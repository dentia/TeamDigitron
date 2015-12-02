namespace TexasHoldem.Tests.GameSimulations
{
    using System;

    using TexasHoldem.Tests.GameSimulations.GameSimulators;

    public static class Program
    {
        public static void Main()
        {

            SimulateGames(new ContraTerroristVsAlwaysCallSimulator());
            SimulateGames(new ContraTerroristVsDummySimulator());
            SimulateGames(new ContraTerroristVsSmartSimulator());
            SimulateGames(new ContraTerrorisVsAlwaysRaiseSimulator());
            SimulateGames(new ContraTerroristVsAlwaysFoldSimulator());

            SimulateGames(new DigitronVsSmartSimulator());
            SimulateGames(new DigitronVsDummySimulator());
            SimulateGames(new DigitronVsAlwaysCallSimulator());
            SimulateGames(new DIgitronVsContraTeroristSimulator());
            SimulateGames(new DigitronVsAlwaysFoldSimulator());
            SimulateGames(new DigitronVsAlwaysRaiseSimulator());

        }

        private static void SimulateGames(IGameSimulator gameSimulator)
        {
            Console.WriteLine($"Running {gameSimulator.GetType().Name}...");

            var simulationResult = gameSimulator.Simulate(10000);

            Console.WriteLine(simulationResult.SimulationDuration);
            Console.WriteLine($"Total games: {simulationResult.FirstPlayerWins:0,0} - {simulationResult.SecondPlayerWins:0,0}");
            Console.WriteLine($"Hands played: {simulationResult.HandsPlayed:0,0}");
            Console.WriteLine(new string('=', 75));
        }
    }
}
