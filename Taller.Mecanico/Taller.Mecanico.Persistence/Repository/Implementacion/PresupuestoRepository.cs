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
                using var command = CreateCommand(StringObjects.DeletePresupuesto);
                command.Parameters.Add(new SqlParameter("id", id));
                command.CommandType = CommandType.StoredProcedure;

                var result = ExecuteCommandScalar(command);

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
            //var vehiculo = new VehiculoDTO();
            //var command = CreateCommand(StringObjects.GetAutomovil);
            //command.Parameters.AddWithValue("@id", id);

            //using (var reader = command.ExecuteReader())
            //{
            //    reader.Read();

            //    vehiculo.Id = ReaderHelper.ConvertFromReader<int>(reader["Id"]);
            //    vehiculo.Tipo = ReaderHelper.ConvertFromReader<EntitiesDTO.DTO.Tipo>(reader["Tipo"]);
            //    vehiculo.Descripcion = ReaderHelper.ConvertFromReader<string>(reader["Description"]);
            //    vehiculo.CantidadPuertas = ReaderHelper.ConvertFromReader<int>(reader["CantidadPuertas"]);

            //}

            //return vehiculo;
        }

        public IEnumerable<PresupuestoDTO> GetAll()
        {
            throw new NotImplementedException();
            //List<VehiculoDTO> vehiculoList = [];
            //var comman = CreateCommand(StringObjects.GetAllVehiculos);
            //DataTable dataTable = new();

            //using (SqlDataAdapter adapter = new(comman))
            //{                
            //    adapter.Fill(dataTable);                
            //}

            //if(dataTable.Rows.Count > 0)
            //{
            //    foreach (DataRow row in dataTable.Rows)
            //    {
            //        VehiculoDTO grupo = MapToVehiculo(row);
            //        vehiculoList.Add(grupo);
            //    }                
            //}

            //return vehiculoList;

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

                var result = ExecuteCommandScalar(command);

                return result != null ? (decimal)result : 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        #region private Method

        private static VehiculoDTO MapToVehiculo(DataRow reader)
        {
            try
            {
                var vehiculo = new VehiculoDTO
                {
                    Id = (int)reader["Id"],
                    Marca = reader["Marca"] is DBNull ? " " : (string)reader["Marca"],
                    Modelo = reader["Modelo"] is DBNull ? " " : (string)reader["Modelo"],
                    Patente = reader["Patente"] is DBNull ? " " : (string)reader["Patente"],
                    TipoVehiculo = reader["TipoVehiculo"] is DBNull ? " " : (string)reader["TipoVehiculo"],
                    Descripcion = reader["Descripcion"] is DBNull ? " " : (string)reader["Descripcion"],
                    Tipo = (Tipo)(int)reader["Tipo"],
                    CantidadPuertas = (int)reader["CantidadPuertas"],
                    Cilindrada = reader["Cilindrada"] is DBNull ? " " : (string)reader["Cilindrada"]
                };

                return vehiculo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

       


        #endregion
    }
}
