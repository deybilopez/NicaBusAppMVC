using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NicaBusApp.Models;

namespace NicaBusApp.Data
{
    public class NicaBusAppContext : DbContext
    {
        public NicaBusAppContext (DbContextOptions<NicaBusAppContext> options)
            : base(options)
        {
        }

        public DbSet<NicaBusApp.Models.DetallesViaje> DetallesViaje { get; set; } = default!;

        public DbSet<NicaBusApp.Models.Users> Users { get; set; }

        public DbSet<NicaBusApp.Models.Ruta> Ruta { get; set; }
    }
}
