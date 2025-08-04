using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;

public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<User>> GetUsersAsync() =>
        _db.LoadData<User, dynamic>("dbo.spUsers_GetAll", new { });

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        var results = await _db.LoadData<User, dynamic>("dbo.spUsers_GetById", new { id });

        return results.FirstOrDefault();
    }

    public Task InsertUser(User user) =>
        _db.SaveData("dbo.spUsers_Insert", new
        {
            user.FirstName,
            user.LastName
        });

    public Task UpdateUser(User user) =>
        _db.SaveData("dbo.spUsers_Update", user);

    public Task DeleteUser(Guid id) =>
        _db.SaveData("dbo.spUsers_Delete", new { id });
}
