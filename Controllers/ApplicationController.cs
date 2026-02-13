using JobTracking.Models;
using JobTracking.Repositories;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ApplicationController : Controller
{
    private readonly IJobTrackingRepository _repo;
    public ApplicationController(IJobTrackingRepository repo)
    {
        _repo=repo;
    }

    [HttpGet]
    public async Task<ActionResult<List<SearchDto>>> GetAll()
    {
        var entities = await _repo.GetAllAsync();
        var result =entities.Select(MapToDto).ToList();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SearchDto>> GetId(int id)
    {
        var entity =await _repo.GetIdAsync(id);
        if (entity is null) return NotFound();
        return Ok(MapToDto(entity));
    }
    [HttpPost]
    public async Task<ActionResult<SearchDto>> Create(CreateDto dto)
    {
        var entity = new TrackingData
        {
            Name=dto.name,
            Age=dto.age,
            Position=dto.position
        };
        var created = await _repo.AddTackingData(entity);
        var resultDto = MapToDto(created);
        return CreatedAtAction(nameof(GetId), new { id = resultDto.Id }, resultDto);

    }
    private SearchDto MapToDto(TrackingData t) => new()
    {
        Id=t.Id,
        Name=t.Name,
        Age=t.Age,
        Position=t.Position
    };
}