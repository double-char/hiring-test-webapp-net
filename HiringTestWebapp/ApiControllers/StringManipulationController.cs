using HiringTestWebapp.DTO;
using HiringTestWebapp.Interfaces;
using HiringTestWebapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace HiringTestWebapp.ApiControllers;

[Route("api/[controller]")]
[ApiController]
public class StringManipulationController : ControllerBase
{
    private readonly IStringManipulationFactory _stringManipulationFactory;

    public StringManipulationController(IStringManipulationFactory stringService)
    {
        _stringManipulationFactory = stringService;
    }

    [HttpGet("strategies")]
    public ActionResult<List<KeyValuePair<string, int>>> GetStrategies()
    {
        return new List<KeyValuePair<string, int>>
        {
            new("Longest word", (int)StringManipulationFactory.StrategyType.Longest),
            new("Shortest word", (int)StringManipulationFactory.StrategyType.Shortest)
        };
    }

    [HttpPost("manipulate")]
    public ActionResult<ManipulateStringResponse> Manipulate([FromBody] ManipulateStringRequest request)
    {
        try
        {
            var strategyInstance = _stringManipulationFactory.GetInstance(request.Strategy);
            var result = strategyInstance.Manipulate(request.Input);

            return new ManipulateStringResponse
            {
                Result = result
            };
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
