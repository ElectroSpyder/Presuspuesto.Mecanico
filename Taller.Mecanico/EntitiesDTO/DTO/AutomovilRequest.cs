namespace EntitiesDTO.DTO
{
    public class AutomovilRequest
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Patente { get; set; }
        public string? Descripcion { get; set; }
        public Tipo Tipo { get; set; }
        public string TipoVehiculo
        {
            get
            {
                return "Auto";
            }
        }
        public int CantidadPuertas { get; set; }
    }
}
