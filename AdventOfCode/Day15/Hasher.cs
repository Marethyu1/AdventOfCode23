namespace AdventOfCode.Day15;

public class Hasher: ISolution<int>
{
    private string[] _input;
    public Hasher(string fileName)
    {
        var input = File.ReadAllText(fileName);
        _input = input.Split(",");
    }
        
    
    public int Solve()
    {
        Console.WriteLine(_input);
        int output = 0;
        foreach (var hash in _input)
        {
            var current = 0;
            foreach (var c in hash)
            {
                current += (int) c;
                current = (current * 17) % 256;
            }

            Console.WriteLine(current);
            output += current;
        }

        Console.WriteLine(output);
        return 1;
    }
}