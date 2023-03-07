using Demo_Common.Repositories;
using Demo_DAL.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    public class TypeService : BaseService, ITypeRepository<Type, int>
    {
        public TypeService(IConfiguration config) : base(config, "Theatre-DB")
        {
        }

        public IEnumerable<Type> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idType], [nom], [prix] FROM [Type]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToType();
                        }
                    }
                }
            }
        }

        public Type Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idType], [nom], [prix] FROM [Type] WHERE idType = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToType();
                        }
                        return null;
                    }
                }
            }
        }
    }
}
