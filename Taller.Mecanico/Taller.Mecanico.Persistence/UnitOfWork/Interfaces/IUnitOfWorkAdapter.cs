//https://www.youtube.com/watch?v=FZozGfArJTc
namespace Taller.Mecanico.Persistence.UnitOfWork.Interfaces
{
    /// <summary>
    /// Connect to dataBase and Acess to repository
    /// </summary>
    public interface IUnitOfWorkAdapter : IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }
        void SaveChanges();
    }
}
