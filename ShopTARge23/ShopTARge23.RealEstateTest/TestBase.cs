

using Microsoft.Extensions.DependencyInjection;
using System.Security.Authentication.ExtendedProtection;

namespace ShopTARge23.RealEstateTest
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



        protected T Svc<T>()
        {
            return serviceProvider.GetService<T>();
        }

        public virtual void SetupServices(IServiceCollection services)
        {
            services.AddScoped<IRealEstateServices, RealEstateServices>();

            services.AddDbContext<ShopTARge23Context>(x =>
            {
                x.UseInMemoryDatabase("TEST");
                x.ConfigureWarnings(e => e.Ignore(InMemoryEventId.TransactionIgnoredWarning));
            });

            RegisterMacros(services);
        }
    }
}
