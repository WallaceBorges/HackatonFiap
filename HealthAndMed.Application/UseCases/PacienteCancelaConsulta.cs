using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces.UseCases;
using HealthAndMed.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.UseCases
{
    public class PacienteCancelaConsulta : IPacienteCancelaConsulta
    {
        private readonly IAgendaRepository _agendaRepository;

        public PacienteCancelaConsulta(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }
        public async Task<string> CancelaConsulta(MarcaAgendamentoRequestModel agenda)
        {
            try
            {
                var ag = await _agendaRepository.ObterPorIdPacienteEData(agenda.Paciente_Id, agenda.DataAtendimento);
                if (ag != null)
                {
                    if ((ag.isAtendico.HasValue &&
                        ag.isAtendico.Value) ||
                        ag.DataAtendimento < DateTime.Now)
                    {
                        throw new Exception("Não é possivel cancelar esta consulta, consulta já aconteceu ou data anterior a data atual.");
                    }

                    ag.Paciente_Id = null;
                    ag.DataAgendou = null;
                    _agendaRepository.Alterar(ag);
                    return "Consulta Cancelada com sucesso.";
                }
                else
                {
                    throw new Exception("Nenhum consulta encontrado para esse paciente nesse horário.");
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
