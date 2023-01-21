using APBD_04.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace APBD_04.Services
{
    public class DbService : IDbService
    {
        private IConfiguration _configuration;
        public DbService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ICollection<Animal> GetAnimals()
        {
            ICollection<Animal> animals = new List<Animal>();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM Animal";

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    animals.Add(new Animal()
                    {
                        IdAnimal = (int)reader["IdAnimal"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Category = reader["Category"].ToString(),
                        Area = reader["Area"].ToString()
                    });
                }
            }

            return animals;
        }

        public Animal GetAnimal(int idAnimal)
        {
            Animal animal = new Animal();
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
                cmd.CommandText = "SELECT * FROM Animal WHERE IdAnimal = @idAnimal";

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    animal = new Animal()
                    {
                        IdAnimal = (int)reader["IdAnimal"],
                        Name = reader["Name"].ToString(),
                        Description = reader["Description"].ToString(),
                        Category = reader["Category"].ToString(),
                        Area = reader["Area"].ToString()
                    };
                }
            }

            return animal;
        }

        public int AddAnimal(Animal animal)
        {
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@name", animal.Name);
                cmd.Parameters.AddWithValue("@description", animal.Description);
                cmd.Parameters.AddWithValue("@category", animal.Category);
                cmd.Parameters.AddWithValue("@area", animal.Area);
                cmd.CommandText = "insert into Animal(Name, Description, Category, Area) values(@name, @description, @category, @area)";

                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }

        public int RemoveAnimal(int idAnimal)
        {
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
                cmd.CommandText = "DELETE FROM Animal WHERE IdAnimal = @idAnimal";

                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;

        }

        public int UpdateAnimal(Animal animal, int idAnimal)
        {
            int rowsAffected = 0;
            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("ProductionDb")))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@idAnimal", idAnimal);
                cmd.Parameters.AddWithValue("@name", animal.Name);
                cmd.Parameters.AddWithValue("@description", animal.Description);
                cmd.Parameters.AddWithValue("@category", animal.Category);
                cmd.Parameters.AddWithValue("@area", animal.Area);
                cmd.CommandText = "UPDATE Animal SET Name = @name, Description = @description, Category = @category, Area = @area WHERE IdAnimal = @idAnimal";

                con.Open();
                rowsAffected = cmd.ExecuteNonQuery();
            }
            return rowsAffected;
        }
    }
}
