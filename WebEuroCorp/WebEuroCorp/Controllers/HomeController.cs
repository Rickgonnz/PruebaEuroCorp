using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebEuroCorp.Models;
using WebEuroCorp.Servicios;

namespace WebEuroCorp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServicioApi _servicioApi;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ServicioApi servicioApi)
        {
            _logger = logger;
            _servicioApi = servicioApi;
        }

        public async Task<IActionResult> Index()
        {
            List<AutorModel> autores = new List<AutorModel>();
            try
            {
                autores = await _servicioApi.GetAsync<List<AutorModel>>("Autor/ObtenerAutores");
            }
            catch (Exception ex)
            {
                ViewBag.Message = $"Error retrieving authors: {ex.Message}";
            }
            return View(autores);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
