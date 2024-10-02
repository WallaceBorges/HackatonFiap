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
    public class EspecialidadeMedicaMap : IEntityTypeConfiguration<EspecialidadeMedica>
    {
        public void Configure(EntityTypeBuilder<EspecialidadeMedica> builder)
        {
            builder.ToTable("EspecialidadeMedica");

            builder.HasKey(x=>x.Id);

            builder.HasData(
                            new EspecialidadeMedica { Id = 1, Nome = "Clínico Geral" },
                            new EspecialidadeMedica { Id = 2, Nome = "Pediatra" },
                            new EspecialidadeMedica { Id = 3, Nome = "Cardiologista" },
                            new EspecialidadeMedica { Id = 4, Nome = "Ginecologista e Obstetra" },
                            new EspecialidadeMedica { Id = 5, Nome = "Dermatologista" },
                            new EspecialidadeMedica { Id = 6, Nome = "Ortopedista e Traumatologista" },
                            new EspecialidadeMedica { Id = 7, Nome = "Neurologista" },
                            new EspecialidadeMedica { Id = 8, Nome = "Psiquiatra" },
                            new EspecialidadeMedica { Id = 9, Nome = "Oftalmologista" },
                            new EspecialidadeMedica { Id = 10, Nome = "Endocrinologista" },
                            new EspecialidadeMedica { Id = 11, Nome = "Gastroenterologista" },
                            new EspecialidadeMedica { Id = 12, Nome = "Urologista" },
                            new EspecialidadeMedica { Id = 13, Nome = "Hematologista" },
                            new EspecialidadeMedica { Id = 14, Nome = "Oncologista" },
                            new EspecialidadeMedica { Id = 15, Nome = "Nefrologista" },
                            new EspecialidadeMedica { Id = 16, Nome = "Reumatologista" },
                            new EspecialidadeMedica { Id = 17, Nome = "Otorrinolaringologista" },
                            new EspecialidadeMedica { Id = 18, Nome = "Pneumologista" },
                            new EspecialidadeMedica { Id = 19, Nome = "Infectologista" },
                            new EspecialidadeMedica { Id = 20, Nome = "Cirurgião Geral" }
                            );
        }
    }
}
