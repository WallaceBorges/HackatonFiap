using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.UseCases;
using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.UseCases
{
    public class FinalizaConsultaAgenda : IFinalizaConsultaAgenda
    {
        private readonly IAgendaRepository _agendaRepos;

        public FinalizaConsultaAgenda(IAgendaRepository agendaRepos)
        {
            _agendaRepos = agendaRepos;
        }

        public string FinalizaConsulta(FinalizaAgendamentoRequestModel request)
        {
            var ag = new Agenda
            {
                DataAtendimento = request.DataAtendimento,
                Medico_Id = request.Medico_Id,
                isAtendico=true,
                Prontuario = request.Prontuario,
            };
            try
            {
                _agendaRepos.Alterar(ag);
                return "Consulta Finalizada com sucesso.";
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
