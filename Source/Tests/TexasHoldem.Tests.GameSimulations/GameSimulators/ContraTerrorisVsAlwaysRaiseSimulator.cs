using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using ContraTerorist;

    using TexasHoldem.AI.DigitronPlayer;
    using TexasHoldem.AI.DummyPlayer;
    using TexasHoldem.Logic.Players;

    class ContraTerrorisVsAlwaysRaiseSimulator : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new ContraTerrorist();
        private readonly IPlayer secondPlayer = new AlwaysRaiseDummyPlayer();

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
