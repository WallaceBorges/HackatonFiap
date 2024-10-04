using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Dtos;
using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.UseCases;
using HealthAndMed.Infra.Messages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.UseCases
{
    public class PacienteAgendaConsulta : IPacienteAgendaConsulta
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly IUsuarioBaseRepository _userRepos;
        private readonly IConsultaMessageProduce _Messagem;


        public PacienteAgendaConsulta(IAgendaRepository agendaRepository, IConsultaMessageProduce messagem, IUsuarioBaseRepository userRepos)
        {
            _agendaRepository = agendaRepository;
            _Messagem = messagem;
            _userRepos = userRepos;
        }

        public async Task<string> AgendarConsulta(MarcaAgendamentoRequestModel agenda)
        {
            try
            {
                var ag = await _agendaRepository.ObterPorIdMedicoEData(agenda.Medico_Id, agenda.DataAtendimento);
                if (ag != null)
                {
                    if ((ag.isAtendico.HasValue && ag.isAtendico.Value)||
                        ag.DataAtendimento < DateTime.Now)
                    {
                        throw new Exception("Este Horário não está diponivel");
                    }

                    ag.Paciente_Id = agenda.Paciente_Id;
                    ag.DataAgendou = DateTime.Now;
                    _agendaRepository.Alterar(ag);
                    var medico = _userRepos.ObterPorId(ag.Medico_Id);
                    var paciente = _userRepos.ObterPorId(ag.Paciente_Id.Value);
                    var usuarioMessageService = new ConsultaMessageService();
        
                    _Messagem.Send(new Domain.Models.Dtos.ConsultaMensagemDto
                    {
                        DataHora = ag.DataAgendou,
                        TipoMensagem = TipoMensagem.ConsultaMarcada,
                        Usuario = new UsuarioDto
                        {
                            Data = agenda.DataAtendimento,
                            NomePaciente = paciente.Nome,
                            Medico = medico.Nome,
                            Email = medico.Email,
                        }
                    });
                    return "Consulta Agendada com sucesso.";
                }
                else
                {
                    throw new Exception("Nenhum horário encontrado para esse médico nessa data.");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
