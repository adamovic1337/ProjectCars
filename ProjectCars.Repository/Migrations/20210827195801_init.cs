using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCars.Repository.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FuelTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufacturers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Engines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CubicCapacity = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    Power = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engines_FuelTypes_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: false),
                    EngineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarModels_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarModels_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CarServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarServices_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarServices_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Vin = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    FirstRegistration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_CarModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "CarModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Repairs = table.Column<string>(type: "text", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CarServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Maintenance_CarServices_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserCars",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCars", x => new { x.CarId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserCars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserDescription = table.Column<string>(type: "text", nullable: false),
                    Appointment = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RepairEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CarServiceId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    UserCarsCarId = table.Column<int>(type: "int", nullable: true),
                    UserCarsUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_CarServices_CarServiceId",
                        column: x => x.CarServiceId,
                        principalTable: "CarServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_Status_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_UserCars_UserCarsCarId_UserCarsUserId",
                        columns: x => new { x.UserCarsCarId, x.UserCarsUserId },
                        principalTable: "UserCars",
                        principalColumns: new[] { "CarId", "UserId" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceRequest_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cayman Islands" },
                    { 118, "Bermuda" },
                    { 119, "Dominican Republic" },
                    { 120, "Aruba" },
                    { 121, "Moldova" },
                    { 122, "Greece" },
                    { 123, "Nigeria" },
                    { 117, "Gabon" },
                    { 124, "Papua New Guinea" },
                    { 129, "Anguilla" },
                    { 130, "Uruguay" },
                    { 131, "Indonesia" },
                    { 132, "Burkina Faso" },
                    { 133, "Slovakia (Slovak Republic)" },
                    { 134, "Panama" },
                    { 126, "Saint Barthelemy" },
                    { 135, "Faroe Islands" },
                    { 114, "Paraguay" },
                    { 112, "Botswana" },
                    { 86, "Libyan Arab Jamahiriya" },
                    { 87, "Sri Lanka" },
                    { 89, "Pakistan" },
                    { 91, "Samoa" },
                    { 92, "Jersey" },
                    { 94, "Saint Martin" },
                    { 113, "Northern Mariana Islands" },
                    { 99, "Yemen" },
                    { 104, "Lao People's Democratic Republic" },
                    { 105, "Jamaica" },
                    { 108, "Solomon Islands" },
                    { 109, "Virgin Islands, British" },
                    { 110, "United States of America" },
                    { 111, "Tonga" },
                    { 100, "Swaziland" },
                    { 137, "Liberia" },
                    { 138, "Brazil" },
                    { 139, "Comoros" },
                    { 174, "Cameroon" },
                    { 175, "Cuba" },
                    { 176, "Mauritania" },
                    { 179, "Azerbaijan" },
                    { 182, "Christmas Island" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 185, "Malta" },
                    { 172, "Cocos (Keeling) Islands" },
                    { 186, "Cook Islands" },
                    { 189, "Iran" },
                    { 190, "Uganda" },
                    { 191, "Bosnia and Herzegovina" },
                    { 192, "Liechtenstein" },
                    { 196, "Saint Helena" },
                    { 198, "Venezuela" },
                    { 188, "Syrian Arab Republic" },
                    { 171, "Burundi" },
                    { 169, "Ireland" },
                    { 166, "Saint Pierre and Miquelon" },
                    { 140, "Benin" },
                    { 141, "South Georgia and the South Sandwich Islands" },
                    { 142, "Andorra" },
                    { 143, "Western Sahara" },
                    { 145, "New Caledonia" },
                    { 147, "Saudi Arabia" },
                    { 149, "United Kingdom" },
                    { 150, "Seychelles" },
                    { 151, "India" },
                    { 152, "Costa Rica" },
                    { 153, "Georgia" },
                    { 155, "Ethiopia" },
                    { 157, "United States Minor Outlying Islands" },
                    { 162, "Belgium" },
                    { 163, "Senegal" },
                    { 85, "Austria" },
                    { 84, "Netherlands" },
                    { 90, "Malaysia" },
                    { 82, "China" },
                    { 22, "Mauritius" },
                    { 23, "Guadeloupe" },
                    { 24, "Singapore" },
                    { 25, "United Arab Emirates" },
                    { 26, "Mexico" },
                    { 28, "Zambia" },
                    { 21, "Rwanda" },
                    { 29, "El Salvador" },
                    { 31, "Madagascar" },
                    { 32, "Bouvet Island (Bouvetoya)" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 83, "Mozambique" },
                    { 34, "Gibraltar" },
                    { 36, "Palestinian Territory" },
                    { 37, "Niger" },
                    { 30, "Bulgaria" },
                    { 20, "Finland" },
                    { 19, "Poland" },
                    { 18, "Monaco" },
                    { 2, "Equatorial Guinea" },
                    { 3, "Albania" },
                    { 4, "Montenegro" },
                    { 5, "Armenia" },
                    { 6, "Tokelau" },
                    { 7, "Trinidad and Tobago" },
                    { 8, "Wallis and Futuna" },
                    { 9, "Italy" },
                    { 10, "Belarus" },
                    { 11, "Malawi" },
                    { 12, "Timor-Leste" },
                    { 13, "Niue" },
                    { 14, "Guernsey" },
                    { 15, "Mongolia" },
                    { 16, "Spain" },
                    { 38, "Republic of Korea" },
                    { 39, "Denmark" },
                    { 33, "Montserrat" },
                    { 41, "Netherlands Antilles" },
                    { 65, "Marshall Islands" },
                    { 66, "Iraq" },
                    { 67, "France" },
                    { 40, "Ecuador" },
                    { 69, "Cyprus" },
                    { 71, "Colombia" },
                    { 64, "French Polynesia" },
                    { 73, "Guam" },
                    { 75, "Norway" },
                    { 76, "Pitcairn Islands" },
                    { 77, "Peru" },
                    { 78, "Sierra Leone" },
                    { 79, "Maldives" },
                    { 80, "Vanuatu" },
                    { 74, "Kiribati" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 63, "Reunion" },
                    { 68, "Germany" },
                    { 60, "Kuwait" },
                    { 42, "Antarctica (the territory South of 60 deg S)" },
                    { 43, "Switzerland" },
                    { 61, "Slovenia" },
                    { 45, "Estonia" },
                    { 46, "Virgin Islands, U.S." },
                    { 47, "Turks and Caicos Islands" },
                    { 49, "Honduras" },
                    { 44, "Mali" },
                    { 53, "Falkland Islands (Malvinas)" },
                    { 54, "New Zealand" },
                    { 56, "Morocco" },
                    { 57, "Turkey" },
                    { 58, "Congo" },
                    { 59, "Norfolk Island" },
                    { 52, "Angola" }
                });

            migrationBuilder.InsertData(
                table: "FuelTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Electric" },
                    { 3, "Petrol + LPG" },
                    { 1, "Diesel" },
                    { 2, "Petrol" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "User" },
                    { 3, "ServiceOwner" }
                });

            migrationBuilder.InsertData(
                table: "Status",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 4, "Ready for pick up" },
                    { 1, "Pending" },
                    { 2, "Accepted" },
                    { 3, "Repairing" },
                    { 5, "Completed" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 63, 1, "Monahanton" },
                    { 64, 114, "Lake Darronchester" },
                    { 27, 114, "West Liana" },
                    { 150, 113, "South Dangelo" },
                    { 282, 112, "Lake Vitaland" },
                    { 221, 112, "Amyberg" },
                    { 281, 111, "Lake Anne" },
                    { 205, 111, "West Gabechester" },
                    { 118, 111, "South Roelfort" },
                    { 159, 110, "West Jailyn" },
                    { 50, 110, "Harberfort" },
                    { 275, 108, "Germanland" },
                    { 235, 108, "South Brown" },
                    { 241, 105, "Port Casey" },
                    { 128, 105, "West Myrtisburgh" },
                    { 230, 100, "Harbershire" },
                    { 148, 99, "Ernserbury" },
                    { 233, 94, "Cartwrightfort" },
                    { 242, 114, "New Maryam" },
                    { 248, 114, "Leuschkemouth" },
                    { 270, 117, "Paucekview" },
                    { 21, 118, "Nikolasville" },
                    { 210, 133, "South River" },
                    { 260, 132, "East Cassietown" },
                    { 108, 131, "Aglaeland" },
                    { 251, 130, "Dibbertberg" },
                    { 110, 130, "South Andrew" },
                    { 279, 129, "Heaneyshire" },
                    { 173, 129, "Cameronton" },
                    { 203, 126, "Francisfort" },
                    { 23, 94, "Gottliebside" },
                    { 134, 126, "New Adamview" },
                    { 11, 124, "O'Connerland" },
                    { 62, 123, "West Corbin" },
                    { 13, 122, "Williamsonburgh" },
                    { 253, 120, "Loganport" },
                    { 54, 120, "Nienowmouth" },
                    { 35, 119, "Leuschkeview" },
                    { 212, 118, "Brownburgh" },
                    { 174, 118, "Gorczanyfurt" },
                    { 26, 126, "East Vladimirborough" },
                    { 202, 92, "Lake Delilah" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 177, 92, "Gottliebberg" },
                    { 271, 91, "New Stanleystad" },
                    { 30, 78, "Myrticeview" },
                    { 209, 77, "East Elsieshire" },
                    { 135, 77, "New Felicita" },
                    { 246, 76, "Selenashire" },
                    { 196, 76, "Boscoton" },
                    { 191, 76, "South Nolanmouth" },
                    { 165, 76, "Port Valerie" },
                    { 83, 76, "Port Peteport" },
                    { 85, 78, "East Adam" },
                    { 263, 75, "Shanieville" },
                    { 220, 74, "Port Mertieton" },
                    { 143, 74, "Wilmaland" },
                    { 75, 74, "West Eliseborough" },
                    { 46, 73, "Adellchester" },
                    { 255, 69, "Port Rashad" },
                    { 252, 69, "Port Jeramie" },
                    { 162, 69, "Batzview" },
                    { 127, 69, "Port Zackchester" },
                    { 114, 75, "Port Reynaberg" },
                    { 278, 133, "Lake Duncan" },
                    { 4, 79, "Terrychester" },
                    { 201, 79, "Westmouth" },
                    { 161, 91, "Lake Alanisland" },
                    { 178, 90, "North Llewellyn" },
                    { 99, 90, "North Ned" },
                    { 47, 89, "Schowalterhaven" },
                    { 48, 87, "New Raina" },
                    { 236, 86, "Ebertbury" },
                    { 167, 86, "Hilllmouth" },
                    { 141, 86, "Konopelskimouth" },
                    { 194, 79, "Leathatown" },
                    { 95, 86, "North Tillmanmouth" },
                    { 283, 85, "Winfieldton" },
                    { 37, 85, "Darrinchester" },
                    { 257, 84, "Champlinhaven" },
                    { 213, 84, "Skilesbury" },
                    { 107, 82, "Anneberg" },
                    { 6, 82, "Kerlukemouth" },
                    { 98, 80, "Kihnborough" },
                    { 68, 80, "Kenhaven" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 20, 86, "Khalidton" },
                    { 77, 68, "Alliehaven" },
                    { 204, 134, "Port Marcbury" },
                    { 17, 138, "Elinoremouth" },
                    { 14, 176, "Lake Terrance" },
                    { 277, 175, "Lorineland" },
                    { 42, 174, "Lake Svenhaven" },
                    { 238, 172, "Port Marcelina" },
                    { 157, 172, "West Herminiomouth" },
                    { 154, 172, "Lake Brettshire" },
                    { 211, 171, "Fisherberg" },
                    { 168, 171, "East Dale" },
                    { 140, 171, "Jalenside" },
                    { 84, 171, "Kaileeville" },
                    { 24, 171, "Wilsonville" },
                    { 12, 171, "Bodemouth" },
                    { 292, 169, "North Ressie" },
                    { 190, 169, "Danfort" },
                    { 187, 169, "Ulisesstad" },
                    { 169, 169, "Priceburgh" },
                    { 101, 169, "East Rosettaberg" },
                    { 139, 176, "Port Alfred" },
                    { 180, 176, "Beckerfort" },
                    { 87, 182, "Vernieton" },
                    { 240, 185, "New Roel" },
                    { 176, 196, "Colemouth" },
                    { 94, 196, "East Zoeyland" },
                    { 184, 192, "West Kevonstad" },
                    { 103, 192, "North Adolfmouth" },
                    { 36, 192, "Karafurt" },
                    { 265, 191, "Lake Gabe" },
                    { 234, 191, "East Maurice" },
                    { 55, 191, "Santiagoton" },
                    { 65, 169, "Wolfhaven" },
                    { 18, 191, "Yesseniashire" },
                    { 164, 190, "Stiedemannville" },
                    { 73, 190, "West Jarod" },
                    { 294, 189, "Venabury" },
                    { 198, 188, "West Ariel" },
                    { 43, 188, "Lake Colton" },
                    { 28, 188, "New Vernon" },
                    { 287, 186, "New Porter" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 40, 186, "East Molly" },
                    { 285, 190, "Port Karleeview" },
                    { 272, 166, "Chelsiemouth" },
                    { 266, 166, "Stiedemannburgh" },
                    { 145, 163, "South Dimitrifurt" },
                    { 113, 147, "North Damian" },
                    { 49, 147, "West Naomieburgh" },
                    { 15, 147, "East Juniortown" },
                    { 249, 145, "East Ryantown" },
                    { 273, 143, "Ricoport" },
                    { 130, 143, "West Rashad" },
                    { 120, 143, "Abshirestad" },
                    { 117, 143, "Lake Mathiasside" },
                    { 231, 147, "Rohanville" },
                    { 106, 143, "New Pauline" },
                    { 33, 142, "South Dominic" },
                    { 259, 141, "Hellenside" },
                    { 239, 141, "Monahantown" },
                    { 147, 141, "North Hallie" },
                    { 142, 141, "Juliastad" },
                    { 222, 140, "Lawrencemouth" },
                    { 217, 139, "Lake Jovaniton" },
                    { 171, 139, "South Boydstad" },
                    { 300, 142, "Port Taylor" },
                    { 71, 135, "Port Ricardoton" },
                    { 280, 147, "Lake Wallace" },
                    { 256, 149, "Port Vita" },
                    { 119, 163, "South Ayanaview" },
                    { 19, 163, "South Elijahburgh" },
                    { 102, 162, "Herzogborough" },
                    { 82, 162, "Lake Yasmineville" },
                    { 78, 162, "McDermottville" },
                    { 299, 157, "North Rosalind" },
                    { 218, 157, "Alfredhaven" },
                    { 146, 157, "West Karolannstad" },
                    { 34, 149, "West Hendersonmouth" },
                    { 262, 155, "Jedidiahmouth" },
                    { 136, 152, "Loyshire" },
                    { 89, 152, "Hesselville" },
                    { 25, 151, "West Osborne" },
                    { 295, 150, "Kiraview" },
                    { 268, 150, "Port Birdie" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 166, 150, "Corwinbury" },
                    { 297, 149, "New Ianfurt" },
                    { 284, 149, "Connerland" },
                    { 189, 155, "Jaylenview" },
                    { 51, 67, "Norvalborough" },
                    { 45, 105, "Lake Gideonmouth" },
                    { 16, 65, "Kirlinberg" },
                    { 70, 30, "Port Hollie" },
                    { 22, 30, "Thielburgh" },
                    { 296, 29, "Aubreefurt" },
                    { 243, 29, "South Nathanielview" },
                    { 225, 29, "D'angelohaven" },
                    { 53, 29, "South Eulah" },
                    { 52, 29, "Kentonbury" },
                    { 124, 30, "West Lolita" },
                    { 1, 29, "Lake Maximo" },
                    { 267, 28, "East Fiona" },
                    { 228, 28, "Brandoberg" },
                    { 76, 28, "West Creola" },
                    { 2, 26, "Daijaburgh" },
                    { 56, 65, "Lake Brandy" },
                    { 9, 23, "Claudialand" },
                    { 186, 22, "Jovannymouth" },
                    { 286, 28, "North Dangeloton" },
                    { 151, 1, "Verniceton" },
                    { 200, 30, "Croninmouth" },
                    { 79, 31, "Ismaelland" },
                    { 39, 40, "New Julius" },
                    { 59, 39, "Wymanton" },
                    { 182, 38, "North Henryfurt" },
                    { 158, 38, "Shanahanview" },
                    { 60, 38, "North Elmer" },
                    { 91, 10, "South Elianeton" },
                    { 291, 34, "Riceberg" },
                    { 215, 30, "North Henriette" },
                    { 264, 34, "Port Aliyah" },
                    { 121, 34, "South Shanelle" },
                    { 105, 34, "Lindsaymouth" },
                    { 126, 33, "East Haleyville" },
                    { 90, 33, "West Solon" },
                    { 61, 32, "West Darrell" },
                    { 214, 31, "South Kelton" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 138, 31, "Emmerichview" },
                    { 247, 34, "O'Reillyhaven" },
                    { 74, 41, "New Claudieton" },
                    { 181, 22, "East Lysanneland" },
                    { 185, 1, "Chetshire" },
                    { 29, 14, "West Mateo" },
                    { 93, 5, "New Jeramieland" },
                    { 156, 6, "Bradtkeside" },
                    { 207, 13, "Sengerborough" },
                    { 193, 13, "Lake Dovieberg" },
                    { 258, 11, "Jakaylamouth" },
                    { 223, 11, "East Aylinfurt" },
                    { 69, 14, "South Theronside" },
                    { 192, 11, "Port Jacquelynland" },
                    { 188, 6, "Port Marquis" },
                    { 224, 6, "West Caterinafort" },
                    { 72, 8, "New Germaine" },
                    { 131, 8, "Lake Dasiashire" },
                    { 58, 9, "Ferryside" },
                    { 227, 10, "New Chesterberg" },
                    { 133, 10, "East Nora" },
                    { 44, 11, "Abshireland" },
                    { 80, 22, "Port Thomasfurt" },
                    { 216, 14, "Rosieshire" },
                    { 31, 5, "Marcchester" },
                    { 144, 2, "Brownstad" },
                    { 206, 3, "East Duane" },
                    { 219, 3, "Johnstonshire" },
                    { 254, 21, "Botsfordville" },
                    { 92, 4, "Johnsonfurt" },
                    { 152, 4, "West Gaston" },
                    { 269, 20, "Pricemouth" },
                    { 32, 15, "New Jadyn" },
                    { 261, 20, "Lake Camila" },
                    { 208, 20, "Sidneystad" },
                    { 109, 19, "Beahanchester" },
                    { 86, 18, "Satterfieldborough" },
                    { 179, 4, "Feltonborough" },
                    { 3, 5, "Migueltown" },
                    { 229, 16, "Stromanview" },
                    { 183, 16, "Sammiemouth" },
                    { 250, 20, "East Dextermouth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 163, 41, "Effertzfurt" },
                    { 129, 36, "Dangelostad" },
                    { 116, 10, "North Skyla" },
                    { 132, 44, "East Jason" },
                    { 38, 59, "Macejkovicmouth" },
                    { 175, 44, "Lake Leola" },
                    { 232, 45, "New Roxane" },
                    { 289, 58, "Mauriceland" },
                    { 81, 57, "North Amira" },
                    { 5, 56, "South Jaquelin" },
                    { 293, 54, "Lake Herminiobury" },
                    { 125, 54, "New Kaylin" },
                    { 290, 45, "Ortizshire" },
                    { 112, 54, "Elianville" },
                    { 88, 46, "West Melba" },
                    { 288, 46, "Johnsborough" },
                    { 298, 46, "Port Ilenefurt" },
                    { 10, 54, "South Koby" },
                    { 149, 53, "Celineview" },
                    { 137, 47, "Port Quinnbury" },
                    { 195, 52, "North Felicity" },
                    { 111, 52, "Lake Everette" },
                    { 67, 49, "Port Katrinamouth" },
                    { 237, 47, "Wildermanbury" },
                    { 244, 60, "Lake Katarina" },
                    { 41, 61, "Davefort" },
                    { 172, 45, "Kilbackport" },
                    { 66, 44, "West Aldenport" },
                    { 160, 64, "North Madelynn" },
                    { 57, 64, "New Marisa" },
                    { 97, 43, "West Alexandro" },
                    { 104, 44, "Johnstonton" },
                    { 276, 63, "Lake Nolan" },
                    { 123, 63, "Muraziktown" },
                    { 122, 63, "New Gregorio" },
                    { 226, 64, "Lehnerfurt" },
                    { 96, 63, "East Kipborough" },
                    { 8, 63, "Janickborough" },
                    { 170, 64, "Nicolasbury" },
                    { 153, 42, "Astridville" },
                    { 7, 65, "Loribury" },
                    { 274, 43, "Lake Lucasport" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 155, 61, "Danniemouth" },
                    { 115, 61, "North Edythton" },
                    { 245, 43, "Vallieborough" },
                    { 199, 64, "Lake Orphachester" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 84, 2319, 3, "quia", 379 },
                    { 79, 2096, 4, "quisquam", 112 },
                    { 83, 2167, 3, "deleniti", 432 },
                    { 1, 1663, 1, "esse", 692 },
                    { 9, 2489, 1, "corporis", 458 },
                    { 87, 1923, 3, "tenetur", 329 },
                    { 81, 1988, 3, "explicabo", 483 },
                    { 98, 2964, 3, "deserunt", 298 },
                    { 71, 2524, 4, "omnis", 112 },
                    { 8, 1110, 4, "dolorem", 106 },
                    { 26, 1197, 4, "consequatur", 531 },
                    { 69, 1013, 4, "repellat", 280 },
                    { 34, 2336, 4, "debitis", 287 },
                    { 46, 2780, 4, "inventore", 413 },
                    { 10, 2180, 1, "in", 661 },
                    { 65, 2083, 4, "aut", 696 },
                    { 49, 2324, 4, "ab", 534 },
                    { 50, 2746, 4, "molestiae", 116 },
                    { 95, 2094, 3, "eveniet", 553 },
                    { 15, 1636, 1, "dolor", 502 },
                    { 48, 2953, 1, "magnam", 160 },
                    { 23, 1165, 1, "et", 648 },
                    { 11, 2663, 2, "voluptatem", 275 },
                    { 13, 1787, 3, "qui", 625 },
                    { 17, 1154, 2, "provident", 281 },
                    { 21, 2662, 2, "repudiandae", 611 },
                    { 22, 1547, 2, "sit", 120 },
                    { 12, 2334, 3, "ut", 429 },
                    { 6, 2808, 3, "eum", 191 },
                    { 25, 1229, 2, "suscipit", 623 },
                    { 5, 2846, 3, "voluptas", 313 },
                    { 27, 1274, 2, "ea", 549 },
                    { 3, 2082, 3, "incidunt", 616 },
                    { 28, 1253, 2, "atque", 641 },
                    { 38, 2651, 2, "rerum", 571 },
                    { 39, 2228, 2, "sed", 350 },
                    { 40, 2969, 2, "porro", 112 },
                    { 97, 1584, 2, "autem", 404 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 44, 2903, 2, "asperiores", 538 },
                    { 72, 1636, 2, "sint", 476 },
                    { 47, 2889, 2, "repellendus", 326 },
                    { 51, 1744, 2, "recusandae", 247 },
                    { 57, 1914, 2, "ad", 141 },
                    { 7, 1925, 2, "nisi", 319 },
                    { 16, 1085, 1, "non", 397 },
                    { 4, 1825, 2, "consectetur", 558 },
                    { 14, 1063, 3, "placeat", 508 },
                    { 32, 2902, 1, "possimus", 590 },
                    { 35, 1142, 1, "fugit", 142 },
                    { 43, 1747, 1, "soluta", 451 },
                    { 77, 1127, 3, "quas", 229 },
                    { 76, 1069, 3, "reiciendis", 643 },
                    { 58, 2581, 2, "tempora", 419 },
                    { 52, 2329, 1, "labore", 267 },
                    { 64, 1120, 3, "maxime", 551 },
                    { 59, 2546, 3, "quam", 305 },
                    { 60, 1511, 1, "facilis", 529 },
                    { 56, 1570, 3, "accusantium", 262 },
                    { 63, 1584, 1, "enim", 625 },
                    { 42, 1807, 3, "voluptates", 430 },
                    { 31, 1059, 3, "ipsa", 330 },
                    { 20, 2500, 3, "laborum", 177 },
                    { 66, 2896, 1, "mollitia", 665 },
                    { 82, 2371, 1, "vitae", 427 },
                    { 91, 1298, 1, "occaecati", 253 },
                    { 19, 1606, 3, "doloribus", 429 },
                    { 18, 2342, 3, "illum", 120 },
                    { 92, 1249, 1, "vel", 699 },
                    { 2, 2790, 2, "similique", 306 },
                    { 61, 1414, 2, "nam", 328 },
                    { 100, 1843, 4, "harum", 528 },
                    { 85, 1754, 4, "vero", 358 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 95, 174, "Ortiz Group" },
                    { 24, 108, "Reinger - Pfeffer" },
                    { 96, 110, "Anderson, Kassulke and Howell" },
                    { 98, 43, "Welch - Jacobi" },
                    { 28, 111, "Medhurst, Smith and Schmitt" },
                    { 93, 111, "Boyer - Bergstrom" },
                    { 70, 42, "Lemke LLC" },
                    { 34, 42, "McClure, Murazik and Ullrich" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 77, 41, "Jaskolski, Goyette and Bauch" },
                    { 26, 41, "Zulauf, Hahn and Halvorson" },
                    { 22, 114, "Toy, Herzog and Jacobs" },
                    { 45, 114, "Treutel - Ward" },
                    { 32, 40, "Becker, Harvey and Mayer" },
                    { 9, 39, "Keeling, Schaefer and Lynch" },
                    { 94, 119, "Haley LLC" },
                    { 30, 38, "Lynch - Wolf" },
                    { 69, 120, "Cronin - Cassin" },
                    { 14, 121, "Champlin - Toy" },
                    { 36, 122, "Brekke, Grant and Spencer" },
                    { 7, 124, "McDermott - Greenholt" },
                    { 10, 126, "Fritsch LLC" },
                    { 63, 100, "Feest, Cole and Kuphal" },
                    { 23, 100, "Stark LLC" },
                    { 42, 45, "Pacocha - Lehner" },
                    { 74, 45, "Streich, Pollich and Gerhold" },
                    { 49, 68, "Kassulke Inc" },
                    { 65, 73, "Marquardt - Windler" },
                    { 85, 61, "Sauer LLC" },
                    { 55, 61, "Walker, Haag and Johns" },
                    { 40, 76, "Raynor - Walsh" },
                    { 8, 59, "Erdman - Crona" },
                    { 57, 58, "Wunsch, Rowe and Mayer" },
                    { 39, 58, "Rodriguez - Block" },
                    { 66, 56, "Lang, Crist and Berge" },
                    { 89, 82, "Stokes Group" },
                    { 68, 126, "Herzog - Erdman" },
                    { 50, 84, "Breitenberg LLC" },
                    { 38, 52, "Kassulke - Cormier" },
                    { 73, 47, "Kiehn - Volkman" },
                    { 29, 47, "Roob - Cremin" },
                    { 33, 89, "Hoeger, Leannon and Lesch" },
                    { 56, 89, "Kerluke Group" },
                    { 21, 47, "Dooley - Legros" },
                    { 2, 90, "Farrell, Douglas and O'Connell" },
                    { 92, 90, "Gutmann - Watsica" },
                    { 81, 46, "Huel Group" },
                    { 11, 91, "Feest - Stamm" },
                    { 61, 52, "Kohler, Hintz and Sporer" },
                    { 80, 175, "Weissnat - Pfannerstill" },
                    { 79, 33, "Kiehn - Fritsch" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 51, 132, "Altenwerth - Kunde" },
                    { 48, 21, "Wehner - Crooks" },
                    { 25, 3, "Muller, Koss and Kiehn" },
                    { 82, 155, "Jaskolski - Steuber" },
                    { 5, 20, "Stokes Inc" },
                    { 46, 16, "Kris - Breitenberg" },
                    { 43, 16, "Watsica LLC" },
                    { 60, 166, "Blanda Inc" },
                    { 86, 13, "O'Hara - Collier" },
                    { 67, 13, "Hudson - Casper" },
                    { 31, 171, "Cruickshank - Abbott" },
                    { 71, 171, "Beatty, Zulauf and Jacobson" },
                    { 27, 186, "Cole - Pfannerstill" },
                    { 4, 6, "Kuhn, Smitham and Rohan" },
                    { 37, 6, "Bartoletti Group" },
                    { 76, 6, "Gottlieb, Thompson and Windler" },
                    { 91, 182, "Dibbert - Senger" },
                    { 75, 171, "Gibson, Barrows and Ratke" },
                    { 16, 179, "O'Kon, Hauck and Schumm" },
                    { 1, 176, "Hane - Prohaska" },
                    { 100, 10, "Braun - Miller" },
                    { 64, 10, "Dietrich - Bernier" },
                    { 6, 191, "Schowalter and Sons" },
                    { 54, 191, "Windler Group" },
                    { 87, 153, "Lesch - Metz" },
                    { 15, 153, "Swaniawski, Mosciski and Hermiston" },
                    { 19, 134, "Jakubowski - Kemmer" },
                    { 35, 134, "Haag, Thompson and Beer" },
                    { 47, 30, "Gleichner, Gerlach and Cronin" },
                    { 41, 139, "Bogan Group" },
                    { 44, 139, "Denesik LLC" },
                    { 88, 139, "Bechtelar - Murray" },
                    { 53, 142, "Steuber and Sons" },
                    { 3, 28, "Terry and Sons" },
                    { 17, 143, "Beatty Inc" },
                    { 59, 143, "Kovacek, Moore and Hodkiewicz" },
                    { 99, 32, "White, Emard and Simonis" },
                    { 84, 24, "Casper Inc" },
                    { 78, 24, "Predovic and Sons" },
                    { 62, 24, "Bayer - O'Conner" },
                    { 13, 24, "Jacobs LLC" },
                    { 97, 23, "White - Hickle" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 72, 23, "Davis LLC" },
                    { 18, 149, "Mohr, Kulas and Keebler" },
                    { 52, 23, "Bechtelar Inc" },
                    { 20, 150, "Jast, Terry and Conn" },
                    { 58, 21, "Schamberger - Grady" },
                    { 90, 1, "Rodriguez LLC" },
                    { 83, 24, "Ferry - Goldner" },
                    { 12, 149, "O'Keefe - Tillman" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 42, 79, 41, "totam" },
                    { 23, 72, 52, "perferendis" },
                    { 18, 57, 4, "dolorem" },
                    { 1, 57, 33, "laudantium" },
                    { 6, 40, 100, "est" },
                    { 78, 39, 33, "magnam" },
                    { 29, 38, 41, "aspernatur" },
                    { 81, 27, 22, "enim" },
                    { 61, 27, 86, "repellat" },
                    { 85, 25, 22, "quos" },
                    { 79, 21, 57, "ut" },
                    { 69, 17, 50, "atque" },
                    { 70, 11, 35, "ea" },
                    { 35, 11, 57, "aut" },
                    { 27, 7, 49, "nihil" },
                    { 45, 2, 43, "ad" },
                    { 39, 82, 66, "corporis" },
                    { 19, 82, 85, "non" },
                    { 44, 1, 98, "deserunt" },
                    { 73, 1, 4, "impedit" },
                    { 22, 9, 29, "cum" },
                    { 64, 9, 49, "commodi" },
                    { 91, 10, 83, "autem" },
                    { 99, 10, 43, "a" },
                    { 43, 72, 72, "sunt" },
                    { 36, 16, 78, "quas" },
                    { 15, 32, 74, "facilis" },
                    { 20, 32, 66, "provident" },
                    { 50, 32, 37, "porro" },
                    { 88, 60, 9, "pariatur" },
                    { 34, 63, 47, "veniam" },
                    { 4, 82, 59, "vero" },
                    { 30, 23, 72, "quia" },
                    { 86, 72, 86, "alias" },
                    { 90, 69, 54, "sequi" },
                    { 92, 3, 58, "rerum" },
                    { 16, 84, 22, "deleniti" },
                    { 31, 84, 67, "magni" },
                    { 32, 84, 5, "tempore" },
                    { 12, 98, 16, "molestiae" },
                    { 58, 98, 26, "perspiciatis" },
                    { 87, 8, 70, "aperiam" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 40, 83, 58, "ducimus" },
                    { 28, 26, 88, "at" },
                    { 5, 46, 94, "dignissimos" },
                    { 3, 65, 79, "nobis" },
                    { 26, 65, 98, "eveniet" },
                    { 59, 69, 46, "labore" },
                    { 84, 69, 87, "qui" },
                    { 17, 97, 65, "explicabo" },
                    { 48, 34, 6, "modi" },
                    { 37, 83, 32, "voluptatem" },
                    { 9, 65, 32, "delectus" },
                    { 11, 81, 48, "in" },
                    { 49, 81, 1, "odio" },
                    { 13, 6, 54, "adipisci" },
                    { 74, 12, 25, "nulla" },
                    { 2, 18, 72, "et" },
                    { 51, 31, 48, "eaque" },
                    { 76, 31, 40, "temporibus" },
                    { 72, 6, 33, "assumenda" },
                    { 7, 56, 9, "eum" },
                    { 21, 76, 73, "molestias" },
                    { 25, 42, 83, "reprehenderit" },
                    { 97, 64, 24, "consequuntur" },
                    { 80, 5, 91, "necessitatibus" },
                    { 65, 59, 88, "ratione" },
                    { 52, 59, 61, "culpa" },
                    { 14, 64, 61, "omnis" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 94, 204, "Ivy.Welch42@gmail.com", "Bradley", "Volkman", "password123", 2, "Aileen50" },
                    { 45, 173, "Felicity_Wintheiser@gmail.com", "Jadyn", "Leffler", "password123", 1, "Francisco65" },
                    { 225, 173, "Marco.Quitzon30@hotmail.com", "Bobbie", "Luettgen", "password123", 2, "Dewayne17" },
                    { 267, 173, "Diego_Gaylord@gmail.com", "Elyssa", "Feil", "password123", 1, "Christophe_Jacobson22" },
                    { 220, 251, "Jadyn8@gmail.com", "Enoch", "Walter", "password123", 1, "Lavinia51" },
                    { 235, 251, "Zion84@yahoo.com", "Lauren", "Dickens", "password123", 2, "Lorenza_Osinski22" },
                    { 104, 108, "Keven_Cassin@gmail.com", "Adele", "Koss", "password123", 2, "Hal58" },
                    { 96, 260, "Alanna_McDermott@yahoo.com", "Bruce", "Gulgowski", "password123", 1, "Antonietta_Bechtelar87" },
                    { 9, 210, "Erna_Kemmer16@gmail.com", "William", "Stroman", "password123", 2, "Salvador93" },
                    { 132, 278, "Reyes.Rempel59@gmail.com", "Lexi", "McCullough", "password123", 2, "Wilfred78" },
                    { 199, 279, "Deontae8@yahoo.com", "Ashlee", "Hammes", "password123", 3, "Alexandrine_Lehner1" },
                    { 63, 239, "Jamil98@hotmail.com", "Juvenal", "Wilderman", "password123", 3, "Price_Towne" },
                    { 258, 71, "Melba.Lind95@gmail.com", "Kaitlin", "Hansen", "password123", 1, "Maia_Hyatt49" },
                    { 27, 17, "Vivian.Smith@gmail.com", "Braeden", "Beer", "password123", 1, "Roselyn26" },
                    { 296, 171, "Caroline94@hotmail.com", "Leanna", "Orn", "password123", 3, "Robin.Hartmann" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 245, 222, "Lessie.Langosh@gmail.com", "Francisca", "Will", "password123", 1, "Kasey34" },
                    { 273, 222, "Lydia34@hotmail.com", "Alvera", "Waelchi", "password123", 1, "Emery.Grant" },
                    { 19, 142, "Lorenz19@hotmail.com", "Adonis", "Watsica", "password123", 2, "Minnie_Pouros" },
                    { 79, 259, "Kennedi67@hotmail.com", "Michael", "Abernathy", "password123", 1, "Urban70" },
                    { 37, 273, "Mazie66@yahoo.com", "Jamie", "Herzog", "password123", 3, "Cathryn_Hilpert" },
                    { 173, 249, "Aglae.Leuschke@yahoo.com", "Madisyn", "Beier", "password123", 1, "Torrance.Feest" },
                    { 275, 249, "Eloisa98@gmail.com", "Janessa", "Mann", "password123", 3, "Tiana70" },
                    { 75, 15, "Donavon_Kulas64@hotmail.com", "Bianka", "Rosenbaum", "password123", 3, "Neoma.Lehner70" },
                    { 2, 173, "Kaelyn33@gmail.com", "Kianna", "Batz", "password123", 2, "Mona_Lubowitz38" },
                    { 149, 71, "Roosevelt35@yahoo.com", "Natalia", "Bashirian", "password123", 1, "Vivien_Franecki10" },
                    { 238, 203, "Wyman.Witting69@hotmail.com", "Pat", "Witting", "password123", 1, "Milton76" },
                    { 167, 50, "Kadin67@yahoo.com", "Harmony", "Wunsch", "password123", 2, "Evert66" },
                    { 16, 203, "Johnnie51@yahoo.com", "Lacey", "Boyle", "password123", 3, "Marco46" },
                    { 217, 23, "Emmitt.Rutherford78@hotmail.com", "Lelia", "Smith", "password123", 1, "Fabian.Gerhold54" },
                    { 12, 233, "Jadon.Dibbert8@gmail.com", "Roxane", "Bechtelar", "password123", 3, "Charlie_Murphy" },
                    { 55, 233, "Ken.Boyer@gmail.com", "Jaycee", "VonRueden", "password123", 2, "Eloisa_Goyette51" },
                    { 91, 148, "Frederick89@gmail.com", "Arvel", "Maggio", "password123", 2, "Bart86" },
                    { 190, 148, "Fermin_Turcotte79@hotmail.com", "Peyton", "Rempel", "password123", 1, "Gennaro.Ritchie6" },
                    { 109, 230, "Adrain.Predovic31@yahoo.com", "Aliyah", "Mohr", "password123", 1, "Lonny27" },
                    { 163, 45, "Parker76@hotmail.com", "Kobe", "Medhurst", "password123", 1, "Carol_McKenzie" },
                    { 8, 128, "Kenneth_Carter@yahoo.com", "Adriana", "Volkman", "password123", 3, "Uriah.Stroman54" },
                    { 46, 241, "Clarabelle17@yahoo.com", "Romaine", "Windler", "password123", 1, "Gwen_Trantow76" },
                    { 22, 275, "Jerald.Von@yahoo.com", "Reta", "Denesik", "password123", 3, "Kaylee.Sporer42" },
                    { 177, 275, "Hiram70@gmail.com", "Hilma", "Halvorson", "password123", 2, "Cristobal72" },
                    { 154, 15, "Barrett58@yahoo.com", "Karson", "Cremin", "password123", 2, "Megane32" },
                    { 87, 203, "Lauren.Schumm@yahoo.com", "Abel", "Grimes", "password123", 2, "Gabriel.Koch15" },
                    { 152, 159, "Hollis_Considine@yahoo.com", "Darlene", "Thompson", "password123", 1, "Hildegard21" },
                    { 130, 205, "Isaias26@hotmail.com", "Ulises", "Hegmann", "password123", 2, "Brayan_Bahringer" },
                    { 237, 282, "Jacey89@yahoo.com", "Shanel", "Fahey", "password123", 3, "Jo_Wilkinson" },
                    { 255, 150, "Rene92@hotmail.com", "Tatyana", "Ebert", "password123", 3, "Crystel.Nolan85" },
                    { 281, 150, "Raphael_Weissnat20@hotmail.com", "Alfreda", "Moen", "password123", 2, "Herminio23" },
                    { 133, 27, "August.Armstrong@gmail.com", "Rigoberto", "Reichel", "password123", 2, "Zane94" },
                    { 78, 270, "Annie.Anderson@hotmail.com", "Maryse", "Vandervort", "password123", 2, "Rhianna.Waters" },
                    { 103, 270, "Kenyon.Paucek@yahoo.com", "Marc", "Jones", "password123", 3, "Lionel_Nitzsche3" },
                    { 223, 270, "Pierre_Wiegand10@hotmail.com", "Loyal", "Erdman", "password123", 1, "Baby.Hodkiewicz" },
                    { 249, 54, "Ross_Grimes@gmail.com", "Amelia", "Ruecker", "password123", 2, "Gene_Daniel" },
                    { 33, 253, "Isaiah_Botsford65@yahoo.com", "Maurice", "Will", "password123", 3, "Bennett_Cassin78" },
                    { 64, 11, "Mateo54@hotmail.com", "Zoie", "Brown", "password123", 3, "Leslie.Leannon36" },
                    { 289, 11, "Mossie.Beer24@yahoo.com", "Adolf", "Bins", "password123", 1, "Sabrina_Harber" },
                    { 25, 205, "Justen_Hagenes@yahoo.com", "Delmer", "Schoen", "password123", 3, "Emely.Harris" },
                    { 137, 49, "Marques.Blanda@gmail.com", "Dexter", "Roberts", "password123", 3, "Ciara28" },
                    { 222, 146, "Paxton.Effertz@hotmail.com", "Layne", "Hartmann", "password123", 1, "Cleveland_Boyle" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 209, 113, "Tomasa.Oberbrunner65@hotmail.com", "Casper", "Lubowitz", "password123", 2, "Odie71" },
                    { 49, 140, "Kurtis3@yahoo.com", "Kennedi", "Marquardt", "password123", 1, "Brendon.Mueller" },
                    { 175, 202, "Jarod_Haag22@gmail.com", "Jameson", "Raynor", "password123", 1, "Kari.Hammes96" },
                    { 159, 168, "Evert12@gmail.com", "Janick", "Koelpin", "password123", 3, "Jessyca41" },
                    { 195, 211, "Berry83@yahoo.com", "Sean", "Erdman", "password123", 2, "Rickie.Schuppe37" },
                    { 102, 157, "Nikki70@yahoo.com", "Katelynn", "Blanda", "password123", 2, "Marlene_Schoen" },
                    { 189, 157, "Mariah19@yahoo.com", "Angie", "Kreiger", "password123", 2, "Gideon52" },
                    { 57, 139, "Sigurd11@gmail.com", "Dawson", "Sanford", "password123", 2, "Luella.Schaden71" },
                    { 42, 87, "Yoshiko.Sanford53@hotmail.com", "Tyrese", "Kunze", "password123", 2, "Dereck99" },
                    { 254, 40, "Erin49@yahoo.com", "Branson", "Kreiger", "password123", 3, "Rodger_Turner85" },
                    { 233, 28, "Kiley48@hotmail.com", "Montana", "Franecki", "password123", 3, "Mateo.Jakubowski" },
                    { 236, 28, "Roselyn71@yahoo.com", "Angelina", "Champlin", "password123", 1, "Peyton.Bayer46" },
                    { 157, 198, "Brady.Haley@hotmail.com", "Ignacio", "Mann", "password123", 3, "Ryleigh.Ruecker45" },
                    { 197, 198, "Florencio_Russel@hotmail.com", "Efrain", "Smith", "password123", 1, "Rhiannon63" },
                    { 226, 198, "Melyna83@gmail.com", "Jewell", "Will", "password123", 3, "Adaline30" },
                    { 158, 294, "Garrett.Jaskolski48@gmail.com", "Jaylen", "Walsh", "password123", 1, "Reyes.Nitzsche" },
                    { 268, 294, "Crystel_Zboncak3@yahoo.com", "Hyman", "Abshire", "password123", 1, "Ron94" },
                    { 292, 73, "Kurt_Bahringer@yahoo.com", "Travon", "Gleason", "password123", 2, "Donna35" },
                    { 129, 18, "Mathilde_Gutmann@yahoo.com", "Rowan", "Grimes", "password123", 3, "Fiona_Kunde53" },
                    { 58, 265, "Rogelio.Dibbert6@hotmail.com", "Marcelino", "Langosh", "password123", 1, "Nicola_Medhurst57" },
                    { 53, 103, "Duncan.Casper@yahoo.com", "Minnie", "Roberts", "password123", 2, "Laurence.MacGyver44" },
                    { 136, 184, "Regan.Thompson@hotmail.com", "Angela", "Mueller", "password123", 1, "Lillian58" },
                    { 86, 176, "Elyssa97@yahoo.com", "Korey", "Kertzmann", "password123", 1, "Jovany8" },
                    { 119, 176, "Reta.OKon27@gmail.com", "Yasmine", "Donnelly", "password123", 2, "Sofia.Harris57" },
                    { 128, 176, "Jaden32@hotmail.com", "Tressa", "McKenzie", "password123", 1, "Tiara.Fadel69" },
                    { 228, 176, "Aaliyah.Feest@hotmail.com", "Meta", "Dicki", "password123", 3, "Rhiannon11" },
                    { 270, 84, "Luz_Dooley29@hotmail.com", "Justyn", "Larkin", "password123", 2, "Kaylee_Schamberger20" },
                    { 266, 84, "Geoffrey_Kunze82@hotmail.com", "Randi", "Rogahn", "password123", 1, "Beryl.Haag72" },
                    { 169, 84, "Isabelle_Schuppe@hotmail.com", "Phoebe", "Robel", "password123", 2, "Elva.Feest" },
                    { 110, 84, "Caroline77@yahoo.com", "Caesar", "Hoeger", "password123", 2, "Hilario9" },
                    { 211, 280, "Jordyn.Cartwright81@gmail.com", "Mikayla", "Erdman", "password123", 1, "Brown_Towne" },
                    { 210, 34, "Gussie.Miller@yahoo.com", "Laverne", "Kuhic", "password123", 2, "Daphnee_Cummings29" },
                    { 265, 256, "Manley.Sporer60@gmail.com", "Mikel", "Schmidt", "password123", 1, "Amani_Mohr62" },
                    { 6, 284, "Marshall_Gutkowski76@hotmail.com", "Raleigh", "Schuppe", "password123", 1, "Allison_King" },
                    { 26, 284, "Gilda_Dooley4@gmail.com", "Tabitha", "Baumbach", "password123", 3, "Kyler_Towne" },
                    { 93, 284, "Tobin_Parisian14@yahoo.com", "Brandon", "Grant", "password123", 1, "Jordy.Mann17" },
                    { 295, 284, "Rylan_Ward@gmail.com", "Wilburn", "Zemlak", "password123", 1, "Elta.Kilback" },
                    { 242, 297, "Mekhi.Schoen@yahoo.com", "Alysson", "Barton", "password123", 2, "Nathaniel.Conn" },
                    { 62, 268, "Zelda.Kautzer@hotmail.com", "Jude", "Cummerata", "password123", 1, "Augusta_Jaskolski" },
                    { 112, 25, "Maye_Little@gmail.com", "Lourdes", "Schuppe", "password123", 2, "Boris.Quitzon" },
                    { 206, 89, "Glennie.Yundt12@yahoo.com", "Vince", "Littel", "password123", 1, "Marquise33" },
                    { 278, 89, "Granville.Hoeger79@yahoo.com", "Jerel", "Fadel", "password123", 1, "Rodrigo6" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 247, 49, "Kylee.Macejkovic40@hotmail.com", "Cathryn", "Jacobs", "password123", 1, "Deron49" },
                    { 186, 262, "Nathan54@gmail.com", "Victor", "Gusikowski", "password123", 2, "Magnus_Lueilwitz" },
                    { 215, 299, "Allene47@gmail.com", "Carlie", "Mertz", "password123", 3, "Deshaun83" },
                    { 194, 82, "Garry_Kunze83@hotmail.com", "Jerel", "Bode", "password123", 3, "Ryleigh_Nitzsche36" },
                    { 272, 19, "Howell74@hotmail.com", "Libby", "Davis", "password123", 2, "Kiel44" },
                    { 188, 145, "Bettye.Powlowski@yahoo.com", "Carson", "Waelchi", "password123", 2, "Hildegard.Lesch" },
                    { 131, 272, "Albina43@gmail.com", "Macie", "Krajcik", "password123", 1, "Markus38" },
                    { 47, 65, "Lenora23@yahoo.com", "Kaitlin", "Feeney", "password123", 3, "Kaci.Klocko28" },
                    { 76, 65, "Sibyl.Krajcik@yahoo.com", "Nikolas", "Kunde", "password123", 3, "Tess.Glover" },
                    { 160, 65, "Deion66@gmail.com", "Karl", "Koch", "password123", 3, "Jaqueline_Swift35" },
                    { 241, 101, "Samara_Heidenreich87@gmail.com", "Maya", "Hegmann", "password123", 3, "Aurore_Hessel" },
                    { 229, 169, "Josianne.Powlowski@gmail.com", "Broderick", "Bernier", "password123", 2, "April_Glover" },
                    { 214, 190, "Anika_Wuckert@hotmail.com", "Otto", "Heathcote", "password123", 2, "Aylin.Prosacco" },
                    { 262, 292, "Chester_Bogisich@yahoo.com", "Glen", "Volkman", "password123", 1, "Grady20" },
                    { 85, 146, "Sedrick52@gmail.com", "Maybell", "Kuvalis", "password123", 1, "Joesph87" },
                    { 60, 140, "Randal92@gmail.com", "Madelynn", "Harris", "password123", 3, "Deon.Hermiston" },
                    { 13, 202, "Leon_Abshire@yahoo.com", "Rubye", "Bergnaum", "password123", 1, "Hermann.Lindgren" },
                    { 216, 161, "Marian11@yahoo.com", "Yazmin", "Hintz", "password123", 2, "Deanna.Kerluke15" },
                    { 224, 126, "Elisabeth.Larson48@gmail.com", "Jessy", "Dickens", "password123", 3, "Dillon30" },
                    { 111, 126, "Matt_Bruen60@hotmail.com", "Garett", "Roob", "password123", 1, "Cleta_Turcotte96" },
                    { 124, 90, "Juanita_Kulas23@gmail.com", "Yesenia", "Grady", "password123", 2, "Bell_Wehner7" },
                    { 221, 61, "Jensen.Dietrich52@yahoo.com", "Emilie", "O'Hara", "password123", 3, "Bret94" },
                    { 219, 61, "Jan.Miller75@hotmail.com", "Rebeka", "Casper", "password123", 1, "Rosalinda80" },
                    { 126, 214, "Madie.Gusikowski@hotmail.com", "Elna", "Thompson", "password123", 2, "Mikel_Schuster97" },
                    { 264, 70, "Lina.Dare6@yahoo.com", "Selmer", "Skiles", "password123", 1, "Clark_Lebsack22" },
                    { 118, 70, "Crawford79@gmail.com", "Albert", "Ruecker", "password123", 1, "Annalise11" },
                    { 44, 22, "Elliot84@gmail.com", "Luna", "Gutkowski", "password123", 1, "Bettye9" },
                    { 261, 296, "Raul40@hotmail.com", "Delia", "Lebsack", "password123", 3, "Yvette28" },
                    { 260, 243, "Abigail.Toy@gmail.com", "Jolie", "Hintz", "password123", 1, "Evans60" },
                    { 234, 243, "Lilla_Dooley75@hotmail.com", "Henri", "Nitzsche", "password123", 3, "Rosina12" },
                    { 299, 225, "Lula29@yahoo.com", "Jeffery", "Harvey", "password123", 3, "Crystel97" },
                    { 106, 53, "Lindsay.Reichel69@gmail.com", "Uriel", "Ullrich", "password123", 1, "Curt58" },
                    { 56, 53, "Herminio_Legros59@gmail.com", "Ubaldo", "Kiehn", "password123", 2, "Norval55" },
                    { 298, 1, "Carlos72@gmail.com", "Torrey", "Abshire", "password123", 1, "Maryjane_Hane" },
                    { 284, 1, "Harmon97@yahoo.com", "Marcelle", "Denesik", "password123", 1, "Mazie_Smitham66" },
                    { 120, 286, "Bertrand_Howell32@hotmail.com", "Beaulah", "Ledner", "password123", 1, "Vladimir_Ankunding3" },
                    { 280, 267, "Matteo.Reichert@yahoo.com", "Seamus", "Monahan", "password123", 1, "Gabriella_Feil79" },
                    { 113, 105, "Thalia_Johns@yahoo.com", "Leopoldo", "Turner", "password123", 3, "Kellen90" },
                    { 147, 267, "Carolina.Cole27@yahoo.com", "Mack", "Jacobi", "password123", 2, "Delfina69" },
                    { 166, 105, "Sim_Schultz@yahoo.com", "Gladys", "Champlin", "password123", 1, "Edwardo_Bins47" },
                    { 71, 247, "Edwin22@gmail.com", "Sincere", "Champlin", "password123", 2, "Ana79" },
                    { 95, 175, "Marshall_Powlowski14@hotmail.com", "Nellie", "Predovic", "password123", 1, "Conrad_Deckow33" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 59, 104, "Isac50@yahoo.com", "Rene", "Gislason", "password123", 1, "Kirk_Wunsch" },
                    { 201, 66, "Elinor.Bins48@yahoo.com", "Gregory", "Thiel", "password123", 2, "Jaclyn.Hintz57" },
                    { 11, 66, "Raphaelle.Gibson@hotmail.com", "Myriam", "Hand", "password123", 3, "Arvilla10" },
                    { 257, 274, "Dorian_Schamberger64@gmail.com", "Brannon", "DuBuque", "password123", 3, "Dortha.Hammes15" },
                    { 52, 153, "Dimitri.Stroman53@yahoo.com", "Amelie", "Lang", "password123", 2, "Kasandra65" },
                    { 43, 153, "Jake99@hotmail.com", "Fannie", "Stracke", "password123", 2, "William.Stracke71" },
                    { 286, 163, "Gertrude25@hotmail.com", "Mikel", "Walker", "password123", 3, "Alphonso85" },
                    { 200, 163, "Eloisa_Graham@hotmail.com", "Delphia", "Johns", "password123", 3, "Marjorie.Hegmann38" },
                    { 172, 163, "Dax_Stamm87@hotmail.com", "Blanche", "Volkman", "password123", 2, "Magdalen_Parker" },
                    { 263, 74, "Earline.Koch@hotmail.com", "Tate", "Schmitt", "password123", 3, "Warren85" },
                    { 193, 39, "Nat_Boyle@gmail.com", "Lew", "Kessler", "password123", 3, "Hillary_Barrows" },
                    { 121, 39, "Melvina43@hotmail.com", "Jeremie", "Mante", "password123", 2, "Alfonzo.Steuber38" },
                    { 184, 182, "Edward_Jaskolski39@hotmail.com", "Keven", "Conn", "password123", 1, "Rigoberto_Ratke64" },
                    { 185, 158, "Benjamin.Runolfsson@hotmail.com", "Bessie", "Barrows", "password123", 1, "Cydney71" },
                    { 171, 158, "Salvador.Boyer@gmail.com", "Ezequiel", "Hodkiewicz", "password123", 3, "Shakira_Mills84" },
                    { 80, 60, "Leonora.Baumbach@hotmail.com", "Asia", "Hilpert", "password123", 2, "Christiana99" },
                    { 144, 129, "Kaylin.Considine35@hotmail.com", "Anabelle", "Reichert", "password123", 3, "Emma_Beatty" },
                    { 202, 291, "Freida_Kiehn@yahoo.com", "Kennedy", "Rohan", "password123", 2, "Krystal95" },
                    { 108, 121, "Wava_Hackett@gmail.com", "Dominic", "Langworth", "password123", 1, "Jimmy_Bruen" },
                    { 115, 172, "Amaya_Smitham@gmail.com", "Loren", "Graham", "password123", 2, "Elaina.Klocko62" },
                    { 196, 228, "Jacey.Walker78@yahoo.com", "Anais", "Frami", "password123", 3, "Stanton_Corwin90" },
                    { 191, 2, "Jermey_Dach91@yahoo.com", "Nigel", "Botsford", "password123", 2, "Jace_Goldner33" },
                    { 81, 223, "Parker.Hermiston@hotmail.com", "Rylee", "Berge", "password123", 3, "Maia.Tromp58" },
                    { 38, 223, "Cole42@gmail.com", "Meghan", "Johns", "password123", 1, "Alayna13" },
                    { 252, 192, "Ashtyn93@hotmail.com", "Nadia", "Carroll", "password123", 2, "Sofia.Haley22" },
                    { 161, 192, "Myrtie_Block@gmail.com", "Velda", "Ritchie", "password123", 3, "Giles_Gutkowski45" },
                    { 256, 44, "Eudora80@hotmail.com", "Sheila", "Toy", "password123", 3, "Hayden.Witting1" },
                    { 251, 44, "Elva_Altenwerth24@hotmail.com", "Raheem", "Leffler", "password123", 2, "Lucinda77" },
                    { 183, 91, "Joan_Stehr@hotmail.com", "Jaeden", "Volkman", "password123", 3, "Brannon90" },
                    { 179, 131, "Amie_Konopelski@yahoo.com", "Eldon", "Bartoletti", "password123", 1, "Emmet11" },
                    { 3, 131, "Kristian.Ullrich65@gmail.com", "Blanche", "Reynolds", "password123", 3, "Daphne_Gleichner91" },
                    { 259, 72, "Cathy_Bogisich@hotmail.com", "Hipolito", "Runte", "password123", 2, "Monique.Berge" },
                    { 141, 224, "Nicholaus_Cummerata@yahoo.com", "Jerald", "Wisozk", "password123", 1, "Griffin.Hackett" },
                    { 204, 31, "Jade_Waelchi10@yahoo.com", "Nolan", "Will", "password123", 2, "Osborne2" },
                    { 246, 3, "Ida.Weissnat69@yahoo.com", "Margarett", "Lebsack", "password123", 3, "Elvis_Dickinson21" },
                    { 125, 179, "Easton5@yahoo.com", "Betsy", "Harvey", "password123", 1, "Matilde29" },
                    { 82, 92, "Sandrine84@hotmail.com", "Xavier", "Heathcote", "password123", 3, "Fletcher31" },
                    { 155, 219, "Bertha96@yahoo.com", "Domenica", "Goldner", "password123", 1, "Kenyon45" },
                    { 192, 206, "Clementine.McDermott18@yahoo.com", "Sunny", "Bogan", "password123", 3, "Merlin_Gorczany" },
                    { 92, 185, "Weldon_Jaskolski@yahoo.com", "Jayne", "Boyer", "password123", 2, "Leda.Metz50" },
                    { 39, 151, "Dean.Hartmann99@gmail.com", "Ceasar", "Williamson", "password123", 2, "Noemy20" },
                    { 287, 223, "Manuela.Conroy26@hotmail.com", "Zita", "Mante", "password123", 3, "Jammie.Goyette1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 218, 76, "Ansley.Armstrong@hotmail.com", "Fern", "Daugherty", "password123", 3, "Josiah.Balistreri52" },
                    { 243, 258, "Aditya_OKon@hotmail.com", "Gracie", "Grimes", "password123", 2, "Florida_Kohler" },
                    { 83, 207, "Pietro.Spinka@hotmail.com", "Marcella", "Kerluke", "password123", 1, "Erik14" },
                    { 140, 2, "Eliseo.Johns@hotmail.com", "Freda", "Bosco", "password123", 1, "Dominic.Sanford" },
                    { 21, 2, "Tatyana76@yahoo.com", "Elyse", "Jacobson", "password123", 3, "Shayna_Bergnaum" },
                    { 153, 186, "Francesca.Denesik@yahoo.com", "Kaleb", "Abshire", "password123", 2, "Camille_Bogan" },
                    { 65, 186, "Lavina31@hotmail.com", "Augustus", "Towne", "password123", 2, "Annalise.Goyette" },
                    { 5, 186, "Justen.Cummerata@gmail.com", "Ibrahim", "Bailey", "password123", 3, "Kay_Runte46" },
                    { 1, 80, "Vivian_Von38@hotmail.com", "Anjali", "Yundt", "password123", 2, "Edmund.Bosco" },
                    { 288, 254, "Bernie_Williamson91@hotmail.com", "Cheyenne", "Cassin", "password123", 3, "Rosalee_Jakubowski" },
                    { 17, 254, "Orlo7@gmail.com", "Edna", "Schinner", "password123", 2, "Gregory_Prosacco" },
                    { 51, 269, "Eusebio_Emard@gmail.com", "Nathen", "Balistreri", "password123", 1, "Shawna.Beatty99" },
                    { 48, 269, "Manley.Rempel88@gmail.com", "Effie", "Pacocha", "password123", 2, "Jazmyn.Hand" },
                    { 282, 261, "Tanya_Cassin22@gmail.com", "Marc", "Hyatt", "password123", 3, "Bradford_Lemke" },
                    { 40, 229, "Hollie_Berge78@yahoo.com", "Franco", "Kub", "password123", 1, "Leopold86" },
                    { 239, 183, "Percival80@yahoo.com", "Phyllis", "Conroy", "password123", 3, "Nickolas18" },
                    { 208, 183, "Elza81@gmail.com", "Stefan", "Leannon", "password123", 2, "Lenna.Mante" },
                    { 180, 216, "Oceane.Feil@hotmail.com", "Noah", "Windler", "password123", 3, "Zachariah_Morissette" },
                    { 139, 216, "Kirstin.Armstrong@gmail.com", "Maverick", "Schumm", "password123", 2, "Jaclyn.Blick" },
                    { 240, 69, "Abelardo.Hahn@gmail.com", "Lupe", "Macejkovic", "password123", 2, "Timothy90" },
                    { 24, 69, "Danny_Bradtke@yahoo.com", "Mckenna", "Orn", "password123", 2, "Ron84" },
                    { 74, 29, "Abner20@yahoo.com", "Eunice", "Olson", "password123", 1, "Osborne_Pfeffer78" },
                    { 148, 193, "Kameron.Hoppe@yahoo.com", "Jay", "Orn", "password123", 1, "Robert78" },
                    { 150, 232, "Scotty7@gmail.com", "German", "Jakubowski", "password123", 1, "Consuelo.Bartell74" },
                    { 283, 290, "Raleigh7@yahoo.com", "Gus", "Kassulke", "password123", 2, "Vada_Kozey" },
                    { 143, 288, "Osvaldo.Marks4@gmail.com", "Nigel", "Waelchi", "password123", 1, "Pedro80" },
                    { 123, 201, "Brock_Hand10@gmail.com", "Ramon", "Schmitt", "password123", 2, "Jaren.Strosin" },
                    { 34, 201, "Meagan_Robel@gmail.com", "Maud", "Terry", "password123", 3, "Jenifer.Deckow81" },
                    { 290, 4, "Camden_Langosh@gmail.com", "Ludwig", "Upton", "password123", 2, "Ewald_Dare22" },
                    { 198, 85, "Helen_Gulgowski@gmail.com", "Bella", "Lueilwitz", "password123", 3, "Grady.Jerde" },
                    { 170, 85, "Eliezer.Farrell@yahoo.com", "Karl", "Beatty", "password123", 1, "Ines_Connelly43" },
                    { 54, 85, "Rossie.Heller34@yahoo.com", "Stefanie", "White", "password123", 1, "Joan23" },
                    { 244, 30, "Cloyd97@yahoo.com", "Mandy", "Stroman", "password123", 3, "Kade.Fay42" },
                    { 50, 30, "Oran.Kohler11@hotmail.com", "Eloisa", "Lakin", "password123", 2, "Dale.Stark88" },
                    { 4, 135, "Aletha_Rippin@gmail.com", "Otis", "Torphy", "password123", 2, "Odell_Raynor" },
                    { 105, 246, "Arjun26@gmail.com", "Myrl", "Senger", "password123", 3, "King.Ritchie59" },
                    { 165, 196, "Abel_Greenfelder72@hotmail.com", "Arvid", "Schultz", "password123", 1, "Curt.Watsica" },
                    { 107, 191, "Will64@gmail.com", "Destinee", "Breitenberg", "password123", 2, "Princess.Leffler91" },
                    { 73, 165, "Katlyn.Leuschke84@yahoo.com", "Hayden", "Legros", "password123", 3, "Percy_Walsh44" },
                    { 41, 165, "Heidi_Windler71@gmail.com", "Zola", "Satterfield", "password123", 3, "Roderick75" },
                    { 29, 165, "Antonina_Torp@hotmail.com", "Julie", "Olson", "password123", 1, "Joanny63" },
                    { 294, 83, "Clifford_Pacocha7@yahoo.com", "Hudson", "Mills", "password123", 2, "Ken_Cruickshank" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 122, 263, "Leda_Considine19@hotmail.com", "Gaetano", "Sauer", "password123", 1, "Zora.Sporer" },
                    { 116, 220, "Ferne_Mueller64@yahoo.com", "Zola", "Schumm", "password123", 3, "Asha18" },
                    { 90, 143, "Amalia_Cronin25@yahoo.com", "Rosanna", "Cartwright", "password123", 1, "Ewell.Bernhard61" },
                    { 134, 201, "Eleonore_Kulas@hotmail.com", "Liliane", "Beatty", "password123", 1, "Leora19" },
                    { 207, 75, "Lolita35@hotmail.com", "Enrique", "Schaefer", "password123", 3, "Fred_Beer38" },
                    { 72, 6, "Creola.Schneider@hotmail.com", "Rosa", "Thiel", "password123", 2, "Ryley.Ryan" },
                    { 69, 257, "Amya_Boehm68@yahoo.com", "Christophe", "Skiles", "password123", 1, "Amira39" },
                    { 151, 161, "Gaston_Kuhn23@yahoo.com", "Rebeca", "Crooks", "password123", 2, "Susan51" },
                    { 117, 161, "Marilou_Dicki35@yahoo.com", "Aiden", "MacGyver", "password123", 2, "Micaela_Stokes" },
                    { 15, 178, "Maudie48@yahoo.com", "Timothy", "Watsica", "password123", 1, "Lisandro60" },
                    { 30, 99, "Scot43@gmail.com", "Jordon", "Berge", "password123", 1, "Heath82" },
                    { 182, 47, "Mariana79@yahoo.com", "Dorcas", "Gottlieb", "password123", 2, "Graciela77" },
                    { 114, 47, "Lilyan_Huels70@yahoo.com", "Judge", "Wilderman", "password123", 3, "Pattie.Torp73" },
                    { 88, 47, "Chadrick_Schuster72@gmail.com", "Michale", "Dare", "password123", 3, "Cornelius.Stracke" },
                    { 156, 48, "Caesar_Lang62@gmail.com", "Bertrand", "Jakubowski", "password123", 3, "Verla_Schmidt76" },
                    { 68, 48, "Dameon66@hotmail.com", "Justine", "Waters", "password123", 2, "Deron.Ritchie29" },
                    { 84, 236, "Mauricio30@gmail.com", "Marlen", "Kuvalis", "password123", 3, "Lurline.Flatley33" },
                    { 18, 236, "Adolphus36@yahoo.com", "Eddie", "Deckow", "password123", 1, "Kenyatta.Waters56" },
                    { 213, 167, "Amir_Heidenreich@hotmail.com", "Tremaine", "Homenick", "password123", 2, "Trycia.Lubowitz59" },
                    { 142, 167, "Jada.Lynch81@hotmail.com", "Makenna", "Pouros", "password123", 1, "Nicole_Daniel56" },
                    { 70, 167, "Prudence.Gorczany65@yahoo.com", "Golda", "Windler", "password123", 1, "Hettie.Beer" },
                    { 138, 95, "Asha.Borer@gmail.com", "Frieda", "Leuschke", "password123", 1, "Dixie_Miller21" },
                    { 274, 20, "Jaron.Bogan51@hotmail.com", "Jayden", "Cormier", "password123", 3, "Cecile_Lubowitz77" },
                    { 212, 20, "Laury.Orn@gmail.com", "Breanna", "Konopelski", "password123", 2, "Bobby51" },
                    { 23, 20, "Pascale72@hotmail.com", "Hoyt", "Graham", "password123", 2, "Mellie_Schinner" },
                    { 269, 283, "Maddison.Hane50@hotmail.com", "Frances", "Trantow", "password123", 2, "Nestor_Herzog" },
                    { 276, 213, "Kirstin_Price@hotmail.com", "Minerva", "Hartmann", "password123", 1, "Lauretta8" },
                    { 101, 46, "Zena.Nitzsche16@hotmail.com", "Johann", "Walker", "password123", 2, "Gwendolyn25" },
                    { 291, 252, "Barry.Howell@yahoo.com", "Taryn", "Gislason", "password123", 2, "Cora_Haag" },
                    { 162, 252, "Vince_Stamm3@hotmail.com", "Willow", "Lueilwitz", "password123", 2, "Mackenzie.Hyatt31" },
                    { 28, 38, "Annabel.Bergnaum@yahoo.com", "Hortense", "Beier", "password123", 2, "Karley_Rodriguez11" },
                    { 176, 81, "Aisha43@gmail.com", "Marina", "Heller", "password123", 1, "Annette66" },
                    { 61, 81, "Cierra.Maggio@hotmail.com", "Chase", "Bahringer", "password123", 3, "Jennie_Windler" },
                    { 98, 5, "Hubert_Orn@gmail.com", "Bethany", "O'Reilly", "password123", 3, "Kelli.Powlowski" },
                    { 277, 293, "Vallie4@yahoo.com", "Reece", "Swift", "password123", 3, "Marge.Stamm88" },
                    { 203, 293, "Sylvan63@hotmail.com", "Weldon", "Krajcik", "password123", 2, "Macey94" },
                    { 97, 293, "Ashton_Okuneva97@gmail.com", "Antoinette", "Morissette", "password123", 3, "Helene20" },
                    { 89, 125, "Cleo4@yahoo.com", "Janiya", "Hermiston", "password123", 2, "Dario.Block" },
                    { 250, 112, "Jade.Swaniawski@gmail.com", "Garnett", "Carter", "password123", 3, "Kirstin.Aufderhar72" },
                    { 227, 112, "Joana_Nolan@yahoo.com", "Carlos", "Wilkinson", "password123", 1, "Wilhelmine_Lockman" },
                    { 135, 112, "Laury71@hotmail.com", "Hunter", "Schaden", "password123", 1, "Regan_Moen95" },
                    { 230, 10, "Verla.Langosh@yahoo.com", "Ricardo", "Stehr", "password123", 1, "Clementine.Mann" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 35, 10, "Roy22@yahoo.com", "Treva", "Romaguera", "password123", 2, "Durward.Rippin59" },
                    { 174, 149, "Hassan27@yahoo.com", "Malvina", "King", "password123", 2, "Enrique.Farrell58" },
                    { 145, 149, "Laverna_Von@gmail.com", "Peggie", "Stracke", "password123", 2, "Gilberto17" },
                    { 181, 195, "Shaylee86@gmail.com", "Johnnie", "Orn", "password123", 1, "Brenna_Volkman86" },
                    { 32, 195, "Emiliano.Kemmer@hotmail.com", "Nikki", "Ward", "password123", 3, "Mireya_Kub" },
                    { 279, 237, "Carolyne.Mitchell11@gmail.com", "Antonietta", "Nikolaus", "password123", 1, "Kaylee46" },
                    { 248, 237, "Althea1@hotmail.com", "Eladio", "Keebler", "password123", 1, "Luigi_Kling" },
                    { 164, 41, "Alexandrine.Leannon32@gmail.com", "Carlee", "Hickle", "password123", 3, "Casey.Monahan" },
                    { 31, 115, "Esperanza_Kuvalis18@yahoo.com", "Mellie", "Jones", "password123", 3, "Reggie16" },
                    { 36, 155, "Mabel.Padberg@hotmail.com", "Prudence", "Thiel", "password123", 1, "Lemuel90" },
                    { 66, 155, "Marley57@yahoo.com", "Edgardo", "Swift", "password123", 1, "Lambert71" },
                    { 187, 162, "Micaela72@gmail.com", "Christopher", "Murazik", "password123", 2, "Giovanna.Ankunding80" },
                    { 20, 162, "Jaeden.MacGyver@hotmail.com", "Jordy", "Powlowski", "password123", 2, "Shaniya99" },
                    { 146, 127, "Dina_Abshire@gmail.com", "Maci", "Carter", "password123", 2, "Maximillian13" },
                    { 271, 77, "Haskell_Rolfson3@gmail.com", "Halie", "Baumbach", "password123", 1, "Rose_Turner93" },
                    { 285, 51, "Jamie_Goodwin79@gmail.com", "Rahsaan", "Kshlerin", "password123", 1, "Abdul.Legros" },
                    { 7, 51, "Connor.Hermiston20@gmail.com", "Violet", "Moen", "password123", 1, "Velda_Crona" },
                    { 67, 226, "Citlalli76@gmail.com", "Felicity", "Murray", "password123", 2, "Gwen.Toy88" },
                    { 168, 199, "Freida26@yahoo.com", "Hipolito", "Corkery", "password123", 1, "Tito_Barton43" },
                    { 77, 199, "Araceli_Goyette@hotmail.com", "Miles", "Quigley", "password123", 1, "Catalina_Corkery" },
                    { 205, 177, "Cale.Cartwright51@gmail.com", "Hazel", "Greenholt", "password123", 3, "Wilma_Luettgen44" },
                    { 297, 170, "Maxie61@gmail.com", "Wilburn", "McGlynn", "password123", 2, "Clotilde.Hermiston" },
                    { 293, 160, "Sabrina_Corwin57@hotmail.com", "Stuart", "Orn", "password123", 3, "Estell.Metz54" },
                    { 127, 160, "Estel_Rowe@gmail.com", "Max", "Dooley", "password123", 1, "Floy20" },
                    { 14, 160, "Vena_OReilly@hotmail.com", "Georgette", "Sauer", "password123", 2, "Stephanie.Blanda" },
                    { 300, 123, "Delia_Beier@hotmail.com", "Shakira", "Harber", "password123", 1, "Rubie_Dach17" },
                    { 253, 122, "Brayan_Walker@gmail.com", "Alexandra", "Zieme", "password123", 1, "Ruby75" },
                    { 10, 96, "Nyasia_Rippin@gmail.com", "Sandra", "Pouros", "password123", 1, "Brandy_Schmitt42" },
                    { 232, 8, "Ines43@gmail.com", "Kade", "Halvorson", "password123", 3, "Raphael.Langosh" },
                    { 231, 8, "Charlie_OConnell@hotmail.com", "Vince", "Jacobs", "password123", 3, "Macy_Durgan" },
                    { 100, 155, "General95@hotmail.com", "Selena", "Torphy", "password123", 2, "Gilbert.MacGyver" },
                    { 178, 170, "Katelyn60@gmail.com", "Imogene", "Turner", "password123", 3, "Brielle.Lockman" },
                    { 99, 63, "Taryn_Trantow13@gmail.com", "Linwood", "Schowalter", "password123", 1, "Kennedi_McKenzie81" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 55, "Runolfsdottir Islands", 204, "Orville5@gmail.com", "Breitenberg LLC", 246, "(568) 057-1771", "www.Breitenberg LLC.com" },
                    { 28, "Gibson Falls", 179, "Demond_Bailey@hotmail.com", "Ward Group", 255, "(166) 845-5645", "www.Ward Group.com" },
                    { 71, "Garrett Track", 189, "Stevie29@hotmail.com", "Littel - Heller", 255, "(832) 215-5494", "www.Littel - Heller.com" },
                    { 87, "Abbie Squares", 245, "Spencer19@yahoo.com", "Cummings, Jakubowski and Lowe", 255, "(733) 916-2646", "www.Cummings, Jakubowski and Lowe.com" },
                    { 52, "Gwendolyn Pass", 136, "Hilario8@gmail.com", "Rath Inc", 103, "(297) 276-4695", "www.Rath Inc.com" },
                    { 92, "Kshlerin Mountain", 11, "Christine.Runte@yahoo.com", "Bernier and Sons", 103, "(670) 183-2920", "www.Bernier and Sons.com" },
                    { 97, "Tremblay Square", 140, "London98@hotmail.com", "Rodriguez, Baumbach and Dickinson", 103, "(983) 452-7779", "www.Rodriguez, Baumbach and Dickinson.com" },
                    { 39, "Garett Ranch", 239, "Peggie_Gleason@hotmail.com", "Murphy - West", 237, "(515) 192-2933", "www.Murphy - West.com" },
                    { 128, "Emmy Ramp", 198, "Desiree.Fritsch@hotmail.com", "Klein and Sons", 103, "(684) 025-6622", "www.Klein and Sons.com" },
                    { 22, "Bode Courts", 198, "Agustina53@gmail.com", "Windler - Leffler", 64, "(878) 485-9890", "www.Windler - Leffler.com" },
                    { 68, "Jada Causeway", 105, "Gail_Kohler@gmail.com", "Heaney Inc", 16, "(678) 006-7763", "www.Heaney Inc.com" },
                    { 47, "Ilene Creek", 269, "Audreanne_Streich@hotmail.com", "Walsh - Leffler", 199, "(772) 802-9202", "www.Walsh - Leffler.com" },
                    { 79, "Angeline Turnpike", 180, "Nickolas_Raynor27@hotmail.com", "Ryan - Schaden", 199, "(007) 162-0438", "www.Ryan - Schaden.com" },
                    { 137, "Demetris Islands", 288, "Wellington_Cormier@gmail.com", "Toy - Kihn", 199, "(593) 791-7873", "www.Toy - Kihn.com" },
                    { 54, "Bergnaum Squares", 80, "Zoila.Ebert36@hotmail.com", "Welch and Sons", 296, "(098) 518-8361", "www.Welch and Sons.com" },
                    { 145, "Treutel Meadow", 266, "Isidro_Huels@yahoo.com", "Jacobs LLC", 103, "(174) 550-4891", "www.Jacobs LLC.com" },
                    { 107, "Britney Stream", 271, "Silas.Farrell@hotmail.com", "Satterfield - Nolan", 22, "(464) 196-1792", "www.Satterfield - Nolan.com" },
                    { 98, "Lilyan Port", 144, "Thelma.Hoeger@hotmail.com", "Kris Inc", 22, "(366) 464-7047", "www.Kris Inc.com" },
                    { 91, "Aufderhar Overpass", 140, "Jewel.Smith@gmail.com", "Jenkins - Harber", 22, "(950) 928-8627", "www.Jenkins - Harber.com" },
                    { 12, "Smith Mission", 64, "Federico62@yahoo.com", "Bogan and Sons", 41, "(977) 196-9226", "www.Bogan and Sons.com" },
                    { 9, "Ward Mountain", 3, "Roxane.Tremblay@hotmail.com", "Ebert, Tremblay and Lakin", 244, "(319) 478-0157", "www.Ebert, Tremblay and Lakin.com" },
                    { 62, "Hodkiewicz Harbor", 272, "Graham_Hoeger43@yahoo.com", "Ernser - Spencer", 244, "(453) 405-3618", "www.Ernser - Spencer.com" },
                    { 42, "Beatty Forks", 284, "Patricia.McDermott@yahoo.com", "Johnson - Kshlerin", 198, "(923) 120-6607", "www.Johnson - Kshlerin.com" },
                    { 126, "Eldridge Neck", 134, "Claudia.Dietrich94@gmail.com", "Collier - Walter", 84, "(601) 151-2053", "www.Collier - Walter.com" },
                    { 59, "Sipes Spur", 172, "Pearlie.Littel27@yahoo.com", "Kunze - Dare", 156, "(887) 439-4282", "www.Kunze - Dare.com" },
                    { 95, "Jeramy Isle", 29, "Darby11@yahoo.com", "Dach - Becker", 156, "(480) 624-1958", "www.Dach - Becker.com" },
                    { 27, "Madie Points", 68, "Wyatt.Spencer24@hotmail.com", "Crooks, Dietrich and Dicki", 114, "(717) 848-6232", "www.Crooks, Dietrich and Dicki.com" },
                    { 73, "Welch Prairie", 167, "Alverta_Cole@hotmail.com", "White, Beahan and Ruecker", 114, "(252) 697-0967", "www.White, Beahan and Ruecker.com" },
                    { 82, "Lueilwitz Forks", 103, "Jamison_Watsica85@gmail.com", "Konopelski, Gibson and Beier", 114, "(402) 271-9001", "www.Konopelski, Gibson and Beier.com" },
                    { 143, "Moore Neck", 162, "Devan_Hintz@yahoo.com", "Windler, Gleichner and Luettgen", 114, "(833) 429-6087", "www.Windler, Gleichner and Luettgen.com" },
                    { 111, "Loren Meadows", 112, "Kory.Gleichner24@gmail.com", "Klocko - Mayer", 205, "(648) 398-6428", "www.Klocko - Mayer.com" },
                    { 125, "Grady Gardens", 18, "Nathan.Schimmel64@yahoo.com", "Wehner - Koch", 205, "(000) 988-2656", "www.Wehner - Koch.com" },
                    { 110, "Lockman Harbors", 106, "Meggie.Bergnaum@hotmail.com", "Ondricka, Goodwin and Nikolaus", 8, "(129) 072-1096", "www.Ondricka, Goodwin and Nikolaus.com" },
                    { 61, "Larson Trace", 19, "Nathaniel.Stokes@hotmail.com", "Barton - Russel", 22, "(839) 871-9751", "www.Barton - Russel.com" },
                    { 33, "Borer Stream", 218, "Cecil_Greenholt@yahoo.com", "Marquardt Group", 63, "(502) 649-7445", "www.Marquardt Group.com" },
                    { 41, "Naomi Ramp", 91, "Brigitte_Hodkiewicz@gmail.com", "Conroy LLC", 63, "(782) 505-7863", "www.Conroy LLC.com" },
                    { 48, "Wiza Estates", 18, "Hermina67@gmail.com", "West, Swaniawski and DuBuque", 63, "(085) 835-6901", "www.West, Swaniawski and DuBuque.com" },
                    { 104, "Hand Burg", 231, "Paolo_Schroeder@hotmail.com", "Effertz, Trantow and Ritchie", 63, "(090) 941-0473", "www.Effertz, Trantow and Ritchie.com" },
                    { 120, "Amelia Passage", 259, "Lori42@gmail.com", "Haley LLC", 60, "(293) 374-4562", "www.Haley LLC.com" },
                    { 123, "Layne Circle", 242, "Alexys53@gmail.com", "Simonis LLC", 60, "(837) 071-4716", "www.Simonis LLC.com" },
                    { 114, "Schroeder Via", 206, "Alexa_McClure82@yahoo.com", "Wilkinson, Hermann and Bayer", 159, "(010) 390-6786", "www.Wilkinson, Hermann and Bayer.com" },
                    { 115, "Bernhard Camp", 34, "Elfrieda_Schiller@yahoo.com", "Wiza Inc", 159, "(440) 813-2843", "www.Wiza Inc.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 34, "Alana Radial", 4, "Marlen_Wuckert5@yahoo.com", "Boehm - Green", 254, "(116) 109-1781", "www.Boehm - Green.com" },
                    { 90, "Boyle Plaza", 32, "Aisha_Kilback@hotmail.com", "Schimmel Group", 254, "(403) 151-0397", "www.Schimmel Group.com" },
                    { 69, "Schroeder Mountain", 233, "Guadalupe50@gmail.com", "Donnelly - Dach", 233, "(317) 716-3819", "www.Donnelly - Dach.com" },
                    { 101, "Burdette Islands", 222, "Dorothy.Dicki5@yahoo.com", "Von Group", 233, "(156) 320-3531", "www.Von Group.com" },
                    { 7, "Carroll Station", 154, "Alf_Luettgen80@hotmail.com", "Gleichner and Sons", 157, "(943) 915-4758", "www.Gleichner and Sons.com" },
                    { 24, "Mayer Groves", 247, "Jonatan11@yahoo.com", "Hoeger - Abernathy", 226, "(872) 641-9759", "www.Hoeger - Abernathy.com" },
                    { 56, "Kuphal Canyon", 110, "Quinten21@hotmail.com", "Rohan, Lockman and Graham", 226, "(457) 896-4783", "www.Rohan, Lockman and Graham.com" },
                    { 26, "Wehner Court", 25, "Simeon.McClure@yahoo.com", "Weimann - Goyette", 129, "(867) 349-7681", "www.Weimann - Goyette.com" },
                    { 49, "Robbie Glen", 49, "Astrid_Shanahan@hotmail.com", "Labadie Inc", 129, "(795) 635-3578", "www.Labadie Inc.com" },
                    { 18, "Connelly Village", 31, "Dorris3@hotmail.com", "Denesik - Emard", 228, "(960) 463-0632", "www.Denesik - Emard.com" },
                    { 149, "Freda Road", 78, "Lauren_Price1@hotmail.com", "Olson, Schmeler and Skiles", 228, "(717) 323-2173", "www.Olson, Schmeler and Skiles.com" },
                    { 103, "Lucy Field", 82, "Valentine45@gmail.com", "Lind, Vandervort and White", 60, "(281) 113-6782", "www.Lind, Vandervort and White.com" },
                    { 122, "Cathy Field", 13, "Carroll34@gmail.com", "Kiehn and Sons", 116, "(829) 441-1707", "www.Kiehn and Sons.com" },
                    { 11, "Misael Walks", 60, "Misty59@gmail.com", "Buckridge - Dietrich", 60, "(974) 992-0249", "www.Buckridge - Dietrich.com" },
                    { 109, "Eric Grove", 242, "Craig_Williamson@gmail.com", "Predovic, Jast and Cremin", 241, "(919) 769-6022", "www.Predovic, Jast and Cremin.com" },
                    { 118, "Considine Crossroad", 92, "Kaycee_Shields36@gmail.com", "Russel LLC", 63, "(771) 607-6461", "www.Russel LLC.com" },
                    { 17, "Cordelia Fords", 35, "Levi75@yahoo.com", "Ernser, Effertz and Bradtke", 37, "(932) 016-7220", "www.Ernser, Effertz and Bradtke.com" },
                    { 45, "Rhiannon Street", 81, "Emile17@gmail.com", "Spencer - Wyman", 275, "(715) 472-7254", "www.Spencer - Wyman.com" },
                    { 130, "Buckridge Cape", 152, "Matilda.Beahan@gmail.com", "Rau - Kassulke", 275, "(414) 155-1874", "www.Rau - Kassulke.com" },
                    { 150, "Miracle Mews", 145, "Milton63@gmail.com", "Nitzsche, Morissette and Lakin", 75, "(744) 154-2251", "www.Nitzsche, Morissette and Lakin.com" },
                    { 13, "Kelli Extension", 208, "Baron_Deckow@gmail.com", "Muller - Bartell", 26, "(381) 572-1918", "www.Muller - Bartell.com" },
                    { 23, "Helmer Rue", 182, "Brenna5@hotmail.com", "Weber Group", 26, "(212) 017-8229", "www.Weber Group.com" },
                    { 136, "Hudson Plaza", 14, "Jamal.Quitzon@yahoo.com", "Reilly, Berge and Kertzmann", 26, "(249) 122-6170", "www.Reilly, Berge and Kertzmann.com" },
                    { 147, "Andy Cape", 240, "Cristopher42@gmail.com", "Kessler Inc", 26, "(836) 240-7027", "www.Kessler Inc.com" },
                    { 58, "Friesen Passage", 224, "Katharina51@hotmail.com", "Hansen and Sons", 47, "(232) 877-3891", "www.Hansen and Sons.com" },
                    { 15, "Stokes Turnpike", 247, "Candelario95@hotmail.com", "Armstrong, VonRueden and Crona", 76, "(004) 569-5995", "www.Armstrong, VonRueden and Crona.com" },
                    { 100, "Agnes Streets", 16, "Emil13@yahoo.com", "Kuhic and Sons", 76, "(972) 609-6393", "www.Kuhic and Sons.com" },
                    { 80, "Green Locks", 99, "Delta30@hotmail.com", "Okuneva LLC", 160, "(714) 988-3710", "www.Okuneva LLC.com" },
                    { 140, "Powlowski Road", 16, "Zoey.Hills@hotmail.com", "Hudson, Schiller and Quigley", 160, "(197) 962-8218", "www.Hudson, Schiller and Quigley.com" },
                    { 31, "Wilderman Neck", 161, "Delta13@hotmail.com", "Frami and Sons", 241, "(867) 819-0844", "www.Frami and Sons.com" },
                    { 2, "Efren Cape", 239, "Brandon53@gmail.com", "Considine - Jakubowski", 60, "(233) 849-0419", "www.Considine - Jakubowski.com" },
                    { 121, "Summer Fort", 226, "Marie_Schuster@hotmail.com", "D'Amore, Dach and Feeney", 116, "(154) 315-9265", "www.D'Amore, Dach and Feeney.com" },
                    { 144, "Brant Overpass", 41, "Tiana70@hotmail.com", "Sauer - Moen", 275, "(597) 526-2948", "www.Sauer - Moen.com" },
                    { 38, "Stoltenberg Highway", 166, "Scotty.Jerde77@yahoo.com", "Bernhard, Doyle and Jerde", 116, "(642) 005-3688", "www.Bernhard, Doyle and Jerde.com" },
                    { 25, "Hailey Haven", 71, "Aliya25@hotmail.com", "Nicolas Group", 288, "(259) 231-3838", "www.Nicolas Group.com" },
                    { 96, "Sage Cliffs", 253, "Henri_Kihn@hotmail.com", "Reichert Group", 288, "(184) 552-3961", "www.Reichert Group.com" },
                    { 108, "Candace Park", 249, "Mason_Sauer67@gmail.com", "Runte, Morar and Effertz", 288, "(873) 867-3530", "www.Runte, Morar and Effertz.com" },
                    { 142, "Preston Circles", 279, "Camden_Ondricka@gmail.com", "Leuschke, Ernser and Rolfson", 288, "(300) 093-3023", "www.Leuschke, Ernser and Rolfson.com" },
                    { 72, "Jazmyne Light", 200, "Guido.Muller1@yahoo.com", "Wehner - O'Reilly", 5, "(532) 864-7948", "www.Wehner - O'Reilly.com" },
                    { 78, "Green Cove", 96, "Travis5@hotmail.com", "Harber and Sons", 5, "(880) 327-8537", "www.Harber and Sons.com" },
                    { 1, "Elwyn Squares", 250, "Haleigh39@gmail.com", "Bahringer, O'Keefe and Daniel", 21, "(665) 726-7232", "www.Bahringer, O'Keefe and Daniel.com" },
                    { 29, "Pacocha Spring", 63, "Rodger_Swaniawski47@gmail.com", "Feil - Welch", 21, "(712) 749-9872", "www.Feil - Welch.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 148, "Frank Square", 169, "Terrence_Batz@yahoo.com", "Osinski, Mayert and Howe", 21, "(903) 845-8307", "www.Osinski, Mayert and Howe.com" },
                    { 112, "Linnie Unions", 118, "Camylle27@hotmail.com", "O'Reilly - Nienow", 218, "(807) 463-2266", "www.O'Reilly - Nienow.com" },
                    { 129, "Nolan Creek", 8, "Rahsaan.Lind53@yahoo.com", "Toy - Harvey", 218, "(492) 595-7874", "www.Toy - Harvey.com" },
                    { 6, "Darien Forest", 274, "Afton_McDermott@gmail.com", "Morar, Leuschke and Leuschke", 196, "(318) 295-1523", "www.Morar, Leuschke and Leuschke.com" },
                    { 67, "Johnson Park", 73, "Immanuel_Johns22@hotmail.com", "Torp, Mitchell and Kiehn", 196, "(225) 429-4772", "www.Torp, Mitchell and Kiehn.com" },
                    { 19, "Dorian Hills", 206, "Carli.Bartell40@gmail.com", "Glover Inc", 299, "(531) 350-1047", "www.Glover Inc.com" },
                    { 50, "Ritchie Trafficway", 165, "Rhianna_Greenholt@hotmail.com", "Kiehn Inc", 234, "(645) 832-8605", "www.Kiehn Inc.com" },
                    { 132, "Lesly Freeway", 244, "Shanelle84@yahoo.com", "King - Pouros", 282, "(485) 453-9832", "www.King - Pouros.com" },
                    { 84, "Wiegand Fork", 143, "Conor_Steuber@hotmail.com", "Goldner and Sons", 234, "(209) 769-6770", "www.Goldner and Sons.com" },
                    { 117, "Nathanial Row", 2, "Carleton_Koch75@hotmail.com", "Mayert - Willms", 282, "(506) 017-1555", "www.Mayert - Willms.com" },
                    { 64, "Fern Fords", 164, "Terrance_Raynor@yahoo.com", "Johnson and Sons", 239, "(316) 221-3047", "www.Johnson and Sons.com" },
                    { 102, "Jailyn Parkways", 151, "Emmie_Padberg84@yahoo.com", "Sipes, Upton and Lindgren", 116, "(906) 302-1091", "www.Sipes, Upton and Lindgren.com" },
                    { 89, "Shaun Ridge", 139, "Elda62@yahoo.com", "Purdy - Mills", 3, "(574) 546-3518", "www.Purdy - Mills.com" },
                    { 85, "Pink Squares", 18, "Rigoberto82@gmail.com", "Ernser Inc", 183, "(976) 103-5775", "www.Ernser Inc.com" },
                    { 133, "Ramiro Mill", 137, "Everett42@yahoo.com", "Ferry, Ankunding and Torphy", 256, "(999) 353-3441", "www.Ferry, Ankunding and Torphy.com" },
                    { 8, "Mitchell Point", 113, "Alvera_Rempel@hotmail.com", "Harvey, Schimmel and Cummerata", 161, "(569) 079-2078", "www.Harvey, Schimmel and Cummerata.com" },
                    { 14, "Hudson Greens", 221, "Arlene5@hotmail.com", "Howell and Sons", 161, "(268) 305-8962", "www.Howell and Sons.com" },
                    { 36, "Nicolas Hollow", 271, "Casimer_Gibson54@hotmail.com", "Luettgen, Kutch and Sawayn", 161, "(899) 530-4628", "www.Luettgen, Kutch and Sawayn.com" },
                    { 88, "Jaydon Lodge", 95, "Lenore72@gmail.com", "Strosin - Halvorson", 161, "(426) 345-8106", "www.Strosin - Halvorson.com" },
                    { 44, "Schmeler Station", 271, "Nicklaus.Hessel73@yahoo.com", "Crooks, Terry and Schiller", 81, "(808) 868-3198", "www.Crooks, Terry and Schiller.com" },
                    { 57, "Mosciski Wells", 261, "Emilio69@hotmail.com", "Feil Group", 287, "(520) 196-3581", "www.Feil Group.com" },
                    { 77, "Hermann Springs", 36, "Nya40@hotmail.com", "Deckow, Jacobs and Larkin", 287, "(179) 771-9567", "www.Deckow, Jacobs and Larkin.com" },
                    { 141, "Schaden Row", 111, "Kristin.Pagac@hotmail.com", "Walter - Metz", 287, "(515) 175-6177", "www.Walter - Metz.com" },
                    { 32, "Gregoria Cape", 259, "Lizzie_Watsica@hotmail.com", "Funk Inc", 180, "(695) 773-4635", "www.Funk Inc.com" },
                    { 16, "Halvorson Vista", 132, "Efren_Goodwin78@gmail.com", "Schuppe - Schmidt", 239, "(454) 603-9217", "www.Schuppe - Schmidt.com" },
                    { 20, "Joaquin Way", 126, "Kelley7@yahoo.com", "Hartmann, Orn and Herman", 239, "(970) 154-1665", "www.Hartmann, Orn and Herman.com" },
                    { 37, "Laverne Point", 59, "Antoinette34@hotmail.com", "Cummerata Inc", 282, "(957) 988-0887", "www.Cummerata Inc.com" },
                    { 53, "Yoshiko Tunnel", 193, "Everette_Funk@hotmail.com", "Bailey - Balistreri", 261, "(647) 628-9194", "www.Bailey - Balistreri.com" },
                    { 74, "Helga Summit", 173, "Evelyn47@yahoo.com", "Kovacek - Jacobson", 239, "(869) 732-6841", "www.Kovacek - Jacobson.com" },
                    { 75, "Gisselle Village", 267, "Velma.Pouros@gmail.com", "Lueilwitz - Parker", 144, "(019) 559-3647", "www.Lueilwitz - Parker.com" },
                    { 70, "Kozey Trafficway", 136, "Teresa32@gmail.com", "Swift Group", 277, "(383) 756-8264", "www.Swift Group.com" },
                    { 119, "Georgianna Ports", 176, "Jeramy_Smith6@yahoo.com", "Bradtke Group", 277, "(391) 585-0429", "www.Bradtke Group.com" },
                    { 116, "Sporer Passage", 250, "Rickie.Mills@gmail.com", "Windler - Bechtelar", 98, "(213) 181-6581", "www.Windler - Bechtelar.com" },
                    { 3, "Dudley Light", 248, "Rashad.Fisher@hotmail.com", "Kirlin Group", 61, "(157) 984-1585", "www.Kirlin Group.com" },
                    { 4, "Dion Gardens", 118, "Zelma0@hotmail.com", "Sanford - Stokes", 61, "(320) 365-5907", "www.Sanford - Stokes.com" },
                    { 134, "Mosciski Harbor", 37, "Dagmar_Bashirian20@yahoo.com", "Kunze, Harris and Schamberger", 31, "(227) 085-8286", "www.Kunze, Harris and Schamberger.com" },
                    { 66, "Collier Hills", 46, "Letha59@hotmail.com", "Hartmann LLC", 231, "(627) 276-6640", "www.Hartmann LLC.com" },
                    { 21, "Kennith Glens", 177, "Trace6@gmail.com", "Weber - Stanton", 232, "(902) 475-0895", "www.Weber - Stanton.com" },
                    { 35, "Jerel Stravenue", 211, "Mckenzie83@hotmail.com", "Steuber - Schmeler", 293, "(335) 355-3447", "www.Steuber - Schmeler.com" },
                    { 51, "Spencer Estates", 56, "Mariana89@hotmail.com", "Considine and Sons", 293, "(122) 856-9123", "www.Considine and Sons.com" },
                    { 124, "Breitenberg Court", 294, "Bernie_Hoppe@hotmail.com", "Denesik LLC", 293, "(472) 360-0029", "www.Denesik LLC.com" },
                    { 127, "Ruthe Ridge", 228, "Ayden_Jenkins@gmail.com", "Sipes - Welch", 293, "(882) 988-8591", "www.Sipes - Welch.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 63, "Floy Keys", 260, "Silas47@hotmail.com", "Schiller Inc", 207, "(070) 495-9165", "www.Schiller Inc.com" },
                    { 76, "Muller Inlet", 221, "Brooke52@hotmail.com", "Ledner, Legros and Dickinson", 221, "(512) 497-6729", "www.Ledner, Legros and Dickinson.com" },
                    { 94, "Rolfson Street", 152, "Kenton69@yahoo.com", "Thiel, Lindgren and Witting", 207, "(323) 901-7098", "www.Thiel, Lindgren and Witting.com" },
                    { 106, "Botsford Corners", 232, "Josue18@hotmail.com", "Kshlerin, Murazik and Cummerata", 97, "(164) 894-6404", "www.Kshlerin, Murazik and Cummerata.com" },
                    { 46, "Imogene Gardens", 74, "Francisca38@hotmail.com", "Rogahn, Wilkinson and Jerde", 97, "(962) 649-5228", "www.Rogahn, Wilkinson and Jerde.com" },
                    { 99, "Batz Stravenue", 257, "Nellie1@hotmail.com", "Beahan LLC", 164, "(661) 178-2704", "www.Beahan LLC.com" },
                    { 138, "Hudson Freeway", 74, "Hassan99@hotmail.com", "Osinski - Gottlieb", 250, "(297) 227-6993", "www.Osinski - Gottlieb.com" },
                    { 5, "Monserrat Stravenue", 62, "Kenneth59@gmail.com", "Rowe, Yundt and Powlowski", 171, "(132) 494-2537", "www.Rowe, Yundt and Powlowski.com" },
                    { 146, "Sanford Stravenue", 7, "Milo_Stamm57@gmail.com", "Beahan, Lind and Prohaska", 250, "(440) 264-8313", "www.Beahan, Lind and Prohaska.com" },
                    { 83, "Shannon Underpass", 229, "Daryl40@gmail.com", "Hayes, Erdman and Rolfson", 171, "(890) 825-9057", "www.Hayes, Erdman and Rolfson.com" },
                    { 40, "Jett Trace", 190, "Carrie_Orn@gmail.com", "Durgan Inc", 193, "(847) 182-6018", "www.Durgan Inc.com" },
                    { 105, "Betty Crossroad", 173, "Melvina.Haley@yahoo.com", "Bartoletti LLC", 263, "(483) 342-7200", "www.Bartoletti LLC.com" },
                    { 86, "Windler Well", 236, "Leanne35@hotmail.com", "Hills, Grady and Wunsch", 144, "(105) 285-5299", "www.Hills, Grady and Wunsch.com" },
                    { 93, "Evans Crescent", 247, "Marisa.Zulauf@gmail.com", "Romaguera Group", 200, "(440) 866-1318", "www.Romaguera Group.com" },
                    { 131, "Beatty Station", 224, "Layla30@gmail.com", "Grady Inc", 286, "(889) 708-8602", "www.Grady Inc.com" },
                    { 65, "Haley Gardens", 13, "Marilie49@gmail.com", "Yundt, Batz and Wunsch", 200, "(192) 731-1063", "www.Yundt, Batz and Wunsch.com" },
                    { 113, "Tina Dale", 291, "Omari.Wuckert@gmail.com", "Cartwright, Emmerich and Batz", 257, "(783) 810-9282", "www.Cartwright, Emmerich and Batz.com" },
                    { 30, "Purdy Estates", 245, "Barry_Rohan@hotmail.com", "Reilly LLC", 11, "(792) 774-0487", "www.Reilly LLC.com" },
                    { 43, "Emelia Fork", 4, "Iva.Lockman71@hotmail.com", "Schamberger and Sons", 11, "(444) 208-7993", "www.Schamberger and Sons.com" },
                    { 60, "Vance Canyon", 279, "Alysson_Stiedemann@gmail.com", "Reichel LLC", 11, "(942) 642-1971", "www.Reichel LLC.com" },
                    { 81, "Jena Trail", 286, "Kayley_Lehner@gmail.com", "Russel, Batz and Green", 250, "(335) 231-1941", "www.Russel, Batz and Green.com" },
                    { 135, "Erna Pike", 280, "Marc20@gmail.com", "Littel LLC", 250, "(548) 471-1452", "www.Littel LLC.com" },
                    { 10, "Lilla Parkways", 14, "Nicholas_Halvorson66@hotmail.com", "Wiegand Inc", 257, "(677) 729-3137", "www.Wiegand Inc.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 30, new DateTime(2021, 3, 17, 5, 0, 54, 360, DateTimeKind.Local).AddTicks(3757), 729920, 21, "6346087" },
                    { 20, new DateTime(2021, 6, 19, 4, 15, 37, 249, DateTimeKind.Local).AddTicks(8359), 257501, 21, "6500482" },
                    { 12, new DateTime(2020, 11, 18, 8, 58, 35, 291, DateTimeKind.Local).AddTicks(7472), 48672, 21, "1341978" },
                    { 68, new DateTime(2021, 8, 12, 17, 48, 27, 793, DateTimeKind.Local).AddTicks(2365), 773396, 97, "6331634" },
                    { 34, new DateTime(2021, 5, 15, 20, 42, 14, 751, DateTimeKind.Local).AddTicks(3858), 704061, 11, "7701060" },
                    { 25, new DateTime(2020, 9, 4, 17, 0, 9, 302, DateTimeKind.Local).AddTicks(8502), 446500, 97, "6892521" },
                    { 65, new DateTime(2021, 3, 23, 5, 44, 23, 519, DateTimeKind.Local).AddTicks(2556), 230134, 14, "4058520" },
                    { 54, new DateTime(2020, 9, 9, 14, 52, 18, 893, DateTimeKind.Local).AddTicks(3242), 702174, 65, "3796832" },
                    { 14, new DateTime(2021, 1, 26, 7, 30, 41, 124, DateTimeKind.Local).AddTicks(9045), 906408, 65, "8124538" },
                    { 23, new DateTime(2020, 9, 10, 16, 44, 16, 606, DateTimeKind.Local).AddTicks(6633), 595802, 51, "6572460" },
                    { 67, new DateTime(2021, 1, 27, 6, 24, 58, 532, DateTimeKind.Local).AddTicks(56), 188909, 52, "6801157" },
                    { 33, new DateTime(2020, 11, 15, 20, 19, 15, 149, DateTimeKind.Local).AddTicks(80), 29289, 52, "5179455" },
                    { 37, new DateTime(2021, 3, 13, 12, 59, 35, 752, DateTimeKind.Local).AddTicks(3204), 321711, 76, "8811902" },
                    { 13, new DateTime(2020, 10, 11, 2, 2, 39, 397, DateTimeKind.Local).AddTicks(7705), 394364, 76, "8147020" },
                    { 43, new DateTime(2021, 7, 9, 8, 1, 56, 192, DateTimeKind.Local).AddTicks(1533), 33431, 74, "7997112" },
                    { 22, new DateTime(2021, 7, 17, 7, 5, 29, 255, DateTimeKind.Local).AddTicks(2768), 339752, 13, "7829463" },
                    { 5, new DateTime(2021, 4, 24, 9, 47, 58, 977, DateTimeKind.Local).AddTicks(9652), 881798, 49, "1254151" },
                    { 10, new DateTime(2021, 8, 19, 14, 18, 25, 751, DateTimeKind.Local).AddTicks(6110), 947894, 72, "2527382" },
                    { 71, new DateTime(2020, 10, 2, 6, 39, 3, 621, DateTimeKind.Local).AddTicks(1376), 76460, 52, "4993744" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 69, new DateTime(2021, 8, 26, 18, 48, 58, 774, DateTimeKind.Local).AddTicks(2305), 445611, 49, "1859354" },
                    { 21, new DateTime(2020, 12, 15, 17, 50, 34, 875, DateTimeKind.Local).AddTicks(8876), 122354, 9, "3177375" },
                    { 63, new DateTime(2021, 8, 24, 23, 27, 55, 665, DateTimeKind.Local).AddTicks(2933), 589948, 37, "7880151" },
                    { 74, new DateTime(2020, 11, 26, 20, 4, 35, 757, DateTimeKind.Local).AddTicks(9268), 818808, 84, "5250749" },
                    { 61, new DateTime(2021, 2, 28, 5, 9, 54, 526, DateTimeKind.Local).AddTicks(6830), 955565, 80, "9319766" },
                    { 87, new DateTime(2021, 7, 16, 12, 3, 30, 543, DateTimeKind.Local).AddTicks(6097), 788448, 59, "7691574" },
                    { 59, new DateTime(2020, 12, 22, 15, 22, 48, 516, DateTimeKind.Local).AddTicks(9706), 372789, 59, "7381174" },
                    { 27, new DateTime(2021, 4, 7, 23, 2, 56, 594, DateTimeKind.Local).AddTicks(7772), 392212, 59, "9713551" },
                    { 56, new DateTime(2020, 11, 1, 20, 29, 33, 241, DateTimeKind.Local).AddTicks(4028), 971703, 48, "1701530" },
                    { 47, new DateTime(2020, 10, 31, 11, 49, 35, 35, DateTimeKind.Local).AddTicks(841), 383787, 48, "8440039" },
                    { 89, new DateTime(2021, 1, 8, 1, 23, 31, 547, DateTimeKind.Local).AddTicks(2088), 682312, 87, "9626840" },
                    { 88, new DateTime(2020, 10, 4, 23, 57, 49, 222, DateTimeKind.Local).AddTicks(2493), 885408, 58, "1210963" },
                    { 60, new DateTime(2020, 12, 14, 12, 35, 27, 491, DateTimeKind.Local).AddTicks(6090), 922110, 58, "9410722" },
                    { 28, new DateTime(2021, 6, 7, 17, 47, 26, 930, DateTimeKind.Local).AddTicks(9210), 94251, 12, "3302682" },
                    { 8, new DateTime(2021, 7, 2, 23, 59, 25, 72, DateTimeKind.Local).AddTicks(5403), 902198, 12, "9893008" },
                    { 70, new DateTime(2021, 7, 9, 13, 1, 39, 132, DateTimeKind.Local).AddTicks(9239), 717902, 32, "8774023" },
                    { 50, new DateTime(2021, 3, 29, 1, 38, 37, 422, DateTimeKind.Local).AddTicks(2813), 203662, 32, "5384059" },
                    { 36, new DateTime(2020, 12, 22, 6, 16, 39, 242, DateTimeKind.Local).AddTicks(8051), 890862, 31, "7496332" },
                    { 73, new DateTime(2021, 7, 12, 19, 56, 22, 665, DateTimeKind.Local).AddTicks(2049), 320768, 40, "4167083" },
                    { 39, new DateTime(2021, 6, 26, 10, 0, 57, 552, DateTimeKind.Local).AddTicks(5617), 246607, 40, "3238553" },
                    { 15, new DateTime(2021, 2, 7, 3, 52, 43, 371, DateTimeKind.Local).AddTicks(4946), 752320, 40, "3954754" },
                    { 81, new DateTime(2021, 5, 5, 11, 30, 16, 595, DateTimeKind.Local).AddTicks(14), 278657, 37, "6370253" },
                    { 41, new DateTime(2021, 3, 18, 16, 3, 47, 883, DateTimeKind.Local).AddTicks(4986), 194125, 37, "6885482" },
                    { 11, new DateTime(2021, 6, 11, 9, 41, 17, 482, DateTimeKind.Local).AddTicks(322), 467398, 80, "3382410" },
                    { 31, new DateTime(2021, 8, 5, 18, 51, 23, 652, DateTimeKind.Local).AddTicks(3059), 309449, 91, "7532371" },
                    { 38, new DateTime(2021, 5, 14, 20, 22, 34, 419, DateTimeKind.Local).AddTicks(9198), 954338, 17, "2714948" },
                    { 79, new DateTime(2020, 11, 2, 0, 30, 46, 899, DateTimeKind.Local).AddTicks(8463), 727460, 88, "7426779" },
                    { 9, new DateTime(2021, 2, 17, 1, 57, 57, 186, DateTimeKind.Local).AddTicks(9375), 667657, 88, "7587349" },
                    { 7, new DateTime(2021, 5, 13, 20, 16, 45, 338, DateTimeKind.Local).AddTicks(1151), 967451, 88, "1403988" },
                    { 86, new DateTime(2021, 6, 8, 4, 38, 31, 558, DateTimeKind.Local).AddTicks(2963), 487364, 50, "7425055" },
                    { 83, new DateTime(2021, 1, 28, 14, 33, 27, 45, DateTimeKind.Local).AddTicks(7197), 332489, 20, "2658614" },
                    { 64, new DateTime(2020, 10, 27, 15, 20, 23, 326, DateTimeKind.Local).AddTicks(9462), 328305, 20, "7910612" },
                    { 46, new DateTime(2020, 9, 16, 14, 49, 8, 913, DateTimeKind.Local).AddTicks(8839), 757152, 15, "9749288" },
                    { 29, new DateTime(2021, 3, 5, 3, 51, 59, 9, DateTimeKind.Local).AddTicks(7977), 257707, 30, "3657229" },
                    { 62, new DateTime(2021, 3, 30, 1, 11, 22, 151, DateTimeKind.Local).AddTicks(2828), 639461, 36, "8754440" },
                    { 48, new DateTime(2021, 6, 16, 15, 55, 39, 652, DateTimeKind.Local).AddTicks(6160), 311259, 91, "1346214" },
                    { 32, new DateTime(2021, 5, 12, 15, 47, 53, 994, DateTimeKind.Local).AddTicks(6600), 734974, 91, "9075028" },
                    { 19, new DateTime(2021, 7, 10, 7, 57, 22, 567, DateTimeKind.Local).AddTicks(487), 329358, 64, "4563637" },
                    { 75, new DateTime(2021, 1, 15, 19, 46, 2, 39, DateTimeKind.Local).AddTicks(5685), 191863, 22, "3253503" },
                    { 49, new DateTime(2021, 3, 10, 14, 14, 17, 900, DateTimeKind.Local).AddTicks(4902), 715969, 22, "4756673" },
                    { 77, new DateTime(2021, 1, 19, 1, 53, 14, 666, DateTimeKind.Local).AddTicks(3672), 374039, 73, "3111864" },
                    { 58, new DateTime(2021, 5, 19, 2, 52, 2, 364, DateTimeKind.Local).AddTicks(7394), 557458, 73, "6796358" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 24, new DateTime(2021, 3, 17, 7, 14, 4, 6, DateTimeKind.Local).AddTicks(2225), 668722, 44, "3434246" },
                    { 2, new DateTime(2021, 8, 10, 14, 33, 1, 887, DateTimeKind.Local).AddTicks(3488), 632831, 44, "8112173" },
                    { 3, new DateTime(2021, 5, 13, 12, 26, 29, 471, DateTimeKind.Local).AddTicks(2121), 196938, 90, "6777492" },
                    { 44, new DateTime(2021, 4, 18, 12, 17, 16, 34, DateTimeKind.Local).AddTicks(5959), 553458, 4, "3768015" },
                    { 78, new DateTime(2020, 11, 28, 20, 1, 45, 635, DateTimeKind.Local).AddTicks(7876), 382750, 17, "4492198" },
                    { 51, new DateTime(2021, 5, 6, 4, 52, 50, 485, DateTimeKind.Local).AddTicks(7778), 11496, 4, "1592894" },
                    { 80, new DateTime(2021, 1, 17, 17, 51, 45, 735, DateTimeKind.Local).AddTicks(2304), 655411, 45, "9831474" },
                    { 53, new DateTime(2021, 6, 15, 4, 10, 17, 927, DateTimeKind.Local).AddTicks(9118), 336345, 86, "6559922" },
                    { 52, new DateTime(2021, 6, 22, 15, 10, 18, 107, DateTimeKind.Local).AddTicks(4609), 898656, 86, "3289787" },
                    { 26, new DateTime(2021, 7, 15, 2, 14, 5, 999, DateTimeKind.Local).AddTicks(6379), 351663, 23, "6100666" },
                    { 6, new DateTime(2021, 7, 30, 5, 44, 58, 109, DateTimeKind.Local).AddTicks(7950), 26862, 23, "9067371" },
                    { 42, new DateTime(2021, 3, 12, 9, 9, 45, 535, DateTimeKind.Local).AddTicks(9213), 392681, 1, "2737944" },
                    { 18, new DateTime(2021, 2, 28, 23, 2, 38, 590, DateTimeKind.Local).AddTicks(2613), 910814, 1, "9250186" },
                    { 85, new DateTime(2021, 4, 20, 20, 41, 46, 13, DateTimeKind.Local).AddTicks(2167), 401340, 6, "1389765" },
                    { 4, new DateTime(2021, 1, 26, 15, 6, 35, 20, DateTimeKind.Local).AddTicks(7690), 417135, 6, "5087647" },
                    { 1, new DateTime(2021, 4, 20, 6, 41, 38, 230, DateTimeKind.Local).AddTicks(8785), 848249, 78, "8055819" },
                    { 55, new DateTime(2021, 8, 21, 11, 50, 29, 527, DateTimeKind.Local).AddTicks(3492), 648172, 29, "7186210" },
                    { 35, new DateTime(2020, 11, 1, 3, 39, 16, 123, DateTimeKind.Local).AddTicks(5086), 140953, 29, "4126937" },
                    { 57, new DateTime(2021, 7, 28, 13, 2, 13, 834, DateTimeKind.Local).AddTicks(446), 355332, 81, "8421201" },
                    { 40, new DateTime(2021, 4, 4, 22, 20, 54, 951, DateTimeKind.Local).AddTicks(5222), 403860, 61, "8295496" },
                    { 72, new DateTime(2021, 7, 26, 19, 39, 29, 940, DateTimeKind.Local).AddTicks(3384), 985902, 85, "7175839" },
                    { 76, new DateTime(2021, 8, 24, 15, 56, 44, 721, DateTimeKind.Local).AddTicks(8299), 859810, 69, "3019793" },
                    { 84, new DateTime(2021, 3, 20, 17, 14, 38, 195, DateTimeKind.Local).AddTicks(1614), 186825, 35, "9490629" },
                    { 45, new DateTime(2020, 9, 28, 18, 52, 14, 794, DateTimeKind.Local).AddTicks(3788), 86457, 35, "2527899" },
                    { 82, new DateTime(2021, 5, 21, 1, 13, 26, 479, DateTimeKind.Local).AddTicks(2163), 512611, 27, "7487222" },
                    { 66, new DateTime(2021, 8, 6, 20, 12, 20, 0, DateTimeKind.Local).AddTicks(7682), 244679, 27, "8436381" },
                    { 16, new DateTime(2020, 12, 9, 10, 37, 7, 926, DateTimeKind.Local).AddTicks(8812), 557635, 39, "1719733" },
                    { 17, new DateTime(2021, 8, 3, 23, 33, 44, 122, DateTimeKind.Local).AddTicks(8078), 207344, 90, "4503697" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 7, 2, 37, 177187, new DateTime(2020, 9, 7, 5, 15, 40, 466, DateTimeKind.Local).AddTicks(7705), "et" },
                    { 242, 37, 48, 698546, new DateTime(2020, 10, 3, 16, 20, 15, 644, DateTimeKind.Local).AddTicks(7732), "deserunt" },
                    { 341, 37, 145, 260065, new DateTime(2021, 5, 8, 9, 42, 16, 574, DateTimeKind.Local).AddTicks(3260), "Dicta est debitis laboriosam accusamus consectetur perferendis suscipit.\nEt aut illum.\nDolore quas mollitia ut eaque placeat.\nEveniet perspiciatis quas eos repellat molestiae et ex aut blanditiis.\nQui consectetur nam quae deleniti aut adipisci quia tempore adipisci." },
                    { 351, 37, 122, 620293, new DateTime(2020, 9, 17, 0, 50, 2, 955, DateTimeKind.Local).AddTicks(4356), "Blanditiis maiores incidunt reprehenderit laudantium provident maiores sed ipsa unde. Ipsa sint rerum. Doloremque vel officiis minima sint debitis minima. Non dolores sequi esse soluta ut ex corrupti." },
                    { 512, 37, 62, 970430, new DateTime(2021, 4, 21, 21, 25, 18, 753, DateTimeKind.Local).AddTicks(3374), "Ut aperiam voluptas ipsum magni.\nDebitis expedita beatae sit eum neque aut provident.\nVoluptates debitis animi nam nesciunt ut rerum nihil molestias.\nFuga nisi adipisci est ut quidem aut est." },
                    { 582, 37, 15, 87969, new DateTime(2021, 5, 2, 0, 51, 19, 603, DateTimeKind.Local).AddTicks(9375), "Mollitia eum et recusandae.\nReiciendis modi quia distinctio minus quo ad enim.\nA reprehenderit qui repellendus ipsum eum et.\nLaudantium placeat labore.\nMolestias unde autem consequatur quibusdam nostrum laboriosam officiis." },
                    { 186, 33, 119, 210019, new DateTime(2021, 8, 19, 11, 22, 55, 865, DateTimeKind.Local).AddTicks(6939), "Rerum veritatis qui. Adipisci amet tempore ipsam libero est voluptas ipsum ut quod. Iure vitae ex ea sit. Cumque et reprehenderit possimus voluptatem assumenda explicabo ipsam nobis." },
                    { 370, 33, 132, 728440, new DateTime(2021, 6, 16, 21, 27, 52, 985, DateTimeKind.Local).AddTicks(4136), "Aperiam necessitatibus sint rem.\nAutem quia neque voluptas consequuntur libero quam quisquam.\nSuscipit cum dolores quia occaecati corporis.\nRerum blanditiis est inventore eveniet non.\nMinima modi quasi quia temporibus quibusdam." },
                    { 460, 33, 25, 977579, new DateTime(2021, 7, 13, 20, 49, 42, 763, DateTimeKind.Local).AddTicks(8945), "Ipsum et qui. In commodi nesciunt quam sed voluptas dignissimos voluptas neque quis. Ad excepturi rem harum est est ad sunt ea." },
                    { 119, 37, 52, 982422, new DateTime(2020, 9, 14, 2, 0, 0, 222, DateTimeKind.Local).AddTicks(7940), "Doloribus corrupti dolorem consequatur temporibus et itaque commodi." },
                    { 248, 67, 117, 157587, new DateTime(2020, 10, 28, 21, 4, 10, 383, DateTimeKind.Local).AddTicks(2604), "distinctio" },
                    { 480, 67, 104, 934506, new DateTime(2021, 7, 25, 6, 34, 43, 117, DateTimeKind.Local).AddTicks(2169), "non" },
                    { 535, 67, 110, 831612, new DateTime(2020, 9, 4, 7, 19, 23, 155, DateTimeKind.Local).AddTicks(8172), "consectetur" },
                    { 13, 71, 76, 167073, new DateTime(2021, 3, 23, 5, 11, 22, 880, DateTimeKind.Local).AddTicks(681), "Quisquam voluptatem aut." },
                    { 381, 71, 104, 915199, new DateTime(2021, 6, 21, 16, 30, 37, 979, DateTimeKind.Local).AddTicks(6784), "Sit cumque ut." },
                    { 420, 71, 116, 805222, new DateTime(2021, 8, 6, 16, 36, 27, 535, DateTimeKind.Local).AddTicks(210), "quidem" },
                    { 586, 71, 26, 734380, new DateTime(2021, 8, 25, 1, 59, 14, 2, DateTimeKind.Local).AddTicks(1358), "Nihil est cum deserunt odio rerum quisquam." },
                    { 38, 14, 53, 822049, new DateTime(2021, 2, 25, 16, 32, 59, 75, DateTimeKind.Local).AddTicks(3121), "Ex vero quis. Perferendis qui eum nostrum. Ipsa aut molestiae mollitia dolores iure. Error enim ea totam id quo aliquam id suscipit. Omnis dolores eveniet assumenda et beatae enim a aut aspernatur. Repellat molestiae accusantium corporis natus aut quia cupiditate et." },
                    { 291, 14, 113, 846967, new DateTime(2021, 8, 1, 21, 53, 12, 293, DateTimeKind.Local).AddTicks(2526), "Nihil sequi tempore eum veritatis qui accusamus.\nUt qui itaque harum et quibusdam.\nPlaceat sit natus iste sed est sit alias.\nLaborum eum aliquam dolores.\nDicta corporis distinctio saepe." },
                    { 426, 67, 77, 267100, new DateTime(2020, 11, 6, 13, 34, 54, 464, DateTimeKind.Local).AddTicks(3339), "deserunt" },
                    { 346, 14, 26, 849182, new DateTime(2020, 11, 10, 10, 40, 9, 20, DateTimeKind.Local).AddTicks(387), "Qui enim unde optio qui et ad voluptatibus ipsum." },
                    { 549, 13, 15, 581977, new DateTime(2021, 7, 21, 15, 34, 30, 835, DateTimeKind.Local).AddTicks(4433), "Voluptatem amet minima sapiente non ratione reprehenderit voluptatem deleniti." },
                    { 497, 13, 9, 94630, new DateTime(2021, 5, 29, 22, 28, 29, 725, DateTimeKind.Local).AddTicks(2979), "Quibusdam ut aut ut autem rerum voluptatem deleniti fugit.\nMollitia esse et error aliquam minima exercitationem quis neque officiis.\nMinima sint sunt eveniet esse repellendus dolor non cum omnis.\nAccusamus voluptas incidunt consequuntur aut odit deserunt earum." },
                    { 105, 43, 94, 330734, new DateTime(2021, 6, 23, 22, 12, 3, 905, DateTimeKind.Local).AddTicks(5635), "Debitis provident quae aut." },
                    { 314, 43, 117, 76288, new DateTime(2021, 8, 20, 9, 52, 37, 11, DateTimeKind.Local).AddTicks(8774), "Aperiam repudiandae dignissimos facilis sed nihil quibusdam aut. Nemo eum aut a ut odit voluptates. Consectetur et inventore. Ducimus voluptas vel. Quidem accusamus ea sed nisi velit necessitatibus. Omnis natus ea vel quam qui." },
                    { 445, 43, 46, 874047, new DateTime(2021, 2, 5, 21, 50, 20, 876, DateTimeKind.Local).AddTicks(5494), "Explicabo molestiae magni quia." },
                    { 555, 43, 131, 349408, new DateTime(2021, 5, 8, 10, 18, 12, 249, DateTimeKind.Local).AddTicks(868), "Possimus corrupti velit harum nobis sunt porro assumenda mollitia maiores." },
                    { 65, 23, 15, 126096, new DateTime(2020, 9, 10, 19, 52, 5, 477, DateTimeKind.Local).AddTicks(9119), "Non assumenda ratione et quo quibusdam voluptatem in architecto. Architecto sit esse et quos eveniet accusantium iste quis nisi. Dolorum quo alias molestiae perferendis consequatur in a illum." },
                    { 238, 23, 4, 57922, new DateTime(2021, 6, 28, 14, 9, 23, 107, DateTimeKind.Local).AddTicks(4722), "Id adipisci consequatur." },
                    { 285, 23, 38, 482705, new DateTime(2021, 5, 10, 15, 45, 50, 947, DateTimeKind.Local).AddTicks(6215), "Recusandae aut nulla in eveniet suscipit error maiores. Omnis architecto officia eum reprehenderit. Reprehenderit ipsam quod voluptas eligendi est praesentium inventore et. Ut quis ut corrupti." },
                    { 287, 23, 42, 5798, new DateTime(2021, 6, 26, 22, 42, 7, 891, DateTimeKind.Local).AddTicks(7057), "Atque ipsa natus repellat voluptatum illo voluptatibus ut ea quae. Et aut minima qui. Delectus est mollitia voluptate et. Unde ducimus quis. Natus aut architecto tempora quod. Dolores iure repellat non est esse nemo." },
                    { 506, 13, 113, 592581, new DateTime(2020, 11, 26, 14, 41, 7, 623, DateTimeKind.Local).AddTicks(8757), "facilis" },
                    { 472, 23, 107, 225969, new DateTime(2021, 6, 27, 17, 56, 16, 927, DateTimeKind.Local).AddTicks(6705), "Aliquam debitis officiis laborum sunt est ipsum quia.\nUt ducimus et voluptates placeat id sapiente." },
                    { 541, 23, 51, 517871, new DateTime(2020, 11, 26, 4, 40, 20, 108, DateTimeKind.Local).AddTicks(8781), "est" },
                    { 576, 23, 29, 921362, new DateTime(2021, 2, 1, 12, 13, 53, 698, DateTimeKind.Local).AddTicks(9762), "quas" },
                    { 30, 13, 22, 617706, new DateTime(2021, 1, 1, 14, 12, 58, 59, DateTimeKind.Local).AddTicks(4845), "est" },
                    { 64, 13, 133, 673405, new DateTime(2020, 8, 29, 2, 51, 13, 583, DateTimeKind.Local).AddTicks(5349), "Quis voluptatem reiciendis eveniet itaque laborum." },
                    { 188, 13, 30, 303066, new DateTime(2021, 7, 13, 22, 7, 18, 328, DateTimeKind.Local).AddTicks(7187), "Iusto omnis amet odio delectus incidunt vel reprehenderit cumque.\nAut sed vel nobis in magnam officia neque aut fuga.\nNon accusantium eligendi est hic.\nEst commodi inventore dolorem." },
                    { 340, 13, 134, 893767, new DateTime(2021, 6, 20, 19, 24, 49, 343, DateTimeKind.Local).AddTicks(2316), "Expedita est sapiente tempore. Autem facere dignissimos molestias vitae laborum sed ut. Illum quibusdam libero iusto porro ut et animi et. Vero voluptas magni magnam pariatur sed ipsa et non rerum. Ipsam itaque libero excepturi aut." },
                    { 422, 13, 23, 44215, new DateTime(2021, 8, 2, 1, 8, 49, 652, DateTimeKind.Local).AddTicks(3869), "Nihil excepturi iste doloremque." },
                    { 440, 13, 60, 620669, new DateTime(2021, 3, 30, 21, 28, 3, 981, DateTimeKind.Local).AddTicks(438), "Mollitia sit nisi aut." },
                    { 540, 23, 28, 263344, new DateTime(2020, 10, 2, 11, 32, 16, 345, DateTimeKind.Local).AddTicks(3696), "Laborum debitis dolorem.\nAccusantium nisi eos enim voluptatem dolor.\nDeserunt quisquam dignissimos provident numquam.\nEligendi vitae ad repudiandae sed non ipsam.\nQui eum ut eum.\nCommodi sed amet doloribus." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 384, 14, 5, 583147, new DateTime(2021, 2, 11, 23, 19, 26, 776, DateTimeKind.Local).AddTicks(9133), "iste" },
                    { 514, 14, 59, 63935, new DateTime(2021, 3, 14, 5, 54, 36, 522, DateTimeKind.Local).AddTicks(7909), "Quo enim laudantium sit.\nIllum praesentium quas veniam nobis.\nAut vel porro odio blanditiis natus reprehenderit dolores dolores voluptatem." },
                    { 16, 54, 141, 831754, new DateTime(2021, 1, 17, 5, 27, 37, 583, DateTimeKind.Local).AddTicks(7651), "Dolor architecto quaerat voluptatem quidem eius corporis non et.\nFugiat et porro.\nOdio sed accusantium libero veritatis voluptatum autem." },
                    { 1, 12, 20, 499017, new DateTime(2021, 3, 5, 6, 13, 39, 870, DateTimeKind.Local).AddTicks(3258), "Quis totam quia. Cumque alias molestias. Ab tempore dolore tenetur autem quod. Molestiae eligendi ut dolores. Quas et eos amet. Expedita magni consequatur voluptates minus officia voluptas cumque facilis." },
                    { 211, 12, 125, 72395, new DateTime(2021, 5, 22, 4, 39, 4, 533, DateTimeKind.Local).AddTicks(2131), "Sit adipisci et perspiciatis facere consequatur.\nEst odio sit est consequatur qui et nobis et magni.\nDebitis quidem beatae quo animi voluptate dolor id.\nNatus quos expedita quos quis sit occaecati temporibus et aut.\nEt veniam excepturi repellendus." },
                    { 224, 12, 69, 4475, new DateTime(2021, 5, 31, 5, 43, 41, 507, DateTimeKind.Local).AddTicks(5588), "ad" },
                    { 324, 12, 89, 259424, new DateTime(2021, 3, 18, 21, 28, 6, 504, DateTimeKind.Local).AddTicks(8046), "rem" },
                    { 432, 12, 99, 346314, new DateTime(2021, 8, 3, 2, 35, 39, 794, DateTimeKind.Local).AddTicks(2755), "Et quia itaque molestiae ut. Voluptates ut impedit ut non esse. Suscipit quia rerum et est et provident explicabo similique dolores. Dicta ex consequuntur quasi sint ad nostrum. Non deleniti quos iure recusandae minus reiciendis ipsam omnis. Quisquam facilis reprehenderit qui adipisci sapiente voluptas." },
                    { 446, 12, 91, 911455, new DateTime(2020, 12, 25, 7, 24, 20, 685, DateTimeKind.Local).AddTicks(3860), "Eum hic nam sequi." },
                    { 568, 12, 26, 826890, new DateTime(2021, 6, 20, 20, 21, 16, 495, DateTimeKind.Local).AddTicks(6302), "Ut numquam quos autem ipsa unde nihil sit." },
                    { 585, 12, 127, 620144, new DateTime(2021, 7, 9, 19, 42, 2, 152, DateTimeKind.Local).AddTicks(5104), "Tempore fugiat expedita itaque unde itaque.\nModi accusamus maiores quae dolor iste." },
                    { 557, 68, 49, 595811, new DateTime(2021, 2, 12, 22, 7, 3, 872, DateTimeKind.Local).AddTicks(8285), "Fugiat et id qui repudiandae et magni." },
                    { 62, 20, 115, 979190, new DateTime(2020, 11, 3, 4, 7, 39, 246, DateTimeKind.Local).AddTicks(3204), "Et qui in vel qui. Corporis alias nam et ea et fugit quam labore. Tenetur inventore est minima sed neque quae itaque." },
                    { 168, 20, 108, 772615, new DateTime(2021, 2, 27, 12, 6, 31, 831, DateTimeKind.Local).AddTicks(4379), "Vel voluptas id.\nEt rerum amet eaque minima illo nihil fugiat." },
                    { 204, 20, 127, 78810, new DateTime(2021, 4, 30, 22, 36, 47, 254, DateTimeKind.Local).AddTicks(9356), "Minima adipisci dolorem est quia recusandae ut.\nA id qui qui consequatur quam id.\nCorporis consequatur architecto omnis voluptatum.\nQui ipsa quos ea et molestiae a.\nFugiat doloribus recusandae odit dolor a quia facere." },
                    { 288, 20, 36, 166707, new DateTime(2020, 10, 1, 12, 19, 59, 63, DateTimeKind.Local).AddTicks(4300), "accusantium" },
                    { 305, 20, 84, 26362, new DateTime(2021, 6, 19, 9, 50, 49, 930, DateTimeKind.Local).AddTicks(1762), "Dolorem assumenda nisi ea sequi quisquam numquam ea. Facilis enim id minus qui est iure. Pariatur aliquid ut dolor voluptate voluptate. Ut incidunt esse." },
                    { 323, 20, 104, 650118, new DateTime(2021, 2, 11, 9, 42, 50, 442, DateTimeKind.Local).AddTicks(6123), "laudantium" },
                    { 354, 20, 23, 829950, new DateTime(2020, 11, 26, 23, 28, 4, 290, DateTimeKind.Local).AddTicks(846), "Ut saepe quae aspernatur.\nTotam iusto consequatur non iure qui suscipit.\nEx rerum voluptas soluta.\nAut eum voluptate.\nOptio in voluptas error culpa at aut quia sunt." },
                    { 593, 20, 75, 957953, new DateTime(2021, 3, 23, 20, 40, 57, 513, DateTimeKind.Local).AddTicks(3725), "nihil" },
                    { 161, 30, 115, 504365, new DateTime(2020, 9, 2, 20, 7, 30, 108, DateTimeKind.Local).AddTicks(1155), "Vel voluptas possimus quia quis cum magni. Dolores ipsum illum dolorum ut voluptas voluptatem ut. Quia voluptatibus deleniti. Dolor consequatur doloribus vitae est iure laudantium incidunt ab." },
                    { 76, 20, 41, 303134, new DateTime(2021, 5, 26, 8, 42, 0, 656, DateTimeKind.Local).AddTicks(1197), "est" },
                    { 493, 68, 46, 156232, new DateTime(2020, 11, 15, 9, 6, 12, 749, DateTimeKind.Local).AddTicks(6820), "Sed ullam facere nulla hic veritatis ab aut amet et." },
                    { 478, 68, 25, 267923, new DateTime(2021, 7, 11, 3, 36, 2, 84, DateTimeKind.Local).AddTicks(5325), "sunt" },
                    { 458, 68, 148, 221383, new DateTime(2021, 8, 13, 13, 54, 59, 134, DateTimeKind.Local).AddTicks(6886), "Eos vel iusto cumque molestiae commodi magni quaerat. Omnis consequatur nemo. Odit ad modi minima provident molestiae est earum dolorum. Eos et nisi aut. Nisi qui commodi amet autem quia quo. Maiores incidunt ea molestiae a." },
                    { 183, 54, 3, 915674, new DateTime(2020, 8, 31, 16, 44, 1, 151, DateTimeKind.Local).AddTicks(4227), "In molestiae quis laboriosam porro quos aut voluptas ut.\nQuia voluptas quasi ipsa assumenda recusandae voluptatum hic eum porro.\nEt laborum quae animi molestiae aut." },
                    { 185, 54, 86, 113566, new DateTime(2021, 7, 1, 2, 15, 17, 529, DateTimeKind.Local).AddTicks(6119), "Nostrum mollitia velit est dolorem id.\nTempore eaque quia non.\nQuis voluptatum unde dolorum fugit et itaque." },
                    { 306, 54, 84, 748114, new DateTime(2020, 11, 4, 12, 8, 32, 100, DateTimeKind.Local).AddTicks(9824), "deserunt" },
                    { 40, 65, 52, 424384, new DateTime(2020, 12, 12, 12, 23, 30, 721, DateTimeKind.Local).AddTicks(4015), "Nam dolor doloremque nesciunt quidem occaecati.\nVoluptatibus error ut autem dolorem.\nDolorem magni non." },
                    { 205, 65, 91, 97204, new DateTime(2021, 8, 20, 1, 14, 36, 991, DateTimeKind.Local).AddTicks(4811), "Eveniet sit ab voluptates explicabo qui voluptatem saepe est." },
                    { 249, 65, 29, 303469, new DateTime(2021, 1, 18, 13, 6, 4, 373, DateTimeKind.Local).AddTicks(5474), "Officia optio ipsum.\nEligendi non quod nesciunt dicta quia eaque ad.\nEaque qui occaecati exercitationem ea corrupti.\nQuisquam magni in ea voluptas id sit amet." },
                    { 547, 65, 133, 324964, new DateTime(2021, 6, 16, 14, 58, 31, 75, DateTimeKind.Local).AddTicks(6452), "similique" },
                    { 556, 65, 15, 872216, new DateTime(2020, 11, 5, 7, 57, 15, 378, DateTimeKind.Local).AddTicks(8080), "Voluptatem eligendi nemo exercitationem ut et tempore consequatur blanditiis et.\nVitae temporibus fugit qui dolore.\nVoluptatem eos architecto tempora.\nDolor et dolorem et voluptatem sint ipsa neque.\nNobis porro ut molestiae quod beatae.\nTemporibus accusamus id ut incidunt quasi qui nobis." },
                    { 4, 25, 131, 327649, new DateTime(2021, 2, 24, 14, 25, 44, 203, DateTimeKind.Local).AddTicks(1665), "totam" },
                    { 10, 25, 120, 841281, new DateTime(2021, 6, 4, 11, 1, 46, 716, DateTimeKind.Local).AddTicks(826), "odit" },
                    { 43, 25, 48, 644244, new DateTime(2021, 8, 3, 16, 12, 19, 804, DateTimeKind.Local).AddTicks(1931), "Atque amet porro labore natus molestiae quos ipsum temporibus officiis. Laborum eos omnis doloremque repudiandae. Dolor sunt voluptatibus ipsam quia laudantium repellat dolorem facere ut." },
                    { 207, 25, 67, 791258, new DateTime(2021, 4, 7, 10, 22, 31, 418, DateTimeKind.Local).AddTicks(9324), "Id numquam aut ut beatae doloribus ullam." },
                    { 235, 25, 115, 456304, new DateTime(2020, 12, 27, 4, 53, 34, 328, DateTimeKind.Local).AddTicks(9826), "Qui tempore sed. Iste quae harum error unde enim sunt. Officiis enim nobis inventore totam in. Culpa fugit iure nemo numquam temporibus. Iure rerum fugit eius molestiae ea voluptate nam alias." },
                    { 515, 25, 68, 423393, new DateTime(2021, 1, 14, 9, 47, 25, 948, DateTimeKind.Local).AddTicks(2641), "Est fuga ut suscipit explicabo." },
                    { 533, 25, 119, 74190, new DateTime(2021, 4, 10, 2, 42, 26, 378, DateTimeKind.Local).AddTicks(8481), "Et quisquam et aut laudantium soluta suscipit dolores ea.\nProvident corrupti praesentium optio maxime quo quas molestiae voluptates." },
                    { 166, 68, 22, 373190, new DateTime(2021, 4, 28, 2, 29, 4, 488, DateTimeKind.Local).AddTicks(4288), "Beatae veniam in illum et.\nMolestiae occaecati consequatur dolore.\nMolestiae vel ut labore eligendi.\nFacere exercitationem ut qui.\nDucimus cupiditate rem ex et enim sunt quia et.\nPossimus eum ad quaerat rerum nulla distinctio." },
                    { 196, 68, 47, 926097, new DateTime(2021, 8, 22, 22, 10, 17, 785, DateTimeKind.Local).AddTicks(9123), "Id et consectetur nemo aliquam nesciunt ut cupiditate." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 302, 68, 70, 688555, new DateTime(2021, 3, 11, 7, 1, 8, 6, DateTimeKind.Local).AddTicks(8365), "Tempore quia officia est voluptas accusantium soluta sit aut nesciunt. Totam quam recusandae non. Tempore et ipsam et. Qui dignissimos odit quod et aspernatur. Sed corporis sed veniam." },
                    { 428, 68, 149, 307460, new DateTime(2020, 12, 12, 8, 25, 56, 702, DateTimeKind.Local).AddTicks(158), "Non ea perferendis dolores perspiciatis aut." },
                    { 513, 10, 129, 270, new DateTime(2021, 7, 22, 2, 13, 14, 231, DateTimeKind.Local).AddTicks(6911), "Non explicabo quod dolore aliquid qui." },
                    { 486, 10, 80, 973012, new DateTime(2021, 7, 25, 18, 45, 31, 825, DateTimeKind.Local).AddTicks(2458), "ad" },
                    { 415, 10, 124, 484372, new DateTime(2021, 3, 30, 14, 57, 55, 675, DateTimeKind.Local).AddTicks(7745), "delectus" },
                    { 400, 10, 4, 883106, new DateTime(2020, 8, 31, 22, 32, 42, 232, DateTimeKind.Local).AddTicks(3619), "aliquam" },
                    { 321, 6, 35, 24247, new DateTime(2021, 5, 6, 10, 27, 23, 869, DateTimeKind.Local).AddTicks(1387), "Asperiores autem delectus. Rerum tempore commodi ea aut cum rerum assumenda necessitatibus consequatur. Dolorum eos quasi at explicabo harum minus. Autem in molestias illo. Dolores assumenda sint vel perspiciatis consequuntur suscipit asperiores." },
                    { 371, 6, 82, 104436, new DateTime(2020, 10, 9, 13, 17, 10, 6, DateTimeKind.Local).AddTicks(7303), "Autem et et quia mollitia iure.\nQuia dolorem quia atque veritatis laudantium libero.\nEt eum esse et eos quisquam." },
                    { 405, 6, 98, 222917, new DateTime(2021, 5, 20, 12, 15, 37, 726, DateTimeKind.Local).AddTicks(6696), "Sed quia ut laudantium voluptate repellendus ratione et. Animi expedita dolores itaque et autem odio sed id. Dolorem eligendi et quibusdam iure rerum sed. Mollitia voluptatibus nostrum." },
                    { 44, 26, 93, 210233, new DateTime(2021, 2, 22, 13, 54, 11, 907, DateTimeKind.Local).AddTicks(8499), "quae" },
                    { 95, 26, 38, 628833, new DateTime(2021, 3, 6, 18, 19, 39, 772, DateTimeKind.Local).AddTicks(390), "Quae aut corporis ea." },
                    { 181, 26, 115, 380428, new DateTime(2021, 3, 16, 3, 9, 46, 20, DateTimeKind.Local).AddTicks(2713), "Cumque sequi cum atque ullam aspernatur quae ipsam assumenda. Minus veritatis vitae nihil et dolorem reprehenderit libero dolore rerum. Numquam accusantium nihil aut." },
                    { 231, 26, 47, 276942, new DateTime(2021, 4, 9, 9, 48, 39, 95, DateTimeKind.Local).AddTicks(2353), "Commodi deserunt nulla ex id. Libero rerum quidem ut eaque iure eaque rerum sit veritatis. Esse provident est. Assumenda facilis rerum velit nostrum similique. Impedit et ex qui ea ea." },
                    { 276, 26, 134, 373530, new DateTime(2021, 6, 27, 22, 54, 45, 86, DateTimeKind.Local).AddTicks(6808), "Quisquam fugiat velit aut laborum molestiae nulla maiores a sint.\nNemo non repellendus provident ipsam unde quia illo dolorem sit.\nNeque est aut." },
                    { 223, 6, 103, 950048, new DateTime(2020, 9, 24, 13, 16, 20, 582, DateTimeKind.Local).AddTicks(6631), "Et consequuntur tempore qui est." },
                    { 441, 26, 53, 107822, new DateTime(2021, 6, 17, 1, 51, 9, 141, DateTimeKind.Local).AddTicks(6307), "Quisquam blanditiis et pariatur corrupti repudiandae odio." },
                    { 553, 26, 49, 612452, new DateTime(2021, 3, 19, 15, 21, 23, 204, DateTimeKind.Local).AddTicks(8879), "Odio magni vel sed consequuntur fuga et sed dolores nostrum.\nFugiat praesentium autem dolore voluptatem possimus.\nAutem rerum exercitationem perspiciatis autem minima.\nNihil hic ab vel deleniti.\nTempora possimus aut nemo iure repellendus voluptate quam." },
                    { 24, 52, 145, 988612, new DateTime(2021, 3, 14, 20, 48, 12, 275, DateTimeKind.Local).AddTicks(8017), "Aut quis labore quo nulla." },
                    { 123, 52, 71, 982163, new DateTime(2020, 9, 10, 7, 44, 30, 482, DateTimeKind.Local).AddTicks(4367), "Ea qui illum architecto exercitationem delectus eum velit qui.\nPerferendis iure ut nobis corporis corrupti sunt consequatur.\nMinus qui et rerum et fuga dolores exercitationem praesentium quia.\nCum sunt at odio fugit illo." },
                    { 222, 52, 128, 750565, new DateTime(2020, 10, 10, 8, 21, 54, 40, DateTimeKind.Local).AddTicks(2874), "Deleniti molestiae velit quas. Excepturi quaerat aspernatur molestias exercitationem accusamus perspiciatis. Autem dolore natus qui neque aliquid. Voluptatem fugiat provident sit et. Saepe optio minus ipsum quo." },
                    { 254, 52, 30, 143147, new DateTime(2021, 1, 6, 0, 40, 58, 42, DateTimeKind.Local).AddTicks(9546), "Fugiat et id ducimus est voluptas exercitationem odit." },
                    { 382, 52, 2, 596373, new DateTime(2021, 5, 20, 2, 12, 47, 383, DateTimeKind.Local).AddTicks(5562), "Voluptates iure minus doloremque vero.\nPorro et voluptate temporibus excepturi consequatur accusamus aliquid praesentium.\nNon incidunt enim consequuntur deleniti temporibus incidunt quia quos.\nHarum est dolor voluptas aut." },
                    { 482, 52, 92, 93210, new DateTime(2021, 7, 27, 22, 15, 51, 964, DateTimeKind.Local).AddTicks(9339), "Accusantium molestiae iure explicabo corporis maxime asperiores et voluptatum molestiae.\nRepellendus dolore laborum aut nemo.\nEt praesentium aut pariatur.\nNeque iusto impedit architecto.\nUt minus consequatur debitis.\nNon hic quos qui et qui id." },
                    { 542, 52, 135, 914567, new DateTime(2021, 1, 29, 3, 21, 47, 973, DateTimeKind.Local).AddTicks(100), "Possimus modi officia ea temporibus. Id sunt velit hic at enim et. Deserunt non et esse est voluptate qui ut ut sapiente. Omnis voluptatum occaecati qui hic. Qui rem eos fuga ipsa autem accusamus." },
                    { 529, 26, 51, 371017, new DateTime(2021, 3, 22, 11, 15, 15, 836, DateTimeKind.Local).AddTicks(3874), "Est quo dolores mollitia architecto provident nesciunt ducimus quae quam.\nAut eos explicabo dolorem illum ipsa non veniam cupiditate quia.\nQuia recusandae laborum quia porro quia.\nEst et optio quibusdam perspiciatis dicta.\nSit sit voluptatem eligendi consequuntur consequatur aut qui dolor velit." },
                    { 167, 6, 107, 895259, new DateTime(2020, 9, 11, 17, 4, 32, 595, DateTimeKind.Local).AddTicks(3578), "Aut quod sed dolorem fuga minus. Porro unde modi quo ab. Rerum aut et hic aut. Minus ipsum maiores eligendi reiciendis consequatur in sunt." },
                    { 145, 6, 97, 287776, new DateTime(2021, 8, 15, 19, 4, 38, 140, DateTimeKind.Local).AddTicks(6236), "Laudantium itaque officiis nostrum aspernatur et qui.\nDeleniti amet et quis excepturi numquam odit modi." },
                    { 579, 42, 9, 921227, new DateTime(2021, 7, 30, 3, 21, 8, 161, DateTimeKind.Local).AddTicks(3294), "illo" },
                    { 85, 18, 45, 80179, new DateTime(2020, 11, 24, 6, 9, 41, 401, DateTimeKind.Local).AddTicks(3736), "Accusantium non odio possimus dolor. Provident et voluptate eveniet ea dicta. Et neque quisquam voluptates ea tempora animi omnis. Quis sit fuga animi quisquam." },
                    { 120, 18, 47, 623366, new DateTime(2021, 6, 1, 1, 0, 53, 439, DateTimeKind.Local).AddTicks(3989), "Ut numquam optio nesciunt sed quas ut et debitis. Suscipit fugit sed modi dolores voluptates. Vel id molestiae." },
                    { 156, 18, 143, 128923, new DateTime(2021, 2, 16, 23, 10, 5, 313, DateTimeKind.Local).AddTicks(7966), "Rerum vitae autem distinctio iure." },
                    { 258, 18, 32, 674728, new DateTime(2021, 1, 12, 19, 2, 50, 660, DateTimeKind.Local).AddTicks(2104), "alias" },
                    { 309, 18, 142, 563936, new DateTime(2020, 10, 3, 20, 1, 31, 191, DateTimeKind.Local).AddTicks(5040), "Ullam qui unde amet corporis.\nTempore iusto harum ipsa voluptates sit ut quis natus.\nPerspiciatis necessitatibus optio et voluptatem.\nCupiditate voluptas reprehenderit quo commodi qui excepturi." },
                    { 311, 18, 89, 213543, new DateTime(2020, 11, 13, 0, 38, 39, 819, DateTimeKind.Local).AddTicks(3278), "Id ut perferendis molestias vel sed ipsum nostrum.\nAspernatur consequatur eos ad omnis sed dolor quibusdam totam rem.\nMolestiae minus deleniti impedit iure quia ipsam sequi earum.\nDolorem nesciunt reiciendis autem non iste.\nAut voluptatem eum est modi itaque totam consectetur vitae." },
                    { 316, 18, 141, 921904, new DateTime(2020, 8, 29, 12, 31, 36, 470, DateTimeKind.Local).AddTicks(2329), "Qui nam tenetur consequuntur corrupti culpa eos aut occaecati officia.\nFacilis laborum ut reiciendis aliquam placeat eum.\nAmet nobis consequatur.\nOptio omnis ea et modi est et.\nDicta laborum temporibus." },
                    { 398, 18, 7, 500598, new DateTime(2020, 12, 18, 9, 44, 18, 765, DateTimeKind.Local).AddTicks(963), "Qui soluta corrupti qui quia.\nRepudiandae illo atque qui quo consequatur.\nQui ut recusandae eos quasi praesentium a.\nEt voluptas quasi earum." },
                    { 419, 18, 115, 381353, new DateTime(2021, 1, 24, 8, 52, 8, 121, DateTimeKind.Local).AddTicks(9516), "laudantium" },
                    { 524, 18, 63, 38988, new DateTime(2020, 11, 11, 16, 57, 7, 758, DateTimeKind.Local).AddTicks(5021), "Ut sunt qui consequatur sed. Ullam sint earum. Possimus nostrum nam et sed omnis id consequatur libero ducimus." },
                    { 530, 18, 111, 150193, new DateTime(2021, 1, 22, 22, 1, 48, 930, DateTimeKind.Local).AddTicks(7120), "Vitae eligendi nostrum sint sed voluptatibus. Illum hic sit qui et veniam quia voluptatem consequatur et. Impedit necessitatibus officia qui in sit." },
                    { 33, 42, 125, 819737, new DateTime(2020, 12, 5, 0, 51, 20, 141, DateTimeKind.Local).AddTicks(9675), "Rem labore maiores fugit qui omnis. Non eveniet quo. Consequatur adipisci repudiandae et. Ex incidunt dolores facere id eos corrupti a ut id. Autem quo optio et autem. Iste eum est numquam omnis officia." },
                    { 103, 42, 62, 935873, new DateTime(2021, 4, 18, 13, 24, 31, 425, DateTimeKind.Local).AddTicks(6899), "Laborum quia architecto inventore perspiciatis veniam. Et odio aliquid voluptatibus fugit voluptatem tenetur officia fugiat dolor. Provident corporis eligendi tempore neque impedit illo. Voluptatem distinctio porro et mollitia dolor soluta. Et et minima quam voluptate id ex voluptatem voluptas provident. Qui dicta quo qui." },
                    { 180, 42, 106, 215112, new DateTime(2021, 6, 18, 13, 6, 31, 965, DateTimeKind.Local).AddTicks(3390), "Consequatur et quasi quis rerum corporis qui asperiores dolorem. Natus rerum corporis et iste dolor atque voluptatibus ipsa harum. Maxime sed commodi. Quisquam voluptates sint. Minima vel ut laborum mollitia voluptas aut et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 246, 42, 50, 21405, new DateTime(2021, 5, 14, 23, 24, 17, 870, DateTimeKind.Local).AddTicks(8857), "perspiciatis" },
                    { 345, 42, 14, 245178, new DateTime(2020, 12, 14, 15, 56, 4, 986, DateTimeKind.Local).AddTicks(2974), "Ut laborum dolorum et occaecati repudiandae esse odit aut eaque. Quia repellendus rerum minus et aperiam nulla et sunt veniam. Quis ut facilis aliquid sed error tenetur. Aut deleniti aliquid repellendus id iste rerum unde deserunt. Est nihil voluptatibus sunt iusto." },
                    { 396, 42, 113, 142147, new DateTime(2021, 4, 18, 20, 33, 1, 170, DateTimeKind.Local).AddTicks(534), "Commodi repudiandae possimus sunt eaque odit incidunt rerum quia deleniti.\nImpedit harum qui ut doloremque omnis.\nFugit repudiandae maiores error sunt quia consequatur eveniet eligendi.\nDicta ut autem eligendi esse et voluptatem.\nHarum veritatis nihil incidunt iste.\nDolores pariatur enim sit atque in." },
                    { 488, 42, 96, 496307, new DateTime(2021, 3, 16, 22, 7, 37, 956, DateTimeKind.Local).AddTicks(5458), "Sit vel qui corrupti quia est fugiat ut.\nVeritatis itaque ratione nihil in natus occaecati non minima qui.\nDolorem non eius.\nTemporibus beatae voluptas non molestiae aut earum rerum reprehenderit in." },
                    { 526, 42, 87, 811917, new DateTime(2021, 2, 23, 0, 16, 47, 994, DateTimeKind.Local).AddTicks(217), "Nemo et error quis delectus id." },
                    { 128, 53, 106, 829030, new DateTime(2021, 7, 12, 10, 0, 38, 412, DateTimeKind.Local).AddTicks(2441), "ea" },
                    { 177, 30, 74, 133843, new DateTime(2020, 11, 13, 12, 17, 35, 130, DateTimeKind.Local).AddTicks(2125), "Fuga ut ex laborum et nihil ab. Aliquid corporis quos dolor fuga eos odio id similique est. Laboriosam et voluptas quis sapiente voluptatibus deserunt est." },
                    { 266, 53, 2, 72190, new DateTime(2021, 5, 29, 7, 20, 41, 999, DateTimeKind.Local).AddTicks(4572), "rerum" },
                    { 379, 53, 72, 427367, new DateTime(2020, 11, 15, 7, 55, 13, 951, DateTimeKind.Local).AddTicks(6473), "non" },
                    { 127, 11, 76, 194099, new DateTime(2021, 5, 13, 11, 10, 18, 2, DateTimeKind.Local).AddTicks(5250), "Vero facilis sed dolor et." },
                    { 294, 11, 29, 292155, new DateTime(2020, 12, 29, 11, 50, 14, 48, DateTimeKind.Local).AddTicks(3624), "necessitatibus" },
                    { 310, 11, 108, 376950, new DateTime(2021, 4, 2, 13, 15, 56, 371, DateTimeKind.Local).AddTicks(2896), "aut" },
                    { 108, 61, 43, 323434, new DateTime(2021, 6, 6, 9, 44, 10, 579, DateTimeKind.Local).AddTicks(711), "Quo distinctio voluptatem illum. Nihil iste minus quia. Eaque qui ut omnis fugiat quod quo et et. Officia qui et aut dolorum. Et impedit facere quos autem voluptas quia qui nostrum. Ut libero mollitia ut." },
                    { 192, 61, 110, 701599, new DateTime(2020, 12, 24, 7, 25, 16, 465, DateTimeKind.Local).AddTicks(6119), "Consequatur et nam non ut hic sunt." },
                    { 201, 61, 9, 734176, new DateTime(2020, 12, 26, 14, 35, 11, 528, DateTimeKind.Local).AddTicks(8837), "Aliquam laudantium ab deleniti.\nCorporis nihil quaerat vitae enim et necessitatibus hic non.\nQui in dolorum a ad sed." },
                    { 225, 61, 90, 39416, new DateTime(2020, 11, 29, 11, 57, 48, 789, DateTimeKind.Local).AddTicks(2140), "Facilis qui et animi.\nDolorum error commodi laboriosam.\nMaiores autem repudiandae itaque officiis enim." },
                    { 358, 61, 73, 450155, new DateTime(2021, 7, 23, 2, 1, 29, 727, DateTimeKind.Local).AddTicks(58), "Perferendis dicta dolor fugiat odio tenetur." },
                    { 102, 11, 3, 193671, new DateTime(2020, 9, 3, 3, 5, 6, 666, DateTimeKind.Local).AddTicks(8050), "temporibus" },
                    { 447, 61, 96, 575405, new DateTime(2020, 12, 16, 19, 37, 9, 217, DateTimeKind.Local).AddTicks(3196), "Deserunt quam in et rerum omnis ab corrupti odit sit." },
                    { 462, 61, 125, 402710, new DateTime(2021, 2, 22, 14, 22, 39, 837, DateTimeKind.Local).AddTicks(8911), "Minus enim reiciendis nostrum ab saepe suscipit.\nUt voluptate non voluptas.\nSit et eveniet ipsa aut quam voluptatem qui." },
                    { 23, 22, 16, 390031, new DateTime(2021, 1, 17, 18, 58, 39, 889, DateTimeKind.Local).AddTicks(8722), "Minima asperiores eveniet molestias animi et maxime rem. Non sit quia deleniti possimus. Temporibus dolor eum. Qui nemo iusto. Nobis omnis ex incidunt magni. Expedita rerum quis delectus enim porro error sint molestias." },
                    { 150, 22, 87, 410177, new DateTime(2020, 12, 17, 17, 41, 17, 347, DateTimeKind.Local).AddTicks(7537), "In porro est quae tempora facere rem voluptatem architecto facere.\nQuidem quia molestiae neque.\nAliquam ea est quibusdam est aliquam." },
                    { 243, 22, 5, 770336, new DateTime(2021, 3, 18, 10, 56, 15, 757, DateTimeKind.Local).AddTicks(3774), "Enim dolorem at quis." },
                    { 295, 22, 77, 984241, new DateTime(2021, 6, 19, 16, 27, 52, 134, DateTimeKind.Local).AddTicks(862), "Nobis expedita quia facilis." },
                    { 395, 22, 90, 170982, new DateTime(2021, 4, 29, 17, 19, 7, 487, DateTimeKind.Local).AddTicks(6188), "eius" },
                    { 455, 22, 59, 984228, new DateTime(2021, 8, 4, 16, 34, 23, 633, DateTimeKind.Local).AddTicks(112), "vel" },
                    { 550, 22, 28, 517945, new DateTime(2021, 8, 26, 21, 6, 31, 147, DateTimeKind.Local).AddTicks(1645), "voluptatem" },
                    { 450, 61, 16, 438349, new DateTime(2021, 8, 3, 5, 10, 53, 257, DateTimeKind.Local).AddTicks(6892), "Dolores odit voluptatum quas." },
                    { 577, 78, 22, 808248, new DateTime(2020, 12, 29, 23, 10, 36, 958, DateTimeKind.Local).AddTicks(5518), "Rerum id possimus autem modi et sit iure totam.\nDucimus quia dolores voluptas at porro." },
                    { 421, 78, 84, 22029, new DateTime(2020, 11, 3, 9, 46, 52, 207, DateTimeKind.Local).AddTicks(9503), "Velit ipsa quia. Quia aut quis dignissimos quisquam illum officiis deserunt ipsam quia. Omnis est qui quisquam aliquid veniam quidem. Ab molestiae sint repellendus ut est. Vero sed qui consectetur at qui aut libero illo suscipit." },
                    { 417, 78, 64, 957805, new DateTime(2021, 8, 19, 12, 21, 25, 168, DateTimeKind.Local).AddTicks(3168), "soluta" },
                    { 443, 53, 39, 629071, new DateTime(2021, 4, 5, 0, 36, 43, 630, DateTimeKind.Local).AddTicks(6085), "iusto" },
                    { 518, 53, 35, 657181, new DateTime(2021, 7, 6, 13, 22, 15, 136, DateTimeKind.Local).AddTicks(3059), "Animi excepturi ut et ea atque aut qui.\nUnde maxime doloribus eius eius voluptas et." },
                    { 591, 53, 77, 757117, new DateTime(2021, 3, 10, 0, 45, 15, 25, DateTimeKind.Local).AddTicks(7998), "Autem rerum qui ratione nihil. Sunt porro occaecati expedita debitis temporibus sit necessitatibus maiores voluptate. Tenetur aut magnam dolorem aut rerum repellendus et iure et. Ad natus est impedit. Ut doloremque cupiditate. Libero nam in." },
                    { 32, 38, 55, 257342, new DateTime(2020, 11, 30, 0, 56, 14, 96, DateTimeKind.Local).AddTicks(4856), "Reiciendis beatae quibusdam animi laboriosam provident explicabo.\nRepellat minima in.\nVero sapiente velit debitis minus veniam sint doloribus id corrupti.\nDucimus eos doloremque." },
                    { 67, 38, 15, 321108, new DateTime(2020, 8, 31, 23, 29, 22, 235, DateTimeKind.Local).AddTicks(2459), "Adipisci consectetur labore esse laudantium ad." },
                    { 253, 38, 38, 384382, new DateTime(2021, 8, 27, 12, 40, 31, 882, DateTimeKind.Local).AddTicks(9717), "Odit culpa eum perferendis qui. Rerum dolor nemo enim voluptatem et omnis. Dolore porro voluptatem totam. Nostrum eveniet quam aliquam sed. Consequatur laudantium inventore qui recusandae aut accusamus minus corrupti consequatur. Sunt nostrum et dolore dolorem est qui omnis repudiandae." },
                    { 282, 38, 41, 518283, new DateTime(2021, 5, 22, 14, 28, 22, 981, DateTimeKind.Local).AddTicks(6321), "quae" },
                    { 393, 38, 125, 821037, new DateTime(2021, 4, 11, 10, 47, 51, 90, DateTimeKind.Local).AddTicks(667), "Non vero et similique similique reiciendis dolor sint ut et. Eveniet dolor et quisquam voluptas nihil sed. Dolor et qui sunt laboriosam sit voluptas. Et illo perferendis dolores sed quidem qui. Asperiores non sed quia esse non nemo ducimus cumque." },
                    { 430, 38, 108, 477925, new DateTime(2020, 10, 4, 6, 59, 3, 259, DateTimeKind.Local).AddTicks(1138), "Eum ut et dolore sed quia sit eum et. Sapiente blanditiis aut laudantium quod id. Illum repellendus quia delectus asperiores sunt alias consequuntur dolor." },
                    { 470, 38, 17, 297009, new DateTime(2020, 12, 28, 4, 25, 54, 216, DateTimeKind.Local).AddTicks(5429), "laudantium" },
                    { 485, 38, 38, 133679, new DateTime(2021, 8, 6, 16, 59, 23, 441, DateTimeKind.Local).AddTicks(7947), "Eaque similique et. Sed vel error reprehenderit nihil repudiandae quia doloribus cum. Iusto culpa distinctio cumque reprehenderit eos dignissimos voluptatem consectetur. Quia non et. Consequuntur quas at sit nulla aliquam totam debitis." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 589, 38, 47, 599421, new DateTime(2021, 8, 7, 16, 21, 57, 860, DateTimeKind.Local).AddTicks(5136), "corrupti" },
                    { 70, 78, 148, 548643, new DateTime(2020, 10, 1, 18, 4, 51, 106, DateTimeKind.Local).AddTicks(696), "Odit distinctio mollitia excepturi reprehenderit maiores eaque ut aut quos." },
                    { 130, 78, 8, 928499, new DateTime(2020, 9, 22, 23, 58, 12, 779, DateTimeKind.Local).AddTicks(4755), "est" },
                    { 165, 78, 73, 516434, new DateTime(2020, 11, 18, 2, 54, 46, 502, DateTimeKind.Local).AddTicks(8422), "Quae sunt doloribus aut consectetur quod velit ex perspiciatis. Nam ut excepturi ullam minima voluptatem. Harum ea temporibus impedit." },
                    { 184, 78, 28, 13473, new DateTime(2021, 6, 24, 5, 30, 4, 234, DateTimeKind.Local).AddTicks(4236), "Voluptatibus quam molestiae esse. Nihil aut ut fugit iusto accusamus qui illo molestiae. Distinctio quia est aliquam id. Nesciunt illum labore quod autem. Saepe molestiae quod sapiente quia sapiente. Inventore ut quas veritatis sed cum et rerum magni quia." },
                    { 332, 78, 17, 110338, new DateTime(2021, 2, 6, 10, 3, 25, 447, DateTimeKind.Local).AddTicks(5413), "corrupti" },
                    { 342, 78, 12, 774865, new DateTime(2021, 1, 12, 12, 26, 29, 913, DateTimeKind.Local).AddTicks(8671), "Nobis ullam quia vero voluptas tempore omnis perspiciatis enim. Nisi rerum in. Quia mollitia itaque culpa fuga qui sed accusantium." },
                    { 368, 78, 4, 544109, new DateTime(2020, 12, 16, 13, 53, 46, 585, DateTimeKind.Local).AddTicks(5096), "Explicabo beatae perspiciatis nihil expedita aperiam veniam quis consequatur.\nReiciendis tempore fuga tenetur omnis at." },
                    { 337, 53, 125, 414106, new DateTime(2020, 12, 12, 19, 58, 8, 69, DateTimeKind.Local).AddTicks(7583), "Non eos laborum omnis ut. Temporibus impedit laborum maxime facere ratione quia sit omnis. Quaerat temporibus similique ratione voluptas suscipit saepe natus voluptas aut. Consequatur aut impedit ab maxime voluptatum molestiae sed nemo." },
                    { 463, 85, 6, 583069, new DateTime(2021, 2, 9, 21, 25, 31, 450, DateTimeKind.Local).AddTicks(6896), "Rem earum facere molestiae nostrum sit repellat." },
                    { 200, 30, 133, 944957, new DateTime(2021, 8, 8, 8, 17, 34, 759, DateTimeKind.Local).AddTicks(5698), "aliquid" },
                    { 230, 30, 5, 623170, new DateTime(2021, 1, 13, 15, 48, 24, 837, DateTimeKind.Local).AddTicks(7961), "Accusantium nobis placeat accusamus magni tempore laborum.\nReiciendis soluta quia.\nSit inventore dignissimos dignissimos." },
                    { 575, 56, 132, 258170, new DateTime(2020, 10, 15, 7, 56, 58, 1, DateTimeKind.Local).AddTicks(7600), "et" },
                    { 17, 21, 22, 474279, new DateTime(2021, 6, 14, 14, 6, 49, 111, DateTimeKind.Local).AddTicks(4188), "saepe" },
                    { 172, 21, 10, 648061, new DateTime(2020, 12, 30, 1, 3, 27, 100, DateTimeKind.Local).AddTicks(5022), "Dignissimos aut laborum rerum omnis. Consequuntur veniam ea. Eaque quia quia." },
                    { 251, 21, 11, 864089, new DateTime(2021, 8, 13, 14, 31, 39, 264, DateTimeKind.Local).AddTicks(9101), "Et nemo tenetur at laudantium iure." },
                    { 284, 21, 34, 382613, new DateTime(2021, 1, 25, 0, 8, 40, 918, DateTimeKind.Local).AddTicks(2212), "Dolores explicabo quos aut nesciunt tempora. Ad ipsam et beatae. Ipsam repellat omnis ut tempora recusandae accusamus non nihil. Quas odit porro. Fugiat repudiandae sed omnis aut. Velit quaerat dolores facilis optio itaque." },
                    { 411, 21, 18, 269447, new DateTime(2020, 10, 15, 1, 43, 30, 291, DateTimeKind.Local).AddTicks(5830), "Necessitatibus ut deserunt veritatis aut dolor eos assumenda.\nPariatur aut quia.\nEnim sed illum perferendis optio et autem ut dolores labore." },
                    { 511, 21, 122, 587942, new DateTime(2020, 12, 28, 21, 58, 54, 133, DateTimeKind.Local).AddTicks(9587), "Consequatur ut voluptatem aut rerum." },
                    { 551, 21, 73, 214297, new DateTime(2021, 1, 21, 8, 20, 11, 639, DateTimeKind.Local).AddTicks(7551), "Sint dicta repudiandae quibusdam sapiente nobis quis. Necessitatibus ex et iste nemo fugiat porro deserunt quibusdam et. Animi debitis tempora. Doloribus eligendi voluptas. Dicta sunt illo. Fuga consequatur repellendus libero consectetur ab qui amet impedit dolor." },
                    { 507, 56, 34, 482977, new DateTime(2020, 12, 1, 2, 13, 31, 177, DateTimeKind.Local).AddTicks(7801), "Et in qui quia eius accusantium id." },
                    { 89, 27, 14, 686103, new DateTime(2020, 11, 24, 10, 12, 8, 59, DateTimeKind.Local).AddTicks(4361), "Enim deserunt sapiente voluptas.\nAd sit expedita et in totam sed minus.\nCum natus odio nisi.\nReprehenderit qui adipisci dignissimos vel dolore porro ipsam harum." },
                    { 157, 27, 23, 472278, new DateTime(2021, 1, 2, 20, 5, 26, 465, DateTimeKind.Local).AddTicks(2195), "voluptatum" },
                    { 361, 27, 15, 337002, new DateTime(2020, 12, 31, 4, 51, 44, 261, DateTimeKind.Local).AddTicks(4069), "Quasi veniam modi inventore praesentium. Et minus odit ex quis delectus et eum. Officiis dolor molestiae earum ut adipisci est ea et nihil." },
                    { 494, 27, 132, 876796, new DateTime(2020, 10, 18, 16, 33, 33, 952, DateTimeKind.Local).AddTicks(9967), "Ad dolore dolore aut enim. Voluptatibus et ea suscipit. Earum nulla similique rerum libero modi quibusdam accusamus quidem. Ut ut et sed dignissimos repellendus et ex sit." },
                    { 548, 27, 22, 92116, new DateTime(2021, 7, 26, 1, 6, 49, 353, DateTimeKind.Local).AddTicks(3571), "Qui debitis molestiae. Aut sit dolores explicabo sit fuga. Repellat iste voluptas. Molestias facere ex. Mollitia magni temporibus repudiandae et." },
                    { 588, 27, 18, 292541, new DateTime(2021, 3, 17, 14, 8, 7, 981, DateTimeKind.Local).AddTicks(5474), "Tempore autem et. Impedit consequatur numquam vel aut veritatis voluptas veniam voluptas. Quis et dolorum voluptates omnis quasi sed. Voluptatem aut veniam id quidem. Error necessitatibus impedit voluptatem asperiores aut quia." },
                    { 137, 59, 143, 467678, new DateTime(2021, 3, 27, 1, 15, 36, 623, DateTimeKind.Local).AddTicks(4280), "Sed incidunt et recusandae iste labore totam suscipit molestiae minus. Cupiditate in assumenda quia non omnis ut ipsam unde. Quo culpa reprehenderit sint debitis incidunt a ut quis. Nesciunt non qui totam ut. Ut alias vitae tempora architecto in autem et ut." },
                    { 140, 59, 126, 194606, new DateTime(2020, 9, 14, 15, 1, 57, 322, DateTimeKind.Local).AddTicks(7031), "Porro consequatur nulla." },
                    { 152, 59, 131, 30677, new DateTime(2021, 3, 18, 6, 38, 4, 331, DateTimeKind.Local).AddTicks(9966), "Facilis id laboriosam nemo." },
                    { 143, 27, 104, 53067, new DateTime(2020, 10, 10, 3, 34, 8, 229, DateTimeKind.Local).AddTicks(8582), "Et et commodi." },
                    { 182, 59, 101, 595709, new DateTime(2021, 8, 9, 5, 48, 22, 610, DateTimeKind.Local).AddTicks(5369), "Id libero distinctio saepe ipsa.\nEt est ut et culpa nihil.\nCumque voluptatem explicabo hic ab beatae ipsa excepturi aliquam.\nCorrupti consequuntur ut eum pariatur porro possimus unde.\nMaiores vel praesentium velit.\nAliquid quia delectus." },
                    { 250, 56, 125, 847482, new DateTime(2021, 4, 3, 3, 10, 22, 893, DateTimeKind.Local).AddTicks(9184), "Cumque mollitia doloribus voluptate harum velit sit.\nQuo dolorem eligendi.\nDolorum est quidem blanditiis quam numquam possimus.\nBlanditiis sed assumenda aut tenetur.\nIste omnis repellendus." },
                    { 203, 56, 105, 999562, new DateTime(2020, 12, 16, 18, 59, 32, 978, DateTimeKind.Local).AddTicks(7851), "Commodi atque repudiandae esse sit." },
                    { 473, 88, 94, 816196, new DateTime(2021, 3, 26, 9, 47, 47, 567, DateTimeKind.Local).AddTicks(8757), "Veniam dolor tenetur minima nostrum est et voluptatibus minus." },
                    { 519, 88, 61, 926047, new DateTime(2021, 3, 21, 21, 17, 32, 267, DateTimeKind.Local).AddTicks(8818), "Ad aut veritatis quo harum deleniti molestias ab nobis similique.\nEt fuga ipsum.\nExcepturi culpa sit sint quam." },
                    { 149, 89, 87, 640643, new DateTime(2020, 10, 30, 8, 3, 43, 922, DateTimeKind.Local).AddTicks(7626), "In molestiae aspernatur placeat doloremque.\nEveniet quam harum dolore quo mollitia dicta dolorum.\nOfficia dolorem beatae hic voluptatum dolorum.\nAlias recusandae ut omnis sit magnam.\nVoluptatem asperiores qui amet nulla ipsa totam." },
                    { 187, 89, 148, 577367, new DateTime(2021, 3, 28, 12, 30, 15, 516, DateTimeKind.Local).AddTicks(6294), "Sed consequuntur accusantium earum inventore aut dolorem vero rerum harum. Nulla est cupiditate eius. Beatae enim itaque et suscipit dolorem debitis." },
                    { 414, 89, 120, 530747, new DateTime(2021, 3, 7, 8, 19, 56, 704, DateTimeKind.Local).AddTicks(1314), "ipsum" },
                    { 500, 89, 67, 223693, new DateTime(2021, 3, 20, 0, 52, 1, 207, DateTimeKind.Local).AddTicks(4287), "Dolorem optio aut nisi voluptates autem.\nTemporibus illum est.\nAliquid doloribus eos quis consequatur consequatur velit natus voluptas qui.\nFacilis voluptatem quisquam quis.\nDolorum fugiat numquam qui ratione." },
                    { 49, 47, 54, 17342, new DateTime(2020, 11, 24, 3, 56, 29, 507, DateTimeKind.Local).AddTicks(9634), "ut" },
                    { 75, 47, 71, 887833, new DateTime(2020, 11, 9, 14, 5, 6, 339, DateTimeKind.Local).AddTicks(5875), "Cumque cum laudantium numquam.\nNon quo voluptatem.\nEst sed mollitia cum." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 213, 56, 73, 138888, new DateTime(2021, 6, 29, 17, 47, 41, 802, DateTimeKind.Local).AddTicks(2351), "Voluptatem sed autem sequi dolor.\nQuia maiores corporis facilis illo commodi necessitatibus.\nMollitia quia nostrum.\nNon ad laboriosam modi cum ut et.\nSed et necessitatibus consectetur id.\nIpsa debitis quas." },
                    { 159, 47, 5, 498243, new DateTime(2021, 6, 6, 16, 49, 38, 722, DateTimeKind.Local).AddTicks(787), "Quibusdam qui quam aperiam est dolorum nostrum." },
                    { 525, 47, 53, 37252, new DateTime(2021, 3, 8, 21, 36, 7, 203, DateTimeKind.Local).AddTicks(4900), "Enim eum officia unde quo." },
                    { 590, 47, 39, 289966, new DateTime(2021, 6, 24, 8, 6, 49, 63, DateTimeKind.Local).AddTicks(297), "Quidem omnis iste qui dolorem qui vel consequatur voluptatum eaque.\nOdit quia cumque vel numquam aliquid." },
                    { 14, 56, 99, 180721, new DateTime(2021, 7, 10, 3, 45, 17, 300, DateTimeKind.Local).AddTicks(746), "Sed occaecati voluptatem.\nIllo repudiandae hic ea occaecati.\nIure et quo in iure distinctio voluptatum iure voluptate.\nMagnam quia nostrum est.\nEius dolores debitis aut quaerat amet ipsum earum nemo qui.\nDolorem vero tempore dolorem quod." },
                    { 81, 56, 1, 915465, new DateTime(2021, 7, 1, 23, 50, 20, 914, DateTimeKind.Local).AddTicks(1796), "Expedita non odit sequi aut quaerat quos." },
                    { 124, 56, 134, 553116, new DateTime(2021, 5, 2, 6, 36, 48, 220, DateTimeKind.Local).AddTicks(9105), "amet" },
                    { 158, 56, 24, 806988, new DateTime(2020, 9, 13, 6, 35, 49, 88, DateTimeKind.Local).AddTicks(8630), "Eum aut minima repellendus ut id quod pariatur." },
                    { 164, 56, 24, 5361, new DateTime(2021, 7, 22, 2, 31, 55, 782, DateTimeKind.Local).AddTicks(7536), "Omnis rem vitae ut qui est. Tenetur ut laborum asperiores aliquid totam. Aut quia dolor voluptatem et et aut error." },
                    { 176, 56, 86, 12852, new DateTime(2020, 10, 12, 6, 35, 7, 333, DateTimeKind.Local).AddTicks(7224), "Et ratione dolor ab quia numquam quis enim natus aut.\nUt consequatur minima mollitia et quam aut." },
                    { 221, 47, 94, 565625, new DateTime(2021, 3, 2, 10, 50, 34, 878, DateTimeKind.Local).AddTicks(5768), "Molestiae incidunt nobis et." },
                    { 270, 59, 30, 655864, new DateTime(2021, 3, 26, 9, 2, 30, 790, DateTimeKind.Local).AddTicks(7206), "Voluptate quia illo illo consequatur sint.\nRecusandae eum id occaecati eos quam ipsum quod." },
                    { 394, 59, 109, 328416, new DateTime(2021, 5, 25, 16, 21, 32, 439, DateTimeKind.Local).AddTicks(2691), "Et quaerat sint aut eum quis culpa eum labore iure.\nLaudantium suscipit repellendus reprehenderit." },
                    { 410, 59, 69, 624073, new DateTime(2021, 3, 5, 1, 20, 21, 263, DateTimeKind.Local).AddTicks(7931), "Corrupti enim rem et omnis et ut.\nUt vitae at repellat et quam nam vero." },
                    { 50, 3, 40, 598978, new DateTime(2020, 10, 17, 19, 30, 4, 155, DateTimeKind.Local).AddTicks(1297), "Qui molestiae excepturi eos." },
                    { 237, 3, 31, 731007, new DateTime(2020, 10, 9, 13, 4, 52, 298, DateTimeKind.Local).AddTicks(2017), "Sapiente facere consequatur ut est aut distinctio maxime ducimus voluptas." },
                    { 360, 3, 119, 603225, new DateTime(2021, 6, 21, 14, 23, 38, 984, DateTimeKind.Local).AddTicks(9916), "voluptatem" },
                    { 387, 3, 7, 591002, new DateTime(2020, 10, 1, 23, 18, 41, 133, DateTimeKind.Local).AddTicks(7383), "Ut quis minus necessitatibus occaecati qui harum.\nEt perferendis qui cupiditate est ipsam quae ut pariatur itaque.\nAut maxime quibusdam modi beatae dolores molestiae recusandae.\nEos nihil veritatis et id tempora ut atque iste.\nUt dolorum quia repellendus rerum quasi.\nOdit consequatur nemo et." },
                    { 424, 3, 115, 635327, new DateTime(2021, 7, 29, 12, 25, 26, 557, DateTimeKind.Local).AddTicks(1265), "In et rerum ea.\nQuis omnis laborum.\nQuibusdam expedita ut nostrum asperiores ipsa et.\nQuibusdam voluptatem est in est reiciendis eveniet voluptas non dolorem.\nIpsa voluptates fuga ipsam beatae." },
                    { 474, 3, 15, 281278, new DateTime(2020, 12, 27, 16, 9, 33, 684, DateTimeKind.Local).AddTicks(3983), "Eum qui et ea est quis aut et culpa veritatis.\nSit quidem et aliquid iusto numquam totam deserunt explicabo expedita.\nQui atque aliquam qui ut accusantium aut non sed.\nSint consectetur voluptas." },
                    { 597, 3, 64, 257484, new DateTime(2021, 4, 18, 10, 44, 38, 472, DateTimeKind.Local).AddTicks(5115), "Nemo possimus et voluptatem ratione.\nConsequatur iusto quis dolore eos animi aut ab ex." },
                    { 6, 17, 103, 870806, new DateTime(2020, 11, 2, 12, 11, 36, 828, DateTimeKind.Local).AddTicks(6114), "Maxime quis eaque." },
                    { 571, 74, 114, 986364, new DateTime(2021, 5, 14, 17, 33, 5, 825, DateTimeKind.Local).AddTicks(7956), "Quo cupiditate vel et rem in pariatur et iste nisi." },
                    { 93, 17, 26, 599220, new DateTime(2021, 2, 28, 2, 21, 44, 31, DateTimeKind.Local).AddTicks(5041), "Nobis nesciunt sapiente enim placeat ea blanditiis et accusamus.\nMolestias consequatur ea dolore iste.\nQuae quos et assumenda ea.\nDolores debitis illo quasi facilis necessitatibus.\nNatus minus omnis deserunt aut debitis nemo.\nFugit natus in nihil ea." },
                    { 162, 17, 47, 445145, new DateTime(2021, 3, 21, 10, 22, 1, 317, DateTimeKind.Local).AddTicks(9749), "Deserunt aut a soluta omnis modi laboriosam eius earum.\nFugiat asperiores voluptatem ratione aliquam.\nRerum consequatur animi possimus voluptas et facilis nostrum libero." },
                    { 189, 17, 126, 352862, new DateTime(2020, 11, 8, 2, 13, 26, 490, DateTimeKind.Local).AddTicks(6779), "Veniam natus maiores quia est similique ipsa et." },
                    { 197, 17, 108, 616868, new DateTime(2021, 3, 2, 16, 10, 6, 415, DateTimeKind.Local).AddTicks(5683), "Non nobis ducimus veniam nemo asperiores voluptate. Mollitia est quam molestiae qui error magnam sunt fugit. Cupiditate voluptatem vero rerum repellat quis et. Nisi et voluptate qui molestiae rerum rerum occaecati quos doloribus." },
                    { 364, 17, 45, 663051, new DateTime(2021, 7, 3, 17, 6, 38, 757, DateTimeKind.Local).AddTicks(2963), "Doloribus iste dolore cumque et nisi qui. Non qui neque pariatur aut minus. Quia et illo reprehenderit rem voluptatibus voluptas nihil aliquid enim. Doloribus voluptatum praesentium vero explicabo. Ut iure est quas velit." },
                    { 416, 17, 2, 811650, new DateTime(2021, 1, 5, 14, 6, 57, 999, DateTimeKind.Local).AddTicks(625), "ducimus" },
                    { 439, 17, 140, 651365, new DateTime(2021, 2, 12, 12, 14, 28, 701, DateTimeKind.Local).AddTicks(3926), "Id nesciunt at officiis iusto placeat." },
                    { 484, 17, 91, 779542, new DateTime(2020, 9, 12, 15, 5, 45, 268, DateTimeKind.Local).AddTicks(1604), "Est et eligendi laudantium fugit iusto. Molestias dignissimos nobis hic tenetur. Expedita libero sint necessitatibus tempora non consequatur facere." },
                    { 554, 17, 65, 227859, new DateTime(2021, 1, 24, 3, 8, 0, 265, DateTimeKind.Local).AddTicks(6715), "Ipsa ea qui fuga quae enim incidunt repellat fuga saepe. Aut fugiat cumque tempore perferendis corporis sit quidem sequi. Ut atque eos. Aliquid sapiente recusandae doloremque consequatur. Reprehenderit facilis sit vel." },
                    { 110, 17, 24, 331644, new DateTime(2020, 11, 19, 19, 48, 5, 937, DateTimeKind.Local).AddTicks(5135), "voluptatem" },
                    { 528, 74, 65, 159733, new DateTime(2021, 7, 20, 5, 10, 2, 724, DateTimeKind.Local).AddTicks(8513), "Qui tempora quis aliquam ratione voluptatem omnis eum exercitationem laudantium." },
                    { 456, 74, 96, 326672, new DateTime(2021, 7, 18, 21, 36, 36, 498, DateTimeKind.Local).AddTicks(2419), "Quisquam esse qui porro nisi deserunt doloribus perferendis facilis perferendis. Fuga sed dolorem itaque. Et aperiam vel autem voluptatem quo voluptatum. Debitis assumenda praesentium error vitae eos est." },
                    { 402, 74, 135, 60030, new DateTime(2021, 6, 9, 23, 27, 28, 181, DateTimeKind.Local).AddTicks(442), "Amet quo tempore molestiae et. Aspernatur quibusdam porro quod. Quo voluptatem officiis voluptas ut sint tenetur." },
                    { 520, 59, 117, 114756, new DateTime(2021, 4, 22, 11, 40, 54, 598, DateTimeKind.Local).AddTicks(324), "Impedit consectetur ut est beatae incidunt iste et cumque. Assumenda dolore magnam dicta dolores. Quam sed quisquam. Sit aut qui aut. Est hic cupiditate." },
                    { 580, 59, 89, 471015, new DateTime(2021, 1, 23, 13, 10, 32, 675, DateTimeKind.Local).AddTicks(2655), "impedit" },
                    { 599, 59, 102, 80665, new DateTime(2021, 8, 1, 13, 17, 26, 489, DateTimeKind.Local).AddTicks(8218), "Aut numquam dolorem atque et omnis eveniet illum.\nVoluptate molestiae accusantium sed ut at.\nNisi dolores aut repellat optio recusandae possimus explicabo numquam perferendis.\nUnde repellat velit at quas voluptatem nihil et." },
                    { 148, 87, 24, 57572, new DateTime(2021, 7, 7, 7, 0, 2, 240, DateTimeKind.Local).AddTicks(3794), "pariatur" },
                    { 178, 87, 16, 15970, new DateTime(2021, 4, 18, 15, 51, 25, 626, DateTimeKind.Local).AddTicks(2375), "Totam cumque et perferendis cumque consequuntur qui error." },
                    { 277, 87, 143, 613328, new DateTime(2020, 10, 20, 17, 20, 9, 435, DateTimeKind.Local).AddTicks(9634), "ducimus" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 304, 87, 147, 574389, new DateTime(2021, 2, 12, 17, 57, 50, 577, DateTimeKind.Local).AddTicks(9062), "Qui dolor veritatis. Incidunt nesciunt sit nostrum occaecati dolore et doloremque. Officiis neque fugit velit et. Qui animi adipisci provident. Quae dolores sunt consequatur et aspernatur qui similique magni. Laudantium facere quae qui quam vel." },
                    { 356, 87, 46, 667513, new DateTime(2021, 3, 1, 10, 40, 2, 68, DateTimeKind.Local).AddTicks(8993), "placeat" },
                    { 431, 87, 123, 12387, new DateTime(2021, 1, 1, 23, 58, 32, 171, DateTimeKind.Local).AddTicks(4841), "Tempore ab consequatur.\nExcepturi officiis nesciunt occaecati quisquam praesentium.\nEt doloribus animi consequatur quia ullam." },
                    { 454, 87, 129, 731080, new DateTime(2020, 9, 9, 21, 33, 29, 710, DateTimeKind.Local).AddTicks(32), "Praesentium dolores accusamus et beatae.\nDolores aspernatur reprehenderit eos non corporis consequatur incidunt.\nConsequatur perferendis autem.\nQuia ut quod autem ad et et aspernatur sed.\nAssumenda maxime commodi consequatur sed molestiae voluptatem repellat rerum modi." },
                    { 59, 74, 86, 270576, new DateTime(2020, 11, 1, 8, 35, 21, 166, DateTimeKind.Local).AddTicks(3493), "aspernatur" },
                    { 69, 74, 106, 596945, new DateTime(2021, 1, 24, 22, 45, 4, 764, DateTimeKind.Local).AddTicks(8160), "Et sed labore quae quis.\nAtque velit quia nemo qui debitis sint sed quas repellat.\nRerum ab occaecati voluptas rerum.\nIusto omnis vel ea laborum numquam blanditiis a et quia.\nUt quasi placeat.\nMagni qui accusamus exercitationem omnis." },
                    { 107, 74, 127, 364351, new DateTime(2021, 7, 4, 22, 59, 40, 196, DateTimeKind.Local).AddTicks(8111), "Quia accusantium deserunt. Facilis laboriosam libero praesentium. Sed sit at sed quia facilis dolor modi iste. Quibusdam nostrum atque repellendus. Repellendus inventore necessitatibus illo et amet eum soluta." },
                    { 151, 74, 79, 948747, new DateTime(2020, 10, 30, 22, 44, 4, 489, DateTimeKind.Local).AddTicks(895), "Dicta autem illum quis. Animi numquam in qui odit et. Accusamus sint iure delectus. Et ipsa distinctio labore. Eius aut qui quis ratione accusantium commodi aut. Eum impedit delectus doloribus vel ea voluptatem facilis." },
                    { 260, 74, 100, 850764, new DateTime(2021, 7, 22, 0, 30, 11, 550, DateTimeKind.Local).AddTicks(8806), "ut" },
                    { 326, 74, 66, 542284, new DateTime(2020, 12, 4, 1, 47, 18, 846, DateTimeKind.Local).AddTicks(7463), "Aut dolorum saepe." },
                    { 333, 74, 6, 823107, new DateTime(2020, 10, 31, 3, 55, 39, 425, DateTimeKind.Local).AddTicks(4619), "Veritatis perferendis aliquid iure odit voluptatem voluptas voluptas neque.\nFacere omnis illum saepe velit.\nVoluptatem maxime vero sunt.\nSoluta iure nesciunt et et qui vero." },
                    { 369, 74, 121, 841185, new DateTime(2021, 2, 22, 17, 30, 19, 748, DateTimeKind.Local).AddTicks(5775), "Architecto consequatur et voluptates sed quae debitis. Iste tenetur incidunt dolorum debitis ex quis accusantium. Sed magni maxime officiis sit aut itaque." },
                    { 374, 74, 59, 642548, new DateTime(2021, 5, 29, 3, 29, 13, 250, DateTimeKind.Local).AddTicks(9255), "Quaerat veritatis similique ab et totam recusandae quam enim cupiditate.\nMagnam dignissimos voluptas quas voluptatem porro.\nOfficia eius voluptatem est.\nEt sed voluptatem repudiandae ut est adipisci.\nEum quis beatae qui sed et cumque esse." },
                    { 220, 88, 106, 182579, new DateTime(2020, 12, 14, 7, 58, 42, 764, DateTimeKind.Local).AddTicks(5499), "Rerum est rem odio in velit.\nLaborum sit veniam consequuntur perspiciatis ab iste et provident.\nQui voluptatem omnis quaerat dolores.\nA sit ullam.\nPraesentium maxime voluptatum temporibus suscipit exercitationem corrupti nesciunt." },
                    { 131, 88, 26, 27415, new DateTime(2020, 11, 3, 0, 30, 37, 563, DateTimeKind.Local).AddTicks(4614), "qui" },
                    { 118, 88, 118, 852329, new DateTime(2021, 1, 10, 14, 32, 4, 33, DateTimeKind.Local).AddTicks(7326), "Minus eaque nostrum repellendus officia sint qui." },
                    { 91, 88, 33, 279971, new DateTime(2021, 8, 22, 10, 47, 45, 138, DateTimeKind.Local).AddTicks(1327), "Et et consequatur quae quisquam dolorem.\nQuasi asperiores dolores sed aliquid atque sint qui rerum omnis." },
                    { 545, 41, 43, 610158, new DateTime(2021, 5, 4, 4, 25, 11, 722, DateTimeKind.Local).AddTicks(3108), "Unde eos ab quo vero. Eum ab tenetur iste odio eaque dolorem commodi consequatur. Cum ea numquam laborum voluptate sunt neque. Nisi voluptas dolores quia doloremque a alias fugit accusantium." },
                    { 561, 41, 35, 629259, new DateTime(2021, 8, 14, 3, 31, 30, 711, DateTimeKind.Local).AddTicks(8990), "Quo et est aut possimus. Aut possimus fuga. Quia deleniti culpa voluptatibus dolore autem rem. Assumenda consequatur ut rerum reprehenderit. Delectus itaque necessitatibus itaque laudantium. Et fugit corporis." },
                    { 19, 63, 98, 580642, new DateTime(2021, 4, 26, 4, 27, 15, 384, DateTimeKind.Local).AddTicks(1831), "Quia saepe sunt doloremque tempore nihil. Cumque ullam porro necessitatibus natus non. Ipsa ipsum et distinctio quia error voluptas aspernatur illo. Officiis animi explicabo aut. Est et odit nobis et corporis ut. Et molestiae incidunt cum consectetur ut possimus." },
                    { 256, 63, 93, 688136, new DateTime(2021, 5, 15, 4, 44, 55, 124, DateTimeKind.Local).AddTicks(3975), "laudantium" },
                    { 27, 81, 46, 875171, new DateTime(2020, 9, 15, 23, 15, 43, 766, DateTimeKind.Local).AddTicks(3500), "Eaque ducimus ad tempore.\nDolorum culpa sed dolor beatae tempore quos sed reprehenderit.\nEa nam consequatur voluptatem accusamus." },
                    { 53, 81, 70, 512464, new DateTime(2021, 8, 24, 17, 19, 15, 139, DateTimeKind.Local).AddTicks(9393), "Dolore mollitia sunt.\nEum consectetur fugiat quidem et et quaerat corrupti nisi." },
                    { 233, 81, 116, 256820, new DateTime(2021, 1, 8, 10, 55, 36, 181, DateTimeKind.Local).AddTicks(3827), "Reprehenderit laborum blanditiis accusantium." },
                    { 319, 81, 85, 945970, new DateTime(2020, 9, 13, 9, 36, 55, 210, DateTimeKind.Local).AddTicks(1948), "Dolorem voluptas consequuntur nobis laboriosam aut sed voluptas quis minima." },
                    { 534, 41, 95, 751510, new DateTime(2021, 8, 3, 17, 52, 13, 668, DateTimeKind.Local).AddTicks(8046), "nemo" },
                    { 461, 81, 108, 25815, new DateTime(2021, 2, 6, 1, 59, 46, 559, DateTimeKind.Local).AddTicks(4793), "Ipsum voluptatem laborum illum eum quis temporibus voluptas quia. Eaque sapiente deserunt fugit. Vitae accusantium delectus. Voluptatem et voluptas unde minima eveniet non voluptas. Quam alias repellat non natus repudiandae ad culpa unde." },
                    { 509, 81, 35, 114924, new DateTime(2021, 4, 30, 18, 54, 17, 645, DateTimeKind.Local).AddTicks(1561), "Et et ipsa eveniet.\nAutem amet consequuntur ipsam sapiente.\nPorro sunt et saepe iste possimus aut voluptas deserunt.\nOdio fuga est vel debitis unde ut optio eos.\nQuo esse id fugiat esse qui." },
                    { 22, 15, 144, 243239, new DateTime(2020, 10, 17, 21, 4, 2, 922, DateTimeKind.Local).AddTicks(4203), "Qui id non consectetur eum veniam sunt eum.\nSunt velit consectetur deserunt doloremque consequatur aut veritatis cupiditate.\nAd architecto qui doloribus inventore qui ut voluptatem.\nUt repellat natus velit perferendis non sit doloribus in et.\nDoloremque dolores quisquam deserunt." },
                    { 271, 15, 93, 999606, new DateTime(2020, 10, 13, 20, 0, 2, 721, DateTimeKind.Local).AddTicks(7203), "Officiis mollitia minus pariatur." },
                    { 546, 15, 150, 698321, new DateTime(2021, 3, 25, 2, 55, 40, 687, DateTimeKind.Local).AddTicks(8786), "incidunt" },
                    { 42, 39, 76, 728323, new DateTime(2020, 11, 11, 17, 31, 11, 442, DateTimeKind.Local).AddTicks(7592), "et" },
                    { 239, 39, 42, 99538, new DateTime(2021, 7, 10, 18, 35, 55, 276, DateTimeKind.Local).AddTicks(7049), "Maiores quia non ea qui rem voluptatem odio nihil dolore.\nOmnis perspiciatis sapiente dolorum omnis.\nEaque voluptas cum fugiat natus eveniet.\nOdit aut ratione quia voluptates quo qui repellendus explicabo quibusdam.\nCorrupti vel ipsa amet velit impedit qui quas et.\nAb est nulla unde minima fugiat maiores quod." },
                    { 362, 39, 125, 340216, new DateTime(2021, 1, 18, 15, 23, 52, 201, DateTimeKind.Local).AddTicks(5292), "Necessitatibus nobis molestiae ut est repellat numquam autem aut." },
                    { 466, 39, 45, 150638, new DateTime(2021, 1, 16, 6, 18, 6, 568, DateTimeKind.Local).AddTicks(9318), "Deserunt quia tempore.\nOfficia ipsum neque quibusdam unde vel ipsum nisi." },
                    { 479, 81, 124, 914422, new DateTime(2021, 3, 13, 22, 31, 39, 482, DateTimeKind.Local).AddTicks(2513), "Inventore voluptatem explicabo.\nEa veniam esse est.\nAut iure dolores laboriosam voluptas occaecati nesciunt." },
                    { 495, 41, 54, 868141, new DateTime(2020, 10, 19, 15, 49, 38, 10, DateTimeKind.Local).AddTicks(2943), "Ut aut illo.\nOmnis officia qui tempora itaque laboriosam quae qui corrupti.\nMolestias et omnis quas id ut et." },
                    { 453, 41, 44, 602520, new DateTime(2021, 3, 16, 18, 26, 6, 36, DateTimeKind.Local).AddTicks(2394), "Eveniet esse nostrum veniam sed numquam cum.\nCum excepturi quasi et alias.\nDolorum asperiores vero error similique quas modi aperiam.\nDoloribus voluptatum necessitatibus nesciunt et aliquam ullam impedit et architecto.\nNecessitatibus nisi consequatur autem totam." },
                    { 448, 41, 140, 812739, new DateTime(2021, 2, 9, 15, 16, 37, 620, DateTimeKind.Local).AddTicks(7694), "provident" },
                    { 261, 30, 54, 873757, new DateTime(2021, 6, 9, 6, 2, 38, 463, DateTimeKind.Local).AddTicks(8682), "consequatur" },
                    { 392, 30, 66, 342799, new DateTime(2021, 5, 26, 5, 50, 35, 149, DateTimeKind.Local).AddTicks(3354), "Facere dolorem culpa id totam ab ut. Explicabo fugiat libero repudiandae optio et. Tempora aut minus sunt praesentium adipisci enim voluptatibus. Qui earum consectetur ipsam ut non vero rerum qui ut. Ab sit voluptas ullam pariatur magni est. Reprehenderit quo dolorem quibusdam dolorum aut porro velit ut." },
                    { 397, 30, 104, 754330, new DateTime(2020, 11, 28, 23, 29, 1, 142, DateTimeKind.Local).AddTicks(2607), "Et dolorem culpa veniam qui velit expedita eos at odit.\nExercitationem perferendis et facilis qui porro quam rerum.\nPerspiciatis molestiae labore ut autem.\nNostrum numquam rerum et dolorum fugit.\nFacilis eius quas ab dolor veniam.\nEveniet qui minima quod sunt quisquam rem animi porro." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 467, 30, 11, 319452, new DateTime(2021, 3, 23, 14, 4, 46, 410, DateTimeKind.Local).AddTicks(5708), "at" },
                    { 20, 34, 42, 29045, new DateTime(2021, 6, 29, 16, 57, 36, 23, DateTimeKind.Local).AddTicks(8677), "Numquam deserunt quam sed beatae voluptas. Sequi quasi est excepturi neque non voluptatum repellendus debitis voluptates. Qui et odio id explicabo rerum dolores. Ullam et nostrum eveniet. Dicta nam ut accusantium excepturi voluptatem. Modi veritatis harum facilis at dolorum." },
                    { 78, 34, 138, 478845, new DateTime(2021, 2, 28, 10, 43, 46, 493, DateTimeKind.Local).AddTicks(1676), "Praesentium facere nobis adipisci." },
                    { 269, 34, 123, 192893, new DateTime(2021, 3, 25, 4, 53, 59, 690, DateTimeKind.Local).AddTicks(4014), "Et quod suscipit placeat eveniet fuga qui ut reiciendis. Veniam quos est sed delectus sapiente dolorum fugit maxime. Temporibus asperiores dolorem deserunt illum et sit non. Iste nam perspiciatis quasi. Laudantium est error. Et voluptatem delectus earum quia dolorem." },
                    { 289, 34, 64, 825464, new DateTime(2021, 2, 8, 11, 26, 48, 90, DateTimeKind.Local).AddTicks(2125), "Quia culpa aut vel dolores fugit quo sequi dolores quia.\nDolores corporis rerum alias.\nMinima est est unde ullam nihil in." },
                    { 403, 34, 8, 574147, new DateTime(2021, 4, 10, 3, 7, 3, 226, DateTimeKind.Local).AddTicks(3961), "Quam quia id magnam eos. Nemo voluptas aut tempora. Possimus perferendis repudiandae repellendus aspernatur quis ut esse aut eum. Assumenda qui odit atque sit nihil sit sint quis rerum." },
                    { 516, 34, 142, 253054, new DateTime(2021, 5, 10, 15, 40, 51, 333, DateTimeKind.Local).AddTicks(7191), "Deserunt et rerum. Velit vero eos ut nihil distinctio perspiciatis unde totam sit. Inventore vel non nemo itaque reiciendis blanditiis pariatur aut. Ut autem quos. Dignissimos doloribus similique et ipsam et sunt quia provident et." },
                    { 48, 5, 3, 867399, new DateTime(2021, 7, 2, 9, 46, 41, 248, DateTimeKind.Local).AddTicks(7566), "quasi" },
                    { 121, 5, 131, 780726, new DateTime(2021, 6, 16, 19, 13, 15, 77, DateTimeKind.Local).AddTicks(948), "sint" },
                    { 206, 5, 52, 10814, new DateTime(2020, 9, 28, 6, 34, 49, 855, DateTimeKind.Local).AddTicks(8000), "Et nisi culpa nemo assumenda mollitia autem quaerat. Est et omnis atque asperiores omnis et dolorem. Ratione enim aliquid nesciunt fugiat incidunt sit earum eum." },
                    { 216, 5, 116, 753652, new DateTime(2021, 5, 27, 5, 43, 0, 365, DateTimeKind.Local).AddTicks(936), "Corrupti minus dolor in et commodi quas et ut. Omnis totam debitis reprehenderit quia quibusdam vel assumenda et. Nulla laudantium perspiciatis consequatur corrupti praesentium provident." },
                    { 298, 5, 67, 120779, new DateTime(2021, 1, 27, 20, 54, 43, 281, DateTimeKind.Local).AddTicks(8979), "Adipisci saepe accusamus eum fugit excepturi voluptatum voluptatem." },
                    { 385, 69, 44, 240099, new DateTime(2020, 11, 17, 1, 51, 30, 202, DateTimeKind.Local).AddTicks(7553), "rerum" },
                    { 537, 69, 112, 736738, new DateTime(2021, 4, 24, 5, 29, 27, 989, DateTimeKind.Local).AddTicks(8735), "Maxime est repudiandae eligendi neque et dignissimos perferendis." },
                    { 5, 41, 20, 754653, new DateTime(2020, 9, 19, 22, 13, 8, 208, DateTimeKind.Local).AddTicks(8305), "dolorem" },
                    { 399, 41, 100, 696036, new DateTime(2021, 2, 7, 2, 59, 2, 717, DateTimeKind.Local).AddTicks(4799), "Vero numquam nulla et quis nostrum." },
                    { 570, 39, 107, 68602, new DateTime(2020, 12, 24, 15, 49, 42, 454, DateTimeKind.Local).AddTicks(1564), "Sunt natus porro dicta ut odit nobis ullam.\nMagnam minus tempora.\nQuidem alias assumenda quia id occaecati totam esse.\nConsequatur dolore rerum tempora omnis id eum." },
                    { 212, 30, 27, 128872, new DateTime(2020, 11, 12, 23, 47, 45, 332, DateTimeKind.Local).AddTicks(5087), "Officia inventore ipsam quis." },
                    { 153, 73, 138, 157113, new DateTime(2021, 4, 23, 23, 5, 27, 537, DateTimeKind.Local).AddTicks(6684), "earum" },
                    { 344, 73, 100, 698367, new DateTime(2020, 10, 30, 14, 41, 52, 463, DateTimeKind.Local).AddTicks(4277), "aut" },
                    { 280, 70, 101, 330229, new DateTime(2021, 6, 22, 19, 59, 57, 509, DateTimeKind.Local).AddTicks(3203), "Eligendi omnis fugiat." },
                    { 329, 70, 74, 538720, new DateTime(2021, 3, 17, 9, 59, 0, 560, DateTimeKind.Local).AddTicks(6304), "Eligendi dolorem omnis fuga voluptatem dolorem quia quas." },
                    { 60, 8, 82, 624130, new DateTime(2021, 7, 2, 7, 12, 19, 903, DateTimeKind.Local).AddTicks(2559), "Rerum sint quas saepe non quia aut." },
                    { 228, 8, 150, 281283, new DateTime(2020, 10, 10, 0, 5, 40, 334, DateTimeKind.Local).AddTicks(6265), "Consequatur minus vel quam quo. Est id vel deserunt vel architecto alias aut harum. Vitae dolorum iusto cupiditate est. Nulla eligendi ratione fuga iusto ipsum quia sunt sed voluptas." },
                    { 373, 8, 26, 491014, new DateTime(2020, 12, 7, 5, 44, 7, 697, DateTimeKind.Local).AddTicks(632), "Natus deserunt ut tenetur exercitationem deleniti dolores. Quia rem atque nemo autem reprehenderit enim repellendus qui. Repudiandae eos fuga eos veniam qui quos ipsa aperiam. Ut amet facere veniam porro in et cumque. Sint in saepe modi." },
                    { 52, 28, 67, 348003, new DateTime(2021, 3, 9, 6, 50, 33, 806, DateTimeKind.Local).AddTicks(8268), "Iure et dolor necessitatibus.\nDeleniti non vel nulla aliquid et.\nVeniam enim deleniti id.\nAut voluptatem iure optio quae ut ut voluptatibus.\nPraesentium velit voluptatum facere reprehenderit tempore aut eum dolores fugit." },
                    { 286, 28, 82, 55145, new DateTime(2021, 8, 5, 18, 43, 22, 513, DateTimeKind.Local).AddTicks(9236), "Tempora maiores sint quidem eius et ea eos et." },
                    { 327, 28, 23, 717139, new DateTime(2020, 12, 10, 17, 38, 47, 91, DateTimeKind.Local).AddTicks(6957), "Dolor nulla omnis modi enim architecto nobis. Eos porro libero. Laborum natus eaque pariatur distinctio cum commodi exercitationem. Aut laboriosam aut nobis corrupti culpa." },
                    { 244, 70, 71, 112793, new DateTime(2020, 10, 3, 7, 23, 26, 651, DateTimeKind.Local).AddTicks(996), "modi" },
                    { 391, 28, 150, 942025, new DateTime(2021, 1, 14, 9, 5, 12, 457, DateTimeKind.Local).AddTicks(6666), "Quia enim totam odio. Recusandae nulla fugiat at quo. Debitis sit officiis voluptates. Assumenda eveniet commodi et accusamus tempora eum id dolores quia." },
                    { 18, 60, 131, 44123, new DateTime(2020, 10, 26, 23, 29, 5, 506, DateTimeKind.Local).AddTicks(822), "occaecati" },
                    { 191, 60, 25, 286842, new DateTime(2021, 1, 19, 1, 15, 51, 476, DateTimeKind.Local).AddTicks(2992), "Architecto soluta incidunt cum corrupti nesciunt deserunt corporis. Illum quam officia a maiores et consequatur. Inventore voluptas eaque est alias tempora autem." },
                    { 218, 60, 87, 429094, new DateTime(2021, 1, 18, 1, 48, 5, 604, DateTimeKind.Local).AddTicks(2501), "Est corporis et porro atque velit qui.\nMinima dicta esse mollitia quo exercitationem dolor reiciendis in in." },
                    { 377, 60, 39, 303585, new DateTime(2020, 10, 7, 14, 57, 36, 221, DateTimeKind.Local).AddTicks(6654), "Ex sit minus. Voluptatum iusto excepturi consequatur delectus enim voluptatem aliquid mollitia quis. Officiis delectus sunt cumque. Qui nesciunt non facilis delectus minima itaque. Voluptatem iusto corrupti mollitia. Fugit rem quos voluptatem ipsa quibusdam enim incidunt nemo." },
                    { 407, 60, 57, 941520, new DateTime(2021, 1, 10, 12, 0, 52, 249, DateTimeKind.Local).AddTicks(9002), "Impedit maxime dolores veritatis quas optio aliquid." },
                    { 427, 60, 26, 572552, new DateTime(2021, 4, 6, 11, 32, 48, 276, DateTimeKind.Local).AddTicks(2723), "perspiciatis" },
                    { 459, 60, 59, 932885, new DateTime(2020, 11, 1, 9, 33, 54, 437, DateTimeKind.Local).AddTicks(5304), "Magni et distinctio doloribus. Aut eligendi labore nobis ullam. Vitae ex iste sint et in." },
                    { 63, 88, 106, 591750, new DateTime(2020, 10, 20, 5, 34, 16, 855, DateTimeKind.Local).AddTicks(9914), "Voluptate sunt dolores animi quis magnam natus nihil. Molestiae aperiam autem fugit quia placeat consequuntur fuga temporibus. Distinctio quia aperiam dolorem. Cumque ut quidem error. Dolorum sed beatae tempore minima asperiores reiciendis reiciendis qui. Nihil qui harum sapiente at vitae consequatur non minus quasi." },
                    { 413, 28, 14, 951239, new DateTime(2021, 1, 26, 3, 54, 5, 103, DateTimeKind.Local).AddTicks(2438), "numquam" },
                    { 116, 70, 101, 657805, new DateTime(2021, 2, 7, 0, 17, 3, 865, DateTimeKind.Local).AddTicks(8867), "Eius rerum iusto ut autem est assumenda ipsam.\nCum in dolor sapiente omnis amet unde ad voluptatem.\nVoluptates laborum aut et aut odio quis consequatur." },
                    { 86, 70, 37, 505434, new DateTime(2020, 11, 27, 8, 17, 49, 525, DateTimeKind.Local).AddTicks(2028), "at" },
                    { 72, 70, 65, 27814, new DateTime(2020, 8, 30, 11, 46, 50, 578, DateTimeKind.Local).AddTicks(7360), "Vero nam dicta est quod tenetur recusandae. Ut omnis ut similique modi aut architecto asperiores quo. Nihil beatae animi nemo non veniam enim. Est velit qui velit laudantium omnis eos quia. Magni enim excepturi consectetur. Similique reiciendis aut voluptatem." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 465, 73, 134, 836270, new DateTime(2021, 5, 4, 20, 15, 9, 608, DateTimeKind.Local).AddTicks(6982), "Magnam eligendi ea fuga." },
                    { 477, 73, 69, 487836, new DateTime(2021, 7, 11, 17, 7, 54, 40, DateTimeKind.Local).AddTicks(4099), "porro" },
                    { 527, 73, 111, 444760, new DateTime(2021, 4, 2, 16, 5, 39, 139, DateTimeKind.Local).AddTicks(542), "Asperiores rem dolor ipsam officia rem recusandae vel." },
                    { 565, 73, 36, 6040, new DateTime(2021, 3, 27, 23, 30, 33, 749, DateTimeKind.Local).AddTicks(2124), "rem" },
                    { 57, 36, 76, 944456, new DateTime(2020, 9, 22, 8, 23, 27, 480, DateTimeKind.Local).AddTicks(2030), "Rerum est cumque reiciendis consectetur. Non aut eum aliquam nemo quo hic sequi. Rerum aut optio eum vero qui et dolor quasi possimus." },
                    { 74, 36, 122, 896286, new DateTime(2021, 4, 16, 1, 51, 27, 667, DateTimeKind.Local).AddTicks(9902), "Nostrum veniam officiis nostrum." },
                    { 136, 36, 7, 158585, new DateTime(2020, 10, 16, 16, 20, 3, 660, DateTimeKind.Local).AddTicks(5502), "Aut optio quos qui labore." },
                    { 538, 36, 140, 794872, new DateTime(2021, 1, 2, 0, 52, 32, 337, DateTimeKind.Local).AddTicks(2479), "molestiae" },
                    { 569, 36, 128, 696853, new DateTime(2020, 11, 21, 4, 25, 11, 413, DateTimeKind.Local).AddTicks(5843), "Consectetur in aut qui occaecati aspernatur qui similique.\nVel quia laudantium aut modi quas cupiditate architecto et aut.\nDelectus iste qui labore laudantium.\nIn quaerat voluptatem corporis consequatur architecto sint expedita laudantium." },
                    { 592, 36, 117, 288930, new DateTime(2021, 5, 1, 22, 32, 29, 14, DateTimeKind.Local).AddTicks(4711), "Laudantium consectetur aut non ullam hic cupiditate et repellendus optio. Et voluptatem fugiat odio odio a recusandae dolorem temporibus. Eos praesentium voluptate." },
                    { 79, 50, 106, 109144, new DateTime(2020, 10, 17, 22, 4, 49, 599, DateTimeKind.Local).AddTicks(6070), "Saepe atque ea.\nVelit aut doloribus totam ducimus dolorem et distinctio ut est.\nDolorum voluptatem ea necessitatibus aperiam culpa rerum vitae consequatur.\nVoluptas accusantium dignissimos necessitatibus dignissimos blanditiis rerum itaque earum.\nDucimus et enim.\nDignissimos fuga quia repudiandae corporis eius explicabo ratione quam et." },
                    { 92, 50, 63, 700013, new DateTime(2020, 8, 30, 2, 16, 28, 126, DateTimeKind.Local).AddTicks(8830), "Atque aliquam provident et omnis perferendis suscipit occaecati.\nOccaecati dolorem iste consequatur consequatur voluptatem culpa molestiae et quae.\nA quibusdam aspernatur similique incidunt perferendis est aut ad sed.\nVoluptatem unde facilis error.\nExercitationem eum nemo voluptatibus nesciunt animi.\nDelectus est quia earum delectus." },
                    { 147, 50, 55, 648211, new DateTime(2021, 1, 17, 8, 48, 41, 39, DateTimeKind.Local).AddTicks(3372), "Enim iste libero." },
                    { 163, 50, 100, 33578, new DateTime(2020, 11, 8, 9, 35, 47, 800, DateTimeKind.Local).AddTicks(9847), "Ut saepe qui cupiditate aspernatur accusantium." },
                    { 217, 50, 118, 973813, new DateTime(2021, 6, 29, 20, 7, 4, 346, DateTimeKind.Local).AddTicks(8282), "Animi quibusdam id possimus quae.\nVoluptatem magni reiciendis ut sit in dolor.\nQuo nesciunt suscipit deleniti quo excepturi.\nAccusantium consectetur quia sunt laudantium fugiat magnam quos dolores sunt." },
                    { 283, 50, 75, 132893, new DateTime(2021, 6, 25, 4, 40, 34, 516, DateTimeKind.Local).AddTicks(86), "Quia sit quaerat debitis cupiditate voluptas cum sunt libero aut.\nEt non qui ut quod.\nQuae maxime est praesentium.\nQuia facere assumenda aut molestiae nulla." },
                    { 449, 50, 102, 13290, new DateTime(2021, 3, 4, 1, 53, 10, 636, DateTimeKind.Local).AddTicks(1899), "Enim natus dolores eveniet.\nVoluptatum omnis est et aliquid perspiciatis sed.\nAccusantium deleniti autem omnis dolorem maiores sed sequi.\nMagnam enim voluptatem alias qui consequatur.\nRatione atque minima nam non.\nSunt consequatur aut." },
                    { 469, 50, 118, 266524, new DateTime(2021, 1, 26, 16, 42, 59, 371, DateTimeKind.Local).AddTicks(459), "dignissimos" },
                    { 522, 50, 43, 123618, new DateTime(2020, 9, 1, 5, 49, 13, 908, DateTimeKind.Local).AddTicks(6812), "Perspiciatis natus numquam. Recusandae libero suscipit itaque et similique quia non consequatur. Dolorem quae a quisquam reprehenderit veniam. Minima officia facilis." },
                    { 303, 73, 121, 458787, new DateTime(2020, 9, 22, 2, 41, 34, 434, DateTimeKind.Local).AddTicks(7179), "Ullam commodi voluptates quia cupiditate.\nAtque adipisci recusandae.\nAutem est aut.\nEt quos eius cum atque rerum optio." },
                    { 318, 85, 141, 336595, new DateTime(2021, 8, 15, 6, 55, 34, 581, DateTimeKind.Local).AddTicks(4342), "Totam illo suscipit ipsum ex vitae consectetur. Veniam praesentium facere iure sed blanditiis omnis ut eaque. Eaque dolorem qui repellendus quo tempora ut. Quo repudiandae et. Natus consectetur consequuntur ut commodi. Debitis sunt optio recusandae eveniet explicabo sit facere distinctio saepe." },
                    { 409, 38, 35, 974032, new DateTime(2020, 10, 4, 4, 44, 28, 72, DateTimeKind.Local).AddTicks(1862), "Quo soluta eum voluptatem qui aliquid.\nPariatur magnam consequuntur eum voluptates vitae nihil doloremque delectus incidunt.\nAnimi ducimus sed quia et exercitationem sed dicta debitis quas.\nFacere dolor facere.\nRepellat similique aperiam laboriosam consequatur modi maxime.\nIn sint ipsa cumque eos aliquid doloribus ut dolores est." },
                    { 66, 85, 13, 8787, new DateTime(2021, 5, 26, 21, 9, 38, 905, DateTimeKind.Local).AddTicks(2854), "Temporibus eos voluptates quasi vero ullam exercitationem ut.\nOccaecati impedit quas omnis sed suscipit qui.\nDoloribus deserunt inventore ratione debitis dolorem maiores et et." },
                    { 490, 86, 102, 489660, new DateTime(2020, 12, 11, 20, 45, 9, 416, DateTimeKind.Local).AddTicks(1063), "reprehenderit" },
                    { 492, 86, 93, 247540, new DateTime(2020, 12, 15, 7, 31, 11, 52, DateTimeKind.Local).AddTicks(7618), "est" },
                    { 501, 86, 91, 435995, new DateTime(2021, 3, 14, 6, 46, 40, 746, DateTimeKind.Local).AddTicks(9206), "Id nisi rem ut odit et quibusdam.\nPlaceat nisi molestiae dicta voluptatem.\nSit illum facilis.\nQui dolorum dolorum." },
                    { 236, 7, 144, 710230, new DateTime(2020, 9, 12, 23, 1, 30, 398, DateTimeKind.Local).AddTicks(1005), "Eos consequatur est voluptate vero voluptas non." },
                    { 268, 7, 78, 95193, new DateTime(2021, 1, 9, 22, 52, 51, 161, DateTimeKind.Local).AddTicks(6547), "earum" },
                    { 483, 7, 40, 535577, new DateTime(2021, 7, 19, 0, 54, 38, 458, DateTimeKind.Local).AddTicks(3911), "Sapiente harum ut laudantium tenetur vero magni quo quae et.\nTenetur eum tempora in est.\nLibero omnis temporibus aliquam exercitationem sed vel labore molestiae ab.\nAut ut est expedita voluptatem autem." },
                    { 503, 7, 132, 654807, new DateTime(2020, 11, 2, 7, 56, 4, 338, DateTimeKind.Local).AddTicks(7614), "Error placeat aut sint animi magnam qui eum ipsa occaecati. Eos voluptas excepturi et a eum cumque et debitis sed. Voluptatem minima placeat praesentium. Et occaecati qui qui. Aut velit ab at enim beatae odit deleniti quia." },
                    { 437, 86, 107, 155871, new DateTime(2021, 8, 17, 18, 50, 45, 140, DateTimeKind.Local).AddTicks(2128), "Et quam quae aliquid.\nDeleniti quod quis culpa id nam.\nVoluptate placeat voluptas et et ab omnis eligendi et eveniet.\nMolestiae at fuga earum et pariatur veritatis.\nNon id recusandae.\nEst quasi maxime laborum." },
                    { 523, 7, 82, 756325, new DateTime(2020, 11, 4, 20, 47, 22, 583, DateTimeKind.Local).AddTicks(1330), "Voluptatem blanditiis architecto repellendus quia non velit.\nVoluptatem laborum qui.\nUnde qui similique possimus dolore aut." },
                    { 117, 9, 9, 206308, new DateTime(2021, 3, 17, 18, 13, 41, 863, DateTimeKind.Local).AddTicks(7518), "Quo iste veniam nihil ad omnis alias earum porro. Sequi doloribus dolorem quo dolores sed eius earum officiis quia. Dolore ipsa omnis. Nihil quibusdam numquam expedita et alias libero dolorem neque. Et ut at maiores necessitatibus voluptates libero aliquam repudiandae qui." },
                    { 279, 9, 132, 555393, new DateTime(2021, 2, 7, 7, 6, 25, 452, DateTimeKind.Local).AddTicks(8439), "Explicabo omnis soluta libero molestias dolor dignissimos." },
                    { 315, 9, 101, 702381, new DateTime(2020, 11, 14, 13, 37, 49, 775, DateTimeKind.Local).AddTicks(5871), "Illo consequatur molestiae. Facere eligendi dolore. Culpa qui voluptatem veritatis eaque error fugiat reprehenderit rem. Aut dolores porro ea." },
                    { 499, 9, 69, 295555, new DateTime(2020, 12, 10, 9, 9, 8, 676, DateTimeKind.Local).AddTicks(8768), "Laborum a sint eum aut rerum a. Nulla ut odio quia. Perspiciatis modi sit consequuntur nemo consectetur omnis eius fuga. Qui laudantium officiis dignissimos in qui voluptatem dicta autem. Voluptatem aliquam rerum." },
                    { 126, 79, 20, 737919, new DateTime(2021, 7, 22, 17, 12, 9, 108, DateTimeKind.Local).AddTicks(6616), "Debitis minus quo eveniet et ut." },
                    { 106, 85, 118, 817365, new DateTime(2021, 3, 29, 11, 43, 54, 938, DateTimeKind.Local).AddTicks(8693), "Velit at non." },
                    { 336, 79, 142, 876209, new DateTime(2021, 8, 14, 14, 13, 1, 116, DateTimeKind.Local).AddTicks(4415), "Consequatur sit ducimus aut at ea.\nOfficia doloribus quo officiis numquam laudantium dolorem quia quia.\nEst voluptate voluptatum odit fugit est quia incidunt illo." },
                    { 595, 7, 126, 730174, new DateTime(2021, 8, 4, 13, 45, 35, 811, DateTimeKind.Local).AddTicks(2536), "Placeat quibusdam pariatur ullam reiciendis porro alias numquam sint. Velit sed quod ullam rerum natus ea architecto provident. Provident ut cumque quasi magnam molestiae nihil. Explicabo enim est quasi eveniet voluptatibus nobis error esse perspiciatis. Aspernatur tempora veniam magni aut aspernatur sed sunt." },
                    { 240, 86, 104, 43868, new DateTime(2020, 11, 30, 0, 4, 0, 654, DateTimeKind.Local).AddTicks(150), "Quia pariatur non doloribus occaecati. Blanditiis placeat ratione magni sapiente quis at. Delectus dolore illo fugiat modi illo. Corporis et et debitis." },
                    { 100, 86, 16, 797590, new DateTime(2020, 11, 17, 15, 48, 29, 372, DateTimeKind.Local).AddTicks(897), "Dolore a consequatur reprehenderit modi non." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 54, 86, 113, 92304, new DateTime(2021, 4, 25, 19, 17, 6, 890, DateTimeKind.Local).AddTicks(6478), "minus" },
                    { 365, 46, 86, 844695, new DateTime(2020, 11, 23, 16, 33, 23, 504, DateTimeKind.Local).AddTicks(1534), "odit" },
                    { 491, 46, 14, 409574, new DateTime(2021, 4, 4, 4, 31, 41, 275, DateTimeKind.Local).AddTicks(9229), "et" },
                    { 532, 46, 116, 156275, new DateTime(2021, 6, 25, 12, 58, 19, 466, DateTimeKind.Local).AddTicks(8027), "Ut fugit commodi ea at beatae suscipit.\nNobis nostrum sapiente et illo repellendus nesciunt rem accusantium.\nProvident est maiores praesentium totam numquam sed ex ea rem.\nEius laborum fuga temporibus est delectus fuga voluptatibus.\nUt temporibus itaque atque doloremque natus eum.\nBeatae error quaerat ea sequi eos." },
                    { 26, 64, 148, 659041, new DateTime(2021, 1, 15, 15, 22, 5, 133, DateTimeKind.Local).AddTicks(3354), "in" },
                    { 215, 64, 37, 956866, new DateTime(2021, 7, 1, 4, 2, 1, 420, DateTimeKind.Local).AddTicks(8594), "At culpa porro id et quae. Voluptatibus facere delectus provident. Quis velit impedit omnis voluptatem autem non. Sunt provident dolor. Delectus maiores cupiditate quis occaecati. Sapiente ipsa inventore voluptas." },
                    { 267, 64, 103, 661161, new DateTime(2021, 7, 22, 0, 8, 22, 741, DateTimeKind.Local).AddTicks(9392), "Maxime ipsam quidem.\nDeleniti eos illum magnam sint fugit.\nAspernatur atque corporis.\nQuia sapiente natus corporis et amet laudantium.\nRepudiandae voluptatem excepturi eveniet velit eos est esse quis." },
                    { 372, 64, 125, 848406, new DateTime(2021, 1, 31, 22, 24, 4, 13, DateTimeKind.Local).AddTicks(3423), "Id ipsam laborum et.\nVero fugit quo voluptas deleniti.\nMolestias eum tempora fugit eveniet officia.\nQuia magni et.\nProvident rem accusamus quis quisquam.\nOptio natus distinctio delectus totam ut." },
                    { 521, 64, 119, 857909, new DateTime(2020, 11, 8, 19, 47, 3, 494, DateTimeKind.Local).AddTicks(9587), "optio" },
                    { 567, 64, 148, 166143, new DateTime(2021, 1, 1, 5, 29, 40, 825, DateTimeKind.Local).AddTicks(9807), "Eos laudantium quia debitis libero ut inventore exercitationem soluta.\nSit quae assumenda veniam aut sed voluptates.\nReiciendis iusto voluptatibus illum alias nostrum." },
                    { 578, 64, 74, 550631, new DateTime(2021, 4, 11, 6, 36, 33, 952, DateTimeKind.Local).AddTicks(4857), "voluptates" },
                    { 581, 64, 104, 174709, new DateTime(2020, 10, 28, 21, 50, 53, 129, DateTimeKind.Local).AddTicks(7249), "Ut sint in." },
                    { 68, 83, 36, 107772, new DateTime(2021, 3, 9, 15, 13, 24, 392, DateTimeKind.Local).AddTicks(2250), "Aut eveniet sit cumque et perspiciatis." },
                    { 154, 83, 68, 213754, new DateTime(2021, 6, 19, 6, 13, 18, 579, DateTimeKind.Local).AddTicks(120), "blanditiis" },
                    { 265, 83, 135, 868850, new DateTime(2021, 3, 21, 5, 7, 56, 569, DateTimeKind.Local).AddTicks(8298), "Nihil nobis blanditiis repellat maxime voluptas aut a necessitatibus omnis." },
                    { 307, 83, 125, 11995, new DateTime(2021, 6, 2, 8, 23, 27, 840, DateTimeKind.Local).AddTicks(5144), "Repudiandae architecto non aut est sed nobis tempora necessitatibus.\nUnde quia ea omnis.\nQuam commodi enim dolores molestiae nemo accusantium autem enim dicta." },
                    { 573, 83, 20, 241496, new DateTime(2021, 8, 6, 23, 19, 30, 966, DateTimeKind.Local).AddTicks(6617), "veniam" },
                    { 31, 86, 116, 230322, new DateTime(2021, 6, 25, 17, 9, 27, 830, DateTimeKind.Local).AddTicks(6904), "A aperiam delectus non dolor.\nTemporibus rem quia unde laborum.\nVelit sunt vero sit quibusdam laborum et et sit.\nHarum alias quasi numquam veritatis repudiandae quod saepe.\nFuga sit impedit qui voluptate nesciunt assumenda accusamus." },
                    { 375, 79, 95, 114842, new DateTime(2020, 11, 18, 11, 37, 41, 622, DateTimeKind.Local).AddTicks(6247), "Ducimus eum eius totam consequatur.\nArchitecto qui aut et praesentium earum nulla voluptas iste doloremque." },
                    { 331, 46, 107, 844736, new DateTime(2020, 12, 3, 0, 53, 47, 464, DateTimeKind.Local).AddTicks(426), "Sed expedita odit animi sequi accusantium eos similique esse ut.\nQuidem eaque quasi velit recusandae eligendi earum possimus.\nDolor nemo dolore hic suscipit velit ipsum error voluptatibus." },
                    { 475, 79, 149, 334903, new DateTime(2021, 3, 5, 16, 53, 41, 404, DateTimeKind.Local).AddTicks(1061), "Optio incidunt placeat ut nisi accusamus quasi vel. Neque sapiente ex quia sunt amet rerum ratione aut. Voluptatibus eos et. Necessitatibus quas ducimus voluptatem nobis sequi sit quis mollitia quia. Fugit dolorem minus aliquid et consequatur tenetur est neque tenetur. Neque et enim." },
                    { 34, 44, 77, 185059, new DateTime(2020, 8, 30, 3, 50, 49, 68, DateTimeKind.Local).AddTicks(712), "Nam fugit fugiat veniam quasi eos. Non et est placeat accusantium assumenda. Labore nemo eligendi sed dicta quibusdam. Quidem non sit omnis deserunt rerum assumenda. Qui accusantium quo perferendis et quasi adipisci a omnis fuga. Ut tempora facere est aut amet." },
                    { 489, 16, 136, 10158, new DateTime(2021, 5, 24, 12, 28, 50, 718, DateTimeKind.Local).AddTicks(3042), "cupiditate" },
                    { 496, 16, 16, 404227, new DateTime(2021, 6, 26, 14, 26, 1, 813, DateTimeKind.Local).AddTicks(140), "Rerum facilis delectus rerum enim in.\nDoloribus vel et dicta hic." },
                    { 531, 16, 118, 876670, new DateTime(2021, 3, 28, 3, 40, 42, 649, DateTimeKind.Local).AddTicks(1298), "Sunt et enim exercitationem porro pariatur autem eum magni ut." },
                    { 558, 16, 69, 842818, new DateTime(2021, 6, 19, 21, 55, 23, 822, DateTimeKind.Local).AddTicks(3593), "Quidem consequatur occaecati." },
                    { 587, 16, 109, 844375, new DateTime(2021, 8, 25, 1, 34, 13, 493, DateTimeKind.Local).AddTicks(9188), "Ratione in laborum veniam tempore minus est assumenda quidem alias.\nOccaecati magni perferendis velit occaecati voluptate et odio beatae.\nQui repellat labore numquam illo dolorem non cumque.\nCumque deleniti quidem pariatur voluptate natus." },
                    { 11, 80, 22, 264187, new DateTime(2021, 4, 6, 5, 51, 40, 93, DateTimeKind.Local).AddTicks(9399), "Accusamus maxime et minus.\nTempore deleniti ut nemo enim illo eligendi vero eos." },
                    { 146, 80, 138, 621545, new DateTime(2021, 7, 21, 16, 56, 15, 500, DateTimeKind.Local).AddTicks(6599), "Et sit reprehenderit soluta repellat voluptatem pariatur rerum." },
                    { 418, 16, 66, 634871, new DateTime(2021, 3, 24, 22, 5, 31, 255, DateTimeKind.Local).AddTicks(9201), "Veritatis cupiditate enim sit. Ducimus itaque cum dolorum quia magni sed. Et nesciunt qui placeat tempora. Et velit itaque nihil accusantium in autem et et. Nemo illo et." },
                    { 435, 80, 50, 508266, new DateTime(2021, 8, 26, 7, 41, 44, 28, DateTimeKind.Local).AddTicks(4359), "Officia pariatur corrupti amet eligendi neque neque quod ducimus non.\nOdit et dolore sequi.\nIn reprehenderit temporibus eaque quo illo.\nOfficia hic consectetur quod sed.\nInventore ducimus quam id voluptas facilis.\nQuas ipsum facilis accusantium fugit explicabo." },
                    { 464, 80, 98, 281337, new DateTime(2021, 8, 25, 20, 1, 28, 814, DateTimeKind.Local).AddTicks(652), "Et exercitationem voluptatem voluptatibus iusto et eius harum.\nEos quo non doloribus.\nModi voluptates corporis qui natus commodi.\nAliquam deleniti voluptatibus rerum qui porro temporibus laboriosam rerum." },
                    { 539, 80, 72, 805768, new DateTime(2020, 11, 25, 4, 5, 20, 226, DateTimeKind.Local).AddTicks(1106), "Et omnis expedita porro sapiente. Quidem quia eos doloremque rerum maxime id quae. Reprehenderit quis officia voluptatem amet quia. Et et asperiores sint qui nihil officia dolorem hic. Eum ea sed quia quaerat reiciendis sed." },
                    { 559, 80, 42, 155593, new DateTime(2021, 8, 22, 8, 42, 39, 435, DateTimeKind.Local).AddTicks(7228), "Sapiente ducimus impedit pariatur atque.\nRatione adipisci earum voluptas eveniet at repudiandae.\nLaboriosam eum perferendis similique magnam ad reiciendis.\nItaque accusantium possimus ipsam quis nobis debitis non eos doloremque.\nTotam est dolores quia numquam facilis repudiandae ducimus error.\nQui ratione dolor blanditiis doloribus pariatur." },
                    { 114, 66, 116, 665549, new DateTime(2021, 2, 4, 0, 48, 44, 521, DateTimeKind.Local).AddTicks(2491), "Sit ab soluta accusamus provident sunt laborum non et veniam.\nVoluptate ad debitis ducimus.\nMolestiae illo quas porro distinctio quasi eum est quaerat." },
                    { 144, 66, 82, 927016, new DateTime(2021, 5, 24, 12, 40, 37, 415, DateTimeKind.Local).AddTicks(6800), "Ad qui magnam amet.\nEst et facilis voluptatem aut excepturi.\nSapiente qui pariatur voluptas labore quae labore pariatur voluptatem.\nMolestiae similique amet." },
                    { 194, 66, 64, 896533, new DateTime(2021, 4, 28, 10, 12, 40, 745, DateTimeKind.Local).AddTicks(1076), "Esse et aut. Doloribus quasi blanditiis vero quasi sed quos molestiae pariatur inventore. Maiores molestiae accusantium perferendis sed ut et ex beatae. Perspiciatis repellendus ratione et nam." },
                    { 209, 66, 127, 90841, new DateTime(2020, 12, 13, 9, 43, 52, 36, DateTimeKind.Local).AddTicks(4811), "Consequatur repudiandae aut dolorem vitae excepturi perspiciatis. Qui accusantium consequatur non fugiat quibusdam odit voluptatum. Repellendus molestiae aut dolorem quia repellendus voluptate nostrum ducimus iusto." },
                    { 442, 80, 25, 592839, new DateTime(2020, 10, 12, 18, 46, 10, 307, DateTimeKind.Local).AddTicks(2611), "Fugit omnis ab aperiam nam ut nihil hic non quis.\nEx eveniet rerum odit." },
                    { 366, 16, 122, 208035, new DateTime(2021, 4, 7, 15, 8, 48, 19, DateTimeKind.Local).AddTicks(1375), "Officia qui praesentium dolorem mollitia modi magni. Et minima aliquid odit doloremque quasi quae necessitatibus et dolores. Voluptate autem sunt." },
                    { 101, 16, 104, 880134, new DateTime(2021, 6, 13, 9, 13, 18, 217, DateTimeKind.Local).AddTicks(4320), "Eaque amet expedita dolores.\nUt officiis debitis ipsa aut facere.\nEarum facilis voluptates ea est quia omnis ea voluptatem.\nAliquid voluptatum tenetur rerum labore sit." },
                    { 574, 51, 149, 972151, new DateTime(2021, 3, 30, 22, 6, 4, 843, DateTimeKind.Local).AddTicks(6448), "Autem ab omnis quidem quia mollitia soluta provident dolorum.\nDolor distinctio culpa.\nError voluptatum architecto." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 94, 44, 138, 882057, new DateTime(2020, 12, 17, 5, 34, 5, 288, DateTimeKind.Local).AddTicks(269), "Esse excepturi non voluptatum amet ea.\nVoluptatem vitae numquam soluta omnis.\nLibero nemo harum qui velit deleniti consequatur.\nHic non recusandae corrupti.\nAlias itaque sed." },
                    { 115, 44, 31, 751353, new DateTime(2020, 12, 21, 13, 9, 16, 386, DateTimeKind.Local).AddTicks(6928), "rem" },
                    { 227, 44, 11, 586110, new DateTime(2021, 5, 30, 19, 9, 56, 496, DateTimeKind.Local).AddTicks(9753), "Saepe illo dolorem." },
                    { 292, 44, 150, 949210, new DateTime(2020, 8, 29, 0, 36, 23, 833, DateTimeKind.Local).AddTicks(8590), "Molestias eaque voluptatum sunt in non nostrum vitae.\nEt minus porro veritatis.\nNecessitatibus quis voluptatem sint eius incidunt rerum.\nVoluptatem illum minima minima id." },
                    { 317, 44, 62, 167286, new DateTime(2021, 2, 25, 22, 38, 26, 467, DateTimeKind.Local).AddTicks(1397), "Quam tenetur officia est pariatur odit iusto consequatur ducimus ut.\nOfficia ducimus ullam culpa inventore.\nCommodi vitae non rerum dolore.\nQuas esse doloremque dolorem aut illo veritatis.\nFugiat aperiam non voluptatem ab sit sunt repudiandae ullam.\nEsse minima sunt autem." },
                    { 429, 44, 124, 35695, new DateTime(2020, 10, 16, 7, 20, 29, 304, DateTimeKind.Local).AddTicks(8608), "Omnis sunt aut reprehenderit ducimus atque ad." },
                    { 502, 44, 54, 736579, new DateTime(2021, 2, 28, 21, 40, 18, 93, DateTimeKind.Local).AddTicks(7955), "Voluptas ratione molestiae temporibus voluptatum nam tenetur nihil aut repudiandae. Vitae molestiae voluptatem officia minima et consequuntur. Architecto nihil voluptate ut reprehenderit pariatur. Sint voluptatem et excepturi nam ratione aliquam rerum et id. Eos laborum animi sed mollitia nihil. Sint est optio mollitia accusamus nesciunt illo deleniti." },
                    { 560, 44, 132, 556585, new DateTime(2021, 3, 28, 23, 3, 20, 255, DateTimeKind.Local).AddTicks(118), "Excepturi soluta sunt.\nSuscipit laudantium ipsam aut.\nEt perferendis ducimus possimus quia dolorum et et laboriosam dolorem." },
                    { 2, 51, 38, 301575, new DateTime(2021, 1, 6, 4, 46, 34, 661, DateTimeKind.Local).AddTicks(8355), "Esse corrupti omnis nihil culpa et dolores est.\nEt consequatur vel et.\nLaudantium sit dolores quaerat quae accusamus et.\nIpsam vitae sint magnam voluptatem quaerat." },
                    { 9, 51, 77, 631282, new DateTime(2021, 5, 25, 8, 59, 26, 715, DateTimeKind.Local).AddTicks(4506), "A ullam dolorem quos earum. Ut quam dolorum fugiat repellendus eum accusantium magnam. Delectus provident voluptatem." },
                    { 104, 51, 116, 171100, new DateTime(2021, 7, 8, 11, 8, 53, 194, DateTimeKind.Local).AddTicks(1845), "Quae consequatur alias itaque magni eius ratione adipisci facere et.\nQuia corporis ut iste possimus eos.\nRerum autem et harum excepturi rem cupiditate ipsam ut ea.\nConsequuntur assumenda aut dolor impedit.\nVoluptates quam totam rem." },
                    { 133, 51, 148, 870084, new DateTime(2021, 1, 7, 16, 5, 12, 645, DateTimeKind.Local).AddTicks(1821), "fugiat" },
                    { 208, 51, 119, 492492, new DateTime(2021, 2, 10, 19, 41, 25, 215, DateTimeKind.Local).AddTicks(2460), "Laborum totam totam natus repellendus harum.\nConsequatur impedit excepturi aliquid aut dolorem numquam debitis dolore.\nUllam quidem tenetur debitis dolor tempore commodi.\nFugiat pariatur sint.\nRerum iure similique error sed assumenda dignissimos." },
                    { 278, 51, 149, 486617, new DateTime(2020, 9, 17, 0, 17, 11, 744, DateTimeKind.Local).AddTicks(1595), "Voluptas est id vel delectus voluptate labore temporibus dolor modi." },
                    { 296, 51, 13, 816438, new DateTime(2021, 3, 6, 1, 57, 7, 37, DateTimeKind.Local).AddTicks(2679), "Est quo ipsa similique laudantium est cum.\nVel rem corrupti omnis aliquam vel.\nVoluptatum omnis adipisci.\nQuidem corrupti dolore eaque.\nMolestiae incidunt earum velit ipsam earum sapiente minima." },
                    { 334, 51, 80, 139078, new DateTime(2021, 6, 1, 11, 38, 30, 346, DateTimeKind.Local).AddTicks(4297), "Et ut animi rerum corporis pariatur." },
                    { 505, 51, 70, 981280, new DateTime(2021, 6, 22, 17, 4, 11, 679, DateTimeKind.Local).AddTicks(635), "Assumenda eos et quod enim facilis vel." },
                    { 536, 79, 74, 566831, new DateTime(2021, 4, 10, 13, 6, 2, 516, DateTimeKind.Local).AddTicks(1196), "architecto" },
                    { 257, 46, 21, 867125, new DateTime(2020, 10, 25, 0, 33, 7, 567, DateTimeKind.Local).AddTicks(8129), "Aut sit labore. Aliquam magni eaque cum sed. Amet eos odit dolore velit ex nisi laudantium libero. Rerum accusamus et." },
                    { 241, 46, 82, 54418, new DateTime(2020, 10, 17, 16, 30, 24, 213, DateTimeKind.Local).AddTicks(617), "Qui maxime et sunt." },
                    { 141, 46, 57, 419712, new DateTime(2021, 2, 8, 19, 59, 49, 851, DateTimeKind.Local).AddTicks(4451), "aliquid" },
                    { 39, 77, 13, 551495, new DateTime(2021, 1, 20, 15, 24, 37, 561, DateTimeKind.Local).AddTicks(9406), "Unde velit et occaecati." },
                    { 46, 77, 128, 796826, new DateTime(2021, 1, 7, 18, 49, 49, 279, DateTimeKind.Local).AddTicks(8805), "Beatae dolores corrupti." },
                    { 122, 77, 142, 721250, new DateTime(2021, 7, 5, 0, 40, 17, 753, DateTimeKind.Local).AddTicks(3797), "Iure et minima quidem veniam et dicta." },
                    { 255, 77, 145, 623677, new DateTime(2021, 4, 9, 8, 38, 58, 278, DateTimeKind.Local).AddTicks(6437), "Ducimus suscipit enim dolor." },
                    { 330, 77, 38, 775910, new DateTime(2020, 11, 30, 22, 47, 14, 736, DateTimeKind.Local).AddTicks(9006), "Error nemo possimus deserunt aspernatur voluptatem inventore. Est non eius rem. Placeat distinctio commodi deleniti dolore. Voluptatem qui reprehenderit." },
                    { 564, 77, 10, 208219, new DateTime(2021, 1, 22, 5, 31, 45, 492, DateTimeKind.Local).AddTicks(6622), "perferendis" },
                    { 45, 49, 112, 626301, new DateTime(2021, 2, 2, 22, 56, 46, 248, DateTimeKind.Local).AddTicks(3133), "Dolores soluta vel id eos est. Nemo voluptas vel odio voluptas quis numquam natus enim quisquam. Architecto aut consectetur nihil cupiditate excepturi natus consequuntur." },
                    { 572, 58, 14, 388731, new DateTime(2020, 9, 14, 16, 52, 57, 8, DateTimeKind.Local).AddTicks(4424), "Ab quasi incidunt. Iste totam eos ipsam nisi rerum rem eum sit nostrum. Ut et dolorem dolore maxime dolores ab. Similique autem ducimus et distinctio labore recusandae aut ut in." },
                    { 139, 49, 79, 254034, new DateTime(2021, 6, 19, 21, 41, 57, 879, DateTimeKind.Local).AddTicks(8696), "dolorum" },
                    { 171, 49, 16, 792404, new DateTime(2021, 6, 9, 16, 55, 1, 992, DateTimeKind.Local).AddTicks(3151), "Quia minus ad et temporibus." },
                    { 234, 49, 80, 770304, new DateTime(2021, 1, 5, 20, 10, 13, 640, DateTimeKind.Local).AddTicks(8784), "Nisi quo vitae reprehenderit voluptates.\nRerum voluptas sapiente ratione a quod qui.\nSunt temporibus voluptas voluptas sequi.\nRepudiandae aperiam et nostrum quidem cupiditate." },
                    { 272, 49, 67, 411976, new DateTime(2021, 2, 19, 11, 43, 50, 242, DateTimeKind.Local).AddTicks(1696), "Beatae aut aliquam consequatur perferendis.\nEt at dolorem." },
                    { 275, 49, 109, 888232, new DateTime(2021, 8, 20, 19, 20, 9, 498, DateTimeKind.Local).AddTicks(1488), "Dolor laborum ipsum quos officiis. Tempore amet sit est voluptatem nam expedita hic commodi. Facere sunt placeat qui." },
                    { 37, 75, 66, 144491, new DateTime(2021, 2, 13, 20, 11, 33, 585, DateTimeKind.Local).AddTicks(4646), "voluptatem" },
                    { 47, 75, 45, 904778, new DateTime(2021, 2, 4, 11, 39, 46, 342, DateTimeKind.Local).AddTicks(1462), "Non corporis eum voluptas maiores eos fugiat hic ut." },
                    { 142, 75, 76, 94565, new DateTime(2021, 3, 13, 20, 53, 17, 931, DateTimeKind.Local).AddTicks(4004), "Odio quod et tempora et non maxime qui rerum. Nostrum sapiente fugit ab. Eligendi earum sequi animi est deserunt aliquam voluptas nostrum. Mollitia rerum est enim doloremque neque ratione. Ut vel consequatur." },
                    { 170, 49, 117, 223164, new DateTime(2021, 3, 17, 17, 39, 27, 463, DateTimeKind.Local).AddTicks(9889), "magnam" },
                    { 412, 58, 87, 375759, new DateTime(2020, 12, 20, 14, 45, 17, 794, DateTimeKind.Local).AddTicks(3206), "Est itaque sunt in qui neque ipsum iusto laudantium at. Ipsam dolorem ratione qui. Possimus qui rerum. Rerum omnis non id totam possimus doloremque est autem. Distinctio velit nesciunt ratione consequuntur et incidunt sit." },
                    { 353, 58, 59, 434258, new DateTime(2021, 7, 11, 5, 46, 4, 110, DateTimeKind.Local).AddTicks(391), "Molestiae maiores est voluptatibus ipsam ut ut nisi. Molestiae illo dolor corporis nihil eveniet nemo. Corporis numquam est. Aut nihil odit." },
                    { 335, 58, 27, 435013, new DateTime(2021, 5, 15, 21, 31, 44, 831, DateTimeKind.Local).AddTicks(5041), "Deserunt ratione tenetur est consequatur. Rerum quia vel fuga consectetur totam velit id totam. Laboriosam deleniti quisquam." },
                    { 175, 2, 91, 483058, new DateTime(2021, 2, 5, 15, 21, 26, 563, DateTimeKind.Local).AddTicks(4771), "Consequatur rerum natus tempore laudantium.\nOdit debitis ipsum optio hic et magni similique." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 190, 2, 148, 831683, new DateTime(2021, 3, 1, 4, 11, 59, 509, DateTimeKind.Local).AddTicks(2014), "Qui eveniet non non voluptates facere." },
                    { 229, 2, 50, 10242, new DateTime(2020, 12, 3, 11, 43, 35, 991, DateTimeKind.Local).AddTicks(1478), "Sunt dolorum rem dolorem fugiat tempore illum.\nIllo laborum exercitationem.\nQui blanditiis placeat est rem necessitatibus.\nAd non aliquid animi esse quisquam reprehenderit illo.\nQuisquam accusantium quidem fuga.\nSunt et et aliquam." },
                    { 596, 2, 18, 292296, new DateTime(2021, 8, 9, 8, 12, 9, 863, DateTimeKind.Local).AddTicks(6431), "Eos modi deleniti explicabo omnis quae." },
                    { 8, 24, 133, 119152, new DateTime(2021, 5, 31, 15, 27, 2, 382, DateTimeKind.Local).AddTicks(6190), "Est est modi nostrum qui." },
                    { 51, 24, 110, 571497, new DateTime(2020, 12, 26, 5, 41, 51, 971, DateTimeKind.Local).AddTicks(147), "eligendi" },
                    { 55, 24, 42, 363371, new DateTime(2021, 6, 25, 2, 45, 24, 411, DateTimeKind.Local).AddTicks(365), "blanditiis" },
                    { 129, 24, 61, 22455, new DateTime(2021, 8, 3, 7, 19, 8, 225, DateTimeKind.Local).AddTicks(820), "Quia atque totam aut.\nPorro sapiente est enim voluptatem aut.\nError in sed incidunt reprehenderit.\nInventore facilis nam tempora nisi sit rerum cumque quis impedit." },
                    { 160, 24, 69, 53022, new DateTime(2021, 5, 26, 17, 48, 37, 980, DateTimeKind.Local).AddTicks(3936), "Porro quis enim.\nNisi omnis quis tenetur magni sint.\nDeleniti quidem consequatur et quisquam excepturi aperiam error molestias cum." },
                    { 293, 24, 119, 353543, new DateTime(2021, 6, 2, 15, 46, 1, 442, DateTimeKind.Local).AddTicks(5580), "Laborum est at et possimus soluta ut ipsum voluptas.\nEx officia animi ullam sit voluptatum repellat." },
                    { 357, 24, 20, 355135, new DateTime(2021, 6, 10, 23, 23, 33, 425, DateTimeKind.Local).AddTicks(7046), "Eos adipisci rem est rerum rerum qui corrupti est.\nReprehenderit quas delectus sed ex excepturi architecto nihil eos.\nRem voluptatum qui expedita iste suscipit eum ea." },
                    { 359, 24, 110, 186839, new DateTime(2021, 2, 12, 8, 47, 49, 75, DateTimeKind.Local).AddTicks(785), "Unde dolores sequi saepe animi.\nOptio quia distinctio quibusdam illum numquam.\nIllo modi enim magnam unde quaerat architecto." },
                    { 436, 24, 80, 888245, new DateTime(2020, 9, 25, 20, 8, 27, 352, DateTimeKind.Local).AddTicks(1380), "Est sed iusto quas." },
                    { 71, 58, 40, 238024, new DateTime(2020, 9, 30, 16, 17, 12, 496, DateTimeKind.Local).AddTicks(4697), "Iste illum culpa iusto magnam asperiores molestias et est aperiam. Vel quo qui. Voluptatibus est odit quibusdam ea sed recusandae fugit. Fugiat earum repellendus tempora mollitia repellat enim." },
                    { 109, 58, 144, 170122, new DateTime(2021, 3, 7, 20, 55, 51, 728, DateTimeKind.Local).AddTicks(5320), "Et ipsam fuga doloribus.\nSit provident sunt iure quae eius velit.\nIllo pariatur voluptatibus porro aut.\nEa quo totam cumque." },
                    { 299, 58, 104, 466553, new DateTime(2020, 11, 7, 16, 26, 51, 666, DateTimeKind.Local).AddTicks(8975), "Incidunt maxime ut consequuntur accusamus excepturi non veniam.\nEt asperiores vel odio asperiores sed.\nId voluptas autem ducimus.\nCommodi fugit exercitationem." },
                    { 312, 58, 34, 118189, new DateTime(2021, 5, 9, 4, 53, 40, 353, DateTimeKind.Local).AddTicks(1721), "Et temporibus est officiis quos." },
                    { 198, 75, 35, 615074, new DateTime(2021, 1, 22, 14, 17, 19, 477, DateTimeKind.Local).AddTicks(1399), "et" },
                    { 349, 75, 30, 109629, new DateTime(2021, 1, 2, 7, 16, 34, 126, DateTimeKind.Local).AddTicks(3320), "autem" },
                    { 363, 75, 29, 820105, new DateTime(2020, 9, 26, 0, 46, 38, 751, DateTimeKind.Local).AddTicks(767), "Iusto quis qui nulla consequatur ut et. Nisi et ea. Aut voluptas ea quidem aut corrupti in minima. Nostrum quia debitis sapiente quidem inventore distinctio at. Non rerum expedita eaque ut. Consequatur blanditiis dolores." },
                    { 433, 75, 68, 279201, new DateTime(2021, 6, 20, 14, 51, 12, 614, DateTimeKind.Local).AddTicks(7947), "Laboriosam doloribus ea laboriosam." },
                    { 423, 32, 22, 497980, new DateTime(2021, 8, 21, 9, 22, 16, 315, DateTimeKind.Local).AddTicks(5023), "Enim ut quia voluptatem ipsam libero est. Libero aut consequuntur ut repudiandae tempore inventore tempore eum ut. Voluptas repudiandae minus magnam numquam. Velit quod molestiae vel inventore. Ex nostrum sit eum consequuntur pariatur." },
                    { 544, 32, 60, 461029, new DateTime(2020, 12, 17, 2, 39, 54, 724, DateTimeKind.Local).AddTicks(3965), "Numquam tenetur et consequatur ut voluptatem vitae." },
                    { 138, 48, 82, 731361, new DateTime(2021, 5, 2, 21, 17, 31, 725, DateTimeKind.Local).AddTicks(5139), "Consectetur sed minima est voluptatem sit soluta.\nExcepturi et iste.\nTempore enim culpa corporis corporis in.\nVoluptatem incidunt voluptatem eligendi.\nQuia cupiditate hic blanditiis omnis ullam." },
                    { 179, 48, 45, 276741, new DateTime(2020, 10, 19, 8, 52, 18, 477, DateTimeKind.Local).AddTicks(6853), "Iusto minima ab sapiente vitae illum molestiae vero.\nQui et voluptas.\nQuaerat est voluptatem consequatur fugit sequi sequi odio.\nQuisquam accusamus deleniti aspernatur est exercitationem placeat.\nVero voluptatem autem voluptatibus aliquid." },
                    { 487, 48, 136, 200468, new DateTime(2021, 2, 18, 10, 41, 52, 199, DateTimeKind.Local).AddTicks(8616), "necessitatibus" },
                    { 406, 62, 107, 923286, new DateTime(2021, 4, 4, 10, 34, 49, 666, DateTimeKind.Local).AddTicks(201), "Id repudiandae rerum impedit." },
                    { 56, 29, 4, 836555, new DateTime(2021, 3, 14, 14, 7, 17, 842, DateTimeKind.Local).AddTicks(1976), "Et accusantium maiores libero necessitatibus fugit architecto consequatur rerum. Voluptas sit pariatur. Autem odit a dignissimos voluptas. Pariatur impedit molestiae nostrum voluptas doloremque. Non eum similique ex fugiat architecto." },
                    { 96, 29, 119, 73037, new DateTime(2021, 5, 16, 17, 45, 52, 557, DateTimeKind.Local).AddTicks(6870), "Eos eligendi amet delectus blanditiis possimus aut aliquid adipisci. Qui repellat doloribus quia ea enim. Iure suscipit consectetur quo fugit molestias. Eum nihil consequatur alias id. Cumque aperiam ab libero molestiae enim facere similique labore quia. Sunt quaerat eligendi laudantium aut ipsam." },
                    { 135, 29, 104, 560788, new DateTime(2021, 3, 7, 4, 38, 50, 80, DateTimeKind.Local).AddTicks(4816), "Optio dicta repudiandae rem amet ea laboriosam tempore ut.\nQuidem et quia neque est dicta voluptate optio totam.\nMolestiae assumenda aliquid dicta hic temporibus officia magni laudantium." },
                    { 169, 29, 110, 901641, new DateTime(2020, 9, 5, 13, 43, 21, 228, DateTimeKind.Local).AddTicks(2415), "Fuga quaerat doloribus quae natus. Tempora rerum qui. Corrupti molestias ipsam rerum nemo molestias dolor sint velit. Maxime perspiciatis magni nihil rerum omnis." },
                    { 301, 29, 61, 971306, new DateTime(2021, 1, 8, 18, 0, 24, 542, DateTimeKind.Local).AddTicks(7786), "Aperiam voluptas ipsa non.\nSoluta ullam hic laborum accusamus." },
                    { 328, 29, 2, 444183, new DateTime(2021, 1, 24, 2, 27, 26, 587, DateTimeKind.Local).AddTicks(263), "Voluptatem praesentium sit temporibus provident maiores voluptatem beatae a impedit." },
                    { 343, 29, 123, 610725, new DateTime(2020, 8, 30, 20, 25, 3, 789, DateTimeKind.Local).AddTicks(7628), "Explicabo ut qui aut omnis. Quo veniam fugit omnis sint ut quas quia. At tempora aspernatur provident voluptatibus distinctio totam vel tempora reprehenderit. Distinctio cum in doloribus voluptas officiis ipsum quaerat. Fugit velit eos vel." },
                    { 388, 29, 77, 34373, new DateTime(2021, 7, 15, 1, 41, 3, 356, DateTimeKind.Local).AddTicks(9422), "Veritatis expedita qui explicabo. Assumenda autem voluptates hic sequi repellendus dolores quae natus voluptatibus. Tempore doloremque reiciendis sapiente voluptates sequi. Reprehenderit quam fuga ut ut fugit eaque reprehenderit recusandae nihil. Nihil ut ab. Minus ex asperiores aut." },
                    { 508, 29, 108, 701232, new DateTime(2020, 12, 15, 15, 12, 28, 726, DateTimeKind.Local).AddTicks(375), "Nihil repellendus enim ut esse vel molestias aut." },
                    { 73, 46, 93, 543070, new DateTime(2021, 3, 24, 11, 25, 37, 597, DateTimeKind.Local).AddTicks(4529), "Est consectetur voluptas molestiae unde blanditiis aut exercitationem sunt. Minus quo est ullam. Et aspernatur harum rerum quisquam voluptas." },
                    { 125, 46, 81, 465123, new DateTime(2021, 3, 25, 18, 1, 25, 586, DateTimeKind.Local).AddTicks(6010), "Ut veniam earum eligendi quisquam accusantium est velit voluptatem.\nEt libero molestiae asperiores velit quae.\nProvident provident sunt magnam cupiditate deserunt." },
                    { 350, 32, 33, 3250, new DateTime(2020, 11, 2, 9, 45, 36, 207, DateTimeKind.Local).AddTicks(9160), "Eos ut et dolorem. Corrupti voluptatem maxime aliquam aut aut vero eius iste est. Dolorum nemo et aut nihil officiis consequatur non commodi. Et et nihil nihil fugiat. Nisi enim illo et vel maxime accusantium cumque explicabo molestiae. Deleniti doloremque quia non." },
                    { 504, 66, 53, 656032, new DateTime(2021, 6, 23, 6, 29, 6, 607, DateTimeKind.Local).AddTicks(6258), "Delectus fuga dolor expedita distinctio." },
                    { 320, 32, 115, 270663, new DateTime(2021, 7, 20, 16, 20, 30, 38, DateTimeKind.Local).AddTicks(8419), "Explicabo in ex rerum fugiat." },
                    { 84, 32, 96, 851311, new DateTime(2021, 4, 8, 1, 47, 8, 266, DateTimeKind.Local).AddTicks(7080), "Non unde rerum eius.\nIllo non asperiores soluta.\nAutem ipsa dolorum ad maiores possimus corporis eos dicta non." },
                    { 510, 75, 147, 578484, new DateTime(2021, 2, 7, 7, 6, 19, 555, DateTimeKind.Local).AddTicks(4865), "Similique nam itaque.\nAut qui natus.\nId sit ad laudantium dignissimos voluptatem occaecati.\nEt facilis et dolor quas dolores.\nDelectus quasi deleniti aut et.\nVero ea velit ducimus et sequi porro earum dignissimos id." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 3, 19, 142, 700799, new DateTime(2021, 1, 19, 5, 5, 45, 93, DateTimeKind.Local).AddTicks(1274), "Esse officia voluptas. Tempora repellat voluptatem dolor. Culpa rerum architecto dolores. Dolorem doloribus officiis." },
                    { 25, 19, 109, 658907, new DateTime(2020, 10, 24, 0, 50, 44, 50, DateTimeKind.Local).AddTicks(5965), "quia" },
                    { 29, 19, 53, 219049, new DateTime(2020, 9, 13, 14, 20, 16, 754, DateTimeKind.Local).AddTicks(9463), "Ducimus sunt mollitia necessitatibus dolor aliquid.\nAut ex eum quia quia omnis perspiciatis.\nVoluptatibus ullam qui dolores.\nEt tempore voluptas quidem at non nihil reprehenderit.\nError ea aperiam omnis ratione temporibus eaque velit.\nQuia optio quae iusto sit iusto." },
                    { 155, 19, 125, 478620, new DateTime(2020, 11, 8, 10, 18, 24, 784, DateTimeKind.Local).AddTicks(1731), "Molestiae consequatur natus rerum minima eius quo esse numquam sapiente.\nConsequatur harum aut porro sint est asperiores hic laborum.\nFacilis modi deserunt.\nSed consequatur possimus est mollitia." },
                    { 226, 19, 147, 390676, new DateTime(2021, 4, 18, 21, 7, 53, 703, DateTimeKind.Local).AddTicks(9658), "Culpa ad eius sequi et qui qui quae autem consequatur." },
                    { 247, 19, 146, 837150, new DateTime(2021, 6, 23, 10, 23, 48, 108, DateTimeKind.Local).AddTicks(8002), "Esse est minus quibusdam nulla.\nVoluptas illo quas.\nEt rerum sequi in assumenda qui aut nulla earum quos." },
                    { 264, 19, 54, 448328, new DateTime(2021, 2, 12, 6, 20, 31, 920, DateTimeKind.Local).AddTicks(9262), "Ut laudantium debitis sed sit et.\nOmnis et et quis.\nVoluptatem sint sapiente ut eligendi fugiat neque quod." },
                    { 338, 19, 130, 980028, new DateTime(2021, 1, 1, 2, 9, 5, 415, DateTimeKind.Local).AddTicks(8808), "Consequatur sit aut odit eaque atque.\nDolorum sequi ea dolore ducimus mollitia ut illo iusto iure.\nQuam dolorem et eligendi aut libero velit deleniti et aliquam.\nAdipisci qui non quasi voluptas cupiditate perspiciatis aliquid est.\nAut ut dicta eveniet nisi incidunt deleniti earum laboriosam." },
                    { 481, 19, 77, 768966, new DateTime(2021, 4, 11, 23, 43, 3, 118, DateTimeKind.Local).AddTicks(5354), "dolore" },
                    { 594, 19, 84, 633656, new DateTime(2021, 1, 15, 9, 32, 34, 82, DateTimeKind.Local).AddTicks(5210), "Aperiam nihil possimus voluptatum minus dolore.\nSed voluptas ut maxime doloremque ipsam et culpa distinctio.\nRepellendus id qui voluptatum.\nPerferendis omnis id iusto.\nUt voluptas est vel tempora.\nQuae molestiae excepturi voluptate enim commodi." },
                    { 598, 19, 70, 759675, new DateTime(2020, 11, 24, 1, 52, 9, 830, DateTimeKind.Local).AddTicks(2643), "nam" },
                    { 21, 31, 78, 511857, new DateTime(2020, 12, 5, 0, 4, 17, 534, DateTimeKind.Local).AddTicks(3784), "Explicabo et eius maiores voluptatum et sed maiores aut.\nVoluptatem et quia ipsum molestiae et sit.\nAd laborum velit laboriosam beatae voluptatem.\nRerum rem est aut qui sit enim officia aut.\nIusto dignissimos ea unde aut." },
                    { 134, 31, 39, 740801, new DateTime(2020, 9, 26, 2, 7, 46, 238, DateTimeKind.Local).AddTicks(4033), "veniam" },
                    { 245, 31, 16, 928749, new DateTime(2021, 1, 11, 9, 49, 45, 854, DateTimeKind.Local).AddTicks(1469), "Possimus et eos." },
                    { 273, 31, 123, 798274, new DateTime(2021, 8, 18, 16, 47, 4, 363, DateTimeKind.Local).AddTicks(4012), "Nobis assumenda est ipsum totam minus veniam sed. Voluptatem sed itaque sint sunt enim qui. Aliquam veritatis ipsam sint autem velit. Alias nisi in est praesentium ab nostrum quae. Ut atque at sapiente." },
                    { 425, 31, 67, 425219, new DateTime(2021, 1, 23, 18, 28, 29, 270, DateTimeKind.Local).AddTicks(1803), "Dignissimos ullam illum dolor dolores ea nostrum quo at aut." },
                    { 99, 32, 62, 510998, new DateTime(2020, 11, 19, 20, 34, 2, 784, DateTimeKind.Local).AddTicks(7240), "Sed deleniti delectus id.\nOptio nemo quis nisi odit voluptas a consequatur quo.\nCommodi autem aut voluptatem vel." },
                    { 15, 82, 35, 834389, new DateTime(2020, 12, 1, 0, 9, 16, 248, DateTimeKind.Local).AddTicks(7555), "Cupiditate quae molestias voluptatem fugit minima." },
                    { 214, 79, 23, 303921, new DateTime(2020, 9, 13, 12, 51, 43, 574, DateTimeKind.Local).AddTicks(239), "Beatae similique sed optio nihil dolore adipisci consequatur eaque.\nQuasi natus voluptatem molestiae dignissimos ea quisquam.\nVoluptas dolorem aspernatur fugit eaque voluptatem.\nPerferendis sed et maiores nam.\nVoluptatibus rem corrupti.\nOdit iusto id repudiandae." },
                    { 401, 1, 43, 372729, new DateTime(2021, 1, 25, 19, 56, 3, 439, DateTimeKind.Local).AddTicks(5202), "Consectetur fuga qui voluptatum tempora vitae aliquid esse temporibus.\nEarum porro aut adipisci dolorem voluptatibus.\nMinus modi reiciendis facilis." },
                    { 83, 57, 73, 131031, new DateTime(2021, 5, 7, 19, 37, 37, 148, DateTimeKind.Local).AddTicks(3509), "Qui sequi ea autem dolor enim eius ab." },
                    { 583, 84, 92, 444380, new DateTime(2021, 5, 29, 5, 58, 34, 629, DateTimeKind.Local).AddTicks(5283), "et" },
                    { 468, 84, 8, 46776, new DateTime(2021, 1, 18, 12, 25, 42, 909, DateTimeKind.Local).AddTicks(8409), "distinctio" },
                    { 457, 84, 78, 724701, new DateTime(2021, 4, 1, 16, 4, 33, 566, DateTimeKind.Local).AddTicks(1447), "Soluta voluptate est non voluptatem porro omnis labore. Est consequuntur vel iusto ea reiciendis et voluptas aut earum. Voluptas sunt magni nihil. Repellendus nostrum sunt ullam quis cupiditate maiores dolores sunt aliquid." },
                    { 347, 4, 27, 997827, new DateTime(2020, 11, 20, 5, 22, 47, 263, DateTimeKind.Local).AddTicks(3314), "ea" },
                    { 98, 57, 143, 113701, new DateTime(2021, 6, 30, 4, 36, 32, 880, DateTimeKind.Local).AddTicks(9992), "Possimus officiis quo aliquid aut quisquam dolorem quis magni sed. Doloremque quia consectetur et molestiae beatae qui harum exercitationem ut. Dolores earum voluptas cupiditate nemo fugiat aut aut." },
                    { 452, 84, 46, 612569, new DateTime(2021, 3, 2, 18, 39, 34, 550, DateTimeKind.Local).AddTicks(1366), "Reiciendis ex accusamus ut perferendis.\nSoluta officiis repellendus omnis expedita beatae officia.\nMinima est delectus aperiam eligendi necessitatibus praesentium illum." },
                    { 348, 4, 10, 360993, new DateTime(2021, 3, 19, 7, 27, 29, 905, DateTimeKind.Local).AddTicks(259), "Consequatur commodi in iste quibusdam.\nEarum odit est rem et inventore consectetur non aut sunt.\nIpsam consequatur error nihil quos debitis iste vel perspiciatis doloremque.\nDolore et repudiandae at ullam similique ut amet sed ipsum." },
                    { 404, 4, 65, 503117, new DateTime(2021, 2, 23, 1, 28, 33, 969, DateTimeKind.Local).AddTicks(2601), "In omnis ipsam repellat aut est consequatur." },
                    { 322, 84, 88, 417290, new DateTime(2021, 6, 19, 5, 49, 14, 112, DateTimeKind.Local).AddTicks(4298), "ut" },
                    { 281, 72, 48, 428589, new DateTime(2020, 9, 17, 4, 8, 38, 483, DateTimeKind.Local).AddTicks(3998), "Consequatur harum molestiae ut voluptatem." },
                    { 562, 1, 87, 336824, new DateTime(2020, 10, 7, 5, 59, 21, 545, DateTimeKind.Local).AddTicks(3873), "aut" },
                    { 451, 1, 138, 947254, new DateTime(2020, 11, 15, 4, 42, 6, 959, DateTimeKind.Local).AddTicks(1772), "Vero nemo et.\nNatus sit amet suscipit veniam accusamus voluptatem officiis praesentium itaque.\nError eveniet laboriosam aut est totam.\nDoloremque eos repudiandae non.\nUllam officiis totam vel et itaque sequi ut." },
                    { 90, 35, 134, 958839, new DateTime(2020, 9, 11, 10, 2, 20, 747, DateTimeKind.Local).AddTicks(3353), "Harum quo laborum praesentium quisquam in ut architecto sunt.\nMinus maiores quis vero quod voluptate enim accusamus ipsa quam.\nVoluptatem qui vitae." },
                    { 434, 1, 134, 936518, new DateTime(2020, 10, 23, 21, 43, 19, 815, DateTimeKind.Local).AddTicks(2337), "Odio sed qui." },
                    { 262, 84, 105, 406331, new DateTime(2021, 5, 5, 2, 0, 46, 131, DateTimeKind.Local).AddTicks(3977), "labore" },
                    { 259, 84, 30, 136299, new DateTime(2020, 10, 15, 22, 15, 56, 918, DateTimeKind.Local).AddTicks(5595), "est" },
                    { 195, 84, 135, 674716, new DateTime(2021, 3, 26, 6, 19, 52, 103, DateTimeKind.Local).AddTicks(5535), "vitae" },
                    { 193, 84, 144, 509645, new DateTime(2021, 7, 30, 3, 54, 2, 959, DateTimeKind.Local).AddTicks(5801), "numquam" },
                    { 80, 84, 129, 909463, new DateTime(2021, 1, 12, 2, 26, 10, 382, DateTimeKind.Local).AddTicks(5513), "In mollitia amet accusamus vero unde culpa alias consequatur ex. Mollitia omnis esse facere tenetur ducimus ducimus velit. Aperiam omnis deserunt libero sit id. Accusantium suscipit eveniet sit aperiam velit veritatis quae enim. Ipsa qui architecto." },
                    { 35, 84, 26, 189827, new DateTime(2021, 7, 24, 7, 53, 44, 495, DateTimeKind.Local).AddTicks(9585), "Ratione officiis doloremque officia et cupiditate voluptatum dolores. Ad distinctio qui aperiam perferendis eos suscipit ipsa. Eos in deserunt eum laboriosam. Facere non in animi blanditiis minima quam quis reprehenderit voluptatem. Doloremque ipsa est nemo doloremque ratione repellat sit tenetur." },
                    { 113, 35, 122, 628358, new DateTime(2021, 8, 18, 8, 36, 22, 346, DateTimeKind.Local).AddTicks(9201), "omnis" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 476, 45, 87, 569356, new DateTime(2021, 2, 17, 22, 49, 20, 438, DateTimeKind.Local).AddTicks(9697), "Quae veniam eos in eveniet nulla iure. Culpa autem consequatur aperiam. Blanditiis sit non quibusdam eos soluta. Velit corrupti doloribus. Laboriosam culpa placeat quia qui ullam autem facilis provident. Quasi rerum officiis tenetur nisi." },
                    { 566, 1, 27, 723792, new DateTime(2021, 1, 21, 21, 16, 39, 235, DateTimeKind.Local).AddTicks(5617), "nostrum" },
                    { 438, 45, 110, 519245, new DateTime(2021, 2, 18, 4, 17, 23, 971, DateTimeKind.Local).AddTicks(4056), "Doloremque possimus nesciunt delectus est corrupti repellendus sed.\nId rerum et et voluptas ut et." },
                    { 36, 57, 9, 165160, new DateTime(2021, 3, 18, 15, 11, 7, 694, DateTimeKind.Local).AddTicks(4492), "pariatur" },
                    { 219, 4, 141, 396697, new DateTime(2021, 3, 1, 8, 8, 20, 141, DateTimeKind.Local).AddTicks(8313), "Atque aliquam voluptatem animi fuga expedita ipsam delectus. Facere provident perferendis quia perspiciatis asperiores ex dolor. Maxime fugiat saepe dolor. Eum asperiores sequi numquam repudiandae voluptas tenetur qui sint. Beatae repellat rerum quibusdam enim et molestiae aut. Alias ut dolore delectus adipisci doloremque et architecto." },
                    { 471, 72, 14, 982538, new DateTime(2021, 2, 10, 18, 8, 9, 628, DateTimeKind.Local).AddTicks(314), "Ea beatae aliquid autem voluptatum rerum ut harum ipsa.\nPossimus cumque cupiditate ipsam perferendis.\nUt labore sed.\nAut incidunt et repellendus qui accusantium delectus harum rerum.\nVoluptatem deserunt rem ad id culpa.\nAliquam praesentium neque corrupti vel." },
                    { 552, 72, 97, 776993, new DateTime(2021, 8, 1, 23, 10, 51, 792, DateTimeKind.Local).AddTicks(3638), "Veniam molestiae dignissimos voluptatem nihil.\nEt nostrum quasi et aut.\nDeserunt veniam nemo.\nQui doloremque placeat occaecati dolorem non perspiciatis et cum.\nQui minima perferendis repellendus et sequi." },
                    { 97, 82, 129, 929848, new DateTime(2021, 8, 18, 17, 27, 21, 717, DateTimeKind.Local).AddTicks(5217), "Voluptatibus voluptatem sit molestiae eos doloremque facere aut. Incidunt voluptas unde rerum voluptatem adipisci explicabo. Et voluptatem non aut voluptatem vero vel. Voluptatem aut est non quam dolorem voluptas rem commodi. Ut consequuntur dolorem molestiae quia quis veniam a." },
                    { 174, 40, 5, 94435, new DateTime(2020, 9, 28, 9, 24, 44, 56, DateTimeKind.Local).AddTicks(7265), "Quas facere repudiandae." },
                    { 600, 76, 15, 910732, new DateTime(2021, 2, 11, 18, 25, 59, 442, DateTimeKind.Local).AddTicks(4095), "voluptatem" },
                    { 199, 40, 25, 68323, new DateTime(2020, 11, 22, 1, 5, 23, 714, DateTimeKind.Local).AddTicks(8477), "Fugiat quidem est ut ipsum impedit ipsa nobis nesciunt.\nNihil et possimus laudantium qui voluptatem dolor quis.\nQuasi voluptatem id et.\nEt quia tempora nostrum eum blanditiis.\nLaboriosam eum necessitatibus sunt quas id.\nTotam consequatur ducimus corporis voluptas sapiente." },
                    { 563, 76, 26, 756770, new DateTime(2021, 3, 18, 20, 27, 23, 491, DateTimeKind.Local).AddTicks(6888), "cum" },
                    { 517, 76, 127, 282314, new DateTime(2021, 5, 18, 22, 16, 11, 436, DateTimeKind.Local).AddTicks(3948), "Et voluptates omnis commodi eveniet et culpa cumque. Eos architecto veritatis. Veritatis et est perferendis voluptatibus tempore reiciendis fuga voluptatem." },
                    { 389, 76, 40, 822084, new DateTime(2021, 8, 24, 1, 14, 18, 61, DateTimeKind.Local).AddTicks(918), "Et amet aliquid." },
                    { 383, 76, 19, 311150, new DateTime(2021, 5, 9, 15, 43, 18, 105, DateTimeKind.Local).AddTicks(2162), "Sint voluptas ipsa impedit.\nEt omnis illum eum.\nEst explicabo eos praesentium." },
                    { 210, 40, 148, 303750, new DateTime(2021, 5, 20, 8, 3, 47, 361, DateTimeKind.Local).AddTicks(7119), "rerum" },
                    { 339, 1, 46, 674060, new DateTime(2021, 1, 24, 18, 22, 51, 306, DateTimeKind.Local).AddTicks(9758), "earum" },
                    { 232, 40, 47, 159868, new DateTime(2020, 9, 12, 11, 3, 35, 95, DateTimeKind.Local).AddTicks(3317), "Id nobis magnam reiciendis libero. Et odio natus veniam laborum dignissimos. Eum mollitia hic." },
                    { 274, 40, 29, 323739, new DateTime(2021, 4, 1, 18, 24, 41, 879, DateTimeKind.Local).AddTicks(1614), "Vel porro recusandae magnam quia enim dolores amet.\nIure id enim ea dicta dolorem consequuntur nesciunt.\nArchitecto non doloremque sequi assumenda similique sunt blanditiis.\nEum blanditiis quisquam dolores.\nQui porro dolorem veniam." },
                    { 297, 40, 113, 602076, new DateTime(2021, 6, 16, 6, 2, 0, 49, DateTimeKind.Local).AddTicks(9612), "voluptatem" },
                    { 376, 40, 13, 422248, new DateTime(2020, 11, 16, 12, 11, 16, 1, DateTimeKind.Local).AddTicks(7581), "Ullam ea perferendis repellendus laboriosam in. Numquam rerum sunt aut sunt. Soluta dolor dolorem cum possimus sint ad. Maxime cum vero sunt eligendi laborum ab minima." },
                    { 386, 40, 145, 443446, new DateTime(2020, 12, 24, 14, 47, 40, 982, DateTimeKind.Local).AddTicks(113), "Dignissimos possimus porro quas dicta est et qui dolorum." },
                    { 313, 76, 132, 929350, new DateTime(2021, 2, 13, 12, 6, 46, 956, DateTimeKind.Local).AddTicks(5547), "aliquid" },
                    { 252, 76, 45, 968734, new DateTime(2021, 2, 27, 2, 6, 10, 16, DateTimeKind.Local).AddTicks(2197), "error" },
                    { 111, 76, 32, 458539, new DateTime(2021, 5, 1, 7, 6, 52, 957, DateTimeKind.Local).AddTicks(6967), "Magni et amet qui autem dolorem.\nDicta quae totam incidunt repudiandae autem nisi delectus nemo quam.\nEnim blanditiis et.\nQui delectus et reprehenderit.\nEt quo doloremque eaque optio." },
                    { 88, 76, 98, 302155, new DateTime(2021, 2, 14, 5, 12, 48, 321, DateTimeKind.Local).AddTicks(6098), "Iusto distinctio tempora magni dignissimos labore assumenda dolor non. Voluptas odit magni sit porro est aliquid numquam. Sit ut ut ea vel voluptatum repellendus. Dolorum molestias recusandae quod excepturi et at dolorem inventore. Hic placeat veritatis qui quasi modi et. Dolores repellat esse necessitatibus ipsam quos commodi ut porro sed." },
                    { 87, 76, 87, 89819, new DateTime(2021, 1, 18, 15, 15, 18, 393, DateTimeKind.Local).AddTicks(8194), "mollitia" },
                    { 82, 76, 93, 959495, new DateTime(2021, 4, 17, 15, 16, 24, 390, DateTimeKind.Local).AddTicks(6540), "Minus omnis libero rem quia.\nAmet optio quis atque fugiat voluptate eos suscipit.\nQuia voluptas minus ullam quidem rerum animi et sit.\nMolestiae perspiciatis aliquam ratione nihil ut animi ex sit.\nQuasi et laudantium est cum." },
                    { 325, 4, 85, 761112, new DateTime(2021, 6, 6, 23, 53, 34, 13, DateTimeKind.Local).AddTicks(7063), "Et rerum eos nisi possimus quaerat." },
                    { 390, 45, 71, 44463, new DateTime(2021, 7, 8, 23, 44, 43, 121, DateTimeKind.Local).AddTicks(1433), "Tempore voluptatem provident. Quibusdam repudiandae omnis pariatur architecto hic dolores. Aliquid et ullam. Delectus recusandae aperiam at quasi et commodi. Ipsam non nobis vel. In eum sint." },
                    { 444, 4, 114, 775085, new DateTime(2021, 3, 11, 11, 33, 29, 40, DateTimeKind.Local).AddTicks(5431), "Dolorem sed eos ipsa aperiam nisi voluptas quidem similique odit.\nSuscipit fugit assumenda et a cum dolores perferendis.\nSunt ut optio praesentium iure dicta error porro ratione." },
                    { 408, 82, 117, 462190, new DateTime(2021, 5, 22, 11, 31, 24, 927, DateTimeKind.Local).AddTicks(8346), "Est unde tempore error voluptas.\nEt veniam quo dolorem fugiat dolorum.\nUt molestiae assumenda.\nVitae quae et velit." },
                    { 173, 45, 111, 118290, new DateTime(2021, 2, 16, 12, 28, 9, 938, DateTimeKind.Local).AddTicks(8090), "nisi" },
                    { 308, 45, 148, 609498, new DateTime(2020, 12, 4, 13, 40, 40, 154, DateTimeKind.Local).AddTicks(5172), "dolorem" },
                    { 352, 45, 107, 282282, new DateTime(2020, 9, 2, 4, 43, 28, 476, DateTimeKind.Local).AddTicks(7462), "eum" },
                    { 367, 45, 19, 675969, new DateTime(2021, 4, 6, 12, 1, 36, 372, DateTimeKind.Local).AddTicks(563), "Possimus omnis tempora totam nulla ut tenetur.\nQuasi temporibus molestiae autem excepturi quisquam eum fugiat adipisci.\nAperiam quo tenetur ut.\nSoluta animi illum.\nFacere magnam asperiores repellendus natus laudantium." },
                    { 498, 82, 19, 387959, new DateTime(2021, 8, 21, 6, 35, 38, 499, DateTimeKind.Local).AddTicks(3486), "qui" },
                    { 58, 1, 143, 124905, new DateTime(2021, 3, 6, 22, 40, 9, 998, DateTimeKind.Local).AddTicks(2475), "Fugit molestiae corrupti." },
                    { 112, 1, 108, 888818, new DateTime(2021, 5, 12, 12, 48, 32, 670, DateTimeKind.Local).AddTicks(2444), "Perferendis error laborum molestiae cumque velit eaque. Et aut voluptatem voluptas aut commodi ad omnis voluptatibus. Eius possimus in sint veniam autem sit molestiae. Officia sint quos facere occaecati ab dignissimos." },
                    { 132, 1, 90, 961865, new DateTime(2021, 1, 16, 8, 55, 32, 924, DateTimeKind.Local).AddTicks(2830), "adipisci" },
                    { 41, 45, 45, 480145, new DateTime(2021, 6, 27, 13, 39, 17, 98, DateTimeKind.Local).AddTicks(9465), "Provident vero cupiditate qui dolores aliquam eos voluptas.\nDelectus dolorem nisi rerum dolores totam.\nCorporis vero quis impedit qui quia dolore iure eligendi.\nLaboriosam voluptatem distinctio et maiores pariatur." },
                    { 77, 55, 101, 327063, new DateTime(2021, 7, 17, 13, 6, 19, 724, DateTimeKind.Local).AddTicks(8585), "Itaque consequatur illum autem.\nOfficiis inventore et recusandae enim quaerat." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 300, 55, 64, 981022, new DateTime(2021, 7, 3, 16, 40, 21, 708, DateTimeKind.Local).AddTicks(7446), "Quia ea eligendi cum delectus vero quia fuga est." },
                    { 380, 55, 85, 757503, new DateTime(2021, 2, 10, 0, 53, 18, 535, DateTimeKind.Local).AddTicks(2216), "Et nostrum iure quia nihil enim voluptates aut nihil. Hic officia id sapiente quos ea ea dolor ad. Recusandae dolores animi illum rerum explicabo ea. Et tempore ut ipsum officiis optio iste. Nulla aperiam voluptates molestiae veritatis fugit sed quis." },
                    { 378, 45, 52, 197061, new DateTime(2020, 9, 30, 3, 28, 39, 250, DateTimeKind.Local).AddTicks(7014), "Culpa unde voluptatum asperiores ut ea sit adipisci ut dicta." },
                    { 355, 82, 115, 301055, new DateTime(2021, 5, 15, 10, 26, 27, 0, DateTimeKind.Local).AddTicks(8939), "Est eum quo soluta itaque." },
                    { 61, 55, 40, 891988, new DateTime(2021, 8, 17, 23, 13, 31, 680, DateTimeKind.Local).AddTicks(3302), "Quibusdam illum id et ipsum.\nVoluptate laudantium soluta eum.\nSequi animi minus eaque praesentium eaque est vel labore quae." },
                    { 543, 82, 14, 334194, new DateTime(2021, 1, 25, 7, 26, 12, 293, DateTimeKind.Local).AddTicks(3406), "Ea repudiandae excepturi est nesciunt." },
                    { 202, 1, 74, 450225, new DateTime(2021, 4, 3, 15, 41, 52, 138, DateTimeKind.Local).AddTicks(8189), "doloremque" },
                    { 28, 85, 114, 631837, new DateTime(2021, 3, 31, 1, 12, 12, 845, DateTimeKind.Local).AddTicks(4732), "Et dignissimos perspiciatis ad minima quae accusantium quibusdam qui sit. Et nisi sint sed nam. Ut ut consequuntur consequatur sit ullam ab. Velit quis voluptatem neque perspiciatis ut saepe." },
                    { 290, 82, 42, 403435, new DateTime(2020, 11, 6, 16, 31, 56, 556, DateTimeKind.Local).AddTicks(3239), "Laboriosam error ea debitis." },
                    { 263, 1, 71, 646662, new DateTime(2020, 9, 2, 1, 59, 21, 281, DateTimeKind.Local).AddTicks(9382), "Placeat asperiores officiis cum repudiandae quia." },
                    { 584, 82, 135, 535307, new DateTime(2021, 7, 7, 19, 52, 5, 235, DateTimeKind.Local).AddTicks(2691), "Quia vero officiis repellendus error voluptates similique sit." },
                    { 12, 45, 105, 689813, new DateTime(2020, 11, 30, 9, 8, 27, 700, DateTimeKind.Local).AddTicks(1541), "est" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 78, new DateTime(2021, 3, 17, 10, 46, 3, 760, DateTimeKind.Local).AddTicks(5445), 70, 97, new DateTime(2021, 9, 13, 21, 49, 8, 362, DateTimeKind.Local).AddTicks(7171), new DateTime(2021, 7, 15, 9, 16, 5, 638, DateTimeKind.Local).AddTicks(3456), 1, null, null, "Quidem dolores rerum voluptatum et et.\nEum quod totam itaque nihil reprehenderit vel qui non.", 80 },
                    { 115, new DateTime(2021, 3, 20, 4, 28, 40, 792, DateTimeKind.Local).AddTicks(2653), 70, 59, new DateTime(2021, 9, 15, 1, 21, 23, 265, DateTimeKind.Local).AddTicks(2869), new DateTime(2021, 7, 28, 17, 40, 29, 358, DateTimeKind.Local).AddTicks(3790), 5, null, null, "Quibusdam odio quas maxime ab atque fugiat nobis.\nIure officia earum molestiae.\nVoluptas odit nihil voluptate sed maiores debitis optio.\nEt in ut.\nIure rerum quis.", 162 },
                    { 24, new DateTime(2021, 4, 3, 5, 4, 20, 395, DateTimeKind.Local).AddTicks(7737), 59, 92, new DateTime(2022, 8, 18, 5, 48, 38, 893, DateTimeKind.Local).AddTicks(7706), new DateTime(2021, 4, 4, 23, 14, 41, 715, DateTimeKind.Local).AddTicks(1883), 5, null, null, "doloribus", 272 },
                    { 84, new DateTime(2020, 10, 31, 22, 16, 20, 767, DateTimeKind.Local).AddTicks(1944), 35, 42, new DateTime(2021, 9, 13, 8, 15, 32, 759, DateTimeKind.Local).AddTicks(6163), new DateTime(2020, 12, 20, 1, 0, 38, 45, DateTimeKind.Local).AddTicks(5395), 1, null, null, "Ipsum voluptatem quo non nam eius ullam quae neque. Quia alias possimus. Unde fugit sunt. Et asperiores at rerum neque impedit quia atque aut. Veniam necessitatibus id fuga dolorum odit.", 133 },
                    { 64, new DateTime(2021, 2, 10, 6, 24, 36, 678, DateTimeKind.Local).AddTicks(8675), 70, 3, new DateTime(2022, 8, 12, 0, 14, 56, 34, DateTimeKind.Local).AddTicks(4946), new DateTime(2020, 11, 28, 10, 12, 55, 731, DateTimeKind.Local).AddTicks(4277), 4, null, null, "Labore et velit minus quae molestiae rem.\nIn atque sequi impedit laborum dolor qui enim.\nQuibusdam cupiditate assumenda id commodi corporis.\nSit cumque quasi iure.", 91 },
                    { 94, new DateTime(2021, 5, 27, 17, 19, 53, 447, DateTimeKind.Local).AddTicks(7579), 62, 27, new DateTime(2022, 6, 14, 8, 33, 4, 719, DateTimeKind.Local).AddTicks(9386), new DateTime(2020, 9, 11, 3, 26, 19, 452, DateTimeKind.Local).AddTicks(7110), 4, null, null, "Dolor eaque est quam. Porro molestiae dolores quaerat similique. Sed iure voluptate maxime veritatis ut quia rerum assumenda. Corporis minima at et dolor ut alias voluptas pariatur. Rem nam nemo enim.", 169 },
                    { 74, new DateTime(2021, 4, 21, 14, 5, 0, 444, DateTimeKind.Local).AddTicks(8461), 62, 96, new DateTime(2022, 8, 2, 9, 26, 55, 275, DateTimeKind.Local).AddTicks(3953), new DateTime(2021, 1, 24, 11, 46, 21, 591, DateTimeKind.Local).AddTicks(1131), 3, null, null, "omnis", 23 },
                    { 13, new DateTime(2021, 2, 11, 17, 0, 52, 446, DateTimeKind.Local).AddTicks(7859), 62, 43, new DateTime(2022, 8, 14, 10, 44, 54, 647, DateTimeKind.Local).AddTicks(4680), new DateTime(2020, 9, 4, 21, 2, 6, 965, DateTimeKind.Local).AddTicks(3474), 2, null, null, "aut", 249 },
                    { 33, new DateTime(2021, 5, 20, 3, 2, 8, 884, DateTimeKind.Local).AddTicks(8242), 8, 42, new DateTime(2022, 5, 21, 4, 46, 50, 553, DateTimeKind.Local).AddTicks(7561), new DateTime(2020, 11, 16, 20, 35, 42, 350, DateTimeKind.Local).AddTicks(8746), 5, null, null, "Est qui consequatur molestiae. Quidem excepturi beatae cum adipisci alias similique ipsum. Repellendus odit aut.", 187 },
                    { 56, new DateTime(2021, 3, 1, 11, 39, 20, 667, DateTimeKind.Local).AddTicks(6380), 8, 61, new DateTime(2022, 6, 4, 8, 42, 3, 403, DateTimeKind.Local).AddTicks(4673), new DateTime(2021, 1, 21, 22, 28, 0, 908, DateTimeKind.Local).AddTicks(924), 2, null, null, "Ducimus doloribus aut eos in nihil error id doloremque.\nEum quaerat eos in dignissimos voluptatum.\nOptio nemo voluptatem facilis quaerat non.\nEarum est accusantium dolor totam veritatis.\nAutem vitae ipsam blanditiis cupiditate quasi accusantium voluptatem laborum numquam.", 249 },
                    { 145, new DateTime(2020, 12, 26, 15, 5, 15, 426, DateTimeKind.Local).AddTicks(1689), 58, 8, new DateTime(2022, 3, 24, 12, 25, 45, 884, DateTimeKind.Local).AddTicks(1894), new DateTime(2020, 9, 20, 20, 57, 7, 739, DateTimeKind.Local).AddTicks(7096), 4, null, null, "Esse asperiores quia est expedita.\nIpsum excepturi qui non voluptatem.\nEum delectus id.\nMolestias molestiae perspiciatis incidunt quasi omnis blanditiis quia.\nNemo quae quo provident cum omnis rem.", 39 },
                    { 149, new DateTime(2020, 11, 18, 6, 26, 32, 761, DateTimeKind.Local).AddTicks(9266), 40, 126, new DateTime(2021, 12, 12, 14, 44, 51, 655, DateTimeKind.Local).AddTicks(3738), new DateTime(2020, 10, 10, 18, 7, 52, 955, DateTimeKind.Local).AddTicks(6711), 2, null, null, "Nisi rerum in.\nSaepe debitis quaerat sunt velit quia quae eos.\nVel at officiis labore animi quae quod harum.\nItaque et voluptatibus possimus officiis non ab.\nConsequatur omnis molestias laudantium doloribus repudiandae et.", 104 },
                    { 187, new DateTime(2021, 8, 26, 2, 41, 55, 365, DateTimeKind.Local).AddTicks(8646), 58, 134, new DateTime(2022, 6, 17, 15, 25, 38, 438, DateTimeKind.Local).AddTicks(8074), new DateTime(2021, 2, 8, 5, 50, 38, 812, DateTimeKind.Local).AddTicks(7213), 3, null, null, "Iure deleniti illum id numquam magnam eius.", 291 },
                    { 107, new DateTime(2021, 1, 23, 7, 46, 39, 419, DateTimeKind.Local).AddTicks(5307), 21, 27, new DateTime(2022, 5, 12, 1, 24, 17, 870, DateTimeKind.Local).AddTicks(5344), new DateTime(2021, 3, 29, 6, 46, 15, 348, DateTimeKind.Local).AddTicks(6639), 1, null, null, "Eius et cum aut eius aut dolor. Eos voluptatibus est ut labore atque illo soluta. Veritatis et voluptas dolorem quod sed sed aliquid. Non eum provident asperiores nulla vitae reprehenderit.", 119 },
                    { 113, new DateTime(2021, 8, 24, 19, 15, 41, 174, DateTimeKind.Local).AddTicks(657), 1, 96, new DateTime(2022, 2, 27, 18, 53, 53, 95, DateTimeKind.Local).AddTicks(1048), new DateTime(2021, 2, 11, 1, 15, 16, 147, DateTimeKind.Local).AddTicks(7807), 2, null, null, "Necessitatibus vero ut non aut velit sed.\nQui magnam qui eum et perferendis maxime.\nConsectetur omnis sint.", 19 },
                    { 68, new DateTime(2021, 5, 31, 23, 52, 58, 334, DateTimeKind.Local).AddTicks(6607), 55, 149, new DateTime(2022, 3, 15, 22, 6, 58, 143, DateTimeKind.Local).AddTicks(4102), new DateTime(2021, 5, 7, 22, 58, 48, 261, DateTimeKind.Local).AddTicks(6848), 2, null, null, "Enim harum maiores voluptatem quibusdam repellendus. Ut nam ut. Quidem rem natus suscipit ex possimus inventore molestiae quas. Recusandae qui quia. Necessitatibus rerum ea praesentium illum autem ea laboriosam atque.", 169 },
                    { 45, new DateTime(2020, 11, 2, 2, 6, 53, 804, DateTimeKind.Local).AddTicks(1806), 40, 6, new DateTime(2021, 12, 10, 6, 37, 21, 979, DateTimeKind.Local).AddTicks(4565), new DateTime(2021, 3, 10, 14, 32, 10, 24, DateTimeKind.Local).AddTicks(3042), 4, null, null, "Voluptas eum dolores.\nSunt quos velit reiciendis.\nAut aut quidem.\nEt sit atque et officia molestiae enim qui sunt.", 20 },
                    { 159, new DateTime(2021, 7, 20, 9, 19, 51, 964, DateTimeKind.Local).AddTicks(3893), 36, 7, new DateTime(2022, 4, 3, 3, 59, 17, 616, DateTimeKind.Local).AddTicks(3285), new DateTime(2021, 4, 21, 22, 31, 52, 484, DateTimeKind.Local).AddTicks(7732), 1, null, null, "Aperiam aliquid repellendus.", 67 },
                    { 154, new DateTime(2021, 7, 5, 11, 54, 9, 74, DateTimeKind.Local).AddTicks(9737), 1, 74, new DateTime(2022, 7, 29, 4, 48, 48, 272, DateTimeKind.Local).AddTicks(6154), new DateTime(2021, 3, 12, 15, 49, 39, 54, DateTimeKind.Local).AddTicks(643), 3, null, null, "Dignissimos nostrum laborum sequi voluptate velit tempora iste earum.\nSunt quae molestiae in blanditiis nobis.\nVel numquam ratione nihil laboriosam dolore exercitationem dolores quam sapiente.\nEt velit in quisquam nemo enim.\nUt dolores ut consequatur odio sint quos et.", 112 },
                    { 172, new DateTime(2021, 4, 28, 4, 48, 28, 101, DateTimeKind.Local).AddTicks(4856), 49, 98, new DateTime(2021, 10, 12, 10, 22, 39, 19, DateTimeKind.Local).AddTicks(7382), new DateTime(2021, 5, 13, 3, 36, 56, 931, DateTimeKind.Local).AddTicks(6418), 2, null, null, "Similique id aut.\nNostrum ea cum laudantium numquam omnis ut molestiae.\nEsse ipsam vitae quae ut perferendis.\nDeleniti incidunt vel et suscipit corrupti ea cum consequuntur.\nTenetur dolorem magnam placeat laudantium possimus dolor culpa qui.\nQuia et aut totam velit dolores non velit esse.", 50 },
                    { 108, new DateTime(2021, 2, 23, 4, 33, 51, 852, DateTimeKind.Local).AddTicks(1491), 38, 133, new DateTime(2021, 9, 3, 0, 20, 38, 411, DateTimeKind.Local).AddTicks(3612), new DateTime(2021, 4, 23, 18, 40, 47, 820, DateTimeKind.Local).AddTicks(4414), 5, null, null, "Quia et in perferendis.", 102 },
                    { 143, new DateTime(2020, 9, 22, 0, 8, 42, 249, DateTimeKind.Local).AddTicks(9458), 1, 30, new DateTime(2021, 9, 23, 13, 31, 38, 539, DateTimeKind.Local).AddTicks(9789), new DateTime(2021, 1, 27, 2, 43, 58, 461, DateTimeKind.Local).AddTicks(7827), 2, null, null, "Rerum porro consequatur qui illum dolorem dolores.", 174 },
                    { 155, new DateTime(2021, 4, 4, 15, 12, 33, 787, DateTimeKind.Local).AddTicks(2848), 29, 16, new DateTime(2021, 10, 21, 9, 16, 42, 875, DateTimeKind.Local).AddTicks(7280), new DateTime(2021, 2, 24, 16, 53, 31, 708, DateTimeKind.Local).AddTicks(8872), 4, null, null, "molestiae", 14 },
                    { 138, new DateTime(2020, 10, 4, 11, 11, 3, 564, DateTimeKind.Local).AddTicks(7295), 29, 16, new DateTime(2021, 10, 23, 9, 30, 34, 496, DateTimeKind.Local).AddTicks(7283), new DateTime(2021, 6, 17, 3, 20, 26, 517, DateTimeKind.Local).AddTicks(2342), 4, null, null, "Accusamus minima laboriosam sunt recusandae omnis id consectetur.", 4 },
                    { 18, new DateTime(2021, 5, 12, 13, 51, 26, 731, DateTimeKind.Local).AddTicks(7262), 38, 8, new DateTime(2022, 5, 10, 19, 35, 23, 411, DateTimeKind.Local).AddTicks(1550), new DateTime(2020, 9, 29, 8, 32, 21, 601, DateTimeKind.Local).AddTicks(6070), 5, null, null, "Recusandae non odio et. Dolores sint voluptatibus qui iusto officia. Fuga quam non. Doloremque molestiae cum laborum ut rem iure occaecati nihil. Sequi ut minima consequatur aliquid sunt velit. Quos deserunt pariatur impedit dolore neque maxime corporis.", 78 },
                    { 126, new DateTime(2020, 12, 5, 5, 33, 41, 642, DateTimeKind.Local).AddTicks(8993), 42, 96, new DateTime(2021, 11, 30, 14, 31, 18, 821, DateTimeKind.Local).AddTicks(4037), new DateTime(2020, 12, 27, 4, 24, 32, 464, DateTimeKind.Local).AddTicks(8824), 3, null, null, "Eum qui voluptatum quibusdam ad officia velit consequuntur quae. Aliquid est quisquam saepe consectetur qui odio id cum. Velit exercitationem accusantium sed quod. Incidunt velit fuga dolores hic cupiditate sint et voluptates odio.", 249 },
                    { 197, new DateTime(2020, 10, 19, 8, 16, 36, 668, DateTimeKind.Local).AddTicks(5139), 27, 80, new DateTime(2021, 10, 26, 21, 4, 41, 903, DateTimeKind.Local).AddTicks(2210), new DateTime(2021, 2, 5, 18, 26, 35, 819, DateTimeKind.Local).AddTicks(9269), 4, null, null, "ea", 20 },
                    { 119, new DateTime(2021, 2, 11, 9, 5, 45, 69, DateTimeKind.Local).AddTicks(8820), 27, 12, new DateTime(2022, 5, 28, 9, 57, 45, 194, DateTimeKind.Local).AddTicks(9065), new DateTime(2020, 10, 17, 18, 58, 23, 680, DateTimeKind.Local).AddTicks(8512), 5, null, null, "aut", 57 },
                    { 2, new DateTime(2020, 10, 1, 1, 3, 2, 812, DateTimeKind.Local).AddTicks(3850), 50, 123, new DateTime(2022, 1, 2, 14, 17, 15, 352, DateTimeKind.Local).AddTicks(9407), new DateTime(2021, 7, 28, 15, 47, 47, 588, DateTimeKind.Local).AddTicks(516), 3, null, null, "ut", 9 },
                    { 163, new DateTime(2021, 5, 20, 17, 29, 14, 668, DateTimeKind.Local).AddTicks(3671), 48, 143, new DateTime(2021, 10, 10, 11, 33, 48, 309, DateTimeKind.Local).AddTicks(4436), new DateTime(2021, 2, 19, 4, 5, 57, 376, DateTimeKind.Local).AddTicks(5632), 2, null, null, "Nisi vel aut at consequuntur id et cumque sed harum.\nNisi suscipit quia et quae nisi.\nQuibusdam repellendus enim.\nNon enim deserunt quae dolorem velit optio consectetur adipisci.\nDeleniti velit quia autem.\nCupiditate cumque id et.", 249 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 160, new DateTime(2021, 5, 22, 21, 6, 39, 926, DateTimeKind.Local).AddTicks(8333), 17, 105, new DateTime(2022, 7, 29, 16, 0, 48, 343, DateTimeKind.Local).AddTicks(3667), new DateTime(2020, 11, 12, 21, 21, 1, 701, DateTimeKind.Local).AddTicks(7632), 4, null, null, "sit", 146 },
                    { 40, new DateTime(2021, 6, 30, 23, 33, 12, 332, DateTimeKind.Local).AddTicks(7409), 55, 74, new DateTime(2021, 9, 8, 0, 28, 22, 367, DateTimeKind.Local).AddTicks(1763), new DateTime(2020, 11, 26, 3, 11, 1, 31, DateTimeKind.Local).AddTicks(6893), 3, null, null, "Nemo non illo dolore consequatur excepturi. Earum nihil fugit sed dolore est explicabo. Dolorem dolorem eos nostrum qui.", 208 },
                    { 16, new DateTime(2021, 4, 11, 11, 46, 10, 108, DateTimeKind.Local).AddTicks(4069), 55, 31, new DateTime(2022, 5, 2, 21, 50, 9, 636, DateTimeKind.Local).AddTicks(7868), new DateTime(2021, 3, 24, 18, 43, 0, 441, DateTimeKind.Local).AddTicks(5222), 4, null, null, "voluptas", 72 },
                    { 156, new DateTime(2020, 10, 18, 3, 6, 52, 2, DateTimeKind.Local).AddTicks(3981), 75, 91, new DateTime(2021, 9, 19, 7, 31, 15, 566, DateTimeKind.Local).AddTicks(6950), new DateTime(2021, 2, 26, 20, 31, 15, 837, DateTimeKind.Local).AddTicks(9129), 3, null, null, "Harum maxime dicta at quod et at sint amet. Quis est incidunt non aspernatur aut fugiat in. Natus nihil et ipsum voluptatum quia et quia dolorum dolores. Id sit doloribus consequuntur.", 53 },
                    { 192, new DateTime(2021, 4, 29, 16, 59, 18, 133, DateTimeKind.Local).AddTicks(9933), 75, 119, new DateTime(2022, 1, 16, 18, 5, 31, 782, DateTimeKind.Local).AddTicks(9744), new DateTime(2021, 1, 20, 3, 2, 0, 958, DateTimeKind.Local).AddTicks(7847), 3, null, null, "sit", 177 },
                    { 158, new DateTime(2021, 7, 10, 1, 37, 48, 685, DateTimeKind.Local).AddTicks(6371), 48, 80, new DateTime(2022, 4, 7, 22, 26, 36, 649, DateTimeKind.Local).AddTicks(1277), new DateTime(2021, 1, 30, 16, 32, 48, 469, DateTimeKind.Local).AddTicks(3086), 2, null, null, "Inventore necessitatibus consequatur.", 281 },
                    { 83, new DateTime(2021, 6, 18, 14, 36, 2, 929, DateTimeKind.Local).AddTicks(4190), 1, 133, new DateTime(2022, 6, 29, 14, 9, 24, 746, DateTimeKind.Local).AddTicks(9019), new DateTime(2021, 3, 28, 11, 25, 16, 294, DateTimeKind.Local).AddTicks(4205), 1, null, null, "Est repellendus veritatis temporibus est nisi tempore quae iure.\nInventore repudiandae aut voluptas omnis accusantium quae eaque ipsam ut.\nNemo id eveniet porro unde laboriosam sint asperiores.\nOmnis corrupti neque id sit cumque qui rerum sit.", 124 },
                    { 189, new DateTime(2021, 1, 4, 20, 42, 41, 685, DateTimeKind.Local).AddTicks(4590), 28, 112, new DateTime(2022, 4, 30, 20, 5, 6, 957, DateTimeKind.Local).AddTicks(1161), new DateTime(2021, 4, 30, 16, 49, 12, 772, DateTimeKind.Local).AddTicks(6249), 2, null, null, "Aut unde et sit magni.\nIpsa dicta quo quia nobis sint nihil a aut.\nIure ut vel sed ipsa vel architecto quae.\nAsperiores magni possimus vero fugit quo sunt reiciendis dolorem.", 204 },
                    { 198, new DateTime(2021, 7, 14, 1, 58, 25, 489, DateTimeKind.Local).AddTicks(6117), 35, 76, new DateTime(2021, 10, 7, 7, 58, 42, 440, DateTimeKind.Local).AddTicks(5696), new DateTime(2021, 2, 22, 10, 43, 39, 77, DateTimeKind.Local).AddTicks(560), 3, null, null, "Cupiditate suscipit ea cum blanditiis. Sed explicabo ut. Qui et odio omnis.", 242 },
                    { 166, new DateTime(2020, 8, 30, 1, 57, 54, 216, DateTimeKind.Local).AddTicks(2312), 88, 1, new DateTime(2022, 8, 16, 20, 58, 35, 974, DateTimeKind.Local).AddTicks(9086), new DateTime(2021, 8, 17, 8, 59, 7, 894, DateTimeKind.Local).AddTicks(1267), 2, null, null, "Ratione minus quasi voluptate harum quisquam sed fuga est.\nOdio illo aut aut molestiae quaerat voluptatem consequatur qui.\nCum eveniet ut.\nImpedit ut in qui quidem sint architecto voluptates.\nEt dolor et voluptatem aut repellendus vel ducimus.", 270 },
                    { 170, new DateTime(2020, 10, 7, 2, 22, 11, 433, DateTimeKind.Local).AddTicks(5033), 35, 34, new DateTime(2021, 9, 4, 14, 25, 47, 250, DateTimeKind.Local).AddTicks(5822), new DateTime(2021, 6, 2, 19, 31, 40, 491, DateTimeKind.Local).AddTicks(5355), 2, null, null, "Explicabo enim dolores labore omnis aperiam ea.", 1 },
                    { 171, new DateTime(2021, 8, 5, 8, 51, 16, 401, DateTimeKind.Local).AddTicks(2880), 31, 109, new DateTime(2022, 4, 8, 3, 53, 44, 893, DateTimeKind.Local).AddTicks(5240), new DateTime(2020, 12, 24, 20, 43, 43, 72, DateTimeKind.Local).AddTicks(2059), 2, null, null, "totam", 117 },
                    { 81, new DateTime(2021, 8, 13, 12, 31, 11, 121, DateTimeKind.Local).AddTicks(3669), 89, 14, new DateTime(2022, 5, 18, 20, 2, 5, 561, DateTimeKind.Local).AddTicks(4017), new DateTime(2021, 6, 6, 13, 8, 41, 115, DateTimeKind.Local).AddTicks(6439), 3, null, null, "Nihil et nulla vel natus iure.\nAt accusantium provident ullam.\nSapiente labore nihil iure architecto facilis similique ut.", 242 },
                    { 103, new DateTime(2021, 8, 26, 5, 46, 35, 531, DateTimeKind.Local).AddTicks(3078), 89, 97, new DateTime(2022, 6, 22, 4, 16, 51, 324, DateTimeKind.Local).AddTicks(7457), new DateTime(2020, 8, 29, 9, 32, 33, 742, DateTimeKind.Local).AddTicks(5879), 1, null, null, "Tempora quia ut quia dolores dolore placeat quidem tempore qui.", 167 },
                    { 200, new DateTime(2020, 12, 8, 18, 54, 1, 264, DateTimeKind.Local).AddTicks(6472), 89, 77, new DateTime(2021, 10, 11, 17, 54, 20, 800, DateTimeKind.Local).AddTicks(5050), new DateTime(2020, 12, 27, 11, 31, 57, 473, DateTimeKind.Local).AddTicks(3598), 5, null, null, "Totam aut omnis cupiditate non tenetur et sunt corrupti quasi.", 187 },
                    { 55, new DateTime(2021, 7, 12, 2, 19, 57, 812, DateTimeKind.Local).AddTicks(9589), 77, 26, new DateTime(2022, 4, 18, 16, 17, 42, 210, DateTimeKind.Local).AddTicks(8384), new DateTime(2021, 6, 9, 4, 26, 56, 406, DateTimeKind.Local).AddTicks(9664), 2, null, null, "Sunt occaecati nemo a possimus voluptas a. Corporis a expedita minima. Nisi aspernatur quod rerum ea quisquam quasi. Nam tenetur nihil non suscipit recusandae cumque beatae ut sint. Necessitatibus quo eaque dolor. Fuga consectetur incidunt.", 68 },
                    { 128, new DateTime(2021, 4, 11, 22, 12, 25, 24, DateTimeKind.Local).AddTicks(8615), 31, 54, new DateTime(2022, 1, 10, 11, 56, 37, 159, DateTimeKind.Local).AddTicks(1515), new DateTime(2021, 7, 27, 14, 27, 25, 386, DateTimeKind.Local).AddTicks(8417), 2, null, null, "aut", 17 },
                    { 97, new DateTime(2020, 12, 14, 8, 54, 31, 399, DateTimeKind.Local).AddTicks(7756), 35, 15, new DateTime(2022, 2, 5, 0, 0, 42, 862, DateTimeKind.Local).AddTicks(7263), new DateTime(2021, 4, 27, 21, 33, 32, 965, DateTimeKind.Local).AddTicks(5735), 2, null, null, "Eum error sequi totam.", 42 },
                    { 52, new DateTime(2021, 4, 12, 1, 14, 17, 589, DateTimeKind.Local).AddTicks(7112), 19, 90, new DateTime(2021, 9, 27, 21, 48, 31, 226, DateTimeKind.Local).AddTicks(6628), new DateTime(2021, 1, 18, 2, 12, 49, 524, DateTimeKind.Local).AddTicks(9214), 5, null, null, "Qui ut nemo est sint.\nLaudantium ut deleniti asperiores natus et assumenda.\nSed est quibusdam maxime unde.\nEveniet optio id.\nAccusantium ut id vel quibusdam sed et libero aspernatur saepe.\nIn ratione totam aliquid porro sequi.", 20 },
                    { 60, new DateTime(2021, 6, 1, 14, 44, 23, 973, DateTimeKind.Local).AddTicks(8861), 19, 135, new DateTime(2022, 1, 25, 16, 49, 53, 371, DateTimeKind.Local).AddTicks(5567), new DateTime(2020, 11, 29, 14, 21, 21, 721, DateTimeKind.Local).AddTicks(1962), 3, null, null, "Labore ut voluptatum ratione natus officia.", 71 },
                    { 79, new DateTime(2021, 4, 20, 12, 11, 4, 252, DateTimeKind.Local).AddTicks(1975), 31, 128, new DateTime(2021, 12, 12, 2, 2, 49, 347, DateTimeKind.Local).AddTicks(6602), new DateTime(2021, 4, 6, 5, 18, 53, 110, DateTimeKind.Local).AddTicks(8537), 2, null, null, "Cumque eligendi laborum a.", 39 },
                    { 73, new DateTime(2021, 1, 19, 19, 53, 5, 180, DateTimeKind.Local).AddTicks(4482), 19, 128, new DateTime(2021, 9, 30, 11, 43, 9, 768, DateTimeKind.Local).AddTicks(440), new DateTime(2021, 2, 2, 2, 11, 3, 857, DateTimeKind.Local).AddTicks(2499), 1, null, null, "Recusandae facere cupiditate rerum.", 117 },
                    { 8, new DateTime(2020, 9, 22, 12, 5, 34, 593, DateTimeKind.Local).AddTicks(94), 35, 15, new DateTime(2021, 9, 8, 5, 52, 0, 524, DateTimeKind.Local).AddTicks(5955), new DateTime(2020, 10, 27, 23, 42, 19, 305, DateTimeKind.Local).AddTicks(5277), 4, null, null, "non", 35 },
                    { 105, new DateTime(2021, 4, 30, 8, 45, 58, 828, DateTimeKind.Local).AddTicks(845), 19, 25, new DateTime(2022, 7, 11, 12, 46, 5, 455, DateTimeKind.Local).AddTicks(4846), new DateTime(2020, 10, 10, 9, 43, 22, 980, DateTimeKind.Local).AddTicks(5598), 5, null, null, "aspernatur", 182 },
                    { 173, new DateTime(2020, 9, 23, 4, 5, 45, 207, DateTimeKind.Local).AddTicks(7233), 59, 88, new DateTime(2021, 12, 25, 7, 16, 4, 789, DateTimeKind.Local).AddTicks(831), new DateTime(2020, 10, 17, 18, 27, 3, 975, DateTimeKind.Local).AddTicks(8021), 4, null, null, "Et alias repellat suscipit praesentium. Dignissimos cum quo hic natus ullam laudantium quas voluptatem. Natus consequuntur nisi incidunt sed minima neque. Autem laudantium eum dolorem sunt. Consequuntur sapiente aut voluptatem.", 186 },
                    { 76, new DateTime(2020, 12, 27, 6, 34, 38, 354, DateTimeKind.Local).AddTicks(6672), 35, 51, new DateTime(2021, 10, 15, 4, 19, 7, 869, DateTimeKind.Local).AddTicks(9400), new DateTime(2020, 10, 27, 0, 4, 33, 769, DateTimeKind.Local).AddTicks(7577), 2, null, null, "Expedita fugiat debitis vero ut.", 55 },
                    { 20, new DateTime(2021, 5, 31, 4, 50, 44, 627, DateTimeKind.Local).AddTicks(2010), 47, 10, new DateTime(2022, 7, 13, 22, 17, 17, 985, DateTimeKind.Local).AddTicks(4527), new DateTime(2021, 8, 16, 20, 12, 25, 553, DateTimeKind.Local).AddTicks(4258), 3, null, null, "Quia cum sint et recusandae dolor voluptatum qui quis ex. Magnam dolorem architecto aliquam aut eos cumque doloremque. Recusandae modi reprehenderit sit laudantium mollitia sequi dolorem quia. Sit quos commodi perspiciatis est esse. Voluptate illo veniam nisi aspernatur aut quas.", 235 },
                    { 144, new DateTime(2021, 1, 11, 14, 57, 13, 395, DateTimeKind.Local).AddTicks(8784), 47, 111, new DateTime(2022, 7, 16, 11, 59, 58, 429, DateTimeKind.Local).AddTicks(3414), new DateTime(2021, 6, 19, 2, 19, 12, 414, DateTimeKind.Local).AddTicks(3072), 5, null, null, "Ipsa voluptas nostrum consequatur sit quo est ab est laborum.", 151 },
                    { 93, new DateTime(2021, 6, 5, 21, 43, 24, 616, DateTimeKind.Local).AddTicks(1135), 42, 55, new DateTime(2021, 9, 9, 14, 5, 41, 878, DateTimeKind.Local).AddTicks(390), new DateTime(2020, 9, 7, 20, 14, 58, 259, DateTimeKind.Local).AddTicks(1381), 2, null, null, "Iure fugit molestiae laudantium voluptas.\nFacere eum consequatur.\nEnim praesentium labore numquam omnis ducimus nostrum est numquam totam.\nEt enim consequuntur amet voluptates.", 153 },
                    { 165, new DateTime(2020, 9, 6, 7, 18, 18, 298, DateTimeKind.Local).AddTicks(6425), 59, 86, new DateTime(2022, 1, 31, 20, 45, 35, 575, DateTimeKind.Local).AddTicks(1097), new DateTime(2020, 11, 12, 22, 46, 14, 493, DateTimeKind.Local).AddTicks(8037), 3, null, null, "Molestiae voluptatem dolorum exercitationem sunt voluptatem quia nobis est.\nQui adipisci ipsum.\nLaudantium ea libero quia quidem suscipit molestias.\nSed similique dolorum cum est dignissimos.", 153 },
                    { 148, new DateTime(2021, 2, 19, 22, 35, 59, 609, DateTimeKind.Local).AddTicks(7136), 48, 19, new DateTime(2022, 3, 3, 23, 36, 12, 229, DateTimeKind.Local).AddTicks(6732), new DateTime(2021, 2, 23, 22, 3, 38, 43, DateTimeKind.Local).AddTicks(9839), 2, null, null, "Corporis atque est ipsum aut praesentium facilis rem id.", 91 },
                    { 185, new DateTime(2021, 8, 18, 11, 8, 0, 171, DateTimeKind.Local).AddTicks(9797), 26, 109, new DateTime(2022, 6, 8, 21, 45, 10, 226, DateTimeKind.Local).AddTicks(4379), new DateTime(2021, 5, 7, 2, 13, 18, 668, DateTimeKind.Local).AddTicks(8920), 1, null, null, "Velit cumque vel. Quisquam autem aut dolore et reiciendis ut nisi consequatur aut. Neque perferendis minus.", 35 },
                    { 129, new DateTime(2021, 2, 8, 2, 25, 19, 382, DateTimeKind.Local).AddTicks(3629), 88, 128, new DateTime(2022, 6, 25, 22, 49, 30, 608, DateTimeKind.Local).AddTicks(4591), new DateTime(2020, 10, 30, 6, 13, 32, 997, DateTimeKind.Local).AddTicks(1732), 4, null, null, "quas", 229 },
                    { 117, new DateTime(2021, 6, 17, 13, 0, 8, 177, DateTimeKind.Local).AddTicks(3739), 48, 111, new DateTime(2022, 6, 4, 11, 40, 57, 225, DateTimeKind.Local).AddTicks(3135), new DateTime(2020, 11, 23, 1, 29, 8, 929, DateTimeKind.Local).AddTicks(1705), 3, null, null, "Qui cumque nisi. Quis dignissimos quod temporibus rerum quas saepe. Veritatis omnis numquam. Et quo culpa earum ratione sit omnis ut ut excepturi. Nam culpa facilis soluta magnam sunt rem vel. Consequuntur explicabo aperiam sapiente.", 78 },
                    { 98, new DateTime(2021, 4, 6, 16, 5, 52, 894, DateTimeKind.Local).AddTicks(861), 21, 55, new DateTime(2022, 7, 5, 17, 36, 36, 618, DateTimeKind.Local).AddTicks(9408), new DateTime(2020, 9, 14, 3, 28, 51, 68, DateTimeKind.Local).AddTicks(7420), 2, null, null, "Soluta sit libero doloribus quia.\nRepellat perferendis enim ut consequuntur enim blanditiis reiciendis.\nRecusandae ex eligendi ut dolore.\nDolorem doloribus sit dolor sunt tenetur.", 162 },
                    { 29, new DateTime(2020, 11, 5, 9, 12, 25, 697, DateTimeKind.Local).AddTicks(2622), 48, 22, new DateTime(2022, 2, 19, 17, 22, 45, 387, DateTimeKind.Local).AddTicks(1926), new DateTime(2020, 10, 1, 4, 27, 35, 117, DateTimeKind.Local).AddTicks(4961), 1, null, null, "Enim quas in quia odio maiores tenetur.\nMinima dolor voluptas hic officiis ducimus sint sit.\nEx eligendi dignissimos autem distinctio ut vel ab.\nLaboriosam eligendi consectetur aut consequatur est reprehenderit molestiae.\nEst ut fuga non ut quaerat reprehenderit porro repellendus repellendus.\nQuibusdam officiis nihil modi placeat.", 174 },
                    { 27, new DateTime(2021, 5, 4, 4, 31, 0, 740, DateTimeKind.Local).AddTicks(2009), 1, 109, new DateTime(2021, 9, 22, 21, 2, 7, 66, DateTimeKind.Local).AddTicks(5673), new DateTime(2020, 12, 29, 10, 41, 54, 443, DateTimeKind.Local).AddTicks(7691), 4, null, null, "voluptatem", 121 },
                    { 71, new DateTime(2020, 11, 2, 2, 9, 38, 909, DateTimeKind.Local).AddTicks(5063), 21, 129, new DateTime(2022, 6, 3, 7, 31, 22, 845, DateTimeKind.Local).AddTicks(6100), new DateTime(2021, 6, 22, 12, 39, 55, 345, DateTimeKind.Local).AddTicks(7678), 5, null, null, "Dolorem odio ullam doloribus voluptatem accusantium consequatur assumenda totam.", 147 },
                    { 196, new DateTime(2021, 8, 18, 7, 29, 45, 385, DateTimeKind.Local).AddTicks(5805), 32, 130, new DateTime(2021, 9, 6, 10, 10, 41, 11, DateTimeKind.Local).AddTicks(6310), new DateTime(2021, 7, 24, 5, 17, 42, 234, DateTimeKind.Local).AddTicks(2278), 2, null, null, "Magni iure labore magni voluptates ut et.", 57 },
                    { 5, new DateTime(2021, 1, 18, 7, 19, 21, 120, DateTimeKind.Local).AddTicks(3938), 60, 112, new DateTime(2022, 5, 1, 3, 9, 58, 747, DateTimeKind.Local).AddTicks(4738), new DateTime(2021, 3, 3, 12, 53, 10, 649, DateTimeKind.Local).AddTicks(1413), 3, null, null, "impedit", 252 },
                    { 10, new DateTime(2021, 1, 20, 9, 12, 10, 674, DateTimeKind.Local).AddTicks(6580), 60, 89, new DateTime(2022, 8, 13, 2, 56, 40, 238, DateTimeKind.Local).AddTicks(6195), new DateTime(2021, 1, 12, 11, 47, 25, 381, DateTimeKind.Local).AddTicks(9765), 1, null, null, "dolore", 92 },
                    { 109, new DateTime(2021, 3, 6, 15, 1, 58, 558, DateTimeKind.Local).AddTicks(5657), 60, 94, new DateTime(2022, 3, 20, 4, 30, 24, 542, DateTimeKind.Local).AddTicks(2841), new DateTime(2021, 4, 9, 20, 28, 13, 677, DateTimeKind.Local).AddTicks(7878), 2, null, null, "ea", 186 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 90, new DateTime(2020, 9, 10, 23, 9, 39, 561, DateTimeKind.Local).AddTicks(2078), 59, 1, new DateTime(2021, 9, 25, 8, 36, 49, 436, DateTimeKind.Local).AddTicks(4742), new DateTime(2021, 3, 29, 13, 53, 54, 686, DateTimeKind.Local).AddTicks(9391), 1, null, null, "non", 117 },
                    { 130, new DateTime(2020, 9, 12, 15, 28, 36, 872, DateTimeKind.Local).AddTicks(9377), 32, 147, new DateTime(2022, 7, 7, 17, 16, 27, 630, DateTimeKind.Local).AddTicks(13), new DateTime(2020, 10, 16, 3, 53, 3, 617, DateTimeKind.Local).AddTicks(5702), 5, null, null, "Nisi eaque atque earum voluptas vel dolor voluptatem laboriosam.", 162 },
                    { 110, new DateTime(2021, 7, 8, 2, 36, 8, 827, DateTimeKind.Local).AddTicks(7132), 32, 97, new DateTime(2022, 7, 13, 4, 54, 9, 191, DateTimeKind.Local).AddTicks(3770), new DateTime(2020, 12, 18, 14, 56, 10, 281, DateTimeKind.Local).AddTicks(866), 3, null, null, "accusamus", 19 },
                    { 61, new DateTime(2021, 4, 10, 0, 16, 43, 797, DateTimeKind.Local).AddTicks(9926), 32, 125, new DateTime(2021, 11, 17, 4, 30, 50, 540, DateTimeKind.Local).AddTicks(2088), new DateTime(2021, 3, 10, 14, 15, 19, 191, DateTimeKind.Local).AddTicks(476), 5, null, null, "Ad et corporis rerum et.\nQui at amet vitae non nesciunt dolores ut.\nDeleniti dolorem dolores corrupti dicta ut.\nEst aut vel non possimus inventore aut vel debitis a.\nOmnis dolorem sint architecto quod at mollitia tenetur dolorum a.\nInventore beatae dolore dolor dolores assumenda.", 101 },
                    { 22, new DateTime(2021, 1, 15, 11, 5, 42, 946, DateTimeKind.Local).AddTicks(4497), 26, 37, new DateTime(2021, 9, 5, 17, 45, 48, 494, DateTimeKind.Local).AddTicks(3502), new DateTime(2020, 9, 26, 9, 7, 16, 159, DateTimeKind.Local).AddTicks(861), 3, null, null, "et", 252 },
                    { 77, new DateTime(2021, 8, 21, 0, 0, 53, 762, DateTimeKind.Local).AddTicks(9048), 26, 131, new DateTime(2022, 6, 10, 19, 55, 2, 96, DateTimeKind.Local).AddTicks(8685), new DateTime(2020, 12, 13, 17, 50, 43, 384, DateTimeKind.Local).AddTicks(713), 3, null, null, "Ex illum dicta minima illum facere dolorum commodi labore quisquam. Consectetur ea deleniti. Vel facilis necessitatibus eveniet necessitatibus mollitia. Commodi sequi eum optio nihil ut vitae blanditiis laborum est.", 242 },
                    { 168, new DateTime(2021, 6, 28, 12, 4, 39, 739, DateTimeKind.Local).AddTicks(8876), 26, 101, new DateTime(2022, 2, 7, 11, 24, 38, 162, DateTimeKind.Local).AddTicks(9750), new DateTime(2021, 5, 31, 5, 38, 19, 972, DateTimeKind.Local).AddTicks(6686), 2, null, null, "Qui autem repudiandae aliquam quia nisi consequuntur.\nBeatae doloremque vel molestiae quo et ea illo.\nSequi consequatur eveniet nostrum rem iste dicta iure.\nUllam tempora tempora sint inventore voluptate eum dolorum.\nEt illum saepe sed facilis consequatur illo.\nSit dicta consequatur nemo quasi omnis.", 291 },
                    { 120, new DateTime(2021, 6, 12, 1, 25, 37, 683, DateTimeKind.Local).AddTicks(2628), 56, 70, new DateTime(2022, 3, 17, 1, 19, 13, 890, DateTimeKind.Local).AddTicks(9005), new DateTime(2021, 7, 15, 7, 0, 35, 104, DateTimeKind.Local).AddTicks(9031), 1, null, null, "Ipsum voluptatem eum impedit soluta dolorum maxime.\nError consequatur delectus iusto ut iste.\nQuod et repellat eaque optio occaecati voluptatem.\nSit omnis quia.", 272 },
                    { 162, new DateTime(2021, 6, 11, 10, 35, 52, 681, DateTimeKind.Local).AddTicks(9730), 57, 60, new DateTime(2022, 4, 29, 11, 5, 56, 337, DateTimeKind.Local).AddTicks(908), new DateTime(2020, 10, 14, 22, 29, 19, 891, DateTimeKind.Local).AddTicks(5691), 4, null, null, "Ipsa odio porro vero ex mollitia sed et. Voluptas asperiores modi quisquam vero qui. Et qui sapiente est aut repudiandae quo vel sequi. Sapiente id enim odit sint consectetur quia autem dolorem. Aut aut inventore facere quam.", 124 },
                    { 32, new DateTime(2020, 9, 10, 16, 55, 15, 65, DateTimeKind.Local).AddTicks(6755), 56, 102, new DateTime(2022, 3, 10, 2, 54, 7, 488, DateTimeKind.Local).AddTicks(5802), new DateTime(2020, 12, 25, 9, 53, 8, 386, DateTimeKind.Local).AddTicks(211), 4, null, null, "Ipsum quia voluptatem odio excepturi fuga in amet. Qui sunt debitis. Aspernatur explicabo fugit.", 174 },
                    { 194, new DateTime(2020, 12, 25, 20, 15, 1, 482, DateTimeKind.Local).AddTicks(9639), 57, 7, new DateTime(2022, 8, 22, 2, 16, 9, 368, DateTimeKind.Local).AddTicks(7490), new DateTime(2021, 4, 25, 16, 15, 27, 436, DateTimeKind.Local).AddTicks(9260), 3, null, null, "Maxime ducimus delectus qui et molestiae qui et.", 55 },
                    { 25, new DateTime(2021, 3, 26, 10, 33, 42, 196, DateTimeKind.Local).AddTicks(7563), 88, 43, new DateTime(2021, 12, 3, 22, 5, 51, 761, DateTimeKind.Local).AddTicks(7443), new DateTime(2021, 6, 16, 12, 17, 32, 906, DateTimeKind.Local).AddTicks(5187), 2, null, null, "Consequatur quo a impedit aut est non corrupti. Ex sint voluptate itaque quis consequuntur dolores alias. Aliquam quas ducimus aspernatur molestiae occaecati est. Doloremque aut sit aperiam unde voluptatem omnis aliquid omnis. Rerum veniam ab aut distinctio distinctio est repellendus quasi asperiores. Nobis corrupti iusto expedita ea cum.", 121 },
                    { 139, new DateTime(2020, 9, 22, 9, 31, 56, 440, DateTimeKind.Local).AddTicks(6931), 88, 63, new DateTime(2021, 9, 9, 2, 58, 11, 265, DateTimeKind.Local).AddTicks(5109), new DateTime(2021, 6, 17, 14, 59, 26, 16, DateTimeKind.Local).AddTicks(397), 2, null, null, "Iste dolorem rem delectus sed vero pariatur dolores debitis. Non sequi id modi voluptates asperiores ut. Molestiae rem consequuntur perferendis incidunt nesciunt tenetur autem. Et in est enim voluptas iure. Unde dolorem enim et. Atque et iusto aut adipisci nam maxime praesentium.", 35 },
                    { 82, new DateTime(2021, 8, 18, 5, 46, 2, 558, DateTimeKind.Local).AddTicks(6142), 18, 55, new DateTime(2021, 9, 13, 21, 41, 49, 660, DateTimeKind.Local).AddTicks(3049), new DateTime(2021, 8, 17, 11, 46, 39, 750, DateTimeKind.Local).AddTicks(5395), 4, null, null, "Quod in iure quis consectetur eaque excepturi perferendis qui laudantium.\nAtque sed cum illo sed sunt aut ad sit et.", 56 },
                    { 36, new DateTime(2021, 7, 6, 8, 37, 15, 62, DateTimeKind.Local).AddTicks(1792), 33, 134, new DateTime(2022, 4, 17, 12, 53, 31, 373, DateTimeKind.Local).AddTicks(5260), new DateTime(2021, 7, 31, 23, 50, 31, 536, DateTimeKind.Local).AddTicks(9121), 4, null, null, "Ullam eius quos aspernatur mollitia enim commodi in ipsa repellendus.", 251 },
                    { 181, new DateTime(2020, 11, 2, 16, 51, 1, 993, DateTimeKind.Local).AddTicks(5325), 10, 49, new DateTime(2022, 5, 4, 5, 37, 6, 337, DateTimeKind.Local).AddTicks(7267), new DateTime(2021, 3, 27, 21, 14, 8, 0, DateTimeKind.Local).AddTicks(6560), 1, null, null, "In quaerat suscipit amet id.", 89 },
                    { 42, new DateTime(2021, 2, 3, 10, 55, 35, 220, DateTimeKind.Local).AddTicks(350), 51, 83, new DateTime(2021, 12, 10, 12, 54, 6, 671, DateTimeKind.Local).AddTicks(7123), new DateTime(2020, 12, 7, 8, 17, 3, 695, DateTimeKind.Local).AddTicks(9247), 3, null, null, "veritatis", 259 },
                    { 104, new DateTime(2020, 11, 16, 1, 52, 4, 68, DateTimeKind.Local).AddTicks(7813), 4, 94, new DateTime(2021, 12, 12, 5, 4, 29, 535, DateTimeKind.Local).AddTicks(9602), new DateTime(2020, 9, 9, 6, 50, 18, 431, DateTimeKind.Local).AddTicks(8410), 5, null, null, "Hic voluptas aut magnam. Et autem qui alias totam delectus id perspiciatis et architecto. Sapiente enim expedita dolores ea sed quaerat provident. Excepturi illum eveniet perferendis.", 94 },
                    { 123, new DateTime(2021, 3, 3, 1, 33, 40, 836, DateTimeKind.Local).AddTicks(9259), 23, 32, new DateTime(2021, 9, 18, 17, 24, 22, 980, DateTimeKind.Local).AddTicks(4636), new DateTime(2021, 5, 26, 10, 11, 31, 300, DateTimeKind.Local).AddTicks(3604), 1, null, null, "Quia aperiam ut itaque. Eius qui voluptatibus placeat enim temporibus enim ipsa. Laudantium dolores perspiciatis dolore.", 115 },
                    { 15, new DateTime(2021, 2, 13, 1, 48, 52, 74, DateTimeKind.Local).AddTicks(6031), 68, 63, new DateTime(2022, 5, 21, 4, 39, 51, 175, DateTimeKind.Local).AddTicks(7150), new DateTime(2021, 8, 23, 22, 12, 56, 715, DateTimeKind.Local).AddTicks(6205), 3, null, null, "Consectetur aut voluptas culpa expedita iure. Vitae minima laudantium necessitatibus in accusamus. Tempore quidem maxime culpa ab distinctio veritatis expedita enim facere.", 57 },
                    { 37, new DateTime(2021, 5, 23, 19, 59, 32, 655, DateTimeKind.Local).AddTicks(8789), 68, 51, new DateTime(2022, 8, 26, 0, 10, 27, 549, DateTimeKind.Local).AddTicks(3670), new DateTime(2020, 9, 12, 7, 59, 36, 80, DateTimeKind.Local).AddTicks(7070), 4, null, null, "Molestias dicta iste eius laudantium. Qui laboriosam debitis quod quas odit maiores. Non delectus enim ipsa ab rerum.", 71 },
                    { 92, new DateTime(2021, 8, 18, 8, 2, 16, 91, DateTimeKind.Local).AddTicks(5836), 4, 141, new DateTime(2022, 5, 29, 20, 57, 15, 64, DateTimeKind.Local).AddTicks(3812), new DateTime(2021, 8, 17, 17, 35, 46, 187, DateTimeKind.Local).AddTicks(6798), 4, null, null, "Explicabo nam exercitationem omnis consequuntur. Nihil quasi expedita ad est sit suscipit voluptatem. Sequi voluptates illo autem dolor. Quas voluptate voluptates facilis optio non itaque voluptatibus. Saepe ea corporis accusantium aut voluptatem itaque ea est quas. Excepturi eaque aspernatur nostrum autem similique.", 243 },
                    { 12, new DateTime(2021, 5, 17, 11, 26, 41, 346, DateTimeKind.Local).AddTicks(9134), 45, 46, new DateTime(2022, 5, 23, 1, 1, 32, 105, DateTimeKind.Local).AddTicks(4919), new DateTime(2021, 8, 21, 20, 15, 12, 314, DateTimeKind.Local).AddTicks(559), 2, null, null, "Dolor velit consequuntur omnis porro.", 252 },
                    { 31, new DateTime(2021, 1, 18, 21, 48, 58, 642, DateTimeKind.Local).AddTicks(3334), 45, 27, new DateTime(2022, 5, 27, 15, 56, 27, 620, DateTimeKind.Local).AddTicks(1412), new DateTime(2021, 5, 6, 23, 45, 9, 526, DateTimeKind.Local).AddTicks(8417), 5, null, null, "Numquam et ratione quisquam amet. Earum sit deserunt omnis rerum laudantium enim ut ex velit. Voluptates dolor sit fugit est omnis occaecati quia repellat. Perspiciatis laborum porro qui pariatur consequatur sequi consequatur nobis nam. Exercitationem neque tempore aliquid.", 297 },
                    { 41, new DateTime(2021, 2, 5, 10, 16, 21, 894, DateTimeKind.Local).AddTicks(2631), 85, 119, new DateTime(2022, 4, 13, 17, 56, 6, 164, DateTimeKind.Local).AddTicks(7381), new DateTime(2021, 5, 31, 18, 14, 32, 167, DateTimeKind.Local).AddTicks(1471), 3, null, null, "Ab nesciunt mollitia vero eligendi voluptatum alias sed.\nMaxime nesciunt fugit temporibus.", 133 },
                    { 11, new DateTime(2020, 9, 4, 16, 22, 49, 11, DateTimeKind.Local).AddTicks(1361), 4, 149, new DateTime(2022, 6, 10, 22, 15, 58, 711, DateTimeKind.Local).AddTicks(4236), new DateTime(2020, 11, 14, 8, 51, 39, 246, DateTimeKind.Local).AddTicks(5876), 3, null, null, "voluptatum", 249 },
                    { 59, new DateTime(2021, 3, 6, 11, 15, 22, 524, DateTimeKind.Local).AddTicks(467), 12, 5, new DateTime(2022, 6, 16, 5, 50, 39, 988, DateTimeKind.Local).AddTicks(6372), new DateTime(2020, 12, 27, 10, 52, 12, 506, DateTimeKind.Local).AddTicks(9651), 2, null, null, "Dolorum tempore ipsum sapiente quaerat voluptatem.", 28 },
                    { 44, new DateTime(2021, 1, 21, 6, 1, 33, 192, DateTimeKind.Local).AddTicks(8886), 51, 89, new DateTime(2022, 8, 24, 3, 55, 54, 807, DateTimeKind.Local).AddTicks(7063), new DateTime(2020, 12, 28, 16, 25, 55, 238, DateTimeKind.Local).AddTicks(4753), 1, null, null, "Illum explicabo natus.", 251 },
                    { 151, new DateTime(2021, 6, 26, 1, 24, 35, 892, DateTimeKind.Local).AddTicks(6238), 12, 37, new DateTime(2022, 4, 10, 10, 42, 58, 125, DateTimeKind.Local).AddTicks(6909), new DateTime(2020, 9, 18, 7, 39, 19, 981, DateTimeKind.Local).AddTicks(3840), 3, null, null, "Facere eveniet voluptatem explicabo cum earum id ut.", 101 },
                    { 175, new DateTime(2021, 5, 24, 10, 5, 56, 345, DateTimeKind.Local).AddTicks(130), 43, 8, new DateTime(2022, 4, 12, 8, 40, 10, 633, DateTimeKind.Local).AddTicks(9992), new DateTime(2020, 10, 27, 4, 5, 46, 726, DateTimeKind.Local).AddTicks(2686), 1, null, null, "Repellat voluptatibus ad officia excepturi qui mollitia. Sed in nostrum quia. Atque nobis rem maxime dolor repudiandae voluptate omnis quidem quia. Et numquam sint sint et ratione ea voluptatem. Quae est cum deleniti accusamus maiores nihil.", 57 },
                    { 164, new DateTime(2020, 11, 1, 11, 46, 33, 791, DateTimeKind.Local).AddTicks(9934), 43, 135, new DateTime(2021, 12, 9, 9, 12, 33, 945, DateTimeKind.Local).AddTicks(8721), new DateTime(2020, 11, 2, 15, 59, 9, 325, DateTimeKind.Local).AddTicks(6908), 3, null, null, "Id minus quae quidem culpa.\nQuod quaerat vitae odio quos consequatur ut.\nVoluptatem et dolores voluptatem molestiae aut.\nSit veritatis quisquam repellat et explicabo voluptatem est excepturi.", 124 },
                    { 133, new DateTime(2021, 1, 9, 20, 16, 43, 415, DateTimeKind.Local).AddTicks(8709), 43, 73, new DateTime(2022, 1, 10, 18, 36, 47, 655, DateTimeKind.Local).AddTicks(7156), new DateTime(2020, 9, 7, 4, 11, 50, 20, DateTimeKind.Local).AddTicks(2676), 1, null, null, "Dolor quaerat nisi excepturi debitis provident et vel. Dolore et et omnis eum. Distinctio itaque fugiat qui.", 189 },
                    { 51, new DateTime(2021, 5, 5, 23, 31, 8, 407, DateTimeKind.Local).AddTicks(533), 3, 81, new DateTime(2021, 11, 14, 1, 42, 31, 343, DateTimeKind.Local).AddTicks(8245), new DateTime(2020, 9, 5, 0, 22, 34, 969, DateTimeKind.Local).AddTicks(9173), 4, null, null, "Dolorum laborum dicta vitae nesciunt.", 67 },
                    { 39, new DateTime(2020, 10, 12, 23, 24, 13, 133, DateTimeKind.Local).AddTicks(1341), 79, 39, new DateTime(2022, 4, 1, 12, 51, 37, 791, DateTimeKind.Local).AddTicks(1342), new DateTime(2021, 4, 2, 0, 57, 29, 37, DateTimeKind.Local).AddTicks(7293), 5, null, null, "Voluptate inventore dolor ut aliquam eligendi inventore numquam tempore dignissimos.", 80 },
                    { 14, new DateTime(2020, 10, 30, 20, 10, 32, 961, DateTimeKind.Local).AddTicks(3730), 20, 119, new DateTime(2022, 8, 6, 14, 20, 59, 702, DateTimeKind.Local).AddTicks(1641), new DateTime(2021, 5, 23, 6, 59, 11, 786, DateTimeKind.Local).AddTicks(3854), 4, null, null, "Laborum accusamus quaerat. Ut deleniti fuga error laudantium est qui nulla. Dolorem voluptates soluta. Qui ea ad tempore eius temporibus reiciendis. Aut et possimus dolorum. Aut quo ut et neque nulla voluptatem nemo fugiat.", 167 },
                    { 114, new DateTime(2021, 7, 19, 20, 50, 42, 915, DateTimeKind.Local).AddTicks(7431), 20, 3, new DateTime(2021, 11, 22, 3, 35, 1, 691, DateTimeKind.Local).AddTicks(372), new DateTime(2020, 8, 29, 14, 51, 54, 574, DateTimeKind.Local).AddTicks(9729), 2, null, null, "Rerum molestias sed ut.\nSit officia facilis id fugiat sunt.\nNumquam qui numquam expedita necessitatibus.\nDolorum impedit aut quo.", 110 },
                    { 146, new DateTime(2020, 10, 5, 21, 24, 51, 757, DateTimeKind.Local).AddTicks(4761), 20, 91, new DateTime(2022, 5, 6, 10, 25, 20, 301, DateTimeKind.Local).AddTicks(3689), new DateTime(2021, 4, 6, 2, 40, 54, 369, DateTimeKind.Local).AddTicks(167), 5, null, null, "Voluptatem omnis exercitationem et.\nSint consequatur vel perferendis non.\nVelit corporis expedita ut alias aut aliquid ut sit voluptatibus.\nDolorem nulla laboriosam.", 249 },
                    { 121, new DateTime(2021, 4, 13, 22, 31, 9, 437, DateTimeKind.Local).AddTicks(6408), 73, 85, new DateTime(2022, 2, 4, 23, 44, 48, 200, DateTimeKind.Local).AddTicks(802), new DateTime(2020, 8, 31, 21, 0, 37, 131, DateTimeKind.Local).AddTicks(1574), 4, null, null, "Consequatur veniam consequatur. Magni similique et laboriosam qui odit necessitatibus. Voluptatum totam facilis dolorem. Omnis quasi at aut vel nesciunt quas. Fuga fugiat explicabo rerum suscipit ea. Culpa natus id.", 283 },
                    { 106, new DateTime(2021, 5, 18, 4, 6, 42, 898, DateTimeKind.Local).AddTicks(4177), 10, 11, new DateTime(2022, 6, 26, 13, 54, 19, 845, DateTimeKind.Local).AddTicks(820), new DateTime(2020, 11, 27, 18, 16, 0, 963, DateTimeKind.Local).AddTicks(9879), 3, null, null, "Eveniet sunt nulla eaque pariatur quia.", 162 },
                    { 46, new DateTime(2021, 5, 24, 5, 34, 39, 676, DateTimeKind.Local).AddTicks(1919), 10, 118, new DateTime(2021, 12, 2, 0, 21, 12, 923, DateTimeKind.Local).AddTicks(8804), new DateTime(2021, 4, 10, 12, 29, 20, 352, DateTimeKind.Local).AddTicks(6780), 5, null, null, "quaerat", 203 },
                    { 112, new DateTime(2020, 12, 8, 23, 28, 0, 211, DateTimeKind.Local).AddTicks(7474), 3, 68, new DateTime(2022, 4, 17, 19, 6, 46, 570, DateTimeKind.Local).AddTicks(5465), new DateTime(2021, 3, 5, 1, 1, 54, 877, DateTimeKind.Local).AddTicks(5487), 5, null, null, "Aut qui ut ipsa aut corporis est. Eos eos minima libero reprehenderit quae deserunt delectus. Dignissimos voluptates magni voluptas. In aut ut laudantium labore.", 42 },
                    { 65, new DateTime(2020, 10, 17, 0, 36, 39, 123, DateTimeKind.Local).AddTicks(5550), 51, 109, new DateTime(2022, 6, 23, 22, 46, 0, 840, DateTimeKind.Local).AddTicks(1092), new DateTime(2021, 2, 24, 15, 37, 7, 695, DateTimeKind.Local).AddTicks(3449), 3, null, null, "Ut exercitationem recusandae numquam eum mollitia consequuntur sit occaecati. Vel accusantium voluptatem quas sequi aut a. Consequuntur modi ea nisi ex vitae magni fugiat non. Qui fugiat dolor rerum. Et error incidunt quo iure sed. Veritatis ratione sit similique aut occaecati atque qui.", 229 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 118, new DateTime(2020, 10, 26, 18, 48, 59, 867, DateTimeKind.Local).AddTicks(6423), 85, 33, new DateTime(2022, 5, 5, 9, 53, 52, 852, DateTimeKind.Local).AddTicks(4027), new DateTime(2020, 8, 31, 1, 12, 8, 765, DateTimeKind.Local).AddTicks(2516), 1, null, null, "veritatis", 251 },
                    { 183, new DateTime(2021, 4, 30, 10, 1, 27, 434, DateTimeKind.Local).AddTicks(5639), 2, 133, new DateTime(2022, 4, 1, 18, 3, 14, 945, DateTimeKind.Local).AddTicks(7798), new DateTime(2021, 2, 1, 1, 55, 56, 128, DateTimeKind.Local).AddTicks(5112), 4, null, null, "Nihil quas cupiditate ab voluptas vitae. Excepturi vel quaerat molestiae saepe temporibus. Quam quidem pariatur enim aliquid.", 9 },
                    { 152, new DateTime(2020, 10, 1, 11, 25, 57, 674, DateTimeKind.Local).AddTicks(8540), 71, 111, new DateTime(2021, 9, 14, 9, 55, 47, 910, DateTimeKind.Local).AddTicks(7559), new DateTime(2021, 8, 26, 3, 13, 29, 639, DateTimeKind.Local).AddTicks(554), 2, null, null, "consectetur", 87 },
                    { 186, new DateTime(2021, 1, 27, 13, 12, 25, 556, DateTimeKind.Local).AddTicks(2472), 85, 9, new DateTime(2021, 10, 18, 11, 52, 19, 990, DateTimeKind.Local).AddTicks(5623), new DateTime(2021, 3, 29, 16, 8, 39, 201, DateTimeKind.Local).AddTicks(4977), 4, null, null, "Iusto exercitationem natus.\nFugit dolores ut mollitia beatae soluta sapiente.\nQui consequatur officia illo itaque architecto.\nEt quam quae illum maxime ut ut et nobis officia.\nDebitis veritatis quos architecto vel est esse.\nTempora molestias voluptatibus blanditiis dicta sit est error.", 101 },
                    { 188, new DateTime(2021, 1, 5, 16, 48, 28, 81, DateTimeKind.Local).AddTicks(8229), 80, 126, new DateTime(2022, 8, 26, 15, 28, 27, 172, DateTimeKind.Local).AddTicks(3991), new DateTime(2021, 3, 23, 19, 38, 45, 474, DateTimeKind.Local).AddTicks(6503), 3, null, null, "Nulla iusto qui delectus. Atque aut suscipit voluptatem eum perspiciatis provident dolor et aliquid. Totam nihil consequuntur. Quia aut quaerat voluptas ducimus sed cupiditate. Mollitia non eos neque esse eos odit minima repellat.", 78 },
                    { 85, new DateTime(2021, 8, 14, 3, 25, 50, 149, DateTimeKind.Local).AddTicks(572), 80, 146, new DateTime(2021, 12, 22, 7, 37, 44, 527, DateTimeKind.Local).AddTicks(7589), new DateTime(2021, 6, 19, 12, 19, 6, 269, DateTimeKind.Local).AddTicks(1089), 4, null, null, "Sequi consectetur distinctio repellendus laboriosam laboriosam iusto ea nihil.\nSapiente quis doloribus consequatur dicta dolor velit aut.\nEnim totam omnis vel et incidunt eos quasi nostrum.\nFugit sapiente velit et ut.\nRecusandae qui voluptatem vitae rerum blanditiis et.\nEveniet qui provident optio.", 48 },
                    { 62, new DateTime(2021, 6, 14, 6, 46, 6, 554, DateTimeKind.Local).AddTicks(4290), 80, 108, new DateTime(2021, 12, 8, 3, 52, 56, 235, DateTimeKind.Local).AddTicks(2475), new DateTime(2021, 1, 31, 10, 28, 0, 12, DateTimeKind.Local).AddTicks(6211), 3, null, null, "Cumque necessitatibus laboriosam voluptas autem.", 115 },
                    { 3, new DateTime(2020, 12, 23, 20, 39, 35, 62, DateTimeKind.Local).AddTicks(4057), 80, 53, new DateTime(2022, 4, 17, 9, 31, 16, 461, DateTimeKind.Local).AddTicks(7426), new DateTime(2020, 12, 15, 14, 28, 57, 978, DateTimeKind.Local).AddTicks(643), 1, null, null, "Dolor saepe est illum deserunt.\nSequi voluptatem et repellat vel delectus voluptatibus facilis non.\nAut tempore qui quod possimus laborum consequatur.\nEst magni et quisquam officiis nostrum.", 39 },
                    { 6, new DateTime(2021, 5, 9, 9, 41, 2, 859, DateTimeKind.Local).AddTicks(5695), 14, 7, new DateTime(2022, 2, 12, 18, 21, 3, 50, DateTimeKind.Local).AddTicks(9275), new DateTime(2021, 8, 10, 15, 1, 38, 97, DateTimeKind.Local).AddTicks(7946), 4, null, null, "necessitatibus", 121 },
                    { 23, new DateTime(2021, 1, 21, 18, 55, 52, 263, DateTimeKind.Local).AddTicks(1300), 14, 110, new DateTime(2021, 10, 23, 3, 34, 23, 84, DateTimeKind.Local).AddTicks(212), new DateTime(2020, 8, 30, 11, 19, 38, 676, DateTimeKind.Local).AddTicks(2505), 3, null, null, "Facilis placeat nihil quo aut rerum itaque et. Sunt asperiores soluta doloribus explicabo mollitia occaecati similique. Consequuntur ut alias porro quaerat eligendi deleniti. Deleniti repellat qui mollitia.", 169 },
                    { 141, new DateTime(2021, 4, 30, 14, 41, 37, 93, DateTimeKind.Local).AddTicks(5854), 14, 89, new DateTime(2022, 3, 7, 18, 52, 12, 286, DateTimeKind.Local).AddTicks(7579), new DateTime(2020, 10, 27, 1, 12, 59, 400, DateTimeKind.Local).AddTicks(9846), 1, null, null, "Reiciendis et aliquam ducimus nemo quam numquam sed neque sapiente. Et vel quibusdam velit tenetur autem. Placeat aut dolorem voluptas aut libero. Voluptas aut eveniet in non dolor ex. Occaecati incidunt totam. Voluptatibus ut recusandae rerum.", 92 },
                    { 161, new DateTime(2020, 12, 21, 6, 16, 40, 515, DateTimeKind.Local).AddTicks(9907), 14, 101, new DateTime(2022, 4, 12, 22, 53, 9, 743, DateTimeKind.Local).AddTicks(9656), new DateTime(2021, 4, 22, 11, 2, 57, 970, DateTimeKind.Local).AddTicks(2450), 1, null, null, "Sapiente aspernatur possimus est molestiae qui beatae.\nEnim enim tempore modi.\nSed voluptas ipsum officia voluptate.\nAliquam soluta ut debitis eaque accusamus repellendus eligendi fugiat esse.\nDolorum et enim excepturi reprehenderit.", 169 },
                    { 48, new DateTime(2020, 10, 4, 8, 55, 57, 434, DateTimeKind.Local).AddTicks(929), 82, 106, new DateTime(2022, 4, 2, 21, 38, 36, 989, DateTimeKind.Local).AddTicks(9792), new DateTime(2021, 7, 2, 22, 0, 11, 708, DateTimeKind.Local).AddTicks(817), 2, null, null, "Sint nihil iusto accusamus qui error corporis molestiae.", 110 },
                    { 167, new DateTime(2020, 9, 21, 22, 23, 15, 280, DateTimeKind.Local).AddTicks(6344), 82, 25, new DateTime(2022, 8, 26, 8, 9, 14, 608, DateTimeKind.Local).AddTicks(3151), new DateTime(2021, 8, 20, 7, 40, 51, 49, DateTimeKind.Local).AddTicks(9411), 4, null, null, "Ducimus eum distinctio sunt magnam consectetur.\nCumque minus ratione exercitationem maiores.\nSoluta provident commodi ut.", 65 },
                    { 38, new DateTime(2021, 6, 19, 15, 39, 40, 893, DateTimeKind.Local).AddTicks(4158), 2, 92, new DateTime(2021, 12, 30, 0, 46, 14, 451, DateTimeKind.Local).AddTicks(7911), new DateTime(2020, 11, 21, 3, 51, 17, 70, DateTimeKind.Local).AddTicks(4312), 4, null, null, "Aut neque quos sit ea non distinctio enim. Asperiores vero accusantium cumque ullam veniam eaque dicta. Delectus voluptates explicabo porro. Id aspernatur unde sunt numquam delectus nihil itaque laborum voluptatem.", 291 },
                    { 19, new DateTime(2021, 5, 16, 15, 57, 40, 637, DateTimeKind.Local).AddTicks(2370), 54, 13, new DateTime(2021, 10, 17, 6, 23, 53, 819, DateTimeKind.Local).AddTicks(4110), new DateTime(2020, 12, 14, 4, 33, 13, 443, DateTimeKind.Local).AddTicks(1935), 5, null, null, "Explicabo sed ad doloribus praesentium qui sint atque vero reiciendis.", 133 },
                    { 99, new DateTime(2020, 10, 15, 4, 11, 52, 501, DateTimeKind.Local).AddTicks(6752), 54, 73, new DateTime(2021, 11, 6, 14, 5, 31, 234, DateTimeKind.Local).AddTicks(7097), new DateTime(2021, 2, 22, 14, 50, 22, 148, DateTimeKind.Local).AddTicks(4585), 4, null, null, "Eum sit quod magni. Magnam rerum nisi reprehenderit debitis. Qui sed doloremque et velit exercitationem.", 225 },
                    { 182, new DateTime(2020, 9, 20, 4, 40, 32, 393, DateTimeKind.Local).AddTicks(4734), 13, 142, new DateTime(2022, 4, 29, 17, 17, 57, 20, DateTimeKind.Local).AddTicks(3900), new DateTime(2021, 6, 7, 19, 47, 35, 137, DateTimeKind.Local).AddTicks(5371), 1, null, null, "Distinctio corporis voluptatum ut quia illo et voluptatem eum ipsa.\nDebitis voluptate minima ut autem qui tenetur.\nLaboriosam totam ratione quos numquam ut molestiae ut natus eveniet.\nAdipisci corporis non vitae impedit nemo ut iste.", 283 },
                    { 80, new DateTime(2021, 5, 22, 7, 15, 22, 162, DateTimeKind.Local).AddTicks(9988), 13, 105, new DateTime(2021, 10, 10, 21, 35, 44, 475, DateTimeKind.Local).AddTicks(5809), new DateTime(2021, 8, 8, 18, 38, 8, 133, DateTimeKind.Local).AddTicks(8983), 4, null, null, "ex", 202 },
                    { 147, new DateTime(2021, 4, 28, 9, 21, 12, 876, DateTimeKind.Local).AddTicks(1345), 16, 40, new DateTime(2021, 9, 26, 6, 3, 57, 321, DateTimeKind.Local).AddTicks(4601), new DateTime(2021, 4, 18, 22, 6, 17, 885, DateTimeKind.Local).AddTicks(631), 3, null, null, "Optio voluptates et earum magni fugiat.\nNam fugiat corrupti quaerat et sint excepturi sed.\nEx quas quia nesciunt ut deserunt ducimus.\nRem cupiditate ipsam non ratione.\nDolor quisquam quis eius voluptas explicabo amet velit.\nEt voluptatem iure.", 130 },
                    { 88, new DateTime(2021, 2, 25, 11, 6, 48, 833, DateTimeKind.Local).AddTicks(9602), 16, 35, new DateTime(2021, 12, 19, 16, 53, 3, 957, DateTimeKind.Local).AddTicks(2971), new DateTime(2020, 10, 18, 8, 20, 38, 614, DateTimeKind.Local).AddTicks(4503), 1, null, null, "Alias hic quia vel. Id soluta enim eos saepe magni. Voluptatem illo qui aperiam sapiente culpa. Beatae saepe sed magnam quia.", 14 },
                    { 70, new DateTime(2021, 4, 26, 13, 16, 38, 975, DateTimeKind.Local).AddTicks(4782), 13, 65, new DateTime(2022, 6, 7, 22, 54, 30, 816, DateTimeKind.Local).AddTicks(2433), new DateTime(2021, 3, 1, 20, 41, 13, 261, DateTimeKind.Local).AddTicks(3878), 4, null, null, "aliquid", 269 },
                    { 122, new DateTime(2020, 11, 6, 18, 41, 56, 213, DateTimeKind.Local).AddTicks(7774), 65, 92, new DateTime(2022, 7, 10, 23, 17, 12, 643, DateTimeKind.Local).AddTicks(5352), new DateTime(2020, 11, 27, 9, 31, 52, 144, DateTimeKind.Local).AddTicks(6614), 2, null, null, "Perferendis facilis vitae qui explicabo. Ipsam aut sed. Consectetur consequuntur et. Quas id voluptate qui.", 270 },
                    { 140, new DateTime(2021, 6, 6, 8, 24, 0, 854, DateTimeKind.Local).AddTicks(7545), 2, 150, new DateTime(2022, 7, 20, 15, 7, 51, 509, DateTimeKind.Local).AddTicks(9838), new DateTime(2020, 9, 11, 8, 34, 13, 787, DateTimeKind.Local).AddTicks(3007), 3, null, null, "Enim aut maxime odio modi et odit enim nobis voluptas.\nCum maxime est asperiores saepe dignissimos tempora.\nMagni aperiam dolores non sit corrupti et perspiciatis.\nNesciunt eos repellat corrupti consequatur.", 14 },
                    { 179, new DateTime(2021, 2, 21, 23, 26, 10, 456, DateTimeKind.Local).AddTicks(2656), 82, 32, new DateTime(2021, 10, 7, 7, 45, 6, 257, DateTimeKind.Local).AddTicks(1368), new DateTime(2021, 6, 26, 22, 39, 17, 480, DateTimeKind.Local).AddTicks(3759), 4, null, null, "Ut facilis at sit quo totam. Numquam ut suscipit libero. Maiores nihil voluptas dolorem. Temporibus excepturi et. Est dolorem et est.", 52 },
                    { 131, new DateTime(2020, 11, 24, 15, 42, 57, 692, DateTimeKind.Local).AddTicks(6564), 25, 118, new DateTime(2022, 8, 18, 16, 44, 56, 287, DateTimeKind.Local).AddTicks(9016), new DateTime(2020, 10, 27, 10, 23, 35, 532, DateTimeKind.Local).AddTicks(2938), 4, null, null, "Consequatur laborum sint.\nEt delectus reiciendis iure molestias.\nOmnis quis culpa ut quod doloremque eos.\nIusto voluptatem natus in autem alias ea.\nFacilis sunt magnam deleniti quae.\nNeque nobis ab neque molestiae.", 119 },
                    { 178, new DateTime(2021, 2, 21, 10, 19, 27, 951, DateTimeKind.Local).AddTicks(8215), 25, 128, new DateTime(2022, 6, 16, 2, 15, 43, 953, DateTimeKind.Local).AddTicks(5364), new DateTime(2021, 1, 22, 11, 51, 17, 964, DateTimeKind.Local).AddTicks(1850), 2, null, null, "Quia voluptatem expedita unde aut consequuntur neque. Ut sapiente quidem. Veniam et inventore aut exercitationem alias. Minima quisquam distinctio beatae esse itaque veniam eligendi.", 119 },
                    { 34, new DateTime(2020, 9, 21, 1, 41, 7, 849, DateTimeKind.Local).AddTicks(9339), 10, 63, new DateTime(2022, 8, 9, 22, 59, 29, 289, DateTimeKind.Local).AddTicks(7444), new DateTime(2021, 4, 16, 18, 19, 43, 855, DateTimeKind.Local).AddTicks(7351), 2, null, null, "Cupiditate eaque omnis excepturi eum enim.\nAt aliquam sit et tempore.", 259 },
                    { 116, new DateTime(2021, 2, 1, 4, 0, 1, 131, DateTimeKind.Local).AddTicks(4818), 71, 42, new DateTime(2022, 5, 7, 16, 25, 40, 330, DateTimeKind.Local).AddTicks(1984), new DateTime(2021, 1, 20, 18, 33, 36, 904, DateTimeKind.Local).AddTicks(4950), 3, null, null, "Voluptate ea itaque omnis quo magnam neque.", 214 },
                    { 35, new DateTime(2021, 5, 9, 17, 2, 22, 949, DateTimeKind.Local).AddTicks(7122), 9, 8, new DateTime(2021, 11, 6, 14, 11, 59, 462, DateTimeKind.Local).AddTicks(5369), new DateTime(2020, 12, 3, 9, 47, 20, 753, DateTimeKind.Local).AddTicks(2821), 4, null, null, "Quas sint iure doloribus odio delectus quia veritatis magni eveniet.\nAdipisci maiores ipsa quia soluta et exercitationem.\nSit provident molestiae voluptatum animi nulla commodi voluptas tempora sit.\nEos facilis hic et sed eaque consequuntur qui fugiat.", 204 },
                    { 30, new DateTime(2021, 1, 4, 6, 56, 37, 783, DateTimeKind.Local).AddTicks(3547), 7, 27, new DateTime(2022, 2, 13, 18, 14, 55, 750, DateTimeKind.Local).AddTicks(7202), new DateTime(2021, 5, 24, 22, 8, 33, 714, DateTimeKind.Local).AddTicks(3212), 3, null, null, "eligendi", 52 },
                    { 191, new DateTime(2020, 11, 29, 19, 47, 8, 246, DateTimeKind.Local).AddTicks(6161), 63, 146, new DateTime(2022, 3, 13, 21, 45, 12, 6, DateTimeKind.Local).AddTicks(1084), new DateTime(2020, 8, 30, 10, 39, 13, 409, DateTimeKind.Local).AddTicks(3076), 5, null, null, "Ex voluptas et voluptatum officiis.\nDolores quisquam veniam incidunt quisquam.\nDeserunt ut aliquam ipsam est.\nQuidem ut quasi.", 204 },
                    { 49, new DateTime(2020, 10, 25, 16, 20, 44, 837, DateTimeKind.Local).AddTicks(2602), 17, 55, new DateTime(2022, 7, 12, 0, 0, 59, 263, DateTimeKind.Local).AddTicks(7164), new DateTime(2020, 12, 15, 19, 8, 56, 699, DateTimeKind.Local).AddTicks(9694), 4, null, null, "eveniet", 126 },
                    { 137, new DateTime(2021, 1, 18, 20, 47, 57, 284, DateTimeKind.Local).AddTicks(3649), 83, 112, new DateTime(2021, 9, 3, 2, 55, 21, 638, DateTimeKind.Local).AddTicks(5972), new DateTime(2021, 7, 25, 20, 30, 3, 346, DateTimeKind.Local).AddTicks(8808), 1, null, null, "Est cum aperiam qui exercitationem praesentium ullam vero atque.\nVoluptas sunt nam quia nihil.\nSit dolores qui illum cupiditate et qui aut ut.\nEnim ea distinctio voluptas dolore id est.\nUt natus veritatis est delectus ut at doloribus sunt minus.", 71 },
                    { 184, new DateTime(2021, 3, 29, 0, 42, 46, 473, DateTimeKind.Local).AddTicks(3310), 74, 70, new DateTime(2021, 12, 21, 2, 1, 24, 183, DateTimeKind.Local).AddTicks(6561), new DateTime(2020, 9, 15, 10, 42, 33, 574, DateTimeKind.Local).AddTicks(8753), 3, null, null, "Ut illo animi esse.\nEos qui modi ratione praesentium dignissimos id adipisci quos.\nConsequuntur ipsa et quia occaecati ipsam ullam necessitatibus.\nNobis fugiat eum laborum quos aperiam quia.", 57 },
                    { 174, new DateTime(2020, 12, 31, 7, 33, 32, 26, DateTimeKind.Local).AddTicks(5547), 11, 67, new DateTime(2021, 11, 12, 17, 7, 3, 405, DateTimeKind.Local).AddTicks(7272), new DateTime(2020, 9, 1, 5, 41, 44, 576, DateTimeKind.Local).AddTicks(9974), 3, null, null, "Dolore vero aperiam dolorem dolorum quas.", 123 },
                    { 95, new DateTime(2020, 10, 24, 18, 38, 37, 140, DateTimeKind.Local).AddTicks(9550), 81, 98, new DateTime(2021, 10, 19, 13, 1, 45, 196, DateTimeKind.Local).AddTicks(8685), new DateTime(2020, 12, 3, 13, 33, 45, 480, DateTimeKind.Local).AddTicks(7595), 2, null, null, "Est qui fuga. Corrupti fugit explicabo qui dolor in debitis. Officiis iste quas consequatur et dolorem velit voluptas voluptatem. Beatae eos quos aut omnis earum aliquid beatae et. Distinctio id quia velit quisquam vel.", 252 },
                    { 26, new DateTime(2021, 3, 31, 15, 39, 49, 693, DateTimeKind.Local).AddTicks(466), 74, 149, new DateTime(2022, 4, 19, 18, 46, 27, 92, DateTimeKind.Local).AddTicks(4693), new DateTime(2020, 10, 18, 22, 42, 29, 645, DateTimeKind.Local).AddTicks(9520), 2, null, null, "Optio aut expedita vero.\nExcepturi et at porro voluptatum et voluptas.\nVelit rerum ducimus minus velit nisi laborum saepe vel.\nQui consequuntur sequi molestias.\nVelit ullam illum ipsam quo et doloribus.\nEsse dolores accusamus ipsum et culpa itaque non et culpa.", 71 },
                    { 199, new DateTime(2021, 2, 12, 17, 45, 14, 921, DateTimeKind.Local).AddTicks(8104), 64, 141, new DateTime(2022, 5, 8, 0, 50, 14, 741, DateTimeKind.Local).AddTicks(5504), new DateTime(2020, 10, 8, 4, 10, 13, 657, DateTimeKind.Local).AddTicks(7232), 2, null, null, "Voluptates debitis dolores itaque excepturi.\nQui odio ut perspiciatis dignissimos qui fuga esse similique.\nCum quaerat voluptatem sapiente qui recusandae fugit laborum voluptate.\nSit sequi tenetur fugiat dolorem omnis laudantium.\nAssumenda in tenetur.\nQui dolores atque qui sit saepe aut.", 19 },
                    { 177, new DateTime(2021, 4, 22, 10, 53, 5, 765, DateTimeKind.Local).AddTicks(275), 64, 30, new DateTime(2021, 10, 29, 0, 41, 42, 563, DateTimeKind.Local).AddTicks(6640), new DateTime(2021, 1, 14, 13, 1, 50, 938, DateTimeKind.Local).AddTicks(6217), 2, null, null, "at", 24 },
                    { 169, new DateTime(2020, 10, 16, 9, 51, 18, 44, DateTimeKind.Local).AddTicks(6126), 15, 134, new DateTime(2021, 9, 11, 18, 12, 19, 995, DateTimeKind.Local).AddTicks(8352), new DateTime(2021, 2, 8, 3, 5, 49, 429, DateTimeKind.Local).AddTicks(274), 5, null, null, "eum", 112 },
                    { 102, new DateTime(2021, 1, 7, 15, 35, 29, 957, DateTimeKind.Local).AddTicks(9168), 11, 117, new DateTime(2022, 4, 1, 16, 16, 24, 356, DateTimeKind.Local).AddTicks(2765), new DateTime(2021, 2, 10, 14, 26, 30, 911, DateTimeKind.Local).AddTicks(2468), 1, null, null, "molestias", 39 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 132, new DateTime(2021, 3, 20, 5, 39, 44, 742, DateTimeKind.Local).AddTicks(536), 63, 20, new DateTime(2021, 9, 20, 17, 32, 20, 838, DateTimeKind.Local).AddTicks(3495), new DateTime(2020, 12, 4, 5, 54, 43, 721, DateTimeKind.Local).AddTicks(7711), 2, null, null, "Excepturi labore perspiciatis non sit.\nQuas molestias temporibus.\nSint debitis corporis quia voluptate dolores doloremque in quos.\nEveniet ullam culpa.\nVel temporibus laudantium provident dolores corporis voluptatem.", 94 },
                    { 28, new DateTime(2021, 6, 2, 2, 34, 39, 88, DateTimeKind.Local).AddTicks(1773), 39, 52, new DateTime(2021, 12, 22, 21, 5, 35, 263, DateTimeKind.Local).AddTicks(9417), new DateTime(2020, 12, 24, 17, 9, 30, 804, DateTimeKind.Local).AddTicks(8946), 1, null, null, "Non consequatur quis quam distinctio aperiam mollitia ut.\nQuis ipsam odio numquam.\nUnde maxime est tenetur.\nQuae repellat sapiente et.", 115 },
                    { 136, new DateTime(2021, 6, 23, 1, 46, 3, 606, DateTimeKind.Local).AddTicks(3377), 39, 101, new DateTime(2022, 7, 29, 7, 49, 28, 456, DateTimeKind.Local).AddTicks(2159), new DateTime(2020, 12, 22, 12, 26, 35, 510, DateTimeKind.Local).AddTicks(3936), 3, null, null, "quis", 212 },
                    { 195, new DateTime(2020, 10, 7, 8, 35, 22, 693, DateTimeKind.Local).AddTicks(5094), 39, 104, new DateTime(2021, 9, 14, 0, 34, 34, 388, DateTimeKind.Local).AddTicks(7394), new DateTime(2021, 8, 13, 20, 23, 10, 859, DateTimeKind.Local).AddTicks(4808), 2, null, null, "Provident corporis quia sed.\nAliquam eius doloremque reprehenderit est tempora et et nobis in.\nEt consectetur excepturi eum magnam error eum.\nDignissimos necessitatibus iure.\nCum aspernatur animi.\nAb ut occaecati ipsa sed quia provident quo id.", 212 },
                    { 157, new DateTime(2021, 4, 10, 2, 52, 26, 134, DateTimeKind.Local).AddTicks(7655), 1, 41, new DateTime(2022, 4, 12, 16, 44, 40, 335, DateTimeKind.Local).AddTicks(7228), new DateTime(2021, 2, 6, 15, 58, 51, 266, DateTimeKind.Local).AddTicks(5437), 5, null, null, "ut", 281 },
                    { 1, new DateTime(2020, 10, 18, 1, 10, 11, 698, DateTimeKind.Local).AddTicks(7876), 78, 75, new DateTime(2022, 6, 28, 6, 35, 38, 840, DateTimeKind.Local).AddTicks(480), new DateTime(2020, 9, 7, 11, 21, 46, 438, DateTimeKind.Local).AddTicks(6773), 3, null, null, "Eligendi et repellendus.", 291 },
                    { 91, new DateTime(2021, 2, 6, 3, 48, 14, 495, DateTimeKind.Local).AddTicks(6980), 76, 43, new DateTime(2021, 12, 11, 21, 25, 6, 523, DateTimeKind.Local).AddTicks(8995), new DateTime(2020, 10, 1, 5, 49, 41, 234, DateTimeKind.Local).AddTicks(5348), 5, null, null, "Temporibus ut autem. Velit dolor aut sed animi. Modi necessitatibus possimus aut incidunt ut voluptatem. Nobis ut quia minus dolor velit qui optio quis et.", 269 },
                    { 57, new DateTime(2020, 12, 13, 19, 58, 38, 151, DateTimeKind.Local).AddTicks(5849), 18, 18, new DateTime(2022, 1, 4, 17, 12, 54, 15, DateTimeKind.Local).AddTicks(569), new DateTime(2021, 1, 25, 11, 47, 49, 732, DateTimeKind.Local).AddTicks(9088), 2, null, null, "Rerum aliquam ullam fugit amet omnis.\nEt pariatur in dolor eos delectus nihil.\nQuia qui earum sint voluptate commodi.\nEligendi aut sequi distinctio dignissimos vitae.\nFacilis dolor illo.", 213 },
                    { 193, new DateTime(2020, 10, 14, 11, 31, 9, 485, DateTimeKind.Local).AddTicks(8089), 46, 86, new DateTime(2021, 10, 30, 14, 23, 16, 859, DateTimeKind.Local).AddTicks(8156), new DateTime(2020, 12, 4, 14, 21, 4, 922, DateTimeKind.Local).AddTicks(4893), 1, null, null, "Mollitia deserunt sunt qui unde assumenda. Officia facere quisquam delectus praesentium officiis numquam tempora. Sit cupiditate quas eos et voluptatem fuga. Ut sed rerum quibusdam sint. Id et ut et rerum voluptatum. Ipsum asperiores sed sit fugit incidunt quis ab.", 1 },
                    { 127, new DateTime(2021, 3, 6, 16, 13, 2, 655, DateTimeKind.Local).AddTicks(2548), 46, 50, new DateTime(2021, 12, 5, 8, 6, 47, 345, DateTimeKind.Local).AddTicks(6596), new DateTime(2021, 1, 23, 8, 19, 21, 906, DateTimeKind.Local).AddTicks(7239), 2, null, null, "suscipit", 210 },
                    { 135, new DateTime(2021, 7, 24, 3, 55, 36, 969, DateTimeKind.Local).AddTicks(363), 76, 121, new DateTime(2021, 11, 30, 12, 51, 30, 107, DateTimeKind.Local).AddTicks(9515), new DateTime(2021, 2, 25, 11, 40, 20, 605, DateTimeKind.Local).AddTicks(955), 1, null, null, "ut", 48 },
                    { 69, new DateTime(2021, 6, 23, 19, 15, 37, 988, DateTimeKind.Local).AddTicks(3531), 73, 81, new DateTime(2022, 1, 14, 7, 16, 51, 531, DateTimeKind.Local).AddTicks(2489), new DateTime(2021, 3, 22, 23, 49, 53, 946, DateTimeKind.Local).AddTicks(8220), 3, null, null, "Laborum reiciendis fugiat.", 270 },
                    { 96, new DateTime(2020, 11, 20, 4, 40, 27, 452, DateTimeKind.Local).AddTicks(1828), 73, 44, new DateTime(2022, 2, 10, 12, 7, 31, 466, DateTimeKind.Local).AddTicks(2695), new DateTime(2021, 1, 17, 7, 33, 13, 472, DateTimeKind.Local).AddTicks(5685), 3, null, null, "Labore tempore tempora.", 216 },
                    { 53, new DateTime(2021, 4, 2, 19, 14, 56, 46, DateTimeKind.Local).AddTicks(7623), 39, 150, new DateTime(2022, 8, 9, 11, 48, 49, 561, DateTimeKind.Local).AddTicks(9624), new DateTime(2021, 1, 27, 8, 49, 40, 794, DateTimeKind.Local).AddTicks(9916), 5, null, null, "Ut voluptates aut qui ex consequuntur ullam.", 23 },
                    { 47, new DateTime(2021, 7, 6, 3, 39, 45, 800, DateTimeKind.Local).AddTicks(2965), 63, 57, new DateTime(2022, 7, 9, 22, 35, 14, 277, DateTimeKind.Local).AddTicks(4710), new DateTime(2021, 2, 19, 21, 0, 23, 36, DateTimeKind.Local).AddTicks(1580), 1, null, null, "Dolores assumenda asperiores. Sapiente saepe iste culpa reprehenderit voluptas. Ratione magni harum enim aut libero rerum. Esse facere quia. Voluptas pariatur aliquam molestias facilis ullam eum molestiae quo. Quaerat voluptatem et qui sit quia.", 242 },
                    { 190, new DateTime(2021, 7, 21, 6, 15, 30, 728, DateTimeKind.Local).AddTicks(8498), 66, 2, new DateTime(2021, 10, 12, 22, 51, 14, 908, DateTimeKind.Local).AddTicks(7082), new DateTime(2021, 5, 5, 18, 58, 6, 498, DateTimeKind.Local).AddTicks(3543), 3, null, null, "enim", 9 },
                    { 134, new DateTime(2021, 7, 30, 19, 14, 39, 394, DateTimeKind.Local).AddTicks(8808), 41, 107, new DateTime(2022, 6, 2, 7, 27, 18, 206, DateTimeKind.Local).AddTicks(776), new DateTime(2021, 3, 24, 1, 3, 0, 94, DateTimeKind.Local).AddTicks(9642), 4, null, null, "consectetur", 89 },
                    { 111, new DateTime(2020, 11, 4, 18, 51, 38, 590, DateTimeKind.Local).AddTicks(2323), 22, 63, new DateTime(2022, 4, 15, 4, 42, 25, 435, DateTimeKind.Local).AddTicks(5246), new DateTime(2021, 1, 6, 6, 42, 16, 950, DateTimeKind.Local).AddTicks(4524), 1, null, null, "Et recusandae sapiente similique aliquam porro suscipit et et.", 57 },
                    { 7, new DateTime(2021, 5, 1, 15, 3, 24, 461, DateTimeKind.Local).AddTicks(2208), 84, 65, new DateTime(2022, 5, 21, 5, 30, 15, 761, DateTimeKind.Local).AddTicks(5949), new DateTime(2021, 4, 10, 23, 56, 39, 502, DateTimeKind.Local).AddTicks(8230), 5, null, null, "Sit harum occaecati.", 50 },
                    { 58, new DateTime(2020, 10, 20, 10, 10, 17, 320, DateTimeKind.Local).AddTicks(2662), 34, 109, new DateTime(2022, 4, 9, 14, 23, 16, 379, DateTimeKind.Local).AddTicks(6873), new DateTime(2021, 6, 13, 13, 33, 40, 920, DateTimeKind.Local).AddTicks(642), 1, null, null, "Velit numquam iusto.\nHarum nisi hic optio quaerat.\nVel ex fugit quia natus.\nSapiente non suscipit ut.", 121 },
                    { 124, new DateTime(2020, 12, 7, 3, 57, 38, 129, DateTimeKind.Local).AddTicks(7762), 34, 140, new DateTime(2022, 2, 8, 1, 0, 43, 846, DateTimeKind.Local).AddTicks(5307), new DateTime(2021, 2, 14, 12, 51, 39, 301, DateTimeKind.Local).AddTicks(6856), 4, null, null, "Minus ex unde quaerat eos fugit.\nVitae quibusdam aliquam velit veniam temporibus cupiditate maiores dolores.\nDolores nihil qui voluptatem quam amet accusantium aliquid.\nEos et fuga aut accusamus perferendis aut asperiores dolore qui.", 107 },
                    { 180, new DateTime(2021, 8, 14, 18, 9, 47, 793, DateTimeKind.Local).AddTicks(2741), 34, 56, new DateTime(2021, 9, 5, 20, 35, 31, 12, DateTimeKind.Local).AddTicks(420), new DateTime(2020, 9, 15, 21, 57, 7, 912, DateTimeKind.Local).AddTicks(2573), 3, null, null, "Hic ea nulla hic aut adipisci vero velit.", 174 },
                    { 9, new DateTime(2020, 10, 7, 0, 3, 58, 226, DateTimeKind.Local).AddTicks(6083), 84, 9, new DateTime(2022, 4, 27, 11, 5, 32, 743, DateTimeKind.Local).AddTicks(93), new DateTime(2021, 4, 23, 5, 46, 10, 95, DateTimeKind.Local).AddTicks(2988), 2, null, null, "Assumenda tenetur alias accusamus odit omnis laborum autem nihil recusandae. Nisi est totam amet veniam odit rerum voluptatem porro. Soluta odit a quis numquam et rerum voluptatem. Repellat reprehenderit exercitationem commodi et error quia excepturi fuga. Omnis natus sed consequuntur ipsum officia modi error. Eum veniam tempore est aspernatur ut sunt pariatur ipsa dolores.", 283 },
                    { 66, new DateTime(2021, 5, 29, 19, 37, 2, 640, DateTimeKind.Local).AddTicks(7382), 84, 131, new DateTime(2022, 8, 18, 7, 21, 14, 854, DateTimeKind.Local).AddTicks(3515), new DateTime(2021, 5, 20, 2, 14, 54, 706, DateTimeKind.Local).AddTicks(8026), 3, null, null, "Vitae repellat quasi doloribus temporibus est quia id perspiciatis. Earum molestiae ut similique laboriosam nihil neque. Nesciunt repellendus architecto laborum ut. Enim necessitatibus aut. Dolorem voluptates eius libero nostrum maiores. Ut quidem architecto ex dolores.", 145 },
                    { 75, new DateTime(2021, 3, 19, 12, 55, 29, 8, DateTimeKind.Local).AddTicks(684), 84, 22, new DateTime(2022, 5, 8, 1, 30, 26, 647, DateTimeKind.Local).AddTicks(72), new DateTime(2021, 4, 29, 0, 24, 47, 863, DateTimeKind.Local).AddTicks(4196), 3, null, null, "Sit placeat numquam quia quaerat perspiciatis molestiae.\nModi quia et provident quo enim minima voluptas ut.", 195 },
                    { 100, new DateTime(2020, 12, 17, 17, 21, 35, 632, DateTimeKind.Local).AddTicks(9353), 67, 112, new DateTime(2022, 4, 27, 17, 18, 34, 695, DateTimeKind.Local).AddTicks(1959), new DateTime(2021, 3, 2, 6, 10, 10, 188, DateTimeKind.Local).AddTicks(5851), 1, null, null, "Ut unde dicta ipsum velit ut.\nNon commodi quos sed dicta sint odit quo repellendus.", 235 },
                    { 87, new DateTime(2021, 2, 23, 14, 43, 26, 826, DateTimeKind.Local).AddTicks(5623), 84, 5, new DateTime(2021, 10, 27, 2, 4, 36, 750, DateTimeKind.Local).AddTicks(1468), new DateTime(2020, 12, 16, 19, 2, 48, 695, DateTimeKind.Local).AddTicks(101), 1, null, null, "Quibusdam vel vel modi aliquid atque.", 28 },
                    { 142, new DateTime(2021, 5, 2, 18, 4, 51, 659, DateTimeKind.Local).AddTicks(3715), 5, 143, new DateTime(2021, 10, 16, 9, 35, 34, 776, DateTimeKind.Local).AddTicks(647), new DateTime(2021, 5, 3, 10, 41, 44, 474, DateTimeKind.Local).AddTicks(5890), 4, null, null, "Eos accusantium illum sequi.\nPossimus qui non perspiciatis.", 213 },
                    { 125, new DateTime(2021, 5, 28, 7, 15, 40, 50, DateTimeKind.Local).AddTicks(1025), 86, 79, new DateTime(2021, 10, 28, 1, 40, 35, 529, DateTimeKind.Local).AddTicks(503), new DateTime(2021, 5, 5, 2, 9, 13, 289, DateTimeKind.Local).AddTicks(747), 5, null, null, "Quia laudantium sed tempora ad mollitia sunt doloribus nobis.", 269 },
                    { 89, new DateTime(2021, 5, 6, 19, 52, 8, 892, DateTimeKind.Local).AddTicks(9812), 86, 67, new DateTime(2021, 12, 13, 1, 17, 18, 906, DateTimeKind.Local).AddTicks(6637), new DateTime(2021, 1, 18, 14, 15, 3, 536, DateTimeKind.Local).AddTicks(110), 4, null, null, "Rerum quas doloremque perspiciatis. Consectetur dolores quas dicta praesentium ex consequuntur perspiciatis aut qui. Aut natus qui. Ullam aut cumque et.", 78 },
                    { 72, new DateTime(2021, 4, 23, 11, 57, 8, 559, DateTimeKind.Local).AddTicks(6738), 86, 88, new DateTime(2022, 8, 9, 13, 48, 22, 805, DateTimeKind.Local).AddTicks(2736), new DateTime(2020, 12, 27, 11, 36, 10, 596, DateTimeKind.Local).AddTicks(4325), 3, null, null, "Sint ut error officiis quia magni ut illum assumenda iste.\nTotam deserunt quo modi ducimus sed provident consectetur.\nEx minus voluptatem.", 130 },
                    { 63, new DateTime(2020, 10, 6, 12, 18, 20, 940, DateTimeKind.Local).AddTicks(2693), 67, 145, new DateTime(2021, 12, 8, 9, 9, 13, 489, DateTimeKind.Local).AddTicks(23), new DateTime(2021, 7, 10, 7, 47, 4, 510, DateTimeKind.Local).AddTicks(5839), 2, null, null, "minima", 89 },
                    { 43, new DateTime(2021, 5, 13, 23, 51, 46, 936, DateTimeKind.Local).AddTicks(9700), 86, 36, new DateTime(2022, 3, 15, 8, 40, 40, 37, DateTimeKind.Local).AddTicks(6485), new DateTime(2021, 1, 10, 10, 55, 36, 294, DateTimeKind.Local).AddTicks(8027), 3, null, null, "Accusantium rerum cumque et ipsa est placeat in quo qui.", 14 },
                    { 17, new DateTime(2021, 8, 3, 23, 23, 42, 482, DateTimeKind.Local).AddTicks(2353), 86, 29, new DateTime(2022, 6, 29, 7, 23, 41, 513, DateTimeKind.Local).AddTicks(95), new DateTime(2020, 10, 6, 9, 54, 15, 426, DateTimeKind.Local).AddTicks(6755), 1, null, null, "Nulla rerum dolore qui repellat consequuntur rerum rem. Aut voluptatum ipsam. Voluptas perferendis quae facilis expedita aut officiis. Voluptates id consequatur corrupti sint doloribus molestiae. Ut quis necessitatibus ullam repudiandae nihil. Quis et minus exercitationem voluptatem veniam odio ut quis.", 57 },
                    { 101, new DateTime(2021, 1, 8, 16, 56, 54, 163, DateTimeKind.Local).AddTicks(8740), 84, 24, new DateTime(2022, 1, 14, 6, 54, 6, 728, DateTimeKind.Local).AddTicks(8944), new DateTime(2021, 7, 3, 2, 8, 43, 233, DateTimeKind.Local).AddTicks(5522), 2, null, null, "Voluptates est sit est hic. Nemo autem voluptatibus quibusdam nemo nihil voluptatem. Ea quas magnam sint dolor dolor. Sunt facilis voluptatem voluptates corporis earum enim.", 210 },
                    { 150, new DateTime(2021, 6, 15, 21, 42, 45, 696, DateTimeKind.Local).AddTicks(2378), 84, 39, new DateTime(2022, 4, 14, 13, 24, 17, 903, DateTimeKind.Local).AddTicks(681), new DateTime(2021, 5, 22, 0, 20, 6, 141, DateTimeKind.Local).AddTicks(7201), 5, null, null, "Cumque enim et ullam expedita et molestiae reprehenderit et.\nEveniet est eos.\nAb eaque expedita.", 229 },
                    { 67, new DateTime(2021, 3, 8, 14, 25, 45, 461, DateTimeKind.Local).AddTicks(7860), 61, 107, new DateTime(2022, 8, 25, 22, 10, 45, 555, DateTimeKind.Local).AddTicks(2910), new DateTime(2021, 1, 2, 18, 18, 20, 643, DateTimeKind.Local).AddTicks(3936), 5, null, null, "Qui voluptate quia minus voluptatem omnis.", 259 },
                    { 153, new DateTime(2020, 9, 9, 7, 8, 7, 845, DateTimeKind.Local).AddTicks(8486), 84, 70, new DateTime(2022, 8, 19, 12, 3, 13, 71, DateTimeKind.Local).AddTicks(7737), new DateTime(2021, 3, 29, 3, 23, 16, 634, DateTimeKind.Local).AddTicks(892), 2, null, null, "Placeat non aut sit laudantium. Itaque eveniet accusantium magni nihil sit a quia dolorem. Odit nihil velit pariatur qui quae amet harum aperiam.", 28 },
                    { 176, new DateTime(2021, 7, 26, 5, 40, 50, 537, DateTimeKind.Local).AddTicks(7113), 84, 148, new DateTime(2022, 5, 29, 10, 32, 36, 708, DateTimeKind.Local).AddTicks(9528), new DateTime(2020, 10, 5, 18, 35, 10, 230, DateTimeKind.Local).AddTicks(1332), 3, null, null, "Quis quod molestiae voluptas omnis commodi omnis et sequi exercitationem.\nVitae perspiciatis inventore ipsum enim qui molestiae fugiat aut asperiores.\nQuibusdam corrupti qui molestiae perferendis nesciunt dignissimos tenetur velit amet.\nSoluta est distinctio explicabo voluptatem ut quis ut et.\nEst occaecati sit nostrum error debitis rerum eveniet.", 133 },
                    { 4, new DateTime(2020, 12, 31, 20, 30, 8, 221, DateTimeKind.Local).AddTicks(7578), 41, 83, new DateTime(2022, 7, 4, 21, 15, 58, 863, DateTimeKind.Local).AddTicks(2503), new DateTime(2020, 11, 5, 13, 24, 54, 354, DateTimeKind.Local).AddTicks(9869), 5, null, null, "et", 20 },
                    { 50, new DateTime(2021, 6, 6, 8, 22, 48, 733, DateTimeKind.Local).AddTicks(6228), 41, 44, new DateTime(2021, 10, 20, 12, 3, 16, 253, DateTimeKind.Local).AddTicks(2361), new DateTime(2021, 8, 25, 12, 54, 38, 435, DateTimeKind.Local).AddTicks(7539), 1, null, null, "Rerum dolorem accusantium eos minus alias debitis magni mollitia rerum.\nSaepe aut tenetur suscipit et libero nihil.\nOmnis id qui quis hic et esse.\nUt quae sint temporibus dolore repudiandae.\nEsse aut officiis sit et impedit molestias dolor.\nVeritatis laboriosam rerum illum sint doloremque similique occaecati.", 89 },
                    { 86, new DateTime(2021, 5, 7, 15, 15, 58, 499, DateTimeKind.Local).AddTicks(837), 41, 58, new DateTime(2022, 6, 1, 19, 13, 1, 86, DateTimeKind.Local).AddTicks(14), new DateTime(2020, 11, 22, 2, 39, 16, 308, DateTimeKind.Local).AddTicks(2739), 1, null, null, "Consequatur aut iste voluptatum ut qui odit.", 186 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 54, new DateTime(2021, 7, 6, 19, 27, 57, 177, DateTimeKind.Local).AddTicks(7208), 30, 108, new DateTime(2022, 7, 24, 1, 42, 18, 113, DateTimeKind.Local).AddTicks(2782), new DateTime(2020, 10, 12, 19, 11, 27, 998, DateTimeKind.Local).AddTicks(1754), 2, null, null, "saepe", 139 },
                    { 21, new DateTime(2020, 10, 23, 3, 47, 17, 282, DateTimeKind.Local).AddTicks(1406), 37, 44, new DateTime(2021, 10, 3, 10, 41, 59, 512, DateTimeKind.Local).AddTicks(5120), new DateTime(2020, 9, 5, 15, 12, 31, 72, DateTimeKind.Local).AddTicks(8782), 2, null, null, "eveniet", 100 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "CarId", "UserId" },
                values: new object[,]
                {
                    { 18, 174 },
                    { 77, 145 },
                    { 87, 101 },
                    { 58, 191 },
                    { 24, 80 },
                    { 74, 189 },
                    { 2, 204 },
                    { 1, 291 },
                    { 72, 182 },
                    { 6, 117 },
                    { 63, 187 },
                    { 41, 169 },
                    { 69, 269 },
                    { 86, 210 },
                    { 30, 252 },
                    { 9, 9 },
                    { 10, 251 },
                    { 20, 216 },
                    { 79, 182 },
                    { 43, 243 },
                    { 11, 203 },
                    { 45, 56 },
                    { 23, 269 },
                    { 51, 130 },
                    { 25, 212 },
                    { 65, 112 },
                    { 13, 214 },
                    { 71, 91 },
                    { 37, 42 },
                    { 67, 291 },
                    { 66, 48 },
                    { 33, 243 },
                    { 68, 80 },
                    { 64, 87 },
                    { 15, 283 },
                    { 39, 110 },
                    { 21, 251 },
                    { 75, 290 },
                    { 26, 91 },
                    { 19, 162 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "CarId", "UserId" },
                values: new object[,]
                {
                    { 47, 102 },
                    { 52, 225 },
                    { 89, 188 },
                    { 31, 242 },
                    { 57, 87 },
                    { 88, 191 },
                    { 60, 112 },
                    { 32, 121 },
                    { 53, 67 },
                    { 40, 132 },
                    { 28, 123 },
                    { 48, 188 },
                    { 8, 17 },
                    { 62, 195 },
                    { 29, 87 },
                    { 36, 39 },
                    { 76, 107 },
                    { 73, 235 },
                    { 46, 123 },
                    { 42, 281 },
                    { 17, 110 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_EngineId",
                table: "CarModels",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_ManufacturerId",
                table: "CarModels",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CarModels_Name",
                table: "CarModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_CityId",
                table: "CarServices",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_Name",
                table: "CarServices",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_OwnerId",
                table: "CarServices",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_Name",
                table: "Cities",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Name",
                table: "Countries",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Engines_FuelTypeId",
                table: "Engines",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_Name",
                table: "Engines",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FuelTypes_Name",
                table: "FuelTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CarId",
                table: "Maintenance",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_CarServiceId",
                table: "Maintenance",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_CountryId",
                table: "Manufacturers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_CarId",
                table: "ServiceRequest",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_CarServiceId",
                table: "ServiceRequest",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_StatusId",
                table: "ServiceRequest",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_UserCarsCarId_UserCarsUserId",
                table: "ServiceRequest",
                columns: new[] { "UserCarsCarId", "UserCarsUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_UserId",
                table: "ServiceRequest",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Status_Name",
                table: "Status",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_UserId",
                table: "UserCars",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CityId",
                table: "Users",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Username",
                table: "Users",
                column: "Username",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "ServiceRequest");

            migrationBuilder.DropTable(
                name: "CarServices");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "UserCars");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CarModels");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Engines");

            migrationBuilder.DropTable(
                name: "Manufacturers");

            migrationBuilder.DropTable(
                name: "FuelTypes");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
