using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RunGym.Models;
using RunGym.Repositorios.Interfaces;

namespace RunGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ErroresReportadosController : Controller
    {
        public readonly IErroresReportados _erroresreportados;

        public ErroresReportadosController(IErroresReportados erroresreportados)
        {
            _erroresreportados = erroresreportados;
        }

        [HttpGet("GetErroresReportados")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetErroresReportados()
        {
            var erroresreportados = await _erroresreportados.GetErroresReportados();
            return Ok(erroresreportados);
        }

        [HttpPost("PostErroresReportados")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostErroresReportados([FromBody] ErroresReportados erroresreportados)
        {
            try
            {
                var response = await _erroresreportados.PostErroresReportados(erroresreportados);
                if (response == true)
                    return Ok("Insertado correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
