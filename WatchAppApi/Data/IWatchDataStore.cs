using WatchAppApi.Models;

namespace WatchAppApi.Data;

public interface IWatchDataStore
{
    IReadOnlyList<WatchDto> GetAll();
    WatchDto? GetById(int id);
}