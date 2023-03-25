using System.Text.Json.Serialization;

namespace ALTC.Application.Models;

public class PostModel
{
    [JsonPropertyName("userId")]
    public int? UserId { get; set; }

    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }

    [JsonPropertyName("body")]
    public string? Body { get; set; }
}
