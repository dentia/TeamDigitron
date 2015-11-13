namespace TexasHoldem.AI.DigitronPlayer.DecisionMakers
{
    using System.Collections.Generic;
    using System.Linq;

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
            return this.ShouldKeepCards() ? PlayerAction.CheckOrCall() : PlayerAction.Fold();
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
