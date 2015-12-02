namespace Algorithms.Contracts
{
    using TexasHoldem.Logic.Cards;

    public interface IPreFlopStrategy
    {
        double CalculateProbability();
    }
}
