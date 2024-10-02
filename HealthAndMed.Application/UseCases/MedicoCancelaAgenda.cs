using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces.UseCases;
using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.UseCases
{
    public class MedicoCancelaAgenda : IMedicoCancelaAgenda
    {
        private readonly IAgendaRepository _repository;

        public MedicoCancelaAgenda(IAgendaRepository repository)
        {
            _repository = repository;
        }

        public string CancelaAgenda(CriaAgendamentoRequestModel agenda)
        {

            try
            {
                _repository.Deletar(agenda.Medico_Id,agenda.DataAtendimento);
                return "Horário de atendimento Excluído com sucesso.";
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
