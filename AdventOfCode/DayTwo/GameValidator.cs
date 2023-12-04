namespace AdventOfCode.DayTwo;

public class GameValidator
{
    private readonly List<GameRule> _rules;

    public GameValidator(List<GameRule> rules)
    {
        _rules = rules;
    }

    public bool IsPossible(Game game)
    {
        return game.Turns.All(IsTurnPossible);
    }

    private bool IsTurnPossible(Turn turn)
    {
        foreach (var rule in _rules)
        {
            if (turn.Combos.TryGetValue(rule.Colour, out var combo))
            {
                if (combo > rule.MaxAmount)
                {
                    return false;
                }
            }
        }

        return true;
    }
}