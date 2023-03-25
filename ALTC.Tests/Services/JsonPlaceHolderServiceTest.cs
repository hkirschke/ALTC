using ALTC.Application.Interfaces.Infrastructures;
using ALTC.Application.Interfaces.Services;
using ALTC.Application.Models;
using ALTC.Application.Services;
using AutoFixture;
using Moq;

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
    public void Must_Get_List_of_Users_No_Cache_Success()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<UserModel>().ToList();

        _jsonPlaceHolderProxyMock
            .Setup(_ => _.GetUsersAsync(CancellationToken.None))
            .ReturnsAsync(usersMock);

        //Act
        var service = new JsonPlaceHolderService(_jsonPlaceHolderProxyMock.Object, _cacheRepositoryMock.Object);

        var response = service.GetUsersAsync(CancellationToken.None);

        //Assert
        Assert.IsInstanceOfType(response, typeof(IList<UserModel>));
    }

    [TestMethod]
    public void Must_Get_List_of_Posts_No_Cache_Success()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<PostModel>().ToList();

        _jsonPlaceHolderProxyMock
            .Setup(_ => _.GetPostsAsync(CancellationToken.None))
            .ReturnsAsync(usersMock);

        //Act
        var service = new JsonPlaceHolderService(_jsonPlaceHolderProxyMock.Object, _cacheRepositoryMock.Object);

        var response = service.GetUsersAsync(CancellationToken.None);

        //Assert
        Assert.IsInstanceOfType(response, typeof(IList<PostModel>));
    }
}