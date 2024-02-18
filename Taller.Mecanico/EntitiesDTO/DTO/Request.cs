namespace EntitiesDTO.DTO
{
    public class Request
    {
        public VehiculoDTO VehiculoDTO { get; set; }
        public IEnumerable<DesperfectoDTO> DesperfectoDTOs { get; set; }
               
    }
}
