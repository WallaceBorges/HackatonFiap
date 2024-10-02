using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Services
{
    public interface IUsuarioMedicoDomainService
    {
        Task<IList<AgendaResponseModel>> ListaAgendaPorMedico(int idMedico);
        Task<IList<AgendaResponseModel>> ListaAgendaPorData(DateTime data, int idMedico);
        Task<IList<AgendaResponseModel>> ListaAgendaPortfolio(int idPort, int idMedico);
    }
}
