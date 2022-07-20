using FinalProject.Interfaces;

namespace FinalProject.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Commit()
        {
            throw new NotImplementedException();
        }

        public Task<int> CommitAsync()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
