using Taller.Mecanico.EntitiesDTO.DTO;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IVehiculoRepository
    {
        void Create(VehiculoDTO vehiculo);
        void Delete(int id);
        public VehiculoDTO Get(int id);
        public IEnumerable<VehiculoDTO> GetAll();
        void Update(VehiculoDTO vehiculo);
    }
}
