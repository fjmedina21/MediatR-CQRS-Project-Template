using Microsoft.Extensions.DependencyInjection;
using MyAppApi.Application.Notifications;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using MyAppApi.Infrastructure;

namespace MyAppApi.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddMediatR(cfg =>
			{
				cfg.LicenseKey = configuration.GetValue<string>("LuckyPennySoftwareLicenseKey");
				cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
			});
			services.AddAutoMapper(cfg =>
			{
				cfg.LicenseKey = configuration.GetValue<string>("LuckyPennySoftwareLicenseKey");
				cfg.AddProfile<AutoMappingProfiles>();
			});

			services.AddScoped<NotificationsService>();

			services.AddInfrastructure(configuration);

			return services;
		}
	}
}
