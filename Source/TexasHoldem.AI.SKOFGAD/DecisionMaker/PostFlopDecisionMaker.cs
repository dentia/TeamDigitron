namespace TexasHoldem.AI.SKOFGAD.DecisionMaker
{
    using System;

    using TexasHoldem.AI.SKOFGAD.MonteCarlo;
    using TexasHoldem.Logic;
    using TexasHoldem.Logic.Players;

    public class PostFlopDecisionMaker : IDecisionMaker
    {
        public PlayerAction GetAction(IDecisionContext ctx, EnchancedPlayer player)
        {
            var handStrenght = MonteCarloEvaluator.GetHandStrenght(
               ctx.FirstCard,
               ctx.SecondCard,
               ctx.CommunityCards);

            var currScore = handStrenght;

            if (ctx.TurnContext.RoundType == GameRoundType.River && currScore > 0.92m)
            {
                return PlayerAction.Raise(2000);
            }

            if (currScore > 0.85m)
            {
                player.LastHandStrenght = currScore;
                player.MyLastRaise = Math.Max(ctx.TurnContext.MoneyLeft / 4, (int)(player.MyLastRaise * (1 + currScore)));
                return PlayerAction.Raise(player.MyLastRaise);
            }

            if ((currScore > player.LastHandStrenght) && (currScore > 0.6m))
            {
                player.LastHandStrenght = currScore;
                player.MyLastRaise = (int)(player.MyLastRaise * (1 + currScore));
                return PlayerAction.Raise(player.MyLastRaise);
            }
            else
            {
                if (currScore > 0.6m)
                {
                    var result = PlayerAction.CheckOrCall();
                    player.LastHandStrenght = currScore;
                    return result;
                }
                else
                {
                    player.LastHandStrenght = currScore;
                    if (ctx.TurnContext.CanCheck)
                    {
                        return PlayerAction.CheckOrCall();
                    }

                    return PlayerAction.Fold();
                }
            }
        }
    }
}
