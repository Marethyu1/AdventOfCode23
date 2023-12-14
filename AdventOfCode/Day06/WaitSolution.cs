namespace AdventOfCode.Day06;

public class WaitSolution: ISolution<int>
{
    public int Solve()
    {
        var x = new List<(long time, long distance)>()
        {
            // (54, 239),
            // (70, 1142),
            // (82, 1295),
            // (75, 1253)
            // (71530, 940200),
            (54708275, 239114212951253)
            // (7, 9),
            // (15, 40),
            // (30, 200),
        };
        var total = x.Select(x => Simulator.Simulate(x.time, x.distance))
            .Aggregate((long) 1, (a, b) => a * b);
        Console.WriteLine(total);
        return 1;
    }
}