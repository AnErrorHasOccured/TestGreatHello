using System.Linq;
using TestGreatHello.Utility;

namespace TestGreatHello
{
    public class Greet : IGreetHello
    {
        private static string[] NormalizeNames(string[] names)
        {
            if (names?.Any(_ => _.Contains("\"")) ?? false)
            {
                var escape2 = names?.Where(x => x.Contains("\"")).ToArray();
                var escapeClear = escape2?.Select(x => x.Replace("\"", string.Empty)).ToArray();

                return names.Except(escape2).Concat(escapeClear).ToArray();
            }

            if (names?.Any(_ => _.Contains(",")) ?? false) 
            {
                var comma2 = names?.Where(x => x.Contains(",")).ToArray();
                var split = comma2.SelectMany(x => x.Split(","));
                var splitClear = split.Select(_ => _.Replace(" ", string.Empty));

                return names.Except(comma2).Concat(splitClear).ToArray();
            }

            return names;
        }

        public string GreetHello(params string[] names)
        {
            names = NormalizeNames(names);

            if (names == null)
                return "Hello, my friend.";

            if (names.Length == 1)
                return names.First().IsUpper() ? $"HELLO {names.First()}!" : $"Hello, {names.First()}.";

            if (names.Length == 2)
                return $"Hello, {names.First()} and {names.ElementAt(1)}.";

            var namesUpp = names.Where(x => x.IsUpper()).ToList();
            var namesDown = names.Except(namesUpp).ToList();

            var result = string.Concat("Hello, ", string.Join(", ", namesDown.Where(x => x != namesDown.Last())), " and ", namesDown.Last(), ".");

            if (namesUpp.Any())
                return string.Concat(result, " AND HELLO ", string.Join(", ", namesUpp.Select(x => x)), "!");

            return result;
        }

    }
}