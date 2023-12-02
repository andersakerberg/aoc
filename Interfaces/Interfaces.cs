namespace AoC.Interfaces
{
    public interface IDayPuzzle
    {
        int Execute(int task = 1);
    }
    public interface IMain
    {
        Task Execute();
    }
}
