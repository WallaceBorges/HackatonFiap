
using HealthAndMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces
{
    /// <summary>
    /// Interface para abstração das operações de autenticação de Usuario
    /// </summary>
    public interface IUsuarioAuthentication
    {
        /// <summary>
        /// Método para gerar o token de acesso do usuário
        /// </summary>
        string CreateToken(UsuarioBase usuario);
    }
}
