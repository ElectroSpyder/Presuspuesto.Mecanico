using EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Logic.Implementacion
{
    public class PresupuestoService : IPresupuestoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PresupuestoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public decimal Create(PresupuestoDTO entity)
        {
            var presupuestoId = 0m;
            entity.Total = CalculoTotal(entity);

            using (var context = _unitOfWork.Create())
            {
                presupuestoId = context.Repositories.presupuestoRepository.Create(entity);
                entity.Vehiculo.PresupuestoId = (int)presupuestoId;
                var vehiculoUpdate = context.Repositories.vehiculolRepository.Update(entity.Vehiculo);
                
                if (vehiculoUpdate < 1) throw new Exception();

                foreach (var desperfecto in entity.Desperfectos)
                {
                    desperfecto.PresupuestoId = (int)presupuestoId;

                    var desperfectoId = context.Repositories.desperfectoRepository.Update(Auxiliar.MapDtoToDesperfecto(desperfecto));
                    if (desperfectoId < 1) throw new Exception();
                }
                context.SaveChanges();
                
            }
            return presupuestoId;
        }

       
        public PresupuestoDTO Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PresupuestoDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public decimal Update(PresupuestoDTO entity)
        {
            var updatePresupuesto = 0m;
            using (var context = _unitOfWork.Create())
            {
                var result = false;
                foreach (var item in entity.Desperfectos)
                {
                    var updateDesperfecto = context.Repositories.desperfectoRepository.Update(Auxiliar.MapDtoToDesperfecto(item));
                    
                    result = true;
                }
                if (!result) throw new Exception("Error al actualiza un desperfecto");

                updatePresupuesto = context.Repositories.presupuestoRepository.Update(entity);
                
            }

            return updatePresupuesto;
        }

        #region Calculos
        private decimal CalculoTotal(PresupuestoDTO entity)
        {
            try
            {
                decimal subtotal = 0;

                foreach (var desperfecto in entity.Desperfectos)
                {
                    decimal subtotalRepuesto = 0;
                    var calculoDesperfecto = desperfecto.ManoDeObra + 130 * desperfecto.Tiempo;

                    subtotal += calculoDesperfecto;

                    foreach (var repuesto in desperfecto.Repuestos)
                    {
                        subtotalRepuesto += repuesto.Precio;
                    }
                    subtotal += subtotalRepuesto;
                }
                if(entity.Recargos != null)
                    subtotal += entity.Recargos.Sum();

                subtotal += 0.1m * subtotal;
                return subtotal;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}
