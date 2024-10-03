using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Services
{
    public interface IUsuarioMedicoDomainService
    {
        Task<IList<AgendaResponseModel>> ListaAgendaPorMedico(int idMedico);
        Task<AgendaResponseModel> AgendaMedicoEdata(DateTime data, int idMedico);
        Task<IList<AgendaResponseModel>> ListaAgendaNaData(DateTime data, int idMedico);
        Task<string> CadastraEspecialidadeParaMedico(int idEspecialidade, int idMedico);
        Task<string> ExcluiEspecialidadeParaMedico(int idEspecialidade, int idMedico);
    
    }
}
