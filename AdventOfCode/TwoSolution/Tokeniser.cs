namespace AdventOfCode.TwoSolution;

public class Token
{
    public int Output { get; }
    public string Input { get; }
    
    public Token(string input, int output)
    {
        Input = input;
        Output = output;
    }
}


public class Tokeniser
{
    private readonly List<Token> _validTokens;
    
    public Tokeniser(List<Token> tokens)
    {
        _validTokens = tokens;
    }

    public List<int> Tokenise(string line)
    {

        var chars = line.ToCharArray();
        var tokens = new List<int>();

        for (var i = 0; i < chars.Length; i++)
        {
            
            foreach (var token in _validTokens)
            {
                var tokenLength = token.Input.Length;

                var remainingTokens = chars.Length - i;
                var hasEnoughRemainingCharacters = remainingTokens >= tokenLength;
                if (!hasEnoughRemainingCharacters)
                {
                    continue;
                }

                var characterArray = chars.Skip(i)
                    .Take(tokenLength).ToArray();

                var isValid = true;
                for (var index = 0; index < characterArray.Length; index++)
                {
                    var c = characterArray[index];
                    var d = token.Input[index];
                    if (c != d)
                    {
                        isValid = false;
                    }
                }

                if (!isValid)
                {
                    continue;
                }
                tokens.Add(token.Output);
                break;
            }
        }

        return tokens;
    }

    public static int ToDigit(List<int> tokens)
    {
        var leftDigit = tokens[0];
        var rightDigit = tokens[^1];
        return int.Parse($"{leftDigit}{rightDigit}");
    }
}