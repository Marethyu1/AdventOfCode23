namespace AdventOfCode.DayTwo;

public static class PowerCalculator
{
    public static int Power(Game game)
    {
        var counter = new Dictionary<string, int>();
        
        foreach (var turn in game.Turns)
        {
            foreach (var key in turn.Combos.Keys)
            {
                var turnAmount = turn.Combos[key];
                int currentMaxAmount;
                var hasValue = counter.TryGetValue(key, out currentMaxAmount);

                if (!hasValue)
                {
                    counter[key] = turnAmount;
                }
                else if (turnAmount > currentMaxAmount)
                {
                    counter[key] = turnAmount;
                }
            }
        }
        return counter.Values.Aggregate(1, (x, y) => x * y);
    }
}