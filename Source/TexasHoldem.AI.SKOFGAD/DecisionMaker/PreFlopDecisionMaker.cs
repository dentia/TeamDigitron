namespace TexasHoldem.AI.SKOFGAD.DecisionMaker
{
    using System;

    using TexasHoldem.Logic.Cards;
    using TexasHoldem.Logic.Players;

    public class PreFlopDecisionMaker : IDecisionMaker
    {
        public PlayerAction GetAction(IDecisionContext ctx, EnchancedPlayer player)
        {
            if (player.PocketStrength > 20 || ctx.FirstCard.Type == CardType.Ace || ctx.SecondCard.Type == CardType.Ace)
            {
                player.MyLastRaise = Math.Max(player.BigBlind, (int)(ctx.TurnContext.MoneyLeft * player.PocketRaisePercent));
                return PlayerAction.Raise(player.MyLastRaise);
            }

            if (player.PocketStrength > 0 || ctx.TurnContext.CanCheck)
            {
                return PlayerAction.CheckOrCall();
            }
            else
            {
                var myBigBlinds = (int)Math.Ceiling(ctx.TurnContext.MoneyLeft / (ctx.TurnContext.SmallBlind * 2.0));
                var bigBlindsToCall = (int)Math.Ceiling(ctx.TurnContext.MoneyToCall / (ctx.TurnContext.SmallBlind * 2.0));
                if (myBigBlinds / bigBlindsToCall < 10)
                {
                    return PlayerAction.CheckOrCall();
                }

                return PlayerAction.Fold();
            }
        }
    }
}
