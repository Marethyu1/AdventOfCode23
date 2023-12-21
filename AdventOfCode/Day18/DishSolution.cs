using System.Diagnostics;
using AdventOfCode.Shared;

namespace AdventOfCode.Day18;

public class DishSolution: ISolution<long>
{
    private Mountain _mountain;
    
    public DishSolution(string filePath)
    {
        var cells = File.ReadAllLines(filePath)
            .Select(line => line.Select(c => new Cell(c)).ToArray())
            .ToArray();

        _mountain = new Mountain(cells);
    }
    
    public long Solve()
    {
        Console.WriteLine(_mountain);

        _mountain.Tilt(Direction.Up);
        
        Console.WriteLine("----");
        Console.WriteLine(_mountain);
        Console.WriteLine(_mountain.Load());
        return 1;
        
    }

    public long SolvePart2()
    {
        var x = new Stopwatch();
        x.Start();


        Console.WriteLine((1000000000 - 190) % 14);
        // 0.......9...(7)...16 ...........1000000000
        // 0......190  (14) ..204......1000000000

        var set = new HashSet<string>();
        bool hasCycle = false;
        string match = "";
        for (var i = 0; i < 190 + 12; i++)
        {
            
            if (i % 10000 == 0)
            {
                x.Stop();
                Console.WriteLine(i);
                Console.WriteLine(x.ElapsedMilliseconds / 1000);
                x = new Stopwatch();
                x.Start();
                // Console.WriteLine(_mountain);
            }
            _mountain.Tilt(Direction.Up);
            _mountain.Tilt(Direction.Left);
            _mountain.Tilt(Direction.Down);
            _mountain.Tilt(Direction.Right);
            // Console.WriteLine("-----------");
            // Console.WriteLine(_mountain);
            
            if (set.Contains(_mountain.ToString()))
            {
                if (hasCycle)
                {
                    if (match == _mountain.ToString())
                    {
                        Console.WriteLine(i);
                        throw new Exception("uhoh");
                    }
                    
                }
                else
                {
                    hasCycle = true;
                    match = _mountain.ToString();
                    Console.WriteLine($"Match {i}");
                }
                
                
            }
            else
            {
                set.Add(_mountain.ToString());
            }
            
        }
        
        // Console.WriteLine(_mountain);
        Console.WriteLine(_mountain.Load());
        return _mountain.Load();
    }
}