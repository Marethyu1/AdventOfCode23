namespace AdventOfCode.Day11;

public class Pair: Tuple<Coord, Coord>
{
    public Pair(Coord item1, Coord item2) : base(item1, item2)
    {
        
    }

    public override string ToString()
    {
        return $"{Item1},{Item2}";
    }

    public int DetermineDistance()
    {
        return Math.Abs(Item1.X - Item2.X) + Math.Abs(Item1.Y - Item2.Y);
    }
}