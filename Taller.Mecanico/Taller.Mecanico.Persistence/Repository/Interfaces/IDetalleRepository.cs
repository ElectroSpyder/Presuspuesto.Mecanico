using EntitiesDTO.DTO;
using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IDetalleRepository
    {
        decimal Create(Detalle detalle);
        ICollection<DetalleDTO> GetAllByIdPresupuesto(int idPresupuesto);
    }
}
