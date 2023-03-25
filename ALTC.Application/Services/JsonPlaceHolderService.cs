using ALTC.Application.Interfaces.Infrastructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALTC.Application.Services;

public sealed class JsonPlaceHolderService
{
    private readonly IJsonPlaceHolderProxy _jsonPlaceHolderProxy;
    private readonly ICacheRepository _cacheRepository;

    public JsonPlaceHolderService(IJsonPlaceHolderProxy jsonPlaceHolderProxy, ICacheRepository cacheRepository)
    {
        _jsonPlaceHolderProxy = jsonPlaceHolderProxy;
        _cacheRepository = cacheRepository;
    }


}
