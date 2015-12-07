namespace TexasHoldem.AI.SKOFGAD.MonteCarlo
{
    using TexasHoldem.Logic.Cards;

    public class TwoCards
    {
        public TwoCards(Card first, Card second)
        {
            this.FirstCard = first;
            this.SecondCard = second;
        }

        public Card FirstCard { get; set; }

        public Card SecondCard { get; set; }
    }
}