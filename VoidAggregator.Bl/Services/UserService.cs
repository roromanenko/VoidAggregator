using AutoMapper;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Bl.Interfaces;
using VoidAggregator.Dal.Entities.Users;
using VoidAggregator.Dal.Exceptions;
using VoidAggregator.Dal.Interfaces;

namespace VoidAggregator.Bl.Services
{
	public class UserService : IUserService
	{
		private readonly IUserManager _userManager;
		private readonly IMapper _mapper;

		public UserService(IUserManager userManager, IMapper mapper)
		{
			_userManager = userManager;
			_mapper = mapper;
		}

		public async Task<UserDto> SignIn(string login, string password)
		{
			bool isAuthenticate = await _userManager.CheckIsAuthenticate(login, password);

			if(isAuthenticate)
			{
				var user = await _userManager.GetUserByLogin(login);
				var result = _mapper.Map<UserDto>(user);
				result.Roles = await _userManager.GetUserRoles(user);
				return result;
			}

			throw new AppException(AppException.IncorrectLogin);
		}

		public async Task<AuthorDto> SignUpAuthor(AuthorDto author, string password)
		{
			var newAuthor = _mapper.Map<Author>(author);

			newAuthor = await _userManager.CreateAuthor(newAuthor, password);

			var result = _mapper.Map<AuthorDto>(newAuthor);
			result.Roles = await _userManager.GetUserRoles(newAuthor);
			return result;
		}

		public async Task<LabelDto> SignUpLabel(LabelDto label, string password)
		{
			var newLabel = _mapper.Map<Label>(label);

			newLabel = await _userManager.CreateLabel(newLabel, password);

			var result = _mapper.Map<LabelDto>(newLabel);
			result.Roles = await _userManager.GetUserRoles(newLabel);
			return result;
		}
	}
}
