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
    public class UsuarioMedicoDomainServiceTests
    {
        private readonly Mock<IAgendaRepository> _agendaRepositoryMock;
        private readonly UsuarioMedicoDomainService _service;

        public UsuarioMedicoDomainServiceTests()
        {
            _agendaRepositoryMock = new Mock<IAgendaRepository>();
            _service = new UsuarioMedicoDomainService(_agendaRepositoryMock.Object);
        }

        #region AgendaMedicoEdata Tests

        [Fact]
        public async Task AgendaMedicoEdata_Should_Return_AgendaResponseModel_When_Agenda_Exists()
        {
            // Arrange
            var data = new DateTime(2024, 10, 03);
            var idMedico = 1;
            var agendaMock = new Agenda
            {
                Medico_Id = idMedico,
                DataAtendimento = data,
                Paciente_Id = 123,
                DataAgendou = new DateTime(2024, 10, 01),
                Prontuario = "Prontuario Teste",
                isAtendico = true
            };

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdMedicoEData(idMedico, data))
                .ReturnsAsync(agendaMock);

            // Act
            var result = await _service.AgendaMedicoEdata(data, idMedico);

            // Assert
            result.Should().NotBeNull();
            result.Medico_Id.Should().Be(idMedico);
            result.DataAtendimento.Should().Be(data);
            result.Paciente_Id.Should().Be(123);
            result.DataAgendou.Should().Be(new DateTime(2024, 10, 01));
            result.Prontuario.Should().Be("Prontuario Teste");
            result.isAtendico.Should().BeTrue();
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdMedicoEData(idMedico, data), Times.Once);
        }

        [Fact]
        public async Task AgendaMedicoEdata_Should_Throw_Exception_When_Agenda_Not_Found()
        {
            // Arrange
            var data = new DateTime(2024, 10, 03);
            var idMedico = 1;

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdMedicoEData(idMedico, data))
                .ReturnsAsync((Agenda)null);

            // Act
            Func<Task> action = async () => await _service.AgendaMedicoEdata(data, idMedico);

            // Assert
            await action.Should().ThrowAsync<Exception>();
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdMedicoEData(idMedico, data), Times.Once);
        }

        #endregion

        #region ListaAgendaNaData Tests

        [Fact]
        public async Task ListaAgendaNaData_Should_Return_ListOf_AgendaResponseModel_When_Agenda_Exists()
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
                    Paciente_Id = 123,
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste",
                    isAtendico = true
                },
                new Agenda
                {
                    Medico_Id = idMedico,
                    DataAtendimento = data,
                    Paciente_Id = 124,
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste 2",
                    isAtendico = false
                }
            };

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdMedicoNaData(idMedico, data))
                .ReturnsAsync(agendaMockList);

            // Act
            var result = await _service.ListaAgendaNaData(data, idMedico);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.First().Medico_Id.Should().Be(idMedico);
            result.First().Paciente_Id.Should().Be(123);
            result.Last().Paciente_Id.Should().Be(124);
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdMedicoNaData(idMedico, data), Times.Once);
        }

        #endregion

        #region ListaAgendaPorMedico Tests

        [Fact]
        public async Task ListaAgendaPorMedico_Should_Return_ListOf_AgendaResponseModel_When_Agenda_Exists()
        {
            // Arrange
            var idMedico = 1;
            var agendaMockList = new List<Agenda>
            {
                new Agenda
                {
                    Medico_Id = idMedico,
                    DataAtendimento = new DateTime(2024, 10, 03),
                    Paciente_Id = 123,
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste",
                    isAtendico = true
                },
                new Agenda
                {
                    Medico_Id = idMedico,
                    DataAtendimento = new DateTime(2024, 10, 04),
                    Paciente_Id = 124,
                    DataAgendou = new DateTime(2024, 10, 01),
                    Prontuario = "Prontuario Teste 2",
                    isAtendico = false
                }
            };

            _agendaRepositoryMock.Setup(repo => repo.ObterPorIdMedico(idMedico))
                .ReturnsAsync(agendaMockList);

            // Act
            var result = await _service.ListaAgendaPorMedico(idMedico);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result.First().Medico_Id.Should().Be(idMedico);
            result.First().Paciente_Id.Should().Be(123);
            result.Last().Paciente_Id.Should().Be(124);
            _agendaRepositoryMock.Verify(repo => repo.ObterPorIdMedico(idMedico), Times.Once);
        }

        #endregion
    }
}
