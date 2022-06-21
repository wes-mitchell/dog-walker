using DogGo.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public class DogRepository : IDogRepository
    {
        private readonly IConfiguration _config;

        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
        public DogRepository(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public List<Dog> GetAllDogs()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Dog";
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Dog> dogs = new List<Dog>();
                        while (reader.Read())
                        {
                            Dog dog = new Dog()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                OwnerId = reader.GetInt32(reader.GetOrdinal("OwnerId")),
                                Breed = reader.GetString(reader.GetOrdinal("Breed")),
                                Notes = !reader.IsDBNull(reader.GetOrdinal("Notes")) ? reader.GetString(reader.GetOrdinal("Notes")) : " ",
                                ImageUrl = !reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? reader.GetString(reader.GetOrdinal("ImageUrl")) : " "
                            };
                            dogs.Add(dog);
                        }
                        return dogs;
                    }
                }
            }
        }
        public Dog GetById(int dogId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT d.Id, d.Name, d.OwnerId, d.Breed, d.Notes, d.ImageUrl, o.Name as OwnerName 
                                        FROM Dog d
                                        JOIN Owner o ON o.Id = d.OwnerId
                                        WHERE d.Id = @dogId";
                    cmd.Parameters.AddWithValue("@dogId", dogId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Dog dog = new Dog
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                OwnerId = reader.GetInt32(reader.GetOrdinal("OwnerId")),
                                Breed = reader.GetString(reader.GetOrdinal("Breed")),
                                Notes = !reader.IsDBNull(reader.GetOrdinal("Notes")) ? reader.GetString(reader.GetOrdinal("Notes")) : " ",
                                ImageUrl = !reader.IsDBNull(reader.GetOrdinal("ImageUrl")) ? reader.GetString(reader.GetOrdinal("ImageUrl")) : " ",
                                Owner = new Owner
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("OwnerId")),
                                    Name = reader.GetString(reader.GetOrdinal("OwnerName"))
                                }
                            };

                            return dog;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public Dog AddDog(Dog dog)
        {
            Dog thisDog = new Dog();
            return thisDog;
        }

        public Dog UpdateDog(Dog dog)
        {
            Dog thisDog = new Dog();
            return thisDog;
        }
        public void DeleteDog(int dogId)
        {
            
        }

        //public List<Dog> GetDogsByOwnerID(int id)
        //{
        //    using (SqlConnection conn = Connection)
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandText = @"
        //                    SELECT d.Id, d.Name, d.OwnerId, d.Breed, o.Name, o.Id as OwnId,         o.Email, o.Address, o.Phone, o.NeighborhoodId
        //                    FROM Dog d
        //                    JOIN Owner o ON o.Id = d.OwnerId
        //                    WHERE o.Id = @id;";

        //            cmd.Parameters.AddWithValue("@id", id);
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    Dog dog = new Dog()
        //                    {

        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return new List<Dog>();
        //}
    }
}
