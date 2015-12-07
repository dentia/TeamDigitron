namespace TexasHoldem.AI.SKOFGAD.DecisionMaker
{
    using System.Collections.Generic;

    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public interface IDecisionContext
    {
        GetTurnContext TurnContext { get; set; }

        Card FirstCard { get; set; }

        Card SecondCard { get; set; }

        IReadOnlyCollection<Card> CommunityCards { get; set; }
    }
}
