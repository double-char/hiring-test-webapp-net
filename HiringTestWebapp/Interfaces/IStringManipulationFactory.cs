using HiringTestWebapp.Interfaces;
using static HiringTestWebapp.Services.StringManipulationFactory;

public interface IStringManipulationFactory
{
    IStringManipulationStrategy GetInstance(StrategyType strategyType);
}
