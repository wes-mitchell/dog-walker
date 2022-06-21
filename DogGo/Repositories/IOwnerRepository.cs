using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using DogGo.Models;

namespace DogGo.Repositories
{
    public interface IOwnerRespository
    {
        List<Owner> GetAllOwners();
        Owner GetOwnerById(int id);
        void AddOwner(Owner owner);
        void UpdateOwner(Owner owner);
        void DeleteOwner(int ownerId);
    }
}
