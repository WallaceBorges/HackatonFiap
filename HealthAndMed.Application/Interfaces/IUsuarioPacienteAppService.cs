using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.Interfaces
{
    public interface IUsuarioPacienteAppService
    {
        Task<IList<AgendaResponseModel>> ListaAgendaPorPaciente(int idPaciente);
        Task<AgendaResponseModel> AgendaPacienteEdata(DateTime data, int idPaciente);
        Task<IList<AgendaResponseModel>> ListaAgendaNaData(DateTime data, int idPaciente);
        Task<IList<AgendaResponseModel>> ListaMedicoNaData(DateTime data, int idPaciente);
        Task<MedicoEspecialidadeAgendaResponseModel> AgendaDisponivelMedico(int idMedico, int idEspecialidade);
        Task<EspecialidadeMedicoAgendaResponseModel> AgendaDisponivelEspecialidade(int idEspecialidade);
    }
}
