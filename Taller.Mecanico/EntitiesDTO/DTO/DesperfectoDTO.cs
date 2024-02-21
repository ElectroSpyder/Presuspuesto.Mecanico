namespace EntitiesDTO.DTO
{
    public class DesperfectoDTO
    {
        public DesperfectoDTO()
        {
            Repuestos = [];
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal ManoDeObra { get; set; }
        public int Tiempo { get; set; }       
        public List<RepuestoDTO> Repuestos { get; set; }
    }
}
