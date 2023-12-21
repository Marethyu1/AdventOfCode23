namespace AdventOfCode.Day20;

public class PulseSolution: ISolution<long>
{

    private PulseTracker _pulseTracker;

    public PulseSolution(string filePath)
    {
        var modules = File.ReadAllLines(filePath)
            .Select(ModuleFactory.ToModule);

        _pulseTracker = new PulseTracker(Pulse.Low, modules);
    }
    
    
    public long Solve()
    {
        for (var i = 0; i < 1000; i++)
        {
            _pulseTracker.PushButton();
        }


        Console.WriteLine($"{_pulseTracker.HighPulses} {_pulseTracker.LowPulses}");
        Console.WriteLine(_pulseTracker.HighPulses * _pulseTracker.LowPulses);
        return _pulseTracker.HighPulses * _pulseTracker.LowPulses;

        return 1;
    }

    public long SolvePart2()
    {
        long c = 0;
        _pulseTracker.SetEndState( (p) => p == Pulse.Low ? throw new Exception("wow") : Pulse.NoSignal);
        try
        {
            for (var i = 0; i < Int32.MaxValue; i++)
            {
                c++;
                _pulseTracker.PushButton();
                if (i % 100000 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine("DONE");
            Console.WriteLine(c);
        }
        

        return 1;
    }
}