namespace AdventOfCode.DayFour;

public class Card : IParsable<Card>
{
    public readonly int CardNumber;
    public readonly HashSet<int> WinningNumbers;
    public readonly List<int> ScratchNumbers;

    public Card(int cardNumber, HashSet<int> winningNumbers, List<int> scratchNumbers)
    {
        CardNumber = cardNumber;
        WinningNumbers = winningNumbers;
        ScratchNumbers = scratchNumbers;
    }

    public static Card Parse(string s, IFormatProvider? provider)
    {
        var line = s.Split(":");
        var cardString = line[0].Split(" ").Where(x => x.Length > 0).ToArray();
        var cardNumber = int.Parse(cardString[1].Trim());
        var splitLine = line[1].Split("|");
        var rawWinningNumbers = splitLine[0]
            .Trim()
            .Split(' ')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(int.Parse)
            .ToHashSet();

        var scratchNumbers = splitLine[1]
            .Trim()
            .Split(' ')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(int.Parse)
            .ToList();

        return new Card(cardNumber, rawWinningNumbers, scratchNumbers);
    }

    public override string ToString()
    {
        return $"{CardNumber}";
    }

    public int MatchingNumbers => ScratchNumbers.Count(n => WinningNumbers.Contains(n));

    public int Score()
    {
        return (int) Math.Pow(2, MatchingNumbers - 1);
    }

    public static bool TryParse(string? s, IFormatProvider? provider, out Card result)
    {
        result = null;
        if (s == null) { return false; }
        try {
            result = Parse(s, provider);
            return true;
        } catch { return false; }
    }
}