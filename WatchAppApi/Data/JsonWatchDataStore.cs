using System.Text.Json;
using System.Text.Json.Serialization;
using WatchAppApi.Models;

namespace WatchAppApi.Data;

public class JsonWatchDataStore : IWatchDataStore
{
    private readonly IReadOnlyList<Watch> _watches;

    public JsonWatchDataStore(IWebHostEnvironment environment)
    {
        var filePath = Path.Combine(environment.ContentRootPath, "Data", "watches.json");

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("Sample watch data file was not found.", filePath);
        }

        using var stream = File.OpenRead(filePath);

        _watches = JsonSerializer.Deserialize<List<Watch>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter() }
        }) ?? throw new InvalidOperationException("Sample watch data file is empty or invalid.");
    }

    public IReadOnlyList<Watch> GetAll() => _watches;

    public Watch? GetById(int id) => _watches.FirstOrDefault(watch => watch.Id == id);
}