using System.Text;

namespace AdventOfCode.Day11;

public class Galaxy
{
    private readonly Location[][] _characters;

    public Galaxy(Location[][] characters)
    {
        _characters = characters;
    }

    public List<Coord> DetermineCoordsWithGalaxies()
    {
        var coords = new List<Coord>();
        for (int i = 0; i < _characters.Length; i++)
        {
            for (int j = 0; j < _characters[i].Length; j++)
            {
                if (!_characters[i][j].Empty)
                {
                    coords.Add(new Coord(i, j));
                }
            }
        }

        return coords;
    }

    public List<Pair> DeterminePairsOfGalaxies()
    {
        var pair = new List<Pair>();
        var galaxies = DetermineCoordsWithGalaxies();
        for (var i = 0; i < galaxies.Count; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                pair.Add(new Pair(galaxies[i], galaxies[j]));
            }
        }
        return pair;
    }

    public override string ToString()
    {
        var s = new StringBuilder();
        foreach (var locations in _characters)
        {
            var y = string.Join("", locations.Select(x => x.ToString()));
            s.AppendLine(y);
        }

        return s.ToString();

    }

    public Galaxy Expand(int amount)
    {
        var rowExpanded = ExpandRows(_characters, amount);
        var columnExpanded = ExpandColumns(rowExpanded, amount);
        return new Galaxy(columnExpanded);
    }

    private static Location[][] ExpandRows(Location[][] chars, int amount)
    {
        var output = new List<Location[]>();
        foreach (var c in chars)
        {
            if (c.All(x => x.Empty))
            {
                foreach (var location in c)
                {
                    location.Amount = amount;
                }
            }
            output.Add(c);
        }

        return output.ToArray();
    }

    private static Location[][] ExpandColumns(Location[][] chars, int amount)
    {
        var rows = chars.Transpose();
        var transposed = ExpandRows(rows, amount);
        return transposed.Transpose();
    }

    public static Galaxy ToGalaxy(string input)
    {
        var characterArrays = input.Split(Environment.NewLine)
            .Select(x => x.Trim())
            .Select(x => 
                x.Select(
                    c => new Location(c)
                    ).ToArray())
            .ToArray();

        return new Galaxy(characterArrays);
    }

    public static Galaxy ToBigBrainGalaxy(string input)
    {
        return ToGalaxy(input).Expand(1000000);
    }

    public long DetermineDistance(Pair pair)
    {
        var coord1 = pair.Item1;
        var coord2 = pair.Item2;

        long count = 0;
        var currentX = 0;
        
        var currentXValue = coord1.X;
        var currentYValue = coord1.Y;
        var xDirection = coord1.X < coord2.X ? 1 : -1;
        while (currentXValue != coord2.X)
        {
            count += _characters[currentXValue][currentYValue].Amount;
            currentXValue += xDirection;
        }
        
        var yDirection = coord1.Y < coord2.Y ? 1 : -1;
        
        while (currentYValue != coord2.Y)
        {
            count += _characters[currentXValue][currentYValue].Amount;
            currentYValue += yDirection;
        }

        return count;
    }
}

public static class ArrayExtensions
{
    public static T[][] Transpose<T>(this T[][] source)  
    {  
        if (source.Length == 0 || source[0].Length == 0)  
        {  
            return Array.Empty<T[]>();  
        }  
  
        var rows = source.Length;  
        var cols = source[0].Length;
  
        var result = new T[cols][];  
  
        for (var i = 0; i < cols; i++)  
        {  
            result[i] = new T[rows];  
  
            for (var j = 0; j < rows; j++)  
            {  
                result[i][j] = source[j][i];  
            }  
        }  
        return result;  
    }  
}