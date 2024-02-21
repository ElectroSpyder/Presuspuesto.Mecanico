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
            using (var context = _unitOFWork.Create())
            {
                return context.Repositories.repuestoRepository.Create(entity);
            }
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RepuestoDTO Get(int id)
        {
            var repuesto = new RepuestoDTO();

            using (var context = _unitOFWork.Create())
            {
                repuesto = context.Repositories.repuestoRepository.Get(id);
            }
            return repuesto;

        }

        public IEnumerable<RepuestoDTO> GetAll()
        {
            var repuestoList = new List<RepuestoDTO>();

            using (var context = _unitOFWork.Create())
            {
                repuestoList = context.Repositories.repuestoRepository.GetAll().ToList();
            }

            return repuestoList;
        }

        public bool Update(RepuestoDTO repuesto)
        {
            throw new NotImplementedException();
        }
    }
}
