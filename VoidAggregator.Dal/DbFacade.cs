using VoidAggregator.Dal.Db;
using VoidAggregator.Dal.Interfaces;

namespace VoidAggregator.Dal
{
    public class DbFacade : IDisposable
    {
        private readonly IReleaseRepository _releaseRepository;
        private readonly VoidAggregatorContext _dbContext;

        public DbFacade(IReleaseRepository releaseRepository, VoidAggregatorContext dbContext)
        {
            _releaseRepository = releaseRepository;
            _dbContext = dbContext;
        }
        public IReleaseRepository ReleaseRepository => _releaseRepository;
        public void SaveChanges() 
        {
            _dbContext.SaveChanges(); 
        }
        public Task SaveChangesAsync()
        {
            return _dbContext.SaveChangesAsync();
        } 
        public void Dispose()
        {
           _dbContext.Dispose();
        }
    }
}
