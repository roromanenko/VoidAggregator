using VoidAggregator.Dal.Entities;

namespace VoidAggregator.Dal.Interfaces
{
	public interface IReleaseRepository
	{
		Task<Release> Create(Release release);
		Task<List<Release>> GetReleases(string userId);
	}
}
