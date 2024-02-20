using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.Logic.Interfaces;

namespace Taller.Mecanico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutomovilController : ControllerBase
    {
        private readonly IAutomovilService _service;

        public AutomovilController(IAutomovilService service)
        {
            _service = service;
        }

        [HttpGet("/Automovil/GetAll")]
        public async Task<List<AutomovilDTO>> GetAll() {
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

        // POST: AutomovilController/Create
        [HttpPost("/automovil/PostModelo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AutomovilDTO>> Create(AutomovilRequest automovil)
        {
            var result = _service.Create(automovil);
            await Task.Delay(100).ConfigureAwait(false);
            return Ok(result);
        }

    }
}
