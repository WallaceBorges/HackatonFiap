using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Models.Requests
{
    public class MarcaAgendamentoRequestModel
    {
        public int Medico_Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        [JsonIgnore]
        public int Paciente_Id { get; set; }
    }
}
