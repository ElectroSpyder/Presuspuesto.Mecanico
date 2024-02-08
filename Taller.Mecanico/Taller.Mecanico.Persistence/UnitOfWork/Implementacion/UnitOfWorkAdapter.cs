using System.Data.SqlClient;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Persistence.UnitOfWork.Implementacion
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        private SqlConnection _context {  get; set; }
        private SqlTransaction _transaction { get; set; }
        public IUnitOfWorkRepository  Repositories { get; set; }

        public UnitOfWorkAdapter()
        {
            _context = new SqlConnection(Parameters.ConnectionString);
            _context.Open();

            _transaction = _context.BeginTransaction();

            Repositories = new UnitOfWorkRepository(_context, _transaction);
        }
        public void Dispose()
        {
            if(_transaction != null )
                _transaction.Dispose();
            

            if(_context != null)
            {
                _context.Close();
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}
