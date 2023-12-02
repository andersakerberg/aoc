using AoC.Interfaces;

namespace AoC
{
    public record DayPuzzleConfiguration(int Day, int Task);
    public class AdventOfCode(IEnumerable<IDayPuzzle> puzzles) : IMain
    {
        private readonly List<DayPuzzleConfiguration> _dayPuzzleConfigurations = new()
        {
            new(Day:1, 1),
            new(Day:2, 1),
        };

        public Task Execute()
        {
            Console.WriteLine("Welcome to Advent of Code 2023!");
            foreach (var item in puzzles.Select((value, i) => new { i, value }))
            {
                var puzzleConfiguration = _dayPuzzleConfigurations[item.i];
                var answer = item.value.Execute(puzzleConfiguration.Task);
                Console.WriteLine($"The answer for Day {puzzleConfiguration.Day} and Task {puzzleConfiguration.Task} was {answer}");
            }
           
            return Task.CompletedTask;
        }
    }
}
