using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.Logic.Interfaces;

namespace Taller.Mecanico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RepuestoController : ControllerBase
    {
        private readonly IRepuestoService _service;

        public RepuestoController(IRepuestoService repuestoService)
        {
            _service = repuestoService;
        }

        [HttpGet("/Repuesto/GetAll")]
        public async Task<List<RepuestoDTO>> GetAll()
        {
            try
            {
                var result = _service.GetAll().ToList();
                List<RepuestoDTO> repuestoList = new List<RepuestoDTO>();
               
                await Task.Delay(100).ConfigureAwait(false);

                return repuestoList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
