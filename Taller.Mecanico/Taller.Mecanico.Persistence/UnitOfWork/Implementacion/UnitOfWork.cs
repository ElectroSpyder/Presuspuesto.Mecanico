
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Persistence.UnitOfWork.Implementacion
{
    public class UnitOfWork : IUnitOfWork
    {
        private  IUnitOfWorkAdapter? _unitOfWorkAdapter;
        public IUnitOfWorkAdapter Create()
        {
            _unitOfWorkAdapter = new UnitOfWorkAdapter();
            return _unitOfWorkAdapter;
        }

    }
}
