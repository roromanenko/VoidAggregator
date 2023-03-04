using VoidAggregator.Dal.Entities.Users;

namespace VoidAggregator.Dal.Interfaces
{
	public interface IUserManager
	{
		Task<bool> CheckIsAuthenticate(string login, string password);
		Task<Author> CreateAuthor(Author newAuthor, string password);
		Task<Label> CreateLabel(Label newLabel, string password);
		Task<ApplicationUser> GetUserByLogin(string login);
		Task<List<string>> GetUserRoles(ApplicationUser user);
	}
}
