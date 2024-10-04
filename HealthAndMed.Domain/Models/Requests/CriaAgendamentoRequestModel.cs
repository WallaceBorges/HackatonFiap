using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Requests
{
    public class CriaAgendamentoRequestModel
    {
        [JsonIgnore]
        public int Medico_Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        public int Especialidade_Id { get; set; }
    }
}
