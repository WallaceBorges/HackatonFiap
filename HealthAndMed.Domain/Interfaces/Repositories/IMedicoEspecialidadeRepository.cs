using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Models.Responses;
using HealthAndMed.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Repositories
{
    public interface IMedicoEspecialidadeRepository 
    {
        IList<MedicoEspecialidade> ObterTodos();
        Task<IList<MedicoEspecialidade>> ObterTodosAsync();
        Task<IList<MedicoEspecialidade>> ObterPorIdMedico(int id);
        Task<IList<MedicoEspecialidade>>  ObterPorIdEspecialidade(int id);
        Task<MedicoEspecialidade>  ObterPorIdMedicoIdEspecialidade(int idMedico,int idEspecialidade);
        Task<MedicoEspecialidadeAgendaResponseModel> AgendaPorEspecialidade(int idMedico, int idEspecialidade);
        void Cadastrar(MedicoEspecialidade entidade);
        void Alterar(MedicoEspecialidade entidade);
        void Deletar(MedicoEspecialidade entidade);
    }
}
