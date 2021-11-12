using System.Linq;

namespace TestGreatHello.Utility
{
    public static class StringExtensions
    {
        public static bool IsUpper(this string s) => s.All(char.IsUpper);
    }
}
