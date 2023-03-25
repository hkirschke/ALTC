using ALTC.Application.Models;

namespace ALTC.Application.Interfaces.Services;

public interface IJsonPlaceHolderService
{
    Task<IList<PostModel>?> GetAllPostsAsync(CancellationToken cancellationToken);

    Task<IList<UserModel>?> GetAllUsersAsync(CancellationToken cancellationToken);

    Task RemovePostsAsync();

    Task RemoveUsersAsync();
}