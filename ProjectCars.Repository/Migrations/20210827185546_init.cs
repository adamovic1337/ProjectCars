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
                        principalColumn: "Id");
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sri Lanka" },
                    { 135, "Moldova" },
                    { 132, "Oman" },
                    { 131, "Niue" },
                    { 127, "Tokelau" },
                    { 126, "Ghana" },
                    { 125, "Andorra" },
                    { 122, "Gibraltar" },
                    { 121, "Heard Island and McDonald Islands" },
                    { 120, "Colombia" },
                    { 117, "Bermuda" },
                    { 116, "Guyana" },
                    { 115, "Sierra Leone" },
                    { 114, "Central African Republic" },
                    { 110, "Holy See (Vatican City State)" },
                    { 136, "Kyrgyz Republic" },
                    { 108, "Senegal" },
                    { 104, "Palau" },
                    { 103, "Trinidad and Tobago" },
                    { 102, "Republic of Korea" },
                    { 100, "Tuvalu" },
                    { 99, "South Africa" },
                    { 98, "Dominica" },
                    { 97, "Faroe Islands" },
                    { 96, "Guatemala" },
                    { 94, "United Kingdom" },
                    { 93, "Saint Vincent and the Grenadines" },
                    { 92, "Puerto Rico" },
                    { 90, "Guinea" },
                    { 88, "Saudi Arabia" },
                    { 85, "Honduras" },
                    { 105, "Antigua and Barbuda" },
                    { 138, "Ecuador" },
                    { 139, "Grenada" },
                    { 145, "Taiwan" },
                    { 200, "Aruba" },
                    { 199, "Nigeria" },
                    { 198, "Macedonia" },
                    { 195, "Philippines" },
                    { 193, "Monaco" },
                    { 192, "Timor-Leste" },
                    { 191, "Brazil" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 190, "Netherlands Antilles" },
                    { 188, "Denmark" },
                    { 185, "Ireland" },
                    { 184, "Slovakia (Slovak Republic)" },
                    { 183, "Rwanda" },
                    { 181, "Georgia" },
                    { 180, "Austria" },
                    { 176, "Croatia" },
                    { 174, "Singapore" },
                    { 173, "Maldives" },
                    { 146, "Vanuatu" },
                    { 148, "Mozambique" },
                    { 149, "Burkina Faso" },
                    { 150, "Turkey" },
                    { 154, "New Caledonia" },
                    { 155, "Malta" },
                    { 82, "South Georgia and the South Sandwich Islands" },
                    { 162, "Turks and Caicos Islands" },
                    { 165, "Romania" },
                    { 167, "Sudan" },
                    { 168, "Cote d'Ivoire" },
                    { 169, "Mongolia" },
                    { 171, "Japan" },
                    { 172, "Suriname" },
                    { 163, "Bangladesh" },
                    { 81, "United States of America" },
                    { 91, "Norway" },
                    { 79, "Israel" },
                    { 34, "Barbados" },
                    { 33, "Fiji" },
                    { 32, "Saint Kitts and Nevis" },
                    { 80, "Switzerland" },
                    { 30, "Greenland" },
                    { 29, "Kazakhstan" },
                    { 27, "Uzbekistan" },
                    { 26, "France" },
                    { 25, "Equatorial Guinea" },
                    { 24, "Papua New Guinea" },
                    { 23, "Serbia" },
                    { 22, "Jamaica" },
                    { 20, "Indonesia" },
                    { 19, "Lesotho" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 18, "Liechtenstein" },
                    { 17, "Kiribati" },
                    { 16, "Tonga" },
                    { 2, "Cocos (Keeling) Islands" },
                    { 3, "Spain" },
                    { 4, "Finland" },
                    { 5, "Armenia" },
                    { 6, "Cayman Islands" },
                    { 7, "Gambia" },
                    { 35, "Saint Pierre and Miquelon" },
                    { 8, "Poland" },
                    { 10, "Western Sahara" },
                    { 11, "Benin" },
                    { 12, "Iceland" },
                    { 13, "Uruguay" },
                    { 14, "Yemen" },
                    { 15, "Saint Helena" },
                    { 9, "Netherlands" },
                    { 36, "Azerbaijan" },
                    { 31, "Pitcairn Islands" },
                    { 38, "Seychelles" },
                    { 77, "Tunisia" },
                    { 76, "Uganda" },
                    { 75, "Antarctica (the territory South of 60 deg S)" },
                    { 74, "Albania" },
                    { 73, "Solomon Islands" },
                    { 72, "Northern Mariana Islands" },
                    { 70, "Panama" },
                    { 69, "Cyprus" },
                    { 68, "Tanzania" },
                    { 37, "Sweden" },
                    { 65, "Falkland Islands (Malvinas)" },
                    { 63, "El Salvador" },
                    { 62, "Angola" },
                    { 61, "Cook Islands" },
                    { 59, "Anguilla" },
                    { 67, "Botswana" },
                    { 57, "Hungary" },
                    { 40, "Latvia" },
                    { 58, "Burundi" },
                    { 42, "Malaysia" },
                    { 43, "Madagascar" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 44, "Bolivia" },
                    { 45, "Eritrea" },
                    { 41, "Haiti" },
                    { 48, "British Indian Ocean Territory (Chagos Archipelago)" },
                    { 49, "Guinea-Bissau" },
                    { 52, "Namibia" },
                    { 54, "Libyan Arab Jamahiriya" },
                    { 55, "Gabon" },
                    { 56, "India" },
                    { 47, "Guadeloupe" }
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
                    { 91, 1, "Elmiraside" },
                    { 274, 99, "South Rosalinda" },
                    { 176, 99, "Schultzburgh" },
                    { 168, 99, "Albertaburgh" },
                    { 122, 99, "East Annefurt" },
                    { 100, 98, "Lafayetteview" },
                    { 289, 97, "New Mitchelside" },
                    { 206, 97, "East Keagan" },
                    { 296, 94, "South Drake" },
                    { 297, 93, "Kemmerport" },
                    { 123, 93, "O'Konview" },
                    { 118, 93, "Yeseniamouth" },
                    { 256, 92, "Myrafort" },
                    { 288, 91, "South Bernardside" },
                    { 213, 91, "Samborough" },
                    { 190, 91, "Port Noemy" },
                    { 144, 91, "Greenshire" },
                    { 111, 91, "Eastonland" },
                    { 129, 100, "East Rubiemouth" },
                    { 87, 91, "Kulasbury" },
                    { 188, 100, "Johnsburgh" },
                    { 66, 103, "Johnsonland" },
                    { 127, 115, "South Elnaside" },
                    { 124, 115, "Rautown" },
                    { 294, 200, "Kylamouth" },
                    { 200, 110, "Schillermouth" },
                    { 57, 110, "West Ervin" },
                    { 90, 108, "Lednerchester" },
                    { 247, 105, "Connellyborough" },
                    { 65, 105, "Port Haylie" },
                    { 264, 104, "South Monty" },
                    { 246, 104, "Port Susie" },
                    { 208, 104, "West Judsonmouth" },
                    { 191, 104, "New Eileen" },
                    { 159, 104, "Parkerview" },
                    { 102, 104, "Lake Kaylee" },
                    { 46, 104, "VonRuedenfort" },
                    { 89, 103, "Port Erik" },
                    { 86, 103, "Romaguerafort" },
                    { 61, 102, "West Nikko" },
                    { 133, 115, "Murphyborough" },
                    { 34, 91, "Homenickbury" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 299, 88, "Lake Mattchester" },
                    { 98, 76, "North Corneliushaven" },
                    { 262, 75, "Alexandrostad" },
                    { 155, 75, "Maurinemouth" },
                    { 142, 75, "South Katlynburgh" },
                    { 1, 75, "Lake Aileenfort" },
                    { 284, 74, "North Alexandriaville" },
                    { 148, 74, "Todmouth" },
                    { 39, 73, "North Guillermoburgh" },
                    { 300, 72, "South Ellaberg" },
                    { 45, 72, "Lake Savion" },
                    { 113, 176, "North Diamondmouth" },
                    { 23, 70, "West Helgahaven" },
                    { 16, 70, "East Cristina" },
                    { 161, 68, "Abigailland" },
                    { 151, 67, "North Thea" },
                    { 279, 65, "Jaybury" },
                    { 252, 65, "West Alexanderside" },
                    { 287, 76, "Michaleshire" },
                    { 149, 90, "Waelchihaven" },
                    { 38, 77, "North Anastacio" },
                    { 245, 79, "Millsland" },
                    { 251, 88, "Collinsberg" },
                    { 230, 88, "North Kelli" },
                    { 214, 88, "Leannonview" },
                    { 182, 88, "Blandamouth" },
                    { 290, 85, "Dominicfurt" },
                    { 164, 85, "New Cassieview" },
                    { 51, 85, "O'Haraside" },
                    { 172, 82, "North Brandy" },
                    { 249, 81, "East Stephaniefort" },
                    { 243, 81, "Maribelburgh" },
                    { 171, 81, "Nolanbury" },
                    { 244, 80, "Aniyahview" },
                    { 126, 80, "Lake Everardo" },
                    { 116, 80, "Elainafort" },
                    { 43, 80, "East Reymundoville" },
                    { 31, 80, "Tillmanport" },
                    { 5, 80, "West Jarrod" },
                    { 181, 77, "West Cortez" },
                    { 225, 200, "New Laurenburgh" },
                    { 175, 200, "Vedafurt" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 20, 116, "Mikelburgh" },
                    { 271, 167, "New Maureen" },
                    { 160, 167, "Gianniland" },
                    { 146, 167, "Lake Faustinotown" },
                    { 59, 167, "North Carsonchester" },
                    { 235, 183, "Rickyton" },
                    { 50, 165, "McGlynnport" },
                    { 233, 184, "Boydhaven" },
                    { 82, 162, "West Darrel" },
                    { 42, 162, "Kaydenmouth" },
                    { 223, 155, "East Lessieton" },
                    { 202, 185, "North Collinshire" },
                    { 255, 185, "East Gunnerstad" },
                    { 226, 150, "Larissaborough" },
                    { 69, 150, "Lake Dixieton" },
                    { 26, 150, "Welchside" },
                    { 216, 149, "North Randall" },
                    { 178, 149, "North Elyseshire" },
                    { 109, 168, "Jesusmouth" },
                    { 27, 149, "Lake Gildaside" },
                    { 153, 168, "Orionland" },
                    { 269, 168, "Ethanshire" },
                    { 30, 176, "Michealberg" },
                    { 44, 180, "South Jena" },
                    { 93, 181, "Simonisshire" },
                    { 138, 173, "New Eloisa" },
                    { 68, 173, "Hackettchester" },
                    { 101, 181, "Laurelland" },
                    { 97, 183, "Ivahmouth" },
                    { 17, 172, "Berenicefurt" },
                    { 242, 171, "South Alford" },
                    { 145, 171, "Abbigailberg" },
                    { 131, 171, "Tremblayfort" },
                    { 81, 171, "South Otismouth" },
                    { 241, 169, "Lake Ricardo" },
                    { 84, 169, "North Juston" },
                    { 49, 169, "North Carmineberg" },
                    { 184, 183, "Simonisland" },
                    { 189, 183, "New Frederic" },
                    { 240, 168, "New Einoborough" },
                    { 80, 188, "Rickyfurt" },
                    { 135, 188, "New Nolachester" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 285, 148, "Fredmouth" },
                    { 198, 193, "Alfonsofurt" },
                    { 187, 127, "New Shyanne" },
                    { 72, 195, "Klingshire" },
                    { 248, 126, "New Alfonzomouth" },
                    { 166, 126, "Rosettabury" },
                    { 143, 126, "South Gersonview" },
                    { 62, 126, "Conroyshire" },
                    { 22, 198, "Huelview" },
                    { 83, 199, "Mohammedfort" },
                    { 94, 199, "Lake Clemmiemouth" },
                    { 261, 122, "North Gregoryhaven" },
                    { 95, 121, "North Ovaside" },
                    { 79, 121, "North Jenifer" },
                    { 11, 121, "Kuhnstad" },
                    { 36, 200, "South Dan" },
                    { 128, 117, "Naomishire" },
                    { 150, 116, "Metzmouth" },
                    { 152, 131, "South Halieland" },
                    { 227, 131, "Langoshbury" },
                    { 136, 132, "Port Joanniehaven" },
                    { 75, 193, "Port Markusberg" },
                    { 174, 148, "Lake Victorland" },
                    { 292, 190, "Isaiahville" },
                    { 277, 145, "Cormiermouth" },
                    { 268, 145, "West Quintenborough" },
                    { 234, 145, "Boylefurt" },
                    { 224, 145, "Schmittstad" },
                    { 218, 145, "Robertsburgh" },
                    { 40, 145, "Kadechester" },
                    { 60, 65, "Kertzmannbury" },
                    { 121, 139, "East Kelliefurt" },
                    { 15, 191, "Teaganland" },
                    { 286, 138, "Burniceland" },
                    { 58, 191, "Rainaburgh" },
                    { 267, 136, "Baileefort" },
                    { 92, 191, "Chrisside" },
                    { 199, 135, "Cummeratamouth" },
                    { 103, 135, "Joanyside" },
                    { 2, 135, "Port Kaela" },
                    { 96, 139, "North Mason" },
                    { 232, 63, "New Carolannemouth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 239, 70, "Klockoview" },
                    { 112, 32, "Zacheryport" },
                    { 4, 26, "Giuseppeland" },
                    { 154, 25, "Schneiderfurt" },
                    { 78, 25, "Montebury" },
                    { 41, 25, "East Shirleyshire" },
                    { 13, 23, "Cleofort" },
                    { 215, 22, "Hanefurt" },
                    { 186, 22, "Beattyborough" },
                    { 280, 27, "Rettahaven" },
                    { 119, 22, "West Blairfort" },
                    { 55, 22, "Emmaleeview" },
                    { 54, 22, "Daremouth" },
                    { 37, 22, "South Fritzport" },
                    { 231, 20, "Bertramland" },
                    { 139, 20, "Kingchester" },
                    { 219, 19, "North Katherynshire" },
                    { 212, 19, "Lake Jorgechester" },
                    { 115, 22, "New Henrystad" },
                    { 105, 29, "Langview" },
                    { 158, 29, "New Gunnerview" },
                    { 162, 29, "Roderickland" },
                    { 12, 35, "Lake Wilfredo" },
                    { 293, 34, "South Bonniebury" },
                    { 53, 34, "Tremblaychester" },
                    { 220, 33, "Lake Morrisview" },
                    { 204, 33, "North Tyrese" },
                    { 197, 33, "Port Eleazarview" },
                    { 193, 33, "Port Elta" },
                    { 194, 63, "Estellaport" },
                    { 32, 32, "Ettiehaven" },
                    { 291, 31, "West Alisha" },
                    { 283, 31, "Port Keyon" },
                    { 6, 31, "Denisshire" },
                    { 250, 30, "Port Lorena" },
                    { 228, 30, "Port Meggie" },
                    { 120, 30, "Reicherthaven" },
                    { 107, 30, "New Tyrique" },
                    { 56, 30, "Jalenmouth" },
                    { 217, 18, "New Sydni" },
                    { 167, 35, "Christianland" },
                    { 137, 18, "East Arnoldo" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 265, 17, "South Ebba" },
                    { 52, 7, "Lake Vickystad" },
                    { 3, 7, "Port Linnea" },
                    { 273, 6, "North Adah" },
                    { 209, 6, "Dayneborough" },
                    { 88, 6, "Kaydentown" },
                    { 63, 6, "Everettburgh" },
                    { 254, 5, "Port Constantin" },
                    { 14, 8, "South Johnnymouth" },
                    { 238, 5, "Lake Jessy" },
                    { 99, 5, "Reyfort" },
                    { 275, 4, "Port Reinholdchester" },
                    { 163, 4, "West Stefanie" },
                    { 141, 3, "Berylstad" },
                    { 73, 3, "South Xander" },
                    { 71, 3, "Walterview" },
                    { 67, 2, "Autumnhaven" },
                    { 165, 5, "Greentown" },
                    { 35, 9, "Lindgrentown" },
                    { 205, 9, "New Rodmouth" },
                    { 237, 9, "Judahfurt" },
                    { 157, 17, "East Freeman" },
                    { 114, 17, "Henrifurt" },
                    { 298, 15, "Pfefferport" },
                    { 282, 15, "Darrickhaven" },
                    { 221, 15, "Pagacberg" },
                    { 108, 15, "West Cletusview" },
                    { 266, 14, "Tyriquetown" },
                    { 195, 14, "Beierland" },
                    { 173, 14, "Bradtkefurt" },
                    { 85, 14, "Thelmaport" },
                    { 29, 14, "Treutelside" },
                    { 7, 14, "Dexterside" },
                    { 8, 12, "Biankaport" },
                    { 270, 11, "South Alexiefort" },
                    { 201, 11, "Port Bella" },
                    { 263, 10, "Lake Dantemouth" },
                    { 295, 9, "Stuartfurt" },
                    { 77, 18, "Weissnathaven" },
                    { 177, 35, "New Lexus" },
                    { 156, 176, "Tommieview" },
                    { 258, 40, "East Ruth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 19, 40, "New Bonniestad" },
                    { 222, 45, "Lake Kenny" },
                    { 47, 57, "Port Dayton" },
                    { 110, 41, "Lake Coltburgh" },
                    { 180, 41, "Anabellestad" },
                    { 185, 41, "Keeblerport" },
                    { 236, 56, "New Maiya" },
                    { 203, 56, "Lake Mafalda" },
                    { 18, 56, "Fritschside" },
                    { 272, 55, "Port Kellen" },
                    { 257, 42, "Leuschkefurt" },
                    { 28, 43, "Donnellyhaven" },
                    { 9, 40, "Watsicaport" },
                    { 259, 43, "Runtebury" },
                    { 70, 55, "Jazlynberg" },
                    { 33, 44, "Lake Yasmeenshire" },
                    { 48, 44, "South Frankfurt" },
                    { 132, 44, "North Camden" },
                    { 179, 44, "North Huberthaven" },
                    { 210, 44, "Botsfordport" },
                    { 21, 54, "Eraburgh" },
                    { 281, 52, "Smithchester" },
                    { 117, 48, "Lake Viviane" },
                    { 104, 47, "Batzfort" },
                    { 278, 45, "Port Delta" },
                    { 169, 45, "Alfredoside" },
                    { 260, 43, "Weimannstad" },
                    { 140, 57, "East Orrin" },
                    { 276, 45, "West Dashawn" },
                    { 125, 63, "Denafort" },
                    { 106, 37, "Lake Roxannechester" },
                    { 211, 62, "East Adanstad" },
                    { 196, 62, "North Leonieborough" },
                    { 10, 62, "Haucktown" },
                    { 74, 36, "Kesslertown" },
                    { 170, 37, "New Evangeline" },
                    { 76, 61, "Hyattstad" },
                    { 24, 36, "East Hank" },
                    { 25, 58, "Rempelburgh" },
                    { 207, 36, "Elsafurt" },
                    { 253, 58, "Connhaven" },
                    { 64, 58, "Bradville" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 147, 63, "Maggioshire" },
                    { 134, 38, "Runolfsdottirburgh" },
                    { 192, 36, "South Brenden" },
                    { 183, 38, "Powlowskichester" },
                    { 130, 63, "Fritschton" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 37, 1201, 4, "porro", 699 },
                    { 61, 1985, 2, "delectus", 344 },
                    { 8, 1908, 4, "quia", 364 },
                    { 82, 2266, 4, "rerum", 596 },
                    { 84, 2490, 4, "facilis", 279 },
                    { 57, 1553, 2, "eum", 542 },
                    { 46, 1536, 2, "soluta", 668 },
                    { 42, 2028, 2, "maxime", 371 },
                    { 33, 2891, 2, "laboriosam", 140 },
                    { 29, 2337, 2, "perspiciatis", 355 },
                    { 25, 1213, 2, "in", 474 },
                    { 71, 1822, 4, "unde", 485 },
                    { 16, 2548, 4, "qui", 478 },
                    { 18, 1797, 4, "aperiam", 233 },
                    { 45, 1854, 2, "animi", 456 },
                    { 66, 2684, 4, "magni", 164 },
                    { 20, 2794, 4, "id", 421 },
                    { 10, 1479, 4, "fuga", 449 },
                    { 30, 2281, 1, "eveniet", 247 },
                    { 5, 1733, 2, "ab", 380 },
                    { 62, 2892, 2, "voluptates", 536 },
                    { 1, 2346, 3, "neque", 661 },
                    { 58, 2202, 3, "eaque", 434 },
                    { 50, 1051, 1, "et", 296 },
                    { 44, 2433, 1, "voluptas", 139 },
                    { 39, 1931, 3, "eos", 659 },
                    { 35, 2644, 3, "repellat", 625 },
                    { 11, 1406, 1, "est", 664 },
                    { 13, 1669, 1, "blanditiis", 621 },
                    { 43, 1470, 1, "quae", 306 },
                    { 28, 2620, 3, "consequatur", 107 },
                    { 23, 2455, 3, "aut", 597 },
                    { 41, 2255, 1, "pariatur", 500 },
                    { 3, 2941, 3, "quis", 582 },
                    { 19, 2224, 3, "repellendus", 569 },
                    { 14, 2575, 3, "dolorum", 371 },
                    { 26, 2667, 1, "nisi", 244 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 34, 1147, 1, "ad", 473 },
                    { 72, 1310, 2, "illum", 462 },
                    { 59, 1785, 1, "aspernatur", 593 },
                    { 70, 2810, 2, "labore", 204 },
                    { 60, 1946, 1, "vel", 598 },
                    { 17, 2714, 2, "provident", 568 },
                    { 4, 1762, 4, "impedit", 609 },
                    { 2, 1201, 4, "nobis", 163 },
                    { 12, 1245, 2, "voluptatem", 227 },
                    { 9, 1663, 2, "debitis", 307 },
                    { 65, 2616, 2, "velit", 154 },
                    { 98, 2175, 3, "adipisci", 621 },
                    { 7, 1469, 2, "sunt", 410 },
                    { 6, 2090, 4, "nulla", 130 },
                    { 27, 1111, 1, "fugit", 268 },
                    { 85, 2111, 1, "minima", 127 },
                    { 77, 2145, 1, "saepe", 688 },
                    { 68, 2199, 1, "consectetur", 222 },
                    { 93, 2974, 3, "ex", 364 },
                    { 69, 2827, 2, "nihil", 488 },
                    { 83, 2047, 3, "ut", 700 },
                    { 79, 2308, 3, "harum", 554 },
                    { 73, 2634, 3, "quasi", 675 },
                    { 96, 1195, 3, "optio", 179 },
                    { 40, 2866, 2, "suscipit", 390 },
                    { 100, 2532, 4, "iure", 214 },
                    { 92, 1270, 4, "itaque", 489 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 63, 174, "Brown, Torp and Bradtke" },
                    { 21, 35, "Mitchell, O'Connell and Fritsch" },
                    { 9, 37, "Muller - Prosacco" },
                    { 48, 37, "Kessler, Gleason and Runolfsdottir" },
                    { 45, 38, "Lueilwitz LLC" },
                    { 86, 41, "Kuphal, Gibson and Lowe" },
                    { 18, 44, "Kozey Inc" },
                    { 100, 44, "Bogan - Daugherty" },
                    { 26, 52, "Treutel Inc" },
                    { 78, 52, "Beier - Gislason" },
                    { 23, 54, "Bauch - Koss" },
                    { 13, 59, "Armstrong, Maggio and Jerde" },
                    { 6, 62, "Medhurst LLC" },
                    { 14, 63, "Gottlieb Inc" },
                    { 58, 65, "Cormier - Sporer" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 91, 65, "Hayes, Toy and Witting" },
                    { 60, 67, "Oberbrunner and Sons" },
                    { 17, 81, "Larson, Kunde and D'Amore" },
                    { 43, 81, "Mohr Group" },
                    { 94, 81, "Crona, Daniel and Nader" },
                    { 62, 82, "Turner - Bednar" },
                    { 84, 34, "Macejkovic - Braun" },
                    { 71, 34, "Hackett, Lebsack and Hilll" },
                    { 4, 32, "Berge, Moore and Maggio" },
                    { 2, 32, "Osinski, Yost and Fritsch" },
                    { 76, 1, "Smitham, Windler and Gibson" },
                    { 51, 2, "Muller, Satterfield and Kshlerin" },
                    { 46, 5, "Treutel - Dickens" },
                    { 10, 6, "White, Weber and Parker" },
                    { 70, 6, "Quigley, Dicki and Smith" },
                    { 12, 7, "Gottlieb, Bruen and Stokes" },
                    { 50, 8, "Batz, Rice and Glover" },
                    { 95, 8, "Swift - Bartoletti" },
                    { 20, 10, "Kautzer - Runte" },
                    { 66, 13, "Turner - Deckow" },
                    { 87, 82, "Weber - Bergnaum" },
                    { 65, 14, "Ledner, Boehm and Funk" },
                    { 92, 15, "Murray and Sons" },
                    { 39, 17, "Cassin, Moen and Collier" },
                    { 80, 20, "Morar - Okuneva" },
                    { 5, 22, "Adams, Klocko and Becker" },
                    { 97, 23, "Gislason, Will and Rau" },
                    { 32, 25, "Homenick, Mueller and Kohler" },
                    { 19, 26, "Ruecker - Hauck" },
                    { 56, 30, "Marquardt, Strosin and Flatley" },
                    { 3, 31, "Dooley Inc" },
                    { 8, 31, "Ruecker LLC" },
                    { 64, 15, "Monahan Group" },
                    { 41, 90, "Welch, Oberbrunner and Sawayn" },
                    { 44, 90, "O'Keefe, Brekke and Kihn" },
                    { 54, 90, "Padberg - Rice" },
                    { 31, 192, "Kemmer - Monahan" },
                    { 30, 192, "Yundt, Larson and Johnston" },
                    { 16, 191, "Funk - Stark" },
                    { 15, 191, "Nitzsche - Marquardt" },
                    { 89, 135, "Mertz, Spencer and Gorczany" },
                    { 27, 136, "Marks LLC" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 72, 138, "Cruickshank Group" },
                    { 67, 146, "Towne LLC" },
                    { 77, 148, "Lubowitz - Wisozk" },
                    { 98, 148, "Casper Inc" },
                    { 74, 150, "Kohler LLC" },
                    { 28, 154, "Veum Inc" },
                    { 99, 184, "Okuneva, Gutmann and Davis" },
                    { 68, 184, "Trantow - Gislason" },
                    { 69, 162, "Monahan, Casper and Lynch" },
                    { 90, 165, "Olson - Sporer" },
                    { 52, 168, "Ebert Inc" },
                    { 88, 168, "Gulgowski Group" },
                    { 25, 172, "Metz - Hilll" },
                    { 81, 181, "Hilll, Johnston and Reilly" },
                    { 59, 172, "Marvin - Sporer" },
                    { 34, 192, "Volkman - Cronin" },
                    { 36, 132, "O'Reilly, Klocko and Conn" },
                    { 24, 127, "Hoeger - Rau" },
                    { 83, 193, "Walsh - Kilback" },
                    { 82, 91, "Hagenes Group" },
                    { 11, 94, "Bogisich LLC" },
                    { 96, 94, "Lang - Casper" },
                    { 47, 97, "Hane - Tillman" },
                    { 49, 97, "Stroman, Fisher and Breitenberg" },
                    { 35, 99, "Abshire - Harris" },
                    { 53, 99, "Murazik, Leffler and Rogahn" },
                    { 75, 99, "Stamm Group" },
                    { 37, 102, "Bahringer - Nolan" },
                    { 7, 105, "Stark, Schiller and Lind" },
                    { 73, 174, "Lynch LLC" },
                    { 42, 105, "Beer and Sons" },
                    { 38, 115, "Kling, Hessel and Grant" },
                    { 79, 115, "Terry, Marvin and Rippin" },
                    { 55, 120, "Cronin Inc" },
                    { 29, 122, "Lakin, O'Conner and Douglas" },
                    { 40, 122, "Ritchie, Howe and Jacobs" },
                    { 57, 125, "Nitzsche - Ruecker" },
                    { 93, 195, "Rutherford Inc" },
                    { 1, 195, "Raynor LLC" },
                    { 33, 126, "Jacobson, Dickinson and Mraz" },
                    { 85, 193, "Moore - Torphy" },
                    { 61, 110, "Murazik, Gibson and Carter" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[] { 22, 92, "Wolf - Rolfson" });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 15, 100, 98, "ut" },
                    { 70, 57, 45, "odit" },
                    { 24, 46, 93, "repudiandae" },
                    { 5, 45, 47, "iusto" },
                    { 29, 42, 11, "qui" },
                    { 76, 40, 73, "adipisci" },
                    { 51, 12, 18, "veniam" },
                    { 7, 9, 16, "rerum" },
                    { 57, 7, 33, "delectus" },
                    { 64, 85, 12, "dolore" },
                    { 27, 77, 41, "omnis" },
                    { 10, 68, 24, "suscipit" },
                    { 21, 60, 76, "maxime" },
                    { 39, 59, 86, "aspernatur" },
                    { 16, 59, 9, "quo" },
                    { 12, 59, 97, "voluptate" },
                    { 90, 50, 87, "itaque" },
                    { 6, 44, 95, "est" },
                    { 9, 43, 93, "sed" },
                    { 23, 41, 3, "mollitia" },
                    { 3, 34, 90, "explicabo" },
                    { 93, 30, 36, "sunt" },
                    { 62, 30, 27, "ipsam" },
                    { 72, 13, 61, "placeat" },
                    { 55, 13, 2, "neque" },
                    { 36, 13, 4, "iste" },
                    { 30, 13, 63, "cupiditate" },
                    { 40, 11, 11, "minima" },
                    { 31, 62, 12, "ullam" },
                    { 53, 62, 84, "distinctio" },
                    { 35, 92, 31, "eos" },
                    { 73, 69, 85, "autem" },
                    { 87, 65, 43, "velit" },
                    { 32, 92, 59, "illum" },
                    { 20, 92, 67, "id" },
                    { 48, 82, 96, "voluptas" },
                    { 56, 71, 62, "totam" },
                    { 83, 66, 36, "expedita" },
                    { 26, 66, 29, "voluptatem" },
                    { 71, 18, 13, "molestiae" },
                    { 38, 18, 83, "et" },
                    { 77, 16, 8, "optio" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 17, 10, 86, "modi" },
                    { 4, 10, 60, "eius" },
                    { 14, 8, 69, "quia" },
                    { 61, 18, 47, "sint" },
                    { 63, 2, 49, "eum" },
                    { 67, 4, 27, "tempore" },
                    { 8, 70, 70, "aliquam" },
                    { 42, 72, 62, "nemo" },
                    { 44, 1, 57, "perspiciatis" },
                    { 2, 19, 86, "dolor" },
                    { 1, 28, 5, "sit" },
                    { 81, 3, 73, "ab" },
                    { 86, 69, 74, "non" },
                    { 88, 28, 41, "nulla" },
                    { 25, 39, 63, "quibusdam" },
                    { 37, 39, 77, "error" },
                    { 66, 93, 17, "perferendis" },
                    { 65, 28, 33, "aut" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 181, 57, "Donna62@gmail.com", "Gene", "Reynolds", "password123", 1, "Khalid81" },
                    { 227, 20, "Sincere.Hahn@yahoo.com", "Francesco", "Stamm", "password123", 3, "Savanna_Fisher7" },
                    { 96, 133, "Adaline_Ullrich@hotmail.com", "Michelle", "Conn", "password123", 2, "Luciano42" },
                    { 234, 124, "Serenity7@gmail.com", "Leonel", "Hermiston", "password123", 3, "Delfina18" },
                    { 29, 57, "Efrain_Bashirian82@yahoo.com", "Tod", "Ortiz", "password123", 1, "Neal.Swift84" },
                    { 102, 246, "Onie_McDermott@hotmail.com", "Julia", "Jacobi", "password123", 2, "Geovanni.Adams" },
                    { 183, 90, "Tabitha.King22@gmail.com", "Claire", "Kub", "password123", 2, "Isaias18" },
                    { 299, 247, "Sim_Corwin@yahoo.com", "Colten", "Veum", "password123", 3, "Kenna23" },
                    { 223, 247, "Laura.Stracke@gmail.com", "Delphia", "O'Conner", "password123", 1, "Gerry_Franecki" },
                    { 228, 264, "Effie52@gmail.com", "Bradford", "Jakubowski", "password123", 3, "Cleve_Johnston89" },
                    { 80, 150, "Mavis.Considine@yahoo.com", "Novella", "Hand", "password123", 1, "Trever19" },
                    { 290, 90, "Alison79@gmail.com", "Darius", "Rutherford", "password123", 1, "Kari_Powlowski" },
                    { 172, 150, "Elsie60@yahoo.com", "Jeanie", "Howe", "password123", 3, "Paula45" },
                    { 220, 96, "Kailey_Pagac47@yahoo.com", "Fabian", "Hand", "password123", 3, "Retta_Shields" },
                    { 225, 62, "Sidney.Aufderhar15@gmail.com", "Brendan", "Larkin", "password123", 1, "Ona_Lebsack4" },
                    { 271, 248, "Camille.Conroy@gmail.com", "Frederic", "Buckridge", "password123", 3, "Taylor_McGlynn48" },
                    { 8, 152, "Marcelo_McKenzie@hotmail.com", "Brycen", "Hilpert", "password123", 2, "Jerrell68" },
                    { 1, 136, "Wilbert32@gmail.com", "Lyla", "Schroeder", "password123", 1, "Korbin.Crona" },
                    { 50, 2, "Cristopher85@yahoo.com", "Emie", "Senger", "password123", 3, "Marion.Parisian" },
                    { 231, 2, "Cesar.Johns53@hotmail.com", "Cassidy", "Kautzer", "password123", 1, "Roman.Gorczany63" },
                    { 180, 199, "Bret_Pacocha80@hotmail.com", "Guiseppe", "Terry", "password123", 3, "Jamey.Botsford75" },
                    { 252, 267, "Brenda_Rau@gmail.com", "Gloria", "Lemke", "password123", 1, "Eliseo.Paucek72" },
                    { 272, 267, "Ellsworth14@gmail.com", "Alisha", "Stoltenberg", "password123", 1, "Lonny.Stark24" },
                    { 270, 286, "Bart_Wolf33@yahoo.com", "Dahlia", "Greenholt", "password123", 1, "Sherman_Conn" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 195, 96, "Brody_Kohler54@hotmail.com", "Herminio", "Goldner", "password123", 2, "Pascale.Schinner" },
                    { 97, 208, "Lura.Wuckert65@yahoo.com", "Piper", "Kulas", "password123", 2, "Albin21" },
                    { 167, 11, "Brandt.Volkman8@gmail.com", "Nels", "Ebert", "password123", 2, "Ludwig_Cartwright55" },
                    { 18, 102, "Jimmy_Towne37@gmail.com", "Chase", "Schaden", "password123", 2, "Lela_Raynor" },
                    { 38, 289, "Mozelle15@hotmail.com", "Norval", "Strosin", "password123", 1, "Stephania_Runolfsson91" },
                    { 212, 89, "Caleb97@yahoo.com", "Jacey", "Larkin", "password123", 3, "Hardy_Hickle97" },
                    { 288, 251, "Quentin.Satterfield@gmail.com", "Trisha", "Spencer", "password123", 3, "Kara69" },
                    { 140, 149, "Taya41@gmail.com", "Flo", "Ritchie", "password123", 1, "Barry97" },
                    { 193, 149, "Jeffery93@yahoo.com", "Domingo", "Hilpert", "password123", 1, "Lonzo_OConnell" },
                    { 43, 87, "Keshaun90@hotmail.com", "Arianna", "Quigley", "password123", 3, "Georgianna78" },
                    { 116, 111, "Marta32@yahoo.com", "Caitlyn", "Champlin", "password123", 1, "Leola_Champlin" },
                    { 268, 144, "Maritza_Tromp@yahoo.com", "Myles", "Schimmel", "password123", 2, "Elian18" },
                    { 92, 190, "Bill87@hotmail.com", "Veda", "Herman", "password123", 1, "Tessie.Kovacek" },
                    { 160, 190, "Kallie_Leffler16@yahoo.com", "Domenica", "Jacobson", "password123", 3, "Lenna.Schmeler81" },
                    { 122, 118, "Bryon.Greenfelder@yahoo.com", "Emely", "West", "password123", 2, "Rachael_Gulgowski" },
                    { 103, 123, "Melvin.Runte@gmail.com", "Chaz", "Kutch", "password123", 1, "Myrtice.Rosenbaum" },
                    { 262, 123, "Florence.Grimes@yahoo.com", "Trenton", "Cassin", "password123", 2, "Cooper_Schneider" },
                    { 135, 297, "Emma67@gmail.com", "Linnie", "Powlowski", "password123", 1, "Anderson_Smith" },
                    { 85, 296, "Dortha.Botsford43@gmail.com", "Michelle", "Larson", "password123", 1, "Cristobal.Sporer89" },
                    { 278, 296, "Carlie.Wehner85@gmail.com", "Violette", "Mayert", "password123", 2, "Kali80" },
                    { 74, 206, "Lula6@gmail.com", "Reynold", "Luettgen", "password123", 3, "Raphael8" },
                    { 17, 40, "Adan.Hahn@hotmail.com", "Allan", "Fritsch", "password123", 2, "Ernest.Reynolds51" },
                    { 28, 168, "Ian9@hotmail.com", "Addison", "Ruecker", "password123", 2, "Garrick_Kemmer16" },
                    { 60, 274, "Elisa_Rohan49@yahoo.com", "Orland", "Morar", "password123", 1, "Isidro65" },
                    { 253, 129, "Elton_Shanahan@yahoo.com", "Israel", "Johnson", "password123", 2, "Anastasia.Hoeger75" },
                    { 23, 188, "Janelle.Wisoky@hotmail.com", "Amari", "Heidenreich", "password123", 2, "Daron.Koch69" },
                    { 114, 188, "Juliana84@hotmail.com", "Jaunita", "Ferry", "password123", 1, "Dereck_Kuvalis" },
                    { 152, 188, "Cedrick_Jones61@gmail.com", "Immanuel", "Ruecker", "password123", 1, "Chadrick.Hermann" },
                    { 186, 188, "Breana.Gottlieb@gmail.com", "Ray", "Stoltenberg", "password123", 3, "Liana.Crooks97" },
                    { 41, 66, "Weldon.McDermott52@yahoo.com", "Federico", "Altenwerth", "password123", 2, "Blanche.Beatty31" },
                    { 283, 86, "Darlene_Hackett88@hotmail.com", "Elda", "Nolan", "password123", 2, "Unique_Mann51" },
                    { 188, 89, "Wilson_Huels78@hotmail.com", "Kraig", "O'Connell", "password123", 2, "Lorna_MacGyver47" },
                    { 203, 89, "Leland.Kling@yahoo.com", "Flo", "Klocko", "password123", 2, "Eloise_Stanton58" },
                    { 235, 89, "Flavio98@gmail.com", "Helena", "Nienow", "password123", 2, "Vern_Stanton52" },
                    { 297, 40, "Ned.Lehner48@gmail.com", "Efren", "Klocko", "password123", 3, "Jaquelin65" },
                    { 254, 82, "Sandy_Mante58@hotmail.com", "Emil", "Koch", "password123", 3, "Lily_Williamson" },
                    { 76, 218, "Maximillian_Macejkovic@hotmail.com", "Dayna", "Jenkins", "password123", 2, "Audrey_Gusikowski24" },
                    { 266, 138, "Amparo.Wuckert17@gmail.com", "Morgan", "Huels", "password123", 1, "Lindsay.Waters85" },
                    { 218, 30, "Elisha.Jaskolski@gmail.com", "Manuel", "Swaniawski", "password123", 3, "Leopoldo14" },
                    { 206, 113, "Jana.Pfannerstill@gmail.com", "Makenzie", "Senger", "password123", 1, "Rosalyn.Johnson36" },
                    { 5, 44, "Xander.Franecki@hotmail.com", "Christy", "Sporer", "password123", 1, "Ocie_Yundt8" },
                    { 39, 44, "Donnell39@hotmail.com", "Moises", "Yundt", "password123", 1, "Gloria_Bartell" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 245, 44, "Kacey0@hotmail.com", "Mozelle", "Gislason", "password123", 2, "Jack9" },
                    { 151, 93, "Tyreek58@hotmail.com", "Bria", "Dickinson", "password123", 1, "Cecelia_McDermott87" },
                    { 169, 93, "Burley_Robel@hotmail.com", "Jacinto", "Torp", "password123", 1, "Doris.Bode" },
                    { 184, 93, "Alize_Stiedemann49@gmail.com", "Otto", "Haag", "password123", 1, "Lavonne13" },
                    { 213, 101, "Caroline.Schmidt@gmail.com", "Gerard", "Ernser", "password123", 1, "Daphnee_Stark" },
                    { 47, 97, "Travis.Emard99@yahoo.com", "Sabryna", "Johnson", "password123", 2, "Florian_Anderson" },
                    { 84, 184, "Newell37@gmail.com", "Allie", "Rodriguez", "password123", 1, "Darius_Towne50" },
                    { 77, 138, "Francis.Legros@gmail.com", "Meaghan", "Shanahan", "password123", 2, "Shaniya.Rau" },
                    { 154, 233, "Kelsie.Crona@hotmail.com", "Rozella", "Boyle", "password123", 2, "Imelda54" },
                    { 89, 202, "Patience14@gmail.com", "Mortimer", "Dare", "password123", 3, "Randall_VonRueden" },
                    { 105, 202, "Shemar.Emmerich84@gmail.com", "Carmel", "Botsford", "password123", 3, "Jovanny.Watsica77" },
                    { 109, 80, "Rico12@gmail.com", "Marta", "Gislason", "password123", 1, "Kyra.Conroy10" },
                    { 261, 135, "Katelynn.Kuhn80@gmail.com", "Vesta", "Kautzer", "password123", 2, "Delta_OConnell92" },
                    { 263, 135, "Pauline_Herzog73@hotmail.com", "Leonel", "Batz", "password123", 1, "Karianne.Schmeler" },
                    { 20, 15, "Faustino_Erdman73@yahoo.com", "Caroline", "Cartwright", "password123", 2, "Mariano_Bartoletti97" },
                    { 40, 75, "Heather83@hotmail.com", "Melissa", "Volkman", "password123", 2, "Alex12" },
                    { 179, 75, "Leatha_Lowe98@gmail.com", "Zion", "Wiegand", "password123", 2, "Reyna.Macejkovic" },
                    { 61, 22, "Rasheed80@hotmail.com", "Raphael", "Kautzer", "password123", 2, "Reyes_Smitham69" },
                    { 215, 94, "Luella.Adams78@gmail.com", "Alize", "Russel", "password123", 3, "Casey.Spinka" },
                    { 19, 225, "Cristina_Welch@yahoo.com", "Monique", "Hoeger", "password123", 1, "Shanel86" },
                    { 34, 225, "Eden_Reynolds85@yahoo.com", "Larry", "Sawayn", "password123", 3, "Clark59" },
                    { 246, 233, "Jewell.Rolfson@gmail.com", "Eliane", "Ritchie", "password123", 2, "Geovanny_Beatty99" },
                    { 33, 68, "Christiana.Buckridge@yahoo.com", "Lindsey", "Mohr", "password123", 1, "Avery18" },
                    { 3, 68, "Garry_Hartmann81@yahoo.com", "Ruthe", "Koss", "password123", 2, "Jamey_Kautzer34" },
                    { 191, 131, "Rodolfo_Hansen@hotmail.com", "Enola", "Luettgen", "password123", 2, "Rashad95" },
                    { 247, 218, "Chaim9@gmail.com", "Dina", "Schamberger", "password123", 1, "Dewayne73" },
                    { 53, 224, "Fritz28@hotmail.com", "Michaela", "Yundt", "password123", 2, "Jada_Doyle" },
                    { 94, 268, "Alex.Conn@yahoo.com", "Emerson", "Muller", "password123", 2, "Jared.Mosciski" },
                    { 2, 277, "Ned.Armstrong16@yahoo.com", "Veronica", "Ruecker", "password123", 3, "Olaf16" },
                    { 86, 178, "Margarett_Braun@hotmail.com", "Dayton", "Heathcote", "password123", 2, "Erick_Hilpert" },
                    { 95, 216, "Morris_Romaguera@yahoo.com", "Drake", "Crist", "password123", 1, "Ronny_Botsford" },
                    { 241, 42, "Kristy_Gerlach@yahoo.com", "Lorena", "Bechtelar", "password123", 3, "Maggie16" },
                    { 7, 82, "Vladimir.Nitzsche58@hotmail.com", "Ada", "Stracke", "password123", 3, "Amie75" },
                    { 14, 82, "Alessia22@hotmail.com", "Taya", "Keebler", "password123", 1, "Nichole.Kovacek" },
                    { 136, 82, "Sheldon24@yahoo.com", "Mikayla", "Jacobs", "password123", 2, "Eda_Kunde54" },
                    { 194, 82, "Angelita57@gmail.com", "Deven", "Labadie", "password123", 2, "Macey.Borer87" },
                    { 138, 50, "Jaron21@gmail.com", "Rene", "Deckow", "password123", 1, "Rebecca.Schimmel" },
                    { 141, 59, "Alfonzo32@yahoo.com", "Monique", "Greenholt", "password123", 1, "Cody_Fay" },
                    { 251, 59, "Kevon.Gleason@hotmail.com", "Maximo", "Hermann", "password123", 1, "Abraham17" },
                    { 150, 146, "Sherman.Romaguera5@yahoo.com", "Wilmer", "Hirthe", "password123", 2, "Abel_Pollich" },
                    { 6, 271, "Eveline.Cummings49@yahoo.com", "Dale", "Torphy", "password123", 2, "Cyrus15" },
                    { 163, 271, "Shyann.Fadel63@hotmail.com", "Carolanne", "Towne", "password123", 1, "Nicholas.Hartmann65" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 78, 153, "Elias44@gmail.com", "Hadley", "Bernhard", "password123", 2, "Rory15" },
                    { 162, 153, "Rosalia_Rogahn@yahoo.com", "Leta", "Lakin", "password123", 2, "Elian_Klocko44" },
                    { 30, 240, "Al72@gmail.com", "Alvera", "Gutmann", "password123", 1, "Stone.Rutherford49" },
                    { 79, 269, "Carmine25@yahoo.com", "Alana", "Reinger", "password123", 2, "Jamil_Towne" },
                    { 139, 269, "Adah_Klocko66@gmail.com", "Nya", "Christiansen", "password123", 3, "Kyler_Auer66" },
                    { 285, 269, "Kaci.Moore@gmail.com", "Shemar", "Kshlerin", "password123", 1, "Arch26" },
                    { 293, 269, "Abbigail76@hotmail.com", "Willow", "Wuckert", "password123", 1, "Gerhard.Shields" },
                    { 51, 84, "Bridie.Schmeler@yahoo.com", "Allene", "Rutherford", "password123", 2, "Kailyn.White" },
                    { 149, 241, "Dolly_Cummings@hotmail.com", "Nola", "Larkin", "password123", 3, "Bernita53" },
                    { 88, 251, "Shawn39@gmail.com", "Leanne", "Lemke", "password123", 2, "Brice.OConnell" },
                    { 26, 218, "Beryl_Klein@hotmail.com", "Arnoldo", "Bergnaum", "password123", 2, "Albertha.Kub73" },
                    { 12, 81, "Elvie_Fahey@yahoo.com", "Abe", "Armstrong", "password123", 1, "Alan2" },
                    { 289, 182, "King.Jacobs94@yahoo.com", "Jovany", "Kuhic", "password123", 3, "Thaddeus83" },
                    { 230, 164, "Stevie26@gmail.com", "Ivah", "Murray", "password123", 1, "Octavia90" },
                    { 236, 105, "Queenie.Wehner@yahoo.com", "Matilde", "Lueilwitz", "password123", 2, "Bria_Kemmer" },
                    { 210, 4, "Gladys.Sipes29@gmail.com", "Genesis", "Satterfield", "password123", 1, "Mossie_Wolff33" },
                    { 189, 78, "Ismael.Gulgowski@gmail.com", "Bria", "Wiza", "password123", 3, "Deon.Dibbert" },
                    { 125, 78, "Winnifred_Mann79@hotmail.com", "Aleen", "Hickle", "password123", 3, "Frances.Marks77" },
                    { 199, 41, "Orpha_Moore@hotmail.com", "Alexie", "Dach", "password123", 3, "Freddie_Doyle" },
                    { 108, 41, "Austen.Casper25@yahoo.com", "Betty", "Green", "password123", 3, "Kaela_Douglas55" },
                    { 100, 41, "Marlee25@yahoo.com", "Kathlyn", "Pouros", "password123", 2, "Hipolito.Murphy79" },
                    { 75, 119, "Eva59@hotmail.com", "Maryse", "Will", "password123", 2, "Gennaro17" },
                    { 255, 162, "Rosalee1@yahoo.com", "Agnes", "Koelpin", "password123", 2, "Kyra.Wyman73" },
                    { 54, 119, "Frida93@yahoo.com", "Pablo", "Fritsch", "password123", 1, "Edwina_Bode38" },
                    { 55, 37, "Jodie.Ankunding62@hotmail.com", "Antonetta", "Wuckert", "password123", 3, "Ahmed.Reichel" },
                    { 173, 231, "Erling_Harris@gmail.com", "Athena", "Funk", "password123", 2, "Zion_Wuckert" },
                    { 198, 139, "Lane.Dibbert62@yahoo.com", "Micheal", "Rau", "password123", 1, "Bonnie.Fay" },
                    { 42, 212, "Ole44@yahoo.com", "Furman", "Spencer", "password123", 1, "Woodrow_White" },
                    { 143, 217, "Quinton.Schimmel@gmail.com", "Wellington", "Hegmann", "password123", 2, "Lonnie37" },
                    { 158, 137, "Rhianna70@yahoo.com", "Gretchen", "Bartell", "password123", 3, "Art16" },
                    { 24, 137, "Mac44@gmail.com", "Odell", "Hane", "password123", 2, "Erik60" },
                    { 187, 77, "Mariana.Hagenes@gmail.com", "Mason", "Torp", "password123", 3, "Toni_Schaefer" },
                    { 52, 54, "Eldon_Daniel@hotmail.com", "Ari", "Bergstrom", "password123", 1, "Rocky38" },
                    { 11, 56, "Ima29@hotmail.com", "Tiara", "Langosh", "password123", 3, "Kylie_Will0" },
                    { 59, 56, "Mary_Mohr49@yahoo.com", "Gaetano", "Howell", "password123", 3, "Zachary_Schuppe" },
                    { 110, 56, "Joelle_Herman77@hotmail.com", "Cathy", "Wiegand", "password123", 1, "Ruthe.Littel" },
                    { 62, 24, "Clotilde16@gmail.com", "Caterina", "Johns", "password123", 1, "Kristian56" },
                    { 81, 167, "Amely85@hotmail.com", "Aaliyah", "Grady", "password123", 3, "Sterling.Monahan" },
                    { 222, 12, "Eleanore_Schmitt28@gmail.com", "Marcelino", "Wehner", "password123", 2, "Axel.Parker" },
                    { 204, 53, "Jamel.Kuhlman@yahoo.com", "Jason", "Cummings", "password123", 3, "Casimer.Wiegand" },
                    { 111, 53, "Alex_Lehner@yahoo.com", "Adriel", "Grant", "password123", 3, "Tomas_Feil" },
                    { 298, 220, "Duane.Anderson@hotmail.com", "General", "Ortiz", "password123", 3, "Hazel98" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 274, 220, "Beth2@yahoo.com", "Kiarra", "Mayert", "password123", 1, "Trystan_Funk95" },
                    { 71, 220, "Odell_Feest36@gmail.com", "Floyd", "Schumm", "password123", 3, "Aiden_Ryan71" },
                    { 115, 204, "Curt.Hilll62@hotmail.com", "Ayla", "Vandervort", "password123", 1, "Otto.Ledner" },
                    { 64, 204, "Orion_Beier32@yahoo.com", "Van", "Sanford", "password123", 1, "Alexys59" },
                    { 249, 32, "Austyn_Littel73@yahoo.com", "Ashly", "Paucek", "password123", 1, "Malvina97" },
                    { 269, 291, "Hillard89@gmail.com", "Laurie", "Langworth", "password123", 2, "Petra.Swift" },
                    { 265, 291, "Loraine.Hilpert@hotmail.com", "Daisha", "Kilback", "password123", 2, "Corrine37" },
                    { 99, 291, "Dallas85@hotmail.com", "Shanna", "Homenick", "password123", 2, "Brent_Dickinson" },
                    { 238, 250, "Litzy_Hermiston@yahoo.com", "Therese", "Ruecker", "password123", 3, "General.Powlowski24" },
                    { 202, 228, "Myrtis.Bechtelar95@hotmail.com", "Felicia", "Langworth", "password123", 2, "Adonis77" },
                    { 155, 120, "Eliezer.Mueller@yahoo.com", "Aisha", "Marks", "password123", 2, "Noemi18" },
                    { 130, 120, "Casimir23@hotmail.com", "Cristobal", "Spencer", "password123", 3, "Velma63" },
                    { 123, 56, "Leila.McDermott35@hotmail.com", "Kimberly", "Hilll", "password123", 1, "Amy_Wolf50" },
                    { 178, 77, "Lila91@yahoo.com", "Alexandra", "Conn", "password123", 1, "Raegan.Heaney50" },
                    { 159, 24, "Emelie.Bauch@hotmail.com", "Nyasia", "Pfannerstill", "password123", 1, "Alden_Tremblay" },
                    { 68, 77, "Celine.Durgan@gmail.com", "Colleen", "Bergnaum", "password123", 2, "Adela_Rempel" },
                    { 185, 265, "Helena_Walsh@yahoo.com", "Eleazar", "Olson", "password123", 3, "Brielle64" },
                    { 170, 273, "Eldred_Quitzon16@gmail.com", "Else", "Grady", "password123", 2, "Fiona_Lynch" },
                    { 128, 209, "Florine.Hayes@hotmail.com", "Ralph", "Lynch", "password123", 2, "Myrtis_Hayes" },
                    { 300, 63, "Kaley_Lowe@hotmail.com", "Karine", "Dach", "password123", 1, "Jedidiah15" },
                    { 286, 63, "Kellie_Spinka@gmail.com", "Ally", "Lakin", "password123", 2, "Mina46" },
                    { 69, 63, "Damon_Labadie47@yahoo.com", "Kristin", "VonRueden", "password123", 2, "Gilberto85" },
                    { 44, 63, "Sylvia_Grimes26@hotmail.com", "Jasper", "McKenzie", "password123", 3, "Magdalen.Daugherty17" },
                    { 32, 63, "Susan_Beahan@yahoo.com", "Kristin", "Williamson", "password123", 3, "Miles42" },
                    { 9, 63, "Reinhold_Bogisich@gmail.com", "Mathilde", "Muller", "password123", 1, "Noemy_Cassin44" },
                    { 134, 3, "Ottilie53@gmail.com", "Dayna", "Abernathy", "password123", 2, "Cletus_Terry25" },
                    { 217, 254, "Jesse.Koch47@hotmail.com", "Alexane", "Cummerata", "password123", 1, "Stephon_Durgan" },
                    { 291, 165, "Ima_Frami78@yahoo.com", "Tressa", "Cartwright", "password123", 1, "Charley.Wuckert" },
                    { 233, 165, "Joanie_Hauck@gmail.com", "Zachary", "Hermann", "password123", 3, "Vivien77" },
                    { 224, 165, "Antonio34@hotmail.com", "Tyshawn", "Treutel", "password123", 3, "Rachel.Torphy70" },
                    { 144, 275, "Branson72@yahoo.com", "Lillian", "Maggio", "password123", 3, "Jamie93" },
                    { 164, 141, "Luna.Dach@hotmail.com", "Hillary", "Leffler", "password123", 3, "Callie.Becker74" },
                    { 156, 141, "Elenora.Swaniawski82@gmail.com", "Julia", "Streich", "password123", 2, "Emmett_Gaylord" },
                    { 37, 141, "Laisha_Hettinger@yahoo.com", "Horace", "Tillman", "password123", 3, "Alisha_Mitchell" },
                    { 56, 73, "Frederick_Lockman@yahoo.com", "Augusta", "Swaniawski", "password123", 1, "Maritza_Hayes8" },
                    { 137, 238, "Laron32@gmail.com", "Ashley", "Batz", "password123", 3, "Ford_Ondricka" },
                    { 229, 3, "Theresa_Bechtelar@yahoo.com", "Evans", "Jacobi", "password123", 2, "Tina.Tillman47" },
                    { 205, 14, "Johnathan_Johnson11@gmail.com", "Laura", "Baumbach", "password123", 1, "Muriel.Gutkowski53" },
                    { 46, 205, "Mallie70@hotmail.com", "Chester", "Nitzsche", "password123", 3, "Russ19" },
                    { 132, 157, "Charlene73@gmail.com", "Maybelle", "Rosenbaum", "password123", 1, "Judson_Kuphal57" },
                    { 282, 114, "Jaleel_Labadie9@yahoo.com", "Thomas", "Kling", "password123", 3, "Jade37" },
                    { 257, 114, "Thea66@yahoo.com", "Saige", "Schinner", "password123", 1, "Allan41" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 13, 114, "Malcolm.Hansen@hotmail.com", "Cassandre", "Heaney", "password123", 1, "Lavonne54" },
                    { 239, 282, "Haven_Rowe@hotmail.com", "Edna", "Doyle", "password123", 1, "Lois_Bashirian43" },
                    { 275, 108, "Lorine21@hotmail.com", "Josiane", "Schinner", "password123", 1, "Heloise_Morar45" },
                    { 129, 108, "Bella_Romaguera68@hotmail.com", "Emily", "Ferry", "password123", 2, "Bernadette.Schmeler23" },
                    { 267, 266, "Erin51@yahoo.com", "Harrison", "Witting", "password123", 3, "Bailee.Thompson90" },
                    { 4, 85, "Leonardo_Rosenbaum88@gmail.com", "Juvenal", "Cole", "password123", 3, "Geovanny_Langworth" },
                    { 284, 7, "Cassie67@hotmail.com", "Cale", "Abbott", "password123", 1, "Melba.Hyatt" },
                    { 279, 7, "Elody.Ledner51@yahoo.com", "Toney", "Ruecker", "password123", 1, "Zoe_Schroeder" },
                    { 126, 270, "Cyril47@hotmail.com", "Mable", "Dibbert", "password123", 3, "Alysa.Langosh97" },
                    { 216, 201, "Ava.Kuhlman@yahoo.com", "Reese", "Fahey", "password123", 1, "Bryana_Predovic91" },
                    { 192, 201, "Anais_Raynor56@yahoo.com", "Glenna", "Olson", "password123", 3, "Sophie_Graham86" },
                    { 176, 201, "Omer67@yahoo.com", "Wayne", "O'Kon", "password123", 2, "Tyshawn_Toy31" },
                    { 295, 237, "Elsa85@yahoo.com", "Sophie", "Hermann", "password123", 2, "Prince.Howell96" },
                    { 197, 237, "Libbie_Ankunding@gmail.com", "Chelsey", "McDermott", "password123", 1, "Foster.Stokes" },
                    { 57, 237, "Wilma21@gmail.com", "Lorenza", "Dooley", "password123", 1, "Javon61" },
                    { 276, 205, "Celestino.Smitham9@gmail.com", "Nelda", "Jacobs", "password123", 2, "Salvatore93" },
                    { 49, 77, "Eileen40@hotmail.com", "Amber", "Turcotte", "password123", 1, "Alexandrea.Tillman" },
                    { 240, 182, "Serena31@hotmail.com", "Rhianna", "Schimmel", "password123", 1, "Gail_Zulauf68" },
                    { 250, 24, "Norene11@gmail.com", "Alford", "Armstrong", "password123", 1, "Marcellus27" },
                    { 226, 207, "Willa39@yahoo.com", "Maryse", "Hoppe", "password123", 2, "Celia.Mohr" },
                    { 264, 287, "Mitchel.OHara@hotmail.com", "Alvina", "McCullough", "password123", 3, "Emmalee.Muller3" },
                    { 244, 287, "Merl1@hotmail.com", "Catherine", "Stark", "password123", 2, "Lyla_Johnson96" },
                    { 82, 287, "Josephine.Larkin@gmail.com", "Cierra", "Ebert", "password123", 3, "Edgardo48" },
                    { 260, 98, "Natalia.Klocko@gmail.com", "Scottie", "Grimes", "password123", 2, "Katlynn.Gerhold66" },
                    { 243, 98, "River_Blanda99@gmail.com", "Taurean", "DuBuque", "password123", 1, "Woodrow17" },
                    { 221, 155, "Filomena.Herzog40@hotmail.com", "Helen", "Moore", "password123", 2, "Henry_Lemke" },
                    { 232, 142, "Mike74@hotmail.com", "Jovanny", "Fahey", "password123", 2, "Pasquale.Purdy65" },
                    { 292, 1, "Casandra49@gmail.com", "Baron", "Aufderhar", "password123", 2, "Alize13" },
                    { 70, 38, "Deion_Treutel@yahoo.com", "Freeman", "Koss", "password123", 2, "Sophia.Cormier7" },
                    { 73, 1, "Emilie_Buckridge@yahoo.com", "Americo", "Kerluke", "password123", 2, "Dorthy_Mosciski" },
                    { 277, 148, "Alessandra.Schmeler@hotmail.com", "Clifford", "Brakus", "password123", 1, "Maci_Adams9" },
                    { 207, 148, "Drew.Schulist@yahoo.com", "Joany", "Boyle", "password123", 2, "Juliana79" },
                    { 294, 39, "Peggie.Murphy14@gmail.com", "Ofelia", "Davis", "password123", 2, "Mathias.Ledner53" },
                    { 120, 39, "Morton91@yahoo.com", "Emmet", "Sawayn", "password123", 3, "Harrison41" },
                    { 168, 300, "Kenna.Hegmann27@hotmail.com", "Mafalda", "Kessler", "password123", 2, "Christine91" },
                    { 161, 23, "Martina.Rice@gmail.com", "Glen", "Conroy", "password123", 3, "Freeman54" },
                    { 63, 16, "Jennifer41@gmail.com", "Seamus", "Weimann", "password123", 1, "Marianna_Mann45" },
                    { 177, 151, "Nia3@gmail.com", "Bart", "Bode", "password123", 1, "Keven_Satterfield" },
                    { 127, 284, "Peter60@hotmail.com", "Marie", "Koepp", "password123", 2, "Cleta.Witting26" },
                    { 142, 38, "Hal15@gmail.com", "Clementina", "Feil", "password123", 2, "Josianne31" },
                    { 209, 38, "Queenie.Cole@hotmail.com", "Bianka", "Dooley", "password123", 3, "Thea49" },
                    { 219, 181, "Mariam32@yahoo.com", "Stanley", "Bins", "password123", 2, "Nels_Zulauf0" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 121, 164, "Kelsie30@hotmail.com", "Kiana", "Hane", "password123", 1, "Carey.McCullough42" },
                    { 201, 51, "Marisa.Dickens@yahoo.com", "Kassandra", "Beer", "password123", 1, "Janick_Dicki85" },
                    { 190, 51, "Holden.Bahringer97@yahoo.com", "Shawna", "Blanda", "password123", 1, "Elyse_Purdy80" },
                    { 146, 51, "Turner_Schiller60@gmail.com", "Taya", "Kozey", "password123", 2, "Kyle97" },
                    { 281, 172, "Talia_Zboncak@yahoo.com", "Ewald", "Maggio", "password123", 3, "Milo_Franecki" },
                    { 113, 172, "Lillie89@yahoo.com", "Vaughn", "Upton", "password123", 3, "Roscoe_Marquardt6" },
                    { 16, 249, "Newton_Reynolds91@gmail.com", "Jenifer", "Steuber", "password123", 3, "Jalen_Emmerich" },
                    { 10, 171, "Deion.Jerde@hotmail.com", "Loyce", "Skiles", "password123", 1, "Felicita.Stanton" },
                    { 27, 126, "Julie.Stracke@gmail.com", "Chance", "Reichert", "password123", 2, "Skye_Rippin41" },
                    { 67, 116, "Jeffrey.Herzog@hotmail.com", "Karlee", "Ullrich", "password123", 1, "Isaac52" },
                    { 104, 43, "Amani_Bosco79@hotmail.com", "Johann", "Bradtke", "password123", 1, "Monty_Bartoletti55" },
                    { 15, 43, "Rosemarie.Rutherford@hotmail.com", "Clark", "Mertz", "password123", 2, "Brendan17" },
                    { 87, 31, "Clemmie.McGlynn@gmail.com", "Jovany", "Schmidt", "password123", 1, "Kieran_Schowalter" },
                    { 31, 5, "Vada.Okuneva45@hotmail.com", "Edgardo", "Sanford", "password123", 1, "Josie_Hoppe18" },
                    { 242, 245, "Oliver_Walsh55@yahoo.com", "Eldred", "Reilly", "password123", 2, "Stephan.Schaefer" },
                    { 171, 245, "Melany_Sawayn@yahoo.com", "Travon", "Stracke", "password123", 2, "Clair55" },
                    { 153, 245, "Josephine_Parisian91@gmail.com", "Niko", "Senger", "password123", 3, "Sophia_Collins14" },
                    { 148, 245, "Meagan_Ernser99@gmail.com", "Kayden", "McCullough", "password123", 1, "Nolan23" },
                    { 147, 245, "Aubree73@gmail.com", "Branson", "Wilkinson", "password123", 3, "Tommie.Boyle3" },
                    { 36, 151, "Corene_Parisian88@hotmail.com", "Velda", "Kassulke", "password123", 3, "Annie_Stokes" },
                    { 35, 192, "Nathan.Feeney82@yahoo.com", "Lester", "Beer", "password123", 2, "Tara_Sipes" },
                    { 157, 279, "Clarissa5@hotmail.com", "Jose", "Hoeger", "password123", 2, "Stacy_Hansen" },
                    { 91, 232, "Dessie.Wintheiser@hotmail.com", "Colten", "Hickle", "password123", 2, "Robyn.Towne" },
                    { 165, 117, "Dan47@gmail.com", "Elody", "Flatley", "password123", 3, "Gonzalo20" },
                    { 66, 117, "Ned21@yahoo.com", "Lea", "Kessler", "password123", 2, "Quinton50" },
                    { 21, 117, "Marlen_Bechtelar35@yahoo.com", "Lura", "Wolff", "password123", 1, "Breana_Dickens" },
                    { 182, 104, "Jaeden.Windler@gmail.com", "Elva", "Streich", "password123", 2, "Jameson82" },
                    { 256, 278, "Verna98@hotmail.com", "Camren", "Blanda", "password123", 2, "Dangelo15" },
                    { 101, 278, "Alford.Gusikowski@hotmail.com", "Baron", "Kulas", "password123", 2, "Onie_Nitzsche" },
                    { 237, 222, "Anthony35@hotmail.com", "Gregg", "Hansen", "password123", 2, "Collin.Streich92" },
                    { 200, 48, "Clifton_Hammes@gmail.com", "Vicenta", "Ortiz", "password123", 3, "Kurt.Padberg17" },
                    { 175, 117, "Theresa.Durgan41@hotmail.com", "Ruthie", "Welch", "password123", 2, "Assunta.Upton98" },
                    { 296, 259, "Dominique.Schmitt@yahoo.com", "Doris", "McLaughlin", "password123", 2, "Winnifred.Wiza" },
                    { 196, 28, "Pansy.Kiehn39@yahoo.com", "Alessia", "Wisoky", "password123", 1, "Barney_Strosin" },
                    { 131, 28, "Wiley.Trantow@yahoo.com", "Trevor", "Casper", "password123", 3, "Vernie_Wiza38" },
                    { 118, 257, "Ayla_Kreiger70@hotmail.com", "Andy", "Powlowski", "password123", 2, "Brandi_Bode34" },
                    { 25, 180, "Alanis8@yahoo.com", "Harold", "Kunze", "password123", 3, "Kathryne_Adams" },
                    { 287, 110, "Jody66@hotmail.com", "Mackenzie", "Morar", "password123", 1, "Gregg.Ziemann" },
                    { 211, 110, "Rick_Schaefer@yahoo.com", "Mateo", "Hodkiewicz", "password123", 1, "Anissa.Mueller" },
                    { 166, 19, "Guadalupe.Zboncak2@hotmail.com", "Nickolas", "Hamill", "password123", 3, "Elsa.Shanahan2" },
                    { 248, 170, "Naomi_Mraz71@hotmail.com", "Dion", "Ratke", "password123", 2, "Tamara_Boyer" },
                    { 145, 259, "Dock_Ferry@yahoo.com", "Nelda", "Heidenreich", "password123", 2, "Riley.Bergstrom42" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 45, 21, "Vesta44@yahoo.com", "Alberto", "Raynor", "password123", 1, "Hans.Hahn" },
                    { 133, 21, "Birdie74@gmail.com", "Ebony", "Von", "password123", 2, "Winifred.Hermiston74" },
                    { 117, 70, "Nicole.Brekke79@yahoo.com", "Irma", "Price", "password123", 2, "Tremayne.Schowalter" },
                    { 72, 232, "Zora_Baumbach12@gmail.com", "Aron", "Wiza", "password123", 2, "Felton_Beahan68" },
                    { 22, 232, "Broderick.Lebsack@yahoo.com", "Felicity", "West", "password123", 2, "Camren_Hills" },
                    { 208, 147, "Anika.Will@yahoo.com", "Nat", "Streich", "password123", 1, "Jevon_Champlin" },
                    { 119, 147, "Zita_Schowalter37@hotmail.com", "Oswaldo", "Farrell", "password123", 1, "Oda66" },
                    { 98, 130, "Betsy93@gmail.com", "Justine", "Anderson", "password123", 3, "Maximillia_Abbott68" },
                    { 258, 125, "Michael.Larkin51@yahoo.com", "Lia", "Rempel", "password123", 1, "Hudson43" },
                    { 214, 211, "Nyasia12@yahoo.com", "Rickey", "Rau", "password123", 1, "Rod62" },
                    { 65, 196, "Delbert_Bergnaum88@hotmail.com", "Darion", "Mante", "password123", 3, "Niko_Heathcote" },
                    { 90, 10, "Horace_Vandervort94@yahoo.com", "Erling", "VonRueden", "password123", 2, "Noelia48" },
                    { 124, 76, "Elmer59@yahoo.com", "Myrl", "Schumm", "password123", 3, "Jane.Sporer72" },
                    { 107, 76, "Shanny.McClure@gmail.com", "Ramona", "Emmerich", "password123", 1, "Geo.Dietrich" },
                    { 280, 253, "Nannie13@gmail.com", "Glenda", "Koch", "password123", 1, "Edmund99" },
                    { 83, 253, "Norval66@hotmail.com", "Mozelle", "Jenkins", "password123", 2, "Otho_Bosco83" },
                    { 58, 253, "Paxton94@hotmail.com", "Carmine", "Feest", "password123", 3, "Cletus.Durgan" },
                    { 48, 253, "Keshaun_Dickens8@yahoo.com", "Alessandra", "Dare", "password123", 2, "Ahmed87" },
                    { 106, 140, "Felipa_Cormier95@yahoo.com", "Nicole", "Lubowitz", "password123", 2, "Dejah_Donnelly44" },
                    { 259, 47, "Jaeden_Paucek@gmail.com", "Sammie", "Schiller", "password123", 2, "Carlo.Schiller" },
                    { 93, 47, "Catharine63@hotmail.com", "Dillon", "Mante", "password123", 3, "Meta.West" },
                    { 174, 203, "Alvis_Christiansen60@gmail.com", "Sabrina", "Lynch", "password123", 1, "Helena.Sauer18" },
                    { 112, 60, "Alexander8@gmail.com", "Maybell", "Gorczany", "password123", 1, "Frederic0" },
                    { 273, 91, "Sylvester_Marks68@yahoo.com", "Melody", "Hirthe", "password123", 3, "Marilou.King12" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 118, "Alexander Row", 168, "Iva.Bauch@gmail.com", "D'Amore - Quigley", 273, "(407) 326-0657", "www.D'Amore - Quigley.com" },
                    { 47, "Ankunding Roads", 96, "Cole_Sipes@gmail.com", "Olson, Homenick and Murazik", 209, "(554) 656-4281", "www.Olson, Homenick and Murazik.com" },
                    { 51, "Donnelly Plaza", 290, "Taya_Johnson13@gmail.com", "Gulgowski, Schultz and Bogan", 209, "(353) 891-3086", "www.Gulgowski, Schultz and Bogan.com" },
                    { 25, "Jade Lake", 227, "Erica61@gmail.com", "Zemlak - Bernhard", 147, "(249) 154-4151", "www.Zemlak - Bernhard.com" },
                    { 137, "Mark Spurs", 158, "Roselyn54@gmail.com", "Bailey and Sons", 147, "(580) 754-9437", "www.Bailey and Sons.com" },
                    { 21, "Heaney Light", 289, "Eloise66@gmail.com", "Turner - Harris", 153, "(360) 628-4801", "www.Turner - Harris.com" },
                    { 50, "Savannah Brooks", 257, "Zella.Shields90@gmail.com", "Moore, Walter and Hoppe", 153, "(451) 047-0016", "www.Moore, Walter and Hoppe.com" },
                    { 65, "Hettinger Mission", 76, "Christ29@hotmail.com", "Mraz, Conn and Denesik", 153, "(927) 758-3000", "www.Mraz, Conn and Denesik.com" },
                    { 69, "Torp Route", 125, "Vince80@yahoo.com", "Wilderman - Brakus", 153, "(426) 209-8761", "www.Wilderman - Brakus.com" },
                    { 26, "Balistreri Point", 67, "Hortense_Leannon@hotmail.com", "Rosenbaum - Kshlerin", 16, "(817) 288-2995", "www.Rosenbaum - Kshlerin.com" },
                    { 113, "Erika Shoals", 219, "Jake_Parker3@hotmail.com", "Feeney, Schmeler and Marks", 16, "(834) 575-3785", "www.Feeney, Schmeler and Marks.com" },
                    { 119, "Kihn Fort", 201, "Esteban17@yahoo.com", "Douglas Inc", 16, "(316) 356-0535", "www.Douglas Inc.com" },
                    { 34, "Bashirian Circles", 65, "Lessie38@gmail.com", "Bernhard, Rolfson and Hettinger", 289, "(323) 712-8655", "www.Bernhard, Rolfson and Hettinger.com" },
                    { 32, "McCullough Village", 205, "Chadd_Raynor75@gmail.com", "Terry, White and Schulist", 288, "(987) 034-8918", "www.Terry, White and Schulist.com" },
                    { 76, "Dominique Way", 8, "Bailey_Stoltenberg@gmail.com", "Hilll - Ratke", 288, "(280) 961-7160", "www.Hilll - Ratke.com" },
                    { 83, "Jeanie Locks", 227, "Arvel_Dibbert@yahoo.com", "Flatley - Ortiz", 288, "(899) 080-6527", "www.Flatley - Ortiz.com" },
                    { 12, "Nikko Meadow", 38, "Aurelia_Wolf75@hotmail.com", "Bernier - Mueller", 209, "(303) 927-3880", "www.Bernier - Mueller.com" },
                    { 63, "Ondricka Ramp", 35, "Karine.Bechtelar@yahoo.com", "Walsh, Koch and Monahan", 43, "(879) 045-6704", "www.Walsh, Koch and Monahan.com" },
                    { 117, "Beier Trail", 201, "Earline22@gmail.com", "Robel, Hudson and Stiedemann", 264, "(758) 307-8813", "www.Robel, Hudson and Stiedemann.com" },
                    { 68, "Gutkowski Place", 279, "Douglas_McClure18@hotmail.com", "Roberts, Tillman and Wunsch", 82, "(186) 865-7188", "www.Roberts, Tillman and Wunsch.com" },
                    { 16, "Kassulke Lights", 230, "Laurence_Rempel@gmail.com", "Paucek Group", 93, "(185) 870-6075", "www.Paucek Group.com" },
                    { 74, "Bins Path", 51, "Alessandra66@hotmail.com", "Swaniawski, Klocko and Ernser", 93, "(667) 741-7163", "www.Swaniawski, Klocko and Ernser.com" },
                    { 78, "Orville Village", 150, "Fermin72@hotmail.com", "Mraz - Reynolds", 93, "(469) 304-5413", "www.Mraz - Reynolds.com" },
                    { 6, "Bruen Circle", 270, "Clemmie_Bogan67@gmail.com", "Jenkins, Haley and Erdman", 58, "(502) 125-4015", "www.Jenkins, Haley and Erdman.com" },
                    { 31, "Meda Road", 3, "Maci_Prohaska@hotmail.com", "Tillman - Moen", 58, "(438) 688-3300", "www.Tillman - Moen.com" },
                    { 2, "Senger Flats", 212, "Alda_Rogahn@yahoo.com", "Huels - Lang", 124, "(302) 252-6085", "www.Huels - Lang.com" },
                    { 121, "Corkery Crossroad", 84, "Jade42@hotmail.com", "Waters - Stanton", 124, "(161) 837-6179", "www.Waters - Stanton.com" },
                    { 22, "Ruecker Meadows", 248, "Lee.Zulauf@yahoo.com", "Roob - Wintheiser", 65, "(203) 449-9709", "www.Roob - Wintheiser.com" },
                    { 41, "Vallie Pines", 189, "Retha5@hotmail.com", "Bednar Group", 65, "(861) 796-0865", "www.Bednar Group.com" },
                    { 98, "Leannon Islands", 124, "Eudora_Gerhold@gmail.com", "Kunde, Bashirian and Ritchie", 65, "(223) 436-5512", "www.Kunde, Bashirian and Ritchie.com" },
                    { 141, "Windler Village", 32, "Zane_Deckow48@yahoo.com", "Moore - Heaney", 65, "(887) 508-2102", "www.Moore - Heaney.com" },
                    { 122, "Joy Meadow", 20, "Josefa_Lubowitz@gmail.com", "Fadel Group", 98, "(009) 765-0386", "www.Fadel Group.com" },
                    { 48, "Goldner Lock", 25, "Bianka.Daniel@gmail.com", "Thiel, Brakus and Kuhlman", 36, "(473) 823-3168", "www.Thiel, Brakus and Kuhlman.com" },
                    { 134, "Beaulah Ways", 122, "Trisha53@hotmail.com", "Kemmer, Wuckert and Lowe", 36, "(175) 469-9348", "www.Kemmer, Wuckert and Lowe.com" },
                    { 56, "Garrick Well", 159, "Cristian_Denesik@yahoo.com", "Toy and Sons", 120, "(656) 304-6558", "www.Toy and Sons.com" },
                    { 33, "Aufderhar Circle", 157, "Anastacio49@gmail.com", "Gottlieb Inc", 264, "(524) 636-8539", "www.Gottlieb Inc.com" },
                    { 17, "Nolan Lane", 168, "Joshua.Davis@gmail.com", "Spencer Inc", 165, "(231) 134-3856", "www.Spencer Inc.com" },
                    { 93, "Gibson Groves", 256, "Alejandrin_Connelly@gmail.com", "Hand - Hintz", 43, "(329) 202-4675", "www.Hand - Hintz.com" },
                    { 55, "Gottlieb Mountains", 253, "Jordan_Morissette@hotmail.com", "Stiedemann Inc", 74, "(482) 547-6536", "www.Stiedemann Inc.com" },
                    { 36, "Schinner Trail", 19, "Priscilla.Jast17@hotmail.com", "Sanford - Aufderhar", 149, "(498) 084-8801", "www.Sanford - Aufderhar.com" },
                    { 60, "Maudie Groves", 297, "Karlie_Stark@hotmail.com", "Larson - Schinner", 149, "(670) 158-0203", "www.Larson - Schinner.com" },
                    { 5, "Emile Terrace", 111, "Vernice65@yahoo.com", "Blanda, Grimes and Robel", 218, "(768) 969-0467", "www.Blanda, Grimes and Robel.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 8, "Brandy View", 135, "Ettie.McKenzie81@yahoo.com", "Sporer, Gorczany and Abbott", 218, "(427) 274-0904", "www.Sporer, Gorczany and Abbott.com" },
                    { 20, "Baby Walk", 38, "Flavie86@gmail.com", "Bauch, Langosh and Leuschke", 218, "(801) 142-2486", "www.Bauch, Langosh and Leuschke.com" },
                    { 46, "Wuckert Forest", 14, "Era16@gmail.com", "Boyle and Sons", 218, "(894) 278-7680", "www.Boyle and Sons.com" },
                    { 116, "Aurore Pines", 255, "Bernice_Erdman@hotmail.com", "Romaguera - Kutch", 218, "(213) 721-8113", "www.Romaguera - Kutch.com" },
                    { 150, "Eldred Mills", 16, "Dylan60@yahoo.com", "Bauch LLC", 89, "(915) 598-1182", "www.Bauch LLC.com" },
                    { 1, "Lambert Inlet", 243, "Gilberto.McGlynn@gmail.com", "Abbott - Swaniawski", 105, "(507) 720-5019", "www.Abbott - Swaniawski.com" },
                    { 10, "Ward Forest", 70, "Darryl_Kuhic@hotmail.com", "Collins - Fisher", 105, "(805) 650-8299", "www.Collins - Fisher.com" },
                    { 19, "Ewald Fall", 143, "Anibal68@hotmail.com", "Gulgowski, Cummerata and Nader", 215, "(063) 142-4439", "www.Gulgowski, Cummerata and Nader.com" },
                    { 59, "Katrine Union", 195, "Chyna53@hotmail.com", "Glover, Hauck and Bauch", 215, "(046) 828-4850", "www.Glover, Hauck and Bauch.com" },
                    { 99, "Fern Junctions", 225, "Ashly20@hotmail.com", "Cartwright LLC", 215, "(993) 795-3706", "www.Cartwright LLC.com" },
                    { 124, "Rutherford Expressway", 21, "Yoshiko_Wisoky@gmail.com", "Schiller - Heller", 215, "(986) 875-1956", "www.Schiller - Heller.com" },
                    { 120, "Garrison Forks", 70, "Doug46@yahoo.com", "Kassulke and Sons", 34, "(527) 113-9242", "www.Kassulke and Sons.com" },
                    { 28, "Tom Port", 17, "Dane2@hotmail.com", "Schulist, Dibbert and Pollich", 149, "(260) 183-6127", "www.Schulist, Dibbert and Pollich.com" },
                    { 95, "Nitzsche Locks", 60, "Ocie.Denesik40@gmail.com", "Cummerata, Sanford and Sanford", 43, "(180) 371-1020", "www.Cummerata, Sanford and Sanford.com" },
                    { 133, "Gerard Terrace", 182, "Lourdes27@gmail.com", "Kovacek Group", 139, "(644) 832-9165", "www.Kovacek Group.com" },
                    { 145, "Wyman Stream", 185, "Abagail_Denesik@gmail.com", "Nolan, Jacobs and Greenholt", 254, "(541) 339-0143", "www.Nolan, Jacobs and Greenholt.com" },
                    { 80, "Eriberto Inlet", 42, "Miguel.Koelpin74@gmail.com", "Ortiz, Botsford and Smitham", 212, "(483) 221-3544", "www.Ortiz, Botsford and Smitham.com" },
                    { 107, "Stewart Spur", 146, "Lauriane.Kulas@gmail.com", "Fahey Inc", 228, "(237) 841-4759", "www.Fahey Inc.com" },
                    { 45, "Carolyn Spurs", 137, "Rylee_Hegmann49@yahoo.com", "Cassin and Sons", 299, "(594) 691-4973", "www.Cassin and Sons.com" },
                    { 114, "Melisa Estate", 165, "Leopold_Reichel7@yahoo.com", "Hermann Inc", 299, "(746) 046-3454", "www.Hermann Inc.com" },
                    { 18, "Jarvis Ramp", 93, "Dell_Leuschke@hotmail.com", "Schmidt, Barton and Donnelly", 234, "(702) 372-3826", "www.Schmidt, Barton and Donnelly.com" },
                    { 90, "Kenneth Fall", 175, "Ardella_Durgan@gmail.com", "Towne Group", 234, "(013) 988-2492", "www.Towne Group.com" },
                    { 64, "Gene Fork", 268, "Ada35@yahoo.com", "Runolfsson - Prohaska", 227, "(969) 846-0121", "www.Runolfsson - Prohaska.com" },
                    { 111, "Dexter Brook", 108, "Charles_Johnston@yahoo.com", "Jacobson LLC", 271, "(637) 968-3420", "www.Jacobson LLC.com" },
                    { 92, "Viola Path", 166, "Ashleigh1@yahoo.com", "Stracke and Sons", 50, "(143) 272-4075", "www.Stracke and Sons.com" },
                    { 110, "Schuster Burg", 252, "Raymundo73@yahoo.com", "Keeling, Herman and Hirthe", 50, "(601) 283-4658", "www.Keeling, Herman and Hirthe.com" },
                    { 108, "Frami Courts", 40, "Ardith.Haley@hotmail.com", "Koelpin, Friesen and Robel", 220, "(314) 243-8940", "www.Koelpin, Friesen and Robel.com" },
                    { 112, "Kallie Villages", 149, "Ethel.Stoltenberg40@gmail.com", "Vandervort - Jones", 220, "(263) 030-5132", "www.Vandervort - Jones.com" },
                    { 102, "Stella Coves", 79, "Tyrel_Schneider36@gmail.com", "Gutmann - Lemke", 297, "(235) 796-9402", "www.Gutmann - Lemke.com" },
                    { 24, "Kuhn Brook", 36, "Marisol_Lang@hotmail.com", "Hermiston, Schultz and Lehner", 241, "(563) 075-0014", "www.Hermiston, Schultz and Lehner.com" },
                    { 91, "Schaden Rapid", 180, "Jamaal_Reilly@hotmail.com", "Koss Group", 254, "(434) 742-9729", "www.Koss Group.com" },
                    { 39, "Reanna Corner", 67, "Franz36@gmail.com", "Hammes Group", 139, "(362) 470-8058", "www.Hammes Group.com" },
                    { 109, "Jedediah Highway", 69, "Dedric12@hotmail.com", "Runolfsson and Sons", 131, "(744) 807-4270", "www.Runolfsson and Sons.com" },
                    { 61, "Wisoky Club", 246, "Ludie46@gmail.com", "Schulist Group", 74, "(333) 623-6554", "www.Schulist Group.com" },
                    { 82, "Bartell Meadow", 227, "Emie.Ziemann@hotmail.com", "Kreiger LLC", 131, "(951) 929-9196", "www.Kreiger LLC.com" },
                    { 71, "Janet Mountain", 6, "Roy.Fahey2@gmail.com", "Hudson Group", 44, "(391) 741-4183", "www.Hudson Group.com" },
                    { 89, "Hettinger Harbor", 42, "Gerry.Nitzsche@gmail.com", "Batz, Torp and Harvey", 46, "(878) 833-5380", "www.Batz, Torp and Harvey.com" },
                    { 106, "Olson Run", 124, "Marcelo.Bashirian93@gmail.com", "Schmitt - Bahringer", 46, "(172) 859-7540", "www.Schmitt - Bahringer.com" },
                    { 43, "Carley Canyon", 199, "Lew49@gmail.com", "Brekke, O'Conner and Schulist", 192, "(691) 248-0614", "www.Brekke, O'Conner and Schulist.com" },
                    { 23, "Monahan Viaduct", 220, "Wallace40@yahoo.com", "Donnelly, Streich and Walker", 126, "(899) 905-4766", "www.Donnelly, Streich and Walker.com" },
                    { 131, "Mac Land", 75, "Madilyn7@yahoo.com", "Haag - Kuvalis", 126, "(696) 359-1675", "www.Haag - Kuvalis.com" },
                    { 132, "Bartoletti Ramp", 35, "Coby_Goyette71@yahoo.com", "Beer - Homenick", 126, "(596) 653-6251", "www.Beer - Homenick.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 77, "Ansley Drive", 99, "Pansy97@hotmail.com", "Streich - Hilll", 4, "(297) 811-9580", "www.Streich - Hilll.com" },
                    { 123, "Bins Summit", 175, "Woodrow_West@yahoo.com", "Kemmer - Keeling", 4, "(155) 516-2569", "www.Kemmer - Keeling.com" },
                    { 135, "Russel Orchard", 267, "Hillary_Kerluke75@hotmail.com", "Schultz and Sons", 4, "(424) 015-0014", "www.Schultz and Sons.com" },
                    { 79, "Ephraim Divide", 195, "Preston27@gmail.com", "Wisoky Inc", 267, "(997) 389-2876", "www.Wisoky Inc.com" },
                    { 100, "Johnson Overpass", 150, "Sim73@hotmail.com", "Sauer and Sons", 267, "(491) 448-0841", "www.Sauer and Sons.com" },
                    { 127, "Tomasa Viaduct", 111, "Willa41@hotmail.com", "Lueilwitz, Erdman and Kozey", 282, "(810) 255-5437", "www.Lueilwitz, Erdman and Kozey.com" },
                    { 52, "Marie Extension", 39, "Jonatan.Botsford60@gmail.com", "Hamill, Sawayn and Schroeder", 187, "(487) 085-2391", "www.Hamill, Sawayn and Schroeder.com" },
                    { 14, "Yessenia Pines", 291, "Joannie_Steuber99@gmail.com", "Marvin LLC", 158, "(903) 779-9398", "www.Marvin LLC.com" },
                    { 54, "Nienow Heights", 14, "Althea_Kshlerin@yahoo.com", "Ritchie - Robel", 44, "(768) 877-6110", "www.Ritchie - Robel.com" },
                    { 53, "Everett Pine", 200, "Troy_Bradtke@hotmail.com", "Ritchie Group", 55, "(459) 183-3250", "www.Ritchie Group.com" },
                    { 57, "Welch Summit", 129, "Kariane.Bruen25@yahoo.com", "Lakin, Gislason and Lang", 32, "(501) 523-6965", "www.Lakin, Gislason and Lang.com" },
                    { 138, "Sauer Groves", 245, "Eloise.Hodkiewicz96@gmail.com", "Medhurst Inc", 137, "(277) 942-2812", "www.Medhurst Inc.com" },
                    { 94, "Twila Way", 191, "Alena.Jacobi94@hotmail.com", "Hartmann Group", 131, "(824) 748-5688", "www.Hartmann Group.com" },
                    { 30, "Rowe Light", 248, "Yvette99@hotmail.com", "Wiza and Sons", 37, "(043) 876-0513", "www.Wiza and Sons.com" },
                    { 37, "Kshlerin Pass", 300, "Juliet_Swift@yahoo.com", "Wiegand LLC", 37, "(199) 182-6178", "www.Wiegand LLC.com" },
                    { 75, "Mraz Spring", 165, "Hillary17@gmail.com", "Murazik - Koelpin", 37, "(472) 096-9364", "www.Murazik - Koelpin.com" },
                    { 96, "Vinnie Mall", 242, "Alaina_OReilly68@yahoo.com", "Gulgowski and Sons", 37, "(498) 265-1169", "www.Gulgowski and Sons.com" },
                    { 13, "Kuhic Island", 213, "Hillard.Ferry@hotmail.com", "Borer, Leffler and Nienow", 164, "(212) 301-3753", "www.Borer, Leffler and Nienow.com" },
                    { 27, "Bode Valley", 55, "Dawn.Morar@hotmail.com", "Murphy - Koss", 144, "(222) 802-8555", "www.Murphy - Koss.com" },
                    { 35, "Edwina Common", 16, "Alison13@yahoo.com", "Cremin LLC", 144, "(591) 446-4345", "www.Cremin LLC.com" },
                    { 44, "Conroy Freeway", 62, "Cary_Balistreri@hotmail.com", "Feeney LLC", 144, "(940) 979-3951", "www.Feeney LLC.com" },
                    { 85, "Tremblay Courts", 46, "Florence_Frami72@hotmail.com", "Franecki Inc", 224, "(863) 844-7322", "www.Franecki Inc.com" },
                    { 97, "Hegmann Summit", 207, "Nelle_Strosin47@yahoo.com", "Jacobson, Gaylord and Dare", 233, "(456) 756-0559", "www.Jacobson, Gaylord and Dare.com" },
                    { 58, "Balistreri Harbors", 233, "Ezra54@gmail.com", "Lebsack - Boyer", 137, "(274) 675-3121", "www.Lebsack - Boyer.com" },
                    { 125, "Kiel Springs", 64, "Peyton.Koelpin3@yahoo.com", "Runolfsson - Wuckert", 137, "(605) 856-8493", "www.Runolfsson - Wuckert.com" },
                    { 126, "Schneider Fall", 207, "Mae.Grimes@hotmail.com", "Quigley Group", 137, "(857) 944-0728", "www.Quigley Group.com" },
                    { 128, "Annetta Glens", 158, "Osborne.Goodwin@yahoo.com", "Zemlak - Gerlach", 137, "(287) 525-2823", "www.Zemlak - Gerlach.com" },
                    { 147, "Zulauf Mission", 157, "Weldon.Wintheiser@gmail.com", "Paucek, Fay and Cummerata", 137, "(122) 905-5912", "www.Paucek, Fay and Cummerata.com" },
                    { 7, "Ludwig Ridges", 54, "Diana41@hotmail.com", "Auer - Russel", 108, "(905) 075-8326", "www.Auer - Russel.com" },
                    { 42, "Medhurst Mills", 87, "Kenny10@gmail.com", "Doyle, Kovacek and Ondricka", 44, "(785) 729-4529", "www.Doyle, Kovacek and Ondricka.com" },
                    { 66, "Stokes Fall", 4, "Destini_Moen@hotmail.com", "Bayer - Green", 108, "(440) 876-9935", "www.Bayer - Green.com" },
                    { 130, "Williamson Harbors", 61, "Destany30@gmail.com", "Tillman, Pollich and Bogan", 130, "(517) 605-8503", "www.Tillman, Pollich and Bogan.com" },
                    { 73, "Reynolds Shores", 258, "Winston_Schaden6@hotmail.com", "Wyman, Lockman and Schmidt", 238, "(159) 923-7131", "www.Wyman, Lockman and Schmidt.com" },
                    { 88, "Rath Course", 131, "Candelario_Rau@gmail.com", "Haley, Braun and Daugherty", 238, "(917) 399-8575", "www.Haley, Braun and Daugherty.com" },
                    { 9, "Johnston Shore", 183, "Kim.Thompson@yahoo.com", "Hoppe - Brown", 71, "(345) 746-9085", "www.Hoppe - Brown.com" },
                    { 149, "Filomena Village", 262, "Stan63@hotmail.com", "Bechtelar, Kerluke and Fay", 71, "(259) 817-6862", "www.Bechtelar, Kerluke and Fay.com" },
                    { 29, "Heaney Crest", 60, "Melba_Frami84@hotmail.com", "Prohaska, Larson and Rempel", 111, "(308) 711-5415", "www.Prohaska, Larson and Rempel.com" },
                    { 4, "Frankie Radial", 131, "Tracy85@yahoo.com", "Ebert - Cronin", 204, "(142) 379-0809", "www.Ebert - Cronin.com" },
                    { 70, "Grace Walks", 194, "Arch77@yahoo.com", "Osinski, White and Lebsack", 130, "(757) 959-7585", "www.Osinski, White and Lebsack.com" },
                    { 144, "Wilber Walks", 127, "Marcelino16@hotmail.com", "Denesik - Lueilwitz", 204, "(586) 007-8493", "www.Denesik - Lueilwitz.com" },
                    { 105, "Schuster Station", 62, "Yoshiko18@gmail.com", "Reynolds - Dicki", 81, "(303) 608-1426", "www.Reynolds - Dicki.com" },
                    { 115, "Fadel Trace", 247, "Elroy93@gmail.com", "Champlin - Gottlieb", 81, "(988) 210-5693", "www.Champlin - Gottlieb.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 140, "Oceane Groves", 207, "Mollie_Littel81@yahoo.com", "Kemmer, Lind and Pagac", 81, "(816) 027-8146", "www.Kemmer, Lind and Pagac.com" },
                    { 129, "Sipes Mall", 232, "Vita.Hayes92@hotmail.com", "Pagac - Reinger", 166, "(362) 215-1298", "www.Pagac - Reinger.com" },
                    { 72, "Alejandra Inlet", 155, "Deon.Hoppe@gmail.com", "Mann Inc", 25, "(774) 410-5246", "www.Mann Inc.com" },
                    { 40, "Reinger Ridges", 83, "Demond.Schaefer@gmail.com", "Romaguera LLC", 108, "(387) 169-5129", "www.Romaguera LLC.com" },
                    { 86, "Ally Crossing", 194, "Vesta.Macejkovic@hotmail.com", "Bashirian - Abernathy", 25, "(958) 673-9687", "www.Bashirian - Abernathy.com" },
                    { 101, "Stamm Squares", 181, "Veda79@gmail.com", "Hegmann, Raynor and Wiegand", 81, "(526) 105-3315", "www.Hegmann, Raynor and Wiegand.com" },
                    { 49, "Cronin Stravenue", 191, "Kirk_Zboncak@yahoo.com", "Hahn - Bayer", 130, "(992) 133-6774", "www.Hahn - Bayer.com" },
                    { 38, "Summer Unions", 7, "Mya.Wuckert51@yahoo.com", "Lueilwitz - Crona", 298, "(427) 033-7540", "www.Lueilwitz - Crona.com" },
                    { 143, "Ernser Crescent", 191, "Dell.Stanton@yahoo.com", "McLaughlin, Green and Ritchie", 59, "(685) 851-0923", "www.McLaughlin, Green and Ritchie.com" },
                    { 87, "Wilford Valley", 26, "Alexandro.Mills29@hotmail.com", "Howell LLC", 108, "(279) 275-0436", "www.Howell LLC.com" },
                    { 11, "Monserrate Road", 99, "Angie99@hotmail.com", "Stanton - Von", 199, "(816) 983-9152", "www.Stanton - Von.com" },
                    { 67, "Haag Grove", 32, "Wanda.Lueilwitz@yahoo.com", "McGlynn LLC", 199, "(551) 774-3659", "www.McGlynn LLC.com" },
                    { 81, "Beahan Passage", 254, "Karl68@hotmail.com", "Dickens - Kerluke", 199, "(284) 050-4288", "www.Dickens - Kerluke.com" },
                    { 104, "Senger Ferry", 263, "Alek73@gmail.com", "Feeney - Simonis", 199, "(709) 752-0513", "www.Feeney - Simonis.com" },
                    { 142, "Zoe Fort", 13, "Lillie67@gmail.com", "Smith, Kub and Dach", 199, "(461) 684-5532", "www.Smith, Kub and Dach.com" },
                    { 139, "Wiza Spring", 10, "Judy89@yahoo.com", "Gerhold Inc", 125, "(669) 716-5296", "www.Gerhold Inc.com" },
                    { 136, "Clarabelle Fields", 265, "Ryder_Shields@hotmail.com", "Lesch and Sons", 199, "(333) 120-8333", "www.Lesch and Sons.com" },
                    { 15, "Elna Plaza", 272, "Louie.Schumm@yahoo.com", "Kulas LLC", 189, "(238) 363-9575", "www.Kulas LLC.com" },
                    { 84, "Haley Cliffs", 34, "Rocio23@gmail.com", "Nader - Weissnat", 189, "(099) 646-3007", "www.Nader - Weissnat.com" },
                    { 103, "Nia Mall", 267, "Gideon14@hotmail.com", "Bayer Group", 189, "(875) 817-4327", "www.Bayer Group.com" },
                    { 146, "O'Reilly Pines", 158, "Amelia22@yahoo.com", "Medhurst, Goldner and Wiza", 189, "(634) 014-6943", "www.Medhurst, Goldner and Wiza.com" },
                    { 3, "Huels Row", 121, "Ora.Wunsch92@gmail.com", "Heathcote - Bode", 11, "(199) 571-7621", "www.Heathcote - Bode.com" },
                    { 62, "Pfeffer Trail", 250, "Bret.Schmidt76@gmail.com", "Legros Inc", 59, "(816) 610-4058", "www.Legros Inc.com" },
                    { 148, "Shakira View", 155, "Moshe_Torp56@gmail.com", "Harvey - McCullough", 125, "(096) 550-6001", "www.Harvey - McCullough.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 64, new DateTime(2021, 1, 4, 9, 35, 3, 293, DateTimeKind.Local).AddTicks(3783), 182824, 67, "6013425" },
                    { 26, new DateTime(2021, 4, 22, 10, 36, 41, 281, DateTimeKind.Local).AddTicks(4112), 155779, 25, "8625909" },
                    { 60, new DateTime(2021, 8, 16, 0, 31, 13, 756, DateTimeKind.Local).AddTicks(6763), 122202, 67, "4961252" },
                    { 22, new DateTime(2021, 6, 24, 3, 59, 47, 301, DateTimeKind.Local).AddTicks(813), 248607, 67, "4573819" },
                    { 25, new DateTime(2021, 5, 21, 15, 9, 27, 872, DateTimeKind.Local).AddTicks(632), 888876, 63, "3952559" },
                    { 77, new DateTime(2021, 7, 1, 17, 24, 4, 740, DateTimeKind.Local).AddTicks(4304), 140277, 37, "8105535" },
                    { 5, new DateTime(2020, 10, 6, 20, 46, 56, 692, DateTimeKind.Local).AddTicks(3362), 506950, 37, "1587371" },
                    { 19, new DateTime(2020, 9, 19, 15, 40, 19, 548, DateTimeKind.Local).AddTicks(3027), 726615, 1, "4224568" },
                    { 62, new DateTime(2021, 3, 15, 20, 18, 12, 639, DateTimeKind.Local).AddTicks(3000), 706672, 44, "7731709" },
                    { 15, new DateTime(2021, 1, 23, 1, 58, 32, 229, DateTimeKind.Local).AddTicks(6338), 806471, 2, "5308767" },
                    { 70, new DateTime(2021, 8, 27, 0, 57, 57, 394, DateTimeKind.Local).AddTicks(6823), 60941, 81, "2995750" },
                    { 78, new DateTime(2020, 10, 21, 20, 49, 4, 164, DateTimeKind.Local).AddTicks(8147), 548880, 44, "5879119" },
                    { 41, new DateTime(2021, 6, 12, 10, 58, 56, 951, DateTimeKind.Local).AddTicks(624), 841957, 42, "2528398" },
                    { 67, new DateTime(2021, 4, 27, 1, 0, 48, 411, DateTimeKind.Local).AddTicks(6095), 167619, 44, "4570755" },
                    { 52, new DateTime(2020, 9, 29, 16, 2, 39, 645, DateTimeKind.Local).AddTicks(3429), 392712, 42, "2263531" },
                    { 36, new DateTime(2021, 8, 21, 0, 36, 32, 141, DateTimeKind.Local).AddTicks(1180), 947788, 14, "1998609" },
                    { 80, new DateTime(2020, 10, 1, 13, 20, 45, 93, DateTimeKind.Local).AddTicks(477), 335767, 2, "8698800" },
                    { 21, new DateTime(2021, 1, 22, 14, 20, 26, 830, DateTimeKind.Local).AddTicks(7902), 471183, 4, "1592742" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 13, new DateTime(2020, 11, 21, 17, 36, 54, 235, DateTimeKind.Local).AddTicks(1119), 141188, 32, "4562619" },
                    { 66, new DateTime(2021, 3, 6, 9, 10, 25, 351, DateTimeKind.Local).AddTicks(6143), 514402, 17, "7829030" },
                    { 29, new DateTime(2021, 4, 9, 18, 17, 23, 855, DateTimeKind.Local).AddTicks(9451), 964960, 32, "8316402" },
                    { 17, new DateTime(2021, 3, 27, 1, 31, 2, 770, DateTimeKind.Local).AddTicks(6318), 48416, 42, "1925052" },
                    { 20, new DateTime(2021, 5, 28, 16, 43, 8, 123, DateTimeKind.Local).AddTicks(6421), 781010, 32, "4680064" },
                    { 46, new DateTime(2021, 7, 23, 16, 7, 56, 978, DateTimeKind.Local).AddTicks(3856), 320603, 20, "7537972" },
                    { 39, new DateTime(2020, 9, 10, 5, 49, 32, 587, DateTimeKind.Local).AddTicks(8513), 528007, 48, "1673989" },
                    { 10, new DateTime(2020, 12, 31, 17, 17, 1, 972, DateTimeKind.Local).AddTicks(2070), 532142, 48, "8851778" },
                    { 72, new DateTime(2021, 4, 11, 5, 57, 47, 3, DateTimeKind.Local).AddTicks(4569), 358133, 56, "9100887" },
                    { 76, new DateTime(2021, 7, 6, 9, 12, 58, 23, DateTimeKind.Local).AddTicks(5580), 955952, 83, "3560561" },
                    { 58, new DateTime(2020, 9, 28, 15, 29, 19, 166, DateTimeKind.Local).AddTicks(476), 977228, 83, "1289585" },
                    { 57, new DateTime(2021, 6, 19, 1, 59, 47, 966, DateTimeKind.Local).AddTicks(669), 151365, 83, "4057698" },
                    { 49, new DateTime(2020, 12, 27, 2, 5, 2, 70, DateTimeKind.Local).AddTicks(6762), 496132, 83, "5868965" },
                    { 6, new DateTime(2021, 5, 21, 12, 57, 25, 660, DateTimeKind.Local).AddTicks(941), 241455, 83, "7808151" },
                    { 69, new DateTime(2021, 7, 31, 16, 32, 11, 731, DateTimeKind.Local).AddTicks(9432), 103006, 26, "5114444" },
                    { 4, new DateTime(2020, 8, 31, 8, 24, 37, 803, DateTimeKind.Local).AddTicks(8191), 883399, 26, "4206676" },
                    { 56, new DateTime(2021, 3, 9, 3, 28, 36, 287, DateTimeKind.Local).AddTicks(9599), 180508, 71, "8665970" },
                    { 12, new DateTime(2020, 10, 4, 22, 14, 44, 965, DateTimeKind.Local).AddTicks(2933), 887757, 61, "2099695" },
                    { 7, new DateTime(2020, 9, 13, 19, 14, 26, 348, DateTimeKind.Local).AddTicks(5163), 268646, 77, "3865139" },
                    { 2, new DateTime(2021, 5, 14, 15, 16, 22, 415, DateTimeKind.Local).AddTicks(8459), 172450, 17, "9859945" },
                    { 1, new DateTime(2020, 12, 7, 23, 54, 42, 469, DateTimeKind.Local).AddTicks(9834), 497143, 8, "7612067" },
                    { 53, new DateTime(2021, 4, 13, 8, 52, 24, 250, DateTimeKind.Local).AddTicks(1738), 251700, 36, "2339345" },
                    { 74, new DateTime(2021, 6, 25, 17, 20, 30, 397, DateTimeKind.Local).AddTicks(4681), 18434, 73, "1756664" },
                    { 27, new DateTime(2020, 12, 4, 0, 10, 37, 807, DateTimeKind.Local).AddTicks(3362), 66318, 16, "3648728" },
                    { 79, new DateTime(2021, 8, 5, 16, 32, 29, 204, DateTimeKind.Local).AddTicks(2178), 464659, 12, "8078032" },
                    { 61, new DateTime(2021, 2, 19, 16, 48, 56, 210, DateTimeKind.Local).AddTicks(8379), 248735, 12, "3835312" },
                    { 38, new DateTime(2021, 7, 13, 3, 19, 32, 778, DateTimeKind.Local).AddTicks(2006), 602508, 90, "5827244" },
                    { 33, new DateTime(2021, 5, 14, 1, 39, 47, 331, DateTimeKind.Local).AddTicks(4690), 683021, 9, "4491026" },
                    { 51, new DateTime(2020, 12, 3, 9, 23, 8, 553, DateTimeKind.Local).AddTicks(8645), 656298, 23, "3170041" },
                    { 50, new DateTime(2021, 3, 31, 16, 23, 38, 232, DateTimeKind.Local).AddTicks(5160), 63171, 3, "2591204" },
                    { 81, new DateTime(2021, 2, 17, 14, 32, 43, 466, DateTimeKind.Local).AddTicks(6120), 221532, 93, "9805482" },
                    { 59, new DateTime(2021, 2, 17, 13, 16, 42, 599, DateTimeKind.Local).AddTicks(3063), 378160, 93, "3598602" },
                    { 11, new DateTime(2020, 11, 28, 19, 25, 27, 178, DateTimeKind.Local).AddTicks(9013), 860507, 93, "7679491" },
                    { 43, new DateTime(2021, 5, 29, 6, 29, 30, 700, DateTimeKind.Local).AddTicks(1034), 984904, 62, "8277195" },
                    { 9, new DateTime(2020, 11, 2, 10, 11, 53, 943, DateTimeKind.Local).AddTicks(978), 472875, 72, "3990240" },
                    { 45, new DateTime(2021, 4, 21, 10, 14, 19, 575, DateTimeKind.Local).AddTicks(4928), 558759, 55, "3915254" },
                    { 37, new DateTime(2021, 7, 19, 0, 45, 5, 381, DateTimeKind.Local).AddTicks(5883), 465541, 36, "9561067" },
                    { 14, new DateTime(2021, 2, 6, 2, 24, 57, 430, DateTimeKind.Local).AddTicks(1261), 819893, 36, "2506920" },
                    { 47, new DateTime(2020, 12, 12, 13, 3, 54, 529, DateTimeKind.Local).AddTicks(9700), 64856, 30, "7186260" },
                    { 55, new DateTime(2021, 1, 28, 9, 42, 38, 572, DateTimeKind.Local).AddTicks(5961), 851689, 32, "8998757" },
                    { 28, new DateTime(2020, 11, 5, 15, 45, 16, 164, DateTimeKind.Local).AddTicks(7508), 56374, 16, "8460300" },
                    { 30, new DateTime(2021, 4, 21, 2, 30, 43, 480, DateTimeKind.Local).AddTicks(8877), 194264, 86, "8508132" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 31, new DateTime(2021, 5, 20, 16, 47, 8, 529, DateTimeKind.Local).AddTicks(3770), 540864, 39, "2555080" },
                    { 44, new DateTime(2021, 2, 16, 0, 56, 25, 708, DateTimeKind.Local).AddTicks(742), 814551, 10, "6243064" },
                    { 65, new DateTime(2020, 10, 22, 13, 47, 46, 611, DateTimeKind.Local).AddTicks(3857), 948392, 87, "5970843" },
                    { 71, new DateTime(2021, 1, 23, 19, 15, 23, 576, DateTimeKind.Local).AddTicks(1667), 622631, 53, "5360771" },
                    { 75, new DateTime(2021, 8, 23, 4, 11, 47, 583, DateTimeKind.Local).AddTicks(6014), 781479, 31, "1034877" },
                    { 18, new DateTime(2021, 8, 3, 14, 3, 12, 833, DateTimeKind.Local).AddTicks(7336), 470458, 31, "5658349" },
                    { 8, new DateTime(2021, 2, 12, 9, 35, 46, 998, DateTimeKind.Local).AddTicks(9431), 601879, 31, "8463605" },
                    { 48, new DateTime(2020, 8, 27, 23, 50, 10, 81, DateTimeKind.Local).AddTicks(464), 908479, 70, "5969878" },
                    { 54, new DateTime(2020, 9, 3, 14, 5, 29, 66, DateTimeKind.Local).AddTicks(3806), 375878, 5, "1783272" },
                    { 3, new DateTime(2020, 12, 13, 16, 4, 43, 909, DateTimeKind.Local).AddTicks(2511), 837436, 29, "2166715" },
                    { 68, new DateTime(2021, 4, 10, 8, 18, 57, 965, DateTimeKind.Local).AddTicks(6290), 633244, 76, "6430973" },
                    { 32, new DateTime(2021, 6, 18, 19, 9, 20, 475, DateTimeKind.Local).AddTicks(3412), 561313, 76, "7555863" },
                    { 73, new DateTime(2021, 1, 18, 2, 57, 39, 725, DateTimeKind.Local).AddTicks(7635), 441300, 51, "4072028" },
                    { 63, new DateTime(2021, 3, 26, 13, 38, 54, 300, DateTimeKind.Local).AddTicks(6452), 12851, 51, "3628234" },
                    { 16, new DateTime(2021, 5, 8, 9, 26, 38, 767, DateTimeKind.Local).AddTicks(7825), 417314, 51, "1177029" },
                    { 40, new DateTime(2021, 1, 4, 3, 48, 22, 400, DateTimeKind.Local).AddTicks(4894), 600879, 7, "8274323" },
                    { 35, new DateTime(2021, 7, 7, 2, 6, 4, 93, DateTimeKind.Local).AddTicks(2713), 770224, 57, "4955434" },
                    { 42, new DateTime(2020, 9, 27, 7, 14, 32, 834, DateTimeKind.Local).AddTicks(2280), 868036, 64, "2132091" },
                    { 34, new DateTime(2021, 7, 29, 14, 13, 59, 906, DateTimeKind.Local).AddTicks(1172), 575285, 64, "4248274" },
                    { 23, new DateTime(2021, 8, 25, 2, 18, 40, 357, DateTimeKind.Local).AddTicks(7668), 338108, 21, "9979923" },
                    { 24, new DateTime(2021, 2, 25, 21, 21, 17, 871, DateTimeKind.Local).AddTicks(1565), 549694, 35, "8638650" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 130, 41, 74, 181122, new DateTime(2020, 9, 18, 4, 41, 16, 886, DateTimeKind.Local).AddTicks(4298), "Quia recusandae autem." },
                    { 291, 57, 3, 978295, new DateTime(2021, 6, 10, 14, 19, 31, 417, DateTimeKind.Local).AddTicks(1114), "Ut magnam vel sint voluptatem delectus. Reprehenderit consequatur quas quisquam est ducimus corporis ipsam et. Aliquam harum sint. Est omnis ipsa suscipit quia. Velit sit dolore repudiandae. Molestiae ipsam sed rerum dolore sit." },
                    { 39, 41, 86, 684027, new DateTime(2021, 6, 28, 22, 39, 5, 134, DateTimeKind.Local).AddTicks(8839), "Praesentium ea quia fugiat amet unde.\nOccaecati nemo officia itaque quis natus aliquam incidunt illo.\nSed dolor similique aliquam vero maiores." },
                    { 58, 41, 121, 785078, new DateTime(2021, 3, 9, 15, 21, 47, 179, DateTimeKind.Local).AddTicks(6310), "Nisi et enim maiores. Voluptatum ea voluptas id ea ea ratione iure. Nam culpa ut ea ut sed. Cum non sunt reprehenderit consectetur assumenda. Officiis voluptatem quia aperiam assumenda et vel consequatur iure." },
                    { 115, 41, 33, 676786, new DateTime(2021, 6, 2, 3, 10, 49, 493, DateTimeKind.Local).AddTicks(1425), "Aut aut incidunt in. Dolores praesentium non ut consequatur sequi ut. Molestiae eius voluptatem. Rerum maiores ut tenetur." },
                    { 207, 57, 64, 748260, new DateTime(2021, 3, 31, 13, 39, 16, 269, DateTimeKind.Local).AddTicks(1938), "maxime" },
                    { 135, 41, 3, 886070, new DateTime(2021, 8, 26, 8, 7, 48, 970, DateTimeKind.Local).AddTicks(8969), "Sit corrupti id omnis quia ad dolorum recusandae sit.\nVoluptates quam occaecati ut voluptatem consequatur aut cum excepturi exercitationem.\nEx et dolores similique sit.\nOfficia autem quia provident eos numquam qui aliquid deserunt.\nLaborum deserunt odio mollitia.\nUt praesentium culpa ipsum debitis ad." },
                    { 217, 41, 113, 356994, new DateTime(2021, 6, 7, 13, 20, 47, 13, DateTimeKind.Local).AddTicks(4331), "Tempore nulla et fugit quasi.\nUt iste soluta consequatur nemo possimus.\nEt a aliquam voluptas ratione eos autem sed natus pariatur.\nEt non earum consequatur facere.\nIn eum quidem." },
                    { 258, 41, 48, 879892, new DateTime(2021, 8, 18, 22, 3, 36, 306, DateTimeKind.Local).AddTicks(3254), "nobis" },
                    { 309, 41, 17, 384803, new DateTime(2021, 5, 12, 4, 39, 55, 108, DateTimeKind.Local).AddTicks(881), "Debitis quia nesciunt totam eligendi excepturi voluptatem omnis." },
                    { 454, 41, 90, 726171, new DateTime(2021, 2, 26, 23, 18, 56, 796, DateTimeKind.Local).AddTicks(1899), "Repellendus consequatur dignissimos possimus voluptatem unde. Veniam ut nostrum et quisquam. Ut sint error officiis nihil hic dolore aliquam." },
                    { 507, 41, 72, 125502, new DateTime(2020, 12, 8, 3, 3, 39, 845, DateTimeKind.Local).AddTicks(7242), "Qui fuga dicta est neque error impedit.\nAut aliquam voluptatibus quia quia praesentium quas placeat." },
                    { 564, 41, 127, 53015, new DateTime(2020, 12, 20, 1, 38, 54, 280, DateTimeKind.Local).AddTicks(4785), "Assumenda quis possimus necessitatibus. Aut qui exercitationem qui et accusantium sit nihil. Nesciunt tempore nihil velit fugit aut. Molestiae eveniet quos animi aut sunt saepe architecto est." },
                    { 187, 57, 56, 847012, new DateTime(2021, 6, 18, 11, 14, 52, 100, DateTimeKind.Local).AddTicks(4069), "Quas voluptate qui facilis.\nReprehenderit et sunt molestias reprehenderit ipsam voluptatem quia." },
                    { 186, 57, 99, 161372, new DateTime(2020, 11, 15, 6, 37, 53, 50, DateTimeKind.Local).AddTicks(979), "Natus natus voluptatibus quidem. Tempora officia ut illo nostrum voluptatem. Aliquid quae at enim tempora corporis consequuntur quis ducimus. Eligendi necessitatibus consequuntur voluptatem. Voluptas optio eos dignissimos voluptas atque quia vel iusto enim. Ducimus id alias earum quia." },
                    { 174, 57, 11, 695959, new DateTime(2021, 7, 30, 4, 36, 26, 611, DateTimeKind.Local).AddTicks(8853), "sit" },
                    { 296, 57, 40, 823476, new DateTime(2020, 9, 21, 17, 51, 50, 888, DateTimeKind.Local).AddTicks(8536), "Sunt consectetur rem quos ut modi. Sit sit aut provident. Ut et aut quam pariatur sint laudantium voluptates est. Quibusdam velit enim corporis odio cupiditate saepe voluptatibus. Ut et rem ut." },
                    { 320, 57, 19, 157429, new DateTime(2020, 12, 15, 15, 2, 54, 408, DateTimeKind.Local).AddTicks(9486), "Eos in quo iusto eos et ut qui est omnis. Mollitia voluptas omnis delectus excepturi molestiae ipsum est voluptas qui. Iure quas vero quibusdam commodi." },
                    { 337, 57, 112, 948677, new DateTime(2021, 1, 12, 3, 39, 45, 542, DateTimeKind.Local).AddTicks(1277), "Ut deserunt beatae accusamus ducimus. Beatae nulla inventore. Quisquam ea voluptates rerum necessitatibus quia qui labore praesentium. Voluptas voluptatum corrupti deleniti quibusdam rerum dignissimos reiciendis. Dolores repellendus assumenda saepe. Sit vero nisi." },
                    { 420, 17, 63, 772505, new DateTime(2021, 1, 9, 21, 46, 53, 61, DateTimeKind.Local).AddTicks(1868), "Voluptas praesentium cupiditate et occaecati vel dolorum numquam.\nCommodi cum recusandae repellat illum debitis impedit explicabo.\nEos dolore ad veritatis.\nQuibusdam ea non cum.\nExplicabo assumenda ea earum nesciunt minus laborum libero.\nAutem non magnam reiciendis." },
                    { 442, 30, 137, 885979, new DateTime(2021, 7, 9, 1, 41, 36, 869, DateTimeKind.Local).AddTicks(1903), "Ipsa fugiat temporibus molestiae nam debitis at dolorem quod.\nTotam minima assumenda soluta facere est iusto quae.\nNon quia deleniti hic in." },
                    { 551, 30, 76, 894850, new DateTime(2021, 5, 18, 7, 9, 34, 498, DateTimeKind.Local).AddTicks(4960), "quia" },
                    { 448, 58, 69, 69686, new DateTime(2020, 11, 6, 11, 14, 13, 514, DateTimeKind.Local).AddTicks(9466), "Labore necessitatibus doloribus praesentium illo eum necessitatibus." },
                    { 369, 58, 29, 1924, new DateTime(2021, 5, 3, 0, 2, 7, 302, DateTimeKind.Local).AddTicks(2698), "debitis" },
                    { 148, 58, 118, 41947, new DateTime(2021, 6, 27, 10, 55, 21, 674, DateTimeKind.Local).AddTicks(3803), "consectetur" },
                    { 112, 1, 57, 858647, new DateTime(2021, 6, 19, 13, 30, 11, 838, DateTimeKind.Local).AddTicks(1405), "Eaque esse dolores aut. Cum sit dolor corporis voluptatem consequatur a et. Ad unde aspernatur dolorem tempora dolores vero repudiandae sint ea. Error inventore magni. Ipsum et cum amet minima sapiente quia voluptatem." },
                    { 228, 1, 32, 167667, new DateTime(2020, 11, 9, 20, 30, 51, 274, DateTimeKind.Local).AddTicks(2166), "Labore omnis asperiores labore. Est dolorem voluptas labore. Fuga vero sequi qui sequi perferendis facilis ab fugit. Ut aperiam provident quia expedita ex atque." },
                    { 23, 57, 10, 562299, new DateTime(2020, 11, 29, 9, 51, 6, 105, DateTimeKind.Local).AddTicks(255), "Illo nihil delectus ea libero impedit aut totam tenetur." },
                    { 242, 1, 2, 830454, new DateTime(2021, 3, 23, 22, 51, 22, 945, DateTimeKind.Local).AddTicks(9284), "ad" },
                    { 405, 1, 94, 783603, new DateTime(2020, 9, 10, 18, 22, 2, 176, DateTimeKind.Local).AddTicks(6782), "Deleniti temporibus est ipsam esse est ullam perspiciatis." },
                    { 431, 1, 37, 404962, new DateTime(2020, 11, 25, 22, 6, 11, 81, DateTimeKind.Local).AddTicks(7880), "Animi odio qui et.\nOptio iusto est eaque eum sequi optio veniam." },
                    { 543, 1, 43, 851114, new DateTime(2021, 4, 3, 10, 46, 53, 141, DateTimeKind.Local).AddTicks(6656), "Ea et quia. Cum officia deleniti. Doloremque tenetur labore et." },
                    { 45, 17, 38, 280643, new DateTime(2021, 7, 24, 7, 51, 55, 164, DateTimeKind.Local).AddTicks(8473), "nam" },
                    { 172, 17, 8, 481801, new DateTime(2021, 5, 19, 1, 58, 12, 779, DateTimeKind.Local).AddTicks(9971), "Consectetur eius cum." },
                    { 256, 17, 147, 226580, new DateTime(2021, 8, 6, 0, 38, 11, 352, DateTimeKind.Local).AddTicks(2025), "Minima illo cupiditate eaque nesciunt omnis ipsam.\nEst quibusdam alias labore eligendi quia sint.\nNihil dignissimos iure doloremque totam neque aut ea." },
                    { 396, 17, 23, 745115, new DateTime(2021, 7, 30, 1, 48, 12, 518, DateTimeKind.Local).AddTicks(5564), "Aut pariatur impedit velit autem minus." },
                    { 289, 1, 92, 572561, new DateTime(2021, 8, 8, 21, 47, 45, 954, DateTimeKind.Local).AddTicks(421), "Voluptatem adipisci et itaque commodi rerum dolores velit." },
                    { 303, 30, 113, 791959, new DateTime(2021, 8, 20, 20, 53, 31, 134, DateTimeKind.Local).AddTicks(185), "libero" },
                    { 77, 52, 131, 247885, new DateTime(2021, 8, 7, 6, 22, 36, 607, DateTimeKind.Local).AddTicks(3510), "Aliquid voluptatem odio." },
                    { 290, 52, 26, 489814, new DateTime(2021, 8, 5, 23, 50, 30, 154, DateTimeKind.Local).AddTicks(7432), "sint" },
                    { 250, 67, 35, 944481, new DateTime(2021, 6, 4, 9, 7, 16, 142, DateTimeKind.Local).AddTicks(3838), "qui" },
                    { 251, 67, 30, 604129, new DateTime(2020, 10, 12, 9, 30, 49, 107, DateTimeKind.Local).AddTicks(7926), "Qui doloribus asperiores optio nesciunt ut animi minus porro quas.\nOptio qui est ipsa ipsum eveniet praesentium in quo ut." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 364, 67, 37, 398901, new DateTime(2021, 2, 2, 19, 28, 12, 726, DateTimeKind.Local).AddTicks(3325), "facere" },
                    { 404, 67, 127, 328302, new DateTime(2021, 6, 21, 13, 47, 25, 311, DateTimeKind.Local).AddTicks(7760), "Autem ut voluptatem facere at sint id officiis voluptas. Delectus rerum fugiat aut. Quae laboriosam ut ea doloremque explicabo atque ipsum. Adipisci libero neque velit. Architecto non rerum rerum qui." },
                    { 450, 67, 5, 871003, new DateTime(2021, 7, 31, 20, 51, 54, 881, DateTimeKind.Local).AddTicks(6457), "Consequatur dolores et explicabo et eum. Sed iure odio. Autem velit at reprehenderit laboriosam. Tenetur ad atque corrupti. Voluptas aut perferendis quae." },
                    { 509, 67, 10, 271218, new DateTime(2020, 10, 3, 20, 14, 45, 409, DateTimeKind.Local).AddTicks(8301), "Velit praesentium qui nihil aliquid qui in odio. Qui rerum repellendus debitis iure iusto asperiores modi minima aperiam. Et et inventore quia soluta." },
                    { 536, 67, 105, 744821, new DateTime(2021, 6, 8, 9, 37, 7, 235, DateTimeKind.Local).AddTicks(9625), "exercitationem" },
                    { 338, 49, 85, 101976, new DateTime(2021, 2, 5, 2, 30, 44, 460, DateTimeKind.Local).AddTicks(2904), "Eius enim quia.\nDolor ea exercitationem nihil rem aut voluptatem omnis.\nMollitia architecto natus." },
                    { 306, 49, 23, 591231, new DateTime(2021, 8, 14, 19, 45, 50, 485, DateTimeKind.Local).AddTicks(9059), "provident" },
                    { 295, 49, 31, 602372, new DateTime(2020, 9, 16, 6, 21, 1, 699, DateTimeKind.Local).AddTicks(109), "Repellendus eos aut consequuntur.\nAdipisci neque consequuntur nisi officia.\nDignissimos nihil sit nemo non." },
                    { 272, 49, 148, 22200, new DateTime(2021, 3, 24, 14, 38, 33, 880, DateTimeKind.Local).AddTicks(2280), "dicta" },
                    { 56, 78, 38, 333227, new DateTime(2021, 3, 21, 5, 8, 43, 880, DateTimeKind.Local).AddTicks(4397), "Repudiandae consequuntur doloribus. Blanditiis laborum ea fuga ipsa soluta saepe velit dolores. Commodi perspiciatis reiciendis et explicabo minima repellat. Sed commodi eligendi fugit perspiciatis quae rerum laboriosam quia. Sunt qui sit sapiente qui officia nesciunt. Cumque blanditiis quos ut neque eius." },
                    { 216, 78, 119, 464661, new DateTime(2021, 6, 22, 4, 3, 14, 388, DateTimeKind.Local).AddTicks(6321), "suscipit" },
                    { 218, 78, 93, 409854, new DateTime(2021, 5, 31, 12, 21, 14, 54, DateTimeKind.Local).AddTicks(9114), "Eum laboriosam necessitatibus." },
                    { 231, 78, 74, 745758, new DateTime(2021, 1, 5, 18, 42, 44, 810, DateTimeKind.Local).AddTicks(1755), "nulla" },
                    { 222, 67, 126, 879606, new DateTime(2021, 1, 27, 18, 9, 1, 240, DateTimeKind.Local).AddTicks(6774), "Praesentium eum assumenda nihil tempore id.\nTempora dolores autem iste et.\nIllum ut qui quaerat soluta vero laudantium placeat ut illo.\nIpsa nostrum temporibus deserunt molestiae natus cumque illum aut facere." },
                    { 111, 67, 95, 914347, new DateTime(2021, 7, 3, 9, 4, 8, 380, DateTimeKind.Local).AddTicks(2123), "enim" },
                    { 40, 67, 45, 349109, new DateTime(2020, 12, 22, 6, 8, 58, 614, DateTimeKind.Local).AddTicks(438), "Similique voluptatem dicta quo quo." },
                    { 418, 49, 27, 643419, new DateTime(2021, 5, 21, 22, 42, 36, 401, DateTimeKind.Local).AddTicks(5127), "Eligendi labore omnis dolorem qui voluptatem esse rerum. Voluptatem tempora iure eius non commodi alias iusto possimus. Vel tenetur molestiae. Nulla sed dolores et necessitatibus in." },
                    { 428, 52, 148, 447724, new DateTime(2021, 8, 7, 17, 31, 3, 912, DateTimeKind.Local).AddTicks(5555), "Amet quia culpa." },
                    { 482, 52, 110, 950435, new DateTime(2021, 2, 28, 9, 10, 37, 706, DateTimeKind.Local).AddTicks(5211), "Optio eveniet natus voluptatem harum deleniti ut a. Deserunt voluptate vero sint provident assumenda praesentium numquam est architecto. Quis et aut quibusdam dolor molestiae. Perspiciatis quidem id dolores dolorum ab omnis neque. Dolores consequuntur similique at repudiandae. Doloremque harum fuga nihil eaque." },
                    { 484, 52, 37, 666541, new DateTime(2021, 3, 5, 4, 48, 21, 831, DateTimeKind.Local).AddTicks(9543), "Consequatur totam delectus dicta quia. Cupiditate architecto non voluptatum. Voluptatum necessitatibus labore deserunt. Officiis nobis necessitatibus. Minima quo excepturi qui ipsa vero odit. Reiciendis harum quia quo ut tempore consequuntur." },
                    { 590, 52, 52, 285865, new DateTime(2021, 2, 23, 14, 6, 34, 228, DateTimeKind.Local).AddTicks(981), "Et aut eos quos aspernatur.\nIncidunt quae voluptatem ipsum veritatis at laudantium." },
                    { 600, 49, 75, 831849, new DateTime(2021, 8, 12, 20, 3, 30, 162, DateTimeKind.Local).AddTicks(3942), "quia" },
                    { 548, 49, 48, 189565, new DateTime(2021, 7, 30, 7, 20, 2, 500, DateTimeKind.Local).AddTicks(5239), "Et error et laborum vel assumenda ratione.\nEst enim delectus corporis natus nobis eveniet.\nVeritatis quia reprehenderit dignissimos optio quisquam rerum.\nNon consequuntur eos amet officia eius qui consequatur.\nTenetur eos voluptas vero velit.\nNihil voluptatem omnis necessitatibus aut." },
                    { 28, 62, 106, 467757, new DateTime(2020, 9, 27, 4, 56, 12, 166, DateTimeKind.Local).AddTicks(9066), "Cumque voluptate ratione hic quam." },
                    { 170, 52, 2, 305797, new DateTime(2020, 9, 9, 23, 1, 59, 337, DateTimeKind.Local).AddTicks(5096), "quia" },
                    { 175, 62, 94, 499419, new DateTime(2021, 1, 18, 4, 56, 12, 775, DateTimeKind.Local).AddTicks(9340), "Facilis dolorum distinctio possimus fugit aut mollitia. Cupiditate rem nemo qui. Tempora omnis temporibus quibusdam doloremque repudiandae ab recusandae. Aliquid et nulla. Doloribus perferendis dolores sint." },
                    { 406, 62, 91, 917957, new DateTime(2021, 3, 27, 4, 0, 12, 192, DateTimeKind.Local).AddTicks(1973), "Nemo quibusdam et natus amet facere quia ut aliquam.\nVoluptas corporis vel temporibus ea modi quos tenetur.\nOmnis nemo quibusdam vero id rem consequatur dolorum.\nPerspiciatis et voluptates perferendis doloribus eligendi.\nProvident tenetur quis quia rerum sequi dolore iusto rerum sunt." },
                    { 471, 62, 12, 512474, new DateTime(2021, 3, 17, 15, 24, 46, 423, DateTimeKind.Local).AddTicks(6469), "Error nobis odit. Laudantium quis sed fuga rerum expedita. Magni in qui occaecati. Dolor accusantium inventore similique repellat. Porro et alias repellendus nostrum." },
                    { 526, 62, 38, 318337, new DateTime(2021, 7, 7, 0, 1, 39, 885, DateTimeKind.Local).AddTicks(7436), "Error nisi id sit necessitatibus non quae quae.\nQuia soluta inventore qui laudantium ut consectetur.\nCorrupti qui velit inventore architecto non." },
                    { 530, 62, 26, 956396, new DateTime(2021, 6, 25, 2, 59, 5, 919, DateTimeKind.Local).AddTicks(7846), "Quis mollitia aut amet facilis deserunt nemo." },
                    { 580, 62, 34, 6667, new DateTime(2021, 4, 4, 9, 4, 58, 26, DateTimeKind.Local).AddTicks(3307), "Sit non nulla voluptate omnis modi quis. Quam doloribus saepe odio perferendis at. Debitis dolores maxime laudantium sed." },
                    { 506, 49, 20, 983249, new DateTime(2020, 12, 17, 5, 35, 33, 83, DateTimeKind.Local).AddTicks(8293), "Earum laboriosam voluptatem doloremque accusantium quod quis. Ea tenetur perspiciatis voluptate. Placeat rerum ut ducimus explicabo ea consequatur quis." },
                    { 473, 49, 1, 578265, new DateTime(2021, 2, 20, 0, 46, 25, 144, DateTimeKind.Local).AddTicks(8546), "Culpa nihil officia possimus. Perspiciatis sit corporis est itaque qui sequi. Consequatur optio non aut id eius magnam modi et rerum." },
                    { 197, 62, 88, 341103, new DateTime(2021, 3, 21, 18, 25, 14, 985, DateTimeKind.Local).AddTicks(1635), "Facere quod molestiae modi ducimus aut aut aut. Facere ratione ad unde ut inventore reiciendis. Accusantium porro optio dolores sed tempore dolorem ex." },
                    { 311, 78, 148, 565630, new DateTime(2021, 2, 11, 9, 10, 59, 800, DateTimeKind.Local).AddTicks(2404), "voluptas" },
                    { 281, 30, 46, 573301, new DateTime(2020, 9, 23, 0, 29, 51, 56, DateTimeKind.Local).AddTicks(9388), "Atque labore velit nihil animi dolorem est." },
                    { 178, 30, 9, 831314, new DateTime(2020, 9, 1, 0, 24, 52, 306, DateTimeKind.Local).AddTicks(3834), "Doloremque dolorem fugit. Eum officiis repellat. Vel sed non perspiciatis cum porro necessitatibus quo. Laborum similique quidem explicabo reiciendis fugiat reprehenderit. Quas dolor explicabo repellendus deleniti et minima qui aut. Ad amet autem cupiditate dolorem et." },
                    { 167, 18, 147, 685787, new DateTime(2021, 8, 8, 21, 25, 7, 959, DateTimeKind.Local).AddTicks(7690), "Porro ipsam non quisquam iusto ab sint. Fuga velit ut sint dolorem. Non deleniti est eveniet deleniti nam. Id est quas magni sed molestiae incidunt aut aut." },
                    { 190, 18, 120, 569712, new DateTime(2020, 9, 1, 13, 58, 5, 192, DateTimeKind.Local).AddTicks(1585), "Animi quo ducimus." },
                    { 424, 18, 27, 823802, new DateTime(2021, 6, 22, 4, 54, 59, 110, DateTimeKind.Local).AddTicks(9101), "Numquam omnis inventore modi. Voluptate dolor optio natus. Culpa qui voluptates cum dolore. Dicta molestias quis labore et qui aut autem omnis. Veritatis quia alias. Excepturi explicabo inventore libero." },
                    { 438, 18, 41, 430734, new DateTime(2021, 7, 20, 17, 1, 34, 772, DateTimeKind.Local).AddTicks(1556), "vitae" },
                    { 563, 18, 31, 559458, new DateTime(2021, 3, 7, 2, 30, 31, 664, DateTimeKind.Local).AddTicks(60), "Quam asperiores praesentium fuga architecto fuga enim aliquam eum." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 416, 76, 125, 857650, new DateTime(2021, 5, 8, 6, 57, 30, 863, DateTimeKind.Local).AddTicks(1375), "Iure facere voluptatem non. Nostrum quo nihil sint qui totam. Ducimus qui libero aliquid ratione saepe. Quibusdam ducimus commodi non quidem." },
                    { 414, 76, 31, 319278, new DateTime(2021, 6, 2, 2, 42, 42, 64, DateTimeKind.Local).AddTicks(466), "Deleniti placeat inventore aut." },
                    { 335, 76, 102, 762394, new DateTime(2021, 3, 14, 7, 11, 21, 51, DateTimeKind.Local).AddTicks(2977), "Quam dolores qui cumque dolorem voluptatum." },
                    { 75, 75, 132, 176764, new DateTime(2020, 12, 9, 16, 6, 40, 142, DateTimeKind.Local).AddTicks(8934), "Dolorum dolor molestiae rerum tenetur vel possimus. Illo et ratione. Earum amet aliquam." },
                    { 88, 75, 58, 636711, new DateTime(2020, 11, 5, 7, 52, 28, 273, DateTimeKind.Local).AddTicks(7589), "animi" },
                    { 99, 75, 76, 558578, new DateTime(2021, 8, 11, 20, 39, 55, 110, DateTimeKind.Local).AddTicks(4161), "Tempore voluptas neque quisquam optio alias.\nNihil et rem distinctio sapiente delectus molestiae quasi praesentium.\nBeatae commodi fuga quia reiciendis debitis." },
                    { 103, 75, 57, 467014, new DateTime(2020, 11, 22, 13, 20, 50, 599, DateTimeKind.Local).AddTicks(9241), "In autem quaerat qui saepe reiciendis sed.\nLaborum dolores officia in unde magnam illo eligendi.\nSuscipit vel doloribus." },
                    { 188, 75, 129, 963615, new DateTime(2021, 3, 29, 1, 43, 14, 785, DateTimeKind.Local).AddTicks(4026), "libero" },
                    { 282, 75, 124, 597430, new DateTime(2020, 9, 15, 8, 25, 31, 783, DateTimeKind.Local).AddTicks(5369), "Quos in earum ea aut. Quas et aut praesentium et dolores aliquam. Cumque minima voluptatibus. Ratione molestiae nihil et. Qui dolores modi sequi ipsa officiis sapiente quo animi. Qui iusto minima." },
                    { 319, 75, 69, 79295, new DateTime(2020, 12, 7, 22, 37, 5, 123, DateTimeKind.Local).AddTicks(2797), "Aut dolorem tempora qui aut assumenda.\nModi nisi enim dignissimos aut et autem quos.\nAut dolorum harum.\nMollitia iusto aut temporibus ipsam quia quam ut laborum culpa.\nNulla est nostrum velit reiciendis mollitia.\nUt accusamus eos veniam quae est recusandae occaecati voluptas." },
                    { 165, 18, 98, 14840, new DateTime(2021, 5, 10, 16, 34, 32, 885, DateTimeKind.Local).AddTicks(9966), "Alias ducimus nam." },
                    { 137, 18, 47, 446535, new DateTime(2021, 5, 17, 18, 43, 19, 96, DateTimeKind.Local).AddTicks(7866), "Aperiam qui nulla ex est sed. Asperiores iste libero consectetur dicta quasi optio non. Consectetur sint qui. Unde qui et tempore excepturi odit. Ipsam est possimus ut et et doloribus error. Et odit aut ut dolor." },
                    { 109, 18, 25, 249208, new DateTime(2021, 8, 24, 12, 19, 6, 603, DateTimeKind.Local).AddTicks(6284), "Sint ullam aut qui quia suscipit id facilis quia." },
                    { 11, 18, 130, 74948, new DateTime(2021, 4, 4, 21, 26, 23, 961, DateTimeKind.Local).AddTicks(5498), "Magnam veritatis eos expedita et." },
                    { 341, 48, 99, 664755, new DateTime(2021, 8, 24, 19, 7, 18, 181, DateTimeKind.Local).AddTicks(7235), "Labore iusto asperiores rerum illo rem et enim." },
                    { 363, 48, 44, 852062, new DateTime(2021, 6, 15, 18, 7, 58, 161, DateTimeKind.Local).AddTicks(3696), "Reprehenderit voluptate neque vero. Neque aspernatur culpa omnis eos et. Similique quia aspernatur non voluptatem porro dicta quidem aut voluptas. Ut rerum magni maiores est qui rerum et. Consequuntur veritatis non ipsam facilis sed explicabo sed." },
                    { 422, 48, 42, 396574, new DateTime(2020, 11, 4, 18, 53, 7, 239, DateTimeKind.Local).AddTicks(2405), "Sed saepe a id omnis voluptatem sed non natus ullam. Laborum ut facilis quis accusantium vel quasi dolor non est. Quasi fugiat illo corrupti ullam ut odio esse. Eius omnis quae. Aut dolore soluta excepturi deleniti hic eum." },
                    { 468, 48, 150, 404795, new DateTime(2021, 6, 28, 17, 41, 3, 515, DateTimeKind.Local).AddTicks(3289), "non" },
                    { 485, 48, 71, 659837, new DateTime(2020, 9, 20, 2, 58, 55, 386, DateTimeKind.Local).AddTicks(7532), "Labore enim deserunt est.\nMolestias voluptas enim cupiditate omnis ut labore dicta expedita.\nUt quae ut fugit ut explicabo culpa corporis suscipit in.\nFugit fugit laboriosam incidunt.\nVel animi beatae rem sed eos.\nEaque animi autem nam aut qui." },
                    { 100, 72, 18, 692444, new DateTime(2021, 5, 1, 19, 29, 24, 126, DateTimeKind.Local).AddTicks(1044), "Consequatur sunt harum perferendis. Modi recusandae sequi ut sapiente eum eos non. Et voluptatem ipsum necessitatibus ea harum voluptas qui quia culpa." },
                    { 86, 12, 92, 642982, new DateTime(2021, 1, 30, 8, 48, 42, 462, DateTimeKind.Local).AddTicks(9540), "Laboriosam tempora eaque maiores maxime quasi est unde tempore.\nNon accusantium qui repellendus consequatur doloremque eum veritatis qui eveniet.\nDolores saepe harum non error occaecati ut sunt.\nEaque maiores est odio quo.\nQuis ut recusandae ad iusto odit enim exercitationem qui." },
                    { 399, 75, 77, 267148, new DateTime(2021, 3, 17, 2, 36, 15, 724, DateTimeKind.Local).AddTicks(6839), "quaerat" },
                    { 14, 8, 78, 41348, new DateTime(2021, 4, 17, 10, 55, 26, 97, DateTimeKind.Local).AddTicks(8548), "Nihil quisquam cupiditate suscipit non dolores et consectetur deleniti.\nOptio aut ut nulla." },
                    { 46, 8, 13, 350108, new DateTime(2020, 11, 27, 2, 51, 3, 454, DateTimeKind.Local).AddTicks(1877), "itaque" },
                    { 352, 8, 51, 443830, new DateTime(2020, 11, 16, 13, 13, 46, 978, DateTimeKind.Local).AddTicks(950), "Ex quisquam nihil eligendi quia vero.\nSed molestias alias.\nExcepturi in aliquam enim dolores aspernatur." },
                    { 490, 8, 4, 614813, new DateTime(2021, 5, 10, 0, 6, 28, 296, DateTimeKind.Local).AddTicks(7658), "dolor" },
                    { 503, 8, 19, 650407, new DateTime(2021, 7, 26, 22, 6, 53, 136, DateTimeKind.Local).AddTicks(4859), "Ut ipsa animi nobis.\nNam autem nihil architecto dignissimos unde voluptas in ea." },
                    { 581, 76, 24, 320401, new DateTime(2020, 11, 16, 10, 10, 53, 220, DateTimeKind.Local).AddTicks(2746), "Quasi pariatur cum occaecati qui delectus sint repellendus odio exercitationem. Nulla sit eligendi aut explicabo quaerat sed quo fugit. Facilis rerum iste." },
                    { 562, 76, 129, 516003, new DateTime(2020, 9, 8, 10, 34, 50, 549, DateTimeKind.Local).AddTicks(2390), "Aut sunt non veritatis tenetur provident. Et ab aut. Accusamus commodi rem. Harum et rerum eum hic." },
                    { 516, 76, 79, 215671, new DateTime(2021, 5, 12, 4, 7, 40, 492, DateTimeKind.Local).AddTicks(442), "Odit fugit sed minus in fugit. Libero nostrum aut repellendus ut eaque ullam ipsum quas. Enim ut aliquid nisi at aut a. Tempora et soluta sit dolorum commodi." },
                    { 15, 8, 37, 858101, new DateTime(2020, 10, 25, 6, 27, 30, 110, DateTimeKind.Local).AddTicks(304), "Fugiat cumque consectetur quia vitae." },
                    { 205, 30, 113, 672998, new DateTime(2020, 9, 18, 9, 44, 19, 227, DateTimeKind.Local).AddTicks(173), "Sed ad dolorum qui non.\nSit voluptatum numquam voluptatem exercitationem adipisci omnis nam.\nUt velit ut officiis velit blanditiis et commodi.\nMagnam sint qui consequatur consequatur accusantium.\nIste enim illum nam mollitia porro omnis id cupiditate.\nTotam placeat quia." },
                    { 505, 75, 37, 714202, new DateTime(2021, 2, 18, 1, 54, 58, 920, DateTimeKind.Local).AddTicks(9857), "tempora" },
                    { 547, 75, 12, 448373, new DateTime(2021, 6, 24, 7, 50, 51, 225, DateTimeKind.Local).AddTicks(7990), "Quos nesciunt consequatur." },
                    { 554, 65, 124, 958264, new DateTime(2021, 5, 6, 23, 25, 3, 250, DateTimeKind.Local).AddTicks(4847), "Tempora temporibus quasi officia dolorum fuga animi. Ducimus repellat delectus ut explicabo. Cum placeat minima maxime. Rem ea perferendis modi itaque sed delectus quasi corrupti. Dolorem voluptatem culpa nulla ut quia voluptatem eius." },
                    { 558, 65, 127, 903393, new DateTime(2021, 5, 11, 1, 19, 36, 45, DateTimeKind.Local).AddTicks(6375), "Corrupti cum numquam culpa iste non laudantium. Voluptas est beatae sint tempore officiis quasi. Unde rem deleniti soluta voluptatem necessitatibus. In soluta beatae placeat eum dolores officiis architecto. Aut cum explicabo laboriosam sequi dolor non." },
                    { 511, 58, 91, 507157, new DateTime(2021, 3, 20, 18, 49, 31, 27, DateTimeKind.Local).AddTicks(5851), "Voluptas non distinctio adipisci non laudantium ut dicta quia.\nVeniam cum accusantium officiis ut et non ipsum.\nEnim quod qui enim facere autem.\nAut tenetur vero ea optio vero dolores eum." },
                    { 496, 58, 100, 63385, new DateTime(2020, 12, 23, 14, 23, 11, 737, DateTimeKind.Local).AddTicks(9136), "Cumque fuga voluptas.\nSit soluta aut vitae fugiat cumque deleniti." },
                    { 21, 74, 91, 643247, new DateTime(2020, 8, 31, 5, 41, 36, 41, DateTimeKind.Local).AddTicks(9502), "Vel quibusdam necessitatibus aliquam aliquam corrupti dolore." },
                    { 71, 74, 93, 760076, new DateTime(2021, 6, 20, 8, 28, 29, 611, DateTimeKind.Local).AddTicks(9483), "pariatur" },
                    { 340, 74, 93, 552045, new DateTime(2021, 7, 26, 3, 34, 2, 747, DateTimeKind.Local).AddTicks(8512), "minima" },
                    { 426, 74, 128, 560732, new DateTime(2021, 3, 26, 1, 35, 14, 47, DateTimeKind.Local).AddTicks(6451), "quos" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 486, 74, 96, 588016, new DateTime(2021, 1, 4, 21, 14, 22, 224, DateTimeKind.Local).AddTicks(9715), "Eveniet qui repellat aut distinctio consequatur quaerat.\nId qui et.\nNostrum suscipit occaecati rerum aut amet possimus explicabo est nemo.\nQuia et totam et in repudiandae harum." },
                    { 491, 74, 32, 542561, new DateTime(2020, 9, 5, 5, 2, 28, 637, DateTimeKind.Local).AddTicks(1437), "Blanditiis architecto et dolorem enim debitis." },
                    { 470, 58, 130, 618460, new DateTime(2020, 11, 28, 9, 55, 45, 760, DateTimeKind.Local).AddTicks(5373), "Quisquam voluptatum est et iusto adipisci magni.\nRecusandae nam dolores nihil velit expedita.\nQuaerat et quos eaque totam.\nConsequatur aut est beatae qui." },
                    { 460, 58, 33, 121020, new DateTime(2021, 5, 26, 19, 14, 50, 296, DateTimeKind.Local).AddTicks(4518), "sit" },
                    { 5, 30, 124, 760824, new DateTime(2021, 6, 18, 14, 47, 12, 483, DateTimeKind.Local).AddTicks(657), "Nihil reiciendis possimus non eveniet alias et qui. Ratione placeat magnam veniam non et rerum odio tempora quia. Nisi in enim aut. Recusandae ducimus repudiandae. Enim sint maiores eos est." },
                    { 7, 30, 144, 489441, new DateTime(2021, 2, 15, 20, 33, 32, 133, DateTimeKind.Local).AddTicks(2695), "Tempore reprehenderit eum et animi velit expedita porro." },
                    { 10, 30, 11, 294480, new DateTime(2021, 8, 9, 23, 29, 14, 266, DateTimeKind.Local).AddTicks(1964), "doloribus" },
                    { 529, 65, 1, 181295, new DateTime(2020, 9, 30, 6, 51, 50, 290, DateTimeKind.Local).AddTicks(4566), "Aut nulla omnis et assumenda aspernatur quis est dolor est." },
                    { 419, 65, 115, 79848, new DateTime(2020, 9, 27, 15, 14, 43, 552, DateTimeKind.Local).AddTicks(5882), "Quasi odio earum magni tempore eos minus et.\nNulla et similique explicabo eius quod delectus." },
                    { 383, 65, 125, 821582, new DateTime(2020, 10, 27, 13, 34, 19, 835, DateTimeKind.Local).AddTicks(216), "Quasi harum asperiores." },
                    { 343, 65, 120, 996690, new DateTime(2021, 8, 9, 8, 3, 9, 702, DateTimeKind.Local).AddTicks(6799), "Veniam eum deleniti corporis magnam dolor autem consequatur voluptatem. Et beatae nostrum rerum quasi sit. A nobis dolor sed non ut. Quod molestiae quisquam quibusdam." },
                    { 284, 76, 5, 114814, new DateTime(2021, 7, 17, 11, 42, 40, 751, DateTimeKind.Local).AddTicks(5105), "Eum nemo quia molestiae laudantium." },
                    { 48, 76, 142, 515379, new DateTime(2021, 1, 4, 16, 15, 7, 426, DateTimeKind.Local).AddTicks(678), "Aut quo voluptates velit et ipsum voluptatem." },
                    { 70, 71, 94, 633966, new DateTime(2021, 3, 6, 9, 12, 28, 496, DateTimeKind.Local).AddTicks(3219), "Porro asperiores esse illum blanditiis voluptas porro molestias debitis omnis. Dolor qui velit porro quis facilis eum animi. Beatae aspernatur omnis et. Sit non alias possimus a. Dignissimos quos voluptates provident dignissimos nihil. Veritatis error quas quia vel error velit accusantium." },
                    { 147, 71, 124, 627128, new DateTime(2020, 9, 28, 12, 15, 5, 751, DateTimeKind.Local).AddTicks(7867), "Deserunt dicta rem dolores dolorem fugit sint. Et eveniet cum. Reprehenderit voluptas exercitationem tenetur. Qui laudantium et. Enim autem tenetur sit ullam rerum cumque. Optio sit et delectus ipsam tenetur nesciunt delectus atque et." },
                    { 276, 71, 117, 670681, new DateTime(2021, 3, 2, 21, 3, 12, 822, DateTimeKind.Local).AddTicks(620), "Consequatur voluptatem minima et. Sit vel sed vitae sit dolorem esse non delectus optio. Voluptates amet voluptatibus aspernatur dolores inventore suscipit ut. Doloremque aut expedita alias ullam voluptas repudiandae illo omnis aut. Consequatur fuga animi. Et laudantium aliquid est facilis rerum consequuntur." },
                    { 436, 71, 52, 786470, new DateTime(2021, 7, 16, 15, 6, 59, 818, DateTimeKind.Local).AddTicks(3984), "Doloremque blanditiis quibusdam. Quis molestiae voluptatem enim. Voluptatem cum saepe officia officiis. Aliquid voluptas nulla pariatur qui. Sequi quasi ipsum repellat." },
                    { 466, 71, 28, 809761, new DateTime(2021, 1, 21, 22, 58, 7, 715, DateTimeKind.Local).AddTicks(7399), "cumque" },
                    { 513, 75, 49, 395753, new DateTime(2021, 3, 22, 3, 11, 28, 763, DateTimeKind.Local).AddTicks(4103), "Explicabo iure numquam et.\nAmet ea reprehenderit incidunt voluptas ipsa molestiae sit rerum." },
                    { 487, 71, 47, 200711, new DateTime(2021, 6, 9, 16, 58, 22, 127, DateTimeKind.Local).AddTicks(1877), "Aut consequatur adipisci debitis voluptate iusto sed.\nEligendi qui veritatis esse.\nIn veniam assumenda.\nDoloribus officia aut qui tempore.\nAut vero fugit ut.\nEt veritatis expedita temporibus ut ipsa aperiam autem natus." },
                    { 531, 71, 4, 847293, new DateTime(2020, 11, 20, 5, 41, 12, 555, DateTimeKind.Local).AddTicks(6270), "Perferendis et eum vel. Veniam perspiciatis aut dolorem neque enim dolorum quia dolores. Praesentium laudantium tenetur. Ipsum nam officia nihil corporis ut. Sed id quis perferendis molestiae totam. Provident cum veniam aliquid esse non et voluptatibus voluptatem." },
                    { 573, 71, 36, 998017, new DateTime(2021, 7, 7, 12, 41, 26, 139, DateTimeKind.Local).AddTicks(5306), "Occaecati iusto sed quod voluptates impedit." },
                    { 126, 65, 60, 814789, new DateTime(2021, 8, 9, 23, 7, 32, 773, DateTimeKind.Local).AddTicks(4035), "Aut neque rem aut sed dignissimos qui et.\nCum aut reiciendis aliquid incidunt numquam minus possimus similique assumenda.\nVoluptatibus fugiat ut tempore cumque quasi beatae harum accusantium.\nIpsa quos hic et et quae quia sit assumenda et.\nNeque et provident et blanditiis dolor iure maiores.\nEa officiis molestiae et porro." },
                    { 224, 65, 86, 750037, new DateTime(2020, 11, 3, 2, 50, 7, 999, DateTimeKind.Local).AddTicks(5863), "Itaque voluptas voluptatem placeat adipisci sit dolorem distinctio eum." },
                    { 234, 65, 40, 225136, new DateTime(2021, 6, 3, 2, 28, 45, 472, DateTimeKind.Local).AddTicks(4475), "vel" },
                    { 302, 65, 104, 787737, new DateTime(2020, 12, 26, 19, 17, 20, 87, DateTimeKind.Local).AddTicks(8220), "Neque non ab placeat. Nam eum illo omnis omnis et exercitationem. Rerum aut accusantium deserunt rerum et nam." },
                    { 333, 65, 140, 552054, new DateTime(2021, 6, 30, 3, 50, 35, 531, DateTimeKind.Local).AddTicks(5684), "harum" },
                    { 515, 71, 113, 993102, new DateTime(2020, 12, 23, 18, 10, 15, 966, DateTimeKind.Local).AddTicks(9737), "laudantium" },
                    { 430, 78, 118, 629812, new DateTime(2021, 4, 5, 6, 50, 17, 47, DateTimeKind.Local).AddTicks(6043), "recusandae" },
                    { 457, 78, 126, 790625, new DateTime(2021, 1, 17, 5, 23, 41, 705, DateTimeKind.Local).AddTicks(7837), "dolor" },
                    { 549, 78, 138, 911202, new DateTime(2020, 12, 20, 4, 1, 16, 834, DateTimeKind.Local).AddTicks(1356), "Eos tenetur voluptatem qui officiis beatae cum ut dicta." },
                    { 8, 36, 76, 136670, new DateTime(2021, 2, 19, 18, 35, 32, 928, DateTimeKind.Local).AddTicks(5457), "Iure veritatis illo velit quidem sapiente et velit assumenda." },
                    { 51, 36, 90, 489165, new DateTime(2021, 5, 19, 0, 32, 30, 229, DateTimeKind.Local).AddTicks(5602), "Voluptates dolorem sed est sed illo molestias. Voluptatem id iste itaque sed et porro voluptas explicabo veniam. Odio non et. Doloremque est quam quis praesentium corporis aut veritatis. Et sed eius neque doloremque est. Assumenda voluptatem est iste ut deserunt mollitia sit." },
                    { 83, 36, 118, 383671, new DateTime(2020, 9, 10, 13, 13, 21, 226, DateTimeKind.Local).AddTicks(8636), "Necessitatibus commodi laboriosam. Est possimus porro quia dolor nemo nihil autem sed. Quia sed accusantium temporibus temporibus ducimus aut." },
                    { 195, 36, 70, 779781, new DateTime(2021, 4, 5, 23, 23, 5, 105, DateTimeKind.Local).AddTicks(8481), "Non explicabo distinctio. Assumenda corrupti voluptatem deleniti ad. Laborum at quisquam accusantium ad voluptas dicta. Consequuntur consequatur quibusdam et." },
                    { 223, 36, 98, 151124, new DateTime(2021, 2, 10, 18, 53, 20, 876, DateTimeKind.Local).AddTicks(1121), "Tempore qui enim qui tenetur." },
                    { 279, 36, 72, 491941, new DateTime(2021, 7, 8, 20, 11, 23, 23, DateTimeKind.Local).AddTicks(4115), "Commodi voluptatem vero in qui veniam officia blanditiis adipisci tempore. Nobis fuga repellat et corrupti maiores dolores occaecati. Voluptatibus quia tempore et molestiae asperiores eveniet impedit atque. Ut similique nemo qui cupiditate aut harum explicabo." },
                    { 312, 4, 94, 593835, new DateTime(2021, 6, 25, 14, 28, 16, 312, DateTimeKind.Local).AddTicks(6910), "Eum aspernatur eligendi sint est. Explicabo officiis eaque sed id voluptatem consequatur dolore et. Ut minus quasi asperiores numquam et minus architecto mollitia quis. Inventore architecto voluptatem consequatur omnis molestias ipsum voluptatum autem. Ut temporibus et sunt enim fugit tempore autem atque." },
                    { 579, 56, 79, 765594, new DateTime(2020, 8, 27, 23, 1, 36, 745, DateTimeKind.Local).AddTicks(8024), "Dolor sit rem.\nEt eos incidunt in voluptate veritatis incidunt excepturi dolore.\nVoluptatem consequuntur accusamus." },
                    { 568, 56, 13, 582293, new DateTime(2021, 5, 30, 17, 59, 25, 611, DateTimeKind.Local).AddTicks(5101), "tempore" },
                    { 92, 21, 89, 279765, new DateTime(2021, 3, 4, 1, 32, 27, 225, DateTimeKind.Local).AddTicks(8426), "Voluptates cupiditate et corporis. Sequi fuga aliquid qui eum est. Reiciendis voluptas modi sed illo sit assumenda ratione culpa. Enim laborum debitis ut aut non. Voluptatem fuga blanditiis dolor sapiente voluptatibus." },
                    { 379, 21, 38, 104150, new DateTime(2020, 10, 13, 17, 51, 31, 353, DateTimeKind.Local).AddTicks(7498), "Blanditiis neque dolore ut sapiente inventore et commodi est animi. Dolorum ut maiores modi sit ut recusandae facere. Ad pariatur cumque hic est quo a harum dolor. Eius ipsum et ea quisquam." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 508, 21, 23, 669951, new DateTime(2020, 12, 7, 19, 0, 4, 419, DateTimeKind.Local).AddTicks(5418), "Ratione est iusto voluptatem dolore ex. Ut in perspiciatis minus atque omnis et. Dolore odit ipsa necessitatibus quaerat adipisci aut ut harum voluptates. Incidunt officiis alias magni." },
                    { 518, 21, 53, 575873, new DateTime(2021, 8, 27, 1, 1, 47, 618, DateTimeKind.Local).AddTicks(1898), "Odio quis alias ipsa magnam." },
                    { 588, 21, 27, 767534, new DateTime(2021, 4, 29, 5, 54, 35, 475, DateTimeKind.Local).AddTicks(426), "Debitis sit optio distinctio debitis vero aperiam occaecati velit tempore.\nNesciunt eaque expedita.\nOccaecati fuga qui inventore amet quibusdam est est.\nReprehenderit ut quis nihil deleniti quia sed et accusantium." },
                    { 480, 56, 83, 165995, new DateTime(2021, 6, 1, 11, 3, 47, 694, DateTimeKind.Local).AddTicks(1987), "excepturi" },
                    { 360, 4, 28, 119984, new DateTime(2021, 7, 18, 20, 4, 50, 605, DateTimeKind.Local).AddTicks(6732), "Reiciendis officia neque aut sed aspernatur velit.\nReprehenderit minima voluptates quaerat repudiandae.\nQui non a velit non." },
                    { 382, 4, 99, 906039, new DateTime(2021, 4, 7, 8, 25, 20, 383, DateTimeKind.Local).AddTicks(3034), "odio" },
                    { 413, 4, 87, 756687, new DateTime(2020, 9, 17, 11, 49, 49, 564, DateTimeKind.Local).AddTicks(5693), "Exercitationem provident pariatur exercitationem error doloribus animi officia aperiam.\nAnimi aspernatur qui et earum ipsam.\nQuia sit magnam id voluptas autem.\nVero voluptas id.\nError molestias repellat enim voluptatem odio qui unde nulla." },
                    { 498, 64, 90, 756093, new DateTime(2021, 5, 9, 2, 43, 53, 277, DateTimeKind.Local).AddTicks(4837), "Ratione porro commodi et fugit dolores totam.\nQuisquam et id optio quo commodi ipsam voluptas consequatur quod.\nId error itaque sed repellendus blanditiis." },
                    { 308, 60, 110, 284689, new DateTime(2021, 6, 18, 23, 6, 54, 246, DateTimeKind.Local).AddTicks(1780), "ab" },
                    { 334, 60, 67, 699672, new DateTime(2020, 12, 5, 18, 10, 24, 871, DateTimeKind.Local).AddTicks(7404), "Rem sed et quae qui sint." },
                    { 351, 60, 76, 703512, new DateTime(2021, 4, 11, 9, 6, 22, 935, DateTimeKind.Local).AddTicks(1905), "Ullam qui accusantium ipsa nihil omnis tempore." },
                    { 421, 60, 107, 228373, new DateTime(2021, 5, 23, 0, 27, 49, 907, DateTimeKind.Local).AddTicks(7977), "Voluptatem eaque quis optio similique rerum libero iusto." },
                    { 462, 60, 123, 366603, new DateTime(2020, 9, 18, 5, 16, 19, 108, DateTimeKind.Local).AddTicks(4872), "Dolore quam totam. Voluptatibus ab eaque dolores et a. Necessitatibus enim neque qui minima ducimus sunt. Ipsa repellendus id minus molestias unde." },
                    { 519, 60, 74, 673320, new DateTime(2021, 1, 2, 17, 26, 55, 113, DateTimeKind.Local).AddTicks(3120), "aut" },
                    { 566, 60, 13, 655682, new DateTime(2021, 6, 29, 4, 16, 10, 281, DateTimeKind.Local).AddTicks(3261), "Labore voluptatem et eligendi et quaerat odio.\nDistinctio minima dolorem in amet dolores nobis iure voluptatem dolores.\nDicta fugiat sit qui eveniet porro.\nConsequatur non et aut dolore non porro enim ad at." },
                    { 478, 56, 21, 511646, new DateTime(2020, 10, 22, 4, 30, 46, 71, DateTimeKind.Local).AddTicks(8764), "sunt" },
                    { 584, 60, 11, 120315, new DateTime(2020, 9, 10, 9, 40, 33, 301, DateTimeKind.Local).AddTicks(7484), "Repudiandae et odit sed eveniet delectus molestiae." },
                    { 595, 60, 112, 928444, new DateTime(2020, 12, 5, 0, 57, 37, 6, DateTimeKind.Local).AddTicks(9732), "Incidunt natus sint voluptas tempore porro nam exercitationem. Odit repellendus eum adipisci labore nostrum modi dolorem consequatur laborum. Quia qui hic fuga necessitatibus temporibus." },
                    { 599, 60, 77, 133287, new DateTime(2021, 1, 13, 1, 18, 10, 131, DateTimeKind.Local).AddTicks(9687), "Doloribus id natus et et cupiditate nihil qui est laudantium." },
                    { 586, 4, 77, 881111, new DateTime(2021, 5, 30, 17, 26, 16, 651, DateTimeKind.Local).AddTicks(9632), "Reprehenderit ut aliquid temporibus et labore sit rerum minus corporis." },
                    { 570, 4, 98, 866478, new DateTime(2021, 7, 14, 7, 54, 48, 746, DateTimeKind.Local).AddTicks(1709), "Vero fugiat tempora dolores assumenda quia illo praesentium omnis eos. Id repudiandae optio veniam quae. Neque et quia sunt eius sequi. Soluta veritatis amet quia aut beatae veniam. Aliquam sequi vel velit ex amet ipsam. Blanditiis minima quas iste magnam quis facere velit fuga numquam." },
                    { 329, 64, 32, 330947, new DateTime(2020, 12, 31, 11, 35, 32, 324, DateTimeKind.Local).AddTicks(864), "Nobis corporis dolorem.\nNecessitatibus sunt magni suscipit enim culpa voluptatem voluptatem culpa." },
                    { 443, 64, 58, 14239, new DateTime(2021, 4, 30, 20, 36, 49, 536, DateTimeKind.Local).AddTicks(4057), "Repellat facilis perspiciatis iste. Dignissimos quia libero voluptas sit. Aut quisquam in hic facilis tempora in." },
                    { 492, 64, 141, 573279, new DateTime(2020, 12, 8, 5, 42, 22, 218, DateTimeKind.Local).AddTicks(4950), "temporibus" },
                    { 594, 60, 78, 768570, new DateTime(2021, 1, 21, 9, 17, 40, 321, DateTimeKind.Local).AddTicks(311), "Minus id ipsum et nam ratione labore.\nQuas atque qui sit accusantium quis dolor.\nSed sit placeat qui explicabo velit.\nModi consequatur omnis ea excepturi." },
                    { 304, 60, 62, 185844, new DateTime(2021, 7, 8, 7, 39, 46, 420, DateTimeKind.Local).AddTicks(9794), "Dolores ut sunt a repellendus deleniti aut. Provident animi inventore minima et nulla nihil. Delectus est vero quia sint perspiciatis autem quam ea tempore. Facilis eaque nobis et dolorem aut quod totam sint. Et consequatur nesciunt et sunt." },
                    { 477, 56, 147, 998822, new DateTime(2020, 9, 12, 5, 37, 34, 877, DateTimeKind.Local).AddTicks(1224), "Officia numquam in." },
                    { 467, 56, 71, 147900, new DateTime(2021, 5, 24, 17, 14, 0, 246, DateTimeKind.Local).AddTicks(1151), "et" },
                    { 230, 12, 50, 973917, new DateTime(2021, 5, 25, 11, 13, 26, 842, DateTimeKind.Local).AddTicks(7190), "Debitis ut facere possimus. Quia et libero culpa et. Accusantium nesciunt ut est." },
                    { 12, 7, 83, 743361, new DateTime(2020, 12, 23, 20, 36, 47, 877, DateTimeKind.Local).AddTicks(2914), "Sed qui quidem suscipit sit eos modi quis. Aperiam consectetur accusamus velit sint et nihil aliquam reiciendis architecto. Id a unde et consequuntur." },
                    { 16, 7, 71, 878020, new DateTime(2021, 3, 30, 17, 40, 6, 479, DateTimeKind.Local).AddTicks(917), "perferendis" },
                    { 17, 7, 34, 903246, new DateTime(2020, 10, 24, 11, 40, 9, 331, DateTimeKind.Local).AddTicks(8578), "quidem" },
                    { 36, 7, 40, 685431, new DateTime(2020, 12, 14, 23, 36, 35, 865, DateTimeKind.Local).AddTicks(4315), "Enim nam voluptas unde. Deserunt aut consequatur voluptate quis fuga commodi dolorem qui earum. Sunt occaecati labore eveniet maxime vel corporis sed quo aut. Fugit corrupti aut." },
                    { 57, 7, 10, 698208, new DateTime(2020, 12, 5, 17, 20, 44, 18, DateTimeKind.Local).AddTicks(9093), "odio" },
                    { 73, 7, 23, 199739, new DateTime(2020, 11, 23, 15, 4, 40, 826, DateTimeKind.Local).AddTicks(3710), "Sed nobis illum. Enim et sit assumenda aperiam qui possimus porro. Iure quaerat ut in. Dolores quod quidem aliquam. Alias voluptates incidunt consequatur aspernatur fuga recusandae repellendus. Laudantium et non nisi distinctio delectus animi." },
                    { 221, 7, 93, 609385, new DateTime(2020, 10, 8, 10, 53, 26, 506, DateTimeKind.Local).AddTicks(5855), "Molestias laudantium voluptatem magnam." },
                    { 288, 7, 62, 886192, new DateTime(2021, 2, 23, 13, 27, 15, 591, DateTimeKind.Local).AddTicks(3349), "Neque quia excepturi molestiae aut dolorum in aut distinctio omnis.\nAb hic ducimus sunt rem." },
                    { 345, 7, 53, 571852, new DateTime(2021, 1, 17, 19, 12, 16, 879, DateTimeKind.Local).AddTicks(6431), "velit" },
                    { 393, 7, 125, 864398, new DateTime(2021, 2, 19, 14, 29, 41, 744, DateTimeKind.Local).AddTicks(7447), "Dignissimos eaque ut modi accusantium qui architecto nihil. Numquam delectus incidunt harum ut. Nihil harum numquam voluptatem explicabo est et animi laudantium. Id reiciendis voluptas possimus sint et mollitia est nostrum. Autem aperiam ut laboriosam ut aut nisi necessitatibus dolores nesciunt. Non consequuntur illo nisi eos et." },
                    { 576, 7, 67, 688840, new DateTime(2021, 3, 8, 11, 48, 3, 361, DateTimeKind.Local).AddTicks(2095), "Eius nihil dicta atque molestias ut exercitationem veniam vitae.\nLaborum cupiditate consequatur repellendus inventore nam expedita.\nSit sed numquam beatae." },
                    { 226, 12, 54, 499354, new DateTime(2020, 8, 31, 6, 22, 6, 184, DateTimeKind.Local).AddTicks(6166), "Velit provident temporibus id a animi." },
                    { 139, 12, 65, 262382, new DateTime(2021, 5, 1, 2, 23, 14, 596, DateTimeKind.Local).AddTicks(2918), "quae" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 94, 12, 74, 566516, new DateTime(2020, 11, 16, 14, 16, 34, 763, DateTimeKind.Local).AddTicks(6004), "est" },
                    { 398, 12, 74, 284487, new DateTime(2020, 9, 15, 14, 45, 34, 852, DateTimeKind.Local).AddTicks(3029), "Et ab ut.\nVeritatis natus culpa veritatis.\nPorro quod et et qui omnis.\nOccaecati veritatis eius." },
                    { 451, 12, 119, 753627, new DateTime(2021, 1, 19, 3, 56, 32, 406, DateTimeKind.Local).AddTicks(8745), "Non dolore quod dolorem eveniet aut.\nQui aliquid quam et blanditiis vitae maiores architecto.\nBeatae delectus aperiam quisquam eius et nesciunt expedita sit vitae.\nEnim incidunt quo ex sint fuga eveniet.\nEst est sint labore ratione." },
                    { 544, 12, 80, 35102, new DateTime(2021, 4, 17, 14, 46, 26, 416, DateTimeKind.Local).AddTicks(690), "Eos est fuga et explicabo.\nMolestias sed accusamus voluptas maiores laudantium beatae fuga.\nEa dicta sed et.\nPlaceat suscipit non cumque sit veniam et." },
                    { 541, 66, 111, 324356, new DateTime(2020, 12, 14, 13, 9, 4, 836, DateTimeKind.Local).AddTicks(6172), "sint" },
                    { 191, 2, 141, 737411, new DateTime(2020, 11, 30, 15, 55, 10, 457, DateTimeKind.Local).AddTicks(6228), "nihil" },
                    { 220, 2, 56, 931929, new DateTime(2020, 9, 17, 17, 36, 20, 648, DateTimeKind.Local).AddTicks(7301), "Aut asperiores quis magnam vero et qui et fuga. Voluptatum sed impedit ullam qui quas odio eaque voluptatum. Est voluptatem odio. Magnam ipsa voluptatem qui perspiciatis." },
                    { 324, 2, 131, 978650, new DateTime(2021, 5, 19, 15, 9, 27, 773, DateTimeKind.Local).AddTicks(2516), "Facilis quo quibusdam molestiae ullam hic totam atque.\nEst aspernatur quasi consequatur.\nAut qui sint maiores a culpa voluptatem." },
                    { 336, 2, 142, 577471, new DateTime(2021, 8, 2, 9, 11, 22, 891, DateTimeKind.Local).AddTicks(8655), "ex" },
                    { 381, 2, 130, 261679, new DateTime(2020, 12, 22, 15, 47, 59, 920, DateTimeKind.Local).AddTicks(6810), "Sit quas ullam dolorem tenetur aut.\nUt voluptatem culpa iure delectus et molestiae.\nDolor iusto quibusdam quam.\nEos voluptatem earum enim nulla." },
                    { 362, 56, 16, 771716, new DateTime(2020, 9, 24, 19, 20, 3, 627, DateTimeKind.Local).AddTicks(2229), "Maxime placeat quia eum et cumque aut consequuntur qui.\nDistinctio consectetur qui recusandae voluptate.\nQui tempora tempore voluptatem deserunt est ipsum similique delectus similique.\nLabore sint est consequatur qui rem consequatur ullam.\nEos sequi debitis est magni id." },
                    { 339, 56, 113, 654881, new DateTime(2020, 10, 7, 15, 7, 34, 763, DateTimeKind.Local).AddTicks(1158), "Illum praesentium aperiam fugiat aut nostrum. Voluptatibus optio architecto deleniti voluptatem atque natus qui quibusdam. Velit beatae exercitationem repellendus et nihil possimus maxime omnis. Qui facilis doloremque quo ipsa ut. Quas aliquam ratione similique consectetur esse quo consequuntur voluptas. Fuga suscipit officia alias eum corporis omnis commodi." },
                    { 472, 56, 12, 382366, new DateTime(2021, 1, 18, 14, 56, 1, 377, DateTimeKind.Local).AddTicks(1511), "Nulla aut quia officiis laboriosam sed quo nulla.\nAliquid aut voluptatum soluta est.\nQuaerat sed fugiat eos.\nEt magnam delectus." },
                    { 275, 56, 32, 597736, new DateTime(2021, 4, 16, 5, 30, 17, 459, DateTimeKind.Local).AddTicks(895), "qui" },
                    { 246, 56, 6, 124874, new DateTime(2021, 8, 8, 14, 53, 39, 476, DateTimeKind.Local).AddTicks(5560), "Eum veniam laboriosam impedit. Quaerat recusandae quisquam laudantium voluptas qui. Quas nobis distinctio numquam ex accusamus alias. Qui corrupti ab et sit perferendis ut. Et dolorum at reiciendis. Nulla perferendis aut id qui." },
                    { 50, 56, 127, 763615, new DateTime(2021, 6, 14, 5, 49, 26, 151, DateTimeKind.Local).AddTicks(481), "Et ad quia quaerat nostrum consectetur nam et dolores voluptates. Alias fuga consequuntur doloribus similique ullam. Qui assumenda qui nihil in ratione sed accusamus et." },
                    { 1, 66, 134, 271559, new DateTime(2021, 1, 18, 15, 12, 44, 635, DateTimeKind.Local).AddTicks(5822), "Quibusdam illum incidunt aut esse. Eius mollitia debitis. Voluptas temporibus pariatur reprehenderit." },
                    { 240, 66, 94, 976281, new DateTime(2020, 11, 3, 18, 32, 18, 858, DateTimeKind.Local).AddTicks(162), "modi" },
                    { 368, 66, 60, 417707, new DateTime(2021, 6, 4, 6, 39, 29, 200, DateTimeKind.Local).AddTicks(3535), "Non illo aspernatur est vero est qui voluptatem beatae.\nNostrum molestias et at quibusdam omnis porro.\nHarum est blanditiis quia ut voluptates ipsum iusto ut rerum.\nOmnis dolores numquam voluptate rerum fugiat corporis deserunt.\nQuasi et et amet quis aut nihil ipsum est fuga." },
                    { 372, 66, 92, 71221, new DateTime(2021, 4, 23, 3, 17, 10, 520, DateTimeKind.Local).AddTicks(8780), "Est expedita illum facilis voluptatibus sapiente." },
                    { 410, 66, 18, 109004, new DateTime(2021, 7, 28, 1, 14, 35, 266, DateTimeKind.Local).AddTicks(9672), "Qui voluptatem est voluptatum ipsa commodi ut voluptatem. Rerum non non. Ducimus perspiciatis labore odio aut ex." },
                    { 264, 56, 97, 546282, new DateTime(2021, 3, 16, 6, 24, 18, 723, DateTimeKind.Local).AddTicks(995), "Beatae assumenda quisquam fugiat quasi eveniet vero culpa rerum. Esse omnis maxime. Consequatur voluptatem maiores." },
                    { 262, 60, 119, 678792, new DateTime(2021, 8, 25, 9, 30, 8, 391, DateTimeKind.Local).AddTicks(8717), "qui" },
                    { 255, 60, 17, 342339, new DateTime(2020, 11, 23, 20, 16, 32, 773, DateTimeKind.Local).AddTicks(629), "Minus impedit quia cupiditate voluptas sint. Ipsum autem esse id et molestiae iste sed. Qui aut id aut sed." },
                    { 252, 60, 68, 382226, new DateTime(2021, 7, 9, 10, 43, 37, 731, DateTimeKind.Local).AddTicks(579), "vel" },
                    { 267, 80, 6, 884964, new DateTime(2021, 2, 23, 2, 57, 2, 205, DateTimeKind.Local).AddTicks(5076), "Praesentium ratione voluptatem molestiae.\nMolestiae ut assumenda perspiciatis ad ipsam magni est.\nCorporis consequatur distinctio nostrum.\nEaque perferendis labore sequi quia ut.\nFacere id eos dolor expedita sunt maxime sit eos enim.\nReiciendis et dolores alias eos minima maiores labore vel." },
                    { 440, 80, 56, 724727, new DateTime(2020, 9, 11, 5, 42, 21, 335, DateTimeKind.Local).AddTicks(9692), "Debitis eum fuga adipisci quaerat eos minima molestiae consequatur voluptatibus. Perspiciatis et officia incidunt laboriosam ut. Ullam ut inventore ab rerum." },
                    { 488, 80, 135, 844448, new DateTime(2021, 1, 4, 4, 47, 24, 875, DateTimeKind.Local).AddTicks(7001), "id" },
                    { 153, 6, 137, 646471, new DateTime(2021, 4, 24, 17, 43, 53, 326, DateTimeKind.Local).AddTicks(5800), "Molestiae sint voluptates quia laudantium. Architecto voluptas harum accusamus ducimus provident qui odio. Quibusdam et cum culpa itaque sapiente." },
                    { 74, 19, 41, 999784, new DateTime(2020, 10, 2, 10, 12, 43, 913, DateTimeKind.Local).AddTicks(2949), "voluptatem" },
                    { 225, 19, 54, 248278, new DateTime(2021, 8, 14, 0, 14, 53, 466, DateTimeKind.Local).AddTicks(4048), "id" },
                    { 298, 19, 135, 712149, new DateTime(2020, 12, 19, 13, 27, 44, 323, DateTimeKind.Local).AddTicks(1435), "Ratione expedita error aut eaque quibusdam blanditiis.\nEst ut nostrum." },
                    { 348, 19, 38, 839415, new DateTime(2020, 11, 6, 8, 47, 6, 560, DateTimeKind.Local).AddTicks(4724), "Sunt dolores vero tenetur aut consequatur et cupiditate consectetur. Et dignissimos corrupti et eaque omnis. Quia vitae omnis. Optio libero sint necessitatibus aspernatur quia qui nesciunt quos. Minima quos quos. Molestias quos necessitatibus quis placeat ea sed." },
                    { 361, 19, 59, 292521, new DateTime(2021, 1, 27, 0, 31, 36, 661, DateTimeKind.Local).AddTicks(1402), "Enim nihil itaque qui maxime aut nisi nostrum ut provident." },
                    { 446, 19, 1, 470300, new DateTime(2021, 1, 24, 13, 33, 7, 343, DateTimeKind.Local).AddTicks(4684), "voluptates" },
                    { 464, 19, 87, 333992, new DateTime(2021, 7, 9, 19, 59, 26, 742, DateTimeKind.Local).AddTicks(9641), "Ab dignissimos fugit reprehenderit et fuga." },
                    { 556, 19, 19, 289101, new DateTime(2020, 10, 9, 15, 31, 6, 502, DateTimeKind.Local).AddTicks(424), "Dolorum minus eum consequuntur maxime inventore et provident.\nRepellendus et et distinctio reiciendis doloribus fugit aut ut repellendus." },
                    { 122, 6, 10, 835135, new DateTime(2020, 12, 17, 12, 48, 53, 681, DateTimeKind.Local).AddTicks(1412), "sed" },
                    { 37, 26, 10, 126557, new DateTime(2020, 9, 18, 17, 48, 12, 443, DateTimeKind.Local).AddTicks(9882), "impedit" },
                    { 142, 26, 49, 361283, new DateTime(2020, 10, 29, 9, 1, 21, 161, DateTimeKind.Local).AddTicks(7753), "libero" },
                    { 183, 80, 127, 600591, new DateTime(2021, 5, 23, 1, 21, 20, 670, DateTimeKind.Local).AddTicks(9992), "Quia inventore enim ducimus molestiae consequatur perferendis est dignissimos quia." },
                    { 270, 6, 18, 499613, new DateTime(2021, 5, 11, 22, 13, 45, 800, DateTimeKind.Local).AddTicks(6292), "Cupiditate doloribus iste." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 474, 6, 27, 536048, new DateTime(2021, 4, 25, 21, 26, 11, 934, DateTimeKind.Local).AddTicks(8457), "Ipsa vitae minus sequi assumenda vel rerum molestiae.\nNobis beatae incidunt.\nEt exercitationem repudiandae minima.\nVoluptates vero in voluptatum sed vero delectus." },
                    { 533, 6, 15, 606766, new DateTime(2021, 6, 21, 17, 25, 0, 878, DateTimeKind.Local).AddTicks(6162), "Labore voluptas assumenda cum qui assumenda odit quae maxime. Amet in illum vero molestiae. Aperiam qui deleniti repellendus. Impedit repellat modi rerum magnam ea dolorem enim. Quia ipsa iusto a est aperiam quaerat nihil doloribus. Reprehenderit et rem odit odio." },
                    { 47, 70, 22, 971811, new DateTime(2021, 7, 29, 11, 27, 43, 464, DateTimeKind.Local).AddTicks(7810), "Nam voluptates distinctio." },
                    { 53, 70, 63, 387940, new DateTime(2021, 7, 30, 19, 12, 28, 669, DateTimeKind.Local).AddTicks(8859), "Eos voluptatem repellat culpa voluptatem eos fuga qui quasi autem. Possimus architecto repellendus dolores eaque id corporis. Dolor sint est quisquam sed nemo sapiente. Voluptatem corporis voluptatibus voluptate ipsum. Aperiam est illo quas. Magnam sapiente est rerum qui non esse et eos suscipit." },
                    { 69, 70, 103, 910210, new DateTime(2021, 1, 25, 14, 55, 52, 515, DateTimeKind.Local).AddTicks(4991), "fugiat" },
                    { 106, 70, 103, 403081, new DateTime(2021, 4, 10, 16, 27, 49, 881, DateTimeKind.Local).AddTicks(2045), "Reiciendis ratione dolor et sapiente iusto velit nihil. Molestias consequatur harum commodi ipsum. Aut ipsa aliquid." },
                    { 325, 70, 59, 45587, new DateTime(2020, 10, 17, 20, 7, 3, 746, DateTimeKind.Local).AddTicks(5461), "Ut iste nobis occaecati fuga ad dolorem." },
                    { 493, 70, 36, 452419, new DateTime(2021, 1, 16, 22, 58, 6, 500, DateTimeKind.Local).AddTicks(9540), "Eius sint reprehenderit dolore quos aut quo odio quaerat minus.\nTotam velit voluptates ea at sapiente odit deleniti sunt.\nEt excepturi blanditiis." },
                    { 495, 70, 112, 689183, new DateTime(2020, 9, 23, 14, 3, 50, 81, DateTimeKind.Local).AddTicks(4357), "Enim accusamus non aut et consequatur dolor sed.\nSequi autem est ratione magni adipisci aspernatur repellat fugiat non.\nOdio ducimus odit accusamus ipsa blanditiis." },
                    { 277, 26, 104, 106752, new DateTime(2020, 10, 10, 2, 37, 7, 609, DateTimeKind.Local).AddTicks(9285), "non" },
                    { 31, 15, 60, 901252, new DateTime(2021, 6, 8, 0, 11, 5, 872, DateTimeKind.Local).AddTicks(9674), "Deleniti exercitationem quae nihil quo totam. Sit sed dolores. Dolor aut sequi hic numquam. Excepturi ea sequi sed et pariatur autem. Eos id quae accusamus officiis voluptatem quia." },
                    { 84, 15, 3, 298109, new DateTime(2021, 3, 27, 11, 11, 40, 127, DateTimeKind.Local).AddTicks(8320), "Aliquid dignissimos beatae.\nConsequatur temporibus ducimus sint doloribus aliquid ut culpa." },
                    { 238, 15, 98, 83079, new DateTime(2020, 10, 18, 14, 25, 11, 89, DateTimeKind.Local).AddTicks(9787), "necessitatibus" },
                    { 365, 15, 57, 245615, new DateTime(2020, 9, 28, 21, 54, 35, 584, DateTimeKind.Local).AddTicks(9235), "Consequatur delectus sed fuga quod vel." },
                    { 373, 15, 135, 294841, new DateTime(2021, 2, 1, 9, 55, 7, 766, DateTimeKind.Local).AddTicks(6599), "Provident nisi minus.\nBeatae sit nihil.\nQuo ut ea ut voluptas voluptates repudiandae." },
                    { 417, 15, 109, 221823, new DateTime(2021, 3, 14, 11, 31, 24, 104, DateTimeKind.Local).AddTicks(3411), "Reprehenderit dicta quas occaecati et dolorem incidunt et explicabo." },
                    { 524, 15, 18, 571442, new DateTime(2021, 3, 16, 11, 39, 24, 520, DateTimeKind.Local).AddTicks(3945), "fugit" },
                    { 528, 15, 107, 36583, new DateTime(2020, 12, 15, 20, 8, 24, 223, DateTimeKind.Local).AddTicks(4651), "Ut doloribus amet sapiente rerum quaerat a omnis." },
                    { 43, 15, 91, 800690, new DateTime(2021, 3, 26, 17, 48, 19, 552, DateTimeKind.Local).AddTicks(1222), "incidunt" },
                    { 445, 26, 57, 329404, new DateTime(2021, 3, 30, 9, 50, 44, 192, DateTimeKind.Local).AddTicks(5358), "consequuntur" },
                    { 561, 26, 76, 928681, new DateTime(2020, 9, 13, 3, 43, 34, 198, DateTimeKind.Local).AddTicks(2408), "Quis qui ut debitis omnis quasi ad." },
                    { 578, 69, 11, 135689, new DateTime(2021, 8, 4, 1, 45, 47, 362, DateTimeKind.Local).AddTicks(9681), "Consequatur qui officiis.\nEt occaecati consequatur ut." },
                    { 322, 25, 142, 602143, new DateTime(2021, 2, 19, 0, 51, 45, 752, DateTimeKind.Local).AddTicks(2879), "Officia et beatae rerum aut fugiat." },
                    { 370, 25, 147, 408337, new DateTime(2020, 12, 7, 13, 19, 1, 582, DateTimeKind.Local).AddTicks(4637), "Vel ut corporis perferendis architecto.\nEt sit quos.\nEst eos quo qui.\nEt autem corrupti repellat impedit." },
                    { 459, 25, 140, 646578, new DateTime(2021, 6, 15, 17, 8, 49, 252, DateTimeKind.Local).AddTicks(3609), "enim" },
                    { 463, 25, 48, 684669, new DateTime(2021, 8, 13, 14, 54, 18, 785, DateTimeKind.Local).AddTicks(3185), "Dignissimos sequi assumenda quo et ipsam labore. Totam est accusamus deleniti. Magnam molestias ratione doloremque eius ut. Laboriosam odio ut molestias est sapiente nulla." },
                    { 465, 25, 65, 130466, new DateTime(2021, 5, 27, 15, 16, 27, 633, DateTimeKind.Local).AddTicks(7407), "et" },
                    { 512, 25, 89, 25423, new DateTime(2020, 11, 27, 4, 51, 18, 633, DateTimeKind.Local).AddTicks(1410), "Est deserunt est provident ut iure quia." },
                    { 164, 22, 95, 199025, new DateTime(2021, 1, 23, 12, 37, 20, 826, DateTimeKind.Local).AddTicks(7458), "Recusandae aut ex dolor distinctio." },
                    { 134, 25, 105, 696758, new DateTime(2021, 7, 2, 6, 35, 15, 40, DateTimeKind.Local).AddTicks(9328), "Consequatur beatae debitis neque porro porro eius ex.\nNisi quos officia in dolorum." },
                    { 215, 22, 56, 776872, new DateTime(2020, 9, 24, 20, 9, 50, 69, DateTimeKind.Local).AddTicks(3340), "Sint dolor eum aut dignissimos." },
                    { 497, 22, 24, 383565, new DateTime(2021, 4, 2, 21, 26, 48, 609, DateTimeKind.Local).AddTicks(5646), "Corporis qui quod voluptatem eos. Distinctio recusandae laudantium aut corrupti soluta aliquam est ad. Dignissimos quas et officia vel sequi nihil vel. Placeat et consectetur reiciendis maxime voluptatem facere. Esse et a aliquid odio omnis alias pariatur dolore numquam. Deserunt sequi ducimus officiis." },
                    { 504, 22, 81, 703467, new DateTime(2020, 10, 1, 1, 19, 54, 792, DateTimeKind.Local).AddTicks(9723), "Et praesentium tempore." },
                    { 110, 60, 36, 138173, new DateTime(2021, 5, 5, 6, 24, 55, 162, DateTimeKind.Local).AddTicks(7769), "Cumque fugiat tempore ut et.\nTempora enim ipsa laborum.\nNostrum quas rem assumenda eos et perferendis fugiat dolorem.\nVoluptates quia odio tempora et explicabo ut cum.\nMinima similique maiores et totam.\nExcepturi repellat quod quis quasi dolores nobis impedit qui." },
                    { 116, 60, 28, 203696, new DateTime(2021, 1, 5, 13, 35, 38, 725, DateTimeKind.Local).AddTicks(2792), "Cupiditate voluptatem quos.\nEum earum sunt voluptatem voluptate incidunt nemo.\nConsectetur quia ipsam facilis repellat voluptas quae voluptatibus et nesciunt.\nRem aut quam modi." },
                    { 118, 60, 21, 239244, new DateTime(2021, 6, 25, 17, 44, 4, 979, DateTimeKind.Local).AddTicks(7504), "Fugiat assumenda facilis deserunt quisquam." },
                    { 143, 60, 45, 264255, new DateTime(2020, 10, 22, 10, 5, 9, 711, DateTimeKind.Local).AddTicks(3585), "Eum aspernatur consequatur commodi totam repudiandae eum magni quisquam aut.\nReiciendis velit nemo expedita.\nPerferendis nemo corporis voluptas molestiae.\nIn consequatur quos ut ullam ut officiis." },
                    { 185, 60, 107, 416540, new DateTime(2020, 10, 5, 17, 16, 26, 57, DateTimeKind.Local).AddTicks(681), "Eos delectus deserunt voluptas quaerat architecto amet unde aut temporibus." },
                    { 400, 22, 70, 937716, new DateTime(2020, 9, 6, 17, 20, 24, 34, DateTimeKind.Local).AddTicks(6253), "Cumque debitis nihil inventore. Magnam et ut sapiente qui numquam saepe. Perferendis eligendi voluptas modi." },
                    { 168, 48, 127, 759223, new DateTime(2021, 4, 19, 20, 8, 35, 10, DateTimeKind.Local).AddTicks(9205), "accusamus" },
                    { 123, 25, 55, 430638, new DateTime(2021, 1, 4, 2, 19, 12, 690, DateTimeKind.Local).AddTicks(6848), "Rerum voluptas quia quia." },
                    { 25, 25, 84, 100228, new DateTime(2021, 5, 1, 8, 53, 8, 884, DateTimeKind.Local).AddTicks(8919), "non" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 68, 5, 31, 113489, new DateTime(2021, 5, 26, 3, 17, 49, 396, DateTimeKind.Local).AddTicks(1609), "fugiat" },
                    { 129, 5, 65, 111980, new DateTime(2020, 12, 23, 11, 31, 33, 58, DateTimeKind.Local).AddTicks(6064), "dolor" },
                    { 439, 5, 119, 170664, new DateTime(2021, 5, 20, 0, 3, 56, 283, DateTimeKind.Local).AddTicks(6427), "esse" },
                    { 546, 5, 93, 167989, new DateTime(2021, 3, 7, 20, 45, 38, 208, DateTimeKind.Local).AddTicks(9494), "beatae" },
                    { 366, 69, 77, 190788, new DateTime(2020, 8, 28, 20, 41, 0, 292, DateTimeKind.Local).AddTicks(1189), "nam" },
                    { 331, 69, 75, 168311, new DateTime(2021, 7, 3, 17, 17, 8, 166, DateTimeKind.Local).AddTicks(9819), "Itaque sapiente quos est ut cumque eius.\nAsperiores possimus corporis autem fugit deserunt.\nNostrum repudiandae quo a quas hic eos.\nLabore ex voluptas.\nQuam voluptate quia et in sunt iure." },
                    { 236, 69, 114, 982367, new DateTime(2021, 8, 21, 7, 33, 48, 424, DateTimeKind.Local).AddTicks(2051), "Et est voluptatem et animi aut commodi sit similique. Quod aut est similique. Id illum aperiam." },
                    { 119, 25, 139, 157817, new DateTime(2021, 8, 14, 4, 13, 42, 367, DateTimeKind.Local).AddTicks(1828), "accusamus" },
                    { 193, 69, 112, 680897, new DateTime(2020, 11, 16, 4, 2, 18, 310, DateTimeKind.Local).AddTicks(7444), "Commodi beatae doloremque ratione aut et quo consequatur aspernatur non." },
                    { 184, 77, 150, 250310, new DateTime(2021, 3, 29, 9, 38, 10, 961, DateTimeKind.Local).AddTicks(1570), "Sunt debitis nostrum et.\nArchitecto tempore aperiam cumque modi aut deserunt sequi sit." },
                    { 248, 77, 65, 995507, new DateTime(2021, 7, 13, 7, 52, 15, 721, DateTimeKind.Local).AddTicks(8759), "Molestiae dolorem voluptatibus provident tempore quod ab. Est ea molestiae delectus. Ut dolor tempora. Reprehenderit libero rem sunt aut itaque rem provident possimus. Inventore eos voluptates et tenetur consequatur voluptas unde cum quaerat." },
                    { 307, 77, 78, 684288, new DateTime(2021, 6, 19, 4, 10, 11, 941, DateTimeKind.Local).AddTicks(6800), "Sit ut nulla et incidunt corporis dolor autem.\nQuidem ut aut optio rem molestiae voluptate." },
                    { 455, 77, 131, 306199, new DateTime(2020, 12, 18, 1, 31, 16, 655, DateTimeKind.Local).AddTicks(4732), "Tempore dolor suscipit animi temporibus quibusdam eius.\nFacilis rerum nam est quae numquam libero est.\nAut unde ducimus tenetur impedit." },
                    { 481, 77, 34, 90942, new DateTime(2020, 12, 8, 10, 11, 25, 453, DateTimeKind.Local).AddTicks(9870), "Sed reprehenderit delectus sint id ut voluptate quaerat et. Laboriosam eum quod aut omnis. Qui unde aliquid nihil voluptatibus. Vero velit illo reprehenderit. Sit illum aliquam doloremque. Doloremque natus tenetur accusantium." },
                    { 169, 69, 42, 304177, new DateTime(2021, 1, 27, 12, 58, 36, 809, DateTimeKind.Local).AddTicks(4387), "Omnis qui exercitationem sint.\nEos illum nam autem velit qui omnis.\nOfficia voluptatem deserunt.\nConsequuntur est sit quod ratione." },
                    { 2, 25, 38, 342471, new DateTime(2021, 2, 11, 3, 51, 42, 743, DateTimeKind.Local).AddTicks(406), "Unde quis quo voluptas in voluptatem et." },
                    { 182, 77, 122, 871214, new DateTime(2020, 10, 1, 11, 11, 3, 492, DateTimeKind.Local).AddTicks(6737), "In vero et occaecati reprehenderit vel laborum est quod voluptatibus." },
                    { 163, 48, 99, 783901, new DateTime(2020, 9, 29, 2, 19, 27, 947, DateTimeKind.Local).AddTicks(2167), "Quis voluptatem corporis accusantium ipsum.\nDebitis ut voluptatem rem.\nEt cupiditate voluptas labore qui delectus amet sit qui voluptas." },
                    { 61, 12, 103, 952267, new DateTime(2021, 5, 8, 10, 9, 29, 374, DateTimeKind.Local).AddTicks(3392), "Est laborum est enim vitae et aut. Quidem qui sit doloremque. Quas dolor doloremque velit." },
                    { 65, 48, 65, 894713, new DateTime(2020, 9, 29, 1, 31, 28, 341, DateTimeKind.Local).AddTicks(1057), "Aut nisi fuga nihil molestiae consectetur quam non quas. Necessitatibus nihil quod eum. Voluptatem illo eius minima repellendus sunt. Quam dolorem eum. Quasi libero id numquam harum debitis rem." },
                    { 159, 33, 12, 894800, new DateTime(2021, 4, 6, 2, 50, 8, 371, DateTimeKind.Local).AddTicks(7785), "Aut dolor ut hic hic quia aut reiciendis." },
                    { 305, 33, 10, 846167, new DateTime(2021, 1, 22, 15, 36, 51, 803, DateTimeKind.Local).AddTicks(2121), "qui" },
                    { 483, 33, 70, 319685, new DateTime(2021, 4, 18, 23, 46, 25, 714, DateTimeKind.Local).AddTicks(3175), "Corrupti ad qui temporibus voluptas vitae impedit maxime." },
                    { 572, 33, 22, 503633, new DateTime(2021, 4, 21, 14, 52, 47, 523, DateTimeKind.Local).AddTicks(3717), "Et nulla et facere nostrum porro animi enim. Enim doloribus dolores eveniet tenetur. Unde id pariatur quia minus eligendi. Laborum pariatur cupiditate recusandae accusantium. Et voluptatem asperiores ipsam facere cupiditate debitis sit. Eveniet perferendis et beatae." },
                    { 401, 20, 84, 597085, new DateTime(2020, 10, 24, 13, 1, 45, 364, DateTimeKind.Local).AddTicks(8102), "Natus ut molestiae laborum nostrum.\nIste et est mollitia quibusdam doloremque placeat cumque.\nUt eos hic maiores necessitatibus recusandae deserunt.\nEt possimus et eligendi sed eos quibusdam soluta veritatis nesciunt.\nDolores fuga quia nemo reiciendis ullam." },
                    { 380, 20, 66, 912965, new DateTime(2020, 10, 11, 5, 51, 4, 85, DateTimeKind.Local).AddTicks(858), "Error qui ipsa veniam ut veniam. Autem totam quidem et quos soluta id praesentium exercitationem. Dolore aut voluptatem qui voluptas vel. Optio eos voluptatem aliquid beatae facilis nobis. Saepe omnis quis aut voluptates quos ducimus tempore est ea. Qui odit et est fugit velit consequatur quibusdam alias eligendi." },
                    { 63, 33, 65, 473510, new DateTime(2021, 8, 7, 17, 13, 41, 322, DateTimeKind.Local).AddTicks(3655), "Dolorem eum voluptatem non dolorum quo. Ipsa aut omnis. Sed quasi optio atque inventore mollitia dolor eos. Cum repellat non." },
                    { 357, 20, 115, 148171, new DateTime(2020, 12, 30, 14, 53, 8, 612, DateTimeKind.Local).AddTicks(4805), "Doloremque officia earum praesentium velit eius et est sint iusto. In et dolore libero perspiciatis distinctio modi nesciunt dolorem consequatur. Aut dolor quasi quis ullam vitae quo nobis nam. Voluptates voluptates quia aut animi laudantium quae rerum officiis itaque. Qui et alias assumenda." },
                    { 78, 38, 113, 885853, new DateTime(2021, 7, 8, 14, 58, 37, 400, DateTimeKind.Local).AddTicks(8352), "Placeat consequatur totam explicabo nihil numquam quod ut ut facilis. Non doloremque voluptate ut libero voluptatem fuga ab est rerum. Rerum sed voluptatum optio ducimus. Cumque est velit nihil." },
                    { 87, 38, 89, 548763, new DateTime(2021, 7, 12, 15, 23, 52, 45, DateTimeKind.Local).AddTicks(6706), "Est autem nesciunt voluptas suscipit ea est sit unde. Blanditiis enim pariatur tempora. Qui hic in expedita eos." },
                    { 138, 38, 14, 43431, new DateTime(2021, 1, 29, 2, 32, 13, 662, DateTimeKind.Local).AddTicks(3214), "Culpa expedita rerum quia qui laboriosam ut ducimus ut. Voluptas libero perspiciatis eum. Quibusdam assumenda error veniam beatae. Facilis molestias dicta aut. Ad enim eos est ea in. Et id doloremque fugit." },
                    { 241, 38, 84, 574435, new DateTime(2020, 9, 14, 14, 20, 33, 712, DateTimeKind.Local).AddTicks(305), "Culpa quia magni.\nVoluptatem officiis officiis est ipsum." },
                    { 245, 38, 120, 164802, new DateTime(2021, 8, 22, 23, 53, 46, 634, DateTimeKind.Local).AddTicks(470), "Illum vitae et quibusdam. Voluptatibus voluptas quaerat. Provident excepturi iure. Possimus consequatur quasi voluptas voluptatibus voluptatibus maxime." },
                    { 274, 38, 46, 831885, new DateTime(2021, 3, 22, 16, 6, 57, 852, DateTimeKind.Local).AddTicks(6542), "Occaecati perspiciatis porro culpa." },
                    { 60, 38, 19, 926982, new DateTime(2020, 11, 21, 10, 31, 29, 730, DateTimeKind.Local).AddTicks(3007), "Mollitia sint nihil omnis.\nQuam labore consequatur autem tenetur et exercitationem consectetur architecto in.\nQui explicabo reiciendis labore sed quis et et.\nFacere dolor quam ut nisi placeat voluptatem sint.\nOfficiis enim temporibus aliquam.\nMinima minus amet qui aut ipsam." },
                    { 42, 33, 27, 220005, new DateTime(2020, 11, 28, 9, 1, 56, 249, DateTimeKind.Local).AddTicks(9055), "maxime" },
                    { 479, 20, 59, 966163, new DateTime(2021, 5, 19, 20, 40, 59, 903, DateTimeKind.Local).AddTicks(7063), "Suscipit aspernatur perspiciatis harum dolorem rem dolorem et dignissimos qui. Sunt maiores earum in quia eos qui quasi. Nobis id unde consectetur non amet." },
                    { 538, 20, 114, 32439, new DateTime(2021, 3, 1, 4, 6, 16, 179, DateTimeKind.Local).AddTicks(190), "ex" },
                    { 389, 29, 71, 761419, new DateTime(2020, 12, 9, 10, 22, 37, 382, DateTimeKind.Local).AddTicks(3251), "Neque libero qui nihil quam est doloremque facere." },
                    { 192, 29, 26, 337179, new DateTime(2021, 2, 7, 22, 39, 12, 640, DateTimeKind.Local).AddTicks(2538), "Et architecto fuga dolor qui." },
                    { 181, 29, 39, 318998, new DateTime(2020, 9, 21, 13, 26, 53, 314, DateTimeKind.Local).AddTicks(8851), "Laboriosam non sunt error sit. Cupiditate quibusdam sunt ea assumenda odit ratione. Sit quos ut sint dolorem repudiandae. Totam maiores minima ratione suscipit quis. Corrupti facilis voluptatum sapiente explicabo et. Consequuntur tempora libero." },
                    { 160, 29, 142, 476832, new DateTime(2021, 1, 9, 9, 23, 2, 473, DateTimeKind.Local).AddTicks(8275), "Nobis mollitia et totam velit quam provident itaque ullam exercitationem." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 154, 50, 57, 210831, new DateTime(2020, 11, 16, 15, 52, 42, 589, DateTimeKind.Local).AddTicks(2384), "Exercitationem officiis quod facere itaque ut perspiciatis ullam.\nImpedit aut tenetur nesciunt.\nId ut ut ab qui aut eum eveniet perspiciatis.\nSit beatae exercitationem qui enim voluptas exercitationem vel aut quam.\nPossimus consequuntur eligendi.\nMagni saepe aut quidem adipisci sunt et." },
                    { 161, 50, 115, 685575, new DateTime(2021, 4, 28, 6, 18, 43, 706, DateTimeKind.Local).AddTicks(7087), "Et qui aut quia et ut enim." },
                    { 412, 50, 52, 242769, new DateTime(2021, 5, 23, 22, 18, 32, 288, DateTimeKind.Local).AddTicks(4673), "deleniti" },
                    { 598, 50, 134, 835702, new DateTime(2021, 5, 6, 19, 43, 50, 588, DateTimeKind.Local).AddTicks(4482), "Perspiciatis repudiandae impedit qui similique." },
                    { 79, 29, 110, 839394, new DateTime(2021, 2, 23, 22, 42, 54, 63, DateTimeKind.Local).AddTicks(6793), "sit" },
                    { 22, 51, 30, 801600, new DateTime(2020, 12, 27, 12, 15, 29, 964, DateTimeKind.Local).AddTicks(8442), "Dolorum laborum vel nobis. Facilis ullam quae nihil voluptatem voluptatibus voluptas maiores sint a. Harum sed vitae." },
                    { 72, 51, 108, 438815, new DateTime(2021, 2, 16, 0, 31, 47, 648, DateTimeKind.Local).AddTicks(9135), "laborum" },
                    { 117, 51, 64, 972318, new DateTime(2021, 5, 30, 2, 57, 54, 98, DateTimeKind.Local).AddTicks(6140), "Ea hic voluptatem quidem occaecati. Ex velit vero. Rerum aperiam omnis et et doloremque dolores ducimus nam praesentium. Consequatur autem sit quo voluptate porro. Illum libero ipsa quas quaerat fugiat sint commodi voluptas ea." },
                    { 243, 51, 89, 979269, new DateTime(2021, 2, 9, 10, 46, 29, 563, DateTimeKind.Local).AddTicks(4243), "Repudiandae et sapiente non id exercitationem repudiandae ab.\nSunt totam enim non praesentium ut.\nQuia itaque quo nobis.\nFugiat quo qui perspiciatis fugit ut." },
                    { 254, 51, 43, 533743, new DateTime(2021, 8, 25, 22, 30, 15, 778, DateTimeKind.Local).AddTicks(8212), "Itaque quis nobis rerum iure quia et repellat nesciunt. Aliquid maiores illo modi sunt voluptatem. Id voluptas eum qui est quos ducimus. Et totam dolor voluptatum qui rerum est. Cum consequatur fugiat qui dolor ab incidunt perferendis voluptatem. Possimus iusto nisi saepe consequuntur dignissimos consequatur vel qui." },
                    { 447, 51, 27, 507775, new DateTime(2021, 7, 10, 14, 16, 56, 541, DateTimeKind.Local).AddTicks(2945), "et" },
                    { 318, 38, 63, 940341, new DateTime(2021, 1, 31, 11, 1, 52, 446, DateTimeKind.Local).AddTicks(6279), "Hic eligendi iste. At reprehenderit reprehenderit tempora veniam odio omnis qui aut. Fugiat vel et exercitationem voluptas nemo cumque ut minus aut. Doloremque dolorem itaque fugit sint consequatur iste ab autem. Minus maxime nihil et qui exercitationem vitae. Est molestias reprehenderit sint autem fuga voluptates aspernatur." },
                    { 397, 38, 50, 92353, new DateTime(2020, 9, 2, 21, 44, 34, 337, DateTimeKind.Local).AddTicks(7831), "Quae atque distinctio. Fugit sunt temporibus repellendus officia accusamus et tenetur. Quae quos maxime. Aspernatur delectus est quae corrupti ut animi quaerat in. Quis debitis dolores odit et iusto voluptatibus eum perspiciatis. Et laborum eveniet sint animi eius." },
                    { 203, 20, 131, 528408, new DateTime(2020, 9, 10, 11, 0, 54, 144, DateTimeKind.Local).AddTicks(9559), "Eos et accusamus suscipit.\nRerum dolorem quae rerum." },
                    { 98, 20, 135, 93063, new DateTime(2021, 3, 22, 21, 49, 26, 843, DateTimeKind.Local).AddTicks(7156), "vel" },
                    { 155, 13, 140, 737050, new DateTime(2021, 7, 14, 7, 45, 18, 797, DateTimeKind.Local).AddTicks(1713), "Maxime dolorem qui sit et sunt vero aut sapiente.\nIpsam velit nostrum.\nQuod quisquam reiciendis qui.\nBlanditiis eligendi numquam quisquam quaerat ut nemo iste ullam.\nReiciendis saepe voluptatem.\nMaiores veritatis mollitia quidem molestiae voluptatem." },
                    { 32, 13, 71, 448040, new DateTime(2021, 7, 2, 5, 25, 52, 722, DateTimeKind.Local).AddTicks(5453), "Fugit tempore enim quisquam in veritatis veritatis." },
                    { 27, 28, 76, 560507, new DateTime(2020, 12, 27, 10, 53, 39, 460, DateTimeKind.Local).AddTicks(2718), "Qui nobis neque qui blanditiis a sed veritatis. Qui amet totam sequi rerum sit nihil. Autem magni iure rem. Voluptates id autem. In consequatur rerum." },
                    { 200, 28, 100, 643897, new DateTime(2020, 10, 14, 15, 5, 59, 466, DateTimeKind.Local).AddTicks(5671), "Hic ipsam commodi. Porro rerum ea itaque voluptates occaecati. Ea eos facilis aperiam est voluptas illum consequatur iure. Quis nihil quo minima inventore rerum dicta. Porro rerum distinctio consectetur quisquam dolor dolorem enim nihil." },
                    { 93, 48, 111, 656683, new DateTime(2021, 5, 16, 18, 32, 16, 557, DateTimeKind.Local).AddTicks(1924), "Accusantium dolores asperiores." },
                    { 269, 28, 50, 976993, new DateTime(2020, 10, 29, 19, 40, 21, 39, DateTimeKind.Local).AddTicks(1564), "Facere ipsum aut et. Et tempora iure ad aperiam aperiam itaque soluta quis. Eaque voluptatem a dolorem delectus at nihil accusamus facere aut. Veritatis recusandae rerum quia repudiandae minima non repellendus dolorem. Velit incidunt sint quis aut. Ut at rerum aspernatur voluptas tempora numquam qui aut voluptatem." },
                    { 332, 28, 90, 63143, new DateTime(2021, 4, 22, 6, 18, 12, 714, DateTimeKind.Local).AddTicks(5091), "Et consequuntur nam sunt deleniti quam sunt." },
                    { 534, 28, 75, 728372, new DateTime(2021, 5, 13, 22, 9, 36, 262, DateTimeKind.Local).AddTicks(9163), "Laudantium eaque sunt. Nulla perspiciatis qui similique velit veniam est. Ipsa ratione sapiente eos dolore qui tenetur sit quod magni. Deleniti labore necessitatibus repellendus voluptas facilis." },
                    { 593, 28, 127, 679077, new DateTime(2021, 8, 21, 2, 58, 46, 307, DateTimeKind.Local).AddTicks(1498), "Distinctio commodi ut minus.\nAsperiores qui a adipisci et totam molestiae aut velit error." },
                    { 4, 31, 28, 419327, new DateTime(2020, 8, 28, 0, 50, 45, 927, DateTimeKind.Local).AddTicks(5290), "Quidem delectus maxime. Dolor possimus necessitatibus quos impedit repudiandae est est odit. Quo et eveniet id sed aperiam dolorem laudantium assumenda. Dolor excepturi tenetur et natus quaerat." },
                    { 90, 31, 108, 713095, new DateTime(2021, 1, 20, 22, 18, 25, 915, DateTimeKind.Local).AddTicks(7360), "Eos quaerat dolorem modi ut aut laborum.\nConsequatur eos a.\nNobis libero quis.\nQuia earum ut sequi non commodi quam consectetur saepe.\nEt natus doloribus." },
                    { 114, 31, 63, 423541, new DateTime(2020, 10, 25, 23, 18, 48, 848, DateTimeKind.Local).AddTicks(9682), "Magni autem quia ut omnis est quasi.\nSed cupiditate magni facilis voluptas assumenda ut.\nHic qui voluptates nemo numquam sed qui ut quidem et.\nDicta et magnam quis blanditiis voluptatem fugit inventore et." },
                    { 323, 31, 9, 87714, new DateTime(2020, 9, 30, 3, 51, 56, 734, DateTimeKind.Local).AddTicks(2703), "Molestiae quas animi aut facilis inventore culpa commodi occaecati.\nMolestias possimus est ipsam provident facilis quisquam fuga voluptatem.\nDolorem natus quae aspernatur." },
                    { 327, 31, 117, 290024, new DateTime(2021, 3, 19, 14, 1, 18, 537, DateTimeKind.Local).AddTicks(623), "Cupiditate accusantium harum eos quasi dolor nam eum.\nMinus dolor inventore voluptas ducimus.\nNon quas dolorem rem autem velit.\nQuo animi consequuntur facere ut voluptas dolor ratione." },
                    { 378, 31, 86, 559404, new DateTime(2021, 7, 29, 7, 17, 47, 61, DateTimeKind.Local).AddTicks(5230), "Quaerat provident qui voluptatem. Ut dolores aut quia est soluta magnam. Quo laboriosam minus temporibus. Quia ea dolor aperiam aliquid quos numquam vero omnis eos. Quam id et sed ut." },
                    { 278, 13, 18, 43000, new DateTime(2020, 10, 7, 8, 8, 35, 156, DateTimeKind.Local).AddTicks(3068), "qui" },
                    { 403, 29, 146, 829429, new DateTime(2021, 1, 2, 4, 30, 13, 475, DateTimeKind.Local).AddTicks(3668), "sint" },
                    { 559, 27, 57, 477508, new DateTime(2021, 7, 13, 8, 12, 22, 251, DateTimeKind.Local).AddTicks(8579), "voluptate" },
                    { 494, 27, 21, 971053, new DateTime(2021, 7, 10, 14, 47, 54, 618, DateTimeKind.Local).AddTicks(4586), "Et quo qui quasi unde.\nEum eos sequi.\nOdio quisquam consequatur qui quod et.\nIpsam porro qui eum quasi nobis assumenda exercitationem ea recusandae.\nEaque nesciunt animi voluptates quaerat consequatur optio harum.\nQuo vero autem." },
                    { 44, 20, 23, 881105, new DateTime(2021, 1, 29, 18, 21, 27, 783, DateTimeKind.Local).AddTicks(2333), "Ratione est reiciendis consequatur quaerat id quia at in est." },
                    { 20, 61, 98, 74311, new DateTime(2021, 6, 24, 9, 28, 58, 306, DateTimeKind.Local).AddTicks(5528), "Quis dolores voluptatem vel. Ea aliquam laborum nihil. Et eaque ut. A quae sunt enim ut rerum dolor consequatur." },
                    { 211, 61, 49, 482421, new DateTime(2021, 3, 1, 2, 20, 57, 400, DateTimeKind.Local).AddTicks(1113), "Libero voluptatibus alias quos laboriosam voluptatem.\nNumquam fugit soluta.\nPorro quia hic fuga voluptas omnis cum aut qui aut.\nQuos quod aut.\nQuaerat assumenda adipisci explicabo animi accusamus." },
                    { 263, 61, 150, 560096, new DateTime(2020, 12, 2, 16, 53, 46, 678, DateTimeKind.Local).AddTicks(920), "Dolor cupiditate natus voluptates ipsum minus." },
                    { 539, 61, 99, 656800, new DateTime(2020, 12, 6, 1, 25, 12, 43, DateTimeKind.Local).AddTicks(1520), "Ut hic perferendis et illum iste aperiam sequi sit." },
                    { 76, 79, 98, 92127, new DateTime(2021, 8, 8, 5, 11, 59, 460, DateTimeKind.Local).AddTicks(6065), "Ut iste aut cumque at.\nIncidunt qui eum.\nRerum velit hic veniam quasi ut reprehenderit nulla.\nNatus nihil minima recusandae." },
                    { 82, 79, 146, 191108, new DateTime(2021, 4, 29, 10, 41, 23, 482, DateTimeKind.Local).AddTicks(4083), "vero" },
                    { 355, 79, 95, 324548, new DateTime(2021, 3, 9, 11, 2, 15, 927, DateTimeKind.Local).AddTicks(4071), "Atque rerum odit optio in consequatur dicta qui." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 415, 79, 24, 174846, new DateTime(2021, 3, 23, 19, 29, 44, 526, DateTimeKind.Local).AddTicks(8107), "eum" },
                    { 456, 13, 62, 942967, new DateTime(2021, 1, 5, 20, 26, 57, 679, DateTimeKind.Local).AddTicks(3532), "quis" },
                    { 346, 13, 105, 318347, new DateTime(2020, 8, 29, 1, 14, 43, 87, DateTimeKind.Local).AddTicks(7625), "Facilis aliquid voluptas nisi natus voluptas veritatis." },
                    { 89, 27, 86, 222800, new DateTime(2020, 12, 24, 5, 37, 9, 528, DateTimeKind.Local).AddTicks(1096), "Ut numquam non minima. Blanditiis ut adipisci facere est quis est a ducimus mollitia. Et amet aperiam non exercitationem." },
                    { 249, 27, 108, 452976, new DateTime(2021, 8, 11, 5, 17, 11, 269, DateTimeKind.Local).AddTicks(7141), "Voluptatum saepe illum cupiditate." },
                    { 353, 27, 94, 928058, new DateTime(2021, 7, 16, 16, 34, 4, 194, DateTimeKind.Local).AddTicks(339), "Dolore quo molestiae amet quo possimus fuga in quis. Eos nisi ipsum deleniti ut cupiditate. Voluptas beatae voluptatem omnis voluptates autem quam. Quia harum est. Ipsum sunt nihil dolor. Dignissimos dolores recusandae saepe qui facere vel sunt tempora consequatur." },
                    { 391, 27, 10, 657171, new DateTime(2021, 7, 12, 5, 34, 23, 204, DateTimeKind.Local).AddTicks(3609), "maiores" },
                    { 545, 27, 117, 939520, new DateTime(2021, 2, 19, 1, 18, 49, 377, DateTimeKind.Local).AddTicks(9008), "neque" },
                    { 522, 81, 58, 38581, new DateTime(2021, 8, 6, 22, 57, 20, 553, DateTimeKind.Local).AddTicks(5536), "enim" },
                    { 499, 81, 119, 240953, new DateTime(2021, 7, 24, 5, 25, 52, 696, DateTimeKind.Local).AddTicks(4360), "Dolore optio ut." },
                    { 452, 81, 143, 58960, new DateTime(2020, 9, 22, 18, 1, 52, 888, DateTimeKind.Local).AddTicks(5030), "molestiae" },
                    { 108, 53, 28, 167737, new DateTime(2021, 2, 14, 0, 22, 49, 230, DateTimeKind.Local).AddTicks(6737), "Molestiae culpa ducimus voluptatem ut." },
                    { 177, 53, 2, 582537, new DateTime(2020, 11, 2, 6, 49, 14, 231, DateTimeKind.Local).AddTicks(5942), "Et eaque et libero facilis similique enim eos voluptates reiciendis." },
                    { 257, 53, 37, 765053, new DateTime(2020, 12, 15, 10, 43, 3, 680, DateTimeKind.Local).AddTicks(5448), "Esse amet sequi eos necessitatibus quia necessitatibus." },
                    { 349, 53, 143, 455842, new DateTime(2020, 12, 16, 10, 45, 55, 77, DateTimeKind.Local).AddTicks(6502), "Corrupti alias nihil quo beatae consequatur qui.\nEarum et officiis est non commodi." },
                    { 407, 53, 8, 215143, new DateTime(2021, 4, 18, 5, 50, 27, 217, DateTimeKind.Local).AddTicks(8587), "Voluptates aut qui excepturi earum consequuntur sunt illum.\nOfficiis asperiores consectetur assumenda.\nIpsam est repudiandae eum ut.\nMaxime fugiat qui inventore." },
                    { 476, 53, 74, 22349, new DateTime(2021, 7, 17, 7, 52, 52, 106, DateTimeKind.Local).AddTicks(1731), "Mollitia voluptatem rerum dolor occaecati sed quia doloribus aspernatur.\nModi nam voluptatem ea distinctio quidem vitae error unde officiis.\nMolestiae nulla vel maxime.\nQui laudantium quam." },
                    { 489, 53, 144, 571738, new DateTime(2020, 11, 2, 0, 6, 45, 345, DateTimeKind.Local).AddTicks(6722), "ea" },
                    { 540, 53, 79, 19504, new DateTime(2021, 3, 26, 17, 55, 13, 535, DateTimeKind.Local).AddTicks(9309), "Expedita tenetur qui ex id et consequuntur enim." },
                    { 316, 24, 118, 210885, new DateTime(2020, 9, 26, 1, 59, 13, 548, DateTimeKind.Local).AddTicks(4719), "Cumque aut fugit. Sit qui quaerat sed. Hic illo repellat. Amet earum iure. Ab excepturi qui fugiat esse tempore suscipit. Repudiandae deleniti nihil corporis voluptatem expedita non est nemo." },
                    { 239, 24, 137, 784553, new DateTime(2021, 1, 29, 16, 58, 35, 404, DateTimeKind.Local).AddTicks(1403), "Nam voluptatum cupiditate non vel officia blanditiis." },
                    { 265, 45, 77, 262273, new DateTime(2020, 10, 31, 5, 11, 4, 919, DateTimeKind.Local).AddTicks(2300), "Esse voluptatem voluptate est nihil ut et." },
                    { 567, 45, 18, 315374, new DateTime(2021, 1, 10, 14, 13, 58, 212, DateTimeKind.Local).AddTicks(9344), "autem" },
                    { 569, 45, 5, 261497, new DateTime(2020, 9, 29, 13, 42, 50, 87, DateTimeKind.Local).AddTicks(3480), "Quod illo optio animi aut libero saepe." },
                    { 189, 24, 83, 168554, new DateTime(2021, 4, 17, 13, 41, 16, 358, DateTimeKind.Local).AddTicks(9170), "Molestias delectus voluptates qui et." },
                    { 145, 24, 103, 18682, new DateTime(2021, 5, 10, 13, 58, 43, 91, DateTimeKind.Local).AddTicks(6397), "aut" },
                    { 41, 53, 110, 972442, new DateTime(2021, 3, 8, 9, 34, 18, 337, DateTimeKind.Local).AddTicks(3354), "excepturi" },
                    { 33, 9, 60, 812054, new DateTime(2021, 2, 5, 19, 4, 22, 551, DateTimeKind.Local).AddTicks(1247), "Id similique consectetur iste ducimus.\nAut pariatur eos tenetur praesentium.\nUt ipsum a quia voluptatibus." },
                    { 26, 53, 48, 394439, new DateTime(2020, 10, 26, 17, 58, 38, 895, DateTimeKind.Local).AddTicks(2327), "non" },
                    { 423, 24, 145, 682109, new DateTime(2021, 7, 13, 13, 55, 26, 491, DateTimeKind.Local).AddTicks(5462), "Reiciendis sed aliquid quidem non quia veniam qui qui." },
                    { 179, 14, 145, 294499, new DateTime(2021, 4, 5, 15, 10, 49, 195, DateTimeKind.Local).AddTicks(4409), "Voluptatem non officiis illo." },
                    { 204, 14, 115, 181076, new DateTime(2021, 2, 23, 0, 5, 48, 26, DateTimeKind.Local).AddTicks(9412), "esse" },
                    { 210, 14, 146, 224208, new DateTime(2021, 2, 26, 13, 42, 56, 615, DateTimeKind.Local).AddTicks(5208), "Vel eos necessitatibus dolor perspiciatis reiciendis non praesentium rerum error." },
                    { 271, 14, 111, 492860, new DateTime(2020, 12, 9, 22, 52, 29, 447, DateTimeKind.Local).AddTicks(9157), "Sed et quo sint odio autem a eos consectetur sit. Consequatur ducimus quo porro et ut est qui tenetur. Quo voluptatem voluptatem nihil non illum." },
                    { 344, 14, 140, 585277, new DateTime(2021, 8, 1, 18, 55, 50, 748, DateTimeKind.Local).AddTicks(3102), "Et tenetur totam facilis aut accusamus eligendi maiores." },
                    { 350, 14, 17, 875749, new DateTime(2021, 8, 4, 18, 8, 15, 444, DateTimeKind.Local).AddTicks(4212), "Veritatis modi facere suscipit quis ad necessitatibus. Soluta quidem occaecati delectus qui tempore corrupti mollitia error. Corrupti magni ipsa unde qui dolores." },
                    { 385, 14, 64, 365714, new DateTime(2021, 8, 1, 11, 23, 47, 43, DateTimeKind.Local).AddTicks(2719), "Culpa eaque enim eos repellat veritatis omnis est reiciendis." },
                    { 517, 14, 76, 965598, new DateTime(2020, 12, 23, 7, 57, 4, 886, DateTimeKind.Local).AddTicks(1369), "Non temporibus et ratione ipsa qui deserunt quae." },
                    { 52, 37, 109, 427928, new DateTime(2021, 6, 11, 6, 35, 1, 521, DateTimeKind.Local).AddTicks(9683), "Exercitationem doloribus consequuntur molestias molestiae optio.\nQuae et nisi perspiciatis dolores officiis esse velit omnis.\nDignissimos error nemo dolor iusto.\nQui iusto magni dicta aut.\nEt quia quas provident similique qui incidunt eaque cupiditate est.\nRepellat numquam quia." },
                    { 152, 37, 83, 695330, new DateTime(2021, 6, 1, 3, 38, 33, 625, DateTimeKind.Local).AddTicks(1398), "omnis" },
                    { 315, 37, 136, 944492, new DateTime(2021, 1, 7, 23, 17, 27, 970, DateTimeKind.Local).AddTicks(6406), "eos" },
                    { 374, 37, 111, 840922, new DateTime(2021, 3, 26, 2, 0, 5, 32, DateTimeKind.Local).AddTicks(6775), "Illo voluptas fuga itaque. Eos molestiae ut fugit libero architecto. Sunt qui et in facere voluptatem optio dolor recusandae sed. Velit expedita ab iusto quas excepturi." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 388, 37, 76, 296027, new DateTime(2020, 12, 8, 14, 1, 12, 6, DateTimeKind.Local).AddTicks(2795), "Ad consequatur minima sit provident dolorem quam nihil dolore aperiam. Qui totam vel quia et nihil illum. Quaerat eveniet magni error exercitationem. Officiis quas aliquid." },
                    { 441, 37, 125, 98869, new DateTime(2021, 7, 3, 2, 55, 32, 370, DateTimeKind.Local).AddTicks(3525), "Unde suscipit sed officiis.\nFacere iure et tempora velit et." },
                    { 577, 37, 73, 72607, new DateTime(2021, 8, 15, 21, 54, 10, 621, DateTimeKind.Local).AddTicks(8306), "dolor" },
                    { 409, 24, 47, 771372, new DateTime(2020, 10, 24, 14, 37, 44, 536, DateTimeKind.Local).AddTicks(147), "Dolore officiis est odit incidunt." },
                    { 402, 31, 101, 521820, new DateTime(2021, 8, 21, 20, 24, 15, 454, DateTimeKind.Local).AddTicks(8974), "distinctio" },
                    { 35, 9, 144, 221152, new DateTime(2021, 2, 1, 18, 30, 54, 766, DateTimeKind.Local).AddTicks(8045), "officiis" },
                    { 132, 9, 85, 247696, new DateTime(2021, 3, 22, 6, 6, 49, 567, DateTimeKind.Local).AddTicks(7278), "Qui qui quasi ut voluptas omnis.\nOfficiis facere quia qui." },
                    { 326, 11, 81, 139299, new DateTime(2021, 5, 27, 9, 0, 3, 931, DateTimeKind.Local).AddTicks(4566), "eligendi" },
                    { 386, 11, 38, 384543, new DateTime(2020, 8, 29, 1, 34, 45, 828, DateTimeKind.Local).AddTicks(3600), "Aliquid aut pariatur perferendis voluptatum." },
                    { 521, 29, 150, 218948, new DateTime(2021, 2, 28, 11, 9, 25, 867, DateTimeKind.Local).AddTicks(3159), "Eum id porro dolor sint ducimus et id ut.\nDistinctio blanditiis dicta et recusandae quia.\nIllum error ut eius quas harum.\nUt beatae dolores dolorem repudiandae labore nam.\nDebitis ea autem sunt vel.\nConsequatur voluptatum esse sequi minus dolor." },
                    { 97, 59, 148, 454045, new DateTime(2021, 4, 6, 3, 6, 33, 325, DateTimeKind.Local).AddTicks(1889), "Praesentium in doloribus explicabo officiis labore sapiente animi error." },
                    { 297, 59, 120, 182797, new DateTime(2020, 9, 27, 9, 2, 42, 756, DateTimeKind.Local).AddTicks(8178), "Et laboriosam quia ut eaque ratione fugiat. Facere quis quam consequatur. At qui ad dolor mollitia repellendus porro quia aliquid." },
                    { 395, 59, 71, 304369, new DateTime(2021, 7, 14, 16, 45, 26, 759, DateTimeKind.Local).AddTicks(5320), "Nisi quaerat iusto reprehenderit explicabo officiis accusantium." },
                    { 458, 59, 102, 686937, new DateTime(2021, 3, 13, 5, 25, 32, 251, DateTimeKind.Local).AddTicks(4004), "Autem sint maiores. Ullam velit ipsa eum tenetur modi atque consectetur saepe. Sapiente corrupti doloremque distinctio sint officia non. Cumque est aliquam. Ut id debitis illum dignissimos dolor. In nesciunt temporibus nihil unde rerum libero dolorem." },
                    { 502, 59, 54, 398680, new DateTime(2020, 11, 23, 16, 3, 54, 246, DateTimeKind.Local).AddTicks(7451), "Est ut consectetur.\nError perspiciatis accusantium consequatur eligendi illum dolorem.\nEt hic minima sed vel." },
                    { 501, 29, 140, 382697, new DateTime(2020, 9, 2, 19, 33, 31, 677, DateTimeKind.Local).AddTicks(1639), "Non aliquam sunt commodi blanditiis libero labore aut. Quae voluptas sint adipisci tempore voluptas repudiandae et. Fugit magni aut dolorem. Qui quia at." },
                    { 411, 29, 24, 863924, new DateTime(2021, 6, 9, 21, 17, 36, 371, DateTimeKind.Local).AddTicks(938), "Earum modi accusantium beatae optio labore quia doloremque dolor nulla." },
                    { 85, 81, 130, 898629, new DateTime(2020, 9, 4, 22, 6, 47, 875, DateTimeKind.Local).AddTicks(3469), "Soluta nisi quia et rerum sit aperiam animi tempora molestiae." },
                    { 127, 81, 26, 284827, new DateTime(2021, 8, 17, 3, 10, 17, 995, DateTimeKind.Local).AddTicks(18), "Omnis omnis voluptatem harum dolorum." },
                    { 128, 81, 8, 124077, new DateTime(2020, 10, 5, 1, 10, 18, 609, DateTimeKind.Local).AddTicks(7046), "Pariatur quia qui molestiae illum placeat dolore quis est.\nPorro deserunt ipsum error impedit ut adipisci incidunt.\nNon corporis omnis et eum aut.\nCorporis molestiae dolores in vel facere non architecto beatae quia." },
                    { 151, 81, 88, 136396, new DateTime(2021, 4, 14, 17, 23, 12, 853, DateTimeKind.Local).AddTicks(2995), "beatae" },
                    { 280, 81, 5, 892447, new DateTime(2020, 10, 19, 18, 15, 44, 747, DateTimeKind.Local).AddTicks(6071), "Consequatur reprehenderit qui maiores iste quia voluptatibus.\nNon non consectetur deleniti illo.\nId iure aut ut.\nVoluptas qui vel saepe voluptatum non." },
                    { 321, 11, 38, 346392, new DateTime(2021, 2, 7, 18, 0, 45, 341, DateTimeKind.Local).AddTicks(3254), "Molestiae fugiat ut nesciunt nihil veritatis occaecati maxime tempore.\nTempore suscipit adipisci et possimus.\nQuos quis ratione quis quia unde consectetur.\nCulpa laboriosam perspiciatis est.\nRepudiandae quidem ex aut." },
                    { 62, 9, 51, 988773, new DateTime(2020, 10, 1, 15, 33, 13, 953, DateTimeKind.Local).AddTicks(7068), "Natus et corrupti reiciendis eum.\nExercitationem in ipsam neque praesentium.\nVoluptatum error amet aut ducimus velit rerum voluptates dolorem optio.\nConsequatur voluptatibus eveniet voluptatem qui asperiores rerum." },
                    { 268, 11, 34, 857382, new DateTime(2021, 7, 1, 9, 26, 51, 894, DateTimeKind.Local).AddTicks(5508), "mollitia" },
                    { 527, 29, 90, 322992, new DateTime(2021, 7, 12, 21, 34, 5, 66, DateTimeKind.Local).AddTicks(9051), "Voluptatibus ea quibusdam deserunt suscipit.\nQuo dolor tempora ab ratione et rerum dolore quas inventore.\nVoluptatum at est consectetur enim accusamus repudiandae culpa quos.\nMollitia perferendis magni cum.\nQuis adipisci laboriosam quia voluptatem et." },
                    { 293, 9, 26, 52667, new DateTime(2021, 8, 27, 19, 35, 31, 891, DateTimeKind.Local).AddTicks(6306), "Repudiandae commodi voluptas ratione dolor voluptatum suscipit.\nDolorem autem eum quis omnis deserunt nemo.\nDolores sit quis omnis ab.\nEt vel incidunt.\nImpedit omnis qui est iste libero voluptas soluta." },
                    { 299, 9, 126, 467684, new DateTime(2021, 5, 26, 17, 49, 9, 620, DateTimeKind.Local).AddTicks(8772), "Nobis sed unde non nam fugit iure ducimus. Nihil doloribus illum et fuga et qui. Harum vero alias maxime inventore itaque magnam. Sit dolores accusantium velit quia sit." },
                    { 390, 9, 22, 8431, new DateTime(2020, 12, 9, 8, 48, 14, 751, DateTimeKind.Local).AddTicks(2076), "Perferendis dicta assumenda ipsum." },
                    { 449, 9, 149, 417917, new DateTime(2021, 5, 4, 5, 8, 14, 576, DateTimeKind.Local).AddTicks(7966), "non" },
                    { 596, 9, 65, 77198, new DateTime(2020, 12, 18, 13, 18, 45, 309, DateTimeKind.Local).AddTicks(3208), "Sapiente quod unde dolorem id." },
                    { 585, 55, 50, 988632, new DateTime(2020, 11, 19, 8, 24, 48, 90, DateTimeKind.Local).AddTicks(6381), "omnis" },
                    { 292, 55, 93, 886168, new DateTime(2021, 5, 16, 17, 40, 5, 29, DateTimeKind.Local).AddTicks(9857), "et" },
                    { 266, 55, 134, 845704, new DateTime(2021, 5, 15, 17, 32, 7, 847, DateTimeKind.Local).AddTicks(9936), "illo" },
                    { 13, 43, 54, 311667, new DateTime(2021, 7, 4, 12, 42, 8, 99, DateTimeKind.Local).AddTicks(8848), "Quod voluptatem sed ad.\nQuo delectus incidunt nulla sit.\nNumquam accusamus doloribus dolore omnis mollitia.\nA necessitatibus molestiae saepe eveniet.\nDolor fugiat non et.\nRatione dolorem incidunt dolores doloremque magni." },
                    { 141, 43, 33, 426891, new DateTime(2021, 1, 7, 19, 54, 51, 745, DateTimeKind.Local).AddTicks(9281), "Et et excepturi asperiores laborum nobis. Optio delectus aliquam tempora. Saepe impedit sit ut minus ut neque officia suscipit. Ullam sed laboriosam voluptatem tempore nulla qui quia dolorem." },
                    { 227, 43, 4, 240962, new DateTime(2021, 4, 25, 20, 13, 13, 74, DateTimeKind.Local).AddTicks(1680), "Voluptas illo vero alias iure unde doloribus dolor. Excepturi et nisi id ea numquam quas ut velit nostrum. Voluptate cupiditate incidunt ut. Ut qui quo neque. Praesentium consequatur quo quo. Nobis dolor dolore nulla consequatur." },
                    { 367, 43, 50, 196104, new DateTime(2021, 8, 17, 10, 27, 30, 227, DateTimeKind.Local).AddTicks(1735), "Est fuga aut iusto quia dolor autem sit adipisci error.\nEveniet sequi rem deleniti eos neque vero.\nSunt eum fuga pariatur accusantium dolorem libero sint exercitationem dolorem.\nInventore quisquam quae ea eligendi omnis non non vitae ducimus.\nDeleniti porro soluta deserunt deleniti." },
                    { 587, 29, 85, 31764, new DateTime(2021, 4, 26, 18, 30, 35, 404, DateTimeKind.Local).AddTicks(2594), "Sint nostrum facilis ad officiis laborum fuga qui molestiae odio.\nExercitationem molestiae voluptates reiciendis mollitia." },
                    { 571, 29, 114, 752648, new DateTime(2020, 10, 20, 3, 45, 31, 457, DateTimeKind.Local).AddTicks(3195), "Cum nam vel nihil dolores recusandae ut voluptatum." },
                    { 552, 29, 122, 956467, new DateTime(2021, 2, 16, 14, 55, 18, 816, DateTimeKind.Local).AddTicks(5531), "Aspernatur consequuntur sed assumenda possimus nihil voluptatem in." },
                    { 18, 11, 120, 532586, new DateTime(2021, 1, 3, 2, 28, 38, 693, DateTimeKind.Local).AddTicks(3085), "nam" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 532, 31, 112, 144009, new DateTime(2021, 2, 16, 20, 37, 38, 930, DateTimeKind.Local).AddTicks(9534), "Quia et nostrum numquam rem et qui nihil et." },
                    { 260, 28, 24, 579031, new DateTime(2020, 9, 21, 16, 54, 46, 542, DateTimeKind.Local).AddTicks(7229), "Sed dolore quia reiciendis." },
                    { 453, 46, 110, 273386, new DateTime(2021, 3, 10, 2, 16, 16, 128, DateTimeKind.Local).AddTicks(6434), "Et quaerat consequatur sunt dicta rerum.\nVelit ea et quidem veritatis impedit eum amet porro." },
                    { 80, 73, 46, 69176, new DateTime(2020, 11, 5, 7, 22, 36, 339, DateTimeKind.Local).AddTicks(6544), "Dolorem asperiores aperiam dicta.\nAutem dolore autem facilis architecto iure eos.\nEt est assumenda animi sed quia dignissimos corrupti reprehenderit qui.\nEius et beatae sed non quaerat sequi soluta nemo in.\nNihil esse inventore quia enim tenetur et quos." },
                    { 144, 73, 55, 237383, new DateTime(2021, 4, 3, 21, 56, 54, 37, DateTimeKind.Local).AddTicks(7753), "Et saepe nemo autem deleniti nostrum eligendi repudiandae dolorum." },
                    { 149, 73, 149, 406249, new DateTime(2020, 10, 15, 9, 46, 25, 683, DateTimeKind.Local).AddTicks(3605), "quos" },
                    { 196, 73, 101, 737979, new DateTime(2021, 5, 7, 6, 36, 6, 663, DateTimeKind.Local).AddTicks(9448), "Ea rem voluptatibus aspernatur reiciendis aspernatur illo ipsam minima. Voluptatem fugiat quae. Sed incidunt saepe ea est eligendi dolor. Omnis nulla eveniet corporis ad cumque aut itaque." },
                    { 201, 73, 98, 577952, new DateTime(2021, 4, 4, 10, 50, 30, 979, DateTimeKind.Local).AddTicks(553), "Voluptatum velit repudiandae provident in sunt unde sit eaque et." },
                    { 287, 73, 134, 265262, new DateTime(2021, 8, 7, 19, 14, 24, 814, DateTimeKind.Local).AddTicks(9009), "Sapiente repellat omnis nemo rerum neque eos est quis. Sunt sint est temporibus. Pariatur inventore soluta animi molestiae et mollitia." },
                    { 317, 73, 130, 720857, new DateTime(2021, 3, 13, 20, 25, 15, 221, DateTimeKind.Local).AddTicks(1195), "ut" },
                    { 9, 73, 49, 904743, new DateTime(2021, 6, 30, 17, 16, 19, 37, DateTimeKind.Local).AddTicks(7589), "Et voluptatem nam hic optio asperiores maxime. Aliquid omnis nemo quo et eligendi nemo enim dignissimos. Consequuntur ad et et maiores. Consequatur voluptatum dolorum et assumenda." },
                    { 537, 73, 71, 543017, new DateTime(2021, 3, 2, 9, 7, 5, 381, DateTimeKind.Local).AddTicks(1817), "Suscipit rerum laborum nostrum tenetur. Delectus et quia omnis iusto voluptate minus similique error. Dolorem quia labore aliquid voluptatem consectetur quis aut cum dolorem." },
                    { 583, 73, 42, 310353, new DateTime(2021, 1, 26, 13, 1, 10, 378, DateTimeKind.Local).AddTicks(8395), "Maxime rem et rem explicabo quasi repudiandae." },
                    { 589, 73, 44, 578514, new DateTime(2021, 6, 27, 16, 48, 21, 614, DateTimeKind.Local).AddTicks(4567), "Qui et magni fuga necessitatibus facere itaque itaque tempore. Minus fugiat et corporis neque consectetur consequatur. Enim laborum sunt voluptas ipsa asperiores dolores autem dolores impedit. Voluptate nisi tempore voluptatibus consectetur autem debitis iste accusantium sint. Voluptas ut doloremque delectus rem nihil deserunt est." },
                    { 49, 32, 19, 895600, new DateTime(2020, 12, 13, 3, 56, 38, 759, DateTimeKind.Local).AddTicks(836), "possimus" },
                    { 54, 32, 66, 89080, new DateTime(2021, 7, 23, 21, 43, 36, 390, DateTimeKind.Local).AddTicks(9449), "Nihil consequatur et praesentium enim ex unde rem." },
                    { 64, 32, 83, 321889, new DateTime(2020, 11, 3, 10, 34, 24, 690, DateTimeKind.Local).AddTicks(6489), "Quibusdam dolores vel id laudantium fuga." },
                    { 166, 32, 41, 296845, new DateTime(2021, 8, 4, 0, 33, 8, 82, DateTimeKind.Local).AddTicks(9409), "Quia commodi ipsam fugit commodi sed molestiae autem labore. Consequatur est sint earum eos delectus exercitationem nemo. Quia in est ut debitis. Rerum deleniti doloremque eveniet. Recusandae omnis sapiente velit consequatur maxime ipsa." },
                    { 199, 32, 150, 178666, new DateTime(2021, 1, 16, 12, 57, 20, 231, DateTimeKind.Local).AddTicks(749), "Magni quia eligendi quo doloremque explicabo. Quia optio non aut earum molestias qui qui qui. Quidem odit qui deserunt maxime animi. Esse ipsam vel omnis quia." },
                    { 574, 73, 122, 688636, new DateTime(2021, 4, 19, 15, 41, 59, 354, DateTimeKind.Local).AddTicks(8920), "incidunt" },
                    { 104, 39, 103, 495481, new DateTime(2021, 1, 26, 10, 15, 55, 2, DateTimeKind.Local).AddTicks(7271), "Eligendi eius optio excepturi aut animi veniam et repellendus veritatis. Doloribus qui fuga doloremque. Quam eveniet modi omnis fugiat ad voluptatem nesciunt sint quo. Omnis recusandae debitis aut. Perferendis asperiores nulla provident sint maiores atque. Voluptatem voluptas ut et autem nisi tempore consequatur minus." },
                    { 133, 39, 35, 489033, new DateTime(2020, 11, 29, 17, 57, 10, 457, DateTimeKind.Local).AddTicks(4820), "Iusto qui dolor et praesentium vitae architecto.\nSuscipit eum iure ad explicabo assumenda consequatur.\nId deleniti est impedit at porro commodi.\nEt fugit deserunt corrupti sed quo.\nEst delectus qui tempora.\nImpedit quisquam asperiores maiores nesciunt qui dignissimos." },
                    { 591, 63, 121, 71660, new DateTime(2020, 10, 20, 15, 51, 28, 97, DateTimeKind.Local).AddTicks(7136), "Tempora exercitationem architecto occaecati et. Voluptate ut enim sint. Asperiores nulla saepe. Repellat quam provident qui sit aspernatur ullam assumenda. Velit pariatur consequuntur numquam aut rerum unde voluptatem quae." },
                    { 387, 39, 149, 705197, new DateTime(2021, 4, 25, 23, 25, 53, 909, DateTimeKind.Local).AddTicks(3117), "Est repellendus impedit beatae sunt ea ratione. Repellendus non eligendi nihil assumenda. Quos et nam iusto voluptatum tempore. Tenetur sint qui dolor sapiente quibusdam at velit voluptates voluptatem." },
                    { 102, 16, 128, 952717, new DateTime(2021, 4, 30, 1, 4, 53, 934, DateTimeKind.Local).AddTicks(8241), "dicta" },
                    { 120, 16, 131, 378737, new DateTime(2021, 3, 25, 15, 18, 32, 890, DateTimeKind.Local).AddTicks(4882), "ex" },
                    { 202, 16, 30, 319655, new DateTime(2021, 8, 27, 18, 44, 37, 945, DateTimeKind.Local).AddTicks(8796), "expedita" },
                    { 213, 16, 123, 831286, new DateTime(2021, 6, 24, 23, 50, 28, 584, DateTimeKind.Local).AddTicks(6373), "Exercitationem perspiciatis consequatur id similique corrupti voluptatem. Necessitatibus alias minima sit sit beatae voluptatem. Eligendi quia corporis debitis. Quia incidunt rerum. Libero adipisci aut eos. Facilis necessitatibus ullam atque nemo voluptas corrupti debitis." },
                    { 525, 46, 114, 914741, new DateTime(2021, 7, 26, 21, 33, 43, 512, DateTimeKind.Local).AddTicks(3155), "itaque" },
                    { 294, 39, 75, 651225, new DateTime(2021, 1, 16, 2, 53, 17, 334, DateTimeKind.Local).AddTicks(3285), "Odio iure sit voluptatem est quis voluptatum aut officia ut. Quis dolores sint officiis impedit excepturi. Et voluptas in magni quia labore porro ipsa beatae officia. Velit ut labore ut facilis." },
                    { 273, 39, 22, 20601, new DateTime(2021, 8, 15, 19, 30, 20, 302, DateTimeKind.Local).AddTicks(5767), "dolorem" },
                    { 156, 39, 6, 280597, new DateTime(2020, 11, 15, 15, 1, 57, 735, DateTimeKind.Local).AddTicks(4317), "voluptatem" },
                    { 95, 63, 82, 333282, new DateTime(2021, 4, 13, 17, 51, 28, 342, DateTimeKind.Local).AddTicks(8187), "Sit nihil magni quae.\nRecusandae voluptatem possimus.\nInventore perferendis nisi id et.\nMolestiae quia inventore iste ut ipsam voluptas modi nobis." },
                    { 194, 63, 143, 547003, new DateTime(2020, 9, 8, 18, 46, 39, 551, DateTimeKind.Local).AddTicks(5540), "et" },
                    { 212, 63, 93, 741089, new DateTime(2021, 1, 6, 19, 18, 8, 379, DateTimeKind.Local).AddTicks(4352), "Rem officiis voluptas similique et ullam." },
                    { 286, 63, 106, 119817, new DateTime(2020, 9, 3, 19, 42, 45, 529, DateTimeKind.Local).AddTicks(2814), "Nihil sed officiis." },
                    { 359, 63, 81, 336954, new DateTime(2021, 1, 11, 12, 2, 41, 470, DateTimeKind.Local).AddTicks(9022), "Et voluptas pariatur fugiat assumenda asperiores nam asperiores quia iste. Adipisci dolor non nostrum quasi expedita eum error et occaecati. Recusandae deserunt sint excepturi ipsum blanditiis eaque molestiae. Quo architecto dolores accusantium aperiam dicta ut a." },
                    { 376, 63, 108, 92637, new DateTime(2021, 4, 26, 9, 49, 4, 212, DateTimeKind.Local).AddTicks(9284), "et" },
                    { 392, 63, 21, 770077, new DateTime(2020, 10, 15, 21, 36, 23, 74, DateTimeKind.Local).AddTicks(6826), "Alias nisi et est expedita modi alias.\nCulpa tempora qui esse et rerum.\nEt exercitationem suscipit harum cupiditate quis temporibus.\nSimilique sit quam velit in voluptas.\nDelectus quae voluptas sit ut.\nRerum natus ea." },
                    { 394, 63, 85, 668391, new DateTime(2021, 5, 6, 14, 31, 11, 662, DateTimeKind.Local).AddTicks(7138), "Et nostrum facere." },
                    { 229, 32, 105, 555013, new DateTime(2020, 10, 17, 3, 14, 19, 420, DateTimeKind.Local).AddTicks(617), "Perferendis corrupti veritatis dolorem consequatur corporis neque perferendis molestias dicta." },
                    { 444, 39, 95, 537735, new DateTime(2021, 2, 7, 16, 26, 31, 897, DateTimeKind.Local).AddTicks(6489), "Error aut iure nostrum dolor occaecati hic debitis." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 377, 32, 104, 424279, new DateTime(2020, 12, 13, 10, 37, 1, 723, DateTimeKind.Local).AddTicks(5147), "Dicta natus veniam itaque repudiandae non veniam commodi." },
                    { 435, 32, 96, 521705, new DateTime(2021, 1, 6, 13, 22, 37, 16, DateTimeKind.Local).AddTicks(9659), "Qui vel unde qui ad.\nAliquid non alias distinctio eos aut quis repellendus fugiat.\nConsectetur tenetur neque culpa cumque voluptas.\nQuos iste qui inventore neque quo beatae excepturi et.\nUt aut earum voluptas voluptatem officia consequatur magnam.\nDeleniti suscipit aliquid in placeat rerum dolorem quisquam nostrum." },
                    { 219, 10, 97, 209165, new DateTime(2021, 6, 6, 22, 36, 28, 269, DateTimeKind.Local).AddTicks(6364), "soluta" },
                    { 124, 3, 66, 207420, new DateTime(2020, 10, 10, 11, 39, 45, 556, DateTimeKind.Local).AddTicks(367), "sapiente" },
                    { 237, 3, 145, 873693, new DateTime(2021, 2, 16, 8, 26, 33, 905, DateTimeKind.Local).AddTicks(6458), "Molestiae laudantium eaque qui. Expedita eius ex quo voluptatibus nam doloremque aperiam placeat odit. Dolorum earum et ex sed dolorem veniam maiores labore optio." },
                    { 384, 3, 147, 561487, new DateTime(2020, 10, 14, 15, 20, 6, 232, DateTimeKind.Local).AddTicks(5813), "Sed voluptatem harum id et rerum aspernatur voluptatem ut." },
                    { 475, 3, 135, 813292, new DateTime(2021, 1, 15, 23, 53, 1, 935, DateTimeKind.Local).AddTicks(7529), "ut" },
                    { 125, 10, 66, 41395, new DateTime(2021, 6, 15, 14, 41, 50, 949, DateTimeKind.Local).AddTicks(1823), "et" },
                    { 81, 10, 113, 323886, new DateTime(2020, 9, 11, 22, 36, 36, 550, DateTimeKind.Local).AddTicks(8030), "Placeat adipisci ex.\nEt iusto pariatur vitae.\nVoluptatem ullam magni qui iure et impedit omnis provident.\nVoluptatem ex perspiciatis velit ab quos vero eveniet suscipit debitis.\nConsequuntur molestias laboriosam eos molestias." },
                    { 283, 10, 93, 402332, new DateTime(2021, 8, 18, 2, 14, 6, 588, DateTimeKind.Local).AddTicks(3385), "Quod quibusdam odit repudiandae. Tempora nostrum eum quasi harum quis et magnam. Numquam ut aut in laudantium consequatur ratione dolorum." },
                    { 55, 10, 10, 792176, new DateTime(2021, 5, 2, 22, 18, 53, 540, DateTimeKind.Local).AddTicks(5709), "Beatae sed est.\nHarum sunt debitis." },
                    { 29, 54, 104, 291089, new DateTime(2020, 9, 17, 5, 35, 11, 714, DateTimeKind.Local).AddTicks(709), "dicta" },
                    { 34, 54, 60, 608686, new DateTime(2021, 4, 17, 7, 47, 24, 128, DateTimeKind.Local).AddTicks(740), "Ut repellendus minus laudantium velit ducimus.\nConsectetur expedita molestiae sint expedita quo et.\nVoluptatem impedit voluptatem consequatur ipsam quaerat et eum saepe velit.\nQuia repudiandae et aut.\nEt soluta impedit quia distinctio cupiditate nisi odio velit autem.\nTempore nemo et corporis dolores." },
                    { 259, 54, 29, 27780, new DateTime(2021, 1, 9, 16, 2, 18, 285, DateTimeKind.Local).AddTicks(7821), "et" },
                    { 427, 54, 12, 236398, new DateTime(2020, 10, 13, 1, 32, 11, 760, DateTimeKind.Local).AddTicks(7162), "Autem aut dolor corporis et sint. Explicabo sit illo laborum. Officia quam quasi provident porro rerum modi. Sapiente id sed aut optio et et qui nisi. Laborum soluta quo libero iure. Ut nesciunt reprehenderit molestiae velit animi voluptatem id." },
                    { 208, 72, 53, 460051, new DateTime(2021, 1, 7, 18, 15, 30, 568, DateTimeKind.Local).AddTicks(8184), "In aut porro possimus qui facere. Modi sed velit sint tempora recusandae ea. Molestiae molestiae consequatur." },
                    { 180, 72, 104, 304627, new DateTime(2020, 12, 6, 23, 58, 5, 469, DateTimeKind.Local).AddTicks(4491), "doloribus" },
                    { 113, 72, 56, 404825, new DateTime(2021, 3, 5, 5, 8, 45, 268, DateTimeKind.Local).AddTicks(7577), "Debitis qui veniam." },
                    { 553, 72, 133, 108174, new DateTime(2021, 5, 17, 2, 13, 16, 676, DateTimeKind.Local).AddTicks(8946), "Culpa quam nihil alias corrupti incidunt temporibus voluptatibus nesciunt laudantium." },
                    { 300, 10, 50, 298237, new DateTime(2021, 1, 22, 10, 25, 26, 958, DateTimeKind.Local).AddTicks(9399), "Asperiores ducimus esse officia tempora aperiam doloremque.\nVoluptatem libero aperiam magni fuga ut quasi aliquam earum fuga." },
                    { 310, 10, 121, 876284, new DateTime(2021, 7, 3, 4, 33, 44, 151, DateTimeKind.Local).AddTicks(8147), "Non et sit. Inventore est amet ea totam et. Quidem veniam ut natus veritatis et eos. Et amet deleniti et amet sit." },
                    { 313, 10, 72, 559878, new DateTime(2020, 12, 10, 9, 7, 52, 124, DateTimeKind.Local).AddTicks(6261), "dolore" },
                    { 597, 32, 26, 22247, new DateTime(2021, 7, 16, 2, 0, 52, 478, DateTimeKind.Local).AddTicks(8231), "ex" },
                    { 96, 39, 41, 312162, new DateTime(2021, 5, 14, 20, 45, 42, 131, DateTimeKind.Local).AddTicks(7527), "voluptatem" },
                    { 523, 10, 147, 115272, new DateTime(2021, 1, 29, 18, 46, 54, 793, DateTimeKind.Local).AddTicks(9347), "Aut debitis quo tenetur quidem dolorem ullam qui corporis culpa.\nInventore ea enim recusandae consequatur sunt consequuntur et.\nPariatur quia nobis est quas veritatis rerum sit fuga.\nQuos voluptas quos id impedit.\nIpsum cupiditate dolor voluptas iusto sapiente consectetur.\nCum itaque quod sapiente consequuntur incidunt ut quaerat." },
                    { 30, 68, 128, 893625, new DateTime(2021, 3, 27, 15, 52, 46, 397, DateTimeKind.Local).AddTicks(5630), "Eum qui ad ab omnis iste aliquid sit iste enim." },
                    { 66, 68, 141, 955128, new DateTime(2021, 8, 24, 8, 18, 59, 820, DateTimeKind.Local).AddTicks(3436), "Quo ut nostrum reiciendis. Enim quisquam autem ea inventore sit voluptas nihil est adipisci. Molestiae et voluptatem. Sed placeat adipisci nostrum cupiditate." },
                    { 91, 68, 88, 849563, new DateTime(2021, 3, 28, 23, 57, 58, 30, DateTimeKind.Local).AddTicks(469), "Dolores iste et." },
                    { 107, 68, 45, 776639, new DateTime(2021, 2, 16, 5, 5, 55, 528, DateTimeKind.Local).AddTicks(361), "Eum doloribus explicabo qui possimus laboriosam ea. Aspernatur commodi non qui ut dolorum. Et quaerat eaque. Esse quia ipsum qui ut totam totam rerum." },
                    { 131, 68, 145, 292166, new DateTime(2020, 11, 11, 23, 10, 15, 307, DateTimeKind.Local).AddTicks(1755), "Iusto ipsa et ducimus illum." },
                    { 136, 68, 37, 663424, new DateTime(2021, 2, 23, 16, 55, 22, 379, DateTimeKind.Local).AddTicks(9419), "iste" },
                    { 171, 68, 31, 361792, new DateTime(2020, 9, 9, 8, 8, 30, 475, DateTimeKind.Local).AddTicks(3813), "totam" },
                    { 314, 68, 116, 812851, new DateTime(2020, 9, 11, 9, 56, 59, 873, DateTimeKind.Local).AddTicks(8872), "Quia in consequatur eaque et porro quo." },
                    { 371, 68, 90, 625216, new DateTime(2021, 2, 14, 17, 3, 43, 115, DateTimeKind.Local).AddTicks(3467), "neque" },
                    { 469, 68, 83, 435223, new DateTime(2021, 1, 5, 10, 57, 4, 142, DateTimeKind.Local).AddTicks(1975), "Qui facere esse deserunt quo ut odit et quia." },
                    { 514, 68, 98, 694572, new DateTime(2021, 3, 21, 16, 54, 28, 844, DateTimeKind.Local).AddTicks(7369), "Voluptatem soluta dolor non doloribus sed. Non iste assumenda quia cum. Nostrum ab nostrum aut temporibus. Ut eum ea aut. Aut quia error ipsam et eum. Nam consequatur qui earum impedit." },
                    { 565, 68, 88, 971848, new DateTime(2020, 9, 22, 12, 10, 47, 755, DateTimeKind.Local).AddTicks(7532), "Totam ab laborum.\nDolorem ipsum praesentium animi earum eum.\nIpsam rerum excepturi alias nam ut nisi laboriosam rem voluptatem.\nMollitia quo eligendi eius aut." },
                    { 575, 68, 38, 709131, new DateTime(2021, 3, 27, 3, 22, 31, 548, DateTimeKind.Local).AddTicks(7034), "Tempore maxime autem beatae in." },
                    { 347, 10, 83, 40792, new DateTime(2021, 1, 17, 5, 8, 52, 631, DateTimeKind.Local).AddTicks(8873), "consequatur" },
                    { 408, 32, 113, 196298, new DateTime(2020, 10, 29, 20, 22, 32, 130, DateTimeKind.Local).AddTicks(3018), "Pariatur maiores unde et aut rerum labore consequatur officia." },
                    { 520, 39, 129, 390823, new DateTime(2021, 8, 14, 13, 10, 10, 443, DateTimeKind.Local).AddTicks(3913), "Ut est culpa occaecati et sed corporis impedit sint. Quibusdam voluptatem omnis dolor non quaerat et molestiae numquam necessitatibus. Ut sequi cum dignissimos molestiae." },
                    { 358, 16, 73, 874432, new DateTime(2021, 3, 14, 22, 15, 14, 544, DateTimeKind.Local).AddTicks(5418), "quibusdam" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 301, 23, 75, 992779, new DateTime(2020, 10, 29, 15, 10, 2, 59, DateTimeKind.Local).AddTicks(6707), "Ducimus ea id.\nDolores repellendus aut sed voluptatibus.\nVoluptate qui sequi fugiat et eius qui enim." },
                    { 592, 23, 17, 529737, new DateTime(2020, 9, 24, 10, 13, 0, 108, DateTimeKind.Local).AddTicks(1742), "Non est id placeat sed et aut sunt dolor quis.\nConsequatur voluptatem et amet." },
                    { 121, 46, 106, 712449, new DateTime(2020, 9, 16, 22, 49, 53, 273, DateTimeKind.Local).AddTicks(6949), "omnis" },
                    { 510, 42, 104, 930981, new DateTime(2020, 9, 23, 0, 43, 1, 275, DateTimeKind.Local).AddTicks(5490), "fuga" },
                    { 285, 46, 110, 186451, new DateTime(2021, 2, 21, 15, 39, 46, 170, DateTimeKind.Local).AddTicks(1235), "Vel culpa in assumenda ut quisquam." },
                    { 342, 42, 46, 588507, new DateTime(2020, 12, 22, 19, 32, 2, 258, DateTimeKind.Local).AddTicks(4090), "Velit sapiente iure enim.\nEnim voluptatum sequi laborum neque.\nModi accusamus deleniti rerum excepturi explicabo autem distinctio ducimus.\nLaboriosam rerum rerum ex.\nCorrupti ex modi quasi accusantium aut exercitationem ratione." },
                    { 330, 42, 9, 628498, new DateTime(2021, 1, 1, 19, 24, 17, 938, DateTimeKind.Local).AddTicks(7205), "earum" },
                    { 235, 42, 85, 843843, new DateTime(2021, 7, 21, 1, 56, 4, 404, DateTimeKind.Local).AddTicks(8204), "Eveniet ipsam qui nam esse eius aut. Est nulla iusto ab ad. Eius et tenetur molestias ipsa. Esse rem pariatur." },
                    { 198, 42, 37, 375580, new DateTime(2021, 1, 24, 18, 28, 22, 280, DateTimeKind.Local).AddTicks(3879), "Doloremque animi eos distinctio nulla totam suscipit debitis. Eaque consequatur omnis consequuntur nihil sit in dolore. Numquam facilis sequi reprehenderit dolores omnis quasi aut accusamus. Laudantium aliquid tempora." },
                    { 105, 42, 149, 349993, new DateTime(2021, 4, 7, 23, 27, 3, 898, DateTimeKind.Local).AddTicks(8961), "Quam a sed asperiores." },
                    { 67, 42, 61, 441365, new DateTime(2020, 10, 25, 9, 41, 9, 2, DateTimeKind.Local).AddTicks(2932), "Quod eaque hic doloremque temporibus. Ut architecto rerum minima nemo cum. Corporis quia optio porro officiis distinctio et ducimus sequi consequuntur. Ut alias qui. Ex necessitatibus eos quos modi quae officia nam qui dolorem. Atque eveniet dolore odio." },
                    { 140, 46, 56, 881383, new DateTime(2020, 11, 7, 18, 25, 48, 431, DateTimeKind.Local).AddTicks(9629), "Ducimus placeat est aut qui recusandae voluptatem iste. Nesciunt et et enim. Vel ut cupiditate maxime est ad nobis. Occaecati qui maiores sit. Sit dolorem aut repellat voluptatum exercitationem corrupti. Laborum molestiae voluptatem quasi." },
                    { 261, 46, 43, 83141, new DateTime(2020, 11, 2, 9, 12, 44, 604, DateTimeKind.Local).AddTicks(2063), "eum" },
                    { 38, 44, 66, 227761, new DateTime(2021, 1, 11, 3, 1, 39, 629, DateTimeKind.Local).AddTicks(2994), "Tenetur voluptatem eaque doloremque nemo voluptatum." },
                    { 214, 44, 5, 277431, new DateTime(2021, 2, 23, 1, 12, 24, 575, DateTimeKind.Local).AddTicks(8902), "Unde velit eius et sint vitae voluptate.\nVoluptatem corrupti dicta enim sed consequatur eveniet.\nNesciunt totam numquam ex iure.\nProvident est eligendi id vel aperiam rem nobis.\nFuga ex quia est aliquam.\nAtque fuga mollitia labore ipsam minima asperiores eius perferendis quis." },
                    { 247, 44, 72, 549899, new DateTime(2021, 1, 9, 6, 1, 13, 485, DateTimeKind.Local).AddTicks(1843), "Totam voluptatum veritatis. Hic odit molestiae vel nostrum. Laboriosam incidunt est est dignissimos. Voluptas quasi voluptas voluptatum voluptas labore expedita libero. Voluptatum provident illum debitis qui repellendus qui enim." },
                    { 432, 44, 78, 154640, new DateTime(2020, 9, 14, 20, 5, 31, 999, DateTimeKind.Local).AddTicks(3422), "Vel dicta nostrum eaque pariatur sed dolorem.\nDeleniti ducimus ipsam tenetur dolores occaecati et temporibus velit sed.\nEt esse asperiores quaerat fugit ut.\nPossimus dolor doloribus.\nQuo sequi delectus in esse excepturi ratione odit." },
                    { 146, 46, 2, 7134, new DateTime(2021, 7, 30, 0, 13, 43, 660, DateTimeKind.Local).AddTicks(4088), "Repellat accusamus ut laborum molestiae quaerat officiis ut.\nSoluta necessitatibus quos velit praesentium nihil.\nQui unde id soluta dolor ut aliquam laboriosam itaque qui.\nUnde dolore odio et placeat accusantium perspiciatis eveniet iusto.\nAccusamus consequatur iusto eaque." },
                    { 500, 34, 89, 726871, new DateTime(2020, 10, 8, 12, 3, 53, 906, DateTimeKind.Local).AddTicks(4498), "Nostrum dolores id vero blanditiis est.\nDicta inventore voluptatem esse beatae omnis rerum.\nSint culpa adipisci consequatur.\nCum commodi et excepturi quos alias.\nUt architecto laboriosam eius sunt natus ex ad dignissimos animi.\nAlias optio dolore nihil sed non est dolorem ratione tenetur." },
                    { 253, 34, 29, 686488, new DateTime(2021, 8, 21, 13, 20, 54, 502, DateTimeKind.Local).AddTicks(4211), "Quia iusto ea.\nVoluptatem molestiae eius temporibus voluptas hic aliquid." },
                    { 542, 44, 93, 811786, new DateTime(2021, 7, 3, 12, 34, 38, 731, DateTimeKind.Local).AddTicks(774), "Nostrum laboriosam illum quis minus aut occaecati quos voluptas rerum." },
                    { 209, 34, 46, 890731, new DateTime(2021, 6, 6, 6, 34, 49, 109, DateTimeKind.Local).AddTicks(809), "Enim fugiat id dicta ipsam harum. Magnam ea rerum et ea. Repellendus rem corrupti labore et qui rerum rem enim nisi. Dolorem ut quam voluptatem sunt sint." },
                    { 582, 44, 37, 493057, new DateTime(2021, 1, 13, 1, 26, 18, 631, DateTimeKind.Local).AddTicks(3404), "qui" },
                    { 233, 46, 99, 415685, new DateTime(2021, 5, 11, 16, 42, 39, 745, DateTimeKind.Local).AddTicks(2018), "Quas repellat maiores aliquid pariatur magnam." },
                    { 206, 46, 105, 995582, new DateTime(2020, 11, 1, 22, 53, 58, 217, DateTimeKind.Local).AddTicks(205), "Non placeat placeat accusamus qui repudiandae sed sit optio. Non rem amet. Id molestiae a alias aut occaecati vero. Aliquid ipsum maiores accusamus sequi voluptatum. Ratione fugiat consequatur inventore enim minima aut. Rerum beatae nobis excepturi modi eaque laudantium." },
                    { 173, 46, 149, 613243, new DateTime(2021, 4, 5, 19, 34, 36, 922, DateTimeKind.Local).AddTicks(1757), "Dolorem ad quisquam delectus quaerat." },
                    { 157, 46, 134, 13471, new DateTime(2021, 2, 5, 2, 7, 5, 446, DateTimeKind.Local).AddTicks(7000), "Ut cum ea dolores non odit eos maiores." },
                    { 150, 46, 92, 916545, new DateTime(2021, 8, 2, 21, 40, 30, 37, DateTimeKind.Local).AddTicks(1204), "Occaecati hic non rem eius." },
                    { 560, 23, 24, 88259, new DateTime(2021, 2, 1, 18, 19, 20, 775, DateTimeKind.Local).AddTicks(9431), "Laudantium recusandae sed mollitia alias.\nUt deleniti sit beatae aut saepe et totam perspiciatis.\nOmnis qui enim consequatur voluptatem sit omnis tempora quae harum.\nIste animi quam aut dolorem itaque quisquam voluptatem ipsa eos.\nLaboriosam laboriosam minima minus sed dolorem.\nHic reprehenderit earum culpa deleniti omnis facilis ex." },
                    { 24, 34, 57, 874074, new DateTime(2021, 1, 31, 21, 40, 57, 284, DateTimeKind.Local).AddTicks(3961), "Voluptas explicabo accusamus ad corrupti.\nVoluptas aperiam error ad et repellendus molestias.\nRepellat quam aut ut recusandae eius.\nFacilis aperiam enim debitis ullam.\nQuia qui eum." },
                    { 176, 34, 16, 168535, new DateTime(2021, 5, 26, 3, 2, 7, 896, DateTimeKind.Local).AddTicks(9162), "Tempore velit nesciunt repudiandae consequatur quia accusamus qui." },
                    { 19, 23, 50, 91633, new DateTime(2021, 5, 27, 0, 29, 5, 67, DateTimeKind.Local).AddTicks(483), "Enim molestiae quo quae cumque aut quisquam non voluptatem." },
                    { 6, 23, 93, 855269, new DateTime(2021, 4, 26, 19, 23, 45, 502, DateTimeKind.Local).AddTicks(7716), "Tenetur adipisci consequatur sed et ad minus. Omnis earum sapiente nam quis iure. Nihil hic amet delectus. Voluptas sit cum incidunt voluptas aut excepturi." },
                    { 244, 40, 1, 121459, new DateTime(2020, 10, 19, 4, 56, 18, 924, DateTimeKind.Local).AddTicks(593), "Sint exercitationem rerum eum iure dolores in." },
                    { 158, 40, 75, 532936, new DateTime(2020, 10, 21, 2, 36, 6, 731, DateTimeKind.Local).AddTicks(7532), "Aut corporis dicta qui vitae omnis debitis est porro sed. Quidem itaque error accusantium beatae. Deserunt aliquid expedita facilis aperiam." },
                    { 101, 40, 94, 914491, new DateTime(2021, 2, 27, 17, 52, 27, 756, DateTimeKind.Local).AddTicks(5700), "omnis" },
                    { 535, 39, 85, 109158, new DateTime(2020, 9, 19, 0, 45, 37, 472, DateTimeKind.Local).AddTicks(2397), "In et vitae amet quo reiciendis nihil." },
                    { 555, 39, 99, 132713, new DateTime(2021, 2, 1, 4, 3, 32, 184, DateTimeKind.Local).AddTicks(4195), "Dolorem perferendis et quis.\nEa animi qui sapiente quia dolore non." },
                    { 162, 23, 45, 186988, new DateTime(2021, 4, 16, 16, 36, 30, 501, DateTimeKind.Local).AddTicks(6167), "nobis" },
                    { 232, 23, 123, 699109, new DateTime(2021, 7, 12, 11, 4, 33, 4, DateTimeKind.Local).AddTicks(7257), "Libero assumenda ut distinctio et est earum consequuntur labore laborum." },
                    { 328, 46, 146, 20142, new DateTime(2021, 4, 18, 15, 37, 16, 177, DateTimeKind.Local).AddTicks(3727), "Dolorem ducimus nulla est repellendus corrupti enim quasi sit reprehenderit. Omnis non fuga quis. Optio voluptatum vel consectetur aperiam. Voluptatem excepturi laboriosam quia modi nostrum quos cum. Totam unde consequatur. Porro fuga amet esse modi cupiditate provident autem." },
                    { 425, 40, 115, 789318, new DateTime(2021, 4, 26, 1, 9, 47, 163, DateTimeKind.Local).AddTicks(8560), "Expedita architecto et deserunt praesentium atque.\nDebitis et sed praesentium.\nProvident beatae voluptas facere nobis praesentium.\nUt expedita optio." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 461, 35, 26, 495816, new DateTime(2021, 3, 4, 1, 57, 46, 391, DateTimeKind.Local).AddTicks(5727), "Vero recusandae iusto hic eos omnis nemo." },
                    { 375, 35, 111, 812237, new DateTime(2020, 12, 23, 11, 35, 15, 506, DateTimeKind.Local).AddTicks(9933), "Ea molestiae qui sint error." },
                    { 356, 35, 58, 791668, new DateTime(2020, 11, 3, 10, 6, 5, 786, DateTimeKind.Local).AddTicks(709), "Est sapiente sed saepe et aut quae molestiae provident.\nSequi cumque ut molestiae et dolorem quibusdam fuga optio.\nCulpa culpa tempore et." },
                    { 433, 46, 115, 199844, new DateTime(2021, 2, 21, 21, 53, 32, 787, DateTimeKind.Local).AddTicks(3745), "officia" },
                    { 437, 40, 83, 60504, new DateTime(2021, 8, 23, 2, 25, 16, 60, DateTimeKind.Local).AddTicks(6140), "Exercitationem ut repellendus quis dolores." },
                    { 550, 40, 7, 527122, new DateTime(2021, 8, 9, 9, 22, 33, 133, DateTimeKind.Local).AddTicks(2972), "Reiciendis est unde magni assumenda et vero.\nNihil qui fugiat debitis in suscipit non ut.\nOmnis ea dolores aut non beatae inventore sunt officia voluptas.\nAutem inventore rerum vel voluptatem deleniti non.\nAssumenda voluptatem inventore quia aspernatur in ut minus dolore quibusdam.\nPlaceat nesciunt quis inventore voluptatem ratione commodi dolores." },
                    { 354, 35, 123, 161740, new DateTime(2021, 7, 18, 17, 53, 56, 708, DateTimeKind.Local).AddTicks(6571), "Sunt vero sint tempora suscipit suscipit molestias. Molestias quia eveniet. Sed nemo porro natus. Aperiam voluptate deserunt et. Quia facilis laudantium nobis quis corporis sit debitis aut pariatur. Officia sint error eos cumque." },
                    { 59, 35, 103, 689142, new DateTime(2020, 12, 14, 23, 42, 45, 607, DateTimeKind.Local).AddTicks(2459), "Aut omnis aut possimus ut veritatis sed sed." },
                    { 3, 35, 53, 786486, new DateTime(2020, 9, 11, 9, 20, 4, 378, DateTimeKind.Local).AddTicks(6182), "Harum dolores eius quia et ut. Voluptas non dolorem ut est aliquid dolor at labore. Ut voluptatum laudantium omnis excepturi aut. Quo sequi eos cum magnam sunt." },
                    { 557, 40, 124, 134173, new DateTime(2021, 3, 18, 19, 28, 40, 228, DateTimeKind.Local).AddTicks(235), "Voluptates qui dicta.\nCorporis et impedit quae esse et odio necessitatibus voluptatem.\nHic dolorem et ex.\nIste qui ut culpa sit quis possimus assumenda incidunt commodi.\nEst voluptas corrupti rerum voluptatem sed." },
                    { 429, 35, 111, 942254, new DateTime(2021, 5, 12, 11, 42, 59, 420, DateTimeKind.Local).AddTicks(1000), "Ut autem placeat quisquam odio non.\nSint doloremque quam harum iste magnam autem aliquid ea.\nEum ut praesentium qui in aspernatur.\nAut ea aut expedita modi.\nNam tempora iste consequatur neque et pariatur animi." },
                    { 434, 40, 90, 150421, new DateTime(2021, 8, 27, 18, 46, 31, 873, DateTimeKind.Local).AddTicks(2438), "Ipsa sequi illum explicabo qui eum dolor.\nConsequatur omnis maiores non at minus neque doloribus natus.\nOmnis facilis nemo.\nVoluptatem iure ut et libero.\nEt deleniti asperiores quos autem aperiam tempore." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 163, new DateTime(2020, 10, 20, 4, 12, 5, 356, DateTimeKind.Local).AddTicks(4533), 24, 73, new DateTime(2022, 5, 31, 21, 47, 31, 777, DateTimeKind.Local).AddTicks(7965), new DateTime(2020, 12, 14, 13, 45, 5, 757, DateTimeKind.Local).AddTicks(8000), 1, null, null, "Eius non inventore adipisci reiciendis voluptates.\nQuisquam voluptatum delectus ut cumque qui perspiciatis sed.\nEst blanditiis recusandae autem impedit cumque nam.", 203 },
                    { 89, new DateTime(2020, 9, 3, 20, 39, 17, 778, DateTimeKind.Local).AddTicks(7160), 49, 37, new DateTime(2022, 4, 28, 8, 44, 6, 914, DateTimeKind.Local).AddTicks(7297), new DateTime(2021, 7, 23, 11, 53, 3, 699, DateTimeKind.Local).AddTicks(8728), 3, null, null, "Rerum laborum reiciendis consequatur.\nMaxime inventore minus non possimus voluptatem ipsum laborum velit.\nDistinctio quibusdam molestiae facilis aperiam qui est atque fuga.\nSuscipit officia sed qui omnis qui velit rerum.\nEa et voluptates cum sint quidem.\nDoloremque facilis repudiandae iure.", 167 },
                    { 185, new DateTime(2021, 7, 21, 22, 42, 23, 223, DateTimeKind.Local).AddTicks(5351), 46, 73, new DateTime(2021, 8, 30, 15, 32, 7, 420, DateTimeKind.Local).AddTicks(2822), new DateTime(2021, 5, 6, 22, 29, 58, 232, DateTimeKind.Local).AddTicks(8890), 5, null, null, "Enim cupiditate et asperiores est animi qui nisi. Cupiditate ut corrupti quia nostrum magnam natus veritatis ut iusto. Id blanditiis delectus. Quia dicta ratione cumque iure repellat. Est quia rem velit voluptatem in nesciunt. Officia perferendis cum et animi.", 202 },
                    { 59, new DateTime(2021, 5, 8, 22, 31, 17, 855, DateTimeKind.Local).AddTicks(9998), 24, 129, new DateTime(2022, 6, 6, 1, 33, 3, 233, DateTimeKind.Local).AddTicks(9526), new DateTime(2021, 6, 21, 16, 22, 58, 639, DateTimeKind.Local).AddTicks(1866), 4, null, null, "Suscipit ea at sunt aperiam nobis sed beatae.\nDolores possimus nihil veniam molestiae velit et non omnis iste.\nIn culpa autem itaque commodi et rerum vel.", 183 },
                    { 129, new DateTime(2020, 10, 9, 12, 0, 56, 390, DateTimeKind.Local).AddTicks(4010), 46, 46, new DateTime(2022, 8, 23, 5, 16, 20, 938, DateTimeKind.Local).AddTicks(6408), new DateTime(2020, 10, 15, 14, 50, 4, 142, DateTimeKind.Local).AddTicks(3668), 5, null, null, "Accusantium quae quisquam dolorem.", 179 },
                    { 71, new DateTime(2021, 6, 11, 16, 52, 59, 494, DateTimeKind.Local).AddTicks(2817), 76, 118, new DateTime(2021, 11, 10, 10, 39, 52, 584, DateTimeKind.Local).AddTicks(1599), new DateTime(2021, 7, 19, 12, 32, 44, 378, DateTimeKind.Local).AddTicks(7730), 1, null, null, "Earum cumque perferendis nobis dignissimos.\nEos aut officia et sit voluptatibus.", 117 },
                    { 159, new DateTime(2020, 9, 21, 1, 52, 28, 147, DateTimeKind.Local).AddTicks(2130), 24, 63, new DateTime(2021, 9, 2, 9, 55, 44, 614, DateTimeKind.Local).AddTicks(6954), new DateTime(2020, 10, 11, 12, 20, 28, 883, DateTimeKind.Local).AddTicks(1042), 1, null, null, "Quibusdam corporis sed voluptatem sed molestiae pariatur sed molestias. Aliquam earum possimus ipsam magni laborum voluptas dolorem ut. Assumenda similique fugit ad modi. Neque est repellendus facere omnis. Corrupti et voluptates. Et sed veniam et.", 269 },
                    { 68, new DateTime(2021, 4, 25, 22, 56, 55, 649, DateTimeKind.Local).AddTicks(9321), 24, 115, new DateTime(2022, 2, 14, 16, 57, 1, 84, DateTimeKind.Local).AddTicks(6978), new DateTime(2021, 6, 20, 12, 54, 29, 448, DateTimeKind.Local).AddTicks(7926), 3, null, null, "consequuntur", 145 },
                    { 127, new DateTime(2021, 8, 2, 0, 32, 20, 41, DateTimeKind.Local).AddTicks(7777), 6, 27, new DateTime(2022, 2, 6, 14, 28, 57, 451, DateTimeKind.Local).AddTicks(8489), new DateTime(2020, 10, 27, 22, 5, 54, 35, DateTimeKind.Local).AddTicks(3582), 5, null, null, "Illo maiores nemo dicta ullam voluptates eveniet aliquid.\nDolores consectetur nam alias delectus.\nDolorem voluptas velit omnis reiciendis.\nEos a voluptatem consequatur voluptatum.\nDoloremque consequatur sapiente.\nHarum repellendus laboriosam beatae sunt placeat voluptas.", 156 },
                    { 151, new DateTime(2020, 9, 21, 9, 53, 53, 110, DateTimeKind.Local).AddTicks(8424), 46, 36, new DateTime(2022, 7, 10, 17, 28, 39, 813, DateTimeKind.Local).AddTicks(6288), new DateTime(2020, 8, 29, 3, 1, 9, 479, DateTimeKind.Local).AddTicks(7532), 5, null, null, "Numquam quidem occaecati temporibus nemo omnis et.", 154 },
                    { 95, new DateTime(2021, 7, 31, 22, 28, 29, 498, DateTimeKind.Local).AddTicks(4237), 20, 48, new DateTime(2022, 7, 7, 2, 12, 39, 488, DateTimeKind.Local).AddTicks(6466), new DateTime(2021, 2, 10, 3, 8, 0, 958, DateTimeKind.Local).AddTicks(179), 1, null, null, "Enim asperiores illum.\nInventore dolores ad consectetur dolores facilis non sint occaecati.\nDoloremque consectetur sunt dicta.\nIn dolorem omnis maxime et incidunt fugit.\nSed quae autem dicta.\nSunt qui nulla.", 122 },
                    { 61, new DateTime(2020, 9, 15, 7, 37, 28, 782, DateTimeKind.Local).AddTicks(1957), 56, 28, new DateTime(2022, 8, 16, 20, 41, 59, 858, DateTimeKind.Local).AddTicks(4280), new DateTime(2021, 5, 16, 0, 50, 20, 562, DateTimeKind.Local).AddTicks(6043), 5, null, null, "dolore", 221 },
                    { 12, new DateTime(2021, 4, 3, 1, 52, 47, 847, DateTimeKind.Local).AddTicks(6287), 13, 142, new DateTime(2021, 11, 21, 2, 41, 59, 784, DateTimeKind.Local).AddTicks(5896), new DateTime(2021, 8, 6, 13, 28, 54, 911, DateTimeKind.Local).AddTicks(9909), 5, null, null, "Amet rem totam non esse incidunt laboriosam minus minus.\nIn nihil quidem.\nRepudiandae unde ea est voluptatem.\nOccaecati beatae assumenda laudantium.\nIpsa cupiditate labore iste eos et ut placeat.\nEx maiores eos.", 292 },
                    { 150, new DateTime(2021, 2, 25, 13, 23, 42, 729, DateTimeKind.Local).AddTicks(5705), 57, 144, new DateTime(2022, 8, 22, 17, 45, 57, 753, DateTimeKind.Local).AddTicks(6286), new DateTime(2021, 2, 1, 12, 6, 8, 335, DateTimeKind.Local).AddTicks(7056), 5, null, null, "Omnis non quas voluptates velit sunt dolorem et praesentium.\nId quos eum ab.", 78 },
                    { 117, new DateTime(2021, 6, 23, 6, 54, 7, 711, DateTimeKind.Local).AddTicks(5035), 4, 113, new DateTime(2022, 6, 26, 2, 19, 53, 129, DateTimeKind.Local).AddTicks(139), new DateTime(2021, 8, 14, 17, 55, 17, 456, DateTimeKind.Local).AddTicks(5628), 2, null, null, "Voluptatem vitae esse non nemo nisi.\nQuisquam beatae sit laboriosam et aut ipsa officiis.\nRerum iste ut aut vero in inventore praesentium.\nCorporis exercitationem expedita porro rerum dolorum qui.\nEst suscipit non voluptas sit.", 260 },
                    { 143, new DateTime(2020, 10, 28, 15, 30, 27, 845, DateTimeKind.Local).AddTicks(584), 4, 146, new DateTime(2022, 6, 29, 8, 54, 21, 969, DateTimeKind.Local).AddTicks(6132), new DateTime(2021, 3, 16, 21, 42, 13, 799, DateTimeKind.Local).AddTicks(8018), 3, null, null, "Aspernatur veniam consequatur voluptate sit et qui sunt tempore. Molestias quaerat nostrum exercitationem sed repellat quis. Adipisci qui voluptatem unde placeat. Ipsum excepturi ut aut qui labore ex beatae.", 83 },
                    { 25, new DateTime(2021, 5, 8, 10, 10, 59, 674, DateTimeKind.Local).AddTicks(1522), 20, 26, new DateTime(2021, 11, 29, 2, 37, 48, 424, DateTimeKind.Local).AddTicks(1245), new DateTime(2020, 11, 2, 18, 3, 53, 703, DateTimeKind.Local).AddTicks(6895), 2, null, null, "Aut et fugiat. Officiis a sed distinctio quisquam vero exercitationem. Officia laudantium vel. In modi accusamus magni optio. Maiores est corporis tempore vero ipsa laudantium est illo animi. Nihil dolorum saepe porro.", 133 },
                    { 72, new DateTime(2021, 5, 9, 12, 21, 43, 868, DateTimeKind.Local).AddTicks(5959), 57, 75, new DateTime(2021, 11, 18, 23, 16, 57, 344, DateTimeKind.Local).AddTicks(5377), new DateTime(2021, 3, 5, 15, 12, 42, 386, DateTimeKind.Local).AddTicks(854), 3, null, null, "Nulla expedita magni officia sed.\nQuae ea nisi tempora aut assumenda aut est iste voluptates.\nVoluptatem velit unde dolores illo consequatur quis possimus culpa.\nAut aut dolores soluta qui dignissimos.\nVero ea omnis vero quis eos molestiae.\nNesciunt temporibus accusamus dignissimos.", 24 },
                    { 10, new DateTime(2021, 1, 18, 15, 34, 12, 82, DateTimeKind.Local).AddTicks(7994), 57, 70, new DateTime(2022, 2, 16, 22, 10, 46, 834, DateTimeKind.Local).AddTicks(7401), new DateTime(2021, 4, 28, 9, 45, 26, 174, DateTimeKind.Local).AddTicks(1670), 5, null, null, "Tenetur ut sunt est et ut blanditiis.", 79 },
                    { 113, new DateTime(2020, 11, 27, 0, 36, 58, 391, DateTimeKind.Local).AddTicks(3902), 39, 18, new DateTime(2021, 10, 29, 8, 51, 19, 732, DateTimeKind.Local).AddTicks(5550), new DateTime(2020, 12, 8, 14, 11, 22, 760, DateTimeKind.Local).AddTicks(1686), 3, null, null, "Velit alias sint hic modi aut aut qui.\nQuia recusandae aliquid in voluptatem doloremque aspernatur libero odit explicabo.\nOptio et quod autem consequatur et voluptatem.", 221 },
                    { 7, new DateTime(2020, 12, 2, 13, 12, 6, 556, DateTimeKind.Local).AddTicks(2172), 57, 4, new DateTime(2022, 1, 10, 7, 15, 12, 651, DateTimeKind.Local).AddTicks(7214), new DateTime(2021, 8, 27, 1, 59, 54, 173, DateTimeKind.Local).AddTicks(4370), 4, null, null, "Quibusdam ex nulla iusto debitis quam corporis eaque.\nNihil molestias aut.\nFugit magni sed quam ipsum.\nEos magnam nihil dolor quas est et.", 268 },
                    { 29, new DateTime(2020, 11, 11, 11, 0, 49, 922, DateTimeKind.Local).AddTicks(4047), 69, 3, new DateTime(2022, 2, 26, 22, 43, 9, 725, DateTimeKind.Local).AddTicks(8853), new DateTime(2021, 5, 1, 17, 46, 38, 325, DateTimeKind.Local).AddTicks(3746), 1, null, null, "Facilis dicta occaecati at omnis aut.", 77 },
                    { 102, new DateTime(2021, 8, 10, 2, 50, 58, 916, DateTimeKind.Local).AddTicks(1353), 69, 47, new DateTime(2021, 10, 7, 12, 46, 46, 756, DateTimeKind.Local).AddTicks(4155), new DateTime(2021, 5, 20, 6, 0, 45, 943, DateTimeKind.Local).AddTicks(4557), 4, null, null, "cupiditate", 278 },
                    { 181, new DateTime(2020, 9, 18, 18, 58, 3, 576, DateTimeKind.Local).AddTicks(2741), 69, 111, new DateTime(2021, 10, 3, 20, 45, 37, 578, DateTimeKind.Local).AddTicks(875), new DateTime(2021, 8, 4, 14, 49, 53, 754, DateTimeKind.Local).AddTicks(7998), 5, null, null, "Aliquam fugiat id quia sint. Enim officia omnis. Excepturi cupiditate in vitae ex omnis explicabo et repellendus. Ratione magnam ipsum. Non accusantium architecto quaerat delectus.", 75 },
                    { 116, new DateTime(2020, 9, 10, 1, 33, 27, 338, DateTimeKind.Local).AddTicks(3313), 39, 16, new DateTime(2022, 8, 4, 20, 42, 4, 899, DateTimeKind.Local).AddTicks(1349), new DateTime(2020, 9, 29, 5, 18, 14, 481, DateTimeKind.Local).AddTicks(7206), 1, null, null, "rerum", 146 },
                    { 178, new DateTime(2021, 7, 11, 23, 15, 52, 341, DateTimeKind.Local).AddTicks(1017), 39, 143, new DateTime(2022, 6, 5, 9, 41, 52, 922, DateTimeKind.Local).AddTicks(7723), new DateTime(2021, 6, 4, 9, 22, 43, 885, DateTimeKind.Local).AddTicks(2283), 3, null, null, "Error ex cumque. Accusantium et sint odit consequatur qui molestiae necessitatibus corporis. Impedit quia ut nobis omnis amet. Accusantium ratione molestiae in illum unde id autem asperiores. Dolor sit eaque quidem dolorem natus et aliquid quas aliquid. Ut harum dolorem.", 256 },
                    { 87, new DateTime(2020, 12, 5, 8, 22, 49, 254, DateTimeKind.Local).AddTicks(4514), 4, 81, new DateTime(2021, 11, 24, 14, 40, 22, 572, DateTimeKind.Local).AddTicks(8318), new DateTime(2021, 1, 6, 0, 35, 38, 24, DateTimeKind.Local).AddTicks(5079), 4, null, null, "ut", 261 },
                    { 75, new DateTime(2020, 9, 9, 19, 31, 0, 48, DateTimeKind.Local).AddTicks(9691), 58, 10, new DateTime(2022, 1, 14, 7, 51, 14, 529, DateTimeKind.Local).AddTicks(7928), new DateTime(2021, 7, 24, 16, 43, 12, 102, DateTimeKind.Local).AddTicks(9320), 1, null, null, "Delectus dolor laborum quae maiores.", 150 },
                    { 177, new DateTime(2021, 8, 21, 23, 27, 1, 151, DateTimeKind.Local).AddTicks(8784), 58, 99, new DateTime(2021, 11, 23, 5, 56, 58, 909, DateTimeKind.Local).AddTicks(4721), new DateTime(2021, 2, 14, 6, 11, 1, 87, DateTimeKind.Local).AddTicks(7236), 2, null, null, "facere", 66 },
                    { 194, new DateTime(2021, 8, 12, 14, 32, 13, 128, DateTimeKind.Local).AddTicks(2096), 69, 70, new DateTime(2022, 6, 11, 18, 41, 37, 593, DateTimeKind.Local).AddTicks(9845), new DateTime(2021, 8, 5, 4, 32, 39, 858, DateTimeKind.Local).AddTicks(5808), 4, null, null, "Qui nisi dolor amet vero non nemo aut. Placeat doloribus ea dolor nihil delectus nobis animi. Ullam provident consequatur qui corporis assumenda fuga culpa accusantium eum. Nobis quis pariatur exercitationem est vel. Dolores libero dolorem deleniti ratione ratione aut.", 150 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 77, new DateTime(2021, 6, 2, 19, 47, 55, 380, DateTimeKind.Local).AddTicks(4003), 13, 32, new DateTime(2021, 10, 26, 2, 48, 46, 562, DateTimeKind.Local).AddTicks(3015), new DateTime(2021, 2, 23, 9, 37, 51, 244, DateTimeKind.Local).AddTicks(7100), 5, null, null, "Sunt repellat et laboriosam repellendus soluta occaecati.\nVoluptatem aut ut dolores eos et hic doloribus autem rerum.\nEius voluptatem architecto.", 91 },
                    { 93, new DateTime(2020, 12, 1, 1, 40, 40, 548, DateTimeKind.Local).AddTicks(5272), 13, 60, new DateTime(2022, 4, 10, 22, 26, 45, 457, DateTimeKind.Local).AddTicks(4607), new DateTime(2021, 1, 3, 22, 2, 14, 636, DateTimeKind.Local).AddTicks(3880), 1, null, null, "Praesentium voluptas incidunt iusto.\nFugit magnam qui.", 143 },
                    { 67, new DateTime(2021, 3, 27, 3, 41, 6, 707, DateTimeKind.Local).AddTicks(3122), 55, 80, new DateTime(2022, 6, 3, 9, 18, 59, 477, DateTimeKind.Local).AddTicks(2281), new DateTime(2020, 10, 8, 18, 25, 42, 676, DateTimeKind.Local).AddTicks(5437), 2, null, null, "Tempore cupiditate sint sequi voluptas quaerat.\nDolore et pariatur aliquid non doloribus eum nihil molestiae.", 22 },
                    { 65, new DateTime(2021, 1, 9, 4, 35, 6, 250, DateTimeKind.Local).AddTicks(2924), 55, 37, new DateTime(2022, 4, 27, 17, 51, 35, 705, DateTimeKind.Local).AddTicks(6106), new DateTime(2020, 12, 28, 0, 25, 59, 498, DateTimeKind.Local).AddTicks(2886), 4, null, null, "Suscipit iste eos fugiat.\nIllum non corrupti.\nVoluptatem dignissimos sunt.\nAut ab quia neque vitae consequatur quam eos non in.", 96 },
                    { 63, new DateTime(2021, 5, 31, 17, 11, 37, 752, DateTimeKind.Local).AddTicks(9693), 55, 16, new DateTime(2021, 12, 22, 15, 35, 17, 840, DateTimeKind.Local).AddTicks(4563), new DateTime(2020, 10, 15, 10, 18, 9, 30, DateTimeKind.Local).AddTicks(2006), 4, null, null, "Eum voluptatibus incidunt aut adipisci.\nMaxime est incidunt numquam quidem et odio beatae.\nIn nobis porro ut sit rerum consequuntur laudantium cum commodi.\nOccaecati mollitia nemo minus recusandae ut id eum.\nNihil deleniti voluptatem.\nCommodi atque voluptatem quidem fugit quia voluptatibus qui excepturi expedita.", 244 },
                    { 96, new DateTime(2021, 2, 18, 22, 44, 38, 848, DateTimeKind.Local).AddTicks(2769), 13, 123, new DateTime(2022, 1, 26, 17, 58, 35, 869, DateTimeKind.Local).AddTicks(5889), new DateTime(2020, 12, 19, 5, 22, 36, 299, DateTimeKind.Local).AddTicks(9081), 2, null, null, "autem", 27 },
                    { 9, new DateTime(2021, 6, 8, 7, 25, 36, 513, DateTimeKind.Local).AddTicks(8771), 13, 4, new DateTime(2022, 6, 16, 14, 5, 0, 521, DateTimeKind.Local).AddTicks(2667), new DateTime(2020, 9, 7, 7, 55, 39, 262, DateTimeKind.Local).AddTicks(8229), 1, null, null, "Qui fugit dolor minus minima autem.\nSequi ad quos.\nSunt laboriosam distinctio.\nNobis corporis libero architecto.\nVel consequatur sequi eligendi vitae qui voluptatum.", 51 },
                    { 123, new DateTime(2020, 11, 24, 22, 4, 35, 182, DateTimeKind.Local).AddTicks(8966), 10, 62, new DateTime(2022, 1, 26, 18, 22, 11, 586, DateTimeKind.Local).AddTicks(7530), new DateTime(2020, 12, 26, 19, 10, 12, 392, DateTimeKind.Local).AddTicks(1694), 1, null, null, "Est atque dolor. Sit molestiae iusto. Voluptatum excepturi illum eveniet dolore soluta. Rem quidem omnis provident. Libero corrupti excepturi rerum. Sint vero necessitatibus suscipit dolor perferendis explicabo.", 106 },
                    { 98, new DateTime(2021, 2, 12, 1, 48, 17, 234, DateTimeKind.Local).AddTicks(5161), 20, 51, new DateTime(2022, 7, 15, 11, 7, 29, 67, DateTimeKind.Local).AddTicks(1934), new DateTime(2020, 8, 29, 13, 41, 19, 106, DateTimeKind.Local).AddTicks(4503), 1, null, null, "Sed suscipit soluta iste consequatur reiciendis ut optio quia.\nNecessitatibus esse laborum.\nVoluptatem incidunt exercitationem.\nIncidunt voluptas quis veritatis dicta repellat dolores vel laboriosam.\nNisi excepturi voluptatem sint nam cumque voluptas sint.", 295 },
                    { 192, new DateTime(2021, 4, 3, 20, 45, 54, 538, DateTimeKind.Local).AddTicks(5189), 56, 101, new DateTime(2022, 7, 10, 21, 53, 38, 74, DateTimeKind.Local).AddTicks(777), new DateTime(2020, 11, 17, 17, 5, 26, 355, DateTimeKind.Local).AddTicks(7493), 1, null, null, "Cumque rerum dolor placeat. Dolorem cumque unde officiis odio repellat consequatur beatae est rerum. Et magnam nihil esse in deleniti fugiat ea. Nam corporis maiores quo voluptatum explicabo. Illum modi dolore quidem at voluptatibus quas quo aut.", 255 },
                    { 101, new DateTime(2020, 10, 9, 11, 59, 51, 731, DateTimeKind.Local).AddTicks(2716), 13, 124, new DateTime(2021, 9, 10, 21, 14, 27, 749, DateTimeKind.Local).AddTicks(6734), new DateTime(2021, 2, 12, 17, 5, 9, 37, DateTimeKind.Local).AddTicks(1991), 4, null, null, "Est ullam earum saepe laboriosam consequuntur. Earum quod quia. Modi consequuntur et et sit aspernatur minima corporis fuga. Vero itaque voluptas optio adipisci saepe modi minima.", 70 },
                    { 165, new DateTime(2021, 4, 23, 8, 33, 34, 814, DateTimeKind.Local).AddTicks(3334), 13, 31, new DateTime(2022, 6, 10, 8, 11, 13, 810, DateTimeKind.Local).AddTicks(1032), new DateTime(2021, 6, 28, 1, 6, 15, 682, DateTimeKind.Local).AddTicks(2094), 3, null, null, "itaque", 26 },
                    { 186, new DateTime(2020, 10, 10, 23, 18, 3, 486, DateTimeKind.Local).AddTicks(691), 58, 74, new DateTime(2022, 1, 18, 21, 25, 28, 267, DateTimeKind.Local).AddTicks(6308), new DateTime(2021, 5, 25, 19, 25, 34, 732, DateTimeKind.Local).AddTicks(7557), 3, null, null, "Reiciendis illum iste dicta officiis occaecati qui eligendi a.\nReiciendis et veniam id aut maiores maiores et itaque nulla.\nVeritatis et consequatur enim vel beatae nam aut dolorem dicta.", 171 },
                    { 146, new DateTime(2021, 6, 25, 7, 9, 6, 194, DateTimeKind.Local).AddTicks(9997), 29, 105, new DateTime(2022, 3, 16, 12, 49, 44, 805, DateTimeKind.Local).AddTicks(8187), new DateTime(2021, 1, 5, 17, 10, 14, 913, DateTimeKind.Local).AddTicks(5628), 4, null, null, "Aut qui deserunt velit ex inventore. Quis odio harum et rerum minima possimus deleniti impedit. Delectus maiores nobis veritatis porro vel enim. Enim quis similique qui quas. Deleniti sint perferendis ipsam voluptatem. Delectus architecto quis maiores ipsum impedit beatae provident recusandae.", 134 },
                    { 23, new DateTime(2020, 12, 8, 10, 1, 15, 853, DateTimeKind.Local).AddTicks(5710), 56, 83, new DateTime(2022, 6, 21, 23, 13, 31, 533, DateTimeKind.Local).AddTicks(1980), new DateTime(2021, 2, 26, 4, 18, 19, 65, DateTimeKind.Local).AddTicks(7568), 2, null, null, "Blanditiis distinctio dolorem eum magni.\nDeleniti aut ullam odio recusandae voluptate eum.\nConsequuntur cupiditate occaecati quis voluptate non eius et odio.\nSequi nemo sapiente adipisci repudiandae dolore repudiandae dicta.\nVel repudiandae quia est aut dolores ducimus.\nIste dolor culpa ducimus sunt.", 253 },
                    { 20, new DateTime(2021, 3, 24, 6, 27, 54, 883, DateTimeKind.Local).AddTicks(8006), 76, 80, new DateTime(2021, 12, 20, 7, 18, 18, 633, DateTimeKind.Local).AddTicks(7695), new DateTime(2021, 8, 20, 5, 20, 51, 31, DateTimeKind.Local).AddTicks(340), 1, null, null, "Et vel nihil similique repellat.", 133 },
                    { 121, new DateTime(2021, 8, 8, 16, 34, 32, 257, DateTimeKind.Local).AddTicks(3008), 47, 22, new DateTime(2022, 5, 23, 15, 59, 11, 638, DateTimeKind.Local).AddTicks(1077), new DateTime(2021, 2, 3, 19, 55, 10, 458, DateTimeKind.Local).AddTicks(358), 2, null, null, "Qui fuga tempore tenetur.", 261 },
                    { 76, new DateTime(2021, 3, 7, 19, 6, 19, 621, DateTimeKind.Local).AddTicks(7930), 7, 81, new DateTime(2021, 11, 24, 0, 13, 51, 376, DateTimeKind.Local).AddTicks(3992), new DateTime(2020, 9, 14, 16, 53, 32, 170, DateTimeKind.Local).AddTicks(2580), 1, null, null, "Reiciendis hic et non sed sunt laborum doloremque eos explicabo. Molestiae qui nemo saepe dolorem nihil sint quaerat. Quaerat quidem neque natus eligendi incidunt eum. Nobis facilis a fugit voluptatum id non hic omnis. Adipisci amet ex placeat.", 100 },
                    { 92, new DateTime(2020, 9, 28, 1, 55, 2, 326, DateTimeKind.Local).AddTicks(930), 16, 15, new DateTime(2021, 12, 19, 2, 9, 56, 545, DateTimeKind.Local).AddTicks(9904), new DateTime(2021, 8, 21, 15, 29, 14, 993, DateTimeKind.Local).AddTicks(9893), 3, null, null, "Quia optio non dolorem voluptate illum corrupti occaecati. Et itaque ipsam. Sed tenetur veniam incidunt eveniet eos accusantium. Et sed est. Quae velit aut est non officia ut nostrum eum.", 157 },
                    { 16, new DateTime(2020, 11, 17, 13, 42, 0, 437, DateTimeKind.Local).AddTicks(8285), 16, 68, new DateTime(2021, 11, 28, 23, 34, 41, 843, DateTimeKind.Local).AddTicks(9557), new DateTime(2021, 2, 28, 18, 28, 3, 74, DateTimeKind.Local).AddTicks(5403), 5, null, null, "asperiores", 229 },
                    { 172, new DateTime(2021, 7, 5, 21, 13, 41, 366, DateTimeKind.Local).AddTicks(2851), 40, 33, new DateTime(2022, 1, 21, 6, 58, 34, 271, DateTimeKind.Local).AddTicks(9961), new DateTime(2020, 11, 11, 16, 31, 1, 704, DateTimeKind.Local).AddTicks(9803), 2, null, null, "adipisci", 150 },
                    { 91, new DateTime(2021, 7, 29, 13, 4, 27, 76, DateTimeKind.Local).AddTicks(9207), 40, 2, new DateTime(2022, 3, 18, 1, 54, 10, 622, DateTimeKind.Local).AddTicks(3803), new DateTime(2020, 11, 11, 17, 2, 31, 160, DateTimeKind.Local).AddTicks(7878), 2, null, null, "Quia et veniam dolorem voluptas quo facere sed consequatur aut. Fugit sapiente similique ut porro labore et a aut hic. Qui beatae qui.", 106 },
                    { 200, new DateTime(2020, 11, 13, 16, 50, 21, 627, DateTimeKind.Local).AddTicks(3202), 35, 141, new DateTime(2022, 2, 3, 9, 12, 6, 6, DateTimeKind.Local).AddTicks(201), new DateTime(2020, 10, 9, 1, 23, 17, 712, DateTimeKind.Local).AddTicks(3468), 5, null, null, "rerum", 191 },
                    { 147, new DateTime(2021, 5, 15, 8, 46, 29, 386, DateTimeKind.Local).AddTicks(4986), 35, 46, new DateTime(2022, 8, 4, 8, 8, 31, 755, DateTimeKind.Local).AddTicks(8458), new DateTime(2021, 7, 6, 12, 52, 3, 180, DateTimeKind.Local).AddTicks(4997), 2, null, null, "Reprehenderit aliquid minima sint vitae nobis.", 91 },
                    { 197, new DateTime(2021, 6, 12, 2, 10, 39, 661, DateTimeKind.Local).AddTicks(2019), 42, 5, new DateTime(2022, 3, 18, 5, 42, 21, 817, DateTimeKind.Local).AddTicks(5005), new DateTime(2020, 10, 18, 10, 12, 21, 723, DateTimeKind.Local).AddTicks(4819), 4, null, null, "Vel vel qui maiores dolorem earum velit ipsum.\nNobis minima qui.\nIusto recusandae rem ut quasi voluptatem.\nExplicabo et sunt perferendis cum sint animi.\nIusto enim cum eos itaque et est ducimus.", 77 },
                    { 70, new DateTime(2021, 5, 21, 9, 53, 16, 696, DateTimeKind.Local).AddTicks(5042), 42, 98, new DateTime(2022, 5, 6, 0, 37, 43, 817, DateTimeKind.Local).AddTicks(5451), new DateTime(2020, 9, 8, 4, 40, 34, 601, DateTimeKind.Local).AddTicks(1210), 1, null, null, "Voluptates recusandae ut voluptas vero et. Repellat tempora illum accusantium nihil. Ea atque in. Aut est voluptas officiis velit sint magnam. Placeat molestiae sunt. Exercitationem aut laboriosam cupiditate est iste dolorem.", 237 },
                    { 176, new DateTime(2021, 5, 23, 17, 14, 37, 130, DateTimeKind.Local).AddTicks(2236), 16, 46, new DateTime(2022, 1, 12, 23, 37, 49, 761, DateTimeKind.Local).AddTicks(3889), new DateTime(2021, 5, 13, 16, 55, 53, 799, DateTimeKind.Local).AddTicks(9677), 2, null, null, "Omnis omnis incidunt quia sint enim sed eos quisquam vel. Autem qui enim libero. Qui a omnis. Libero saepe officia cupiditate veritatis veritatis. Sit exercitationem commodi cum esse aliquid. Qui natus cumque ut aperiam officiis eos sed sit.", 78 },
                    { 19, new DateTime(2021, 5, 8, 23, 59, 38, 351, DateTimeKind.Local).AddTicks(8389), 34, 96, new DateTime(2022, 5, 22, 14, 43, 35, 582, DateTimeKind.Local).AddTicks(9595), new DateTime(2021, 8, 15, 16, 18, 16, 269, DateTimeKind.Local).AddTicks(5091), 5, null, null, "Necessitatibus ratione ut eum quo beatae aut.", 78 },
                    { 168, new DateTime(2020, 12, 7, 22, 59, 32, 17, DateTimeKind.Local).AddTicks(9502), 44, 110, new DateTime(2022, 4, 4, 20, 3, 19, 216, DateTimeKind.Local).AddTicks(2739), new DateTime(2020, 10, 21, 12, 49, 26, 285, DateTimeKind.Local).AddTicks(4467), 5, null, null, "dolorem", 146 },
                    { 105, new DateTime(2020, 10, 28, 16, 8, 29, 481, DateTimeKind.Local).AddTicks(9674), 44, 41, new DateTime(2022, 6, 7, 4, 9, 47, 426, DateTimeKind.Local).AddTicks(62), new DateTime(2020, 10, 1, 2, 38, 10, 375, DateTimeKind.Local).AddTicks(6738), 2, null, null, "Optio dolore culpa.\nAutem et ad reiciendis.\nEt adipisci necessitatibus modi magnam est qui aliquam nihil doloremque.\nQuaerat magnam quia doloribus quia impedit.", 232 },
                    { 53, new DateTime(2021, 6, 23, 16, 10, 53, 376, DateTimeKind.Local).AddTicks(2651), 44, 56, new DateTime(2022, 7, 14, 6, 33, 43, 197, DateTimeKind.Local).AddTicks(2811), new DateTime(2021, 3, 4, 0, 18, 11, 431, DateTimeKind.Local).AddTicks(4924), 1, null, null, "Vel maiores qui dolor vero assumenda quia velit. Sit occaecati iusto ut tempora. Ut dolore sit harum rerum voluptates.", 96 },
                    { 55, new DateTime(2020, 10, 14, 6, 56, 27, 745, DateTimeKind.Local).AddTicks(3761), 23, 15, new DateTime(2021, 11, 17, 10, 50, 4, 850, DateTimeKind.Local).AddTicks(848), new DateTime(2021, 8, 10, 22, 38, 42, 490, DateTimeKind.Local).AddTicks(2558), 5, null, null, "repellat", 156 },
                    { 156, new DateTime(2021, 2, 3, 20, 19, 35, 987, DateTimeKind.Local).AddTicks(2179), 31, 147, new DateTime(2022, 2, 8, 22, 35, 25, 624, DateTimeKind.Local).AddTicks(1721), new DateTime(2020, 9, 3, 12, 29, 12, 9, DateTimeKind.Local).AddTicks(5774), 1, null, null, "Odit quae eos molestiae sapiente fugit error illum officia. Iste ullam placeat. Tempora sed modi non iure harum.", 221 },
                    { 100, new DateTime(2021, 1, 6, 16, 3, 18, 350, DateTimeKind.Local).AddTicks(5547), 31, 122, new DateTime(2022, 1, 4, 2, 3, 44, 316, DateTimeKind.Local).AddTicks(3432), new DateTime(2020, 11, 10, 17, 19, 52, 698, DateTimeKind.Local).AddTicks(9644), 4, null, null, "In qui magnam nobis inventore iste.", 256 },
                    { 43, new DateTime(2021, 5, 4, 1, 35, 22, 738, DateTimeKind.Local).AddTicks(4283), 31, 27, new DateTime(2021, 12, 4, 11, 26, 21, 528, DateTimeKind.Local).AddTicks(8982), new DateTime(2021, 8, 10, 4, 8, 9, 403, DateTimeKind.Local).AddTicks(174), 4, null, null, "Qui modi sit soluta totam aut labore rerum et.", 229 },
                    { 2, new DateTime(2021, 5, 28, 18, 29, 19, 938, DateTimeKind.Local).AddTicks(770), 31, 81, new DateTime(2022, 7, 13, 19, 1, 49, 976, DateTimeKind.Local).AddTicks(3157), new DateTime(2020, 9, 29, 3, 13, 55, 96, DateTimeKind.Local).AddTicks(2462), 4, null, null, "aut", 106 },
                    { 196, new DateTime(2021, 5, 4, 13, 45, 23, 342, DateTimeKind.Local).AddTicks(6752), 44, 35, new DateTime(2021, 10, 22, 15, 43, 43, 235, DateTimeKind.Local).AddTicks(8961), new DateTime(2021, 1, 28, 6, 45, 58, 388, DateTimeKind.Local).AddTicks(5163), 2, null, null, "Doloribus ab quis fugit autem porro atque dicta.\nOmnis reiciendis nam.\nNesciunt culpa et soluta reiciendis consectetur ea perspiciatis.\nBeatae maxime autem ut quae omnis nihil est sequi.\nDolores facere sapiente velit at asperiores optio est tenetur odit.\nId nulla est ut praesentium nobis repellendus sequi qui.", 294 },
                    { 136, new DateTime(2021, 5, 22, 7, 0, 42, 827, DateTimeKind.Local).AddTicks(8651), 28, 39, new DateTime(2022, 4, 29, 12, 57, 44, 391, DateTimeKind.Local).AddTicks(2687), new DateTime(2021, 5, 31, 12, 35, 8, 884, DateTimeKind.Local).AddTicks(8794), 5, null, null, "Maiores dolores similique nam.\nDelectus ex ipsam et sapiente iure.\nRepudiandae ut odio mollitia ea maxime ab quia.", 8 },
                    { 182, new DateTime(2020, 9, 25, 4, 31, 44, 805, DateTimeKind.Local).AddTicks(3493), 63, 79, new DateTime(2022, 8, 23, 8, 20, 27, 449, DateTimeKind.Local).AddTicks(7360), new DateTime(2021, 7, 20, 11, 22, 44, 681, DateTimeKind.Local).AddTicks(8259), 1, null, null, "Soluta quia dolorum voluptatum qui eius pariatur non.\nExcepturi quas id ut reiciendis fuga sit alias.\nVel deserunt quos voluptatem aut dolorum quo est.\nRepellendus voluptatem labore cupiditate modi cum.", 235 },
                    { 126, new DateTime(2020, 11, 4, 15, 13, 38, 921, DateTimeKind.Local).AddTicks(5941), 32, 89, new DateTime(2021, 10, 17, 11, 15, 17, 110, DateTimeKind.Local).AddTicks(2489), new DateTime(2020, 9, 10, 16, 28, 16, 366, DateTimeKind.Local).AddTicks(6344), 4, null, null, "aut", 276 },
                    { 18, new DateTime(2021, 1, 31, 3, 12, 49, 802, DateTimeKind.Local).AddTicks(3737), 18, 92, new DateTime(2022, 2, 26, 20, 33, 36, 508, DateTimeKind.Local).AddTicks(6733), new DateTime(2020, 9, 5, 8, 29, 48, 710, DateTimeKind.Local).AddTicks(1288), 4, null, null, "Et placeat doloremque doloribus iste quod doloribus suscipit sed tempore.\nOfficiis qui voluptas dolor.\nRepudiandae et exercitationem.\nEt doloribus voluptatum dolorum consequatur explicabo blanditiis quis.\nOptio aut eius dignissimos autem qui magnam.", 175 },
                    { 137, new DateTime(2021, 5, 21, 19, 45, 16, 593, DateTimeKind.Local).AddTicks(2377), 8, 150, new DateTime(2022, 7, 8, 2, 41, 21, 715, DateTimeKind.Local).AddTicks(7766), new DateTime(2021, 2, 2, 11, 21, 37, 677, DateTimeKind.Local).AddTicks(1106), 1, null, null, "laborum", 70 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 50, new DateTime(2021, 3, 7, 22, 38, 39, 380, DateTimeKind.Local).AddTicks(99), 8, 147, new DateTime(2022, 4, 3, 13, 10, 49, 583, DateTimeKind.Local).AddTicks(5429), new DateTime(2021, 1, 17, 13, 35, 40, 633, DateTimeKind.Local).AddTicks(4711), 2, null, null, "Nihil ullam occaecati et non.", 295 },
                    { 11, new DateTime(2021, 3, 8, 6, 7, 55, 896, DateTimeKind.Local).AddTicks(4131), 8, 13, new DateTime(2022, 3, 29, 3, 41, 6, 548, DateTimeKind.Local).AddTicks(2181), new DateTime(2021, 7, 16, 9, 31, 18, 15, DateTimeKind.Local).AddTicks(3093), 4, null, null, "natus", 286 },
                    { 133, new DateTime(2021, 1, 25, 18, 37, 56, 555, DateTimeKind.Local).AddTicks(8077), 48, 114, new DateTime(2022, 3, 18, 18, 45, 11, 223, DateTimeKind.Local).AddTicks(7816), new DateTime(2020, 9, 10, 22, 24, 32, 107, DateTimeKind.Local).AddTicks(6615), 1, null, null, "fugit", 35 },
                    { 45, new DateTime(2021, 5, 30, 14, 32, 56, 829, DateTimeKind.Local).AddTicks(9616), 48, 74, new DateTime(2021, 10, 11, 12, 23, 18, 639, DateTimeKind.Local).AddTicks(792), new DateTime(2021, 5, 3, 15, 35, 18, 44, DateTimeKind.Local).AddTicks(3946), 2, null, null, "Assumenda quos repellat rerum.", 117 },
                    { 31, new DateTime(2021, 8, 18, 15, 9, 4, 697, DateTimeKind.Local).AddTicks(8378), 48, 133, new DateTime(2021, 11, 15, 0, 12, 29, 997, DateTimeKind.Local).AddTicks(9298), new DateTime(2021, 6, 24, 22, 0, 11, 78, DateTimeKind.Local).AddTicks(4431), 4, null, null, "eos", 269 },
                    { 164, new DateTime(2021, 1, 22, 18, 31, 41, 316, DateTimeKind.Local).AddTicks(79), 54, 66, new DateTime(2022, 2, 17, 11, 59, 47, 691, DateTimeKind.Local).AddTicks(6991), new DateTime(2020, 10, 7, 5, 52, 19, 107, DateTimeKind.Local).AddTicks(2368), 5, null, null, "Culpa laborum aliquam.", 232 },
                    { 32, new DateTime(2021, 2, 3, 16, 4, 28, 637, DateTimeKind.Local).AddTicks(4834), 32, 69, new DateTime(2021, 11, 11, 3, 18, 51, 953, DateTimeKind.Local).AddTicks(7382), new DateTime(2021, 2, 11, 20, 16, 8, 560, DateTimeKind.Local).AddTicks(3780), 3, null, null, "Et et fugit dignissimos praesentium praesentium. Sit voluptates voluptatum expedita. Omnis fugiat quia numquam labore enim cupiditate. Deserunt voluptas et pariatur rerum. Qui vero voluptatem neque minus praesentium veritatis. Labore nesciunt vero totam quo id aliquam et.", 118 },
                    { 66, new DateTime(2020, 12, 9, 19, 45, 27, 283, DateTimeKind.Local).AddTicks(6785), 54, 93, new DateTime(2022, 7, 3, 7, 16, 30, 509, DateTimeKind.Local).AddTicks(2153), new DateTime(2020, 11, 7, 5, 13, 0, 912, DateTimeKind.Local).AddTicks(5467), 2, null, null, "Tenetur consequatur veritatis ex occaecati. Error similique occaecati pariatur maxime. Ipsa quas vel nam ratione maxime. Qui aperiam vitae quia nesciunt quas dolorem odio in. Illum nihil quia sed. Aut maxime doloribus at facilis.", 99 },
                    { 145, new DateTime(2020, 10, 11, 19, 30, 12, 105, DateTimeKind.Local).AddTicks(287), 3, 5, new DateTime(2022, 1, 20, 20, 45, 9, 283, DateTimeKind.Local).AddTicks(7401), new DateTime(2021, 3, 15, 10, 36, 48, 755, DateTimeKind.Local).AddTicks(9733), 2, null, null, "Et neque molestiae molestiae voluptas blanditiis ratione quo suscipit.", 117 },
                    { 130, new DateTime(2020, 10, 13, 23, 19, 22, 350, DateTimeKind.Local).AddTicks(5950), 3, 76, new DateTime(2022, 4, 4, 17, 50, 19, 628, DateTimeKind.Local).AddTicks(8279), new DateTime(2021, 7, 8, 20, 37, 20, 342, DateTimeKind.Local).AddTicks(1308), 1, null, null, "Architecto odio laboriosam earum provident quia voluptatem necessitatibus dignissimos.\nSint at aut quaerat.\nVoluptatem voluptas temporibus ut rerum.\nCumque id et hic culpa consectetur ut.\nAliquam ut exercitationem quis iusto aperiam.\nAut nulla totam dolore.", 90 },
                    { 108, new DateTime(2021, 1, 9, 20, 33, 46, 855, DateTimeKind.Local).AddTicks(5296), 3, 138, new DateTime(2022, 6, 8, 3, 20, 9, 731, DateTimeKind.Local).AddTicks(8204), new DateTime(2021, 2, 28, 19, 15, 18, 651, DateTimeKind.Local).AddTicks(9385), 5, null, null, "Quibusdam laboriosam autem perspiciatis voluptatem enim harum. Libero quo aperiam ratione autem. Repellat suscipit enim excepturi quam. Quis tempore praesentium. Voluptatem ipsa dignissimos nemo impedit reprehenderit voluptas et amet voluptates.", 143 },
                    { 195, new DateTime(2021, 4, 8, 7, 55, 51, 72, DateTimeKind.Local).AddTicks(8320), 68, 40, new DateTime(2022, 4, 11, 7, 0, 0, 469, DateTimeKind.Local).AddTicks(9659), new DateTime(2020, 12, 28, 1, 5, 23, 331, DateTimeKind.Local).AddTicks(8124), 1, null, null, "Sit eveniet nam eaque velit natus ad.\nDeleniti qui hic laudantium eos aut corrupti.\nOdio consectetur recusandae sequi qui.", 203 },
                    { 180, new DateTime(2021, 4, 13, 12, 11, 6, 800, DateTimeKind.Local).AddTicks(4407), 68, 131, new DateTime(2022, 5, 28, 17, 56, 47, 222, DateTimeKind.Local).AddTicks(2556), new DateTime(2021, 1, 17, 15, 20, 55, 742, DateTimeKind.Local).AddTicks(1742), 5, null, null, "minus", 77 },
                    { 170, new DateTime(2021, 2, 6, 12, 16, 6, 589, DateTimeKind.Local).AddTicks(1890), 68, 48, new DateTime(2022, 8, 2, 20, 18, 55, 69, DateTimeKind.Local).AddTicks(140), new DateTime(2021, 5, 18, 10, 3, 17, 620, DateTimeKind.Local).AddTicks(6638), 1, null, null, "Ipsa libero voluptates corrupti ut dolore voluptatibus.\nQuaerat eum repudiandae ut optio a.\nVoluptatem molestiae quis saepe.\nSuscipit cupiditate sit.", 242 },
                    { 42, new DateTime(2021, 4, 25, 1, 44, 5, 22, DateTimeKind.Local).AddTicks(1616), 68, 135, new DateTime(2022, 2, 12, 7, 49, 22, 151, DateTimeKind.Local).AddTicks(8975), new DateTime(2021, 4, 13, 15, 20, 49, 256, DateTimeKind.Local).AddTicks(8477), 3, null, null, "facere", 66 },
                    { 5, new DateTime(2021, 6, 20, 14, 47, 17, 688, DateTimeKind.Local).AddTicks(9441), 68, 61, new DateTime(2021, 10, 18, 19, 2, 37, 944, DateTimeKind.Local).AddTicks(186), new DateTime(2020, 11, 2, 16, 28, 28, 866, DateTimeKind.Local).AddTicks(371), 2, null, null, "Quibusdam praesentium incidunt in alias deserunt numquam voluptatem consectetur.\nRatione dolor quaerat voluptas officiis.\nIpsum tempora repudiandae.\nRepudiandae et explicabo suscipit provident amet quibusdam.\nOmnis omnis sint ut dolorem velit voluptas asperiores harum et.", 47 },
                    { 3, new DateTime(2020, 10, 16, 6, 48, 18, 59, DateTimeKind.Local).AddTicks(7686), 54, 62, new DateTime(2021, 11, 5, 11, 48, 24, 440, DateTimeKind.Local).AddTicks(4883), new DateTime(2021, 5, 23, 3, 26, 26, 863, DateTimeKind.Local).AddTicks(153), 2, null, null, "Non et accusamus. Enim ab dolorum quos necessitatibus voluptas sint iusto esse. Molestiae in in consectetur optio. Aspernatur itaque est. Deserunt aut et odio incidunt consequuntur blanditiis.", 99 },
                    { 84, new DateTime(2021, 7, 28, 12, 24, 39, 336, DateTimeKind.Local).AddTicks(8530), 18, 115, new DateTime(2022, 4, 26, 12, 26, 35, 719, DateTimeKind.Local).AddTicks(4884), new DateTime(2021, 7, 22, 5, 57, 45, 610, DateTimeKind.Local).AddTicks(2928), 5, null, null, "Mollitia eligendi explicabo iure animi.\nEius molestiae laborum sunt saepe perferendis omnis excepturi.\nAdipisci adipisci fuga consequatur quod et ullam.\nAliquam nobis in rem.\nEt laudantium illum quae delectus.\nCorporis repellendus labore nesciunt est.", 76 },
                    { 8, new DateTime(2021, 8, 10, 4, 57, 3, 190, DateTimeKind.Local).AddTicks(3909), 28, 143, new DateTime(2022, 8, 6, 17, 14, 59, 709, DateTimeKind.Local).AddTicks(7821), new DateTime(2020, 11, 6, 16, 10, 23, 382, DateTimeKind.Local).AddTicks(6250), 2, null, null, "nihil", 168 },
                    { 79, new DateTime(2020, 12, 8, 10, 48, 7, 23, DateTimeKind.Local).AddTicks(5112), 27, 89, new DateTime(2022, 1, 24, 15, 21, 40, 281, DateTimeKind.Local).AddTicks(3481), new DateTime(2020, 9, 1, 0, 51, 28, 161, DateTimeKind.Local).AddTicks(9890), 2, null, null, "Est odit sit qui.\nSimilique corrupti ab voluptate ea nostrum dolore quae.", 221 },
                    { 14, new DateTime(2021, 7, 4, 8, 52, 12, 410, DateTimeKind.Local).AddTicks(6854), 59, 39, new DateTime(2022, 3, 25, 2, 43, 18, 888, DateTimeKind.Local).AddTicks(8895), new DateTime(2021, 7, 12, 6, 1, 58, 814, DateTimeKind.Local).AddTicks(604), 2, null, null, "Sint assumenda deleniti rerum error numquam et.", 18 },
                    { 188, new DateTime(2020, 11, 18, 18, 14, 43, 576, DateTimeKind.Local).AddTicks(339), 11, 119, new DateTime(2022, 2, 4, 22, 35, 0, 430, DateTimeKind.Local).AddTicks(7465), new DateTime(2021, 8, 5, 9, 27, 55, 897, DateTimeKind.Local).AddTicks(5334), 4, null, null, "amet", 195 },
                    { 132, new DateTime(2021, 6, 23, 18, 47, 51, 62, DateTimeKind.Local).AddTicks(4094), 43, 72, new DateTime(2022, 6, 9, 18, 8, 50, 108, DateTimeKind.Local).AddTicks(2216), new DateTime(2020, 11, 24, 14, 4, 27, 565, DateTimeKind.Local).AddTicks(6960), 5, null, null, "Maiores voluptas minima minus neque architecto iusto rem qui quas.\nAssumenda et minima dolor similique quibusdam tempora eos.\nVelit tempora est nobis unde quo qui qui tenetur.\nLaborum consequatur velit quidem ullam ut.\nDolorum placeat omnis beatae voluptas delectus.", 61 },
                    { 125, new DateTime(2021, 8, 7, 2, 41, 6, 57, DateTimeKind.Local).AddTicks(7640), 43, 112, new DateTime(2022, 1, 10, 10, 23, 4, 787, DateTimeKind.Local).AddTicks(543), new DateTime(2021, 3, 29, 16, 47, 2, 768, DateTimeKind.Local).AddTicks(8838), 5, null, null, "iste", 96 },
                    { 90, new DateTime(2021, 8, 9, 9, 43, 12, 63, DateTimeKind.Local).AddTicks(4465), 43, 54, new DateTime(2021, 10, 14, 11, 50, 3, 634, DateTimeKind.Local).AddTicks(368), new DateTime(2021, 5, 18, 10, 35, 38, 342, DateTimeKind.Local).AddTicks(1401), 1, null, null, "aut", 191 },
                    { 44, new DateTime(2020, 9, 15, 23, 4, 40, 941, DateTimeKind.Local).AddTicks(5946), 43, 87, new DateTime(2022, 4, 20, 18, 51, 12, 800, DateTimeKind.Local).AddTicks(6250), new DateTime(2021, 3, 1, 19, 57, 48, 86, DateTimeKind.Local).AddTicks(9412), 2, null, null, "Consequatur numquam vel cupiditate distinctio ex.\nQui totam ratione et.\nAut hic ab enim aut voluptatem quis iusto.\nQuaerat ea repellat.\nNesciunt atque dolorem et vitae sequi dignissimos quia.", 203 },
                    { 183, new DateTime(2020, 12, 8, 16, 47, 35, 112, DateTimeKind.Local).AddTicks(1847), 9, 79, new DateTime(2022, 7, 12, 22, 7, 26, 729, DateTimeKind.Local).AddTicks(23), new DateTime(2021, 3, 16, 21, 43, 26, 7, DateTimeKind.Local).AddTicks(4244), 2, null, null, "Maxime laudantium sed quibusdam quia fugit.\nVoluptas dolorem nesciunt.\nSed expedita fugit alias rerum libero vel et veritatis.\nDoloribus minima inventore nisi officiis quidem.\nTempora rerum et repudiandae cum et voluptatem sequi.\nNon quis libero dicta in ex et pariatur.", 41 },
                    { 39, new DateTime(2021, 5, 9, 9, 46, 39, 464, DateTimeKind.Local).AddTicks(4465), 9, 70, new DateTime(2022, 4, 7, 19, 44, 7, 540, DateTimeKind.Local).AddTicks(7556), new DateTime(2021, 6, 9, 20, 38, 0, 714, DateTimeKind.Local).AddTicks(859), 3, null, null, "Pariatur asperiores libero rerum. Quo non tempora distinctio est officia. Corrupti ad molestiae quibusdam eaque aut voluptatibus blanditiis ut. Beatae consequatur est illo temporibus accusantium dolorem. Est temporibus fugiat minima. Dicta nihil in architecto quibusdam et perspiciatis.", 259 },
                    { 112, new DateTime(2021, 6, 3, 14, 20, 52, 954, DateTimeKind.Local).AddTicks(8318), 59, 118, new DateTime(2022, 1, 28, 18, 26, 21, 927, DateTimeKind.Local).AddTicks(9388), new DateTime(2020, 12, 9, 21, 40, 48, 369, DateTimeKind.Local).AddTicks(7933), 2, null, null, "Quis amet ratione necessitatibus cum possimus quod.", 90 },
                    { 153, new DateTime(2021, 2, 2, 20, 2, 12, 623, DateTimeKind.Local).AddTicks(5316), 45, 11, new DateTime(2022, 1, 6, 5, 46, 22, 500, DateTimeKind.Local).AddTicks(8703), new DateTime(2021, 2, 13, 9, 32, 40, 985, DateTimeKind.Local).AddTicks(8248), 5, null, null, "Deleniti alias qui.\nSit debitis blanditiis animi nostrum ad.\nCorporis sint enim iste eius id fuga ratione.\nRecusandae est quibusdam nihil nisi quasi porro.\nAb id et voluptatibus ipsum magnam quasi ut sed.", 292 },
                    { 62, new DateTime(2020, 10, 8, 8, 29, 40, 270, DateTimeKind.Local).AddTicks(7190), 45, 98, new DateTime(2022, 3, 30, 11, 25, 48, 876, DateTimeKind.Local).AddTicks(79), new DateTime(2021, 8, 19, 0, 43, 59, 559, DateTimeKind.Local).AddTicks(2565), 1, null, null, "Autem neque accusantium tempora autem et voluptas nulla.", 182 },
                    { 46, new DateTime(2021, 8, 10, 15, 39, 12, 487, DateTimeKind.Local).AddTicks(9956), 45, 149, new DateTime(2022, 1, 14, 13, 57, 54, 253, DateTimeKind.Local).AddTicks(2524), new DateTime(2021, 6, 14, 1, 16, 22, 433, DateTimeKind.Local).AddTicks(7944), 5, null, null, "Omnis vero illum eveniet quas officiis.", 99 },
                    { 13, new DateTime(2021, 1, 19, 10, 13, 2, 656, DateTimeKind.Local).AddTicks(8245), 45, 62, new DateTime(2022, 8, 1, 5, 58, 35, 589, DateTimeKind.Local).AddTicks(6405), new DateTime(2020, 9, 26, 5, 24, 43, 185, DateTimeKind.Local).AddTicks(7758), 1, null, null, "Enim ipsum voluptate minus ipsa quis. Enim odit nihil consequatur et autem impedit aut. Officiis quam eaque cum.", 286 },
                    { 30, new DateTime(2020, 9, 8, 11, 32, 18, 305, DateTimeKind.Local).AddTicks(6042), 53, 30, new DateTime(2021, 12, 15, 5, 11, 7, 792, DateTimeKind.Local).AddTicks(1105), new DateTime(2020, 9, 29, 23, 57, 34, 466, DateTimeKind.Local).AddTicks(9470), 3, null, null, "Aut ut eos aut id labore tempore. Soluta molestiae voluptatem dolorem esse sed illum. Quia distinctio aut quasi molestias recusandae nobis reiciendis sit. Similique porro nihil ut. Illum quo aut quod ea. Amet facere ea velit itaque quia at expedita.", 106 },
                    { 174, new DateTime(2021, 5, 28, 19, 18, 42, 308, DateTimeKind.Local).AddTicks(4311), 37, 62, new DateTime(2021, 9, 7, 23, 9, 34, 834, DateTimeKind.Local).AddTicks(4310), new DateTime(2021, 2, 5, 11, 1, 31, 877, DateTimeKind.Local).AddTicks(1415), 1, null, null, "Dolor nemo est dolorum iste ut sit architecto minus corrupti.\nNostrum eum rerum et enim consequuntur necessitatibus maxime ut illum.\nRepudiandae doloribus laboriosam.\nNisi sit optio qui perspiciatis.", 261 },
                    { 118, new DateTime(2020, 10, 27, 5, 6, 52, 909, DateTimeKind.Local).AddTicks(801), 37, 80, new DateTime(2022, 5, 9, 11, 30, 31, 145, DateTimeKind.Local).AddTicks(8195), new DateTime(2021, 2, 19, 0, 24, 13, 97, DateTimeKind.Local).AddTicks(6255), 1, null, null, "Saepe tempora possimus.", 157 },
                    { 47, new DateTime(2021, 3, 3, 8, 20, 7, 349, DateTimeKind.Local).AddTicks(608), 14, 148, new DateTime(2022, 8, 27, 11, 41, 25, 209, DateTimeKind.Local).AddTicks(5700), new DateTime(2020, 10, 15, 4, 50, 13, 954, DateTimeKind.Local).AddTicks(1982), 1, null, null, "Est ad et ab sit itaque.", 268 },
                    { 36, new DateTime(2021, 2, 2, 19, 52, 33, 689, DateTimeKind.Local).AddTicks(3417), 14, 140, new DateTime(2021, 11, 10, 0, 47, 28, 853, DateTimeKind.Local).AddTicks(4824), new DateTime(2020, 9, 3, 5, 12, 41, 624, DateTimeKind.Local).AddTicks(5898), 1, null, null, "quod", 118 },
                    { 73, new DateTime(2021, 2, 12, 15, 31, 54, 368, DateTimeKind.Local).AddTicks(652), 45, 38, new DateTime(2021, 9, 11, 6, 16, 16, 891, DateTimeKind.Local).AddTicks(3842), new DateTime(2021, 2, 6, 14, 23, 30, 163, DateTimeKind.Local).AddTicks(8938), 4, null, null, "Temporibus nulla voluptas eum.", 69 },
                    { 82, new DateTime(2021, 1, 1, 12, 11, 34, 476, DateTimeKind.Local).AddTicks(4847), 27, 51, new DateTime(2022, 2, 17, 19, 10, 6, 846, DateTimeKind.Local).AddTicks(4654), new DateTime(2020, 10, 3, 0, 3, 24, 524, DateTimeKind.Local).AddTicks(7492), 4, null, null, "Ipsa facere saepe autem consectetur modi. Minus quod ipsam illo. Ad dolor blanditiis doloribus eos. Cum possimus et optio est aut esse esse architecto provident. Hic est inventore asperiores cum corrupti ea id. Magnam praesentium voluptas qui est facere sapiente.", 156 },
                    { 17, new DateTime(2020, 11, 23, 5, 45, 49, 660, DateTimeKind.Local).AddTicks(9388), 81, 25, new DateTime(2022, 5, 23, 7, 10, 34, 459, DateTimeKind.Local).AddTicks(4764), new DateTime(2021, 2, 12, 0, 20, 52, 24, DateTimeKind.Local).AddTicks(3028), 4, null, null, "Dolores eaque accusantium maxime nulla dolor et aut tempore.\nVeniam quibusdam et molestias quam voluptas harum consectetur.\nUt est qui qui sequi aliquid beatae.\nAnimi delectus inventore.\nId omnis officiis doloremque quibusdam.", 222 },
                    { 149, new DateTime(2021, 1, 10, 8, 35, 25, 255, DateTimeKind.Local).AddTicks(1459), 81, 85, new DateTime(2022, 4, 29, 3, 16, 16, 763, DateTimeKind.Local).AddTicks(2277), new DateTime(2020, 9, 25, 4, 4, 17, 533, DateTimeKind.Local).AddTicks(4400), 4, null, null, "Voluptatibus quo numquam.", 18 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 184, new DateTime(2020, 11, 9, 3, 24, 49, 7, DateTimeKind.Local).AddTicks(653), 79, 142, new DateTime(2022, 6, 7, 16, 43, 35, 242, DateTimeKind.Local).AddTicks(4099), new DateTime(2021, 6, 10, 10, 0, 47, 314, DateTimeKind.Local).AddTicks(1009), 5, null, null, "Possimus amet ratione qui magnam deleniti ea laborum minima repudiandae.\nNon eaque pariatur nulla aut quod cupiditate qui aut aperiam.\nNumquam quia fuga nihil omnis dolores sunt dolor.\nCorporis molestiae facilis molestias ut atque voluptatum aperiam consectetur soluta.\nArchitecto voluptatem itaque consectetur velit voluptatem cum quia consequatur.", 35 },
                    { 154, new DateTime(2021, 8, 22, 7, 55, 51, 814, DateTimeKind.Local).AddTicks(9809), 79, 118, new DateTime(2021, 9, 29, 3, 45, 55, 426, DateTimeKind.Local).AddTicks(5543), new DateTime(2021, 8, 12, 16, 38, 47, 171, DateTimeKind.Local).AddTicks(2698), 1, null, null, "Et delectus laboriosam. Excepturi reprehenderit sunt. Possimus quia corporis. Voluptatem neque expedita. Est omnis optio magni ut labore expedita.", 133 },
                    { 111, new DateTime(2020, 10, 5, 9, 46, 29, 403, DateTimeKind.Local).AddTicks(697), 79, 122, new DateTime(2021, 12, 29, 10, 7, 49, 877, DateTimeKind.Local).AddTicks(3195), new DateTime(2021, 3, 12, 18, 21, 43, 686, DateTimeKind.Local).AddTicks(9849), 4, null, null, "Asperiores deserunt eligendi molestias laborum debitis quidem ad.\nExcepturi fugit consequatur ut.\nDeleniti minima minus officia deleniti.\nSed ipsa consequatur nobis provident doloremque.", 28 },
                    { 38, new DateTime(2021, 5, 31, 21, 49, 9, 106, DateTimeKind.Local).AddTicks(6257), 79, 149, new DateTime(2022, 1, 14, 9, 5, 6, 460, DateTimeKind.Local).AddTicks(286), new DateTime(2021, 4, 19, 8, 29, 51, 14, DateTimeKind.Local).AddTicks(8519), 1, null, null, "Quidem unde assumenda sapiente ut velit.", 295 },
                    { 34, new DateTime(2021, 2, 27, 18, 27, 40, 46, DateTimeKind.Local).AddTicks(4514), 79, 69, new DateTime(2022, 2, 12, 18, 3, 15, 408, DateTimeKind.Local).AddTicks(2511), new DateTime(2020, 10, 11, 18, 42, 33, 882, DateTimeKind.Local).AddTicks(8049), 5, null, null, "Quos voluptatem possimus ullam omnis illum sit accusantium.", 171 },
                    { 33, new DateTime(2021, 4, 18, 21, 45, 59, 803, DateTimeKind.Local).AddTicks(4606), 79, 119, new DateTime(2022, 1, 31, 18, 51, 53, 983, DateTimeKind.Local).AddTicks(9967), new DateTime(2020, 11, 18, 23, 45, 6, 671, DateTimeKind.Local).AddTicks(8428), 2, null, null, "Et error at est cumque voluptatem.\nSaepe voluptatem minima facere maxime quod.\nMolestias doloremque deserunt neque.", 20 },
                    { 135, new DateTime(2020, 9, 30, 3, 25, 55, 759, DateTimeKind.Local).AddTicks(491), 61, 31, new DateTime(2022, 2, 25, 7, 56, 1, 282, DateTimeKind.Local).AddTicks(2652), new DateTime(2021, 3, 26, 15, 47, 43, 7, DateTimeKind.Local).AddTicks(1416), 5, null, null, "Non voluptas ea ut corporis sit esse.\nEius ducimus beatae ut incidunt repellendus.\nNihil sequi laudantium voluptas officia nostrum.", 195 },
                    { 115, new DateTime(2020, 11, 29, 8, 35, 15, 185, DateTimeKind.Local).AddTicks(1691), 38, 58, new DateTime(2022, 2, 21, 21, 51, 26, 272, DateTimeKind.Local).AddTicks(1695), new DateTime(2021, 4, 6, 5, 48, 3, 156, DateTimeKind.Local).AddTicks(566), 5, null, null, "In necessitatibus quos.\nIpsa minima deserunt.\nProvident quis aspernatur sunt numquam.\nOmnis modi ea optio.\nReiciendis magni ex perferendis.", 143 },
                    { 83, new DateTime(2020, 9, 26, 12, 9, 2, 376, DateTimeKind.Local).AddTicks(9012), 81, 23, new DateTime(2022, 6, 7, 21, 40, 44, 427, DateTimeKind.Local).AddTicks(7184), new DateTime(2020, 9, 11, 1, 46, 47, 633, DateTimeKind.Local).AddTicks(5056), 4, null, null, "Vel nisi odit.", 194 },
                    { 81, new DateTime(2020, 8, 29, 16, 19, 25, 985, DateTimeKind.Local).AddTicks(4057), 38, 119, new DateTime(2022, 4, 24, 7, 7, 8, 905, DateTimeKind.Local).AddTicks(7868), new DateTime(2021, 6, 24, 13, 5, 20, 771, DateTimeKind.Local).AddTicks(8416), 4, null, null, "perferendis", 155 },
                    { 1, new DateTime(2021, 2, 13, 11, 53, 36, 112, DateTimeKind.Local).AddTicks(6926), 33, 62, new DateTime(2022, 1, 8, 18, 19, 51, 62, DateTimeKind.Local).AddTicks(2007), new DateTime(2021, 7, 16, 20, 38, 35, 102, DateTimeKind.Local).AddTicks(3753), 1, null, null, "Consectetur eum mollitia quia reprehenderit et quo.\nImpedit aliquam consectetur fugit.\nIste aut voluptatem et ut quo qui voluptas.\nDolor reiciendis harum et aut autem omnis nostrum itaque ut.", 68 },
                    { 189, new DateTime(2020, 10, 8, 5, 26, 47, 792, DateTimeKind.Local).AddTicks(6266), 51, 43, new DateTime(2021, 12, 11, 12, 41, 11, 32, DateTimeKind.Local).AddTicks(7663), new DateTime(2021, 5, 30, 22, 49, 35, 607, DateTimeKind.Local).AddTicks(6621), 1, null, null, "ea", 143 },
                    { 169, new DateTime(2021, 4, 29, 23, 54, 18, 229, DateTimeKind.Local).AddTicks(6332), 51, 33, new DateTime(2022, 8, 21, 5, 44, 15, 916, DateTimeKind.Local).AddTicks(7600), new DateTime(2020, 12, 20, 18, 15, 49, 277, DateTimeKind.Local).AddTicks(8236), 3, null, null, "Eos occaecati laudantium praesentium animi recusandae id.", 96 },
                    { 120, new DateTime(2020, 10, 12, 2, 57, 34, 812, DateTimeKind.Local).AddTicks(2136), 51, 4, new DateTime(2022, 1, 9, 18, 34, 39, 737, DateTimeKind.Local).AddTicks(8941), new DateTime(2021, 3, 16, 4, 39, 22, 704, DateTimeKind.Local).AddTicks(6576), 2, null, null, "Deleniti perspiciatis inventore accusamus sit quis suscipit autem. Fugiat aliquam iusto maxime. Quibusdam suscipit minus. In ipsa ratione laudantium accusamus praesentium maiores qui. Quae aut sed.", 154 },
                    { 167, new DateTime(2020, 11, 9, 21, 53, 55, 877, DateTimeKind.Local).AddTicks(3860), 50, 44, new DateTime(2021, 10, 9, 1, 18, 24, 376, DateTimeKind.Local).AddTicks(6948), new DateTime(2021, 7, 13, 21, 33, 2, 726, DateTimeKind.Local).AddTicks(1910), 2, null, null, "Molestiae velit et.", 173 },
                    { 152, new DateTime(2020, 9, 24, 2, 0, 30, 309, DateTimeKind.Local).AddTicks(7181), 50, 79, new DateTime(2021, 10, 31, 21, 0, 10, 539, DateTimeKind.Local).AddTicks(3785), new DateTime(2021, 1, 11, 19, 18, 0, 943, DateTimeKind.Local).AddTicks(4122), 1, null, null, "provident", 162 },
                    { 140, new DateTime(2021, 4, 13, 16, 5, 8, 965, DateTimeKind.Local).AddTicks(7176), 50, 55, new DateTime(2021, 9, 20, 13, 9, 5, 851, DateTimeKind.Local).AddTicks(4160), new DateTime(2021, 6, 29, 15, 38, 25, 254, DateTimeKind.Local).AddTicks(799), 5, null, null, "Minima id mollitia voluptate sed esse ipsa ex id eum. Exercitationem sint et laudantium ad. Magnam ut eius aliquid voluptatum molestiae aliquid molestias dignissimos mollitia. Quis et vel repellendus.", 296 },
                    { 173, new DateTime(2020, 9, 21, 4, 25, 54, 805, DateTimeKind.Local).AddTicks(8480), 81, 24, new DateTime(2022, 4, 20, 4, 3, 57, 545, DateTimeKind.Local).AddTicks(9669), new DateTime(2021, 6, 22, 11, 0, 21, 943, DateTimeKind.Local).AddTicks(3111), 2, null, null, "est", 118 },
                    { 88, new DateTime(2021, 7, 4, 0, 26, 5, 400, DateTimeKind.Local).AddTicks(4672), 33, 2, new DateTime(2022, 7, 9, 16, 47, 45, 607, DateTimeKind.Local).AddTicks(4739), new DateTime(2020, 12, 11, 10, 5, 29, 445, DateTimeKind.Local).AddTicks(2772), 3, null, null, "Omnis ipsum libero et.", 73 },
                    { 40, new DateTime(2021, 8, 10, 22, 38, 55, 926, DateTimeKind.Local).AddTicks(8501), 75, 35, new DateTime(2022, 3, 3, 16, 0, 36, 76, DateTimeKind.Local).AddTicks(3921), new DateTime(2020, 8, 31, 5, 20, 0, 848, DateTimeKind.Local).AddTicks(8387), 4, null, null, "non", 76 },
                    { 175, new DateTime(2020, 11, 25, 6, 22, 6, 441, DateTimeKind.Local).AddTicks(8178), 3, 130, new DateTime(2022, 3, 29, 14, 5, 7, 52, DateTimeKind.Local).AddTicks(8490), new DateTime(2020, 10, 6, 23, 42, 12, 880, DateTimeKind.Local).AddTicks(4609), 4, null, null, "Esse fuga quisquam nam facilis. Consequatur magnam eos officiis ea. Dolores quia assumenda qui cumque veniam quaerat consequatur repellat vel. Rerum eligendi minus et incidunt sit illum tenetur quae debitis. Ea iure consectetur quia optio rerum laboriosam non. Hic amet aliquam veritatis et rerum dolores.", 96 },
                    { 26, new DateTime(2020, 11, 1, 0, 42, 21, 972, DateTimeKind.Local).AddTicks(5222), 60, 110, new DateTime(2022, 2, 3, 2, 16, 20, 269, DateTimeKind.Local).AddTicks(5262), new DateTime(2020, 12, 17, 0, 6, 27, 996, DateTimeKind.Local).AddTicks(7999), 1, null, null, "Consequuntur et minus expedita. Reiciendis omnis voluptatem molestiae itaque. Et velit aut neque. Asperiores aut optio debitis. Nulla atque facilis explicabo ea et sapiente ut porro fuga.", 41 },
                    { 139, new DateTime(2021, 5, 12, 11, 57, 23, 282, DateTimeKind.Local).AddTicks(9628), 52, 60, new DateTime(2021, 11, 19, 22, 47, 55, 681, DateTimeKind.Local).AddTicks(5302), new DateTime(2020, 12, 14, 7, 41, 41, 475, DateTimeKind.Local).AddTicks(9292), 4, null, null, "aut", 154 },
                    { 109, new DateTime(2020, 10, 10, 16, 41, 13, 86, DateTimeKind.Local).AddTicks(8196), 2, 84, new DateTime(2022, 2, 27, 20, 52, 35, 666, DateTimeKind.Local).AddTicks(2569), new DateTime(2021, 1, 1, 19, 39, 16, 25, DateTimeKind.Local).AddTicks(8245), 2, null, null, "Rerum odio nesciunt eum explicabo aperiam necessitatibus. Iusto deserunt eius quia. Ut veniam modi accusamus voluptas rerum ad quasi id sapiente.", 106 },
                    { 99, new DateTime(2021, 5, 14, 4, 10, 45, 640, DateTimeKind.Local).AddTicks(3089), 2, 94, new DateTime(2021, 10, 9, 14, 41, 35, 171, DateTimeKind.Local).AddTicks(6647), new DateTime(2020, 9, 15, 12, 13, 20, 970, DateTimeKind.Local).AddTicks(7769), 1, null, null, "aliquam", 253 },
                    { 106, new DateTime(2021, 3, 29, 2, 45, 58, 851, DateTimeKind.Local).AddTicks(4013), 62, 86, new DateTime(2022, 6, 28, 0, 5, 40, 473, DateTimeKind.Local).AddTicks(7984), new DateTime(2021, 3, 24, 22, 10, 13, 366, DateTimeKind.Local).AddTicks(5267), 2, null, null, "Illum pariatur doloribus aut qui beatae deserunt velit quis nulla.", 134 },
                    { 97, new DateTime(2020, 12, 13, 12, 24, 9, 319, DateTimeKind.Local).AddTicks(7371), 25, 142, new DateTime(2021, 11, 1, 9, 43, 29, 999, DateTimeKind.Local).AddTicks(2181), new DateTime(2021, 2, 4, 2, 5, 57, 949, DateTimeKind.Local).AddTicks(5539), 5, null, null, "Magnam modi omnis magnam ipsam provident rerum ex nesciunt qui.", 23 },
                    { 124, new DateTime(2021, 1, 14, 6, 47, 23, 556, DateTimeKind.Local).AddTicks(9662), 62, 40, new DateTime(2022, 1, 2, 8, 6, 24, 406, DateTimeKind.Local).AddTicks(916), new DateTime(2021, 5, 11, 4, 28, 34, 194, DateTimeKind.Local).AddTicks(8212), 1, null, null, "Inventore quas at optio quidem. Odit illum vero sit nihil animi in labore. Incidunt quas vel similique perspiciatis vitae exercitationem et est qui. Ut id architecto sint est et in. Molestiae aut explicabo sint aut dolor. Occaecati voluptatem eum tempore nesciunt enim dolor iusto dolorem.", 68 },
                    { 74, new DateTime(2020, 9, 15, 17, 34, 5, 433, DateTimeKind.Local).AddTicks(9313), 2, 137, new DateTime(2022, 4, 12, 14, 24, 19, 716, DateTimeKind.Local).AddTicks(2455), new DateTime(2021, 8, 5, 14, 41, 9, 320, DateTimeKind.Local).AddTicks(5050), 3, null, null, "Accusamus velit ex doloribus.", 262 },
                    { 198, new DateTime(2021, 1, 14, 16, 32, 4, 692, DateTimeKind.Local).AddTicks(6280), 21, 58, new DateTime(2022, 6, 18, 18, 19, 14, 599, DateTimeKind.Local).AddTicks(8224), new DateTime(2021, 3, 12, 18, 44, 4, 335, DateTimeKind.Local).AddTicks(4951), 2, null, null, "Minus magni porro exercitationem et rerum dolore exercitationem dicta.", 88 },
                    { 85, new DateTime(2021, 2, 8, 13, 58, 9, 101, DateTimeKind.Local).AddTicks(4499), 21, 25, new DateTime(2022, 6, 13, 9, 48, 22, 593, DateTimeKind.Local).AddTicks(5164), new DateTime(2021, 3, 5, 7, 35, 44, 654, DateTimeKind.Local).AddTicks(3784), 3, null, null, "ut", 262 },
                    { 52, new DateTime(2021, 8, 5, 1, 14, 49, 848, DateTimeKind.Local).AddTicks(2385), 67, 113, new DateTime(2022, 4, 30, 6, 13, 10, 516, DateTimeKind.Local).AddTicks(9580), new DateTime(2021, 4, 3, 4, 10, 47, 25, DateTimeKind.Local).AddTicks(6643), 3, null, null, "Vel sunt suscipit aut accusamus.\nEx est sed laudantium delectus dolorum blanditiis perferendis.", 47 },
                    { 60, new DateTime(2021, 3, 30, 17, 38, 57, 433, DateTimeKind.Local).AddTicks(852), 21, 119, new DateTime(2022, 8, 26, 3, 24, 2, 702, DateTimeKind.Local).AddTicks(1172), new DateTime(2021, 3, 23, 3, 51, 25, 218, DateTimeKind.Local).AddTicks(3333), 4, null, null, "Qui molestiae nihil dolor totam id. Quibusdam eius sint. Excepturi nam cupiditate sequi unde ab. Est repudiandae quia voluptate id dolorem est facere ea. Assumenda doloribus quisquam sint sit qui quidem magni a in. Inventore debitis error.", 150 },
                    { 86, new DateTime(2021, 5, 19, 16, 35, 15, 814, DateTimeKind.Local).AddTicks(3695), 67, 69, new DateTime(2021, 9, 14, 3, 5, 17, 429, DateTimeKind.Local).AddTicks(3489), new DateTime(2020, 10, 23, 1, 18, 58, 535, DateTimeKind.Local).AddTicks(6399), 5, null, null, "Voluptas nihil voluptatem et et omnis voluptatem.", 69 },
                    { 131, new DateTime(2021, 2, 6, 15, 56, 54, 85, DateTimeKind.Local).AddTicks(3706), 67, 105, new DateTime(2022, 2, 13, 20, 32, 51, 868, DateTimeKind.Local).AddTicks(6758), new DateTime(2021, 7, 24, 14, 45, 3, 388, DateTimeKind.Local).AddTicks(9376), 2, null, null, "Quisquam sunt eligendi alias dolore autem.\nExplicabo asperiores tenetur non vitae blanditiis consectetur hic eius.\nConsequatur modi ratione eos asperiores quia est.\nVoluptate aspernatur aut.\nSint sint praesentium voluptatem tenetur sed dolor id quis consectetur.\nAliquid repudiandae at excepturi ipsam temporibus soluta velit.", 146 },
                    { 187, new DateTime(2020, 12, 13, 14, 16, 0, 380, DateTimeKind.Local).AddTicks(7232), 67, 110, new DateTime(2021, 8, 29, 7, 18, 57, 393, DateTimeKind.Local).AddTicks(4075), new DateTime(2021, 1, 29, 16, 54, 48, 943, DateTimeKind.Local).AddTicks(2489), 5, null, null, "Dolores voluptatem porro sint fuga atque doloremque enim animi.", 156 },
                    { 157, new DateTime(2020, 10, 8, 23, 19, 14, 483, DateTimeKind.Local).AddTicks(256), 5, 117, new DateTime(2022, 3, 24, 22, 9, 54, 791, DateTimeKind.Local).AddTicks(853), new DateTime(2021, 1, 23, 5, 41, 10, 262, DateTimeKind.Local).AddTicks(1014), 3, null, null, "delectus", 97 },
                    { 56, new DateTime(2020, 12, 13, 10, 26, 32, 469, DateTimeKind.Local).AddTicks(393), 21, 58, new DateTime(2022, 2, 26, 23, 59, 58, 467, DateTimeKind.Local).AddTicks(633), new DateTime(2021, 3, 31, 2, 2, 0, 588, DateTimeKind.Local).AddTicks(5246), 2, null, null, "Voluptatem veniam ullam.\nAt quae eum maxime voluptates.\nFugiat ullam tempore.\nAspernatur suscipit tenetur et autem.\nCommodi ut aut nisi nobis.\nNumquam in beatae voluptatem molestias.", 17 },
                    { 28, new DateTime(2021, 3, 17, 20, 21, 22, 709, DateTimeKind.Local).AddTicks(7240), 21, 77, new DateTime(2022, 4, 19, 16, 45, 0, 458, DateTimeKind.Local).AddTicks(4322), new DateTime(2020, 12, 11, 1, 1, 1, 84, DateTimeKind.Local).AddTicks(7906), 3, null, null, "Sequi doloremque temporibus laudantium tenetur aut rem.\nMinus delectus vitae.", 255 },
                    { 80, new DateTime(2021, 2, 27, 23, 43, 47, 52, DateTimeKind.Local).AddTicks(618), 15, 103, new DateTime(2022, 2, 5, 13, 15, 0, 538, DateTimeKind.Local).AddTicks(705), new DateTime(2020, 9, 28, 5, 18, 55, 273, DateTimeKind.Local).AddTicks(7638), 2, null, null, "Ab voluptas quia non fugit.", 155 },
                    { 119, new DateTime(2021, 6, 25, 10, 55, 22, 20, DateTimeKind.Local).AddTicks(7334), 15, 56, new DateTime(2022, 7, 24, 15, 9, 42, 412, DateTimeKind.Local).AddTicks(6039), new DateTime(2020, 10, 8, 2, 48, 40, 970, DateTimeKind.Local).AddTicks(2991), 5, null, null, "Quae consequatur alias. Error possimus minima nesciunt. Earum quam praesentium autem et enim fugit cumque. Nesciunt enim enim. Molestiae sapiente ab aspernatur rerum illum.", 168 },
                    { 110, new DateTime(2021, 1, 24, 10, 53, 0, 659, DateTimeKind.Local).AddTicks(5269), 5, 124, new DateTime(2021, 8, 29, 18, 45, 51, 725, DateTimeKind.Local).AddTicks(5729), new DateTime(2020, 10, 21, 16, 15, 41, 1, DateTimeKind.Local).AddTicks(9214), 2, null, null, "sed", 260 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 190, new DateTime(2021, 1, 20, 15, 31, 14, 711, DateTimeKind.Local).AddTicks(5118), 36, 87, new DateTime(2021, 10, 17, 12, 30, 17, 549, DateTimeKind.Local).AddTicks(9215), new DateTime(2020, 10, 25, 16, 20, 50, 281, DateTimeKind.Local).AddTicks(3345), 5, null, null, "Minus maxime eum repellendus consequatur.\nCorporis magnam vitae.\nImpedit culpa sunt et.\nPorro modi consequatur ut harum qui consequuntur.\nConsequuntur qui doloremque enim nihil vitae eum.", 127 },
                    { 160, new DateTime(2021, 8, 8, 0, 6, 18, 840, DateTimeKind.Local).AddTicks(1317), 36, 3, new DateTime(2022, 8, 14, 3, 26, 44, 639, DateTimeKind.Local).AddTicks(4467), new DateTime(2020, 12, 23, 5, 56, 58, 832, DateTimeKind.Local).AddTicks(2782), 4, null, null, "Cum rerum et laborum perferendis incidunt consectetur nulla explicabo.\nVoluptas quia facere facere doloribus eos blanditiis eligendi voluptate.\nMaxime natus aut sed nihil saepe omnis optio aliquid recusandae.\nExcepturi maiores sit.\nDolores magnam officiis.", 28 },
                    { 103, new DateTime(2020, 10, 27, 6, 46, 55, 646, DateTimeKind.Local).AddTicks(6247), 19, 30, new DateTime(2022, 4, 9, 18, 54, 39, 279, DateTimeKind.Local).AddTicks(1375), new DateTime(2021, 4, 17, 22, 45, 44, 552, DateTimeKind.Local).AddTicks(7195), 5, null, null, "At enim nulla ad voluptatum est tempore minus.", 47 },
                    { 57, new DateTime(2020, 10, 9, 17, 51, 50, 495, DateTimeKind.Local).AddTicks(5536), 75, 86, new DateTime(2021, 9, 24, 16, 23, 24, 148, DateTimeKind.Local).AddTicks(5572), new DateTime(2021, 8, 7, 3, 46, 54, 348, DateTimeKind.Local).AddTicks(3021), 1, null, null, "Et laborum voluptatem dolorem sunt. A asperiores non voluptas quis. Totam impedit et ipsum. Libero sunt fugiat maiores nam omnis culpa magni rerum ipsum.", 256 },
                    { 158, new DateTime(2021, 6, 3, 17, 37, 50, 301, DateTimeKind.Local).AddTicks(147), 36, 131, new DateTime(2022, 8, 14, 10, 31, 18, 123, DateTimeKind.Local).AddTicks(6260), new DateTime(2020, 9, 13, 11, 56, 22, 247, DateTimeKind.Local).AddTicks(8229), 5, null, null, "Quia in est sit qui.\nQuis similique voluptas eos amet sunt nostrum.\nPraesentium tempora consequuntur mollitia dolorem adipisci.\nTenetur blanditiis pariatur nihil qui maiores cupiditate.\nEa dolor esse cupiditate dolor dolor.", 101 },
                    { 114, new DateTime(2020, 11, 14, 23, 43, 5, 645, DateTimeKind.Local).AddTicks(5009), 36, 64, new DateTime(2022, 3, 26, 16, 49, 53, 108, DateTimeKind.Local).AddTicks(7160), new DateTime(2021, 2, 18, 11, 43, 40, 77, DateTimeKind.Local).AddTicks(2821), 5, null, null, "Distinctio ratione quia ipsum corporis eligendi culpa aut rerum ipsam. Placeat non illo labore excepturi. Non qui quaerat eos eos sunt placeat modi. Vel inventore sed accusamus repudiandae eum quaerat dolor aut. Sint esse qui aut neque similique molestiae laboriosam doloribus repellat. Sed debitis modi id iste quis excepturi.", 278 },
                    { 24, new DateTime(2020, 12, 25, 18, 52, 19, 420, DateTimeKind.Local).AddTicks(984), 5, 43, new DateTime(2022, 3, 31, 4, 21, 26, 495, DateTimeKind.Local).AddTicks(2122), new DateTime(2020, 10, 30, 20, 38, 3, 382, DateTimeKind.Local).AddTicks(3544), 3, null, null, "A eius vitae.", 26 },
                    { 138, new DateTime(2021, 1, 25, 16, 17, 42, 143, DateTimeKind.Local).AddTicks(6854), 26, 112, new DateTime(2022, 8, 14, 23, 20, 20, 99, DateTimeKind.Local).AddTicks(4189), new DateTime(2021, 8, 21, 5, 12, 12, 447, DateTimeKind.Local).AddTicks(7173), 4, null, null, "Blanditiis et ratione.\nEt ut veniam excepturi mollitia assumenda explicabo ut aut.", 246 },
                    { 35, new DateTime(2020, 9, 6, 17, 6, 49, 124, DateTimeKind.Local).AddTicks(3968), 36, 134, new DateTime(2022, 3, 1, 19, 20, 5, 10, DateTimeKind.Local).AddTicks(9476), new DateTime(2021, 1, 4, 13, 36, 32, 823, DateTimeKind.Local).AddTicks(802), 4, null, null, "Officiis illum quibusdam aut rerum eum autem qui aliquid in.", 145 },
                    { 21, new DateTime(2020, 11, 4, 18, 43, 56, 688, DateTimeKind.Local).AddTicks(9610), 52, 138, new DateTime(2021, 8, 28, 3, 32, 9, 2, DateTimeKind.Local).AddTicks(8159), new DateTime(2021, 1, 13, 23, 1, 39, 228, DateTimeKind.Local).AddTicks(7178), 5, null, null, "Ut quia eaque.\nHic atque maiores.", 118 },
                    { 155, new DateTime(2021, 1, 25, 12, 3, 3, 301, DateTimeKind.Local).AddTicks(9834), 26, 56, new DateTime(2022, 5, 23, 18, 12, 17, 510, DateTimeKind.Local).AddTicks(6994), new DateTime(2021, 5, 3, 12, 35, 25, 722, DateTimeKind.Local).AddTicks(5111), 5, null, null, "Sapiente pariatur quo quo mollitia maiores officia vitae. Ipsam optio eveniet voluptatum. Velit velit velit accusamus eos. Quos voluptas fuga nemo. Delectus nihil est et sequi.", 88 },
                    { 142, new DateTime(2020, 12, 24, 16, 39, 59, 851, DateTimeKind.Local).AddTicks(8095), 2, 148, new DateTime(2022, 6, 21, 1, 25, 39, 253, DateTimeKind.Local).AddTicks(4377), new DateTime(2020, 11, 2, 16, 32, 13, 493, DateTimeKind.Local).AddTicks(4075), 3, null, null, "eveniet", 24 },
                    { 128, new DateTime(2021, 6, 25, 6, 27, 6, 995, DateTimeKind.Local).AddTicks(9811), 64, 94, new DateTime(2021, 10, 6, 11, 19, 19, 917, DateTimeKind.Local).AddTicks(3486), new DateTime(2021, 6, 6, 2, 31, 42, 49, DateTimeKind.Local).AddTicks(5776), 5, null, null, "a", 97 },
                    { 148, new DateTime(2021, 8, 24, 12, 22, 52, 23, DateTimeKind.Local).AddTicks(9264), 60, 53, new DateTime(2022, 6, 8, 2, 42, 6, 185, DateTimeKind.Local).AddTicks(9230), new DateTime(2021, 5, 10, 3, 45, 32, 142, DateTimeKind.Local).AddTicks(2663), 1, null, null, "Accusamus animi saepe et optio saepe.", 26 },
                    { 49, new DateTime(2020, 11, 1, 17, 1, 3, 832, DateTimeKind.Local).AddTicks(5202), 7, 107, new DateTime(2022, 3, 30, 16, 32, 2, 983, DateTimeKind.Local).AddTicks(2651), new DateTime(2020, 9, 29, 3, 24, 30, 888, DateTimeKind.Local).AddTicks(4634), 4, null, null, "Quia rerum iure et quidem dicta. Vero porro quibusdam consequuntur sapiente quia. Qui et doloribus.", 3 },
                    { 15, new DateTime(2020, 11, 13, 1, 43, 6, 943, DateTimeKind.Local).AddTicks(4520), 71, 142, new DateTime(2022, 3, 27, 15, 37, 25, 996, DateTimeKind.Local).AddTicks(7198), new DateTime(2021, 5, 15, 16, 0, 2, 602, DateTimeKind.Local).AddTicks(5976), 2, null, null, "Nesciunt nobis cupiditate quo.", 100 },
                    { 58, new DateTime(2021, 6, 9, 5, 7, 25, 650, DateTimeKind.Local).AddTicks(7387), 71, 119, new DateTime(2022, 8, 6, 9, 36, 30, 769, DateTimeKind.Local).AddTicks(7359), new DateTime(2021, 2, 25, 23, 4, 31, 218, DateTimeKind.Local).AddTicks(8868), 2, null, null, "Sapiente dolor aut et aliquam ea accusamus qui.", 168 },
                    { 6, new DateTime(2021, 2, 6, 16, 44, 6, 145, DateTimeKind.Local).AddTicks(9439), 65, 130, new DateTime(2022, 7, 21, 13, 10, 26, 311, DateTimeKind.Local).AddTicks(4337), new DateTime(2021, 4, 15, 20, 55, 24, 797, DateTimeKind.Local).AddTicks(9820), 2, null, null, "Vel dolorem alias rerum ut rerum quae et.", 245 },
                    { 41, new DateTime(2021, 8, 9, 8, 59, 42, 402, DateTimeKind.Local).AddTicks(5417), 65, 75, new DateTime(2021, 9, 19, 11, 11, 57, 515, DateTimeKind.Local).AddTicks(5332), new DateTime(2020, 10, 1, 19, 6, 10, 148, DateTimeKind.Local).AddTicks(8248), 5, null, null, "suscipit", 3 },
                    { 64, new DateTime(2021, 1, 15, 13, 49, 36, 358, DateTimeKind.Local).AddTicks(7838), 74, 108, new DateTime(2022, 7, 31, 16, 41, 22, 538, DateTimeKind.Local).AddTicks(6991), new DateTime(2021, 3, 22, 5, 49, 55, 959, DateTimeKind.Local).AddTicks(9811), 5, null, null, "Sint qui voluptatem laudantium et minima aspernatur dolorem.\nVoluptatem similique et.\nPlaceat quia cumque et quos aliquid.\nVel aspernatur consequatur itaque et et.", 99 },
                    { 37, new DateTime(2020, 12, 12, 19, 16, 56, 387, DateTimeKind.Local).AddTicks(4854), 7, 73, new DateTime(2022, 6, 16, 3, 1, 21, 168, DateTimeKind.Local).AddTicks(9708), new DateTime(2020, 11, 21, 10, 8, 4, 74, DateTimeKind.Local).AddTicks(5276), 1, null, null, "magni", 100 },
                    { 27, new DateTime(2021, 4, 13, 14, 38, 29, 792, DateTimeKind.Local).AddTicks(5573), 7, 139, new DateTime(2022, 2, 14, 17, 16, 28, 841, DateTimeKind.Local).AddTicks(5732), new DateTime(2021, 8, 17, 1, 49, 58, 346, DateTimeKind.Local).AddTicks(9341), 3, null, null, "Eum eligendi a quos veritatis et. Consequatur quaerat dolore iste. Qui aliquid veniam. Dicta error eveniet commodi vel dicta. Enim ea perspiciatis voluptas.", 20 },
                    { 22, new DateTime(2021, 2, 26, 3, 2, 51, 4, DateTimeKind.Local).AddTicks(9754), 30, 142, new DateTime(2021, 12, 13, 1, 35, 23, 23, DateTimeKind.Local).AddTicks(3842), new DateTime(2021, 2, 8, 11, 42, 58, 565, DateTimeKind.Local).AddTicks(3934), 1, null, null, "Eaque voluptatem alias voluptate sit repellendus culpa praesentium quia expedita. Quaerat eos doloribus et aut nihil ea voluptatem quis. Sint et et alias aut similique vitae sit vel.", 23 },
                    { 134, new DateTime(2020, 9, 4, 1, 51, 32, 538, DateTimeKind.Local).AddTicks(5635), 30, 27, new DateTime(2021, 11, 4, 21, 53, 16, 215, DateTimeKind.Local).AddTicks(2194), new DateTime(2020, 10, 29, 9, 20, 27, 685, DateTimeKind.Local).AddTicks(1784), 4, null, null, "Et sint vel necessitatibus pariatur ea voluptatibus.", 136 },
                    { 191, new DateTime(2020, 10, 18, 16, 38, 37, 695, DateTimeKind.Local).AddTicks(1527), 30, 60, new DateTime(2022, 6, 7, 10, 27, 18, 598, DateTimeKind.Local).AddTicks(7690), new DateTime(2020, 11, 23, 6, 58, 0, 829, DateTimeKind.Local).AddTicks(968), 1, null, null, "Qui eum aut impedit hic est nemo libero.", 232 },
                    { 161, new DateTime(2020, 12, 22, 18, 13, 49, 217, DateTimeKind.Local).AddTicks(255), 60, 88, new DateTime(2022, 7, 17, 9, 44, 58, 713, DateTimeKind.Local).AddTicks(3725), new DateTime(2020, 10, 20, 13, 27, 59, 714, DateTimeKind.Local).AddTicks(228), 1, null, null, "Nihil repellendus fugiat quas et. Voluptatem sed possimus voluptas consectetur quia cum quos dolores. Assumenda magnam dolores minus.", 179 },
                    { 94, new DateTime(2021, 6, 14, 9, 42, 21, 283, DateTimeKind.Local).AddTicks(9717), 77, 21, new DateTime(2022, 8, 17, 21, 35, 9, 861, DateTimeKind.Local).AddTicks(5919), new DateTime(2020, 9, 19, 11, 14, 40, 683, DateTimeKind.Local).AddTicks(8643), 3, null, null, "Autem repudiandae occaecati suscipit cumque voluptatem minus.", 97 },
                    { 141, new DateTime(2021, 1, 1, 15, 47, 2, 897, DateTimeKind.Local).AddTicks(1525), 66, 27, new DateTime(2022, 2, 12, 17, 32, 45, 105, DateTimeKind.Local).AddTicks(6071), new DateTime(2021, 3, 18, 21, 15, 1, 952, DateTimeKind.Local).AddTicks(6849), 5, null, null, "Tenetur et magnam quo alias amet nemo recusandae aliquam.", 168 },
                    { 69, new DateTime(2020, 11, 19, 10, 0, 36, 763, DateTimeKind.Local).AddTicks(5237), 1, 75, new DateTime(2021, 10, 4, 22, 46, 15, 273, DateTimeKind.Local).AddTicks(2576), new DateTime(2021, 8, 21, 19, 10, 43, 799, DateTimeKind.Local).AddTicks(5569), 2, null, null, "Excepturi exercitationem molestias ipsum.", 24 },
                    { 104, new DateTime(2021, 5, 8, 0, 18, 19, 985, DateTimeKind.Local).AddTicks(3002), 1, 27, new DateTime(2021, 9, 27, 5, 21, 44, 194, DateTimeKind.Local).AddTicks(5983), new DateTime(2021, 1, 2, 18, 9, 12, 838, DateTimeKind.Local).AddTicks(4712), 4, null, null, "Dolorem ea et ut dolor fugiat in tempora.\nExcepturi ea repudiandae.\nQuidem veniam cupiditate.\nRepudiandae iusto est.\nEt voluptatem atque.\nEx sunt voluptas et eaque.", 256 },
                    { 48, new DateTime(2021, 2, 2, 12, 49, 20, 297, DateTimeKind.Local).AddTicks(7953), 64, 84, new DateTime(2022, 7, 2, 20, 43, 18, 847, DateTimeKind.Local).AddTicks(399), new DateTime(2021, 8, 2, 20, 33, 6, 653, DateTimeKind.Local).AddTicks(7385), 4, null, null, "soluta", 278 },
                    { 51, new DateTime(2020, 11, 8, 19, 58, 25, 872, DateTimeKind.Local).AddTicks(4399), 17, 65, new DateTime(2022, 7, 18, 20, 23, 33, 77, DateTimeKind.Local).AddTicks(7472), new DateTime(2020, 9, 18, 5, 24, 57, 647, DateTimeKind.Local).AddTicks(4090), 5, null, null, "Cupiditate nemo voluptas sit iste id maxime placeat aut officiis.", 222 },
                    { 107, new DateTime(2021, 1, 25, 5, 6, 30, 298, DateTimeKind.Local).AddTicks(1849), 17, 14, new DateTime(2022, 4, 27, 19, 46, 35, 556, DateTimeKind.Local).AddTicks(9969), new DateTime(2020, 9, 15, 1, 0, 45, 9, DateTimeKind.Local).AddTicks(9843), 4, null, null, "Facere ducimus et.", 100 },
                    { 179, new DateTime(2021, 5, 19, 7, 24, 47, 791, DateTimeKind.Local).AddTicks(1279), 17, 117, new DateTime(2021, 11, 12, 6, 56, 16, 245, DateTimeKind.Local).AddTicks(2343), new DateTime(2021, 2, 11, 10, 37, 45, 381, DateTimeKind.Local).AddTicks(2852), 2, null, null, "nam", 106 },
                    { 199, new DateTime(2021, 8, 12, 20, 30, 41, 695, DateTimeKind.Local).AddTicks(8631), 17, 48, new DateTime(2021, 11, 22, 2, 51, 4, 462, DateTimeKind.Local).AddTicks(5703), new DateTime(2021, 2, 20, 7, 12, 48, 222, DateTimeKind.Local).AddTicks(2987), 1, null, null, "Facere consequatur qui facilis quia impedit atque voluptatem.", 168 },
                    { 54, new DateTime(2021, 2, 5, 15, 3, 43, 611, DateTimeKind.Local).AddTicks(2236), 66, 76, new DateTime(2022, 4, 17, 5, 5, 15, 607, DateTimeKind.Local).AddTicks(9489), new DateTime(2020, 12, 1, 22, 40, 52, 863, DateTimeKind.Local).AddTicks(8692), 3, null, null, "Nihil saepe est quis aut quasi quia et ut.\nIste voluptas odio quos fuga.\nDucimus quis et in provident quia.", 203 },
                    { 4, new DateTime(2021, 1, 27, 5, 13, 17, 913, DateTimeKind.Local).AddTicks(6287), 66, 105, new DateTime(2021, 10, 18, 13, 34, 56, 820, DateTimeKind.Local).AddTicks(724), new DateTime(2020, 9, 29, 16, 35, 25, 505, DateTimeKind.Local).AddTicks(5773), 3, null, null, "commodi", 20 },
                    { 193, new DateTime(2021, 6, 18, 2, 30, 23, 14, DateTimeKind.Local).AddTicks(6468), 24, 122, new DateTime(2021, 11, 16, 7, 15, 31, 604, DateTimeKind.Local).AddTicks(7412), new DateTime(2021, 1, 5, 20, 26, 49, 218, DateTimeKind.Local).AddTicks(8965), 2, null, null, "Maxime temporibus illo.", 122 },
                    { 122, new DateTime(2021, 1, 21, 20, 35, 9, 502, DateTimeKind.Local).AddTicks(2079), 41, 38, new DateTime(2022, 1, 6, 14, 12, 47, 120, DateTimeKind.Local).AddTicks(5059), new DateTime(2020, 10, 8, 17, 21, 37, 841, DateTimeKind.Local).AddTicks(1878), 5, null, null, "Et cumque provident perferendis tempore.", 83 },
                    { 78, new DateTime(2020, 12, 18, 4, 8, 24, 848, DateTimeKind.Local).AddTicks(5878), 64, 133, new DateTime(2022, 2, 16, 4, 36, 13, 171, DateTimeKind.Local).AddTicks(2672), new DateTime(2021, 7, 27, 17, 12, 14, 217, DateTimeKind.Local).AddTicks(4612), 5, null, null, "Ea dignissimos perspiciatis deleniti aut officia neque explicabo est nemo. Unde ea reiciendis vel laborum qui autem cumque modi quidem. Adipisci et omnis. Dolor sunt commodi. Accusantium excepturi quia aliquid eos.", 236 },
                    { 144, new DateTime(2021, 1, 22, 4, 45, 27, 124, DateTimeKind.Local).AddTicks(2963), 41, 98, new DateTime(2022, 3, 9, 18, 30, 58, 43, DateTimeKind.Local).AddTicks(719), new DateTime(2021, 2, 8, 9, 49, 15, 389, DateTimeKind.Local).AddTicks(7894), 3, null, null, "Qui est reprehenderit esse.\nOccaecati et sunt facilis nesciunt est est.", 73 },
                    { 166, new DateTime(2020, 9, 4, 9, 30, 33, 728, DateTimeKind.Local).AddTicks(8927), 41, 40, new DateTime(2022, 3, 4, 20, 57, 55, 65, DateTimeKind.Local).AddTicks(3891), new DateTime(2020, 12, 23, 9, 56, 35, 231, DateTimeKind.Local).AddTicks(3894), 2, null, null, "facilis", 69 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 171, new DateTime(2021, 4, 25, 9, 47, 48, 602, DateTimeKind.Local).AddTicks(6258), 2, 119, new DateTime(2022, 6, 23, 11, 0, 47, 483, DateTimeKind.Local).AddTicks(43), new DateTime(2021, 7, 19, 19, 58, 17, 508, DateTimeKind.Local).AddTicks(7762), 5, null, null, "Nostrum a quos corporis consequatur quia mollitia enim deleniti maiores.", 295 },
                    { 162, new DateTime(2020, 10, 14, 13, 41, 31, 991, DateTimeKind.Local).AddTicks(3571), 26, 45, new DateTime(2022, 5, 26, 22, 24, 44, 884, DateTimeKind.Local).AddTicks(3457), new DateTime(2021, 2, 21, 14, 28, 6, 985, DateTimeKind.Local).AddTicks(6555), 3, null, null, "Accusamus laborum voluptas nostrum enim error.\nSunt enim tempora.\nA vel et nobis recusandae alias rem cupiditate rerum tempore.\nCum reprehenderit culpa sunt ut dolore.", 188 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "CarId", "UserId" },
                values: new object[,]
                {
                    { 9, 143 },
                    { 81, 83 },
                    { 36, 229 },
                    { 43, 96 },
                    { 2, 24 },
                    { 55, 232 },
                    { 53, 171 },
                    { 37, 246 },
                    { 66, 8 },
                    { 47, 69 },
                    { 20, 259 },
                    { 18, 183 },
                    { 69, 171 },
                    { 77, 17 },
                    { 35, 79 },
                    { 40, 162 },
                    { 49, 96 },
                    { 41, 72 },
                    { 63, 83 },
                    { 32, 255 },
                    { 17, 167 },
                    { 68, 195 },
                    { 30, 102 },
                    { 72, 129 },
                    { 7, 170 },
                    { 74, 195 },
                    { 76, 18 },
                    { 75, 286 },
                    { 58, 255 },
                    { 52, 207 },
                    { 42, 179 },
                    { 39, 261 },
                    { 62, 70 },
                    { 38, 40 },
                    { 5, 78 },
                    { 61, 23 },
                    { 26, 248 },
                    { 79, 226 },
                    { 19, 226 },
                    { 27, 69 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "CarId", "UserId" },
                values: new object[,]
                {
                    { 33, 6 },
                    { 46, 191 },
                    { 80, 27 },
                    { 15, 296 },
                    { 67, 226 },
                    { 23, 72 },
                    { 6, 99 },
                    { 44, 133 },
                    { 34, 194 },
                    { 28, 66 },
                    { 24, 73 }
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
