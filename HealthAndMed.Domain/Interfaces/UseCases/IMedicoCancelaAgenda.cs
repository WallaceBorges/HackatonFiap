using HealthAndMed.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.UseCases
{
    public interface IMedicoCancelaAgenda
    {
        string CancelaAgenda(CriaAgendamentoRequestModel agenda);
    }
}
