namespace AdventOfCode.Day20;

public enum ModuleState
{
    On,
    Off
}

public static class ModuleStateExtensions
{
    public static ModuleState Toggle(this ModuleState moduleState)
    {
        return moduleState == ModuleState.On ? ModuleState.Off : ModuleState.On;
    }
}