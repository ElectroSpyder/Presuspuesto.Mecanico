using EntitiesDTO.DTO;

namespace Taller.Mecanico.Logic.Interfaces
{
    public interface IReporteService
    {
        RepuestoMasUsadoDTO GetRepuestoMasUsado();
        IEnumerable<PromedioMarcaModeloDTO> GetPromedio();
        IEnumerable<TotalPorVehiculoDTO> GetTotalPorVehiculo();
    }
}
