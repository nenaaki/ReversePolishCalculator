namespace Calculator
{
    internal interface ICalculator
    {
        void Push(string formula);

        string DisplayStack();

        string Pop();

        string Clean();

        void Run();

        string[] GetAllCommand();
    }
}