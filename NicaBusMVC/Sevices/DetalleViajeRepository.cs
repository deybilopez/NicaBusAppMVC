using Microsoft.EntityFrameworkCore;
using NicaBusMVC.Data;
using NicaBusMVC.Models;

namespace NicaBusMVC.Sevices
{
    public class DetalleViajeRepository : GenericRepository<DetallesViaje>, IDetalleViajeRepository
    {
        private readonly NicaBusMVCContext _context;
        public DetalleViajeRepository(NicaBusMVCContext context) : base(context)
        {
            _context = context;
        }
        public override async Task<IEnumerable<DetallesViaje>> GetAllAsync()
        {
            return await _context.DetallesViaje.ToListAsync();

        }

        public virtual async Task<DetallesViaje> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(m => m.Id == id);
        }

    }
}
