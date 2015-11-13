namespace TexasHoldem.AI.DigitronPlayer.DecisionMakers
{
    using System.Collections.Generic;

    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public interface IDecisionMaker
    {
        Card FirstCard { get; }

        Card SecondCard { get; }

        bool ShouldKeepCards();

        PlayerAction DecidePreflop(GetTurnContext context);

        PlayerAction DecideOthers(GetTurnContext context, IReadOnlyCollection<Card> communityCards);
    }
}
