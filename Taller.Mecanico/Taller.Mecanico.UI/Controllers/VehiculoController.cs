using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.Logic.Implementacion;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.UI.Auxiliar;

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

        [HttpPost]
        [AllowAnonymous]
        public IActionResult BuscarPatente(string patente)
        {
            try
            {
                if (string.IsNullOrEmpty(patente)) return View();

                var model = new VehiculoDTO();
                var vehiculoList = _service.GetAll();

                foreach (var vehiculo in vehiculoList)
                {
                    if(vehiculo.Patente == patente)
                    {
                        model = vehiculo;
                        HttpContext.Session.SetObjectAsJson<VehiculoDTO>("vehiculo", model);
                        break;
                    }
                }
                if (model.TipoVehiculo.Trim() == "Auto")
                {                   
                    return RedirectToAction("GoAutomovil");
                }
                else
                {
                    return RedirectToAction("GoMoto");
                }
                    
               
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IActionResult GoAutomovil()
        {
            return LocalRedirect("/Automovil/Index");
        }

        public IActionResult GoMoto()
        {
            return LocalRedirect("/Moto/Index");
        }
    }
}
