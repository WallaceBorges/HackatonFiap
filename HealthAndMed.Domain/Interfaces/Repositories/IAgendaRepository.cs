using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Repositories
{
    public interface IAgendaRepository
    {
        void Alterar(Agenda entidade);
        void Cadastrar(Agenda entidade);
        void Deletar(int medicoIde, DateTime dtAtendimento);
        IList<Agenda> ObterPorIdMedico(int id);
        Agenda ObterPorIdMedicoEData(int id, DateTime dtAgenda);
        IList<Agenda> ObterPorIdPaciente(int id);
        Agenda ObterPorIdPacienteEData(int id, DateTime dtAgenda);
        IList<Agenda> ObterPorIdEspecialidade(int id);
    }
}
