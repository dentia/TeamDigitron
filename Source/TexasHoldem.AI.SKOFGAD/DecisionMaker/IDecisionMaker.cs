namespace TexasHoldem.AI.SKOFGAD.DecisionMaker
{
    using TexasHoldem.Logic.Players;

    public interface IDecisionMaker
    {
        PlayerAction GetAction(IDecisionContext ctx, EnchancedPlayer player);
    }
}
