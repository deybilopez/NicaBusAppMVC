using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NicaBusMVC.Data;
using NicaBusMVC.Models;

namespace NicaBusMVC.Sevices
{
    public class RutaRepository : GenericRepository<Ruta>, IRutaRepository
    {
        private readonly NicaBusMVCContext _context;
        public RutaRepository(NicaBusMVCContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<Ruta>> GetAllAsync()
        {
            return await _context.Ruta.ToListAsync();

        }
        public virtual async Task<Ruta> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }
    }
}
