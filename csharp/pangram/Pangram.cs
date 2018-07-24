using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        var normalizedDistinctLetters = input
            .ToLower()
            .ToCharArray()
            .Distinct()
            .Where(c => char.IsLetter(c))
            .ToArray();
        return normalizedDistinctLetters.Length == 26;
    }
}
