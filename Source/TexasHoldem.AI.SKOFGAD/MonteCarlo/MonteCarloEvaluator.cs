namespace TexasHoldem.AI.SKOFGAD.MonteCarlo
{
    using System.Collections.Generic;
    using System.Linq;

    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Extensions;
    using TexasHoldem.Logic.Helpers;

    public class MonteCarloEvaluator
    {
        public static IList<TwoCards> GetAllCombinationsOfTwoCards(IList<Card> deck)
        {
            IList<TwoCards> combinations = new List<TwoCards>();
            for (var i = 0; i < deck.Count - 1; i++)
            {
                for (var j = i + 1; j < deck.Count; j++)
                {
                    var twoCards = new TwoCards(deck[i], deck[j]);
                    combinations.Add(twoCards);
                }
            }

            return combinations;
        }

        public static decimal GetHandStrenght(Card firstCard, Card secondCard, IReadOnlyCollection<Card> communityCards)
        {
            var deck = new List<Card>(Deck.AllCards.ToList());
            deck.Remove(firstCard);
            deck.Remove(secondCard);
            foreach (var card in communityCards)
            {
                deck.Remove(card);
            }

            var toEvalOurRank = new List<Card>(communityCards) { firstCard, secondCard };

            var combinations = GetAllCombinationsOfTwoCards(deck);
            
            combinations = combinations.Shuffle().ToList();

            var ahead = 0;
            var tied = 0;
            var behind = 0;
            
            foreach (var betterHand in combinations
                    .Select(oppCards => new List<Card>(communityCards) { oppCards.FirstCard, oppCards.SecondCard })
                .Select(toEvalOppRank => Helpers.CompareCards(toEvalOurRank, toEvalOppRank)))
            {
                if (betterHand > 0)
                {
                    ahead++;
                }
                else if (betterHand < 0)
                {
                    behind++;
                }
                else
                {
                    tied++;
                }
            }

            return (ahead + (tied / 2m)) / (ahead + tied + behind);
        }
    }
}
