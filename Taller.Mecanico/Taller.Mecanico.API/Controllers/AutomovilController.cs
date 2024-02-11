using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;

namespace Taller.Mecanico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomovilController : ControllerBase
    {
        private readonly IVehiculoService _service;

        public AutomovilController(IVehiculoService service)
        {
            _service = service;
        }

        //// POST: AutomovilController/Create
        //[HttpPost("/automovil/PostModelo")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult<VehiculoDTO>> Create(VehiculoDTO vehiculo)
        //{
        //    var result = _service.       
        //}

        [HttpGet("/Automovil/GetAll")]
        public async Task<List<VehiculoDTO>> GetAll() {
            try
            {
                var result = _service.GetAll().ToList();

                await Task.Delay(100).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
           

        }
    }
}
