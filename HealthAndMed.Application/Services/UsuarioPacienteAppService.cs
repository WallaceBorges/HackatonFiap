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
            try
            {

                return await _domainService.AgendaPacienteEdata(data, idMedico);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<AgendaResponseModel>> ListaAgendaNaData(DateTime data, int idPaciente)
        {
            try
            {
                return await _domainService.ListaAgendaNaData(data, idPaciente);

            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<IList<AgendaResponseModel>> ListaMedicoNaData(DateTime data, int idMedico)
        {
            try
            {
                return await _domainService.ListaMedicoNaData(data, idMedico);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<AgendaResponseModel>> ListaAgendaPorPaciente(int idMedico)
        {
            try
            {

                return await _domainService.ListaAgendaPorPaciente(idMedico);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public async Task<MedicoEspecialidadeAgendaResponseModel> AgendaDisponivelMedico(int idMedico, int idEspecialidade)
        {
            try
            {
                return await _domainService.AgendaDisponivelMedico(idMedico, idEspecialidade);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
