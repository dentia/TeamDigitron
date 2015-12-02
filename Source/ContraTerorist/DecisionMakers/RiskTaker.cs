namespace ContraTerorist.DecisionMakers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    using Algorithms;

    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public class RiskTaker : IDecisionMaker
    {
        public RiskTaker(Card a, Card b)
        {
            this.FirstCard = a;
            this.SecondCard = b;
        }

        public Card FirstCard { get; private set; }

        public Card SecondCard { get; private set; }

        public bool ShouldKeepCards()
        {
            return true;
        }

        public PlayerAction DecidePreflop(GetTurnContext context)
        {
            ChenAlgorithm chen = new ChenAlgorithm(this.FirstCard, this.SecondCard);

            double chenScore = chen.CalculateProbability();

            if (chenScore > 17)
            {
                return PlayerAction.Raise(2000);
            }

            if (chenScore > 15)
            {
                return PlayerAction.Raise(context.MoneyLeft / 3);
            }


            if (chenScore > 12)
            {
                return PlayerAction.Raise(context.MoneyLeft/4);
            }

            if (chenScore >= (double)ChenConstants.EarlyRaise)
            {
                //calc the  right ammount to raise
                return PlayerAction.Raise(context.SmallBlind*30);
            }

            if (chenScore > (double)ChenConstants.EarlyFold)
            {
                if (context.MoneyToCall < context.MoneyLeft / 20)
                    return PlayerAction.CheckOrCall();
            }

            return PlayerAction.Fold();

            //return PlayerAction.Raise((int)(context.MoneyLeft * 0.2));
        }

        public PlayerAction DecideOthers(GetTurnContext context, IReadOnlyCollection<Card> communityCards)
        {
            return PlayerAction.CheckOrCall();
        }
    }
}
