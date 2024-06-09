using Microsoft.AspNetCore.Mvc;
using WebEuroCorp.Models;
using WebEuroCorp.Servicios;

namespace WebEuroCorp.Controllers
{
    public class AutorController : Controller
    {
        private readonly ServicioApi _servicioApi;
        public AutorController(ServicioApi servicioApi)
        {
            _servicioApi = servicioApi;
        }
        [HttpPost]
        public async Task<IActionResult> CrearAutor(AutorModel autorModel)
        {
            try
            {
                // Envía los datos del autor al método de la API para crear un nuevo autor
                var response = await _servicioApi.PostAsync("Autor/Registrar", autorModel);
                if (response.IsSuccessStatusCode)
                {
                    return Json(new { success = true, mensaje = "Autor creado con éxito." });
                }
                else
                {
                    return Json(new { success = false, mensaje = response.ReasonPhrase });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> ObtenerAutores()
        {
            List<AutorModel> autores = new List<AutorModel>();
            try
            {
                autores = await _servicioApi.GetAsync<List<AutorModel>>("Autor/ObtenerAutores");
                return Json(new { success = true, data = autores });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, mensaje = ex.Message });
            }
        }
    }
}
