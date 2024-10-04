using FluentAssertions;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Services;
using HealthAndMed.Domain.ValueObjects;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Tests.Domain
{
    public class UsuarioPacienteDomainServiceTests
    {
        private readonly Mock<IAgendaRepository> _agendaRepositoryMock;
        private readonly UsuarioPacienteDomainService _service;

        public UsuarioPacienteDomainServiceTests()
        {
            _agendaRepositoryMock = new Mock<IAgendaRepository>();
            _service = new UsuarioPacienteDomainService(_agendaRepositoryMock.Object);
        }

        #region AgendaPacienteEdata Tests

        [Fact]
        public async Task AgendaPacienteEdata_Should_Return_AgendaResponseModel_When_Agenda_Exists()
        {
            // Arrange
            var data = new DateTime(2024, 10, 03);
            var idPaciente = 1;
            var agendaMock = new Agenda
            {
                Medico_Id = 1,
                DataAtendimento = data,
                Paciente_Id = idPaciente,
                DataAgendou = new DateTime(2024, 10, 01),
                Prontuario = "Prontuario Teste",
                isAtendico = true
            };

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdPacienteEData(idPaciente, data))
                .ReturnsAsync(agendaMock);

            // Act
            var result = await _service.AgendaPacienteEdata(data, idPaciente);

            // Assert
            result.Should().NotBeNull();
            result.Medico_Id.Should().Be(1);
            result.DataAtendimento.Should().Be(data);
            result.Paciente_Id.Should().Be(idPaciente);
            result.DataAgendou.Should().Be(new DateTime(2024, 10, 01));
            result.Prontuario.Should().Be("Prontuario Teste");
            result.isAtendico.Should().BeTrue();
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdPacienteEData(idPaciente, data), Times.Once);
        }

        [Fact]
        public async Task AgendaPacienteEdata_Should_Throw_Exception_When_Agenda_Not_Found()
        {
            // Arrange
            var data = new DateTime(2024, 10, 03);
            var idPaciente = 1;

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdPacienteEData(idPaciente, data))
                .ReturnsAsync((Agenda)null);

            // Act
            Func<Task> action = async () => await _service.AgendaPacienteEdata(data, idPaciente);

            // Assert
            await action.Should().ThrowAsync<Exception>();
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdPacienteEData(idPaciente, data), Times.Once);
        }

        #endregion

        #region ListaAgendaNaData Tests

        [Fact]
        public async Task ListaAgendaNaData_Should_Return_ListOf_AgendaResponseModel_When_Agenda_Exists()
        {
            // Arrange
            var data = new DateTime(2024, 10, 03);
            var idPaciente = 1;
            var agendaMockList = new List<Agenda>
            {
                new Agenda
                {
                    Medico_Id = 1,
                    DataAtendimento = data,
                    Paciente_Id = idPaciente,
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste",
                    isAtendico = true
                },
                new Agenda
                {
                    Medico_Id = 2,
                    DataAtendimento = data,
                    Paciente_Id = idPaciente,
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste 2",
                    isAtendico = false
                }
            };

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdPacienteNaData(idPaciente, data))
                .ReturnsAsync(agendaMockList);

            // Act
            var result = await _service.ListaAgendaNaData(data, idPaciente);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.First().Medico_Id.Should().Be(1);
            result.Last().Medico_Id.Should().Be(2);
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdPacienteNaData(idPaciente, data), Times.Once);
        }

        #endregion

        #region ListaAgendaPorPaciente Tests

        [Fact]
        public async Task ListaAgendaPorPaciente_Should_Return_ListOf_AgendaResponseModel_When_Agenda_Exists()
        {
            // Arrange
            var idPaciente = 1;
            var agendaMockList = new List<Agenda>
            {
                new Agenda
                {
                    Medico_Id = 1,
                    DataAtendimento = new DateTime(2024, 10, 03),
                    Paciente_Id = idPaciente,
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste",
                    isAtendico = true
                },
                new Agenda
                {
                    Medico_Id = 2,
                    DataAtendimento = new DateTime(2024, 10, 04),
                    Paciente_Id = idPaciente,
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste 2",
                    isAtendico = false
                }
            };

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdPaciente(idPaciente))
                .ReturnsAsync(agendaMockList);

            // Act
            var result = await _service.ListaAgendaPorPaciente(idPaciente);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.First().Medico_Id.Should().Be(1);
            result.Last().Medico_Id.Should().Be(2);
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdPaciente(idPaciente), Times.Once);
        }

        #endregion

        #region ListaMedicoNaData Tests

        [Fact]
        public async Task ListaMedicoNaData_Should_Return_Only_Unassigned_Agendas()
        {
            // Arrange
            var data = new DateTime(2024, 10, 03);
            var idMedico = 1;
            var agendaMockList = new List<Agenda>
            {
                new Agenda
                {
                    Medico_Id = idMedico,
                    DataAtendimento = data,
                    Paciente_Id = null, // Unassigned
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste",
                    isAtendico = true
                },
                new Agenda
                {
                    Medico_Id = idMedico,
                    DataAtendimento = data,
                    Paciente_Id = 123, // Assigned
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste 2",
                    isAtendico = false
                }
            };

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdMedicoNaData(idMedico, data))
                .ReturnsAsync(agendaMockList);

            // Act
            var result = await _service.ListaMedicoNaData(data, idMedico);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result.First().Medico_Id.Should().Be(idMedico);
            result.First().Paciente_Id.Should().BeNull();
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdMedicoNaData(idMedico, data), Times.Once);
        }

        #endregion
    }
}
