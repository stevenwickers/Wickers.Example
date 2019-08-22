using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Wickers.DOTNET.Example.Tests
{
    public class BaseFixture
    {
        public BaseFixture()
        {
            var services = new ServiceCollection();
            services.AddTransient<IServiceCollection, ServiceCollection>();

            //Logging
            services.AddLogging(configureLog => configureLog
                .AddDebug()
                .AddConsole()
                .AddEventSourceLogger());

        }
    }
}
