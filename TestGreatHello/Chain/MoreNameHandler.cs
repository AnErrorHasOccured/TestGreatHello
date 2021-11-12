using System.Linq;
using TestGreatHello.Utility;

namespace TestGreatHello.Chain
{
    public class MoreNameHandler : AbstractHandler
    {
        public override string Handler(params string[] input)
        {
            if (input.Length > 2 && !input.Any(x=> x.IsUpper()))
            {
                var lastName = input.Last();
                var otherName = input.Where(x => x != input.Last()).ToArray();
                return string.Concat("Hello, ", string.Join(", ", otherName), " and ", lastName, ".");
            }
            return base.Handler(input);
        }
    }
}
