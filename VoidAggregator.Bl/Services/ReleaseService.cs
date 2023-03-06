using AutoMapper;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Bl.Interfaces;
using VoidAggregator.Dal;
using VoidAggregator.Dal.Entities;
using VoidAggregator.Dal.Interfaces;

namespace VoidAggregator.Bl.Services
{
    public class ReleaseService : IReleaseService
    {
        private readonly IMapper _mapper;
        private readonly DbFacade _dbFacade;
        private readonly IBlobStorage _blobStorage;

        public ReleaseService(IMapper mapper, DbFacade dbFacade, IBlobStorage blobStorage)
        {
            _mapper = mapper;
            _dbFacade = dbFacade;
            _blobStorage = blobStorage;
        }

        public async Task<ReleaseDto> CreateRelease(ReleaseDto releaseDto)
        {
            var release = _mapper.Map<Release>(releaseDto);
            release.CoverImagePath = await _blobStorage.AddItem(releaseDto.CoverImage);

            for (int i = 0; i < releaseDto.Songs.Count; i++)
            {
                release.Songs[i].SongContentPath = await _blobStorage.AddItem(releaseDto.Songs[i].SongContent);
            }
            var result = await _dbFacade.ReleaseRepository.Create(release);
            await _dbFacade.SaveChangesAsync();
            return _mapper.Map<ReleaseDto>(result);
        }

		public async Task<List<ReleaseDto>> GetReleases(string userId)
		{
			var releases = await _dbFacade.ReleaseRepository.GetReleases(userId);

			return _mapper.Map<List<ReleaseDto>>(releases);
		}
	}
}
