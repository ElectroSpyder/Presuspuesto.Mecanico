using System.Data;
using Microsoft.Data.SqlClient;
using EntitiesDTO.DTO;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.Repository.Interfaces;

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class PresupuestoRepository : BaseRepository, IPresupuestoRepository
    {
        /// <summary>
        /// Metodos para CRUD de Automovil o Moto
        /// </summary>
        /// <param name="Automovil o Moto"></param>
        public PresupuestoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public decimal Create(PresupuestoDTO presupuesto)
        {            
            try
            {               
                using var command = CreateCommand(StringObjects.CreatePresupuesto);
                
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Nombre", presupuesto.Nombre));
                command.Parameters.Add(new SqlParameter("@Apellido", presupuesto.Apellido));
                command.Parameters.Add(new SqlParameter("@Email", presupuesto.Email));
                command.Parameters.Add(new SqlParameter("@Total", presupuesto.Total));
                command.Parameters.Add(new SqlParameter("@VehiculoId", presupuesto.Vehiculo.Id));

                var result = command.ExecuteScalar(); //& ExecuteCommandScalar(command);
                
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
                using var command = CreateCommand(StringObjects.DeletePresupuesto);
                command.Parameters.Add(new SqlParameter("id", id));
                command.CommandType = CommandType.StoredProcedure;

                var result = command.ExecuteScalar();// ExecuteCommandScalar(command);

                return result != null ? (decimal)result : 0;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public PresupuestoDTO Get(int id)
        {
            throw new NotImplementedException();           
        }

        public IEnumerable<PresupuestoDTO> GetAll()
        {

            try
            {
                List<PresupuestoDTO> presupuestoList = [];
                using var comman = CreateCommand(StringObjects.GetAllPresupuesto);
                DataTable dataTable = new();

                SqlDataAdapter adapter = new(comman);

                adapter.Fill(dataTable);


                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        PresupuestoDTO grupo = MapToPresupuesto(row);
                        presupuestoList.Add(grupo);
                    }
                }

                return presupuestoList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public decimal Update(PresupuestoDTO presupuesto)
        {
            try
            {
                using var command = CreateCommand(StringObjects.UpdatePresupuesto);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Nombre", presupuesto.Nombre));
                command.Parameters.Add(new SqlParameter("@Apellido", presupuesto.Apellido));
                command.Parameters.Add(new SqlParameter("@Email", presupuesto.Email));
                command.Parameters.Add(new SqlParameter("@Total", presupuesto.Total));
                command.Parameters.Add(new SqlParameter("@VehiculoId", presupuesto.Vehiculo.Id));

                var result = command.ExecuteScalar();// ExecuteCommandScalar(command);

                return result != null ? (Int32)result : 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        #region private Method

        private static PresupuestoDTO MapToPresupuesto(DataRow reader)
        {
            try
            {

                var presupuesto = new PresupuestoDTO
                {
                    Id = reader["Id"] is DBNull ? 0 : (int)reader["Id"],
                    Nombre = reader["Nombre"] is DBNull ? " " : (string)reader["Nombre"],
                    Apellido = reader["Apellido"] is DBNull ? " " : (string)reader["Apellido"],
                    Email = reader["Email"] is DBNull ? " " : (string)reader["Email"],
                    VehiculoId = reader["VehiculoId"] is DBNull ? 0 : (int)reader["VehiculoId"],
                    Total = reader["Total"] is DBNull ? 0 : (decimal)reader["Total"]
                };

                return presupuesto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

       


        #endregion
    }
}
