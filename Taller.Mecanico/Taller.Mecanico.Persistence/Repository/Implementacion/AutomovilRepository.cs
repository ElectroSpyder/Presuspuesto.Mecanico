using System.Data.SqlClient;
using Taller.Mecanico.Models.Auxiliar;
using Taller.Mecanico.Models.Entities;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.Repository.Interfaces;

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class AutomovilRepository : BaseRepository, IAutomovilRepository
    {
        public AutomovilRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Create(Automovil automovil)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Automovil Get(int id)
        {
            var automovil = new Automovil();
            var command = CreateCommand(StringObjects.GetAutomovil);
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                automovil.Id = Convert.ToInt32(reader["Id"]);
                automovil.Tipo = Enum.Parse<Tipo>(Convert.ToString(value: reader["Tipo"]));
                automovil.Descripcion = Convert.ToString(reader["Description"]);
                automovil.CantidadPuertas = Convert.ToInt32(reader["CantidadPuertas"]);
            }

            return automovil;
        }

        public IEnumerable<Automovil> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Automovil automovil)
        {
            throw new NotImplementedException();
        }
    }
}
