using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.UI.Auxiliar;
using Taller.Mecanico.UI.Models;

namespace Taller.Mecanico.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPresupuestoService _presupuestoService;
        private readonly IDesperfectoService _desperfectoService;
        private readonly IVehiculoService _vehiculoService;
        public HomeController(ILogger<HomeController> logger, IPresupuestoService presupuestoService, IDesperfectoService desperfectoService, IVehiculoService vehiculoService)
        {
            _logger = logger;
            _presupuestoService = presupuestoService;
            _desperfectoService = desperfectoService;
            _vehiculoService = vehiculoService;
        }

        public IActionResult Index()
        {
            var model = new Request();
            model.VehiculoDTO = new VehiculoDTO();
            model.DesperfectoDTOs = new List<DesperfectoDTO>();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult BuscarPatente(string patente)
        {
            try
            {
                Request request = new Request();

                if (string.IsNullOrEmpty(patente)) return View();

                var model = new VehiculoDTO();
                var vehiculoList = _vehiculoService.GetAll();

                foreach (var vehiculo in vehiculoList)
                {
                    if (vehiculo.Patente == patente)
                    {
                        request.VehiculoDTO= vehiculo;
                        HttpContext.Session.SetObjectAsJson<Request>("request", request);
                        break;
                    }
                }

                List<DesperfectoDTO> desperfectosList = _desperfectoService.GetAll().ToList();
                ViewBag.DesperfectoList = desperfectosList;

                return View("Panel", request);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult CargarVehiculo(VehiculoDTO vehiculo)
        {
            try
            {
                var result = _vehiculoService.Create(vehiculo);
                return Json(result);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
