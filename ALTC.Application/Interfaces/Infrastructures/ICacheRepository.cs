namespace ALTC.Application.Interfaces.Infrastructures;

public interface ICacheRepository
{
    Task<object?> GetAsync<T>(string cacheName);

    Task<bool> RemoveAsync<T>(string cacheName);

    Task SetAsync<T>(string cacheName, T value, int hoursExpiration = 1);
}