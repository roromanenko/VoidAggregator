using Microsoft.AspNetCore.Identity;
using System.Security.Cryptography.X509Certificates;
using VoidAggregator.Dal.Entities.Users;
using VoidAggregator.Dal.Interfaces;

namespace VoidAggregator.Dal.Db
{
	public class DbInitializer
	{
		public static void Initialize(VoidAggregatorContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			context.Database.EnsureCreated();

			var isInit = userManager.FindByNameAsync("zerom2016romanenko@gmail.com").Result is not null;

			if(isInit)
			{
				return;
			}

			roleManager.CreateAsync(new IdentityRole { Name = Roles.Author, NormalizedName = Roles.Author }).Wait();
			roleManager.CreateAsync(new IdentityRole { Name = Roles.Label, NormalizedName = Roles.Label }).Wait();

			var user = new ApplicationUser
			{
				Email = "zerom2016romanenko@gmail.com",
				UserName = "zerom2016romanenko@gmail.com",
				Title = "Creator",
				Country = "Ukraine"
			};

			userManager.CreateAsync(user, "Password1!").Wait();
			user = userManager.FindByEmailAsync("zerom2016romanenko@gmail.com").Result;
			userManager.AddToRoleAsync(user, Roles.Author);
			userManager.AddToRoleAsync(user, Roles.Label);

			context.SaveChanges();
		}
	}
}
