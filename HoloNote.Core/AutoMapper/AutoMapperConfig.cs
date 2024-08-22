using AutoMapper;
using HoloNote.Core.AutoMapper.Profiles;

namespace HoloNote.Core.AutoMapper;

public class AutoMapperConfig
{
    public static IMapper Init()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new ContractToCqrsProfile());
        });

        return config.CreateMapper();
    }
}
