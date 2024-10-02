using HealthAndMed.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Entities
{
    public class UsuarioBase : EntityBase
    {
        public long Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        [NotMapped]
        public string? AccessToken { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }
}
