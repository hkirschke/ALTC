using ALTC.Application.Models;

namespace ALTC.Application.Interfaces.Services;

public interface IJsonPlaceHolderService
{
    Task<IList<PostModel>?> GetPostsAsync(CancellationToken cancellationToken);

    Task<IList<UserModel>?> GetUsersAsync(CancellationToken cancellationToken);

    Task RemovePostsAsync();

    Task RemoveUsersAsync();
}