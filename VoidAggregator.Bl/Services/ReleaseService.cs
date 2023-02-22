using AutoMapper;
using VoidAggregator.Bl.Dtos;
using VoidAggregator.Bl.Interfaces;
using VoidAggregator.Dal.Entities;
using VoidAggregator.Dal.Interfaces;

namespace VoidAggregator.Bl.Services
{
    public class ReleaseService : IReleaseService
    {
        private readonly IMapper _mapper;
        private readonly IReleaseRepository _realeaseRepository;
        private readonly IBlobStorage _blobStorage;

        public ReleaseService(IMapper mapper, IReleaseRepository realeaseRepository, IBlobStorage blobStorage)
        {
            _mapper = mapper;
            _realeaseRepository = realeaseRepository;
            _blobStorage = blobStorage;
        }

        public async Task<ReleaseDto> CreateRelease(ReleaseDto releaseDto)
        {
            var release = _mapper.Map<Release>(releaseDto);
            release.CoverImagePath = await _blobStorage.AddItem(releaseDto.CoverImage);

            for(int i = 0; i<releaseDto.Songs.Count; i++)  
            {
                release.Songs[i].SongContentPath = await _blobStorage.AddItem(releaseDto.Songs[i].SongContent);
            }
            var result = await _realeaseRepository.CreateRelease(release);
            return _mapper.Map<ReleaseDto>(result);
        }
    }
}
