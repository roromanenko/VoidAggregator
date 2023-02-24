using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using VoidAggregator.Dal;
using VoidAggregator.Dal.Db;

namespace VoidAggregator.Bl
{
	public static class ServiceCollectionExtension
	{
		public static void AddServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDb(configuration);
		}

		public static void TryAddDb(this IServiceScope serviceScope)
		{
			var context = serviceScope.ServiceProvider.GetRequiredService<VoidAggregatorContext>();

			DbInitializer.Initialize(context);
		}
	}
}
