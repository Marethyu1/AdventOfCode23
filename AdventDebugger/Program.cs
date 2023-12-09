// See https://aka.ms/new-console-template for more information

using AdventOfCode;
using AdventOfCode.DayEight;
using AdventOfCode.DayFive;

// var solution  = SeedSolutionPart2.Parse(File.ReadAllText("input.txt"), null);
ISolution<int> solution = new WastelandSolution("input.txt");

solution.Solve();