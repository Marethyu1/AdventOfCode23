using System.Globalization;

namespace AdventOfCode.DayFour;

public class ScratchCards: ISolution<int>
{
    private List<Card> _cards;
    
    public ScratchCards(string input)
    {
        _cards = input.Trim()
            .Split(Environment.NewLine)
            .Select(x => Card.Parse(x, null)).ToList();
    }
    
    public int Solve()
    {
        return _cards
            .Sum(c => c.Score());
    }
}