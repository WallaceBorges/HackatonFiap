using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Requests
{
    public class FinalizaAgendamentoRequestModel
    {
        public int Medico_Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        public string Prontuario { get; set; }
    }
}
