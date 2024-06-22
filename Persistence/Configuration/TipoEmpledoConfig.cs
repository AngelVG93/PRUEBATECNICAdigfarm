using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configuration
{
    internal class TipoEmpledoConfig : IEntityTypeConfiguration<TipoEmpledo>
    {
        public void Configure(EntityTypeBuilder<TipoEmpledo> builder)
        {
            builder.HasKey(e => e.idTipoEmpleado);
            builder.ToTable("TipoEmpledo");
            builder.Property(e => e.idTipoEmpleado).HasColumnName("idTipoEmpleado");

            builder.Property(e => e.nombre).HasColumnName("nombre");
        }
    }
}
