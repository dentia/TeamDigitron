namespace TexasHoldem.AI.SKOFGAD
{
    using System.Collections.Generic;

    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Helpers;
    using TexasHoldem.Logic.Players;

    public abstract class EnchancedPlayer : BasePlayer
    {
        private readonly IHandEvaluator handEvaluator;

        protected EnchancedPlayer(string name)
        {
            this.Name = name;
            this.handEvaluator = new HandEvaluator();
        }

        public override string Name { get; }

        public bool IsDealer { get; set; }

        public int BigBlind { get; set; }

        public int OpponentMoney { get; set; }

        public int LastOpponentRaise { get; set; }

        public decimal LastHandStrenght { get; set; }

        public int MyLastRaise { get; set; }

        public int PocketStrength { get; set; }
        
        public decimal PocketRaisePercent { get; set; }

        public BestHand BestHand { get; set; }

        public override void EndHand(EndHandContext context)
        {
            base.EndHand(context);

            this.LastOpponentRaise = 0;
        }

        public override void StartHand(StartHandContext context)
        {
            base.StartHand(context);

            this.PocketRaisePercent = PreflopHandEvaluator.GetPocketStrength(this.FirstCard, this.SecondCard);
            this.PocketStrength = (int)(this.PocketRaisePercent * 100);
            this.OpponentMoney = 2000 - context.MoneyLeft;
            this.BigBlind = context.SmallBlind * 2;
            this.MyLastRaise = 0;
        }

        public override void StartRound(StartRoundContext context)
        {
            base.StartRound(context);

            if (context.RoundType != GameRoundType.PreFlop)
            {
                this.BestHand =
                    this.handEvaluator.GetBestHand(
                        new List<Card>(this.CommunityCards) { this.FirstCard, this.SecondCard });
            }
        }
    }
}
