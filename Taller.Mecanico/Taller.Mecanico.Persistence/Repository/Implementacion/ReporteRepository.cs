using EntitiesDTO.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.Repository.Interfaces;

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class ReporteRepository :BaseRepository, IReportesRepository
    {
        public ReporteRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }

        public IEnumerable<PromedioMarcaModeloDTO> GetPromedio()
        {
            try
            {
                var promedioList = new List<PromedioMarcaModeloDTO>();

                using var command = CreateCommand(StringObjects.GetPromedio);
                command.CommandType = CommandType.StoredProcedure;

                DataTable dataTable = new();
                using var adapter = new SqlDataAdapter(command);
                adapter.SelectCommand = command;

                adapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        PromedioMarcaModeloDTO grupo = MapToPromedio(row);
                        promedioList.Add(grupo);
                    }
                }

                return promedioList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public RepuestoMasUsadoDTO GetRepuestoMasUsado()
        {
            try
            {
                var repuesto = new RepuestoMasUsadoDTO();

                using var command = CreateCommand(StringObjects.GetRepuestoMasUtilizado);
                command.CommandType = CommandType.StoredProcedure;

                DataTable dataTable = new();
                using var adapter = new SqlDataAdapter(command);
                adapter.SelectCommand = command;

                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    foreach (DataRow row in dataTable.Rows)
                    {
                        repuesto.Cantidad = ReaderHelper.ConvertFromReader<int>(row["Cantidad"]);
                        repuesto.Descripcion = ReaderHelper.ConvertFromReader<string>(row["Descripcion"]);
                    }
                }

                return repuesto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region privado
        private PromedioMarcaModeloDTO MapToPromedio(DataRow reader)
        {
            try
            {

                var promedio = new PromedioMarcaModeloDTO
                {
                    Promedio = reader["Promedio"] is DBNull ? 0 : (decimal)reader["Promedio"],
                    Marca = reader["Marca"] is DBNull ? " " : (string)reader["Marca"],
                    Modelo = reader["Modelo"] is DBNull ? " " : (string)reader["Modelo"]
                };

                return promedio;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
