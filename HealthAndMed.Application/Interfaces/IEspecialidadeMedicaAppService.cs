using HealthAndMed.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.Interfaces
{
    public interface IEspecialidadeMedicaAppService
    {
        Task<string> CadastraEspecialidade(CriaEspecialidadeRequestModel model);
        Task<string> ExcluiEspecialidade(int id);
        Task<string> ALteraEspecialidade(AlteraEspecialidadeRequestModel model);
        Task<IList<AlteraEspecialidadeRequestModel>> RetornaListaEspecialidades();
        Task<AlteraEspecialidadeRequestModel> RetornaEspecialidadePorId(int id);

    }
}
