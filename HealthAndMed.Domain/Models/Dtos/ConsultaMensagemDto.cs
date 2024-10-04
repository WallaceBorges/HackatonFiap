using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Dtos
{
    public class ConsultaMensagemDto
    {
        public TipoMensagem TipoMensagem { get; set; }
        public DateTime? DataHora { get; set; }
        public UsuarioDto? Usuario { get; set; }
    }

    public class UsuarioDto
    {
        public int? Id { get; set; }
        public string? Medico { get; set; }
        public string? NomePaciente { get; set; }
        public string? Email { get; set; }
        public DateTime? Data { get; set; }

    }

    public enum TipoMensagem
    {
        BoasVindas = 1,
        ConsultaMarcada = 2
    }
}
