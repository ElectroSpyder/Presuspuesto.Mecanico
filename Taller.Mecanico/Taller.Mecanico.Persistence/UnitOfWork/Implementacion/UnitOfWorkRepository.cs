using System.Data.SqlClient;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Persistence.UnitOfWork.Implementacion
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public UnitOfWorkRepository(SqlConnection context, SqlTransaction _transaction)
        {
            
        }
    }
}
