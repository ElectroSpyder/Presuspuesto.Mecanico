using Microsoft.Data.SqlClient;

namespace Taller.Mecanico.Persistence.Repository
{
    public abstract class BaseRepository
    {
        protected SqlConnection _context;
        protected SqlTransaction _transaction;

        protected SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _context, _transaction);
        }
    }
}
