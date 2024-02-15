using EntitiesDTO.DTO;

namespace Taller.Mecanico.Logic.Interfaces
{
    public interface IAutomovilService
    {
        public decimal Create(AutomovilDTO entity);
        public AutomovilDTO Get(int id);
        public IEnumerable<AutomovilDTO> GetAll();
    }
}
