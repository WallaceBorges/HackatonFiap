using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Entities
{
    public class UsuarioPaciente:UsuarioBase
    {
        public IList<Agenda> Agendas { get; set; }
    }
}
