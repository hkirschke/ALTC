using ALTC.Application.Models;

namespace ALTC.Application.Interfaces.Infrastructures;

public interface IJsonPlaceHolderProxy
{
    Task<IList<PostModel>> GetAllPostsAsync(CancellationToken cancellationToken);

    Task<IList<UserModel>> GetAllUsersAsync(CancellationToken cancellationToken);
}