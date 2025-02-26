using DAL.Entities;
using DAL.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly AppDbContext _context;

        public ApplicationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Application>> GetAllAsync()
        {
            return await _context.Applications.ToListAsync();
        }

        public async Task<Application?> AddAsync(Application app)
        {
            _context.Applications.Add(app);
            await _context.SaveChangesAsync();
            return app;
        }
    }
}
