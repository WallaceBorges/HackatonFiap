using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Services
{
    public interface IUsuarioPacienteDomainService
    {
        Task<IList<AgendaResponseModel>> ListaAgendaPorPaciente(int idPaciente);
        Task<AgendaResponseModel> AgendaPacienteEdata(DateTime data, int idPaciente);
        Task<IList<AgendaResponseModel>> ListaAgendaNaData(DateTime data, int idPaciente);
        Task<IList<AgendaResponseModel>> ListaMedicoNaData(DateTime data, int idMedico);
    
    }
}
