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
        public decimal Create(Desperfecto desperfecto)
        {
            try
            {                
                using var command = CreateCommand(StringObjects.CreateDesperfecto);
                command.CommandType = CommandType.StoredProcedure;          

                command.Parameters.Add(new SqlParameter("@Descripcion", desperfecto.Descripcion));
                command.Parameters.Add(new SqlParameter("@ManoDeObra", desperfecto.ManoDeObra));
                command.Parameters.Add(new SqlParameter("@Tiempo", desperfecto.Tiempo));
                command.Parameters.Add(new SqlParameter("@PresupuestoId", desperfecto.PresupuestoId == 0 ? DBNull.Value : desperfecto.PresupuestoId));
                
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
            using var command = CreateCommand(StringObjects.DeleteDespertecto);
            command.Parameters.Add(new SqlParameter("id", id));
            command.CommandType = CommandType.StoredProcedure;

            var result = ExecuteCommandScalar(command);

            return result != null ? (decimal)result : 0;
        }

        public Desperfecto Get(int id)
        {
            var desperfecto = new Desperfecto();
            using var command = CreateCommand(StringObjects.GetAutomovil);
            command.Parameters.AddWithValue("@id", id);
            
            DataTable dataTable = new ();
            var adapter = ExecuteCommandAdapter(command);
            adapter.Fill(dataTable);

            if(dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    desperfecto.Id = ReaderHelper.ConvertFromReader<int>(row["Id"]);
                    desperfecto.Descripcion = ReaderHelper.ConvertFromReader<string>(row["Descripcion"]);
                    desperfecto.ManoDeObra = ReaderHelper.ConvertFromReader<decimal>(row["ManoDeObra"]);
                    desperfecto.Tiempo = ReaderHelper.ConvertFromReader<int>(row["Tiempo"]);
                    desperfecto.PresupuestoId = ReaderHelper.ConvertFromReader<int>(row["PresupuestoId"]);
                }
            }

            return desperfecto;
        }

        public IEnumerable<Desperfecto> GetAll()
        {
            try
            {
                List<Desperfecto> desperfectoList = [];
                using var comman = CreateCommand(StringObjects.GetAllDesperfectos);
                DataTable dataTable = new();

                using var adapter = ExecuteCommandAdapter(comman);
                {
                    adapter.Fill(dataTable);
                }

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        Desperfecto grupo = MapToDesperfecto(row);
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

        public decimal Update(Desperfecto desperfecto)
        {
            try
            {
                using var command = CreateCommand(StringObjects.UpdateDesperfecto);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Descripcion", desperfecto.Descripcion));
                command.Parameters.Add(new SqlParameter("@ManoDeObra", desperfecto.ManoDeObra));
                command.Parameters.Add(new SqlParameter("@Tiempo", desperfecto.Tiempo));
                command.Parameters.Add(new SqlParameter("@PresupuestoId", desperfecto.PresupuestoId == 0 ? DBNull.Value : desperfecto.PresupuestoId));

                var result = ExecuteCommandScalar(command);

                return result != null ? (decimal)result : 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }           
        }

        #region Privado
        private Desperfecto MapToDesperfecto(DataRow reader)
        {
            try
            {
                var desperfecto = new Desperfecto
                {
                    Id = (int)reader["Id"],
                    Descripcion = reader["Descripcion"] is DBNull ? " " : (string)reader["Descripcion"],
                    ManoDeObra = reader["ManoDeObra"] is DBNull ? 0 : (decimal)reader["ManoDeObra"],
                    Tiempo = reader["Tiempo"] is DBNull ? 0 : (int)reader["Tiempo"],
                    PresupuestoId = reader["PresupuestoId"] is DBNull ? 0 : (int)reader["PresupuestoId"]
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
