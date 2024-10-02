using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.UseCases
{
    public interface ICriaAgendaDisponivel
    {
        string CriaAgenda(CriaAgendamentoRequestModel agenda);
    }
}
