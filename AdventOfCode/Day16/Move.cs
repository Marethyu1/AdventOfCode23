namespace AdventOfCode.Day16;

public record Move(Coord Coord, Direction Direction)
{
    public readonly Coord Coord = Coord;
    public readonly Direction Direction = Direction;
}