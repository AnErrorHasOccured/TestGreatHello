using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGreatHello.IoC
{
    public class Container
    {
        private static IHost CreateHostBuilder()
                => Host
                     .CreateDefaultBuilder()
                     .ConfigureServices(
                        (_, services) =>
                            services
                            .AddSingleton<IGreetHello, Greet>()
                            .AddSingleton<IHandler>(x =>
                            {
                                var nullHandler = new NullHandler();
                                var oneName = new OneNameHandler();
                                var oneNameUpper = new OneNameUpperHandler();
                                var twoNames = new TwoNamesHandler();
                                var moreNames = new MoreNameHandler();
                                var moreNamesWithUpper = new MoreNameWithUpperHandler();

                                nullHandler
                                .SetNext(oneName)
                                .SetNext(oneNameUpper)
                                .SetNext(twoNames)
                                .SetNext(moreNames)
                                .SetNext(moreNamesWithUpper);

                                return nullHandler;
                            }))
                        .Build();
        public static T GetService<T>() => CreateHostBuilder().Services.GetService<T>();
    }
}
