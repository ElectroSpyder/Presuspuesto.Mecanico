using Microsoft.Data.SqlClient;
using Taller.Mecanico.Persistence.Repository.Implementacion;
using Taller.Mecanico.Persistence.Repository.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Persistence.UnitOfWork.Implementacion
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public UnitOfWorkRepository(SqlConnection context, SqlTransaction _transaction)
        {
            vehiculolRepository = new VehiculoRepository(context, _transaction);
            desperfectoRepository = new DesperfectoRepository(context, _transaction);
            repuestoRepository = new RepuestoRepository(context, _transaction);
            presupuestoRepository = new PresupuestoRepository(context, _transaction);
            detalleRepository = new DetalleRepository(context, _transaction);
            desperfectoRepuestoRepository = new DesperfectoRepuestoRepository(context, _transaction);
        }

        public IVehiculoRepository vehiculolRepository { get; }
        public IDesperfectoRepository desperfectoRepository { get; }
        public IRepuestoRepository repuestoRepository { get; }
        public IPresupuestoRepository presupuestoRepository { get; }
        public IDetalleRepository detalleRepository { get; }

        public IDesperfectoRepuestoRepository desperfectoRepuestoRepository { get; }
    }
}
