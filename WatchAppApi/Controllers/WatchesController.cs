using Microsoft.AspNetCore.Mvc;
using WatchAppApi.Data;
using WatchAppApi.Models;

namespace WatchAppApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchesController : ControllerBase
{
    private readonly IWatchRepository _watchRepository;

    public WatchesController(IWatchRepository repository)
    {
        _watchRepository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Watch>>> GetAll()
    {
        var watches = await _watchRepository.GetAllAsync();

        return Ok(watches);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Watch>> GetById(int id)
    {
        var watch = await _watchRepository.GetByIdAsync(id);

        return watch is null ? NotFound() : Ok(watch);
    }

    [HttpPost]
    public async Task<ActionResult<Watch>> Create(Watch watch)
    {
        var createdWatch = await _watchRepository.CreateAsync(watch);

        return CreatedAtAction(nameof(GetById), new { id = createdWatch.Id }, createdWatch);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Watch watch)
    {
        if (watch.Id != 0 && watch.Id != id)
        {
            return BadRequest("The watch id in the route must match the request body.");
        }

        watch.Id = id;

        var updated = await _watchRepository.UpdateAsync(id, watch);

        return updated ? NoContent() : NotFound();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _watchRepository.DeleteAsync(id);

        return deleted ? NoContent() : NotFound();
    }
}