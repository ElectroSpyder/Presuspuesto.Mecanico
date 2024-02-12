using Microsoft.Data.SqlClient;
using Taller.Mecanico.Models.Entities;
using Taller.Mecanico.Persistence.Common;
using Taller.Mecanico.Persistence.Repository.Interfaces;

namespace Taller.Mecanico.Persistence.Repository.Implementacion
{
    public class MotoRepository : BaseRepository, IMotoRepository
    {
        public MotoRepository(SqlConnection context, SqlTransaction transaction)
        {
            this._context = context;
            this._transaction = transaction;
        }
        public void Create(Moto moto)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Moto Get(int id)
        {
            var moto = new Moto();
            var command = CreateCommand(StringObjects.GetMoto);
            command.Parameters.AddWithValue("@id", id);

            using (var reader = command.ExecuteReader())
            {
                reader.Read();

                moto.Id = Convert.ToInt32(reader["Id"]);
                moto.Cilindrada = Convert.ToString(reader["Cilindrada"]);
            }

            return moto;
        }

        public IEnumerable<Moto> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Moto moto)
        {
            throw new NotImplementedException();
        }
    }
}
