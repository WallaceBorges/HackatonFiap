using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Responses
{
    public class CriaContaResponseModel
    {
            public string? Mensagem { get; set; }
            public int? Id { get; set; }
            public string? Nome { get; set; }
            public string? Email { get; set; }
            public DateTime? DataHoraCriacao { get; set; }
    }
}
