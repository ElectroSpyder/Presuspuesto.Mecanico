using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.Logic.Interfaces;

namespace Taller.Mecanico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MotosController : Controller
    {
        private readonly IMotoService _service;

        public MotosController(IMotoService service)
        {
            this._service = service;
        }

        [HttpGet("/moto/GetAll")]
        public async Task<List<MotoDTO>> GetAll()
        {
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
              
        [HttpPost("/moto/PostModelo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<MotoDTO>> Create(MotoRequest motoRequest)
        {
            var result = _service.Create(motoRequest);
            await Task.Delay(100).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
