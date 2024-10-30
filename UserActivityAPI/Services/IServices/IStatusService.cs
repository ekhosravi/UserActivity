using UserActivityAPI.Models;

namespace UserActivityAPI.Services.IServices
{
    public interface IStatusService
    {
        ICollection<Status> GetAllStatus();
        Status GetStatusById(int statusId);
        bool StatusExists(string statusName);
        bool StatusExists(int statusId);
        bool AddStatusAsync(Status status);
        bool UpdateStatusAsync(Status status);
        bool DeleteStatusAsync(Status status);
        bool save();
    }
}
