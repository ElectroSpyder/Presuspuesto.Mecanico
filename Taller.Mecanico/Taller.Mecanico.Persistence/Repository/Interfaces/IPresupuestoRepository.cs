using EntitiesDTO.DTO;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IPresupuestoRepository
    {
        decimal Create(PresupuestoDTO presupuesto);
        decimal Delete(int id);
        public PresupuestoDTO Get(int id);
        public IEnumerable<PresupuestoDTO> GetAll();
        decimal Update(PresupuestoDTO  presupuesto);
    }
}
