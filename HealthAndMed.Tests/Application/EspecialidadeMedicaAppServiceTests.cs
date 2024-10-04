using HealthAndMed.Application.Services;
using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Requests;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Tests.Application
{
    public class EspecialidadeMedicaAppServiceTests
    {
        private readonly Mock<IEspecialidadeMedicaDomainService> _domainServiceMock;
        private readonly EspecialidadeMedicaAppService _appService;

        public EspecialidadeMedicaAppServiceTests()
        {
            _domainServiceMock = new Mock<IEspecialidadeMedicaDomainService>();
            _appService = new EspecialidadeMedicaAppService(_domainServiceMock.Object);
        }

        [Fact]
        public async Task AlteraEspecialidade_WithValidId_ShouldReturnSuccessMessage()
        {
            // Arrange
            var especialidade = new EspecialidadeMedica { Id = 1, Nome = "Cardiologia" };
            var requestModel = new AlteraEspecialidadeRequestModel { Id = 1, Nome = "Neurologia" };

            _domainServiceMock.Setup(ds => ds.RetornaEspecialidadePorId(1)).ReturnsAsync(especialidade);
            _domainServiceMock.Setup(ds => ds.AlteraEspecialidade(It.IsAny<EspecialidadeMedica>())).ReturnsAsync("Especialidade Alterada com sucesso.");

            // Act
            var result = await _appService.ALteraEspecialidade(requestModel);

            // Assert
            Assert.Equal("Especialidade Alterada com sucesso.", result);
            _domainServiceMock.Verify(ds => ds.RetornaEspecialidadePorId(1), Times.Once);
            _domainServiceMock.Verify(ds => ds.AlteraEspecialidade(It.IsAny<EspecialidadeMedica>()), Times.Once);
        }

  

        [Fact]
        public async Task CadastraEspecialidade_ShouldReturnSuccessMessage()
        {
            // Arrange
            var requestModel = new CriaEspecialidadeRequestModel { Nome = "Ortopedia" };

            _domainServiceMock.Setup(ds => ds.AlteraEspecialidade(It.IsAny<EspecialidadeMedica>()))
            .ReturnsAsync("Especialidade Alterada com sucesso.");

            // Act
            var result = await _appService.CadastraEspecialidade(requestModel);

            // Assert
            Assert.Equal("Especialidade Cadastrada com sucesso.", result);
            _domainServiceMock.Verify(ds => ds.AlteraEspecialidade(It.IsAny<EspecialidadeMedica>()), Times.Once);
        }

        [Fact]
        public async Task ExcluiEspecialidade_WithValidId_ShouldReturnSuccessMessage()
        {
            // Arrange
            var especialidade = new EspecialidadeMedica { Id = 1, Nome = "Cardiologia" };

            _domainServiceMock.Setup(ds => ds.RetornaEspecialidadePorId(1)).ReturnsAsync(especialidade);
            _domainServiceMock.Setup(ds => ds.ExcluiEspecialidade(1)).ReturnsAsync("Especialidade Excluida com sucesso.");

            // Act
            var result = await _appService.ExcluiEspecialidade(1);

            // Assert
            Assert.Equal("Especialidade Excluida com sucesso.", result);
            _domainServiceMock.Verify(ds => ds.RetornaEspecialidadePorId(1), Times.Once);
            _domainServiceMock.Verify(ds => ds.ExcluiEspecialidade(1), Times.Once);
        }

        [Fact]
        public async Task ExcluiEspecialidade_WithInvalidId_ShouldReturnNotFoundMessage()
        {
            // Arrange
            _domainServiceMock.Setup(ds => ds.RetornaEspecialidadePorId(1)).ReturnsAsync((EspecialidadeMedica)null);

            // Act
            var result = await _appService.ExcluiEspecialidade(1);

            // Assert
            Assert.Equal("Nenhuma Especialidade Médica encontrada com o código informado.", result);
            _domainServiceMock.Verify(ds => ds.RetornaEspecialidadePorId(1), Times.Once);
            _domainServiceMock.Verify(ds => ds.ExcluiEspecialidade(1), Times.Never);
        }

        [Fact]
        public async Task RetornaEspecialidadePorId_ShouldReturnEspecialidade()
        {
            // Arrange
            var especialidade = new EspecialidadeMedica { Id = 1, Nome = "Cardiologia" };

            _domainServiceMock.Setup(ds => ds.RetornaEspecialidadePorId(1)).ReturnsAsync(especialidade);

            // Act
            var result = await _appService.RetornaEspecialidadePorId(1);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal("Cardiologia", result.Nome);
            _domainServiceMock.Verify(ds => ds.RetornaEspecialidadePorId(1), Times.Once);
        }

        [Fact]
        public async Task RetornaListaEspecialidades_ShouldReturnListOfEspecialidades()
        {
            // Arrange
            var especialidades = new List<EspecialidadeMedica>
            {
                new EspecialidadeMedica { Id = 1, Nome = "Cardiologia" },
                new EspecialidadeMedica { Id = 2, Nome = "Neurologia" }
            };

            _domainServiceMock.Setup(ds => ds.ListaEspecialidade()).ReturnsAsync(especialidades);

            // Act
            var result = await _appService.RetornaListaEspecialidades();

            // Assert
            Assert.Equal(2, result.Count);
            _domainServiceMock.Verify(ds => ds.ListaEspecialidade(), Times.Once);
        }
    }
}
