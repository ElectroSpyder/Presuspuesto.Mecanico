using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IDesperfectoRepository
    {
        decimal Create(Desperfecto desperfecto);
        void Delete(int id);
        public Desperfecto Get(int id);
        public IEnumerable<Desperfecto> GetAll();
        void Update(Desperfecto desperfecto);
    }
}
