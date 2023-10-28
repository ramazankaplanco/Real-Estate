using Tumsas.RealEstate.Business.Abstract.Base;
using Tumsas.RealEstate.DataAccess.Concrete.Dto;
using Tumsas.RealEstate.DataAccess.Concrete.Dto.Base;

namespace Tumsas.RealEstate.Business.Abstract
{
    public interface IUserService : IServiceBase<UserDto>
    {
        ResponseBase<UserDto> GetByEmail(string email);
    }
}