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
                    { 1, "Belarus" },
                    { 130, "Guyana" },
                    { 128, "Afghanistan" },
                    { 127, "Mayotte" },
                    { 126, "Guatemala" },
                    { 124, "Montserrat" },
                    { 123, "New Caledonia" },
                    { 122, "Switzerland" },
                    { 121, "Iceland" },
                    { 118, "Norway" },
                    { 117, "Argentina" },
                    { 116, "Burkina Faso" },
                    { 115, "Ethiopia" },
                    { 114, "Israel" },
                    { 113, "Honduras" },
                    { 110, "United States Minor Outlying Islands" },
                    { 109, "Solomon Islands" },
                    { 108, "Netherlands Antilles" },
                    { 80, "Anguilla" },
                    { 81, "Mauritius" },
                    { 82, "Costa Rica" },
                    { 85, "Paraguay" },
                    { 86, "Slovakia (Slovak Republic)" },
                    { 88, "Swaziland" },
                    { 131, "Pakistan" },
                    { 91, "Singapore" },
                    { 96, "Vietnam" },
                    { 97, "Japan" },
                    { 100, "Tunisia" },
                    { 101, "Venezuela" },
                    { 102, "Netherlands" },
                    { 107, "Kiribati" },
                    { 93, "Greece" },
                    { 79, "Papua New Guinea" },
                    { 133, "Isle of Man" },
                    { 136, "United Arab Emirates" },
                    { 199, "Lebanon" },
                    { 198, "Mongolia" },
                    { 192, "Mexico" },
                    { 191, "United Kingdom" },
                    { 183, "Zambia" },
                    { 182, "Northern Mariana Islands" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 181, "Fiji" },
                    { 177, "South Africa" },
                    { 174, "Antarctica (the territory South of 60 deg S)" },
                    { 172, "Guernsey" },
                    { 171, "Armenia" },
                    { 169, "Guinea-Bissau" },
                    { 168, "Mozambique" },
                    { 166, "Holy See (Vatican City State)" },
                    { 165, "Faroe Islands" },
                    { 164, "Jordan" },
                    { 163, "Finland" },
                    { 137, "Benin" },
                    { 140, "Turks and Caicos Islands" },
                    { 141, "Guam" },
                    { 142, "Congo" },
                    { 143, "Antigua and Barbuda" },
                    { 144, "Saint Pierre and Miquelon" },
                    { 135, "Bahamas" },
                    { 145, "Aruba" },
                    { 149, "Albania" },
                    { 154, "Timor-Leste" },
                    { 155, "Lithuania" },
                    { 156, "Bolivia" },
                    { 157, "Zimbabwe" },
                    { 158, "Macao" },
                    { 147, "Bangladesh" },
                    { 77, "Andorra" },
                    { 84, "Niue" },
                    { 75, "Greenland" },
                    { 34, "San Marino" },
                    { 33, "Algeria" },
                    { 76, "Botswana" },
                    { 31, "Marshall Islands" },
                    { 29, "Azerbaijan" },
                    { 28, "Ukraine" },
                    { 27, "Saudi Arabia" },
                    { 26, "Maldives" },
                    { 25, "Poland" },
                    { 24, "Somalia" },
                    { 23, "Denmark" },
                    { 22, "Dominica" },
                    { 21, "Taiwan" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 20, "Puerto Rico" },
                    { 19, "Montenegro" },
                    { 18, "Hungary" },
                    { 17, "Peru" },
                    { 2, "Indonesia" },
                    { 3, "Tonga" },
                    { 4, "Central African Republic" },
                    { 5, "Haiti" },
                    { 6, "Brunei Darussalam" },
                    { 7, "Guadeloupe" },
                    { 35, "Pitcairn Islands" },
                    { 8, "Heard Island and McDonald Islands" },
                    { 10, "Samoa" },
                    { 11, "Uzbekistan" },
                    { 12, "Reunion" },
                    { 13, "Brazil" },
                    { 14, "Chad" },
                    { 15, "Suriname" },
                    { 9, "American Samoa" },
                    { 36, "Wallis and Futuna" },
                    { 32, "Russian Federation" },
                    { 38, "Serbia" },
                    { 74, "France" },
                    { 73, "Falkland Islands (Malvinas)" },
                    { 72, "Trinidad and Tobago" },
                    { 71, "Slovenia" },
                    { 70, "Syrian Arab Republic" },
                    { 69, "Democratic People's Republic of Korea" },
                    { 67, "Portugal" },
                    { 66, "Cyprus" },
                    { 64, "Nicaragua" },
                    { 37, "Malaysia" },
                    { 62, "Iran" },
                    { 61, "Grenada" },
                    { 60, "Spain" },
                    { 59, "Kenya" },
                    { 58, "Barbados" },
                    { 63, "Germany" },
                    { 56, "Sudan" },
                    { 39, "Bouvet Island (Bouvetoya)" },
                    { 40, "French Polynesia" },
                    { 57, "China" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 43, "Cuba" },
                    { 44, "Luxembourg" },
                    { 46, "Palestinian Territory" },
                    { 47, "Virgin Islands, British" },
                    { 42, "Saint Martin" },
                    { 49, "Mauritania" },
                    { 50, "India" },
                    { 51, "Palau" },
                    { 52, "Rwanda" },
                    { 53, "Turkmenistan" },
                    { 54, "Cape Verde" },
                    { 48, "Moldova" }
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
                    { 56, 1, "South Kianamouth" },
                    { 255, 108, "Mertzview" },
                    { 251, 108, "East Cullen" },
                    { 30, 108, "West Benjamin" },
                    { 246, 107, "South Esmeralda" },
                    { 243, 107, "New Joliemouth" },
                    { 223, 107, "Port Madelynshire" },
                    { 125, 107, "Bednarchester" },
                    { 219, 102, "Steuberberg" },
                    { 185, 101, "South Margehaven" },
                    { 132, 101, "Solonland" },
                    { 100, 101, "Lake Sheila" },
                    { 92, 101, "North Estafort" },
                    { 53, 101, "East Adell" },
                    { 2, 101, "Marvinville" },
                    { 69, 100, "Susanstad" },
                    { 220, 97, "Breannaburgh" },
                    { 166, 97, "Lake Graciela" },
                    { 71, 109, "South Kendra" },
                    { 145, 109, "Abigayleton" },
                    { 58, 110, "Bechtelartown" },
                    { 170, 110, "Thaddeusborough" },
                    { 50, 122, "Port Amberburgh" },
                    { 182, 121, "New Clyde" },
                    { 299, 118, "West Bennettland" },
                    { 181, 118, "Lake Giahaven" },
                    { 84, 118, "West Reymundo" },
                    { 215, 117, "South Emeliebury" },
                    { 294, 116, "South Jeromymouth" },
                    { 148, 116, "Boehmview" },
                    { 160, 96, "Gilbertville" },
                    { 44, 116, "Aglaeview" },
                    { 1, 116, "South Kamille" },
                    { 68, 115, "East Marinamouth" },
                    { 63, 115, "Ortizton" },
                    { 207, 114, "Romagueraland" },
                    { 162, 114, "Port Gladyce" },
                    { 140, 113, "North Stuartborough" },
                    { 136, 113, "Aidaburgh" },
                    { 278, 110, "Aylinmouth" },
                    { 37, 116, "East Kipberg" },
                    { 157, 122, "North Savanna" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 298, 93, "Port Samanthatown" },
                    { 21, 93, "Domenickfort" },
                    { 204, 75, "Lake Jennifer" },
                    { 174, 75, "Lake Rosamondland" },
                    { 95, 75, "Bauchfurt" },
                    { 60, 75, "Ernserport" },
                    { 260, 74, "Port Nadiamouth" },
                    { 230, 74, "Abshireshire" },
                    { 209, 74, "South Joaquin" },
                    { 191, 73, "Ashleighchester" },
                    { 33, 73, "Cielobury" },
                    { 226, 72, "Lilianebury" },
                    { 231, 71, "Port Agustinmouth" },
                    { 227, 70, "Lavadafort" },
                    { 38, 69, "West Cassie" },
                    { 27, 69, "Huelschester" },
                    { 176, 66, "Jackhaven" },
                    { 163, 66, "Koeppport" },
                    { 129, 66, "South Guiseppe" },
                    { 109, 76, "New Adeline" },
                    { 188, 76, "Carterhaven" },
                    { 104, 77, "Magnusport" },
                    { 283, 77, "Houstonhaven" },
                    { 97, 91, "South Giles" },
                    { 225, 88, "Rickville" },
                    { 161, 88, "Deborahchester" },
                    { 113, 88, "Port Fridahaven" },
                    { 216, 86, "Maggiechester" },
                    { 4, 85, "VonRuedenshire" },
                    { 34, 84, "East Quintenton" },
                    { 152, 82, "West Adonisborough" },
                    { 168, 93, "Thielton" },
                    { 138, 82, "Kennithside" },
                    { 179, 81, "South Fatimafurt" },
                    { 24, 81, "Naderton" },
                    { 213, 80, "Ottilieside" },
                    { 154, 80, "Port Berylside" },
                    { 142, 80, "Port Johnberg" },
                    { 137, 80, "East Beau" },
                    { 121, 80, "Boganfort" },
                    { 291, 79, "New Stephonland" },
                    { 197, 81, "North Marlonborough" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 293, 122, "Antoninachester" },
                    { 262, 123, "West Tanner" },
                    { 164, 124, "East Jayne" },
                    { 80, 166, "South Savanahland" },
                    { 234, 165, "Howardburgh" },
                    { 245, 164, "Terryfurt" },
                    { 108, 164, "Destinimouth" },
                    { 51, 164, "West Porter" },
                    { 123, 163, "East Bailey" },
                    { 64, 163, "Smithamtown" },
                    { 48, 163, "South Elliottville" },
                    { 237, 157, "Pathaven" },
                    { 218, 157, "Johnsview" },
                    { 103, 157, "Rohanton" },
                    { 19, 157, "Lake Kurtis" },
                    { 229, 156, "Runolfssonbury" },
                    { 224, 156, "East Milford" },
                    { 177, 156, "Caseyside" },
                    { 264, 155, "Larsonburgh" },
                    { 263, 155, "Stantonfurt" },
                    { 82, 166, "South Tillmanhaven" },
                    { 93, 172, "West Anderson" },
                    { 29, 174, "South Duncan" },
                    { 201, 174, "East Donnastad" },
                    { 259, 199, "Gerholdland" },
                    { 133, 199, "South Eliseoview" },
                    { 57, 199, "Murrayhaven" },
                    { 122, 192, "Calistabury" },
                    { 35, 192, "Metzborough" },
                    { 210, 191, "East Eleonoretown" },
                    { 167, 191, "East Mandyshire" },
                    { 165, 191, "Rosendoton" },
                    { 149, 155, "Fritschmouth" },
                    { 78, 191, "Deonteland" },
                    { 66, 183, "Cartershire" },
                    { 240, 182, "North Carlotta" },
                    { 127, 182, "Willtown" },
                    { 111, 182, "North Zoieberg" },
                    { 249, 181, "Lake Blaze" },
                    { 124, 181, "Marlinport" },
                    { 45, 181, "Emmahaven" },
                    { 198, 177, "North Litzy" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 102, 183, "South Janisbury" },
                    { 28, 155, "South Brittanyside" },
                    { 297, 154, "Erdmanland" },
                    { 273, 149, "Bednarhaven" },
                    { 206, 133, "Lavadaville" },
                    { 43, 133, "South Rick" },
                    { 112, 131, "New Ashlynnberg" },
                    { 16, 131, "Ahmadtown" },
                    { 261, 130, "South Avisland" },
                    { 258, 130, "Willmsville" },
                    { 212, 130, "Kubmouth" },
                    { 221, 128, "Corkeryfort" },
                    { 232, 133, "South Malloryport" },
                    { 75, 128, "Port Quincy" },
                    { 31, 127, "Elisabethview" },
                    { 10, 127, "West Morganhaven" },
                    { 285, 126, "West Steveberg" },
                    { 274, 126, "Ebertshire" },
                    { 242, 126, "Savionbury" },
                    { 99, 126, "Elwynmouth" },
                    { 77, 126, "North Dustyburgh" },
                    { 290, 124, "West Allanbury" },
                    { 205, 127, "New Napoleonhaven" },
                    { 79, 66, "Hendersonmouth" },
                    { 275, 133, "Ariellemouth" },
                    { 241, 135, "South Biankashire" },
                    { 222, 147, "Wilberfort" },
                    { 288, 145, "New Beaulah" },
                    { 236, 145, "East Trever" },
                    { 169, 145, "Kovacekborough" },
                    { 98, 145, "Port Neilburgh" },
                    { 146, 144, "Jacobsside" },
                    { 47, 144, "Emiefurt" },
                    { 9, 144, "Port Grayce" },
                    { 187, 135, "Schroederchester" },
                    { 151, 143, "North Dion" },
                    { 11, 143, "New Virginiafurt" },
                    { 281, 142, "Denesikfort" },
                    { 96, 140, "Stiedemannberg" },
                    { 7, 140, "South Elsie" },
                    { 196, 137, "West Myah" },
                    { 114, 137, "Jolieshire" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 106, 137, "New Letha" },
                    { 18, 137, "North Lurabury" },
                    { 73, 143, "Horaceville" },
                    { 59, 66, "New Stellafort" },
                    { 203, 108, "East Freddie" },
                    { 280, 64, "Wolfside" },
                    { 265, 29, "New Sydneyfurt" },
                    { 42, 29, "Cummingsfurt" },
                    { 287, 28, "Tristinhaven" },
                    { 173, 28, "Paulborough" },
                    { 70, 28, "East Pinkmouth" },
                    { 233, 26, "West Andytown" },
                    { 194, 25, "South Aminashire" },
                    { 55, 25, "Bartonbury" },
                    { 12, 25, "Brauliohaven" },
                    { 20, 24, "Port Calemouth" },
                    { 110, 23, "North Terrell" },
                    { 147, 22, "Chelsieside" },
                    { 119, 22, "Leximouth" },
                    { 94, 22, "Port Mckenzie" },
                    { 36, 22, "Selenamouth" },
                    { 289, 29, "Port Perry" },
                    { 120, 31, "Abbytown" },
                    { 131, 31, "Port Elmiraside" },
                    { 150, 1, "Wittingville" },
                    { 25, 40, "Moniquemouth" },
                    { 247, 39, "Port Reymundo" },
                    { 178, 39, "Reichertborough" },
                    { 153, 39, "Felipeside" },
                    { 118, 38, "Aldaton" },
                    { 72, 38, "Lake Kathleenshire" },
                    { 143, 37, "Minatown" },
                    { 17, 22, "South Brodyview" },
                    { 286, 35, "Mckenzieburgh" },
                    { 105, 35, "Leolaside" },
                    { 8, 35, "East Einar" },
                    { 269, 34, "East Diana" },
                    { 254, 34, "Macyland" },
                    { 134, 34, "South Theresia" },
                    { 128, 34, "Framifort" },
                    { 62, 34, "West Lavadaville" },
                    { 190, 35, "Cyrilfurt" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 268, 21, "Stehrfurt" },
                    { 250, 21, "Port Tellyview" },
                    { 211, 21, "Generalmouth" },
                    { 65, 8, "Wintheiserhaven" },
                    { 23, 8, "Ezraside" },
                    { 300, 7, "Norvalton" },
                    { 228, 7, "Mantebury" },
                    { 189, 7, "Janessamouth" },
                    { 52, 7, "Laurencechester" },
                    { 26, 6, "South Jalonchester" },
                    { 208, 10, "Laceyfurt" },
                    { 199, 5, "Buckridgeberg" },
                    { 276, 2, "Wilfridshire" },
                    { 86, 2, "North Rickieburgh" },
                    { 277, 1, "Jordiborough" },
                    { 252, 1, "Port Asaport" },
                    { 239, 1, "Mitchellstad" },
                    { 217, 1, "Goodwinshire" },
                    { 81, 1, "North Jalonfort" },
                    { 135, 4, "Cummingsborough" },
                    { 180, 40, "Lesliemouth" },
                    { 267, 10, "South Camryn" },
                    { 139, 12, "New Elisashire" },
                    { 175, 21, "East Graycefurt" },
                    { 83, 20, "Jacklynhaven" },
                    { 54, 20, "New Blaze" },
                    { 295, 19, "Ariannaton" },
                    { 3, 19, "Hackettburgh" },
                    { 271, 18, "Hegmannton" },
                    { 266, 18, "North Greyson" },
                    { 116, 12, "East Wilburn" },
                    { 89, 18, "Lake Humbertoland" },
                    { 40, 15, "West Cassandre" },
                    { 41, 66, "Eastermouth" },
                    { 253, 13, "East Emmettland" },
                    { 159, 13, "Port Brice" },
                    { 130, 13, "South Price" },
                    { 158, 12, "Lake Rey" },
                    { 155, 12, "Lake Kody" },
                    { 13, 17, "North Kory" },
                    { 183, 40, "East Kaitlynstad" },
                    { 193, 33, "West Alfonzostad" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 85, 1, "New Kallie" },
                    { 144, 46, "New Kattie" },
                    { 186, 46, "Spencerchester" },
                    { 88, 53, "Metzstad" },
                    { 192, 46, "South Caleb" },
                    { 279, 52, "Port Erlingmouth" },
                    { 141, 51, "Larkinfort" },
                    { 238, 62, "Rickiechester" },
                    { 87, 62, "Sheaberg" },
                    { 6, 62, "Jeremyborough" },
                    { 32, 51, "North Juliana" },
                    { 76, 46, "Hannahland" },
                    { 195, 46, "Hudsonshire" },
                    { 257, 54, "Jacobsonmouth" },
                    { 202, 50, "North Josiah" },
                    { 46, 47, "Port Theronton" },
                    { 156, 50, "Kathleenberg" },
                    { 74, 49, "Kertzmannton" },
                    { 39, 48, "Crooksburgh" },
                    { 49, 49, "New Allenchester" },
                    { 115, 48, "Gorczanymouth" },
                    { 272, 48, "New Monica" },
                    { 61, 61, "Wisozkhaven" },
                    { 235, 46, "Port Garret" },
                    { 90, 53, "Schillerchester" },
                    { 214, 60, "New Margret" },
                    { 172, 63, "Burnicebury" },
                    { 107, 64, "New Madalynland" },
                    { 14, 42, "Lake Brookeland" },
                    { 67, 64, "North Daleburgh" },
                    { 22, 64, "Zacktown" },
                    { 296, 53, "Rogahnfurt" },
                    { 15, 43, "East Gerda" },
                    { 91, 43, "South Muriel" },
                    { 117, 43, "Kovacektown" },
                    { 284, 53, "Maceytown" },
                    { 256, 53, "New Foster" },
                    { 248, 63, "East Randi" },
                    { 5, 58, "Lake Adan" },
                    { 126, 43, "South Lelandside" },
                    { 244, 63, "Joyport" },
                    { 184, 63, "Leschberg" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 292, 44, "West Herta" },
                    { 171, 59, "Lake Russelberg" },
                    { 270, 44, "Port Dominicview" },
                    { 101, 44, "East Deja" },
                    { 282, 44, "South Vicenta" },
                    { 200, 59, "New Greggfurt" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 78, 1838, 4, 185 },
                    { 8, 1415, 2, 643 },
                    { 9, 1182, 2, 203 },
                    { 92, 1358, 1, 406 },
                    { 18, 2444, 2, 503 },
                    { 76, 2663, 4, 692 },
                    { 14, 1691, 2, 656 },
                    { 88, 2687, 4, 155 },
                    { 2, 1007, 2, 453 },
                    { 11, 2342, 2, 664 },
                    { 12, 2288, 2, 556 },
                    { 49, 2804, 1, 160 },
                    { 87, 2556, 1, 142 },
                    { 4, 1973, 1, 388 },
                    { 96, 2318, 4, 243 },
                    { 93, 2944, 4, 269 },
                    { 7, 1886, 1, 430 },
                    { 10, 1957, 1, 676 },
                    { 13, 2521, 1, 279 },
                    { 17, 1935, 1, 637 },
                    { 24, 2091, 1, 378 },
                    { 26, 2632, 1, 369 },
                    { 28, 2107, 1, 106 },
                    { 30, 1185, 1, 498 },
                    { 37, 2510, 1, 199 },
                    { 41, 1546, 1, 507 },
                    { 91, 2487, 4, 424 },
                    { 42, 2251, 1, 331 },
                    { 44, 1673, 1, 256 },
                    { 46, 2145, 1, 414 },
                    { 54, 1475, 1, 236 },
                    { 64, 2021, 1, 373 },
                    { 68, 2681, 1, 623 },
                    { 90, 2674, 4, 326 },
                    { 72, 1504, 1, 188 },
                    { 82, 1419, 1, 320 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 83, 1871, 1, 280 },
                    { 84, 2259, 1, 533 },
                    { 89, 2754, 1, 535 },
                    { 66, 2763, 4, 638 },
                    { 57, 2520, 4, 652 },
                    { 19, 2963, 2, 492 },
                    { 81, 2790, 2, 345 },
                    { 15, 2520, 4, 506 },
                    { 5, 2080, 4, 395 },
                    { 85, 1362, 2, 213 },
                    { 95, 2022, 2, 304 },
                    { 1, 2722, 4, 215 },
                    { 99, 1853, 2, 130 },
                    { 3, 1236, 3, 591 },
                    { 100, 1798, 3, 300 },
                    { 6, 1446, 3, 395 },
                    { 22, 1987, 3, 590 },
                    { 23, 2543, 3, 638 },
                    { 25, 2354, 3, 158 },
                    { 36, 1066, 3, 127 },
                    { 39, 1984, 3, 382 },
                    { 94, 1783, 3, 337 },
                    { 86, 1182, 3, 309 },
                    { 51, 2317, 3, 558 },
                    { 53, 1235, 3, 343 },
                    { 58, 2078, 3, 194 },
                    { 65, 2105, 3, 338 },
                    { 69, 2805, 3, 171 },
                    { 70, 1123, 3, 117 },
                    { 80, 2240, 3, 113 },
                    { 77, 2940, 3, 149 },
                    { 79, 2750, 2, 250 },
                    { 63, 1942, 4, 325 },
                    { 75, 1983, 2, 249 },
                    { 74, 1810, 2, 430 },
                    { 20, 1978, 2, 648 },
                    { 29, 2879, 2, 670 },
                    { 31, 1320, 2, 262 },
                    { 32, 2307, 2, 293 },
                    { 34, 1823, 2, 197 },
                    { 61, 1180, 4, 206 },
                    { 35, 1061, 2, 654 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 73, 1318, 3, 624 },
                    { 55, 2596, 4, 351 },
                    { 48, 2388, 2, 303 },
                    { 50, 2261, 4, 196 },
                    { 47, 2270, 4, 644 },
                    { 45, 1734, 4, 645 },
                    { 43, 2615, 4, 114 },
                    { 52, 2986, 2, 183 },
                    { 56, 1042, 2, 515 },
                    { 59, 2929, 2, 448 },
                    { 40, 2586, 4, 433 },
                    { 38, 1117, 4, 201 },
                    { 33, 2109, 4, 259 },
                    { 60, 2471, 2, 535 },
                    { 62, 2850, 2, 507 },
                    { 27, 1639, 4, 194 },
                    { 21, 1048, 4, 484 },
                    { 67, 2187, 2, 628 },
                    { 16, 2869, 4, 248 },
                    { 71, 1287, 3, 329 },
                    { 98, 2370, 4, 606 },
                    { 97, 2031, 4, 570 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 14, 199, "Conn, Sawayn and Kassulke" },
                    { 43, 101, "Sawayn Group" },
                    { 51, 43, "Littel - Wolf" },
                    { 93, 40, "Bernhard - Purdy" },
                    { 88, 40, "Kuhn, Gerlach and Koss" },
                    { 22, 40, "Kutch Inc" },
                    { 56, 39, "Kulas - Kertzmann" },
                    { 90, 110, "Murazik - Lemke" },
                    { 9, 39, "Grady - Lubowitz" },
                    { 74, 38, "Wolff - Ernser" },
                    { 33, 115, "Cummerata and Sons" },
                    { 39, 115, "Lueilwitz Inc" },
                    { 20, 35, "Koss Inc" },
                    { 18, 35, "Jaskolski, Kerluke and Moore" },
                    { 97, 34, "Pfeffer - Bayer" },
                    { 17, 118, "Grant - Lockman" },
                    { 63, 34, "Roob - Hirthe" },
                    { 44, 121, "Glover Inc" },
                    { 64, 122, "Braun LLC" },
                    { 50, 123, "Toy, McKenzie and Homenick" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 100, 32, "Bruen - Ward" },
                    { 1, 44, "Brakus, Thiel and Hoppe" },
                    { 79, 96, "Reynolds - Price" },
                    { 61, 96, "Crooks, Carroll and Schmitt" },
                    { 54, 96, "Stoltenberg - Hickle" },
                    { 12, 63, "Blanda - Nolan" },
                    { 49, 66, "Fahey, Glover and Wisozk" },
                    { 92, 71, "Jakubowski, Cole and Mertz" },
                    { 8, 73, "Goodwin and Sons" },
                    { 34, 59, "Gottlieb - Nolan" },
                    { 67, 74, "Greenfelder - Kohler" },
                    { 78, 57, "Lemke LLC" },
                    { 30, 75, "Johnston, Jenkins and Hamill" },
                    { 75, 56, "Carroll Inc" },
                    { 4, 77, "Marks, Boyer and West" },
                    { 13, 32, "Prohaska - Bayer" },
                    { 58, 51, "Skiles, Schuster and Wilderman" },
                    { 87, 81, "Swift - Frami" },
                    { 16, 84, "Murazik Inc" },
                    { 45, 84, "Fadel, Schuster and Ratke" },
                    { 68, 84, "Lebsack LLC" },
                    { 65, 48, "Lowe - Stracke" },
                    { 66, 85, "Deckow - Tremblay" },
                    { 6, 48, "Kling and Sons" },
                    { 32, 47, "Halvorson - Wiegand" },
                    { 37, 91, "Botsford, Christiansen and Miller" },
                    { 96, 46, "Nikolaus - Ledner" },
                    { 36, 51, "Green - Quigley" },
                    { 83, 198, "Brekke - Tromp" },
                    { 60, 29, "Zieme, Daniel and Kohler" },
                    { 99, 126, "Gaylord, Koepp and Carroll" },
                    { 94, 164, "Marquardt, Weimann and Blick" },
                    { 89, 165, "Volkman - Beer" },
                    { 15, 7, "Bartoletti, Wisoky and Schmidt" },
                    { 25, 166, "Pouros, Hermiston and Stroman" },
                    { 26, 168, "Nienow, Sauer and Brown" },
                    { 71, 168, "Klein, Donnelly and Willms" },
                    { 77, 171, "Simonis - Mante" },
                    { 82, 171, "Ankunding - Gulgowski" },
                    { 62, 174, "Mitchell - Stamm" },
                    { 81, 174, "Weber Inc" },
                    { 70, 177, "Dickinson, Armstrong and Champlin" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 76, 177, "Stanton, Botsford and Smith" },
                    { 27, 5, "Russel, Nitzsche and Brown" },
                    { 24, 5, "Bergnaum - Dare" },
                    { 11, 5, "Fay - Schmitt" },
                    { 31, 4, "Lynch - Rath" },
                    { 3, 3, "Tromp and Sons" },
                    { 48, 183, "Hartmann Inc" },
                    { 85, 183, "Wintheiser Group" },
                    { 55, 1, "Leannon Group" },
                    { 42, 192, "Ondricka, Connelly and Quigley" },
                    { 73, 164, "Murazik - Miller" },
                    { 35, 164, "Hermann, Murazik and Kunde" },
                    { 23, 8, "Von - Steuber" },
                    { 47, 9, "Dickens Inc" },
                    { 28, 127, "Runte - Schultz" },
                    { 57, 127, "Satterfield - Kassulke" },
                    { 98, 26, "Cruickshank - Kemmer" },
                    { 91, 130, "Brown - Nader" },
                    { 69, 22, "Kutch and Sons" },
                    { 21, 133, "Farrell - Beier" },
                    { 38, 22, "Kuhn - Koch" },
                    { 5, 142, "Gerhold - Koss" },
                    { 7, 144, "Brown and Sons" },
                    { 84, 15, "DuBuque - Mills" },
                    { 40, 126, "Hansen Inc" },
                    { 72, 15, "Schimmel - Hudson" },
                    { 52, 15, "Witting LLC" },
                    { 29, 13, "Weissnat - Schaden" },
                    { 95, 155, "Bechtelar and Sons" },
                    { 10, 156, "Wiegand - Schuster" },
                    { 46, 11, "Spinka, Doyle and Kihn" },
                    { 2, 157, "Block Inc" },
                    { 19, 157, "O'Hara and Sons" },
                    { 86, 157, "Deckow, Hickle and Botsford" },
                    { 41, 10, "Mills - Kshlerin" },
                    { 53, 163, "Abshire - Stamm" },
                    { 59, 15, "Marquardt Group" },
                    { 80, 13, "Stiedemann - Osinski" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 33, 97, 6, "maiores" },
                    { 43, 72, 68, "autem" },
                    { 23, 83, 50, "sed" },
                    { 59, 84, 44, "aut" },
                    { 80, 84, 44, "ut" },
                    { 87, 89, 99, "dignissimos" },
                    { 88, 8, 5, "itaque" },
                    { 5, 68, 39, "id" },
                    { 90, 8, 78, "eaque" },
                    { 27, 12, 16, "non" },
                    { 95, 12, 62, "voluptatibus" },
                    { 24, 18, 69, "debitis" },
                    { 2, 19, 89, "aliquid" },
                    { 38, 20, 40, "veniam" },
                    { 93, 34, 51, "impedit" },
                    { 18, 12, 82, "error" },
                    { 3, 68, 1, "quia" },
                    { 57, 64, 5, "possimus" },
                    { 37, 54, 91, "eum" },
                    { 53, 4, 82, "aperiam" },
                    { 4, 7, 12, "amet" },
                    { 100, 7, 49, "voluptatem" },
                    { 40, 10, 48, "voluptatum" },
                    { 74, 10, 22, "necessitatibus" },
                    { 14, 24, 49, "dolor" },
                    { 19, 28, 55, "sequi" },
                    { 36, 41, 27, "perspiciatis" },
                    { 41, 42, 29, "temporibus" },
                    { 75, 42, 75, "aspernatur" },
                    { 52, 44, 33, "accusamus" },
                    { 10, 46, 76, "eveniet" },
                    { 13, 46, 16, "voluptas" },
                    { 50, 46, 92, "animi" },
                    { 7, 49, 22, "qui" },
                    { 71, 48, 80, "mollitia" },
                    { 51, 59, 52, "iste" },
                    { 79, 93, 77, "ratione" },
                    { 8, 60, 33, "quis" },
                    { 26, 100, 2, "magnam" },
                    { 91, 100, 93, "totam" },
                    { 92, 15, 65, "veritatis" },
                    { 72, 40, 84, "sint" }
                });

            migrationBuilder.InsertData(
                table: "Models",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 34, 45, 72, "fugit" },
                    { 45, 45, 82, "accusantium" },
                    { 31, 80, 44, "occaecati" },
                    { 78, 45, 71, "dolore" },
                    { 39, 66, 25, "porro" },
                    { 6, 76, 34, "ducimus" },
                    { 62, 76, 97, "quaerat" },
                    { 28, 78, 63, "et" },
                    { 1, 93, 60, "fugiat" },
                    { 66, 59, 66, "voluptate" },
                    { 22, 55, 37, "eius" },
                    { 12, 80, 56, "labore" },
                    { 29, 76, 27, "quod" },
                    { 85, 69, 65, "est" },
                    { 9, 70, 6, "asperiores" },
                    { 83, 60, 27, "ipsam" },
                    { 15, 67, 33, "ad" },
                    { 54, 60, 17, "ab" },
                    { 11, 95, 58, "dolorem" },
                    { 94, 99, 52, "culpa" },
                    { 65, 3, 43, "sit" },
                    { 25, 74, 41, "ullam" },
                    { 96, 6, 57, "omnis" },
                    { 32, 22, 70, "fuga" },
                    { 46, 23, 62, "nam" },
                    { 84, 23, 58, "harum" },
                    { 21, 25, 28, "atque" },
                    { 42, 25, 36, "vel" },
                    { 99, 3, 31, "a" },
                    { 55, 65, 87, "eligendi" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 262, 290, "Eriberto.Botsford@yahoo.com", "Mark", "Fisher", "t2jFB6P2pZ", 3, "Parker_Reichert" },
                    { 104, 164, "Brandon35@yahoo.com", "Dahlia", "Hahn", "cOUlU9Y_Od", 1, "Juliana62" },
                    { 39, 262, "Wyatt.Beahan@gmail.com", "Cornell", "Powlowski", "v5VnnMu4Ib", 2, "Jett.Effertz64" },
                    { 246, 293, "Clementine26@hotmail.com", "Zena", "Beatty", "OS3k9skZrN", 3, "April9" },
                    { 259, 299, "Allen_Bartell@gmail.com", "Estefania", "Kiehn", "JAaiBeDCNI", 3, "Reginald83" },
                    { 48, 50, "General18@hotmail.com", "Ebony", "Murazik", "yKtsMoJljt", 1, "Tressa_Lind" },
                    { 102, 299, "Art.Tremblay38@hotmail.com", "Efrain", "Marquardt", "v48XDpZiQk", 1, "Ezequiel.Stark" },
                    { 123, 84, "Norbert75@hotmail.com", "Amir", "Casper", "cQoZedIzoN", 1, "King_Mann55" },
                    { 234, 215, "Rodolfo_Littel66@gmail.com", "Prudence", "Ryan", "WMJu1bh6sD", 3, "Regan.Dickens" },
                    { 283, 157, "Sarina_Schaden74@yahoo.com", "Maximo", "Langworth", "3rT_7Q4Dkw", 3, "Catharine.McCullough" },
                    { 49, 99, "Richard_Leannon4@hotmail.com", "Deonte", "Lehner", "cHJq3Ep8EC", 2, "Gabriella_Trantow6" },
                    { 43, 31, "Jermaine7@gmail.com", "Shyanne", "Cassin", "m2jz6BMMGE", 1, "Laverna36" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 98, 242, "Eleonore_Schultz@gmail.com", "Annabel", "Boyer", "mD7BooB3ya", 1, "Cyril83" },
                    { 74, 274, "Rosemary48@yahoo.com", "Misty", "Koss", "CY6ATUh7ku", 2, "Ronaldo53" },
                    { 224, 274, "Keely90@gmail.com", "Chandler", "Boyle", "ocGA5Iu8YR", 3, "Jadyn_Altenwerth" },
                    { 260, 274, "Etha46@yahoo.com", "Tanya", "Feest", "tXNH8JKLvF", 2, "Alaina20" },
                    { 142, 10, "Gregoria.Halvorson@gmail.com", "Rylee", "Wilkinson", "8BCYPqT0oa", 3, "Josh_Christiansen13" },
                    { 285, 10, "Faustino.Vandervort17@yahoo.com", "Emmet", "Rau", "1_ptrGLnWJ", 2, "Janice_Moen44" },
                    { 170, 31, "Hilton72@gmail.com", "Jensen", "Mosciski", "1KvSdx8lBP", 3, "Shannon_Bahringer" },
                    { 205, 205, "Danial_Brown@hotmail.com", "Joanny", "Heathcote", "usy_DcI5Ss", 2, "Garnet_Jacobi8" },
                    { 201, 75, "Wiley.Price63@hotmail.com", "Reece", "Lindgren", "gVnduyrXge", 1, "Aidan11" },
                    { 203, 75, "Cullen.Walter@yahoo.com", "Clemmie", "Renner", "CiDb_X9456", 1, "Montana.Hartmann0" },
                    { 207, 75, "Alize_Kulas36@yahoo.com", "Brent", "Toy", "5iITiqFozg", 1, "Noe.Schulist54" },
                    { 53, 294, "Kayden_Reichel3@gmail.com", "Willis", "Vandervort", "Ce6QY5AeYe", 2, "Tyson5" },
                    { 167, 99, "Furman.Konopelski60@yahoo.com", "Scot", "Koss", "l1PoXqi1ys", 2, "Carolyn.Hettinger68" },
                    { 284, 148, "Maverick.Wolff76@yahoo.com", "Clifton", "Swaniawski", "k18eWagoe5", 1, "Marvin_Wisoky23" },
                    { 295, 243, "Icie_Kub@yahoo.com", "Ilene", "Kessler", "NOBJR0HHnm", 1, "Priscilla_Sipes" },
                    { 236, 44, "Violet.Hand94@yahoo.com", "Avery", "Miller", "2LcKGcgTzs", 3, "Ruthe63" },
                    { 277, 69, "Sienna.Stanton@yahoo.com", "Devin", "Larson", "5SifDhofZJ", 3, "Earl74" },
                    { 174, 2, "Lucy.Stamm8@gmail.com", "Dudley", "Williamson", "DtehDQaehD", 2, "Ford.Yost46" },
                    { 75, 53, "Graciela_Huel36@yahoo.com", "Zella", "Kub", "UhB4HG8PJN", 1, "Enoch_Smith" },
                    { 293, 100, "May.Langworth@yahoo.com", "Sincere", "Lubowitz", "tLUttqE205", 1, "Ottilie.Gerhold" },
                    { 1, 132, "Ray_Halvorson72@yahoo.com", "Alexandria", "Collins", "qJN9JU3naN", 1, "Joelle_Hagenes" },
                    { 137, 185, "Carol.OConnell@yahoo.com", "Frieda", "Yost", "zynJ3gY4ei", 1, "Bria51" },
                    { 135, 219, "Claudine67@hotmail.com", "Osvaldo", "Abshire", "QNXiIwE0p0", 2, "Ashleigh97" },
                    { 122, 125, "Agnes_Ebert93@yahoo.com", "Valentina", "Heaney", "Pw_38n1fML", 3, "Diamond_Streich" },
                    { 149, 125, "Jayden_Kuvalis@gmail.com", "Forrest", "Waters", "6qPbkh2Dhp", 3, "Rodrigo66" },
                    { 77, 223, "Nannie91@hotmail.com", "Javier", "Kutch", "pviOVB5trU", 3, "Crystal.Purdy" },
                    { 161, 223, "Hallie3@gmail.com", "Brice", "McKenzie", "yXumdvhyNi", 2, "Christa57" },
                    { 35, 221, "Florine70@hotmail.com", "Bailey", "Anderson", "UqncQNGFOH", 1, "Nella37" },
                    { 249, 148, "Gabrielle.Tremblay10@yahoo.com", "Raphael", "Cummerata", "hwhCnFTiJ7", 3, "Cecilia12" },
                    { 119, 246, "Giuseppe95@hotmail.com", "Muhammad", "Gislason", "tduFP4q07l", 1, "Seamus59" },
                    { 108, 251, "Victor.Wolf@gmail.com", "Danny", "Torp", "PiVixaxhxr", 2, "Nico.Kuhn47" },
                    { 118, 251, "Pearline_Dach43@gmail.com", "Khalil", "Kertzmann", "wS5LtQl0F8", 1, "Brice_Kozey" },
                    { 92, 255, "Jonathon43@gmail.com", "Priscilla", "Streich", "jbLISkUn5C", 2, "Annalise_Lind" },
                    { 20, 145, "Geovanni.Gleason@hotmail.com", "Haleigh", "McGlynn", "4CMEsyO4gb", 2, "Ian45" },
                    { 261, 58, "Margie5@yahoo.com", "Gloria", "Rogahn", "f719ZIiWa5", 3, "Baylee19" },
                    { 132, 170, "Jamel73@hotmail.com", "Corbin", "Williamson", "wUmZxxll9o", 3, "Tracy_Schinner73" },
                    { 248, 140, "Javier_Mueller@hotmail.com", "Nick", "Barton", "XKewmPSygp", 3, "Noemie.Huels2" },
                    { 82, 207, "Reilly28@hotmail.com", "Isaias", "Sipes", "PbL7nj94Sk", 2, "Lonzo19" },
                    { 5, 1, "Nikki_Kerluke@gmail.com", "Giovanna", "Miller", "6Phx14FZPb", 3, "Karina_Padberg16" },
                    { 33, 1, "Hosea91@yahoo.com", "Rudy", "Braun", "TsDuU_H5b0", 2, "Peggie.Pollich" },
                    { 263, 1, "Michelle3@gmail.com", "Grover", "Mosciski", "5ESxE6B4Kc", 3, "Garett_Stoltenberg9" },
                    { 300, 1, "Arjun_Smitham@hotmail.com", "Frank", "Weber", "vMqBSUmgBU", 1, "Gregory.Turcotte71" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 47, 30, "Virginie13@yahoo.com", "Freeda", "Kassulke", "J2HrHv2ULy", 2, "Beth93" },
                    { 171, 221, "Arvilla.Jenkins@hotmail.com", "Gail", "Christiansen", "wxSRbpUhLU", 1, "Rossie.Kuvalis10" },
                    { 243, 11, "Jazmyne.Paucek82@yahoo.com", "Mac", "Predovic", "NPHkzCO6yi", 1, "Alanis_Mertz59" },
                    { 280, 206, "Era53@yahoo.com", "Wade", "Kulas", "uFSctWt1Fu", 1, "Mckayla_West" },
                    { 9, 177, "Brenden18@yahoo.com", "Alvis", "Pouros", "jXT0DKudy_", 3, "Elmo59" },
                    { 6, 229, "Ari.Schuppe71@gmail.com", "Antwon", "Goldner", "KcQ9ThZNWa", 3, "Carlotta_Beer50" },
                    { 91, 229, "Mckayla_Koepp@gmail.com", "Abbey", "Pagac", "myd0hwBykH", 3, "Nyah.Brakus" },
                    { 192, 220, "Helene.Kozey@gmail.com", "Joany", "Corwin", "psmi5INYYA", 1, "Karley.Blick66" },
                    { 162, 123, "Yasmeen5@yahoo.com", "Rowena", "Casper", "rIfePCqwbD", 1, "Estevan68" },
                    { 273, 51, "Eileen56@yahoo.com", "Emmett", "Hickle", "Hrd62KvTtS", 2, "Mattie_Botsford59" },
                    { 44, 108, "Miguel57@hotmail.com", "Cyrus", "Bergstrom", "ZD9FM5OGcL", 1, "Beulah_Cassin45" },
                    { 148, 234, "Casandra.Koelpin27@hotmail.com", "Kaya", "Heller", "ADykcxt3hc", 3, "Matt.Mohr" },
                    { 56, 80, "Emmanuelle55@hotmail.com", "Salma", "West", "Bo9eQU1nTZ", 3, "Otho2" },
                    { 121, 82, "Lavina71@hotmail.com", "Santino", "Fritsch", "cmVVCR_FoS", 1, "Torey_Rempel47" },
                    { 185, 82, "Kallie.Ledner@hotmail.com", "Ofelia", "Hermiston", "y4PkctluT5", 1, "Stephan.Funk" },
                    { 155, 29, "Flavie54@gmail.com", "Giovanny", "Wiegand", "Q2HOBh9iwZ", 3, "Brigitte_Fay99" },
                    { 202, 201, "Kaycee.Legros54@gmail.com", "Julia", "Howell", "UTtHKpusdU", 2, "Kennedy.Kling" },
                    { 150, 198, "Ignacio.Kutch62@yahoo.com", "Verona", "Powlowski", "sraLlhXeac", 1, "Werner.Streich42" },
                    { 196, 45, "Amya_Kuhic@hotmail.com", "Wilber", "Hegmann", "Qq5l6ayoQe", 3, "Rosie.Oberbrunner" },
                    { 163, 249, "Arnold2@hotmail.com", "Omari", "Reichel", "pOfjYsZKpU", 3, "Mara_Muller35" },
                    { 212, 249, "Arlo85@yahoo.com", "Aimee", "Herman", "JDAxIRGsYX", 3, "Vincent_Braun81" },
                    { 67, 127, "Marcelo.Wyman38@gmail.com", "Emerson", "Wisoky", "Rslj6BxOwT", 3, "Filiberto.Langworth" },
                    { 160, 127, "Karine21@gmail.com", "Jade", "Farrell", "rxqXZShdbA", 3, "Isobel_Koepp26" },
                    { 221, 240, "Patsy.Considine58@yahoo.com", "Dominic", "Heaney", "R5ibO9C6v2", 3, "Maximillia_Schumm96" },
                    { 25, 165, "Waylon.Roberts@yahoo.com", "Neoma", "Sanford", "UnWX_AoC4F", 2, "Rafaela_Gutkowski" },
                    { 133, 167, "Hassie.Erdman62@hotmail.com", "Jay", "Herzog", "xRAz8dA0GE", 2, "Eliane.Graham71" },
                    { 289, 35, "Jorge.Jenkins@hotmail.com", "Astrid", "Stehr", "NmMUaE0P0V", 1, "Chanel_Langosh" },
                    { 166, 259, "Tomasa19@yahoo.com", "Rosemarie", "Schmidt", "AvIZGlLvxt", 3, "Lavern19" },
                    { 241, 259, "Jordan.Dibbert36@hotmail.com", "Retha", "Schmeler", "ZjGW632tyB", 3, "Reinhold99" },
                    { 16, 264, "Evan90@hotmail.com", "Greg", "Borer", "We2JmjTw7L", 2, "Hailey.Quitzon" },
                    { 117, 212, "Veda_Hills@yahoo.com", "Lavon", "Rutherford", "0vmT_FEcxb", 1, "Marlen.Tremblay50" },
                    { 195, 263, "Kay_Gerhold@hotmail.com", "Gertrude", "Gulgowski", "zDjF3CLubF", 3, "Silas_Schoen20" },
                    { 40, 263, "Willard21@hotmail.com", "Ahmad", "Welch", "ghRrKsrA7k", 2, "Terry_Jakubowski97" },
                    { 250, 275, "Shannon37@gmail.com", "Mortimer", "Ryan", "fOfo6WjVwI", 1, "Seamus.Casper" },
                    { 4, 187, "Kurtis84@hotmail.com", "Dereck", "Stark", "pbhlgPE4_F", 3, "Gonzalo.Goodwin76" },
                    { 55, 187, "Amparo88@hotmail.com", "Anjali", "Collier", "bMW__TvkNe", 2, "Taurean91" },
                    { 141, 187, "Sylvester.Schimmel@gmail.com", "Harrison", "Schulist", "uQMlC8D4du", 2, "Conner49" },
                    { 154, 241, "Eleanora_Kiehn0@gmail.com", "Destini", "Stiedemann", "LvgzRCjPME", 1, "Jordi_Carroll19" },
                    { 281, 241, "Shaun70@gmail.com", "Ena", "Upton", "OO7j8t89yX", 1, "Laurie.Trantow" },
                    { 54, 106, "Celestine.Feest@gmail.com", "Amelia", "Crona", "xQ1T8_GTgT", 3, "Maurice_Howe61" },
                    { 80, 106, "Zoey.Gottlieb73@hotmail.com", "Carol", "Graham", "n3sPI5tTJf", 2, "Rusty20" },
                    { 252, 196, "Ramon79@gmail.com", "Mae", "Purdy", "eXv9mAxuE4", 3, "Domingo_Davis52" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 189, 281, "Ruthie61@gmail.com", "Liana", "Walsh", "dzYuwlAZdT", 1, "Arvel_OConner10" },
                    { 61, 11, "Baron.Kovacek83@yahoo.com", "Ciara", "Murray", "xQ4uh1CWvN", 1, "Cynthia14" },
                    { 95, 11, "Myah47@gmail.com", "Nolan", "Ullrich", "cHOe_ZQXpQ", 3, "Mariam89" },
                    { 187, 11, "Vena.Gleason12@yahoo.com", "Eudora", "Schuster", "c5YOvduqUK", 1, "Megane49" },
                    { 235, 11, "Haylee14@gmail.com", "Dell", "Lang", "8ANZrhlgMJ", 2, "Casimir.Schamberger" },
                    { 116, 73, "Immanuel54@gmail.com", "Terrell", "Sipes", "8sGzmE0dF_", 1, "Maribel35" },
                    { 125, 73, "Tia79@hotmail.com", "Yvonne", "Ruecker", "bUek3K1YTu", 2, "Jayde_Kertzmann31" },
                    { 157, 236, "Bill.Price@hotmail.com", "Pierre", "Mosciski", "mYWzQHwQrl", 1, "Mara27" },
                    { 210, 236, "Kirsten_Bashirian2@gmail.com", "Lilyan", "Haley", "59xHZfeYUO", 3, "Keeley43" },
                    { 65, 222, "Crawford.Von@hotmail.com", "Cleo", "O'Kon", "ARC2_CmS4_", 3, "Bill_Schulist" },
                    { 113, 222, "Dudley.Schuppe29@hotmail.com", "Chloe", "Friesen", "WinjKJYfQj", 1, "Casey96" },
                    { 50, 273, "Loma3@yahoo.com", "Johnathan", "Bartoletti", "2yffLdE9PC", 2, "Mercedes.Ziemann42" },
                    { 144, 273, "Lonie.Kemmer@yahoo.com", "Oswaldo", "Rippin", "V4drEDz8dh", 3, "Hope33" },
                    { 206, 273, "Cindy.Schaden@yahoo.com", "Garrett", "Hane", "QVlDk_wsO3", 1, "Chaim16" },
                    { 2, 149, "Johnnie76@hotmail.com", "Jacklyn", "Little", "K2ATFW172L", 2, "Michel_Little90" },
                    { 238, 149, "Zackery.Goldner26@gmail.com", "Rebeka", "Wiegand", "ua3Rb4w6jJ", 2, "Clarabelle.Schuster" },
                    { 138, 263, "Madyson41@gmail.com", "Tressie", "Johnston", "SGQvfuYMeE", 2, "Kiarra44" },
                    { 100, 103, "Aurelio.Strosin91@hotmail.com", "Dariana", "Buckridge", "J7PsHJEx0g", 3, "Maia65" },
                    { 124, 220, "Rosemary_Cormier@yahoo.com", "Ola", "Brown", "JhaFUo46RK", 3, "Lon39" },
                    { 257, 97, "Kade.Weimann@gmail.com", "Abraham", "Christiansen", "ac9Js5Jj3O", 1, "Elton_Hirthe75" },
                    { 268, 70, "Lavinia36@hotmail.com", "Pauline", "Bernier", "BTEk9C0ol8", 3, "Camden7" },
                    { 7, 70, "Joannie89@yahoo.com", "Liliana", "O'Hara", "JpXzDbGQPW", 1, "Osbaldo24" },
                    { 111, 194, "Diego_Reinger@yahoo.com", "Ebba", "Auer", "m_admvuXEK", 1, "Scotty_Rice" },
                    { 106, 194, "Madilyn_Herzog@hotmail.com", "Roberta", "Sanford", "alAM_weNed", 3, "Leora_Schoen" },
                    { 299, 55, "Mafalda44@yahoo.com", "Tremayne", "Schinner", "ZSun6V6Hoy", 3, "Remington_Wolf" },
                    { 233, 55, "Jaime_Conn@yahoo.com", "Bert", "Franecki", "zw0pan24Ix", 3, "Dulce31" },
                    { 275, 20, "Nolan.Roberts44@gmail.com", "Alford", "Hane", "CupiMxUOmg", 2, "Ezequiel.Kohler75" },
                    { 251, 20, "Theron_Metz61@yahoo.com", "Marie", "Beahan", "saDObjDZDZ", 1, "Hans.McGlynn" },
                    { 156, 20, "Camille_Hudson@yahoo.com", "Alivia", "Will", "mpp2FjmbSz", 1, "Rafaela.Veum" },
                    { 112, 110, "Drake41@yahoo.com", "Michel", "Howe", "1wkI_vgVLy", 1, "Thalia.Johnson44" },
                    { 26, 119, "Retha23@yahoo.com", "Layne", "Wiegand", "8_ASGJo3JP", 3, "Norris40" },
                    { 200, 94, "Nova_Roob73@gmail.com", "Mortimer", "Hyatt", "83d1Yrr37g", 1, "Sammy_Howe10" },
                    { 64, 36, "Sigrid56@yahoo.com", "Heaven", "McCullough", "oogsgSmkaj", 1, "Manuel.DuBuque" },
                    { 24, 36, "Buford53@yahoo.com", "Monserrat", "O'Hara", "faZYlsd7Z6", 2, "Gust84" },
                    { 276, 17, "Silas30@hotmail.com", "Amos", "Johnston", "feZ9xQf69B", 1, "Name8" },
                    { 87, 17, "Katelynn_Cronin74@yahoo.com", "Verdie", "Dicki", "V3KMQuJLu7", 1, "Katarina.Kunde34" },
                    { 81, 17, "Joseph_Lang@gmail.com", "Dixie", "Maggio", "zUumoH4Fko", 3, "John53" },
                    { 41, 268, "Virginie60@yahoo.com", "Tabitha", "O'Connell", "FpEZKvgEGC", 3, "Emiliano.Bernhard22" },
                    { 198, 250, "Vince_Fay96@yahoo.com", "Grant", "Swaniawski", "5uMaIizcM5", 3, "Courtney_Lesch53" },
                    { 227, 287, "Gudrun.Towne@hotmail.com", "Lavonne", "Dach", "dS3iUPV9_B", 3, "Archibald_Hermann49" },
                    { 146, 250, "Tomasa_Strosin@gmail.com", "Laverne", "Lebsack", "cEpyn5Y0hG", 2, "Darrin.Mayert30" },
                    { 270, 287, "Alvina.Schinner42@gmail.com", "Frederique", "Morissette", "C4r7pWPFZy", 3, "Ayana34" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 85, 265, "Edmund67@yahoo.com", "Pasquale", "Nolan", "IpgocY6NhR", 3, "Vincenzo.Rempel76" },
                    { 34, 105, "Raheem.Schroeder@yahoo.com", "Rebeca", "Hickle", "xfd9IqATby", 1, "Oren_Bauch76" },
                    { 143, 269, "Kiara.Schmeler15@gmail.com", "Berniece", "Predovic", "svZ3wgypDh", 2, "Harmony86" },
                    { 97, 254, "Adah.VonRueden@yahoo.com", "Declan", "Walter", "JZ8ppeNeYk", 3, "Timothy_Leannon" },
                    { 79, 254, "Chanel_Farrell@gmail.com", "Rene", "Mohr", "lFfEXdSerN", 2, "Roberta11" },
                    { 279, 134, "Allie_Kilback@hotmail.com", "Reva", "Ledner", "N6NkRXC552", 2, "Wilton_Wilkinson69" },
                    { 103, 134, "Sydnee61@hotmail.com", "Zack", "Hane", "d6L9ONJ3BJ", 2, "Deshawn20" },
                    { 208, 128, "Wilfred.Wyman27@yahoo.com", "Elouise", "Koch", "lyvVII9Mgz", 1, "Ebba66" },
                    { 45, 128, "Cecil.Considine9@hotmail.com", "Adelbert", "DuBuque", "LLkafIvsld", 1, "Elijah83" },
                    { 269, 193, "Molly34@hotmail.com", "Amelie", "Schinner", "HjLtEbF0u4", 3, "Augustine_Gottlieb" },
                    { 180, 193, "Kieran_Batz84@gmail.com", "Franz", "Crist", "3dgaKLHHfP", 2, "Brian35" },
                    { 101, 193, "Berniece9@yahoo.com", "Angelita", "Cremin", "NWi8GCgjf4", 3, "Terrence84" },
                    { 231, 131, "Jarrell5@gmail.com", "Claudia", "Thiel", "6DCPOvLLy5", 3, "Gillian90" },
                    { 114, 131, "Catharine.Thompson73@gmail.com", "Brisa", "Romaguera", "2ZMJ4blNhK", 3, "Cecile_Batz26" },
                    { 10, 131, "Deborah.Kozey@hotmail.com", "Myron", "Cronin", "50k6U7F0c8", 2, "Claudia_Ritchie" },
                    { 291, 120, "Aidan94@hotmail.com", "Conner", "Heathcote", "Dxs9NEqnv0", 3, "Lilla38" },
                    { 239, 120, "Karson_Dietrich71@hotmail.com", "Candido", "Reichert", "wC8F92HoOd", 3, "Lauryn.Macejkovic93" },
                    { 78, 120, "Era_Hermann10@gmail.com", "Cecilia", "Homenick", "Ma0oYoS4oP", 3, "Howard.Botsford" },
                    { 15, 289, "Prudence_Hoppe93@hotmail.com", "Hillard", "Vandervort", "dmYh6RLTi1", 3, "Alicia_Beier14" },
                    { 152, 265, "Eduardo41@hotmail.com", "Arnold", "O'Connell", "v9wllZhdHm", 3, "Eldred44" },
                    { 294, 42, "Jacinthe.Satterfield46@hotmail.com", "Adolf", "Ondricka", "NyfEQ9neRN", 3, "Kay.Goyette" },
                    { 282, 211, "Regan9@yahoo.com", "Betty", "Hirthe", "MexH2pOMEf", 3, "Elody.Langworth38" },
                    { 89, 211, "Jillian.Pollich@hotmail.com", "Arvel", "Dietrich", "nlCZMvkY0a", 3, "Betsy_Huels84" },
                    { 179, 83, "Violet_Stark82@yahoo.com", "Davin", "Crona", "cg_Xie8Bt_", 1, "Orion_Spencer" },
                    { 76, 189, "Maria.McGlynn19@yahoo.com", "Joshua", "Tromp", "hQjaifkj2S", 3, "Adan_Deckow" },
                    { 217, 52, "Antonietta.Fisher92@gmail.com", "Antwan", "Olson", "DFOuGrXq6F", 3, "Minerva_Swift" },
                    { 23, 52, "Jackeline_West38@gmail.com", "Chadrick", "Will", "pDJiJsHo98", 3, "Mohamed_Bernier" },
                    { 264, 26, "Meaghan_Champlin@yahoo.com", "Loyal", "Doyle", "w_V2tOw5dx", 1, "Cecile.Macejkovic88" },
                    { 71, 26, "Nelson_Schowalter@yahoo.com", "Antoinette", "Satterfield", "IQIqGz7Ptu", 1, "Lloyd.Flatley52" },
                    { 165, 135, "Avery_Volkman@gmail.com", "Westley", "Kerluke", "XsFYcz4hZe", 3, "Gustave77" },
                    { 69, 135, "Bertha8@hotmail.com", "Heather", "Pollich", "rJ__kjrbmk", 3, "Lennie.Ziemann" },
                    { 290, 276, "Pietro32@yahoo.com", "Kellie", "Rowe", "PjuRm_xlbC", 3, "Shanon.Mohr" },
                    { 178, 86, "Letha.Borer39@yahoo.com", "Gussie", "Harvey", "oEmYTX06kG", 2, "Julie.Schuster21" },
                    { 57, 86, "Garland21@yahoo.com", "Edwina", "Ward", "EDqUIA4Oio", 1, "Gonzalo_Dibbert" },
                    { 3, 86, "Uriah_Hand19@gmail.com", "Jed", "Schuster", "IuJS2m79q9", 3, "Christine.OKon95" },
                    { 70, 277, "Kellen9@hotmail.com", "Angus", "Bechtelar", "Ha9JgcNhSy", 2, "Flavio71" },
                    { 32, 277, "Monserrat.Mayert@gmail.com", "Dusty", "Waelchi", "dILnD7aKTf", 3, "Chaya.Kreiger" },
                    { 139, 252, "Selmer28@hotmail.com", "Lorena", "Ebert", "DQOZukcWaM", 3, "Jarvis10" },
                    { 105, 239, "Melvina52@hotmail.com", "Mya", "Lowe", "sybsspZzWE", 1, "Lurline_Block" },
                    { 232, 217, "Santino.Ullrich42@hotmail.com", "Ted", "Robel", "lde5O2yeB5", 3, "Larue_Waters" },
                    { 21, 217, "Benton_Hansen77@yahoo.com", "Carrie", "Bailey", "HRKqWfA43Y", 2, "Jonathon62" },
                    { 211, 150, "Brenna_Johns@yahoo.com", "Rosetta", "Bergstrom", "xZlHP8EKqO", 2, "Shannon12" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 36, 85, "Hardy_Daugherty@yahoo.com", "Arne", "Gibson", "qVryMkb0Bp", 3, "Annette_Kautzer95" },
                    { 194, 189, "Trevor.Waters@gmail.com", "Alexandro", "Bechtelar", "DneP1e6stk", 2, "Elwyn83" },
                    { 134, 228, "Jillian.Kirlin43@gmail.com", "Elna", "Mueller", "72U4nscWEb", 1, "Tony.Mayert" },
                    { 42, 300, "Annabelle.Osinski@hotmail.com", "Betsy", "Hauck", "jI9DB5nM7e", 3, "Gus.Bergnaum" },
                    { 164, 23, "Estell_Carter28@yahoo.com", "Nakia", "Willms", "tY434URZto", 2, "Nannie.Marvin29" },
                    { 147, 54, "Isabelle.Funk@gmail.com", "Verda", "Torp", "umQ6GUb0tQ", 3, "Roslyn70" },
                    { 140, 54, "Tressie.Schimmel@yahoo.com", "Kenyon", "Pacocha", "6URL9oy5jd", 3, "Seth.Armstrong69" },
                    { 110, 89, "Maria40@gmail.com", "Kelsi", "Leannon", "chv0YGN_wI", 1, "Elmo_Considine" },
                    { 90, 89, "Sunny.Blanda91@gmail.com", "Hallie", "Waters", "dHS6SZO9qF", 1, "Princess_Lind" },
                    { 46, 89, "Baylee70@yahoo.com", "Ellis", "Gaylord", "hKDD0wn_CV", 1, "Jedidiah.Marquardt44" },
                    { 193, 40, "Edwina83@hotmail.com", "Dannie", "Becker", "7GZC9cqdex", 2, "Myles52" },
                    { 127, 40, "Grover.Botsford22@yahoo.com", "Trent", "Mayert", "cjLH2Rr00K", 2, "Crystal64" },
                    { 94, 40, "Hipolito_Harvey91@yahoo.com", "Drake", "Smith", "XNod4wqKqu", 2, "Nicolas43" },
                    { 245, 253, "Nigel_Rogahn64@yahoo.com", "Crawford", "O'Conner", "CrAdWKl2lD", 2, "Rhea.Wisozk" },
                    { 244, 190, "Cordell_Mosciski@yahoo.com", "Hailey", "Stiedemann", "1q018xN5BI", 2, "Bridie.Schiller14" },
                    { 30, 253, "Esteban_Casper@gmail.com", "Chance", "Champlin", "GHmoFj5Ug3", 2, "Lexus_Kulas46" },
                    { 228, 130, "Emie_Bashirian4@hotmail.com", "Kathlyn", "Heaney", "xs6Jaqa8ZG", 3, "Bethel17" },
                    { 151, 130, "Manley_Ernser38@yahoo.com", "Brenda", "Thiel", "3Cs8uik95f", 2, "Danny_Leuschke" },
                    { 278, 158, "Pascale_Bednar4@gmail.com", "Darius", "Hansen", "rQGrt8EgqP", 1, "Meggie.Welch47" },
                    { 184, 139, "Sammy45@gmail.com", "Orrin", "Pollich", "PY7WxC0TSd", 3, "Berniece.Feil28" },
                    { 237, 116, "Lavada.Bayer@hotmail.com", "Pete", "Wiza", "cLHJ6rKHZq", 3, "Johanna20" },
                    { 223, 116, "Cindy.Runte@gmail.com", "Liana", "Baumbach", "fDN0_iS_kO", 2, "Alfredo62" },
                    { 240, 267, "Cathrine_Lueilwitz@hotmail.com", "Burnice", "Legros", "qY2ZDrpC0q", 1, "Lucious_Hirthe" },
                    { 129, 208, "Noah27@yahoo.com", "Ottis", "O'Reilly", "i_pC13nPzv", 1, "Lew63" },
                    { 255, 23, "Jacynthe87@gmail.com", "Lempi", "Braun", "yVoICXT2f0", 1, "Nico.Keeling20" },
                    { 14, 159, "Dale52@gmail.com", "Laurence", "Torp", "M2X1w9qppS", 3, "Henri.Stanton" },
                    { 27, 160, "Johnny76@yahoo.com", "Darien", "Vandervort", "DTAo38maNQ", 2, "Roxanne21" },
                    { 219, 286, "Malvina44@hotmail.com", "Creola", "Pagac", "z4r4reUbHR", 1, "Annalise57" },
                    { 209, 72, "Joanne69@gmail.com", "Taya", "Stanton", "dMRyN_uswO", 1, "Erica83" },
                    { 37, 60, "Duane61@hotmail.com", "Tristian", "Quitzon", "E1gwSLRKWU", 1, "Magdalena_Greenholt" },
                    { 51, 230, "Tillman.Dach53@yahoo.com", "Connor", "Carter", "Ew4fvdrJW2", 1, "Margie.Bechtelar" },
                    { 8, 230, "Gust3@yahoo.com", "Faustino", "Steuber", "gnchNqXmM_", 2, "Terrance.Maggio26" },
                    { 216, 191, "Niko97@gmail.com", "Vivienne", "Little", "9Iw48kevxb", 3, "Dorcas_Marks" },
                    { 287, 33, "Joseph3@gmail.com", "Cleo", "O'Hara", "amGYLabKxY", 3, "Miles.Lakin26" },
                    { 107, 33, "Bailey.Metz@yahoo.com", "Brook", "Lemke", "rWXr2gCzna", 1, "Nick.OConnell16" },
                    { 175, 38, "Fidel13@yahoo.com", "Alexys", "Witting", "kGrlsb_ut6", 1, "Joanne.Ryan" },
                    { 128, 38, "Humberto_Klocko@yahoo.com", "Mariana", "Harris", "CRp9DDJWv5", 2, "Eulah.Metz" },
                    { 96, 38, "Amara_Ankunding@hotmail.com", "Faustino", "Monahan", "G0tBdgJykH", 3, "Isadore_Shanahan" },
                    { 63, 38, "Cloyd_Kautzer@yahoo.com", "Verner", "Larkin", "lAEfoBSNBe", 2, "Mattie.Prosacco" },
                    { 253, 27, "Abel_Haley@yahoo.com", "Tristian", "Greenfelder", "pqPFT0Tckc", 3, "Candelario77" },
                    { 220, 163, "Dan3@yahoo.com", "Jaydon", "Hermann", "BZ8IkCdBHH", 2, "Terrill.Gulgowski51" },
                    { 62, 129, "Leonardo.Weissnat29@gmail.com", "Kiarra", "Grant", "RRTyTtpq2B", 2, "Rory_Carter96" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 296, 79, "Caleb.Goldner83@gmail.com", "Maverick", "Daugherty", "KUypru9aKo", 1, "Roger4" },
                    { 204, 79, "Stan.Walter@hotmail.com", "Yolanda", "Predovic", "apRwTtxxPW", 1, "Willy_Harvey69" },
                    { 13, 79, "Clarissa.Bruen@yahoo.com", "Julie", "Koelpin", "pBJZoXRC6z", 3, "Jovan_Dietrich66" },
                    { 28, 59, "Noah.Rogahn19@yahoo.com", "Yasmin", "Boyle", "ZuO_FL9q10", 3, "Eugenia.Abbott49" },
                    { 52, 280, "Robin_Medhurst@yahoo.com", "Desiree", "Gleason", "4D7RXpPcAv", 1, "Delfina.Pollich6" },
                    { 168, 67, "Hanna_Reilly82@yahoo.com", "Abbey", "Brekke", "0y5eiKFkwm", 1, "Manuela30" },
                    { 186, 60, "Ladarius.Schmitt@hotmail.com", "Greyson", "Blick", "6c91VK3_me", 3, "Alene30" },
                    { 60, 67, "Amely_Wintheiser@gmail.com", "Antonina", "Simonis", "6PTItsSBCh", 2, "Lamar80" },
                    { 19, 204, "Maryam66@yahoo.com", "Sydney", "Schneider", "uIzeZZBWlM", 3, "Gudrun78" },
                    { 226, 188, "Thurman16@gmail.com", "Gonzalo", "Stoltenberg", "2koHkG5Jtv", 2, "Idell43" },
                    { 153, 97, "Tiana71@gmail.com", "Ethan", "Morar", "kiTAhP11Ju", 3, "Mossie27" },
                    { 131, 97, "Aniyah.Sporer@gmail.com", "Benedict", "Shields", "LJvdGa0eAH", 2, "Junior_McDermott27" },
                    { 213, 225, "Lillian3@hotmail.com", "Bertha", "Funk", "falsICYWLd", 3, "Octavia.Ruecker95" },
                    { 265, 161, "Adam_Hayes13@hotmail.com", "Tyler", "Gislason", "aPEbQm1MFX", 3, "Ashlynn_Wisozk22" },
                    { 126, 161, "Lorine.Bayer76@gmail.com", "Myah", "Berge", "RqiHMEYCCG", 2, "Lee89" },
                    { 158, 113, "Asha_Hermiston@yahoo.com", "Andreanne", "Johnson", "gVvX1aEUSu", 3, "Briana_Schinner74" },
                    { 99, 216, "Carolyn3@hotmail.com", "Jordane", "Hamill", "6IzH2A7Bic", 1, "Napoleon.Fadel70" },
                    { 292, 34, "Clarissa.Lesch73@hotmail.com", "Natasha", "Schneider", "IleGesR5Nx", 1, "Gianni_Schmidt" },
                    { 188, 34, "Yessenia_Feest@yahoo.com", "Adelle", "Dare", "XU8POIoDK6", 3, "Amelie.Altenwerth" },
                    { 29, 34, "Glen80@gmail.com", "Melany", "Kihn", "0u14AkRlkG", 1, "Carolyn88" },
                    { 86, 152, "Garfield_Sanford@yahoo.com", "Christa", "Doyle", "r_CiQrnQpU", 3, "Paxton_Goldner" },
                    { 17, 197, "Silas_Osinski@gmail.com", "Allan", "Paucek", "mdk91iEGAp", 1, "Emie_Kessler" },
                    { 73, 24, "Hilbert.Gibson@hotmail.com", "Arne", "Stoltenberg", "T6qGjl9PRZ", 2, "Stone_Walker" },
                    { 266, 142, "Sebastian.Schultz53@yahoo.com", "Lew", "Nienow", "Qt6caTy3RX", 2, "Jeanette.Cummerata" },
                    { 222, 142, "Marcelo_Dickinson88@yahoo.com", "Orie", "Runolfsson", "U217dIfiWV", 2, "Alexandra_MacGyver" },
                    { 214, 142, "Ona52@hotmail.com", "Fernando", "Langosh", "BCBEdFsOdp", 3, "Evans.Swaniawski29" },
                    { 183, 137, "Melba63@gmail.com", "Winfield", "Pollich", "2fa5QNuTB8", 1, "Ladarius.Boehm42" },
                    { 272, 121, "Jayme.Gerhold@hotmail.com", "Destiny", "Gutmann", "GjD9qV7Ygi", 2, "Chyna13" },
                    { 229, 188, "Rafaela14@hotmail.com", "Marilou", "Macejkovic", "QE421eBnap", 3, "Marianne25" },
                    { 120, 204, "Shad.Williamson61@gmail.com", "Dovie", "Jacobs", "7PVEeuxZSF", 1, "Landen_Roberts64" },
                    { 12, 67, "Ivah.Konopelski10@yahoo.com", "Ewell", "Jacobi", "RRnKq8O3rL", 2, "Frances_Rogahn71" },
                    { 286, 22, "Maybell.Rohan@yahoo.com", "Violet", "Tremblay", "djedpV08oA", 2, "Deja89" },
                    { 72, 248, "Giovanna_Lowe@yahoo.com", "Brayan", "Kuphal", "b5x1v4VXPG", 3, "Bella18" },
                    { 22, 195, "Furman_Bruen3@hotmail.com", "Morris", "Kuhic", "GLcsBzJKGp", 1, "Aubree92" },
                    { 159, 186, "Maximus.Greenfelder@hotmail.com", "Lamont", "Mills", "iNji0_0wap", 2, "Rusty.OHara52" },
                    { 136, 144, "Terrance69@hotmail.com", "Christa", "Von", "s7UU6EQxsO", 2, "Hobart_Corwin" },
                    { 31, 76, "Isai93@hotmail.com", "Kaylee", "Towne", "FaOQDmXsON", 1, "Skyla91" },
                    { 59, 282, "Chasity63@gmail.com", "Boris", "Gleichner", "LlKobxkBdl", 2, "Ashley_Wolf9" },
                    { 177, 270, "Brock22@hotmail.com", "Jessyca", "Haag", "I6oZ3OZJXc", 1, "Gladys.Ward" },
                    { 256, 101, "Makenzie19@hotmail.com", "Jermaine", "Abshire", "DjsDhPB70d", 3, "Lorna_MacGyver" },
                    { 58, 101, "Stacey_Bergstrom27@gmail.com", "Keira", "Fay", "GTqjoo0450", 1, "Jacey63" },
                    { 288, 117, "Brando63@gmail.com", "Scotty", "Stoltenberg", "vVaGIKggBD", 2, "Cloyd.Daniel" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 218, 14, "Lamar.Stroman19@yahoo.com", "Tillman", "Stoltenberg", "tqIJ5aOG9n", 3, "Oliver68" },
                    { 83, 183, "Olin_Green@hotmail.com", "Gaetano", "Lockman", "H_xEZefeVj", 1, "Vinnie_Adams37" },
                    { 191, 180, "Abdul.Keebler95@gmail.com", "Minnie", "Beer", "BhKCm61VEb", 1, "Reuben.Murphy" },
                    { 66, 180, "Lizzie.Graham22@yahoo.com", "Kelly", "Bednar", "0K9W7oRmSJ", 2, "Berta26" },
                    { 258, 247, "Taryn_Fay25@gmail.com", "Duncan", "Towne", "RBySQxuao4", 1, "Ali_Friesen" },
                    { 173, 247, "Oceane.OConnell@gmail.com", "Ted", "Kuhic", "xjEXWqYXUR", 3, "Cleta.Vandervort31" },
                    { 169, 247, "Dudley_Marquardt@gmail.com", "Hobart", "Stamm", "AUXcQtyr1u", 2, "Alvena23" },
                    { 182, 178, "Jamil.Baumbach@yahoo.com", "Imogene", "Murazik", "s072eK3hsI", 2, "Kyle.Feeney71" },
                    { 199, 118, "Ted.Breitenberg23@yahoo.com", "Travon", "DuBuque", "VFimpm2kMa", 2, "Emelia.Hills" },
                    { 18, 118, "Rhoda.Orn69@gmail.com", "Jarod", "Schumm", "Cwe2y8k32i", 1, "Anita_Olson" },
                    { 145, 235, "Christina_Barton36@hotmail.com", "Chad", "Steuber", "CgvHrAS4cf", 2, "Mariam.Watsica" },
                    { 254, 235, "Markus_Jast75@yahoo.com", "Elmira", "Carter", "EQX4m6dsPm", 2, "Werner_Nienow43" },
                    { 274, 235, "Markus.Ondricka@hotmail.com", "Willow", "Kirlin", "zX1AWaOjiP", 2, "Rosina74" },
                    { 68, 39, "Elisha.Rogahn@hotmail.com", "Savanah", "Johnson", "IDkglBfVC_", 2, "Alessandra.Okuneva" },
                    { 197, 184, "Hanna.Kertzmann@hotmail.com", "Erling", "Larson", "f6AaO4MtYV", 1, "Nestor_Huels" },
                    { 225, 172, "Hiram_Spinka97@hotmail.com", "Liam", "Blick", "lMskbB8UN2", 2, "Kylee.Oberbrunner51" },
                    { 267, 87, "Arianna.Gutkowski@gmail.com", "Lemuel", "Mante", "aZJihypBav", 2, "Chase34" },
                    { 190, 87, "Lue.Dickinson@yahoo.com", "Ashlynn", "Morar", "qjJ4CDq1WK", 1, "Katarina.Lakin62" },
                    { 130, 6, "Hazle83@gmail.com", "Nasir", "Bartoletti", "FYB4NCcRFz", 1, "Nola_Cassin27" },
                    { 271, 214, "Aracely.Nader23@gmail.com", "Stephan", "Olson", "C4AkqHvEL4", 2, "Nicole.Wolff" },
                    { 242, 214, "Paolo81@yahoo.com", "Garrison", "Dietrich", "487UdrP6Wh", 3, "Rhiannon0" },
                    { 109, 171, "Elfrieda.Kilback51@gmail.com", "Dolores", "Waelchi", "J1bBWml2ce", 1, "Renee_Herzog" },
                    { 215, 5, "Adan2@yahoo.com", "Mabelle", "Goyette", "ZM6xaP3lqk", 1, "Pearline.Kuhn" },
                    { 181, 72, "Leonel.Corkery@gmail.com", "Jewell", "Lubowitz", "LeK3yUYKIn", 3, "Jarred_Bartoletti48" },
                    { 176, 284, "Evan17@gmail.com", "Chaz", "Powlowski", "4SiYMvdSwu", 3, "Toni.Hermann62" },
                    { 247, 88, "Rudolph_Krajcik@yahoo.com", "Cletus", "Mann", "msksNopPxF", 1, "Barney.Oberbrunner19" },
                    { 88, 88, "Leda_Schuster@hotmail.com", "Ethel", "Nolan", "sFL0BLB6Ow", 3, "Declan.Bruen12" },
                    { 84, 141, "Trey.McClure8@gmail.com", "Edgardo", "Kiehn", "O749BYFmv_", 3, "Jeramy12" },
                    { 38, 141, "Dangelo96@yahoo.com", "Anthony", "Mueller", "DFg0_YJxfj", 1, "Marguerite25" },
                    { 298, 32, "Chris_Shields@hotmail.com", "Milton", "Grant", "eJ8ZX_7AAy", 3, "Rhett.MacGyver" },
                    { 172, 156, "Cloyd_Breitenberg61@hotmail.com", "Bernhard", "Bartoletti", "JI1ZzbmP_r", 2, "Cullen68" },
                    { 115, 156, "Kyleigh.Williamson@gmail.com", "Caleigh", "Kuhn", "jo1G9HGqyA", 2, "Chris30" },
                    { 93, 272, "Selina.Weissnat58@gmail.com", "Connor", "Ullrich", "g0VCMdJrnh", 2, "Trinity.Hahn10" },
                    { 11, 115, "Tyreek.Schuppe88@yahoo.com", "Hildegard", "Auer", "ci3p3Uz3wN", 2, "Lydia_Witting" },
                    { 297, 256, "Aditya_Moore@gmail.com", "Vernon", "Wintheiser", "8o_IMNWzvS", 1, "Eli_Sipes68" },
                    { 230, 81, "Catharine.Rosenbaum@yahoo.com", "Ernie", "Braun", "QusSKscG6b", 3, "Birdie.Veum77" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 62, "Guillermo Lakes", 212, "Jason39@hotmail.com", "Sanford, Gislason and Littel", 230, "(178) 268-7971", "www.Sanford, Gislason and Littel.com" },
                    { 78, "Hegmann Corners", 272, "Flo_Bauch62@gmail.com", "Rippin - Donnelly", 5, "(953) 948-9362", "www.Rippin - Donnelly.com" },
                    { 94, "Blair Tunnel", 78, "Chase.Bartoletti@yahoo.com", "Morar - Rempel", 263, "(667) 021-9776", "www.Morar - Rempel.com" },
                    { 57, "Effertz Mill", 55, "Mavis20@gmail.com", "Larkin, Jacobs and Bernier", 249, "(779) 192-6052", "www.Larkin, Jacobs and Bernier.com" },
                    { 6, "Aurelie Forge", 25, "Erica_Boehm78@yahoo.com", "Daniel, Hermiston and Ankunding", 234, "(268) 544-0806", "www.Daniel, Hermiston and Ankunding.com" },
                    { 143, "Edyth Pine", 64, "Cora_Bogan24@yahoo.com", "Bogan Inc", 234, "(190) 172-2079", "www.Bogan Inc.com" },
                    { 32, "Kunze Lodge", 242, "Brett70@gmail.com", "Littel, Lind and Carter", 283, "(242) 685-0146", "www.Littel, Lind and Carter.com" },
                    { 119, "Sydney Alley", 115, "Joe.Terry@yahoo.com", "Kohler LLC", 262, "(603) 600-7004", "www.Kohler LLC.com" },
                    { 50, "Hilpert Ranch", 156, "Reina95@gmail.com", "Lakin - Dibbert", 224, "(794) 709-7382", "www.Lakin - Dibbert.com" },
                    { 92, "Glover Unions", 181, "Lavern_Zboncak@yahoo.com", "Howe - Bartoletti", 224, "(803) 521-1064", "www.Howe - Bartoletti.com" },
                    { 115, "Bins Springs", 170, "Vesta58@gmail.com", "Johns Group", 224, "(768) 677-4410", "www.Johns Group.com" },
                    { 72, "Aufderhar Manors", 269, "Billie.Pollich20@yahoo.com", "Pouros - Rippin", 170, "(624) 886-0167", "www.Pouros - Rippin.com" },
                    { 90, "Haleigh Track", 144, "Noelia.Nitzsche@hotmail.com", "Leffler - Thiel", 170, "(549) 006-0268", "www.Leffler - Thiel.com" },
                    { 107, "Leann Lake", 269, "Evangeline.Lowe68@yahoo.com", "Shields Group", 170, "(971) 341-3449", "www.Shields Group.com" },
                    { 95, "Emiliano Knolls", 83, "Braden56@yahoo.com", "Stamm, Von and Murazik", 4, "(330) 510-3169", "www.Stamm, Von and Murazik.com" },
                    { 130, "Kozey Roads", 300, "Mollie.Miller83@hotmail.com", "Dickens Inc", 4, "(852) 233-9560", "www.Dickens Inc.com" },
                    { 64, "Beahan Canyon", 116, "Davin.Hyatt@hotmail.com", "Champlin - Parker", 5, "(476) 930-5394", "www.Champlin - Parker.com" },
                    { 7, "Maxine Islands", 186, "Ottis.Heathcote@yahoo.com", "Kessler, Medhurst and Pfeffer", 252, "(119) 746-8216", "www.Kessler, Medhurst and Pfeffer.com" },
                    { 14, "Addie Common", 54, "Jed.Cole70@gmail.com", "Goyette, Gulgowski and Shanahan", 5, "(359) 993-1390", "www.Goyette, Gulgowski and Shanahan.com" },
                    { 74, "Sabina Underpass", 59, "Lorenz_Jones3@hotmail.com", "Keeling LLC", 132, "(400) 127-2813", "www.Keeling LLC.com" },
                    { 21, "Walsh Squares", 232, "Scottie_Fisher@gmail.com", "Cruickshank Inc", 19, "(968) 662-1360", "www.Cruickshank Inc.com" },
                    { 54, "Langosh Cliff", 110, "Lois_Metz@hotmail.com", "Greenholt LLC", 19, "(899) 315-2630", "www.Greenholt LLC.com" },
                    { 100, "Blake Mountain", 126, "Mertie_Schroeder@yahoo.com", "Stehr - Bartoletti", 229, "(828) 261-4613", "www.Stehr - Bartoletti.com" },
                    { 25, "Moen Mall", 153, "Allan78@gmail.com", "Bechtelar and Sons", 86, "(238) 811-0860", "www.Bechtelar and Sons.com" },
                    { 26, "Tracey Run", 3, "Winifred3@gmail.com", "Kub and Sons", 86, "(861) 451-6170", "www.Kub and Sons.com" },
                    { 51, "Raynor Mews", 190, "Jared46@yahoo.com", "Green Inc", 86, "(154) 527-0201", "www.Green Inc.com" },
                    { 86, "Marianne Islands", 128, "Hayden_Spinka@hotmail.com", "Senger Inc", 86, "(779) 646-8037", "www.Senger Inc.com" },
                    { 38, "Paolo Gateway", 270, "Lempi.Oberbrunner@hotmail.com", "Nitzsche Inc", 188, "(900) 890-9604", "www.Nitzsche Inc.com" },
                    { 140, "Wolf Centers", 244, "Grayson35@hotmail.com", "Luettgen - Torphy", 158, "(646) 016-3035", "www.Luettgen - Torphy.com" },
                    { 31, "Jeromy Gardens", 66, "Antonetta_Glover39@gmail.com", "Casper, Robel and Kassulke", 265, "(666) 011-0698", "www.Casper, Robel and Kassulke.com" },
                    { 137, "Weber Plaza", 13, "Mikel.Crist32@hotmail.com", "Dibbert - Bernier", 153, "(187) 948-6666", "www.Dibbert - Bernier.com" },
                    { 42, "Jayce Hill", 47, "Adaline.Mayert44@hotmail.com", "Botsford - Runte", 277, "(567) 911-5699", "www.Botsford - Runte.com" },
                    { 59, "Lorena Field", 14, "Betty_Willms@gmail.com", "Brown and Sons", 277, "(866) 063-5563", "www.Brown and Sons.com" },
                    { 33, "Stanton Ridges", 99, "Viviane98@hotmail.com", "Lehner Group", 261, "(408) 975-5801", "www.Lehner Group.com" },
                    { 113, "Collier Tunnel", 174, "Emilia3@yahoo.com", "Barrows, Gottlieb and Mayert", 261, "(504) 797-6387", "www.Barrows, Gottlieb and Mayert.com" },
                    { 124, "Dare Trail", 51, "Damien.Renner@hotmail.com", "Kirlin - Koelpin", 248, "(569) 701-1084", "www.Kirlin - Koelpin.com" },
                    { 123, "Wilfredo Forks", 107, "Joelle.Kling10@gmail.com", "Boehm, Halvorson and O'Connell", 186, "(497) 948-8596", "www.Boehm, Halvorson and O'Connell.com" },
                    { 10, "Giovanny Mountains", 206, "Michale.Kertzmann@hotmail.com", "Leuschke and Sons", 252, "(345) 223-8213", "www.Leuschke and Sons.com" },
                    { 49, "Carey Groves", 74, "Reagan.Wyman47@hotmail.com", "Grady Inc", 252, "(761) 449-2222", "www.Grady Inc.com" },
                    { 9, "Green Rue", 139, "Jaiden.Wuckert13@yahoo.com", "Ward, Hoppe and Hickle", 163, "(297) 378-7564", "www.Ward, Hoppe and Hickle.com" },
                    { 13, "Gino Ford", 141, "Travis_Raynor@gmail.com", "Bogisich, Wehner and King", 163, "(290) 328-6420", "www.Bogisich, Wehner and King.com" },
                    { 46, "Breitenberg Street", 242, "Augusta_Blanda@gmail.com", "Waters LLC", 163, "(833) 770-5228", "www.Waters LLC.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 47, "Yost Junctions", 32, "Emmy_Dickens@yahoo.com", "Prohaska LLC", 163, "(463) 648-8449", "www.Prohaska LLC.com" },
                    { 73, "Kole Rapids", 80, "Kayley37@yahoo.com", "Bernier, Bosco and Johnson", 163, "(973) 529-4921", "www.Bernier, Bosco and Johnson.com" },
                    { 84, "Neha Crossroad", 162, "Mara_Fritsch@yahoo.com", "Marquardt - Howe", 163, "(802) 212-9444", "www.Marquardt - Howe.com" },
                    { 118, "Hane Spur", 164, "Destany_Zulauf25@yahoo.com", "Feeney, Jacobs and Bernier", 163, "(180) 661-7905", "www.Feeney, Jacobs and Bernier.com" },
                    { 101, "Torp Forks", 67, "Braulio_Wisoky65@yahoo.com", "Thiel - Erdman", 212, "(743) 393-9004", "www.Thiel - Erdman.com" },
                    { 129, "Maxine Cliffs", 230, "Parker40@yahoo.com", "Luettgen - Kohler", 212, "(663) 838-4605", "www.Luettgen - Kohler.com" },
                    { 11, "Abdullah Freeway", 137, "Jennie_Gerlach@gmail.com", "Schowalter Group", 67, "(608) 277-9894", "www.Schowalter Group.com" },
                    { 16, "Margarete Walk", 256, "Joshuah.Harris@hotmail.com", "Murazik, Dach and Glover", 67, "(366) 518-6657", "www.Murazik, Dach and Glover.com" },
                    { 56, "Icie Neck", 260, "Enrique37@hotmail.com", "Veum, Howell and Harris", 67, "(063) 897-2014", "www.Veum, Howell and Harris.com" },
                    { 19, "Haag Stravenue", 54, "Milo.Halvorson@hotmail.com", "Pagac - Greenfelder", 160, "(274) 878-3353", "www.Pagac - Greenfelder.com" },
                    { 82, "Ullrich Lake", 23, "Jeanie_OReilly15@yahoo.com", "Hauck Group", 241, "(188) 991-4043", "www.Hauck Group.com" },
                    { 144, "Genevieve Plains", 65, "Cesar_Hamill38@hotmail.com", "Green Group", 241, "(282) 082-5498", "www.Green Group.com" },
                    { 126, "Labadie Cove", 215, "Rachael.Blanda3@hotmail.com", "Harris LLC", 196, "(013) 632-6087", "www.Harris LLC.com" },
                    { 28, "Misael Villages", 53, "Reta.Wyman83@gmail.com", "Haley - Gutkowski", 252, "(609) 220-2096", "www.Haley - Gutkowski.com" },
                    { 127, "Demarcus Plain", 294, "Nya.Parker51@gmail.com", "Koepp - Sporer", 56, "(684) 316-1993", "www.Koepp - Sporer.com" },
                    { 22, "Rolfson Springs", 52, "Giovani.Dickens@gmail.com", "Zulauf Group", 56, "(937) 940-3337", "www.Zulauf Group.com" },
                    { 76, "Kirlin Trace", 232, "Giovanny29@yahoo.com", "O'Keefe, Schneider and Larson", 252, "(939) 122-4986", "www.O'Keefe, Schneider and Larson.com" },
                    { 145, "Wuckert Freeway", 80, "Joel.Hansen73@gmail.com", "Runte, Doyle and Swift", 252, "(909) 884-0639", "www.Runte, Doyle and Swift.com" },
                    { 71, "Angelina Loop", 22, "Taurean_Douglas@gmail.com", "Emard Group", 95, "(608) 305-4263", "www.Emard Group.com" },
                    { 29, "Maxine Forge", 27, "Kiera_Fay@yahoo.com", "Russel Group", 210, "(553) 241-4642", "www.Russel Group.com" },
                    { 131, "Herzog Corner", 240, "Brook93@hotmail.com", "McKenzie - Shanahan", 210, "(880) 235-9343", "www.McKenzie - Shanahan.com" },
                    { 80, "Lakin Wall", 69, "Louvenia85@yahoo.com", "Feil - Moore", 65, "(146) 098-1952", "www.Feil - Moore.com" },
                    { 5, "Eliane Dale", 174, "Dakota.Farrell55@gmail.com", "Herzog - Schuster", 144, "(606) 180-5902", "www.Herzog - Schuster.com" },
                    { 55, "Freddie Flats", 160, "Lon_Willms@yahoo.com", "Padberg - MacGyver", 144, "(995) 798-1693", "www.Padberg - MacGyver.com" },
                    { 98, "Henry Bypass", 297, "Efrain.Effertz99@hotmail.com", "Cummerata - Towne", 144, "(505) 840-3208", "www.Cummerata - Towne.com" },
                    { 148, "Murphy Skyway", 25, "Verdie8@gmail.com", "Gutmann and Sons", 144, "(612) 310-1015", "www.Gutmann and Sons.com" },
                    { 79, "Leuschke Cape", 45, "Bernadette_MacGyver@gmail.com", "Wolff, Collins and Gorczany", 9, "(993) 680-7190", "www.Wolff, Collins and Gorczany.com" },
                    { 85, "Conn Harbor", 287, "Ludwig94@hotmail.com", "Batz Inc", 9, "(582) 818-6016", "www.Batz Inc.com" },
                    { 135, "Hintz Neck", 255, "Griffin.Thompson@yahoo.com", "Raynor - Emard", 9, "(075) 617-1298", "www.Raynor - Emard.com" },
                    { 83, "Lucius Forest", 259, "Taurean_Fay@hotmail.com", "Kulas, Homenick and Lesch", 100, "(209) 418-2393", "www.Kulas, Homenick and Lesch.com" },
                    { 60, "Ella Summit", 198, "Cary70@yahoo.com", "Greenfelder LLC", 148, "(400) 204-3044", "www.Greenfelder LLC.com" },
                    { 104, "Kirlin Islands", 204, "Keeley.Hickle@gmail.com", "Okuneva - Beahan", 56, "(330) 338-1323", "www.Okuneva - Beahan.com" },
                    { 44, "Kolby Point", 30, "Rasheed35@yahoo.com", "Klocko Inc", 287, "(353) 909-8856", "www.Klocko Inc.com" },
                    { 138, "Domenick Inlet", 225, "Marco11@gmail.com", "Cole, Koch and Orn", 148, "(715) 421-7392", "www.Cole, Koch and Orn.com" },
                    { 122, "Borer Land", 125, "Makenzie_Daniel@yahoo.com", "Kuhic - Simonis", 96, "(121) 406-7654", "www.Kuhic - Simonis.com" },
                    { 27, "Anderson Field", 242, "Marques.Kuphal89@hotmail.com", "Waelchi Inc", 184, "(076) 971-7727", "www.Waelchi Inc.com" },
                    { 39, "Einar Crescent", 137, "Aleen28@yahoo.com", "Blanda Inc", 228, "(338) 462-4932", "www.Blanda Inc.com" },
                    { 20, "Sporer Island", 65, "Marjolaine83@gmail.com", "Marvin, Rolfson and Metz", 147, "(896) 400-8825", "www.Marvin, Rolfson and Metz.com" },
                    { 110, "Giles Locks", 231, "Jonathan.Weimann28@hotmail.com", "Macejkovic, Bahringer and Terry", 89, "(935) 976-7370", "www.Macejkovic, Bahringer and Terry.com" },
                    { 136, "Herman Village", 98, "Ottis56@gmail.com", "Kihn - Ebert", 89, "(503) 902-4579", "www.Kihn - Ebert.com" },
                    { 112, "Weissnat View", 277, "Angelina20@yahoo.com", "D'Amore Inc", 282, "(357) 352-2623", "www.D'Amore Inc.com" },
                    { 15, "Maryam Underpass", 55, "Jodie.Upton42@yahoo.com", "Sporer - Johns", 198, "(276) 164-7962", "www.Sporer - Johns.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 1, "Brakus Highway", 187, "Gardner_Berge65@gmail.com", "Considine, Gislason and Beier", 41, "(648) 918-3262", "www.Considine, Gislason and Beier.com" },
                    { 43, "Stracke Highway", 9, "Devin89@yahoo.com", "Borer, Bosco and Ortiz", 41, "(541) 846-0339", "www.Borer, Bosco and Ortiz.com" },
                    { 133, "Cole Prairie", 49, "Katherine29@yahoo.com", "Hartmann and Sons", 26, "(500) 580-6938", "www.Hartmann and Sons.com" },
                    { 106, "Keebler Streets", 92, "Haylie.Ebert@gmail.com", "Pagac and Sons", 299, "(794) 472-7569", "www.Pagac and Sons.com" },
                    { 132, "Giovani Mews", 79, "Mervin15@yahoo.com", "Yost - Bergstrom", 299, "(858) 042-1249", "www.Yost - Bergstrom.com" },
                    { 103, "Liliana Point", 56, "Antonietta86@hotmail.com", "Kling, Hodkiewicz and Howe", 106, "(858) 966-0013", "www.Kling, Hodkiewicz and Howe.com" },
                    { 17, "Ronaldo Camp", 112, "Kennedy.Kessler@yahoo.com", "Farrell, Frami and Littel", 268, "(739) 268-3049", "www.Farrell, Frami and Littel.com" },
                    { 34, "Sawayn Place", 241, "Lyric_Harvey@gmail.com", "Carroll - Ryan", 268, "(362) 281-7597", "www.Carroll - Ryan.com" },
                    { 125, "Gustave Skyway", 25, "Allen.Jones17@hotmail.com", "Paucek - Veum", 237, "(129) 439-9094", "www.Paucek - Veum.com" },
                    { 91, "Zieme Mews", 242, "Kariane.Corwin@hotmail.com", "Breitenberg LLC", 268, "(605) 007-9261", "www.Breitenberg LLC.com" },
                    { 8, "Hartmann Forge", 252, "Avery54@gmail.com", "Kling Group", 42, "(246) 232-2422", "www.Kling Group.com" },
                    { 88, "Litzy Green", 228, "Yadira.Jacobs@yahoo.com", "Flatley - Feil", 76, "(226) 132-7502", "www.Flatley - Feil.com" },
                    { 24, "Stroman Highway", 253, "Lucio_Kuhic83@yahoo.com", "Kihn Inc", 287, "(013) 100-8040", "www.Kihn Inc.com" },
                    { 65, "Rath Trail", 122, "Modesta.Wolff32@gmail.com", "Kuphal, Ondricka and Tromp", 230, "(299) 399-0508", "www.Kuphal, Ondricka and Tromp.com" },
                    { 108, "Legros Union", 158, "Everett.Hand@gmail.com", "Ernser, Kerluke and Rau", 230, "(876) 896-0815", "www.Ernser, Kerluke and Rau.com" },
                    { 68, "Toy Street", 241, "Art_Schmidt26@hotmail.com", "Halvorson - Thiel", 36, "(582) 069-2963", "www.Halvorson - Thiel.com" },
                    { 128, "Josianne Summit", 172, "Sylvia_Greenfelder@gmail.com", "Gutkowski - Zboncak", 232, "(611) 326-9665", "www.Gutkowski - Zboncak.com" },
                    { 2, "Jacobi Mill", 54, "Stanley42@yahoo.com", "Mohr - Trantow", 32, "(700) 135-9148", "www.Mohr - Trantow.com" },
                    { 114, "Shea Landing", 174, "Jonatan_OHara@hotmail.com", "Johns - Keeling", 32, "(496) 813-2122", "www.Johns - Keeling.com" },
                    { 102, "Hackett Spurs", 203, "Emelie37@yahoo.com", "Kreiger, Crona and Altenwerth", 3, "(773) 291-4001", "www.Kreiger, Crona and Altenwerth.com" },
                    { 40, "Mikayla Mission", 163, "Lenna_Hegmann@gmail.com", "McClure LLC", 290, "(989) 435-1098", "www.McClure LLC.com" },
                    { 81, "Celine Fork", 16, "Wilhelmine75@gmail.com", "Smith LLC", 290, "(765) 351-8067", "www.Smith LLC.com" },
                    { 61, "Veronica Mount", 278, "Juwan27@gmail.com", "Kris, Huel and Treutel", 69, "(860) 561-1051", "www.Kris, Huel and Treutel.com" },
                    { 134, "Elliott Vista", 288, "Mose81@yahoo.com", "Murray - Graham", 23, "(693) 674-1975", "www.Murray - Graham.com" },
                    { 141, "Haley Locks", 264, "Hilbert24@gmail.com", "Bode, Herzog and Weissnat", 23, "(807) 367-5705", "www.Bode, Herzog and Weissnat.com" },
                    { 3, "Dietrich Cliff", 116, "Cesar21@hotmail.com", "Daugherty - Johnston", 217, "(219) 504-6908", "www.Daugherty - Johnston.com" },
                    { 139, "Marguerite Route", 162, "Clifford_Jacobs@gmail.com", "Cronin and Sons", 217, "(543) 711-6362", "www.Cronin and Sons.com" },
                    { 89, "Jacobi Shoal", 216, "Nina17@yahoo.com", "Nikolaus, Jaskolski and Hartmann", 76, "(645) 995-1911", "www.Nikolaus, Jaskolski and Hartmann.com" },
                    { 93, "Lewis Walk", 47, "Daphnee50@hotmail.com", "Green LLC", 268, "(269) 914-3202", "www.Green LLC.com" },
                    { 147, "Toby Mews", 220, "Hildegard.Macejkovic@yahoo.com", "Hayes LLC", 290, "(488) 040-9049", "www.Hayes LLC.com" },
                    { 37, "Melody Parks", 266, "Elias_Denesik13@hotmail.com", "Hayes - McLaughlin", 227, "(384) 115-8632", "www.Hayes - McLaughlin.com" },
                    { 70, "Jonatan Stream", 256, "Brennon_MacGyver96@hotmail.com", "Waelchi - Kovacek", 97, "(008) 653-5755", "www.Waelchi - Kovacek.com" },
                    { 87, "Krajcik Cliffs", 167, "Chadrick.DuBuque@gmail.com", "Kunde and Sons", 97, "(337) 645-0087", "www.Kunde and Sons.com" },
                    { 4, "Schroeder Wells", 241, "Alvera_Wisoky91@yahoo.com", "Feil - Wiza", 181, "(528) 247-3446", "www.Feil - Wiza.com" },
                    { 121, "Senger Glen", 111, "Santos87@yahoo.com", "Heller Group", 181, "(443) 146-5060", "www.Heller Group.com" },
                    { 142, "Brock Vista", 287, "Fred4@gmail.com", "Dach, Cole and Lemke", 181, "(002) 370-9517", "www.Dach, Cole and Lemke.com" },
                    { 30, "Pollich Rapids", 94, "Maudie54@hotmail.com", "Wintheiser, Little and Klocko", 218, "(198) 251-4430", "www.Wintheiser, Little and Klocko.com" },
                    { 146, "Donnelly Ranch", 89, "Annie74@yahoo.com", "Bailey - Kirlin", 298, "(930) 609-4101", "www.Bailey - Kirlin.com" },
                    { 23, "Hauck Turnpike", 126, "Mohammed67@yahoo.com", "Lowe, Friesen and Thiel", 72, "(015) 784-0998", "www.Lowe, Friesen and Thiel.com" },
                    { 150, "Janelle Tunnel", 142, "Johnathon40@gmail.com", "Rogahn, Orn and Hintz", 72, "(346) 809-1457", "www.Rogahn, Orn and Hintz.com" },
                    { 67, "Bernice Estate", 173, "Ellie69@hotmail.com", "Leannon - Erdman", 28, "(341) 712-1369", "www.Leannon - Erdman.com" },
                    { 99, "Zack Common", 258, "Marjolaine_Metz@yahoo.com", "Skiles, Donnelly and Jakubowski", 28, "(257) 523-5033", "www.Skiles, Donnelly and Jakubowski.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 12, "Wilderman Extension", 131, "Alba.Block@yahoo.com", "Hudson - Bernhard", 13, "(495) 791-5795", "www.Hudson - Bernhard.com" },
                    { 77, "Koelpin Lakes", 111, "William_Harvey48@yahoo.com", "Gaylord Inc", 13, "(381) 009-0795", "www.Gaylord Inc.com" },
                    { 105, "Lakin Parkway", 24, "Drake99@yahoo.com", "Hartmann - Powlowski", 268, "(543) 398-2091", "www.Hartmann - Powlowski.com" },
                    { 97, "Medhurst River", 185, "Piper.Trantow50@yahoo.com", "Stokes LLC", 96, "(112) 845-9079", "www.Stokes LLC.com" },
                    { 120, "Will Ranch", 69, "Brisa_Weber81@hotmail.com", "Balistreri - Adams", 101, "(787) 489-8503", "www.Balistreri - Adams.com" },
                    { 63, "Halvorson Stravenue", 78, "Vivian.Johnston25@yahoo.com", "Doyle and Sons", 101, "(115) 155-2103", "www.Doyle and Sons.com" },
                    { 36, "Rhianna Divide", 26, "Kimberly.Feeney@hotmail.com", "Cummerata Inc", 72, "(306) 669-7237", "www.Cummerata Inc.com" },
                    { 41, "Windler Mission", 44, "Pattie.Blanda@hotmail.com", "Wisoky - Kutch", 101, "(414) 452-6387", "www.Wisoky - Kutch.com" },
                    { 58, "Alene Dam", 260, "Aleen_Bruen2@hotmail.com", "Dicki - Jerde", 101, "(657) 150-2552", "www.Dicki - Jerde.com" },
                    { 53, "Waters Skyway", 78, "Guy89@hotmail.com", "Jakubowski, Hansen and Boyer", 227, "(672) 240-0911", "www.Jakubowski, Hansen and Boyer.com" },
                    { 75, "Catherine Shoal", 55, "Christop_Berge@gmail.com", "Brown, Greenholt and Kuhn", 85, "(633) 486-1519", "www.Brown, Greenholt and Kuhn.com" },
                    { 109, "O'Keefe Islands", 219, "Kellie4@hotmail.com", "Abshire - Rowe", 85, "(145) 759-3047", "www.Abshire - Rowe.com" },
                    { 48, "Vandervort Crest", 120, "Hyman.Braun@yahoo.com", "Emard - Mayert", 152, "(134) 085-2431", "www.Emard - Mayert.com" },
                    { 45, "Erdman Cliff", 97, "Ahmad.Kiehn@hotmail.com", "Conroy, Ratke and Krajcik", 85, "(818) 770-9403", "www.Conroy, Ratke and Krajcik.com" },
                    { 66, "Bailee Fords", 51, "Ally0@yahoo.com", "Hilpert, Ziemann and Crist", 15, "(872) 217-9176", "www.Hilpert, Ziemann and Crist.com" },
                    { 52, "Hammes Estate", 203, "Horace_Kunde96@yahoo.com", "Dooley and Sons", 78, "(373) 918-1804", "www.Dooley and Sons.com" },
                    { 18, "Orie Stravenue", 53, "Janae.Aufderhar17@hotmail.com", "Feil Group", 15, "(398) 067-9413", "www.Feil Group.com" },
                    { 116, "Conroy Forges", 239, "Josh_Kautzer3@hotmail.com", "Pacocha, Kshlerin and Trantow", 239, "(463) 018-3290", "www.Pacocha, Kshlerin and Trantow.com" },
                    { 35, "Janice Gateway", 152, "Deja.Paucek@yahoo.com", "Marvin - Keebler", 291, "(410) 659-8633", "www.Marvin - Keebler.com" },
                    { 96, "Nina Ville", 141, "Jarrell.Leuschke19@gmail.com", "Lueilwitz - Heaney", 291, "(394) 552-7777", "www.Lueilwitz - Heaney.com" },
                    { 111, "Feil Island", 258, "Frank32@yahoo.com", "Wisozk - Monahan", 114, "(073) 667-8546", "www.Wisozk - Monahan.com" },
                    { 117, "Gerda Junction", 219, "Felipe.Schaefer@gmail.com", "Roberts, Homenick and Lubowitz", 114, "(245) 670-0191", "www.Roberts, Homenick and Lubowitz.com" },
                    { 69, "Strosin Tunnel", 160, "Kenya.Koch@gmail.com", "Fritsch Group", 239, "(570) 039-4505", "www.Fritsch Group.com" },
                    { 149, "Flatley Summit", 104, "Maximus.Schaefer95@gmail.com", "Ebert LLC", 114, "(506) 195-5341", "www.Ebert LLC.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 51, new DateTime(2020, 10, 27, 20, 17, 52, 671, DateTimeKind.Local).AddTicks(3535), 567402, 96, "6214013" },
                    { 82, new DateTime(2020, 5, 19, 2, 11, 19, 787, DateTimeKind.Local).AddTicks(1820), 55775, 96, "9019243" },
                    { 8, new DateTime(2020, 11, 18, 10, 0, 27, 237, DateTimeKind.Local).AddTicks(309), 120203, 32, "1963355" },
                    { 9, new DateTime(2020, 12, 13, 11, 41, 13, 515, DateTimeKind.Local).AddTicks(8496), 834086, 21, "1164191" },
                    { 105, new DateTime(2020, 6, 12, 2, 8, 57, 574, DateTimeKind.Local).AddTicks(932), 123307, 21, "1846714" },
                    { 50, new DateTime(2020, 11, 21, 22, 32, 0, 249, DateTimeKind.Local).AddTicks(5089), 583372, 21, "4996971" },
                    { 6, new DateTime(2021, 3, 10, 6, 5, 4, 710, DateTimeKind.Local).AddTicks(9590), 274768, 42, "8089789" },
                    { 24, new DateTime(2020, 4, 21, 0, 14, 28, 205, DateTimeKind.Local).AddTicks(7808), 296457, 55, "6573709" },
                    { 80, new DateTime(2020, 7, 21, 23, 40, 23, 947, DateTimeKind.Local).AddTicks(2093), 625030, 42, "2721821" },
                    { 20, new DateTime(2021, 3, 4, 7, 14, 29, 815, DateTimeKind.Local).AddTicks(6511), 404618, 9, "9814352" },
                    { 39, new DateTime(2020, 4, 25, 10, 19, 38, 300, DateTimeKind.Local).AddTicks(4942), 554113, 99, "7720929" },
                    { 35, new DateTime(2020, 6, 2, 11, 3, 45, 215, DateTimeKind.Local).AddTicks(8714), 411531, 11, "3910111" },
                    { 76, new DateTime(2020, 8, 5, 20, 27, 51, 556, DateTimeKind.Local).AddTicks(2171), 153868, 94, "8245056" },
                    { 63, new DateTime(2021, 1, 26, 1, 31, 18, 554, DateTimeKind.Local).AddTicks(5241), 903323, 94, "1044836" },
                    { 60, new DateTime(2021, 2, 4, 17, 51, 39, 441, DateTimeKind.Local).AddTicks(9693), 145328, 94, "4716601" },
                    { 86, new DateTime(2020, 12, 13, 19, 53, 8, 367, DateTimeKind.Local).AddTicks(8013), 141884, 11, "7149202" },
                    { 84, new DateTime(2020, 3, 29, 4, 59, 14, 274, DateTimeKind.Local).AddTicks(3732), 629470, 11, "5613295" },
                    { 91, new DateTime(2020, 8, 15, 14, 9, 52, 580, DateTimeKind.Local).AddTicks(7117), 375907, 15, "5662799" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 71, new DateTime(2020, 12, 28, 5, 1, 1, 454, DateTimeKind.Local).AddTicks(512), 352297, 15, "8016889" },
                    { 53, new DateTime(2020, 4, 17, 15, 26, 21, 157, DateTimeKind.Local).AddTicks(5381), 645650, 15, "9458521" },
                    { 59, new DateTime(2020, 12, 19, 5, 11, 27, 252, DateTimeKind.Local).AddTicks(9756), 144355, 54, "3904870" },
                    { 107, new DateTime(2020, 7, 11, 20, 50, 57, 609, DateTimeKind.Local).AddTicks(3878), 394642, 9, "7635450" },
                    { 44, new DateTime(2020, 9, 16, 13, 26, 54, 70, DateTimeKind.Local).AddTicks(770), 971097, 54, "1487153" },
                    { 2, new DateTime(2020, 7, 30, 15, 33, 16, 782, DateTimeKind.Local).AddTicks(5499), 231761, 54, "2489684" },
                    { 34, new DateTime(2021, 2, 19, 7, 10, 46, 865, DateTimeKind.Local).AddTicks(6460), 402463, 99, "3276945" },
                    { 112, new DateTime(2020, 10, 27, 14, 46, 54, 165, DateTimeKind.Local).AddTicks(3756), 992414, 9, "7489265" },
                    { 10, new DateTime(2020, 10, 5, 4, 2, 33, 238, DateTimeKind.Local).AddTicks(3604), 453104, 39, "5358155" },
                    { 25, new DateTime(2020, 10, 27, 10, 16, 59, 839, DateTimeKind.Local).AddTicks(4054), 800757, 26, "4786096" },
                    { 54, new DateTime(2021, 3, 14, 23, 22, 30, 92, DateTimeKind.Local).AddTicks(2360), 691867, 1, "2340300" },
                    { 14, new DateTime(2020, 4, 20, 23, 3, 46, 151, DateTimeKind.Local).AddTicks(9006), 273839, 66, "4293090" },
                    { 47, new DateTime(2020, 10, 1, 18, 0, 14, 550, DateTimeKind.Local).AddTicks(6429), 828513, 28, "2013222" },
                    { 103, new DateTime(2020, 11, 13, 19, 31, 52, 544, DateTimeKind.Local).AddTicks(9807), 717920, 62, "5643506" },
                    { 48, new DateTime(2020, 10, 19, 3, 35, 57, 427, DateTimeKind.Local).AddTicks(3122), 875133, 62, "5817352" },
                    { 106, new DateTime(2020, 10, 31, 9, 13, 34, 441, DateTimeKind.Local).AddTicks(8761), 688368, 29, "9521557" },
                    { 77, new DateTime(2020, 8, 26, 11, 2, 49, 875, DateTimeKind.Local).AddTicks(3949), 563402, 29, "6095478" },
                    { 57, new DateTime(2020, 12, 4, 15, 2, 29, 121, DateTimeKind.Local).AddTicks(5904), 268851, 29, "2018485" },
                    { 99, new DateTime(2020, 4, 23, 16, 21, 47, 66, DateTimeKind.Local).AddTicks(6070), 613787, 6, "4396214" },
                    { 78, new DateTime(2021, 1, 11, 10, 41, 47, 763, DateTimeKind.Local).AddTicks(9177), 267309, 6, "2055806" },
                    { 41, new DateTime(2020, 9, 1, 17, 27, 42, 670, DateTimeKind.Local).AddTicks(353), 695177, 6, "9846312" },
                    { 72, new DateTime(2020, 12, 23, 21, 28, 20, 452, DateTimeKind.Local).AddTicks(2206), 625263, 22, "7351669" },
                    { 93, new DateTime(2020, 6, 1, 20, 25, 10, 382, DateTimeKind.Local).AddTicks(5517), 583872, 78, "8124580" },
                    { 108, new DateTime(2020, 6, 24, 23, 33, 52, 276, DateTimeKind.Local).AddTicks(9170), 851997, 45, "8914297" },
                    { 15, new DateTime(2020, 3, 26, 8, 46, 30, 214, DateTimeKind.Local).AddTicks(2152), 845774, 45, "1053379" },
                    { 7, new DateTime(2020, 8, 3, 23, 28, 26, 904, DateTimeKind.Local).AddTicks(441), 473244, 45, "7032014" },
                    { 69, new DateTime(2021, 3, 16, 18, 53, 44, 732, DateTimeKind.Local).AddTicks(6102), 946255, 72, "4309198" },
                    { 45, new DateTime(2020, 4, 27, 4, 21, 2, 512, DateTimeKind.Local).AddTicks(6082), 505719, 72, "3970389" },
                    { 31, new DateTime(2020, 6, 26, 15, 53, 6, 724, DateTimeKind.Local).AddTicks(6647), 483753, 92, "7850179" },
                    { 67, new DateTime(2020, 7, 29, 17, 48, 39, 811, DateTimeKind.Local).AddTicks(1101), 873681, 91, "7790763" },
                    { 56, new DateTime(2020, 11, 13, 13, 40, 59, 758, DateTimeKind.Local).AddTicks(5219), 964047, 91, "3917048" },
                    { 37, new DateTime(2020, 12, 12, 6, 15, 24, 84, DateTimeKind.Local).AddTicks(5716), 902254, 91, "4589969" },
                    { 30, new DateTime(2020, 10, 4, 22, 55, 25, 45, DateTimeKind.Local).AddTicks(6923), 657318, 91, "2207152" },
                    { 4, new DateTime(2020, 5, 12, 0, 23, 52, 103, DateTimeKind.Local).AddTicks(5784), 469544, 91, "7842135" },
                    { 104, new DateTime(2020, 12, 21, 4, 34, 17, 766, DateTimeKind.Local).AddTicks(8237), 64822, 26, "9034166" },
                    { 49, new DateTime(2020, 7, 12, 13, 42, 4, 171, DateTimeKind.Local).AddTicks(6620), 158339, 31, "1526831" },
                    { 36, new DateTime(2021, 2, 1, 1, 57, 43, 853, DateTimeKind.Local).AddTicks(7084), 410392, 51, "9268541" },
                    { 96, new DateTime(2021, 1, 8, 18, 12, 47, 862, DateTimeKind.Local).AddTicks(8970), 509566, 52, "6897099" },
                    { 90, new DateTime(2021, 1, 11, 10, 22, 45, 439, DateTimeKind.Local).AddTicks(8502), 41956, 71, "1703726" },
                    { 92, new DateTime(2020, 11, 3, 19, 27, 34, 225, DateTimeKind.Local).AddTicks(4728), 565256, 50, "2748786" },
                    { 5, new DateTime(2020, 10, 17, 13, 6, 53, 811, DateTimeKind.Local).AddTicks(9907), 954125, 50, "9611690" },
                    { 97, new DateTime(2020, 4, 11, 23, 42, 3, 981, DateTimeKind.Local).AddTicks(4212), 437023, 13, "1699200" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 85, new DateTime(2020, 10, 21, 20, 54, 46, 420, DateTimeKind.Local).AddTicks(8040), 635779, 10, "1728623" },
                    { 75, new DateTime(2021, 2, 25, 20, 9, 59, 109, DateTimeKind.Local).AddTicks(8833), 848464, 10, "7523232" },
                    { 13, new DateTime(2021, 3, 3, 13, 39, 55, 826, DateTimeKind.Local).AddTicks(4662), 347181, 52, "9849939" },
                    { 12, new DateTime(2020, 9, 3, 13, 48, 53, 84, DateTimeKind.Local).AddTicks(1399), 71410, 52, "1881728" },
                    { 94, new DateTime(2020, 9, 24, 22, 4, 15, 353, DateTimeKind.Local).AddTicks(3301), 824637, 75, "1317468" },
                    { 26, new DateTime(2020, 8, 21, 21, 48, 25, 338, DateTimeKind.Local).AddTicks(9715), 559246, 75, "7445165" },
                    { 42, new DateTime(2021, 1, 27, 5, 3, 28, 741, DateTimeKind.Local).AddTicks(9968), 699186, 41, "9948211" },
                    { 23, new DateTime(2021, 2, 5, 15, 20, 6, 213, DateTimeKind.Local).AddTicks(4231), 230700, 41, "1011898" },
                    { 22, new DateTime(2020, 9, 11, 7, 28, 50, 29, DateTimeKind.Local).AddTicks(5818), 21594, 7, "9969982" },
                    { 18, new DateTime(2020, 12, 28, 21, 47, 11, 759, DateTimeKind.Local).AddTicks(2533), 416006, 41, "1282642" },
                    { 89, new DateTime(2020, 11, 19, 14, 35, 47, 75, DateTimeKind.Local).AddTicks(1089), 106773, 14, "5017807" },
                    { 46, new DateTime(2020, 3, 31, 2, 9, 39, 79, DateTimeKind.Local).AddTicks(7706), 97984, 14, "1205331" },
                    { 73, new DateTime(2020, 4, 21, 8, 5, 58, 996, DateTimeKind.Local).AddTicks(2477), 180971, 74, "4035933" },
                    { 65, new DateTime(2020, 7, 22, 13, 40, 34, 718, DateTimeKind.Local).AddTicks(7892), 855567, 74, "4950082" },
                    { 17, new DateTime(2020, 6, 11, 5, 25, 25, 311, DateTimeKind.Local).AddTicks(2819), 835501, 40, "4782341" },
                    { 58, new DateTime(2020, 8, 13, 14, 41, 51, 403, DateTimeKind.Local).AddTicks(7452), 177737, 100, "4219454" },
                    { 88, new DateTime(2020, 11, 5, 8, 57, 27, 674, DateTimeKind.Local).AddTicks(9607), 838626, 4, "5051713" },
                    { 32, new DateTime(2020, 4, 20, 6, 29, 48, 118, DateTimeKind.Local).AddTicks(7613), 872478, 4, "1019903" },
                    { 21, new DateTime(2020, 5, 5, 18, 35, 17, 739, DateTimeKind.Local).AddTicks(7978), 557153, 4, "6076439" },
                    { 61, new DateTime(2020, 8, 17, 17, 22, 14, 114, DateTimeKind.Local).AddTicks(8749), 402225, 53, "6161954" },
                    { 110, new DateTime(2020, 5, 11, 4, 17, 11, 622, DateTimeKind.Local).AddTicks(4668), 799838, 1, "2279901" },
                    { 52, new DateTime(2021, 1, 21, 9, 57, 29, 182, DateTimeKind.Local).AddTicks(9586), 900889, 19, "1331488" },
                    { 70, new DateTime(2020, 11, 12, 3, 16, 23, 571, DateTimeKind.Local).AddTicks(6607), 116829, 37, "9594100" },
                    { 101, new DateTime(2020, 8, 8, 5, 55, 11, 301, DateTimeKind.Local).AddTicks(3409), 60972, 57, "5840831" },
                    { 62, new DateTime(2020, 7, 19, 4, 47, 36, 743, DateTimeKind.Local).AddTicks(9891), 519781, 3, "8030068" },
                    { 40, new DateTime(2020, 7, 27, 23, 26, 13, 576, DateTimeKind.Local).AddTicks(5769), 748202, 71, "1923227" },
                    { 29, new DateTime(2020, 7, 1, 11, 59, 42, 252, DateTimeKind.Local).AddTicks(266), 966012, 24, "6298149" },
                    { 102, new DateTime(2021, 2, 27, 14, 27, 11, 935, DateTimeKind.Local).AddTicks(1311), 18476, 95, "8161388" },
                    { 81, new DateTime(2020, 8, 11, 15, 12, 33, 453, DateTimeKind.Local).AddTicks(3727), 552131, 95, "1220867" },
                    { 38, new DateTime(2021, 3, 22, 2, 32, 48, 650, DateTimeKind.Local).AddTicks(4719), 495897, 95, "9613280" },
                    { 28, new DateTime(2020, 10, 20, 6, 27, 16, 187, DateTimeKind.Local).AddTicks(9221), 727914, 95, "7162060" },
                    { 68, new DateTime(2021, 2, 25, 15, 23, 44, 187, DateTimeKind.Local).AddTicks(1031), 589609, 27, "8921406" },
                    { 66, new DateTime(2020, 9, 6, 12, 4, 13, 407, DateTimeKind.Local).AddTicks(2799), 872996, 27, "9096918" },
                    { 43, new DateTime(2020, 3, 28, 4, 36, 30, 716, DateTimeKind.Local).AddTicks(7791), 968139, 27, "3922456" },
                    { 64, new DateTime(2021, 2, 28, 17, 15, 15, 178, DateTimeKind.Local).AddTicks(3141), 922138, 18, "4335240" },
                    { 11, new DateTime(2020, 4, 15, 16, 33, 31, 6, DateTimeKind.Local).AddTicks(9045), 58072, 18, "3891768" },
                    { 98, new DateTime(2020, 10, 14, 16, 53, 57, 828, DateTimeKind.Local).AddTicks(2895), 71138, 90, "8908678" },
                    { 83, new DateTime(2020, 4, 23, 11, 10, 42, 987, DateTimeKind.Local).AddTicks(1191), 1512, 90, "9776175" },
                    { 27, new DateTime(2020, 5, 15, 16, 46, 41, 737, DateTimeKind.Local).AddTicks(1423), 611709, 90, "6757758" },
                    { 87, new DateTime(2021, 2, 14, 6, 42, 45, 778, DateTimeKind.Local).AddTicks(534), 190875, 87, "6893529" },
                    { 19, new DateTime(2020, 9, 28, 9, 51, 22, 168, DateTimeKind.Local).AddTicks(9029), 238504, 87, "9802526" },
                    { 3, new DateTime(2020, 9, 7, 15, 38, 12, 29, DateTimeKind.Local).AddTicks(2884), 170219, 87, "9980467" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 79, new DateTime(2020, 10, 21, 5, 20, 38, 672, DateTimeKind.Local).AddTicks(8553), 957741, 59, "5973630" },
                    { 16, new DateTime(2020, 7, 14, 14, 28, 23, 858, DateTimeKind.Local).AddTicks(9467), 516941, 59, "2566703" },
                    { 100, new DateTime(2020, 4, 14, 11, 55, 16, 725, DateTimeKind.Local).AddTicks(3767), 947193, 23, "9084858" },
                    { 111, new DateTime(2020, 9, 28, 8, 24, 46, 509, DateTimeKind.Local).AddTicks(5166), 656060, 43, "9363577" },
                    { 55, new DateTime(2020, 9, 17, 16, 4, 18, 423, DateTimeKind.Local).AddTicks(7713), 963614, 43, "5128387" },
                    { 1, new DateTime(2020, 12, 11, 11, 10, 30, 83, DateTimeKind.Local).AddTicks(9511), 495890, 43, "7702583" },
                    { 109, new DateTime(2021, 3, 12, 4, 1, 45, 807, DateTimeKind.Local).AddTicks(5284), 250030, 3, "5170908" },
                    { 74, new DateTime(2020, 10, 26, 0, 36, 54, 592, DateTimeKind.Local).AddTicks(3598), 44413, 3, "3463147" },
                    { 33, new DateTime(2020, 8, 13, 19, 49, 49, 231, DateTimeKind.Local).AddTicks(9942), 429458, 51, "2684189" },
                    { 95, new DateTime(2020, 10, 25, 0, 59, 48, 336, DateTimeKind.Local).AddTicks(6425), 303173, 79, "5253405" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 39, 61, 144, 459649, new DateTime(2020, 8, 30, 10, 29, 58, 264, DateTimeKind.Local).AddTicks(8864), "Consequatur autem unde voluptatem qui reiciendis.\nSoluta sit occaecati quis.\nQuis rerum optio tempore occaecati sapiente repellat est maiores." },
                    { 108, 8, 107, 605451, new DateTime(2020, 7, 26, 5, 47, 1, 364, DateTimeKind.Local).AddTicks(8880), "Eos perspiciatis vel quas sit tenetur.\nQuo minus dolore aut rerum sequi.\nSit sunt tenetur.\nEnim qui consequatur." },
                    { 296, 8, 141, 150181, new DateTime(2020, 5, 20, 19, 54, 58, 903, DateTimeKind.Local).AddTicks(1494), "voluptas" },
                    { 308, 8, 134, 146020, new DateTime(2020, 12, 19, 19, 9, 8, 720, DateTimeKind.Local).AddTicks(8670), "Quae culpa aspernatur repudiandae dolor." },
                    { 330, 8, 116, 918329, new DateTime(2020, 9, 7, 15, 26, 48, 423, DateTimeKind.Local).AddTicks(8623), "ab" },
                    { 350, 8, 127, 441789, new DateTime(2020, 7, 21, 22, 28, 20, 435, DateTimeKind.Local).AddTicks(6963), "Quasi totam nemo doloribus autem doloremque. Eaque labore omnis. Velit dolore aliquam earum voluptatem iste tempore. Facilis molestias non molestiae." },
                    { 478, 8, 123, 416542, new DateTime(2020, 12, 30, 15, 16, 16, 823, DateTimeKind.Local).AddTicks(2189), "Commodi error odit ut omnis nulla minus beatae." },
                    { 511, 8, 60, 717164, new DateTime(2020, 7, 23, 8, 20, 59, 487, DateTimeKind.Local).AddTicks(4445), "Saepe illum sint est temporibus exercitationem deleniti.\nVoluptas eius et est aliquid.\nId autem dolore illo quo illum aliquid et." },
                    { 542, 8, 9, 938608, new DateTime(2021, 2, 18, 19, 12, 30, 318, DateTimeKind.Local).AddTicks(9489), "Qui reprehenderit odio earum temporibus. Atque non similique porro fuga atque rerum placeat consectetur. Aliquid et veniam dolor nihil." },
                    { 86, 9, 85, 100361, new DateTime(2020, 12, 20, 19, 57, 15, 933, DateTimeKind.Local).AddTicks(5014), "Autem facere est dicta dolor iure omnis tempore. Reiciendis porro eaque voluptas consectetur temporibus. Sunt reprehenderit aperiam consequuntur esse. Nisi architecto est voluptates earum dolor fuga facilis. Consequatur aut repellendus eum hic molestiae doloribus culpa exercitationem hic." },
                    { 107, 9, 29, 526940, new DateTime(2020, 6, 21, 7, 27, 39, 147, DateTimeKind.Local).AddTicks(8376), "Aut a laudantium saepe laudantium possimus corrupti autem.\nSunt quo assumenda in fugiat suscipit nemo.\nSunt et explicabo eos nostrum.\nEos dolorem facere omnis excepturi." },
                    { 129, 9, 112, 894710, new DateTime(2020, 11, 2, 1, 39, 41, 183, DateTimeKind.Local).AddTicks(7537), "Nemo provident natus quae aliquid vitae et ut.\nEst ex non explicabo rerum.\nQui voluptates soluta voluptas laboriosam impedit.\nEum est vero aliquam sed dolorem aliquam nihil ipsa delectus." },
                    { 218, 9, 110, 698603, new DateTime(2021, 1, 2, 19, 36, 47, 652, DateTimeKind.Local).AddTicks(7961), "enim" },
                    { 579, 9, 44, 118969, new DateTime(2020, 7, 6, 0, 12, 28, 324, DateTimeKind.Local).AddTicks(2569), "Et ullam omnis dolore inventore iusto quidem." },
                    { 469, 50, 37, 765821, new DateTime(2020, 7, 14, 13, 53, 13, 790, DateTimeKind.Local).AddTicks(7817), "In sint dolores in id et vitae. Exercitationem occaecati ullam. Recusandae nihil laboriosam nihil consequuntur quia. Nesciunt eos consectetur consequatur reiciendis neque sequi dolorum placeat dignissimos. Doloribus provident ut porro itaque iusto. Quis mollitia eum impedit et aliquid." },
                    { 477, 50, 71, 873896, new DateTime(2020, 10, 18, 1, 17, 48, 897, DateTimeKind.Local).AddTicks(1341), "Totam adipisci officiis eius dolor commodi ullam dolores doloribus cum." },
                    { 573, 82, 118, 767420, new DateTime(2020, 10, 23, 0, 14, 34, 77, DateTimeKind.Local).AddTicks(2171), "Rem porro tempora et beatae in reprehenderit quia in. Accusamus dolorum fugit error veniam qui tempora modi. Quo culpa inventore numquam. Sit ut numquam ut aliquam. Rerum enim consequuntur." },
                    { 364, 82, 139, 663047, new DateTime(2021, 1, 4, 5, 49, 2, 701, DateTimeKind.Local).AddTicks(5308), "Excepturi quisquam voluptatem ipsam minima eos error possimus. Sit illo alias dolores in nostrum similique dolorem. Id minima nostrum nam voluptas repellat voluptas. Occaecati est excepturi dolorum expedita ut. Beatae ea doloremque sunt at a error dolor." },
                    { 216, 82, 93, 835140, new DateTime(2020, 9, 19, 7, 7, 5, 803, DateTimeKind.Local).AddTicks(5891), "Amet accusamus fugit ipsum assumenda vero voluptates." },
                    { 21, 82, 48, 738097, new DateTime(2020, 10, 2, 16, 42, 28, 452, DateTimeKind.Local).AddTicks(9720), "Hic cupiditate id porro qui veritatis repellendus est." },
                    { 127, 34, 9, 452194, new DateTime(2020, 7, 5, 7, 27, 44, 444, DateTimeKind.Local).AddTicks(1836), "Ullam a quam nemo perspiciatis laboriosam voluptatibus quas. Facilis et reiciendis. Beatae ipsa et." },
                    { 223, 34, 74, 14502, new DateTime(2020, 10, 26, 8, 39, 55, 711, DateTimeKind.Local).AddTicks(4074), "Natus neque eius ipsam quaerat odit non.\nQuia exercitationem alias laudantium nesciunt dolorem autem velit vero corporis.\nEt quisquam pariatur suscipit nihil soluta.\nIpsam ut dicta pariatur consequatur deserunt aliquid rerum modi sed." },
                    { 245, 34, 71, 409879, new DateTime(2021, 3, 18, 10, 58, 46, 282, DateTimeKind.Local).AddTicks(9901), "Ut quia cupiditate. Aut recusandae aut amet. Quia laborum dolor in ea quia consequatur quidem alias. Officiis voluptas at ab architecto amet itaque perferendis sit." },
                    { 344, 34, 62, 777198, new DateTime(2020, 11, 18, 1, 13, 1, 153, DateTimeKind.Local).AddTicks(1192), "repellat" },
                    { 357, 34, 87, 873072, new DateTime(2020, 4, 5, 10, 41, 46, 110, DateTimeKind.Local).AddTicks(3502), "Eaque corporis aspernatur qui inventore facere quidem nisi.\nQuas in inventore neque ut non inventore rem." },
                    { 382, 34, 9, 97842, new DateTime(2020, 10, 2, 5, 32, 38, 404, DateTimeKind.Local).AddTicks(9746), "Deleniti dolorum maxime qui nulla et et porro impedit." },
                    { 398, 34, 59, 509297, new DateTime(2020, 5, 16, 0, 11, 51, 899, DateTimeKind.Local).AddTicks(432), "nam" },
                    { 493, 50, 108, 271845, new DateTime(2020, 9, 15, 14, 10, 13, 553, DateTimeKind.Local).AddTicks(8599), "voluptatem" },
                    { 426, 34, 150, 865144, new DateTime(2020, 5, 26, 8, 56, 43, 726, DateTimeKind.Local).AddTicks(760), "Accusamus dolores corrupti quam." },
                    { 113, 51, 146, 712727, new DateTime(2021, 1, 5, 0, 5, 30, 611, DateTimeKind.Local).AddTicks(1026), "Qui eos et quisquam repellat ducimus fuga." },
                    { 197, 51, 62, 812871, new DateTime(2021, 2, 7, 18, 46, 2, 620, DateTimeKind.Local).AddTicks(5067), "recusandae" },
                    { 204, 51, 134, 638171, new DateTime(2020, 4, 14, 6, 57, 31, 350, DateTimeKind.Local).AddTicks(2635), "Soluta ut fuga quam aspernatur omnis dolorem et officia." },
                    { 385, 51, 55, 82941, new DateTime(2020, 11, 13, 0, 10, 26, 589, DateTimeKind.Local).AddTicks(5515), "Sit explicabo minima." },
                    { 515, 51, 63, 311089, new DateTime(2020, 8, 25, 22, 54, 56, 835, DateTimeKind.Local).AddTicks(1461), "et" },
                    { 523, 51, 65, 628835, new DateTime(2020, 11, 26, 11, 44, 50, 57, DateTimeKind.Local).AddTicks(260), "Aut commodi sunt earum quidem quam voluptate porro illum numquam.\nVoluptatum recusandae neque et ut alias excepturi veritatis eum." },
                    { 547, 51, 141, 193542, new DateTime(2020, 10, 15, 15, 21, 1, 729, DateTimeKind.Local).AddTicks(3134), "Facilis earum ut commodi rerum placeat sed aspernatur architecto ut.\nCorporis explicabo in voluptas ut natus dolor aliquam." },
                    { 596, 39, 85, 461790, new DateTime(2020, 8, 29, 23, 31, 43, 296, DateTimeKind.Local).AddTicks(7157), "Necessitatibus quam eos voluptatem sunt.\nTenetur consequatur vel iure numquam.\nOdio est et saepe.\nError molestiae sequi sunt earum sunt nam enim placeat fuga." },
                    { 123, 34, 70, 469321, new DateTime(2020, 8, 13, 13, 18, 24, 295, DateTimeKind.Local).AddTicks(6299), "ut" },
                    { 28, 105, 111, 877961, new DateTime(2020, 6, 22, 8, 27, 49, 184, DateTimeKind.Local).AddTicks(1557), "Accusamus eum sit placeat nam culpa quae.\nUt ab enim esse accusantium at et.\nEos quos quia commodi perferendis.\nExpedita sed optio commodi voluptate et.\nVoluptatem qui rerum ea nam et impedit expedita fuga." },
                    { 8, 6, 83, 956903, new DateTime(2021, 3, 4, 19, 9, 2, 493, DateTimeKind.Local).AddTicks(7513), "In aut consequatur optio illum. Voluptas quo magnam. Voluptatem omnis et omnis omnis ullam corrupti. Aut dolorum voluptates corporis est aspernatur. Adipisci reprehenderit consequatur est fugiat similique debitis veniam." },
                    { 134, 107, 129, 903760, new DateTime(2020, 8, 11, 16, 31, 55, 501, DateTimeKind.Local).AddTicks(6792), "Voluptatibus et in qui molestiae hic tenetur tempora aut voluptatem.\nDicta illum rerum repellat rem non." },
                    { 168, 107, 96, 689244, new DateTime(2020, 7, 22, 12, 18, 18, 364, DateTimeKind.Local).AddTicks(4750), "Veniam molestiae rem temporibus asperiores sapiente eligendi.\nCorporis perspiciatis earum.\nUt assumenda a aut quos maxime nam dolore molestias delectus.\nA repudiandae quia non.\nCorporis culpa et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 191, 107, 6, 462148, new DateTime(2020, 10, 19, 7, 37, 27, 896, DateTimeKind.Local).AddTicks(7523), "explicabo" },
                    { 272, 107, 55, 596930, new DateTime(2020, 8, 31, 15, 34, 39, 415, DateTimeKind.Local).AddTicks(6372), "asperiores" },
                    { 288, 107, 17, 640506, new DateTime(2020, 8, 29, 5, 25, 23, 820, DateTimeKind.Local).AddTicks(7332), "Iure at autem eos doloremque non molestiae excepturi doloremque.\nEt et est expedita corporis autem.\nBeatae iusto voluptas et molestias." },
                    { 534, 107, 142, 529599, new DateTime(2020, 7, 31, 16, 47, 22, 12, DateTimeKind.Local).AddTicks(3645), "Dicta quis porro excepturi totam vitae pariatur et sed.\nExercitationem vel modi quis sit velit neque harum.\nVelit qui sapiente in quidem nobis quia libero." },
                    { 553, 107, 72, 74592, new DateTime(2020, 7, 3, 3, 42, 52, 871, DateTimeKind.Local).AddTicks(8684), "Recusandae nostrum at quia adipisci quaerat et." },
                    { 597, 107, 128, 244493, new DateTime(2020, 12, 6, 22, 9, 15, 370, DateTimeKind.Local).AddTicks(5294), "Eum ipsa omnis placeat perferendis autem exercitationem neque.\nAd nulla quae doloribus sunt autem sunt quas error quia." },
                    { 90, 112, 82, 741467, new DateTime(2021, 3, 11, 10, 18, 56, 213, DateTimeKind.Local).AddTicks(8348), "Consequatur quia ipsam explicabo non reprehenderit voluptas consequuntur ullam.\nLaudantium aspernatur ipsum et.\nQuia dolores dolores." },
                    { 265, 112, 12, 793083, new DateTime(2020, 8, 25, 0, 18, 35, 677, DateTimeKind.Local).AddTicks(8674), "Est sint aliquid est sit dolores incidunt.\nPerferendis tempora enim enim ut.\nPossimus qui delectus.\nDucimus nihil labore.\nQuae rerum nemo qui et sint ut in quis." },
                    { 297, 112, 133, 721973, new DateTime(2020, 5, 11, 13, 49, 57, 517, DateTimeKind.Local).AddTicks(7477), "Aut nihil iure incidunt eaque.\nTemporibus illum sint quo." },
                    { 450, 112, 100, 160664, new DateTime(2020, 8, 23, 11, 8, 52, 20, DateTimeKind.Local).AddTicks(4181), "Autem odio et voluptas sunt ad eum totam dolorum." },
                    { 571, 112, 128, 321696, new DateTime(2020, 8, 10, 1, 21, 4, 461, DateTimeKind.Local).AddTicks(4044), "Eum tempora possimus sed labore.\nAut eveniet officiis qui possimus sed." },
                    { 29, 49, 42, 444869, new DateTime(2020, 6, 27, 9, 23, 4, 884, DateTimeKind.Local).AddTicks(5763), "Magnam minus reprehenderit omnis saepe ad sequi sit ex.\nEsse est et ab corporis ipsum consequuntur.\nNihil laudantium iure perferendis commodi sed provident id labore." },
                    { 57, 49, 142, 98559, new DateTime(2020, 8, 14, 1, 48, 32, 60, DateTimeKind.Local).AddTicks(7977), "Architecto maxime pariatur quo omnis. Consequuntur consequuntur nulla. Maxime omnis distinctio. Deleniti magnam voluptatum reprehenderit quis quia aspernatur voluptas eligendi consequatur. Eveniet ea earum sed laborum necessitatibus vel veritatis nemo quia." },
                    { 370, 20, 140, 637198, new DateTime(2020, 5, 13, 12, 18, 22, 9, DateTimeKind.Local).AddTicks(5259), "Sit aperiam eum.\nDelectus nesciunt sapiente neque ipsam.\nPariatur repudiandae rerum ut unde." },
                    { 205, 20, 97, 926544, new DateTime(2021, 2, 20, 7, 30, 24, 36, DateTimeKind.Local).AddTicks(8937), "Ex vero rerum rerum incidunt. Qui hic culpa doloribus laudantium eveniet eligendi earum cupiditate. Et velit accusamus sunt commodi. Dolor quaerat culpa repudiandae repudiandae magni aut fugiat enim. Quis aspernatur vero quisquam. Eligendi sed aut consequuntur tempore voluptas odit." },
                    { 126, 20, 60, 769614, new DateTime(2020, 11, 29, 11, 46, 39, 898, DateTimeKind.Local).AddTicks(8687), "Velit autem doloremque molestias perspiciatis voluptatem.\nOccaecati vitae quasi totam rem voluptatibus facilis unde velit cupiditate.\nCumque dolore rerum quo laudantium." },
                    { 391, 24, 72, 776781, new DateTime(2020, 9, 15, 22, 30, 12, 218, DateTimeKind.Local).AddTicks(141), "Quis ut voluptatem tempore quod. Ab ex ut unde aut explicabo. Exercitationem totam excepturi qui nisi iste omnis assumenda sit. Autem pariatur sequi tempore aspernatur neque natus ut exercitationem." },
                    { 142, 6, 101, 287568, new DateTime(2021, 2, 12, 5, 9, 43, 538, DateTimeKind.Local).AddTicks(5376), "Molestiae omnis est." },
                    { 284, 6, 137, 140045, new DateTime(2020, 9, 10, 7, 18, 52, 959, DateTimeKind.Local).AddTicks(7622), "Rem voluptatem sed ducimus dolores nesciunt laboriosam modi. Iusto consequatur qui nemo autem. Nihil cum alias dolor. Voluptatibus repellat quisquam esse voluptas eos aut. Enim eaque rerum et et porro aut tempora est." },
                    { 316, 6, 140, 836249, new DateTime(2020, 8, 12, 6, 59, 35, 501, DateTimeKind.Local).AddTicks(9219), "Alias ullam eum dolore qui dolor voluptate.\nSoluta quia in dolore sunt tempore est at." },
                    { 329, 6, 137, 903843, new DateTime(2020, 3, 27, 7, 12, 53, 109, DateTimeKind.Local).AddTicks(5494), "Et minus esse doloremque iste. Autem corrupti repellat dignissimos pariatur molestias. Neque blanditiis commodi saepe nisi sit consequatur." },
                    { 574, 6, 78, 768101, new DateTime(2021, 2, 12, 11, 4, 11, 985, DateTimeKind.Local).AddTicks(9694), "Debitis consequatur voluptas eius dolorum quia incidunt veritatis nihil." },
                    { 72, 80, 116, 876302, new DateTime(2020, 11, 23, 3, 50, 3, 358, DateTimeKind.Local).AddTicks(812), "Porro aut repellat ad. Rerum nostrum officia quia a quis. Deserunt perferendis tempora aut non voluptate distinctio non repellendus." },
                    { 161, 80, 38, 625053, new DateTime(2020, 8, 10, 5, 22, 35, 438, DateTimeKind.Local).AddTicks(1402), "Dolores sunt vero. Ducimus enim nobis sint iste officiis consectetur sit deleniti. Cupiditate doloremque qui. Modi quidem rerum magni." },
                    { 172, 105, 48, 323982, new DateTime(2020, 7, 15, 14, 59, 19, 187, DateTimeKind.Local).AddTicks(1682), "ducimus" },
                    { 195, 80, 87, 782208, new DateTime(2020, 5, 24, 5, 31, 17, 620, DateTimeKind.Local).AddTicks(3050), "Aut in tempora aut officia qui nobis vel iste.\nAperiam sunt eligendi quaerat.\nEa fuga quaerat ut." },
                    { 328, 80, 118, 950181, new DateTime(2020, 4, 8, 16, 11, 15, 895, DateTimeKind.Local).AddTicks(5401), "adipisci" },
                    { 348, 80, 89, 234367, new DateTime(2021, 1, 24, 16, 59, 38, 775, DateTimeKind.Local).AddTicks(6067), "Itaque aperiam occaecati autem velit qui excepturi eligendi quas autem." },
                    { 499, 80, 146, 728057, new DateTime(2020, 6, 17, 7, 18, 11, 149, DateTimeKind.Local).AddTicks(1659), "et" },
                    { 550, 80, 129, 801807, new DateTime(2020, 8, 29, 12, 23, 44, 221, DateTimeKind.Local).AddTicks(9909), "Qui consectetur et voluptatem consequatur." },
                    { 588, 80, 82, 750219, new DateTime(2020, 5, 2, 19, 12, 19, 241, DateTimeKind.Local).AddTicks(8401), "omnis" },
                    { 589, 80, 64, 786091, new DateTime(2020, 7, 19, 1, 9, 13, 138, DateTimeKind.Local).AddTicks(397), "Facere illo magni ipsa asperiores ut. Ad quod cum quos. Omnis minus omnis distinctio eius unde optio quam." },
                    { 62, 24, 105, 199485, new DateTime(2021, 1, 11, 4, 54, 34, 712, DateTimeKind.Local).AddTicks(6805), "voluptatibus" },
                    { 290, 80, 80, 410099, new DateTime(2021, 3, 21, 14, 18, 16, 419, DateTimeKind.Local).AddTicks(9412), "Sunt unde quibusdam id rerum est. Ut rem ullam. Quia voluptates et debitis quis. Voluptates sint placeat quos sint voluptatem sit ab." },
                    { 26, 34, 77, 977818, new DateTime(2020, 10, 7, 19, 35, 18, 784, DateTimeKind.Local).AddTicks(6666), "Minima vel ut nostrum vel. Aspernatur ut et dolor nisi. Delectus et velit consequatur sed. Porro hic in incidunt ut quia voluptatem cupiditate. Quo quis esse." },
                    { 15, 34, 28, 89770, new DateTime(2020, 5, 4, 14, 24, 51, 978, DateTimeKind.Local).AddTicks(8398), "Tenetur molestias dolor omnis voluptas eos consequuntur aut modi voluptatem. Aut autem nostrum vel est itaque ratione nisi et dicta. Rerum dolore nemo vel ducimus deleniti. Assumenda eos et nihil qui quia veritatis." },
                    { 552, 76, 54, 704324, new DateTime(2020, 6, 30, 14, 58, 29, 349, DateTimeKind.Local).AddTicks(6872), "quos" },
                    { 495, 2, 39, 471328, new DateTime(2021, 2, 8, 2, 53, 35, 203, DateTimeKind.Local).AddTicks(7014), "Modi autem deserunt asperiores voluptatum harum repellendus consequatur totam. Iste harum voluptatem eaque. Necessitatibus omnis voluptate quas voluptatem excepturi eum ut." },
                    { 522, 2, 150, 422456, new DateTime(2020, 12, 3, 1, 58, 2, 177, DateTimeKind.Local).AddTicks(7846), "Iure incidunt dolorem tempora consequatur sed quidem et deleniti. Fuga quis placeat molestias modi quasi repellendus saepe. Aut consectetur ipsa tempora et neque voluptatibus autem aut dolor. Quas et et." },
                    { 555, 2, 5, 100823, new DateTime(2020, 12, 14, 14, 52, 54, 948, DateTimeKind.Local).AddTicks(7092), "Facilis consequatur sint aperiam dolor et officia. Vel dolor est hic aut et. Vel et dicta placeat assumenda enim beatae laboriosam. Consequatur similique maxime deserunt placeat rerum. Sed corporis pariatur ex aliquid occaecati est." },
                    { 32, 44, 62, 874042, new DateTime(2020, 8, 23, 18, 40, 9, 819, DateTimeKind.Local).AddTicks(7018), "Voluptatem ullam consequatur nihil." },
                    { 80, 44, 146, 474842, new DateTime(2020, 10, 14, 10, 5, 17, 394, DateTimeKind.Local).AddTicks(4810), "Est vitae quod laborum tempore eos quia recusandae ipsa provident. Eos veritatis consectetur illum. Temporibus eum ex unde. Sapiente pariatur dolorem. Quis voluptatem voluptatem et eaque qui rerum porro porro blanditiis." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 94, 44, 57, 447136, new DateTime(2020, 12, 27, 0, 51, 24, 391, DateTimeKind.Local).AddTicks(3024), "Iste reprehenderit necessitatibus consequatur hic molestiae eaque maiores placeat. Aut voluptatibus fugiat nulla voluptatum id saepe. Qui consequatur aut ipsam saepe ducimus nemo dolores. Consectetur voluptatem aspernatur occaecati corporis quo suscipit. Praesentium sed repellat consequatur tempore." },
                    { 227, 44, 136, 90384, new DateTime(2021, 3, 3, 6, 12, 44, 203, DateTimeKind.Local).AddTicks(5328), "animi" },
                    { 259, 44, 13, 269263, new DateTime(2020, 4, 15, 19, 17, 22, 426, DateTimeKind.Local).AddTicks(4070), "Et eum tempore commodi aut earum laudantium similique asperiores sed.\nDeserunt quos natus quaerat est earum nobis corporis.\nExercitationem vel saepe qui et distinctio." },
                    { 277, 44, 5, 906578, new DateTime(2021, 3, 16, 12, 36, 43, 4, DateTimeKind.Local).AddTicks(3012), "Impedit perferendis necessitatibus corporis at atque magni enim. Rerum et eius et voluptatem ut accusantium. Laborum consequuntur odit. Non earum accusantium consequatur excepturi cupiditate vel at. Facilis aut quibusdam dicta exercitationem cupiditate est." },
                    { 406, 44, 25, 632450, new DateTime(2020, 6, 3, 16, 22, 51, 558, DateTimeKind.Local).AddTicks(147), "Recusandae corrupti reprehenderit. Accusamus facilis libero doloremque. Fugiat voluptas officiis molestiae odio ipsam enim provident eos dolorum." },
                    { 449, 44, 99, 778491, new DateTime(2020, 3, 30, 11, 17, 3, 527, DateTimeKind.Local).AddTicks(5732), "incidunt" },
                    { 213, 59, 55, 21687, new DateTime(2020, 9, 11, 4, 52, 28, 439, DateTimeKind.Local).AddTicks(6402), "Modi dignissimos harum.\nConsequuntur nam soluta laudantium." },
                    { 31, 53, 41, 225183, new DateTime(2021, 2, 22, 7, 50, 50, 691, DateTimeKind.Local).AddTicks(3766), "Possimus vero quo aperiam.\nDelectus quis delectus unde sit libero quis id fuga.\nBeatae optio rerum non quaerat.\nUt dolorum a perferendis nam consequuntur omnis minus impedit.\nUt omnis omnis ab fugit sed porro officia enim." },
                    { 98, 53, 2, 639872, new DateTime(2020, 11, 12, 11, 37, 34, 918, DateTimeKind.Local).AddTicks(335), "Sint culpa ipsam sit veniam corporis porro aut nihil.\nAutem qui unde.\nReiciendis minima dignissimos quam assumenda sed.\nEt impedit cum.\nQui sequi consequuntur placeat illum." },
                    { 243, 53, 75, 531528, new DateTime(2021, 3, 12, 21, 34, 43, 48, DateTimeKind.Local).AddTicks(9167), "Magnam aliquid quibusdam quo ullam ipsam." },
                    { 461, 2, 61, 27636, new DateTime(2021, 2, 18, 12, 30, 10, 665, DateTimeKind.Local).AddTicks(1935), "Possimus provident error dolor id adipisci voluptatem omnis voluptate." },
                    { 279, 2, 75, 532372, new DateTime(2020, 5, 15, 11, 59, 17, 440, DateTimeKind.Local).AddTicks(9635), "Porro quia autem." },
                    { 5, 2, 57, 187848, new DateTime(2020, 6, 13, 5, 44, 7, 37, DateTimeKind.Local).AddTicks(199), "Similique vitae dolorum." },
                    { 575, 95, 84, 377707, new DateTime(2020, 12, 26, 14, 19, 11, 92, DateTimeKind.Local).AddTicks(1832), "Velit quas saepe animi. Ea consequuntur hic autem veritatis animi dolores optio quibusdam. Ex hic molestiae enim rem magnam voluptas. Quia temporibus ipsum autem nesciunt corrupti aut. Laudantium sit non. Tempora necessitatibus cum tenetur occaecati." },
                    { 317, 33, 74, 534629, new DateTime(2020, 5, 21, 15, 55, 5, 868, DateTimeKind.Local).AddTicks(8819), "Non dolorem accusantium praesentium similique. Reprehenderit eum quos ipsum. Et veniam adipisci. At iste laboriosam ducimus vel voluptatem quo fugiat sed ea. Officiis voluptas magnam. Adipisci natus neque reiciendis ut nihil molestiae porro." },
                    { 374, 33, 36, 390509, new DateTime(2020, 9, 14, 17, 23, 8, 90, DateTimeKind.Local).AddTicks(3603), "Nemo a impedit consequuntur architecto omnis tempora odio nisi. Dolorem molestiae beatae ut corrupti voluptatem non. Architecto earum nemo molestiae fugit accusamus eaque voluptatem. Occaecati maiores blanditiis inventore ipsam. Quasi libero non in cupiditate accusamus omnis voluptas nobis." },
                    { 412, 33, 121, 599414, new DateTime(2020, 7, 22, 1, 20, 11, 341, DateTimeKind.Local).AddTicks(248), "Itaque praesentium ratione. Et voluptas repellat blanditiis excepturi. Et aperiam et. Cupiditate omnis quia quia provident. Exercitationem minus eum dolor est. Accusamus eum delectus deserunt iste." },
                    { 9, 36, 41, 272425, new DateTime(2020, 10, 13, 10, 27, 44, 189, DateTimeKind.Local).AddTicks(250), "Inventore est voluptas qui quos aut ut voluptatem ipsum.\nEsse at omnis non." },
                    { 96, 36, 148, 233790, new DateTime(2020, 5, 24, 23, 17, 59, 423, DateTimeKind.Local).AddTicks(8650), "Qui est ipsum dignissimos enim est dolor." },
                    { 246, 36, 93, 439556, new DateTime(2021, 1, 29, 15, 8, 10, 296, DateTimeKind.Local).AddTicks(8738), "Dolor autem pariatur qui sed est. Ducimus et dolor nulla quisquam. Beatae in et voluptatem doloremque culpa dolorem velit quasi qui. Et et repellendus quia velit voluptates qui minima laborum repudiandae. Non repellendus ad eius sit error voluptate dolorum nostrum laboriosam. Sed itaque et dolorem." },
                    { 295, 36, 37, 333563, new DateTime(2020, 8, 25, 0, 18, 47, 265, DateTimeKind.Local).AddTicks(2125), "Laudantium qui consequuntur expedita.\nIpsa a distinctio tenetur facere." },
                    { 325, 53, 82, 389129, new DateTime(2020, 10, 6, 12, 23, 43, 835, DateTimeKind.Local).AddTicks(2620), "et" },
                    { 331, 36, 102, 336849, new DateTime(2020, 11, 7, 20, 50, 44, 729, DateTimeKind.Local).AddTicks(1601), "Ut ex aut quia molestiae." },
                    { 41, 14, 141, 623574, new DateTime(2021, 3, 1, 18, 17, 14, 872, DateTimeKind.Local).AddTicks(439), "Aut architecto unde qui.\nAspernatur reiciendis dolor aut dolores.\nAut a praesentium.\nIusto natus officiis.\nEst odio aut suscipit aut ea quis.\nDolorum explicabo quia maxime repellendus et quia." },
                    { 209, 14, 80, 990933, new DateTime(2021, 1, 3, 7, 29, 12, 687, DateTimeKind.Local).AddTicks(5437), "harum" },
                    { 305, 14, 70, 132868, new DateTime(2020, 4, 12, 13, 36, 52, 517, DateTimeKind.Local).AddTicks(4096), "Quibusdam assumenda tenetur est et ea.\nNulla dolorem odit non eligendi voluptatem ut.\nHarum provident ducimus minima quos corrupti quia facilis explicabo voluptate.\nQuia expedita voluptas enim et.\nEt quia a dolorem odio laboriosam debitis.\nNesciunt nam dolorum error perspiciatis molestiae iusto sed impedit." },
                    { 381, 14, 11, 285884, new DateTime(2021, 1, 6, 10, 48, 2, 678, DateTimeKind.Local).AddTicks(6226), "Quia quo et voluptate non omnis corporis similique. Voluptatem nihil dolor rerum atque ab. Sit maiores est dolorem est rerum. Quia a quam ducimus." },
                    { 441, 14, 53, 931382, new DateTime(2020, 5, 1, 16, 55, 35, 290, DateTimeKind.Local).AddTicks(2340), "Nam sequi sunt est autem omnis voluptatem ducimus." },
                    { 481, 14, 29, 397015, new DateTime(2020, 11, 18, 16, 17, 14, 92, DateTimeKind.Local).AddTicks(1127), "adipisci" },
                    { 488, 14, 1, 23170, new DateTime(2020, 7, 1, 3, 0, 54, 78, DateTimeKind.Local).AddTicks(1979), "Beatae cum quia velit incidunt veniam. Ut ipsa cum dolor quisquam unde deserunt dolorem voluptas est. Voluptatem distinctio est placeat reiciendis nobis consectetur id. Eos hic repudiandae. Non ex praesentium. Aut nemo placeat id consectetur." },
                    { 18, 14, 74, 178547, new DateTime(2020, 4, 30, 10, 6, 25, 361, DateTimeKind.Local).AddTicks(6570), "Dicta beatae nihil." },
                    { 332, 53, 121, 831521, new DateTime(2020, 10, 26, 7, 22, 19, 878, DateTimeKind.Local).AddTicks(5813), "Omnis delectus occaecati aperiam quas officia.\nOdio sint sed quis est nobis molestias delectus quas.\nOfficiis nihil tempora sequi natus neque magnam amet dolore.\nOccaecati consequatur cumque voluptas sit repudiandae.\nEa aspernatur provident molestias esse voluptatum tenetur pariatur.\nQui voluptatibus magnam occaecati quam." },
                    { 442, 53, 97, 412673, new DateTime(2021, 3, 19, 16, 15, 30, 990, DateTimeKind.Local).AddTicks(3403), "Temporibus rem molestiae.\nOmnis ut est neque voluptate.\nSequi error consequatur maxime.\nEaque quae et ipsum impedit.\nUt quos delectus tempore molestias doloribus excepturi quae." },
                    { 447, 53, 139, 930931, new DateTime(2021, 3, 21, 13, 5, 52, 191, DateTimeKind.Local).AddTicks(769), "Repellat omnis dolor soluta et quia culpa occaecati. Tenetur quis nesciunt saepe eum earum. Cupiditate optio dolor. Ut recusandae et nam perspiciatis sequi quo voluptatem. Ipsum voluptatem enim. Amet blanditiis excepturi." },
                    { 212, 86, 53, 510547, new DateTime(2020, 5, 9, 19, 59, 10, 78, DateTimeKind.Local).AddTicks(5908), "Alias aspernatur et saepe et reiciendis tempora. Consequatur dolorem debitis harum magnam est aut quia. At ut facere qui magni officia aut ut non. Ratione esse et adipisci nihil molestias qui explicabo quam deserunt. Sit id aliquid et harum et nostrum exercitationem et. Autem eaque vero magnam reiciendis velit delectus." },
                    { 415, 86, 118, 620596, new DateTime(2021, 2, 6, 7, 15, 28, 864, DateTimeKind.Local).AddTicks(6919), "Earum culpa et." },
                    { 437, 86, 48, 970781, new DateTime(2021, 3, 22, 3, 50, 9, 25, DateTimeKind.Local).AddTicks(5026), "Labore neque facere eius quia est ducimus.\nNihil consequatur est est beatae iste odit quo nihil.\nIpsa ea aut aspernatur.\nEnim ab at sit ut tempora." },
                    { 484, 86, 29, 338612, new DateTime(2020, 3, 26, 3, 25, 25, 738, DateTimeKind.Local).AddTicks(7531), "et" },
                    { 489, 86, 24, 474772, new DateTime(2020, 7, 30, 1, 20, 7, 14, DateTimeKind.Local).AddTicks(9272), "dicta" },
                    { 560, 86, 79, 139058, new DateTime(2020, 7, 16, 21, 53, 3, 675, DateTimeKind.Local).AddTicks(6091), "qui" },
                    { 199, 60, 123, 554287, new DateTime(2020, 5, 15, 4, 22, 43, 217, DateTimeKind.Local).AddTicks(7817), "Eos ut commodi saepe id exercitationem adipisci in perspiciatis enim.\nQuia voluptas enim odio itaque architecto consectetur ex deleniti exercitationem.\nEos eaque est.\nDolor quisquam dolorum alias reiciendis delectus quis id nulla ipsum.\nVeritatis autem ipsum." },
                    { 226, 84, 23, 523916, new DateTime(2020, 4, 12, 12, 53, 22, 768, DateTimeKind.Local).AddTicks(3806), "Commodi dolor ut ipsam voluptates dolores provident quam dignissimos." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 253, 60, 2, 630623, new DateTime(2020, 8, 30, 15, 54, 23, 809, DateTimeKind.Local).AddTicks(8092), "Cum voluptatem distinctio eos perferendis. Aliquam ut eos natus eos et. Et temporibus aliquam. Rerum et illo sit autem quo." },
                    { 131, 63, 4, 988055, new DateTime(2020, 4, 27, 4, 23, 43, 618, DateTimeKind.Local).AddTicks(1615), "voluptas" },
                    { 319, 63, 99, 198543, new DateTime(2020, 11, 10, 11, 5, 48, 270, DateTimeKind.Local).AddTicks(8343), "Cupiditate dolorem aut possimus dolor corrupti id numquam quasi ut. Animi aperiam dolores reiciendis. Et est dolorum commodi quia distinctio repudiandae aut. Sint incidunt sit." },
                    { 548, 63, 17, 942399, new DateTime(2020, 3, 24, 12, 36, 27, 360, DateTimeKind.Local).AddTicks(6682), "Ut doloremque qui voluptates illum doloremque.\nAspernatur blanditiis sed neque est debitis in perferendis.\nBlanditiis quia earum esse ea doloribus est sint incidunt sapiente.\nPlaceat temporibus consectetur consequatur distinctio.\nOmnis dolor dicta sint neque dicta distinctio laborum." },
                    { 569, 63, 35, 837522, new DateTime(2020, 10, 27, 2, 3, 11, 845, DateTimeKind.Local).AddTicks(3111), "veritatis" },
                    { 13, 76, 63, 318040, new DateTime(2020, 8, 8, 22, 45, 33, 15, DateTimeKind.Local).AddTicks(7371), "Et et omnis enim consequatur quam ut. Ipsum et qui laudantium sapiente adipisci error vel reprehenderit. Assumenda distinctio quia quas cumque quae non. Explicabo aspernatur eligendi neque culpa et. Vero illum ad similique libero rerum." },
                    { 155, 76, 96, 905811, new DateTime(2020, 8, 6, 17, 41, 18, 200, DateTimeKind.Local).AddTicks(7586), "Qui minima minima voluptatibus culpa perspiciatis sed consequatur enim. Et sit et ducimus est repudiandae non qui quia. Sapiente dolorem quasi vero perspiciatis et omnis consequatur expedita amet." },
                    { 529, 76, 68, 83089, new DateTime(2021, 2, 22, 2, 12, 35, 689, DateTimeKind.Local).AddTicks(5279), "Veniam maiores magnam a.\nVel nihil rerum dolores corporis qui.\nDolorum in perspiciatis quasi.\nQuidem reiciendis et iste qui aut dolore facilis quibusdam at.\nEt consequatur id omnis delectus vel et est.\nTempore et voluptatem quos vel." },
                    { 562, 60, 7, 790991, new DateTime(2021, 2, 13, 18, 9, 44, 109, DateTimeKind.Local).AddTicks(8926), "Omnis necessitatibus magnam tenetur quo repellendus." },
                    { 101, 49, 75, 539448, new DateTime(2020, 9, 21, 16, 52, 21, 340, DateTimeKind.Local).AddTicks(7110), "Sint autem odit ut et itaque quis. Corporis ab voluptatem quae molestias modi. Ut voluptas asperiores et exercitationem mollitia voluptate consequatur quia. Nam tempora cumque placeat nihil eligendi impedit numquam officia cum. Dolor quibusdam accusamus id magnam non." },
                    { 201, 84, 129, 73537, new DateTime(2020, 6, 15, 13, 46, 57, 454, DateTimeKind.Local).AddTicks(9762), "Enim deserunt architecto aspernatur quia. Nam sint voluptatum omnis. Sit aut quo neque totam enim et. Illum amet dolorum. Sed quia aut similique non veritatis molestiae assumenda. Sed laborum aut aut." },
                    { 64, 84, 68, 10587, new DateTime(2020, 9, 8, 12, 46, 6, 944, DateTimeKind.Local).AddTicks(950), "Sunt excepturi autem possimus amet." },
                    { 3, 71, 135, 390347, new DateTime(2020, 10, 28, 1, 17, 26, 830, DateTimeKind.Local).AddTicks(2152), "Et voluptatum amet nulla eaque eveniet." },
                    { 153, 71, 144, 945007, new DateTime(2020, 5, 16, 13, 9, 21, 870, DateTimeKind.Local).AddTicks(9226), "Et voluptas dolores aperiam. Totam repellat placeat sed reprehenderit pariatur nulla. Autem qui ut accusamus voluptas quidem. Dolorem ullam earum cum provident repudiandae labore. Dolorem tempora provident sapiente est pariatur eligendi consequatur commodi hic. Qui labore maxime iusto repellendus." },
                    { 324, 71, 126, 967224, new DateTime(2021, 2, 28, 6, 59, 33, 868, DateTimeKind.Local).AddTicks(9252), "officia" },
                    { 376, 71, 134, 230607, new DateTime(2021, 3, 2, 17, 4, 45, 766, DateTimeKind.Local).AddTicks(3609), "Eum voluptas voluptas dicta ab quaerat.\nBlanditiis necessitatibus et at expedita consequatur corporis sapiente.\nNobis dolorem cupiditate quia dolorum ea est culpa.\nItaque ratione mollitia quo corporis ab animi veritatis laborum.\nNobis id iusto illum nostrum." },
                    { 527, 71, 102, 705243, new DateTime(2021, 1, 31, 10, 32, 40, 296, DateTimeKind.Local).AddTicks(3282), "Architecto consequatur deleniti similique numquam est magnam voluptates." },
                    { 14, 91, 16, 589967, new DateTime(2021, 1, 5, 1, 12, 53, 540, DateTimeKind.Local).AddTicks(6027), "Veniam voluptatem porro et." },
                    { 35, 91, 70, 723313, new DateTime(2020, 4, 5, 19, 7, 41, 110, DateTimeKind.Local).AddTicks(9444), "Quam et iste asperiores et vitae libero dolorum." },
                    { 87, 84, 62, 247273, new DateTime(2020, 10, 22, 11, 53, 5, 7, DateTimeKind.Local).AddTicks(9168), "Corrupti eos in error voluptates voluptates." },
                    { 77, 91, 90, 635676, new DateTime(2020, 7, 23, 5, 21, 25, 163, DateTimeKind.Local).AddTicks(8797), "Qui aut placeat et quidem.\nAt distinctio voluptatibus et assumenda.\nSed eos nesciunt cum quam temporibus eaque.\nMollitia asperiores dicta animi dolorem voluptatibus voluptas nihil.\nAmet dolorem deleniti.\nEligendi est et atque quasi ab reprehenderit qui." },
                    { 225, 91, 148, 361399, new DateTime(2020, 6, 26, 22, 11, 24, 297, DateTimeKind.Local).AddTicks(6954), "Quis saepe vel recusandae optio eveniet consequatur.\nConsequuntur sint laudantium." },
                    { 333, 91, 41, 991414, new DateTime(2020, 12, 15, 21, 53, 38, 196, DateTimeKind.Local).AddTicks(9465), "voluptas" },
                    { 475, 91, 139, 197423, new DateTime(2020, 5, 23, 0, 38, 46, 117, DateTimeKind.Local).AddTicks(6139), "aut" },
                    { 513, 91, 135, 642454, new DateTime(2020, 8, 2, 5, 44, 19, 38, DateTimeKind.Local).AddTicks(5889), "hic" },
                    { 214, 35, 93, 724923, new DateTime(2020, 4, 13, 10, 2, 3, 13, DateTimeKind.Local).AddTicks(5058), "Dolores dicta vel et et commodi est autem et." },
                    { 261, 35, 47, 146984, new DateTime(2020, 4, 26, 16, 52, 36, 688, DateTimeKind.Local).AddTicks(7220), "repudiandae" },
                    { 585, 35, 35, 217243, new DateTime(2021, 3, 18, 18, 10, 34, 557, DateTimeKind.Local).AddTicks(3890), "Voluptas dolorum inventore corporis ea eveniet mollitia id nihil. Excepturi voluptas maiores. Suscipit ut nisi eum saepe cumque repellendus possimus atque. Consequatur beatae omnis sit qui modi. Sed et sint quo pariatur adipisci reprehenderit. Error sit occaecati sit similique corporis." },
                    { 136, 91, 92, 196738, new DateTime(2021, 3, 9, 19, 38, 25, 446, DateTimeKind.Local).AddTicks(2639), "Doloremque eligendi quisquam est amet facilis.\nRerum voluptas quasi similique distinctio ipsum esse sed quidem.\nEt est dolores beatae.\nEt et et enim optio debitis eius." },
                    { 200, 33, 129, 718479, new DateTime(2020, 10, 24, 1, 3, 26, 448, DateTimeKind.Local).AddTicks(6399), "sed" },
                    { 416, 49, 105, 39964, new DateTime(2020, 6, 28, 23, 23, 46, 601, DateTimeKind.Local).AddTicks(3496), "Exercitationem aliquid et voluptatem minima iste non sit saepe." },
                    { 178, 25, 143, 751552, new DateTime(2020, 12, 22, 18, 9, 20, 583, DateTimeKind.Local).AddTicks(3467), "Accusantium enim harum assumenda ut. Eligendi inventore esse sint. Ex necessitatibus debitis sed perspiciatis quidem sapiente ad officia aperiam. Eos consequatur et facere eos. Error a perferendis molestias consectetur a dolor voluptatem asperiores. Qui odit odio neque tempora velit." },
                    { 444, 99, 116, 631468, new DateTime(2020, 5, 5, 13, 38, 31, 860, DateTimeKind.Local).AddTicks(2797), "Neque rem quidem maiores eveniet cumque harum saepe architecto cumque. Alias sit rerum reiciendis a et quae. Quaerat fugit qui est nobis et dolores cupiditate impedit maxime. Quo autem illum porro. Voluptatem sit nobis laborum quis aut sequi itaque. Sapiente rerum ut suscipit sunt laboriosam adipisci est." },
                    { 453, 99, 100, 213532, new DateTime(2020, 10, 22, 18, 27, 5, 366, DateTimeKind.Local).AddTicks(7170), "Id reprehenderit corrupti eos delectus assumenda est qui." },
                    { 68, 57, 116, 256400, new DateTime(2020, 5, 15, 14, 0, 30, 501, DateTimeKind.Local).AddTicks(6609), "Voluptatem facilis deserunt cum qui necessitatibus accusamus id perspiciatis.\nQuae molestiae facere sequi.\nOdit voluptatem et eaque fugiat enim est laboriosam.\nReprehenderit molestias qui molestiae quam est velit asperiores inventore eos.\nVoluptatem quae architecto qui reprehenderit velit est." },
                    { 78, 57, 28, 868115, new DateTime(2020, 6, 10, 12, 52, 18, 502, DateTimeKind.Local).AddTicks(4613), "Rerum sed soluta maiores. Quia qui deserunt et ratione id et. Molestiae officia quibusdam praesentium quis illum voluptas. Provident adipisci ut id. Quia non ex minima alias numquam odio animi." },
                    { 251, 57, 133, 356495, new DateTime(2020, 8, 4, 9, 52, 15, 786, DateTimeKind.Local).AddTicks(2589), "voluptatem" },
                    { 271, 57, 18, 864834, new DateTime(2021, 1, 9, 13, 52, 56, 82, DateTimeKind.Local).AddTicks(1236), "Doloribus dolor sunt sed nostrum ad eaque aut. Distinctio a fuga ipsa iste illo. Aut quis culpa voluptate labore amet ut. Enim quia odio autem incidunt maxime." },
                    { 367, 57, 49, 76898, new DateTime(2021, 3, 9, 4, 51, 45, 290, DateTimeKind.Local).AddTicks(6058), "Enim est ipsa aspernatur architecto alias." },
                    { 501, 57, 34, 344110, new DateTime(2020, 7, 4, 4, 8, 1, 2, DateTimeKind.Local).AddTicks(7380), "Pariatur aut qui debitis sed id laudantium qui expedita quo. Qui quam iusto deleniti ut. Ducimus modi aut nulla ducimus occaecati nostrum dolorum corporis. Soluta in quaerat at quos delectus eos molestiae quia sit. Rerum dolores est est. Necessitatibus qui iure." },
                    { 505, 57, 46, 560968, new DateTime(2020, 10, 8, 18, 39, 8, 150, DateTimeKind.Local).AddTicks(4023), "Nulla nihil aperiam eos.\nMolestiae aut cupiditate iusto aut." },
                    { 559, 57, 36, 380887, new DateTime(2021, 2, 10, 1, 37, 47, 515, DateTimeKind.Local).AddTicks(3261), "Incidunt earum quo quis ducimus totam eaque. Et cupiditate veritatis aut aut et rerum necessitatibus ut aut. Dolores commodi rem quam quo in facere libero. Rerum fuga quibusdam quia occaecati animi voluptatem velit. Eveniet dolorem provident. Dolorum doloribus ex qui perspiciatis hic." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 20, 77, 115, 55070, new DateTime(2021, 1, 30, 9, 5, 16, 345, DateTimeKind.Local).AddTicks(2512), "Accusamus quasi assumenda quas est est cumque assumenda.\nOdio rerum voluptas ut ipsa nesciunt optio quia ratione.\nNisi ut voluptatem id.\nNon occaecati commodi vero similique sunt expedita voluptates." },
                    { 45, 77, 44, 80506, new DateTime(2021, 3, 7, 2, 48, 24, 821, DateTimeKind.Local).AddTicks(2997), "Fugiat at velit culpa nihil labore asperiores qui iure tempora." },
                    { 143, 77, 104, 558163, new DateTime(2021, 3, 4, 2, 6, 53, 951, DateTimeKind.Local).AddTicks(9030), "Aut qui est et voluptatem quae qui omnis.\nDolorem deserunt ullam ut rerum." },
                    { 174, 77, 81, 175724, new DateTime(2020, 10, 28, 11, 41, 23, 405, DateTimeKind.Local).AddTicks(5469), "Dolorum accusamus eum possimus velit perferendis reprehenderit eius.\nTenetur quis nostrum laboriosam molestias veniam excepturi nam.\nNumquam autem eum in qui.\nSuscipit repellendus repellendus.\nUt animi minus qui consequatur consectetur." },
                    { 356, 77, 29, 453397, new DateTime(2021, 2, 2, 9, 27, 16, 498, DateTimeKind.Local).AddTicks(4321), "Molestiae inventore optio explicabo quia.\nAt magni aut inventore et." },
                    { 244, 99, 23, 403824, new DateTime(2021, 1, 8, 23, 58, 25, 813, DateTimeKind.Local).AddTicks(1110), "Quidem qui accusantium sed aliquam." },
                    { 194, 99, 83, 605820, new DateTime(2020, 5, 18, 3, 29, 58, 131, DateTimeKind.Local).AddTicks(5795), "Est nesciunt aut autem. Iusto officiis voluptatem commodi. Commodi consequatur dolores tenetur est quia consequuntur sint doloribus doloribus. Vel ratione occaecati et dolores illo ipsam aut sit. Tempore aut non omnis ratione. Modi dicta quia veniam magnam soluta eum et animi." },
                    { 111, 99, 85, 161558, new DateTime(2020, 10, 16, 19, 14, 43, 239, DateTimeKind.Local).AddTicks(9619), "Voluptatem possimus labore magnam. Nostrum odit earum veritatis. Nulla ea quisquam voluptas. Ipsa ea illo illo autem mollitia aut similique consequatur. Pariatur voluptas est. Voluptate voluptatem occaecati qui eveniet nihil et voluptatem commodi id." },
                    { 17, 99, 143, 378596, new DateTime(2020, 7, 19, 4, 38, 49, 490, DateTimeKind.Local).AddTicks(7807), "tenetur" },
                    { 145, 10, 44, 132672, new DateTime(2021, 3, 21, 10, 24, 23, 487, DateTimeKind.Local).AddTicks(1640), "Illo qui quis maiores quo rerum nihil sit expedita.\nNesciunt nulla blanditiis velit sint sint.\nFugit officiis ut deleniti et sed aperiam fugiat.\nQui beatae consequatur voluptatem et.\nMollitia dolorem fugit magni et excepturi rerum ut.\nArchitecto mollitia et corrupti." },
                    { 524, 10, 32, 446809, new DateTime(2020, 6, 25, 5, 28, 29, 59, DateTimeKind.Local).AddTicks(5294), "aut" },
                    { 51, 41, 53, 959613, new DateTime(2020, 5, 9, 1, 42, 51, 22, DateTimeKind.Local).AddTicks(6318), "Omnis ut voluptate necessitatibus corporis est dignissimos.\nMolestiae non magni dolores molestias distinctio dicta fugit deserunt fuga.\nIusto ex officiis officia eveniet aut optio.\nNon omnis reiciendis sunt est." },
                    { 169, 41, 3, 981128, new DateTime(2020, 11, 15, 13, 17, 7, 389, DateTimeKind.Local).AddTicks(9341), "Dicta sapiente adipisci aperiam maxime cumque dolores.\nNihil sit eum rerum quis." },
                    { 208, 41, 7, 136206, new DateTime(2021, 3, 19, 19, 14, 50, 885, DateTimeKind.Local).AddTicks(3914), "Quia expedita quod.\nQuo dolores quis culpa consequuntur." },
                    { 373, 41, 106, 536458, new DateTime(2020, 10, 24, 19, 15, 41, 535, DateTimeKind.Local).AddTicks(4789), "sed" },
                    { 434, 41, 133, 797248, new DateTime(2020, 7, 15, 4, 4, 15, 654, DateTimeKind.Local).AddTicks(4512), "Nam accusamus et qui deleniti optio necessitatibus officia ut." },
                    { 407, 77, 6, 187653, new DateTime(2020, 4, 6, 8, 49, 1, 615, DateTimeKind.Local).AddTicks(8266), "non" },
                    { 471, 41, 89, 855817, new DateTime(2020, 7, 23, 4, 39, 0, 575, DateTimeKind.Local).AddTicks(7944), "Ducimus quasi voluptas cum non quisquam repudiandae. Deleniti ut corporis consequatur quas aliquid nisi iste quis vero. Ratione omnis quis voluptatum. Nesciunt repellat voluptatem voluptatem ut commodi. Nisi quis voluptatum dolorem corporis ut rem nemo sint provident." },
                    { 549, 41, 99, 812038, new DateTime(2021, 2, 19, 10, 36, 34, 568, DateTimeKind.Local).AddTicks(5367), "Quam sed repellat omnis quidem nostrum maiores voluptatibus vel. Soluta at quisquam earum nemo ut adipisci et. Quia dolorum non. Nostrum dicta minima aut voluptate quae." },
                    { 66, 78, 112, 782740, new DateTime(2020, 7, 17, 22, 22, 0, 348, DateTimeKind.Local).AddTicks(1852), "Iste at qui sed." },
                    { 347, 78, 139, 225564, new DateTime(2020, 9, 28, 12, 56, 42, 428, DateTimeKind.Local).AddTicks(117), "labore" },
                    { 410, 78, 113, 425664, new DateTime(2021, 2, 13, 21, 36, 2, 788, DateTimeKind.Local).AddTicks(7107), "totam" },
                    { 414, 78, 88, 367381, new DateTime(2020, 6, 3, 7, 40, 27, 325, DateTimeKind.Local).AddTicks(7118), "Et perspiciatis perferendis sed consequatur vel.\nDucimus dolorum exercitationem dicta aliquid nesciunt excepturi et nobis est.\nQui et explicabo omnis animi iusto laudantium.\nAdipisci sequi nam sit sint temporibus alias sunt.\nCupiditate magni nesciunt modi.\nMolestias illo quia voluptates doloribus et totam distinctio expedita deleniti." },
                    { 419, 78, 1, 203935, new DateTime(2020, 11, 28, 6, 16, 47, 905, DateTimeKind.Local).AddTicks(9830), "Laboriosam vel molestiae ad eaque quibusdam.\nCorporis est dolore eos aut voluptates dicta ut id.\nEt velit recusandae." },
                    { 563, 78, 122, 395738, new DateTime(2020, 7, 28, 12, 40, 51, 46, DateTimeKind.Local).AddTicks(9659), "Ut sit reprehenderit quas numquam nam odio ut.\nCommodi minima sed quisquam sequi animi quae illum et.\nEt quisquam nisi et deleniti non qui doloremque occaecati placeat." },
                    { 540, 41, 43, 703529, new DateTime(2020, 10, 19, 16, 54, 22, 486, DateTimeKind.Local).AddTicks(5188), "quia" },
                    { 105, 10, 118, 308232, new DateTime(2020, 11, 19, 10, 55, 0, 36, DateTimeKind.Local).AddTicks(5857), "Minus natus velit et quaerat occaecati qui. Sint est natus repudiandae quisquam reprehenderit sequi. Qui inventore quis provident eveniet. Id rerum est autem voluptas delectus et esse. Quisquam qui voluptatem. Qui consequatur enim delectus earum odio omnis." },
                    { 418, 77, 20, 268839, new DateTime(2020, 6, 25, 21, 43, 53, 871, DateTimeKind.Local).AddTicks(6980), "corporis" },
                    { 285, 106, 122, 668783, new DateTime(2020, 4, 1, 10, 49, 36, 580, DateTimeKind.Local).AddTicks(1537), "voluptates" },
                    { 52, 110, 75, 771746, new DateTime(2020, 12, 10, 8, 18, 30, 243, DateTimeKind.Local).AddTicks(7233), "Iste cupiditate fuga maiores occaecati." },
                    { 115, 110, 27, 797358, new DateTime(2020, 11, 2, 0, 25, 46, 152, DateTimeKind.Local).AddTicks(6808), "Qui asperiores placeat sint. Rerum qui dolor. Eos voluptatum quod illum fugiat debitis dolor. Iure temporibus perspiciatis magnam id et eos ea. Omnis dignissimos quia. Ad quas sed non et consequuntur cupiditate." },
                    { 141, 110, 124, 83272, new DateTime(2020, 8, 4, 12, 22, 41, 786, DateTimeKind.Local).AddTicks(453), "quia" },
                    { 192, 110, 3, 304752, new DateTime(2021, 1, 24, 16, 53, 39, 442, DateTimeKind.Local).AddTicks(228), "Ut iste sed deleniti rem voluptatibus nesciunt." },
                    { 306, 110, 59, 829116, new DateTime(2020, 11, 11, 19, 1, 32, 307, DateTimeKind.Local).AddTicks(5337), "Fuga quia vero et delectus eaque ut occaecati omnis cum." },
                    { 309, 110, 114, 149404, new DateTime(2020, 10, 7, 9, 2, 25, 479, DateTimeKind.Local).AddTicks(2041), "mollitia" },
                    { 362, 110, 52, 907876, new DateTime(2020, 11, 10, 16, 10, 13, 137, DateTimeKind.Local).AddTicks(319), "Officiis facere aut dolorem ut nihil maxime aut." },
                    { 377, 110, 18, 837104, new DateTime(2020, 9, 9, 21, 29, 10, 64, DateTimeKind.Local).AddTicks(2805), "Beatae nulla sapiente officia totam sit consectetur." },
                    { 503, 110, 135, 920959, new DateTime(2020, 10, 7, 10, 40, 9, 315, DateTimeKind.Local).AddTicks(5741), "Eligendi assumenda odio fugiat incidunt laboriosam eveniet dolores harum illo.\nVeritatis eum animi accusantium est fugit est quibusdam impedit voluptas.\nMinus consectetur doloribus cupiditate corporis possimus temporibus impedit ipsa qui.\nEst ratione laudantium ratione aut rerum sit temporibus.\nEos eum fugit." },
                    { 514, 110, 109, 320712, new DateTime(2021, 1, 22, 8, 57, 21, 47, DateTimeKind.Local).AddTicks(5579), "aut" },
                    { 16, 95, 128, 838409, new DateTime(2020, 6, 23, 8, 49, 1, 796, DateTimeKind.Local).AddTicks(4753), "Consequatur exercitationem quae.\nEa in et officiis a.\nItaque et cupiditate dolorum sed et hic.\nEst odio qui perferendis ea soluta omnis ut." },
                    { 110, 95, 42, 11516, new DateTime(2020, 11, 24, 23, 44, 3, 595, DateTimeKind.Local).AddTicks(9683), "Autem natus laborum.\nEst ut dolorem fuga autem ipsa neque voluptatibus deserunt." },
                    { 135, 95, 10, 9842, new DateTime(2021, 2, 24, 20, 33, 46, 831, DateTimeKind.Local).AddTicks(8000), "Animi a nesciunt magnam." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 217, 95, 21, 691113, new DateTime(2020, 9, 3, 23, 14, 48, 793, DateTimeKind.Local).AddTicks(7521), "Nihil hic odit alias porro. Pariatur vel est ducimus qui. Blanditiis iste nihil." },
                    { 551, 95, 148, 605686, new DateTime(2020, 11, 10, 16, 41, 39, 397, DateTimeKind.Local).AddTicks(9408), "Earum libero est cum." },
                    { 12, 110, 59, 594823, new DateTime(2021, 1, 3, 4, 46, 40, 892, DateTimeKind.Local).AddTicks(3809), "Alias ipsam quis qui delectus sed doloribus.\nIpsam non quia reiciendis facilis ipsa.\nDolores officia architecto iste maxime fugit voluptates." },
                    { 352, 54, 32, 216291, new DateTime(2021, 1, 5, 14, 27, 44, 383, DateTimeKind.Local).AddTicks(5172), "Ratione blanditiis voluptatem.\nIllum quaerat enim eum id deserunt accusamus rem veniam eum.\nArchitecto totam omnis eos in possimus.\nQui qui quod unde." },
                    { 188, 54, 30, 998557, new DateTime(2020, 4, 28, 3, 34, 24, 428, DateTimeKind.Local).AddTicks(3496), "dolor" },
                    { 119, 54, 105, 293029, new DateTime(2020, 11, 16, 5, 58, 47, 664, DateTimeKind.Local).AddTicks(6907), "Ducimus minus accusamus quis sint maiores ea dolor iste.\nIllo minus accusantium deleniti quo ipsum pariatur dolorem.\nRerum est maiores repellendus accusantium nemo numquam enim mollitia." },
                    { 301, 106, 61, 877387, new DateTime(2020, 9, 8, 16, 3, 17, 62, DateTimeKind.Local).AddTicks(5117), "Qui sit ipsa repellat.\nRepudiandae hic deserunt.\nQuia impedit provident et et quasi.\nDicta sit praesentium numquam delectus quaerat corporis." },
                    { 592, 106, 126, 138572, new DateTime(2020, 8, 7, 12, 3, 54, 473, DateTimeKind.Local).AddTicks(5254), "Fugit unde commodi nisi odio et impedit dolores id." },
                    { 42, 48, 148, 524613, new DateTime(2020, 6, 30, 1, 2, 49, 44, DateTimeKind.Local).AddTicks(123), "Aut possimus delectus ducimus hic non consequatur similique.\nUllam eveniet illo nisi.\nBeatae quod ut tempora vitae officia ea dicta atque.\nNemo qui dolor in ea enim fuga veniam.\nEt harum quae consequatur natus voluptate beatae quas.\nEarum voluptatem pariatur." },
                    { 252, 48, 121, 812251, new DateTime(2021, 1, 15, 14, 2, 5, 567, DateTimeKind.Local).AddTicks(8712), "Consequuntur sed quos.\nQuae reiciendis at.\nNobis minus quia quibusdam.\nEt culpa laboriosam porro.\nMaiores eaque excepturi fugit." },
                    { 387, 48, 18, 624428, new DateTime(2020, 12, 10, 2, 23, 25, 196, DateTimeKind.Local).AddTicks(5248), "Sequi eum beatae laboriosam sed eos consequuntur saepe qui a." },
                    { 482, 48, 48, 572512, new DateTime(2020, 5, 27, 10, 30, 18, 311, DateTimeKind.Local).AddTicks(4350), "accusamus" },
                    { 500, 48, 13, 120302, new DateTime(2020, 3, 30, 5, 59, 28, 400, DateTimeKind.Local).AddTicks(129), "dolor" },
                    { 220, 106, 27, 63452, new DateTime(2020, 9, 17, 13, 29, 48, 925, DateTimeKind.Local).AddTicks(1174), "odit" },
                    { 465, 103, 145, 490151, new DateTime(2020, 10, 31, 14, 19, 21, 972, DateTimeKind.Local).AddTicks(5312), "placeat" },
                    { 164, 47, 117, 912046, new DateTime(2020, 12, 19, 19, 37, 49, 795, DateTimeKind.Local).AddTicks(6625), "Quo voluptatem et et." },
                    { 283, 47, 34, 531115, new DateTime(2020, 12, 4, 19, 19, 54, 212, DateTimeKind.Local).AddTicks(5191), "praesentium" },
                    { 292, 47, 47, 905165, new DateTime(2020, 7, 11, 23, 39, 50, 249, DateTimeKind.Local).AddTicks(9595), "Consequatur quas iusto. Sed velit voluptas minima consequatur ad veritatis. Quos beatae fugiat id recusandae et. Totam omnis itaque velit. Autem voluptas doloribus a modi. Et et occaecati." },
                    { 337, 47, 40, 663887, new DateTime(2021, 3, 9, 3, 31, 15, 406, DateTimeKind.Local).AddTicks(4096), "Ullam fuga est rerum aperiam placeat sit dolores.\nMaxime sunt ipsam odit ipsum.\nEt reprehenderit error quas ut facere et amet voluptatum.\nDolorem repudiandae asperiores omnis.\nCorrupti sapiente ratione dignissimos ab nam rerum beatae assumenda." },
                    { 530, 47, 27, 825783, new DateTime(2020, 7, 6, 10, 5, 10, 143, DateTimeKind.Local).AddTicks(9824), "Molestias voluptate dicta ut molestiae. Qui officiis alias ipsam est sapiente voluptas voluptas. Cumque harum sed aut deleniti recusandae minus voluptatem." },
                    { 570, 47, 31, 868826, new DateTime(2020, 11, 25, 11, 54, 8, 45, DateTimeKind.Local).AddTicks(3934), "Unde corrupti corrupti est quae. Impedit vitae aspernatur vel ipsam. Qui sequi consequuntur explicabo id mollitia fugit cum sed." },
                    { 104, 54, 15, 802934, new DateTime(2020, 8, 14, 19, 52, 47, 632, DateTimeKind.Local).AddTicks(3644), "Voluptatem nam consequatur et sit asperiores distinctio soluta. Minus ex veniam fugiat molestiae ad saepe. Mollitia ullam iste qui sunt quae necessitatibus. Fuga beatae itaque nostrum. Quam assumenda tempora praesentium saepe vel. Repellat est eligendi omnis vel." },
                    { 509, 103, 112, 318750, new DateTime(2020, 6, 1, 12, 53, 28, 31, DateTimeKind.Local).AddTicks(9679), "Facilis dolores ut autem sed est rem cumque.\nCorporis excepturi sed hic.\nExercitationem labore vel cupiditate non ab cum." },
                    { 58, 10, 23, 274166, new DateTime(2021, 2, 24, 11, 38, 29, 934, DateTimeKind.Local).AddTicks(8882), "aut" },
                    { 38, 10, 126, 108838, new DateTime(2020, 7, 3, 8, 23, 57, 978, DateTimeKind.Local).AddTicks(6024), "Nulla omnis voluptatum consequatur temporibus quos accusamus ipsam optio rerum. Quia quis dolorum magnam et aspernatur ut. Architecto consectetur vero doloribus perferendis laudantium eum voluptas ea." },
                    { 486, 72, 150, 662476, new DateTime(2020, 4, 23, 4, 51, 2, 914, DateTimeKind.Local).AddTicks(4572), "Praesentium asperiores hic adipisci quidem sint id ad reiciendis." },
                    { 238, 37, 13, 826036, new DateTime(2020, 10, 29, 18, 33, 25, 941, DateTimeKind.Local).AddTicks(9431), "Dolorem necessitatibus eum alias eveniet voluptatem officia fuga deleniti." },
                    { 235, 56, 136, 740516, new DateTime(2020, 10, 6, 15, 24, 2, 165, DateTimeKind.Local).AddTicks(6637), "Qui et laboriosam voluptas nulla quis odit atque assumenda voluptatem. Deleniti quis suscipit voluptatibus unde. Excepturi praesentium sapiente perferendis minima iure debitis. Beatae qui qui et dicta qui ex est qui facere. Est officia inventore error non quis. Natus explicabo eaque eligendi blanditiis placeat amet." },
                    { 318, 56, 65, 293035, new DateTime(2020, 12, 2, 23, 6, 34, 779, DateTimeKind.Local).AddTicks(6033), "Accusamus corrupti distinctio. Voluptatibus quos deserunt cupiditate doloremque alias numquam asperiores. Aspernatur voluptatum sit et culpa aut reiciendis molestias rerum." },
                    { 413, 56, 139, 166377, new DateTime(2020, 10, 7, 18, 9, 27, 783, DateTimeKind.Local).AddTicks(5329), "Commodi laborum eum tempore odio.\nEum non qui et ratione.\nAperiam id molestiae quas quod.\nArchitecto delectus et ipsum." },
                    { 568, 56, 118, 229955, new DateTime(2021, 2, 18, 4, 52, 40, 731, DateTimeKind.Local).AddTicks(4898), "Natus eum ea tempora aut et voluptas voluptate." },
                    { 594, 56, 106, 511039, new DateTime(2020, 5, 20, 4, 33, 17, 503, DateTimeKind.Local).AddTicks(2333), "error" },
                    { 109, 67, 54, 249280, new DateTime(2020, 3, 25, 22, 43, 12, 326, DateTimeKind.Local).AddTicks(7928), "Aut et est aperiam et autem rem. Itaque officia dolore qui placeat blanditiis error laborum illum. Dolorum in sunt. Quia sunt nihil perferendis est sed itaque enim autem sed. Assumenda eos ut animi aut quo dolor facilis quam quidem. Pariatur ipsum fugiat ex aspernatur." },
                    { 286, 67, 148, 76545, new DateTime(2020, 8, 30, 5, 1, 14, 272, DateTimeKind.Local).AddTicks(183), "Id modi quod voluptates minus voluptatum animi quia soluta.\nAliquid error tenetur sit quibusdam." },
                    { 287, 67, 55, 849095, new DateTime(2021, 1, 7, 13, 29, 37, 14, DateTimeKind.Local).AddTicks(2900), "Eos magni cum rerum. Maxime maxime qui. Qui quidem odio corporis esse. Sequi voluptatibus sit. Id pariatur dolor optio aliquid vitae culpa dolor. Accusamus numquam soluta." },
                    { 378, 67, 59, 253312, new DateTime(2020, 10, 10, 18, 27, 59, 289, DateTimeKind.Local).AddTicks(9421), "Aut fugit aut maxime qui." },
                    { 432, 67, 134, 14076, new DateTime(2020, 9, 15, 6, 5, 43, 644, DateTimeKind.Local).AddTicks(3098), "expedita" },
                    { 438, 67, 136, 272239, new DateTime(2021, 1, 22, 7, 53, 8, 719, DateTimeKind.Local).AddTicks(4582), "Commodi aut accusantium. Dolorem vel quisquam voluptates modi sequi officia laborum vero. Cum harum culpa ipsum quam qui cumque odio." },
                    { 521, 67, 56, 285105, new DateTime(2021, 3, 9, 9, 30, 27, 916, DateTimeKind.Local).AddTicks(1741), "Ab laudantium facilis. Quos saepe ratione consequatur labore nesciunt at vero dicta. Doloribus illo nobis voluptatem autem nesciunt tempora." },
                    { 88, 31, 78, 533660, new DateTime(2021, 1, 24, 23, 57, 44, 428, DateTimeKind.Local).AddTicks(8136), "Ducimus qui ab repellendus reiciendis.\nRecusandae perspiciatis commodi quo nihil.\nVel quod quia." },
                    { 236, 31, 12, 385564, new DateTime(2020, 5, 10, 14, 16, 31, 463, DateTimeKind.Local).AddTicks(3835), "Praesentium quam voluptas natus quis natus. Facere eveniet autem repellendus culpa et omnis sint. Saepe facere est maxime eum repellendus." },
                    { 221, 37, 7, 706278, new DateTime(2020, 7, 27, 12, 44, 46, 261, DateTimeKind.Local).AddTicks(8165), "Qui repellendus minima fuga voluptas natus mollitia occaecati facere." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 457, 30, 127, 80408, new DateTime(2021, 1, 5, 8, 27, 47, 458, DateTimeKind.Local).AddTicks(2621), "Quia dicta et unde sint eius necessitatibus qui. Rerum modi reprehenderit ea architecto mollitia. Est ut molestiae. Blanditiis cupiditate dolorem tempore commodi sint ipsum magni. Soluta a doloribus iste voluptatem dignissimos. A commodi id labore beatae omnis." },
                    { 431, 30, 32, 241184, new DateTime(2021, 1, 14, 13, 0, 17, 377, DateTimeKind.Local).AddTicks(9528), "Et dicta voluptatem expedita velit amet et in quis quibusdam. Odio pariatur facere rerum qui commodi fugit quod est. Officia voluptatibus consequatur dolores amet deserunt est ex. Ut ex est aut quia qui repellendus quos quae. Dolore delectus cumque reprehenderit totam. Iure tempora nulla quis debitis quia." },
                    { 390, 30, 59, 410340, new DateTime(2020, 5, 6, 21, 47, 52, 122, DateTimeKind.Local).AddTicks(8776), "Explicabo dolores sit ipsa voluptates omnis rem nam omnis.\nEt similique soluta ea nemo." },
                    { 229, 25, 41, 322450, new DateTime(2020, 4, 15, 17, 43, 24, 289, DateTimeKind.Local).AddTicks(1595), "doloribus" },
                    { 242, 25, 63, 269570, new DateTime(2021, 3, 3, 6, 5, 30, 876, DateTimeKind.Local).AddTicks(2420), "Quam voluptatem nam.\nTempora consequatur enim consequuntur est totam non." },
                    { 342, 25, 6, 83220, new DateTime(2020, 11, 26, 5, 26, 16, 587, DateTimeKind.Local).AddTicks(8259), "Corporis facilis ut cupiditate in odit deleniti.\nInventore doloribus est rem qui quod repudiandae sit delectus saepe.\nAd est id distinctio accusamus.\nArchitecto libero eos cupiditate dignissimos voluptas.\nVero recusandae beatae qui atque.\nVoluptas aspernatur nulla id cumque qui ad corporis architecto." },
                    { 353, 25, 41, 865029, new DateTime(2020, 5, 8, 18, 55, 39, 944, DateTimeKind.Local).AddTicks(834), "Et nesciunt qui.\nQuia voluptas quis incidunt aut architecto non neque in odio.\nAb dolor veniam excepturi id voluptatibus nostrum et." },
                    { 440, 25, 19, 19847, new DateTime(2021, 3, 20, 10, 36, 56, 44, DateTimeKind.Local).AddTicks(2534), "Reiciendis dolores voluptas voluptatem ex enim." },
                    { 468, 25, 29, 915790, new DateTime(2020, 8, 13, 16, 54, 39, 774, DateTimeKind.Local).AddTicks(3382), "Culpa ipsa repellat sit repellat ex ea dolorum dolor. Maxime ut excepturi hic accusamus assumenda velit. Autem odit facilis non et fugiat quia autem." },
                    { 525, 25, 125, 972302, new DateTime(2020, 5, 18, 12, 17, 5, 265, DateTimeKind.Local).AddTicks(9810), "sequi" },
                    { 396, 31, 140, 61283, new DateTime(2020, 4, 19, 15, 34, 57, 403, DateTimeKind.Local).AddTicks(6491), "natus" },
                    { 338, 104, 101, 444992, new DateTime(2021, 2, 24, 23, 0, 22, 664, DateTimeKind.Local).AddTicks(9224), "Rerum debitis sit eos aut enim eius." },
                    { 599, 104, 2, 855794, new DateTime(2020, 8, 4, 21, 20, 40, 295, DateTimeKind.Local).AddTicks(5598), "unde" },
                    { 219, 4, 109, 40439, new DateTime(2020, 9, 20, 21, 21, 30, 838, DateTimeKind.Local).AddTicks(9628), "Incidunt numquam aut molestias iusto nulla atque debitis commodi.\nConsequatur sapiente qui aut dolor nam aliquid quisquam in.\nAut veniam eaque est nam.\nVeritatis sed magnam aperiam enim non dignissimos reiciendis voluptatem rem.\nEnim laborum est architecto dolorem.\nEos doloremque ipsum rem." },
                    { 282, 4, 13, 414303, new DateTime(2020, 12, 11, 20, 47, 29, 524, DateTimeKind.Local).AddTicks(8228), "Et ad dolores ducimus at aliquam voluptatem architecto et.\nEt quisquam error et minima unde.\nVoluptatibus quidem sed aliquam quaerat." },
                    { 526, 4, 103, 236786, new DateTime(2020, 4, 6, 0, 34, 37, 229, DateTimeKind.Local).AddTicks(74), "Perferendis maxime sunt beatae consectetur." },
                    { 4, 30, 130, 141967, new DateTime(2020, 4, 16, 21, 54, 46, 150, DateTimeKind.Local).AddTicks(2513), "excepturi" },
                    { 154, 30, 64, 495629, new DateTime(2020, 4, 7, 10, 9, 6, 868, DateTimeKind.Local).AddTicks(7766), "Voluptas sequi blanditiis ab assumenda dolorem praesentium quas. Incidunt accusantium molestiae enim eos necessitatibus quia error. Ducimus dolor sint." },
                    { 184, 30, 65, 794845, new DateTime(2021, 3, 13, 12, 39, 19, 523, DateTimeKind.Local).AddTicks(4178), "Dolore illo quod maiores cumque dolor expedita. Dolore perspiciatis laborum quas necessitatibus voluptate nemo qui quia. Omnis totam laboriosam voluptatem eos dicta fugiat. Excepturi et dolores numquam quia deserunt ut dolores aut iure. Quas excepturi in id odio sit. Laboriosam cum eligendi odio aut modi." },
                    { 480, 104, 61, 981405, new DateTime(2020, 4, 10, 15, 11, 2, 489, DateTimeKind.Local).AddTicks(5842), "Illum et et fugiat tempora suscipit est. Dolores deleniti voluptates fugit architecto inventore velit illo aut. Beatae eum est iure natus pariatur. Incidunt repellat pariatur distinctio praesentium magni." },
                    { 403, 31, 16, 685278, new DateTime(2020, 5, 30, 15, 9, 30, 278, DateTimeKind.Local).AddTicks(9982), "totam" },
                    { 496, 31, 49, 394844, new DateTime(2020, 10, 3, 12, 56, 55, 557, DateTimeKind.Local).AddTicks(126), "Ea quisquam nesciunt eius qui ab et quia molestiae qui." },
                    { 140, 45, 145, 212955, new DateTime(2020, 11, 8, 11, 15, 30, 364, DateTimeKind.Local).AddTicks(2486), "ut" },
                    { 63, 108, 44, 560517, new DateTime(2020, 6, 21, 1, 53, 58, 516, DateTimeKind.Local).AddTicks(7086), "Maxime eum quod sit non est." },
                    { 149, 108, 149, 321410, new DateTime(2020, 11, 5, 9, 26, 44, 272, DateTimeKind.Local).AddTicks(1667), "Quod distinctio enim sed." },
                    { 150, 108, 92, 984468, new DateTime(2020, 9, 24, 7, 59, 56, 795, DateTimeKind.Local).AddTicks(6549), "Omnis amet facere nobis et omnis assumenda." },
                    { 231, 108, 45, 83756, new DateTime(2020, 12, 15, 19, 48, 50, 646, DateTimeKind.Local).AddTicks(3906), "Laborum iste repellat numquam. A dolorem nam omnis occaecati porro. Labore quis atque consequatur sed incidunt consectetur." },
                    { 280, 108, 113, 342000, new DateTime(2020, 12, 4, 16, 35, 39, 544, DateTimeKind.Local).AddTicks(9200), "eos" },
                    { 383, 108, 36, 390431, new DateTime(2020, 7, 3, 0, 4, 31, 208, DateTimeKind.Local).AddTicks(2789), "et" },
                    { 71, 93, 148, 96212, new DateTime(2020, 7, 26, 1, 18, 36, 103, DateTimeKind.Local).AddTicks(1717), "neque" },
                    { 590, 15, 14, 819350, new DateTime(2020, 11, 13, 15, 57, 52, 991, DateTimeKind.Local).AddTicks(5556), "Quia minima est neque ab dolorem saepe. Non exercitationem debitis aut saepe impedit sit. Vitae veniam reiciendis." },
                    { 162, 93, 97, 12680, new DateTime(2020, 7, 13, 22, 39, 34, 634, DateTimeKind.Local).AddTicks(4315), "mollitia" },
                    { 215, 93, 79, 471133, new DateTime(2020, 5, 25, 23, 51, 45, 38, DateTimeKind.Local).AddTicks(638), "et" },
                    { 345, 93, 104, 991472, new DateTime(2021, 2, 19, 22, 28, 39, 465, DateTimeKind.Local).AddTicks(2038), "Nostrum repellat autem animi dicta minus dolorem expedita modi enim." },
                    { 425, 93, 110, 254643, new DateTime(2020, 9, 30, 8, 5, 35, 28, DateTimeKind.Local).AddTicks(6053), "Nostrum enim incidunt et facere dicta illum omnis ratione.\nUllam unde rem soluta vero amet est consequatur.\nDistinctio provident nemo qui.\nNam cum suscipit modi sunt.\nDolores molestiae nostrum vero alias labore molestiae." },
                    { 564, 93, 90, 761875, new DateTime(2020, 11, 1, 3, 45, 3, 264, DateTimeKind.Local).AddTicks(5317), "Fuga excepturi sit. Sit sed et non ut facere doloribus. Quas maxime impedit reiciendis mollitia et aut iste. Repudiandae exercitationem reprehenderit harum sint voluptatem velit delectus qui." },
                    { 34, 72, 132, 224173, new DateTime(2020, 11, 10, 16, 10, 13, 474, DateTimeKind.Local).AddTicks(7317), "Adipisci a voluptatibus ullam earum dolor animi.\nAliquid officia rerum sint eum possimus enim consequuntur tenetur culpa." },
                    { 363, 72, 20, 10198, new DateTime(2020, 5, 31, 1, 35, 50, 961, DateTimeKind.Local).AddTicks(9485), "dolorum" },
                    { 474, 72, 134, 2344, new DateTime(2020, 6, 27, 12, 51, 45, 751, DateTimeKind.Local).AddTicks(3364), "Harum qui tenetur voluptatem est quod ea qui et.\nSunt impedit sequi a explicabo illum rerum et." },
                    { 198, 93, 8, 790883, new DateTime(2020, 6, 28, 23, 5, 24, 626, DateTimeKind.Local).AddTicks(5699), "Beatae quos voluptatibus ea et a voluptatibus totam. Tenetur architecto quia. Et dolor doloremque." },
                    { 483, 49, 103, 824636, new DateTime(2021, 2, 10, 14, 47, 54, 566, DateTimeKind.Local).AddTicks(4637), "Nam expedita veritatis aut." },
                    { 535, 15, 146, 380769, new DateTime(2021, 1, 30, 12, 31, 12, 167, DateTimeKind.Local).AddTicks(9277), "Enim ratione quas non nihil. Necessitatibus et et tempore saepe ut eum odit. Et vitae reprehenderit aut." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 448, 15, 137, 729284, new DateTime(2020, 5, 4, 21, 1, 9, 954, DateTimeKind.Local).AddTicks(618), "Delectus recusandae sunt sit tenetur officia doloribus quaerat ab. Architecto voluptate veritatis. Sint eos sunt atque quaerat voluptate aliquam est aut. Impedit quis molestiae. Deserunt incidunt at sapiente quas aut a minus ut qui." },
                    { 147, 45, 77, 321431, new DateTime(2020, 6, 8, 16, 30, 49, 534, DateTimeKind.Local).AddTicks(258), "Tenetur perspiciatis et animi qui commodi sunt iure eveniet facere.\nAsperiores ipsa possimus quas.\nEt cumque in voluptates molestiae est debitis ipsa adipisci." },
                    { 327, 45, 72, 867320, new DateTime(2020, 3, 28, 10, 36, 1, 563, DateTimeKind.Local).AddTicks(9462), "Quasi et quia voluptas qui nihil nostrum.\nEst deleniti eos necessitatibus.\nNemo sed dolor minus officiis perferendis voluptatum architecto modi iste.\nAnimi earum nisi in saepe impedit rem ratione." },
                    { 497, 45, 62, 502071, new DateTime(2021, 2, 12, 14, 25, 51, 121, DateTimeKind.Local).AddTicks(3855), "Aperiam facere nemo.\nSit rerum rem dolor ad quo.\nRem occaecati laudantium autem ea molestiae." },
                    { 528, 45, 109, 579352, new DateTime(2020, 5, 27, 4, 57, 2, 588, DateTimeKind.Local).AddTicks(7703), "Eos expedita et sapiente rerum qui aut. Dolores voluptatem aliquam et iusto corrupti adipisci non. Minima autem aut quia mollitia. Harum voluptas delectus sint voluptas in iure. Laborum ducimus qui." },
                    { 561, 45, 43, 17904, new DateTime(2021, 3, 16, 21, 3, 21, 832, DateTimeKind.Local).AddTicks(2119), "Et nemo dicta quia qui vero commodi molestias. Incidunt at consequatur voluptatem quia libero maxime deleniti et. Aperiam aut omnis aliquid autem iure. Et quo praesentium voluptatem necessitatibus nesciunt aut. Qui neque provident illum. Ut dolor dignissimos enim voluptatem expedita incidunt voluptatem." },
                    { 392, 69, 64, 79267, new DateTime(2021, 3, 15, 16, 4, 48, 257, DateTimeKind.Local).AddTicks(2560), "labore" },
                    { 473, 69, 15, 620439, new DateTime(2020, 9, 4, 5, 34, 5, 527, DateTimeKind.Local).AddTicks(2912), "vel" },
                    { 506, 15, 92, 13595, new DateTime(2020, 9, 16, 16, 6, 7, 433, DateTimeKind.Local).AddTicks(3601), "Cum pariatur ut beatae non id quia eos est odio.\nHarum et officia odio molestiae eveniet sapiente labore.\nEt quod non qui deserunt voluptatem illum cupiditate sit iste.\nPorro ipsa vitae praesentium at magni dolorem ipsam aut quo.\nDolorum corrupti ut necessitatibus consequatur." },
                    { 6, 7, 139, 534074, new DateTime(2020, 10, 28, 0, 22, 54, 991, DateTimeKind.Local).AddTicks(4701), "Omnis officiis et repellendus reiciendis aut modi maiores.\nSed eos ipsa maiores iusto voluptatem est aperiam exercitationem vel.\nAssumenda veniam doloribus sint.\nIn officiis at quis quia rem.\nSed minus quo possimus fugiat." },
                    { 408, 7, 118, 233802, new DateTime(2020, 4, 5, 16, 12, 38, 449, DateTimeKind.Local).AddTicks(8400), "Consequatur a rem aut molestiae consequatur et et." },
                    { 516, 7, 81, 252853, new DateTime(2020, 6, 11, 20, 38, 13, 581, DateTimeKind.Local).AddTicks(1115), "eaque" },
                    { 541, 7, 128, 486975, new DateTime(2020, 11, 21, 18, 57, 30, 370, DateTimeKind.Local).AddTicks(1910), "Reiciendis omnis aut.\nMagni neque quisquam ducimus laudantium aut fugiat necessitatibus velit dolore." },
                    { 36, 15, 75, 128255, new DateTime(2020, 11, 6, 3, 12, 31, 783, DateTimeKind.Local).AddTicks(7065), "Ut qui provident rerum dolorem dolores.\nAut assumenda et porro ut sed ratione sapiente.\nVoluptatem mollitia quis debitis molestias fuga id dolore ut sint.\nOmnis odit rerum nulla non." },
                    { 326, 15, 101, 734252, new DateTime(2020, 8, 29, 7, 42, 49, 722, DateTimeKind.Local).AddTicks(5453), "Aliquid et repellat sit distinctio est quas occaecati est quisquam." },
                    { 402, 15, 100, 722080, new DateTime(2020, 7, 9, 14, 25, 24, 705, DateTimeKind.Local).AddTicks(7277), "Rem officia vel incidunt." },
                    { 409, 15, 114, 493641, new DateTime(2021, 2, 19, 8, 58, 15, 533, DateTimeKind.Local).AddTicks(1018), "Nihil inventore ut temporibus consequatur quia ut sed.\nPerspiciatis quia eum eius et blanditiis.\nDoloribus quas neque sapiente repudiandae tenetur molestiae rerum laudantium fuga.\nEt similique sunt id.\nMagnam voluptatem ut magni esse dolore." },
                    { 366, 7, 33, 324025, new DateTime(2020, 5, 28, 12, 20, 34, 577, DateTimeKind.Local).AddTicks(4496), "Tenetur voluptatem rem accusamus laboriosam voluptas dolore vitae cupiditate." },
                    { 67, 33, 40, 16558, new DateTime(2020, 7, 17, 8, 46, 25, 751, DateTimeKind.Local).AddTicks(6316), "Aut expedita sunt est sint. Sint omnis est iusto aut cum nobis. Non et delectus quidem placeat nulla veniam minima. In iusto unde adipisci velit minus." },
                    { 556, 14, 120, 261640, new DateTime(2020, 11, 8, 3, 14, 6, 511, DateTimeKind.Local).AddTicks(9561), "Qui totam laudantium quos et consequatur." },
                    { 452, 90, 144, 225876, new DateTime(2021, 3, 7, 11, 33, 10, 737, DateTimeKind.Local).AddTicks(830), "Qui ab officiis officiis.\nOmnis impedit dolorum aut voluptas ut." },
                    { 485, 17, 99, 134632, new DateTime(2020, 4, 8, 17, 28, 0, 160, DateTimeKind.Local).AddTicks(9723), "aliquid" },
                    { 7, 101, 41, 478020, new DateTime(2020, 4, 18, 22, 16, 36, 197, DateTimeKind.Local).AddTicks(7111), "Necessitatibus eveniet non explicabo sit possimus culpa reiciendis beatae." },
                    { 19, 101, 38, 14690, new DateTime(2020, 5, 4, 18, 52, 43, 860, DateTimeKind.Local).AddTicks(2185), "Aliquid nulla ut quos eveniet ut. Asperiores itaque consequatur repellendus reprehenderit et accusantium. Aut ut maiores. Ratione quod qui maiores. Id similique minus iste fugiat et consectetur quidem quia nemo. Alias quas libero illo impedit dolor." },
                    { 59, 101, 26, 480458, new DateTime(2021, 1, 23, 5, 22, 20, 691, DateTimeKind.Local).AddTicks(1771), "Est nesciunt odit et odio nemo labore. Ab eaque voluptates et facilis sit officia incidunt. Non quo ex nihil. Voluptatem ipsa ducimus et odit accusantium illo laborum nam." },
                    { 380, 17, 34, 832252, new DateTime(2020, 6, 15, 9, 7, 24, 687, DateTimeKind.Local).AddTicks(9908), "reprehenderit" },
                    { 124, 101, 7, 524670, new DateTime(2020, 7, 12, 18, 59, 13, 758, DateTimeKind.Local).AddTicks(2130), "molestiae" },
                    { 581, 70, 20, 689798, new DateTime(2021, 2, 23, 6, 38, 41, 254, DateTimeKind.Local).AddTicks(3713), "Deleniti eos ut aliquam quam quia fugit dolorem sunt." },
                    { 264, 101, 117, 939358, new DateTime(2020, 10, 7, 5, 7, 39, 373, DateTimeKind.Local).AddTicks(9070), "Molestiae aut voluptatum dolorem saepe vel vel.\nUllam veritatis quia ea.\nQui est deleniti odio molestiae quia debitis.\nMagni non non occaecati odio eos." },
                    { 405, 101, 6, 61717, new DateTime(2020, 8, 22, 22, 11, 28, 679, DateTimeKind.Local).AddTicks(1054), "Ut pariatur dolores." },
                    { 422, 101, 56, 514315, new DateTime(2020, 4, 7, 5, 5, 59, 664, DateTimeKind.Local).AddTicks(7410), "aliquid" },
                    { 539, 101, 143, 947777, new DateTime(2020, 9, 2, 21, 40, 7, 224, DateTimeKind.Local).AddTicks(5037), "Est maxime laboriosam nostrum error dignissimos ut accusamus." },
                    { 375, 17, 2, 273677, new DateTime(2020, 4, 20, 15, 48, 37, 993, DateTimeKind.Local).AddTicks(9442), "ratione" },
                    { 2, 62, 1, 416434, new DateTime(2021, 1, 28, 13, 40, 23, 325, DateTimeKind.Local).AddTicks(5837), "Delectus nemo asperiores qui ipsa aut non molestias totam dignissimos. Eligendi incidunt dolor quos inventore cumque. Nostrum et temporibus blanditiis quis at praesentium dolor. Quia earum iure dolorem et quas. Aut placeat ea aperiam." },
                    { 152, 62, 99, 785370, new DateTime(2020, 10, 12, 16, 30, 12, 542, DateTimeKind.Local).AddTicks(6757), "facere" },
                    { 291, 101, 44, 949415, new DateTime(2020, 11, 24, 3, 32, 21, 639, DateTimeKind.Local).AddTicks(5520), "nemo" },
                    { 393, 62, 16, 778733, new DateTime(2020, 12, 30, 10, 45, 14, 899, DateTimeKind.Local).AddTicks(9845), "Est qui quos perferendis velit eveniet quia ab." },
                    { 384, 70, 104, 482927, new DateTime(2020, 4, 13, 15, 17, 54, 763, DateTimeKind.Local).AddTicks(4770), "rem" },
                    { 273, 70, 71, 596493, new DateTime(2021, 2, 20, 20, 26, 15, 978, DateTimeKind.Local).AddTicks(5642), "Quos ea tempore omnis ut est.\nEos ipsam non eos corrupti.\nFugiat consequuntur pariatur fugit fugiat nam accusamus optio praesentium.\nSed et eum.\nAut velit suscipit.\nNihil dolore est at." },
                    { 389, 65, 124, 975983, new DateTime(2020, 3, 30, 13, 15, 19, 451, DateTimeKind.Local).AddTicks(7465), "Aspernatur commodi sapiente ipsam et.\nPerspiciatis eos temporibus id iure sed magnam autem accusantium.\nEst quia sapiente earum sapiente temporibus atque omnis ab odit.\nNumquam perspiciatis et.\nCommodi provident excepturi." },
                    { 148, 5, 129, 223654, new DateTime(2020, 9, 3, 5, 12, 7, 45, DateTimeKind.Local).AddTicks(2567), "Rerum quos exercitationem dicta et amet quia autem.\nRerum aspernatur et consequatur laboriosam molestias.\nEt at quis.\nNemo voluptatem provident corporis libero qui voluptate itaque ipsa.\nDebitis laboriosam aut excepturi ex unde praesentium esse.\nIpsam in id non atque." },
                    { 186, 5, 147, 671267, new DateTime(2021, 3, 21, 20, 25, 50, 198, DateTimeKind.Local).AddTicks(3826), "Nemo doloremque laboriosam sit sed facere in et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 233, 5, 145, 698192, new DateTime(2021, 1, 30, 4, 40, 13, 736, DateTimeKind.Local).AddTicks(785), "Id inventore ducimus ipsam in optio velit et enim. Cum aut distinctio aut repudiandae magni molestias voluptates. Recusandae sit illo in qui nam ut." },
                    { 266, 5, 97, 96560, new DateTime(2020, 5, 23, 19, 31, 22, 106, DateTimeKind.Local).AddTicks(1262), "magni" },
                    { 388, 5, 64, 704345, new DateTime(2020, 7, 15, 12, 37, 20, 692, DateTimeKind.Local).AddTicks(2273), "nulla" },
                    { 278, 70, 101, 390028, new DateTime(2020, 12, 10, 19, 6, 28, 514, DateTimeKind.Local).AddTicks(487), "dolore" },
                    { 210, 65, 85, 399066, new DateTime(2020, 5, 12, 0, 40, 46, 914, DateTimeKind.Local).AddTicks(2829), "iure" },
                    { 203, 65, 31, 215107, new DateTime(2020, 10, 18, 16, 25, 52, 29, DateTimeKind.Local).AddTicks(5515), "Voluptate dolor et architecto dignissimos veniam nesciunt incidunt ullam." },
                    { 583, 92, 117, 686406, new DateTime(2020, 6, 22, 10, 35, 3, 750, DateTimeKind.Local).AddTicks(1380), "Aperiam molestiae provident eligendi.\nQuo perspiciatis consequatur sequi.\nDistinctio ex et.\nMolestias ipsum modi officia minima recusandae qui molestiae consequatur velit.\nPraesentium qui cum rem.\nEligendi eum laudantium molestiae consequuntur." },
                    { 74, 65, 124, 256787, new DateTime(2020, 6, 20, 19, 16, 21, 83, DateTimeKind.Local).AddTicks(3653), "Alias quis veniam itaque omnis qui labore blanditiis omnis. Facilis qui aspernatur quasi dolorem fugit eligendi. Aut repudiandae eum. Et ut ab." },
                    { 33, 22, 105, 841580, new DateTime(2020, 12, 29, 12, 22, 1, 163, DateTimeKind.Local).AddTicks(73), "Ut possimus sit dolorem quo non." },
                    { 487, 22, 138, 919441, new DateTime(2020, 4, 18, 3, 56, 56, 733, DateTimeKind.Local).AddTicks(3382), "Accusamus aut reiciendis. Eos repudiandae ea repellendus molestiae rerum. Rem et nostrum dolorem soluta tenetur aut velit et." },
                    { 600, 22, 12, 881793, new DateTime(2020, 9, 24, 18, 46, 51, 243, DateTimeKind.Local).AddTicks(9613), "Tempora possimus illo est necessitatibus nulla alias in at." },
                    { 443, 92, 123, 295798, new DateTime(2020, 9, 4, 4, 23, 16, 585, DateTimeKind.Local).AddTicks(3102), "modi" },
                    { 460, 97, 18, 530179, new DateTime(2020, 10, 18, 10, 29, 9, 891, DateTimeKind.Local).AddTicks(2798), "sint" },
                    { 417, 62, 76, 583566, new DateTime(2021, 2, 10, 4, 25, 36, 654, DateTimeKind.Local).AddTicks(9471), "Numquam provident dolores sit autem voluptatem aspernatur esse placeat." },
                    { 519, 62, 147, 564364, new DateTime(2021, 1, 13, 5, 1, 2, 553, DateTimeKind.Local).AddTicks(3513), "Est quo rem.\nOmnis dolore dolorem ut ad sed ullam perferendis." },
                    { 311, 1, 41, 259209, new DateTime(2021, 1, 14, 9, 13, 16, 421, DateTimeKind.Local).AddTicks(4821), "modi" },
                    { 341, 1, 64, 241215, new DateTime(2020, 3, 25, 8, 4, 42, 306, DateTimeKind.Local).AddTicks(7613), "Laboriosam commodi autem et quia nostrum qui. Voluptas ducimus ut necessitatibus cumque occaecati eum tempora placeat. Ut sed voluptas eligendi omnis. Repellat est eius veritatis." },
                    { 84, 17, 108, 166014, new DateTime(2021, 3, 22, 0, 49, 32, 86, DateTimeKind.Local).AddTicks(8745), "Ducimus maxime at.\nNon natus est culpa voluptatem voluptatem quia corporis.\nCorrupti architecto quam.\nQui qui distinctio vel alias ut ratione architecto dolores et.\nEt modi minus.\nDoloremque nobis est qui quos." },
                    { 379, 1, 35, 247623, new DateTime(2020, 4, 11, 15, 56, 27, 323, DateTimeKind.Local).AddTicks(3315), "ad" },
                    { 504, 1, 21, 822029, new DateTime(2020, 11, 4, 20, 7, 38, 196, DateTimeKind.Local).AddTicks(6577), "ut" },
                    { 518, 1, 90, 74140, new DateTime(2020, 12, 27, 14, 53, 32, 821, DateTimeKind.Local).AddTicks(5554), "cumque" },
                    { 260, 1, 30, 218832, new DateTime(2020, 10, 13, 8, 48, 31, 775, DateTimeKind.Local).AddTicks(287), "Sit enim et rem consequatur.\nDeleniti voluptatem architecto exercitationem.\nEx est autem praesentium deserunt.\nCorporis dolor corporis debitis est est corrupti pariatur." },
                    { 43, 17, 63, 770568, new DateTime(2020, 4, 25, 11, 43, 18, 166, DateTimeKind.Local).AddTicks(6510), "Excepturi enim iure quisquam ad eius qui aut. Est dolorem quo cum et esse. Consequuntur aperiam quis voluptatibus illum consequatur. Nemo ratione praesentium. In et ea esse sint qui repudiandae assumenda voluptas voluptatum." },
                    { 576, 1, 38, 928647, new DateTime(2021, 3, 13, 3, 39, 53, 820, DateTimeKind.Local).AddTicks(1168), "Fuga iste velit aut sunt.\nQuia a sunt et est vel tempore.\nUt laudantium in earum eos dolorem corrupti.\nQuia laudantium enim rem facere ut.\nAsperiores eaque soluta illo aut dolorem animi architecto accusamus." },
                    { 591, 58, 67, 970188, new DateTime(2020, 3, 25, 15, 35, 51, 802, DateTimeKind.Local).AddTicks(6428), "Sed est facere delectus ut nihil quia et nisi aut." },
                    { 459, 58, 20, 409399, new DateTime(2021, 2, 19, 21, 13, 35, 123, DateTimeKind.Local).AddTicks(6101), "Ratione aut ea recusandae nobis facilis cum enim." },
                    { 60, 55, 138, 75263, new DateTime(2020, 9, 12, 13, 33, 42, 690, DateTimeKind.Local).AddTicks(2576), "Praesentium quis possimus et nihil iste inventore." },
                    { 83, 55, 19, 522380, new DateTime(2020, 7, 13, 13, 48, 4, 269, DateTimeKind.Local).AddTicks(9751), "Dolores molestiae porro et explicabo fugit." },
                    { 546, 89, 22, 187032, new DateTime(2020, 10, 23, 22, 18, 12, 505, DateTimeKind.Local).AddTicks(9845), "Nihil necessitatibus ex dignissimos. Cumque sapiente mollitia debitis beatae aspernatur qui qui ab. Voluptatem magni sunt provident beatae harum quisquam et iure." },
                    { 538, 1, 47, 927708, new DateTime(2020, 8, 4, 6, 36, 19, 171, DateTimeKind.Local).AddTicks(1036), "voluptates" },
                    { 508, 62, 19, 590462, new DateTime(2020, 4, 13, 16, 54, 21, 428, DateTimeKind.Local).AddTicks(242), "deleniti" },
                    { 240, 1, 124, 688155, new DateTime(2020, 9, 6, 6, 38, 37, 442, DateTimeKind.Local).AddTicks(2150), "Neque ut et officiis placeat earum temporibus sed. Voluptatem quia non et sunt molestiae ut necessitatibus. Quas reiciendis quisquam assumenda autem mollitia. Qui fugiat eos quaerat quia quia aut aut nemo. Reprehenderit cum cupiditate architecto vel nostrum. Iste voluptatem voluptas fuga est." },
                    { 81, 1, 107, 24679, new DateTime(2020, 5, 16, 3, 53, 52, 484, DateTimeKind.Local).AddTicks(8762), "Nemo facere impedit eius voluptas. Velit nesciunt et quibusdam dolores ut et qui. Sint cumque iure impedit." },
                    { 85, 74, 46, 928069, new DateTime(2020, 4, 20, 4, 53, 14, 954, DateTimeKind.Local).AddTicks(7739), "Reprehenderit aliquid ab fuga. Aut omnis ullam ullam ipsam facilis dignissimos. Nihil et architecto possimus. Quo non provident ab ad commodi quo cum." },
                    { 507, 90, 80, 784554, new DateTime(2020, 9, 19, 23, 16, 55, 600, DateTimeKind.Local).AddTicks(1238), "Et ut itaque rerum vitae corrupti." },
                    { 112, 74, 132, 959671, new DateTime(2020, 11, 21, 11, 21, 15, 611, DateTimeKind.Local).AddTicks(619), "Voluptatem placeat laudantium ut deleniti modi dolor vel omnis.\nConsectetur et et sit non." },
                    { 241, 74, 130, 110305, new DateTime(2020, 8, 14, 8, 38, 23, 891, DateTimeKind.Local).AddTicks(9291), "Consequatur doloribus qui eos quia doloremque." },
                    { 248, 74, 121, 654651, new DateTime(2021, 1, 24, 23, 50, 41, 977, DateTimeKind.Local).AddTicks(8015), "Occaecati rerum similique. Voluptatibus dolores amet. Officiis consequatur qui id consequatur qui." },
                    { 346, 74, 57, 371122, new DateTime(2020, 12, 4, 0, 16, 20, 989, DateTimeKind.Local).AddTicks(959), "Est saepe delectus adipisci dolores accusantium et laudantium aut. Quas explicabo nulla consequuntur quia voluptas cupiditate voluptatem quia veniam. Qui velit quod quas non animi vel non. Odio consequuntur nobis voluptatem laborum excepturi laboriosam qui nesciunt. In dolores veniam est voluptatem error vel sit aut ratione." },
                    { 237, 1, 75, 102988, new DateTime(2021, 3, 20, 9, 10, 52, 995, DateTimeKind.Local).AddTicks(750), "Eos repellendus soluta culpa alias enim dolorem nostrum.\nEt est pariatur.\nAdipisci et et officiis dolore velit perspiciatis veniam animi.\nDolor molestiae est cum.\nVel quis numquam eum veritatis explicabo aperiam." },
                    { 394, 74, 99, 263588, new DateTime(2021, 2, 13, 18, 44, 0, 518, DateTimeKind.Local).AddTicks(1046), "Officia quisquam tenetur consectetur nisi enim qui in dicta.\nDoloribus quos et.\nVoluptatum itaque ut assumenda consequuntur." },
                    { 557, 74, 97, 247772, new DateTime(2021, 1, 19, 22, 2, 38, 563, DateTimeKind.Local).AddTicks(4003), "Totam veritatis modi numquam sed asperiores harum." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 234, 109, 38, 737968, new DateTime(2020, 7, 1, 8, 48, 15, 686, DateTimeKind.Local).AddTicks(4294), "Aut expedita qui dolorem et error aperiam officiis ut voluptas.\nNihil velit ipsam minima dolor qui aspernatur tempora.\nEos sint unde distinctio illo et.\nOmnis et quia ut aut.\nUt at ipsam assumenda corporis impedit ut occaecati veritatis temporibus." },
                    { 281, 109, 99, 710132, new DateTime(2021, 2, 24, 22, 23, 33, 863, DateTimeKind.Local).AddTicks(6682), "Ullam facere quam esse voluptatem qui corporis dicta nihil quod." },
                    { 359, 109, 15, 957564, new DateTime(2020, 12, 12, 7, 46, 35, 648, DateTimeKind.Local).AddTicks(9347), "Praesentium et sint aliquid iste quae eveniet cumque quia qui. Modi quisquam rerum vitae. Velit voluptatem aut nam qui molestiae nulla. Quia aut architecto quo quasi. Eos est ut. Voluptas quo ut ut qui asperiores et voluptates alias aut." },
                    { 531, 109, 100, 196817, new DateTime(2020, 8, 27, 3, 3, 39, 52, DateTimeKind.Local).AddTicks(4763), "accusantium" },
                    { 176, 17, 17, 927598, new DateTime(2020, 8, 1, 2, 53, 56, 660, DateTimeKind.Local).AddTicks(3391), "Perferendis eos est voluptates. Enim pariatur exercitationem quae quis consequatur quam fuga. Asperiores voluptatem magni eius." },
                    { 423, 74, 149, 313501, new DateTime(2020, 11, 25, 23, 25, 49, 498, DateTimeKind.Local).AddTicks(6287), "Mollitia quia ipsa autem sint. Magni veritatis aliquam. Qui illo iusto suscipit pariatur. Aspernatur nihil sint similique expedita. Deleniti explicabo quia." },
                    { 254, 55, 49, 214702, new DateTime(2020, 7, 27, 16, 23, 39, 318, DateTimeKind.Local).AddTicks(8331), "Et labore fugit praesentium saepe aut esse unde." },
                    { 358, 97, 30, 469490, new DateTime(2020, 10, 10, 17, 58, 58, 826, DateTimeKind.Local).AddTicks(8321), "Hic eaque qui est non dolores corrupti sit eligendi voluptatibus." },
                    { 247, 97, 93, 853651, new DateTime(2020, 11, 18, 22, 59, 38, 642, DateTimeKind.Local).AddTicks(9152), "odit" },
                    { 536, 23, 136, 412848, new DateTime(2020, 11, 17, 17, 2, 39, 439, DateTimeKind.Local).AddTicks(37), "dolorem" },
                    { 598, 23, 52, 940624, new DateTime(2020, 7, 10, 16, 31, 21, 16, DateTimeKind.Local).AddTicks(5362), "Dolorem quo iure ut aperiam qui laudantium aut." },
                    { 577, 46, 29, 262322, new DateTime(2021, 3, 23, 19, 43, 59, 399, DateTimeKind.Local).AddTicks(4111), "Et veniam tenetur enim. Dignissimos et iure similique debitis amet ut hic fugiat et. Sunt dicta in et consequatur omnis et in consequatur. Provident voluptates non nesciunt ut expedita." },
                    { 24, 42, 83, 248558, new DateTime(2021, 2, 4, 17, 28, 14, 769, DateTimeKind.Local).AddTicks(2412), "et" },
                    { 65, 42, 67, 265873, new DateTime(2021, 2, 13, 2, 19, 29, 6, DateTimeKind.Local).AddTicks(9618), "quam" },
                    { 160, 42, 42, 798207, new DateTime(2020, 10, 1, 8, 34, 6, 924, DateTimeKind.Local).AddTicks(8106), "Nesciunt possimus consequatur itaque reiciendis fuga necessitatibus. Eum delectus reiciendis temporibus. Quod nesciunt qui corrupti id architecto hic ratione pariatur quasi. Vel aut et natus est quis. Hic sed nihil occaecati cupiditate dolor. Sed qui et eveniet repellendus." },
                    { 512, 23, 145, 568675, new DateTime(2020, 11, 18, 11, 40, 20, 243, DateTimeKind.Local).AddTicks(5455), "Consequatur architecto sint. Impedit et nihil. Odio necessitatibus sint quo et. Ut qui possimus hic provident repellendus. Officia qui eos. Sit voluptatem voluptatem velit ut reprehenderit." },
                    { 257, 42, 107, 618809, new DateTime(2021, 1, 6, 14, 22, 59, 565, DateTimeKind.Local).AddTicks(9065), "Ut qui non voluptatem accusantium dolor." },
                    { 269, 26, 106, 714775, new DateTime(2020, 5, 4, 0, 32, 54, 844, DateTimeKind.Local).AddTicks(7035), "Rem ea corporis debitis saepe enim asperiores et itaque. Deleniti labore ut qui mollitia dolores aut velit. Sed soluta laboriosam. Inventore et sequi eius illo laudantium et qui." },
                    { 276, 26, 61, 744011, new DateTime(2020, 10, 10, 19, 3, 33, 589, DateTimeKind.Local).AddTicks(6570), "Amet ipsum sequi provident laborum a et ea. A et enim quia necessitatibus facilis et quis alias ut. Perferendis ipsum veniam. Soluta magni eum mollitia et ab explicabo iusto consequatur. Ut et quia. Officiis neque ipsam aut tempora aliquam voluptas ipsum id." },
                    { 467, 46, 85, 894750, new DateTime(2020, 8, 25, 13, 24, 50, 329, DateTimeKind.Local).AddTicks(6508), "nostrum" },
                    { 289, 26, 149, 774694, new DateTime(2020, 4, 14, 0, 25, 39, 106, DateTimeKind.Local).AddTicks(5414), "Deserunt impedit ab qui sint velit." },
                    { 429, 26, 133, 188090, new DateTime(2020, 3, 28, 22, 55, 58, 762, DateTimeKind.Local).AddTicks(3540), "Magni facere commodi recusandae ipsa explicabo qui debitis quia.\nExcepturi ea ad deserunt sed.\nIpsum deserunt voluptatem quam sunt sint quia.\nEos veniam expedita.\nQuia incidunt aut voluptatem dolore sed et ut." },
                    { 439, 26, 117, 759014, new DateTime(2021, 2, 15, 10, 29, 25, 443, DateTimeKind.Local).AddTicks(2211), "Pariatur exercitationem fugit.\nAspernatur voluptatum ut velit quia consectetur quis.\nOmnis dicta eveniet voluptatem similique nobis.\nVoluptas suscipit sit qui ut ut nemo.\nQuidem facere minima quaerat dolorem voluptatem officiis autem eos voluptatum." },
                    { 144, 26, 76, 470241, new DateTime(2021, 1, 8, 0, 16, 13, 723, DateTimeKind.Local).AddTicks(2069), "Voluptatum atque sed nisi rem. Ipsum vero iusto dolores voluptatum nihil nam. Magnam ex est at officia et." },
                    { 53, 94, 30, 127493, new DateTime(2020, 12, 2, 12, 39, 41, 100, DateTimeKind.Local).AddTicks(4711), "Perspiciatis enim neque.\nQuaerat necessitatibus vel molestias vitae est voluptas repudiandae commodi rerum.\nCupiditate dolorum unde corporis minus eum voluptatem quasi.\nVel consequatur aliquid." },
                    { 451, 23, 46, 503565, new DateTime(2020, 4, 28, 16, 38, 44, 391, DateTimeKind.Local).AddTicks(396), "Et tenetur eveniet. Ipsum ut animi provident veniam nisi voluptatum officiis quia. Reiciendis assumenda quas et at velit praesentium quia sed soluta." },
                    { 310, 23, 115, 624789, new DateTime(2020, 4, 3, 6, 26, 26, 452, DateTimeKind.Local).AddTicks(5078), "Sequi vitae architecto. Nemo quaerat consequuntur. Tenetur eos esse commodi quaerat. Impedit inventore est laborum explicabo expedita. Architecto cum corrupti consectetur consequatur eum eum harum." },
                    { 228, 52, 97, 796860, new DateTime(2020, 12, 2, 20, 58, 13, 443, DateTimeKind.Local).AddTicks(7404), "Magnam neque debitis." },
                    { 250, 52, 31, 524224, new DateTime(2020, 11, 28, 15, 19, 6, 282, DateTimeKind.Local).AddTicks(3079), "nostrum" },
                    { 372, 52, 100, 946980, new DateTime(2020, 5, 11, 18, 39, 11, 659, DateTimeKind.Local).AddTicks(2768), "Et earum aut asperiores consequuntur." },
                    { 479, 52, 69, 718540, new DateTime(2020, 8, 9, 17, 10, 24, 428, DateTimeKind.Local).AddTicks(794), "Consequatur sequi voluptatibus perferendis ut.\nVoluptas placeat eos voluptas.\nDolorum qui totam autem et qui voluptates voluptatum non modi.\nAut dolor dolorum laudantium quibusdam doloribus.\nCorporis deleniti ut iure qui." },
                    { 361, 89, 7, 255551, new DateTime(2020, 9, 14, 17, 36, 45, 521, DateTimeKind.Local).AddTicks(2070), "sed" },
                    { 565, 52, 125, 509066, new DateTime(2020, 7, 6, 6, 22, 20, 761, DateTimeKind.Local).AddTicks(5800), "Rerum commodi esse amet iusto." },
                    { 365, 23, 63, 569186, new DateTime(2020, 10, 3, 8, 35, 20, 345, DateTimeKind.Local).AddTicks(3162), "Ipsa occaecati dignissimos." },
                    { 595, 52, 19, 465416, new DateTime(2021, 3, 11, 0, 1, 52, 84, DateTimeKind.Local).AddTicks(2523), "Natus ea veritatis aliquam.\nEst similique dolor ut.\nMolestiae aut eligendi aliquid deserunt quasi quisquam.\nEst est officia magni magnam aut.\nDistinctio veritatis exercitationem et nisi." },
                    { 114, 18, 25, 773680, new DateTime(2020, 9, 28, 17, 53, 30, 830, DateTimeKind.Local).AddTicks(5960), "Perferendis nemo aut molestiae explicabo id odio.\nQui molestiae necessitatibus quia enim.\nDolorem et et quisquam officiis dolor dignissimos laborum eius magnam." },
                    { 185, 18, 112, 652646, new DateTime(2021, 1, 12, 0, 55, 15, 359, DateTimeKind.Local).AddTicks(8620), "modi" },
                    { 411, 18, 138, 829647, new DateTime(2020, 7, 22, 0, 42, 34, 403, DateTimeKind.Local).AddTicks(5171), "Minima et autem.\nRem et eum voluptas quod ut culpa harum.\nItaque dolorem magni tenetur consequatur voluptas error quod velit." },
                    { 146, 89, 69, 642838, new DateTime(2021, 1, 26, 6, 0, 9, 494, DateTimeKind.Local).AddTicks(8474), "Possimus rerum veniam magnam non suscipit.\nUnde sequi ut quia.\nOfficiis ducimus magnam et exercitationem temporibus.\nNesciunt voluptatum sit asperiores ea quia suscipit unde eum." },
                    { 47, 23, 57, 442068, new DateTime(2020, 12, 28, 1, 52, 2, 683, DateTimeKind.Local).AddTicks(1281), "Et consequatur quisquam rerum voluptatibus.\nCulpa doloribus id aut nemo iure impedit aut.\nDeleniti dolor ab non minima aperiam cupiditate maiores repellendus.\nDicta aliquid fugit inventore id et aliquam dolor.\nQuibusdam in maiores mollitia aut pariatur aut." },
                    { 183, 23, 53, 619689, new DateTime(2020, 10, 21, 20, 26, 28, 159, DateTimeKind.Local).AddTicks(3626), "Alias et qui repellat et nam aut sit quis.\nNam facere non libero assumenda voluptates eos.\nQuis at eaque perferendis ut ea laboriosam.\nQuam iste voluptate.\nImpedit aliquam dignissimos magni quos numquam ea reprehenderit et.\nAsperiores hic dolor culpa pariatur." },
                    { 97, 18, 132, 234525, new DateTime(2021, 1, 13, 12, 15, 6, 346, DateTimeKind.Local).AddTicks(3809), "Sed nulla alias possimus. Accusamus nesciunt sapiente. Inventore earum animi aspernatur laudantium vel beatae." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 293, 97, 9, 73589, new DateTime(2020, 9, 19, 19, 56, 6, 842, DateTimeKind.Local).AddTicks(321), "Error assumenda repellat dolores est ipsa expedita tempora dolores non. Rerum qui corporis atque et nemo consequuntur sequi autem quam. Illo repellat est qui ut autem ipsum quam molestiae. Pariatur voluptas ut repellendus itaque et distinctio suscipit libero voluptas. Perferendis ipsa maiores consectetur numquam numquam. Odit amet vel consequatur atque facere porro alias atque." },
                    { 349, 94, 63, 939323, new DateTime(2020, 10, 20, 2, 12, 27, 228, DateTimeKind.Local).AddTicks(5545), "rerum" },
                    { 401, 94, 146, 549501, new DateTime(2020, 9, 7, 21, 38, 20, 413, DateTimeKind.Local).AddTicks(3550), "voluptatem" },
                    { 274, 75, 19, 695747, new DateTime(2020, 9, 22, 17, 15, 54, 161, DateTimeKind.Local).AddTicks(9443), "Necessitatibus et facilis et consequatur nesciunt et placeat quo non.\nSed et aperiam.\nIste harum officia et corporis.\nReiciendis doloribus sequi et aut voluptatibus.\nAliquam quos commodi.\nTenetur illum sunt odio voluptatum nostrum sit ut in nam." },
                    { 304, 75, 85, 577633, new DateTime(2020, 8, 12, 21, 17, 9, 840, DateTimeKind.Local).AddTicks(1465), "Quia dolor quo molestias dignissimos tempore rem sed officia rerum." },
                    { 334, 75, 24, 262851, new DateTime(2020, 12, 7, 10, 2, 25, 937, DateTimeKind.Local).AddTicks(4111), "Exercitationem iusto eius debitis. Consequatur inventore voluptatem. Aut nisi praesentium rerum enim corporis amet sit enim. Est perferendis aut quia incidunt occaecati explicabo ratione ex consequatur." },
                    { 48, 46, 122, 783950, new DateTime(2021, 2, 21, 11, 1, 1, 551, DateTimeKind.Local).AddTicks(5958), "Autem natus deleniti atque ipsum autem enim sunt sit. Non saepe eum totam non accusamus beatae illo non neque. Sed dolores culpa. Cum rem et." },
                    { 182, 85, 24, 725612, new DateTime(2021, 2, 7, 14, 47, 50, 616, DateTimeKind.Local).AddTicks(4036), "officiis" },
                    { 303, 85, 141, 564246, new DateTime(2020, 5, 20, 12, 13, 3, 827, DateTimeKind.Local).AddTicks(6063), "Ullam maiores ducimus animi amet eos sed sit. Esse dicta occaecati dolor odit error. Placeat omnis odit labore sed quo aut quo accusantium. Sunt praesentium quia asperiores et voluptatem error. Eos quia ut ut recusandae repellat enim." },
                    { 268, 75, 28, 935212, new DateTime(2021, 1, 5, 12, 48, 40, 750, DateTimeKind.Local).AddTicks(7986), "cumque" },
                    { 171, 73, 100, 878346, new DateTime(2020, 6, 11, 18, 41, 43, 482, DateTimeKind.Local).AddTicks(4403), "Doloribus expedita nihil illo rem eius non qui dolorum." },
                    { 427, 85, 89, 78320, new DateTime(2020, 4, 6, 4, 46, 16, 646, DateTimeKind.Local).AddTicks(548), "Quia ut voluptatibus illum at." },
                    { 433, 85, 7, 402447, new DateTime(2020, 5, 1, 21, 38, 12, 124, DateTimeKind.Local).AddTicks(3815), "ducimus" },
                    { 491, 85, 57, 667639, new DateTime(2020, 4, 28, 12, 3, 3, 498, DateTimeKind.Local).AddTicks(2251), "Velit fugiat voluptas ut optio repellat esse officiis quod.\nEt reiciendis nihil asperiores reprehenderit repudiandae quisquam natus non impedit.\nError voluptatem laborum consectetur explicabo cumque quisquam et." },
                    { 40, 97, 116, 587913, new DateTime(2020, 8, 19, 16, 54, 31, 958, DateTimeKind.Local).AddTicks(7844), "laudantium" },
                    { 165, 97, 42, 882306, new DateTime(2020, 9, 19, 19, 32, 25, 938, DateTimeKind.Local).AddTicks(5575), "Beatae error vel voluptatem consequatur rem incidunt aut velit. Sunt dolorem perspiciatis ab. Eius non eos ipsum earum velit rerum. Quibusdam soluta sit. Consequatur quibusdam eum nostrum facilis molestiae. Placeat beatae ullam qui." },
                    { 167, 97, 15, 651334, new DateTime(2020, 11, 19, 10, 16, 5, 613, DateTimeKind.Local).AddTicks(2214), "Quidem dolor eum qui dolores iste.\nTotam aperiam explicabo.\nIpsam consequatur tenetur dignissimos eveniet ipsam corporis rem et.\nEt quis vitae et rerum quae ab.\nBeatae sit distinctio aut." },
                    { 351, 85, 44, 256240, new DateTime(2020, 9, 12, 15, 19, 0, 627, DateTimeKind.Local).AddTicks(7124), "Consequatur illo natus. Ducimus voluptates odit fugiat dolores distinctio iure. Et nobis fugit reprehenderit et iure atque temporibus ad. Maxime minus sapiente vero ipsa quidem unde nemo. Enim quis qui perspiciatis. Quidem soluta aut doloremque quae est sed." },
                    { 371, 94, 147, 419563, new DateTime(2021, 2, 13, 7, 38, 50, 866, DateTimeKind.Local).AddTicks(640), "Veritatis quia cumque sit velit non occaecati illum omnis." },
                    { 46, 75, 81, 40166, new DateTime(2021, 1, 27, 19, 27, 42, 311, DateTimeKind.Local).AddTicks(1715), "tempore" },
                    { 322, 96, 149, 428921, new DateTime(2021, 3, 21, 12, 31, 34, 586, DateTimeKind.Local).AddTicks(1375), "Dolores id iusto tenetur voluptates quidem voluptatem impedit culpa.\nEx blanditiis ut est mollitia et et illo debitis cupiditate.\nOfficiis at non est et.\nEnim quia recusandae et sed natus sunt id reiciendis.\nOmnis excepturi asperiores.\nError laborum doloribus et aperiam dolorem velit." },
                    { 320, 46, 36, 175483, new DateTime(2020, 9, 21, 8, 48, 45, 661, DateTimeKind.Local).AddTicks(4465), "laborum" },
                    { 510, 94, 132, 424408, new DateTime(2020, 11, 1, 17, 22, 50, 877, DateTimeKind.Local).AddTicks(2928), "Ea ullam voluptatem." },
                    { 1, 12, 14, 956666, new DateTime(2020, 9, 11, 15, 56, 31, 862, DateTimeKind.Local).AddTicks(7966), "Praesentium saepe excepturi vel ullam voluptate. Voluptates et mollitia voluptate nihil. Quos sint sunt sit adipisci est illo ex omnis consectetur. Omnis excepturi hic itaque. Dolorem esse accusantium." },
                    { 44, 12, 60, 264099, new DateTime(2021, 3, 14, 14, 54, 11, 267, DateTimeKind.Local).AddTicks(5024), "Rerum aut ut ut ipsam quae exercitationem rerum excepturi id.\nMolestias tempora vitae in vel voluptatem error amet quasi consectetur.\nAut omnis nulla sunt alias numquam voluptatem eius.\nEius ex amet quam ipsa fugit nam.\nSunt et rem consequatur consequuntur." },
                    { 76, 12, 117, 879583, new DateTime(2020, 6, 4, 14, 57, 46, 478, DateTimeKind.Local).AddTicks(9055), "Autem sapiente molestiae laborum cupiditate ut. Inventore repellendus tempora hic quis earum inventore animi. Ad rerum incidunt. Nobis possimus corporis voluptas et iusto consequatur quas beatae voluptatem." },
                    { 93, 12, 14, 799952, new DateTime(2020, 7, 24, 13, 51, 59, 551, DateTimeKind.Local).AddTicks(1205), "Quod eveniet et doloribus veniam. Ducimus aut voluptate qui natus sunt. Dolorem sed est sed voluptatem eos quo at consequatur. Tenetur mollitia ad. Dolores doloribus a fugiat veritatis inventore." },
                    { 263, 46, 81, 207625, new DateTime(2020, 10, 11, 9, 50, 58, 172, DateTimeKind.Local).AddTicks(9301), "Quis voluptatum cum quod omnis." },
                    { 307, 12, 57, 313289, new DateTime(2021, 2, 1, 16, 32, 26, 192, DateTimeKind.Local).AddTicks(5669), "Similique praesentium sit qui.\nVitae omnis voluptatibus voluptas repellendus rerum vel." },
                    { 454, 12, 12, 149218, new DateTime(2020, 4, 6, 14, 3, 46, 178, DateTimeKind.Local).AddTicks(5437), "exercitationem" },
                    { 490, 12, 144, 515343, new DateTime(2020, 4, 2, 2, 43, 11, 665, DateTimeKind.Local).AddTicks(9789), "Quia omnis voluptas optio iusto consequatur fuga veniam.\nVoluptatem magni et aliquam commodi dicta ut illo.\nItaque beatae architecto recusandae nam fuga." },
                    { 544, 12, 16, 621874, new DateTime(2020, 6, 17, 18, 20, 39, 368, DateTimeKind.Local).AddTicks(5989), "Consequatur molestiae hic inventore id sit qui amet.\nDolor impedit adipisci fugit voluptas commodi nulla et et perferendis.\nMolestiae voluptates qui aut in ut voluptas.\nDebitis delectus vero consequatur occaecati tempora.\nMolestias dignissimos expedita.\nVoluptatem et exercitationem tenetur dolores quia error et." },
                    { 117, 13, 29, 941575, new DateTime(2020, 5, 16, 18, 7, 22, 558, DateTimeKind.Local).AddTicks(4401), "Est eos dolores blanditiis eius dolore voluptatibus adipisci sint.\nVero temporibus necessitatibus voluptatum minima.\nAlias distinctio quibusdam et." },
                    { 132, 13, 97, 735291, new DateTime(2020, 8, 19, 6, 49, 55, 26, DateTimeKind.Local).AddTicks(7497), "Qui ut quasi mollitia nihil facilis voluptatem.\nPossimus mollitia rerum tempora dolores nobis aut consequatur dolores fuga.\nRatione omnis consectetur sed consectetur sit dolore iste.\nAut possimus quia molestiae laborum." },
                    { 79, 96, 27, 340951, new DateTime(2021, 3, 19, 8, 20, 14, 798, DateTimeKind.Local).AddTicks(4830), "Explicabo nihil suscipit suscipit qui temporibus accusantium beatae quo ut. Dolores cumque doloribus aut consequatur. Dolore saepe alias quibusdam ut. Ratione occaecati numquam repellat rerum quisquam nostrum minima. Quis debitis beatae dolorem vero." },
                    { 294, 46, 60, 791951, new DateTime(2021, 3, 23, 4, 22, 51, 834, DateTimeKind.Local).AddTicks(1283), "repellendus" },
                    { 498, 55, 131, 53924, new DateTime(2020, 6, 24, 7, 7, 20, 909, DateTimeKind.Local).AddTicks(5105), "Assumenda sit aut eaque molestiae et veritatis modi.\nTotam reiciendis quas quia nihil nisi est est.\nQui non distinctio est et non.\nEaque ut numquam.\nRepellat deserunt dignissimos voluptas.\nOptio nobis recusandae iusto at aperiam est sit." },
                    { 139, 55, 26, 146459, new DateTime(2020, 12, 11, 22, 44, 31, 111, DateTimeKind.Local).AddTicks(2200), "Debitis non ut magnam labore." },
                    { 137, 111, 126, 297126, new DateTime(2021, 3, 12, 9, 10, 0, 93, DateTimeKind.Local).AddTicks(1013), "Nemo placeat id molestiae quaerat dolorem ut animi dicta." },
                    { 517, 43, 30, 340021, new DateTime(2020, 6, 20, 10, 57, 14, 800, DateTimeKind.Local).AddTicks(6747), "Explicabo ut dolores ipsum ut molestiae blanditiis.\nAdipisci sed nemo.\nNecessitatibus delectus dolor expedita ut quos praesentium ab.\nFuga incidunt earum molestiae dignissimos neque dolor necessitatibus.\nAut sed sequi laboriosam maiores et libero voluptatem quo nostrum." },
                    { 170, 32, 21, 200494, new DateTime(2020, 12, 15, 0, 21, 47, 34, DateTimeKind.Local).AddTicks(1279), "Excepturi officiis temporibus placeat nam impedit quisquam quod." },
                    { 30, 32, 115, 502557, new DateTime(2020, 11, 30, 1, 51, 36, 66, DateTimeKind.Local).AddTicks(2519), "Ducimus et sit consequatur voluptates. Et omnis ab architecto ut maiores officia sunt qui impedit. Ut fugiat placeat quam ut quis consectetur sit quis. Esse rerum et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 56, 66, 124, 410103, new DateTime(2020, 12, 21, 23, 36, 42, 884, DateTimeKind.Local).AddTicks(1774), "vel" },
                    { 102, 66, 108, 712286, new DateTime(2021, 1, 8, 15, 1, 44, 622, DateTimeKind.Local).AddTicks(6312), "Et voluptas a nisi.\nSapiente molestias nihil maiores voluptatibus." },
                    { 120, 66, 146, 689416, new DateTime(2020, 5, 28, 22, 8, 50, 4, DateTimeKind.Local).AddTicks(8337), "Maxime velit aut corrupti tempore odio.\nExercitationem sed inventore blanditiis numquam totam vel laudantium illo.\nImpedit quis voluptatem laudantium hic.\nEt ullam porro voluptas et voluptatem quaerat ea eos.\nEaque explicabo possimus.\nCum adipisci ducimus." },
                    { 502, 43, 149, 712864, new DateTime(2020, 4, 22, 11, 41, 14, 367, DateTimeKind.Local).AddTicks(1005), "Vitae ab ea blanditiis odio quaerat ut facere.\nSequi in maiores omnis et veniam excepturi enim aut.\nEt dicta doloremque architecto laboriosam et quo incidunt.\nRerum quia ex est eius est rerum.\nCupiditate placeat culpa." },
                    { 232, 68, 21, 714553, new DateTime(2020, 7, 13, 8, 45, 34, 912, DateTimeKind.Local).AddTicks(5717), "Illum explicabo deserunt asperiores aut. Esse earum ipsam incidunt fugit ea. Ab quis aut fugit optio id dolores sapiente. Qui reprehenderit facere similique. Quod inventore et quaerat sed enim sed eos. Architecto dolor rerum laboriosam aspernatur exercitationem aut magnam." },
                    { 249, 68, 18, 936422, new DateTime(2020, 6, 20, 7, 35, 23, 203, DateTimeKind.Local).AddTicks(7467), "Voluptas nihil sapiente asperiores. Voluptas accusamus recusandae esse id veniam blanditiis quis aspernatur et. Aut dolores aut et impedit enim et sint perferendis. Et sit velit. Consequatur illo unde temporibus." },
                    { 298, 68, 141, 757155, new DateTime(2020, 5, 2, 8, 38, 0, 242, DateTimeKind.Local).AddTicks(6369), "Quae qui iste quia quis est omnis ut. Hic natus magnam harum consectetur distinctio nemo natus voluptatem. A vel sint totam neque recusandae veritatis dolorum ducimus occaecati. Sapiente perferendis maxime reprehenderit." },
                    { 424, 68, 45, 480796, new DateTime(2020, 7, 2, 13, 24, 16, 823, DateTimeKind.Local).AddTicks(2668), "In voluptas quia non.\nEum nisi nihil assumenda dolorum magni aut consequatur voluptas.\nPerferendis aut quia quibusdam libero hic ipsum cumque.\nVoluptas hic illo adipisci autem rem architecto.\nNostrum molestias expedita odit aut sint perspiciatis ut.\nDolores quibusdam aperiam saepe molestias." },
                    { 463, 68, 25, 834433, new DateTime(2020, 10, 2, 20, 53, 39, 665, DateTimeKind.Local).AddTicks(2874), "Accusamus sapiente voluptas qui ad consequuntur fugit et. Officiis laborum ut sit sit corrupti voluptas. Ut repellat eum quas est et vero non quod optio. Facere non eum cumque in molestias id ut voluptatum quia. Sapiente voluptates excepturi et. Ducimus ea est fugiat optio magnam et." },
                    { 91, 28, 1, 892778, new DateTime(2020, 5, 2, 23, 41, 56, 235, DateTimeKind.Local).AddTicks(4133), "nihil" },
                    { 258, 28, 130, 254916, new DateTime(2020, 5, 17, 0, 54, 15, 547, DateTimeKind.Local).AddTicks(1990), "Qui rerum itaque aut porro quo sed non a. Rerum quia quos. Et consequuntur vel. Ratione minus architecto nihil corrupti facilis. Qui perferendis velit et voluptatem." },
                    { 580, 21, 2, 40400, new DateTime(2020, 6, 8, 8, 10, 3, 371, DateTimeKind.Local).AddTicks(6759), "Odio id maiores dolorem." },
                    { 267, 28, 32, 258794, new DateTime(2020, 7, 9, 12, 30, 24, 44, DateTimeKind.Local).AddTicks(4092), "fugit" },
                    { 436, 43, 129, 537314, new DateTime(2020, 4, 6, 5, 23, 20, 718, DateTimeKind.Local).AddTicks(5302), "Quo ad hic qui autem nobis aut. Cupiditate autem qui illum occaecati aliquid quas voluptas iure. Iure voluptas corrupti veniam ipsum fugit voluptatem voluptatem rerum. Est nihil sint fugiat voluptas libero dolorem." },
                    { 206, 43, 9, 679751, new DateTime(2020, 9, 24, 19, 20, 11, 549, DateTimeKind.Local).AddTicks(5609), "Perspiciatis est sed ea sapiente." },
                    { 222, 11, 27, 978645, new DateTime(2020, 12, 12, 3, 22, 55, 613, DateTimeKind.Local).AddTicks(3941), "temporibus" },
                    { 256, 11, 77, 604684, new DateTime(2020, 5, 5, 6, 55, 42, 290, DateTimeKind.Local).AddTicks(2786), "Natus aut sint dolorum laboriosam minima." },
                    { 404, 11, 112, 901593, new DateTime(2020, 8, 13, 3, 51, 23, 520, DateTimeKind.Local).AddTicks(4012), "Modi sapiente ut rerum sint sed illo occaecati." },
                    { 421, 11, 135, 222752, new DateTime(2020, 11, 2, 18, 9, 7, 696, DateTimeKind.Local).AddTicks(4300), "Vel consectetur sed aliquam aut fugit corporis.\nDucimus totam laboriosam velit cumque consectetur numquam.\nNam dolorum quas dolores sit dicta.\nNobis et magnam aut.\nEos non eveniet soluta." },
                    { 435, 11, 126, 636488, new DateTime(2020, 4, 9, 22, 57, 1, 378, DateTimeKind.Local).AddTicks(3801), "Dolorem ducimus ut fugit eaque magni aut aperiam placeat. Maxime magnam et veritatis eligendi. Et ipsa nihil aut illo. Omnis similique quia sint facere eum numquam incidunt consequatur. Corrupti aut ut nemo. Ipsam omnis sed saepe aperiam facilis quia." },
                    { 25, 88, 36, 114738, new DateTime(2020, 11, 4, 7, 19, 46, 455, DateTimeKind.Local).AddTicks(4479), "Sint quo corporis." },
                    { 315, 43, 13, 725151, new DateTime(2020, 5, 13, 0, 14, 25, 422, DateTimeKind.Local).AddTicks(8024), "Maxime sit quos rerum fugit beatae exercitationem aperiam." },
                    { 586, 32, 21, 491595, new DateTime(2020, 7, 29, 12, 14, 23, 664, DateTimeKind.Local).AddTicks(6216), "Maiores dicta aut accusantium dicta eos." },
                    { 462, 64, 57, 578499, new DateTime(2021, 1, 14, 18, 16, 5, 893, DateTimeKind.Local).AddTicks(8163), "Ut temporibus neque." },
                    { 545, 64, 43, 404275, new DateTime(2021, 3, 23, 14, 46, 30, 62, DateTimeKind.Local).AddTicks(8348), "Qui aspernatur nulla quo expedita.\nEligendi sapiente nemo earum molestiae.\nTempore rerum voluptatem at in qui ut facere ut et.\nDucimus temporibus quo odit natus accusamus omnis eos nostrum dolor.\nEt et nam est." },
                    { 582, 32, 134, 793634, new DateTime(2020, 11, 15, 20, 49, 37, 129, DateTimeKind.Local).AddTicks(1847), "Est iure qui.\nAdipisci est sapiente accusamus dolorem necessitatibus sint.\nQui doloremque ut provident qui totam exercitationem odit nesciunt sit.\nMolestias alias repudiandae porro.\nDignissimos qui voluptatum suscipit iusto quisquam." },
                    { 572, 32, 112, 909751, new DateTime(2020, 11, 1, 18, 34, 33, 728, DateTimeKind.Local).AddTicks(9625), "maiores" },
                    { 82, 43, 107, 733163, new DateTime(2020, 11, 18, 0, 58, 7, 670, DateTimeKind.Local).AddTicks(1395), "qui" },
                    { 122, 43, 10, 867195, new DateTime(2020, 9, 9, 23, 25, 26, 65, DateTimeKind.Local).AddTicks(3364), "Voluptates reiciendis perspiciatis voluptatem illo. Repudiandae veniam veritatis ullam consectetur nemo. Labore est vel expedita quidem ad." },
                    { 173, 64, 144, 197708, new DateTime(2021, 1, 30, 18, 56, 14, 881, DateTimeKind.Local).AddTicks(6622), "Ullam non non voluptas voluptatem a et sunt. Velit accusantium temporibus eum. Minima enim perspiciatis aspernatur ipsum eligendi aliquam consequatur. Sit quae excepturi exercitationem qui debitis ut illum qui. Commodi ea quos cupiditate." },
                    { 323, 28, 33, 885834, new DateTime(2021, 2, 17, 0, 21, 19, 975, DateTimeKind.Local).AddTicks(8552), "Quaerat aut modi nemo nostrum officiis. Et facilis ea illum saepe quia hic et a ipsam. Rerum voluptatibus assumenda quaerat et natus et. Aliquid corporis omnis beatae et eligendi tempora libero voluptatum." },
                    { 472, 21, 6, 28390, new DateTime(2020, 8, 3, 2, 35, 17, 697, DateTimeKind.Local).AddTicks(4763), "Officiis non dolorum.\nEt laudantium autem beatae mollitia iure.\nNumquam optio saepe illo sed ex a." },
                    { 386, 28, 82, 904295, new DateTime(2020, 5, 8, 10, 16, 7, 43, DateTimeKind.Local).AddTicks(1652), "Corporis vero laboriosam sint architecto aut voluptatibus dolorem quia." },
                    { 543, 102, 30, 943451, new DateTime(2020, 3, 29, 22, 1, 12, 67, DateTimeKind.Local).AddTicks(2442), "Numquam corporis iusto. Consequatur dolor fugiat nesciunt similique repellat laboriosam ullam ut sint. Exercitationem quia ea assumenda et qui nesciunt cumque esse voluptatum. Officiis illo qui autem aut perferendis itaque reprehenderit quo. Minima optio deleniti eos repudiandae. Possimus ex sunt." },
                    { 22, 21, 28, 974073, new DateTime(2020, 6, 11, 4, 10, 27, 928, DateTimeKind.Local).AddTicks(4852), "Vitae eos pariatur laudantium sunt sunt.\nVeniam nulla velit assumenda." },
                    { 166, 29, 29, 440603, new DateTime(2020, 6, 23, 10, 24, 29, 346, DateTimeKind.Local).AddTicks(425), "delectus" },
                    { 302, 29, 31, 535024, new DateTime(2020, 6, 25, 12, 26, 38, 390, DateTimeKind.Local).AddTicks(9538), "Sit quibusdam commodi enim. Sed magnam aut labore placeat natus nam ad vero. Est et sed quod magnam qui aspernatur ad sit neque. Quo quas quia dolores. Accusantium hic ipsum voluptatem repudiandae ipsum incidunt." },
                    { 464, 61, 65, 59660, new DateTime(2020, 3, 29, 15, 51, 16, 73, DateTimeKind.Local).AddTicks(8564), "suscipit" },
                    { 339, 29, 92, 505522, new DateTime(2020, 7, 4, 0, 54, 36, 514, DateTimeKind.Local).AddTicks(1869), "Minus et quo laboriosam." },
                    { 520, 102, 138, 95378, new DateTime(2021, 1, 16, 11, 7, 44, 840, DateTimeKind.Local).AddTicks(7899), "Dolor dolorem nostrum vel et aperiam. Modi quia dicta dolor exercitationem eum inventore illo perspiciatis. Sint incidunt fugit ut rerum voluptatem atque. Vitae sit hic eos. Explicabo consequuntur est sed ut eveniet voluptatem praesentium. Quidem placeat accusantium dolorum." },
                    { 428, 29, 93, 373519, new DateTime(2021, 2, 3, 9, 16, 36, 892, DateTimeKind.Local).AddTicks(9933), "natus" },
                    { 133, 40, 40, 107513, new DateTime(2021, 2, 9, 17, 10, 33, 704, DateTimeKind.Local).AddTicks(1727), "Maxime doloribus corporis." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 177, 40, 126, 110566, new DateTime(2021, 2, 6, 11, 38, 4, 496, DateTimeKind.Local).AddTicks(7060), "dolorem" },
                    { 189, 40, 44, 835751, new DateTime(2020, 10, 24, 13, 6, 2, 544, DateTimeKind.Local).AddTicks(7938), "Molestiae est asperiores nulla laborum qui ut quia ad. Qui est perferendis corporis et sit quia aperiam. Inventore eum distinctio quae voluptas in similique." },
                    { 335, 40, 44, 125520, new DateTime(2020, 5, 15, 1, 45, 18, 223, DateTimeKind.Local).AddTicks(8076), "Esse sequi ut itaque odio praesentium enim ut." },
                    { 89, 61, 42, 88202, new DateTime(2020, 9, 8, 19, 30, 45, 326, DateTimeKind.Local).AddTicks(8569), "Blanditiis ipsa quae vitae sunt blanditiis nobis." },
                    { 255, 90, 62, 846604, new DateTime(2020, 8, 13, 9, 1, 19, 956, DateTimeKind.Local).AddTicks(6856), "at" },
                    { 445, 29, 52, 710781, new DateTime(2020, 8, 12, 1, 20, 35, 782, DateTimeKind.Local).AddTicks(9053), "Omnis dolor molestiae.\nPariatur eos dolores amet.\nVoluptatem a et earum et et vel.\nPraesentium aut est veniam incidunt amet eos voluptate doloremque et.\nAmet quo ut ad eum dolorum.\nOdit tenetur consequatur dicta at eum blanditiis quis amet." },
                    { 470, 102, 50, 768348, new DateTime(2021, 1, 3, 16, 49, 13, 100, DateTimeKind.Local).AddTicks(4292), "Aspernatur voluptatibus doloremque et.\nEum voluptatem occaecati ut ducimus dolorum.\nDeserunt saepe provident assumenda nihil." },
                    { 313, 102, 48, 41985, new DateTime(2020, 4, 7, 14, 44, 33, 477, DateTimeKind.Local).AddTicks(8589), "suscipit" },
                    { 300, 102, 18, 759474, new DateTime(2020, 6, 1, 11, 2, 7, 924, DateTimeKind.Local).AddTicks(2346), "Ullam provident voluptas ea.\nOmnis exercitationem aut ipsam.\nMolestias aliquam soluta veritatis facilis modi corporis nihil." },
                    { 533, 28, 4, 42436, new DateTime(2020, 11, 4, 8, 50, 14, 12, DateTimeKind.Local).AddTicks(173), "Ipsam consectetur qui ab reprehenderit." },
                    { 578, 28, 11, 60849, new DateTime(2020, 9, 22, 13, 52, 54, 308, DateTimeKind.Local).AddTicks(2773), "Omnis quam exercitationem corrupti non voluptatibus consequatur consequuntur aperiam velit. Sint dolorem quia blanditiis. Odit esse iste ut. Repudiandae nihil dolor voluptate rerum non ut. Molestiae molestiae reiciendis consequuntur consequuntur accusantium dignissimos quo. Itaque esse alias ut dolores." },
                    { 360, 21, 95, 972189, new DateTime(2020, 7, 20, 23, 10, 12, 333, DateTimeKind.Local).AddTicks(7110), "Ducimus quae cum sit quibusdam doloremque voluptatem voluptatem doloremque." },
                    { 369, 38, 146, 223342, new DateTime(2021, 2, 20, 12, 44, 7, 864, DateTimeKind.Local).AddTicks(8921), "eum" },
                    { 395, 38, 89, 203347, new DateTime(2020, 5, 20, 17, 1, 16, 291, DateTimeKind.Local).AddTicks(9864), "Amet et quod tempora aut omnis.\nEsse iusto ea distinctio incidunt quasi eum aut aut.\nMolestiae nihil voluptate eius qui facere." },
                    { 400, 38, 141, 681992, new DateTime(2020, 8, 11, 12, 9, 14, 554, DateTimeKind.Local).AddTicks(2418), "Dicta quidem pariatur quia corporis tempore sit. Quasi est libero. Earum quo eius veritatis. Quidem autem qui. Illum sed corrupti quam vitae impedit temporibus et sequi corrupti." },
                    { 190, 21, 95, 142082, new DateTime(2021, 2, 16, 15, 2, 53, 580, DateTimeKind.Local).AddTicks(4), "beatae" },
                    { 175, 81, 39, 595687, new DateTime(2020, 4, 8, 23, 33, 51, 975, DateTimeKind.Local).AddTicks(7972), "eos" },
                    { 239, 81, 107, 908889, new DateTime(2020, 8, 11, 12, 31, 55, 843, DateTimeKind.Local).AddTicks(8650), "Quidem quas sequi aliquid harum." },
                    { 321, 81, 7, 494759, new DateTime(2020, 8, 15, 21, 59, 35, 934, DateTimeKind.Local).AddTicks(5729), "Fugit natus enim est autem rem molestias voluptas est.\nQui eius eos.\nEt repudiandae cumque expedita distinctio quaerat quam pariatur.\nQuo perspiciatis molestias quam et et ad consectetur delectus.\nCorrupti sunt aut." },
                    { 49, 102, 71, 493802, new DateTime(2020, 10, 12, 12, 26, 8, 763, DateTimeKind.Local).AddTicks(4815), "Et aliquam ipsam vitae aut ad nihil iste. Libero fugit totam. Corporis sunt quia quia eligendi. Vero ipsum et eveniet." },
                    { 61, 102, 2, 795187, new DateTime(2021, 3, 1, 13, 1, 39, 368, DateTimeKind.Local).AddTicks(9776), "Et numquam ab." },
                    { 70, 102, 76, 380110, new DateTime(2021, 3, 21, 0, 52, 57, 924, DateTimeKind.Local).AddTicks(9830), "Et enim sit quam temporibus.\nQuia totam sit aperiam quos ducimus.\nIpsa doloremque iste pariatur inventore quibusdam." },
                    { 92, 21, 46, 219790, new DateTime(2020, 4, 10, 0, 14, 6, 581, DateTimeKind.Local).AddTicks(4649), "Ratione molestias et saepe consequatur." },
                    { 118, 102, 66, 633653, new DateTime(2020, 7, 29, 15, 52, 55, 445, DateTimeKind.Local).AddTicks(1689), "rerum" },
                    { 130, 111, 75, 702231, new DateTime(2020, 5, 9, 19, 4, 51, 850, DateTimeKind.Local).AddTicks(8721), "Natus iusto quisquam molestiae ex dicta quis.\nVeritatis qui sit eum suscipit quia labore repellat voluptatem.\nTenetur amet explicabo debitis.\nPorro recusandae minus iure eos velit." },
                    { 157, 11, 12, 293143, new DateTime(2020, 6, 9, 1, 19, 13, 199, DateTimeKind.Local).AddTicks(1667), "Aut aut corporis soluta minima." },
                    { 163, 11, 58, 352317, new DateTime(2020, 5, 9, 1, 20, 27, 756, DateTimeKind.Local).AddTicks(5749), "unde" },
                    { 312, 88, 102, 143336, new DateTime(2020, 6, 12, 1, 57, 6, 389, DateTimeKind.Local).AddTicks(1441), "Corporis consequatur est non et ratione placeat. Veniam qui voluptas. Quia beatae ea qui pariatur itaque debitis maxime dolorum voluptatibus. Eius mollitia sequi incidunt occaecati quibusdam nobis. Quaerat accusamus sequi est libero. Nam ducimus labore harum ut est deleniti ex officiis." },
                    { 492, 16, 11, 236625, new DateTime(2020, 10, 12, 13, 17, 29, 96, DateTimeKind.Local).AddTicks(5036), "Esse consequuntur iure ut rerum officia adipisci aut dolorem.\nSapiente et qui animi eum qui ipsam distinctio aspernatur nulla.\nIncidunt quae animi exercitationem eligendi hic voluptas enim.\nAnimi sit minima est.\nDeserunt ipsum earum quasi odit consequatur ab." },
                    { 179, 58, 40, 871895, new DateTime(2020, 7, 5, 2, 12, 2, 846, DateTimeKind.Local).AddTicks(9943), "error" },
                    { 558, 16, 23, 396488, new DateTime(2021, 3, 16, 0, 37, 37, 264, DateTimeKind.Local).AddTicks(1623), "Exercitationem alias vel est facere. Voluptas earum alias nisi odit. Aliquid maxime enim ad alias. Deserunt temporibus aut blanditiis nihil inventore voluptatibus." },
                    { 138, 58, 48, 861669, new DateTime(2020, 5, 24, 13, 47, 32, 881, DateTimeKind.Local).AddTicks(4808), "Esse delectus laboriosam voluptatem velit repellendus sint quod. Rerum ut libero est officiis omnis quae placeat iste consequatur. Sed modi molestiae ut odit sit qui assumenda similique veniam. Et nulla suscipit dolor quo enim aspernatur ducimus cupiditate." },
                    { 54, 79, 27, 270162, new DateTime(2020, 4, 11, 20, 39, 56, 202, DateTimeKind.Local).AddTicks(3152), "Iusto ullam ducimus debitis cumque totam aut.\nConsectetur rerum adipisci impedit fuga in facilis dolore aliquid." },
                    { 151, 79, 119, 176645, new DateTime(2020, 4, 3, 0, 44, 47, 965, DateTimeKind.Local).AddTicks(9511), "quos" },
                    { 466, 16, 26, 801263, new DateTime(2020, 7, 11, 18, 40, 28, 797, DateTimeKind.Local).AddTicks(8384), "At id est aperiam rem.\nEt ipsa voluptate dolorem magni et ut quas iste voluptates.\nUt nisi mollitia eveniet quos sed mollitia provident est.\nVelit explicabo sed qui recusandae labore odio qui repudiandae." },
                    { 187, 79, 50, 283542, new DateTime(2020, 6, 22, 11, 42, 39, 278, DateTimeKind.Local).AddTicks(7128), "Velit placeat sequi.\nArchitecto consequatur ad amet velit.\nUt et repellendus adipisci quod.\nAssumenda nemo alias magni maiores.\nVoluptatem eos earum.\nConsectetur numquam ex." },
                    { 336, 79, 118, 663246, new DateTime(2020, 4, 12, 23, 8, 19, 922, DateTimeKind.Local).AddTicks(6205), "Et temporibus repellat voluptates provident eos sit voluptatem maiores ex." },
                    { 399, 79, 110, 194567, new DateTime(2020, 4, 14, 5, 26, 53, 38, DateTimeKind.Local).AddTicks(7105), "Aliquam qui ipsum perspiciatis." },
                    { 125, 58, 118, 470225, new DateTime(2020, 5, 19, 12, 56, 37, 811, DateTimeKind.Local).AddTicks(8057), "Necessitatibus voluptatem ea.\nCommodi esse sint optio aut ad voluptatem tenetur sed.\nAnimi soluta molestiae sed repudiandae commodi repellendus ducimus.\nLaborum qui vero officiis quos repellendus officia consectetur beatae atque.\nPlaceat tenetur magni perferendis aut est nam ut.\nAdipisci voluptatem molestias dicta optio aspernatur." },
                    { 314, 3, 26, 583522, new DateTime(2020, 6, 2, 14, 34, 47, 849, DateTimeKind.Local).AddTicks(5068), "Non voluptas sint incidunt exercitationem mollitia." },
                    { 354, 3, 86, 395311, new DateTime(2020, 11, 15, 5, 40, 37, 637, DateTimeKind.Local).AddTicks(6499), "explicabo" },
                    { 397, 3, 115, 897352, new DateTime(2020, 11, 28, 15, 47, 44, 867, DateTimeKind.Local).AddTicks(7886), "Quo eos maiores incidunt nihil corrupti rerum. Ad sed cumque. Alias aliquam aliquam qui quaerat vero eius praesentium." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 211, 79, 16, 160957, new DateTime(2020, 12, 20, 6, 54, 21, 849, DateTimeKind.Local).AddTicks(9170), "Doloremque consequuntur repudiandae enim rem.\nQuia ea in fuga exercitationem est praesentium.\nExplicabo sint blanditiis porro.\nCulpa culpa dignissimos repellat voluptas dolorem non soluta nemo." },
                    { 224, 16, 43, 610333, new DateTime(2020, 12, 1, 22, 26, 16, 976, DateTimeKind.Local).AddTicks(7602), "Velit voluptas in tenetur delectus corrupti.\nLabore accusamus nemo voluptas repellendus quo eum excepturi harum.\nAutem eligendi eum ex quis.\nFugit numquam id cum autem nulla.\nRerum veritatis rerum.\nEt vel aut earum aliquid placeat." },
                    { 196, 16, 40, 247832, new DateTime(2020, 9, 11, 11, 31, 27, 654, DateTimeKind.Local).AddTicks(2155), "Laudantium est ducimus iusto voluptas culpa.\nEos tempora provident quia.\nAd dolores in dolorem.\nAut est consequatur autem nisi facilis sed aliquam.\nNulla consequatur doloremque quia qui." },
                    { 75, 16, 121, 553702, new DateTime(2021, 1, 26, 18, 8, 25, 264, DateTimeKind.Local).AddTicks(2539), "Tenetur at cumque nisi eos dolores non neque suscipit.\nEarum dolorem id repellendus amet et nihil enim.\nQuia rerum iste vel et vel.\nRerum consequatur adipisci distinctio harum nesciunt animi temporibus dolores dolore.\nDolorem magnam adipisci provident porro.\nEligendi voluptatem beatae est ut similique dolorem." },
                    { 159, 111, 124, 826959, new DateTime(2020, 8, 14, 4, 47, 21, 322, DateTimeKind.Local).AddTicks(4770), "non" },
                    { 202, 111, 43, 841567, new DateTime(2020, 9, 3, 11, 0, 32, 511, DateTimeKind.Local).AddTicks(7846), "Omnis voluptatibus atque sit veniam magnam.\nVoluptatem maiores maxime quae dolorem.\nAt ut est ipsam rerum dolores qui quae.\nUllam numquam qui.\nVoluptatem optio velit quia nesciunt aut non labore sapiente." },
                    { 368, 58, 12, 729856, new DateTime(2020, 12, 18, 0, 35, 4, 343, DateTimeKind.Local).AddTicks(8545), "Et voluptatem sunt doloremque." },
                    { 207, 111, 67, 661765, new DateTime(2021, 1, 5, 8, 30, 53, 42, DateTimeKind.Local).AddTicks(2640), "Aut ratione placeat quisquam modi non deserunt vitae aut voluptas." },
                    { 566, 111, 117, 902996, new DateTime(2021, 2, 15, 20, 46, 14, 116, DateTimeKind.Local).AddTicks(4391), "Alias rerum esse." },
                    { 567, 111, 16, 788662, new DateTime(2021, 1, 2, 19, 22, 23, 164, DateTimeKind.Local).AddTicks(7757), "quo" },
                    { 343, 58, 90, 901697, new DateTime(2020, 4, 25, 9, 39, 55, 71, DateTimeKind.Local).AddTicks(8020), "Itaque cumque voluptatibus in sunt quas odio.\nMolestiae laborum voluptatem ducimus laborum quia distinctio.\nSed qui error nesciunt et." },
                    { 23, 100, 32, 542836, new DateTime(2020, 5, 5, 21, 45, 25, 400, DateTimeKind.Local).AddTicks(8916), "Modi corrupti velit optio id qui." },
                    { 55, 100, 82, 183768, new DateTime(2021, 2, 8, 4, 14, 5, 731, DateTimeKind.Local).AddTicks(989), "velit" },
                    { 106, 100, 7, 489744, new DateTime(2020, 10, 10, 9, 20, 18, 529, DateTimeKind.Local).AddTicks(8920), "doloribus" },
                    { 537, 100, 147, 338307, new DateTime(2020, 11, 19, 22, 43, 17, 658, DateTimeKind.Local).AddTicks(7213), "optio" },
                    { 262, 58, 92, 221879, new DateTime(2020, 10, 16, 5, 19, 8, 22, DateTimeKind.Local).AddTicks(9918), "Eos sunt quos dolorem." },
                    { 27, 16, 97, 150605, new DateTime(2020, 6, 6, 10, 48, 36, 923, DateTimeKind.Local).AddTicks(5260), "Libero possimus dolore." },
                    { 50, 16, 135, 118498, new DateTime(2020, 9, 13, 21, 9, 14, 266, DateTimeKind.Local).AddTicks(8934), "ut" },
                    { 181, 58, 26, 177084, new DateTime(2020, 9, 3, 14, 56, 7, 560, DateTimeKind.Local).AddTicks(7549), "ut" },
                    { 11, 11, 117, 669358, new DateTime(2021, 1, 4, 22, 41, 58, 946, DateTimeKind.Local).AddTicks(2909), "Molestias dolores quas consequatur modi consequatur." },
                    { 455, 3, 83, 145625, new DateTime(2021, 1, 1, 2, 36, 45, 822, DateTimeKind.Local).AddTicks(1714), "Ut consequatur quibusdam. Maxime sunt quos magni. Aut rerum neque molestias cumque. Facilis vel molestiae veniam." },
                    { 69, 58, 89, 964465, new DateTime(2020, 12, 25, 9, 17, 13, 247, DateTimeKind.Local).AddTicks(9666), "Voluptates dolores fugiat et et cupiditate suscipit corporis fuga veniam.\nQuasi rerum ipsam qui voluptas illo consequatur et unde ea.\nBeatae eaque facilis.\nDolorum fugiat vitae laudantium fuga pariatur." },
                    { 587, 88, 92, 757498, new DateTime(2020, 6, 8, 7, 38, 18, 524, DateTimeKind.Local).AddTicks(2409), "Cupiditate nemo aut et.\nAtque nihil hic.\nVoluptas quis ut molestiae sint.\nQuibusdam eos blanditiis." },
                    { 99, 27, 82, 85582, new DateTime(2020, 5, 31, 4, 40, 46, 66, DateTimeKind.Local).AddTicks(9638), "Est at debitis expedita." },
                    { 532, 88, 111, 172713, new DateTime(2021, 3, 9, 15, 15, 51, 683, DateTimeKind.Local).AddTicks(1358), "In sint eius." },
                    { 299, 27, 17, 100918, new DateTime(2021, 1, 16, 22, 48, 13, 369, DateTimeKind.Local).AddTicks(8303), "Est consectetur dolore tempora similique aut occaecati quia.\nEt natus officiis ducimus eos consequuntur.\nReprehenderit iure modi aut ipsam.\nSoluta doloribus unde.\nLabore ullam et impedit dolorum et ut.\nConsequuntur est modi itaque consequatur." },
                    { 430, 27, 36, 822225, new DateTime(2020, 6, 9, 8, 12, 47, 740, DateTimeKind.Local).AddTicks(3300), "reiciendis" },
                    { 458, 27, 126, 988902, new DateTime(2020, 6, 2, 18, 43, 24, 883, DateTimeKind.Local).AddTicks(7458), "Consequatur voluptatem aspernatur accusamus. Et nobis sint qui. Repellat quae omnis perferendis." },
                    { 95, 83, 43, 484415, new DateTime(2020, 11, 1, 10, 36, 31, 651, DateTimeKind.Local).AddTicks(4442), "Numquam amet veritatis quia. Quas animi quibusdam et et odio. Qui esse pariatur sapiente est explicabo libero enim. Error sit dolorum eveniet et quisquam. Error molestiae sint totam praesentium enim ullam alias sapiente. Sunt et aut sed aperiam a cum ullam iste quaerat." },
                    { 554, 3, 53, 819786, new DateTime(2020, 5, 1, 16, 10, 48, 141, DateTimeKind.Local).AddTicks(1411), "Modi dolorum consequatur at suscipit eos porro quis est.\nSint cum tempora quo.\nCorrupti similique nam aut maiores accusamus esse alias nesciunt.\nNobis ab delectus.\nVelit consequuntur dolor modi esse enim aut." },
                    { 128, 83, 3, 765493, new DateTime(2020, 12, 17, 8, 2, 33, 637, DateTimeKind.Local).AddTicks(770), "Reiciendis dolores optio sit porro id consequatur fuga aut. Ea est excepturi illo tempore aut. Et sit nesciunt inventore. Delectus id eum enim sequi praesentium rerum. Veritatis eligendi dolor consequuntur dignissimos vel nulla aut." },
                    { 494, 88, 53, 350718, new DateTime(2021, 3, 18, 6, 35, 19, 47, DateTimeKind.Local).AddTicks(9950), "Aut sit vitae temporibus ut hic quidem ex autem." },
                    { 193, 98, 18, 675854, new DateTime(2020, 7, 28, 15, 0, 22, 951, DateTimeKind.Local).AddTicks(2394), "Sequi enim quae ipsam et ut voluptatibus natus." },
                    { 230, 98, 121, 201801, new DateTime(2020, 5, 7, 0, 45, 42, 513, DateTimeKind.Local).AddTicks(9900), "Velit vel possimus pariatur sint. Hic deleniti ut aut autem. Nobis enim nihil vitae non temporibus fugit et voluptatem. Aut tempore necessitatibus. Blanditiis aut sed non." },
                    { 270, 98, 91, 883467, new DateTime(2020, 6, 25, 10, 53, 47, 158, DateTimeKind.Local).AddTicks(9356), "Qui sit consequuntur et.\nSimilique assumenda delectus sed fugit et et expedita est.\nNesciunt quia magni porro et quidem id explicabo itaque.\nVoluptatem exercitationem deserunt cupiditate." },
                    { 456, 98, 96, 69984, new DateTime(2020, 6, 2, 1, 18, 23, 11, DateTimeKind.Local).AddTicks(1081), "Perspiciatis consequatur eveniet. Quisquam eos sunt. Veritatis eum eligendi soluta modi adipisci sequi mollitia. Sit itaque quas. Mollitia repellendus molestias quisquam est ut accusantium. Occaecati praesentium ut tempora cumque accusantium atque ut amet nesciunt." },
                    { 446, 88, 112, 991796, new DateTime(2020, 9, 10, 18, 57, 53, 64, DateTimeKind.Local).AddTicks(5725), "Sint nemo minus tempora dolor." },
                    { 593, 83, 28, 552228, new DateTime(2020, 12, 2, 8, 20, 28, 209, DateTimeKind.Local).AddTicks(9444), "Minima neque pariatur qui.\nEst eos officia facere." },
                    { 584, 88, 123, 286160, new DateTime(2020, 8, 29, 14, 15, 40, 113, DateTimeKind.Local).AddTicks(403), "ipsum" },
                    { 476, 89, 76, 890871, new DateTime(2021, 1, 26, 15, 16, 38, 238, DateTimeKind.Local).AddTicks(3116), "Natus deleniti cupiditate aut atque maxime maxime commodi. Hic tempora minus ut explicabo sit. At blanditiis et aut deleniti omnis fugit tempora placeat. Quasi ipsam quos recusandae deleniti minus. Voluptatibus provident tempora. Beatae laborum quasi eveniet magnam commodi ab voluptate." },
                    { 340, 87, 47, 141628, new DateTime(2021, 2, 7, 11, 45, 33, 999, DateTimeKind.Local).AddTicks(1655), "distinctio" },
                    { 73, 19, 36, 383245, new DateTime(2020, 8, 20, 1, 36, 20, 684, DateTimeKind.Local).AddTicks(725), "Aliquid dolores atque non. Nemo minus quis ipsa possimus ipsum quia assumenda quia. Nihil laborum cumque et ratione iusto nostrum et. Qui nihil ea eum ut quis et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 275, 87, 148, 661448, new DateTime(2020, 11, 2, 12, 41, 45, 615, DateTimeKind.Local).AddTicks(6356), "Ipsa asperiores aut illo et molestiae voluptates nam corrupti. Aliquam dolor reprehenderit quos ut neque. Dolorem voluptatibus laudantium. Vitae laboriosam sunt qui est repellendus deleniti exercitationem corrupti. Modi neque modi. Dolores deleniti molestiae laboriosam." },
                    { 158, 87, 24, 439932, new DateTime(2021, 1, 21, 22, 3, 5, 593, DateTimeKind.Local).AddTicks(5530), "accusantium" },
                    { 121, 87, 56, 333038, new DateTime(2020, 4, 20, 13, 6, 32, 798, DateTimeKind.Local).AddTicks(7519), "Repellendus rerum labore sed voluptatibus modi autem reiciendis autem. Id consectetur a tempore odio aperiam earum. Ipsam dolores molestiae porro nihil consequatur mollitia excepturi." },
                    { 37, 87, 64, 563065, new DateTime(2021, 1, 12, 7, 19, 24, 824, DateTimeKind.Local).AddTicks(1188), "doloribus" },
                    { 100, 19, 143, 266935, new DateTime(2021, 3, 15, 2, 18, 22, 936, DateTimeKind.Local).AddTicks(4701), "Mollitia non a quo praesentium est provident est perferendis.\nRerum cumque eum ratione deserunt modi necessitatibus cumque minus.\nSed repellat aut officia officia ut aut corporis." },
                    { 10, 87, 78, 312719, new DateTime(2021, 2, 12, 13, 32, 32, 615, DateTimeKind.Local).AddTicks(7976), "Rem fugit quam doloremque iure quos in aut. Placeat et ea ad natus eius laudantium odit. Ut nulla quasi velit perspiciatis quam quo. Aliquid est nobis. Minima officia et sequi qui sunt quam omnis." },
                    { 103, 19, 2, 627158, new DateTime(2020, 5, 1, 18, 53, 41, 568, DateTimeKind.Local).AddTicks(4714), "Fugiat et unde molestiae error ipsa.\nSint quae quasi.\nEum nobis nihil veritatis qui sed eum vel minus commodi." },
                    { 420, 87, 113, 991590, new DateTime(2020, 8, 20, 5, 42, 31, 495, DateTimeKind.Local).AddTicks(966), "incidunt" },
                    { 355, 19, 17, 289479, new DateTime(2020, 11, 8, 16, 24, 10, 197, DateTimeKind.Local).AddTicks(2678), "Libero maxime vitae qui qui pariatur nisi hic dolorem." },
                    { 180, 19, 140, 389147, new DateTime(2020, 9, 22, 3, 5, 23, 926, DateTimeKind.Local).AddTicks(6886), "Magni fuga eos temporibus ex voluptates quos blanditiis." },
                    { 156, 19, 72, 960420, new DateTime(2020, 12, 7, 12, 20, 39, 442, DateTimeKind.Local).AddTicks(8959), "Quae nisi assumenda distinctio vitae pariatur voluptas dolor ut ad. Enim qui illo id id incidunt. Omnis non quam iusto sint dolor fugiat voluptatem vitae. Sit excepturi ut provident." },
                    { 116, 19, 80, 25585, new DateTime(2020, 10, 10, 14, 32, 11, 237, DateTimeKind.Local).AddTicks(8118), "Ut accusamus ea. Id mollitia odio dolor ab ipsam. Vitae non est fugit earum amet quis praesentium consequatur et. Quia id voluptas facere et sit officia vel consequatur ipsam." }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 88, 106, 16 },
                    { 95, 103, 131 },
                    { 13, 110, 27 },
                    { 25, 46, 266 },
                    { 99, 77, 272 },
                    { 9, 57, 49 },
                    { 87, 65, 199 },
                    { 43, 17, 24 },
                    { 61, 49, 235 },
                    { 79, 78, 55 },
                    { 8, 9, 222 },
                    { 54, 8, 220 },
                    { 30, 16, 194 },
                    { 49, 79, 79 },
                    { 46, 51, 2 },
                    { 83, 3, 66 },
                    { 41, 87, 68 },
                    { 7, 76, 267 },
                    { 15, 83, 40 },
                    { 19, 86, 205 },
                    { 53, 98, 62 },
                    { 22, 11, 126 },
                    { 69, 100, 33 },
                    { 51, 35, 274 },
                    { 73, 64, 20 },
                    { 16, 71, 80 },
                    { 31, 43, 254 },
                    { 37, 53, 126 },
                    { 34, 44, 108 },
                    { 62, 28, 49 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 24, 38, 10 },
                    { 26, 2, 143 },
                    { 28, 14, 235 },
                    { 6, 102, 24 },
                    { 14, 36, 128 },
                    { 108, 40, 172 },
                    { 59, 91, 145 },
                    { 56, 99, 94 },
                    { 5, 105, 194 },
                    { 42, 6, 245 },
                    { 50, 41, 103 },
                    { 38, 18, 267 },
                    { 10, 23, 254 },
                    { 98, 93, 126 },
                    { 23, 108, 194 },
                    { 29, 15, 220 },
                    { 1, 96, 70 },
                    { 65, 7, 73 },
                    { 90, 69, 285 },
                    { 52, 45, 272 },
                    { 18, 31, 159 },
                    { 47, 67, 2 },
                    { 2, 111, 27 },
                    { 63, 5, 2 },
                    { 3, 92, 194 },
                    { 4, 37, 39 },
                    { 40, 30, 66 },
                    { 60, 70, 286 },
                    { 71, 4, 93 },
                    { 89, 25, 74 },
                    { 85, 101, 24 },
                    { 68, 109, 244 },
                    { 12, 20, 59 },
                    { 86, 24, 180 },
                    { 17, 80, 66 },
                    { 11, 1, 11 },
                    { 57, 56, 254 },
                    { 102, 95, 286 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 14, new DateTime(2020, 10, 13, 5, 49, 22, 782, DateTimeKind.Local).AddTicks(6407), 2, new DateTime(2021, 10, 5, 10, 28, 9, 424, DateTimeKind.Local).AddTicks(2165), new DateTime(2021, 2, 12, 23, 51, 55, 34, DateTimeKind.Local).AddTicks(1122), 2, 43, "Dolorem excepturi quae illum atque saepe qui.\nOmnis enim omnis nam fugiat incidunt.\nSuscipit ipsum et expedita blanditiis exercitationem laborum molestiae dolorem at.\nNon quo deleniti est illum.\nVel ea quos recusandae omnis omnis vel saepe eius et.\nNeque ea aut necessitatibus omnis iure." },
                    { 135, new DateTime(2021, 3, 15, 2, 36, 17, 103, DateTimeKind.Local).AddTicks(4889), 26, new DateTime(2022, 2, 10, 2, 50, 0, 742, DateTimeKind.Local).AddTicks(8045), new DateTime(2020, 4, 24, 7, 54, 50, 375, DateTimeKind.Local).AddTicks(8134), 1, 61, "Nulla dolores facere molestiae aut. Est quis aspernatur est aliquam perferendis ea necessitatibus pariatur temporibus. Quam magni error. Qui vitae aliquid ex eius id animi ut ea officiis. Temporibus et asperiores fuga voluptatum. Dolorem laborum repudiandae nulla unde et impedit." },
                    { 167, new DateTime(2020, 10, 5, 7, 35, 47, 348, DateTimeKind.Local).AddTicks(8503), 76, new DateTime(2021, 12, 5, 20, 0, 57, 993, DateTimeKind.Local).AddTicks(8344), new DateTime(2021, 2, 27, 8, 35, 31, 364, DateTimeKind.Local).AddTicks(2199), 2, 61, "Rerum quis voluptatem nihil. Est nam perspiciatis distinctio qui. Sed iste qui error quidem aperiam voluptas quaerat dolor. Eos quasi aspernatur aut. Distinctio velit enim facilis nisi. Iure voluptatibus illum velit sequi enim officiis." },
                    { 137, new DateTime(2020, 12, 26, 16, 6, 26, 446, DateTimeKind.Local).AddTicks(5735), 112, new DateTime(2021, 11, 13, 22, 0, 18, 672, DateTimeKind.Local).AddTicks(4449), new DateTime(2020, 9, 29, 5, 19, 9, 849, DateTimeKind.Local).AddTicks(7669), 3, 89, "Distinctio dolore facere deserunt voluptas." },
                    { 161, new DateTime(2021, 1, 12, 23, 14, 48, 265, DateTimeKind.Local).AddTicks(8282), 44, new DateTime(2021, 4, 28, 14, 48, 2, 188, DateTimeKind.Local).AddTicks(2616), new DateTime(2020, 10, 22, 10, 15, 16, 797, DateTimeKind.Local).AddTicks(8753), 4, 89, "Sed non autem possimus qui et aut iusto. Sit cum nobis fugiat aut dicta quia. Id consectetur aspernatur provident dolores vel fuga quia. Dolorem nulla nobis et." },
                    { 97, new DateTime(2020, 4, 20, 17, 8, 59, 650, DateTimeKind.Local).AddTicks(9988), 93, new DateTime(2021, 12, 28, 0, 38, 29, 162, DateTimeKind.Local).AddTicks(8718), new DateTime(2020, 5, 30, 17, 47, 20, 325, DateTimeKind.Local).AddTicks(9112), 1, 71, "Velit et tenetur id aliquid.\nDeserunt id autem a porro repellat ea pariatur neque.\nDeserunt ab repudiandae recusandae quod.\nQuae magnam aut ut dicta laudantium quos nihil nostrum." },
                    { 47, new DateTime(2020, 5, 29, 18, 37, 27, 535, DateTimeKind.Local).AddTicks(6100), 63, new DateTime(2022, 1, 1, 22, 36, 24, 849, DateTimeKind.Local).AddTicks(9739), new DateTime(2020, 4, 17, 19, 26, 43, 591, DateTimeKind.Local).AddTicks(1591), 3, 40, "Eligendi consequatur rem voluptatem pariatur commodi. Omnis mollitia eos et nam qui aut laudantium deserunt eligendi. Alias et impedit ad et eaque voluptas ut eligendi repellat. Qui consequuntur recusandae eaque nihil qui repudiandae. Iure nobis consequatur nulla ducimus placeat vel perspiciatis. Quas ut rerum consequatur consectetur labore." },
                    { 55, new DateTime(2021, 3, 15, 20, 55, 10, 252, DateTimeKind.Local).AddTicks(2569), 46, new DateTime(2021, 5, 19, 7, 22, 58, 858, DateTimeKind.Local).AddTicks(1424), new DateTime(2020, 11, 11, 17, 21, 6, 26, DateTimeKind.Local).AddTicks(9307), 4, 40, "Porro consequatur repellendus." },
                    { 77, new DateTime(2020, 5, 15, 21, 53, 41, 410, DateTimeKind.Local).AddTicks(3909), 109, new DateTime(2021, 5, 6, 20, 56, 36, 193, DateTimeKind.Local).AddTicks(9330), new DateTime(2020, 8, 22, 21, 5, 12, 230, DateTimeKind.Local).AddTicks(5202), 4, 40, "Nisi sequi debitis ut. Non neque dolorum excepturi explicabo consequatur non repellat tempora facere. Voluptate ut ab hic similique optio et enim. Provident quibusdam beatae necessitatibus dolores et alias provident voluptates ut." },
                    { 158, new DateTime(2021, 2, 8, 4, 15, 28, 259, DateTimeKind.Local).AddTicks(9194), 118, new DateTime(2022, 2, 9, 10, 6, 51, 725, DateTimeKind.Local).AddTicks(6613), new DateTime(2021, 2, 27, 5, 50, 25, 959, DateTimeKind.Local).AddTicks(3362), 2, 40, "Ut animi non earum dolores similique incidunt accusantium." },
                    { 160, new DateTime(2020, 9, 8, 0, 1, 12, 468, DateTimeKind.Local).AddTicks(9056), 50, new DateTime(2021, 5, 15, 13, 14, 49, 923, DateTimeKind.Local).AddTicks(6720), new DateTime(2020, 8, 27, 7, 34, 38, 355, DateTimeKind.Local).AddTicks(1108), 3, 40, "Numquam quas assumenda molestiae tempore neque sit quod in." },
                    { 164, new DateTime(2020, 10, 24, 17, 11, 44, 606, DateTimeKind.Local).AddTicks(8038), 31, new DateTime(2021, 5, 21, 16, 58, 46, 270, DateTimeKind.Local).AddTicks(5391), new DateTime(2020, 8, 24, 4, 50, 41, 405, DateTimeKind.Local).AddTicks(6748), 4, 40, "Accusantium minus consequatur nihil optio omnis veniam voluptatem.\nIllo consequatur et voluptates eum accusantium quia aliquam aut.\nAnimi asperiores deleniti quasi." },
                    { 69, new DateTime(2020, 9, 7, 9, 46, 14, 332, DateTimeKind.Local).AddTicks(6512), 32, new DateTime(2021, 12, 18, 2, 11, 54, 86, DateTimeKind.Local).AddTicks(6610), new DateTime(2020, 9, 15, 14, 41, 16, 380, DateTimeKind.Local).AddTicks(8423), 5, 4, "Fugiat eveniet ducimus et qui. Optio repellendus sequi blanditiis ipsam facere quam minus sapiente quae. Quisquam at nisi quia error vitae earum." },
                    { 36, new DateTime(2020, 9, 13, 14, 3, 59, 12, DateTimeKind.Local).AddTicks(8457), 127, new DateTime(2021, 11, 14, 23, 51, 56, 396, DateTimeKind.Local).AddTicks(966), new DateTime(2020, 4, 30, 5, 5, 4, 320, DateTimeKind.Local).AddTicks(4657), 2, 57, "Et officia qui provident." },
                    { 50, new DateTime(2021, 2, 14, 4, 43, 6, 819, DateTimeKind.Local).AddTicks(6102), 134, new DateTime(2021, 9, 12, 20, 44, 49, 289, DateTimeKind.Local).AddTicks(4045), new DateTime(2020, 8, 12, 3, 56, 41, 709, DateTimeKind.Local).AddTicks(8773), 1, 57, "Quibusdam reiciendis pariatur reprehenderit dolorem sunt molestiae. Aut qui vero sint saepe quis itaque voluptatem enim sit. Natus aut consequuntur qui occaecati consectetur ea." },
                    { 80, new DateTime(2020, 4, 18, 10, 3, 23, 250, DateTimeKind.Local).AddTicks(5280), 49, new DateTime(2021, 10, 30, 13, 46, 38, 479, DateTimeKind.Local).AddTicks(4356), new DateTime(2021, 3, 16, 0, 53, 34, 401, DateTimeKind.Local).AddTicks(3262), 4, 57, "Aspernatur quis minus.\nVel consectetur vero aut ipsum aperiam temporibus nihil.\nAdipisci error sed tempora deserunt occaecati tempora labore." },
                    { 128, new DateTime(2020, 11, 5, 10, 53, 41, 948, DateTimeKind.Local).AddTicks(5245), 110, new DateTime(2021, 11, 14, 21, 50, 34, 192, DateTimeKind.Local).AddTicks(9143), new DateTime(2020, 8, 6, 7, 14, 27, 210, DateTimeKind.Local).AddTicks(4586), 2, 57, "Velit repudiandae soluta et repellat ad quod possimus explicabo." },
                    { 146, new DateTime(2020, 8, 22, 12, 44, 22, 491, DateTimeKind.Local).AddTicks(4068), 7, new DateTime(2022, 2, 6, 16, 46, 48, 322, DateTimeKind.Local).AddTicks(5604), new DateTime(2020, 5, 10, 16, 51, 29, 920, DateTimeKind.Local).AddTicks(6680), 4, 57, "ut" },
                    { 181, new DateTime(2020, 7, 2, 17, 44, 5, 314, DateTimeKind.Local).AddTicks(2935), 79, new DateTime(2021, 5, 5, 22, 23, 8, 565, DateTimeKind.Local).AddTicks(5145), new DateTime(2020, 12, 1, 11, 52, 28, 107, DateTimeKind.Local).AddTicks(8981), 3, 57, "Occaecati nulla id quae animi tempore distinctio soluta sunt." },
                    { 15, new DateTime(2020, 5, 11, 15, 10, 16, 662, DateTimeKind.Local).AddTicks(9309), 53, new DateTime(2022, 2, 28, 12, 37, 15, 564, DateTimeKind.Local).AddTicks(8344), new DateTime(2021, 1, 13, 13, 45, 3, 977, DateTimeKind.Local).AddTicks(5675), 5, 47, "Sapiente quia soluta laborum.\nDoloribus qui vero quis molestiae id aut sunt qui perspiciatis.\nUt quos modi voluptas totam facere totam qui ducimus.\nNam veniam saepe." },
                    { 17, new DateTime(2020, 10, 15, 4, 48, 51, 295, DateTimeKind.Local).AddTicks(7701), 81, new DateTime(2021, 4, 21, 3, 9, 52, 318, DateTimeKind.Local).AddTicks(6926), new DateTime(2021, 3, 12, 21, 41, 28, 825, DateTimeKind.Local).AddTicks(3929), 2, 47, "Ad quisquam suscipit illum.\nQuia expedita tempora dolorem accusamus quia ipsum delectus.\nLabore et distinctio doloremque culpa quis.\nHarum deserunt qui inventore ut itaque alias.\nQuasi dolorem tenetur nostrum rerum deserunt.\nAnimi provident autem est mollitia voluptatibus." },
                    { 89, new DateTime(2020, 8, 11, 0, 30, 37, 138, DateTimeKind.Local).AddTicks(2898), 128, new DateTime(2021, 7, 15, 19, 6, 22, 323, DateTimeKind.Local).AddTicks(3543), new DateTime(2020, 6, 28, 2, 21, 34, 244, DateTimeKind.Local).AddTicks(1305), 4, 47, "Ab deserunt totam est est voluptatem ipsa sequi." },
                    { 18, new DateTime(2020, 7, 5, 4, 6, 58, 496, DateTimeKind.Local).AddTicks(8588), 106, new DateTime(2021, 5, 11, 16, 19, 45, 41, DateTimeKind.Local).AddTicks(7542), new DateTime(2020, 5, 22, 3, 40, 11, 242, DateTimeKind.Local).AddTicks(7747), 4, 61, "eius" },
                    { 133, new DateTime(2020, 10, 30, 12, 21, 29, 140, DateTimeKind.Local).AddTicks(3451), 62, new DateTime(2021, 11, 8, 18, 40, 32, 334, DateTimeKind.Local).AddTicks(1235), new DateTime(2020, 11, 30, 4, 52, 54, 650, DateTimeKind.Local).AddTicks(7582), 4, 47, "Exercitationem aut magnam. Voluptatem voluptas voluptatibus temporibus quas qui non. Aut cum et vitae ducimus. Facilis quos porro et et. Et minus cupiditate nihil consequuntur suscipit nemo qui. Voluptatem et nisi." },
                    { 165, new DateTime(2021, 1, 22, 22, 32, 56, 609, DateTimeKind.Local).AddTicks(5184), 38, new DateTime(2021, 12, 16, 11, 35, 11, 639, DateTimeKind.Local).AddTicks(582), new DateTime(2020, 12, 27, 3, 10, 46, 184, DateTimeKind.Local).AddTicks(5319), 1, 12, "sit" },
                    { 123, new DateTime(2020, 10, 13, 10, 33, 10, 593, DateTimeKind.Local).AddTicks(5464), 74, new DateTime(2021, 12, 23, 2, 45, 7, 263, DateTimeKind.Local).AddTicks(7915), new DateTime(2020, 8, 21, 0, 36, 45, 641, DateTimeKind.Local).AddTicks(222), 1, 86, "Sit sapiente architecto adipisci aperiam. Eum ut non ut tempora debitis inventore sed quibusdam. Et provident exercitationem. Dolor modi dolorum nisi natus repudiandae." },
                    { 51, new DateTime(2020, 12, 6, 7, 26, 52, 687, DateTimeKind.Local).AddTicks(8794), 97, new DateTime(2021, 9, 1, 8, 55, 37, 352, DateTimeKind.Local).AddTicks(5112), new DateTime(2020, 9, 16, 7, 37, 50, 626, DateTimeKind.Local).AddTicks(560), 2, 46, "sint" },
                    { 126, new DateTime(2020, 10, 14, 15, 42, 37, 885, DateTimeKind.Local).AddTicks(9888), 13, new DateTime(2021, 12, 6, 13, 59, 8, 696, DateTimeKind.Local).AddTicks(5365), new DateTime(2020, 11, 13, 5, 49, 45, 781, DateTimeKind.Local).AddTicks(9984), 2, 46, "Repellendus quos quod dolor." },
                    { 132, new DateTime(2020, 11, 10, 12, 46, 23, 447, DateTimeKind.Local).AddTicks(7453), 50, new DateTime(2021, 11, 9, 3, 43, 46, 341, DateTimeKind.Local).AddTicks(5675), new DateTime(2020, 12, 14, 20, 51, 20, 338, DateTimeKind.Local).AddTicks(985), 4, 46, "Accusamus illum ipsam." },
                    { 58, new DateTime(2021, 2, 2, 8, 29, 50, 710, DateTimeKind.Local).AddTicks(8269), 91, new DateTime(2021, 7, 24, 9, 6, 4, 315, DateTimeKind.Local).AddTicks(2610), new DateTime(2020, 11, 16, 15, 40, 36, 941, DateTimeKind.Local).AddTicks(389), 2, 54, "Aut provident officia dolores natus optio magnam tempore vel." },
                    { 114, new DateTime(2021, 3, 20, 14, 53, 54, 772, DateTimeKind.Local).AddTicks(7433), 89, new DateTime(2021, 8, 24, 7, 35, 22, 357, DateTimeKind.Local).AddTicks(6646), new DateTime(2020, 10, 14, 2, 33, 32, 612, DateTimeKind.Local).AddTicks(7082), 5, 54, "Amet nesciunt sint iure omnis.\nRepudiandae minus eveniet odit tenetur illum rerum ut iure.\nFuga quia quis assumenda et similique labore.\nAutem et perferendis.\nSint ad amet molestias nostrum cupiditate distinctio quas cum." },
                    { 174, new DateTime(2020, 7, 12, 15, 37, 47, 740, DateTimeKind.Local).AddTicks(5880), 98, new DateTime(2021, 11, 26, 10, 59, 45, 704, DateTimeKind.Local).AddTicks(9824), new DateTime(2020, 10, 9, 12, 4, 45, 733, DateTimeKind.Local).AddTicks(7535), 2, 54, "Natus et quia." },
                    { 101, new DateTime(2020, 11, 27, 12, 44, 46, 550, DateTimeKind.Local).AddTicks(903), 100, new DateTime(2021, 4, 3, 19, 21, 10, 340, DateTimeKind.Local).AddTicks(6758), new DateTime(2020, 5, 17, 2, 38, 26, 169, DateTimeKind.Local).AddTicks(7752), 1, 8, "Sed qui accusantium iusto." },
                    { 185, new DateTime(2021, 1, 12, 13, 9, 10, 15, DateTimeKind.Local).AddTicks(3046), 147, new DateTime(2021, 5, 19, 4, 52, 45, 415, DateTimeKind.Local).AddTicks(8796), new DateTime(2020, 6, 19, 22, 14, 47, 952, DateTimeKind.Local).AddTicks(9823), 1, 8, "Sunt voluptas id accusamus provident. Numquam consectetur enim. Non quia magnam at omnis quasi consequatur nam." },
                    { 186, new DateTime(2020, 9, 30, 9, 53, 26, 925, DateTimeKind.Local).AddTicks(383), 47, new DateTime(2021, 8, 15, 9, 16, 50, 632, DateTimeKind.Local).AddTicks(4725), new DateTime(2020, 4, 26, 6, 18, 59, 699, DateTimeKind.Local).AddTicks(2736), 4, 8, "libero" },
                    { 32, new DateTime(2020, 9, 21, 3, 8, 58, 356, DateTimeKind.Local).AddTicks(199), 79, new DateTime(2022, 1, 16, 0, 30, 41, 279, DateTimeKind.Local).AddTicks(2318), new DateTime(2020, 4, 23, 17, 43, 49, 374, DateTimeKind.Local).AddTicks(1717), 4, 5, "Maxime quis dolor.\nEt a quia.\nQuasi et enim officia porro soluta ipsa quia ipsum corrupti.\nSequi et hic est qui facilis non suscipit dolor.\nAutem corrupti qui.\nAmet distinctio consectetur." },
                    { 56, new DateTime(2020, 4, 27, 10, 50, 31, 179, DateTimeKind.Local).AddTicks(4681), 59, new DateTime(2022, 1, 27, 22, 55, 37, 558, DateTimeKind.Local).AddTicks(6829), new DateTime(2021, 2, 26, 16, 46, 56, 868, DateTimeKind.Local).AddTicks(9576), 5, 5, "Dolorum quae voluptatem tempore.\nNihil laudantium non et est.\nSint unde atque ipsa exercitationem iusto aperiam excepturi eligendi dicta.\nUt laborum mollitia itaque tempore.\nAsperiores ipsa voluptatem voluptate illum.\nVel distinctio nesciunt dicta optio." },
                    { 145, new DateTime(2021, 1, 16, 16, 45, 36, 654, DateTimeKind.Local).AddTicks(3297), 62, new DateTime(2021, 8, 13, 23, 54, 4, 692, DateTimeKind.Local).AddTicks(160), new DateTime(2020, 10, 27, 9, 22, 5, 458, DateTimeKind.Local).AddTicks(9710), 1, 5, "Sed inventore dolores enim quia omnis vel ratione et officia.\nEt at veritatis placeat.\nBeatae ut rerum aperiam reiciendis voluptatem quisquam repellat.\nOptio odio fugit adipisci iste quo.\nAut ipsum ex.\nNesciunt molestiae vitae." },
                    { 199, new DateTime(2020, 10, 1, 12, 32, 3, 823, DateTimeKind.Local).AddTicks(4133), 143, new DateTime(2022, 2, 21, 7, 11, 25, 494, DateTimeKind.Local).AddTicks(36), new DateTime(2020, 4, 13, 8, 40, 36, 24, DateTimeKind.Local).AddTicks(3464), 4, 5, "Ex qui quia architecto." },
                    { 84, new DateTime(2021, 2, 13, 15, 37, 22, 337, DateTimeKind.Local).AddTicks(320), 99, new DateTime(2021, 12, 5, 0, 48, 36, 983, DateTimeKind.Local).AddTicks(5247), new DateTime(2020, 4, 2, 2, 18, 0, 240, DateTimeKind.Local).AddTicks(6542), 3, 42, "Reiciendis voluptas fuga quis quia." },
                    { 162, new DateTime(2020, 9, 23, 16, 1, 19, 808, DateTimeKind.Local).AddTicks(9460), 45, new DateTime(2021, 7, 4, 21, 3, 58, 517, DateTimeKind.Local).AddTicks(4268), new DateTime(2020, 9, 27, 13, 21, 9, 451, DateTimeKind.Local).AddTicks(9792), 3, 42, "Nihil vel labore. Quo veritatis quo nihil natus inventore consequatur vel. Omnis dolor sed et ratione dolorem harum ut et ut. Deserunt doloribus quaerat officia perspiciatis aut voluptas sit velit." },
                    { 193, new DateTime(2020, 12, 16, 8, 23, 50, 789, DateTimeKind.Local).AddTicks(354), 125, new DateTime(2021, 4, 28, 0, 31, 53, 978, DateTimeKind.Local).AddTicks(7897), new DateTime(2021, 1, 21, 0, 7, 50, 985, DateTimeKind.Local).AddTicks(9697), 4, 42, "Quia recusandae non id eveniet ex ab quia qui quia.\nVoluptates occaecati omnis nihil ex." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 65, new DateTime(2020, 7, 19, 18, 2, 16, 276, DateTimeKind.Local).AddTicks(3227), 66, new DateTime(2021, 8, 5, 3, 26, 16, 924, DateTimeKind.Local).AddTicks(1351), new DateTime(2020, 11, 6, 16, 1, 47, 677, DateTimeKind.Local).AddTicks(8319), 1, 17, "consequatur" },
                    { 102, new DateTime(2021, 3, 3, 9, 36, 47, 138, DateTimeKind.Local).AddTicks(4551), 14, new DateTime(2021, 7, 7, 4, 18, 54, 989, DateTimeKind.Local).AddTicks(9616), new DateTime(2020, 8, 30, 5, 56, 53, 89, DateTimeKind.Local).AddTicks(3170), 1, 17, "odit" },
                    { 183, new DateTime(2021, 3, 12, 11, 28, 38, 15, DateTimeKind.Local).AddTicks(4270), 105, new DateTime(2022, 1, 24, 10, 23, 37, 882, DateTimeKind.Local).AddTicks(4532), new DateTime(2020, 11, 23, 14, 1, 25, 459, DateTimeKind.Local).AddTicks(8959), 4, 17, "nostrum" },
                    { 23, new DateTime(2021, 1, 1, 9, 48, 6, 326, DateTimeKind.Local).AddTicks(175), 57, new DateTime(2021, 12, 22, 2, 16, 4, 534, DateTimeKind.Local).AddTicks(767), new DateTime(2020, 8, 3, 8, 56, 32, 793, DateTimeKind.Local).AddTicks(4925), 2, 86, "ea" },
                    { 120, new DateTime(2021, 2, 28, 21, 56, 26, 823, DateTimeKind.Local).AddTicks(4980), 33, new DateTime(2021, 5, 17, 14, 54, 6, 83, DateTimeKind.Local).AddTicks(6156), new DateTime(2020, 9, 6, 17, 30, 1, 778, DateTimeKind.Local).AddTicks(307), 4, 86, "fugit" },
                    { 134, new DateTime(2020, 12, 14, 12, 21, 2, 738, DateTimeKind.Local).AddTicks(8072), 73, new DateTime(2021, 3, 31, 12, 18, 17, 678, DateTimeKind.Local).AddTicks(3956), new DateTime(2020, 6, 13, 19, 26, 7, 939, DateTimeKind.Local).AddTicks(3689), 5, 12, "Sit natus mollitia impedit magnam quasi laudantium.\nEnim qui quos vel dolorum.\nProvident et ad.\nIpsum quo possimus incidunt corrupti quia in nobis.\nFacilis ut sapiente eaque." },
                    { 191, new DateTime(2020, 9, 26, 1, 29, 48, 516, DateTimeKind.Local).AddTicks(342), 23, new DateTime(2021, 5, 31, 13, 26, 3, 949, DateTimeKind.Local).AddTicks(649), new DateTime(2020, 5, 5, 19, 39, 18, 334, DateTimeKind.Local).AddTicks(2200), 3, 7, "voluptatem" },
                    { 195, new DateTime(2020, 9, 20, 4, 55, 40, 428, DateTimeKind.Local).AddTicks(7262), 141, new DateTime(2021, 5, 4, 13, 3, 10, 756, DateTimeKind.Local).AddTicks(4312), new DateTime(2020, 8, 25, 5, 39, 6, 575, DateTimeKind.Local).AddTicks(8100), 2, 47, "Dolorum aliquid optio vitae voluptatem.\nEt qui omnis velit delectus tempore similique optio nihil et.\nConsectetur blanditiis molestias id odio minima.\nItaque perspiciatis dolor numquam est facere.\nVoluptatibus autem ipsum id repudiandae rem aut." },
                    { 73, new DateTime(2020, 3, 31, 13, 16, 30, 144, DateTimeKind.Local).AddTicks(2104), 82, new DateTime(2021, 10, 19, 0, 56, 10, 99, DateTimeKind.Local).AddTicks(5180), new DateTime(2020, 6, 11, 7, 57, 46, 883, DateTimeKind.Local).AddTicks(536), 1, 18, "qui" },
                    { 138, new DateTime(2020, 12, 16, 7, 43, 25, 499, DateTimeKind.Local).AddTicks(8483), 71, new DateTime(2022, 3, 19, 5, 40, 23, 725, DateTimeKind.Local).AddTicks(5266), new DateTime(2020, 4, 25, 16, 50, 46, 960, DateTimeKind.Local).AddTicks(8395), 5, 50, "Placeat aut non et et occaecati debitis." },
                    { 189, new DateTime(2020, 6, 17, 20, 47, 52, 375, DateTimeKind.Local).AddTicks(6021), 94, new DateTime(2021, 6, 3, 17, 38, 18, 267, DateTimeKind.Local).AddTicks(4351), new DateTime(2020, 9, 9, 2, 17, 29, 793, DateTimeKind.Local).AddTicks(5506), 5, 50, "Eos omnis incidunt aut iusto laborum molestias ea." },
                    { 108, new DateTime(2020, 6, 12, 13, 6, 38, 212, DateTimeKind.Local).AddTicks(7030), 126, new DateTime(2021, 3, 27, 1, 27, 2, 27, DateTimeKind.Local).AddTicks(1365), new DateTime(2020, 12, 2, 6, 39, 27, 722, DateTimeKind.Local).AddTicks(2868), 4, 79, "Temporibus delectus ea sit omnis. Veritatis ut aliquam eum. Ducimus id distinctio nihil nobis. Neque placeat ipsam dolorem consequatur voluptatum dignissimos aliquid delectus et. Voluptate commodi dignissimos minima voluptas inventore." },
                    { 182, new DateTime(2021, 3, 20, 2, 6, 33, 729, DateTimeKind.Local).AddTicks(5553), 29, new DateTime(2022, 2, 6, 6, 59, 29, 912, DateTimeKind.Local).AddTicks(6132), new DateTime(2020, 3, 31, 2, 0, 23, 499, DateTimeKind.Local).AddTicks(9433), 2, 79, "dolorem" },
                    { 100, new DateTime(2020, 7, 21, 0, 29, 34, 325, DateTimeKind.Local).AddTicks(5449), 28, new DateTime(2022, 1, 6, 22, 23, 42, 765, DateTimeKind.Local).AddTicks(6247), new DateTime(2020, 7, 24, 2, 1, 56, 839, DateTimeKind.Local).AddTicks(6035), 2, 56, "dolore" },
                    { 42, new DateTime(2020, 7, 23, 22, 10, 37, 88, DateTimeKind.Local).AddTicks(6090), 109, new DateTime(2021, 8, 25, 5, 16, 9, 549, DateTimeKind.Local).AddTicks(4563), new DateTime(2020, 12, 18, 18, 35, 52, 981, DateTimeKind.Local).AddTicks(8253), 5, 9, "Facere quam id dolorum quos vero incidunt. Dolorem ratione mollitia quo dicta voluptatem ex est commodi. Cum enim sed quis dolorum itaque et illum aut. Nisi ab sint. At officia praesentium voluptate omnis aliquam quia quasi ut." },
                    { 144, new DateTime(2021, 1, 9, 22, 24, 18, 532, DateTimeKind.Local).AddTicks(3515), 86, new DateTime(2021, 11, 4, 8, 21, 39, 96, DateTimeKind.Local).AddTicks(3339), new DateTime(2020, 7, 30, 5, 26, 47, 765, DateTimeKind.Local).AddTicks(1382), 3, 9, "Aliquam a repellendus ut non distinctio commodi id." },
                    { 151, new DateTime(2021, 1, 6, 22, 58, 29, 93, DateTimeKind.Local).AddTicks(4519), 130, new DateTime(2021, 4, 7, 18, 14, 8, 985, DateTimeKind.Local).AddTicks(5417), new DateTime(2021, 1, 25, 5, 45, 38, 333, DateTimeKind.Local).AddTicks(2802), 1, 9, "Ea optio sequi at quisquam enim.\nEst non porro." },
                    { 147, new DateTime(2021, 1, 3, 5, 43, 2, 91, DateTimeKind.Local).AddTicks(1334), 126, new DateTime(2021, 8, 13, 7, 22, 6, 856, DateTimeKind.Local).AddTicks(3656), new DateTime(2020, 11, 19, 18, 41, 40, 190, DateTimeKind.Local).AddTicks(8073), 1, 99, "Suscipit eos saepe voluptatum suscipit ut tenetur dolore placeat qui. Nobis impedit et sed et qui omnis harum. At est eum ad aliquid at dolore. Excepturi sit quia voluptatibus non. Omnis voluptatem provident est nulla eos. Neque quia accusantium voluptate nam officiis." },
                    { 46, new DateTime(2020, 11, 25, 8, 29, 37, 567, DateTimeKind.Local).AddTicks(7817), 61, new DateTime(2021, 5, 1, 17, 16, 32, 930, DateTimeKind.Local).AddTicks(4604), new DateTime(2020, 10, 7, 1, 37, 57, 565, DateTimeKind.Local).AddTicks(2757), 1, 88, "Et voluptatem aut voluptates suscipit ipsam facere saepe consectetur minima. Dolor nihil sed quis assumenda. Ut tenetur quae eos." },
                    { 48, new DateTime(2020, 11, 18, 17, 30, 54, 665, DateTimeKind.Local).AddTicks(6998), 40, new DateTime(2021, 12, 2, 6, 11, 20, 667, DateTimeKind.Local).AddTicks(4544), new DateTime(2020, 11, 13, 20, 39, 21, 383, DateTimeKind.Local).AddTicks(6998), 1, 88, "Molestiae aliquam qui perferendis similique fuga fugit cupiditate.\nRerum nemo ut asperiores architecto voluptatem cupiditate.\nDolores nostrum aperiam." },
                    { 76, new DateTime(2021, 2, 8, 16, 17, 13, 381, DateTimeKind.Local).AddTicks(5152), 74, new DateTime(2021, 4, 22, 2, 12, 33, 896, DateTimeKind.Local).AddTicks(1367), new DateTime(2020, 4, 30, 13, 53, 52, 569, DateTimeKind.Local).AddTicks(5056), 5, 88, "Et incidunt ipsa eum. Omnis ab exercitationem perferendis et eligendi nesciunt eum. Omnis quo non. Eligendi aut laudantium. Est asperiores aut. Beatae nihil maiores et." },
                    { 112, new DateTime(2020, 3, 25, 23, 43, 14, 120, DateTimeKind.Local).AddTicks(4430), 55, new DateTime(2021, 9, 23, 21, 4, 10, 687, DateTimeKind.Local).AddTicks(6379), new DateTime(2020, 12, 27, 4, 41, 52, 753, DateTimeKind.Local).AddTicks(157), 5, 88, "Quasi et et.\nAb neque sit voluptatem non enim autem qui dolores.\nSit minus mollitia voluptate.\nAnimi perferendis sed dicta at pariatur nam mollitia qui." },
                    { 121, new DateTime(2021, 1, 9, 7, 48, 25, 116, DateTimeKind.Local).AddTicks(3829), 124, new DateTime(2021, 5, 1, 3, 38, 17, 387, DateTimeKind.Local).AddTicks(5279), new DateTime(2021, 2, 7, 5, 30, 4, 816, DateTimeKind.Local).AddTicks(2815), 3, 88, "Iure aperiam sint eaque veritatis qui rem enim." },
                    { 197, new DateTime(2020, 7, 17, 8, 15, 53, 785, DateTimeKind.Local).AddTicks(6778), 75, new DateTime(2021, 11, 4, 18, 39, 10, 237, DateTimeKind.Local).AddTicks(2587), new DateTime(2020, 10, 23, 7, 32, 38, 306, DateTimeKind.Local).AddTicks(4593), 3, 88, "Et deserunt maiores aut in a autem est.\nNobis debitis reprehenderit libero ut voluptatem.\nConsectetur est nulla." },
                    { 40, new DateTime(2020, 5, 25, 20, 12, 21, 583, DateTimeKind.Local).AddTicks(1801), 100, new DateTime(2022, 2, 6, 13, 29, 58, 845, DateTimeKind.Local).AddTicks(1284), new DateTime(2020, 9, 16, 12, 38, 46, 933, DateTimeKind.Local).AddTicks(371), 1, 95, "numquam" },
                    { 66, new DateTime(2020, 8, 9, 10, 59, 35, 108, DateTimeKind.Local).AddTicks(6431), 23, new DateTime(2021, 10, 22, 1, 18, 6, 874, DateTimeKind.Local).AddTicks(6955), new DateTime(2020, 12, 17, 22, 0, 3, 565, DateTimeKind.Local).AddTicks(127), 2, 95, "Fuga saepe debitis veniam vitae." },
                    { 98, new DateTime(2021, 3, 17, 5, 28, 40, 53, DateTimeKind.Local).AddTicks(8519), 128, new DateTime(2022, 1, 31, 1, 59, 20, 624, DateTimeKind.Local).AddTicks(6901), new DateTime(2020, 8, 21, 5, 52, 24, 742, DateTimeKind.Local).AddTicks(2051), 2, 95, "Necessitatibus et quam perferendis." },
                    { 93, new DateTime(2020, 5, 20, 13, 10, 57, 159, DateTimeKind.Local).AddTicks(5959), 12, new DateTime(2021, 7, 30, 3, 33, 39, 328, DateTimeKind.Local).AddTicks(8782), new DateTime(2020, 8, 23, 4, 42, 52, 535, DateTimeKind.Local).AddTicks(1571), 4, 13, "Quo iusto et.\nOdit est voluptas minus quis rerum dolores assumenda.\nCumque et et neque quis mollitia magnam.\nQuia officia in sunt labore enim eos adipisci.\nIusto velit minima eveniet non distinctio suscipit rem consectetur." },
                    { 116, new DateTime(2020, 9, 8, 2, 23, 41, 439, DateTimeKind.Local).AddTicks(312), 104, new DateTime(2021, 10, 19, 1, 47, 25, 159, DateTimeKind.Local).AddTicks(6744), new DateTime(2020, 8, 13, 15, 31, 15, 735, DateTimeKind.Local).AddTicks(8343), 2, 13, "Omnis excepturi in." },
                    { 153, new DateTime(2021, 3, 21, 4, 28, 14, 917, DateTimeKind.Local).AddTicks(4233), 16, new DateTime(2021, 4, 2, 20, 6, 18, 7, DateTimeKind.Local).AddTicks(3072), new DateTime(2020, 7, 11, 1, 31, 21, 409, DateTimeKind.Local).AddTicks(3512), 2, 13, "Et accusantium id recusandae occaecati iste nihil molestiae. Velit aut et. Eligendi maxime quasi dolor alias nostrum sed autem. Cum suscipit et enim magnam neque exercitationem rem mollitia sint. Unde autem sit labore totam nihil. Facere cumque est et." },
                    { 109, new DateTime(2020, 7, 16, 18, 42, 33, 833, DateTimeKind.Local).AddTicks(7193), 42, new DateTime(2021, 5, 17, 5, 54, 39, 591, DateTimeKind.Local).AddTicks(9636), new DateTime(2020, 5, 23, 0, 44, 7, 642, DateTimeKind.Local).AddTicks(8392), 4, 50, "aspernatur" },
                    { 27, new DateTime(2021, 2, 24, 20, 2, 46, 789, DateTimeKind.Local).AddTicks(653), 112, new DateTime(2021, 8, 15, 1, 25, 9, 616, DateTimeKind.Local).AddTicks(893), new DateTime(2020, 8, 28, 0, 18, 43, 759, DateTimeKind.Local).AddTicks(3697), 5, 18, "Quia et nemo enim est aliquam ipsam.\nSed qui dolorem corrupti qui.\nSuscipit quae at rerum est dolores et odit odio exercitationem.\nVoluptate cupiditate rem eius consectetur est alias quia neque.\nRerum aut id nulla qui a rerum.\nQui non facilis qui." },
                    { 72, new DateTime(2020, 11, 24, 23, 58, 37, 29, DateTimeKind.Local).AddTicks(9506), 53, new DateTime(2022, 3, 3, 13, 42, 46, 127, DateTimeKind.Local).AddTicks(2472), new DateTime(2021, 3, 16, 17, 51, 4, 171, DateTimeKind.Local).AddTicks(1242), 2, 50, "Optio eos ut illum quas quia corporis quia corrupti minus." },
                    { 173, new DateTime(2020, 11, 21, 2, 4, 2, 92, DateTimeKind.Local).AddTicks(3262), 141, new DateTime(2021, 11, 6, 5, 31, 52, 184, DateTimeKind.Local).AddTicks(2247), new DateTime(2020, 12, 10, 12, 42, 37, 779, DateTimeKind.Local).AddTicks(9950), 4, 98, "Est quo eligendi. Eaque ratione et quibusdam facilis magnam deleniti amet eligendi. Eos ea autem qui eos sit porro. Dicta esse illo nihil. Et voluptatem adipisci debitis expedita. Itaque ratione alias aperiam quidem." },
                    { 140, new DateTime(2020, 4, 18, 2, 0, 35, 846, DateTimeKind.Local).AddTicks(6105), 7, new DateTime(2021, 9, 4, 7, 30, 18, 314, DateTimeKind.Local).AddTicks(7444), new DateTime(2020, 4, 11, 18, 21, 19, 458, DateTimeKind.Local).AddTicks(6304), 4, 18, "veritatis" },
                    { 150, new DateTime(2020, 6, 29, 12, 1, 28, 758, DateTimeKind.Local).AddTicks(7223), 52, new DateTime(2021, 8, 8, 14, 50, 51, 289, DateTimeKind.Local).AddTicks(8132), new DateTime(2020, 9, 3, 1, 10, 7, 617, DateTimeKind.Local).AddTicks(9594), 3, 18, "Expedita est modi praesentium molestiae quidem aut vel et quia." },
                    { 170, new DateTime(2020, 11, 12, 23, 23, 40, 385, DateTimeKind.Local).AddTicks(572), 144, new DateTime(2022, 3, 11, 17, 49, 49, 694, DateTimeKind.Local).AddTicks(7497), new DateTime(2020, 7, 21, 8, 4, 36, 444, DateTimeKind.Local).AddTicks(2667), 1, 18, "Magni debitis eum similique eos ducimus omnis itaque consequatur." },
                    { 26, new DateTime(2020, 11, 30, 12, 12, 59, 63, DateTimeKind.Local).AddTicks(6686), 67, new DateTime(2022, 2, 17, 16, 32, 59, 120, DateTimeKind.Local).AddTicks(9722), new DateTime(2021, 3, 4, 23, 18, 21, 960, DateTimeKind.Local).AddTicks(2829), 1, 52, "Ad nemo veniam sed aliquid dolores." },
                    { 33, new DateTime(2020, 4, 13, 4, 13, 3, 66, DateTimeKind.Local).AddTicks(7131), 120, new DateTime(2022, 3, 21, 11, 51, 2, 686, DateTimeKind.Local).AddTicks(7812), new DateTime(2020, 7, 9, 12, 30, 34, 997, DateTimeKind.Local).AddTicks(3884), 1, 52, "Fuga rerum qui deleniti qui ab aliquam alias." },
                    { 9, new DateTime(2020, 6, 15, 5, 25, 5, 21, DateTimeKind.Local).AddTicks(5107), 109, new DateTime(2022, 2, 9, 14, 37, 45, 873, DateTimeKind.Local).AddTicks(3304), new DateTime(2020, 10, 1, 21, 13, 6, 620, DateTimeKind.Local).AddTicks(8373), 1, 90, "Earum autem non voluptas velit ullam quisquam laboriosam.\nReprehenderit iste dicta saepe dolor sunt.\nCum et ut deserunt ipsam quibusdam doloremque.\nRerum quis qui sapiente voluptatibus ducimus." },
                    { 12, new DateTime(2021, 3, 5, 12, 50, 39, 174, DateTimeKind.Local).AddTicks(584), 52, new DateTime(2021, 10, 17, 14, 0, 31, 928, DateTimeKind.Local).AddTicks(7535), new DateTime(2020, 12, 12, 23, 0, 31, 298, DateTimeKind.Local).AddTicks(5136), 4, 90, "aliquam" },
                    { 45, new DateTime(2020, 10, 29, 22, 41, 52, 148, DateTimeKind.Local).AddTicks(7443), 104, new DateTime(2021, 8, 6, 22, 8, 20, 182, DateTimeKind.Local).AddTicks(9200), new DateTime(2020, 9, 27, 14, 57, 55, 111, DateTimeKind.Local).AddTicks(9949), 4, 90, "Animi officia molestias minus molestiae dolore. Autem debitis minima voluptate ullam optio suscipit pariatur at quia. Cum consectetur perspiciatis voluptate enim. Iste modi quo sint. Libero recusandae blanditiis. Iste perferendis iure placeat assumenda." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 131, new DateTime(2020, 12, 31, 4, 16, 51, 608, DateTimeKind.Local).AddTicks(6200), 134, new DateTime(2022, 1, 22, 12, 4, 10, 453, DateTimeKind.Local).AddTicks(9822), new DateTime(2020, 7, 31, 1, 12, 6, 766, DateTimeKind.Local).AddTicks(1504), 3, 65, "Eum consequatur amet quo.\nDignissimos illum aspernatur autem suscipit.\nAt quae quam officiis iusto quibusdam." },
                    { 139, new DateTime(2020, 7, 21, 11, 14, 51, 915, DateTimeKind.Local).AddTicks(9582), 90, new DateTime(2021, 7, 20, 23, 39, 53, 164, DateTimeKind.Local).AddTicks(6515), new DateTime(2021, 1, 11, 5, 35, 34, 772, DateTimeKind.Local).AddTicks(1760), 5, 65, "Corrupti laudantium nam fugit veritatis qui quia numquam.\nNemo facere eveniet id alias adipisci voluptatem non quia ab.\nInventore nostrum eos quasi autem vitae placeat.\nVeniam aperiam vero nihil quidem.\nMagnam iusto illum magnam dolores molestiae natus quo tempore recusandae.\nReiciendis distinctio voluptates temporibus ratione doloremque minus atque enim." },
                    { 16, new DateTime(2020, 9, 22, 10, 11, 30, 14, DateTimeKind.Local).AddTicks(5315), 4, new DateTime(2021, 9, 8, 21, 36, 37, 687, DateTimeKind.Local).AddTicks(5065), new DateTime(2020, 5, 29, 16, 45, 6, 753, DateTimeKind.Local).AddTicks(1544), 5, 29, "Id eveniet in impedit." },
                    { 49, new DateTime(2021, 1, 21, 21, 18, 24, 639, DateTimeKind.Local).AddTicks(6417), 125, new DateTime(2021, 7, 1, 23, 47, 41, 777, DateTimeKind.Local).AddTicks(4700), new DateTime(2020, 10, 11, 2, 1, 33, 26, DateTimeKind.Local).AddTicks(9288), 2, 29, "molestiae" },
                    { 103, new DateTime(2020, 10, 10, 1, 35, 57, 185, DateTimeKind.Local).AddTicks(6264), 17, new DateTime(2022, 1, 1, 18, 15, 8, 557, DateTimeKind.Local).AddTicks(4858), new DateTime(2020, 5, 19, 0, 34, 16, 484, DateTimeKind.Local).AddTicks(8395), 1, 29, "sapiente" },
                    { 136, new DateTime(2020, 6, 5, 17, 7, 22, 720, DateTimeKind.Local).AddTicks(5451), 142, new DateTime(2022, 3, 19, 10, 47, 21, 168, DateTimeKind.Local).AddTicks(7423), new DateTime(2020, 10, 7, 1, 32, 16, 800, DateTimeKind.Local).AddTicks(6233), 3, 29, "Sit accusantium ab ea similique.\nCommodi ipsum placeat quod minus aut tempora blanditiis eveniet.\nEnim excepturi aliquam sint.\nDicta enim blanditiis rerum sit nemo porro et.\nAliquam consequatur velit deleniti sunt ut in quasi doloribus.\nMagnam quod aspernatur aut saepe id." },
                    { 178, new DateTime(2020, 4, 7, 3, 50, 7, 739, DateTimeKind.Local).AddTicks(7769), 140, new DateTime(2021, 8, 11, 14, 27, 29, 194, DateTimeKind.Local).AddTicks(3515), new DateTime(2020, 10, 18, 0, 51, 2, 947, DateTimeKind.Local).AddTicks(4014), 5, 29, "Repellendus ab eum. Cum vero enim quo. Dolorem et provident ab animi necessitatibus ipsa numquam eligendi. Unde veritatis nobis ut est exercitationem doloremque ut provident adipisci." },
                    { 2, new DateTime(2020, 3, 29, 17, 53, 41, 449, DateTimeKind.Local).AddTicks(60), 27, new DateTime(2021, 8, 23, 3, 45, 49, 702, DateTimeKind.Local).AddTicks(8447), new DateTime(2021, 3, 12, 2, 37, 35, 952, DateTimeKind.Local).AddTicks(8855), 4, 98, "Officia ut exercitationem sit ut iusto voluptatem earum. Expedita occaecati et distinctio et praesentium amet. Necessitatibus dolore quia inventore aut voluptatem sed ex omnis. Aut aut nulla et veniam totam nihil sit et unde." },
                    { 20, new DateTime(2021, 2, 19, 5, 43, 41, 53, DateTimeKind.Local).AddTicks(3332), 51, new DateTime(2021, 3, 29, 1, 5, 15, 11, DateTimeKind.Local).AddTicks(5377), new DateTime(2020, 6, 16, 2, 29, 45, 577, DateTimeKind.Local).AddTicks(1543), 1, 98, "Quia dolorem est sed magni labore ut eligendi error adipisci.\nMaxime occaecati iusto sed omnis non aliquid.\nQui officia earum hic laboriosam." },
                    { 30, new DateTime(2020, 12, 24, 7, 15, 24, 512, DateTimeKind.Local).AddTicks(1692), 43, new DateTime(2021, 10, 15, 4, 7, 29, 750, DateTimeKind.Local).AddTicks(1504), new DateTime(2020, 10, 26, 7, 6, 40, 101, DateTimeKind.Local).AddTicks(9411), 2, 98, "Qui qui molestiae dolor accusamus rerum rem totam sapiente dicta.\nVoluptate fugit aut labore iusto impedit commodi.\nNam officiis quia quos eius.\nEt reiciendis nesciunt debitis." },
                    { 70, new DateTime(2020, 9, 9, 2, 7, 59, 23, DateTimeKind.Local).AddTicks(9815), 121, new DateTime(2021, 7, 4, 10, 25, 43, 826, DateTimeKind.Local).AddTicks(5699), new DateTime(2020, 4, 14, 17, 59, 40, 184, DateTimeKind.Local).AddTicks(8606), 3, 98, "In vero molestiae voluptas ipsam." },
                    { 125, new DateTime(2020, 10, 23, 6, 59, 42, 997, DateTimeKind.Local).AddTicks(2668), 42, new DateTime(2021, 7, 17, 13, 36, 45, 119, DateTimeKind.Local).AddTicks(5730), new DateTime(2020, 8, 13, 9, 58, 44, 610, DateTimeKind.Local).AddTicks(9926), 2, 98, "Quis sed dolores accusamus. Consequatur soluta et sunt tempore iusto quae eum. Voluptas occaecati consequatur recusandae corrupti a veritatis at recusandae et. Excepturi eos eum cumque adipisci ex autem blanditiis. Molestiae hic nemo labore in." },
                    { 142, new DateTime(2020, 8, 31, 21, 26, 54, 689, DateTimeKind.Local).AddTicks(4330), 119, new DateTime(2021, 10, 26, 11, 50, 37, 429, DateTimeKind.Local).AddTicks(959), new DateTime(2020, 12, 28, 18, 20, 58, 862, DateTimeKind.Local).AddTicks(4752), 2, 98, "Voluptas in quia ullam nisi." },
                    { 177, new DateTime(2021, 2, 16, 6, 14, 53, 19, DateTimeKind.Local).AddTicks(3184), 63, new DateTime(2021, 6, 15, 10, 25, 25, 649, DateTimeKind.Local).AddTicks(8056), new DateTime(2020, 12, 16, 16, 39, 54, 596, DateTimeKind.Local).AddTicks(6164), 5, 98, "Veritatis fuga suscipit consequuntur voluptatem quidem non illum." },
                    { 78, new DateTime(2021, 3, 14, 7, 15, 13, 304, DateTimeKind.Local).AddTicks(7932), 50, new DateTime(2021, 7, 12, 1, 15, 21, 224, DateTimeKind.Local).AddTicks(1615), new DateTime(2021, 2, 4, 19, 14, 0, 621, DateTimeKind.Local).AddTicks(5279), 3, 7, "Reiciendis at sed libero quia.\nDeleniti eum temporibus qui dolorum est non similique voluptatem.\nMinus vitae minus autem totam consequatur.\nDicta aut ut aspernatur quis illum qui tempora." },
                    { 163, new DateTime(2020, 7, 16, 7, 12, 2, 676, DateTimeKind.Local).AddTicks(1830), 70, new DateTime(2021, 11, 22, 6, 53, 37, 321, DateTimeKind.Local).AddTicks(7764), new DateTime(2020, 8, 16, 8, 47, 41, 448, DateTimeKind.Local).AddTicks(4409), 4, 19, "Voluptatem repellendus cum aut corporis expedita.\nVitae fugiat laborum qui dolorem quo praesentium unde atque inventore.\nEt consequuntur nesciunt qui minus tempore laborum reprehenderit ad.\nVoluptates culpa id id modi nulla reiciendis deleniti architecto deleniti." },
                    { 85, new DateTime(2020, 12, 2, 17, 1, 12, 560, DateTimeKind.Local).AddTicks(4866), 42, new DateTime(2021, 6, 8, 12, 27, 13, 461, DateTimeKind.Local).AddTicks(9250), new DateTime(2020, 11, 3, 15, 48, 38, 332, DateTimeKind.Local).AddTicks(9715), 2, 19, "Necessitatibus sed perspiciatis omnis qui sequi voluptate et rerum.\nTenetur consectetur minima impedit dolor sed alias quia aspernatur.\nVoluptatum rerum eaque voluptas repellat dolores.\nAdipisci et consequuntur voluptas et." },
                    { 171, new DateTime(2020, 12, 4, 22, 28, 26, 759, DateTimeKind.Local).AddTicks(5517), 108, new DateTime(2022, 2, 5, 10, 43, 9, 589, DateTimeKind.Local).AddTicks(7146), new DateTime(2020, 4, 7, 20, 26, 16, 719, DateTimeKind.Local).AddTicks(7283), 3, 63, "dignissimos" },
                    { 176, new DateTime(2020, 10, 30, 7, 43, 56, 421, DateTimeKind.Local).AddTicks(1314), 73, new DateTime(2021, 8, 8, 22, 32, 20, 755, DateTimeKind.Local).AddTicks(6967), new DateTime(2020, 11, 10, 13, 6, 4, 733, DateTimeKind.Local).AddTicks(456), 2, 63, "Exercitationem dolores tempora facilis minima.\nNam quasi voluptas porro error quibusdam voluptates provident voluptas.\nSuscipit officiis facere molestias.\nAmet impedit quia illum aut consequuntur aut omnis laborum voluptates." },
                    { 6, new DateTime(2020, 8, 15, 21, 1, 33, 655, DateTimeKind.Local).AddTicks(4088), 49, new DateTime(2021, 9, 6, 2, 58, 23, 176, DateTimeKind.Local).AddTicks(9170), new DateTime(2020, 7, 17, 9, 54, 30, 67, DateTimeKind.Local).AddTicks(9377), 5, 3, "Quis nulla est. Consequuntur et possimus qui. Itaque officia iure pariatur." },
                    { 198, new DateTime(2020, 4, 10, 22, 42, 3, 988, DateTimeKind.Local).AddTicks(5151), 144, new DateTime(2021, 10, 30, 12, 30, 56, 603, DateTimeKind.Local).AddTicks(9688), new DateTime(2020, 9, 17, 6, 24, 12, 475, DateTimeKind.Local).AddTicks(7117), 3, 3, "Quaerat eos qui fugiat eum tempora id nam blanditiis.\nSed quis quod et nam molestiae quia eos maiores.\nIllo ipsum a dolorem eveniet.\nNostrum sit aspernatur sunt nisi rerum ea." },
                    { 34, new DateTime(2020, 5, 13, 15, 22, 25, 944, DateTimeKind.Local).AddTicks(6627), 3, new DateTime(2021, 10, 3, 5, 10, 55, 805, DateTimeKind.Local).AddTicks(568), new DateTime(2020, 8, 26, 18, 13, 45, 976, DateTimeKind.Local).AddTicks(162), 4, 85, "Fuga nihil et eligendi quam." },
                    { 88, new DateTime(2020, 5, 2, 21, 24, 9, 521, DateTimeKind.Local).AddTicks(94), 111, new DateTime(2021, 12, 29, 14, 19, 13, 895, DateTimeKind.Local).AddTicks(9887), new DateTime(2020, 8, 9, 22, 50, 21, 328, DateTimeKind.Local).AddTicks(2874), 2, 85, "Impedit facere est incidunt ut dolore.\nVoluptas nihil at et quas ut cum reiciendis et consequatur.\nRepudiandae tempora id itaque voluptatibus." },
                    { 82, new DateTime(2020, 12, 7, 10, 35, 49, 11, DateTimeKind.Local).AddTicks(2814), 118, new DateTime(2021, 10, 6, 11, 18, 38, 361, DateTimeKind.Local).AddTicks(6284), new DateTime(2020, 12, 16, 5, 52, 20, 462, DateTimeKind.Local).AddTicks(2930), 1, 68, "Numquam itaque dignissimos ea et vel laboriosam.\nCommodi praesentium soluta aut at.\nSit aspernatur omnis dolorem ut consequuntur ipsam nesciunt.\nQuidem dolor similique labore est at.\nAlias aperiam aliquid rerum vel culpa dolor debitis.\nRerum ut repellat." },
                    { 106, new DateTime(2020, 6, 27, 9, 44, 17, 433, DateTimeKind.Local).AddTicks(9669), 75, new DateTime(2021, 10, 13, 19, 49, 2, 439, DateTimeKind.Local).AddTicks(5115), new DateTime(2020, 9, 8, 10, 49, 5, 233, DateTimeKind.Local).AddTicks(4036), 1, 68, "Voluptatibus incidunt reiciendis aspernatur qui." },
                    { 141, new DateTime(2020, 4, 4, 11, 10, 37, 24, DateTimeKind.Local).AddTicks(4583), 97, new DateTime(2021, 4, 4, 5, 37, 15, 88, DateTimeKind.Local).AddTicks(8938), new DateTime(2021, 1, 23, 12, 30, 44, 9, DateTimeKind.Local).AddTicks(7388), 1, 68, "Minima cum quia sit nisi dolorum sed.\nQui quam quo totam eos.\nConsequuntur modi commodi.\nInventore aut eius molestias.\nAt dolores dolor quisquam atque est porro." },
                    { 149, new DateTime(2020, 12, 30, 13, 42, 58, 435, DateTimeKind.Local).AddTicks(8540), 76, new DateTime(2021, 8, 2, 0, 24, 15, 541, DateTimeKind.Local).AddTicks(8988), new DateTime(2020, 10, 30, 12, 33, 37, 51, DateTimeKind.Local).AddTicks(7522), 3, 68, "Ullam necessitatibus sint sed numquam sint. Ratione eligendi voluptas aut et nobis. Accusantium reiciendis quia nisi ea temporibus quo quia beatae quo. Deleniti commodi fugit aut et facere non eligendi consectetur in. Dolorem enim fuga ab cumque." },
                    { 175, new DateTime(2020, 7, 1, 10, 32, 8, 969, DateTimeKind.Local).AddTicks(1213), 57, new DateTime(2021, 10, 27, 4, 54, 52, 743, DateTimeKind.Local).AddTicks(9001), new DateTime(2020, 8, 6, 12, 8, 39, 650, DateTimeKind.Local).AddTicks(1736), 5, 68, "Vel et quibusdam nostrum facilis.\nAutem dolorem voluptas possimus in dolores.\nId fugit at impedit omnis.\nAtque earum itaque et.\nVoluptate blanditiis quod velit consequatur." },
                    { 64, new DateTime(2020, 11, 12, 18, 13, 33, 382, DateTimeKind.Local).AddTicks(9976), 137, new DateTime(2022, 3, 17, 1, 45, 33, 429, DateTimeKind.Local).AddTicks(1162), new DateTime(2021, 3, 13, 20, 48, 56, 541, DateTimeKind.Local).AddTicks(5692), 4, 11, "Vitae ipsam corrupti laboriosam." },
                    { 122, new DateTime(2020, 12, 2, 8, 29, 19, 450, DateTimeKind.Local).AddTicks(3413), 85, new DateTime(2021, 3, 29, 21, 51, 33, 262, DateTimeKind.Local).AddTicks(7578), new DateTime(2020, 10, 23, 2, 16, 58, 776, DateTimeKind.Local).AddTicks(973), 3, 11, "deserunt" },
                    { 129, new DateTime(2020, 7, 26, 12, 49, 8, 302, DateTimeKind.Local).AddTicks(4375), 2, new DateTime(2021, 12, 28, 5, 59, 21, 410, DateTimeKind.Local).AddTicks(6496), new DateTime(2020, 10, 17, 3, 37, 33, 227, DateTimeKind.Local).AddTicks(6224), 2, 11, "Et quis ex suscipit recusandae veniam ipsum molestiae.\nVoluptatem sint quaerat deleniti in non quo aliquid qui.\nVelit magni aliquam sit.\nEst velit ea est qui facilis et." },
                    { 196, new DateTime(2020, 7, 28, 11, 53, 39, 257, DateTimeKind.Local).AddTicks(2476), 32, new DateTime(2021, 4, 19, 17, 52, 51, 543, DateTimeKind.Local).AddTicks(9058), new DateTime(2021, 1, 17, 5, 50, 9, 241, DateTimeKind.Local).AddTicks(3206), 4, 11, "Recusandae sit provident enim dolores fugit dicta aliquam." },
                    { 159, new DateTime(2020, 11, 1, 7, 4, 36, 721, DateTimeKind.Local).AddTicks(4421), 56, new DateTime(2021, 8, 4, 18, 33, 43, 733, DateTimeKind.Local).AddTicks(2911), new DateTime(2020, 7, 17, 17, 57, 15, 553, DateTimeKind.Local).AddTicks(4847), 1, 2, "Laboriosam mollitia voluptates ullam earum et.\nNesciunt minima et laudantium aspernatur dignissimos et et ipsa inventore.\nAut consequatur odit accusamus odit a voluptatem quia ullam.\nCommodi cupiditate libero qui doloribus aut." },
                    { 24, new DateTime(2020, 12, 31, 20, 29, 33, 988, DateTimeKind.Local).AddTicks(2234), 29, new DateTime(2021, 7, 20, 21, 42, 13, 815, DateTimeKind.Local).AddTicks(6415), new DateTime(2020, 4, 5, 4, 33, 43, 306, DateTimeKind.Local).AddTicks(7159), 4, 69, "eos" },
                    { 29, new DateTime(2020, 9, 8, 16, 2, 27, 585, DateTimeKind.Local).AddTicks(1933), 45, new DateTime(2022, 3, 3, 1, 3, 24, 959, DateTimeKind.Local).AddTicks(7568), new DateTime(2020, 12, 5, 19, 1, 29, 188, DateTimeKind.Local).AddTicks(1332), 1, 69, "Voluptate optio architecto dolore ipsa qui." },
                    { 91, new DateTime(2021, 2, 25, 8, 59, 18, 351, DateTimeKind.Local).AddTicks(5585), 15, new DateTime(2021, 8, 5, 1, 35, 16, 852, DateTimeKind.Local).AddTicks(8463), new DateTime(2020, 4, 29, 0, 47, 48, 156, DateTimeKind.Local).AddTicks(4046), 1, 69, "Nesciunt illum repudiandae." },
                    { 7, new DateTime(2020, 9, 22, 19, 35, 58, 717, DateTimeKind.Local).AddTicks(2112), 32, new DateTime(2021, 11, 16, 12, 38, 28, 424, DateTimeKind.Local).AddTicks(2116), new DateTime(2020, 12, 8, 13, 29, 18, 202, DateTimeKind.Local).AddTicks(5171), 5, 30, "Consectetur et cupiditate amet eos unde quasi et quidem et. Blanditiis non consequuntur. Molestiae eos quo qui iusto." },
                    { 60, new DateTime(2021, 1, 27, 9, 11, 46, 620, DateTimeKind.Local).AddTicks(6982), 63, new DateTime(2021, 5, 9, 6, 44, 56, 169, DateTimeKind.Local).AddTicks(2351), new DateTime(2021, 3, 16, 9, 48, 43, 433, DateTimeKind.Local).AddTicks(222), 2, 30, "Facere sint sapiente officiis unde in inventore labore." },
                    { 157, new DateTime(2021, 2, 27, 5, 18, 35, 266, DateTimeKind.Local).AddTicks(9961), 67, new DateTime(2021, 9, 23, 10, 49, 27, 944, DateTimeKind.Local).AddTicks(430), new DateTime(2021, 2, 23, 5, 55, 1, 691, DateTimeKind.Local).AddTicks(9946), 2, 63, "reiciendis" },
                    { 71, new DateTime(2020, 10, 20, 14, 33, 15, 276, DateTimeKind.Local).AddTicks(633), 51, new DateTime(2021, 9, 27, 16, 33, 45, 384, DateTimeKind.Local).AddTicks(5551), new DateTime(2020, 10, 31, 15, 38, 20, 596, DateTimeKind.Local).AddTicks(9895), 5, 49, "iste" },
                    { 148, new DateTime(2021, 2, 5, 21, 54, 6, 117, DateTimeKind.Local).AddTicks(982), 96, new DateTime(2021, 3, 31, 18, 56, 23, 542, DateTimeKind.Local).AddTicks(9480), new DateTime(2020, 9, 29, 9, 39, 28, 887, DateTimeKind.Local).AddTicks(1576), 3, 63, "Nobis nemo dolorum." },
                    { 188, new DateTime(2020, 5, 12, 19, 53, 58, 707, DateTimeKind.Local).AddTicks(2146), 120, new DateTime(2021, 7, 14, 9, 40, 7, 404, DateTimeKind.Local).AddTicks(235), new DateTime(2020, 9, 9, 1, 2, 55, 847, DateTimeKind.Local).AddTicks(3557), 3, 1, "Aut numquam sunt est." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 37, new DateTime(2020, 7, 3, 15, 52, 31, 845, DateTimeKind.Local).AddTicks(7570), 66, new DateTime(2021, 7, 26, 16, 42, 10, 565, DateTimeKind.Local).AddTicks(2340), new DateTime(2021, 1, 29, 13, 26, 17, 477, DateTimeKind.Local).AddTicks(9390), 5, 43, "Praesentium ut et alias sit nihil dolorum quidem adipisci. Hic vel deleniti assumenda eaque nulla. Recusandae ex voluptatem suscipit sequi voluptatem dolorem." },
                    { 63, new DateTime(2021, 1, 13, 6, 46, 27, 636, DateTimeKind.Local).AddTicks(3810), 34, new DateTime(2021, 12, 29, 10, 25, 43, 228, DateTimeKind.Local).AddTicks(4868), new DateTime(2021, 2, 20, 18, 3, 3, 581, DateTimeKind.Local).AddTicks(7308), 1, 43, "Perspiciatis aut aliquam in." },
                    { 90, new DateTime(2020, 6, 15, 10, 27, 34, 699, DateTimeKind.Local).AddTicks(3965), 75, new DateTime(2021, 11, 1, 21, 3, 12, 786, DateTimeKind.Local).AddTicks(5447), new DateTime(2020, 7, 5, 0, 39, 37, 257, DateTimeKind.Local).AddTicks(8590), 1, 43, "Rem quasi sapiente eum quis libero dicta tempore assumenda." },
                    { 95, new DateTime(2020, 9, 7, 15, 12, 18, 286, DateTimeKind.Local).AddTicks(1240), 134, new DateTime(2021, 11, 24, 6, 45, 42, 55, DateTimeKind.Local).AddTicks(6564), new DateTime(2020, 12, 27, 9, 34, 1, 160, DateTimeKind.Local).AddTicks(1644), 3, 43, "Nulla doloremque dicta accusamus laboriosam cumque ut.\nMolestias dicta corrupti tempore quia quia minima.\nDolor possimus libero suscipit et voluptate nobis esse." },
                    { 22, new DateTime(2020, 11, 7, 9, 40, 49, 374, DateTimeKind.Local).AddTicks(8422), 58, new DateTime(2021, 7, 8, 14, 30, 7, 694, DateTimeKind.Local).AddTicks(632), new DateTime(2020, 9, 4, 21, 38, 57, 172, DateTimeKind.Local).AddTicks(564), 3, 87, "Voluptas et nisi minus officiis qui maxime." },
                    { 180, new DateTime(2021, 3, 7, 3, 44, 32, 803, DateTimeKind.Local).AddTicks(2823), 34, new DateTime(2021, 9, 26, 21, 21, 37, 362, DateTimeKind.Local).AddTicks(4982), new DateTime(2021, 2, 15, 3, 18, 3, 814, DateTimeKind.Local).AddTicks(7196), 4, 87, "Veniam ab nam laboriosam autem minus ad explicabo eveniet." },
                    { 54, new DateTime(2020, 7, 8, 7, 28, 22, 340, DateTimeKind.Local).AddTicks(5719), 3, new DateTime(2021, 12, 25, 13, 55, 0, 575, DateTimeKind.Local).AddTicks(2509), new DateTime(2021, 1, 16, 8, 16, 6, 14, DateTimeKind.Local).AddTicks(8850), 3, 25, "Repudiandae placeat voluptatum. Illo voluptas tempora laudantium. Veritatis nihil eum sapiente aperiam. Corporis quas ut alias repellendus blanditiis et." },
                    { 105, new DateTime(2020, 5, 2, 5, 37, 27, 77, DateTimeKind.Local).AddTicks(2138), 62, new DateTime(2021, 5, 26, 20, 47, 2, 201, DateTimeKind.Local).AddTicks(1418), new DateTime(2020, 11, 7, 10, 50, 16, 889, DateTimeKind.Local).AddTicks(8004), 2, 25, "Sint qui harum.\nConsectetur aut autem.\nRerum totam dolorem quam quod enim ipsa sint.\nRatione excepturi cum.\nOdio nulla dignissimos magni illum ut odit quis explicabo." },
                    { 113, new DateTime(2021, 2, 21, 13, 39, 51, 895, DateTimeKind.Local).AddTicks(9209), 132, new DateTime(2021, 11, 7, 18, 11, 25, 744, DateTimeKind.Local).AddTicks(6734), new DateTime(2020, 8, 23, 10, 5, 42, 468, DateTimeKind.Local).AddTicks(8928), 5, 25, "rerum" },
                    { 1, new DateTime(2021, 2, 21, 22, 32, 16, 50, DateTimeKind.Local).AddTicks(5423), 136, new DateTime(2022, 1, 15, 4, 21, 6, 323, DateTimeKind.Local).AddTicks(5186), new DateTime(2020, 4, 26, 7, 56, 3, 932, DateTimeKind.Local).AddTicks(1119), 2, 38, "consectetur" },
                    { 38, new DateTime(2021, 2, 7, 4, 9, 44, 299, DateTimeKind.Local).AddTicks(2869), 92, new DateTime(2021, 9, 28, 20, 12, 6, 355, DateTimeKind.Local).AddTicks(248), new DateTime(2020, 12, 25, 21, 59, 49, 705, DateTimeKind.Local).AddTicks(3617), 3, 38, "Rerum qui nulla officia sed voluptatem et est iste tempore. Quas sequi quae magni. Repellat architecto enim velit aut non nemo. Voluptatem minima amet commodi sit." },
                    { 99, new DateTime(2020, 9, 5, 5, 54, 7, 455, DateTimeKind.Local).AddTicks(4038), 95, new DateTime(2021, 12, 5, 21, 33, 51, 484, DateTimeKind.Local).AddTicks(659), new DateTime(2020, 5, 29, 5, 35, 29, 483, DateTimeKind.Local).AddTicks(1158), 4, 38, "Consequatur fugiat in mollitia." },
                    { 53, new DateTime(2020, 12, 11, 3, 15, 4, 498, DateTimeKind.Local).AddTicks(3215), 125, new DateTime(2022, 3, 12, 13, 56, 50, 819, DateTimeKind.Local).AddTicks(6802), new DateTime(2020, 10, 7, 6, 1, 6, 582, DateTimeKind.Local).AddTicks(4959), 3, 10, "Repellendus expedita et odio consectetur dolorum doloribus aut dignissimos illo." },
                    { 75, new DateTime(2021, 3, 23, 9, 50, 26, 157, DateTimeKind.Local).AddTicks(2584), 127, new DateTime(2021, 11, 15, 9, 38, 54, 675, DateTimeKind.Local).AddTicks(2395), new DateTime(2020, 9, 10, 6, 45, 48, 767, DateTimeKind.Local).AddTicks(2500), 1, 10, "voluptatem" },
                    { 83, new DateTime(2021, 1, 11, 1, 38, 43, 255, DateTimeKind.Local).AddTicks(5042), 123, new DateTime(2021, 8, 16, 10, 21, 38, 686, DateTimeKind.Local).AddTicks(2682), new DateTime(2021, 2, 16, 3, 43, 48, 259, DateTimeKind.Local).AddTicks(7840), 4, 10, "Voluptatem ut est enim illo. Consequatur dolor aliquid qui qui deleniti. Blanditiis est distinctio non voluptatem id voluptatem eveniet. Fuga eos voluptatem et." },
                    { 104, new DateTime(2020, 12, 26, 7, 30, 27, 6, DateTimeKind.Local).AddTicks(3614), 121, new DateTime(2021, 5, 29, 17, 34, 9, 134, DateTimeKind.Local).AddTicks(8806), new DateTime(2021, 3, 15, 17, 36, 36, 574, DateTimeKind.Local).AddTicks(4296), 2, 10, "Quibusdam cum quia nihil reiciendis." },
                    { 110, new DateTime(2020, 7, 19, 23, 52, 43, 320, DateTimeKind.Local).AddTicks(9947), 22, new DateTime(2021, 7, 27, 19, 55, 18, 166, DateTimeKind.Local).AddTicks(6802), new DateTime(2021, 3, 8, 17, 25, 42, 866, DateTimeKind.Local).AddTicks(93), 1, 10, "Rerum nesciunt aliquam sequi reiciendis corrupti a libero quibusdam. Et dolorem necessitatibus eum perferendis. Perspiciatis aut in." },
                    { 124, new DateTime(2021, 3, 9, 16, 54, 11, 134, DateTimeKind.Local).AddTicks(9138), 40, new DateTime(2021, 6, 27, 1, 57, 55, 310, DateTimeKind.Local).AddTicks(3046), new DateTime(2020, 7, 9, 9, 6, 32, 507, DateTimeKind.Local).AddTicks(111), 2, 10, "Et in architecto dolorem aliquam quisquam sint sapiente rem aut.\nDolore ullam eius unde ex asperiores omnis voluptas.\nSapiente nisi qui.\nQuia nihil quibusdam voluptatem odio odit eaque tempora.\nLabore commodi et qui commodi." },
                    { 8, new DateTime(2020, 9, 17, 23, 34, 38, 596, DateTimeKind.Local).AddTicks(3534), 10, new DateTime(2022, 2, 16, 17, 17, 3, 595, DateTimeKind.Local).AddTicks(1510), new DateTime(2020, 5, 30, 4, 1, 36, 383, DateTimeKind.Local).AddTicks(292), 3, 1, "amet" },
                    { 21, new DateTime(2021, 3, 17, 1, 10, 57, 851, DateTimeKind.Local).AddTicks(1349), 25, new DateTime(2021, 10, 29, 1, 14, 41, 870, DateTimeKind.Local).AddTicks(9692), new DateTime(2020, 8, 21, 11, 50, 22, 145, DateTimeKind.Local).AddTicks(4214), 1, 1, "Impedit expedita non sunt qui." },
                    { 94, new DateTime(2021, 2, 24, 21, 18, 41, 476, DateTimeKind.Local).AddTicks(505), 37, new DateTime(2021, 7, 13, 3, 53, 38, 327, DateTimeKind.Local).AddTicks(1788), new DateTime(2020, 10, 4, 19, 28, 28, 473, DateTimeKind.Local).AddTicks(7381), 5, 1, "cumque" },
                    { 96, new DateTime(2020, 12, 22, 9, 52, 24, 336, DateTimeKind.Local).AddTicks(8954), 118, new DateTime(2021, 9, 30, 6, 51, 6, 27, DateTimeKind.Local).AddTicks(4069), new DateTime(2020, 6, 9, 8, 27, 8, 136, DateTimeKind.Local).AddTicks(43), 1, 63, "Perferendis vel corporis iure quia quas aut.\nPraesentium tempore harum libero accusantium ut quaerat accusantium omnis.\nVoluptatem officiis maiores ad odio ut tempore voluptas aut.\nEst aut beatae.\nFacere explicabo nesciunt reprehenderit reiciendis corporis at." },
                    { 143, new DateTime(2020, 10, 28, 14, 37, 53, 932, DateTimeKind.Local).AddTicks(1853), 16, new DateTime(2021, 11, 21, 12, 55, 41, 375, DateTimeKind.Local).AddTicks(3087), new DateTime(2020, 7, 2, 1, 30, 45, 703, DateTimeKind.Local).AddTicks(1611), 1, 49, "Est est veniam assumenda nesciunt enim. Natus eveniet quisquam sunt soluta qui cum. Dolores magnam quasi et aut repudiandae. Doloribus et dolorem a dolorum ut. Omnis nesciunt ut qui sint rem eum ea voluptatibus eveniet. Minus voluptas cum." },
                    { 5, new DateTime(2020, 12, 27, 10, 40, 12, 228, DateTimeKind.Local).AddTicks(8073), 97, new DateTime(2022, 1, 12, 1, 56, 55, 79, DateTimeKind.Local).AddTicks(1632), new DateTime(2020, 10, 17, 0, 29, 45, 367, DateTimeKind.Local).AddTicks(1895), 5, 83, "mollitia" },
                    { 59, new DateTime(2020, 7, 19, 2, 51, 38, 987, DateTimeKind.Local).AddTicks(5453), 98, new DateTime(2021, 9, 15, 14, 48, 35, 861, DateTimeKind.Local).AddTicks(4271), new DateTime(2020, 11, 5, 17, 7, 48, 935, DateTimeKind.Local).AddTicks(5337), 2, 83, "Quia laudantium autem labore maiores perferendis odio voluptatem perspiciatis. Perspiciatis sapiente placeat aut. Voluptatem a ipsam et similique. In modi quia minus officiis." },
                    { 67, new DateTime(2020, 7, 11, 8, 33, 18, 362, DateTimeKind.Local).AddTicks(1805), 73, new DateTime(2022, 2, 21, 3, 21, 0, 90, DateTimeKind.Local).AddTicks(496), new DateTime(2020, 6, 1, 3, 52, 25, 243, DateTimeKind.Local).AddTicks(3684), 5, 6, "Eaque quas consectetur fuga asperiores." },
                    { 79, new DateTime(2021, 2, 23, 19, 59, 30, 37, DateTimeKind.Local).AddTicks(5135), 32, new DateTime(2021, 6, 21, 21, 3, 46, 266, DateTimeKind.Local).AddTicks(2149), new DateTime(2020, 7, 29, 0, 57, 40, 192, DateTimeKind.Local).AddTicks(3484), 2, 6, "facere" },
                    { 81, new DateTime(2020, 8, 15, 9, 23, 6, 655, DateTimeKind.Local).AddTicks(4029), 87, new DateTime(2021, 5, 28, 18, 48, 45, 368, DateTimeKind.Local).AddTicks(8673), new DateTime(2020, 6, 6, 18, 29, 27, 778, DateTimeKind.Local).AddTicks(5601), 1, 6, "autem" },
                    { 10, new DateTime(2021, 2, 19, 13, 3, 20, 534, DateTimeKind.Local).AddTicks(1195), 131, new DateTime(2022, 2, 25, 21, 58, 5, 305, DateTimeKind.Local).AddTicks(9166), new DateTime(2020, 3, 28, 3, 45, 38, 283, DateTimeKind.Local).AddTicks(3407), 3, 108, "odit" },
                    { 87, new DateTime(2020, 11, 4, 6, 7, 29, 19, DateTimeKind.Local).AddTicks(3487), 31, new DateTime(2021, 4, 10, 0, 28, 51, 133, DateTimeKind.Local).AddTicks(2130), new DateTime(2021, 1, 29, 15, 14, 54, 372, DateTimeKind.Local).AddTicks(121), 3, 14, "Sed et velit quam nesciunt laboriosam consequatur vitae cumque dolor. Vel non commodi sint provident voluptatem rerum saepe et et. Quidem et debitis atque ea. Enim quam et libero beatae ad eum fuga repudiandae." },
                    { 156, new DateTime(2020, 7, 21, 2, 4, 7, 76, DateTimeKind.Local).AddTicks(6736), 49, new DateTime(2021, 4, 10, 17, 54, 42, 922, DateTimeKind.Local).AddTicks(8047), new DateTime(2021, 1, 12, 21, 4, 34, 576, DateTimeKind.Local).AddTicks(6061), 2, 28, "commodi" },
                    { 68, new DateTime(2020, 5, 31, 3, 42, 18, 526, DateTimeKind.Local).AddTicks(3984), 89, new DateTime(2021, 7, 11, 10, 3, 24, 958, DateTimeKind.Local).AddTicks(7355), new DateTime(2020, 12, 23, 10, 45, 52, 928, DateTimeKind.Local).AddTicks(6194), 1, 26, "Vel porro sit maiores molestias facilis dolorem culpa. Iusto sed quaerat id. In omnis tempora dolores minus nobis rerum officiis quia." },
                    { 31, new DateTime(2021, 2, 10, 23, 41, 37, 404, DateTimeKind.Local).AddTicks(2544), 27, new DateTime(2021, 8, 30, 4, 23, 48, 918, DateTimeKind.Local).AddTicks(3466), new DateTime(2021, 1, 24, 9, 24, 8, 679, DateTimeKind.Local).AddTicks(8353), 3, 34, "Rerum esse sed itaque incidunt." },
                    { 86, new DateTime(2020, 4, 22, 4, 31, 48, 701, DateTimeKind.Local).AddTicks(8934), 115, new DateTime(2021, 5, 8, 10, 13, 8, 527, DateTimeKind.Local).AddTicks(7819), new DateTime(2021, 2, 10, 2, 4, 20, 620, DateTimeKind.Local).AddTicks(108), 1, 34, "modi" },
                    { 111, new DateTime(2020, 12, 6, 5, 2, 44, 490, DateTimeKind.Local).AddTicks(7804), 44, new DateTime(2021, 8, 17, 18, 20, 34, 379, DateTimeKind.Local).AddTicks(3005), new DateTime(2021, 2, 25, 4, 54, 48, 295, DateTimeKind.Local).AddTicks(3375), 2, 34, "rerum" },
                    { 119, new DateTime(2021, 1, 13, 5, 36, 3, 206, DateTimeKind.Local).AddTicks(3706), 111, new DateTime(2021, 4, 19, 1, 41, 58, 811, DateTimeKind.Local).AddTicks(7368), new DateTime(2020, 9, 27, 13, 12, 12, 622, DateTimeKind.Local).AddTicks(451), 3, 34, "Doloribus eius in ea quaerat quibusdam explicabo dolor." },
                    { 127, new DateTime(2020, 12, 2, 22, 39, 32, 648, DateTimeKind.Local).AddTicks(8435), 144, new DateTime(2021, 7, 24, 1, 0, 12, 11, DateTimeKind.Local).AddTicks(4056), new DateTime(2020, 11, 14, 20, 50, 40, 30, DateTimeKind.Local).AddTicks(7260), 5, 34, "Tempore pariatur eius.\nIpsam facilis officia unde dolores illum non magni provident quasi.\nMaxime culpa maiores suscipit enim." },
                    { 166, new DateTime(2020, 5, 19, 15, 34, 15, 62, DateTimeKind.Local).AddTicks(2580), 26, new DateTime(2021, 10, 22, 6, 39, 12, 914, DateTimeKind.Local).AddTicks(2266), new DateTime(2020, 4, 14, 20, 42, 3, 219, DateTimeKind.Local).AddTicks(5907), 1, 34, "et" },
                    { 179, new DateTime(2020, 9, 25, 1, 45, 42, 736, DateTimeKind.Local).AddTicks(1569), 4, new DateTime(2021, 12, 28, 16, 47, 37, 205, DateTimeKind.Local).AddTicks(1703), new DateTime(2020, 11, 3, 12, 16, 59, 4, DateTimeKind.Local).AddTicks(3616), 2, 34, "totam" },
                    { 41, new DateTime(2020, 4, 5, 20, 56, 20, 466, DateTimeKind.Local).AddTicks(946), 66, new DateTime(2021, 9, 24, 15, 0, 49, 622, DateTimeKind.Local).AddTicks(4690), new DateTime(2020, 10, 14, 10, 4, 18, 912, DateTimeKind.Local).AddTicks(2739), 4, 37, "Similique quia quo." },
                    { 200, new DateTime(2021, 2, 17, 22, 54, 17, 123, DateTimeKind.Local).AddTicks(3679), 57, new DateTime(2021, 11, 18, 21, 7, 20, 97, DateTimeKind.Local).AddTicks(5056), new DateTime(2020, 10, 21, 4, 36, 1, 846, DateTimeKind.Local).AddTicks(1995), 1, 16, "Temporibus sunt et natus itaque.\nRecusandae iste similique consequatur.\nEt ut temporibus maiores veritatis voluptatum dolorem.\nPerspiciatis aut cumque qui quidem." },
                    { 39, new DateTime(2020, 8, 26, 19, 39, 1, 705, DateTimeKind.Local).AddTicks(123), 20, new DateTime(2021, 9, 15, 9, 51, 50, 271, DateTimeKind.Local).AddTicks(8814), new DateTime(2020, 6, 12, 8, 40, 43, 178, DateTimeKind.Local).AddTicks(5429), 3, 59, "Quaerat blanditiis dolor omnis." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 184, new DateTime(2020, 3, 28, 3, 43, 17, 444, DateTimeKind.Local).AddTicks(4289), 86, new DateTime(2021, 4, 29, 23, 35, 24, 634, DateTimeKind.Local).AddTicks(905), new DateTime(2020, 11, 25, 1, 49, 36, 415, DateTimeKind.Local).AddTicks(6850), 2, 59, "Saepe autem minus id.\nAutem alias distinctio aut aut delectus reiciendis vel.\nHarum dignissimos reprehenderit eos nam dignissimos.\nCumque et culpa possimus similique nisi qui." },
                    { 3, new DateTime(2020, 9, 24, 11, 14, 58, 203, DateTimeKind.Local).AddTicks(3004), 86, new DateTime(2021, 4, 22, 10, 1, 50, 67, DateTimeKind.Local).AddTicks(5804), new DateTime(2020, 7, 12, 21, 59, 33, 282, DateTimeKind.Local).AddTicks(5423), 5, 51, "Quia nihil nostrum ex quo harum." },
                    { 152, new DateTime(2020, 7, 4, 0, 29, 30, 190, DateTimeKind.Local).AddTicks(5813), 45, new DateTime(2022, 2, 26, 9, 39, 59, 606, DateTimeKind.Local).AddTicks(1419), new DateTime(2020, 6, 6, 17, 29, 14, 689, DateTimeKind.Local).AddTicks(8083), 1, 51, "Assumenda omnis animi occaecati voluptatem veritatis necessitatibus dolores quia. Dolores temporibus voluptates qui rerum explicabo ullam quas possimus quas. Fugiat doloremque quae explicabo. Ab eligendi est aliquam adipisci odio ipsa. Ea earum et dolor magni temporibus eum vel assumenda." },
                    { 13, new DateTime(2020, 7, 2, 4, 47, 45, 672, DateTimeKind.Local).AddTicks(4829), 117, new DateTime(2021, 7, 23, 15, 9, 36, 302, DateTimeKind.Local).AddTicks(2782), new DateTime(2020, 3, 27, 3, 52, 57, 291, DateTimeKind.Local).AddTicks(9707), 3, 19, "Deserunt eos repellendus libero sit voluptatem et sed voluptas." },
                    { 52, new DateTime(2021, 1, 6, 12, 59, 21, 726, DateTimeKind.Local).AddTicks(7083), 117, new DateTime(2021, 6, 29, 4, 43, 52, 952, DateTimeKind.Local).AddTicks(2058), new DateTime(2021, 1, 26, 3, 43, 49, 2, DateTimeKind.Local).AddTicks(8496), 1, 6, "Exercitationem magnam velit ad beatae suscipit similique odit consequatur ex. Est tempore non sit velit totam maiores enim. Dicta neque cumque dignissimos aut architecto. Qui et consequatur ullam temporibus et." },
                    { 44, new DateTime(2020, 8, 17, 4, 7, 35, 545, DateTimeKind.Local).AddTicks(7289), 144, new DateTime(2021, 3, 24, 3, 18, 21, 900, DateTimeKind.Local).AddTicks(3982), new DateTime(2021, 1, 9, 0, 21, 30, 484, DateTimeKind.Local).AddTicks(1195), 4, 6, "Ea omnis et eum.\nDolores est rerum eum aut cum id velit qui.\nVelit non quos.\nQui sint sint voluptatibus facere unde qui adipisci asperiores laborum.\nAliquam quas quia minus quaerat atque autem eveniet ut eum." },
                    { 11, new DateTime(2020, 6, 19, 8, 5, 58, 307, DateTimeKind.Local).AddTicks(368), 94, new DateTime(2022, 3, 4, 6, 0, 41, 227, DateTimeKind.Local).AddTicks(4748), new DateTime(2020, 11, 12, 19, 1, 21, 541, DateTimeKind.Local).AddTicks(6851), 2, 6, "Quidem vel unde sit consequatur placeat saepe.\nQui voluptas dolor odio quia deleniti." },
                    { 155, new DateTime(2021, 1, 30, 12, 6, 34, 622, DateTimeKind.Local).AddTicks(4739), 125, new DateTime(2021, 12, 14, 16, 27, 3, 95, DateTimeKind.Local).AddTicks(1102), new DateTime(2020, 11, 27, 15, 45, 15, 32, DateTimeKind.Local).AddTicks(2264), 3, 62, "Ut id necessitatibus harum." },
                    { 62, new DateTime(2020, 9, 20, 14, 16, 0, 538, DateTimeKind.Local).AddTicks(1420), 9, new DateTime(2021, 7, 23, 23, 43, 38, 365, DateTimeKind.Local).AddTicks(221), new DateTime(2021, 2, 11, 10, 54, 7, 976, DateTimeKind.Local).AddTicks(8822), 5, 83, "qui" },
                    { 172, new DateTime(2020, 12, 22, 11, 22, 1, 286, DateTimeKind.Local).AddTicks(7995), 15, new DateTime(2021, 7, 27, 8, 58, 30, 439, DateTimeKind.Local).AddTicks(1594), new DateTime(2020, 8, 11, 13, 21, 32, 368, DateTimeKind.Local).AddTicks(8509), 1, 83, "Non minus deserunt at tenetur corporis." },
                    { 35, new DateTime(2020, 5, 16, 4, 59, 56, 690, DateTimeKind.Local).AddTicks(3641), 18, new DateTime(2021, 3, 30, 11, 6, 12, 985, DateTimeKind.Local).AddTicks(9487), new DateTime(2020, 11, 2, 4, 24, 44, 959, DateTimeKind.Local).AddTicks(3170), 3, 41, "Labore vitae ex id ratione odit consequatur vel." },
                    { 61, new DateTime(2020, 7, 23, 14, 50, 57, 608, DateTimeKind.Local).AddTicks(1454), 108, new DateTime(2021, 5, 19, 21, 15, 37, 813, DateTimeKind.Local).AddTicks(6944), new DateTime(2020, 4, 21, 21, 57, 44, 201, DateTimeKind.Local).AddTicks(3548), 4, 41, "blanditiis" },
                    { 130, new DateTime(2021, 1, 12, 17, 48, 30, 493, DateTimeKind.Local).AddTicks(3692), 37, new DateTime(2021, 5, 26, 3, 0, 50, 450, DateTimeKind.Local).AddTicks(5925), new DateTime(2020, 8, 6, 23, 37, 50, 495, DateTimeKind.Local).AddTicks(2846), 1, 41, "Harum quasi blanditiis nihil et fugiat. Tempora iusto necessitatibus nemo nihil sed fugit occaecati et tenetur. Est minus molestiae deleniti nisi quia aliquam vero eum. Reprehenderit veritatis dignissimos corrupti est quod dolor veritatis. Voluptates ut vel ullam magni aliquam optio laboriosam ea. Ipsam dolore ea." },
                    { 169, new DateTime(2021, 3, 6, 11, 7, 15, 742, DateTimeKind.Local).AddTicks(6347), 139, new DateTime(2021, 6, 27, 3, 39, 35, 808, DateTimeKind.Local).AddTicks(6184), new DateTime(2020, 7, 24, 10, 59, 3, 501, DateTimeKind.Local).AddTicks(8955), 4, 41, "Aliquam incidunt sit.\nDolore ratione in.\nSequi atque est.\nQuibusdam aut et ea consequatur temporibus qui dicta perspiciatis qui.\nAliquam fugit debitis temporibus ut eaque adipisci incidunt nihil.\nAliquid vel rem atque et veritatis modi quo fugit et." },
                    { 154, new DateTime(2021, 2, 15, 11, 31, 31, 196, DateTimeKind.Local).AddTicks(2423), 131, new DateTime(2021, 6, 30, 8, 23, 29, 291, DateTimeKind.Local).AddTicks(313), new DateTime(2020, 11, 17, 8, 13, 16, 779, DateTimeKind.Local).AddTicks(3635), 2, 15, "Voluptatum nihil enim." },
                    { 168, new DateTime(2020, 7, 3, 22, 33, 24, 992, DateTimeKind.Local).AddTicks(1163), 118, new DateTime(2021, 4, 22, 23, 48, 58, 626, DateTimeKind.Local).AddTicks(7169), new DateTime(2020, 8, 18, 5, 4, 31, 407, DateTimeKind.Local).AddTicks(9974), 5, 15, "Sed sit provident reprehenderit tempora." },
                    { 190, new DateTime(2020, 4, 30, 3, 11, 57, 991, DateTimeKind.Local).AddTicks(433), 13, new DateTime(2021, 9, 21, 21, 19, 17, 769, DateTimeKind.Local).AddTicks(2639), new DateTime(2020, 7, 30, 18, 53, 20, 600, DateTimeKind.Local).AddTicks(7409), 5, 15, "similique" },
                    { 118, new DateTime(2020, 6, 6, 3, 17, 28, 739, DateTimeKind.Local).AddTicks(1458), 4, new DateTime(2021, 7, 10, 10, 38, 37, 438, DateTimeKind.Local).AddTicks(1657), new DateTime(2020, 12, 15, 18, 54, 45, 344, DateTimeKind.Local).AddTicks(8668), 2, 53, "Mollitia quia ab tempora quaerat voluptatem." },
                    { 74, new DateTime(2020, 4, 21, 14, 29, 51, 462, DateTimeKind.Local).AddTicks(8944), 27, new DateTime(2021, 6, 6, 9, 28, 38, 66, DateTimeKind.Local).AddTicks(5786), new DateTime(2021, 2, 8, 10, 26, 45, 750, DateTimeKind.Local).AddTicks(7780), 4, 102, "Consequuntur modi accusamus. Consequatur sit velit nihil porro neque voluptatem. Numquam quidem architecto enim numquam sed neque laborum quasi. Non eius illum nulla quidem iure sequi aut incidunt." },
                    { 187, new DateTime(2020, 10, 2, 23, 53, 37, 275, DateTimeKind.Local).AddTicks(5207), 100, new DateTime(2021, 9, 21, 14, 22, 47, 718, DateTimeKind.Local).AddTicks(2520), new DateTime(2020, 11, 20, 2, 0, 49, 906, DateTimeKind.Local).AddTicks(5877), 3, 53, "Provident veritatis sunt ab nobis.\nReprehenderit dignissimos sint velit et quod." },
                    { 25, new DateTime(2021, 3, 10, 10, 26, 58, 51, DateTimeKind.Local).AddTicks(8817), 39, new DateTime(2022, 1, 1, 20, 30, 3, 96, DateTimeKind.Local).AddTicks(4716), new DateTime(2020, 7, 18, 11, 16, 38, 768, DateTimeKind.Local).AddTicks(5694), 5, 22, "Et est quia non libero animi et animi mollitia.\nNeque consequatur eum eligendi sit et tempora autem cupiditate voluptatem.\nMollitia sit qui vel sed assumenda unde reprehenderit reiciendis.\nNecessitatibus porro sunt autem distinctio temporibus fugiat omnis." },
                    { 19, new DateTime(2020, 6, 18, 22, 22, 26, 854, DateTimeKind.Local).AddTicks(2912), 99, new DateTime(2021, 7, 1, 7, 6, 31, 575, DateTimeKind.Local).AddTicks(5674), new DateTime(2020, 6, 12, 7, 30, 30, 949, DateTimeKind.Local).AddTicks(4925), 1, 73, "excepturi" },
                    { 43, new DateTime(2020, 10, 27, 17, 35, 24, 761, DateTimeKind.Local).AddTicks(912), 120, new DateTime(2021, 9, 9, 15, 7, 31, 445, DateTimeKind.Local).AddTicks(1507), new DateTime(2020, 10, 31, 0, 52, 25, 723, DateTimeKind.Local).AddTicks(6502), 1, 73, "Eum et omnis eius." },
                    { 115, new DateTime(2020, 8, 11, 10, 35, 14, 902, DateTimeKind.Local).AddTicks(5049), 27, new DateTime(2022, 2, 4, 1, 4, 16, 987, DateTimeKind.Local).AddTicks(5697), new DateTime(2020, 5, 5, 1, 58, 41, 165, DateTimeKind.Local).AddTicks(3977), 3, 73, "Eos laborum et nemo cumque et voluptatem accusantium eveniet. Sint vel aut ut et dolores illum. Sint ducimus non quam nemo aut necessitatibus." },
                    { 117, new DateTime(2020, 5, 18, 11, 51, 52, 269, DateTimeKind.Local).AddTicks(4983), 71, new DateTime(2021, 4, 7, 2, 6, 5, 485, DateTimeKind.Local).AddTicks(7569), new DateTime(2021, 2, 17, 1, 58, 40, 618, DateTimeKind.Local).AddTicks(6410), 3, 73, "Et repellat ut et blanditiis vel commodi.\nEst exercitationem porro nemo ea quam dicta et qui." },
                    { 57, new DateTime(2020, 12, 14, 10, 43, 8, 81, DateTimeKind.Local).AddTicks(8335), 105, new DateTime(2021, 6, 30, 1, 49, 46, 624, DateTimeKind.Local).AddTicks(7040), new DateTime(2021, 2, 26, 9, 51, 34, 251, DateTimeKind.Local).AddTicks(9857), 1, 31, "Debitis fugit aut accusantium quo dicta." },
                    { 92, new DateTime(2020, 12, 15, 19, 53, 6, 417, DateTimeKind.Local).AddTicks(3999), 139, new DateTime(2021, 7, 23, 13, 18, 9, 94, DateTimeKind.Local).AddTicks(7177), new DateTime(2020, 6, 13, 12, 5, 57, 74, DateTimeKind.Local).AddTicks(7539), 2, 31, "Nihil dicta ducimus consequuntur non molestiae." },
                    { 4, new DateTime(2020, 3, 27, 2, 44, 15, 11, DateTimeKind.Local).AddTicks(3149), 125, new DateTime(2021, 6, 7, 13, 35, 59, 735, DateTimeKind.Local).AddTicks(3022), new DateTime(2020, 9, 26, 1, 30, 13, 755, DateTimeKind.Local).AddTicks(3416), 2, 62, "distinctio" },
                    { 28, new DateTime(2020, 6, 29, 10, 39, 22, 96, DateTimeKind.Local).AddTicks(3448), 140, new DateTime(2021, 5, 14, 12, 29, 17, 285, DateTimeKind.Local).AddTicks(1631), new DateTime(2020, 5, 19, 15, 29, 43, 867, DateTimeKind.Local).AddTicks(9626), 5, 62, "Aspernatur quia perferendis sint et." },
                    { 107, new DateTime(2021, 1, 22, 7, 51, 24, 333, DateTimeKind.Local).AddTicks(8206), 116, new DateTime(2021, 12, 4, 16, 5, 46, 744, DateTimeKind.Local).AddTicks(3865), new DateTime(2020, 12, 11, 23, 23, 35, 369, DateTimeKind.Local).AddTicks(4024), 1, 62, "Amet aut quia architecto. Amet eveniet autem similique enim velit at. Temporibus et sit earum nam odio est." },
                    { 194, new DateTime(2020, 9, 20, 21, 18, 53, 51, DateTimeKind.Local).AddTicks(9952), 78, new DateTime(2021, 6, 18, 12, 35, 50, 418, DateTimeKind.Local).AddTicks(8721), new DateTime(2021, 3, 13, 16, 48, 38, 250, DateTimeKind.Local).AddTicks(2604), 2, 53, "Praesentium velit quam." },
                    { 192, new DateTime(2020, 9, 27, 0, 20, 57, 865, DateTimeKind.Local).AddTicks(6770), 9, new DateTime(2022, 3, 21, 20, 32, 9, 915, DateTimeKind.Local).AddTicks(9171), new DateTime(2020, 12, 31, 4, 39, 9, 187, DateTimeKind.Local).AddTicks(8171), 3, 102, "Quia tenetur animi sint aut." }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_ModelId",
                table: "Cars",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_Vin",
                table: "Cars",
                column: "Vin",
                unique: true);

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
                name: "IX_Models_EngineId",
                table: "Models",
                column: "EngineId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_ManufacturerId",
                table: "Models",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Models_Name",
                table: "Models",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

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
                name: "IX_Status_Name",
                table: "Status",
                column: "Name",
                unique: true);

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
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

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
