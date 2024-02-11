using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;

namespace Taller.Mecanico.UI.Controllers
{
    public class VehiculoController : Controller
    {
        private readonly IVehiculoService _service;

        public VehiculoController(IVehiculoService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var model = new VehiculoDTO();

            return View(model);
        }

        //public IActionResult CreateAutomovil()
        //{

        //}
    }
}
