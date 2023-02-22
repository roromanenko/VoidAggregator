using VoidAggregator.Bl.Dtos;

namespace VoidAggregator.Bl.Interfaces
{
    public interface IReleaseService
    {
        Task<ReleaseDto> CreateRelease(ReleaseDto releaseDto);
    }
}
