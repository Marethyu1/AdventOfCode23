namespace AdventOfCode;

public interface ISolution<out T>
{
    public T Solve();
}