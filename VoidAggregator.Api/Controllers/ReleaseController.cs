using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VoidAggregator.Api.Models;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Bl.Interfaces;
using VoidAggregator.Dal;

namespace VoidAggregator.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReleaseController : AppBaseController
	{
		private readonly IMapper _mapper;
		private readonly IReleaseService _releaseService;

		public ReleaseController(IMapper mapper, IReleaseService releaseService)
		{
			_mapper = mapper;
			_releaseService = releaseService;
		}

		[HttpPost]
		[Route("create")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
			Roles = $"{Roles.Author},{Roles.Label}")]
		public async Task<ActionResult<Release>> CreateRelease([FromBody] Release release)
		{
			var releaseDto = _mapper.Map<ReleaseDto>(release);

			var resultDto = await _releaseService.CreateRelease(releaseDto);

			var result = _mapper.Map<Release>(resultDto);

			return Ok(result);
		}

		[HttpGet]
		[Route("releases")]
		[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,
			Roles = $"{Roles.Author},{Roles.Label}")]
		public async Task<ActionResult<List<Release>>> GetReleases()
		{
			var releasesDto = await _releaseService.GetReleases(GetCurrentUserId());

			return Ok(_mapper.Map<List<Release>>(releasesDto));
		}
	}
}
