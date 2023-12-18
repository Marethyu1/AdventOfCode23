namespace AdventOfCode.Day16;

public interface ILavalQueue
{
    public bool Any();
    public void Add(Move move);

    public Move Next();
}

public class DfsQeue : ILavalQueue
{
    private Stack<Move> _stack = new();
    public bool Any()
    {
        return _stack.Any();
    }

    public void Add(Move move)
    {
        _stack.Push(move);
    }

    public Move Next()
    {
        return _stack.Pop();
    }
}

public class LavaQueue: ILavalQueue
{
    private readonly Queue<Move> _queue = new();
    
    public bool Any()
    {
        return _queue.Any();
    }

    public void Add(Move move)
    {
        _queue.Enqueue(move);
    }

    public Move Next()
    {
        return _queue.Dequeue();
    }
}