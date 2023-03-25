﻿using ALTC.Application.Infrastructure;
using ALTC.Application.Models;
using ALTC.Infra.Json.API.Consts;
using ALTC.Infra.Json.API.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ALTC.Infra.Json.API.Proxys;

public sealed class JsonPlaceHolderProxy
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IMapper _mapper;

    public JsonPlaceHolderProxy(IHttpClientFactory httpClientFactory, IMapper mapper)
    {
        _httpClientFactory = httpClientFactory;
        _mapper = mapper;
    } 

 
    public async Task<IList<UserModel>> GetUsers(CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient(HttpClientNames.JsonApi);

        var response = await httpClient.GetAsync(Endpoints.GET_USERS, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        var usersDto = JsonSerializer.Deserialize<IList<UserDto>>(json);

        var usersModel = _mapper.Map<IList<UserModel>>(usersDto);

        return usersModel;
    }


    public async Task<IList<PostModel>> GetPosts(CancellationToken cancellationToken)
    {
        var httpClient = _httpClientFactory.CreateClient(HttpClientNames.JsonApi);

        var response = await httpClient.GetAsync(Endpoints.GET_POSTS, cancellationToken);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync(cancellationToken);

        var postsDto = JsonSerializer.Deserialize<IList<PostDto>>(json);

        var postsModel = _mapper.Map<IList<PostModel>>(postsDto);

        return postsModel;
    }
}