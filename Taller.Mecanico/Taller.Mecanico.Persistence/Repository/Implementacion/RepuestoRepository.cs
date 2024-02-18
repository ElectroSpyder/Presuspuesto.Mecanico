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

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class RepuestoRepository : BaseRepository, IRepuestoRepository
    {
        public RepuestoRepository(SqlConnection context, SqlTransaction transaction)
        {
            _context = context;
            this._transaction = transaction;
        }
        public decimal Create(Repuesto repuesto)
        {
            try
            {
                using var command = CreateCommand(StringObjects.CreateRepuesto);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Nombre", repuesto.Nombre));
                command.Parameters.Add(new SqlParameter("@Precio", repuesto.Precio));

                var result = ExecuteCommandScalar(command);

                return result != null ? (decimal)result : 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        public decimal Delete(int id)
        {
            try
            {
                using var command = CreateCommand(StringObjects.DeleteRepuesto);
                command.Parameters.Add(new SqlParameter("id", id));
                command.CommandType = CommandType.StoredProcedure;

                var result = command.ExecuteScalar();

                return result != null ? (decimal)result : 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Repuesto Get(int id)
        {
            try
            {
                var repuesto = new Repuesto();
                using var command = CreateCommand(StringObjects.GetRepuesto);
                command.Parameters.AddWithValue("@id", id);

                using var reader = command.ExecuteReader();

                reader.Read();

                repuesto.Id = ReaderHelper.ConvertFromReader<int>(reader["Id"]);
                repuesto.Nombre = ReaderHelper.ConvertFromReader<string>(reader["Nombre"]);
                repuesto.Precio = ReaderHelper.ConvertFromReader<decimal>(reader["Precio"]);

                return repuesto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<Repuesto> GetAll()
        {
            try
            {
                List<Repuesto> repuestoList = [];
                using var comman = CreateCommand(StringObjects.GetAllRepuesto);
                DataTable dataTable = new();

                using (SqlDataAdapter adapter = new(comman))
                {
                    adapter.Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Repuesto grupo = MapToRepuesto(row);
                        repuestoList.Add(grupo);
                    }
                }

                return repuestoList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        public decimal Update(Repuesto repuesto)
        {
            try
            {
                using var command = CreateCommand(StringObjects.UpdateRepuesto);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Nombre", repuesto.Nombre));
                command.Parameters.Add(new SqlParameter("@Precio", repuesto.Precio));

                var result = ExecuteCommandScalar(command);

                return result != null ? (decimal)result : 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        #region Privados
        private Repuesto MapToRepuesto(DataRow reader)
        {
            try
            {
                var repuesto = new Repuesto
                {
                    Id = (int)reader["Id"],
                    Nombre = reader["Nombre"] is DBNull ? " " : (string)reader["Nombre"],
                    Precio = reader["Precio"] is DBNull ? 0 : (decimal)reader["Precio"]
                };

                return repuesto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
