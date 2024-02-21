using EntitiesDTO.DTO;
using Microsoft.Data.SqlClient;
using System.Data;
using Taller.Mecanico.Models.Entities;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.Repository.Interfaces;

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class DesperfectoRepuestoRepository : BaseRepository, IDesperfectoRepuestoRepository
    {
        public DesperfectoRepuestoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public ICollection<DesperfectoRepuestoDTO> GetAllDesperfectoRepuestoByIdDesperfecto(int desperfectoId)
        {
            try
            {
                List<DesperfectoRepuestoDTO> desperfectoRepuestoList = [];
                using var command = CreateCommand(StringObjects.GetAllDesperfectoRepuestoByIdDesperfecto);
                command.Parameters.Add(new SqlParameter("Id", desperfectoId));
                command.CommandType = CommandType.StoredProcedure;

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
                        DesperfectoRepuestoDTO grupo = MapToDesperfectoRepuestoDto(row);
                        desperfectoRepuestoList.Add(grupo);
                    }
                }

                return desperfectoRepuestoList;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        private DesperfectoRepuestoDTO MapToDesperfectoRepuestoDto(DataRow reader)
        {
            try
            {

                var desperfectoRepuesto = new DesperfectoRepuestoDTO
                {
                   DesperfectosId = (int)reader["DesperfectosId"],
                    RepuestosId = (int)reader["RepuestosId"]
                };

                return desperfectoRepuesto;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
