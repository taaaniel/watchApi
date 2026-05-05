using System.Text.Json;
using System.Text.Json.Serialization;
using WatchAppApi.Models;

namespace WatchAppApi.Data;

public class JsonWatchDataStore : IWatchDataStore
{
    private readonly IReadOnlyList<WatchDto> _watches;

    public JsonWatchDataStore(IWebHostEnvironment environment)
    {
        var filePath = Path.Combine(environment.ContentRootPath, "Data", "watches.json");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Sample watch data file was not found.", filePath);
        }

        using var stream = File.OpenRead(filePath);

        _watches = JsonSerializer.Deserialize<List<WatchDto>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        }) ?? throw new InvalidOperationException("Sample watch data file is empty or invalid.");
    }

    public IReadOnlyList<WatchDto> GetAll() => _watches;

    public WatchDto? GetById(int id) => _watches.FirstOrDefault(watch => watch.Id == id);
}