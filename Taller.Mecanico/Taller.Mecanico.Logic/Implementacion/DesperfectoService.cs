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
            Desperfecto desperfecto = Auxiliar.MapDtoToDesperfecto(entity);
            using (var context = _unitOFWork.Create())
            {
                return context.Repositories.desperfectoRepository.Create(desperfecto);
            }
        }
        public DesperfectoDTO Get(int id)
        {
            var desperfecto = new Desperfecto();

            using (var context = _unitOFWork.Create())
            {
                desperfecto = context.Repositories.desperfectoRepository.Get(id);
            }
            return Auxiliar.MapDesperfectoToDTO(desperfecto);
            
        }

        public IEnumerable<DesperfectoDTO> GetAll()
        {
            var desperfectoList = new List<Desperfecto>();
            var dtoList = new List<DesperfectoDTO>();

            using (var context = _unitOFWork.Create())
            {
                desperfectoList = context.Repositories.desperfectoRepository.GetAll().ToList();
            }

            if (desperfectoList.Count > 0)
                foreach (var item in desperfectoList)
                {
                    dtoList.Add(Auxiliar.MapDesperfectoToDTO(item));
                }

            return dtoList;
        }
    }
}
