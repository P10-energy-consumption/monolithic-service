using monolithic_service.Models;

namespace monolithic_service.Repositories.Interfaces
{
    public interface IPetRepository
    {
        Task<int> InsertPet(Pet pet);
        Task<int> UpdatePet(Pet pet);
        Task<int> InsertPetPhoto(Guid photoId, int petId, string metaData, string url);
        Task<int> DeletePet(int petId);
        Task<Pet> GetPet(int petId);
        Task<List<Pet>> GetPetByStatus(PetStatus status);
    }
}
