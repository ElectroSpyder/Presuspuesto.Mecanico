using Taller.Mecanico.EntitiesDTO.DTO;

namespace Taller.Mecanico.Logic.Interfaces
{
    public interface IVehiculoService
    {
        public VehiculoDTO Get(int id);
        public IEnumerable<VehiculoDTO> GetAll();
    }
}
