using AdventOfCode.Shared;

namespace AdventOfCode.Day16_v2;

public record Move(Coord Coord, Direction Direction)
{
    public readonly Coord Coord = Coord;
    public readonly Direction Direction = Direction;
}