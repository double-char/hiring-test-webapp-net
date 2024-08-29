using Moq;
using Microsoft.AspNetCore.Mvc;
using HiringTestWebapp.ApiControllers;
using HiringTestWebapp.DTO;
using HiringTestWebapp.Interfaces;
using HiringTestWebapp.Services;
using HiringTestWebapp.Tests.Helpers;

namespace HiringTestWebapp.Tests;

public class StringManipulationControllerTests
{
    private readonly Mock<IStringManipulationFactory> _mockFactory;
    private readonly StringManipulationController _controller;

    public StringManipulationControllerTests()
    {
        _mockFactory = new Mock<IStringManipulationFactory>();
        _controller = new StringManipulationController(_mockFactory.Object);
    }

    [Fact]
    public void GetStrategies_ReturnsStrategies_OkResult()
    {
        // Act
        var result = _controller.GetStrategies();

        // Assert
        Assert.NotNull(result);

        var actionResult = Assert.IsType<ActionResult<List<KeyValuePair<string, int>>>>(result);
        var okResult = Assert.IsType<List<KeyValuePair<string, int>>>(actionResult.Value);

        Assert.NotNull(okResult);
        Assert.Equal(2, okResult.Count);

        Assert.Contains(okResult, s => s.Key == "Longest word" && s.Value == (int)StringManipulationFactory.StrategyType.Longest);
        Assert.Contains(okResult, s => s.Key == "Shortest word" && s.Value == (int)StringManipulationFactory.StrategyType.Shortest);
    }

    [Fact]
    public void Manipulate_ReturnsManipulatedResult_OkResult()
    {
        // Arrange
        var request = new ManipulateStringRequest
        {
            Strategy = (int)StringManipulationFactory.StrategyType.Longest,
            Input = "example ex"
        };

        var mockStrategy = new Mock<IStringManipulationStrategy>();
        mockStrategy.Setup(s => s.Manipulate(request.Input)).Returns("example");
        _mockFactory.Setup(f => f.GetInstance(request.Strategy)).Returns(mockStrategy.Object);

        // Act
        var result = _controller.Manipulate(request);

        // Assert
        Assert.NotNull(result);

        var actionResult = Assert.IsType<ActionResult<ManipulateStringResponse>>(result);
        Assert.NotNull(actionResult);

        var okResult = Assert.IsType<ManipulateStringResponse>(actionResult.Value);
        Assert.NotNull(okResult);

        Assert.Equal("example", okResult.Result);
    }

    [Fact]
    public void Manipulate_ThrowsArgumentException_BadRequest()
    {
        // Arrange
        var request = new ManipulateStringRequest
        {
            Strategy = (int)StringManipulationFactory.StrategyType.Longest,
            Input = "example"
        };

        _mockFactory.Setup(f => f.GetInstance(request.Strategy)).Throws(new ArgumentException("Invalid strategy"));

        // Act
        var result = _controller.Manipulate(request);

        // Assert
        Assert.NotNull(result);

        var actionResult = Assert.IsType<ActionResult<ManipulateStringResponse>>(result);

        var badRequest = Assert.IsType<BadRequestObjectResult>(actionResult.Result);

        Assert.Equal("Invalid strategy", badRequest.Value);
    }
}
