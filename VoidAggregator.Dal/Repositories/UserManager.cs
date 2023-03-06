using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VoidAggregator.Dal.Db;
using VoidAggregator.Dal.Entities.Users;
using VoidAggregator.Dal.Exceptions;
using VoidAggregator.Dal.Interfaces;

namespace VoidAggregator.Dal.Repositories
{
	public class UserManager : IUserManager
	{
		private readonly UserManager<ApplicationUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly VoidAggregatorContext _context;

		public UserManager(UserManager<ApplicationUser> userManager,
			RoleManager<IdentityRole> roleManager,
			VoidAggregatorContext context)
		{
			_userManager = userManager;
			_roleManager = roleManager;
			_context = context;
		}

		public async Task<bool> CheckIsAuthenticate(string login, string password)
		{
			var appUser = await _userManager.FindByNameAsync(login);

			if(appUser is not null)
			{
				return await _userManager.CheckPasswordAsync(appUser, password);
			}

			return false;
		}

		public async Task<Author> CreateAuthor(Author newAuthor, string password)
		{
			newAuthor.Id = Guid.NewGuid().ToString();
			newAuthor.UserName = newAuthor.Email;

			var result = await _userManager.CreateAsync(newAuthor, password);
			if(result.Succeeded)
			{
				newAuthor = await _context.Authors.FirstAsync(x => x.Id == newAuthor.Id);
				await _userManager.AddToRoleAsync(newAuthor, Roles.Author);

				return newAuthor;
			}

			throw new AppException(AppException.CannotCreateUser);
		}

		public async Task<Label> CreateLabel(Label newLabel, string password)
		{
			newLabel.Id = Guid.NewGuid().ToString();

			var result = _userManager.CreateAsync(newLabel, password);
			if(result.IsCompletedSuccessfully)
			{
				newLabel = await _context.Labels.FirstAsync(x => x.Id == newLabel.Id);
				await _userManager.AddToRoleAsync(newLabel, Roles.Label);

				return newLabel;
			}

			throw new AppException(AppException.CannotCreateUser);
		}

		public async Task<ApplicationUser> GetUserByLogin(string login)
		{
			var user = await _userManager.FindByNameAsync(login);
			if(user is null)
			{
				user = await _userManager.FindByEmailAsync(login);
			}

			return user;
		}

		public async Task<List<string>> GetUserRoles(ApplicationUser user)
		{
			return (await _userManager.GetRolesAsync(user)).ToList();
		}
	}
}
