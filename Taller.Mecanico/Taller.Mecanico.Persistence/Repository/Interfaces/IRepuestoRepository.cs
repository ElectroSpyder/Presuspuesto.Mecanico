using EntitiesDTO.DTO;
using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IRepuestoRepository
    {
        decimal Create(RepuestoDTO repuesto);
        decimal Delete(int id);
        public RepuestoDTO Get(int id);
        public IEnumerable<RepuestoDTO> GetAll();
        decimal Update(RepuestoDTO repuesto);
    }
}
