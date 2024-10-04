using HealthAndMed.Application.Interfaces;
using HealthAndMed.Domain.Enums;
using HealthAndMed.Domain.Interfaces.UseCases;
using HealthAndMed.Domain.Models.Requests;
using HealthAndMed.Domain.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthAndMed.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteAgendaConsulta _agendaConsulta;
        private readonly IPacienteCancelaConsulta _cancelaConsulta;
        private readonly IUsuarioPacienteAppService _appService;
        private readonly ILogger<PacienteController> _logger;

        public PacienteController(IPacienteAgendaConsulta agendaConsulta, IPacienteCancelaConsulta cancelaConsulta, IUsuarioPacienteAppService appService, ILogger<PacienteController> logger)
        {
            _agendaConsulta = agendaConsulta;
            _cancelaConsulta = cancelaConsulta;
            _appService = appService;
            _logger = logger;
        }

        /// <summary>
        /// Serviço para agendamento de consulta.
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{Permissoes.Paciente}")]
        [Route("agenda-consulta")]
        public async Task<IActionResult> CriarConsulta(MarcaAgendamentoRequestModel request)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                request.Paciente_Id = userId;
                var response =await _agendaConsulta?.AgendarConsulta(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao marcar consulta: {e.Message}");
            }

        }

        /// <summary>
        /// Serviço para cancelamento de consulta.
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{Permissoes.Paciente}")]
        [Route("cancela-consulta")]
        public async Task<IActionResult> cancelaConsulta(MarcaAgendamentoRequestModel request)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                request.Paciente_Id = userId;
                var response = await _cancelaConsulta?.CancelaConsulta(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao cancelar consulta: {e.Message}");
            }
        }

        /// <summary>
        /// Serviço para listar as consultas do paciente.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{Permissoes.Paciente}")]
        [Route("lista-consulta-paciente")]
        public async Task<IActionResult> CancelaConsulta()
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                var response = await _appService.ListaAgendaPorPaciente(userId);
                return StatusCode(201, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao realizar consulta: {e.Message}");
            }
        }

        /// <summary>
        /// Serviço para listar as consultas disponivel para o médico informado na data informada.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{Permissoes.Paciente}")]
        [Route("lista-consulta-medico-data/{id}/{data}")]
        public async Task<IActionResult> PorMedicoConsulta(int id,DateTime data)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                var response = await _appService.ListaMedicoNaData(data,id);
                return StatusCode(201, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao realizar consulta: {e.Message}");
            }
        }

        /// <summary>
        /// Serviço para listar as consultas disponivel para o médico informado na especialidade selecionada.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{Permissoes.Paciente}")]
        [Route("lista-consulta-medico/{idMedico}/{idEspecialidade}")]
        public async Task<IActionResult> PorMedicoConsultaEspecialidade(int idMedico, int idEspecialidade)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                var response = await _appService.AgendaDisponivelMedico(idMedico, idEspecialidade);
                return StatusCode(201, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao realizar consulta: {e.Message}");
            }
        }

        /// <summary>
        /// Serviço para listar as consultas disponivel para a especialidade informada.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{Permissoes.Paciente}")]
        [Route("lista-consulta-especialidade/{idEspecialidade}")]
        public async Task<IActionResult> ConsultaEspecialidade(int idEspecialidade)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                var response = await _appService.AgendaDisponivelEspecialidade(idEspecialidade);
                return StatusCode(201, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao realizar consulta: {e.Message}");
            }
        }

    }
}
