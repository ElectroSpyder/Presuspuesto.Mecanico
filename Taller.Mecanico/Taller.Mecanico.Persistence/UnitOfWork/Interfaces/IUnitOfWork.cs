
namespace Taller.Mecanico.Persistence.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
