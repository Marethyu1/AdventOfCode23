using System.Text;
using System.Xml.Schema;

namespace AdventOfCode.DayThree;

public class Grid
{
    private readonly List<List<Container>> _rows;
    private readonly int _nRows;
    private readonly int _nColumns;

    public Grid(List<List<Container>> rows)
    {
        _rows = rows;
        _nRows = rows.Count;
        _nColumns = rows[0].Count;
    }

    public int Solve()
    {
        MarkGrid();
        var builder = new StringBuilder();
        foreach (var row in _rows)
        {
            foreach (var container in row)
            {
                if (container.Marked)
                {
                    builder.Append(container.Value);
                }

                else if (container.HasSymbol())
                {
                    builder.Append(container.Value);
                }
                else
                {
                    builder.Append('.');
                }
            }

            builder.AppendLine();
        }

        Console.WriteLine(builder.ToString());
        var numbers = FindNumbers();
        return numbers.Sum();
    }

    private List<int> FindNumbers()
    {
        
        var ints = new List<int>();
        
        
        foreach (var row in _rows)
        {
            var stack = new Stack<Container>();
            
            foreach (var currentContainer in row)
            {
                if (currentContainer.HasInt())
                {
                    stack.Push(currentContainer);
                }
                else
                {
                    var l = new List<char>();
                    var shouldTrack = stack.Any(x => x.Marked);
                    
                    
                    while (stack.Count > 0)
                    {
                        var value = stack.Pop().Value;
                        if (shouldTrack)
                        {
                            l.Add(value);
                        }
                    }

                    if (l.Any())
                    {
                        l.Reverse();
                        var parsedInt =  int.Parse(string.Join("", l));
                        ints.Add(parsedInt);
                    }
                }
            }
            if (stack.Count > 0)
            {
                var l = new List<char>();
                var shouldTrack = stack.Any(x => x.Marked);
                    
                    
                while (stack.Count > 0)
                {
                    var value = stack.Pop().Value;
                    if (shouldTrack)
                    {
                        l.Add(value);
                    }
                }

                if (l.Any())
                {
                    l.Reverse();
                    var parsedInt =  int.Parse(string.Join("", l));
                    ints.Add(parsedInt);
                }
            }
        }
        
       

        return ints;
    }

    private void MarkGrid()
    {
        for (var x = 0; x < _nRows; x++)
        {
            for (var y = 0; y < _nColumns; y++)
            {
                var currentValue = _rows[x][y];

                if (!currentValue.HasInt())
                {
                    continue;
                }
                

                for (var xcord = x - 1; xcord <= x + 1; xcord++)
                {
                    for (var ycord = y - 1; ycord <= y + 1; ycord++)
                    {
                        try
                        {
                            if (xcord == x && ycord == y)
                            {
                                continue;
                            }

                            var checkedValue = _rows[xcord][ycord];
                            if (checkedValue.HasSymbol())
                            {
                                currentValue.Marked = true;
                            }

                        }
                        catch (ArgumentOutOfRangeException _)
                        {
                            
                        }
                    }
                }
            }
        }
    }

    public int SolvePartTwo()
    {
        return Multiples()
            .Sum();
    }

    private List<int> Multiples()
    {
        var output = new List<int>();
        for (var x = 0; x < _nRows; x++)
        {
            var y = 0;
            while (y < _nColumns)
            {
                var current = _rows[x][y];
                
                var s = "";
                var ycoords = new List<Container>();
                while (y < _nColumns && !_rows[x][y].HasInt())
                {
                    y++;
                }
                while (y < _nColumns && _rows[x][y].HasInt())
                {
                    current = _rows[x][y];
                    s += current.Value;
                    ycoords.Add(current);
                    y++;
                }

                if (string.IsNullOrEmpty(s))
                {
                    continue;
                }
                var num = int.Parse(s);
                Console.WriteLine(num);
                var guid = Guid.NewGuid();
                foreach (var ycoord in ycoords)
                {
                    ycoord.Num = num;
                    ycoord.Id = guid;

                }
                y++;
            }
        }

        var dict = new Dictionary<Guid, int>();
        foreach (var row in _rows)
        {
            foreach (var container in row)
            {
                if (container.HasInt())
                {
                    dict[container.Id] = container.Num;
                }
            }
        }
        

        for (var x = 0; x < _nRows; x++)
        {
            for (var y = 0; y < _nColumns; y++)
            {
                var current = _rows[x][y];
                if (current.Star)
                {
                    var uniqueMatches = new HashSet<Guid>();
                    for (var xcord = x - 1; xcord <= x + 1; xcord++)
                    {
                        for (var ycord = y - 1; ycord <= y + 1; ycord++)
                        {
                            try
                            {
                                if (xcord == x && ycord == y)
                                {
                                    continue;
                                }

                                var checkedValue = _rows[xcord][ycord];
                                if (checkedValue.HasInt())
                                {
                                    uniqueMatches.Add(checkedValue.Id);
                                }

                            }
                            catch (ArgumentOutOfRangeException _)
                            {
                            
                            }
                        }
                    }

                    
                    
                    if (uniqueMatches.Count == 2)
                    {
                        var multiple = uniqueMatches.Select(x => dict[x])
                            .Aggregate(1, (a, b) => a * b);
                        output.Add(multiple);
                    }
                }
            }
        }
        
        return output;
    }
}