using HiringTestWebapp.Interfaces;

namespace HiringTestWebapp.Services;

public class StringManipulationFactory : IStringManipulationFactory
{
    public enum StrategyType
    {
        Longest,
        Shortest,
        Random
    }

    public IStringManipulationStrategy GetInstance(StrategyType strategyType)
    {
        return strategyType switch
        {
            StrategyType.Longest => new LongestWordStrategy(),
            StrategyType.Shortest => new ShortestWordStrategy(),
            _ => throw new ArgumentException("Not implemented strategy", nameof(strategyType)),
        };
    }
}
