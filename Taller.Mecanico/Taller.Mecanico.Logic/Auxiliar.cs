﻿using EntitiesDTO.DTO;
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

        internal static MotoDTO MapVehiculoToMoto(VehiculoDTO vehiculo)
        {
            try
            {
                var motoDTO = new MotoDTO
                {
                    Id = vehiculo.Id,                    
                    Descripcion = vehiculo.Descripcion,
                    Marca = vehiculo.Marca,
                    Modelo = vehiculo.Modelo,
                    Patente = vehiculo.Patente,
                    Cilindrada = vehiculo.Cilindrada
                };

                return motoDTO;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        internal static VehiculoDTO MapAutomovilToVehiculo(AutomovilRequest automovilDTO)
        {
            try
            {
                return new VehiculoDTO
                {                   
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
        internal static VehiculoDTO MapMotoToVehiculo(MotoRequest motoRequest)
        {
            try
            {
                return new VehiculoDTO
                {                   
                    Descripcion = motoRequest.Descripcion,
                    Marca = motoRequest.Marca,
                    Modelo = motoRequest.Modelo,
                    Patente = motoRequest.Patente,
                    Cilindrada = motoRequest.Cilindrada,
                    TipoVehiculo = motoRequest.TipoVehiculo,
                    CantidadPuertas = 0                     
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
                    Tiempo = entity.Tiempo
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
                    Tiempo = desperfecto.Tiempo
                };
            }catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        internal static Repuesto MapDtoToRepuesto(RepuestoDTO entity)
        {
            try
            {
                return new Repuesto
                {
                    Id = entity.Id,
                    Nombre = entity.Nombre,
                    Precio = entity.Precio
                };
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        internal static RepuestoDTO MapRepuestoToDTO(Repuesto repuesto)
        {
            try
            {
                return new RepuestoDTO
                {
                    Id = repuesto.Id,
                    Nombre = repuesto.Nombre,
                    Precio = repuesto.Precio
                };
            }
            catch (Exception ex) { throw new Exception(ex.Message, ex); }
        }

        internal static Detalle MapDtoToDetalle(DetalleDTO detalle)
        {
            try
            {
                return new Detalle
                {
                    Id = detalle.Id,
                    PresupuestoId = detalle.PresupuestoId,
                    DesperfectoId = detalle.DesperfectoId
                };
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
