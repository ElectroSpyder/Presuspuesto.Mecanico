using EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Logic.Implementacion
{
    public class AutomovilService : IAutomovilService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AutomovilService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public decimal Create(AutomovilRequest entity)
        {
            try
            {
                var createVehiculo = 0m;
                var vehiculoDTO = Auxiliar.MapAutomovilToVehiculo(entity);
                using (var context = _unitOfWork.Create())
                {
                    createVehiculo = context.Repositories.vehiculolRepository.Create(vehiculoDTO);
                    if(createVehiculo > 0 ) context.SaveChanges();
                }
                return createVehiculo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public AutomovilDTO Get(int id)
        {
            var vehiculoDTO = new VehiculoDTO();

            using (var context = _unitOfWork.Create())
            {
                vehiculoDTO = context.Repositories.vehiculolRepository.Get(id);
            }
            if (vehiculoDTO != null)
                return Auxiliar.MapVehiculoToAutomovil(vehiculoDTO);

            return new AutomovilDTO();
        }

        public IEnumerable<AutomovilDTO> GetAll()
        {
            var vehiculoList = new List<VehiculoDTO>();
            var automovilList = new List<AutomovilDTO>();

            using (var context = _unitOfWork.Create())
            {
                vehiculoList = context.Repositories.vehiculolRepository.GetAll().ToList();
            }
            if(vehiculoList.Count > 0)
                foreach (var item in vehiculoList)
                {
                    automovilList.Add(Auxiliar.MapVehiculoToAutomovil(item));
                }

            return automovilList;
        }
    }
}
