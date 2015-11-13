namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using ContraTerorist;

    using TexasHoldem.AI.DummyPlayer;
    using TexasHoldem.Logic.Players;

    public class ContraTerroristVsDummySimulator:BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new ContraTerrorist();

        private readonly IPlayer secondPlayer = new DummyPlayer();

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
