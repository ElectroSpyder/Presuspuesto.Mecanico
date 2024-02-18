using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IRepuestoRepository
    {
        decimal Create(Repuesto repuesto);
        decimal Delete(int id);
        public Repuesto Get(int id);
        public IEnumerable<Repuesto> GetAll();
        decimal Update(Repuesto repuesto);
    }
}
