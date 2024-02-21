using EntitiesDTO.DTO;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IReportesRepository
    {
        RepuestoMasUsadoDTO GetRepuestoMasUsado();
        IEnumerable<PromedioMarcaModeloDTO> GetPromedio();
        IEnumerable<TotalPorVehiculoDTO> GetTotalPorVehiculo();
    }
}
