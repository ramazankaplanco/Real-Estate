using Tumsas.RealEstate.Core.DataAccess.EntityFrameworkCore;
using Tumsas.RealEstate.DataAccess.Abstract;
using Tumsas.RealEstate.DataAccess.EntityFrameworkCore;
using Tumsas.RealEstate.Entities;

namespace Tumsas.RealEstate.DataAccess.Repository
{
    public class UserRepository : EntityRepositoryBase<User, RealEstateDbContext>, IUserRepository
    {
        public UserRepository(RealEstateDbContext dataContext) : base(dataContext)
        {

        }
    }
}