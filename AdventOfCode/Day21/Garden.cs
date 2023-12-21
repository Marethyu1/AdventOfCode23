using System.Text;
using AdventOfCode.Shared;

namespace AdventOfCode.Day21;

public class Garden: Grid<Plot>
{
    public Coord StartCord { get; }

    public Queue<Coord> Queue = new();
    
    public Garden(Plot[][] input) : base(input)
    {
        for (var r = 0; r < input.Length; r++)
        {
            for (var c = 0; c < input.Length; c++)
            {
                var plot = input[r][c];
                if (plot.Input == 'S')
                {
                    StartCord = new Coord(r, c);
                    input[r][c] = new Plot('.');
                }
            }
        }

        Queue.Enqueue(StartCord);
    }

    public void Walk()
    {
        var queue = new Queue<Coord>();
        while (Queue.Any())
        {
            var currentCord = Queue.Dequeue();

            var directions = new List<Coord>()
            {
                currentCord.NextCoord(Direction.Up),
                currentCord.NextCoord(Direction.Down),
                currentCord.NextCoord(Direction.Left),
                currentCord.NextCoord(Direction.Right),
            };

            var validDirections = directions.Where(InBounds)
                .Where(coord => this[coord].Walkable);

            foreach (var coord in validDirections)
            {
                if (!queue.Contains(coord))
                    queue.Enqueue(coord);
            }
        }

        Queue = queue;
    }

    public override string ToString()
    {
        var b = new StringBuilder();
        for (var r = 0; r < Input.Length; r++)
        {
            for (var c = 0; c < Input[0].Length; c++)
            {
                var coord = new Coord(r, c);
                if (Queue.Contains(coord))
                {
                    b.Append("O");
                }
                else
                {
                    b.Append(this[coord]);
                }
            }

            b.AppendLine();
        }
        return b.ToString();
    }
}