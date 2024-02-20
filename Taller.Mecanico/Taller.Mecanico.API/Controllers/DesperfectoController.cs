using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.Logic.Interfaces;

namespace Taller.Mecanico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DesperfectoController : ControllerBase
    {
        private readonly IDesperfectoService _service;

        public DesperfectoController(IDesperfectoService desperfectoService)
        {
            _service = desperfectoService;
        }

        [HttpGet("/Desperfecto/GetAll")]
        public async Task<List<DesperfectoDTO>> GetAll()
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
                
        [HttpPost("/Desperfecto/PostModelo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DesperfectoDTO>> Create(DesperfectoDTO desperfecto)
        {
            try
            {
                var result = _service.Create(desperfecto);
                await Task.Delay(100).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost("/DesperfectoPutModelo")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DesperfectoDTO>> Update(DesperfectoDTO desperfecto)
        {
            try
            {
                var result = _service.Update(desperfecto);
                await Task.Delay(100).ConfigureAwait(false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

    }
}
