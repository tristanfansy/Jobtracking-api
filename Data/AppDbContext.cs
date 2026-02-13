using Microsoft.EntityFrameworkCore;
using JobTracking.Models;

namespace JobTracking.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<TrackingData> TrackingDatas => Set<TrackingData>();
}