﻿using DogGo.Models;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace DogGo.Repositories
{
    public interface IDogRepository
    {
        List<Dog> GetAllDogs();
        Dog GetById(int id);
        Dog AddDog(Dog dog);
        Dog UpdateDog(Dog dog);
        void DeleteDog(int dogId);
        //List<Dog> GetDogsByOwner(int id);
    }
}
