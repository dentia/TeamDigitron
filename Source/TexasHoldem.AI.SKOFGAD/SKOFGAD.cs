namespace TexasHoldem.AI.SKOFGAD
{
    using System;

    using TexasHoldem.AI.SKOFGAD.DecisionMaker;
    using TexasHoldem.AI.SKOFGAD.DecisionMaker.Factory;
    using TexasHoldem.Logic.Players;

    public class SKOFGAD : EnchancedPlayer
    {
        private const int AllIn = 2000;

        private readonly IDecisionMakerFactory factory;

        public SKOFGAD()
            : base(Guid.NewGuid().ToString())
        {
            this.MyLastRaise = 1;
            this.factory = new DecisionMakerFactory();
        }

        public override PlayerAction GetTurn(GetTurnContext context)
        {
            if (context.MoneyLeft / this.BigBlind <= 5)
            {
                return PlayerAction.Raise(AllIn);
            }

            var decisionMaker = this.factory.GetDecisionMaker(context.RoundType);
            var decisionContext = new DecisionContext
                                      {
                                          CommunityCards = this.CommunityCards,
                                          FirstCard = this.FirstCard,
                                          SecondCard = this.SecondCard,
                                          TurnContext = context
                                      };

            return decisionMaker.GetAction(decisionContext, this);
        }
    }
}
