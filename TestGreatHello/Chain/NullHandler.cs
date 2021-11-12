namespace TestGreatHello.Chain
{
    public class NullHandler : AbstractHandler
    {
        public override string Handler(params string[] input)
        {
            if (input == null)
                return "Hello, my friend.";
            return base.Handler(input);
        }
    }
}
