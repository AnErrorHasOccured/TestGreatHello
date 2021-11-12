using System.Linq;
using TestGreatHello.Utility;

namespace TestGreatHello.Chain
{
    public class MoreNameWithUpperHandler : AbstractHandler
    {
        public override string Handler(params string[] input)
        {
            if (input.Length > 2 && input.Any(x => x.IsUpper()))
            {
                var namesUpp = input.Where(x => x.IsUpper()).ToList();
                var namesDown = input.Except(namesUpp).ToList();
                //var result = base.Handler(namesDown);
                var result = string.Concat("Hello, ", string.Join(", ", namesDown.Where(x => x != namesDown.Last())), " and ", namesDown.Last(), ".");
                return string.Concat(result, " AND HELLO ", string.Join(", ", namesUpp.Select(x => x)), "!");
            }
            return base.Handler(input);
        }
    }
}
