using HiringTestWebapp.Interfaces;

namespace HiringTestWebapp.Services;

public class ShortestWordStrategy : IStringManipulationStrategy
{
    public string? Manipulate(string? input)
    {
        var words = input?.Split(new[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        return words?.OrderBy(w => w.Length)?.FirstOrDefault();
    }
}
