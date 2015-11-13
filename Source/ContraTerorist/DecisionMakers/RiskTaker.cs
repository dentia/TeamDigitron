namespace ContraTerorist.DecisionMakers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

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
            return PlayerAction.Raise((int)(context.MoneyLeft * 0.2));
        }

        public PlayerAction DecideOthers(GetTurnContext context, IReadOnlyCollection<Card> communityCards)
        {
            return PlayerAction.CheckOrCall();
        }
    }
}
