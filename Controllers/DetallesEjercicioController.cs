using RunGym.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RunGym.Models;
using Microsoft.AspNetCore.Authorization;

namespace RunGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DetallesEjerciciosController : ControllerBase
    {
        private readonly IDetallesEjercicio _detallesEjercicios;
        public DetallesEjerciciosController(IDetallesEjercicio detallesEjercicio)
        {
            _detallesEjercicios = detallesEjercicio;
        }

        [HttpGet("GetDetallesEjercicio")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDetallesEjercicio()
        {
            var response = await _detallesEjercicios.GetDetallesEjercicio();
            return Ok(response);
        }

        [HttpPost("PostDetallesEjercicio")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEjercicios([FromBody] DetallesEjercicio detallesEjercicio)
        {
            try
            {
                var response = await _detallesEjercicios.PostDetallesEjercicio(detallesEjercicio);
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

        [HttpPut("PutEjercicio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAdministrador([FromBody] DetallesEjercicio detallesEjercicio)
        {


            try
            {
                var response = await _detallesEjercicios.PutDetallesEjercicio(detallesEjercicio);
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


        [HttpDelete("DeleteDetallesEjercicio/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategorias(int id)
        {
            try
            {
                var response = await _detallesEjercicios.DeleteDetallesEjercicio(id);

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