namespace ContraTerorist
{
    using System.Runtime.CompilerServices;

    using ContraTerorist.DecisionMakers;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Players;
    public class ContraTerrorist : BasePlayer
    {
        public IDecisionMaker DesicionMaker;
        public override string Name => "Contra Terrorist";

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
            if (moneyLeft <= blind * 40)
            {
                this.DesicionMaker = new DesperateBot(this.FirstCard, this.SecondCard);
            }
            else if (moneyLeft <= blind * 200)
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
