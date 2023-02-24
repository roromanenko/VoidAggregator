using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VoidAggregator.Dal.Db;

namespace VoidAggregator.Dal
{
	public static class ServiceCollectionExtension
	{
		public static void AddDb(this IServiceCollection services,
			IConfiguration configuration)
		{
			services.AddDbContext<VoidAggregatorContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
			});
		}
	}
}
