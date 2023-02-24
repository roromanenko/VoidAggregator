using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoidAggregator.Dal;

namespace VoidAggregator.Bl
{
	public static class ServiceCollectionExtension
	{
		public static void AddServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDb(configuration);
		}
	}
}
