using JobTracking.Data;
using JobTracking.Repositories;
using Microsoft.EntityFrameworkCore;

var builder =WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("TrackingDb"));
builder.Services.AddScoped<IJobTrackingRepository,JobTrackingRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app= builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();


app.Run();
