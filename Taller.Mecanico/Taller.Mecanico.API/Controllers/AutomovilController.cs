using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntitiesDTO.DTO;
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

        [HttpGet("/Automovil/GetAll")]
        public async Task<List<AutomovilDTO>> GetAll() {
            try
            {
                var result = _service.GetAll().ToList();
                List<AutomovilDTO> automovilList = new List<AutomovilDTO>();
                foreach (var item in result)
                {
                    automovilList.Add(Auxiliar.MapVehiculoToAutomovil(item));
                }
                await Task.Delay(100).ConfigureAwait(false);

                return automovilList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            } 
        }

        // POST: AutomovilController/Create
        [HttpPost("/automovil/PostModelo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AutomovilDTO>> Create(AutomovilDTO automovil)
        {
            var result = _service.Create(Auxiliar.MapAutomovilToVehiculo(automovil));
            await Task.Delay(100).ConfigureAwait(false);
            return Ok(result);
        }

    }
}
