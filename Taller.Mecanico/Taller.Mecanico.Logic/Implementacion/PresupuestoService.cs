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
                
                foreach (var desperfecto in entity.Desperfectos)
                {
                    var detalle =
                        new DetalleDTO
                        {
                            DesperfectoId = desperfecto.Id,
                            PresupuestoId = (int)presupuestoId
                        };

                    var detalleId = context.Repositories.detalleRepository.Create(Auxiliar.MapDtoToDetalle(detalle));
                    
                    if (detalleId < 1) throw new Exception();
                }
                context.SaveChanges();
                
            }
            return presupuestoId;
        }

       
        public PresupuestoDTO Get(int id)
        {
            try
            {
                using var context = _unitOfWork.Create();

                var result = context.Repositories.presupuestoRepository.Get(id);

                return result;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<PresupuestoDTO> GetAll()
        {
            try
            {
                List<PresupuestoDTO> presupuestoList = [];
                List<DetalleDTO> detalleList = [];
                
                using var context = _unitOfWork.Create();

                var presupuestos = context.Repositories.presupuestoRepository.GetAll().ToList();

                foreach (var presupuesto in presupuestos)
                {
                    var presupuestoDTO = new PresupuestoDTO();
                    presupuestoDTO = presupuesto;

                    presupuestoDTO.Detalle = context.Repositories.detalleRepository.GetAllByIdPresupuesto(presupuesto.Id).ToList();

                    if (presupuestoDTO.Detalle.Count > 0)
                    {
                        foreach (var detalle in presupuestoDTO.Detalle)
                        {
                            DesperfectoDTO desperfecto = new();
                            desperfecto = context.Repositories.desperfectoRepository.Get(detalle.DesperfectoId);

                            var desperfectoRepuestosList = context.Repositories.desperfectoRepuestoRepository.GetAllDesperfectoRepuestoByIdDesperfecto(desperfecto.Id).ToList();

                            foreach (var desperfectoRepuesto in desperfectoRepuestosList)
                            {
                                var repuesto = context.Repositories.repuestoRepository.Get(desperfectoRepuesto.RepuestosId);
                                desperfecto.Repuestos.Add(repuesto);
                            }

                            presupuestoDTO.Desperfectos.Add(desperfecto);
                        }
                    }
                    
                    presupuestoList.Add(presupuestoDTO);
                }
                
                return presupuestoList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public decimal Update(PresupuestoDTO entity)
        {
            var presupuestoId = 0m;
            using (var context = _unitOfWork.Create())
            {
                var result = false;
                foreach (var item in entity.Desperfectos)
                {
                    var updateDesperfecto = context.Repositories.desperfectoRepository.Update(item);
                    
                    result = true;
                }
                if (!result) throw new Exception("Error al actualiza un desperfecto");

                presupuestoId = context.Repositories.presupuestoRepository.Update(entity);
                if (presupuestoId > 0) context.SaveChanges();
                
            }

            return presupuestoId;
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
