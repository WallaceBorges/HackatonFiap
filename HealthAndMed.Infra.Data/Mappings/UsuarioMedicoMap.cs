using HealthAndMed.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Data.Mappings
{
    public class UsuarioMedicoMap : IEntityTypeConfiguration<UsuarioMedico>
    {
        public void Configure(EntityTypeBuilder<UsuarioMedico> builder)
        {
            builder.HasBaseType<UsuarioBase>(); // Herda de UsuarioBase

            // Propriedades específicas de médicos
            builder.Property(u => u.Especialidade_Id)
                   .IsRequired();

            // Define que médicos terão TipoUsuario = 1
            builder.Property(u => u.TipoUsuario)
                   .IsRequired();

            builder.HasMany(x => x.Agendas)
                   .WithOne(x=>x.Medico)
                   .HasForeignKey(x=>x.Medico_Id)
                   .OnDelete(DeleteBehavior.NoAction);
            
        }
    }
}
