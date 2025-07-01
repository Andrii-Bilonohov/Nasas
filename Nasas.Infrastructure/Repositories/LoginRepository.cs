using Microsoft.EntityFrameworkCore;
using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Models;
using Nasas.Infrastructure.Data;

namespace Nasas.Infrastructure.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        private readonly NasasDbContext _context;


        public LoginRepository(NasasDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Login> AddAsync(Login login, CancellationToken cancellationToken)
        {
            _context.Logins.Add(login);
            await _context.SaveChangesAsync(cancellationToken);
            return login;
        }


        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var login = await _context.Logins.FindAsync(new object[] { id }, cancellationToken);
            
            _context.Logins.Remove(login);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }


        public async Task<IEnumerable<Login>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Logins.ToListAsync(cancellationToken);
        }


        public async Task<Login?> GetLoginAsync(string username, string password, CancellationToken cancellationToken)
        {
            return await _context.Logins
                .Include(l => l.User)
                .FirstOrDefaultAsync(l => l.UserName == username && l.Password == password, cancellationToken);
        }

        public async Task<bool> IsLoginExistsAsync(Login login, CancellationToken cancellationToken)
        {
            return await _context.Logins.AnyAsync(l => l.UserName == login.UserName || l.Email == login.Email, cancellationToken);
        }


        public async Task<Login> UpdateAsync(Login login, CancellationToken cancellationToken)
        {
            _context.Logins.Update(login);
            await _context.SaveChangesAsync(cancellationToken);
            return login;
        }
    }
}
