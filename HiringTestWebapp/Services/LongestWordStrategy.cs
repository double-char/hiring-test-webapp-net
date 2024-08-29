

using HiringTestWebapp.Interfaces;

namespace HiringTestWebapp.Services;

public class LongestWordStrategy : IStringManipulationStrategy
{
    public string? Manipulate(string? input)
    {
        var words = input?.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return words?.OrderByDescending(w => w.Length)?.FirstOrDefault();
    }
}
