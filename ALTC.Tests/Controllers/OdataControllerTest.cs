using ALTC.Application.Interfaces.Infrastructures;
using ALTC.Application.Interfaces.Services;
using ALTC.Application.Models;
using ALTC.Application.Services;
using ALTC.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ALTC.Tests.Services;

[TestClass]
public sealed class OdataControllerTest
{
    private readonly Mock<IJsonPlaceHolderService> _jsonPlaceHolderServiceMock;
    private readonly Mock<ILogger<OdataController>> _loggerMock;
    private readonly IFixture _fixture;

    public OdataControllerTest()
    {
        _jsonPlaceHolderServiceMock = new Mock<IJsonPlaceHolderService>();
        _loggerMock = new Mock<ILogger<OdataController>>();
        _fixture = new Fixture();
    }

    [TestMethod]
    public async void Must_Get_List_of_Users_Success()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<UserModel>().ToList();

        _jsonPlaceHolderServiceMock
            .Setup(_ => _.GetAllUsersAsync(CancellationToken.None))
            .ReturnsAsync(usersMock);

        //Act
        var controller = new OdataController(_jsonPlaceHolderServiceMock.Object, _loggerMock.Object);

        var response = await controller.GetAllUsersAsync(CancellationToken.None);

        //Assert
        Assert.IsInstanceOfType(response, typeof(ActionResult<IList<UserModel>>));
    }

    [TestMethod]
    public async void Must_Get_List_of_Posts_Success()
    {
        //Arrange
        var usersMock = _fixture.CreateMany<PostModel>().ToList();

        _jsonPlaceHolderServiceMock
            .Setup(_ => _.GetAllPostsAsync(CancellationToken.None))
            .ReturnsAsync(usersMock);

        //Act
        var controller = new OdataController(_jsonPlaceHolderServiceMock.Object, _loggerMock.Object);

        var response = await controller.GetAllUsersAsync(CancellationToken.None);

        //Assert
        Assert.IsInstanceOfType(response, typeof(ActionResult<IList<PostModel>>));
    }
}