namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using ContraTerorist;

    using TexasHoldem.AI.DigitronPlayer;
    using TexasHoldem.Logic.Players;

    public class DIgitronVsContraTeroristSimulator : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new DigitronPlayer();
        private readonly IPlayer secondPlayer = new ContraTerrorist();

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
