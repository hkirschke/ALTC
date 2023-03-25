using ALTC.Infra.JsonPlaceHolder.API.Mapping;
using AutoMapper;

namespace ALTC.Tests.Helpers;

public class MapperHelper
{
    public IMapper Mapper { get; }

    public MapperHelper()
    {
        var config = new MapperConfiguration(opts =>
        {
            opts.AddProfile(new PostMap());
            opts.AddProfile(new UserMap());
        });

        Mapper = config.CreateMapper();
    }
}
