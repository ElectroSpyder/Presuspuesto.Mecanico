using EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Logic.Implementacion
{
    public class MotoService : IMotoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MotoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public decimal Create(MotoRequest entity)
        {
            try
            {
                var createVehiculo = 0m;
                var vehiculoDTO = Auxiliar.MapMotoToVehiculo(entity);
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

        public MotoDTO Get(int id)
        {
            var vehiculoDTO = new VehiculoDTO();

            using (var context = _unitOfWork.Create())
            {
                vehiculoDTO = context.Repositories.vehiculolRepository.Get(id);
            }
            if (vehiculoDTO != null)
                return Auxiliar.MapVehiculoToMoto(vehiculoDTO);

            return new MotoDTO();
        }

        public IEnumerable<MotoDTO> GetAll()
        {
            var vehiculoList = new List<VehiculoDTO>();
            var motoList = new List<MotoDTO>();

            using (var context = _unitOfWork.Create())
            {
                vehiculoList = context.Repositories.vehiculolRepository.GetAll().ToList();
            }
            if(vehiculoList.Count > 0)
                foreach (var item in vehiculoList)
                {
                    if(item.TipoVehiculo.Trim() == "Moto")
                        motoList.Add(Auxiliar.MapVehiculoToMoto(item));
                }

            return motoList;
        }
    }
}
