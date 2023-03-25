using ALTC.Application.Consts;
using ALTC.Application.Interfaces.Infrastructures;
using ALTC.Application.Interfaces.Services;
using ALTC.Application.Models;

namespace ALTC.Application.Services;

public sealed class JsonPlaceHolderService : IJsonPlaceHolderService
{
    private readonly IJsonPlaceHolderProxy _jsonPlaceHolderProxy;
    private readonly ICacheRepository _cacheRepository;

    public JsonPlaceHolderService(IJsonPlaceHolderProxy jsonPlaceHolderProxy, ICacheRepository cacheRepository)
    {
        _jsonPlaceHolderProxy = jsonPlaceHolderProxy;
        _cacheRepository = cacheRepository;
    }

    public async Task<IList<UserModel>?> GetUsersAsync(CancellationToken cancellationToken)
    {
        var usersModel = await _cacheRepository.GetAsync<IList<UserModel>>(CacheNames.CACHE_NAME_ALL_USERS);

        if (usersModel is null)
        {
            usersModel = await _jsonPlaceHolderProxy.GetUsersAsync(cancellationToken);

            if (usersModel is not null)
            {
                await _cacheRepository.SetAsync(CacheNames.CACHE_NAME_ALL_USERS, usersModel);

                return (IList<UserModel>)usersModel;
            }

            return null;
        }

        return (IList<UserModel>)usersModel;
    }


    public async Task<IList<PostModel>?> GetPostsAsync(CancellationToken cancellationToken)
    {
        var postModel = await _cacheRepository.GetAsync<IList<UserModel>>(CacheNames.CACHE_NAME_ALL_POSTS);

        if (postModel is null)
        {
            postModel = await _jsonPlaceHolderProxy.GetUsersAsync(cancellationToken);

            if (postModel is not null)
            {
                await _cacheRepository.SetAsync(CacheNames.CACHE_NAME_ALL_USERS, postModel);

                return (IList<PostModel>)postModel;
            }

            return null;
        }

        return (IList<PostModel>)postModel;
    }


    public async Task RemovePostsAsync()
    {
        await _cacheRepository.RemoveAsync<IList<PostModel>>(CacheNames.CACHE_NAME_ALL_POSTS);
    }


    public async Task RemoveUsersAsync()
    {
        await _cacheRepository.RemoveAsync<IList<UserModel>>(CacheNames.CACHE_NAME_ALL_USERS);
    }
}