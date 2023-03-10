using VoidAggregator.Dal.Db;
using VoidAggregator.Dal.Entities;
using VoidAggregator.Dal.Interfaces;

namespace VoidAggregator.Dal.Repositories
{
    public class ReleaseRepository : IReleaseRepository, IDisposable
    {
        private readonly VoidAggregatorContext _dbContext;

        public ReleaseRepository(VoidAggregatorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Release> Create(Release release)
        {
            var createdRelease = await _dbContext.Releases.AddAsync(release);
            return createdRelease.Entity;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
