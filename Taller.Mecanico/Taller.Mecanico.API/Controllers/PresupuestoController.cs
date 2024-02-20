using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.Logic.Interfaces;

namespace Taller.Mecanico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresupuestoController : Controller
    {
        private readonly IPresupuestoService _presupuestoService;
        private readonly IDesperfectoService _desperfectoService;
        private readonly IVehiculoService _vehiculoService;
        private readonly IRepuestoService _repuestoService;


        public PresupuestoController(IPresupuestoService presupuestoService, IDesperfectoService desperfectoService, IVehiculoService vehiculoService, IRepuestoService repuestoService)
        {
            _presupuestoService = presupuestoService;
            _desperfectoService = desperfectoService;
            _vehiculoService = vehiculoService;
            _repuestoService = repuestoService;
        }
        // POST: AutomovilController/Create
        [HttpPost("/presupuesto/CrearPresupuesto")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PresupuestoDTO>> Create(Request request)
        {
            try
            {
                //0 inicializar el presupuesto
                var presupuesto = new PresupuestoDTO
                {
                     Nombre = request.Nombre,
                     Apellido = request.Apellido,
                     Email = request.Email,
                     Total = 0
                };


                //1_ existe vehiculo?
                var vehiculos = _vehiculoService.GetAll();
                var vehiculo = vehiculos
                    .FirstOrDefault(x => x.Id == request.VehiculoId 
                                        && x.Patente.Trim() == request.Patente.Trim() 
                                        && x.TipoVehiculo.Trim() == request.TipoVehiculo.Trim());
                if (vehiculo == null) return NotFound(request.Patente);

                presupuesto.Vehiculo = vehiculo;

                //2_ existen desperfectos
                foreach (var desperfecto in request.Desperfectos)
                {
                    var desperperfectoDTO = _desperfectoService.Get(desperfecto.Id);
                                        
                    if ( desperperfectoDTO == null) return NotFound("No existe el desperefecto");

                    //3_ si existen repuestos
                    foreach (var repuesto in desperfecto.Repuestos)
                    {
                        var repuestoDTO = _repuestoService.Get(repuesto.Id);
                        if ( repuestoDTO == null) return NotFound("no se encuentran repuestos");
                        
                        desperperfectoDTO.Repuestos.Add(repuestoDTO);
                    }

                    presupuesto.Desperfectos.Add(desperperfectoDTO);
                }

                var respoonse = _presupuestoService.Create(presupuesto);

                await Task.Delay(100).ConfigureAwait(false);

                return Ok(respoonse);

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           
        }
    }
}
