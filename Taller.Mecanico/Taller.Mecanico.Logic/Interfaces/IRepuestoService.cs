
using EntitiesDTO.DTO;

namespace Taller.Mecanico.Logic.Interfaces
{
    public interface IRepuestoService
    {
        decimal Create(RepuestoDTO  repuesto);
        bool Delete(int id);
        public RepuestoDTO Get(int id);
        public IEnumerable<RepuestoDTO> GetAll();
        bool Update(RepuestoDTO repuesto);
    }
}
