using RunGym.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RunGym.Models;
using Microsoft.AspNetCore.Authorization;

namespace RunGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ComidasController : ControllerBase
    {
        private readonly IComidas _comidas;

        public ComidasController(IComidas comidas)
        {
            _comidas = comidas;
        }

        [HttpGet("GetComidas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetComidas()
        {
            var response = await _comidas.GetComidas();
            return Ok(response);
        }

        [HttpPost("PostComidas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostComidas([FromBody] Comidas comidas)
        {
            try
            {
                var response = await _comidas.PostComidas(comidas);
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
        [HttpPut("PutComidas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> PutComidas(int id, [FromBody] Comidas comidas)
        {
            if (id != comidas.Id)
            {
                return BadRequest("El ID de la comida no coincide.");
            }

            try
            {
                var response = await _comidas.PutComidas(comidas);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Comida no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeleteComidas/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteComidas(Comidas comidas )
        {
            try
            {
                var response = await _comidas.DeleteComidas(comidas);
                if (response)
                    return NoContent(); 
                else
                    return NotFound("Comida no encontrada");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}





