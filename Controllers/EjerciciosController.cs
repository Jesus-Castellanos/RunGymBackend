using RunGym.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RunGym.Models;
using Microsoft.AspNetCore.Authorization;

namespace RunGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EjerciciosController : ControllerBase
    {
        private readonly IEjercicios _ejercicios;
        public EjerciciosController(IEjercicios ejercicios)
        {
            _ejercicios = ejercicios;
        }

        [HttpGet("GetEjercicios")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetEjercicios()
        {
            var response = await _ejercicios.GetEjercicios();
            return Ok(response);
        }

        [HttpGet("GetDetalles/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetDetalles(int id)
        {
            var response = await _ejercicios.GetDetalles(id);
            return Ok(response);
        }

        [HttpPost("PostEjercicios")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostEjercicios([FromBody] Ejercicios ejercicios)
        {
            try
            {
                var response = await _ejercicios.PostEjercicios(ejercicios);
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

        [HttpPut("PutEjercicios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutAdministrador([FromBody] Ejercicios ejercicios)
        {


            try
            {
                var response = await _ejercicios.PutEjercicios(ejercicios);
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


        [HttpDelete("DeleteEjercicios/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCategorias(int id)
        {
            try
            {
                var response = await _ejercicios.DeleteEjercicios(id);

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