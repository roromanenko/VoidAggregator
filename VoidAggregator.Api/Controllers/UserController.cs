using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using VoidAggregator.Api.Models;
using VoidAggregator.Api.Models.Authorization;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Bl.Interfaces;

namespace VoidAggregator.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : AppBaseController
	{
		private readonly IMapper _mapper;
		private readonly IUserService _userService;
		private readonly ITokenHelper _tokenHelper;
		private readonly JwtSecurityTokenHandler _tokenHandler;

		public UserController(IMapper mapper, IUserService userService, ITokenHelper tokenHelper, JwtSecurityTokenHandler tokenHandler)
		{
			_mapper = mapper;
			_userService = userService;
			_tokenHelper = tokenHelper;
			_tokenHandler = tokenHandler;
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("signup-author")]
		public async Task<ActionResult<SignResponse<Author>>> SignUpAuthor([FromBody] SignUpRequest<Author> request)
		{
			var authorDto = _mapper.Map<AuthorDto>(request.User);

			authorDto = await _userService.SignUpAuthor(authorDto, request.Password);
			var token = _tokenHelper.GenerateToken(authorDto);
			var response = new SignResponse<Author>
			{
				ExpiredAt = token.ValidTo,
				Token = _tokenHandler.WriteToken(token),
				User = _mapper.Map<Author>(authorDto)
			};

			return Ok(response);
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("signup-label")]
		public async Task<ActionResult<SignResponse<Label>>> SignUpLabel([FromBody] SignUpRequest<Label> request)
		{
			var labelDto = _mapper.Map<LabelDto>(request.User);

			labelDto = await _userService.SignUpLabel(labelDto, request.Password);
			var token = _tokenHelper.GenerateToken(labelDto);
			var response = new SignResponse<Label>
			{
				ExpiredAt = token.ValidTo,
				Token = _tokenHandler.WriteToken(token),
				User = _mapper.Map<Label>(labelDto)
			};

			return Ok(response);
		}

		[AllowAnonymous]
		[HttpPost]
		[Route("signIn")]
		public async Task<ActionResult<SignResponse<User>>> SignIn([FromBody] SignInRequest request)
		{
			var userDto = await _userService.SignIn(request.Login, request.Password);
			var token = _tokenHelper.GenerateToken(userDto);
			var response = new SignResponse<User>
			{
				ExpiredAt = token.ValidTo,
				Token = _tokenHandler.WriteToken(token),
				User = _mapper.Map<User>(userDto)
			};

			return Ok(response);
		}
	}
}
