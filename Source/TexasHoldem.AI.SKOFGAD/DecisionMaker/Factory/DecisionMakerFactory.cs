namespace TexasHoldem.AI.SKOFGAD.DecisionMaker.Factory
{
    using System.Collections.Generic;

    using TexasHoldem.Logic;

    public class DecisionMakerFactory : IDecisionMakerFactory
    {
        private const int DefaultId = -1;
        private readonly IDictionary<int, IDecisionMaker> factories;

        public DecisionMakerFactory()
        {
            this.factories = new Dictionary<int, IDecisionMaker>();
        }

        public IDecisionMaker GetDecisionMaker(GameRoundType gameRoundType)
        {
            switch (gameRoundType)
            {
                    case GameRoundType.PreFlop:

                    if (!this.factories.ContainsKey((int)gameRoundType))
                    {
                        this.factories.Add((int)gameRoundType, new PreFlopDecisionMaker());
                    }

                    return this.factories[(int)gameRoundType];
                default:

                    if (!this.factories.ContainsKey(DefaultId))
                    {
                        this.factories.Add(DefaultId, new PostFlopDecisionMaker());
                    }

                    return this.factories[DefaultId];
            }
        }
    }
}
