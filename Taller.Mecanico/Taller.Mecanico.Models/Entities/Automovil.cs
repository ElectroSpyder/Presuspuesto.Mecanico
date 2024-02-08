using Taller.Mecanico.Models.Auxiliar;

namespace Taller.Mecanico.Models.Entities
{
    public class Automovil : Vehiculo
    {
        public string? Descripcion { get; set; }
        public Tipo Tipo { get; set; }
        public int CantidadPuertas { get; set; }

    }
}
