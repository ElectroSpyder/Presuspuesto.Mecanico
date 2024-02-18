
namespace Taller.Mecanico.Persistence.UnitOfWork.Interfaces
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
        //void SaveChanges();
        //void Dispose();
    }
}
