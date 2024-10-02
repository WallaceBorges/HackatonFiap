using HealthAndMed.Application.Interfaces;
using HealthAndMed.Application.UseCases;
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
    public class MedicoController : ControllerBase
    {
        private readonly ICriaAgendaDisponivel _criaAgenda;
        private readonly IFinalizaConsultaAgenda _finalizaAgenda;
        private readonly IMedicoCancelaAgenda _CancelaAgenda;
        private readonly IUsuarioMedicoAppService _appService;
        private readonly ILogger<UsuarioController> _logger;

        public MedicoController(ICriaAgendaDisponivel criaAgenda, ILogger<UsuarioController> logger, IFinalizaConsultaAgenda finalizaAgenda, IUsuarioMedicoAppService appService)
        {
            _criaAgenda = criaAgenda;
            _logger = logger;
            _finalizaAgenda = finalizaAgenda;
            _appService = appService;
        }


        /// <summary>
        /// Serviço para criação de Horário disponivel para consulta.
        /// </summary>
        [HttpPost]
        [Authorize(Roles = $"{Permissoes.Medico}")]
        [Route("Criar-agenda-disponivel")]
        public IActionResult CriarConsulta(CriaAgendamentoRequestModel request)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                request.Medico_Id = userId;
                var response = _criaAgenda?.CriaAgenda(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Horásrio Disponivel: {e.Message}");
            }

        }

        /// <summary>
        /// Serviço Finalização de Consulta para consulta.
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{Permissoes.Medico}")]
        [Route("finaliza-consulta-disponivel")]
        public IActionResult finalizaConsulta(FinalizaAgendamentoRequestModel request)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                request.Medico_Id = userId;
                var response = _finalizaAgenda?.FinalizaConsulta(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Horásrio Disponivel: {e.Message}");
            }

        }

        /// <summary>
        /// Serviço Cancelamento de consulta.
        /// </summary>
        [HttpPut]
        [Authorize(Roles = $"{Permissoes.Medico}")]
        [Route("cancela-consulta-disponivel")]
        public IActionResult CancelaConsulta(CriaAgendamentoRequestModel request)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                request.Medico_Id = userId;
                var response = _CancelaAgenda.CancelaAgenda(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Horário Disponivel: {e.Message}");
            }

        }

        /// <summary>
        /// retorna lista de consultas cadastradas para o médico.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{Permissoes.Medico}")]
        [Route("lista-consulta")]
        public async Task<IActionResult> ListConsulta()
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                var response = await _appService.ListaAgendaPorMedico(userId);
                return StatusCode(201, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao realizar consulta: {e.Message}");
            }


        }

        /// <summary>
        /// retorna lista de consultas cadastradas para o médico na data informada.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{Permissoes.Medico}")]
        [Route("lista-consulta-data/{data}")]
        public async Task<IActionResult> ListConsultaData(DateTime data)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                var response = await _appService.ListaAgendaNaData(data, userId);
                return StatusCode(201, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao realizar consulta: {e.Message}");
            }
        }

        /// <summary>
        /// retorna a consulta cadastrada para o médico na data e hora informada.
        /// </summary>
        [HttpGet]
        [Authorize(Roles = $"{Permissoes.Medico}")]
        [Route("consulta-data/{data}")]
        public async Task<IActionResult> ConsultaData(DateTime data)
        {
            var userId = int.Parse(User.FindFirst("Id")?.Value);
            try
            {
                var response = await _appService.AgendaMedicoEdata(data, userId);
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