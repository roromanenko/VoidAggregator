using VoidAggregator.Dal.Entities;

namespace VoidAggregator.Dal.Interfaces
{
	public interface IReleaseRepository
	{
		public Task<Release> Create(Release release);

	}
}
