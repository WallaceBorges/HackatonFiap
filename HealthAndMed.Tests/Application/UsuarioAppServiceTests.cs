using HealthAndMed.Application.Services;
using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Enums;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Requests;
using Moq;


namespace HealthAndMed.Tests.Application
{
    public class UsuarioAppServiceTests
    {
        private readonly UsuarioAppService _usuarioAppService;
        private readonly Mock<IUsuarioDomainService> _usuarioDomainServiceMock;

        public UsuarioAppServiceTests()
        {
            _usuarioDomainServiceMock = new Mock<IUsuarioDomainService>();
            _usuarioAppService = new UsuarioAppService(_usuarioDomainServiceMock.Object);
        }

        [Fact]
        public void CriarContaMedico_DeveRetornarRespostaComSucesso()
        {
            // Arrange
            var model = new CadastraMedicoRequestModel
            {
                Nome = "Dr. João",
                Cpf = 12345678900,
                Email = "joao@teste.com",
                Senha = "senha123",
                CRM = "123456",
                Especialidade_Id = 1
            };

            var usuarioMedico = new UsuarioMedico
            {
                Nome = model.Nome,
                Cpf = model.Cpf,
                Email = model.Email,
                Senha = model.Senha,
                CRM = model.CRM,
                Especialidade_Id = model.Especialidade_Id,
                Id = 1,
                TipoUsuario = TipoUsuario.Medico
            };

            _usuarioDomainServiceMock.Setup(uds => uds.CriarConta(It.IsAny<UsuarioBase>()))
                        .Callback<UsuarioBase>(u => u.Id = 1);

            // Act
            var result = _usuarioAppService.CriarContaMedico(model);

            // Assert
            Assert.Equal("Parabéns! Sua conta de usuário foi criada com sucesso.", result.Mensagem);
            Assert.Equal(1, result.Id);
            Assert.Equal("Dr. João", result.Nome);
            Assert.Equal("joao@teste.com", result.Email);
            _usuarioDomainServiceMock.Verify(uds => uds.CriarConta(It.IsAny<UsuarioMedico>()), Times.Once);
        }

        [Fact]
        public void CriarContaPaciente_DeveRetornarRespostaComSucesso()
        {
            // Arrange
            var model = new CadastraPacienteRequestModel
            {
                Nome = "Maria",
                Cpf = 98765432100,
                Email = "maria@teste.com",
                Senha = "senha123"
            };

            var usuarioPaciente = new UsuarioMedico
            {
                Nome = model.Nome,
                Cpf = model.Cpf,
                Email = model.Email,
                Senha = model.Senha,
                Id = 2,
                TipoUsuario = TipoUsuario.Paciente
            };

            _usuarioDomainServiceMock.Setup(uds => uds.CriarConta(It.IsAny<UsuarioBase>()))
                        .Callback<UsuarioBase>(u => u.Id = 2);
            // Act
            var result = _usuarioAppService.CriarContaPaciente(model);

            // Assert
            Assert.Equal("Parabéns! Sua conta de usuário foi criada com sucesso.", result.Mensagem);
            Assert.Equal(2, result.Id);
            Assert.Equal("Maria", result.Nome);
            Assert.Equal("maria@teste.com", result.Email);
            _usuarioDomainServiceMock.Verify(uds => uds.CriarConta(It.IsAny<UsuarioMedico>()), Times.Once);
        }

        [Fact]
        public void Autenticar_DeveRetornarUsuarioAutenticado()
        {
            // Arrange
            var model = new AutenticarRequestModel
            {
                Email = "joao@teste.com",
                Senha = "senha123"
            };

            var usuario = new UsuarioMedico
            {
                Nome = "João",
                Email = model.Email,
                Senha = model.Senha,
                AccessToken = "fakeAccessToken",
                Id = 1
            };

            _usuarioDomainServiceMock.Setup(uds => uds.Autenticar(model.Email, model.Senha))
                                     .Returns(usuario);

            // Act
            var result = _usuarioAppService.Autenticar(model);

            // Assert
            Assert.Equal("Autenticação realizada com sucesso.", result.Mensagem);
            Assert.Equal(1, result.Id);
            Assert.Equal("João", result.Nome);
            Assert.Equal("joao@teste.com", result.Email);
            Assert.Equal("fakeAccessToken", result.AccessToken);
            _usuarioDomainServiceMock.Verify(uds => uds.Autenticar(model.Email, model.Senha), Times.Once);
        }
    }
}
