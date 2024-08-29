using static HiringTestWebapp.Services.StringManipulationFactory;

namespace HiringTestWebapp.DTO;

public class ManipulateStringRequest
{
    public required string Input { get; set; }

    public StrategyType Strategy { get; set; }
}