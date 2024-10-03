using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Services
{
    public interface IEspecialidadeMedicaDomainService
    {
        Task<IList<EspecialidadeMedica>> ListaEspecialidade();
        Task<string> CriaEspecialidade(EspecialidadeMedica model);
        Task<string> AlteraEspecialidade(EspecialidadeMedica model);
        Task<string> ExcluiEspecialidade(int id);
        Task<EspecialidadeMedica> RetornaEspecialidadePorId(int id);
        
    }
}
