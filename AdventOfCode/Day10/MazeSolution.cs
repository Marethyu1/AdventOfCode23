namespace AdventOfCode.Day10;

public class MazeSolution: ISolution<int>
{
    private readonly (int x, int y) startCoord;
    private readonly Node[][] _nodes;
    public MazeSolution(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        
        var nodes = new List<List<Node>>();
        for (var i = 0; i < lines.Length; i++)
        {
            var nodeRow = new List<Node>();
            for (var j = 0; j < lines[i].Length; j++)
            {
                Console.Write($"({i},{j})");
                var node = new Node(lines[i][j]);
                if (node.IsStartingNode)
                {
                    startCoord = (i, j);
                }
                nodeRow.Add(node);
            }
            Console.Write($"\n");
            nodes.Add(nodeRow);
        }
        
        _nodes = nodes.Select(x => x.ToArray()).ToArray();
    }
    
    public int Solve()
    {
        var coords = new List<(int a, int b)>()
        {
            // CoordHelper.Down(startCoord), // v
            // CoordHelper.Up(startCoord), // ^ 
            CoordHelper.Right(startCoord), // >
            // CoordHelper.Left(startCoord) //  < 
        }.Where(InBounds).ToArray();

        var tracker = new List<(int x, int y)>();


        foreach (var seedCoord in coords)
        {
            Console.WriteLine($"processing {seedCoord}");
            var current = startCoord;
            var next = seedCoord;
            
            Console.WriteLine(next);
            var isBroken = false;
            var count = 1;
            while (next != startCoord && !isBroken)
            {
                
                _nodes[current.x][current.y].Visited = true;
                _nodes[current.x][current.y].Counter = count;
                count += 1;
                var nextNext = CoordHelper.Next(current, next, _nodes);
                
                current = next;
                next = nextNext;
                if (next == (-1, -1))
                {
                    isBroken = true;
                }
                
            }

            foreach (var node in _nodes)
            {
                foreach (var n in node)
                {
                    Console.Write(n.Visited ? n.Value == Value.NorthSouth ?  (char) n.Value : '*' : '.');
                }
                
                Console.Write("\n");
            }
            
            Console.WriteLine(next + " wow " + count/2);
            if (next == startCoord)
            {
                // return count/2;
            }
            
        }
        
        
        
        
        return 1;
    }

    private bool InBounds((int x, int y) coord)
    {
        return coord.x >= 0 && coord.x < _nodes.Length && coord.y >=0 && coord.y < _nodes[0].Length;
    }
}