using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces.Services;
using Hel.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HealthAndMed.Domain.Services.UsuarioDomainService;

namespace HealthAndMed.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributos
        private readonly IUsuarioBaseRepository? _usuarioRepository;
        private readonly IUsuarioAuthentication? _usuarioAuthentication;

        //construtor para injeção de dependência (inicialização dos atributos)
        public UsuarioDomainService(IUsuarioBaseRepository? usuarioRepository, IUsuarioAuthentication? usuarioAuthentication)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioAuthentication = usuarioAuthentication;
        }

        public UsuarioBase Autenticar(string email, string senha)
        {
            try
            {
                var usuario = _usuarioRepository?.ObterPorEmailESenha(email, Sha1Helper.Encrypt(senha));
                if (usuario == null)
                    throw new Exception("Usuario Não Cadastrado");

                usuario.AccessToken = _usuarioAuthentication?.CreateToken(usuario);
                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CriarConta(UsuarioBase usuario)
        {
            //Não permitir o cadastro de usuários com o mesmo email
            if (_usuarioRepository?.ObterPorEmail(usuario.Email) != null)
                throw new Exception("Usuario Já Cadastrado");

            //gerando os dados adicionais do usuário
            usuario.Senha = Sha1Helper.Encrypt(usuario.Senha);

            //gravando no banco de dados
            _usuarioRepository?.Cadastrar(usuario);

        }

    }
}

