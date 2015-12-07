namespace TexasHoldem.AI.SKOFGAD.DecisionMaker.Factory
{
    using TexasHoldem.Logic;

    public interface IDecisionMakerFactory
    {
        IDecisionMaker GetDecisionMaker(GameRoundType gameRoundType);
    }
}
