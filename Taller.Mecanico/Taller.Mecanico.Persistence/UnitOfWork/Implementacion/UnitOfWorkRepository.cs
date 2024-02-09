using System.Data.SqlClient;
using Taller.Mecanico.Persistence.Repository.Implementacion;
using Taller.Mecanico.Persistence.Repository.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Persistence.UnitOfWork.Implementacion
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public UnitOfWorkRepository(SqlConnection context, SqlTransaction _transaction)
        {
            automovilRepository = new AutomovilRepository(context, _transaction);
        }

        public IAutomovilRepository automovilRepository { get; }
    }
}
