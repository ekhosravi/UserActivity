using UserActivityAPI.Data;
using UserActivityAPI.Models;
using UserActivityAPI.Services.IServices;

namespace UserActivityAPI.Services
{
    public class StatusService : IStatusService
    {
        private readonly UserContext _db;

        public StatusService(UserContext db)
        {
            _db = db;
        }

        public bool AddStatusAsync(Status status)
        {
            _db.Status.Add(status);
            return save();
        }

        public bool DeleteStatusAsync(Status status)
        {
            _db.Status.Remove(status);
            return save();
        }

        public ICollection<Status> GetAllStatus()
        {
            return _db.Status.OrderBy(a=>a.StatusName).ToList();
        }

        public Status GetStatusById(int statusId)
        {
            return _db.Status.FirstOrDefault(a => a.StatusId == statusId);        
        }

        public bool save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool StatusExists(string statusName)
        {
            bool value = _db.Status.Any(a => a.StatusName.ToLower().Trim() == statusName.ToLower().Trim());
            return value;
        }
        
        public bool StatusExists(int statusId)
        {
            return _db.Status.Any(a => a.StatusId == statusId);
        }

        public bool UpdateStatusAsync(Status status)
        {
            _db.Status.Update(status);
            return save();
        }
    }
}
