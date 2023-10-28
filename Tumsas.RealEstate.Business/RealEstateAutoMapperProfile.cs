using AutoMapper;
using Tumsas.RealEstate.DataAccess.Concrete.Dto;
using Tumsas.RealEstate.Entities;

namespace Tumsas.RealEstate.Business
{
    public class RealEstateAutoMapperProfile : Profile
    {
        public RealEstateAutoMapperProfile()
        {
            CreateMap<User, UserDto>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<UserDto, User>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<BuildingAge, BuildingAgeDto>();
            CreateMap<BuildingAgeDto, BuildingAge>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<Estate, EstateDto>();
            CreateMap<EstateDto, Estate>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<FloorNumber, FloorNumberDto>();
            CreateMap<FloorNumberDto, FloorNumber>().ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<RoomNumber, RoomNumberDto>();
            CreateMap<RoomNumberDto, RoomNumber>().ForMember(x => x.Id, opt => opt.Ignore());
        }
    }
}