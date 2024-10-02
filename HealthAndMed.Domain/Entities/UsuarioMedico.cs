using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Entities
{
    public class UsuarioMedico:UsuarioBase
    {
        public string CRM { get; set; }
        public int Especialidade_Id { get; set; }

        public IList<MedicoEspecialidade> medicoEspecialidade { get; set; }
        public IList<Agenda> Agendas { get; set; }
    }
}
