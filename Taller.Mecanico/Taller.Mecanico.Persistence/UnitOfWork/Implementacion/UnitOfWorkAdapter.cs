using Microsoft.Data.SqlClient;
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
            try
            {
                _context = new SqlConnection(StringObjects.ConnectionString);
                if (_context.State == System.Data.ConnectionState.Closed)
                    _context.Open();

                _transaction = _context.BeginTransaction();

                Repositories = new UnitOfWorkRepository(_context, _transaction);
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Dispose transaction and if context close and dispose ther
        /// </summary>
        public void Dispose()
        {
            _transaction?.Dispose();
            

            if(_context != null)
            {
                _context.Close();
                _context.Dispose();
            }
        }

        /// <summary>
        /// Set Transaction commit
        /// </summary>
        public void SaveChanges()
        {
            _transaction.Commit();
        }
    }
}
