using HealthAndMed.Application.Interfaces;
using HealthAndMed.Domain.Enums;
using HealthAndMed.Domain.Models.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthAndMed.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadeMedicaController : ControllerBase
    {
        private readonly IEspecialidadeMedicaAppService _appEspecialidade;
        private readonly ILogger<MedicoController> _logger;

        public EspecialidadeMedicaController(IEspecialidadeMedicaAppService appService, ILogger<MedicoController> logger)
        {
            _appEspecialidade = appService;
            _logger = logger;
        }


        /// <summary>
        /// Retorna a lista de especialidades cadastradas.
        /// </summary>
        [HttpGet]
        [Route("lista-especialidades")]
        public async Task<IActionResult> ListaEspecialidade()
        {
            try
            {
                var response = await _appEspecialidade.RetornaListaEspecialidades();
                return StatusCode(201, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao realizar consulta: {e.Message}");
            }
        }

        /// <summary>
        /// Retorna a especialidades cadastrada com o ID informado.
        /// </summary>
        [HttpGet]
        [Route("especialidade/{id}")]
        public async Task<IActionResult> Especialidade(int id)
        {
            try
            {
                var response = await _appEspecialidade.RetornaEspecialidadePorId(id);
                return StatusCode(201, response);

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao realizar consulta: {e.Message}");
            }
        }

        /// <summary>
        /// Serviço para criação de Especialidade Médica.
        /// </summary>
        [HttpPost]
        [Authorize(Roles = $"{Permissoes.Medico}")]
        [Route("Criar-especialidade")]
        public async Task<IActionResult> CriarEspecialidadea(CriaEspecialidadeRequestModel request)
        {
            try
            {
                var response = await _appEspecialidade.CadastraEspecialidade(request);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Horásrio Disponivel: {e.Message}");
            }
        }

        /// <summary>
        /// Serviço para criação de Horário disponivel para consulta.
        /// </summary>
        [HttpDelete]
        [Authorize(Roles = $"{Permissoes.Medico}")]
        [Route("exclui-especialidade/{id}")]
        public async Task<IActionResult> CriarEspecialidadea(int id)
        {
            try
            {
                var response = await _appEspecialidade.ExcluiEspecialidade(id);
                return StatusCode(201, response);
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"{DateTime.Now} - Exception Forçada: {e.Message}");
                return BadRequest($"Erro ao Criar Horásrio Disponivel: {e.Message}");
            }
        }
    }
}
