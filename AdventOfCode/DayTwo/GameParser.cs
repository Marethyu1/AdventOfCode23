namespace AdventOfCode.DayTwo;

public static class GameParser
{
    public static List<Game> Parse(string input)
    {
        var games = input.Trim()
            .Split(Environment.NewLine)
            .Where(x => !string.IsNullOrEmpty(x) && !string.IsNullOrWhiteSpace(x))
            .Select(ParseLine);
        return games.ToList();
    }
    
    public static Game ParseLine(string input)
    {
        var splitInput = input.Split(":");
        var rawGame = splitInput[0];
        var rawTurnz = splitInput[1].Split(';');
        var rawGameNumber = rawGame.Split(' ')[1];
        
        var game = new Game(int.Parse(rawGameNumber));
        foreach (var rawTurn in rawTurnz)
        {
            var turn = new Turn();
            var combos = rawTurn.Split(",");
            foreach (var combo in combos)
            {
                var splitCombo = combo.Trim().Split(' ');
                var rawAmount = splitCombo[0];
                var colour = splitCombo[1];
                turn.AddCombo(colour, int.Parse(rawAmount));
            }

            game.AddTurn(turn);
        }
        return game;
    }
}