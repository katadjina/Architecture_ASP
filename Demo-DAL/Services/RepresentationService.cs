using Demo_Common.Repositories;
using Demo_DAL.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_DAL.Services
{
    public class RepresentationService : BaseService,IRepresentationRepository<Representation, int>
    {
        public RepresentationService(IConfiguration config) : base(config, "Theatre-DB")
        {
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [Representation] WHERE [idRespresentation] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public IEnumerable<Representation> Get()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idRepresentation], [dateRepresentation], [heureRepresentation], [idSpectacle] FROM [Representation]";
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToRepresentation();
                        }
                    }
                }
            }
        }

        public Representation Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idRepresentation], [dateRepresentation], [heureRepresentation], [idSpectacle] FROM [Representation] WHERE [idRepresentation] = @id";
                    command.Parameters.AddWithValue("id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return reader.ToRepresentation();
                        }
                        return null;
                    }
                }
            }
        }

        public IEnumerable<Representation> GetByDate(DateTime date)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idRepresentation], [dateRepresentation], [heureRepresentation], [idSpectacle] FROM [Representation] WHERE [dateRepresentation] = @date";
                    command.Parameters.AddWithValue("date", date);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToRepresentation();
                        }
                    }
                }
            }
        }

        public IEnumerable<Representation> GetBySpectacle(int idSpec)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT [idRepresentation], [dateRepresentation], [heureRepresentation], [idSpectacle] FROM [Representation] WHERE [idSpectacle] = @idSpec";
                    command.Parameters.AddWithValue("idSpec", idSpec);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return reader.ToRepresentation();
                        }
                    }
                }
            }
        }

        public int Insert(Representation entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO [Representation] ([dateRepresentation], [heureRepresentation], [idSpectacle]) OUTPUT [inserted].[idRepresentation] VALUES (@date,@heure,@idSpec)";
                    command.Parameters.AddWithValue("date", entity.dateRepresentation);
                    command.Parameters.AddWithValue("heure", entity.heureRepresentation);
                    command.Parameters.AddWithValue("idSpec", entity.idSpectacle);
                    connection.Open();
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(int id, Representation entity)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE [Representation] SET [dateRepresentation] = @date,  [heureRepresentation] = @heure , [idSpectacle]= @idSpec WHERE [idRepresentation] = @id)";
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("date", entity.dateRepresentation);
                    command.Parameters.AddWithValue("heure", entity.heureRepresentation);
                    command.Parameters.AddWithValue("idSpec", entity.idSpectacle);
                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
