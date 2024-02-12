using System.Data;
using Microsoft.Data.SqlClient;
using Taller.Mecanico.EntitiesDTO.DTO;
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

        public void Create(VehiculoDTO vehiculo)
        {
            /* var queryDomicilio = "sp_insert_update_Domicilio";
                    using (SqlCommand cmdInsDomicilio = new SqlCommand(queryDomicilio, con))
                    {

                        cmdInsDomicilio.CommandType = CommandType.StoredProcedure;
                        cmdInsDomicilio.CommandText = queryDomicilio;
                        cmdInsDomicilio.Parameters.Add(new SqlParameter("@insd_ficha", inscViewModel.InsFicha));
            decimal InscriptoId = 0;
            var objetoId = new object();

            @Marca , @Modelo , @Patente , @TipoVehiculo , @Descripcion " +
            " , @Tipo , @CantidadPuertas 

            @Marca nvarchar(50),
    @Modelo nvarchar(50),
	@Patente nvarchar(50),
	@PresupuestoId int,
	@TipoVehiculo nchar(13),
	@Descripcion nvarchar(50),
	@Tipo int,
	@CantidadPuertas int,
	@Cilindrada nvarchar(50)


            */
            try
            {
                var command = CreateCommand(StringObjects.CreateVehiculo);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.CommandText = StringObjects.CreateVehiculo;

                command.Parameters.Add(new SqlParameter("@Marca", vehiculo.Marca));
                command.Parameters.Add(new SqlParameter("@Modelo", vehiculo.Modelo));
                command.Parameters.Add(new SqlParameter("@Patente", vehiculo.Patente));
                command.Parameters.Add(new SqlParameter("@TipoVehiculo", vehiculo.TipoVehiculo));
                command.Parameters.Add(new SqlParameter("@Descripcion", vehiculo.Descripcion));
                command.Parameters.Add(new SqlParameter("@Tipo", vehiculo.Tipo));
                command.Parameters.Add(new SqlParameter("@CantidadPuertas", vehiculo.CantidadPuertas));
                command.Parameters.Add(new SqlParameter("@Cilindrada", vehiculo.Cilindrada));

                command.ExecuteScalar();
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception(ex.Message);
            }

        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public VehiculoDTO Get(int id)
        {
            var vehiculo = new VehiculoDTO();
            var command = CreateCommand(StringObjects.GetAutomovil);
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

        public IEnumerable<VehiculoDTO> GetAll()
        {
            List<VehiculoDTO> vehiculoList = [];
            var comman = CreateCommand(StringObjects.GetAllVehiculos);
            DataTable dataTable = new();

            using (SqlDataAdapter adapter = new(comman))
            {                
                adapter.Fill(dataTable);                
            }

            if(dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    VehiculoDTO grupo = MapToVehiculo(row);
                    vehiculoList.Add(grupo);
                }                
            }
           
            return vehiculoList;

        }
        public void Update(VehiculoDTO vehiculo)
        {
            throw new NotImplementedException();
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
