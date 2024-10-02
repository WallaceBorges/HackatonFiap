using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.Interfaces
{
    public interface IUsuarioAppService
    {
        /// <summary>
        /// Método de ação para criar a conta do usuário
        /// </summary>
        /// <param name="model">Dados da requisição</param>
        /// <returns>Dados da resposta</returns>
        CriaContaResponseModel CriarContaMedico(CadastraMedicoRequestModel model);
        CriaContaResponseModel CriarContaPaciente(CadastraPacienteRequestModel model);

        /// <summary>
        /// Método de ação para autenticar o usuário
        /// </summary>
        /// <param name="model">Dados da requisição</param>
        /// <returns>Dados da resposta</returns>
        AutenticarResponseModel Autenticar(AutenticarRequestModel model);
    }
}
