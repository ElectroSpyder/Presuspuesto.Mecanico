using System.Data;
using Microsoft.Data.SqlClient;
using EntitiesDTO.DTO;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.Repository.Interfaces;

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class VehiculoRepository : BaseRepository, IVehiculoRepository
    {
        /// <summary>
        /// Metodos para CRUD de Automovil o Moto
        /// </summary>
        /// <param name="Automovil o Moto"></param>
        public VehiculoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public decimal Create(VehiculoDTO vehiculo)
        {
            
            try
            {               
                using var command = CreateCommand(StringObjects.CreateVehiculo);
                
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Marca", vehiculo.Marca));
                command.Parameters.Add(new SqlParameter("@Modelo", vehiculo.Modelo));
                command.Parameters.Add(new SqlParameter("@Patente", vehiculo.Patente));
                command.Parameters.Add(new SqlParameter("@TipoVehiculo", vehiculo.TipoVehiculo));
                command.Parameters.Add(new SqlParameter("@Descripcion", vehiculo.Descripcion));
                command.Parameters.Add(new SqlParameter("@Tipo", vehiculo.Tipo));
                command.Parameters.Add(new SqlParameter("@CantidadPuertas", vehiculo.CantidadPuertas));
                command.Parameters.Add(new SqlParameter("@Cilindrada", vehiculo.Cilindrada));

                var result = command.ExecuteScalar();// ExecuteCommandScalar(command);
                
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
                using var command = CreateCommand(StringObjects.DeleteVehiculo);
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

        public VehiculoDTO Get(int id)
        {
            try
            {
                var vehiculo = new VehiculoDTO();
                using var command = CreateCommand(StringObjects.GetAutomovil);
                command.Parameters.AddWithValue("@id", id);

                using (var reader = command.ExecuteReader())
                {
                    reader.Read();

                    vehiculo.Id = ReaderHelper.ConvertFromReader<int>(reader["Id"]);
                    vehiculo.Tipo = ReaderHelper.ConvertFromReader<EntitiesDTO.DTO.Tipo>(reader["Tipo"]);
                    vehiculo.Descripcion = ReaderHelper.ConvertFromReader<string>(reader["Description"]);
                    vehiculo.CantidadPuertas = ReaderHelper.ConvertFromReader<int>(reader["CantidadPuertas"]);

                }

                return vehiculo;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }           
        }

        public IEnumerable<VehiculoDTO> GetAll()
        {
            try
            {
                List<VehiculoDTO> vehiculoList = [];
                using var comman = CreateCommand(StringObjects.GetAllVehiculos);
                DataTable dataTable = new();

                SqlDataAdapter adapter = new(comman);
                
                adapter.Fill(dataTable);
                

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        VehiculoDTO grupo = MapToVehiculo(row);
                        vehiculoList.Add(grupo);
                    }
                }

                return vehiculoList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            

        }
        public decimal Update(VehiculoDTO vehiculo)
        {
            using var command = CreateCommand(StringObjects.UpdateVehiculo);

            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", vehiculo.Id));
            command.Parameters.Add(new SqlParameter("@Marca", vehiculo.Marca));
            command.Parameters.Add(new SqlParameter("@Modelo", vehiculo.Modelo));
            command.Parameters.Add(new SqlParameter("@Patente", vehiculo.Patente));
            command.Parameters.Add(new SqlParameter("@TipoVehiculo", vehiculo.TipoVehiculo));
            command.Parameters.Add(new SqlParameter("@Descripcion", vehiculo.Descripcion));
            command.Parameters.Add(new SqlParameter("@Tipo", vehiculo.Tipo));
            command.Parameters.Add(new SqlParameter("@CantidadPuertas", vehiculo.CantidadPuertas));
            command.Parameters.Add(new SqlParameter("@Cilindrada", vehiculo.Cilindrada));

            var result = command.ExecuteScalar();

            return result != null ? (Int32)result : 0 ;
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
