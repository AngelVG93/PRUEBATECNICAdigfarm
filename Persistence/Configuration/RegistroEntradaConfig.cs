using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    public class RegistroEntradaConfig : IEntityTypeConfiguration<RegistroEntrada>
    {
        public void Configure(EntityTypeBuilder<RegistroEntrada> builder)
        {
            builder.HasKey(e => e.idRegistroEntrada);
            builder.ToTable("RegistroEntrada");
            builder.Property(e => e.idRegistroEntrada).HasColumnName("idRegistroEntrada");

            builder.Property(e => e.idTipoNovedad).HasColumnName("idTipoNovedad");
            builder.Property(e => e.idEmpleado).HasColumnName("idEmpleado");
            builder.Property(e => e.horaEntrada).HasColumnName("horaEntrada");
            builder.Property(e => e.horaSalida).HasColumnName("horaSalida");
            builder.Property(e => e.fechaNovedad).HasColumnName("fechaNovedad");
            builder.Property(e => e.horas).HasColumnName("horas");
            builder.Property(e => e.descripcion).HasColumnName("descripcion");

            builder.HasOne(e => e.idTipoNovedadNavigation)
           .WithMany(e => e.RegistroEntrada)
           .HasForeignKey(e => e.idTipoNovedad)
           .OnDelete(DeleteBehavior.ClientSetNull)
           .HasConstraintName("RegistroEntrada_TipoNovedad_fk");

            builder.HasOne(e => e.idEmpleadoNavigation)
             .WithMany(e => e.RegistroEntradas)
             .HasForeignKey(e => e.idEmpleado)
             .OnDelete(DeleteBehavior.ClientSetNull)
             .HasConstraintName("RegistroEntrada_Empleado_fk");
        }
    }
}
