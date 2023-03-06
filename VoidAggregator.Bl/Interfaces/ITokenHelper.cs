using System.IdentityModel.Tokens.Jwt;
using VoidAggregator.Bl.Dtos;

namespace VoidAggregator.Bl.Interfaces
{
	public interface ITokenHelper
	{
		JwtSecurityToken GenerateToken(UserDto user);
	}
}
