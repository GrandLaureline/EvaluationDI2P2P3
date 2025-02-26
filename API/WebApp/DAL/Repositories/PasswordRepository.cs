using DAL.Entities;
using DAL.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PasswordRepository : IPasswordRepository
    {
        private readonly AppDbContext _context;

        public PasswordRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Password>> GetAllAsync()
        {
            return await _context.Passwords.Include(p => p.Application).ToListAsync();
        }

        public async Task<Password?> GetByIdAsync(int id)
        {
            return await _context.Passwords.Include(p => p.Application).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Password?> AddAsync(Password password)
        {
            _context.Passwords.Add(password);
            await _context.SaveChangesAsync();
            return password;
        }

        public async Task DeleteAsync(int id)
        {
            var password = await _context.Passwords.FindAsync(id);
            if (password != null)
            {
                _context.Passwords.Remove(password);
                await _context.SaveChangesAsync();
            }
        }
    }
}
