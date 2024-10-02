using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Requests
{
    public class CadastraPacienteRequestModel
    {
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
