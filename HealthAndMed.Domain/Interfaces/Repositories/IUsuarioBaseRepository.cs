using HealthAndMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Repositories
{
    public interface IUsuarioBaseRepository:IRepositoryBase<UsuarioBase>
    {
        UsuarioBase ObterPorEmailESenha(string email, string senha);
        UsuarioBase ObterPorEmail(string email);
    }
}
