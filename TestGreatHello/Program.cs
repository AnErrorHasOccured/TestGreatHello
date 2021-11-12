using System;
using TestGreatHello.IoC;

namespace TestGreatHello
{
    class Program
    {
        static void Main(string[] args)
        {
            var greet= Container.GetService<IGreetHello>();
            Console.WriteLine(greet.GreetHello(args));
        }
    }
}
