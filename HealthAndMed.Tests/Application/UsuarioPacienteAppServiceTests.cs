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
    public class UsuarioPacienteAppServiceTests
    {
        private readonly Mock<IUsuarioPacienteDomainService> _domainServiceMock;
        private readonly UsuarioPacienteAppService _usuarioPacienteAppService;

        public UsuarioPacienteAppServiceTests()
        {
            _domainServiceMock = new Mock<IUsuarioPacienteDomainService>();
            _usuarioPacienteAppService = new UsuarioPacienteAppService(_domainServiceMock.Object);
        }

        [Fact]
        public async Task AgendaPacienteEdata_ShouldReturnAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var data = DateTime.Now;
            var idMedico = 1;
            var expectedAgenda = new AgendaResponseModel
            {
                Medico_Id = idMedico,
                DataAtendimento = data
            };

            _domainServiceMock.Setup(ds => ds.AgendaPacienteEdata(data, idMedico))
                .ReturnsAsync(expectedAgenda);

            // Act
            var result = await _usuarioPacienteAppService.AgendaPacienteEdata(data, idMedico);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(idMedico, result.Medico_Id);
            _domainServiceMock.Verify(ds => ds.AgendaPacienteEdata(data, idMedico), Times.Once);
        }

        [Fact]
        public async Task ListaAgendaNaData_ShouldReturnListOfAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var data = DateTime.Now;
            var idPaciente = 1;
            var expectedAgendas = new List<AgendaResponseModel>
            {
                new AgendaResponseModel { Paciente_Id = idPaciente, DataAtendimento = data }
            };

            _domainServiceMock.Setup(ds => ds.ListaAgendaNaData(data, idPaciente))
                .ReturnsAsync(expectedAgendas);

            // Act
            var result = await _usuarioPacienteAppService.ListaAgendaNaData(data, idPaciente);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(idPaciente, result[0].Paciente_Id);
            _domainServiceMock.Verify(ds => ds.ListaAgendaNaData(data, idPaciente), Times.Once);
        }

        [Fact]
        public async Task ListaMedicoNaData_ShouldReturnListOfAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var data = DateTime.Now;
            var idMedico = 1;
            var expectedAgendas = new List<AgendaResponseModel>
            {
                new AgendaResponseModel { Medico_Id = idMedico, DataAtendimento = data }
            };

            _domainServiceMock.Setup(ds => ds.ListaMedicoNaData(data, idMedico))
                .ReturnsAsync(expectedAgendas);

            // Act
            var result = await _usuarioPacienteAppService.ListaMedicoNaData(data, idMedico);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(idMedico, result[0].Medico_Id);
            _domainServiceMock.Verify(ds => ds.ListaMedicoNaData(data, idMedico), Times.Once);
        }

        [Fact]
        public async Task ListaAgendaPorPaciente_ShouldReturnListOfAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var idMedico = 1;
            var expectedAgendas = new List<AgendaResponseModel>
            {
                new AgendaResponseModel { Medico_Id = idMedico }
            };

            _domainServiceMock.Setup(ds => ds.ListaAgendaPorPaciente(idMedico))
                .ReturnsAsync(expectedAgendas);

            // Act
            var result = await _usuarioPacienteAppService.ListaAgendaPorPaciente(idMedico);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
            Assert.Equal(idMedico, result[0].Medico_Id);
            _domainServiceMock.Verify(ds => ds.ListaAgendaPorPaciente(idMedico), Times.Once);
        }

        [Fact]
        public async Task AgendaDisponivelMedico_ShouldReturnMedicoEspecialidadeAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var idMedico = 1;
            var idEspecialidade = 2;
            var expectedAgenda = new MedicoEspecialidadeAgendaResponseModel
            {
                Medico_Id = idMedico,
                Especialidade_Id = idEspecialidade
            };

            _domainServiceMock.Setup(ds => ds.AgendaDisponivelMedico(idMedico, idEspecialidade))
                .ReturnsAsync(expectedAgenda);

            // Act
            var result = await _usuarioPacienteAppService.AgendaDisponivelMedico(idMedico, idEspecialidade);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(idMedico, result.Medico_Id);
            Assert.Equal(idEspecialidade, result.Especialidade_Id);
            _domainServiceMock.Verify(ds => ds.AgendaDisponivelMedico(idMedico, idEspecialidade), Times.Once);
        }

        [Fact]
        public async Task AgendaDisponivelEspecialidade_ShouldReturnEspecialidadeMedicoAgendaResponseModel_WhenCalledWithValidParameters()
        {
            // Arrange
            var idEspecialidade = 2;
            var expectedAgenda = new EspecialidadeMedicoAgendaResponseModel
            {
                Especialidade_Id = idEspecialidade
            };

            _domainServiceMock.Setup(ds => ds.AgendaDisponivelEspecialidade(idEspecialidade))
                .ReturnsAsync(expectedAgenda);

            // Act
            var result = await _usuarioPacienteAppService.AgendaDisponivelEspecialidade(idEspecialidade);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(idEspecialidade, result.Especialidade_Id);
            _domainServiceMock.Verify(ds => ds.AgendaDisponivelEspecialidade(idEspecialidade), Times.Once);
        }
    }
}
