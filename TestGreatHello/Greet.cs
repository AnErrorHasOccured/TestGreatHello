using System.Linq;
using TestGreatHello.Chain;

namespace TestGreatHello
{
    public class Greet : IGreetHello
    {
        private readonly IHandler _handler;

        public Greet(IHandler handler)
        {
            _handler = handler;
        }
       
        public string GreetHello(params string[] names)
        {
            names = NormalizeNames(names);
            return _handler.Handler(names);
        }

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

    }
}