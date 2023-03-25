using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALTC.Infra.Json.API.Dtos;

public sealed class PostsDto
{
    public long? UserId { get; set; }
    public long? Id { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
}
