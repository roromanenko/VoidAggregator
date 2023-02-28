using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Identity.Client;
using VoidAggregator.Bl.Infrastructure;
using VoidAggregator.Bl.Interfaces;
using VoidAggregator.Bl.Services;
using VoidAggregator.Dal;
using VoidAggregator.Dal.Db;
using VoidAggregator.Dal.Entities.Users;
using VoidAggregator.Dal.Interfaces;
using VoidAggregator.Dal.Repositories;

namespace VoidAggregator.Bl
{
	public static class ServiceCollectionExtension
	{
		public static void AddServices(this IServiceCollection services,
			IConfiguration configuration)
		{
			AddDbContext(services, configuration);

			services.AddScoped<IReleaseService, ReleaseService>();
			services.AddScoped<IBlobStorage, LocalFileBlobStorage>();
			services.AddScoped<IReleaseRepository, ReleaseRepository>();
			services.AddScoped<DbFacade>();
		}

		public static void TryAddDb(this IServiceScope serviceScope)
		{
			var context = serviceScope.ServiceProvider.GetRequiredService<VoidAggregatorContext>();

			DbInitializer.Initialize(context);
		}

		private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<VoidAggregatorContext>(options =>
			{
				options.UseSqlServer(configuration.GetConnectionString("DbConnectionString"));
			});

			services.AddIdentityCore<ApplicationUser>(opt =>
			{
				opt.User.RequireUniqueEmail = true;
			})
				.AddEntityFrameworkStores<VoidAggregatorContext>();
		}
	}
}
