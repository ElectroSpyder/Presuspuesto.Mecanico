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
            var createPresupuesto = 0m;
            using (var context = _unitOfWork.Create())
            {
                createPresupuesto = context.Repositories.presupuestoRepository.Create(entity);
                
                if (createPresupuesto < 1) context.Dispose();
                context.SaveChanges();
            }
            return createPresupuesto;
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
                    if (updateDesperfecto < 1) context.Dispose();
                }
                if (!result) throw new Exception("Error al actualiza un desperfecto");

                updatePresupuesto = context.Repositories.presupuestoRepository.Update(entity);
                if (updatePresupuesto > 0) context.SaveChanges();
            }

            return updatePresupuesto;
        }
    }
}
