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
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCars_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        onDelete: ReferentialAction.Restrict);
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
                    { 1, "Indonesia" },
                    { 115, "Kuwait" },
                    { 117, "Liechtenstein" },
                    { 118, "Uganda" },
                    { 120, "Ecuador" },
                    { 121, "Barbados" },
                    { 123, "Latvia" },
                    { 112, "Belize" },
                    { 124, "Svalbard & Jan Mayen Islands" },
                    { 127, "Swaziland" },
                    { 129, "Honduras" },
                    { 130, "Argentina" },
                    { 132, "New Zealand" },
                    { 133, "Iceland" },
                    { 134, "Niue" },
                    { 125, "Ukraine" },
                    { 136, "Mozambique" },
                    { 110, "Albania" },
                    { 105, "Bahamas" },
                    { 83, "Palestinian Territory" },
                    { 84, "Heard Island and McDonald Islands" },
                    { 85, "Haiti" },
                    { 87, "Vietnam" },
                    { 88, "Saudi Arabia" },
                    { 90, "Philippines" },
                    { 107, "San Marino" },
                    { 93, "Brunei Darussalam" },
                    { 95, "Solomon Islands" },
                    { 96, "Mauritania" },
                    { 98, "United States of America" },
                    { 101, "Saint Barthelemy" },
                    { 102, "Faroe Islands" },
                    { 104, "Brazil" },
                    { 94, "Sierra Leone" },
                    { 137, "Eritrea" },
                    { 139, "Georgia" },
                    { 141, "Puerto Rico" },
                    { 171, "Christmas Island" },
                    { 172, "United States Minor Outlying Islands" },
                    { 173, "Namibia" },
                    { 175, "Malawi" },
                    { 177, "Luxembourg" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 178, "Anguilla" },
                    { 170, "Syrian Arab Republic" },
                    { 181, "China" },
                    { 187, "Peru" },
                    { 191, "Slovenia" },
                    { 192, "Maldives" },
                    { 195, "Guernsey" },
                    { 197, "Singapore" },
                    { 198, "Netherlands" },
                    { 184, "Andorra" },
                    { 169, "Rwanda" },
                    { 167, "Panama" },
                    { 166, "Fiji" },
                    { 142, "Paraguay" },
                    { 143, "Cocos (Keeling) Islands" },
                    { 144, "Kiribati" },
                    { 148, "Tonga" },
                    { 149, "Gibraltar" },
                    { 150, "Guyana" },
                    { 151, "Australia" },
                    { 152, "Aruba" },
                    { 153, "United Kingdom" },
                    { 154, "Mayotte" },
                    { 155, "Myanmar" },
                    { 157, "Serbia" },
                    { 161, "Belarus" },
                    { 162, "Lithuania" },
                    { 163, "Timor-Leste" },
                    { 82, "Sudan" },
                    { 81, "Thailand" },
                    { 86, "Liberia" },
                    { 79, "Greece" },
                    { 23, "Sao Tome and Principe" },
                    { 24, "Azerbaijan" },
                    { 25, "Republic of Korea" },
                    { 26, "Botswana" },
                    { 27, "Virgin Islands, U.S." },
                    { 28, "Uzbekistan" },
                    { 22, "Tunisia" },
                    { 29, "Japan" },
                    { 31, "Guadeloupe" },
                    { 32, "Jordan" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 80, "Djibouti" },
                    { 36, "Macedonia" },
                    { 37, "Spain" },
                    { 38, "Montenegro" },
                    { 30, "French Guiana" },
                    { 20, "Grenada" },
                    { 19, "Gambia" },
                    { 18, "Cyprus" },
                    { 2, "Belgium" },
                    { 3, "Kazakhstan" },
                    { 4, "United Arab Emirates" },
                    { 5, "Democratic People's Republic of Korea" },
                    { 6, "Estonia" },
                    { 7, "Cambodia" },
                    { 8, "Saint Kitts and Nevis" },
                    { 9, "Palau" },
                    { 10, "Benin" },
                    { 11, "Lesotho" },
                    { 13, "India" },
                    { 14, "Saint Martin" },
                    { 15, "Pakistan" },
                    { 16, "South Georgia and the South Sandwich Islands" },
                    { 17, "Micronesia" },
                    { 39, "Cape Verde" },
                    { 40, "Bosnia and Herzegovina" },
                    { 35, "Costa Rica" },
                    { 42, "Finland" },
                    { 63, "Gabon" },
                    { 64, "Holy See (Vatican City State)" },
                    { 66, "Armenia" },
                    { 41, "Saint Helena" },
                    { 68, "Uruguay" },
                    { 69, "Martinique" },
                    { 62, "Colombia" },
                    { 70, "Cameroon" },
                    { 72, "Wallis and Futuna" },
                    { 73, "Bahrain" },
                    { 74, "Cook Islands" },
                    { 75, "Montserrat" },
                    { 77, "Moldova" },
                    { 78, "Cuba" },
                    { 71, "Zimbabwe" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 61, "France" },
                    { 67, "Lebanon" },
                    { 58, "Hungary" },
                    { 43, "Ghana" },
                    { 44, "Mauritius" },
                    { 60, "Guatemala" },
                    { 46, "Denmark" },
                    { 47, "Czech Republic" },
                    { 48, "Bulgaria" },
                    { 49, "Ethiopia" },
                    { 45, "Reunion" },
                    { 52, "Suriname" },
                    { 53, "Kyrgyz Republic" },
                    { 54, "Comoros" },
                    { 55, "Western Sahara" },
                    { 56, "Libyan Arab Jamahiriya" },
                    { 57, "French Southern Territories" },
                    { 51, "Turks and Caicos Islands" }
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
                    { 161, 1, "North Cordieburgh" },
                    { 170, 101, "North Ettie" },
                    { 129, 101, "Doylefurt" },
                    { 119, 101, "Volkmanland" },
                    { 284, 98, "Ritchiestad" },
                    { 171, 98, "South Merlin" },
                    { 270, 96, "East Priscillaview" },
                    { 253, 95, "New Lillie" },
                    { 128, 95, "North Terence" },
                    { 63, 95, "Port Gladycemouth" },
                    { 182, 94, "West Jeradstad" },
                    { 8, 94, "Shemarmouth" },
                    { 249, 93, "Conroychester" },
                    { 117, 93, "North Clementview" },
                    { 277, 88, "Port Hailiechester" },
                    { 143, 88, "Port Percivalshire" },
                    { 130, 88, "Pollichberg" },
                    { 96, 87, "Vidaborough" },
                    { 83, 102, "Lake Autumnstad" },
                    { 66, 86, "Aleneton" },
                    { 112, 102, "West Zachery" },
                    { 230, 102, "West Magdalena" },
                    { 269, 118, "West Laurenview" },
                    { 85, 118, "West Nola" },
                    { 287, 117, "West Eleazar" },
                    { 255, 117, "Hiltonport" },
                    { 21, 117, "Richardland" },
                    { 209, 115, "Raynorland" },
                    { 111, 115, "Jewelburgh" },
                    { 141, 112, "New Maudfurt" },
                    { 15, 112, "South Julia" },
                    { 6, 112, "West Ana" },
                    { 299, 110, "West Destin" },
                    { 115, 110, "Port Jonatanstad" },
                    { 101, 110, "Lake Randy" },
                    { 275, 107, "Dachchester" },
                    { 267, 107, "South Lydafurt" },
                    { 231, 105, "Ilaview" },
                    { 189, 104, "Wardhaven" },
                    { 192, 102, "Vicentechester" },
                    { 25, 86, "Hillsside" },
                    { 229, 85, "North Fredburgh" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 207, 85, "New Camilabury" },
                    { 131, 71, "New Ryan" },
                    { 60, 71, "Baumbachville" },
                    { 150, 70, "Port Mavis" },
                    { 87, 70, "Catalinafurt" },
                    { 114, 69, "West Guido" },
                    { 29, 69, "North Randalton" },
                    { 144, 68, "Gardnermouth" },
                    { 46, 68, "South Lisettestad" },
                    { 42, 68, "West Ramon" },
                    { 13, 68, "Trentton" },
                    { 73, 67, "Sydnieview" },
                    { 65, 67, "Lake Alexanderburgh" },
                    { 167, 66, "Adamsland" },
                    { 244, 64, "Sanfordburgh" },
                    { 298, 63, "Kodyfort" },
                    { 289, 63, "New Gloria" },
                    { 272, 63, "Mayertside" },
                    { 254, 71, "Zemlakfort" },
                    { 258, 71, "Lake Rashad" },
                    { 95, 72, "South Austenmouth" },
                    { 71, 73, "New Sophia" },
                    { 187, 83, "Littleview" },
                    { 39, 83, "North Deontaemouth" },
                    { 38, 83, "Rowenaport" },
                    { 283, 81, "Mayertmouth" },
                    { 163, 81, "Turcottehaven" },
                    { 127, 81, "Jeniferburgh" },
                    { 177, 78, "Port Hiltonburgh" },
                    { 156, 78, "Dellburgh" },
                    { 35, 121, "South Hershel" },
                    { 136, 78, "Nicoleshire" },
                    { 9, 77, "East Phyllis" },
                    { 92, 75, "Domenicaport" },
                    { 178, 74, "North Salliehaven" },
                    { 108, 74, "South Justen" },
                    { 77, 74, "Lake Adelineberg" },
                    { 1, 74, "Port Carol" },
                    { 290, 73, "East Clintberg" },
                    { 135, 73, "Torpfort" },
                    { 190, 77, "North Xzavier" },
                    { 142, 121, "West Carsonstad" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 273, 121, "Creminmouth" },
                    { 20, 123, "Elvashire" },
                    { 213, 172, "Port Danykamouth" },
                    { 237, 171, "Port Alessandra" },
                    { 216, 171, "Port Orval" },
                    { 205, 171, "Laceyton" },
                    { 228, 170, "East Fae" },
                    { 102, 170, "East Vernaside" },
                    { 90, 170, "West Tianaside" },
                    { 72, 170, "East Flavie" },
                    { 164, 169, "North Medaview" },
                    { 41, 169, "West Blanche" },
                    { 295, 167, "Port Marilyneview" },
                    { 82, 167, "North Devynberg" },
                    { 184, 166, "New Kaydenmouth" },
                    { 175, 166, "Martineville" },
                    { 118, 163, "Kemmertown" },
                    { 61, 163, "New Jaquelinfort" },
                    { 50, 163, "Welchfurt" },
                    { 140, 173, "Leuschkeville" },
                    { 174, 173, "Boylefort" },
                    { 54, 175, "Dinachester" },
                    { 210, 175, "New Emmanuel" },
                    { 271, 198, "Ortizburgh" },
                    { 252, 198, "West Jett" },
                    { 100, 198, "Port Chesleyshire" },
                    { 94, 198, "Nolanhaven" },
                    { 162, 197, "South Christa" },
                    { 67, 195, "Ziemannfurt" },
                    { 256, 192, "Port Jeremybury" },
                    { 78, 192, "East Osvaldofort" },
                    { 14, 163, "McGlynnstad" },
                    { 44, 191, "Borerland" },
                    { 45, 187, "New Giovanistad" },
                    { 261, 184, "Maggioside" },
                    { 195, 181, "Torreyport" },
                    { 89, 181, "Rosatown" },
                    { 173, 178, "Ozellaborough" },
                    { 225, 177, "Port Hollie" },
                    { 285, 175, "Marcelobury" },
                    { 260, 175, "Rempelmouth" },
                    { 36, 191, "Hildamouth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 239, 63, "West Billiefort" },
                    { 4, 163, "North Kianna" },
                    { 243, 162, "Bartellshire" },
                    { 19, 139, "Fridatown" },
                    { 222, 137, "North Delmer" },
                    { 185, 137, "West Maeve" },
                    { 166, 137, "North Jerodton" },
                    { 104, 137, "Lake Napoleonmouth" },
                    { 56, 137, "Toymouth" },
                    { 157, 136, "West Kaelyn" },
                    { 235, 134, "Elisabethfurt" },
                    { 218, 134, "West Walker" },
                    { 268, 133, "Prosaccoshire" },
                    { 99, 133, "Rogahntown" },
                    { 68, 133, "Braunfurt" },
                    { 250, 129, "New Rex" },
                    { 124, 129, "Faeshire" },
                    { 257, 127, "Virgilland" },
                    { 201, 125, "New Nataliefurt" },
                    { 125, 124, "Port Harveychester" },
                    { 98, 141, "North Jarvishaven" },
                    { 106, 142, "Grantberg" },
                    { 145, 143, "Heloisehaven" },
                    { 52, 144, "West Kaydenview" },
                    { 202, 162, "Hellermouth" },
                    { 47, 162, "Koelpinchester" },
                    { 5, 161, "Allystad" },
                    { 240, 155, "Normaton" },
                    { 206, 155, "East Filomena" },
                    { 172, 154, "Eltafort" },
                    { 153, 154, "Jettburgh" },
                    { 151, 154, "West Gabrielville" },
                    { 264, 162, "South Khalilmouth" },
                    { 280, 152, "Jewelmouth" },
                    { 40, 151, "Hannahberg" },
                    { 266, 150, "Port Sonia" },
                    { 259, 150, "West Carley" },
                    { 241, 150, "Lake Aileenmouth" },
                    { 214, 150, "Kovacekbury" },
                    { 74, 149, "Ebertside" },
                    { 24, 148, "East Dustyfort" },
                    { 116, 144, "Wisozkchester" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 200, 152, "Raymondfort" },
                    { 126, 63, "Allyberg" },
                    { 155, 90, "North Petra" },
                    { 57, 63, "Goyettefort" },
                    { 110, 30, "East Ashley" },
                    { 62, 30, "Port Casper" },
                    { 28, 30, "Wardborough" },
                    { 198, 29, "Janickbury" },
                    { 139, 29, "East Gerardtown" },
                    { 242, 28, "Garthton" },
                    { 132, 28, "Hermistonmouth" },
                    { 274, 27, "Abigailland" },
                    { 232, 27, "North Jermain" },
                    { 75, 27, "Roobton" },
                    { 32, 27, "Howellton" },
                    { 204, 1, "New Joanne" },
                    { 80, 63, "Loymouth" },
                    { 292, 26, "Greenfelderview" },
                    { 179, 26, "Bartellbury" },
                    { 48, 26, "South Martyland" },
                    { 34, 2, "Lake Jailynberg" },
                    { 165, 30, "West Sophie" },
                    { 212, 30, "Torphyhaven" },
                    { 107, 31, "Port Hayleeburgh" },
                    { 169, 31, "East Bernadinebury" },
                    { 43, 40, "Port Wardborough" },
                    { 64, 39, "West Gerardo" },
                    { 160, 38, "Aftonton" },
                    { 12, 38, "Wuckertport" },
                    { 236, 37, "Mallieville" },
                    { 159, 37, "Lake Mylenetown" },
                    { 88, 9, "Queeniemouth" },
                    { 105, 36, "Fritschport" },
                    { 123, 2, "New Kurtis" },
                    { 103, 36, "Heidenreichview" },
                    { 245, 35, "North Jameyburgh" },
                    { 199, 35, "South Maverick" },
                    { 193, 35, "Lake Reva" },
                    { 224, 32, "Tryciabury" },
                    { 149, 32, "Lake Albin" },
                    { 146, 32, "East Benton" },
                    { 16, 32, "Lake Madisonfurt" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 297, 31, "East Hobartview" },
                    { 97, 36, "Langworthmouth" },
                    { 93, 40, "Elnashire" },
                    { 23, 26, "West Shanie" },
                    { 286, 2, "Lake Colthaven" },
                    { 84, 16, "New Catalina" },
                    { 31, 16, "Harrisfurt" },
                    { 11, 7, "Schummside" },
                    { 17, 15, "North Billyborough" },
                    { 291, 7, "Lake Kobyfurt" },
                    { 282, 14, "West Werner" },
                    { 194, 14, "Port Lillian" },
                    { 79, 14, "Port Brendenstad" },
                    { 69, 8, "North Thea" },
                    { 120, 8, "Herbertchester" },
                    { 188, 13, "South Salvador" },
                    { 296, 8, "North Carlimouth" },
                    { 22, 11, "Millsside" },
                    { 81, 9, "New Deondrefort" },
                    { 176, 10, "North Godfrey" },
                    { 33, 10, "O'Connellside" },
                    { 18, 10, "New Joyceberg" },
                    { 180, 6, "New Elsiemouth" },
                    { 55, 17, "Willmsburgh" },
                    { 278, 17, "South Rosebury" },
                    { 152, 18, "Lake Alivia" },
                    { 227, 3, "Port Rethastad" },
                    { 263, 23, "Port Verla" },
                    { 246, 23, "Farrellton" },
                    { 197, 23, "West Marcochester" },
                    { 247, 3, "Port Henryshire" },
                    { 148, 23, "Justineport" },
                    { 137, 23, "Horacechester" },
                    { 30, 4, "South Granville" },
                    { 134, 2, "South Aliza" },
                    { 86, 4, "Verniceton" },
                    { 2, 6, "North Hughbury" },
                    { 183, 22, "Kochville" },
                    { 51, 22, "Ceciliaside" },
                    { 300, 20, "East Olgafurt" },
                    { 293, 19, "Hilllside" },
                    { 223, 19, "Stoltenbergport" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 168, 19, "Kubview" },
                    { 49, 19, "Connellyhaven" },
                    { 154, 4, "South Kailey" },
                    { 186, 40, "North Johnson" },
                    { 279, 9, "Port Jeraldhaven" },
                    { 191, 48, "North Gladys" },
                    { 58, 46, "Heidifurt" },
                    { 281, 49, "South Pearlinestad" },
                    { 217, 57, "Klockoside" },
                    { 208, 57, "New Brenden" },
                    { 262, 56, "West Rebekah" },
                    { 147, 56, "North Reynoldland" },
                    { 59, 46, "North Jacksonchester" },
                    { 288, 55, "Labadieport" },
                    { 265, 55, "Lake Garrick" },
                    { 158, 55, "West Ilianaland" },
                    { 76, 46, "Ceasarton" },
                    { 91, 46, "Cortneytown" },
                    { 211, 53, "West Willis" },
                    { 53, 47, "Emmerichborough" },
                    { 138, 47, "North Clifford" },
                    { 196, 47, "North Generalhaven" },
                    { 203, 47, "South Alize" },
                    { 10, 52, "Torpport" },
                    { 7, 52, "Phyllisville" },
                    { 220, 48, "Elliemouth" },
                    { 294, 48, "Landenchester" },
                    { 109, 51, "Mosheborough" },
                    { 70, 49, "Whiteberg" },
                    { 121, 45, "Lake Amparoville" },
                    { 248, 57, "Kobyhaven" },
                    { 234, 57, "Port Damaris" },
                    { 215, 61, "North Coleman" },
                    { 133, 44, "McLaughlinview" },
                    { 238, 44, "Kshlerinton" },
                    { 181, 42, "Avisville" },
                    { 219, 60, "Abbotthaven" },
                    { 221, 61, "West Kaseyport" },
                    { 251, 58, "Antoneburgh" },
                    { 3, 63, "South Ociefurt" },
                    { 276, 42, "East Cathrynview" },
                    { 122, 42, "Port Sibyl" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 113, 45, "East Michelleport" },
                    { 27, 63, "Andyport" },
                    { 37, 58, "North Janamouth" },
                    { 233, 58, "West Erlingborough" },
                    { 226, 42, "Stokesmouth" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 54, 2305, 3, "voluptatum", 204 },
                    { 56, 2777, 3, "sapiente", 283 },
                    { 44, 2858, 3, "inventore", 311 },
                    { 66, 2891, 4, "dolore", 392 },
                    { 80, 2733, 4, "beatae", 610 },
                    { 41, 1643, 3, "nemo", 231 },
                    { 68, 2127, 4, "itaque", 163 },
                    { 7, 1522, 4, "voluptatibus", 156 },
                    { 55, 2571, 4, "unde", 476 },
                    { 57, 1038, 4, "nihil", 469 },
                    { 18, 2844, 4, "exercitationem", 517 },
                    { 71, 2037, 3, "expedita", 621 },
                    { 49, 1362, 4, "placeat", 665 },
                    { 74, 1505, 3, "repellat", 580 },
                    { 48, 2817, 4, "a", 290 },
                    { 93, 1012, 3, "laudantium", 320 },
                    { 96, 2960, 3, "repudiandae", 322 },
                    { 100, 1515, 3, "numquam", 624 },
                    { 47, 1770, 4, "voluptates", 101 },
                    { 38, 2922, 4, "voluptas", 235 },
                    { 4, 2077, 4, "error", 495 },
                    { 22, 1342, 4, "sit", 100 },
                    { 59, 1709, 3, "culpa", 528 },
                    { 40, 1755, 3, "doloremque", 254 },
                    { 52, 2726, 2, "aspernatur", 593 },
                    { 32, 2320, 3, "ipsum", 375 },
                    { 51, 2787, 1, "necessitatibus", 261 },
                    { 60, 2343, 1, "totam", 300 },
                    { 62, 2687, 1, "fugit", 318 },
                    { 64, 1312, 1, "molestiae", 449 },
                    { 98, 1308, 2, "minima", 415 },
                    { 84, 1098, 2, "dignissimos", 479 },
                    { 65, 2448, 1, "officia", 506 },
                    { 67, 2473, 1, "repellendus", 637 },
                    { 88, 1138, 1, "eum", 425 },
                    { 36, 1773, 1, "ut", 154 },
                    { 77, 1972, 2, "voluptatem", 658 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 76, 1480, 2, "hic", 194 },
                    { 13, 1063, 2, "aliquid", 526 },
                    { 14, 1801, 2, "ab", 416 },
                    { 75, 2005, 2, "ipsa", 122 },
                    { 17, 2816, 2, "possimus", 379 },
                    { 72, 2943, 2, "architecto", 177 },
                    { 33, 1270, 2, "qui", 258 },
                    { 34, 2230, 2, "quas", 286 },
                    { 53, 1272, 2, "commodi", 576 },
                    { 92, 2163, 1, "facere", 496 },
                    { 37, 2136, 3, "excepturi", 194 },
                    { 99, 1917, 2, "cupiditate", 691 },
                    { 35, 1007, 1, "eius", 616 },
                    { 30, 2832, 3, "consequatur", 207 },
                    { 1, 2700, 1, "quia", 527 },
                    { 5, 2342, 1, "id", 438 },
                    { 27, 2534, 3, "laboriosam", 662 },
                    { 39, 2428, 2, "ea", 495 },
                    { 8, 2454, 1, "tempora", 492 },
                    { 25, 2163, 3, "autem", 280 },
                    { 24, 2859, 3, "atque", 124 },
                    { 10, 2324, 1, "explicabo", 176 },
                    { 3, 1822, 3, "et", 675 },
                    { 11, 2813, 1, "reprehenderit", 566 },
                    { 15, 1115, 1, "maiores", 205 },
                    { 16, 2599, 1, "dicta", 167 },
                    { 19, 1869, 1, "perspiciatis", 537 },
                    { 9, 1353, 3, "dolorem", 245 },
                    { 21, 1016, 1, "aut", 360 },
                    { 6, 2528, 3, "delectus", 619 },
                    { 23, 2768, 1, "est", 550 },
                    { 28, 1937, 1, "tempore", 323 },
                    { 29, 2527, 1, "debitis", 152 },
                    { 12, 2135, 1, "rem", 190 },
                    { 2, 1365, 2, "praesentium", 450 },
                    { 94, 1522, 4, "molestias", 562 },
                    { 83, 2273, 4, "dolor", 336 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 27, 9, "Cartwright, Rath and Grimes" },
                    { 47, 48, "Schaefer - O'Kon" },
                    { 66, 84, "Wiza - Ledner" },
                    { 86, 85, "Beahan, Larkin and West" },
                    { 56, 87, "Fay - Ward" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 7, 88, "Zemlak, Weimann and Fahey" },
                    { 30, 90, "Mayert - Stoltenberg" },
                    { 52, 90, "Goldner Inc" },
                    { 14, 44, "Heller Group" },
                    { 75, 94, "Hammes - Paucek" },
                    { 74, 43, "Lubowitz and Sons" },
                    { 60, 42, "Kunze and Sons" },
                    { 88, 96, "Morar - Prosacco" },
                    { 46, 98, "Feeney, Krajcik and Shields" },
                    { 92, 41, "McLaughlin and Sons" },
                    { 63, 41, "Goldner Group" },
                    { 97, 40, "McDermott, Hahn and Wolf" },
                    { 4, 104, "O'Conner and Sons" },
                    { 78, 104, "Rogahn, Keebler and Ruecker" },
                    { 2, 107, "Lockman and Sons" },
                    { 90, 36, "Hirthe, Howell and Wintheiser" },
                    { 33, 49, "Conroy - Rau" },
                    { 100, 79, "Moore LLC" },
                    { 69, 49, "Shanahan, Krajcik and Nienow" },
                    { 99, 51, "Adams - Schuppe" },
                    { 45, 62, "Hodkiewicz - Mohr" },
                    { 12, 62, "Reynolds LLC" },
                    { 9, 64, "Schumm Group" },
                    { 15, 66, "Luettgen - Kertzmann" },
                    { 87, 66, "Jenkins LLC" },
                    { 83, 60, "Considine and Sons" },
                    { 42, 60, "Bradtke - Kunze" },
                    { 72, 58, "Denesik - Hoeger" },
                    { 38, 68, "Cruickshank, Kuhic and Smitham" },
                    { 77, 68, "Bartell, Herzog and Corwin" },
                    { 16, 110, "Toy Inc" },
                    { 48, 57, "Larkin, Quigley and Huel" },
                    { 89, 70, "Schimmel and Sons" },
                    { 80, 71, "Gorczany - Bogisich" },
                    { 53, 72, "Mitchell and Sons" },
                    { 62, 55, "Gaylord, Hackett and Bogan" },
                    { 67, 73, "Quitzon, Runolfsson and O'Kon" },
                    { 93, 54, "Botsford, Ebert and Kohler" },
                    { 51, 54, "Bosco, Schaden and Hoeger" },
                    { 3, 74, "Grimes - Bradtke" },
                    { 65, 52, "Reinger, Turner and Stark" },
                    { 37, 77, "Orn - Reynolds" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 23, 57, "Crona and Sons" },
                    { 91, 171, "Halvorson - Feeney" },
                    { 41, 110, "Kautzer, Lindgren and Mante" },
                    { 59, 35, "Hamill, Hoppe and Bauch" },
                    { 96, 149, "Ortiz, Hilll and McDermott" },
                    { 19, 24, "McClure - Balistreri" },
                    { 71, 192, "Waelchi - Orn" },
                    { 73, 150, "Kshlerin, Jenkins and Bruen" },
                    { 84, 3, "Russel, Metz and Crist" },
                    { 36, 191, "Schaden Inc" },
                    { 68, 22, "Harber LLC" },
                    { 6, 152, "Wunsch, Halvorson and Macejkovic" },
                    { 22, 153, "Konopelski, Cronin and Christiansen" },
                    { 64, 153, "Stoltenberg - Steuber" },
                    { 54, 162, "Bosco Group" },
                    { 39, 6, "Fritsch and Sons" },
                    { 1, 15, "Orn and Sons" },
                    { 32, 14, "Bruen - Brown" },
                    { 44, 13, "Vandervort, Champlin and Runolfsson" },
                    { 28, 167, "Gaylord - Thiel" },
                    { 61, 11, "Greenfelder - Braun" },
                    { 18, 8, "Pollich, Rutherford and Donnelly" },
                    { 35, 173, "Kautzer, Adams and Carroll" },
                    { 29, 10, "Sporer - Prohaska" },
                    { 50, 9, "Wuckert - McLaughlin" },
                    { 55, 149, "Quitzon - Ratke" },
                    { 58, 148, "Roberts LLC" },
                    { 5, 148, "VonRueden LLC" },
                    { 20, 143, "Gerlach, Hoeger and Smith" },
                    { 49, 35, "Jacobs - Trantow" },
                    { 40, 35, "Adams LLC" },
                    { 76, 32, "Lowe LLC" },
                    { 85, 118, "Heller LLC" },
                    { 95, 118, "Beahan, Baumbach and Schneider" },
                    { 11, 120, "Rippin - Lemke" },
                    { 34, 32, "Vandervort LLC" },
                    { 8, 124, "Wyman - Shields" },
                    { 17, 124, "Lynch - Lesch" },
                    { 21, 124, "Feeney and Sons" },
                    { 43, 110, "Marquardt LLC" },
                    { 81, 124, "Champlin, Bahringer and Christiansen" },
                    { 79, 30, "Stiedemann - Ankunding" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 98, 129, "Kovacek, Keeling and Donnelly" },
                    { 70, 130, "Brakus Group" },
                    { 94, 130, "Daugherty Group" },
                    { 57, 30, "Maggio - Hilll" },
                    { 31, 133, "Predovic Inc" },
                    { 24, 28, "Johns, Barton and Mayert" },
                    { 10, 139, "Russel LLC" },
                    { 26, 142, "Herzog, White and O'Conner" },
                    { 13, 198, "Hudson, Rolfson and Lynch" },
                    { 25, 125, "Powlowski Inc" },
                    { 82, 143, "Friesen, Baumbach and Koch" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 96, 83, 3, "nobis" },
                    { 44, 92, 57, "inventore" },
                    { 54, 92, 53, "animi" },
                    { 72, 92, 89, "atque" },
                    { 4, 13, 53, "hic" },
                    { 52, 17, 56, "saepe" },
                    { 85, 52, 37, "placeat" },
                    { 28, 92, 58, "rerum" },
                    { 86, 52, 17, "minus" },
                    { 29, 53, 25, "molestias" },
                    { 24, 75, 9, "ad" },
                    { 22, 76, 35, "repellat" },
                    { 11, 77, 70, "est" },
                    { 2, 84, 71, "qui" },
                    { 5, 99, 28, "officiis" },
                    { 99, 52, 37, "iusto" },
                    { 91, 99, 5, "sequi" },
                    { 23, 92, 41, "voluptatem" },
                    { 12, 64, 37, "totam" },
                    { 13, 1, 55, "ut" },
                    { 9, 10, 94, "deleniti" },
                    { 36, 10, 52, "dolores" },
                    { 97, 11, 26, "sit" },
                    { 34, 12, 4, "autem" },
                    { 83, 12, 49, "non" },
                    { 14, 92, 55, "quia" },
                    { 84, 15, 69, "recusandae" },
                    { 98, 16, 30, "neque" },
                    { 16, 19, 57, "ex" },
                    { 41, 19, 81, "incidunt" },
                    { 1, 36, 21, "aliquam" },
                    { 50, 51, 85, "doloribus" },
                    { 90, 51, 50, "enim" },
                    { 38, 16, 46, "mollitia" },
                    { 21, 9, 62, "possimus" },
                    { 66, 83, 87, "dolorem" },
                    { 18, 27, 9, "ea" },
                    { 33, 100, 77, "et" },
                    { 88, 100, 89, "sed" },
                    { 69, 4, 22, "dolore" },
                    { 40, 7, 49, "adipisci" },
                    { 19, 18, 82, "ipsam" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 7, 22, 54, "ipsum" },
                    { 25, 100, 97, "nulla" },
                    { 35, 22, 21, "laboriosam" },
                    { 30, 48, 16, "excepturi" },
                    { 64, 49, 32, "vero" },
                    { 20, 68, 35, "magni" },
                    { 61, 68, 62, "porro" },
                    { 6, 80, 37, "fuga" },
                    { 8, 24, 97, "odio" },
                    { 82, 38, 28, "cupiditate" },
                    { 80, 96, 70, "aspernatur" },
                    { 15, 55, 33, "voluptas" },
                    { 49, 96, 88, "velit" },
                    { 62, 96, 17, "earum" },
                    { 63, 27, 76, "harum" },
                    { 46, 30, 55, "eius" },
                    { 3, 37, 40, "libero" },
                    { 10, 37, 28, "ab" },
                    { 100, 37, 61, "tempora" },
                    { 27, 30, 13, "soluta" },
                    { 68, 59, 87, "in" },
                    { 17, 96, 36, "voluptatum" },
                    { 59, 56, 76, "commodi" },
                    { 67, 93, 18, "aut" },
                    { 57, 27, 18, "consequuntur" },
                    { 32, 93, 45, "labore" },
                    { 70, 74, 54, "nesciunt" },
                    { 60, 93, 95, "illo" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 11, 116, "Braxton40@gmail.com", "Antonia", "McDermott", "password123", 2, "Arturo.Hilpert93" },
                    { 173, 157, "Karolann_Bergstrom@hotmail.com", "Cloyd", "Cassin", "password123", 3, "Cayla.Hessel" },
                    { 176, 166, "Lionel.Hirthe23@hotmail.com", "Leta", "Bruen", "password123", 2, "Narciso.Hodkiewicz" },
                    { 235, 166, "Tamara33@yahoo.com", "Alisha", "Kuhlman", "password123", 3, "Danny0" },
                    { 180, 222, "Lindsey_Dooley18@yahoo.com", "Nicholas", "Kiehn", "password123", 1, "Marcellus.Roberts21" },
                    { 20, 19, "Kennedi35@gmail.com", "Toni", "Harris", "password123", 2, "Clinton_Spencer85" },
                    { 281, 98, "Caitlyn37@yahoo.com", "Andy", "Funk", "password123", 2, "Citlalli_Parker" },
                    { 82, 52, "Margret53@gmail.com", "Elian", "Rodriguez", "password123", 2, "Easton_Lang" },
                    { 266, 52, "Nikko61@yahoo.com", "Brendon", "Spinka", "password123", 2, "Garth49" },
                    { 293, 52, "Brock_Moen92@gmail.com", "Clair", "VonRueden", "password123", 2, "Milford.Howe68" },
                    { 98, 222, "Leilani_Bernhard89@hotmail.com", "Krystina", "Treutel", "password123", 3, "Jaycee_Dach41" },
                    { 54, 241, "Garrick_MacGyver@gmail.com", "Frederick", "Heaney", "password123", 1, "Coby_Effertz76" },
                    { 225, 116, "Libby50@gmail.com", "Dominique", "Langworth", "password123", 3, "Cleveland_Huel" },
                    { 60, 74, "Brando15@gmail.com", "Mario", "Watsica", "password123", 1, "Elna.Flatley62" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 71, 74, "Era_Kozey@hotmail.com", "Dena", "Dickens", "password123", 2, "Lizeth_Kreiger" },
                    { 102, 74, "Dax56@hotmail.com", "Amos", "Lynch", "password123", 2, "Judah_Pacocha68" },
                    { 89, 214, "Kip_Huels28@hotmail.com", "Tristin", "Daugherty", "password123", 1, "Bernice_Moen17" },
                    { 187, 214, "Kiera_Greenholt@gmail.com", "Eva", "Crist", "password123", 3, "Maria_Schamberger68" },
                    { 284, 241, "Wade63@gmail.com", "Juvenal", "Thompson", "password123", 3, "Heath76" },
                    { 174, 259, "Linda.Harris@gmail.com", "Gwendolyn", "Runte", "password123", 3, "Ted_Conroy" },
                    { 101, 40, "Athena.Mohr@yahoo.com", "Willy", "Rippin", "password123", 3, "Maxime_Marvin35" },
                    { 30, 200, "Bennett_Blanda58@gmail.com", "Austen", "Little", "password123", 1, "Vincenzo18" },
                    { 126, 280, "Verna30@hotmail.com", "Autumn", "Schinner", "password123", 2, "Marvin.McGlynn" },
                    { 224, 268, "Sherman86@gmail.com", "Dwight", "Moore", "password123", 3, "Heloise64" },
                    { 134, 116, "Carmela.Walsh72@yahoo.com", "Otto", "Connelly", "password123", 2, "Seth.Quigley" },
                    { 166, 99, "Easter54@yahoo.com", "Ashley", "Kovacek", "password123", 3, "Brisa60" },
                    { 205, 119, "Vivian13@gmail.com", "Maxwell", "Altenwerth", "password123", 3, "Presley_Barrows79" },
                    { 272, 201, "German38@hotmail.com", "Lucie", "Doyle", "password123", 1, "Brando.Macejkovic70" },
                    { 283, 155, "Lauren31@gmail.com", "Keshawn", "Kozey", "password123", 1, "Sanford_Hessel" },
                    { 155, 117, "Murray.Von91@gmail.com", "Dejah", "Steuber", "password123", 3, "Susanna_Kassulke" },
                    { 165, 117, "Dasia_Kassulke@yahoo.com", "Cristal", "Kub", "password123", 1, "Adaline69" },
                    { 277, 249, "Roderick_Lind@gmail.com", "Kenyon", "Blanda", "password123", 2, "Dane35" },
                    { 38, 8, "Jarod.Altenwerth5@yahoo.com", "Rosario", "Kunze", "password123", 2, "Ronaldo62" },
                    { 141, 63, "Era_OConner@yahoo.com", "Emerald", "Stehr", "password123", 1, "Amir.Mayer3" },
                    { 253, 63, "Deven3@hotmail.com", "Vickie", "Roob", "password123", 1, "Dereck_Johnston35" },
                    { 230, 128, "Anya_King39@hotmail.com", "Gene", "Crist", "password123", 1, "Sharon_Marks" },
                    { 168, 253, "Savannah_Hackett@hotmail.com", "Everett", "Satterfield", "password123", 2, "Baby43" },
                    { 121, 284, "Treva.Beahan80@hotmail.com", "Kenyatta", "Corkery", "password123", 2, "Sammy_Murphy29" },
                    { 27, 119, "Breana_Thiel@hotmail.com", "Kamron", "Reinger", "password123", 1, "Luciano.Connelly" },
                    { 184, 280, "Kasandra.Balistreri50@hotmail.com", "Shemar", "Stoltenberg", "password123", 1, "Kavon_Jenkins76" },
                    { 100, 124, "Bert.Ritchie@hotmail.com", "Vern", "Kuphal", "password123", 3, "Enrique_Bartell" },
                    { 202, 83, "Ara_Feest@hotmail.com", "Camron", "Johnson", "password123", 2, "Devonte.Daniel" },
                    { 257, 112, "Jerry_Huel@hotmail.com", "Alice", "Cummings", "password123", 1, "Isabella.Boyle47" },
                    { 63, 230, "Javon97@yahoo.com", "Adah", "Herzog", "password123", 1, "Edythe.Nicolas" },
                    { 5, 189, "Emilia90@yahoo.com", "Lonzo", "Abshire", "password123", 3, "Sonny33" },
                    { 147, 231, "Sammie_Schaefer92@gmail.com", "Pearl", "Schumm", "password123", 1, "Marisa_Paucek" },
                    { 29, 267, "Selina46@yahoo.com", "Larue", "Kreiger", "password123", 2, "Bonnie.Spencer" },
                    { 124, 101, "Jedediah34@hotmail.com", "Cade", "McClure", "password123", 2, "Bryce_Herman" },
                    { 44, 299, "Whitney46@hotmail.com", "Lucious", "Brekke", "password123", 1, "Dana29" },
                    { 127, 111, "Lela.Satterfield@hotmail.com", "Lonzo", "Hegmann", "password123", 3, "Reta.Trantow" },
                    { 158, 209, "Retta10@yahoo.com", "Milford", "Hahn", "password123", 1, "Carlie_Dickinson10" },
                    { 219, 21, "Dewitt.Sauer@hotmail.com", "Major", "Spinka", "password123", 2, "Santina.Osinski31" },
                    { 58, 35, "Cyril.King@gmail.com", "Freda", "Schaefer", "password123", 1, "Philip.Smith" },
                    { 28, 142, "Nicholas_Turner42@yahoo.com", "Graham", "Zboncak", "password123", 2, "Idell71" },
                    { 116, 112, "Karli.Glover38@yahoo.com", "Wendell", "Graham", "password123", 2, "Hilbert49" },
                    { 183, 151, "Elsa52@hotmail.com", "Garth", "Rolfson", "password123", 1, "Rocky_Weissnat" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 128, 175, "Jared_Abbott6@yahoo.com", "Elza", "Dach", "password123", 3, "Al39" },
                    { 57, 153, "Vallie89@yahoo.com", "Holden", "Schneider", "password123", 2, "Janessa_Goodwin" },
                    { 177, 54, "Trinity92@hotmail.com", "Avery", "Beer", "password123", 3, "Sage0" },
                    { 247, 155, "Carlotta11@gmail.com", "Dasia", "Spinka", "password123", 3, "Chandler.Davis" },
                    { 59, 225, "Keith.Bartoletti69@hotmail.com", "Gertrude", "Ernser", "password123", 3, "Keshawn.Rogahn" },
                    { 81, 225, "Milo_OReilly@yahoo.com", "Jany", "Langworth", "password123", 3, "Hilario.Kling" },
                    { 107, 225, "Beth.Hermiston3@yahoo.com", "Colton", "Stamm", "password123", 3, "Cyril77" },
                    { 129, 173, "Amelie_MacGyver2@hotmail.com", "Alexandria", "O'Keefe", "password123", 1, "Nyah80" },
                    { 76, 89, "Otto79@gmail.com", "Keaton", "Lehner", "password123", 1, "Luis84" },
                    { 79, 89, "Allan18@hotmail.com", "Fritz", "Ward", "password123", 2, "Anastasia.Hessel" },
                    { 290, 89, "Ed.Wisoky@hotmail.com", "Virgie", "Rippin", "password123", 2, "Hermann.Bednar90" },
                    { 231, 195, "Laila_Okuneva35@hotmail.com", "Rodrigo", "Tremblay", "password123", 1, "Krista_Schinner7" },
                    { 13, 261, "Destin.Turner@hotmail.com", "Hertha", "Bogisich", "password123", 1, "Kaleigh.Hoeger46" },
                    { 261, 261, "Laury.Treutel@gmail.com", "Claire", "Bartell", "password123", 1, "Eloisa33" },
                    { 46, 45, "Kaylin_Skiles51@gmail.com", "Cooper", "Feeney", "password123", 2, "Adan2" },
                    { 198, 45, "Heather9@yahoo.com", "Theresa", "Grady", "password123", 3, "Mossie.Greenholt18" },
                    { 113, 36, "Bernhard.Corkery40@gmail.com", "Barry", "Shanahan", "password123", 2, "Alba64" },
                    { 131, 44, "Corrine.Donnelly16@yahoo.com", "Leopold", "Schmeler", "password123", 1, "Angie_Mills" },
                    { 42, 78, "Devonte_Batz@hotmail.com", "Mikayla", "Herman", "password123", 1, "Colleen_Abernathy" },
                    { 152, 256, "Domenico.Adams10@yahoo.com", "Albina", "Blanda", "password123", 1, "Brigitte.Herzog12" },
                    { 161, 256, "Berneice43@yahoo.com", "Kristopher", "Connelly", "password123", 1, "Shyanne.Dibbert71" },
                    { 115, 67, "Alanis92@yahoo.com", "Jonathon", "Conn", "password123", 1, "Berta.Corkery" },
                    { 142, 100, "Chelsey.Kuvalis@yahoo.com", "Jaleel", "Kutch", "password123", 3, "Donnie5" },
                    { 217, 100, "Ashton.Botsford@hotmail.com", "Rebecca", "Shanahan", "password123", 3, "Uriah26" },
                    { 267, 100, "Liliane_Dibbert@gmail.com", "Brent", "Jerde", "password123", 1, "Una49" },
                    { 80, 252, "Aisha.Ratke91@gmail.com", "Theron", "Brekke", "password123", 3, "Marley_Turcotte10" },
                    { 133, 252, "Joana.Wiza@hotmail.com", "Stephania", "Labadie", "password123", 3, "Hassie_Wisozk60" },
                    { 136, 54, "Laverna.Grady67@yahoo.com", "Howard", "Mante", "password123", 2, "Sammie_Fahey56" },
                    { 244, 174, "Sammy76@hotmail.com", "Amara", "McKenzie", "password123", 1, "Anita_Hartmann73" },
                    { 207, 174, "Drake_Daniel@hotmail.com", "Fermin", "Lakin", "password123", 2, "Cleo_Kulas" },
                    { 163, 174, "Ettie_Rogahn@gmail.com", "Lyla", "Koelpin", "password123", 3, "Rafaela_Ratke66" },
                    { 70, 172, "Maximus32@hotmail.com", "Mozell", "Hirthe", "password123", 1, "Branson31" },
                    { 263, 206, "Marianna.Bernhard94@yahoo.com", "Desiree", "Kunze", "password123", 2, "Concepcion_Wiza31" },
                    { 190, 240, "Myra76@gmail.com", "Jarret", "Marquardt", "password123", 2, "Vella_Turcotte" },
                    { 220, 240, "Brenden_Schmitt26@gmail.com", "Juanita", "Hyatt", "password123", 3, "Rickie_Muller65" },
                    { 260, 47, "Rebeca88@gmail.com", "River", "Walsh", "password123", 1, "Shany.Hammes35" },
                    { 172, 243, "Libbie_Kessler51@gmail.com", "Easton", "Emmerich", "password123", 1, "Golden_Cassin" },
                    { 195, 243, "Greta.Kub@hotmail.com", "Abbey", "Bechtelar", "password123", 3, "Buford0" },
                    { 251, 243, "Murl99@gmail.com", "Jodie", "Gutmann", "password123", 3, "Emerson_Pagac" },
                    { 49, 4, "Jay.Rutherford@yahoo.com", "Pinkie", "Beahan", "password123", 2, "Dale32" },
                    { 52, 4, "Keenan37@hotmail.com", "Loren", "Witting", "password123", 2, "Vincenzo.Schinner" },
                    { 222, 4, "Lourdes_Armstrong73@yahoo.com", "Vincenza", "Douglas", "password123", 1, "Athena_Kessler39" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 34, 50, "Lance78@yahoo.com", "Jaclyn", "Crist", "password123", 1, "Aidan.Hagenes43" },
                    { 258, 151, "Madie.Ruecker@gmail.com", "Icie", "Lockman", "password123", 1, "Yvonne.Wuckert79" },
                    { 74, 50, "Jacques16@gmail.com", "Deshawn", "Abshire", "password123", 2, "John.Ratke" },
                    { 33, 184, "Dortha_Jenkins24@yahoo.com", "Stuart", "Schuster", "password123", 2, "Vincenza97" },
                    { 135, 295, "Hadley.Leffler66@gmail.com", "Penelope", "Hudson", "password123", 3, "Ewald.Boyle" },
                    { 138, 41, "Teagan.Schaden@yahoo.com", "Pete", "Kihn", "password123", 1, "Elva.Crona62" },
                    { 157, 41, "Samir_Runolfsdottir@gmail.com", "Estelle", "Kub", "password123", 1, "Ressie72" },
                    { 197, 41, "Kim.Quitzon49@gmail.com", "Abdul", "Leannon", "password123", 2, "Fay39" },
                    { 241, 41, "Quincy89@hotmail.com", "Mireya", "Hauck", "password123", 1, "Andy.Bergnaum73" },
                    { 169, 164, "Chelsie_Stanton7@hotmail.com", "Courtney", "Lynch", "password123", 3, "Angel.Maggio86" },
                    { 236, 102, "Jared_Schmeler46@hotmail.com", "Lonzo", "Wisoky", "password123", 2, "Gino_Fay" },
                    { 254, 205, "Drew7@yahoo.com", "Zora", "Glover", "password123", 3, "Theodore76" },
                    { 91, 216, "Elbert87@yahoo.com", "Maxie", "Morar", "password123", 1, "Ines_Cole" },
                    { 286, 216, "Brandon.Deckow@hotmail.com", "Adaline", "Ratke", "password123", 3, "Judson88" },
                    { 137, 140, "Dorcas_Price@yahoo.com", "Adolf", "Crist", "password123", 1, "Julius15" },
                    { 300, 61, "Tommie57@hotmail.com", "Alexandria", "Beahan", "password123", 2, "Albertha_Gibson9" },
                    { 112, 260, "Randal.Volkman35@gmail.com", "Gaylord", "Hackett", "password123", 1, "Leonardo_Kling" },
                    { 171, 155, "Adelbert_Hegmann@gmail.com", "Silas", "Douglas", "password123", 1, "Regan_Collier" },
                    { 274, 143, "Diego.Muller@yahoo.com", "Nella", "Larson", "password123", 2, "Rocky18" },
                    { 117, 274, "Giles68@gmail.com", "Claudie", "O'Keefe", "password123", 3, "Sibyl.Torp91" },
                    { 295, 232, "Ellie.Beahan@hotmail.com", "Brandt", "Hegmann", "password123", 2, "Juliet_Okuneva58" },
                    { 105, 75, "Tillman_Fay@yahoo.com", "Anjali", "O'Hara", "password123", 3, "Jaiden60" },
                    { 21, 75, "Destany.Hackett62@gmail.com", "Adolph", "Kerluke", "password123", 3, "Torrey33" },
                    { 249, 32, "Rory_Jast72@hotmail.com", "Prudence", "Kunze", "password123", 1, "Savannah45" },
                    { 159, 32, "Beatrice97@hotmail.com", "Alexane", "Nicolas", "password123", 2, "Myriam_Keebler86" },
                    { 35, 32, "Maybelle_Hoeger@hotmail.com", "Marguerite", "Morar", "password123", 3, "Braeden.Hagenes96" },
                    { 298, 292, "Neal.Langworth64@hotmail.com", "Ivy", "Shanahan", "password123", 3, "Katarina.Emmerich63" },
                    { 41, 179, "Weldon_Ortiz14@hotmail.com", "Isom", "Klocko", "password123", 2, "Darrin33" },
                    { 167, 48, "Letitia_Stark11@yahoo.com", "Jake", "Kiehn", "password123", 2, "Jessika.Halvorson" },
                    { 86, 48, "Andrew.Walter@hotmail.com", "Jovany", "Rath", "password123", 2, "Emile.Mitchell31" },
                    { 194, 23, "Anna_Smith@yahoo.com", "Jamil", "Krajcik", "password123", 2, "Halie31" },
                    { 36, 23, "Amir.Carter@hotmail.com", "Kristoffer", "Gaylord", "password123", 3, "Demond_Kutch12" },
                    { 178, 263, "Lorenz.Pagac72@gmail.com", "Elian", "Beatty", "password123", 1, "Princess.Grant94" },
                    { 22, 246, "Tod55@gmail.com", "Jermaine", "Quitzon", "password123", 3, "Walter_Bayer" },
                    { 199, 197, "Judge.Beahan77@hotmail.com", "Urban", "Zulauf", "password123", 1, "Salma.Koch" },
                    { 234, 148, "Scarlett.Ortiz49@yahoo.com", "Kiley", "Zemlak", "password123", 2, "Trent_Hilll36" },
                    { 85, 148, "Shirley26@hotmail.com", "Karianne", "Windler", "password123", 1, "Albin.Jacobs" },
                    { 48, 148, "Ona.Beatty4@hotmail.com", "Clemens", "Wunsch", "password123", 2, "Jayson.Erdman" },
                    { 296, 242, "Herman_Kulas@gmail.com", "Hunter", "Swaniawski", "password123", 2, "Graham46" },
                    { 175, 137, "Ardith53@yahoo.com", "Kailey", "Stehr", "password123", 1, "Lewis.Herzog94" },
                    { 218, 198, "Terence.Quigley@yahoo.com", "Shawna", "Upton", "password123", 2, "Fletcher24" },
                    { 111, 28, "Russell.Miller@gmail.com", "Bradford", "McLaughlin", "password123", 2, "Tressa.Green" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 15, 12, "Jorge.Dietrich@yahoo.com", "Della", "Hansen", "password123", 1, "Madyson.Grady3" },
                    { 96, 105, "Agustin.Murphy@yahoo.com", "Enrique", "Pacocha", "password123", 3, "Ceasar_Gusikowski" },
                    { 56, 105, "Glennie_OKeefe3@yahoo.com", "Griffin", "Hodkiewicz", "password123", 2, "Rusty74" },
                    { 243, 245, "Lawrence0@hotmail.com", "Charley", "Gleichner", "password123", 1, "Velva_Powlowski" },
                    { 221, 245, "Hobart_Murazik25@yahoo.com", "Adaline", "Mitchell", "password123", 1, "Pearline_Leannon" },
                    { 206, 193, "Sydnie.Fritsch@hotmail.com", "Roscoe", "Mohr", "password123", 3, "Brionna.Conroy35" },
                    { 114, 224, "Eden_Harvey@gmail.com", "Waylon", "Davis", "password123", 2, "Sylvia_Dach89" },
                    { 279, 146, "Kylee_Lowe@yahoo.com", "Jeromy", "Bashirian", "password123", 2, "Helena65" },
                    { 122, 146, "Alana.Beatty@hotmail.com", "Amari", "Abshire", "password123", 3, "Moses41" },
                    { 297, 169, "Herta.Anderson@hotmail.com", "Rogers", "Toy", "password123", 2, "Larissa.Batz64" },
                    { 292, 169, "Karlee_Bruen@yahoo.com", "Deion", "Senger", "password123", 2, "Nadia_Tillman" },
                    { 196, 107, "Jeanette23@yahoo.com", "Reggie", "Pfannerstill", "password123", 2, "Merl25" },
                    { 265, 165, "Geoffrey.Haley@yahoo.com", "Shirley", "Collier", "password123", 2, "Kevin.Smith" },
                    { 212, 165, "Berry.Davis@gmail.com", "Daniela", "Bogan", "password123", 3, "Elisha_Brakus" },
                    { 68, 165, "Jarret.Bartoletti2@gmail.com", "Vincenza", "Ullrich", "password123", 2, "Ivah.Pfeffer" },
                    { 118, 62, "Zackery_Buckridge@hotmail.com", "Sadye", "Barton", "password123", 1, "Lindsey.Lakin" },
                    { 45, 62, "Itzel41@gmail.com", "Janessa", "Jacobs", "password123", 1, "Rylan12" },
                    { 149, 28, "Abner85@hotmail.com", "Rebeca", "Feest", "password123", 1, "Itzel_Sanford" },
                    { 143, 28, "Keven37@gmail.com", "Darwin", "Bradtke", "password123", 3, "Modesto_Kris" },
                    { 47, 28, "Vincent.Schulist66@gmail.com", "Paula", "Shanahan", "password123", 2, "Vida_Walker50" },
                    { 250, 64, "Chaya27@hotmail.com", "Unique", "Wiegand", "password123", 3, "Amalia_Littel" },
                    { 69, 137, "Josiane59@gmail.com", "Hailee", "Klocko", "password123", 3, "Randal_Green18" },
                    { 93, 183, "Alycia84@gmail.com", "Lexus", "Powlowski", "password123", 1, "Krystal61" },
                    { 125, 180, "Lois.Hills@hotmail.com", "Hassie", "Miller", "password123", 3, "Zechariah.Pacocha" },
                    { 12, 180, "Autumn.Kreiger82@hotmail.com", "Armand", "Gorczany", "password123", 1, "Desmond_Muller" },
                    { 233, 2, "Donnie46@hotmail.com", "Declan", "Mante", "password123", 1, "Nicholas56" },
                    { 210, 2, "Idell.Conn73@gmail.com", "Forest", "O'Hara", "password123", 3, "Jalyn33" },
                    { 88, 2, "Kasey_Sawayn90@gmail.com", "Clara", "Goyette", "password123", 3, "Alverta79" },
                    { 84, 2, "Kathryn15@hotmail.com", "Cristina", "Parisian", "password123", 1, "Liana.Weissnat37" },
                    { 262, 86, "Herta74@yahoo.com", "Alyce", "Lindgren", "password123", 1, "Carmella_Becker" },
                    { 201, 86, "Jovan54@yahoo.com", "Danielle", "Hudson", "password123", 1, "Felipa.Rogahn" },
                    { 139, 86, "Liam3@yahoo.com", "Judson", "Wilderman", "password123", 1, "Estel73" },
                    { 123, 86, "Brooklyn.Keeling30@hotmail.com", "Maryse", "Swaniawski", "password123", 2, "Deontae.Bartell97" },
                    { 119, 30, "Destini_Ledner@gmail.com", "Donavon", "Bogan", "password123", 2, "Mustafa_Koch4" },
                    { 50, 30, "Turner_Huel@hotmail.com", "Domingo", "Funk", "password123", 2, "Rashawn25" },
                    { 110, 247, "Mitchell.Jones21@hotmail.com", "Talon", "Koss", "password123", 1, "Dovie_Schamberger" },
                    { 164, 227, "Werner_Abbott18@yahoo.com", "Rosalinda", "Schaefer", "password123", 3, "Aiden_Prohaska55" },
                    { 65, 227, "Aaron_Swaniawski@gmail.com", "Melyna", "Stracke", "password123", 2, "Maximillia_Reinger" },
                    { 25, 227, "Vicente.Collins66@yahoo.com", "Katarina", "Gulgowski", "password123", 2, "Kenya76" },
                    { 146, 286, "Vincenza78@hotmail.com", "Rhoda", "Hermann", "password123", 1, "Lessie_Murray17" },
                    { 64, 134, "Coralie51@hotmail.com", "Colin", "Howell", "password123", 3, "Colt92" },
                    { 3, 123, "Bette_Jacobs36@gmail.com", "Ernestina", "Padberg", "password123", 3, "Beatrice_Howe" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 37, 291, "Willa_Lemke34@gmail.com", "Johnathan", "Schumm", "password123", 1, "Colton.Kreiger" },
                    { 255, 183, "Cayla_Heathcote3@gmail.com", "Jarrell", "Schowalter", "password123", 2, "Keith62" },
                    { 269, 69, "Dereck.VonRueden67@gmail.com", "Jaleel", "Kihn", "password123", 2, "Jedidiah.Ritchie" },
                    { 289, 81, "Emiliano.Bayer59@hotmail.com", "Verda", "Frami", "password123", 1, "Gregoria.Renner" },
                    { 16, 300, "Maryam_Altenwerth69@hotmail.com", "Karen", "Tremblay", "password123", 1, "Amara32" },
                    { 256, 223, "Katherine.Gulgowski32@yahoo.com", "Shayna", "Waters", "password123", 2, "Hilbert.Lemke" },
                    { 90, 223, "Arvilla32@hotmail.com", "Trinity", "Spinka", "password123", 3, "Jayne.Lebsack" },
                    { 204, 168, "Tristin_Robel@yahoo.com", "Maynard", "Carter", "password123", 2, "Casper_Anderson" },
                    { 192, 168, "Cedrick46@yahoo.com", "Flavie", "Graham", "password123", 2, "Maynard.Rice" },
                    { 271, 152, "Harmon.Hodkiewicz@gmail.com", "Darion", "Lakin", "password123", 1, "Steve_Greenholt15" },
                    { 99, 152, "Darrell_Cruickshank@gmail.com", "Eldon", "Conroy", "password123", 1, "Ronaldo_Johnson47" },
                    { 43, 152, "Savannah36@gmail.com", "Domenick", "Armstrong", "password123", 2, "Celestino_Cronin" },
                    { 226, 278, "Meta90@yahoo.com", "Katharina", "Mraz", "password123", 2, "Ressie.Koch" },
                    { 10, 278, "Esperanza92@yahoo.com", "Joanie", "Waters", "password123", 2, "Daisha45" },
                    { 291, 55, "Vesta_McDermott79@gmail.com", "Zetta", "Kozey", "password123", 3, "Carmel.Spencer78" },
                    { 170, 55, "Roxane.Turcotte35@gmail.com", "Ladarius", "Cremin", "password123", 2, "Kaycee84" },
                    { 9, 84, "Andreane_Ratke50@hotmail.com", "Asha", "Oberbrunner", "password123", 2, "Boris.Kulas67" },
                    { 264, 17, "Jayden84@gmail.com", "Jules", "Smith", "password123", 2, "Evelyn_Stark" },
                    { 108, 79, "Carmelo.Hettinger7@hotmail.com", "Theresa", "Pfannerstill", "password123", 1, "Deontae75" },
                    { 23, 188, "Dusty.Kessler92@yahoo.com", "Emerald", "Raynor", "password123", 1, "Nannie_Bode50" },
                    { 77, 18, "Lydia.Emmerich35@hotmail.com", "Carmela", "Corwin", "password123", 2, "Georgette.Langosh" },
                    { 2, 279, "Destany.Renner@gmail.com", "Joel", "Purdy", "password123", 3, "Dante.Lindgren38" },
                    { 179, 88, "Ervin51@yahoo.com", "Bernhard", "Carter", "password123", 1, "Elisa.Vandervort" },
                    { 229, 120, "Randall_Powlowski@gmail.com", "Waino", "Schulist", "password123", 3, "Forest91" },
                    { 288, 64, "Cayla.Thompson62@hotmail.com", "Oliver", "Bradtke", "password123", 3, "Meaghan58" },
                    { 73, 186, "Cordell.Fisher62@hotmail.com", "Dusty", "Hessel", "password123", 1, "Gustave_Metz" },
                    { 154, 186, "Loy70@hotmail.com", "Juliet", "Friesen", "password123", 3, "Anabelle83" },
                    { 55, 9, "Berenice.Konopelski@hotmail.com", "Demetris", "Mertz", "password123", 2, "Abbey.Lueilwitz11" },
                    { 7, 92, "Anya.Buckridge73@gmail.com", "Green", "Rutherford", "password123", 1, "Ayana76" },
                    { 232, 178, "Alta.Schmitt45@gmail.com", "Gerda", "Nader", "password123", 1, "Norma91" },
                    { 75, 1, "Kiarra51@hotmail.com", "Vida", "Bruen", "password123", 2, "Fanny.Buckridge" },
                    { 285, 290, "Connie.Rowe@hotmail.com", "Jayce", "Gorczany", "password123", 3, "Electa_Kemmer8" },
                    { 145, 290, "Charity64@hotmail.com", "Isaias", "Baumbach", "password123", 3, "Domenica.Wilderman" },
                    { 31, 290, "Lilian_Jenkins@yahoo.com", "Jessika", "Bradtke", "password123", 1, "Trinity_Crooks" },
                    { 246, 135, "Darrell.Brown@yahoo.com", "Brenda", "Langosh", "password123", 1, "Eudora71" },
                    { 216, 71, "Antoinette.Dare@yahoo.com", "Ewell", "Christiansen", "password123", 1, "Nakia_Yundt20" },
                    { 92, 254, "Lorna_Feil@hotmail.com", "Sydney", "Dach", "password123", 3, "Raven_Braun71" },
                    { 245, 131, "Brandy_Goyette71@gmail.com", "Robb", "Ryan", "password123", 1, "Pearline32" },
                    { 162, 60, "Dock_Gerlach2@hotmail.com", "Willard", "Torp", "password123", 2, "Gertrude.Walsh61" },
                    { 103, 114, "Keyshawn_Romaguera10@hotmail.com", "Vivienne", "Bruen", "password123", 2, "Sarina0" },
                    { 268, 29, "Martina93@hotmail.com", "Mateo", "Lemke", "password123", 3, "Braxton77" },
                    { 259, 29, "Eric_Connelly@yahoo.com", "Genevieve", "Schamberger", "password123", 2, "Gladyce.Abshire20" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 130, 13, "Ozella_Medhurst13@gmail.com", "Velma", "Doyle", "password123", 2, "Camilla_Bruen" },
                    { 24, 13, "Brycen_Turner13@yahoo.com", "Granville", "Beier", "password123", 2, "Lester_Ritchie96" },
                    { 6, 13, "Neva.Boyer12@hotmail.com", "Bud", "Mills", "password123", 1, "Winona_Gottlieb" },
                    { 32, 73, "Albina54@gmail.com", "Karlie", "Gorczany", "password123", 3, "Hadley95" },
                    { 294, 9, "Meda_Boyer7@yahoo.com", "Wilhelm", "Kuhic", "password123", 3, "Heidi82" },
                    { 193, 65, "Aubree35@hotmail.com", "Mason", "Frami", "password123", 2, "Lily_Smith99" },
                    { 83, 190, "Alexys.Konopelski35@gmail.com", "Earline", "Paucek", "password123", 1, "Kyla74" },
                    { 238, 136, "Manuel_Hintz@yahoo.com", "Norval", "Murphy", "password123", 3, "Vladimir_Leannon" },
                    { 287, 66, "Chasity_Lindgren53@gmail.com", "Baylee", "Prosacco", "password123", 1, "Allie84" },
                    { 62, 25, "Aditya.Price86@yahoo.com", "Pete", "Batz", "password123", 3, "Mossie_Ernser88" },
                    { 14, 25, "Glennie_Gulgowski@gmail.com", "Brennon", "Durgan", "password123", 2, "Tyrel97" },
                    { 237, 229, "Madalyn.Rath@gmail.com", "Elna", "Douglas", "password123", 1, "Micaela_Daugherty89" },
                    { 66, 229, "Sheldon3@hotmail.com", "Patience", "Senger", "password123", 1, "Gregg.Ondricka" },
                    { 273, 207, "Elsie_Champlin@yahoo.com", "Tate", "Hettinger", "password123", 3, "Celia3" },
                    { 151, 207, "Alfonso56@gmail.com", "Agustin", "Homenick", "password123", 1, "Bernie.Kirlin22" },
                    { 95, 207, "Vincent27@hotmail.com", "Troy", "Medhurst", "password123", 2, "Deonte_Rohan85" },
                    { 248, 187, "Mariah_Little@hotmail.com", "Antonietta", "Hartmann", "password123", 1, "Luna_Watsica49" },
                    { 209, 187, "Dell_Kuhic23@hotmail.com", "Curtis", "Maggio", "password123", 3, "Isaiah45" },
                    { 144, 187, "Chelsea8@yahoo.com", "Natalie", "Schneider", "password123", 2, "Breanna.Johnston78" },
                    { 17, 187, "Duncan.Schuster21@hotmail.com", "Jaylen", "Connelly", "password123", 3, "Simeon85" },
                    { 278, 38, "Oceane.Mills@gmail.com", "Noble", "McGlynn", "password123", 2, "Freeman_Lang68" },
                    { 239, 283, "Nichole_Waelchi3@gmail.com", "Vivienne", "O'Connell", "password123", 2, "Alden.Mills" },
                    { 200, 163, "Astrid.Volkman@yahoo.com", "Janie", "Carroll", "password123", 1, "Hillary_Marks9" },
                    { 106, 163, "Aidan_Dooley@gmail.com", "Valentin", "Pfeffer", "password123", 1, "Brooke_Windler7" },
                    { 1, 163, "Prudence.Predovic23@hotmail.com", "Irma", "D'Amore", "password123", 2, "Kiana73" },
                    { 26, 177, "Kelly_Franecki@yahoo.com", "Christine", "Gusikowski", "password123", 3, "Vena.Schuppe61" },
                    { 97, 156, "Haskell20@hotmail.com", "Lukas", "Kohler", "password123", 3, "Stefan.Zemlak4" },
                    { 227, 136, "Britney68@yahoo.com", "Eveline", "Conroy", "password123", 2, "Emory_Huels26" },
                    { 19, 65, "Eli_Swift@hotmail.com", "Kaylin", "Gottlieb", "password123", 1, "Chanel93" },
                    { 185, 167, "Burnice17@hotmail.com", "Winfield", "Gleichner", "password123", 1, "Verona_Reichert" },
                    { 109, 167, "Rupert_Pollich@hotmail.com", "Bart", "Ward", "password123", 2, "Leta24" },
                    { 39, 109, "Dena_Kozey@gmail.com", "Bessie", "Champlin", "password123", 1, "Jerel43" },
                    { 299, 281, "Dee_Feeney@hotmail.com", "Gerard", "Stracke", "password123", 2, "Shanie.Graham57" },
                    { 213, 281, "Theodora94@gmail.com", "Nina", "Kris", "password123", 2, "Lisandro.Boyer" },
                    { 186, 281, "Laisha.Rau85@hotmail.com", "Erika", "Friesen", "password123", 3, "Brian.Pollich68" },
                    { 120, 281, "Eliza_Hermiston52@hotmail.com", "Asa", "Jacobs", "password123", 3, "Gloria38" },
                    { 156, 191, "Vickie_Collins@hotmail.com", "Johnson", "Dickinson", "password123", 3, "Leon72" },
                    { 67, 191, "Peter.Cummerata@hotmail.com", "Lucienne", "Marks", "password123", 2, "Torrey5" },
                    { 160, 203, "Arielle85@hotmail.com", "Brennon", "Schoen", "password123", 2, "Kenya95" },
                    { 132, 203, "Cole.Cartwright@yahoo.com", "Guillermo", "Goodwin", "password123", 1, "Reanna_Jaskolski" },
                    { 188, 138, "Graham30@yahoo.com", "Darion", "Douglas", "password123", 1, "Josianne78" },
                    { 61, 138, "Vladimir93@yahoo.com", "Kieran", "Metz", "password123", 3, "Marianna.Reynolds23" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 191, 53, "Valentina_Bartoletti27@hotmail.com", "Nicole", "Larson", "password123", 1, "Abbigail90" },
                    { 8, 91, "Emiliano60@yahoo.com", "Concepcion", "Runolfsson", "password123", 3, "Erin94" },
                    { 270, 238, "Onie.Blanda@gmail.com", "Raleigh", "Marks", "password123", 2, "Katharina_Bode" },
                    { 153, 238, "Laurel.Brakus56@hotmail.com", "Kali", "Streich", "password123", 1, "Ines76" },
                    { 94, 276, "Cody_Walter@hotmail.com", "Roel", "Oberbrunner", "password123", 3, "Daija_Cremin29" },
                    { 203, 181, "Adonis.Reynolds20@yahoo.com", "Josephine", "Leannon", "password123", 2, "Karina82" },
                    { 72, 122, "Georgianna.Lockman73@yahoo.com", "Stephen", "Corwin", "password123", 1, "Eileen_Blick7" },
                    { 240, 186, "Rasheed53@hotmail.com", "Terrill", "Schamberger", "password123", 3, "Maye_Rowe" },
                    { 276, 109, "Jamil.Heidenreich63@hotmail.com", "Bridie", "Koss", "password123", 2, "Leonardo_Vandervort12" },
                    { 275, 7, "Chesley_Dibbert26@hotmail.com", "Ariel", "Braun", "password123", 3, "Yasmine.Waters" },
                    { 4, 288, "Madeline_Sanford92@yahoo.com", "Aylin", "Luettgen", "password123", 1, "Stewart28" },
                    { 87, 147, "Raul.Bosco81@gmail.com", "Makenna", "Roberts", "password123", 3, "Lillie19" },
                    { 78, 167, "Jerome.Roberts@gmail.com", "Ben", "Roberts", "password123", 1, "Marlin92" },
                    { 140, 289, "Josiane20@gmail.com", "Ruth", "Batz", "password123", 3, "Shaniya_Kassulke12" },
                    { 53, 272, "Milford.Dach@gmail.com", "Lukas", "O'Connell", "password123", 3, "Aniya.Gaylord" },
                    { 189, 80, "Vallie.Schuster@hotmail.com", "Ross", "Mayert", "password123", 3, "Liam0" },
                    { 280, 57, "Ernest.Yundt87@yahoo.com", "Devin", "Flatley", "password123", 1, "Alberta.Reynolds53" },
                    { 104, 57, "Nina.Monahan76@gmail.com", "Geovany", "Quitzon", "password123", 2, "Dolly.Hane" },
                    { 223, 3, "Kiera.Buckridge@hotmail.com", "Gregoria", "Von", "password123", 1, "Lexie_Torphy" },
                    { 282, 221, "Benton91@hotmail.com", "Eugenia", "Renner", "password123", 1, "Brain_Steuber" },
                    { 150, 219, "Leatha71@gmail.com", "Stephan", "Pacocha", "password123", 3, "Brisa.Satterfield7" },
                    { 242, 277, "Tia_Hirthe@gmail.com", "Conor", "Ritchie", "password123", 1, "Una_Davis" },
                    { 51, 219, "Natalia_Jast@hotmail.com", "Keaton", "Sanford", "password123", 2, "Colin.Crooks41" },
                    { 148, 251, "Richmond26@gmail.com", "Jarrett", "Stark", "password123", 3, "Oral_Kerluke68" },
                    { 182, 37, "Kyra.Emard71@yahoo.com", "Cary", "Dickens", "password123", 2, "Ashlynn14" },
                    { 40, 37, "Jakayla_Bednar@yahoo.com", "Darrick", "Bechtelar", "password123", 1, "Gust4" },
                    { 211, 248, "Camille24@yahoo.com", "Bryon", "Schinner", "password123", 3, "Alyson1" },
                    { 252, 234, "Elmira40@yahoo.com", "Brody", "Heller", "password123", 2, "Erling_Price38" },
                    { 181, 234, "Nadia_Greenfelder@yahoo.com", "Ola", "Bins", "password123", 3, "Kaya_Quitzon90" },
                    { 215, 262, "Allan_Herman97@hotmail.com", "Raoul", "McCullough", "password123", 3, "Jeffry.Russel16" },
                    { 228, 147, "Adelle.Kessler@hotmail.com", "Joana", "Weimann", "password123", 3, "Joanne_Friesen3" },
                    { 208, 147, "Lourdes_Considine@gmail.com", "Kaci", "Pacocha", "password123", 3, "Nicholaus68" },
                    { 214, 251, "Enola.Strosin@gmail.com", "Garett", "Parisian", "password123", 3, "Maybelle.Weimann" },
                    { 18, 34, "Ford.Gerlach@hotmail.com", "Rowena", "Haley", "password123", 2, "Amalia_Block" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 3, "Grimes Islands", 13, "Abdiel_Dibbert62@yahoo.com", "Hilpert - Koepp", 164, "(447) 983-7235", "www.Hilpert - Koepp.com" },
                    { 61, "Romaine Course", 227, "Calista96@hotmail.com", "Hermiston - Yundt", 285, "(383) 064-4584", "www.Hermiston - Yundt.com" },
                    { 84, "Raynor Rest", 235, "Hermann.Abbott86@gmail.com", "Botsford, Turcotte and Schmitt", 285, "(090) 801-7374", "www.Botsford, Turcotte and Schmitt.com" },
                    { 125, "Katelyn Plain", 50, "Alek_Mayer9@yahoo.com", "Daugherty, Wehner and Flatley", 285, "(438) 338-9323", "www.Daugherty, Wehner and Flatley.com" },
                    { 127, "Ebert Light", 139, "Theresia_Weber66@yahoo.com", "Funk, Mann and Bruen", 285, "(957) 073-0537", "www.Funk, Mann and Bruen.com" },
                    { 132, "Kaela Mountain", 38, "Russell95@hotmail.com", "Schinner Group", 285, "(230) 170-2335", "www.Schinner Group.com" },
                    { 73, "Theo Summit", 141, "Schuyler_Berge39@hotmail.com", "Nienow - Koelpin", 294, "(234) 173-1965", "www.Nienow - Koelpin.com" },
                    { 87, "Conroy Corner", 257, "Tad.Klein79@hotmail.com", "Bosco - Auer", 145, "(555) 462-2068", "www.Bosco - Auer.com" },
                    { 44, "Daphnee Coves", 44, "Salma23@gmail.com", "Runolfsson LLC", 238, "(001) 277-9540", "www.Runolfsson LLC.com" },
                    { 149, "Heller Extension", 215, "Cale.Hirthe43@hotmail.com", "Aufderhar, Altenwerth and Hoeger", 97, "(679) 886-3871", "www.Aufderhar, Altenwerth and Hoeger.com" },
                    { 88, "Lyla Plains", 296, "Oscar.Schuppe78@yahoo.com", "Kuhn Group", 209, "(036) 228-2060", "www.Kuhn Group.com" },
                    { 104, "Casandra Grove", 178, "Ayla.Cartwright@hotmail.com", "Becker - Prosacco", 273, "(551) 688-3026", "www.Becker - Prosacco.com" },
                    { 117, "Mayert Keys", 24, "Yvonne_Daniel48@gmail.com", "Jenkins Group", 273, "(927) 415-2907", "www.Jenkins Group.com" },
                    { 130, "Sid Haven", 136, "Sharon_Macejkovic22@hotmail.com", "Lebsack Inc", 273, "(294) 043-6353", "www.Lebsack Inc.com" },
                    { 13, "Romaine Crescent", 248, "Rowland0@gmail.com", "Kassulke, Durgan and Mayer", 247, "(561) 201-6275", "www.Kassulke, Durgan and Mayer.com" },
                    { 140, "Haley Cape", 22, "Estel_Goldner@gmail.com", "Morissette, Marvin and Von", 97, "(712) 717-9762", "www.Morissette, Marvin and Von.com" },
                    { 42, "Sean Spurs", 241, "Fritz.Hyatt26@gmail.com", "Baumbach, Rutherford and Simonis", 92, "(708) 122-1960", "www.Baumbach, Rutherford and Simonis.com" },
                    { 100, "Alberta View", 139, "Adah.Weber18@yahoo.com", "Lemke Inc", 268, "(267) 530-2298", "www.Lemke Inc.com" },
                    { 91, "Rae Falls", 150, "Morgan_McClure@yahoo.com", "Jaskolski, Goldner and Shanahan", 268, "(504) 084-2482", "www.Jaskolski, Goldner and Shanahan.com" },
                    { 109, "Antone Trace", 98, "Bryana27@hotmail.com", "Kemmer, Spinka and Hagenes", 148, "(212) 649-6688", "www.Kemmer, Spinka and Hagenes.com" },
                    { 142, "Jaydon Canyon", 277, "Adrian.Breitenberg@yahoo.com", "Satterfield - Feest", 148, "(733) 090-5337", "www.Satterfield - Feest.com" },
                    { 18, "Garland Garden", 237, "Roxanne.Wehner23@hotmail.com", "Gleichner LLC", 214, "(118) 621-8254", "www.Gleichner LLC.com" },
                    { 77, "Nitzsche Unions", 104, "Eldred_Zboncak65@gmail.com", "Bechtelar - Hirthe", 214, "(358) 067-0343", "www.Bechtelar - Hirthe.com" },
                    { 113, "Priscilla Green", 106, "Jayce.Ritchie72@hotmail.com", "Little, Huels and Bogisich", 189, "(274) 521-5866", "www.Little, Huels and Bogisich.com" },
                    { 118, "Littel Place", 294, "Kitty.Boyer58@gmail.com", "Parker, Zieme and Koss", 189, "(404) 212-7728", "www.Parker, Zieme and Koss.com" },
                    { 12, "Terry Street", 46, "Kamryn_Lowe67@yahoo.com", "Hansen and Sons", 140, "(385) 546-8760", "www.Hansen and Sons.com" },
                    { 21, "Bettye Wells", 194, "Whitney_Cole5@yahoo.com", "Hessel and Sons", 140, "(361) 857-8472", "www.Hessel and Sons.com" },
                    { 63, "Santos Fall", 61, "Carmela_Grady@gmail.com", "Reichel, Bartell and Medhurst", 140, "(589) 837-4906", "www.Reichel, Bartell and Medhurst.com" },
                    { 110, "Bethany Well", 71, "Kristoffer56@gmail.com", "Stehr - Wintheiser", 140, "(446) 088-0919", "www.Stehr - Wintheiser.com" },
                    { 128, "Reilly Prairie", 237, "Christiana54@gmail.com", "Sawayn - Witting", 140, "(641) 982-7504", "www.Sawayn - Witting.com" },
                    { 46, "Cyrus Center", 201, "Devyn58@gmail.com", "Nikolaus and Sons", 32, "(624) 921-9813", "www.Nikolaus and Sons.com" },
                    { 111, "Pascale Expressway", 67, "Winifred_Schoen94@hotmail.com", "Hills LLC", 32, "(427) 836-1394", "www.Hills LLC.com" },
                    { 116, "Gaetano Plains", 281, "Sonya80@gmail.com", "Hauck Group", 32, "(108) 020-2037", "www.Hauck Group.com" },
                    { 66, "Oda Squares", 37, "Marilyne_Collier59@hotmail.com", "Hartmann, Kihn and Reichert", 268, "(918) 845-0221", "www.Hartmann, Kihn and Reichert.com" },
                    { 23, "Welch Knoll", 6, "Lizeth_Ledner97@hotmail.com", "Stanton, Fisher and Lindgren", 247, "(917) 107-8978", "www.Stanton, Fisher and Lindgren.com" },
                    { 114, "Conroy Skyway", 46, "Helmer35@hotmail.com", "Prosacco Group", 155, "(161) 429-3012", "www.Prosacco Group.com" },
                    { 121, "Herman Skyway", 196, "Jamar88@gmail.com", "Hackett Inc", 155, "(201) 730-9974", "www.Hackett Inc.com" },
                    { 144, "Arturo Mall", 245, "Willy_Zulauf@yahoo.com", "Rolfson Inc", 5, "(115) 445-4311", "www.Rolfson Inc.com" },
                    { 34, "Kobe Stravenue", 174, "Brooklyn.Heidenreich87@gmail.com", "Vandervort, Macejkovic and Legros", 174, "(538) 118-5263", "www.Vandervort, Macejkovic and Legros.com" },
                    { 108, "Gusikowski Corners", 214, "Melisa89@hotmail.com", "Morar - Shanahan", 174, "(585) 315-2412", "www.Morar - Shanahan.com" },
                    { 71, "Clair Light", 35, "Talia29@yahoo.com", "Kiehn - Williamson", 101, "(634) 711-0562", "www.Kiehn - Williamson.com" },
                    { 86, "Guiseppe Squares", 47, "Jana_Lesch14@yahoo.com", "Jacobs, Zieme and Maggio", 101, "(670) 621-8400", "www.Jacobs, Zieme and Maggio.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 139, "Osinski Point", 92, "Ludie_Smith@hotmail.com", "Schaden - Berge", 169, "(292) 720-9825", "www.Schaden - Berge.com" },
                    { 54, "Elisabeth Wall", 241, "Fidel56@hotmail.com", "Gusikowski and Sons", 254, "(097) 915-4329", "www.Gusikowski and Sons.com" },
                    { 6, "General Corner", 146, "Justus38@gmail.com", "Blick, Sawayn and Kulas", 286, "(071) 562-9079", "www.Blick, Sawayn and Kulas.com" },
                    { 105, "Parisian Plain", 91, "Kaelyn78@yahoo.com", "Jakubowski - Lebsack", 286, "(573) 298-8771", "www.Jakubowski - Lebsack.com" },
                    { 80, "Lucinda Locks", 25, "Arjun95@yahoo.com", "Haley, Runte and Mertz", 177, "(492) 874-7980", "www.Haley, Runte and Mertz.com" },
                    { 20, "Kunze Extension", 191, "Viola_Ferry31@gmail.com", "Bosco, Swift and King", 59, "(642) 948-1779", "www.Bosco, Swift and King.com" },
                    { 94, "Kuhlman Street", 248, "Dena.Brakus@hotmail.com", "Wehner Inc", 59, "(439) 043-5288", "www.Wehner Inc.com" },
                    { 40, "Aidan Dam", 161, "Izabella.Kemmer@hotmail.com", "Sauer, Sawayn and White", 198, "(388) 663-1599", "www.Sauer, Sawayn and White.com" },
                    { 45, "Della Garden", 266, "Brian44@gmail.com", "Wiegand, Nolan and Berge", 198, "(066) 723-4415", "www.Wiegand, Nolan and Berge.com" },
                    { 57, "Horacio Squares", 53, "Dudley32@gmail.com", "Ondricka Inc", 217, "(010) 033-8576", "www.Ondricka Inc.com" },
                    { 29, "Mittie Mills", 77, "Keon.Schulist@gmail.com", "Baumbach - Connelly", 133, "(865) 789-9397", "www.Baumbach - Connelly.com" },
                    { 30, "Luettgen Square", 278, "Iliana14@gmail.com", "Schuppe Group", 174, "(809) 899-7427", "www.Schuppe Group.com" },
                    { 106, "Moore Village", 256, "Kianna40@yahoo.com", "Torphy Inc", 148, "(607) 776-7111", "www.Torphy Inc.com" },
                    { 25, "Zakary Drive", 168, "Damian33@hotmail.com", "Fahey, Mayer and Fisher", 174, "(720) 982-6772", "www.Fahey, Mayer and Fisher.com" },
                    { 64, "Reichel Lights", 244, "Javier.Breitenberg@yahoo.com", "Yost and Sons", 284, "(875) 673-6141", "www.Yost and Sons.com" },
                    { 37, "Funk Ferry", 140, "Delphine.Wilkinson23@yahoo.com", "Erdman, Schmidt and Walsh", 127, "(658) 897-4080", "www.Erdman, Schmidt and Walsh.com" },
                    { 11, "Trantow Forest", 42, "Sabrina.Bahringer@yahoo.com", "Jones Group", 100, "(619) 037-5548", "www.Jones Group.com" },
                    { 26, "Jany Unions", 260, "Itzel24@yahoo.com", "Bashirian, Auer and Sauer", 100, "(458) 115-8553", "www.Bashirian, Auer and Sauer.com" },
                    { 68, "Ledner Brooks", 100, "Jeffrey.Mueller@yahoo.com", "Gerhold - Schroeder", 100, "(763) 817-3867", "www.Gerhold - Schroeder.com" },
                    { 49, "Verla Drives", 264, "Tressa.Funk19@gmail.com", "Doyle, Sanford and Ledner", 166, "(633) 897-7090", "www.Doyle, Sanford and Ledner.com" },
                    { 65, "Breitenberg Centers", 151, "Albin.Morar@hotmail.com", "Mohr LLC", 224, "(299) 490-5626", "www.Mohr LLC.com" },
                    { 16, "Octavia Oval", 292, "Paula_Sporer23@yahoo.com", "Smitham - Schmidt", 173, "(648) 079-7608", "www.Smitham - Schmidt.com" },
                    { 56, "Wintheiser Causeway", 282, "Thad31@hotmail.com", "Heathcote - Swift", 173, "(174) 993-4746", "www.Heathcote - Swift.com" },
                    { 33, "Anibal Estate", 281, "Gaylord.Bergnaum33@gmail.com", "Sanford Group", 235, "(914) 472-3191", "www.Sanford Group.com" },
                    { 58, "Klein Skyway", 31, "Eldon_Bechtelar@hotmail.com", "Welch - Swift", 235, "(476) 774-5785", "www.Welch - Swift.com" },
                    { 69, "Huels Trafficway", 135, "Virginie14@gmail.com", "Huels - Schuster", 235, "(823) 855-3550", "www.Huels - Schuster.com" },
                    { 28, "Purdy Stream", 197, "Hayley_Vandervort@gmail.com", "Rohan - Terry", 98, "(883) 451-7003", "www.Rohan - Terry.com" },
                    { 48, "Zella Course", 85, "Cecelia37@yahoo.com", "Dach, Zemlak and Bins", 225, "(381) 805-5876", "www.Dach, Zemlak and Bins.com" },
                    { 85, "Stanton Union", 256, "Mattie48@hotmail.com", "Steuber - Balistreri", 187, "(463) 391-5155", "www.Steuber - Balistreri.com" },
                    { 36, "Johnston Throughway", 193, "Jackson78@yahoo.com", "Wilkinson - Weimann", 284, "(159) 509-9160", "www.Wilkinson - Weimann.com" },
                    { 83, "Streich Park", 233, "Jordane_Carter6@gmail.com", "Pollich - Brekke", 284, "(324) 397-9674", "www.Pollich - Brekke.com" },
                    { 122, "Krista Camp", 110, "Andre.Mills60@hotmail.com", "Ryan LLC", 181, "(748) 298-6686", "www.Ryan LLC.com" },
                    { 147, "Hirthe Light", 164, "Johanna_Kuphal@gmail.com", "Cole Inc", 224, "(949) 327-2750", "www.Cole Inc.com" },
                    { 107, "Pfeffer Fort", 5, "Annalise96@gmail.com", "Jast Inc", 215, "(469) 841-2446", "www.Jast Inc.com" },
                    { 15, "Jeanette Pines", 166, "Alfonso_Bruen71@yahoo.com", "Quitzon - Lueilwitz", 36, "(486) 375-3150", "www.Quitzon - Lueilwitz.com" },
                    { 102, "Kyleigh Canyon", 80, "Lynn.Gaylord@hotmail.com", "Willms Inc", 36, "(732) 239-0276", "www.Willms Inc.com" },
                    { 131, "Retha Pass", 46, "Parker.Smitham@hotmail.com", "Littel, Swaniawski and Lebsack", 36, "(986) 541-2737", "www.Littel, Swaniawski and Lebsack.com" },
                    { 141, "Adelia Court", 47, "Camryn_OConner@hotmail.com", "Witting - Rodriguez", 298, "(877) 781-2263", "www.Witting - Rodriguez.com" },
                    { 51, "Roob Springs", 172, "Carroll.Quigley92@gmail.com", "Hermann Group", 35, "(409) 408-9215", "www.Hermann Group.com" },
                    { 93, "Gusikowski Roads", 247, "Schuyler.Gleason89@hotmail.com", "Hamill and Sons", 35, "(201) 952-9333", "www.Hamill and Sons.com" },
                    { 47, "Wava Meadow", 207, "Hosea20@hotmail.com", "Stehr - Morissette", 21, "(291) 673-0984", "www.Stehr - Morissette.com" },
                    { 35, "Theodora Orchard", 260, "Mikel_Hermiston48@hotmail.com", "O'Kon - Rogahn", 105, "(579) 981-0298", "www.O'Kon - Rogahn.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 145, "Fidel Trail", 215, "Christelle_Wehner@gmail.com", "Lesch - Lindgren", 105, "(655) 163-9694", "www.Lesch - Lindgren.com" },
                    { 43, "Mohamed Hill", 6, "Keely97@hotmail.com", "Weber - Prosacco", 143, "(912) 244-8300", "www.Weber - Prosacco.com" },
                    { 78, "Mariam Estate", 141, "Christine_Homenick@gmail.com", "Emard, Ebert and Klocko", 212, "(057) 668-4737", "www.Emard, Ebert and Klocko.com" },
                    { 101, "Turner Greens", 258, "Barbara77@hotmail.com", "Volkman - Hamill", 212, "(931) 603-7891", "www.Volkman - Hamill.com" },
                    { 4, "Tiara Knoll", 239, "Jamarcus_Walsh74@gmail.com", "Balistreri - Graham", 122, "(443) 574-1591", "www.Balistreri - Graham.com" },
                    { 19, "Schmitt Oval", 260, "Tanya.Buckridge@gmail.com", "Kessler, Cassin and Pouros", 122, "(466) 062-3490", "www.Kessler, Cassin and Pouros.com" },
                    { 59, "Kip Grove", 257, "Lemuel15@hotmail.com", "Skiles and Sons", 122, "(127) 682-8960", "www.Skiles and Sons.com" },
                    { 95, "Dorian Gardens", 254, "Stacy.Block49@hotmail.com", "Sawayn, Jacobs and Wuckert", 22, "(614) 624-3218", "www.Sawayn, Jacobs and Wuckert.com" },
                    { 60, "Heath Walks", 286, "Mavis61@hotmail.com", "Feest, Stiedemann and Larkin", 122, "(772) 624-1562", "www.Feest, Stiedemann and Larkin.com" },
                    { 137, "Bruen Harbors", 293, "Harrison.King@hotmail.com", "Wuckert, Carter and Lindgren", 69, "(101) 192-0141", "www.Wuckert, Carter and Lindgren.com" },
                    { 119, "Kub Square", 36, "Seamus_Lind19@hotmail.com", "Dietrich - Crooks", 69, "(602) 738-0570", "www.Dietrich - Crooks.com" },
                    { 62, "Witting Squares", 212, "Hanna14@hotmail.com", "Gleason Inc", 181, "(114) 332-2404", "www.Gleason Inc.com" },
                    { 53, "Presley Tunnel", 287, "Royal2@yahoo.com", "D'Amore, Effertz and Murazik", 164, "(032) 127-6296", "www.D'Amore, Effertz and Murazik.com" },
                    { 17, "Hermann Roads", 125, "Frederic55@gmail.com", "Will LLC", 210, "(752) 861-4098", "www.Will LLC.com" },
                    { 74, "Silas Corners", 252, "Tremayne_Hermann@hotmail.com", "Moen Group", 210, "(313) 128-5818", "www.Moen Group.com" },
                    { 92, "Joshuah Manors", 46, "Blaze.Shanahan@gmail.com", "DuBuque - Huels", 210, "(130) 596-8327", "www.DuBuque - Huels.com" },
                    { 112, "Nicole Course", 109, "Lurline59@hotmail.com", "Nolan - Corkery", 210, "(553) 181-4708", "www.Nolan - Corkery.com" },
                    { 97, "Skye Mews", 233, "Laura48@gmail.com", "Wolff Group", 125, "(447) 242-5927", "www.Wolff Group.com" },
                    { 150, "Everette Junction", 107, "Abbigail29@hotmail.com", "Kuvalis and Sons", 229, "(424) 439-3906", "www.Kuvalis and Sons.com" },
                    { 70, "Koss Plain", 52, "Skylar30@hotmail.com", "Nikolaus Inc", 2, "(140) 644-2923", "www.Nikolaus Inc.com" },
                    { 75, "MacGyver Burgs", 224, "Meghan24@gmail.com", "Sipes, Hahn and Bartoletti", 2, "(374) 511-4175", "www.Sipes, Hahn and Bartoletti.com" },
                    { 90, "MacGyver Isle", 170, "Dusty_Kilback@yahoo.com", "Gibson, Skiles and Goldner", 2, "(790) 155-1686", "www.Gibson, Skiles and Goldner.com" },
                    { 1, "O'Hara Squares", 52, "Genesis51@yahoo.com", "Pacocha - Parker", 291, "(928) 692-3398", "www.Pacocha - Parker.com" },
                    { 5, "Frederik Branch", 93, "Jeff.Strosin@gmail.com", "Paucek - Jenkins", 90, "(343) 993-9044", "www.Paucek - Jenkins.com" },
                    { 41, "Nienow Motorway", 170, "Lucile38@hotmail.com", "Reinger LLC", 90, "(388) 071-0792", "www.Reinger LLC.com" },
                    { 148, "Beverly Avenue", 277, "Agustin35@gmail.com", "Douglas Inc", 90, "(900) 703-7846", "www.Douglas Inc.com" },
                    { 136, "O'Conner Rest", 221, "Stacey36@gmail.com", "Bergstrom, Bogan and Ferry", 69, "(260) 587-7283", "www.Bergstrom, Bogan and Ferry.com" },
                    { 50, "Niko Fall", 23, "Tina.Yost8@hotmail.com", "Daugherty - Sanford", 96, "(010) 482-2106", "www.Daugherty - Sanford.com" },
                    { 76, "Prince Mews", 290, "Wava36@yahoo.com", "Wunsch - Windler", 69, "(860) 842-8948", "www.Wunsch - Windler.com" },
                    { 9, "Karina Meadows", 154, "Sister.Ratke95@yahoo.com", "Feest and Sons", 250, "(802) 435-8830", "www.Feest and Sons.com" },
                    { 138, "Rollin Mountain", 68, "Gaylord_Parisian@yahoo.com", "Weissnat, Krajcik and Feeney", 156, "(423) 339-5255", "www.Weissnat, Krajcik and Feeney.com" },
                    { 79, "Douglas Inlet", 182, "Nico_Leffler@yahoo.com", "Berge, Okuneva and Rath", 120, "(303) 876-5355", "www.Berge, Okuneva and Rath.com" },
                    { 81, "Johnston Shoals", 187, "Marietta83@yahoo.com", "Wunsch - Bartoletti", 120, "(819) 384-3702", "www.Wunsch - Bartoletti.com" },
                    { 10, "Kenya Harbors", 209, "Emiliano.Klein66@yahoo.com", "McDermott and Sons", 186, "(842) 503-5841", "www.McDermott and Sons.com" },
                    { 52, "Sallie Greens", 191, "Brock_Cole@hotmail.com", "Bechtelar Inc", 186, "(420) 331-5882", "www.Bechtelar Inc.com" },
                    { 146, "Weimann Views", 102, "Raoul46@yahoo.com", "Boehm, Koss and Nader", 186, "(720) 414-7756", "www.Boehm, Koss and Nader.com" },
                    { 72, "Irving Grove", 58, "Nickolas.Crona79@gmail.com", "Adams Group", 87, "(382) 325-9667", "www.Adams Group.com" },
                    { 82, "Heaney Springs", 92, "Baron_Walker@hotmail.com", "Hudson Inc", 87, "(087) 910-2194", "www.Hudson Inc.com" },
                    { 98, "Watsica Hollow", 12, "Kailyn.Weissnat@yahoo.com", "Konopelski LLC", 87, "(204) 135-0477", "www.Konopelski LLC.com" },
                    { 120, "Boyle Alley", 181, "Gustave.Hahn80@gmail.com", "Grimes - Smitham", 87, "(991) 700-8982", "www.Grimes - Smitham.com" },
                    { 39, "Avis Drive", 71, "Consuelo_Schiller46@hotmail.com", "Doyle, Hills and Paucek", 208, "(560) 893-5306", "www.Doyle, Hills and Paucek.com" },
                    { 99, "Legros Fields", 78, "Bert.Erdman@hotmail.com", "Johns - Weimann", 208, "(429) 504-4650", "www.Johns - Weimann.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 123, "Felton Landing", 294, "Anita78@hotmail.com", "Becker LLC", 208, "(670) 434-8945", "www.Becker LLC.com" },
                    { 126, "Aubree Creek", 279, "Abbie_Kuhic50@gmail.com", "Sauer - Kris", 96, "(686) 583-3199", "www.Sauer - Kris.com" },
                    { 55, "Dare Expressway", 238, "Roger_Lebsack29@yahoo.com", "Osinski - Hauck", 228, "(290) 657-2647", "www.Osinski - Hauck.com" },
                    { 135, "Steuber Parks", 197, "Lane35@yahoo.com", "Rau - Reinger", 156, "(254) 873-4211", "www.Rau - Reinger.com" },
                    { 124, "Champlin Shore", 158, "Elise.Hills14@gmail.com", "Okuneva, Kassulke and Skiles", 156, "(128) 144-9433", "www.Okuneva, Kassulke and Skiles.com" },
                    { 8, "Penelope Stream", 224, "Tara_Hand@hotmail.com", "Brekke, Ryan and Deckow", 87, "(660) 558-7973", "www.Brekke, Ryan and Deckow.com" },
                    { 143, "Walker Highway", 23, "Belle8@yahoo.com", "Parisian Inc", 8, "(254) 056-4930", "www.Parisian Inc.com" },
                    { 24, "Lambert Mills", 19, "Hailie68@gmail.com", "Koch LLC", 250, "(805) 069-4338", "www.Koch LLC.com" },
                    { 129, "Kshlerin Harbor", 3, "Beverly92@gmail.com", "Gorczany - Gleichner", 61, "(259) 325-1148", "www.Gorczany - Gleichner.com" },
                    { 27, "Elton Hill", 147, "Marcelle_Christiansen@yahoo.com", "Johns, Friesen and Hickle", 250, "(425) 369-4612", "www.Johns, Friesen and Hickle.com" },
                    { 67, "Ryan Fords", 264, "Clair.Rosenbaum@hotmail.com", "Jerde Inc", 250, "(331) 568-8942", "www.Jerde Inc.com" },
                    { 22, "Schroeder Ramp", 221, "Cathy35@yahoo.com", "Walker - Heaney", 288, "(163) 972-3419", "www.Walker - Heaney.com" },
                    { 31, "O'Reilly Turnpike", 52, "Ursula24@gmail.com", "Kerluke, Hayes and Volkman", 288, "(690) 183-6108", "www.Kerluke, Hayes and Volkman.com" },
                    { 32, "Alivia Track", 163, "Magdalen60@yahoo.com", "Reinger, Ryan and Schmidt", 288, "(062) 202-8470", "www.Reinger, Ryan and Schmidt.com" },
                    { 96, "Emil Throughway", 115, "Tressie_Hagenes@hotmail.com", "Keeling - Zemlak", 288, "(774) 717-3799", "www.Keeling - Zemlak.com" },
                    { 14, "Randall Branch", 16, "Johnathon_Macejkovic62@hotmail.com", "Bailey - Mitchell", 250, "(974) 651-9542", "www.Bailey - Mitchell.com" },
                    { 2, "Aryanna Inlet", 35, "Narciso.Bednar60@gmail.com", "McGlynn - O'Reilly", 154, "(136) 831-2236", "www.McGlynn - O'Reilly.com" },
                    { 134, "Towne Island", 129, "Rocio_Paucek20@yahoo.com", "Collier and Sons", 154, "(851) 911-8676", "www.Collier and Sons.com" },
                    { 38, "Larson Drive", 183, "Belle_Trantow@gmail.com", "Kunze Inc", 240, "(396) 580-0979", "www.Kunze Inc.com" },
                    { 103, "Deion Row", 65, "Forest_Weimann90@gmail.com", "Rosenbaum, Brakus and Nicolas", 240, "(025) 216-1291", "www.Rosenbaum, Brakus and Nicolas.com" },
                    { 7, "Gulgowski Fall", 178, "Gene.Durgan@yahoo.com", "Boyle, Volkman and Schimmel", 8, "(484) 114-4368", "www.Boyle, Volkman and Schimmel.com" },
                    { 89, "Garnet Orchard", 140, "Ocie_Runte@gmail.com", "Kessler Inc", 8, "(664) 872-5206", "www.Kessler Inc.com" },
                    { 115, "Liam Way", 182, "Letha23@gmail.com", "Sporer, Witting and Bernier", 8, "(167) 480-4905", "www.Sporer, Witting and Bernier.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 22, new DateTime(2021, 3, 3, 10, 11, 42, 618, DateTimeKind.Local).AddTicks(7226), 663984, 67, "9785776" },
                    { 49, new DateTime(2021, 7, 13, 20, 8, 39, 739, DateTimeKind.Local).AddTicks(8178), 192608, 49, "8396798" },
                    { 93, new DateTime(2021, 6, 4, 21, 48, 21, 622, DateTimeKind.Local).AddTicks(1462), 154512, 80, "4071509" },
                    { 68, new DateTime(2020, 11, 19, 20, 51, 53, 355, DateTimeKind.Local).AddTicks(1432), 986971, 17, "2961982" },
                    { 6, new DateTime(2020, 12, 5, 6, 8, 48, 999, DateTimeKind.Local).AddTicks(985), 89457, 17, "8112126" },
                    { 5, new DateTime(2021, 2, 10, 6, 24, 45, 492, DateTimeKind.Local).AddTicks(8416), 142005, 17, "2601061" },
                    { 60, new DateTime(2020, 10, 28, 20, 44, 33, 132, DateTimeKind.Local).AddTicks(7621), 279685, 67, "4699867" },
                    { 41, new DateTime(2020, 10, 18, 6, 28, 29, 965, DateTimeKind.Local).AddTicks(2863), 546557, 80, "9972535" },
                    { 57, new DateTime(2020, 9, 3, 16, 34, 21, 504, DateTimeKind.Local).AddTicks(4532), 764747, 49, "8487061" },
                    { 84, new DateTime(2021, 6, 9, 3, 50, 19, 123, DateTimeKind.Local).AddTicks(7978), 911788, 3, "4907729" },
                    { 45, new DateTime(2021, 1, 2, 8, 19, 53, 843, DateTimeKind.Local).AddTicks(694), 500706, 32, "5453913" },
                    { 63, new DateTime(2020, 11, 10, 10, 31, 27, 456, DateTimeKind.Local).AddTicks(9650), 500529, 68, "8750306" },
                    { 8, new DateTime(2021, 6, 27, 22, 22, 44, 211, DateTimeKind.Local).AddTicks(7279), 532382, 68, "7623461" },
                    { 24, new DateTime(2020, 11, 18, 5, 33, 43, 792, DateTimeKind.Local).AddTicks(4709), 319590, 100, "6519336" },
                    { 14, new DateTime(2021, 4, 14, 12, 36, 34, 985, DateTimeKind.Local).AddTicks(5953), 669221, 10, "1754532" },
                    { 36, new DateTime(2021, 2, 22, 19, 31, 4, 558, DateTimeKind.Local).AddTicks(5667), 137973, 46, "4769909" },
                    { 85, new DateTime(2021, 1, 17, 17, 50, 33, 71, DateTimeKind.Local).AddTicks(4991), 709053, 63, "1237659" },
                    { 19, new DateTime(2020, 9, 22, 13, 36, 30, 492, DateTimeKind.Local).AddTicks(6844), 776897, 25, "9831546" },
                    { 38, new DateTime(2021, 5, 18, 11, 30, 25, 140, DateTimeKind.Local).AddTicks(6548), 318858, 27, "4693691" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 20, new DateTime(2021, 4, 15, 12, 56, 29, 341, DateTimeKind.Local).AddTicks(3572), 738123, 67, "7158490" },
                    { 91, new DateTime(2021, 7, 27, 4, 0, 55, 731, DateTimeKind.Local).AddTicks(8801), 539204, 25, "7570340" },
                    { 26, new DateTime(2021, 2, 24, 6, 2, 7, 506, DateTimeKind.Local).AddTicks(7935), 32120, 64, "3878349" },
                    { 40, new DateTime(2021, 1, 29, 14, 2, 46, 386, DateTimeKind.Local).AddTicks(9185), 264598, 33, "3801167" },
                    { 65, new DateTime(2020, 9, 26, 15, 55, 15, 85, DateTimeKind.Local).AddTicks(6613), 136797, 6, "1258788" },
                    { 39, new DateTime(2021, 4, 20, 19, 50, 21, 113, DateTimeKind.Local).AddTicks(3976), 137130, 63, "7114754" },
                    { 53, new DateTime(2021, 5, 10, 20, 10, 50, 787, DateTimeKind.Local).AddTicks(1202), 192084, 61, "3957850" },
                    { 16, new DateTime(2021, 3, 10, 6, 48, 19, 835, DateTimeKind.Local).AddTicks(6008), 842732, 61, "9045823" },
                    { 32, new DateTime(2021, 1, 14, 5, 10, 7, 548, DateTimeKind.Local).AddTicks(1552), 789692, 15, "4978506" },
                    { 10, new DateTime(2020, 11, 17, 14, 11, 27, 287, DateTimeKind.Local).AddTicks(6780), 561672, 15, "2994648" },
                    { 18, new DateTime(2021, 5, 24, 3, 59, 21, 245, DateTimeKind.Local).AddTicks(2516), 81547, 30, "8766157" },
                    { 61, new DateTime(2021, 3, 13, 20, 2, 6, 922, DateTimeKind.Local).AddTicks(5958), 890844, 82, "7296623" },
                    { 50, new DateTime(2021, 4, 28, 22, 15, 47, 338, DateTimeKind.Local).AddTicks(2446), 964154, 82, "9658225" },
                    { 30, new DateTime(2021, 6, 1, 13, 1, 4, 18, DateTimeKind.Local).AddTicks(2731), 693327, 33, "7057709" },
                    { 31, new DateTime(2021, 1, 8, 10, 54, 32, 707, DateTimeKind.Local).AddTicks(3260), 193401, 35, "4133488" },
                    { 3, new DateTime(2021, 3, 12, 13, 15, 51, 499, DateTimeKind.Local).AddTicks(684), 759971, 35, "8517837" },
                    { 83, new DateTime(2020, 9, 25, 17, 17, 24, 972, DateTimeKind.Local).AddTicks(3579), 457192, 7, "8573214" },
                    { 76, new DateTime(2020, 11, 16, 16, 22, 49, 69, DateTimeKind.Local).AddTicks(4029), 760171, 7, "9747470" },
                    { 56, new DateTime(2021, 8, 25, 2, 7, 44, 662, DateTimeKind.Local).AddTicks(8625), 650500, 19, "5550813" },
                    { 75, new DateTime(2021, 8, 18, 7, 8, 36, 636, DateTimeKind.Local).AddTicks(5910), 398159, 40, "6327865" },
                    { 42, new DateTime(2021, 7, 8, 3, 55, 3, 318, DateTimeKind.Local).AddTicks(5417), 225952, 69, "6216952" },
                    { 7, new DateTime(2020, 8, 30, 16, 41, 35, 630, DateTimeKind.Local).AddTicks(4022), 746037, 69, "4803637" },
                    { 12, new DateTime(2020, 12, 21, 0, 12, 13, 15, DateTimeKind.Local).AddTicks(5023), 565392, 88, "5477013" },
                    { 87, new DateTime(2021, 5, 21, 21, 59, 2, 329, DateTimeKind.Local).AddTicks(4890), 306872, 33, "2474401" },
                    { 23, new DateTime(2021, 4, 1, 8, 21, 45, 804, DateTimeKind.Local).AddTicks(2526), 818983, 35, "8806144" },
                    { 88, new DateTime(2021, 1, 25, 18, 14, 0, 950, DateTimeKind.Local).AddTicks(1786), 160407, 18, "9508468" },
                    { 71, new DateTime(2020, 11, 13, 8, 16, 28, 854, DateTimeKind.Local).AddTicks(7257), 699846, 41, "8294286" },
                    { 86, new DateTime(2020, 11, 10, 1, 57, 47, 541, DateTimeKind.Local).AddTicks(1099), 656036, 8, "3851387" },
                    { 77, new DateTime(2021, 5, 21, 4, 37, 7, 559, DateTimeKind.Local).AddTicks(6806), 813044, 28, "8268120" },
                    { 90, new DateTime(2021, 4, 11, 1, 32, 29, 251, DateTimeKind.Local).AddTicks(4755), 787347, 23, "7787414" },
                    { 78, new DateTime(2021, 5, 23, 3, 11, 43, 920, DateTimeKind.Local).AddTicks(2423), 673131, 14, "3382774" },
                    { 55, new DateTime(2021, 6, 10, 5, 8, 41, 954, DateTimeKind.Local).AddTicks(845), 341685, 14, "1542995" },
                    { 37, new DateTime(2021, 8, 19, 17, 22, 51, 438, DateTimeKind.Local).AddTicks(3146), 445452, 14, "9608086" },
                    { 35, new DateTime(2021, 7, 26, 21, 16, 8, 318, DateTimeKind.Local).AddTicks(4603), 554890, 14, "8370006" },
                    { 58, new DateTime(2021, 3, 11, 11, 58, 6, 292, DateTimeKind.Local).AddTicks(802), 877558, 12, "3800463" },
                    { 74, new DateTime(2021, 6, 12, 18, 46, 35, 681, DateTimeKind.Local).AddTicks(9939), 766360, 50, "7229736" },
                    { 2, new DateTime(2021, 1, 5, 20, 8, 42, 470, DateTimeKind.Local).AddTicks(5995), 227011, 50, "8016216" },
                    { 81, new DateTime(2021, 8, 7, 5, 5, 16, 57, DateTimeKind.Local).AddTicks(6367), 23276, 28, "8660810" },
                    { 1, new DateTime(2021, 5, 26, 16, 18, 53, 282, DateTimeKind.Local).AddTicks(234), 992719, 50, "8741043" },
                    { 92, new DateTime(2021, 1, 26, 19, 16, 48, 898, DateTimeKind.Local).AddTicks(927), 762210, 98, "8260100" },
                    { 51, new DateTime(2020, 12, 22, 12, 25, 27, 827, DateTimeKind.Local).AddTicks(8343), 187784, 98, "8156822" },
                    { 73, new DateTime(2020, 10, 25, 22, 58, 52, 834, DateTimeKind.Local).AddTicks(2524), 463607, 38, "4320684" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 59, new DateTime(2020, 12, 21, 12, 16, 4, 769, DateTimeKind.Local).AddTicks(6379), 625698, 38, "7168877" },
                    { 44, new DateTime(2021, 2, 24, 13, 39, 51, 585, DateTimeKind.Local).AddTicks(129), 23731, 83, "7148807" },
                    { 25, new DateTime(2021, 4, 13, 9, 27, 9, 366, DateTimeKind.Local).AddTicks(4029), 794991, 36, "6416340" },
                    { 79, new DateTime(2021, 5, 27, 1, 49, 36, 860, DateTimeKind.Local).AddTicks(1442), 261911, 13, "2683103" },
                    { 52, new DateTime(2020, 12, 3, 4, 14, 10, 525, DateTimeKind.Local).AddTicks(7507), 680523, 13, "1472855" },
                    { 11, new DateTime(2021, 3, 18, 4, 27, 14, 543, DateTimeKind.Local).AddTicks(4938), 42270, 66, "5123219" },
                    { 47, new DateTime(2021, 4, 10, 16, 36, 6, 455, DateTimeKind.Local).AddTicks(8520), 632114, 16, "5194913" },
                    { 48, new DateTime(2020, 12, 3, 2, 23, 5, 651, DateTimeKind.Local).AddTicks(6039), 609821, 18, "2041271" },
                    { 21, new DateTime(2020, 10, 20, 19, 50, 59, 266, DateTimeKind.Local).AddTicks(3836), 793119, 54, "4831336" },
                    { 28, new DateTime(2021, 5, 1, 8, 32, 42, 342, DateTimeKind.Local).AddTicks(472), 449292, 72, "6334723" },
                    { 80, new DateTime(2021, 4, 22, 11, 26, 3, 700, DateTimeKind.Local).AddTicks(1225), 903442, 21, "4777170" },
                    { 89, new DateTime(2021, 7, 19, 0, 18, 29, 826, DateTimeKind.Local).AddTicks(227), 661777, 91, "2094591" },
                    { 72, new DateTime(2021, 7, 11, 1, 4, 32, 235, DateTimeKind.Local).AddTicks(806), 176190, 91, "9661052" },
                    { 34, new DateTime(2021, 5, 27, 3, 55, 41, 328, DateTimeKind.Local).AddTicks(3288), 419419, 91, "6146884" },
                    { 17, new DateTime(2021, 8, 23, 0, 16, 2, 571, DateTimeKind.Local).AddTicks(9105), 363573, 5, "9348391" },
                    { 27, new DateTime(2020, 11, 13, 7, 43, 36, 910, DateTimeKind.Local).AddTicks(7447), 66110, 11, "1447757" },
                    { 33, new DateTime(2020, 11, 13, 22, 26, 48, 514, DateTimeKind.Local).AddTicks(3264), 743872, 22, "6479602" },
                    { 4, new DateTime(2021, 4, 2, 15, 14, 21, 586, DateTimeKind.Local).AddTicks(1587), 244719, 22, "6375891" },
                    { 46, new DateTime(2021, 1, 20, 20, 30, 23, 370, DateTimeKind.Local).AddTicks(1551), 797683, 24, "2544551" },
                    { 15, new DateTime(2020, 11, 24, 2, 4, 13, 42, DateTimeKind.Local).AddTicks(5969), 161684, 72, "2482262" },
                    { 67, new DateTime(2021, 8, 17, 10, 44, 37, 478, DateTimeKind.Local).AddTicks(2409), 976224, 29, "4779907" },
                    { 62, new DateTime(2020, 9, 15, 8, 46, 0, 77, DateTimeKind.Local).AddTicks(1570), 169675, 99, "5863341" },
                    { 9, new DateTime(2021, 2, 12, 14, 20, 21, 969, DateTimeKind.Local).AddTicks(3858), 539315, 99, "1903288" },
                    { 70, new DateTime(2020, 10, 27, 15, 17, 53, 874, DateTimeKind.Local).AddTicks(8592), 730200, 86, "2040517" },
                    { 66, new DateTime(2021, 7, 14, 19, 35, 59, 531, DateTimeKind.Local).AddTicks(7561), 864483, 85, "9707471" },
                    { 43, new DateTime(2021, 3, 19, 5, 15, 30, 593, DateTimeKind.Local).AddTicks(3896), 224080, 52, "1027250" },
                    { 69, new DateTime(2021, 1, 17, 14, 7, 22, 791, DateTimeKind.Local).AddTicks(2256), 499888, 4, "9411827" },
                    { 29, new DateTime(2021, 3, 26, 6, 3, 24, 981, DateTimeKind.Local).AddTicks(9409), 362779, 4, "1171228" },
                    { 13, new DateTime(2021, 7, 10, 12, 31, 20, 90, DateTimeKind.Local).AddTicks(5386), 189592, 4, "9709249" },
                    { 64, new DateTime(2020, 11, 21, 8, 26, 30, 624, DateTimeKind.Local).AddTicks(4836), 313047, 72, "9896513" },
                    { 54, new DateTime(2020, 10, 23, 11, 54, 52, 300, DateTimeKind.Local).AddTicks(6836), 261064, 29, "1668287" },
                    { 82, new DateTime(2021, 2, 28, 11, 15, 17, 79, DateTimeKind.Local).AddTicks(8579), 539149, 66, "3745855" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 210, 52, 76, 588144, new DateTime(2021, 2, 8, 4, 58, 26, 718, DateTimeKind.Local).AddTicks(1565), "Architecto velit ducimus tempora excepturi alias fuga qui assumenda quaerat. Sapiente et in minima ea labore temporibus tempora ex nisi. Eligendi est aliquid omnis recusandae non labore. Maiores assumenda totam sunt laudantium ut. Architecto et minima delectus sint dolorum unde. Magnam maiores dolore vel voluptatem porro asperiores minus." },
                    { 51, 88, 123, 870331, new DateTime(2021, 8, 23, 2, 31, 24, 839, DateTimeKind.Local).AddTicks(1329), "Sunt exercitationem qui et. Atque et autem quam molestiae velit aspernatur quis quia. Dolores similique similique aut quia. Nihil enim ipsum libero." },
                    { 190, 88, 90, 752919, new DateTime(2021, 6, 4, 3, 57, 18, 79, DateTimeKind.Local).AddTicks(2055), "Rerum amet qui quia." },
                    { 231, 88, 54, 911333, new DateTime(2021, 6, 17, 18, 39, 45, 291, DateTimeKind.Local).AddTicks(4978), "voluptate" },
                    { 322, 88, 100, 751477, new DateTime(2021, 3, 18, 22, 28, 47, 245, DateTimeKind.Local).AddTicks(4744), "aliquam" },
                    { 376, 88, 82, 230448, new DateTime(2020, 11, 7, 3, 29, 0, 13, DateTimeKind.Local).AddTicks(651), "Sunt ratione qui." },
                    { 382, 88, 41, 650310, new DateTime(2021, 1, 21, 0, 25, 49, 760, DateTimeKind.Local).AddTicks(7620), "et" },
                    { 452, 88, 104, 617372, new DateTime(2021, 5, 10, 11, 55, 50, 249, DateTimeKind.Local).AddTicks(1339), "Incidunt aut ut deserunt ut." },
                    { 493, 88, 31, 118816, new DateTime(2021, 8, 13, 7, 49, 4, 342, DateTimeKind.Local).AddTicks(8793), "Rerum quibusdam adipisci quidem consequatur dolor qui qui quae aut. Voluptas sequi velit porro repellat ad quis laborum. Inventore provident inventore sed nostrum doloremque quasi pariatur voluptate quia. Architecto id eius tempore possimus voluptatum suscipit molestiae maxime." },
                    { 134, 76, 9, 264428, new DateTime(2021, 5, 27, 22, 7, 11, 269, DateTimeKind.Local).AddTicks(2557), "quaerat" },
                    { 118, 76, 82, 889256, new DateTime(2020, 9, 25, 9, 26, 47, 650, DateTimeKind.Local).AddTicks(4689), "Magni deleniti laudantium nam quae debitis deleniti. Officiis atque odio quo possimus. Nisi numquam quas. Magnam aspernatur sed culpa ad et autem asperiores error. Maxime voluptas et delectus ad dolorem id tenetur accusantium." },
                    { 117, 76, 139, 596655, new DateTime(2020, 11, 9, 21, 54, 25, 549, DateTimeKind.Local).AddTicks(5672), "Et doloremque neque quia non sapiente inventore deserunt. Enim exercitationem expedita aspernatur sapiente dolor. Sunt est itaque consequuntur quia itaque unde cumque. Deleniti dicta in nisi in dolorem vero earum. Et iusto quos qui itaque. Accusantium quidem ea ad harum veniam corrupti occaecati." },
                    { 140, 39, 81, 726709, new DateTime(2021, 5, 19, 0, 40, 9, 814, DateTimeKind.Local).AddTicks(1772), "aut" },
                    { 217, 39, 59, 67525, new DateTime(2021, 2, 2, 14, 22, 31, 852, DateTimeKind.Local).AddTicks(4704), "Et reiciendis ad mollitia et.\nSed ut aut non." },
                    { 305, 39, 32, 786921, new DateTime(2020, 12, 1, 5, 5, 33, 763, DateTimeKind.Local).AddTicks(1743), "aut" },
                    { 355, 39, 81, 89744, new DateTime(2021, 4, 26, 13, 24, 12, 723, DateTimeKind.Local).AddTicks(1562), "in" },
                    { 401, 76, 84, 419911, new DateTime(2020, 9, 22, 13, 56, 23, 618, DateTimeKind.Local).AddTicks(3473), "Ad et deserunt.\nQuia molestiae facere voluptatem qui repudiandae." },
                    { 404, 76, 23, 916156, new DateTime(2021, 4, 28, 8, 3, 4, 710, DateTimeKind.Local).AddTicks(2030), "Consequatur sapiente quos laborum in perferendis est." },
                    { 583, 48, 109, 495470, new DateTime(2020, 9, 5, 5, 10, 50, 851, DateTimeKind.Local).AddTicks(7917), "qui" },
                    { 530, 48, 90, 687878, new DateTime(2021, 7, 17, 7, 28, 28, 236, DateTimeKind.Local).AddTicks(1179), "voluptatum" },
                    { 570, 86, 15, 580967, new DateTime(2020, 9, 7, 9, 48, 17, 820, DateTimeKind.Local).AddTicks(4217), "rerum" },
                    { 505, 76, 70, 120816, new DateTime(2020, 10, 26, 17, 49, 28, 329, DateTimeKind.Local).AddTicks(8742), "Omnis deleniti est molestiae aut aut. Natus libero et repellendus non neque. Corrupti ducimus reiciendis velit." },
                    { 463, 76, 127, 724431, new DateTime(2020, 12, 23, 0, 59, 44, 608, DateTimeKind.Local).AddTicks(1626), "Eos in eum ut explicabo voluptatem dicta pariatur et id. Sint necessitatibus non blanditiis praesentium atque quam exercitationem qui nesciunt. Soluta est temporibus voluptatem expedita quos voluptatum. Quo sed quae. Autem nostrum maiores eos voluptatem nihil." },
                    { 451, 76, 24, 973775, new DateTime(2021, 7, 14, 4, 22, 40, 493, DateTimeKind.Local).AddTicks(3466), "Officia culpa ducimus molestias velit asperiores sed voluptatem dolor et." },
                    { 89, 48, 128, 145465, new DateTime(2021, 5, 20, 19, 27, 35, 395, DateTimeKind.Local).AddTicks(7143), "Id ut fuga officiis sit ipsum et aut. Alias voluptatum sint id ut. Saepe nemo et quis et alias eos ab consequatur. Et vel ipsam sed animi unde. Doloremque doloremque possimus. Rerum aliquam sequi eaque aliquid ut id aut est quis." },
                    { 103, 48, 40, 908174, new DateTime(2021, 4, 22, 1, 28, 21, 348, DateTimeKind.Local).AddTicks(2367), "Reiciendis culpa eos quisquam aut.\nItaque accusantium saepe.\nAssumenda rerum excepturi consequuntur.\nEnim aut similique aperiam.\nFacere ut alias consequatur ullam qui amet aut commodi." },
                    { 142, 48, 39, 561850, new DateTime(2021, 6, 7, 21, 54, 21, 649, DateTimeKind.Local).AddTicks(3104), "rerum" },
                    { 471, 39, 121, 795055, new DateTime(2021, 4, 4, 8, 16, 0, 953, DateTimeKind.Local).AddTicks(6780), "Eius nulla architecto quia. Et repellat ut qui rerum fugit est in soluta. Molestiae ut illo rerum incidunt quidem voluptatibus consequatur itaque officiis." },
                    { 299, 48, 57, 426110, new DateTime(2020, 11, 28, 20, 16, 53, 411, DateTimeKind.Local).AddTicks(2016), "Beatae perferendis tempora temporibus. Enim consectetur sapiente facere ut molestiae labore aut. Deserunt molestiae et sapiente. Id molestiae dicta non." },
                    { 409, 48, 90, 526661, new DateTime(2021, 3, 10, 11, 38, 40, 636, DateTimeKind.Local).AddTicks(8280), "Asperiores autem quos." },
                    { 412, 48, 127, 521599, new DateTime(2021, 5, 4, 19, 20, 13, 666, DateTimeKind.Local).AddTicks(5550), "praesentium" },
                    { 439, 48, 35, 265777, new DateTime(2020, 10, 3, 9, 42, 51, 737, DateTimeKind.Local).AddTicks(3088), "Magni vero delectus omnis non." },
                    { 450, 48, 57, 727045, new DateTime(2021, 2, 16, 2, 52, 13, 447, DateTimeKind.Local).AddTicks(5718), "Ratione aliquid est. Deleniti qui ratione beatae ipsum est perspiciatis dignissimos. Ut cum quo aut dolor qui quis voluptas nisi qui. Id sit fugiat. Vel corrupti recusandae voluptatibus." },
                    { 484, 48, 10, 648189, new DateTime(2021, 1, 7, 15, 41, 11, 248, DateTimeKind.Local).AddTicks(8442), "enim" },
                    { 488, 48, 18, 86336, new DateTime(2021, 3, 28, 4, 0, 50, 155, DateTimeKind.Local).AddTicks(5545), "Veritatis est voluptas ullam quam placeat atque error repellendus.\nVoluptas libero veritatis velit nihil aliquid quasi natus optio voluptate.\nAliquam vel omnis.\nAnimi illum dolorum ut sit sit.\nRepudiandae incidunt maxime quo.\nDolor quas illum pariatur qui in." },
                    { 490, 48, 141, 396180, new DateTime(2021, 7, 25, 6, 6, 30, 25, DateTimeKind.Local).AddTicks(566), "provident" },
                    { 390, 48, 30, 344253, new DateTime(2021, 1, 3, 13, 0, 10, 354, DateTimeKind.Local).AddTicks(5425), "Provident ipsum reiciendis fugit.\nDolor hic maiores omnis molestiae autem dolorem quasi quaerat.\nConsequuntur eos perspiciatis earum sequi.\nTempora dolorem quia officiis porro quia impedit." },
                    { 449, 86, 51, 686254, new DateTime(2020, 11, 8, 18, 17, 36, 454, DateTimeKind.Local).AddTicks(5973), "Dolores possimus sit nemo et alias et velit enim accusamus. Quibusdam distinctio qui. Culpa et doloremque. Qui culpa soluta distinctio mollitia consequuntur velit." },
                    { 495, 39, 141, 631017, new DateTime(2020, 10, 21, 19, 38, 19, 381, DateTimeKind.Local).AddTicks(5867), "Itaque deserunt at blanditiis qui voluptas natus pariatur nihil dolor. Possimus aliquam corporis voluptatem voluptatem deleniti. Explicabo quidem dolores vel aut aspernatur vitae commodi aliquam est. Dolor atque culpa. Mollitia aut omnis rerum ut cupiditate. Unde optio aperiam illo cum et." },
                    { 561, 39, 111, 828363, new DateTime(2020, 9, 15, 15, 38, 51, 578, DateTimeKind.Local).AddTicks(5984), "Magni reiciendis autem ullam. Totam voluptatem ullam et quia id et nulla consequatur. Ut placeat est et laudantium temporibus." },
                    { 115, 56, 10, 628782, new DateTime(2021, 7, 10, 6, 47, 17, 268, DateTimeKind.Local).AddTicks(930), "Aspernatur consequatur neque. Molestiae deserunt provident quia labore molestiae maxime voluptatibus reprehenderit. Saepe dolore commodi alias. Officia non ea quod." },
                    { 78, 56, 26, 334563, new DateTime(2021, 7, 3, 3, 54, 0, 277, DateTimeKind.Local).AddTicks(7669), "Sunt nam earum at.\nQuo eius velit sunt facilis et ut.\nImpedit consequuntur dolorem ut tempora beatae iure et ut.\nIpsa saepe quia sit nulla consequatur dolorem.\nVoluptas quidem velit et et voluptatem." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 21, 56, 72, 49862, new DateTime(2020, 11, 14, 19, 36, 19, 452, DateTimeKind.Local).AddTicks(2666), "voluptas" },
                    { 45, 84, 119, 560795, new DateTime(2021, 1, 23, 5, 58, 56, 760, DateTimeKind.Local).AddTicks(9517), "Minima sed incidunt rerum debitis mollitia similique et asperiores." },
                    { 116, 84, 91, 304175, new DateTime(2021, 1, 29, 2, 12, 28, 921, DateTimeKind.Local).AddTicks(3759), "Voluptatum iusto nobis minus eaque recusandae laudantium expedita.\nLaudantium est vitae incidunt aut qui non itaque officia atque." },
                    { 237, 84, 131, 498944, new DateTime(2020, 11, 3, 14, 41, 7, 384, DateTimeKind.Local).AddTicks(6069), "repellendus" },
                    { 302, 84, 21, 774669, new DateTime(2021, 7, 17, 4, 42, 52, 267, DateTimeKind.Local).AddTicks(3427), "Cumque omnis eum rem.\nAut sint hic modi voluptatem quo magni est ex.\nDeleniti iusto non.\nVitae et ipsum rerum at est sit expedita.\nVero blanditiis sed et.\nAt aut quisquam provident quisquam aut voluptatem rerum nisi." },
                    { 578, 84, 142, 941352, new DateTime(2021, 4, 22, 18, 52, 3, 504, DateTimeKind.Local).AddTicks(8775), "Animi ex enim officia incidunt aliquid eligendi pariatur quia quia. Enim et veniam. Similique dignissimos ipsam veniam et ducimus alias ad non. Voluptatem harum sint quam et qui deserunt." },
                    { 461, 75, 9, 455379, new DateTime(2021, 3, 11, 6, 5, 3, 622, DateTimeKind.Local).AddTicks(9884), "Accusamus illum explicabo dolore in voluptas sunt." },
                    { 220, 75, 135, 682721, new DateTime(2021, 4, 16, 2, 35, 11, 101, DateTimeKind.Local).AddTicks(5814), "Enim alias et. Enim alias et. Et excepturi accusantium nisi tempore. Ab sit voluptatem fugiat quis." },
                    { 153, 75, 25, 434797, new DateTime(2021, 5, 14, 10, 31, 7, 403, DateTimeKind.Local).AddTicks(6726), "Maxime natus qui eligendi quos quia quos sequi doloribus architecto.\nOmnis cumque eos qui facere mollitia occaecati est tenetur.\nEt laborum aut." },
                    { 11, 14, 19, 624093, new DateTime(2021, 7, 10, 1, 34, 42, 668, DateTimeKind.Local).AddTicks(2296), "Ducimus in asperiores voluptates inventore qui soluta et rem ut. Eos asperiores pariatur. Non odit qui placeat temporibus dolore inventore et enim omnis. Nisi voluptas impedit ipsam eos quae eaque repudiandae." },
                    { 81, 14, 99, 495705, new DateTime(2020, 11, 11, 9, 36, 6, 483, DateTimeKind.Local).AddTicks(2705), "Nihil et laudantium est eum ab. Sunt natus consectetur ut eveniet iste molestiae et sint sed. Expedita in quia dicta quia accusantium." },
                    { 264, 14, 104, 560755, new DateTime(2021, 7, 11, 11, 36, 8, 636, DateTimeKind.Local).AddTicks(4132), "Amet ducimus beatae. Qui optio commodi inventore corporis similique qui corrupti. Est qui consequatur est nemo aut mollitia repellat qui. Qui aut expedita. Amet pariatur ex modi itaque consequatur cum vel nihil aliquid." },
                    { 391, 14, 25, 351488, new DateTime(2021, 8, 15, 18, 26, 35, 991, DateTimeKind.Local).AddTicks(1200), "Consequatur non sunt aut id velit voluptatem." },
                    { 466, 36, 38, 563224, new DateTime(2020, 11, 28, 0, 31, 11, 959, DateTimeKind.Local).AddTicks(5088), "Molestias culpa reprehenderit culpa voluptatem commodi facere veritatis cupiditate temporibus.\nEius quia rerum omnis.\nAut aut sint consequatur est quo sed.\nEarum qui vitae in." },
                    { 232, 36, 3, 719745, new DateTime(2021, 2, 27, 8, 11, 41, 70, DateTimeKind.Local).AddTicks(8285), "Aut odit in placeat officiis rerum." },
                    { 164, 36, 55, 888124, new DateTime(2020, 12, 21, 23, 19, 48, 352, DateTimeKind.Local).AddTicks(8283), "repellat" },
                    { 157, 36, 114, 560593, new DateTime(2020, 10, 25, 2, 56, 43, 337, DateTimeKind.Local).AddTicks(4516), "Ut et unde ipsa." },
                    { 177, 85, 45, 159695, new DateTime(2021, 2, 26, 6, 51, 6, 88, DateTimeKind.Local).AddTicks(2820), "Dignissimos architecto commodi. Sit fuga magnam. Fugit debitis perspiciatis perspiciatis sed ratione. Aut laborum quos doloremque minus." },
                    { 236, 85, 89, 254080, new DateTime(2021, 6, 15, 9, 25, 38, 218, DateTimeKind.Local).AddTicks(5862), "Consequatur natus voluptatem ut doloremque eos accusantium. Sed omnis sit dolorem aliquid. Cupiditate facilis ut in quos est autem. Cumque et illum. Facilis ullam voluptatibus explicabo ipsa et exercitationem eos reprehenderit et. Cum eveniet tenetur." },
                    { 406, 85, 108, 174499, new DateTime(2020, 12, 6, 16, 58, 41, 339, DateTimeKind.Local).AddTicks(8593), "Tenetur ut enim debitis natus expedita iure.\nQuae ducimus et voluptates ullam." },
                    { 472, 85, 127, 527470, new DateTime(2020, 9, 1, 21, 28, 25, 677, DateTimeKind.Local).AddTicks(1443), "Ipsam ipsam eum sit dignissimos voluptas voluptates expedita nihil. Magni rerum nihil eveniet fugiat autem ipsum veritatis. Quos neque nulla mollitia labore. Eos magnam ducimus. Culpa nihil itaque maxime ea sit. Exercitationem reiciendis voluptatibus sed ratione." },
                    { 506, 85, 99, 299162, new DateTime(2020, 12, 10, 2, 7, 11, 570, DateTimeKind.Local).AddTicks(5493), "Explicabo perspiciatis velit possimus accusantium dolorem consequatur quam odit doloremque.\nQuia eaque libero voluptas.\nMaiores quis voluptatum ut tenetur et culpa." },
                    { 526, 85, 50, 88997, new DateTime(2021, 1, 2, 14, 9, 47, 853, DateTimeKind.Local).AddTicks(1049), "Dolorem alias repellat sunt temporibus adipisci illo sint. Animi quisquam expedita consequatur. Fuga fugit sint vitae assumenda necessitatibus libero enim. Ut vel repellendus. Nesciunt est rem neque ipsum inventore voluptas voluptate in praesentium. Fugit perspiciatis nulla qui odit incidunt eum laboriosam tempore adipisci." },
                    { 537, 56, 79, 210084, new DateTime(2021, 1, 21, 4, 13, 53, 187, DateTimeKind.Local).AddTicks(9173), "nemo" },
                    { 539, 39, 121, 465783, new DateTime(2021, 3, 28, 1, 40, 55, 539, DateTimeKind.Local).AddTicks(7806), "Consectetur quia dolore non nemo culpa." },
                    { 489, 56, 83, 961041, new DateTime(2021, 3, 5, 22, 33, 51, 904, DateTimeKind.Local).AddTicks(8733), "Consequuntur quibusdam quae occaecati quisquam consequatur sapiente non rerum. Non eos eius qui laborum fuga facere eum blanditiis. Repudiandae necessitatibus inventore debitis iste rem at qui totam ut." },
                    { 131, 38, 37, 59484, new DateTime(2021, 5, 20, 5, 53, 58, 45, DateTimeKind.Local).AddTicks(7263), "Odit non sed magnam quae et pariatur." },
                    { 249, 38, 96, 454838, new DateTime(2021, 2, 9, 2, 2, 32, 323, DateTimeKind.Local).AddTicks(7007), "rerum" },
                    { 250, 38, 144, 412605, new DateTime(2020, 10, 25, 2, 46, 19, 134, DateTimeKind.Local).AddTicks(6098), "Ea ut voluptas magni quibusdam sint." },
                    { 289, 56, 105, 706932, new DateTime(2020, 10, 9, 18, 17, 24, 897, DateTimeKind.Local).AddTicks(6584), "Alias eligendi similique nobis magnam.\nNihil unde ipsa.\nEnim sapiente vitae sit id ipsa quasi.\nCommodi non sunt dolorem animi deleniti ipsam inventore natus." },
                    { 194, 56, 123, 456297, new DateTime(2021, 1, 30, 7, 27, 15, 131, DateTimeKind.Local).AddTicks(4800), "Aut natus repudiandae odio quia quae.\nSapiente optio porro ut ex quis cupiditate.\nDoloribus voluptates consequatur quam adipisci.\nAut odit eos.\nArchitecto debitis minus hic magnam.\nNam aut quaerat nobis vel." },
                    { 152, 56, 67, 10252, new DateTime(2021, 8, 6, 12, 23, 35, 356, DateTimeKind.Local).AddTicks(4680), "Libero enim exercitationem quaerat reiciendis quis voluptas ad quidem hic." },
                    { 124, 36, 68, 898197, new DateTime(2021, 7, 4, 19, 17, 36, 511, DateTimeKind.Local).AddTicks(908), "Consequatur sit aut aut delectus.\nQuam aut ipsa architecto ducimus est blanditiis et maiores facilis.\nProvident aut repudiandae culpa.\nMaxime dolor voluptas perspiciatis aut." },
                    { 456, 56, 76, 321051, new DateTime(2021, 5, 29, 3, 51, 59, 345, DateTimeKind.Local).AddTicks(2011), "accusantium" },
                    { 349, 86, 84, 703705, new DateTime(2021, 5, 19, 7, 49, 59, 90, DateTimeKind.Local).AddTicks(8664), "Laudantium assumenda quo commodi omnis ad dolore.\nCulpa voluptas enim sed dolorem molestiae natus vel quod." },
                    { 137, 86, 12, 419073, new DateTime(2020, 10, 3, 8, 10, 6, 991, DateTimeKind.Local).AddTicks(326), "Hic necessitatibus aut in." },
                    { 574, 76, 51, 92533, new DateTime(2021, 2, 26, 20, 1, 11, 269, DateTimeKind.Local).AddTicks(4247), "nobis" },
                    { 13, 33, 56, 649122, new DateTime(2020, 9, 12, 9, 14, 26, 329, DateTimeKind.Local).AddTicks(6557), "Quis vitae distinctio quo reprehenderit sed quisquam. Nihil aut sint et nesciunt. Doloremque dolorem beatae. Ex et voluptatibus aperiam cupiditate odit cupiditate adipisci." },
                    { 76, 33, 123, 421612, new DateTime(2021, 2, 16, 5, 49, 59, 356, DateTimeKind.Local).AddTicks(4214), "Sit sunt consequatur doloremque dolores facilis autem. Non deleniti et ullam expedita nihil reiciendis explicabo sint omnis. Molestiae et reprehenderit porro minima consectetur ad incidunt et. Molestiae dolore id officia provident. Consequatur et iusto iure nulla." },
                    { 128, 33, 31, 805830, new DateTime(2021, 3, 27, 10, 3, 58, 391, DateTimeKind.Local).AddTicks(1075), "et" },
                    { 169, 33, 28, 541725, new DateTime(2021, 4, 23, 1, 55, 29, 899, DateTimeKind.Local).AddTicks(5987), "Aspernatur distinctio ut. Voluptas aperiam et vitae quos doloremque et praesentium dolorem quidem. Sunt non ut cupiditate quam optio voluptates. Corrupti inventore molestias eum officiis et nemo ab dolore porro. Iure qui sint laudantium rerum dolore hic ut. Et blanditiis non vel error voluptas hic ipsum quasi." },
                    { 284, 33, 100, 316307, new DateTime(2021, 8, 12, 6, 29, 53, 252, DateTimeKind.Local).AddTicks(9675), "Quam eos accusantium ut itaque et eaque quaerat perferendis veritatis.\nSit doloribus veritatis et quibusdam in quis.\nOdio id sint.\nAccusamus esse iure recusandae adipisci ullam dolor.\nUt aperiam similique sint ex tenetur soluta autem est." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 375, 33, 96, 412113, new DateTime(2020, 9, 25, 6, 54, 17, 623, DateTimeKind.Local).AddTicks(159), "Necessitatibus aperiam adipisci omnis aut qui placeat." },
                    { 597, 33, 46, 496505, new DateTime(2021, 7, 15, 12, 0, 44, 739, DateTimeKind.Local).AddTicks(3067), "Facere magnam id vero quaerat et enim repellendus maiores ea." },
                    { 36, 23, 7, 537472, new DateTime(2020, 10, 15, 6, 10, 43, 27, DateTimeKind.Local).AddTicks(3142), "at" },
                    { 243, 27, 5, 380945, new DateTime(2021, 8, 26, 16, 12, 21, 503, DateTimeKind.Local).AddTicks(8411), "Molestiae quo consequatur dolor provident voluptatem suscipit adipisci odit. Ex id ab et et esse repellendus voluptatem. In aspernatur illo dolor atque reprehenderit. Ratione id voluptates cupiditate et consequatur maiores. Suscipit aut labore culpa eveniet." },
                    { 519, 27, 52, 78761, new DateTime(2021, 7, 11, 12, 7, 21, 784, DateTimeKind.Local).AddTicks(1443), "Minima iste vero vero placeat non ipsam est." },
                    { 575, 27, 149, 705363, new DateTime(2021, 4, 25, 5, 22, 5, 218, DateTimeKind.Local).AddTicks(5118), "Modi excepturi ut nesciunt." },
                    { 429, 3, 84, 262930, new DateTime(2020, 11, 8, 7, 34, 33, 733, DateTimeKind.Local).AddTicks(1472), "Accusamus sed dignissimos officiis iure libero.\nEt qui modi saepe et quia et vel consequatur.\nVel mollitia veritatis nemo qui.\nNostrum reprehenderit saepe minima reiciendis eius ut qui.\nAd fugit non eius cumque atque nisi.\nRepellendus nesciunt impedit doloribus fugit exercitationem itaque." },
                    { 348, 3, 139, 445241, new DateTime(2021, 4, 16, 6, 5, 37, 774, DateTimeKind.Local).AddTicks(2139), "Quam delectus corporis consequuntur laudantium eum.\nVeniam omnis animi incidunt sit a tempora.\nMaiores corrupti accusamus impedit est aut quos." },
                    { 203, 3, 7, 92190, new DateTime(2021, 4, 14, 5, 55, 46, 691, DateTimeKind.Local).AddTicks(5152), "Doloribus beatae animi est dolorem cupiditate harum." },
                    { 75, 17, 58, 25710, new DateTime(2021, 1, 16, 15, 23, 49, 809, DateTimeKind.Local).AddTicks(4442), "Corporis sed nemo dicta nulla." },
                    { 150, 23, 2, 232705, new DateTime(2021, 6, 14, 16, 38, 41, 550, DateTimeKind.Local).AddTicks(6510), "ea" },
                    { 402, 23, 8, 591947, new DateTime(2020, 11, 30, 2, 55, 58, 724, DateTimeKind.Local).AddTicks(9180), "Nihil ipsam quae ea velit." },
                    { 591, 4, 78, 736160, new DateTime(2021, 4, 14, 19, 35, 25, 215, DateTimeKind.Local).AddTicks(2233), "Deleniti aut vel optio velit quod." },
                    { 582, 4, 106, 493509, new DateTime(2021, 8, 13, 12, 53, 20, 721, DateTimeKind.Local).AddTicks(6395), "Est id aut quas maiores rem quis maiores dolores.\nId maxime sunt voluptatum et perferendis tempora." },
                    { 158, 46, 35, 201670, new DateTime(2021, 5, 15, 21, 38, 51, 500, DateTimeKind.Local).AddTicks(8068), "Rerum quia error et suscipit." },
                    { 176, 46, 118, 435437, new DateTime(2021, 4, 22, 5, 20, 22, 290, DateTimeKind.Local).AddTicks(5888), "repellat" },
                    { 180, 46, 114, 145415, new DateTime(2020, 9, 28, 16, 19, 2, 879, DateTimeKind.Local).AddTicks(2403), "Perspiciatis in veniam ipsum quasi omnis est reprehenderit debitis consequatur." },
                    { 282, 46, 103, 777797, new DateTime(2021, 5, 12, 1, 33, 45, 336, DateTimeKind.Local).AddTicks(9620), "Occaecati unde aut eos nesciunt ut ullam.\nUt fugit quis et sint corporis.\nCorporis consequatur vero atque in." },
                    { 307, 46, 30, 319671, new DateTime(2020, 10, 30, 19, 46, 4, 225, DateTimeKind.Local).AddTicks(9941), "Qui eum aperiam molestias.\nDolor aut voluptatem non.\nVoluptate explicabo et voluptas dolores ea maiores laboriosam enim sequi.\nQuo voluptatum consequatur expedita veritatis consequuntur possimus amet veritatis.\nIusto maiores culpa sapiente." },
                    { 324, 46, 77, 279241, new DateTime(2020, 10, 23, 1, 40, 14, 714, DateTimeKind.Local).AddTicks(556), "Enim id saepe." },
                    { 372, 46, 131, 65588, new DateTime(2020, 11, 7, 11, 51, 38, 277, DateTimeKind.Local).AddTicks(3168), "asperiores" },
                    { 252, 17, 136, 497499, new DateTime(2021, 3, 26, 11, 30, 57, 561, DateTimeKind.Local).AddTicks(8032), "delectus" },
                    { 507, 46, 69, 964093, new DateTime(2021, 1, 22, 18, 11, 12, 527, DateTimeKind.Local).AddTicks(5971), "Enim et ut perferendis debitis laudantium quia. Rerum esse quam excepturi inventore magni ut labore earum. Asperiores deserunt dolorem explicabo explicabo eos tenetur." },
                    { 448, 23, 64, 692069, new DateTime(2020, 11, 23, 18, 46, 42, 18, DateTimeKind.Local).AddTicks(6296), "voluptate" },
                    { 182, 4, 47, 209788, new DateTime(2020, 10, 27, 5, 18, 43, 516, DateTimeKind.Local).AddTicks(8878), "A dolorem autem iure. Voluptas iusto voluptatem labore. Placeat quo quibusdam cum placeat similique occaecati. Ad nisi sunt occaecati dolorem id quas explicabo quisquam sed." },
                    { 214, 4, 138, 227911, new DateTime(2021, 6, 21, 5, 56, 54, 798, DateTimeKind.Local).AddTicks(3844), "Non illum provident possimus est sit. Atque et ullam vero quae accusamus sit. Quidem beatae est odit. Deleniti quia iusto rerum aliquam voluptatibus suscipit. Eos eum eaque hic quasi mollitia nihil commodi voluptate ut." },
                    { 222, 4, 30, 20467, new DateTime(2020, 9, 28, 20, 30, 33, 371, DateTimeKind.Local).AddTicks(899), "Enim incidunt in cumque qui itaque sit enim ratione recusandae.\nTemporibus minima voluptates praesentium.\nPariatur aspernatur tempora iste.\nAb laborum ut molestiae.\nEligendi perferendis sit." },
                    { 278, 4, 98, 863798, new DateTime(2021, 1, 31, 2, 16, 25, 843, DateTimeKind.Local).AddTicks(9230), "Animi quis non ratione delectus sint.\nCumque eius et quod.\nFugiat necessitatibus aut nesciunt molestiae provident accusantium aliquid perferendis.\nDolorem quod et est cum consequatur quod magnam maxime.\nQuasi deleniti tenetur minima.\nTemporibus distinctio ratione voluptatem sit culpa." },
                    { 431, 4, 42, 468821, new DateTime(2020, 11, 4, 11, 27, 32, 288, DateTimeKind.Local).AddTicks(9404), "Qui aliquid dolorem ut modi quia quam nesciunt odit." },
                    { 499, 4, 13, 761219, new DateTime(2021, 4, 6, 9, 55, 4, 809, DateTimeKind.Local).AddTicks(6639), "Consectetur rerum delectus et cumque." },
                    { 96, 91, 96, 980299, new DateTime(2021, 2, 26, 11, 25, 11, 380, DateTimeKind.Local).AddTicks(4389), "optio" },
                    { 270, 17, 85, 415709, new DateTime(2021, 1, 11, 14, 5, 7, 486, DateTimeKind.Local).AddTicks(3324), "qui" },
                    { 296, 17, 23, 271253, new DateTime(2021, 7, 3, 14, 57, 39, 767, DateTimeKind.Local).AddTicks(899), "dolores" },
                    { 191, 3, 82, 27496, new DateTime(2021, 6, 2, 1, 40, 34, 599, DateTimeKind.Local).AddTicks(207), "sequi" },
                    { 242, 89, 15, 143593, new DateTime(2021, 7, 7, 10, 4, 14, 961, DateTimeKind.Local).AddTicks(1549), "Quos beatae dolore culpa sed neque praesentium ipsum debitis. Distinctio ratione in porro nostrum in adipisci repellendus qui. Voluptas incidunt quod ab. Non aut quisquam quia voluptatem occaecati. Ea molestiae voluptatem porro. Eos est suscipit autem maxime vitae." },
                    { 244, 89, 134, 194341, new DateTime(2020, 12, 9, 0, 30, 4, 458, DateTimeKind.Local).AddTicks(6728), "Optio totam eveniet. Neque rerum perspiciatis nesciunt possimus accusamus sed occaecati. Hic fugit minus quis qui dolore. Facere dolor minima iusto dolor sed aliquam. Adipisci illum accusantium et molestias laboriosam. Soluta nihil sit ea atque voluptatem dolorem excepturi totam enim." },
                    { 303, 89, 108, 397382, new DateTime(2021, 5, 27, 22, 13, 18, 899, DateTimeKind.Local).AddTicks(2617), "Dolor saepe dolores repellat eos quos non vel.\nCumque mollitia ipsam ullam sunt assumenda veritatis sint ex accusamus." },
                    { 389, 89, 12, 573042, new DateTime(2020, 9, 2, 15, 28, 57, 488, DateTimeKind.Local).AddTicks(8007), "voluptatem" },
                    { 523, 89, 73, 55155, new DateTime(2020, 10, 3, 0, 12, 21, 738, DateTimeKind.Local).AddTicks(5737), "Velit sit reprehenderit sit fugiat velit dolores natus provident minus.\nAccusantium ut incidunt aut consequatur facilis labore aut.\nA est reprehenderit et maxime alias assumenda est nostrum omnis.\nOmnis est qui veniam assumenda.\nVelit fugiat rerum." },
                    { 565, 89, 111, 184967, new DateTime(2021, 5, 27, 16, 45, 4, 592, DateTimeKind.Local).AddTicks(2290), "Accusamus eos est eos quos ad ut asperiores numquam aut.\nQuisquam in voluptate.\nAd qui et maiores assumenda et earum illum consequuntur.\nAliquid consequatur dignissimos incidunt provident placeat." },
                    { 300, 83, 75, 10210, new DateTime(2021, 3, 11, 19, 47, 44, 833, DateTimeKind.Local).AddTicks(458), "iste" },
                    { 122, 89, 5, 560845, new DateTime(2021, 1, 6, 1, 56, 29, 534, DateTimeKind.Local).AddTicks(7201), "Dolor autem qui facilis nulla ratione qui dicta quia." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 50, 83, 140, 615124, new DateTime(2021, 3, 12, 0, 52, 29, 343, DateTimeKind.Local).AddTicks(3493), "Totam beatae libero qui consequatur reiciendis tempore sit. Nobis et beatae ea iusto laudantium. Saepe dicta rerum quaerat. Aut excepturi aspernatur sunt quidem qui. Officiis quaerat perferendis incidunt quia." },
                    { 6, 80, 65, 281212, new DateTime(2021, 3, 21, 5, 27, 34, 835, DateTimeKind.Local).AddTicks(6607), "Id error cupiditate hic dignissimos aut minima odit ea quasi." },
                    { 14, 80, 145, 803058, new DateTime(2021, 5, 14, 7, 17, 33, 63, DateTimeKind.Local).AddTicks(539), "dolor" },
                    { 260, 80, 37, 826005, new DateTime(2021, 6, 15, 0, 57, 57, 764, DateTimeKind.Local).AddTicks(8223), "non" },
                    { 268, 80, 72, 826303, new DateTime(2021, 1, 13, 4, 10, 36, 838, DateTimeKind.Local).AddTicks(7115), "fugit" },
                    { 428, 80, 11, 839691, new DateTime(2021, 1, 4, 20, 7, 33, 968, DateTimeKind.Local).AddTicks(6959), "Aut autem voluptatem molestiae." },
                    { 433, 80, 25, 4985, new DateTime(2021, 2, 7, 22, 38, 48, 819, DateTimeKind.Local).AddTicks(6593), "Amet cum eos quos ea doloremque nesciunt rerum." },
                    { 476, 80, 111, 789284, new DateTime(2021, 6, 18, 1, 30, 40, 189, DateTimeKind.Local).AddTicks(5549), "Voluptatem impedit delectus voluptatem vero ut est reprehenderit aut incidunt. Doloremque unde quas quis soluta qui excepturi et in et. Voluptatibus et a quasi voluptate doloremque unde reprehenderit corporis dolores. Voluptas accusantium nesciunt molestiae autem quam id et. Nisi corrupti animi commodi in quos beatae et consectetur aut. Officia quos non est totam." },
                    { 43, 83, 132, 214820, new DateTime(2021, 6, 15, 17, 34, 30, 135, DateTimeKind.Local).AddTicks(6316), "Voluptas esse ipsa voluptatem earum. Autem deserunt illo labore. Illum odit quo a fugiat qui rerum autem. Eligendi et dolorum deserunt fugit aut esse unde." },
                    { 410, 14, 83, 762649, new DateTime(2021, 7, 18, 23, 58, 4, 992, DateTimeKind.Local).AddTicks(1034), "Atque voluptas facilis voluptatem velit et vitae magni.\nConsequatur alias veniam tenetur culpa asperiores accusantium.\nEt et consequatur nihil reiciendis.\nExpedita dolorum similique labore.\nEt doloremque aperiam alias sit quidem distinctio at ut." },
                    { 98, 89, 136, 754137, new DateTime(2021, 4, 12, 9, 51, 26, 154, DateTimeKind.Local).AddTicks(4909), "Quaerat quisquam et dolorem beatae enim consequatur. Facere veniam quos veritatis doloribus sunt consequatur. Doloribus autem molestiae velit nostrum soluta est." },
                    { 38, 89, 39, 392280, new DateTime(2021, 8, 4, 7, 7, 15, 321, DateTimeKind.Local).AddTicks(7454), "Sit quidem aperiam repellat numquam velit." },
                    { 1, 34, 132, 966160, new DateTime(2020, 9, 10, 20, 46, 29, 397, DateTimeKind.Local).AddTicks(2763), "A et reiciendis dolore vel dolores et reiciendis.\nConsequatur reprehenderit ut qui libero aliquam odit animi fugit.\nAut ut iste dolores debitis occaecati modi nesciunt fugiat ex." },
                    { 63, 34, 96, 7156, new DateTime(2020, 9, 2, 8, 34, 40, 507, DateTimeKind.Local).AddTicks(7165), "Expedita voluptatem veniam maiores unde nam est voluptatum soluta. Id repudiandae dicta esse deleniti sunt. Placeat laborum minima fugiat sed ab est quia. Voluptas laudantium aut sunt adipisci sunt nemo et quia odit. Totam officia provident non. Voluptas qui et eveniet." },
                    { 64, 34, 89, 308662, new DateTime(2020, 10, 30, 14, 24, 17, 213, DateTimeKind.Local).AddTicks(6875), "Laboriosam et earum sed aspernatur excepturi omnis distinctio." },
                    { 167, 34, 72, 456812, new DateTime(2021, 8, 6, 22, 48, 50, 354, DateTimeKind.Local).AddTicks(871), "Doloremque officia qui dolore cum. Et quis nemo voluptate et sit et eos id ut. Eaque qui hic quia distinctio unde. Eum aut doloribus facere consectetur. Accusamus qui corrupti qui et et voluptate totam. Soluta repellendus corrupti." },
                    { 399, 34, 39, 498258, new DateTime(2021, 3, 6, 10, 51, 3, 407, DateTimeKind.Local).AddTicks(2416), "Consequatur tempore consequuntur pariatur iste magni dolorem culpa." },
                    { 434, 34, 86, 874308, new DateTime(2021, 1, 13, 23, 57, 47, 509, DateTimeKind.Local).AddTicks(1358), "Neque assumenda quasi qui vel. Molestiae maxime temporibus. Mollitia itaque earum. Reiciendis vel ut voluptates sequi in cum est vero qui. Quaerat occaecati iste aut." },
                    { 491, 34, 48, 533060, new DateTime(2021, 7, 29, 7, 33, 21, 833, DateTimeKind.Local).AddTicks(1472), "Nobis necessitatibus maiores consequatur rerum.\nLaudantium omnis nostrum ea eaque aut ut quod ipsum.\nDolore tenetur similique maxime maiores nisi ut enim libero dolore." },
                    { 52, 89, 119, 225160, new DateTime(2020, 9, 1, 18, 20, 6, 767, DateTimeKind.Local).AddTicks(6899), "Harum excepturi dolorem qui culpa saepe exercitationem sunt sed doloremque.\nRerum pariatur repudiandae rerum aut ipsum quia voluptatem ea.\nAd aut nam." },
                    { 502, 34, 106, 395912, new DateTime(2020, 9, 19, 15, 11, 34, 683, DateTimeKind.Local).AddTicks(5017), "Voluptas consectetur fugit asperiores temporibus excepturi quod reprehenderit culpa autem. Dicta laudantium vel soluta consequatur. Quod laborum dolorum est." },
                    { 22, 3, 103, 682460, new DateTime(2020, 9, 4, 15, 56, 10, 117, DateTimeKind.Local).AddTicks(6606), "Deleniti ullam magni autem et praesentium sequi quod. Dignissimos vel nobis. Fugiat quia cupiditate neque." },
                    { 15, 72, 120, 113864, new DateTime(2020, 9, 20, 7, 15, 35, 237, DateTimeKind.Local).AddTicks(1912), "Quod sunt nihil assumenda." },
                    { 155, 72, 72, 114316, new DateTime(2020, 10, 20, 23, 35, 23, 707, DateTimeKind.Local).AddTicks(2316), "Quo hic dolores ea inventore quis voluptas id distinctio unde. Autem fuga illum reprehenderit voluptate laboriosam ut. Voluptatem voluptates sint ea explicabo error et. Natus nostrum voluptas animi veniam consequatur adipisci deleniti aut quia." },
                    { 202, 72, 142, 508879, new DateTime(2021, 8, 19, 14, 25, 41, 135, DateTimeKind.Local).AddTicks(1482), "Adipisci sit maiores sed." },
                    { 363, 72, 131, 84815, new DateTime(2021, 3, 30, 9, 55, 11, 883, DateTimeKind.Local).AddTicks(4726), "Amet ut laboriosam vel.\nRepellendus cupiditate veritatis architecto ipsa mollitia a at." },
                    { 467, 72, 136, 485997, new DateTime(2020, 9, 18, 4, 44, 8, 677, DateTimeKind.Local).AddTicks(3438), "Voluptatem repellendus vitae quo modi beatae sit labore et necessitatibus.\nDebitis laudantium ducimus dolores accusantium iure porro sed.\nQuibusdam vel sed rerum.\nMinima dolor voluptatem sapiente voluptate." },
                    { 504, 83, 129, 746926, new DateTime(2021, 6, 14, 21, 30, 27, 996, DateTimeKind.Local).AddTicks(5436), "Exercitationem aut et culpa non sint excepturi cumque. Amet voluptatem earum voluptas nobis illo commodi quas quis reprehenderit. Facere quis in quas repudiandae est magni culpa sed. Optio vel sapiente rerum pariatur recusandae unde eaque porro. Rerum distinctio quod." },
                    { 32, 3, 29, 863105, new DateTime(2021, 4, 5, 1, 2, 57, 803, DateTimeKind.Local).AddTicks(5542), "et" },
                    { 86, 46, 32, 131552, new DateTime(2021, 5, 22, 21, 7, 15, 537, DateTimeKind.Local).AddTicks(8852), "Inventore aut eligendi commodi consectetur." },
                    { 420, 14, 131, 238584, new DateTime(2021, 6, 5, 17, 49, 45, 689, DateTimeKind.Local).AddTicks(9264), "Tenetur fugit eos enim eum." },
                    { 599, 14, 138, 477772, new DateTime(2020, 12, 30, 22, 53, 18, 867, DateTimeKind.Local).AddTicks(7026), "et" },
                    { 586, 49, 98, 925094, new DateTime(2020, 11, 16, 1, 55, 29, 245, DateTimeKind.Local).AddTicks(3553), "At sunt odio dolor tempore architecto in et vero delectus.\nEt dolorem est voluptatem.\nAut voluptatum maxime minima ipsam cumque tenetur omnis distinctio inventore." },
                    { 500, 30, 74, 324118, new DateTime(2021, 1, 28, 6, 40, 29, 560, DateTimeKind.Local).AddTicks(4254), "Veniam aut assumenda in cumque voluptas voluptates voluptas nostrum mollitia." },
                    { 392, 30, 91, 798766, new DateTime(2021, 2, 13, 2, 27, 46, 883, DateTimeKind.Local).AddTicks(1479), "Voluptas quidem dignissimos illum." },
                    { 387, 30, 89, 22408, new DateTime(2020, 10, 20, 22, 15, 41, 804, DateTimeKind.Local).AddTicks(5680), "Laudantium quis ipsum id modi facere deserunt vero pariatur eaque.\nImpedit assumenda enim neque.\nQui nam nam voluptates voluptas labore facere reiciendis quidem sed." },
                    { 8, 57, 83, 252007, new DateTime(2021, 3, 1, 4, 47, 50, 928, DateTimeKind.Local).AddTicks(3146), "Sunt quam nihil.\nExplicabo unde commodi et omnis ipsam.\nConsectetur rerum ea fugit reprehenderit ut aut omnis." },
                    { 108, 57, 91, 263457, new DateTime(2021, 8, 3, 17, 9, 42, 943, DateTimeKind.Local).AddTicks(3739), "Commodi dolorem quis nam illum." },
                    { 175, 57, 123, 366952, new DateTime(2021, 5, 9, 23, 19, 10, 481, DateTimeKind.Local).AddTicks(5069), "Mollitia assumenda dolorum voluptas sit vitae voluptates. Vel itaque praesentium enim et inventore qui. Quisquam voluptates eligendi occaecati. Illo incidunt voluptatum sapiente tempora rem quam qui est odio." },
                    { 183, 57, 102, 445432, new DateTime(2021, 4, 4, 3, 45, 44, 345, DateTimeKind.Local).AddTicks(961), "Dolorem sit corrupti et qui impedit nisi cupiditate et. Voluptas dignissimos deleniti nisi et. Officia cumque quasi expedita odio expedita quidem aut quae. Incidunt ipsam doloremque perspiciatis odio a a. Et omnis doloremque dicta est harum tempora asperiores commodi. Quod et labore vero sit." },
                    { 184, 57, 122, 380326, new DateTime(2021, 6, 26, 18, 50, 48, 35, DateTimeKind.Local).AddTicks(2528), "vel" },
                    { 187, 57, 16, 419816, new DateTime(2021, 3, 10, 13, 31, 20, 944, DateTimeKind.Local).AddTicks(9662), "Earum mollitia dolore placeat recusandae debitis fugit." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 396, 57, 51, 657663, new DateTime(2020, 12, 28, 18, 38, 56, 82, DateTimeKind.Local).AddTicks(5621), "Beatae consequuntur est quod iste laudantium exercitationem quia consequatur modi.\nSunt aut harum.\nPerspiciatis eius quia cumque sit voluptas aliquam." },
                    { 459, 57, 34, 760936, new DateTime(2021, 2, 17, 17, 50, 43, 606, DateTimeKind.Local).AddTicks(3177), "Voluptatem impedit qui illo quia qui aut et.\nNulla reiciendis natus distinctio magnam.\nRerum quisquam quaerat placeat fuga.\nNobis velit porro labore beatae ratione in qui assumenda eum." },
                    { 576, 57, 139, 429471, new DateTime(2021, 2, 5, 2, 0, 54, 165, DateTimeKind.Local).AddTicks(6338), "Expedita deleniti tempora et quia. Autem odit beatae libero in. Ea eos porro velit quis cupiditate dignissimos accusamus." },
                    { 357, 30, 137, 421312, new DateTime(2021, 4, 19, 0, 9, 46, 6, DateTimeKind.Local).AddTicks(6362), "maiores" },
                    { 336, 30, 105, 891870, new DateTime(2021, 4, 21, 15, 28, 56, 249, DateTimeKind.Local).AddTicks(8696), "Quaerat accusantium consequuntur. Et earum enim consequatur quia. Vel amet sit suscipit quisquam occaecati temporibus blanditiis corrupti eveniet. Quia et et. Sit autem ut reprehenderit. Sunt minus consequatur voluptas ut ut omnis laudantium velit consequatur." },
                    { 564, 49, 77, 926364, new DateTime(2021, 5, 1, 5, 39, 9, 914, DateTimeKind.Local).AddTicks(1862), "Deleniti accusamus est impedit velit sit voluptatem vel iste omnis. Tempore voluptatem ut quasi asperiores sit quas sit omnis et. Aliquid inventore minima odio enim quis est esse veritatis distinctio. Nesciunt illo ut delectus laborum non laborum est temporibus. Cumque architecto excepturi velit. Totam facilis repellat impedit pariatur." },
                    { 540, 49, 124, 879860, new DateTime(2021, 2, 7, 9, 57, 57, 753, DateTimeKind.Local).AddTicks(5721), "Labore dolorem odit. Expedita porro dolorem id. Dolores illo sit quas ut sed quaerat incidunt. Assumenda nemo facere minus. Quasi non id perspiciatis aut est saepe temporibus ea et. Doloribus quod facere id deleniti velit." },
                    { 494, 49, 141, 958370, new DateTime(2020, 12, 1, 12, 59, 46, 63, DateTimeKind.Local).AddTicks(9677), "Excepturi alias cumque nihil.\nVoluptatem atque repudiandae ex id asperiores.\nSuscipit odit perspiciatis id quo.\nNam aut recusandae." },
                    { 479, 49, 21, 89112, new DateTime(2020, 9, 18, 5, 43, 44, 263, DateTimeKind.Local).AddTicks(2075), "Dolor exercitationem et blanditiis aut qui unde accusamus." },
                    { 350, 6, 120, 809609, new DateTime(2021, 1, 18, 14, 29, 6, 394, DateTimeKind.Local).AddTicks(10), "Et rem molestiae.\nVero aspernatur perspiciatis quia in optio exercitationem.\nOccaecati qui dolor hic ut consectetur et aut odio." },
                    { 509, 6, 145, 445117, new DateTime(2021, 3, 15, 21, 10, 10, 580, DateTimeKind.Local).AddTicks(8666), "Voluptatem autem autem quia sit qui veritatis vel dignissimos dignissimos." },
                    { 532, 6, 146, 974920, new DateTime(2021, 5, 30, 22, 58, 59, 208, DateTimeKind.Local).AddTicks(2153), "Numquam quibusdam voluptatibus. Id sint omnis vitae neque. Laudantium eum recusandae voluptas deserunt dolor cumque illum. Est natus vitae ad. Qui fugit aperiam natus. Repellendus totam excepturi temporibus earum ut molestias." },
                    { 99, 87, 106, 411562, new DateTime(2021, 1, 23, 15, 3, 14, 31, DateTimeKind.Local).AddTicks(4327), "Vel rerum ea reprehenderit voluptatem sit placeat." },
                    { 67, 87, 106, 689124, new DateTime(2020, 12, 6, 17, 19, 44, 221, DateTimeKind.Local).AddTicks(8389), "Fugiat aut rem quod occaecati incidunt expedita consequuntur quidem consequatur." },
                    { 170, 68, 20, 471401, new DateTime(2021, 5, 18, 19, 12, 59, 867, DateTimeKind.Local).AddTicks(3708), "Sit est quod totam amet reiciendis tempore quod molestiae.\nQuia quia totam nihil." },
                    { 207, 68, 56, 771978, new DateTime(2021, 4, 15, 14, 38, 11, 146, DateTimeKind.Local).AddTicks(7409), "Eligendi fugiat temporibus qui culpa et dignissimos dolores doloremque porro. Necessitatibus itaque dolorem ea ut. Quas earum ducimus voluptates. Iure error harum culpa ullam vero." },
                    { 24, 41, 75, 526788, new DateTime(2021, 1, 28, 22, 44, 17, 985, DateTimeKind.Local).AddTicks(3969), "In aut minus earum dolor. Voluptatem quasi minima suscipit earum est. Cum voluptas qui doloremque aut." },
                    { 240, 68, 39, 207970, new DateTime(2020, 12, 21, 5, 26, 31, 895, DateTimeKind.Local).AddTicks(1918), "in" },
                    { 445, 68, 112, 857186, new DateTime(2021, 1, 12, 9, 57, 47, 499, DateTimeKind.Local).AddTicks(5050), "corrupti" },
                    { 515, 68, 17, 642524, new DateTime(2021, 2, 8, 2, 14, 4, 963, DateTimeKind.Local).AddTicks(9263), "Rem adipisci debitis voluptates. Iure sapiente incidunt maxime libero vel. Tempora quos adipisci minima. Omnis id odit fuga consectetur omnis." },
                    { 453, 40, 135, 674732, new DateTime(2021, 1, 31, 11, 27, 46, 137, DateTimeKind.Local).AddTicks(1200), "Sint modi eum ullam ex ut deserunt.\nQuo sit non praesentium aut officia consequatur voluptas vitae.\nCum est quos voluptatem dolores impedit.\nVoluptas et quis delectus quas consequatur.\nLabore natus incidunt a ut qui dolorum culpa." },
                    { 227, 49, 111, 111649, new DateTime(2021, 3, 27, 22, 21, 21, 968, DateTimeKind.Local).AddTicks(3937), "fugiat" },
                    { 290, 49, 28, 680396, new DateTime(2021, 4, 5, 8, 54, 50, 698, DateTimeKind.Local).AddTicks(4788), "suscipit" },
                    { 327, 49, 79, 502021, new DateTime(2021, 1, 5, 16, 52, 51, 609, DateTimeKind.Local).AddTicks(3192), "aliquid" },
                    { 447, 49, 112, 413325, new DateTime(2020, 9, 11, 14, 19, 6, 120, DateTimeKind.Local).AddTicks(6312), "culpa" },
                    { 273, 68, 35, 548735, new DateTime(2021, 7, 31, 8, 41, 23, 232, DateTimeKind.Local).AddTicks(1837), "Rerum consequatur enim ipsum pariatur quas. Assumenda temporibus laborum ut est odit earum. Omnis pariatur qui voluptatibus culpa sequi explicabo. Voluptatem iste voluptas cum minus fugit quia quaerat ea enim. Quia rerum suscipit omnis et laudantium quae eum." },
                    { 320, 6, 85, 863219, new DateTime(2021, 4, 2, 2, 25, 6, 632, DateTimeKind.Local).AddTicks(4968), "Sed nostrum quibusdam earum sint ut est similique.\nEst a pariatur iusto cum.\nAutem voluptas quia laudantium autem consequatur eveniet mollitia eius.\nConsequatur et officia quia tenetur incidunt explicabo et omnis.\nEligendi laborum itaque molestiae dolorem omnis non quas qui alias." },
                    { 312, 41, 98, 70360, new DateTime(2021, 4, 17, 11, 16, 40, 988, DateTimeKind.Local).AddTicks(8035), "Eaque deserunt corporis optio autem reprehenderit nihil quod qui omnis.\nQui illo dolorem.\nMolestiae voluptatem fugiat.\nAut accusamus nam et aliquam soluta distinctio." },
                    { 457, 41, 136, 246768, new DateTime(2021, 5, 16, 12, 42, 22, 839, DateTimeKind.Local).AddTicks(5504), "Illum consequuntur veniam repellendus. Et nemo id est alias deleniti. Et dolor vel esse ut possimus nulla recusandae asperiores maxime. Dolorem illum earum et. Autem ab aut vel rem et possimus odit. Non qui ducimus a dicta ea autem consectetur aliquam." },
                    { 286, 19, 54, 793172, new DateTime(2020, 10, 30, 21, 31, 25, 130, DateTimeKind.Local).AddTicks(7101), "Illum omnis non nulla. Quo dolore nemo ratione quam qui ducimus voluptas saepe repellat. In quam dolorem pariatur odio. Sit dolor porro ex. Omnis possimus voluptas vel perferendis minus quibusdam et." },
                    { 288, 19, 10, 503947, new DateTime(2021, 6, 24, 15, 36, 21, 77, DateTimeKind.Local).AddTicks(5467), "doloremque" },
                    { 346, 19, 16, 79126, new DateTime(2020, 12, 5, 9, 53, 53, 255, DateTimeKind.Local).AddTicks(660), "Enim a dolore explicabo autem nihil qui dolor pariatur.\nDolor et sint qui ad est velit.\nNeque fuga exercitationem ullam non nam accusamus aspernatur quos.\nArchitecto et praesentium veritatis esse.\nSimilique distinctio voluptas dolor et." },
                    { 368, 19, 70, 594386, new DateTime(2021, 7, 8, 10, 27, 59, 317, DateTimeKind.Local).AddTicks(5196), "Et fugiat corrupti.\nVelit similique alias quia odit.\nVel pariatur minima est.\nAt ab molestias.\nDolor est aliquid maxime." },
                    { 403, 19, 7, 524858, new DateTime(2020, 9, 9, 16, 40, 6, 109, DateTimeKind.Local).AddTicks(9187), "Est officiis debitis delectus saepe. Sint accusantium illum et ex iste placeat. Est maiores voluptates. Sapiente maxime atque consectetur. Inventore rerum et est sed sit aliquid aliquid. Doloremque qui quos enim aperiam." },
                    { 415, 19, 75, 368911, new DateTime(2021, 8, 11, 8, 33, 8, 710, DateTimeKind.Local).AddTicks(9052), "Aspernatur odio adipisci voluptates. Exercitationem voluptate fugiat. Non ipsum qui voluptas. Est odit aperiam aut impedit minima est doloremque. Rerum facilis minima consequatur quis nisi magni sed quidem." },
                    { 487, 19, 54, 148828, new DateTime(2020, 12, 3, 2, 14, 45, 734, DateTimeKind.Local).AddTicks(3959), "inventore" },
                    { 587, 19, 132, 716199, new DateTime(2020, 11, 1, 6, 20, 54, 284, DateTimeKind.Local).AddTicks(7203), "non" },
                    { 66, 30, 106, 354857, new DateTime(2021, 1, 3, 5, 49, 41, 792, DateTimeKind.Local).AddTicks(9467), "quasi" },
                    { 31, 30, 53, 337581, new DateTime(2021, 4, 1, 15, 50, 16, 870, DateTimeKind.Local).AddTicks(9869), "quaerat" },
                    { 337, 91, 60, 303089, new DateTime(2021, 1, 31, 12, 28, 41, 636, DateTimeKind.Local).AddTicks(6455), "Nulla consequuntur dolores repellat.\nRem explicabo a dolores aut optio et ab." },
                    { 266, 91, 98, 230002, new DateTime(2021, 7, 18, 1, 56, 39, 724, DateTimeKind.Local).AddTicks(665), "Quasi assumenda quia quia rerum nisi rerum quia." },
                    { 224, 91, 95, 639507, new DateTime(2021, 5, 19, 4, 21, 53, 909, DateTimeKind.Local).AddTicks(2037), "Qui eius maxime eius et eos ad similique.\nAlias sunt ut repudiandae.\nMollitia saepe reiciendis ea.\nFacere doloribus et debitis quis nulla architecto nam.\nAccusamus qui modi odio dolores." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 174, 91, 59, 851538, new DateTime(2021, 3, 8, 6, 7, 1, 252, DateTimeKind.Local).AddTicks(6408), "Quae deleniti corporis. Qui cum voluptatem modi provident impedit dolore autem enim. Omnis necessitatibus iusto et fugiat odit voluptas. Quam at dolorum tempore. Sunt cumque unde et perferendis ut ut enim beatae." },
                    { 126, 91, 119, 18468, new DateTime(2020, 12, 13, 15, 14, 5, 998, DateTimeKind.Local).AddTicks(5985), "Doloremque quis aut at nemo enim quam quia. Rerum et consequuntur. Explicabo ut et tempore qui." },
                    { 285, 19, 28, 508000, new DateTime(2021, 8, 7, 14, 55, 42, 911, DateTimeKind.Local).AddTicks(1482), "Inventore facere deleniti rerum atque." },
                    { 197, 19, 107, 825574, new DateTime(2021, 1, 19, 20, 39, 26, 27, DateTimeKind.Local).AddTicks(7004), "Fugit voluptas repudiandae esse qui velit." },
                    { 185, 19, 75, 154721, new DateTime(2020, 12, 11, 15, 35, 39, 252, DateTimeKind.Local).AddTicks(6350), "Dolores quaerat non. Corrupti fuga nihil hic dolor quas perferendis odio et. Nostrum ut qui qui consequatur quis. Et aspernatur fugiat ad omnis voluptatum facere ipsum nihil enim." },
                    { 148, 19, 40, 420807, new DateTime(2020, 11, 28, 23, 54, 21, 261, DateTimeKind.Local).AddTicks(4471), "facilis" },
                    { 518, 41, 49, 283800, new DateTime(2021, 1, 20, 0, 4, 32, 554, DateTimeKind.Local).AddTicks(4129), "Omnis minima ex vero sint consequuntur nisi voluptatem." },
                    { 579, 41, 5, 261008, new DateTime(2021, 8, 11, 12, 41, 5, 404, DateTimeKind.Local).AddTicks(8481), "Omnis fugit porro blanditiis deleniti voluptatem dolor aperiam." },
                    { 334, 30, 114, 517921, new DateTime(2020, 11, 9, 13, 16, 26, 402, DateTimeKind.Local).AddTicks(3), "Cum vel consectetur nulla et cum rerum vitae. Qui possimus molestias quia voluptatem. Tempore qui id dolores dicta esse aperiam. Architecto perspiciatis odit dolores. Nihil perspiciatis quisquam." },
                    { 295, 30, 85, 585144, new DateTime(2021, 8, 16, 18, 51, 6, 189, DateTimeKind.Local).AddTicks(6900), "Veritatis libero ducimus similique fugiat.\nUt voluptas incidunt.\nNulla fugiat delectus nam sequi.\nVoluptas accusamus quaerat occaecati.\nEnim laudantium optio tenetur doloremque." },
                    { 235, 30, 136, 523765, new DateTime(2021, 3, 25, 22, 57, 55, 138, DateTimeKind.Local).AddTicks(6522), "quasi" },
                    { 57, 93, 70, 982354, new DateTime(2021, 7, 18, 7, 34, 24, 902, DateTimeKind.Local).AddTicks(900), "qui" },
                    { 206, 93, 70, 496593, new DateTime(2020, 9, 3, 8, 12, 58, 165, DateTimeKind.Local).AddTicks(1681), "Ea cupiditate labore quo. Error vero excepturi. Cupiditate fugiat blanditiis perspiciatis quod qui repudiandae." },
                    { 315, 41, 103, 967241, new DateTime(2021, 6, 24, 20, 20, 8, 445, DateTimeKind.Local).AddTicks(700), "Ex eos quisquam adipisci.\nQuas ab laboriosam expedita cumque sed consectetur quibusdam fugiat facilis.\nDolorem saepe ex earum quia soluta.\nIste nihil autem culpa est iure dignissimos quidem.\nQuia repellendus vero officia eum accusantium voluptatem at ipsa." },
                    { 418, 93, 61, 302521, new DateTime(2020, 12, 21, 12, 30, 6, 84, DateTimeKind.Local).AddTicks(6973), "saepe" },
                    { 527, 93, 69, 510725, new DateTime(2021, 8, 24, 19, 21, 25, 402, DateTimeKind.Local).AddTicks(5587), "dicta" },
                    { 580, 93, 143, 935438, new DateTime(2021, 4, 8, 19, 22, 47, 993, DateTimeKind.Local).AddTicks(5286), "Odio praesentium mollitia beatae repellendus architecto vitae porro. Et praesentium facere et. Molestiae eum et aliquam id omnis ipsum ratione asperiores cupiditate. Placeat deleniti odit quis dicta." },
                    { 70, 30, 119, 452490, new DateTime(2021, 4, 16, 0, 5, 37, 37, DateTimeKind.Local).AddTicks(5567), "nam" },
                    { 18, 19, 98, 22152, new DateTime(2020, 11, 28, 23, 51, 41, 31, DateTimeKind.Local).AddTicks(2358), "Eius a ducimus voluptatem et iste fugiat beatae sit." },
                    { 48, 19, 24, 562995, new DateTime(2020, 8, 30, 4, 59, 49, 250, DateTimeKind.Local).AddTicks(4528), "Tempore id est enim necessitatibus vel qui. Accusantium consequatur quia asperiores aut. Accusamus mollitia occaecati molestiae autem enim. Maxime voluptatem sint et vel. Magni totam ab dolores." },
                    { 65, 19, 25, 854924, new DateTime(2021, 4, 13, 21, 38, 27, 120, DateTimeKind.Local).AddTicks(4917), "Est sit et." },
                    { 127, 19, 36, 479239, new DateTime(2021, 1, 9, 14, 2, 0, 625, DateTimeKind.Local).AddTicks(8110), "Sit ratione consectetur enim harum natus assumenda." },
                    { 516, 93, 20, 117612, new DateTime(2021, 4, 17, 11, 59, 9, 77, DateTimeKind.Local).AddTicks(665), "Rerum et aut quo culpa." },
                    { 283, 6, 64, 742017, new DateTime(2021, 5, 16, 8, 15, 51, 341, DateTimeKind.Local).AddTicks(24), "Debitis et officiis aut et.\nVoluptatum ipsa ut et quibusdam tempore quos laboriosam.\nVoluptatibus repudiandae enim officia vitae in.\nQui alias laudantium quae illum." },
                    { 275, 6, 23, 179638, new DateTime(2020, 9, 3, 22, 33, 16, 317, DateTimeKind.Local).AddTicks(2805), "Consequatur rem similique quis. Qui quidem non ipsum. Adipisci dolorem illum provident aperiam illum. Quisquam neque corporis et voluptatibus fugiat itaque sint nostrum. Et voluptatum iste magnam dolores." },
                    { 39, 6, 121, 77018, new DateTime(2021, 4, 16, 11, 28, 1, 78, DateTimeKind.Local).AddTicks(5770), "voluptates" },
                    { 218, 63, 105, 106924, new DateTime(2021, 6, 13, 5, 1, 11, 101, DateTimeKind.Local).AddTicks(2545), "Eum id magni ut voluptatem." },
                    { 258, 63, 145, 517265, new DateTime(2020, 9, 7, 19, 47, 46, 412, DateTimeKind.Local).AddTicks(3212), "Velit alias atque sed repudiandae esse." },
                    { 338, 63, 57, 387646, new DateTime(2020, 11, 26, 11, 2, 50, 597, DateTimeKind.Local).AddTicks(7046), "Error et autem maxime voluptas quaerat quia perspiciatis neque. Modi optio fugit dolorem non nulla aliquam non ducimus. Enim consequatur assumenda et beatae. Ratione quibusdam quae repudiandae et eum. Nostrum et esse." },
                    { 395, 63, 132, 129913, new DateTime(2021, 5, 27, 8, 14, 8, 162, DateTimeKind.Local).AddTicks(1390), "Quia iusto accusamus. Aut voluptates eligendi qui tempora maiores et eligendi. Quas voluptate temporibus qui ut enim sed et voluptatibus. Autem cupiditate velit ipsum eos soluta. Dolor ut totam fugiat non animi nesciunt sequi est explicabo. Minus quibusdam ipsum ut eos ut similique quibusdam quod." },
                    { 455, 63, 33, 377324, new DateTime(2021, 7, 25, 0, 30, 32, 705, DateTimeKind.Local).AddTicks(6984), "Cupiditate asperiores fugit facilis. Quisquam aliquam quos in incidunt fugit repellat. Magnam ut dolorem." },
                    { 558, 63, 34, 155779, new DateTime(2021, 8, 18, 9, 57, 41, 123, DateTimeKind.Local).AddTicks(1130), "Velit totam quam veritatis ipsum iure.\nQuidem sint omnis culpa." },
                    { 100, 45, 87, 698838, new DateTime(2020, 11, 28, 16, 29, 18, 178, DateTimeKind.Local).AddTicks(5261), "dolor" },
                    { 178, 45, 31, 371844, new DateTime(2021, 6, 4, 19, 34, 55, 867, DateTimeKind.Local).AddTicks(8495), "quis" },
                    { 341, 45, 124, 358768, new DateTime(2021, 6, 12, 12, 17, 26, 973, DateTimeKind.Local).AddTicks(7671), "Fugit explicabo accusamus quaerat.\nVoluptates quisquam perferendis.\nCommodi vitae ducimus molestiae facere officia.\nQui ea cumque quod.\nFacere dolorum quisquam id enim accusantium ab unde blanditiis.\nEum quia accusantium non commodi at." },
                    { 430, 45, 74, 152463, new DateTime(2021, 1, 28, 12, 0, 42, 714, DateTimeKind.Local).AddTicks(589), "Officiis dicta ab." },
                    { 485, 45, 40, 549954, new DateTime(2021, 2, 5, 23, 17, 55, 171, DateTimeKind.Local).AddTicks(1133), "consectetur" },
                    { 544, 45, 126, 124855, new DateTime(2021, 8, 23, 1, 40, 44, 151, DateTimeKind.Local).AddTicks(8270), "commodi" },
                    { 72, 20, 126, 46087, new DateTime(2021, 6, 28, 18, 5, 30, 781, DateTimeKind.Local).AddTicks(2881), "autem" },
                    { 353, 20, 21, 136895, new DateTime(2020, 12, 30, 7, 59, 23, 215, DateTimeKind.Local).AddTicks(2200), "Nostrum veritatis laboriosam non quasi non commodi omnis dolore dignissimos." },
                    { 443, 20, 76, 664636, new DateTime(2021, 6, 22, 2, 1, 57, 937, DateTimeKind.Local).AddTicks(942), "Voluptas fugit eum dicta odit autem. Blanditiis cum sequi sint sequi fugiat eligendi non est. Inventore et ratione quaerat ad quos. Ea ea est id vel animi aperiam quae id fuga. Ipsam aut sequi et. Beatae est fugiat qui." },
                    { 196, 42, 70, 11363, new DateTime(2020, 10, 12, 9, 34, 38, 422, DateTimeKind.Local).AddTicks(3784), "Odit aut dolorem." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 581, 8, 1, 444710, new DateTime(2021, 8, 21, 10, 4, 46, 264, DateTimeKind.Local).AddTicks(624), "Eos non harum soluta qui. Voluptatem sit enim minima aut sed debitis. Dolor consectetur et rem nostrum totam architecto. Aperiam deserunt aut ut sunt quae cupiditate omnis omnis." },
                    { 426, 8, 63, 508124, new DateTime(2021, 6, 11, 16, 55, 4, 466, DateTimeKind.Local).AddTicks(6051), "Eos tempore est explicabo impedit fugiat.\nEt tenetur expedita unde qui optio ut fugit.\nUllam amet sequi impedit dolorum inventore dicta totam velit." },
                    { 397, 8, 65, 868579, new DateTime(2021, 3, 26, 4, 1, 13, 762, DateTimeKind.Local).AddTicks(6643), "Accusamus officia quia nihil distinctio beatae accusantium sed. Labore enim et delectus ipsum. Quas asperiores doloribus odit soluta officia ducimus natus. Ipsa et qui totam hic dolores numquam occaecati laborum omnis. Quidem eum et qui omnis unde." },
                    { 147, 75, 136, 135312, new DateTime(2021, 7, 13, 4, 43, 9, 862, DateTimeKind.Local).AddTicks(4084), "Nesciunt sequi earum nulla quasi non aut tempore." },
                    { 92, 75, 100, 122966, new DateTime(2021, 4, 3, 15, 3, 35, 150, DateTimeKind.Local).AddTicks(2948), "Ullam voluptas in beatae." },
                    { 88, 75, 106, 752344, new DateTime(2021, 4, 30, 14, 22, 18, 439, DateTimeKind.Local).AddTicks(9013), "vel" },
                    { 60, 75, 146, 268282, new DateTime(2021, 6, 5, 5, 59, 42, 404, DateTimeKind.Local).AddTicks(5388), "aut" },
                    { 91, 24, 8, 892145, new DateTime(2021, 3, 6, 7, 57, 37, 880, DateTimeKind.Local).AddTicks(9715), "Saepe placeat blanditiis esse corrupti nihil." },
                    { 162, 24, 24, 313807, new DateTime(2020, 9, 3, 20, 52, 54, 530, DateTimeKind.Local).AddTicks(6805), "Laborum est libero ut.\nSuscipit id repellendus praesentium amet veritatis doloremque.\nQuasi dolorem aliquam consequatur molestiae perspiciatis unde delectus consequuntur sunt.\nUt expedita et ut incidunt ullam.\nFacilis totam eius amet consequatur alias omnis laudantium.\nQuos ut ducimus sed quia." },
                    { 354, 24, 109, 539324, new DateTime(2020, 8, 30, 12, 31, 20, 258, DateTimeKind.Local).AddTicks(4811), "Nulla ratione libero sit accusantium quasi. Soluta nisi ipsa delectus eius sequi aperiam fugit quis. Minima fugiat quia recusandae qui. Qui laboriosam debitis doloremque aut enim dolor. Maiores ut fugit omnis odit possimus unde ut." },
                    { 529, 20, 116, 526077, new DateTime(2021, 8, 11, 1, 0, 43, 712, DateTimeKind.Local).AddTicks(7213), "Modi et doloremque delectus modi." },
                    { 411, 24, 70, 735822, new DateTime(2021, 7, 2, 14, 4, 54, 644, DateTimeKind.Local).AddTicks(7157), "Aut quo quo repudiandae rem et nesciunt. Impedit et alias. Sed maiores rerum et nobis labore voluptatum. Est alias voluptatem voluptatem sint eos. Et id omnis magnam impedit doloribus qui facilis et. Quia consequatur voluptatem officiis non nostrum eius harum." },
                    { 571, 24, 59, 852352, new DateTime(2021, 4, 6, 20, 49, 29, 654, DateTimeKind.Local).AddTicks(6735), "Itaque dolorem aliquam aut." },
                    { 543, 42, 107, 589952, new DateTime(2021, 6, 4, 16, 29, 54, 971, DateTimeKind.Local).AddTicks(7015), "Ab quia sit tenetur assumenda nihil est consequatur illo minima. Quas et libero similique possimus officiis. Aut officiis ullam et." },
                    { 28, 8, 120, 940975, new DateTime(2021, 1, 13, 18, 26, 29, 465, DateTimeKind.Local).AddTicks(366), "ut" },
                    { 87, 8, 120, 976368, new DateTime(2021, 7, 26, 4, 51, 0, 578, DateTimeKind.Local).AddTicks(1686), "et" },
                    { 143, 8, 23, 153756, new DateTime(2021, 1, 31, 16, 35, 2, 180, DateTimeKind.Local).AddTicks(2942), "Amet cupiditate molestiae vel et nostrum ullam minima repellat omnis. Voluptas et aperiam voluptatum cum iste. Eveniet accusamus tenetur vero. Voluptas expedita rem natus quod. Reprehenderit et officia aperiam nulla cum." },
                    { 318, 8, 148, 431467, new DateTime(2021, 4, 13, 4, 54, 31, 922, DateTimeKind.Local).AddTicks(9081), "facere" },
                    { 343, 8, 68, 252103, new DateTime(2021, 7, 9, 2, 16, 19, 945, DateTimeKind.Local).AddTicks(7544), "Dolorem modi nisi dolore quae modi repudiandae dolores occaecati at." },
                    { 533, 24, 111, 754284, new DateTime(2020, 12, 4, 22, 19, 51, 808, DateTimeKind.Local).AddTicks(7411), "Blanditiis ratione repellat. Voluptatem omnis rerum hic mollitia harum eum sed. Occaecati quibusdam officiis fuga. Velit voluptatum vel non hic deserunt doloribus sunt vitae itaque." },
                    { 541, 20, 31, 313763, new DateTime(2020, 11, 6, 19, 42, 23, 1, DateTimeKind.Local).AddTicks(3793), "repudiandae" },
                    { 600, 7, 80, 985078, new DateTime(2020, 11, 16, 0, 16, 51, 754, DateTimeKind.Local).AddTicks(6286), "Est voluptas dolorem sunt nihil dolore odit deleniti occaecati veniam." },
                    { 594, 7, 80, 328555, new DateTime(2021, 2, 8, 9, 23, 18, 259, DateTimeKind.Local).AddTicks(3793), "Reiciendis eveniet quis fugiat.\nPariatur aut illum perferendis voluptatem culpa id debitis et.\nNihil dolorum rerum praesentium omnis.\nAt omnis magnam dolor velit provident.\nQuia dolore omnis et dolorem id ratione." },
                    { 238, 12, 33, 416398, new DateTime(2021, 5, 15, 5, 25, 42, 127, DateTimeKind.Local).AddTicks(9820), "Qui qui id impedit vero." },
                    { 82, 12, 126, 595099, new DateTime(2021, 1, 30, 6, 59, 58, 446, DateTimeKind.Local).AddTicks(1881), "Commodi et voluptatem quo ut excepturi. Aut dolor facilis hic. Quibusdam mollitia adipisci corrupti voluptatibus eius necessitatibus." },
                    { 40, 12, 23, 802264, new DateTime(2021, 2, 10, 2, 38, 40, 225, DateTimeKind.Local).AddTicks(956), "Nulla aliquam aperiam iste consequuntur qui voluptas." },
                    { 590, 87, 29, 111892, new DateTime(2020, 10, 7, 23, 38, 50, 980, DateTimeKind.Local).AddTicks(2134), "Numquam suscipit qui fugiat occaecati.\nVelit dignissimos enim eaque enim qui quisquam ex id.\nUt sequi deleniti quam corrupti sunt." },
                    { 549, 87, 99, 759206, new DateTime(2021, 2, 5, 19, 57, 9, 488, DateTimeKind.Local).AddTicks(6406), "Qui labore dolores repudiandae." },
                    { 317, 87, 96, 970084, new DateTime(2021, 2, 13, 0, 14, 6, 793, DateTimeKind.Local).AddTicks(5931), "nam" },
                    { 55, 5, 118, 934297, new DateTime(2021, 5, 5, 17, 53, 58, 283, DateTimeKind.Local).AddTicks(5610), "Odit ut et doloribus natus minus est.\nAliquam veritatis est beatae sint.\nSaepe voluptatem facere quos est.\nTempore illo est et sed qui placeat omnis at.\nTemporibus qui cupiditate rerum nisi recusandae architecto doloremque facilis repudiandae." },
                    { 458, 60, 149, 944451, new DateTime(2021, 2, 3, 15, 32, 28, 683, DateTimeKind.Local).AddTicks(3857), "Et pariatur aliquam architecto et fugit ut quas corporis." },
                    { 56, 5, 82, 847907, new DateTime(2020, 9, 18, 13, 35, 52, 508, DateTimeKind.Local).AddTicks(964), "Maiores necessitatibus fugiat commodi delectus omnis reiciendis." },
                    { 173, 5, 150, 801923, new DateTime(2021, 1, 7, 18, 28, 32, 161, DateTimeKind.Local).AddTicks(1770), "Repellat quidem fugiat." },
                    { 212, 5, 146, 88076, new DateTime(2021, 8, 20, 12, 22, 7, 367, DateTimeKind.Local).AddTicks(7965), "Est rerum vel perferendis quis libero minima sit in ad." },
                    { 265, 5, 53, 46029, new DateTime(2021, 7, 23, 14, 39, 20, 193, DateTimeKind.Local).AddTicks(2277), "Ut qui quisquam iure quia ea necessitatibus occaecati et aut." },
                    { 383, 5, 31, 169395, new DateTime(2021, 1, 6, 0, 25, 8, 534, DateTimeKind.Local).AddTicks(749), "ut" },
                    { 584, 5, 13, 564598, new DateTime(2020, 11, 11, 2, 8, 5, 104, DateTimeKind.Local).AddTicks(8334), "tempore" },
                    { 233, 87, 122, 913191, new DateTime(2021, 6, 30, 10, 6, 51, 722, DateTimeKind.Local).AddTicks(7264), "Vel molestias nemo repellat esse omnis pariatur voluptas est. Porro quisquam quas. Earum iure non nam sed fuga." },
                    { 17, 6, 134, 527235, new DateTime(2021, 1, 27, 22, 59, 32, 526, DateTimeKind.Local).AddTicks(5648), "Corporis esse ea quo ipsam voluptatem ratione non praesentium impedit.\nSit sit eos aperiam reiciendis cumque.\nEst expedita dolorum.\nIusto possimus nostrum qui eius ipsum impedit iste qui." },
                    { 104, 5, 64, 578412, new DateTime(2021, 7, 31, 4, 12, 13, 531, DateTimeKind.Local).AddTicks(3058), "Est nam pariatur.\nRerum delectus autem labore.\nCupiditate magni et possimus accusantium.\nAut quidem alias molestias." },
                    { 567, 14, 33, 509312, new DateTime(2021, 7, 1, 15, 3, 44, 809, DateTimeKind.Local).AddTicks(9109), "Quisquam qui totam blanditiis voluptas soluta. Omnis sed et. Eaque explicabo quidem odio amet nesciunt eaque autem." },
                    { 414, 60, 30, 340742, new DateTime(2020, 12, 25, 2, 25, 0, 590, DateTimeKind.Local).AddTicks(4000), "Unde exercitationem sint sed nisi minus eveniet ea officiis voluptas. Voluptas quo ipsa nobis voluptas ea ut. Id corporis itaque amet deleniti minus quidem blanditiis non. Aperiam odio a error ut." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 304, 60, 5, 470579, new DateTime(2021, 6, 21, 9, 59, 22, 456, DateTimeKind.Local).AddTicks(7748), "Nemo inventore ipsum hic. Quos culpa excepturi soluta natus impedit et repudiandae. In et iste sit excepturi. Officia magnam nisi quo voluptatibus dolor qui eum nemo. Quia tempore velit libero." },
                    { 228, 7, 115, 121179, new DateTime(2021, 6, 12, 23, 24, 51, 358, DateTimeKind.Local).AddTicks(7798), "Eveniet reprehenderit debitis nulla et.\nQuia accusamus voluptatibus sed rerum doloribus quae molestiae rerum explicabo.\nOfficiis ratione omnis quas explicabo." },
                    { 44, 22, 40, 609179, new DateTime(2021, 7, 11, 7, 33, 57, 115, DateTimeKind.Local).AddTicks(9421), "Quia dolorem quaerat beatae." },
                    { 94, 22, 72, 12516, new DateTime(2021, 7, 11, 8, 13, 21, 459, DateTimeKind.Local).AddTicks(7458), "Rerum sed veritatis repellendus suscipit amet amet incidunt.\nQui error iusto molestiae velit.\nQuia quia ut repellat amet et libero.\nNecessitatibus cum voluptatum modi similique aut.\nMolestiae maiores dolor nihil ut qui." },
                    { 129, 22, 138, 763935, new DateTime(2021, 7, 26, 13, 42, 44, 666, DateTimeKind.Local).AddTicks(559), "Omnis expedita voluptatem dolor repellendus velit labore ullam similique quia." },
                    { 144, 22, 138, 715774, new DateTime(2020, 10, 31, 13, 30, 43, 516, DateTimeKind.Local).AddTicks(8732), "Sed sed qui atque molestiae est maxime rerum a ipsa.\nAut molestiae sit aliquam aut est ratione minus natus.\nEst voluptates quibusdam minus repellendus ea voluptates occaecati rem.\nTempora aut voluptatibus.\nVeritatis sit ipsum quae hic repellat occaecati et." },
                    { 189, 22, 46, 355386, new DateTime(2020, 11, 15, 14, 24, 15, 946, DateTimeKind.Local).AddTicks(4665), "libero" },
                    { 331, 22, 149, 603956, new DateTime(2021, 1, 23, 19, 22, 13, 509, DateTimeKind.Local).AddTicks(2350), "quia" },
                    { 381, 60, 140, 444121, new DateTime(2021, 5, 18, 2, 56, 42, 72, DateTimeKind.Local).AddTicks(7942), "Eum non dolores perferendis.\nCorporis vel eius accusantium qui nihil.\nTotam quod eum alias ipsum rerum laudantium nihil iusto.\nMinima ut minus." },
                    { 366, 22, 1, 817685, new DateTime(2021, 6, 25, 13, 20, 12, 468, DateTimeKind.Local).AddTicks(4787), "Ut veritatis iste quia asperiores quos.\nConsequatur perferendis quia.\nVoluptate ipsam molestiae." },
                    { 405, 22, 10, 430798, new DateTime(2021, 1, 5, 19, 1, 34, 252, DateTimeKind.Local).AddTicks(3805), "Qui quia explicabo ut. Optio laudantium ut consequatur cupiditate ullam occaecati qui hic rerum. Voluptas cumque sed cum aut aspernatur voluptatem. Magnam occaecati est voluptatem. Sed aut harum et sunt numquam." },
                    { 560, 22, 72, 226240, new DateTime(2021, 5, 22, 23, 51, 20, 317, DateTimeKind.Local).AddTicks(52), "soluta" },
                    { 151, 7, 93, 968349, new DateTime(2021, 2, 24, 21, 2, 48, 845, DateTimeKind.Local).AddTicks(7494), "Totam sit nemo nesciunt magni. Eos quidem similique in. Et praesentium sint aliquam. Recusandae porro porro repudiandae illo nihil inventore. Quia architecto labore ut amet a magnam ad. Eveniet est error quasi possimus modi natus molestiae reiciendis at." },
                    { 536, 12, 34, 912204, new DateTime(2021, 7, 6, 4, 50, 45, 458, DateTimeKind.Local).AddTicks(8739), "Sed voluptatem veniam nobis soluta labore et magnam ipsam." },
                    { 408, 12, 74, 634925, new DateTime(2021, 8, 3, 3, 47, 6, 398, DateTimeKind.Local).AddTicks(5232), "Sit debitis quis sapiente." },
                    { 241, 12, 75, 431025, new DateTime(2021, 8, 17, 20, 8, 19, 132, DateTimeKind.Local).AddTicks(5981), "Et rem vitae corporis repudiandae animi. Iusto et consectetur facilis vero. Velit occaecati placeat omnis eum sit architecto. Quis possimus autem est quisquam. Dolores magnam repudiandae sapiente ut aut aspernatur tempore quo." },
                    { 85, 60, 130, 192546, new DateTime(2021, 7, 30, 23, 4, 58, 127, DateTimeKind.Local).AddTicks(8956), "non" },
                    { 378, 22, 27, 219615, new DateTime(2021, 8, 15, 23, 46, 32, 214, DateTimeKind.Local).AddTicks(945), "Et soluta repellat minima.\nNon fugiat eius alias odit non.\nSequi sint et fugiat dolore qui provident.\nAut unde non nisi cumque veritatis nisi unde inventore.\nExpedita recusandae ut voluptas amet totam dolorem cupiditate illum aut.\nMinima laboriosam porro voluptas exercitationem possimus delectus sit." },
                    { 74, 46, 136, 883027, new DateTime(2021, 3, 9, 13, 13, 15, 814, DateTimeKind.Local).AddTicks(7441), "Et commodi beatae velit ut est harum error odit.\nDeserunt culpa cum." },
                    { 508, 46, 108, 380675, new DateTime(2021, 3, 19, 21, 3, 30, 406, DateTimeKind.Local).AddTicks(6789), "neque" },
                    { 554, 55, 6, 10728, new DateTime(2020, 10, 3, 11, 0, 37, 208, DateTimeKind.Local).AddTicks(7120), "maiores" },
                    { 421, 2, 149, 990796, new DateTime(2021, 1, 26, 11, 38, 54, 179, DateTimeKind.Local).AddTicks(1740), "Ut est autem in.\nExplicabo molestias in nemo eius iusto neque sunt a non.\nNon ut debitis odit vitae in.\nAsperiores iure dolores est commodi." },
                    { 477, 2, 129, 356191, new DateTime(2021, 7, 31, 3, 14, 20, 925, DateTimeKind.Local).AddTicks(2685), "Temporibus quis modi voluptatum numquam facere doloremque sunt necessitatibus ut. Mollitia dolores ut mollitia quos sint tenetur. Sed velit et. Quo vel et praesentium. Harum aut possimus illo est iste vel." },
                    { 598, 2, 23, 290901, new DateTime(2021, 3, 30, 12, 54, 14, 5, DateTimeKind.Local).AddTicks(1132), "voluptatem" },
                    { 263, 16, 121, 894952, new DateTime(2020, 11, 25, 15, 49, 45, 504, DateTimeKind.Local).AddTicks(11), "Aut delectus quia quia repellendus." },
                    { 119, 16, 96, 304745, new DateTime(2021, 4, 10, 14, 55, 8, 428, DateTimeKind.Local).AddTicks(6045), "Temporibus consectetur sunt qui molestiae qui." },
                    { 68, 16, 107, 219223, new DateTime(2020, 9, 25, 17, 2, 15, 229, DateTimeKind.Local).AddTicks(7602), "Laudantium doloremque nostrum delectus. Maiores repellendus ratione molestias quaerat culpa nostrum sit omnis. Rem possimus doloribus sed saepe pariatur maxime et hic. Id commodi magni excepturi ut autem dolorem dolorem sit eos. Sit itaque et sed nobis deserunt aut aut. Fugiat qui incidunt." },
                    { 257, 74, 95, 356730, new DateTime(2021, 1, 15, 15, 59, 3, 994, DateTimeKind.Local).AddTicks(2788), "Accusamus ratione similique amet molestiae. Dicta voluptatem debitis. Ipsa harum earum." },
                    { 328, 74, 32, 586119, new DateTime(2021, 8, 27, 2, 4, 6, 568, DateTimeKind.Local).AddTicks(7198), "Dolorem assumenda ipsam rerum facere culpa sunt ut perferendis.\nVoluptas explicabo voluptatibus saepe incidunt eos repellendus.\nAdipisci consequatur qui harum." },
                    { 335, 74, 15, 656375, new DateTime(2020, 10, 22, 6, 59, 35, 896, DateTimeKind.Local).AddTicks(4488), "Sed iste illum quae quo amet optio.\nOmnis neque autem ut possimus.\nNemo dolorum quaerat rerum nam.\nUllam occaecati dolor." },
                    { 513, 74, 7, 489367, new DateTime(2021, 8, 12, 18, 0, 12, 492, DateTimeKind.Local).AddTicks(8603), "A molestias officiis animi fugiat quia consequatur fugiat ipsam officiis." },
                    { 553, 74, 58, 332352, new DateTime(2021, 3, 16, 3, 14, 55, 733, DateTimeKind.Local).AddTicks(6949), "Dolorem rerum illo laudantium in suscipit veritatis animi maiores dolorem." },
                    { 16, 16, 52, 631827, new DateTime(2021, 6, 1, 14, 33, 4, 41, DateTimeKind.Local).AddTicks(9571), "Quis sit reprehenderit fuga ex non magnam.\nOmnis amet velit culpa architecto alias ab.\nDolores harum ex dolore et ducimus debitis reiciendis ut rerum.\nAspernatur velit nisi est.\nRatione illo voluptatibus consectetur voluptas nesciunt.\nAd animi voluptate dolorem perferendis ut excepturi aliquid voluptas aut." },
                    { 470, 32, 82, 488074, new DateTime(2021, 6, 27, 7, 42, 4, 841, DateTimeKind.Local).AddTicks(563), "Qui sed eos dicta cum eaque quia.\nVero earum at consequatur ut.\nId voluptas suscipit deleniti esse consequatur ut officia ullam magni.\nNatus reprehenderit unde animi eos sint.\nPossimus eveniet cumque ut eos non ut perspiciatis velit rem." },
                    { 10, 58, 102, 629077, new DateTime(2020, 9, 9, 10, 46, 16, 566, DateTimeKind.Local).AddTicks(4728), "Commodi ut suscipit qui optio inventore aliquam a." },
                    { 97, 58, 64, 961660, new DateTime(2020, 10, 16, 21, 8, 47, 839, DateTimeKind.Local).AddTicks(1355), "odit" },
                    { 298, 2, 112, 468265, new DateTime(2020, 12, 20, 3, 59, 59, 200, DateTimeKind.Local).AddTicks(6532), "Exercitationem suscipit distinctio officiis. Veritatis et voluptatem expedita sed facere accusantium rem omnis. Omnis doloribus et ipsum eum harum sit sunt inventore. Optio at voluptates quo voluptatem id." },
                    { 172, 58, 9, 70323, new DateTime(2021, 8, 1, 17, 24, 26, 454, DateTimeKind.Local).AddTicks(1236), "Velit qui accusamus dolorum enim mollitia. Quas mollitia et repellendus. Iure voluptatem iste omnis cumque commodi." },
                    { 267, 2, 52, 800650, new DateTime(2021, 3, 18, 17, 24, 28, 561, DateTimeKind.Local).AddTicks(5412), "Ut porro nesciunt iste qui nostrum enim placeat eum sapiente.\nEst inventore enim harum suscipit quasi alias qui corrupti.\nSint architecto aperiam velit quaerat.\nMinima rerum iure incidunt repellat facere voluptates.\nSit necessitatibus quibusdam voluptas." },
                    { 95, 2, 3, 576602, new DateTime(2020, 12, 31, 3, 17, 29, 493, DateTimeKind.Local).AddTicks(4322), "Dolor velit eveniet officia totam." },
                    { 345, 53, 72, 638485, new DateTime(2021, 4, 29, 0, 54, 0, 492, DateTimeKind.Local).AddTicks(6758), "Nihil nobis error mollitia sequi enim magnam eveniet necessitatibus nesciunt.\nPlaceat est quo dolor earum.\nQuia consectetur quo dolorum perferendis enim quo et.\nAut hic consequatur modi quis adipisci aliquam." },
                    { 280, 53, 118, 54185, new DateTime(2020, 9, 8, 20, 31, 23, 387, DateTimeKind.Local).AddTicks(417), "a" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 211, 71, 97, 160060, new DateTime(2020, 11, 14, 11, 43, 37, 294, DateTimeKind.Local).AddTicks(7335), "Et velit ut ea enim eius dolores est. Non aut dolorem rerum hic iure eum ut qui ut. Temporibus est in. Eligendi doloribus eaque sint et repudiandae voluptas possimus velit ipsum. Omnis ipsum quaerat ad. Possimus numquam ipsam aut blanditiis unde aut." },
                    { 573, 16, 132, 163155, new DateTime(2020, 9, 23, 12, 50, 14, 815, DateTimeKind.Local).AddTicks(6881), "Laudantium aut voluptatem sed soluta eveniet minus.\nRatione incidunt soluta quaerat provident odio officia minus consequuntur." },
                    { 562, 16, 118, 836153, new DateTime(2020, 11, 10, 23, 8, 19, 504, DateTimeKind.Local).AddTicks(6867), "Facilis voluptatem provident dolores quod voluptatem laboriosam." },
                    { 34, 1, 49, 58535, new DateTime(2021, 5, 1, 18, 5, 47, 461, DateTimeKind.Local).AddTicks(43), "Dolorem fugiat at neque quod voluptas doloribus voluptas impedit." },
                    { 154, 1, 140, 257692, new DateTime(2021, 1, 18, 21, 17, 40, 746, DateTimeKind.Local).AddTicks(7828), "Et dolor architecto voluptatem inventore nisi aliquam.\nDolores aut aut doloribus.\nRepudiandae est itaque consequatur." },
                    { 213, 1, 75, 367267, new DateTime(2021, 3, 24, 9, 36, 36, 959, DateTimeKind.Local).AddTicks(3242), "Expedita rerum et quis nisi in quis sint occaecati.\nDebitis aliquam omnis quod.\nDeleniti eos molestiae tempora fugiat.\nEt deserunt repellat aliquid dolor itaque exercitationem.\nVelit culpa in quae quia aut aut dolores cupiditate." },
                    { 380, 1, 108, 400552, new DateTime(2021, 4, 29, 5, 58, 2, 670, DateTimeKind.Local).AddTicks(831), "Veniam nesciunt inventore ducimus deserunt sit ipsam." },
                    { 474, 1, 41, 279733, new DateTime(2020, 9, 16, 22, 57, 13, 97, DateTimeKind.Local).AddTicks(3249), "Ducimus voluptate asperiores quas illo libero magnam illo esse.\nVoluptatem possimus officiis soluta.\nSunt voluptas temporibus harum.\nAutem exercitationem cumque accusantium aliquid adipisci ea deleniti.\nEa repudiandae aspernatur qui quia dolor et saepe." },
                    { 475, 1, 92, 113677, new DateTime(2021, 3, 16, 15, 9, 18, 541, DateTimeKind.Local).AddTicks(6172), "Porro cupiditate reprehenderit consequuntur asperiores." },
                    { 557, 1, 85, 322405, new DateTime(2020, 12, 4, 5, 51, 14, 997, DateTimeKind.Local).AddTicks(6601), "voluptatem" },
                    { 464, 16, 71, 837977, new DateTime(2021, 2, 24, 7, 20, 50, 386, DateTimeKind.Local).AddTicks(9652), "Vel aut voluptatibus sed. Blanditiis inventore quibusdam ut eveniet modi dignissimos architecto. Deserunt autem id voluptas est accusamus." },
                    { 323, 16, 109, 769404, new DateTime(2021, 8, 25, 11, 40, 47, 627, DateTimeKind.Local).AddTicks(3693), "Voluptates dolores commodi et quae.\nNeque dicta adipisci magni ut voluptatum omnis incidunt.\nRatione ab dolorem minima.\nFacere adipisci corporis architecto magnam ipsam.\nCulpa cupiditate dolorem optio laboriosam consequatur.\nDistinctio et tempore modi sit rerum et voluptas." },
                    { 62, 2, 64, 728463, new DateTime(2020, 10, 25, 21, 38, 55, 489, DateTimeKind.Local).AddTicks(8370), "Libero vel quasi nihil." },
                    { 261, 2, 50, 963921, new DateTime(2020, 12, 20, 22, 56, 8, 450, DateTimeKind.Local).AddTicks(5009), "Aut impedit quisquam facere." },
                    { 186, 58, 65, 165079, new DateTime(2020, 9, 20, 11, 38, 32, 376, DateTimeKind.Local).AddTicks(8373), "dignissimos" },
                    { 292, 58, 85, 175335, new DateTime(2021, 2, 3, 10, 5, 11, 962, DateTimeKind.Local).AddTicks(7632), "Enim exercitationem quas maxime.\nExplicabo sunt consequatur adipisci.\nQui voluptas ducimus voluptates consectetur et est.\nBeatae eos fuga in voluptatem ratione sunt." },
                    { 352, 58, 38, 599598, new DateTime(2020, 10, 11, 10, 57, 13, 56, DateTimeKind.Local).AddTicks(5537), "Et corporis ut facilis itaque atque modi ratione. Totam magni minus vero et explicabo facere. Consequatur impedit tempora similique saepe distinctio et quibusdam. Vel saepe quia rem libero qui reprehenderit illum a." },
                    { 498, 55, 32, 142707, new DateTime(2021, 6, 28, 16, 40, 56, 120, DateTimeKind.Local).AddTicks(5112), "Sunt et ut ab quam dolor sint. Ex odit dolores sed vel eius non. Ad consequuntur ipsum et ut omnis. Molestias possimus dolorem animi consectetur corporis eos et aut atque." },
                    { 511, 67, 52, 501253, new DateTime(2021, 5, 15, 9, 34, 22, 453, DateTimeKind.Local).AddTicks(7726), "veritatis" },
                    { 297, 10, 141, 824, new DateTime(2020, 12, 19, 0, 10, 42, 686, DateTimeKind.Local).AddTicks(4983), "Distinctio nobis aut mollitia perferendis ut consequatur doloribus qui nam.\nNihil accusantium aliquam aspernatur voluptates.\nSed facere et et ut soluta consequatur distinctio magnam.\nSoluta eligendi atque alias et molestiae sapiente animi.\nMagnam tempore qui est qui ipsa non et sit.\nBeatae aut ab ea reprehenderit rerum maiores tempora odit." },
                    { 274, 10, 55, 358931, new DateTime(2021, 8, 18, 2, 59, 17, 712, DateTimeKind.Local).AddTicks(2351), "Perferendis consequatur in illum aperiam. At vel quae laborum vitae. Quo expedita laborum ex error quam et dolorum iste. Sunt ut sint provident. Sit odio provident quia et." },
                    { 168, 10, 62, 39432, new DateTime(2021, 4, 14, 5, 39, 18, 633, DateTimeKind.Local).AddTicks(7213), "Illo minima expedita vel tempore reiciendis velit." },
                    { 146, 78, 63, 770418, new DateTime(2021, 8, 6, 3, 15, 10, 201, DateTimeKind.Local).AddTicks(1071), "Quo consequatur corrupti aut facilis. Rerum cum consectetur sint iste aut dolor error. Quia sunt vitae quas et. Deserunt totam aut. Quis saepe aut." },
                    { 262, 78, 8, 290717, new DateTime(2020, 10, 14, 3, 18, 18, 832, DateTimeKind.Local).AddTicks(7709), "Laboriosam eum laborum et est a error voluptate corporis aut.\nAnimi possimus perspiciatis molestias dolor ut iusto occaecati animi.\nEst laboriosam nihil quia eligendi numquam fugiat quo earum maxime.\nAperiam recusandae inventore quisquam similique officiis molestiae." },
                    { 384, 78, 82, 26779, new DateTime(2021, 4, 29, 4, 49, 44, 970, DateTimeKind.Local).AddTicks(7653), "dolores" },
                    { 454, 78, 90, 818462, new DateTime(2021, 6, 14, 20, 59, 55, 266, DateTimeKind.Local).AddTicks(2706), "Eum exercitationem at vero nostrum consequatur voluptatibus. Expedita est quia. Deserunt voluptas corporis pariatur suscipit occaecati sed eius esse. Quae provident voluptatem repellendus aspernatur." },
                    { 501, 78, 119, 208637, new DateTime(2021, 1, 13, 3, 24, 21, 419, DateTimeKind.Local).AddTicks(4721), "Ab est beatae." },
                    { 525, 78, 62, 203630, new DateTime(2021, 5, 19, 13, 55, 55, 953, DateTimeKind.Local).AddTicks(7731), "Fugiat rerum consequatur ut facere et necessitatibus. Sunt rerum aperiam alias incidunt. Praesentium reiciendis et quod ut expedita. Eum aut asperiores deleniti accusamus." },
                    { 555, 78, 60, 83166, new DateTime(2021, 7, 21, 17, 58, 50, 176, DateTimeKind.Local).AddTicks(3453), "alias" },
                    { 110, 10, 4, 240496, new DateTime(2021, 5, 15, 18, 26, 46, 211, DateTimeKind.Local).AddTicks(8336), "Cupiditate facilis nihil reiciendis necessitatibus excepturi qui.\nIure repellendus tenetur libero temporibus sed neque." },
                    { 69, 90, 110, 33592, new DateTime(2021, 2, 28, 9, 12, 53, 856, DateTimeKind.Local).AddTicks(1982), "Porro incidunt laboriosam architecto neque.\nEt harum ad rerum velit totam alias.\nConsequuntur qui illum et dicta quia aliquam id eum officiis.\nVoluptatem dolores non.\nEt expedita rem saepe eos.\nDucimus cum et et." },
                    { 113, 90, 28, 738070, new DateTime(2021, 3, 6, 21, 41, 5, 572, DateTimeKind.Local).AddTicks(8759), "optio" },
                    { 417, 55, 123, 439451, new DateTime(2020, 11, 5, 16, 43, 58, 678, DateTimeKind.Local).AddTicks(8821), "cupiditate" },
                    { 347, 10, 30, 545160, new DateTime(2021, 3, 20, 16, 7, 5, 640, DateTimeKind.Local).AddTicks(3860), "Soluta cupiditate inventore hic sequi harum. Dolores error ut molestiae qui modi. Non explicabo nihil incidunt aspernatur porro ducimus amet. Laborum et incidunt non." },
                    { 351, 10, 5, 87, new DateTime(2021, 1, 3, 0, 13, 14, 287, DateTimeKind.Local).AddTicks(4868), "veniam" },
                    { 432, 10, 144, 176319, new DateTime(2021, 1, 7, 0, 6, 20, 810, DateTimeKind.Local).AddTicks(2343), "aut" },
                    { 369, 58, 19, 50035, new DateTime(2021, 3, 6, 2, 40, 59, 603, DateTimeKind.Local).AddTicks(8024), "Voluptatibus consequatur omnis explicabo in reprehenderit.\nSed qui maxime possimus labore aspernatur ut." },
                    { 407, 58, 94, 638830, new DateTime(2021, 2, 11, 19, 35, 4, 184, DateTimeKind.Local).AddTicks(8219), "Dignissimos fugiat totam rerum libero et commodi minus nemo dolor." },
                    { 483, 58, 126, 197986, new DateTime(2020, 10, 5, 10, 5, 9, 540, DateTimeKind.Local).AddTicks(3631), "Qui repudiandae quam non ipsum ut minima. Itaque ad velit. Non saepe quas maiores corporis. Consequatur quis sed amet quia numquam. Repellat dolores nobis dolore veritatis et. Maxime voluptas aut nam voluptatibus dolores hic dolorem." },
                    { 535, 58, 5, 263372, new DateTime(2021, 7, 24, 18, 23, 39, 236, DateTimeKind.Local).AddTicks(9362), "Voluptate ea eos doloribus dignissimos aut odio dicta nam eum. Dolore adipisci voluptate cumque maxime eligendi cumque modi. Iure rerum quis fugit nihil omnis quam sed dolorem. Excepturi perspiciatis suscipit architecto sit qui. Explicabo quos fuga ipsam nesciunt beatae. Voluptas similique voluptas quae quisquam aut." },
                    { 393, 32, 32, 240910, new DateTime(2021, 1, 17, 14, 19, 45, 142, DateTimeKind.Local).AddTicks(8809), "Et labore vitae." },
                    { 93, 32, 70, 217992, new DateTime(2021, 7, 7, 17, 4, 13, 537, DateTimeKind.Local).AddTicks(5333), "Laboriosam aliquid cumque. Nostrum nihil voluptatem temporibus saepe. Et laboriosam doloribus sint consectetur quibusdam error libero. Id odio eos laudantium accusantium saepe et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 109, 35, 56, 367885, new DateTime(2021, 7, 20, 7, 8, 47, 376, DateTimeKind.Local).AddTicks(8358), "Autem aliquid accusamus et dolorem molestiae at laboriosam nihil." },
                    { 569, 47, 103, 544040, new DateTime(2021, 3, 25, 21, 11, 7, 201, DateTimeKind.Local).AddTicks(5942), "Voluptas quod sint omnis quam iste voluptatem." },
                    { 159, 35, 57, 622307, new DateTime(2021, 5, 25, 6, 35, 31, 631, DateTimeKind.Local).AddTicks(573), "Officia quod repellendus eius amet alias.\nDignissimos libero sit fugiat deserunt.\nNatus error dolorem aut.\nIure quo amet asperiores porro maiores dolor.\nExpedita molestiae facilis ipsum ut nihil perspiciatis natus sit consequatur." },
                    { 559, 35, 148, 747225, new DateTime(2021, 3, 20, 14, 3, 5, 984, DateTimeKind.Local).AddTicks(8238), "Voluptatem qui iure minus sed adipisci fugiat eligendi perspiciatis.\nIusto eum in temporibus est voluptas non voluptates autem omnis.\nQui quos perspiciatis et vel sapiente dicta.\nVoluptatum quas est." },
                    { 577, 35, 116, 599858, new DateTime(2021, 6, 1, 19, 39, 38, 865, DateTimeKind.Local).AddTicks(1091), "Consectetur id nemo.\nEnim facere aut quas ea qui inventore quia.\nSit ut modi sint est pariatur et exercitationem fuga.\nDoloribus laudantium voluptate corporis et.\nOfficiis nemo voluptates perspiciatis." },
                    { 441, 10, 123, 605966, new DateTime(2021, 2, 22, 17, 40, 21, 615, DateTimeKind.Local).AddTicks(7911), "Dolor ea at. Ea quaerat id asperiores est aut perferendis. Non et minus non quo tempora." },
                    { 259, 37, 16, 877307, new DateTime(2021, 3, 19, 3, 41, 9, 110, DateTimeKind.Local).AddTicks(4655), "numquam" },
                    { 362, 37, 143, 508014, new DateTime(2021, 1, 11, 8, 50, 16, 641, DateTimeKind.Local).AddTicks(6963), "ea" },
                    { 496, 37, 84, 231328, new DateTime(2020, 11, 21, 1, 30, 51, 83, DateTimeKind.Local).AddTicks(2098), "hic" },
                    { 521, 37, 92, 50907, new DateTime(2020, 12, 26, 15, 49, 26, 344, DateTimeKind.Local).AddTicks(1504), "Possimus in iure et voluptatem ad sunt ipsum.\nQui labore ratione libero sit aut sit.\nQui et laboriosam atque tenetur qui maxime." },
                    { 281, 35, 48, 31984, new DateTime(2021, 1, 14, 23, 9, 44, 883, DateTimeKind.Local).AddTicks(572), "Fugiat qui quidem officiis aut doloremque nobis sed mollitia debitis." },
                    { 386, 47, 60, 816154, new DateTime(2020, 11, 24, 20, 2, 18, 788, DateTimeKind.Local).AddTicks(8043), "Labore error eius quod ea eaque consectetur.\nOmnis magni aut sed quisquam sit.\nQui quis nemo.\nOmnis rerum sit quisquam reiciendis doloribus vel in maiores laborum." },
                    { 358, 47, 10, 410763, new DateTime(2020, 9, 12, 0, 16, 42, 713, DateTimeKind.Local).AddTicks(8457), "Et voluptatum id totam. Labore necessitatibus necessitatibus aperiam aut iusto id et est id. Non qui aliquam aut perspiciatis eum. Ut eum quis in omnis non molestiae aut. Voluptatem quis nostrum in unde quasi sit qui." },
                    { 192, 47, 102, 859865, new DateTime(2021, 8, 25, 18, 28, 22, 227, DateTimeKind.Local).AddTicks(7235), "At aspernatur ab voluptatem quidem hic ut ea blanditiis totam. Animi voluptatem quo nostrum sapiente sint maiores eligendi nostrum. Consectetur vero ipsum dignissimos at." },
                    { 251, 11, 49, 182854, new DateTime(2020, 9, 16, 9, 49, 5, 106, DateTimeKind.Local).AddTicks(3956), "enim" },
                    { 25, 44, 52, 43130, new DateTime(2021, 3, 6, 14, 32, 24, 145, DateTimeKind.Local).AddTicks(3159), "Aperiam quis esse." },
                    { 90, 44, 40, 617494, new DateTime(2021, 6, 9, 3, 24, 31, 754, DateTimeKind.Local).AddTicks(7833), "Impedit voluptas distinctio totam." },
                    { 130, 44, 90, 691785, new DateTime(2021, 8, 7, 4, 25, 39, 980, DateTimeKind.Local).AddTicks(1824), "Quia ratione in et.\nQuia facilis quasi at.\nMaiores magnam facilis ex illum.\nEum cum nulla et ut ea eos reprehenderit.\nSed nihil reprehenderit iusto alias.\nEsse qui est tempora." },
                    { 163, 44, 33, 589077, new DateTime(2021, 5, 27, 20, 24, 51, 373, DateTimeKind.Local).AddTicks(1812), "Quia sit labore atque animi ipsum alias non et totam.\nNeque natus quam error assumenda aut ea." },
                    { 198, 44, 140, 933993, new DateTime(2021, 7, 30, 1, 57, 9, 972, DateTimeKind.Local).AddTicks(7181), "A aut quisquam sunt quia nihil nulla excepturi." },
                    { 234, 44, 144, 147543, new DateTime(2021, 3, 16, 15, 58, 48, 259, DateTimeKind.Local).AddTicks(2615), "fuga" },
                    { 277, 44, 105, 369477, new DateTime(2020, 11, 10, 0, 56, 54, 68, DateTimeKind.Local).AddTicks(8802), "Nesciunt sunt debitis ipsa qui.\nUt unde sit accusamus et aut porro.\nEt rerum eos omnis error ex.\nFuga et non doloremque et quis id saepe quos adipisci." },
                    { 293, 44, 59, 244911, new DateTime(2021, 5, 6, 5, 45, 41, 806, DateTimeKind.Local).AddTicks(8615), "quo" },
                    { 294, 44, 135, 475076, new DateTime(2020, 11, 2, 14, 38, 16, 713, DateTimeKind.Local).AddTicks(2549), "Molestias et sunt beatae nesciunt et sapiente neque. Sint libero quia enim ut quos animi molestias voluptates. Ex quia laborum sint rem aut aspernatur eum excepturi mollitia. Sint in quibusdam ipsa asperiores facilis assumenda perspiciatis et qui. Voluptate maxime distinctio hic. Dolorem commodi illum facilis tenetur atque." },
                    { 309, 44, 112, 75726, new DateTime(2021, 4, 22, 12, 41, 32, 234, DateTimeKind.Local).AddTicks(4965), "Iure laborum voluptates libero at sit ab." },
                    { 339, 44, 64, 720883, new DateTime(2021, 3, 12, 22, 34, 40, 217, DateTimeKind.Local).AddTicks(4075), "Autem suscipit aut repellat hic modi ipsa." },
                    { 344, 44, 6, 502355, new DateTime(2021, 8, 16, 21, 34, 17, 947, DateTimeKind.Local).AddTicks(2951), "quos" },
                    { 377, 44, 103, 863224, new DateTime(2021, 6, 15, 14, 59, 32, 155, DateTimeKind.Local).AddTicks(8959), "Qui at pariatur repudiandae deleniti." },
                    { 80, 11, 2, 808855, new DateTime(2020, 10, 22, 22, 59, 48, 879, DateTimeKind.Local).AddTicks(5236), "Expedita quis animi voluptate aliquam. Animi velit quia quaerat nulla illum saepe deleniti. Corrupti rerum est adipisci. Saepe aut ut omnis quas. Dolor velit qui enim cumque quam consectetur reiciendis. Et eum unde occaecati aut maiores et sunt quae velit." },
                    { 356, 11, 24, 865850, new DateTime(2021, 2, 13, 0, 36, 0, 669, DateTimeKind.Local).AddTicks(7851), "Eos voluptatem unde sed similique eius doloribus ratione ipsa. Consequatur neque commodi reiciendis voluptatibus eaque quaerat consequatur non. Aut voluptas repellendus nobis alias velit ab consequatur temporibus. Totam laudantium ipsam qui nulla sint error. Ut ut natus sed hic placeat aut error. Quam ex ab voluptatem sed voluptatem veritatis pariatur ullam." },
                    { 400, 11, 56, 518410, new DateTime(2020, 11, 11, 7, 45, 36, 477, DateTimeKind.Local).AddTicks(8778), "Non et est laborum quos beatae id omnis sed.\nNostrum maiores magnam.\nInventore soluta autem rerum velit sit deleniti deleniti.\nAd accusamus eveniet quo omnis omnis nemo." },
                    { 589, 25, 97, 47286, new DateTime(2021, 8, 12, 14, 45, 58, 80, DateTimeKind.Local).AddTicks(2552), "debitis" },
                    { 481, 25, 87, 115830, new DateTime(2021, 2, 4, 10, 17, 11, 832, DateTimeKind.Local).AddTicks(3598), "Architecto neque ipsa eligendi exercitationem quis.\nEt libero odio praesentium in in molestiae.\nEt ipsum modi." },
                    { 245, 52, 12, 581109, new DateTime(2020, 10, 31, 0, 39, 12, 121, DateTimeKind.Local).AddTicks(7166), "Est molestiae corporis repudiandae amet laudantium.\nA eligendi explicabo delectus itaque nulla exercitationem.\nAb veritatis et.\nOdit modi omnis.\nMolestiae enim vel dolorem laudantium.\nNemo error perspiciatis." },
                    { 497, 52, 21, 329160, new DateTime(2020, 12, 30, 11, 7, 20, 298, DateTimeKind.Local).AddTicks(6412), "Quis praesentium officia repellendus aut non ullam pariatur nemo." },
                    { 522, 52, 40, 817359, new DateTime(2021, 2, 27, 13, 7, 18, 291, DateTimeKind.Local).AddTicks(6706), "Beatae dolores qui eveniet." },
                    { 547, 52, 144, 51534, new DateTime(2021, 6, 22, 0, 1, 50, 729, DateTimeKind.Local).AddTicks(7786), "cum" },
                    { 359, 82, 95, 134477, new DateTime(2021, 8, 22, 1, 57, 16, 990, DateTimeKind.Local).AddTicks(4194), "Suscipit dolorum hic reprehenderit voluptas deserunt similique.\nNobis est veritatis vitae dolorum nam consequuntur.\nId eum porro nisi laboriosam.\nNeque et eos vel et." },
                    { 342, 82, 104, 978894, new DateTime(2021, 3, 9, 18, 21, 1, 929, DateTimeKind.Local).AddTicks(7016), "Qui atque amet sunt voluptates illo nihil doloribus repudiandae.\nQuia ea rem.\nCupiditate quibusdam aut tempore." },
                    { 340, 82, 59, 247514, new DateTime(2021, 2, 26, 10, 46, 20, 684, DateTimeKind.Local).AddTicks(6114), "Facere nam magni libero recusandae aut voluptas." },
                    { 35, 11, 103, 184968, new DateTime(2020, 11, 14, 18, 43, 57, 532, DateTimeKind.Local).AddTicks(5432), "Ut consequatur nesciunt error quis. Tempora assumenda sed tempore laborum distinctio modi. Inventore occaecati sit odit. Quia cum impedit sequi ea." },
                    { 58, 79, 104, 719553, new DateTime(2021, 6, 19, 17, 42, 1, 829, DateTimeKind.Local).AddTicks(4271), "Numquam omnis aperiam a a." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 216, 79, 82, 626798, new DateTime(2021, 2, 25, 19, 49, 40, 341, DateTimeKind.Local).AddTicks(84), "Molestiae est maxime sapiente et quisquam vel necessitatibus." },
                    { 424, 79, 11, 251249, new DateTime(2020, 12, 19, 18, 8, 2, 480, DateTimeKind.Local).AddTicks(1468), "Aspernatur repudiandae impedit.\nCulpa odio et molestiae placeat et omnis ratione.\nAutem tempora sed impedit ut est assumenda unde.\nEst voluptatem nulla.\nQui molestiae quibusdam.\nVitae id ea." },
                    { 486, 79, 27, 362511, new DateTime(2021, 6, 21, 18, 48, 25, 99, DateTimeKind.Local).AddTicks(6290), "Quia ea deserunt dolor officiis ex.\nNon est rerum quo consequatur aut.\nSed deleniti et error suscipit voluptatem." },
                    { 592, 11, 149, 361695, new DateTime(2020, 11, 15, 9, 43, 42, 416, DateTimeKind.Local).AddTicks(298), "et" },
                    { 12, 25, 17, 195636, new DateTime(2021, 1, 12, 12, 5, 29, 571, DateTimeKind.Local).AddTicks(5234), "Soluta quisquam eos voluptates." },
                    { 247, 25, 111, 115712, new DateTime(2021, 3, 27, 11, 22, 38, 153, DateTimeKind.Local).AddTicks(4010), "Sunt dolorum reiciendis cumque qui rerum blanditiis fuga rerum. Molestiae qui autem facilis. Exercitationem dicta hic iure non." },
                    { 422, 25, 66, 893695, new DateTime(2021, 6, 3, 7, 12, 0, 44, DateTimeKind.Local).AddTicks(7391), "Nostrum excepturi nihil laudantium. Numquam dolorem a minus soluta reiciendis eius accusamus. Qui numquam cupiditate. Suscipit neque accusamus quis vel amet nihil atque qui. Ipsam sed dignissimos ullam ut qui et et quas rerum." },
                    { 205, 79, 129, 215039, new DateTime(2021, 6, 29, 2, 11, 42, 18, DateTimeKind.Local).AddTicks(8619), "Doloribus iusto sit nulla aut quis." },
                    { 132, 90, 102, 80656, new DateTime(2021, 3, 7, 23, 0, 19, 96, DateTimeKind.Local).AddTicks(7266), "Porro quis sit labore.\nPlaceat aliquam quidem pariatur nesciunt similique libero repellat magni omnis.\nConsequatur beatae ea.\nEos rem quod qui non.\nIn sed autem animi saepe.\nLaborum blanditiis molestias assumenda excepturi modi et id magnam." },
                    { 77, 59, 140, 422978, new DateTime(2021, 3, 23, 7, 20, 21, 777, DateTimeKind.Local).AddTicks(318), "aut" },
                    { 204, 59, 116, 196224, new DateTime(2021, 8, 4, 13, 0, 23, 873, DateTimeKind.Local).AddTicks(4562), "Assumenda dolorem exercitationem. Quam voluptatem soluta ut sint. Eos veniam repellat quibusdam repudiandae unde nostrum praesentium." },
                    { 480, 51, 52, 435477, new DateTime(2021, 2, 4, 18, 9, 12, 418, DateTimeKind.Local).AddTicks(6329), "Ipsa sit ea totam rerum velit. Saepe alias suscipit earum. Quia enim dolorem dolorem earum ut ex vitae eum minus." },
                    { 528, 51, 90, 437504, new DateTime(2020, 12, 16, 3, 22, 18, 998, DateTimeKind.Local).AddTicks(4009), "Enim eveniet eum." },
                    { 556, 51, 17, 366887, new DateTime(2021, 3, 21, 0, 59, 0, 716, DateTimeKind.Local).AddTicks(73), "Officiis non ullam. Rem eum id nostrum est similique ipsum. Minus earum non optio optio possimus iure. Atque pariatur est dolorum. Quibusdam qui repellendus ut et sit." },
                    { 3, 92, 112, 501252, new DateTime(2020, 11, 1, 1, 45, 24, 393, DateTimeKind.Local).AddTicks(5143), "Assumenda quos qui." },
                    { 61, 92, 99, 196369, new DateTime(2021, 7, 8, 2, 19, 17, 184, DateTimeKind.Local).AddTicks(9177), "Suscipit eos enim omnis adipisci ut numquam. Qui consequatur molestias molestiae quasi ipsam. Beatae magni sequi molestiae dolore id est quia necessitatibus. Voluptatem dolores natus labore dignissimos voluptatem a voluptatem ullam. Odit et cupiditate labore voluptas eum quaerat sint qui." },
                    { 83, 92, 50, 436812, new DateTime(2021, 4, 29, 9, 39, 24, 274, DateTimeKind.Local).AddTicks(7033), "dolorum" },
                    { 199, 92, 135, 375322, new DateTime(2021, 6, 22, 21, 51, 43, 497, DateTimeKind.Local).AddTicks(5562), "Et dolores et est sequi vel.\nHic voluptatem dolore velit sunt asperiores unde reiciendis quia molestias.\nNemo ratione sunt ducimus corporis necessitatibus quod dolorum temporibus qui." },
                    { 308, 92, 78, 95608, new DateTime(2021, 1, 28, 8, 9, 26, 912, DateTimeKind.Local).AddTicks(7677), "Tempora et maxime eveniet distinctio aut numquam." },
                    { 394, 92, 60, 527564, new DateTime(2021, 6, 14, 20, 7, 40, 379, DateTimeKind.Local).AddTicks(2679), "Totam saepe dolores eaque doloremque consequatur provident. Corrupti officiis accusantium. Dignissimos iste velit quasi." },
                    { 440, 92, 73, 180514, new DateTime(2020, 11, 11, 5, 27, 3, 217, DateTimeKind.Local).AddTicks(3462), "Itaque possimus voluptates voluptas recusandae nihil ex dolorum porro." },
                    { 478, 92, 21, 731600, new DateTime(2021, 3, 28, 19, 45, 42, 197, DateTimeKind.Local).AddTicks(1332), "Dignissimos nobis necessitatibus.\nIncidunt error mollitia ullam earum repellendus minus." },
                    { 514, 92, 102, 134204, new DateTime(2021, 2, 7, 1, 35, 45, 892, DateTimeKind.Local).AddTicks(5670), "Quia ratione vero omnis assumenda." },
                    { 524, 92, 76, 897027, new DateTime(2021, 1, 29, 16, 43, 38, 364, DateTimeKind.Local).AddTicks(2678), "Ipsum libero eligendi vel et accusantium." },
                    { 435, 53, 53, 466854, new DateTime(2021, 6, 19, 17, 0, 38, 351, DateTimeKind.Local).AddTicks(461), "Doloremque modi aspernatur laborum voluptatem non. Voluptatum aut sunt eius cumque. Fuga enim quaerat omnis quia nobis voluptatum. Dolore omnis quia qui consequatur earum ipsum eos ut consequatur." },
                    { 161, 47, 121, 791422, new DateTime(2021, 4, 29, 13, 36, 34, 661, DateTimeKind.Local).AddTicks(3246), "Iusto enim ut nihil quibusdam et tempore consequuntur quae.\nTempora facere voluptates iure sit aut corporis voluptatem." },
                    { 388, 51, 38, 570264, new DateTime(2020, 10, 1, 10, 47, 16, 760, DateTimeKind.Local).AddTicks(3804), "Adipisci ea vitae dolores aliquam ut magni id. Consequuntur hic velit est eius ullam deserunt itaque est. Eveniet eum et modi sed adipisci aut sit." },
                    { 329, 51, 12, 848627, new DateTime(2020, 12, 4, 12, 50, 36, 742, DateTimeKind.Local).AddTicks(2725), "Id esse facilis consequatur voluptatibus est rerum sed natus.\nPossimus delectus quisquam quaerat.\nEx aperiam vitae blanditiis velit commodi id ipsam laudantium.\nVoluptate adipisci assumenda." },
                    { 311, 51, 67, 739462, new DateTime(2021, 1, 30, 19, 46, 47, 335, DateTimeKind.Local).AddTicks(9165), "Perferendis veniam modi voluptatem in asperiores molestiae omnis. Suscipit ut illo corrupti vel vel sit. Rerum quia velit vero molestiae eos ipsum maiores iure. Ut porro accusantium. Qui iure vero consequuntur cumque ex odio." },
                    { 41, 51, 42, 17779, new DateTime(2020, 10, 28, 17, 0, 34, 97, DateTimeKind.Local).AddTicks(9346), "Sequi omnis eius.\nEligendi ea corrupti quas et velit magni." },
                    { 215, 59, 76, 961020, new DateTime(2021, 5, 30, 2, 12, 42, 172, DateTimeKind.Local).AddTicks(6599), "voluptatem" },
                    { 221, 59, 126, 910319, new DateTime(2021, 5, 26, 18, 22, 30, 351, DateTimeKind.Local).AddTicks(9807), "Placeat perferendis est. Necessitatibus magnam commodi in dicta est ipsam odio saepe. Explicabo sed eos distinctio ut. Sed quis nulla quibusdam eligendi. Optio dolores aliquid rem aut necessitatibus nihil sed." },
                    { 246, 59, 61, 242016, new DateTime(2021, 2, 28, 5, 22, 20, 955, DateTimeKind.Local).AddTicks(9557), "aut" },
                    { 313, 59, 124, 343240, new DateTime(2021, 6, 14, 7, 55, 43, 765, DateTimeKind.Local).AddTicks(8950), "Natus quaerat rerum autem voluptas." },
                    { 325, 59, 72, 568329, new DateTime(2021, 7, 7, 7, 30, 15, 174, DateTimeKind.Local).AddTicks(9451), "Vel qui incidunt culpa error.\nEt harum nam." },
                    { 427, 59, 145, 225076, new DateTime(2020, 12, 3, 0, 0, 12, 808, DateTimeKind.Local).AddTicks(1279), "ea" },
                    { 551, 59, 106, 531508, new DateTime(2021, 8, 23, 20, 55, 48, 31, DateTimeKind.Local).AddTicks(7698), "Autem voluptas commodi.\nQuibusdam rerum itaque exercitationem beatae odio possimus vitae veniam voluptas.\nConsequatur architecto dolores est debitis tenetur ut.\nDeserunt expedita voluptas eos.\nSunt libero corrupti non.\nIncidunt eos hic libero." },
                    { 101, 59, 95, 393297, new DateTime(2020, 10, 19, 7, 22, 11, 216, DateTimeKind.Local).AddTicks(1568), "sit" },
                    { 548, 65, 81, 418508, new DateTime(2021, 7, 21, 1, 11, 32, 965, DateTimeKind.Local).AddTicks(4799), "beatae" },
                    { 271, 73, 135, 199962, new DateTime(2020, 11, 3, 16, 28, 20, 822, DateTimeKind.Local).AddTicks(2725), "numquam" },
                    { 473, 73, 61, 687019, new DateTime(2020, 12, 19, 5, 14, 19, 946, DateTimeKind.Local).AddTicks(1706), "Error alias dolore placeat quam in deserunt totam porro ratione. Nemo sint praesentium non quia nemo consectetur eos et error. Et adipisci beatae dolorem ut dolor voluptatem. Iure aut fuga ad rerum ducimus sit tempore. Nisi assumenda et perspiciatis voluptatem repellat cum." },
                    { 534, 73, 145, 718419, new DateTime(2021, 3, 26, 17, 57, 11, 277, DateTimeKind.Local).AddTicks(8941), "Illum eaque qui." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 552, 73, 31, 749310, new DateTime(2021, 3, 9, 8, 4, 5, 510, DateTimeKind.Local).AddTicks(1935), "Non corrupti nisi labore ratione molestias.\nSuscipit non aspernatur ratione doloremque omnis assumenda ipsam." },
                    { 512, 65, 75, 934481, new DateTime(2021, 2, 23, 18, 51, 48, 771, DateTimeKind.Local).AddTicks(3674), "Magni sunt velit tenetur ut et id et enim facilis.\nAperiam quia molestias voluptatem excepturi.\nIn voluptatem accusantium." },
                    { 446, 65, 23, 789261, new DateTime(2021, 8, 12, 23, 2, 1, 488, DateTimeKind.Local).AddTicks(9812), "Architecto sed officiis quam quia dignissimos laborum qui.\nEt et et corrupti dignissimos." },
                    { 276, 65, 67, 802453, new DateTime(2021, 1, 18, 1, 51, 45, 776, DateTimeKind.Local).AddTicks(2843), "Esse debitis voluptatem sequi iste dolore consequatur quas enim asperiores. Nemo facilis eligendi veniam id iure quidem. Est at ut quo minus et non optio. Quidem totam rerum dolorem. Omnis placeat nihil sit dolorem minima eligendi ratione temporibus. Consequatur recusandae dolore." },
                    { 165, 73, 80, 832881, new DateTime(2021, 6, 12, 17, 42, 55, 517, DateTimeKind.Local).AddTicks(1448), "Odit eligendi ipsum maxime occaecati dolores reiciendis nihil." },
                    { 160, 90, 34, 357910, new DateTime(2020, 12, 22, 10, 27, 44, 871, DateTimeKind.Local).AddTicks(519), "Nam molestiae quos aut non omnis quisquam aperiam deleniti." },
                    { 125, 91, 3, 141791, new DateTime(2020, 11, 23, 7, 51, 20, 895, DateTimeKind.Local).AddTicks(2185), "Laboriosam impedit velit ea est fugiat earum error. Rerum dignissimos vel quia delectus. Deserunt quasi doloremque est non. Ut qui recusandae ut nihil non enim aut expedita. Rem voluptatem quisquam praesentium ad dignissimos debitis." },
                    { 256, 90, 6, 816211, new DateTime(2021, 5, 2, 9, 47, 2, 518, DateTimeKind.Local).AddTicks(7038), "Eum ut a officia saepe vitae.\nEt nostrum ut.\nSoluta qui soluta necessitatibus accusantium aspernatur iure provident.\nMolestias nobis nam assumenda nam vel repellat.\nIpsa magnam corporis voluptatem quod aut quia explicabo iure.\nRecusandae sit et accusantium voluptatem placeat ex eligendi exercitationem." },
                    { 30, 43, 124, 383009, new DateTime(2021, 6, 15, 21, 12, 9, 61, DateTimeKind.Local).AddTicks(1374), "Quo dolor id dolor possimus.\nSed delectus sit tempora nostrum et dolores sed a.\nEt id libero reprehenderit iure.\nMaiores ipsum eum deleniti ea soluta sunt occaecati quasi.\nNatus id officiis sit voluptas aut mollitia provident non." },
                    { 112, 43, 150, 996365, new DateTime(2021, 5, 21, 6, 11, 49, 956, DateTimeKind.Local).AddTicks(6581), "eaque" },
                    { 193, 43, 62, 815499, new DateTime(2021, 3, 14, 17, 36, 12, 216, DateTimeKind.Local).AddTicks(4899), "Qui vel quia ut beatae nemo labore voluptatum.\nOmnis quis ipsum repellat placeat dignissimos rerum veritatis molestias.\nAmet voluptas cumque nam labore aut impedit.\nEarum corrupti eveniet assumenda et aut debitis et suscipit.\nQui iusto soluta." },
                    { 332, 43, 130, 6807, new DateTime(2021, 8, 10, 22, 24, 2, 2, DateTimeKind.Local).AddTicks(9685), "Minus autem dolorem incidunt omnis magni." },
                    { 423, 50, 36, 641953, new DateTime(2020, 10, 27, 14, 24, 42, 281, DateTimeKind.Local).AddTicks(2571), "Ad id ut voluptas omnis quos.\nNon culpa enim sint.\nLabore eaque neque quasi." },
                    { 385, 50, 28, 133703, new DateTime(2020, 10, 13, 12, 11, 39, 445, DateTimeKind.Local).AddTicks(2165), "Quo est quia aut cumque impedit.\nIncidunt veniam magni vero maxime quis alias tempora dolorem aut.\nRem soluta doloremque non omnis velit numquam.\nMaiores hic labore ut qui." },
                    { 188, 50, 106, 96512, new DateTime(2021, 6, 30, 4, 44, 37, 737, DateTimeKind.Local).AddTicks(8195), "et" },
                    { 141, 50, 38, 980209, new DateTime(2021, 6, 15, 17, 57, 51, 182, DateTimeKind.Local).AddTicks(2717), "Dolore harum et sunt et assumenda quis. Qui quos voluptatem magnam ut. Maxime voluptatum aliquid eveniet similique quaerat voluptatem maiores eos earum. Inventore dolore vero voluptates. Sed sapiente ut ut quia ea impedit. Eos sunt qui totam assumenda sapiente quasi aliquam." },
                    { 563, 31, 32, 639488, new DateTime(2021, 2, 11, 4, 23, 42, 814, DateTimeKind.Local).AddTicks(4956), "Sit ut quidem." },
                    { 542, 31, 76, 638724, new DateTime(2021, 8, 12, 19, 29, 27, 838, DateTimeKind.Local).AddTicks(9022), "distinctio" },
                    { 7, 66, 47, 690960, new DateTime(2021, 8, 25, 21, 3, 14, 173, DateTimeKind.Local).AddTicks(7629), "Quia at non voluptates eos velit id aut." },
                    { 26, 66, 143, 866591, new DateTime(2021, 1, 9, 13, 31, 45, 885, DateTimeKind.Local).AddTicks(3119), "mollitia" },
                    { 492, 66, 108, 698774, new DateTime(2020, 12, 8, 11, 55, 50, 54, DateTimeKind.Local).AddTicks(5773), "Mollitia autem doloribus similique odit voluptates deserunt consequatur.\nAmet natus omnis libero.\nAutem et et voluptatem maiores sit atque nemo nisi et." },
                    { 550, 66, 70, 514104, new DateTime(2020, 12, 25, 1, 7, 5, 358, DateTimeKind.Local).AddTicks(2931), "Quo et velit facere deserunt assumenda eveniet ducimus in.\nAliquam laborum similique labore.\nIllo laudantium quia.\nFacere odio quasi natus tempora tenetur nihil.\nId quis a totam ipsum sit labore quo aperiam.\nVoluptas excepturi est quibusdam sunt vero delectus similique fuga similique." },
                    { 572, 66, 88, 399143, new DateTime(2020, 12, 27, 4, 51, 44, 3, DateTimeKind.Local).AddTicks(7704), "Vero consequatur mollitia quia unde." },
                    { 23, 43, 18, 333360, new DateTime(2020, 12, 31, 10, 47, 29, 23, DateTimeKind.Local).AddTicks(3485), "rerum" },
                    { 413, 31, 106, 995302, new DateTime(2021, 2, 19, 4, 6, 17, 398, DateTimeKind.Local).AddTicks(4094), "qui" },
                    { 20, 61, 41, 118673, new DateTime(2021, 5, 13, 22, 41, 8, 219, DateTimeKind.Local).AddTicks(9204), "Error at corrupti sapiente aut est dolor deleniti quia velit. Alias nemo id soluta a impedit. Ut illo sunt debitis. Expedita possimus ducimus ducimus velit quibusdam aspernatur excepturi." },
                    { 364, 69, 48, 743983, new DateTime(2020, 11, 26, 17, 16, 2, 841, DateTimeKind.Local).AddTicks(3611), "Aut possimus in omnis aperiam quaerat quaerat maxime illo nesciunt. Reprehenderit et excepturi distinctio laboriosam. Iste nesciunt hic. Error dicta sed optio ad non hic ut id. Delectus est consectetur doloremque et delectus temporibus. In non dolor aut repudiandae voluptas quia non laboriosam." },
                    { 287, 13, 107, 37743, new DateTime(2021, 5, 7, 4, 31, 43, 4, DateTimeKind.Local).AddTicks(3837), "Dolores quidem est.\nAut officia illo.\nQuibusdam assumenda quod assumenda.\nSoluta eius facere magni id ratione corrupti unde." },
                    { 321, 13, 31, 899104, new DateTime(2021, 6, 15, 4, 42, 35, 672, DateTimeKind.Local).AddTicks(3668), "Velit non eos corporis optio in vitae unde laudantium. Ea corporis dolores et. Cum et quia sit. Velit rerum perferendis animi qui sed numquam blanditiis quas maxime. Ad aut commodi. Est eveniet sunt asperiores aperiam at autem ea deserunt pariatur." },
                    { 465, 13, 40, 85040, new DateTime(2021, 6, 12, 21, 20, 10, 100, DateTimeKind.Local).AddTicks(9446), "Et et repellendus fugiat cumque et rerum ad eum.\nNulla dolor nam doloribus officia fugiat.\nOmnis quam beatae non dicta ut." },
                    { 468, 13, 38, 619446, new DateTime(2020, 9, 16, 18, 28, 48, 659, DateTimeKind.Local).AddTicks(72), "Accusantium ipsa optio molestiae dignissimos rem in exercitationem ut." },
                    { 538, 13, 138, 788204, new DateTime(2020, 10, 17, 3, 21, 20, 705, DateTimeKind.Local).AddTicks(6040), "error" },
                    { 546, 13, 134, 159198, new DateTime(2020, 11, 29, 23, 3, 37, 741, DateTimeKind.Local).AddTicks(7975), "quo" },
                    { 59, 61, 19, 457913, new DateTime(2021, 5, 29, 9, 11, 16, 558, DateTimeKind.Local).AddTicks(4069), "Ut aut asperiores.\nVero rerum corrupti doloremque aut esse.\nEaque nostrum eum at culpa sed recusandae.\nRem temporibus molestias et doloribus.\nNon officiis quia dolore non quis et aut quae est." },
                    { 209, 90, 118, 620722, new DateTime(2021, 7, 25, 8, 58, 0, 378, DateTimeKind.Local).AddTicks(8817), "Aut iure aut id numquam at facilis." },
                    { 49, 29, 28, 120099, new DateTime(2020, 10, 8, 11, 38, 7, 658, DateTimeKind.Local).AddTicks(4645), "Delectus mollitia vel. Odit voluptas voluptatum dolorem corporis. Natus fugiat tempora." },
                    { 123, 29, 84, 237133, new DateTime(2021, 5, 17, 9, 19, 50, 508, DateTimeKind.Local).AddTicks(4847), "Quo ad sequi tempore praesentium. Ut quia quod. Dolores est perferendis est doloremque odit. Ipsa enim totam quod. Commodi sunt ea quo saepe nihil et assumenda." },
                    { 436, 29, 92, 181659, new DateTime(2020, 9, 2, 5, 32, 49, 387, DateTimeKind.Local).AddTicks(1986), "Ut eos maxime suscipit vel sit sunt ipsa illum." },
                    { 438, 29, 25, 907844, new DateTime(2020, 9, 4, 5, 41, 12, 341, DateTimeKind.Local).AddTicks(7066), "Incidunt laudantium beatae voluptas eum omnis et. Quidem delectus quia totam quasi similique rerum. Molestias et possimus sequi ipsa dignissimos commodi aut qui." },
                    { 482, 29, 94, 50160, new DateTime(2021, 8, 23, 20, 50, 44, 827, DateTimeKind.Local).AddTicks(3661), "perspiciatis" },
                    { 46, 61, 122, 573968, new DateTime(2021, 7, 9, 22, 44, 32, 461, DateTimeKind.Local).AddTicks(5291), "Dolores qui dolorem qui voluptas ex at velit sapiente ut." },
                    { 37, 61, 149, 30631, new DateTime(2021, 2, 10, 20, 48, 10, 12, DateTimeKind.Local).AddTicks(1511), "Omnis in et id dicta et et incidunt sit. Deleniti ut sed dolorem eius unde ut. Quidem numquam possimus dolor amet molestiae perspiciatis. Soluta consequatur architecto nihil dolor ea quia qui. Nihil nihil porro deserunt beatae dicta. Qui rerum fuga quam." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 419, 69, 108, 381124, new DateTime(2021, 8, 27, 8, 29, 33, 964, DateTimeKind.Local).AddTicks(1031), "necessitatibus" },
                    { 301, 31, 64, 656294, new DateTime(2020, 10, 30, 15, 22, 4, 736, DateTimeKind.Local).AddTicks(2242), "Id voluptas et qui. Atque earum molestias voluptatibus mollitia eaque animi explicabo ipsa. Repellendus et distinctio porro asperiores aut atque. Consectetur necessitatibus consequuntur ea nostrum. Eaque quod voluptatem esse iusto." },
                    { 254, 31, 52, 154957, new DateTime(2021, 4, 21, 12, 56, 44, 968, DateTimeKind.Local).AddTicks(3627), "Rem dolorum et fugiat tenetur repellat id. Deserunt vitae cupiditate a tempore et ut eum. Quo eius quis iusto eius rerum ad blanditiis quia omnis. Eaque optio repellat atque aperiam eum iste eligendi nihil." },
                    { 27, 70, 64, 812737, new DateTime(2021, 6, 11, 21, 50, 9, 823, DateTimeKind.Local).AddTicks(928), "Placeat quia sunt optio ut vitae repudiandae qui." },
                    { 135, 31, 47, 193734, new DateTime(2021, 1, 27, 3, 0, 33, 84, DateTimeKind.Local).AddTicks(3899), "Quas ratione ducimus fuga aut iure reprehenderit dolor praesentium fugiat.\nEos est voluptas error qui.\nConsequatur magni voluptatem modi rem adipisci.\nError sed non eum optio accusamus quia vel sunt occaecati.\nNecessitatibus porro tempore et itaque pariatur voluptas." },
                    { 107, 31, 54, 84467, new DateTime(2021, 1, 18, 20, 41, 37, 322, DateTimeKind.Local).AddTicks(9684), "Vel omnis necessitatibus quisquam delectus vel animi et recusandae." },
                    { 230, 54, 49, 845790, new DateTime(2021, 6, 22, 13, 46, 41, 33, DateTimeKind.Local).AddTicks(4112), "Saepe aut vero corporis et asperiores fugit consequatur eos ipsa. Deleniti nulla corporis et fuga laboriosam sit dignissimos. Perspiciatis optio ut sint earum dolores excepturi odit. Natus exercitationem fugiat sed ut. Quia est error aperiam rerum et eaque. Aut et reprehenderit facilis sit sit." },
                    { 333, 54, 130, 575549, new DateTime(2020, 8, 30, 23, 2, 3, 907, DateTimeKind.Local).AddTicks(7178), "sit" },
                    { 371, 54, 51, 544351, new DateTime(2020, 12, 29, 18, 28, 56, 139, DateTimeKind.Local).AddTicks(6148), "Dignissimos sit tempore.\nSunt dicta amet velit.\nNisi pariatur illo odio accusantium velit aliquam voluptatum." },
                    { 517, 54, 76, 169927, new DateTime(2021, 7, 28, 6, 18, 16, 400, DateTimeKind.Local).AddTicks(2707), "ea" },
                    { 585, 54, 126, 493732, new DateTime(2020, 12, 18, 10, 42, 15, 989, DateTimeKind.Local).AddTicks(8601), "optio" },
                    { 73, 31, 47, 254466, new DateTime(2020, 12, 29, 21, 17, 11, 49, DateTimeKind.Local).AddTicks(3280), "Dolorum non vero quisquam temporibus enim ut. Asperiores ea omnis. Iste assumenda voluptatibus." },
                    { 54, 67, 41, 624463, new DateTime(2020, 12, 5, 10, 16, 14, 73, DateTimeKind.Local).AddTicks(2609), "Pariatur quasi dolorum et adipisci." },
                    { 120, 67, 46, 190785, new DateTime(2021, 8, 4, 16, 14, 20, 825, DateTimeKind.Local).AddTicks(2463), "Quia in quis illo ipsam cumque molestias.\nCulpa rem iusto.\nEa iure consectetur qui eos dignissimos omnis voluptatem sunt corrupti.\nAut voluptatem dolores voluptas commodi praesentium minus voluptas impedit.\nSit placeat et harum fugiat quos nulla aut vel.\nQuisquam dolores et et." },
                    { 121, 67, 79, 459193, new DateTime(2020, 10, 28, 0, 1, 59, 669, DateTimeKind.Local).AddTicks(5333), "sit" },
                    { 219, 67, 75, 815312, new DateTime(2020, 10, 4, 11, 42, 2, 950, DateTimeKind.Local).AddTicks(2774), "Iste vel quos. Et omnis suscipit voluptatibus aliquid. Laudantium et iure ut et iusto ea et delectus dolores. Enim perferendis consequatur quos. Repellat cumque officiis id." },
                    { 239, 67, 16, 683067, new DateTime(2021, 7, 21, 5, 45, 50, 823, DateTimeKind.Local).AddTicks(5609), "Excepturi eum officiis numquam dolor praesentium.\nModi soluta ut sunt sed amet aut minus.\nAspernatur ratione in." },
                    { 314, 67, 28, 833649, new DateTime(2021, 1, 29, 23, 1, 41, 470, DateTimeKind.Local).AddTicks(7979), "Aperiam iste corporis.\nIste vel occaecati est fugit.\nIpsa quis sapiente quae sit quo doloremque quidem corporis.\nEa voluptas culpa quibusdam modi eius nesciunt qui quos.\nReiciendis non qui unde eius quia ea sunt excepturi dolorum.\nAut dolores temporibus numquam." },
                    { 316, 67, 27, 662069, new DateTime(2021, 1, 25, 16, 29, 46, 645, DateTimeKind.Local).AddTicks(7952), "Non nihil necessitatibus nostrum ad distinctio. Cum deleniti dolorem. Dolor et ea tenetur non veritatis. Et aut reiciendis illo culpa. Quod et eveniet hic quo modi et possimus quibusdam. Porro sapiente omnis nisi." },
                    { 139, 31, 76, 455006, new DateTime(2020, 9, 28, 15, 26, 36, 185, DateTimeKind.Local).AddTicks(7782), "Et consequuntur omnis. Ipsam ad quo sequi consequuntur dolores quidem recusandae id placeat. Odio quis doloribus quia vel odit eos accusamus possimus." },
                    { 566, 62, 109, 731859, new DateTime(2020, 10, 15, 20, 43, 45, 957, DateTimeKind.Local).AddTicks(4615), "Non quibusdam est. Voluptatem nam et ad. Dignissimos praesentium est temporibus." },
                    { 442, 62, 85, 544696, new DateTime(2020, 9, 13, 18, 57, 39, 40, DateTimeKind.Local).AddTicks(2134), "sed" },
                    { 416, 62, 46, 483061, new DateTime(2020, 10, 29, 21, 35, 28, 727, DateTimeKind.Local).AddTicks(4086), "Laboriosam ab vel aut odit enim illum quibusdam. Veritatis incidunt id qui velit qui unde quasi. Nemo ut qui non aperiam corrupti aspernatur. Provident aspernatur qui odio aut sed laudantium vitae. Tempora nemo non qui et." },
                    { 47, 70, 47, 429501, new DateTime(2021, 3, 23, 18, 47, 1, 74, DateTimeKind.Local).AddTicks(3751), "ducimus" },
                    { 398, 70, 134, 25202, new DateTime(2021, 6, 9, 16, 31, 51, 168, DateTimeKind.Local).AddTicks(9911), "Voluptatem sequi est.\nFugiat alias veritatis quam doloremque.\nNam quae quaerat natus ipsum." },
                    { 425, 70, 9, 39555, new DateTime(2020, 9, 1, 21, 52, 53, 480, DateTimeKind.Local).AddTicks(7521), "Cum voluptas ipsum. Laudantium necessitatibus esse. Id aut qui delectus ut. Et explicabo eos. Autem molestias et voluptatum et distinctio." },
                    { 545, 70, 8, 328906, new DateTime(2020, 9, 3, 18, 18, 10, 856, DateTimeKind.Local).AddTicks(5671), "Accusantium provident molestiae possimus quia perspiciatis.\nFacere aperiam facere cumque omnis asperiores rem.\nQui ullam autem dolorem tempore magnam rerum molestiae molestias inventore.\nQuis ex non quibusdam et temporibus repellat.\nUt modi rerum ducimus." },
                    { 593, 70, 142, 342559, new DateTime(2020, 10, 14, 2, 0, 44, 795, DateTimeKind.Local).AddTicks(1945), "Occaecati iusto nam asperiores quos fugit. Et consequuntur ducimus et eveniet sit ea alias delectus. Modi sunt voluptatem reiciendis doloribus." },
                    { 370, 9, 53, 890568, new DateTime(2021, 3, 24, 14, 4, 56, 393, DateTimeKind.Local).AddTicks(741), "Et sint quia rerum." },
                    { 588, 9, 124, 23391, new DateTime(2021, 4, 9, 2, 17, 16, 231, DateTimeKind.Local).AddTicks(7518), "Est eligendi et recusandae animi qui sit et aut.\nDolores natus consequatur illum earum cum voluptatem.\nRerum sed laborum exercitationem voluptatum voluptates sed.\nCorporis dolore qui non enim praesentium nostrum quidem explicabo.\nQuasi assumenda aliquid minus rerum adipisci aut." },
                    { 255, 13, 38, 992941, new DateTime(2020, 12, 12, 5, 12, 2, 487, DateTimeKind.Local).AddTicks(5342), "Esse expedita rerum odio aspernatur consequatur autem aut alias." },
                    { 596, 9, 83, 740497, new DateTime(2021, 7, 23, 6, 52, 25, 195, DateTimeKind.Local).AddTicks(6529), "Eaque ab eum voluptatem.\nQuos assumenda voluptas beatae iusto qui." },
                    { 181, 31, 81, 68748, new DateTime(2021, 7, 24, 5, 15, 52, 463, DateTimeKind.Local).AddTicks(4727), "Deleniti labore nesciunt." },
                    { 179, 31, 131, 984236, new DateTime(2020, 10, 19, 23, 3, 13, 511, DateTimeKind.Local).AddTicks(2506), "Sequi doloremque rerum et blanditiis in sapiente in a.\nCorrupti et minima perspiciatis." },
                    { 4, 62, 12, 36047, new DateTime(2021, 4, 3, 6, 7, 33, 411, DateTimeKind.Local).AddTicks(7805), "In recusandae aut qui sequi aut incidunt fuga debitis." },
                    { 114, 62, 136, 822238, new DateTime(2021, 4, 12, 2, 45, 42, 930, DateTimeKind.Local).AddTicks(9576), "Dolorum suscipit at eum voluptatum.\nUnde nemo earum vitae.\nEnim harum officiis consequatur.\nQuia assumenda quas officiis rem praesentium ut non temporibus.\nAut enim vel adipisci aut id dolores quod et ducimus.\nIllo dolor nostrum totam minus voluptas repudiandae sit est." },
                    { 156, 62, 87, 848144, new DateTime(2021, 6, 11, 12, 53, 55, 942, DateTimeKind.Local).AddTicks(6181), "Nam enim ut enim asperiores." },
                    { 248, 62, 50, 934433, new DateTime(2021, 1, 10, 13, 2, 21, 682, DateTimeKind.Local).AddTicks(1022), "Itaque repellendus voluptatum. Aut fugit veritatis optio consectetur consectetur omnis et nihil. Et itaque ea." },
                    { 272, 62, 81, 565743, new DateTime(2020, 10, 11, 10, 1, 16, 100, DateTimeKind.Local).AddTicks(9831), "Tenetur voluptatem delectus deleniti fugiat enim est soluta quo. Sed aut eos enim enim facilis non facere ut. Animi eos neque cumque et quasi deserunt." },
                    { 195, 31, 33, 803870, new DateTime(2021, 7, 3, 1, 57, 47, 195, DateTimeKind.Local).AddTicks(1360), "Ipsum dolorum fugit autem veritatis nesciunt nesciunt dolorem perspiciatis voluptate." },
                    { 225, 13, 140, 960999, new DateTime(2021, 5, 21, 12, 5, 22, 577, DateTimeKind.Local).AddTicks(8027), "Qui ut deleniti cum est ut fuga.\nQuas magnam ipsam reprehenderit voluptatem voluptatem possimus eveniet.\nAutem autem perspiciatis adipisci rerum.\nPariatur dolor est aspernatur rerum natus et quaerat." },
                    { 53, 61, 13, 205916, new DateTime(2021, 8, 19, 19, 21, 30, 610, DateTimeKind.Local).AddTicks(7963), "Nulla distinctio dignissimos laudantium est sequi ratione repudiandae tempore ad.\nUt quia mollitia commodi quia facere et maiores est.\nAliquam et et ea sed quas nesciunt ex.\nQuas voluptatum quo inventore maiores veniam ea qui ipsum est." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 149, 13, 104, 78772, new DateTime(2021, 3, 26, 23, 24, 41, 938, DateTimeKind.Local).AddTicks(3392), "Labore et eveniet autem repudiandae ex consequatur veritatis et." },
                    { 510, 21, 122, 791766, new DateTime(2021, 3, 17, 14, 2, 23, 742, DateTimeKind.Local).AddTicks(6502), "recusandae" },
                    { 469, 18, 83, 58958, new DateTime(2020, 10, 25, 21, 20, 2, 89, DateTimeKind.Local).AddTicks(6290), "Velit ut sit rerum qui dignissimos molestias.\nUt aut minima eius hic modi odit natus hic optio.\nNisi voluptatem laborum qui quia et et ea eum distinctio.\nQuasi nihil velit.\nQuis quas quisquam laborum eius qui.\nFacere accusantium et adipisci ea ut aut." },
                    { 373, 18, 124, 714962, new DateTime(2020, 11, 10, 23, 20, 19, 158, DateTimeKind.Local).AddTicks(8113), "Neque non et facilis enim.\nNihil dicta et sapiente.\nMolestiae porro qui dolor eos aut.\nPerferendis quidem et eligendi magni quidem possimus ad accusantium.\nFugit vitae numquam sint sint quis dolor voluptatem vel." },
                    { 2, 15, 38, 60371, new DateTime(2021, 5, 9, 16, 31, 55, 362, DateTimeKind.Local).AddTicks(3853), "Vel numquam consequatur voluptatem sit." },
                    { 106, 15, 93, 213601, new DateTime(2020, 10, 2, 5, 49, 53, 912, DateTimeKind.Local).AddTicks(1104), "Qui est blanditiis voluptatem quae laboriosam consectetur aut aut. Sunt nisi rem quisquam et. Dolore molestias corporis dolore ut aut." },
                    { 166, 15, 63, 178412, new DateTime(2020, 11, 11, 13, 6, 53, 904, DateTimeKind.Local).AddTicks(9595), "Quis rerum cumque esse perspiciatis consequatur. Quis ut esse et ad et et quo autem. Qui omnis commodi et doloribus vel eveniet molestiae." },
                    { 437, 21, 6, 450305, new DateTime(2020, 8, 28, 13, 4, 23, 873, DateTimeKind.Local).AddTicks(9429), "Repellat dolores repellendus.\nReiciendis doloremque saepe maiores dolor laboriosam sunt est.\nUt consequatur ad." },
                    { 568, 15, 66, 330368, new DateTime(2021, 8, 2, 9, 39, 12, 566, DateTimeKind.Local).AddTicks(9545), "Culpa maxime rerum occaecati cupiditate tempora vel repellendus nihil quis." },
                    { 360, 18, 13, 275772, new DateTime(2021, 7, 20, 10, 54, 7, 772, DateTimeKind.Local).AddTicks(1452), "Labore qui in aperiam non consequuntur eligendi optio est. Atque maiores impedit nesciunt eum ab saepe ut sapiente. Velit reiciendis blanditiis doloremque. Tenetur nesciunt iste blanditiis aut eos quia. Temporibus nihil voluptatibus dolor sunt. Deserunt est rerum facere commodi odio debitis." },
                    { 310, 18, 52, 390727, new DateTime(2021, 7, 31, 0, 6, 5, 705, DateTimeKind.Local).AddTicks(2524), "Aut enim ipsa quos. Voluptatibus culpa officia ut. Totam asperiores quaerat repudiandae dolor sunt beatae nobis." },
                    { 171, 13, 148, 666206, new DateTime(2021, 7, 18, 23, 2, 59, 269, DateTimeKind.Local).AddTicks(8265), "Nulla optio illum." },
                    { 79, 18, 25, 269162, new DateTime(2021, 6, 6, 17, 21, 54, 433, DateTimeKind.Local).AddTicks(6667), "Omnis nulla officia minima ullam corporis quaerat nam nihil officia." },
                    { 42, 28, 85, 427327, new DateTime(2020, 10, 26, 12, 23, 51, 580, DateTimeKind.Local).AddTicks(8409), "Est eos qui perferendis eum et excepturi qui.\nTempore in earum et ullam aspernatur quasi facere.\nVero quos fugit sit voluptatem laboriosam animi." },
                    { 145, 28, 52, 596340, new DateTime(2021, 7, 22, 6, 7, 55, 654, DateTimeKind.Local).AddTicks(6198), "Illo ea consequatur itaque quia." },
                    { 595, 15, 129, 56520, new DateTime(2021, 7, 11, 15, 31, 44, 779, DateTimeKind.Local).AddTicks(1661), "Dolore et asperiores porro.\nMaxime culpa et." },
                    { 200, 28, 148, 330443, new DateTime(2020, 9, 15, 0, 49, 46, 292, DateTimeKind.Local).AddTicks(476), "sint" },
                    { 201, 21, 31, 962114, new DateTime(2020, 9, 12, 7, 5, 32, 985, DateTimeKind.Local).AddTicks(9495), "Illo veritatis ea quia quo et pariatur sapiente aspernatur vel." },
                    { 84, 21, 5, 242839, new DateTime(2020, 11, 5, 19, 5, 27, 229, DateTimeKind.Local).AddTicks(5287), "Quos temporibus et eum exercitationem porro dicta ea. Odio debitis facere quaerat sed. Et animi consequatur nesciunt odio maiores dolores." },
                    { 291, 90, 127, 751913, new DateTime(2020, 10, 17, 22, 31, 44, 300, DateTimeKind.Local).AddTicks(6938), "Ipsa repellendus alias ut nihil." },
                    { 306, 90, 128, 456860, new DateTime(2020, 12, 9, 16, 56, 32, 321, DateTimeKind.Local).AddTicks(5671), "Dignissimos molestias cum quos reprehenderit cumque nemo possimus id illo." },
                    { 5, 10, 80, 667408, new DateTime(2021, 3, 14, 2, 53, 56, 500, DateTimeKind.Local).AddTicks(9725), "Necessitatibus deserunt at omnis impedit voluptas qui et ea esse." },
                    { 226, 77, 93, 987701, new DateTime(2021, 3, 15, 23, 7, 28, 156, DateTimeKind.Local).AddTicks(9253), "Velit mollitia officiis." },
                    { 253, 77, 126, 758916, new DateTime(2021, 4, 20, 7, 18, 59, 917, DateTimeKind.Local).AddTicks(5909), "alias" },
                    { 503, 26, 115, 794693, new DateTime(2021, 6, 10, 7, 4, 12, 592, DateTimeKind.Local).AddTicks(1381), "Eum cumque ducimus." },
                    { 136, 21, 142, 539435, new DateTime(2021, 1, 29, 13, 9, 52, 277, DateTimeKind.Local).AddTicks(6661), "Sed ex quae velit ea assumenda doloremque hic.\nInventore asperiores dolor error dicta officia molestias.\nAssumenda sunt dolor cum aut dolor molestias consectetur esse blanditiis.\nAlias et aliquam deserunt minima qui nesciunt excepturi minima ut.\nPlaceat excepturi itaque non et molestias omnis quis.\nDoloribus nobis nisi ut iusto voluptatem aut cupiditate." },
                    { 19, 81, 141, 420951, new DateTime(2021, 1, 20, 7, 27, 34, 813, DateTimeKind.Local).AddTicks(5279), "Sint officiis corporis odio reiciendis." },
                    { 105, 81, 17, 721544, new DateTime(2021, 5, 7, 15, 50, 46, 985, DateTimeKind.Local).AddTicks(9524), "Dolores nam unde ut aliquam dolorum repudiandae quo dolores ut." },
                    { 460, 81, 103, 918204, new DateTime(2020, 12, 3, 15, 50, 23, 149, DateTimeKind.Local).AddTicks(9042), "In libero officiis ut minus.\nEos voluptate nulla.\nDolore inventore sint." },
                    { 279, 26, 37, 492669, new DateTime(2021, 6, 19, 4, 37, 57, 824, DateTimeKind.Local).AddTicks(1099), "Non eaque dolorem distinctio cupiditate consequatur vel sed." },
                    { 138, 26, 110, 338022, new DateTime(2021, 8, 14, 1, 38, 10, 340, DateTimeKind.Local).AddTicks(4703), "aut" },
                    { 29, 26, 126, 598637, new DateTime(2021, 5, 11, 6, 2, 37, 318, DateTimeKind.Local).AddTicks(4556), "Ipsa voluptas accusantium illum asperiores quo dolor expedita consequatur.\nEt omnis aliquid dolorem.\nNisi et a eaque quia.\nQuia nam nostrum aperiam ut aut reiciendis.\nTemporibus voluptates laboriosam nisi at impedit commodi veritatis.\nEx consequatur minus dolorem in cum quia est possimus cupiditate." },
                    { 33, 21, 144, 167534, new DateTime(2021, 4, 24, 15, 27, 2, 325, DateTimeKind.Local).AddTicks(3264), "Voluptatum cupiditate debitis et nesciunt.\nOfficiis saepe et est hic illum consequatur.\nEos consectetur quam provident." },
                    { 71, 81, 129, 710004, new DateTime(2021, 2, 16, 2, 52, 41, 136, DateTimeKind.Local).AddTicks(2254), "Est est et voluptatibus in laudantium sit aut quos. Laboriosam quia tempora earum in qui. Soluta est hic sit deserunt ipsum exercitationem repellat quod. Est cumque qui quam." },
                    { 208, 28, 63, 1221, new DateTime(2021, 2, 9, 8, 58, 28, 877, DateTimeKind.Local).AddTicks(871), "ut" },
                    { 229, 18, 113, 805264, new DateTime(2020, 10, 28, 5, 50, 51, 937, DateTimeKind.Local).AddTicks(3135), "Quia vel voluptatibus repellat recusandae veritatis maxime ab id qui. Voluptatum alias totam accusamus itaque. Aperiam ea provident sit quia accusamus corrupti atque." },
                    { 223, 28, 119, 144890, new DateTime(2021, 7, 22, 11, 56, 34, 969, DateTimeKind.Local).AddTicks(5024), "Inventore dignissimos aspernatur odit est soluta eos quia ut officiis." },
                    { 367, 64, 64, 18273, new DateTime(2021, 3, 14, 10, 43, 25, 837, DateTimeKind.Local).AddTicks(7953), "Enim omnis velit sed et vero eveniet ut eveniet." },
                    { 462, 64, 12, 443583, new DateTime(2021, 2, 2, 9, 31, 27, 638, DateTimeKind.Local).AddTicks(2669), "deserunt" },
                    { 365, 28, 128, 591219, new DateTime(2021, 3, 15, 9, 42, 21, 336, DateTimeKind.Local).AddTicks(3289), "Unde libero blanditiis at. Ab enim quia ipsam quidem enim et labore atque. Autem et omnis omnis. Consequatur omnis quia ex corrupti maxime. Velit quibusdam alias quia eos quibusdam aut atque omnis. Recusandae sit aliquid eius sunt optio ad." },
                    { 444, 28, 109, 510784, new DateTime(2021, 6, 20, 5, 37, 10, 418, DateTimeKind.Local).AddTicks(4265), "vero" },
                    { 520, 28, 19, 861648, new DateTime(2020, 12, 26, 8, 45, 9, 13, DateTimeKind.Local).AddTicks(4738), "Blanditiis et aliquam.\nItaque ipsum dolorem illo.\nQuis autem sed sunt reiciendis beatae soluta." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 330, 64, 14, 207522, new DateTime(2021, 3, 30, 4, 4, 6, 408, DateTimeKind.Local).AddTicks(6028), "non" },
                    { 326, 64, 19, 459321, new DateTime(2021, 5, 20, 5, 15, 17, 99, DateTimeKind.Local).AddTicks(8427), "Doloribus maiores amet provident et occaecati ut praesentium. Et ad at inventore voluptatem. Rerum nemo eum nulla. Voluptate pariatur sed reiciendis suscipit ut et." },
                    { 361, 28, 35, 159072, new DateTime(2021, 6, 29, 18, 49, 12, 78, DateTimeKind.Local).AddTicks(7362), "Fuga et voluptatem est unde molestias quaerat delectus eos et. Distinctio minima id sint minus nulla ut quia et. Natus iste modi sunt officia. Pariatur aut quis quis illum id enim fuga." },
                    { 319, 64, 149, 724543, new DateTime(2021, 4, 10, 5, 13, 50, 393, DateTimeKind.Local).AddTicks(6440), "Voluptas sunt unde omnis omnis quia sapiente aliquam ullam minus." },
                    { 133, 64, 26, 27137, new DateTime(2021, 8, 12, 18, 33, 14, 547, DateTimeKind.Local).AddTicks(1184), "Porro excepturi quae aperiam dolorem ullam est voluptas et perspiciatis." },
                    { 111, 61, 71, 437828, new DateTime(2020, 12, 18, 17, 23, 13, 704, DateTimeKind.Local).AddTicks(927), "dolor" },
                    { 531, 61, 62, 819751, new DateTime(2021, 4, 14, 22, 35, 43, 870, DateTimeKind.Local).AddTicks(234), "Aut quia eveniet ea.\nEt aut incidunt.\nEnim velit autem fugiat quod adipisci non nihil iusto aut.\nDolor eaque deleniti corporis modi.\nQuibusdam necessitatibus fuga iure incidunt.\nEst eum fuga nesciunt." },
                    { 379, 61, 86, 466594, new DateTime(2021, 4, 19, 0, 12, 14, 76, DateTimeKind.Local).AddTicks(9113), "aspernatur" },
                    { 9, 13, 6, 23615, new DateTime(2021, 1, 27, 2, 47, 32, 716, DateTimeKind.Local).AddTicks(4112), "Sint rerum facere velit delectus voluptate ab rerum ut eos. Consequatur ut qui vel nihil sequi. Reprehenderit consequatur delectus est necessitatibus corporis qui. Recusandae illum officiis atque accusamus." },
                    { 102, 13, 101, 336189, new DateTime(2020, 9, 18, 1, 30, 50, 690, DateTimeKind.Local).AddTicks(8733), "Quis in asperiores est velit quia voluptate rerum asperiores." },
                    { 269, 64, 116, 648390, new DateTime(2021, 5, 18, 15, 11, 21, 965, DateTimeKind.Local).AddTicks(7154), "Consequuntur quaerat mollitia eum rerum quia ex voluptas. Asperiores aut dignissimos qui quo ut ratione beatae. Dignissimos ad labore tenetur est. Ipsum eum et in et. Quibusdam ab corrupti culpa officiis quos ipsam aut. Voluptas odio iusto placeat aut numquam ut sint." },
                    { 374, 64, 71, 49078, new DateTime(2020, 12, 31, 21, 4, 17, 287, DateTimeKind.Local).AddTicks(7032), "Culpa eos esse qui ipsum sit sed id perferendis." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 41, new DateTime(2021, 1, 9, 17, 45, 12, 12, DateTimeKind.Local).AddTicks(6527), 56, 22, new DateTime(2021, 12, 30, 7, 51, 22, 998, DateTimeKind.Local).AddTicks(6919), new DateTime(2020, 11, 6, 16, 36, 20, 799, DateTimeKind.Local).AddTicks(4145), 4, null, null, "Facilis impedit qui dolorem beatae dignissimos molestiae ut.", 14 },
                    { 52, new DateTime(2020, 9, 25, 20, 16, 41, 765, DateTimeKind.Local).AddTicks(5374), 56, 41, new DateTime(2021, 12, 14, 7, 18, 25, 70, DateTimeKind.Local).AddTicks(3036), new DateTime(2020, 11, 9, 15, 56, 29, 441, DateTimeKind.Local).AddTicks(8463), 1, null, null, "Dolores porro dolor omnis molestias eos earum. Id nemo voluptatibus impedit doloremque. Voluptatem autem et voluptas. Id sit nesciunt similique voluptatem eos laboriosam eveniet aliquid dolores. Blanditiis tempore temporibus fugit reiciendis dolores ut veniam doloribus.", 266 },
                    { 76, new DateTime(2021, 5, 14, 18, 22, 44, 998, DateTimeKind.Local).AddTicks(6721), 56, 11, new DateTime(2022, 2, 16, 15, 57, 41, 116, DateTimeKind.Local).AddTicks(4512), new DateTime(2021, 2, 27, 22, 20, 41, 258, DateTimeKind.Local).AddTicks(8842), 4, null, null, "amet", 256 },
                    { 87, new DateTime(2020, 11, 5, 20, 22, 30, 45, DateTimeKind.Local).AddTicks(6224), 7, 84, new DateTime(2021, 12, 30, 4, 44, 54, 455, DateTimeKind.Local).AddTicks(7423), new DateTime(2020, 10, 16, 16, 12, 38, 397, DateTimeKind.Local).AddTicks(3015), 1, null, null, "Nam ex optio omnis est velit exercitationem ut velit illo.", 293 },
                    { 178, new DateTime(2020, 12, 25, 11, 5, 51, 663, DateTimeKind.Local).AddTicks(2061), 56, 47, new DateTime(2022, 3, 6, 7, 33, 10, 56, DateTimeKind.Local).AddTicks(205), new DateTime(2021, 6, 18, 14, 26, 42, 307, DateTimeKind.Local).AddTicks(5673), 1, null, null, "Et alias modi voluptatem soluta.\nSed perferendis itaque corrupti modi quia sit.\nDoloremque nulla molestiae deleniti sint voluptatem adipisci.\nMagnam asperiores qui qui.\nEt odio harum quia vero.", 51 },
                    { 136, new DateTime(2020, 12, 18, 6, 56, 7, 107, DateTimeKind.Local).AddTicks(8860), 16, 95, new DateTime(2021, 9, 26, 19, 13, 7, 742, DateTimeKind.Local).AddTicks(3662), new DateTime(2021, 7, 9, 16, 1, 54, 284, DateTimeKind.Local).AddTicks(6968), 5, null, null, "voluptatem", 218 },
                    { 110, new DateTime(2021, 1, 22, 16, 54, 56, 78, DateTimeKind.Local).AddTicks(6469), 16, 45, new DateTime(2021, 10, 20, 3, 45, 58, 325, DateTimeKind.Local).AddTicks(4536), new DateTime(2021, 1, 24, 15, 21, 26, 171, DateTimeKind.Local).AddTicks(6784), 1, null, null, "Neque minima nostrum natus iure reprehenderit. Qui ipsam itaque. Veniam consequuntur esse accusamus repellendus.", 95 },
                    { 20, new DateTime(2020, 9, 13, 7, 57, 28, 786, DateTimeKind.Local).AddTicks(8592), 23, 17, new DateTime(2021, 12, 26, 8, 28, 1, 127, DateTimeKind.Local).AddTicks(2371), new DateTime(2021, 5, 27, 11, 14, 23, 337, DateTimeKind.Local).AddTicks(674), 4, null, null, "Eum et repellendus error sint officiis ad nihil ullam exercitationem. Sint quia omnis tenetur vitae vel quia deleniti laboriosam. Rerum esse fugit alias vero non possimus dolorem aut nam.", 295 },
                    { 175, new DateTime(2021, 8, 17, 18, 57, 23, 912, DateTimeKind.Local).AddTicks(2151), 11, 39, new DateTime(2022, 7, 22, 0, 24, 44, 986, DateTimeKind.Local).AddTicks(7038), new DateTime(2020, 10, 23, 19, 49, 41, 274, DateTimeKind.Local).AddTicks(6426), 2, null, null, "debitis", 296 },
                    { 33, new DateTime(2020, 10, 3, 22, 32, 34, 213, DateTimeKind.Local).AddTicks(8919), 26, 113, new DateTime(2022, 2, 23, 13, 23, 15, 688, DateTimeKind.Local).AddTicks(9277), new DateTime(2021, 4, 11, 17, 7, 52, 280, DateTimeKind.Local).AddTicks(3289), 4, null, null, "Sit totam reiciendis qui. Temporibus alias quae iure aut nam est molestiae. Quibusdam recusandae quis quia corporis in laudantium.", 299 },
                    { 176, new DateTime(2020, 9, 5, 8, 53, 18, 823, DateTimeKind.Local).AddTicks(4294), 23, 113, new DateTime(2021, 12, 23, 9, 43, 15, 732, DateTimeKind.Local).AddTicks(8277), new DateTime(2021, 1, 20, 14, 35, 51, 710, DateTimeKind.Local).AddTicks(9957), 5, null, null, "eius", 207 },
                    { 170, new DateTime(2021, 7, 30, 21, 16, 59, 660, DateTimeKind.Local).AddTicks(5347), 23, 2, new DateTime(2022, 6, 1, 8, 22, 9, 69, DateTimeKind.Local).AddTicks(3124), new DateTime(2021, 6, 15, 18, 51, 52, 58, DateTimeKind.Local).AddTicks(1958), 1, null, null, "facere", 264 },
                    { 120, new DateTime(2021, 2, 27, 3, 50, 19, 25, DateTimeKind.Local).AddTicks(1121), 23, 53, new DateTime(2021, 11, 17, 16, 34, 25, 886, DateTimeKind.Local).AddTicks(6603), new DateTime(2020, 9, 14, 10, 7, 32, 964, DateTimeKind.Local).AddTicks(5981), 4, null, null, "dignissimos", 274 },
                    { 66, new DateTime(2021, 1, 7, 8, 44, 14, 176, DateTimeKind.Local).AddTicks(62), 16, 39, new DateTime(2021, 10, 11, 7, 21, 19, 174, DateTimeKind.Local).AddTicks(6680), new DateTime(2021, 6, 22, 4, 58, 38, 886, DateTimeKind.Local).AddTicks(308), 2, null, null, "Est eum quia aut.", 116 },
                    { 123, new DateTime(2020, 11, 11, 5, 20, 53, 241, DateTimeKind.Local).AddTicks(9694), 26, 108, new DateTime(2022, 5, 29, 4, 22, 36, 186, DateTimeKind.Local).AddTicks(7897), new DateTime(2021, 2, 24, 21, 4, 37, 287, DateTimeKind.Local).AddTicks(1095), 2, null, null, "Laboriosam et rerum. Numquam cumque eum quis. Ullam dolores corporis.", 14 },
                    { 126, new DateTime(2021, 7, 18, 5, 18, 17, 955, DateTimeKind.Local).AddTicks(4764), 26, 52, new DateTime(2021, 9, 16, 0, 27, 42, 277, DateTimeKind.Local).AddTicks(3628), new DateTime(2021, 8, 17, 8, 14, 46, 316, DateTimeKind.Local).AddTicks(2780), 4, null, null, "Et reprehenderit quaerat culpa ab aut est.", 111 },
                    { 49, new DateTime(2021, 1, 31, 17, 21, 57, 141, DateTimeKind.Local).AddTicks(7411), 76, 95, new DateTime(2022, 4, 30, 16, 35, 33, 936, DateTimeKind.Local).AddTicks(6424), new DateTime(2021, 7, 14, 10, 25, 8, 309, DateTimeKind.Local).AddTicks(4469), 1, null, null, "qui", 33 },
                    { 24, new DateTime(2021, 4, 6, 5, 19, 21, 827, DateTimeKind.Local).AddTicks(9384), 23, 104, new DateTime(2021, 8, 28, 17, 29, 6, 418, DateTimeKind.Local).AddTicks(9580), new DateTime(2020, 11, 3, 2, 31, 29, 696, DateTimeKind.Local).AddTicks(6095), 1, null, null, "Sit mollitia beatae est.\nConsequuntur iste et et.\nNon consequatur ab quia ad.", 71 },
                    { 199, new DateTime(2020, 9, 5, 6, 15, 12, 267, DateTimeKind.Local).AddTicks(7687), 16, 149, new DateTime(2022, 1, 17, 12, 52, 19, 939, DateTimeKind.Local).AddTicks(642), new DateTime(2021, 5, 10, 17, 52, 46, 816, DateTimeKind.Local).AddTicks(9111), 5, null, null, "Nostrum fuga et.", 18 },
                    { 16, new DateTime(2021, 4, 5, 9, 6, 53, 676, DateTimeKind.Local).AddTicks(5416), 10, 24, new DateTime(2022, 4, 2, 2, 14, 43, 104, DateTimeKind.Local).AddTicks(2165), new DateTime(2021, 6, 20, 8, 24, 58, 311, DateTimeKind.Local).AddTicks(9125), 3, null, null, "Mollitia eos et et molestiae qui aut amet inventore.", 259 },
                    { 142, new DateTime(2020, 12, 3, 16, 57, 48, 820, DateTimeKind.Local).AddTicks(9050), 3, 117, new DateTime(2022, 6, 11, 23, 15, 15, 207, DateTimeKind.Local).AddTicks(363), new DateTime(2021, 1, 29, 10, 59, 50, 711, DateTimeKind.Local).AddTicks(1237), 4, null, null, "Natus qui sed in consequuntur quidem. Esse non suscipit nihil doloribus repudiandae nesciunt praesentium consequatur. Tempora quia dolore et quis ex voluptatem repudiandae sit voluptatem. Quo error omnis ut placeat. Placeat omnis nobis nesciunt accusantium amet blanditiis.", 167 },
                    { 57, new DateTime(2020, 11, 28, 16, 22, 17, 912, DateTimeKind.Local).AddTicks(592), 42, 42, new DateTime(2022, 7, 10, 9, 14, 30, 681, DateTimeKind.Local).AddTicks(4063), new DateTime(2020, 11, 16, 11, 58, 29, 672, DateTimeKind.Local).AddTicks(5807), 2, null, null, "Asperiores voluptatum eum id. Reiciendis officiis rem at dolor aliquam aliquid fuga. Illum aut doloremque error non. Inventore quo voluptas in dolores praesentium rerum. Facilis et eius optio quae dolorem sunt error ut iure.", 264 },
                    { 148, new DateTime(2021, 3, 8, 13, 53, 55, 294, DateTimeKind.Local).AddTicks(3004), 7, 135, new DateTime(2021, 11, 17, 7, 11, 31, 903, DateTimeKind.Local).AddTicks(996), new DateTime(2021, 3, 15, 0, 17, 23, 192, DateTimeKind.Local).AddTicks(5243), 2, null, null, "Hic ab quos adipisci molestiae laboriosam vitae. Ad ipsam quia enim earum a. Deserunt ipsa perspiciatis et est ut.", 266 },
                    { 146, new DateTime(2020, 9, 29, 13, 32, 4, 892, DateTimeKind.Local).AddTicks(9792), 53, 61, new DateTime(2021, 11, 3, 0, 14, 20, 642, DateTimeKind.Local).AddTicks(4197), new DateTime(2021, 3, 21, 15, 14, 31, 258, DateTimeKind.Local).AddTicks(3184), 2, null, null, "et", 50 },
                    { 10, new DateTime(2021, 5, 28, 17, 25, 47, 514, DateTimeKind.Local).AddTicks(6442), 40, 53, new DateTime(2022, 4, 8, 5, 36, 56, 941, DateTimeKind.Local).AddTicks(6551), new DateTime(2021, 4, 25, 3, 36, 45, 689, DateTimeKind.Local).AddTicks(5154), 4, null, null, "Et ipsam voluptas neque ex qui distinctio ut facilis quibusdam. Aut illo ducimus nobis id. Voluptatum aliquid enim temporibus cupiditate quis. Ut sed quisquam assumenda earum quibusdam enim.", 124 },
                    { 90, new DateTime(2021, 6, 11, 9, 33, 58, 285, DateTimeKind.Local).AddTicks(324), 32, 117, new DateTime(2022, 1, 2, 3, 24, 58, 634, DateTimeKind.Local).AddTicks(403), new DateTime(2021, 7, 20, 16, 45, 15, 597, DateTimeKind.Local).AddTicks(5939), 2, null, null, "Officiis et beatae.", 74 },
                    { 39, new DateTime(2020, 12, 22, 3, 18, 19, 921, DateTimeKind.Local).AddTicks(5694), 32, 1, new DateTime(2022, 6, 1, 9, 20, 0, 20, DateTimeKind.Local).AddTicks(6579), new DateTime(2021, 3, 17, 19, 13, 48, 951, DateTimeKind.Local).AddTicks(4192), 2, null, null, "explicabo", 226 },
                    { 150, new DateTime(2021, 7, 20, 8, 47, 1, 144, DateTimeKind.Local).AddTicks(8545), 83, 2, new DateTime(2022, 4, 20, 7, 46, 56, 946, DateTimeKind.Local).AddTicks(194), new DateTime(2020, 11, 11, 22, 24, 8, 420, DateTimeKind.Local).AddTicks(7760), 5, null, null, "Beatae enim ut saepe sed. Adipisci et corporis. Sint maxime voluptas nihil voluptatem. Mollitia ut corporis dicta voluptatem quo. Repudiandae ea quasi eos. Fugit ut et dolor qui ut non architecto quia natus.", 20 },
                    { 151, new DateTime(2021, 8, 18, 20, 20, 19, 635, DateTimeKind.Local).AddTicks(2859), 53, 84, new DateTime(2022, 1, 7, 19, 55, 36, 713, DateTimeKind.Local).AddTicks(3784), new DateTime(2020, 11, 26, 17, 15, 5, 322, DateTimeKind.Local).AddTicks(8055), 4, null, null, "consequatur", 218 },
                    { 94, new DateTime(2020, 10, 27, 18, 17, 42, 51, DateTimeKind.Local).AddTicks(940), 53, 28, new DateTime(2022, 1, 30, 21, 28, 0, 800, DateTimeKind.Local).AddTicks(706), new DateTime(2021, 3, 13, 22, 16, 46, 932, DateTimeKind.Local).AddTicks(4993), 4, null, null, "Dolor deleniti facere rem pariatur inventore est. Ut reiciendis consequatur iure laboriosam excepturi eaque explicabo molestias. Dolore et eius quia dolorem quia voluptates aut.", 111 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 31, new DateTime(2021, 3, 20, 2, 53, 1, 232, DateTimeKind.Local).AddTicks(7366), 40, 80, new DateTime(2021, 12, 20, 17, 43, 26, 189, DateTimeKind.Local).AddTicks(125), new DateTime(2020, 10, 28, 5, 39, 15, 675, DateTimeKind.Local).AddTicks(9663), 3, null, null, "Modi nam vitae dolorum reprehenderit.", 103 },
                    { 102, new DateTime(2020, 11, 9, 1, 2, 16, 554, DateTimeKind.Local).AddTicks(9857), 40, 148, new DateTime(2021, 9, 3, 11, 9, 3, 948, DateTimeKind.Local).AddTicks(9210), new DateTime(2021, 5, 9, 22, 10, 5, 971, DateTimeKind.Local).AddTicks(7493), 3, null, null, "Qui quam fugit sed omnis exercitationem aut soluta qui est.\nDeleniti et optio quos ea.\nQuo atque voluptas nam numquam harum.\nRerum praesentium modi itaque.", 51 },
                    { 187, new DateTime(2021, 8, 10, 3, 29, 45, 978, DateTimeKind.Local).AddTicks(8361), 7, 93, new DateTime(2022, 2, 2, 9, 22, 8, 725, DateTimeKind.Local).AddTicks(4862), new DateTime(2021, 8, 25, 11, 43, 43, 779, DateTimeKind.Local).AddTicks(6727), 3, null, null, "Aspernatur ad dolores quam minus. Dolorem eos inventore amet doloribus illum ipsam facere. Eaque vel labore placeat. A consequuntur omnis. Consectetur vel consequatur et fuga quia consequatur recusandae. Nihil rerum hic est dolore qui ad.", 51 },
                    { 196, new DateTime(2021, 1, 7, 13, 43, 24, 797, DateTimeKind.Local).AddTicks(6497), 7, 93, new DateTime(2022, 3, 9, 13, 57, 1, 328, DateTimeKind.Local).AddTicks(4491), new DateTime(2020, 10, 17, 6, 11, 42, 398, DateTimeKind.Local).AddTicks(2349), 1, null, null, "sit", 297 },
                    { 165, new DateTime(2021, 8, 15, 5, 51, 42, 287, DateTimeKind.Local).AddTicks(3512), 61, 27, new DateTime(2022, 5, 8, 22, 54, 16, 86, DateTimeKind.Local).AddTicks(8847), new DateTime(2021, 6, 30, 8, 33, 34, 460, DateTimeKind.Local).AddTicks(8709), 5, null, null, "Rerum qui neque rerum consequatur et rerum ut ut nesciunt. Ratione sed error reprehenderit provident sit adipisci asperiores autem eos. Corrupti omnis repellendus et culpa sit dicta facilis sint voluptatem.", 297 },
                    { 173, new DateTime(2021, 6, 14, 15, 26, 18, 280, DateTimeKind.Local).AddTicks(1367), 30, 103, new DateTime(2022, 5, 22, 21, 16, 32, 361, DateTimeKind.Local).AddTicks(5421), new DateTime(2021, 8, 15, 0, 41, 59, 519, DateTimeKind.Local).AddTicks(4671), 3, null, null, "Ea aut unde eum libero. Eos repellat voluptates reprehenderit quo repellendus non. Molestiae odit autem consectetur velit. Error quo eos deserunt.", 190 },
                    { 92, new DateTime(2021, 2, 20, 0, 27, 58, 62, DateTimeKind.Local).AddTicks(2997), 30, 96, new DateTime(2022, 2, 23, 16, 55, 19, 223, DateTimeKind.Local).AddTicks(1602), new DateTime(2021, 1, 11, 9, 6, 30, 426, DateTimeKind.Local).AddTicks(6532), 3, null, null, "quod", 202 },
                    { 135, new DateTime(2020, 12, 26, 14, 15, 37, 502, DateTimeKind.Local).AddTicks(9334), 40, 66, new DateTime(2021, 12, 3, 15, 35, 19, 738, DateTimeKind.Local).AddTicks(3563), new DateTime(2020, 9, 25, 18, 37, 19, 17, DateTimeKind.Local).AddTicks(131), 4, null, null, "Aut officia placeat reiciendis.\nOmnis deserunt optio maiores quia autem cupiditate rerum excepturi aut.\nQui dolorum illo reiciendis asperiores et.\nId magnam a aliquam veritatis ut similique nihil aut.\nEius inventore qui sunt beatae est recusandae.", 49 },
                    { 91, new DateTime(2021, 5, 25, 14, 32, 34, 985, DateTimeKind.Local).AddTicks(6675), 53, 50, new DateTime(2021, 9, 15, 19, 15, 47, 283, DateTimeKind.Local).AddTicks(9365), new DateTime(2020, 9, 19, 16, 42, 7, 153, DateTimeKind.Local).AddTicks(9776), 1, null, null, "Placeat aspernatur et non alias doloribus qui aliquam.", 277 },
                    { 100, new DateTime(2021, 8, 4, 17, 40, 43, 113, DateTimeKind.Local).AddTicks(7133), 65, 115, new DateTime(2022, 2, 24, 5, 57, 20, 640, DateTimeKind.Local).AddTicks(4134), new DateTime(2021, 1, 13, 2, 24, 3, 995, DateTimeKind.Local).AddTicks(2311), 2, null, null, "Ut vel et magni fugit. Quo non ut cupiditate aliquid velit laboriosam. Quia ullam necessitatibus corrupti hic. Velit inventore aliquam voluptatibus. Consequatur recusandae non labore beatae odit labore vitae natus et.", 194 },
                    { 160, new DateTime(2021, 7, 19, 5, 29, 49, 670, DateTimeKind.Local).AddTicks(5186), 65, 65, new DateTime(2022, 6, 17, 11, 26, 36, 116, DateTimeKind.Local).AddTicks(6432), new DateTime(2021, 2, 10, 17, 53, 57, 904, DateTimeKind.Local).AddTicks(4484), 3, null, null, "natus", 103 },
                    { 6, new DateTime(2021, 7, 13, 9, 32, 16, 810, DateTimeKind.Local).AddTicks(3298), 50, 79, new DateTime(2022, 2, 6, 3, 5, 46, 873, DateTimeKind.Local).AddTicks(7044), new DateTime(2021, 6, 13, 18, 21, 6, 618, DateTimeKind.Local).AddTicks(1263), 4, null, null, "Culpa ducimus est velit enim error quia qui asperiores voluptates.\nQuia est perferendis quo aut enim nesciunt corrupti quaerat explicabo.", 57 },
                    { 71, new DateTime(2020, 9, 10, 3, 39, 33, 804, DateTimeKind.Local).AddTicks(8509), 7, 150, new DateTime(2022, 5, 27, 8, 11, 0, 105, DateTimeKind.Local).AddTicks(4601), new DateTime(2020, 12, 7, 21, 9, 27, 969, DateTimeKind.Local).AddTicks(2942), 2, null, null, "in", 49 },
                    { 184, new DateTime(2021, 4, 5, 23, 4, 30, 669, DateTimeKind.Local).AddTicks(6411), 10, 35, new DateTime(2021, 9, 9, 3, 3, 37, 519, DateTimeKind.Local).AddTicks(1319), new DateTime(2020, 9, 29, 3, 32, 43, 682, DateTimeKind.Local).AddTicks(2612), 5, null, null, "Repudiandae quia omnis accusamus sed eum.", 204 },
                    { 56, new DateTime(2021, 1, 1, 15, 15, 4, 979, DateTimeKind.Local).AddTicks(8409), 61, 138, new DateTime(2021, 10, 8, 20, 1, 7, 148, DateTimeKind.Local).AddTicks(4824), new DateTime(2020, 12, 12, 2, 15, 0, 717, DateTimeKind.Local).AddTicks(8989), 1, null, null, "Reprehenderit iste ipsa repellendus ipsum alias qui officia sint.\nSunt omnis quasi error ipsa.\nQuia corrupti possimus quod maxime cum incidunt laudantium.", 293 },
                    { 13, new DateTime(2021, 6, 17, 17, 49, 21, 868, DateTimeKind.Local).AddTicks(1130), 61, 128, new DateTime(2021, 11, 30, 19, 23, 50, 848, DateTimeKind.Local).AddTicks(7567), new DateTime(2021, 6, 10, 17, 40, 17, 798, DateTimeKind.Local).AddTicks(4049), 3, null, null, "Modi ipsam expedita.", 281 },
                    { 77, new DateTime(2020, 10, 11, 9, 43, 0, 185, DateTimeKind.Local).AddTicks(1250), 18, 117, new DateTime(2022, 8, 18, 11, 44, 5, 671, DateTimeKind.Local).AddTicks(910), new DateTime(2020, 11, 11, 17, 42, 28, 606, DateTimeKind.Local).AddTicks(9711), 5, null, null, "Dolores necessitatibus saepe ullam ut est voluptas quia.", 95 },
                    { 195, new DateTime(2021, 7, 8, 16, 55, 20, 25, DateTimeKind.Local).AddTicks(1059), 65, 35, new DateTime(2021, 11, 1, 2, 27, 7, 464, DateTimeKind.Local).AddTicks(657), new DateTime(2021, 6, 24, 7, 4, 32, 509, DateTimeKind.Local).AddTicks(5760), 2, null, null, "Accusantium dolore voluptatum voluptas facere.\nVel fugit incidunt quibusdam iusto.\nRecusandae ducimus veniam ducimus vitae excepturi voluptas voluptatem.", 255 },
                    { 2, new DateTime(2021, 2, 21, 16, 49, 4, 775, DateTimeKind.Local).AddTicks(8568), 53, 106, new DateTime(2021, 9, 24, 8, 22, 40, 525, DateTimeKind.Local).AddTicks(494), new DateTime(2021, 8, 17, 2, 5, 5, 550, DateTimeKind.Local).AddTicks(3930), 5, null, null, "Consequuntur quo nisi temporibus aliquid eos qui.\nPerspiciatis temporibus aut sed cupiditate et magni.", 50 },
                    { 124, new DateTime(2021, 5, 14, 20, 4, 20, 855, DateTimeKind.Local).AddTicks(7969), 3, 132, new DateTime(2022, 2, 22, 12, 2, 26, 464, DateTimeKind.Local).AddTicks(9234), new DateTime(2020, 12, 6, 12, 25, 39, 31, DateTimeKind.Local).AddTicks(9420), 1, null, null, "eaque", 192 },
                    { 112, new DateTime(2021, 7, 25, 1, 30, 46, 502, DateTimeKind.Local).AddTicks(2179), 83, 105, new DateTime(2022, 4, 12, 5, 25, 56, 961, DateTimeKind.Local).AddTicks(1179), new DateTime(2021, 3, 11, 5, 44, 17, 710, DateTimeKind.Local).AddTicks(4875), 4, null, null, "Iste aliquid quibusdam possimus ipsa repellat odit et totam labore.", 300 },
                    { 158, new DateTime(2021, 6, 21, 11, 50, 20, 301, DateTimeKind.Local).AddTicks(823), 42, 106, new DateTime(2022, 3, 19, 9, 54, 40, 948, DateTimeKind.Local).AddTicks(7808), new DateTime(2021, 4, 17, 7, 7, 55, 621, DateTimeKind.Local).AddTicks(1089), 2, null, null, "Sapiente inventore velit.\nMagni natus tenetur molestiae impedit dolorum quod.", 170 },
                    { 72, new DateTime(2020, 9, 28, 19, 20, 32, 777, DateTimeKind.Local).AddTicks(4282), 23, 147, new DateTime(2021, 11, 11, 15, 42, 3, 393, DateTimeKind.Local).AddTicks(5729), new DateTime(2021, 5, 4, 2, 35, 19, 635, DateTimeKind.Local).AddTicks(7852), 2, null, null, "unde", 47 },
                    { 97, new DateTime(2021, 6, 3, 15, 43, 49, 397, DateTimeKind.Local).AddTicks(2482), 82, 141, new DateTime(2022, 7, 13, 1, 2, 4, 705, DateTimeKind.Local).AddTicks(3079), new DateTime(2021, 2, 18, 15, 6, 44, 536, DateTimeKind.Local).AddTicks(6562), 3, null, null, "Quam ut libero magni molestias ipsum. Omnis cum voluptas provident laboriosam ut repellat distinctio numquam autem. Eum repellat vero. Dolorem cupiditate aut et ut animi libero laudantium id. Quam deleniti ut nemo saepe. Porro aspernatur ea nemo repudiandae delectus consectetur ea sit iure.", 300 },
                    { 193, new DateTime(2021, 3, 27, 15, 31, 47, 923, DateTimeKind.Local).AddTicks(5328), 19, 7, new DateTime(2022, 1, 13, 3, 4, 36, 362, DateTimeKind.Local).AddTicks(8624), new DateTime(2021, 6, 13, 7, 35, 58, 182, DateTimeKind.Local).AddTicks(1392), 2, null, null, "Porro quidem eius ut laborum ipsa cumque velit.", 51 },
                    { 106, new DateTime(2020, 10, 30, 10, 2, 54, 686, DateTimeKind.Local).AddTicks(3294), 43, 44, new DateTime(2022, 6, 27, 21, 24, 51, 619, DateTimeKind.Local).AddTicks(9183), new DateTime(2020, 12, 7, 6, 1, 46, 124, DateTimeKind.Local).AddTicks(2479), 3, null, null, "vitae", 300 },
                    { 19, new DateTime(2021, 3, 20, 17, 4, 28, 605, DateTimeKind.Local).AddTicks(1644), 43, 47, new DateTime(2022, 8, 19, 11, 13, 28, 654, DateTimeKind.Local).AddTicks(8543), new DateTime(2020, 12, 17, 22, 35, 14, 103, DateTimeKind.Local).AddTicks(6888), 1, null, null, "Eum consequatur quo.", 182 },
                    { 157, new DateTime(2021, 4, 29, 17, 38, 11, 999, DateTimeKind.Local).AddTicks(2074), 69, 3, new DateTime(2022, 5, 18, 23, 51, 15, 695, DateTimeKind.Local).AddTicks(8356), new DateTime(2020, 11, 29, 0, 53, 10, 743, DateTimeKind.Local).AddTicks(1567), 1, null, null, "sed", 197 },
                    { 64, new DateTime(2021, 8, 10, 16, 33, 37, 355, DateTimeKind.Local).AddTicks(1278), 69, 38, new DateTime(2022, 3, 9, 20, 45, 21, 746, DateTimeKind.Local).AddTicks(744), new DateTime(2021, 4, 22, 22, 44, 24, 179, DateTimeKind.Local).AddTicks(3532), 5, null, null, "Natus cumque iste fugiat et omnis vitae eos ut consequatur. Quaerat a totam recusandae quisquam dolores quos laborum illum dolor. Nulla id aut id quod dolores et. Tenetur aut quidem eius sit enim non. Animi natus iste molestiae commodi. Quis distinctio eos deleniti nostrum.", 41 },
                    { 141, new DateTime(2021, 2, 12, 2, 15, 2, 744, DateTimeKind.Local).AddTicks(1402), 29, 21, new DateTime(2022, 7, 22, 23, 42, 14, 304, DateTimeKind.Local).AddTicks(9541), new DateTime(2020, 9, 19, 18, 30, 35, 74, DateTimeKind.Local).AddTicks(9274), 3, null, null, "Provident accusamus ab explicabo quis a. Eos necessitatibus minus sequi dolorem. Ratione quas consequuntur sed.", 213 },
                    { 28, new DateTime(2020, 12, 6, 12, 14, 1, 76, DateTimeKind.Local).AddTicks(5944), 13, 79, new DateTime(2022, 3, 28, 22, 22, 3, 532, DateTimeKind.Local).AddTicks(5647), new DateTime(2021, 7, 2, 11, 12, 55, 354, DateTimeKind.Local).AddTicks(7361), 4, null, null, "Voluptates illum beatae qui.", 47 },
                    { 5, new DateTime(2020, 12, 16, 17, 14, 34, 336, DateTimeKind.Local).AddTicks(5081), 64, 96, new DateTime(2022, 2, 14, 12, 35, 14, 481, DateTimeKind.Local).AddTicks(1222), new DateTime(2020, 9, 5, 12, 7, 20, 736, DateTimeKind.Local).AddTicks(5875), 4, null, null, "Excepturi quis occaecati incidunt quidem odit natus.\nEum ex ipsam.\nIllo quisquam qui omnis modi numquam repellat enim minus occaecati.\nDolorum voluptatem eos explicabo est enim.\nVelit eum est sapiente mollitia consectetur aut.", 55 },
                    { 65, new DateTime(2021, 1, 5, 15, 52, 53, 440, DateTimeKind.Local).AddTicks(9), 28, 73, new DateTime(2022, 7, 13, 0, 42, 24, 125, DateTimeKind.Local).AddTicks(8310), new DateTime(2021, 6, 16, 14, 31, 44, 710, DateTimeKind.Local).AddTicks(6663), 4, null, null, "Veritatis aperiam officia impedit commodi illo et fuga. Ducimus fuga molestias voluptas saepe illo quaerat magnam. Natus ipsam odio debitis. Quia eum quaerat quam quisquam. Atque accusantium blanditiis quaerat error sed cupiditate. Eius alias incidunt eum eaque quia doloremque libero sed quas.", 256 },
                    { 164, new DateTime(2021, 7, 17, 5, 3, 16, 421, DateTimeKind.Local).AddTicks(2852), 43, 10, new DateTime(2021, 11, 29, 16, 6, 31, 814, DateTimeKind.Local).AddTicks(7890), new DateTime(2021, 4, 9, 21, 25, 13, 23, DateTimeKind.Local).AddTicks(8161), 4, null, null, "expedita", 126 },
                    { 27, new DateTime(2021, 1, 26, 7, 48, 1, 141, DateTimeKind.Local).AddTicks(3312), 28, 145, new DateTime(2021, 12, 28, 12, 30, 52, 226, DateTimeKind.Local).AddTicks(359), new DateTime(2021, 2, 17, 4, 39, 12, 38, DateTimeKind.Local).AddTicks(8674), 4, null, null, "Ea quasi ut similique cupiditate magnam nobis.", 52 },
                    { 149, new DateTime(2020, 9, 12, 11, 17, 51, 342, DateTimeKind.Local).AddTicks(404), 15, 2, new DateTime(2022, 2, 7, 7, 3, 51, 511, DateTimeKind.Local).AddTicks(1600), new DateTime(2021, 7, 8, 19, 50, 14, 947, DateTimeKind.Local).AddTicks(582), 5, null, null, "ea", 266 },
                    { 129, new DateTime(2020, 9, 30, 7, 38, 38, 194, DateTimeKind.Local).AddTicks(1921), 15, 81, new DateTime(2021, 9, 10, 4, 55, 18, 49, DateTimeKind.Local).AddTicks(8044), new DateTime(2021, 1, 12, 14, 1, 10, 314, DateTimeKind.Local).AddTicks(2097), 5, null, null, "Repellat qui consequatur et omnis sit aspernatur ut possimus iure.", 86 },
                    { 121, new DateTime(2021, 6, 30, 16, 36, 57, 521, DateTimeKind.Local).AddTicks(3363), 15, 65, new DateTime(2021, 12, 21, 23, 24, 15, 99, DateTimeKind.Local).AddTicks(2011), new DateTime(2021, 4, 22, 18, 47, 4, 235, DateTimeKind.Local).AddTicks(5062), 3, null, null, "Porro saepe sequi illum autem hic enim sit omnis.", 192 },
                    { 109, new DateTime(2020, 12, 7, 1, 10, 49, 688, DateTimeKind.Local).AddTicks(2857), 15, 45, new DateTime(2022, 3, 5, 6, 32, 14, 623, DateTimeKind.Local).AddTicks(8888), new DateTime(2021, 5, 8, 19, 54, 27, 93, DateTimeKind.Local).AddTicks(7563), 5, null, null, "dolorem", 213 },
                    { 55, new DateTime(2021, 7, 16, 9, 23, 13, 851, DateTimeKind.Local).AddTicks(8268), 15, 128, new DateTime(2022, 7, 17, 12, 51, 1, 513, DateTimeKind.Local).AddTicks(9636), new DateTime(2020, 12, 17, 1, 5, 0, 954, DateTimeKind.Local).AddTicks(886), 1, null, null, "eum", 192 },
                    { 140, new DateTime(2020, 9, 14, 21, 24, 24, 725, DateTimeKind.Local).AddTicks(6381), 21, 119, new DateTime(2022, 8, 8, 22, 56, 15, 44, DateTimeKind.Local).AddTicks(7403), new DateTime(2021, 3, 9, 18, 0, 48, 371, DateTimeKind.Local).AddTicks(3780), 3, null, null, "Commodi officiis rem mollitia saepe cum eum.", 130 },
                    { 95, new DateTime(2020, 10, 18, 9, 29, 21, 405, DateTimeKind.Local).AddTicks(267), 21, 84, new DateTime(2022, 3, 13, 15, 0, 23, 159, DateTimeKind.Local).AddTicks(6302), new DateTime(2020, 12, 31, 6, 42, 58, 973, DateTimeKind.Local).AddTicks(6338), 2, null, null, "Sed est quam enim aspernatur suscipit earum ea.\nEt tempore quia quis dolores ea porro porro dolores corporis.", 14 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 182, new DateTime(2020, 9, 28, 16, 30, 33, 776, DateTimeKind.Local).AddTicks(1777), 81, 147, new DateTime(2021, 12, 3, 9, 45, 48, 984, DateTimeKind.Local).AddTicks(542), new DateTime(2021, 5, 25, 12, 31, 15, 512, DateTimeKind.Local).AddTicks(9553), 3, null, null, "Aut consequuntur autem rerum cumque autem ut quis. Aut non qui sint minima vel. Eos amet aut sed possimus porro vero illum ut fugiat. Impedit iusto quo qui ad deleniti debitis numquam architecto corrupti. Dolor a nulla voluptas ut ipsa. Est maxime quam dicta velit voluptatem odio expedita quibusdam.", 29 },
                    { 3, new DateTime(2021, 1, 9, 19, 18, 54, 919, DateTimeKind.Local).AddTicks(6930), 28, 86, new DateTime(2022, 4, 7, 13, 22, 26, 431, DateTimeKind.Local).AddTicks(9576), new DateTime(2020, 9, 23, 4, 34, 17, 229, DateTimeKind.Local).AddTicks(7356), 3, null, null, "Dolorem sunt excepturi voluptatem. Quas culpa ut. Qui similique iusto velit quisquam reprehenderit veniam excepturi odit voluptatum.", 51 },
                    { 46, new DateTime(2020, 9, 29, 14, 7, 30, 381, DateTimeKind.Local).AddTicks(8973), 81, 125, new DateTime(2022, 2, 7, 21, 42, 50, 102, DateTimeKind.Local).AddTicks(8915), new DateTime(2020, 9, 15, 20, 59, 44, 894, DateTimeKind.Local).AddTicks(2197), 3, null, null, "Ut nihil doloremque debitis ipsum voluptas tempora ut maiores.\nNatus est sit aut sint enim doloribus voluptatem sint tempore.\nRepudiandae maiores autem fugit nulla.\nAccusantium ut commodi.\nVeritatis consequuntur ut porro.\nMolestiae maxime officiis adipisci animi nostrum.", 74 },
                    { 179, new DateTime(2021, 1, 2, 14, 42, 30, 677, DateTimeKind.Local).AddTicks(7894), 43, 25, new DateTime(2021, 12, 22, 1, 46, 7, 6, DateTimeKind.Local).AddTicks(9677), new DateTime(2020, 10, 29, 1, 2, 33, 389, DateTimeKind.Local).AddTicks(3974), 4, null, null, "Provident hic et aperiam accusantium consectetur qui ratione. Velit dolorem occaecati dolor at facere. Consequatur aspernatur veniam suscipit. Nemo minima consequatur provident qui quasi porro.", 279 },
                    { 68, new DateTime(2021, 8, 24, 14, 11, 18, 446, DateTimeKind.Local).AddTicks(869), 66, 1, new DateTime(2021, 8, 30, 16, 58, 50, 10, DateTimeKind.Local).AddTicks(6861), new DateTime(2021, 1, 8, 22, 47, 58, 985, DateTimeKind.Local).AddTicks(2980), 1, null, null, "Repellat labore nesciunt dolorum enim aliquid placeat. Saepe ut deserunt sed sint accusamus id. Veniam modi quis nam qui ducimus. Delectus impedit saepe et perspiciatis nulla rem. Vero expedita et quaerat amet.", 255 },
                    { 153, new DateTime(2021, 4, 26, 8, 31, 55, 287, DateTimeKind.Local).AddTicks(4008), 34, 135, new DateTime(2022, 8, 20, 3, 27, 24, 525, DateTimeKind.Local).AddTicks(2220), new DateTime(2021, 8, 21, 13, 10, 16, 492, DateTimeKind.Local).AddTicks(3768), 1, null, null, "et", 50 },
                    { 111, new DateTime(2021, 4, 25, 20, 19, 45, 972, DateTimeKind.Local).AddTicks(1458), 17, 74, new DateTime(2021, 10, 4, 16, 45, 16, 774, DateTimeKind.Local).AddTicks(330), new DateTime(2021, 1, 20, 2, 47, 8, 405, DateTimeKind.Local).AddTicks(128), 1, null, null, "Ullam dolorum sapiente laborum.\nOdio quos omnis quam corporis dolores sint soluta maxime porro.", 121 },
                    { 58, new DateTime(2021, 1, 12, 8, 40, 50, 64, DateTimeKind.Local).AddTicks(6549), 27, 22, new DateTime(2022, 8, 9, 1, 5, 27, 201, DateTimeKind.Local).AddTicks(4606), new DateTime(2021, 1, 30, 6, 12, 1, 99, DateTimeKind.Local).AddTicks(3649), 1, null, null, "Autem aut et.", 50 },
                    { 21, new DateTime(2020, 12, 17, 0, 18, 50, 727, DateTimeKind.Local).AddTicks(7298), 27, 12, new DateTime(2022, 7, 22, 12, 39, 40, 753, DateTimeKind.Local).AddTicks(2414), new DateTime(2021, 4, 20, 5, 0, 4, 998, DateTimeKind.Local).AddTicks(1928), 4, null, null, "Ullam provident sint.\nOccaecati similique sed.\nQuas beatae earum vel quibusdam.\nDolores vitae tempore natus veritatis earum sint debitis quam et.\nNam temporibus nam asperiores voluptas id iusto assumenda quaerat.", 130 },
                    { 117, new DateTime(2020, 9, 13, 17, 51, 52, 186, DateTimeKind.Local).AddTicks(8970), 33, 116, new DateTime(2021, 9, 2, 0, 16, 46, 995, DateTimeKind.Local).AddTicks(6213), new DateTime(2021, 8, 18, 14, 59, 51, 662, DateTimeKind.Local).AddTicks(1859), 1, null, null, "Nulla maxime assumenda vitae a aut consequuntur aut.\nMagni voluptatum aliquam alias dolores sint mollitia non aut officia.\nAsperiores ex ratione esse magnam.\nEsse non similique dolorem.\nSint quia animi quo tenetur.\nBeatae eum fugiat ab.", 123 },
                    { 15, new DateTime(2020, 9, 18, 18, 24, 42, 510, DateTimeKind.Local).AddTicks(88), 33, 24, new DateTime(2021, 11, 11, 21, 48, 55, 966, DateTimeKind.Local).AddTicks(8698), new DateTime(2021, 7, 6, 12, 37, 40, 488, DateTimeKind.Local).AddTicks(8835), 3, null, null, "et", 162 },
                    { 88, new DateTime(2021, 6, 17, 7, 13, 4, 971, DateTimeKind.Local).AddTicks(2861), 4, 8, new DateTime(2022, 7, 15, 19, 21, 24, 485, DateTimeKind.Local).AddTicks(1972), new DateTime(2021, 6, 26, 10, 58, 59, 980, DateTimeKind.Local).AddTicks(5318), 1, null, null, "Asperiores adipisci vel sit in corrupti hic nam.", 264 },
                    { 7, new DateTime(2020, 9, 13, 8, 35, 1, 435, DateTimeKind.Local).AddTicks(9667), 4, 36, new DateTime(2022, 7, 30, 8, 56, 17, 818, DateTimeKind.Local).AddTicks(1046), new DateTime(2021, 2, 18, 13, 18, 28, 847, DateTimeKind.Local).AddTicks(4095), 1, null, null, "Aut maiores necessitatibus excepturi minima nam ratione.\nVoluptatem quia eos id veniam quia corrupti sed blanditiis et.\nVelit et nesciunt omnis aut praesentium.\nNeque rerum architecto eaque.\nCorporis sequi corporis molestiae modi rerum et iste.\nConsequuntur enim modi itaque.", 14 },
                    { 181, new DateTime(2021, 8, 12, 15, 40, 25, 160, DateTimeKind.Local).AddTicks(5439), 43, 135, new DateTime(2022, 5, 8, 22, 36, 37, 218, DateTimeKind.Local).AddTicks(5115), new DateTime(2021, 5, 25, 2, 16, 31, 152, DateTimeKind.Local).AddTicks(3027), 4, null, null, "Veritatis totam perferendis neque tempora tempore iusto et rerum.\nAut et culpa.\nDistinctio est est.\nQui aperiam qui perspiciatis.\nVelit veniam dicta atque.\nEum magni in sequi soluta.", 74 },
                    { 43, new DateTime(2021, 6, 12, 15, 47, 41, 955, DateTimeKind.Local).AddTicks(4416), 46, 79, new DateTime(2021, 10, 19, 4, 4, 4, 666, DateTimeKind.Local).AddTicks(879), new DateTime(2021, 8, 19, 5, 1, 30, 674, DateTimeKind.Local).AddTicks(8360), 2, null, null, "et", 227 },
                    { 25, new DateTime(2021, 5, 16, 1, 30, 2, 164, DateTimeKind.Local).AddTicks(1202), 54, 45, new DateTime(2021, 12, 16, 17, 35, 47, 960, DateTimeKind.Local).AddTicks(5724), new DateTime(2020, 12, 20, 12, 42, 30, 938, DateTimeKind.Local).AddTicks(8103), 3, null, null, "Consectetur accusantium distinctio sit eius delectus repudiandae. Rem eligendi ut dolores. Omnis odio eos dolores voluptatibus molestiae facilis velit corrupti. Eum beatae est id. Itaque ut dolorem porro qui voluptatem accusantium aut eveniet.", 47 },
                    { 9, new DateTime(2020, 12, 6, 17, 17, 9, 211, DateTimeKind.Local).AddTicks(6881), 54, 132, new DateTime(2022, 1, 28, 2, 59, 11, 530, DateTimeKind.Local).AddTicks(730), new DateTime(2021, 1, 7, 14, 14, 45, 821, DateTimeKind.Local).AddTicks(8780), 5, null, null, "Sapiente repellendus adipisci. Nemo fugit perferendis debitis ducimus cupiditate quidem et. Repellat ut sed quasi earum a. Quisquam sed fuga quo qui est debitis quis beatae. Porro culpa quam. Voluptatem rerum rerum quisquam tempore dolorem magnam iusto molestias.", 292 },
                    { 200, new DateTime(2021, 3, 13, 5, 47, 14, 320, DateTimeKind.Local).AddTicks(227), 62, 128, new DateTime(2021, 12, 7, 7, 20, 51, 555, DateTimeKind.Local).AddTicks(7851), new DateTime(2021, 1, 26, 17, 9, 5, 226, DateTimeKind.Local).AddTicks(1640), 3, null, null, "Fugit unde incidunt exercitationem totam.\nAssumenda voluptatem id autem harum qui neque sit.", 10 },
                    { 51, new DateTime(2020, 10, 27, 4, 21, 53, 451, DateTimeKind.Local).AddTicks(4235), 62, 53, new DateTime(2021, 9, 1, 6, 12, 57, 901, DateTimeKind.Local).AddTicks(1804), new DateTime(2021, 1, 7, 21, 48, 29, 784, DateTimeKind.Local).AddTicks(9949), 2, null, null, "Sit ipsa et dolor id expedita debitis ratione in.", 67 },
                    { 186, new DateTime(2020, 10, 6, 15, 33, 25, 515, DateTimeKind.Local).AddTicks(6273), 9, 145, new DateTime(2022, 6, 8, 10, 53, 20, 201, DateTimeKind.Local).AddTicks(229), new DateTime(2020, 10, 5, 18, 34, 47, 65, DateTimeKind.Local).AddTicks(4240), 2, null, null, "Quae temporibus nobis et dolorem fuga error molestiae beatae nihil.\nQui minima numquam ex et ducimus omnis.\nModi et nam omnis itaque officiis et dolores aut adipisci.", 202 },
                    { 122, new DateTime(2020, 10, 30, 10, 21, 58, 214, DateTimeKind.Local).AddTicks(9434), 9, 2, new DateTime(2022, 7, 19, 9, 19, 8, 560, DateTimeKind.Local).AddTicks(5180), new DateTime(2021, 3, 26, 4, 35, 6, 783, DateTimeKind.Local).AddTicks(5015), 2, null, null, "Veritatis error mollitia mollitia distinctio sint culpa ducimus iste laborum.\nRerum aspernatur corporis qui quia iusto reiciendis.", 75 },
                    { 114, new DateTime(2020, 12, 27, 4, 26, 11, 10, DateTimeKind.Local).AddTicks(2712), 9, 2, new DateTime(2022, 3, 14, 17, 49, 47, 347, DateTimeKind.Local).AddTicks(6834), new DateTime(2020, 9, 11, 20, 33, 12, 478, DateTimeKind.Local).AddTicks(8925), 2, null, null, "Quam velit nulla qui odio et magnam quo.\nAut animi est eum aut et et aut dignissimos qui.\nEaque iusto eaque quas.\nUt eveniet ad similique est ea dolore inventore et.\nConsequatur dignissimos tempora totam placeat sit nostrum.", 43 },
                    { 198, new DateTime(2021, 6, 9, 6, 13, 47, 432, DateTimeKind.Local).AddTicks(2055), 66, 107, new DateTime(2022, 7, 11, 0, 46, 34, 622, DateTimeKind.Local).AddTicks(4154), new DateTime(2021, 8, 20, 23, 8, 4, 275, DateTimeKind.Local).AddTicks(9942), 3, null, null, "Deserunt voluptatem ex provident quam non ipsum pariatur. Dolore veritatis inventore. Ut dolor mollitia. Et eaque tenetur vel velit voluptas ullam commodi natus rem. Ut tenetur cumque. Voluptas officia omnis perferendis minima sit aut voluptate consequatur.", 25 },
                    { 144, new DateTime(2021, 5, 6, 14, 49, 59, 610, DateTimeKind.Local).AddTicks(7694), 54, 116, new DateTime(2021, 12, 27, 23, 31, 18, 308, DateTimeKind.Local).AddTicks(7624), new DateTime(2021, 1, 3, 0, 45, 22, 502, DateTimeKind.Local).AddTicks(2396), 1, null, null, "deserunt", 104 },
                    { 171, new DateTime(2020, 10, 12, 11, 44, 54, 188, DateTimeKind.Local).AddTicks(7887), 34, 110, new DateTime(2021, 12, 27, 9, 0, 15, 409, DateTimeKind.Local).AddTicks(4603), new DateTime(2020, 10, 30, 17, 19, 6, 139, DateTimeKind.Local).AddTicks(7441), 4, null, null, "Possimus est totam explicabo.\nVoluptatem dolores iusto est explicabo quia dolore provident adipisci.", 269 },
                    { 161, new DateTime(2021, 5, 14, 15, 57, 22, 289, DateTimeKind.Local).AddTicks(3739), 77, 56, new DateTime(2021, 12, 29, 23, 11, 58, 279, DateTimeKind.Local).AddTicks(3947), new DateTime(2020, 11, 17, 20, 18, 14, 231, DateTimeKind.Local).AddTicks(4833), 4, null, null, "Eum dolorem enim beatae.", 269 },
                    { 81, new DateTime(2021, 7, 15, 1, 36, 9, 80, DateTimeKind.Local).AddTicks(3424), 90, 138, new DateTime(2022, 6, 6, 23, 39, 12, 761, DateTimeKind.Local).AddTicks(9723), new DateTime(2020, 10, 4, 17, 59, 47, 121, DateTimeKind.Local).AddTicks(6714), 2, null, null, "quia", 111 },
                    { 79, new DateTime(2020, 10, 14, 19, 11, 55, 635, DateTimeKind.Local).AddTicks(2837), 92, 100, new DateTime(2022, 8, 5, 19, 13, 22, 539, DateTimeKind.Local).AddTicks(8658), new DateTime(2021, 6, 24, 18, 44, 37, 442, DateTimeKind.Local).AddTicks(5620), 5, null, null, "Vitae laboriosam nobis id labore atque est voluptatum quos rem.", 167 },
                    { 104, new DateTime(2020, 12, 23, 1, 51, 39, 463, DateTimeKind.Local).AddTicks(6019), 51, 46, new DateTime(2021, 9, 23, 3, 59, 3, 209, DateTimeKind.Local).AddTicks(9988), new DateTime(2021, 6, 30, 14, 18, 30, 207, DateTimeKind.Local).AddTicks(1718), 1, null, null, "Nemo est repellendus rerum deleniti voluptatem architecto quia. Explicabo nihil nisi quis vel nesciunt voluptatem pariatur illo dicta. Culpa assumenda placeat aut perspiciatis.", 86 },
                    { 86, new DateTime(2021, 1, 2, 12, 50, 12, 699, DateTimeKind.Local).AddTicks(2840), 51, 105, new DateTime(2022, 6, 21, 11, 22, 40, 134, DateTimeKind.Local).AddTicks(9373), new DateTime(2021, 2, 2, 12, 42, 43, 730, DateTimeKind.Local).AddTicks(8105), 4, null, null, "Mollitia eum veritatis delectus commodi porro ut. Occaecati voluptatem adipisci. Iste qui vero.", 50 },
                    { 1, new DateTime(2021, 7, 11, 15, 10, 28, 901, DateTimeKind.Local).AddTicks(7845), 51, 50, new DateTime(2021, 9, 23, 19, 15, 50, 912, DateTimeKind.Local).AddTicks(757), new DateTime(2021, 7, 8, 21, 59, 40, 493, DateTimeKind.Local).AddTicks(6409), 2, null, null, "Et ut qui.", 259 },
                    { 89, new DateTime(2021, 7, 19, 10, 33, 42, 961, DateTimeKind.Local).AddTicks(1709), 73, 95, new DateTime(2022, 8, 12, 19, 57, 30, 983, DateTimeKind.Local).AddTicks(7808), new DateTime(2020, 10, 19, 9, 50, 21, 990, DateTimeKind.Local).AddTicks(4078), 5, null, null, "Voluptatem omnis ducimus.", 136 },
                    { 36, new DateTime(2021, 3, 9, 21, 38, 10, 377, DateTimeKind.Local).AddTicks(5752), 73, 139, new DateTime(2022, 8, 13, 11, 2, 46, 682, DateTimeKind.Local).AddTicks(3547), new DateTime(2020, 9, 5, 7, 59, 31, 682, DateTimeKind.Local).AddTicks(8025), 2, null, null, "Aut omnis optio error explicabo facere omnis. Sunt veritatis sunt accusamus consequatur. Adipisci repudiandae id delectus. Quia ipsa magni saepe mollitia et quia qui. Eaque recusandae vel iste corporis et fugit excepturi.", 255 },
                    { 26, new DateTime(2021, 8, 14, 13, 41, 45, 519, DateTimeKind.Local).AddTicks(6650), 73, 15, new DateTime(2022, 8, 21, 4, 43, 17, 506, DateTimeKind.Local).AddTicks(388), new DateTime(2020, 9, 14, 10, 14, 26, 186, DateTimeKind.Local).AddTicks(3286), 2, null, null, "Delectus qui quaerat velit maxime.", 218 },
                    { 130, new DateTime(2020, 10, 22, 22, 1, 45, 39, DateTimeKind.Local).AddTicks(9149), 59, 33, new DateTime(2022, 3, 9, 6, 8, 42, 676, DateTimeKind.Local).AddTicks(5057), new DateTime(2021, 2, 27, 3, 31, 19, 285, DateTimeKind.Local).AddTicks(7580), 4, null, null, "Repellendus laboriosam fugit nam mollitia provident quia quas.", 236 },
                    { 23, new DateTime(2020, 11, 16, 6, 41, 35, 998, DateTimeKind.Local).AddTicks(9829), 47, 99, new DateTime(2022, 1, 9, 0, 37, 27, 171, DateTimeKind.Local).AddTicks(6801), new DateTime(2021, 2, 11, 23, 46, 48, 508, DateTimeKind.Local).AddTicks(4971), 4, null, null, "Rerum adipisci vero.", 126 },
                    { 42, new DateTime(2020, 10, 11, 17, 12, 36, 908, DateTimeKind.Local).AddTicks(2038), 59, 131, new DateTime(2022, 3, 10, 8, 51, 30, 129, DateTimeKind.Local).AddTicks(6157), new DateTime(2021, 7, 23, 3, 13, 40, 726, DateTimeKind.Local).AddTicks(3709), 1, null, null, "Non alias numquam impedit.", 176 },
                    { 103, new DateTime(2020, 12, 21, 10, 37, 49, 181, DateTimeKind.Local).AddTicks(685), 44, 23, new DateTime(2021, 12, 14, 19, 6, 19, 460, DateTimeKind.Local).AddTicks(1355), new DateTime(2020, 9, 10, 16, 51, 35, 167, DateTimeKind.Local).AddTicks(4281), 4, null, null, "Vel facere sequi quaerat saepe totam placeat.", 196 },
                    { 98, new DateTime(2020, 9, 26, 2, 18, 23, 883, DateTimeKind.Local).AddTicks(6650), 44, 53, new DateTime(2022, 6, 1, 14, 45, 37, 306, DateTimeKind.Local).AddTicks(5339), new DateTime(2020, 11, 23, 14, 9, 4, 334, DateTimeKind.Local).AddTicks(5197), 2, null, null, "Nesciunt animi ut sit.\nNon odit eius.", 82 },
                    { 185, new DateTime(2021, 3, 31, 6, 26, 58, 574, DateTimeKind.Local).AddTicks(8535), 25, 81, new DateTime(2021, 12, 5, 11, 3, 23, 723, DateTimeKind.Local).AddTicks(1684), new DateTime(2021, 7, 7, 10, 49, 10, 34, DateTimeKind.Local).AddTicks(6569), 1, null, null, "Animi quaerat et nihil et ut. Maiores amet veniam consequatur. Ut odit sequi delectus sint aliquid animi dolores eos. Consequatur neque quisquam voluptas veritatis dolores iusto magnam.", 281 },
                    { 152, new DateTime(2021, 8, 16, 5, 28, 26, 706, DateTimeKind.Local).AddTicks(2188), 25, 8, new DateTime(2022, 3, 10, 4, 30, 22, 795, DateTimeKind.Local).AddTicks(8481), new DateTime(2021, 3, 22, 7, 5, 55, 583, DateTimeKind.Local).AddTicks(1293), 5, null, null, "commodi", 57 },
                    { 67, new DateTime(2020, 9, 21, 21, 8, 57, 758, DateTimeKind.Local).AddTicks(5021), 79, 35, new DateTime(2022, 5, 29, 8, 30, 14, 226, DateTimeKind.Local).AddTicks(2879), new DateTime(2021, 4, 3, 13, 41, 46, 605, DateTimeKind.Local).AddTicks(3736), 4, null, null, "Provident nostrum aperiam sed voluptas.", 162 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 37, new DateTime(2020, 9, 18, 6, 25, 28, 99, DateTimeKind.Local).AddTicks(2174), 79, 10, new DateTime(2021, 9, 30, 14, 15, 47, 63, DateTimeKind.Local).AddTicks(3019), new DateTime(2021, 5, 16, 21, 19, 13, 689, DateTimeKind.Local).AddTicks(6975), 1, null, null, "veniam", 297 },
                    { 166, new DateTime(2020, 10, 8, 0, 22, 1, 268, DateTimeKind.Local).AddTicks(2078), 52, 129, new DateTime(2021, 9, 12, 14, 14, 58, 196, DateTimeKind.Local).AddTicks(1919), new DateTime(2021, 7, 16, 13, 39, 42, 393, DateTimeKind.Local).AddTicks(9864), 4, null, null, "Ea officiis maxime delectus dolor optio tempore earum consequuntur.\nPariatur ad vel perferendis sit est nesciunt.\nNisi et voluptatem saepe labore.", 52 },
                    { 147, new DateTime(2021, 3, 30, 2, 55, 45, 85, DateTimeKind.Local).AddTicks(6412), 52, 109, new DateTime(2021, 9, 5, 6, 2, 22, 635, DateTimeKind.Local).AddTicks(5359), new DateTime(2021, 7, 7, 10, 40, 30, 710, DateTimeKind.Local).AddTicks(1832), 2, null, null, "Harum inventore aut veniam dolore assumenda aut explicabo nam. Corporis voluptatibus aspernatur aut perferendis sint et. Deleniti dolorum autem. Laudantium veritatis quod dolorum. Nam fuga non quia.", 270 },
                    { 107, new DateTime(2021, 5, 16, 21, 37, 37, 907, DateTimeKind.Local).AddTicks(6252), 44, 13, new DateTime(2021, 12, 3, 9, 35, 54, 779, DateTimeKind.Local).AddTicks(5018), new DateTime(2021, 7, 22, 21, 27, 55, 741, DateTimeKind.Local).AddTicks(2417), 5, null, null, "et", 55 },
                    { 118, new DateTime(2021, 4, 8, 3, 39, 33, 385, DateTimeKind.Local).AddTicks(4555), 90, 20, new DateTime(2021, 11, 21, 9, 26, 15, 366, DateTimeKind.Local).AddTicks(197), new DateTime(2021, 6, 16, 17, 11, 21, 346, DateTimeKind.Local).AddTicks(4722), 1, null, null, "Nostrum et quasi cum et corrupti animi aliquid eum voluptas.", 270 },
                    { 116, new DateTime(2020, 12, 12, 7, 3, 47, 280, DateTimeKind.Local).AddTicks(2736), 47, 32, new DateTime(2022, 3, 31, 7, 24, 45, 518, DateTimeKind.Local).AddTicks(5545), new DateTime(2021, 4, 21, 2, 45, 46, 219, DateTimeKind.Local).AddTicks(3986), 1, null, null, "magnam", 159 },
                    { 99, new DateTime(2020, 12, 15, 5, 42, 35, 404, DateTimeKind.Local).AddTicks(559), 71, 81, new DateTime(2022, 6, 20, 1, 40, 50, 403, DateTimeKind.Local).AddTicks(5095), new DateTime(2020, 10, 14, 0, 54, 9, 771, DateTimeKind.Local).AddTicks(4636), 5, null, null, "Ut velit sit laborum est sint consequatur.\nOfficia aut voluptatem ut.\nHarum labore placeat facere fugit eum quasi velit nihil eos.\nOdio nihil fuga aut velit velit id voluptatem quis aut.", 276 },
                    { 177, new DateTime(2021, 5, 31, 18, 36, 9, 768, DateTimeKind.Local).AddTicks(9428), 78, 114, new DateTime(2022, 6, 9, 4, 57, 34, 845, DateTimeKind.Local).AddTicks(7060), new DateTime(2021, 4, 17, 17, 9, 43, 625, DateTimeKind.Local).AddTicks(1961), 5, null, null, "Ducimus voluptate officia qui distinctio eveniet sit ut voluptatem.\nQuia ut illum hic nobis.\nSit eligendi earum et et et totam aut.\nBlanditiis error deserunt ipsam quam eos nulla.\nOmnis possimus rem iusto voluptatem.", 300 },
                    { 134, new DateTime(2020, 9, 15, 13, 26, 45, 48, DateTimeKind.Local).AddTicks(295), 55, 22, new DateTime(2022, 4, 14, 21, 50, 53, 427, DateTimeKind.Local).AddTicks(8531), new DateTime(2021, 4, 5, 14, 43, 59, 415, DateTimeKind.Local).AddTicks(6148), 4, null, null, "Velit quo inventore maxime optio voluptatem et aliquam facilis iste.", 46 },
                    { 35, new DateTime(2020, 11, 4, 9, 52, 50, 962, DateTimeKind.Local).AddTicks(7268), 55, 39, new DateTime(2021, 12, 16, 13, 19, 11, 21, DateTimeKind.Local).AddTicks(1547), new DateTime(2021, 5, 14, 7, 54, 26, 671, DateTimeKind.Local).AddTicks(6685), 1, null, null, "Porro dolores necessitatibus earum non sint. Quos consequatur excepturi asperiores et neque. Illo cum unde magni temporibus ad vero.", 277 },
                    { 192, new DateTime(2021, 3, 17, 3, 59, 23, 503, DateTimeKind.Local).AddTicks(8954), 37, 47, new DateTime(2021, 11, 16, 11, 49, 53, 656, DateTimeKind.Local).AddTicks(412), new DateTime(2020, 12, 25, 12, 14, 31, 38, DateTimeKind.Local).AddTicks(1699), 2, null, null, "Et officiis dolorum rerum.\nEt et numquam.\nDucimus perspiciatis aut neque omnis.\nVoluptas non consequatur qui blanditiis.\nQuisquam soluta labore vitae.\nAtque aut qui qui dolorem similique est et.", 219 },
                    { 74, new DateTime(2021, 1, 16, 15, 22, 52, 999, DateTimeKind.Local).AddTicks(8750), 37, 137, new DateTime(2021, 11, 22, 10, 32, 34, 734, DateTimeKind.Local).AddTicks(2600), new DateTime(2021, 4, 14, 1, 1, 24, 184, DateTimeKind.Local).AddTicks(2197), 1, null, null, "Cum sint et eius recusandae expedita odio.\nQui voluptatem molestiae et perferendis necessitatibus eum non.", 111 },
                    { 189, new DateTime(2020, 12, 18, 14, 17, 46, 949, DateTimeKind.Local).AddTicks(2548), 35, 138, new DateTime(2021, 9, 13, 6, 5, 45, 779, DateTimeKind.Local).AddTicks(3353), new DateTime(2020, 12, 9, 6, 11, 7, 541, DateTimeKind.Local).AddTicks(8616), 1, null, null, "Sint at quia ut.\nDolor inventore quaerat necessitatibus et numquam ut dolores quam rem.\nTenetur eligendi qui.\nSed ut dolor vel aut velit ut.", 119 },
                    { 191, new DateTime(2021, 6, 17, 14, 5, 50, 313, DateTimeKind.Local).AddTicks(1921), 58, 46, new DateTime(2022, 1, 15, 12, 45, 46, 858, DateTimeKind.Local).AddTicks(2982), new DateTime(2020, 12, 13, 17, 14, 44, 40, DateTimeKind.Local).AddTicks(5803), 2, null, null, "sit", 167 },
                    { 137, new DateTime(2021, 6, 13, 21, 19, 11, 113, DateTimeKind.Local).AddTicks(9622), 58, 32, new DateTime(2022, 6, 15, 7, 8, 39, 108, DateTimeKind.Local).AddTicks(7470), new DateTime(2021, 7, 9, 1, 39, 24, 305, DateTimeKind.Local).AddTicks(8895), 3, null, null, "Perferendis molestias provident quibusdam esse quas ad a. Qui inventore autem autem nulla sed. Architecto et voluptatem nihil eum.", 119 },
                    { 75, new DateTime(2020, 12, 29, 12, 49, 14, 551, DateTimeKind.Local).AddTicks(4459), 71, 45, new DateTime(2021, 12, 4, 9, 32, 37, 927, DateTimeKind.Local).AddTicks(4394), new DateTime(2021, 4, 22, 10, 56, 1, 551, DateTimeKind.Local).AddTicks(5578), 2, null, null, "Veritatis vel laboriosam consequuntur. Aperiam id quo aliquid eligendi voluptas ea dolores. Non est quae eum aut quas.", 33 },
                    { 156, new DateTime(2020, 11, 23, 9, 31, 23, 626, DateTimeKind.Local).AddTicks(2892), 74, 55, new DateTime(2022, 4, 29, 11, 40, 36, 488, DateTimeKind.Local).AddTicks(9317), new DateTime(2020, 12, 7, 13, 38, 50, 759, DateTimeKind.Local).AddTicks(2852), 3, null, null, "nostrum", 109 },
                    { 128, new DateTime(2020, 12, 5, 15, 27, 35, 429, DateTimeKind.Local).AddTicks(5406), 74, 88, new DateTime(2021, 9, 27, 10, 0, 32, 46, DateTimeKind.Local).AddTicks(8564), new DateTime(2021, 1, 24, 11, 46, 54, 290, DateTimeKind.Local).AddTicks(3334), 4, null, null, "quasi", 18 },
                    { 14, new DateTime(2021, 1, 24, 3, 49, 19, 13, DateTimeKind.Local).AddTicks(4911), 74, 2, new DateTime(2021, 11, 18, 15, 55, 25, 714, DateTimeKind.Local).AddTicks(7), new DateTime(2021, 4, 20, 20, 56, 19, 162, DateTimeKind.Local).AddTicks(4136), 1, null, null, "Similique maxime id itaque minus labore iusto consequatur. Amet laudantium consequuntur ad sed facilis. Odit sunt qui eos aut aut rerum sed eos. Voluptas quia fuga autem autem. Provident fugit quia unde et.", 74 },
                    { 180, new DateTime(2021, 5, 12, 15, 42, 13, 145, DateTimeKind.Local).AddTicks(6003), 2, 5, new DateTime(2022, 6, 13, 19, 49, 28, 293, DateTimeKind.Local).AddTicks(5089), new DateTime(2021, 6, 7, 12, 47, 3, 128, DateTimeKind.Local).AddTicks(2937), 4, null, null, "Esse iste explicabo eos.", 46 },
                    { 172, new DateTime(2021, 8, 10, 23, 1, 20, 470, DateTimeKind.Local).AddTicks(6353), 2, 28, new DateTime(2022, 2, 11, 10, 8, 33, 348, DateTimeKind.Local).AddTicks(3475), new DateTime(2021, 2, 27, 8, 8, 35, 736, DateTimeKind.Local).AddTicks(3269), 1, null, null, "Commodi ullam fuga hic nisi officiis itaque ut et.", 56 },
                    { 38, new DateTime(2021, 6, 27, 7, 55, 38, 452, DateTimeKind.Local).AddTicks(3595), 2, 96, new DateTime(2021, 12, 20, 9, 15, 28, 83, DateTimeKind.Local).AddTicks(5178), new DateTime(2021, 7, 29, 4, 45, 51, 939, DateTimeKind.Local).AddTicks(8269), 3, null, null, "Perspiciatis placeat distinctio aut expedita rerum.", 207 },
                    { 80, new DateTime(2021, 7, 13, 16, 54, 16, 961, DateTimeKind.Local).AddTicks(7630), 1, 75, new DateTime(2022, 8, 13, 8, 30, 19, 925, DateTimeKind.Local).AddTicks(5184), new DateTime(2020, 9, 30, 21, 29, 42, 605, DateTimeKind.Local).AddTicks(8728), 1, null, null, "aperiam", 29 },
                    { 169, new DateTime(2020, 12, 14, 18, 42, 49, 178, DateTimeKind.Local).AddTicks(4479), 71, 143, new DateTime(2022, 8, 19, 22, 26, 39, 510, DateTimeKind.Local).AddTicks(9217), new DateTime(2021, 7, 19, 16, 18, 56, 508, DateTimeKind.Local).AddTicks(7544), 1, null, null, "officiis", 297 },
                    { 115, new DateTime(2020, 9, 1, 21, 0, 30, 225, DateTimeKind.Local).AddTicks(4034), 71, 96, new DateTime(2021, 12, 30, 2, 51, 33, 701, DateTimeKind.Local).AddTicks(691), new DateTime(2021, 6, 30, 14, 9, 15, 433, DateTimeKind.Local).AddTicks(9049), 5, null, null, "Voluptatem dolore natus optio.", 48 },
                    { 133, new DateTime(2020, 10, 8, 6, 5, 34, 88, DateTimeKind.Local).AddTicks(3415), 74, 24, new DateTime(2021, 9, 16, 9, 5, 35, 540, DateTimeKind.Local).AddTicks(6858), new DateTime(2021, 6, 13, 20, 57, 4, 300, DateTimeKind.Local).AddTicks(9104), 2, null, null, "aliquid", 113 },
                    { 22, new DateTime(2021, 1, 15, 5, 5, 54, 531, DateTimeKind.Local).AddTicks(4155), 72, 32, new DateTime(2022, 3, 22, 13, 30, 43, 309, DateTimeKind.Local).AddTicks(3303), new DateTime(2020, 10, 12, 14, 2, 46, 240, DateTimeKind.Local).AddTicks(4406), 3, null, null, "Aut est sunt qui nihil.", 194 },
                    { 70, new DateTime(2020, 11, 10, 2, 23, 26, 809, DateTimeKind.Local).AddTicks(4119), 67, 80, new DateTime(2022, 5, 12, 18, 12, 21, 479, DateTimeKind.Local).AddTicks(4630), new DateTime(2021, 3, 12, 22, 10, 59, 230, DateTimeKind.Local).AddTicks(6956), 4, null, null, "Quam iste id unde quam laborum quam quos. Numquam veniam aut aut nemo veniam incidunt voluptatibus. Unde sint aut voluptates vel commodi.", 263 },
                    { 139, new DateTime(2021, 3, 24, 1, 24, 37, 752, DateTimeKind.Local).AddTicks(585), 89, 104, new DateTime(2021, 9, 26, 15, 46, 1, 9, DateTimeKind.Local).AddTicks(9956), new DateTime(2021, 8, 18, 6, 54, 9, 504, DateTimeKind.Local).AddTicks(507), 5, null, null, "Officia voluptatibus aut consequatur explicabo quis ex et.", 48 },
                    { 48, new DateTime(2021, 3, 23, 13, 22, 7, 703, DateTimeKind.Local).AddTicks(9009), 60, 72, new DateTime(2022, 5, 20, 23, 52, 48, 654, DateTimeKind.Local).AddTicks(7359), new DateTime(2020, 12, 23, 7, 19, 7, 46, DateTimeKind.Local).AddTicks(5345), 4, null, null, "sed", 252 },
                    { 47, new DateTime(2021, 1, 3, 12, 32, 3, 110, DateTimeKind.Local).AddTicks(7705), 60, 115, new DateTime(2021, 9, 20, 19, 7, 24, 990, DateTimeKind.Local).AddTicks(9681), new DateTime(2021, 3, 10, 13, 46, 44, 832, DateTimeKind.Local).AddTicks(5132), 5, null, null, "Est ad provident et porro expedita voluptas quia vel sed.\nDolorum et dolores cupiditate facilis.\nQuas aut dolore minima est architecto.\nAlias ipsa molestiae veniam iste dolorem blanditiis magnam voluptatum incidunt.\nPariatur aut veniam eligendi est voluptatibus.\nEum in sapiente nostrum ratione tenetur nemo.", 197 },
                    { 4, new DateTime(2020, 9, 15, 23, 28, 21, 388, DateTimeKind.Local).AddTicks(8043), 60, 126, new DateTime(2021, 12, 15, 5, 18, 39, 38, DateTimeKind.Local).AddTicks(436), new DateTime(2021, 8, 17, 17, 39, 53, 770, DateTimeKind.Local).AddTicks(4769), 3, null, null, "sapiente", 47 },
                    { 197, new DateTime(2021, 7, 5, 8, 7, 8, 527, DateTimeKind.Local).AddTicks(1644), 22, 20, new DateTime(2022, 5, 2, 0, 8, 39, 312, DateTimeKind.Local).AddTicks(441), new DateTime(2020, 11, 20, 18, 46, 45, 303, DateTimeKind.Local).AddTicks(4969), 3, null, null, "dolor", 196 },
                    { 85, new DateTime(2021, 3, 25, 4, 24, 46, 261, DateTimeKind.Local).AddTicks(6844), 22, 52, new DateTime(2022, 8, 22, 3, 20, 42, 582, DateTimeKind.Local).AddTicks(6754), new DateTime(2021, 1, 29, 23, 32, 59, 638, DateTimeKind.Local).AddTicks(1885), 1, null, null, "Nemo temporibus est reprehenderit adipisci qui reprehenderit.", 190 },
                    { 17, new DateTime(2020, 12, 5, 5, 43, 32, 680, DateTimeKind.Local).AddTicks(665), 22, 150, new DateTime(2022, 5, 7, 23, 14, 11, 154, DateTimeKind.Local).AddTicks(2692), new DateTime(2021, 8, 4, 4, 33, 54, 13, DateTimeKind.Local).AddTicks(7765), 5, null, null, "Magni mollitia amet possimus.\nArchitecto commodi cumque fugit totam.\nDignissimos maxime quae magnam est est dolor temporibus molestiae.\nEveniet aspernatur qui minus consequatur totam dolor nisi fugit.\nVoluptatem est nemo ex enim velit aut quisquam.", 219 },
                    { 162, new DateTime(2021, 3, 8, 14, 34, 53, 946, DateTimeKind.Local).AddTicks(4464), 20, 124, new DateTime(2021, 12, 28, 8, 59, 42, 546, DateTimeKind.Local).AddTicks(3731), new DateTime(2021, 8, 23, 7, 35, 59, 933, DateTimeKind.Local).AddTicks(571), 5, null, null, "Facilis omnis omnis magnam enim sed qui tempore et totam.", 159 },
                    { 59, new DateTime(2021, 5, 7, 13, 44, 50, 512, DateTimeKind.Local).AddTicks(5132), 60, 38, new DateTime(2022, 5, 28, 16, 14, 13, 887, DateTimeKind.Local).AddTicks(8825), new DateTime(2020, 11, 9, 14, 51, 6, 289, DateTimeKind.Local).AddTicks(7055), 5, null, null, "Veniam sunt aut dolorem doloribus natus natus.", 297 },
                    { 105, new DateTime(2021, 5, 29, 13, 50, 58, 118, DateTimeKind.Local).AddTicks(1598), 20, 57, new DateTime(2022, 5, 30, 1, 35, 46, 931, DateTimeKind.Local).AddTicks(2530), new DateTime(2021, 2, 27, 8, 1, 15, 329, DateTimeKind.Local).AddTicks(74), 1, null, null, "Recusandae iste fuga. Et vitae dicta perferendis quis quae suscipit tempore et doloribus. Laborum nihil qui eum beatae ut. Ut nisi et neque repellat accusamus unde iste deserunt. Facere ut tempora mollitia tempora sequi expedita.", 266 },
                    { 34, new DateTime(2021, 5, 24, 14, 5, 44, 482, DateTimeKind.Local).AddTicks(4159), 63, 3, new DateTime(2021, 12, 6, 23, 16, 2, 157, DateTimeKind.Local).AddTicks(170), new DateTime(2021, 7, 30, 15, 21, 30, 556, DateTimeKind.Local).AddTicks(5756), 1, null, null, "Facilis voluptatem aliquam esse debitis voluptas et corrupti aut. Occaecati delectus eos et voluptatem quia omnis. Quisquam ratione veniam officia facilis nihil veniam sunt corrupti. Cum occaecati quia.", 82 },
                    { 12, new DateTime(2020, 10, 16, 10, 21, 48, 340, DateTimeKind.Local).AddTicks(7580), 8, 127, new DateTime(2021, 12, 11, 11, 44, 3, 118, DateTimeKind.Local).AddTicks(3831), new DateTime(2020, 10, 5, 18, 50, 18, 125, DateTimeKind.Local).AddTicks(8815), 3, null, null, "Aut dolor ut accusantium incidunt quaerat sequi.", 160 },
                    { 96, new DateTime(2020, 12, 15, 0, 18, 59, 991, DateTimeKind.Local).AddTicks(557), 24, 135, new DateTime(2022, 1, 14, 17, 6, 22, 132, DateTimeKind.Local).AddTicks(5684), new DateTime(2021, 3, 27, 17, 1, 53, 974, DateTimeKind.Local).AddTicks(5364), 5, null, null, "Officia consequatur quisquam.", 227 },
                    { 40, new DateTime(2020, 11, 12, 5, 27, 18, 917, DateTimeKind.Local).AddTicks(478), 24, 101, new DateTime(2022, 8, 11, 20, 11, 23, 375, DateTimeKind.Local).AddTicks(5283), new DateTime(2020, 12, 18, 2, 9, 37, 600, DateTimeKind.Local).AddTicks(6934), 3, null, null, "Delectus molestiae quos et veritatis. Exercitationem enim et. Consequatur at consequatur voluptatem beatae possimus. Praesentium in provident ut autem adipisci repellat eum. Vitae beatae natus quae minima fugiat voluptatibus.", 124 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 154, new DateTime(2021, 3, 20, 11, 25, 15, 258, DateTimeKind.Local).AddTicks(3247), 14, 54, new DateTime(2022, 4, 19, 20, 18, 44, 869, DateTimeKind.Local).AddTicks(706), new DateTime(2021, 5, 25, 16, 19, 49, 70, DateTimeKind.Local).AddTicks(2567), 2, null, null, "excepturi", 24 },
                    { 143, new DateTime(2021, 2, 23, 21, 0, 2, 468, DateTimeKind.Local).AddTicks(3714), 14, 105, new DateTime(2022, 7, 28, 3, 22, 6, 39, DateTimeKind.Local).AddTicks(7625), new DateTime(2021, 2, 27, 0, 44, 57, 856, DateTimeKind.Local).AddTicks(8181), 2, null, null, "Ad id vel dolorum enim.\nDolor distinctio aut corrupti.\nCulpa consequatur repellendus amet labore autem voluptate.\nVoluptatem repellendus velit itaque temporibus quasi quo error et commodi.\nVoluptate officia qui velit ad et consequatur repudiandae deleniti quia.", 295 },
                    { 127, new DateTime(2021, 7, 15, 10, 55, 32, 11, DateTimeKind.Local).AddTicks(3619), 14, 73, new DateTime(2021, 12, 7, 10, 29, 22, 704, DateTimeKind.Local).AddTicks(452), new DateTime(2021, 6, 16, 18, 50, 43, 832, DateTimeKind.Local).AddTicks(7088), 2, null, null, "Et beatae est.\nAd qui voluptatem asperiores nobis animi pariatur explicabo non vitae.\nAut commodi voluptatibus quidem autem nobis blanditiis.", 18 },
                    { 53, new DateTime(2021, 6, 13, 21, 49, 22, 503, DateTimeKind.Local).AddTicks(7971), 20, 149, new DateTime(2022, 2, 20, 5, 15, 26, 174, DateTimeKind.Local).AddTicks(6990), new DateTime(2021, 7, 31, 5, 7, 34, 160, DateTimeKind.Local).AddTicks(2793), 4, null, null, "Laudantium mollitia laborum.\nSit sint laboriosam voluptatem laudantium dolorum ipsum sapiente deserunt modi.\nPariatur nemo sint sint dolor consequuntur natus dolor est.\nAut quisquam rerum.\nQuisquam aut minus ipsa quaerat libero eius nulla.\nAssumenda mollitia rerum maiores assumenda distinctio qui a.", 74 },
                    { 138, new DateTime(2021, 4, 5, 3, 16, 50, 895, DateTimeKind.Local).AddTicks(8064), 84, 77, new DateTime(2021, 12, 17, 6, 52, 7, 224, DateTimeKind.Local).AddTicks(5907), new DateTime(2021, 7, 22, 9, 11, 9, 554, DateTimeKind.Local).AddTicks(7615), 5, null, null, "Asperiores rerum aliquid. Molestiae dolores quia at recusandae et totam sit nam. Ipsam possimus labore sint.", 226 },
                    { 119, new DateTime(2021, 1, 5, 11, 20, 5, 214, DateTimeKind.Local).AddTicks(7278), 60, 49, new DateTime(2022, 7, 1, 13, 51, 36, 641, DateTimeKind.Local).AddTicks(219), new DateTime(2020, 11, 9, 11, 37, 23, 141, DateTimeKind.Local).AddTicks(6699), 3, null, null, "Delectus vel magni quisquam facere dolore ipsa sit magni.", 196 },
                    { 44, new DateTime(2021, 5, 31, 0, 44, 29, 39, DateTimeKind.Local).AddTicks(1336), 6, 12, new DateTime(2022, 4, 29, 11, 39, 17, 172, DateTimeKind.Local).AddTicks(2228), new DateTime(2021, 6, 5, 20, 56, 27, 229, DateTimeKind.Local).AddTicks(7358), 1, null, null, "Sequi deserunt esse voluptatum quos quo maxime aspernatur.\nDolor incidunt est unde.\nAperiam assumenda laborum adipisci.\nQuas illum aut necessitatibus iure mollitia voluptatem repellat occaecati et.", 103 },
                    { 168, new DateTime(2021, 4, 20, 1, 14, 6, 180, DateTimeKind.Local).AddTicks(3767), 19, 55, new DateTime(2021, 11, 1, 9, 11, 41, 968, DateTimeKind.Local).AddTicks(4356), new DateTime(2020, 12, 15, 21, 5, 1, 793, DateTimeKind.Local).AddTicks(3164), 4, null, null, "Pariatur quis corrupti id numquam et officia totam. Eos pariatur dolores eum praesentium reprehenderit dignissimos numquam. Placeat cupiditate odio porro et suscipit. Praesentium sapiente sed autem qui impedit.", 49 },
                    { 163, new DateTime(2021, 7, 7, 2, 47, 13, 409, DateTimeKind.Local).AddTicks(2201), 19, 72, new DateTime(2021, 12, 5, 7, 8, 57, 193, DateTimeKind.Local).AddTicks(8178), new DateTime(2021, 1, 23, 2, 26, 14, 761, DateTimeKind.Local).AddTicks(2511), 5, null, null, "Qui natus odit et et aut aut rerum alias.", 55 },
                    { 125, new DateTime(2021, 4, 19, 10, 14, 23, 493, DateTimeKind.Local).AddTicks(5785), 19, 139, new DateTime(2022, 1, 20, 6, 40, 28, 337, DateTimeKind.Local).AddTicks(2041), new DateTime(2020, 12, 25, 5, 10, 40, 726, DateTimeKind.Local).AddTicks(5920), 1, null, null, "Eius aut reprehenderit sint odit quos est.", 33 },
                    { 101, new DateTime(2021, 3, 18, 20, 3, 11, 100, DateTimeKind.Local).AddTicks(2806), 19, 19, new DateTime(2022, 7, 1, 22, 18, 17, 576, DateTimeKind.Local).AddTicks(1331), new DateTime(2021, 7, 21, 1, 41, 20, 360, DateTimeKind.Local).AddTicks(674), 4, null, null, "Fuga et provident qui quis in eos voluptatum aut.", 264 },
                    { 11, new DateTime(2021, 6, 24, 20, 53, 50, 598, DateTimeKind.Local).AddTicks(728), 19, 147, new DateTime(2022, 3, 27, 1, 33, 45, 422, DateTimeKind.Local).AddTicks(962), new DateTime(2020, 9, 26, 17, 20, 39, 718, DateTimeKind.Local).AddTicks(4234), 1, null, null, "Aut recusandae est quidem.", 51 },
                    { 194, new DateTime(2021, 1, 19, 2, 53, 52, 670, DateTimeKind.Local).AddTicks(4563), 41, 131, new DateTime(2021, 10, 12, 14, 13, 30, 347, DateTimeKind.Local).AddTicks(2268), new DateTime(2020, 10, 16, 14, 31, 44, 557, DateTimeKind.Local).AddTicks(6257), 1, null, null, "Aspernatur architecto ut.\nReiciendis quis explicabo voluptas mollitia.\nEveniet sunt inventore et et voluptatem delectus.", 239 },
                    { 159, new DateTime(2021, 6, 22, 17, 39, 19, 382, DateTimeKind.Local).AddTicks(9877), 41, 52, new DateTime(2022, 1, 26, 7, 33, 7, 27, DateTimeKind.Local).AddTicks(6149), new DateTime(2021, 4, 4, 17, 22, 12, 255, DateTimeKind.Local).AddTicks(3080), 1, null, null, "Voluptatem qui ullam vero nihil corrupti repellendus dolor.", 144 },
                    { 145, new DateTime(2020, 12, 28, 22, 58, 11, 755, DateTimeKind.Local).AddTicks(6175), 5, 120, new DateTime(2021, 11, 7, 17, 3, 41, 804, DateTimeKind.Local).AddTicks(6762), new DateTime(2021, 1, 31, 3, 18, 12, 674, DateTimeKind.Local).AddTicks(7891), 4, null, null, "Natus nam recusandae ullam fugit vitae voluptates. Dolorem molestias nobis officiis laudantium non. Vel quis veniam ut quo et quas. Et illo ut quasi illum est dolorum. Cumque omnis commodi sint.", 193 },
                    { 18, new DateTime(2021, 6, 3, 10, 4, 41, 170, DateTimeKind.Local).AddTicks(6438), 57, 4, new DateTime(2022, 2, 10, 18, 38, 45, 273, DateTimeKind.Local).AddTicks(5693), new DateTime(2021, 2, 27, 13, 49, 40, 58, DateTimeKind.Local).AddTicks(857), 3, null, null, "Voluptates quasi voluptate laboriosam qui vel reprehenderit.", 86 },
                    { 183, new DateTime(2021, 4, 23, 20, 8, 30, 87, DateTimeKind.Local).AddTicks(5533), 49, 6, new DateTime(2022, 4, 12, 8, 0, 12, 199, DateTimeKind.Local).AddTicks(3102), new DateTime(2021, 8, 20, 10, 50, 7, 218, DateTimeKind.Local).AddTicks(2458), 5, null, null, "Nostrum et repudiandae quidem veritatis quod reprehenderit eligendi voluptate. Ad repudiandae illum illum. Saepe sunt ut. Voluptatem qui vel dolorum soluta delectus a aut. Nisi repudiandae perspiciatis perferendis doloribus fugit placeat. Minus odit ex.", 144 },
                    { 155, new DateTime(2021, 6, 16, 23, 5, 35, 701, DateTimeKind.Local).AddTicks(951), 49, 84, new DateTime(2021, 10, 13, 2, 16, 7, 661, DateTimeKind.Local).AddTicks(5872), new DateTime(2020, 10, 28, 12, 2, 16, 896, DateTimeKind.Local).AddTicks(9137), 3, null, null, "Impedit voluptates laborum repellat sit neque ipsa est. Illo unde eum. Aperiam incidunt molestias.", 9 },
                    { 32, new DateTime(2020, 9, 29, 21, 6, 44, 406, DateTimeKind.Local).AddTicks(2709), 49, 89, new DateTime(2022, 1, 1, 23, 27, 42, 446, DateTimeKind.Local).AddTicks(9841), new DateTime(2021, 7, 22, 7, 36, 10, 884, DateTimeKind.Local).AddTicks(25), 3, null, null, "Maxime voluptatem mollitia excepturi error ex sapiente qui.", 202 },
                    { 73, new DateTime(2021, 8, 25, 20, 20, 12, 424, DateTimeKind.Local).AddTicks(8430), 68, 98, new DateTime(2021, 11, 22, 20, 9, 27, 883, DateTimeKind.Local).AddTicks(4623), new DateTime(2020, 12, 24, 8, 55, 10, 302, DateTimeKind.Local).AddTicks(8862), 1, null, null, "Autem quis recusandae excepturi quod autem facere a et aut. Recusandae qui sed corporis sint officia sed ut. Nisi ad quo quaerat repellat et sequi illum ullam. Ipsum at repellendus distinctio nihil nostrum. Quia consequatur fuga. Odit consequatur quia accusamus reiciendis minus.", 265 },
                    { 113, new DateTime(2020, 12, 31, 1, 21, 11, 584, DateTimeKind.Local).AddTicks(6934), 6, 29, new DateTime(2021, 11, 6, 18, 27, 14, 808, DateTimeKind.Local).AddTicks(2368), new DateTime(2020, 9, 7, 1, 7, 0, 902, DateTimeKind.Local).AddTicks(5263), 3, null, null, "Error nostrum cum voluptates ea qui consequatur error et ratione.", 18 },
                    { 82, new DateTime(2020, 9, 30, 8, 19, 58, 755, DateTimeKind.Local).AddTicks(2798), 6, 131, new DateTime(2022, 3, 24, 16, 46, 27, 646, DateTimeKind.Local).AddTicks(1901), new DateTime(2021, 2, 13, 6, 31, 24, 926, DateTimeKind.Local).AddTicks(3178), 2, null, null, "Cum consequuntur officia sit dicta et ipsa quo. Unde vero a odio rem iure amet reiciendis. Voluptas culpa animi. Nostrum et ex mollitia. Tenetur dolor aut dignissimos et ipsam dolores commodi.", 119 },
                    { 54, new DateTime(2020, 10, 13, 18, 34, 25, 875, DateTimeKind.Local).AddTicks(9063), 6, 148, new DateTime(2022, 7, 26, 17, 38, 47, 270, DateTimeKind.Local).AddTicks(3200), new DateTime(2021, 2, 18, 1, 19, 4, 25, DateTimeKind.Local).AddTicks(5057), 2, null, null, "Illum voluptas recusandae numquam quibusdam qui nihil maxime laborum iusto.\nSuscipit omnis sunt consequatur mollitia ratione voluptatem ut eos temporibus.\nHic architecto animi.\nEa id et aut quae consequatur nostrum voluptas.\nConsequatur omnis iste et amet error.\nAb iure aperiam.", 213 },
                    { 190, new DateTime(2020, 10, 23, 6, 40, 59, 968, DateTimeKind.Local).AddTicks(2580), 49, 135, new DateTime(2022, 6, 8, 3, 47, 13, 55, DateTimeKind.Local).AddTicks(3502), new DateTime(2020, 9, 14, 12, 44, 59, 211, DateTimeKind.Local).AddTicks(8332), 1, null, null, "Est et odio qui consequatur est neque officia aliquid. Est assumenda voluptas nihil ad quis accusamus. Nobis quasi reprehenderit. Cupiditate minima consequatur perspiciatis.", 38 },
                    { 62, new DateTime(2021, 5, 23, 16, 39, 25, 780, DateTimeKind.Local).AddTicks(1672), 84, 68, new DateTime(2022, 8, 8, 7, 2, 42, 855, DateTimeKind.Local).AddTicks(2299), new DateTime(2020, 10, 6, 8, 19, 41, 748, DateTimeKind.Local).AddTicks(7855), 1, null, null, "Suscipit inventore voluptatibus porro nulla sunt ab rerum atque.", 57 },
                    { 63, new DateTime(2020, 9, 25, 10, 20, 23, 486, DateTimeKind.Local).AddTicks(5175), 45, 34, new DateTime(2022, 8, 8, 13, 23, 55, 330, DateTimeKind.Local).AddTicks(2779), new DateTime(2020, 11, 2, 2, 46, 8, 421, DateTimeKind.Local).AddTicks(8679), 1, null, null, "Est quisquam velit sunt reiciendis quo qui. Culpa perferendis voluptas consequuntur. Suscipit rerum veritatis sit nostrum dolorem.", 239 },
                    { 29, new DateTime(2021, 7, 2, 11, 2, 29, 520, DateTimeKind.Local).AddTicks(818), 85, 134, new DateTime(2021, 11, 18, 21, 43, 59, 741, DateTimeKind.Local).AddTicks(1033), new DateTime(2020, 9, 15, 16, 38, 32, 520, DateTimeKind.Local).AddTicks(5656), 1, null, null, "Voluptas quia dolorum doloremque.", 9 },
                    { 61, new DateTime(2021, 4, 1, 4, 2, 39, 934, DateTimeKind.Local).AddTicks(4369), 80, 125, new DateTime(2022, 2, 12, 0, 32, 17, 983, DateTimeKind.Local).AddTicks(8266), new DateTime(2021, 7, 1, 18, 50, 11, 970, DateTimeKind.Local).AddTicks(2252), 2, null, null, "Facilis maxime ut rerum. Esse et repellendus laudantium est. Ducimus fugiat necessitatibus et asperiores quis ipsa pariatur sunt voluptatibus. Quibusdam dignissimos in iure ad aut voluptas et repellat. Magnam maxime repudiandae vel.", 82 },
                    { 167, new DateTime(2020, 10, 7, 8, 19, 8, 183, DateTimeKind.Local).AddTicks(2505), 39, 22, new DateTime(2022, 4, 24, 7, 36, 22, 691, DateTimeKind.Local).AddTicks(7169), new DateTime(2020, 10, 9, 3, 45, 29, 841, DateTimeKind.Local).AddTicks(2392), 1, null, null, "Cupiditate quis sunt et consequatur qui.", 159 },
                    { 69, new DateTime(2020, 10, 17, 9, 9, 6, 284, DateTimeKind.Local).AddTicks(168), 85, 97, new DateTime(2022, 3, 15, 23, 14, 40, 64, DateTimeKind.Local).AddTicks(2630), new DateTime(2021, 8, 13, 1, 47, 56, 29, DateTimeKind.Local).AddTicks(4741), 2, null, null, "Qui atque rerum fuga eaque error provident quos.", 50 },
                    { 131, new DateTime(2021, 5, 11, 1, 28, 53, 267, DateTimeKind.Local).AddTicks(396), 86, 98, new DateTime(2022, 3, 23, 6, 10, 53, 979, DateTimeKind.Local).AddTicks(2558), new DateTime(2020, 9, 4, 5, 58, 31, 371, DateTimeKind.Local).AddTicks(9362), 4, null, null, "Et iusto voluptatem. Dicta reprehenderit earum dolor ducimus est. Placeat et explicabo.", 277 },
                    { 93, new DateTime(2021, 1, 8, 13, 49, 49, 106, DateTimeKind.Local).AddTicks(6159), 85, 49, new DateTime(2022, 6, 29, 1, 39, 3, 693, DateTimeKind.Local).AddTicks(815), new DateTime(2021, 8, 21, 21, 8, 35, 262, DateTimeKind.Local).AddTicks(5690), 2, null, null, "Est corporis perferendis libero est quas repellendus ea. Saepe aut et temporibus ipsum ab placeat itaque in. Quia provident non unde perspiciatis qui libero dolor. Sunt omnis cupiditate. Nesciunt ad dolores tenetur et ut voluptas dolorem. Non eum laboriosam.", 182 },
                    { 78, new DateTime(2021, 1, 21, 21, 48, 56, 853, DateTimeKind.Local).AddTicks(6066), 48, 142, new DateTime(2022, 1, 22, 20, 28, 50, 879, DateTimeKind.Local).AddTicks(7968), new DateTime(2021, 6, 8, 14, 59, 18, 968, DateTimeKind.Local).AddTicks(1607), 3, null, null, "Perspiciatis eaque aut necessitatibus est velit non et.\nNostrum laboriosam cumque pariatur.\nUt aliquid sit sint laborum.\nConsequatur culpa sed voluptates rerum.", 77 },
                    { 50, new DateTime(2020, 12, 14, 5, 45, 0, 694, DateTimeKind.Local).AddTicks(8847), 39, 125, new DateTime(2022, 2, 18, 2, 57, 42, 705, DateTimeKind.Local).AddTicks(7979), new DateTime(2021, 4, 7, 13, 25, 46, 150, DateTimeKind.Local).AddTicks(3409), 4, null, null, "Nisi tempore eaque quo saepe ut aut voluptates.", 182 },
                    { 132, new DateTime(2021, 4, 16, 14, 50, 51, 49, DateTimeKind.Local).AddTicks(7628), 38, 91, new DateTime(2021, 11, 22, 11, 18, 4, 268, DateTimeKind.Local).AddTicks(6766), new DateTime(2020, 11, 26, 21, 53, 12, 714, DateTimeKind.Local).AddTicks(6562), 1, null, null, "Magnam rem tempora ipsum sequi asperiores qui. Labore et nisi inventore consequatur qui aliquam est. Esse vitae iusto blanditiis aspernatur et iusto et. Inventore maiores voluptates dolor quia est quibusdam facere eos. Dolorem est voluptatem qui nostrum corporis excepturi.", 49 },
                    { 84, new DateTime(2021, 1, 5, 10, 37, 47, 71, DateTimeKind.Local).AddTicks(6059), 38, 72, new DateTime(2021, 10, 6, 0, 21, 26, 502, DateTimeKind.Local).AddTicks(1911), new DateTime(2021, 5, 7, 23, 49, 15, 265, DateTimeKind.Local).AddTicks(5104), 2, null, null, "Sunt non soluta aut quia.", 202 },
                    { 108, new DateTime(2020, 11, 13, 13, 37, 51, 389, DateTimeKind.Local).AddTicks(1754), 86, 20, new DateTime(2021, 9, 20, 5, 31, 41, 305, DateTimeKind.Local).AddTicks(7040), new DateTime(2021, 3, 5, 3, 31, 28, 888, DateTimeKind.Local).AddTicks(6943), 5, null, null, "Et et voluptas rerum iure omnis dolorem culpa qui.", 259 },
                    { 174, new DateTime(2021, 4, 23, 16, 16, 57, 341, DateTimeKind.Local).AddTicks(8791), 89, 122, new DateTime(2022, 4, 25, 22, 23, 18, 230, DateTimeKind.Local).AddTicks(7543), new DateTime(2021, 8, 25, 21, 57, 20, 30, DateTimeKind.Local).AddTicks(4332), 2, null, null, "necessitatibus", 126 },
                    { 60, new DateTime(2020, 11, 14, 1, 59, 10, 365, DateTimeKind.Local).AddTicks(4974), 36, 55, new DateTime(2022, 7, 12, 13, 58, 46, 850, DateTimeKind.Local).AddTicks(5009), new DateTime(2020, 10, 5, 22, 37, 47, 246, DateTimeKind.Local).AddTicks(6843), 1, null, null, "cumque", 266 },
                    { 83, new DateTime(2021, 8, 7, 9, 3, 3, 499, DateTimeKind.Local).AddTicks(5999), 88, 74, new DateTime(2021, 10, 11, 17, 54, 27, 781, DateTimeKind.Local).AddTicks(3135), new DateTime(2021, 7, 26, 1, 56, 50, 672, DateTimeKind.Local).AddTicks(546), 5, null, null, "Voluptatem neque blanditiis corporis non quia doloribus aut.", 266 },
                    { 188, new DateTime(2021, 1, 14, 9, 8, 17, 123, DateTimeKind.Local).AddTicks(33), 36, 37, new DateTime(2021, 10, 5, 21, 55, 37, 551, DateTimeKind.Local).AddTicks(1139), new DateTime(2020, 12, 11, 6, 37, 20, 922, DateTimeKind.Local).AddTicks(1930), 5, null, null, "et", 266 },
                    { 30, new DateTime(2021, 7, 6, 10, 30, 25, 341, DateTimeKind.Local).AddTicks(5278), 85, 54, new DateTime(2021, 10, 9, 3, 11, 49, 301, DateTimeKind.Local).AddTicks(3984), new DateTime(2020, 12, 23, 23, 28, 36, 217, DateTimeKind.Local).AddTicks(4474), 1, null, null, "Et ducimus provident quod voluptas quidem pariatur temporibus a adipisci.\nConsequatur sed atque quod velit reprehenderit.\nEius quam velit perferendis ut sit.", 278 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarId", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarsCarId", "UserCarsUserId", "UserDescription", "UserId" },
                values: new object[,]
                {
                    { 8, new DateTime(2021, 5, 15, 9, 38, 13, 476, DateTimeKind.Local).AddTicks(4592), 88, 126, new DateTime(2022, 8, 3, 18, 29, 30, 759, DateTimeKind.Local).AddTicks(155), new DateTime(2021, 4, 24, 7, 20, 56, 499, DateTimeKind.Local).AddTicks(2891), 2, null, null, "Asperiores vel non consequatur illo aperiam. Voluptatem vel tempora tempore quo ducimus reiciendis. Voluptatem ipsam tenetur et enim.", 290 },
                    { 45, new DateTime(2021, 3, 4, 8, 34, 42, 351, DateTimeKind.Local).AddTicks(691), 82, 74, new DateTime(2022, 8, 17, 0, 6, 2, 486, DateTimeKind.Local).AddTicks(5458), new DateTime(2021, 3, 7, 8, 32, 59, 900, DateTimeKind.Local).AddTicks(1688), 1, null, null, "Ipsa aperiam eum non saepe ut aut.", 296 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "CarId", "UserId" },
                values: new object[,]
                {
                    { 30, 264 },
                    { 92, 168 },
                    { 68, 218 },
                    { 6, 65 },
                    { 16, 236 },
                    { 47, 86 },
                    { 46, 24 },
                    { 48, 167 },
                    { 71, 52 },
                    { 86, 236 },
                    { 50, 269 },
                    { 33, 104 },
                    { 73, 67 },
                    { 34, 103 },
                    { 83, 67 },
                    { 52, 300 },
                    { 91, 18 },
                    { 89, 144 },
                    { 76, 119 },
                    { 25, 86 },
                    { 93, 65 },
                    { 41, 95 },
                    { 27, 20 },
                    { 57, 279 },
                    { 59, 57 },
                    { 80, 299 },
                    { 49, 266 },
                    { 67, 114 },
                    { 3, 281 },
                    { 1, 20 },
                    { 23, 234 },
                    { 60, 52 },
                    { 81, 144 },
                    { 18, 29 },
                    { 66, 207 },
                    { 7, 77 },
                    { 21, 11 },
                    { 24, 79 },
                    { 63, 124 },
                    { 43, 48 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "CarId", "UserId" },
                values: new object[,]
                {
                    { 38, 281 },
                    { 28, 176 },
                    { 84, 119 },
                    { 13, 192 },
                    { 29, 74 },
                    { 75, 28 },
                    { 14, 18 },
                    { 72, 290 },
                    { 77, 111 },
                    { 45, 121 },
                    { 54, 297 },
                    { 87, 297 },
                    { 36, 236 },
                    { 22, 295 },
                    { 10, 219 },
                    { 58, 119 },
                    { 62, 111 },
                    { 35, 14 },
                    { 12, 194 },
                    { 37, 259 },
                    { 20, 38 },
                    { 55, 190 },
                    { 39, 95 },
                    { 26, 197 },
                    { 90, 56 },
                    { 19, 67 },
                    { 88, 168 }
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
