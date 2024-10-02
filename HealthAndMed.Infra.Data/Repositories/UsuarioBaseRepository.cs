using AtivosTC5.Infra.Data.Contexts;
using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Data.Repositories
{
    public class UsuarioBaseRepository : RepositoryBase<UsuarioBase>, IUsuarioBaseRepository
    {
        public UsuarioBase ObterPorEmail(string email)
        {
            using (var context = new SqlServerContext())
            {
                return context.Usuarios
                     .FirstOrDefault(u => u.Email.Equals(email));
            }
        }

        public UsuarioBase ObterPorEmailESenha(string email, string senha)
        {
            using (var context = new SqlServerContext())
            {

#pragma warning disable CS8603 // Possible null reference return.
                return context.Usuarios
                    .FirstOrDefault(u => u.Email.Equals(email)
                                      && u.Senha.Equals(senha));
#pragma warning restore CS8603 // Possible null reference return.


            }
        }
    }
}
