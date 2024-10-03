using HealthAndMed.Application.Interfaces;
using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.Services
{
    public class EspecialidadeMedicaAppService : IEspecialidadeMedicaAppService
    {
        private readonly IEspecialidadeMedicaDomainService _domainService;

        public EspecialidadeMedicaAppService(IEspecialidadeMedicaDomainService domainService)
        {
            _domainService = domainService;
        }

        public async Task<string> ALteraEspecialidade(AlteraEspecialidadeRequestModel model)
        {
            try
            {
                var esp = await _domainService.RetornaEspecialidadePorId(model.Id);
                if (esp != null)
                {
                    esp.Nome = model.Nome;
                    await _domainService.AlteraEspecialidade(esp);
                    return "Especialidade Alterada com sucesso.";
                }
                else
                {
                    return "Nenhuma Especialidade Médica encontrada com o código informado.";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> CadastraEspecialidade(CriaEspecialidadeRequestModel model)
        {
            try
            {
                var esp = new EspecialidadeMedica
                {
                    Nome = model.Nome,
                };
                await _domainService.AlteraEspecialidade(esp);
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
                var esp = await _domainService.RetornaEspecialidadePorId(id);
                if (esp != null)
                {
                    await _domainService.ExcluiEspecialidade(id);
                    return "Especialidade Excluida com sucesso.";
                }
                else
                {
                    return "Nenhuma Especialidade Médica encontrada com o código informado.";
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AlteraEspecialidadeRequestModel> RetornaEspecialidadePorId(int id)
        {
            try
            {
                var esp = await _domainService.RetornaEspecialidadePorId(id);
                if (esp != null)
                {
                    var model = new AlteraEspecialidadeRequestModel
                    {
                        Id = esp.Id,
                        Nome = esp.Nome,
                    };
                    return model;

                }
                else
                {
                   throw new Exception("Nenhuma Especialidade encontrada com o id informado.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IList<AlteraEspecialidadeRequestModel>> RetornaListaEspecialidades()
        {
            try
            {
                var esp = await _domainService.ListaEspecialidade();

                var model = esp.Select(x => new AlteraEspecialidadeRequestModel
                {
                    Id = x.Id,
                    Nome = x.Nome,
                }).ToList();
                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
