using EntitiesDTO.DTO;

namespace Taller.Mecanico.Logic.Interfaces
{
    public interface IMotoService
    {
        public decimal Create(MotoRequest entity);
        public MotoDTO Get(int id);
        public IEnumerable<MotoDTO> GetAll();
    }
}
