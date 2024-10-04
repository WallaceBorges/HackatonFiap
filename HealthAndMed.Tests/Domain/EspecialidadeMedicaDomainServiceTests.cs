using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Xunit;
using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Services;
using FluentAssertions;

namespace HealthAndMed.Tests.Domain
{
    public class EspecialidadeMedicaDomainServiceTests
    {
        private readonly Mock<IEspecialidadeMedicaRepository> _repositoryMock;
        private readonly EspecialidadeMedicaDomainService _service;

        public EspecialidadeMedicaDomainServiceTests()
        {
            _repositoryMock = new Mock<IEspecialidadeMedicaRepository>();
            _service = new EspecialidadeMedicaDomainService(_repositoryMock.Object);
        }

        #region CriaEspecialidade Tests

        [Fact]
        public async Task CriaEspecialidade_Should_Return_Success_Message()
        {
            // Arrange
            var especialidade = new EspecialidadeMedica { Nome = "Cardiologia" };

            // Act
            var result = await _service.CriaEspecialidade(especialidade);

            // Assert
            result.Should().Be("Especialidade Cadastrada com sucesso.");
            _repositoryMock.Verify(r => r.Cadastrar(especialidade), Times.Once);
        }

        [Fact]
        public async Task CriaEspecialidade_Should_Throw_Exception_When_Error_Occurs()
        {
            // Arrange
            var especialidade = new EspecialidadeMedica { Nome = "Cardiologia" };
            _repositoryMock.Setup(r => r.Cadastrar(It.IsAny<EspecialidadeMedica>())).Throws(new Exception());

            // Act
            Func<Task> action = async () => await _service.CriaEspecialidade(especialidade);

            // Assert
            await action.Should().ThrowAsync<Exception>();
            _repositoryMock.Verify(r => r.Cadastrar(especialidade), Times.Once);
        }

        #endregion

        #region AlteraEspecialidade Tests

        [Fact]
        public async Task AlteraEspecialidade_Should_Return_Success_Message()
        {
            // Arrange
            var especialidade = new EspecialidadeMedica { Nome = "Pediatria" };

            // Act
            var result = await _service.AlteraEspecialidade(especialidade);

            // Assert
            result.Should().Be("Especialidade Alterada com sucesso.");
            _repositoryMock.Verify(r => r.Alterar(especialidade), Times.Once);
        }

        [Fact]
        public async Task AlteraEspecialidade_Should_Throw_Exception_When_Error_Occurs()
        {
            // Arrange
            var especialidade = new EspecialidadeMedica { Nome = "Pediatria" };
            _repositoryMock.Setup(r => r.Alterar(It.IsAny<EspecialidadeMedica>())).Throws(new Exception());

            // Act
            Func<Task> action = async () => await _service.AlteraEspecialidade(especialidade);

            // Assert
            await action.Should().ThrowAsync<Exception>();
            _repositoryMock.Verify(r => r.Alterar(especialidade), Times.Once);
        }

        #endregion

        #region ExcluiEspecialidade Tests

        [Fact]
        public async Task ExcluiEspecialidade_Should_Return_Success_Message()
        {
            // Arrange
            var especialidadeId = 1;

            // Act
            var result = await _service.ExcluiEspecialidade(especialidadeId);

            // Assert
            result.Should().Be("Especialidade Excluida com Sucesso.");
            _repositoryMock.Verify(r => r.Deletar(especialidadeId), Times.Once);
        }

        [Fact]
        public async Task ExcluiEspecialidade_Should_Throw_Exception_When_Error_Occurs()
        {
            // Arrange
            var especialidadeId = 1;
            _repositoryMock.Setup(r => r.Deletar(It.IsAny<int>())).Throws(new Exception());

            // Act
            Func<Task> action = async () => await _service.ExcluiEspecialidade(especialidadeId);

            // Assert
            await action.Should().ThrowAsync<Exception>();
            _repositoryMock.Verify(r => r.Deletar(especialidadeId), Times.Once);
        }

        #endregion

        #region ListaEspecialidade Tests

        [Fact]
        public async Task ListaEspecialidade_Should_Return_List_Of_Especialidades()
        {
            // Arrange
            var especialidades = new List<EspecialidadeMedica>
            {
                new EspecialidadeMedica { Nome = "Cardiologia" },
                new EspecialidadeMedica { Nome = "Pediatria" }
            };
            _repositoryMock.Setup(r => r.ObterTodosAsync()).ReturnsAsync(especialidades);

            // Act
            var result = await _service.ListaEspecialidade();

            // Assert
            result.Should().BeEquivalentTo(especialidades);
            _repositoryMock.Verify(r => r.ObterTodosAsync(), Times.Once);
        }

        #endregion

        #region RetornaEspecialidadePorId Tests

        [Fact]
        public async Task RetornaEspecialidadePorId_Should_Return_Especialidade()
        {
            // Arrange
            var especialidade = new EspecialidadeMedica { Id = 1, Nome = "Neurologia" };
            _repositoryMock.Setup(r => r.ObterPorId(It.IsAny<int>())).Returns(especialidade);

            // Act
            var result = await _service.RetornaEspecialidadePorId(1);

            // Assert
            result.Should().Be(especialidade);
            _repositoryMock.Verify(r => r.ObterPorId(1), Times.Once);
        }

        [Fact]
        public async Task RetornaEspecialidadePorId_Should_Return_Null_If_Not_Found()
        {
            // Arrange
            _repositoryMock.Setup(r => r.ObterPorId(It.IsAny<int>())).Returns((EspecialidadeMedica)null);

            // Act
            var result = await _service.RetornaEspecialidadePorId(1);

            // Assert
            result.Should().BeNull();
            _repositoryMock.Verify(r => r.ObterPorId(1), Times.Once);
        }

        #endregion
    }
}
