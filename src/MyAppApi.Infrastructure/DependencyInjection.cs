using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyAppApi.Infrastructure.Data;

namespace MyAppApi.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MyAppContext>(options => options.UseInMemoryDatabase("TodoDb"));
            // services.AddDbContext<MyAppContext>(opt => opt.UseSqlServer(configuration.GetConnectionString(configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException())));

            services.AddSignalR();

            // services.AddTransient<ISomeService, SomeService>();
             // services.AddSingleton()<ISomeService, SomeService>();
            // services.AddScoped<ISomeService, SomeService>();

            return services;
        }
    }
}