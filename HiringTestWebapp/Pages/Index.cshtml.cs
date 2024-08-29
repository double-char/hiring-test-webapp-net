using HiringTestWebapp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HiringTestWebapp.Pages;

public class IndexModel : PageModel
{
    public List<SelectListItem> Strategies { get; } = new List<SelectListItem>
    {
        new("Longest word", StringManipulationFactory.StrategyType.Longest.ToString()),
        new("Shortest word", StringManipulationFactory.StrategyType.Shortest.ToString())
    };

    public string? Result { get; set; }

    public IndexModel()
    {
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost(string input, string strategy)
    {
        try
        {
            Result = new StringManipulationFactory()
                .GetInstance(
                    Enum.Parse<StringManipulationFactory.StrategyType>(strategy)
                )
                .Manipulate(input);
        }
        catch (Exception ex)
        {
            Result = ex.Message;
        }
        return Page();
    }
}
