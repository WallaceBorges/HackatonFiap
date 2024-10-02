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
    public class UsuarioPacienteMap : IEntityTypeConfiguration<UsuarioPaciente>
    {
        public void Configure(EntityTypeBuilder<UsuarioPaciente> builder)
        {
            builder.HasBaseType<UsuarioBase>(); // Herda de UsuarioBase

            builder.Property(u => u.TipoUsuario)
                   .IsRequired();

            builder.HasMany(x => x.Agendas)
                .WithOne(x => x.Paciente)
                .HasForeignKey(x=>x.Paciente_Id)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
