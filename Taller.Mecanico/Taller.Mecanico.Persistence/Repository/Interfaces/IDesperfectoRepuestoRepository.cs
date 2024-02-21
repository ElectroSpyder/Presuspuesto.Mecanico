using EntitiesDTO.DTO;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IDesperfectoRepuestoRepository
    {
        ICollection<DesperfectoRepuestoDTO> GetAllDesperfectoRepuestoByIdDesperfecto(int idDesperfecto);
    }
}
