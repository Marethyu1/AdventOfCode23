namespace AdventOfCode.DayTwo;

public class Turn
{
    public Dictionary<string, int> Combos = new(); 

    public void AddCombo(string colour, int amount)
    {
        Combos[colour] = amount;
    }
}