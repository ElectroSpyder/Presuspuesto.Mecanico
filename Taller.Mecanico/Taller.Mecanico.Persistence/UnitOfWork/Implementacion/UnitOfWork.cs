
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Persistence.UnitOfWork.Implementacion
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUnitOfWorkAdapter Create()
        {
            return new UnitOfWorkAdapter();
        }

        public void SaveChanges()
        {
            var adapter = new UnitOfWorkAdapter();
            adapter.SaveChanges();
        }
    }
}
