using EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Logic.Implementacion
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public VehiculoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public decimal Create(VehiculoDTO entity)
        {
            using (var context = _unitOfWork.Create())
            {
                return context.Repositories.vehiculolRepository.Create(entity);
            }
        }
        public VehiculoDTO Get(int id)
        {
            var vehiculo = new VehiculoDTO();

            using(var context = _unitOfWork.Create())
            {
                vehiculo = context.Repositories.vehiculolRepository.Get(id);                
            }
            return vehiculo;
        }

        public IEnumerable<VehiculoDTO> GetAll()
        {
            var vehiculoList = new List<VehiculoDTO>();
            using (var context = _unitOfWork.Create())
            {
                vehiculoList = context.Repositories.vehiculolRepository.GetAll().ToList();
            }
            return vehiculoList;
        }
    }
}
