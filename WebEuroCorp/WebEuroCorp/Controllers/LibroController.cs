using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebEuroCorp.Models;
using WebEuroCorp.Servicios;

namespace WebEuroCorp.Controllers
{
    public class LibroController : Controller
    {
        private readonly ServicioApi _servicioApi;
        public LibroController(ServicioApi servicioApi)
        {
            _servicioApi = servicioApi;
        }

        [HttpPost]
        public async Task<IActionResult> CrearLibro(LibroModel libroModel)
        {
            try
            {
                var response = await _servicioApi.PostAsync("Libro/Registrar", libroModel);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, mensaje = "Libro creado con éxito." });
                }
                else
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    return Json(new { success = false, mensaje = errorContent });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerLibrosPorAutor(string rut)
        {
            List<LibroModel> libros = new List<LibroModel>();
            try
            {
                libros = await _servicioApi.GetAsync<List<LibroModel>>("Libro/ObtenerLibrosPorAutor/" + rut);

                // Construir la tabla HTML
                StringBuilder sb = new StringBuilder();
                sb.Append("<table class='table table-bordered'><thead><tr>");
                sb.Append("<th>Título</th>");
                sb.Append("<th>Año</th>");
                sb.Append("<th>Género</th>");
                sb.Append("<th>Número de Páginas</th>");
                sb.Append("</tr></thead><tbody>");

                if (libros.Count > 0)
                {
                    foreach (var libro in libros)
                    {
                        sb.Append("<tr>");
                        sb.Append($"<td>{libro.Titulo}</td>");
                        sb.Append($"<td>{libro.Año}</td>");
                        sb.Append($"<td>{libro.Genero}</td>");
                        sb.Append($"<td>{libro.NumeroPaginas}</td>");
                        sb.Append("</tr>");
                    }
                }
                else
                {
                    sb.Append("<tr>");
                    sb.Append("<td colspan='4'>No existen libros aún.</td>");
                    sb.Append("</tr>");
                }

                sb.Append("</tbody></table>");

                return Json(new { success = true, data = sb.ToString() });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message });
            }
        }


    }
}
