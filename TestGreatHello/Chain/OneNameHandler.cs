using System.Linq;
using TestGreatHello.Utility;

namespace TestGreatHello.Chain
{
    public class OneNameHandler : AbstractHandler
    {
        public override string Handler(params string[] input)
        {
            if (input.Length == 1 && !input.First().IsUpper())
                return $"Hello, {input.First()}.";
            return base.Handler(input);
        }
    }
}
