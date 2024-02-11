
using Taller.Mecanico.Persistence.Repository.Interfaces;

namespace Taller.Mecanico.Persistence.UnitOfWork.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        public IVehiculoRepository vehiculolRepository { get; }
    }
}
