using AdventOfCode.Shared;

namespace AdventOfCode.Day16_v2;

public class LavaGrid: Grid<Cell>
{
    private readonly Move _startMove;
    private HashSet<Move> _moves = new();
    
    public LavaGrid(Cell[][] input, Move startMove) : base(input)
    {
        _startMove = startMove;
    }

    public bool InBounds(Coord moveCoord)
    {
        try
        {
            var _ = this[moveCoord];
            return true;
        }
        catch (CoordinateOutOfGridException e)
        {
            return false;
        }
    }

    public void Visit(Move current)
    {
        _moves.Add(current);
    }

    public bool Visited(Move move)
    {
        return _moves.Contains(move);
    }

    public int VisitedCoords()
    {
        return _moves.Select(x => x.Coord).ToHashSet().Count;
    }

    public void Reset()
    {
        _moves = new HashSet<Move>();
    }
}