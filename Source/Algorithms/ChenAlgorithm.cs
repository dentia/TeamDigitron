namespace Algorithms
{
    using System;
    using System.Collections.Generic;

    using Algorithms.Contracts;
    using TexasHoldem.Logic.Cards;

    public class ChenAlgorithm : IPreFlopStrategy
    {
        private readonly Dictionary<CardType, double> cardPoints;

        private Card first;

        private Card second;

        private double score;

        public ChenAlgorithm(Card first, Card second)
        {
            this.cardPoints = new Dictionary<CardType, double>
                                  {
                { CardType.Ace, 10 },
                { CardType.King, 8 },
                { CardType.Queen, 7 },
                { CardType.Jack, 6 },
                { CardType.Ten, 5 },
                { CardType.Nine, 4.5 },
                { CardType.Eight, 4 },
                { CardType.Seven, 3.5 },
                { CardType.Six, 3 },
                { CardType.Five, 2.5 },
                { CardType.Four, 2 },
                { CardType.Three, 1.5 },
                { CardType.Two, 1 },
                };

            this.first = first;
            this.second = second;
        }

        public double CalculateProbability()
        {
            score = 0;

            if (this.first.Type > this.second.Type)
            {
                score += this.cardPoints[this.first.Type];
            }
            else
            {
                score += this.cardPoints[this.second.Type];
            }

            this.CalculateScoreFroPair();

            this.CalculateScoreForSuited();

            this.CalculateScoreForGap();

            return this.score;
        }

        private void CalculateScoreFroPair()
        {
            if (this.first.Type == this.second.Type)
            {
                if (this.first.Type <= CardType.Four && this.first.Type >= CardType.Two)
                {
                    this.score = 5;
                }

                this.score *= 2;
            }
        }

        private void CalculateScoreForSuited()
        {
            if (this.first.Suit == this.second.Suit)
            {
                this.score += 2;
            }
        }

        private void CalculateScoreForGap()
        {
            if (this.first.Type == this.second.Type)
            {
                return;
            }

            int gap = 0;


            bool isFirstCardAce = this.first.Type == CardType.Ace;
            bool isSecondCardAce = this.second.Type == CardType.Ace;

            if (isFirstCardAce || isSecondCardAce)
            {
                var secondCard = isFirstCardAce ? this.second : this.first;
                if ((int)secondCard.Type < 7)
                {
                    gap = Math.Abs(1 - (int)secondCard.Type);
                }
                else
                {
                    gap = Math.Abs(this.first.Type - this.second.Type);
                }
            }
            else
            {
                gap = Math.Abs(this.first.Type - this.second.Type);
            }

            gap--;

            switch (gap)
            {
                case 0:
                    {
                        this.score++;
                        break;
                    }
                case 1:
                    {
                        this.score--;
                        break;
                    }
                case 2:
                    {
                        this.score -= 2;
                        break;
                    }
                case 3:
                    {
                        this.score -= 4;
                        break;
                    }
                default:
                    {
                        this.score -= 5;
                        break;
                    }
            }
        }
    }
}
