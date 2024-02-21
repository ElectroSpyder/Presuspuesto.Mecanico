using EntitiesDTO.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using Taller.Mecanico.Models.Entities;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.Repository.Interfaces;

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class DesperfectoRepository : BaseRepository, IDesperfectoRepository
    {
        public DesperfectoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public decimal Create(DesperfectoDTO desperfecto)
        {
            try
            {                
                using var command = CreateCommand(StringObjects.CreateDesperfecto);
                command.CommandType = CommandType.StoredProcedure;          

                command.Parameters.Add(new SqlParameter("@Descripcion", desperfecto.Descripcion));
                command.Parameters.Add(new SqlParameter("@ManoDeObra", desperfecto.ManoDeObra));
                command.Parameters.Add(new SqlParameter("@Tiempo", desperfecto.Tiempo));
                
                var result = command.ExecuteScalar();// ExecuteCommandScalar(command);

                return result != null ? (decimal)result : 0;

            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw new Exception(ex.Message);
            }
            
        }

        public decimal Delete(int id)
        {
            try
            {
                using var command = CreateCommand(StringObjects.DeleteDespertecto);
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

        public DesperfectoDTO Get(int id)
        {
            try
            {
                var desperfecto = new DesperfectoDTO();
                using var command = CreateCommand(StringObjects.GetDesperfecto);
                command.Parameters.AddWithValue("@id", id);
                command.CommandType= CommandType.Text;

                DataTable dataTable = new();
                using var adapter = new SqlDataAdapter(command);
                adapter.SelectCommand = command;

                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        desperfecto.Id = ReaderHelper.ConvertFromReader<int>(row["Id"]);
                        desperfecto.Descripcion = ReaderHelper.ConvertFromReader<string>(row["Descripcion"]);
                        desperfecto.ManoDeObra = ReaderHelper.ConvertFromReader<decimal>(row["ManoDeObra"]);
                        desperfecto.Tiempo = ReaderHelper.ConvertFromReader<int>(row["Tiempo"]);                        
                    }
                }

                return desperfecto;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
            
        }

        public IEnumerable<DesperfectoDTO> GetAll()
        {
            try
            {
                List<DesperfectoDTO> desperfectoList = [];
                using var comman = CreateCommand(StringObjects.GetAllDesperfectos);
                DataTable dataTable = new();

                using var adapter = new SqlDataAdapter(comman);
                adapter.Fill(dataTable);                

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        DesperfectoDTO grupo = MapToDesperfecto(row);
                        desperfectoList.Add(grupo);
                    }
                }

                return desperfectoList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        public int Update(DesperfectoDTO desperfecto)
        {
            try
            {
                using var command = CreateCommand(StringObjects.UpdateDesperfecto);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Id", desperfecto.Id));
                command.Parameters.Add(new SqlParameter("@Descripcion", desperfecto.Descripcion));
                command.Parameters.Add(new SqlParameter("@ManoDeObra", desperfecto.ManoDeObra));
                command.Parameters.Add(new SqlParameter("@Tiempo", desperfecto.Tiempo));                

                var result = command.ExecuteScalar();// ExecuteCommandScalar(command);

                return result != null ? (int)result : 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        #region Privado
        private DesperfectoDTO MapToDesperfecto(DataRow reader)
        {
            try
            {
                var desperfecto = new DesperfectoDTO
                {
                    Id = (int)reader["Id"],
                    Descripcion = reader["Descripcion"] is DBNull ? " " : (string)reader["Descripcion"],
                    ManoDeObra = reader["ManoDeObra"] is DBNull ? 0 : (decimal)reader["ManoDeObra"],
                    Tiempo = reader["Tiempo"] is DBNull ? 0 : (int)reader["Tiempo"]                   
                };

                return desperfecto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        #endregion
       
    }
}
