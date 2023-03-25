using ALTC.Application.Infrastructure;
using ALTC.Application.Models;
using ALTC.Infra.Json.API.Consts;
using ALTC.Infra.Json.API.Proxys;
using ALTC.Tests.Helpers;
using System.Text.Json;

namespace ALTC.Tests.Proxys;

[TestClass]
[Collection("Mapper")]
public sealed class JsonPlaceHolderProxyTest
{
    private readonly IFixture _fixture;
    private readonly Mock<MapperHelper> _mapperFixture;

    public JsonPlaceHolderProxyTest()
    {
        _fixture = new Fixture();
        _mapperFixture = new Mock<MapperHelper>();
    }

    [TestMethod]
    public async void Must_Get_List_of_Users_Success()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<UserModel>().ToList();

        var httpClientFactoryMock = new HttpClientHelper(HttpClientNames.JsonApi)
                  .SetupGet(Endpoints.GET_USERS, JsonSerializer.Serialize(usersMock))
                  .Build();

        //Act
        var service = new JsonPlaceHolderProxy(httpClientFactoryMock.Object, _mapperFixture.Object.Mapper);

        var response = await service.GetAllUsersAsync(CancellationToken.None);

        //Assert
        Assert.IsInstanceOfType(response, typeof(IList<UserModel>));
    }

    [TestMethod]
    public async void Must_Get_List_of_Posts_Success()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<PostModel>().ToList();

        var httpClientFactoryMock = new HttpClientHelper(HttpClientNames.JsonApi)
                  .SetupGet(Endpoints.GET_USERS, JsonSerializer.Serialize(usersMock))
                  .Build();

        //Act
        var service = new JsonPlaceHolderProxy(httpClientFactoryMock.Object, _mapperFixture.Object.Mapper);

        var response = await service.GetAllPostsAsync(CancellationToken.None);

        //Assert
        Assert.IsInstanceOfType(response, typeof(IList<PostModel>));
    }

    [TestMethod]
    public async void Must_Get_List_of_Users_Error()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<UserModel>().ToList();

        var httpClientFactoryMock = new HttpClientHelper(HttpClientNames.JsonApi)
                  .SetupGet(Endpoints.GET_USERS, JsonSerializer.Serialize(usersMock), System.Net.HttpStatusCode.InternalServerError)
                  .Build();

        //Act
        var service = new JsonPlaceHolderProxy(httpClientFactoryMock.Object, _mapperFixture.Object.Mapper); 

        //Assert
        await Assert.ThrowsExceptionAsync<HttpRequestException>(() => service.GetAllUsersAsync(CancellationToken.None)); 
    }

    [TestMethod]
    public async void Must_Get_List_of_Posts_Error()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<PostModel>().ToList();

        var httpClientFactoryMock = new HttpClientHelper(HttpClientNames.JsonApi)
                  .SetupGet(Endpoints.GET_USERS, JsonSerializer.Serialize(usersMock), System.Net.HttpStatusCode.InternalServerError)
                  .Build();

        //Act
        var service = new JsonPlaceHolderProxy(httpClientFactoryMock.Object, _mapperFixture.Object.Mapper); 

        //Assert
        await Assert.ThrowsExceptionAsync<HttpRequestException>(() => service.GetAllPostsAsync(CancellationToken.None));
    }
}