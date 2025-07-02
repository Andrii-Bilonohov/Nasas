using Microsoft.EntityFrameworkCore;
using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Models;
using Nasas.Infrastructure.Data;

namespace Nasas.Infrastructure.Repositories
{
    public class ScientistRepository : IScientistRepository
    {
        private readonly NasasDbContext _context;


        public ScientistRepository(NasasDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Scientist> AddAsync(Scientist scientist, CancellationToken cancellationToken)
        {
            _context.Scientists.Add(scientist);
            await _context.SaveChangesAsync(cancellationToken);
            return scientist;
        }


        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var scientist = await _context.Scientists.FindAsync(new object[] { id }, cancellationToken);
            _context.Scientists.Remove(scientist);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
        

        public async Task<IEnumerable<Scientist>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Scientists.Include(s => s.Planets)
                .Include(s => s.FullName)
                .ToListAsync(cancellationToken);
        }


        public Task<Scientist?> GetScientistAsync(Scientist scientist, CancellationToken cancellationToken)
        {
            return _context.Scientists
                .Include(s => s.Planets)
                .Include(s => s.FullName)
                .FirstOrDefaultAsync(s => s.Id == scientist.Id, cancellationToken);
        }


        public async Task<Scientist> UpdateAsync(Scientist scientist, CancellationToken cancellationToken)
        {
            _context.Scientists.Update(scientist);
            await _context.SaveChangesAsync(cancellationToken);
            return scientist;
        }
    }
}
