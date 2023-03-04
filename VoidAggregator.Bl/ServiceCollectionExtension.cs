using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;
using VoidAggregator.Bl.Authorization;
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

			services.AddScoped<ITokenHelper, JwtTokenHelper>();
			services.AddScoped(x => new JwtSecurityTokenHandler());
			services.AddScoped<IUserService, UserService>();
		}

		public static void TryAddDb(this IServiceScope serviceScope)
		{
			var context = serviceScope.ServiceProvider.GetRequiredService<VoidAggregatorContext>();
			var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
			var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

			DbInitializer.Initialize(context, userManager, roleManager);
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
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<VoidAggregatorContext>();
			services.AddScoped<IUserManager, UserManager>();
			services.AddScoped<IReleaseRepository, ReleaseRepository>();
			services.AddScoped<DbFacade>();
		}
	}
}
