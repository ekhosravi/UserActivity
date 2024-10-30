using UserActivityAPI.Data;
using UserActivityAPI.Models;
using Microsoft.EntityFrameworkCore;
using UserActivityAPI.Services.IServices;

namespace UserActivityAPI.Services
{
    public class UserService : IUserService
    {
        private readonly UserContext _db;
        public UserService(UserContext db)
        {
                _db= db;
        }

        public bool AddUserAsync(User user)
        {
            _db.Users.Add(user);
            return save();
        }

        public bool DeleteUserAsync(User user)
        {
            _db.Users.Remove(user);
            return save();
        }

        public ICollection<User> GetAllUser()
        {
            return _db.Users.Include(c => c.Status).OrderBy(a=>a.UserName).ToList();
        }

        public User GetUserById(int userId)
        {
            return _db.Users.Include(c => c.Status).FirstOrDefault(a => a.UserID == userId);
        }

        public ICollection<User> GetUsersStatus(int stId)
        {
            return _db.Users.Include(c => c.Status).Where(c => c.StatusId == stId).ToList();
        }

        public bool save()
        {
            return  _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateUserAsync(User user)
        {
            _db.Users.Update(user); 
            return save();  
        }

        public bool UserExists(string username)
        {
            bool value=_db.Users.Any(a=>a.UserName.ToLower().Trim() == username.ToLower().Trim());
            return value;
        }

        public bool UserExists(int userId)
        {
            return _db.Users.Any(a => a.UserID == userId);
        }
    }

}