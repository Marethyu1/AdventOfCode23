// See https://aka.ms/new-console-template for more information

using AdventOfCode.DayNine;

// var solution  = SeedSolutionPart2.Parse(File.ReadAllText("input.txt"), null);
var solution = new MirageSolution("input.txt");

Console.WriteLine(solution.Solve());