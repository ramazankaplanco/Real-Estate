using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Tumsas.RealEstate.DataAccess.EntityFrameworkCore
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<RealEstateDbContext>
    {
        public RealEstateDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RealEstateDbContext>();

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=RealEstate;Integrated Security=True;MultipleActiveResultSets=True;");

            return new RealEstateDbContext(optionsBuilder.Options);
        }
    }
}