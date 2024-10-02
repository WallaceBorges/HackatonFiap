using HealthAndMed.Application.Interfaces;
using HealthAndMed.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthAndMed.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger<UsuarioController> _logger;
        private readonly IUsuarioAppService _usuarioService;

        public UsuarioController(ILogger<UsuarioController> logger,
                                IUsuarioAppService usuarioAppService)
        {
            _logger = logger;
            _usuarioService = usuarioAppService;
        }


        [AllowAnonymous]
        [Route("Autenticar")]
        [HttpPost]
        public async Task<IActionResult> Autenticar([FromBody] AutenticarRequestModel usuarioModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = _usuarioService?.Autenticar(usuarioModel);
                return StatusCode(200, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Autenticar: {e.Message}");
            }
        }

        /// <summary>
        /// Serviço para criação de conta de novos Médicos.
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("Criar-Conta-medico")]
        public IActionResult CriarConta(CadastraMedicoRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = _usuarioService?.CriarContaMedico(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Conta: {e.Message}");
            }
        }


        /// <summary>
        /// Serviço para criação de conta de novos Médicos.
        /// </summary>
        [AllowAnonymous]
        [HttpPost]
        [Route("Criar-Conta-paciente")]
        public IActionResult CriarConta(CadastraPacienteRequestModel request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var response = _usuarioService?.CriarContaPaciente(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Conta: {e.Message}");
            }
        }
    }
}
