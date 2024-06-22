using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class EmpleadoConfig : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.HasKey(e => e.idEmpleado);
            builder.ToTable("Empleado");
            builder.Property(e => e.idEmpleado).HasColumnName("idEmpleado");

            builder.Property(e => e.nombre).HasColumnName("nombre");
            builder.Property(e => e.cedula).HasColumnName("cedula");
            builder.Property(e => e.estado).HasColumnName("estado");
            builder.Property(e => e.horaEntrada).HasColumnName("horaEntrada");
            builder.Property(e => e.horaSalida).HasColumnName("horaSalida");
            builder.Property(e => e.idTipoEmpleado).HasColumnName("idTipoEmpleado");

            builder.HasOne(e => e.IdTipoEmpledoNavigation)
           .WithMany(e => e.Empleado)
           .HasForeignKey(e => e.idTipoEmpleado)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("Empleado_TipoEmpledo_fk");
        }
    }
}
