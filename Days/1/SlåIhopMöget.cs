using AoC.Extensions;
using AoC.Helpers;
using AoC.Interfaces;

namespace AoC.Days._1
{
    public class SlåIhopMöget : IDayPuzzle
    {
       public int Execute(int task = 1)
        {
            var allLines = ReadInput.GetFile("1");
            var answer = 0;
            foreach (var row in allLines)
            {
                var (first, last) = GetFirstAndLast(row, task == 2);
                answer += int.Parse($"{first}{last}");
            }
            return answer;
        }

        public (int first,int last) GetFirstAndLast(string input,bool includeWords)
        {
            var keys = numberTable.Keys.ToList();
            var mapp = new List<StringAndIndex>();
            var values = numberTable.Values;
            foreach (var number in values)
            {
                var foundStringAtIndex = input.AllIndexesOf(number.ToString());
                foreach (var r in foundStringAtIndex)
                {
                    mapp.Add(new StringAndIndex() { Index = r, Value = number });
                }
            }

            if (includeWords)
            {
                foreach (var key in keys)
                {
                    var foundStringAtIndex = input.AllIndexesOf(key);
                    foreach (var r in foundStringAtIndex)
                    {
                        mapp.Add(new StringAndIndex() { Index = r, Value = numberTable[key] });
                    }
                }
            }

            var result = mapp.OrderBy(X => X.Index).Select(x=> x.Value).ToList();
            return (result.First(),result.Last());
        }

        public class StringAndIndex
        {
            public int Index { get; set; }
            public int Value { get; set; }
        }
        
        private static Dictionary<string, int> numberTable = new Dictionary<string, int>
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };
    }
}
