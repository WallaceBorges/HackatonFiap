using HealthAndMed.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Data.Mappings
{
    public class MedicoEspecialidadeMap : IEntityTypeConfiguration<MedicoEspecialidade>
    {
        public void Configure(EntityTypeBuilder<MedicoEspecialidade> builder)
        {
            builder.ToTable("MedicoEspecialidade");

            builder.HasKey(x => new { x.Medico_Id, x.EspecialidadeMedica_Id });

            builder.HasOne(x => x.Medico)
                .WithMany(x => x.medicoEspecialidade)
                .HasForeignKey(x => x.Medico_Id);


            builder.HasOne(x => x.Especialidade)
                .WithMany(y => y.medicoEspecialidades)
                .HasForeignKey(x => x.EspecialidadeMedica_Id);

            builder.HasMany(x => x.Agenda)
                   .WithOne(x => x.MedicoEspecialidade)
                   .HasPrincipalKey(x => new {x.EspecialidadeMedica_Id })
                   .HasForeignKey(x => new { x.Especialidade_Id });
        }
    }
}
