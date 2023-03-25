using ALTC.Application.Models;
using ALTC.Infra.Json.API.Dtos;
using AutoMapper;

namespace ALTC.Infra.JsonPlaceHolder.API.Mapping;

public sealed class PostMap : Profile
{
    public PostMap()
    {
        CreateMap<PostDto, PostModel>();
    }
}