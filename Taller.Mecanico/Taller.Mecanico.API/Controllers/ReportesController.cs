using EntitiesDTO.DTO;
using Microsoft.AspNetCore.Mvc;
using Taller.Mecanico.Logic.Interfaces;

namespace Taller.Mecanico.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportesController : Controller
    {
        private readonly IReporteService _service;
        public ReportesController(IReporteService reporteService)
        {
            this._service = reporteService;
        }


        [HttpGet("/reporte/GetRepuestoMasUsado")]
        public async Task<RepuestoMasUsadoDTO> GetRepuestoMasUsado()
        {
            try
            {
                var result = _service.GetRepuestoMasUsado();

                await Task.Delay(100).ConfigureAwait(false);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet("/reporte/GetPromedio")]
        public async Task<List<PromedioMarcaModeloDTO>> GetPromedio()
        {
            try
            {
                var result = _service.GetPromedio();

                await Task.Delay(100).ConfigureAwait(false);

                return result.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }


        [HttpGet("/reporte/GetTotalPorVehiculo")]
        public async Task<List<TotalPorVehiculoDTO>> GetTotalPorVehiculo()
        {
            try
            {
                var result = _service.GetTotalPorVehiculo();

                await Task.Delay(100).ConfigureAwait(false);

                return result.ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
