using System.Linq;

namespace TestGreatHello.Chain
{
    public class TwoNamesHandler : AbstractHandler
    {
        public override string Handler(params string[] input)
        {
            if (input.Length == 2)
                return $"Hello, {input.First()} and {input.ElementAt(1)}.";

            return base.Handler(input);
        }
    }
}
