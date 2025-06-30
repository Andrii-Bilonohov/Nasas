using Microsoft.EntityFrameworkCore;
using Nasas.Domain.Abstraction.Interfaces.Repositories;
using Nasas.Domain.Models;
using Nasas.Infrastructure.Data;

namespace Nasas.Infrastructure.Repositories
{
    public class PlanetRepository : IPlanetRepository
    {
        private readonly NasasDbContext _context;


        public PlanetRepository(NasasDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public async Task<Planet> AddAsync(Planet planet, CancellationToken cancellationToken)
        {
            _context.Planets.Add(planet);
            await _context.SaveChangesAsync(cancellationToken);
            return planet;
        }


        public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken)
        {
            var planet = await _context.Planets.FindAsync(new object[] { id }, cancellationToken);
            if (planet == null)
            {
                return false;
            }

            _context.Planets.Remove(planet);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }


        public async Task<IEnumerable<Planet>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _context.Planets.ToListAsync(cancellationToken);
        }


        public async Task<Planet> UpdateAsync(Planet planet, CancellationToken cancellationToken)
        {
            _context.Planets.Update(planet);
            await _context.SaveChangesAsync(cancellationToken);
            return planet;
        }
    }
}
