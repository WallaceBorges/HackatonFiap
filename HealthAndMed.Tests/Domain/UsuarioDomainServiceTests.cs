using FluentAssertions;
using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces;
using HealthAndMed.Domain.Services;
using Hel.Domain.Helpers;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Tests.Domain
{
    public class UsuarioDomainServiceTests
    {
        private readonly Mock<IUsuarioBaseRepository> _usuarioRepositoryMock;
        private readonly Mock<IUsuarioAuthentication> _usuarioAuthenticationMock;
        private readonly UsuarioDomainService _service;

        public UsuarioDomainServiceTests()
        {
            _usuarioRepositoryMock = new Mock<IUsuarioBaseRepository>();
            _usuarioAuthenticationMock = new Mock<IUsuarioAuthentication>();
            _service = new UsuarioDomainService(_usuarioRepositoryMock.Object, _usuarioAuthenticationMock.Object);
        }

        #region Autenticar Tests

        [Fact]
        public void Autenticar_Should_Return_Usuario_With_Token_When_Valid_Credentials()
        {
            // Arrange
            var email = "teste@teste.com";
            var senha = "123456";
            var senhaEncriptada = Sha1Helper.Encrypt(senha);
            var usuario = new UsuarioBase { Email = email, Senha = senhaEncriptada };
            var token = "mocked_token";

            _usuarioRepositoryMock.Setup(r => r.ObterPorEmailESenha(email, senhaEncriptada)).Returns(usuario);
            _usuarioAuthenticationMock.Setup(auth => auth.CreateToken(usuario)).Returns(token);

            // Act
            var result = _service.Autenticar(email, senha);

            // Assert
            result.Should().NotBeNull();
            result.AccessToken.Should().Be(token);
            _usuarioRepositoryMock.Verify(r => r.ObterPorEmailESenha(email, senhaEncriptada), Times.Once);
            _usuarioAuthenticationMock.Verify(auth => auth.CreateToken(usuario), Times.Once);
        }

        [Fact]
        public void Autenticar_Should_Throw_Exception_When_Invalid_Credentials()
        {
            // Arrange
            var email = "invalido@teste.com";
            var senha = "senha_invalida";
            var senhaEncriptada = Sha1Helper.Encrypt(senha);

            _usuarioRepositoryMock.Setup(r => r.ObterPorEmailESenha(email, senhaEncriptada)).Returns((UsuarioBase)null);

            // Act
            Action action = () => _service.Autenticar(email, senha);

            // Assert
            action.Should().Throw<Exception>().WithMessage("Usuario Não Cadastrado");
            _usuarioRepositoryMock.Verify(r => r.ObterPorEmailESenha(email, senhaEncriptada), Times.Once);
            _usuarioAuthenticationMock.Verify(auth => auth.CreateToken(It.IsAny<UsuarioBase>()), Times.Never);
        }

        #endregion

        #region CriarConta Tests

        [Fact]
        public void CriarConta_Should_Create_Usuario_When_Email_Not_Exists()
        {
            // Arrange
            var usuario = new UsuarioBase { Email = "novo@teste.com", Senha = "123456" };
            var senhaEncriptada = Sha1Helper.Encrypt(usuario.Senha);

            _usuarioRepositoryMock.Setup(r => r.ObterPorEmail(usuario.Email)).Returns((UsuarioBase)null);

            // Act
            _service.CriarConta(usuario);

            // Assert
            usuario.Senha.Should().Be(senhaEncriptada);
            _usuarioRepositoryMock.Verify(r => r.Cadastrar(usuario), Times.Once);
        }

        [Fact]
        public void CriarConta_Should_Throw_Exception_When_Email_Already_Exists()
        {
            // Arrange
            var usuario = new UsuarioBase { Email = "existente@teste.com", Senha = "123456" };

            _usuarioRepositoryMock.Setup(r => r.ObterPorEmail(usuario.Email)).Returns(usuario);

            // Act
            Action action = () => _service.CriarConta(usuario);

            // Assert
            action.Should().Throw<Exception>().WithMessage("Usuario Já Cadastrado");
            _usuarioRepositoryMock.Verify(r => r.Cadastrar(It.IsAny<UsuarioBase>()), Times.Never);
        }

        #endregion
    }
}
