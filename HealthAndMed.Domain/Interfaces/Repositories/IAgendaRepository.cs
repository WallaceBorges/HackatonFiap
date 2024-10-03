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
        Task<IList<Agenda>> ObterPorIdMedico(int id);
        Task<IList<Agenda>> ObterPorIdMedicoNaData(int id, DateTime dtAgenda);
        Task<Agenda> ObterPorIdMedicoEData(int id, DateTime dtAgenda);
        Task<IList<Agenda>> ObterPorIdPaciente(int id);
        Task<Agenda> ObterPorIdPacienteEData(int id, DateTime dtAgenda);
        Task<IList<Agenda>> ObterPorIdPacienteNaData(int id, DateTime dtAgenda);
        Task<IList<Agenda>> ObterPorIdEspecialidade(int id);
    }
}
