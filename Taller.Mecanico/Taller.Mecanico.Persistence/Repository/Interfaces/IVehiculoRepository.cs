using EntitiesDTO.DTO;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IVehiculoRepository
    {
        decimal Create(VehiculoDTO vehiculo);
        decimal Delete(int id);
        public VehiculoDTO Get(int id);
        public IEnumerable<VehiculoDTO> GetAll();
        decimal Update(VehiculoDTO vehiculo);
    }
}
