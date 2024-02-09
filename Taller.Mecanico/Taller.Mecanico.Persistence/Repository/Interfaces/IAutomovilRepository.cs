using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IAutomovilRepository
    {
        void Create(Automovil automovil);
        void Delete(int id);
        public Automovil Get(int id);
        public IEnumerable<Automovil> GetAll();
        void Update(Automovil automovil);
    }
}
