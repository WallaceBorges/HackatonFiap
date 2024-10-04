using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Responses
{
    public class EspecialidadeMedicoAgendaResponseModel
    {
        public int Especialidade_Id { get; set; }
        public string Nome { get; set; }
        public IList<MedicoAgenda> MedicoAgendas { get; set; }
    }
}
