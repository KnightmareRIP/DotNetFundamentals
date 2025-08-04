using DataAccess.Models;

namespace DataAccess.Data
{
    public interface IUserData
    {
        Task DeleteUser(Guid id);
        Task<User?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<User>> GetUsersAsync();
        Task InsertUser(User user);
        Task UpdateUser(User user);
    }
}