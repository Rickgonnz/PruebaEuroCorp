using ApiEuroCorp.Dtos;
using ApiEuroCorp.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiEuroCorp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibroController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        [HttpPost("Registrar")]
        public IActionResult RegistrarLibro([FromBody] LibroDTO libroDto)
        {
            try
            {
                var libroRegistrado = _libroService.RegistrarLibro(libroDto);
                return Ok(libroRegistrado);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ObtenerLibrosPorAutor/{autorRut}")]
        public IActionResult ObtenerLibrosPorAutor(string autorRut)
        {
            try
            {
                var libros = _libroService.ObtenerLibrosPorAutor(autorRut);
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
