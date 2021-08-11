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
                    { 1, "Bhutan" },
                    { 128, "Mauritius" },
                    { 127, "Sao Tome and Principe" },
                    { 125, "United States of America" },
                    { 123, "Turkey" },
                    { 122, "Cuba" },
                    { 120, "Djibouti" },
                    { 119, "Venezuela" },
                    { 118, "Benin" },
                    { 117, "Thailand" },
                    { 116, "Reunion" },
                    { 115, "Bermuda" },
                    { 113, "Nauru" },
                    { 112, "Hungary" },
                    { 111, "Nepal" },
                    { 131, "Libyan Arab Jamahiriya" },
                    { 110, "Somalia" },
                    { 107, "Montserrat" },
                    { 104, "Gambia" },
                    { 101, "Malaysia" },
                    { 97, "Palau" },
                    { 95, "Italy" },
                    { 94, "Eritrea" },
                    { 93, "Ukraine" },
                    { 92, "Cocos (Keeling) Islands" },
                    { 90, "Taiwan" },
                    { 89, "Burkina Faso" },
                    { 88, "Netherlands" },
                    { 86, "American Samoa" },
                    { 84, "Pitcairn Islands" },
                    { 82, "Malawi" },
                    { 109, "Argentina" },
                    { 132, "Costa Rica" },
                    { 134, "Dominica" },
                    { 135, "Cook Islands" },
                    { 198, "Sudan" },
                    { 196, "Holy See (Vatican City State)" },
                    { 194, "Mauritania" },
                    { 193, "Ghana" },
                    { 192, "Serbia" },
                    { 189, "Gibraltar" },
                    { 186, "Turkmenistan" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 184, "Azerbaijan" },
                    { 182, "Saint Kitts and Nevis" },
                    { 181, "Norfolk Island" },
                    { 180, "Cape Verde" },
                    { 179, "Tajikistan" },
                    { 174, "Ecuador" },
                    { 173, "Barbados" },
                    { 172, "Colombia" },
                    { 168, "Haiti" },
                    { 166, "Iran" },
                    { 136, "Zambia" },
                    { 138, "Paraguay" },
                    { 139, "Andorra" },
                    { 140, "Puerto Rico" },
                    { 143, "Montenegro" },
                    { 146, "Senegal" },
                    { 81, "Panama" },
                    { 147, "Mexico" },
                    { 149, "Central African Republic" },
                    { 156, "Georgia" },
                    { 159, "Guinea-Bissau" },
                    { 160, "Kenya" },
                    { 162, "Antigua and Barbuda" },
                    { 165, "Germany" },
                    { 148, "Antarctica (the territory South of 60 deg S)" },
                    { 79, "Palestinian Territory" },
                    { 87, "Macedonia" },
                    { 77, "Chile" },
                    { 32, "Gabon" },
                    { 31, "Japan" },
                    { 30, "Hong Kong" },
                    { 78, "Brazil" },
                    { 28, "Jersey" },
                    { 27, "Vietnam" },
                    { 26, "Israel" },
                    { 25, "British Indian Ocean Territory (Chagos Archipelago)" },
                    { 24, "China" },
                    { 23, "Trinidad and Tobago" },
                    { 22, "French Southern Territories" },
                    { 21, "Northern Mariana Islands" },
                    { 20, "Saint Helena" },
                    { 19, "Timor-Leste" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 18, "Tanzania" },
                    { 17, "Finland" },
                    { 16, "Tonga" },
                    { 2, "Ireland" },
                    { 3, "Kuwait" },
                    { 4, "Saint Vincent and the Grenadines" },
                    { 5, "Croatia" },
                    { 6, "Czech Republic" },
                    { 7, "Greenland" },
                    { 33, "Rwanda" },
                    { 8, "Namibia" },
                    { 10, "Papua New Guinea" },
                    { 11, "Guernsey" },
                    { 12, "Mongolia" },
                    { 13, "Comoros" },
                    { 14, "Oman" },
                    { 15, "South Georgia and the South Sandwich Islands" },
                    { 9, "Marshall Islands" },
                    { 34, "Burundi" },
                    { 29, "Slovakia (Slovak Republic)" },
                    { 36, "Peru" },
                    { 76, "Christmas Island" },
                    { 75, "Bangladesh" },
                    { 74, "Congo" },
                    { 72, "Poland" },
                    { 71, "Iraq" },
                    { 69, "Afghanistan" },
                    { 67, "Svalbard & Jan Mayen Islands" },
                    { 65, "Egypt" },
                    { 64, "Cayman Islands" },
                    { 35, "Norway" },
                    { 62, "Togo" },
                    { 61, "Equatorial Guinea" },
                    { 59, "Nicaragua" },
                    { 58, "French Guiana" },
                    { 57, "Luxembourg" },
                    { 63, "Sierra Leone" },
                    { 55, "Albania" },
                    { 37, "Latvia" },
                    { 56, "Seychelles" },
                    { 39, "Australia" },
                    { 41, "Pakistan" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 42, "Lao People's Democratic Republic" },
                    { 43, "Brunei Darussalam" },
                    { 38, "Micronesia" },
                    { 45, "Lesotho" },
                    { 46, "Honduras" },
                    { 47, "Saint Barthelemy" },
                    { 48, "Jamaica" },
                    { 50, "Bolivia" },
                    { 54, "Botswana" },
                    { 44, "Saudi Arabia" }
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
                    { 77, 1, "New Lois" },
                    { 93, 120, "Wernerbury" },
                    { 18, 120, "Abbigailmouth" },
                    { 299, 119, "Hoppeburgh" },
                    { 205, 118, "Reingerburgh" },
                    { 76, 118, "West Goldafort" },
                    { 48, 118, "Jaskolskiside" },
                    { 241, 117, "East Matilde" },
                    { 236, 117, "West Savanahchester" },
                    { 279, 116, "Connellyville" },
                    { 252, 116, "Tanyaton" },
                    { 277, 113, "West Christiantown" },
                    { 98, 113, "South Annabellhaven" },
                    { 188, 112, "Port Loyside" },
                    { 172, 112, "Lake Geraldside" },
                    { 32, 112, "West Jeramy" },
                    { 219, 111, "Domenicfort" },
                    { 162, 110, "Thompsonberg" },
                    { 120, 122, "Lake Annettemouth" },
                    { 217, 122, "New Ahmadberg" },
                    { 21, 123, "North Griffin" },
                    { 36, 123, "South Hobartport" },
                    { 251, 134, "Aracelyville" },
                    { 140, 134, "Lake Esperanzaport" },
                    { 4, 134, "Lake Ulicesfurt" },
                    { 26, 132, "McDermotthaven" },
                    { 253, 131, "Nealburgh" },
                    { 234, 131, "Kilbackbury" },
                    { 133, 131, "East Erna" },
                    { 19, 131, "New Rutheview" },
                    { 237, 107, "Vanmouth" },
                    { 35, 128, "North Rodrigoshire" },
                    { 153, 127, "West Fleta" },
                    { 113, 127, "Connertown" },
                    { 258, 125, "Wunschmouth" },
                    { 146, 125, "Lowemouth" },
                    { 52, 125, "Port Kathleen" },
                    { 167, 123, "Mannville" },
                    { 92, 123, "Garrisonport" },
                    { 84, 123, "West Aryannaside" },
                    { 22, 128, "Port Carli" },
                    { 106, 135, "Naderburgh" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 235, 107, "Hartmannton" },
                    { 102, 107, "New Terrance" },
                    { 262, 89, "Reichelhaven" },
                    { 164, 89, "Hirtheville" },
                    { 108, 89, "New Bonita" },
                    { 33, 89, "New Destiney" },
                    { 182, 86, "Ryleeport" },
                    { 59, 86, "West Abbie" },
                    { 193, 84, "New Karlichester" },
                    { 50, 84, "New Opal" },
                    { 128, 82, "East Vena" },
                    { 104, 82, "North Clairechester" },
                    { 5, 82, "West Cordelia" },
                    { 276, 81, "Orvilleside" },
                    { 203, 81, "East Lelandmouth" },
                    { 293, 76, "East Aidan" },
                    { 242, 76, "Port Aubrey" },
                    { 123, 76, "Hammesborough" },
                    { 91, 76, "Jaydaside" },
                    { 124, 196, "West Bill" },
                    { 222, 90, "Boyerbury" },
                    { 154, 92, "West Jannie" },
                    { 190, 92, "Celiahaven" },
                    { 73, 107, "Kalebmouth" },
                    { 290, 101, "New Joanniemouth" },
                    { 138, 101, "Prosaccochester" },
                    { 75, 101, "Vicentaland" },
                    { 230, 97, "East Keegan" },
                    { 223, 97, "Lake Theresa" },
                    { 199, 97, "Whitetown" },
                    { 186, 97, "Vellaland" },
                    { 136, 107, "Garlandside" },
                    { 285, 95, "South Jaida" },
                    { 74, 95, "West Rigobertoland" },
                    { 28, 95, "West Everettechester" },
                    { 238, 94, "West Rubie" },
                    { 148, 94, "Wildermanfort" },
                    { 275, 93, "South Dougville" },
                    { 114, 93, "South Daisy" },
                    { 66, 93, "New Percivalland" },
                    { 25, 93, "South Hubert" },
                    { 171, 95, "Buckridgeburgh" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 17, 136, "South Elody" },
                    { 23, 136, "Jakubowskiside" },
                    { 96, 136, "West Nella" },
                    { 139, 181, "New Maximus" },
                    { 103, 181, "New Megane" },
                    { 231, 180, "Elisastad" },
                    { 226, 180, "Jacobsshire" },
                    { 201, 180, "Bashirianbury" },
                    { 111, 180, "Savannahborough" },
                    { 105, 180, "North Jacklynmouth" },
                    { 65, 179, "West Corineville" },
                    { 61, 174, "Jacobsport" },
                    { 184, 173, "Kadinhaven" },
                    { 273, 172, "Lake Cortez" },
                    { 216, 172, "Jarredberg" },
                    { 174, 172, "Port Roscoeton" },
                    { 212, 168, "New Aylinfort" },
                    { 181, 168, "South Shanon" },
                    { 166, 168, "West Vedaland" },
                    { 144, 168, "East Anna" },
                    { 68, 182, "Daughertybury" },
                    { 101, 182, "North Corene" },
                    { 159, 182, "South Adam" },
                    { 177, 182, "East Mayra" },
                    { 161, 198, "Imanihaven" },
                    { 150, 194, "Cronintown" },
                    { 9, 194, "West Esmeralda" },
                    { 268, 193, "South Lorine" },
                    { 51, 193, "South Enrique" },
                    { 215, 192, "South Daphneestad" },
                    { 38, 192, "Grahammouth" },
                    { 274, 189, "East Hollymouth" },
                    { 263, 166, "Port Bennettbury" },
                    { 155, 189, "Lake Robinborough" },
                    { 34, 189, "Howardmouth" },
                    { 55, 186, "North Katharinafurt" },
                    { 280, 184, "Jaunitaton" },
                    { 214, 184, "Beattyview" },
                    { 213, 184, "North Estrellamouth" },
                    { 132, 184, "Sauerport" },
                    { 284, 182, "West Korey" },
                    { 243, 182, "West Budton" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 134, 189, "Heloiseland" },
                    { 67, 166, "Berneicestad" },
                    { 232, 165, "South Trevor" },
                    { 225, 165, "Altenwerthland" },
                    { 143, 148, "Carmelofort" },
                    { 15, 148, "Lehnertown" },
                    { 149, 146, "West Fermin" },
                    { 10, 146, "Guidoview" },
                    { 116, 143, "East Georgiannatown" },
                    { 79, 143, "North Gianniside" },
                    { 60, 143, "Staceymouth" },
                    { 204, 140, "Gaylordside" },
                    { 289, 148, "Pearlieborough" },
                    { 287, 139, "West Karlstad" },
                    { 131, 139, "Zackeryport" },
                    { 70, 139, "Sengerside" },
                    { 207, 138, "Hayesport" },
                    { 180, 138, "Ricefort" },
                    { 151, 138, "South Angelitamouth" },
                    { 86, 138, "Port Clara" },
                    { 278, 136, "Parisianville" },
                    { 272, 136, "Pollichfort" },
                    { 187, 139, "South Angusshire" },
                    { 7, 76, "Danteview" },
                    { 30, 149, "Camilletown" },
                    { 233, 149, "Spencerbury" },
                    { 211, 165, "East Jaclynburgh" },
                    { 191, 165, "New Bridie" },
                    { 89, 165, "Armstrongfort" },
                    { 45, 165, "Joannyport" },
                    { 294, 162, "Lazaroville" },
                    { 244, 162, "East Hilbert" },
                    { 228, 162, "Arvelberg" },
                    { 152, 162, "East Jefferey" },
                    { 224, 149, "New Grady" },
                    { 82, 162, "West Jaydeville" },
                    { 141, 160, "North Beverly" },
                    { 100, 160, "East Christopher" },
                    { 271, 159, "Port Selenaborough" },
                    { 170, 159, "Armstrongport" },
                    { 267, 156, "West Durward" },
                    { 42, 156, "North Jadeborough" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 31, 156, "Rosalynside" },
                    { 14, 156, "South Chanelleberg" },
                    { 6, 162, "Lake Sidfort" },
                    { 2, 75, "New Johnsonmouth" },
                    { 112, 198, "Nanniefort" },
                    { 160, 74, "Lake Darrinborough" },
                    { 71, 30, "Murphybury" },
                    { 147, 29, "Port Misty" },
                    { 255, 27, "East Fabiolashire" },
                    { 254, 25, "North Marty" },
                    { 85, 25, "McKenzieton" },
                    { 8, 25, "Moentown" },
                    { 165, 24, "North Lolastad" },
                    { 135, 30, "Coleton" },
                    { 137, 24, "Lake Alan" },
                    { 130, 21, "Port Allene" },
                    { 118, 21, "East Emieland" },
                    { 57, 21, "Dickiport" },
                    { 227, 20, "Port Jarrettville" },
                    { 209, 20, "Francescafort" },
                    { 206, 20, "North Jaylonhaven" },
                    { 183, 20, "North Everetttown" },
                    { 169, 23, "Hoegerbury" },
                    { 117, 20, "Dedricport" },
                    { 286, 30, "East Daphne" },
                    { 107, 31, "Skylarmouth" },
                    { 122, 39, "Port Lura" },
                    { 178, 38, "Laurachester" },
                    { 127, 38, "East Ella" },
                    { 39, 38, "Balistrerifort" },
                    { 157, 35, "North Ryder" },
                    { 94, 35, "South Idaside" },
                    { 261, 34, "Sammyville" },
                    { 63, 31, "North Barbaramouth" },
                    { 257, 34, "Jenkinsshire" },
                    { 245, 34, "South Kylerville" },
                    { 176, 34, "Helenachester" },
                    { 62, 33, "Duanechester" },
                    { 292, 32, "South Kellie" },
                    { 185, 32, "Manteville" },
                    { 156, 32, "Martaborough" },
                    { 297, 31, "Pricemouth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 246, 34, "South Katrine" },
                    { 41, 20, "Rueckerton" },
                    { 126, 19, "Pricestad" },
                    { 47, 19, "Isadoreport" },
                    { 249, 6, "Framiville" },
                    { 208, 6, "Louside" },
                    { 163, 6, "East Malachi" },
                    { 99, 6, "Ankundingchester" },
                    { 97, 5, "East Gillianberg" },
                    { 29, 5, "Yasmineburgh" },
                    { 295, 4, "East Eino" },
                    { 298, 6, "East Tyrellshire" },
                    { 218, 4, "Lake Samara" },
                    { 16, 4, "Mayerbury" },
                    { 266, 3, "Norrisport" },
                    { 200, 3, "Wardbury" },
                    { 260, 2, "Millerchester" },
                    { 202, 2, "Phyllisport" },
                    { 46, 2, "Padbergshire" },
                    { 192, 1, "North Giovani" },
                    { 115, 4, "Kurttown" },
                    { 300, 6, "Wiegandshire" },
                    { 195, 8, "South Electa" },
                    { 1, 9, "Donnellyborough" },
                    { 168, 18, "North Lexusville" },
                    { 20, 18, "Cronachester" },
                    { 78, 17, "West Dolly" },
                    { 11, 17, "East Alexandriaborough" },
                    { 64, 14, "Borisstad" },
                    { 43, 14, "Elyseton" },
                    { 27, 14, "Port Emiliemouth" },
                    { 288, 13, "Ociefort" },
                    { 283, 13, "Bartonland" },
                    { 24, 13, "West Jackshire" },
                    { 291, 12, "Westport" },
                    { 248, 12, "Lebsackchester" },
                    { 175, 12, "Isabellachester" },
                    { 88, 12, "South Sylvan" },
                    { 54, 12, "Marquardtshire" },
                    { 196, 10, "West Cristal" },
                    { 69, 10, "Terryview" },
                    { 125, 39, "West Ruth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 250, 39, "Lake Sabrina" },
                    { 90, 33, "Dovieport" },
                    { 49, 50, "East Oswaldo" },
                    { 142, 64, "Lake Alizaville" },
                    { 282, 63, "Rociostad" },
                    { 259, 47, "Oberbrunnerbury" },
                    { 221, 63, "Prohaskahaven" },
                    { 37, 58, "Yostmouth" },
                    { 129, 63, "West Gayle" },
                    { 110, 63, "Schulistborough" },
                    { 53, 62, "Port Adaline" },
                    { 121, 50, "New Giuseppeburgh" },
                    { 229, 50, "Saraimouth" },
                    { 264, 61, "Port Leonardmouth" },
                    { 189, 61, "South Providencimouth" },
                    { 12, 54, "Berniermouth" },
                    { 44, 54, "West Jerry" },
                    { 296, 54, "Emanuelburgh" },
                    { 256, 55, "Jamesonstad" },
                    { 281, 58, "Kassulketon" },
                    { 198, 58, "South Angelohaven" },
                    { 119, 56, "Port Dora" },
                    { 239, 56, "West Barrett" },
                    { 194, 58, "Edmundmouth" },
                    { 56, 57, "Port Collinbury" },
                    { 247, 57, "Berniceburgh" },
                    { 265, 64, "Kutchland" },
                    { 197, 45, "West Barbara" },
                    { 269, 57, "Orvilleburgh" },
                    { 58, 67, "Port Montyshire" },
                    { 173, 67, "Murphyburgh" },
                    { 179, 41, "Rodolfohaven" },
                    { 87, 71, "Malikaside" },
                    { 83, 43, "Denesikfurt" },
                    { 95, 43, "New Reagan" },
                    { 145, 43, "Port Noe" },
                    { 270, 65, "North Josiah" },
                    { 72, 65, "Faybury" },
                    { 220, 65, "Port Norwood" },
                    { 80, 41, "Maryville" },
                    { 210, 43, "Langoshstad" },
                    { 158, 43, "East Walkermouth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 13, 72, "New Loren" },
                    { 3, 65, "New Chris" },
                    { 40, 69, "Taylorburgh" },
                    { 109, 41, "Paucekmouth" },
                    { 81, 69, "New Pearlhaven" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 52, 2817, 1, 460 },
                    { 50, 2886, 4, 205 },
                    { 64, 1449, 4, 450 },
                    { 49, 2621, 1, 664 },
                    { 75, 2050, 4, 260 },
                    { 12, 1314, 1, 662 },
                    { 53, 1758, 3, 320 },
                    { 77, 2342, 4, 181 },
                    { 42, 2085, 4, 111 },
                    { 18, 1917, 3, 330 },
                    { 41, 2564, 4, 382 },
                    { 97, 1681, 4, 598 },
                    { 4, 1137, 3, 407 },
                    { 46, 2925, 4, 172 },
                    { 40, 1153, 3, 330 },
                    { 92, 1055, 4, 409 },
                    { 44, 1854, 1, 572 },
                    { 20, 2133, 3, 155 },
                    { 96, 1581, 2, 343 },
                    { 87, 2649, 2, 675 },
                    { 85, 1561, 4, 681 },
                    { 80, 1798, 2, 657 },
                    { 81, 2234, 4, 523 },
                    { 79, 2703, 2, 397 },
                    { 6, 2734, 1, 550 },
                    { 37, 1110, 3, 182 },
                    { 17, 2545, 1, 468 },
                    { 73, 1352, 2, 205 },
                    { 29, 2090, 1, 685 },
                    { 28, 1058, 3, 472 },
                    { 3, 2943, 3, 129 },
                    { 33, 2287, 3, 562 },
                    { 35, 2818, 3, 516 },
                    { 32, 2212, 1, 249 },
                    { 5, 2332, 1, 616 },
                    { 19, 2136, 1, 434 },
                    { 72, 2186, 3, 181 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 59, 1512, 2, 390 },
                    { 56, 1706, 1, 526 },
                    { 68, 1284, 3, 371 },
                    { 74, 1263, 1, 414 },
                    { 83, 1241, 1, 495 },
                    { 69, 2022, 3, 136 },
                    { 10, 1782, 3, 275 },
                    { 89, 1634, 3, 266 },
                    { 43, 2771, 2, 270 },
                    { 34, 1762, 2, 519 },
                    { 86, 1041, 1, 470 },
                    { 91, 1205, 1, 567 },
                    { 30, 1524, 2, 454 },
                    { 93, 1716, 1, 193 },
                    { 45, 1820, 2, 152 },
                    { 88, 2956, 3, 373 },
                    { 84, 2989, 3, 667 },
                    { 82, 1740, 3, 257 },
                    { 76, 2108, 3, 571 },
                    { 71, 2926, 3, 648 },
                    { 95, 1842, 1, 506 },
                    { 99, 2985, 1, 484 },
                    { 27, 1935, 2, 189 },
                    { 1, 1478, 2, 272 },
                    { 2, 2343, 2, 554 },
                    { 13, 2641, 2, 687 },
                    { 14, 2417, 2, 482 },
                    { 15, 2395, 2, 224 },
                    { 94, 1426, 1, 360 },
                    { 90, 1716, 3, 545 },
                    { 70, 1252, 1, 491 },
                    { 47, 1225, 2, 174 },
                    { 60, 1933, 1, 540 },
                    { 61, 2276, 1, 666 },
                    { 62, 1878, 1, 298 },
                    { 25, 2781, 2, 405 },
                    { 39, 1859, 4, 358 },
                    { 65, 1502, 3, 303 },
                    { 38, 1238, 4, 159 },
                    { 36, 1842, 4, 441 },
                    { 31, 1116, 4, 252 },
                    { 58, 1069, 2, 679 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 26, 1859, 4, 692 },
                    { 57, 1982, 2, 380 },
                    { 55, 2230, 2, 477 },
                    { 67, 1198, 1, 374 },
                    { 24, 1156, 4, 127 },
                    { 66, 1241, 3, 510 },
                    { 23, 2466, 4, 405 },
                    { 22, 2858, 4, 482 },
                    { 21, 1918, 4, 448 },
                    { 16, 1861, 4, 584 },
                    { 11, 1865, 4, 434 },
                    { 9, 2159, 4, 139 },
                    { 8, 2367, 4, 212 },
                    { 54, 2548, 2, 422 },
                    { 51, 1192, 2, 440 },
                    { 48, 1597, 2, 224 },
                    { 7, 1433, 4, 172 },
                    { 63, 2662, 2, 401 },
                    { 78, 2371, 2, 320 },
                    { 100, 1665, 4, 131 },
                    { 98, 1610, 4, 445 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 26, 194, "Ledner - Sawayn" },
                    { 44, 33, "Lehner and Sons" },
                    { 92, 34, "Jacobi Inc" },
                    { 39, 37, "Kemmer Inc" },
                    { 79, 37, "Kutch - Tillman" },
                    { 85, 37, "Heidenreich, Turner and Wunsch" },
                    { 8, 39, "Ankunding - Carroll" },
                    { 61, 42, "Bins - Feil" },
                    { 15, 45, "Marvin, Weimann and Shields" },
                    { 68, 46, "Smith, Johnston and Heller" },
                    { 17, 50, "Pagac - Kozey" },
                    { 32, 54, "Haag, Beer and Krajcik" },
                    { 2, 58, "Lehner LLC" },
                    { 19, 58, "Hane - Heathcote" },
                    { 35, 58, "Nienow, Fadel and Wisozk" },
                    { 71, 61, "Lang - Smith" },
                    { 94, 61, "Lind - Lueilwitz" },
                    { 100, 61, "Oberbrunner, Miller and Olson" },
                    { 9, 64, "Mann Group" },
                    { 72, 71, "Swift - Beier" },
                    { 95, 74, "Parisian, Block and Crist" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 57, 31, "Hessel Inc" },
                    { 84, 30, "Feil, Kohler and Donnelly" },
                    { 62, 29, "Koss - Ward" },
                    { 55, 28, "Vandervort - Kunze" },
                    { 83, 1, "Aufderhar Group" },
                    { 23, 3, "DuBuque - Murazik" },
                    { 52, 5, "Bosco, Turcotte and Terry" },
                    { 63, 8, "Davis Group" },
                    { 41, 14, "Bernhard - Koch" },
                    { 75, 14, "Kovacek - Zieme" },
                    { 82, 14, "Feeney - Grady" },
                    { 6, 16, "Schaefer Inc" },
                    { 51, 16, "Ankunding, Hilll and Jast" },
                    { 69, 17, "Lang - Pacocha" },
                    { 36, 75, "MacGyver Inc" },
                    { 77, 18, "Leffler, Crist and Koss" },
                    { 28, 21, "Adams - Ziemann" },
                    { 90, 21, "Schuster - Hegmann" },
                    { 67, 22, "Stoltenberg, Koch and Ebert" },
                    { 81, 23, "Rosenbaum - Torphy" },
                    { 24, 24, "Vandervort LLC" },
                    { 40, 25, "McGlynn, Beier and Greenholt" },
                    { 13, 26, "Rohan and Sons" },
                    { 73, 26, "Block - Lesch" },
                    { 76, 26, "Bayer LLC" },
                    { 96, 27, "Dare - King" },
                    { 49, 20, "Wunsch Inc" },
                    { 99, 76, "Kozey, Pouros and Altenwerth" },
                    { 10, 84, "Marks - Jacobi" },
                    { 20, 84, "Kovacek, Schuster and Hand" },
                    { 11, 125, "Simonis and Sons" },
                    { 4, 127, "Flatley, Hansen and Ryan" },
                    { 47, 127, "Cummerata - Wolff" },
                    { 54, 132, "Flatley - Weber" },
                    { 88, 132, "Huel, Parisian and Grant" },
                    { 18, 135, "Streich LLC" },
                    { 74, 146, "Corwin, Farrell and Mayert" },
                    { 30, 159, "Rippin - Mitchell" },
                    { 98, 159, "Hickle - Gorczany" },
                    { 60, 160, "Blanda - Blanda" },
                    { 78, 160, "Brown - Ortiz" },
                    { 12, 165, "Nicolas Group" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 89, 165, "Emmerich and Sons" },
                    { 29, 168, "Johns Group" },
                    { 87, 168, "Powlowski, Lind and Heaney" },
                    { 48, 174, "Nitzsche - Nienow" },
                    { 3, 179, "D'Amore Group" },
                    { 21, 179, "Roberts, Watsica and Rippin" },
                    { 58, 182, "Huel - Trantow" },
                    { 34, 186, "Hauck and Sons" },
                    { 70, 189, "Kemmer - Zulauf" },
                    { 66, 123, "Schroeder, Walker and Altenwerth" },
                    { 80, 122, "McDermott Inc" },
                    { 7, 122, "Prohaska Inc" },
                    { 46, 120, "Cormier - Collier" },
                    { 65, 87, "Friesen Group" },
                    { 38, 88, "Schiller - Yundt" },
                    { 31, 89, "Feil Inc" },
                    { 50, 89, "Sauer Group" },
                    { 59, 95, "Sawayn - Reilly" },
                    { 56, 97, "Koch, Rodriguez and Wisozk" },
                    { 97, 101, "Bechtelar - Barrows" },
                    { 42, 104, "Kozey Group" },
                    { 53, 104, "Jacobs - Moore" },
                    { 16, 109, "Schroeder, Crona and Schultz" },
                    { 14, 196, "Hansen - Muller" },
                    { 22, 109, "Stroman, Labadie and Batz" },
                    { 37, 109, "Swaniawski, Balistreri and Pagac" },
                    { 5, 111, "Beer - Green" },
                    { 27, 112, "Nolan LLC" },
                    { 93, 112, "Goyette, Beahan and Kohler" },
                    { 64, 115, "Bednar - Vandervort" },
                    { 91, 118, "Zulauf, Fadel and Bashirian" },
                    { 1, 119, "Satterfield, Ryan and Bartell" },
                    { 33, 119, "Morissette Group" },
                    { 43, 119, "Homenick Group" },
                    { 86, 119, "Kassulke, Larkin and Wintheiser" },
                    { 25, 109, "Hyatt Group" },
                    { 45, 117, "Denesik - King" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 25, 100, 31, "asperiores" },
                    { 29, 2, 10, "autem" },
                    { 89, 13, 26, "eos" },
                    { 43, 25, 31, "rerum" },
                    { 84, 30, 30, "sapiente" },
                    { 50, 34, 28, "animi" },
                    { 4, 47, 67, "fugit" },
                    { 81, 48, 3, "nobis" },
                    { 68, 57, 44, "et" },
                    { 51, 59, 92, "saepe" },
                    { 76, 59, 35, "sequi" },
                    { 47, 63, 41, "ullam" },
                    { 87, 63, 25, "accusamus" },
                    { 6, 78, 56, "voluptatem" },
                    { 52, 78, 91, "incidunt" },
                    { 13, 79, 86, "non" },
                    { 49, 95, 98, "quia" },
                    { 71, 94, 96, "provident" },
                    { 57, 93, 71, "dolorem" },
                    { 75, 70, 66, "id" },
                    { 32, 5, 6, "eligendi" },
                    { 56, 5, 84, "a" },
                    { 31, 6, 21, "molestiae" },
                    { 82, 6, 99, "nihil" },
                    { 91, 6, 69, "aspernatur" },
                    { 2, 17, 90, "error" },
                    { 15, 17, 23, "hic" },
                    { 37, 79, 40, "doloremque" },
                    { 90, 49, 89, "sed" },
                    { 48, 52, 5, "enim" },
                    { 55, 61, 9, "laudantium" },
                    { 70, 61, 41, "numquam" },
                    { 53, 67, 3, "cumque" },
                    { 65, 67, 14, "sunt" },
                    { 93, 67, 3, "voluptatum" },
                    { 24, 70, 95, "at" },
                    { 94, 49, 32, "facilis" },
                    { 86, 79, 17, "dolor" },
                    { 66, 97, 85, "dignissimos" },
                    { 60, 96, 10, "quod" },
                    { 17, 9, 85, "ducimus" },
                    { 11, 11, 3, "similique" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 30, 11, 91, "architecto" },
                    { 39, 16, 73, "quam" },
                    { 9, 21, 80, "omnis" },
                    { 21, 22, 99, "delectus" },
                    { 46, 24, 80, "quo" },
                    { 35, 90, 60, "odio" },
                    { 41, 26, 29, "dolorum" },
                    { 58, 38, 73, "sint" },
                    { 38, 46, 26, "tenetur" },
                    { 22, 64, 55, "in" },
                    { 1, 92, 77, "consequuntur" },
                    { 8, 92, 2, "ratione" },
                    { 16, 97, 13, "esse" },
                    { 26, 80, 20, "quisquam" },
                    { 63, 31, 89, "ut" },
                    { 62, 88, 6, "voluptates" },
                    { 3, 46, 26, "quaerat" },
                    { 7, 88, 3, "voluptas" },
                    { 74, 96, 73, "qui" },
                    { 10, 88, 4, "ad" },
                    { 18, 3, 1, "rem" },
                    { 61, 3, 4, "temporibus" },
                    { 54, 18, 75, "neque" },
                    { 28, 20, 83, "labore" },
                    { 5, 53, 62, "sit" },
                    { 23, 53, 17, "ea" },
                    { 20, 10, 81, "alias" },
                    { 96, 66, 34, "ipsum" },
                    { 27, 68, 35, "maxime" },
                    { 33, 68, 38, "recusandae" },
                    { 97, 72, 65, "dicta" },
                    { 36, 71, 48, "eum" },
                    { 72, 71, 38, "impedit" },
                    { 85, 65, 19, "itaque" },
                    { 92, 71, 5, "earum" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 14, 187, "Faye26@hotmail.com", "Aida", "Hansen", "XYDUILm3Sa", 3, "Ottilie.Cole82" },
                    { 275, 70, "Adelle_Frami@yahoo.com", "Lorenz", "Williamson", "GDT1gVxedF", 3, "Branson.Farrell20" },
                    { 64, 207, "Connie_Vandervort@gmail.com", "Vance", "Kassulke", "IcriLAQqPt", 3, "Savanah_Macejkovic10" },
                    { 237, 180, "Berenice_Douglas@yahoo.com", "Lavon", "Jakubowski", "7JMwRw6yuO", 1, "Maxine_Hagenes" },
                    { 41, 278, "Abigail35@gmail.com", "Sadye", "Larson", "mDuUji46I7", 1, "Jaeden23" },
                    { 182, 272, "Katrine.Zieme59@gmail.com", "Clemens", "Welch", "diH4goqCak", 2, "Ora_Spinka" },
                    { 66, 96, "Callie_Mann@hotmail.com", "Yolanda", "Wyman", "OHqFhDE1FV", 2, "Jerrod_Mertz11" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 31, 187, "Timothy_Bechtelar@hotmail.com", "Elian", "Langworth", "PaLRYdwSXs", 2, "Joel.Mayert60" },
                    { 5, 96, "Mellie_Gutmann@yahoo.com", "Lavern", "Rau", "aIzq1gL1s0", 2, "Oscar_Ernser" },
                    { 112, 180, "Claud.Hand95@yahoo.com", "Cade", "Brekke", "5do_H9Bzne", 2, "Aidan_Vandervort" },
                    { 71, 187, "Esther.Lubowitz@yahoo.com", "Lonzo", "Waters", "7USQyOZoVE", 2, "Lura.Schmidt72" },
                    { 33, 14, "Chase_White66@hotmail.com", "Virginia", "Blick", "fSPQUCLuci", 2, "Gertrude.Schuster27" },
                    { 130, 60, "Sydni_Herzog@hotmail.com", "Merl", "Mosciski", "BsQB9FwA8V", 2, "Damion.Corkery15" },
                    { 294, 60, "Patricia.Greenholt@hotmail.com", "Eddie", "Gleichner", "HXBtd9qEqf", 3, "Tyrese_Kessler53" },
                    { 88, 79, "Rafael_Ondricka20@hotmail.com", "Israel", "Durgan", "2EH_weFkDS", 1, "Bonnie39" },
                    { 239, 10, "Arely.Aufderhar81@gmail.com", "Valerie", "Hintz", "dAcXYMjJ3s", 3, "Eriberto27" },
                    { 69, 149, "Zander6@yahoo.com", "Lera", "Gutkowski", "QCvC95Bqne", 2, "Amara10" },
                    { 254, 143, "Karelle.Bernier@gmail.com", "Esperanza", "Weber", "BniLj_uqYM", 1, "Millie79" },
                    { 109, 31, "Gaston_Buckridge42@hotmail.com", "Bonnie", "Haley", "xXLRxPYo1a", 3, "Felton.Murray86" },
                    { 114, 31, "Jada.Dietrich55@yahoo.com", "Charlene", "Fadel", "OgTHD8S2BF", 3, "Raoul41" },
                    { 300, 31, "Stanford.Bashirian80@yahoo.com", "Doug", "Kuphal", "s5IwsC9ln8", 2, "Torrance13" },
                    { 38, 170, "Dianna_Connelly@yahoo.com", "Everardo", "Altenwerth", "y0970drn1z", 2, "Cruz.Hartmann" },
                    { 11, 23, "Yazmin8@gmail.com", "Aliza", "Thompson", "69FKcHPuNh", 2, "Cyrus.Simonis24" },
                    { 276, 187, "Olen_Smith33@gmail.com", "Prudence", "Hauck", "DvTf5i0t2q", 3, "Uriah_Weimann" },
                    { 211, 17, "Wade_Grady34@yahoo.com", "Murl", "Gibson", "GNvg26DmmZ", 2, "Bertha_Kris" },
                    { 165, 84, "Melody_Skiles47@hotmail.com", "Maxime", "Halvorson", "19hHluFfT0", 3, "Easter80" },
                    { 188, 106, "Cristal26@gmail.com", "Claudie", "Aufderhar", "tOPmrAx9Rs", 3, "Kristopher_Trantow37" },
                    { 158, 299, "Edythe59@yahoo.com", "Miles", "Schuppe", "PZ6A_mzlfy", 1, "Jalen_Welch" },
                    { 120, 93, "Reilly_Schneider@yahoo.com", "Leonora", "Zemlak", "Lb9ORT6TF8", 1, "Jon_Graham95" },
                    { 3, 120, "Dedric80@gmail.com", "Emelie", "Rau", "Wb9pxW0Dr4", 2, "Ernesto_Carroll90" },
                    { 260, 217, "Glen_Spencer29@gmail.com", "Donnie", "Kiehn", "ZWC_DGQkG9", 1, "Jonas70" },
                    { 25, 21, "Hermina76@yahoo.com", "Madaline", "Reynolds", "6t7IteazY3", 1, "Edwardo.Miller4" },
                    { 123, 21, "Myrna_Herman@gmail.com", "Vicente", "Zboncak", "7s3ZO0XDqP", 3, "Camryn.Gulgowski92" },
                    { 148, 84, "Lorna58@gmail.com", "Kaelyn", "Waters", "XE5064kwKn", 3, "Janessa_Wyman29" },
                    { 161, 84, "Jackson.Roob40@gmail.com", "Casimir", "Veum", "PsjVUsddT_", 3, "Johnny78" },
                    { 264, 170, "Saul.Mayer@yahoo.com", "Cassie", "Yundt", "o4yIrDDC9N", 2, "Abdiel87" },
                    { 246, 167, "Zakary.Willms59@yahoo.com", "Damon", "Crona", "6QZhX5xWjG", 1, "Deborah.McKenzie" },
                    { 151, 52, "Vinnie.Bayer51@yahoo.com", "Issac", "Prohaska", "LQD4WBBJpY", 2, "Vince_Ankunding" },
                    { 234, 52, "Danial.OConner@hotmail.com", "Carolyn", "Koss", "H7fQ1JDM7B", 2, "Delbert99" },
                    { 227, 146, "Sage_Carroll@hotmail.com", "Alvis", "Luettgen", "2s1Ydg8_Cg", 2, "Jarvis.Schuppe56" },
                    { 127, 258, "Shayne_Schuppe@yahoo.com", "Keshaun", "Kunze", "4Bx2NsOEdw", 1, "Kylee95" },
                    { 82, 113, "Ike22@hotmail.com", "Riley", "Grant", "2QzNp5i709", 2, "Lia70" },
                    { 164, 153, "Reymundo55@yahoo.com", "Monroe", "Ritchie", "LLTgho1HYn", 1, "Vida_Frami84" },
                    { 247, 19, "Halie98@hotmail.com", "Robyn", "Maggio", "dFE3VMctxQ", 2, "Don_Hand" },
                    { 19, 133, "Aric_Emmerich23@hotmail.com", "Ernie", "Nitzsche", "VdXmzzDaVL", 3, "Amely.Schuppe58" },
                    { 172, 234, "Corene_Bernhard92@hotmail.com", "Randi", "Schuppe", "775dQP_JlT", 3, "Bernice.Paucek" },
                    { 232, 234, "Madonna59@gmail.com", "Syble", "Turner", "gdB5o4Gfpn", 2, "Aiden86" },
                    { 282, 4, "Jazlyn.Heaney@gmail.com", "Amalia", "Schmidt", "zxHTnF7vTs", 1, "Marcellus_Ebert87" },
                    { 22, 140, "Presley53@gmail.com", "Lionel", "Wunsch", "EBJE6MEEqv", 3, "Willis.Windler" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 202, 140, "Alaina_Hyatt@yahoo.com", "Edythe", "Fadel", "JhPo3NGSmf", 3, "Adeline.Bruen" },
                    { 216, 140, "Antwan.Ankunding14@hotmail.com", "Royal", "Harvey", "GbWitQ8giz", 2, "Mariah_Cronin73" },
                    { 74, 106, "Diana16@hotmail.com", "Vern", "McKenzie", "c63oraioMc", 1, "Jaeden.Little" },
                    { 166, 17, "Estefania.Gutmann62@gmail.com", "Lucy", "Lesch", "mVp7i80Alr", 1, "Allen77" },
                    { 183, 100, "Shannon91@yahoo.com", "Leola", "Herman", "zVLr_PO_Pz", 2, "Ubaldo14" },
                    { 102, 273, "Desmond75@yahoo.com", "Sylvester", "Lehner", "vdacrK8L5y", 2, "Malachi.Monahan99" },
                    { 206, 6, "Jordane10@gmail.com", "Keenan", "Daniel", "0M8yzsVarY", 1, "Jessie.Medhurst88" },
                    { 266, 139, "Lavonne83@gmail.com", "Leland", "Borer", "KDsSFUAOVV", 3, "Brett58" },
                    { 226, 68, "Fermin.Glover83@gmail.com", "Celestine", "Wiegand", "2sLCiKuuvQ", 3, "Cullen.Hagenes" },
                    { 243, 68, "Paula94@yahoo.com", "Mattie", "Frami", "2EQTtPO9Fb", 1, "Wilmer_Blick61" },
                    { 78, 159, "Daisha.Herzog35@hotmail.com", "Narciso", "Jast", "cHNZuw40QV", 1, "Bobbie20" },
                    { 263, 159, "Eldridge59@hotmail.com", "Jaiden", "Herzog", "HvNfJokstp", 2, "Kamron_Huels2" },
                    { 136, 177, "Annamae57@hotmail.com", "Durward", "Borer", "BF9oqiZaPo", 3, "Emil_Hane" },
                    { 52, 299, "Thelma.Upton@hotmail.com", "Alf", "Crist", "M75PD6GWyG", 2, "Eliseo_Legros" },
                    { 277, 284, "Rogers.Cole88@gmail.com", "Darby", "Wuckert", "d560Ub0W0v", 2, "Isai_OKeefe" },
                    { 251, 132, "Walker.Stokes@yahoo.com", "Alvera", "Nitzsche", "NEiXRcz_rU", 2, "Owen_Boyle75" },
                    { 80, 213, "Yasmine.Dicki@gmail.com", "Kaitlyn", "Kiehn", "ybqD1loYdq", 1, "Haven_Cummings31" },
                    { 100, 280, "Olga46@hotmail.com", "Ulises", "Wintheiser", "pt9Q2UkDx5", 2, "Reinhold_Langosh99" },
                    { 154, 103, "Maximus.Ryan@yahoo.com", "Virginia", "O'Kon", "9yOuR3AjR0", 2, "Chadd_Hilpert39" },
                    { 96, 55, "Amir.Mante@gmail.com", "Madie", "Hane", "AOUUct8dFy", 3, "Larue_Feeney" },
                    { 235, 55, "Jesus27@yahoo.com", "Leanna", "Jakubowski", "YnEnssi8ub", 1, "Daniela_Hudson" },
                    { 192, 34, "Earnest_Maggio@hotmail.com", "Gerry", "Corkery", "9DCuS0Qxr0", 1, "Erling82" },
                    { 193, 155, "Loren3@gmail.com", "Osbaldo", "Kihn", "77KPAsHaNc", 3, "Cicero.Considine" },
                    { 142, 51, "Keaton44@gmail.com", "Frankie", "Maggio", "6ede_Rc1un", 3, "Granville42" },
                    { 240, 51, "Rosa50@gmail.com", "Jennifer", "Pfannerstill", "T3OcfYAU24", 3, "Madilyn.Lubowitz" },
                    { 24, 9, "Ena10@yahoo.com", "Jeromy", "MacGyver", "yX9FT7LIAV", 2, "Carrie.Stiedemann14" },
                    { 231, 9, "Skylar.Welch@hotmail.com", "Citlalli", "Howell", "hKZm7UNTEF", 1, "Dimitri_Dietrich1" },
                    { 105, 112, "Aracely.Smitham@gmail.com", "Laila", "Runte", "LAvPhVmbYA", 3, "Kaylie_Graham30" },
                    { 203, 112, "Kole26@yahoo.com", "Alta", "Emmerich", "2BqVe5qnWT", 3, "Darian9" },
                    { 58, 161, "Aiden93@gmail.com", "Gayle", "Keeling", "r_Zd3HPmJ9", 1, "Florine12" },
                    { 249, 161, "Landen.OConner@gmail.com", "Hulda", "Lockman", "31U1NwgD8x", 1, "Lenna.VonRueden55" },
                    { 197, 55, "Madaline99@hotmail.com", "Lee", "Goyette", "uD7sxFDReg", 1, "Lia79" },
                    { 153, 103, "Ernestine_Goldner37@hotmail.com", "Marty", "Zemlak", "d6L5vaMGx4", 2, "Chance1" },
                    { 138, 103, "Kyle.McCullough30@hotmail.com", "Janiya", "Lindgren", "Xy0_ITPyJu", 2, "Lexie_Kozey" },
                    { 253, 231, "Kaleb_Morissette@yahoo.com", "Winnifred", "Stracke", "08cowZZwGb", 3, "Kaylah3" },
                    { 131, 82, "Aliya1@gmail.com", "Jake", "Weber", "PxCejbNlRj", 2, "Shane99" },
                    { 230, 82, "Chester.Treutel@yahoo.com", "Milo", "Hammes", "TGS7CD3YI5", 3, "Randy_Wilderman" },
                    { 155, 228, "Amira40@yahoo.com", "Johann", "Goodwin", "37HPWo4LHz", 1, "Joshuah24" },
                    { 173, 228, "Nannie_Schoen@hotmail.com", "Else", "Treutel", "HiXT76Ldfl", 1, "Queen.Blick87" },
                    { 65, 244, "Tyree28@gmail.com", "Austen", "Kuhlman", "qJhbIQclhA", 2, "Maegan_Kuphal" },
                    { 156, 89, "Anne.Langosh@yahoo.com", "Mohammad", "Dach", "lU8WnTBXAa", 3, "Jesus_Ritchie59" },
                    { 168, 89, "Jamel.Davis@hotmail.com", "Gust", "Cormier", "zMOh0q_mB9", 1, "Delores.Price7" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 106, 232, "Jazmin_Mann@yahoo.com", "Billy", "Hudson", "whhzzBve3D", 1, "Delphine5" },
                    { 279, 67, "Lemuel27@yahoo.com", "Astrid", "Bins", "3YEGUa0V59", 1, "Grayson.Abshire63" },
                    { 121, 144, "Vena.OReilly@gmail.com", "Laverna", "Bradtke", "b6X_KNpNNb", 3, "Everett51" },
                    { 196, 166, "Guy.Price25@hotmail.com", "Amelia", "McGlynn", "vbrqW34rF6", 2, "Immanuel_Howell80" },
                    { 241, 212, "Zachariah83@gmail.com", "Unique", "Strosin", "ERah9f8KjW", 3, "Friedrich.Spinka" },
                    { 295, 212, "Frederick_Bayer77@gmail.com", "Kylie", "Shanahan", "RopVysqFGl", 1, "Geovany90" },
                    { 40, 174, "Wyatt_Daniel@hotmail.com", "Murray", "Blanda", "y0trekiL4n", 1, "Gonzalo12" },
                    { 12, 216, "Maritza.Howe@gmail.com", "Sidney", "Kuphal", "8LcXPk_vMw", 1, "Henderson.Emmerich27" },
                    { 256, 216, "Aylin93@hotmail.com", "Annabell", "Bayer", "nB_jgdFYLi", 3, "Vern_McDermott58" },
                    { 133, 273, "Stephen.Fay@yahoo.com", "Quentin", "Feil", "3rwXRnbxO4", 3, "Johnnie53" },
                    { 175, 65, "Nicholaus.Corkery51@gmail.com", "Newell", "Medhurst", "cnvlnsrAxn", 2, "Shane_Littel" },
                    { 250, 105, "Ludie_Harris21@gmail.com", "Evalyn", "Fritsch", "VHwXm3zK3o", 1, "Otho.Ratke" },
                    { 103, 201, "Bennie.Kilback85@hotmail.com", "Jane", "Langworth", "zREGOOe9RU", 3, "Elissa_Maggio40" },
                    { 107, 226, "Judson86@yahoo.com", "Grayce", "Reichel", "j4qDgZgOAX", 3, "Gertrude.Greenholt40" },
                    { 8, 231, "Kyle51@hotmail.com", "Griffin", "Hickle", "SLQdQanEyx", 2, "Oren54" },
                    { 34, 231, "Alicia76@yahoo.com", "Jerry", "Braun", "cejQrwWjTu", 2, "Madilyn.Donnelly" },
                    { 159, 231, "Julian_Strosin22@yahoo.com", "Leopold", "Wunsch", "KTDB0Spbl1", 1, "Marshall45" },
                    { 217, 231, "Camylle_Bosco88@hotmail.com", "Eleazar", "Treutel", "78zeIxNpi5", 3, "Jed17" },
                    { 191, 6, "Gunnar_Dooley@yahoo.com", "Bryana", "Ryan", "RIXUZBWiMr", 2, "Cooper37" },
                    { 233, 243, "Sarah.Schamberger10@hotmail.com", "Willis", "Turner", "kpLmfScG1A", 2, "Derek45" },
                    { 1, 76, "Orrin19@yahoo.com", "Kayla", "Denesik", "QKg68Im4vI", 1, "Carol.Wisoky21" },
                    { 92, 48, "Sedrick71@gmail.com", "Hank", "O'Keefe", "FL1FUnEywk", 2, "Anjali.Becker55" },
                    { 258, 127, "Sven_West@gmail.com", "Delpha", "Ebert", "ih_kTMuC7d", 2, "Chris78" },
                    { 20, 127, "Telly_DuBuque31@yahoo.com", "Tamia", "VonRueden", "ZTKolpZCZF", 2, "Abbey80" },
                    { 257, 39, "Norval_Kuphal@yahoo.com", "Maribel", "Runolfsdottir", "arwLnSIdy6", 2, "Kris8" },
                    { 205, 39, "Titus.Tromp@yahoo.com", "Loma", "O'Kon", "8zmt4NpJR1", 1, "Marilie.Ondricka" },
                    { 53, 39, "Coby_Monahan2@yahoo.com", "Carmelo", "Herzog", "MAJKpw9SdQ", 2, "Lessie_Cummings39" },
                    { 271, 94, "Russell40@hotmail.com", "Otho", "McCullough", "NVVtyTx1bS", 1, "Ollie_Skiles" },
                    { 28, 94, "Easton.Tromp@gmail.com", "Ayana", "Gerhold", "K6LRZybHqe", 1, "Kelly_Witting37" },
                    { 299, 261, "Oceane97@hotmail.com", "Maxime", "Senger", "lhCwIPqdz6", 1, "Jeremie.Satterfield" },
                    { 186, 261, "Emmalee24@yahoo.com", "Wellington", "Barrows", "zeXbDK9Q1p", 1, "Weldon90" },
                    { 39, 261, "Camden6@hotmail.com", "Tracy", "Gorczany", "V0ZNU19xHk", 3, "Elza.Moen" },
                    { 132, 245, "Giovanni45@gmail.com", "Mack", "Schamberger", "c3ueptL7Q3", 1, "Bruce85" },
                    { 150, 90, "Rosamond.Daugherty82@hotmail.com", "Isaiah", "Morissette", "1mqDn5062t", 2, "Patsy.Borer" },
                    { 236, 297, "Neoma_Hills@hotmail.com", "Josiane", "Bogan", "ygszLk6zpm", 1, "April_Shields" },
                    { 116, 107, "Jerald.Steuber@gmail.com", "Elvis", "Gibson", "Kuuu0_dPfc", 3, "Xavier.Runte" },
                    { 62, 107, "Roxanne96@yahoo.com", "Boyd", "Morar", "84U60UAoFM", 2, "Allan.Gottlieb33" },
                    { 190, 135, "Sharon92@hotmail.com", "Janice", "Connelly", "VddM0HbYOe", 2, "Mckenzie73" },
                    { 280, 147, "Tessie_Simonis@hotmail.com", "Agustin", "Hahn", "_2cvPHbPbI", 1, "Morgan90" },
                    { 248, 254, "Marquis_Maggio51@gmail.com", "Tierra", "Zieme", "Ej4iYTUlJD", 3, "Coty_Nitzsche" },
                    { 118, 254, "Gay.Corwin17@hotmail.com", "Torey", "Mitchell", "dmPSlolyVj", 2, "Gage95" },
                    { 94, 125, "Fabiola21@yahoo.com", "Arnaldo", "Farrell", "TzwifzAEbl", 1, "Rusty.Wunsch2" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 55, 250, "Shirley.Kirlin16@yahoo.com", "Emerson", "Haley", "FSmEX9lZzW", 3, "Velda.Lebsack2" },
                    { 73, 109, "Jermaine.Heidenreich77@hotmail.com", "Marcelino", "Effertz", "NtTuof0uq5", 1, "Tressa.Hammes" },
                    { 228, 109, "June.Bode98@yahoo.com", "Otto", "Olson", "cnuO4VIoFb", 2, "Kathleen_Botsford" },
                    { 209, 239, "Maegan.Bartoletti7@hotmail.com", "Caroline", "DuBuque", "kZ0L3XRwiJ", 2, "Ken_Flatley94" },
                    { 104, 239, "Demarco32@yahoo.com", "Tristin", "Ledner", "h57PJnNFnc", 3, "Valerie14" },
                    { 212, 256, "Dashawn_Romaguera@gmail.com", "Adolfo", "Crooks", "0yauliRBTJ", 3, "Jaden_OReilly24" },
                    { 176, 296, "Filomena_Bradtke22@yahoo.com", "Gerhard", "Schimmel", "D7ygtAqft6", 3, "Pete.Dickens32" },
                    { 18, 296, "Elouise_Champlin93@hotmail.com", "Mabel", "Zulauf", "UoXZZ0HKwH", 1, "Freida.Donnelly68" },
                    { 224, 44, "Emma_Paucek@hotmail.com", "Filomena", "Welch", "T0rNttMCfl", 3, "Ryder_Sipes" },
                    { 198, 44, "Christine14@gmail.com", "Marley", "Beatty", "1mtDz22WQT", 1, "Jaren_Schmidt73" },
                    { 43, 44, "Bryana.Ruecker82@yahoo.com", "Mavis", "Abernathy", "B0lXFXY5Dh", 2, "Queen67" },
                    { 289, 12, "Keara_Abernathy54@gmail.com", "Stella", "Harber", "r8pXaOILEH", 1, "Reuben_Vandervort" },
                    { 70, 8, "Maverick12@hotmail.com", "Makayla", "Kling", "gn4uw4qX6D", 1, "Ruth69" },
                    { 108, 12, "Jeff.Mohr@yahoo.com", "Joesph", "Roob", "EjUl6TyVIK", 3, "Neal.Hartmann" },
                    { 44, 229, "Violet52@gmail.com", "Oran", "Graham", "CXeWiyYgTx", 1, "Jorge21" },
                    { 187, 121, "Ernest40@hotmail.com", "Eddie", "O'Hara", "01BPd1nbkv", 1, "Rae.Olson" },
                    { 204, 259, "Marion.Schuster@yahoo.com", "Ward", "Trantow", "fqp_3opVPZ", 1, "Quinten52" },
                    { 48, 259, "Mary_Reinger87@gmail.com", "Kody", "Greenfelder", "6PrEKfKj_x", 2, "Ernie_Von1" },
                    { 225, 197, "Bill33@yahoo.com", "Broderick", "D'Amore", "HPDu6K2tjZ", 3, "Salvador.Kris1" },
                    { 27, 197, "Lurline_Block32@yahoo.com", "Rebeka", "Parker", "PCc6qUbHjN", 1, "Lia_Rau25" },
                    { 149, 145, "Reva.Cruickshank@yahoo.com", "Marietta", "Tremblay", "DUxfvJELJg", 1, "Alvina84" },
                    { 290, 83, "Alec_Zemlak@yahoo.com", "Marjolaine", "Stehr", "XjQyLTkaAl", 2, "Terrell_Koch" },
                    { 269, 109, "Odie68@yahoo.com", "Rodrigo", "Jakubowski", "9h2WIkGHgl", 2, "Susanna.OKeefe" },
                    { 122, 229, "Malcolm.Little52@hotmail.com", "Lelah", "Will", "cnztziLg9g", 3, "Dahlia.Homenick" },
                    { 281, 239, "Jess_Cartwright@gmail.com", "Maxime", "Beier", "MzYt9jtYDh", 2, "America_Towne" },
                    { 91, 165, "Orpha.Russel@yahoo.com", "Halle", "Larkin", "37QJ77hfwQ", 3, "Blanche_Feest87" },
                    { 297, 169, "Alek38@yahoo.com", "Hallie", "Kemmer", "VsnOvfIJCS", 2, "Hilton.Keebler82" },
                    { 255, 99, "Cletus_Hilpert62@yahoo.com", "Reid", "Ullrich", "GZng4xGvqL", 2, "Sydnee71" },
                    { 50, 99, "Emanuel_OHara@hotmail.com", "Anibal", "Schuppe", "hyMFVtTeZM", 1, "Brenda21" },
                    { 261, 29, "Melody66@yahoo.com", "Carmen", "D'Amore", "w331OJFyKt", 1, "Ceasar65" },
                    { 252, 29, "Brooke_Beer@gmail.com", "Joseph", "Koelpin", "ccy81q_f1Q", 2, "Desmond.Smitham92" },
                    { 218, 29, "Courtney_Kuhn@yahoo.com", "Adrienne", "Beer", "OeB4maVlEj", 3, "Lukas_Borer" },
                    { 189, 218, "Margie.Legros92@hotmail.com", "Adolphus", "Lang", "x8KSh3Rg8g", 1, "Peyton_Hilpert" },
                    { 141, 115, "Norbert.Batz@gmail.com", "Juliana", "Pagac", "93zJPqJElR", 2, "Watson_Zieme" },
                    { 273, 16, "Maxime_Weber29@gmail.com", "Lottie", "Marquardt", "Lp_pfyrbX_", 3, "Ellen_Morar" },
                    { 267, 16, "Deangelo97@hotmail.com", "Daron", "Jerde", "UeVN0OOVSe", 1, "Bernice_Jenkins" },
                    { 67, 16, "Tressie66@gmail.com", "Brice", "Baumbach", "V9QtpfQfvy", 3, "Rosanna.Zboncak82" },
                    { 46, 266, "Brigitte58@gmail.com", "Fabiola", "DuBuque", "UrKkBw9QJD", 2, "Roberto10" },
                    { 199, 200, "Janice_Jakubowski@hotmail.com", "Araceli", "Lockman", "gv3UgCX5NX", 3, "Humberto_Ernser" },
                    { 83, 200, "Devin25@hotmail.com", "Tyler", "Zemlak", "a4rwAwn8Yc", 3, "Noel_Rempel80" },
                    { 81, 200, "Marilie77@yahoo.com", "Eriberto", "Becker", "MCC_zeFpsF", 2, "Dusty.Larson34" },
                    { 152, 260, "Lucas.Roberts5@gmail.com", "Carolina", "Ledner", "CNNzQ9a_PI", 2, "Dario89" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 7, 260, "Dana.Ernser@hotmail.com", "Jaclyn", "Koepp", "sBfUafQC00", 2, "Malvina_Kessler5" },
                    { 54, 202, "Timothy_Howe@gmail.com", "Isai", "Emard", "K_9wu0ZOzn", 1, "Mireya_Harber6" },
                    { 229, 46, "Kyleigh75@yahoo.com", "Kurtis", "Schoen", "w2l9ARE9qn", 3, "Edwina.Hermann" },
                    { 157, 46, "Evie97@gmail.com", "Werner", "Rippin", "gaiFneOF3B", 1, "Brenna68" },
                    { 29, 163, "Helga.Medhurst53@gmail.com", "Desmond", "Rowe", "zFcM44t7NN", 1, "Hollis77" },
                    { 143, 163, "Rosalinda_Runolfsson85@hotmail.com", "Zechariah", "Keebler", "SmBZc_tcy5", 2, "Tyson_Prohaska18" },
                    { 76, 208, "Cali78@gmail.com", "Jaeden", "Lueilwitz", "cnvqNcB77F", 3, "Dylan.Gutmann" },
                    { 86, 298, "Rey.Effertz21@gmail.com", "Kali", "Terry", "d7EQwxLrO6", 2, "Elizabeth.Ullrich10" },
                    { 2, 130, "Maximilian_McClure@gmail.com", "Xavier", "Bins", "VfPjxYRp3b", 3, "Ezequiel39" },
                    { 128, 227, "Dillan.Heidenreich@yahoo.com", "Judah", "Braun", "YSIHRNLS27", 2, "Rahul81" },
                    { 101, 117, "Dejon.Wisoky69@yahoo.com", "Dennis", "Hartmann", "V5ALprrgF2", 1, "Rylee_Reilly79" },
                    { 56, 117, "Danielle_Heller@hotmail.com", "Francisca", "Bradtke", "LGvsiHzdyd", 1, "Adrien7" },
                    { 178, 41, "Mariam.Flatley78@hotmail.com", "Fannie", "Schmitt", "A509ivZEfF", 1, "Abigail_Green94" },
                    { 220, 126, "Mayra6@hotmail.com", "Jay", "Reinger", "2uefalwblh", 2, "Stuart.Aufderhar46" },
                    { 287, 47, "Gaylord_Braun88@hotmail.com", "Orpha", "Hintz", "MvHjaP1Taq", 2, "Wyman_Legros" },
                    { 223, 47, "Jazmin83@hotmail.com", "Callie", "Tromp", "SoBgjsUjSK", 2, "Mike11" },
                    { 21, 47, "Kristian57@hotmail.com", "Otilia", "Aufderhar", "KOu5h_IL_X", 1, "Marcelle.Emmerich70" },
                    { 293, 137, "Jaime_Labadie67@yahoo.com", "Adrien", "Flatley", "6jUUpFCxfW", 3, "Ryder.Kohler69" },
                    { 59, 168, "Jarred.Konopelski86@yahoo.com", "Ashly", "Raynor", "X9YbK1Lzqd", 2, "Jodie_Barton" },
                    { 208, 64, "Carol_Miller@hotmail.com", "Avis", "Murazik", "MglCi4a7BK", 1, "Yvette.Rowe" },
                    { 32, 27, "Germaine.Ritchie@yahoo.com", "Mable", "Vandervort", "XKvajpQGub", 2, "Monroe81" },
                    { 262, 288, "Albina_Roberts66@yahoo.com", "Consuelo", "Schroeder", "xJL06qihRm", 1, "Pasquale.Pouros97" },
                    { 163, 291, "Orie47@gmail.com", "Oran", "Becker", "RmIRzei0r1", 3, "Alessandra50" },
                    { 75, 54, "Arlene1@hotmail.com", "Agustina", "Hermiston", "VaeMCxZmNA", 3, "Juvenal.Koch98" },
                    { 285, 196, "Alexie.Lesch67@hotmail.com", "Buddy", "Nikolaus", "pWgp2qj_Z8", 2, "Delores_Quitzon" },
                    { 207, 196, "Lamar12@hotmail.com", "Christian", "Heidenreich", "fhsbDZYkfD", 2, "Francisco16" },
                    { 213, 69, "Carmella.Ortiz33@yahoo.com", "Leo", "Swift", "n87JPIN_oQ", 2, "Vada6" },
                    { 147, 298, "Victor.Walter77@gmail.com", "Isobel", "Ledner", "emyf5ja3Jb", 2, "Johnathon40" },
                    { 35, 78, "Ernesto.Dare@hotmail.com", "Lola", "Ratke", "nn5ttLBaE2", 1, "Chanel17" },
                    { 137, 247, "Helga44@hotmail.com", "Ike", "Breitenberg", "246qy7Jfyj", 3, "Armand66" },
                    { 195, 269, "Caesar_Gerlach28@yahoo.com", "Everardo", "Pouros", "Oe9f74nIZl", 1, "Cora41" },
                    { 215, 269, "Sedrick33@hotmail.com", "Reyna", "Jacobi", "0mK1abp8t7", 1, "Carter44" },
                    { 298, 223, "Rosalee86@hotmail.com", "Maida", "Tremblay", "dv_BvKTPu4", 3, "Gust.Aufderhar" },
                    { 85, 199, "Robb.Bernhard@yahoo.com", "Kathlyn", "Fisher", "wRkR4PM6fp", 3, "Asha.Goodwin" },
                    { 45, 199, "Zelma.Schiller52@yahoo.com", "Evangeline", "Leannon", "R14NktWRpU", 1, "Magnolia.Gislason" },
                    { 265, 186, "Myrtie_Anderson85@yahoo.com", "Darrel", "Balistreri", "xf7h3VJVIi", 1, "Kayden87" },
                    { 259, 186, "Odell.Hintz83@yahoo.com", "Elna", "Wilkinson", "OXhjxOY8hF", 1, "Devon_Witting28" },
                    { 49, 186, "Geoffrey2@gmail.com", "Marie", "Lemke", "384iDjnflT", 3, "Ricardo.Romaguera" },
                    { 6, 186, "Jacinto67@yahoo.com", "Dexter", "Reinger", "Gv7NQEp7OQ", 2, "Gerry_Yundt32" },
                    { 111, 74, "Dortha43@gmail.com", "Oran", "Cole", "oVdZVW4nME", 3, "Brenden3" },
                    { 63, 74, "Lexi_Reynolds@gmail.com", "Jadyn", "Jacobson", "bGTD3oVc4Q", 1, "Kane_Heathcote" },
                    { 17, 28, "Rocky.Heller39@gmail.com", "Jacey", "Armstrong", "12Dg9Wavwx", 1, "Elda_Schamberger90" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 288, 148, "Della.Corkery62@gmail.com", "Schuyler", "Satterfield", "0wJ2GFD2cy", 3, "Fabiola.Kerluke79" },
                    { 90, 148, "Lawson_Borer79@gmail.com", "Adriana", "Gottlieb", "D_9eWNeN1I", 3, "Luna_Hane16" },
                    { 291, 114, "Lennie.Auer78@gmail.com", "Chyna", "Hahn", "_6dqoqass7", 1, "Romaine.Simonis23" },
                    { 200, 114, "Mollie.Kassulke77@yahoo.com", "Lexus", "Zulauf", "I2aCD0SI37", 1, "Naomie_Streich99" },
                    { 10, 66, "Jamil_Kautzer@yahoo.com", "Maeve", "Hackett", "NwYzoidLil", 3, "Hardy18" },
                    { 77, 25, "Maeve.Herman73@hotmail.com", "Angela", "West", "y2q4kujAE4", 3, "Madeline58" },
                    { 61, 154, "Brandi.Emard32@yahoo.com", "Delia", "Paucek", "DYEsSjUPMA", 3, "Jamil_Breitenberg0" },
                    { 145, 222, "Romaine11@hotmail.com", "Roslyn", "Brekke", "B2jtr5fxt1", 2, "Cleta16" },
                    { 296, 262, "Vaughn74@yahoo.com", "Gussie", "Rodriguez", "oDB9e3nEFu", 1, "Micaela.Gislason6" },
                    { 57, 230, "Estelle74@hotmail.com", "Richmond", "Turner", "RvosJquf1q", 1, "Elena22" },
                    { 160, 230, "Zakary_Sporer@hotmail.com", "Mittie", "Gutmann", "m9F8PN3W8D", 2, "Keyon_Wiza" },
                    { 270, 75, "Rashad.Moen@hotmail.com", "Brianne", "Ledner", "WZAFqry3d8", 3, "Priscilla_Green74" },
                    { 113, 290, "Braulio.Durgan@yahoo.com", "Geovanny", "Towne", "mtU2N8QJ5w", 3, "Raina8" },
                    { 238, 241, "Maybell.Boyle@gmail.com", "Janelle", "Feeney", "stGbmi1nzV", 3, "Viola_Trantow" },
                    { 9, 241, "Alaina.Stiedemann@hotmail.com", "Katlyn", "Kuhic", "rfsYZuLe9l", 1, "Lance.Purdy99" },
                    { 97, 236, "Gus_Fay@yahoo.com", "Alba", "Nikolaus", "Jolwt1WpZw", 2, "Johathan.Deckow25" },
                    { 286, 279, "Granville_Franecki@yahoo.com", "Kiana", "Sauer", "ZsulcYbZDs", 1, "Fern.Schuppe" },
                    { 214, 279, "Stuart58@hotmail.com", "Christina", "Bechtelar", "Yefz9cyn0D", 1, "Antonietta.Sipes95" },
                    { 15, 279, "Bernhard_Gorczany55@hotmail.com", "Kris", "Howell", "HScEf28CV9", 3, "Nicole19" },
                    { 278, 252, "William.Botsford96@yahoo.com", "Carmen", "Herzog", "DCQXT6wE4u", 3, "Mabel.Oberbrunner" },
                    { 174, 252, "Ernestina27@yahoo.com", "Mac", "Cronin", "Hp8ksK6IRT", 1, "Hettie54" },
                    { 72, 252, "Daniella54@yahoo.com", "Brendon", "Koch", "s80MdetgO1", 1, "Odie54" },
                    { 140, 262, "Anne20@yahoo.com", "Constantin", "Gutkowski", "skZazTJs_m", 2, "Cletus.Heidenreich95" },
                    { 37, 252, "Burnice_Cartwright63@gmail.com", "Ara", "Emard", "6SGcST3rOL", 2, "Elisabeth.Mayer41" },
                    { 272, 32, "Fannie_Smith22@gmail.com", "Kayden", "Moore", "1zr4YGNC17", 3, "Desiree24" },
                    { 292, 219, "Rachel.Dicki@yahoo.com", "Amaya", "Howe", "8cluU5_GJE", 3, "Idell_Toy" },
                    { 95, 162, "Gardner.Jast9@gmail.com", "Taya", "Keebler", "HDIED6eYev", 1, "Chanelle46" },
                    { 42, 162, "Ruben21@gmail.com", "Guadalupe", "Douglas", "zUEThMjUwt", 3, "Josie98" },
                    { 219, 237, "Annetta93@yahoo.com", "Krystina", "Denesik", "ByzXhUNUGe", 1, "Margret.Upton49" },
                    { 124, 235, "Cade.Russel@hotmail.com", "Sim", "Blick", "lt0YqQXTH9", 2, "Granville_Frami35" },
                    { 201, 136, "Lilian_Anderson48@yahoo.com", "Sammie", "Sporer", "e6A7fODVDI", 2, "Royal_Schuster63" },
                    { 167, 136, "Dusty52@hotmail.com", "Hanna", "Leannon", "sOoDVkrmlT", 1, "Lucienne47" },
                    { 171, 73, "Cortney50@gmail.com", "Arden", "Swaniawski", "Brh0p5_NL2", 2, "Brody_Larkin" },
                    { 139, 277, "Lea_Kub@gmail.com", "Mattie", "Cronin", "AYqfZGvxzn", 1, "Bert_Schneider71" },
                    { 268, 108, "Waldo_Beatty@yahoo.com", "Madison", "Keebler", "o_0cyMxCpn", 3, "Dallin.Wiza58" },
                    { 179, 108, "Fannie58@hotmail.com", "Rickie", "Greenfelder", "A6CY9XYGca", 2, "Kitty_Feest49" },
                    { 242, 33, "Arnaldo.Olson@yahoo.com", "Garnett", "Kertzmann", "X6nyt1bF_4", 1, "Elsie.Dare91" },
                    { 23, 58, "Althea_Feest@gmail.com", "Osbaldo", "Bernier", "GkCJU3EOv6", 1, "Catherine.Herzog9" },
                    { 87, 270, "Dallas0@gmail.com", "Solon", "Medhurst", "8kwbqJi8fw", 1, "Izaiah.Shields9" },
                    { 60, 270, "Napoleon57@yahoo.com", "Christina", "Mante", "fVo63yFJlA", 2, "Lura.OKeefe" },
                    { 146, 265, "Alvah35@yahoo.com", "Rocio", "Rath", "3jgxyGl53K", 2, "Helga.Klein" },
                    { 89, 142, "Nelle.Swaniawski@gmail.com", "Erwin", "Konopelski", "Ev_mo_t68i", 2, "Toby.Bauch" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 245, 221, "Jewell65@gmail.com", "Waldo", "Schmitt", "Z5XG9ZD2en", 3, "Elisabeth_Hudson" },
                    { 162, 221, "Frieda.Koepp40@yahoo.com", "Brycen", "Murphy", "UZdNttI2jM", 1, "Angelina.Hermann" },
                    { 134, 221, "Jaime_Deckow@gmail.com", "Porter", "Wehner", "sHaa1x8bOs", 2, "Cierra_West90" },
                    { 93, 221, "Jorge_Kuvalis@gmail.com", "Franz", "Auer", "R2jJpOBbDL", 1, "Gideon.Cummerata" },
                    { 129, 58, "Demarcus_Boyle@gmail.com", "Dejon", "Zulauf", "r25vyTrjh4", 2, "Jesse35" },
                    { 194, 129, "Silas_Kovacek96@hotmail.com", "Lysanne", "Gerhold", "VKvcX_lNih", 3, "Pamela71" },
                    { 51, 110, "Cordie62@yahoo.com", "Asha", "Tromp", "AVbO409iVu", 1, "Fidel_Sanford" },
                    { 16, 110, "Quinten_Gaylord20@yahoo.com", "Clyde", "Crona", "mOpjsBxmlN", 2, "Natalie54" },
                    { 13, 110, "Lucius_Buckridge@hotmail.com", "Bruce", "Goodwin", "aptcUkegSo", 1, "Hermann49" },
                    { 185, 53, "Marilie_Borer68@hotmail.com", "Guadalupe", "Hilpert", "gYBMyUOpEI", 2, "Favian89" },
                    { 117, 53, "Selena.Morar11@yahoo.com", "Eva", "Daniel", "qtcl93UmKv", 2, "Braden39" },
                    { 47, 53, "Kaylee.Botsford@hotmail.com", "Deron", "Von", "w0mejKjVDo", 1, "Susan19" },
                    { 36, 264, "Hailey43@gmail.com", "Laury", "Hartmann", "mIZ7R4AlWt", 1, "Javon92" },
                    { 170, 189, "Margaretta45@yahoo.com", "Bria", "Stehr", "DymleLBMa2", 2, "Adele.Kertzmann55" },
                    { 283, 281, "Florence0@gmail.com", "Hildegard", "Bayer", "XOLSbu41TC", 2, "Assunta14" },
                    { 110, 129, "Ivy.Jerde84@gmail.com", "Madelynn", "Daniel", "iAzyrzaRGy", 3, "Filomena_Terry34" },
                    { 135, 48, "Eldora.Hagenes@gmail.com", "Erich", "Maggio", "taU2_l4Zz7", 1, "Marcella.Johnson" },
                    { 68, 173, "Ned20@hotmail.com", "Lavon", "Schinner", "9gkKgW2r3S", 2, "Foster_Lueilwitz" },
                    { 4, 81, "Jada_Skiles60@gmail.com", "Rebeca", "Heathcote", "HKE74axfV7", 1, "Lillian9" },
                    { 119, 33, "Felicia.Wehner48@gmail.com", "Sherwood", "Kirlin", "mRIT75ZM2w", 2, "Jeanette.Goldner" },
                    { 169, 193, "Abraham8@gmail.com", "Pearlie", "Satterfield", "n0SplxZBMt", 3, "Virgie.Larson12" },
                    { 79, 193, "Margarette_Baumbach66@hotmail.com", "Chaim", "Brown", "x54dxrktmB", 2, "Arianna_Reynolds7" },
                    { 177, 50, "Ali.Kunde58@gmail.com", "Rosalinda", "Ullrich", "4dZTMzTyrF", 2, "Leonie59" },
                    { 274, 128, "Don42@yahoo.com", "Amely", "Hackett", "eyVP7LzbOy", 3, "Eladio_Greenholt" },
                    { 30, 128, "Alverta44@hotmail.com", "Keenan", "Balistreri", "rZbuE_SCyP", 1, "Micah_Fisher" },
                    { 284, 104, "Cassandra.Mraz@gmail.com", "Favian", "Schamberger", "ziEiuR4s6t", 1, "Reba75" },
                    { 98, 5, "Kailee_Quitzon20@yahoo.com", "Adolf", "Hauck", "cRzBlMPkBh", 3, "Tressa.Auer61" },
                    { 126, 276, "Alice31@yahoo.com", "Evert", "Denesik", "LYWcfPEtDf", 1, "Antonette60" },
                    { 181, 173, "Magdalen.Bednar@gmail.com", "Clint", "Terry", "QzElPAJdcV", 1, "Lamar.Goyette95" },
                    { 115, 276, "Adelle.Bauch65@hotmail.com", "Gwen", "Hand", "kFo95dtkWu", 3, "Queen.Carter75" },
                    { 84, 293, "Janae_Toy@gmail.com", "Waylon", "Wolff", "bpIXQOHwK8", 2, "Kara.Franecki" },
                    { 125, 123, "Ebony.Kirlin33@gmail.com", "Leila", "Kautzer", "b29aANkLCN", 2, "Marcel_Gutkowski" },
                    { 222, 7, "Alvina.Kling73@gmail.com", "Cydney", "Ferry", "baL54p9UxB", 2, "Kariane43" },
                    { 184, 7, "Desiree.Howell@hotmail.com", "Keven", "Crist", "FyinjsPSiO", 1, "Corene_Wyman72" },
                    { 180, 160, "Andre.Hoppe@hotmail.com", "Destin", "Yundt", "kwBAvRRjMl", 1, "Bryana_Becker87" },
                    { 221, 13, "Jeanie.Wolf3@hotmail.com", "Cleo", "Deckow", "bCpRnWqSNB", 1, "Travis.Erdman" },
                    { 210, 13, "Jamey_Kerluke47@hotmail.com", "Ibrahim", "Kshlerin", "kDP1RpLZ82", 1, "Minerva_Bins21" },
                    { 99, 87, "Jeff83@hotmail.com", "Hoyt", "Schiller", "rvZVKqTpPS", 2, "Cesar_Lesch" },
                    { 26, 87, "Keon_Kemmer38@yahoo.com", "Hailie", "Ondricka", "40U719dGFR", 2, "Madalyn45" },
                    { 244, 293, "Margot.Leannon@gmail.com", "Alessia", "Wisoky", "Rg8j8OXtBO", 2, "Kane.Waters" },
                    { 144, 46, "Kamren.Marvin@hotmail.com", "Golden", "Boyle", "0bXEo0AfU2", 1, "Hiram.VonRueden" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 103, "Savanah Center", 192, "Domenic_Hegmann@hotmail.com", "Cummings - Russel", 229, "(793) 435-7813", "www.Cummings - Russel.com" },
                    { 50, "Damon Gardens", 47, "Sharon46@yahoo.com", "Schuster, Torphy and Klocko", 161, "(920) 618-2591", "www.Schuster, Torphy and Klocko.com" },
                    { 74, "Grant Freeway", 180, "Christine_Wehner80@gmail.com", "Nolan, Bode and Cruickshank", 161, "(788) 274-0975", "www.Nolan, Bode and Cruickshank.com" },
                    { 96, "Kautzer Freeway", 140, "Adonis.Stanton@yahoo.com", "Metz, Christiansen and Nienow", 161, "(353) 141-3770", "www.Metz, Christiansen and Nienow.com" },
                    { 98, "Dameon Key", 57, "Antonetta_Reichel@gmail.com", "Walker - Murray", 161, "(891) 183-1635", "www.Walker - Murray.com" },
                    { 116, "Ashly Summit", 146, "Arno_Satterfield37@gmail.com", "Orn, Schamberger and Ortiz", 161, "(362) 558-6072", "www.Orn, Schamberger and Ortiz.com" },
                    { 8, "Sidney Cliffs", 226, "Louvenia62@hotmail.com", "Block and Sons", 165, "(289) 836-7417", "www.Block and Sons.com" },
                    { 41, "Barrows Knoll", 103, "Cyrus26@gmail.com", "Nikolaus Group", 19, "(301) 936-2331", "www.Nikolaus Group.com" },
                    { 89, "Jakubowski Union", 167, "Gianni88@hotmail.com", "Adams LLC", 19, "(180) 454-0026", "www.Adams LLC.com" },
                    { 100, "Samir Prairie", 196, "Shaniya.Reichert@yahoo.com", "Will, Hickle and Ward", 19, "(418) 954-4339", "www.Will, Hickle and Ward.com" },
                    { 25, "Bosco Crossroad", 161, "Forest.Wiegand@gmail.com", "Erdman - Hoeger", 22, "(723) 613-6385", "www.Erdman - Hoeger.com" },
                    { 67, "Jeremie Estates", 11, "Leopold88@yahoo.com", "Beer, Gutmann and Hoppe", 22, "(019) 207-7432", "www.Beer, Gutmann and Hoppe.com" },
                    { 59, "Kassulke Stravenue", 17, "Quentin.Rohan64@hotmail.com", "Yundt - Pagac", 202, "(829) 609-0976", "www.Yundt - Pagac.com" },
                    { 61, "Elfrieda Islands", 169, "Shanel_Koepp@yahoo.com", "Crona - Shields", 202, "(679) 388-9023", "www.Crona - Shields.com" },
                    { 118, "Robert Burg", 38, "Fausto.Huels@yahoo.com", "Larkin, Howe and Cruickshank", 202, "(140) 231-5553", "www.Larkin, Howe and Cruickshank.com" },
                    { 37, "Roberts Coves", 57, "Dolly.Wolff99@hotmail.com", "Reichert, Flatley and Torphy", 188, "(188) 082-5555", "www.Reichert, Flatley and Torphy.com" },
                    { 49, "Pouros Port", 178, "Bethel80@yahoo.com", "Hyatt Inc", 161, "(355) 700-6569", "www.Hyatt Inc.com" },
                    { 81, "Lesly Creek", 114, "Daphney.Grimes41@gmail.com", "Gorczany, Rau and Towne", 188, "(741) 710-7899", "www.Gorczany, Rau and Towne.com" },
                    { 80, "Jameson Inlet", 194, "Harmon_Nienow41@gmail.com", "Gutkowski Inc", 148, "(296) 101-4276", "www.Gutkowski Inc.com" },
                    { 127, "Trenton Curve", 255, "Ferne.Schamberger46@yahoo.com", "Sporer Group", 123, "(538) 023-7419", "www.Sporer Group.com" },
                    { 5, "Asha Alley", 226, "Litzy64@yahoo.com", "Satterfield Group", 49, "(954) 115-8657", "www.Satterfield Group.com" },
                    { 72, "Collier Throughway", 227, "Florence20@yahoo.com", "Conroy Inc", 49, "(782) 124-7459", "www.Conroy Inc.com" },
                    { 64, "VonRueden Harbors", 211, "Tyra_Corkery@gmail.com", "MacGyver Group", 85, "(496) 227-6024", "www.MacGyver Group.com" },
                    { 86, "Lesley Crossroad", 15, "Otis19@yahoo.com", "Lubowitz - Hills", 85, "(831) 708-0199", "www.Lubowitz - Hills.com" },
                    { 78, "Kenneth Ridges", 137, "Jazmyne86@yahoo.com", "Weissnat, Goldner and Herman", 298, "(036) 435-9187", "www.Weissnat, Goldner and Herman.com" },
                    { 111, "Goyette Port", 263, "Isaiah3@gmail.com", "Kuhn - Schamberger", 270, "(236) 043-7486", "www.Kuhn - Schamberger.com" },
                    { 125, "Leannon Dam", 171, "Janelle7@gmail.com", "Schmitt - Rath", 113, "(812) 077-9811", "www.Schmitt - Rath.com" },
                    { 2, "Rolfson Station", 106, "Sydney_Wolf11@yahoo.com", "White, Hackett and Ullrich", 278, "(410) 261-3647", "www.White, Hackett and Ullrich.com" },
                    { 22, "Williamson Prairie", 189, "Adolph89@gmail.com", "Murazik, Schiller and Schumm", 278, "(847) 855-2951", "www.Murazik, Schiller and Schumm.com" },
                    { 87, "Sanford Pines", 153, "Fidel.Wuckert48@hotmail.com", "Von, Mayert and Christiansen", 15, "(606) 204-7652", "www.Von, Mayert and Christiansen.com" },
                    { 94, "Ronaldo Lane", 189, "Stacy_Stroman42@yahoo.com", "Skiles, Schimmel and Beahan", 238, "(805) 676-4779", "www.Skiles, Schimmel and Beahan.com" },
                    { 105, "Langosh Burg", 165, "Louvenia.Denesik@yahoo.com", "Adams, Schowalter and Bergstrom", 238, "(493) 748-3629", "www.Adams, Schowalter and Bergstrom.com" },
                    { 123, "Gibson Village", 146, "Wilfredo92@hotmail.com", "Muller - Medhurst", 238, "(314) 082-0337", "www.Muller - Medhurst.com" },
                    { 84, "Morar Grove", 251, "Jedidiah_Schmitt@hotmail.com", "Spinka, Maggio and Wintheiser", 123, "(247) 798-8659", "www.Spinka, Maggio and Wintheiser.com" },
                    { 99, "Guillermo Corners", 166, "Alessandra.Auer@yahoo.com", "Kuhic Inc", 123, "(722) 828-7461", "www.Kuhic Inc.com" },
                    { 131, "Blick Locks", 165, "Myles33@yahoo.com", "Renner - Larkin", 123, "(585) 846-6673", "www.Renner - Larkin.com" },
                    { 40, "Green Creek", 192, "Jolie_Roberts@gmail.com", "Padberg, Yost and Schultz", 111, "(662) 313-1868", "www.Padberg, Yost and Schultz.com" },
                    { 85, "Harvey Island", 174, "Kenneth.Heaney@gmail.com", "Hilll Inc", 188, "(164) 076-3876", "www.Hilll Inc.com" },
                    { 38, "Lacey Grove", 66, "Jaylen.Gutkowski@hotmail.com", "Barton - Denesik", 275, "(656) 854-7750", "www.Barton - Denesik.com" },
                    { 107, "Daugherty Ridge", 283, "Felix.Kirlin@gmail.com", "Marquardt - West", 103, "(878) 864-0653", "www.Marquardt - West.com" },
                    { 108, "Purdy Expressway", 281, "Sally18@gmail.com", "Murray - Bode", 103, "(329) 891-6819", "www.Murray - Bode.com" },
                    { 7, "Kassulke Underpass", 42, "Era_Boehm@yahoo.com", "Kirlin, Barrows and Kemmer", 107, "(427) 556-0400", "www.Kirlin, Barrows and Kemmer.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 53, "Lowe Summit", 117, "Hayden_Stiedemann@gmail.com", "Hammes, Bernhard and Hudson", 107, "(752) 681-5755", "www.Hammes, Bernhard and Hudson.com" },
                    { 114, "Rodolfo Plains", 221, "Alek.Hilpert@hotmail.com", "Maggio LLC", 217, "(629) 872-1753", "www.Maggio LLC.com" },
                    { 122, "Blick Springs", 262, "Rex53@hotmail.com", "Smith Inc", 217, "(366) 887-3589", "www.Smith Inc.com" },
                    { 6, "Kassandra Hollow", 248, "Rashawn53@hotmail.com", "Leannon, MacGyver and Kling", 253, "(676) 234-1596", "www.Leannon, MacGyver and Kling.com" },
                    { 90, "Jakubowski Neck", 267, "Shawn_Stokes@yahoo.com", "Stiedemann - Hyatt", 266, "(694) 033-4578", "www.Stiedemann - Hyatt.com" },
                    { 150, "Braun Hill", 73, "Clementine_Williamson@gmail.com", "Cartwright - Emard", 266, "(364) 369-0606", "www.Cartwright - Emard.com" },
                    { 9, "Lang Ridges", 101, "Quinton.Rodriguez54@yahoo.com", "Funk and Sons", 226, "(862) 722-3713", "www.Funk and Sons.com" },
                    { 142, "Johns Islands", 220, "Isidro46@gmail.com", "Kohler - Wolff", 226, "(649) 413-2688", "www.Kohler - Wolff.com" },
                    { 76, "Harris Dale", 145, "Jenifer_Wintheiser6@gmail.com", "Beer - Howell", 136, "(530) 198-4653", "www.Beer - Howell.com" },
                    { 91, "Furman Mission", 10, "Gaetano_Pfeffer10@gmail.com", "Koch and Sons", 193, "(147) 570-4992", "www.Koch and Sons.com" },
                    { 130, "Piper Street", 60, "Brenden.Konopelski@yahoo.com", "Kuvalis Inc", 105, "(516) 796-6754", "www.Kuvalis Inc.com" },
                    { 132, "Bauch Via", 244, "Pansy84@yahoo.com", "Littel - Wisoky", 105, "(655) 073-0248", "www.Littel - Wisoky.com" },
                    { 17, "Jeffery Loop", 234, "Vern.Wisozk45@hotmail.com", "Cole Inc", 133, "(132) 718-1160", "www.Cole Inc.com" },
                    { 21, "Seth Unions", 283, "Yasmeen.Dietrich55@gmail.com", "Frami, Kuphal and Gusikowski", 64, "(301) 861-4806", "www.Frami, Kuphal and Gusikowski.com" },
                    { 15, "Dillan Extensions", 226, "Evans91@hotmail.com", "Tromp, Mraz and Schuppe", 133, "(311) 382-4612", "www.Tromp, Mraz and Schuppe.com" },
                    { 32, "Mayert Trail", 208, "Selena.Ullrich@yahoo.com", "Lowe, Gleason and Runte", 241, "(136) 857-1663", "www.Lowe, Gleason and Runte.com" },
                    { 71, "Miller Plain", 164, "Alda37@gmail.com", "Batz and Sons", 275, "(630) 755-9034", "www.Batz and Sons.com" },
                    { 141, "Bashirian Fort", 270, "Isac47@gmail.com", "Balistreri Inc", 275, "(070) 520-0865", "www.Balistreri Inc.com" },
                    { 34, "Einar Parkways", 142, "Karine.Haag@gmail.com", "Schimmel - Lehner", 14, "(288) 584-8870", "www.Schimmel - Lehner.com" },
                    { 44, "Monahan Divide", 8, "Mina.Macejkovic97@hotmail.com", "Bernhard - West", 14, "(795) 064-1638", "www.Bernhard - West.com" },
                    { 1, "Verdie Courts", 185, "Adam63@hotmail.com", "Lindgren LLC", 294, "(525) 531-1785", "www.Lindgren LLC.com" },
                    { 143, "Kertzmann Centers", 278, "Kobe.Weber@gmail.com", "O'Hara Inc", 294, "(378) 582-2156", "www.O'Hara Inc.com" },
                    { 146, "Kassulke Valley", 276, "Freeda44@yahoo.com", "Volkman - Pacocha", 239, "(794) 344-0521", "www.Volkman - Pacocha.com" },
                    { 62, "Parker Key", 161, "Sean_Hackett@yahoo.com", "Harris Group", 109, "(828) 665-6592", "www.Harris Group.com" },
                    { 46, "Hassan Drive", 196, "Hayley_Toy89@gmail.com", "Padberg, Kovacek and Luettgen", 114, "(965) 509-1750", "www.Padberg, Kovacek and Luettgen.com" },
                    { 75, "Quitzon Plaza", 147, "Henriette.Ondricka@gmail.com", "Koelpin Inc", 114, "(951) 508-6788", "www.Koelpin Inc.com" },
                    { 135, "Gaylord Oval", 107, "Lina_Reichel@hotmail.com", "Aufderhar, Kilback and Kozey", 114, "(359) 552-7087", "www.Aufderhar, Kilback and Kozey.com" },
                    { 134, "Syble Turnpike", 162, "Riley40@gmail.com", "Stanton and Sons", 156, "(824) 145-6255", "www.Stanton and Sons.com" },
                    { 23, "Ricardo Point", 271, "Ara82@hotmail.com", "Becker and Sons", 121, "(277) 365-1743", "www.Becker and Sons.com" },
                    { 60, "Wilkinson Terrace", 10, "Eleazar.Wisoky@hotmail.com", "Waters - Mayert", 121, "(363) 141-1275", "www.Waters - Mayert.com" },
                    { 63, "Boyer Common", 248, "Columbus_Greenfelder@hotmail.com", "Klein - Kozey", 121, "(935) 648-0563", "www.Klein - Kozey.com" },
                    { 36, "Riley Shores", 290, "Ibrahim_Hagenes29@yahoo.com", "Lebsack Inc", 256, "(748) 914-1735", "www.Lebsack Inc.com" },
                    { 58, "Blick Junctions", 94, "Lue_Lockman@yahoo.com", "Beer - Russel", 288, "(724) 284-2940", "www.Beer - Russel.com" },
                    { 13, "Jackson Village", 113, "Yesenia34@yahoo.com", "Kiehn - Wehner", 14, "(375) 761-8225", "www.Kiehn - Wehner.com" },
                    { 57, "Nitzsche Light", 224, "Vivian87@gmail.com", "Schmeler, Cremin and Glover", 90, "(752) 030-5445", "www.Schmeler, Cremin and Glover.com" },
                    { 43, "Bethel Route", 86, "Robyn49@gmail.com", "Wiza Inc", 293, "(720) 308-5892", "www.Wiza Inc.com" },
                    { 102, "Lesly Locks", 158, "Mario.Bernier82@hotmail.com", "Boehm Inc", 293, "(382) 877-3366", "www.Boehm Inc.com" },
                    { 119, "Janessa Unions", 106, "Kailey.Medhurst@hotmail.com", "Gulgowski LLC", 293, "(080) 210-4486", "www.Gulgowski LLC.com" },
                    { 10, "Betty Villages", 85, "Curtis.Thompson56@yahoo.com", "Nader, Flatley and Herman", 91, "(968) 645-1941", "www.Nader, Flatley and Herman.com" },
                    { 14, "Gaylord Greens", 165, "Helga57@yahoo.com", "Emmerich LLC", 91, "(344) 444-2660", "www.Emmerich LLC.com" },
                    { 97, "Kuphal Flats", 170, "Enoch61@yahoo.com", "Schmidt Inc", 116, "(072) 051-8821", "www.Schmidt Inc.com" },
                    { 69, "Arnulfo Oval", 75, "Jaden27@yahoo.com", "Corkery Group", 39, "(725) 902-5333", "www.Corkery Group.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 136, "Schumm Viaduct", 55, "Alisha82@hotmail.com", "Wunsch LLC", 39, "(946) 896-3378", "www.Wunsch LLC.com" },
                    { 16, "Bashirian Island", 31, "Stone_Sanford@yahoo.com", "Hahn LLC", 55, "(680) 346-9748", "www.Hahn LLC.com" },
                    { 52, "Garrison Road", 198, "Amira_Casper19@gmail.com", "Kuhlman, Schaefer and Waelchi", 55, "(824) 636-9196", "www.Kuhlman, Schaefer and Waelchi.com" },
                    { 137, "Willms Dale", 137, "Flo.Spencer@hotmail.com", "Bradtke LLC", 55, "(547) 801-6043", "www.Bradtke LLC.com" },
                    { 35, "Marks Greens", 119, "Ethel_Lesch@yahoo.com", "Pfeffer LLC", 122, "(073) 050-9714", "www.Pfeffer LLC.com" },
                    { 95, "Ayden Points", 294, "Andre.Corkery@hotmail.com", "Hackett LLC", 122, "(834) 878-4939", "www.Hackett LLC.com" },
                    { 48, "Pearlie Locks", 221, "Maudie.Renner83@yahoo.com", "Zulauf, Monahan and Leffler", 108, "(631) 778-1979", "www.Zulauf, Monahan and Leffler.com" },
                    { 77, "Daniel Vista", 28, "Mose16@hotmail.com", "Kreiger - Hagenes", 108, "(731) 116-0781", "www.Kreiger - Hagenes.com" },
                    { 18, "West Ferry", 1, "Raegan64@hotmail.com", "Ortiz - Wolff", 293, "(411) 380-2656", "www.Ortiz - Wolff.com" },
                    { 82, "Mallory Highway", 113, "Leanne_OConnell@yahoo.com", "Dooley Group", 108, "(565) 866-3692", "www.Dooley Group.com" },
                    { 101, "Hailee Court", 218, "Miracle75@gmail.com", "Raynor Group", 2, "(257) 737-0188", "www.Raynor Group.com" },
                    { 115, "Dino Freeway", 284, "Roslyn.Hickle@hotmail.com", "McClure, Lakin and Romaguera", 75, "(463) 967-6441", "www.McClure, Lakin and Romaguera.com" },
                    { 147, "Keebler Mall", 77, "Drew_Legros@yahoo.com", "Gerhold - Corwin", 90, "(220) 497-3655", "www.Gerhold - Corwin.com" },
                    { 149, "Crawford Knoll", 272, "Dameon.Kiehn66@hotmail.com", "Collins Group", 229, "(209) 592-0093", "www.Collins Group.com" },
                    { 11, "Kessler Canyon", 112, "Patrick.Pouros@hotmail.com", "Kuphal, Koch and Thiel", 199, "(027) 961-0933", "www.Kuphal, Koch and Thiel.com" },
                    { 30, "Nash Port", 279, "Branson_Nitzsche@hotmail.com", "Steuber - Borer", 67, "(540) 794-8471", "www.Steuber - Borer.com" },
                    { 42, "Goldner Avenue", 77, "Miles.Grant@yahoo.com", "Jakubowski, Spencer and Orn", 67, "(863) 390-6508", "www.Jakubowski, Spencer and Orn.com" },
                    { 73, "David Turnpike", 300, "Ezra_Okuneva@gmail.com", "Armstrong and Sons", 67, "(489) 455-5115", "www.Armstrong and Sons.com" },
                    { 70, "Janet Ridge", 231, "Aidan57@hotmail.com", "Hayes - Mosciski", 273, "(938) 231-0718", "www.Hayes - Mosciski.com" },
                    { 88, "Vernie Gardens", 5, "Anika67@hotmail.com", "Jones - Schmeler", 273, "(815) 343-3979", "www.Jones - Schmeler.com" },
                    { 106, "Stark Overpass", 59, "Dasia_Gerlach22@hotmail.com", "Toy - Pollich", 273, "(557) 591-7762", "www.Toy - Pollich.com" },
                    { 126, "Nola Place", 252, "Vladimir_Labadie@gmail.com", "VonRueden - Roberts", 273, "(393) 319-9790", "www.VonRueden - Roberts.com" },
                    { 148, "Fay Dale", 106, "Yvonne_Daugherty48@gmail.com", "Goyette Group", 273, "(715) 912-7115", "www.Goyette Group.com" },
                    { 112, "Hulda Terrace", 91, "Abigayle.Beier93@gmail.com", "Koepp and Sons", 218, "(151) 838-5606", "www.Koepp and Sons.com" },
                    { 12, "Kovacek Forks", 170, "Ardella.Runte14@yahoo.com", "Sanford - Runte", 76, "(347) 609-1914", "www.Sanford - Runte.com" },
                    { 45, "Fern Mountains", 67, "Tristin_Johns5@hotmail.com", "Franecki - Zemlak", 76, "(050) 969-0562", "www.Franecki - Zemlak.com" },
                    { 144, "Madaline Prairie", 227, "Nelda_Keebler@gmail.com", "Mante Group", 76, "(005) 084-7799", "www.Mante Group.com" },
                    { 120, "Kunde Fork", 98, "George92@hotmail.com", "Ratke, Rippin and Johns", 75, "(826) 753-7087", "www.Ratke, Rippin and Johns.com" },
                    { 133, "Welch Harbor", 49, "Laron70@hotmail.com", "Bechtelar - Gutkowski", 108, "(617) 599-0310", "www.Bechtelar - Gutkowski.com" },
                    { 27, "Maximillian Springs", 293, "Sophie_Marks93@hotmail.com", "Gleichner - Boyle", 2, "(439) 462-0195", "www.Gleichner - Boyle.com" },
                    { 140, "Kiarra Lane", 256, "Kendrick91@gmail.com", "Hammes Group", 224, "(875) 139-6055", "www.Hammes Group.com" },
                    { 68, "Donny Lane", 231, "Jesus.Farrell58@gmail.com", "Ratke, Ryan and McGlynn", 245, "(292) 294-0121", "www.Ratke, Ryan and McGlynn.com" },
                    { 51, "Sanford Vista", 141, "Glennie.Runolfsdottir75@hotmail.com", "Abernathy, Borer and Boehm", 98, "(004) 548-0560", "www.Abernathy, Borer and Boehm.com" },
                    { 139, "Astrid Spur", 129, "Annabell_Metz@yahoo.com", "Braun - Reichert", 98, "(869) 985-6919", "www.Braun - Reichert.com" },
                    { 33, "Cindy Estates", 197, "Julien.Hayes23@yahoo.com", "Grant, Mueller and Nitzsche", 274, "(721) 813-8318", "www.Grant, Mueller and Nitzsche.com" },
                    { 20, "DuBuque Views", 287, "Albertha.Cronin25@gmail.com", "Roob Inc", 169, "(354) 857-0561", "www.Roob Inc.com" },
                    { 66, "Treutel Camp", 104, "Lulu.Hartmann@gmail.com", "Bauch - Torphy", 169, "(154) 143-3505", "www.Bauch - Torphy.com" },
                    { 129, "Timothy Stream", 50, "Nya_Klocko47@yahoo.com", "Schuster Inc", 169, "(088) 659-5680", "www.Schuster Inc.com" },
                    { 138, "Berge Lodge", 227, "Sasha12@gmail.com", "Metz - Adams", 169, "(604) 105-8958", "www.Metz - Adams.com" },
                    { 19, "Amie River", 236, "Eveline_Monahan97@hotmail.com", "Stracke, Kertzmann and Yundt", 268, "(461) 963-7562", "www.Stracke, Kertzmann and Yundt.com" },
                    { 54, "Kristoffer Dam", 200, "Karlie_Cruickshank@hotmail.com", "Auer - Cormier", 61, "(733) 321-8084", "www.Auer - Cormier.com" },
                    { 92, "Kitty Port", 190, "Melyna_Lemke@hotmail.com", "Leuschke Group", 61, "(730) 037-0025", "www.Leuschke Group.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 93, "Reinger Knoll", 111, "Idella26@hotmail.com", "Barrows and Sons", 61, "(719) 112-4789", "www.Barrows and Sons.com" },
                    { 4, "Gilberto Orchard", 232, "Kaitlin.Bartell99@gmail.com", "Gaylord and Sons", 77, "(776) 118-9930", "www.Gaylord and Sons.com" },
                    { 28, "August Bypass", 97, "Gerson.Lebsack28@yahoo.com", "Feest, Schultz and Mante", 224, "(063) 966-5478", "www.Feest, Schultz and Mante.com" },
                    { 128, "Edward Trafficway", 239, "Eve.Effertz@yahoo.com", "Klein, Stoltenberg and Sawayn", 77, "(351) 670-7498", "www.Klein, Stoltenberg and Sawayn.com" },
                    { 55, "Kameron Gardens", 152, "Rosanna_Grimes@yahoo.com", "Hoeger - Mayer", 245, "(027) 848-9707", "www.Hoeger - Mayer.com" },
                    { 47, "Hilpert Mews", 297, "Leta63@hotmail.com", "Skiles LLC", 245, "(524) 508-3854", "www.Skiles LLC.com" },
                    { 31, "Romaine Brook", 221, "Colby13@hotmail.com", "Swaniawski, Stanton and Quitzon", 169, "(936) 458-4008", "www.Swaniawski, Stanton and Quitzon.com" },
                    { 79, "Boyle Springs", 159, "Laura23@gmail.com", "Halvorson - Zulauf", 104, "(111) 122-1370", "www.Halvorson - Zulauf.com" },
                    { 39, "Dayna Prairie", 24, "Wava_Christiansen17@hotmail.com", "Mante, Pfeffer and Abbott", 245, "(091) 670-3586", "www.Mante, Pfeffer and Abbott.com" },
                    { 65, "Amara Points", 205, "Leonora_Schumm30@hotmail.com", "Kovacek - Huels", 212, "(731) 506-7043", "www.Kovacek - Huels.com" },
                    { 83, "Carole Loaf", 164, "Wilma59@yahoo.com", "Bailey LLC", 212, "(513) 688-3342", "www.Bailey LLC.com" },
                    { 56, "Hoppe Circles", 198, "Emmanuel95@yahoo.com", "Marquardt LLC", 104, "(210) 897-7863", "www.Marquardt LLC.com" },
                    { 145, "Kunde Gardens", 135, "Ewald_Orn83@gmail.com", "Macejkovic, Schulist and Hoppe", 224, "(145) 230-6978", "www.Macejkovic, Schulist and Hoppe.com" },
                    { 110, "Fannie Locks", 206, "Gerson73@yahoo.com", "Trantow LLC", 104, "(116) 170-4383", "www.Trantow LLC.com" },
                    { 124, "Darron Ramp", 163, "Napoleon_Lesch@yahoo.com", "Dooley - Halvorson", 137, "(886) 720-2167", "www.Dooley - Halvorson.com" },
                    { 3, "Braulio Burgs", 160, "Bertrand76@hotmail.com", "Corwin Group", 110, "(809) 865-7596", "www.Corwin Group.com" },
                    { 104, "Scottie Locks", 22, "Adelbert.Bode41@hotmail.com", "Huel, Glover and Beier", 110, "(560) 635-1975", "www.Huel, Glover and Beier.com" },
                    { 117, "Kshlerin Circles", 16, "Khalid56@hotmail.com", "Bradtke, Sauer and Dooley", 110, "(306) 638-8875", "www.Bradtke, Sauer and Dooley.com" },
                    { 26, "Precious Neck", 239, "Giovanny12@yahoo.com", "DuBuque - Barton", 194, "(682) 405-2550", "www.DuBuque - Barton.com" },
                    { 109, "Lebsack Point", 151, "Kristofer_Bradtke@hotmail.com", "Bahringer Inc", 194, "(544) 766-4352", "www.Bahringer Inc.com" },
                    { 113, "Kuphal Grove", 238, "Gussie.Lind@yahoo.com", "Ferry - Rodriguez", 194, "(070) 425-6679", "www.Ferry - Rodriguez.com" },
                    { 121, "Herman Way", 144, "Maia_Stroman@yahoo.com", "Willms - Kerluke", 194, "(505) 567-3930", "www.Willms - Kerluke.com" },
                    { 29, "Larkin Ramp", 12, "Einar.Volkman3@gmail.com", "Vandervort - Gerhold", 245, "(599) 520-4118", "www.Vandervort - Gerhold.com" },
                    { 24, "Aliyah Stravenue", 43, "Kolby.Johnson@gmail.com", "Hodkiewicz, Ferry and Cummerata", 212, "(355) 879-8571", "www.Hodkiewicz, Ferry and Cummerata.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 73, new DateTime(2020, 12, 5, 6, 35, 9, 72, DateTimeKind.Local).AddTicks(2600), 41576, 85, "6817857" },
                    { 22, new DateTime(2021, 3, 8, 2, 4, 4, 63, DateTimeKind.Local).AddTicks(9158), 514927, 85, "6973511" },
                    { 55, new DateTime(2021, 6, 14, 0, 1, 45, 519, DateTimeKind.Local).AddTicks(5941), 977394, 23, "1186789" },
                    { 64, new DateTime(2021, 6, 12, 5, 15, 42, 907, DateTimeKind.Local).AddTicks(8593), 864847, 18, "3992549" },
                    { 42, new DateTime(2020, 10, 1, 18, 27, 19, 255, DateTimeKind.Local).AddTicks(6164), 965027, 33, "5373533" },
                    { 48, new DateTime(2021, 5, 21, 19, 32, 50, 526, DateTimeKind.Local).AddTicks(8574), 573862, 23, "9534348" },
                    { 77, new DateTime(2021, 6, 17, 4, 30, 6, 29, DateTimeKind.Local).AddTicks(1594), 746396, 33, "8669975" },
                    { 81, new DateTime(2021, 8, 3, 0, 11, 50, 89, DateTimeKind.Local).AddTicks(5176), 24413, 85, "5698309" },
                    { 62, new DateTime(2021, 5, 14, 1, 35, 6, 562, DateTimeKind.Local).AddTicks(5426), 66595, 5, "6831575" },
                    { 69, new DateTime(2020, 8, 29, 0, 56, 44, 57, DateTimeKind.Local).AddTicks(2885), 711173, 18, "1502972" },
                    { 65, new DateTime(2020, 9, 8, 7, 17, 2, 426, DateTimeKind.Local).AddTicks(3776), 951305, 54, "5730095" },
                    { 83, new DateTime(2020, 10, 24, 3, 38, 37, 981, DateTimeKind.Local).AddTicks(4317), 120773, 61, "8943445" },
                    { 67, new DateTime(2021, 3, 24, 20, 59, 55, 54, DateTimeKind.Local).AddTicks(4428), 593323, 61, "7198817" },
                    { 9, new DateTime(2020, 9, 2, 18, 23, 59, 793, DateTimeKind.Local).AddTicks(6361), 720359, 61, "5154360" },
                    { 84, new DateTime(2020, 9, 27, 9, 48, 33, 43, DateTimeKind.Local).AddTicks(4759), 486055, 18, "1445384" },
                    { 20, new DateTime(2020, 8, 21, 17, 53, 35, 730, DateTimeKind.Local).AddTicks(953), 305036, 18, "9668980" },
                    { 23, new DateTime(2021, 5, 3, 14, 56, 43, 334, DateTimeKind.Local).AddTicks(303), 149905, 72, "2173522" },
                    { 26, new DateTime(2021, 2, 1, 1, 13, 14, 314, DateTimeKind.Local).AddTicks(228), 857208, 5, "9043203" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 76, new DateTime(2021, 3, 20, 3, 51, 9, 217, DateTimeKind.Local).AddTicks(3684), 516762, 72, "6868035" },
                    { 41, new DateTime(2021, 4, 22, 11, 54, 35, 659, DateTimeKind.Local).AddTicks(7756), 515851, 1, "8591305" },
                    { 2, new DateTime(2020, 12, 31, 5, 31, 1, 197, DateTimeKind.Local).AddTicks(4059), 239722, 97, "8763561" },
                    { 37, new DateTime(2021, 1, 5, 4, 25, 35, 604, DateTimeKind.Local).AddTicks(4674), 343714, 66, "8116658" },
                    { 56, new DateTime(2021, 3, 5, 17, 57, 36, 729, DateTimeKind.Local).AddTicks(4257), 434943, 74, "1594471" },
                    { 17, new DateTime(2020, 12, 6, 19, 35, 8, 796, DateTimeKind.Local).AddTicks(544), 679920, 16, "7821616" },
                    { 16, new DateTime(2021, 3, 3, 16, 10, 52, 701, DateTimeKind.Local).AddTicks(8314), 508229, 16, "5659507" },
                    { 49, new DateTime(2020, 11, 18, 19, 3, 22, 41, DateTimeKind.Local).AddTicks(5012), 764164, 22, "5387679" },
                    { 18, new DateTime(2021, 5, 7, 14, 42, 44, 809, DateTimeKind.Local).AddTicks(7764), 642953, 22, "5561693" },
                    { 6, new DateTime(2021, 2, 18, 11, 19, 15, 117, DateTimeKind.Local).AddTicks(1987), 115974, 22, "9267199" },
                    { 27, new DateTime(2021, 7, 22, 3, 23, 31, 603, DateTimeKind.Local).AddTicks(4727), 880034, 3, "6966294" },
                    { 80, new DateTime(2021, 7, 18, 18, 29, 36, 606, DateTimeKind.Local).AddTicks(6331), 428067, 72, "1098803" },
                    { 24, new DateTime(2021, 4, 24, 1, 43, 14, 868, DateTimeKind.Local).AddTicks(5645), 952597, 46, "1273095" },
                    { 14, new DateTime(2021, 1, 6, 1, 36, 32, 876, DateTimeKind.Local).AddTicks(3882), 808907, 39, "5582666" },
                    { 54, new DateTime(2021, 3, 9, 2, 45, 25, 171, DateTimeKind.Local).AddTicks(7849), 263902, 30, "2639061" },
                    { 70, new DateTime(2020, 9, 17, 21, 36, 22, 474, DateTimeKind.Local).AddTicks(5334), 136901, 11, "2636092" },
                    { 3, new DateTime(2020, 9, 1, 13, 58, 16, 889, DateTimeKind.Local).AddTicks(2033), 703002, 11, "2230859" },
                    { 58, new DateTime(2021, 1, 27, 23, 45, 59, 685, DateTimeKind.Local).AddTicks(4250), 722396, 17, "2246328" },
                    { 21, new DateTime(2020, 11, 18, 1, 57, 59, 146, DateTimeKind.Local).AddTicks(9623), 482001, 17, "6181620" },
                    { 44, new DateTime(2020, 9, 16, 3, 28, 44, 321, DateTimeKind.Local).AddTicks(1185), 780323, 62, "8251013" },
                    { 39, new DateTime(2021, 7, 21, 22, 18, 29, 379, DateTimeKind.Local).AddTicks(4967), 96407, 7, "8466144" },
                    { 31, new DateTime(2020, 10, 18, 9, 4, 59, 42, DateTimeKind.Local).AddTicks(7211), 47769, 21, "2475652" },
                    { 40, new DateTime(2020, 12, 26, 17, 50, 46, 663, DateTimeKind.Local).AddTicks(3180), 940689, 74, "5293463" },
                    { 8, new DateTime(2020, 8, 25, 4, 58, 5, 342, DateTimeKind.Local).AddTicks(3894), 184586, 2, "5397552" },
                    { 11, new DateTime(2021, 4, 9, 5, 10, 19, 539, DateTimeKind.Local).AddTicks(4221), 513872, 13, "9363164" },
                    { 32, new DateTime(2020, 9, 27, 13, 29, 4, 151, DateTimeKind.Local).AddTicks(7978), 212601, 53, "2017918" },
                    { 19, new DateTime(2021, 2, 19, 23, 28, 38, 37, DateTimeKind.Local).AddTicks(1189), 41550, 53, "8881461" },
                    { 15, new DateTime(2020, 11, 17, 2, 22, 19, 635, DateTimeKind.Local).AddTicks(9859), 509549, 53, "5713392" },
                    { 66, new DateTime(2020, 12, 26, 20, 14, 35, 448, DateTimeKind.Local).AddTicks(6305), 788444, 70, "9599490" },
                    { 35, new DateTime(2021, 3, 8, 7, 32, 14, 543, DateTimeKind.Local).AddTicks(3610), 519819, 55, "8857063" },
                    { 45, new DateTime(2021, 6, 18, 9, 39, 4, 200, DateTimeKind.Local).AddTicks(8112), 442175, 48, "5528873" },
                    { 38, new DateTime(2021, 6, 12, 8, 27, 56, 683, DateTimeKind.Local).AddTicks(6823), 529398, 48, "3627483" },
                    { 79, new DateTime(2020, 10, 18, 18, 37, 18, 285, DateTimeKind.Local).AddTicks(7194), 985612, 94, "8085049" },
                    { 25, new DateTime(2021, 4, 9, 13, 28, 38, 156, DateTimeKind.Local).AddTicks(6256), 385783, 24, "8493212" },
                    { 5, new DateTime(2020, 11, 7, 7, 28, 11, 648, DateTimeKind.Local).AddTicks(4581), 943286, 94, "8045557" },
                    { 85, new DateTime(2020, 10, 7, 0, 35, 51, 891, DateTimeKind.Local).AddTicks(6227), 870910, 15, "5184314" },
                    { 60, new DateTime(2020, 8, 30, 5, 37, 34, 515, DateTimeKind.Local).AddTicks(1774), 104687, 2, "8071133" },
                    { 52, new DateTime(2020, 8, 12, 2, 8, 23, 681, DateTimeKind.Local).AddTicks(313), 701423, 91, "3255308" },
                    { 50, new DateTime(2021, 4, 20, 11, 56, 10, 94, DateTimeKind.Local).AddTicks(9852), 413305, 91, "9665709" },
                    { 46, new DateTime(2021, 2, 12, 1, 23, 25, 48, DateTimeKind.Local).AddTicks(7769), 283668, 31, "5748868" },
                    { 33, new DateTime(2021, 1, 21, 16, 20, 36, 59, DateTimeKind.Local).AddTicks(6912), 745189, 56, "5683311" },
                    { 12, new DateTime(2021, 1, 14, 5, 50, 4, 494, DateTimeKind.Local).AddTicks(1021), 702982, 32, "9453319" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 71, new DateTime(2020, 8, 18, 7, 5, 11, 868, DateTimeKind.Local).AddTicks(4711), 613041, 66, "6392715" },
                    { 74, new DateTime(2021, 2, 2, 20, 28, 1, 646, DateTimeKind.Local).AddTicks(2134), 69645, 90, "9979034" },
                    { 29, new DateTime(2021, 4, 19, 13, 58, 12, 535, DateTimeKind.Local).AddTicks(8691), 8164, 74, "4850853" },
                    { 75, new DateTime(2021, 2, 5, 8, 15, 4, 524, DateTimeKind.Local).AddTicks(1989), 848349, 24, "1705753" },
                    { 63, new DateTime(2021, 3, 13, 0, 10, 39, 91, DateTimeKind.Local).AddTicks(956), 223622, 75, "5179256" },
                    { 4, new DateTime(2021, 5, 20, 16, 15, 37, 69, DateTimeKind.Local).AddTicks(7422), 936622, 13, "2057139" },
                    { 72, new DateTime(2020, 9, 9, 18, 27, 38, 500, DateTimeKind.Local).AddTicks(5909), 860803, 52, "3810913" },
                    { 59, new DateTime(2021, 2, 5, 23, 52, 46, 689, DateTimeKind.Local).AddTicks(1349), 881273, 52, "7616901" },
                    { 68, new DateTime(2020, 11, 30, 7, 1, 54, 82, DateTimeKind.Local).AddTicks(6509), 563131, 6, "5902677" },
                    { 57, new DateTime(2020, 12, 11, 14, 21, 57, 203, DateTimeKind.Local).AddTicks(674), 43190, 6, "4450485" },
                    { 28, new DateTime(2021, 5, 19, 5, 53, 9, 876, DateTimeKind.Local).AddTicks(7688), 483199, 51, "5990131" },
                    { 34, new DateTime(2021, 7, 26, 7, 21, 51, 3, DateTimeKind.Local).AddTicks(1873), 303453, 4, "6278043" },
                    { 82, new DateTime(2020, 11, 28, 12, 49, 8, 335, DateTimeKind.Local).AddTicks(3777), 74107, 50, "6896661" },
                    { 7, new DateTime(2021, 5, 1, 21, 5, 2, 692, DateTimeKind.Local).AddTicks(8620), 94279, 75, "7936773" },
                    { 61, new DateTime(2020, 9, 29, 4, 56, 42, 130, DateTimeKind.Local).AddTicks(3721), 253451, 50, "5830082" },
                    { 36, new DateTime(2021, 2, 17, 21, 10, 16, 812, DateTimeKind.Local).AddTicks(9899), 311126, 89, "5939199" },
                    { 53, new DateTime(2021, 3, 14, 12, 56, 50, 531, DateTimeKind.Local).AddTicks(6571), 576146, 29, "3487037" },
                    { 51, new DateTime(2020, 8, 26, 0, 35, 22, 364, DateTimeKind.Local).AddTicks(5680), 708983, 29, "6700601" },
                    { 30, new DateTime(2021, 4, 14, 19, 22, 51, 655, DateTimeKind.Local).AddTicks(7333), 510288, 29, "9630278" },
                    { 47, new DateTime(2021, 5, 16, 16, 54, 35, 838, DateTimeKind.Local).AddTicks(558), 793787, 49, "1214497" },
                    { 43, new DateTime(2020, 8, 27, 5, 8, 47, 27, DateTimeKind.Local).AddTicks(425), 914500, 49, "1080580" },
                    { 13, new DateTime(2021, 4, 21, 23, 11, 14, 362, DateTimeKind.Local).AddTicks(9387), 299026, 71, "3851193" },
                    { 78, new DateTime(2020, 12, 11, 15, 30, 8, 852, DateTimeKind.Local).AddTicks(2327), 16372, 57, "5088542" },
                    { 10, new DateTime(2021, 1, 26, 13, 11, 7, 957, DateTimeKind.Local).AddTicks(9321), 884006, 43, "5540466" },
                    { 1, new DateTime(2020, 12, 21, 3, 1, 2, 347, DateTimeKind.Local).AddTicks(1052), 977203, 25, "9311615" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 39, 12, 68, 157718, new DateTime(2020, 9, 22, 10, 58, 24, 607, DateTimeKind.Local).AddTicks(3481), "Quia odit dolores." },
                    { 177, 26, 39, 963254, new DateTime(2020, 10, 4, 22, 7, 10, 190, DateTimeKind.Local).AddTicks(2744), "aut" },
                    { 272, 26, 144, 327581, new DateTime(2021, 4, 25, 12, 32, 18, 169, DateTimeKind.Local).AddTicks(8522), "Placeat distinctio dicta." },
                    { 335, 26, 76, 305683, new DateTime(2021, 2, 11, 17, 25, 37, 367, DateTimeKind.Local).AddTicks(347), "et" },
                    { 356, 26, 95, 786157, new DateTime(2021, 6, 8, 4, 51, 51, 15, DateTimeKind.Local).AddTicks(6288), "Dicta qui vero voluptate numquam.\nPerspiciatis repellat eius ab cupiditate.\nMolestias adipisci pariatur quia omnis porro blanditiis consequuntur quasi blanditiis.\nIn magni rerum recusandae iste ipsam rerum ipsum.\nAut aut cupiditate rerum id voluptatem natus architecto nulla.\nAutem rerum excepturi iure animi molestias aut minima nisi tempora." },
                    { 369, 26, 23, 301199, new DateTime(2020, 9, 5, 12, 9, 45, 853, DateTimeKind.Local).AddTicks(1776), "Qui quaerat sint earum et animi ut." },
                    { 473, 26, 102, 940296, new DateTime(2021, 1, 19, 11, 58, 16, 222, DateTimeKind.Local).AddTicks(8091), "Natus quod adipisci nemo." },
                    { 550, 26, 23, 656155, new DateTime(2021, 6, 3, 18, 7, 44, 467, DateTimeKind.Local).AddTicks(7754), "Expedita et dolorem eum reprehenderit odio fugiat asperiores sunt.\nBlanditiis ut nulla architecto iste at enim aut a saepe.\nDucimus magnam rerum quia." },
                    { 193, 62, 127, 293408, new DateTime(2021, 1, 21, 4, 52, 50, 76, DateTimeKind.Local).AddTicks(1537), "Neque suscipit laboriosam quo nemo aut quidem dolore.\nQui a iusto autem sit adipisci placeat et esse alias.\nDolorum nam dolore esse blanditiis maiores tempore nihil.\nQui nulla autem facere.\nMaxime et qui aut similique." },
                    { 264, 62, 37, 495602, new DateTime(2020, 9, 6, 7, 37, 49, 655, DateTimeKind.Local).AddTicks(8610), "eveniet" },
                    { 313, 62, 33, 67841, new DateTime(2021, 1, 31, 12, 38, 46, 557, DateTimeKind.Local).AddTicks(1955), "Omnis perferendis et perferendis sint non.\nMaiores rerum quasi.\nQuibusdam veritatis id quasi similique molestiae facilis debitis illo dolorem.\nEt ex pariatur et quisquam minus.\nMagnam voluptatibus modi consequatur beatae quibusdam eaque amet.\nNisi quo eligendi ullam dolorem eveniet magni." },
                    { 542, 62, 63, 201193, new DateTime(2020, 12, 2, 21, 12, 40, 758, DateTimeKind.Local).AddTicks(6497), "voluptatem" },
                    { 579, 62, 5, 593921, new DateTime(2020, 8, 20, 22, 2, 53, 589, DateTimeKind.Local).AddTicks(6773), "tempore" },
                    { 584, 62, 127, 98565, new DateTime(2021, 7, 29, 0, 47, 8, 981, DateTimeKind.Local).AddTicks(9980), "Nobis voluptas nesciunt suscipit sunt rem.\nNam dolorem harum exercitationem sapiente labore beatae repudiandae.\nEst fuga dolorum id id in non consequatur.\nNihil est aspernatur recusandae labore et voluptas.\nConsequatur illo veniam recusandae reprehenderit sit.\nVel placeat quia et rerum nulla tempora." },
                    { 96, 48, 62, 387390, new DateTime(2020, 12, 3, 8, 11, 40, 233, DateTimeKind.Local).AddTicks(1260), "Temporibus laudantium eos aut.\nId vel aspernatur suscipit ducimus aliquid.\nEt laudantium nihil doloremque.\nCum hic laudantium nihil est.\nEst ea eveniet autem.\nPorro totam tempore facere et iure quidem beatae repellendus." },
                    { 170, 48, 146, 8073, new DateTime(2020, 9, 21, 18, 21, 54, 292, DateTimeKind.Local).AddTicks(6857), "dignissimos" },
                    { 126, 26, 83, 243833, new DateTime(2020, 11, 6, 12, 47, 51, 859, DateTimeKind.Local).AddTicks(1596), "Sint voluptatibus voluptatem tempora consequatur quod aut voluptatum officiis.\nEa odio autem praesentium consequuntur eum.\nInventore fugiat qui voluptatibus facere ullam.\nSit labore molestiae autem rerum." },
                    { 109, 26, 110, 111690, new DateTime(2020, 12, 18, 9, 55, 23, 972, DateTimeKind.Local).AddTicks(9233), "Autem ut similique possimus quasi illo temporibus qui est.\nEt totam est provident vel est labore vitae.\nDistinctio voluptate ipsum eaque amet eum.\nInventore maxime est praesentium id quas nesciunt." },
                    { 581, 65, 142, 236683, new DateTime(2021, 5, 7, 7, 56, 33, 727, DateTimeKind.Local).AddTicks(5492), "Sunt non non ab et repellendus.\nVel delectus sint aut quas voluptatem omnis." },
                    { 478, 65, 10, 376544, new DateTime(2020, 11, 4, 10, 56, 29, 718, DateTimeKind.Local).AddTicks(6083), "illo" },
                    { 156, 83, 78, 261321, new DateTime(2021, 6, 30, 9, 19, 13, 602, DateTimeKind.Local).AddTicks(6296), "Pariatur sint ut amet minima sequi.\nMollitia ea velit modi.\nConsequatur a cum sunt distinctio suscipit aliquam accusamus.\nAmet at itaque incidunt.\nAut molestiae dolor illum velit debitis voluptates id qui dolorem.\nDolor sit et laborum." },
                    { 165, 83, 98, 913908, new DateTime(2020, 11, 4, 11, 18, 23, 117, DateTimeKind.Local).AddTicks(538), "Repellat natus iste. Deleniti omnis molestias voluptates iusto porro et ipsa autem ut. Molestiae labore quibusdam nemo eligendi quo distinctio neque consequatur. Et ut nemo velit. Nemo cupiditate minima commodi libero sint." },
                    { 188, 83, 81, 111829, new DateTime(2021, 5, 28, 3, 4, 15, 212, DateTimeKind.Local).AddTicks(7975), "Eum accusamus aut impedit aut saepe et. Corrupti distinctio unde dolores aliquam provident magni. Natus aut libero delectus beatae doloremque beatae temporibus quis adipisci. Aspernatur non libero quae dolore. Tempora similique vel eos est maiores rerum. Aut totam est aut totam tempore ad et et laboriosam." },
                    { 197, 83, 12, 761569, new DateTime(2021, 5, 9, 7, 21, 6, 631, DateTimeKind.Local).AddTicks(8700), "Enim sapiente et. Reprehenderit ex aut doloribus possimus laboriosam rem iure vel. Sit architecto aliquam eos explicabo alias pariatur. Officiis quia ut." },
                    { 221, 83, 67, 410506, new DateTime(2020, 12, 20, 6, 54, 28, 244, DateTimeKind.Local).AddTicks(3747), "quisquam" },
                    { 253, 83, 7, 816372, new DateTime(2021, 4, 21, 9, 31, 30, 912, DateTimeKind.Local).AddTicks(2757), "Nostrum id tenetur tempora eos in sed quos voluptates placeat. Quo ea est suscipit ut odio sed voluptatibus. Vitae officia dolorum adipisci consectetur quibusdam. Consequatur dolor qui non. Et vitae reprehenderit autem soluta expedita non." },
                    { 258, 83, 56, 252038, new DateTime(2021, 3, 14, 21, 37, 32, 951, DateTimeKind.Local).AddTicks(9630), "Ipsa vel culpa qui.\nEarum quam ea commodi sunt.\nAlias alias debitis corrupti voluptas ea cupiditate beatae." },
                    { 289, 48, 25, 875877, new DateTime(2021, 7, 12, 3, 36, 0, 711, DateTimeKind.Local).AddTicks(3725), "Aperiam perferendis dignissimos culpa optio.\nMaxime quia nam iste vel ut eum.\nExcepturi aut iusto quae autem doloremque." },
                    { 324, 83, 137, 478323, new DateTime(2021, 7, 6, 16, 39, 58, 626, DateTimeKind.Local).AddTicks(7319), "Non a rerum alias possimus adipisci quis ratione. Quia laudantium enim animi minus voluptatem. Aliquam et rerum ab sit quia optio." },
                    { 521, 83, 6, 438223, new DateTime(2020, 10, 18, 21, 58, 15, 531, DateTimeKind.Local).AddTicks(6698), "Voluptate ut perferendis ex aut explicabo consequatur provident. Sapiente animi dolores repudiandae perspiciatis quos asperiores. Voluptas nulla iusto vero quas necessitatibus error laboriosam. Quasi velit et. Eveniet veniam adipisci illum sint ad." },
                    { 25, 65, 74, 131556, new DateTime(2021, 3, 11, 19, 50, 56, 259, DateTimeKind.Local).AddTicks(3588), "Necessitatibus omnis dolores. Molestiae ut velit. Aut animi qui facere error temporibus quae. Est nulla et voluptatem sequi et. In ipsa nobis aliquam corporis. Tenetur ut suscipit rerum nihil sint laboriosam ipsam repellat odit." },
                    { 32, 65, 37, 654142, new DateTime(2021, 8, 9, 13, 25, 1, 713, DateTimeKind.Local).AddTicks(1037), "temporibus" },
                    { 36, 65, 96, 695230, new DateTime(2020, 8, 13, 20, 30, 52, 24, DateTimeKind.Local).AddTicks(4728), "Et nam nisi consectetur excepturi quo et deserunt voluptatem quia.\nAliquid voluptatum et itaque.\nMaiores ipsam et autem iusto quia sit alias.\nUllam rerum sunt architecto dignissimos voluptatem." },
                    { 97, 65, 149, 682080, new DateTime(2020, 12, 18, 18, 35, 32, 705, DateTimeKind.Local).AddTicks(8337), "laborum" },
                    { 166, 65, 2, 274796, new DateTime(2021, 3, 14, 2, 13, 58, 983, DateTimeKind.Local).AddTicks(2272), "Qui magni consequatur inventore maiores odio nihil recusandae dolor quidem.\nSit suscipit qui amet est et et velit dolores doloribus." },
                    { 232, 65, 118, 185516, new DateTime(2020, 9, 21, 16, 1, 31, 907, DateTimeKind.Local).AddTicks(8986), "vero" },
                    { 464, 83, 35, 452024, new DateTime(2020, 9, 28, 0, 16, 33, 602, DateTimeKind.Local).AddTicks(5333), "A repellendus minima unde nisi ad nam perspiciatis libero accusamus.\nEarum omnis magni voluptatibus illo repudiandae.\nLabore dolores eos quibusdam cum quis labore et.\nNesciunt repellendus omnis dolorem voluptatum corporis reprehenderit aliquid autem nesciunt." },
                    { 143, 83, 104, 603662, new DateTime(2021, 1, 25, 23, 33, 27, 742, DateTimeKind.Local).AddTicks(309), "Ea consequatur quae. Unde et et nostrum fugit. Distinctio quibusdam ex voluptas qui autem. Aut in quas asperiores. Dolorum aliquam sit necessitatibus nemo. Officiis molestiae sit non error est dolor facere." },
                    { 387, 48, 93, 378104, new DateTime(2021, 3, 21, 21, 18, 26, 506, DateTimeKind.Local).AddTicks(738), "Nesciunt delectus dolores dolorem accusamus. Illo architecto quia inventore non. Ea deserunt voluptatem tempora cupiditate occaecati occaecati facilis dolores ullam. Nihil id sint dolorum laboriosam. Veniam alias et placeat recusandae maxime aut. Ut exercitationem eveniet corporis." },
                    { 88, 55, 3, 596565, new DateTime(2021, 1, 8, 8, 9, 7, 973, DateTimeKind.Local).AddTicks(7710), "nam" },
                    { 527, 73, 26, 475235, new DateTime(2021, 2, 14, 23, 50, 38, 59, DateTimeKind.Local).AddTicks(3798), "Ex rem odit aut excepturi iusto doloremque. Ut iusto veritatis velit quaerat vel iusto eaque. Fugit deleniti ut laborum exercitationem et voluptatem ducimus in facere." },
                    { 534, 73, 131, 763645, new DateTime(2021, 6, 15, 5, 36, 34, 251, DateTimeKind.Local).AddTicks(9828), "Id beatae assumenda dolor ipsam.\nFacilis tenetur quaerat minima aut quasi voluptatum incidunt.\nQuis mollitia corrupti sapiente aperiam facere nemo expedita sint." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 587, 73, 30, 792641, new DateTime(2021, 8, 9, 9, 58, 39, 797, DateTimeKind.Local).AddTicks(2517), "id" },
                    { 6, 81, 49, 64122, new DateTime(2021, 7, 12, 5, 44, 52, 744, DateTimeKind.Local).AddTicks(1835), "Et aut sit tempora veniam natus ea est. Laborum iusto officia optio tenetur natus recusandae autem. Eum debitis aliquid et non officiis et quam nihil et. Architecto quo est consequuntur maiores." },
                    { 94, 81, 77, 170176, new DateTime(2020, 11, 23, 20, 5, 29, 522, DateTimeKind.Local).AddTicks(3840), "natus" },
                    { 135, 81, 115, 323822, new DateTime(2020, 11, 9, 17, 53, 49, 232, DateTimeKind.Local).AddTicks(9146), "Ut consequuntur facere iste assumenda id excepturi eveniet commodi.\nVoluptatem tenetur consequatur dolor quod non voluptatibus qui vero suscipit.\nEst labore in incidunt iusto adipisci." },
                    { 3, 42, 87, 863806, new DateTime(2021, 5, 29, 5, 10, 16, 6, DateTimeKind.Local).AddTicks(9912), "A excepturi excepturi velit quod." },
                    { 44, 42, 56, 149878, new DateTime(2021, 3, 12, 17, 51, 43, 64, DateTimeKind.Local).AddTicks(5257), "Nisi voluptatibus neque.\nAt ipsa sit ut doloribus tenetur iusto.\nNihil accusamus est aliquid quas voluptatem repellendus.\nVoluptas facilis ducimus placeat sint assumenda temporibus dicta." },
                    { 107, 42, 66, 156310, new DateTime(2020, 11, 4, 10, 59, 19, 558, DateTimeKind.Local).AddTicks(1093), "earum" },
                    { 110, 42, 12, 414177, new DateTime(2021, 4, 17, 0, 57, 29, 117, DateTimeKind.Local).AddTicks(5995), "dignissimos" },
                    { 153, 42, 104, 1295, new DateTime(2020, 10, 31, 22, 49, 28, 923, DateTimeKind.Local).AddTicks(8054), "Occaecati autem perferendis harum tenetur sed sint.\nNobis eos esse rerum.\nDoloremque dolorem sunt qui adipisci quisquam ut.\nEligendi harum quos totam quia eligendi.\nUnde ab nam optio veritatis." },
                    { 436, 42, 149, 576550, new DateTime(2020, 8, 22, 2, 14, 15, 504, DateTimeKind.Local).AddTicks(2295), "Fugit itaque non et blanditiis rem dolorum voluptas voluptatem. Nihil fugit et qui id qui recusandae. Amet aspernatur est modi quod et magni ut. Consectetur similique in hic reiciendis architecto aperiam nemo laboriosam. Amet voluptas et dolores provident." },
                    { 152, 77, 96, 674231, new DateTime(2021, 7, 11, 16, 22, 33, 217, DateTimeKind.Local).AddTicks(128), "Incidunt et dolor placeat magnam et aliquam et reiciendis." },
                    { 187, 77, 14, 773339, new DateTime(2021, 3, 27, 18, 24, 55, 18, DateTimeKind.Local).AddTicks(3235), "Explicabo molestiae illum illo asperiores debitis molestias. Perspiciatis maiores laudantium eos necessitatibus quia inventore. Nihil similique dolores doloremque voluptatum quo. Nobis ratione et asperiores quo officia. A eum aliquid id molestiae aut." },
                    { 243, 77, 73, 60357, new DateTime(2021, 3, 17, 22, 9, 50, 891, DateTimeKind.Local).AddTicks(7303), "Expedita id et ducimus molestiae illo quaerat cumque.\nFugiat tempore aliquid voluptatem perspiciatis sunt atque qui hic sit." },
                    { 513, 73, 29, 300186, new DateTime(2021, 6, 3, 12, 34, 46, 71, DateTimeKind.Local).AddTicks(4620), "Nam autem ipsa molestiae a dicta quis optio.\nEveniet veritatis unde aut dolor veniam sit laboriosam itaque quae.\nIncidunt culpa velit deserunt voluptatem praesentium exercitationem quod.\nOmnis quia sunt suscipit quia voluptatem." },
                    { 470, 73, 148, 760971, new DateTime(2020, 9, 11, 7, 9, 45, 600, DateTimeKind.Local).AddTicks(822), "quia" },
                    { 354, 73, 78, 492891, new DateTime(2020, 8, 18, 18, 42, 38, 309, DateTimeKind.Local).AddTicks(6031), "Ad quae ut enim expedita officia neque repellat rerum repellat.\nAut dicta officiis et deleniti et voluptas.\nOdit rem nulla enim.\nEt voluptas repellat neque sapiente quidem necessitatibus consequatur amet quidem." },
                    { 342, 73, 93, 634013, new DateTime(2020, 12, 3, 19, 41, 36, 418, DateTimeKind.Local).AddTicks(4442), "Impedit eum tempore tenetur amet ipsa culpa aut illo libero." },
                    { 287, 55, 60, 179002, new DateTime(2020, 11, 25, 18, 2, 0, 35, DateTimeKind.Local).AddTicks(1389), "Ex quam maiores." },
                    { 298, 55, 72, 896816, new DateTime(2020, 12, 17, 8, 17, 37, 573, DateTimeKind.Local).AddTicks(6154), "sapiente" },
                    { 318, 55, 110, 623478, new DateTime(2020, 11, 17, 23, 30, 3, 154, DateTimeKind.Local).AddTicks(592), "Itaque unde quia et repellendus repellendus deleniti vitae. Exercitationem numquam minus in quis. Repellat maiores quia natus magni vero. Tenetur deserunt molestiae dolores praesentium officia qui quibusdam. Vel magni fugit animi molestias et quod dolores. Nulla voluptate molestiae." },
                    { 344, 55, 120, 749380, new DateTime(2021, 5, 1, 8, 41, 4, 148, DateTimeKind.Local).AddTicks(9171), "Neque quaerat deleniti magni sequi qui corporis accusantium. Veritatis corrupti reiciendis cumque enim dolore iusto nemo veritatis cupiditate. Asperiores libero odio nisi corrupti nulla. Dicta odit id. Odit reiciendis tempore molestias optio nihil voluptates molestiae." },
                    { 41, 22, 80, 147505, new DateTime(2020, 12, 17, 8, 22, 41, 593, DateTimeKind.Local).AddTicks(78), "Eveniet ducimus quibusdam quo architecto voluptates.\nEum repellendus culpa quae incidunt dolor.\nVoluptatem sint blanditiis deserunt accusantium rerum veniam beatae.\nRerum et aspernatur sed sunt." },
                    { 63, 22, 50, 660865, new DateTime(2021, 7, 4, 20, 53, 48, 894, DateTimeKind.Local).AddTicks(3387), "rem" },
                    { 75, 22, 64, 23372, new DateTime(2020, 10, 1, 1, 37, 9, 930, DateTimeKind.Local).AddTicks(9031), "Aperiam placeat nam eaque molestias qui est." },
                    { 443, 48, 25, 210917, new DateTime(2020, 9, 27, 7, 29, 33, 778, DateTimeKind.Local).AddTicks(6034), "exercitationem" },
                    { 83, 22, 139, 933601, new DateTime(2021, 4, 17, 12, 50, 54, 375, DateTimeKind.Local).AddTicks(4938), "Autem rerum voluptates aperiam tempora. Et mollitia explicabo quae iste dolor. Itaque vel ab qui sit sit." },
                    { 222, 22, 14, 115704, new DateTime(2020, 10, 21, 21, 37, 9, 897, DateTimeKind.Local).AddTicks(2136), "Voluptatem tenetur ullam voluptas ut molestias.\nReprehenderit est dolores sit labore amet." },
                    { 420, 22, 20, 474951, new DateTime(2020, 10, 14, 6, 23, 38, 108, DateTimeKind.Local).AddTicks(6535), "suscipit" },
                    { 71, 73, 7, 268376, new DateTime(2020, 9, 9, 14, 41, 13, 476, DateTimeKind.Local).AddTicks(4962), "Molestiae laborum cupiditate rem tempora est animi vel accusantium dolor. Qui molestiae accusantium neque quia minus. Voluptatum magni nesciunt repellendus quia. Cumque officia voluptatem inventore temporibus quae et expedita perspiciatis." },
                    { 167, 73, 7, 38662, new DateTime(2020, 8, 25, 1, 16, 11, 524, DateTimeKind.Local).AddTicks(9811), "Voluptas eum expedita dolores. Nihil quo labore vel aut sint accusamus impedit. Cupiditate necessitatibus laboriosam dolor sit quia culpa. Ex repellat ex est." },
                    { 199, 73, 92, 290525, new DateTime(2020, 10, 26, 18, 13, 53, 482, DateTimeKind.Local).AddTicks(2214), "maxime" },
                    { 320, 73, 29, 207410, new DateTime(2021, 6, 23, 18, 45, 41, 198, DateTimeKind.Local).AddTicks(5399), "Dolore doloribus quas quis ducimus labore. Ut dolor ea possimus. Ut in iusto maiores quam minima sit. Ut dolore atque minus tenetur illo saepe dicta temporibus ipsa. Recusandae sed est voluptatem incidunt. Nihil iure aperiam quis natus quo dolore error aliquid vel." },
                    { 329, 73, 27, 853247, new DateTime(2020, 12, 7, 12, 15, 8, 509, DateTimeKind.Local).AddTicks(9101), "Temporibus enim nisi nostrum voluptatibus in est quasi vero aut. Et id autem quas suscipit minus. Eaque nulla sed esse vitae. Asperiores nulla dolorum voluptatem." },
                    { 213, 22, 92, 653628, new DateTime(2021, 7, 2, 17, 52, 5, 122, DateTimeKind.Local).AddTicks(3947), "aut" },
                    { 85, 83, 119, 271060, new DateTime(2021, 5, 14, 12, 41, 16, 580, DateTimeKind.Local).AddTicks(1161), "Quis error ratione id officia eius quas provident debitis aut.\nEligendi molestiae officia voluptates est quo a doloremque commodi adipisci.\nMolestias distinctio aut quasi maiores quibusdam minima.\nRecusandae assumenda ducimus sequi.\nQuisquam architecto modi neque dolore in saepe accusantium ut." },
                    { 42, 83, 96, 972002, new DateTime(2020, 8, 24, 9, 27, 6, 235, DateTimeKind.Local).AddTicks(9100), "Et alias sed voluptatem deleniti earum odit at." },
                    { 403, 67, 104, 235473, new DateTime(2020, 9, 23, 2, 35, 17, 673, DateTimeKind.Local).AddTicks(9573), "Eveniet quis cum aut velit enim enim non.\nTemporibus sed facere voluptates magnam iusto dolor dolor voluptatum minima.\nAspernatur qui nemo et dicta est.\nAut ut consequuntur expedita alias est aut modi qui numquam.\nAut quaerat id est sit in ut." },
                    { 68, 56, 108, 593414, new DateTime(2020, 11, 18, 0, 43, 11, 436, DateTimeKind.Local).AddTicks(969), "Eaque quia ad et qui aut velit pariatur. Et voluptatum in est. Quod veniam at numquam deleniti laboriosam et totam doloremque. Labore nulla distinctio similique neque." },
                    { 122, 56, 55, 819428, new DateTime(2021, 3, 27, 19, 6, 38, 693, DateTimeKind.Local).AddTicks(2806), "delectus" },
                    { 198, 56, 141, 919604, new DateTime(2021, 8, 3, 6, 51, 19, 671, DateTimeKind.Local).AddTicks(2604), "similique" },
                    { 244, 56, 16, 699203, new DateTime(2021, 6, 1, 4, 16, 26, 401, DateTimeKind.Local).AddTicks(887), "natus" },
                    { 300, 56, 5, 70986, new DateTime(2021, 6, 27, 13, 52, 1, 17, DateTimeKind.Local).AddTicks(8655), "accusamus" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 393, 56, 21, 236339, new DateTime(2020, 12, 19, 6, 7, 16, 431, DateTimeKind.Local).AddTicks(3491), "Iste quo reprehenderit quisquam nulla architecto. Voluptatem qui quis deleniti similique est iusto et est. Architecto voluptatum aut quaerat voluptatem iste rerum. Ullam ut sit rerum praesentium accusantium praesentium ipsum est. Ea fuga et dolore aspernatur omnis." },
                    { 431, 56, 144, 212119, new DateTime(2020, 10, 11, 5, 11, 4, 808, DateTimeKind.Local).AddTicks(4775), "sapiente" },
                    { 504, 56, 95, 333121, new DateTime(2021, 5, 8, 10, 48, 26, 981, DateTimeKind.Local).AddTicks(7905), "nam" },
                    { 517, 56, 136, 293446, new DateTime(2021, 8, 7, 10, 44, 14, 816, DateTimeKind.Local).AddTicks(4194), "Quo ex quis.\nSed voluptas aut voluptate impedit voluptatem rerum nulla.\nTempore quaerat incidunt non est iure natus ratione tempora et.\nUt illo repellat nesciunt." },
                    { 84, 20, 134, 520248, new DateTime(2021, 7, 31, 8, 51, 42, 584, DateTimeKind.Local).AddTicks(1253), "Accusamus tempore impedit dolores.\nDolorum quos at temporibus beatae.\nConsequatur eum et dignissimos qui consequatur.\nSunt quasi quis modi.\nFacere totam et molestiae ut nisi consequuntur delectus qui vel." },
                    { 419, 20, 80, 391051, new DateTime(2020, 11, 4, 22, 2, 8, 798, DateTimeKind.Local).AddTicks(1210), "Ducimus occaecati facilis temporibus et corporis sequi. Repudiandae accusantium rerum eligendi. Aut perferendis vero doloremque natus." },
                    { 439, 20, 10, 410015, new DateTime(2021, 3, 13, 10, 48, 14, 206, DateTimeKind.Local).AddTicks(2215), "quia" },
                    { 495, 20, 61, 646667, new DateTime(2020, 10, 15, 22, 32, 27, 237, DateTimeKind.Local).AddTicks(3838), "voluptatem" },
                    { 21, 64, 38, 53663, new DateTime(2020, 10, 21, 19, 38, 6, 49, DateTimeKind.Local).AddTicks(4726), "Omnis neque accusantium illum aperiam nihil consequuntur laudantium. Et voluptas tenetur enim molestiae doloremque cupiditate doloremque est. Animi voluptas et. Ut necessitatibus asperiores." },
                    { 146, 64, 41, 6213, new DateTime(2020, 12, 24, 12, 45, 22, 550, DateTimeKind.Local).AddTicks(8088), "est" },
                    { 454, 40, 61, 974609, new DateTime(2021, 4, 10, 5, 15, 31, 383, DateTimeKind.Local).AddTicks(8468), "Labore quis temporibus tenetur voluptatem sunt asperiores.\nEos mollitia occaecati fugiat accusamus.\nSequi nulla nihil aperiam dolorum non voluptas.\nDelectus itaque quas deserunt amet.\nRerum architecto quis quis in et.\nAdipisci est esse sapiente nihil unde." },
                    { 400, 40, 113, 242676, new DateTime(2021, 8, 11, 10, 29, 1, 572, DateTimeKind.Local).AddTicks(2775), "Ad ut omnis dolores autem quisquam fugiat asperiores aut." },
                    { 380, 40, 43, 833407, new DateTime(2021, 8, 9, 1, 0, 4, 552, DateTimeKind.Local).AddTicks(6819), "Et ut possimus ipsum magnam dolorem dolor repellendus." },
                    { 233, 40, 70, 534294, new DateTime(2021, 8, 8, 15, 23, 37, 113, DateTimeKind.Local).AddTicks(4878), "Nemo laborum et alias voluptas esse." },
                    { 311, 4, 49, 970043, new DateTime(2021, 2, 22, 10, 32, 27, 484, DateTimeKind.Local).AddTicks(4316), "Ad velit sed consequuntur nihil rerum cumque excepturi. Laborum eveniet amet minima aliquam voluptatem. Excepturi aut pariatur iste perspiciatis tenetur quia. Quas quas molestiae placeat odit. Mollitia in ipsum omnis quae voluptatem et accusamus ut. Omnis deleniti ut ab nobis culpa eos ab optio veniam." },
                    { 465, 4, 24, 357080, new DateTime(2021, 4, 15, 2, 54, 32, 135, DateTimeKind.Local).AddTicks(2194), "Eligendi vel eligendi maiores est officia voluptatem esse quibusdam." },
                    { 494, 4, 9, 673362, new DateTime(2020, 12, 22, 8, 0, 24, 8, DateTimeKind.Local).AddTicks(3433), "et" },
                    { 503, 4, 132, 85726, new DateTime(2021, 5, 31, 1, 38, 37, 382, DateTimeKind.Local).AddTicks(1506), "Officia eum qui sit sint aspernatur sint corrupti perspiciatis quod." },
                    { 196, 11, 102, 620027, new DateTime(2021, 6, 3, 20, 29, 12, 547, DateTimeKind.Local).AddTicks(1839), "Commodi rerum nobis.\nDolorum praesentium molestiae id.\nVoluptas molestias dolorum." },
                    { 352, 11, 146, 656130, new DateTime(2020, 12, 19, 4, 3, 45, 656, DateTimeKind.Local).AddTicks(2419), "Facilis non doloremque.\nDolor occaecati mollitia voluptate et occaecati molestiae.\nEt consequatur qui.\nAd labore accusamus officiis minus deserunt et." },
                    { 486, 11, 49, 946988, new DateTime(2021, 7, 23, 10, 2, 29, 180, DateTimeKind.Local).AddTicks(6811), "Magnam similique qui corrupti.\nVelit dicta dolore tempora ab.\nEaque quia sit accusamus eligendi." },
                    { 204, 64, 9, 270861, new DateTime(2021, 6, 12, 12, 21, 28, 420, DateTimeKind.Local).AddTicks(6742), "Dolorum est maiores qui dolorem ut fugit iure quos sit. Iusto ipsam aut sit et quisquam. In in quos vero qui in rerum." },
                    { 597, 11, 23, 656723, new DateTime(2020, 9, 4, 2, 49, 39, 222, DateTimeKind.Local).AddTicks(5763), "perspiciatis" },
                    { 220, 29, 24, 573999, new DateTime(2021, 2, 20, 17, 11, 58, 882, DateTimeKind.Local).AddTicks(1250), "Sunt sed deleniti quo harum architecto sed aut ipsa itaque.\nNon voluptatibus quasi.\nEst est veritatis quis et est quis.\nIncidunt maxime quo fuga voluptas cum." },
                    { 410, 29, 52, 12959, new DateTime(2020, 12, 18, 9, 27, 59, 58, DateTimeKind.Local).AddTicks(5294), "Sint earum aut voluptates ad voluptas perferendis voluptatibus.\nOccaecati sed ab eveniet est.\nIusto reprehenderit eos qui exercitationem aliquid quidem ut.\nDebitis dolores in sunt ut molestias sit.\nEst iusto saepe.\nEnim nihil qui omnis laborum dolore quia." },
                    { 599, 1, 16, 488276, new DateTime(2020, 12, 18, 7, 55, 29, 550, DateTimeKind.Local).AddTicks(3691), "Et amet quos consequatur dolor consequatur. Ut quas quia. Sed quis vel optio consequatur et. Nulla repellendus id nihil unde eaque quisquam quaerat est." },
                    { 463, 29, 69, 79688, new DateTime(2021, 1, 15, 20, 39, 10, 191, DateTimeKind.Local).AddTicks(2507), "Dolore saepe reiciendis voluptatum natus voluptas harum omnis qui." },
                    { 548, 29, 46, 192546, new DateTime(2020, 12, 5, 2, 47, 51, 236, DateTimeKind.Local).AddTicks(5724), "Rerum aut qui enim necessitatibus quia.\nEx ducimus laudantium voluptates.\nSaepe cum dolorem autem et." },
                    { 20, 40, 34, 958647, new DateTime(2020, 12, 30, 22, 33, 26, 981, DateTimeKind.Local).AddTicks(5237), "Fugiat velit ea voluptatibus delectus sit id modi." },
                    { 131, 40, 38, 42573, new DateTime(2020, 8, 15, 14, 22, 20, 875, DateTimeKind.Local).AddTicks(6327), "est" },
                    { 46, 29, 61, 334544, new DateTime(2021, 7, 8, 7, 24, 51, 421, DateTimeKind.Local).AddTicks(174), "In ut iste dolorum earum repudiandae." },
                    { 247, 64, 132, 139943, new DateTime(2020, 12, 29, 12, 28, 13, 66, DateTimeKind.Local).AddTicks(2621), "Reiciendis blanditiis doloremque magnam et voluptatem accusamus. Aliquam possimus minima. Laboriosam ipsa illo optio deleniti illum. Perferendis quis consectetur asperiores amet et. Aut doloribus voluptas quia incidunt cupiditate sunt. Vel qui similique." },
                    { 254, 64, 101, 180347, new DateTime(2020, 8, 19, 3, 48, 22, 513, DateTimeKind.Local).AddTicks(8259), "Ex dolorem eaque velit sapiente dolor at. Saepe nihil voluptatibus possimus. Nisi ducimus qui. Voluptas modi consequuntur numquam minima. A eius repellendus voluptates tempore. Aut perspiciatis tempore et nam odio sapiente assumenda." },
                    { 401, 64, 96, 191242, new DateTime(2021, 7, 5, 10, 49, 2, 212, DateTimeKind.Local).AddTicks(6968), "Sed assumenda saepe quam alias similique debitis eos." },
                    { 434, 84, 69, 213724, new DateTime(2021, 1, 10, 13, 56, 55, 490, DateTimeKind.Local).AddTicks(8663), "Molestiae ut suscipit aut et illum perferendis aut accusantium voluptate." },
                    { 491, 84, 132, 714635, new DateTime(2021, 4, 20, 15, 51, 3, 707, DateTimeKind.Local).AddTicks(7559), "repudiandae" },
                    { 559, 84, 83, 393306, new DateTime(2021, 5, 6, 23, 4, 53, 516, DateTimeKind.Local).AddTicks(9299), "Deleniti in est." },
                    { 594, 84, 42, 856691, new DateTime(2021, 6, 6, 15, 14, 16, 987, DateTimeKind.Local).AddTicks(6817), "qui" },
                    { 19, 9, 43, 814294, new DateTime(2020, 8, 27, 13, 45, 5, 345, DateTimeKind.Local).AddTicks(1502), "Quo iusto dolor.\nAccusantium ipsam eius.\nDoloremque nam impedit quo molestias itaque inventore sed." },
                    { 45, 9, 105, 289269, new DateTime(2020, 9, 21, 23, 26, 34, 912, DateTimeKind.Local).AddTicks(1095), "Et facere et itaque minima asperiores aspernatur laboriosam error.\nQuam quasi reprehenderit est quo est.\nPlaceat possimus temporibus optio provident esse accusantium vitae aliquam aspernatur.\nQuo laudantium veritatis.\nEst architecto qui animi quasi non molestias soluta tempora corporis." },
                    { 149, 9, 65, 74756, new DateTime(2021, 6, 14, 14, 12, 6, 57, DateTimeKind.Local).AddTicks(3735), "aperiam" },
                    { 363, 84, 62, 960097, new DateTime(2021, 2, 9, 13, 35, 9, 276, DateTimeKind.Local).AddTicks(772), "qui" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 189, 9, 76, 927610, new DateTime(2021, 4, 20, 11, 22, 17, 117, DateTimeKind.Local).AddTicks(8013), "Quam vel facilis sint. Illum laborum ullam mollitia doloremque delectus ipsam assumenda. Eveniet est asperiores adipisci natus ex maiores illum cupiditate. Vero et sit quo dolores natus est voluptas voluptatem sint. Ipsum ullam qui incidunt et. Quas accusamus facilis." },
                    { 257, 9, 92, 919544, new DateTime(2021, 2, 26, 2, 43, 46, 138, DateTimeKind.Local).AddTicks(7045), "Consequatur ut corrupti a suscipit qui rem." },
                    { 358, 9, 31, 362936, new DateTime(2021, 4, 10, 2, 45, 36, 541, DateTimeKind.Local).AddTicks(3196), "Sit quo saepe ut voluptatem quod nostrum est.\nQuia ipsa et quibusdam enim aut quo quasi impedit.\nQuasi quibusdam et consequuntur iste et eius sed molestiae.\nVoluptate est autem recusandae sunt aspernatur repellendus omnis quidem magnam.\nEt eligendi et delectus eaque nihil ut rem labore.\nExcepturi voluptas qui debitis fugiat sint officia." },
                    { 92, 67, 138, 190654, new DateTime(2021, 8, 4, 1, 28, 28, 122, DateTimeKind.Local).AddTicks(6852), "repellat" },
                    { 117, 67, 31, 713074, new DateTime(2020, 11, 23, 23, 58, 11, 38, DateTimeKind.Local).AddTicks(6078), "Quas rerum est dolorem voluptas quos eveniet. Ut velit sunt sequi atque ullam animi delectus quia voluptas. Fugiat tempore nulla molestiae itaque iure quia. Est tempore libero sequi suscipit nam porro architecto tenetur. Et voluptatem explicabo quo qui ipsum sequi ea. Quo quos facilis voluptatem enim neque dolore doloremque earum expedita." },
                    { 161, 67, 147, 921811, new DateTime(2020, 10, 4, 21, 41, 1, 337, DateTimeKind.Local).AddTicks(2899), "saepe" },
                    { 256, 67, 25, 533204, new DateTime(2021, 6, 6, 8, 55, 21, 429, DateTimeKind.Local).AddTicks(1591), "Dolorem nemo architecto accusamus beatae reiciendis dolor accusamus." },
                    { 325, 67, 43, 524786, new DateTime(2020, 10, 28, 7, 10, 24, 372, DateTimeKind.Local).AddTicks(6350), "Accusantium error quia molestiae tempore. Officiis debitis dolor distinctio quibusdam. Fuga aperiam nobis blanditiis occaecati. Nulla odit voluptatibus dolores vitae. Velit id voluptatem." },
                    { 237, 9, 20, 391009, new DateTime(2021, 6, 23, 23, 58, 26, 250, DateTimeKind.Local).AddTicks(5141), "Saepe sint rerum error et eveniet.\nDolorem iure autem est dolore.\nSequi repellendus deserunt vitae magnam.\nSunt ut vero aliquam itaque dolores excepturi enim est.\nEt iste dolorem iusto natus blanditiis repellat veritatis rerum." },
                    { 275, 77, 12, 705051, new DateTime(2021, 6, 15, 23, 5, 37, 527, DateTimeKind.Local).AddTicks(3100), "Cupiditate eos exercitationem id blanditiis deleniti." },
                    { 310, 84, 142, 888687, new DateTime(2020, 11, 22, 9, 34, 3, 450, DateTimeKind.Local).AddTicks(2428), "nemo" },
                    { 155, 84, 65, 970482, new DateTime(2020, 12, 4, 5, 24, 52, 433, DateTimeKind.Local).AddTicks(587), "Exercitationem eius pariatur quo dolorum quia quod dolorem quas minima." },
                    { 446, 64, 11, 941791, new DateTime(2021, 7, 1, 22, 21, 51, 800, DateTimeKind.Local).AddTicks(1232), "totam" },
                    { 482, 64, 126, 917150, new DateTime(2021, 4, 10, 12, 33, 46, 514, DateTimeKind.Local).AddTicks(2805), "Consectetur quae atque ut est." },
                    { 496, 64, 27, 394869, new DateTime(2020, 11, 28, 11, 14, 41, 215, DateTimeKind.Local).AddTicks(2172), "eius" },
                    { 545, 64, 18, 389356, new DateTime(2020, 8, 20, 11, 58, 36, 898, DateTimeKind.Local).AddTicks(6932), "qui" },
                    { 562, 64, 128, 501070, new DateTime(2020, 8, 29, 15, 33, 55, 441, DateTimeKind.Local).AddTicks(6546), "Odio aliquid architecto.\nDeleniti perspiciatis nostrum tempore.\nEt autem non mollitia ut autem excepturi in temporibus.\nAut ab nemo similique aut nihil qui necessitatibus animi.\nTenetur veniam ratione corporis nemo perspiciatis velit perferendis voluptatem magnam.\nFacilis et excepturi distinctio dolorem at ad tempore explicabo animi." },
                    { 53, 69, 117, 708164, new DateTime(2020, 11, 24, 13, 19, 48, 84, DateTimeKind.Local).AddTicks(1122), "Laborum et harum veritatis molestias voluptatem eos corporis repellendus. Et atque voluptas qui. Quo et magnam tempore nulla et. Consequatur ipsum quia similique iste magnam. Voluptatibus animi voluptas architecto eum sapiente error qui et cum." },
                    { 101, 69, 109, 578565, new DateTime(2021, 4, 10, 8, 3, 2, 133, DateTimeKind.Local).AddTicks(4047), "suscipit" },
                    { 278, 84, 112, 796679, new DateTime(2020, 9, 5, 14, 25, 13, 213, DateTimeKind.Local).AddTicks(7694), "Voluptatem nihil voluptate ipsam quasi et at." },
                    { 137, 69, 50, 440709, new DateTime(2020, 9, 2, 7, 47, 41, 731, DateTimeKind.Local).AddTicks(7926), "Suscipit voluptate omnis in velit. Unde autem et. Beatae sit quis qui vitae incidunt nam repellendus natus minima." },
                    { 283, 69, 100, 794181, new DateTime(2021, 2, 6, 11, 54, 26, 233, DateTimeKind.Local).AddTicks(4297), "Et adipisci nesciunt itaque eos. Eaque at animi. Quia velit explicabo fugiat mollitia dolores. Voluptas officia dolorem est dolorem consequatur." },
                    { 408, 69, 101, 6481, new DateTime(2021, 1, 22, 22, 13, 31, 427, DateTimeKind.Local).AddTicks(9311), "sed" },
                    { 415, 69, 98, 827438, new DateTime(2021, 5, 1, 18, 50, 35, 263, DateTimeKind.Local).AddTicks(4812), "Et commodi delectus sapiente." },
                    { 595, 69, 115, 915163, new DateTime(2020, 12, 17, 10, 51, 58, 984, DateTimeKind.Local).AddTicks(2118), "Nesciunt accusamus vel eos." },
                    { 15, 84, 23, 763632, new DateTime(2021, 7, 19, 4, 43, 3, 673, DateTimeKind.Local).AddTicks(4579), "Quae rerum inventore earum quia non omnis.\nHarum voluptate laudantium voluptatem est.\nConsequatur laboriosam rerum animi fuga deserunt repudiandae praesentium.\nItaque quo dolor.\nLibero pariatur illo harum ipsum consequatur." },
                    { 115, 84, 18, 568057, new DateTime(2021, 3, 4, 23, 56, 26, 481, DateTimeKind.Local).AddTicks(4059), "Error tempore et quasi. Non provident similique est soluta qui debitis consectetur dolore. Consectetur sed similique. Veniam quos repudiandae quas quia. At a ut sequi velit non suscipit. Deserunt minima quibusdam aliquid officia id cumque." },
                    { 142, 84, 3, 863388, new DateTime(2021, 6, 1, 0, 40, 48, 904, DateTimeKind.Local).AddTicks(606), "In molestias doloremque." },
                    { 231, 69, 62, 906870, new DateTime(2020, 11, 17, 0, 46, 53, 578, DateTimeKind.Local).AddTicks(9207), "Cumque et ratione quaerat facere unde.\nEos eos velit qui incidunt.\nIllo saepe corporis delectus consequatur magni.\nSint quae dolorem placeat.\nMolestiae consequatur cumque vel hic ipsam est sit." },
                    { 296, 4, 106, 375635, new DateTime(2021, 6, 27, 11, 47, 42, 825, DateTimeKind.Local).AddTicks(5268), "Corrupti perferendis dolorem eaque doloremque incidunt aut nobis facilis. Voluptas et ea dolore ducimus optio minus fugit. Molestiae officia distinctio qui dolor repellendus voluptate perferendis. Doloremque incidunt consequatur soluta impedit provident." },
                    { 355, 77, 142, 453301, new DateTime(2020, 10, 15, 15, 35, 15, 566, DateTimeKind.Local).AddTicks(955), "Laborum iusto illo quidem autem voluptas omnis fugit. Porro vel laborum laboriosam praesentium molestiae. Qui iure necessitatibus deserunt repellat eaque nemo odit cumque." },
                    { 567, 77, 49, 120920, new DateTime(2021, 2, 22, 8, 55, 54, 308, DateTimeKind.Local).AddTicks(1665), "eos" },
                    { 493, 27, 53, 4405, new DateTime(2020, 10, 9, 20, 39, 41, 36, DateTimeKind.Local).AddTicks(7726), "Qui minus quisquam voluptatum." },
                    { 500, 27, 149, 994543, new DateTime(2020, 10, 6, 13, 42, 39, 38, DateTimeKind.Local).AddTicks(8452), "Ullam consequatur quibusdam molestiae commodi.\nEnim dignissimos vitae dolorem rerum harum ea fugit dolorem non." },
                    { 40, 6, 129, 382692, new DateTime(2021, 4, 20, 2, 17, 30, 634, DateTimeKind.Local).AddTicks(8454), "Iste pariatur occaecati nobis facere omnis perferendis accusamus laboriosam aut." },
                    { 114, 6, 65, 191456, new DateTime(2020, 11, 22, 8, 18, 36, 691, DateTimeKind.Local).AddTicks(7562), "Ut eos facere quibusdam sit libero iusto provident." },
                    { 163, 6, 9, 202473, new DateTime(2021, 2, 28, 5, 19, 36, 640, DateTimeKind.Local).AddTicks(343), "Dolore aperiam dolore excepturi omnis saepe ab suscipit exercitationem ipsa. Molestiae culpa ipsa et rerum. Voluptates eum libero beatae quia autem." },
                    { 326, 6, 35, 375863, new DateTime(2020, 11, 26, 4, 50, 0, 189, DateTimeKind.Local).AddTicks(938), "Ipsum explicabo eveniet ratione quia veritatis et." },
                    { 399, 6, 31, 203814, new DateTime(2021, 3, 29, 6, 47, 44, 566, DateTimeKind.Local).AddTicks(2212), "Nisi qui rerum similique quidem earum rerum aperiam. Sequi libero ut dignissimos optio dolor maxime voluptate sit. Voluptatem veniam mollitia inventore tenetur qui accusamus ab cupiditate. Corporis minima non. Magnam tenetur ratione animi." },
                    { 549, 6, 86, 587700, new DateTime(2021, 8, 4, 0, 53, 27, 709, DateTimeKind.Local).AddTicks(2037), "Qui minus sequi minus nesciunt dolor ullam eius.\nQuaerat expedita ut qui ab sed repudiandae qui.\nRepudiandae et saepe facere nostrum quia quod officia.\nNulla voluptatem et amet aspernatur vel quam ipsum nesciunt voluptatem.\nAdipisci nam neque est error quidem." },
                    { 557, 6, 9, 268550, new DateTime(2021, 2, 8, 22, 8, 7, 737, DateTimeKind.Local).AddTicks(6862), "Accusantium porro possimus repellendus eum." },
                    { 54, 18, 123, 199756, new DateTime(2020, 10, 6, 11, 49, 27, 965, DateTimeKind.Local).AddTicks(7825), "Quod aperiam omnis earum accusantium." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 208, 18, 139, 546092, new DateTime(2021, 5, 31, 1, 14, 13, 947, DateTimeKind.Local).AddTicks(2680), "Consequuntur vero reprehenderit et nihil excepturi qui." },
                    { 261, 18, 48, 504803, new DateTime(2020, 9, 8, 4, 38, 8, 539, DateTimeKind.Local).AddTicks(6967), "Ut eum fugiat.\nVoluptatem maiores ab quia.\nArchitecto harum impedit voluptatem et molestiae aut et doloribus.\nNam in incidunt.\nIpsum accusantium quibusdam odit placeat." },
                    { 375, 18, 116, 660671, new DateTime(2020, 8, 14, 14, 25, 9, 375, DateTimeKind.Local).AddTicks(9199), "molestias" },
                    { 423, 18, 3, 531267, new DateTime(2021, 5, 9, 12, 7, 29, 416, DateTimeKind.Local).AddTicks(4892), "Voluptate enim sapiente assumenda ipsa voluptatem maxime laborum sint rem. Quis fuga aliquid sit vero. Esse omnis aut eos cum recusandae aut omnis dolores. Aut nam dolorem in corrupti est similique." },
                    { 86, 49, 63, 933501, new DateTime(2021, 2, 3, 6, 35, 14, 288, DateTimeKind.Local).AddTicks(8574), "officiis" },
                    { 457, 27, 34, 823320, new DateTime(2021, 1, 4, 4, 52, 30, 555, DateTimeKind.Local).AddTicks(4273), "Aspernatur aperiam deserunt illo fugit reiciendis neque nihil dolorem." },
                    { 341, 27, 80, 631607, new DateTime(2021, 2, 16, 7, 40, 55, 466, DateTimeKind.Local).AddTicks(6720), "Velit aspernatur explicabo." },
                    { 307, 27, 118, 307062, new DateTime(2020, 12, 20, 11, 5, 46, 989, DateTimeKind.Local).AddTicks(5916), "Quo dolorem quas sint itaque odio excepturi illo. Ducimus iusto quia dolores placeat qui velit incidunt omnis voluptatem. Eum recusandae non unde voluptatem rerum aut. Libero sunt asperiores consequatur illum provident recusandae consequatur. Autem debitis sunt minima. Eligendi rerum est quae nam id et ad quas sed." },
                    { 150, 27, 112, 521063, new DateTime(2020, 12, 1, 20, 24, 38, 900, DateTimeKind.Local).AddTicks(5596), "Dolorem culpa nemo animi minus. Sunt eligendi nostrum asperiores. Doloribus vitae atque consequuntur minima expedita vel sit aut. Eum eligendi placeat debitis. Non fugit rem nisi." },
                    { 66, 31, 57, 438173, new DateTime(2021, 7, 28, 14, 37, 39, 428, DateTimeKind.Local).AddTicks(8782), "Dolorum quis dignissimos." },
                    { 118, 31, 60, 964323, new DateTime(2021, 4, 25, 11, 23, 24, 473, DateTimeKind.Local).AddTicks(7013), "Animi quaerat labore quos voluptas.\nEst suscipit optio illum.\nAsperiores earum cum assumenda provident molestiae voluptate." },
                    { 483, 31, 30, 849762, new DateTime(2021, 5, 13, 6, 43, 40, 327, DateTimeKind.Local).AddTicks(4714), "Qui voluptas ut non et consequuntur officia aut quis.\nCorporis necessitatibus iste et soluta veniam et quia.\nCum aut aspernatur facilis atque aliquam cumque itaque aspernatur.\nFugiat occaecati assumenda ut omnis adipisci sint repellat recusandae animi.\nDistinctio non repellat atque maxime.\nUt dignissimos expedita harum molestias distinctio maxime." },
                    { 12, 24, 47, 456006, new DateTime(2020, 8, 11, 15, 56, 11, 598, DateTimeKind.Local).AddTicks(3841), "Et beatae et est consequatur harum qui dicta.\nConsequatur quas officiis impedit cupiditate consequatur quis esse." },
                    { 218, 24, 74, 991302, new DateTime(2021, 6, 28, 1, 14, 23, 191, DateTimeKind.Local).AddTicks(150), "Cum molestiae nam amet occaecati facilis aut quidem sed. Dolores accusantium et molestiae. Illo tempore et. Id ullam reprehenderit similique. Vel qui autem laboriosam nobis ut. Nobis pariatur aperiam." },
                    { 304, 24, 49, 196932, new DateTime(2021, 3, 30, 7, 43, 34, 662, DateTimeKind.Local).AddTicks(2232), "Ad aperiam corporis quis dolores unde minus mollitia." },
                    { 338, 24, 71, 833902, new DateTime(2020, 11, 12, 1, 39, 22, 612, DateTimeKind.Local).AddTicks(1293), "Eius maiores aut aut sequi minima exercitationem voluptas reprehenderit." },
                    { 449, 49, 144, 647066, new DateTime(2021, 4, 16, 19, 54, 59, 347, DateTimeKind.Local).AddTicks(3339), "Sapiente deleniti cum.\nConsequatur veritatis et quia earum.\nQuidem quod expedita ipsam eaque sint minima eius autem ut.\nLaboriosam aut animi alias repellat vel." },
                    { 433, 24, 131, 140115, new DateTime(2020, 9, 26, 19, 26, 34, 978, DateTimeKind.Local).AddTicks(9108), "Ut molestiae ut.\nEt magnam maiores qui iusto sint provident autem.\nSint voluptates placeat similique assumenda." },
                    { 515, 24, 75, 447411, new DateTime(2020, 8, 24, 23, 37, 20, 443, DateTimeKind.Local).AddTicks(3190), "Ipsum hic totam nobis qui dicta." },
                    { 574, 24, 57, 239375, new DateTime(2021, 5, 5, 5, 47, 20, 66, DateTimeKind.Local).AddTicks(3563), "voluptatum" },
                    { 22, 27, 34, 466259, new DateTime(2021, 7, 17, 14, 52, 21, 300, DateTimeKind.Local).AddTicks(8671), "Temporibus ea sit et." },
                    { 64, 27, 38, 943454, new DateTime(2020, 10, 1, 0, 10, 14, 651, DateTimeKind.Local).AddTicks(5519), "Laborum iste esse provident quis est corporis nostrum quis vero." },
                    { 79, 27, 54, 88872, new DateTime(2021, 1, 5, 6, 49, 22, 417, DateTimeKind.Local).AddTicks(3452), "Sapiente adipisci quam.\nExcepturi et explicabo aut.\nAd quo voluptas nulla incidunt cum." },
                    { 124, 27, 116, 86428, new DateTime(2020, 10, 18, 4, 59, 51, 755, DateTimeKind.Local).AddTicks(6466), "Voluptatem numquam accusantium maxime labore aliquid laboriosam quas natus autem." },
                    { 136, 27, 20, 12114, new DateTime(2020, 11, 28, 4, 40, 55, 181, DateTimeKind.Local).AddTicks(2458), "Repellendus nam accusantium laborum eligendi omnis aut illum maiores.\nExercitationem nostrum asperiores qui quam omnis et sit." },
                    { 475, 24, 21, 786549, new DateTime(2021, 4, 26, 8, 17, 47, 646, DateTimeKind.Local).AddTicks(2746), "Voluptatem provident nemo aut accusantium enim. Explicabo illum dolorem aliquam assumenda tenetur sit. Quis mollitia eos autem." },
                    { 47, 31, 73, 667004, new DateTime(2021, 5, 8, 1, 47, 0, 840, DateTimeKind.Local).AddTicks(8667), "Aut et aspernatur qui quas ut ipsam et labore sed. Et beatae natus qui facilis consequuntur non eum. Cumque unde ullam et dignissimos aut consequatur voluptatibus corrupti." },
                    { 523, 49, 136, 245915, new DateTime(2021, 2, 22, 15, 40, 34, 877, DateTimeKind.Local).AddTicks(1531), "perferendis" },
                    { 129, 41, 13, 605606, new DateTime(2021, 3, 3, 23, 29, 27, 594, DateTimeKind.Local).AddTicks(5513), "Beatae quos sint nulla hic ratione nemo dolorem iste rerum." },
                    { 301, 37, 130, 795087, new DateTime(2021, 4, 21, 13, 59, 39, 550, DateTimeKind.Local).AddTicks(4780), "Quia quae error deserunt dolorem possimus sed. Omnis repellendus dicta perspiciatis nisi ut ullam quas expedita. Ut alias et laborum sed repudiandae. Aut dolor est. Dolorem esse sapiente et et eos omnis." },
                    { 427, 37, 41, 468590, new DateTime(2021, 5, 6, 14, 49, 30, 883, DateTimeKind.Local).AddTicks(2951), "Repellendus non sequi ab accusantium. Aut similique eum sunt eos est. Odio quia explicabo consequuntur vel quos sint. Quam aut quis consequatur sed enim magnam quisquam veritatis facere." },
                    { 565, 37, 38, 854117, new DateTime(2021, 3, 18, 21, 12, 52, 637, DateTimeKind.Local).AddTicks(1084), "Aut iure nulla laboriosam accusamus et dolorum culpa odio sit." },
                    { 568, 37, 11, 66466, new DateTime(2021, 2, 4, 17, 42, 1, 389, DateTimeKind.Local).AddTicks(702), "Ut id illum." },
                    { 582, 37, 27, 991216, new DateTime(2020, 12, 12, 8, 8, 42, 369, DateTimeKind.Local).AddTicks(6471), "Quis maxime vel eaque quisquam.\nMinus nihil veritatis sit molestiae." },
                    { 216, 71, 93, 538355, new DateTime(2021, 3, 10, 9, 48, 3, 349, DateTimeKind.Local).AddTicks(4883), "Molestias temporibus repellendus omnis et odio non ut. Temporibus consequatur est voluptatibus doloribus aliquid at quod molestiae sint. Assumenda voluptas animi ut dolores ut et doloribus maxime. Voluptas rerum quibusdam repudiandae itaque soluta." },
                    { 333, 71, 86, 787502, new DateTime(2021, 3, 24, 14, 13, 35, 625, DateTimeKind.Local).AddTicks(7394), "Rerum placeat autem tempora totam ut recusandae magni." },
                    { 383, 71, 149, 858381, new DateTime(2020, 12, 19, 4, 13, 57, 467, DateTimeKind.Local).AddTicks(3526), "Placeat facere blanditiis." },
                    { 437, 71, 39, 415131, new DateTime(2020, 11, 3, 23, 17, 42, 540, DateTimeKind.Local).AddTicks(428), "tempora" },
                    { 445, 71, 59, 142925, new DateTime(2020, 10, 19, 12, 1, 26, 928, DateTimeKind.Local).AddTicks(5833), "eos" },
                    { 99, 1, 115, 68396, new DateTime(2020, 10, 12, 12, 56, 10, 256, DateTimeKind.Local).AddTicks(4680), "Accusamus vitae unde sunt delectus rerum qui velit. Voluptatem in similique vero. Dignissimos quo qui est omnis qui voluptate provident. Quod nulla quia molestias et aliquid qui. Numquam praesentium esse. Et inventore laboriosam laborum quia fugiat quae aut." },
                    { 113, 1, 99, 470197, new DateTime(2020, 10, 7, 1, 35, 26, 929, DateTimeKind.Local).AddTicks(8394), "Consectetur eos illo consequatur aliquam harum nam. Nisi et nostrum corrupti voluptatibus. Ut a quia consequatur est." },
                    { 194, 1, 72, 308854, new DateTime(2020, 12, 26, 10, 14, 49, 79, DateTimeKind.Local).AddTicks(5236), "Reiciendis adipisci reprehenderit recusandae. Laudantium harum inventore. Et sunt molestiae. Voluptatem odio non beatae neque id. Nobis illo officia quis. Perspiciatis nulla dignissimos odio eveniet qui ullam." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 321, 1, 76, 529992, new DateTime(2021, 8, 4, 21, 42, 16, 533, DateTimeKind.Local).AddTicks(4089), "odio" },
                    { 332, 1, 144, 392653, new DateTime(2021, 1, 10, 6, 26, 12, 343, DateTimeKind.Local).AddTicks(9465), "Quo pariatur illo rerum et est.\nId quis tempora sit ullam eos omnis." },
                    { 282, 37, 75, 512225, new DateTime(2020, 12, 28, 2, 27, 26, 415, DateTimeKind.Local).AddTicks(5035), "quia" },
                    { 281, 37, 127, 513554, new DateTime(2021, 1, 7, 9, 35, 42, 299, DateTimeKind.Local).AddTicks(4691), "omnis" },
                    { 279, 37, 18, 627343, new DateTime(2020, 12, 19, 4, 39, 54, 393, DateTimeKind.Local).AddTicks(3872), "Sit pariatur neque facere ipsa et." },
                    { 78, 37, 84, 176843, new DateTime(2021, 2, 10, 13, 3, 7, 859, DateTimeKind.Local).AddTicks(2901), "Maiores et tempore cum repellendus repellat soluta molestiae.\nExcepturi a aut et accusantium laudantium autem.\nNesciunt sint repudiandae ad impedit.\nUt eum omnis quia vitae quo ad nesciunt eos et.\nBlanditiis voluptas sit autem laboriosam." },
                    { 148, 41, 92, 436357, new DateTime(2020, 9, 7, 13, 27, 5, 931, DateTimeKind.Local).AddTicks(1942), "Odit repellendus nulla debitis tenetur magnam maiores rerum explicabo." },
                    { 169, 41, 48, 507912, new DateTime(2020, 8, 22, 14, 1, 21, 690, DateTimeKind.Local).AddTicks(766), "Et nobis hic nemo consequatur id. Temporibus atque necessitatibus eum nihil. Ut adipisci in aspernatur rem distinctio dolor quae maxime. Eum suscipit possimus et placeat neque ut similique. Ut eligendi cumque odio harum et perspiciatis voluptatem accusantium eos. Voluptatem rem dolorum numquam in molestiae." },
                    { 276, 41, 90, 20307, new DateTime(2021, 4, 12, 18, 0, 29, 808, DateTimeKind.Local).AddTicks(6192), "Vel culpa dolorum quod corporis hic debitis.\nAliquam non eveniet nobis reiciendis deserunt ut pariatur numquam.\nSit incidunt facilis quasi.\nVoluptatem deleniti mollitia ut error.\nUt ea delectus necessitatibus alias nulla eos molestiae velit." },
                    { 563, 41, 134, 270369, new DateTime(2020, 10, 30, 5, 54, 48, 758, DateTimeKind.Local).AddTicks(6991), "dolores" },
                    { 575, 41, 142, 28725, new DateTime(2021, 5, 17, 13, 54, 25, 502, DateTimeKind.Local).AddTicks(7490), "Aut molestias laudantium fugit." },
                    { 292, 16, 59, 797228, new DateTime(2021, 8, 4, 22, 25, 50, 53, DateTimeKind.Local).AddTicks(6243), "Veritatis autem in laudantium dolorum." },
                    { 295, 16, 6, 172323, new DateTime(2021, 7, 10, 2, 16, 35, 922, DateTimeKind.Local).AddTicks(3922), "Doloremque dolorem ab qui." },
                    { 540, 49, 116, 171242, new DateTime(2020, 10, 6, 3, 57, 29, 402, DateTimeKind.Local).AddTicks(2099), "Ut quibusdam voluptatem doloremque atque.\nMolestiae odio quidem doloribus unde accusantium.\nLaudantium repellendus non provident illo consectetur qui distinctio necessitatibus consectetur.\nAnimi accusamus possimus.\nError eveniet tempore occaecati.\nSapiente assumenda consequatur hic." },
                    { 456, 16, 25, 665121, new DateTime(2021, 7, 24, 6, 48, 33, 257, DateTimeKind.Local).AddTicks(607), "Iure et tempore temporibus nemo voluptatem. Quis inventore sapiente sequi aut architecto. Reiciendis et sit dolores sed tempora consequuntur sunt itaque molestiae. Labore nostrum repellat eum sint officiis quo delectus provident voluptatem." },
                    { 572, 16, 136, 2386, new DateTime(2021, 5, 20, 5, 5, 22, 562, DateTimeKind.Local).AddTicks(1607), "Error omnis in ut fugit in qui.\nImpedit enim qui ut ratione laudantium vero hic.\nEnim repudiandae unde deleniti minima aperiam qui excepturi.\nEarum quis quos eaque.\nOfficiis sunt magni omnis temporibus illo enim nostrum rerum." },
                    { 141, 17, 71, 472661, new DateTime(2021, 1, 21, 13, 43, 9, 267, DateTimeKind.Local).AddTicks(5312), "Delectus voluptatem deserunt qui laboriosam earum id ut. Atque deleniti soluta sit. Officia tenetur occaecati." },
                    { 266, 17, 2, 29984, new DateTime(2021, 6, 12, 15, 53, 57, 272, DateTimeKind.Local).AddTicks(2738), "Excepturi pariatur deleniti autem. Ut nulla recusandae similique quos earum aut est in. Ut eveniet voluptas. Dignissimos facilis hic voluptatem sed. Quae voluptates expedita recusandae est. Iure iste neque perspiciatis hic nobis." },
                    { 360, 17, 143, 517453, new DateTime(2021, 6, 14, 16, 41, 49, 96, DateTimeKind.Local).AddTicks(2194), "quasi" },
                    { 381, 17, 66, 447012, new DateTime(2021, 7, 10, 1, 53, 17, 242, DateTimeKind.Local).AddTicks(5035), "Fugiat cumque asperiores recusandae fugit et. Mollitia ullam cupiditate qui. Amet quis minus. Voluptatem illo ratione suscipit provident perferendis. Ex doloremque molestias libero a." },
                    { 450, 17, 96, 878751, new DateTime(2021, 6, 12, 8, 35, 4, 699, DateTimeKind.Local).AddTicks(4035), "Consequatur deleniti aut mollitia." },
                    { 467, 17, 103, 346796, new DateTime(2020, 8, 31, 7, 15, 25, 886, DateTimeKind.Local).AddTicks(7584), "Maiores quidem eum omnis amet saepe quae quia. Voluptates molestiae doloribus voluptatibus doloribus. Aliquam corporis sunt omnis eos consequatur voluptatem." },
                    { 551, 16, 94, 378248, new DateTime(2021, 5, 26, 5, 23, 13, 809, DateTimeKind.Local).AddTicks(3588), "Eaque sed non rem iste.\nDolor porro consectetur laudantium fuga dolor nihil.\nQuisquam error laudantium minus facere est est eum fuga." },
                    { 535, 14, 65, 377458, new DateTime(2020, 10, 20, 0, 35, 51, 237, DateTimeKind.Local).AddTicks(2340), "aut" },
                    { 511, 14, 40, 665102, new DateTime(2021, 7, 11, 22, 29, 1, 598, DateTimeKind.Local).AddTicks(5713), "Velit corrupti aliquam totam dolorem enim aut dicta.\nEt maiores error nisi veniam ratione molestias aliquid itaque." },
                    { 238, 14, 132, 15427, new DateTime(2021, 2, 23, 11, 12, 3, 195, DateTimeKind.Local).AddTicks(3477), "ut" },
                    { 560, 80, 81, 473212, new DateTime(2020, 11, 17, 18, 39, 43, 200, DateTimeKind.Local).AddTicks(8938), "sed" },
                    { 327, 2, 11, 62229, new DateTime(2021, 2, 16, 5, 16, 18, 470, DateTimeKind.Local).AddTicks(663), "Cumque distinctio velit voluptatem qui iste ab et quia necessitatibus." },
                    { 359, 2, 31, 456210, new DateTime(2021, 3, 6, 16, 18, 53, 559, DateTimeKind.Local).AddTicks(7186), "Ducimus iste dolore dolores nihil quia voluptatem veritatis." },
                    { 533, 2, 121, 330048, new DateTime(2021, 1, 23, 22, 21, 17, 978, DateTimeKind.Local).AddTicks(1548), "Ullam vel saepe. Et dolor totam aut hic aliquid eum nihil in. Est perferendis doloremque autem dignissimos et esse nisi quia et. Unde nihil ut ipsam in facere eveniet maxime ut velit. Ea aut quidem soluta perferendis." },
                    { 74, 39, 38, 372207, new DateTime(2021, 1, 16, 5, 43, 40, 611, DateTimeKind.Local).AddTicks(1235), "Ut accusantium reiciendis porro voluptas voluptates. Possimus corporis beatae excepturi totam maxime repellat. Inventore rerum ab. Ex dolorum saepe est minima. Tempora quaerat dolores consequuntur." },
                    { 127, 39, 135, 763203, new DateTime(2020, 8, 22, 0, 50, 22, 19, DateTimeKind.Local).AddTicks(3082), "Omnis eius consequuntur." },
                    { 139, 39, 143, 313244, new DateTime(2020, 9, 14, 11, 0, 33, 731, DateTimeKind.Local).AddTicks(6947), "Est molestiae perferendis dicta provident sed facilis rerum laboriosam ullam. Dicta sunt quo necessitatibus nihil. Asperiores provident dignissimos rerum. Maiores voluptatibus quasi nulla reprehenderit consequatur." },
                    { 209, 39, 105, 497640, new DateTime(2021, 5, 14, 23, 47, 31, 862, DateTimeKind.Local).AddTicks(1468), "Provident sed cupiditate incidunt itaque aut.\nEst nobis et.\nIllum eius debitis quibusdam nam a qui quaerat.\nAutem omnis culpa quaerat libero ut omnis autem in.\nUt distinctio quam." },
                    { 260, 39, 20, 442941, new DateTime(2021, 7, 14, 6, 3, 33, 213, DateTimeKind.Local).AddTicks(2232), "Nobis perferendis eum consequatur tenetur sit saepe. Sunt aut sed qui ut. Qui mollitia delectus sequi est. Corrupti rerum voluptates." },
                    { 262, 39, 117, 616099, new DateTime(2021, 4, 7, 8, 58, 16, 688, DateTimeKind.Local).AddTicks(1293), "Sequi error dicta.\nAnimi perspiciatis nulla." },
                    { 265, 39, 54, 809870, new DateTime(2021, 3, 24, 14, 46, 16, 421, DateTimeKind.Local).AddTicks(9999), "Ratione possimus quis laudantium autem illo et neque.\nUt aut at esse hic voluptates nostrum dignissimos velit quod." },
                    { 374, 39, 40, 817335, new DateTime(2021, 5, 24, 7, 52, 2, 661, DateTimeKind.Local).AddTicks(5121), "Et est repudiandae nihil dolorem consequuntur architecto ut.\nBeatae magni repellendus incidunt quia neque quos non iusto.\nIure repellat error.\nOmnis cum in voluptas maxime maxime est voluptatum laboriosam maiores.\nDoloremque est ad." },
                    { 414, 39, 105, 804001, new DateTime(2021, 4, 27, 23, 1, 45, 979, DateTimeKind.Local).AddTicks(783), "Quas libero corrupti aliquid rem quia et. Deleniti aspernatur minima reprehenderit et. Ipsa sit atque maiores molestias quos est officia distinctio. Et reprehenderit a maxime eius minima possimus." },
                    { 469, 39, 93, 56795, new DateTime(2021, 1, 8, 4, 11, 41, 649, DateTimeKind.Local).AddTicks(2508), "quis" },
                    { 524, 39, 68, 577158, new DateTime(2020, 8, 20, 16, 35, 3, 492, DateTimeKind.Local).AddTicks(13), "Provident consequatur facilis debitis esse voluptatem culpa eos ipsum. Doloremque necessitatibus voluptas sint perferendis sint et. Doloribus eveniet eos esse in illum. Qui autem odit facere nesciunt voluptatem deserunt vero non." },
                    { 455, 80, 49, 669563, new DateTime(2021, 3, 17, 16, 17, 52, 908, DateTimeKind.Local).AddTicks(5293), "Explicabo iste non quia ab beatae." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 417, 80, 28, 548705, new DateTime(2021, 1, 20, 19, 5, 20, 803, DateTimeKind.Local).AddTicks(3592), "Dignissimos beatae magnam et quae velit nisi doloribus officia quam. Harum quo in dolorum. Non quos omnis vero sapiente esse adipisci." },
                    { 339, 80, 52, 210964, new DateTime(2021, 5, 13, 20, 9, 53, 509, DateTimeKind.Local).AddTicks(9039), "Quis occaecati sit cum incidunt." },
                    { 10, 80, 83, 692051, new DateTime(2021, 1, 29, 18, 45, 9, 558, DateTimeKind.Local).AddTicks(5539), "Voluptas ut autem ducimus est vero ut est hic quasi.\nProvident nam qui et vitae similique voluptatem beatae iure voluptas." },
                    { 145, 23, 146, 186310, new DateTime(2020, 10, 21, 11, 57, 40, 996, DateTimeKind.Local).AddTicks(1359), "minima" },
                    { 162, 23, 143, 604291, new DateTime(2021, 7, 23, 7, 23, 22, 158, DateTimeKind.Local).AddTicks(5737), "tenetur" },
                    { 314, 23, 48, 490590, new DateTime(2020, 9, 21, 19, 52, 15, 5, DateTimeKind.Local).AddTicks(1248), "Ad voluptas eveniet culpa quia iure qui neque." },
                    { 430, 23, 90, 118917, new DateTime(2021, 4, 13, 23, 7, 23, 292, DateTimeKind.Local).AddTicks(7439), "Natus esse consequatur inventore cum aliquam totam pariatur rerum." },
                    { 573, 23, 147, 975116, new DateTime(2021, 7, 8, 23, 33, 40, 58, DateTimeKind.Local).AddTicks(5959), "Dolor aut consectetur.\nEveniet est aut quia quis occaecati vel accusantium sint blanditiis.\nVelit tempore odio.\nDucimus perferendis cumque quasi eveniet aliquid sit.\nQuia voluptatum aspernatur magni hic eum sequi omnis ea ullam." },
                    { 18, 76, 127, 390583, new DateTime(2021, 8, 7, 1, 13, 52, 338, DateTimeKind.Local).AddTicks(3329), "voluptatem" },
                    { 67, 76, 104, 880609, new DateTime(2020, 10, 8, 23, 10, 2, 63, DateTimeKind.Local).AddTicks(6438), "Aut expedita sequi omnis architecto dolor sed at nihil voluptas." },
                    { 538, 39, 147, 882260, new DateTime(2020, 12, 11, 1, 12, 57, 310, DateTimeKind.Local).AddTicks(5745), "Numquam sit doloremque nulla nesciunt aperiam asperiores possimus." },
                    { 98, 76, 49, 244579, new DateTime(2021, 4, 10, 13, 44, 18, 191, DateTimeKind.Local).AddTicks(8757), "Aut molestiae expedita. Illum sit labore ducimus dignissimos quos. In eum accusamus omnis. Quia esse eum ut et mollitia quis. Illo magnam neque in consequatur id. Culpa illum et praesentium et explicabo totam similique dolorum quo." },
                    { 178, 76, 139, 575510, new DateTime(2021, 1, 31, 20, 39, 28, 974, DateTimeKind.Local).AddTicks(9038), "Ipsa eius odit enim consequuntur. Velit sed ut eum vel blanditiis unde blanditiis. Dolorum sequi nam odit autem animi. Est consequatur perferendis ut nihil. Veniam nobis itaque neque nobis qui earum ea in." },
                    { 185, 76, 145, 825709, new DateTime(2021, 6, 2, 18, 24, 18, 755, DateTimeKind.Local).AddTicks(5850), "minus" },
                    { 273, 76, 149, 981050, new DateTime(2021, 6, 6, 6, 7, 51, 509, DateTimeKind.Local).AddTicks(1233), "quasi" },
                    { 351, 76, 132, 442814, new DateTime(2020, 12, 18, 0, 30, 22, 292, DateTimeKind.Local).AddTicks(8286), "Eaque corrupti ex quod facere distinctio in et odit.\nQuia sequi qui fugiat voluptas voluptas.\nVoluptate libero aspernatur ut molestiae nulla qui impedit labore aut.\nVoluptas cumque quo et qui similique suscipit sapiente ipsam laboriosam.\nEt tempora rem adipisci.\nBeatae et qui facere et." },
                    { 426, 76, 90, 222774, new DateTime(2021, 5, 11, 12, 30, 40, 40, DateTimeKind.Local).AddTicks(8912), "Possimus consequatur voluptatem blanditiis quidem." },
                    { 461, 76, 94, 863616, new DateTime(2020, 11, 19, 0, 10, 50, 342, DateTimeKind.Local).AddTicks(2603), "Occaecati maxime incidunt.\nQuos quam ut.\nReprehenderit voluptate omnis.\nQuas id architecto odio natus dolores.\nBlanditiis corrupti doloremque quo ad.\nNumquam officiis alias vel." },
                    { 531, 76, 20, 64897, new DateTime(2020, 12, 29, 19, 29, 11, 273, DateTimeKind.Local).AddTicks(2604), "Quisquam dolor qui quam perspiciatis hic asperiores vel ut in. Id eaque tempora enim. Tempore quas ea assumenda." },
                    { 159, 76, 64, 926306, new DateTime(2021, 7, 21, 16, 9, 40, 466, DateTimeKind.Local).AddTicks(8002), "aliquam" },
                    { 558, 39, 125, 765287, new DateTime(2020, 11, 6, 12, 55, 18, 163, DateTimeKind.Local).AddTicks(5696), "Nam pariatur quo quaerat.\nUt odio sed vero adipisci incidunt impedit.\nConsequatur vel alias tempore quasi.\nQuo rerum recusandae.\nOmnis quisquam nostrum architecto deleniti rem.\nAliquam nisi animi omnis occaecati ut ipsa officia et qui." },
                    { 583, 39, 121, 343936, new DateTime(2021, 8, 7, 8, 24, 37, 955, DateTimeKind.Local).AddTicks(4719), "Est et consequatur voluptas quas. Consequuntur explicabo qui odit dicta praesentium velit doloremque. Dolor aut totam fugit." },
                    { 106, 44, 57, 954863, new DateTime(2021, 4, 24, 18, 40, 1, 489, DateTimeKind.Local).AddTicks(9791), "Magni minus velit ut rerum." },
                    { 570, 3, 34, 214566, new DateTime(2020, 9, 22, 4, 38, 24, 732, DateTimeKind.Local).AddTicks(6288), "Ipsum dolorem dolore laborum.\nEum culpa et harum rerum beatae qui facere.\nVoluptas laboriosam qui pariatur voluptate nisi fuga est." },
                    { 195, 70, 33, 246661, new DateTime(2021, 4, 26, 2, 26, 8, 713, DateTimeKind.Local).AddTicks(1571), "Assumenda vel nesciunt eligendi." },
                    { 210, 70, 10, 432346, new DateTime(2021, 1, 8, 21, 6, 6, 175, DateTimeKind.Local).AddTicks(7155), "Reprehenderit in ipsum ratione odio. Exercitationem at ea aut magnam laboriosam deleniti. Ipsa est ut voluptatem error officia magnam quod ratione. Nihil ut in reiciendis vel ut delectus. Maiores ut laudantium reiciendis." },
                    { 229, 70, 82, 857270, new DateTime(2020, 12, 19, 1, 31, 6, 618, DateTimeKind.Local).AddTicks(6520), "Unde facere eveniet molestias. Et eos incidunt nihil similique et vel eligendi. Sunt consectetur recusandae. Mollitia non suscipit dolores ex nam fugit. Id iste voluptatem laborum iusto dignissimos saepe." },
                    { 290, 70, 58, 6015, new DateTime(2020, 8, 17, 23, 3, 21, 59, DateTimeKind.Local).AddTicks(2633), "Minima cumque est.\nVelit a impedit unde eos dolorem sed dicta sapiente.\nVoluptas officiis harum dicta eos." },
                    { 396, 70, 3, 895403, new DateTime(2021, 5, 12, 16, 39, 7, 528, DateTimeKind.Local).AddTicks(411), "Ut amet qui blanditiis quia odit qui quis. Sed dolor repellat. Et quia voluptatem delectus nemo fugit pariatur omnis. Alias consequatur veniam debitis aut. Dolorum corrupti magnam quidem quaerat sint harum." },
                    { 444, 70, 12, 784415, new DateTime(2021, 7, 23, 15, 57, 33, 536, DateTimeKind.Local).AddTicks(5475), "Suscipit necessitatibus eaque ut illum qui voluptatem eveniet.\nRatione velit ab culpa.\nQui possimus corrupti repellendus omnis odit." },
                    { 108, 3, 78, 704167, new DateTime(2021, 4, 23, 17, 46, 8, 828, DateTimeKind.Local).AddTicks(4652), "qui" },
                    { 490, 70, 32, 891923, new DateTime(2021, 6, 22, 3, 13, 7, 113, DateTimeKind.Local).AddTicks(2768), "Aut aperiam repellat omnis est doloribus ut.\nSimilique eos consequatur nobis reiciendis quod placeat." },
                    { 274, 54, 146, 938008, new DateTime(2021, 7, 25, 10, 22, 40, 510, DateTimeKind.Local).AddTicks(2343), "Voluptatem excepturi placeat illo aut minus earum id ab. Quod quia distinctio voluptate quod recusandae a ex delectus mollitia. Et est blanditiis voluptatem omnis. Temporibus eveniet voluptatem vel sequi. Sunt deserunt nesciunt ipsam numquam illo sit. Atque dolore iusto iste harum sunt distinctio odio." },
                    { 331, 54, 39, 820930, new DateTime(2020, 11, 23, 10, 41, 40, 621, DateTimeKind.Local).AddTicks(5289), "aut" },
                    { 429, 54, 58, 525855, new DateTime(2020, 11, 27, 17, 32, 35, 981, DateTimeKind.Local).AddTicks(3913), "Mollitia corporis dolorem dolorem est voluptas cupiditate beatae repellendus. Alias necessitatibus temporibus tempora et soluta architecto quia deserunt. Ut tenetur aut quae et. Perspiciatis natus dolore. Quia quae omnis commodi unde beatae est. Rem ea labore." },
                    { 506, 54, 148, 859651, new DateTime(2021, 2, 4, 12, 43, 58, 232, DateTimeKind.Local).AddTicks(1630), "Laboriosam ducimus quo ratione ut velit. Quidem asperiores occaecati harum quis iusto. Reiciendis error assumenda eaque consequatur voluptatibus. Modi atque et cumque aut quis modi nulla cupiditate et." },
                    { 586, 54, 104, 25108, new DateTime(2021, 5, 17, 15, 18, 31, 830, DateTimeKind.Local).AddTicks(690), "Eum qui unde qui qui consequatur delectus provident." },
                    { 62, 14, 66, 25143, new DateTime(2021, 2, 20, 17, 19, 14, 438, DateTimeKind.Local).AddTicks(4283), "Porro accusantium quos nemo et. Aliquid blanditiis in a recusandae et sint adipisci et. Saepe molestiae id ut non est esse itaque necessitatibus quo. Distinctio sequi aut officia architecto possimus. Aut vel ullam aut in aut qui beatae rerum nostrum." },
                    { 234, 14, 84, 307895, new DateTime(2021, 1, 28, 4, 24, 51, 205, DateTimeKind.Local).AddTicks(3325), "Est eum ut iste possimus voluptates.\nImpedit numquam distinctio.\nDicta eveniet sapiente tenetur.\nRepellat neque voluptatem quisquam.\nNisi enim molestias cumque ut." },
                    { 104, 54, 28, 527121, new DateTime(2021, 6, 9, 1, 31, 7, 589, DateTimeKind.Local).AddTicks(9055), "Rerum saepe quia numquam autem et et quidem. Ipsum ut voluptates et dolores rerum. Quibusdam ut fugit distinctio et. Quo ea officia." },
                    { 448, 77, 24, 374194, new DateTime(2021, 7, 16, 21, 13, 47, 602, DateTimeKind.Local).AddTicks(129), "blanditiis" },
                    { 87, 3, 62, 200081, new DateTime(2021, 8, 11, 13, 42, 4, 389, DateTimeKind.Local).AddTicks(574), "Corrupti fuga sint.\nNihil aliquam libero dolor.\nDolore enim aut.\nSunt quos autem dolor.\nUllam similique ad esse voluptas aut adipisci cum voluptate est." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 502, 58, 15, 738024, new DateTime(2021, 8, 8, 8, 23, 59, 334, DateTimeKind.Local).AddTicks(1926), "Et voluptas rerum sapiente itaque iusto sed rerum." },
                    { 180, 44, 75, 300130, new DateTime(2021, 4, 2, 14, 59, 11, 6, DateTimeKind.Local).AddTicks(1541), "Possimus ducimus ullam aliquam nesciunt minima autem fugiat.\nSaepe numquam est voluptatem.\nQuae ipsa harum sunt eius accusamus ut.\nRerum nisi quia nihil voluptas quam earum sed ut corrupti.\nQuo sit a ad enim esse laborum unde.\nQuasi asperiores magnam sint qui eos." },
                    { 183, 44, 134, 818313, new DateTime(2020, 11, 7, 12, 47, 42, 537, DateTimeKind.Local).AddTicks(7415), "Eligendi nihil quis et voluptates eligendi ducimus voluptatem. Molestias qui ea provident odio sunt cupiditate quasi qui temporibus. Et accusantium ipsum. Delectus deserunt est qui vel aut numquam cumque ad quod." },
                    { 407, 44, 8, 955922, new DateTime(2021, 6, 13, 22, 51, 38, 492, DateTimeKind.Local).AddTicks(8095), "ipsum" },
                    { 477, 44, 43, 406659, new DateTime(2021, 3, 1, 22, 25, 8, 927, DateTimeKind.Local).AddTicks(6567), "a" },
                    { 512, 44, 134, 733472, new DateTime(2020, 11, 18, 3, 49, 21, 853, DateTimeKind.Local).AddTicks(9011), "a" },
                    { 547, 44, 80, 382381, new DateTime(2021, 1, 18, 1, 28, 31, 488, DateTimeKind.Local).AddTicks(9625), "Ut ullam eum qui repudiandae. Exercitationem dolore officiis commodi consequatur sunt est repellat. Ut aut doloremque amet repellat." },
                    { 130, 21, 18, 418394, new DateTime(2021, 6, 29, 10, 44, 33, 528, DateTimeKind.Local).AddTicks(4324), "Repellendus esse consequatur ut dicta autem occaecati cupiditate porro delectus. Vel earum fuga. In ea veniam." },
                    { 528, 58, 82, 936235, new DateTime(2021, 1, 17, 6, 37, 37, 776, DateTimeKind.Local).AddTicks(4162), "Qui doloribus doloribus et est ut quas.\nA perferendis libero ullam amet voluptatem itaque.\nQui exercitationem ut officiis voluptatibus veritatis illum dicta." },
                    { 144, 21, 111, 847068, new DateTime(2020, 11, 7, 12, 56, 9, 437, DateTimeKind.Local).AddTicks(81), "Eos voluptate omnis voluptatem amet. Quasi quod sint iste voluptate eaque. Maxime autem sit distinctio. Facere esse consectetur ullam magni incidunt impedit. Reiciendis magnam harum. Quo non dicta eveniet." },
                    { 294, 21, 143, 446282, new DateTime(2021, 6, 3, 17, 7, 28, 140, DateTimeKind.Local).AddTicks(3840), "quod" },
                    { 323, 21, 58, 689211, new DateTime(2020, 8, 13, 5, 47, 34, 39, DateTimeKind.Local).AddTicks(7308), "dicta" },
                    { 593, 21, 116, 17578, new DateTime(2021, 6, 6, 13, 46, 42, 910, DateTimeKind.Local).AddTicks(5586), "Debitis neque hic quod voluptatem nemo aut optio." },
                    { 33, 58, 85, 197119, new DateTime(2020, 12, 14, 19, 19, 55, 308, DateTimeKind.Local).AddTicks(1829), "consequuntur" },
                    { 100, 58, 12, 310579, new DateTime(2021, 3, 16, 5, 17, 41, 16, DateTimeKind.Local).AddTicks(2151), "saepe" },
                    { 271, 58, 10, 617403, new DateTime(2020, 9, 26, 4, 14, 28, 826, DateTimeKind.Local).AddTicks(9945), "provident" },
                    { 288, 58, 60, 396759, new DateTime(2021, 4, 13, 22, 18, 16, 446, DateTimeKind.Local).AddTicks(3197), "Dolores eum hic aut minus esse placeat. Est est molestiae est aspernatur voluptatem sequi quibusdam. Aut qui officiis laborum optio. In vitae est ut consectetur totam non consequatur iure." },
                    { 242, 21, 59, 556314, new DateTime(2021, 4, 28, 9, 24, 4, 383, DateTimeKind.Local).AddTicks(9418), "Illo voluptatem eveniet labore tempore. Delectus rerum expedita ad qui quam quod qui libero. Aspernatur qui asperiores blanditiis repudiandae asperiores. Esse inventore fugit animi ut." },
                    { 270, 4, 121, 878954, new DateTime(2020, 8, 22, 20, 38, 10, 665, DateTimeKind.Local).AddTicks(3968), "Reprehenderit voluptatem consequuntur vel assumenda explicabo deserunt. Quia velit est sed quia qui corrupti quas sit autem. Repudiandae deleniti aspernatur. Eum vero sed accusantium velit repellat tempora quam. Aliquam nihil quibusdam aut facere ad repellendus quia." },
                    { 459, 29, 43, 144275, new DateTime(2020, 10, 10, 6, 9, 59, 317, DateTimeKind.Local).AddTicks(8895), "Ut animi non." },
                    { 105, 4, 59, 642343, new DateTime(2020, 10, 23, 20, 19, 20, 714, DateTimeKind.Local).AddTicks(7795), "Quasi eaque repellendus rerum sed sed.\nIpsam sit possimus et tempora odit praesentium odio.\nQui ut dolore.\nAccusamus optio fugiat.\nDolor sapiente et sed aut iusto blanditiis rerum adipisci.\nQuo et aliquid itaque adipisci cum voluptatem." },
                    { 578, 45, 36, 636054, new DateTime(2021, 6, 22, 3, 2, 16, 403, DateTimeKind.Local).AddTicks(9365), "aliquam" },
                    { 60, 35, 97, 252114, new DateTime(2021, 7, 27, 16, 42, 35, 565, DateTimeKind.Local).AddTicks(122), "Voluptas eaque et est veritatis quas dolores repellat earum.\nAutem aperiam omnis corporis.\nDeleniti ipsum totam vel nam laboriosam sed.\nDoloremque ullam est odit quia et quia ullam mollitia.\nAutem voluptate facilis maxime recusandae sed." },
                    { 202, 35, 105, 213472, new DateTime(2020, 12, 7, 9, 58, 5, 632, DateTimeKind.Local).AddTicks(2130), "Omnis sunt quos sit rem perspiciatis ea." },
                    { 252, 35, 136, 99637, new DateTime(2021, 3, 28, 7, 48, 47, 889, DateTimeKind.Local).AddTicks(2478), "Et error quisquam assumenda blanditiis sit aut eveniet. Quis ipsam sed voluptatem totam et. Perspiciatis sed quia autem molestiae sint maiores sit minima. Et ea sit inventore nobis voluptatibus harum. Ut rerum ex laudantium hic cumque animi labore porro vero." },
                    { 284, 35, 88, 654662, new DateTime(2021, 8, 6, 14, 0, 56, 441, DateTimeKind.Local).AddTicks(2697), "Est dolore reiciendis quae. Impedit atque ut qui reiciendis amet cumque asperiores consequuntur. Iusto quasi laboriosam voluptatem perferendis." },
                    { 509, 35, 30, 673291, new DateTime(2020, 11, 11, 20, 7, 28, 217, DateTimeKind.Local).AddTicks(8489), "Saepe ullam iste et vitae eos et." },
                    { 569, 35, 77, 199557, new DateTime(2020, 10, 27, 11, 30, 35, 350, DateTimeKind.Local).AddTicks(2392), "Dolor quo est qui et perferendis enim dolores reiciendis rerum.\nUt reprehenderit temporibus nostrum debitis." },
                    { 76, 66, 95, 11991, new DateTime(2021, 5, 1, 1, 45, 52, 921, DateTimeKind.Local).AddTicks(2987), "Vitae nisi fuga corrupti minima quo est laboriosam.\nUt ut est autem et id nihil veritatis.\nTotam voluptate quasi enim." },
                    { 77, 66, 10, 614261, new DateTime(2020, 9, 23, 0, 35, 58, 535, DateTimeKind.Local).AddTicks(9021), "Voluptatem possimus ut delectus ducimus quae modi placeat. Aut odio earum eligendi ab quia dolores vero ex qui. Voluptatem adipisci quia eius." },
                    { 248, 66, 82, 608035, new DateTime(2021, 3, 2, 1, 39, 5, 112, DateTimeKind.Local).AddTicks(3085), "ad" },
                    { 249, 66, 21, 299933, new DateTime(2021, 3, 6, 2, 57, 31, 474, DateTimeKind.Local).AddTicks(1353), "Quasi beatae nemo.\nSit temporibus laudantium nulla quidem quasi qui aut veniam.\nNon facere nemo.\nNam repudiandae consequuntur eos.\nQuod dolores fugit sint unde in quo perferendis." },
                    { 364, 66, 127, 769788, new DateTime(2021, 3, 21, 19, 10, 38, 712, DateTimeKind.Local).AddTicks(8984), "Exercitationem et non vitae accusamus nihil tempore. Dignissimos molestiae qui neque voluptatem eos cum commodi. Ut sit beatae ducimus deserunt quia fuga. Nemo odio nihil ratione. Placeat qui et." },
                    { 391, 66, 113, 535528, new DateTime(2021, 3, 21, 13, 32, 40, 727, DateTimeKind.Local).AddTicks(5367), "Assumenda itaque sint et repudiandae adipisci facilis consequatur quod. Et omnis nam commodi sapiente reiciendis et earum minima. Placeat consectetur eum dolore eius eius. Quis possimus earum deleniti. Distinctio cum nostrum hic." },
                    { 416, 66, 120, 330122, new DateTime(2021, 5, 5, 17, 38, 3, 550, DateTimeKind.Local).AddTicks(7015), "Ea adipisci veniam aspernatur." },
                    { 424, 66, 86, 581311, new DateTime(2021, 5, 6, 20, 57, 26, 266, DateTimeKind.Local).AddTicks(156), "Molestias omnis et non et quia et." },
                    { 561, 45, 44, 110067, new DateTime(2020, 9, 22, 6, 18, 24, 107, DateTimeKind.Local).AddTicks(4780), "A veritatis accusamus earum." },
                    { 365, 45, 111, 911399, new DateTime(2021, 3, 29, 12, 4, 12, 157, DateTimeKind.Local).AddTicks(4390), "Eum non eos assumenda et. Repellat dignissimos dolorem. Et quia est quos aut cumque quibusdam. Et error ut delectus qui ex cum explicabo sed possimus." },
                    { 251, 45, 125, 523515, new DateTime(2020, 11, 29, 4, 8, 59, 75, DateTimeKind.Local).AddTicks(1144), "Id repellat rerum.\nRepudiandae at rem ipsam.\nOmnis earum quia ea error est numquam officiis repudiandae ut.\nInventore impedit culpa excepturi voluptates vel sed alias ducimus.\nIncidunt ea aut.\nDolores dolores incidunt est quidem quisquam consequatur." },
                    { 224, 45, 12, 155471, new DateTime(2020, 11, 14, 0, 43, 41, 564, DateTimeKind.Local).AddTicks(1301), "Doloribus est officia laborum ad." },
                    { 308, 5, 66, 292426, new DateTime(2021, 1, 26, 12, 52, 25, 210, DateTimeKind.Local).AddTicks(564), "Ullam harum vero iure reprehenderit blanditiis et quas.\nIllum omnis consequatur vero rerum quia enim corrupti et quia.\nEius aut velit eaque reprehenderit quasi officiis dolorem molestias eius.\nConsectetur labore porro culpa.\nQuam molestias ullam et sit ut.\nTemporibus quo ut facilis incidunt totam repellat qui." },
                    { 552, 5, 84, 841727, new DateTime(2021, 1, 29, 19, 38, 46, 693, DateTimeKind.Local).AddTicks(4596), "repellendus" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 125, 79, 16, 226429, new DateTime(2021, 1, 15, 1, 11, 37, 936, DateTimeKind.Local).AddTicks(6214), "quis" },
                    { 184, 79, 32, 177377, new DateTime(2021, 8, 6, 19, 23, 45, 549, DateTimeKind.Local).AddTicks(5504), "Dolores fugiat ut. Alias ullam incidunt. Repellat rerum et aut qui. Nam provident blanditiis aspernatur voluptatem ut asperiores quia sit. Doloremque consequuntur temporibus soluta facere." },
                    { 205, 79, 23, 25647, new DateTime(2021, 3, 31, 12, 8, 52, 481, DateTimeKind.Local).AddTicks(9985), "Natus numquam temporibus consequatur rem vitae.\nSapiente consequatur qui.\nIste voluptatum quos architecto quam quam.\nConsequuntur dolores iste ut molestias.\nOdit officia dolor distinctio architecto quis sit et adipisci.\nDebitis aut explicabo quia qui quidem error iusto quia ipsa." },
                    { 277, 79, 112, 512589, new DateTime(2021, 3, 16, 22, 51, 19, 411, DateTimeKind.Local).AddTicks(8073), "Qui ab voluptatum rerum consequatur at nobis eveniet." },
                    { 343, 79, 125, 211635, new DateTime(2021, 1, 24, 5, 0, 58, 101, DateTimeKind.Local).AddTicks(7702), "qui" },
                    { 435, 66, 133, 557716, new DateTime(2021, 2, 8, 10, 27, 51, 991, DateTimeKind.Local).AddTicks(5153), "Illum qui optio consequuntur. Fugiat voluptates assumenda et. Ad eum sunt repellendus qui fugit. Ut dicta repudiandae aut minima dolorum." },
                    { 514, 79, 27, 715752, new DateTime(2021, 7, 9, 3, 24, 10, 9, DateTimeKind.Local).AddTicks(1658), "Labore sed voluptas." },
                    { 38, 38, 20, 670218, new DateTime(2020, 8, 25, 22, 13, 45, 401, DateTimeKind.Local).AddTicks(8933), "Ea et necessitatibus. Unde maxime ut adipisci maiores. Necessitatibus accusantium harum quos repellat. Impedit vel qui ipsam possimus eum. Eaque vel eos asperiores nobis sit fugit. Aut porro magnam et ratione debitis neque ut fugiat et." },
                    { 128, 38, 116, 201008, new DateTime(2021, 4, 24, 2, 22, 31, 44, DateTimeKind.Local).AddTicks(4793), "Sit quidem eum ducimus qui praesentium ipsa at dolor necessitatibus. Nobis est non consequuntur. Enim deserunt fugit qui et necessitatibus doloremque ut commodi. Suscipit dicta quasi commodi vitae vel mollitia. Est id aspernatur nisi corrupti." },
                    { 147, 38, 19, 545639, new DateTime(2021, 5, 3, 6, 34, 5, 257, DateTimeKind.Local).AddTicks(6393), "Modi corrupti dolorem natus." },
                    { 362, 38, 41, 197818, new DateTime(2021, 1, 11, 11, 42, 19, 981, DateTimeKind.Local).AddTicks(9797), "aliquam" },
                    { 406, 38, 90, 654151, new DateTime(2021, 6, 9, 4, 25, 44, 853, DateTimeKind.Local).AddTicks(8037), "Quod ullam omnis et mollitia." },
                    { 525, 38, 43, 98774, new DateTime(2021, 2, 23, 7, 26, 52, 356, DateTimeKind.Local).AddTicks(8245), "dolor" },
                    { 2, 45, 17, 856435, new DateTime(2020, 8, 20, 6, 57, 48, 355, DateTimeKind.Local).AddTicks(2133), "nisi" },
                    { 555, 79, 28, 526620, new DateTime(2020, 8, 20, 0, 40, 30, 758, DateTimeKind.Local).AddTicks(3211), "Fuga in modi provident molestiae asperiores sit vel.\nDoloremque officia commodi soluta delectus reprehenderit.\nMagnam quia minus est eligendi nihil ad repudiandae quas quia.\nIncidunt asperiores non omnis.\nEnim quae eaque et et ea dolores.\nBeatae praesentium maiores quod illo nemo." },
                    { 507, 66, 35, 700997, new DateTime(2021, 2, 21, 10, 8, 52, 33, DateTimeKind.Local).AddTicks(8693), "Similique aut numquam. Sed facilis sunt voluptas dolor atque dolor quis. Dolorum a commodi unde sed delectus recusandae ducimus. Repudiandae et autem totam. Sed molestiae aut iusto non aut est." },
                    { 590, 66, 131, 187224, new DateTime(2021, 1, 30, 3, 53, 22, 553, DateTimeKind.Local).AddTicks(1494), "Cum harum autem voluptatem voluptatem dolorum quos. Enim asperiores perferendis rem doloremque fuga in ab quas aperiam. Minima nihil itaque. Non unde excepturi amet natus est ea quia aliquam et. Ut ut numquam. Quo sunt sed alias totam atque animi." },
                    { 17, 15, 79, 792258, new DateTime(2021, 2, 27, 6, 57, 12, 301, DateTimeKind.Local).AddTicks(1131), "Impedit saepe eum consectetur nisi eaque voluptas." },
                    { 544, 32, 30, 699161, new DateTime(2021, 2, 6, 22, 54, 40, 999, DateTimeKind.Local).AddTicks(2137), "Consequatur eius eius eum." },
                    { 554, 32, 145, 92543, new DateTime(2021, 4, 18, 9, 54, 20, 634, DateTimeKind.Local).AddTicks(7090), "Nihil distinctio qui totam.\nQuam totam explicabo quo quam est facilis tempore expedita quos." },
                    { 73, 25, 101, 140661, new DateTime(2020, 10, 28, 10, 37, 17, 618, DateTimeKind.Local).AddTicks(1347), "Esse ut non dolorem aut assumenda necessitatibus molestiae quis." },
                    { 95, 25, 16, 95861, new DateTime(2021, 3, 13, 22, 8, 37, 409, DateTimeKind.Local).AddTicks(5336), "Vitae ut mollitia. Explicabo tempora impedit sapiente et saepe delectus a omnis blanditiis. Aliquam cumque quisquam. Quisquam labore est harum numquam. Possimus omnis ea quo et molestiae ut molestiae quos. Nesciunt temporibus ad rerum explicabo doloremque aut temporibus quaerat." },
                    { 186, 25, 9, 92705, new DateTime(2020, 8, 29, 0, 55, 25, 827, DateTimeKind.Local).AddTicks(5146), "Sequi vel sit ratione mollitia dolores." },
                    { 337, 25, 130, 189443, new DateTime(2020, 11, 10, 1, 44, 48, 102, DateTimeKind.Local).AddTicks(5662), "Et libero dicta ipsam. Tempora qui quisquam expedita fugiat magni. Atque fuga totam facere non libero. Incidunt deleniti qui nihil debitis vel. Aut non exercitationem aut." },
                    { 207, 4, 81, 224023, new DateTime(2021, 1, 16, 8, 22, 8, 449, DateTimeKind.Local).AddTicks(1269), "Accusantium eveniet aut et commodi necessitatibus repellat sed. Commodi quas et aut voluptas explicabo eos quos. Quia sit laudantium in vitae nam doloremque." },
                    { 522, 32, 64, 817811, new DateTime(2020, 12, 31, 2, 24, 24, 817, DateTimeKind.Local).AddTicks(196), "Delectus ratione non delectus natus accusantium dolorem quasi quis. Voluptatem vero ut blanditiis ducimus sit molestiae voluptatem in laborum. Et voluptatem earum explicabo. Numquam sit consectetur. Aut sunt repellat minus et quam magni vitae molestias. Explicabo voluptas est voluptas ipsa a." },
                    { 479, 25, 49, 833509, new DateTime(2020, 8, 25, 8, 19, 32, 192, DateTimeKind.Local).AddTicks(8249), "modi" },
                    { 158, 75, 48, 872702, new DateTime(2020, 10, 4, 20, 8, 18, 770, DateTimeKind.Local).AddTicks(3484), "Corporis qui enim illum perspiciatis alias nisi est ut eos." },
                    { 174, 75, 55, 235996, new DateTime(2021, 6, 2, 13, 19, 13, 227, DateTimeKind.Local).AddTicks(1670), "Et quasi rerum quos voluptas dignissimos incidunt saepe dolorem.\nId architecto id ipsum accusantium voluptas omnis et enim quaerat.\nAtque est voluptatem molestias impedit omnis iusto." },
                    { 211, 75, 30, 694856, new DateTime(2020, 8, 22, 2, 2, 26, 561, DateTimeKind.Local).AddTicks(2847), "et" },
                    { 223, 75, 97, 162527, new DateTime(2021, 1, 31, 12, 28, 38, 386, DateTimeKind.Local).AddTicks(3791), "Et sunt commodi nobis illo quibusdam aliquid earum enim. Fuga culpa sit enim voluptatem totam recusandae esse. Fugit eos veniam optio odio. Sint repellat sint." },
                    { 226, 75, 128, 135248, new DateTime(2021, 7, 11, 19, 21, 56, 732, DateTimeKind.Local).AddTicks(462), "Et suscipit non ratione officiis molestiae soluta eos.\nIusto esse voluptatem omnis voluptatibus quia repudiandae veniam sit.\nQuia qui iste sapiente laboriosam quia error molestiae magnam eos." },
                    { 235, 75, 53, 995784, new DateTime(2020, 12, 24, 23, 57, 40, 201, DateTimeKind.Local).AddTicks(4957), "Ipsum aut qui doloremque ut." },
                    { 376, 75, 73, 165198, new DateTime(2020, 8, 21, 20, 36, 56, 65, DateTimeKind.Local).AddTicks(2833), "et" },
                    { 585, 25, 47, 892228, new DateTime(2021, 4, 25, 5, 0, 0, 92, DateTimeKind.Local).AddTicks(8432), "illo" },
                    { 82, 5, 36, 803601, new DateTime(2020, 11, 3, 21, 16, 38, 564, DateTimeKind.Local).AddTicks(5442), "Laudantium enim facilis pariatur nihil nesciunt." },
                    { 480, 32, 83, 582041, new DateTime(2021, 7, 7, 15, 9, 28, 862, DateTimeKind.Local).AddTicks(6367), "Voluptatem autem quasi vero facilis placeat reprehenderit velit. Perspiciatis sunt amet culpa cumque quia consequatur. Ducimus eveniet veritatis voluptatem eum. Doloremque tempora sed ab dolor enim. Nesciunt quaerat expedita voluptas." },
                    { 440, 32, 87, 139061, new DateTime(2021, 6, 6, 10, 22, 57, 860, DateTimeKind.Local).AddTicks(1994), "Perferendis ipsa hic." },
                    { 49, 15, 32, 776639, new DateTime(2021, 7, 30, 22, 14, 28, 794, DateTimeKind.Local).AddTicks(6832), "suscipit" },
                    { 133, 15, 70, 779468, new DateTime(2020, 10, 26, 19, 54, 6, 747, DateTimeKind.Local).AddTicks(8614), "Omnis recusandae et exercitationem alias voluptatem et rerum aperiam sunt.\nMolestiae velit molestiae ut ut praesentium aperiam laudantium provident doloribus.\nEst labore rerum sed.\nAutem dolores voluptatum.\nQuis sint ullam natus sunt ad molestias nam nobis." },
                    { 164, 15, 88, 630162, new DateTime(2021, 5, 4, 13, 45, 37, 225, DateTimeKind.Local).AddTicks(7333), "Non at et cupiditate." },
                    { 334, 15, 128, 790989, new DateTime(2020, 11, 3, 13, 5, 30, 388, DateTimeKind.Local).AddTicks(1049), "Quia fuga non dolor ea quidem voluptatibus aliquam atque molestiae. Recusandae quia magni molestiae fuga corporis suscipit molestias non delectus. Eum quia et. Deleniti aliquid qui in laborum rem nihil officiis velit." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 385, 15, 36, 727181, new DateTime(2021, 4, 27, 14, 16, 21, 721, DateTimeKind.Local).AddTicks(2653), "Numquam quas at suscipit tenetur aut cumque est odit aspernatur. Omnis eos officia. Natus libero dolores quia sint magnam nobis facere alias. Quibusdam repudiandae error eos labore omnis aperiam est sit provident. Animi nemo ut earum." },
                    { 421, 15, 118, 841181, new DateTime(2020, 12, 11, 23, 24, 35, 0, DateTimeKind.Local).AddTicks(4915), "Excepturi esse voluptas maiores atque." },
                    { 485, 15, 150, 107206, new DateTime(2021, 3, 26, 7, 21, 29, 782, DateTimeKind.Local).AddTicks(1431), "quaerat" },
                    { 452, 32, 148, 477066, new DateTime(2021, 2, 16, 21, 44, 30, 848, DateTimeKind.Local).AddTicks(1627), "Sit consequatur nobis." },
                    { 489, 15, 90, 701406, new DateTime(2021, 5, 13, 18, 5, 20, 195, DateTimeKind.Local).AddTicks(664), "Impedit adipisci quisquam amet rerum velit voluptatem saepe vero autem." },
                    { 291, 19, 24, 307945, new DateTime(2021, 5, 21, 21, 10, 20, 819, DateTimeKind.Local).AddTicks(2777), "aliquid" },
                    { 305, 19, 135, 395997, new DateTime(2020, 11, 21, 8, 42, 54, 248, DateTimeKind.Local).AddTicks(3553), "aperiam" },
                    { 580, 19, 53, 322507, new DateTime(2021, 3, 28, 20, 53, 0, 730, DateTimeKind.Local).AddTicks(3454), "Dolore necessitatibus vitae consequatur dolorum minima.\nRecusandae et veniam maiores aperiam nobis culpa voluptas.\nLibero delectus dolorem aut doloremque veniam quis ut.\nTotam sint eum optio neque nisi rem ut eum.\nVoluptatem pariatur et dolore corrupti." },
                    { 236, 32, 119, 218678, new DateTime(2020, 10, 2, 22, 46, 44, 942, DateTimeKind.Local).AddTicks(9988), "Aliquid repudiandae rerum qui illo nostrum totam ullam reprehenderit repudiandae.\nVoluptatem sint aperiam." },
                    { 259, 32, 59, 257380, new DateTime(2020, 12, 1, 20, 26, 29, 261, DateTimeKind.Local).AddTicks(6724), "quia" },
                    { 303, 32, 40, 420347, new DateTime(2020, 11, 10, 21, 14, 26, 229, DateTimeKind.Local).AddTicks(3648), "Similique asperiores in esse quas facilis impedit nulla et. Voluptatem reiciendis nisi modi qui consequatur quia. Ut corrupti occaecati velit eos doloremque soluta voluptates ad excepturi. Sit velit doloribus quaerat hic consequatur eum. Unde quia nesciunt voluptatem recusandae et incidunt in aut." },
                    { 328, 32, 61, 389844, new DateTime(2021, 4, 4, 19, 19, 11, 181, DateTimeKind.Local).AddTicks(1422), "dicta" },
                    { 69, 19, 95, 295775, new DateTime(2021, 3, 13, 9, 12, 3, 572, DateTimeKind.Local).AddTicks(2815), "Quia veniam a est a.\nEt porro qui minima reiciendis laudantium aspernatur mollitia eaque deleniti.\nVoluptatibus dolorem sunt explicabo maiores." },
                    { 388, 75, 129, 206887, new DateTime(2021, 5, 19, 10, 57, 8, 781, DateTimeKind.Local).AddTicks(3674), "Unde et et numquam aut." },
                    { 81, 5, 29, 400789, new DateTime(2021, 3, 28, 19, 3, 12, 148, DateTimeKind.Local).AddTicks(8946), "Quas eveniet doloremque odio.\nUnde quas vel quo magni dolorem sapiente." },
                    { 56, 5, 112, 361363, new DateTime(2021, 7, 18, 12, 52, 10, 878, DateTimeKind.Local).AddTicks(6318), "facere" },
                    { 340, 46, 99, 533589, new DateTime(2020, 12, 20, 5, 28, 4, 555, DateTimeKind.Local).AddTicks(7928), "Nihil nobis vitae earum velit dolorum aliquid." },
                    { 447, 46, 122, 956218, new DateTime(2020, 11, 15, 15, 51, 46, 91, DateTimeKind.Local).AddTicks(2685), "Enim dolores rerum quaerat odio dignissimos." },
                    { 458, 46, 14, 544411, new DateTime(2021, 3, 4, 22, 7, 23, 457, DateTimeKind.Local).AddTicks(3353), "Natus dolore quo quasi vero." },
                    { 497, 46, 95, 902058, new DateTime(2021, 7, 7, 23, 31, 0, 574, DateTimeKind.Local).AddTicks(4331), "Est ut neque rerum quisquam ut voluptas voluptas consequatur. Qui impedit sit iste nam iure alias omnis labore velit. Facilis quasi hic eos voluptatem excepturi. Voluptas minus expedita." },
                    { 546, 46, 26, 894009, new DateTime(2020, 9, 15, 21, 37, 16, 898, DateTimeKind.Local).AddTicks(6435), "Ab cupiditate modi provident quo voluptatem unde pariatur illum. Voluptatem eveniet odit natus dignissimos eius. Ut harum ab dolores eius autem enim repellendus perspiciatis. Tempore atque consequatur voluptas corrupti eveniet maxime exercitationem rerum consectetur. Ut quasi libero voluptatibus eligendi veniam aut ullam." },
                    { 16, 50, 117, 456758, new DateTime(2021, 7, 3, 5, 27, 9, 155, DateTimeKind.Local).AddTicks(9134), "Eos quia quis corrupti quibusdam qui assumenda aut repellendus.\nIusto voluptatem odit.\nEt officia non.\nIncidunt nisi consequuntur." },
                    { 171, 50, 49, 627507, new DateTime(2021, 1, 11, 9, 30, 20, 217, DateTimeKind.Local).AddTicks(8744), "recusandae" },
                    { 241, 50, 28, 578434, new DateTime(2021, 5, 25, 22, 44, 0, 856, DateTimeKind.Local).AddTicks(8973), "Vel quibusdam optio temporibus provident adipisci. Voluptatum doloribus quo. Porro voluptatum sed ex iusto cumque voluptatem non voluptatem. Et eos nihil suscipit fugit qui. Aut et quod quia quisquam voluptatem sed ea. Veniam explicabo explicabo quam." },
                    { 302, 50, 93, 629645, new DateTime(2021, 7, 5, 22, 5, 28, 242, DateTimeKind.Local).AddTicks(7265), "facilis" },
                    { 309, 50, 115, 664423, new DateTime(2020, 11, 12, 7, 13, 57, 341, DateTimeKind.Local).AddTicks(1305), "Illum asperiores quia culpa praesentium asperiores." },
                    { 347, 50, 40, 569356, new DateTime(2021, 4, 21, 14, 33, 46, 359, DateTimeKind.Local).AddTicks(8956), "Repellendus sit voluptatibus eos et minus tenetur perferendis debitis. Ut quia qui provident est quas qui. Rerum occaecati quam placeat ipsa modi eos inventore molestias consequatur. Hic nesciunt quibusdam aut nulla et officia." },
                    { 357, 50, 6, 426718, new DateTime(2021, 4, 7, 18, 35, 36, 184, DateTimeKind.Local).AddTicks(6902), "Enim eum doloribus nobis suscipit.\nPorro fugit dolores libero et sunt provident sequi vel veniam.\nBeatae est veritatis quod." },
                    { 366, 50, 127, 944128, new DateTime(2021, 4, 23, 4, 45, 11, 811, DateTimeKind.Local).AddTicks(7090), "Et blanditiis aliquid consequatur ab nemo asperiores aut. Et in sed dolores minima et delectus. Saepe necessitatibus sunt quam rerum dolor explicabo cupiditate in labore. Repudiandae beatae optio. Repellendus et consectetur dolore ducimus eveniet. Aliquam ad dicta eaque nihil aut aut in deleniti." },
                    { 372, 50, 52, 985017, new DateTime(2020, 12, 21, 9, 6, 51, 300, DateTimeKind.Local).AddTicks(4874), "Sunt quod est pariatur iste.\nEos et blanditiis voluptatem quo quam nobis at quam.\nQui laudantium ut tenetur ut libero in error.\nQuia accusantium repellendus recusandae tempore autem distinctio aliquam consectetur." },
                    { 413, 50, 39, 300487, new DateTime(2021, 5, 16, 4, 24, 9, 697, DateTimeKind.Local).AddTicks(2631), "Quia laborum ut nemo ut non rerum et enim." },
                    { 215, 46, 52, 501394, new DateTime(2021, 3, 2, 22, 51, 12, 710, DateTimeKind.Local).AddTicks(4057), "odit" },
                    { 1, 46, 110, 356335, new DateTime(2021, 7, 22, 9, 35, 20, 303, DateTimeKind.Local).AddTicks(7441), "perferendis" },
                    { 409, 33, 69, 797034, new DateTime(2021, 8, 8, 11, 8, 2, 193, DateTimeKind.Local).AddTicks(2566), "Quo temporibus voluptatem vel. Culpa qui rerum. Facere laudantium sequi velit sed fugit et tempore. Et incidunt est. Numquam eum et quisquam." },
                    { 384, 33, 96, 817055, new DateTime(2020, 9, 9, 19, 33, 24, 725, DateTimeKind.Local).AddTicks(6717), "Suscipit dignissimos tempora rerum sed." },
                    { 348, 12, 77, 161075, new DateTime(2020, 12, 9, 17, 32, 33, 892, DateTimeKind.Local).AddTicks(7890), "placeat" },
                    { 428, 12, 128, 488705, new DateTime(2021, 7, 27, 6, 2, 42, 172, DateTimeKind.Local).AddTicks(6951), "Minus nihil illo eveniet provident sit qui.\nAt velit beatae consequuntur omnis dolor.\nQuos iure commodi omnis repellendus." },
                    { 460, 12, 87, 258454, new DateTime(2020, 10, 10, 19, 46, 16, 662, DateTimeKind.Local).AddTicks(8072), "Inventore ut quis." },
                    { 589, 12, 17, 274754, new DateTime(2021, 3, 1, 23, 51, 59, 465, DateTimeKind.Local).AddTicks(8160), "qui" },
                    { 8, 33, 11, 52213, new DateTime(2021, 1, 2, 14, 25, 39, 668, DateTimeKind.Local).AddTicks(2014), "Totam aspernatur consequatur mollitia labore et placeat tempora et voluptatem." },
                    { 13, 33, 71, 817181, new DateTime(2021, 4, 1, 0, 28, 38, 395, DateTimeKind.Local).AddTicks(6066), "Et non deserunt. Architecto facere rerum. Dolores et repellendus laudantium repudiandae magni doloribus tenetur. Non vero fuga officia et eos sit necessitatibus optio sed. Consectetur necessitatibus molestiae eos aliquam molestiae dignissimos animi. Et aut a." },
                    { 90, 33, 132, 793678, new DateTime(2020, 12, 10, 12, 5, 17, 920, DateTimeKind.Local).AddTicks(8304), "Ut a rerum occaecati vel incidunt voluptatibus." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 462, 50, 66, 309045, new DateTime(2021, 4, 25, 4, 36, 33, 507, DateTimeKind.Local).AddTicks(8999), "quibusdam" },
                    { 93, 33, 8, 151462, new DateTime(2021, 5, 21, 18, 0, 20, 863, DateTimeKind.Local).AddTicks(9258), "Consequatur eum quis quod enim voluptatem et rerum necessitatibus omnis.\nPraesentium dicta repudiandae repellendus mollitia et eum laboriosam.\nConsequatur sunt itaque.\nRepellendus sed eos reprehenderit eum.\nEaque voluptatem quod nulla." },
                    { 219, 33, 30, 115470, new DateTime(2021, 7, 24, 14, 0, 48, 361, DateTimeKind.Local).AddTicks(7977), "Reiciendis pariatur quae rerum omnis laborum velit eos. Quam eius deserunt. Omnis quis ea velit autem. Pariatur est tenetur quidem veritatis vel dolor necessitatibus aut. Omnis dolor non. Saepe voluptatem ut occaecati in." },
                    { 230, 33, 123, 146128, new DateTime(2020, 9, 18, 20, 53, 31, 879, DateTimeKind.Local).AddTicks(2548), "omnis" },
                    { 263, 33, 45, 666987, new DateTime(2020, 10, 4, 5, 2, 46, 669, DateTimeKind.Local).AddTicks(8579), "Totam qui eos totam voluptatem expedita quod explicabo.\nSequi occaecati aut ullam adipisci nemo officiis enim.\nMinima quia ad.\nDolor aut excepturi sed omnis rerum.\nQuo dolore incidunt iusto aut blanditiis et veritatis." },
                    { 315, 33, 54, 34362, new DateTime(2020, 10, 21, 2, 6, 41, 64, DateTimeKind.Local).AddTicks(4177), "Est maiores maiores." },
                    { 317, 33, 52, 186354, new DateTime(2021, 2, 13, 10, 5, 19, 297, DateTimeKind.Local).AddTicks(7641), "Omnis impedit vel voluptates dolores. Est ipsa ea blanditiis ut nihil reiciendis. Consequatur odio ut vitae repudiandae sit. Suscipit aut aut ut illo dolorum distinctio sint voluptas quia. Possimus accusantium voluptas vel nemo beatae." },
                    { 368, 33, 72, 65015, new DateTime(2020, 12, 21, 9, 56, 53, 242, DateTimeKind.Local).AddTicks(516), "Similique maxime repudiandae." },
                    { 373, 33, 47, 464134, new DateTime(2021, 7, 31, 10, 28, 21, 852, DateTimeKind.Local).AddTicks(1671), "Quasi autem asperiores repellat labore." },
                    { 111, 33, 140, 310701, new DateTime(2020, 12, 27, 7, 2, 33, 468, DateTimeKind.Local).AddTicks(4150), "Delectus non ab corrupti illo autem iusto neque repudiandae ex." },
                    { 487, 50, 42, 879008, new DateTime(2021, 7, 18, 19, 47, 20, 318, DateTimeKind.Local).AddTicks(811), "Quia pariatur voluptatem ab adipisci reprehenderit at et iste.\nNon voluptate dolor aspernatur hic repudiandae consequuntur est dolor." },
                    { 58, 52, 82, 583600, new DateTime(2021, 1, 24, 12, 41, 39, 407, DateTimeKind.Local).AddTicks(7215), "Veritatis sunt magni aspernatur fuga magnam nobis." },
                    { 134, 52, 50, 974427, new DateTime(2021, 6, 12, 22, 51, 17, 733, DateTimeKind.Local).AddTicks(9553), "Porro ut iste natus et commodi quia." },
                    { 518, 60, 144, 773993, new DateTime(2020, 9, 10, 5, 37, 43, 283, DateTimeKind.Local).AddTicks(6176), "Recusandae distinctio ut delectus voluptatem rerum. Non et voluptates minus minus. Aliquam maxime iste eum numquam earum at atque quos adipisci. Ratione voluptas pariatur qui velit nam quae repudiandae nihil. Quia sunt et rerum quia." },
                    { 520, 60, 20, 820252, new DateTime(2021, 2, 4, 5, 57, 46, 761, DateTimeKind.Local).AddTicks(7890), "Totam aut qui nihil temporibus aut.\nEt eos qui.\nEst non quia molestiae quod.\nAccusantium vitae repellendus.\nEt dolorum dolorem quibusdam rerum magni cum.\nEa non maxime ut aut odit." },
                    { 576, 60, 100, 764977, new DateTime(2021, 5, 30, 11, 16, 7, 37, DateTimeKind.Local).AddTicks(8405), "Debitis rerum temporibus est amet iure et." },
                    { 61, 85, 89, 453487, new DateTime(2020, 12, 20, 22, 16, 9, 192, DateTimeKind.Local).AddTicks(8646), "harum" },
                    { 120, 85, 121, 853904, new DateTime(2021, 6, 17, 11, 25, 36, 337, DateTimeKind.Local).AddTicks(3994), "voluptatem" },
                    { 378, 85, 93, 215842, new DateTime(2021, 2, 3, 20, 30, 20, 380, DateTimeKind.Local).AddTicks(9849), "qui" },
                    { 397, 85, 58, 438674, new DateTime(2020, 8, 15, 7, 9, 47, 929, DateTimeKind.Local).AddTicks(4095), "Reiciendis earum et est consequuntur praesentium necessitatibus deserunt. Animi eligendi omnis beatae amet amet sint ipsum ducimus dolores. Facere sed hic ut quod dolor quis architecto consequuntur sequi. Quia ut consequatur vel veritatis. Natus placeat excepturi et accusantium ut et earum et voluptas. Veritatis reiciendis rerum sunt omnis repellat." },
                    { 192, 60, 132, 685681, new DateTime(2021, 1, 9, 8, 30, 16, 564, DateTimeKind.Local).AddTicks(9704), "Debitis nam non delectus dolorem non placeat culpa aliquid non." },
                    { 432, 85, 7, 549682, new DateTime(2020, 12, 7, 13, 21, 59, 26, DateTimeKind.Local).AddTicks(1647), "molestiae" },
                    { 151, 74, 106, 521618, new DateTime(2021, 4, 10, 15, 58, 35, 507, DateTimeKind.Local).AddTicks(7991), "Ex occaecati temporibus quis in harum odio. Fuga et omnis doloremque quibusdam dignissimos illo hic. Sit odio rerum iste quisquam similique tempore blanditiis. Hic corporis ut cum." },
                    { 346, 74, 147, 874166, new DateTime(2021, 4, 5, 21, 51, 48, 324, DateTimeKind.Local).AddTicks(157), "id" },
                    { 411, 74, 2, 518291, new DateTime(2020, 8, 17, 12, 15, 36, 489, DateTimeKind.Local).AddTicks(8758), "Maiores voluptatem beatae occaecati consequatur. In incidunt aperiam eos molestiae odio quidem dolor laboriosam aut. Praesentium aut quasi quia est quod. Soluta aut ipsam saepe error perspiciatis temporibus blanditiis incidunt." },
                    { 471, 74, 131, 261141, new DateTime(2021, 2, 19, 4, 24, 39, 925, DateTimeKind.Local).AddTicks(1398), "Suscipit fugiat eligendi eaque qui quas rerum deleniti vero culpa. Placeat exercitationem asperiores animi. Et iure quia harum assumenda omnis. Dolores qui accusantium. Suscipit et et nihil repellendus cum porro. Iste commodi error sit eveniet corrupti necessitatibus qui." },
                    { 577, 74, 116, 998203, new DateTime(2020, 9, 6, 10, 41, 23, 909, DateTimeKind.Local).AddTicks(2407), "Magnam totam aut modi et expedita. Facilis deleniti sed. Deserunt libero fugiat deserunt quia veniam quam consequatur. Aspernatur et consectetur ea nostrum aut. Vitae est quibusdam sed voluptates." },
                    { 23, 5, 80, 451027, new DateTime(2021, 6, 29, 18, 24, 34, 572, DateTimeKind.Local).AddTicks(634), "Ex rerum autem laudantium ullam qui iusto.\nEt minus tempore hic quia sed.\nMolestiae eaque et quasi quo error ut consectetur.\nAccusamus maxime vel blanditiis.\nQuam nulla saepe illum veritatis eligendi impedit.\nProvident molestias rem ipsam vel repellendus ea." },
                    { 50, 5, 29, 799160, new DateTime(2021, 4, 30, 3, 10, 46, 32, DateTimeKind.Local).AddTicks(1732), "Veritatis odit praesentium." },
                    { 28, 74, 123, 777717, new DateTime(2021, 7, 6, 5, 5, 0, 778, DateTimeKind.Local).AddTicks(8768), "Sit maxime porro aut sunt sequi suscipit.\nAut vero ad.\nAut eligendi quod facilis necessitatibus qui facere eius.\nEst labore deserunt dolores omnis sunt et quam." },
                    { 72, 5, 110, 132149, new DateTime(2020, 11, 16, 13, 17, 54, 564, DateTimeKind.Local).AddTicks(7297), "necessitatibus" },
                    { 175, 60, 89, 796189, new DateTime(2020, 12, 4, 5, 12, 24, 800, DateTimeKind.Local).AddTicks(6112), "Debitis ut odio quasi nemo. Consequatur optio repudiandae aut totam corrupti et dolorem veritatis sed. Dolore doloribus consectetur rerum quam nobis voluptatibus dolorum." },
                    { 553, 8, 45, 545937, new DateTime(2020, 11, 19, 1, 2, 1, 526, DateTimeKind.Local).AddTicks(750), "eos" },
                    { 168, 52, 144, 546910, new DateTime(2021, 6, 28, 2, 31, 8, 920, DateTimeKind.Local).AddTicks(690), "fugit" },
                    { 269, 52, 129, 566269, new DateTime(2021, 6, 14, 22, 55, 13, 276, DateTimeKind.Local).AddTicks(779), "Vero dolorem numquam minus minus vitae iusto." },
                    { 293, 52, 59, 304089, new DateTime(2021, 8, 10, 10, 1, 38, 422, DateTimeKind.Local).AddTicks(9030), "Voluptas ipsam a esse optio possimus alias molestiae.\nEt laboriosam aperiam.\nIpsam voluptate voluptate aut est corrupti.\nVoluptate necessitatibus illo impedit eum accusamus.\nVero quo et rem corporis ipsum dolorem perspiciatis.\nReprehenderit consequatur laborum praesentium nesciunt non sed velit eaque perspiciatis." },
                    { 319, 52, 70, 835631, new DateTime(2020, 12, 20, 4, 7, 49, 709, DateTimeKind.Local).AddTicks(4790), "In eius qui quo.\nEnim deserunt provident quos et quia necessitatibus ex provident." },
                    { 530, 52, 144, 651024, new DateTime(2021, 2, 12, 0, 56, 1, 645, DateTimeKind.Local).AddTicks(3359), "Ut nisi culpa. Eaque laboriosam rerum ex ratione reprehenderit minus unde. Quo accusamus minima totam dolorum omnis quia et et. Eius sapiente quam ad maxime tempora tempora cupiditate aperiam." },
                    { 571, 52, 32, 140978, new DateTime(2020, 9, 27, 17, 45, 13, 181, DateTimeKind.Local).AddTicks(4846), "rerum" },
                    { 4, 8, 89, 74903, new DateTime(2020, 11, 6, 2, 48, 8, 763, DateTimeKind.Local).AddTicks(1551), "Qui quia dolores omnis vitae accusantium facilis possimus." },
                    { 132, 60, 61, 98611, new DateTime(2021, 1, 31, 13, 7, 48, 146, DateTimeKind.Local).AddTicks(2323), "Nihil quia dolore expedita ex. Animi doloribus sed qui quia incidunt sit sed. Laborum voluptatem quia. Beatae et libero. Quo nam sed aperiam ea ipsa repudiandae ad." },
                    { 9, 8, 25, 666295, new DateTime(2020, 12, 12, 3, 22, 22, 440, DateTimeKind.Local).AddTicks(7604), "omnis" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 217, 8, 98, 117802, new DateTime(2021, 5, 29, 9, 41, 10, 885, DateTimeKind.Local).AddTicks(285), "Vel temporibus sed laboriosam." },
                    { 255, 8, 99, 858744, new DateTime(2020, 9, 29, 2, 11, 29, 103, DateTimeKind.Local).AddTicks(7239), "Nobis reprehenderit et dolorum." },
                    { 268, 8, 84, 880198, new DateTime(2020, 8, 12, 2, 0, 15, 812, DateTimeKind.Local).AddTicks(6730), "Error eum ad sint dolorem asperiores amet." },
                    { 349, 8, 94, 881920, new DateTime(2021, 7, 13, 14, 52, 17, 113, DateTimeKind.Local).AddTicks(8778), "Quis qui doloribus non omnis et aperiam quis.\nEst maxime tempora qui reprehenderit non velit totam aut.\nAspernatur dolores velit sunt ea autem ducimus libero." },
                    { 441, 8, 97, 989737, new DateTime(2021, 2, 17, 14, 31, 58, 867, DateTimeKind.Local).AddTicks(12), "sapiente" },
                    { 510, 8, 26, 553382, new DateTime(2021, 7, 11, 21, 49, 57, 460, DateTimeKind.Local).AddTicks(9862), "Quae aut esse reiciendis quae sunt ea maiores. Quaerat mollitia ipsam sit. Quia officia pariatur aut. Ut sunt ullam natus non est in voluptate dolores. Et quas autem sit qui temporibus quo dignissimos nisi possimus. Voluptatem voluptates ratione ullam ut voluptas nulla tempore fuga." },
                    { 516, 8, 149, 977052, new DateTime(2021, 2, 5, 5, 22, 25, 781, DateTimeKind.Local).AddTicks(1464), "Sed omnis quos non molestiae. Sunt doloremque deleniti placeat et tempore. Vel facilis quas et sed sed nostrum doloremque officia ipsum. Et dolor ut. At culpa eligendi et." },
                    { 173, 8, 90, 392090, new DateTime(2021, 6, 2, 20, 3, 51, 403, DateTimeKind.Local).AddTicks(4478), "qui" },
                    { 438, 75, 63, 479362, new DateTime(2021, 5, 17, 20, 16, 1, 412, DateTimeKind.Local).AddTicks(5161), "Saepe velit explicabo est.\nOptio molestiae ad et natus ducimus eaque aperiam dicta in.\nPlaceat ullam voluptatem id architecto magnam neque earum qui.\nUnde quam sequi similique est." },
                    { 466, 25, 77, 103007, new DateTime(2021, 4, 21, 10, 5, 21, 571, DateTimeKind.Local).AddTicks(8954), "et" },
                    { 596, 36, 2, 168806, new DateTime(2021, 6, 26, 18, 23, 15, 175, DateTimeKind.Local).AddTicks(4515), "Qui molestiae quasi." },
                    { 526, 10, 62, 735352, new DateTime(2021, 3, 28, 18, 58, 38, 736, DateTimeKind.Local).AddTicks(9933), "Quia dolores qui qui quo ducimus quo." },
                    { 5, 68, 99, 877103, new DateTime(2021, 6, 27, 8, 17, 0, 566, DateTimeKind.Local).AddTicks(7971), "est" },
                    { 488, 10, 8, 413009, new DateTime(2021, 2, 6, 9, 35, 57, 367, DateTimeKind.Local).AddTicks(3324), "labore" },
                    { 425, 10, 24, 758147, new DateTime(2020, 12, 17, 0, 59, 47, 910, DateTimeKind.Local).AddTicks(4398), "Dolor qui autem nesciunt doloribus.\nQuas earum hic ut quasi aut quisquam inventore sunt atque." },
                    { 402, 10, 121, 732802, new DateTime(2021, 6, 25, 18, 16, 18, 53, DateTimeKind.Local).AddTicks(8800), "eaque" },
                    { 330, 10, 40, 711607, new DateTime(2020, 12, 26, 6, 41, 44, 474, DateTimeKind.Local).AddTicks(6570), "porro" },
                    { 123, 10, 103, 363038, new DateTime(2021, 5, 24, 21, 27, 36, 547, DateTimeKind.Local).AddTicks(2214), "Exercitationem id et voluptatem voluptatibus tempora.\nConsequatur harum perferendis et a totam.\nNatus minus laboriosam deserunt deserunt corrupti accusamus.\nVel qui suscipit.\nEx similique eum laborum temporibus magnam." },
                    { 43, 10, 13, 190521, new DateTime(2021, 3, 26, 4, 18, 44, 852, DateTimeKind.Local).AddTicks(7603), "Laudantium est voluptatem.\nEt consequuntur illum dolores pariatur repudiandae aut.\nQuia dolor rerum voluptas sint saepe eaque dolores quaerat." },
                    { 336, 68, 6, 114806, new DateTime(2020, 9, 2, 4, 7, 38, 294, DateTimeKind.Local).AddTicks(7562), "Repellat tenetur neque cupiditate ut voluptatem ut." },
                    { 481, 36, 38, 523143, new DateTime(2020, 9, 29, 13, 18, 16, 137, DateTimeKind.Local).AddTicks(1202), "At consectetur fugiat tempore aut libero cupiditate facere voluptatem. Officiis et est ex adipisci saepe eaque harum aut optio. Molestiae sit eum fugiat. Quod id et et illum officia ea. Totam quidem est ex ut." },
                    { 371, 36, 21, 289449, new DateTime(2020, 11, 19, 0, 19, 21, 278, DateTimeKind.Local).AddTicks(9444), "incidunt" },
                    { 91, 36, 49, 269807, new DateTime(2020, 10, 11, 5, 50, 26, 809, DateTimeKind.Local).AddTicks(8680), "consequatur" },
                    { 377, 68, 121, 599446, new DateTime(2021, 6, 6, 2, 38, 27, 708, DateTimeKind.Local).AddTicks(4202), "Et est ea maxime deserunt et sit id." },
                    { 588, 53, 1, 478080, new DateTime(2020, 11, 1, 0, 36, 19, 50, DateTimeKind.Local).AddTicks(5412), "molestiae" },
                    { 541, 57, 19, 352166, new DateTime(2021, 5, 30, 23, 54, 37, 348, DateTimeKind.Local).AddTicks(7523), "Eum consequatur aut dignissimos debitis commodi perspiciatis consequatur qui et. Vitae est modi et et est quia debitis. Ipsam doloremque repellendus tenetur eligendi reiciendis culpa nobis. Et illo minus error numquam quo ut saepe enim nisi." },
                    { 474, 53, 36, 46156, new DateTime(2020, 9, 24, 9, 24, 49, 599, DateTimeKind.Local).AddTicks(8116), "In architecto in nisi ipsa magni sunt inventore minima ratione." },
                    { 390, 68, 89, 146184, new DateTime(2020, 11, 29, 3, 42, 35, 129, DateTimeKind.Local).AddTicks(5028), "itaque" },
                    { 297, 53, 87, 267595, new DateTime(2021, 4, 1, 11, 23, 24, 245, DateTimeKind.Local).AddTicks(8031), "eius" },
                    { 532, 68, 86, 92661, new DateTime(2021, 5, 25, 8, 49, 35, 455, DateTimeKind.Local).AddTicks(7287), "Illo consequuntur aut sint excepturi quia cum eaque. Quia ducimus nostrum ut ut ipsa corporis ut et fuga. Aut modi excepturi non ducimus voluptate. Voluptas expedita quis animi dolores soluta. Itaque magnam eos deleniti et. Commodi consectetur ad sapiente tempora." },
                    { 140, 53, 143, 190993, new DateTime(2021, 3, 25, 12, 39, 0, 10, DateTimeKind.Local).AddTicks(7389), "Repudiandae incidunt corrupti doloremque non at unde inventore quae. Dolorem facilis et necessitatibus. Magni sit consequatur earum. Quia odio doloremque sit est qui ad eaque accusantium pariatur." },
                    { 11, 53, 112, 986055, new DateTime(2020, 9, 17, 12, 24, 30, 869, DateTimeKind.Local).AddTicks(6559), "Ipsa temporibus voluptas suscipit qui dolorem eaque inventore ducimus.\nVeritatis quis eum suscipit expedita voluptatibus esse ut velit qui.\nQui sint sit error et explicabo quibusdam nulla at." },
                    { 598, 68, 100, 426886, new DateTime(2021, 8, 10, 17, 35, 50, 351, DateTimeKind.Local).AddTicks(8271), "commodi" },
                    { 566, 51, 77, 175336, new DateTime(2021, 8, 9, 14, 19, 56, 619, DateTimeKind.Local).AddTicks(6918), "Enim dolor facere." },
                    { 472, 51, 115, 195090, new DateTime(2021, 5, 5, 9, 48, 37, 863, DateTimeKind.Local).AddTicks(7793), "ipsam" },
                    { 392, 51, 117, 634291, new DateTime(2020, 12, 19, 6, 9, 55, 118, DateTimeKind.Local).AddTicks(4458), "Assumenda et dolorem nihil.\nId ipsum dolorem est molestias dolorem sed.\nIste libero est eligendi reiciendis enim ab.\nNostrum et aut doloribus architecto perferendis qui sunt ipsum.\nEt delectus voluptatem laborum illum reprehenderit autem." },
                    { 280, 51, 13, 908452, new DateTime(2020, 12, 19, 21, 3, 17, 413, DateTimeKind.Local).AddTicks(7921), "Nam praesentium error autem architecto aut in eum itaque fuga.\nNeque provident commodi et laudantium aliquam et.\nQuia et libero ab.\nOmnis aut rerum rerum.\nFugiat officia possimus natus qui et reprehenderit consequatur quam ut." },
                    { 267, 51, 93, 560976, new DateTime(2020, 9, 13, 8, 57, 34, 648, DateTimeKind.Local).AddTicks(7384), "Quam ut rem voluptatum laboriosam voluptatem." },
                    { 35, 59, 16, 169054, new DateTime(2021, 6, 6, 19, 15, 13, 481, DateTimeKind.Local).AddTicks(4024), "Ut veritatis reprehenderit nihil impedit." },
                    { 250, 51, 103, 779715, new DateTime(2021, 4, 22, 17, 19, 15, 789, DateTimeKind.Local).AddTicks(2272), "eius" },
                    { 80, 57, 54, 524201, new DateTime(2021, 3, 22, 22, 40, 16, 286, DateTimeKind.Local).AddTicks(3277), "Similique eos ex aut illum perferendis id nulla voluptatem nostrum. Id officia consequuntur nam mollitia omnis magnam ipsa odio itaque. Laborum eligendi non odit. Culpa laboriosam magnam quaerat perspiciatis tempora eaque fuga veniam. Harum dicta beatae et sed consequuntur nihil nisi odit facilis. Recusandae quos unde aut est nihil maiores." },
                    { 312, 53, 138, 946878, new DateTime(2021, 4, 28, 1, 25, 32, 353, DateTimeKind.Local).AddTicks(6234), "quia" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 116, 51, 1, 284526, new DateTime(2021, 5, 14, 6, 28, 53, 356, DateTimeKind.Local).AddTicks(5207), "temporibus" },
                    { 7, 61, 131, 462424, new DateTime(2020, 10, 27, 13, 41, 45, 813, DateTimeKind.Local).AddTicks(5918), "Aut quasi laudantium est alias. Qui error rerum alias omnis aspernatur. Quia alias eveniet nemo nemo et. Maxime voluptatem dolorum omnis." },
                    { 182, 61, 133, 524735, new DateTime(2020, 9, 29, 7, 59, 11, 128, DateTimeKind.Local).AddTicks(8068), "Perspiciatis qui aperiam odio suscipit dicta voluptas ea. Id quia non non necessitatibus sunt voluptate accusantium. Veritatis rerum voluptatem pariatur accusantium nam autem nihil. Voluptatem laboriosam soluta aspernatur deserunt non. Qui occaecati aut a aut enim. Sequi dolorem at facere voluptate fugiat tempore." },
                    { 508, 28, 121, 858267, new DateTime(2020, 10, 19, 6, 35, 13, 431, DateTimeKind.Local).AddTicks(7031), "quo" },
                    { 476, 28, 78, 221425, new DateTime(2021, 2, 16, 9, 2, 12, 36, DateTimeKind.Local).AddTicks(9005), "sed" },
                    { 361, 28, 10, 894732, new DateTime(2021, 3, 29, 18, 8, 38, 615, DateTimeKind.Local).AddTicks(3054), "nobis" },
                    { 316, 28, 85, 225270, new DateTime(2020, 11, 18, 14, 54, 55, 85, DateTimeKind.Local).AddTicks(7653), "Ea non omnis." },
                    { 119, 28, 142, 408805, new DateTime(2020, 10, 24, 22, 29, 36, 300, DateTimeKind.Local).AddTicks(8383), "Omnis quam labore sint pariatur illum reprehenderit omnis. Similique eveniet dolorem rem rerum enim. Voluptatibus in nisi est aperiam alias reiciendis earum dolor aliquid." },
                    { 14, 28, 138, 344898, new DateTime(2021, 1, 6, 10, 55, 46, 431, DateTimeKind.Local).AddTicks(3541), "Veniam aut quas nisi vel.\nVelit atque quia quasi voluptatem adipisci vel unde ut dolores.\nVel molestiae quia corrupti nobis iure repudiandae.\nEt eveniet voluptatem assumenda ut libero." },
                    { 89, 57, 129, 105111, new DateTime(2020, 11, 14, 20, 27, 43, 965, DateTimeKind.Local).AddTicks(2046), "Inventore magni accusantium optio maiores.\nCorporis accusantium qui repellendus blanditiis odio consequuntur dolor quasi repellendus.\nEaque doloremque nulla reiciendis dolor repudiandae.\nEos porro occaecati voluptatibus.\nRatione voluptas voluptatem distinctio quia eius quis illum voluptate quia." },
                    { 154, 57, 112, 159759, new DateTime(2020, 10, 8, 12, 13, 42, 825, DateTimeKind.Local).AddTicks(79), "Sint id veritatis.\nEst nemo expedita.\nSint qui facere dignissimos pariatur ut sequi eum maxime cupiditate.\nEt nihil perspiciatis fuga.\nVoluptatum quisquam rerum consequatur accusantium soluta in voluptatum.\nLaborum facere quibusdam et occaecati." },
                    { 537, 34, 120, 202241, new DateTime(2021, 6, 6, 8, 26, 18, 990, DateTimeKind.Local).AddTicks(1396), "Totam quas voluptates ipsa. Omnis error dolorum et eveniet eos quas. Sunt eligendi deserunt iste quasi. Inventore eligendi quos. Et voluptates suscipit illum a aliquid accusantium labore fugit. Eveniet laborum est expedita neque." },
                    { 505, 34, 99, 850650, new DateTime(2020, 11, 6, 9, 13, 13, 627, DateTimeKind.Local).AddTicks(2097), "Maiores optio molestiae culpa. Sed aut voluptatem eius occaecati. Quo nemo soluta sit aut. Est consequuntur eius ut." },
                    { 499, 34, 111, 702113, new DateTime(2021, 7, 11, 12, 19, 11, 791, DateTimeKind.Local).AddTicks(3451), "Quod esse libero.\nQui sapiente ad non." },
                    { 157, 57, 10, 248717, new DateTime(2021, 7, 20, 6, 20, 3, 337, DateTimeKind.Local).AddTicks(8719), "Voluptatem consequatur aut quia sunt iure." },
                    { 398, 34, 52, 577786, new DateTime(2021, 2, 8, 8, 15, 47, 135, DateTimeKind.Local).AddTicks(5220), "Vel totam quibusdam enim. Vero enim consequatur quia doloremque est. Dolorum sit est repellat exercitationem animi labore earum. Aut ratione excepturi porro molestiae et qui itaque quasi." },
                    { 382, 34, 141, 625193, new DateTime(2020, 12, 6, 7, 22, 40, 202, DateTimeKind.Local).AddTicks(7959), "atque" },
                    { 172, 61, 82, 913910, new DateTime(2021, 1, 31, 19, 20, 13, 588, DateTimeKind.Local).AddTicks(7921), "Eos quo possimus rerum dolor non qui facere amet voluptatem." },
                    { 379, 34, 131, 325021, new DateTime(2021, 2, 5, 9, 29, 2, 24, DateTimeKind.Local).AddTicks(3434), "Inventore necessitatibus saepe laudantium aut quaerat debitis est atque est.\nNobis qui delectus et repudiandae rem modi expedita itaque." },
                    { 350, 34, 45, 412109, new DateTime(2021, 5, 18, 10, 32, 50, 900, DateTimeKind.Local).AddTicks(6668), "Quod magnam eius ipsum officia." },
                    { 345, 34, 95, 731317, new DateTime(2021, 1, 22, 22, 0, 44, 100, DateTimeKind.Local).AddTicks(8659), "Unde dolor ullam est dolorum assumenda corporis et.\nDolores illum dolores facilis nemo optio eius sint.\nEt eum repellat accusantium omnis." },
                    { 160, 34, 138, 453200, new DateTime(2020, 10, 13, 8, 57, 32, 454, DateTimeKind.Local).AddTicks(6513), "Sint ut quos odit quos pariatur corrupti nesciunt.\nEt dolorem quo et corporis ullam porro ut quia.\nTempora sit sequi consequatur dignissimos est velit aut.\nMinus sit debitis quia." },
                    { 190, 57, 88, 666666, new DateTime(2021, 4, 27, 6, 16, 40, 605, DateTimeKind.Local).AddTicks(7553), "Reiciendis laboriosam labore iusto incidunt animi." },
                    { 102, 34, 22, 84608, new DateTime(2020, 8, 31, 18, 59, 0, 737, DateTimeKind.Local).AddTicks(4612), "Veritatis maxime adipisci sit aut odio a occaecati omnis et. Qui saepe commodi. Cum tempore voluptas dignissimos suscipit perferendis." },
                    { 299, 57, 25, 414065, new DateTime(2020, 12, 15, 17, 16, 35, 101, DateTimeKind.Local).AddTicks(2797), "Dolores consequatur sit dolorem accusamus iure magnam dolorum numquam odio." },
                    { 418, 57, 136, 456539, new DateTime(2020, 12, 25, 2, 9, 27, 439, DateTimeKind.Local).AddTicks(75), "Doloremque et dolor ea nemo laudantium quis porro illo ut." },
                    { 556, 82, 30, 241527, new DateTime(2020, 10, 6, 14, 42, 50, 222, DateTimeKind.Local).AddTicks(3515), "possimus" },
                    { 404, 82, 25, 40945, new DateTime(2021, 8, 2, 5, 43, 34, 325, DateTimeKind.Local).AddTicks(8038), "Totam iure et dignissimos et.\nPorro molestias ex.\nVoluptatem quibusdam dolores sed qui itaque." },
                    { 121, 82, 70, 367037, new DateTime(2020, 9, 26, 15, 36, 39, 720, DateTimeKind.Local).AddTicks(5277), "Nulla alias magni dignissimos excepturi aut." },
                    { 34, 82, 40, 725463, new DateTime(2021, 2, 18, 22, 13, 51, 395, DateTimeKind.Local).AddTicks(1402), "voluptatem" },
                    { 501, 57, 5, 133912, new DateTime(2020, 12, 2, 8, 25, 5, 717, DateTimeKind.Local).AddTicks(1646), "nihil" },
                    { 30, 82, 70, 115200, new DateTime(2021, 5, 25, 9, 10, 14, 704, DateTimeKind.Local).AddTicks(9533), "Minus vero in ab quis enim enim ratione possimus molestias. Error qui praesentium et voluptas dicta quia voluptatum temporibus accusamus. At molestiae exercitationem consequuntur qui qui corrupti natus fugiat molestiae. Velit voluptatibus occaecati consequatur qui quo. Dolore aut unde ratione." },
                    { 492, 61, 27, 464898, new DateTime(2020, 11, 13, 17, 36, 13, 759, DateTimeKind.Local).AddTicks(1048), "Aut aut quam et nihil illum aut sit. Esse voluptatibus quia placeat natus architecto. Laboriosam quia aut. Dolores error veniam est in voluptatem soluta autem. Voluptatem tempore aut ullam laboriosam." },
                    { 367, 34, 29, 417501, new DateTime(2021, 6, 4, 13, 8, 40, 455, DateTimeKind.Local).AddTicks(8334), "Aut cum quaerat deleniti voluptatum. Et delectus totam. Amet suscipit suscipit sunt qui occaecati eaque voluptatem harum illum. Voluptates architecto asperiores unde quia. Est ut dolores at dolores ab cupiditate numquam similique." },
                    { 48, 51, 129, 305997, new DateTime(2021, 4, 25, 20, 47, 53, 366, DateTimeKind.Local).AddTicks(741), "Repellendus saepe mollitia aliquid vitae non laboriosam alias eum. Et aliquid optio est numquam voluptatum. Dolorem adipisci nihil sed consectetur hic. Sed sit vel reiciendis accusamus quis possimus." },
                    { 240, 51, 59, 585241, new DateTime(2021, 3, 14, 15, 31, 34, 858, DateTimeKind.Local).AddTicks(5239), "Distinctio rerum et." },
                    { 27, 72, 139, 915759, new DateTime(2021, 4, 2, 7, 41, 24, 787, DateTimeKind.Local).AddTicks(6972), "eos" },
                    { 353, 13, 107, 917482, new DateTime(2021, 1, 24, 9, 48, 42, 941, DateTimeKind.Local).AddTicks(6470), "Est voluptatibus vitae tempora voluptatem aut nemo dolorum est impedit.\nTemporibus mollitia iste quidem similique aliquam ut velit dolorem et.\nOfficiis laborum vel ab ratione iure at et." },
                    { 322, 13, 109, 158132, new DateTime(2021, 7, 6, 12, 45, 0, 642, DateTimeKind.Local).AddTicks(4052), "Nisi dolores sit quod dolores dolorem. At dolore sed explicabo asperiores saepe. Perspiciatis voluptate sed ut dolorem. Et omnis aut itaque at vitae quos." },
                    { 179, 13, 89, 342799, new DateTime(2021, 3, 17, 8, 16, 17, 629, DateTimeKind.Local).AddTicks(3521), "Rerum laudantium eligendi unde expedita." },
                    { 57, 72, 61, 973417, new DateTime(2021, 2, 25, 13, 53, 51, 511, DateTimeKind.Local).AddTicks(7955), "aspernatur" },
                    { 112, 13, 38, 637846, new DateTime(2021, 7, 27, 13, 58, 36, 83, DateTimeKind.Local).AddTicks(304), "Quae voluptas incidunt aut asperiores enim ipsa quam sint sint." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 29, 13, 37, 150702, new DateTime(2021, 4, 29, 10, 28, 47, 414, DateTimeKind.Local).AddTicks(932), "Cumque voluptatem amet suscipit cumque. Laudantium officia reprehenderit blanditiis architecto ipsum dolorum enim tenetur. Saepe nemo qui dolore quas consequuntur aut. Et et rerum nihil vitae ea saepe ut quo. Earum accusamus quia esse occaecati tenetur. Et sed cum nobis et." },
                    { 176, 72, 23, 716843, new DateTime(2021, 6, 5, 8, 4, 20, 684, DateTimeKind.Local).AddTicks(772), "quis" },
                    { 468, 78, 60, 601833, new DateTime(2021, 7, 22, 17, 27, 39, 279, DateTimeKind.Local).AddTicks(3832), "Ut nobis quisquam cum eligendi doloribus reprehenderit." },
                    { 395, 78, 136, 614078, new DateTime(2021, 5, 25, 14, 0, 29, 957, DateTimeKind.Local).AddTicks(7742), "Ut ea nesciunt ducimus et unde quia iusto.\nEnim nisi sit in fugit alias qui.\nQuisquam dolorem vel." },
                    { 201, 72, 24, 332235, new DateTime(2021, 7, 20, 4, 43, 37, 485, DateTimeKind.Local).AddTicks(738), "Modi tempora sunt velit hic.\nMollitia ipsa sint deserunt.\nQui totam sequi distinctio dolor sit laudantium nulla et.\nAutem sint est sunt sapiente natus.\nAut non nostrum accusantium quia fuga et impedit." },
                    { 394, 78, 1, 144514, new DateTime(2021, 4, 2, 23, 47, 13, 940, DateTimeKind.Local).AddTicks(8651), "libero" },
                    { 225, 78, 118, 55837, new DateTime(2020, 11, 9, 23, 47, 32, 30, DateTimeKind.Local).AddTicks(5303), "excepturi" },
                    { 212, 78, 66, 725225, new DateTime(2021, 5, 30, 18, 4, 28, 81, DateTimeKind.Local).AddTicks(7875), "laborum" },
                    { 191, 78, 37, 965163, new DateTime(2021, 1, 25, 7, 39, 20, 575, DateTimeKind.Local).AddTicks(4063), "Neque aperiam laboriosam velit nostrum pariatur cupiditate est molestiae." },
                    { 37, 51, 81, 616286, new DateTime(2021, 7, 4, 20, 54, 21, 259, DateTimeKind.Local).AddTicks(6779), "Non dolore velit eveniet nemo.\nRepudiandae eaque incidunt illo et non.\nTemporibus quibusdam impedit deleniti placeat atque laboriosam autem.\nVoluptas quos sint in.\nSequi expedita porro.\nMolestiae nam cumque." },
                    { 203, 72, 109, 126109, new DateTime(2020, 11, 11, 20, 6, 2, 508, DateTimeKind.Local).AddTicks(9030), "Pariatur enim atque voluptas maiores sunt vero non iure corporis." },
                    { 386, 63, 80, 90137, new DateTime(2020, 11, 30, 12, 27, 25, 774, DateTimeKind.Local).AddTicks(6688), "Et laborum qui aliquam quisquam qui." },
                    { 306, 63, 133, 473682, new DateTime(2021, 5, 30, 11, 42, 34, 623, DateTimeKind.Local).AddTicks(314), "Vel laboriosam officia perspiciatis et et quibusdam nesciunt vero.\nNemo officiis quo quo.\nFacilis quidem optio exercitationem.\nNon temporibus tenetur expedita sit vitae consequatur nesciunt ex." },
                    { 245, 63, 3, 605118, new DateTime(2020, 11, 1, 4, 54, 33, 256, DateTimeKind.Local).AddTicks(6858), "et" },
                    { 181, 63, 77, 931452, new DateTime(2020, 8, 26, 17, 48, 26, 74, DateTimeKind.Local).AddTicks(9328), "Suscipit omnis natus." },
                    { 59, 63, 119, 471386, new DateTime(2021, 6, 15, 4, 34, 38, 207, DateTimeKind.Local).AddTicks(5754), "Qui corporis molestiae tempore incidunt ullam." },
                    { 227, 72, 123, 340796, new DateTime(2020, 9, 9, 13, 42, 21, 98, DateTimeKind.Local).AddTicks(439), "qui" },
                    { 484, 72, 48, 927701, new DateTime(2021, 4, 26, 14, 9, 44, 885, DateTimeKind.Local).AddTicks(5757), "Consectetur quos non qui. Provident ut omnis ab. Veniam nemo in dolores. Et aspernatur nesciunt. Expedita aliquid dolores odio voluptatem voluptas eos accusantium." },
                    { 539, 7, 10, 893463, new DateTime(2020, 12, 12, 18, 8, 18, 235, DateTimeKind.Local).AddTicks(9849), "Ut id est ut.\nExpedita accusantium adipisci consequatur a delectus recusandae qui necessitatibus voluptates." },
                    { 529, 7, 100, 439108, new DateTime(2021, 5, 5, 7, 33, 57, 758, DateTimeKind.Local).AddTicks(8560), "nobis" },
                    { 412, 7, 101, 199496, new DateTime(2021, 8, 6, 12, 31, 6, 339, DateTimeKind.Local).AddTicks(741), "quasi" },
                    { 370, 7, 68, 22765, new DateTime(2021, 2, 27, 14, 34, 58, 384, DateTimeKind.Local).AddTicks(7348), "Est veniam consequatur. Aliquam suscipit dolorum et dignissimos laudantium non laboriosam sit beatae. Aut autem nostrum perspiciatis hic doloremque labore dolores culpa ratione. Sint atque explicabo aut sed quia mollitia rerum tempora ex. Excepturi tempora sunt molestiae adipisci. Qui qui qui enim consectetur voluptatem consectetur non vero." },
                    { 286, 7, 46, 762821, new DateTime(2021, 2, 27, 14, 29, 0, 139, DateTimeKind.Local).AddTicks(9147), "Ut fugit sunt non iure iusto alias voluptatem. Dolores alias similique perspiciatis et. Est minima culpa qui repellendus voluptatem sed consequuntur vel ut. Ipsa eaque quidem nobis alias quia et iusto. Non eveniet est. Omnis ex quo sit consequatur tempora unde ducimus aperiam." },
                    { 103, 4, 139, 854568, new DateTime(2020, 12, 31, 2, 10, 38, 7, DateTimeKind.Local).AddTicks(5161), "Consequatur nisi magnam." },
                    { 51, 7, 8, 419919, new DateTime(2020, 9, 20, 17, 2, 8, 870, DateTimeKind.Local).AddTicks(6478), "Eum animi deserunt earum et vel placeat. Ea magni praesentium fuga. Quae odit eum maiores qui dignissimos iure. Numquam et fugit." },
                    { 600, 63, 5, 448905, new DateTime(2021, 3, 7, 5, 36, 57, 369, DateTimeKind.Local).AddTicks(2314), "Quia occaecati rerum harum neque harum velit odit adipisci." },
                    { 442, 13, 2, 590134, new DateTime(2020, 12, 24, 18, 16, 51, 50, DateTimeKind.Local).AddTicks(9218), "sequi" },
                    { 26, 57, 25, 444793, new DateTime(2021, 5, 4, 23, 0, 38, 904, DateTimeKind.Local).AddTicks(8126), "voluptas" },
                    { 24, 47, 31, 594888, new DateTime(2021, 5, 25, 22, 26, 5, 7, DateTimeKind.Local).AddTicks(2650), "Ut id quidem labore voluptatem consequatur qui." },
                    { 239, 59, 86, 537554, new DateTime(2021, 4, 27, 6, 4, 30, 23, DateTimeKind.Local).AddTicks(4180), "fuga" },
                    { 451, 59, 93, 203874, new DateTime(2020, 10, 28, 8, 5, 37, 875, DateTimeKind.Local).AddTicks(9262), "Sit ut quasi corrupti eos aperiam vero et recusandae." },
                    { 498, 59, 122, 835161, new DateTime(2020, 11, 24, 22, 6, 4, 57, DateTimeKind.Local).AddTicks(3261), "Qui voluptatem sequi autem voluptatum perferendis." },
                    { 519, 59, 148, 273715, new DateTime(2020, 11, 15, 6, 50, 44, 808, DateTimeKind.Local).AddTicks(9690), "Quia quae et ut." },
                    { 536, 47, 124, 622908, new DateTime(2020, 10, 5, 8, 56, 22, 381, DateTimeKind.Local).AddTicks(7676), "Aut culpa et saepe dolore ipsa vitae tempora similique.\nDolor possimus a quam.\nEst ex cupiditate exercitationem quam." },
                    { 453, 47, 13, 54534, new DateTime(2020, 11, 25, 12, 38, 19, 133, DateTimeKind.Local).AddTicks(5783), "Est fugiat et et fugit laboriosam animi." },
                    { 246, 47, 135, 765586, new DateTime(2020, 11, 12, 11, 24, 3, 494, DateTimeKind.Local).AddTicks(142), "Quasi in expedita exercitationem ut. Iure omnis in quisquam velit quasi repellendus. Fuga id id possimus consequuntur voluptatem. Qui ex animi animi accusamus assumenda eveniet placeat nostrum provident. Rerum ipsum aut et." },
                    { 285, 30, 133, 410568, new DateTime(2021, 3, 20, 10, 58, 31, 786, DateTimeKind.Local).AddTicks(382), "Est qui illo odio quasi est totam id debitis.\nQuae aperiam necessitatibus aut dignissimos aut.\nRerum maiores quia et velit ea id.\nEarum incidunt sed asperiores fugiat." },
                    { 405, 30, 58, 212285, new DateTime(2020, 9, 15, 23, 6, 11, 227, DateTimeKind.Local).AddTicks(144), "Quos enim et sunt sed blanditiis ipsum amet quo.\nVoluptas provident eius ex dolor sit ipsum ut exercitationem." },
                    { 200, 47, 132, 856926, new DateTime(2021, 8, 3, 11, 57, 12, 44, DateTimeKind.Local).AddTicks(8983), "Ut harum itaque optio." },
                    { 65, 47, 148, 91052, new DateTime(2021, 2, 13, 6, 0, 11, 332, DateTimeKind.Local).AddTicks(7265), "Omnis et pariatur dolores quia laudantium et.\nSapiente facilis soluta consequatur molestiae qui nihil.\nRecusandae voluptas maxime est accusamus id saepe.\nAliquid et laborum neque modi quia voluptas temporibus ipsam.\nDolores soluta perspiciatis vel." },
                    { 55, 47, 38, 401595, new DateTime(2021, 6, 24, 1, 0, 45, 908, DateTimeKind.Local).AddTicks(4810), "Praesentium at itaque deserunt est aliquid. Harum at velit dolores quos at saepe maxime sunt. Dolores quaerat fuga eveniet repudiandae totam sed consequatur nemo molestiae." },
                    { 214, 30, 10, 579537, new DateTime(2021, 4, 3, 19, 28, 38, 123, DateTimeKind.Local).AddTicks(3739), "Non ipsam voluptatum illo sint aut." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 422, 30, 2, 634645, new DateTime(2021, 1, 5, 5, 14, 35, 152, DateTimeKind.Local).AddTicks(6297), "Aliquam reprehenderit iusto in voluptatem optio quia et." },
                    { 591, 59, 25, 679438, new DateTime(2021, 7, 14, 13, 18, 27, 193, DateTimeKind.Local).AddTicks(8542), "fuga" },
                    { 592, 59, 40, 262596, new DateTime(2020, 11, 24, 6, 59, 23, 788, DateTimeKind.Local).AddTicks(1350), "Quo molestias iusto recusandae incidunt voluptates accusamus.\nIllum molestiae dicta id fugiat aut velit occaecati maxime.\nRem quam est sit voluptas esse.\nLaudantium omnis quae in sapiente earum aut et.\nIllum voluptas eos id assumenda iste et nulla." },
                    { 543, 30, 25, 542053, new DateTime(2021, 2, 13, 12, 53, 18, 402, DateTimeKind.Local).AddTicks(3440), "Ab qui distinctio ex qui voluptatem facere.\nDolor eos consequuntur dolor perferendis voluptates sint reprehenderit molestias velit.\nVel eos soluta iure est ut est harum.\nOmnis at ut.\nQui quos nobis voluptatibus omnis.\nEst officiis natus ducimus esse." },
                    { 564, 43, 16, 951409, new DateTime(2020, 8, 15, 19, 51, 14, 171, DateTimeKind.Local).AddTicks(8096), "Vero numquam facilis et quis est mollitia dolores.\nSed et laudantium amet autem voluptates rerum.\nEnim numquam molestias suscipit alias repellendus qui qui ad.\nEsse maxime unde ea ad tenetur.\nEt dignissimos occaecati hic." },
                    { 389, 43, 89, 538916, new DateTime(2020, 9, 11, 18, 23, 2, 809, DateTimeKind.Local).AddTicks(9085), "Aliquid porro quo voluptatum.\nInventore doloremque quia nihil pariatur quis quasi fuga modi.\nLaboriosam odit et maxime aut nemo sequi.\nEt minus quasi.\nUt perspiciatis inventore rerum enim dignissimos soluta earum dolor deserunt." },
                    { 206, 43, 104, 798105, new DateTime(2021, 4, 14, 4, 16, 2, 748, DateTimeKind.Local).AddTicks(15), "pariatur" },
                    { 70, 43, 37, 222631, new DateTime(2021, 4, 14, 12, 52, 29, 747, DateTimeKind.Local).AddTicks(8478), "Qui eos doloremque sed atque architecto.\nAliquam nihil eum aut unde enim error.\nAccusamus adipisci totam error eligendi fugit nisi minus accusamus facere.\nModi accusamus nam omnis." },
                    { 52, 43, 68, 740914, new DateTime(2021, 3, 31, 17, 53, 49, 165, DateTimeKind.Local).AddTicks(9325), "Dolores odio impedit voluptatum asperiores voluptatem quis ut.\nAccusantium voluptatem pariatur dolorem.\nOdio sed esse dolor ut et ab.\nNon natus et eligendi deleniti illo.\nId cumque sunt et qui delectus amet eos.\nAut error optio debitis tempora ea alias." },
                    { 31, 43, 109, 921748, new DateTime(2021, 7, 21, 0, 8, 48, 898, DateTimeKind.Local).AddTicks(881), "dolorem" },
                    { 228, 59, 16, 451255, new DateTime(2020, 11, 22, 2, 33, 8, 727, DateTimeKind.Local).AddTicks(7294), "Earum quisquam odit non.\nProvident molestiae qui harum ducimus.\nDoloribus provident rerum autem officia earum nemo alias et.\nQuo ullam ut corporis natus.\nEa sunt odio sint numquam qui consequatur laborum labore.\nAd adipisci reprehenderit dolorem." },
                    { 138, 30, 50, 647568, new DateTime(2020, 10, 30, 20, 25, 23, 483, DateTimeKind.Local).AddTicks(89), "Perferendis voluptatem iste expedita omnis pariatur veniam.\nConsequatur nisi et sunt error.\nDolores dolores in nisi in aliquam minus dolorum." }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 70, 29, 129 },
                    { 44, 37, 134 },
                    { 53, 12, 141 },
                    { 3, 57, 124 },
                    { 26, 71, 232 },
                    { 37, 40, 255 },
                    { 45, 16, 177 },
                    { 5, 46, 31 },
                    { 25, 11, 251 },
                    { 31, 72, 46 },
                    { 17, 17, 71 },
                    { 73, 75, 227 },
                    { 39, 18, 207 },
                    { 77, 39, 86 },
                    { 48, 35, 134 },
                    { 40, 65, 128 },
                    { 13, 47, 99 },
                    { 12, 43, 183 },
                    { 61, 26, 97 },
                    { 36, 62, 92 },
                    { 68, 13, 300 },
                    { 1, 15, 138 },
                    { 58, 48, 65 },
                    { 19, 78, 8 },
                    { 63, 55, 79 },
                    { 9, 32, 183 },
                    { 27, 63, 209 },
                    { 6, 77, 5 },
                    { 51, 25, 220 },
                    { 35, 42, 201 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 4, 7, 52 },
                    { 43, 81, 196 },
                    { 38, 45, 53 },
                    { 14, 50, 264 },
                    { 16, 44, 46 },
                    { 30, 38, 89 },
                    { 15, 28, 223 },
                    { 82, 34, 38 },
                    { 47, 52, 255 },
                    { 8, 64, 177 },
                    { 7, 8, 24 },
                    { 60, 69, 257 },
                    { 72, 24, 82 },
                    { 57, 60, 300 },
                    { 2, 10, 290 },
                    { 66, 14, 285 },
                    { 29, 84, 131 },
                    { 21, 54, 258 },
                    { 32, 73, 216 },
                    { 76, 9, 179 },
                    { 34, 70, 233 },
                    { 46, 5, 129 },
                    { 42, 67, 134 },
                    { 49, 3, 68 },
                    { 18, 51, 8 },
                    { 54, 30, 252 },
                    { 22, 1, 227 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 73, new DateTime(2021, 7, 24, 7, 7, 4, 169, DateTimeKind.Local).AddTicks(6265), 57, new DateTime(2021, 12, 21, 0, 48, 8, 28, DateTimeKind.Local).AddTicks(6081), new DateTime(2021, 2, 17, 23, 55, 50, 152, DateTimeKind.Local).AddTicks(5253), 2, 53, "et" },
                    { 143, new DateTime(2021, 5, 25, 23, 43, 4, 200, DateTimeKind.Local).AddTicks(3510), 54, new DateTime(2022, 6, 9, 17, 15, 36, 86, DateTimeKind.Local).AddTicks(2499), new DateTime(2021, 8, 11, 11, 58, 1, 1, DateTimeKind.Local).AddTicks(6656), 4, 61, "Iste neque cumque. Sed voluptates rerum quis sequi et iusto facilis ut. Neque nihil laudantium. Voluptas vero consectetur accusantium sed." },
                    { 193, new DateTime(2021, 4, 14, 15, 15, 8, 731, DateTimeKind.Local).AddTicks(6852), 119, new DateTime(2021, 10, 17, 10, 28, 33, 419, DateTimeKind.Local).AddTicks(5179), new DateTime(2021, 7, 14, 5, 22, 11, 718, DateTimeKind.Local).AddTicks(3664), 4, 61, "Vel culpa in aut eveniet consequatur quos.\nConsequuntur aut ad blanditiis placeat dolorum sequi.\nSit architecto omnis qui itaque saepe.\nAut id eos officia eveniet qui." },
                    { 14, new DateTime(2020, 11, 27, 15, 40, 48, 666, DateTimeKind.Local).AddTicks(1410), 139, new DateTime(2021, 11, 18, 1, 6, 58, 731, DateTimeKind.Local).AddTicks(7540), new DateTime(2021, 3, 11, 17, 16, 12, 908, DateTimeKind.Local).AddTicks(9658), 2, 36, "Et doloribus sed iusto enim asperiores." },
                    { 39, new DateTime(2021, 4, 4, 12, 44, 11, 393, DateTimeKind.Local).AddTicks(6650), 112, new DateTime(2021, 12, 6, 19, 8, 33, 777, DateTimeKind.Local).AddTicks(6606), new DateTime(2021, 5, 2, 15, 47, 12, 737, DateTimeKind.Local).AddTicks(6095), 1, 36, "Nostrum laborum veritatis recusandae impedit ex alias adipisci. Eius harum vero tempora amet quibusdam similique natus. Voluptate in odio id autem quis et officia saepe." },
                    { 87, new DateTime(2021, 2, 3, 4, 53, 15, 33, DateTimeKind.Local).AddTicks(4005), 139, new DateTime(2022, 4, 26, 11, 52, 4, 828, DateTimeKind.Local).AddTicks(1509), new DateTime(2020, 11, 16, 12, 11, 21, 197, DateTimeKind.Local).AddTicks(3355), 1, 36, "Quo unde praesentium. Non similique earum molestiae maiores consequatur. Velit debitis repudiandae. Quam consequuntur excepturi cum sit consectetur error." },
                    { 132, new DateTime(2021, 5, 16, 0, 36, 25, 424, DateTimeKind.Local).AddTicks(5029), 64, new DateTime(2021, 12, 10, 0, 51, 22, 67, DateTimeKind.Local).AddTicks(7624), new DateTime(2020, 8, 24, 9, 2, 21, 980, DateTimeKind.Local).AddTicks(408), 2, 36, "Qui est qui sit ut." },
                    { 147, new DateTime(2021, 7, 26, 0, 9, 58, 954, DateTimeKind.Local).AddTicks(3017), 124, new DateTime(2022, 7, 22, 0, 27, 24, 993, DateTimeKind.Local).AddTicks(6134), new DateTime(2021, 7, 25, 23, 10, 51, 872, DateTimeKind.Local).AddTicks(5566), 5, 36, "Voluptates suscipit numquam dolorem repellat.\nQui officia aliquid aut dolorem tempora autem vero labore ut.\nMolestias nemo sed placeat sint est et quae.\nDignissimos nam sunt amet.\nPariatur est animi inventore recusandae fuga assumenda placeat voluptas exercitationem.\nTemporibus mollitia laboriosam dolor." },
                    { 148, new DateTime(2021, 8, 5, 9, 26, 21, 236, DateTimeKind.Local).AddTicks(9565), 48, new DateTime(2021, 10, 31, 20, 7, 23, 9, DateTimeKind.Local).AddTicks(875), new DateTime(2021, 6, 12, 16, 36, 21, 441, DateTimeKind.Local).AddTicks(3462), 4, 36, "Deserunt reprehenderit est exercitationem omnis accusamus et repellendus." },
                    { 195, new DateTime(2020, 8, 29, 17, 45, 46, 655, DateTimeKind.Local).AddTicks(209), 15, new DateTime(2021, 11, 18, 21, 35, 47, 851, DateTimeKind.Local).AddTicks(6674), new DateTime(2021, 2, 10, 3, 32, 54, 391, DateTimeKind.Local).AddTicks(197), 4, 36, "Earum repellendus voluptates molestiae facere totam corporis facere. Dolorem numquam quia unde ab tenetur et omnis est similique. Autem earum veniam corporis incidunt est molestiae autem. Eum sed distinctio qui praesentium distinctio ea pariatur doloribus quo." },
                    { 79, new DateTime(2020, 12, 9, 19, 30, 20, 553, DateTimeKind.Local).AddTicks(4819), 1, new DateTime(2022, 2, 15, 3, 8, 18, 342, DateTimeKind.Local).AddTicks(3370), new DateTime(2021, 2, 23, 17, 41, 5, 84, DateTimeKind.Local).AddTicks(4316), 3, 58, "Blanditiis nemo occaecati necessitatibus aliquid dolor dolor qui quia." },
                    { 86, new DateTime(2020, 10, 10, 14, 24, 50, 82, DateTimeKind.Local).AddTicks(4077), 6, new DateTime(2021, 10, 7, 0, 1, 23, 926, DateTimeKind.Local).AddTicks(904), new DateTime(2021, 2, 19, 8, 19, 20, 228, DateTimeKind.Local).AddTicks(5465), 1, 58, "Et eligendi omnis voluptatem commodi dolore. Est porro iste et blanditiis aut quo. Dolores aut ea ad voluptas recusandae. Omnis voluptatibus quia recusandae. Qui nihil nemo cum necessitatibus. Iure impedit saepe illum doloribus non quo consequatur velit corrupti." },
                    { 135, new DateTime(2020, 11, 28, 3, 0, 24, 285, DateTimeKind.Local).AddTicks(9159), 142, new DateTime(2021, 12, 27, 23, 27, 12, 463, DateTimeKind.Local).AddTicks(9273), new DateTime(2020, 9, 30, 15, 38, 5, 499, DateTimeKind.Local).AddTicks(7458), 1, 58, "Amet dolore error nihil voluptatum error quaerat nihil corporis.\nFugit delectus et eveniet fugiat voluptatem odio.\nSunt ducimus vero animi suscipit dolorem laudantium corrupti mollitia et." },
                    { 136, new DateTime(2021, 6, 30, 20, 16, 47, 451, DateTimeKind.Local).AddTicks(6804), 15, new DateTime(2022, 3, 9, 3, 8, 4, 899, DateTimeKind.Local).AddTicks(3365), new DateTime(2020, 12, 12, 4, 45, 25, 119, DateTimeKind.Local).AddTicks(8832), 3, 58, "Tenetur deleniti cupiditate placeat cupiditate reiciendis non nostrum." },
                    { 187, new DateTime(2021, 7, 13, 13, 32, 11, 862, DateTimeKind.Local).AddTicks(1927), 124, new DateTime(2021, 11, 15, 18, 32, 7, 312, DateTimeKind.Local).AddTicks(5746), new DateTime(2020, 11, 16, 19, 2, 22, 275, DateTimeKind.Local).AddTicks(894), 1, 58, "Dolor tempora excepturi enim voluptatem." },
                    { 63, new DateTime(2021, 3, 6, 8, 24, 25, 419, DateTimeKind.Local).AddTicks(1979), 146, new DateTime(2022, 3, 16, 3, 14, 27, 196, DateTimeKind.Local).AddTicks(3936), new DateTime(2020, 9, 5, 13, 58, 45, 846, DateTimeKind.Local).AddTicks(6714), 1, 63, "Laborum dolor perferendis sit doloremque.\nCupiditate culpa minus eos.\nVoluptatibus vel voluptatem et quos qui voluptatem ut explicabo dolor.\nEt labore culpa.\nEt ullam commodi et." },
                    { 105, new DateTime(2020, 12, 5, 14, 8, 31, 819, DateTimeKind.Local).AddTicks(1309), 84, new DateTime(2021, 11, 12, 15, 40, 3, 139, DateTimeKind.Local).AddTicks(196), new DateTime(2021, 6, 30, 3, 46, 46, 82, DateTimeKind.Local).AddTicks(8599), 2, 63, "nemo" },
                    { 110, new DateTime(2020, 10, 3, 18, 39, 4, 267, DateTimeKind.Local).AddTicks(1131), 113, new DateTime(2022, 3, 14, 9, 9, 36, 72, DateTimeKind.Local).AddTicks(4670), new DateTime(2021, 7, 9, 22, 31, 45, 494, DateTimeKind.Local).AddTicks(307), 5, 63, "Facere vero ratione voluptatem et laudantium voluptatem." },
                    { 36, new DateTime(2021, 3, 25, 22, 21, 21, 686, DateTimeKind.Local).AddTicks(3747), 47, new DateTime(2021, 12, 16, 10, 12, 47, 556, DateTimeKind.Local).AddTicks(6580), new DateTime(2021, 1, 22, 6, 22, 1, 287, DateTimeKind.Local).AddTicks(7982), 2, 32, "hic" },
                    { 54, new DateTime(2021, 6, 11, 20, 28, 45, 594, DateTimeKind.Local).AddTicks(6594), 89, new DateTime(2022, 8, 2, 10, 30, 28, 355, DateTimeKind.Local).AddTicks(2770), new DateTime(2021, 8, 11, 13, 17, 8, 59, DateTimeKind.Local).AddTicks(1183), 4, 32, "Quis sit nemo." },
                    { 182, new DateTime(2021, 1, 4, 18, 16, 36, 526, DateTimeKind.Local).AddTicks(3149), 97, new DateTime(2022, 5, 10, 1, 50, 4, 465, DateTimeKind.Local).AddTicks(547), new DateTime(2021, 6, 5, 3, 6, 0, 708, DateTimeKind.Local).AddTicks(4171), 2, 32, "Nam quo ratione mollitia doloribus provident ex explicabo dolorem commodi.\nEos eum harum accusamus consequatur.\nNisi odio repellat enim adipisci in omnis voluptatem natus quia.\nDolorem pariatur reprehenderit exercitationem molestiae." },
                    { 141, new DateTime(2020, 12, 11, 22, 35, 35, 589, DateTimeKind.Local).AddTicks(9979), 98, new DateTime(2022, 6, 28, 22, 44, 26, 685, DateTimeKind.Local).AddTicks(5720), new DateTime(2021, 7, 27, 8, 46, 2, 316, DateTimeKind.Local).AddTicks(3570), 1, 43, "Consequatur perferendis molestias perspiciatis.\nQuos et quis qui.\nRepudiandae harum recusandae ut." },
                    { 94, new DateTime(2020, 9, 22, 7, 48, 11, 112, DateTimeKind.Local).AddTicks(3901), 26, new DateTime(2022, 4, 13, 11, 59, 31, 386, DateTimeKind.Local).AddTicks(4287), new DateTime(2020, 9, 28, 15, 43, 33, 853, DateTimeKind.Local).AddTicks(100), 3, 40, "Non esse sed quisquam quidem quam repellendus.\nVoluptatem adipisci quas repellat et vitae.\nAsperiores totam quibusdam dolores dolores.\nTempore repellendus hic libero odio.\nVoluptatum aspernatur laborum enim quam sed veniam sed itaque." },
                    { 189, new DateTime(2021, 1, 8, 5, 56, 55, 287, DateTimeKind.Local).AddTicks(6607), 15, new DateTime(2021, 10, 4, 16, 20, 41, 348, DateTimeKind.Local).AddTicks(2897), new DateTime(2020, 11, 28, 17, 45, 39, 979, DateTimeKind.Local).AddTicks(8591), 1, 43, "Voluptatem illum velit vero alias et facilis voluptatem labore modi." },
                    { 78, new DateTime(2021, 7, 1, 19, 1, 57, 15, DateTimeKind.Local).AddTicks(2089), 47, new DateTime(2022, 7, 15, 3, 49, 25, 685, DateTimeKind.Local).AddTicks(4062), new DateTime(2020, 8, 18, 0, 0, 30, 693, DateTimeKind.Local).AddTicks(1909), 3, 40, "Ut sit eligendi nobis nam maiores iure.\nAut iste est id omnis iure.\nConsectetur dolorem tempora.\nAtque explicabo quaerat.\nDolorem adipisci amet blanditiis et dolor.\nPariatur porro voluptas pariatur magni." },
                    { 160, new DateTime(2021, 3, 16, 0, 25, 39, 285, DateTimeKind.Local).AddTicks(5938), 121, new DateTime(2021, 11, 9, 1, 4, 41, 643, DateTimeKind.Local).AddTicks(6031), new DateTime(2020, 10, 21, 23, 10, 32, 47, DateTimeKind.Local).AddTicks(7196), 2, 42, "consequatur" },
                    { 48, new DateTime(2021, 5, 6, 6, 40, 20, 710, DateTimeKind.Local).AddTicks(445), 26, new DateTime(2022, 3, 27, 0, 55, 52, 535, DateTimeKind.Local).AddTicks(8834), new DateTime(2021, 3, 21, 18, 23, 15, 33, DateTimeKind.Local).AddTicks(5940), 3, 37, "Est pariatur numquam nihil ea dolores molestiae voluptas minima." },
                    { 88, new DateTime(2021, 8, 9, 14, 32, 13, 589, DateTimeKind.Local).AddTicks(1853), 80, new DateTime(2022, 5, 20, 14, 56, 56, 95, DateTimeKind.Local).AddTicks(4114), new DateTime(2021, 7, 19, 20, 36, 55, 784, DateTimeKind.Local).AddTicks(6097), 3, 37, "Id maiores natus quia ea non. Sapiente magnam ab dolor est. Magni beatae a natus id dolorum libero animi exercitationem. Molestiae voluptatem accusantium est facere." },
                    { 119, new DateTime(2020, 11, 17, 10, 38, 39, 353, DateTimeKind.Local).AddTicks(129), 126, new DateTime(2022, 5, 11, 2, 28, 23, 417, DateTimeKind.Local).AddTicks(4042), new DateTime(2020, 10, 17, 10, 22, 40, 828, DateTimeKind.Local).AddTicks(6219), 4, 37, "nisi" },
                    { 163, new DateTime(2021, 7, 27, 15, 17, 57, 866, DateTimeKind.Local).AddTicks(9402), 3, new DateTime(2021, 11, 18, 21, 0, 45, 635, DateTimeKind.Local).AddTicks(5781), new DateTime(2020, 8, 30, 11, 47, 27, 898, DateTimeKind.Local).AddTicks(7095), 1, 37, "Est quod eum repellat qui possimus.\nRatione nulla ea et.\nEum id sed.\nAut unde modi numquam hic dolores autem sint non saepe.\nVelit velit harum modi et at possimus explicabo pariatur." },
                    { 139, new DateTime(2021, 5, 31, 10, 58, 1, 2, DateTimeKind.Local).AddTicks(9613), 36, new DateTime(2022, 7, 12, 22, 5, 36, 134, DateTimeKind.Local).AddTicks(9886), new DateTime(2021, 1, 30, 4, 35, 47, 287, DateTimeKind.Local).AddTicks(7574), 3, 8, "Neque pariatur quia. Praesentium nemo neque quaerat et qui quod exercitationem voluptatem. Aut in modi ex aspernatur rerum." },
                    { 146, new DateTime(2021, 3, 10, 15, 15, 20, 720, DateTimeKind.Local).AddTicks(229), 110, new DateTime(2021, 10, 17, 4, 8, 32, 312, DateTimeKind.Local).AddTicks(9162), new DateTime(2020, 9, 16, 5, 35, 1, 908, DateTimeKind.Local).AddTicks(8684), 3, 8, "Et ipsam dolorem molestias maxime incidunt aliquam in.\nSimilique expedita ex molestiae qui unde nisi pariatur ullam voluptatem.\nTotam rerum itaque delectus enim.\nDeserunt placeat enim maxime qui eos impedit quas ea." },
                    { 153, new DateTime(2020, 12, 15, 18, 23, 32, 742, DateTimeKind.Local).AddTicks(6661), 146, new DateTime(2022, 4, 7, 18, 30, 54, 190, DateTimeKind.Local).AddTicks(6478), new DateTime(2020, 9, 21, 9, 3, 43, 739, DateTimeKind.Local).AddTicks(1647), 2, 8, "Quo voluptatibus tenetur reiciendis.\nVelit occaecati culpa.\nVoluptas eos ducimus quia temporibus.\nQuam hic ex tenetur culpa voluptas perferendis ipsam ipsa.\nOfficia nemo qui perferendis temporibus voluptatem odio.\nVoluptatum quis odit est totam accusamus quod in." },
                    { 167, new DateTime(2020, 10, 5, 20, 23, 24, 337, DateTimeKind.Local).AddTicks(9760), 73, new DateTime(2022, 7, 18, 7, 29, 15, 38, DateTimeKind.Local).AddTicks(6243), new DateTime(2020, 10, 9, 22, 34, 16, 746, DateTimeKind.Local).AddTicks(2856), 4, 8, "Non sunt non ea eos odit rerum voluptatem rerum delectus. Vel exercitationem ab voluptas. Est quam quaerat suscipit hic ratione ullam. Fugit autem vero id in voluptas. Sapiente incidunt ut perferendis dolores deserunt. Laboriosam fugit et inventore iste." },
                    { 69, new DateTime(2021, 2, 24, 8, 17, 21, 393, DateTimeKind.Local).AddTicks(2966), 77, new DateTime(2022, 4, 18, 19, 30, 36, 672, DateTimeKind.Local).AddTicks(4627), new DateTime(2021, 3, 7, 12, 6, 6, 783, DateTimeKind.Local).AddTicks(6739), 5, 60, "est" },
                    { 76, new DateTime(2020, 8, 19, 21, 1, 57, 803, DateTimeKind.Local).AddTicks(9859), 129, new DateTime(2022, 7, 26, 15, 8, 45, 321, DateTimeKind.Local).AddTicks(1817), new DateTime(2021, 1, 20, 11, 32, 9, 237, DateTimeKind.Local).AddTicks(1296), 1, 60, "Blanditiis qui exercitationem cum laborum." },
                    { 198, new DateTime(2021, 2, 4, 20, 1, 28, 413, DateTimeKind.Local).AddTicks(1502), 111, new DateTime(2022, 5, 4, 13, 43, 29, 342, DateTimeKind.Local).AddTicks(9233), new DateTime(2021, 2, 16, 11, 7, 21, 570, DateTimeKind.Local).AddTicks(9160), 5, 60, "Asperiores esse molestiae nihil veniam." },
                    { 113, new DateTime(2021, 1, 19, 2, 6, 32, 85, DateTimeKind.Local).AddTicks(4333), 90, new DateTime(2021, 12, 14, 14, 55, 15, 812, DateTimeKind.Local).AddTicks(2275), new DateTime(2021, 1, 6, 8, 29, 27, 795, DateTimeKind.Local).AddTicks(7074), 5, 29, "Quia aspernatur omnis reprehenderit.\nUt at dignissimos eius adipisci hic earum." },
                    { 155, new DateTime(2020, 10, 12, 7, 43, 20, 513, DateTimeKind.Local).AddTicks(429), 141, new DateTime(2022, 8, 4, 19, 13, 27, 325, DateTimeKind.Local).AddTicks(2062), new DateTime(2021, 6, 29, 10, 25, 41, 228, DateTimeKind.Local).AddTicks(8739), 2, 29, "Molestias dicta iure delectus enim laboriosam iusto omnis." },
                    { 173, new DateTime(2021, 6, 4, 23, 33, 3, 883, DateTimeKind.Local).AddTicks(1321), 114, new DateTime(2022, 4, 30, 2, 12, 39, 449, DateTimeKind.Local).AddTicks(8702), new DateTime(2021, 6, 19, 16, 5, 32, 296, DateTimeKind.Local).AddTicks(5195), 4, 29, "Aut commodi aut quis dicta minima libero velit nisi. Sit in rerum et. Itaque dignissimos et aut. Incidunt eaque repellat omnis alias tenetur nisi optio." },
                    { 30, new DateTime(2020, 12, 15, 2, 48, 0, 493, DateTimeKind.Local).AddTicks(6845), 96, new DateTime(2022, 3, 22, 22, 13, 58, 394, DateTimeKind.Local).AddTicks(9330), new DateTime(2020, 10, 19, 7, 11, 5, 442, DateTimeKind.Local).AddTicks(324), 2, 76, "aut" },
                    { 125, new DateTime(2021, 4, 5, 11, 10, 14, 363, DateTimeKind.Local).AddTicks(700), 81, new DateTime(2021, 11, 16, 23, 2, 59, 72, DateTimeKind.Local).AddTicks(3952), new DateTime(2020, 11, 3, 14, 32, 55, 510, DateTimeKind.Local).AddTicks(9960), 4, 76, "Esse et eos molestiae sequi sit quo dolores.\nEst sed iure velit hic sit dolor pariatur at.\nConsequatur eos sequi debitis beatae." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 17, new DateTime(2021, 1, 13, 12, 2, 47, 631, DateTimeKind.Local).AddTicks(5698), 30, new DateTime(2022, 1, 26, 4, 20, 37, 284, DateTimeKind.Local).AddTicks(2448), new DateTime(2021, 1, 30, 5, 30, 2, 647, DateTimeKind.Local).AddTicks(1683), 4, 42, "Neque dolorum aliquid et necessitatibus rem velit voluptas. At asperiores delectus maiores totam. Enim sit repellat." },
                    { 57, new DateTime(2020, 9, 15, 11, 46, 57, 491, DateTimeKind.Local).AddTicks(3169), 62, new DateTime(2021, 9, 5, 10, 2, 1, 321, DateTimeKind.Local).AddTicks(8879), new DateTime(2021, 1, 30, 22, 45, 42, 962, DateTimeKind.Local).AddTicks(7674), 5, 42, "Occaecati et quidem dicta est iste aliquid et sed. Molestias aut cupiditate deserunt. Ad modi incidunt nulla accusantium veniam eum ducimus placeat. Ut nemo quas et laborum necessitatibus explicabo. Ratione rem est consequuntur. Nihil porro cum perspiciatis." },
                    { 68, new DateTime(2021, 5, 14, 15, 20, 49, 625, DateTimeKind.Local).AddTicks(519), 18, new DateTime(2022, 5, 14, 22, 50, 44, 822, DateTimeKind.Local).AddTicks(8870), new DateTime(2021, 4, 4, 22, 14, 44, 229, DateTimeKind.Local).AddTicks(912), 2, 42, "Vitae esse dolorum exercitationem labore quia accusamus." },
                    { 84, new DateTime(2020, 9, 24, 4, 9, 7, 311, DateTimeKind.Local).AddTicks(1544), 55, new DateTime(2022, 5, 22, 6, 7, 0, 109, DateTimeKind.Local).AddTicks(8533), new DateTime(2020, 10, 30, 20, 55, 13, 441, DateTimeKind.Local).AddTicks(9335), 2, 42, "Excepturi sit mollitia quos tempora id nostrum illo voluptas. Velit qui eos optio rerum aliquid facere nobis ut. Velit doloribus et ut aut ut qui. In voluptatem quaerat recusandae dolor saepe odit quia harum velit." },
                    { 99, new DateTime(2021, 5, 2, 5, 54, 4, 940, DateTimeKind.Local).AddTicks(2678), 45, new DateTime(2022, 5, 10, 21, 18, 49, 739, DateTimeKind.Local).AddTicks(832), new DateTime(2021, 7, 17, 15, 47, 51, 685, DateTimeKind.Local).AddTicks(2066), 1, 42, "Totam mollitia illum rerum ut amet." },
                    { 180, new DateTime(2021, 4, 5, 6, 53, 49, 40, DateTimeKind.Local).AddTicks(6714), 66, new DateTime(2021, 11, 12, 21, 31, 8, 321, DateTimeKind.Local).AddTicks(1841), new DateTime(2020, 10, 25, 7, 12, 49, 709, DateTimeKind.Local).AddTicks(1603), 5, 42, "Autem debitis atque quia. Itaque optio labore aliquam. Est sed sit itaque dolor sit suscipit autem. Aperiam eos recusandae dolores pariatur blanditiis temporibus quae." },
                    { 47, new DateTime(2021, 1, 28, 21, 49, 2, 932, DateTimeKind.Local).AddTicks(5690), 122, new DateTime(2022, 6, 7, 12, 36, 39, 286, DateTimeKind.Local).AddTicks(3390), new DateTime(2020, 8, 14, 0, 15, 29, 102, DateTimeKind.Local).AddTicks(4199), 3, 37, "illo" },
                    { 25, new DateTime(2020, 12, 6, 16, 18, 8, 105, DateTimeKind.Local).AddTicks(5218), 50, new DateTime(2022, 1, 25, 6, 9, 12, 236, DateTimeKind.Local).AddTicks(885), new DateTime(2020, 8, 28, 23, 27, 37, 672, DateTimeKind.Local).AddTicks(2581), 4, 35, "quis" },
                    { 53, new DateTime(2020, 9, 2, 4, 40, 10, 885, DateTimeKind.Local).AddTicks(5848), 114, new DateTime(2022, 5, 17, 17, 41, 4, 572, DateTimeKind.Local).AddTicks(5719), new DateTime(2020, 8, 12, 0, 22, 19, 487, DateTimeKind.Local).AddTicks(5826), 4, 6, "Assumenda asperiores veniam.\nInventore in unde cumque voluptas sed harum.\nEt unde nostrum veritatis qui quo sint repudiandae quod dolor.\nEt architecto vel voluptatibus id.\nSaepe modi minima vel." },
                    { 52, new DateTime(2021, 7, 27, 20, 43, 37, 468, DateTimeKind.Local).AddTicks(9938), 113, new DateTime(2022, 5, 7, 0, 39, 15, 146, DateTimeKind.Local).AddTicks(6558), new DateTime(2021, 6, 23, 1, 17, 8, 802, DateTimeKind.Local).AddTicks(6394), 3, 39, "Odit ipsam ab aut. Similique reprehenderit voluptatum consequatur error dolor. Quasi quam fugit laboriosam non odio placeat perferendis dolorem. Assumenda possimus eaque. At debitis natus quasi dolor excepturi quibusdam repellat." },
                    { 70, new DateTime(2021, 3, 4, 1, 53, 39, 266, DateTimeKind.Local).AddTicks(4694), 112, new DateTime(2022, 5, 1, 9, 17, 27, 340, DateTimeKind.Local).AddTicks(775), new DateTime(2021, 5, 12, 22, 30, 26, 28, DateTimeKind.Local).AddTicks(8406), 5, 39, "delectus" },
                    { 130, new DateTime(2021, 2, 6, 17, 3, 9, 972, DateTimeKind.Local).AddTicks(3273), 137, new DateTime(2021, 10, 4, 17, 41, 17, 251, DateTimeKind.Local).AddTicks(2150), new DateTime(2021, 6, 12, 0, 33, 5, 329, DateTimeKind.Local).AddTicks(6394), 2, 39, "Quod ratione sint quidem." },
                    { 126, new DateTime(2020, 11, 16, 0, 26, 19, 80, DateTimeKind.Local).AddTicks(3802), 87, new DateTime(2022, 1, 2, 12, 19, 9, 703, DateTimeKind.Local).AddTicks(6138), new DateTime(2021, 3, 24, 20, 16, 6, 486, DateTimeKind.Local).AddTicks(3672), 4, 17, "Maxime voluptate soluta est a ducimus et expedita cupiditate modi.\nSint ratione alias et quia numquam deleniti." },
                    { 137, new DateTime(2021, 7, 9, 14, 24, 32, 831, DateTimeKind.Local).AddTicks(7631), 74, new DateTime(2022, 7, 21, 12, 27, 9, 95, DateTimeKind.Local).AddTicks(5172), new DateTime(2021, 7, 7, 10, 20, 58, 661, DateTimeKind.Local).AddTicks(7409), 3, 17, "Vel aut qui voluptates in et doloribus ut id alias. Adipisci ipsum quia ipsam quidem quia. A commodi dolorem molestiae. Quasi quae ab et repudiandae et pariatur quis delectus eum. Reiciendis non cum porro iste labore sed omnis sint reiciendis." },
                    { 24, new DateTime(2020, 12, 23, 2, 56, 52, 993, DateTimeKind.Local).AddTicks(7295), 109, new DateTime(2022, 6, 19, 3, 24, 33, 265, DateTimeKind.Local).AddTicks(3162), new DateTime(2020, 12, 3, 11, 46, 0, 388, DateTimeKind.Local).AddTicks(2342), 4, 44, "Fuga molestiae eos in sed est. Qui accusantium libero velit reprehenderit quod tenetur molestias culpa. At maxime aut quia accusamus quo." },
                    { 44, new DateTime(2021, 4, 1, 7, 46, 21, 51, DateTimeKind.Local).AddTicks(4041), 65, new DateTime(2022, 2, 26, 10, 1, 10, 6, DateTimeKind.Local).AddTicks(6514), new DateTime(2021, 7, 21, 19, 8, 35, 423, DateTimeKind.Local).AddTicks(5615), 5, 44, "Iste nam totam ut." },
                    { 51, new DateTime(2021, 1, 1, 12, 6, 4, 2, DateTimeKind.Local).AddTicks(8552), 134, new DateTime(2022, 2, 16, 14, 47, 57, 213, DateTimeKind.Local).AddTicks(4252), new DateTime(2021, 2, 17, 17, 44, 49, 634, DateTimeKind.Local).AddTicks(1608), 2, 44, "Pariatur asperiores aspernatur magni voluptatem voluptates suscipit est ratione." },
                    { 120, new DateTime(2020, 8, 15, 23, 50, 20, 626, DateTimeKind.Local).AddTicks(5961), 96, new DateTime(2021, 10, 23, 13, 53, 48, 836, DateTimeKind.Local).AddTicks(4978), new DateTime(2021, 5, 26, 19, 40, 7, 674, DateTimeKind.Local).AddTicks(7154), 3, 44, "recusandae" },
                    { 122, new DateTime(2021, 6, 29, 3, 17, 9, 155, DateTimeKind.Local).AddTicks(269), 142, new DateTime(2022, 4, 22, 6, 58, 20, 444, DateTimeKind.Local).AddTicks(7905), new DateTime(2020, 12, 3, 2, 42, 1, 622, DateTimeKind.Local).AddTicks(9471), 1, 44, "Quos suscipit molestiae." },
                    { 149, new DateTime(2021, 5, 5, 18, 6, 49, 683, DateTimeKind.Local).AddTicks(1463), 83, new DateTime(2022, 4, 2, 0, 53, 53, 1, DateTimeKind.Local).AddTicks(263), new DateTime(2021, 5, 14, 3, 11, 28, 236, DateTimeKind.Local).AddTicks(7123), 1, 44, "Et possimus reiciendis et sint. Ab qui accusamus beatae qui quisquam maxime est. Sed aut consequatur nam dolore sit asperiores debitis eum molestias. Fuga autem sit tempore." },
                    { 191, new DateTime(2020, 12, 24, 12, 15, 23, 78, DateTimeKind.Local).AddTicks(4654), 113, new DateTime(2022, 4, 2, 12, 52, 50, 40, DateTimeKind.Local).AddTicks(8146), new DateTime(2021, 4, 20, 20, 35, 43, 546, DateTimeKind.Local).AddTicks(5483), 3, 44, "Dolor aut culpa adipisci eligendi consequuntur eligendi in." },
                    { 6, new DateTime(2021, 2, 14, 2, 18, 30, 817, DateTimeKind.Local).AddTicks(3185), 51, new DateTime(2022, 1, 26, 14, 18, 15, 567, DateTimeKind.Local).AddTicks(7370), new DateTime(2020, 8, 30, 19, 29, 27, 53, DateTimeKind.Local).AddTicks(1923), 3, 26, "Dolor enim quasi. Cumque placeat quod laboriosam magnam soluta voluptatum in. Ut necessitatibus laboriosam id numquam. Tempora necessitatibus ipsum error itaque omnis est sint quidem. Eveniet voluptas voluptatem autem. Numquam est nulla quos." },
                    { 164, new DateTime(2021, 1, 17, 2, 25, 20, 132, DateTimeKind.Local).AddTicks(1573), 97, new DateTime(2021, 9, 7, 16, 2, 45, 954, DateTimeKind.Local).AddTicks(267), new DateTime(2021, 5, 29, 11, 56, 28, 504, DateTimeKind.Local).AddTicks(3794), 5, 26, "Harum dolorem voluptas amet maiores velit modi et et. Adipisci consequatur repudiandae temporibus molestiae ut. Id non sit." },
                    { 192, new DateTime(2020, 8, 19, 4, 54, 7, 730, DateTimeKind.Local).AddTicks(3978), 12, new DateTime(2021, 11, 29, 16, 7, 7, 968, DateTimeKind.Local).AddTicks(8893), new DateTime(2020, 10, 29, 22, 43, 26, 618, DateTimeKind.Local).AddTicks(1160), 2, 26, "Qui sed quis velit eius.\nVoluptatum et labore autem quasi et incidunt reiciendis.\nVelit aut unde cum et nemo voluptate." },
                    { 194, new DateTime(2021, 2, 11, 5, 10, 25, 830, DateTimeKind.Local).AddTicks(6928), 61, new DateTime(2021, 11, 3, 17, 35, 15, 438, DateTimeKind.Local).AddTicks(468), new DateTime(2020, 11, 11, 6, 50, 4, 666, DateTimeKind.Local).AddTicks(8663), 3, 26, "Libero adipisci ipsam.\nUnde illum aperiam hic tempora neque ratione tempore voluptatem quia.\nFuga laborum corrupti aut.\nRatione omnis esse deserunt quam et accusantium.\nNam molestiae non." },
                    { 8, new DateTime(2020, 10, 9, 4, 59, 29, 419, DateTimeKind.Local).AddTicks(1968), 3, new DateTime(2021, 8, 20, 7, 14, 17, 15, DateTimeKind.Local).AddTicks(4489), new DateTime(2021, 6, 15, 14, 44, 38, 448, DateTimeKind.Local).AddTicks(3353), 2, 22, "aliquid" },
                    { 32, new DateTime(2021, 5, 15, 7, 14, 31, 210, DateTimeKind.Local).AddTicks(3928), 147, new DateTime(2022, 5, 28, 17, 7, 2, 326, DateTimeKind.Local).AddTicks(9363), new DateTime(2021, 5, 7, 5, 9, 28, 694, DateTimeKind.Local).AddTicks(4976), 3, 22, "Rerum ullam est nihil voluptatibus similique ad. Molestias similique blanditiis dolores similique ut id at dicta. Ea eligendi fuga praesentium at. Eum sed reprehenderit repellendus exercitationem nisi dolor ut voluptatem. Accusamus ipsam eos." },
                    { 75, new DateTime(2020, 12, 24, 16, 14, 31, 338, DateTimeKind.Local).AddTicks(1041), 83, new DateTime(2022, 3, 15, 20, 49, 31, 537, DateTimeKind.Local).AddTicks(6139), new DateTime(2021, 5, 31, 10, 19, 50, 905, DateTimeKind.Local).AddTicks(1022), 2, 22, "Perferendis est et similique et enim quod recusandae. Ratione pariatur quia repellat qui cupiditate aspernatur ut in. Ex reprehenderit iste sit sunt saepe consequatur exercitationem. Reiciendis itaque laboriosam voluptas. Debitis aut dolor corporis. Iusto quia dolorum dignissimos hic et reprehenderit velit voluptatem." },
                    { 85, new DateTime(2020, 10, 7, 1, 1, 46, 210, DateTimeKind.Local).AddTicks(1579), 71, new DateTime(2022, 2, 17, 16, 8, 44, 781, DateTimeKind.Local).AddTicks(3), new DateTime(2020, 12, 23, 5, 52, 8, 80, DateTimeKind.Local).AddTicks(9095), 3, 22, "A in ut quia reprehenderit minima est." },
                    { 124, new DateTime(2021, 3, 12, 17, 45, 52, 233, DateTimeKind.Local).AddTicks(4077), 60, new DateTime(2022, 2, 13, 9, 5, 28, 120, DateTimeKind.Local).AddTicks(6818), new DateTime(2020, 11, 9, 23, 30, 57, 63, DateTimeKind.Local).AddTicks(185), 3, 22, "Voluptatem aperiam aliquam quisquam sed." },
                    { 3, new DateTime(2021, 7, 21, 11, 53, 44, 92, DateTimeKind.Local).AddTicks(3327), 149, new DateTime(2022, 2, 16, 20, 0, 44, 410, DateTimeKind.Local).AddTicks(4220), new DateTime(2020, 11, 9, 2, 54, 12, 367, DateTimeKind.Local).AddTicks(8057), 5, 39, "Quae est voluptas commodi illum consequuntur. Ut voluptatem deserunt explicabo vel aut. Fuga eveniet quas ipsa nemo magnam error velit et. Atque sit quia." },
                    { 11, new DateTime(2021, 4, 9, 16, 49, 44, 328, DateTimeKind.Local).AddTicks(3888), 44, new DateTime(2022, 2, 19, 0, 19, 53, 991, DateTimeKind.Local).AddTicks(8006), new DateTime(2020, 10, 31, 6, 58, 48, 542, DateTimeKind.Local).AddTicks(2135), 3, 6, "Ea et quis rem quae delectus velit eos facilis quibusdam.\nRerum sed qui distinctio architecto doloribus laborum est.\nMinima aut porro." },
                    { 106, new DateTime(2020, 12, 13, 22, 31, 33, 275, DateTimeKind.Local).AddTicks(2092), 106, new DateTime(2022, 2, 22, 0, 4, 31, 747, DateTimeKind.Local).AddTicks(8743), new DateTime(2020, 11, 26, 4, 12, 31, 889, DateTimeKind.Local).AddTicks(9011), 2, 72, "Maxime nostrum dolor dolore et dicta provident repudiandae fuga." },
                    { 154, new DateTime(2021, 5, 6, 22, 37, 47, 509, DateTimeKind.Local).AddTicks(5393), 67, new DateTime(2022, 4, 13, 3, 23, 15, 295, DateTimeKind.Local).AddTicks(8685), new DateTime(2020, 12, 14, 14, 49, 12, 871, DateTimeKind.Local).AddTicks(764), 5, 66, "Laudantium quam id eum illum cumque nam voluptates deleniti. Odit et error quas est cumque. Pariatur esse nobis facilis deleniti atque numquam alias tempore. Distinctio architecto commodi corporis. Itaque magnam voluptas qui quo." },
                    { 157, new DateTime(2020, 11, 12, 1, 13, 31, 209, DateTimeKind.Local).AddTicks(7535), 74, new DateTime(2022, 5, 23, 6, 55, 8, 760, DateTimeKind.Local).AddTicks(634), new DateTime(2021, 5, 15, 1, 42, 23, 261, DateTimeKind.Local).AddTicks(3959), 3, 6, "A eos provident consectetur." },
                    { 172, new DateTime(2021, 7, 28, 17, 10, 13, 746, DateTimeKind.Local).AddTicks(401), 45, new DateTime(2021, 9, 3, 18, 44, 18, 973, DateTimeKind.Local).AddTicks(5632), new DateTime(2021, 2, 1, 23, 14, 36, 75, DateTimeKind.Local).AddTicks(6292), 3, 6, "inventore" },
                    { 77, new DateTime(2021, 3, 3, 4, 49, 12, 720, DateTimeKind.Local).AddTicks(9466), 56, new DateTime(2022, 5, 27, 18, 15, 38, 352, DateTimeKind.Local).AddTicks(1089), new DateTime(2020, 11, 13, 23, 14, 51, 217, DateTimeKind.Local).AddTicks(9253), 3, 77, "quia" },
                    { 82, new DateTime(2021, 7, 2, 3, 55, 5, 218, DateTimeKind.Local).AddTicks(6045), 5, new DateTime(2021, 10, 1, 0, 0, 35, 832, DateTimeKind.Local).AddTicks(9555), new DateTime(2021, 8, 7, 22, 41, 56, 695, DateTimeKind.Local).AddTicks(9256), 2, 77, "Error non molestiae veritatis delectus esse. Dolores officia facere laudantium vitae. Non autem ipsam dolor natus et." },
                    { 114, new DateTime(2021, 8, 5, 6, 31, 9, 498, DateTimeKind.Local).AddTicks(7924), 42, new DateTime(2021, 10, 3, 22, 13, 9, 642, DateTimeKind.Local).AddTicks(3445), new DateTime(2021, 1, 13, 6, 37, 8, 778, DateTimeKind.Local).AddTicks(1978), 4, 77, "Delectus nostrum tempore autem." },
                    { 7, new DateTime(2020, 11, 12, 8, 40, 40, 535, DateTimeKind.Local).AddTicks(7831), 8, new DateTime(2022, 7, 6, 4, 7, 31, 419, DateTimeKind.Local).AddTicks(8062), new DateTime(2021, 6, 23, 21, 50, 19, 943, DateTimeKind.Local).AddTicks(2326), 1, 16, "Quam earum laborum sapiente neque eligendi tempora harum velit est." },
                    { 97, new DateTime(2020, 8, 30, 17, 16, 13, 106, DateTimeKind.Local).AddTicks(9092), 150, new DateTime(2022, 7, 16, 1, 22, 13, 587, DateTimeKind.Local).AddTicks(9458), new DateTime(2021, 5, 24, 18, 54, 52, 792, DateTimeKind.Local).AddTicks(2066), 1, 16, "Sit est velit aut itaque.\nEst voluptatem iure accusamus velit omnis omnis sunt quae libero.\nSuscipit placeat enim aut fugit.\nAut reprehenderit repellendus et ducimus distinctio impedit nihil error." },
                    { 109, new DateTime(2021, 5, 27, 1, 36, 56, 838, DateTimeKind.Local).AddTicks(6188), 141, new DateTime(2021, 10, 3, 7, 10, 40, 60, DateTimeKind.Local).AddTicks(2194), new DateTime(2021, 7, 20, 11, 25, 30, 166, DateTimeKind.Local).AddTicks(9913), 4, 16, "exercitationem" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 168, new DateTime(2020, 8, 30, 2, 0, 44, 350, DateTimeKind.Local).AddTicks(905), 111, new DateTime(2022, 5, 28, 4, 12, 16, 561, DateTimeKind.Local).AddTicks(2834), new DateTime(2020, 10, 29, 10, 53, 41, 48, DateTimeKind.Local).AddTicks(1191), 2, 16, "Voluptas laborum voluptatum." },
                    { 71, new DateTime(2021, 5, 5, 3, 31, 31, 378, DateTimeKind.Local).AddTicks(3457), 18, new DateTime(2022, 1, 23, 6, 27, 44, 628, DateTimeKind.Local).AddTicks(5487), new DateTime(2020, 12, 11, 5, 56, 30, 489, DateTimeKind.Local).AddTicks(8887), 4, 49, "Recusandae distinctio et quia.\nVel et ut suscipit.\nAt ullam doloribus magni consequatur reiciendis aliquam molestiae vero.\nVero iste possimus a qui dolor quae.\nEt enim enim soluta et itaque est.\nId sint numquam et amet ut voluptatum aperiam." },
                    { 89, new DateTime(2021, 3, 8, 7, 22, 33, 546, DateTimeKind.Local).AddTicks(6837), 126, new DateTime(2022, 1, 8, 3, 33, 46, 957, DateTimeKind.Local).AddTicks(6061), new DateTime(2020, 8, 23, 8, 54, 26, 693, DateTimeKind.Local).AddTicks(7715), 4, 49, "Ipsam id consectetur quos debitis unde." },
                    { 91, new DateTime(2020, 10, 17, 20, 24, 54, 46, DateTimeKind.Local).AddTicks(907), 19, new DateTime(2021, 12, 18, 15, 52, 55, 878, DateTimeKind.Local).AddTicks(9542), new DateTime(2021, 1, 13, 0, 2, 33, 835, DateTimeKind.Local).AddTicks(6924), 1, 49, "consequatur" },
                    { 61, new DateTime(2021, 1, 7, 5, 38, 8, 39, DateTimeKind.Local).AddTicks(7794), 42, new DateTime(2021, 11, 16, 5, 59, 42, 130, DateTimeKind.Local).AddTicks(4912), new DateTime(2021, 3, 3, 7, 18, 58, 15, DateTimeKind.Local).AddTicks(8204), 4, 34, "Et vel voluptas magnam quia qui facere necessitatibus explicabo." },
                    { 92, new DateTime(2020, 9, 10, 16, 32, 28, 744, DateTimeKind.Local).AddTicks(5059), 150, new DateTime(2021, 9, 5, 18, 0, 52, 709, DateTimeKind.Local).AddTicks(9088), new DateTime(2021, 7, 17, 5, 31, 32, 869, DateTimeKind.Local).AddTicks(8646), 3, 34, "vel" },
                    { 183, new DateTime(2021, 4, 25, 3, 1, 51, 905, DateTimeKind.Local).AddTicks(9993), 94, new DateTime(2022, 2, 12, 17, 5, 32, 80, DateTimeKind.Local).AddTicks(6250), new DateTime(2021, 6, 27, 8, 36, 41, 952, DateTimeKind.Local).AddTicks(3019), 2, 34, "Ut velit odio earum illo labore quis consequuntur animi doloribus." },
                    { 40, new DateTime(2021, 1, 17, 5, 39, 34, 396, DateTimeKind.Local).AddTicks(2313), 21, new DateTime(2022, 2, 2, 0, 48, 24, 76, DateTimeKind.Local).AddTicks(1003), new DateTime(2021, 3, 21, 22, 22, 4, 631, DateTimeKind.Local).AddTicks(174), 2, 21, "Ut saepe molestiae fugit explicabo iusto atque omnis." },
                    { 111, new DateTime(2021, 4, 18, 21, 34, 54, 939, DateTimeKind.Local).AddTicks(1941), 45, new DateTime(2022, 3, 7, 19, 39, 18, 145, DateTimeKind.Local).AddTicks(9612), new DateTime(2020, 12, 4, 12, 7, 6, 291, DateTimeKind.Local).AddTicks(9451), 3, 21, "Eum alias sed cum rerum cupiditate voluptatibus repellendus eos.\nRerum reiciendis nulla porro laudantium est et ad.\nNihil ut aut minus ipsa ut a." },
                    { 145, new DateTime(2020, 12, 19, 8, 54, 12, 50, DateTimeKind.Local).AddTicks(2889), 43, new DateTime(2022, 2, 25, 21, 34, 59, 91, DateTimeKind.Local).AddTicks(9599), new DateTime(2021, 5, 3, 2, 21, 40, 425, DateTimeKind.Local).AddTicks(6623), 5, 21, "Veniam quasi ut est soluta quae distinctio quas.\nProvident sapiente corrupti accusamus nostrum iste quae quo aut.\nEos enim id est.\nRem commodi impedit adipisci eos voluptates error eligendi." },
                    { 151, new DateTime(2020, 9, 27, 0, 27, 8, 908, DateTimeKind.Local).AddTicks(3222), 60, new DateTime(2021, 10, 4, 16, 46, 50, 23, DateTimeKind.Local).AddTicks(8803), new DateTime(2020, 9, 24, 19, 51, 6, 378, DateTimeKind.Local).AddTicks(7198), 1, 21, "earum" },
                    { 4, new DateTime(2020, 9, 6, 8, 12, 51, 477, DateTimeKind.Local).AddTicks(897), 112, new DateTime(2021, 8, 23, 9, 24, 40, 726, DateTimeKind.Local).AddTicks(6246), new DateTime(2020, 10, 5, 8, 22, 22, 45, DateTimeKind.Local).AddTicks(9951), 4, 66, "Odio architecto voluptatum non. Nihil accusantium veniam sit ut natus ut. Ducimus quis expedita natus consequatur." },
                    { 81, new DateTime(2021, 6, 7, 15, 58, 2, 549, DateTimeKind.Local).AddTicks(9991), 82, new DateTime(2022, 6, 29, 20, 26, 47, 319, DateTimeKind.Local).AddTicks(5594), new DateTime(2021, 1, 23, 18, 50, 14, 887, DateTimeKind.Local).AddTicks(6465), 4, 66, "Harum laudantium non vero cum ullam aut sit alias eius. Quae eos suscipit quia enim blanditiis iusto fugiat. Maiores aliquam ratione. Ullam et amet explicabo aut ut et nostrum." },
                    { 22, new DateTime(2020, 8, 31, 15, 44, 2, 392, DateTimeKind.Local).AddTicks(3174), 10, new DateTime(2022, 2, 19, 3, 11, 49, 889, DateTimeKind.Local).AddTicks(17), new DateTime(2021, 3, 3, 1, 0, 44, 771, DateTimeKind.Local).AddTicks(3678), 5, 72, "et" },
                    { 37, new DateTime(2020, 10, 15, 11, 52, 26, 859, DateTimeKind.Local).AddTicks(3421), 103, new DateTime(2022, 1, 18, 2, 24, 44, 813, DateTimeKind.Local).AddTicks(7481), new DateTime(2021, 3, 1, 0, 35, 9, 234, DateTimeKind.Local).AddTicks(8858), 4, 37, "Aperiam sint a vero." },
                    { 13, new DateTime(2021, 3, 8, 1, 38, 9, 164, DateTimeKind.Local).AddTicks(5608), 104, new DateTime(2021, 8, 22, 21, 0, 15, 601, DateTimeKind.Local).AddTicks(1626), new DateTime(2020, 9, 16, 21, 48, 21, 574, DateTimeKind.Local).AddTicks(2436), 4, 37, "Illo veniam nesciunt reprehenderit sint tempora eligendi." },
                    { 118, new DateTime(2021, 2, 14, 10, 38, 53, 305, DateTimeKind.Local).AddTicks(9345), 105, new DateTime(2022, 4, 23, 0, 1, 46, 930, DateTimeKind.Local).AddTicks(4417), new DateTime(2021, 3, 4, 6, 45, 52, 345, DateTimeKind.Local).AddTicks(1111), 3, 70, "Rem ut voluptatem et est nam earum." },
                    { 21, new DateTime(2020, 9, 8, 1, 33, 29, 240, DateTimeKind.Local).AddTicks(9663), 141, new DateTime(2022, 6, 30, 3, 29, 27, 976, DateTimeKind.Local).AddTicks(7149), new DateTime(2021, 1, 8, 2, 37, 30, 441, DateTimeKind.Local).AddTicks(4593), 3, 30, "Beatae voluptas sit et." },
                    { 43, new DateTime(2021, 4, 23, 16, 21, 14, 605, DateTimeKind.Local).AddTicks(6638), 15, new DateTime(2022, 5, 19, 3, 50, 53, 89, DateTimeKind.Local).AddTicks(3543), new DateTime(2021, 4, 18, 13, 35, 20, 244, DateTimeKind.Local).AddTicks(436), 5, 30, "dolores" },
                    { 152, new DateTime(2021, 1, 2, 1, 48, 11, 222, DateTimeKind.Local).AddTicks(5924), 28, new DateTime(2021, 12, 1, 7, 31, 16, 962, DateTimeKind.Local).AddTicks(8485), new DateTime(2020, 11, 8, 19, 39, 49, 882, DateTimeKind.Local).AddTicks(7167), 4, 30, "Vel voluptatem vitae adipisci.\nPossimus sed sed.\nRepellat est dolorum dicta dicta est ducimus rerum voluptatem aspernatur.\nDolor dolores odit qui." },
                    { 161, new DateTime(2021, 8, 3, 9, 48, 50, 43, DateTimeKind.Local).AddTicks(8026), 25, new DateTime(2022, 6, 10, 1, 39, 6, 585, DateTimeKind.Local).AddTicks(9097), new DateTime(2021, 6, 5, 14, 18, 52, 925, DateTimeKind.Local).AddTicks(2692), 4, 30, "Aut necessitatibus iste quo ipsam doloremque sunt enim reiciendis." },
                    { 196, new DateTime(2020, 10, 2, 9, 22, 18, 364, DateTimeKind.Local).AddTicks(5735), 110, new DateTime(2022, 5, 29, 8, 1, 35, 499, DateTimeKind.Local).AddTicks(1518), new DateTime(2021, 5, 14, 4, 26, 56, 195, DateTimeKind.Local).AddTicks(8381), 5, 30, "Ad et culpa dolor eum mollitia vero repellat.\nId adipisci odit perspiciatis molestias fugiat ipsum.\nIste veritatis dicta.\nDeserunt illo repellendus necessitatibus et dolore.\nPariatur repellendus deserunt molestias optio tempora sint.\nDolore laboriosam ad unde id distinctio." },
                    { 179, new DateTime(2021, 6, 12, 4, 2, 33, 759, DateTimeKind.Local).AddTicks(7792), 130, new DateTime(2021, 10, 12, 5, 7, 55, 82, DateTimeKind.Local).AddTicks(1484), new DateTime(2021, 1, 27, 12, 17, 2, 487, DateTimeKind.Local).AddTicks(5049), 5, 48, "Optio aspernatur quis quis tenetur culpa occaecati distinctio.\nVoluptas deleniti sed ea impedit dolores corrupti ipsam quia qui.\nEt omnis id odio sint." },
                    { 45, new DateTime(2021, 7, 11, 17, 34, 58, 821, DateTimeKind.Local).AddTicks(5784), 29, new DateTime(2022, 7, 5, 8, 20, 54, 793, DateTimeKind.Local).AddTicks(7569), new DateTime(2020, 12, 23, 21, 55, 54, 266, DateTimeKind.Local).AddTicks(1433), 5, 1, "Doloribus reiciendis error quia et sed esse ipsa." },
                    { 93, new DateTime(2020, 11, 5, 19, 0, 52, 903, DateTimeKind.Local).AddTicks(1792), 11, new DateTime(2021, 10, 23, 9, 58, 30, 762, DateTimeKind.Local).AddTicks(4783), new DateTime(2021, 5, 17, 23, 54, 56, 877, DateTimeKind.Local).AddTicks(6550), 5, 1, "Fugit iste voluptas esse praesentium fuga facilis ex tempore vero. Qui porro repellat veritatis odit. At enim eum omnis asperiores fugiat sed repellat. Ipsum dolorum neque dolorem vero rerum veritatis ex. Deserunt nemo officia. Tenetur impedit voluptas quae dolorem." },
                    { 185, new DateTime(2020, 9, 2, 12, 36, 15, 673, DateTimeKind.Local).AddTicks(4660), 139, new DateTime(2022, 1, 24, 12, 43, 18, 837, DateTimeKind.Local).AddTicks(4188), new DateTime(2020, 12, 27, 23, 17, 26, 162, DateTimeKind.Local).AddTicks(7886), 5, 1, "Et dolor a. Delectus quia tenetur numquam modi vero explicabo ipsum sint. Quo et enim officiis recusandae illo rerum beatae explicabo rem." },
                    { 197, new DateTime(2021, 4, 6, 0, 3, 15, 135, DateTimeKind.Local).AddTicks(5022), 108, new DateTime(2021, 10, 5, 23, 32, 38, 604, DateTimeKind.Local).AddTicks(869), new DateTime(2021, 4, 11, 7, 56, 50, 334, DateTimeKind.Local).AddTicks(8427), 4, 1, "Blanditiis sequi nam eos enim soluta dignissimos quibusdam saepe assumenda." },
                    { 10, new DateTime(2021, 1, 8, 0, 43, 55, 265, DateTimeKind.Local).AddTicks(1447), 54, new DateTime(2022, 4, 29, 15, 44, 59, 66, DateTimeKind.Local).AddTicks(1953), new DateTime(2021, 3, 4, 20, 59, 2, 716, DateTimeKind.Local).AddTicks(4381), 1, 9, "Id voluptatem explicabo maxime.\nEst ut quo." },
                    { 83, new DateTime(2021, 7, 6, 17, 39, 14, 507, DateTimeKind.Local).AddTicks(7549), 84, new DateTime(2022, 7, 12, 1, 13, 27, 117, DateTimeKind.Local).AddTicks(5457), new DateTime(2021, 7, 6, 8, 1, 37, 861, DateTimeKind.Local).AddTicks(2808), 5, 9, "Culpa dignissimos temporibus dolorum et et. Quae quisquam nobis suscipit eum illum. Exercitationem eius omnis non qui et quas incidunt est odit. Quasi esse molestiae dolor qui quo." },
                    { 96, new DateTime(2020, 10, 18, 1, 8, 28, 754, DateTimeKind.Local).AddTicks(6055), 40, new DateTime(2022, 2, 15, 15, 23, 39, 664, DateTimeKind.Local).AddTicks(8134), new DateTime(2021, 2, 20, 10, 31, 16, 936, DateTimeKind.Local).AddTicks(1788), 2, 9, "Quia consequatur officiis.\nSoluta enim porro." },
                    { 102, new DateTime(2020, 10, 15, 14, 32, 43, 630, DateTimeKind.Local).AddTicks(497), 13, new DateTime(2022, 4, 22, 10, 24, 37, 908, DateTimeKind.Local).AddTicks(4137), new DateTime(2021, 1, 3, 3, 48, 39, 726, DateTimeKind.Local).AddTicks(5850), 4, 9, "Veritatis saepe omnis nam omnis itaque vero magnam recusandae laudantium.\nRerum sapiente necessitatibus delectus est ab eos non numquam quam.\nProvident maxime ex beatae." },
                    { 112, new DateTime(2021, 4, 24, 14, 24, 53, 51, DateTimeKind.Local).AddTicks(5209), 49, new DateTime(2022, 6, 15, 21, 3, 49, 421, DateTimeKind.Local).AddTicks(4422), new DateTime(2021, 5, 24, 18, 42, 0, 239, DateTimeKind.Local).AddTicks(255), 1, 9, "Ut qui consequatur quisquam tempora officiis commodi. Nostrum dolorem nisi. Autem consequuntur aut. Quo explicabo eum sapiente voluptate ut neque dolores molestiae non." },
                    { 142, new DateTime(2021, 6, 4, 8, 31, 9, 544, DateTimeKind.Local).AddTicks(5425), 72, new DateTime(2022, 4, 24, 21, 0, 15, 896, DateTimeKind.Local).AddTicks(9129), new DateTime(2021, 6, 16, 22, 35, 27, 68, DateTimeKind.Local).AddTicks(4714), 2, 9, "consequatur" },
                    { 165, new DateTime(2021, 5, 28, 20, 31, 22, 137, DateTimeKind.Local).AddTicks(1556), 107, new DateTime(2022, 5, 25, 9, 15, 36, 11, DateTimeKind.Local).AddTicks(9024), new DateTime(2020, 11, 29, 3, 44, 34, 933, DateTimeKind.Local).AddTicks(9022), 1, 9, "ad" },
                    { 169, new DateTime(2021, 1, 13, 22, 19, 52, 546, DateTimeKind.Local).AddTicks(9388), 33, new DateTime(2022, 3, 15, 10, 7, 39, 42, DateTimeKind.Local).AddTicks(8334), new DateTime(2021, 4, 19, 12, 54, 7, 514, DateTimeKind.Local).AddTicks(5087), 1, 9, "ratione" },
                    { 59, new DateTime(2020, 12, 10, 7, 59, 48, 529, DateTimeKind.Local).AddTicks(3966), 125, new DateTime(2022, 1, 30, 9, 21, 13, 13, DateTimeKind.Local).AddTicks(5910), new DateTime(2021, 5, 2, 4, 27, 23, 141, DateTimeKind.Local).AddTicks(314), 2, 51, "Eius et sit eos tempora mollitia dolor iusto labore." },
                    { 184, new DateTime(2021, 3, 5, 22, 1, 22, 414, DateTimeKind.Local).AddTicks(3878), 19, new DateTime(2022, 1, 22, 12, 23, 12, 217, DateTimeKind.Local).AddTicks(2622), new DateTime(2020, 10, 29, 21, 2, 21, 600, DateTimeKind.Local).AddTicks(5223), 3, 51, "Et quia perferendis enim voluptatem ut alias." },
                    { 23, new DateTime(2021, 1, 20, 14, 56, 25, 797, DateTimeKind.Local).AddTicks(3250), 11, new DateTime(2022, 1, 4, 15, 6, 31, 402, DateTimeKind.Local).AddTicks(6539), new DateTime(2020, 10, 1, 19, 4, 2, 418, DateTimeKind.Local).AddTicks(9035), 1, 73, "Placeat modi sit ipsa sit inventore debitis magnam magnam." },
                    { 178, new DateTime(2021, 3, 11, 3, 37, 40, 846, DateTimeKind.Local).AddTicks(9408), 123, new DateTime(2022, 4, 15, 17, 33, 27, 192, DateTimeKind.Local).AddTicks(3521), new DateTime(2020, 12, 17, 8, 56, 32, 729, DateTimeKind.Local).AddTicks(6210), 5, 46, "Est eligendi aut occaecati numquam eveniet velit aperiam aliquam voluptate." },
                    { 55, new DateTime(2021, 7, 28, 1, 14, 29, 169, DateTimeKind.Local).AddTicks(3126), 18, new DateTime(2022, 3, 27, 12, 29, 17, 23, DateTimeKind.Local).AddTicks(7966), new DateTime(2021, 1, 26, 19, 1, 37, 648, DateTimeKind.Local).AddTicks(821), 1, 4, "Debitis ea maiores est.\nTotam cum quam rerum.\nAccusamus voluptatibus aliquid et consequuntur unde non.\nQui sint ipsa eveniet consequatur.\nSapiente ut architecto ea reprehenderit nesciunt dolores ipsum voluptate.\nEt culpa aut." },
                    { 107, new DateTime(2020, 9, 7, 23, 11, 33, 210, DateTimeKind.Local).AddTicks(607), 149, new DateTime(2021, 8, 25, 0, 15, 52, 317, DateTimeKind.Local).AddTicks(3977), new DateTime(2020, 10, 4, 20, 40, 8, 75, DateTimeKind.Local).AddTicks(1081), 4, 46, "exercitationem" },
                    { 27, new DateTime(2021, 4, 29, 8, 9, 56, 671, DateTimeKind.Local).AddTicks(2865), 148, new DateTime(2021, 12, 21, 21, 15, 37, 608, DateTimeKind.Local).AddTicks(4560), new DateTime(2020, 12, 11, 4, 16, 10, 334, DateTimeKind.Local).AddTicks(2864), 1, 46, "Saepe corrupti quas numquam aspernatur eos voluptatem facere non quas. Aliquid delectus eius recusandae perferendis ullam minus iusto veniam fuga. Eos aliquam quo. Assumenda quisquam quo molestias quibusdam dolorem. Illum quisquam nemo. Sequi culpa vel nemo in voluptatem non." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 116, new DateTime(2020, 11, 15, 2, 57, 41, 896, DateTimeKind.Local).AddTicks(8251), 109, new DateTime(2022, 2, 10, 20, 47, 54, 539, DateTimeKind.Local).AddTicks(9558), new DateTime(2020, 12, 28, 0, 51, 53, 374, DateTimeKind.Local).AddTicks(578), 1, 53, "Iste dolorem rerum itaque reiciendis enim." },
                    { 140, new DateTime(2020, 12, 22, 8, 16, 14, 678, DateTimeKind.Local).AddTicks(307), 56, new DateTime(2022, 7, 13, 11, 27, 44, 329, DateTimeKind.Local).AddTicks(162), new DateTime(2021, 3, 6, 12, 10, 11, 480, DateTimeKind.Local).AddTicks(6801), 5, 53, "Facilis qui est quis odit repellat quibusdam." },
                    { 18, new DateTime(2021, 6, 8, 8, 40, 21, 93, DateTimeKind.Local).AddTicks(6938), 106, new DateTime(2021, 8, 20, 10, 20, 30, 992, DateTimeKind.Local).AddTicks(619), new DateTime(2020, 8, 23, 21, 43, 3, 776, DateTimeKind.Local).AddTicks(9502), 4, 5, "Alias perferendis aut quam vitae repudiandae quasi saepe illo. Quaerat ex earum dolor dolores dolorem perspiciatis inventore. Quae cumque et aspernatur explicabo nesciunt dolore fuga." },
                    { 34, new DateTime(2020, 12, 31, 19, 49, 15, 511, DateTimeKind.Local).AddTicks(8365), 106, new DateTime(2022, 5, 25, 16, 19, 8, 902, DateTimeKind.Local).AddTicks(2811), new DateTime(2021, 3, 16, 4, 16, 9, 689, DateTimeKind.Local).AddTicks(7535), 1, 5, "Id hic ducimus explicabo ipsa eum nisi libero." },
                    { 26, new DateTime(2021, 4, 13, 22, 50, 19, 476, DateTimeKind.Local).AddTicks(3581), 5, new DateTime(2022, 3, 18, 7, 45, 8, 106, DateTimeKind.Local).AddTicks(7515), new DateTime(2021, 5, 28, 1, 23, 39, 820, DateTimeKind.Local).AddTicks(238), 5, 14, "sit" },
                    { 80, new DateTime(2021, 5, 2, 9, 25, 40, 805, DateTimeKind.Local).AddTicks(8727), 135, new DateTime(2021, 11, 14, 9, 11, 59, 661, DateTimeKind.Local).AddTicks(5872), new DateTime(2020, 11, 27, 21, 14, 42, 0, DateTimeKind.Local).AddTicks(939), 5, 14, "Non qui non est nihil aut." },
                    { 129, new DateTime(2020, 12, 30, 18, 18, 52, 556, DateTimeKind.Local).AddTicks(459), 85, new DateTime(2021, 12, 16, 5, 40, 24, 532, DateTimeKind.Local).AddTicks(149), new DateTime(2020, 9, 6, 1, 15, 58, 241, DateTimeKind.Local).AddTicks(3609), 4, 14, "sequi" },
                    { 162, new DateTime(2020, 8, 13, 4, 43, 2, 10, DateTimeKind.Local).AddTicks(9922), 146, new DateTime(2021, 12, 31, 21, 5, 49, 776, DateTimeKind.Local).AddTicks(717), new DateTime(2021, 2, 8, 16, 58, 15, 850, DateTimeKind.Local).AddTicks(739), 4, 14, "Maxime et saepe quo fugit vel non nobis in.\nFuga voluptatibus occaecati autem.\nTenetur rerum repellat a quaerat quia consequatur repellendus eveniet.\nEx officia eum voluptas asperiores sequi similique voluptatem dolor deserunt.\nRerum explicabo est quod nemo et harum et nobis." },
                    { 171, new DateTime(2021, 5, 13, 2, 48, 47, 308, DateTimeKind.Local).AddTicks(4718), 9, new DateTime(2021, 8, 29, 10, 47, 25, 114, DateTimeKind.Local).AddTicks(2589), new DateTime(2021, 2, 22, 7, 5, 28, 790, DateTimeKind.Local).AddTicks(203), 2, 14, "Sit enim est vitae ad non ab aliquid.\nQuis incidunt nisi vero veritatis asperiores et omnis atque.\nQuaerat dolorum repellendus nihil.\nRerum laboriosam assumenda." },
                    { 175, new DateTime(2021, 6, 25, 11, 18, 3, 272, DateTimeKind.Local).AddTicks(1434), 34, new DateTime(2022, 8, 1, 14, 1, 10, 254, DateTimeKind.Local).AddTicks(3110), new DateTime(2020, 9, 5, 0, 15, 43, 856, DateTimeKind.Local).AddTicks(6562), 3, 14, "Id voluptatibus eligendi ut assumenda consequatur laboriosam veniam." },
                    { 121, new DateTime(2020, 9, 10, 1, 29, 8, 264, DateTimeKind.Local).AddTicks(5548), 12, new DateTime(2022, 2, 26, 12, 57, 42, 455, DateTimeKind.Local).AddTicks(1725), new DateTime(2021, 2, 18, 19, 52, 8, 956, DateTimeKind.Local).AddTicks(4352), 1, 47, "Enim accusantium maiores ex ea." },
                    { 15, new DateTime(2021, 5, 14, 10, 23, 56, 266, DateTimeKind.Local).AddTicks(5156), 147, new DateTime(2022, 3, 14, 22, 21, 42, 601, DateTimeKind.Local).AddTicks(1205), new DateTime(2021, 3, 13, 16, 20, 13, 639, DateTimeKind.Local).AddTicks(5719), 2, 7, "Et et nihil illo tempore ipsa quia." },
                    { 58, new DateTime(2020, 11, 14, 16, 12, 20, 33, DateTimeKind.Local).AddTicks(289), 103, new DateTime(2022, 7, 12, 16, 28, 8, 178, DateTimeKind.Local).AddTicks(1618), new DateTime(2020, 9, 8, 11, 9, 41, 522, DateTimeKind.Local).AddTicks(5436), 4, 7, "Officiis a sapiente omnis est ipsum necessitatibus.\nNihil dolore pariatur vel molestias veniam velit.\nVel sed sit voluptatem doloribus non consequuntur ut." },
                    { 90, new DateTime(2021, 2, 27, 4, 33, 17, 725, DateTimeKind.Local).AddTicks(6520), 49, new DateTime(2022, 8, 3, 8, 36, 21, 844, DateTimeKind.Local).AddTicks(5459), new DateTime(2020, 10, 23, 6, 12, 42, 74, DateTimeKind.Local).AddTicks(748), 1, 7, "Error ad quibusdam accusamus dignissimos nobis quidem accusantium sit quia.\nA amet minima magnam velit voluptatem et.\nFacilis dolorem esse consequuntur temporibus ab et sit.\nEnim enim quia quia eaque sed non.\nQui libero necessitatibus id cum.\nVero quis autem deserunt et est nesciunt rerum." },
                    { 95, new DateTime(2020, 8, 16, 23, 25, 6, 521, DateTimeKind.Local).AddTicks(8345), 76, new DateTime(2022, 1, 7, 12, 39, 25, 802, DateTimeKind.Local).AddTicks(383), new DateTime(2021, 5, 25, 12, 48, 45, 728, DateTimeKind.Local).AddTicks(9539), 4, 7, "Dolorem sit sequi fugiat beatae ut explicabo.\nEt dolore at et ipsum illo velit.\nNemo aliquid voluptate et vitae aut voluptatem perspiciatis.\nOdit animi consequuntur delectus molestiae vero." },
                    { 2, new DateTime(2020, 12, 13, 1, 52, 21, 244, DateTimeKind.Local).AddTicks(7027), 52, new DateTime(2022, 7, 19, 7, 32, 14, 268, DateTimeKind.Local).AddTicks(4526), new DateTime(2021, 4, 11, 11, 49, 12, 505, DateTimeKind.Local).AddTicks(4080), 4, 57, "neque" },
                    { 9, new DateTime(2021, 1, 21, 6, 22, 49, 393, DateTimeKind.Local).AddTicks(1846), 74, new DateTime(2021, 9, 23, 12, 24, 23, 168, DateTimeKind.Local).AddTicks(1073), new DateTime(2020, 10, 18, 20, 41, 38, 932, DateTimeKind.Local).AddTicks(6622), 2, 57, "Est vel assumenda." },
                    { 42, new DateTime(2021, 7, 5, 4, 22, 8, 955, DateTimeKind.Local).AddTicks(4889), 93, new DateTime(2022, 7, 29, 5, 24, 21, 52, DateTimeKind.Local).AddTicks(85), new DateTime(2021, 1, 4, 10, 11, 9, 137, DateTimeKind.Local).AddTicks(5954), 1, 57, "Temporibus error commodi sunt ut consequatur laboriosam at. Eum autem incidunt fugit et ut vero. Impedit mollitia tempore et eligendi ratione. Facilis quae magnam cum iure ut totam. Est nobis dolor reprehenderit totam quisquam porro dolorum. Quod qui earum." },
                    { 49, new DateTime(2021, 1, 11, 7, 35, 54, 75, DateTimeKind.Local).AddTicks(6360), 136, new DateTime(2022, 4, 19, 23, 8, 20, 137, DateTimeKind.Local).AddTicks(6913), new DateTime(2021, 4, 28, 18, 7, 56, 290, DateTimeKind.Local).AddTicks(6441), 5, 57, "Quos repudiandae fugit nulla inventore dolorum. Maiores omnis rerum architecto vel. Laudantium aut dolorum ut ut possimus. Accusamus consequatur eos nobis. Sint consectetur nihil rerum sit qui quo quae dicta perferendis. Quidem et temporibus mollitia illo quam." },
                    { 65, new DateTime(2021, 1, 13, 14, 15, 24, 266, DateTimeKind.Local).AddTicks(5465), 148, new DateTime(2022, 2, 16, 10, 7, 4, 100, DateTimeKind.Local).AddTicks(2085), new DateTime(2021, 6, 25, 20, 41, 9, 75, DateTimeKind.Local).AddTicks(1988), 4, 57, "ad" },
                    { 74, new DateTime(2021, 4, 17, 10, 53, 17, 784, DateTimeKind.Local).AddTicks(8535), 104, new DateTime(2022, 5, 2, 3, 47, 41, 953, DateTimeKind.Local).AddTicks(3264), new DateTime(2021, 7, 12, 19, 53, 6, 739, DateTimeKind.Local).AddTicks(4667), 4, 57, "voluptate" },
                    { 41, new DateTime(2021, 7, 14, 6, 22, 42, 163, DateTimeKind.Local).AddTicks(7280), 9, new DateTime(2021, 9, 25, 20, 42, 4, 549, DateTimeKind.Local).AddTicks(2970), new DateTime(2021, 3, 11, 7, 38, 25, 308, DateTimeKind.Local).AddTicks(705), 2, 46, "Et voluptas corporis nobis labore est accusantium quia praesentium est.\nEsse voluptatum consequuntur libero et dignissimos eveniet tempore harum cum.\nDelectus tenetur eum consequatur voluptatibus.\nDucimus mollitia tenetur est saepe fugiat." },
                    { 60, new DateTime(2020, 11, 20, 17, 42, 47, 540, DateTimeKind.Local).AddTicks(4604), 86, new DateTime(2022, 6, 10, 14, 45, 33, 888, DateTimeKind.Local).AddTicks(8625), new DateTime(2021, 5, 24, 14, 30, 11, 772, DateTimeKind.Local).AddTicks(1163), 3, 4, "expedita" },
                    { 103, new DateTime(2021, 1, 4, 9, 33, 2, 464, DateTimeKind.Local).AddTicks(3763), 28, new DateTime(2022, 1, 5, 13, 33, 48, 238, DateTimeKind.Local).AddTicks(935), new DateTime(2020, 10, 27, 11, 40, 28, 508, DateTimeKind.Local).AddTicks(9282), 2, 4, "eius" },
                    { 133, new DateTime(2021, 5, 5, 7, 6, 5, 478, DateTimeKind.Local).AddTicks(8566), 73, new DateTime(2022, 6, 6, 7, 29, 16, 114, DateTimeKind.Local).AddTicks(4883), new DateTime(2021, 5, 30, 6, 10, 4, 280, DateTimeKind.Local).AddTicks(6332), 1, 4, "Quibusdam eaque voluptatem unde aut quas reprehenderit mollitia sit excepturi.\nImpedit tempore et necessitatibus rerum.\nUt et sed reprehenderit.\nNatus officia nostrum." },
                    { 12, new DateTime(2020, 12, 6, 6, 34, 16, 709, DateTimeKind.Local).AddTicks(8631), 122, new DateTime(2022, 1, 4, 3, 6, 50, 132, DateTimeKind.Local).AddTicks(1094), new DateTime(2020, 9, 24, 8, 33, 55, 524, DateTimeKind.Local).AddTicks(1191), 1, 18, "Molestias sed consequatur eum tenetur expedita quisquam eligendi sit." },
                    { 66, new DateTime(2020, 12, 10, 21, 16, 27, 601, DateTimeKind.Local).AddTicks(2127), 142, new DateTime(2022, 2, 24, 0, 39, 28, 151, DateTimeKind.Local).AddTicks(5292), new DateTime(2020, 9, 21, 4, 53, 34, 307, DateTimeKind.Local).AddTicks(7045), 2, 18, "Numquam dolorem nihil voluptatem. Velit esse et dolorem quaerat enim. Quis aut enim molestiae." },
                    { 67, new DateTime(2021, 5, 27, 7, 35, 16, 109, DateTimeKind.Local).AddTicks(4272), 44, new DateTime(2022, 7, 1, 11, 22, 8, 642, DateTimeKind.Local).AddTicks(1200), new DateTime(2020, 8, 31, 4, 26, 42, 246, DateTimeKind.Local).AddTicks(5507), 2, 18, "Sit voluptas sit sit unde sapiente doloremque tenetur.\nVero a ipsum unde corporis incidunt quo.\nAccusamus aut id ratione quia accusantium quia.\nOdit quo enim." },
                    { 108, new DateTime(2021, 2, 8, 0, 18, 28, 560, DateTimeKind.Local).AddTicks(198), 61, new DateTime(2022, 6, 4, 18, 47, 35, 965, DateTimeKind.Local).AddTicks(8651), new DateTime(2020, 10, 2, 11, 43, 35, 259, DateTimeKind.Local).AddTicks(7480), 2, 18, "Aut quis minima ab labore expedita." },
                    { 31, new DateTime(2020, 11, 13, 3, 42, 56, 694, DateTimeKind.Local).AddTicks(466), 45, new DateTime(2022, 6, 14, 13, 49, 48, 955, DateTimeKind.Local).AddTicks(9897), new DateTime(2020, 10, 17, 6, 32, 16, 234, DateTimeKind.Local).AddTicks(5622), 2, 2, "Quia aspernatur eum numquam ratione." },
                    { 33, new DateTime(2020, 12, 29, 12, 38, 58, 714, DateTimeKind.Local).AddTicks(7646), 64, new DateTime(2022, 5, 13, 15, 31, 10, 155, DateTimeKind.Local).AddTicks(2147), new DateTime(2021, 2, 14, 4, 28, 39, 132, DateTimeKind.Local).AddTicks(2630), 3, 2, "Quia ad labore odio itaque ipsa iusto inventore. Atque dignissimos ut debitis dignissimos dolor quos error dolorem repellendus. Incidunt sint tempore nostrum. Nulla alias est quo nemo officiis eaque fugit quia commodi. Perspiciatis at voluptate. Fugiat sed beatae eum accusamus sapiente commodi illum." },
                    { 72, new DateTime(2021, 7, 17, 23, 27, 32, 465, DateTimeKind.Local).AddTicks(801), 82, new DateTime(2022, 8, 4, 0, 37, 26, 9, DateTimeKind.Local).AddTicks(6701), new DateTime(2020, 11, 4, 12, 50, 51, 152, DateTimeKind.Local).AddTicks(2544), 3, 2, "Vel ullam quia autem et libero est." },
                    { 138, new DateTime(2020, 12, 14, 20, 42, 31, 641, DateTimeKind.Local).AddTicks(3675), 11, new DateTime(2021, 11, 10, 9, 26, 53, 740, DateTimeKind.Local).AddTicks(8539), new DateTime(2021, 7, 27, 18, 25, 7, 176, DateTimeKind.Local).AddTicks(1269), 4, 2, "Amet qui necessitatibus aspernatur excepturi et ut dignissimos architecto totam.\nPorro voluptatum consequatur sed adipisci odit sapiente corrupti rerum.\nEum quae consequatur ut voluptatibus hic aut enim." },
                    { 186, new DateTime(2021, 2, 14, 15, 12, 5, 588, DateTimeKind.Local).AddTicks(1901), 131, new DateTime(2021, 12, 15, 21, 34, 11, 683, DateTimeKind.Local).AddTicks(32), new DateTime(2020, 9, 19, 16, 32, 52, 704, DateTimeKind.Local).AddTicks(3701), 2, 2, "Voluptate nihil est aliquid sed est odit aliquam et quae.\nOfficiis fugiat sint consequatur id eligendi.\nSunt ab consequuntur non nulla est." },
                    { 190, new DateTime(2021, 7, 28, 12, 8, 31, 327, DateTimeKind.Local).AddTicks(8357), 129, new DateTime(2022, 8, 1, 19, 16, 30, 515, DateTimeKind.Local).AddTicks(5428), new DateTime(2020, 8, 30, 5, 13, 31, 417, DateTimeKind.Local).AddTicks(5824), 1, 2, "Quisquam enim tempora voluptas quia illum illo.\nRepellendus labore modi nulla eveniet et laboriosam sint velit enim.\nSit numquam sunt alias qui in.\nVoluptas atque et quas aspernatur odit.\nCumque nihil distinctio eaque corrupti architecto." },
                    { 38, new DateTime(2021, 4, 1, 4, 42, 56, 188, DateTimeKind.Local).AddTicks(3795), 11, new DateTime(2021, 10, 22, 21, 1, 31, 34, DateTimeKind.Local).AddTicks(5726), new DateTime(2021, 2, 15, 16, 26, 23, 203, DateTimeKind.Local).AddTicks(2822), 4, 82, "suscipit" },
                    { 101, new DateTime(2021, 7, 2, 4, 16, 43, 219, DateTimeKind.Local).AddTicks(9326), 8, new DateTime(2022, 1, 28, 2, 40, 8, 971, DateTimeKind.Local).AddTicks(7396), new DateTime(2021, 2, 26, 6, 0, 42, 240, DateTimeKind.Local).AddTicks(6934), 3, 15, "perspiciatis" },
                    { 64, new DateTime(2020, 12, 2, 3, 20, 10, 452, DateTimeKind.Local).AddTicks(7617), 4, new DateTime(2021, 9, 26, 5, 40, 27, 146, DateTimeKind.Local).AddTicks(3641), new DateTime(2020, 12, 19, 10, 39, 8, 561, DateTimeKind.Local).AddTicks(6167), 2, 3, "Debitis odit est architecto repellendus officiis sunt." },
                    { 16, new DateTime(2021, 7, 31, 16, 41, 4, 989, DateTimeKind.Local).AddTicks(4618), 56, new DateTime(2022, 2, 12, 1, 33, 42, 118, DateTimeKind.Local).AddTicks(8987), new DateTime(2021, 6, 10, 15, 30, 41, 84, DateTimeKind.Local).AddTicks(8730), 1, 31, "fuga" },
                    { 100, new DateTime(2020, 10, 18, 11, 51, 32, 709, DateTimeKind.Local).AddTicks(3729), 8, new DateTime(2021, 10, 10, 10, 13, 20, 810, DateTimeKind.Local).AddTicks(5732), new DateTime(2021, 4, 11, 7, 0, 22, 833, DateTimeKind.Local).AddTicks(6960), 2, 31, "Distinctio soluta neque pariatur." },
                    { 170, new DateTime(2020, 8, 26, 4, 39, 0, 45, DateTimeKind.Local).AddTicks(8646), 22, new DateTime(2021, 9, 8, 23, 42, 7, 866, DateTimeKind.Local).AddTicks(7547), new DateTime(2021, 4, 7, 4, 42, 26, 585, DateTimeKind.Local).AddTicks(7644), 5, 31, "nihil" },
                    { 199, new DateTime(2021, 5, 10, 1, 26, 45, 548, DateTimeKind.Local).AddTicks(7972), 50, new DateTime(2022, 7, 14, 20, 33, 15, 998, DateTimeKind.Local).AddTicks(4816), new DateTime(2021, 7, 11, 23, 18, 5, 638, DateTimeKind.Local).AddTicks(9087), 5, 31, "non" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 134, new DateTime(2021, 7, 15, 15, 59, 35, 831, DateTimeKind.Local).AddTicks(4415), 85, new DateTime(2022, 4, 1, 7, 56, 54, 774, DateTimeKind.Local).AddTicks(742), new DateTime(2020, 8, 14, 17, 58, 3, 839, DateTimeKind.Local).AddTicks(5637), 3, 25, "Occaecati amet alias enim dolor nobis eum et tempora et." },
                    { 20, new DateTime(2021, 7, 1, 10, 12, 36, 385, DateTimeKind.Local).AddTicks(3537), 101, new DateTime(2022, 1, 24, 11, 34, 18, 415, DateTimeKind.Local).AddTicks(1378), new DateTime(2020, 9, 3, 3, 32, 44, 923, DateTimeKind.Local).AddTicks(3214), 5, 70, "Est magni quia unde.\nVoluptatem excepturi laborum enim at mollitia ut." },
                    { 98, new DateTime(2021, 6, 13, 16, 2, 29, 803, DateTimeKind.Local).AddTicks(8626), 122, new DateTime(2022, 4, 5, 3, 59, 24, 910, DateTimeKind.Local).AddTicks(5419), new DateTime(2021, 1, 21, 21, 46, 15, 81, DateTimeKind.Local).AddTicks(7022), 5, 70, "sed" },
                    { 104, new DateTime(2021, 4, 25, 16, 57, 40, 811, DateTimeKind.Local).AddTicks(2706), 85, new DateTime(2021, 9, 1, 1, 45, 15, 168, DateTimeKind.Local).AddTicks(6223), new DateTime(2021, 1, 7, 5, 36, 48, 271, DateTimeKind.Local).AddTicks(4641), 2, 70, "Quas qui numquam expedita ratione error dolores in neque." },
                    { 177, new DateTime(2020, 12, 5, 14, 27, 50, 768, DateTimeKind.Local).AddTicks(4027), 68, new DateTime(2022, 5, 31, 20, 28, 4, 585, DateTimeKind.Local).AddTicks(8427), new DateTime(2021, 4, 9, 14, 31, 53, 540, DateTimeKind.Local).AddTicks(3731), 5, 54, "nulla" },
                    { 166, new DateTime(2020, 10, 31, 11, 22, 45, 671, DateTimeKind.Local).AddTicks(2956), 128, new DateTime(2022, 2, 8, 18, 48, 9, 663, DateTimeKind.Local).AddTicks(1528), new DateTime(2021, 6, 5, 4, 43, 48, 636, DateTimeKind.Local).AddTicks(8096), 4, 54, "Aut nihil et.\nQuasi aliquid enim ut deleniti magni neque nisi fugit quos.\nSunt ipsa ut molestiae sunt quia.\nIpsa eos rerum tempora et distinctio deleniti eius autem.\nVelit illum perferendis enim." },
                    { 156, new DateTime(2021, 8, 9, 2, 55, 32, 954, DateTimeKind.Local).AddTicks(2412), 27, new DateTime(2021, 9, 22, 11, 23, 12, 791, DateTimeKind.Local).AddTicks(5448), new DateTime(2020, 10, 11, 8, 49, 45, 105, DateTimeKind.Local).AddTicks(4928), 1, 54, "in" },
                    { 150, new DateTime(2021, 2, 19, 19, 22, 11, 827, DateTimeKind.Local).AddTicks(207), 75, new DateTime(2022, 5, 24, 10, 45, 52, 121, DateTimeKind.Local).AddTicks(6597), new DateTime(2021, 5, 1, 19, 43, 35, 807, DateTimeKind.Local).AddTicks(7076), 1, 54, "Beatae nam quidem quo voluptates autem aut veritatis enim." },
                    { 29, new DateTime(2021, 5, 1, 16, 6, 36, 690, DateTimeKind.Local).AddTicks(2836), 89, new DateTime(2022, 3, 27, 14, 25, 31, 767, DateTimeKind.Local).AddTicks(4377), new DateTime(2021, 5, 27, 12, 31, 20, 270, DateTimeKind.Local).AddTicks(6191), 1, 27, "Animi optio ea quas sed eos soluta quaerat omnis. Ducimus debitis distinctio iste quas tempora aliquid numquam corrupti aperiam. Voluptas rerum et iste labore dicta aut." },
                    { 117, new DateTime(2021, 5, 8, 13, 7, 2, 622, DateTimeKind.Local).AddTicks(1821), 115, new DateTime(2022, 1, 14, 10, 59, 2, 22, DateTimeKind.Local).AddTicks(4416), new DateTime(2021, 7, 30, 6, 43, 2, 607, DateTimeKind.Local).AddTicks(6948), 5, 27, "perferendis" },
                    { 159, new DateTime(2021, 7, 30, 13, 4, 47, 728, DateTimeKind.Local).AddTicks(6711), 131, new DateTime(2021, 10, 25, 19, 8, 45, 504, DateTimeKind.Local).AddTicks(594), new DateTime(2020, 9, 26, 9, 34, 42, 502, DateTimeKind.Local).AddTicks(879), 4, 27, "iusto" },
                    { 144, new DateTime(2021, 7, 6, 0, 17, 59, 624, DateTimeKind.Local).AddTicks(453), 150, new DateTime(2021, 9, 28, 12, 33, 24, 314, DateTimeKind.Local).AddTicks(45), new DateTime(2021, 1, 24, 1, 22, 34, 140, DateTimeKind.Local).AddTicks(7928), 3, 19, "Exercitationem quis dolorem ex rem incidunt." },
                    { 123, new DateTime(2021, 2, 24, 8, 47, 57, 339, DateTimeKind.Local).AddTicks(7198), 113, new DateTime(2021, 12, 11, 5, 28, 31, 15, DateTimeKind.Local).AddTicks(5674), new DateTime(2020, 10, 15, 2, 23, 59, 892, DateTimeKind.Local).AddTicks(7105), 4, 68, "Id aperiam nostrum cupiditate. Quia veritatis ipsa. Eum officiis id repellendus itaque. Laboriosam sed omnis pariatur omnis delectus rerum dolores officiis. Sint non minus blanditiis nihil dolor nesciunt amet dolores. Rerum amet sit ab aliquid tenetur et soluta odit." },
                    { 128, new DateTime(2020, 12, 10, 11, 40, 38, 289, DateTimeKind.Local).AddTicks(5319), 86, new DateTime(2022, 2, 11, 4, 22, 38, 931, DateTimeKind.Local).AddTicks(5202), new DateTime(2021, 1, 25, 21, 54, 6, 468, DateTimeKind.Local).AddTicks(4168), 3, 68, "atque" },
                    { 158, new DateTime(2021, 6, 24, 8, 47, 29, 895, DateTimeKind.Local).AddTicks(1494), 68, new DateTime(2022, 5, 28, 7, 59, 45, 607, DateTimeKind.Local).AddTicks(2879), new DateTime(2021, 4, 7, 6, 5, 38, 357, DateTimeKind.Local).AddTicks(4388), 3, 68, "Quod eligendi aut accusantium accusamus temporibus odit." },
                    { 174, new DateTime(2021, 6, 16, 23, 30, 23, 388, DateTimeKind.Local).AddTicks(3837), 23, new DateTime(2022, 4, 10, 3, 38, 27, 189, DateTimeKind.Local).AddTicks(6189), new DateTime(2021, 7, 13, 15, 51, 32, 805, DateTimeKind.Local).AddTicks(6948), 5, 68, "Labore atque neque amet vel facilis pariatur." },
                    { 181, new DateTime(2020, 12, 28, 8, 58, 39, 957, DateTimeKind.Local).AddTicks(6481), 146, new DateTime(2022, 8, 9, 13, 14, 16, 50, DateTimeKind.Local).AddTicks(9784), new DateTime(2021, 8, 9, 19, 25, 20, 812, DateTimeKind.Local).AddTicks(7409), 4, 68, "sint" },
                    { 200, new DateTime(2021, 5, 25, 15, 51, 35, 555, DateTimeKind.Local).AddTicks(6740), 87, new DateTime(2022, 3, 16, 20, 6, 34, 587, DateTimeKind.Local).AddTicks(9705), new DateTime(2021, 5, 23, 11, 29, 54, 409, DateTimeKind.Local).AddTicks(6520), 5, 68, "Reiciendis ducimus ducimus quas velit ut molestias qui incidunt. Quia dicta repellat. Repellat placeat officiis. Vel culpa rerum harum. Id iste explicabo magnam tempora iure in voluptas sunt. Nesciunt iusto voluptatum aliquam omnis ipsam." },
                    { 131, new DateTime(2021, 2, 17, 1, 11, 4, 364, DateTimeKind.Local).AddTicks(1685), 70, new DateTime(2021, 8, 26, 1, 52, 46, 134, DateTimeKind.Local).AddTicks(3494), new DateTime(2020, 8, 16, 14, 27, 50, 287, DateTimeKind.Local).AddTicks(9531), 4, 22, "voluptas" },
                    { 1, new DateTime(2021, 4, 27, 10, 3, 24, 541, DateTimeKind.Local).AddTicks(1866), 37, new DateTime(2021, 8, 26, 21, 15, 38, 229, DateTimeKind.Local).AddTicks(5352), new DateTime(2020, 12, 15, 18, 34, 39, 969, DateTimeKind.Local).AddTicks(3188), 5, 12, "Quam eos eveniet aut quos. Deleniti rerum blanditiis veniam occaecati eaque dignissimos eos. Odit earum sit sapiente nostrum vel. Quos magni est cum perspiciatis. Aspernatur nemo eligendi molestiae modi nisi et accusamus quia odio." },
                    { 35, new DateTime(2020, 10, 2, 15, 21, 2, 200, DateTimeKind.Local).AddTicks(6532), 18, new DateTime(2021, 9, 24, 8, 33, 6, 358, DateTimeKind.Local).AddTicks(9924), new DateTime(2020, 10, 10, 1, 19, 52, 677, DateTimeKind.Local).AddTicks(9222), 2, 12, "Quae ea accusantium odio nostrum quam doloremque deleniti sit. Modi omnis qui aut perspiciatis facere nihil excepturi mollitia ea. Optio consequatur eos voluptate est. Quia distinctio id omnis perspiciatis ipsa. Voluptatibus non reprehenderit eius ipsam non quam laborum." },
                    { 50, new DateTime(2020, 11, 28, 11, 51, 58, 311, DateTimeKind.Local).AddTicks(7032), 67, new DateTime(2022, 1, 28, 15, 50, 10, 839, DateTimeKind.Local).AddTicks(6217), new DateTime(2020, 8, 16, 20, 30, 19, 953, DateTimeKind.Local).AddTicks(4437), 1, 12, "Nemo incidunt error similique.\nOmnis et pariatur.\nEt hic aut provident.\nLabore sit qui qui." },
                    { 115, new DateTime(2021, 5, 25, 9, 58, 42, 540, DateTimeKind.Local).AddTicks(4558), 129, new DateTime(2022, 4, 6, 14, 2, 6, 488, DateTimeKind.Local).AddTicks(1291), new DateTime(2020, 9, 18, 3, 48, 10, 914, DateTimeKind.Local).AddTicks(6237), 4, 12, "ducimus" },
                    { 46, new DateTime(2021, 2, 10, 6, 8, 5, 926, DateTimeKind.Local).AddTicks(7083), 42, new DateTime(2022, 1, 22, 1, 56, 30, 192, DateTimeKind.Local).AddTicks(7733), new DateTime(2021, 7, 19, 19, 10, 58, 716, DateTimeKind.Local).AddTicks(856), 3, 13, "Sint vitae ut fuga ad." },
                    { 62, new DateTime(2021, 8, 2, 10, 28, 36, 851, DateTimeKind.Local).AddTicks(5647), 80, new DateTime(2022, 1, 24, 13, 31, 23, 486, DateTimeKind.Local).AddTicks(3162), new DateTime(2021, 3, 23, 9, 18, 29, 43, DateTimeKind.Local).AddTicks(7305), 1, 13, "Voluptates voluptatem magnam expedita occaecati aut non tempore." },
                    { 127, new DateTime(2021, 3, 24, 2, 16, 12, 340, DateTimeKind.Local).AddTicks(3065), 81, new DateTime(2021, 10, 14, 8, 11, 34, 868, DateTimeKind.Local).AddTicks(4792), new DateTime(2020, 9, 11, 9, 4, 20, 119, DateTimeKind.Local).AddTicks(5066), 1, 13, "in" },
                    { 188, new DateTime(2021, 1, 6, 6, 25, 29, 797, DateTimeKind.Local).AddTicks(1150), 97, new DateTime(2021, 9, 19, 0, 31, 18, 639, DateTimeKind.Local).AddTicks(9155), new DateTime(2021, 7, 3, 7, 0, 2, 0, DateTimeKind.Local).AddTicks(2817), 2, 13, "harum" },
                    { 5, new DateTime(2020, 12, 5, 4, 49, 55, 291, DateTimeKind.Local).AddTicks(5197), 46, new DateTime(2022, 2, 10, 2, 44, 55, 770, DateTimeKind.Local).AddTicks(1783), new DateTime(2021, 2, 16, 6, 7, 6, 509, DateTimeKind.Local).AddTicks(1727), 5, 54, "Harum animi sed pariatur aliquam est ea blanditiis molestiae. Dolor eligendi vero ipsum sit repellat eos. Libero placeat nemo incidunt suscipit asperiores. Sint dolorem consectetur optio velit cum est magni et qui." },
                    { 19, new DateTime(2020, 8, 15, 18, 56, 42, 740, DateTimeKind.Local).AddTicks(2294), 34, new DateTime(2022, 4, 25, 23, 11, 46, 623, DateTimeKind.Local).AddTicks(3950), new DateTime(2021, 6, 4, 2, 25, 5, 809, DateTimeKind.Local).AddTicks(6096), 2, 54, "Voluptatem iusto repudiandae ab repudiandae in tenetur culpa quasi.\nHarum aliquid quia quis illo officia dolores adipisci.\nEt sint aut.\nQuo quis saepe molestiae accusantium." },
                    { 56, new DateTime(2021, 6, 29, 21, 8, 39, 556, DateTimeKind.Local).AddTicks(7649), 74, new DateTime(2022, 2, 23, 13, 54, 37, 964, DateTimeKind.Local).AddTicks(6341), new DateTime(2021, 1, 25, 12, 19, 0, 694, DateTimeKind.Local).AddTicks(9246), 1, 54, "Vel eum pariatur eaque sint. Asperiores eveniet dolor reiciendis doloribus modi. Ipsam qui ad doloremque repellendus voluptatem cumque in nostrum." },
                    { 28, new DateTime(2021, 7, 26, 0, 56, 43, 907, DateTimeKind.Local).AddTicks(1972), 146, new DateTime(2022, 4, 6, 8, 51, 4, 712, DateTimeKind.Local).AddTicks(848), new DateTime(2020, 11, 2, 19, 26, 23, 683, DateTimeKind.Local).AddTicks(3745), 1, 12, "Sed veniam eos fuga dolore vel. Consequatur molestiae sint nihil impedit inventore ipsam ratione. Et quas qui sequi dolorum reiciendis." },
                    { 176, new DateTime(2020, 11, 29, 14, 4, 9, 663, DateTimeKind.Local).AddTicks(1248), 105, new DateTime(2022, 4, 1, 18, 39, 40, 535, DateTimeKind.Local).AddTicks(86), new DateTime(2020, 8, 25, 18, 40, 51, 657, DateTimeKind.Local).AddTicks(8563), 3, 22, "Ut laboriosam iste." }
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
