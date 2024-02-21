using EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Models.Entities;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Logic.Implementacion
{    
    public class DesperfectoService : IDesperfectoService
    {
        private readonly IUnitOfWork _unitOFWork;

        public DesperfectoService(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }

        public decimal Create(DesperfectoDTO entity)
        {
            var result = 0m;
            //Desperfecto desperfecto = Auxiliar.MapDtoToDesperfecto(entity);
            using (var context = _unitOFWork.Create())
            {
                result = context.Repositories.desperfectoRepository.Create(entity);
                if (result > 0) context.SaveChanges();
            }
            return result;
        }
        public DesperfectoDTO Get(int id)
        {
            var desperfecto = new DesperfectoDTO();

            using (var context = _unitOFWork.Create())
            {
                desperfecto = context.Repositories.desperfectoRepository.Get(id);
            }
            return desperfecto;
            
        }

        public IEnumerable<DesperfectoDTO> GetAll()
        {
            var desperfectoList = new List<DesperfectoDTO>();
            var dtoList = new List<DesperfectoDTO>();

            using (var context = _unitOFWork.Create())
            {
                desperfectoList = context.Repositories.desperfectoRepository.GetAll().ToList();
            }

            if (desperfectoList.Count > 0)
                foreach (var item in desperfectoList)
                {
                    dtoList.Add(item);
                }

            return dtoList;
        }

        public decimal Update(DesperfectoDTO entity)
        {
            try
            {
                var desperfectoId = 0m;
                using(var context = _unitOFWork.Create())
                {
                    desperfectoId= context.Repositories.desperfectoRepository.Update(entity);
                    if (desperfectoId > 0) context.SaveChanges();
                }

                return desperfectoId;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
