using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem.Tests.GameSimulations.GameSimulators
{
    using TexasHoldem.AI.DigitronPlayer;
    using TexasHoldem.AI.DummyPlayer;
    using TexasHoldem.Logic.Players;

    class DigitronVsAlwaysFoldSimulator : BaseGameSimulator
    {
        private readonly IPlayer firstPlayer = new DigitronPlayer();
        private readonly IPlayer secondPlayer = new AlwaysFoldDummyPlayer();

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
