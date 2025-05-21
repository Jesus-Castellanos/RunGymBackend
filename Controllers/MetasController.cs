using RunGym.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RunGym.Models;
using Microsoft.AspNetCore.Authorization;

namespace RunGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MetasController : ControllerBase
    {
        private readonly IMetas _metas;

        public MetasController(IMetas metas)
        {
            _metas = metas;
        }

        [HttpGet("GetMetas")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> GetMetas()
        {
            var response = await _metas.GetMetas();
            return Ok(response);
        }

        [HttpPost("PostMetas")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostMetas([FromBody] Metas metas)
        {
            try
            {
                var response = await _metas.PostMetas(metas);
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
        [HttpPut("PutMetas/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> PutMetas(int id, [FromBody] Metas metas)
        {
            if (id != metas.Id)
            {
                return BadRequest("El ID de la meta no coincide.");
            }

            try
            {
                var response = await _metas.PutMetas(metas);
                if (response)
                    return Ok("Actualizado correctamente");
                else
                    return NotFound("Metas no encontradas");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("DeleteMetas/{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> DeleteMetas(Metas metas)
        {
            try
            {
                var response = await _metas.DeleteMetas(metas);
                if (response)
                    return NoContent();
                else
                    return NotFound("Metas no encontradas");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}