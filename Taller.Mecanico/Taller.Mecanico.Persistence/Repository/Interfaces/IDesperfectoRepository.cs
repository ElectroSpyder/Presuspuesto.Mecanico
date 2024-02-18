using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IDesperfectoRepository
    {
        decimal Create(Desperfecto desperfecto);
        decimal Delete(int id);
        public Desperfecto Get(int id);
        public IEnumerable<Desperfecto> GetAll();
        decimal Update(Desperfecto desperfecto);
    }
}
