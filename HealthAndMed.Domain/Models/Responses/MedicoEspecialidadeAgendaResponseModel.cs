using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Responses
{
    public class MedicoEspecialidadeAgendaResponseModel
    {
        public int Medico_Id { get; set; }
        public string Nome { get; set; }
        public int Especialidade_Id { get; set; }
        public string Especialidade_Nome { get; set; }
        public IList<DateTime>? Agenda { get; set; }
    }
}
