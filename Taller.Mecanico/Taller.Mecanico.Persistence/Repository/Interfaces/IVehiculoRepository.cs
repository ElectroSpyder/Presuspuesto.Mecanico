using EntitiesDTO.DTO;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IVehiculoRepository
    {
        bool Create(VehiculoDTO vehiculo);
        bool Delete(int id);
        public VehiculoDTO Get(int id);
        public IEnumerable<VehiculoDTO> GetAll();
        bool Update(VehiculoDTO vehiculo);
    }
}
