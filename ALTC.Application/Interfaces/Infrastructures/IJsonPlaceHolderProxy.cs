using ALTC.Application.Models;

namespace ALTC.Application.Interfaces.Infrastructures
{
    public interface IJsonPlaceHolderProxy
    {
        Task<IList<PostModel>> GetPosts(CancellationToken cancellationToken);
        Task<IList<UserModel>> GetUsers(CancellationToken cancellationToken);
    }
}