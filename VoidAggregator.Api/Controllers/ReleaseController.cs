using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoidAggregator.Api.Models;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Bl.Interfaces;

namespace VoidAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReleaseController : ControllerBase
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
        public async Task<Release> CreateRelease([FromBody] Release release)
        {
            var releaseDto = _mapper.Map<ReleaseDto>(release);

            var resultDto = await _releaseService.CreateRelease(releaseDto);

            var result = _mapper.Map<Release>(resultDto);

            return result;
        }
    }
}
