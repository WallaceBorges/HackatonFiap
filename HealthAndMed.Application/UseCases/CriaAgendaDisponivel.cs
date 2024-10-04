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
        private readonly IMedicoEspecialidadeRepository _EspRepos;

        public CriaAgendaDisponivel(IAgendaRepository agendaRepos, IMedicoEspecialidadeRepository espRepos)
        {
            _agendaRepos = agendaRepos;
            _EspRepos = espRepos;
        }

        public string CriaAgenda(CriaAgendamentoRequestModel agenda)
        {

            try
            {
                var esp = _EspRepos.AgendaPorMedicoEspecialidade(agenda.Medico_Id, agenda.Especialidade_Id).Result;
                if (esp != null)
                {
                    var ag = new Agenda
                    {
                        DataAtendimento = agenda.DataAtendimento,
                        Medico_Id = agenda.Medico_Id,
                        Especialidade_Id = agenda.Especialidade_Id,
                    };
                    _agendaRepos.Cadastrar(ag);
                    return "Horário de atendimento criado com sucesso.";
                }
                else
                {
                    throw new Exception("O médico logado não possui esta especialidade cadastrada.");

                }
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
