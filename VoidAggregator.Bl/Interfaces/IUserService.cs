using VoidAggregator.Bl.Dtos;

namespace VoidAggregator.Bl.Interfaces
{
	public interface IUserService
	{
		Task<UserDto> SignIn(string login, string password);
		Task<AuthorDto> SignUpAuthor(AuthorDto author, string password);
		Task<LabelDto> SignUpLabel(LabelDto label, string password);
	}
}
