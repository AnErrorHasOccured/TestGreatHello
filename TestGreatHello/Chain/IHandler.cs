namespace TestGreatHello.Chain
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);
        string Handler(params string[] input);
    }
}
