using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Responses
{
    public class AgendaResponseModel
    {
        public int Medico_Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        public int? Paciente_Id { get; set; }
        public DateTime? DataAgendou { get; set; }
        public bool? isAtendico { get; set; }
        public string? Prontuario { get; set; }
    }
}
