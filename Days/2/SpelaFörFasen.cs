using System.Text.RegularExpressions;
using AoC.Helpers;
using AoC.Interfaces;

namespace AoC.Days._2
{
    public class SpelaFörFasen : IDayPuzzle
    {
        public int Execute(int task)
        {
            return Solve(task);
        }
        public static int Solve(int task)
        {
            var allLines = ReadInput.GetFile("2");
            int allowedReds = 12, allowedGreens = 13, allowedBlues = 14;
            int sumOfValidGameIds = 0,totalPowerOfAll = 0;
            foreach (var line in allLines)
            {
                var gameNumber = GameNumber(line, out var drawResult);
                List<bool> validDraw = new List<bool>();
                int reds = 0, greens = 0, blues = 0;
                foreach (var info in drawResult)
                {
                    
                    if (info.Greens <= allowedGreens && info.Reds <= allowedReds && info.Blues <= allowedBlues)
                    {
                       validDraw.Add(true);
                    }
                    else
                    {
                        validDraw.Add(false);
                    }

                    if (reds < info.Reds)
                    {
                        reds = info.Reds;
                    }

                    if (greens < info.Greens)
                    {
                        greens = info.Greens;
                    }

                    if (blues < info.Blues)
                    {
                        blues = info.Blues;
                    }
                }

                var powerOfAll = reds * greens * blues;
                totalPowerOfAll += powerOfAll;
                if (validDraw.All(x => x == true))
                {
                    sumOfValidGameIds += gameNumber;
                }
            }
          
            switch (task)
            {
                case 1:
                    return sumOfValidGameIds;
                case 2:
                    return totalPowerOfAll;

                default:
                    throw new Exception($"Could not solve Day 2 Task {task}");
            }
        }
        private static int GameNumber(string line, out List<Draw> drawResult)
        {
            var gameInfo = line.Substring(0, line.IndexOf(':'));
            var gameNumber = int.Parse(gameInfo.Substring(gameInfo.IndexOf(' '), gameInfo.Length - gameInfo.IndexOf(' ')));
            var gamesFlat = line.Substring(line.LastIndexOf(':') + 1);
            var splitOnSemi = gamesFlat.Split(';');

            var result = new List<GameDrawInfo>();
            drawResult = new List<Draw>();

            foreach (var game in splitOnSemi)
            {
                var draws = game.Split(",");
                int reds = 0, greens = 0, blues = 0;

                foreach (var draw in draws)
                {
                    var count = int.Parse(Regex.Match(draw, @"\d+").Value);
                    var onlyLetters = new string(draw.Where(Char.IsLetter).ToArray());

                    switch (onlyLetters)
                    {
                        case "green":
                            greens += count;
                            break;
                        case "red":
                            reds += count;
                            break;
                        case "blue":
                            blues += count;
                            break;
                    }
                }

                drawResult.Add(new Draw(reds, blues, greens));
                result.Add(new GameDrawInfo(drawResult));
            }

            return gameNumber;
        }
    }
    
    public class Draw(int reds,int blues,int greens)
    {
       public int Reds { get; set; } = reds;
       public int Blues { get; set; } = blues;
       public int Greens { get; set; } = greens;
    }

    public class GameDrawInfo()
    {
        public List<Draw> Draws { get; set; } = new List<Draw>();
        public GameDrawInfo(List<Draw> result) : this()
        {
            this.Draws = result;
        }
    }
}   
