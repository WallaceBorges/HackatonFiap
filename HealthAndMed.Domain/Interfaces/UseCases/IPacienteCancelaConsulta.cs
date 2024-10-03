using HealthAndMed.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.UseCases
{
    public interface IPacienteCancelaConsulta
    {
        Task<string> CancelaConsulta(MarcaAgendamentoRequestModel agenda);
    }
}
