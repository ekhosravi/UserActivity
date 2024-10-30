using UserActivityAPI.Models;

namespace UserActivityAPI.Services.IServices
{
    public interface IUserService
    {
        ICollection<User> GetAllUser();
        ICollection<User> GetUsersStatus(int stId);
        User GetUserById(int userId);
        bool UserExists(string username);
        bool UserExists(int userId);
        bool AddUserAsync(User user);
        bool UpdateUserAsync(User user);
        bool DeleteUserAsync(User user);
        bool save();
    }
}
