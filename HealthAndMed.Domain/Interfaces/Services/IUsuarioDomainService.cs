using HealthAndMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        void CriarConta(UsuarioBase usuario);

        UsuarioBase Autenticar(string email, string senha);
    }
}
