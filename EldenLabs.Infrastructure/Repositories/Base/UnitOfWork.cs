using EldenLabs.Domain.Repositories.Base;
using EldenLabs.Infrastructure.AppContext;

namespace EldenLabs.Domain.Repositories
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly AppDbContext _context;

        public IRepository<T> Repository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Repository = new Repository<T>(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
