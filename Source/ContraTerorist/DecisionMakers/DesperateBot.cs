namespace ContraTerorist.DecisionMakers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public class DesperateBot : IDecisionMaker
    {
        public DesperateBot(Card a, Card b)
        {
            this.FirstCard = a;
            this.SecondCard = b;
        }

        public Card FirstCard { get; }

        public Card SecondCard { get; }

        public bool ShouldKeepCards()
        {
            if (this.FirstCard.Type == CardType.Ace || this.SecondCard.Type == CardType.Ace)
            {
                return true;
            }

            return Math.Abs((int)this.FirstCard.Type - (int)this.SecondCard.Type) <= 4 
                || this.FirstCard.Suit == this.SecondCard.Suit;
        }

        public PlayerAction DecidePreflop(GetTurnContext context)
        {
            return this.ShouldKeepCards() ? PlayerAction.CheckOrCall() : PlayerAction.Fold();
        }

        public PlayerAction DecideOthers(GetTurnContext context, IReadOnlyCollection<Card> communityCards)
        {
            if (communityCards.Where(x=>(int)x.Type > 9).ToArray().Any(card => card.Type == this.FirstCard.Type || card.Type == this.SecondCard.Type))
            {
                return PlayerAction.Raise(2000);
            }

            return context.IsAllIn ? PlayerAction.Fold() : PlayerAction.CheckOrCall();
        }
    }
}
