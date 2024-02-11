using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Persistence.Repository.Interfaces
{
    public interface IMotoRepository
    {
        void Create(Moto moto);
        void Delete(int id);
        public Moto Get(int id);
        public IEnumerable<Moto> GetAll();
        void Update(Moto moto);
    }
}
