using ALTC.Application.Interfaces.Services;
using ALTC.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace ALTC.Controllers;

[ApiController]
[Route("odata")]
public class OdataController : ControllerBase
{
    private readonly IJsonPlaceHolderService _jsonPlaceHolderService;
    private readonly ILogger<OdataController> _logger;

    public OdataController(IJsonPlaceHolderService jsonPlaceHolderService, ILogger<OdataController> logger)
    {
        _jsonPlaceHolderService = jsonPlaceHolderService;
        _logger = logger;
    }

    [HttpGet("posts")]
    [ProducesResponseType(typeof(IList<PostModel>), 200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<PostModel>>> GetAllPostsAsync(CancellationToken cancellationToken)
    {
        return Ok(await _jsonPlaceHolderService.GetAllPostsAsync(cancellationToken));
    }


    [HttpGet("users")]
    [ProducesResponseType(typeof(IList<PostModel>), 200)]
    [ProducesResponseType(204)]
    [ProducesResponseType(500)]
    public async Task<ActionResult<IList<UserModel>>> GetAllUsersAsync(CancellationToken cancellationToken)
    {
        return Ok(await _jsonPlaceHolderService.GetAllUsersAsync(cancellationToken));
    }
}