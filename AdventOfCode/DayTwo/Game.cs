namespace AdventOfCode.DayTwo;

public class Game
{
    public readonly int Id;
    public readonly List<Turn> Turns = new();

    public Game(int id)
    {
        Id = id;
    }

    public void AddTurn(Turn turn)
    {
        Turns.Add(turn);
    }
}