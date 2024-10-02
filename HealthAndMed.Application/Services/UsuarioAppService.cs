using HealthAndMed.Application.Interfaces;
using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IUsuarioDomainService? _usuarioDomainService;
        public UsuarioAppService(IUsuarioDomainService? usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }
        public CriaContaResponseModel CriarContaMedico(CadastraMedicoRequestModel model)
        {
            var usuario = new UsuarioMedico
            {
                Nome=model.Nome,
                Cpf=model.Cpf,
                Email=model.Email,
                Senha=model.Senha,
                CRM=model.CRM,
                Especialidade_Id=model.Especialidade_Id,
                TipoUsuario=Domain.Enums.TipoUsuario.Medico
            };

            _usuarioDomainService?.CriarConta(usuario);

            return new CriaContaResponseModel
            {
                Mensagem = "Parabéns! Sua conta de usuário foi criada com sucesso.",
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCriacao = DateTime.Now
            };
        }

        public CriaContaResponseModel CriarContaPaciente(CadastraPacienteRequestModel model)
        {
            var usuario = new UsuarioMedico
            {
                Nome = model.Nome,
                Cpf = model.Cpf,
                Email = model.Email,
                Senha = model.Senha,
                TipoUsuario = Domain.Enums.TipoUsuario.Paciente
            };

            _usuarioDomainService?.CriarConta(usuario);

            return new CriaContaResponseModel
            {
                Mensagem = "Parabéns! Sua conta de usuário foi criada com sucesso.",
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                DataHoraCriacao=DateTime.Now
            };
        }

        /// <summary>
        /// Serviço da aplicação para autenticação do usuário.
        /// </summary>
        public AutenticarResponseModel Autenticar(AutenticarRequestModel model)
        {
            try
            {
                var usuario = _usuarioDomainService?.Autenticar(model.Email, model.Senha);

                //retornando a resposta com os dados do usuário cadastrado
                return new AutenticarResponseModel
                {
                    Mensagem = "Autenticação realizada com sucesso.",
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    AccessToken = usuario.AccessToken
                };

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
