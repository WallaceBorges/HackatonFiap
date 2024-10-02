using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Enums
{
    public enum TipoUsuario
    {
        Medico = 1,
        Paciente = 2,
    }
    public static class Permissoes
    {
        public const string Medico = "Medico";
        public const string Paciente = "Paciente";
    }
}
