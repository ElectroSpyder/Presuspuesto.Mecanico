using EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Logic.Implementacion
{
    public class DetalleService : IDetalleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetalleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public decimal Create(DetalleDTO detalle)
        {
            using var context = _unitOfWork.Create();

            var result = context.Repositories.detalleRepository.Create(Auxiliar.MapDtoToDetalle(detalle));
            if(result > 0) context.SaveChanges();

            return result;
        }
    }
}
