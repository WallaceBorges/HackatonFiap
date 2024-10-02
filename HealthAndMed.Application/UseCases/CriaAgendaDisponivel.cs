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
    public class CriaAgendaDisponivel : ICriaAgendaDisponivel
    {
        private readonly IAgendaRepository _agendaRepos;

        public CriaAgendaDisponivel(IAgendaRepository agendaRepos)
        {
            _agendaRepos = agendaRepos;
        }

        public string CriaAgenda(CriaAgendamentoRequestModel agenda)
        {
            var ag = new Agenda
            {
                DataAtendimento = agenda.DataAtendimento,
                Medico_Id = agenda.Medico_Id,
            };
            try
            {
                _agendaRepos.Cadastrar(ag);
                return "Horário de atendimento criado com sucesso.";
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
