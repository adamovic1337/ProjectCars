using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCars.Repository.Migrations
{
    public partial class initial : Migration
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
                name: "Models",
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
                    table.PrimaryKey("PK_Models", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Models_Engines_EngineId",
                        column: x => x.EngineId,
                        principalTable: "Engines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Models_Manufacturers_ManufacturerId",
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
                        name: "FK_Cars_Models_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Models",
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCars", x => x.Id);
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
                    UserCarId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRequest", x => x.Id);
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
                        name: "FK_ServiceRequest_UserCars_UserCarId",
                        column: x => x.UserCarId,
                        principalTable: "UserCars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Malta" },
                    { 124, "Equatorial Guinea" },
                    { 123, "Moldova" },
                    { 122, "Pitcairn Islands" },
                    { 120, "Brazil" },
                    { 119, "San Marino" },
                    { 118, "Italy" },
                    { 117, "American Samoa" },
                    { 116, "Myanmar" },
                    { 114, "Australia" },
                    { 111, "Bahrain" },
                    { 110, "Czech Republic" },
                    { 109, "Cocos (Keeling) Islands" },
                    { 108, "Dominican Republic" },
                    { 107, "Reunion" },
                    { 106, "Cambodia" },
                    { 103, "Cape Verde" },
                    { 101, "Honduras" },
                    { 100, "Tajikistan" },
                    { 99, "Barbados" },
                    { 98, "Portugal" },
                    { 96, "Sudan" },
                    { 94, "Guyana" },
                    { 93, "Seychelles" },
                    { 92, "Bulgaria" },
                    { 91, "Lao People's Democratic Republic" },
                    { 90, "Tokelau" },
                    { 88, "Ecuador" },
                    { 86, "Zambia" },
                    { 85, "Lebanon" },
                    { 125, "Fiji" },
                    { 127, "Dominica" },
                    { 128, "Cote d'Ivoire" },
                    { 131, "Finland" },
                    { 197, "Liberia" },
                    { 193, "Cuba" },
                    { 192, "Uzbekistan" },
                    { 188, "Spain" },
                    { 187, "Benin" },
                    { 186, "Mauritius" },
                    { 184, "Hungary" },
                    { 181, "Latvia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 178, "Falkland Islands (Malvinas)" },
                    { 175, "Swaziland" },
                    { 173, "Singapore" },
                    { 172, "Congo" },
                    { 171, "Saint Kitts and Nevis" },
                    { 168, "Sierra Leone" },
                    { 84, "Togo" },
                    { 167, "Mozambique" },
                    { 162, "Luxembourg" },
                    { 161, "Trinidad and Tobago" },
                    { 159, "Montserrat" },
                    { 158, "Tonga" },
                    { 157, "Afghanistan" },
                    { 151, "South Georgia and the South Sandwich Islands" },
                    { 150, "Armenia" },
                    { 149, "Syrian Arab Republic" },
                    { 146, "Belize" },
                    { 145, "South Africa" },
                    { 143, "Azerbaijan" },
                    { 137, "Sweden" },
                    { 133, "Senegal" },
                    { 132, "Antarctica (the territory South of 60 deg S)" },
                    { 163, "Slovakia (Slovak Republic)" },
                    { 83, "Paraguay" },
                    { 89, "Madagascar" },
                    { 81, "Suriname" },
                    { 37, "Chad" },
                    { 36, "Russian Federation" },
                    { 35, "Poland" },
                    { 82, "Andorra" },
                    { 33, "Netherlands Antilles" },
                    { 30, "Oman" },
                    { 28, "Guadeloupe" },
                    { 27, "Gibraltar" },
                    { 26, "Malaysia" },
                    { 25, "Western Sahara" },
                    { 24, "Somalia" },
                    { 22, "Romania" },
                    { 21, "Turkmenistan" },
                    { 19, "Guinea" },
                    { 38, "Lesotho" },
                    { 18, "French Southern Territories" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 16, "Jamaica" },
                    { 15, "Liechtenstein" },
                    { 13, "French Polynesia" },
                    { 12, "Micronesia" },
                    { 11, "Ethiopia" },
                    { 10, "Isle of Man" },
                    { 9, "United Kingdom" },
                    { 8, "Saint Barthelemy" },
                    { 7, "Austria" },
                    { 6, "Uruguay" },
                    { 5, "Thailand" },
                    { 4, "Palestinian Territory" },
                    { 3, "Switzerland" },
                    { 2, "Gambia" },
                    { 17, "Malawi" },
                    { 39, "Qatar" },
                    { 34, "Comoros" },
                    { 41, "Marshall Islands" },
                    { 80, "Niger" },
                    { 79, "Martinique" },
                    { 77, "Saint Helena" },
                    { 76, "Japan" },
                    { 75, "Colombia" },
                    { 74, "Belgium" },
                    { 73, "Monaco" },
                    { 72, "Antigua and Barbuda" },
                    { 40, "Faroe Islands" },
                    { 70, "Saint Vincent and the Grenadines" },
                    { 69, "Canada" },
                    { 68, "Bosnia and Herzegovina" },
                    { 66, "Hong Kong" },
                    { 65, "Bouvet Island (Bouvetoya)" },
                    { 71, "Eritrea" },
                    { 60, "Guam" },
                    { 42, "Kuwait" },
                    { 63, "Germany" },
                    { 46, "Grenada" },
                    { 47, "Papua New Guinea" },
                    { 49, "Nigeria" },
                    { 51, "China" },
                    { 45, "Estonia" },
                    { 54, "Haiti" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 55, "Norway" },
                    { 56, "Slovenia" },
                    { 57, "El Salvador" },
                    { 58, "Argentina" },
                    { 59, "Peru" },
                    { 52, "Gabon" }
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
                    { 15, 1, "Lazaroport" },
                    { 169, 116, "New Monroeton" },
                    { 133, 116, "Port Elisa" },
                    { 23, 116, "North Annamaechester" },
                    { 236, 114, "New Lethaburgh" },
                    { 26, 114, "East Jennie" },
                    { 260, 111, "Jacintoview" },
                    { 204, 111, "Lake Jammieview" },
                    { 34, 111, "East Arnaldo" },
                    { 124, 110, "Lake Myrtle" },
                    { 75, 109, "West Fredericmouth" },
                    { 251, 108, "Creminstad" },
                    { 73, 108, "Greenfelderburgh" },
                    { 8, 107, "North Hillardside" },
                    { 106, 106, "West Maximillia" },
                    { 97, 106, "West Ryley" },
                    { 272, 103, "Feltonland" },
                    { 263, 103, "Lake Elmira" },
                    { 188, 116, "DuBuquetown" },
                    { 225, 116, "Lambertland" },
                    { 202, 118, "Kaytown" },
                    { 287, 118, "Joanaside" },
                    { 62, 124, "Lewisfurt" },
                    { 268, 123, "South Nelsbury" },
                    { 42, 123, "West Woodrowville" },
                    { 10, 123, "Port Lyricstad" },
                    { 190, 122, "Purdymouth" },
                    { 93, 122, "Lake Emmetstad" },
                    { 9, 122, "Lorenamouth" },
                    { 279, 120, "Margotside" },
                    { 217, 103, "Zulaufstad" },
                    { 258, 120, "West Rigoberto" },
                    { 13, 120, "Yosthaven" },
                    { 283, 119, "Parisianchester" },
                    { 262, 119, "Lake Jessyfurt" },
                    { 254, 119, "North Jayden" },
                    { 132, 119, "South Karsonview" },
                    { 121, 119, "Willchester" },
                    { 88, 119, "Woodrowton" },
                    { 32, 119, "West Myrtie" },
                    { 146, 120, "South Theresia" },
                    { 148, 103, "Muellerside" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 230, 101, "Port Angelita" },
                    { 197, 101, "Eugenebury" },
                    { 107, 88, "East Craig" },
                    { 270, 86, "West Lizashire" },
                    { 95, 86, "MacGyverview" },
                    { 139, 85, "Lake Gudrun" },
                    { 72, 85, "Wolffhaven" },
                    { 130, 84, "South Laverna" },
                    { 2, 84, "New Teagan" },
                    { 84, 83, "Leschshire" },
                    { 250, 88, "Jaydafurt" },
                    { 64, 83, "West Horaciomouth" },
                    { 295, 82, "South Hankfort" },
                    { 69, 82, "Port Santos" },
                    { 14, 82, "Monafurt" },
                    { 288, 81, "West Kassandraborough" },
                    { 110, 81, "New Kristoferberg" },
                    { 28, 81, "North Kaylin" },
                    { 40, 80, "West Geoburgh" },
                    { 223, 77, "Bradtkehaven" },
                    { 58, 83, "Crooksland" },
                    { 112, 124, "Lake Lilastad" },
                    { 198, 89, "Lakinfurt" },
                    { 273, 90, "Lindgrenland" },
                    { 180, 101, "Jerdefurt" },
                    { 66, 101, "West Guido" },
                    { 1, 101, "Lake Urban" },
                    { 60, 100, "East Marisolfurt" },
                    { 22, 100, "Schuppeton" },
                    { 164, 99, "North Adolph" },
                    { 161, 99, "Port Citlalli" },
                    { 252, 98, "West Carter" },
                    { 237, 90, "McDermottbury" },
                    { 83, 98, "Whitehaven" },
                    { 39, 96, "Lake Antwonberg" },
                    { 281, 94, "Trompfort" },
                    { 264, 93, "North Thea" },
                    { 261, 93, "South Imani" },
                    { 209, 93, "Jaedenton" },
                    { 92, 93, "Wiltonshire" },
                    { 152, 92, "Seanmouth" },
                    { 76, 91, "Erichhaven" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 46, 98, "Sigurdfurt" },
                    { 220, 77, "South Silas" },
                    { 221, 124, "Lake Wavaland" },
                    { 122, 125, "North Jessyca" },
                    { 181, 175, "Winifredberg" },
                    { 111, 175, "Port Rylee" },
                    { 63, 175, "Dominiquefurt" },
                    { 291, 173, "New Andy" },
                    { 259, 173, "Audreanneport" },
                    { 119, 173, "East Garrett" },
                    { 114, 173, "West Mustafa" },
                    { 98, 173, "Lafayetteside" },
                    { 36, 173, "Keelingchester" },
                    { 192, 172, "Feeneybury" },
                    { 138, 172, "North Kristopherfort" },
                    { 127, 172, "Vestaport" },
                    { 185, 171, "North Jewel" },
                    { 150, 171, "East Bailey" },
                    { 53, 171, "South Luisaport" },
                    { 50, 168, "Torpfurt" },
                    { 48, 168, "Koelpinbury" },
                    { 154, 178, "North Joshua" },
                    { 232, 178, "Kirstenchester" },
                    { 5, 181, "West Garfield" },
                    { 74, 181, "Eladiotown" },
                    { 247, 197, "Reichertfort" },
                    { 21, 197, "Torreyfort" },
                    { 282, 193, "Gayleland" },
                    { 195, 193, "Lucianoport" },
                    { 7, 193, "Wolffburgh" },
                    { 6, 193, "Corwinberg" },
                    { 176, 192, "Morissettefort" },
                    { 55, 192, "North Lisandroview" },
                    { 141, 167, "Ilianafurt" },
                    { 280, 188, "Hillsview" },
                    { 271, 186, "Avisland" },
                    { 222, 186, "Bruenchester" },
                    { 187, 186, "Londonport" },
                    { 128, 186, "Port Geovanny" },
                    { 20, 186, "South Vickyport" },
                    { 235, 184, "North Ansel" },
                    { 47, 184, "Lake Artton" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 131, 181, "New Paoloberg" },
                    { 228, 188, "North Charlenehaven" },
                    { 296, 163, "West Daisyville" },
                    { 227, 163, "Russelstad" },
                    { 179, 163, "Elizaburgh" },
                    { 286, 137, "McGlynnport" },
                    { 269, 137, "Lake Jaydaland" },
                    { 267, 133, "Lake Verdashire" },
                    { 210, 133, "West Maryamside" },
                    { 207, 132, "Bruenfurt" },
                    { 118, 132, "Lake Abigaylefort" },
                    { 44, 132, "South Niko" },
                    { 123, 131, "South Andrew" },
                    { 33, 143, "Aimeefurt" },
                    { 35, 131, "West Davion" },
                    { 171, 128, "Feilborough" },
                    { 41, 128, "Jasperport" },
                    { 244, 127, "Gloverville" },
                    { 201, 127, "Trentonport" },
                    { 90, 127, "Bechtelarport" },
                    { 38, 127, "Mullerview" },
                    { 253, 125, "West Alexie" },
                    { 140, 125, "Wernerport" },
                    { 25, 131, "Cruickshankland" },
                    { 224, 124, "Lake Natalie" },
                    { 68, 143, "Sauerbury" },
                    { 51, 145, "Port Ronaldoborough" },
                    { 78, 163, "North Estellberg" },
                    { 242, 162, "Thielside" },
                    { 99, 162, "North Chaseton" },
                    { 37, 162, "Dedrickville" },
                    { 113, 161, "Port Coralie" },
                    { 67, 159, "East Susannaton" },
                    { 297, 158, "South Gilda" },
                    { 284, 158, "Donshire" },
                    { 213, 143, "South Earlburgh" },
                    { 125, 158, "New Axel" },
                    { 85, 157, "Veldabury" },
                    { 233, 151, "Othafort" },
                    { 89, 150, "New Margeborough" },
                    { 61, 150, "Lake Glendaborough" },
                    { 16, 150, "New Precious" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 120, 149, "Gradymouth" },
                    { 100, 149, "Hershelport" },
                    { 11, 149, "South Kaliport" },
                    { 144, 157, "West Annamae" },
                    { 175, 77, "West Gerard" },
                    { 276, 110, "South Della" },
                    { 3, 77, "South Alexanechester" },
                    { 274, 1, "West Blanche" },
                    { 70, 39, "West Loraine" },
                    { 81, 38, "Jonathonchester" },
                    { 248, 37, "Lake Lennaside" },
                    { 160, 36, "Ovastad" },
                    { 56, 36, "Batzbury" },
                    { 137, 35, "Lavadabury" },
                    { 54, 34, "Arnoport" },
                    { 266, 33, "North Alexandra" },
                    { 214, 33, "Violettehaven" },
                    { 162, 33, "Einofort" },
                    { 136, 33, "East Beaulah" },
                    { 96, 28, "Verdiehaven" },
                    { 27, 28, "Amandaville" },
                    { 246, 27, "North Marcosmouth" },
                    { 104, 40, "North Brendaberg" },
                    { 173, 41, "Katarinashire" },
                    { 200, 41, "Grahambury" },
                    { 241, 41, "South Annieland" },
                    { 59, 51, "Smithburgh" },
                    { 52, 51, "Simonisbury" },
                    { 19, 51, "North Marieview" },
                    { 290, 47, "East Nicholausshire" },
                    { 205, 47, "East Sofiashire" },
                    { 135, 47, "South Leestad" },
                    { 31, 47, "Corenefurt" },
                    { 116, 26, "South Araburgh" },
                    { 277, 46, "Coleton" },
                    { 194, 46, "Carolinaton" },
                    { 177, 46, "Clarissabury" },
                    { 82, 46, "Williamsonside" },
                    { 186, 45, "Port Vanessa" },
                    { 57, 45, "North Tomas" },
                    { 285, 41, "North Jamar" },
                    { 256, 41, "Lake Daronton" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 238, 46, "Noelland" },
                    { 4, 26, "New Hank" },
                    { 234, 25, "Goodwinburgh" },
                    { 166, 25, "East Bonita" },
                    { 71, 8, "Ryleighhaven" },
                    { 300, 7, "Zanderland" },
                    { 299, 7, "Rennerstad" },
                    { 102, 7, "East Edgar" },
                    { 278, 6, "West Nelsonstad" },
                    { 255, 6, "Valentinaville" },
                    { 229, 6, "Lake Camilleville" },
                    { 294, 8, "West Allison" },
                    { 211, 6, "New Jordon" },
                    { 103, 6, "North Jeffrey" },
                    { 145, 5, "Schmelershire" },
                    { 29, 5, "Annamariehaven" },
                    { 174, 4, "Framifort" },
                    { 108, 4, "North Travonchester" },
                    { 45, 4, "North Sandyfort" },
                    { 147, 2, "Hoegerport" },
                    { 159, 6, "Lake Annette" },
                    { 212, 51, "New Nelle" },
                    { 142, 9, "South Jaylen" },
                    { 12, 11, "Barrowsstad" },
                    { 243, 24, "Lake Zackfurt" },
                    { 170, 21, "Jazmynechester" },
                    { 265, 19, "Lake Kiley" },
                    { 249, 19, "Bricebury" },
                    { 172, 77, "Edisonchester" },
                    { 193, 19, "South Ivaborough" },
                    { 109, 19, "Boehmton" },
                    { 203, 9, "Ayanaberg" },
                    { 49, 19, "South Nellie" },
                    { 158, 18, "Keithhaven" },
                    { 293, 17, "Port Summerville" },
                    { 80, 15, "North Kelly" },
                    { 155, 13, "North Adolphusview" },
                    { 163, 12, "Elliottberg" },
                    { 101, 12, "Brennamouth" },
                    { 292, 11, "East Mazie" },
                    { 24, 19, "Ritchiefurt" },
                    { 216, 51, "Shieldsmouth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 196, 39, "Port Rico" },
                    { 77, 1, "North Jaclynfurt" },
                    { 165, 58, "Port Rebekah" },
                    { 91, 74, "Aryannaland" },
                    { 206, 58, "Port Patriciafort" },
                    { 17, 74, "Adrianahaven" },
                    { 218, 58, "New Edwinbury" },
                    { 183, 66, "Bashirianberg" },
                    { 117, 59, "Port Lucilemouth" },
                    { 182, 73, "East Jamil" },
                    { 79, 73, "Kattiemouth" },
                    { 156, 59, "Demarcusburgh" },
                    { 231, 72, "South Shawnview" },
                    { 191, 74, "Huelsport" },
                    { 275, 63, "Marvinside" },
                    { 199, 71, "Willmstown" },
                    { 134, 65, "Lake Santa" },
                    { 189, 65, "Strackemouth" },
                    { 289, 70, "West Madisyn" },
                    { 94, 70, "West Elody" },
                    { 86, 52, "Gislasonville" },
                    { 87, 66, "West Jimmy" },
                    { 184, 69, "East Gideonburgh" },
                    { 105, 66, "New Bobbyside" },
                    { 168, 69, "Krajcikberg" },
                    { 157, 66, "Lednerborough" },
                    { 208, 72, "East Deontae" },
                    { 129, 58, "Maximilliaberg" },
                    { 18, 59, "South Modesta" },
                    { 245, 66, "Zacheryburgh" },
                    { 178, 56, "Meaghanburgh" },
                    { 126, 58, "Angelicaton" },
                    { 65, 76, "West Virginie" },
                    { 43, 76, "Lake Douglas" },
                    { 257, 56, "Missouritown" },
                    { 298, 56, "Dwightmouth" },
                    { 239, 55, "Hegmannmouth" },
                    { 151, 57, "New Rubyefurt" },
                    { 215, 54, "New Annamae" },
                    { 143, 76, "East Tamia" },
                    { 226, 75, "Port Zacharyhaven" },
                    { 219, 52, "Cleoraburgh" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 167, 75, "West Sybleborough" },
                    { 153, 75, "Mittietown" },
                    { 115, 58, "Lake Shemarside" },
                    { 30, 58, "Arjuntown" },
                    { 149, 75, "South Scottiechester" },
                    { 240, 57, "North Else" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 75, 2451, 1, 289 },
                    { 79, 2153, 1, 236 },
                    { 80, 2242, 1, 467 },
                    { 5, 1011, 2, 137 },
                    { 91, 2231, 1, 228 },
                    { 93, 2393, 1, 335 },
                    { 1, 1229, 1, 234 },
                    { 2, 1374, 2, 235 },
                    { 11, 1720, 1, 630 },
                    { 3, 1955, 2, 436 },
                    { 74, 1683, 1, 492 },
                    { 51, 2619, 4, 193 },
                    { 48, 2125, 4, 212 },
                    { 4, 1760, 2, 349 },
                    { 94, 2157, 4, 372 },
                    { 66, 2249, 4, 350 },
                    { 57, 1706, 1, 524 },
                    { 92, 2809, 4, 140 },
                    { 84, 2312, 4, 574 },
                    { 33, 1608, 1, 242 },
                    { 40, 1298, 1, 263 },
                    { 83, 1714, 4, 291 },
                    { 76, 2623, 4, 244 },
                    { 41, 1554, 1, 535 },
                    { 42, 1666, 1, 236 },
                    { 46, 2740, 1, 206 },
                    { 73, 2670, 1, 487 },
                    { 47, 1932, 1, 574 },
                    { 50, 1097, 1, 530 },
                    { 71, 2750, 4, 153 },
                    { 27, 1120, 1, 452 },
                    { 23, 1152, 1, 663 },
                    { 55, 1290, 1, 241 },
                    { 13, 1014, 1, 245 },
                    { 60, 1347, 1, 603 },
                    { 68, 1582, 1, 518 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 90, 2221, 4, 557 },
                    { 85, 2678, 4, 375 },
                    { 52, 2944, 2, 132 },
                    { 21, 2349, 2, 501 },
                    { 15, 2121, 4, 164 },
                    { 12, 1137, 4, 610 },
                    { 19, 1385, 3, 682 },
                    { 22, 1646, 3, 112 },
                    { 24, 1938, 3, 116 },
                    { 25, 2281, 3, 660 },
                    { 26, 1409, 3, 451 },
                    { 36, 1523, 3, 589 },
                    { 10, 2619, 4, 176 },
                    { 43, 2627, 3, 309 },
                    { 49, 1990, 3, 193 },
                    { 59, 1046, 3, 529 },
                    { 14, 1116, 3, 365 },
                    { 61, 2035, 3, 559 },
                    { 62, 1999, 3, 173 },
                    { 7, 2982, 4, 188 },
                    { 99, 2073, 3, 476 },
                    { 98, 2375, 3, 526 },
                    { 63, 1765, 3, 373 },
                    { 72, 1676, 3, 154 },
                    { 97, 2148, 3, 271 },
                    { 81, 1546, 3, 641 },
                    { 95, 1114, 3, 392 },
                    { 89, 1083, 3, 274 },
                    { 88, 2294, 3, 303 },
                    { 87, 2824, 3, 146 },
                    { 8, 1291, 4, 473 },
                    { 16, 1423, 2, 256 },
                    { 9, 2596, 3, 373 },
                    { 6, 1069, 3, 646 },
                    { 28, 1676, 2, 523 },
                    { 29, 1101, 2, 644 },
                    { 34, 1663, 2, 181 },
                    { 37, 1330, 2, 693 },
                    { 44, 2862, 2, 641 },
                    { 45, 1855, 2, 537 },
                    { 53, 1523, 2, 597 },
                    { 39, 2152, 4, 301 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 54, 2216, 2, 369 },
                    { 38, 1174, 4, 176 },
                    { 35, 1323, 4, 482 },
                    { 56, 1072, 2, 496 },
                    { 17, 1210, 4, 607 },
                    { 32, 1585, 4, 330 },
                    { 58, 2794, 2, 510 },
                    { 64, 1076, 2, 465 },
                    { 65, 2314, 2, 615 },
                    { 67, 2601, 2, 375 },
                    { 30, 1704, 4, 626 },
                    { 69, 2779, 2, 648 },
                    { 70, 1963, 2, 669 },
                    { 77, 1284, 2, 340 },
                    { 20, 1376, 4, 334 },
                    { 78, 2169, 2, 324 },
                    { 18, 1909, 4, 476 },
                    { 86, 1581, 2, 440 },
                    { 31, 1484, 4, 592 },
                    { 82, 1667, 3, 198 },
                    { 100, 2919, 4, 275 },
                    { 96, 2052, 4, 548 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 3, 193, "Schmidt Group" },
                    { 19, 107, "Blick, Reilly and Spinka" },
                    { 73, 107, "Mayert LLC" },
                    { 87, 55, "Hirthe Inc" },
                    { 22, 108, "Douglas and Sons" },
                    { 58, 108, "Kuhlman, Rice and Ryan" },
                    { 41, 110, "Zboncak Group" },
                    { 25, 51, "Stokes Group" },
                    { 68, 116, "Dickinson - Muller" },
                    { 96, 46, "Casper and Sons" },
                    { 48, 46, "Johns - Wilderman" },
                    { 67, 45, "Kirlin Inc" },
                    { 98, 42, "Grady - Langosh" },
                    { 78, 42, "Buckridge, Schaefer and Mitchell" },
                    { 4, 42, "Kling LLC" },
                    { 75, 123, "Carter - Shields" },
                    { 16, 39, "Stroman - Volkman" },
                    { 53, 124, "Schmeler and Sons" },
                    { 28, 38, "Kuphal - Flatley" },
                    { 51, 125, "Veum - Wintheiser" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 83, 37, "Kilback - Walter" },
                    { 50, 106, "Jacobson - Kozey" },
                    { 21, 37, "Raynor Inc" },
                    { 1, 103, "Batz Inc" },
                    { 7, 58, "Blanda, Wuckert and Mayer" },
                    { 85, 77, "Bechtelar and Sons" },
                    { 71, 79, "Homenick, Connelly and Hills" },
                    { 9, 75, "Brekke LLC" },
                    { 38, 82, "Rosenbaum and Sons" },
                    { 49, 74, "Green Inc" },
                    { 91, 73, "Hayes Group" },
                    { 6, 84, "Bayer, Buckridge and Reinger" },
                    { 94, 85, "Adams Group" },
                    { 13, 88, "Zieme and Sons" },
                    { 88, 89, "Kuphal Group" },
                    { 63, 90, "Hilll - Gusikowski" },
                    { 90, 65, "Ebert - Balistreri" },
                    { 33, 93, "Lang - Greenholt" },
                    { 84, 65, "Murazik, Stracke and Wyman" },
                    { 54, 94, "Fisher Inc" },
                    { 66, 94, "Mann - Bergnaum" },
                    { 34, 65, "Klein, Walker and Murazik" },
                    { 43, 63, "McGlynn LLC" },
                    { 42, 99, "Hickle, Goldner and Hoppe" },
                    { 52, 99, "Rogahn - Wintheiser" },
                    { 76, 100, "Corkery, Cremin and Robel" },
                    { 62, 101, "Schmeler Inc" },
                    { 61, 35, "Spinka Inc" },
                    { 24, 35, "Sauer, Strosin and Streich" },
                    { 8, 131, "Beatty Inc" },
                    { 11, 16, "Greenholt, O'Conner and Sawayn" },
                    { 5, 16, "Cormier Group" },
                    { 79, 15, "Kassulke LLC" },
                    { 69, 15, "Bauch - Bartoletti" },
                    { 23, 15, "Legros and Sons" },
                    { 47, 13, "Koch LLC" },
                    { 57, 172, "Lang - Witting" },
                    { 72, 172, "Wilderman LLC" },
                    { 89, 172, "Mante, Carter and Tromp" },
                    { 82, 12, "Luettgen, Hane and Mayert" },
                    { 20, 10, "Cremin - Lueilwitz" },
                    { 86, 8, "Bashirian, Dare and Cormier" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 44, 175, "Altenwerth, Doyle and Dietrich" },
                    { 55, 175, "Feeney Inc" },
                    { 31, 8, "Bashirian and Sons" },
                    { 65, 7, "Auer Group" },
                    { 95, 187, "Fisher - Doyle" },
                    { 2, 188, "Heathcote - Abernathy" },
                    { 32, 188, "Gulgowski Group" },
                    { 60, 192, "Mohr, Johnson and Kulas" },
                    { 29, 2, "Schumm - Dietrich" },
                    { 14, 17, "Walker LLC" },
                    { 56, 17, "Blick Group" },
                    { 59, 17, "Dach - Thompson" },
                    { 10, 162, "Hoppe LLC" },
                    { 80, 33, "Kunze, Jakubowski and Hessel" },
                    { 74, 132, "Hintz - Kris" },
                    { 45, 30, "Daugherty Inc" },
                    { 30, 28, "Gerlach, Hessel and Kub" },
                    { 15, 137, "Glover, Bahringer and Hyatt" },
                    { 12, 143, "Koch - Kassulke" },
                    { 70, 26, "Durgan Inc" },
                    { 35, 145, "Rutherford Group" },
                    { 39, 26, "Hamill Group" },
                    { 17, 149, "Kihn LLC" },
                    { 81, 197, "Bartoletti - Bayer" },
                    { 18, 24, "Hyatt, Maggio and Waelchi" },
                    { 99, 151, "Johnston - Thompson" },
                    { 93, 22, "Hagenes LLC" },
                    { 64, 157, "Kuvalis - Wisoky" },
                    { 100, 19, "Morissette Inc" },
                    { 46, 19, "Schimmel, Block and O'Conner" },
                    { 26, 158, "Schimmel - Monahan" },
                    { 36, 159, "Barrows - Ferry" },
                    { 37, 159, "Windler LLC" },
                    { 77, 159, "Mante and Sons" },
                    { 97, 161, "Waelchi - Gulgowski" },
                    { 27, 151, "Keebler and Sons" },
                    { 40, 159, "Wyman, Cole and Leuschke" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 94, 94, 36, "sunt" },
                    { 75, 21, 4, "dicta" },
                    { 71, 29, 84, "amet" },
                    { 24, 44, 39, "sint" },
                    { 13, 45, 16, "commodi" },
                    { 26, 52, 28, "minus" },
                    { 1, 56, 74, "aut" },
                    { 23, 56, 96, "architecto" },
                    { 32, 56, 97, "suscipit" },
                    { 2, 58, 5, "ut" },
                    { 57, 64, 67, "soluta" },
                    { 39, 65, 95, "rerum" },
                    { 52, 67, 69, "veniam" },
                    { 15, 70, 52, "cupiditate" },
                    { 30, 77, 95, "quia" },
                    { 18, 78, 3, "impedit" },
                    { 70, 16, 9, "quis" },
                    { 51, 4, 26, "repudiandae" },
                    { 17, 4, 78, "voluptates" },
                    { 68, 2, 79, "facilis" },
                    { 41, 1, 75, "qui" },
                    { 42, 11, 93, "temporibus" },
                    { 72, 11, 18, "tenetur" },
                    { 54, 23, 62, "exercitationem" },
                    { 3, 40, 94, "id" },
                    { 35, 40, 100, "illum" },
                    { 31, 46, 29, "repellat" },
                    { 74, 78, 36, "debitis" },
                    { 69, 46, 87, "eum" },
                    { 7, 55, 52, "itaque" },
                    { 21, 57, 24, "quasi" },
                    { 25, 73, 90, "voluptate" },
                    { 37, 73, 60, "ab" },
                    { 79, 73, 47, "distinctio" },
                    { 78, 74, 41, "beatae" },
                    { 50, 2, 69, "rem" },
                    { 81, 50, 38, "est" },
                    { 6, 86, 59, "facere" },
                    { 76, 92, 51, "ex" },
                    { 65, 19, 89, "non" },
                    { 4, 18, 59, "illo" },
                    { 45, 31, 96, "at" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 56, 35, 34, "doloremque" },
                    { 16, 38, 46, "corrupti" },
                    { 40, 38, 54, "maiores" },
                    { 61, 39, 51, "fugit" },
                    { 8, 48, 4, "et" },
                    { 77, 12, 25, "natus" },
                    { 27, 48, 71, "repellendus" },
                    { 9, 51, 93, "sed" },
                    { 85, 66, 37, "dolor" },
                    { 12, 71, 77, "ad" },
                    { 44, 71, 49, "ipsum" },
                    { 90, 71, 29, "perspiciatis" },
                    { 88, 84, 73, "unde" },
                    { 22, 86, 86, "hic" },
                    { 59, 48, 54, "velit" },
                    { 60, 12, 75, "expedita" },
                    { 34, 51, 41, "fugiat" },
                    { 20, 12, 70, "vitae" },
                    { 63, 26, 57, "libero" },
                    { 36, 12, 30, "animi" },
                    { 28, 59, 59, "consequuntur" },
                    { 93, 59, 99, "minima" },
                    { 73, 62, 26, "pariatur" },
                    { 5, 63, 33, "incidunt" },
                    { 82, 63, 46, "odit" },
                    { 19, 72, 1, "sit" },
                    { 46, 61, 31, "delectus" },
                    { 91, 72, 49, "iure" },
                    { 14, 82, 79, "aperiam" },
                    { 43, 95, 8, "voluptatibus" },
                    { 11, 10, 73, "consectetur" },
                    { 38, 99, 30, "adipisci" },
                    { 49, 99, 80, "ipsa" },
                    { 29, 72, 48, "ea" },
                    { 53, 8, 3, "dolores" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 296, 44, "Eleanora80@yahoo.com", "Anabelle", "Schuster", "973PSU8Oo6", 3, "Royce58" },
                    { 299, 25, "Elbert30@hotmail.com", "Dena", "Green", "zlUOg90JzU", 3, "Jeramie2" },
                    { 270, 25, "Madge93@gmail.com", "Roslyn", "Padberg", "2cgUcqBiqw", 3, "Samantha_Von" },
                    { 144, 41, "Hans79@gmail.com", "Virgil", "Mann", "OFdG757rTo", 2, "Ayla_Roob80" },
                    { 234, 38, "Ayana_Gerlach58@yahoo.com", "Brittany", "Murray", "sUW6qAjs0D", 1, "Tyler.Gaylord64" },
                    { 273, 253, "Ines.Boehm94@yahoo.com", "Elody", "Shields", "zh_AeGnQpb", 1, "Jonatan.Glover89" },
                    { 138, 253, "Velma.Moore@gmail.com", "Raven", "Schuster", "aOQ3LdO3Cv", 1, "Noble64" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 102, 118, "Zander_Olson@hotmail.com", "Hellen", "Reilly", "w5ZC8EMVOC", 2, "Coby_Brown" },
                    { 23, 140, "Eliza.Ward@hotmail.com", "Anibal", "Williamson", "wvwMOAoPJw", 2, "Nikolas25" },
                    { 149, 90, "Lennie64@yahoo.com", "Joy", "West", "opuFk67Qeb", 3, "Hans45" },
                    { 112, 210, "Fleta30@yahoo.com", "Keon", "Bode", "G594yQxTFz", 2, "Robert.Braun" },
                    { 123, 51, "Lou.Vandervort@hotmail.com", "Jarod", "Goldner", "uhHpVKDlaG", 2, "Gerald_Rice85" },
                    { 77, 286, "Ted.Prohaska58@hotmail.com", "Britney", "Ritchie", "CAu15Gq99Y", 3, "Marian_Wolff" },
                    { 238, 286, "Evert_Ledner61@yahoo.com", "Esmeralda", "McDermott", "KEQxwQ993M", 2, "Emelie24" },
                    { 253, 286, "Marlin.Parker@hotmail.com", "Juvenal", "Quitzon", "1uWNxPNFX1", 2, "Judd.Quigley" },
                    { 16, 33, "Leilani.Swaniawski@gmail.com", "Pearline", "Dach", "uDzTZkpw78", 3, "Krista_Steuber" },
                    { 73, 68, "Russ.Huel18@gmail.com", "Carlee", "Rau", "dnF9p8YmIn", 3, "Pietro51" },
                    { 4, 213, "Jack25@yahoo.com", "Donnell", "Marks", "ClywT9Gh9s", 1, "Zaria.Renner" },
                    { 169, 51, "Elody40@yahoo.com", "Lisette", "Robel", "xTkvKpWtX1", 1, "Richard20" },
                    { 207, 51, "Alivia_Kuphal66@gmail.com", "Rickey", "Miller", "ffNadWL357", 2, "Katharina_Smitham" },
                    { 282, 51, "Shany86@hotmail.com", "Easton", "Thiel", "etvRvaPHaT", 3, "Ricky.Wintheiser47" },
                    { 289, 51, "Shawna_Gutkowski@yahoo.com", "Roy", "Schroeder", "q7GL8HI_VV", 1, "Eduardo.Sanford96" },
                    { 121, 224, "Adriana_Gottlieb@hotmail.com", "Hope", "Haag", "oSMvic8eYD", 2, "Gaetano.Hoeger" },
                    { 247, 267, "Edgardo.Funk15@hotmail.com", "Milford", "McClure", "SQ1p99vm5M", 3, "Alfonso.Rau24" },
                    { 85, 224, "Olen15@gmail.com", "Gavin", "Simonis", "2vQ23lDAYA", 2, "Yazmin_Mraz" },
                    { 61, 287, "Vicky.Ullrich27@gmail.com", "Katrina", "Lubowitz", "o7dZj1cxO4", 3, "Daphne.Breitenberg" },
                    { 243, 112, "Hudson.Price@gmail.com", "Brennon", "Hermann", "dVsEQIQXZc", 3, "Mandy_Batz50" },
                    { 148, 23, "Tia.Lynch@hotmail.com", "Greg", "Stanton", "FCxy7mzu2k", 3, "Reginald.Terry" },
                    { 279, 133, "Clark42@hotmail.com", "Cristopher", "Doyle", "GsFtGZpeEC", 2, "Astrid.Sanford11" },
                    { 95, 169, "Gonzalo.Kshlerin39@gmail.com", "Francis", "Balistreri", "ak1a6aSbRN", 2, "Gussie.Conroy" },
                    { 32, 225, "Chad.Goyette@hotmail.com", "Carrie", "Hackett", "Mn5LGLNJM5", 2, "Kenneth84" },
                    { 259, 225, "Francesco.Deckow@yahoo.com", "Rossie", "Boehm", "NjZqfRerCy", 2, "Marshall.Dach20" },
                    { 128, 202, "Tanner_Watsica@hotmail.com", "Trevor", "Lockman", "36El5bzjZy", 2, "Abbey_Ziemann" },
                    { 198, 202, "Drew_Denesik8@yahoo.com", "Maritza", "Hayes", "jyFv2KNvXK", 3, "Hubert.Watsica" },
                    { 272, 202, "Velma.Powlowski3@hotmail.com", "Luis", "Yost", "6B_ul65qkw", 2, "Don.Robel" },
                    { 27, 11, "Tyrell_Reinger3@hotmail.com", "Clay", "Sipes", "qbOQCK7t8O", 2, "Helen.Dibbert63" },
                    { 47, 121, "Cindy80@gmail.com", "Elisha", "Kovacek", "ctbtJO3hAq", 2, "Demarco_Hamill2" },
                    { 209, 121, "Percy73@gmail.com", "Verla", "Beer", "kG0qFdlyVO", 3, "Hipolito_Mante" },
                    { 107, 132, "Justice_Schaden29@yahoo.com", "Jacinto", "Monahan", "pLKFtmgPrv", 1, "Mateo38" },
                    { 28, 283, "Kennedy_Trantow@gmail.com", "Sim", "Pagac", "_gvn6id9bj", 3, "Rodolfo.Johnson" },
                    { 94, 13, "Joey.Frami48@gmail.com", "Judah", "Glover", "KjbWoiKcfY", 2, "Letitia_Brakus99" },
                    { 162, 13, "Will.Marvin42@hotmail.com", "Candace", "Bogan", "9SZRE2xyJB", 3, "Lorine19" },
                    { 165, 279, "Audrey_Padberg@hotmail.com", "Alanis", "Pfannerstill", "Jm8dCOxzVh", 2, "Juana.Sporer" },
                    { 53, 9, "Ernesto42@gmail.com", "Otto", "Morar", "jET3yhvMIu", 3, "Kaitlyn66" },
                    { 263, 9, "Cathrine.Bayer@hotmail.com", "Kay", "Brakus", "zynWZJXqel", 2, "Brock.Ortiz4" },
                    { 232, 93, "Kaci75@hotmail.com", "Constance", "Lowe", "uckhfpMzwx", 2, "Ryleigh.Powlowski" },
                    { 206, 190, "Aurore_Veum@hotmail.com", "Efren", "Trantow", "Yam6yjdUS1", 3, "Piper_OConnell33" },
                    { 80, 42, "Marco.Schroeder62@yahoo.com", "Vesta", "Kohler", "QOFC2HIHkN", 2, "Mariane.Wisozk47" },
                    { 196, 42, "Linnie84@hotmail.com", "Zoe", "Kirlin", "Ch7WvtthI4", 1, "Roderick_Mosciski" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 1, 268, "Elda37@gmail.com", "Leonie", "Johns", "NgSab9ADq2", 2, "Alan57" },
                    { 58, 268, "Clarabelle.Deckow79@gmail.com", "Evalyn", "Langworth", "b85ml_o_ht", 3, "Joana.Mosciski34" },
                    { 116, 268, "Elizabeth_Pfannerstill26@gmail.com", "Emilia", "McKenzie", "e6qbu4jaZJ", 1, "Lexi.Christiansen" },
                    { 127, 221, "Walker_Fay@hotmail.com", "Ricky", "Kuhic", "edqF3fHy00", 1, "Lelah.Blanda" },
                    { 136, 11, "Jon37@gmail.com", "Sydnee", "Heaney", "inDEwyFzes", 2, "Grover.Murazik13" },
                    { 60, 50, "Kraig_Cole6@gmail.com", "Gillian", "Cremin", "iq14YB0CNe", 1, "Eldridge22" },
                    { 31, 120, "Napoleon.Jast22@hotmail.com", "Cloyd", "Collins", "cW7NaJdjJm", 1, "Ebba.Klein71" },
                    { 223, 63, "Coleman_Flatley@hotmail.com", "Solon", "Abshire", "oPupgWlRIm", 2, "Emmet.Schroeder" },
                    { 3, 111, "Candice55@hotmail.com", "Damon", "Jones", "fkCVWN8h1L", 1, "Shirley79" },
                    { 168, 111, "Boyd.Ritchie@gmail.com", "Emmie", "Daugherty", "jRGdsZUDBj", 1, "Izabella51" },
                    { 214, 111, "Blanca_Weissnat71@gmail.com", "Bud", "Gaylord", "NMcuyIp9Xg", 1, "Korey_Kreiger" },
                    { 277, 181, "Patricia_Fahey@hotmail.com", "Sidney", "Lowe", "mWw_sBSpQ9", 3, "Ciara_Williamson" },
                    { 6, 154, "Roman82@hotmail.com", "Dorian", "Frami", "57j2mZZaEm", 2, "Greyson71" },
                    { 187, 236, "Nikolas_Ruecker@gmail.com", "Clyde", "Keebler", "z9xsPxk7Im", 3, "Jerome26" },
                    { 181, 5, "Johathan.Rutherford@yahoo.com", "Weldon", "Kshlerin", "B1AthYjLvZ", 1, "Sunny.Hickle53" },
                    { 103, 74, "Aylin66@gmail.com", "Mariela", "Rutherford", "ba6pzEhx6k", 3, "Jimmie.Bechtelar40" },
                    { 25, 131, "Mertie86@hotmail.com", "Kyler", "Schmitt", "QICAMkPUbs", 1, "Garrison.Gorczany84" },
                    { 170, 235, "Augusta.Little62@yahoo.com", "Eleonore", "Schimmel", "2rNfW9Cq1S", 3, "Della_Corkery4" },
                    { 36, 63, "Greyson_Berge@yahoo.com", "Amparo", "Corkery", "O9X1s8NPSx", 2, "Hardy44" },
                    { 216, 235, "Ruby42@yahoo.com", "Eleazar", "Dicki", "5MpGwvBzrp", 3, "Isabelle.Durgan" },
                    { 147, 128, "Neal70@yahoo.com", "Marisol", "Murazik", "hEVZZOfEfD", 1, "Annamae13" },
                    { 7, 228, "Jo.Gutkowski35@gmail.com", "Felton", "Schmidt", "vFLrhafs6P", 2, "Baylee_Abbott" },
                    { 135, 228, "Mathias.Nikolaus@hotmail.com", "Krystina", "Rau", "UnRDYtxsFe", 2, "Clair.Murray" },
                    { 212, 280, "Zack_Ebert@yahoo.com", "Everardo", "Towne", "tMwUCmhygf", 2, "Clark.Larson" },
                    { 68, 176, "Deangelo40@yahoo.com", "Jovany", "Wiza", "Or8bDVGvE3", 2, "Paula.Dare" },
                    { 106, 176, "Clarabelle63@yahoo.com", "Randal", "Wolf", "GHDzeWHPEV", 2, "Gregorio_Strosin" },
                    { 12, 195, "Daniela_Marvin6@yahoo.com", "Sibyl", "Carter", "vWkylqAOE5", 3, "Arvel.Grant" },
                    { 100, 21, "Pat_Renner35@gmail.com", "Ryder", "Kuhn", "OVqNE8Ih4k", 2, "Camille.Pagac" },
                    { 133, 21, "Antwan.Hauck6@yahoo.com", "Ignatius", "Hayes", "3aX7rtFooK", 2, "Erica.Monahan" },
                    { 194, 21, "Delphia_Sporer@hotmail.com", "Coy", "Hermann", "Dba1gMyEsl", 3, "Delilah_Ryan" },
                    { 203, 21, "Matt_Christiansen50@hotmail.com", "Deon", "Grady", "shFMXOaYlP", 1, "Ora76" },
                    { 211, 20, "Annamarie.Kub14@yahoo.com", "Ethel", "Klein", "1ocUj0keKF", 3, "Lisette.Thompson61" },
                    { 241, 291, "Alize92@gmail.com", "Evan", "Grady", "Rd0w76GUvq", 2, "Lindsay44" },
                    { 193, 291, "Clarissa.Satterfield@yahoo.com", "Lysanne", "Jenkins", "nLMj8BNK_O", 3, "Dahlia.Tillman" },
                    { 143, 291, "Howard44@gmail.com", "Helene", "Heller", "b3mNERLkAS", 3, "Domingo84" },
                    { 152, 120, "Haylee.Koelpin33@hotmail.com", "Abdul", "Carroll", "1xA3blsuZ2", 1, "Domenica25" },
                    { 176, 120, "Wilma_Heathcote52@hotmail.com", "Federico", "McGlynn", "1OrK12wvdy", 2, "Lloyd31" },
                    { 86, 16, "Madge_Stroman@gmail.com", "Eunice", "Bruen", "X1RtRRsyGF", 2, "Irwin_Littel" },
                    { 189, 16, "Forrest_Stehr71@yahoo.com", "Cary", "Rowe", "o9mWz3dU15", 3, "Cyril_Ziemann" },
                    { 17, 61, "Kelton18@yahoo.com", "Christine", "DuBuque", "0eE2MscBDd", 2, "Kirsten.Beahan" },
                    { 292, 61, "Blaise36@hotmail.com", "Mertie", "Muller", "dKFWKLdugY", 3, "Carmel_Koss58" },
                    { 110, 144, "Kimberly_Hermann@gmail.com", "Santino", "Ziemann", "lRjFwMgQ80", 2, "Sydnee_Pfeffer5" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 188, 144, "Duane.Block@gmail.com", "Una", "Raynor", "UdLRl8Yu2g", 3, "Ardith.Brown11" },
                    { 261, 125, "Helga74@hotmail.com", "Heber", "Pouros", "HOZFjurWj8", 3, "Macy.Abernathy" },
                    { 35, 297, "Jamil_Jones77@yahoo.com", "Rico", "D'Amore", "8EpJT8njy7", 3, "Pinkie25" },
                    { 174, 67, "Virginie49@hotmail.com", "Drew", "Kris", "ojipK8dIZD", 1, "Shyanne49" },
                    { 46, 113, "Edythe57@hotmail.com", "Emerald", "Collier", "xi8aJqaoY1", 2, "Joan.Howe47" },
                    { 244, 78, "Haven21@yahoo.com", "Nola", "O'Conner", "W1fKhBOFZQ", 2, "Myra.Prosacco" },
                    { 48, 296, "Nelson82@hotmail.com", "Lera", "Ratke", "o_KbRfIJf9", 3, "Bernadette75" },
                    { 78, 141, "Petra.Haley75@hotmail.com", "Adella", "Bergnaum", "5IDeFdGopH", 3, "Conner21" },
                    { 293, 48, "Roderick84@gmail.com", "Rico", "Wiegand", "muMhCZvPZ8", 3, "Lesly.Muller" },
                    { 205, 50, "Alvena_Heathcote85@yahoo.com", "Winona", "King", "ZD_nh9AYkJ", 3, "London.Roob" },
                    { 268, 150, "Alta_Kemmer91@gmail.com", "Yasmeen", "Sanford", "Ijip0N1zMx", 1, "Caesar.Moore" },
                    { 62, 185, "Dayton.Becker85@yahoo.com", "Filiberto", "Marquardt", "CzSdmiKIeD", 2, "Sonny88" },
                    { 222, 185, "Heloise.Moore@yahoo.com", "Ibrahim", "Reichel", "L0mUz0Rv0S", 3, "Fletcher89" },
                    { 225, 127, "Andreanne.Quitzon11@gmail.com", "Ophelia", "Jones", "dC4Mim8ZY9", 3, "Haven59" },
                    { 177, 138, "Travon.Herman@yahoo.com", "Cooper", "Zemlak", "KiUXbHFiVJ", 3, "Clemens_Hilll" },
                    { 227, 138, "Yvette_Miller27@gmail.com", "Carlotta", "Schumm", "CDBksRjXmE", 3, "Tyrese_McKenzie26" },
                    { 288, 138, "Remington.Koch@hotmail.com", "Norene", "Walker", "VJj1UvEDxe", 3, "Vivienne94" },
                    { 295, 138, "Eldred69@gmail.com", "Garrick", "Barrows", "4oCcV3hlK2", 3, "Bert.Towne" },
                    { 217, 11, "Pasquale40@hotmail.com", "Orville", "Kunde", "IUlpao9OuF", 1, "Isabelle_Reichert" },
                    { 132, 232, "Buford88@hotmail.com", "Yesenia", "Koepp", "qHoZwZamyl", 2, "Kiarra_Gleason66" },
                    { 113, 236, "Braeden46@hotmail.com", "Mario", "Auer", "TquwvSObSZ", 3, "Garland.Rowe" },
                    { 191, 260, "Linwood_Runolfsdottir25@gmail.com", "Brandon", "Bechtelar", "tC3VFmzUK8", 2, "Bethel93" },
                    { 37, 241, "Ramiro.Greenholt63@yahoo.com", "Taylor", "Schinner", "Ixw5LynPAn", 2, "Ruth.Harvey" },
                    { 119, 70, "Leonardo_Moore87@hotmail.com", "Marietta", "Wyman", "89FaC3tFP6", 1, "Dewayne54" },
                    { 195, 81, "Jovany_Goyette@hotmail.com", "Eileen", "Walker", "qdVsjiNgNk", 3, "Adah.Lehner" },
                    { 90, 81, "Abbie37@hotmail.com", "Jessy", "Collier", "WuSRcFSE5b", 3, "Rosendo_McKenzie" },
                    { 287, 248, "Berta26@hotmail.com", "Alverta", "Casper", "65ExHb2Z0J", 2, "Evalyn41" },
                    { 266, 160, "Marcus_Terry35@hotmail.com", "Arne", "Effertz", "o0t7hTgAtk", 2, "Dereck.Hagenes8" },
                    { 179, 56, "Buck.Wunsch@gmail.com", "Emmanuel", "Larkin", "Dc_TJXZl0N", 3, "Matteo_Lockman" },
                    { 56, 56, "Jesse78@gmail.com", "Polly", "Grimes", "T8VhP99eyX", 3, "Freeda_Mohr68" },
                    { 38, 266, "Jonatan.Kessler24@hotmail.com", "Syble", "Stracke", "3BF8WoIUPY", 1, "Thea_Gibson" },
                    { 262, 214, "Melisa0@yahoo.com", "Evie", "Larkin", "Ei8jEmZb5t", 3, "Jaunita.Lubowitz74" },
                    { 278, 96, "Leonard4@gmail.com", "Santa", "Schmidt", "yJzFMxJaol", 1, "Deron_Zemlak69" },
                    { 184, 96, "Emory46@gmail.com", "Merlin", "Fahey", "ik3W9Ts5mk", 1, "Kali90" },
                    { 173, 96, "Royce50@gmail.com", "Gisselle", "Rogahn", "H1nOrRYGqs", 1, "Thaddeus.Kuhlman" },
                    { 290, 27, "Jayda5@yahoo.com", "Guadalupe", "Murphy", "8ADAkQGnXP", 2, "Kenya48" },
                    { 101, 27, "Arlene_Mann@gmail.com", "Marguerite", "Crona", "cBYl34zhFk", 2, "Jettie.Will" },
                    { 283, 246, "Frieda.Moen@yahoo.com", "Korbin", "Zemlak", "lohSnliAaq", 2, "Kristofer.Batz" },
                    { 142, 246, "Vilma.Wintheiser@yahoo.com", "Alaina", "Leannon", "pUcqm5jgcE", 1, "Immanuel.Willms" },
                    { 15, 246, "Ofelia.Ankunding@yahoo.com", "Dejon", "Will", "biIniYIIxB", 2, "Cynthia.Murphy19" },
                    { 252, 234, "Sabrina_Pfeffer75@gmail.com", "Jayce", "Howell", "_e6kkv98os", 1, "Billy_Hane38" },
                    { 145, 241, "Destiney54@gmail.com", "Audrey", "Turner", "Eky8E1dVcb", 2, "Percy1" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 166, 241, "Aniyah50@hotmail.com", "Alva", "Welch", "JwnpgR3Zgg", 2, "Gerhard.Greenholt48" },
                    { 115, 256, "Dave_Kozey@gmail.com", "Gina", "Jacobs", "h7v26vOnR5", 3, "Chanelle.Shields" },
                    { 192, 256, "Larry_Mayert21@hotmail.com", "Julien", "Kuvalis", "TJMY0YirBl", 1, "Dashawn_Becker43" },
                    { 210, 212, "Winona50@yahoo.com", "Clinton", "McCullough", "RCEc7f0DXd", 2, "Eli.Walter" },
                    { 2, 59, "Jalon.Collier69@gmail.com", "Valentin", "Marks", "iBnHcWtjYK", 2, "Ismael_Lebsack89" },
                    { 14, 52, "Juvenal_Dicki@hotmail.com", "Brenna", "Veum", "H_YqXnV0Bc", 2, "Lonnie_Walter5" },
                    { 245, 290, "Kattie.Shanahan8@hotmail.com", "Elza", "Abernathy", "FTAbNqEo74", 3, "Summer19" },
                    { 122, 290, "Dannie_Abernathy50@yahoo.com", "Pauline", "Purdy", "nebSPybGdW", 2, "Adrien28" },
                    { 43, 205, "Fabiola22@gmail.com", "Jerod", "Bailey", "ICVOd3821a", 3, "Donavon.Schinner16" },
                    { 108, 135, "Jeremy_Labadie@hotmail.com", "Kasey", "Bogisich", "rKyeXytONn", 1, "Myrtie.Runolfsdottir" },
                    { 204, 277, "Tess.Dickens@hotmail.com", "Irma", "Cronin", "FoSyuEH6BE", 2, "Jaylin.Jones29" },
                    { 151, 238, "Raheem.Jenkins73@gmail.com", "Peter", "Fritsch", "52Eo0aGwnd", 1, "Estell_Nader" },
                    { 74, 166, "Erna.Larson@gmail.com", "Catharine", "Bergstrom", "eIzZQb6Qet", 2, "Kamron48" },
                    { 84, 238, "Aliza91@hotmail.com", "Polly", "Wintheiser", "kWlyGeJSgt", 2, "Quinn98" },
                    { 256, 82, "Garrett.Goyette@gmail.com", "Dion", "Simonis", "fA2jAILNkc", 3, "Adolfo_Hermiston96" },
                    { 140, 82, "Naomi_Feil@gmail.com", "Rosella", "Gerhold", "fdBLsSnfPj", 1, "Ellie73" },
                    { 49, 82, "Fabiola63@hotmail.com", "Domenico", "Lang", "XJZIyO5aHK", 2, "Leatha.Denesik51" },
                    { 274, 186, "Quinn.OKon87@hotmail.com", "Charles", "Krajcik", "24B81_Uy6G", 3, "Theresa33" },
                    { 224, 186, "Jaylon89@yahoo.com", "Hoyt", "Beatty", "NOpH0ECwrb", 1, "Sim18" },
                    { 155, 186, "Lura.Kuvalis@hotmail.com", "Geoffrey", "Zieme", "D8yeIwRmPp", 1, "Sigrid_Crooks40" },
                    { 96, 57, "Imelda_Adams78@hotmail.com", "Kaley", "Bergnaum", "y1bxzGALay", 3, "Lavonne46" },
                    { 255, 285, "Jo96@gmail.com", "Mallory", "Klocko", "puILEiFamc", 3, "Audreanne63" },
                    { 208, 256, "Philip_Dach32@yahoo.com", "Katlyn", "Schulist", "M9FVmGHXWB", 2, "Camren_MacGyver" },
                    { 213, 177, "Taylor_Olson@hotmail.com", "Rebeka", "Emmerich", "dFqM_85LAu", 1, "Brooklyn88" },
                    { 240, 212, "Alysson.Batz45@gmail.com", "Mason", "Haley", "Q0BKyr3Du9", 2, "Bella.Ratke" },
                    { 69, 166, "Soledad.Bergnaum72@gmail.com", "Bradford", "Feest", "FciwJ4a4xy", 2, "Pansy24" },
                    { 226, 243, "Shany_Hettinger@yahoo.com", "Janie", "Maggio", "DnkMkJCcEw", 3, "Melissa11" },
                    { 70, 299, "Jennyfer22@gmail.com", "Cyril", "Lehner", "dWYNpZ3GMQ", 3, "Sophie_Rutherford" },
                    { 42, 299, "Nona.Rogahn@yahoo.com", "Tavares", "Ferry", "s8DkO6VMY0", 1, "Nona.Schulist32" },
                    { 98, 102, "Tremaine.Hahn@hotmail.com", "Alex", "Vandervort", "u0qFiGgEez", 1, "Dahlia82" },
                    { 248, 278, "Breanna43@yahoo.com", "Germaine", "Crooks", "R76wiC1sPV", 2, "Alvera.Stark5" },
                    { 159, 278, "Jeanne_Rutherford@hotmail.com", "Julius", "Murazik", "Hm5cq4HxDi", 3, "Mireille6" },
                    { 92, 278, "Ron.Hirthe@gmail.com", "Rolando", "Bechtelar", "_EKe76kXVA", 3, "Presley.Stroman28" },
                    { 55, 278, "Baylee.Breitenberg@hotmail.com", "Eliezer", "Nolan", "_EV_2UIL2x", 3, "Coby.Quigley59" },
                    { 258, 255, "Jane_Wilderman48@gmail.com", "Rosalia", "Crona", "rvK4u1wVjU", 2, "Lilliana89" },
                    { 67, 159, "Bernhard_Jast@yahoo.com", "Mathilde", "Weissnat", "PV9adVUV3h", 1, "Isabella49" },
                    { 99, 103, "Charles_King37@hotmail.com", "Sydnie", "Lynch", "JAdzfSKsB1", 2, "Floyd.King" },
                    { 79, 103, "Kaci_Osinski@yahoo.com", "Enoch", "Ratke", "xoaHoVrTXq", 1, "Magdalena.Braun0" },
                    { 249, 29, "Holly.Lehner@yahoo.com", "Eliseo", "Lang", "F_MOhkeqjs", 2, "Drake_Harber" },
                    { 134, 29, "Adrain44@gmail.com", "Walter", "Blick", "PdVVbUuham", 2, "Arnoldo.Russel28" },
                    { 21, 174, "Sabryna.Auer60@gmail.com", "Pablo", "Macejkovic", "_3w1Px1Lfx", 2, "Melyna88" },
                    { 286, 108, "Stacy.Labadie@gmail.com", "Claire", "Howell", "vipn_DjyHL", 1, "Armando21" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 215, 45, "Kattie63@gmail.com", "Gabe", "Bruen", "t2jNwrTWEz", 2, "Ila.Greenfelder52" },
                    { 64, 45, "Darrel94@yahoo.com", "Mina", "Brakus", "vrgeitTfNI", 3, "Rudy37" },
                    { 153, 274, "Krystal_Labadie86@gmail.com", "Yolanda", "Brakus", "OGOEV6cUyv", 1, "Dangelo91" },
                    { 275, 77, "Trisha.Hauck41@yahoo.com", "Darrell", "Zulauf", "gSFiJQ_Mfl", 3, "Daryl88" },
                    { 185, 299, "Augustus_Jaskolski52@gmail.com", "Efren", "Kerluke", "Y5hzL1z1wo", 1, "Kylee_Schimmel" },
                    { 114, 300, "Clovis13@hotmail.com", "Annabell", "Purdy", "cU9kL4XZrJ", 3, "Patsy.Stoltenberg" },
                    { 269, 71, "Hazel87@gmail.com", "Misty", "Herman", "F8sXnYPT9I", 2, "Antonina.Beatty48" },
                    { 219, 294, "Lindsay16@hotmail.com", "Edgar", "Kozey", "BsB91JlfY1", 3, "Dane98" },
                    { 182, 170, "Ellen.Hauck@hotmail.com", "Oswald", "Spinka", "v1GWe4RWTP", 1, "Devyn.Rice92" },
                    { 199, 265, "Norwood59@hotmail.com", "Dannie", "Herzog", "sqg702WbAN", 1, "Kenna.Emard" },
                    { 89, 249, "Casimir67@yahoo.com", "Mae", "Greenfelder", "p5kzrChROw", 1, "Geoffrey.Schroeder" },
                    { 158, 109, "Nelson.Lynch@yahoo.com", "Marcelina", "Kling", "jK0oR_z9OL", 2, "Camryn_Bartoletti33" },
                    { 230, 24, "Vern.Schuppe76@gmail.com", "Kayden", "VonRueden", "0O36NUOIg9", 2, "Shawn78" },
                    { 88, 24, "Jack81@hotmail.com", "Leanna", "Reichel", "49u6QNgY2g", 1, "Caroline_Rodriguez20" },
                    { 26, 24, "Ora.Schiller@yahoo.com", "Buddy", "Mraz", "DjJqSLfHiP", 1, "Gerda26" },
                    { 280, 158, "Reynold18@gmail.com", "Florence", "Stroman", "2dETPB1KUX", 2, "Rachelle83" },
                    { 125, 158, "Maureen35@yahoo.com", "Curt", "Feest", "cUAcat3X9I", 2, "Ali_Goldner37" },
                    { 63, 166, "Veda.Balistreri@hotmail.com", "Bonnie", "Hintz", "jUOhgcru50", 1, "Cali_Mertz83" },
                    { 41, 293, "Evans.Bernhard32@hotmail.com", "Eleanore", "Heller", "UJrq7ma0V3", 1, "Isaias_Wiegand" },
                    { 51, 80, "Jordan83@yahoo.com", "Camryn", "Farrell", "gdYexu1_uQ", 3, "Vita3" },
                    { 218, 155, "Quinton.Bins93@gmail.com", "Damaris", "Heaney", "mogGqHmP9Q", 1, "Modesto.Johnston" },
                    { 267, 101, "Jerrod_Kub@hotmail.com", "Lessie", "Hyatt", "wC80i2rtVX", 3, "Angela12" },
                    { 57, 101, "Franco93@gmail.com", "Itzel", "Smith", "jcPWkZ0GMc", 3, "Corine80" },
                    { 82, 292, "Giovanny69@gmail.com", "Brenna", "Franecki", "1o8BCE5Cnq", 2, "Solon.Johnston" },
                    { 281, 12, "Kylee_Nolan46@hotmail.com", "Dorothea", "Emard", "__eE8Aab54", 1, "Robb60" },
                    { 257, 12, "Finn_Tremblay79@hotmail.com", "Dewitt", "Reichert", "GKPkyMVujC", 3, "Jaydon.Leannon" },
                    { 233, 12, "Dessie.Aufderhar@hotmail.com", "Warren", "Emard", "Y8zIl_XRZa", 1, "Chase50" },
                    { 126, 12, "Rebeka57@hotmail.com", "Henderson", "Schroeder", "NpQqlBZ7QH", 2, "Tessie_Harvey44" },
                    { 19, 293, "Zachary_Murphy@hotmail.com", "Donna", "Davis", "9n8s_FdIcn", 3, "Lindsay.Wilkinson" },
                    { 242, 216, "Ora.Cartwright@gmail.com", "Tiara", "Heidenreich", "pu38iCs4Lb", 1, "Renee.Kirlin" },
                    { 75, 86, "Delaney.Douglas@gmail.com", "Alford", "Williamson", "MW7kEGxomT", 3, "Xander54" },
                    { 172, 219, "Itzel_Ferry@yahoo.com", "Citlalli", "Morissette", "l5TR6ItUta", 2, "Josiane.Spinka" },
                    { 160, 46, "Rolando.Dach24@yahoo.com", "Dalton", "Torphy", "8ZiFFqeU2G", 1, "Aletha_Thompson" },
                    { 18, 39, "Evie.Runolfsdottir37@hotmail.com", "Unique", "Franecki", "cdTCu5XCEY", 1, "Curt45" },
                    { 33, 264, "Zella.Vandervort@yahoo.com", "Shawna", "Ernser", "IYrHN8ahfo", 1, "Eliezer.Abernathy27" },
                    { 237, 76, "Tyrique.Lebsack@yahoo.com", "Maia", "Dicki", "gXQBsE4JCi", 2, "Abigale79" },
                    { 236, 198, "Troy_Kertzmann@yahoo.com", "Zechariah", "Witting", "aaDVlmpnkC", 1, "Willis94" },
                    { 71, 107, "Kasandra.Hoppe16@gmail.com", "Charles", "Dickens", "bZjlxKE_Xi", 3, "Dario.Huel34" },
                    { 83, 270, "Julio56@yahoo.com", "Chris", "Hodkiewicz", "1VyQ0xlSgZ", 2, "Patience55" },
                    { 221, 95, "Candace.Roob@gmail.com", "Ottilie", "Kessler", "b4Lpk2BUIh", 1, "Richard.Prosacco20" },
                    { 34, 139, "Hollis.Metz@yahoo.com", "Trey", "Kuhn", "j5rPVQ6MdS", 3, "Darren.Feil83" },
                    { 109, 130, "Augusta_Kovacek@yahoo.com", "Urban", "Rodriguez", "Vcl2e2i9kH", 1, "Emilia60" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 254, 2, "Davon.Lockman@hotmail.com", "Kaylee", "Morissette", "fAXZMajvr9", 1, "Marianne45" },
                    { 156, 2, "Gregoria10@hotmail.com", "Pearlie", "Wisozk", "FaoE396Kf7", 2, "Wendy_Mohr" },
                    { 251, 84, "Godfrey.Feest90@yahoo.com", "Margot", "Gutkowski", "MXEXPAN58J", 1, "Brisa_Klocko74" },
                    { 20, 58, "Cornelius98@hotmail.com", "Kolby", "Dooley", "Rwbuzi0oLE", 2, "Candace.West46" },
                    { 129, 295, "Regan_Keeling@gmail.com", "Mariano", "Green", "F4UIIrxBPR", 1, "Natalie.Braun24" },
                    { 298, 14, "Ted_Lynch43@yahoo.com", "Kameron", "Herman", "xlWWu5opRI", 3, "Marcia42" },
                    { 118, 14, "Neal.Morar@hotmail.com", "Meghan", "Kohler", "dxkEfdcFlD", 3, "Ruthe10" },
                    { 284, 288, "Zoey.Funk89@gmail.com", "Cleve", "Wiza", "Zs_QrNvis8", 2, "Santino.Hegmann85" },
                    { 264, 288, "Tia.King69@gmail.com", "Hilton", "Hegmann", "JdAr_s39oi", 1, "Shane_Ward" },
                    { 175, 252, "Juvenal_Stracke46@gmail.com", "Carlie", "Cassin", "lS7LOhgS5E", 2, "Lamar.Littel55" },
                    { 265, 252, "Erna_Nikolaus@hotmail.com", "Muhammad", "Lebsack", "zseQMsP3xm", 1, "Maxie49" },
                    { 5, 164, "Ova_Jakubowski54@gmail.com", "Jackson", "Fisher", "5yWp2MxaSB", 3, "Alverta.Heaney" },
                    { 39, 164, "Jana.Crona@yahoo.com", "Noemi", "Jacobs", "ZNOeLMmEMF", 2, "Izabella.Reilly9" },
                    { 178, 276, "Lucious67@gmail.com", "Braden", "Mohr", "Rfa5QFWN0n", 3, "Aubree.Bayer47" },
                    { 157, 276, "Zion_Lebsack36@hotmail.com", "Jana", "Nikolaus", "xphcozh6to", 3, "Morgan34" },
                    { 200, 124, "Eva_Jerde28@hotmail.com", "Frida", "McKenzie", "eaQLFkofL2", 2, "Elvis.Auer6" },
                    { 117, 124, "Sarah61@yahoo.com", "Asa", "King", "AresP1nYto", 2, "Sarah_Flatley" },
                    { 294, 75, "Jamir.Jenkins74@yahoo.com", "Aniyah", "Romaguera", "pNKEGk2t71", 1, "Lupe.Schoen16" },
                    { 9, 75, "Kennith_Cole7@yahoo.com", "Rebeka", "Stroman", "SIznuxbH1y", 2, "Imelda.Maggio97" },
                    { 163, 251, "Ivah.Dare@hotmail.com", "Wilhelm", "McKenzie", "qkx9SNhhui", 3, "Mohamed.Hermann8" },
                    { 183, 73, "Kathryn51@hotmail.com", "Jerome", "O'Connell", "zp8_ODSgh4", 2, "Marianne_Kreiger30" },
                    { 131, 73, "Elsa.Tremblay11@hotmail.com", "Nash", "Zieme", "usSruglbsR", 1, "Westley.Kshlerin94" },
                    { 300, 110, "Maybell_Nitzsche7@hotmail.com", "Lenora", "Treutel", "fsCdIu9OeW", 3, "Jaydon67" },
                    { 45, 97, "Edgardo_Fahey@yahoo.com", "Casimer", "Mayer", "_Q1SpVWTs8", 2, "Brandyn.Price" },
                    { 105, 148, "Rodger_Bogan@hotmail.com", "Ryley", "Grant", "adayUx7qKP", 3, "Koby_Mills3" },
                    { 297, 230, "Rebeca26@gmail.com", "Mariana", "Runte", "OyGrNtSfMg", 3, "Tiara_Weissnat" },
                    { 44, 230, "Edd.Koss@gmail.com", "Alverta", "Grant", "jZLaYFkws1", 3, "Maynard_Fritsch93" },
                    { 65, 197, "Gisselle.OConner@hotmail.com", "Greta", "Ullrich", "9qtevLdTST", 2, "Fermin84" },
                    { 54, 197, "Rosetta.Lemke98@gmail.com", "Edgardo", "Simonis", "zcM7xNRxAZ", 2, "Susie_Lang" },
                    { 171, 180, "Jeff_Bayer@yahoo.com", "Ole", "Bogan", "Czj_r8lcEp", 3, "Andrew38" },
                    { 139, 22, "Vance13@hotmail.com", "Sydney", "Kirlin", "oSuW0PopWK", 3, "Myrna.Witting" },
                    { 220, 164, "Edward_Graham@gmail.com", "Harvey", "Quitzon", "YCrZShEpU5", 3, "Carlotta_Koelpin33" },
                    { 40, 164, "Allene.Schoen@gmail.com", "Liza", "Cummings", "wNimotHBME", 1, "Shania_Jacobi41" },
                    { 137, 148, "Troy_Pfeffer25@hotmail.com", "Cara", "Crist", "ux82WVTEYp", 1, "Art.Herman" },
                    { 59, 110, "Sydni1@hotmail.com", "Trenton", "Stroman", "0amLNcPEia", 2, "Eldora96" },
                    { 111, 40, "Makenna27@hotmail.com", "Eldon", "Bayer", "O7746fzQ8H", 2, "Alexys_Fahey89" },
                    { 164, 220, "Lura40@hotmail.com", "Vella", "Thompson", "kQTldaprvb", 2, "Wilfredo.Parisian" },
                    { 8, 189, "Keyon79@gmail.com", "Llewellyn", "Schamberger", "yUcocw03Yn", 1, "Juliet_Johns" },
                    { 229, 134, "Nathaniel_Schumm@gmail.com", "Lucious", "Runolfsdottir", "ojfDI1QUrG", 1, "Darien.Leannon54" },
                    { 250, 117, "Uriel.Walker15@hotmail.com", "Alexane", "Doyle", "bE8jIEld9M", 2, "Martine92" },
                    { 120, 18, "Magnus_Hagenes78@gmail.com", "Greg", "Runolfsdottir", "Fzp_POpNKY", 3, "Jennyfer_Thiel" },
                    { 197, 206, "Micaela.Rippin@gmail.com", "Alia", "Lemke", "E3VOS1VqND", 3, "Mack84" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 154, 206, "Aimee.Heaney8@hotmail.com", "Misael", "Kutch", "8z2DrF4TgE", 2, "Markus66" },
                    { 228, 126, "Jewell.Denesik84@gmail.com", "Celestino", "Kessler", "6hRC8EsAm1", 1, "Jonathon10" },
                    { 24, 126, "Amari_Wisozk69@hotmail.com", "Kurtis", "Wilkinson", "NGvbQUvA3v", 1, "Ari_Labadie97" },
                    { 11, 126, "Gudrun_Johnston@yahoo.com", "Geovany", "Considine", "chk4Q4e3EU", 1, "Lonnie19" },
                    { 22, 189, "Isabella93@yahoo.com", "Germaine", "Nolan", "k8Ms5SxNWV", 1, "Cristina.Wilkinson67" },
                    { 271, 115, "Lauretta81@hotmail.com", "Shany", "Boyer", "E1TSbbsk8F", 3, "Christa.Kozey" },
                    { 130, 240, "Jacky.Wehner@gmail.com", "Linnie", "Champlin", "Rh4WNf350P", 2, "Deven56" },
                    { 76, 298, "Kacey_Maggio@yahoo.com", "Karianne", "Runte", "5bskFb4NVS", 1, "Cortez.Doyle" },
                    { 93, 257, "Krystal_Deckow@yahoo.com", "Yvonne", "Mante", "zfZkul7EmR", 1, "Gregg.Abshire90" },
                    { 72, 257, "Laurine_Deckow@hotmail.com", "Matilde", "Feeney", "A3ZOOQacxT", 3, "Noble55" },
                    { 66, 178, "Cara_Quigley@yahoo.com", "Cloyd", "Hickle", "opnyRPfIom", 3, "Edward41" },
                    { 141, 239, "Karson_Gottlieb29@yahoo.com", "Bettye", "Stokes", "OjiqDJaP1W", 1, "Kristian_Walker65" },
                    { 180, 215, "Mohammad_Emard@yahoo.com", "Sean", "Carter", "IMS8r0VHsw", 2, "Laverne_Quitzon" },
                    { 239, 219, "Shyann61@hotmail.com", "Cary", "Ebert", "0Is47ynxIp", 1, "Tressa48" },
                    { 186, 219, "Lydia_Robel61@gmail.com", "Dortha", "Hand", "Q8Ksrop78F", 2, "Judd_Cremin80" },
                    { 124, 115, "Vernie.Lindgren64@hotmail.com", "Garland", "Grady", "lRkQjQ0Yo4", 3, "Terry32" },
                    { 202, 26, "Lilyan.Bruen@gmail.com", "Trinity", "Cassin", "DKBhQlvZsr", 2, "Virginia.Murazik" },
                    { 87, 189, "Elna.Stehr@hotmail.com", "Daphney", "O'Hara", "Sg_VqghmgN", 2, "Earlene_Gusikowski" },
                    { 276, 105, "Desmond.Abernathy@hotmail.com", "Jorge", "Kohler", "XjCIFRLFX2", 3, "Rhea.Ebert5" },
                    { 150, 220, "Marisa.Kuphal@yahoo.com", "Rhett", "Marks", "9PTFwSR_y9", 2, "Rosina.Morar46" },
                    { 231, 175, "Gretchen_Boyer@hotmail.com", "Dejuan", "Nader", "7dqDUCHseG", 3, "Lazaro_Kunde" },
                    { 104, 3, "Kiley_Schoen19@gmail.com", "Hayden", "O'Reilly", "N33xjiSafR", 2, "Leila.Casper70" },
                    { 52, 43, "Quinton7@hotmail.com", "Pearl", "Beatty", "rRaWwrsVJv", 2, "Imelda47" },
                    { 260, 149, "Alvis55@hotmail.com", "Amir", "Klocko", "e3eHjO7cTu", 3, "Sabina53" },
                    { 30, 191, "Otto_Wiegand@yahoo.com", "Lisette", "Parisian", "ChmRq1jDdK", 2, "Caden.Hilpert" },
                    { 91, 17, "Melody79@hotmail.com", "Prince", "Fisher", "S_l1LKcbB4", 1, "Loy_Hauck" },
                    { 10, 17, "Germaine.Rippin@hotmail.com", "Tianna", "Bechtelar", "y44alooDNd", 1, "Dino_Goodwin95" },
                    { 167, 182, "Bertrand.Terry@gmail.com", "Kole", "Wintheiser", "2u5Jdb2XRf", 3, "Josue89" },
                    { 161, 87, "Keira_Bins@gmail.com", "Lea", "Franecki", "CsjC2g3l8Q", 2, "Archibald8" },
                    { 146, 231, "Vinnie_Jenkins@hotmail.com", "Monique", "Littel", "U55oYFbRzl", 2, "Jimmie73" },
                    { 50, 231, "Alberta.Smitham40@gmail.com", "Adeline", "Nitzsche", "QTS5vEcMoh", 1, "Trevion85" },
                    { 201, 289, "Lionel46@gmail.com", "Durward", "Kessler", "fxtStILRVg", 1, "Gennaro_Heaney" },
                    { 97, 94, "Marie_Schuppe46@gmail.com", "Adella", "Stroman", "aZ_SG98uZB", 3, "Daisy.Kohler22" },
                    { 285, 184, "Juliana_Cronin79@yahoo.com", "Norval", "Little", "lzfaL21MMo", 2, "Evalyn_Boyer25" },
                    { 246, 184, "Carmen.Pfeffer90@gmail.com", "Caden", "Hammes", "JA4Uywp3Fa", 3, "Cameron33" },
                    { 190, 184, "Marcellus94@hotmail.com", "Constantin", "Williamson", "gmYZXcPZl9", 2, "Barrett.Nolan74" },
                    { 235, 183, "Terrell.Olson@hotmail.com", "Tessie", "Orn", "JD9KKyFd7C", 1, "Janessa_Schamberger53" },
                    { 291, 157, "Bill.Ondricka@gmail.com", "Loraine", "Waelchi", "lxjES24Cs3", 2, "Jacques_Kuhlman" },
                    { 13, 157, "Cornell.Kozey66@hotmail.com", "Celia", "Hamill", "IgmSnYNId0", 1, "Viviane95" },
                    { 81, 231, "Loyce40@yahoo.com", "Willie", "Blanda", "_bKk_OB4R2", 1, "Maggie95" },
                    { 29, 77, "Bennett.Davis29@gmail.com", "Onie", "Pollich", "H7qwE5AAp8", 2, "Bernadette40" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 10, "America Views", 127, "Creola90@gmail.com", "Donnelly Inc", 275, "(873) 168-9939", "www.Donnelly Inc.com" },
                    { 92, "Baumbach Passage", 224, "Russ_Reynolds@hotmail.com", "DuBuque LLC", 206, "(142) 490-7428", "www.DuBuque LLC.com" },
                    { 109, "Arlene Springs", 156, "Joshuah_Herman63@yahoo.com", "O'Reilly, Prohaska and Heidenreich", 58, "(397) 834-7485", "www.O'Reilly, Prohaska and Heidenreich.com" },
                    { 12, "Ana Ridge", 296, "Colten86@yahoo.com", "Weber, Daugherty and Klocko", 270, "(991) 166-3877", "www.Weber, Daugherty and Klocko.com" },
                    { 15, "Zemlak Overpass", 2, "Jordi.Zulauf@yahoo.com", "Kassulke and Sons", 270, "(342) 980-5029", "www.Kassulke and Sons.com" },
                    { 55, "Goodwin Vista", 158, "Marianne.Cummerata@gmail.com", "Schuppe Group", 299, "(212) 700-1363", "www.Schuppe Group.com" },
                    { 81, "Myrl Station", 19, "Maude_Gerlach@gmail.com", "Gottlieb Inc", 299, "(663) 206-3268", "www.Gottlieb Inc.com" },
                    { 91, "Kilback Lodge", 222, "Garth.Cummerata@yahoo.com", "Roberts, Aufderhar and Kuhn", 206, "(736) 816-8208", "www.Roberts, Aufderhar and Kuhn.com" },
                    { 85, "Bins Circle", 269, "Leone14@hotmail.com", "Feest Group", 299, "(969) 056-4467", "www.Feest Group.com" },
                    { 125, "Blaise Fords", 264, "Rhea_Connelly27@hotmail.com", "Aufderhar Inc", 299, "(544) 896-5284", "www.Aufderhar Inc.com" },
                    { 132, "Feest Lake", 138, "Casey.Hyatt@hotmail.com", "Langosh, Feeney and Gibson", 296, "(727) 587-8350", "www.Langosh, Feeney and Gibson.com" },
                    { 124, "Brown Glen", 151, "Marcella90@gmail.com", "Satterfield and Sons", 247, "(530) 121-2997", "www.Satterfield and Sons.com" },
                    { 26, "Robert Forks", 168, "Stefan76@gmail.com", "Hane, Stroman and Zieme", 77, "(660) 729-6362", "www.Hane, Stroman and Zieme.com" },
                    { 34, "Leslie Ville", 80, "Keshaun.Considine@gmail.com", "Morissette - Hauck", 77, "(823) 421-3927", "www.Morissette - Hauck.com" },
                    { 121, "Deckow Ridge", 113, "Makenna_Schulist@yahoo.com", "Schumm and Sons", 77, "(280) 088-0007", "www.Schumm and Sons.com" },
                    { 99, "Ward Groves", 162, "Aric11@hotmail.com", "Zieme Group", 299, "(418) 151-7110", "www.Zieme Group.com" },
                    { 127, "Osinski Throughway", 184, "Raoul.Bruen@gmail.com", "Auer, Kemmer and Greenholt", 53, "(275) 991-2280", "www.Auer, Kemmer and Greenholt.com" },
                    { 89, "Peter Greens", 20, "Rodger.Douglas@gmail.com", "Reilly Inc", 28, "(972) 535-1370", "www.Reilly Inc.com" },
                    { 7, "Aufderhar Plaza", 140, "Moises.Maggio@gmail.com", "Bayer, MacGyver and Hintz", 28, "(692) 216-5530", "www.Bayer, MacGyver and Hintz.com" },
                    { 79, "Blanca Terrace", 163, "Destiny.Kiehn91@gmail.com", "Watsica, Denesik and Quitzon", 105, "(275) 067-9987", "www.Watsica, Denesik and Quitzon.com" },
                    { 129, "Kovacek Way", 248, "Maureen.Veum13@hotmail.com", "Huel, McKenzie and King", 105, "(469) 134-3914", "www.Huel, McKenzie and King.com" },
                    { 13, "Orlando Crest", 145, "George.Pfannerstill65@hotmail.com", "Ratke, Yost and Kshlerin", 163, "(602) 816-3995", "www.Ratke, Yost and Kshlerin.com" },
                    { 17, "Katelin Hills", 173, "Irwin_Bauch29@yahoo.com", "Vandervort, Kuphal and Christiansen", 163, "(594) 513-5097", "www.Vandervort, Kuphal and Christiansen.com" },
                    { 70, "Flatley Underpass", 236, "Jaren66@gmail.com", "Schroeder LLC", 163, "(588) 731-4473", "www.Schroeder LLC.com" },
                    { 117, "Tristin Road", 233, "Domenica.Champlin26@gmail.com", "MacGyver and Sons", 163, "(742) 079-5564", "www.MacGyver and Sons.com" },
                    { 137, "Jaida Prairie", 288, "Isadore15@hotmail.com", "Emmerich, Cole and Stoltenberg", 178, "(720) 521-7644", "www.Emmerich, Cole and Stoltenberg.com" },
                    { 53, "Glover Harbors", 178, "Axel.Torphy14@yahoo.com", "Padberg LLC", 113, "(627) 415-4438", "www.Padberg LLC.com" },
                    { 150, "Champlin Tunnel", 142, "Matteo77@gmail.com", "Botsford - Greenholt", 113, "(190) 975-8005", "www.Botsford - Greenholt.com" },
                    { 110, "Bartholome Run", 228, "Maribel_Hudson@yahoo.com", "Bergstrom - Denesik", 187, "(549) 094-1840", "www.Bergstrom - Denesik.com" },
                    { 24, "Josiane Cliff", 233, "Vicente86@hotmail.com", "Hilll Inc", 148, "(924) 991-0889", "www.Hilll Inc.com" },
                    { 145, "Mathias Via", 160, "Jody.Beahan@gmail.com", "Cassin, Reichert and Jakubowski", 148, "(476) 090-7226", "www.Cassin, Reichert and Jakubowski.com" },
                    { 4, "Lemke Mountain", 157, "Lourdes_Maggio@yahoo.com", "Hodkiewicz, Lehner and Mills", 61, "(480) 146-6903", "www.Hodkiewicz, Lehner and Mills.com" },
                    { 136, "Zita Shore", 278, "Cortez_Mayert51@hotmail.com", "Osinski and Sons", 61, "(800) 041-2946", "www.Osinski and Sons.com" },
                    { 5, "Twila Fort", 268, "Madyson0@hotmail.com", "Marquardt - Simonis", 28, "(824) 055-1528", "www.Marquardt - Simonis.com" },
                    { 40, "Keeling Trail", 272, "Ena_Schuster22@hotmail.com", "Schuppe and Sons", 73, "(522) 280-2938", "www.Schuppe and Sons.com" },
                    { 54, "Ellis Glen", 75, "Jaqueline.Hackett68@hotmail.com", "Murazik and Sons", 73, "(886) 272-4373", "www.Murazik and Sons.com" },
                    { 82, "Gleason Plaza", 213, "Al.Mertz@gmail.com", "Pfannerstill Inc", 282, "(304) 885-3046", "www.Pfannerstill Inc.com" },
                    { 103, "McLaughlin Harbor", 144, "Tressa.Fay@yahoo.com", "Hegmann - DuBuque", 282, "(464) 402-4509", "www.Hegmann - DuBuque.com" },
                    { 108, "Leopold Burg", 99, "Leann51@hotmail.com", "Hermann Group", 288, "(414) 705-4081", "www.Hermann Group.com" },
                    { 66, "Antonina Stravenue", 199, "Naomi62@hotmail.com", "Hammes, Renner and Schmidt", 193, "(324) 557-6881", "www.Hammes, Renner and Schmidt.com" },
                    { 139, "Denesik Walk", 62, "Vernie45@gmail.com", "Carroll Inc", 193, "(706) 862-6152", "www.Carroll Inc.com" },
                    { 128, "Grady Ramp", 67, "Alejandra_Berge@gmail.com", "Bins and Sons", 277, "(559) 453-9588", "www.Bins and Sons.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 22, "Smith Shoal", 247, "Bret_Monahan8@gmail.com", "Adams LLC", 170, "(163) 381-0080", "www.Adams LLC.com" },
                    { 23, "Lemke Brook", 37, "Rosalinda_West44@hotmail.com", "Schinner - Jenkins", 216, "(330) 110-9703", "www.Schinner - Jenkins.com" },
                    { 76, "Buckridge Common", 94, "Jasmin.Hansen@yahoo.com", "Nicolas and Sons", 216, "(477) 297-5853", "www.Nicolas and Sons.com" },
                    { 111, "Green Union", 169, "Mckenzie.Kirlin@yahoo.com", "Ledner - Johnston", 216, "(409) 190-1178", "www.Ledner - Johnston.com" },
                    { 114, "Cali Lodge", 144, "Kendall11@yahoo.com", "Nitzsche, Kerluke and Corkery", 216, "(274) 842-4823", "www.Nitzsche, Kerluke and Corkery.com" },
                    { 115, "Royce Forge", 71, "Rosemarie_Turner@yahoo.com", "Dietrich Group", 216, "(216) 810-8908", "www.Dietrich Group.com" },
                    { 68, "Valentina Gardens", 64, "Christ_Corkery@gmail.com", "Heaney, Bernhard and Morar", 211, "(655) 161-6956", "www.Heaney, Bernhard and Morar.com" },
                    { 98, "Dimitri Estate", 62, "Mariana_Sanford@gmail.com", "Johnston, Sipes and Shanahan", 211, "(792) 338-0223", "www.Johnston, Sipes and Shanahan.com" },
                    { 126, "Nick Springs", 7, "Devan.Haag@yahoo.com", "Lowe and Sons", 211, "(828) 447-0051", "www.Lowe and Sons.com" },
                    { 3, "Champlin Port", 17, "Nicolas_Dickens@gmail.com", "Dibbert - Hintz", 12, "(630) 409-8096", "www.Dibbert - Hintz.com" },
                    { 90, "Barton Plaza", 184, "Demarco_Nolan36@yahoo.com", "Nitzsche - Russel", 12, "(408) 079-5690", "www.Nitzsche - Russel.com" },
                    { 104, "Aufderhar Vista", 138, "Alexandrine_Goldner@hotmail.com", "Kuphal LLC", 225, "(075) 719-5954", "www.Kuphal LLC.com" },
                    { 141, "Kulas Well", 245, "Sabrina_Kassulke52@yahoo.com", "Gerlach - Donnelly", 297, "(143) 408-9566", "www.Gerlach - Donnelly.com" },
                    { 146, "Johnson Light", 27, "Samantha17@gmail.com", "Schimmel, McCullough and Ruecker", 222, "(183) 788-1508", "www.Schimmel, McCullough and Ruecker.com" },
                    { 64, "Hahn Views", 242, "Domenica.Cremin45@gmail.com", "Wintheiser, Lueilwitz and Mills", 293, "(043) 868-6712", "www.Wintheiser, Lueilwitz and Mills.com" },
                    { 113, "Amya Viaduct", 72, "Alisha.Ruecker0@hotmail.com", "Hackett Group", 282, "(962) 310-8735", "www.Hackett Group.com" },
                    { 60, "Muller Summit", 104, "Matteo.Swaniawski@yahoo.com", "Kub, Berge and O'Hara", 189, "(670) 954-9619", "www.Kub, Berge and O'Hara.com" },
                    { 86, "Alayna Pines", 24, "Demond_Walter@yahoo.com", "Stokes, Ledner and Macejkovic", 189, "(146) 681-5975", "www.Stokes, Ledner and Macejkovic.com" },
                    { 94, "Wilfrid Divide", 82, "Krystina.Bosco46@gmail.com", "VonRueden - Heathcote", 189, "(724) 637-4503", "www.VonRueden - Heathcote.com" },
                    { 88, "Hermann Burgs", 8, "Kaley_Hand55@gmail.com", "Mills - McGlynn", 292, "(178) 948-7927", "www.Mills - McGlynn.com" },
                    { 95, "Casimer Stream", 16, "Lilly_Schoen19@yahoo.com", "Hauck, Leffler and Shields", 292, "(194) 324-6391", "www.Hauck, Leffler and Shields.com" },
                    { 18, "Johnson Ports", 176, "Whitney87@hotmail.com", "Dickens, Heidenreich and Dare", 188, "(374) 710-2939", "www.Dickens, Heidenreich and Dare.com" },
                    { 43, "Charley Mission", 115, "Joana12@hotmail.com", "Legros - Terry", 188, "(701) 852-7316", "www.Legros - Terry.com" },
                    { 96, "Pattie Wall", 78, "Norma_Vandervort@gmail.com", "Spinka LLC", 261, "(149) 167-8998", "www.Spinka LLC.com" },
                    { 25, "Frami Trail", 198, "Vincenza.Rowe73@yahoo.com", "Mitchell - Medhurst", 48, "(281) 989-6729", "www.Mitchell - Medhurst.com" },
                    { 69, "Schmeler Crescent", 53, "Halle_Stoltenberg64@gmail.com", "Wolf Inc", 48, "(787) 814-3964", "www.Wolf Inc.com" },
                    { 20, "Phyllis Fall", 116, "Wilfrid44@yahoo.com", "Harvey - Bosco", 78, "(374) 968-3914", "www.Harvey - Bosco.com" },
                    { 62, "Rath Mountain", 143, "Patricia_Cremin85@gmail.com", "Hintz Group", 78, "(622) 721-5995", "www.Hintz Group.com" },
                    { 93, "Mante Highway", 123, "Devin25@hotmail.com", "Reinger - Donnelly", 78, "(329) 465-0424", "www.Reinger - Donnelly.com" },
                    { 118, "Brielle Plaza", 172, "Adriana.Wisozk@gmail.com", "Boyer Inc", 78, "(054) 211-3231", "www.Boyer Inc.com" },
                    { 56, "Bernhard Place", 295, "Luis.Gerhold@gmail.com", "Schimmel LLC", 222, "(788) 626-3260", "www.Schimmel LLC.com" },
                    { 58, "Wehner Track", 196, "Leonel.Gleichner78@gmail.com", "Collier Inc", 44, "(189) 880-1636", "www.Collier Inc.com" },
                    { 52, "Bryon Squares", 295, "Brisa0@yahoo.com", "Dooley, Kreiger and Leffler", 35, "(489) 504-6844", "www.Dooley, Kreiger and Leffler.com" },
                    { 30, "Davion View", 218, "Constance_Erdman@hotmail.com", "Weissnat - Schulist", 171, "(361) 250-6332", "www.Weissnat - Schulist.com" },
                    { 38, "Bogan Divide", 110, "Ryann.Crona59@hotmail.com", "Oberbrunner - Weimann", 19, "(624) 694-2211", "www.Oberbrunner - Weimann.com" },
                    { 61, "Conn Lakes", 237, "Jeremie_Breitenberg@gmail.com", "Pagac, Gottlieb and Berge", 19, "(203) 143-3715", "www.Pagac, Gottlieb and Berge.com" },
                    { 106, "Clyde Corner", 278, "Bryon_Hickle4@yahoo.com", "Kihn and Sons", 19, "(934) 983-8833", "www.Kihn and Sons.com" },
                    { 73, "Zachariah Hills", 151, "Mason_Koss12@hotmail.com", "Daniel Group", 262, "(602) 302-2707", "www.Daniel Group.com" },
                    { 144, "Elza Gateway", 224, "Jace.Koss@hotmail.com", "McClure, Wintheiser and Walter", 56, "(673) 110-1829", "www.McClure, Wintheiser and Walter.com" },
                    { 28, "Rupert Ramp", 220, "Rickie.Stroman@yahoo.com", "Swift - Walsh", 179, "(618) 499-7635", "www.Swift - Walsh.com" },
                    { 134, "Boehm Keys", 296, "Forrest_Steuber62@yahoo.com", "Braun LLC", 179, "(383) 024-0204", "www.Braun LLC.com" },
                    { 138, "Torp Cove", 101, "Buck37@yahoo.com", "Cruickshank, Zboncak and Farrell", 90, "(330) 771-0881", "www.Cruickshank, Zboncak and Farrell.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 107, "Malcolm Heights", 11, "Autumn62@gmail.com", "Kuhic, Hermann and Roob", 195, "(238) 213-5817", "www.Kuhic, Hermann and Roob.com" },
                    { 48, "Keanu Ford", 107, "Robin_Weimann79@yahoo.com", "Zboncak, Ortiz and Bogan", 115, "(104) 761-7032", "www.Zboncak, Ortiz and Bogan.com" },
                    { 67, "Keven Spring", 293, "Joan_Ruecker3@hotmail.com", "Kemmer LLC", 115, "(805) 446-7558", "www.Kemmer LLC.com" },
                    { 123, "Ricardo Road", 157, "Magdalena_Rath88@gmail.com", "Mayert, Bashirian and Mills", 115, "(027) 657-9419", "www.Mayert, Bashirian and Mills.com" },
                    { 72, "Lehner Road", 58, "Felix.Wilkinson15@yahoo.com", "Gerhold, Cummings and Will", 255, "(301) 942-3217", "www.Gerhold, Cummings and Will.com" },
                    { 143, "Zemlak Springs", 89, "Destiney_Breitenberg59@yahoo.com", "Flatley - Schmeler", 255, "(781) 514-2461", "www.Flatley - Schmeler.com" },
                    { 19, "Legros Divide", 167, "Quentin_Reinger0@gmail.com", "Herzog, Paucek and Wunsch", 96, "(638) 696-7714", "www.Herzog, Paucek and Wunsch.com" },
                    { 2, "Schuppe Lake", 148, "Jarvis64@hotmail.com", "Paucek and Sons", 19, "(272) 969-7448", "www.Paucek and Sons.com" },
                    { 87, "Reilly Camp", 234, "Prudence.Parker@hotmail.com", "Jones Group", 96, "(365) 512-2010", "www.Jones Group.com" },
                    { 149, "Cora Green", 148, "Arne.Willms42@gmail.com", "Greenfelder - Rogahn", 267, "(517) 623-0566", "www.Greenfelder - Rogahn.com" },
                    { 8, "Schumm Mountain", 124, "Lisa37@hotmail.com", "Renner Group", 267, "(568) 414-1564", "www.Renner Group.com" },
                    { 120, "Tess Overpass", 233, "Dovie83@gmail.com", "Cole, Kunze and Schoen", 171, "(022) 168-3697", "www.Cole, Kunze and Schoen.com" },
                    { 14, "Nicolas Mews", 44, "Marshall.Carter@yahoo.com", "Crist - Morissette", 64, "(851) 893-4296", "www.Crist - Morissette.com" },
                    { 1, "Misael Tunnel", 72, "Adolfo6@yahoo.com", "Denesik Inc", 55, "(333) 436-7425", "www.Denesik Inc.com" },
                    { 41, "Luther Ford", 68, "Milo.Kling79@gmail.com", "Satterfield - Hoeger", 55, "(539) 368-1747", "www.Satterfield - Hoeger.com" },
                    { 83, "Adams Flats", 255, "Percy.Marvin80@yahoo.com", "Grant - Morar", 55, "(658) 049-2289", "www.Grant - Morar.com" },
                    { 57, "Vaughn Field", 289, "Toney5@yahoo.com", "Keebler, Dooley and Hayes", 70, "(735) 797-8845", "www.Keebler, Dooley and Hayes.com" },
                    { 100, "Spencer Forge", 51, "Marshall49@yahoo.com", "Bode - Frami", 70, "(596) 460-2167", "www.Bode - Frami.com" },
                    { 142, "Sporer Summit", 187, "Stephany_Berge@hotmail.com", "Schimmel, Funk and Satterfield", 70, "(006) 258-9868", "www.Schimmel, Funk and Satterfield.com" },
                    { 59, "Torrance Ways", 32, "Zola89@hotmail.com", "Pouros - Batz", 114, "(222) 494-0053", "www.Pouros - Batz.com" },
                    { 63, "Emmerich Points", 127, "Lily_Nader62@gmail.com", "Lynch, Koch and MacGyver", 114, "(922) 982-8806", "www.Lynch, Koch and MacGyver.com" },
                    { 84, "Goldner Bridge", 271, "Sedrick31@yahoo.com", "Stark Inc", 114, "(031) 655-7604", "www.Stark Inc.com" },
                    { 105, "Johnston Ranch", 24, "Isidro.Gerhold@yahoo.com", "Pfannerstill LLC", 114, "(367) 812-0499", "www.Pfannerstill LLC.com" },
                    { 131, "Anderson Divide", 138, "Shyann_Wilkinson54@gmail.com", "Blick - Ortiz", 219, "(239) 227-1659", "www.Blick - Ortiz.com" },
                    { 147, "Strosin Cove", 295, "Angelo.Kemmer@hotmail.com", "Ruecker - Lindgren", 219, "(276) 565-3561", "www.Ruecker - Lindgren.com" },
                    { 49, "Price Island", 171, "Norris96@yahoo.com", "Breitenberg and Sons", 57, "(744) 402-1536", "www.Breitenberg and Sons.com" },
                    { 65, "Smith Mall", 144, "Harrison.Towne@hotmail.com", "Little Inc", 267, "(859) 902-0263", "www.Little Inc.com" },
                    { 71, "Eliseo Greens", 118, "Lauryn.Mayer@yahoo.com", "Hilpert - Bechtelar", 43, "(026) 505-8170", "www.Hilpert - Bechtelar.com" },
                    { 122, "Emely Plain", 61, "Jonathon_Stanton6@hotmail.com", "Fay, Kovacek and Wilkinson", 257, "(159) 383-0728", "www.Fay, Kovacek and Wilkinson.com" },
                    { 140, "Electa River", 1, "Dasia.Jenkins@gmail.com", "Becker - Maggio", 75, "(180) 313-8702", "www.Becker - Maggio.com" },
                    { 11, "Kiehn Flats", 67, "Hoyt4@hotmail.com", "Batz - Adams", 120, "(809) 263-0032", "www.Batz - Adams.com" },
                    { 77, "Darryl Spring", 107, "Lula2@gmail.com", "Roob and Sons", 246, "(579) 344-6264", "www.Roob and Sons.com" },
                    { 16, "Pablo Heights", 198, "Gladyce42@yahoo.com", "Jenkins - Rogahn", 97, "(134) 509-2924", "www.Jenkins - Rogahn.com" },
                    { 116, "Durgan Shoals", 133, "Ernestina.Hane34@hotmail.com", "Mante - Morar", 97, "(594) 058-1790", "www.Mante - Morar.com" },
                    { 21, "Christian Fork", 126, "Bert86@hotmail.com", "Kirlin, Padberg and Schneider", 231, "(087) 131-6097", "www.Kirlin, Padberg and Schneider.com" },
                    { 74, "Ethan Brook", 149, "Chanel.Terry@hotmail.com", "Streich Group", 300, "(741) 619-1393", "www.Streich Group.com" },
                    { 6, "Crona Turnpike", 251, "Marshall_Cole@gmail.com", "Lueilwitz Inc", 118, "(698) 449-8309", "www.Lueilwitz Inc.com" },
                    { 44, "Bernhard Union", 59, "Beverly_Wisoky@hotmail.com", "Hammes Group", 298, "(835) 179-8091", "www.Hammes Group.com" },
                    { 101, "Grady Falls", 248, "Lyda97@hotmail.com", "Lindgren Inc", 298, "(394) 305-6043", "www.Lindgren Inc.com" },
                    { 50, "Zoie Fords", 223, "Enos6@hotmail.com", "Stehr and Sons", 71, "(466) 581-3799", "www.Stehr and Sons.com" },
                    { 31, "Swift Corners", 245, "Randi.Fahey91@yahoo.com", "Kuhn - Block", 5, "(889) 517-9736", "www.Kuhn - Block.com" },
                    { 33, "Casper Spur", 159, "Jolie.Dietrich@hotmail.com", "Braun, Sporer and Rau", 5, "(392) 660-8137", "www.Braun, Sporer and Rau.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 42, "Cole Villages", 264, "Hilbert.Raynor15@gmail.com", "Beer, Ryan and Raynor", 220, "(576) 891-9586", "www.Beer, Ryan and Raynor.com" },
                    { 75, "Marina Pike", 246, "Lucas53@gmail.com", "Hessel - Morissette", 43, "(056) 488-6052", "www.Hessel - Morissette.com" },
                    { 80, "Hand Pines", 246, "Jennifer.Powlowski@yahoo.com", "Cassin, Pollich and Sauer", 220, "(898) 253-6089", "www.Cassin, Pollich and Sauer.com" },
                    { 135, "Lafayette Points", 30, "Mellie.Von91@yahoo.com", "Huel - Price", 197, "(027) 204-6354", "www.Huel - Price.com" },
                    { 133, "Lockman Lodge", 214, "Antone89@yahoo.com", "Gibson and Sons", 197, "(615) 406-0377", "www.Gibson and Sons.com" },
                    { 47, "Stroman Junctions", 178, "Hallie44@yahoo.com", "Oberbrunner - VonRueden", 118, "(507) 778-2429", "www.Oberbrunner - VonRueden.com" },
                    { 51, "Addie Squares", 289, "Okey.Goyette@yahoo.com", "Blanda - Collins", 197, "(530) 613-6919", "www.Blanda - Collins.com" },
                    { 148, "Brian Vista", 298, "Dejah_Legros30@gmail.com", "Littel Inc", 75, "(633) 326-7943", "www.Littel Inc.com" },
                    { 37, "Jerde Stravenue", 285, "Kamryn38@hotmail.com", "Schaden - D'Amore", 66, "(887) 228-9136", "www.Schaden - D'Amore.com" },
                    { 119, "Clinton Manors", 172, "Gilda85@gmail.com", "Howell, Mosciski and Rempel", 197, "(125) 297-8431", "www.Howell, Mosciski and Rempel.com" },
                    { 97, "Effertz Squares", 80, "Johnathan29@yahoo.com", "Walter - Cassin", 66, "(684) 621-4901", "www.Walter - Cassin.com" },
                    { 130, "Jacobson Roads", 82, "Heloise.Legros@gmail.com", "Conn, Windler and Kautzer", 66, "(322) 016-1950", "www.Conn, Windler and Kautzer.com" },
                    { 27, "Dicki Grove", 274, "Willa15@hotmail.com", "Block - Frami", 72, "(119) 189-4452", "www.Block - Frami.com" },
                    { 39, "Arjun Spur", 141, "Trisha35@gmail.com", "Hermann - Sauer", 72, "(215) 944-5519", "www.Hermann - Sauer.com" },
                    { 45, "Freddie Mall", 171, "Arlo.Weissnat@gmail.com", "Beatty - Funk", 72, "(205) 585-2964", "www.Beatty - Funk.com" },
                    { 32, "Leola Lodge", 177, "Lysanne_Koepp@yahoo.com", "Rogahn, Lockman and Shanahan", 72, "(351) 984-2853", "www.Rogahn, Lockman and Shanahan.com" },
                    { 29, "Eddie Brooks", 196, "Jayde_Marquardt@hotmail.com", "Harris - Zieme", 197, "(551) 750-7882", "www.Harris - Zieme.com" },
                    { 112, "Anissa Bridge", 191, "Braeden86@gmail.com", "Bruen, Johnson and Morar", 72, "(102) 148-5500", "www.Bruen, Johnson and Morar.com" },
                    { 35, "Graciela Harbors", 192, "Marlene80@yahoo.com", "Marks, Legros and Parisian", 124, "(723) 785-8375", "www.Marks, Legros and Parisian.com" },
                    { 36, "Pagac Avenue", 32, "Lavern_Connelly@hotmail.com", "Conroy - Luettgen", 271, "(999) 051-3627", "www.Conroy - Luettgen.com" },
                    { 46, "Astrid Garden", 184, "Art.Kunde8@gmail.com", "Runolfsdottir, Schinner and Medhurst", 271, "(691) 750-3671", "www.Runolfsdottir, Schinner and Medhurst.com" },
                    { 9, "Mraz Greens", 51, "Graciela52@gmail.com", "Feil, Ortiz and Kuvalis", 197, "(412) 915-5091", "www.Feil, Ortiz and Kuvalis.com" },
                    { 78, "Casimir Motorway", 22, "Hosea_Collier@gmail.com", "Russel Inc", 72, "(525) 238-6926", "www.Russel Inc.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 66, new DateTime(2020, 8, 3, 7, 12, 45, 231, DateTimeKind.Local).AddTicks(8021), 502836, 43, "4198107" },
                    { 91, new DateTime(2020, 6, 18, 22, 17, 41, 983, DateTimeKind.Local).AddTicks(3842), 911066, 29, "9939444" },
                    { 98, new DateTime(2020, 12, 18, 10, 7, 48, 786, DateTimeKind.Local).AddTicks(3699), 331961, 29, "8550684" },
                    { 81, new DateTime(2020, 6, 24, 3, 5, 57, 71, DateTimeKind.Local).AddTicks(1856), 467874, 14, "4136846" },
                    { 3, new DateTime(2020, 8, 11, 22, 36, 46, 63, DateTimeKind.Local).AddTicks(1549), 409564, 49, "3382114" },
                    { 85, new DateTime(2020, 6, 3, 3, 7, 28, 201, DateTimeKind.Local).AddTicks(9497), 331570, 14, "5089672" },
                    { 50, new DateTime(2020, 11, 11, 17, 20, 3, 883, DateTimeKind.Local).AddTicks(4262), 385828, 29, "3490902" },
                    { 67, new DateTime(2020, 5, 26, 5, 33, 57, 623, DateTimeKind.Local).AddTicks(3599), 888454, 43, "3249657" },
                    { 68, new DateTime(2020, 7, 19, 7, 3, 38, 353, DateTimeKind.Local).AddTicks(2675), 635, 14, "5513622" },
                    { 42, new DateTime(2020, 4, 17, 0, 44, 7, 149, DateTimeKind.Local).AddTicks(7937), 932068, 19, "8392656" },
                    { 43, new DateTime(2020, 6, 11, 3, 54, 58, 230, DateTimeKind.Local).AddTicks(1177), 802987, 46, "9841336" },
                    { 22, new DateTime(2020, 5, 16, 4, 7, 45, 245, DateTimeKind.Local).AddTicks(2524), 644298, 82, "1038792" },
                    { 61, new DateTime(2020, 12, 31, 12, 19, 12, 215, DateTimeKind.Local).AddTicks(7366), 243579, 5, "4250685" },
                    { 19, new DateTime(2021, 2, 20, 3, 7, 45, 260, DateTimeKind.Local).AddTicks(3389), 581786, 5, "4966740" },
                    { 58, new DateTime(2020, 9, 6, 15, 42, 46, 844, DateTimeKind.Local).AddTicks(9908), 50245, 73, "4658256" },
                    { 14, new DateTime(2020, 4, 19, 9, 53, 2, 105, DateTimeKind.Local).AddTicks(6613), 541489, 73, "9777387" },
                    { 65, new DateTime(2021, 3, 5, 2, 14, 20, 151, DateTimeKind.Local).AddTicks(5529), 409559, 28, "4362166" },
                    { 40, new DateTime(2021, 3, 6, 2, 18, 47, 598, DateTimeKind.Local).AddTicks(7190), 211448, 65, "6354773" },
                    { 90, new DateTime(2021, 3, 12, 11, 19, 16, 251, DateTimeKind.Local).AddTicks(5902), 434473, 49, "9692759" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 15, new DateTime(2020, 4, 27, 23, 32, 38, 511, DateTimeKind.Local).AddTicks(111), 207189, 22, "9917221" },
                    { 24, new DateTime(2020, 9, 30, 7, 47, 44, 557, DateTimeKind.Local).AddTicks(1377), 865968, 22, "9942473" },
                    { 52, new DateTime(2020, 6, 17, 21, 5, 8, 702, DateTimeKind.Local).AddTicks(1231), 656215, 82, "1365406" },
                    { 97, new DateTime(2021, 3, 19, 20, 45, 54, 581, DateTimeKind.Local).AddTicks(6562), 606472, 49, "8007905" },
                    { 11, new DateTime(2020, 7, 16, 11, 43, 36, 772, DateTimeKind.Local).AddTicks(3001), 778901, 34, "5506815" },
                    { 87, new DateTime(2020, 11, 4, 19, 5, 3, 655, DateTimeKind.Local).AddTicks(2599), 430074, 11, "2367413" },
                    { 57, new DateTime(2020, 8, 5, 2, 2, 10, 982, DateTimeKind.Local).AddTicks(4298), 471712, 90, "6911484" },
                    { 51, new DateTime(2021, 1, 16, 7, 33, 58, 758, DateTimeKind.Local).AddTicks(382), 255206, 6, "1417679" },
                    { 10, new DateTime(2021, 2, 1, 11, 7, 32, 758, DateTimeKind.Local).AddTicks(8865), 801943, 44, "6844327" },
                    { 56, new DateTime(2020, 9, 26, 4, 55, 57, 667, DateTimeKind.Local).AddTicks(6179), 871465, 12, "8189761" },
                    { 39, new DateTime(2020, 8, 31, 19, 33, 1, 69, DateTimeKind.Local).AddTicks(8069), 627220, 85, "1129837" },
                    { 28, new DateTime(2020, 10, 21, 16, 29, 23, 153, DateTimeKind.Local).AddTicks(3750), 208572, 85, "4673747" },
                    { 13, new DateTime(2020, 9, 7, 5, 54, 55, 526, DateTimeKind.Local).AddTicks(6538), 875976, 34, "8532321" },
                    { 48, new DateTime(2020, 6, 12, 16, 16, 56, 844, DateTimeKind.Local).AddTicks(9751), 188624, 9, "4203025" },
                    { 23, new DateTime(2020, 9, 24, 10, 42, 25, 853, DateTimeKind.Local).AddTicks(129), 912177, 59, "7206508" },
                    { 44, new DateTime(2021, 3, 8, 9, 17, 18, 277, DateTimeKind.Local).AddTicks(7141), 485455, 27, "9886170" },
                    { 60, new DateTime(2020, 5, 14, 8, 51, 0, 65, DateTimeKind.Local).AddTicks(5002), 399498, 8, "6942153" },
                    { 88, new DateTime(2021, 3, 8, 11, 14, 26, 975, DateTimeKind.Local).AddTicks(2561), 2847, 56, "4958463" },
                    { 74, new DateTime(2021, 3, 27, 2, 5, 22, 787, DateTimeKind.Local).AddTicks(2256), 747935, 56, "5608409" },
                    { 54, new DateTime(2020, 12, 15, 2, 36, 31, 829, DateTimeKind.Local).AddTicks(4575), 116079, 56, "2301173" },
                    { 78, new DateTime(2021, 3, 31, 5, 27, 34, 402, DateTimeKind.Local).AddTicks(6769), 185609, 45, "2251084" },
                    { 73, new DateTime(2020, 12, 13, 13, 13, 40, 91, DateTimeKind.Local).AddTicks(8984), 1517, 45, "1556335" },
                    { 53, new DateTime(2020, 12, 27, 4, 17, 41, 295, DateTimeKind.Local).AddTicks(668), 698356, 45, "2226688" },
                    { 2, new DateTime(2020, 9, 3, 20, 56, 7, 796, DateTimeKind.Local).AddTicks(9094), 449924, 45, "7159868" },
                    { 46, new DateTime(2020, 5, 16, 14, 48, 24, 81, DateTimeKind.Local).AddTicks(9479), 987997, 36, "6581178" },
                    { 30, new DateTime(2020, 7, 14, 8, 2, 58, 360, DateTimeKind.Local).AddTicks(7453), 380082, 36, "8816803" },
                    { 37, new DateTime(2020, 4, 23, 14, 39, 20, 576, DateTimeKind.Local).AddTicks(9516), 472397, 20, "4135933" },
                    { 99, new DateTime(2020, 7, 16, 9, 5, 16, 823, DateTimeKind.Local).AddTicks(6214), 173159, 49, "4896917" },
                    { 26, new DateTime(2020, 6, 10, 2, 16, 0, 618, DateTimeKind.Local).AddTicks(1924), 426647, 6, "7097489" },
                    { 5, new DateTime(2021, 1, 17, 4, 7, 31, 457, DateTimeKind.Local).AddTicks(2012), 684046, 7, "4126864" },
                    { 77, new DateTime(2020, 8, 25, 2, 6, 47, 490, DateTimeKind.Local).AddTicks(7821), 472620, 18, "1334196" },
                    { 21, new DateTime(2020, 8, 22, 22, 47, 24, 288, DateTimeKind.Local).AddTicks(4208), 372233, 50, "6687855" },
                    { 49, new DateTime(2021, 4, 4, 10, 27, 19, 775, DateTimeKind.Local).AddTicks(6077), 698644, 78, "1834174" },
                    { 45, new DateTime(2021, 3, 29, 21, 37, 24, 965, DateTimeKind.Local).AddTicks(3803), 966817, 78, "3105990" },
                    { 20, new DateTime(2021, 3, 25, 21, 54, 2, 191, DateTimeKind.Local).AddTicks(3194), 756034, 37, "6459196" },
                    { 12, new DateTime(2020, 12, 11, 22, 21, 16, 135, DateTimeKind.Local).AddTicks(2702), 791405, 25, "6066304" },
                    { 75, new DateTime(2020, 7, 29, 11, 55, 54, 934, DateTimeKind.Local).AddTicks(5094), 805722, 21, "8069465" },
                    { 72, new DateTime(2020, 5, 31, 6, 28, 21, 720, DateTimeKind.Local).AddTicks(3473), 540565, 7, "8259527" },
                    { 41, new DateTime(2021, 3, 21, 17, 32, 7, 662, DateTimeKind.Local).AddTicks(6048), 541922, 7, "6186891" },
                    { 32, new DateTime(2021, 3, 12, 23, 34, 8, 643, DateTimeKind.Local).AddTicks(6546), 153023, 81, "8709841" },
                    { 9, new DateTime(2021, 1, 21, 9, 39, 47, 906, DateTimeKind.Local).AddTicks(6053), 372160, 81, "9183876" },
                    { 62, new DateTime(2020, 8, 25, 5, 15, 1, 752, DateTimeKind.Local).AddTicks(7278), 963426, 69, "2286539" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 47, new DateTime(2021, 4, 9, 9, 39, 49, 821, DateTimeKind.Local).AddTicks(6338), 197642, 31, "9373051" },
                    { 16, new DateTime(2021, 1, 17, 20, 59, 49, 771, DateTimeKind.Local).AddTicks(1629), 350532, 31, "7015800" },
                    { 4, new DateTime(2021, 1, 16, 12, 57, 0, 747, DateTimeKind.Local).AddTicks(4562), 671806, 35, "2567109" },
                    { 82, new DateTime(2020, 10, 31, 20, 21, 52, 283, DateTimeKind.Local).AddTicks(7539), 646911, 54, "7655235" },
                    { 79, new DateTime(2020, 11, 23, 11, 21, 1, 171, DateTimeKind.Local).AddTicks(8328), 614054, 54, "2044217" },
                    { 38, new DateTime(2020, 6, 11, 20, 17, 6, 958, DateTimeKind.Local).AddTicks(5704), 391456, 54, "9206631" },
                    { 55, new DateTime(2021, 3, 9, 14, 8, 47, 772, DateTimeKind.Local).AddTicks(2429), 156059, 72, "1725059" },
                    { 69, new DateTime(2021, 3, 27, 11, 46, 38, 902, DateTimeKind.Local).AddTicks(4156), 442815, 42, "7320915" },
                    { 64, new DateTime(2020, 9, 15, 9, 19, 27, 570, DateTimeKind.Local).AddTicks(5192), 553070, 41, "3418185" },
                    { 17, new DateTime(2020, 7, 1, 9, 42, 32, 79, DateTimeKind.Local).AddTicks(8816), 664482, 88, "4153426" },
                    { 83, new DateTime(2020, 7, 4, 12, 8, 45, 549, DateTimeKind.Local).AddTicks(9573), 725033, 50, "3743580" },
                    { 36, new DateTime(2020, 6, 20, 22, 23, 47, 485, DateTimeKind.Local).AddTicks(1131), 511144, 17, "9534346" },
                    { 96, new DateTime(2020, 10, 5, 5, 55, 38, 986, DateTimeKind.Local).AddTicks(8260), 208610, 17, "1220170" },
                    { 25, new DateTime(2020, 11, 22, 18, 12, 55, 22, DateTimeKind.Local).AddTicks(9419), 55469, 70, "4583273" },
                    { 33, new DateTime(2020, 12, 19, 7, 10, 55, 386, DateTimeKind.Local).AddTicks(1045), 660970, 18, "3553185" },
                    { 7, new DateTime(2020, 11, 12, 5, 13, 6, 453, DateTimeKind.Local).AddTicks(2490), 944954, 18, "8138264" },
                    { 92, new DateTime(2020, 9, 12, 9, 25, 3, 925, DateTimeKind.Local).AddTicks(7429), 547732, 30, "3857561" },
                    { 80, new DateTime(2021, 2, 25, 19, 6, 47, 257, DateTimeKind.Local).AddTicks(9271), 723931, 30, "6926191" },
                    { 71, new DateTime(2020, 7, 29, 18, 20, 3, 615, DateTimeKind.Local).AddTicks(9633), 41408, 30, "7584038" },
                    { 59, new DateTime(2020, 9, 3, 7, 43, 7, 606, DateTimeKind.Local).AddTicks(8353), 831763, 30, "6943115" },
                    { 76, new DateTime(2020, 11, 8, 10, 34, 52, 952, DateTimeKind.Local).AddTicks(4740), 257895, 15, "7762335" },
                    { 63, new DateTime(2021, 4, 1, 23, 15, 29, 216, DateTimeKind.Local).AddTicks(3430), 799139, 15, "9234389" },
                    { 8, new DateTime(2020, 5, 29, 10, 48, 12, 145, DateTimeKind.Local).AddTicks(8178), 325818, 52, "2800823" },
                    { 94, new DateTime(2020, 9, 24, 6, 24, 59, 601, DateTimeKind.Local).AddTicks(1670), 971979, 2, "8223054" },
                    { 27, new DateTime(2020, 7, 23, 13, 3, 14, 158, DateTimeKind.Local).AddTicks(2949), 968404, 74, "8458641" },
                    { 86, new DateTime(2020, 12, 18, 6, 7, 40, 36, DateTimeKind.Local).AddTicks(525), 939511, 2, "4624131" },
                    { 29, new DateTime(2020, 7, 13, 19, 17, 5, 455, DateTimeKind.Local).AddTicks(720), 629055, 2, "2894223" },
                    { 35, new DateTime(2020, 12, 25, 17, 53, 30, 58, DateTimeKind.Local).AddTicks(381), 767221, 23, "2974543" },
                    { 1, new DateTime(2020, 11, 1, 3, 13, 18, 535, DateTimeKind.Local).AddTicks(1656), 285460, 1, "2805665" },
                    { 31, new DateTime(2020, 7, 17, 18, 39, 15, 471, DateTimeKind.Local).AddTicks(8979), 253409, 26, "2311316" },
                    { 6, new DateTime(2020, 11, 26, 1, 18, 58, 915, DateTimeKind.Local).AddTicks(5521), 462952, 26, "8270081" },
                    { 18, new DateTime(2020, 7, 9, 3, 11, 37, 139, DateTimeKind.Local).AddTicks(2624), 775394, 13, "8850384" },
                    { 95, new DateTime(2020, 11, 3, 0, 22, 44, 756, DateTimeKind.Local).AddTicks(2680), 12034, 24, "8833795" },
                    { 84, new DateTime(2020, 7, 18, 2, 17, 40, 433, DateTimeKind.Local).AddTicks(5993), 265636, 24, "1090536" },
                    { 93, new DateTime(2020, 12, 21, 7, 55, 32, 322, DateTimeKind.Local).AddTicks(2112), 188633, 71, "2142248" },
                    { 34, new DateTime(2020, 4, 21, 22, 3, 11, 109, DateTimeKind.Local).AddTicks(7942), 773660, 71, "1014690" },
                    { 70, new DateTime(2020, 6, 21, 23, 52, 0, 171, DateTimeKind.Local).AddTicks(8303), 998116, 2, "3777489" },
                    { 89, new DateTime(2020, 11, 9, 10, 0, 52, 593, DateTimeKind.Local).AddTicks(1677), 905306, 88, "9901930" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 140, 64, 23, 459065, new DateTime(2020, 11, 7, 7, 49, 14, 883, DateTimeKind.Local).AddTicks(3592), "Veritatis ut quam ipsam consequatur ducimus. Esse eum exercitationem ipsa placeat officiis modi. Eveniet perspiciatis eligendi magnam doloremque deserunt et perferendis eveniet error. Eos iure iste molestiae deserunt in voluptas beatae eos. Deleniti quis blanditiis nulla aut maiores quaerat earum possimus nesciunt." },
                    { 547, 91, 36, 76691, new DateTime(2021, 1, 21, 1, 35, 6, 61, DateTimeKind.Local).AddTicks(3402), "quisquam" },
                    { 174, 98, 63, 257834, new DateTime(2021, 4, 12, 2, 40, 43, 849, DateTimeKind.Local).AddTicks(8294), "Qui dolor aut ipsum." },
                    { 415, 98, 90, 133164, new DateTime(2021, 3, 24, 17, 15, 28, 641, DateTimeKind.Local).AddTicks(2351), "Perferendis aperiam odio eos voluptatem consequatur. Officiis exercitationem aut tenetur delectus mollitia voluptatem incidunt dolorem repellat. Facilis quas est nam dolor accusantium sit ut." },
                    { 424, 98, 55, 986648, new DateTime(2020, 7, 6, 23, 51, 24, 197, DateTimeKind.Local).AddTicks(6148), "ipsam" },
                    { 430, 98, 123, 953792, new DateTime(2020, 9, 24, 0, 43, 3, 950, DateTimeKind.Local).AddTicks(2674), "Adipisci mollitia non nemo." },
                    { 476, 98, 67, 463363, new DateTime(2020, 12, 26, 4, 8, 11, 863, DateTimeKind.Local).AddTicks(3813), "Quae alias placeat consectetur similique similique et consequatur nihil eum. Non id eveniet et et quo tempora. Qui dolores velit voluptatem nam labore. Culpa labore ut." },
                    { 72, 68, 24, 156753, new DateTime(2020, 9, 28, 8, 28, 54, 96, DateTimeKind.Local).AddTicks(6206), "placeat" },
                    { 276, 68, 78, 392979, new DateTime(2020, 6, 18, 10, 53, 25, 37, DateTimeKind.Local).AddTicks(4316), "Iste et ullam culpa enim et sequi architecto omnis dolores.\nTotam dicta incidunt in facere odit et ab perspiciatis.\nAspernatur dolore ullam consequatur qui nobis temporibus.\nOmnis voluptas impedit a totam inventore vitae recusandae.\nCulpa rerum neque rem blanditiis suscipit occaecati unde aspernatur quia." },
                    { 393, 68, 114, 289691, new DateTime(2021, 1, 3, 2, 44, 26, 801, DateTimeKind.Local).AddTicks(4821), "ipsum" },
                    { 119, 81, 85, 641019, new DateTime(2021, 1, 27, 12, 37, 3, 230, DateTimeKind.Local).AddTicks(1856), "Quia quis nostrum tempora in nihil.\nQuisquam quis eos.\nAut nam delectus dolor laborum enim voluptatem animi.\nTempore non minima nam placeat esse libero adipisci asperiores nisi.\nQuam asperiores ipsa." },
                    { 125, 81, 80, 618886, new DateTime(2020, 5, 1, 9, 42, 9, 466, DateTimeKind.Local).AddTicks(5759), "reprehenderit" },
                    { 154, 81, 25, 169989, new DateTime(2020, 7, 18, 7, 48, 42, 564, DateTimeKind.Local).AddTicks(8237), "Autem voluptates harum est ullam hic ullam aut deleniti nostrum. Non id explicabo id sit consequatur itaque vel dolores rerum. Quod similique iste consequuntur sunt." },
                    { 236, 81, 84, 307760, new DateTime(2020, 7, 9, 4, 4, 52, 270, DateTimeKind.Local).AddTicks(6386), "Repellendus nobis laboriosam facilis veritatis eaque optio quidem suscipit.\nQui nihil magni officia voluptas.\nVitae a quaerat.\nReprehenderit dolores sed nihil possimus vel.\nQuia non corrupti dolores nostrum voluptatibus rerum aperiam." },
                    { 245, 81, 143, 524407, new DateTime(2020, 6, 27, 7, 38, 49, 174, DateTimeKind.Local).AddTicks(437), "Architecto modi neque id eos. Et tenetur deleniti qui doloremque. Esse architecto consequuntur omnis esse modi quos tenetur. Deserunt sapiente voluptatem ea deserunt est consequatur. Ducimus vitae aut. Atque aliquid voluptatem eum dolorem tenetur." },
                    { 283, 81, 70, 676779, new DateTime(2020, 11, 13, 21, 1, 25, 815, DateTimeKind.Local).AddTicks(3378), "molestiae" },
                    { 456, 91, 26, 477034, new DateTime(2020, 5, 21, 18, 54, 12, 406, DateTimeKind.Local).AddTicks(8579), "Exercitationem quisquam provident itaque autem." },
                    { 453, 91, 48, 778629, new DateTime(2020, 7, 19, 4, 7, 16, 38, DateTimeKind.Local).AddTicks(7172), "Reprehenderit aut veritatis maiores perferendis velit fugiat quo et. Quia laboriosam voluptatum et quam. Quo tempora cumque reprehenderit nam expedita est cum sunt vel. Non similique sit dolores alias et et enim non. Consequatur velit odio sit consequatur recusandae beatae." },
                    { 218, 91, 17, 978788, new DateTime(2020, 6, 24, 19, 45, 8, 285, DateTimeKind.Local).AddTicks(2910), "Ipsum consectetur omnis facilis iste. Voluptatum quia esse est dolores animi assumenda eligendi non dolorem. Ut aut id eaque hic omnis sint est optio. Veritatis mollitia officia quis. Repellendus voluptas est consectetur aspernatur soluta. A et reiciendis consequatur eos." },
                    { 76, 91, 33, 554371, new DateTime(2021, 1, 11, 7, 30, 23, 899, DateTimeKind.Local).AddTicks(2348), "deserunt" },
                    { 101, 52, 72, 352120, new DateTime(2021, 1, 27, 6, 1, 44, 672, DateTimeKind.Local).AddTicks(9367), "quasi" },
                    { 269, 52, 80, 793551, new DateTime(2020, 6, 18, 12, 20, 32, 960, DateTimeKind.Local).AddTicks(2275), "Dolores assumenda ut aut ut facere consequatur molestiae tenetur. A omnis molestiae dolore harum rerum. Sequi repudiandae alias pariatur voluptatem. Ea nulla dolorum et ipsum." },
                    { 357, 52, 22, 290144, new DateTime(2021, 2, 4, 15, 5, 4, 616, DateTimeKind.Local).AddTicks(7337), "Incidunt error quam nam accusantium consequatur illo. Tempore et et quas expedita qui animi adipisci. Est sed consequatur suscipit accusantium. Aliquid non quidem omnis quidem qui consequuntur. Nisi sit ea maxime dolor eius ad dignissimos maxime aliquam. Ut et velit eveniet inventore." },
                    { 377, 52, 17, 63888, new DateTime(2020, 6, 13, 3, 50, 30, 52, DateTimeKind.Local).AddTicks(1940), "Ut totam voluptatibus.\nDelectus voluptates velit ut debitis earum in deserunt aut.\nAd nostrum facilis fuga exercitationem porro occaecati.\nIncidunt rerum soluta omnis in." },
                    { 407, 52, 35, 693172, new DateTime(2020, 12, 14, 11, 13, 19, 255, DateTimeKind.Local).AddTicks(4031), "Beatae omnis ipsam rerum eveniet ipsum." },
                    { 29, 42, 115, 583144, new DateTime(2020, 8, 4, 13, 35, 38, 868, DateTimeKind.Local).AddTicks(6034), "excepturi" },
                    { 41, 42, 75, 91184, new DateTime(2021, 1, 5, 22, 40, 6, 338, DateTimeKind.Local).AddTicks(1667), "Nihil deserunt expedita et illo rerum quis officia." },
                    { 367, 81, 30, 424752, new DateTime(2020, 7, 20, 18, 31, 6, 270, DateTimeKind.Local).AddTicks(7355), "commodi" },
                    { 111, 42, 131, 983319, new DateTime(2020, 9, 7, 5, 16, 25, 690, DateTimeKind.Local).AddTicks(3602), "Omnis ut quas distinctio voluptate. Aliquam et rerum doloremque dolor qui voluptates eveniet qui dicta. Facere nesciunt error est cupiditate totam aut. Et fuga ut quia. Atque ea deleniti in et assumenda blanditiis nisi reprehenderit ipsam. Sed sunt ab nemo voluptas." },
                    { 309, 42, 31, 230588, new DateTime(2021, 1, 2, 12, 49, 26, 499, DateTimeKind.Local).AddTicks(5003), "assumenda" },
                    { 358, 42, 123, 608709, new DateTime(2020, 11, 24, 6, 47, 6, 464, DateTimeKind.Local).AddTicks(1335), "Doloribus et sed hic quasi qui." },
                    { 527, 42, 41, 588331, new DateTime(2020, 8, 17, 2, 23, 52, 668, DateTimeKind.Local).AddTicks(7693), "Ut culpa aperiam et aut maxime nobis ut. Pariatur nisi quidem deserunt quia ut vel. Vel molestias ut consequatur qui laborum nisi perferendis. Commodi inventore ad." },
                    { 171, 50, 130, 960937, new DateTime(2021, 4, 3, 5, 15, 29, 757, DateTimeKind.Local).AddTicks(2435), "Odit a modi mollitia.\nOccaecati et error iure ipsam quia rerum voluptatem et.\nMinima dolore iure voluptatem sit velit cupiditate corporis et quis." },
                    { 519, 50, 10, 750588, new DateTime(2021, 2, 4, 9, 51, 52, 341, DateTimeKind.Local).AddTicks(2766), "Nesciunt sunt numquam fuga." },
                    { 576, 50, 43, 967456, new DateTime(2020, 7, 13, 20, 56, 22, 260, DateTimeKind.Local).AddTicks(3305), "Natus dicta in velit amet alias enim exercitationem. Dolores suscipit voluptatem necessitatibus. Quisquam soluta consequuntur recusandae enim. Consequatur exercitationem ea molestiae ex iusto. Amet officiis beatae molestiae quas. Harum ea quis quo consequatur et aut perspiciatis minima totam." },
                    { 10, 91, 96, 444340, new DateTime(2020, 10, 20, 4, 52, 0, 802, DateTimeKind.Local).AddTicks(5135), "Voluptatum cum necessitatibus atque molestiae qui fugiat dolores. In sunt enim quam velit illo eius enim sit dignissimos. Ut eveniet et voluptate laborum. Itaque non consequatur facilis ullam dolorum et enim ipsam quam. Eaque nihil dolor officia architecto." },
                    { 168, 42, 136, 246022, new DateTime(2021, 2, 13, 6, 6, 56, 772, DateTimeKind.Local).AddTicks(6874), "Optio unde amet est quo est odit reiciendis. Quos vitae itaque. Facere accusamus quia ullam. Eveniet non incidunt. Excepturi beatae quia saepe totam et. Sunt voluptatibus laudantium." },
                    { 38, 52, 34, 38824, new DateTime(2021, 2, 9, 21, 54, 42, 628, DateTimeKind.Local).AddTicks(4642), "Quaerat deserunt placeat dolor dolor libero." },
                    { 463, 81, 125, 517168, new DateTime(2020, 12, 15, 1, 47, 2, 47, DateTimeKind.Local).AddTicks(7350), "Dolor odio explicabo." },
                    { 11, 85, 41, 637821, new DateTime(2021, 3, 10, 14, 54, 11, 133, DateTimeKind.Local).AddTicks(5765), "Consequuntur numquam ea. Sit aspernatur in consequatur deleniti. Unde est fuga quia nostrum ad rem et ratione." },
                    { 348, 3, 94, 473612, new DateTime(2020, 7, 24, 15, 50, 19, 714, DateTimeKind.Local).AddTicks(3985), "Blanditiis explicabo officia porro asperiores est molestiae.\nAut minima dolore earum voluptatem quibusdam et reprehenderit nisi.\nId aperiam consequuntur unde omnis iste debitis.\nOdio quisquam blanditiis unde reprehenderit laudantium minus cum sit.\nUnde neque facere ratione repellat aut harum labore." },
                    { 554, 3, 44, 204598, new DateTime(2021, 2, 17, 9, 14, 22, 674, DateTimeKind.Local).AddTicks(7015), "Eum exercitationem quos." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 556, 3, 81, 465398, new DateTime(2021, 2, 17, 2, 59, 44, 171, DateTimeKind.Local).AddTicks(4710), "Earum eos provident nemo id ex.\nVelit non ipsam saepe placeat animi rerum ullam est aut.\nRerum quo voluptates non minima at doloremque id.\nIusto qui quasi laboriosam.\nEt beatae ipsam et sequi eius doloremque qui nemo aut.\nQuae eligendi unde ipsam assumenda." },
                    { 561, 3, 34, 666946, new DateTime(2020, 9, 20, 3, 46, 12, 124, DateTimeKind.Local).AddTicks(5510), "Repudiandae dolorem nihil asperiores accusamus voluptatem nobis mollitia. Nulla expedita aliquid. Perferendis nobis in nisi officia. Doloribus molestiae nemo assumenda harum ab eligendi similique." },
                    { 584, 3, 136, 681944, new DateTime(2020, 11, 18, 13, 20, 2, 891, DateTimeKind.Local).AddTicks(213), "Repellendus et architecto sint temporibus enim incidunt non magni vero.\nDolor fugit corporis delectus ut non voluptas.\nNihil occaecati quos harum.\nQuia facere illo commodi voluptatibus autem labore.\nTempore atque dicta aperiam perferendis quas est." },
                    { 83, 90, 127, 452192, new DateTime(2020, 7, 18, 5, 39, 10, 417, DateTimeKind.Local).AddTicks(9798), "Corporis laudantium nam aut illum quos nobis.\nExpedita in id vitae velit est.\nVoluptas qui non totam corrupti laudantium quos maxime optio.\nRatione dolorem quos.\nSit reiciendis quia minima." },
                    { 124, 90, 78, 984113, new DateTime(2020, 9, 9, 19, 24, 3, 363, DateTimeKind.Local).AddTicks(8300), "Est et adipisci iure repudiandae accusantium." },
                    { 143, 90, 35, 126002, new DateTime(2020, 10, 14, 7, 26, 33, 519, DateTimeKind.Local).AddTicks(2030), "Corrupti minima atque consequatur. Laboriosam libero et totam qui non. Saepe vel est rerum et laudantium unde et accusamus harum. Vero quo accusantium cum impedit culpa. Libero aut quia." },
                    { 220, 90, 107, 581364, new DateTime(2021, 3, 24, 3, 47, 17, 160, DateTimeKind.Local).AddTicks(8530), "vitae" },
                    { 408, 90, 111, 329874, new DateTime(2020, 8, 31, 11, 43, 21, 767, DateTimeKind.Local).AddTicks(3018), "Nisi quo error voluptatem.\nDebitis minus commodi sit nostrum est maiores.\nVoluptatum sit quasi amet voluptas et distinctio.\nVero aspernatur hic aut magnam nemo reiciendis beatae.\nIure labore assumenda esse quos et debitis accusantium necessitatibus ut.\nBeatae inventore rem fuga expedita sit optio sequi." },
                    { 536, 90, 49, 780627, new DateTime(2020, 4, 30, 22, 41, 30, 303, DateTimeKind.Local).AddTicks(8919), "Molestiae dolorum aut autem sint ex repellendus esse esse qui." },
                    { 68, 97, 123, 242594, new DateTime(2020, 5, 25, 17, 7, 10, 826, DateTimeKind.Local).AddTicks(1982), "Facilis consequatur dolor vel non.\nMaiores tempora laborum itaque et.\nMolestiae odio autem impedit molestias optio.\nNesciunt quas cupiditate placeat aut nulla." },
                    { 75, 97, 47, 148566, new DateTime(2020, 9, 16, 19, 41, 6, 974, DateTimeKind.Local).AddTicks(146), "Explicabo eos cumque omnis." },
                    { 229, 97, 126, 230856, new DateTime(2020, 12, 25, 10, 35, 44, 11, DateTimeKind.Local).AddTicks(5761), "Labore modi blanditiis odit modi.\nVero id ut delectus magnam qui recusandae soluta dolores.\nIn et quibusdam voluptas.\nMinus cumque minima dolorum ipsa.\nRerum autem aut quos similique accusamus quia eum sed magni.\nArchitecto rem et et fugit dolore." },
                    { 432, 97, 87, 586808, new DateTime(2020, 9, 10, 16, 28, 1, 965, DateTimeKind.Local).AddTicks(6239), "In et quia sint ullam ut quidem quasi. Quis et numquam quisquam. Vel molestiae quo ad. Optio quisquam nihil laborum perferendis vel quasi. Nihil est quo provident ipsum dolor. Perspiciatis ut praesentium omnis maiores consequatur est voluptatem doloremque." },
                    { 289, 3, 7, 90226, new DateTime(2020, 10, 4, 23, 44, 20, 443, DateTimeKind.Local).AddTicks(9907), "deleniti" },
                    { 81, 3, 56, 970800, new DateTime(2020, 8, 16, 6, 32, 10, 175, DateTimeKind.Local).AddTicks(6654), "Recusandae ex possimus consequatur excepturi eveniet aut similique voluptas ea." },
                    { 4, 3, 60, 803258, new DateTime(2020, 7, 2, 13, 42, 4, 377, DateTimeKind.Local).AddTicks(1210), "Minus voluptatem quidem deserunt aut suscipit harum." },
                    { 451, 67, 32, 605172, new DateTime(2020, 5, 10, 22, 37, 51, 502, DateTimeKind.Local).AddTicks(7958), "Aspernatur eum sed animi." },
                    { 46, 85, 5, 780057, new DateTime(2020, 9, 16, 13, 54, 19, 911, DateTimeKind.Local).AddTicks(9887), "Fuga qui veniam." },
                    { 197, 85, 20, 344142, new DateTime(2020, 5, 15, 10, 54, 58, 338, DateTimeKind.Local).AddTicks(7486), "Aliquam qui adipisci sed dolore.\nEt fuga a nisi porro.\nVoluptatem et neque in quisquam qui quam vitae.\nRatione dolorem est ullam.\nAperiam possimus vero perferendis quos deserunt nihil.\nVero enim repellendus enim facere nihil enim voluptatem aspernatur laborum." },
                    { 330, 85, 62, 919328, new DateTime(2020, 12, 31, 16, 44, 43, 159, DateTimeKind.Local).AddTicks(1674), "Repudiandae nihil labore quos sint consequatur illo.\nSunt voluptas quidem culpa nihil.\nEst consequuntur sint cumque corporis.\nDolorem esse cumque velit vel optio nihil." },
                    { 370, 85, 64, 503480, new DateTime(2021, 2, 11, 6, 41, 11, 269, DateTimeKind.Local).AddTicks(5804), "iusto" },
                    { 445, 85, 127, 52007, new DateTime(2020, 12, 25, 17, 9, 27, 78, DateTimeKind.Local).AddTicks(1142), "Neque repudiandae sed quis voluptas ut et culpa. Veritatis illum excepturi architecto vero beatae ab quo eum iste. Atque qui quo. Praesentium illum molestias quos et blanditiis maxime dolores." },
                    { 510, 85, 146, 587345, new DateTime(2021, 1, 10, 13, 45, 21, 143, DateTimeKind.Local).AddTicks(1873), "Laborum sit non." },
                    { 517, 85, 52, 537081, new DateTime(2020, 9, 15, 5, 50, 6, 132, DateTimeKind.Local).AddTicks(4286), "Architecto dolor odio vero." },
                    { 538, 81, 72, 430255, new DateTime(2021, 3, 21, 21, 11, 5, 859, DateTimeKind.Local).AddTicks(8445), "Rerum sit aut dicta sunt et non nemo ut. Illo sed sed quo. Et atque in aut dolor enim accusamus recusandae quo. Unde dolores nemo vel. Sed perspiciatis aliquid quidem. Voluptatum earum et accusantium ut reprehenderit quibusdam ad minus." },
                    { 520, 85, 53, 798407, new DateTime(2020, 8, 10, 23, 27, 27, 374, DateTimeKind.Local).AddTicks(2844), "Rerum libero quia vero.\nItaque sed eum aut molestias qui veritatis.\nLibero sed at quia.\nSunt sunt nisi.\nEarum nisi quod dignissimos nulla aut quia.\nAutem fugit omnis ea et." },
                    { 366, 66, 141, 602080, new DateTime(2021, 2, 23, 10, 12, 14, 944, DateTimeKind.Local).AddTicks(5877), "Molestiae culpa aut ad omnis earum maiores expedita aut.\nMolestiae unde qui aut facere ullam rerum voluptas similique sint.\nEarum et quia doloribus autem facilis doloremque et et et.\nMinus qui quo itaque nihil hic quis." },
                    { 438, 66, 121, 420708, new DateTime(2020, 6, 23, 16, 47, 36, 60, DateTimeKind.Local).AddTicks(3520), "Illo perspiciatis labore eius." },
                    { 580, 66, 112, 80230, new DateTime(2021, 1, 20, 10, 1, 1, 16, DateTimeKind.Local).AddTicks(3706), "commodi" },
                    { 44, 67, 123, 623000, new DateTime(2020, 12, 30, 1, 49, 11, 335, DateTimeKind.Local).AddTicks(6249), "Aut sint temporibus aspernatur voluptas maiores deleniti nesciunt.\nNeque iusto voluptatem vitae voluptatem.\nSoluta nostrum architecto odit ducimus.\nRerum et dolorem.\nIpsa voluptate cumque nemo voluptas aperiam laboriosam ut ut ea.\nTenetur sed aliquam laboriosam quia soluta." },
                    { 118, 67, 2, 639336, new DateTime(2020, 8, 31, 7, 49, 54, 432, DateTimeKind.Local).AddTicks(5398), "Blanditiis deserunt totam.\nOmnis est error voluptatem culpa.\nIllum harum sit sed hic libero.\nNihil non aspernatur quibusdam corporis doloribus.\nCulpa similique dolores ut ea neque dolor." },
                    { 334, 67, 53, 523033, new DateTime(2020, 5, 16, 16, 3, 30, 991, DateTimeKind.Local).AddTicks(3586), "Cumque vel qui fuga. Dolor expedita officiis laborum quia sit. Autem saepe sit." },
                    { 361, 67, 25, 247260, new DateTime(2020, 6, 3, 14, 56, 15, 599, DateTimeKind.Local).AddTicks(7280), "Possimus officiis enim consequatur temporibus non voluptatem asperiores perferendis. Labore aspernatur assumenda asperiores incidunt facilis eius a. Est corrupti porro saepe repellat earum sit qui. Unde accusantium ut ipsa soluta velit possimus optio." },
                    { 262, 66, 115, 833005, new DateTime(2020, 8, 9, 4, 30, 40, 769, DateTimeKind.Local).AddTicks(4276), "Omnis qui culpa.\nIllo rem eius assumenda omnis.\nConsectetur odio repellat aspernatur qui." },
                    { 460, 97, 11, 224822, new DateTime(2021, 4, 2, 21, 43, 26, 770, DateTimeKind.Local).AddTicks(9887), "iure" },
                    { 599, 22, 37, 405372, new DateTime(2020, 6, 29, 0, 41, 7, 885, DateTimeKind.Local).AddTicks(8220), "qui" },
                    { 380, 22, 86, 594658, new DateTime(2020, 12, 22, 19, 44, 19, 399, DateTimeKind.Local).AddTicks(7493), "Cupiditate sapiente iste tenetur neque ea voluptas aliquam." },
                    { 279, 24, 134, 575063, new DateTime(2020, 10, 1, 3, 5, 30, 935, DateTimeKind.Local).AddTicks(8914), "Atque error sapiente ut accusamus. Consectetur autem vitae animi vitae recusandae ratione saepe cumque. Illo magnam non eum eaque voluptatum hic molestias similique. Tempore aut repellendus ipsam illum sunt. Quas sed vel ea. Laboriosam consequatur rerum porro." },
                    { 282, 24, 28, 70527, new DateTime(2020, 5, 20, 5, 34, 39, 58, DateTimeKind.Local).AddTicks(9422), "Rerum est voluptatem reprehenderit ut voluptates cupiditate iusto. Itaque quis enim soluta ducimus. Ea velit ullam molestiae impedit qui minima adipisci. Rerum blanditiis delectus officiis et impedit est quibusdam dolore. Ea ut iure adipisci. Deleniti vero sapiente." },
                    { 91, 40, 82, 146152, new DateTime(2020, 5, 25, 8, 46, 9, 337, DateTimeKind.Local).AddTicks(1779), "Quia dolorem sit. Voluptatem officia hic. Pariatur pariatur velit. Placeat placeat consectetur non debitis. Eaque temporibus et minus aspernatur dolorem earum." },
                    { 133, 40, 142, 881191, new DateTime(2020, 11, 23, 18, 59, 16, 702, DateTimeKind.Local).AddTicks(6413), "Eius ipsam placeat sit maiores temporibus explicabo.\nEst autem suscipit." },
                    { 186, 40, 111, 437492, new DateTime(2021, 3, 15, 3, 15, 3, 538, DateTimeKind.Local).AddTicks(923), "Repellendus suscipit voluptatem non facilis." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 238, 40, 127, 360622, new DateTime(2020, 6, 22, 20, 6, 29, 687, DateTimeKind.Local).AddTicks(7594), "Autem dolor ad iure voluptas ut odio nostrum ratione quidem.\nNobis vel quis nihil pariatur quia pariatur quisquam dolore iste.\nIllum ut qui voluptatem et est magnam similique odio modi.\nMaxime provident et numquam maxime delectus quo.\nQuod dolorum tempore molestiae aut qui." },
                    { 244, 40, 119, 703583, new DateTime(2020, 8, 24, 5, 13, 23, 808, DateTimeKind.Local).AddTicks(799), "Impedit odit mollitia nam." },
                    { 325, 40, 3, 483921, new DateTime(2020, 12, 25, 2, 35, 19, 670, DateTimeKind.Local).AddTicks(4542), "Soluta est eius aut. Delectus autem fugit nobis qui corrupti amet. Laborum nemo delectus nulla facere tempore et. Quae a in officia. Dicta qui omnis. Hic fugit voluptates ipsa sequi non et." },
                    { 368, 40, 64, 688628, new DateTime(2020, 9, 10, 13, 16, 43, 682, DateTimeKind.Local).AddTicks(1024), "Architecto natus hic maiores excepturi temporibus.\nMaiores ullam a sequi molestias.\nEsse vel consequatur ut vel." },
                    { 406, 40, 62, 289472, new DateTime(2020, 11, 5, 11, 34, 24, 769, DateTimeKind.Local).AddTicks(8710), "Ad optio eum sint expedita. Quae dolores quas voluptates laudantium. Fugit nemo rerum excepturi deleniti qui numquam. Dolores recusandae vero. Et ratione deleniti enim est. Dolorum est id unde fugiat nihil." },
                    { 439, 40, 118, 340683, new DateTime(2021, 3, 21, 12, 39, 55, 935, DateTimeKind.Local).AddTicks(2851), "Consequatur beatae ut harum." },
                    { 457, 40, 34, 36076, new DateTime(2020, 4, 17, 4, 19, 53, 528, DateTimeKind.Local).AddTicks(5610), "Earum et quis sunt itaque consectetur tenetur." },
                    { 521, 40, 129, 205282, new DateTime(2020, 8, 21, 4, 5, 41, 354, DateTimeKind.Local).AddTicks(1911), "Exercitationem est suscipit accusantium delectus a. Eveniet exercitationem veritatis. Porro temporibus laboriosam est reiciendis fugit explicabo sunt. Quas minus magni impedit. Voluptas omnis odio illo ut." },
                    { 541, 40, 13, 648573, new DateTime(2020, 12, 27, 2, 21, 24, 173, DateTimeKind.Local).AddTicks(1495), "Earum illum maiores deleniti adipisci molestias modi consequatur quia. Exercitationem nihil ut expedita aut voluptas. Aliquam enim dolorem rerum quia." },
                    { 5, 65, 126, 120021, new DateTime(2020, 10, 7, 0, 28, 46, 130, DateTimeKind.Local).AddTicks(2311), "Et pariatur sed recusandae est. In culpa reiciendis non exercitationem qui ipsum ullam qui. Omnis sunt omnis repudiandae culpa quos non ipsam." },
                    { 122, 24, 27, 250514, new DateTime(2021, 2, 8, 12, 5, 46, 899, DateTimeKind.Local).AddTicks(7055), "vitae" },
                    { 559, 15, 104, 552009, new DateTime(2020, 10, 15, 5, 35, 55, 495, DateTimeKind.Local).AddTicks(9225), "Temporibus eum et quasi eligendi. Autem eos quisquam aut incidunt recusandae cum sint. Dignissimos aliquid sint autem nulla est labore ut. Ipsum ut veritatis aut voluptas sequi reiciendis pariatur nihil. Quod omnis quasi neque totam vel dolores ut iste ut. Et aliquid corporis aut eos molestiae sapiente ratione illo." },
                    { 533, 15, 85, 101126, new DateTime(2020, 8, 14, 12, 4, 54, 752, DateTimeKind.Local).AddTicks(9450), "Praesentium exercitationem neque sint aut nisi dolorum magnam rerum." },
                    { 433, 15, 68, 338851, new DateTime(2020, 6, 9, 15, 4, 9, 724, DateTimeKind.Local).AddTicks(8432), "Porro reiciendis non non molestiae optio. Nemo aut tempora dolores non nihil sed facere. Aperiam rerum cumque velit ut. Nostrum autem ab optio tempore. Molestiae voluptas quos. Totam quaerat asperiores iste a delectus voluptates." },
                    { 258, 27, 125, 611127, new DateTime(2020, 9, 2, 5, 25, 3, 515, DateTimeKind.Local).AddTicks(5300), "Non atque placeat quibusdam quis aperiam. Nisi ut accusantium eos necessitatibus ipsa officia aliquam. Temporibus dolor reprehenderit esse ab laborum et ut in. Itaque dolorem dignissimos quis et aspernatur rerum qui minus. Reprehenderit tenetur enim. Qui minus natus adipisci ut." },
                    { 388, 27, 36, 156405, new DateTime(2020, 11, 20, 18, 8, 16, 571, DateTimeKind.Local).AddTicks(2486), "natus" },
                    { 67, 26, 96, 998139, new DateTime(2020, 8, 4, 22, 57, 2, 614, DateTimeKind.Local).AddTicks(6702), "Laboriosam et distinctio est." },
                    { 85, 26, 103, 300350, new DateTime(2020, 7, 10, 10, 23, 7, 458, DateTimeKind.Local).AddTicks(4738), "Iure sit et atque. Velit quisquam enim qui. Sit impedit sed sequi sed mollitia rerum sit. Necessitatibus et facere delectus optio non voluptatem debitis corrupti dolorem. Officiis aut et fuga dolor fugiat. Voluptas unde iste minima commodi officiis qui recusandae." },
                    { 224, 26, 150, 17553, new DateTime(2020, 9, 8, 2, 58, 44, 779, DateTimeKind.Local).AddTicks(2006), "Cumque voluptatem id voluptates alias accusamus.\nAd est aut." },
                    { 242, 26, 75, 85708, new DateTime(2020, 5, 30, 16, 2, 8, 138, DateTimeKind.Local).AddTicks(7573), "Nihil qui nam deleniti omnis deserunt qui. At dolorem magnam accusantium. Aut cupiditate nihil et. Voluptatem consectetur fugit. Nam beatae quisquam voluptas blanditiis." },
                    { 375, 26, 68, 120281, new DateTime(2021, 3, 30, 8, 6, 42, 630, DateTimeKind.Local).AddTicks(3631), "Quas deserunt iure incidunt non.\nDeleniti unde rerum quae." },
                    { 284, 65, 86, 945489, new DateTime(2020, 11, 3, 5, 10, 38, 77, DateTimeKind.Local).AddTicks(2819), "Eveniet ea dolores iste dignissimos." },
                    { 505, 26, 148, 344992, new DateTime(2020, 10, 31, 2, 26, 34, 790, DateTimeKind.Local).AddTicks(5347), "qui" },
                    { 579, 26, 23, 510507, new DateTime(2021, 2, 11, 14, 24, 48, 412, DateTimeKind.Local).AddTicks(7566), "Iusto quia eligendi doloribus id dolores enim quo itaque blanditiis.\nNobis nostrum necessitatibus.\nExpedita a tenetur assumenda quam officiis cupiditate repudiandae.\nExcepturi sed officiis quo reprehenderit dolores et modi quo.\nDistinctio occaecati dolores." },
                    { 112, 51, 41, 929732, new DateTime(2020, 10, 14, 5, 30, 48, 305, DateTimeKind.Local).AddTicks(7678), "Corporis qui accusantium et non voluptatum nisi ad quo.\nVoluptates unde autem magnam sit.\nVel et incidunt ea voluptas enim sunt hic quam libero.\nLaudantium rerum consequuntur laboriosam nihil quas.\nDolor asperiores aut ut non et ab.\nIn voluptates nam." },
                    { 308, 51, 40, 137402, new DateTime(2021, 4, 1, 18, 8, 0, 752, DateTimeKind.Local).AddTicks(5748), "Vel voluptatem vero ut exercitationem esse debitis cupiditate non. Sed cum nihil necessitatibus magni qui iusto. Voluptatem temporibus tempora delectus animi assumenda vero molestias dolore mollitia. Dolore unde nihil voluptate ut eius inventore." },
                    { 49, 15, 12, 465522, new DateTime(2021, 1, 17, 22, 10, 45, 21, DateTimeKind.Local).AddTicks(4674), "Eum voluptatem quos in in. Blanditiis quis est nam. Nam illo velit doloribus. Consequuntur alias provident et sit asperiores blanditiis sed consectetur eveniet. Unde error in doloremque pariatur aut maiores animi vitae. Et quod similique aut beatae magni voluptates vel." },
                    { 117, 15, 59, 551475, new DateTime(2020, 8, 27, 14, 52, 37, 137, DateTimeKind.Local).AddTicks(7546), "Sit ut repellendus totam. Qui est maiores. At vel nesciunt. Molestiae ex nemo quaerat." },
                    { 596, 89, 125, 185676, new DateTime(2021, 4, 9, 9, 51, 40, 759, DateTimeKind.Local).AddTicks(1809), "Et incidunt natus eos vel modi est in at necessitatibus.\nReiciendis distinctio et natus.\nLaudantium est totam.\nEos fugit distinctio commodi eaque culpa.\nIste deserunt suscipit quis et ea.\nEt consequatur non voluptatem." },
                    { 398, 15, 50, 460371, new DateTime(2020, 7, 22, 6, 7, 58, 263, DateTimeKind.Local).AddTicks(35), "Provident est perspiciatis modi dignissimos." },
                    { 571, 26, 99, 631055, new DateTime(2020, 11, 19, 17, 54, 41, 962, DateTimeKind.Local).AddTicks(4951), "Sapiente dolores ab nihil aut nulla. Quaerat eum sunt et distinctio. Culpa et inventore omnis aut minus illum. Impedit vitae deleniti modi minima nihil cum doloremque. Quidem fugit optio quis. Velit deleniti quasi non reiciendis et iure reprehenderit nisi rerum." },
                    { 567, 22, 34, 847928, new DateTime(2020, 8, 16, 5, 32, 11, 893, DateTimeKind.Local).AddTicks(190), "Beatae impedit occaecati aut." },
                    { 328, 65, 93, 652385, new DateTime(2020, 5, 8, 16, 50, 27, 558, DateTimeKind.Local).AddTicks(9272), "Blanditiis commodi repellat aspernatur molestiae soluta autem molestias quia occaecati.\nDolore sint aut cupiditate eaque natus.\nMolestiae numquam aliquid explicabo enim corporis omnis sed repellat.\nDoloribus deserunt est.\nConsequatur molestiae illo.\nVoluptatibus labore placeat aspernatur culpa assumenda reprehenderit." },
                    { 58, 43, 19, 826291, new DateTime(2020, 8, 3, 21, 12, 15, 555, DateTimeKind.Local).AddTicks(7785), "Laboriosam in libero ipsa et. Magnam molestiae ratione laborum impedit perspiciatis qui temporibus. Labore et excepturi temporibus laboriosam exercitationem." },
                    { 318, 61, 78, 931739, new DateTime(2020, 10, 7, 8, 26, 33, 550, DateTimeKind.Local).AddTicks(8749), "Numquam ut porro autem odio ullam exercitationem. Facere minus incidunt. Eum dolor temporibus vel reprehenderit reprehenderit vel dolores. Quasi numquam et placeat consequuntur eum. Pariatur aliquid dolorem ut sequi pariatur." },
                    { 341, 61, 74, 306425, new DateTime(2020, 6, 16, 12, 51, 54, 191, DateTimeKind.Local).AddTicks(5891), "Eaque ipsum fuga error voluptatem ab consequuntur expedita debitis." },
                    { 350, 61, 31, 473796, new DateTime(2021, 1, 29, 5, 3, 8, 125, DateTimeKind.Local).AddTicks(4755), "Suscipit doloremque voluptas voluptatem sit nihil exercitationem natus rerum repellendus." },
                    { 383, 61, 119, 420131, new DateTime(2020, 12, 6, 15, 4, 57, 149, DateTimeKind.Local).AddTicks(6851), "Aut officia et dicta.\nItaque quia eos dolorem architecto amet sit." },
                    { 386, 61, 84, 431715, new DateTime(2020, 8, 18, 12, 17, 40, 703, DateTimeKind.Local).AddTicks(1105), "Dolorem nisi nesciunt ipsam minus voluptatem dicta non voluptates." },
                    { 409, 61, 38, 742194, new DateTime(2020, 10, 20, 18, 34, 21, 197, DateTimeKind.Local).AddTicks(2369), "dignissimos" },
                    { 411, 61, 124, 918923, new DateTime(2020, 12, 7, 2, 53, 24, 728, DateTimeKind.Local).AddTicks(3210), "Sit est quibusdam fuga voluptas." },
                    { 436, 61, 78, 17963, new DateTime(2021, 3, 16, 5, 51, 22, 168, DateTimeKind.Local).AddTicks(9943), "Quaerat unde aut exercitationem. Dolorem dicta necessitatibus et fugit reiciendis. Ut est nihil minima consequuntur. Tenetur quidem enim. Voluptatum harum eveniet nihil sit at sed quis." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 459, 61, 41, 602999, new DateTime(2020, 11, 17, 14, 44, 24, 118, DateTimeKind.Local).AddTicks(2460), "Ullam molestiae nihil aut quia libero dolor." },
                    { 464, 61, 1, 143598, new DateTime(2020, 5, 11, 5, 39, 48, 561, DateTimeKind.Local).AddTicks(6870), "Nulla voluptas fuga illo magni sit suscipit. Accusamus qui sunt expedita ipsa quis veritatis. Architecto ducimus illo. Fugit nostrum illum ut molestias. Consectetur harum eum accusantium quia tempora quas error consectetur omnis." },
                    { 514, 61, 124, 654315, new DateTime(2020, 9, 21, 13, 45, 9, 841, DateTimeKind.Local).AddTicks(956), "Eos delectus dolorem magnam pariatur voluptatem adipisci nihil. Ut adipisci perferendis fugit incidunt in sint voluptatem reiciendis dolores. Rerum consequatur sed nisi." },
                    { 14, 22, 38, 718944, new DateTime(2020, 7, 25, 15, 8, 51, 17, DateTimeKind.Local).AddTicks(595), "id" },
                    { 129, 22, 55, 293654, new DateTime(2020, 6, 9, 4, 46, 37, 937, DateTimeKind.Local).AddTicks(7036), "Similique omnis qui in repellendus est. Unde velit aliquid soluta provident facilis magnam necessitatibus ut aut. Quia aut tempore aut dolore maxime a qui qui in." },
                    { 157, 22, 26, 63033, new DateTime(2021, 2, 13, 22, 24, 27, 291, DateTimeKind.Local).AddTicks(7463), "quia" },
                    { 208, 22, 109, 343845, new DateTime(2020, 8, 27, 4, 20, 16, 106, DateTimeKind.Local).AddTicks(1566), "Mollitia quaerat praesentium cumque quis quia." },
                    { 268, 61, 79, 883572, new DateTime(2020, 10, 23, 1, 32, 5, 818, DateTimeKind.Local).AddTicks(6049), "et" },
                    { 211, 61, 140, 740424, new DateTime(2020, 5, 30, 13, 47, 23, 127, DateTimeKind.Local).AddTicks(1475), "Distinctio cupiditate nihil et et vel quis fuga recusandae." },
                    { 203, 61, 135, 830877, new DateTime(2021, 2, 24, 23, 13, 31, 878, DateTimeKind.Local).AddTicks(2564), "Inventore debitis aut qui nam voluptate.\nQuam asperiores unde et.\nEnim quibusdam velit earum aut voluptatem hic id.\nUt qui velit repellendus hic libero sunt mollitia et et.\nQuia a quas beatae quasi dolores esse.\nSit praesentium fugiat." },
                    { 179, 61, 71, 343022, new DateTime(2020, 5, 15, 4, 52, 17, 348, DateTimeKind.Local).AddTicks(7251), "Et neque reiciendis et quae iusto expedita quas deserunt." },
                    { 60, 43, 31, 433252, new DateTime(2021, 2, 7, 16, 6, 16, 352, DateTimeKind.Local).AddTicks(173), "Nihil porro quasi aut aliquid alias cupiditate nemo facere quia." },
                    { 128, 43, 100, 110290, new DateTime(2020, 4, 25, 20, 51, 36, 34, DateTimeKind.Local).AddTicks(6422), "Ea quis et soluta. Laudantium necessitatibus velit. Qui unde sapiente porro rerum nemo fuga ea nemo. Reiciendis dignissimos non. Explicabo aut eos. Ratione et quia omnis." },
                    { 161, 43, 146, 163238, new DateTime(2020, 6, 4, 21, 20, 31, 11, DateTimeKind.Local).AddTicks(2100), "Quia dolor dolorum mollitia exercitationem quaerat repudiandae suscipit voluptatum.\nVoluptate et laboriosam nisi similique eligendi.\nLabore qui fuga accusamus minima nihil blanditiis.\nIllum sunt itaque reprehenderit.\nSuscipit doloremque temporibus aperiam excepturi totam eos.\nVoluptatem harum consequuntur et rerum." },
                    { 267, 43, 104, 863036, new DateTime(2021, 3, 17, 15, 17, 10, 94, DateTimeKind.Local).AddTicks(6658), "Dolorem aut distinctio a dolore necessitatibus enim quia doloribus." },
                    { 321, 43, 146, 418163, new DateTime(2021, 3, 10, 15, 12, 4, 497, DateTimeKind.Local).AddTicks(7523), "molestiae" },
                    { 206, 14, 39, 420189, new DateTime(2021, 1, 6, 1, 4, 41, 481, DateTimeKind.Local).AddTicks(8278), "Suscipit accusamus iure ut et." },
                    { 271, 14, 59, 950402, new DateTime(2021, 2, 1, 2, 35, 35, 367, DateTimeKind.Local).AddTicks(8642), "distinctio" },
                    { 448, 65, 43, 37458, new DateTime(2020, 9, 12, 8, 48, 28, 371, DateTimeKind.Local).AddTicks(575), "ut" },
                    { 299, 14, 42, 802297, new DateTime(2020, 5, 27, 21, 11, 40, 195, DateTimeKind.Local).AddTicks(8382), "Dolor nesciunt at suscipit expedita enim voluptas. Earum et culpa sit dolore quos praesentium quasi. Eaque sed nam eius aliquam." },
                    { 586, 14, 70, 845734, new DateTime(2020, 4, 15, 21, 12, 10, 798, DateTimeKind.Local).AddTicks(1492), "sequi" },
                    { 260, 58, 62, 833482, new DateTime(2020, 9, 2, 0, 27, 8, 613, DateTimeKind.Local).AddTicks(1280), "Eius et explicabo fugiat ut reiciendis dolor eaque rerum.\nVero consectetur deleniti quo et.\nSapiente voluptatem ab.\nEa a qui tempore asperiores consequatur officia.\nProvident quis ea magni eum perspiciatis minus eligendi consectetur." },
                    { 403, 58, 17, 315539, new DateTime(2020, 6, 21, 21, 52, 2, 138, DateTimeKind.Local).AddTicks(8709), "Architecto blanditiis voluptate vitae optio consequatur quia aspernatur. Ipsa delectus dolorem quia voluptatem et temporibus ut et. Aut accusamus dicta repellat. Similique dolorem voluptas nostrum itaque ut molestias maiores. Quod id voluptas reiciendis autem tempora accusamus et." },
                    { 496, 58, 136, 842236, new DateTime(2020, 5, 13, 0, 22, 7, 578, DateTimeKind.Local).AddTicks(8401), "itaque" },
                    { 577, 58, 117, 147153, new DateTime(2020, 6, 7, 21, 34, 25, 400, DateTimeKind.Local).AddTicks(1459), "Pariatur vel quisquam sint.\nVoluptatem qui est nulla facere porro dicta nihil.\nEt fugiat nesciunt quaerat.\nAliquid nulla sed et neque debitis qui dolorem id a." },
                    { 63, 19, 26, 678, new DateTime(2020, 10, 17, 1, 19, 52, 227, DateTimeKind.Local).AddTicks(6492), "Quibusdam magnam explicabo molestiae itaque autem labore." },
                    { 178, 19, 62, 254154, new DateTime(2020, 5, 29, 7, 58, 57, 27, DateTimeKind.Local).AddTicks(3344), "quia" },
                    { 354, 14, 42, 887406, new DateTime(2021, 2, 14, 12, 21, 40, 459, DateTimeKind.Local).AddTicks(7412), "voluptas" },
                    { 575, 97, 113, 844185, new DateTime(2021, 2, 26, 10, 10, 13, 717, DateTimeKind.Local).AddTicks(3390), "quae" },
                    { 373, 99, 46, 726866, new DateTime(2021, 2, 4, 9, 13, 7, 480, DateTimeKind.Local).AddTicks(8939), "Culpa ut veniam." },
                    { 405, 99, 145, 205540, new DateTime(2021, 1, 24, 20, 27, 30, 663, DateTimeKind.Local).AddTicks(3417), "deleniti" },
                    { 96, 11, 138, 881582, new DateTime(2020, 5, 30, 7, 36, 18, 531, DateTimeKind.Local).AddTicks(4121), "Distinctio unde optio sapiente et libero quis ut rerum." },
                    { 173, 11, 46, 23054, new DateTime(2020, 8, 11, 10, 25, 18, 144, DateTimeKind.Local).AddTicks(7470), "Itaque quia et repellendus.\nSunt qui odio necessitatibus dignissimos voluptatem nobis ullam quo.\nDucimus doloremque quibusdam cum quisquam quisquam alias iusto aperiam.\nImpedit excepturi quasi et." },
                    { 180, 11, 144, 755057, new DateTime(2021, 3, 4, 22, 43, 56, 101, DateTimeKind.Local).AddTicks(3920), "Natus illum necessitatibus repellat dolor adipisci praesentium alias ab non. Omnis unde eaque exercitationem aut quia et repudiandae. In minima minus assumenda sed totam provident dolore aut. Sunt iure qui et eligendi consequatur occaecati. Et quam cumque reiciendis placeat." },
                    { 205, 11, 77, 919843, new DateTime(2020, 10, 18, 12, 8, 27, 873, DateTimeKind.Local).AddTicks(1342), "dolorem" },
                    { 360, 11, 136, 289713, new DateTime(2020, 5, 29, 16, 45, 26, 799, DateTimeKind.Local).AddTicks(5157), "Vel ipsa quasi sint. Dolor et blanditiis sunt odio maiores eum. Adipisci et voluptates quas." },
                    { 420, 11, 94, 238820, new DateTime(2021, 1, 18, 21, 8, 24, 440, DateTimeKind.Local).AddTicks(7787), "Iste aliquam sequi saepe pariatur ipsum. Sequi non saepe vero ut id veniam et. Illo omnis et." },
                    { 449, 11, 134, 494587, new DateTime(2020, 7, 8, 6, 47, 21, 254, DateTimeKind.Local).AddTicks(905), "Nam dolorum aut quia delectus repellendus quas facilis esse. Veniam aut mollitia vero. Ea distinctio delectus aperiam quibusdam reprehenderit aspernatur dolorem. Et dolore exercitationem facere neque qui et placeat qui quas. Voluptates excepturi sed labore ut quas deserunt maxime non possimus." },
                    { 462, 11, 104, 696221, new DateTime(2020, 12, 14, 12, 29, 51, 770, DateTimeKind.Local).AddTicks(2233), "quod" },
                    { 562, 11, 98, 58561, new DateTime(2020, 12, 4, 5, 36, 5, 995, DateTimeKind.Local).AddTicks(600), "Dolores aut provident rerum quam voluptatem qui optio libero quidem." },
                    { 110, 13, 111, 953474, new DateTime(2020, 4, 16, 9, 45, 44, 553, DateTimeKind.Local).AddTicks(1039), "Nesciunt aut numquam autem nisi recusandae blanditiis.\nA consequatur et.\nUnde cumque praesentium beatae.\nQuos excepturi aut." },
                    { 123, 13, 40, 552716, new DateTime(2020, 9, 15, 11, 47, 33, 797, DateTimeKind.Local).AddTicks(1357), "Temporibus omnis et ut ut molestias dolorum et vero veritatis.\nNobis mollitia id.\nMollitia quae autem est quod commodi.\nOfficiis explicabo voluptas ratione unde alias voluptas quia quasi.\nConsequatur autem provident quia perferendis non cupiditate adipisci id delectus." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 145, 13, 41, 304943, new DateTime(2020, 6, 14, 23, 56, 16, 11, DateTimeKind.Local).AddTicks(4692), "Illum autem at et et. Ex nam a ab praesentium repellendus quam nulla reprehenderit nobis. Ea excepturi necessitatibus voluptatem aperiam a molestias aut. Similique aut possimus cum sed et qui." },
                    { 304, 13, 23, 943967, new DateTime(2020, 6, 19, 11, 23, 50, 588, DateTimeKind.Local).AddTicks(7187), "Illo corrupti doloribus at quam sed nostrum. Voluptas fuga maxime repellat error. Ea non eligendi voluptas voluptatem aliquam." },
                    { 528, 13, 146, 689658, new DateTime(2020, 11, 2, 21, 37, 1, 435, DateTimeKind.Local).AddTicks(6054), "Quo voluptates labore deleniti sed et.\nEum voluptatem possimus qui dolorem ut itaque quasi alias rem." },
                    { 551, 13, 82, 105131, new DateTime(2020, 5, 22, 10, 4, 52, 164, DateTimeKind.Local).AddTicks(5995), "quo" },
                    { 27, 11, 45, 174899, new DateTime(2020, 4, 18, 10, 41, 44, 622, DateTimeKind.Local).AddTicks(557), "culpa" },
                    { 582, 48, 131, 298241, new DateTime(2021, 1, 20, 13, 16, 43, 922, DateTimeKind.Local).AddTicks(7790), "Fuga optio voluptatem repellat omnis. Molestiae facilis magnam consequatur voluptatum deserunt ipsum et doloribus. Minima hic suscipit facere non. Fuga odit non. Deserunt porro sint qui." },
                    { 557, 48, 44, 160925, new DateTime(2021, 1, 20, 17, 21, 31, 542, DateTimeKind.Local).AddTicks(2790), "Aut qui cum ad dolores dolor sint. Eos aut repellat aut occaecati et iusto. Temporibus id consectetur non itaque similique." },
                    { 467, 48, 27, 153376, new DateTime(2020, 6, 4, 11, 16, 52, 224, DateTimeKind.Local).AddTicks(7931), "Nihil facere voluptas dolores." },
                    { 440, 60, 101, 747298, new DateTime(2020, 8, 2, 7, 59, 30, 918, DateTimeKind.Local).AddTicks(6012), "Assumenda quos doloremque sapiente." },
                    { 490, 60, 106, 299340, new DateTime(2020, 11, 6, 16, 39, 29, 244, DateTimeKind.Local).AddTicks(7973), "Non cupiditate eum quis sit dolorum et velit quam. Molestiae sequi deleniti recusandae. Officiis enim sit sed ullam. Dignissimos magni nihil totam. Dolores tempore aut sapiente facilis quae in." },
                    { 54, 44, 93, 790092, new DateTime(2021, 3, 20, 21, 14, 3, 878, DateTimeKind.Local).AddTicks(3868), "iusto" },
                    { 298, 44, 107, 272183, new DateTime(2021, 2, 18, 20, 32, 54, 259, DateTimeKind.Local).AddTicks(3510), "voluptatibus" },
                    { 387, 44, 25, 558936, new DateTime(2020, 6, 24, 12, 21, 19, 529, DateTimeKind.Local).AddTicks(5653), "Temporibus officiis ut itaque expedita ut.\nSed earum enim.\nAliquid in eius nostrum velit accusamus ut architecto distinctio.\nVoluptas molestiae quos temporibus quaerat reprehenderit cum totam nemo repudiandae." },
                    { 491, 44, 123, 860465, new DateTime(2020, 10, 19, 14, 5, 50, 855, DateTimeKind.Local).AddTicks(978), "Quo voluptatum laborum libero quia et itaque quia consequatur." },
                    { 581, 44, 92, 73392, new DateTime(2020, 7, 25, 12, 57, 50, 550, DateTimeKind.Local).AddTicks(162), "Est autem temporibus eius et voluptates quia accusamus. Corrupti quaerat mollitia quia odio officia. Pariatur voluptatem incidunt sit neque repellendus dignissimos excepturi enim. Nesciunt soluta maxime at vel ab ea qui." },
                    { 273, 28, 100, 281654, new DateTime(2020, 12, 10, 16, 39, 38, 657, DateTimeKind.Local).AddTicks(1444), "Libero ipsum aut. Esse consequuntur dolores. Nulla est maiores animi quis voluptatem. Vitae ipsam porro nam dolorem assumenda eaque perferendis aut." },
                    { 3, 23, 111, 762292, new DateTime(2020, 8, 23, 14, 42, 54, 845, DateTimeKind.Local).AddTicks(7653), "Repellendus nemo labore totam ipsam possimus. Voluptates dolores blanditiis veniam. Veritatis at possimus corrupti qui animi harum." },
                    { 359, 23, 78, 240354, new DateTime(2020, 9, 11, 9, 6, 21, 8, DateTimeKind.Local).AddTicks(8316), "Atque magnam voluptatibus illum reiciendis eaque dolore.\nPlaceat perferendis soluta aut itaque ipsam in similique ut.\nVoluptatibus et sapiente doloremque nesciunt.\nFugiat ratione qui ab eos voluptas molestias.\nQui fugiat esse aut non rem perspiciatis odit consectetur." },
                    { 450, 23, 142, 22676, new DateTime(2021, 2, 19, 0, 20, 10, 534, DateTimeKind.Local).AddTicks(9487), "Qui ut voluptatum similique blanditiis.\nQuos quisquam quos placeat deleniti deserunt molestias provident eum explicabo.\nAutem pariatur praesentium est quibusdam exercitationem et aliquid rerum.\nVero facere amet eos.\nDolorem corporis voluptatem et accusantium nihil.\nEst quo occaecati maxime facere aut." },
                    { 525, 23, 29, 227677, new DateTime(2021, 1, 15, 3, 39, 45, 268, DateTimeKind.Local).AddTicks(1719), "Accusantium iusto ut qui dolorum velit sit beatae placeat illum." },
                    { 572, 23, 26, 581603, new DateTime(2020, 11, 12, 15, 6, 22, 96, DateTimeKind.Local).AddTicks(3080), "Voluptates consequuntur inventore et aliquam ab sunt velit qui." },
                    { 225, 48, 33, 879777, new DateTime(2021, 1, 12, 18, 49, 58, 927, DateTimeKind.Local).AddTicks(4619), "Natus debitis hic rem officia qui et. Sunt aperiam nulla quia ut a ut aut. Est architecto nulla et dolores. Aliquid quia ut dolor architecto." },
                    { 305, 48, 71, 441487, new DateTime(2021, 2, 12, 4, 42, 51, 393, DateTimeKind.Local).AddTicks(8984), "Odit sunt voluptatem laudantium ipsam omnis optio qui voluptates." },
                    { 320, 48, 60, 895714, new DateTime(2020, 7, 18, 20, 36, 44, 828, DateTimeKind.Local).AddTicks(4205), "Eum nihil dolorum optio autem et qui voluptatum. Odit cumque mollitia non quod qui et. Consequuntur consequatur quae dolorem labore." },
                    { 167, 23, 136, 944163, new DateTime(2021, 1, 30, 12, 19, 30, 273, DateTimeKind.Local).AddTicks(1342), "Eligendi fugit consequuntur dolore nemo ad qui voluptas asperiores." },
                    { 379, 60, 125, 659644, new DateTime(2020, 9, 12, 19, 57, 19, 177, DateTimeKind.Local).AddTicks(5192), "Fugiat facere id dolorem sequi voluptatum quos." },
                    { 326, 28, 77, 373386, new DateTime(2020, 7, 4, 17, 19, 0, 135, DateTimeKind.Local).AddTicks(4102), "Officia et est est. Cum architecto ut voluptatem ea sint. Assumenda illum iure excepturi debitis voluptatibus laboriosam dolor." },
                    { 535, 28, 59, 750934, new DateTime(2020, 12, 7, 10, 13, 9, 601, DateTimeKind.Local).AddTicks(6356), "voluptatem" },
                    { 259, 57, 49, 564936, new DateTime(2020, 11, 7, 15, 0, 57, 476, DateTimeKind.Local).AddTicks(3129), "cumque" },
                    { 395, 57, 127, 591168, new DateTime(2021, 3, 25, 5, 36, 16, 969, DateTimeKind.Local).AddTicks(4056), "Soluta recusandae libero blanditiis reiciendis vel architecto consequatur occaecati voluptatem." },
                    { 26, 17, 14, 95284, new DateTime(2021, 1, 3, 13, 51, 28, 981, DateTimeKind.Local).AddTicks(7462), "Asperiores nihil assumenda. Quam natus explicabo ut est cum qui ipsum nihil. Voluptate voluptatem quas adipisci id dolor et voluptatum magni." },
                    { 148, 17, 85, 693221, new DateTime(2020, 5, 12, 10, 18, 46, 559, DateTimeKind.Local).AddTicks(2621), "Et aut natus voluptates nam porro non non. Et enim necessitatibus similique illum. Quaerat incidunt impedit consequatur natus voluptatem molestias vitae. Ut in eum non officiis. Vel omnis sit iste quos atque labore quis aut." },
                    { 390, 17, 41, 137800, new DateTime(2020, 8, 26, 1, 15, 41, 227, DateTimeKind.Local).AddTicks(6209), "Consequatur molestiae minima rem. Doloribus inventore consequuntur nihil nemo ducimus error cumque vel libero. Modi laborum nihil aliquam possimus facere aut omnis id. Omnis earum dolor." },
                    { 423, 17, 104, 830178, new DateTime(2020, 9, 3, 11, 10, 45, 499, DateTimeKind.Local).AddTicks(7129), "Et aperiam perspiciatis voluptas eius cum natus." },
                    { 59, 89, 124, 92535, new DateTime(2020, 8, 16, 13, 40, 27, 239, DateTimeKind.Local).AddTicks(9251), "Libero alias ex." },
                    { 89, 89, 85, 456180, new DateTime(2021, 2, 16, 2, 27, 14, 629, DateTimeKind.Local).AddTicks(2582), "Odit ullam iste eaque et non ex vitae quae maxime. Delectus sit odit saepe sit rerum. Et aut amet ex aut et." },
                    { 159, 89, 6, 318430, new DateTime(2020, 6, 1, 14, 24, 50, 16, DateTimeKind.Local).AddTicks(1027), "Animi est dolorem quisquam est deleniti." },
                    { 301, 89, 97, 591302, new DateTime(2020, 9, 27, 9, 7, 54, 309, DateTimeKind.Local).AddTicks(3125), "Ut voluptates quis blanditiis. Sapiente cumque ullam. Voluptatem impedit culpa sed odio commodi rerum aut magnam. Repellat voluptatum qui quia dolor et qui rerum." },
                    { 319, 89, 7, 946855, new DateTime(2020, 7, 1, 8, 52, 3, 553, DateTimeKind.Local).AddTicks(1282), "Maxime sit nemo impedit et ut. Nam consequatur eligendi repellendus unde provident voluptatem qui magni. Quae enim totam et. In similique quaerat iste. Distinctio vero voluptas accusamus unde aut quidem tempore quod et." },
                    { 329, 89, 103, 320196, new DateTime(2020, 8, 4, 20, 24, 14, 78, DateTimeKind.Local).AddTicks(1583), "Autem voluptas consectetur voluptatem mollitia laborum ea sunt." },
                    { 400, 89, 16, 444013, new DateTime(2020, 12, 18, 1, 44, 28, 256, DateTimeKind.Local).AddTicks(3338), "Voluptatem vero natus soluta animi molestias corporis libero quaerat.\nTenetur optio provident." },
                    { 511, 89, 101, 176157, new DateTime(2021, 1, 21, 4, 36, 49, 111, DateTimeKind.Local).AddTicks(6232), "Aliquid est adipisci praesentium et.\nRerum odit dolor voluptates deleniti repellat.\nA fugit expedita dolor.\nConsequuntur quos occaecati optio distinctio eius.\nUt quo architecto sit consequuntur provident neque." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 518, 89, 48, 820128, new DateTime(2020, 5, 25, 20, 19, 54, 829, DateTimeKind.Local).AddTicks(1075), "quo" },
                    { 249, 57, 108, 776686, new DateTime(2020, 10, 16, 2, 31, 19, 932, DateTimeKind.Local).AddTicks(3676), "Inventore sequi suscipit hic consequatur. Soluta molestiae iusto explicabo ut consequatur quia dolores consectetur. Ut blanditiis est voluptatem." },
                    { 100, 57, 59, 72257, new DateTime(2021, 3, 21, 1, 32, 54, 351, DateTimeKind.Local).AddTicks(1981), "Eveniet molestias provident et." },
                    { 31, 57, 56, 734446, new DateTime(2020, 11, 20, 4, 5, 18, 929, DateTimeKind.Local).AddTicks(9014), "Voluptas qui hic ab eos ratione quibusdam." },
                    { 552, 10, 55, 669158, new DateTime(2021, 1, 7, 17, 40, 31, 486, DateTimeKind.Local).AddTicks(2954), "Consequuntur suscipit ad accusantium fugit perspiciatis consequatur natus unde. Quia quaerat aut voluptatum dolor est impedit quia. Placeat voluptas veritatis tempora culpa. Molestiae distinctio numquam quos fuga aliquam tenetur eligendi. Excepturi sed asperiores unde dolorem voluptas. Officia vel vel." },
                    { 558, 28, 72, 304588, new DateTime(2020, 10, 11, 1, 56, 28, 551, DateTimeKind.Local).AddTicks(9052), "Ex quae et doloremque qui." },
                    { 17, 39, 46, 756167, new DateTime(2020, 7, 6, 15, 27, 6, 289, DateTimeKind.Local).AddTicks(8872), "quam" },
                    { 362, 39, 6, 586124, new DateTime(2021, 3, 25, 21, 49, 14, 36, DateTimeKind.Local).AddTicks(6727), "Illum non tenetur iste eos molestias est facilis necessitatibus earum." },
                    { 468, 39, 35, 468368, new DateTime(2020, 9, 14, 11, 2, 40, 815, DateTimeKind.Local).AddTicks(4650), "Non voluptas ab reiciendis." },
                    { 479, 39, 27, 664494, new DateTime(2020, 6, 9, 1, 15, 4, 203, DateTimeKind.Local).AddTicks(6051), "Velit in ea consequatur perspiciatis voluptas velit recusandae sequi quo." },
                    { 162, 56, 44, 394291, new DateTime(2020, 5, 4, 10, 29, 35, 578, DateTimeKind.Local).AddTicks(53), "Odio aut placeat ad molestiae molestiae.\nDolorem ea deleniti ipsum aut earum earum odit vel.\nNemo eum aspernatur fugiat incidunt eius consectetur dolores." },
                    { 169, 56, 139, 486008, new DateTime(2020, 4, 26, 18, 16, 44, 940, DateTimeKind.Local).AddTicks(4237), "Dicta consequatur ratione amet.\nConsectetur praesentium aut labore suscipit qui molestiae eum rerum.\nDolores dolore eaque.\nEa qui eos.\nRecusandae corrupti molestias et assumenda ut sit." },
                    { 427, 28, 21, 176053, new DateTime(2020, 8, 13, 5, 29, 53, 490, DateTimeKind.Local).AddTicks(5064), "rerum" },
                    { 264, 56, 43, 701702, new DateTime(2020, 10, 6, 5, 28, 24, 545, DateTimeKind.Local).AddTicks(8589), "Molestias qui dolores aut harum tenetur ratione error amet.\nPossimus vero amet qui qui.\nOdit delectus voluptas non corrupti officiis quos.\nNihil dolores officia laborum quis provident." },
                    { 333, 56, 7, 157436, new DateTime(2021, 2, 17, 13, 56, 42, 409, DateTimeKind.Local).AddTicks(2209), "Aliquid sequi non molestias qui ducimus." },
                    { 55, 10, 126, 161881, new DateTime(2020, 5, 8, 13, 6, 9, 227, DateTimeKind.Local).AddTicks(7532), "distinctio" },
                    { 62, 10, 32, 292853, new DateTime(2020, 6, 14, 16, 51, 10, 996, DateTimeKind.Local).AddTicks(1880), "Sit iure dolores aut porro totam. In repellat magnam. Nisi harum ex. Facilis omnis explicabo. Dicta quidem aut earum nulla eius quisquam odio nesciunt. Commodi eaque distinctio corporis ea quam dignissimos." },
                    { 294, 10, 60, 40128, new DateTime(2020, 8, 21, 3, 2, 38, 246, DateTimeKind.Local).AddTicks(6628), "a" },
                    { 363, 10, 123, 984907, new DateTime(2020, 12, 29, 8, 39, 16, 210, DateTimeKind.Local).AddTicks(7800), "Praesentium velit vel dignissimos doloribus ducimus. Esse sunt ut sed. Ut nostrum omnis ex dolores ut consequatur ipsa iure. Modi asperiores et eos." },
                    { 378, 10, 28, 87083, new DateTime(2021, 4, 14, 15, 26, 31, 163, DateTimeKind.Local).AddTicks(3111), "Quas consectetur velit praesentium aliquam voluptas rerum. Culpa ea temporibus sed veritatis consequatur dolor totam est. Numquam consequatur animi rerum ut eaque aspernatur velit. Sunt ipsum ea eum ducimus quaerat ipsam." },
                    { 499, 10, 10, 327462, new DateTime(2021, 3, 28, 13, 2, 58, 363, DateTimeKind.Local).AddTicks(5457), "sed" },
                    { 292, 56, 5, 86994, new DateTime(2020, 6, 27, 9, 39, 41, 629, DateTimeKind.Local).AddTicks(3585), "Adipisci qui aut voluptate aut nulla qui velit praesentium perspiciatis." },
                    { 337, 60, 114, 519909, new DateTime(2020, 12, 1, 22, 21, 58, 664, DateTimeKind.Local).AddTicks(7491), "Iste aut et aperiam." },
                    { 288, 60, 141, 859138, new DateTime(2021, 1, 25, 12, 4, 20, 897, DateTimeKind.Local).AddTicks(2388), "Velit eum quo eos dolores veritatis incidunt consequatur tempore amet.\nCupiditate esse est totam beatae." },
                    { 247, 60, 118, 596978, new DateTime(2020, 6, 4, 18, 17, 52, 415, DateTimeKind.Local).AddTicks(8144), "Explicabo eum sint et ab dolorum.\nDolore et et.\nReprehenderit ullam est et ratione voluptas at.\nNesciunt dolores est nulla.\nSimilique doloribus totam placeat ullam vero eos at delectus." },
                    { 472, 46, 10, 489706, new DateTime(2020, 6, 25, 3, 33, 45, 476, DateTimeKind.Local).AddTicks(722), "voluptatem" },
                    { 593, 46, 7, 127912, new DateTime(2020, 8, 31, 1, 20, 48, 736, DateTimeKind.Local).AddTicks(1041), "Nobis eveniet id hic recusandae. Repellat eos nihil minima ut doloremque id. Deleniti ut veritatis quis fuga. Delectus quibusdam minus veritatis aut animi aliquam non rerum et. Mollitia voluptatum qui qui reprehenderit in." },
                    { 1, 2, 17, 294, new DateTime(2020, 9, 7, 23, 45, 33, 502, DateTimeKind.Local).AddTicks(915), "officia" },
                    { 79, 2, 116, 695672, new DateTime(2020, 7, 10, 6, 10, 7, 79, DateTimeKind.Local).AddTicks(7670), "Reprehenderit et repudiandae autem.\nUnde eveniet quis voluptatem.\nNatus cupiditate impedit id porro eum perferendis sit.\nDoloribus eum voluptatem libero voluptatibus iusto praesentium dolor.\nIure non ratione porro neque ipsa." },
                    { 280, 2, 59, 586491, new DateTime(2020, 7, 31, 6, 21, 12, 801, DateTimeKind.Local).AddTicks(7666), "a" },
                    { 339, 2, 123, 188083, new DateTime(2020, 12, 26, 15, 45, 33, 525, DateTimeKind.Local).AddTicks(4702), "Molestiae repellendus consectetur dolorem optio ut. Doloremque sed ea aut perspiciatis et voluptates et nostrum illo. Pariatur est odit consequuntur placeat voluptatem ut magni hic. Ut debitis deleniti enim ut nostrum esse ab exercitationem." },
                    { 371, 2, 50, 219005, new DateTime(2020, 9, 18, 17, 35, 53, 424, DateTimeKind.Local).AddTicks(1933), "Voluptas facilis quas molestiae placeat rerum. Inventore nulla eum maiores impedit veritatis facilis et optio voluptatibus. Eum doloremque laborum rem consequuntur ut ea. Reiciendis rerum et sed. Soluta voluptatem consequatur qui tempore placeat." },
                    { 458, 2, 112, 832762, new DateTime(2020, 6, 18, 4, 25, 54, 779, DateTimeKind.Local).AddTicks(7283), "Dolorum quas itaque magni vitae sit minima perspiciatis et." },
                    { 531, 2, 19, 14480, new DateTime(2020, 11, 23, 9, 33, 16, 720, DateTimeKind.Local).AddTicks(8780), "Nobis voluptas excepturi doloribus sint et autem et. Et assumenda enim architecto accusantium nihil tenetur tenetur. Consequatur temporibus ratione aut libero vel. Tempore sunt et velit expedita." },
                    { 566, 2, 115, 416694, new DateTime(2021, 2, 17, 23, 28, 35, 416, DateTimeKind.Local).AddTicks(6028), "Voluptatem exercitationem suscipit qui saepe." },
                    { 573, 2, 44, 590609, new DateTime(2020, 12, 17, 2, 27, 2, 583, DateTimeKind.Local).AddTicks(2504), "Modi libero expedita in nihil sit facere placeat laboriosam ipsam. Quo qui est ipsum perferendis provident consequatur qui. Quidem harum expedita ea voluptates officiis odit iste atque nesciunt. Voluptate at odio voluptate. Consequatur et eos est autem nemo ipsam. Nemo minus autem quia aliquam similique optio aut sed et." },
                    { 588, 2, 69, 564293, new DateTime(2020, 6, 28, 0, 27, 13, 490, DateTimeKind.Local).AddTicks(8370), "vel" },
                    { 600, 2, 55, 201605, new DateTime(2020, 12, 3, 0, 28, 22, 28, DateTimeKind.Local).AddTicks(227), "expedita" },
                    { 9, 53, 64, 346363, new DateTime(2021, 3, 6, 18, 20, 46, 665, DateTimeKind.Local).AddTicks(978), "Velit similique velit similique voluptatem sequi ipsum quisquam et at.\nTemporibus explicabo aliquam occaecati dolores omnis nihil quia nihil sit.\nTenetur voluptatem harum." },
                    { 57, 53, 52, 443507, new DateTime(2020, 5, 20, 4, 9, 15, 548, DateTimeKind.Local).AddTicks(3318), "Aperiam fuga quo sunt vero dignissimos vero sit autem. Voluptatem itaque qui quis placeat rerum debitis velit. Sunt dignissimos necessitatibus aut consequatur. Magni expedita eum. Omnis eos non. Et tempore et laudantium facere voluptates eius." },
                    { 356, 46, 19, 715837, new DateTime(2020, 5, 25, 22, 28, 44, 206, DateTimeKind.Local).AddTicks(1499), "Sit maiores aut ut rerum.\nTotam fugit nemo sapiente voluptatem sed sit in quo et." },
                    { 311, 46, 103, 742963, new DateTime(2020, 5, 28, 0, 7, 54, 360, DateTimeKind.Local).AddTicks(282), "Delectus repellat fugiat enim blanditiis libero quasi ex ullam quam." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 230, 46, 147, 615593, new DateTime(2020, 5, 25, 9, 57, 56, 926, DateTimeKind.Local).AddTicks(6576), "Autem eos amet doloremque molestias.\nQuia atque sit itaque aut rerum quis.\nNobis non vel at exercitationem consequatur.\nOmnis quia voluptatem." },
                    { 137, 46, 21, 609407, new DateTime(2020, 5, 17, 12, 20, 59, 557, DateTimeKind.Local).AddTicks(8002), "qui" },
                    { 565, 99, 21, 496783, new DateTime(2020, 4, 19, 5, 22, 46, 606, DateTimeKind.Local).AddTicks(3023), "Harum molestiae enim non. Quaerat libero voluptate in hic. Ut dolorem est. Veniam consectetur deleniti nobis dolores dolores officiis voluptatum eos. Culpa quod natus quod qui qui. Reprehenderit deserunt molestiae quia tempore id quia unde itaque." },
                    { 18, 87, 144, 774083, new DateTime(2021, 1, 6, 14, 39, 36, 269, DateTimeKind.Local).AddTicks(627), "Sint voluptates hic dolores et. Suscipit sit est incidunt vel culpa. Debitis et autem. Inventore eum similique dolores modi laborum aut totam quo. Blanditiis voluptas ex odit facilis et omnis ea harum et. Voluptatibus dolor magnam." },
                    { 94, 87, 91, 690793, new DateTime(2021, 3, 13, 2, 17, 4, 140, DateTimeKind.Local).AddTicks(2215), "itaque" },
                    { 106, 87, 46, 437126, new DateTime(2020, 6, 14, 18, 28, 47, 383, DateTimeKind.Local).AddTicks(4977), "Magnam quasi fugit delectus. Qui vitae error quidem fuga sit molestiae libero aut nobis. Officia et ratione tenetur illum et maxime accusamus qui. Ut totam similique non laboriosam doloribus qui." },
                    { 233, 87, 103, 403650, new DateTime(2020, 7, 20, 0, 1, 31, 567, DateTimeKind.Local).AddTicks(7069), "Maxime est dolorum nihil neque voluptatibus.\nEa enim labore sed.\nEos saepe veritatis velit explicabo sed eos harum natus facere.\nReiciendis voluptas porro provident laborum ab architecto distinctio temporibus." },
                    { 272, 87, 145, 7286, new DateTime(2020, 9, 19, 13, 54, 30, 873, DateTimeKind.Local).AddTicks(1506), "necessitatibus" },
                    { 342, 87, 121, 633896, new DateTime(2020, 5, 23, 8, 41, 44, 618, DateTimeKind.Local).AddTicks(1810), "Nam fugiat autem placeat culpa exercitationem ipsum eum consequuntur. Explicabo quos ab sunt ut voluptate. Dolorum perferendis consequuntur cum dolorum asperiores omnis incidunt necessitatibus sunt. Pariatur reprehenderit perferendis. Esse quasi est ipsum aperiam error numquam quod alias labore. Qui a quidem est repellendus error." },
                    { 352, 53, 106, 191095, new DateTime(2020, 10, 6, 23, 31, 3, 769, DateTimeKind.Local).AddTicks(6289), "Pariatur quas a.\nSunt rem asperiores vel sed odio quia." },
                    { 426, 87, 14, 537745, new DateTime(2020, 11, 15, 21, 58, 1, 650, DateTimeKind.Local).AddTicks(4171), "Sunt non architecto dicta magnam excepturi. Quia accusamus nobis sint rerum non fugiat atque. Delectus aut corrupti veniam. Et iusto fuga et omnis rerum dolorem deleniti autem. Voluptatem magni omnis eveniet nesciunt amet eum." },
                    { 287, 37, 6, 985607, new DateTime(2021, 4, 2, 8, 41, 36, 361, DateTimeKind.Local).AddTicks(9390), "Nam neque molestias debitis aut distinctio consequatur minima in et." },
                    { 372, 37, 78, 773962, new DateTime(2020, 8, 27, 8, 8, 13, 939, DateTimeKind.Local).AddTicks(8160), "Ducimus recusandae qui fugit temporibus non consequatur accusamus rerum dicta." },
                    { 492, 37, 124, 424221, new DateTime(2020, 5, 2, 21, 2, 15, 839, DateTimeKind.Local).AddTicks(5149), "Atque qui a et id consequuntur qui. Praesentium excepturi vel facere. Harum tempore ipsum." },
                    { 42, 30, 87, 741786, new DateTime(2020, 12, 8, 19, 6, 4, 69, DateTimeKind.Local).AddTicks(7120), "Autem magni rerum minus impedit vel." },
                    { 190, 30, 69, 903403, new DateTime(2020, 6, 19, 16, 13, 13, 345, DateTimeKind.Local).AddTicks(7233), "Aspernatur saepe est eos magnam culpa culpa asperiores qui perferendis. Consequatur quam amet autem quae libero architecto ducimus inventore. Enim ut reiciendis." },
                    { 199, 30, 6, 549286, new DateTime(2021, 2, 11, 6, 9, 15, 785, DateTimeKind.Local).AddTicks(2693), "sint" },
                    { 537, 30, 87, 666917, new DateTime(2020, 8, 28, 11, 38, 49, 16, DateTimeKind.Local).AddTicks(8557), "Sed laboriosam dolores qui quo consequatur. Necessitatibus sed aliquam. Aut perspiciatis necessitatibus quia harum ex adipisci." },
                    { 274, 37, 3, 470278, new DateTime(2021, 1, 26, 1, 50, 21, 342, DateTimeKind.Local).AddTicks(8843), "Voluptas incidunt dolores at enim voluptatem perspiciatis." },
                    { 355, 53, 81, 680807, new DateTime(2020, 12, 9, 21, 15, 54, 971, DateTimeKind.Local).AddTicks(4763), "Ex fuga quo unde impedit minima error enim aut minima. Aut ad quis ab culpa. Aliquam cum dolor occaecati. Nihil rerum fugiat aliquam sequi est ipsam ullam. Qui soluta laborum." },
                    { 303, 73, 44, 61388, new DateTime(2020, 9, 27, 4, 56, 18, 605, DateTimeKind.Local).AddTicks(1572), "Similique vel rerum aut velit voluptate delectus incidunt magni.\nPerspiciatis ut veritatis ea accusantium distinctio quibusdam et eos itaque.\nCulpa non cupiditate at sed.\nVelit est iure.\nVoluptatibus sapiente distinctio et suscipit saepe sed vel ipsam asperiores.\nEt architecto soluta placeat." },
                    { 307, 73, 31, 239787, new DateTime(2020, 6, 16, 23, 51, 41, 210, DateTimeKind.Local).AddTicks(7206), "Aut commodi voluptas in culpa perferendis quisquam nemo corporis.\nConsectetur ullam dolorem voluptatum incidunt.\nNon nostrum voluptas minus fugiat porro.\nPraesentium autem quisquam maxime nihil necessitatibus nihil.\nReiciendis possimus harum et consequatur animi vitae saepe voluptate.\nNobis molestiae exercitationem dolores omnis hic rerum repudiandae rerum." },
                    { 461, 54, 83, 39038, new DateTime(2021, 2, 23, 16, 11, 43, 871, DateTimeKind.Local).AddTicks(1412), "Ipsam quis delectus nisi quo voluptatem fugit perferendis." },
                    { 540, 54, 72, 918995, new DateTime(2020, 9, 16, 15, 50, 35, 632, DateTimeKind.Local).AddTicks(5535), "natus" },
                    { 568, 54, 79, 876555, new DateTime(2020, 8, 14, 13, 0, 4, 480, DateTimeKind.Local).AddTicks(3130), "Praesentium est qui enim. Natus qui autem atque. Accusantium quis quam voluptatem ea officia fugiat expedita aut sunt." },
                    { 15, 74, 62, 598791, new DateTime(2021, 1, 21, 8, 4, 29, 172, DateTimeKind.Local).AddTicks(2610), "in" },
                    { 23, 74, 140, 450187, new DateTime(2020, 6, 5, 5, 43, 14, 998, DateTimeKind.Local).AddTicks(4630), "ipsam" },
                    { 142, 74, 111, 101148, new DateTime(2020, 8, 24, 21, 7, 3, 739, DateTimeKind.Local).AddTicks(8683), "minus" },
                    { 184, 74, 70, 153590, new DateTime(2020, 6, 3, 14, 57, 38, 286, DateTimeKind.Local).AddTicks(7134), "iure" },
                    { 444, 54, 116, 310399, new DateTime(2020, 7, 31, 20, 41, 29, 137, DateTimeKind.Local).AddTicks(1819), "nam" },
                    { 414, 74, 135, 913702, new DateTime(2021, 2, 18, 20, 52, 57, 751, DateTimeKind.Local).AddTicks(4009), "Totam rem sequi fugiat. Sed quis eveniet laboriosam a recusandae eum velit. Rerum et dolor aut consectetur molestiae. Aut exercitationem magni vel temporibus inventore." },
                    { 21, 88, 73, 512473, new DateTime(2021, 3, 15, 10, 40, 37, 475, DateTimeKind.Local).AddTicks(7658), "nam" },
                    { 113, 88, 93, 106131, new DateTime(2021, 3, 9, 23, 2, 5, 502, DateTimeKind.Local).AddTicks(9504), "Voluptatem dolorum ut doloremque. Architecto eum vero. Aut quidem officia. Atque ipsa dolor architecto suscipit fugit nulla cumque commodi enim. Optio nam quis repudiandae quod voluptates consectetur est non." },
                    { 270, 88, 74, 324157, new DateTime(2020, 11, 11, 10, 50, 36, 866, DateTimeKind.Local).AddTicks(5550), "Saepe quam ratione sint sint.\nError consequuntur autem totam voluptates dolores illum.\nItaque ullam quis officiis suscipit aut dolor et dolor.\nUt molestias rerum animi neque.\nMolestiae et delectus itaque quod cupiditate ipsum ut qui corrupti.\nAdipisci eveniet saepe itaque corrupti." },
                    { 338, 88, 37, 699410, new DateTime(2020, 8, 23, 1, 35, 34, 221, DateTimeKind.Local).AddTicks(2525), "Quo laboriosam quo corrupti totam aut maiores id.\nVitae consequatur tenetur cumque et quam." },
                    { 384, 88, 114, 84025, new DateTime(2020, 6, 3, 15, 59, 10, 198, DateTimeKind.Local).AddTicks(3400), "Sunt molestiae expedita iure numquam et quod adipisci.\nTempore corrupti eveniet.\nAut voluptatem quaerat consequatur dolor deserunt dolor voluptatum suscipit omnis." },
                    { 412, 88, 120, 968402, new DateTime(2020, 8, 27, 12, 13, 55, 59, DateTimeKind.Local).AddTicks(8800), "Atque quas mollitia aut consequatur quia ut est." },
                    { 36, 60, 129, 263227, new DateTime(2021, 2, 26, 21, 56, 28, 4, DateTimeKind.Local).AddTicks(2861), "Doloremque similique a et nostrum et doloremque." },
                    { 513, 74, 141, 642119, new DateTime(2021, 1, 18, 23, 59, 33, 141, DateTimeKind.Local).AddTicks(9172), "Placeat aut autem." },
                    { 248, 27, 67, 467855, new DateTime(2020, 12, 15, 14, 47, 14, 553, DateTimeKind.Local).AddTicks(2551), "Sapiente neque adipisci.\nId quasi numquam ut.\nCorrupti voluptatem ratione." },
                    { 256, 54, 130, 9627, new DateTime(2020, 6, 26, 9, 29, 36, 908, DateTimeKind.Local).AddTicks(6471), "Animi illo totam et totam qui est.\nOfficiis aut officiis sit et reprehenderit necessitatibus a accusantium.\nNam sint quas et quas voluptas.\nDolor dolorem sunt minus quae aut consectetur dolorem voluptatem sed." },
                    { 139, 54, 82, 51486, new DateTime(2020, 10, 6, 11, 50, 53, 461, DateTimeKind.Local).AddTicks(400), "Facilis labore quibusdam et enim soluta." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 332, 73, 133, 241947, new DateTime(2020, 8, 15, 13, 55, 3, 394, DateTimeKind.Local).AddTicks(1307), "Nostrum eum ipsam impedit qui repellendus eaque." },
                    { 335, 73, 51, 407534, new DateTime(2021, 2, 13, 10, 45, 45, 676, DateTimeKind.Local).AddTicks(7099), "Reiciendis est dolor repudiandae dolores nisi." },
                    { 488, 73, 141, 82491, new DateTime(2021, 2, 28, 2, 11, 15, 621, DateTimeKind.Local).AddTicks(7078), "Est neque ea. Ipsa sed distinctio nulla sit provident dolores sint natus incidunt. Iusto maxime quo quidem. Earum et tempora." },
                    { 500, 73, 38, 539325, new DateTime(2020, 10, 20, 17, 58, 32, 270, DateTimeKind.Local).AddTicks(5587), "Eius ipsa consequatur ut doloremque vel. Omnis ipsam maxime iste facilis. Aut error temporibus quis vel et voluptas ipsa. Quis animi assumenda eum quis pariatur voluptates neque repellendus. Quod labore et vel voluptatem eaque. Delectus molestiae et repellendus consequatur repellendus excepturi eum tempora." },
                    { 529, 73, 116, 393230, new DateTime(2020, 12, 14, 20, 11, 32, 88, DateTimeKind.Local).AddTicks(9454), "Vel et voluptatem at voluptatem molestiae commodi dicta inventore voluptate.\nTemporibus eos doloremque.\nAliquid ipsum tempora vitae quaerat.\nUt dicta laboriosam deserunt.\nRerum qui illum itaque cupiditate voluptatem voluptatem.\nAspernatur voluptates iure sed quia." },
                    { 545, 73, 112, 449715, new DateTime(2020, 11, 8, 20, 54, 34, 217, DateTimeKind.Local).AddTicks(6336), "Repellat consequatur velit." },
                    { 578, 73, 113, 317615, new DateTime(2021, 3, 24, 11, 44, 35, 733, DateTimeKind.Local).AddTicks(7282), "Dolor voluptatum delectus aspernatur facilis amet neque.\nReprehenderit praesentium at.\nEst dolores nisi doloremque quo." },
                    { 165, 54, 67, 369044, new DateTime(2020, 11, 23, 1, 29, 55, 918, DateTimeKind.Local).AddTicks(217), "vitae" },
                    { 592, 73, 1, 572521, new DateTime(2020, 9, 23, 8, 9, 22, 632, DateTimeKind.Local).AddTicks(4390), "et" },
                    { 193, 78, 61, 205890, new DateTime(2020, 5, 5, 9, 29, 28, 738, DateTimeKind.Local).AddTicks(4511), "reiciendis" },
                    { 214, 78, 28, 802331, new DateTime(2021, 2, 7, 14, 31, 12, 158, DateTimeKind.Local).AddTicks(5568), "Provident mollitia voluptatibus eos rerum consequatur dolorem." },
                    { 300, 78, 9, 504789, new DateTime(2020, 8, 20, 9, 13, 35, 223, DateTimeKind.Local).AddTicks(1749), "Qui molestias eos voluptatem non praesentium impedit esse quo quaerat.\nIllum minus accusantium.\nSaepe pariatur qui corrupti eligendi sed explicabo.\nImpedit iste ut molestiae enim illo velit vel.\nAut id unde qui porro et voluptatem aperiam placeat." },
                    { 310, 78, 26, 409374, new DateTime(2021, 3, 15, 10, 45, 16, 713, DateTimeKind.Local).AddTicks(5716), "Cumque nulla exercitationem minima dolor animi laborum esse quam." },
                    { 404, 78, 35, 672095, new DateTime(2020, 9, 15, 11, 27, 13, 834, DateTimeKind.Local).AddTicks(2016), "Veritatis molestiae quam quis dolor nobis dolor maiores blanditiis quo. Non ipsa rerum nesciunt a provident reiciendis. Qui cupiditate rem vel aut in. Quia illo est quam culpa." },
                    { 470, 78, 101, 558307, new DateTime(2021, 2, 27, 6, 37, 34, 220, DateTimeKind.Local).AddTicks(5388), "iste" },
                    { 64, 54, 120, 750024, new DateTime(2020, 9, 4, 17, 8, 5, 942, DateTimeKind.Local).AddTicks(3221), "Dignissimos nostrum officia asperiores accusantium eveniet quae quidem numquam eum. Tempora itaque cum. Quaerat repellat culpa id aperiam corporis eligendi placeat autem. Veritatis sint aperiam commodi at corrupti qui et quas. Perspiciatis nihil aut sit qui iste neque aperiam impedit eum. Odio error est quod amet officia fugit porro." },
                    { 153, 78, 128, 296087, new DateTime(2021, 4, 4, 10, 47, 51, 838, DateTimeKind.Local).AddTicks(2163), "Perferendis ipsum cum ipsam architecto ut beatae corporis inventore. Beatae blanditiis asperiores facilis. Deserunt explicabo fugit ab exercitationem hic eum qui vel commodi. Totam animi perferendis explicabo labore rem commodi iure et. Expedita veniam reiciendis dolorem ipsa quia vel voluptas magnam autem." },
                    { 138, 27, 44, 686547, new DateTime(2020, 5, 21, 22, 23, 56, 708, DateTimeKind.Local).AddTicks(2918), "Natus molestiae rerum." },
                    { 209, 15, 79, 333244, new DateTime(2021, 2, 16, 13, 55, 27, 436, DateTimeKind.Local).AddTicks(1478), "culpa" },
                    { 107, 16, 122, 157251, new DateTime(2020, 7, 18, 5, 53, 33, 696, DateTimeKind.Local).AddTicks(5374), "recusandae" },
                    { 235, 36, 52, 902854, new DateTime(2020, 9, 24, 0, 8, 31, 304, DateTimeKind.Local).AddTicks(3010), "Saepe molestiae asperiores consequatur rerum et ducimus ducimus. Ex velit culpa placeat sit minus voluptatem vel. Velit eius assumenda ut culpa ea enim consequatur beatae. Odit asperiores nostrum nesciunt aut fugit nulla voluptatum debitis. Quo qui qui est blanditiis fuga ratione aut. Culpa modi ea labore repudiandae quas." },
                    { 466, 36, 82, 944709, new DateTime(2020, 9, 24, 10, 45, 17, 448, DateTimeKind.Local).AddTicks(1357), "praesentium" },
                    { 502, 36, 71, 835590, new DateTime(2021, 1, 27, 20, 39, 46, 351, DateTimeKind.Local).AddTicks(6031), "Ratione consequatur quis et provident laudantium. Temporibus libero fuga repudiandae praesentium quidem cupiditate. Error harum quae et id doloribus. Ullam quasi in ad qui." },
                    { 32, 82, 25, 541620, new DateTime(2020, 9, 7, 15, 20, 7, 265, DateTimeKind.Local).AddTicks(8970), "Impedit velit voluptatum dolore debitis porro. Rerum ut eos. Eos ut ut excepturi quasi repellat perferendis. Sint in deleniti minima neque aut. Nesciunt qui distinctio explicabo. Alias quibusdam aut aut perspiciatis non eligendi et." },
                    { 13, 96, 16, 28302, new DateTime(2020, 12, 4, 2, 45, 24, 587, DateTimeKind.Local).AddTicks(3214), "Magnam repudiandae quia id est necessitatibus ipsum sequi provident delectus.\nAdipisci dolorem odio sunt placeat sed esse enim.\nSunt aut rerum et dolorem iure voluptatibus saepe similique non.\nFacilis eos eum modi sequi aut." },
                    { 19, 96, 87, 345405, new DateTime(2020, 9, 30, 7, 6, 43, 799, DateTimeKind.Local).AddTicks(1026), "ratione" },
                    { 227, 36, 26, 318182, new DateTime(2020, 12, 28, 13, 8, 49, 427, DateTimeKind.Local).AddTicks(5649), "Suscipit voluptates repudiandae modi qui voluptatum et nihil qui animi." },
                    { 53, 96, 40, 756941, new DateTime(2021, 2, 18, 7, 45, 46, 401, DateTimeKind.Local).AddTicks(7167), "Qui perspiciatis quia quia asperiores autem rem." },
                    { 149, 96, 58, 456003, new DateTime(2020, 12, 26, 23, 57, 33, 636, DateTimeKind.Local).AddTicks(7868), "Magnam voluptate nihil laborum quibusdam voluptate." },
                    { 237, 96, 40, 245259, new DateTime(2020, 7, 3, 15, 15, 48, 564, DateTimeKind.Local).AddTicks(5635), "sit" },
                    { 344, 96, 80, 279767, new DateTime(2020, 4, 24, 3, 37, 4, 119, DateTimeKind.Local).AddTicks(2564), "Temporibus blanditiis tenetur possimus qui. Perspiciatis repellat soluta sit. Ipsa cupiditate sit at nihil nihil neque dolorem iste et. Rem occaecati eius totam non placeat. Eos molestiae tempora molestiae velit recusandae est culpa." },
                    { 587, 79, 104, 519883, new DateTime(2021, 2, 14, 23, 28, 55, 279, DateTimeKind.Local).AddTicks(1055), "temporibus" },
                    { 130, 25, 9, 278425, new DateTime(2020, 11, 25, 22, 2, 26, 444, DateTimeKind.Local).AddTicks(4562), "Iste non accusamus quod ea sequi praesentium qui.\nLaudantium quo non excepturi vitae eos dolorum repellendus et.\nOmnis mollitia corporis nihil.\nSed et commodi optio sed magni ipsam.\nEst excepturi sit.\nRecusandae eos delectus illum non dolore." },
                    { 222, 25, 11, 322261, new DateTime(2020, 10, 5, 9, 36, 38, 914, DateTimeKind.Local).AddTicks(289), "rerum" },
                    { 146, 62, 122, 216471, new DateTime(2020, 12, 21, 16, 2, 19, 4, DateTimeKind.Local).AddTicks(5750), "id" },
                    { 223, 25, 72, 731572, new DateTime(2021, 3, 5, 12, 34, 12, 641, DateTimeKind.Local).AddTicks(5666), "Vel illo sit quia.\nTotam aliquam consequatur rem incidunt.\nVoluptas eligendi ipsa in molestiae perspiciatis aut sint doloribus incidunt.\nA illo sint iusto et ut maxime.\nSuscipit qui nisi dolores neque ducimus.\nA nam cum enim qui rem." },
                    { 131, 82, 38, 253484, new DateTime(2021, 2, 22, 12, 26, 49, 204, DateTimeKind.Local).AddTicks(5864), "Quo tempore iusto maxime ex quia." },
                    { 516, 83, 98, 502072, new DateTime(2021, 3, 11, 4, 27, 4, 759, DateTimeKind.Local).AddTicks(3514), "Quis et temporibus rerum soluta facilis.\nOccaecati totam aut sint saepe voluptates voluptatibus distinctio voluptates." },
                    { 126, 49, 76, 271568, new DateTime(2020, 9, 28, 1, 30, 46, 347, DateTimeKind.Local).AddTicks(898), "Modi architecto voluptatem qui sint. Qui dolores qui modi voluptatem. Inventore tempore quasi enim amet magni nobis perferendis nisi omnis." },
                    { 257, 49, 92, 947916, new DateTime(2021, 3, 14, 18, 16, 26, 8, DateTimeKind.Local).AddTicks(5396), "Odio voluptatem culpa dicta.\nTemporibus repudiandae reprehenderit omnis vero illo.\nOdit rerum unde eos placeat nobis voluptatem fugit beatae eum.\nSoluta molestias et at." },
                    { 595, 49, 88, 174301, new DateTime(2020, 7, 26, 10, 28, 57, 227, DateTimeKind.Local).AddTicks(9547), "Tempora quisquam omnis autem consequuntur aliquam facilis." },
                    { 8, 21, 107, 151004, new DateTime(2020, 6, 16, 12, 45, 33, 639, DateTimeKind.Local).AddTicks(6835), "voluptatum" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 71, 21, 9, 387303, new DateTime(2020, 10, 19, 5, 57, 59, 845, DateTimeKind.Local).AddTicks(972), "optio" },
                    { 82, 21, 58, 637305, new DateTime(2020, 10, 1, 4, 14, 17, 302, DateTimeKind.Local).AddTicks(9388), "corrupti" },
                    { 170, 36, 15, 839507, new DateTime(2020, 7, 30, 13, 31, 41, 462, DateTimeKind.Local).AddTicks(1263), "Ut optio rerum. Dolor tempora dolorem modi est voluptatem occaecati dolores placeat. Et non suscipit voluptas. Ea numquam cumque nemo sunt est qui et consequatur suscipit. Et magni aut esse voluptatibus. Modi sed eaque voluptates odio." },
                    { 92, 21, 69, 617274, new DateTime(2020, 12, 27, 2, 55, 55, 867, DateTimeKind.Local).AddTicks(7061), "Eligendi sed architecto ut earum laborum quasi et." },
                    { 441, 21, 20, 130814, new DateTime(2020, 4, 22, 0, 48, 50, 421, DateTimeKind.Local).AddTicks(4192), "beatae" },
                    { 207, 82, 134, 541362, new DateTime(2020, 9, 13, 16, 4, 48, 438, DateTimeKind.Local).AddTicks(1727), "Illo numquam nihil qui." },
                    { 446, 21, 4, 323809, new DateTime(2020, 12, 20, 20, 5, 20, 480, DateTimeKind.Local).AddTicks(1710), "Vel delectus sint incidunt cum maiores ipsum inventore aut. Quaerat fugiat itaque autem laboriosam voluptatem nisi sed. Repudiandae molestias voluptas quis expedita provident." },
                    { 164, 83, 65, 989809, new DateTime(2020, 5, 24, 7, 31, 11, 718, DateTimeKind.Local).AddTicks(2144), "Qui aut molestias perferendis sit id voluptas incidunt aut temporibus.\nId magni illo excepturi illum commodi voluptates autem.\nNon explicabo odit nobis nam laudantium sint et cupiditate." },
                    { 188, 83, 25, 289299, new DateTime(2020, 9, 20, 0, 59, 15, 352, DateTimeKind.Local).AddTicks(5278), "Repudiandae distinctio officiis accusamus error nam similique qui quaerat eum.\nVero soluta distinctio cumque exercitationem culpa odio officiis architecto.\nAtque debitis rerum dolores.\nTotam et deserunt aliquam quia quod deserunt quisquam neque labore.\nRerum vero perferendis labore nulla voluptatem.\nDelectus tempora ipsum asperiores." },
                    { 336, 83, 52, 735795, new DateTime(2020, 10, 7, 3, 24, 49, 341, DateTimeKind.Local).AddTicks(1586), "Nostrum vitae tempora numquam et magnam nihil omnis." },
                    { 286, 21, 59, 533661, new DateTime(2020, 8, 16, 16, 4, 12, 528, DateTimeKind.Local).AddTicks(4113), "Est eum placeat." },
                    { 88, 49, 35, 404798, new DateTime(2020, 6, 12, 18, 55, 59, 288, DateTimeKind.Local).AddTicks(8812), "Qui totam nulla.\nNon voluptatem ab numquam vel.\nVoluptate nobis aut debitis in consequuntur autem.\nQuibusdam nisi commodi.\nPariatur ipsa consectetur ipsum repudiandae nihil illo ex optio." },
                    { 293, 79, 132, 788009, new DateTime(2020, 12, 31, 0, 49, 50, 216, DateTimeKind.Local).AddTicks(8831), "Sit assumenda quia veniam et ex enim sed delectus. Recusandae quis ea qui ut dolorem reprehenderit et animi similique. Ad est qui ipsum nihil quod aliquid officiis. Velit omnis ut magni perferendis ipsam neque mollitia." },
                    { 345, 25, 134, 177094, new DateTime(2020, 11, 26, 2, 29, 34, 797, DateTimeKind.Local).AddTicks(3951), "Autem autem aut aliquam ut minus voluptatum magnam reiciendis. Et quis maiores. Ut tempore harum quibusdam ea qui. Est fugit aut dicta neque consequuntur qui aut eos accusantium. Minus impedit qui nulla qui ad deleniti et." },
                    { 549, 93, 131, 574579, new DateTime(2021, 1, 6, 14, 7, 38, 990, DateTimeKind.Local).AddTicks(9128), "Expedita eos ipsa sed nesciunt corporis.\nLabore at corporis fugit quo ipsa veniam.\nIpsum accusamus asperiores nihil nisi.\nEt accusantium dolores fugit.\nPossimus aut repudiandae mollitia exercitationem rerum sed." },
                    { 212, 79, 7, 785740, new DateTime(2021, 3, 21, 21, 44, 13, 477, DateTimeKind.Local).AddTicks(9181), "harum" },
                    { 99, 84, 142, 473342, new DateTime(2021, 4, 4, 18, 52, 27, 339, DateTimeKind.Local).AddTicks(6774), "Dolor officia fugit. Nobis harum facere. Voluptatem fuga quibusdam. Aspernatur quia minima placeat ut nihil soluta nihil voluptas." },
                    { 135, 84, 65, 24141, new DateTime(2020, 10, 9, 11, 17, 36, 853, DateTimeKind.Local).AddTicks(1747), "Nihil quia aut consequatur esse illo molestiae fugiat velit.\nEst quia praesentium ut rerum placeat aliquam aperiam iste.\nPerferendis rem dolorem.\nMolestiae nihil quos tempore qui qui quod.\nNostrum pariatur est et ducimus amet voluptatum et sequi.\nRepellendus et ut." },
                    { 183, 84, 78, 695751, new DateTime(2021, 1, 28, 15, 35, 48, 573, DateTimeKind.Local).AddTicks(7021), "nemo" },
                    { 394, 84, 25, 133354, new DateTime(2020, 7, 16, 8, 44, 38, 984, DateTimeKind.Local).AddTicks(4967), "sed" },
                    { 473, 93, 34, 69096, new DateTime(2021, 3, 10, 9, 39, 25, 344, DateTimeKind.Local).AddTicks(7983), "Vel eaque atque velit est eos modi unde ad odio.\nSunt consectetur ipsam.\nMolestiae eum optio perspiciatis unde consequatur.\nEst rem ab mollitia officiis quasi animi." },
                    { 47, 62, 133, 110831, new DateTime(2020, 11, 14, 15, 7, 24, 872, DateTimeKind.Local).AddTicks(17), "explicabo" },
                    { 156, 95, 135, 912036, new DateTime(2020, 7, 6, 2, 20, 47, 653, DateTimeKind.Local).AddTicks(81), "Sint pariatur voluptates facilis cumque nihil minima." },
                    { 160, 95, 18, 186414, new DateTime(2020, 5, 13, 10, 11, 9, 767, DateTimeKind.Local).AddTicks(2597), "Corporis sunt et enim recusandae." },
                    { 546, 16, 28, 371344, new DateTime(2021, 3, 30, 21, 21, 22, 610, DateTimeKind.Local).AddTicks(8886), "et" },
                    { 200, 95, 12, 565092, new DateTime(2020, 11, 16, 14, 46, 4, 744, DateTimeKind.Local).AddTicks(9981), "veritatis" },
                    { 210, 95, 34, 153995, new DateTime(2021, 4, 11, 9, 1, 13, 24, DateTimeKind.Local).AddTicks(2399), "assumenda" },
                    { 477, 95, 92, 620274, new DateTime(2020, 8, 21, 17, 48, 5, 355, DateTimeKind.Local).AddTicks(5527), "Ut ut maiores error doloremque eius nostrum eum adipisci dolor." },
                    { 86, 95, 93, 116622, new DateTime(2020, 8, 3, 5, 0, 52, 972, DateTimeKind.Local).AddTicks(3959), "nobis" },
                    { 226, 25, 144, 837273, new DateTime(2020, 5, 17, 21, 45, 23, 350, DateTimeKind.Local).AddTicks(7816), "Et quisquam quia molestiae fugit quia dolores consectetur." },
                    { 385, 93, 137, 955040, new DateTime(2020, 5, 8, 7, 20, 56, 418, DateTimeKind.Local).AddTicks(2021), "Natus omnis rerum doloremque aut vel ducimus sed. Iusto et maxime quasi laudantium suscipit. Modi voluptatem quia nesciunt. Consequatur inventore sequi nesciunt. Debitis temporibus corporis suscipit eveniet et voluptatum enim fugit." },
                    { 228, 93, 63, 544231, new DateTime(2021, 4, 1, 17, 12, 58, 924, DateTimeKind.Local).AddTicks(3468), "Iste et repudiandae sint." },
                    { 495, 25, 139, 138459, new DateTime(2020, 6, 12, 5, 17, 47, 933, DateTimeKind.Local).AddTicks(293), "Quaerat maiores fugit possimus soluta." },
                    { 65, 27, 54, 8277, new DateTime(2020, 4, 22, 22, 13, 18, 72, DateTimeKind.Local).AddTicks(1415), "sapiente" },
                    { 553, 25, 128, 254571, new DateTime(2020, 8, 28, 0, 28, 21, 198, DateTimeKind.Local).AddTicks(3526), "Tempora distinctio nesciunt voluptatem veritatis odit.\nQuia amet rerum temporibus quasi et atque quis.\nCulpa sapiente aut omnis neque et aut." },
                    { 196, 34, 38, 931164, new DateTime(2021, 2, 25, 8, 1, 43, 721, DateTimeKind.Local).AddTicks(4920), "aperiam" },
                    { 421, 34, 83, 622881, new DateTime(2020, 11, 1, 13, 6, 5, 694, DateTimeKind.Local).AddTicks(3645), "Est sed neque id. Dolor beatae aut delectus dignissimos adipisci. Error hic impedit autem quidem asperiores quo ipsa ea debitis. Est voluptatem rerum aperiam nulla eius." },
                    { 452, 34, 121, 350868, new DateTime(2020, 7, 29, 15, 55, 22, 888, DateTimeKind.Local).AddTicks(9066), "Ut corporis necessitatibus asperiores voluptas sed excepturi officia. Odio laboriosam labore. Quia ab perspiciatis est velit et et sint. Earum voluptas expedita nostrum nihil. Quidem ex non. Pariatur vitae omnis odio et sed iure illum." },
                    { 322, 93, 43, 836926, new DateTime(2021, 2, 7, 3, 8, 9, 602, DateTimeKind.Local).AddTicks(2513), "quod" },
                    { 471, 34, 73, 559129, new DateTime(2020, 10, 31, 14, 44, 54, 785, DateTimeKind.Local).AddTicks(2766), "Omnis unde rem qui autem ut." },
                    { 275, 79, 144, 147677, new DateTime(2021, 1, 23, 14, 58, 37, 648, DateTimeKind.Local).AddTicks(6769), "ex" },
                    { 507, 34, 42, 149361, new DateTime(2020, 7, 19, 21, 35, 44, 17, DateTimeKind.Local).AddTicks(6202), "Non totam deserunt assumenda neque accusamus tempora blanditiis nulla esse." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 30, 93, 47, 402594, new DateTime(2020, 7, 19, 12, 21, 8, 42, DateTimeKind.Local).AddTicks(4461), "Eius ut tempore officia laboriosam ut et sint.\nCorrupti placeat magnam voluptatum itaque quia eligendi.\nNisi officiis incidunt non ut iure a.\nQui libero odit saepe quo occaecati excepturi." },
                    { 77, 93, 80, 435987, new DateTime(2020, 7, 25, 5, 14, 47, 607, DateTimeKind.Local).AddTicks(8507), "Eos veniam aut aut aliquid rerum veniam necessitatibus.\nEum nisi atque architecto voluptatibus odio fugit asperiores sapiente.\nQuae repellendus culpa sed dolor." },
                    { 95, 93, 76, 937801, new DateTime(2020, 7, 17, 12, 41, 43, 364, DateTimeKind.Local).AddTicks(9829), "Nulla debitis quam et ullam vero et soluta non. Officiis omnis sit optio inventore sed quidem et. Qui quo sed omnis." },
                    { 105, 93, 108, 388596, new DateTime(2020, 10, 3, 0, 47, 45, 775, DateTimeKind.Local).AddTicks(9236), "Dolor soluta nam.\nVeniam et qui voluptatum adipisci ut magnam officiis.\nQui ipsa ipsam alias tenetur accusamus illo facere facere perferendis.\nRerum esse non eveniet sit et est ducimus.\nQuae placeat iusto delectus." },
                    { 498, 34, 24, 748199, new DateTime(2021, 3, 10, 6, 59, 46, 361, DateTimeKind.Local).AddTicks(702), "Voluptas iure et omnis exercitationem quia." },
                    { 25, 18, 118, 288935, new DateTime(2020, 8, 29, 19, 34, 33, 912, DateTimeKind.Local).AddTicks(8787), "Repellendus ea maxime modi quos. Voluptatem unde repellendus accusamus ipsum a ab quis et. Qui ea reprehenderit quasi assumenda est animi. Explicabo non facere at praesentium." },
                    { 33, 49, 121, 374533, new DateTime(2020, 10, 6, 22, 47, 59, 808, DateTimeKind.Local).AddTicks(719), "Quia natus necessitatibus nam sunt ea excepturi repellat voluptas tempora. Ipsam eos quidem iste et quis eos ea dolorum et. Et delectus qui nemo culpa est autem possimus voluptatem. Id aut quasi mollitia magnam repellat." },
                    { 234, 62, 114, 426239, new DateTime(2020, 5, 1, 8, 39, 30, 283, DateTimeKind.Local).AddTicks(2905), "Eveniet explicabo explicabo voluptatibus ut praesentium ipsum voluptas." },
                    { 127, 5, 84, 154969, new DateTime(2020, 4, 20, 11, 16, 56, 537, DateTimeKind.Local).AddTicks(4384), "labore" },
                    { 306, 5, 79, 130818, new DateTime(2021, 2, 21, 7, 24, 37, 557, DateTimeKind.Local).AddTicks(4069), "Doloribus tempora id est architecto sed commodi." },
                    { 349, 5, 91, 812139, new DateTime(2020, 8, 6, 20, 29, 22, 558, DateTimeKind.Local).AddTicks(5850), "eligendi" },
                    { 597, 5, 119, 12361, new DateTime(2020, 11, 8, 12, 50, 57, 926, DateTimeKind.Local).AddTicks(3546), "Ratione mollitia est nesciunt sequi voluptatem et. Excepturi consequuntur iure sunt. Aut incidunt voluptas ab. Sint sint quisquam sunt occaecati sed iste consequatur ipsam. Minima ut aperiam dolore est autem necessitatibus maiores. Qui odio ipsam molestias ex necessitatibus aut velit." },
                    { 447, 4, 112, 663430, new DateTime(2021, 2, 16, 6, 35, 59, 35, DateTimeKind.Local).AddTicks(64), "ut" },
                    { 365, 4, 33, 880938, new DateTime(2020, 5, 3, 22, 28, 21, 202, DateTimeKind.Local).AddTicks(3606), "fuga" },
                    { 43, 5, 15, 133431, new DateTime(2020, 9, 20, 1, 17, 46, 121, DateTimeKind.Local).AddTicks(1739), "Quo est temporibus odit dolores autem sunt." },
                    { 78, 41, 101, 762611, new DateTime(2020, 11, 6, 11, 27, 34, 335, DateTimeKind.Local).AddTicks(9875), "Saepe ipsa enim in voluptas reprehenderit labore maxime reiciendis quam. Repellendus voluptatem harum dolorem voluptatem laborum illum odio sint. Sequi voluptas molestiae natus maxime. Magnam repudiandae tenetur placeat necessitatibus ut eos qui." },
                    { 266, 41, 7, 708888, new DateTime(2020, 8, 22, 1, 44, 6, 565, DateTimeKind.Local).AddTicks(1854), "Repellendus provident soluta enim." },
                    { 416, 41, 137, 941676, new DateTime(2020, 6, 26, 1, 6, 30, 557, DateTimeKind.Local).AddTicks(3232), "rerum" },
                    { 422, 41, 133, 853120, new DateTime(2020, 6, 19, 10, 57, 17, 730, DateTimeKind.Local).AddTicks(2731), "Doloribus id qui architecto.\nEst ipsam quibusdam vero explicabo adipisci aut non ducimus.\nQuidem aut exercitationem voluptas vel consequuntur.\nNisi iste placeat ut distinctio sint." },
                    { 454, 41, 30, 384676, new DateTime(2021, 1, 6, 11, 11, 42, 256, DateTimeKind.Local).AddTicks(3947), "Dolorum in veritatis velit consequuntur id." },
                    { 381, 62, 139, 880694, new DateTime(2020, 11, 17, 9, 25, 47, 162, DateTimeKind.Local).AddTicks(3109), "Maxime consequatur explicabo quis quas enim est reiciendis nulla non." },
                    { 524, 41, 68, 947739, new DateTime(2020, 6, 11, 11, 20, 10, 931, DateTimeKind.Local).AddTicks(6845), "Blanditiis voluptatibus natus occaecati et id consequuntur adipisci harum." },
                    { 187, 41, 91, 583144, new DateTime(2021, 1, 7, 19, 4, 22, 809, DateTimeKind.Local).AddTicks(7359), "Eos omnis debitis quia assumenda.\nCumque culpa est sed assumenda quia libero vel exercitationem culpa.\nArchitecto eveniet ad facere quam soluta aut doloribus.\nAb possimus vitae at et." },
                    { 585, 41, 26, 486154, new DateTime(2021, 3, 6, 19, 25, 50, 427, DateTimeKind.Local).AddTicks(7972), "Nisi rerum voluptatem eum autem reprehenderit iusto sed.\nExercitationem accusamus dolores impedit aperiam quaerat.\nTempora laboriosam dolorum consequatur molestias et numquam recusandae necessitatibus.\nEaque dolorem quod quos officia asperiores." },
                    { 522, 32, 69, 982338, new DateTime(2020, 11, 11, 1, 52, 39, 51, DateTimeKind.Local).AddTicks(3277), "Aut porro voluptatum necessitatibus ut." },
                    { 425, 32, 75, 689310, new DateTime(2021, 4, 13, 12, 2, 7, 787, DateTimeKind.Local).AddTicks(6426), "Nam ab occaecati voluptatem saepe voluptas deserunt veritatis et aut." },
                    { 66, 9, 75, 469817, new DateTime(2021, 1, 18, 15, 21, 7, 507, DateTimeKind.Local).AddTicks(7814), "Et cum voluptatem iste eveniet in veniam. Qui distinctio eaque voluptate quasi fuga. Ut fuga nam eveniet suscipit. Saepe dolore consequatur voluptates necessitatibus eius rem unde necessitatibus tempore. Autem dolores aut rerum nihil sit nostrum consectetur eum." },
                    { 104, 9, 78, 899796, new DateTime(2021, 4, 13, 2, 22, 38, 518, DateTimeKind.Local).AddTicks(9318), "Et tenetur aut dolores non. Et neque tempore. Provident et quos porro quas rerum doloremque odit." },
                    { 251, 9, 119, 725050, new DateTime(2020, 9, 30, 1, 26, 53, 706, DateTimeKind.Local).AddTicks(2596), "Dolore tempora vero repellat possimus.\nEligendi recusandae inventore vel tempora nostrum nesciunt.\nAnimi sint perferendis enim consequatur.\nSit voluptatem assumenda.\nRecusandae et at quis voluptatem blanditiis illum cumque." },
                    { 555, 4, 26, 75611, new DateTime(2020, 10, 30, 19, 33, 6, 468, DateTimeKind.Local).AddTicks(7614), "Explicabo ullam modi quidem dignissimos voluptas.\nSaepe saepe eveniet aut sint ea maxime.\nQuaerat qui nobis cupiditate assumenda consequatur quaerat.\nNostrum ea officia exercitationem repudiandae porro." },
                    { 317, 9, 27, 189318, new DateTime(2020, 11, 1, 0, 29, 48, 396, DateTimeKind.Local).AddTicks(3758), "delectus" },
                    { 401, 9, 70, 752987, new DateTime(2020, 12, 18, 3, 4, 38, 682, DateTimeKind.Local).AddTicks(812), "Nobis iusto suscipit architecto quia et soluta eum." },
                    { 486, 32, 8, 349926, new DateTime(2020, 8, 16, 22, 28, 19, 630, DateTimeKind.Local).AddTicks(2246), "Est ratione eum." },
                    { 478, 9, 143, 852704, new DateTime(2020, 8, 27, 0, 32, 54, 58, DateTimeKind.Local).AddTicks(698), "Omnis iusto voluptatem dolores." },
                    { 84, 32, 133, 668393, new DateTime(2020, 6, 27, 15, 0, 56, 184, DateTimeKind.Local).AddTicks(9991), "Nesciunt delectus consequatur. Quis nostrum fugiat quo facere quibusdam rem. Ipsum neque ratione vel quisquam delectus repellat tempore voluptas. Ut voluptatum quam velit." },
                    { 163, 32, 101, 137728, new DateTime(2020, 11, 24, 20, 15, 26, 266, DateTimeKind.Local).AddTicks(5887), "Qui eveniet sunt blanditiis minima sint. Officia quo eligendi. Perspiciatis laudantium voluptatem reiciendis rerum possimus repellendus temporibus nam omnis. Nam non nam natus omnis. Provident velit debitis omnis harum tempore reprehenderit quae pariatur et. Consequuntur velit et." },
                    { 501, 4, 43, 610799, new DateTime(2020, 5, 16, 16, 40, 30, 266, DateTimeKind.Local).AddTicks(7664), "Qui facere voluptate in velit odio. Accusamus sequi a ipsum et reprehenderit voluptates. Totam sit reiciendis aut." },
                    { 277, 32, 124, 174086, new DateTime(2020, 9, 1, 5, 0, 46, 414, DateTimeKind.Local).AddTicks(5268), "Praesentium repellat repellat assumenda est earum.\nEsse quia consequatur eos molestias." },
                    { 402, 32, 138, 715679, new DateTime(2020, 6, 5, 16, 1, 43, 135, DateTimeKind.Local).AddTicks(206), "Architecto qui quia dolor unde qui maiores repellendus. Dolorum assumenda quisquam voluptatibus sit. Et modi molestiae voluptates. Reprehenderit vel repellendus eum debitis et. Reiciendis repudiandae quia dolorum beatae voluptatem illum magnam." },
                    { 419, 32, 97, 744293, new DateTime(2020, 8, 19, 21, 4, 28, 8, DateTimeKind.Local).AddTicks(4834), "nesciunt" },
                    { 503, 4, 39, 299626, new DateTime(2021, 3, 22, 20, 2, 17, 249, DateTimeKind.Local).AddTicks(8457), "Exercitationem sequi dolores quisquam nihil nihil exercitationem animi labore.\nIste accusamus laboriosam in molestias ab ea.\nSed est praesentium eum." },
                    { 481, 82, 82, 900255, new DateTime(2020, 8, 16, 20, 41, 29, 263, DateTimeKind.Local).AddTicks(3954), "Vitae repudiandae perspiciatis molestiae voluptates sit quos.\nAperiam fugit ipsa aut saepe molestiae eum harum rerum.\nVoluptatem blanditiis placeat consequatur rerum ab.\nNostrum ab eveniet animi ea rerum ea repellendus saepe.\nBlanditiis repellat laboriosam nostrum animi." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 347, 4, 63, 81520, new DateTime(2021, 2, 27, 17, 19, 41, 354, DateTimeKind.Local).AddTicks(4977), "Accusamus pariatur ut.\nVel odit autem ullam rerum consequatur dolores.\nMaxime et nihil at maxime sint aut esse quia molestiae." },
                    { 172, 72, 85, 119144, new DateTime(2020, 6, 14, 4, 9, 28, 342, DateTimeKind.Local).AddTicks(738), "Sint facere quaerat. Qui nemo ut deserunt unde esse. Voluptates ea in officia rerum qui natus aut impedit est. Tenetur qui et nihil nemo fugiat iste commodi nihil odio." },
                    { 250, 20, 49, 752684, new DateTime(2020, 7, 16, 0, 28, 44, 12, DateTimeKind.Local).AddTicks(6984), "Cupiditate dolores deserunt voluptatem et et consequatur ullam. Et non amet ea molestiae rerum omnis consequatur dolores. Ut et qui. Ullam doloribus suscipit perferendis at. Officia dolorum eos ipsum vitae. Recusandae nulla earum veniam." },
                    { 382, 20, 42, 348035, new DateTime(2020, 12, 10, 0, 30, 49, 623, DateTimeKind.Local).AddTicks(4947), "Non in quo id ex ducimus dolores. Dolorem non ad occaecati nesciunt sint magnam vel sed maxime. Similique tempora voluptas sed quae perspiciatis fugit ut perspiciatis. Id sint suscipit in voluptatem. Dolor et sed reprehenderit ea a iusto cum. Esse blanditiis est eligendi nesciunt et dicta dolor eos." },
                    { 410, 20, 25, 315995, new DateTime(2020, 4, 21, 23, 54, 7, 553, DateTimeKind.Local).AddTicks(2184), "Possimus quis ab ut qui numquam voluptatem." },
                    { 469, 20, 132, 783979, new DateTime(2020, 10, 1, 17, 31, 31, 270, DateTimeKind.Local).AddTicks(1686), "Commodi consequatur nostrum rerum reprehenderit sit. Quidem fugiat similique. Aliquid eos expedita omnis reiciendis recusandae ipsum. Et unde voluptatibus sit aut." },
                    { 93, 45, 32, 304132, new DateTime(2021, 1, 7, 2, 34, 23, 370, DateTimeKind.Local).AddTicks(1441), "Est non corporis at dignissimos vitae aut ut. Iure et consectetur voluptatem magni. Omnis non provident nesciunt molestias dolor. Sint dolore voluptatem consequatur dolor id ipsum mollitia." },
                    { 103, 45, 48, 888103, new DateTime(2021, 2, 5, 1, 15, 17, 318, DateTimeKind.Local).AddTicks(2964), "qui" },
                    { 144, 4, 69, 919388, new DateTime(2021, 1, 24, 18, 52, 55, 769, DateTimeKind.Local).AddTicks(4500), "Veniam assumenda voluptates consequuntur cum ad enim." },
                    { 132, 45, 96, 25607, new DateTime(2020, 10, 25, 7, 8, 47, 127, DateTimeKind.Local).AddTicks(6707), "Voluptas est qui voluptatem nobis quo repellat placeat eligendi.\nFacilis et sit similique ut sint molestiae quis.\nOmnis et maiores ducimus.\nSimilique tempore sint consequatur beatae fuga nobis animi." },
                    { 201, 45, 45, 684258, new DateTime(2020, 6, 17, 12, 37, 35, 846, DateTimeKind.Local).AddTicks(5236), "Iusto omnis aut." },
                    { 254, 45, 63, 123434, new DateTime(2020, 12, 22, 6, 7, 38, 143, DateTimeKind.Local).AddTicks(7898), "itaque" },
                    { 523, 82, 112, 952135, new DateTime(2020, 9, 20, 12, 38, 8, 281, DateTimeKind.Local).AddTicks(7978), "et" },
                    { 285, 45, 145, 305204, new DateTime(2020, 5, 22, 18, 43, 49, 256, DateTimeKind.Local).AddTicks(587), "Accusantium molestias quae dignissimos sit alias consectetur.\nAt vero autem quia cupiditate omnis odio eaque qui consectetur." },
                    { 435, 45, 36, 81078, new DateTime(2021, 3, 16, 22, 53, 8, 884, DateTimeKind.Local).AddTicks(1290), "Accusamus ut aut soluta dolorem qui ut. Voluptatem sunt est odio. Facilis accusantium accusamus porro nemo rem animi animi voluptatem ullam. Dolores pariatur et dolor commodi itaque velit. Quia reiciendis voluptas omnis voluptatem exercitationem accusantium nisi omnis. Excepturi doloremque et expedita eius sed architecto doloremque." },
                    { 530, 45, 53, 854021, new DateTime(2020, 10, 28, 4, 25, 33, 281, DateTimeKind.Local).AddTicks(9300), "Eos dignissimos dicta laboriosam a.\nLaborum harum facere voluptas perspiciatis molestiae voluptatem cum.\nPerspiciatis enim quia aut architecto assumenda officiis non blanditiis sapiente.\nAut maxime et.\nAssumenda occaecati et enim est quas.\nDeleniti reiciendis dolor voluptate reprehenderit excepturi aliquam commodi." },
                    { 166, 45, 125, 120335, new DateTime(2020, 4, 25, 22, 29, 25, 770, DateTimeKind.Local).AddTicks(6777), "Delectus eos vel reprehenderit et consectetur officiis voluptatem hic. Recusandae officia ipsa ex optio qui aliquid quisquam eius. Impedit doloribus et rerum nemo magni." },
                    { 12, 72, 24, 981469, new DateTime(2020, 4, 25, 9, 52, 5, 722, DateTimeKind.Local).AddTicks(6609), "Est totam velit nihil et." },
                    { 239, 20, 99, 577522, new DateTime(2021, 3, 31, 6, 21, 34, 705, DateTimeKind.Local).AddTicks(1985), "Sed ex quibusdam delectus consequatur asperiores dolor voluptatem fugiat." },
                    { 192, 20, 110, 378121, new DateTime(2020, 5, 13, 9, 20, 1, 883, DateTimeKind.Local).AddTicks(992), "Sunt doloremque eaque iusto voluptatem." },
                    { 331, 72, 120, 420091, new DateTime(2020, 12, 24, 9, 0, 34, 197, DateTimeKind.Local).AddTicks(7704), "Accusantium incidunt velit consequuntur vel quod quia dignissimos aut. A doloremque expedita omnis quae consectetur aut voluptatibus odio ut. Dolores quisquam dolorem cum modi culpa voluptas in. Repudiandae et voluptas nulla." },
                    { 313, 4, 13, 935975, new DateTime(2020, 9, 13, 21, 56, 37, 896, DateTimeKind.Local).AddTicks(9183), "Quidem tenetur qui est explicabo voluptas temporibus voluptatem ut." },
                    { 396, 72, 89, 207083, new DateTime(2021, 2, 15, 19, 23, 52, 560, DateTimeKind.Local).AddTicks(2181), "Nihil aut quia quod tenetur laboriosam omnis.\nVel et error vitae atque corporis ab rerum odit earum.\nVeritatis ea praesentium corporis officiis quaerat est quaerat incidunt.\nConsectetur ea hic.\nExcepturi esse consectetur." },
                    { 583, 72, 24, 733112, new DateTime(2021, 1, 22, 1, 6, 52, 271, DateTimeKind.Local).AddTicks(1914), "Excepturi quisquam voluptates ut aperiam quos.\nUt praesentium amet." },
                    { 116, 75, 80, 874810, new DateTime(2020, 5, 9, 0, 21, 59, 327, DateTimeKind.Local).AddTicks(7069), "odio" },
                    { 120, 75, 21, 623102, new DateTime(2020, 5, 26, 2, 15, 6, 98, DateTimeKind.Local).AddTicks(5515), "Vero minima ex eius occaecati dolores.\nVoluptas accusantium commodi eos non quisquam voluptas repellat aut.\nDeleniti nesciunt aperiam repudiandae qui earum aperiam ut." },
                    { 219, 20, 96, 70741, new DateTime(2021, 4, 9, 0, 32, 10, 622, DateTimeKind.Local).AddTicks(7685), "Voluptatibus dolor quia ut.\nMolestiae aperiam a vero.\nVelit est eum ea voluptatem vel molestiae ut." },
                    { 182, 75, 70, 199322, new DateTime(2020, 6, 8, 10, 54, 57, 777, DateTimeKind.Local).AddTicks(6595), "Ea dignissimos voluptates possimus corrupti." },
                    { 485, 75, 101, 502995, new DateTime(2020, 11, 9, 11, 47, 13, 75, DateTimeKind.Local).AddTicks(6152), "id" },
                    { 489, 75, 150, 732730, new DateTime(2020, 7, 11, 2, 11, 6, 254, DateTimeKind.Local).AddTicks(6018), "Vel dicta commodi quos explicabo expedita quod." },
                    { 532, 75, 17, 123386, new DateTime(2020, 4, 29, 16, 1, 51, 671, DateTimeKind.Local).AddTicks(7611), "Minus doloribus odit odit quasi eos perspiciatis dolorum et. Laboriosam ipsa ut dolores. Ipsa tempore et qui aspernatur magni harum voluptas ut officiis. Maiores rem facere magnam hic consectetur nobis voluptatem. Atque cumque nobis architecto." },
                    { 177, 12, 7, 222826, new DateTime(2021, 2, 13, 22, 51, 12, 483, DateTimeKind.Local).AddTicks(2805), "Aspernatur hic recusandae temporibus sed delectus voluptatem. Non recusandae aut ea voluptas. Adipisci voluptas nobis ex. Mollitia explicabo est voluptatem voluptatem et tempora dolorem. Et officiis et nostrum atque quam provident quisquam provident rerum. Vitae omnis sed est aut quia." },
                    { 392, 12, 143, 439617, new DateTime(2020, 6, 6, 20, 13, 19, 383, DateTimeKind.Local).AddTicks(7916), "Aut consequuntur dolorum quasi et. Consequuntur aut eum et ratione numquam et. Fuga est minus." },
                    { 291, 4, 13, 926515, new DateTime(2021, 1, 1, 7, 5, 57, 67, DateTimeKind.Local).AddTicks(9826), "Fugiat sunt provident doloribus hic enim reprehenderit.\nAccusamus temporibus rerum laudantium.\nDolor voluptas et distinctio quis quia.\nSed ad veritatis.\nTempore voluptatem magnam dolorum reiciendis qui aut quis.\nSapiente non odio error." },
                    { 484, 75, 92, 867392, new DateTime(2020, 8, 20, 1, 47, 16, 739, DateTimeKind.Local).AddTicks(2343), "Pariatur unde suscipit nihil rem aut saepe est placeat." },
                    { 35, 9, 137, 621691, new DateTime(2020, 7, 19, 0, 52, 24, 69, DateTimeKind.Local).AddTicks(5705), "Et occaecati voluptatem dolor." },
                    { 465, 38, 126, 735827, new DateTime(2020, 10, 30, 6, 0, 20, 675, DateTimeKind.Local).AddTicks(3552), "Qui molestiae aperiam occaecati in est enim." },
                    { 121, 18, 143, 616262, new DateTime(2020, 11, 6, 12, 22, 24, 605, DateTimeKind.Local).AddTicks(9350), "Ipsam perspiciatis vel non molestiae dignissimos. Sint vero aliquid delectus. Et corrupti enim minima numquam harum sit sunt error magnam. Magni suscipit voluptatem tenetur harum officiis. Cumque tempora dolorum." },
                    { 591, 59, 26, 244831, new DateTime(2021, 1, 24, 1, 3, 25, 407, DateTimeKind.Local).AddTicks(930), "Fuga nihil assumenda. Harum ut soluta non eligendi. Reiciendis est ad. Et assumenda non quidem quos cupiditate aut voluptatem. Quis dolores sunt. Illo quae est." },
                    { 22, 71, 12, 176732, new DateTime(2020, 6, 28, 23, 7, 52, 576, DateTimeKind.Local).AddTicks(8049), "Minus quo exercitationem occaecati." },
                    { 74, 71, 8, 22631, new DateTime(2020, 11, 14, 11, 10, 25, 17, DateTimeKind.Local).AddTicks(5595), "esse" },
                    { 204, 71, 112, 35042, new DateTime(2020, 6, 23, 11, 46, 13, 224, DateTimeKind.Local).AddTicks(3213), "Perferendis repudiandae dicta est quis sunt sunt atque." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 315, 71, 107, 65716, new DateTime(2020, 5, 15, 11, 4, 3, 188, DateTimeKind.Local).AddTicks(1245), "Autem molestias enim molestias cum rem. Modi consectetur vitae nihil neque odit aut corrupti consequatur repudiandae. Ipsa temporibus ut sed quasi ab ipsam aut occaecati eveniet. Pariatur sit animi quod consequatur id nesciunt illo et. Dolore ipsa amet. Magni sed magnam." },
                    { 497, 71, 109, 373554, new DateTime(2020, 6, 9, 16, 56, 26, 204, DateTimeKind.Local).AddTicks(8350), "quaerat" },
                    { 136, 69, 71, 253152, new DateTime(2020, 9, 21, 20, 51, 54, 371, DateTimeKind.Local).AddTicks(8440), "Et ratione assumenda quibusdam incidunt tenetur perspiciatis odio asperiores." },
                    { 20, 69, 45, 234755, new DateTime(2020, 12, 3, 5, 29, 1, 218, DateTimeKind.Local).AddTicks(2341), "aut" },
                    { 52, 80, 42, 271310, new DateTime(2020, 4, 25, 21, 12, 28, 846, DateTimeKind.Local).AddTicks(9651), "sequi" },
                    { 141, 80, 36, 128172, new DateTime(2020, 9, 11, 11, 1, 7, 585, DateTimeKind.Local).AddTicks(3620), "Quo necessitatibus qui rerum cupiditate placeat sit nemo. Vero praesentium nihil rerum. Quibusdam ea eveniet quam ipsum ut. Tempora est distinctio architecto qui voluptate. Soluta placeat ea non id. Laborum amet quisquam aspernatur tenetur fuga iusto sed." },
                    { 213, 47, 97, 436235, new DateTime(2020, 6, 13, 20, 32, 57, 594, DateTimeKind.Local).AddTicks(7556), "Inventore sunt odio inventore ex ab.\nIncidunt praesentium quis vel animi ipsa omnis et reprehenderit odio." },
                    { 202, 80, 61, 953483, new DateTime(2021, 3, 16, 20, 21, 45, 117, DateTimeKind.Local).AddTicks(9775), "magnam" },
                    { 255, 80, 51, 348506, new DateTime(2020, 6, 26, 1, 25, 17, 823, DateTimeKind.Local).AddTicks(6044), "dolor" },
                    { 434, 80, 58, 900527, new DateTime(2021, 3, 9, 21, 45, 27, 734, DateTimeKind.Local).AddTicks(2669), "Animi dolores voluptas voluptas itaque eligendi. Perspiciatis quam iusto nobis. Neque incidunt accusantium est aut voluptatem. Officia maxime neque ut velit ullam quasi aut. Architecto qui fugiat sed sed laborum explicabo quia dolor." },
                    { 34, 80, 141, 408441, new DateTime(2021, 4, 6, 21, 29, 29, 48, DateTimeKind.Local).AddTicks(9255), "Fuga et omnis quibusdam quae quidem sed." },
                    { 443, 80, 103, 740041, new DateTime(2021, 1, 27, 14, 32, 14, 654, DateTimeKind.Local).AddTicks(6366), "Neque eum aspernatur." },
                    { 560, 59, 80, 637452, new DateTime(2020, 11, 9, 14, 26, 47, 156, DateTimeKind.Local).AddTicks(8543), "Repellendus vel similique doloremque eum incidunt omnis. Beatae autem consectetur ab voluptatibus ut quas soluta rerum. Corporis dolorum possimus consequuntur laudantium incidunt perferendis cumque et esse. Ea eum voluptatem quod. Quo qui doloribus ipsam." },
                    { 494, 59, 140, 573095, new DateTime(2021, 4, 9, 22, 59, 21, 17, DateTimeKind.Local).AddTicks(5877), "Et enim expedita quod dolorem similique. Tempore nisi ut excepturi. Praesentium eaque dignissimos at maxime. Aut id ratione beatae rerum enim officiis iure enim." },
                    { 263, 76, 100, 489115, new DateTime(2021, 2, 18, 13, 44, 35, 115, DateTimeKind.Local).AddTicks(6047), "Enim cupiditate dicta debitis harum aut harum." },
                    { 442, 76, 2, 12396, new DateTime(2020, 6, 27, 8, 39, 0, 685, DateTimeKind.Local).AddTicks(8074), "Cum saepe repudiandae adipisci ipsam ab.\nAut provident unde quis cum quo et veniam sit velit.\nNatus excepturi minima sint veritatis.\nVoluptatibus in dolore non debitis accusamus voluptas veritatis dolores.\nQuisquam necessitatibus culpa aperiam blanditiis dignissimos eos hic ipsum velit.\nRepellat excepturi molestiae cumque." },
                    { 515, 76, 124, 856356, new DateTime(2020, 6, 30, 11, 12, 27, 308, DateTimeKind.Local).AddTicks(6790), "Excepturi consequatur sit impedit aut rerum. Vitae tempora voluptatem modi explicabo aut. Minus repellat ratione distinctio est quam a et repellendus." },
                    { 24, 55, 64, 335480, new DateTime(2020, 8, 15, 9, 48, 31, 155, DateTimeKind.Local).AddTicks(9606), "Odio aut aut est vero quidem et perspiciatis." },
                    { 241, 47, 79, 765888, new DateTime(2020, 12, 1, 19, 35, 17, 613, DateTimeKind.Local).AddTicks(5158), "Vel autem qui laboriosam excepturi quam et dolore at. Doloremque velit inventore iure id totam quia placeat. Est laborum cumque quae voluptatum voluptatem autem explicabo aut." },
                    { 2, 59, 116, 782366, new DateTime(2020, 12, 31, 16, 16, 53, 93, DateTimeKind.Local).AddTicks(8065), "Magni voluptatem rerum eum." },
                    { 550, 59, 140, 115914, new DateTime(2020, 12, 5, 8, 24, 41, 457, DateTimeKind.Local).AddTicks(1405), "voluptatem" },
                    { 506, 69, 26, 397900, new DateTime(2020, 12, 18, 17, 43, 8, 715, DateTimeKind.Local).AddTicks(9398), "Nostrum laboriosam architecto facere quia repellendus quas." },
                    { 185, 59, 86, 682583, new DateTime(2021, 2, 3, 8, 19, 19, 205, DateTimeKind.Local).AddTicks(1134), "et" },
                    { 243, 59, 115, 154936, new DateTime(2021, 3, 13, 5, 16, 22, 935, DateTimeKind.Local).AddTicks(9650), "Ipsam est perspiciatis enim accusantium aspernatur accusantium molestias consectetur.\nAut voluptas nulla accusamus nulla.\nVoluptas molestiae atque unde et." },
                    { 314, 59, 33, 73505, new DateTime(2021, 2, 2, 0, 18, 3, 273, DateTimeKind.Local).AddTicks(5175), "Vero eveniet vero sequi minus ab minus possimus assumenda cum.\nMinima aut qui voluptates laudantium aspernatur.\nIusto ea sunt optio temporibus reiciendis libero commodi eos.\nPorro reiciendis voluptate ut non sapiente velit accusantium rerum." },
                    { 418, 69, 143, 889121, new DateTime(2020, 6, 11, 1, 16, 47, 707, DateTimeKind.Local).AddTicks(4932), "Pariatur consectetur et molestiae.\nQuod nesciunt laboriosam.\nCumque aliquid at esse sed quam rerum." },
                    { 480, 59, 75, 484888, new DateTime(2020, 5, 2, 7, 45, 19, 13, DateTimeKind.Local).AddTicks(2968), "qui" },
                    { 493, 59, 31, 113053, new DateTime(2020, 8, 10, 6, 24, 29, 729, DateTimeKind.Local).AddTicks(5084), "Ea non in est amet voluptatem occaecati fugiat ut neque.\nIllum non quod blanditiis voluptatem impedit vitae molestiae quia.\nNobis amet magni quia illum est atque iure.\nQuam aut impedit rem mollitia autem.\nOdio non eaque itaque." },
                    { 102, 59, 150, 609216, new DateTime(2020, 8, 29, 20, 2, 54, 860, DateTimeKind.Local).AddTicks(6164), "Quaerat rerum perferendis et impedit dolorum vitae dolor dolorem.\nDolore ratione fugit ut vitae nihil voluptate at sint.\nQuia est nihil cupiditate dolor quia cum ab.\nNesciunt earum neque." },
                    { 194, 76, 147, 115861, new DateTime(2021, 1, 1, 7, 49, 3, 947, DateTimeKind.Local).AddTicks(8854), "Quasi saepe temporibus ex maxime ipsam ut." },
                    { 56, 92, 72, 557660, new DateTime(2021, 2, 20, 11, 58, 44, 699, DateTimeKind.Local).AddTicks(7209), "Accusantium consequatur reprehenderit voluptatibus inventore ut voluptas commodi.\nVitae nostrum veritatis.\nDolor earum laboriosam eius.\nAut ut aspernatur dolorem commodi provident et soluta et.\nNihil nemo impedit perspiciatis quia quia assumenda.\nVoluptas est voluptates repellat incidunt architecto eaque impedit." },
                    { 324, 92, 4, 642058, new DateTime(2020, 8, 1, 20, 40, 12, 288, DateTimeKind.Local).AddTicks(814), "laboriosam" },
                    { 191, 33, 78, 765893, new DateTime(2020, 10, 1, 15, 23, 23, 894, DateTimeKind.Local).AddTicks(1102), "id" },
                    { 198, 64, 13, 77938, new DateTime(2020, 6, 29, 0, 23, 54, 352, DateTimeKind.Local).AddTicks(4447), "Cupiditate ullam voluptas quia aut fuga quam. Minus modi accusamus voluptas rerum pariatur quia ut non quae. Laborum ducimus aut repellat consequatur accusantium quae numquam vero. Et et repellendus voluptas reprehenderit ut exercitationem culpa voluptas placeat. Commodi consequatur voluptatem velit ea iure sequi omnis." },
                    { 215, 33, 24, 796747, new DateTime(2020, 12, 1, 18, 28, 2, 178, DateTimeKind.Local).AddTicks(3013), "Et nulla voluptatem labore placeat nihil quam." },
                    { 253, 33, 128, 164926, new DateTime(2020, 10, 23, 17, 15, 24, 521, DateTimeKind.Local).AddTicks(5312), "Alias vel vitae at eius repudiandae enim omnis dolores vero." },
                    { 265, 33, 127, 183955, new DateTime(2021, 3, 30, 15, 48, 1, 357, DateTimeKind.Local).AddTicks(3398), "Dolor consequuntur dignissimos qui nihil. Consequatur quia est temporibus dolor. Ut distinctio cumque saepe ut quia quidem. Et praesentium dolores commodi provident minima et placeat. Exercitationem et error." },
                    { 327, 33, 5, 412879, new DateTime(2021, 1, 6, 22, 17, 34, 637, DateTimeKind.Local).AddTicks(566), "Eveniet sed enim." },
                    { 155, 33, 103, 358562, new DateTime(2021, 2, 23, 2, 54, 56, 559, DateTimeKind.Local).AddTicks(4448), "Culpa doloribus voluptatum asperiores." },
                    { 376, 33, 46, 759059, new DateTime(2020, 10, 31, 2, 48, 2, 360, DateTimeKind.Local).AddTicks(9525), "Qui ea et.\nError ad recusandae rem aut nulla.\nSit occaecati dolor in eos voluptatum quos porro exercitationem qui.\nQuam laudantium eos nobis assumenda expedita dolor labore eius.\nUllam alias praesentium ut consectetur quibusdam earum ipsam." },
                    { 564, 33, 56, 620380, new DateTime(2021, 3, 18, 10, 13, 13, 98, DateTimeKind.Local).AddTicks(1041), "non" },
                    { 175, 77, 130, 690509, new DateTime(2020, 8, 13, 11, 56, 48, 641, DateTimeKind.Local).AddTicks(8863), "Soluta voluptate animi et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 147, 64, 2, 58285, new DateTime(2020, 12, 9, 14, 33, 33, 941, DateTimeKind.Local).AddTicks(1221), "At molestiae fugiat ut sit inventore molestiae eum aut repellendus. Ut asperiores quae voluptate omnis et. Recusandae qui reprehenderit qui ut. Esse mollitia quibusdam velit tempore. Modi aspernatur quo repudiandae qui eos aut cupiditate." },
                    { 428, 77, 134, 812410, new DateTime(2020, 6, 5, 17, 13, 44, 239, DateTimeKind.Local).AddTicks(2897), "Optio molestias ea nam odio.\nDucimus rem quos accusamus illum eligendi quos consequuntur animi.\nAut itaque voluptas tenetur eos reprehenderit hic voluptate soluta.\nAutem tenetur odio corrupti et corporis recusandae accusantium." },
                    { 526, 77, 57, 750176, new DateTime(2020, 5, 31, 11, 13, 50, 136, DateTimeKind.Local).AddTicks(2290), "Id qui velit hic." },
                    { 548, 77, 129, 129648, new DateTime(2020, 6, 23, 15, 39, 53, 504, DateTimeKind.Local).AddTicks(7745), "Expedita fugiat dolor voluptate tenetur laborum ratione esse." },
                    { 399, 33, 135, 543010, new DateTime(2020, 9, 10, 14, 19, 51, 234, DateTimeKind.Local).AddTicks(1181), "Occaecati impedit est esse sint nisi." },
                    { 312, 92, 121, 269707, new DateTime(2020, 5, 2, 5, 16, 46, 301, DateTimeKind.Local).AddTicks(507), "Et sit dolores saepe cumque." },
                    { 221, 64, 14, 344724, new DateTime(2020, 5, 6, 5, 14, 59, 165, DateTimeKind.Local).AddTicks(4957), "Sint vel qui.\nEligendi est est quas voluptas.\nQuisquam voluptate labore.\nConsequatur ut quas repellendus.\nVoluptatibus qui non ratione." },
                    { 90, 33, 105, 786284, new DateTime(2020, 10, 17, 0, 48, 51, 920, DateTimeKind.Local).AddTicks(5499), "Facilis culpa accusantium odio a." },
                    { 369, 92, 16, 831636, new DateTime(2020, 6, 17, 23, 58, 3, 908, DateTimeKind.Local).AddTicks(5395), "Alias ut sapiente aliquam quis." },
                    { 397, 92, 45, 170905, new DateTime(2021, 2, 3, 3, 55, 29, 620, DateTimeKind.Local).AddTicks(85), "Necessitatibus excepturi qui eaque. Consequatur facilis praesentium eveniet quibusdam soluta modi delectus. Qui atque nemo beatae unde rerum dolorum error. Architecto aut necessitatibus vero repellendus ut eius." },
                    { 504, 92, 61, 646807, new DateTime(2020, 5, 23, 13, 20, 43, 486, DateTimeKind.Local).AddTicks(8123), "Ipsam sequi voluptatem eos rerum incidunt magnam et repudiandae dolorum.\nEnim iure architecto quod sint non recusandae et nihil temporibus.\nUt reprehenderit tempore nostrum laudantium sunt velit nobis dolorem veritatis." },
                    { 512, 92, 13, 455178, new DateTime(2021, 1, 14, 1, 22, 2, 183, DateTimeKind.Local).AddTicks(2614), "Est corrupti hic et.\nSimilique et perferendis aliquam ratione recusandae cum.\nEsse sed et expedita doloremque aut.\nIure optio consequatur sunt et vel ipsam voluptas doloribus veritatis.\nEarum sit ullam in consequatur sunt.\nFugit et recusandae." },
                    { 109, 7, 103, 546231, new DateTime(2020, 4, 20, 18, 43, 39, 301, DateTimeKind.Local).AddTicks(2693), "voluptatum" },
                    { 114, 7, 123, 586498, new DateTime(2020, 6, 25, 14, 15, 37, 867, DateTimeKind.Local).AddTicks(3558), "voluptatibus" },
                    { 151, 33, 38, 9362, new DateTime(2020, 6, 2, 7, 15, 13, 198, DateTimeKind.Local).AddTicks(7202), "molestias" },
                    { 278, 7, 96, 381654, new DateTime(2020, 11, 17, 17, 32, 25, 18, DateTimeKind.Local).AddTicks(3004), "pariatur" },
                    { 353, 64, 112, 252936, new DateTime(2020, 6, 3, 21, 57, 49, 602, DateTimeKind.Local).AddTicks(4393), "Dicta nostrum laboriosam dolorem voluptas." },
                    { 543, 7, 86, 455000, new DateTime(2020, 8, 12, 12, 41, 49, 319, DateTimeKind.Local).AddTicks(4591), "Repudiandae non voluptatem non rerum nesciunt quidem." },
                    { 296, 64, 131, 494218, new DateTime(2020, 10, 20, 17, 58, 38, 857, DateTimeKind.Local).AddTicks(7838), "eligendi" },
                    { 7, 33, 31, 166692, new DateTime(2020, 10, 7, 9, 45, 3, 191, DateTimeKind.Local).AddTicks(337), "exercitationem" },
                    { 16, 33, 119, 106271, new DateTime(2020, 10, 15, 11, 45, 32, 564, DateTimeKind.Local).AddTicks(8772), "Ratione ad perspiciatis similique modi et ad officia animi." },
                    { 48, 33, 9, 317638, new DateTime(2021, 3, 21, 16, 57, 8, 877, DateTimeKind.Local).AddTicks(9994), "Assumenda voluptas molestiae ut dolor dolores eos placeat suscipit.\nAt in perferendis et occaecati nisi." },
                    { 437, 7, 124, 48752, new DateTime(2021, 3, 27, 6, 45, 48, 438, DateTimeKind.Local).AddTicks(6730), "placeat" },
                    { 115, 18, 69, 953083, new DateTime(2020, 4, 20, 0, 14, 47, 996, DateTimeKind.Local).AddTicks(8249), "voluptate" },
                    { 80, 76, 58, 32005, new DateTime(2020, 8, 20, 1, 12, 35, 416, DateTimeKind.Local).AddTicks(7163), "Et quidem aperiam sit dolorem.\nPorro quisquam vel reprehenderit." },
                    { 37, 76, 70, 175206, new DateTime(2020, 5, 9, 13, 11, 4, 517, DateTimeKind.Local).AddTicks(2953), "Possimus repellendus est id modi exercitationem inventore." },
                    { 217, 1, 133, 386062, new DateTime(2020, 7, 13, 18, 51, 26, 889, DateTimeKind.Local).AddTicks(8021), "Voluptas consequuntur sit repellendus molestias nemo in soluta aut." },
                    { 232, 1, 135, 956067, new DateTime(2020, 8, 9, 22, 48, 55, 210, DateTimeKind.Local).AddTicks(73), "voluptatem" },
                    { 281, 1, 116, 79898, new DateTime(2021, 2, 26, 11, 47, 6, 69, DateTimeKind.Local).AddTicks(985), "Tempora aut et blanditiis optio autem." },
                    { 45, 38, 94, 434871, new DateTime(2021, 4, 7, 23, 21, 8, 743, DateTimeKind.Local).AddTicks(9816), "Magnam qui facere." },
                    { 340, 1, 125, 389574, new DateTime(2020, 6, 18, 12, 27, 11, 838, DateTimeKind.Local).AddTicks(7602), "Qui at nesciunt alias excepturi dolor voluptate." },
                    { 542, 1, 130, 115333, new DateTime(2020, 6, 23, 8, 31, 43, 77, DateTimeKind.Local).AddTicks(5541), "eos" },
                    { 50, 38, 58, 809521, new DateTime(2020, 6, 15, 15, 25, 50, 554, DateTimeKind.Local).AddTicks(6524), "Inventore iusto sint aut." },
                    { 39, 38, 101, 409052, new DateTime(2021, 1, 16, 4, 38, 17, 233, DateTimeKind.Local).AddTicks(4109), "maiores" },
                    { 261, 35, 116, 267521, new DateTime(2020, 6, 11, 18, 14, 55, 668, DateTimeKind.Local).AddTicks(686), "Voluptate rerum mollitia eos similique.\nLaborum aut omnis architecto corrupti voluptatem.\nQuam voluptas sed reprehenderit aut quas.\nEt est consequatur recusandae aut quia sint.\nAtque totam adipisci vero quis." },
                    { 6, 16, 43, 152356, new DateTime(2020, 8, 29, 13, 54, 15, 624, DateTimeKind.Local).AddTicks(6364), "Ea sunt sit ipsam iure quibusdam natus ullam ab." },
                    { 455, 35, 5, 379533, new DateTime(2021, 1, 29, 1, 8, 12, 215, DateTimeKind.Local).AddTicks(5794), "Qui animi incidunt quia ad aut amet." },
                    { 346, 29, 42, 981624, new DateTime(2020, 10, 29, 22, 12, 23, 93, DateTimeKind.Local).AddTicks(9378), "Ratione odio id sit minus fuga et vero. Quaerat est dolorem aut id maxime consequatur. Aut aut rerum. Nostrum eligendi sunt ex voluptatem. Iusto qui cupiditate modi aliquid cupiditate." },
                    { 364, 29, 43, 73051, new DateTime(2020, 5, 4, 20, 16, 39, 111, DateTimeKind.Local).AddTicks(3531), "Qui non sapiente eaque unde dolorem beatae.\nEos similique enim fugit et sint et molestias incidunt.\nEos est ad ipsa ut reiciendis eum ut pariatur sequi.\nVoluptatem omnis sint vel.\nVoluptatem vitae officia ipsam." },
                    { 594, 29, 125, 770654, new DateTime(2021, 1, 19, 7, 29, 55, 288, DateTimeKind.Local).AddTicks(8573), "Labore qui corrupti ut beatae laboriosam libero porro corporis est. Necessitatibus dolorem cum pariatur suscipit. Temporibus modi quibusdam temporibus facere. Officiis rerum sunt quo iusto nesciunt neque. Aut minima assumenda qui a fugit ex magni ullam." },
                    { 98, 35, 91, 368718, new DateTime(2020, 4, 21, 2, 16, 54, 172, DateTimeKind.Local).AddTicks(42), "tempore" },
                    { 569, 55, 10, 913662, new DateTime(2020, 7, 6, 12, 45, 49, 511, DateTimeKind.Local).AddTicks(2321), "Dolorem voluptas est." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 176, 1, 36, 513054, new DateTime(2021, 1, 17, 21, 42, 44, 668, DateTimeKind.Local).AddTicks(9573), "Est qui animi architecto veritatis quia velit non quam eius. Debitis nam amet ut molestiae et. Laudantium minus qui quae quibusdam quas corporis voluptates. Similique maiores aliquam." },
                    { 574, 31, 97, 250965, new DateTime(2020, 7, 30, 0, 7, 16, 641, DateTimeKind.Local).AddTicks(8458), "Adipisci voluptatem sit.\nSit maiores eum.\nCulpa consequatur laborum incidunt.\nEt voluptas voluptatem.\nIllo quia dolores non corporis sint praesentium esse.\nAb aut illum in." },
                    { 295, 18, 126, 809462, new DateTime(2020, 10, 20, 21, 13, 32, 950, DateTimeKind.Local).AddTicks(8589), "Neque amet maxime illo. Asperiores vel fugit deleniti laborum a distinctio ipsam. Nesciunt ea incidunt consequuntur expedita consequatur. In vel omnis et enim illum maxime magni voluptas. Occaecati tenetur corrupti magnam deserunt. Architecto ad voluptatem ut." },
                    { 343, 18, 62, 438175, new DateTime(2021, 3, 2, 2, 53, 49, 109, DateTimeKind.Local).AddTicks(9901), "Quo aperiam occaecati. Est ratione provident minus nihil magni beatae reiciendis. Explicabo autem esse ea enim." },
                    { 413, 18, 108, 441460, new DateTime(2021, 2, 11, 8, 58, 5, 511, DateTimeKind.Local).AddTicks(4208), "similique" },
                    { 482, 18, 114, 607881, new DateTime(2021, 3, 17, 14, 22, 22, 549, DateTimeKind.Local).AddTicks(2828), "Ipsam nesciunt consequuntur at nihil." },
                    { 563, 18, 105, 943293, new DateTime(2021, 3, 20, 9, 18, 5, 153, DateTimeKind.Local).AddTicks(906), "Inventore dolore earum dolores dolores consequatur est in." },
                    { 40, 6, 119, 319507, new DateTime(2020, 12, 28, 20, 24, 43, 788, DateTimeKind.Local).AddTicks(1972), "Culpa doloribus molestias repellat perferendis.\nEos et iure rerum at aut quos voluptas vel ex.\nEum vitae molestiae amet neque quos.\nIste rerum facere reiciendis.\nSoluta voluptatem quas veritatis consectetur maxime corrupti facere mollitia minus." },
                    { 69, 1, 62, 7812, new DateTime(2021, 4, 2, 0, 2, 23, 771, DateTimeKind.Local).AddTicks(9034), "Blanditiis dolorem ut veniam perferendis sit.\nEius aut ad est sed.\nNesciunt minus non voluptatem nostrum placeat earum fugit.\nFacere quia quaerat exercitationem ut." },
                    { 97, 6, 110, 488080, new DateTime(2020, 8, 15, 16, 12, 5, 51, DateTimeKind.Local).AddTicks(113), "Sunt distinctio sit labore aperiam sequi ut nihil." },
                    { 150, 6, 77, 598548, new DateTime(2020, 12, 15, 0, 0, 23, 720, DateTimeKind.Local).AddTicks(9274), "Et facilis dicta." },
                    { 374, 6, 29, 8384, new DateTime(2020, 12, 26, 21, 44, 20, 949, DateTimeKind.Local).AddTicks(7880), "Sunt rerum velit.\nVel cumque ullam quos cum." },
                    { 389, 6, 35, 953561, new DateTime(2020, 6, 30, 7, 41, 32, 410, DateTimeKind.Local).AddTicks(1607), "Quas minus magni est consequatur sit.\nNumquam et saepe deserunt rerum dignissimos at ratione.\nMolestias et et harum ex hic." },
                    { 475, 6, 118, 79373, new DateTime(2021, 3, 5, 12, 24, 52, 295, DateTimeKind.Local).AddTicks(4410), "pariatur" },
                    { 509, 6, 60, 372135, new DateTime(2021, 2, 25, 6, 27, 0, 980, DateTimeKind.Local).AddTicks(7645), "Commodi et corporis eum." },
                    { 51, 31, 80, 273726, new DateTime(2020, 7, 10, 2, 55, 48, 905, DateTimeKind.Local).AddTicks(1876), "Aut quia harum aliquid expedita et animi et aliquam quia.\nDelectus commodi aliquam et perspiciatis.\nHic et fuga totam amet.\nAut velit quos aut." },
                    { 216, 38, 97, 895645, new DateTime(2021, 3, 4, 0, 49, 6, 996, DateTimeKind.Local).AddTicks(8522), "Aliquid sed quia est eum est. Et praesentium quis repudiandae non eos. Amet aut qui at exercitationem. Officia deserunt illum velit quisquam rerum eos modi id enim. Ut autem aut illum voluptatibus mollitia quia ea eligendi." },
                    { 70, 76, 136, 11086, new DateTime(2021, 2, 21, 9, 36, 43, 397, DateTimeKind.Local).AddTicks(9310), "dignissimos" },
                    { 87, 70, 26, 92006, new DateTime(2020, 6, 25, 12, 53, 26, 142, DateTimeKind.Local).AddTicks(494), "Tenetur voluptatem sed incidunt ratione veritatis et non vitae.\nAutem veniam rerum enim harum quia.\nAliquam debitis excepturi omnis voluptas at fuga." },
                    { 231, 70, 104, 700443, new DateTime(2020, 9, 1, 17, 37, 30, 669, DateTimeKind.Local).AddTicks(1731), "Architecto nisi eum." },
                    { 189, 8, 61, 825211, new DateTime(2020, 9, 15, 22, 46, 48, 34, DateTimeKind.Local).AddTicks(5142), "Molestiae repellendus non quis facilis velit et omnis consequatur.\nAb voluptatem a et praesentium necessitatibus optio.\nVero quo consequatur laudantium expedita reiciendis enim.\nVoluptatum non corporis nihil ipsa inventore soluta rerum.\nBlanditiis rem excepturi non vel ipsum nostrum sit.\nSint sapiente non dolores odit in magni." },
                    { 290, 8, 112, 85686, new DateTime(2021, 2, 10, 19, 2, 34, 838, DateTimeKind.Local).AddTicks(5523), "Ea quibusdam et.\nEt consequatur consequatur qui ipsa provident aspernatur ad.\nCorporis voluptatum iste facere voluptatibus repellendus similique et voluptatem." },
                    { 323, 8, 123, 938631, new DateTime(2020, 8, 4, 0, 16, 35, 957, DateTimeKind.Local).AddTicks(3875), "Quis qui perferendis." },
                    { 429, 8, 63, 514469, new DateTime(2020, 10, 3, 2, 26, 28, 702, DateTimeKind.Local).AddTicks(6442), "Quod ex et libero inventore qui." },
                    { 544, 8, 17, 337794, new DateTime(2020, 10, 9, 6, 40, 7, 249, DateTimeKind.Local).AddTicks(6482), "Ut voluptatum sequi veniam tempora blanditiis corporis molestiae voluptas." },
                    { 61, 55, 42, 139108, new DateTime(2020, 12, 5, 15, 29, 10, 148, DateTimeKind.Local).AddTicks(404), "Autem aut rerum. Dolore sint similique nam culpa molestiae autem. Et et et rem quos illum ut dignissimos maiores doloribus. Quia sint libero sint ipsam. Labore autem iusto eum ut aspernatur vel. Voluptate dolor quibusdam et eos assumenda sunt minus." },
                    { 134, 8, 70, 92764, new DateTime(2021, 3, 20, 2, 23, 51, 610, DateTimeKind.Local).AddTicks(2413), "Aperiam culpa perferendis quia. Libero quasi alias quae dolor corporis quia quo. Ullam aut molestiae labore sed. Praesentium voluptates voluptatum facilis et in maxime ut et quia. Aspernatur nam voluptatum fuga unde omnis saepe. Beatae hic maiores quod repudiandae quisquam atque vitae." },
                    { 590, 8, 51, 768710, new DateTime(2021, 3, 13, 4, 3, 44, 380, DateTimeKind.Local).AddTicks(5291), "Praesentium maiores impedit officiis eum modi et." },
                    { 181, 63, 49, 506612, new DateTime(2021, 4, 8, 8, 18, 2, 830, DateTimeKind.Local).AddTicks(3978), "Ea omnis aut hic in.\nDicta sed aut impedit distinctio.\nQuia unde ex nostrum.\nFacilis nisi molestiae corrupti aut corporis dolores dicta nihil provident.\nPerferendis perferendis excepturi reiciendis fuga unde aut." },
                    { 195, 63, 6, 955323, new DateTime(2021, 3, 25, 5, 29, 49, 879, DateTimeKind.Local).AddTicks(5051), "Soluta eveniet est." },
                    { 240, 63, 57, 990927, new DateTime(2020, 6, 13, 13, 24, 4, 640, DateTimeKind.Local).AddTicks(2178), "quidem" },
                    { 252, 63, 118, 965361, new DateTime(2020, 11, 5, 8, 46, 7, 117, DateTimeKind.Local).AddTicks(3010), "Ipsa dignissimos labore voluptatem omnis nihil omnis dolor repellat. Labore sit illo error. Dolore molestiae praesentium ratione et saepe qui quia. Id error cupiditate placeat iusto consectetur consequatur sint minus." },
                    { 302, 63, 39, 953743, new DateTime(2020, 7, 12, 13, 39, 58, 300, DateTimeKind.Local).AddTicks(8745), "Molestiae qui repudiandae et autem ratione eaque magnam.\nError ea quod et enim.\nEt eveniet consequatur eos atque.\nHic minus quas a natus sit voluptatem nihil tenetur.\nRepellat quo voluptas excepturi modi est a.\nNatus a tempora explicabo laborum nihil." },
                    { 28, 55, 98, 634246, new DateTime(2020, 11, 7, 1, 35, 40, 932, DateTimeKind.Local).AddTicks(902), "error" },
                    { 297, 47, 27, 189048, new DateTime(2020, 4, 26, 21, 49, 45, 755, DateTimeKind.Local).AddTicks(5947), "Sint consequatur qui autem." },
                    { 391, 47, 72, 314193, new DateTime(2020, 10, 28, 0, 25, 50, 50, DateTimeKind.Local).AddTicks(2879), "dolorum" },
                    { 73, 55, 53, 791875, new DateTime(2020, 10, 5, 23, 17, 49, 744, DateTimeKind.Local).AddTicks(2299), "distinctio" },
                    { 487, 94, 20, 504266, new DateTime(2020, 6, 6, 8, 25, 58, 465, DateTimeKind.Local).AddTicks(4999), "Hic consectetur vel ut. Est autem fugit facilis. Dolorem praesentium sit ullam recusandae velit." },
                    { 474, 70, 130, 26249, new DateTime(2020, 10, 2, 10, 21, 28, 357, DateTimeKind.Local).AddTicks(6380), "Et eos et soluta voluptatem. Dolor sed exercitationem repudiandae repellat alias esse veritatis architecto commodi. Alias voluptates pariatur. Perferendis ea aut ut sequi. Quia quis aut ut et aliquid quae ea et fugiat. In perferendis ut et dolor dolores mollitia accusamus expedita." },
                    { 508, 70, 127, 503875, new DateTime(2020, 4, 21, 3, 43, 22, 522, DateTimeKind.Local).AddTicks(8407), "Ducimus aut blanditiis et aspernatur sit eius impedit voluptas velit. Voluptas nam sed deleniti. Deleniti nemo voluptatem et in explicabo fugit. Nesciunt ducimus molestiae suscipit id." },
                    { 483, 55, 20, 633688, new DateTime(2020, 11, 30, 18, 19, 19, 982, DateTimeKind.Local).AddTicks(1104), "Qui et minima mollitia non tempore.\nNobis voluptatem repellat odit." },
                    { 431, 55, 38, 817246, new DateTime(2020, 12, 13, 13, 27, 3, 952, DateTimeKind.Local).AddTicks(7337), "Consequatur quis sint. Laudantium ut temporibus maiores dicta deleniti rerum numquam dolor. Veniam aliquid veniam explicabo minima aut. Consectetur ullam aut." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 152, 86, 23, 441460, new DateTime(2020, 8, 2, 11, 41, 43, 910, DateTimeKind.Local).AddTicks(9574), "earum" },
                    { 158, 86, 87, 21215, new DateTime(2021, 2, 27, 20, 49, 58, 833, DateTimeKind.Local).AddTicks(9488), "Quo nam quia rerum qui accusantium aut." },
                    { 589, 94, 55, 329491, new DateTime(2020, 8, 14, 18, 59, 25, 900, DateTimeKind.Local).AddTicks(264), "porro" },
                    { 246, 86, 1, 634270, new DateTime(2020, 10, 2, 22, 21, 31, 692, DateTimeKind.Local).AddTicks(5535), "Sit officia sint molestiae voluptatibus.\nEum non pariatur atque quaerat nulla velit.\nNihil optio necessitatibus aperiam quas inventore minima.\nEst eos reprehenderit officia enim eligendi molestiae cumque rerum voluptate.\nIpsa velit inventore at dolores laudantium excepturi deserunt." },
                    { 539, 86, 29, 486349, new DateTime(2020, 9, 17, 12, 15, 26, 159, DateTimeKind.Local).AddTicks(3296), "Sit eligendi id quas architecto qui ad earum ut. Et non vitae dolorum molestias at eveniet rerum suscipit. Nobis quis facere repellendus sint mollitia velit assumenda porro minus. Corrupti harum vel aliquid at placeat dolores eligendi. Nam eos atque." },
                    { 598, 86, 146, 157461, new DateTime(2020, 7, 31, 7, 46, 46, 220, DateTimeKind.Local).AddTicks(6919), "Voluptatem aliquid consequatur at in architecto id id nisi." },
                    { 108, 55, 56, 581773, new DateTime(2021, 3, 30, 9, 3, 47, 649, DateTimeKind.Local).AddTicks(7619), "Voluptas asperiores pariatur cupiditate ut.\nEt nisi ea qui voluptas et similique ex labore.\nRepellat impedit veniam laboriosam aut fugiat sed.\nError nisi doloribus ea quibusdam distinctio doloribus dolore sequi.\nVoluptas ex dolorum." },
                    { 316, 94, 77, 42763, new DateTime(2021, 3, 17, 6, 1, 27, 780, DateTimeKind.Local).AddTicks(2119), "Dolorem sequi aliquam odio quaerat consectetur autem hic eaque iusto.\nEveniet dolorem quam id minima.\nIpsam veniam officiis autem placeat." },
                    { 351, 94, 40, 354609, new DateTime(2021, 3, 19, 21, 47, 59, 994, DateTimeKind.Local).AddTicks(7330), "Blanditiis aperiam accusantium repudiandae occaecati eum ea dolorem consequatur. Voluptas vero culpa nihil quia sit ad. Sint voluptatem id illum exercitationem aut." },
                    { 417, 94, 78, 185419, new DateTime(2020, 8, 19, 5, 4, 17, 208, DateTimeKind.Local).AddTicks(4586), "ipsa" },
                    { 534, 86, 150, 69924, new DateTime(2021, 2, 18, 15, 45, 51, 220, DateTimeKind.Local).AddTicks(7445), "ea" },
                    { 570, 62, 3, 555706, new DateTime(2020, 7, 23, 22, 54, 4, 903, DateTimeKind.Local).AddTicks(3655), "quo" }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 10, 56, 126 },
                    { 26, 28, 84 },
                    { 17, 39, 106 },
                    { 96, 38, 150 },
                    { 42, 55, 46 },
                    { 95, 10, 272 },
                    { 94, 57, 102 },
                    { 84, 69, 248 },
                    { 59, 64, 285 },
                    { 51, 13, 15 },
                    { 36, 77, 172 },
                    { 80, 97, 150 },
                    { 89, 47, 172 },
                    { 29, 1, 125 },
                    { 5, 91, 59 },
                    { 22, 29, 150 },
                    { 63, 50, 128 },
                    { 79, 42, 87 },
                    { 2, 70, 150 },
                    { 44, 86, 186 },
                    { 49, 94, 52 },
                    { 11, 61, 202 },
                    { 8, 8, 134 },
                    { 62, 63, 101 },
                    { 27, 19, 200 },
                    { 64, 76, 80 },
                    { 12, 58, 68 },
                    { 32, 14, 23 },
                    { 39, 43, 2 },
                    { 50, 71, 117 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 20, 40, 285 },
                    { 65, 15, 156 },
                    { 86, 7, 146 },
                    { 71, 51, 80 },
                    { 25, 26, 238 },
                    { 35, 27, 230 },
                    { 13, 98, 285 },
                    { 97, 11, 150 },
                    { 52, 68, 126 },
                    { 6, 85, 121 },
                    { 23, 23, 46 },
                    { 9, 9, 36 },
                    { 48, 44, 99 },
                    { 34, 5, 17 },
                    { 69, 88, 21 },
                    { 19, 74, 123 },
                    { 1, 41, 156 },
                    { 60, 54, 232 },
                    { 24, 12, 284 },
                    { 90, 73, 54 },
                    { 14, 53, 237 },
                    { 82, 45, 49 },
                    { 40, 2, 238 },
                    { 7, 46, 258 },
                    { 67, 30, 158 },
                    { 16, 36, 15 },
                    { 47, 87, 126 },
                    { 28, 96, 200 },
                    { 4, 99, 32 },
                    { 72, 90, 291 },
                    { 38, 93, 136 },
                    { 83, 84, 9 },
                    { 77, 66, 272 },
                    { 99, 81, 200 },
                    { 3, 89, 15 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 11, new DateTime(2020, 5, 24, 12, 0, 19, 145, DateTimeKind.Local).AddTicks(5923), 99, new DateTime(2021, 6, 20, 22, 14, 7, 398, DateTimeKind.Local).AddTicks(7231), new DateTime(2020, 11, 7, 23, 4, 18, 742, DateTimeKind.Local).AddTicks(4769), 4, 59, "Ducimus aliquam temporibus unde." },
                    { 55, new DateTime(2021, 3, 27, 13, 27, 15, 539, DateTimeKind.Local).AddTicks(2978), 123, new DateTime(2021, 6, 16, 8, 26, 41, 830, DateTimeKind.Local).AddTicks(3518), new DateTime(2020, 4, 20, 22, 2, 2, 460, DateTimeKind.Local).AddTicks(5784), 5, 77, "Dolorum est ad autem voluptas omnis vero architecto. Est non quasi et est cumque quae temporibus minus. Minima esse dolores. Enim vitae occaecati cum reprehenderit eos a corporis sint dolor." },
                    { 99, new DateTime(2021, 1, 21, 15, 42, 29, 153, DateTimeKind.Local).AddTicks(3846), 61, new DateTime(2022, 3, 28, 19, 45, 25, 937, DateTimeKind.Local).AddTicks(6593), new DateTime(2020, 10, 1, 21, 44, 39, 850, DateTimeKind.Local).AddTicks(6168), 5, 77, "est" },
                    { 106, new DateTime(2021, 1, 17, 10, 4, 9, 248, DateTimeKind.Local).AddTicks(1684), 44, new DateTime(2022, 2, 24, 12, 23, 1, 585, DateTimeKind.Local).AddTicks(9648), new DateTime(2020, 7, 1, 20, 57, 2, 900, DateTimeKind.Local).AddTicks(7272), 2, 77, "Velit omnis id hic aut iusto officia molestiae qui.\nRepudiandae et ad at facilis tempore.\nQui vel nobis tenetur et sed vel dicta vel.\nSuscipit inventore itaque nihil eos inventore maxime modi.\nEius aperiam harum est autem magni consequatur itaque tenetur eveniet.\nQui nobis accusamus et velit quia dolores nulla tenetur." },
                    { 118, new DateTime(2020, 6, 13, 1, 50, 1, 707, DateTimeKind.Local).AddTicks(6028), 150, new DateTime(2022, 4, 14, 23, 13, 29, 409, DateTimeKind.Local).AddTicks(4433), new DateTime(2020, 11, 1, 5, 30, 35, 847, DateTimeKind.Local).AddTicks(1750), 2, 77, "rerum" },
                    { 39, new DateTime(2020, 10, 3, 7, 32, 28, 116, DateTimeKind.Local).AddTicks(7853), 80, new DateTime(2022, 4, 2, 1, 16, 32, 43, DateTimeKind.Local).AddTicks(3103), new DateTime(2020, 10, 29, 12, 8, 51, 937, DateTimeKind.Local).AddTicks(436), 4, 72, "Iusto eos aliquam maxime nulla. Ipsum incidunt dolorem in blanditiis sequi reprehenderit. Similique ea ratione rem consectetur expedita mollitia vel et est. Corrupti distinctio illo doloremque tempora facere quia sed similique. Voluptates est molestiae deserunt rem quod excepturi. Fugit perferendis maxime." },
                    { 42, new DateTime(2020, 5, 27, 19, 33, 58, 20, DateTimeKind.Local).AddTicks(2519), 15, new DateTime(2022, 3, 25, 15, 52, 3, 749, DateTimeKind.Local).AddTicks(9221), new DateTime(2020, 5, 27, 3, 37, 35, 30, DateTimeKind.Local).AddTicks(1291), 1, 72, "Facilis dolores nostrum omnis at. Accusamus non dolore aut repellendus id. Ut iste accusamus nesciunt consequatur labore voluptatem hic dolorem ut. Id enim perspiciatis ipsa sint cumque laudantium. Autem ad nesciunt eum sint." },
                    { 128, new DateTime(2020, 7, 18, 15, 23, 36, 820, DateTimeKind.Local).AddTicks(1508), 47, new DateTime(2021, 7, 12, 4, 27, 34, 512, DateTimeKind.Local).AddTicks(965), new DateTime(2021, 2, 1, 13, 8, 23, 194, DateTimeKind.Local).AddTicks(8365), 4, 72, "omnis" },
                    { 175, new DateTime(2020, 8, 30, 17, 12, 2, 506, DateTimeKind.Local).AddTicks(7526), 7, new DateTime(2021, 11, 23, 4, 10, 48, 588, DateTimeKind.Local).AddTicks(7840), new DateTime(2021, 2, 11, 2, 32, 52, 740, DateTimeKind.Local).AddTicks(5451), 4, 72, "et" },
                    { 73, new DateTime(2021, 3, 1, 22, 56, 34, 374, DateTimeKind.Local).AddTicks(4839), 137, new DateTime(2022, 1, 17, 12, 52, 24, 764, DateTimeKind.Local).AddTicks(8570), new DateTime(2020, 10, 9, 2, 1, 9, 37, DateTimeKind.Local).AddTicks(3364), 3, 80, "Qui omnis veniam deleniti dicta quis corporis.\nRepudiandae repellat sunt deserunt dolores vel qui ut ratione aut.\nAssumenda quasi dolorem accusamus qui aut nesciunt non voluptatem rem.\nConsequatur nam dolorem dolores provident.\nFuga voluptates provident eos labore aspernatur vel deleniti.\nIn veritatis est quaerat fuga vel libero cumque." },
                    { 103, new DateTime(2020, 4, 17, 18, 26, 45, 519, DateTimeKind.Local).AddTicks(5687), 70, new DateTime(2021, 12, 11, 23, 7, 54, 79, DateTimeKind.Local).AddTicks(2231), new DateTime(2020, 8, 31, 23, 28, 7, 109, DateTimeKind.Local).AddTicks(126), 5, 80, "nihil" },
                    { 192, new DateTime(2020, 11, 20, 15, 36, 1, 456, DateTimeKind.Local).AddTicks(9878), 116, new DateTime(2022, 3, 11, 1, 33, 36, 707, DateTimeKind.Local).AddTicks(9128), new DateTime(2020, 5, 30, 9, 39, 38, 334, DateTimeKind.Local).AddTicks(7025), 3, 80, "Sit dolores labore odio nam quo rerum dolorem." },
                    { 9, new DateTime(2020, 4, 29, 14, 16, 22, 369, DateTimeKind.Local).AddTicks(6167), 46, new DateTime(2021, 9, 4, 8, 25, 6, 459, DateTimeKind.Local).AddTicks(3469), new DateTime(2021, 1, 27, 10, 10, 38, 613, DateTimeKind.Local).AddTicks(8966), 2, 4, "Aliquam est eveniet laboriosam et ipsa." },
                    { 49, new DateTime(2020, 11, 3, 20, 47, 43, 600, DateTimeKind.Local).AddTicks(2212), 138, new DateTime(2021, 12, 15, 16, 38, 28, 956, DateTimeKind.Local).AddTicks(1689), new DateTime(2020, 10, 12, 12, 56, 8, 382, DateTimeKind.Local).AddTicks(4932), 5, 4, "Eius voluptatum animi eos sapiente libero doloribus quis. Odit iste voluptatem. Repellat nesciunt suscipit dicta. Explicabo doloremque nihil debitis assumenda officia et impedit. Quia consequuntur voluptatem repellendus." },
                    { 60, new DateTime(2020, 11, 15, 16, 10, 1, 847, DateTimeKind.Local).AddTicks(1430), 5, new DateTime(2021, 5, 3, 1, 59, 57, 957, DateTimeKind.Local).AddTicks(861), new DateTime(2020, 6, 4, 4, 2, 17, 348, DateTimeKind.Local).AddTicks(2172), 3, 4, "Neque sed culpa sed.\nQuia qui voluptas.\nEum aut officia aut nisi voluptatem est fugit.\nEarum sit voluptatum unde et quia quidem hic aliquam.\nFugit consequatur neque dolore voluptatem inventore nisi voluptas qui." },
                    { 155, new DateTime(2020, 6, 19, 20, 26, 30, 467, DateTimeKind.Local).AddTicks(9966), 25, new DateTime(2022, 4, 10, 3, 27, 49, 517, DateTimeKind.Local).AddTicks(4610), new DateTime(2021, 2, 24, 5, 36, 0, 510, DateTimeKind.Local).AddTicks(3464), 2, 4, "quia" },
                    { 188, new DateTime(2020, 6, 29, 2, 55, 48, 600, DateTimeKind.Local).AddTicks(9615), 142, new DateTime(2022, 4, 12, 8, 19, 20, 72, DateTimeKind.Local).AddTicks(4730), new DateTime(2020, 11, 20, 20, 39, 34, 924, DateTimeKind.Local).AddTicks(1596), 2, 4, "Possimus aut corporis illum sapiente ducimus accusantium. Quasi aut aut quae inventore ea sunt aut. Reiciendis porro ut unde rem pariatur itaque consequatur voluptatum voluptatem." },
                    { 21, new DateTime(2020, 12, 11, 7, 8, 54, 117, DateTimeKind.Local).AddTicks(2548), 21, new DateTime(2021, 6, 5, 23, 26, 21, 346, DateTimeKind.Local).AddTicks(6783), new DateTime(2020, 5, 23, 7, 52, 50, 251, DateTimeKind.Local).AddTicks(7845), 5, 47, "Praesentium nobis voluptatibus laudantium amet. Nihil voluptas porro tenetur necessitatibus culpa. Voluptas voluptas deserunt corrupti perspiciatis cum. Magni sunt quos omnis reprehenderit quae tempora aliquid eos. Cum voluptas ea labore. Aliquam unde ut natus excepturi blanditiis." },
                    { 43, new DateTime(2020, 9, 29, 9, 31, 40, 159, DateTimeKind.Local).AddTicks(7551), 44, new DateTime(2022, 2, 12, 18, 14, 51, 966, DateTimeKind.Local).AddTicks(2940), new DateTime(2020, 5, 1, 23, 37, 37, 73, DateTimeKind.Local).AddTicks(8539), 3, 47, "Enim atque ipsum.\nPariatur repudiandae quod.\nSit qui incidunt optio ipsum." },
                    { 166, new DateTime(2020, 7, 29, 17, 50, 22, 367, DateTimeKind.Local).AddTicks(2021), 54, new DateTime(2021, 5, 6, 3, 11, 33, 900, DateTimeKind.Local).AddTicks(7408), new DateTime(2020, 4, 23, 18, 13, 39, 868, DateTimeKind.Local).AddTicks(1349), 5, 47, "et" },
                    { 68, new DateTime(2020, 9, 26, 2, 0, 39, 636, DateTimeKind.Local).AddTicks(6264), 146, new DateTime(2021, 9, 17, 7, 23, 58, 830, DateTimeKind.Local).AddTicks(8755), new DateTime(2020, 9, 26, 9, 52, 59, 240, DateTimeKind.Local).AddTicks(1189), 2, 67, "velit" },
                    { 71, new DateTime(2020, 9, 2, 12, 37, 34, 954, DateTimeKind.Local).AddTicks(2160), 7, new DateTime(2021, 10, 30, 7, 9, 32, 789, DateTimeKind.Local).AddTicks(7568), new DateTime(2021, 1, 20, 5, 1, 4, 246, DateTimeKind.Local).AddTicks(4083), 3, 67, "Sed qui dolores enim sed. Ut tempore alias quisquam tempore in dignissimos. Ratione voluptatem porro dicta. Rem et reprehenderit." },
                    { 182, new DateTime(2020, 9, 11, 2, 0, 18, 869, DateTimeKind.Local).AddTicks(6170), 49, new DateTime(2021, 9, 29, 6, 40, 25, 664, DateTimeKind.Local).AddTicks(3675), new DateTime(2020, 9, 8, 8, 4, 31, 310, DateTimeKind.Local).AddTicks(9887), 5, 6, "quia" },
                    { 87, new DateTime(2020, 8, 25, 23, 34, 25, 177, DateTimeKind.Local).AddTicks(657), 68, new DateTime(2021, 5, 29, 9, 2, 40, 865, DateTimeKind.Local).AddTicks(5363), new DateTime(2021, 3, 24, 8, 4, 29, 609, DateTimeKind.Local).AddTicks(3532), 2, 67, "Ad non necessitatibus. Libero reprehenderit voluptatum ut at nulla tempore et adipisci ut. Nostrum exercitationem fugiat ullam." },
                    { 151, new DateTime(2020, 4, 16, 8, 15, 27, 366, DateTimeKind.Local).AddTicks(1457), 114, new DateTime(2021, 12, 14, 7, 5, 16, 451, DateTimeKind.Local).AddTicks(3912), new DateTime(2020, 10, 25, 15, 23, 30, 707, DateTimeKind.Local).AddTicks(8828), 4, 6, "Consequatur sit non." },
                    { 80, new DateTime(2020, 5, 13, 20, 7, 45, 251, DateTimeKind.Local).AddTicks(6528), 62, new DateTime(2021, 8, 8, 3, 58, 21, 393, DateTimeKind.Local).AddTicks(7499), new DateTime(2021, 1, 31, 17, 39, 55, 994, DateTimeKind.Local).AddTicks(9515), 3, 6, "Quos recusandae quis et iste aliquam et est. Accusamus praesentium ab aperiam maxime quos. Qui dolores quod architecto quia eligendi natus omnis. In veritatis asperiores saepe voluptate at sed hic." },
                    { 64, new DateTime(2020, 5, 8, 5, 16, 59, 939, DateTimeKind.Local).AddTicks(8197), 48, new DateTime(2021, 7, 20, 12, 33, 46, 968, DateTimeKind.Local).AddTicks(374), new DateTime(2020, 10, 22, 9, 2, 34, 670, DateTimeKind.Local).AddTicks(5201), 5, 12, "Veniam voluptas et necessitatibus quia.\nOmnis rerum consequatur repudiandae ea illo.\nSit illo officia.\nNon possimus corrupti aliquid eum et deleniti officia in." },
                    { 199, new DateTime(2021, 2, 23, 23, 2, 3, 266, DateTimeKind.Local).AddTicks(1474), 112, new DateTime(2021, 9, 8, 19, 36, 0, 653, DateTimeKind.Local).AddTicks(2995), new DateTime(2020, 8, 4, 20, 18, 22, 150, DateTimeKind.Local).AddTicks(2755), 4, 12, "Qui non aut exercitationem." },
                    { 194, new DateTime(2021, 1, 5, 8, 58, 20, 547, DateTimeKind.Local).AddTicks(5647), 148, new DateTime(2022, 2, 24, 8, 1, 0, 915, DateTimeKind.Local).AddTicks(8531), new DateTime(2020, 12, 30, 21, 15, 10, 524, DateTimeKind.Local).AddTicks(1257), 2, 27, "sit" },
                    { 34, new DateTime(2020, 10, 12, 2, 36, 12, 197, DateTimeKind.Local).AddTicks(9856), 129, new DateTime(2021, 7, 31, 5, 5, 9, 8, DateTimeKind.Local).AddTicks(9471), new DateTime(2020, 9, 23, 8, 10, 3, 415, DateTimeKind.Local).AddTicks(3589), 4, 11, "Magnam quia quia et minima exercitationem officiis deserunt nesciunt. Praesentium vero sed sed eius atque nobis aut. Tenetur aliquid eligendi repudiandae aliquid enim cum hic minus reprehenderit. Sunt minus commodi voluptate non nobis. Ab non aut autem iusto et ea. Sit est nesciunt quaerat dicta ut rerum sit ut." },
                    { 54, new DateTime(2020, 8, 12, 11, 9, 57, 361, DateTimeKind.Local).AddTicks(7991), 108, new DateTime(2021, 9, 8, 12, 16, 57, 542, DateTimeKind.Local).AddTicks(8175), new DateTime(2021, 2, 6, 23, 25, 24, 48, DateTimeKind.Local).AddTicks(57), 1, 11, "Nemo provident possimus nesciunt.\nAdipisci eos temporibus culpa quia dolores autem ad eligendi.\nEarum sunt officia aut rem ut necessitatibus.\nVoluptas rerum est." },
                    { 77, new DateTime(2020, 7, 29, 3, 58, 12, 662, DateTimeKind.Local).AddTicks(280), 101, new DateTime(2022, 2, 16, 5, 46, 56, 90, DateTimeKind.Local).AddTicks(7860), new DateTime(2021, 1, 24, 16, 5, 52, 276, DateTimeKind.Local).AddTicks(4569), 2, 11, "Et minima in doloribus voluptas eos ut explicabo quos. Autem ut quia veniam dolorem nobis delectus soluta laboriosam voluptatem. Culpa voluptatem dolorum blanditiis vel quisquam dolorem similique. Vitae quis at aperiam ex tempore dolores vel dicta at." },
                    { 86, new DateTime(2021, 3, 1, 20, 33, 50, 365, DateTimeKind.Local).AddTicks(7017), 55, new DateTime(2021, 9, 29, 5, 22, 46, 139, DateTimeKind.Local).AddTicks(9950), new DateTime(2020, 6, 9, 0, 30, 59, 351, DateTimeKind.Local).AddTicks(7798), 1, 79, "Eaque molestiae saepe dolorem expedita aspernatur libero magni veritatis error. Repellat velit est ut ea maiores consequatur aspernatur error. Est tenetur molestiae ut vel. Animi recusandae occaecati nisi totam nihil. Rem impedit nisi et voluptates quis ut." },
                    { 133, new DateTime(2020, 12, 11, 17, 19, 24, 297, DateTimeKind.Local).AddTicks(3391), 30, new DateTime(2021, 5, 18, 13, 0, 39, 687, DateTimeKind.Local).AddTicks(761), new DateTime(2021, 1, 3, 0, 42, 1, 989, DateTimeKind.Local).AddTicks(3934), 4, 63, "Officia aut alias quibusdam illo." },
                    { 141, new DateTime(2020, 11, 27, 22, 3, 36, 38, DateTimeKind.Local).AddTicks(3986), 78, new DateTime(2021, 6, 17, 3, 16, 41, 445, DateTimeKind.Local).AddTicks(1905), new DateTime(2020, 9, 28, 7, 49, 33, 597, DateTimeKind.Local).AddTicks(9533), 5, 63, "Voluptas qui qui ut sed." },
                    { 36, new DateTime(2021, 1, 13, 5, 28, 26, 404, DateTimeKind.Local).AddTicks(974), 113, new DateTime(2021, 7, 9, 21, 51, 24, 623, DateTimeKind.Local).AddTicks(1958), new DateTime(2021, 2, 23, 4, 31, 20, 937, DateTimeKind.Local).AddTicks(1832), 1, 5, "Repudiandae dolorem excepturi et sunt ut autem.\nNemo debitis qui porro praesentium eveniet.\nReprehenderit optio necessitatibus est possimus ut ut consequuntur.\nConsequuntur est facilis magnam est sequi ut ut quia.\nDeserunt id dolor ex quasi.\nOmnis nam saepe eos quia aut aperiam incidunt." },
                    { 81, new DateTime(2020, 9, 22, 0, 5, 46, 268, DateTimeKind.Local).AddTicks(2827), 76, new DateTime(2021, 7, 7, 21, 28, 54, 516, DateTimeKind.Local).AddTicks(7591), new DateTime(2020, 6, 2, 19, 3, 55, 631, DateTimeKind.Local).AddTicks(3261), 2, 5, "tempora" },
                    { 61, new DateTime(2020, 6, 27, 2, 19, 50, 89, DateTimeKind.Local).AddTicks(2752), 50, new DateTime(2021, 9, 21, 0, 55, 28, 851, DateTimeKind.Local).AddTicks(9157), new DateTime(2021, 2, 27, 23, 58, 57, 100, DateTimeKind.Local).AddTicks(6441), 3, 13, "Quibusdam sed officia cupiditate et et.\nId minus laborum et quaerat error veritatis.\nDeserunt qui nostrum eius iste quia quae repellat sit laudantium.\nReiciendis eveniet doloribus esse quasi omnis rem labore.\nPorro numquam deserunt et.\nNam non voluptas qui modi rerum pariatur." },
                    { 113, new DateTime(2020, 10, 19, 9, 48, 49, 413, DateTimeKind.Local).AddTicks(6533), 66, new DateTime(2021, 12, 27, 10, 22, 59, 848, DateTimeKind.Local).AddTicks(8068), new DateTime(2020, 4, 30, 14, 32, 48, 332, DateTimeKind.Local).AddTicks(8721), 1, 13, "tempore" },
                    { 144, new DateTime(2020, 6, 12, 16, 4, 43, 861, DateTimeKind.Local).AddTicks(8242), 94, new DateTime(2021, 7, 2, 15, 11, 35, 216, DateTimeKind.Local).AddTicks(4807), new DateTime(2020, 5, 14, 18, 9, 12, 750, DateTimeKind.Local).AddTicks(6295), 4, 13, "Earum maxime non neque sunt.\nQuia esse et ipsum commodi asperiores aliquam voluptas animi impedit.\nSit tempore excepturi aspernatur asperiores explicabo expedita impedit voluptas.\nQuisquam atque est ratione recusandae nisi totam aut error." },
                    { 22, new DateTime(2020, 12, 8, 11, 12, 2, 400, DateTimeKind.Local).AddTicks(5308), 53, new DateTime(2021, 6, 25, 0, 54, 57, 791, DateTimeKind.Local).AddTicks(7275), new DateTime(2020, 7, 2, 18, 8, 43, 6, DateTimeKind.Local).AddTicks(1604), 5, 52, "Delectus non consectetur dolorem. Quis adipisci eius architecto. Non aliquid cumque provident. Ab eius dolorem fugiat molestias. Occaecati maiores neque." },
                    { 29, new DateTime(2020, 9, 10, 8, 25, 57, 49, DateTimeKind.Local).AddTicks(5381), 113, new DateTime(2021, 10, 20, 5, 8, 45, 597, DateTimeKind.Local).AddTicks(3178), new DateTime(2021, 2, 5, 19, 56, 11, 64, DateTimeKind.Local).AddTicks(4784), 1, 99, "Laudantium ea accusamus quo soluta dolor consequatur in." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 56, new DateTime(2020, 11, 4, 0, 10, 15, 104, DateTimeKind.Local).AddTicks(9117), 35, new DateTime(2021, 10, 27, 2, 0, 0, 425, DateTimeKind.Local).AddTicks(9105), new DateTime(2020, 7, 19, 13, 10, 24, 207, DateTimeKind.Local).AddTicks(9520), 4, 99, "Modi consectetur cum dolorum quia praesentium optio tempore quis. Dolor numquam modi quia vero consequatur. Quia debitis totam non at ut eligendi quis." },
                    { 139, new DateTime(2020, 11, 8, 7, 49, 36, 601, DateTimeKind.Local).AddTicks(2426), 6, new DateTime(2021, 10, 6, 2, 2, 4, 204, DateTimeKind.Local).AddTicks(2241), new DateTime(2020, 8, 28, 21, 33, 40, 999, DateTimeKind.Local).AddTicks(1026), 1, 99, "Ad ipsam aliquid qui nulla." },
                    { 31, new DateTime(2020, 6, 3, 17, 58, 32, 435, DateTimeKind.Local).AddTicks(3150), 78, new DateTime(2021, 7, 19, 8, 56, 24, 397, DateTimeKind.Local).AddTicks(8187), new DateTime(2020, 7, 17, 21, 29, 23, 952, DateTimeKind.Local).AddTicks(3787), 3, 6, "Et consequuntur molestiae dicta beatae quibusdam est.\nQuas perferendis ad.\nEt eos fuga modi placeat sint.\nCulpa eum praesentium totam fugit.\nAt officia vel.\nNecessitatibus ipsam inventore ut ut dolore." },
                    { 40, new DateTime(2021, 1, 25, 8, 37, 46, 674, DateTimeKind.Local).AddTicks(3973), 138, new DateTime(2022, 1, 4, 10, 52, 32, 370, DateTimeKind.Local).AddTicks(5216), new DateTime(2020, 5, 30, 7, 45, 16, 939, DateTimeKind.Local).AddTicks(9241), 2, 6, "Illo incidunt id doloribus ea aut sed sed.\nQui dolore tenetur dolorem enim expedita quidem." },
                    { 51, new DateTime(2020, 12, 2, 4, 29, 25, 143, DateTimeKind.Local).AddTicks(512), 124, new DateTime(2021, 7, 30, 20, 59, 8, 54, DateTimeKind.Local).AddTicks(1415), new DateTime(2020, 11, 30, 5, 17, 45, 136, DateTimeKind.Local).AddTicks(1373), 1, 6, "Itaque tempore doloremque harum in ex pariatur.\nEst id neque excepturi beatae.\nNulla in autem.\nAd veritatis consequatur aspernatur temporibus deleniti dicta animi." },
                    { 150, new DateTime(2021, 4, 4, 11, 28, 54, 627, DateTimeKind.Local).AddTicks(6154), 83, new DateTime(2022, 2, 15, 20, 4, 18, 152, DateTimeKind.Local).AddTicks(3611), new DateTime(2021, 3, 21, 6, 7, 9, 687, DateTimeKind.Local).AddTicks(3796), 5, 6, "maxime" },
                    { 44, new DateTime(2021, 1, 5, 23, 24, 40, 328, DateTimeKind.Local).AddTicks(8214), 8, new DateTime(2021, 8, 1, 17, 59, 27, 202, DateTimeKind.Local).AddTicks(1031), new DateTime(2020, 5, 13, 19, 47, 47, 152, DateTimeKind.Local).AddTicks(1620), 4, 12, "Est aut est tenetur." },
                    { 17, new DateTime(2020, 8, 29, 7, 25, 57, 29, DateTimeKind.Local).AddTicks(102), 83, new DateTime(2021, 6, 30, 20, 16, 7, 62, DateTimeKind.Local).AddTicks(8418), new DateTime(2021, 3, 31, 12, 11, 12, 521, DateTimeKind.Local).AddTicks(2598), 5, 7, "Consectetur perspiciatis et maiores ipsam quos autem consequatur. Adipisci voluptatem ea et nihil nisi natus sint qui. Cum iure esse natus. Ab eos omnis sit odit non minima. Quia numquam ullam. Enim necessitatibus et repudiandae ut quibusdam." },
                    { 196, new DateTime(2021, 4, 2, 11, 57, 37, 288, DateTimeKind.Local).AddTicks(5341), 50, new DateTime(2022, 2, 24, 6, 50, 57, 953, DateTimeKind.Local).AddTicks(7700), new DateTime(2020, 11, 5, 9, 14, 26, 155, DateTimeKind.Local).AddTicks(8023), 4, 7, "iure" },
                    { 142, new DateTime(2021, 3, 31, 1, 47, 11, 996, DateTimeKind.Local).AddTicks(2113), 13, new DateTime(2021, 5, 5, 8, 20, 49, 880, DateTimeKind.Local).AddTicks(1934), new DateTime(2020, 12, 23, 18, 46, 50, 619, DateTimeKind.Local).AddTicks(5872), 3, 23, "Repudiandae accusantium rerum voluptates voluptas eos quia amet qui veniam.\nAutem dolorem eum beatae rerum natus totam.\nVitae excepturi sint assumenda." },
                    { 74, new DateTime(2020, 10, 31, 21, 14, 24, 783, DateTimeKind.Local).AddTicks(4223), 106, new DateTime(2022, 4, 2, 11, 5, 1, 340, DateTimeKind.Local).AddTicks(7756), new DateTime(2020, 8, 4, 23, 40, 10, 212, DateTimeKind.Local).AddTicks(5979), 4, 97, "Rem facilis harum et voluptas alias minima consequuntur quisquam ut. Eaque provident ut aut iure consequatur est. Natus veritatis nulla." },
                    { 132, new DateTime(2021, 1, 7, 3, 24, 22, 313, DateTimeKind.Local).AddTicks(4116), 84, new DateTime(2022, 4, 14, 18, 52, 46, 729, DateTimeKind.Local).AddTicks(9072), new DateTime(2020, 11, 15, 16, 13, 4, 385, DateTimeKind.Local).AddTicks(1746), 1, 97, "voluptas" },
                    { 137, new DateTime(2020, 10, 13, 9, 59, 3, 677, DateTimeKind.Local).AddTicks(8304), 9, new DateTime(2022, 1, 26, 22, 6, 55, 601, DateTimeKind.Local).AddTicks(9112), new DateTime(2020, 5, 4, 2, 35, 50, 899, DateTimeKind.Local).AddTicks(4705), 2, 97, "Similique quidem repellendus odit quibusdam non numquam minima aspernatur dolor.\nQuos vel ipsum veniam reprehenderit voluptatem occaecati quis delectus quia.\nRatione doloribus rerum voluptatibus quia.\nSed ut vel quidem neque." },
                    { 173, new DateTime(2020, 8, 2, 21, 5, 49, 863, DateTimeKind.Local).AddTicks(7979), 6, new DateTime(2021, 5, 18, 13, 21, 35, 968, DateTimeKind.Local).AddTicks(6840), new DateTime(2020, 7, 2, 13, 58, 47, 694, DateTimeKind.Local).AddTicks(545), 2, 97, "Sequi eveniet ut dicta quo." },
                    { 59, new DateTime(2020, 5, 21, 19, 50, 39, 280, DateTimeKind.Local).AddTicks(6758), 20, new DateTime(2021, 11, 24, 19, 4, 53, 207, DateTimeKind.Local).AddTicks(9073), new DateTime(2020, 5, 29, 18, 18, 14, 413, DateTimeKind.Local).AddTicks(3071), 3, 51, "Sunt quidem ipsa in est quis nulla voluptatibus sit. Quisquam dolorem odio vel nobis et voluptatibus fuga. Dolores velit dolore reiciendis distinctio est sit ut quas. Est et debitis modi nihil et dolores sed expedita doloribus." },
                    { 83, new DateTime(2020, 6, 17, 21, 42, 12, 957, DateTimeKind.Local).AddTicks(4539), 81, new DateTime(2021, 4, 19, 17, 10, 38, 811, DateTimeKind.Local).AddTicks(7956), new DateTime(2020, 9, 23, 13, 34, 23, 884, DateTimeKind.Local).AddTicks(141), 3, 51, "Alias nesciunt adipisci quidem porro et perferendis quaerat aspernatur. Ut quia veniam. Est est pariatur omnis dolorem sit quae culpa. Eaque ipsum recusandae." },
                    { 3, new DateTime(2020, 10, 5, 11, 11, 13, 496, DateTimeKind.Local).AddTicks(24), 76, new DateTime(2022, 1, 5, 20, 15, 20, 290, DateTimeKind.Local).AddTicks(8228), new DateTime(2020, 7, 7, 2, 45, 39, 138, DateTimeKind.Local).AddTicks(2978), 1, 26, "Deserunt odio corrupti consectetur et eum voluptatum quas ex.\nQuae qui nihil ut tempora ipsam unde dolorem.\nAtque rerum quo.\nDolore qui recusandae.\nRem sit eum iste.\nEst consequuntur ut blanditiis asperiores ex aut at." },
                    { 14, new DateTime(2020, 11, 4, 22, 42, 56, 301, DateTimeKind.Local).AddTicks(359), 8, new DateTime(2021, 12, 11, 18, 16, 0, 559, DateTimeKind.Local).AddTicks(1377), new DateTime(2020, 6, 4, 15, 6, 36, 760, DateTimeKind.Local).AddTicks(3776), 5, 26, "At quidem vero commodi dolorem sed ut ullam dolor.\nDolores tenetur laudantium qui atque labore dolor voluptatem dolorem.\nVoluptatem qui velit quae." },
                    { 95, new DateTime(2020, 9, 9, 0, 10, 2, 977, DateTimeKind.Local).AddTicks(8584), 43, new DateTime(2022, 3, 17, 22, 22, 49, 646, DateTimeKind.Local).AddTicks(4313), new DateTime(2021, 4, 8, 16, 7, 17, 94, DateTimeKind.Local).AddTicks(5665), 4, 26, "Ut dolores animi eum quas quidem veniam temporibus.\nNesciunt repellat consectetur aliquam dolorem." },
                    { 1, new DateTime(2020, 5, 23, 13, 30, 5, 838, DateTimeKind.Local).AddTicks(4349), 66, new DateTime(2021, 10, 31, 21, 34, 16, 342, DateTimeKind.Local).AddTicks(9377), new DateTime(2020, 10, 22, 14, 13, 39, 832, DateTimeKind.Local).AddTicks(7074), 1, 17, "Quia quibusdam ut et eos eligendi aut saepe.\nItaque ipsam voluptates consequuntur autem explicabo.\nAliquid corrupti sint sint enim quidem est.\nUt eum consectetur expedita voluptatem ea corrupti saepe natus." },
                    { 109, new DateTime(2020, 6, 26, 7, 36, 4, 463, DateTimeKind.Local).AddTicks(9878), 49, new DateTime(2022, 3, 12, 12, 13, 11, 576, DateTimeKind.Local).AddTicks(2693), new DateTime(2020, 5, 7, 6, 3, 21, 427, DateTimeKind.Local).AddTicks(9789), 3, 17, "Nisi eveniet quia possimus." },
                    { 145, new DateTime(2021, 2, 21, 13, 43, 31, 580, DateTimeKind.Local).AddTicks(9725), 146, new DateTime(2022, 4, 9, 4, 52, 27, 135, DateTimeKind.Local).AddTicks(8534), new DateTime(2020, 8, 10, 14, 45, 52, 94, DateTimeKind.Local).AddTicks(9875), 2, 17, "non" },
                    { 163, new DateTime(2020, 8, 19, 0, 58, 13, 985, DateTimeKind.Local).AddTicks(2811), 101, new DateTime(2021, 11, 30, 5, 4, 39, 222, DateTimeKind.Local).AddTicks(7001), new DateTime(2020, 5, 21, 21, 55, 51, 517, DateTimeKind.Local).AddTicks(2934), 1, 17, "Necessitatibus odio consequatur voluptatem nam laboriosam vel." },
                    { 52, new DateTime(2020, 7, 23, 1, 2, 52, 788, DateTimeKind.Local).AddTicks(8245), 142, new DateTime(2021, 12, 17, 8, 1, 54, 380, DateTimeKind.Local).AddTicks(5360), new DateTime(2020, 11, 16, 10, 56, 27, 864, DateTimeKind.Local).AddTicks(3453), 3, 10, "Iusto est pariatur molestias quod et.\nInventore autem fugiat iusto nam modi temporibus rerum quidem.\nVoluptatum cupiditate sequi voluptas rerum unde perspiciatis aut maiores.\nDoloremque et sint ipsa at perspiciatis." },
                    { 78, new DateTime(2020, 7, 6, 13, 34, 36, 695, DateTimeKind.Local).AddTicks(8067), 63, new DateTime(2022, 3, 28, 17, 38, 48, 295, DateTimeKind.Local).AddTicks(850), new DateTime(2020, 10, 3, 5, 16, 3, 292, DateTimeKind.Local).AddTicks(8494), 3, 10, "Voluptas provident dolore error id doloremque quia ab consequuntur." },
                    { 13, new DateTime(2020, 10, 20, 6, 36, 4, 930, DateTimeKind.Local).AddTicks(472), 5, new DateTime(2021, 8, 19, 3, 21, 50, 312, DateTimeKind.Local).AddTicks(6754), new DateTime(2020, 11, 3, 12, 17, 47, 674, DateTimeKind.Local).AddTicks(6961), 2, 95, "Placeat nemo iste iure quia rerum. Tempore aut amet illo omnis laboriosam ratione neque explicabo corrupti. Nesciunt nam et eveniet libero cumque voluptatem. Odit reprehenderit quis autem voluptatem. Qui debitis eligendi soluta vero nemo amet sit qui id. Quaerat et culpa." },
                    { 127, new DateTime(2020, 11, 8, 18, 22, 41, 389, DateTimeKind.Local).AddTicks(607), 103, new DateTime(2021, 5, 1, 15, 22, 2, 22, DateTimeKind.Local).AddTicks(657), new DateTime(2020, 6, 21, 0, 38, 57, 733, DateTimeKind.Local).AddTicks(2055), 3, 95, "In temporibus voluptatem laborum ad aut.\nUt temporibus eum." },
                    { 190, new DateTime(2021, 2, 28, 11, 36, 49, 227, DateTimeKind.Local).AddTicks(9757), 132, new DateTime(2021, 11, 25, 22, 20, 55, 225, DateTimeKind.Local).AddTicks(7845), new DateTime(2020, 6, 10, 10, 0, 9, 749, DateTimeKind.Local).AddTicks(5156), 2, 95, "Sunt qui animi vel corrupti quas velit natus. Placeat repellat veniam nesciunt. Consequatur atque consequuntur incidunt quia. Aperiam sapiente quibusdam. Tempore laborum ad unde consequuntur mollitia est libero dolor." },
                    { 35, new DateTime(2020, 10, 17, 8, 43, 33, 772, DateTimeKind.Local).AddTicks(6878), 80, new DateTime(2022, 3, 12, 6, 41, 52, 38, DateTimeKind.Local).AddTicks(3258), new DateTime(2021, 2, 27, 22, 9, 9, 483, DateTimeKind.Local).AddTicks(7424), 4, 94, "Sed quod et est." },
                    { 38, new DateTime(2020, 5, 12, 17, 11, 35, 504, DateTimeKind.Local).AddTicks(1307), 134, new DateTime(2021, 10, 25, 21, 18, 12, 166, DateTimeKind.Local).AddTicks(7140), new DateTime(2020, 12, 13, 10, 41, 29, 786, DateTimeKind.Local).AddTicks(3773), 1, 94, "Voluptates quia similique laboriosam voluptatem animi sed et velit.\nCulpa et sequi et dicta reiciendis voluptates eaque quae voluptatibus.\nOdio perferendis repudiandae quod rerum eligendi totam ut." },
                    { 93, new DateTime(2021, 1, 30, 9, 50, 18, 175, DateTimeKind.Local).AddTicks(1936), 7, new DateTime(2021, 10, 29, 0, 39, 27, 875, DateTimeKind.Local).AddTicks(7139), new DateTime(2020, 11, 28, 8, 20, 17, 437, DateTimeKind.Local).AddTicks(8820), 5, 23, "Ullam et corrupti minus voluptatem est dolor unde.\nDistinctio porro rem et magni porro consequatur.\nExpedita autem eaque veritatis veniam culpa." },
                    { 112, new DateTime(2020, 7, 11, 6, 40, 51, 439, DateTimeKind.Local), 78, new DateTime(2022, 3, 4, 14, 7, 56, 3, DateTimeKind.Local).AddTicks(3571), new DateTime(2020, 6, 23, 22, 2, 21, 291, DateTimeKind.Local).AddTicks(2559), 2, 7, "Reiciendis consequatur totam exercitationem sapiente voluptate maxime dolorum dolore natus." },
                    { 47, new DateTime(2020, 6, 1, 20, 45, 56, 918, DateTimeKind.Local).AddTicks(3585), 14, new DateTime(2022, 2, 15, 14, 28, 38, 217, DateTimeKind.Local).AddTicks(6511), new DateTime(2021, 3, 27, 20, 46, 32, 8, DateTimeKind.Local).AddTicks(5759), 1, 23, "Doloribus debitis eius nam assumenda consequuntur id natus. Nemo dolor cumque illo aspernatur similique rerum. Nobis nihil et minima natus. Eligendi temporibus amet deserunt." },
                    { 24, new DateTime(2021, 3, 23, 20, 4, 42, 51, DateTimeKind.Local).AddTicks(4045), 62, new DateTime(2022, 3, 8, 21, 0, 1, 655, DateTimeKind.Local).AddTicks(4138), new DateTime(2020, 12, 17, 8, 39, 31, 713, DateTimeKind.Local).AddTicks(3992), 1, 23, "quia" },
                    { 46, new DateTime(2021, 2, 18, 20, 54, 22, 873, DateTimeKind.Local).AddTicks(1650), 99, new DateTime(2021, 8, 20, 10, 57, 46, 958, DateTimeKind.Local).AddTicks(2405), new DateTime(2021, 4, 14, 11, 32, 9, 63, DateTimeKind.Local).AddTicks(5693), 5, 40, "Earum laboriosam mollitia.\nQuo nisi maiores ut.\nLaborum magni dolor accusamus nam autem.\nAb in doloribus ducimus voluptatem sequi." },
                    { 98, new DateTime(2021, 1, 17, 23, 54, 35, 508, DateTimeKind.Local).AddTicks(7426), 71, new DateTime(2022, 4, 11, 1, 27, 49, 812, DateTimeKind.Local).AddTicks(9074), new DateTime(2020, 7, 12, 15, 46, 18, 377, DateTimeKind.Local).AddTicks(8805), 5, 40, "Qui est ea molestiae.\nUt corporis omnis nesciunt voluptatem eligendi.\nOmnis amet voluptas." },
                    { 114, new DateTime(2020, 11, 1, 15, 45, 43, 28, DateTimeKind.Local).AddTicks(3573), 127, new DateTime(2021, 4, 27, 0, 33, 6, 395, DateTimeKind.Local).AddTicks(7892), new DateTime(2020, 12, 5, 10, 54, 41, 106, DateTimeKind.Local).AddTicks(483), 5, 40, "Ut consequuntur et ducimus repudiandae voluptatem. Cupiditate eligendi et. Omnis dolorem est suscipit ut. Nulla laboriosam nesciunt. In ut non ut totam voluptas veniam ut laborum quis." },
                    { 159, new DateTime(2020, 11, 20, 10, 46, 29, 753, DateTimeKind.Local).AddTicks(670), 58, new DateTime(2021, 11, 18, 5, 40, 16, 639, DateTimeKind.Local).AddTicks(4436), new DateTime(2021, 2, 15, 15, 53, 50, 836, DateTimeKind.Local).AddTicks(7586), 3, 40, "Aut eaque corporis ea hic qui corporis." },
                    { 180, new DateTime(2020, 12, 7, 11, 58, 59, 826, DateTimeKind.Local).AddTicks(6762), 38, new DateTime(2021, 10, 1, 5, 13, 52, 65, DateTimeKind.Local).AddTicks(955), new DateTime(2021, 3, 29, 2, 51, 0, 0, DateTimeKind.Local).AddTicks(2184), 3, 40, "est" },
                    { 76, new DateTime(2020, 10, 21, 11, 31, 26, 348, DateTimeKind.Local).AddTicks(6078), 33, new DateTime(2021, 6, 10, 5, 26, 0, 2, DateTimeKind.Local).AddTicks(8781), new DateTime(2021, 3, 20, 5, 17, 9, 753, DateTimeKind.Local).AddTicks(458), 2, 14, "Autem reiciendis repellendus aut voluptas ipsam velit ut voluptatibus.\nSaepe aut esse asperiores soluta ipsam sit facilis hic officia." },
                    { 45, new DateTime(2020, 10, 12, 1, 25, 6, 942, DateTimeKind.Local).AddTicks(1423), 131, new DateTime(2021, 5, 7, 3, 59, 37, 288, DateTimeKind.Local).AddTicks(2079), new DateTime(2021, 4, 1, 19, 3, 57, 511, DateTimeKind.Local).AddTicks(8043), 5, 90, "aliquid" },
                    { 75, new DateTime(2021, 3, 12, 4, 15, 15, 22, DateTimeKind.Local).AddTicks(2385), 147, new DateTime(2022, 4, 15, 14, 1, 42, 834, DateTimeKind.Local).AddTicks(4983), new DateTime(2020, 12, 15, 12, 57, 9, 622, DateTimeKind.Local).AddTicks(8330), 4, 90, "Animi optio aliquam fuga dolorem pariatur. Quidem veritatis quis magni ut in sunt nam. Perspiciatis maxime occaecati voluptatem et fugiat id. Et consectetur itaque rerum veritatis voluptatem molestias laboriosam molestiae autem. Laboriosam ad ut nulla ut quasi ut doloremque consectetur non. Debitis id ullam aut iusto accusantium ut est in assumenda." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 84, new DateTime(2020, 9, 20, 14, 32, 35, 302, DateTimeKind.Local).AddTicks(3035), 38, new DateTime(2022, 3, 10, 18, 41, 37, 652, DateTimeKind.Local).AddTicks(6905), new DateTime(2020, 10, 25, 19, 13, 1, 139, DateTimeKind.Local).AddTicks(2336), 1, 90, "Magnam dolorem deserunt. Aut non dolore ut veniam atque facilis tempore recusandae. Laudantium error natus aut ipsa assumenda nihil. Sequi laudantium dolor labore. Magnam natus excepturi eos labore est." },
                    { 120, new DateTime(2020, 5, 26, 3, 31, 4, 260, DateTimeKind.Local).AddTicks(160), 57, new DateTime(2021, 11, 2, 18, 14, 54, 227, DateTimeKind.Local).AddTicks(2876), new DateTime(2020, 9, 2, 7, 38, 55, 513, DateTimeKind.Local).AddTicks(3813), 2, 90, "Beatae et nesciunt ipsa labore harum exercitationem voluptas." },
                    { 158, new DateTime(2021, 1, 10, 3, 45, 14, 78, DateTimeKind.Local).AddTicks(5431), 31, new DateTime(2021, 7, 5, 19, 19, 56, 321, DateTimeKind.Local).AddTicks(2736), new DateTime(2020, 5, 5, 15, 2, 16, 372, DateTimeKind.Local).AddTicks(4097), 2, 90, "rem" },
                    { 23, new DateTime(2020, 7, 30, 9, 1, 48, 728, DateTimeKind.Local).AddTicks(8640), 23, new DateTime(2021, 7, 4, 16, 24, 55, 649, DateTimeKind.Local).AddTicks(7307), new DateTime(2020, 4, 21, 2, 46, 53, 779, DateTimeKind.Local).AddTicks(8583), 1, 60, "veniam" },
                    { 85, new DateTime(2020, 9, 5, 13, 19, 57, 935, DateTimeKind.Local).AddTicks(4846), 79, new DateTime(2021, 11, 4, 3, 42, 23, 59, DateTimeKind.Local).AddTicks(703), new DateTime(2020, 7, 24, 23, 48, 40, 758, DateTimeKind.Local).AddTicks(6958), 5, 19, "et" },
                    { 164, new DateTime(2020, 8, 6, 9, 0, 54, 326, DateTimeKind.Local).AddTicks(7627), 42, new DateTime(2021, 9, 15, 3, 11, 47, 366, DateTimeKind.Local).AddTicks(5481), new DateTime(2020, 5, 6, 20, 21, 26, 428, DateTimeKind.Local).AddTicks(1416), 2, 19, "Repellendus et assumenda aut ut quae." },
                    { 62, new DateTime(2021, 3, 25, 16, 4, 43, 322, DateTimeKind.Local).AddTicks(4958), 104, new DateTime(2021, 12, 18, 17, 39, 3, 553, DateTimeKind.Local).AddTicks(8830), new DateTime(2020, 6, 27, 18, 27, 13, 747, DateTimeKind.Local).AddTicks(1371), 2, 69, "Facere ut voluptate." },
                    { 100, new DateTime(2020, 5, 22, 12, 45, 27, 295, DateTimeKind.Local).AddTicks(8285), 13, new DateTime(2021, 8, 19, 19, 5, 18, 990, DateTimeKind.Local).AddTicks(2463), new DateTime(2020, 8, 2, 22, 55, 38, 476, DateTimeKind.Local).AddTicks(1053), 1, 69, "dolore" },
                    { 126, new DateTime(2021, 3, 12, 2, 45, 50, 779, DateTimeKind.Local).AddTicks(670), 2, new DateTime(2021, 7, 18, 11, 31, 29, 535, DateTimeKind.Local).AddTicks(3582), new DateTime(2021, 3, 22, 6, 6, 59, 923, DateTimeKind.Local).AddTicks(4288), 5, 69, "Perspiciatis tempora quia perferendis ut nisi. Qui sit qui porro incidunt accusamus velit. Consequuntur aspernatur ipsum soluta. Consequuntur est in et." },
                    { 140, new DateTime(2020, 11, 25, 6, 5, 40, 336, DateTimeKind.Local).AddTicks(5870), 105, new DateTime(2021, 7, 20, 15, 34, 23, 674, DateTimeKind.Local).AddTicks(1935), new DateTime(2020, 9, 13, 16, 34, 20, 387, DateTimeKind.Local).AddTicks(7357), 4, 69, "hic" },
                    { 174, new DateTime(2020, 7, 17, 19, 44, 0, 922, DateTimeKind.Local).AddTicks(5012), 9, new DateTime(2022, 4, 10, 3, 36, 37, 564, DateTimeKind.Local).AddTicks(6483), new DateTime(2020, 7, 14, 15, 51, 4, 376, DateTimeKind.Local).AddTicks(9433), 5, 69, "labore" },
                    { 58, new DateTime(2021, 2, 4, 13, 56, 49, 232, DateTimeKind.Local).AddTicks(9053), 111, new DateTime(2022, 2, 18, 2, 0, 52, 941, DateTimeKind.Local).AddTicks(5265), new DateTime(2020, 9, 13, 10, 1, 8, 604, DateTimeKind.Local).AddTicks(8335), 5, 48, "eligendi" },
                    { 122, new DateTime(2020, 12, 31, 19, 19, 8, 71, DateTimeKind.Local).AddTicks(5515), 119, new DateTime(2021, 5, 7, 6, 5, 26, 868, DateTimeKind.Local).AddTicks(3987), new DateTime(2020, 10, 19, 8, 42, 10, 178, DateTimeKind.Local).AddTicks(881), 2, 48, "Quod cupiditate optio id voluptatem et officia quo. Aspernatur dolores delectus odit possimus. Odio est consequatur nisi et consequatur atque quam." },
                    { 37, new DateTime(2020, 4, 24, 2, 3, 4, 905, DateTimeKind.Local).AddTicks(7867), 20, new DateTime(2021, 10, 30, 14, 7, 5, 280, DateTimeKind.Local).AddTicks(4087), new DateTime(2020, 10, 21, 2, 52, 4, 782, DateTimeKind.Local).AddTicks(4219), 5, 23, "Optio id autem in quaerat ut facere voluptatem." },
                    { 26, new DateTime(2020, 10, 18, 20, 29, 16, 232, DateTimeKind.Local).AddTicks(4434), 66, new DateTime(2021, 10, 19, 14, 55, 3, 855, DateTimeKind.Local).AddTicks(9098), new DateTime(2020, 9, 29, 9, 33, 5, 699, DateTimeKind.Local).AddTicks(7678), 3, 12, "dolorem" },
                    { 4, new DateTime(2021, 3, 28, 9, 54, 55, 368, DateTimeKind.Local).AddTicks(6588), 1, new DateTime(2021, 6, 20, 2, 36, 35, 280, DateTimeKind.Local).AddTicks(2453), new DateTime(2020, 10, 15, 9, 41, 33, 385, DateTimeKind.Local).AddTicks(4036), 5, 12, "Soluta unde quisquam molestiae unde reprehenderit quia possimus esse labore." },
                    { 187, new DateTime(2020, 8, 18, 19, 24, 13, 399, DateTimeKind.Local).AddTicks(1731), 71, new DateTime(2021, 5, 7, 10, 48, 2, 1, DateTimeKind.Local).AddTicks(1120), new DateTime(2020, 7, 20, 5, 4, 28, 75, DateTimeKind.Local).AddTicks(3732), 3, 32, "dignissimos" },
                    { 33, new DateTime(2020, 12, 24, 21, 45, 43, 997, DateTimeKind.Local).AddTicks(8161), 85, new DateTime(2021, 10, 6, 18, 5, 29, 871, DateTimeKind.Local).AddTicks(8637), new DateTime(2021, 1, 5, 14, 12, 31, 284, DateTimeKind.Local).AddTicks(1463), 3, 16, "Magnam accusantium accusantium consequuntur nemo ipsa." },
                    { 156, new DateTime(2021, 2, 7, 10, 50, 57, 764, DateTimeKind.Local).AddTicks(1139), 107, new DateTime(2022, 2, 9, 15, 26, 24, 520, DateTimeKind.Local).AddTicks(8344), new DateTime(2020, 11, 11, 4, 11, 0, 822, DateTimeKind.Local).AddTicks(2889), 3, 16, "Qui modi accusamus consequatur et.\nQui distinctio porro facere sapiente non natus cumque quis nesciunt.\nIpsa voluptatem ullam." },
                    { 92, new DateTime(2020, 7, 28, 5, 31, 24, 655, DateTimeKind.Local).AddTicks(9844), 146, new DateTime(2021, 4, 26, 13, 18, 18, 33, DateTimeKind.Local).AddTicks(3668), new DateTime(2020, 5, 14, 17, 33, 40, 502, DateTimeKind.Local).AddTicks(8266), 5, 28, "Dignissimos iusto dolorem quis ab soluta magni quos modi odit." },
                    { 135, new DateTime(2020, 5, 1, 10, 21, 47, 258, DateTimeKind.Local).AddTicks(9799), 89, new DateTime(2021, 8, 3, 11, 9, 13, 376, DateTimeKind.Local).AddTicks(1995), new DateTime(2020, 9, 23, 10, 36, 9, 583, DateTimeKind.Local).AddTicks(134), 3, 28, "Autem ducimus temporibus sint." },
                    { 10, new DateTime(2020, 9, 22, 13, 6, 7, 941, DateTimeKind.Local).AddTicks(4157), 57, new DateTime(2021, 9, 14, 11, 15, 3, 327, DateTimeKind.Local).AddTicks(6382), new DateTime(2021, 2, 23, 3, 41, 30, 992, DateTimeKind.Local).AddTicks(2629), 4, 38, "Qui similique necessitatibus est.\nIusto ut ex sed voluptates a ad.\nDebitis iste dolores vero eos repellendus facere." },
                    { 57, new DateTime(2020, 9, 9, 19, 4, 43, 411, DateTimeKind.Local).AddTicks(7548), 89, new DateTime(2022, 1, 4, 22, 23, 17, 510, DateTimeKind.Local).AddTicks(9330), new DateTime(2021, 1, 6, 12, 52, 34, 19, DateTimeKind.Local).AddTicks(5660), 2, 38, "ut" },
                    { 88, new DateTime(2020, 10, 16, 7, 36, 21, 906, DateTimeKind.Local).AddTicks(3061), 93, new DateTime(2021, 6, 15, 15, 5, 32, 145, DateTimeKind.Local).AddTicks(168), new DateTime(2020, 9, 22, 21, 43, 7, 327, DateTimeKind.Local).AddTicks(9250), 2, 38, "quibusdam" },
                    { 104, new DateTime(2021, 4, 3, 5, 50, 57, 900, DateTimeKind.Local).AddTicks(8676), 14, new DateTime(2022, 3, 24, 14, 1, 59, 730, DateTimeKind.Local).AddTicks(6241), new DateTime(2020, 8, 9, 16, 18, 48, 858, DateTimeKind.Local).AddTicks(8602), 2, 38, "Quibusdam id aliquid quo nihil. Aut molestias et repudiandae et id sint quis harum. Ipsum sed ut vero perferendis esse aut. Nihil sed numquam officia fugit aut incidunt. Accusamus ad impedit." },
                    { 181, new DateTime(2020, 8, 5, 14, 59, 36, 667, DateTimeKind.Local).AddTicks(649), 53, new DateTime(2021, 9, 20, 3, 13, 13, 477, DateTimeKind.Local).AddTicks(4266), new DateTime(2020, 12, 3, 8, 8, 49, 895, DateTimeKind.Local).AddTicks(8937), 4, 38, "Molestiae iste quaerat voluptatem quas.\nLabore et ipsam et." },
                    { 25, new DateTime(2020, 11, 4, 9, 40, 9, 551, DateTimeKind.Local).AddTicks(5260), 85, new DateTime(2021, 11, 28, 22, 34, 22, 628, DateTimeKind.Local).AddTicks(7788), new DateTime(2020, 7, 26, 22, 9, 42, 520, DateTimeKind.Local).AddTicks(1272), 2, 83, "Dicta sit quisquam fugit magni odit ducimus perspiciatis accusantium.\nEa dolor voluptas deserunt incidunt maiores non facilis quo.\nConsequuntur in accusantium architecto impedit." },
                    { 149, new DateTime(2020, 6, 22, 9, 35, 1, 455, DateTimeKind.Local).AddTicks(7312), 128, new DateTime(2021, 11, 28, 6, 57, 22, 114, DateTimeKind.Local).AddTicks(8459), new DateTime(2020, 4, 16, 13, 9, 29, 392, DateTimeKind.Local).AddTicks(3408), 2, 83, "eius" },
                    { 162, new DateTime(2020, 6, 8, 18, 33, 56, 752, DateTimeKind.Local).AddTicks(9167), 46, new DateTime(2021, 4, 18, 8, 22, 11, 842, DateTimeKind.Local).AddTicks(6406), new DateTime(2021, 1, 16, 21, 27, 8, 722, DateTimeKind.Local).AddTicks(7503), 5, 83, "Natus harum praesentium iste sint consequatur id sapiente quasi. Deserunt sed dignissimos ea. Aut sunt provident blanditiis qui consequuntur modi qui. Expedita nostrum magni quos vel qui id aut ea. Exercitationem dolores illo aut officia eaque ipsum et." },
                    { 178, new DateTime(2021, 3, 2, 9, 51, 8, 619, DateTimeKind.Local).AddTicks(8070), 125, new DateTime(2021, 11, 8, 3, 45, 45, 387, DateTimeKind.Local).AddTicks(5989), new DateTime(2021, 3, 13, 23, 23, 55, 171, DateTimeKind.Local).AddTicks(1722), 3, 83, "Voluptatem aut ut totam nostrum vel." },
                    { 167, new DateTime(2021, 3, 14, 0, 53, 49, 79, DateTimeKind.Local).AddTicks(4391), 128, new DateTime(2022, 1, 17, 3, 13, 23, 402, DateTimeKind.Local).AddTicks(8452), new DateTime(2020, 10, 8, 5, 30, 24, 59, DateTimeKind.Local).AddTicks(2028), 4, 22, "Nisi ut ea libero rerum aut corrupti eum est. Dicta sed et assumenda delectus quo repellendus aut perspiciatis officiis. Suscipit culpa culpa eveniet corrupti sint saepe excepturi eos aut. Nostrum cumque at at qui quaerat. Qui eos neque ratione quia consequuntur fugit veniam quia." },
                    { 177, new DateTime(2021, 2, 25, 14, 36, 57, 876, DateTimeKind.Local).AddTicks(29), 122, new DateTime(2021, 6, 14, 18, 49, 34, 175, DateTimeKind.Local).AddTicks(7023), new DateTime(2020, 6, 12, 2, 22, 12, 914, DateTimeKind.Local).AddTicks(3807), 3, 22, "Nemo molestiae repudiandae molestias non nostrum nemo. Est non quisquam commodi. Itaque voluptatibus quos. Perferendis quia dicta sed quae qui." },
                    { 197, new DateTime(2020, 6, 4, 14, 56, 35, 44, DateTimeKind.Local).AddTicks(4143), 146, new DateTime(2022, 3, 2, 8, 45, 44, 469, DateTimeKind.Local).AddTicks(3830), new DateTime(2020, 7, 26, 17, 8, 31, 973, DateTimeKind.Local).AddTicks(5576), 5, 22, "Impedit non qui harum. Dicta possimus voluptatem minus quod ea non et. Debitis sed qui corporis doloribus delectus illum." },
                    { 16, new DateTime(2021, 4, 5, 15, 18, 46, 895, DateTimeKind.Local).AddTicks(4825), 139, new DateTime(2022, 1, 3, 13, 37, 23, 556, DateTimeKind.Local).AddTicks(6855), new DateTime(2020, 12, 28, 2, 9, 22, 993, DateTimeKind.Local).AddTicks(4866), 3, 2, "Suscipit officiis recusandae ea ut est dignissimos ut incidunt tenetur." },
                    { 110, new DateTime(2020, 12, 31, 20, 29, 3, 734, DateTimeKind.Local).AddTicks(8494), 125, new DateTime(2021, 10, 19, 15, 30, 30, 187, DateTimeKind.Local).AddTicks(1100), new DateTime(2020, 8, 20, 20, 4, 35, 649, DateTimeKind.Local).AddTicks(3122), 4, 2, "esse" },
                    { 8, new DateTime(2021, 2, 8, 3, 44, 44, 389, DateTimeKind.Local).AddTicks(2601), 34, new DateTime(2022, 3, 14, 13, 7, 48, 732, DateTimeKind.Local).AddTicks(3658), new DateTime(2020, 9, 6, 18, 37, 28, 584, DateTimeKind.Local).AddTicks(7718), 2, 44, "Cum cupiditate animi possimus ipsam asperiores ipsum." },
                    { 97, new DateTime(2021, 4, 3, 11, 23, 47, 646, DateTimeKind.Local).AddTicks(5395), 82, new DateTime(2021, 8, 11, 5, 3, 37, 137, DateTimeKind.Local).AddTicks(5902), new DateTime(2020, 12, 26, 8, 19, 5, 751, DateTimeKind.Local).AddTicks(9489), 2, 44, "porro" },
                    { 183, new DateTime(2020, 11, 6, 11, 51, 14, 295, DateTimeKind.Local).AddTicks(6404), 52, new DateTime(2021, 10, 23, 21, 7, 24, 965, DateTimeKind.Local).AddTicks(1101), new DateTime(2020, 11, 8, 1, 25, 28, 699, DateTimeKind.Local).AddTicks(2751), 5, 44, "consectetur" },
                    { 147, new DateTime(2020, 6, 2, 15, 18, 11, 614, DateTimeKind.Local).AddTicks(7709), 107, new DateTime(2022, 4, 4, 15, 24, 13, 420, DateTimeKind.Local).AddTicks(6198), new DateTime(2021, 3, 6, 11, 2, 43, 680, DateTimeKind.Local).AddTicks(6466), 4, 24, "Vitae ipsa nihil.\nAmet sint qui perspiciatis autem ea.\nOccaecati qui sed qui iure.\nLaudantium ut quos enim veritatis quibusdam repellat nam quidem.\nQuibusdam voluptatem sed dolorem perspiciatis.\nDoloremque fugiat et ipsa in qui." },
                    { 200, new DateTime(2020, 8, 15, 18, 12, 28, 559, DateTimeKind.Local).AddTicks(9526), 140, new DateTime(2021, 6, 17, 2, 30, 40, 678, DateTimeKind.Local).AddTicks(4636), new DateTime(2020, 5, 24, 16, 39, 38, 868, DateTimeKind.Local).AddTicks(152), 1, 44, "Expedita quos debitis eos ea nulla non earum distinctio. Quia et dolore cupiditate rem quia. Voluptates harum natus quia. Omnis rerum libero soluta dolorem voluptatem dolores quibusdam quos. Qui ad omnis. Ad sint aut sed odit ut et architecto eveniet." },
                    { 138, new DateTime(2020, 9, 24, 22, 14, 18, 787, DateTimeKind.Local).AddTicks(7509), 50, new DateTime(2021, 8, 18, 23, 3, 36, 690, DateTimeKind.Local).AddTicks(6034), new DateTime(2020, 4, 26, 16, 35, 18, 448, DateTimeKind.Local).AddTicks(9466), 2, 24, "Itaque sint excepturi at asperiores. Dolores officia sequi. Autem totam possimus velit. Quibusdam eius vel aliquid voluptas quod." },
                    { 79, new DateTime(2020, 11, 11, 10, 27, 2, 117, DateTimeKind.Local).AddTicks(9552), 98, new DateTime(2021, 8, 7, 5, 14, 11, 68, DateTimeKind.Local).AddTicks(5711), new DateTime(2020, 7, 9, 14, 15, 56, 736, DateTimeKind.Local).AddTicks(2861), 3, 24, "Eum dicta non sequi consectetur voluptatem.\nAtque id odio id voluptatum laudantium aut.\nRecusandae dolores aperiam.\nOccaecati assumenda dolorem eum corporis perspiciatis porro veniam.\nIusto similique optio dolore.\nId ut ad vero quia laboriosam explicabo delectus sed." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 111, new DateTime(2020, 11, 22, 4, 1, 59, 789, DateTimeKind.Local).AddTicks(840), 108, new DateTime(2021, 7, 10, 3, 20, 57, 268, DateTimeKind.Local).AddTicks(3478), new DateTime(2020, 8, 9, 18, 28, 17, 729, DateTimeKind.Local).AddTicks(2686), 5, 59, "Quaerat quis est sit sit voluptatibus reprehenderit et.\nEa sapiente voluptatem id quam quibusdam amet et.\nExpedita tenetur et temporibus asperiores facilis.\nQui ea ratione sunt officiis omnis beatae et et.\nLaborum sint in.\nA sint tempore est voluptatem ipsa." },
                    { 153, new DateTime(2020, 12, 12, 11, 39, 19, 655, DateTimeKind.Local).AddTicks(3295), 45, new DateTime(2021, 11, 15, 14, 38, 44, 911, DateTimeKind.Local).AddTicks(9355), new DateTime(2020, 12, 13, 14, 3, 16, 387, DateTimeKind.Local).AddTicks(5288), 1, 59, "Suscipit qui laboriosam deserunt odit sunt quibusdam officiis." },
                    { 117, new DateTime(2020, 6, 24, 17, 32, 3, 677, DateTimeKind.Local).AddTicks(5617), 50, new DateTime(2021, 5, 15, 2, 9, 44, 465, DateTimeKind.Local).AddTicks(5340), new DateTime(2020, 4, 20, 14, 31, 28, 496, DateTimeKind.Local).AddTicks(1370), 1, 84, "Quia tempora ut deleniti dignissimos itaque." },
                    { 125, new DateTime(2020, 9, 26, 18, 36, 56, 166, DateTimeKind.Local).AddTicks(7374), 28, new DateTime(2022, 1, 3, 17, 25, 53, 843, DateTimeKind.Local).AddTicks(5317), new DateTime(2020, 12, 7, 1, 52, 51, 219, DateTimeKind.Local).AddTicks(7369), 5, 84, "Omnis beatae nihil placeat est.\nIure ut qui.\nEt repellendus eum.\nQuis et laborum minus.\nDolor sed veritatis nulla quo suscipit perspiciatis itaque quis consequatur.\nRepudiandae autem perferendis aliquam provident ad." },
                    { 101, new DateTime(2021, 2, 27, 11, 4, 42, 171, DateTimeKind.Local).AddTicks(6595), 85, new DateTime(2021, 11, 2, 3, 3, 3, 762, DateTimeKind.Local).AddTicks(2749), new DateTime(2020, 5, 25, 17, 42, 46, 593, DateTimeKind.Local).AddTicks(9644), 4, 42, "Debitis enim ut hic sit soluta.\nFugit repellat nemo assumenda voluptate.\nQuo et culpa quo." },
                    { 157, new DateTime(2020, 7, 31, 20, 26, 6, 86, DateTimeKind.Local).AddTicks(51), 109, new DateTime(2022, 2, 23, 5, 49, 40, 83, DateTimeKind.Local).AddTicks(1851), new DateTime(2020, 5, 9, 23, 18, 51, 278, DateTimeKind.Local).AddTicks(720), 1, 42, "Rem aut consequuntur a quod." },
                    { 15, new DateTime(2021, 4, 4, 11, 4, 38, 478, DateTimeKind.Local).AddTicks(5399), 139, new DateTime(2022, 2, 4, 19, 51, 48, 36, DateTimeKind.Local).AddTicks(9539), new DateTime(2021, 1, 22, 11, 12, 0, 126, DateTimeKind.Local).AddTicks(2782), 5, 96, "Fugit voluptas ipsa alias rerum commodi quibusdam. Corporis eveniet reprehenderit sint et voluptatem repellat eos quibusdam omnis. Necessitatibus inventore id." },
                    { 72, new DateTime(2020, 9, 22, 23, 5, 33, 957, DateTimeKind.Local).AddTicks(2773), 146, new DateTime(2021, 5, 14, 15, 53, 32, 110, DateTimeKind.Local).AddTicks(4249), new DateTime(2020, 10, 29, 5, 11, 22, 177, DateTimeKind.Local).AddTicks(7312), 4, 96, "asperiores" },
                    { 124, new DateTime(2021, 3, 26, 16, 37, 50, 939, DateTimeKind.Local).AddTicks(6191), 133, new DateTime(2021, 9, 2, 14, 53, 0, 438, DateTimeKind.Local).AddTicks(8396), new DateTime(2020, 10, 19, 13, 55, 55, 88, DateTimeKind.Local).AddTicks(7164), 2, 96, "Non rerum reiciendis laborum enim ex.\nOdit voluptate dolore quaerat qui.\nDignissimos earum sit." },
                    { 131, new DateTime(2020, 8, 24, 12, 13, 50, 172, DateTimeKind.Local).AddTicks(5648), 2, new DateTime(2021, 9, 22, 0, 9, 34, 505, DateTimeKind.Local).AddTicks(5006), new DateTime(2020, 7, 6, 10, 12, 59, 219, DateTimeKind.Local).AddTicks(4582), 1, 96, "Aut et officia odio mollitia ex dicta." },
                    { 6, new DateTime(2020, 5, 1, 2, 14, 29, 349, DateTimeKind.Local).AddTicks(2217), 78, new DateTime(2021, 5, 25, 18, 38, 13, 337, DateTimeKind.Local).AddTicks(1726), new DateTime(2020, 6, 3, 3, 56, 36, 840, DateTimeKind.Local).AddTicks(5943), 1, 89, "quaerat" },
                    { 28, new DateTime(2020, 11, 21, 21, 32, 23, 450, DateTimeKind.Local).AddTicks(8506), 33, new DateTime(2021, 10, 19, 8, 49, 49, 686, DateTimeKind.Local).AddTicks(1715), new DateTime(2021, 3, 12, 10, 14, 32, 841, DateTimeKind.Local).AddTicks(7423), 4, 89, "Quidem blanditiis vel excepturi deserunt officiis est rerum rerum et." },
                    { 169, new DateTime(2020, 9, 15, 11, 11, 7, 859, DateTimeKind.Local).AddTicks(7417), 148, new DateTime(2021, 11, 9, 14, 52, 53, 50, DateTimeKind.Local).AddTicks(7123), new DateTime(2020, 6, 1, 2, 39, 7, 819, DateTimeKind.Local).AddTicks(4377), 4, 89, "Eveniet hic corrupti nihil odit ut nostrum in corporis.\nAccusamus unde nostrum reiciendis velit incidunt.\nDolores nobis explicabo illum omnis voluptas asperiores hic.\nTemporibus debitis facilis est sunt expedita molestiae quasi numquam nesciunt.\nDucimus quae placeat.\nTemporibus aut aut voluptates expedita voluptatem dolorem." },
                    { 53, new DateTime(2020, 12, 11, 11, 37, 37, 30, DateTimeKind.Local).AddTicks(4129), 97, new DateTime(2021, 8, 14, 12, 6, 20, 914, DateTimeKind.Local).AddTicks(9738), new DateTime(2021, 2, 5, 15, 32, 27, 288, DateTimeKind.Local).AddTicks(8583), 2, 9, "Eaque velit est et itaque qui qui." },
                    { 50, new DateTime(2020, 7, 18, 23, 16, 59, 97, DateTimeKind.Local).AddTicks(1030), 52, new DateTime(2021, 12, 3, 8, 53, 23, 856, DateTimeKind.Local).AddTicks(6689), new DateTime(2020, 12, 13, 19, 44, 49, 653, DateTimeKind.Local).AddTicks(7337), 3, 34, "Aperiam possimus dolores. Tenetur sequi minima quod quis ut. Nulla est deleniti aperiam nisi nihil. Quidem aliquam molestias. Dolore inventore voluptatem aut possimus atque vitae aspernatur voluptatum. Placeat voluptatibus repellat rerum." },
                    { 65, new DateTime(2020, 10, 14, 3, 19, 9, 981, DateTimeKind.Local).AddTicks(3081), 135, new DateTime(2022, 4, 7, 0, 18, 6, 459, DateTimeKind.Local).AddTicks(6659), new DateTime(2021, 3, 4, 10, 58, 24, 290, DateTimeKind.Local).AddTicks(6488), 5, 34, "Beatae eligendi ut sed. Fugiat veniam eos aut. Unde labore ut et. Earum iste fugiat doloribus voluptatibus ut. Voluptatem ullam quisquam quos exercitationem dolorum ab qui et inventore." },
                    { 195, new DateTime(2021, 1, 7, 21, 1, 51, 321, DateTimeKind.Local).AddTicks(2364), 69, new DateTime(2021, 5, 5, 0, 49, 13, 811, DateTimeKind.Local).AddTicks(9664), new DateTime(2021, 2, 6, 0, 2, 33, 878, DateTimeKind.Local).AddTicks(6881), 1, 34, "Ea ipsam et sit neque excepturi tempore dolore doloremque numquam." },
                    { 41, new DateTime(2021, 2, 18, 10, 36, 0, 424, DateTimeKind.Local).AddTicks(267), 132, new DateTime(2022, 1, 5, 19, 16, 21, 213, DateTimeKind.Local).AddTicks(7866), new DateTime(2020, 7, 15, 17, 32, 29, 657, DateTimeKind.Local).AddTicks(8814), 4, 1, "Tenetur velit sunt. Dignissimos quasi occaecati beatae qui unde. Sed itaque incidunt officia dolorum nemo laudantium nostrum. Autem nihil consectetur corporis saepe natus aut delectus quia. Quod odio ut maiores voluptate nobis doloremque cumque." },
                    { 91, new DateTime(2020, 6, 13, 2, 11, 19, 16, DateTimeKind.Local).AddTicks(3888), 81, new DateTime(2021, 10, 14, 18, 20, 30, 426, DateTimeKind.Local).AddTicks(7750), new DateTime(2020, 10, 16, 5, 52, 4, 543, DateTimeKind.Local).AddTicks(6287), 5, 1, "Est odit reprehenderit doloremque nesciunt quaerat. Voluptatem corrupti expedita aliquam illum qui. Sunt maxime velit quasi et corrupti aliquam delectus voluptas." },
                    { 5, new DateTime(2020, 6, 12, 6, 50, 58, 346, DateTimeKind.Local).AddTicks(5803), 116, new DateTime(2021, 9, 1, 18, 17, 30, 181, DateTimeKind.Local).AddTicks(2354), new DateTime(2020, 12, 29, 6, 0, 46, 709, DateTimeKind.Local).AddTicks(5280), 1, 24, "aliquid" },
                    { 70, new DateTime(2020, 11, 24, 23, 33, 6, 427, DateTimeKind.Local).AddTicks(13), 126, new DateTime(2021, 6, 7, 18, 32, 6, 389, DateTimeKind.Local).AddTicks(3748), new DateTime(2021, 2, 23, 0, 49, 50, 972, DateTimeKind.Local).AddTicks(1416), 3, 24, "cumque" },
                    { 129, new DateTime(2021, 1, 21, 6, 27, 19, 439, DateTimeKind.Local).AddTicks(3361), 32, new DateTime(2021, 7, 24, 8, 30, 11, 800, DateTimeKind.Local).AddTicks(7656), new DateTime(2021, 1, 2, 2, 19, 1, 440, DateTimeKind.Local).AddTicks(1965), 4, 24, "Dicta iste voluptas ad.\nSed assumenda totam fuga.\nSint qui quasi natus et suscipit rerum qui vel.\nEum ipsam iusto.\nMagni debitis voluptatibus modi dicta sit libero sint.\nUt doloremque temporibus hic iste." },
                    { 48, new DateTime(2020, 11, 9, 20, 27, 41, 22, DateTimeKind.Local).AddTicks(4214), 132, new DateTime(2021, 10, 25, 13, 21, 13, 150, DateTimeKind.Local).AddTicks(3423), new DateTime(2020, 7, 18, 19, 47, 58, 511, DateTimeKind.Local).AddTicks(251), 3, 49, "Est alias id voluptatem enim perferendis velit eos sed blanditiis. Et omnis voluptatem. Numquam sed excepturi esse." },
                    { 102, new DateTime(2020, 6, 30, 10, 19, 17, 52, DateTimeKind.Local).AddTicks(334), 15, new DateTime(2021, 9, 14, 5, 17, 10, 844, DateTimeKind.Local).AddTicks(6951), new DateTime(2020, 12, 14, 17, 15, 30, 516, DateTimeKind.Local).AddTicks(7114), 1, 49, "omnis" },
                    { 121, new DateTime(2020, 7, 5, 8, 56, 48, 202, DateTimeKind.Local).AddTicks(1372), 98, new DateTime(2021, 5, 19, 5, 57, 58, 266, DateTimeKind.Local).AddTicks(7349), new DateTime(2021, 4, 12, 2, 53, 59, 673, DateTimeKind.Local).AddTicks(9756), 5, 49, "Ut consequatur deserunt amet eum debitis quo.\nEt et delectus maxime qui et dignissimos et et.\nRepudiandae ea tempora tempore repellat aut voluptas explicabo iure." },
                    { 32, new DateTime(2021, 1, 26, 5, 15, 6, 830, DateTimeKind.Local).AddTicks(8789), 134, new DateTime(2021, 10, 1, 19, 17, 32, 138, DateTimeKind.Local).AddTicks(6831), new DateTime(2021, 1, 9, 5, 45, 3, 909, DateTimeKind.Local).AddTicks(53), 3, 71, "Architecto quibusdam culpa aut. Dolorem quis ut sed. Porro ipsa distinctio enim voluptatibus modi. Sapiente rerum laborum cumque." },
                    { 107, new DateTime(2020, 8, 28, 12, 46, 52, 903, DateTimeKind.Local).AddTicks(9022), 118, new DateTime(2021, 9, 27, 13, 18, 22, 901, DateTimeKind.Local).AddTicks(5030), new DateTime(2020, 8, 10, 4, 40, 19, 305, DateTimeKind.Local).AddTicks(4905), 4, 71, "Repellat ab sunt provident." },
                    { 148, new DateTime(2021, 2, 5, 2, 54, 12, 663, DateTimeKind.Local).AddTicks(9595), 128, new DateTime(2022, 3, 13, 20, 12, 17, 696, DateTimeKind.Local).AddTicks(223), new DateTime(2020, 4, 25, 16, 22, 15, 305, DateTimeKind.Local).AddTicks(5393), 2, 71, "Dolorem voluptate enim.\nVelit vel vel sit dolore nihil.\nUnde rerum non modi cum labore dolorem quia.\nVeniam laboriosam ut ut quasi libero vel.\nEx corrupti laboriosam doloribus repellat." },
                    { 160, new DateTime(2020, 8, 28, 22, 44, 51, 366, DateTimeKind.Local).AddTicks(3472), 129, new DateTime(2021, 10, 3, 19, 7, 20, 263, DateTimeKind.Local).AddTicks(6501), new DateTime(2021, 4, 14, 22, 22, 34, 822, DateTimeKind.Local).AddTicks(8848), 3, 71, "impedit" },
                    { 165, new DateTime(2020, 10, 15, 3, 13, 43, 243, DateTimeKind.Local).AddTicks(2509), 82, new DateTime(2021, 8, 20, 15, 26, 38, 82, DateTimeKind.Local).AddTicks(8886), new DateTime(2021, 2, 2, 6, 56, 17, 684, DateTimeKind.Local).AddTicks(2029), 1, 71, "Et minima nesciunt eius voluptas.\nOdio aliquam perferendis tenetur quia.\nReiciendis delectus commodi molestiae porro excepturi.\nModi quas sunt quod quibusdam unde velit dolores.\nAccusamus ea ut ut eos unde adipisci qui dicta non." },
                    { 179, new DateTime(2021, 1, 10, 13, 29, 49, 250, DateTimeKind.Local).AddTicks(8196), 100, new DateTime(2022, 1, 25, 13, 50, 49, 472, DateTimeKind.Local).AddTicks(5159), new DateTime(2020, 8, 3, 14, 40, 27, 627, DateTimeKind.Local).AddTicks(1513), 3, 71, "Omnis pariatur consequatur mollitia amet eos consequuntur autem velit eum." },
                    { 184, new DateTime(2021, 1, 31, 16, 48, 26, 136, DateTimeKind.Local).AddTicks(4984), 18, new DateTime(2021, 6, 9, 18, 50, 59, 102, DateTimeKind.Local).AddTicks(7402), new DateTime(2021, 1, 20, 0, 33, 19, 681, DateTimeKind.Local).AddTicks(6173), 3, 71, "cupiditate" },
                    { 186, new DateTime(2020, 6, 24, 0, 16, 51, 119, DateTimeKind.Local).AddTicks(7463), 90, new DateTime(2021, 12, 5, 22, 48, 6, 895, DateTimeKind.Local).AddTicks(1585), new DateTime(2020, 9, 19, 14, 33, 47, 435, DateTimeKind.Local).AddTicks(9804), 4, 71, "ut" },
                    { 63, new DateTime(2020, 12, 5, 17, 36, 41, 504, DateTimeKind.Local).AddTicks(657), 3, new DateTime(2022, 3, 17, 14, 36, 58, 741, DateTimeKind.Local).AddTicks(6314), new DateTime(2020, 5, 31, 19, 19, 39, 437, DateTimeKind.Local).AddTicks(79), 1, 65, "Voluptas voluptates sed vel eos nihil impedit saepe quibusdam.\nEnim a culpa at quia assumenda iste vitae.\nEt quia neque in dolor consequatur provident et fugiat aut.\nConsequatur amet consequatur aspernatur occaecati saepe molestiae illo adipisci.\nVel in minima aperiam ut ducimus voluptatum hic et.\nConsectetur ut distinctio laborum est dolorem molestias voluptatem sunt id." },
                    { 90, new DateTime(2020, 8, 13, 19, 14, 27, 449, DateTimeKind.Local).AddTicks(5695), 61, new DateTime(2021, 8, 1, 16, 5, 20, 454, DateTimeKind.Local).AddTicks(7499), new DateTime(2020, 11, 26, 8, 43, 0, 650, DateTimeKind.Local).AddTicks(4284), 3, 65, "velit" },
                    { 115, new DateTime(2020, 9, 28, 10, 48, 11, 381, DateTimeKind.Local).AddTicks(1958), 62, new DateTime(2022, 4, 13, 7, 44, 5, 257, DateTimeKind.Local).AddTicks(6869), new DateTime(2020, 6, 30, 15, 1, 49, 965, DateTimeKind.Local).AddTicks(9296), 5, 65, "pariatur" },
                    { 119, new DateTime(2020, 5, 11, 23, 6, 27, 261, DateTimeKind.Local).AddTicks(3341), 79, new DateTime(2021, 8, 20, 22, 58, 57, 222, DateTimeKind.Local).AddTicks(6628), new DateTime(2021, 2, 7, 19, 43, 40, 384, DateTimeKind.Local).AddTicks(8995), 1, 65, "Distinctio pariatur voluptatem explicabo. Consequatur non tenetur hic repudiandae provident sint ut repudiandae harum. Est voluptatibus consequatur sit iure consequatur." },
                    { 2, new DateTime(2020, 5, 22, 10, 20, 9, 471, DateTimeKind.Local).AddTicks(3931), 130, new DateTime(2022, 3, 14, 7, 17, 56, 668, DateTimeKind.Local).AddTicks(8220), new DateTime(2020, 12, 14, 7, 17, 49, 527, DateTimeKind.Local).AddTicks(4375), 3, 20, "Dolore reprehenderit totam." },
                    { 108, new DateTime(2021, 4, 11, 0, 56, 40, 606, DateTimeKind.Local).AddTicks(2880), 135, new DateTime(2022, 3, 17, 15, 27, 50, 716, DateTimeKind.Local).AddTicks(8881), new DateTime(2020, 8, 18, 15, 49, 45, 612, DateTimeKind.Local).AddTicks(4694), 4, 20, "Ut animi vero consectetur aperiam quas est consectetur officiis." },
                    { 168, new DateTime(2020, 12, 23, 15, 29, 33, 406, DateTimeKind.Local).AddTicks(3256), 16, new DateTime(2022, 4, 13, 5, 26, 34, 380, DateTimeKind.Local).AddTicks(1818), new DateTime(2020, 6, 25, 22, 38, 5, 938, DateTimeKind.Local).AddTicks(477), 1, 20, "Omnis est sequi quis deserunt officiis placeat officiis nobis dolore. Sint aut odit non voluptatem voluptatem perferendis quibusdam. Voluptate qui dolor sed." },
                    { 69, new DateTime(2020, 7, 31, 23, 6, 27, 478, DateTimeKind.Local).AddTicks(1859), 144, new DateTime(2021, 5, 30, 17, 41, 37, 966, DateTimeKind.Local).AddTicks(4742), new DateTime(2021, 2, 24, 12, 17, 8, 85, DateTimeKind.Local).AddTicks(1437), 5, 39, "Nam est expedita repellat sint autem magnam deserunt eos. Nihil minima et iusto accusamus fuga illo corporis qui. Quis modi et molestias minus velit." },
                    { 170, new DateTime(2020, 8, 30, 19, 56, 42, 843, DateTimeKind.Local).AddTicks(7035), 20, new DateTime(2022, 1, 15, 9, 48, 33, 702, DateTimeKind.Local).AddTicks(12), new DateTime(2020, 10, 17, 17, 52, 39, 389, DateTimeKind.Local).AddTicks(7697), 3, 39, "nisi" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 82, new DateTime(2020, 5, 1, 11, 16, 45, 30, DateTimeKind.Local).AddTicks(3548), 29, new DateTime(2021, 7, 31, 21, 54, 32, 14, DateTimeKind.Local).AddTicks(456), new DateTime(2020, 9, 15, 19, 20, 52, 11, DateTimeKind.Local).AddTicks(4631), 2, 32, "qui" },
                    { 89, new DateTime(2020, 8, 20, 21, 38, 27, 88, DateTimeKind.Local).AddTicks(7174), 147, new DateTime(2021, 11, 18, 15, 26, 22, 460, DateTimeKind.Local).AddTicks(2555), new DateTime(2020, 10, 21, 13, 54, 37, 701, DateTimeKind.Local).AddTicks(9773), 4, 32, "In quisquam repudiandae vitae incidunt quis perferendis et optio. Molestiae enim ut architecto. Commodi et sunt veritatis sequi quasi neque." },
                    { 134, new DateTime(2020, 10, 6, 19, 9, 49, 881, DateTimeKind.Local).AddTicks(6955), 103, new DateTime(2021, 11, 6, 18, 44, 11, 499, DateTimeKind.Local).AddTicks(4992), new DateTime(2020, 7, 15, 13, 49, 48, 46, DateTimeKind.Local).AddTicks(303), 3, 32, "aliquid" },
                    { 136, new DateTime(2020, 6, 24, 22, 10, 28, 75, DateTimeKind.Local).AddTicks(7466), 148, new DateTime(2021, 9, 14, 11, 18, 6, 557, DateTimeKind.Local).AddTicks(8447), new DateTime(2021, 1, 5, 6, 42, 8, 305, DateTimeKind.Local).AddTicks(6237), 4, 32, "Sunt alias laudantium mollitia iste aperiam ullam dolores ut." },
                    { 27, new DateTime(2020, 7, 14, 7, 14, 44, 741, DateTimeKind.Local).AddTicks(1847), 120, new DateTime(2021, 6, 29, 21, 57, 50, 68, DateTimeKind.Local).AddTicks(5857), new DateTime(2020, 6, 6, 1, 48, 55, 311, DateTimeKind.Local).AddTicks(5492), 5, 71, "Dolorum vel qui rerum modi id nam. Autem praesentium non illo id nobis. Facilis ea est iure dolorem. Dolorem similique eius aliquid aliquid ab quisquam perspiciatis possimus veritatis. Ut sint dolor facilis ut voluptas modi maiores a. Atque repellendus non est." },
                    { 198, new DateTime(2021, 1, 30, 11, 38, 32, 279, DateTimeKind.Local).AddTicks(2635), 9, new DateTime(2021, 6, 10, 9, 11, 19, 706, DateTimeKind.Local).AddTicks(2920), new DateTime(2021, 1, 7, 19, 37, 34, 318, DateTimeKind.Local).AddTicks(1511), 5, 25, "quasi" },
                    { 176, new DateTime(2020, 5, 24, 21, 38, 1, 656, DateTimeKind.Local).AddTicks(8287), 101, new DateTime(2021, 11, 12, 1, 46, 16, 868, DateTimeKind.Local).AddTicks(623), new DateTime(2020, 5, 6, 8, 58, 56, 896, DateTimeKind.Local).AddTicks(423), 1, 25, "Sit at dolores sit consectetur sit dolorum qui." },
                    { 171, new DateTime(2020, 6, 26, 21, 31, 47, 28, DateTimeKind.Local).AddTicks(8674), 103, new DateTime(2021, 8, 13, 8, 0, 40, 297, DateTimeKind.Local).AddTicks(6093), new DateTime(2021, 3, 23, 4, 53, 57, 116, DateTimeKind.Local).AddTicks(6055), 5, 25, "Numquam fuga eius omnis aliquam consectetur dolore sunt itaque. Accusantium ducimus ipsam vitae exercitationem a sapiente. Est eaque deserunt facere non. Officiis provident unde. Sint enim aspernatur eaque voluptate qui eligendi doloremque." },
                    { 30, new DateTime(2021, 4, 11, 5, 10, 29, 486, DateTimeKind.Local).AddTicks(8907), 59, new DateTime(2022, 2, 26, 19, 40, 23, 73, DateTimeKind.Local).AddTicks(1820), new DateTime(2021, 1, 14, 14, 1, 11, 708, DateTimeKind.Local).AddTicks(2400), 2, 8, "Aut voluptas fugiat quo quia aliquid ullam." },
                    { 67, new DateTime(2021, 1, 22, 22, 10, 43, 473, DateTimeKind.Local).AddTicks(7393), 134, new DateTime(2021, 6, 19, 19, 54, 47, 291, DateTimeKind.Local).AddTicks(8292), new DateTime(2020, 11, 30, 7, 24, 18, 945, DateTimeKind.Local).AddTicks(8991), 3, 8, "Accusamus et fugiat." },
                    { 146, new DateTime(2021, 1, 23, 1, 40, 7, 866, DateTimeKind.Local).AddTicks(6457), 120, new DateTime(2021, 9, 11, 12, 50, 26, 870, DateTimeKind.Local).AddTicks(1257), new DateTime(2021, 1, 31, 1, 39, 59, 970, DateTimeKind.Local).AddTicks(510), 5, 8, "Veritatis velit rerum est iste qui dolore ab in recusandae.\nAccusantium et est temporibus quod aperiam accusamus vero.\nIpsa quia voluptas dolorem similique excepturi doloremque eos et.\nQuia sed incidunt accusantium veniam ut.\nSint quis totam delectus.\nRepellendus quo excepturi quas quo doloremque adipisci." },
                    { 189, new DateTime(2020, 4, 30, 13, 5, 50, 838, DateTimeKind.Local).AddTicks(3882), 128, new DateTime(2021, 9, 27, 22, 44, 8, 732, DateTimeKind.Local).AddTicks(8861), new DateTime(2020, 8, 4, 5, 18, 44, 427, DateTimeKind.Local).AddTicks(6509), 4, 8, "nobis" },
                    { 191, new DateTime(2020, 5, 21, 6, 10, 16, 992, DateTimeKind.Local).AddTicks(3415), 40, new DateTime(2021, 11, 21, 9, 34, 15, 494, DateTimeKind.Local).AddTicks(7497), new DateTime(2020, 7, 12, 1, 33, 56, 85, DateTimeKind.Local).AddTicks(5313), 1, 8, "Consequatur et sed ea et sit. Consequatur asperiores eum omnis laborum est consequuntur mollitia. Nihil officiis incidunt et iusto facilis aspernatur voluptas. Doloremque sint adipisci id amet et molestiae. Expedita sequi ullam et enim vel earum." },
                    { 66, new DateTime(2020, 9, 22, 22, 59, 59, 695, DateTimeKind.Local).AddTicks(259), 119, new DateTime(2021, 12, 19, 19, 1, 15, 281, DateTimeKind.Local).AddTicks(297), new DateTime(2021, 3, 12, 1, 12, 50, 44, DateTimeKind.Local).AddTicks(8813), 1, 62, "Et autem ut.\nNeque qui et.\nVel fuga accusantium consequatur quidem ipsam qui libero ab.\nEst ut distinctio sunt eum quo corrupti id nihil.\nNon sint error quaerat laboriosam voluptates distinctio qui facere quaerat." },
                    { 154, new DateTime(2021, 3, 10, 1, 58, 30, 751, DateTimeKind.Local).AddTicks(3744), 139, new DateTime(2021, 8, 1, 8, 30, 45, 874, DateTimeKind.Local).AddTicks(8721), new DateTime(2021, 2, 5, 13, 28, 11, 23, DateTimeKind.Local).AddTicks(4681), 5, 62, "Doloribus aperiam distinctio vitae deserunt voluptatem." },
                    { 193, new DateTime(2020, 7, 15, 11, 9, 1, 776, DateTimeKind.Local).AddTicks(3170), 85, new DateTime(2021, 5, 31, 10, 34, 51, 514, DateTimeKind.Local).AddTicks(6605), new DateTime(2021, 1, 6, 23, 45, 17, 657, DateTimeKind.Local).AddTicks(7596), 3, 62, "Quia aut aperiam aut ullam sunt. Inventore quis sapiente tempore ipsa fugiat. Sit deserunt quibusdam quia. Rerum atque voluptas temporibus quo maiores. Omnis consequatur ipsa consequuntur qui repellat autem et asperiores veritatis. Maxime quisquam quae aut vel autem." },
                    { 96, new DateTime(2020, 7, 3, 12, 50, 55, 165, DateTimeKind.Local).AddTicks(660), 124, new DateTime(2021, 6, 20, 23, 33, 7, 941, DateTimeKind.Local).AddTicks(2398), new DateTime(2020, 11, 1, 12, 56, 20, 619, DateTimeKind.Local).AddTicks(4700), 5, 64, "Quam aut consequatur nam voluptatem architecto minima vero.\nRerum qui est non soluta placeat cumque maxime.\nAliquam maiores impedit fugit praesentium.\nRerum similique eaque occaecati libero aliquid ea ut." },
                    { 19, new DateTime(2020, 8, 28, 22, 5, 58, 76, DateTimeKind.Local).AddTicks(5023), 106, new DateTime(2021, 8, 8, 1, 57, 46, 118, DateTimeKind.Local).AddTicks(8396), new DateTime(2020, 4, 27, 2, 34, 18, 935, DateTimeKind.Local).AddTicks(7911), 4, 50, "Id repudiandae sint veniam nihil quia et nostrum." },
                    { 7, new DateTime(2021, 2, 20, 10, 43, 17, 573, DateTimeKind.Local).AddTicks(3293), 32, new DateTime(2021, 4, 17, 21, 57, 19, 411, DateTimeKind.Local).AddTicks(2474), new DateTime(2021, 1, 26, 1, 27, 8, 986, DateTimeKind.Local).AddTicks(2550), 4, 3, "Temporibus repellendus nam consequuntur." },
                    { 123, new DateTime(2021, 3, 15, 0, 30, 1, 821, DateTimeKind.Local).AddTicks(4981), 100, new DateTime(2022, 1, 25, 1, 34, 59, 850, DateTimeKind.Local).AddTicks(7751), new DateTime(2020, 12, 31, 11, 56, 20, 503, DateTimeKind.Local).AddTicks(7377), 3, 50, "Odio voluptatum est officiis porro qui dolor ipsa maiores." },
                    { 152, new DateTime(2020, 7, 5, 12, 27, 36, 357, DateTimeKind.Local).AddTicks(3615), 30, new DateTime(2021, 9, 19, 18, 8, 51, 991, DateTimeKind.Local).AddTicks(1560), new DateTime(2021, 1, 24, 2, 15, 48, 251, DateTimeKind.Local).AddTicks(426), 2, 50, "Ipsam eum rem voluptatum aut suscipit totam nisi est velit.\nOdio velit mollitia quia.\nEt iusto repudiandae iure corrupti nulla.\nIusto illum voluptatem maxime voluptatem et sed sed ullam." },
                    { 105, new DateTime(2021, 3, 27, 15, 55, 26, 983, DateTimeKind.Local).AddTicks(7945), 81, new DateTime(2021, 8, 13, 6, 47, 34, 695, DateTimeKind.Local).AddTicks(578), new DateTime(2020, 4, 16, 21, 53, 35, 479, DateTimeKind.Local).AddTicks(4037), 5, 86, "Error delectus beatae magnam accusantium.\nEt commodi molestias illum ad eum dolores et magni quas.\nExcepturi qui saepe soluta et et facilis distinctio.\nQui incidunt ducimus debitis perspiciatis nihil quod.\nMaiores id quia delectus natus voluptatem ea accusamus non." },
                    { 18, new DateTime(2020, 7, 8, 3, 42, 16, 728, DateTimeKind.Local).AddTicks(6124), 141, new DateTime(2021, 10, 23, 15, 6, 10, 406, DateTimeKind.Local).AddTicks(7323), new DateTime(2020, 4, 21, 20, 6, 3, 400, DateTimeKind.Local).AddTicks(8754), 4, 36, "Et rerum deserunt dolorem ad." },
                    { 20, new DateTime(2020, 12, 31, 0, 1, 21, 815, DateTimeKind.Local).AddTicks(1668), 113, new DateTime(2021, 9, 9, 17, 26, 36, 420, DateTimeKind.Local).AddTicks(3575), new DateTime(2021, 1, 6, 23, 1, 28, 579, DateTimeKind.Local).AddTicks(8204), 1, 36, "Facere necessitatibus rerum placeat quo suscipit.\nA earum non iusto placeat tenetur nesciunt.\nLaborum explicabo accusantium consequuntur." },
                    { 161, new DateTime(2020, 12, 26, 4, 6, 8, 62, DateTimeKind.Local).AddTicks(5466), 105, new DateTime(2021, 4, 18, 23, 12, 21, 31, DateTimeKind.Local).AddTicks(4990), new DateTime(2021, 1, 12, 7, 47, 16, 40, DateTimeKind.Local).AddTicks(9213), 5, 36, "Nulla voluptates dolorem et deleniti animi quas." },
                    { 12, new DateTime(2020, 6, 17, 22, 30, 26, 402, DateTimeKind.Local).AddTicks(9661), 19, new DateTime(2021, 10, 17, 20, 25, 56, 894, DateTimeKind.Local).AddTicks(1374), new DateTime(2020, 9, 11, 14, 27, 55, 365, DateTimeKind.Local).AddTicks(9823), 5, 35, "Exercitationem optio molestiae delectus assumenda aliquid suscipit eum ipsum quia.\nVoluptas sed est officia voluptatem.\nSit accusamus consequuntur ab et rerum sed.\nVel quia optio eveniet et ut.\nRepellendus omnis ut dignissimos.\nEsse optio commodi ut eum ad ab ducimus impedit ex." },
                    { 94, new DateTime(2020, 5, 19, 9, 3, 13, 751, DateTimeKind.Local).AddTicks(6603), 9, new DateTime(2021, 6, 16, 15, 36, 4, 83, DateTimeKind.Local).AddTicks(6570), new DateTime(2020, 6, 24, 21, 18, 31, 383, DateTimeKind.Local).AddTicks(5603), 5, 35, "et" },
                    { 143, new DateTime(2021, 1, 18, 16, 0, 46, 80, DateTimeKind.Local).AddTicks(1249), 149, new DateTime(2022, 2, 16, 3, 58, 4, 397, DateTimeKind.Local).AddTicks(6643), new DateTime(2020, 6, 24, 19, 23, 38, 319, DateTimeKind.Local).AddTicks(1201), 5, 35, "Id optio excepturi tempore." },
                    { 185, new DateTime(2020, 10, 22, 20, 46, 50, 460, DateTimeKind.Local).AddTicks(3732), 112, new DateTime(2021, 7, 22, 1, 23, 54, 504, DateTimeKind.Local).AddTicks(4356), new DateTime(2021, 4, 14, 4, 25, 34, 828, DateTimeKind.Local).AddTicks(542), 5, 35, "Soluta voluptas et et optio doloribus.\nNisi ut explicabo molestias aut animi rem.\nPerferendis ipsam et aut ut aut.\nTemporibus quis et voluptatem ut.\nIpsa ducimus dolores inventore vero debitis ea." },
                    { 116, new DateTime(2021, 1, 20, 21, 34, 48, 609, DateTimeKind.Local).AddTicks(2112), 13, new DateTime(2021, 6, 16, 13, 13, 51, 427, DateTimeKind.Local).AddTicks(6759), new DateTime(2020, 12, 3, 11, 44, 32, 704, DateTimeKind.Local).AddTicks(7755), 3, 25, "voluptatem" },
                    { 130, new DateTime(2020, 7, 23, 5, 26, 40, 77, DateTimeKind.Local).AddTicks(6837), 108, new DateTime(2022, 2, 12, 16, 19, 59, 432, DateTimeKind.Local).AddTicks(574), new DateTime(2020, 7, 25, 11, 50, 55, 239, DateTimeKind.Local).AddTicks(9523), 5, 50, "Rerum odio aut eum molestias aut et vel.\nSed voluptatem qui quia omnis unde eum id nesciunt.\nLaudantium ipsum non aut iure iure voluptates.\nOmnis ipsum asperiores nobis ratione dolor quia.\nDolor aut consectetur nesciunt aperiam.\nDicta quaerat libero quibusdam velit voluptates." },
                    { 172, new DateTime(2021, 2, 12, 1, 16, 30, 552, DateTimeKind.Local).AddTicks(8350), 149, new DateTime(2021, 10, 12, 15, 3, 21, 698, DateTimeKind.Local).AddTicks(4155), new DateTime(2020, 8, 14, 16, 37, 12, 780, DateTimeKind.Local).AddTicks(4449), 1, 3, "Saepe enim voluptate. Ipsum sint aut voluptatibus expedita minima. Velit dolor necessitatibus quisquam rerum unde." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_CityId",
                table: "CarServices",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarServices_OwnerId",
                table: "CarServices",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryId",
                table: "Cities",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Engines_FuelTypeId",
                table: "Engines",
                column: "FuelTypeId");

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
                name: "IX_Models_EngineId",
                table: "Models",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerId",
                table: "Models",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_CarServiceId",
                table: "ServiceRequest",
                column: "CarServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_StatusId",
                table: "ServiceRequest",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceRequest_UserCarId",
                table: "ServiceRequest",
                column: "UserCarId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCars_CarId",
                table: "UserCars",
                column: "CarId");

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
                name: "Models");

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
