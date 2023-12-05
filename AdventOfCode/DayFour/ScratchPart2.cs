namespace AdventOfCode.DayFour;

public class ScratchPart2 : ISolution<int>
{
    private List<Card> _cards;
    private PriorityQueue<Card, int> _cardsToBeProcessed;
    
    
    public ScratchPart2(string input)
    {
        _cards = input.Trim()
            .Split(Environment.NewLine)
            .Where(x => !string.IsNullOrEmpty(x) && x.Length > 5)
            .Select(x => Card.Parse(x, null)).ToList();

        _cardsToBeProcessed = new PriorityQueue<Card, int>();

        foreach (var card in _cards)
        {
            _cardsToBeProcessed.Enqueue(card, card.CardNumber);
        }
    }

    private static bool IsWinning(Card c)
    {
        return c.Score() > 0;
    }


    public int Solve()
    {
        var counter = 0;
        while (_cardsToBeProcessed.Count > 0)
        {
            var current = _cardsToBeProcessed.Dequeue();
            for (var i = 0; i < current.MatchingNumbers; i++)
            {
                _cardsToBeProcessed.Enqueue(_cards[i + current.CardNumber], i + current.CardNumber);
            }

            counter++;
        }

        return counter;
    }
}