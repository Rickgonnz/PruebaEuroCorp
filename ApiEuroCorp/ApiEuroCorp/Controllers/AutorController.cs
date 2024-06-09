using ApiEuroCorp.Dtos;
using ApiEuroCorp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEuroCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService _autorService;

        public AutorController(IAutorService autorService)
        {
            _autorService = autorService;
        }

        [HttpPost("Registrar")]
        public IActionResult RegistrarAutor([FromBody] AutorDTO autorDto)
        {
            try
            {
                var autorRegistrado = _autorService.RegistrarAutor(autorDto);
                return Ok(autorRegistrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("ObtenerAutorPorRut/{rut}")]
        public IActionResult ObtenerAutorPorRut(string rut)
        {
            try
            {
                var autor = _autorService.ObtenerAutorPorRut(rut);
                return Ok(autor);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpGet("ObtenerAutores")]
        public IActionResult ObtenerAutores()
        {
            try
            {
                var autores = _autorService.ObtenerAutores();
                return Ok(autores);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
