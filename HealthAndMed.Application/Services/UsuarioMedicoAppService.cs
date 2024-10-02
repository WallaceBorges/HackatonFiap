using HealthAndMed.Application.Interfaces;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.Services
{
    public class UsuarioMedicoAppService : IUsuarioMedicoAppService
    {
        private readonly IUsuarioMedicoDomainService _domainService;

        public UsuarioMedicoAppService(IUsuarioMedicoDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<AgendaResponseModel> AgendaMedicoEdata(DateTime data, int idMedico)
        {
            return await _domainService.AgendaMedicoEdata(data,idMedico);
        }

        public async Task<IList<AgendaResponseModel>> ListaAgendaNaData(DateTime data, int idMedico)
        {
            return await _domainService.ListaAgendaNaData(data,idMedico);
        }

        public async Task<IList<AgendaResponseModel>> ListaAgendaPorMedico(int idMedico)
        {
            return await _domainService.ListaAgendaPorMedico(idMedico);
            
        }
    }
}
