using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopTARge23.Core.ServiceInterface;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.KindergartenTests.Mock;
using ShopTARge23.KindergartenTests.Macros;
using ShopTARge23.ApplicationServices.Services;
using ShopTARge23.Core.ServiceInterface;
using static System.Runtime.InteropServices.JavaScript.JSType;



namespace ShopTARge23.KindergartenTests
{
    public abstract class TestBase
    {
        protected IServiceProvider serviceProvider { get; set; }
        protected TestBase()
        {
            var services = new ServiceCollection();
            SetupServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        public void Dispose()
        {

        }

        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IKindergartensServices, KindergartensServices>();
            services.AddScoped<IFileServices, FileServices>();
            services.AddScoped<IHostEnvironment, MockIHostEnvironment>();

            services.AddDbContext<Data.ShopTARge23Context>(x =>
            {
                x.UseInMemoryDatabase("Test");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }

        private void RegisterMacros(IServiceCollection services)
        {
            var macroBaseType = typeof(IMacros);

            var macros = macroBaseType.Assembly.GetTypes().Where(x => macroBaseType.IsAssignableFrom(x) && !x.IsInterface
            && !x.IsAbstract);

            foreach (var macro in macros)
            {
                services.AddSingleton(macro);
            }
        }
    }
}
