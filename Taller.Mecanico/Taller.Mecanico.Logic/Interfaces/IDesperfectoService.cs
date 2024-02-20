using EntitiesDTO.DTO;

namespace Taller.Mecanico.Logic.Interfaces
{
    public interface IDesperfectoService
    {
        public DesperfectoDTO Get(int id);
        public IEnumerable<DesperfectoDTO> GetAll();
        public decimal Create(DesperfectoDTO entity);    
        public decimal Update(DesperfectoDTO entity);
    }
}
