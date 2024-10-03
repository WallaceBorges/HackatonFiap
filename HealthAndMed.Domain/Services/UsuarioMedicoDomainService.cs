using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Responses;
using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HealthAndMed.Domain.Services
{
    public class UsuarioMedicoDomainService : IUsuarioMedicoDomainService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IMedicoEspecialidadeRepository _MedicoEspecialidadeRepository;

        public UsuarioMedicoDomainService(IAgendaRepository agendaRepository, IMedicoEspecialidadeRepository medicoEspecialidadeRepository)
        {
            _agendaRepository = agendaRepository;
            _MedicoEspecialidadeRepository = medicoEspecialidadeRepository;
        }

        public async Task<AgendaResponseModel> AgendaMedicoEdata(DateTime data, int idMedico)
        {
            try
            {
                var agenda = await _agendaRepository.ObterPorIdMedicoEData(idMedico, data);
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

        public async Task<string> CadastraEspecialidadeParaMedico(int idEspecialidade, int idMedico)
        {
            try
            {
                var esp = new MedicoEspecialidade
                {
                    EspecialidadeMedica_Id = idEspecialidade,
                    Medico_Id = idMedico
                };
                _MedicoEspecialidadeRepository.Cadastrar(esp);
                return "Especialidade Cadastrada para o médico com sucesso";
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<string> ExcluiEspecialidadeParaMedico(int idEspecialidade, int idMedico)
        {
            try
            {
                var esp = await _MedicoEspecialidadeRepository.ObterPorIdMedicoIdEspecialidade(idMedico, idEspecialidade);
                if (esp != null)
                {
                    _MedicoEspecialidadeRepository.Deletar(esp);
                    return "Especialidade Cadastrada para o médico com sucesso";
                }
                else
                {
                    return "Especialidade não localizada para o médico logado.";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<AgendaResponseModel>> ListaAgendaNaData(DateTime data, int idMedico)
        {
            try
            {
                var agenda = await _agendaRepository.ObterPorIdMedicoNaData(idMedico, data);
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

        public async Task<IList<AgendaResponseModel>> ListaAgendaPorMedico(int idMedico)
        {
            try
            {
                var agenda = await _agendaRepository.ObterPorIdMedico(idMedico);
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

    }
}
