using RunGym.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RunGym.Models;
using Microsoft.AspNetCore.Authorization;

namespace RunGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PasosEjercicioController : ControllerBase
    {
        private readonly IPasosEjercicio _pasosEjercicio;
        public PasosEjercicioController(IPasosEjercicio pasosEjercicio)
        {
            _pasosEjercicio = pasosEjercicio;
        }

        [HttpGet("GetPasosEjercicio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEjercicios()
        {
            var response = await _pasosEjercicio.GetPasosEjercicio();
            return Ok(response);
        }

        [HttpPost("PostPasosEjercicio")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEjercicios([FromBody] PasosEjercicio pasosEjercicio)
        {
            try
            {
                var response = await _pasosEjercicio.PostPasosEjercicio(pasosEjercicio);
                if (response == true)
                    return Ok("Categoria Insertada correctamente");
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("PutPasosEjercicio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAdministrador([FromBody] PasosEjercicio pasosEjercicio)
        {


            try
            {
                var response = await _pasosEjercicio.PutPasosEjercicio(pasosEjercicio);
                if (response)
                    return Ok("Categoria actualizado correctamente.");
                else
                    return NotFound("Categoria no encontrado.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeletePasosEjercicio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePasosEjercicio(int id)
        {
            try
            {
                var response = await _pasosEjercicio.DeletePasosEjercicio(id);

                if (response)
                    return Ok("Categoría eliminada con éxito.");
                else
                    return NotFound("La categoría no fue encontrada.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}