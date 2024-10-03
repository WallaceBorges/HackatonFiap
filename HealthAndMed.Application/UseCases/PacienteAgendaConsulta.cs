using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.UseCases;
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

        public PacienteAgendaConsulta(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
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
