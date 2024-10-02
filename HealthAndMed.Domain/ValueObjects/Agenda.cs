using HealthAndMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.ValueObjects
{
    public class Agenda
    {
        public int Medico_Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        public int? Paciente_Id { get; set; }
        public DateTime? DataAgendou { get; set; }
        public bool? isAtendico { get; set; }
        public string? Prontuario { get; set; }

        public UsuarioMedico Medico { get; set; }
        public UsuarioPaciente Paciente { get; set; }

    }
}
