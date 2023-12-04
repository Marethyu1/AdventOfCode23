namespace AdventOfCode.DayThree;

public static class GridParser
{
    public static Grid ParseLines(string lines)
    {
        var grid = new List<List<Container>>();
        
        foreach (var line in lines.Split("\r\n").Where(x => x.Length > 2))
        {
            var row = line.Select(x => new Container()
            {
                Value = x
            });
            
            grid.Add(row.ToList());
        }

        return new Grid(grid);
    }
}