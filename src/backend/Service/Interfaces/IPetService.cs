using System.Threading.Tasks;
using Domain.Entities;

namespace Service.Interfaces
{
    public interface IPetService
    {
        Task<Pet> GetPetById(int id, bool inclueOwner);
        Task<Pet[]> GetPetsByName(string name, bool inclueOwner);
        Task<int> CreatePet(Pet pet);
        Task<bool> UpdatePet(Pet pet, int oldAccommodationNumber);
        Task<bool> DeletePet(Pet pet);
    }
}