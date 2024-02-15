using EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Models.Entities;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Logic.Implementacion
{
    public class RepuestoService : IRepuestoService
    {
        private readonly IUnitOfWork _unitOFWork;

        public RepuestoService(IUnitOfWork unitOFWork)
        {
            _unitOFWork = unitOFWork;
        }

        public decimal Create(RepuestoDTO entity)
        {
            Repuesto repuesto = Auxiliar.MapDtoToRepuesto(entity);
            using (var context = _unitOFWork.Create())
            {
                return context.Repositories.repuestoRepository.Create(repuesto);
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RepuestoDTO Get(int id)
        {
            var repuesto = new Repuesto();

            using (var context = _unitOFWork.Create())
            {
                repuesto = context.Repositories.repuestoRepository.Get(id);
            }
            return Auxiliar.MapRepuestoToDTO(repuesto);

        }

        public IEnumerable<RepuestoDTO> GetAll()
        {
            var repuestoList = new List<Repuesto>();
            var dtoList = new List<RepuestoDTO>();

            using (var context = _unitOFWork.Create())
            {
                repuestoList = context.Repositories.repuestoRepository.GetAll().ToList();
            }

            if (repuestoList.Count > 0)
                foreach (var item in repuestoList)
                {
                    dtoList.Add(Auxiliar.MapRepuestoToDTO(item));
                }

            return dtoList;
        }

        public bool Update(RepuestoDTO repuesto)
        {
            throw new NotImplementedException();
        }
    }
}
