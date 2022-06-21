//using DogGo.Models;
//using Microsoft.Data.SqlClient;
//using Microsoft.Extensions.Configuration;
//using System.Collections.Generic;

//namespace DogGo.Repositories
//{
//    public class DogRepository : IDogRepository
//    {
//        private readonly IConfiguration _config;

//        // The constructor accepts an IConfiguration object as a parameter. This class comes from the ASP.NET framework and is useful for retrieving things out of the appsettings.json file like connection strings.
//        public DogRepository(IConfiguration config)
//        {
//            _config = config;
//        }

//        public SqlConnection Connection
//        {
//            get
//            {
//                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
//            }
//        }

//        public List<Dog> GetDogsByOwnerID(int id)
//        {
//            using (SqlConnection conn = Connection)
//            {
//                conn.Open();
//                using (SqlCommand cmd = conn.CreateCommand())
//                {
//                    cmd.CommandText = @"
//                            SELECT d.Id, d.Name, d.OwnerId, d.Breed, o.Name, o.Id as OwnId,         o.Email, o.Address, o.Phone, o.NeighborhoodId
//                            FROM Dog d
//                            JOIN Owner o ON o.Id = d.OwnerId
//                            WHERE o.Id = @id;";

//                    cmd.Parameters.AddWithValue("@id", id);
//                    using (SqlDataReader reader = cmd.ExecuteReader())
//                    {
//                        if (reader.Read())
//                        {
//                            Dog dog = new Dog()
//                            {

//                            }
//                        }
//                    }
//                }
//            }
//            return new List<Dog>();
//        }

//    }
//}
