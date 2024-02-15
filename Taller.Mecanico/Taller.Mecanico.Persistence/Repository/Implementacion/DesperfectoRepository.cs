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
                
                var result = ExecuteCommand(command);

                return result != null ? (decimal)result : 0;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _transaction.Dispose();
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Desperfecto Get(int id)
        {
            var desperfecto = new Desperfecto();
            var command = CreateCommand(StringObjects.GetAutomovil);
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                desperfecto.Id = ReaderHelper.ConvertFromReader<int>(reader["Id"]);
                desperfecto.Descripcion = ReaderHelper.ConvertFromReader<string>(reader["Descripcion"]);
                desperfecto.ManoDeObra = ReaderHelper.ConvertFromReader<decimal>(reader["ManoDeObra"]);
                desperfecto.Tiempo = ReaderHelper.ConvertFromReader<int>(reader["Tiempo"]);
                desperfecto.PresupuestoId = ReaderHelper.ConvertFromReader<int>(reader["PresupuestoId"]);
            }

            return desperfecto;
        }

        public IEnumerable<Desperfecto> GetAll()
        {

            List<Desperfecto> desperfectoList = [];
            var comman = CreateCommand(StringObjects.GetAllDesperfectos);
            DataTable dataTable = new();

            using (SqlDataAdapter adapter = new(comman))
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

        public void Update(Desperfecto desperfecto)
        {
            throw new NotImplementedException();
        }
    }
}
