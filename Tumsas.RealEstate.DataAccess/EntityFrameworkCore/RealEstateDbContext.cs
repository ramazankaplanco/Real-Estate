using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Tumsas.RealEstate.DataAccess.Extensions;
using Tumsas.RealEstate.Entities;

namespace Tumsas.RealEstate.DataAccess.EntityFrameworkCore
{
    public class RealEstateDbContext : DbContext
    {
        public RealEstateDbContext()
        {
        }

        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BuildingAge> BuildingAges { get; set; }
        public DbSet<FloorNumber> FloorNumbers { get; set; }
        public DbSet<RoomNumber> RoomNumbers { get; set; }
        public DbSet<Estate> Estates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }

        // Handle dispose
        public override void Dispose()
        {
            base.Dispose();
        }

        // Handle error
        public override int SaveChanges()
        {
            try
            {
                var result = base.SaveChanges();

                return result;
            }
            catch (Exception exception)
            {
                Trace.TraceError(exception.ToString());

                throw;
            }
        }
    }
}