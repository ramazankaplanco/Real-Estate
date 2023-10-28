# Real Estate

Asp.Net Core 7 with N-Tier Architecture Design
 

## About System

 - We designed the system for a company to selling estates, in same time we designed with N-Tier Architecture.

## Getting Started to Real Estate

- Open terminal and run this command; `git clone https://github.com/ramazankaplanco/Real-Estate.git`
- Open Package Manager Console; select `Tumsas.RealEstate.DataAccess` project
- Run this command; `Add-Migration -Context RealEstateDbContext SeedDataInitialMigration`
- and this command; `Update-Database -v -Context RealEstateDbContext`


1. First project for admin panel `Tumsas.RealEstate`; data adding and editing panel.

![image](https://github.com/ramazankaplanco/Real-Estate/assets/16455646/c8a13eb1-abb5-4484-b54e-a8291ac115ec)


#### Run `Tumsas.RealEstate`

- We've added two tables to start with and will continue to improve. For example, the `Users` and `Categories` tables.

![image](https://github.com/ramazankaplanco/Real-Estate/assets/16455646/480851c3-debd-4536-824f-9c4548da3749)

- Add an Edit for CRUD operations.

![image](https://github.com/ramazankaplanco/Real-Estate/assets/16455646/9a3a8e92-6b6a-43f5-a02d-0a3404ea3ce8)


2. Second project for Api `Tumsas.RealEstate.Api`; for public projects or mobile applications.

![image](https://github.com/ramazankaplanco/Real-Estate/assets/16455646/b55b3650-dbbf-410c-bd26-75c1bb4af8dc)


#### Run `Tumsas.RealEstate.Api`
- We've added two controls to start with and will continue to improve. For example, the `Users` and `Categories` endpoints.

![image](https://github.com/ramazankaplanco/Real-Estate/assets/16455646/5c974f9b-90dd-4530-b990-4f087ba5d453)

3. `Tumsas.RealEstate.Public` is an end-user project; it works with API. For it to work, `Tumsas.RealEstate.Public` and `Tumsas.RealEstate.Api` must work at the same time.

#### Run `Tumsas.RealEstate.Public` and `Tumsas.RealEstate.Api` at the same time
- For now, we the Category list via API (`GET api/Categories`). We haven't encountered the other parts yet.

![image](https://github.com/ramazankaplanco/Real-Estate/assets/16455646/6d45df2c-a8f2-49f3-ab04-1586e74f9724)



