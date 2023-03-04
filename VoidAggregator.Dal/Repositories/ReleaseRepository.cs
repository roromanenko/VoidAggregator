using Microsoft.EntityFrameworkCore;
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

		public Task<List<Release>> GetReleases(string userId)
		{
			return _dbContext.Releases.Where(r => r.AuthorId == userId)
				.Include(r => r.Author)
				.Include(r => r.Songs)
				.ThenInclude(s => s.AuthorsSongs)
				.ToListAsync();
		}
	}
}
