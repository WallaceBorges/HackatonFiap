using HealthAndMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.ValueObjects
{
    public class MedicoEspecialidade
    {
        public int Medico_Id { get; set; }
        public int EspecialidadeMedica_Id { get; set; }

        public UsuarioMedico Medico { get; set; }
        public EspecialidadeMedica Especialidade { get; set; }
    }
}
