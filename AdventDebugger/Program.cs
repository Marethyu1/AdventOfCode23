// See https://aka.ms/new-console-template for more information

using AdventOfCode.Day10;
using AdventOfCode.Day11;
using AdventOfCode.DayNine;

// var solution  = SeedSolutionPart2.Parse(File.ReadAllText("input.txt"), null);
var solutionPart1 = new GalaxySolution("input.txt");
var solution = new GalaxySolutionPart2("input.txt");

Console.WriteLine(solutionPart1.Solve());
Console.WriteLine(solution.Solve());