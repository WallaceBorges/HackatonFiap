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

        IList<EspecialidadeMedica> EspecialidadeMedidas { get; set; }   
    }
}
