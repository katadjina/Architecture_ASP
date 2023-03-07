using Demo_Common.Repositories;
using Demo_DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    public class SpectacleService : BaseService, ISpectacleRepository<Spectacle, int>
    {
        public SpectacleService(IConfiguration config) : base(config, "Theatre-DB")
        {
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Spectacle] WHERE [idSpectacle] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public IEnumerable<Spectacle> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idSpectacle], [nom], [description] FROM [spectacle]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToSpectacle();
                        }
                    }
                }
            }
        }

        public Spectacle Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idSpectacle], [nom], [description] FROM [Spectacle] WHERE [idSpectacle] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) return reader.ToSpectacle();
                        return null;
                    }
                }
            }
        }

        public int Insert(Spectacle entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SP_SpectacleAdd";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("desc", entity.description);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(int id, Spectacle entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Spectacle] SET [nom] = @nom, [description] = @desc WHERE [idSpectacle] = @id";
                    command.Parameters.AddWithValue("nom", entity.nom);
                    command.Parameters.AddWithValue("desc", entity.description);
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
