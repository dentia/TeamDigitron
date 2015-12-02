namespace ContraTerorist.DecisionMakers
{
    using System.Collections.Generic;
    using System.Linq;

    using Algorithms;

    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public class MingyBot : IDecisionMaker
    {
        public MingyBot(Card a, Card b)
        {
            this.FirstCard = a;
            this.SecondCard = b;
        }

        public Card FirstCard { get; private set; }

        public Card SecondCard { get; private set; }

        public bool ShouldKeepCards()
        {
            return ((int)this.FirstCard.Type >= 10 && (int)this.SecondCard.Type >= 10)
                   || this.FirstCard.Type == this.SecondCard.Type;
        }

        public PlayerAction DecidePreflop(GetTurnContext context)
        {
            ChenAlgorithm chen = new ChenAlgorithm(this.FirstCard, this.SecondCard);

            double chenScore = chen.CalculateProbability();

            if (chenScore > 17)
            {
                return PlayerAction.Raise(2000);
            }

            if (chenScore > 15)
            {
                return PlayerAction.Raise(context.MoneyLeft / 3);
            }
            if (chenScore > 12)
            {
                return PlayerAction.Raise(context.MoneyLeft/7);
            }

            if (chenScore >= (double)ChenConstants.MidRaise)
            {
                //calc the  right ammount to raise
                return PlayerAction.CheckOrCall();
            }

            if (chenScore > (double)ChenConstants.MidFold)
            {

                if (context.MoneyToCall < context.MoneyLeft / 25)
                    return PlayerAction.CheckOrCall();

            }

            return PlayerAction.Fold();
        }

        public PlayerAction DecideOthers(GetTurnContext context, IReadOnlyCollection<Card> communityCards)
        {
            if (context.CanCheck)
            {
                return PlayerAction.CheckOrCall();
            }
            else
            {
                return communityCards.Any(card => card.Type == this.FirstCard.Type || card.Type == this.SecondCard.Type)
                    ? PlayerAction.CheckOrCall()
                    : PlayerAction.Fold();
            }
        }
    }
}
