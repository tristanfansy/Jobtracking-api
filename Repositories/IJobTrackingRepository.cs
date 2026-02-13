using JobTracking.Models;

namespace JobTracking.Repositories;


public interface IJobTrackingRepository
{
    Task<List<TrackingData>> GetAllAsync();
    Task<TrackingData?> GetIdAsync(int id);
    Task<TrackingData> AddTackingData(TrackingData trackingData);
}