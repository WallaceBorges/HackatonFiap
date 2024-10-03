using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Services
{
    public class UsuarioPacienteDomainService : IUsuarioPacienteDomainService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMedicoEspecialidadeRepository _medicoEspecialidade;

        public UsuarioPacienteDomainService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        public async Task<MedicoEspecialidadeAgendaResponseModel> AgendaDisponivelMedico(int idMedico, int idEspecialidade)
        {
            try
            {
                var agenda = await _medicoEspecialidade.AgendaPorEspecialidade(idMedico,idEspecialidade);
                return agenda;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AgendaResponseModel> AgendaPacienteEdata(DateTime data, int idPaciente)
        {
            try
            {
                var agenda = await _agendaRepository.ObterPorIdPacienteEData(idPaciente, data);
                var agendaResponde = new AgendaResponseModel
                {
                    Medico_Id = agenda.Medico_Id,
                    DataAtendimento = agenda.DataAtendimento,
                    Paciente_Id = agenda.Paciente_Id,
                    DataAgendou = agenda.DataAgendou,
                    Prontuario = agenda.Prontuario,
                    isAtendico = agenda.isAtendico,
                };
                return agendaResponde;
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
                var agenda = await _agendaRepository.ObterPorIdPacienteNaData(idPaciente, data);
                var agendaResponde = agenda.Select(x => new AgendaResponseModel
                {
                    Medico_Id = x.Medico_Id,
                    DataAtendimento = x.DataAtendimento,
                    Paciente_Id = x.Paciente_Id,
                    DataAgendou = x.DataAgendou,
                    Prontuario = x.Prontuario,
                    isAtendico = x.isAtendico,

                }).ToList();
                return agendaResponde;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<AgendaResponseModel>> ListaAgendaPorPaciente(int idPaciente)
        {
            try
            {
                var agenda = await _agendaRepository.ObterPorIdPaciente(idPaciente);
                var agendaResponde = agenda.Select(x => new AgendaResponseModel
                {
                    Medico_Id = x.Medico_Id,
                    DataAtendimento = x.DataAtendimento,
                    Paciente_Id = x.Paciente_Id,
                    DataAgendou = x.DataAgendou,
                    Prontuario = x.Prontuario,
                    isAtendico = x.isAtendico,

                }).ToList();
                return agendaResponde;
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
                var agenda = await _agendaRepository.ObterPorIdMedicoNaData(idMedico, data);
                var agendaResponde = agenda.Where(x => x.Paciente_Id == null || x.Paciente_Id == 0)
                                            .Select(x => new AgendaResponseModel
                {
                    Medico_Id = x.Medico_Id,
                    DataAtendimento = x.DataAtendimento,
                    Paciente_Id = x.Paciente_Id,
                    DataAgendou = x.DataAgendou,
                    Prontuario = x.Prontuario,
                    isAtendico = x.isAtendico,

                }).ToList();
                return agendaResponde;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
