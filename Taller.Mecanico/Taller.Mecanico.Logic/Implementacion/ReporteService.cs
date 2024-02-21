using EntitiesDTO.DTO;
using Taller.Mecanico.Logic.Interfaces;
using Taller.Mecanico.Persistence.UnitOfWork.Interfaces;

namespace Taller.Mecanico.Logic.Implementacion
{
    public class ReporteService : IReporteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReporteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PromedioMarcaModeloDTO> GetPromedio()
        {
            try
            {
                using var context = _unitOfWork.Create();
                return context.Repositories.reportesRepository.GetPromedio();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public RepuestoMasUsadoDTO GetRepuestoMasUsado()
        {
            try
            {
                using var context = _unitOfWork.Create();
                return context.Repositories.reportesRepository.GetRepuestoMasUsado();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
