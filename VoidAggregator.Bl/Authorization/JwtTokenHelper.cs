using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime;
using System.Security.Claims;
using System.Text;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Bl.Interfaces;
using VoidAggregator.Bl.Settings;

namespace VoidAggregator.Bl.Authorization
{
	public class JwtTokenHelper : ITokenHelper
	{
		private readonly TokenGenerationSetting _options;

		public JwtTokenHelper(IOptions<TokenGenerationSetting> options)
		{
			_options = options.Value;
		}

		public JwtSecurityToken GenerateToken(UserDto user)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));

			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.NameIdentifier, user.Id),
				new Claim(ClaimTypes.Email, user.Email)
			};
			claims.AddRange(user.Roles.Select(x => new Claim(ClaimTypes.Role, x)));

			var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddMinutes(_options.MinutesToExpiration),
			signingCredentials: credentials
			);

			return token;
		}
	}
}
