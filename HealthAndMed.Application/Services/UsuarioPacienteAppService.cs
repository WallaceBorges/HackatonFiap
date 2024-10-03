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
    public class UsuarioPacienteAppService : IUsuarioPacienteAppService
    {
        private readonly IUsuarioPacienteDomainService _domainService;

        public UsuarioPacienteAppService(IUsuarioPacienteDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<AgendaResponseModel> AgendaPacienteEdata(DateTime data, int idMedico)
        {
            return await _domainService.AgendaPacienteEdata(data,idMedico);
        }

        public async Task<IList<AgendaResponseModel>> ListaAgendaNaData(DateTime data, int idPaciente)
        {
            return await _domainService.ListaAgendaNaData(data, idPaciente);
        }
        public async Task<IList<AgendaResponseModel>> ListaMedicoNaData(DateTime data, int idMedico)
        {
            return await _domainService.ListaMedicoNaData(data, idMedico);
        }

        public async Task<IList<AgendaResponseModel>> ListaAgendaPorPaciente(int idMedico)
        {
            return await _domainService.ListaAgendaPorPaciente(idMedico);
            
        }
    }
}
