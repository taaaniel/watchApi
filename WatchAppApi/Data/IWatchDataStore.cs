using WatchAppApi.Models;

namespace WatchAppApi.Data;

public interface IWatchDataStore
{
    IReadOnlyList<Watch> GetAll();
    Watch? GetById(int id);
}