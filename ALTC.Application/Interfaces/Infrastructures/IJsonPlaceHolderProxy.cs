using ALTC.Application.Models;

namespace ALTC.Application.Interfaces.Infrastructures;

public interface IJsonPlaceHolderProxy
{
    Task<IList<PostModel>> GetPostsAsync(CancellationToken cancellationToken);

    Task<IList<UserModel>> GetUsersAsync(CancellationToken cancellationToken);
}