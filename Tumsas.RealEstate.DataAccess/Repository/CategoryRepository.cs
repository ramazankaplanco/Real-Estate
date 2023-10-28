using Tumsas.RealEstate.Core.DataAccess.EntityFrameworkCore;
using Tumsas.RealEstate.DataAccess.Abstract;
using Tumsas.RealEstate.DataAccess.EntityFrameworkCore;
using Tumsas.RealEstate.Entities;

namespace Tumsas.RealEstate.DataAccess.Repository
{
    public class CategoryRepository : EntityRepositoryBase<Category, RealEstateDbContext>, ICategoryRepository
    {
        public CategoryRepository(RealEstateDbContext dataContext) : base(dataContext)
        {

        }
    }
}