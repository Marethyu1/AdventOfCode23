namespace AdventOfCode.Day06;

public static class Simulator
{
    public static long Simulate(long time, long distance)
    {
        Console.WriteLine($"{time},{distance}");
        var count = 0;
        for (var i = 1; i < time; i++)
        {
            var speed = i;
            var msRemaining = time - i;
            var y = msRemaining * speed;
            if (y > distance)
            {
                count++;
            }
            // Console.WriteLine($"\t{i},{y}");
        }
        Console.WriteLine(count);

        return count;
    }
}