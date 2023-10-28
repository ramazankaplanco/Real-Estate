using Microsoft.EntityFrameworkCore;
using Tumsas.RealEstate.Core.Enums;
using Tumsas.RealEstate.Entities;

namespace Tumsas.RealEstate.DataAccess.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
               new User
               {
                   Id = 1,
                   FirstName = "System",
                   LastName = "Admin",
                   Email = "admin@admin.com",
                   Password = "Admin123.",
                   PhoneNumber = "05503000000"
               });

            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    ParentId = null,
                    Title = "Residential",
                    Description = ""
                },
                new Category
                {
                    Id = 2,
                    ParentId = null,
                    Title = "Commercial",
                    Description = ""
                },
                new Category
                {
                    Id = 3,
                    ParentId = null,
                    Title = "Land",
                    Description = ""
                },
                new Category
                {
                    Id = 4,
                    ParentId = null,
                    Title = "Buildings",
                    Description = ""
                });

            modelBuilder.Entity<BuildingAge>().HasData(
                new BuildingAge
                {
                    Id = 1,
                    Title = "0",
                    Description = ""
                },
                new BuildingAge
                {
                    Id = 2,
                    Title = "1",
                    Description = ""
                });

            modelBuilder.Entity<FloorNumber>().HasData(
                new FloorNumber
                {
                    Id = 1,
                    Title = "1",
                    Description = ""
                },
                new FloorNumber
                {
                    Id = 2,
                    Title = "2",
                    Description = ""
                });

            modelBuilder.Entity<RoomNumber>().HasData(
                new RoomNumber
                {
                    Id = 1,
                    Title = "1+1",
                    Description = ""
                },
                new RoomNumber
                {
                    Id = 2,
                    Title = "2+1",
                    Description = ""
                });

            modelBuilder.Entity<Estate>().HasData(
                new Estate
                {
                    Id = 1,
                    CategoryId = 1,
                    RoomNumberId = 1,
                    BuildingAgeId = 1,
                    FloorNumberId = 1,
                    Title = "Test Building",
                    Price = 2000000,
                    ImageUrl = "https://i0.shbdn.com/photos/11/16/63/lthmb_1115111663f4f.jpg",
                    GrossSquareMeters = "120m2",
                    NetSquareMeters = "100m2",
                    AdDate = DateTime.Now,
                    EstateStatus = EstateStatus.ForSale,
                    Location = "Center of Country",
                    Description = ""
                });
        }
    }
}