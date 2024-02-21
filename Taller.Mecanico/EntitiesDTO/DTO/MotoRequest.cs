namespace EntitiesDTO.DTO
{
    public class MotoRequest
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public string? Descripcion { get; set; }
        public string TipoVehiculo
        {
            get
            {
                return "Moto";
            }
        }
        public string? Cilindrada { get; set; }
    }
}
