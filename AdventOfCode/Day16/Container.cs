namespace AdventOfCode.Day16;

public class Container
{
    public char Value { get; }

    public bool VisitCount => _visits > 0;
    public bool Visited => _visits > 1;
    private int _visits = 0;

    public bool IsVisited(Move move) => _moves.Contains(move);

    private HashSet<Move> _moves = new HashSet<Move>();

    public Container(char value)
    {
        Value = value;
    }

    public override string ToString()
    {
        if (_visits > 1)
        {
            // return "#";
            return _visits.ToString();
        } 
        else if (_visits > 0)
        {
            return "#";
        }
        return Value.ToString();
    }

    public void Visit(Move currentMove)
    {
        _moves.Add(currentMove);
        _visits++;
        // Visited = true;
    }
}