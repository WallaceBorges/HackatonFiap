using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Services
{
    public class EspecialidadeMedicaDomainService : IEspecialidadeMedicaDomainService
    {
        private readonly IEspecialidadeMedicaRepository _repository;

        public EspecialidadeMedicaDomainService(IEspecialidadeMedicaRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> AlteraEspecialidade(EspecialidadeMedica model)
        {
            try
            {
                _repository.Alterar(model);
                return "Especialidade Alterada com sucesso.";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> CriaEspecialidade(EspecialidadeMedica model)
        {
            try
            {
                _repository.Cadastrar(model);
                return "Especialidade Cadastrada com sucesso.";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> ExcluiEspecialidade(int id)
        {
            try
            {
                _repository.Deletar(id);
                return "Especialidade Excluida com Sucesso.";
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async  Task<IList<EspecialidadeMedica>> ListaEspecialidade()
        {
            return await _repository.ObterTodosAsync();
        }

        public async Task<EspecialidadeMedica> RetornaEspecialidadePorId(int id)
        {
            return _repository.ObterPorId(id);
            
        }
    }
}
