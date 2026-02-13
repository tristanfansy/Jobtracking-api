using JobTracking.Data;
using JobTracking.Models;
using Microsoft.EntityFrameworkCore;


namespace JobTracking.Repositories;
public class JobTrackingRepository:IJobTrackingRepository
{
    private readonly AppDbContext _db;
    public JobTrackingRepository(AppDbContext db)
    {
        _db=db;
    }

    public Task<List<TrackingData>> GetAllAsync()
        => _db.TrackingDatas.AsNoTracking().ToListAsync();

    public Task<TrackingData?> GetIdAsync(int id)
        => _db.TrackingDatas.AsNoTracking().FirstOrDefaultAsync(a => a.Id ==id);

    public async Task<TrackingData> AddTackingData(TrackingData trackingData)
    {
        _db.TrackingDatas.Add(trackingData);
        await _db.SaveChangesAsync();
        return trackingData;
    }
}