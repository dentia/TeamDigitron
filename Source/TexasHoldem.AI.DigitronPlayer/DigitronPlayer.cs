﻿namespace TexasHoldem.AI.DigitronPlayer
{
    using System.Runtime.CompilerServices;

    using TexasHoldem.AI.DigitronPlayer.DecisionMakers;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Players;
    public class DigitronPlayer : BasePlayer
    {
        public IDecisionMaker DesicionMaker;
        public override string Name => "Digitron";

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            if (context.RoundType == GameRoundType.PreFlop)
            {
                GetDecisionMaker(context.SmallBlind * 2, context.MoneyLeft);
                return this.DesicionMaker.DecidePreflop(context);
            }

            return this.DesicionMaker.DecideOthers(context, this.CommunityCards);
        }

        private void GetDecisionMaker(int blind, int moneyLeft)
        {
            if (moneyLeft <= blind * 50)
            {
                this.DesicionMaker = new DesperateBot(this.FirstCard, this.SecondCard);
            }
            else if (moneyLeft <= blind * 250)
            {
                this.DesicionMaker = new MingyBot(this.FirstCard, this.SecondCard);
            }
            else
            {
                this.DesicionMaker = new RiskTaker(this.FirstCard, this.SecondCard);
            }
        }
    }
}