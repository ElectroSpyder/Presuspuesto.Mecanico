using EntitiesDTO.DTO;
using Microsoft.Identity.Client;
using Taller.Mecanico.Models.Entities;

namespace Taller.Mecanico.Logic
{
    internal static class Auxiliar
    {
        internal static AutomovilDTO MapVehiculoToAutomovil(VehiculoDTO vehiculo)
        {
            try
            {
                var automovilDTO = new AutomovilDTO
                {
                    Id = vehiculo.Id,
                    CantidadPuertas = vehiculo.CantidadPuertas,
                    Descripcion = vehiculo.Descripcion,
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Patente = vehiculo.Patente,
                    Tipo = vehiculo.Tipo
                };

                return automovilDTO;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        internal static VehiculoDTO MapAutomovilToVehiculo(AutomovilDTO automovilDTO)
        {
            try
            {
                return new VehiculoDTO
                {
                    Id = automovilDTO.Id,
                    CantidadPuertas = automovilDTO.CantidadPuertas,
                    Descripcion = automovilDTO.Descripcion,
                    Marca = automovilDTO.Marca,
                    Modelo = automovilDTO.Modelo,
                    Patente = automovilDTO.Patente,
                    Cilindrada = string.Empty,
                    Tipo = automovilDTO.Tipo,
                    TipoVehiculo = automovilDTO.TipoVehiculo
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static Desperfecto MapDtoToDesperfecto(DesperfectoDTO entity)
        {
            try
            {
                return new Desperfecto
                {
                    Id = entity.Id,
                    Descripcion = entity.Descripcion,
                    ManoDeObra = entity.ManoDeObra,
                    Tiempo = entity.Tiempo,
                    PresupuestoId = entity.PresupuestoId
                };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static DesperfectoDTO MapDesperfectoToDTO(Desperfecto desperfecto)
        {
            try
            {
                return new DesperfectoDTO
                {
                    Id = desperfecto.Id,
                    Descripcion = desperfecto.Descripcion,
                    ManoDeObra = desperfecto.ManoDeObra,
                    Tiempo = desperfecto.Tiempo,
                    PresupuestoId = desperfecto.PresupuestoId
                };
            }catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }
    }
}
