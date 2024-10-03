using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.Interfaces
{
    public interface IUsuarioMedicoAppService
    {
        Task<IList<AgendaResponseModel>> ListaAgendaPorMedico(int idMedico);
        Task<AgendaResponseModel> AgendaMedicoEdata(DateTime data, int idMedico);
        Task<IList<AgendaResponseModel>> ListaAgendaNaData(DateTime data, int idMedico);

        Task<string> CadastraEspecialidade(int idEspecialidade, int idMedico);
        Task<string> ExcluiEspecialidade(int idEspecialidade, int idMedico);
    }
}
