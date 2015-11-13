namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using TexasHoldem.AI.DigitronPlayer;
    using TexasHoldem.AI.DummyPlayer;
    using TexasHoldem.Logic.Players;

    public class DigitronVsAlwaysCallSimulator : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new DigitronPlayer();
        private readonly IPlayer secondPlayer = new AlwaysCallDummyPlayer();

        protected override IPlayer GetFirstPlayer()
        {
            return this.firstPlayer;
        }

        protected override IPlayer GetSecondPlayer()
        {
            return this.secondPlayer;
        }
    }
}
