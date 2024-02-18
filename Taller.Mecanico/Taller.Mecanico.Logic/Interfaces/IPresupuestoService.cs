using EntitiesDTO.DTO;

namespace Taller.Mecanico.Logic.Interfaces
{
    public interface IPresupuestoService
    {
        public PresupuestoDTO Get(int id);
        public IEnumerable<PresupuestoDTO> GetAll();
        public decimal Create(PresupuestoDTO entity);
        public decimal Update(PresupuestoDTO entity);
    }
}
