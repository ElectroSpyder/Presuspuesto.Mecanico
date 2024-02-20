namespace EntitiesDTO.DTO
{
    public class Request
    {
        public Request()
        {
            Desperfectos = new List<RequestDesperfecto>();
        }
        public int VehiculoId { get; set; }
        public string Patente { get; set; }
        public string TipoVehiculo { get; set; }
        //public VehiculoDTO VehiculoDTO { get; set; }
        public IEnumerable<RequestDesperfecto> Desperfectos { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}
