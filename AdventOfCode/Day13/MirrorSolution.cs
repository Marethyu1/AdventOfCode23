namespace AdventOfCode.Day13;

public class MirrorSolution: ISolution<long>
{

    private readonly List<MirrorGrid> _grids;
    
    public MirrorSolution(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        _grids = Parse(lines);
    }
    
    public long Solve()
    {
        foreach (var mirrorGrid in _grids)
        {
            GridAnalyser.AnalyseRows(mirrorGrid);
        }

        return 1;
    }

    private static List<MirrorGrid> Parse(string[] lines)
    {
        var grids = new List<MirrorGrid>();
        var gridLines = new List<string>();
        foreach (var line in lines)
        {
            if (line.Length <= 2)
            {
                grids.Add(MirrorGrid.Parse(gridLines));
                gridLines = new List<string>();
            }
            else
            {
                gridLines.Add(line);
            }
        }
        grids.Add(MirrorGrid.Parse(gridLines));
        return grids;
    }
}