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
    internal class TipoNovedadConfig : IEntityTypeConfiguration<TipoNovedad>
    {
        public void Configure(EntityTypeBuilder<TipoNovedad> builder)
        {
            builder.HasKey(e => e.idTipoNovedad);
            builder.ToTable("TipoNovedad");
            builder.Property(e => e.idTipoNovedad).HasColumnName("idTipoNovedad");

            builder.Property(e => e.nombre).HasColumnName("nombre");
        }
    }
}
