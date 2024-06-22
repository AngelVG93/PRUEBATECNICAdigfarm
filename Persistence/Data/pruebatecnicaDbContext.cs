using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Data
{
    public class pruebatecnicaDbContext(DbContextOptions<pruebatecnicaDbContext> options) : DbContext(options)
    {
        public virtual DbSet<Empleado> empleado { get; set; }
        public virtual DbSet<RegistroEmpleado> registroentrada { get; set; }
        public virtual DbSet<TipoEmpledo> tipoempledo { get; set; }
        public virtual DbSet<TipoNovedad> tiponovedad { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
