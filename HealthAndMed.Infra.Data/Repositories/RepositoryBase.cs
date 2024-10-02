using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        public void Alterar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(T entidade)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public T ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public IList<T> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public Task<IList<T>> ObterTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
