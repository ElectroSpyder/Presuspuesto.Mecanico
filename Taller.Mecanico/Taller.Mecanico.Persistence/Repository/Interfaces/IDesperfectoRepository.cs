using EntitiesDTO.DTO;
using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IDesperfectoRepository
    {
        decimal Create(DesperfectoDTO desperfecto);
        decimal Delete(int id);
        public DesperfectoDTO Get(int id);
        public IEnumerable<DesperfectoDTO> GetAll();
        int Update(DesperfectoDTO desperfecto);
    }
}
