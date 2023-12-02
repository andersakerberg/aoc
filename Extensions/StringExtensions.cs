namespace AoC.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<int> AllIndexesOf(this string str, string searchString)
        {
            int minIndex = str.IndexOf(searchString, StringComparison.Ordinal);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchString, minIndex + searchString.Length, StringComparison.Ordinal);
            }
        }
    }
}
