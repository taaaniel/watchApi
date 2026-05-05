using Microsoft.AspNetCore.Mvc;
using WatchAppApi.Data;
using WatchAppApi.Models;

namespace WatchAppApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WatchesController : ControllerBase
{
    private readonly IWatchDataStore _watchDataStore;

    public WatchesController(IWatchDataStore watchDataStore)
    {
        _watchDataStore = watchDataStore;
    }

    [HttpGet]
    public ActionResult<IReadOnlyList<WatchDto>> GetAll()
    {
        return Ok(_watchDataStore.GetAll());
    }

    [HttpGet("{id:int}")]
    public ActionResult<WatchDto> GetById(int id)
    {
        var watch = _watchDataStore.GetById(id);

        return watch is null ? NotFound() : Ok(watch);
    }
}