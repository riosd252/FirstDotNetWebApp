using AutoMapper;
using FirstDotNetWebApp.Data;
using FirstDotNetWebApp.Models;

namespace FirstDotNetWebApp.Configurations;

public class MapperConfig : Profile
{
    public MapperConfig()
    {
        CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
    }
}