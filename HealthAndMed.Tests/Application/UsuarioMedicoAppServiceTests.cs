using HealthAndMed.Application.Services;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Responses;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Tests.Application
{
    public class UsuarioMedicoAppServiceTests
    {
        private readonly Mock<IUsuarioMedicoDomainService> _domainServiceMock;
        private readonly UsuarioMedicoAppService _usuarioMedicoAppService;

        public UsuarioMedicoAppServiceTests()
        {
            _domainServiceMock = new Mock<IUsuarioMedicoDomainService>();
            _usuarioMedicoAppService = new UsuarioMedicoAppService(_domainServiceMock.Object);
        }

        [Fact]
        public async Task AgendaMedicoEdata_ShouldReturnAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var data = DateTime.Now;
            var idMedico = 1;
            var expectedAgenda = new AgendaResponseModel
            {
                Medico_Id = idMedico,
                DataAtendimento = data
            };

            _domainServiceMock.Setup(ds => ds.AgendaMedicoEdata(data, idMedico))
                .ReturnsAsync(expectedAgenda);

            // Act
            var result = await _usuarioMedicoAppService.AgendaMedicoEdata(data, idMedico);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(idMedico, result.Medico_Id);
            _domainServiceMock.Verify(ds => ds.AgendaMedicoEdata(data, idMedico), Times.Once);
        }

        [Fact]
        public async Task CadastraEspecialidade_ShouldReturnSuccessMessage_WhenCalledWithValidParameters()
        {
            // Arrange
            var idEspecialidade = 1;
            var idMedico = 2;
            var expectedMessage = "Especialidade cadastrada com sucesso.";

            _domainServiceMock.Setup(ds => ds.CadastraEspecialidadeParaMedico(idEspecialidade, idMedico))
                .ReturnsAsync(expectedMessage);

            // Act
            var result = await _usuarioMedicoAppService.CadastraEspecialidade(idEspecialidade, idMedico);

            // Assert
            Assert.Equal(expectedMessage, result);
            _domainServiceMock.Verify(ds => ds.CadastraEspecialidadeParaMedico(idEspecialidade, idMedico), Times.Once);
        }

        [Fact]
        public async Task ExcluiEspecialidade_ShouldReturnSuccessMessage_WhenCalledWithValidParameters()
        {
            // Arrange
            var idEspecialidade = 1;
            var idMedico = 2;
            var expectedMessage = "Especialidade excluída com sucesso.";

            _domainServiceMock.Setup(ds => ds.ExcluiEspecialidadeParaMedico(idEspecialidade, idMedico))
                .ReturnsAsync(expectedMessage);

            // Act
            var result = await _usuarioMedicoAppService.ExcluiEspecialidade(idEspecialidade, idMedico);

            // Assert
            Assert.Equal(expectedMessage, result);
            _domainServiceMock.Verify(ds => ds.ExcluiEspecialidadeParaMedico(idEspecialidade, idMedico), Times.Once);
        }

        [Fact]
        public async Task ListaAgendaNaData_ShouldReturnListOfAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var data = DateTime.Now;
            var idMedico = 1;
            var expectedAgendas = new List<AgendaResponseModel>
            {
                new AgendaResponseModel { Medico_Id = idMedico, DataAtendimento = data }
            };

            _domainServiceMock.Setup(ds => ds.ListaAgendaNaData(data, idMedico))
                .ReturnsAsync(expectedAgendas);

            // Act
            var result = await _usuarioMedicoAppService.ListaAgendaNaData(data, idMedico);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            _domainServiceMock.Verify(ds => ds.ListaAgendaNaData(data, idMedico), Times.Once);
        }

        [Fact]
        public async Task ListaAgendaPorMedico_ShouldReturnListOfAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var idMedico = 1;
            var expectedAgendas = new List<AgendaResponseModel>
            {
                new AgendaResponseModel { Medico_Id = idMedico }
            };

            _domainServiceMock.Setup(ds => ds.ListaAgendaPorMedico(idMedico))
                .ReturnsAsync(expectedAgendas);

            // Act
            var result = await _usuarioMedicoAppService.ListaAgendaPorMedico(idMedico);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            _domainServiceMock.Verify(ds => ds.ListaAgendaPorMedico(idMedico), Times.Once);
        }
    }
}
