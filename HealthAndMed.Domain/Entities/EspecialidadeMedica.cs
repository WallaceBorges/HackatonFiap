using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Entities
{
    public class EspecialidadeMedica:EntityBase
    {
       public IList<MedicoEspecialidade> medicoEspecialidades { get; set; }
       public IList<Agenda> agendas { get; set; }
    }
}
