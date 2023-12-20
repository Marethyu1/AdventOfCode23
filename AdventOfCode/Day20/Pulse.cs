namespace AdventOfCode.Day20;

public enum Pulse
{
    High,
    Low,
    NoSignal
}

public static class PulseExtensions
{
    public static Pulse Toggle(this Pulse pulse)
    {
        return pulse == Pulse.High ? Pulse.Low : Pulse.High;
    }
}