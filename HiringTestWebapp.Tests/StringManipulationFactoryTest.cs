using HiringTestWebapp.Services;

namespace HiringTestWebapp.Tests;

public class StringManipulationFactoryTest
{
    private readonly IStringManipulationFactory _stringManipulationFactory;

    public StringManipulationFactoryTest()
    {
        _stringManipulationFactory = new StringManipulationFactory();
    }

    [Fact]
    public void LargestWord_Manipulate_ReturnsLargest()
    {
        var sentence = "The cow jumped over the moon.";
        var expected = "jumped";

        var result = _stringManipulationFactory.GetInstance(StringManipulationFactory.StrategyType.Longest).Manipulate(sentence);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShortestWord_Manipulate_ReturnsShortest()
    {
        var sentence = "The cow jumped over the moon.";
        var expected = "The";

        var result = _stringManipulationFactory.GetInstance(StringManipulationFactory.StrategyType.Shortest).Manipulate(sentence);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void RandomWord_Manipulate_ThrowsNotImplementedException()
    {
        var sentence = "The cow jumped over the moon.";

        Assert.Throws<ArgumentException>(() => _stringManipulationFactory.GetInstance(StringManipulationFactory.StrategyType.Random).Manipulate(sentence));
    }
}