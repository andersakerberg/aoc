namespace AoC.Helpers
{
    public  static class ReadInput
    {
        public  static string[] GetFile(string day)
        {
            string path = Path.Combine(Environment.CurrentDirectory, $@"Days\{day}\", "input.txt");

            var allLines = File.ReadAllLines(path);
            return allLines;
        }
    }
}
