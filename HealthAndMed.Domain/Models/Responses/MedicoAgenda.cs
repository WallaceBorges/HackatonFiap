using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Responses
{
    public class MedicoAgenda
    {
        public int Medico_Id { get; set; }
        public string Nome { get; set; }
        public IList<DateTime> Agenda { get; set; }
    }
}
