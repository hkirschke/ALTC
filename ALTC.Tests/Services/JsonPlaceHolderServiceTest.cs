using ALTC.Application.Interfaces.Infrastructures;
using ALTC.Application.Models;
using ALTC.Application.Services;

namespace ALTC.Tests.Services;

[TestClass]
public sealed class JsonPlaceHolderServiceTest
{
    private readonly Mock<IJsonPlaceHolderProxy> _jsonPlaceHolderProxyMock;
    private readonly Mock<ICacheRepository> _cacheRepositoryMock;
    private readonly IFixture _fixture;

    public JsonPlaceHolderServiceTest()
    {
        _jsonPlaceHolderProxyMock = new Mock<IJsonPlaceHolderProxy>();
        _cacheRepositoryMock = new Mock<ICacheRepository>();
        _fixture = new Fixture();
    }

    [TestMethod]
    public async void Must_Get_List_of_Users_No_Cache_Success()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<UserModel>().ToList();

        _jsonPlaceHolderProxyMock
            .Setup(_ => _.GetAllUsersAsync(CancellationToken.None))
            .ReturnsAsync(usersMock);

        //Act
        var service = new JsonPlaceHolderService(_jsonPlaceHolderProxyMock.Object, _cacheRepositoryMock.Object);

        var response = await service.GetAllUsersAsync(CancellationToken.None);

        //Assert
        Assert.IsInstanceOfType(response, typeof(IList<UserModel>));
    }

    [TestMethod]
    public async void Must_Get_List_of_Posts_No_Cache_Success()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<PostModel>().ToList();

        _jsonPlaceHolderProxyMock
            .Setup(_ => _.GetAllPostsAsync(CancellationToken.None))
            .ReturnsAsync(usersMock);

        //Act
        var service = new JsonPlaceHolderService(_jsonPlaceHolderProxyMock.Object, _cacheRepositoryMock.Object);

        var response = await service.GetAllUsersAsync(CancellationToken.None);

        //Assert
        Assert.IsInstanceOfType(response, typeof(IList<PostModel>));
    }
}