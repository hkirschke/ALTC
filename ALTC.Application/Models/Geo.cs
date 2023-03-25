using System.Text.Json.Serialization;

namespace ALTC.Infra.Json.API.Dtos;

public sealed class Geo
{
    [JsonPropertyName("lat")]
    public string? Lat { get; set; }


    [JsonPropertyName("lng")]
    public string? Lng { get; set; }
}
