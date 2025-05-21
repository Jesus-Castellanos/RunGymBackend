using RunGym.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RunGym.Models;
using Microsoft.AspNetCore.Authorization;

namespace RunGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DietaController : ControllerBase
    {
        private readonly IDieta _dieta;

        public DietaController(IDieta dieta)
        {
            _dieta = dieta;
        }

        [HttpGet("GetDieta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDieta()
        {
            var response = await _dieta.GetDieta();
            return Ok(response);
        }

        [HttpPost("PostDieta")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostDieta([FromBody] Dieta dieta)
        {
            try
            {
                var response = await _dieta.PostDieta(dieta);
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
        [HttpPut("PutDieta/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> PutDieta(int id, [FromBody] Dieta dieta)
        {
            if (id != dieta.Id)
            {
                return BadRequest("El ID de la dieta no coincide.");
            }

            try
            {
                var response = await _dieta.PutDieta(dieta);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Dieta no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeleteDieta/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteDieta(Dieta dieta)
        {
            try
            {
                var response = await _dieta.DeleteDieta(dieta);
                if (response)
                    return NoContent();
                else
                    return NotFound("Dieta no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
