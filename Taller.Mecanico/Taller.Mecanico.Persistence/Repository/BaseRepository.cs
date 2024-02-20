using Microsoft.Data.SqlClient;
using System.Data;

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

        ///// <summary>
        ///// Execute command and its Ok? commit
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //protected object ExecuteCommandScalar(SqlCommand command) {
        //   var result = command.ExecuteScalar();
        //    //if(result != null)
        //        //_transaction.Commit();
                
        //    return result;
            
        //}

        //protected SqlDataAdapter ExecuteCommandAdapter(SqlCommand command)
        //{            
        //    SqlDataAdapter adapter = new SqlDataAdapter(command);
        //    return adapter;
            
        //}
    }
}
