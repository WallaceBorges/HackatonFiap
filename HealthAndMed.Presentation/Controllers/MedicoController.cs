using HealthAndMed.Application.UseCases;
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
        private readonly ILogger<UsuarioController> _logger;

        public MedicoController(ICriaAgendaDisponivel criaAgenda, ILogger<UsuarioController> logger, IFinalizaConsultaAgenda finalizaAgenda)
        {
            _criaAgenda = criaAgenda;
            _logger = logger;
            _finalizaAgenda = finalizaAgenda;
        }


        /// <summary>
        /// Serviço para criação de Horário disponivel para consulta.
        /// </summary>
        [HttpPost]
        [Route("Criar-agenda-disponivel")]
        public IActionResult CriarConsulta(CriaAgendamentoRequestModel request)
        {
            try
            {
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
        [Route("finaliza-consulta-disponivel")]
        public IActionResult finalizaConsulta(FinalizaAgendamentoRequestModel request)
        {
            try
            {
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
        /// Serviço Cancelamento de Consulta para consulta.
        /// </summary>
        [HttpPut]
        [Route("cancela-consulta-disponivel")]
        public IActionResult CancelaConsulta(CriaAgendamentoRequestModel request)
        {
            try
            {
                var response = _CancelaAgenda.CancelaAgenda(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Horásrio Disponivel: {e.Message}");
            }

        }

        /// <summary>
        /// Serviço Cancelamento de Consulta para consulta.
        /// </summary>
        [HttpGet]
        [Route("lista-consulta-disponivel")]
        public IActionResult ListConsulta(CriaAgendamentoRequestModel request)
        {
            try
            {


            }
            catch (Exception e)
            {
               
            }
                return StatusCode(201);

        }
    }
}