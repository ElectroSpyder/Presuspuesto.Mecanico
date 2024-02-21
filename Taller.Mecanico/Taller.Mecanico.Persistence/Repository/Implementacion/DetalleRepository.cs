using EntitiesDTO.DTO;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Taller.Mecanico.Models.Entities;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.Repository.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class DetalleRepository : BaseRepository, IDetalleRepository
    {
        public DetalleRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public decimal Create(Detalle detalle)
        {
            try
            {
                using var command = CreateCommand(StringObjects.CreateDetalle);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@PresupuestoId", detalle.PresupuestoId));
                command.Parameters.Add(new SqlParameter("@DesperfectoId", detalle.DesperfectoId));

                var result = command.ExecuteScalar(); 

                return result != null ? (decimal)result : 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<DetalleDTO> GetAllByIdPresupuesto(int presupuestoId)
        {
            try
            {
                List<DetalleDTO> detalleList = [];
                using var command = CreateCommand(StringObjects.GetAllDetalleByIdPresupuesto);
                command.Parameters.Add(new SqlParameter("@Id", presupuestoId));
                command.CommandType= CommandType.StoredProcedure;

                DataTable dataTable = new();

                SqlDataAdapter adapter = new(command)
                {
                    SelectCommand = command
                };
                adapter.Fill(dataTable);


                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DetalleDTO grupo = MapToDetalleDto(row);
                        detalleList.Add(grupo);
                    }
                }

                return detalleList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private DetalleDTO MapToDetalleDto(DataRow reader)
        {
            try
            {

                var detalle = new DetalleDTO
                {
                    Id = (int)reader["Id"],
                    PresupuestoId = (int)reader["PresupuestoId"],
                    DesperfectoId = (int)reader["DesperfectoId"]
                };

                return detalle;
            }
            catch (Exception )
            {

                throw;
            }
        }
    }
}
