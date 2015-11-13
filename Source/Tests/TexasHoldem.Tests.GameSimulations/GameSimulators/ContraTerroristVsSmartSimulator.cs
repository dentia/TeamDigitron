namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using ContraTerorist;

    using TexasHoldem.AI.SmartPlayer;
    using TexasHoldem.Logic.Players;

    public class ContraTerroristVsSmartSimulator : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new ContraTerrorist();

        private readonly IPlayer secondPlayer = new SmartPlayer();

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
