using System.Diagnostics;

namespace AdventOfCode.Day20;

public class FlipFlop: IModule
{
    public IEnumerable<string> OutPutModules { get; }
    public string Key { get; }

    private ModuleState _state = ModuleState.Off;
    
    public FlipFlop(string key, IEnumerable<string> outPutModules)
    {
        OutPutModules = outPutModules;
        Key = key;
    }

    public Pulse Process(string currentModuleKey, Pulse pulse)
    {
        if (pulse == Pulse.High)
        {
            return Pulse.NoSignal;
        }
        
        var previousState = _state;
        
        _state = _state.Toggle();
        Debug.Assert(previousState != _state);
        if (previousState == ModuleState.Off)
        {
            return Pulse.High;
        }
        return Pulse.Low;
    }

    public override string ToString()
    {
        return $"[FF]: {Key} -> {string.Join(",", OutPutModules)}";
    }
}