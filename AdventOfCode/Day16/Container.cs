namespace AdventOfCode.Day16;

public class Container
{
    public char Value { get; }

    public bool VisitCount => _moves.Count > 0;
    public bool Visited => Visits > 1;
    public int Visits = 0;

    public bool IsVisited(Move move) => _moves.Contains(move);

    private HashSet<Move> _moves = new HashSet<Move>();

    public Container(char value)
    {
        Value = value;
    }

    public override string ToString()
    {
        if (Visits > 1)
        {
            // return "#";
            return Visits.ToString();
        } 
        else if (Visits > 0)
        {
            return "#";
        }
        return Value.ToString();
    }

    public void Visit(Move currentMove)
    {
        _moves.Add(currentMove);
        Visits++;
    }

    public string Debug()
    {
        if (Visits > 1 && Value == '.')
        {
            return "#";
        } 
        else if (Visits > 0)
        {
            return "#";
        }

        return ".";
    }
}