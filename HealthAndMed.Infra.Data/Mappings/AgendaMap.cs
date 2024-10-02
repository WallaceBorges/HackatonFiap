using HealthAndMed.Domain.Entities;
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
    public class AgendaMap : IEntityTypeConfiguration<Agenda>
    {
        public void Configure(EntityTypeBuilder<Agenda> builder)
        {
            builder.ToTable("Agenda");


            builder.Property(e => e.DataAtendimento)
                        .HasColumnType("smalldatetime");
            builder.HasKey(x=>new { x.Medico_Id,x.DataAtendimento});

            builder.HasOne(x => x.Paciente)
                    .WithMany(x => x.Agendas)
                    .HasForeignKey(x=>x.Paciente_Id);

            builder.HasOne(x => x.Medico)
                    .WithMany(x => x.Agendas)
                    .HasForeignKey(x=>x.Medico_Id);
        }
    }
}
