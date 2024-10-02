using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Services
{
    public class UsuarioMedicoDomainService : IUsuarioMedicoDomainService
    {
        public Task<IList<AgendaResponseModel>> ListaAgendaPorData(DateTime data, int idMedico)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AgendaResponseModel>> ListaAgendaPorMedico(int idMedico)
        {
            throw new NotImplementedException();
        }

        public Task<IList<AgendaResponseModel>> ListaAgendaPortfolio(int idPort, int idMedico)
        {
            throw new NotImplementedException();
        }
    }
}
