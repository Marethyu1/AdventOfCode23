namespace AdventOfCode.Day21;

public class StepSolution: ISolution<long>
{

    private readonly Garden _garden;
    
    public StepSolution(string filePath)
    {
        var lines = File.ReadAllLines(filePath);

        var plots = lines.Select(line => line.Select(c => new Plot(c)).ToArray())
            .ToArray();
        _garden = new Garden(plots);
    }
    
    public long Solve()
    {
        Console.WriteLine(_garden);
        for (int i = 0; i < 64; i++)
        {
            
            _garden.Walk();
            // Console.WriteLine($"----{i+1}-----");
            // Console.WriteLine(_garden);
        }

        Console.WriteLine(_garden.Queue.Count);
        return 1;
    }
}