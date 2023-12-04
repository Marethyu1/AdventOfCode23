using System.Diagnostics;
using System.Text;
using AdventOfCode.DayTwo;

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
}