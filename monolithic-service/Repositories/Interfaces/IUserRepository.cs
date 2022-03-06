using monolithic_service.Models;

namespace monolithic_service.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<int> InsertUser(User user);
        Task<User> GetUser(string userName);
        Task<User> UpdateUser(User user);
        Task<string> DeleteUser(string userName);

    }
}
