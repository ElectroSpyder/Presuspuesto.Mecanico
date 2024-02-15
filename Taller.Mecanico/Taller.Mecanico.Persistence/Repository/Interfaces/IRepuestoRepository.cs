using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IRepuestoRepository
    {
        decimal Create(Repuesto repuesto);
        bool Delete(int id);
        public Repuesto Get(int id);
        public IEnumerable<Repuesto> GetAll();
        bool Update(Repuesto repuesto);
    }
}
