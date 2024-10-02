using HealthAndMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<UsuarioBase>
    {
        public void Configure(EntityTypeBuilder<UsuarioBase> builder)
        {
            builder.ToTable("Usuario"); 

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(200);

            
        }
    }
}
