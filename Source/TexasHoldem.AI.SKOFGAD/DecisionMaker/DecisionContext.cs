namespace TexasHoldem.AI.SKOFGAD.DecisionMaker
{
    using System.Collections.Generic;

    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public class DecisionContext : IDecisionContext
    {
        public GetTurnContext TurnContext { get; set; }

        public Card FirstCard { get; set; }

        public Card SecondCard { get; set; }

        public IReadOnlyCollection<Card> CommunityCards { get; set; }
    }
}
