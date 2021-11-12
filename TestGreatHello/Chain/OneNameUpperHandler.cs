using System.Linq;
using TestGreatHello.Utility;

namespace TestGreatHello.Chain
{
    public class OneNameUpperHandler : AbstractHandler
    {
        public override string Handler(params string[] input)
        {
            if (input.Length == 1 && input.First().IsUpper())
                return $"HELLO {input.First()}!";
            return base.Handler(input);
        }
    }
}
