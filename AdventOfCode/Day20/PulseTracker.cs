namespace AdventOfCode.Day20;

public class PulseTracker
{
    private readonly Pulse _currentPulse;
    private readonly IDictionary<string, IModule> _modules;
    public long LowPulses = 0;
    public long HighPulses = 0;
    private IModule _broadCastModule;
    private readonly Terminal _terminal;
    

    public PulseTracker(Pulse startingPulse, IEnumerable<IModule> modules)
    {
        _currentPulse = startingPulse;
        _modules = modules.ToDictionary((k => k.Key), v => v);
        _broadCastModule = _modules[ModuleFactory.BroadCast];
        
        foreach (var module in _modules.Values)
        {
            foreach (var outPutModuleKey in module.OutPutModules)
            {
                if (_modules.TryGetValue(outPutModuleKey, out var outPutModule))
                {
                    if (outPutModule is Conjunction conjunction)
                    {
                        conjunction.Link(module.Key);
                    }
                }
                else
                {
                    _terminal = new Terminal(outPutModuleKey);
                }
            }
        }

        _modules[_terminal.Key] = _terminal;
    }
    
    public void SetEndState(Func<Pulse, Pulse> func)
    {
        _terminal.CustomProcess = func;
    }

    public void PushButton()
    {
        var queue = new Queue<(IModule _broadCastModule, Pulse Low, string source)>();
        queue.Enqueue((_broadCastModule, Pulse.Low, "button"));
        var count = 0;
        while (queue.Any())
        {
            var (currentModule, currentPulse, source) = queue.Dequeue();
            
            if (currentPulse == Pulse.Low) LowPulses ++;
            if (currentPulse == Pulse.High) HighPulses ++;
            
            var nextPulse = currentModule.Process(source, currentPulse);
            if (nextPulse == Pulse.NoSignal) continue;
            
            foreach (var moduleKey in currentModule.OutPutModules)
            {
                queue.Enqueue((_modules[moduleKey], nextPulse, currentModule.Key));
            }
            count++;
        }
        
    }

    
    
}