using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tumsas.RealEstate.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataInitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildingAges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingAges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FloorNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FloorNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomNumbers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    RoomNumberId = table.Column<int>(type: "int", nullable: false),
                    BuildingAgeId = table.Column<int>(type: "int", nullable: false),
                    FloorNumberId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    GrossSquareMeters = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    NetSquareMeters = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    AdDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstateStatus = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estates_BuildingAges_BuildingAgeId",
                        column: x => x.BuildingAgeId,
                        principalTable: "BuildingAges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estates_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estates_FloorNumbers_FloorNumberId",
                        column: x => x.FloorNumberId,
                        principalTable: "FloorNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estates_RoomNumbers_RoomNumberId",
                        column: x => x.RoomNumberId,
                        principalTable: "RoomNumbers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BuildingAges",
                columns: new[] { "Id", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "", false, "0" },
                    { 2, "", false, "1" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsDeleted", "ParentId", "Title" },
                values: new object[,]
                {
                    { 1, "", false, null, "Residential" },
                    { 2, "", false, null, "Commercial" },
                    { 3, "", false, null, "Land" },
                    { 4, "", false, null, "Buildings" }
                });

            migrationBuilder.InsertData(
                table: "FloorNumbers",
                columns: new[] { "Id", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "", false, "1" },
                    { 2, "", false, "2" }
                });

            migrationBuilder.InsertData(
                table: "RoomNumbers",
                columns: new[] { "Id", "Description", "IsDeleted", "Title" },
                values: new object[,]
                {
                    { 1, "", false, "1+1" },
                    { 2, "", false, "2+1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "IsDeleted", "LastName", "Password", "PhoneNumber" },
                values: new object[] { 1, "admin@admin.com", "System", false, "Admin", "Admin123.", "05503000000" });

            migrationBuilder.InsertData(
                table: "Estates",
                columns: new[] { "Id", "AdDate", "BuildingAgeId", "CategoryId", "Description", "EstateStatus", "FloorNumberId", "GrossSquareMeters", "ImageUrl", "IsDeleted", "Location", "NetSquareMeters", "Price", "RoomNumberId", "Title" },
                values: new object[] { 1, new DateTime(2023, 10, 28, 20, 9, 12, 857, DateTimeKind.Local).AddTicks(6692), 1, 1, "", 1, 1, "120m2", "https://i0.shbdn.com/photos/11/16/63/lthmb_1115111663f4f.jpg", false, "Center of Country", "100m2", 2000000m, 1, "Test Building" });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ParentId",
                table: "Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_BuildingAgeId",
                table: "Estates",
                column: "BuildingAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_CategoryId",
                table: "Estates",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_FloorNumberId",
                table: "Estates",
                column: "FloorNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Estates_RoomNumberId",
                table: "Estates",
                column: "RoomNumberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Estates");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BuildingAges");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "FloorNumbers");

            migrationBuilder.DropTable(
                name: "RoomNumbers");
        }
    }
}
