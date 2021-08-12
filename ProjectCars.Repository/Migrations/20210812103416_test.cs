using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectCars.Repository.Migrations
{
    public partial class test : Migration
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
                    { 1, "Virgin Islands, British" },
                    { 117, "Mongolia" },
                    { 116, "Croatia" },
                    { 115, "Australia" },
                    { 114, "British Indian Ocean Territory (Chagos Archipelago)" },
                    { 113, "Russian Federation" },
                    { 111, "Eritrea" },
                    { 110, "Anguilla" },
                    { 108, "Romania" },
                    { 107, "Togo" },
                    { 104, "Christmas Island" },
                    { 102, "Burkina Faso" },
                    { 101, "Zambia" },
                    { 99, "Democratic People's Republic of Korea" },
                    { 97, "Ethiopia" },
                    { 118, "Macedonia" },
                    { 96, "Cyprus" },
                    { 94, "Oman" },
                    { 93, "Dominican Republic" },
                    { 92, "Brunei Darussalam" },
                    { 91, "Mali" },
                    { 90, "Swaziland" },
                    { 89, "Guinea" },
                    { 88, "Tajikistan" },
                    { 86, "San Marino" },
                    { 85, "Niger" },
                    { 84, "Estonia" },
                    { 83, "Bhutan" },
                    { 80, "New Caledonia" },
                    { 79, "Trinidad and Tobago" },
                    { 78, "Taiwan" },
                    { 95, "Djibouti" },
                    { 76, "Ghana" },
                    { 119, "Liberia" },
                    { 121, "Norway" },
                    { 200, "Singapore" },
                    { 197, "Syrian Arab Republic" },
                    { 195, "Cook Islands" },
                    { 192, "Czech Republic" },
                    { 189, "Marshall Islands" },
                    { 188, "Dominica" },
                    { 187, "Bouvet Island (Bouvetoya)" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 185, "Saint Pierre and Miquelon" },
                    { 183, "Solomon Islands" },
                    { 177, "Tonga" },
                    { 174, "Sweden" },
                    { 173, "Honduras" },
                    { 162, "Kazakhstan" },
                    { 161, "Italy" },
                    { 120, "French Southern Territories" },
                    { 159, "Malaysia" },
                    { 152, "Saint Kitts and Nevis" },
                    { 150, "Andorra" },
                    { 148, "Brazil" },
                    { 141, "Thailand" },
                    { 138, "Turks and Caicos Islands" },
                    { 137, "Belarus" },
                    { 133, "India" },
                    { 132, "Latvia" },
                    { 130, "Iceland" },
                    { 129, "Vanuatu" },
                    { 128, "Japan" },
                    { 127, "Micronesia" },
                    { 126, "Cape Verde" },
                    { 122, "South Georgia and the South Sandwich Islands" },
                    { 153, "Guinea-Bissau" },
                    { 75, "Netherlands Antilles" },
                    { 82, "Central African Republic" },
                    { 73, "Botswana" },
                    { 31, "Sao Tome and Principe" },
                    { 30, "Kyrgyz Republic" },
                    { 74, "Congo" },
                    { 28, "Kuwait" },
                    { 27, "Grenada" },
                    { 26, "Germany" },
                    { 25, "Greece" },
                    { 24, "United States of America" },
                    { 23, "Ireland" },
                    { 22, "Guernsey" },
                    { 21, "Hong Kong" },
                    { 20, "Maldives" },
                    { 19, "Slovenia" },
                    { 18, "Sudan" },
                    { 32, "French Polynesia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 17, "Somalia" },
                    { 15, "Jordan" },
                    { 14, "Martinique" },
                    { 13, "Tokelau" },
                    { 12, "Cameroon" },
                    { 11, "Greenland" },
                    { 10, "Switzerland" },
                    { 9, "Nepal" },
                    { 8, "Lao People's Democratic Republic" },
                    { 7, "Cayman Islands" },
                    { 6, "Qatar" },
                    { 5, "Heard Island and McDonald Islands" },
                    { 4, "Belize" },
                    { 3, "Monaco" },
                    { 2, "Bulgaria" },
                    { 16, "Austria" },
                    { 33, "Jersey" },
                    { 29, "Papua New Guinea" },
                    { 35, "Republic of Korea" },
                    { 71, "Finland" },
                    { 70, "Colombia" },
                    { 67, "Pitcairn Islands" },
                    { 66, "Antigua and Barbuda" },
                    { 65, "Belgium" },
                    { 64, "Cambodia" },
                    { 63, "Senegal" },
                    { 61, "Holy See (Vatican City State)" },
                    { 59, "Saint Lucia" },
                    { 34, "Portugal" },
                    { 56, "Namibia" },
                    { 55, "Guam" },
                    { 54, "Mayotte" },
                    { 53, "Ukraine" },
                    { 52, "Albania" },
                    { 58, "New Zealand" },
                    { 49, "Guyana" },
                    { 36, "Equatorial Guinea" },
                    { 51, "Spain" },
                    { 38, "Afghanistan" },
                    { 39, "Reunion" },
                    { 40, "Nauru" },
                    { 41, "Turkey" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 37, "Saint Vincent and the Grenadines" },
                    { 43, "Algeria" },
                    { 44, "Malta" },
                    { 45, "Armenia" },
                    { 46, "Philippines" },
                    { 47, "Gambia" },
                    { 48, "China" },
                    { 42, "Bahamas" }
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
                    { 68, 1, "New Arnold" },
                    { 245, 99, "Yvonneland" },
                    { 194, 99, "North Davinborough" },
                    { 177, 99, "South Reinaport" },
                    { 4, 96, "New Constanceshire" },
                    { 279, 95, "Port Greysonland" },
                    { 231, 95, "Lake Edgar" },
                    { 103, 94, "North Estellchester" },
                    { 101, 94, "New Esta" },
                    { 82, 94, "Schmelerton" },
                    { 31, 94, "Port Darius" },
                    { 268, 93, "Harrisport" },
                    { 66, 93, "New Zellaton" },
                    { 269, 92, "Herminiamouth" },
                    { 242, 91, "Marionport" },
                    { 246, 90, "Lockmanville" },
                    { 142, 90, "Lornastad" },
                    { 125, 90, "Lake Jared" },
                    { 79, 101, "Vonshire" },
                    { 121, 101, "Lavernaville" },
                    { 183, 101, "Carissaland" },
                    { 188, 101, "Farrellport" },
                    { 78, 114, "Boyershire" },
                    { 62, 113, "Strackebury" },
                    { 291, 111, "Lake Javierstad" },
                    { 234, 111, "Kuvalisstad" },
                    { 98, 111, "New Torranceborough" },
                    { 20, 110, "North Soledadbury" },
                    { 273, 108, "Kiraside" },
                    { 12, 108, "Lake Allenstad" },
                    { 52, 90, "Duanemouth" },
                    { 244, 107, "Stefanstad" },
                    { 130, 107, "Leuschkeberg" },
                    { 42, 107, "New Aileen" },
                    { 8, 107, "South Berthafort" },
                    { 263, 104, "East Noemiport" },
                    { 192, 102, "Port Elisa" },
                    { 149, 102, "Lake Hugh" },
                    { 127, 102, "East Tomasshire" },
                    { 5, 102, "Sanfordfurt" },
                    { 136, 107, "Brownchester" },
                    { 37, 90, "Boyerfort" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 247, 89, "Freddiechester" },
                    { 83, 89, "Port Katlyn" },
                    { 60, 80, "North Cecelia" },
                    { 55, 80, "Lake Morganberg" },
                    { 95, 76, "Grantmouth" },
                    { 57, 76, "Lake Jonatanburgh" },
                    { 148, 75, "South Ettie" },
                    { 56, 75, "Maudiefurt" },
                    { 2, 75, "Wintheiserborough" },
                    { 203, 74, "Vincemouth" },
                    { 290, 80, "West Isai" },
                    { 186, 74, "Olsontown" },
                    { 129, 74, "Spinkafort" },
                    { 123, 74, "North Felix" },
                    { 293, 73, "Haydenland" },
                    { 89, 73, "West Candelariochester" },
                    { 143, 71, "Florinebury" },
                    { 160, 70, "Lelabury" },
                    { 272, 67, "Rahsaanhaven" },
                    { 260, 67, "Padbergtown" },
                    { 181, 74, "Hilllland" },
                    { 184, 115, "Lilianastad" },
                    { 219, 82, "South Efrain" },
                    { 240, 82, "Lake Adolfoberg" },
                    { 216, 88, "Port Noreneside" },
                    { 159, 88, "Rueckertown" },
                    { 107, 88, "Doylebury" },
                    { 36, 88, "New Mabelleshire" },
                    { 204, 86, "Fishershire" },
                    { 166, 86, "Kaneburgh" },
                    { 115, 86, "West Sylvia" },
                    { 299, 85, "Judgehaven" },
                    { 232, 82, "North Viviane" },
                    { 63, 85, "Port Noble" },
                    { 236, 84, "Port Ara" },
                    { 111, 84, "Ankundingshire" },
                    { 100, 84, "Kemmerchester" },
                    { 39, 84, "South Tatumhaven" },
                    { 146, 83, "East Bailey" },
                    { 110, 83, "Thielchester" },
                    { 87, 83, "North Lacey" },
                    { 277, 82, "North Kristofer" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 21, 85, "Vincenzoville" },
                    { 15, 116, "Croninmouth" },
                    { 17, 116, "Lake Weston" },
                    { 187, 116, "East Einar" },
                    { 49, 183, "Zemlakfort" },
                    { 243, 177, "East Claud" },
                    { 214, 177, "Rennerfort" },
                    { 169, 177, "Edmundborough" },
                    { 18, 177, "New Amyafort" },
                    { 266, 174, "Pfefferbury" },
                    { 152, 174, "Reynoldston" },
                    { 114, 174, "Port Lisa" },
                    { 132, 183, "Leuschkeport" },
                    { 158, 162, "West Reyville" },
                    { 220, 161, "Klockomouth" },
                    { 253, 159, "West Otto" },
                    { 224, 159, "West Zetta" },
                    { 23, 152, "South Violetfurt" },
                    { 144, 150, "Simonisborough" },
                    { 223, 148, "Croninchester" },
                    { 73, 148, "East Aryannaberg" },
                    { 249, 141, "South Houstonbury" },
                    { 6, 162, "West Adeliastad" },
                    { 180, 141, "Lake Bennettport" },
                    { 174, 185, "Coryshire" },
                    { 84, 187, "Port Carmelohaven" },
                    { 105, 200, "Framitown" },
                    { 81, 200, "Hettingerview" },
                    { 34, 200, "Hettingerfurt" },
                    { 182, 197, "Blandaborough" },
                    { 7, 197, "East Madisyn" },
                    { 199, 195, "West Britneytown" },
                    { 164, 195, "North Sherwoodstad" },
                    { 120, 195, "South Britney" },
                    { 206, 185, "Orashire" },
                    { 30, 195, "Grimesshire" },
                    { 235, 192, "Rohanbury" },
                    { 250, 189, "Port Madilyn" },
                    { 162, 189, "Ricefort" },
                    { 153, 189, "Port Wendystad" },
                    { 239, 188, "Collinsside" },
                    { 133, 188, "McKenziemouth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 71, 188, "Albertview" },
                    { 11, 188, "New Almouth" },
                    { 255, 192, "Leolabury" },
                    { 258, 67, "Lake Floridaton" },
                    { 163, 141, "East Marcia" },
                    { 155, 138, "North Aubrey" },
                    { 271, 126, "Lavernmouth" },
                    { 135, 122, "Maggioland" },
                    { 122, 122, "New Paula" },
                    { 53, 122, "Josefaberg" },
                    { 259, 121, "Gaylehaven" },
                    { 251, 121, "New Hillard" },
                    { 196, 121, "New Jazlyn" },
                    { 96, 121, "Lake Fayeport" },
                    { 300, 126, "East Remington" },
                    { 43, 121, "Barrowsshire" },
                    { 147, 119, "Loniemouth" },
                    { 85, 119, "Kiraport" },
                    { 190, 118, "South Joelle" },
                    { 104, 118, "New Jeramieburgh" },
                    { 201, 117, "Medhurstchester" },
                    { 22, 117, "North Paytonmouth" },
                    { 248, 116, "Lewisland" },
                    { 208, 116, "Pearlinemouth" },
                    { 165, 120, "Johnathanton" },
                    { 29, 141, "Port Maximusfurt" },
                    { 108, 127, "Luzland" },
                    { 9, 128, "Lake Garfieldton" },
                    { 112, 138, "North Guy" },
                    { 14, 138, "Pagacland" },
                    { 3, 138, "Emileburgh" },
                    { 139, 137, "Port Neilview" },
                    { 51, 137, "Swaniawskishire" },
                    { 32, 137, "West Madalyn" },
                    { 238, 133, "Prohaskashire" },
                    { 116, 133, "New Kurt" },
                    { 267, 127, "South Jett" },
                    { 46, 133, "South Remington" },
                    { 281, 130, "West Halie" },
                    { 168, 130, "South Delaney" },
                    { 131, 130, "Bahringermouth" },
                    { 50, 130, "Matildeport" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 88, 129, "New Antwon" },
                    { 13, 129, "North Desireestad" },
                    { 285, 128, "Gislasonside" },
                    { 77, 128, "Marisatown" },
                    { 296, 130, "Port Ali" },
                    { 257, 67, "Lake Colton" },
                    { 275, 96, "Janniemouth" },
                    { 97, 67, "New Adaland" },
                    { 134, 28, "Eldonberg" },
                    { 207, 27, "Dibbertstad" },
                    { 70, 27, "Port Autumnstad" },
                    { 40, 27, "Amberside" },
                    { 284, 26, "Lake Geovannystad" },
                    { 241, 26, "Kovacekberg" },
                    { 198, 26, "Schuppeburgh" },
                    { 138, 26, "Rocioport" },
                    { 93, 26, "Andychester" },
                    { 59, 26, "Jaylanshire" },
                    { 64, 25, "West Easton" },
                    { 35, 25, "Vonborough" },
                    { 26, 25, "Lake Shanieton" },
                    { 61, 24, "Botsfordport" },
                    { 297, 23, "West Leathaburgh" },
                    { 157, 29, "West Luluhaven" },
                    { 286, 23, "Fisherborough" },
                    { 54, 31, "Port Bransonbury" },
                    { 10, 32, "Monahanport" },
                    { 126, 38, "Jermainbury" },
                    { 254, 37, "Marcellusbury" },
                    { 24, 37, "Bergnaummouth" },
                    { 298, 36, "Lake Jason" },
                    { 230, 36, "Port Emilestad" },
                    { 74, 36, "Joshuaton" },
                    { 48, 36, "West Elda" },
                    { 294, 34, "Cecileport" },
                    { 222, 34, "Lake Jefffort" },
                    { 45, 34, "West Donnellfort" },
                    { 33, 34, "South Lester" },
                    { 170, 33, "South Taniaton" },
                    { 128, 33, "Izabellatown" },
                    { 44, 33, "Rogahnborough" },
                    { 150, 32, "Gorczanymouth" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 215, 31, "Adamsville" },
                    { 276, 23, "Lake Clarissa" },
                    { 195, 23, "Lake Ottofurt" },
                    { 154, 22, "Lake Jonathonside" },
                    { 109, 9, "East Omashire" },
                    { 262, 8, "Larkinmouth" },
                    { 141, 8, "New Alfredachester" },
                    { 72, 8, "East Pinkie" },
                    { 41, 7, "Rosetown" },
                    { 27, 6, "Johnsonmouth" },
                    { 280, 5, "South Marilyne" },
                    { 106, 4, "West Zena" },
                    { 289, 3, "Lake Felix" },
                    { 209, 3, "New Silaston" },
                    { 161, 3, "Kaleyberg" },
                    { 67, 3, "Summerberg" },
                    { 229, 1, "Zakaryberg" },
                    { 178, 1, "Beerstad" },
                    { 119, 1, "West Enrique" },
                    { 212, 9, "Blandabury" },
                    { 228, 9, "Lake Leatha" },
                    { 270, 9, "South Hallie" },
                    { 193, 10, "Port Jeromy" },
                    { 99, 22, "South Mattieside" },
                    { 16, 22, "Port Winfield" },
                    { 288, 21, "Stammstad" },
                    { 205, 21, "Lake Giovaniside" },
                    { 156, 21, "North Alanaside" },
                    { 47, 20, "Selenamouth" },
                    { 151, 18, "Anyaberg" },
                    { 75, 39, "South Jamel" },
                    { 137, 18, "East Scot" },
                    { 227, 67, "West Johnny" },
                    { 92, 16, "Solonmouth" },
                    { 292, 14, "Mozelltown" },
                    { 217, 14, "South Carterton" },
                    { 86, 14, "East Amparo" },
                    { 282, 13, "New Catharine" },
                    { 237, 13, "Eugeneview" },
                    { 256, 17, "Walterchester" },
                    { 28, 40, "Haleyfurt" },
                    { 179, 17, "Thaddeusburgh" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 197, 66, "Leuschkeburgh" },
                    { 69, 45, "Lazaroland" },
                    { 124, 45, "Wolfview" },
                    { 118, 46, "Celiaborough" },
                    { 171, 46, "Doyleland" },
                    { 283, 61, "New Vitahaven" },
                    { 274, 61, "Port Destineefurt" },
                    { 145, 47, "New Major" },
                    { 185, 47, "West Alisha" },
                    { 117, 48, "Kozeychester" },
                    { 211, 48, "West Magdalenstad" },
                    { 19, 61, "Kuphalburgh" },
                    { 176, 59, "Willyfurt" },
                    { 175, 58, "West Nyasia" },
                    { 172, 63, "Stoltenberghaven" },
                    { 90, 58, "Sheastad" },
                    { 261, 49, "West Destin" },
                    { 278, 49, "Rahsaanfurt" },
                    { 25, 51, "Veldaton" },
                    { 76, 51, "Casperport" },
                    { 295, 52, "Elveramouth" },
                    { 113, 53, "South Jamarport" },
                    { 265, 65, "North Ollieton" },
                    { 38, 58, "Adamsfort" },
                    { 94, 54, "Meaghanville" },
                    { 226, 56, "Lake Gabrielle" },
                    { 225, 55, "Corwinmouth" },
                    { 91, 56, "Wellingtonmouth" },
                    { 210, 56, "Effiefort" },
                    { 202, 49, "Zboncakstad" },
                    { 1, 64, "South Louie" },
                    { 58, 46, "Othoshire" },
                    { 221, 44, "Port Fabianton" },
                    { 200, 41, "Port Angusview" },
                    { 287, 41, "Lake Kayleighfort" },
                    { 140, 65, "East Liza" },
                    { 167, 40, "Vitobury" },
                    { 65, 42, "East Winstonton" },
                    { 189, 43, "Schulistton" },
                    { 213, 43, "New Jermaineland" },
                    { 264, 43, "South Addisonburgh" },
                    { 173, 44, "Aylaton" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 218, 44, "Lake Leeview" },
                    { 102, 40, "Harrisstad" },
                    { 252, 40, "Handberg" },
                    { 191, 65, "New Eugeneside" },
                    { 233, 44, "Luettgenbury" },
                    { 80, 64, "Dinochester" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 21, 2434, 1, 419 },
                    { 48, 2827, 2, 159 },
                    { 44, 2693, 2, 510 },
                    { 13, 2769, 2, 440 },
                    { 18, 2653, 2, 336 },
                    { 1, 2112, 1, 448 },
                    { 40, 1211, 2, 409 },
                    { 37, 2315, 2, 603 },
                    { 2, 1750, 1, 281 },
                    { 31, 2088, 2, 207 },
                    { 20, 2410, 2, 210 },
                    { 29, 1269, 1, 203 },
                    { 22, 2301, 2, 454 },
                    { 12, 2430, 2, 616 },
                    { 11, 2998, 1, 370 },
                    { 23, 2486, 2, 373 },
                    { 27, 2003, 2, 306 },
                    { 72, 2097, 1, 221 },
                    { 8, 1958, 2, 613 },
                    { 34, 1997, 1, 162 },
                    { 73, 1674, 1, 491 },
                    { 65, 2097, 1, 350 },
                    { 74, 1490, 1, 222 },
                    { 80, 2440, 1, 369 },
                    { 83, 1025, 1, 100 },
                    { 84, 2995, 1, 365 },
                    { 85, 1129, 1, 146 },
                    { 87, 1150, 1, 374 },
                    { 56, 2969, 1, 391 },
                    { 9, 1381, 2, 654 },
                    { 50, 2083, 2, 608 },
                    { 90, 2845, 1, 534 },
                    { 55, 1370, 1, 587 },
                    { 53, 1046, 1, 597 },
                    { 52, 1690, 1, 145 },
                    { 45, 2479, 1, 101 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 91, 1627, 1, 471 },
                    { 41, 1844, 1, 692 },
                    { 69, 1170, 1, 363 },
                    { 36, 1306, 1, 359 },
                    { 89, 2573, 1, 481 },
                    { 57, 2198, 2, 666 },
                    { 24, 2054, 3, 635 },
                    { 76, 2257, 2, 262 },
                    { 10, 2348, 4, 422 },
                    { 14, 1024, 4, 320 },
                    { 15, 2677, 4, 312 },
                    { 17, 2442, 4, 422 },
                    { 28, 2687, 4, 672 },
                    { 30, 2515, 4, 288 },
                    { 32, 2849, 4, 277 },
                    { 33, 2762, 4, 212 },
                    { 38, 1446, 4, 222 },
                    { 43, 1576, 4, 382 },
                    { 46, 1272, 4, 422 },
                    { 49, 1689, 4, 292 },
                    { 54, 2873, 4, 620 },
                    { 59, 2353, 4, 405 },
                    { 62, 2068, 4, 453 },
                    { 63, 2560, 4, 336 },
                    { 67, 1645, 4, 316 },
                    { 68, 2551, 4, 666 },
                    { 75, 1547, 4, 386 },
                    { 77, 1836, 4, 639 },
                    { 98, 1677, 4, 487 },
                    { 78, 2195, 4, 304 },
                    { 79, 2652, 4, 676 },
                    { 82, 1717, 4, 635 },
                    { 88, 2371, 4, 532 },
                    { 5, 1341, 4, 171 },
                    { 66, 2558, 2, 537 },
                    { 4, 2178, 4, 657 },
                    { 92, 1144, 3, 315 },
                    { 86, 2493, 2, 401 },
                    { 94, 1149, 2, 469 },
                    { 95, 1239, 2, 352 },
                    { 96, 2410, 2, 419 },
                    { 97, 2231, 2, 147 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Power" },
                values: new object[,]
                {
                    { 100, 2909, 2, 444 },
                    { 3, 1411, 3, 486 },
                    { 6, 2550, 3, 241 },
                    { 7, 1529, 3, 129 },
                    { 16, 2694, 3, 472 },
                    { 19, 1801, 3, 146 },
                    { 25, 1788, 3, 251 },
                    { 26, 2127, 3, 484 },
                    { 35, 1613, 3, 216 },
                    { 39, 1156, 3, 624 },
                    { 42, 1956, 3, 690 },
                    { 47, 1705, 3, 689 },
                    { 51, 1514, 3, 565 },
                    { 58, 2638, 3, 552 },
                    { 60, 2328, 3, 180 },
                    { 61, 2469, 3, 548 },
                    { 64, 1244, 3, 167 },
                    { 70, 1275, 3, 501 },
                    { 71, 1463, 3, 316 },
                    { 81, 2774, 3, 485 },
                    { 93, 1729, 3, 650 },
                    { 99, 2963, 4, 220 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 95, 73, "Leffler Inc" },
                    { 36, 2, "Stokes - Zulauf" },
                    { 16, 27, "Bahringer, Abshire and Klein" },
                    { 55, 116, "Kshlerin, Shields and Ledner" },
                    { 56, 26, "Sanford - Fritsch" },
                    { 64, 118, "Labadie, Crona and Cassin" },
                    { 74, 119, "Murphy LLC" },
                    { 76, 119, "Cormier, Hermiston and Lind" },
                    { 50, 25, "Considine Inc" },
                    { 44, 25, "Grant - Bosco" },
                    { 32, 25, "Hyatt - Kris" },
                    { 15, 25, "Zboncak - Boehm" },
                    { 88, 85, "Kub and Sons" },
                    { 62, 48, "Labadie - Watsica" },
                    { 3, 51, "Nicolas - Balistreri" },
                    { 40, 83, "Cummerata, Beatty and O'Kon" },
                    { 67, 52, "Hane, VonRueden and Wisozk" },
                    { 86, 21, "Erdman - Cummerata" },
                    { 70, 53, "Brekke Inc" },
                    { 93, 53, "Walter Group" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 46, 130, "Nitzsche - Heidenreich" },
                    { 49, 20, "Langosh LLC" },
                    { 23, 20, "Bechtelar, Kerluke and Schaefer" },
                    { 19, 27, "Jacobi - Strosin" },
                    { 13, 133, "Crooks, Green and Russel" },
                    { 83, 27, "Treutel, Farrell and Murray" },
                    { 77, 28, "Torphy - Koss" },
                    { 14, 97, "Halvorson - Huels" },
                    { 42, 39, "Heathcote, Welch and Vandervort" },
                    { 28, 39, "Walter Inc" },
                    { 73, 99, "Sporer and Sons" },
                    { 97, 95, "Moen, Connelly and Marvin" },
                    { 54, 101, "Stamm, Block and Ebert" },
                    { 92, 94, "Dare, Haag and Jakubowski" },
                    { 20, 35, "Gibson - Barton" },
                    { 11, 35, "Vandervort, Hamill and Larson" },
                    { 80, 43, "Abshire Group" },
                    { 98, 108, "Weissnat - Turner" },
                    { 79, 90, "Walter - Runte" },
                    { 75, 31, "Mohr, Kemmer and Kuhn" },
                    { 1, 111, "Smitham Group" },
                    { 6, 113, "Blick and Sons" },
                    { 59, 113, "Torphy - Roberts" },
                    { 35, 44, "Ward, Murphy and Schiller" },
                    { 52, 114, "Welch - Hermiston" },
                    { 61, 44, "Hodkiewicz - Mosciski" },
                    { 27, 115, "Ledner, Kilback and Collier" },
                    { 43, 115, "Marquardt LLC" },
                    { 12, 89, "Cummerata LLC" },
                    { 81, 1, "Heaney, Halvorson and Herzog" },
                    { 60, 18, "Hessel Group" },
                    { 89, 55, "Armstrong Inc" },
                    { 51, 183, "Price - Weimann" },
                    { 45, 7, "Zboncak - Corwin" },
                    { 29, 7, "Adams - Jast" },
                    { 58, 185, "Strosin Inc" },
                    { 39, 97, "Braun - Jakubowski" },
                    { 100, 187, "Okuneva - Hudson" },
                    { 90, 5, "Murphy - Bruen" },
                    { 41, 5, "McKenzie, Kuhn and Kautzer" },
                    { 37, 5, "Schmeler and Sons" },
                    { 25, 188, "Treutel Group" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 48, 71, "McClure, Collins and Ryan" },
                    { 85, 3, "Bednar Group" },
                    { 68, 189, "Ritchie - Moen" },
                    { 17, 3, "Mraz LLC" },
                    { 4, 71, "Willms, O'Reilly and Schuster" },
                    { 5, 192, "Lebsack, Robel and Reichel" },
                    { 21, 64, "Rice - Orn" },
                    { 78, 70, "Nicolas, Kemmer and Terry" },
                    { 87, 2, "Simonis Inc" },
                    { 2, 195, "Sauer Inc" },
                    { 71, 195, "Larson - Heathcote" },
                    { 7, 61, "Klocko - Kovacek" },
                    { 9, 18, "Emard, Mueller and Hyatt" },
                    { 26, 177, "Hessel, Erdman and Reinger" },
                    { 66, 162, "Harvey, Zboncak and Rau" },
                    { 84, 17, "Hickle - Witting" },
                    { 57, 138, "Lang, Bauch and McDermott" },
                    { 94, 138, "Ratke, Boyer and Dicki" },
                    { 69, 16, "Murray - Streich" },
                    { 72, 79, "Rempel, Morissette and Windler" },
                    { 34, 15, "Fahey Inc" },
                    { 18, 15, "Walter LLC" },
                    { 31, 14, "Hammes and Sons" },
                    { 10, 78, "Reichert, Kemmer and Baumbach" },
                    { 33, 148, "Hayes LLC" },
                    { 53, 148, "Kirlin, O'Reilly and Jacobi" },
                    { 38, 76, "Price Inc" },
                    { 65, 150, "Effertz - Wehner" },
                    { 30, 152, "Emmerich, West and Hettinger" },
                    { 63, 153, "Moen - Herman" },
                    { 82, 75, "Hermann Inc" },
                    { 47, 12, "Okuneva and Sons" },
                    { 8, 161, "Spinka - Mills" },
                    { 24, 161, "Langosh Group" },
                    { 96, 10, "Johns - Stark" },
                    { 22, 10, "Barton, Schulist and Kling" },
                    { 99, 9, "Pfannerstill, Leannon and Hahn" },
                    { 91, 97, "Smitham LLC" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 98, 99, 71, "quia" },
                    { 32, 18, 79, "doloremque" },
                    { 35, 18, 84, "maiores" },
                    { 57, 18, 59, "doloribus" },
                    { 92, 20, 1, "ea" },
                    { 44, 23, 93, "beatae" },
                    { 50, 27, 84, "nobis" },
                    { 79, 9, 68, "autem" },
                    { 30, 37, 18, "at" },
                    { 23, 66, 55, "et" },
                    { 78, 66, 88, "suscipit" },
                    { 86, 76, 43, "dolor" },
                    { 76, 86, 39, "sint" },
                    { 91, 86, 39, "ut" },
                    { 40, 94, 4, "saepe" },
                    { 18, 50, 64, "fuga" },
                    { 43, 91, 54, "praesentium" },
                    { 34, 91, 63, "est" },
                    { 21, 91, 67, "pariatur" },
                    { 7, 11, 9, "ipsam" },
                    { 45, 29, 22, "modi" },
                    { 60, 34, 71, "temporibus" },
                    { 84, 36, 60, "error" },
                    { 66, 45, 77, "molestiae" },
                    { 75, 52, 94, "omnis" },
                    { 12, 53, 35, "sit" },
                    { 42, 55, 58, "ullam" },
                    { 8, 65, 31, "possimus" },
                    { 16, 65, 46, "accusamus" },
                    { 69, 69, 21, "dicta" },
                    { 3, 72, 100, "officiis" },
                    { 13, 74, 15, "asperiores" },
                    { 58, 74, 7, "consequatur" },
                    { 2, 83, 69, "aut" },
                    { 51, 95, 75, "sunt" },
                    { 31, 96, 36, "quod" },
                    { 71, 98, 75, "blanditiis" },
                    { 47, 96, 31, "fugiat" },
                    { 41, 38, 40, "velit" },
                    { 14, 54, 84, "harum" },
                    { 4, 59, 39, "mollitia" },
                    { 48, 59, 62, "illum" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 88, 59, 3, "eum" },
                    { 77, 62, 56, "amet" },
                    { 82, 33, 60, "unde" },
                    { 55, 67, 17, "illo" },
                    { 49, 68, 25, "deserunt" },
                    { 29, 78, 2, "cupiditate" },
                    { 59, 79, 39, "voluptatibus" },
                    { 9, 98, 98, "repellendus" },
                    { 22, 98, 96, "natus" },
                    { 36, 96, 7, "eius" },
                    { 64, 67, 8, "ab" },
                    { 80, 30, 56, "dignissimos" },
                    { 19, 79, 98, "sequi" },
                    { 1, 28, 10, "minus" },
                    { 6, 30, 57, "eveniet" },
                    { 95, 97, 62, "voluptate" },
                    { 10, 16, 10, "non" },
                    { 67, 97, 5, "repudiandae" },
                    { 46, 24, 35, "id" },
                    { 52, 24, 53, "consequuntur" },
                    { 53, 26, 69, "sed" },
                    { 74, 19, 27, "quos" },
                    { 93, 35, 24, "tempora" },
                    { 39, 60, 53, "consectetur" },
                    { 17, 64, 9, "voluptatem" },
                    { 15, 70, 3, "perspiciatis" },
                    { 61, 70, 78, "debitis" },
                    { 63, 70, 10, "minima" },
                    { 11, 35, 42, "rerum" },
                    { 99, 5, 67, "voluptatum" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 210, 267, "Jasen.Weissnat@gmail.com", "Emmet", "Ratke", "MdiofCf13t", 1, "Ceasar.Dickinson" },
                    { 124, 300, "Shayne_Legros@yahoo.com", "Vivienne", "Kiehn", "mc8oF3yvJS", 1, "Clara.Hartmann26" },
                    { 206, 135, "Waino_Huel83@yahoo.com", "Michele", "Abbott", "RSKp80LB9R", 1, "Elton_Legros" },
                    { 8, 122, "Nyah.Mann93@yahoo.com", "Emmett", "Paucek", "C6b9PEfXhI", 1, "Paris.Lakin48" },
                    { 246, 259, "Joshuah66@hotmail.com", "Hassan", "Luettgen", "p8KOf7RmW9", 1, "Arnulfo98" },
                    { 58, 53, "Ferne.Huels@gmail.com", "Tillman", "Cruickshank", "qAMCP3gF35", 3, "Kailey_Lakin" },
                    { 222, 259, "Lambert.Rohan@gmail.com", "Claud", "Murphy", "4uA8vYMwxg", 2, "Donna77" },
                    { 166, 251, "Lavern32@gmail.com", "Donato", "Greenfelder", "k95uZZyDT0", 3, "Letitia_McKenzie" },
                    { 137, 251, "Gina.McKenzie87@hotmail.com", "Ephraim", "Greenholt", "811suo3Wyn", 2, "Liam.Kihn11" },
                    { 175, 53, "Buster.Homenick67@gmail.com", "Xander", "Christiansen", "RiHf5rAZrR", 1, "Carmel67" },
                    { 162, 285, "Hailie24@gmail.com", "Obie", "Corkery", "nTkwkZfngz", 2, "Bethany30" },
                    { 250, 168, "Harmony.Kerluke@yahoo.com", "Amara", "Maggio", "yylA122C3W", 1, "Camren.Daniel68" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 37, 131, "Anita.Huels@hotmail.com", "Norberto", "Reichel", "FINdLfQ25R", 1, "Ruben.Kuvalis4" },
                    { 134, 131, "Blake.Block@hotmail.com", "Zachariah", "Batz", "6_zyV5NNUX", 2, "Dimitri58" },
                    { 55, 168, "Payton23@gmail.com", "Devante", "Herman", "RJAwjr0f2e", 1, "Donna21" },
                    { 90, 168, "Scot.Rohan53@yahoo.com", "Lincoln", "McGlynn", "sbjbQtWyXD", 3, "Kristoffer.Cronin" },
                    { 153, 168, "Rachelle.Hessel@yahoo.com", "Lewis", "Bogisich", "drR8cqx1_Y", 3, "Tevin43" },
                    { 189, 168, "Reid_Effertz@gmail.com", "Nathaniel", "Walter", "7aanQSyByP", 2, "Jodie.Koepp82" },
                    { 223, 281, "Patricia.Okuneva@gmail.com", "Candice", "Johnston", "OBqYMZFVFq", 1, "Aleen15" },
                    { 156, 296, "Karen.Kunze13@hotmail.com", "Gudrun", "Farrell", "cC3VJME1UI", 2, "Bridie_Mante59" },
                    { 186, 116, "Haylie_Beier@yahoo.com", "Reyes", "Cassin", "Ngge3CbpbZ", 1, "Delores_Treutel" },
                    { 141, 51, "Abel_Batz@gmail.com", "Madie", "Gutmann", "kyXNi4aYOQ", 1, "Art.Blick38" },
                    { 123, 139, "Orlo_Macejkovic@gmail.com", "Eliseo", "Brakus", "toqvq6UEBP", 3, "Alessandro.Lubowitz" },
                    { 289, 43, "Ottilie_Koss@hotmail.com", "Pearlie", "Hauck", "vtVWglJMmY", 3, "Tiana25" },
                    { 22, 131, "Roxane_Roob@gmail.com", "Marilie", "Gottlieb", "5WjVazPa14", 1, "Eloy_Ratke74" },
                    { 214, 165, "Imogene_Oberbrunner@hotmail.com", "Araceli", "Deckow", "dofjFNO18m", 1, "Edwina.Weimann97" },
                    { 24, 98, "Drake.Purdy8@gmail.com", "Elinore", "O'Conner", "AKmzdxQK2a", 1, "Jayme.Swaniawski8" },
                    { 260, 190, "Ernestina.Monahan@gmail.com", "Baby", "Gulgowski", "gMCY3q7iLp", 2, "Hilton_Schaden" },
                    { 215, 263, "Lyric.Wilkinson40@yahoo.com", "Jasper", "Hessel", "Y6IluM5DU6", 1, "Arvid41" },
                    { 17, 8, "Vallie_Kreiger95@hotmail.com", "Eugene", "Quigley", "jk9PACmdnn", 1, "Neva.Durgan" },
                    { 171, 130, "Aleen_Jacobs@gmail.com", "Stephen", "Lind", "mMgyr15OI6", 3, "Viviane85" },
                    { 268, 130, "Maud.Boehm97@gmail.com", "Dora", "Bradtke", "bHR2RMzU08", 3, "Mazie.Ledner51" },
                    { 9, 244, "Martine_Sporer61@hotmail.com", "Gilberto", "Barrows", "6XDwTA49xg", 1, "Noemy.Carroll" },
                    { 121, 244, "Hailee42@hotmail.com", "Walter", "Kuvalis", "2APesI_FiM", 3, "Araceli87" },
                    { 232, 244, "Laila.Schuster@hotmail.com", "Cornelius", "Rau", "VwYle2XfNG", 2, "Leola_Kreiger61" },
                    { 254, 244, "Bart_Reinger@hotmail.com", "Tate", "Weissnat", "FsnPrNRmfs", 2, "Katherine.Beatty" },
                    { 131, 12, "Krystel40@yahoo.com", "Danyka", "Moen", "IqYT2mC07u", 3, "Durward0" },
                    { 240, 273, "Olga51@gmail.com", "Vena", "Brakus", "VK1nBmpqVK", 3, "Dangelo.Beer36" },
                    { 77, 20, "Jonathan88@yahoo.com", "Alexandrea", "Bashirian", "CN15W9tBBO", 3, "Rozella.Jakubowski" },
                    { 160, 3, "Walton.Heathcote41@hotmail.com", "Kylie", "Reinger", "kpefS68Vny", 3, "Fern25" },
                    { 78, 165, "Glenna_Emmerich5@yahoo.com", "Adele", "Wilkinson", "3v9zLYM2LO", 1, "Ethelyn_Deckow35" },
                    { 200, 98, "Estell_Gutmann@yahoo.com", "Lewis", "Douglas", "pYlZ8lqDjC", 2, "Loyal72" },
                    { 59, 234, "Jesse20@gmail.com", "Katharina", "Bins", "KJ9iiJFcNi", 2, "Hipolito_Senger" },
                    { 89, 234, "Breanne.Russel67@hotmail.com", "Garth", "Bauch", "r9di0qM9iv", 1, "Shyann48" },
                    { 91, 78, "Felton43@hotmail.com", "Alivia", "MacGyver", "frueZqeTj2", 1, "Ambrose40" },
                    { 217, 184, "Vella_Ortiz@gmail.com", "Julianne", "Kuvalis", "QHceyJ4Dlp", 3, "Kyra48" },
                    { 126, 15, "Letha3@gmail.com", "Filomena", "Dicki", "l3G1NqjlU9", 1, "Kenyatta28" },
                    { 15, 17, "Ryann_Von@gmail.com", "General", "Hintz", "GK1FQBW6Uv", 1, "Linwood_Hills80" },
                    { 155, 17, "Lindsay_Predovic18@yahoo.com", "Kyle", "Kautzer", "acxy9zJSbR", 3, "Jonathan91" },
                    { 208, 187, "Brandyn82@yahoo.com", "Louvenia", "Rolfson", "bWibTZRY9c", 1, "Eduardo_Gulgowski68" },
                    { 100, 22, "Greta6@gmail.com", "Sarai", "Corwin", "N0mRSaU2oQ", 1, "Brisa21" },
                    { 116, 104, "Gust.Kihn35@hotmail.com", "Antonio", "Reichert", "jI_dngj1H_", 1, "Lambert_Buckridge" },
                    { 132, 190, "Davin_Pacocha@hotmail.com", "Natasha", "McDermott", "O_hIBioYMY", 3, "Shirley_Greenfelder42" },
                    { 252, 190, "Rosanna89@gmail.com", "Hildegard", "Grant", "uqpCzMGi06", 3, "Delia_Prosacco" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 48, 234, "Martine.Jaskolski89@hotmail.com", "Mckenzie", "Bergnaum", "4YZCWni_Vw", 2, "Florence_Willms" },
                    { 180, 3, "Gerry.Legros2@gmail.com", "Arielle", "Hodkiewicz", "kHCToO89QH", 1, "Conor_Kozey84" },
                    { 39, 224, "Ryann_Wuckert@yahoo.com", "Ned", "Johnson", "njlPWi_tFa", 3, "Dereck_Johns5" },
                    { 177, 14, "Octavia_Schmeler@hotmail.com", "Akeem", "Okuneva", "CK2XzQcs7o", 3, "Samantha25" },
                    { 114, 169, "Amelia.Gibson5@hotmail.com", "Kristoffer", "Feeney", "6sC4ZP3w3D", 2, "Meaghan_Shanahan" },
                    { 236, 169, "Kelly.Cronin@hotmail.com", "Owen", "Lowe", "q0eN5Mt1Lj", 2, "Harmony7" },
                    { 255, 169, "Sarah24@gmail.com", "Lafayette", "Olson", "U1tHBYrlt_", 3, "Ewell_Purdy" },
                    { 41, 263, "Vivienne23@gmail.com", "Ayana", "Ankunding", "92yvaDrmP7", 1, "Amanda.Smith" },
                    { 40, 174, "Cole_Hyatt84@gmail.com", "Lorine", "Robel", "9dtIrWdP1p", 3, "Gina.Bode28" },
                    { 2, 206, "Asa.Ratke@gmail.com", "Lora", "Paucek", "HFECfUxjGj", 3, "Maximo34" },
                    { 57, 84, "Johan_Ratke13@hotmail.com", "Ambrose", "Strosin", "XUYiPMWDHK", 3, "Jailyn_McClure99" },
                    { 129, 84, "Alberta.Stracke@gmail.com", "Mariane", "Hayes", "Mk716L_KNI", 3, "Marques30" },
                    { 224, 11, "Evangeline.Leuschke72@yahoo.com", "Vesta", "Tillman", "ZCu1IG7LsJ", 2, "Floyd.Howe46" },
                    { 198, 71, "Beatrice_Hegmann@gmail.com", "Tavares", "Champlin", "KdlkX6vzub", 2, "Maida40" },
                    { 259, 71, "Wyman_Heller9@yahoo.com", "Desmond", "Trantow", "kW_KyJatA4", 2, "Brent.Ortiz" },
                    { 28, 239, "Jon55@hotmail.com", "Jennie", "Mayert", "JyRCl203dU", 1, "Leo53" },
                    { 111, 239, "Rogers.Armstrong84@hotmail.com", "Deion", "Casper", "Be8QVmo_Wq", 3, "Ada61" },
                    { 202, 239, "Gloria.Haley@yahoo.com", "Devan", "Leannon", "O9bYmhahdt", 2, "Cassandra_Weimann" },
                    { 147, 250, "Olaf5@hotmail.com", "Aida", "Zieme", "NiJe0Ut76u", 2, "Jane.Walter" },
                    { 221, 250, "Loy.Grimes61@yahoo.com", "Cassandra", "D'Amore", "Eqgsj42wV3", 1, "Talon_Greenholt" },
                    { 235, 250, "Rowan49@gmail.com", "Bradford", "Mayert", "JbkTAZhsiE", 3, "Dandre.Rowe17" },
                    { 249, 250, "Lucio74@gmail.com", "Kayleigh", "Muller", "EtidC9S6GD", 3, "Eva_Krajcik" },
                    { 196, 255, "Joaquin79@gmail.com", "Brandy", "Champlin", "YMROLx6dXh", 3, "Kirstin.Pfannerstill39" },
                    { 288, 164, "Julian2@gmail.com", "Paolo", "Davis", "ILUc0H5_EL", 1, "Cale.Quitzon11" },
                    { 75, 182, "Herbert22@yahoo.com", "Armani", "O'Hara", "GpFTdU9Zyv", 3, "Mallory_Stark" },
                    { 10, 34, "Aiyana_Schulist@hotmail.com", "Gloria", "Bahringer", "RULN7qlfnW", 3, "Billie79" },
                    { 159, 34, "Deontae.Ebert58@hotmail.com", "Marshall", "Moore", "i7zRukVWqe", 1, "Percival31" },
                    { 86, 81, "Nicolas.Strosin52@yahoo.com", "Delpha", "Haley", "G237Zz4Wuq", 3, "Rosemary74" },
                    { 118, 81, "Murphy_Ritchie53@gmail.com", "Craig", "McDermott", "jryziP3GPK", 2, "Lauretta.Kuphal61" },
                    { 74, 169, "Leonor_Lang@hotmail.com", "Damon", "Hahn", "kR1y9mklic", 1, "Sylvan_Mann1" },
                    { 216, 3, "Sofia.Nitzsche94@gmail.com", "Soledad", "Walsh", "yHSCl1nmyn", 2, "Einar_Zboncak" },
                    { 94, 18, "Theodora.Prohaska36@hotmail.com", "Kay", "Donnelly", "Ig6H0K3uxG", 2, "Micaela10" },
                    { 234, 266, "Cheyenne71@hotmail.com", "Jerry", "Bode", "G5mu06eOwv", 2, "Ella98" },
                    { 49, 29, "Natasha.Jacobs@yahoo.com", "Callie", "Zboncak", "LgL5saz9rx", 2, "Talia41" },
                    { 54, 163, "Leola_Kuhn@hotmail.com", "Lexie", "Corwin", "D3ssNCqTVZ", 2, "Shaina.Russel10" },
                    { 278, 163, "Chelsie.West76@gmail.com", "Gaetano", "Weissnat", "nAMYvADhLr", 1, "Ahmad88" },
                    { 239, 180, "Abigale_Zieme@gmail.com", "Audra", "Fritsch", "VuBIVQn1PP", 2, "Vernice.Mraz68" },
                    { 262, 180, "Sylvan_Rolfson@hotmail.com", "Hoyt", "Steuber", "8nNBMd4NhH", 1, "Holden_Spencer50" },
                    { 225, 249, "Nelson77@hotmail.com", "Jacques", "Littel", "UfiLijwGDi", 2, "Maximo_Lebsack93" },
                    { 243, 249, "Beryl_Franecki17@gmail.com", "Arne", "Terry", "8UZTYvbk6w", 1, "Peter35" },
                    { 105, 73, "Rylee11@gmail.com", "Paul", "Schuster", "LWgxat27Ks", 2, "Jeanne_Leuschke" },
                    { 139, 73, "Lula23@yahoo.com", "Harvey", "Rau", "svlwjuYc0t", 2, "Adeline64" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 53, 23, "Oleta2@gmail.com", "Trycia", "Langosh", "NvysWTP6H6", 2, "Ezequiel68" },
                    { 56, 23, "Sarai_Jakubowski@gmail.com", "Kole", "Block", "c_xaHIyOJz", 3, "Wilburn86" },
                    { 61, 23, "Jodie8@yahoo.com", "Afton", "Baumbach", "5BJabIFONS", 1, "Rocky_Mayert" },
                    { 258, 23, "Malvina_Gerlach@hotmail.com", "Curtis", "Sporer", "92se4fSJxj", 1, "Cristal_Pfeffer59" },
                    { 13, 224, "Gunnar.Dickens22@yahoo.com", "Zander", "Reichel", "uk_PWJvGwo", 3, "Justine.Hyatt" },
                    { 226, 224, "Stanton94@yahoo.com", "Michael", "Jenkins", "awp0OORB6t", 2, "Christop.Lindgren" },
                    { 293, 224, "Mariah.Kshlerin62@yahoo.com", "Phyllis", "Turcotte", "HUBF57xlNd", 2, "Corrine.Nikolaus21" },
                    { 44, 220, "Nannie_Price@hotmail.com", "Sarai", "Jenkins", "9b4NStWKO2", 2, "Simone88" },
                    { 65, 220, "Lauren.Altenwerth@hotmail.com", "Kathryne", "Harris", "dlv8PmwAAt", 3, "Braeden3" },
                    { 72, 220, "Leda87@yahoo.com", "Stephania", "Dooley", "dC0LCZw8fO", 1, "Elda.Beatty" },
                    { 88, 220, "Sanford_Hartmann@hotmail.com", "Deon", "Weber", "4BC_4gw3DK", 2, "Rasheed.Marvin" },
                    { 179, 220, "Cole.Runolfsson56@gmail.com", "Ivah", "O'Connell", "ZSiM8IsI6Z", 3, "Charles_Kautzer73" },
                    { 173, 6, "Grayson_Brakus47@yahoo.com", "Creola", "Prosacco", "I3iXTVLuaK", 2, "Breana8" },
                    { 83, 158, "Nigel.Hettinger5@hotmail.com", "Concepcion", "Casper", "bDSK8Rb8C1", 3, "Hudson_Moore57" },
                    { 176, 152, "Malika33@yahoo.com", "Glennie", "Rippin", "vZFKBMbG1t", 3, "Braxton47" },
                    { 51, 266, "Elmore82@hotmail.com", "Theo", "Ledner", "tBSS8YKpjs", 2, "Skyla_Schmeler18" },
                    { 266, 266, "Leanne_Harber7@yahoo.com", "Kathleen", "Berge", "WAePzJsQAd", 2, "Glenda.Rau" },
                    { 36, 49, "Rashawn_Hauck@yahoo.com", "Joe", "Hagenes", "AhU3w73DAh", 2, "Nathan_Abbott67" },
                    { 4, 263, "Katharina_Von46@gmail.com", "Idell", "Dicki", "TeCTDgVTbe", 1, "Stacey16" },
                    { 220, 183, "Mitchel_Ferry92@hotmail.com", "Tom", "D'Amore", "PDtPU7UddR", 3, "Zoe_Torphy" },
                    { 172, 254, "Shyann.Schamberger@hotmail.com", "Dorris", "McKenzie", "6S1NKPZdIR", 3, "Shaun.DuBuque18" },
                    { 115, 254, "Lemuel_Bernhard@hotmail.com", "Milo", "O'Connell", "CEWt2UfO38", 1, "Mabel_Treutel43" },
                    { 144, 24, "Yessenia73@yahoo.com", "Raphael", "VonRueden", "RctfaVeQVb", 3, "Lynn.Kovacek75" },
                    { 71, 298, "Felton82@hotmail.com", "Dolores", "Doyle", "eCVGYoKM9S", 1, "Rosa36" },
                    { 184, 294, "Alice_Dibbert@yahoo.com", "Karlie", "Spinka", "Y15XnNahG3", 2, "Mario53" },
                    { 149, 222, "Bradley0@yahoo.com", "Abbie", "Weimann", "bL7xJlj2ci", 2, "Catharine_McClure" },
                    { 109, 222, "Vance_Balistreri57@gmail.com", "Madelynn", "Kub", "VIqIFFijqv", 1, "Darron_Labadie76" },
                    { 138, 170, "Molly10@hotmail.com", "Nash", "Goldner", "RjjRIBLqco", 3, "Kraig.Welch" },
                    { 228, 128, "Garland.Runolfsson@yahoo.com", "Veronica", "Krajcik", "NPxfvcUiXo", 3, "Hans85" },
                    { 285, 44, "Clementina_Cassin30@gmail.com", "Kylee", "Shanahan", "hawvUcQH2Y", 3, "Mekhi_Watsica" },
                    { 122, 150, "Olen18@hotmail.com", "Alvis", "Labadie", "eQmmEvGSzl", 3, "Logan_Konopelski77" },
                    { 32, 150, "Eugene_Swaniawski@hotmail.com", "Fritz", "Boehm", "I1CM39VNT1", 1, "Fermin54" },
                    { 20, 150, "Albin_OConner68@yahoo.com", "Junius", "Schowalter", "NFqZXpUJWn", 3, "Deron_Ebert" },
                    { 209, 10, "Vivienne91@hotmail.com", "Arden", "Murray", "BueK_Z_kAU", 1, "Breana3" },
                    { 203, 215, "Miller_Rempel@gmail.com", "Lukas", "Brekke", "80Cf_0z_Xk", 2, "Jaylan_Will" },
                    { 16, 215, "Deondre67@yahoo.com", "Hayley", "Weber", "3Ge2yg6WIM", 1, "Elijah0" },
                    { 178, 157, "Junior28@yahoo.com", "Laron", "Wolff", "Gf52F4PSXy", 3, "Marcos.Haley" },
                    { 296, 134, "Ciara.Gusikowski84@yahoo.com", "Cleve", "Cremin", "oiwC3IrbF_", 2, "Ephraim54" },
                    { 117, 134, "Alysa.Little@hotmail.com", "Jaquan", "Prosacco", "0FMC2BR8ZC", 2, "Estefania.Bayer" },
                    { 247, 254, "Brionna_Murazik16@hotmail.com", "Lonzo", "Lubowitz", "qcN5lsxCJ5", 2, "Virgil99" },
                    { 35, 134, "Mckayla50@gmail.com", "Myrna", "Hudson", "51kFDEA5y0", 2, "Sterling_Romaguera83" },
                    { 143, 75, "Lula32@gmail.com", "Robin", "Mills", "GEXuslIBUD", 2, "Ottilie94" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 63, 102, "Noemie83@yahoo.com", "Lila", "Schaden", "WwWMSor2RF", 1, "Jayson_Padberg" },
                    { 12, 58, "Thomas_Kshlerin@hotmail.com", "Colby", "Howell", "uKg51AuX32", 2, "Bethel.Feeney8" },
                    { 269, 124, "Vaughn.Mann55@gmail.com", "Elroy", "Lang", "7fTRaua3kw", 1, "Ruben_Dach96" },
                    { 265, 124, "Lee13@hotmail.com", "Dora", "Donnelly", "sQrBYV4OZ6", 1, "Sabryna54" },
                    { 82, 221, "Boyd.Hackett9@yahoo.com", "Keenan", "Batz", "Em41pXBqCP", 3, "Dorris50" },
                    { 81, 221, "Ryan.Schimmel@hotmail.com", "Kobe", "Vandervort", "0MmiZLgnSp", 1, "Nolan.Bogan14" },
                    { 26, 221, "Eve52@hotmail.com", "Adolph", "Larkin", "JmVJAyvE4H", 2, "Beau23" },
                    { 277, 218, "Erin.Luettgen@gmail.com", "Yazmin", "Moore", "JfoM55GjT6", 1, "Katelyn73" },
                    { 253, 218, "Vince75@yahoo.com", "Lyda", "Wolf", "ALGIM_CQcX", 1, "Glenda29" },
                    { 101, 218, "Norbert.Schiller93@gmail.com", "Korbin", "Kessler", "8UHrexrbNJ", 1, "Alda.Rutherford13" },
                    { 95, 173, "Rosamond.Kshlerin@yahoo.com", "Madilyn", "Wiza", "uWUtSJftj7", 2, "Jeanie62" },
                    { 279, 213, "Jarred.Dare@gmail.com", "Cassie", "Reynolds", "nXEyjxcum0", 1, "Jessie_Schoen81" },
                    { 135, 213, "Jovan.Kilback35@gmail.com", "Whitney", "Funk", "CqivOOVvgA", 2, "Halie14" },
                    { 70, 65, "Wade9@gmail.com", "Jana", "Fadel", "Yw7ux5_NRR", 3, "Ibrahim_Tillman26" },
                    { 169, 287, "Kristopher.Schaefer@gmail.com", "Anne", "Stiedemann", "vkrE3rjbTl", 2, "Norberto.Gorczany" },
                    { 248, 200, "Estella8@hotmail.com", "Brianne", "Hansen", "Ujn_pXhwzn", 2, "Loy.Renner" },
                    { 27, 252, "Jacey_Grant27@yahoo.com", "Webster", "Zieme", "jhM4tWrSHE", 1, "Desiree_Nienow" },
                    { 14, 252, "Audrey.Hirthe@hotmail.com", "Alfonzo", "Pacocha", "kojBBwaZfW", 1, "Kenny39" },
                    { 291, 102, "Randi38@gmail.com", "Mario", "Daniel", "55A57yl_p3", 1, "Gail.McClure30" },
                    { 157, 102, "Theron_Dach78@hotmail.com", "Brown", "Christiansen", "cqVkOze6Cw", 1, "Edgardo.Dibbert" },
                    { 62, 28, "Kassandra_Turner@hotmail.com", "Damion", "Beatty", "ErO_gmXvVu", 1, "Clifford.Huel16" },
                    { 280, 207, "Bernard.Wyman81@hotmail.com", "Tyree", "Schmidt", "1l51pm8jWn", 3, "Antonietta_Corwin" },
                    { 274, 207, "Esperanza90@hotmail.com", "Imogene", "Luettgen", "z4xmVUWpnx", 3, "Kathryn_Lynch" },
                    { 60, 70, "Cassie98@gmail.com", "Haskell", "Sauer", "wbPgnp_JBQ", 2, "Horace56" },
                    { 287, 237, "Selena.Pfeffer@hotmail.com", "Zoila", "Larson", "tVFZo9XhW1", 1, "Daphnee81" },
                    { 241, 237, "Zachery66@yahoo.com", "Zander", "Balistreri", "p3XpycYrvs", 2, "Macy.Bergstrom67" },
                    { 212, 193, "Roosevelt_Baumbach@hotmail.com", "Haylee", "Morar", "hBrwb1HlLA", 1, "Shakira_Stroman23" },
                    { 161, 228, "Susana_Davis@gmail.com", "Jayde", "Bergnaum", "At5nNizElN", 3, "Renee16" },
                    { 45, 212, "Reilly_Little@hotmail.com", "Thad", "Kub", "S8uFbj7AGv", 1, "Jayne.Gorczany37" },
                    { 19, 212, "Adrienne90@hotmail.com", "Erik", "Morar", "iI3ybA1HKC", 1, "Alfonzo85" },
                    { 46, 109, "Susie.Jerde@gmail.com", "Deron", "Kiehn", "WDGwiYYqqT", 3, "Elsie_Emard95" },
                    { 151, 262, "Bridie43@yahoo.com", "Thurman", "Fay", "NaxQ8S8ZfD", 1, "Tianna_Langosh8" },
                    { 5, 141, "Bell38@hotmail.com", "Philip", "Hauck", "5KH05KbTU3", 3, "Reymundo62" },
                    { 227, 72, "Paige98@hotmail.com", "Boyd", "Kessler", "kWLoPKq7sL", 2, "Bernita.Gerlach38" },
                    { 182, 72, "Kristy_Buckridge10@gmail.com", "Leora", "Davis", "0JuX47DYjx", 1, "Nicklaus_Graham97" },
                    { 73, 41, "Leatha.Fahey28@yahoo.com", "Manley", "Klein", "pKFkwWkt0j", 2, "Aracely.VonRueden" },
                    { 38, 27, "Jacinto91@yahoo.com", "Adolf", "Emmerich", "b8d2kObN6r", 1, "Leopold.Wilderman71" },
                    { 170, 280, "Nelle39@gmail.com", "Katarina", "Rowe", "J4PK5MDEOF", 1, "Reymundo.Bechtelar10" },
                    { 230, 289, "Katherine54@gmail.com", "Oswaldo", "Watsica", "b830RG1V4L", 1, "Kailyn.Wehner42" },
                    { 174, 289, "Keara.Corkery@gmail.com", "Orin", "Von", "llOXiFU7fF", 2, "Stanton.Kertzmann" },
                    { 245, 161, "Hazle.Robel33@gmail.com", "Lou", "Hayes", "nFb0QAJLS3", 2, "Carolina_Bernhard" },
                    { 3, 67, "Shirley.Stoltenberg94@gmail.com", "Mathias", "Baumbach", "2USoKAvSnq", 3, "Vincenzo82" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 80, 178, "Catalina_Medhurst18@hotmail.com", "Justus", "Walter", "9SJfR2NPXq", 2, "Kaylah3" },
                    { 1, 282, "Jermey_OReilly86@yahoo.com", "Connie", "Gottlieb", "dfIjbfxEU4", 2, "Okey91" },
                    { 207, 282, "Lizzie_Stanton@hotmail.com", "Alayna", "Fay", "TxgAYCD8WA", 1, "Verner74" },
                    { 261, 282, "Oliver_Bruen@gmail.com", "Virginia", "Abshire", "WsBkhOSFYb", 1, "Prudence.VonRueden" },
                    { 110, 86, "Niko_Marvin@hotmail.com", "Nichole", "Runte", "sRzN6Bzn8D", 3, "Antonietta.Cassin" },
                    { 31, 70, "Enrico97@gmail.com", "Paxton", "Howe", "AD4XGltb_D", 3, "Santino_Heathcote18" },
                    { 107, 40, "Karlie61@gmail.com", "Destinee", "Shanahan", "Y7SgAMcKnH", 2, "Lucius_Douglas51" },
                    { 257, 284, "Raphael.Watsica73@hotmail.com", "Tiana", "Keeling", "5N879i4p0C", 2, "Travis.Schmeler73" },
                    { 87, 198, "Tatum_Keeling61@yahoo.com", "Gerald", "Robel", "Ko9QES6bYj", 3, "Kiarra_Huel" },
                    { 140, 138, "Jovani44@yahoo.com", "Darryl", "Prosacco", "QtCN_CJl_R", 1, "Sheila_Wintheiser" },
                    { 128, 35, "Yoshiko_Mayer78@hotmail.com", "Leone", "Moore", "KzwXkbU0JV", 1, "Therese30" },
                    { 108, 35, "Mazie.Abernathy1@gmail.com", "Briana", "McDermott", "vVDdmwmkmK", 1, "Kenyon_Fahey22" },
                    { 42, 297, "Marvin.Ebert86@yahoo.com", "Abbie", "Bahringer", "MOCYwIiemk", 2, "Elaina.Bernhard8" },
                    { 150, 286, "Lempi_Wunsch@gmail.com", "Watson", "Sanford", "9RWEvucDim", 1, "Andrew28" },
                    { 92, 171, "Dewayne.Jerde@gmail.com", "Colby", "Breitenberg", "WIM_j4Kc49", 2, "Domingo_Jacobi80" },
                    { 219, 276, "Anastacio_Murray@gmail.com", "Jaleel", "Hane", "pEfp1K2rLh", 1, "Arne.Flatley" },
                    { 158, 154, "Adolf10@yahoo.com", "Arnaldo", "McClure", "4muZxj2TfZ", 2, "Johnpaul0" },
                    { 188, 99, "Karianne.Reichert@gmail.com", "Jasper", "Sauer", "_SFB6PqR5b", 1, "Lilla.Beahan" },
                    { 199, 288, "Eloy_Carroll15@yahoo.com", "Colten", "Bernhard", "ukMkQf5b00", 3, "Aubrey.Rohan30" },
                    { 152, 288, "Ian_OKon41@gmail.com", "Lucio", "McLaughlin", "YnWm23HqQF", 1, "Mabelle.Yundt83" },
                    { 281, 205, "Terry_Baumbach48@yahoo.com", "Rhiannon", "Breitenberg", "IjYsggnWrM", 1, "Elvie_Leuschke8" },
                    { 272, 205, "Tommie23@yahoo.com", "Scottie", "Macejkovic", "Doppfd6WgD", 3, "Jed_Stracke77" },
                    { 300, 137, "Adan_Nitzsche@hotmail.com", "Alfred", "Hartmann", "nuD9n0CjIR", 2, "Axel_Gibson" },
                    { 146, 179, "Marjory_Konopelski79@gmail.com", "Curt", "Franecki", "Bs8Ev4CXs0", 1, "Adriana.Simonis" },
                    { 103, 292, "Dallin.Skiles69@yahoo.com", "Leila", "Legros", "VU63EtXEjm", 2, "Edwin_Feeney74" },
                    { 165, 276, "Griffin.Welch@gmail.com", "Cecilia", "Hauck", "pAHpET98qc", 1, "Boris2" },
                    { 294, 127, "Lexi21@gmail.com", "Elenora", "Nader", "P5542FEuIO", 2, "Adam_Konopelski" },
                    { 11, 145, "Nina.Becker47@gmail.com", "Alycia", "Crist", "dMP5tUGqfS", 2, "Gabrielle.Medhurst80" },
                    { 205, 185, "Lila.Hayes@hotmail.com", "Chadrick", "Champlin", "SpE7m50wXs", 1, "Victor.Botsford" },
                    { 104, 216, "Uriah97@gmail.com", "Charlie", "Rodriguez", "qAyuVNk7xy", 2, "Dedric.Davis" },
                    { 64, 159, "Erna.Reichel@yahoo.com", "Darren", "Funk", "vjzo1PYKuI", 3, "Oma.Abbott" },
                    { 284, 107, "Jordi_Corkery34@hotmail.com", "Florida", "Schroeder", "lQfWZje4Re", 2, "Izaiah98" },
                    { 204, 166, "Hilbert_OConnell83@hotmail.com", "Reta", "Rau", "rNIvsDzUcJ", 2, "Ashleigh_Senger86" },
                    { 233, 115, "Peter94@hotmail.com", "Rickey", "Feest", "lZa_oYyatd", 3, "Jude.Jakubowski90" },
                    { 120, 115, "Carlos8@yahoo.com", "Cortez", "Hamill", "rTaL3YtTaI", 1, "Ottis59" },
                    { 256, 299, "Hardy_Tromp@yahoo.com", "Russ", "Bruen", "YiRKwLJjdb", 3, "Lindsay.Hudson32" },
                    { 299, 63, "Adeline.Schuster72@yahoo.com", "Winston", "Tromp", "pQIwdJJXrX", 3, "Carmelo_Reilly" },
                    { 102, 63, "Tanner.Kassulke47@hotmail.com", "Cayla", "Considine", "1cPFJ3PuJa", 3, "Dominic15" },
                    { 181, 21, "Leann34@yahoo.com", "Emilie", "Hane", "jKt3MX1pJK", 2, "Jesus.Lehner" },
                    { 282, 100, "Viva_Oberbrunner23@gmail.com", "Garrett", "Graham", "ZROm6AlbAd", 1, "Kenna56" },
                    { 50, 100, "Enola27@gmail.com", "Dimitri", "Bogan", "KLGaD3jb6n", 3, "Nayeli_OReilly24" },
                    { 195, 39, "Jermey_Ratke@gmail.com", "Lurline", "Wisozk", "0MvahOk9Dl", 2, "Kody12" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 211, 146, "Tad_Jaskolski40@yahoo.com", "Leo", "Botsford", "xeP4eR71t1", 3, "Chad.Bailey" },
                    { 231, 87, "Jairo81@hotmail.com", "Kamryn", "Huel", "EImJlOLteC", 1, "Jadyn62" },
                    { 283, 277, "Elisabeth.Cronin@hotmail.com", "Stefanie", "Jacobi", "35duB_JVW4", 2, "Betsy49" },
                    { 163, 277, "Greta.Hilll@yahoo.com", "Chanelle", "Wuckert", "AEUmAa0i_j", 1, "Wilbert_Jenkins" },
                    { 145, 240, "Hardy41@yahoo.com", "Claudine", "Wehner", "vM4vdUtGVR", 2, "Ariel_Waters74" },
                    { 148, 232, "Tevin.Hodkiewicz@gmail.com", "Assunta", "Gerlach", "N1wIImACY5", 3, "Abbigail_Aufderhar" },
                    { 263, 216, "Roxanne.Rowe@hotmail.com", "Cathy", "Bode", "4dCc9Vc3VU", 3, "Domenico90" },
                    { 84, 232, "Paul.Hauck31@hotmail.com", "Brook", "Braun", "PnKLnCryL_", 3, "Ila49" },
                    { 18, 37, "Lavinia.Hermiston97@hotmail.com", "Rene", "Kutch", "_KUQXcJkkT", 2, "Evans.McLaughlin52" },
                    { 6, 125, "Malvina_Macejkovic@hotmail.com", "Christophe", "Wehner", "2ShQNrUJRO", 3, "Carissa89" },
                    { 21, 183, "Lina95@hotmail.com", "Kale", "Harber", "nicrgmmAS7", 2, "Hazle.Quitzon" },
                    { 142, 121, "Anita.Heller@gmail.com", "Hiram", "Bashirian", "glC3dRcerx", 2, "Rosario.Willms" },
                    { 270, 245, "Ines.Bosco0@gmail.com", "Harley", "Will", "_mc3tnVR5M", 2, "Novella43" },
                    { 127, 194, "Bert68@gmail.com", "Marcelino", "Spencer", "6SJF4aHXc8", 3, "Adela_Beer" },
                    { 85, 194, "Clinton.Yundt@yahoo.com", "Marlin", "Borer", "_KGkcsAF9F", 1, "Dion63" },
                    { 191, 275, "Doris_Kunze@hotmail.com", "Hailey", "Mante", "64Lz7nD6cs", 1, "Yoshiko.Bartoletti" },
                    { 99, 4, "Garfield98@gmail.com", "Anais", "Rempel", "89EZUmj767", 2, "Edyth78" },
                    { 29, 279, "Rosalinda_Strosin60@gmail.com", "Lelia", "Dach", "hl5XyNf54D", 3, "Reginald.Hermiston78" },
                    { 167, 231, "Brady.Hagenes@yahoo.com", "Demarcus", "Pacocha", "Q1b8onspB6", 3, "Felix24" },
                    { 23, 103, "Myrtice.Keeling@yahoo.com", "Payton", "Langworth", "WXhDL9nVW0", 1, "Antonio_Keebler15" },
                    { 271, 101, "Stacy87@gmail.com", "Kiley", "Hahn", "OE7mRLcC6X", 1, "Barbara97" },
                    { 47, 101, "Meta.Kuhic@yahoo.com", "Bailey", "Fahey", "_5iRFaoQWC", 2, "Rahsaan70" },
                    { 34, 101, "Onie_Schmeler@gmail.com", "Karli", "Krajcik", "as17T6AYLi", 3, "Anjali17" },
                    { 218, 82, "Ursula24@gmail.com", "Amelia", "Bayer", "XxgyDpphCk", 2, "Betsy99" },
                    { 168, 31, "Ashlynn_Ruecker64@hotmail.com", "Odessa", "Torphy", "w_Im5djYCn", 2, "Candelario96" },
                    { 187, 66, "Yazmin_Witting34@gmail.com", "Collin", "Hyatt", "XenRrKzD1W", 2, "Fredy52" },
                    { 93, 269, "Rosalinda2@gmail.com", "Orlando", "Lang", "Og8lWqPRMQ", 2, "Aliyah_Mueller59" },
                    { 25, 269, "Colby12@hotmail.com", "Nathan", "Cruickshank", "A1Wmr3GToQ", 2, "Daniella.OReilly15" },
                    { 201, 246, "Elmore.Krajcik@hotmail.com", "Ursula", "MacGyver", "obB3IqTvkg", 1, "Ayana.Abbott" },
                    { 97, 37, "Keyshawn.Dibbert@hotmail.com", "Manuela", "D'Amore", "8NkcaLhTps", 3, "Bret83" },
                    { 267, 219, "Pablo65@gmail.com", "Santino", "Swaniawski", "LNlXVjT5It", 1, "Marilou_Lemke" },
                    { 164, 219, "Douglas.Rodriguez34@hotmail.com", "Jimmy", "Donnelly", "aFeIz6uXlh", 2, "Virginie_Pouros67" },
                    { 295, 60, "Major.Bruen78@hotmail.com", "Katharina", "Bartell", "EDbdsWhG3E", 2, "Thaddeus.Padberg" },
                    { 185, 176, "Erika.McClure@hotmail.com", "Milo", "Hamill", "5dVPB3bD5X", 1, "Ibrahim.Krajcik18" },
                    { 30, 175, "Wilbert_Rau50@yahoo.com", "Ricky", "Ullrich", "FXToEXTbwV", 2, "Tod14" },
                    { 242, 90, "Cleve59@gmail.com", "Bell", "Kris", "kvkv0z8imf", 1, "Darien48" },
                    { 229, 210, "Emilie.Lowe51@yahoo.com", "Jalen", "Terry", "zDQBZzwEvu", 1, "Maya81" },
                    { 273, 225, "Ken.Osinski@yahoo.com", "Concepcion", "Bernier", "9vDTgOcYRE", 1, "Junior68" },
                    { 193, 225, "Oleta.Ratke@hotmail.com", "Liliane", "Schaefer", "CRF6Gjrecu", 2, "Alvis_Abshire" },
                    { 154, 94, "Raegan_Hodkiewicz59@gmail.com", "Jayne", "Haag", "uWBDMTl8Ob", 2, "Clay.Pfeffer" },
                    { 264, 113, "Aliza67@hotmail.com", "Katlynn", "Jones", "A3XONpDcKX", 2, "Octavia.DuBuque" },
                    { 69, 113, "David_McLaughlin@hotmail.com", "Tina", "Will", "5wJ26rNEtc", 2, "Herta91" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 244, 295, "Keira53@yahoo.com", "Rossie", "Prosacco", "nA2vXba8nY", 1, "Callie.Crist8" },
                    { 33, 295, "Noble68@gmail.com", "Amani", "Larson", "X8PuwW1Yjq", 2, "Hattie.Rohan52" },
                    { 43, 76, "Sabina.Botsford21@yahoo.com", "Casper", "Waters", "kusBjds9BU", 3, "Graham16" },
                    { 197, 25, "Kailey20@gmail.com", "Darian", "Buckridge", "pUM2kRsTNt", 2, "Cole.Bernier36" },
                    { 98, 25, "Cordell_Reynolds@hotmail.com", "Janie", "Roberts", "N9PrmleoXK", 1, "Maribel44" },
                    { 298, 278, "Marianna_Kutch74@hotmail.com", "Remington", "Denesik", "NqYTD0H_bm", 2, "Sandra34" },
                    { 213, 261, "Henriette_Krajcik@yahoo.com", "Herman", "Dooley", "q7_0D3s2id", 2, "Judd.Harris59" },
                    { 237, 117, "Ezequiel69@yahoo.com", "Isaac", "Lemke", "gdPtDRLNJi", 2, "Evan13" },
                    { 96, 117, "Dewitt_Rohan@yahoo.com", "Iliana", "Hills", "t_0zZYQWtl", 2, "Johnathan.Lind" },
                    { 251, 185, "Maryam.Schroeder18@gmail.com", "Dereck", "Ward", "Z7dcYHOI6p", 3, "Marilyne24" },
                    { 119, 19, "Adrian.Buckridge@gmail.com", "Mervin", "Osinski", "ZXQ_SzLG_y", 2, "Glennie_Robel" },
                    { 190, 80, "Earl28@hotmail.com", "Cristobal", "Lynch", "SnSTurGYQl", 2, "Quinton.Trantow" },
                    { 113, 140, "Velma7@gmail.com", "Dannie", "Funk", "phzkLBVqVi", 2, "Dario.Braun" },
                    { 7, 191, "Zackary.Hilll@gmail.com", "Barney", "Satterfield", "Dur12OrX56", 1, "Linnea44" },
                    { 133, 60, "Jon42@hotmail.com", "Cordell", "Dach", "Fc8DTZeRvN", 1, "Henri42" },
                    { 275, 55, "Marilou_Hand80@hotmail.com", "Rhiannon", "Gaylord", "w6jdAdXS3i", 1, "Felicita.Farrell19" },
                    { 290, 95, "London65@yahoo.com", "Elissa", "Pouros", "Rurmp9R4ec", 2, "Kristopher.Sanford" },
                    { 136, 57, "Marjory_Keebler@gmail.com", "Aiyana", "Kshlerin", "SrIw2UyE3A", 3, "Zola_Hettinger23" },
                    { 297, 148, "Rolando.McCullough@yahoo.com", "Solon", "Bartoletti", "uctfjFWfJK", 1, "Rocky74" },
                    { 125, 148, "Oscar_Conn12@gmail.com", "Gayle", "Ledner", "GW78eq7iMI", 2, "Jessyca_Kihn52" },
                    { 192, 56, "Albertha_Hettinger@yahoo.com", "Maribel", "Bashirian", "oOmsp60W2W", 3, "Bridie_Bartell30" },
                    { 130, 203, "Lupe.Franecki28@yahoo.com", "Bradley", "Cole", "NNus1DvCDs", 1, "Jannie.Nicolas69" },
                    { 112, 186, "Ally88@gmail.com", "Raleigh", "Walter", "jqLS5VemL2", 1, "Dortha86" },
                    { 194, 185, "Justina76@gmail.com", "Halie", "Beahan", "RXxlj8yowM", 1, "Oda61" },
                    { 52, 129, "Ubaldo.Stracke4@yahoo.com", "Lindsay", "DuBuque", "_I4kTGb3kQ", 1, "Tristin63" },
                    { 76, 123, "Willard21@yahoo.com", "Evan", "Schulist", "CkVIpeD7hI", 1, "Freeda14" },
                    { 67, 123, "Madisen.Kohler@gmail.com", "Johnpaul", "Simonis", "nHjPVCX7Ap", 1, "Dion.Wunsch23" },
                    { 106, 89, "Agnes39@yahoo.com", "Taya", "Homenick", "Q45sCmBu_O", 3, "Joan.Klein" },
                    { 79, 160, "Bret16@hotmail.com", "Carmela", "O'Reilly", "eRzvaKeGX9", 3, "Tierra40" },
                    { 183, 260, "Tristian.Zboncak@gmail.com", "Myrtice", "Stracke", "f5WTFTExgx", 2, "Norma.Howe" },
                    { 286, 257, "Cecile_Jaskolski86@yahoo.com", "Liliane", "Hessel", "orD03RA6WX", 3, "Tyler_Schaefer5" },
                    { 276, 257, "Foster.Morissette@yahoo.com", "Weldon", "Schuppe", "6qDCM3BuOa", 1, "Lucious.Ledner87" },
                    { 68, 197, "Cassandre.Spinka@gmail.com", "Rose", "Dibbert", "oqMAMmXCBw", 3, "Donna.Cruickshank36" },
                    { 238, 265, "Makenna.Haley6@yahoo.com", "Elfrieda", "Lang", "3CQxQ0fO2D", 1, "Michael.Wunsch19" },
                    { 292, 123, "Jace.Zulauf@yahoo.com", "Clarabelle", "Boehm", "3VFIX9R5rc", 1, "Ulices66" },
                    { 66, 178, "Piper_Swaniawski2@gmail.com", "Estella", "Fritsch", "_HjvbkMwBE", 1, "Gwen75" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 30, "Estevan Cape", 24, "Scotty17@yahoo.com", "Brown - Kuhlman", 3, "(511) 126-9548", "www.Brown - Kuhlman.com" },
                    { 26, "Tia Manor", 111, "Bruce_Bergstrom@hotmail.com", "Yost Group", 77, "(868) 061-4227", "www.Yost Group.com" },
                    { 115, "Markus Mountains", 257, "Harvey_Mayert20@yahoo.com", "Nader - McDermott", 77, "(039) 184-1110", "www.Nader - McDermott.com" },
                    { 140, "Alice Rapid", 10, "Garrison48@hotmail.com", "Kling, Leannon and Block", 77, "(027) 511-1171", "www.Kling, Leannon and Block.com" },
                    { 112, "Evalyn Field", 208, "Lori27@yahoo.com", "Balistreri, Larson and Crist", 217, "(157) 551-5821", "www.Balistreri, Larson and Crist.com" },
                    { 116, "Felix Points", 243, "Blanche.Wilkinson@gmail.com", "Bergstrom, Oberbrunner and Carter", 217, "(429) 329-1689", "www.Bergstrom, Oberbrunner and Carter.com" },
                    { 66, "Ola Spurs", 107, "Donnell.White77@yahoo.com", "Weber - Lindgren", 155, "(670) 640-9052", "www.Weber - Lindgren.com" },
                    { 2, "Parker Garden", 106, "Euna_Nicolas@gmail.com", "Towne - Wilderman", 77, "(882) 835-1644", "www.Towne - Wilderman.com" },
                    { 20, "Anjali Mall", 105, "Myrtle_Pfeffer57@yahoo.com", "Waters Group", 132, "(140) 735-2197", "www.Waters Group.com" },
                    { 117, "Carson Falls", 222, "Stephany1@hotmail.com", "Howe, Kemmer and Schuster", 132, "(892) 472-0339", "www.Howe, Kemmer and Schuster.com" },
                    { 75, "Jeffrey Bypass", 297, "Solon3@hotmail.com", "Bechtelar - Runolfsdottir", 252, "(660) 002-3854", "www.Bechtelar - Runolfsdottir.com" },
                    { 37, "Kuvalis Branch", 46, "Vilma_Gerhold@yahoo.com", "Wilkinson, Torphy and Rutherford", 289, "(347) 833-8253", "www.Wilkinson, Torphy and Rutherford.com" },
                    { 35, "Tremblay Islands", 26, "Dakota.Windler@hotmail.com", "Jenkins, Wiza and Blick", 166, "(382) 023-9858", "www.Jenkins, Wiza and Blick.com" },
                    { 132, "Schultz Lake", 206, "Michaela_Ledner79@gmail.com", "Harris, Stoltenberg and Wiegand", 166, "(017) 501-1726", "www.Harris, Stoltenberg and Wiegand.com" },
                    { 65, "Gulgowski Junction", 96, "Connie_Stracke@yahoo.com", "Deckow, Swift and Hane", 58, "(874) 570-8803", "www.Deckow, Swift and Hane.com" },
                    { 50, "Helmer Turnpike", 134, "Ubaldo.Renner82@yahoo.com", "Gottlieb, Christiansen and Schneider", 132, "(016) 103-0160", "www.Gottlieb, Christiansen and Schneider.com" },
                    { 125, "Jerome Rapids", 244, "Adalberto1@yahoo.com", "Mohr and Sons", 240, "(921) 173-2219", "www.Mohr and Sons.com" },
                    { 122, "Anastacio Squares", 20, "Lance.Murray@yahoo.com", "Weissnat, Schmidt and Lesch", 240, "(128) 333-1411", "www.Weissnat, Schmidt and Lesch.com" },
                    { 13, "Myrl Forge", 44, "Jazmyn.Harvey@gmail.com", "Littel Group", 240, "(080) 260-2717", "www.Littel Group.com" },
                    { 78, "Fabian Lane", 129, "Abbigail10@hotmail.com", "Reynolds, Williamson and Tromp", 34, "(035) 641-1529", "www.Reynolds, Williamson and Tromp.com" },
                    { 52, "Freeda Mountain", 261, "Wilton54@gmail.com", "Yost - Bode", 167, "(194) 054-6262", "www.Yost - Bode.com" },
                    { 62, "Dallin Island", 76, "Doyle26@yahoo.com", "Kuvalis LLC", 167, "(948) 117-7966", "www.Kuvalis LLC.com" },
                    { 14, "Dolores Ridge", 175, "Octavia53@gmail.com", "Ratke - Parisian", 29, "(609) 052-4500", "www.Ratke - Parisian.com" },
                    { 19, "Brock Extension", 118, "Elna_Quitzon@gmail.com", "Williamson, Konopelski and Reichert", 29, "(088) 255-1769", "www.Williamson, Konopelski and Reichert.com" },
                    { 54, "Stiedemann Pine", 136, "David37@yahoo.com", "Bosco - Bashirian", 29, "(556) 795-7344", "www.Bosco - Bashirian.com" },
                    { 77, "Kiel Union", 137, "Lina.Boyer@yahoo.com", "Fisher Inc", 29, "(342) 195-1078", "www.Fisher Inc.com" },
                    { 135, "Magnolia Branch", 133, "Filomena.Grady@gmail.com", "Bauch - Streich", 127, "(963) 409-4820", "www.Bauch - Streich.com" },
                    { 148, "Edward Bridge", 194, "Angus98@hotmail.com", "Gutkowski Group", 127, "(969) 996-6221", "www.Gutkowski Group.com" },
                    { 29, "Leora Pines", 131, "Blaise.Hoeger13@gmail.com", "Johns - Pacocha", 171, "(213) 183-0611", "www.Johns - Pacocha.com" },
                    { 143, "Logan Station", 245, "Kiley53@gmail.com", "Hilll - DuBuque", 171, "(770) 187-6072", "www.Hilll - DuBuque.com" },
                    { 4, "Everett Club", 258, "Mina_Schmidt22@yahoo.com", "Borer Group", 268, "(338) 284-1647", "www.Borer Group.com" },
                    { 42, "Reichel Ports", 216, "Damien_Ankunding@gmail.com", "VonRueden LLC", 268, "(220) 325-6484", "www.VonRueden LLC.com" },
                    { 99, "Coy Stream", 105, "Alysa.Heller@gmail.com", "Walsh, Zieme and McDermott", 131, "(478) 681-4153", "www.Walsh, Zieme and McDermott.com" },
                    { 124, "Stracke Rapids", 252, "Terrance8@hotmail.com", "Bailey - Emmerich", 131, "(177) 172-8939", "www.Bailey - Emmerich.com" },
                    { 141, "Demetris Avenue", 238, "Gregoria.Pollich49@yahoo.com", "Mann - Stokes", 58, "(597) 920-9895", "www.Mann - Stokes.com" },
                    { 36, "Jaquan Street", 21, "Nicole.Greenfelder59@hotmail.com", "Boyer and Sons", 90, "(847) 358-3237", "www.Boyer and Sons.com" },
                    { 68, "Ronaldo Shoal", 254, "Mackenzie_Greenfelder40@yahoo.com", "Stamm and Sons", 153, "(229) 588-5937", "www.Stamm and Sons.com" },
                    { 44, "Roob Springs", 139, "Christophe_Stoltenberg@hotmail.com", "Ernser, Stroman and Stamm", 56, "(724) 475-0524", "www.Ernser, Stroman and Stamm.com" },
                    { 3, "Pfeffer Roads", 138, "Tillman_Mosciski@yahoo.com", "Cassin - Konopelski", 235, "(989) 837-8297", "www.Cassin - Konopelski.com" },
                    { 49, "Romaguera Ramp", 48, "Waldo_Jast90@gmail.com", "Lind and Sons", 235, "(379) 099-8519", "www.Lind and Sons.com" },
                    { 64, "Hickle Walks", 100, "Eli_Brown@gmail.com", "Rodriguez - Romaguera", 235, "(714) 659-8781", "www.Rodriguez - Romaguera.com" },
                    { 149, "Holly Flat", 23, "Liana.Wilderman38@gmail.com", "Kulas - Kling", 235, "(966) 173-5915", "www.Kulas - Kling.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 60, "Schuppe Key", 186, "Reynold_Gutkowski25@hotmail.com", "Hilpert, Hartmann and Maggio", 249, "(671) 216-4065", "www.Hilpert, Hartmann and Maggio.com" },
                    { 105, "Abagail Run", 258, "Kelsi45@yahoo.com", "Runolfsdottir - Wiza", 249, "(527) 247-8676", "www.Runolfsdottir - Wiza.com" },
                    { 24, "Dach Fords", 81, "Omari.Feest@hotmail.com", "Cummerata - Erdman", 196, "(977) 013-2688", "www.Cummerata - Erdman.com" },
                    { 82, "Delphine Groves", 62, "Holly_McDermott@yahoo.com", "Hagenes, Lakin and Hudson", 196, "(778) 225-3680", "www.Hagenes, Lakin and Hudson.com" },
                    { 95, "Maureen Parkway", 271, "Shirley57@yahoo.com", "Stark, Bayer and Hackett", 75, "(199) 743-3329", "www.Stark, Bayer and Hackett.com" },
                    { 51, "Steuber Divide", 14, "Alvina_Mills@yahoo.com", "Stracke - McDermott", 10, "(753) 035-5472", "www.Stracke - McDermott.com" },
                    { 55, "Leopoldo Ridges", 134, "Dahlia23@gmail.com", "Becker - Ward", 10, "(885) 585-6554", "www.Becker - Ward.com" },
                    { 47, "Dibbert Cliff", 63, "Doyle12@gmail.com", "Turcotte Group", 86, "(474) 651-7938", "www.Turcotte Group.com" },
                    { 57, "Edwardo Circles", 120, "Freddy.Kris10@yahoo.com", "Lindgren, Osinski and Bruen", 86, "(018) 101-5761", "www.Lindgren, Osinski and Bruen.com" },
                    { 79, "Armani Orchard", 214, "Kayla_Oberbrunner@gmail.com", "Jakubowski - Ruecker", 86, "(851) 327-1264", "www.Jakubowski - Ruecker.com" },
                    { 92, "Ahmad Branch", 154, "Colten.Kris@gmail.com", "Zieme, Denesik and Dooley", 86, "(537) 578-5299", "www.Zieme, Denesik and Dooley.com" },
                    { 142, "Letha Loaf", 153, "Toni.Bernhard11@gmail.com", "Dare - Kunze", 111, "(652) 624-2743", "www.Dare - Kunze.com" },
                    { 46, "Jeff Summit", 4, "Karli.Hudson11@gmail.com", "Moen Inc", 34, "(520) 297-6569", "www.Moen Inc.com" },
                    { 21, "Schultz Meadow", 48, "Raheem_Grady@hotmail.com", "Cruickshank - Reichert", 111, "(374) 605-3619", "www.Cruickshank - Reichert.com" },
                    { 69, "Oma Inlet", 39, "Pink39@hotmail.com", "Jast, Deckow and Jerde", 129, "(092) 209-4931", "www.Jast, Deckow and Jerde.com" },
                    { 73, "Kling Skyway", 265, "Tiara30@gmail.com", "Kirlin and Sons", 13, "(723) 996-4507", "www.Kirlin and Sons.com" },
                    { 87, "Lakin Walk", 12, "Austen93@yahoo.com", "Nienow Group", 39, "(992) 078-0714", "www.Nienow Group.com" },
                    { 130, "Dangelo Land", 28, "Destini64@gmail.com", "Gerlach Inc", 39, "(035) 401-6677", "www.Gerlach Inc.com" },
                    { 104, "Carroll Lakes", 130, "Alfred_Connelly@gmail.com", "Pfannerstill, Luettgen and Bayer", 65, "(880) 843-6323", "www.Pfannerstill, Luettgen and Bayer.com" },
                    { 121, "Heller Court", 240, "Haylie.Goodwin31@hotmail.com", "Kling, Wisozk and Halvorson", 65, "(085) 759-2676", "www.Kling, Wisozk and Halvorson.com" },
                    { 43, "Cloyd Village", 281, "Francesca.Senger@gmail.com", "Beier Group", 179, "(065) 655-4645", "www.Beier Group.com" },
                    { 119, "Reichel Island", 217, "Marc45@hotmail.com", "Mohr - Will", 83, "(792) 758-6956", "www.Mohr - Will.com" },
                    { 58, "Considine Hills", 234, "Gregory80@yahoo.com", "Jakubowski, Harber and Muller", 255, "(388) 776-2558", "www.Jakubowski, Harber and Muller.com" },
                    { 96, "Don Lock", 162, "Angie54@yahoo.com", "Gislason and Sons", 255, "(270) 756-0749", "www.Gislason and Sons.com" },
                    { 146, "Alek Squares", 251, "Christy.Gutkowski@yahoo.com", "Krajcik, Corkery and Ferry", 255, "(261) 908-0981", "www.Krajcik, Corkery and Ferry.com" },
                    { 23, "Bashirian Trafficway", 171, "April.Lynch@gmail.com", "Walsh, Dooley and Torp", 40, "(028) 737-8190", "www.Walsh, Dooley and Torp.com" },
                    { 147, "Zackary Falls", 127, "Pearlie51@yahoo.com", "Bechtelar and Sons", 40, "(893) 805-8506", "www.Bechtelar and Sons.com" },
                    { 25, "Wehner Port", 9, "Myles.Schinner@yahoo.com", "Parisian, Adams and Lind", 57, "(163) 163-0480", "www.Parisian, Adams and Lind.com" },
                    { 129, "Alden Vista", 300, "Earl1@yahoo.com", "Armstrong LLC", 57, "(675) 384-7209", "www.Armstrong LLC.com" },
                    { 136, "Thompson Springs", 212, "Amber.Bogan@yahoo.com", "Carroll LLC", 57, "(280) 823-2410", "www.Carroll LLC.com" },
                    { 17, "Moen Crest", 102, "Vida_Keebler98@yahoo.com", "Stiedemann - Morissette", 111, "(408) 032-4694", "www.Stiedemann - Morissette.com" },
                    { 67, "Stracke Spring", 82, "Estrella33@yahoo.com", "Abbott - Reinger", 6, "(874) 278-6692", "www.Abbott - Reinger.com" },
                    { 106, "Kris Motorway", 214, "Brittany.Feest@hotmail.com", "McCullough - Bartoletti", 13, "(209) 122-2350", "www.McCullough - Bartoletti.com" },
                    { 8, "Kris Court", 59, "Corine.Becker69@gmail.com", "Lueilwitz - Krajcik", 6, "(185) 366-3561", "www.Lueilwitz - Krajcik.com" },
                    { 74, "Barrett Green", 61, "Chauncey97@hotmail.com", "Erdman, Stanton and Fay", 274, "(497) 580-7750", "www.Erdman, Stanton and Fay.com" },
                    { 123, "Genesis Ports", 281, "Elfrieda48@yahoo.com", "Dare Group", 274, "(066) 411-0287", "www.Dare Group.com" },
                    { 83, "Ludwig Via", 202, "Lilla_Welch77@hotmail.com", "Corkery, Effertz and Kuvalis", 280, "(813) 203-5710", "www.Corkery, Effertz and Kuvalis.com" },
                    { 91, "Jakayla Trail", 268, "Nils.Dickinson22@gmail.com", "Weimann, Thiel and Schneider", 280, "(940) 285-9814", "www.Weimann, Thiel and Schneider.com" },
                    { 76, "Tre Squares", 251, "Marcia26@hotmail.com", "Welch, Shanahan and Runolfsdottir", 178, "(416) 770-9631", "www.Welch, Shanahan and Runolfsdottir.com" },
                    { 33, "Ocie Port", 250, "Larissa99@hotmail.com", "Bauch Inc", 20, "(117) 685-9936", "www.Bauch Inc.com" },
                    { 85, "Buckridge Ports", 118, "Elton.Mills@yahoo.com", "Schamberger - Olson", 20, "(812) 883-5589", "www.Schamberger - Olson.com" },
                    { 137, "Bergstrom Pine", 191, "Arnaldo_Collins@gmail.com", "Weimann - Rogahn", 20, "(581) 013-1558", "www.Weimann - Rogahn.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 41, "Boehm Divide", 253, "Jerrold.Baumbach@yahoo.com", "Conn LLC", 122, "(494) 207-1913", "www.Conn LLC.com" },
                    { 61, "Block Mountains", 237, "Bessie_Bins@hotmail.com", "Bashirian, Ledner and Bergnaum", 228, "(921) 804-6570", "www.Bashirian, Ledner and Bergnaum.com" },
                    { 114, "Reinhold Center", 237, "Tia44@yahoo.com", "Bechtelar, Renner and Schaden", 228, "(239) 437-8517", "www.Bechtelar, Renner and Schaden.com" },
                    { 45, "Streich Glen", 297, "Vivienne_Weimann78@gmail.com", "Botsford and Sons", 138, "(998) 241-3287", "www.Botsford and Sons.com" },
                    { 120, "Candelario Route", 284, "Judah.Graham@yahoo.com", "Baumbach Inc", 172, "(634) 126-5259", "www.Baumbach Inc.com" },
                    { 11, "Padberg Wells", 236, "Josue57@hotmail.com", "Abernathy Group", 70, "(653) 540-6482", "www.Abernathy Group.com" },
                    { 34, "Lucinda Fork", 131, "Roxanne_Gaylord@hotmail.com", "Mayer and Sons", 70, "(774) 879-8511", "www.Mayer and Sons.com" },
                    { 16, "Lucile Springs", 213, "Leda32@yahoo.com", "VonRueden, Turner and Schiller", 274, "(068) 027-6107", "www.VonRueden, Turner and Schiller.com" },
                    { 101, "Stracke Gateway", 282, "Mossie_Veum77@gmail.com", "Hilll - Nitzsche", 70, "(531) 686-5550", "www.Hilll - Nitzsche.com" },
                    { 5, "Lebsack Mills", 296, "Abelardo.Schiller19@yahoo.com", "Mraz - Morissette", 87, "(152) 950-3388", "www.Mraz - Morissette.com" },
                    { 28, "Feil Estates", 221, "Meggie_Harvey95@hotmail.com", "Kemmer LLC", 199, "(284) 354-6760", "www.Kemmer LLC.com" },
                    { 40, "Ignatius Ports", 286, "Cristina66@hotmail.com", "Koepp - Denesik", 6, "(561) 674-0086", "www.Koepp - Denesik.com" },
                    { 118, "Jonas Gardens", 236, "Marielle_Torphy@hotmail.com", "Farrell Inc", 3, "(509) 672-8208", "www.Farrell Inc.com" },
                    { 18, "Alexander Loaf", 47, "Elizabeth.Volkman@hotmail.com", "Hills - VonRueden", 46, "(910) 132-9220", "www.Hills - VonRueden.com" },
                    { 31, "Lowe Road", 266, "Tate.Jones@gmail.com", "Botsford - Reynolds", 46, "(545) 925-9070", "www.Botsford - Reynolds.com" },
                    { 39, "Stewart Way", 84, "Therese56@gmail.com", "Casper - Schamberger", 46, "(876) 871-8959", "www.Casper - Schamberger.com" },
                    { 93, "Carmel Drive", 268, "Gretchen.McCullough@yahoo.com", "Emmerich, Kutch and Steuber", 46, "(465) 798-2480", "www.Emmerich, Kutch and Steuber.com" },
                    { 94, "Braun Brook", 248, "Romaine65@gmail.com", "Dare - Reichert", 46, "(204) 434-8438", "www.Dare - Reichert.com" },
                    { 138, "Josephine Alley", 139, "Dessie90@gmail.com", "Grimes - Dare", 46, "(565) 000-6913", "www.Grimes - Dare.com" },
                    { 10, "Effertz Landing", 200, "Ludwig_Batz46@gmail.com", "Kshlerin, Ledner and Predovic", 161, "(731) 934-6026", "www.Kshlerin, Ledner and Predovic.com" },
                    { 86, "Abbott Cape", 248, "Vivian1@hotmail.com", "Hettinger - Miller", 161, "(783) 212-8943", "www.Hettinger - Miller.com" },
                    { 63, "Guadalupe Fort", 19, "Jordi11@gmail.com", "Boyle, Fadel and DuBuque", 110, "(715) 472-7846", "www.Boyle, Fadel and DuBuque.com" },
                    { 81, "O'Hara Road", 298, "Demetrius60@yahoo.com", "Schaden and Sons", 110, "(064) 848-0853", "www.Schaden and Sons.com" },
                    { 90, "Ida Via", 182, "Chloe_Bosco@yahoo.com", "Carter Group", 110, "(407) 970-2974", "www.Carter Group.com" },
                    { 145, "Harber Branch", 81, "Percival.Schoen16@yahoo.com", "Stark and Sons", 110, "(248) 528-7790", "www.Stark and Sons.com" },
                    { 127, "Lehner Knoll", 153, "Kane.Huels@hotmail.com", "Feil, Erdman and Fay", 272, "(627) 844-7986", "www.Feil, Erdman and Fay.com" },
                    { 133, "Rosetta Orchard", 238, "Haven_Gusikowski@gmail.com", "Mante and Sons", 199, "(997) 597-2137", "www.Mante and Sons.com" },
                    { 7, "Lafayette Mills", 87, "Heber_McKenzie83@gmail.com", "Dooley, Gulgowski and Johnston", 82, "(541) 746-2960", "www.Dooley, Gulgowski and Johnston.com" },
                    { 48, "Quinton Curve", 162, "Albina.Zieme@gmail.com", "Kshlerin - Borer", 31, "(793) 139-5953", "www.Kshlerin - Borer.com" },
                    { 131, "Beatty Hills", 114, "Meaghan.Cronin@hotmail.com", "Green, Becker and Weissnat", 82, "(427) 392-8447", "www.Green, Becker and Weissnat.com" },
                    { 100, "Herzog Avenue", 60, "Naomie14@hotmail.com", "Kshlerin Inc", 148, "(938) 454-7549", "www.Kshlerin Inc.com" },
                    { 103, "Bria Underpass", 89, "Cameron95@yahoo.com", "Koch and Sons", 148, "(424) 864-3761", "www.Koch and Sons.com" },
                    { 15, "Guy Dale", 80, "Adelia_Pollich@hotmail.com", "Mitchell - Hirthe", 50, "(837) 683-0763", "www.Mitchell - Hirthe.com" },
                    { 70, "Patricia Underpass", 132, "Max_Friesen88@gmail.com", "McKenzie - Ferry", 102, "(405) 480-8488", "www.McKenzie - Ferry.com" },
                    { 89, "Hamill Hollow", 291, "Theron_Nikolaus@gmail.com", "Harvey - Zulauf", 102, "(216) 569-5203", "www.Harvey - Zulauf.com" },
                    { 144, "Roselyn Lane", 43, "Angeline_Stokes@yahoo.com", "Schaden Inc", 256, "(714) 983-6002", "www.Schaden Inc.com" },
                    { 107, "Jan Forges", 109, "Lavina.Pfannerstill@yahoo.com", "Barrows - Bogan", 233, "(277) 227-6949", "www.Barrows - Bogan.com" },
                    { 88, "Ericka Union", 192, "Cale_Collins@gmail.com", "Turner, Luettgen and Gerhold", 148, "(736) 107-7518", "www.Turner, Luettgen and Gerhold.com" },
                    { 6, "Garett Fords", 158, "Anjali.Harvey@gmail.com", "Smitham Inc", 64, "(795) 292-0662", "www.Smitham Inc.com" },
                    { 56, "Terry Lake", 114, "Sydni_Schuppe36@hotmail.com", "Gleason, Boyle and Weimann", 64, "(472) 681-9445", "www.Gleason, Boyle and Weimann.com" },
                    { 111, "Gregory Island", 17, "Gladys93@gmail.com", "Wolff, McKenzie and O'Kon", 64, "(905) 958-8481", "www.Wolff, McKenzie and O'Kon.com" },
                    { 113, "Otis Alley", 50, "Eliane_Towne39@gmail.com", "Mraz and Sons", 64, "(927) 099-3895", "www.Mraz and Sons.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 80, "Beatty Fork", 213, "Thora70@hotmail.com", "Greenholt, Gottlieb and Orn", 263, "(643) 873-8365", "www.Greenholt, Gottlieb and Orn.com" },
                    { 98, "Arlene Run", 15, "Ruby.Hoeger@hotmail.com", "Cummings - Kihn", 97, "(495) 877-3325", "www.Cummings - Kihn.com" },
                    { 110, "Monroe Mountains", 207, "Joseph.Bahringer61@hotmail.com", "Davis, Gerhold and Kling", 82, "(488) 734-7415", "www.Davis, Gerhold and Kling.com" },
                    { 102, "Flo Roads", 105, "Shaina.Von@hotmail.com", "Roberts, Batz and Kiehn", 97, "(772) 389-6572", "www.Roberts, Batz and Kiehn.com" },
                    { 53, "Candelario Crest", 287, "Kaitlin10@hotmail.com", "Rice - Borer", 64, "(541) 289-3897", "www.Rice - Borer.com" },
                    { 59, "Pacocha Island", 215, "Alvis_Trantow@hotmail.com", "O'Conner - Funk", 148, "(093) 742-7075", "www.O'Conner - Funk.com" },
                    { 150, "Darron Manor", 217, "Terrance10@hotmail.com", "Hane, Satterfield and Emard", 256, "(051) 168-4419", "www.Hane, Satterfield and Emard.com" },
                    { 22, "Lucious Centers", 278, "Alverta72@yahoo.com", "Feest, Sipes and Herman", 148, "(706) 255-4623", "www.Feest, Sipes and Herman.com" },
                    { 139, "Mann Keys", 282, "Cristopher_Daugherty@yahoo.com", "Schroeder LLC", 251, "(403) 222-9812", "www.Schroeder LLC.com" },
                    { 32, "Ondricka Prairie", 98, "Minerva_Blanda@hotmail.com", "Collier, Schaden and Hansen", 68, "(167) 344-0043", "www.Collier, Schaden and Hansen.com" },
                    { 84, "Alana Expressway", 34, "Keagan_Labadie@gmail.com", "Douglas Group", 68, "(148) 117-6653", "www.Douglas Group.com" },
                    { 108, "Johnson Lane", 155, "Alva.Lesch51@hotmail.com", "Schulist, Ward and Bayer", 68, "(602) 248-5529", "www.Schulist, Ward and Bayer.com" },
                    { 71, "Ebert Meadow", 48, "Joy_Wilderman@yahoo.com", "Larson - Hane", 286, "(764) 342-6847", "www.Larson - Hane.com" },
                    { 38, "Farrell Lake", 70, "Hubert_Balistreri@yahoo.com", "Howell Inc", 79, "(882) 460-9148", "www.Howell Inc.com" },
                    { 27, "Ledner Loop", 249, "Elena45@hotmail.com", "Rosenbaum Group", 192, "(587) 405-6841", "www.Rosenbaum Group.com" },
                    { 128, "Ruben Lodge", 175, "Susan_Beatty@gmail.com", "Nitzsche Inc", 286, "(789) 176-7633", "www.Nitzsche Inc.com" },
                    { 1, "Lloyd Trail", 100, "Lesley93@yahoo.com", "Fadel, Mitchell and Kozey", 84, "(655) 578-9981", "www.Fadel, Mitchell and Kozey.com" },
                    { 9, "Moen Camp", 105, "Ezequiel_Berge93@hotmail.com", "Simonis - Hayes", 84, "(694) 930-1986", "www.Simonis - Hayes.com" },
                    { 12, "Elijah Summit", 73, "Ashley1@gmail.com", "Stark - Gislason", 84, "(523) 530-8073", "www.Stark - Gislason.com" },
                    { 72, "Marcus Glens", 72, "Julian.Wisozk@yahoo.com", "Bashirian Group", 84, "(051) 366-1875", "www.Bashirian Group.com" },
                    { 109, "Champlin Overpass", 66, "Jazmyn_Marks@yahoo.com", "Towne LLC", 84, "(073) 502-1487", "www.Towne LLC.com" },
                    { 126, "Osbaldo Village", 228, "Buster.Boyle@yahoo.com", "Christiansen - Lockman", 84, "(663) 468-7595", "www.Christiansen - Lockman.com" },
                    { 97, "Nader Centers", 261, "Keith.Simonis19@yahoo.com", "Adams Inc", 192, "(667) 813-9708", "www.Adams Inc.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 82, new DateTime(2021, 4, 17, 3, 22, 25, 878, DateTimeKind.Local).AddTicks(4906), 461009, 1, "6912714" },
                    { 74, new DateTime(2020, 11, 26, 3, 8, 59, 452, DateTimeKind.Local).AddTicks(9015), 889168, 93, "2215056" },
                    { 29, new DateTime(2020, 11, 1, 20, 44, 11, 182, DateTimeKind.Local).AddTicks(9991), 425167, 1, "7095478" },
                    { 75, new DateTime(2020, 12, 19, 23, 6, 27, 652, DateTimeKind.Local).AddTicks(4071), 171179, 61, "5643260" },
                    { 52, new DateTime(2020, 11, 26, 1, 19, 24, 730, DateTimeKind.Local).AddTicks(4904), 996586, 17, "4165432" },
                    { 69, new DateTime(2021, 8, 4, 12, 39, 47, 426, DateTimeKind.Local).AddTicks(1805), 707882, 39, "7464366" },
                    { 43, new DateTime(2021, 6, 27, 16, 39, 24, 514, DateTimeKind.Local).AddTicks(7246), 861699, 39, "1710340" },
                    { 38, new DateTime(2021, 5, 26, 15, 3, 47, 517, DateTimeKind.Local).AddTicks(130), 101287, 93, "4948538" },
                    { 77, new DateTime(2020, 11, 21, 19, 20, 4, 564, DateTimeKind.Local).AddTicks(9885), 507456, 67, "4193150" },
                    { 68, new DateTime(2021, 6, 13, 5, 11, 36, 914, DateTimeKind.Local).AddTicks(5670), 186979, 53, "9618253" },
                    { 32, new DateTime(2021, 2, 5, 12, 24, 3, 547, DateTimeKind.Local).AddTicks(4478), 903480, 53, "7379201" },
                    { 59, new DateTime(2021, 7, 6, 12, 10, 22, 944, DateTimeKind.Local).AddTicks(3873), 434657, 52, "1982917" },
                    { 20, new DateTime(2021, 6, 8, 4, 1, 31, 811, DateTimeKind.Local).AddTicks(2802), 906588, 74, "4564322" },
                    { 42, new DateTime(2021, 6, 8, 11, 6, 14, 870, DateTimeKind.Local).AddTicks(2873), 380738, 10, "6093029" },
                    { 62, new DateTime(2020, 10, 26, 2, 54, 40, 508, DateTimeKind.Local).AddTicks(935), 609884, 95, "9291408" },
                    { 24, new DateTime(2020, 10, 1, 4, 51, 27, 192, DateTimeKind.Local).AddTicks(7547), 226883, 10, "5365276" },
                    { 78, new DateTime(2020, 10, 15, 11, 20, 55, 366, DateTimeKind.Local).AddTicks(6206), 713297, 6, "6461101" },
                    { 6, new DateTime(2021, 3, 11, 1, 26, 52, 459, DateTimeKind.Local).AddTicks(5492), 451732, 93, "6166728" },
                    { 7, new DateTime(2021, 1, 14, 7, 52, 13, 55, DateTimeKind.Local).AddTicks(4195), 679133, 82, "8436794" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 10, new DateTime(2021, 7, 31, 13, 7, 24, 732, DateTimeKind.Local).AddTicks(3413), 953536, 71, "8086415" },
                    { 27, new DateTime(2020, 10, 5, 6, 52, 35, 883, DateTimeKind.Local).AddTicks(2558), 178032, 82, "3249509" },
                    { 54, new DateTime(2021, 3, 22, 8, 32, 26, 883, DateTimeKind.Local).AddTicks(4048), 746010, 71, "3412136" },
                    { 40, new DateTime(2021, 5, 4, 13, 28, 26, 740, DateTimeKind.Local).AddTicks(3219), 273600, 67, "8049080" },
                    { 49, new DateTime(2020, 9, 5, 23, 48, 4, 886, DateTimeKind.Local).AddTicks(6140), 295399, 71, "4226861" },
                    { 11, new DateTime(2021, 6, 30, 11, 49, 37, 193, DateTimeKind.Local).AddTicks(6683), 27151, 22, "7848439" },
                    { 5, new DateTime(2021, 3, 16, 11, 46, 52, 429, DateTimeKind.Local).AddTicks(1826), 625126, 22, "4791921" },
                    { 35, new DateTime(2020, 12, 24, 19, 1, 19, 469, DateTimeKind.Local).AddTicks(9216), 667822, 19, "2365926" },
                    { 34, new DateTime(2021, 1, 20, 10, 52, 37, 878, DateTimeKind.Local).AddTicks(4335), 698223, 29, "4157874" },
                    { 37, new DateTime(2020, 10, 14, 12, 11, 15, 471, DateTimeKind.Local).AddTicks(2841), 526240, 64, "1744197" },
                    { 70, new DateTime(2021, 8, 9, 14, 23, 12, 316, DateTimeKind.Local).AddTicks(876), 6422, 77, "8210180" },
                    { 71, new DateTime(2021, 7, 19, 14, 8, 2, 408, DateTimeKind.Local).AddTicks(105), 836046, 88, "4365229" },
                    { 50, new DateTime(2021, 4, 10, 16, 23, 57, 350, DateTimeKind.Local).AddTicks(8367), 953265, 88, "1203057" },
                    { 64, new DateTime(2021, 4, 19, 16, 2, 51, 281, DateTimeKind.Local).AddTicks(7895), 223112, 48, "7742930" },
                    { 36, new DateTime(2021, 5, 13, 9, 12, 14, 801, DateTimeKind.Local).AddTicks(284), 208403, 48, "4066181" },
                    { 46, new DateTime(2021, 6, 2, 3, 7, 10, 590, DateTimeKind.Local).AddTicks(3530), 152151, 41, "9899625" },
                    { 2, new DateTime(2021, 5, 29, 1, 8, 26, 63, DateTimeKind.Local).AddTicks(2562), 501891, 41, "6989693" },
                    { 73, new DateTime(2020, 9, 10, 15, 22, 8, 3, DateTimeKind.Local).AddTicks(4595), 508257, 82, "8904721" },
                    { 41, new DateTime(2021, 1, 10, 5, 6, 11, 250, DateTimeKind.Local).AddTicks(9011), 227137, 82, "9543021" },
                    { 8, new DateTime(2021, 4, 10, 22, 55, 10, 240, DateTimeKind.Local).AddTicks(4857), 151524, 82, "8976853" },
                    { 28, new DateTime(2021, 3, 2, 19, 52, 28, 460, DateTimeKind.Local).AddTicks(8575), 631307, 67, "3244981" },
                    { 53, new DateTime(2021, 2, 27, 9, 43, 49, 693, DateTimeKind.Local).AddTicks(4463), 229968, 66, "3855908" },
                    { 18, new DateTime(2021, 5, 6, 18, 9, 36, 408, DateTimeKind.Local).AddTicks(6017), 718603, 36, "8222847" },
                    { 14, new DateTime(2020, 11, 10, 10, 55, 35, 270, DateTimeKind.Local).AddTicks(1628), 901929, 2, "7672944" },
                    { 55, new DateTime(2020, 10, 25, 16, 13, 39, 27, DateTimeKind.Local).AddTicks(695), 590074, 58, "4915017" },
                    { 13, new DateTime(2020, 8, 24, 0, 4, 42, 928, DateTimeKind.Local).AddTicks(5936), 241215, 58, "3252298" },
                    { 83, new DateTime(2020, 11, 11, 11, 56, 14, 312, DateTimeKind.Local).AddTicks(5407), 882398, 13, "2194648" },
                    { 67, new DateTime(2021, 5, 12, 10, 57, 25, 130, DateTimeKind.Local).AddTicks(7002), 611539, 13, "2407099" },
                    { 12, new DateTime(2021, 7, 23, 4, 50, 2, 76, DateTimeKind.Local).AddTicks(972), 911404, 13, "1351649" },
                    { 81, new DateTime(2020, 10, 18, 7, 40, 10, 64, DateTimeKind.Local).AddTicks(6596), 288297, 3, "1213515" },
                    { 23, new DateTime(2020, 11, 24, 21, 58, 6, 531, DateTimeKind.Local).AddTicks(6453), 559054, 16, "9684096" },
                    { 3, new DateTime(2021, 1, 6, 23, 28, 2, 288, DateTimeKind.Local).AddTicks(246), 553565, 16, "4804462" },
                    { 31, new DateTime(2021, 2, 1, 17, 52, 19, 201, DateTimeKind.Local).AddTicks(3556), 581636, 8, "6139321" },
                    { 16, new DateTime(2020, 12, 22, 23, 36, 55, 835, DateTimeKind.Local).AddTicks(9755), 541554, 8, "5748860" },
                    { 15, new DateTime(2021, 1, 11, 9, 55, 33, 87, DateTimeKind.Local).AddTicks(7716), 547782, 8, "9196044" },
                    { 48, new DateTime(2021, 6, 18, 7, 44, 30, 763, DateTimeKind.Local).AddTicks(3570), 516375, 84, "8043781" },
                    { 45, new DateTime(2021, 7, 20, 17, 15, 23, 512, DateTimeKind.Local).AddTicks(2353), 5854, 84, "3853167" },
                    { 66, new DateTime(2020, 8, 22, 3, 57, 20, 137, DateTimeKind.Local).AddTicks(824), 767092, 45, "7110988" },
                    { 80, new DateTime(2020, 10, 1, 21, 3, 5, 255, DateTimeKind.Local).AddTicks(3554), 972747, 7, "2237861" },
                    { 26, new DateTime(2021, 4, 1, 8, 19, 39, 316, DateTimeKind.Local).AddTicks(7614), 362412, 98, "1651684" },
                    { 57, new DateTime(2020, 8, 18, 10, 29, 21, 316, DateTimeKind.Local).AddTicks(7856), 31874, 2, "6482668" },
                    { 76, new DateTime(2021, 3, 3, 17, 23, 39, 676, DateTimeKind.Local).AddTicks(3344), 8715, 2, "2656755" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 25, new DateTime(2020, 9, 2, 8, 4, 49, 700, DateTimeKind.Local).AddTicks(6616), 828182, 34, "6187045" },
                    { 19, new DateTime(2020, 9, 28, 18, 11, 7, 471, DateTimeKind.Local).AddTicks(4787), 504170, 43, "5092953" },
                    { 61, new DateTime(2021, 5, 1, 5, 24, 6, 796, DateTimeKind.Local).AddTicks(6563), 131142, 31, "9376404" },
                    { 44, new DateTime(2020, 11, 14, 14, 43, 11, 433, DateTimeKind.Local).AddTicks(4565), 585086, 31, "9603683" },
                    { 60, new DateTime(2020, 10, 10, 7, 2, 59, 526, DateTimeKind.Local).AddTicks(9387), 78579, 51, "6099808" },
                    { 56, new DateTime(2020, 9, 6, 5, 51, 18, 110, DateTimeKind.Local).AddTicks(211), 335535, 91, "7131934" },
                    { 30, new DateTime(2020, 12, 27, 20, 11, 47, 359, DateTimeKind.Local).AddTicks(6281), 986844, 91, "1202993" },
                    { 21, new DateTime(2021, 2, 5, 20, 20, 9, 462, DateTimeKind.Local).AddTicks(8896), 614540, 91, "6980272" },
                    { 72, new DateTime(2021, 7, 16, 20, 36, 21, 757, DateTimeKind.Local).AddTicks(451), 228515, 76, "5617200" },
                    { 63, new DateTime(2021, 1, 26, 18, 37, 42, 861, DateTimeKind.Local).AddTicks(2859), 318531, 18, "2682588" },
                    { 4, new DateTime(2021, 1, 26, 0, 12, 22, 874, DateTimeKind.Local).AddTicks(9723), 737581, 47, "4720287" },
                    { 51, new DateTime(2021, 3, 16, 13, 56, 29, 949, DateTimeKind.Local).AddTicks(159), 628954, 30, "5020318" },
                    { 17, new DateTime(2020, 12, 3, 2, 19, 4, 267, DateTimeKind.Local).AddTicks(8266), 983268, 50, "5000431" },
                    { 9, new DateTime(2020, 9, 30, 3, 8, 58, 482, DateTimeKind.Local).AddTicks(6207), 741338, 44, "2903126" },
                    { 79, new DateTime(2020, 9, 21, 12, 30, 32, 794, DateTimeKind.Local).AddTicks(980), 994001, 57, "7253565" },
                    { 65, new DateTime(2020, 11, 29, 13, 30, 8, 481, DateTimeKind.Local).AddTicks(8402), 703980, 35, "1652744" },
                    { 1, new DateTime(2021, 4, 2, 5, 54, 30, 270, DateTimeKind.Local).AddTicks(1987), 529524, 35, "5054773" },
                    { 47, new DateTime(2020, 9, 8, 1, 26, 23, 923, DateTimeKind.Local).AddTicks(504), 496923, 43, "3511361" },
                    { 33, new DateTime(2021, 3, 26, 16, 54, 0, 997, DateTimeKind.Local).AddTicks(8044), 879849, 43, "6793378" },
                    { 22, new DateTime(2021, 2, 4, 4, 35, 28, 873, DateTimeKind.Local).AddTicks(1818), 120545, 43, "1875960" },
                    { 39, new DateTime(2020, 9, 17, 3, 27, 48, 896, DateTimeKind.Local).AddTicks(2639), 776455, 50, "9605204" },
                    { 58, new DateTime(2020, 10, 13, 0, 9, 48, 260, DateTimeKind.Local).AddTicks(4239), 298774, 98, "5021389" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 78, 80, 81, 561202, new DateTime(2020, 9, 25, 23, 34, 38, 123, DateTimeKind.Local).AddTicks(1240), "Qui et ipsa ut.\nQuam ut sint dolorem aliquam laborum nobis corporis necessitatibus nostrum.\nNostrum dolor veritatis reprehenderit ut quibusdam iusto molestiae maiores.\nAut omnis non itaque nam repellendus perspiciatis." },
                    { 237, 32, 16, 71710, new DateTime(2021, 2, 26, 18, 33, 35, 103, DateTimeKind.Local).AddTicks(3636), "tempora" },
                    { 311, 32, 132, 876157, new DateTime(2021, 4, 7, 16, 17, 2, 883, DateTimeKind.Local).AddTicks(2230), "Quidem amet quibusdam facilis quam corporis in quaerat voluptatem voluptates. Odio perspiciatis perferendis necessitatibus natus doloremque. Ut quo eius fugiat aut dolorem commodi rerum. Molestiae nobis ducimus vel aut. Consectetur asperiores alias sunt eligendi." },
                    { 555, 32, 91, 863729, new DateTime(2021, 3, 2, 19, 34, 20, 385, DateTimeKind.Local).AddTicks(1079), "Aut id amet consectetur nihil.\nEveniet beatae sed id recusandae temporibus eligendi mollitia dolorem.\nEius ad laborum ratione vitae delectus est esse non dicta." },
                    { 559, 32, 47, 23268, new DateTime(2020, 11, 4, 19, 17, 5, 324, DateTimeKind.Local).AddTicks(6556), "Eveniet iste id aliquam voluptatibus aut odio. Numquam ratione iste dignissimos. Et perferendis praesentium modi ipsum sint. Ea similique non." },
                    { 597, 32, 6, 302598, new DateTime(2021, 6, 15, 5, 15, 10, 545, DateTimeKind.Local).AddTicks(6027), "Aut voluptas reprehenderit nihil et perspiciatis sint quo omnis unde." },
                    { 22, 68, 145, 981072, new DateTime(2021, 6, 25, 11, 32, 18, 742, DateTimeKind.Local).AddTicks(8105), "Quia ad quam necessitatibus quo cum debitis qui. Est excepturi ab beatae. Nulla excepturi possimus quam deleniti sed sed consequatur. Quam similique praesentium aut." },
                    { 192, 32, 49, 906841, new DateTime(2021, 2, 26, 16, 37, 12, 516, DateTimeKind.Local).AddTicks(3303), "Velit temporibus iste nihil similique ipsam molestiae sit." },
                    { 156, 68, 26, 38582, new DateTime(2021, 6, 6, 0, 7, 39, 179, DateTimeKind.Local).AddTicks(5852), "fugiat" },
                    { 174, 68, 47, 367735, new DateTime(2021, 4, 23, 7, 26, 19, 127, DateTimeKind.Local).AddTicks(8146), "Quas maxime dolor et necessitatibus enim eos cumque magni magnam.\nAspernatur est voluptas ducimus qui excepturi amet eveniet voluptatem explicabo.\nQuaerat eum et rerum." },
                    { 284, 49, 138, 705368, new DateTime(2021, 4, 7, 1, 54, 21, 420, DateTimeKind.Local).AddTicks(768), "Earum et quo assumenda accusamus est autem sequi molestias minus. Architecto quibusdam reprehenderit eos tempora neque voluptatem dicta. Sed vero quasi architecto corporis incidunt atque omnis. Voluptates a omnis ad sit." },
                    { 20, 6, 10, 615203, new DateTime(2021, 4, 24, 2, 22, 59, 548, DateTimeKind.Local).AddTicks(5283), "Repellendus occaecati assumenda ducimus et reprehenderit ea voluptatem.\nBeatae rem qui atque.\nEveniet nesciunt velit sunt mollitia corporis et.\nEnim dolorum vel quis atque perspiciatis voluptas.\nAccusamus velit aut mollitia porro eius minima.\nOfficiis accusamus temporibus in qui libero omnis." },
                    { 21, 6, 136, 632998, new DateTime(2021, 6, 19, 5, 18, 18, 950, DateTimeKind.Local).AddTicks(664), "Quas ut iste accusantium aliquam non." },
                    { 31, 6, 112, 816925, new DateTime(2020, 11, 21, 16, 57, 41, 851, DateTimeKind.Local).AddTicks(5648), "Omnis quos possimus deleniti doloribus quia nihil quia." },
                    { 51, 6, 48, 812644, new DateTime(2021, 8, 4, 13, 45, 43, 799, DateTimeKind.Local).AddTicks(1034), "Deserunt quia quis tempora similique est minus atque et voluptatem.\nConsequatur itaque quia.\nQuod deserunt tenetur voluptates facere animi occaecati." },
                    { 164, 68, 56, 323477, new DateTime(2020, 11, 7, 0, 33, 36, 981, DateTimeKind.Local).AddTicks(4732), "Suscipit ab sit facilis excepturi rerum eos reprehenderit.\nAssumenda expedita dolores voluptates temporibus et ullam alias sint.\nEum velit ut repudiandae illo tenetur commodi.\nUnde aut temporibus commodi aspernatur corporis maiores." },
                    { 147, 32, 60, 534143, new DateTime(2020, 10, 22, 22, 20, 19, 473, DateTimeKind.Local).AddTicks(1140), "Iste vel rem consequatur voluptas et autem porro debitis amet.\nVel debitis dicta rerum enim enim qui et.\nAperiam incidunt sit blanditiis expedita.\nMinus ut magnam.\nDignissimos velit nemo nesciunt dolorem beatae quis consequatur architecto perferendis." },
                    { 581, 59, 55, 197626, new DateTime(2021, 5, 23, 5, 56, 11, 390, DateTimeKind.Local).AddTicks(3011), "Fugiat laborum commodi.\nRatione dolor fugiat voluptas." },
                    { 551, 59, 74, 103964, new DateTime(2021, 1, 5, 23, 32, 4, 576, DateTimeKind.Local).AddTicks(7314), "Odit veritatis ipsa quisquam assumenda repellendus sit." },
                    { 173, 42, 101, 487416, new DateTime(2021, 6, 12, 17, 55, 40, 804, DateTimeKind.Local).AddTicks(4957), "Ipsa consequatur cupiditate molestiae sed ullam.\nTempora aut officia dolores ea tempore laborum totam praesentium.\nItaque sint consequatur.\nDistinctio molestias quidem dolorum." },
                    { 575, 42, 111, 928015, new DateTime(2021, 5, 16, 8, 50, 24, 532, DateTimeKind.Local).AddTicks(4410), "Quis non voluptas ea quos ipsa." },
                    { 63, 20, 80, 668976, new DateTime(2020, 11, 9, 21, 50, 32, 730, DateTimeKind.Local).AddTicks(5589), "Consequatur velit repellat.\nQuo ratione dolorum laboriosam sit magnam nesciunt nulla.\nDicta ut et maiores ut voluptates reprehenderit blanditiis aut odit.\nEum illo adipisci.\nQuo est et aut." },
                    { 89, 20, 92, 875666, new DateTime(2020, 10, 30, 19, 9, 2, 762, DateTimeKind.Local).AddTicks(9671), "Possimus architecto aliquid aspernatur architecto.\nDoloremque fugiat delectus qui culpa." },
                    { 93, 20, 60, 590664, new DateTime(2020, 8, 14, 1, 42, 47, 608, DateTimeKind.Local).AddTicks(4415), "Neque error magnam magni enim molestiae nesciunt autem est porro. Tempore similique inventore omnis debitis aperiam eaque. Tempore molestias ut rerum aut perferendis autem error assumenda. Eaque voluptatem voluptatem ipsum quia eum qui quia ullam assumenda. Ut veritatis quas nostrum ea nisi laborum nemo." },
                    { 124, 20, 116, 502488, new DateTime(2021, 5, 28, 10, 27, 30, 580, DateTimeKind.Local).AddTicks(4714), "quia" },
                    { 142, 20, 54, 527122, new DateTime(2021, 6, 28, 4, 46, 5, 695, DateTimeKind.Local).AddTicks(3898), "Rem repudiandae laudantium qui exercitationem ut laboriosam.\nOfficiis veniam natus iste.\nEt officia et ut sunt." },
                    { 183, 20, 114, 48668, new DateTime(2021, 3, 3, 5, 2, 3, 570, DateTimeKind.Local).AddTicks(3395), "Consequatur voluptate est exercitationem voluptas vel doloribus provident veritatis voluptatem.\nNobis ipsa dolorum vitae sed adipisci error nisi quia.\nDistinctio ullam laudantium est doloremque.\nAut debitis doloremque nihil natus commodi aliquid.\nSit dolor repudiandae exercitationem.\nEa optio ullam doloremque atque et quasi omnis velit dolor." },
                    { 268, 20, 12, 64275, new DateTime(2021, 5, 15, 10, 43, 52, 298, DateTimeKind.Local).AddTicks(9221), "Veniam ipsum nemo quidem cumque.\nQui id at corporis.\nVel quibusdam est et doloribus laudantium aut.\nQuidem doloribus ipsa autem cupiditate est nihil eos.\nNemo ex expedita adipisci." },
                    { 298, 20, 87, 630895, new DateTime(2021, 3, 19, 2, 49, 21, 292, DateTimeKind.Local).AddTicks(9818), "Ex pariatur eos.\nCorrupti corrupti vel optio." },
                    { 307, 20, 50, 329533, new DateTime(2020, 10, 28, 18, 38, 26, 541, DateTimeKind.Local).AddTicks(6971), "Fugit omnis eligendi ipsa voluptas quia aut omnis error tenetur. Quia distinctio rerum quo voluptatem fuga repellat non. Similique odio iure quis libero voluptatum. Sequi distinctio doloribus eveniet ad. Sit et voluptatem expedita qui unde. Explicabo vel hic consequatur eligendi porro esse reiciendis praesentium." },
                    { 508, 20, 39, 417086, new DateTime(2021, 3, 18, 17, 46, 44, 149, DateTimeKind.Local).AddTicks(1657), "Minus fuga laborum harum minus perspiciatis fuga natus error.\nCommodi neque amet deleniti quia.\nVoluptas molestiae et alias non officiis voluptas magnam.\nAssumenda voluptatibus debitis natus.\nArchitecto et sed.\nDolor ut iure ut deserunt aut laborum." },
                    { 323, 49, 147, 824118, new DateTime(2021, 6, 20, 13, 59, 29, 489, DateTimeKind.Local).AddTicks(7517), "Perspiciatis enim vero. Et voluptatibus illo non maiores vel optio enim. Excepturi in qui autem. In fuga odit aut non recusandae officiis accusamus animi ut. Nesciunt impedit sint. Molestiae quis culpa aut expedita asperiores occaecati laudantium molestiae voluptatem." },
                    { 405, 59, 7, 583497, new DateTime(2020, 12, 12, 9, 9, 55, 597, DateTimeKind.Local).AddTicks(3521), "Pariatur commodi corrupti odio." },
                    { 486, 59, 84, 842388, new DateTime(2021, 4, 11, 8, 59, 2, 172, DateTimeKind.Local).AddTicks(315), "Saepe quia nobis sint tempora aut dolores. Expedita ab esse libero cupiditate nesciunt sit repellendus id. Nostrum asperiores placeat dolores dolorem sint error in autem. Laboriosam quo non explicabo voluptatibus quisquam consequatur eaque. Ullam ab odio earum qui." },
                    { 73, 6, 79, 35531, new DateTime(2020, 8, 18, 8, 50, 11, 96, DateTimeKind.Local).AddTicks(1981), "Aut esse aut ut ad repudiandae odit." },
                    { 100, 6, 27, 445380, new DateTime(2020, 11, 24, 22, 1, 3, 755, DateTimeKind.Local).AddTicks(4883), "Qui voluptas aut vel quia.\nQui quod doloribus dolore.\nTempore explicabo et earum distinctio.\nEst sequi et hic sequi cum sint." },
                    { 143, 6, 146, 116931, new DateTime(2021, 4, 3, 4, 37, 59, 935, DateTimeKind.Local).AddTicks(4825), "Ipsam dolorem corporis rerum perferendis ea. Autem beatae culpa ea blanditiis voluptas eaque. Sed et quam accusantium. Doloribus itaque quis voluptas quam voluptatum quis laborum consequatur." },
                    { 163, 6, 135, 102048, new DateTime(2020, 8, 29, 23, 12, 3, 893, DateTimeKind.Local).AddTicks(8404), "Modi nihil dolore aut et quia at quaerat animi.\nNobis aspernatur autem fugiat perferendis quis necessitatibus est dolor.\nAccusamus dolorem totam aut ut." },
                    { 233, 74, 120, 990037, new DateTime(2020, 12, 18, 13, 25, 40, 929, DateTimeKind.Local).AddTicks(7062), "Illo blanditiis doloribus sed corrupti dicta vel tenetur et autem.\nAsperiores velit maxime doloremque et rerum doloribus nihil.\nSimilique sit vero velit eum.\nSoluta voluptas rem.\nEsse qui rerum nobis est placeat ut expedita aliquid." },
                    { 246, 74, 7, 426391, new DateTime(2020, 10, 28, 5, 35, 56, 986, DateTimeKind.Local).AddTicks(8683), "nisi" },
                    { 361, 74, 138, 293329, new DateTime(2021, 3, 4, 2, 24, 26, 199, DateTimeKind.Local).AddTicks(406), "harum" },
                    { 406, 74, 77, 918271, new DateTime(2021, 1, 3, 9, 21, 27, 698, DateTimeKind.Local).AddTicks(4810), "Voluptates dolores quam sit nemo et vel. Maxime et libero dolores quia et voluptatibus quia. Facilis sit dolores qui. Dolorem eos delectus natus ut. Rerum voluptatem cum exercitationem dolor est. Natus dolorum saepe et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 242, 49, 122, 26877, new DateTime(2021, 3, 21, 23, 28, 59, 463, DateTimeKind.Local).AddTicks(9094), "Explicabo iure aliquid dolores iure nulla." },
                    { 107, 43, 73, 122992, new DateTime(2021, 1, 17, 12, 11, 24, 611, DateTimeKind.Local).AddTicks(425), "Doloribus quia enim rem non ducimus nesciunt in voluptas.\nEarum fugit est et necessitatibus quaerat dolores.\nDolor veniam dolorem eum sit quis consequatur eius aut eum." },
                    { 227, 43, 6, 454206, new DateTime(2021, 1, 21, 11, 1, 57, 466, DateTimeKind.Local).AddTicks(2265), "Rem possimus consequatur alias maiores et veritatis quia." },
                    { 354, 43, 37, 593512, new DateTime(2021, 2, 3, 14, 45, 3, 902, DateTimeKind.Local).AddTicks(3523), "Et ullam et consequuntur aut consequuntur non assumenda suscipit deleniti. In adipisci quae et eveniet id cupiditate ea deleniti. Autem voluptas autem est numquam qui id sit placeat similique. Dicta quia ipsum alias reiciendis ut asperiores incidunt." },
                    { 234, 49, 106, 601042, new DateTime(2020, 11, 21, 12, 43, 56, 911, DateTimeKind.Local).AddTicks(2745), "Earum a dolore atque eius quos odit qui qui enim." },
                    { 68, 69, 86, 489815, new DateTime(2021, 4, 20, 4, 46, 31, 41, DateTimeKind.Local).AddTicks(240), "Aliquam beatae cumque itaque. Nesciunt nulla consequatur libero labore voluptas sint corrupti vel. Quis corporis ab. Quam repudiandae eum ut dicta omnis amet alias ipsa. Quia velit nobis explicabo soluta nostrum aut eligendi tenetur modi." },
                    { 141, 69, 129, 919170, new DateTime(2020, 9, 12, 21, 50, 47, 355, DateTimeKind.Local).AddTicks(1992), "dicta" },
                    { 245, 69, 18, 777111, new DateTime(2020, 11, 3, 13, 45, 7, 247, DateTimeKind.Local).AddTicks(2326), "sequi" },
                    { 484, 69, 14, 757799, new DateTime(2021, 2, 13, 2, 32, 45, 215, DateTimeKind.Local).AddTicks(3491), "Id enim vitae nisi quis non. Dolor fugiat rerum dolores quia qui deleniti accusamus repellendus est. Rem earum similique voluptatem doloribus vel sit ipsam quo est. In corporis qui et suscipit dolore nulla eos." },
                    { 487, 69, 33, 351346, new DateTime(2021, 6, 12, 2, 16, 13, 309, DateTimeKind.Local).AddTicks(4025), "Eveniet commodi quae ipsa provident id at in a." },
                    { 490, 69, 31, 479396, new DateTime(2020, 12, 9, 16, 18, 45, 492, DateTimeKind.Local).AddTicks(7839), "Dolores vel minus ab dolorum ut. Quidem et eius porro similique officiis iure. Illum debitis atque alias omnis assumenda id possimus labore animi. Minus qui nihil consequatur error blanditiis sequi dolor et." },
                    { 11, 74, 44, 285802, new DateTime(2020, 11, 4, 5, 48, 7, 64, DateTimeKind.Local).AddTicks(6526), "Excepturi perspiciatis odit.\nVoluptatem nihil et voluptas animi porro quasi at et.\nMolestias quis officiis omnis tenetur sint quaerat repudiandae.\nTotam laudantium dolores eveniet consequatur laborum aut laudantium ea optio.\nHarum accusamus omnis illo cupiditate omnis earum error et ut." },
                    { 503, 49, 143, 697007, new DateTime(2021, 5, 25, 14, 14, 40, 774, DateTimeKind.Local).AddTicks(8783), "aut" },
                    { 278, 49, 113, 94433, new DateTime(2020, 11, 15, 16, 33, 21, 16, DateTimeKind.Local).AddTicks(6582), "non" },
                    { 550, 38, 75, 122852, new DateTime(2021, 1, 4, 22, 5, 23, 951, DateTimeKind.Local).AddTicks(136), "Cupiditate tenetur et in enim repellendus quod laboriosam recusandae est." },
                    { 379, 6, 28, 310274, new DateTime(2021, 6, 16, 4, 42, 29, 716, DateTimeKind.Local).AddTicks(4443), "Autem est id nesciunt quia illum autem nesciunt quia. Nihil dolorem placeat libero eveniet quasi commodi est unde. Non reprehenderit adipisci et hic voluptatibus omnis dignissimos. Aut quas doloremque debitis et qui esse quod et ea." },
                    { 569, 6, 114, 505397, new DateTime(2021, 5, 20, 8, 19, 55, 953, DateTimeKind.Local).AddTicks(7428), "mollitia" },
                    { 585, 6, 84, 496669, new DateTime(2020, 8, 24, 15, 31, 26, 469, DateTimeKind.Local).AddTicks(3194), "Alias ratione consequatur laudantium. Sed porro necessitatibus voluptate. Eaque doloremque a quisquam recusandae voluptatem quia aut. Sequi eum voluptates praesentium fugiat recusandae repellendus ad autem." },
                    { 25, 38, 132, 616046, new DateTime(2021, 6, 4, 20, 11, 47, 43, DateTimeKind.Local).AddTicks(221), "Explicabo odit exercitationem beatae.\nAutem deserunt veniam odio dolorem eos molestias deleniti unde ratione." },
                    { 49, 38, 121, 432701, new DateTime(2020, 12, 11, 22, 35, 54, 158, DateTimeKind.Local).AddTicks(5010), "Aut vitae est consectetur animi sequi sit est iste perferendis.\nHic qui voluptatem eos et quo velit.\nDolor esse autem aliquid.\nPossimus in aut occaecati." },
                    { 104, 38, 123, 355005, new DateTime(2020, 11, 16, 21, 32, 36, 800, DateTimeKind.Local).AddTicks(2747), "voluptatibus" },
                    { 158, 38, 42, 812445, new DateTime(2020, 11, 2, 22, 0, 21, 19, DateTimeKind.Local).AddTicks(665), "Dolorum blanditiis est sapiente commodi non impedit." },
                    { 162, 38, 83, 204692, new DateTime(2021, 8, 5, 16, 53, 3, 558, DateTimeKind.Local).AddTicks(36), "Dolorem ut vitae. Hic architecto quis. Fugiat labore et possimus ducimus commodi mollitia. Accusantium quaerat voluptatem deserunt necessitatibus officiis dolores." },
                    { 249, 38, 133, 707027, new DateTime(2021, 7, 21, 21, 19, 1, 332, DateTimeKind.Local).AddTicks(1269), "Aut eos consectetur eligendi dolores voluptate nihil eius alias quae.\nSint quae saepe deleniti esse sunt.\nCorrupti ipsum sint cumque aperiam est." },
                    { 261, 38, 96, 785804, new DateTime(2020, 10, 29, 6, 7, 35, 23, DateTimeKind.Local).AddTicks(1711), "vitae" },
                    { 291, 38, 150, 950156, new DateTime(2020, 9, 24, 20, 51, 6, 150, DateTimeKind.Local).AddTicks(3135), "Dolorem debitis et quibusdam nemo ullam impedit libero. Tempore delectus consequatur consequatur. Harum ad aut quo id ab iste id." },
                    { 319, 38, 110, 489193, new DateTime(2020, 9, 21, 0, 30, 25, 586, DateTimeKind.Local).AddTicks(7691), "veritatis" },
                    { 425, 38, 128, 551374, new DateTime(2021, 2, 20, 23, 15, 19, 618, DateTimeKind.Local).AddTicks(8768), "Commodi reprehenderit provident doloremque consequuntur." },
                    { 426, 38, 55, 933889, new DateTime(2021, 6, 24, 12, 51, 22, 536, DateTimeKind.Local).AddTicks(3702), "Quos quibusdam eum aperiam ut non perferendis accusamus. Rerum qui sapiente asperiores illum. Dolorem esse est aliquam rerum quod deleniti molestiae." },
                    { 447, 38, 144, 695483, new DateTime(2021, 3, 30, 1, 3, 3, 159, DateTimeKind.Local).AddTicks(2038), "Ullam nisi et." },
                    { 587, 38, 90, 245839, new DateTime(2021, 5, 4, 6, 56, 26, 170, DateTimeKind.Local).AddTicks(2094), "Et voluptatem rerum sed voluptatem quam sunt nobis. Provident commodi voluptas et molestiae voluptates sunt. Voluptas ut vel quibusdam necessitatibus dolor. Ipsam explicabo magnam aperiam adipisci est. Qui et magni ipsam ut molestiae ex alias." },
                    { 590, 69, 72, 987339, new DateTime(2020, 8, 15, 14, 38, 23, 733, DateTimeKind.Local).AddTicks(2381), "error" },
                    { 532, 24, 105, 654574, new DateTime(2020, 10, 24, 17, 56, 53, 683, DateTimeKind.Local).AddTicks(2886), "Repellat et incidunt facilis saepe fugit. Praesentium ea optio sunt earum aliquam laborum ab maiores. Eos repellendus ad a pariatur corporis numquam animi fuga." },
                    { 400, 24, 43, 414092, new DateTime(2021, 2, 24, 17, 33, 25, 138, DateTimeKind.Local).AddTicks(4003), "molestiae" },
                    { 352, 18, 46, 715430, new DateTime(2021, 2, 13, 7, 25, 20, 141, DateTimeKind.Local).AddTicks(7453), "Non earum quia." },
                    { 562, 18, 136, 9913, new DateTime(2021, 3, 4, 3, 41, 53, 859, DateTimeKind.Local).AddTicks(1661), "Quisquam expedita labore explicabo." },
                    { 577, 18, 63, 80595, new DateTime(2020, 10, 22, 13, 27, 26, 814, DateTimeKind.Local).AddTicks(9466), "Quasi et sunt mollitia qui quia dignissimos." },
                    { 588, 58, 41, 428730, new DateTime(2020, 12, 12, 7, 18, 36, 482, DateTimeKind.Local).AddTicks(2968), "Quidem eos est delectus optio." },
                    { 23, 4, 1, 843241, new DateTime(2021, 1, 15, 23, 5, 10, 503, DateTimeKind.Local).AddTicks(5652), "Praesentium et aut est tempora iure molestiae dolorem quis. Ipsa reiciendis quia similique. Quia corporis atque vel rerum." },
                    { 88, 4, 118, 36281, new DateTime(2020, 9, 13, 18, 49, 54, 220, DateTimeKind.Local).AddTicks(1551), "fugit" },
                    { 342, 18, 47, 998054, new DateTime(2021, 1, 8, 10, 2, 11, 910, DateTimeKind.Local).AddTicks(7836), "Quia ducimus sequi sequi a quis.\nReiciendis impedit rerum." },
                    { 207, 4, 51, 243857, new DateTime(2021, 4, 17, 11, 37, 22, 614, DateTimeKind.Local).AddTicks(3445), "ipsa" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 401, 4, 25, 988542, new DateTime(2021, 4, 30, 15, 6, 15, 245, DateTimeKind.Local).AddTicks(6749), "Suscipit suscipit quam optio unde et sed et ut omnis. Magni repellendus ad placeat fuga quos adipisci quidem animi. Ipsum voluptatem error sequi possimus nam ut accusantium quidem ducimus. Molestiae nihil placeat dolor ut quis id voluptatum voluptatum. Magni ut aliquid fuga praesentium sequi quo temporibus temporibus dicta." },
                    { 434, 4, 39, 322659, new DateTime(2021, 5, 13, 0, 0, 28, 855, DateTimeKind.Local).AddTicks(5158), "expedita" },
                    { 521, 4, 12, 83611, new DateTime(2021, 8, 8, 4, 48, 28, 350, DateTimeKind.Local).AddTicks(1828), "Et amet accusamus sit deserunt culpa. Velit et labore molestiae quisquam. Nobis voluptates tempore." },
                    { 557, 4, 125, 193449, new DateTime(2021, 6, 20, 3, 54, 3, 167, DateTimeKind.Local).AddTicks(2794), "Numquam dignissimos nemo dolorem tenetur aut. Et provident repudiandae. Dolore sit tenetur." },
                    { 4, 28, 59, 182849, new DateTime(2020, 9, 13, 23, 47, 54, 407, DateTimeKind.Local).AddTicks(1550), "Sed alias sed doloribus harum magnam. Odit maiores vero labore vitae similique velit sit. Natus dolor et. Ipsum numquam sit in repudiandae. Quasi numquam eum sapiente. Repudiandae sed odio cumque doloremque at eum." },
                    { 198, 28, 127, 686968, new DateTime(2020, 9, 12, 18, 51, 46, 711, DateTimeKind.Local).AddTicks(1931), "rerum" },
                    { 343, 4, 111, 792465, new DateTime(2021, 8, 11, 4, 54, 54, 938, DateTimeKind.Local).AddTicks(7909), "Omnis voluptatum autem consequuntur corrupti sapiente delectus omnis. Deserunt tenetur velit. Voluptatem aliquid labore iure. Est vero rerum eos. Expedita dolor molestiae non eius enim pariatur." },
                    { 288, 18, 4, 732720, new DateTime(2021, 6, 4, 13, 9, 51, 211, DateTimeKind.Local).AddTicks(7834), "Autem expedita voluptatibus quos temporibus et voluptatibus laudantium. Voluptate natus in. Distinctio beatae saepe quas temporibus ad dolore et ullam. Quia sint et ut rerum laboriosam et et neque." },
                    { 189, 18, 96, 909227, new DateTime(2021, 7, 11, 8, 26, 31, 507, DateTimeKind.Local).AddTicks(9451), "nemo" },
                    { 123, 18, 114, 330741, new DateTime(2020, 12, 13, 3, 9, 56, 386, DateTimeKind.Local).AddTicks(9887), "Et illum ab quasi quae qui sequi nemo doloribus.\nNon quia id vitae omnis non magni dolores." },
                    { 55, 44, 17, 349689, new DateTime(2021, 2, 28, 4, 8, 59, 388, DateTimeKind.Local).AddTicks(3799), "Ipsum atque laborum cum.\nVoluptatem libero quasi est eos sequi natus qui rem dignissimos.\nFugit delectus enim blanditiis quo alias.\nTenetur occaecati ea voluptatem vel nesciunt in." },
                    { 98, 44, 37, 241552, new DateTime(2020, 8, 19, 16, 48, 19, 356, DateTimeKind.Local).AddTicks(830), "Quia est omnis aut. Sit nostrum at aut velit eveniet quo ab voluptas. Quidem ipsum fugiat et. Et dignissimos a qui. Cumque dignissimos ullam id et non et. Odit dolor fuga repudiandae sit voluptates unde." },
                    { 226, 44, 108, 664766, new DateTime(2020, 10, 16, 11, 18, 34, 695, DateTimeKind.Local).AddTicks(5248), "Iste quia quibusdam dolorem possimus quas.\nLaborum qui fugit magnam.\nEst aut assumenda et neque est est.\nDolore alias nam quis consequuntur nihil ut dolor et.\nSint ut dicta voluptatem explicabo quam amet.\nCum sit dolores." },
                    { 247, 44, 101, 759376, new DateTime(2020, 9, 15, 6, 23, 2, 577, DateTimeKind.Local).AddTicks(7086), "Odit rerum perspiciatis fuga reprehenderit." },
                    { 265, 44, 14, 872855, new DateTime(2020, 10, 24, 16, 17, 53, 645, DateTimeKind.Local).AddTicks(4143), "Qui voluptatem fugit. Sed dolor dignissimos molestias eum. Tempora exercitationem modi eum. Consequatur sunt enim ut accusamus exercitationem in laborum fugiat occaecati." },
                    { 321, 44, 129, 959993, new DateTime(2021, 8, 9, 7, 15, 32, 151, DateTimeKind.Local).AddTicks(8394), "Quos eum necessitatibus quod in dolorum quas occaecati tenetur." },
                    { 442, 44, 80, 17908, new DateTime(2020, 9, 18, 9, 46, 47, 958, DateTimeKind.Local).AddTicks(7213), "Eaque voluptatem vel." },
                    { 558, 44, 11, 187319, new DateTime(2021, 2, 2, 20, 25, 38, 770, DateTimeKind.Local).AddTicks(8393), "Molestiae aperiam eligendi non in. Fugiat itaque et rem et. Accusamus in nihil. Eos illum nemo odio neque repudiandae hic sit ea. Id consequatur natus sed." },
                    { 182, 54, 92, 297705, new DateTime(2021, 5, 2, 13, 32, 17, 579, DateTimeKind.Local).AddTicks(6788), "eum" },
                    { 90, 61, 56, 431458, new DateTime(2021, 7, 5, 6, 14, 49, 659, DateTimeKind.Local).AddTicks(6413), "A natus illo quaerat dolor.\nAsperiores rerum qui expedita alias.\nLaboriosam eos ab ea blanditiis repellat velit autem beatae porro.\nAut ut nihil fugit eaque eius.\nUllam aliquid qui et laborum officia veniam et eveniet quae." },
                    { 175, 61, 19, 473372, new DateTime(2020, 11, 30, 4, 4, 17, 494, DateTimeKind.Local).AddTicks(6542), "Error ut molestiae fugiat delectus.\nEst architecto illum ut earum repellendus voluptate.\nVero porro ut doloribus quos impedit et voluptas ipsam atque.\nAlias alias consequatur quos rerum illum." },
                    { 384, 61, 103, 410295, new DateTime(2020, 10, 28, 14, 14, 4, 717, DateTimeKind.Local).AddTicks(5278), "et" },
                    { 432, 61, 126, 20066, new DateTime(2021, 4, 11, 19, 37, 6, 182, DateTimeKind.Local).AddTicks(4916), "nobis" },
                    { 502, 61, 61, 934175, new DateTime(2020, 10, 24, 5, 52, 44, 468, DateTimeKind.Local).AddTicks(1238), "Atque qui neque nostrum. Minus cum eveniet voluptatem velit. Natus debitis quasi repellat asperiores harum et. Ullam consectetur eveniet enim alias perspiciatis quis reprehenderit explicabo quas. Atque animi et culpa eum odit. Nemo natus culpa iste." },
                    { 579, 61, 6, 90379, new DateTime(2021, 8, 6, 9, 40, 49, 192, DateTimeKind.Local).AddTicks(4607), "Debitis reiciendis eos sed expedita accusamus aut tempora. Impedit adipisci sit totam beatae recusandae. Qui eligendi et quidem sapiente. Sapiente doloremque molestias nostrum fuga delectus quae distinctio. Aut dolores omnis quo sunt quae qui itaque quo. Numquam enim autem." },
                    { 312, 28, 51, 391846, new DateTime(2021, 4, 2, 0, 3, 20, 15, DateTimeKind.Local).AddTicks(2403), "Accusamus laudantium possimus aut qui. Eos sint rerum possimus et beatae. Minima voluptatum perferendis voluptatem in in aspernatur sint sequi aliquid. Necessitatibus totam suscipit." },
                    { 332, 28, 86, 25743, new DateTime(2020, 8, 20, 19, 50, 3, 357, DateTimeKind.Local).AddTicks(3145), "Assumenda sit delectus est unde architecto dolores et hic aut. Ut non quas fugiat illo at magni. Et architecto ad dolores. Ut corrupti voluptate itaque ullam reiciendis. Excepturi nam adipisci eos. Tenetur officia omnis tenetur sapiente." },
                    { 118, 40, 133, 903032, new DateTime(2020, 12, 29, 23, 31, 59, 144, DateTimeKind.Local).AddTicks(4434), "Officia ut et illum qui consequatur provident.\nSit perspiciatis velit ullam eum harum.\nQuaerat doloremque sed natus expedita." },
                    { 303, 40, 142, 331161, new DateTime(2021, 5, 20, 6, 3, 25, 895, DateTimeKind.Local).AddTicks(2335), "Eum mollitia distinctio itaque hic sequi quisquam deserunt omnis." },
                    { 429, 62, 86, 160684, new DateTime(2020, 11, 27, 8, 50, 15, 380, DateTimeKind.Local).AddTicks(4911), "Velit esse magni quo est." },
                    { 537, 62, 54, 526611, new DateTime(2021, 7, 22, 9, 34, 28, 930, DateTimeKind.Local).AddTicks(3008), "Maiores sit optio ipsa et laudantium sunt voluptatem ab laborum. Voluptatem ut ea suscipit. Ut corrupti maxime commodi nisi veritatis aut voluptas. Est qui harum." },
                    { 539, 62, 54, 437231, new DateTime(2021, 3, 9, 5, 3, 7, 30, DateTimeKind.Local).AddTicks(9409), "Quia molestias quidem dolorum.\nEst voluptatibus distinctio.\nId soluta voluptatem ab inventore.\nRatione soluta consectetur rerum ex quisquam.\nDoloremque exercitationem itaque quo optio aut repellat quasi aut." },
                    { 531, 49, 85, 745175, new DateTime(2021, 2, 4, 12, 18, 53, 353, DateTimeKind.Local).AddTicks(614), "Nostrum aut dolorem ea eligendi dicta neque velit quaerat." },
                    { 17, 24, 73, 24968, new DateTime(2021, 2, 2, 14, 42, 36, 671, DateTimeKind.Local).AddTicks(9521), "Voluptatem est voluptatem quia facere aspernatur." },
                    { 72, 24, 101, 163695, new DateTime(2020, 9, 26, 10, 36, 22, 80, DateTimeKind.Local).AddTicks(4221), "Eveniet voluptas ut vel sint autem et et aut. Tempore iste sed et. Accusamus ipsa provident et blanditiis cum culpa sint sunt quis. Labore tempore eligendi hic voluptatibus tempore." },
                    { 165, 24, 146, 313129, new DateTime(2021, 7, 17, 18, 14, 12, 33, DateTimeKind.Local).AddTicks(7106), "Temporibus provident aspernatur molestias aut ut dignissimos qui et. Reiciendis rerum est. Consequatur dolores sapiente est ratione." },
                    { 181, 24, 88, 49817, new DateTime(2021, 4, 1, 5, 17, 3, 114, DateTimeKind.Local).AddTicks(6797), "Quod dolorem non dolorum assumenda ut incidunt." },
                    { 202, 24, 133, 274101, new DateTime(2020, 12, 13, 8, 30, 48, 521, DateTimeKind.Local).AddTicks(2816), "Quibusdam ut aut nam nesciunt.\nUt rerum magnam dolor ullam est nihil quam similique asperiores.\nSunt exercitationem quia deleniti at eum aut fugiat dignissimos." },
                    { 235, 24, 145, 136701, new DateTime(2021, 2, 5, 16, 47, 44, 176, DateTimeKind.Local).AddTicks(8737), "Ut atque quibusdam vel sapiente aliquid." },
                    { 270, 24, 33, 209069, new DateTime(2021, 5, 9, 11, 44, 16, 566, DateTimeKind.Local).AddTicks(2459), "Vel sunt minus sed doloribus dolore adipisci possimus." },
                    { 287, 24, 79, 384073, new DateTime(2021, 8, 7, 3, 10, 25, 832, DateTimeKind.Local).AddTicks(1611), "Sunt rerum consectetur ipsam. Et eos aliquam distinctio possimus omnis molestias. Ut nesciunt hic qui et voluptates ut qui ipsum expedita. Consectetur dolor earum laudantium quam alias soluta rerum. Voluptatem doloribus voluptates. Voluptatem ab repellendus placeat qui recusandae." },
                    { 359, 24, 118, 8499, new DateTime(2021, 2, 24, 11, 50, 56, 108, DateTimeKind.Local).AddTicks(8681), "Voluptas illum eum laudantium ipsa fuga temporibus eos quos facilis." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 372, 24, 54, 222678, new DateTime(2020, 9, 20, 11, 58, 23, 36, DateTimeKind.Local).AddTicks(7), "Impedit harum quia explicabo quia quos excepturi libero. Alias assumenda quam non non. Aut similique est." },
                    { 389, 24, 119, 863575, new DateTime(2021, 6, 21, 12, 8, 52, 638, DateTimeKind.Local).AddTicks(3835), "Labore ut adipisci cum et cum.\nDolorem est sit voluptatum.\nHic neque et molestiae.\nSequi iste excepturi eos delectus.\nCumque nihil numquam." },
                    { 396, 62, 92, 349766, new DateTime(2021, 1, 18, 18, 41, 8, 579, DateTimeKind.Local).AddTicks(1767), "Omnis aut voluptas commodi ea numquam doloribus architecto voluptas deleniti. Nihil eum voluptatibus sed placeat quidem soluta ut. Temporibus sit commodi nulla harum libero velit quis. Est sequi est omnis est ut accusamus ut molestias excepturi. Quos ea accusamus hic." },
                    { 513, 24, 26, 599501, new DateTime(2020, 10, 15, 2, 7, 58, 214, DateTimeKind.Local).AddTicks(6986), "Doloribus dolorum sequi cupiditate atque temporibus." },
                    { 132, 62, 40, 610625, new DateTime(2021, 5, 15, 7, 18, 12, 848, DateTimeKind.Local).AddTicks(6188), "quia" },
                    { 8, 62, 146, 979279, new DateTime(2021, 4, 3, 12, 31, 28, 670, DateTimeKind.Local).AddTicks(748), "Sed est quis.\nPlaceat molestiae quia libero deserunt laudantium et nemo minima.\nSapiente et in fugiat quae.\nCulpa rerum iste omnis quasi.\nAd eum quae qui itaque nulla necessitatibus voluptate aut." },
                    { 427, 40, 8, 164466, new DateTime(2020, 10, 10, 20, 38, 10, 846, DateTimeKind.Local).AddTicks(5168), "Voluptatum et perspiciatis aspernatur sed dolore provident voluptas." },
                    { 467, 40, 78, 515805, new DateTime(2021, 3, 16, 1, 45, 2, 898, DateTimeKind.Local).AddTicks(1680), "accusantium" },
                    { 507, 40, 53, 19109, new DateTime(2021, 7, 12, 2, 16, 11, 808, DateTimeKind.Local).AddTicks(5292), "Labore delectus voluptatibus iste fuga et ut voluptate." },
                    { 45, 54, 84, 358508, new DateTime(2020, 8, 17, 5, 24, 20, 429, DateTimeKind.Local).AddTicks(5956), "Repellendus consequatur et quam velit expedita quos id veritatis et.\nVoluptates sit et quaerat nobis maiores reiciendis porro atque ad.\nConsequatur enim quod doloribus.\nVoluptatem eaque optio maxime nulla omnis repellat.\nTotam est nesciunt delectus architecto eius animi quas unde qui.\nDoloremque deserunt quas quidem voluptatem et." },
                    { 67, 77, 38, 724055, new DateTime(2020, 9, 8, 21, 18, 13, 66, DateTimeKind.Local).AddTicks(8159), "Explicabo rem sit adipisci et a voluptatum assumenda perspiciatis ut." },
                    { 94, 77, 41, 622124, new DateTime(2021, 3, 19, 3, 27, 4, 185, DateTimeKind.Local).AddTicks(2974), "nulla" },
                    { 231, 77, 59, 232257, new DateTime(2021, 1, 18, 0, 29, 14, 507, DateTimeKind.Local).AddTicks(9019), "Et laborum officiis.\nFuga voluptas voluptatem expedita quod assumenda dolor voluptate omnis asperiores.\nVeritatis odit qui.\nOdio accusantium est at totam rerum accusamus quos quos quos.\nEx voluptatem molestiae." },
                    { 277, 77, 124, 804676, new DateTime(2020, 12, 2, 6, 13, 4, 195, DateTimeKind.Local).AddTicks(8089), "Est nulla voluptate voluptas laborum quae dolore consequatur. Deserunt culpa aut. Eveniet iusto consequatur autem deleniti quo tenetur." },
                    { 302, 77, 111, 641024, new DateTime(2021, 2, 13, 6, 46, 5, 136, DateTimeKind.Local).AddTicks(2996), "Porro pariatur sint sit omnis et. Ducimus eveniet et sint velit quidem. Odio odio accusantium quas vitae temporibus." },
                    { 347, 77, 82, 29901, new DateTime(2021, 2, 7, 20, 42, 34, 487, DateTimeKind.Local).AddTicks(6257), "Facere placeat veniam voluptatem deserunt neque consequatur.\nUt explicabo sed illo molestias labore.\nVeniam sit eos in non dignissimos necessitatibus reiciendis." },
                    { 469, 77, 19, 38061, new DateTime(2021, 2, 7, 6, 38, 9, 651, DateTimeKind.Local).AddTicks(4874), "Ea aliquam occaecati nemo sit ut quasi reprehenderit." },
                    { 476, 77, 72, 201792, new DateTime(2021, 6, 22, 10, 32, 55, 586, DateTimeKind.Local).AddTicks(501), "Quae sit aut vero ut est.\nReprehenderit totam id.\nOdio sint nostrum doloremque ab." },
                    { 542, 77, 146, 603824, new DateTime(2021, 8, 1, 8, 25, 58, 375, DateTimeKind.Local).AddTicks(5483), "Magnam eum enim optio vitae similique non minima." },
                    { 583, 77, 59, 531651, new DateTime(2021, 2, 2, 14, 33, 51, 797, DateTimeKind.Local).AddTicks(347), "Repellendus non illum molestiae illum. Aut distinctio reprehenderit aliquid. Consectetur excepturi reprehenderit dolorum pariatur voluptas fugit. Dolor dignissimos mollitia impedit eveniet inventore eius." },
                    { 43, 54, 87, 277621, new DateTime(2020, 11, 26, 13, 25, 30, 327, DateTimeKind.Local).AddTicks(1967), "Aperiam sed culpa est. Excepturi laborum vel ea aspernatur veritatis voluptatem molestiae excepturi odit. Sed suscipit error ea ducimus. Laborum autem quo aut. Sed est repudiandae. Alias nisi unde id molestiae." },
                    { 86, 62, 104, 817706, new DateTime(2021, 8, 12, 0, 2, 45, 555, DateTimeKind.Local).AddTicks(9028), "Aut libero error mollitia atque in ut iste. Doloremque aut nobis ex. Consequatur alias mollitia officiis alias eos perferendis voluptatibus sunt qui. Ducimus sed dignissimos voluptatibus maiores eligendi quia est." },
                    { 5, 52, 117, 120521, new DateTime(2020, 12, 27, 12, 4, 46, 901, DateTimeKind.Local).AddTicks(9276), "Id architecto perspiciatis." },
                    { 28, 52, 51, 746244, new DateTime(2020, 9, 21, 12, 6, 46, 653, DateTimeKind.Local).AddTicks(5900), "similique" },
                    { 36, 52, 137, 123949, new DateTime(2021, 2, 1, 10, 19, 40, 340, DateTimeKind.Local).AddTicks(9284), "Sed quia deserunt impedit sit dolorem." },
                    { 211, 50, 105, 678248, new DateTime(2020, 8, 13, 3, 1, 20, 337, DateTimeKind.Local).AddTicks(5379), "Et necessitatibus nesciunt molestiae debitis explicabo et voluptas iusto distinctio." },
                    { 363, 50, 39, 429244, new DateTime(2021, 3, 8, 17, 28, 41, 772, DateTimeKind.Local).AddTicks(7254), "Quisquam autem est ipsa est nemo nobis autem ullam est.\nAssumenda commodi officiis et.\nEt dolor molestias fugiat dolores autem sed culpa consequuntur." },
                    { 428, 50, 110, 163336, new DateTime(2021, 5, 18, 18, 30, 48, 649, DateTimeKind.Local).AddTicks(4510), "Dolore sunt aperiam nemo possimus iure.\nNon et nostrum.\nAut consequatur magnam aut qui neque rerum dolorem eum cumque.\nEt officiis sunt sit quia culpa atque.\nSaepe sequi occaecati aut necessitatibus commodi velit inventore laborum.\nOdio aperiam quae aut consectetur." },
                    { 435, 50, 61, 988592, new DateTime(2020, 11, 1, 1, 34, 16, 56, DateTimeKind.Local).AddTicks(4082), "Voluptate esse maxime aut incidunt. Recusandae non eum error quod quae explicabo est voluptatum in. Voluptas et officia et sint aperiam aspernatur. Quia vitae nesciunt." },
                    { 470, 50, 85, 873379, new DateTime(2021, 3, 5, 9, 31, 5, 83, DateTimeKind.Local).AddTicks(7898), "Eius harum nesciunt veniam rerum aut officiis fuga aspernatur.\nDeserunt et ex dolorum iure dolores et.\nMaiores ut tempore." },
                    { 480, 50, 65, 364847, new DateTime(2020, 12, 19, 1, 40, 16, 277, DateTimeKind.Local).AddTicks(2468), "sed" },
                    { 14, 50, 7, 608851, new DateTime(2021, 1, 5, 5, 18, 0, 884, DateTimeKind.Local).AddTicks(604), "Similique ratione officia doloremque earum tempora numquam. Asperiores reprehenderit sed voluptatem consequatur id ex maiores quam voluptate. Unde a eveniet veniam." },
                    { 215, 11, 11, 239214, new DateTime(2020, 8, 31, 20, 52, 32, 0, DateTimeKind.Local).AddTicks(6584), "Maxime amet minima iusto a sint aut vitae aut non." },
                    { 30, 71, 59, 911016, new DateTime(2021, 4, 22, 4, 0, 6, 398, DateTimeKind.Local).AddTicks(5384), "voluptatem" },
                    { 208, 71, 124, 773706, new DateTime(2021, 6, 24, 8, 21, 19, 336, DateTimeKind.Local).AddTicks(9472), "Autem quis error fugit magnam. Vero alias est dolore doloremque et voluptas. Doloremque consequatur sunt quis doloribus." },
                    { 498, 71, 123, 746394, new DateTime(2020, 10, 8, 16, 30, 29, 997, DateTimeKind.Local).AddTicks(8166), "quidem" },
                    { 139, 70, 143, 151902, new DateTime(2020, 12, 18, 12, 45, 25, 666, DateTimeKind.Local).AddTicks(8630), "Ullam nisi vero. Iste tenetur impedit et. Nobis doloribus at vero esse quas et enim maiores consectetur." },
                    { 177, 70, 148, 861466, new DateTime(2020, 10, 13, 21, 58, 27, 207, DateTimeKind.Local).AddTicks(3769), "Iste nulla aut. Rerum dolor quam ea ad beatae. Culpa ipsa cupiditate dolores ut. Architecto veniam velit quia blanditiis blanditiis omnis. Sit consectetur voluptatem nesciunt tempora minima et illo excepturi consequuntur. A molestiae id provident voluptatem esse porro sed." },
                    { 223, 70, 25, 892464, new DateTime(2020, 9, 29, 4, 10, 42, 12, DateTimeKind.Local).AddTicks(2753), "Voluptate alias enim non vero doloremque. Enim et dolor similique voluptatem excepturi nam voluptatem sed. Aliquam voluptatem officia repudiandae voluptates. Delectus eaque praesentium doloribus qui velit. Provident voluptatem alias qui." },
                    { 7, 71, 114, 66036, new DateTime(2021, 3, 9, 20, 40, 38, 167, DateTimeKind.Local).AddTicks(8727), "Explicabo non sit omnis omnis ut. Vel non eveniet. Occaecati consequatur consequatur aut ullam. Voluptate provident esse magni dolores ut id quisquam. Est ut et expedita sed labore eligendi qui." },
                    { 415, 64, 118, 958289, new DateTime(2021, 1, 2, 15, 16, 56, 782, DateTimeKind.Local).AddTicks(5695), "Et cupiditate repellendus tempora veniam aliquam ut.\nVoluptatum et ut corrupti perspiciatis tenetur eaque nostrum rerum qui.\nMollitia sed voluptatem." },
                    { 258, 64, 129, 42539, new DateTime(2021, 1, 25, 2, 5, 21, 287, DateTimeKind.Local).AddTicks(8172), "fugiat" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 154, 64, 76, 478215, new DateTime(2021, 3, 25, 11, 7, 46, 235, DateTimeKind.Local).AddTicks(9748), "eum" },
                    { 355, 46, 103, 169014, new DateTime(2020, 9, 10, 19, 39, 15, 118, DateTimeKind.Local).AddTicks(5147), "aut" },
                    { 472, 46, 46, 29070, new DateTime(2020, 8, 13, 21, 21, 42, 206, DateTimeKind.Local).AddTicks(5569), "Nihil assumenda id sit porro assumenda quia et." },
                    { 512, 46, 148, 900034, new DateTime(2020, 12, 19, 10, 43, 30, 652, DateTimeKind.Local).AddTicks(6359), "Eum corporis eveniet sed perferendis cupiditate consequuntur atque non doloremque.\nQuibusdam et omnis ad dolor inventore sint est autem sint.\nExpedita repellat expedita doloremque incidunt et dolores et.\nQui ipsam rerum tenetur cum saepe rerum veniam inventore numquam.\nAut laboriosam ut quia beatae at rem ullam aperiam dolorem.\nEt et cum." },
                    { 328, 11, 15, 169932, new DateTime(2020, 12, 13, 21, 55, 53, 306, DateTimeKind.Local).AddTicks(8), "Quia qui eos.\nRecusandae cupiditate quas dolores illo ex.\nAdipisci esse natus sunt in repellendus repudiandae.\nDicta voluptas quibusdam nulla eos ipsam velit vero necessitatibus deleniti.\nAccusantium eum qui sit modi aliquid placeat non.\nDolor est optio ut repellendus." },
                    { 2, 36, 11, 541844, new DateTime(2021, 3, 29, 6, 4, 1, 507, DateTimeKind.Local).AddTicks(3563), "Sint similique quos iusto ab excepturi recusandae.\nQuae iure libero cupiditate inventore unde quasi ex.\nEx error ullam impedit cum corrupti molestiae labore aperiam reprehenderit." },
                    { 185, 36, 131, 464052, new DateTime(2021, 5, 17, 20, 19, 52, 70, DateTimeKind.Local).AddTicks(9695), "Ipsa ut quo aliquam. Vel ea ducimus ut neque omnis nulla. Tenetur ut quo quia placeat suscipit laudantium nihil a dignissimos. Et est rerum necessitatibus cupiditate hic itaque enim. Animi est sunt iste est et culpa iusto." },
                    { 194, 36, 81, 120280, new DateTime(2021, 7, 31, 9, 49, 53, 341, DateTimeKind.Local).AddTicks(9129), "neque" },
                    { 201, 36, 36, 566368, new DateTime(2020, 11, 5, 17, 16, 32, 103, DateTimeKind.Local).AddTicks(3871), "Fugiat quas ipsa iusto est accusamus." },
                    { 264, 36, 143, 777036, new DateTime(2021, 4, 22, 20, 42, 12, 293, DateTimeKind.Local).AddTicks(2360), "Impedit eveniet sunt sed. Dignissimos ipsa aspernatur voluptas sint quis soluta id. Facilis maiores voluptatibus." },
                    { 274, 36, 79, 351125, new DateTime(2020, 10, 8, 13, 34, 36, 770, DateTimeKind.Local).AddTicks(6430), "soluta" },
                    { 310, 36, 127, 11064, new DateTime(2020, 9, 17, 21, 38, 17, 112, DateTimeKind.Local).AddTicks(1474), "Optio accusamus distinctio nam earum. Et consectetur necessitatibus suscipit. Sit a qui et vel facere enim consequatur assumenda." },
                    { 475, 36, 150, 579262, new DateTime(2020, 10, 21, 7, 41, 17, 461, DateTimeKind.Local).AddTicks(3583), "sint" },
                    { 596, 36, 148, 654720, new DateTime(2021, 4, 24, 19, 36, 52, 338, DateTimeKind.Local).AddTicks(7674), "Vel aperiam illum possimus quasi quia nam rerum modi consectetur." },
                    { 83, 64, 59, 265177, new DateTime(2021, 5, 26, 20, 36, 3, 314, DateTimeKind.Local).AddTicks(6774), "ut" },
                    { 125, 64, 36, 364075, new DateTime(2021, 4, 9, 23, 34, 58, 788, DateTimeKind.Local).AddTicks(322), "nam" },
                    { 230, 70, 137, 817321, new DateTime(2020, 11, 19, 15, 14, 40, 369, DateTimeKind.Local).AddTicks(4052), "Eos provident ut et totam ullam dolore.\nIpsa inventore officia voluptas provident nostrum." },
                    { 239, 70, 97, 525496, new DateTime(2021, 3, 1, 8, 26, 1, 169, DateTimeKind.Local).AddTicks(9126), "Non culpa id exercitationem animi.\nNesciunt repellat eum quo modi.\nMaxime eligendi architecto ut.\nMolestiae ut enim dolor.\nDebitis perspiciatis corrupti corporis vero veritatis laborum.\nCumque fugiat quis aliquid nam quos." },
                    { 248, 70, 103, 6634, new DateTime(2021, 6, 16, 20, 19, 17, 705, DateTimeKind.Local).AddTicks(5907), "Voluptates esse aut dolorum qui quisquam et." },
                    { 251, 70, 31, 215692, new DateTime(2020, 9, 11, 0, 58, 46, 404, DateTimeKind.Local).AddTicks(4152), "Inventore velit numquam tempore sed cum. Enim sed sit voluptatem voluptatem enim dolorem. Harum molestiae hic vel temporibus non. Quis exercitationem ea excepturi iusto nulla quod rerum. Enim tempora quis reiciendis non nulla aperiam." },
                    { 266, 35, 26, 917043, new DateTime(2020, 9, 15, 6, 39, 35, 261, DateTimeKind.Local).AddTicks(312), "Quas architecto provident expedita voluptas porro error unde architecto.\nAt autem eos aliquid omnis sequi suscipit velit suscipit.\nMaiores cupiditate quisquam aut velit minima consequatur id." },
                    { 294, 35, 38, 846341, new DateTime(2021, 3, 14, 4, 55, 44, 752, DateTimeKind.Local).AddTicks(969), "Ullam necessitatibus voluptatum et maxime aut dolor rerum veniam inventore. Distinctio et illum est. Esse nulla et cum et rerum. Sed itaque voluptatibus voluptatem molestiae. Ut unde aut quia aut non deleniti quia vel. Ut eligendi est vitae odit fuga." },
                    { 453, 35, 148, 528444, new DateTime(2020, 12, 11, 23, 19, 40, 158, DateTimeKind.Local).AddTicks(4223), "Vel doloremque sequi est officia.\nAt maxime excepturi temporibus animi provident repellendus.\nConsequatur alias esse labore qui quae quos." },
                    { 543, 35, 55, 842567, new DateTime(2021, 3, 7, 2, 34, 4, 729, DateTimeKind.Local).AddTicks(121), "aut" },
                    { 568, 35, 37, 379890, new DateTime(2021, 6, 6, 3, 42, 28, 427, DateTimeKind.Local).AddTicks(877), "Rerum eligendi rerum asperiores veniam." },
                    { 598, 35, 18, 354609, new DateTime(2020, 11, 27, 13, 7, 19, 769, DateTimeKind.Local).AddTicks(9552), "delectus" },
                    { 109, 5, 119, 557912, new DateTime(2020, 10, 6, 20, 25, 4, 631, DateTimeKind.Local).AddTicks(9267), "Ut beatae impedit rerum quaerat autem accusamus." },
                    { 186, 5, 52, 823117, new DateTime(2021, 7, 12, 22, 53, 53, 325, DateTimeKind.Local).AddTicks(9503), "Temporibus dolorem iure temporibus mollitia nam ut dolorem." },
                    { 241, 5, 121, 702567, new DateTime(2020, 8, 19, 7, 9, 7, 468, DateTimeKind.Local).AddTicks(2582), "Veritatis vel ut nisi ut iste aspernatur." },
                    { 387, 5, 42, 809659, new DateTime(2021, 4, 2, 14, 43, 36, 573, DateTimeKind.Local).AddTicks(9018), "Aliquid autem molestias voluptas sed inventore quis et qui qui.\nCommodi ut alias minus.\nQuia sit autem in.\nEt quod dignissimos ut velit nihil ut.\nAtque autem optio quia." },
                    { 388, 5, 61, 350457, new DateTime(2021, 4, 11, 21, 51, 46, 743, DateTimeKind.Local).AddTicks(610), "Pariatur voluptatem assumenda in dolores aut magni dolor.\nEt molestiae minima quo nesciunt ea odit harum et et." },
                    { 393, 5, 90, 852749, new DateTime(2021, 1, 7, 9, 13, 35, 464, DateTimeKind.Local).AddTicks(3347), "aut" },
                    { 394, 5, 15, 588088, new DateTime(2021, 2, 23, 3, 49, 33, 67, DateTimeKind.Local).AddTicks(1122), "assumenda" },
                    { 500, 5, 102, 212265, new DateTime(2020, 9, 2, 2, 44, 54, 491, DateTimeKind.Local).AddTicks(3317), "Dolore voluptate aut tempora quisquam cumque soluta dolorum non voluptatem. Ut libero magnam aut consequatur numquam sed nemo perferendis. Est odit quas commodi velit totam maiores consequatur. Vitae dolores qui eum iste exercitationem incidunt. Quaerat provident necessitatibus voluptatem labore." },
                    { 153, 11, 34, 650073, new DateTime(2020, 12, 31, 21, 19, 11, 182, DateTimeKind.Local).AddTicks(5686), "Debitis perferendis eveniet suscipit omnis non fugit repudiandae.\nSuscipit numquam et doloribus quis a et assumenda.\nExcepturi maxime ducimus voluptas sed qui accusamus est porro.\nId quia quis sit voluptas tempora quod quisquam." },
                    { 157, 11, 106, 886243, new DateTime(2021, 5, 18, 2, 32, 18, 701, DateTimeKind.Local).AddTicks(5433), "Quos esse dolor dolorum sapiente aut modi voluptas harum." },
                    { 66, 46, 29, 925973, new DateTime(2020, 10, 19, 3, 0, 48, 797, DateTimeKind.Local).AddTicks(1998), "Tenetur enim sit.\nAut qui tempora rem ex aut.\nVoluptatem totam mollitia molestias consequatur ab.\nEligendi et sit velit molestiae aliquam nobis adipisci qui.\nFacere aut fuga corporis natus.\nQui ut delectus soluta quia qui officia." },
                    { 599, 34, 59, 467241, new DateTime(2021, 2, 27, 17, 25, 26, 738, DateTimeKind.Local).AddTicks(3342), "Voluptatibus doloremque distinctio et odit.\nDucimus veritatis quae.\nEst explicabo at aperiam pariatur repudiandae.\nSint aut sed occaecati sapiente commodi molestias amet ut.\nHic beatae error sit et." },
                    { 283, 34, 34, 283439, new DateTime(2021, 7, 30, 12, 53, 17, 411, DateTimeKind.Local).AddTicks(910), "Ad neque animi veritatis odio autem." },
                    { 316, 70, 101, 886678, new DateTime(2020, 12, 6, 18, 27, 25, 891, DateTimeKind.Local).AddTicks(7859), "Ab officiis minima quam repellendus vel nostrum in." },
                    { 455, 70, 148, 939546, new DateTime(2021, 7, 30, 11, 1, 12, 786, DateTimeKind.Local).AddTicks(7193), "consequatur" },
                    { 592, 70, 149, 344712, new DateTime(2021, 7, 30, 1, 8, 34, 434, DateTimeKind.Local).AddTicks(257), "Hic deleniti facilis nihil modi minus architecto quia.\nAliquam laborum perspiciatis adipisci.\nMolestiae qui ex natus vel reiciendis numquam dolorum aut minus.\nSit voluptatem itaque illo minus tenetur est alias quia." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 169, 11, 89, 872714, new DateTime(2021, 6, 28, 19, 53, 15, 472, DateTimeKind.Local).AddTicks(9887), "quam" },
                    { 152, 37, 140, 422961, new DateTime(2020, 9, 24, 20, 28, 50, 362, DateTimeKind.Local).AddTicks(1028), "Id est error. Optio architecto nemo rerum sequi. Pariatur asperiores est consequatur possimus cupiditate. Maiores consectetur ut sit impedit odio aut explicabo culpa nesciunt. Corporis earum quam vero dolorum minus molestias. Nobis iusto et quod consequuntur vel voluptatibus sunt ut vel." },
                    { 188, 37, 137, 374128, new DateTime(2021, 4, 13, 14, 29, 24, 81, DateTimeKind.Local).AddTicks(9879), "Ratione ut ipsam dolor adipisci consequatur." },
                    { 224, 37, 103, 235217, new DateTime(2020, 8, 18, 12, 46, 50, 927, DateTimeKind.Local).AddTicks(9893), "Ut dolores consequatur nihil illo modi omnis voluptas rerum.\nMinima et doloremque occaecati et sed nemo necessitatibus qui.\nExercitationem aut soluta.\nCorporis quaerat inventore autem quaerat.\nVelit eligendi excepturi dolor earum est et ut." },
                    { 236, 37, 147, 820065, new DateTime(2021, 7, 23, 13, 59, 11, 326, DateTimeKind.Local).AddTicks(2648), "Minima soluta provident non cupiditate rerum quae et ex. Laboriosam nemo officia dolore autem. Ratione voluptatem tenetur accusamus labore qui voluptate alias hic et. Dignissimos aut velit aliquam molestias rem consequatur. Et consectetur architecto." },
                    { 373, 37, 131, 626595, new DateTime(2021, 6, 19, 18, 52, 36, 327, DateTimeKind.Local).AddTicks(9468), "Blanditiis doloribus suscipit aspernatur eos.\nNam rerum eaque ut quod quia doloribus aperiam hic.\nUt facere ut quis magnam quis placeat." },
                    { 451, 37, 77, 727173, new DateTime(2021, 1, 24, 4, 10, 7, 735, DateTimeKind.Local).AddTicks(7321), "Hic in qui qui rerum. Quasi dolore numquam aliquam vero dolores. Iusto consequatur tempora impedit qui laboriosam. Unde in doloremque qui est impedit aut voluptatem facere." },
                    { 471, 37, 98, 921598, new DateTime(2020, 11, 28, 22, 8, 54, 227, DateTimeKind.Local).AddTicks(174), "Sint quis animi ut doloribus qui iusto vel consequatur." },
                    { 12, 34, 3, 412998, new DateTime(2020, 12, 6, 16, 3, 2, 792, DateTimeKind.Local).AddTicks(8163), "Rem maxime ratione voluptas mollitia et quidem in qui.\nQuaerat voluptatem dolores magnam nam sequi molestias.\nQuidem non illum.\nConsectetur in eligendi aut fuga.\nQuia est est voluptatem omnis exercitationem doloribus expedita.\nVoluptatem aperiam numquam quia et nihil ut." },
                    { 144, 34, 139, 733592, new DateTime(2020, 11, 9, 1, 43, 45, 998, DateTimeKind.Local).AddTicks(1303), "Eaque ut eos et rerum voluptas incidunt modi. Ipsa qui provident debitis. Odio itaque qui quo velit autem. Aut laudantium sed quasi alias voluptatibus quisquam praesentium quis corrupti. Inventore excepturi vitae sed natus aut quo modi impedit. Aspernatur vel saepe." },
                    { 167, 34, 87, 23568, new DateTime(2021, 5, 14, 21, 31, 29, 862, DateTimeKind.Local).AddTicks(500), "Reprehenderit consequuntur explicabo corporis est eum sequi laborum cumque qui. At soluta et dolor. Et natus eligendi tenetur omnis quae esse. Ipsam et quo quidem quisquam. Recusandae voluptatem esse impedit possimus earum eius maiores." },
                    { 257, 34, 64, 493811, new DateTime(2020, 8, 19, 14, 38, 23, 927, DateTimeKind.Local).AddTicks(74), "Rerum natus voluptatem maxime cumque et.\nVoluptatem repellat voluptatibus quam qui optio totam.\nNemo voluptas eos tempore dolores fuga eos et.\nPraesentium doloremque dolorem reprehenderit pariatur qui.\nQuia repellendus optio eum.\nOccaecati accusamus tempora odit enim hic explicabo eligendi sed." },
                    { 334, 34, 97, 286530, new DateTime(2020, 11, 23, 19, 33, 41, 43, DateTimeKind.Local).AddTicks(4343), "Ut aliquid sit.\nAspernatur dolore neque voluptates dolores eum ex.\nQui ut debitis accusamus.\nLaboriosam commodi officia voluptatum aut." },
                    { 524, 2, 87, 778644, new DateTime(2021, 1, 24, 12, 7, 7, 253, DateTimeKind.Local).AddTicks(2648), "Molestiae repellat voluptate sed qui.\nQuia non est reiciendis dolores illum dolore earum.\nFacere sit rerum est sequi temporibus quasi tempora.\nAliquid cumque occaecati unde omnis.\nQuam sed autem ipsam et sed quo suscipit.\nDoloremque omnis sit et." },
                    { 496, 2, 146, 787861, new DateTime(2020, 8, 20, 19, 23, 52, 760, DateTimeKind.Local).AddTicks(2295), "facilis" },
                    { 397, 2, 105, 694303, new DateTime(2020, 11, 18, 10, 32, 11, 539, DateTimeKind.Local).AddTicks(2267), "Iure minus voluptates alias explicabo et odio sint." },
                    { 454, 10, 71, 35695, new DateTime(2021, 5, 15, 19, 14, 34, 661, DateTimeKind.Local).AddTicks(471), "Repellendus beatae beatae quos distinctio voluptate quia qui repellat." },
                    { 35, 82, 14, 200197, new DateTime(2021, 3, 25, 23, 24, 25, 838, DateTimeKind.Local).AddTicks(3516), "Laudantium est magni quas explicabo consequatur dolores placeat temporibus eaque." },
                    { 50, 82, 136, 479751, new DateTime(2021, 7, 7, 16, 46, 41, 363, DateTimeKind.Local).AddTicks(8490), "Et iure accusantium consectetur dolor iusto aut aspernatur ducimus." },
                    { 136, 82, 54, 163174, new DateTime(2021, 6, 22, 5, 54, 16, 463, DateTimeKind.Local).AddTicks(9837), "doloribus" },
                    { 170, 82, 45, 820995, new DateTime(2020, 11, 26, 9, 54, 51, 885, DateTimeKind.Local).AddTicks(7046), "ut" },
                    { 217, 82, 126, 999965, new DateTime(2021, 1, 11, 5, 40, 59, 747, DateTimeKind.Local).AddTicks(6995), "Sint quia ut quo quos. Quo est similique. Quos doloremque id a quae voluptatum ut enim animi. Qui natus temporibus. Quis deserunt dignissimos fuga vel quia et veniam ut." },
                    { 292, 82, 2, 475472, new DateTime(2021, 4, 20, 6, 28, 39, 138, DateTimeKind.Local).AddTicks(6598), "Rem veniam et voluptatem totam dolores eum aliquid. Est commodi qui debitis dolores. Beatae minus et et a qui cumque. Explicabo explicabo explicabo. Repellat unde ut." },
                    { 304, 82, 5, 978691, new DateTime(2021, 4, 30, 10, 5, 47, 983, DateTimeKind.Local).AddTicks(5388), "dolores" },
                    { 439, 10, 101, 338780, new DateTime(2021, 1, 6, 20, 54, 43, 691, DateTimeKind.Local).AddTicks(325), "odit" },
                    { 56, 78, 95, 254657, new DateTime(2021, 4, 17, 3, 30, 47, 465, DateTimeKind.Local).AddTicks(5569), "Soluta possimus est sapiente rerum numquam." },
                    { 150, 78, 122, 739228, new DateTime(2021, 5, 14, 14, 40, 39, 36, DateTimeKind.Local).AddTicks(4500), "In et laudantium. Laudantium qui quia excepturi assumenda est molestiae. Ea rem nulla. Explicabo totam voluptatem officia possimus possimus. Voluptatibus soluta totam omnis fugit possimus." },
                    { 229, 78, 40, 310356, new DateTime(2021, 5, 24, 11, 55, 42, 203, DateTimeKind.Local).AddTicks(5183), "Nihil suscipit qui similique est omnis et nihil. Cupiditate non ea accusantium aut ut delectus. Aperiam laboriosam culpa magni magni est voluptas minus. Labore nobis voluptate est repudiandae inventore atque in repellendus." },
                    { 365, 78, 147, 17664, new DateTime(2021, 5, 18, 20, 16, 33, 328, DateTimeKind.Local).AddTicks(6047), "Esse distinctio amet quia dignissimos placeat ut voluptas. Sint dolor debitis. Sed maxime tempore. Assumenda qui unde corporis veniam magnam doloremque aperiam odio nostrum." },
                    { 458, 78, 19, 296600, new DateTime(2021, 3, 7, 12, 44, 3, 330, DateTimeKind.Local).AddTicks(6215), "libero" },
                    { 519, 78, 28, 582411, new DateTime(2021, 3, 14, 11, 52, 46, 365, DateTimeKind.Local).AddTicks(7213), "Et reiciendis rem consequuntur cumque rerum. Assumenda et consequatur. Dolor optio maiores eos facere quis adipisci. Dolorem deserunt quis consectetur natus neque tempore occaecati." },
                    { 464, 29, 6, 41767, new DateTime(2020, 12, 7, 7, 8, 48, 124, DateTimeKind.Local).AddTicks(6269), "Et alias non magnam rerum nostrum est autem.\nQuis dolores ipsam dignissimos ipsum." },
                    { 522, 78, 108, 752109, new DateTime(2020, 12, 24, 9, 3, 23, 565, DateTimeKind.Local).AddTicks(1253), "accusantium" },
                    { 209, 29, 16, 824301, new DateTime(2021, 7, 16, 4, 35, 42, 653, DateTimeKind.Local).AddTicks(6534), "Aut nihil hic et et nisi omnis veniam quia. Quasi sit unde et doloremque. Et impedit quia sint. Cumque quis iusto a delectus ut. Atque hic blanditiis sunt consequuntur iure est voluptatem ab ratione. Est at atque voluptatem optio id." },
                    { 3, 29, 26, 736567, new DateTime(2021, 6, 22, 22, 57, 46, 676, DateTimeKind.Local).AddTicks(5814), "Debitis aut nesciunt fugit qui." },
                    { 58, 52, 102, 814969, new DateTime(2021, 4, 21, 15, 20, 56, 334, DateTimeKind.Local).AddTicks(9530), "Et at repudiandae ratione nobis aut eaque.\nQuia asperiores maxime ea ex." },
                    { 113, 52, 140, 351109, new DateTime(2020, 9, 19, 17, 32, 24, 67, DateTimeKind.Local).AddTicks(3490), "Recusandae aut amet at eaque possimus odit odio." },
                    { 166, 52, 65, 968339, new DateTime(2021, 4, 21, 17, 52, 41, 495, DateTimeKind.Local).AddTicks(5194), "Adipisci molestiae accusantium dolor atque harum qui." },
                    { 216, 52, 142, 523173, new DateTime(2020, 11, 16, 23, 22, 7, 151, DateTimeKind.Local).AddTicks(9929), "Aliquid explicabo veniam." },
                    { 381, 52, 37, 634444, new DateTime(2021, 1, 15, 16, 26, 6, 820, DateTimeKind.Local).AddTicks(127), "dolor" },
                    { 489, 52, 85, 293301, new DateTime(2021, 2, 13, 4, 35, 4, 76, DateTimeKind.Local).AddTicks(7246), "Ad soluta omnis non et quidem ex ut.\nConsectetur ipsa dolores accusantium doloremque possimus nemo earum rerum numquam.\nEa ut harum non culpa.\nRepellat et magni quia dolorum ipsum aut illo.\nDebitis dolorem itaque dolorem.\nAssumenda animi ullam doloremque beatae pariatur." },
                    { 499, 52, 113, 856088, new DateTime(2020, 8, 23, 12, 29, 34, 412, DateTimeKind.Local).AddTicks(2798), "Officia eos quod.\nSed qui ea blanditiis.\nCupiditate nobis omnis.\nTenetur modi eius fugiat sit nemo sit.\nNihil sit cupiditate reiciendis incidunt similique assumenda voluptas delectus.\nQuia ut ipsa." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 545, 52, 105, 70571, new DateTime(2021, 5, 17, 13, 20, 11, 664, DateTimeKind.Local).AddTicks(1303), "earum" },
                    { 567, 52, 67, 716064, new DateTime(2020, 8, 20, 10, 12, 17, 463, DateTimeKind.Local).AddTicks(7736), "Et deleniti nemo excepturi est illum voluptates blanditiis quas. Voluptatem voluptate deserunt deserunt temporibus sapiente earum itaque. Tempore eaque consectetur laudantium aut sed." },
                    { 595, 52, 64, 197173, new DateTime(2020, 12, 28, 11, 17, 41, 962, DateTimeKind.Local).AddTicks(6263), "dolorem" },
                    { 549, 10, 139, 664002, new DateTime(2020, 8, 20, 21, 59, 5, 284, DateTimeKind.Local).AddTicks(5367), "Rem consequuntur enim.\nUt in eaque assumenda.\nSaepe temporibus voluptatibus hic sed nulla omnis." },
                    { 34, 75, 49, 660731, new DateTime(2020, 8, 17, 21, 8, 48, 695, DateTimeKind.Local).AddTicks(9867), "Ratione qui odio ea magnam ut ut aspernatur." },
                    { 126, 75, 46, 234120, new DateTime(2020, 8, 25, 14, 15, 56, 107, DateTimeKind.Local).AddTicks(7184), "sint" },
                    { 161, 75, 64, 905589, new DateTime(2020, 11, 2, 18, 27, 55, 649, DateTimeKind.Local).AddTicks(4933), "Deleniti autem est eaque unde.\nConsequatur eius error culpa vitae quia.\nMagnam repellendus rerum.\nDolorem soluta facilis numquam est.\nVoluptas odio itaque ex omnis eveniet ut eligendi non architecto.\nQuae suscipit dicta." },
                    { 172, 75, 13, 644778, new DateTime(2020, 8, 20, 14, 15, 15, 437, DateTimeKind.Local).AddTicks(3360), "adipisci" },
                    { 140, 29, 82, 307227, new DateTime(2021, 4, 27, 12, 22, 58, 84, DateTimeKind.Local).AddTicks(1669), "Aut fugiat eius aliquid.\nSoluta ab enim sint.\nSit ratione praesentium hic." },
                    { 327, 54, 65, 186289, new DateTime(2020, 9, 23, 16, 14, 7, 335, DateTimeKind.Local).AddTicks(7872), "Adipisci eum in eos quia consequatur ut expedita." },
                    { 527, 78, 47, 440161, new DateTime(2021, 4, 27, 0, 54, 11, 699, DateTimeKind.Local).AddTicks(1458), "natus" },
                    { 116, 7, 73, 527038, new DateTime(2021, 3, 17, 19, 21, 16, 209, DateTimeKind.Local).AddTicks(4661), "ut" },
                    { 129, 41, 86, 731191, new DateTime(2021, 7, 13, 18, 47, 48, 107, DateTimeKind.Local).AddTicks(4536), "voluptas" },
                    { 351, 41, 146, 936459, new DateTime(2021, 8, 3, 14, 55, 15, 430, DateTimeKind.Local).AddTicks(1666), "Et ut molestias ut delectus dignissimos omnis. Aut iusto quo fugiat veniam ut aliquid sed. Ut optio enim quo. Ipsa accusamus nam ut nisi et ullam aut cupiditate. Vel libero optio modi. Accusamus quos tempora corporis atque quia soluta." },
                    { 375, 41, 8, 470949, new DateTime(2021, 6, 6, 8, 54, 11, 770, DateTimeKind.Local).AddTicks(5958), "Quia similique incidunt quia odit dolor necessitatibus. Ex pariatur culpa laborum earum animi ipsam est. Sit architecto vitae et amet. Eligendi hic similique eum deserunt necessitatibus. Magnam modi veniam ducimus ducimus in cupiditate quia." },
                    { 547, 41, 25, 813306, new DateTime(2021, 2, 11, 20, 51, 20, 506, DateTimeKind.Local).AddTicks(2767), "dignissimos" },
                    { 82, 73, 88, 238685, new DateTime(2021, 6, 19, 5, 58, 56, 765, DateTimeKind.Local).AddTicks(1329), "Iste deleniti delectus.\nNisi sit aliquid quia nostrum temporibus voluptates atque occaecati porro.\nUt odit eaque.\nMolestiae rerum similique." },
                    { 210, 73, 119, 444336, new DateTime(2020, 9, 18, 3, 29, 7, 679, DateTimeKind.Local).AddTicks(350), "Accusamus totam vel.\nEsse sint tempore." },
                    { 297, 73, 109, 445427, new DateTime(2021, 1, 6, 8, 3, 4, 537, DateTimeKind.Local).AddTicks(6475), "Voluptatibus vero et velit in.\nDolores minus tempore et perferendis aliquid omnis.\nPraesentium culpa ut nulla necessitatibus minus nemo odio est assumenda." },
                    { 357, 73, 94, 987089, new DateTime(2021, 4, 20, 7, 33, 29, 867, DateTimeKind.Local).AddTicks(5174), "In possimus voluptatibus voluptatum iusto officia repudiandae numquam." },
                    { 593, 73, 106, 416431, new DateTime(2020, 10, 19, 9, 15, 31, 587, DateTimeKind.Local).AddTicks(5323), "Aut et voluptate voluptatem suscipit facere in laborum alias repellat.\nQuibusdam qui qui voluptas animi repudiandae animi ipsa.\nEos quia reprehenderit ullam consequatur perspiciatis accusamus.\nCulpa enim consequatur non perferendis asperiores sed illum rem esse.\nMolestiae placeat voluptas ab id quaerat." },
                    { 403, 11, 9, 162137, new DateTime(2021, 1, 8, 9, 16, 26, 783, DateTimeKind.Local).AddTicks(1424), "Voluptas quae nihil beatae non ut quisquam quia." },
                    { 40, 2, 130, 212782, new DateTime(2021, 5, 2, 5, 39, 10, 67, DateTimeKind.Local).AddTicks(1495), "Nemo ab quam sunt dolores tenetur occaecati." },
                    { 91, 2, 3, 9517, new DateTime(2021, 6, 18, 21, 20, 20, 445, DateTimeKind.Local).AddTicks(4404), "Porro minus sint repellendus et enim. Non et nesciunt dolore ex rem consectetur tenetur nihil. Ex est id voluptas magnam laudantium architecto tenetur. Commodi est est. Doloremque aut non ipsam qui nemo nihil sunt nobis vitae. Nostrum quis molestiae eaque qui molestiae vero." },
                    { 371, 2, 79, 599222, new DateTime(2021, 5, 15, 22, 52, 54, 541, DateTimeKind.Local).AddTicks(7981), "Libero corporis cum." },
                    { 380, 2, 34, 811260, new DateTime(2021, 3, 27, 9, 20, 24, 290, DateTimeKind.Local).AddTicks(5841), "Est neque odit culpa facere quisquam sit voluptas.\nMaiores in reiciendis non consectetur.\nRecusandae aliquam dolorem voluptatem cum.\nSed non deleniti sit recusandae et iure voluptatem praesentium quia.\nQuisquam modi nostrum reprehenderit laboriosam quia quaerat repellendus.\nFugit quis sequi quo omnis modi numquam necessitatibus." },
                    { 395, 2, 62, 404450, new DateTime(2021, 2, 14, 1, 1, 27, 749, DateTimeKind.Local).AddTicks(2007), "Debitis repellendus molestias iste voluptatem eius eius ipsa. Dicta est et autem omnis qui maxime sunt quam. Id minus tempore aperiam officiis. Ea deleniti et impedit molestiae et inventore in deserunt." },
                    { 505, 27, 131, 855491, new DateTime(2020, 9, 20, 3, 26, 32, 658, DateTimeKind.Local).AddTicks(8784), "Reprehenderit pariatur quo non possimus ullam et." },
                    { 378, 10, 55, 650222, new DateTime(2021, 8, 11, 22, 45, 22, 372, DateTimeKind.Local).AddTicks(9972), "Et quam eum ducimus.\nConsequuntur accusamus et ad esse occaecati amet.\nOfficia in aut est modi.\nConsequatur laborum omnis odio eum." },
                    { 457, 27, 108, 703217, new DateTime(2020, 11, 16, 14, 39, 35, 38, DateTimeKind.Local).AddTicks(2235), "quas" },
                    { 377, 27, 112, 522132, new DateTime(2021, 5, 22, 13, 48, 55, 159, DateTimeKind.Local).AddTicks(1678), "Occaecati amet et quia quia excepturi recusandae distinctio. Eius et animi. Dicta et et. In quo sed consequuntur sit voluptas expedita. Velit qui quo corporis eligendi est aspernatur. Amet dicta esse hic." },
                    { 252, 7, 33, 664575, new DateTime(2021, 7, 17, 6, 18, 38, 737, DateTimeKind.Local).AddTicks(5462), "sed" },
                    { 345, 7, 85, 691612, new DateTime(2020, 10, 9, 0, 58, 37, 660, DateTimeKind.Local).AddTicks(5146), "animi" },
                    { 392, 7, 144, 970532, new DateTime(2021, 1, 31, 3, 25, 14, 974, DateTimeKind.Local).AddTicks(4655), "Laboriosam inventore aut nemo consequatur consectetur." },
                    { 529, 7, 19, 76347, new DateTime(2020, 12, 27, 8, 26, 48, 943, DateTimeKind.Local).AddTicks(6641), "Sed sed magnam labore provident voluptate quo ipsum molestiae atque.\nDoloribus omnis rem aut saepe sequi hic aut." },
                    { 552, 7, 75, 317688, new DateTime(2021, 1, 4, 9, 56, 12, 252, DateTimeKind.Local).AddTicks(9004), "Sit laudantium voluptate cumque sunt." },
                    { 220, 10, 141, 233963, new DateTime(2021, 7, 25, 12, 59, 39, 137, DateTimeKind.Local).AddTicks(2811), "quis" },
                    { 84, 8, 113, 727981, new DateTime(2021, 4, 12, 23, 14, 30, 797, DateTimeKind.Local).AddTicks(3543), "Ipsam ullam perspiciatis.\nError ut ea aut perferendis quia.\nUt quo dolorum ea voluptatem neque occaecati laborum consequatur doloribus." },
                    { 115, 8, 72, 435657, new DateTime(2021, 8, 7, 10, 51, 32, 425, DateTimeKind.Local).AddTicks(7863), "At nemo consequatur sapiente fugit quia qui autem sed.\nNihil corrupti tempore labore cum commodi." },
                    { 253, 8, 136, 928128, new DateTime(2021, 7, 3, 22, 28, 44, 456, DateTimeKind.Local).AddTicks(7905), "adipisci" },
                    { 362, 8, 55, 234979, new DateTime(2021, 5, 9, 3, 21, 22, 370, DateTimeKind.Local).AddTicks(3391), "ea" },
                    { 511, 8, 13, 476071, new DateTime(2020, 11, 12, 11, 35, 33, 513, DateTimeKind.Local).AddTicks(1029), "Fuga suscipit reiciendis temporibus. Exercitationem qui nisi. Sit quis laudantium aut molestias harum." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 589, 8, 32, 200975, new DateTime(2021, 2, 20, 10, 36, 30, 43, DateTimeKind.Local).AddTicks(7724), "Non necessitatibus ipsum dolorem inventore corrupti nulla temporibus ut numquam. Laborum error qui consequuntur omnis doloribus dolores nisi nostrum. Quia cum tenetur animi et et voluptatem enim consequuntur. Quaerat unde autem numquam laudantium. Aut amet delectus facere dolorum assumenda quam ut eaque. Omnis ut nam nihil dolores cupiditate." },
                    { 243, 27, 23, 653193, new DateTime(2020, 11, 10, 20, 33, 0, 913, DateTimeKind.Local).AddTicks(1579), "Et rerum sint rerum reprehenderit sint voluptates.\nAlias ut in ea error.\nAliquam nobis temporibus reprehenderit quisquam perspiciatis sit recusandae.\nMinima aspernatur voluptas consequuntur alias sed deleniti natus nostrum." },
                    { 295, 27, 77, 84797, new DateTime(2021, 5, 11, 9, 42, 26, 742, DateTimeKind.Local).AddTicks(6599), "Velit numquam consequuntur nisi aliquid culpa ad molestiae voluptas sapiente." },
                    { 340, 27, 10, 369101, new DateTime(2020, 12, 12, 5, 27, 9, 707, DateTimeKind.Local).AddTicks(9094), "Placeat qui quidem." },
                    { 382, 27, 2, 233121, new DateTime(2021, 2, 9, 14, 58, 47, 163, DateTimeKind.Local).AddTicks(2865), "Ducimus autem omnis molestiae quaerat maiores eveniet debitis deserunt non. Provident reiciendis fugiat maxime quis facilis sunt quo doloremque et. Est consectetur molestiae corrupti odio quisquam possimus porro beatae iusto. Possimus libero in autem voluptates." },
                    { 54, 11, 26, 638404, new DateTime(2021, 5, 1, 0, 10, 17, 630, DateTimeKind.Local).AddTicks(4200), "Porro unde et et voluptas consequuntur.\nAut quae porro.\nTemporibus aspernatur quibusdam nihil.\nAlias ipsa voluptatem occaecati recusandae nostrum et sed.\nNemo quis quae reprehenderit.\nVelit assumenda voluptas." },
                    { 570, 60, 20, 826555, new DateTime(2021, 1, 1, 8, 12, 46, 413, DateTimeKind.Local).AddTicks(4534), "dolorum" },
                    { 492, 60, 8, 158269, new DateTime(2021, 2, 23, 6, 16, 35, 829, DateTimeKind.Local).AddTicks(7179), "Eos est enim dolorum incidunt veritatis deleniti nihil." },
                    { 180, 12, 50, 317703, new DateTime(2020, 12, 10, 5, 8, 2, 15, DateTimeKind.Local).AddTicks(9713), "quia" },
                    { 232, 12, 15, 84138, new DateTime(2021, 2, 5, 20, 15, 46, 51, DateTimeKind.Local).AddTicks(7861), "Molestiae qui corporis nostrum consequatur iusto reiciendis ullam est possimus. Excepturi mollitia nemo doloribus ullam omnis ea ut. Quo eum neque quidem velit possimus reiciendis maiores omnis. Libero ex iste ut. Exercitationem nemo natus distinctio quia necessitatibus adipisci. Id consequatur voluptas molestiae quia in recusandae nesciunt doloribus." },
                    { 322, 12, 138, 328652, new DateTime(2020, 8, 21, 15, 20, 15, 495, DateTimeKind.Local).AddTicks(2561), "sit" },
                    { 329, 12, 43, 56775, new DateTime(2020, 11, 8, 17, 9, 0, 76, DateTimeKind.Local).AddTicks(3260), "Cupiditate omnis at labore voluptate quod est sunt id. Et expedita aliquid sit neque totam ut laboriosam. Et sunt unde quo in quasi qui inventore. Ratione quasi omnis explicabo eligendi pariatur. Dolorum debitis rerum vel laborum voluptatem quia. Sint architecto eaque repellat blanditiis dolores cumque saepe." },
                    { 338, 12, 52, 51267, new DateTime(2020, 8, 22, 16, 18, 47, 364, DateTimeKind.Local).AddTicks(8411), "Itaque velit corrupti in aut et et nemo eaque." },
                    { 413, 12, 7, 116364, new DateTime(2020, 9, 5, 0, 44, 14, 759, DateTimeKind.Local).AddTicks(6724), "Libero et et aut rerum.\nExcepturi pariatur beatae." },
                    { 179, 12, 141, 315414, new DateTime(2020, 11, 14, 2, 51, 49, 494, DateTimeKind.Local).AddTicks(6888), "Aut et quae et est non provident.\nPossimus reprehenderit laborum rem facere voluptatem.\nId laboriosam recusandae voluptatem ut quia qui rerum.\nAmet aut iste in accusantium aliquid." },
                    { 461, 12, 8, 675431, new DateTime(2020, 9, 1, 6, 1, 51, 980, DateTimeKind.Local).AddTicks(1237), "doloremque" },
                    { 544, 12, 41, 437178, new DateTime(2021, 8, 2, 3, 5, 33, 107, DateTimeKind.Local).AddTicks(5910), "consequuntur" },
                    { 548, 26, 150, 245662, new DateTime(2021, 4, 10, 21, 47, 55, 57, DateTimeKind.Local).AddTicks(1706), "Eaque nam qui voluptas vero et sit doloremque.\nEx et neque possimus nesciunt qui consequatur repudiandae odit.\nVoluptatum dignissimos minus libero sunt repellat.\nSit sed omnis facilis qui molestias consequuntur maiores facilis.\nEius non nesciunt sint et nam facere consequatur laudantium beatae.\nVeniam cum consequatur culpa illo labore." },
                    { 74, 67, 30, 202734, new DateTime(2020, 9, 2, 18, 22, 58, 349, DateTimeKind.Local).AddTicks(1588), "quidem" },
                    { 77, 67, 78, 872963, new DateTime(2020, 10, 7, 0, 26, 30, 581, DateTimeKind.Local).AddTicks(587), "Cupiditate animi doloribus consequatur. Sint ut dignissimos recusandae aut aliquid dolor officiis ex. Ut et quo facere odit sint atque et explicabo rerum. In minus amet voluptatem quia ab nostrum qui. Nihil dicta consequatur ducimus dolor enim vitae. Facilis occaecati quo." },
                    { 212, 67, 57, 433543, new DateTime(2020, 10, 27, 15, 22, 10, 736, DateTimeKind.Local).AddTicks(6022), "Repellendus at voluptates suscipit cumque distinctio aut. Minus sed voluptatum atque et maiores est. Qui ut amet nam velit tempora provident iure." },
                    { 290, 67, 133, 859370, new DateTime(2021, 1, 9, 16, 33, 59, 76, DateTimeKind.Local).AddTicks(8886), "Eveniet dolorem fugit a.\nPariatur sed sint distinctio neque unde quo quia.\nUt iusto eum." },
                    { 477, 12, 37, 581034, new DateTime(2020, 9, 9, 14, 28, 2, 653, DateTimeKind.Local).AddTicks(8625), "autem" },
                    { 1, 12, 14, 984658, new DateTime(2021, 7, 22, 0, 16, 35, 102, DateTimeKind.Local).AddTicks(2355), "vitae" },
                    { 510, 81, 150, 399716, new DateTime(2020, 9, 30, 12, 22, 56, 476, DateTimeKind.Local).AddTicks(3824), "Officiis vero vero commodi molestias sapiente error placeat alias dignissimos. Ullam a mollitia corporis. Voluptas ea fugiat omnis iure non. Cupiditate doloribus quae maiores illo fugit. Ut voluptatem numquam incidunt quisquam. Ipsa accusantium praesentium harum ut." },
                    { 402, 81, 85, 792504, new DateTime(2021, 1, 25, 13, 7, 5, 203, DateTimeKind.Local).AddTicks(9935), "vero" },
                    { 103, 3, 4, 89941, new DateTime(2021, 3, 1, 14, 43, 40, 484, DateTimeKind.Local).AddTicks(7411), "Qui rerum nihil aut culpa voluptates vitae molestiae non velit.\nCorporis a sit commodi autem cum cum ipsum nobis non." },
                    { 193, 3, 34, 336626, new DateTime(2020, 10, 21, 9, 42, 18, 1, DateTimeKind.Local).AddTicks(6285), "Inventore dolorum ut." },
                    { 238, 3, 115, 643653, new DateTime(2021, 6, 23, 20, 7, 55, 525, DateTimeKind.Local).AddTicks(7371), "aliquam" },
                    { 534, 3, 121, 871453, new DateTime(2021, 2, 3, 22, 44, 46, 544, DateTimeKind.Local).AddTicks(289), "Vel soluta sequi amet." },
                    { 26, 23, 44, 491259, new DateTime(2020, 8, 26, 14, 21, 46, 729, DateTimeKind.Local).AddTicks(4148), "Porro soluta modi rerum atque praesentium sit at eum." },
                    { 92, 23, 66, 468971, new DateTime(2021, 1, 25, 0, 15, 43, 710, DateTimeKind.Local).AddTicks(387), "consequatur" },
                    { 114, 23, 70, 675871, new DateTime(2021, 4, 22, 6, 59, 34, 319, DateTimeKind.Local).AddTicks(1586), "Quia earum voluptatum magnam ut aut fuga." },
                    { 187, 23, 76, 525891, new DateTime(2020, 11, 2, 6, 20, 55, 207, DateTimeKind.Local).AddTicks(3010), "Et veniam tempora molestias voluptatem enim. Aliquam minima deleniti molestias facere. Amet quos voluptatem. Nihil eaque nesciunt est eos neque laboriosam est praesentium." },
                    { 390, 23, 81, 583433, new DateTime(2021, 6, 19, 23, 25, 6, 785, DateTimeKind.Local).AddTicks(8411), "Ab et officia officia magnam qui magnam ratione tempore iusto. Et totam fugit. Ut nihil maxime magnam aut." },
                    { 584, 23, 111, 674276, new DateTime(2021, 1, 5, 8, 27, 23, 813, DateTimeKind.Local).AddTicks(3556), "Commodi voluptatem sequi cumque. Qui rerum assumenda consequatur iste soluta itaque laboriosam. Et voluptate illum animi dolor. Veniam ut amet modi sint quis." },
                    { 76, 81, 63, 789225, new DateTime(2020, 10, 27, 13, 43, 8, 994, DateTimeKind.Local).AddTicks(4843), "Numquam perspiciatis nihil quam numquam.\nVoluptas corporis id laudantium corporis.\nIpsum voluptatem qui ipsam eaque.\nBeatae delectus delectus aliquid et cupiditate.\nVeniam ut aut consequuntur qui aut corporis beatae id enim.\nNon cupiditate doloribus qui accusamus sit est incidunt." },
                    { 221, 81, 9, 191166, new DateTime(2021, 6, 18, 20, 8, 52, 447, DateTimeKind.Local).AddTicks(7886), "Est necessitatibus qui itaque quae facilis praesentium tempore illum." },
                    { 271, 81, 81, 422223, new DateTime(2021, 7, 3, 13, 53, 41, 834, DateTimeKind.Local).AddTicks(7667), "Est omnis sed molestiae vero sunt enim voluptatem voluptas.\nCumque a et at quia eos veniam voluptas quos quos.\nDicta perspiciatis ut dolores.\nSit nam rerum sit voluptatem.\nDolores neque nam omnis commodi et facilis beatae." },
                    { 324, 81, 111, 704853, new DateTime(2020, 10, 18, 4, 13, 27, 456, DateTimeKind.Local).AddTicks(7900), "Nisi consequatur unde adipisci a distinctio dolor. Accusamus omnis vel qui occaecati dolorem odit dolor suscipit facere. Asperiores earum dolores sint. Nesciunt soluta eos eum odit quis saepe dolor fugiat et." },
                    { 356, 81, 11, 1696, new DateTime(2021, 1, 8, 1, 47, 56, 111, DateTimeKind.Local).AddTicks(8826), "ea" },
                    { 466, 67, 66, 926000, new DateTime(2021, 6, 8, 5, 32, 22, 433, DateTimeKind.Local).AddTicks(6011), "Quia dolorem eveniet. Laborum aut fugit. Est et eum asperiores consequuntur nihil laborum voluptatem non a." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 509, 26, 23, 761482, new DateTime(2020, 9, 8, 1, 16, 28, 487, DateTimeKind.Local).AddTicks(1895), "repellendus" },
                    { 184, 83, 52, 224782, new DateTime(2021, 2, 6, 12, 39, 8, 748, DateTimeKind.Local).AddTicks(1187), "Sit sunt exercitationem.\nAut expedita aperiam ipsam incidunt.\nEligendi ea placeat earum minima.\nReprehenderit pariatur est ea enim.\nQui sapiente autem nobis optio officia expedita voluptas animi maxime." },
                    { 280, 83, 26, 329977, new DateTime(2020, 10, 24, 7, 30, 27, 649, DateTimeKind.Local).AddTicks(1773), "Iste laudantium sequi ea quo blanditiis facere tempora. Harum eius nam. Nam quia dolor ut corporis. Amet dolorem et nostrum voluptate in." },
                    { 6, 14, 126, 890283, new DateTime(2020, 11, 1, 1, 36, 43, 556, DateTimeKind.Local).AddTicks(2183), "Voluptatem quia qui a architecto reprehenderit dolor occaecati. Accusantium ipsam voluptas perspiciatis magni. Maiores ut quia ut et maiores." },
                    { 53, 14, 90, 765261, new DateTime(2021, 3, 9, 2, 25, 56, 279, DateTimeKind.Local).AddTicks(7094), "Minima eius praesentium distinctio reprehenderit.\nIllo voluptas accusamus." },
                    { 57, 14, 136, 313994, new DateTime(2021, 7, 21, 7, 48, 1, 633, DateTimeKind.Local).AddTicks(3169), "Quo numquam perferendis quia eum." },
                    { 196, 14, 108, 112183, new DateTime(2021, 5, 12, 23, 9, 46, 452, DateTimeKind.Local).AddTicks(241), "Voluptatem non corrupti voluptatibus perspiciatis vitae qui. Est quibusdam sit officia nostrum quo nemo excepturi incidunt qui. Voluptas dicta ad sunt iste est sit architecto explicabo quam." },
                    { 225, 14, 89, 275737, new DateTime(2021, 2, 1, 19, 52, 1, 646, DateTimeKind.Local).AddTicks(8547), "Magnam quidem ut non quis ex." },
                    { 256, 14, 61, 367067, new DateTime(2021, 7, 25, 11, 16, 16, 359, DateTimeKind.Local).AddTicks(6717), "accusamus" },
                    { 459, 14, 105, 914125, new DateTime(2021, 2, 5, 6, 30, 54, 233, DateTimeKind.Local).AddTicks(6205), "Possimus eum sed reiciendis aut.\nHarum officia in alias accusamus quod.\nNon accusamus quidem odio.\nEa iusto dolores.\nSit quibusdam placeat aspernatur laboriosam id facilis.\nEos illum odit veniam reprehenderit eum id dolore molestiae commodi." },
                    { 556, 14, 53, 752582, new DateTime(2020, 8, 28, 7, 58, 17, 114, DateTimeKind.Local).AddTicks(149), "natus" },
                    { 213, 26, 22, 148164, new DateTime(2021, 5, 21, 2, 12, 40, 935, DateTimeKind.Local).AddTicks(7139), "Vel temporibus possimus rerum vitae earum laudantium ut et." },
                    { 10, 57, 38, 140579, new DateTime(2021, 7, 24, 9, 24, 29, 122, DateTimeKind.Local).AddTicks(8839), "Molestiae ipsum eius deserunt autem et. Temporibus dolorum eos cupiditate. Quam accusamus nemo animi rerum voluptas eos. Repellendus quo aut commodi sunt qui velit et sint. Amet consequatur voluptas quas voluptatibus quo eos iure earum." },
                    { 62, 57, 49, 270772, new DateTime(2021, 1, 6, 7, 8, 7, 887, DateTimeKind.Local).AddTicks(4833), "Laborum vel sed maiores molestiae et." },
                    { 71, 57, 71, 113923, new DateTime(2021, 3, 14, 3, 31, 2, 159, DateTimeKind.Local).AddTicks(7378), "Vel beatae omnis ut sequi est." },
                    { 102, 57, 51, 799469, new DateTime(2020, 12, 26, 14, 42, 4, 777, DateTimeKind.Local).AddTicks(1301), "Nesciunt commodi repellendus doloribus commodi sequi.\nNeque nobis distinctio qui.\nQuibusdam deserunt ducimus aut sunt similique.\nRatione nostrum dolores suscipit impedit consequatur." },
                    { 197, 57, 113, 672467, new DateTime(2021, 5, 7, 13, 34, 44, 119, DateTimeKind.Local).AddTicks(5648), "Quo voluptatum ipsam sit molestiae in earum est.\nIste atque aperiam labore aut.\nQui sapiente minima atque officiis a recusandae nostrum non aut.\nSimilique iusto nobis pariatur et laborum." },
                    { 214, 57, 109, 721477, new DateTime(2020, 9, 15, 3, 56, 2, 77, DateTimeKind.Local).AddTicks(9595), "Adipisci cum enim doloremque assumenda laudantium optio voluptatum ratione.\nQuia occaecati perspiciatis ut vero harum amet." },
                    { 279, 26, 23, 86776, new DateTime(2020, 12, 25, 3, 38, 25, 340, DateTimeKind.Local).AddTicks(4717), "Iusto dolores est voluptates fuga aliquam. Quia voluptatum eos et neque necessitatibus aliquid quas. Sit sunt quisquam aut consequuntur doloremque et et culpa." },
                    { 85, 3, 77, 27929, new DateTime(2020, 8, 26, 15, 1, 2, 586, DateTimeKind.Local).AddTicks(9114), "consequatur" },
                    { 566, 55, 11, 790324, new DateTime(2021, 3, 18, 20, 36, 26, 647, DateTimeKind.Local).AddTicks(8871), "Quia ea pariatur maxime. Dolorum omnis quos saepe voluptatem veritatis quasi illo minus. Eius dolorem est non." },
                    { 419, 55, 146, 582856, new DateTime(2021, 4, 19, 21, 17, 16, 472, DateTimeKind.Local).AddTicks(3172), "Ea adipisci nam aperiam." },
                    { 506, 83, 90, 523443, new DateTime(2020, 9, 13, 6, 59, 39, 321, DateTimeKind.Local).AddTicks(3453), "Reprehenderit sapiente culpa mollitia et similique dolor qui." },
                    { 540, 83, 43, 504600, new DateTime(2021, 6, 3, 4, 14, 15, 822, DateTimeKind.Local).AddTicks(4688), "Facere voluptates est facere quibusdam et et." },
                    { 456, 26, 127, 223599, new DateTime(2020, 10, 4, 2, 50, 15, 361, DateTimeKind.Local).AddTicks(171), "Et ratione non." },
                    { 206, 13, 20, 958998, new DateTime(2021, 1, 13, 22, 32, 31, 235, DateTimeKind.Local).AddTicks(3025), "Enim quas et quae dolor numquam architecto porro.\nEa eum aut velit.\nQui ut ea corporis praesentium et.\nModi dolorem quia sit et quam.\nVoluptatem sed aut pariatur accusantium adipisci cum sed ut.\nUt fugit dolorum quidem magni quibusdam sit rerum ratione." },
                    { 240, 13, 146, 234633, new DateTime(2020, 12, 26, 6, 36, 26, 795, DateTimeKind.Local).AddTicks(1957), "incidunt" },
                    { 272, 13, 104, 158014, new DateTime(2020, 9, 20, 20, 15, 45, 612, DateTimeKind.Local).AddTicks(9626), "Tenetur ut eos ut repellat." },
                    { 398, 13, 16, 70262, new DateTime(2021, 4, 16, 8, 52, 55, 274, DateTimeKind.Local).AddTicks(8966), "sed" },
                    { 437, 13, 1, 248384, new DateTime(2020, 12, 17, 18, 48, 56, 709, DateTimeKind.Local).AddTicks(9881), "ipsum" },
                    { 586, 13, 29, 265650, new DateTime(2020, 9, 26, 23, 27, 58, 131, DateTimeKind.Local).AddTicks(3612), "Laboriosam eos dolores earum tempore deleniti veritatis in." },
                    { 411, 26, 115, 942859, new DateTime(2020, 9, 27, 14, 20, 10, 803, DateTimeKind.Local).AddTicks(7630), "Dolores aut sit officiis a omnis sapiente ut.\nOmnis fugit necessitatibus magnam.\nEaque amet dignissimos molestiae qui praesentium fuga ea omnis numquam." },
                    { 110, 55, 117, 919399, new DateTime(2021, 6, 1, 23, 19, 42, 708, DateTimeKind.Local).AddTicks(4612), "Consequatur doloribus fugiat illo dolore voluptatem et nulla dolor. Deserunt non et quo distinctio omnis quia eius maiores consequatur. Dicta nobis sunt consequatur. Totam vitae dolores unde molestias dolor." },
                    { 149, 55, 115, 269134, new DateTime(2021, 3, 1, 19, 16, 1, 959, DateTimeKind.Local).AddTicks(1978), "Molestias repellendus voluptatum et at temporibus occaecati et quo sit.\nImpedit modi dolore corrupti dolorem magnam et." },
                    { 160, 55, 114, 715188, new DateTime(2020, 11, 17, 21, 7, 25, 35, DateTimeKind.Local).AddTicks(2977), "aliquid" },
                    { 358, 55, 140, 963597, new DateTime(2021, 4, 12, 17, 2, 53, 604, DateTimeKind.Local).AddTicks(8445), "Magni sapiente aliquid veniam mollitia velit facere. Aut adipisci facilis ut quia. Dicta incidunt aspernatur. Quis rerum ut dolore quae sequi et." },
                    { 408, 55, 145, 747831, new DateTime(2021, 7, 23, 23, 43, 9, 656, DateTimeKind.Local).AddTicks(1893), "In consequatur ipsam inventore animi voluptas iste." },
                    { 440, 55, 20, 111317, new DateTime(2021, 6, 21, 12, 0, 19, 395, DateTimeKind.Local).AddTicks(1529), "Dolores quo reprehenderit sunt saepe corporis ullam ipsa quod nulla.\nEos vero molestiae nulla tenetur." },
                    { 60, 3, 48, 586871, new DateTime(2021, 5, 7, 8, 4, 36, 138, DateTimeKind.Local).AddTicks(5427), "Dolor perspiciatis sit animi sunt quisquam temporibus corporis quia. Magni mollitia reiciendis ipsum voluptas totam et. Quasi dolore est corrupti in rerum enim iusto excepturi. Delectus officia odio quo culpa unde rerum qui qui omnis." },
                    { 27, 3, 121, 279543, new DateTime(2020, 9, 20, 7, 2, 9, 979, DateTimeKind.Local).AddTicks(3032), "Minima voluptas veritatis fuga qui sunt tempora et quod." },
                    { 87, 58, 123, 431947, new DateTime(2020, 9, 30, 5, 19, 30, 76, DateTimeKind.Local).AddTicks(7446), "Dolores iusto velit.\nNon architecto voluptas saepe voluptatem voluptatem molestiae rerum." },
                    { 134, 48, 1, 94234, new DateTime(2021, 8, 9, 3, 6, 37, 829, DateTimeKind.Local).AddTicks(6904), "Commodi cumque delectus ut ut laboriosam vero. Quia necessitatibus est accusantium iure occaecati distinctio. Unde explicabo accusamus atque enim. Praesentium accusantium velit harum." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 275, 48, 48, 221009, new DateTime(2021, 6, 15, 8, 19, 1, 262, DateTimeKind.Local).AddTicks(6150), "Similique voluptatibus totam qui.\nMagni nihil sunt quo quas." },
                    { 308, 48, 9, 894120, new DateTime(2020, 8, 29, 2, 20, 18, 361, DateTimeKind.Local).AddTicks(9224), "Cum autem voluptatem autem consequatur ut." },
                    { 309, 48, 101, 488304, new DateTime(2020, 11, 10, 7, 33, 24, 894, DateTimeKind.Local).AddTicks(4836), "Facilis beatae ducimus consequatur deleniti ducimus libero ea." },
                    { 331, 48, 63, 529179, new DateTime(2021, 1, 18, 12, 17, 24, 82, DateTimeKind.Local).AddTicks(8534), "iste" },
                    { 333, 48, 110, 93348, new DateTime(2020, 9, 3, 5, 37, 54, 282, DateTimeKind.Local).AddTicks(2752), "Minus voluptatum quo. Rerum ea vero dolores nobis. Impedit inventore libero iste sit aut." },
                    { 407, 48, 102, 364449, new DateTime(2020, 9, 29, 14, 21, 37, 700, DateTimeKind.Local).AddTicks(644), "sit" },
                    { 501, 48, 138, 584965, new DateTime(2020, 12, 1, 10, 52, 14, 736, DateTimeKind.Local).AddTicks(1036), "Ea unde in. Enim iste corporis animi et enim ut optio. Non earum libero soluta quis." },
                    { 526, 48, 26, 127747, new DateTime(2020, 11, 11, 9, 35, 0, 720, DateTimeKind.Local).AddTicks(3212), "sit" },
                    { 561, 48, 24, 704739, new DateTime(2020, 8, 16, 9, 53, 26, 569, DateTimeKind.Local).AddTicks(8736), "Ut rerum voluptatem voluptatem nam facere necessitatibus aperiam." },
                    { 514, 58, 44, 15130, new DateTime(2021, 6, 6, 18, 24, 44, 652, DateTimeKind.Local).AddTicks(1279), "Alias ut ipsam blanditiis.\nTenetur autem dolor velit officiis impedit.\nIllum in minima doloremque asperiores.\nUllam assumenda quod molestiae sit." },
                    { 41, 53, 110, 438716, new DateTime(2021, 7, 1, 8, 14, 18, 442, DateTimeKind.Local).AddTicks(3453), "Quidem praesentium quis molestiae culpa explicabo asperiores aut." },
                    { 70, 53, 118, 996325, new DateTime(2021, 1, 8, 16, 41, 23, 555, DateTimeKind.Local).AddTicks(3197), "occaecati" },
                    { 127, 53, 13, 329435, new DateTime(2021, 1, 1, 14, 49, 41, 512, DateTimeKind.Local).AddTicks(6358), "A fuga nisi in dignissimos dicta." },
                    { 385, 53, 70, 27800, new DateTime(2020, 9, 14, 11, 12, 8, 773, DateTimeKind.Local).AddTicks(355), "saepe" },
                    { 515, 45, 73, 860749, new DateTime(2021, 8, 7, 21, 34, 32, 984, DateTimeKind.Local).AddTicks(6958), "officiis" },
                    { 452, 53, 14, 147107, new DateTime(2021, 8, 4, 10, 35, 31, 259, DateTimeKind.Local).AddTicks(9338), "dolorum" },
                    { 318, 45, 136, 192197, new DateTime(2021, 1, 19, 1, 9, 48, 874, DateTimeKind.Local).AddTicks(6898), "Accusantium cum nisi laudantium." },
                    { 205, 45, 83, 423117, new DateTime(2021, 3, 16, 1, 29, 59, 172, DateTimeKind.Local).AddTicks(4042), "Error voluptas nisi accusantium." },
                    { 99, 80, 93, 829468, new DateTime(2021, 2, 1, 22, 12, 12, 572, DateTimeKind.Local).AddTicks(8805), "excepturi" },
                    { 119, 80, 100, 616951, new DateTime(2021, 4, 3, 1, 52, 18, 64, DateTimeKind.Local).AddTicks(753), "Distinctio fuga et.\nVoluptas esse et dicta perferendis." },
                    { 120, 80, 118, 925454, new DateTime(2021, 3, 11, 7, 36, 58, 0, DateTimeKind.Local).AddTicks(8808), "Voluptatibus distinctio consectetur tempore doloribus vel.\nEa accusamus dolorem animi ut nobis accusamus voluptas.\nAccusantium impedit accusamus dolor.\nDolore est rerum qui perspiciatis ullam eveniet velit qui necessitatibus.\nRepellendus sint dolores tempora iusto dignissimos aut nulla ut impedit.\nAnimi vel nobis ea ratione deserunt." },
                    { 128, 80, 142, 776149, new DateTime(2021, 4, 22, 18, 25, 30, 236, DateTimeKind.Local).AddTicks(1677), "Atque tempore est eos perspiciatis et vel. Voluptas voluptatem similique iusto et. Nulla dolore eveniet animi ea delectus voluptas et occaecati voluptatibus. Inventore voluptatem neque quisquam aperiam aliquam et beatae quidem. Et labore quis ex in maiores adipisci harum." },
                    { 255, 80, 106, 673910, new DateTime(2021, 7, 9, 22, 15, 41, 931, DateTimeKind.Local).AddTicks(5196), "Perspiciatis et molestiae quisquam eveniet aut." },
                    { 267, 80, 146, 372742, new DateTime(2021, 8, 3, 8, 43, 11, 206, DateTimeKind.Local).AddTicks(8044), "Voluptatem ullam enim eaque quis impedit aliquid autem et. Labore aut ipsum eaque porro amet soluta voluptatem. Fugiat reiciendis aliquid cupiditate dolore quae voluptates. Rerum nesciunt dignissimos soluta dignissimos qui natus laborum vero." },
                    { 306, 80, 35, 811923, new DateTime(2021, 6, 9, 14, 9, 8, 408, DateTimeKind.Local).AddTicks(8935), "molestiae" },
                    { 313, 80, 53, 830445, new DateTime(2020, 9, 11, 19, 38, 23, 957, DateTimeKind.Local).AddTicks(2148), "Dolores atque provident esse ut illo. Commodi laboriosam iusto consectetur molestiae sed velit officiis. Tempora nemo quia quis nulla porro aut id quia. Inventore omnis quia est quam et odio excepturi repellendus doloribus. Id nisi occaecati nihil voluptatem vel." },
                    { 410, 80, 42, 260694, new DateTime(2020, 9, 9, 21, 9, 19, 481, DateTimeKind.Local).AddTicks(5424), "saepe" },
                    { 416, 80, 52, 793864, new DateTime(2021, 4, 6, 0, 19, 42, 885, DateTimeKind.Local).AddTicks(1300), "officiis" },
                    { 446, 80, 144, 604761, new DateTime(2021, 8, 3, 9, 49, 11, 251, DateTimeKind.Local).AddTicks(3983), "Asperiores excepturi asperiores totam. Ut aspernatur hic. Aliquam vero asperiores laboriosam deleniti vero ipsum dolorem tempore qui. Quam voluptate sit iusto qui ducimus." },
                    { 491, 80, 114, 213045, new DateTime(2021, 3, 14, 0, 36, 15, 662, DateTimeKind.Local).AddTicks(9268), "Nulla eum qui praesentium sed laudantium occaecati voluptatum maxime.\nPlaceat est dolorum.\nDolorum quos qui voluptas et praesentium non fugit et quaerat.\nSunt assumenda ullam suscipit ab ad." },
                    { 553, 80, 21, 174938, new DateTime(2021, 8, 2, 8, 32, 0, 380, DateTimeKind.Local).AddTicks(2856), "magnam" },
                    { 520, 66, 137, 61132, new DateTime(2020, 10, 7, 20, 40, 7, 441, DateTimeKind.Local).AddTicks(2069), "Sunt corrupti excepturi vero rem laborum. Soluta cumque sit deleniti quia mollitia. Iure hic dolor magnam sed numquam." },
                    { 560, 66, 74, 602528, new DateTime(2021, 5, 19, 20, 32, 50, 686, DateTimeKind.Local).AddTicks(5942), "Et laborum exercitationem nesciunt et voluptatem sunt. Sit consequatur excepturi sed. Eaque quae consequatur eos. Molestias est corporis eveniet. Quia aliquam voluptas nisi delectus." },
                    { 250, 45, 131, 828885, new DateTime(2021, 1, 17, 1, 23, 10, 865, DateTimeKind.Local).AddTicks(7204), "Quam dolores modi nobis eum quae." },
                    { 535, 60, 83, 268673, new DateTime(2020, 11, 11, 16, 28, 13, 374, DateTimeKind.Local).AddTicks(4242), "Molestiae quo et id.\nTenetur non exercitationem aperiam possimus est ut voluptatem veniam.\nVoluptas porro molestiae sed non ullam quidem.\nLibero qui neque repudiandae distinctio fugiat earum iusto quisquam.\nConsectetur voluptatem sed voluptate eum." },
                    { 483, 53, 59, 499447, new DateTime(2021, 4, 26, 21, 8, 51, 278, DateTimeKind.Local).AddTicks(6337), "Quia alias error qui doloribus. Tempora accusantium optio aspernatur omnis dolorem pariatur sequi earum quo. Placeat aut et. Sit dolorum eum vitae ad." },
                    { 488, 58, 62, 874867, new DateTime(2021, 3, 26, 5, 15, 10, 530, DateTimeKind.Local).AddTicks(6618), "Occaecati voluptatem nobis aut aliquid exercitationem quos nemo voluptas. Ab molestiae nesciunt quia vel consequatur ut doloremque omnis. Autem corrupti natus vel et voluptate beatae quia rerum modi. Quia nisi occaecati quia." },
                    { 81, 31, 30, 372672, new DateTime(2020, 11, 15, 13, 35, 49, 352, DateTimeKind.Local).AddTicks(5854), "Repudiandae ut et qui autem.\nEius accusamus hic ex aliquid aut dolores.\nQui harum sapiente sapiente voluptatem.\nNatus quibusdam ut molestias.\nMaxime optio culpa corporis et sed deleniti nihil molestiae." },
                    { 111, 31, 62, 628478, new DateTime(2020, 11, 25, 5, 49, 50, 807, DateTimeKind.Local).AddTicks(1559), "Corporis debitis iure ut fugiat ab ab ea doloremque. Dolor recusandae in vero. Mollitia quisquam nemo maxime dolore dolor soluta sunt." },
                    { 219, 31, 10, 623481, new DateTime(2020, 11, 4, 0, 22, 51, 727, DateTimeKind.Local).AddTicks(1788), "Ex quia est quae ad.\nQui molestias facilis tenetur suscipit eum totam ut.\nNon reprehenderit dignissimos animi quia consequuntur sequi a.\nHarum quia deserunt." },
                    { 282, 31, 146, 685264, new DateTime(2021, 4, 24, 7, 16, 26, 794, DateTimeKind.Local).AddTicks(2405), "Inventore dolores vel aliquam et sint.\nVoluptates architecto pariatur iure dolores.\nQuidem ipsum placeat eum repudiandae consequuntur possimus.\nSoluta praesentium non.\nQui inventore eveniet voluptatibus magni incidunt tempore commodi libero.\nQuibusdam mollitia voluptatem sit velit nobis quaerat nostrum quia." },
                    { 293, 31, 7, 927377, new DateTime(2020, 8, 22, 7, 23, 24, 204, DateTimeKind.Local).AddTicks(6324), "Repellendus nisi mollitia aut molestiae dolor tempora quis mollitia cum.\nVel officiis porro consequatur.\nOmnis architecto assumenda labore." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 335, 31, 61, 195830, new DateTime(2021, 2, 17, 20, 15, 42, 953, DateTimeKind.Local).AddTicks(8425), "reprehenderit" },
                    { 341, 31, 90, 669950, new DateTime(2020, 11, 6, 21, 57, 20, 787, DateTimeKind.Local).AddTicks(1217), "Omnis qui ipsum voluptates porro vitae mollitia et dicta. Pariatur odio ipsum aut eaque. Quo est omnis quidem pariatur consequatur ut inventore ipsam." },
                    { 367, 31, 77, 88850, new DateTime(2021, 6, 15, 3, 11, 22, 86, DateTimeKind.Local).AddTicks(937), "Quidem impedit atque.\nConsequatur unde impedit accusamus nam esse voluptas reprehenderit distinctio.\nEt perspiciatis sunt delectus." },
                    { 369, 31, 45, 941995, new DateTime(2020, 11, 2, 10, 25, 26, 985, DateTimeKind.Local).AddTicks(6974), "Consequatur asperiores possimus libero in optio voluptatem ex expedita tempore." },
                    { 463, 31, 67, 234890, new DateTime(2021, 6, 30, 22, 20, 24, 896, DateTimeKind.Local).AddTicks(3541), "Praesentium dolorum unde doloribus delectus ad corporis blanditiis inventore odio. Voluptatem voluptatum quia doloremque dolor iusto. Eos beatae earum quam architecto ea occaecati. Explicabo quos quis aut." },
                    { 494, 31, 149, 672024, new DateTime(2021, 3, 30, 16, 5, 2, 153, DateTimeKind.Local).AddTicks(618), "Aliquid cum quo dignissimos. Beatae accusantium facilis. Explicabo sed in in sunt." },
                    { 546, 31, 36, 360687, new DateTime(2021, 1, 26, 17, 5, 18, 431, DateTimeKind.Local).AddTicks(8471), "Sed earum cum nobis deserunt ea quaerat.\nSunt sapiente optio." },
                    { 565, 31, 88, 192961, new DateTime(2020, 11, 28, 6, 52, 36, 407, DateTimeKind.Local).AddTicks(6049), "Dolore dolores eaque sint et sint omnis sit et aut. Maxime recusandae eligendi et. Repellat sequi ea non. Blanditiis quo sapiente iste maxime sunt molestiae." },
                    { 582, 31, 135, 668018, new DateTime(2021, 8, 2, 7, 55, 37, 940, DateTimeKind.Local).AddTicks(8000), "Facere repudiandae perspiciatis maxime autem. Perferendis esse natus officia possimus eum nostrum. Quo aut dicta occaecati architecto numquam quo in. Rerum aperiam deleniti provident autem saepe." },
                    { 600, 31, 140, 943387, new DateTime(2020, 12, 4, 8, 9, 39, 671, DateTimeKind.Local).AddTicks(7708), "Velit expedita odit corrupti fugit et." },
                    { 32, 31, 4, 702094, new DateTime(2021, 5, 10, 7, 39, 35, 284, DateTimeKind.Local).AddTicks(2833), "Velit quia sunt error nihil nesciunt distinctio ipsum illo quis.\nSunt est quas modi porro et corrupti hic.\nRerum libero deserunt velit exercitationem dolores commodi.\nLabore autem fuga culpa labore ex eveniet nihil.\nDolorem omnis sint aut quia.\nOdit sit fugit et nihil et aspernatur similique." },
                    { 538, 53, 7, 973412, new DateTime(2020, 9, 3, 20, 44, 46, 569, DateTimeKind.Local).AddTicks(9433), "Commodi ab tempora vero sunt dolor. Iste dolorem impedit rerum. Maxime aut optio. Inventore sunt et similique et numquam quis aperiam numquam id. Voluptatem cupiditate officiis assumenda quae nisi." },
                    { 29, 31, 35, 865233, new DateTime(2021, 7, 22, 14, 0, 0, 437, DateTimeKind.Local).AddTicks(9966), "Quasi consectetur et sint sunt molestiae." },
                    { 578, 16, 136, 592514, new DateTime(2021, 6, 22, 8, 52, 56, 271, DateTimeKind.Local).AddTicks(7735), "fugit" },
                    { 135, 15, 120, 89747, new DateTime(2020, 8, 27, 7, 58, 17, 628, DateTimeKind.Local).AddTicks(7300), "est" },
                    { 222, 15, 80, 422993, new DateTime(2020, 9, 13, 2, 53, 35, 744, DateTimeKind.Local).AddTicks(3139), "Sed consequatur fuga velit. Ipsa fuga rerum. Saepe odit aspernatur esse libero. Minima inventore deserunt asperiores voluptatem minus numquam." },
                    { 330, 15, 1, 444565, new DateTime(2020, 8, 20, 18, 7, 3, 928, DateTimeKind.Local).AddTicks(3047), "Dolorem tenetur soluta magnam earum nam. Cupiditate delectus quas dolorem perspiciatis deserunt quis cupiditate consequuntur harum. Et velit voluptas doloremque blanditiis id." },
                    { 366, 15, 31, 840433, new DateTime(2020, 8, 17, 8, 26, 54, 300, DateTimeKind.Local).AddTicks(7946), "Voluptas saepe sint voluptatem omnis neque voluptatibus corrupti molestias ut.\nMollitia nemo nemo qui nulla qui autem autem itaque sit.\nVelit sequi qui consequatur.\nAut qui explicabo itaque culpa recusandae.\nEligendi at possimus.\nNumquam quis similique vel est voluptatibus veritatis iusto magni." },
                    { 399, 15, 113, 125386, new DateTime(2021, 2, 17, 16, 13, 36, 944, DateTimeKind.Local).AddTicks(2474), "sit" },
                    { 541, 15, 99, 909043, new DateTime(2021, 4, 30, 4, 26, 54, 889, DateTimeKind.Local).AddTicks(942), "Rerum at doloribus ullam laudantium sit voluptatum nisi soluta." },
                    { 346, 58, 139, 744699, new DateTime(2020, 11, 3, 16, 26, 58, 76, DateTimeKind.Local).AddTicks(1911), "Labore omnis illum vitae dolore." },
                    { 16, 16, 27, 447476, new DateTime(2021, 8, 11, 18, 32, 5, 125, DateTimeKind.Local).AddTicks(5289), "reiciendis" },
                    { 24, 16, 52, 320642, new DateTime(2020, 8, 27, 21, 43, 47, 72, DateTimeKind.Local).AddTicks(2867), "Libero placeat id ea omnis qui." },
                    { 46, 16, 105, 145033, new DateTime(2021, 7, 30, 16, 38, 17, 43, DateTimeKind.Local).AddTicks(1664), "Soluta nihil voluptatem laboriosam cumque commodi quia." },
                    { 75, 16, 150, 151092, new DateTime(2021, 3, 28, 22, 17, 41, 426, DateTimeKind.Local).AddTicks(5233), "Optio explicabo dolores dolores similique." },
                    { 171, 16, 25, 689632, new DateTime(2020, 9, 22, 16, 55, 59, 392, DateTimeKind.Local).AddTicks(252), "Eaque laudantium accusamus iusto aut accusamus ut sit sint ipsam.\nUnde velit qui repellendus quis nobis deleniti voluptatem.\nCorporis ut inventore velit dolorem molestias velit.\nQui alias hic voluptatum." },
                    { 200, 16, 118, 902599, new DateTime(2020, 12, 7, 15, 2, 20, 223, DateTimeKind.Local).AddTicks(3297), "optio" },
                    { 474, 16, 91, 499046, new DateTime(2021, 5, 12, 4, 31, 0, 656, DateTimeKind.Local).AddTicks(28), "ea" },
                    { 479, 16, 3, 170416, new DateTime(2020, 12, 6, 21, 2, 36, 905, DateTimeKind.Local).AddTicks(4741), "Deserunt accusantium quo ut." },
                    { 204, 58, 53, 331623, new DateTime(2020, 11, 23, 21, 10, 57, 514, DateTimeKind.Local).AddTicks(1391), "Autem ut autem.\nQuia quod repellendus ut ducimus velit sunt.\nDistinctio ex repellat aut rerum impedit corporis fugiat." },
                    { 300, 57, 32, 689985, new DateTime(2021, 2, 3, 17, 54, 54, 291, DateTimeKind.Local).AddTicks(9740), "Pariatur aut explicabo occaecati voluptatem corrupti aut beatae vero aperiam.\nOdio accusantium laboriosam architecto tempora libero.\nFacilis incidunt illum animi voluptatem reprehenderit omnis.\nFacere tempora aperiam repudiandae ad facilis distinctio." },
                    { 254, 57, 28, 837719, new DateTime(2021, 1, 25, 12, 31, 15, 127, DateTimeKind.Local).AddTicks(1281), "Et enim voluptatem labore maxime non quaerat voluptate aut autem. Pariatur earum temporibus. Doloremque animi tenetur voluptas velit dolorem. Optio odio eius maxime." },
                    { 443, 57, 112, 292555, new DateTime(2021, 5, 12, 0, 14, 58, 607, DateTimeKind.Local).AddTicks(4103), "labore" },
                    { 485, 54, 128, 145625, new DateTime(2021, 5, 20, 12, 17, 22, 857, DateTimeKind.Local).AddTicks(8825), "Corrupti inventore harum quibusdam nihil porro.\nCorrupti corrupti eum et culpa voluptatem cumque neque aut numquam.\nQui iusto rerum asperiores necessitatibus.\nIncidunt accusantium et." },
                    { 80, 63, 130, 926080, new DateTime(2020, 11, 8, 6, 27, 56, 883, DateTimeKind.Local).AddTicks(6219), "Eum eos nihil voluptas laboriosam incidunt omnis. Fugit dolor nihil et est voluptatibus voluptatem ea nesciunt modi. Et quia voluptatem ex cum et." },
                    { 122, 63, 88, 541580, new DateTime(2021, 3, 29, 8, 29, 43, 385, DateTimeKind.Local).AddTicks(6213), "Possimus hic veniam ad id sit dolorem." },
                    { 273, 63, 18, 384433, new DateTime(2021, 3, 13, 16, 13, 5, 630, DateTimeKind.Local).AddTicks(4707), "Autem omnis labore est.\nMaxime aut aut qui vitae.\nSimilique et dolor nobis." },
                    { 360, 63, 117, 227975, new DateTime(2021, 6, 20, 22, 29, 40, 980, DateTimeKind.Local).AddTicks(7987), "nihil" },
                    { 441, 63, 84, 363759, new DateTime(2021, 2, 18, 10, 17, 42, 999, DateTimeKind.Local).AddTicks(1039), "Quasi illum maxime aliquid natus odio corporis sit." },
                    { 448, 63, 146, 447218, new DateTime(2020, 12, 5, 11, 51, 31, 577, DateTimeKind.Local).AddTicks(656), "A in laudantium totam explicabo autem ullam doloribus.\nDolores ut qui est officia dolor iste sit rerum et.\nRepellat reiciendis saepe quod optio asperiores.\nCorrupti rem vel porro et illo." },
                    { 465, 63, 27, 468823, new DateTime(2021, 6, 20, 22, 22, 59, 213, DateTimeKind.Local).AddTicks(3838), "unde" },
                    { 481, 63, 46, 811042, new DateTime(2021, 7, 19, 7, 41, 10, 516, DateTimeKind.Local).AddTicks(3317), "Dolores sit et sed temporibus nostrum molestiae earum itaque odio.\nDolores vero beatae tempore molestias magni architecto." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 504, 63, 141, 159101, new DateTime(2021, 6, 22, 3, 52, 6, 145, DateTimeKind.Local).AddTicks(4170), "Voluptatum recusandae officia." },
                    { 95, 72, 91, 388454, new DateTime(2020, 10, 2, 2, 45, 59, 825, DateTimeKind.Local).AddTicks(3434), "deleniti" },
                    { 263, 72, 124, 784723, new DateTime(2021, 6, 13, 1, 26, 6, 916, DateTimeKind.Local).AddTicks(945), "et" },
                    { 317, 72, 42, 262883, new DateTime(2020, 9, 11, 20, 36, 49, 627, DateTimeKind.Local).AddTicks(830), "Voluptas dignissimos pariatur sapiente consequuntur iusto et enim rem expedita." },
                    { 383, 72, 48, 328330, new DateTime(2021, 3, 19, 1, 53, 17, 703, DateTimeKind.Local).AddTicks(1420), "Eligendi aliquam hic. Voluptatem voluptatibus cum aut ducimus odio quas ratione officia. Assumenda unde dolor quia debitis at rem. Eius neque dolorem asperiores. Et deleniti quo corrupti sequi assumenda vitae minus. Quos saepe quos minus." },
                    { 420, 72, 19, 21173, new DateTime(2020, 11, 13, 19, 48, 4, 740, DateTimeKind.Local).AddTicks(1082), "Dolor voluptatem et in dolores. Fugiat dolorem consequatur soluta sint earum. Itaque perferendis magnam et incidunt qui et et." },
                    { 462, 51, 44, 225497, new DateTime(2021, 4, 8, 6, 56, 4, 784, DateTimeKind.Local).AddTicks(3626), "Ipsa eveniet consectetur tempore asperiores et culpa.\nHarum nisi voluptas neque animi.\nVoluptatibus ea voluptas.\nIn velit eos dolor quam sit facilis.\nCorrupti ut atque iste.\nUt dicta adipisci occaecati voluptas nemo." },
                    { 468, 72, 31, 440001, new DateTime(2021, 8, 1, 1, 13, 38, 270, DateTimeKind.Local).AddTicks(8606), "aliquam" },
                    { 412, 51, 149, 884900, new DateTime(2021, 6, 5, 8, 52, 52, 528, DateTimeKind.Local).AddTicks(1883), "Dignissimos laborum dicta est explicabo consequatur et." },
                    { 145, 51, 128, 583923, new DateTime(2021, 5, 11, 1, 57, 16, 998, DateTimeKind.Local).AddTicks(3261), "magnam" },
                    { 199, 17, 66, 383338, new DateTime(2021, 5, 10, 1, 59, 39, 398, DateTimeKind.Local).AddTicks(4381), "Provident ipsa at ipsam." },
                    { 289, 17, 48, 429563, new DateTime(2020, 8, 16, 17, 57, 2, 343, DateTimeKind.Local).AddTicks(2240), "Quasi non maiores accusantium rerum. Aliquid facere ad itaque. Repellendus id quas doloremque amet dolores. Eos aut molestiae est laboriosam consequuntur modi possimus qui. Aut qui inventore doloribus." },
                    { 414, 17, 114, 251429, new DateTime(2021, 8, 7, 17, 30, 59, 801, DateTimeKind.Local).AddTicks(1275), "alias" },
                    { 436, 17, 40, 842831, new DateTime(2021, 2, 9, 16, 8, 23, 296, DateTimeKind.Local).AddTicks(6092), "Est ut deserunt numquam." },
                    { 517, 17, 99, 29432, new DateTime(2020, 11, 22, 18, 8, 48, 4, DateTimeKind.Local).AddTicks(2586), "Sed libero non unde similique nostrum. Suscipit qui quam beatae quisquam dolores dignissimos temporibus nam. Nemo amet perferendis dolor quo. Sint quas optio unde ad ut. Dignissimos dolores iusto id vel accusantium beatae deleniti corporis." },
                    { 523, 17, 75, 13506, new DateTime(2020, 10, 9, 17, 17, 19, 376, DateTimeKind.Local).AddTicks(7450), "Nihil animi eveniet ducimus amet at dolores. Repellat rerum ut sit inventore id impedit facere non. Provident itaque reprehenderit est. Sint hic quis id omnis sed dolore accusamus mollitia. Ut hic rerum non ad fugiat eum esse." },
                    { 536, 17, 82, 377499, new DateTime(2021, 4, 22, 5, 36, 16, 141, DateTimeKind.Local).AddTicks(4492), "Est dolor fugiat et aut odit." },
                    { 47, 39, 107, 344130, new DateTime(2020, 10, 4, 23, 50, 51, 383, DateTimeKind.Local).AddTicks(3554), "Aut rerum voluptatem cum est illum quos ullam sapiente. Est in vel magni vero ea aliquid commodi accusantium aut. Perspiciatis molestiae aut eveniet eos autem. Exercitationem nulla rerum quo tempore dolores id nisi explicabo. Fugiat dolorum quia vel laudantium ut eligendi ullam maiores quae. Quod fugiat laboriosam voluptas." },
                    { 285, 39, 96, 638427, new DateTime(2021, 1, 24, 8, 43, 50, 763, DateTimeKind.Local).AddTicks(6458), "Exercitationem voluptas et rerum doloribus facilis maiores eveniet inventore dolore.\nEst assumenda reprehenderit vitae." },
                    { 336, 39, 122, 939421, new DateTime(2021, 3, 2, 15, 4, 14, 13, DateTimeKind.Local).AddTicks(5273), "autem" },
                    { 376, 39, 46, 191297, new DateTime(2020, 12, 29, 16, 49, 50, 808, DateTimeKind.Local).AddTicks(4839), "Voluptatem sequi non dolores id porro at eligendi nam. Maiores aspernatur sed modi ut. Ullam consequatur et animi ex sit quos voluptatem repudiandae dicta. Fugiat id animi. Qui optio dolorem nobis. Et blanditiis voluptatem voluptatem in provident." },
                    { 423, 39, 71, 523779, new DateTime(2020, 10, 28, 15, 36, 58, 368, DateTimeKind.Local).AddTicks(6943), "quod" },
                    { 518, 39, 67, 700847, new DateTime(2021, 1, 31, 15, 38, 51, 359, DateTimeKind.Local).AddTicks(2718), "Velit alias minima. Error doloribus id id enim. Consectetur optio ipsa accusamus quod. Et delectus aut earum veniam qui harum. Qui accusamus consequatur laudantium voluptatibus maiores ipsum iste non. Et unde asperiores et nostrum blanditiis." },
                    { 554, 39, 45, 932773, new DateTime(2020, 11, 15, 16, 12, 16, 121, DateTimeKind.Local).AddTicks(4911), "Sunt nisi eum commodi natus quae debitis laborum consequuntur." },
                    { 19, 51, 89, 465486, new DateTime(2020, 8, 27, 1, 4, 0, 945, DateTimeKind.Local).AddTicks(5441), "et" },
                    { 326, 51, 92, 933278, new DateTime(2021, 3, 9, 3, 48, 57, 90, DateTimeKind.Local).AddTicks(6769), "Quia sunt tempore eaque minima quibusdam qui.\nCulpa et animi doloribus voluptatem aut in non mollitia.\nMollitia velit voluptatibus nisi nobis.\nExcepturi est nam nisi laudantium aperiam libero sit." },
                    { 108, 17, 1, 831832, new DateTime(2020, 11, 3, 2, 56, 4, 559, DateTimeKind.Local).AddTicks(335), "Sit et officiis qui enim iusto est voluptas modi.\nLaboriosam et dolorem reprehenderit minus et.\nLaboriosam non eligendi est corporis.\nNam impedit rem." },
                    { 525, 72, 116, 501701, new DateTime(2020, 10, 10, 8, 28, 34, 391, DateTimeKind.Local).AddTicks(4625), "Quaerat dolor iste aspernatur." },
                    { 370, 54, 18, 133670, new DateTime(2021, 3, 3, 22, 30, 10, 23, DateTimeKind.Local).AddTicks(3788), "labore" },
                    { 259, 56, 118, 285728, new DateTime(2021, 1, 17, 12, 32, 56, 538, DateTimeKind.Local).AddTicks(4747), "voluptates" },
                    { 262, 56, 39, 383719, new DateTime(2021, 5, 21, 0, 9, 14, 612, DateTimeKind.Local).AddTicks(346), "Assumenda sapiente sint voluptatum sed quam delectus temporibus.\nOfficia vitae voluptatem fugiat ullam non tenetur qui iste.\nSed omnis soluta nulla labore.\nQuos quia quidem.\nVel voluptates voluptatum recusandae consectetur.\nRerum est consequatur magni quis." },
                    { 299, 56, 57, 197073, new DateTime(2021, 3, 17, 21, 13, 54, 708, DateTimeKind.Local).AddTicks(120), "Quam ut expedita nemo.\nProvident quo et quae perspiciatis.\nExplicabo animi dolores facilis." },
                    { 417, 56, 94, 71196, new DateTime(2021, 2, 12, 10, 36, 44, 31, DateTimeKind.Local).AddTicks(2195), "Vel tempora expedita. Aliquam nemo aspernatur praesentium non autem iste sunt quae. Sapiente nemo commodi facilis quisquam sapiente est sint dolorem laudantium." },
                    { 431, 56, 83, 388893, new DateTime(2020, 10, 5, 17, 11, 33, 164, DateTimeKind.Local).AddTicks(3098), "Ea id voluptate aut doloremque." },
                    { 528, 56, 104, 149567, new DateTime(2021, 7, 13, 22, 23, 23, 337, DateTimeKind.Local).AddTicks(2303), "Et et vel assumenda sed cum rem suscipit.\nQuae nihil et.\nEos odit sed vel est ut.\nVoluptatem reprehenderit et quia nulla quisquam maiores atque.\nEst neque provident nisi et facere deleniti.\nMinus et explicabo nobis pariatur harum." },
                    { 574, 56, 1, 867975, new DateTime(2021, 3, 8, 19, 23, 8, 879, DateTimeKind.Local).AddTicks(4540), "Ratione officiis qui adipisci aspernatur aut ipsa quis voluptatem. Quae voluptatem est. Accusamus ut voluptatum illo." },
                    { 364, 54, 22, 519529, new DateTime(2021, 6, 21, 23, 27, 41, 937, DateTimeKind.Local).AddTicks(9510), "Repellat voluptates voluptas voluptas sed.\nRatione voluptatum qui voluptas." },
                    { 148, 60, 40, 508762, new DateTime(2021, 2, 22, 2, 9, 55, 22, DateTimeKind.Local).AddTicks(4821), "Quo nobis ut tempore. Impedit deleniti et quia. Sit impedit corporis ipsum qui totam voluptatibus maxime." },
                    { 228, 60, 14, 348702, new DateTime(2020, 10, 29, 8, 2, 24, 681, DateTimeKind.Local).AddTicks(4946), "Alias est illo adipisci maiores quos voluptate." },
                    { 315, 60, 93, 315824, new DateTime(2021, 7, 18, 12, 39, 43, 888, DateTimeKind.Local).AddTicks(3246), "Est dignissimos sunt cupiditate non voluptates dicta. Molestias voluptatum maxime ullam est sequi laborum et consequatur voluptatem. Debitis sit necessitatibus dolores dolorum et laborum est tempora dolorum." },
                    { 344, 60, 73, 333275, new DateTime(2020, 11, 29, 18, 28, 15, 423, DateTimeKind.Local).AddTicks(4700), "aliquam" },
                    { 444, 60, 55, 742306, new DateTime(2020, 10, 3, 6, 55, 12, 861, DateTimeKind.Local).AddTicks(4884), "Error eos et libero molestiae voluptas sunt eum ut quod." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 473, 60, 78, 563059, new DateTime(2020, 11, 8, 17, 8, 54, 498, DateTimeKind.Local).AddTicks(6840), "dolor" },
                    { 478, 60, 9, 434511, new DateTime(2021, 3, 21, 1, 53, 30, 544, DateTimeKind.Local).AddTicks(3373), "Rem repellat autem numquam necessitatibus aut voluptas. Nihil atque accusamus eos delectus repellendus eveniet accusamus. Error et omnis non. Quibusdam qui at nostrum libero. Cupiditate est maiores. Quasi pariatur asperiores id earum modi et amet ut." },
                    { 155, 56, 14, 924018, new DateTime(2020, 9, 8, 17, 45, 29, 478, DateTimeKind.Local).AddTicks(1514), "consequatur" },
                    { 576, 72, 15, 768166, new DateTime(2020, 10, 4, 14, 24, 12, 407, DateTimeKind.Local).AddTicks(8516), "rerum" },
                    { 130, 56, 52, 766270, new DateTime(2020, 12, 21, 15, 38, 5, 82, DateTimeKind.Local).AddTicks(6422), "Voluptatem quod illo atque possimus eius provident nostrum.\nDolores ex eos.\nAnimi consequatur cupiditate et.\nVoluptatibus similique dolorem numquam quia nulla fugit tenetur qui rerum.\nAssumenda eos ex aut voluptatem.\nEt voluptatem accusamus." },
                    { 418, 30, 44, 195159, new DateTime(2021, 5, 18, 2, 27, 48, 89, DateTimeKind.Local).AddTicks(5833), "Non autem fugiat expedita et tempora est voluptas quis odio.\nQui dolorem quia numquam eos eveniet reprehenderit corrupti.\nNihil labore sed rem laudantium in adipisci.\nSit quidem totam dolor voluptatem.\nDoloremque adipisci numquam voluptatem eveniet beatae possimus debitis et.\nA occaecati distinctio aliquam minima recusandae est." },
                    { 18, 21, 104, 745388, new DateTime(2020, 12, 10, 22, 51, 45, 632, DateTimeKind.Local).AddTicks(2285), "Animi tempore et maiores nihil aliquid dolor maiores. Quidem a ut quos et et ex. Ut modi minus illo quidem quia quaerat. Vero quos cupiditate velit illo accusamus. Totam aspernatur quas nemo dolores praesentium omnis. Magnam quas quod ab veritatis nemo voluptatem consectetur eveniet." },
                    { 64, 21, 92, 543161, new DateTime(2021, 8, 4, 12, 56, 11, 506, DateTimeKind.Local).AddTicks(9122), "Ut suscipit qui explicabo veniam consequuntur a eos." },
                    { 65, 21, 5, 143158, new DateTime(2020, 8, 19, 21, 48, 53, 811, DateTimeKind.Local).AddTicks(3581), "Ut iste quo corporis saepe aliquid distinctio tenetur totam.\nNobis dolorum ratione sunt ut pariatur illum quis.\nMolestiae sunt distinctio commodi eligendi." },
                    { 286, 21, 78, 637430, new DateTime(2021, 3, 7, 13, 45, 32, 399, DateTimeKind.Local).AddTicks(1770), "Voluptas mollitia est neque quibusdam laudantium ipsa." },
                    { 296, 21, 57, 886262, new DateTime(2021, 6, 30, 21, 30, 56, 829, DateTimeKind.Local).AddTicks(9524), "sed" },
                    { 325, 21, 34, 646117, new DateTime(2021, 7, 28, 20, 21, 45, 860, DateTimeKind.Local).AddTicks(2280), "Quibusdam a temporibus ut eos facilis et adipisci." },
                    { 386, 21, 91, 270711, new DateTime(2020, 12, 14, 16, 17, 26, 11, DateTimeKind.Local).AddTicks(9778), "repellendus" },
                    { 391, 21, 135, 368171, new DateTime(2021, 2, 20, 0, 19, 11, 617, DateTimeKind.Local).AddTicks(9814), "Nihil sed ut rerum molestiae." },
                    { 533, 21, 127, 223510, new DateTime(2021, 1, 1, 14, 2, 45, 583, DateTimeKind.Local).AddTicks(7762), "Numquam veniam et minus cumque officiis.\nIllo impedit repellat repellat.\nModi earum facilis totam omnis eum nihil eaque omnis blanditiis.\nItaque sit quae ut.\nAspernatur dolor nihil delectus et.\nIpsa voluptas amet magnam veritatis maiores." },
                    { 572, 21, 77, 524388, new DateTime(2021, 1, 18, 17, 57, 49, 717, DateTimeKind.Local).AddTicks(3949), "Porro est animi molestias dolor." },
                    { 52, 30, 102, 662171, new DateTime(2020, 11, 9, 21, 18, 26, 310, DateTimeKind.Local).AddTicks(2773), "Est libero quis dolores repellendus quo minima occaecati. Exercitationem sint et perspiciatis. Sequi eum corporis nesciunt quia ut id reprehenderit hic. Harum veniam quasi sequi rem nesciunt magnam et deleniti." },
                    { 176, 30, 25, 563088, new DateTime(2020, 8, 16, 1, 25, 3, 888, DateTimeKind.Local).AddTicks(5667), "Unde laborum quia architecto minima tenetur voluptatem mollitia sunt. Ducimus est voluptates quia inventore eligendi nemo est officia dignissimos. Delectus sunt nobis culpa non quam. Enim soluta illum asperiores. Voluptatem dignissimos debitis quas." },
                    { 218, 30, 75, 403673, new DateTime(2020, 10, 14, 12, 22, 46, 414, DateTimeKind.Local).AddTicks(7081), "porro" },
                    { 305, 30, 139, 765282, new DateTime(2021, 2, 6, 14, 22, 22, 879, DateTimeKind.Local).AddTicks(1712), "Iure et quia consequatur." },
                    { 368, 30, 140, 335920, new DateTime(2020, 9, 22, 4, 10, 48, 430, DateTimeKind.Local).AddTicks(7534), "Sunt nihil officiis totam enim et." },
                    { 591, 30, 39, 147103, new DateTime(2021, 1, 28, 6, 7, 0, 262, DateTimeKind.Local).AddTicks(896), "Provident veritatis amet non distinctio non aut hic autem." },
                    { 106, 17, 30, 989933, new DateTime(2021, 5, 1, 18, 24, 5, 935, DateTimeKind.Local).AddTicks(24), "aperiam" },
                    { 9, 17, 40, 465455, new DateTime(2021, 3, 15, 6, 43, 33, 764, DateTimeKind.Local).AddTicks(1116), "Accusamus voluptas consectetur nobis non esse." },
                    { 594, 9, 74, 358040, new DateTime(2021, 4, 26, 2, 45, 5, 940, DateTimeKind.Local).AddTicks(2103), "Deserunt numquam nulla necessitatibus velit odit.\nAutem rerum praesentium doloremque eligendi.\nVoluptas repellendus deserunt magnam excepturi consequuntur dolores fugit.\nQuo vel architecto expedita eaque consectetur consequuntur.\nUt quo reprehenderit reiciendis suscipit quibusdam ratione ipsam voluptate commodi.\nEligendi perspiciatis nostrum." },
                    { 61, 22, 73, 442765, new DateTime(2021, 4, 2, 0, 29, 31, 209, DateTimeKind.Local).AddTicks(2203), "Quis aut iste magni voluptatum et qui eveniet numquam odit.\nDelectus autem voluptas expedita non voluptates suscipit qui.\nNostrum sit molestiae tempora.\nQuod saepe qui atque eius consequatur.\nQui facere maiores voluptas a placeat quos soluta quae earum." },
                    { 101, 22, 38, 650153, new DateTime(2021, 6, 28, 0, 4, 4, 163, DateTimeKind.Local).AddTicks(2866), "Perferendis voluptatem et et dolor ullam consequatur id temporibus assumenda.\nDoloribus asperiores quaerat sunt quae ut qui dolorem commodi.\nDucimus qui aliquid in est sapiente aspernatur qui neque delectus." },
                    { 191, 22, 30, 676657, new DateTime(2020, 10, 29, 14, 56, 27, 499, DateTimeKind.Local).AddTicks(133), "Molestiae sit quia ut corporis ratione voluptas.\nAut at fugiat voluptatem natus.\nFacere enim harum sed odio in rerum sint ut et.\nId fugiat laboriosam quaerat sint hic qui.\nSunt rerum optio est veniam qui odit quis expedita.\nVel et nihil enim exercitationem omnis." },
                    { 314, 22, 26, 391978, new DateTime(2021, 2, 9, 9, 44, 53, 146, DateTimeKind.Local).AddTicks(6821), "Odit doloremque laborum ut dolorum omnis autem. Nostrum magnam repellat eveniet labore qui perferendis quia corrupti. Et aut vel quos delectus et rerum. Ut adipisci et nesciunt harum dolores quis deserunt." },
                    { 422, 22, 2, 79832, new DateTime(2021, 4, 29, 11, 42, 3, 307, DateTimeKind.Local).AddTicks(8986), "reprehenderit" },
                    { 580, 22, 49, 212539, new DateTime(2021, 3, 30, 13, 28, 21, 990, DateTimeKind.Local).AddTicks(7998), "eius" },
                    { 48, 26, 56, 511247, new DateTime(2021, 2, 2, 7, 29, 46, 670, DateTimeKind.Local).AddTicks(5604), "Officia dignissimos nihil alias fugit accusantium recusandae est aut." },
                    { 105, 33, 68, 734692, new DateTime(2020, 12, 17, 16, 46, 58, 457, DateTimeKind.Local).AddTicks(463), "Rerum voluptates ipsum facilis. Sit atque aut recusandae debitis ipsum. Facere tempore voluptatem. Aut nam iste quia impedit alias. Qui omnis quas molestiae ut architecto possimus deserunt consequatur." },
                    { 117, 33, 61, 912942, new DateTime(2021, 6, 26, 9, 51, 39, 590, DateTimeKind.Local).AddTicks(840), "fuga" },
                    { 178, 33, 32, 101522, new DateTime(2020, 9, 4, 23, 48, 19, 607, DateTimeKind.Local).AddTicks(6843), "Qui sunt occaecati et." },
                    { 203, 33, 24, 79073, new DateTime(2020, 9, 24, 21, 22, 23, 476, DateTimeKind.Local).AddTicks(4017), "id" },
                    { 244, 33, 27, 287902, new DateTime(2020, 12, 10, 19, 56, 4, 503, DateTimeKind.Local).AddTicks(1373), "veritatis" },
                    { 301, 33, 3, 647958, new DateTime(2021, 2, 8, 6, 4, 11, 785, DateTimeKind.Local).AddTicks(3944), "Sint ut nobis dolores. Neque odit nemo sit ut repellat eos aut. Beatae dolore expedita nihil quod. Minus officiis ipsa earum omnis qui dolor." },
                    { 430, 33, 116, 714530, new DateTime(2020, 11, 20, 12, 28, 50, 798, DateTimeKind.Local).AddTicks(1598), "blanditiis" },
                    { 433, 33, 44, 737988, new DateTime(2021, 2, 17, 16, 24, 31, 356, DateTimeKind.Local).AddTicks(6523), "rem" },
                    { 79, 26, 69, 320940, new DateTime(2020, 8, 17, 21, 53, 57, 98, DateTimeKind.Local).AddTicks(2960), "Non ut qui dolorem dignissimos sapiente numquam hic iste aut.\nNisi totam amet velit recusandae adipisci et." },
                    { 38, 47, 19, 932663, new DateTime(2021, 6, 29, 19, 18, 23, 166, DateTimeKind.Local).AddTicks(4287), "Repellat eius et laudantium magni distinctio et." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 564, 19, 48, 377731, new DateTime(2021, 4, 3, 7, 2, 7, 158, DateTimeKind.Local).AddTicks(7787), "Ut voluptates similique placeat aspernatur voluptates ipsum dolore in.\nOptio ab eum quos ducimus.\nSit ea placeat quo veniam vitae velit.\nIste aliquid aut deleniti dolorum odio commodi perspiciatis.\nQuia earum doloribus est eius aut consequatur maxime." },
                    { 460, 19, 117, 319600, new DateTime(2021, 7, 25, 13, 45, 44, 95, DateTimeKind.Local).AddTicks(5528), "Itaque id error distinctio et voluptatem eius non officiis magnam." },
                    { 13, 76, 49, 269309, new DateTime(2021, 3, 26, 2, 47, 49, 518, DateTimeKind.Local).AddTicks(5085), "magni" },
                    { 33, 76, 83, 90887, new DateTime(2021, 6, 16, 16, 50, 43, 706, DateTimeKind.Local).AddTicks(6940), "Enim non autem tenetur non.\nPlaceat beatae pariatur esse id.\nOdio cum recusandae et deleniti natus delectus.\nAccusamus dolor voluptas distinctio quia eos.\nConsequatur debitis accusamus sit." },
                    { 39, 76, 99, 461981, new DateTime(2020, 12, 27, 7, 44, 55, 209, DateTimeKind.Local).AddTicks(5605), "similique" },
                    { 159, 76, 67, 703823, new DateTime(2021, 7, 28, 14, 58, 33, 822, DateTimeKind.Local).AddTicks(7537), "aut" },
                    { 497, 76, 72, 625010, new DateTime(2021, 2, 18, 13, 30, 15, 235, DateTimeKind.Local).AddTicks(4632), "Odit animi excepturi eius in assumenda odio. Soluta quas sit a odio praesentium odio. Laborum excepturi qui nulla. Ut sunt iste repellat ea recusandae quam corporis aliquid cumque." },
                    { 516, 76, 45, 29556, new DateTime(2021, 7, 19, 6, 18, 47, 940, DateTimeKind.Local).AddTicks(2372), "Est sit dignissimos." },
                    { 190, 26, 70, 55963, new DateTime(2021, 1, 30, 2, 9, 2, 646, DateTimeKind.Local).AddTicks(6691), "Molestiae vel ad quod repellendus.\nRerum ut eligendi.\nQui maiores omnis aut sed est inventore.\nIpsam dolorem esse sunt nam quo vel doloremque at.\nOptio magnam eos recusandae totam.\nQui sunt officiis tempora." },
                    { 15, 25, 115, 432357, new DateTime(2021, 4, 4, 13, 44, 59, 3, DateTimeKind.Local).AddTicks(2195), "laboriosam" },
                    { 42, 25, 98, 555442, new DateTime(2021, 4, 18, 19, 44, 43, 702, DateTimeKind.Local).AddTicks(69), "eos" },
                    { 260, 25, 142, 847130, new DateTime(2021, 3, 14, 9, 21, 24, 231, DateTimeKind.Local).AddTicks(7894), "quia" },
                    { 320, 25, 94, 333650, new DateTime(2021, 5, 28, 11, 50, 2, 181, DateTimeKind.Local).AddTicks(2298), "recusandae" },
                    { 404, 25, 77, 527469, new DateTime(2021, 5, 27, 8, 12, 35, 942, DateTimeKind.Local).AddTicks(6124), "repudiandae" },
                    { 121, 26, 142, 13238, new DateTime(2020, 11, 17, 15, 20, 41, 641, DateTimeKind.Local).AddTicks(8965), "iusto" },
                    { 195, 19, 19, 616624, new DateTime(2021, 1, 24, 22, 53, 41, 565, DateTimeKind.Local).AddTicks(4964), "Nobis aliquam iure aliquid voluptatum et explicabo vero eum.\nEarum rerum eaque rem ut aut quo dolore quisquam.\nVoluptas blanditiis eos esse.\nIure et occaecati corporis qui est accusamus." },
                    { 450, 19, 56, 971861, new DateTime(2020, 12, 13, 7, 21, 55, 39, DateTimeKind.Local).AddTicks(1716), "ut" },
                    { 563, 19, 131, 101994, new DateTime(2020, 12, 3, 1, 34, 32, 948, DateTimeKind.Local).AddTicks(1791), "Ut repudiandae sint id tenetur culpa sit sit consequatur dignissimos." },
                    { 59, 47, 37, 945067, new DateTime(2020, 8, 22, 0, 44, 21, 677, DateTimeKind.Local).AddTicks(5061), "Rerum dicta qui." },
                    { 133, 47, 1, 655732, new DateTime(2020, 10, 6, 7, 34, 25, 837, DateTimeKind.Local).AddTicks(2260), "Quia quis et qui necessitatibus maiores exercitationem.\nAlias inventore neque molestias molestias.\nQuis voluptatem numquam et.\nAut error labore aperiam rerum ut similique aspernatur cupiditate.\nLaborum sed et nesciunt.\nAut et quo rerum est ea rerum consequatur id voluptatem." },
                    { 151, 47, 84, 453917, new DateTime(2021, 6, 2, 4, 50, 4, 902, DateTimeKind.Local).AddTicks(6310), "Dolores illo dicta quis similique et." },
                    { 530, 9, 145, 281074, new DateTime(2020, 12, 26, 14, 44, 42, 756, DateTimeKind.Local).AddTicks(4109), "Ullam omnis qui inventore ipsum accusantium quis exercitationem tempore non." },
                    { 350, 9, 72, 617949, new DateTime(2020, 12, 11, 12, 14, 39, 257, DateTimeKind.Local).AddTicks(851), "Veritatis qui dolores sed eos est omnis ut." },
                    { 281, 9, 12, 194687, new DateTime(2021, 3, 10, 5, 38, 58, 335, DateTimeKind.Local).AddTicks(6785), "Est qui voluptates id." },
                    { 96, 9, 61, 269638, new DateTime(2020, 11, 17, 14, 32, 16, 268, DateTimeKind.Local).AddTicks(9499), "Quas qui tempore qui possimus." },
                    { 482, 79, 33, 562240, new DateTime(2020, 11, 19, 23, 25, 12, 460, DateTimeKind.Local).AddTicks(5908), "Vel ea exercitationem vero doloremque facere deserunt voluptatem qui.\nAperiam ad ipsa et.\nRepellendus accusantium maxime qui libero aut quia quia.\nAt totam ea id voluptatem tempora consectetur laboriosam dolor veniam.\nRerum harum vitae et nobis sint accusamus ea eos rerum.\nDicta ad sit accusantium." },
                    { 353, 79, 133, 582090, new DateTime(2021, 6, 10, 19, 15, 5, 0, DateTimeKind.Local).AddTicks(3677), "Aspernatur voluptas ea voluptates repudiandae est.\nEt similique consequuntur aperiam ullam quae.\nUt ex minus commodi nulla qui.\nQuis fugit eius." },
                    { 337, 79, 6, 11190, new DateTime(2020, 9, 4, 2, 56, 56, 103, DateTimeKind.Local).AddTicks(6960), "Similique sunt cum ipsam aliquid molestias nihil. Modi ut qui. Aut fuga iure quidem saepe. Qui adipisci assumenda molestiae." },
                    { 276, 79, 31, 548766, new DateTime(2021, 5, 21, 17, 33, 47, 423, DateTimeKind.Local).AddTicks(750), "Quo sunt nulla numquam non quod assumenda earum ea." },
                    { 168, 79, 77, 632404, new DateTime(2020, 8, 16, 17, 18, 55, 328, DateTimeKind.Local).AddTicks(3562), "harum" },
                    { 146, 79, 117, 853082, new DateTime(2021, 4, 16, 0, 10, 34, 517, DateTimeKind.Local).AddTicks(8681), "et" },
                    { 37, 26, 106, 528621, new DateTime(2021, 1, 16, 2, 49, 48, 86, DateTimeKind.Local).AddTicks(9078), "Deleniti sit ipsa laborum.\nEt eum a ea praesentium aut deserunt in id ea.\nAb quis ratione est natus consequuntur est minus natus natus.\nDolore consequatur rerum dolor omnis." },
                    { 495, 65, 15, 554387, new DateTime(2020, 12, 7, 6, 12, 20, 729, DateTimeKind.Local).AddTicks(2067), "Aut ratione veritatis quia fuga ut sit." },
                    { 445, 65, 121, 159729, new DateTime(2021, 6, 16, 9, 7, 50, 606, DateTimeKind.Local).AddTicks(6498), "Dolorem possimus sint aut ullam. Fugit minus ipsum voluptates in corrupti inventore aut est. Ab repudiandae quas est saepe fugiat quia laudantium et ad." },
                    { 421, 65, 83, 294661, new DateTime(2021, 3, 3, 14, 22, 11, 896, DateTimeKind.Local).AddTicks(4557), "ipsa" },
                    { 112, 65, 147, 879189, new DateTime(2021, 6, 9, 6, 30, 24, 569, DateTimeKind.Local).AddTicks(9835), "excepturi" },
                    { 409, 65, 121, 33961, new DateTime(2021, 5, 29, 0, 0, 13, 678, DateTimeKind.Local).AddTicks(7052), "Quis quo rem et nihil quas.\nQuod velit in error autem.\nSoluta aspernatur adipisci eligendi minus atque quisquam ad atque laudantium.\nLaborum ut veritatis voluptas nesciunt hic tenetur." },
                    { 571, 1, 6, 289335, new DateTime(2021, 7, 7, 3, 14, 45, 691, DateTimeKind.Local).AddTicks(5316), "Temporibus iusto perferendis suscipit enim et." },
                    { 269, 47, 64, 329710, new DateTime(2021, 5, 4, 18, 35, 49, 922, DateTimeKind.Local).AddTicks(5506), "Qui molestiae impedit dolorem.\nOfficiis maxime illum vitae.\nEum et dicta molestiae explicabo ullam labore autem repellendus accusantium." },
                    { 339, 47, 102, 304126, new DateTime(2021, 7, 21, 16, 22, 18, 417, DateTimeKind.Local).AddTicks(7800), "Non aut consequuntur adipisci facere." },
                    { 438, 47, 17, 5238, new DateTime(2021, 5, 5, 3, 34, 49, 117, DateTimeKind.Local).AddTicks(4188), "Non consequatur quisquam sunt quos eum. Id aut sint omnis et qui ut suscipit. Officiis alias non consequatur suscipit qui est eum. Illum eos ducimus illum reiciendis beatae eum vero et libero. Rerum magni sequi. Hic deleniti qui molestiae molestiae fugiat nihil sed ipsam error." },
                    { 493, 47, 143, 174797, new DateTime(2021, 7, 24, 22, 29, 14, 100, DateTimeKind.Local).AddTicks(9632), "Ut aut aut minus qui voluptas. Aut eligendi modi. Eligendi aut suscipit voluptatum. Dolores dolore quo enim fugit ut quo optio." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 573, 47, 40, 154552, new DateTime(2021, 4, 20, 19, 53, 48, 82, DateTimeKind.Local).AddTicks(2434), "A et dignissimos sapiente explicabo aut et placeat adipisci quam." },
                    { 44, 26, 89, 324263, new DateTime(2020, 11, 7, 6, 29, 10, 203, DateTimeKind.Local).AddTicks(1051), "Impedit laboriosam error rem cumque aliquid non eius." },
                    { 131, 1, 25, 81615, new DateTime(2021, 1, 3, 2, 38, 35, 437, DateTimeKind.Local).AddTicks(522), "rerum" },
                    { 97, 65, 51, 255502, new DateTime(2021, 6, 8, 7, 38, 40, 812, DateTimeKind.Local).AddTicks(8820), "Ut sunt tempore." },
                    { 137, 1, 121, 905708, new DateTime(2021, 8, 6, 12, 0, 47, 292, DateTimeKind.Local).AddTicks(2204), "Quia laboriosam numquam quas consectetur nemo." },
                    { 348, 1, 8, 200319, new DateTime(2020, 9, 11, 21, 11, 5, 937, DateTimeKind.Local).AddTicks(3387), "Commodi sit voluptatibus maiores neque minus iusto ipsam in aut." },
                    { 349, 1, 16, 572547, new DateTime(2020, 11, 6, 16, 28, 50, 571, DateTimeKind.Local).AddTicks(581), "modi" },
                    { 374, 1, 130, 345786, new DateTime(2021, 3, 1, 13, 17, 28, 300, DateTimeKind.Local).AddTicks(2174), "consequatur" },
                    { 424, 1, 10, 432380, new DateTime(2020, 9, 28, 6, 30, 7, 730, DateTimeKind.Local).AddTicks(1214), "Aliquam molestiae aspernatur ullam suscipit repellendus id voluptas modi." },
                    { 449, 1, 28, 287086, new DateTime(2021, 8, 1, 7, 56, 3, 326, DateTimeKind.Local).AddTicks(5071), "Nemo sapiente consequatur tempora. Voluptatum dolorum deleniti consectetur eos et ipsam voluptate voluptates. Voluptatibus nobis est assumenda aspernatur autem consequatur sint. Quam perspiciatis assumenda eaque eos nihil officia." },
                    { 138, 1, 48, 763241, new DateTime(2021, 4, 14, 17, 39, 48, 187, DateTimeKind.Local).AddTicks(4616), "Labore itaque est suscipit." },
                    { 69, 11, 6, 507196, new DateTime(2021, 2, 28, 3, 29, 17, 202, DateTimeKind.Local).AddTicks(525), "Inventore delectus vero iusto laborum.\nIllo corporis sit officiis.\nEt dolor nobis nesciunt et velit laudantium eaque.\nQuam aut sunt a.\nUt dolorem sed non sunt aut et." }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 51, 11, 59 },
                    { 21, 26, 59 },
                    { 12, 54, 118 },
                    { 34, 10, 198 },
                    { 7, 18, 145 },
                    { 61, 34, 135 },
                    { 79, 51, 94 },
                    { 17, 79, 181 },
                    { 30, 65, 35 },
                    { 5, 47, 162 },
                    { 15, 22, 158 },
                    { 18, 19, 117 },
                    { 26, 25, 254 },
                    { 33, 76, 113 },
                    { 76, 14, 53 },
                    { 60, 72, 53 },
                    { 49, 55, 145 },
                    { 52, 83, 113 },
                    { 68, 67, 294 },
                    { 41, 12, 51 },
                    { 81, 23, 264 },
                    { 14, 31, 18 },
                    { 6, 16, 25 },
                    { 8, 15, 92 },
                    { 2, 53, 284 },
                    { 39, 48, 47 },
                    { 13, 13, 295 },
                    { 3, 5, 241 },
                    { 11, 56, 35 },
                    { 32, 44, 26 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 1, 70, 113 },
                    { 16, 50, 254 },
                    { 4, 46, 236 },
                    { 48, 73, 237 },
                    { 28, 41, 226 },
                    { 45, 7, 154 },
                    { 27, 78, 88 },
                    { 36, 82, 200 },
                    { 38, 29, 156 },
                    { 9, 60, 96 },
                    { 50, 52, 103 },
                    { 22, 43, 168 },
                    { 42, 74, 21 },
                    { 31, 38, 164 },
                    { 70, 68, 183 },
                    { 53, 20, 197 },
                    { 47, 24, 149 },
                    { 40, 62, 283 },
                    { 44, 77, 218 },
                    { 74, 40, 142 },
                    { 10, 69, 200 },
                    { 29, 58, 94 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 97, new DateTime(2021, 6, 20, 22, 55, 28, 519, DateTimeKind.Local).AddTicks(3157), 85, new DateTime(2022, 5, 27, 10, 37, 3, 122, DateTimeKind.Local).AddTicks(4380), new DateTime(2021, 2, 11, 14, 54, 2, 505, DateTimeKind.Local).AddTicks(5152), 1, 39, "Vitae voluptatem minus.\nPraesentium consequuntur sit maxime.\nQuas est nobis beatae non in debitis sit.\nVoluptatem quod quas consequatur eveniet saepe enim nihil natus et.\nAut delectus dolorem." },
                    { 122, new DateTime(2020, 12, 29, 17, 25, 49, 350, DateTimeKind.Local).AddTicks(905), 142, new DateTime(2022, 4, 17, 4, 4, 42, 236, DateTimeKind.Local).AddTicks(972), new DateTime(2020, 11, 20, 7, 24, 12, 137, DateTimeKind.Local).AddTicks(179), 3, 38, "Magni natus totam eaque consequatur." },
                    { 165, new DateTime(2020, 8, 25, 0, 19, 13, 779, DateTimeKind.Local).AddTicks(8833), 23, new DateTime(2022, 7, 15, 21, 48, 59, 329, DateTimeKind.Local).AddTicks(4818), new DateTime(2020, 10, 13, 7, 36, 11, 545, DateTimeKind.Local).AddTicks(6375), 3, 38, "Odio ipsa natus possimus recusandae aut ad est quia aut." },
                    { 172, new DateTime(2020, 12, 1, 15, 8, 57, 542, DateTimeKind.Local).AddTicks(7715), 117, new DateTime(2021, 11, 1, 6, 54, 48, 120, DateTimeKind.Local).AddTicks(3989), new DateTime(2021, 1, 12, 3, 46, 31, 515, DateTimeKind.Local).AddTicks(2404), 2, 38, "Rerum nihil ipsum maiores." },
                    { 182, new DateTime(2020, 11, 22, 20, 4, 33, 576, DateTimeKind.Local).AddTicks(8617), 32, new DateTime(2022, 5, 30, 11, 58, 7, 113, DateTimeKind.Local).AddTicks(8371), new DateTime(2021, 7, 14, 10, 49, 41, 662, DateTimeKind.Local).AddTicks(9577), 2, 38, "Perspiciatis eos est sit eos." },
                    { 21, new DateTime(2021, 3, 13, 20, 40, 49, 692, DateTimeKind.Local).AddTicks(9317), 43, new DateTime(2022, 5, 23, 20, 10, 8, 347, DateTimeKind.Local).AddTicks(7827), new DateTime(2020, 10, 7, 16, 59, 24, 573, DateTimeKind.Local).AddTicks(4364), 3, 36, "Minima aut quasi asperiores voluptas qui ea animi.\nConsectetur sit qui sit." },
                    { 28, new DateTime(2021, 3, 3, 9, 48, 10, 602, DateTimeKind.Local).AddTicks(6982), 110, new DateTime(2022, 1, 13, 12, 57, 0, 596, DateTimeKind.Local).AddTicks(6942), new DateTime(2020, 11, 28, 22, 37, 8, 451, DateTimeKind.Local).AddTicks(397), 2, 36, "Numquam molestiae ut nulla commodi non saepe." },
                    { 42, new DateTime(2020, 12, 16, 6, 58, 30, 950, DateTimeKind.Local).AddTicks(9280), 15, new DateTime(2022, 2, 3, 9, 22, 54, 712, DateTimeKind.Local).AddTicks(9153), new DateTime(2020, 10, 31, 14, 44, 39, 90, DateTimeKind.Local).AddTicks(4117), 1, 36, "Architecto similique rerum autem et est modi.\nAt fuga aut quidem natus rerum.\nEos modi ea quisquam.\nFuga numquam sed ipsa doloremque qui." },
                    { 187, new DateTime(2020, 11, 7, 15, 31, 59, 222, DateTimeKind.Local).AddTicks(3032), 83, new DateTime(2022, 3, 8, 6, 14, 56, 450, DateTimeKind.Local).AddTicks(1686), new DateTime(2020, 9, 15, 15, 49, 23, 810, DateTimeKind.Local).AddTicks(9271), 1, 36, "Illum temporibus non vitae non aut nulla.\nNon incidunt tempore magni repudiandae voluptate.\nCupiditate quis possimus dolorum deserunt incidunt.\nId in qui nulla rerum et debitis dolore quia aut.\nEt qui modi sunt animi excepturi est qui." },
                    { 58, new DateTime(2021, 7, 15, 8, 37, 33, 972, DateTimeKind.Local).AddTicks(7433), 5, new DateTime(2022, 7, 12, 22, 40, 8, 386, DateTimeKind.Local).AddTicks(9938), new DateTime(2021, 6, 25, 2, 51, 50, 642, DateTimeKind.Local).AddTicks(8833), 1, 27, "Sint doloremque occaecati neque ut aut doloribus.\nEt aperiam quidem.\nSunt incidunt minima similique ullam vel adipisci tempore.\nEt ut voluptas ut delectus eum velit aspernatur et." },
                    { 92, new DateTime(2021, 8, 9, 19, 48, 49, 856, DateTimeKind.Local).AddTicks(3083), 120, new DateTime(2022, 2, 17, 4, 55, 41, 208, DateTimeKind.Local).AddTicks(3508), new DateTime(2021, 1, 13, 17, 57, 4, 274, DateTimeKind.Local).AddTicks(3326), 4, 27, "Quae molestiae voluptatem nam cumque minima quis." },
                    { 108, new DateTime(2021, 8, 2, 7, 39, 20, 784, DateTimeKind.Local).AddTicks(5470), 137, new DateTime(2022, 7, 25, 7, 53, 25, 70, DateTimeKind.Local).AddTicks(6979), new DateTime(2020, 11, 10, 6, 33, 30, 242, DateTimeKind.Local).AddTicks(9098), 1, 27, "Sit recusandae dolores maxime dolorem hic fugiat sapiente quidem accusantium. Eaque non et voluptates. Qui ut at quo." },
                    { 152, new DateTime(2021, 5, 10, 15, 40, 15, 228, DateTimeKind.Local).AddTicks(7047), 29, new DateTime(2022, 7, 19, 14, 35, 30, 318, DateTimeKind.Local).AddTicks(1754), new DateTime(2020, 12, 31, 6, 42, 7, 806, DateTimeKind.Local).AddTicks(9590), 5, 27, "Sed facere hic pariatur sed maxime explicabo facere.\nDelectus harum deserunt laborum enim et.\nEnim qui illum qui quasi veritatis.\nIllum magni fugiat rerum distinctio esse sit.\nNemo quia voluptas.\nConsequuntur officia laudantium voluptatibus modi delectus voluptates voluptatem blanditiis." },
                    { 160, new DateTime(2020, 11, 21, 17, 3, 46, 429, DateTimeKind.Local).AddTicks(987), 73, new DateTime(2021, 12, 17, 12, 10, 26, 213, DateTimeKind.Local).AddTicks(2735), new DateTime(2020, 12, 7, 12, 31, 41, 619, DateTimeKind.Local).AddTicks(7525), 5, 27, "Molestiae ut porro qui. Eum ea eveniet voluptates voluptatem cumque maiores debitis. Ullam magnam dolore eveniet. Unde sint doloribus sed aliquid ut porro ullam sapiente. Sed doloribus eos dignissimos occaecati quibusdam ut debitis sed. Officiis eligendi cupiditate modi eos ex fugit et." },
                    { 169, new DateTime(2021, 5, 4, 20, 43, 8, 48, DateTimeKind.Local).AddTicks(8308), 98, new DateTime(2022, 8, 3, 9, 17, 27, 73, DateTimeKind.Local).AddTicks(5354), new DateTime(2021, 2, 28, 6, 28, 56, 110, DateTimeKind.Local).AddTicks(1460), 3, 27, "Doloribus aliquam dolorem. Veniam velit saepe aut. Dolores ut similique a blanditiis aut repudiandae a. Ea unde voluptatem maxime sapiente harum. Eos doloremque et enim aut." },
                    { 40, new DateTime(2021, 3, 20, 18, 30, 56, 139, DateTimeKind.Local).AddTicks(2381), 145, new DateTime(2022, 3, 23, 10, 30, 14, 753, DateTimeKind.Local).AddTicks(789), new DateTime(2020, 12, 22, 1, 31, 55, 571, DateTimeKind.Local).AddTicks(4656), 5, 45, "Magni cupiditate minus consequatur sit qui nemo sint. Voluptatum ex magnam. Quidem nostrum aut dolores non deleniti eaque qui rem. Aut porro dolorem autem. Hic reprehenderit aspernatur omnis. Harum eos iusto sit est in et." },
                    { 77, new DateTime(2021, 1, 17, 6, 25, 42, 210, DateTimeKind.Local).AddTicks(5817), 87, new DateTime(2022, 3, 13, 9, 59, 28, 931, DateTimeKind.Local).AddTicks(8053), new DateTime(2020, 11, 16, 23, 7, 16, 115, DateTimeKind.Local).AddTicks(3578), 3, 45, "Sequi quidem provident doloribus quo aut similique quo dicta sed.\nEx tempore consectetur consequuntur dolorem.\nEum tempora quia voluptatum omnis." },
                    { 18, new DateTime(2021, 5, 7, 3, 1, 42, 806, DateTimeKind.Local).AddTicks(7958), 53, new DateTime(2022, 1, 18, 0, 10, 14, 983, DateTimeKind.Local).AddTicks(149), new DateTime(2020, 9, 28, 7, 6, 13, 126, DateTimeKind.Local).AddTicks(2266), 2, 28, "Alias voluptates nihil ducimus consequatur asperiores voluptas sequi quis." },
                    { 105, new DateTime(2021, 5, 18, 16, 9, 20, 789, DateTimeKind.Local).AddTicks(9690), 139, new DateTime(2021, 10, 1, 8, 59, 6, 150, DateTimeKind.Local).AddTicks(5802), new DateTime(2020, 12, 14, 18, 33, 59, 319, DateTimeKind.Local).AddTicks(442), 2, 28, "Et ut et voluptas." },
                    { 163, new DateTime(2020, 11, 28, 0, 48, 38, 870, DateTimeKind.Local).AddTicks(8381), 146, new DateTime(2022, 3, 24, 20, 39, 11, 596, DateTimeKind.Local).AddTicks(3955), new DateTime(2021, 4, 21, 15, 47, 44, 533, DateTimeKind.Local).AddTicks(8842), 2, 28, "Dignissimos et officia temporibus sunt." },
                    { 180, new DateTime(2020, 12, 2, 9, 0, 52, 764, DateTimeKind.Local).AddTicks(264), 43, new DateTime(2022, 7, 15, 17, 36, 13, 739, DateTimeKind.Local).AddTicks(1561), new DateTime(2021, 3, 27, 18, 12, 20, 752, DateTimeKind.Local).AddTicks(7487), 5, 28, "Ut labore sint est nemo. Culpa omnis hic repellendus et dolore quis. Rerum facere et aut. Odit sint enim." },
                    { 185, new DateTime(2021, 3, 3, 14, 29, 12, 2, DateTimeKind.Local).AddTicks(6124), 22, new DateTime(2022, 3, 9, 20, 29, 33, 835, DateTimeKind.Local).AddTicks(5796), new DateTime(2020, 11, 23, 16, 40, 31, 585, DateTimeKind.Local).AddTicks(3067), 5, 28, "Rerum perferendis et nobis." },
                    { 85, new DateTime(2021, 6, 9, 1, 9, 36, 40, DateTimeKind.Local).AddTicks(2087), 66, new DateTime(2022, 5, 18, 20, 20, 25, 845, DateTimeKind.Local).AddTicks(9201), new DateTime(2021, 3, 19, 3, 12, 34, 212, DateTimeKind.Local).AddTicks(9892), 4, 38, "Velit sed suscipit sint natus omnis neque." },
                    { 5, new DateTime(2021, 5, 3, 17, 32, 47, 679, DateTimeKind.Local).AddTicks(3969), 119, new DateTime(2022, 4, 1, 5, 46, 48, 200, DateTimeKind.Local).AddTicks(3900), new DateTime(2021, 1, 12, 14, 54, 55, 754, DateTimeKind.Local).AddTicks(7903), 2, 48, "accusantium" },
                    { 83, new DateTime(2020, 9, 5, 10, 6, 2, 932, DateTimeKind.Local).AddTicks(5360), 107, new DateTime(2022, 3, 9, 8, 13, 27, 971, DateTimeKind.Local).AddTicks(1876), new DateTime(2021, 7, 18, 3, 41, 35, 868, DateTimeKind.Local).AddTicks(4674), 5, 38, "Qui consectetur ex rerum." },
                    { 66, new DateTime(2020, 8, 24, 9, 35, 27, 561, DateTimeKind.Local).AddTicks(347), 18, new DateTime(2021, 10, 28, 17, 14, 32, 397, DateTimeKind.Local).AddTicks(3640), new DateTime(2021, 4, 8, 0, 23, 9, 780, DateTimeKind.Local).AddTicks(2317), 4, 50, "Maxime ratione voluptatum laboriosam.\nReiciendis aliquid voluptatem qui ea ullam quia quidem.\nFugit placeat rerum pariatur et aut tempora.\nSed aliquid corrupti inventore dicta aperiam." },
                    { 191, new DateTime(2020, 8, 16, 19, 10, 6, 428, DateTimeKind.Local).AddTicks(8567), 30, new DateTime(2022, 6, 26, 6, 47, 53, 849, DateTimeKind.Local).AddTicks(3046), new DateTime(2021, 6, 20, 14, 56, 45, 152, DateTimeKind.Local).AddTicks(5840), 4, 53, "Quo culpa et.\nEst ut repellat.\nPariatur hic voluptatem nobis.\nVel iure sed.\nVoluptate sapiente quod sint alias eligendi tempora voluptates.\nIllum sunt quasi non aliquid quos." },
                    { 37, new DateTime(2021, 5, 5, 3, 37, 32, 68, DateTimeKind.Local).AddTicks(8966), 127, new DateTime(2022, 3, 5, 2, 1, 49, 26, DateTimeKind.Local).AddTicks(7029), new DateTime(2021, 4, 23, 9, 52, 20, 45, DateTimeKind.Local).AddTicks(4650), 2, 70, "Voluptate nemo aut. Harum dolor consequuntur. Delectus excepturi fugit consequatur iure." },
                    { 50, new DateTime(2020, 9, 18, 18, 46, 4, 337, DateTimeKind.Local).AddTicks(9560), 18, new DateTime(2021, 10, 13, 12, 15, 4, 32, DateTimeKind.Local).AddTicks(8914), new DateTime(2021, 7, 26, 14, 59, 57, 886, DateTimeKind.Local).AddTicks(8138), 1, 70, "Odio error maxime quis." },
                    { 55, new DateTime(2020, 8, 30, 6, 31, 2, 517, DateTimeKind.Local).AddTicks(6834), 32, new DateTime(2021, 12, 21, 8, 59, 53, 374, DateTimeKind.Local).AddTicks(6614), new DateTime(2020, 10, 2, 9, 29, 37, 485, DateTimeKind.Local).AddTicks(6839), 4, 70, "Et at officia qui non.\nEveniet deserunt asperiores minus aliquam magni soluta aperiam accusamus quia.\nIllo et quis et." },
                    { 118, new DateTime(2020, 12, 24, 17, 52, 8, 455, DateTimeKind.Local).AddTicks(9162), 123, new DateTime(2021, 11, 26, 23, 46, 52, 878, DateTimeKind.Local).AddTicks(2411), new DateTime(2021, 6, 18, 14, 27, 26, 356, DateTimeKind.Local).AddTicks(4886), 1, 70, "Et assumenda aut voluptas ut neque." },
                    { 151, new DateTime(2021, 1, 24, 8, 53, 34, 360, DateTimeKind.Local).AddTicks(6805), 55, new DateTime(2021, 12, 14, 8, 28, 37, 266, DateTimeKind.Local).AddTicks(4904), new DateTime(2021, 2, 9, 8, 59, 25, 195, DateTimeKind.Local).AddTicks(5533), 1, 70, "Delectus inventore nam facere nihil necessitatibus quia." },
                    { 178, new DateTime(2020, 11, 30, 7, 12, 42, 872, DateTimeKind.Local).AddTicks(7522), 21, new DateTime(2022, 7, 20, 23, 7, 9, 525, DateTimeKind.Local).AddTicks(5933), new DateTime(2021, 2, 4, 18, 38, 1, 11, DateTimeKind.Local).AddTicks(9678), 5, 70, "Eos sunt aut officia voluptas aliquam. Et vitae enim. Perspiciatis consequuntur sit. Enim dicta itaque." },
                    { 9, new DateTime(2021, 6, 13, 22, 31, 55, 119, DateTimeKind.Local).AddTicks(1939), 132, new DateTime(2022, 7, 21, 1, 59, 47, 373, DateTimeKind.Local).AddTicks(6621), new DateTime(2021, 6, 24, 1, 15, 36, 812, DateTimeKind.Local).AddTicks(6590), 3, 31, "Asperiores dolorem veniam.\nPossimus reiciendis sit.\nEt at et." },
                    { 17, new DateTime(2020, 12, 28, 23, 59, 19, 981, DateTimeKind.Local).AddTicks(1147), 39, new DateTime(2022, 7, 30, 19, 2, 53, 321, DateTimeKind.Local).AddTicks(4803), new DateTime(2021, 4, 19, 11, 35, 19, 567, DateTimeKind.Local).AddTicks(4646), 1, 31, "dolores" },
                    { 81, new DateTime(2021, 6, 5, 5, 51, 52, 379, DateTimeKind.Local).AddTicks(4913), 140, new DateTime(2022, 7, 29, 16, 30, 37, 547, DateTimeKind.Local).AddTicks(2942), new DateTime(2021, 6, 2, 23, 25, 11, 438, DateTimeKind.Local).AddTicks(2974), 2, 31, "Veritatis ut animi minima et quia quis atque nesciunt voluptates.\nAdipisci temporibus et expedita et adipisci nihil facere.\nDeleniti et et et in.\nQuisquam itaque impedit totam temporibus praesentium non ea.\nCommodi dolorem quis excepturi qui voluptatum unde qui.\nConsectetur vel porro sapiente voluptatum." },
                    { 157, new DateTime(2020, 12, 14, 10, 37, 19, 981, DateTimeKind.Local).AddTicks(5931), 129, new DateTime(2022, 3, 7, 13, 33, 34, 353, DateTimeKind.Local).AddTicks(6968), new DateTime(2021, 2, 7, 22, 22, 23, 329, DateTimeKind.Local).AddTicks(1060), 3, 31, "Quam porro quod eos omnis nisi id eveniet soluta." },
                    { 94, new DateTime(2020, 10, 28, 15, 52, 30, 159, DateTimeKind.Local).AddTicks(9834), 111, new DateTime(2022, 8, 1, 5, 45, 44, 284, DateTimeKind.Local).AddTicks(520), new DateTime(2020, 10, 29, 22, 35, 12, 150, DateTimeKind.Local).AddTicks(1644), 1, 22, "Quis mollitia aperiam deleniti occaecati mollitia et. Et eum rem sint deleniti qui consequatur libero. Numquam aperiam maiores sit qui quaerat. Laborum reiciendis beatae non omnis deleniti enim. Veniam perferendis ratione quia eum quia." },
                    { 96, new DateTime(2021, 4, 6, 23, 58, 2, 177, DateTimeKind.Local).AddTicks(4598), 88, new DateTime(2022, 7, 21, 7, 8, 16, 586, DateTimeKind.Local).AddTicks(2399), new DateTime(2021, 4, 30, 5, 51, 30, 517, DateTimeKind.Local).AddTicks(8384), 3, 22, "Aut rerum nihil aut et incidunt laudantium. Quibusdam veniam numquam molestiae dolore sit deserunt qui. Sit dolores reprehenderit illo nulla. Soluta voluptatum error perspiciatis dolor mollitia accusamus. Suscipit dolore enim repellat at rerum necessitatibus quis et quia." },
                    { 176, new DateTime(2020, 12, 22, 22, 38, 10, 393, DateTimeKind.Local).AddTicks(7566), 44, new DateTime(2021, 12, 2, 2, 42, 27, 728, DateTimeKind.Local).AddTicks(3468), new DateTime(2020, 9, 20, 17, 53, 45, 406, DateTimeKind.Local).AddTicks(8919), 2, 22, "Nobis ut aut.\nExercitationem molestiae esse animi quia et aut.\nVoluptate vero velit dolorem dolorem amet dolores provident illum et." },
                    { 199, new DateTime(2020, 9, 13, 17, 31, 36, 639, DateTimeKind.Local).AddTicks(6877), 145, new DateTime(2021, 10, 14, 5, 13, 0, 342, DateTimeKind.Local).AddTicks(6479), new DateTime(2021, 1, 10, 5, 57, 31, 810, DateTimeKind.Local).AddTicks(7164), 3, 22, "Veniam in blanditiis repellat sunt.\nIllo mollitia consectetur in est voluptatem." },
                    { 72, new DateTime(2021, 7, 30, 8, 16, 34, 819, DateTimeKind.Local).AddTicks(9796), 3, new DateTime(2021, 12, 5, 13, 49, 54, 631, DateTimeKind.Local).AddTicks(2068), new DateTime(2021, 4, 10, 6, 5, 19, 194, DateTimeKind.Local).AddTicks(5006), 3, 10, "Corporis et nobis hic." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 76, new DateTime(2020, 11, 14, 13, 3, 49, 55, DateTimeKind.Local).AddTicks(9752), 48, new DateTime(2022, 2, 9, 3, 37, 14, 631, DateTimeKind.Local).AddTicks(2580), new DateTime(2021, 3, 9, 8, 38, 25, 894, DateTimeKind.Local).AddTicks(7020), 3, 10, "Excepturi voluptatem consequuntur asperiores et velit numquam eos ut autem. Ab non soluta porro reprehenderit non nesciunt. Similique voluptatem non." },
                    { 88, new DateTime(2020, 12, 9, 11, 4, 11, 950, DateTimeKind.Local).AddTicks(9255), 113, new DateTime(2021, 11, 7, 5, 21, 37, 76, DateTimeKind.Local).AddTicks(2505), new DateTime(2021, 2, 7, 15, 48, 42, 338, DateTimeKind.Local).AddTicks(3288), 5, 10, "laborum" },
                    { 113, new DateTime(2021, 1, 17, 4, 13, 14, 168, DateTimeKind.Local).AddTicks(5660), 6, new DateTime(2021, 10, 21, 3, 46, 27, 281, DateTimeKind.Local).AddTicks(7308), new DateTime(2021, 5, 12, 17, 31, 3, 820, DateTimeKind.Local).AddTicks(8323), 2, 10, "Accusantium dolorem totam.\nSaepe est eos similique ea numquam praesentium.\nQui recusandae earum.\nTempora aut iure dolorem expedita nihil vitae.\nQuidem quo reprehenderit explicabo sed aperiam ipsam dolorum." },
                    { 164, new DateTime(2021, 6, 18, 15, 47, 56, 901, DateTimeKind.Local).AddTicks(9474), 59, new DateTime(2021, 12, 4, 7, 26, 12, 15, DateTimeKind.Local).AddTicks(8212), new DateTime(2020, 11, 25, 9, 47, 14, 192, DateTimeKind.Local).AddTicks(3344), 5, 10, "Dolorem deserunt commodi ipsum quis hic sed laborum nesciunt optio. Provident ratione omnis soluta eos. Et et error rerum. Libero non in rerum ut. Dolores consectetur aliquid quaerat odio ullam eligendi temporibus." },
                    { 25, new DateTime(2021, 2, 27, 1, 4, 47, 767, DateTimeKind.Local).AddTicks(2574), 120, new DateTime(2022, 5, 12, 22, 9, 46, 176, DateTimeKind.Local).AddTicks(582), new DateTime(2020, 12, 8, 20, 49, 40, 58, DateTimeKind.Local).AddTicks(4902), 5, 50, "Veritatis delectus optio harum.\nVelit pariatur fuga laudantium eius non eligendi quae voluptatem quia." },
                    { 54, new DateTime(2021, 2, 8, 5, 46, 35, 245, DateTimeKind.Local).AddTicks(5011), 9, new DateTime(2022, 1, 20, 23, 47, 46, 649, DateTimeKind.Local).AddTicks(5738), new DateTime(2020, 9, 18, 5, 27, 26, 772, DateTimeKind.Local).AddTicks(3925), 4, 38, "Neque possimus dolor consequatur omnis recusandae sint explicabo sit rerum. Temporibus odio sint. Omnis sunt similique et error ab sunt voluptas. Placeat est aliquam deleniti modi aut. Sapiente dolores sequi asperiores dolor est minus ex." },
                    { 155, new DateTime(2020, 12, 15, 0, 57, 3, 431, DateTimeKind.Local).AddTicks(3960), 26, new DateTime(2022, 6, 24, 4, 32, 48, 538, DateTimeKind.Local).AddTicks(1372), new DateTime(2020, 10, 15, 9, 6, 26, 399, DateTimeKind.Local).AddTicks(5649), 5, 53, "Ut eaque natus laboriosam nam et aut sed voluptatum.\nUt quo modi alias maiores corporis.\nOmnis temporibus qui." },
                    { 33, new DateTime(2020, 11, 27, 3, 45, 13, 485, DateTimeKind.Local).AddTicks(2479), 72, new DateTime(2021, 12, 12, 4, 52, 3, 887, DateTimeKind.Local).AddTicks(3593), new DateTime(2021, 7, 7, 12, 40, 32, 507, DateTimeKind.Local).AddTicks(4291), 1, 48, "Fuga quo molestias provident.\nAut sit labore est asperiores explicabo nam quisquam.\nQuia ipsa commodi.\nNon alias nihil reiciendis sit est cupiditate.\nAut aut in sed voluptate.\nAut blanditiis esse id laboriosam sed doloremque est ratione dolorum." },
                    { 68, new DateTime(2021, 4, 15, 22, 19, 12, 679, DateTimeKind.Local).AddTicks(7605), 131, new DateTime(2022, 2, 13, 1, 2, 12, 998, DateTimeKind.Local).AddTicks(8380), new DateTime(2020, 12, 24, 9, 55, 9, 525, DateTimeKind.Local).AddTicks(9524), 5, 48, "explicabo" },
                    { 64, new DateTime(2021, 4, 7, 13, 10, 49, 370, DateTimeKind.Local).AddTicks(7063), 142, new DateTime(2021, 9, 21, 10, 9, 56, 976, DateTimeKind.Local).AddTicks(3803), new DateTime(2020, 8, 22, 18, 2, 40, 138, DateTimeKind.Local).AddTicks(1796), 2, 3, "impedit" },
                    { 75, new DateTime(2020, 11, 10, 3, 14, 35, 871, DateTimeKind.Local).AddTicks(4233), 93, new DateTime(2021, 9, 17, 12, 5, 28, 346, DateTimeKind.Local).AddTicks(5501), new DateTime(2021, 8, 5, 21, 32, 50, 115, DateTimeKind.Local).AddTicks(8934), 4, 3, "Amet placeat ea quos earum.\nMaiores ipsam occaecati temporibus ut tempore architecto.\nError quia nemo fuga.\nEst esse quas.\nAut error dolor.\nEsse dolorem deserunt quae aut dolor." },
                    { 192, new DateTime(2020, 9, 23, 7, 26, 10, 996, DateTimeKind.Local).AddTicks(6633), 8, new DateTime(2021, 12, 7, 0, 33, 18, 783, DateTimeKind.Local).AddTicks(2040), new DateTime(2021, 4, 4, 17, 13, 9, 695, DateTimeKind.Local).AddTicks(5756), 3, 3, "Sapiente nemo ducimus earum." },
                    { 71, new DateTime(2020, 11, 23, 14, 56, 8, 947, DateTimeKind.Local).AddTicks(7548), 111, new DateTime(2022, 7, 17, 5, 48, 44, 845, DateTimeKind.Local).AddTicks(7868), new DateTime(2021, 7, 20, 11, 4, 16, 729, DateTimeKind.Local).AddTicks(5883), 2, 51, "Labore consequuntur eum aut sint magnam omnis." },
                    { 8, new DateTime(2020, 11, 3, 22, 43, 52, 599, DateTimeKind.Local).AddTicks(4458), 145, new DateTime(2022, 7, 10, 13, 38, 9, 370, DateTimeKind.Local).AddTicks(3563), new DateTime(2020, 9, 19, 6, 19, 21, 614, DateTimeKind.Local).AddTicks(2522), 3, 34, "modi" },
                    { 26, new DateTime(2020, 8, 15, 8, 26, 19, 675, DateTimeKind.Local).AddTicks(3673), 127, new DateTime(2021, 10, 22, 9, 2, 44, 344, DateTimeKind.Local).AddTicks(6326), new DateTime(2021, 5, 28, 5, 31, 24, 553, DateTimeKind.Local).AddTicks(3731), 4, 34, "cupiditate" },
                    { 74, new DateTime(2021, 6, 22, 0, 44, 41, 142, DateTimeKind.Local).AddTicks(3420), 28, new DateTime(2022, 5, 23, 1, 18, 11, 226, DateTimeKind.Local).AddTicks(7970), new DateTime(2020, 12, 31, 19, 51, 37, 499, DateTimeKind.Local).AddTicks(1873), 1, 34, "Tempore tempore quia ea velit ut pariatur sed deleniti.\nEt ut ratione quis incidunt et aut adipisci aliquid magni.\nOdio alias aut.\nPariatur voluptatem perspiciatis in.\nQuia velit aperiam aut commodi libero." },
                    { 125, new DateTime(2020, 12, 9, 11, 40, 8, 692, DateTimeKind.Local).AddTicks(9586), 140, new DateTime(2021, 11, 8, 0, 53, 33, 802, DateTimeKind.Local).AddTicks(6656), new DateTime(2021, 1, 24, 5, 26, 27, 319, DateTimeKind.Local).AddTicks(2121), 5, 34, "vel" },
                    { 193, new DateTime(2021, 6, 21, 6, 27, 39, 336, DateTimeKind.Local).AddTicks(3156), 92, new DateTime(2022, 5, 23, 8, 1, 22, 411, DateTimeKind.Local).AddTicks(5555), new DateTime(2020, 10, 23, 0, 18, 8, 437, DateTimeKind.Local).AddTicks(3323), 4, 34, "Fugit sit quo rerum soluta sed quia.\nNihil quia rerum.\nDistinctio optio officiis molestias consectetur quis maiores." },
                    { 7, new DateTime(2021, 5, 23, 7, 0, 30, 679, DateTimeKind.Local).AddTicks(2233), 32, new DateTime(2021, 12, 28, 1, 4, 4, 347, DateTimeKind.Local).AddTicks(5008), new DateTime(2020, 9, 18, 6, 39, 51, 400, DateTimeKind.Local).AddTicks(4511), 5, 12, "dicta" },
                    { 12, new DateTime(2021, 8, 2, 15, 15, 12, 533, DateTimeKind.Local).AddTicks(9712), 93, new DateTime(2022, 4, 15, 18, 44, 2, 409, DateTimeKind.Local).AddTicks(8124), new DateTime(2021, 1, 12, 22, 59, 18, 672, DateTimeKind.Local).AddTicks(7887), 3, 12, "sed" },
                    { 32, new DateTime(2021, 2, 27, 14, 35, 25, 857, DateTimeKind.Local).AddTicks(2449), 79, new DateTime(2022, 1, 6, 14, 4, 35, 296, DateTimeKind.Local).AddTicks(5350), new DateTime(2021, 6, 13, 11, 2, 39, 397, DateTimeKind.Local).AddTicks(5395), 3, 12, "Non et accusamus provident. Id ipsa ducimus. Et est sunt dolorem vero qui explicabo molestiae ratione." },
                    { 70, new DateTime(2020, 12, 21, 8, 48, 6, 52, DateTimeKind.Local).AddTicks(7797), 72, new DateTime(2021, 10, 23, 22, 14, 20, 833, DateTimeKind.Local).AddTicks(3877), new DateTime(2020, 12, 15, 10, 10, 49, 674, DateTimeKind.Local).AddTicks(1011), 1, 12, "sed" },
                    { 93, new DateTime(2021, 7, 19, 12, 49, 21, 963, DateTimeKind.Local).AddTicks(9386), 133, new DateTime(2021, 9, 14, 10, 26, 24, 34, DateTimeKind.Local).AddTicks(424), new DateTime(2020, 10, 8, 9, 56, 31, 524, DateTimeKind.Local).AddTicks(6319), 1, 12, "Officiis in minima eum dolorem doloribus." },
                    { 156, new DateTime(2021, 3, 12, 0, 26, 5, 911, DateTimeKind.Local).AddTicks(2796), 144, new DateTime(2022, 3, 28, 8, 26, 24, 579, DateTimeKind.Local).AddTicks(8873), new DateTime(2020, 10, 2, 10, 48, 33, 313, DateTimeKind.Local).AddTicks(7142), 5, 12, "Omnis voluptates similique et sint veritatis voluptates veniam consectetur.\nRepudiandae et error ea consequatur unde.\nDolorum occaecati rerum et dolores consectetur eum quidem sequi.\nQuia iure excepturi dolorem ea non cumque et.\nOmnis numquam nemo earum architecto sit et.\nDebitis incidunt explicabo." },
                    { 195, new DateTime(2021, 1, 28, 13, 10, 29, 784, DateTimeKind.Local).AddTicks(5317), 52, new DateTime(2022, 6, 3, 7, 14, 34, 676, DateTimeKind.Local).AddTicks(5785), new DateTime(2021, 6, 24, 18, 40, 37, 940, DateTimeKind.Local).AddTicks(8725), 4, 12, "beatae" },
                    { 45, new DateTime(2021, 7, 27, 7, 35, 57, 585, DateTimeKind.Local).AddTicks(9177), 36, new DateTime(2021, 11, 7, 21, 33, 14, 579, DateTimeKind.Local).AddTicks(5605), new DateTime(2021, 3, 28, 16, 58, 45, 942, DateTimeKind.Local).AddTicks(3845), 4, 21, "Eius molestiae doloremque.\nEos doloremque mollitia ut distinctio asperiores dignissimos sit possimus et.\nSimilique et voluptatem aut necessitatibus quidem quas autem aliquid.\nAb placeat dolores mollitia exercitationem aliquid aut soluta voluptatibus nisi.\nEaque laboriosam laudantium." },
                    { 98, new DateTime(2021, 5, 29, 22, 44, 13, 614, DateTimeKind.Local).AddTicks(5073), 139, new DateTime(2021, 12, 29, 11, 38, 34, 20, DateTimeKind.Local).AddTicks(1031), new DateTime(2021, 7, 15, 19, 38, 44, 478, DateTimeKind.Local).AddTicks(5711), 1, 21, "Sed aliquam dolor iste odio enim ex. Impedit sit et optio eveniet mollitia quo. Voluptas aut facere error quo et. Sed eos ut culpa qui fugiat ad. Dolorem sequi numquam. Fugit fugit suscipit eum iusto." },
                    { 126, new DateTime(2021, 3, 21, 10, 33, 48, 7, DateTimeKind.Local).AddTicks(5231), 20, new DateTime(2022, 3, 24, 3, 57, 54, 257, DateTimeKind.Local).AddTicks(6208), new DateTime(2020, 12, 2, 11, 21, 56, 986, DateTimeKind.Local).AddTicks(7473), 4, 21, "Et sunt eum sit quo eum.\nConsequuntur voluptatibus sint.\nAperiam ad voluptatem.\nFuga est et omnis non excepturi voluptas qui architecto.\nNon quasi quis tempore ratione laudantium eveniet est optio." },
                    { 177, new DateTime(2021, 5, 4, 18, 32, 5, 3, DateTimeKind.Local).AddTicks(2874), 3, new DateTime(2022, 5, 31, 20, 22, 4, 180, DateTimeKind.Local).AddTicks(5758), new DateTime(2021, 4, 2, 5, 35, 39, 433, DateTimeKind.Local).AddTicks(1385), 2, 21, "Quisquam asperiores impedit laboriosam rem.\nDolore numquam cupiditate." },
                    { 183, new DateTime(2021, 5, 29, 3, 56, 6, 154, DateTimeKind.Local).AddTicks(5054), 40, new DateTime(2021, 11, 28, 0, 11, 41, 143, DateTimeKind.Local).AddTicks(75), new DateTime(2021, 7, 22, 8, 21, 54, 586, DateTimeKind.Local).AddTicks(6985), 5, 21, "omnis" },
                    { 162, new DateTime(2021, 5, 26, 15, 42, 39, 488, DateTimeKind.Local).AddTicks(6494), 77, new DateTime(2021, 12, 30, 1, 37, 11, 87, DateTimeKind.Local).AddTicks(8226), new DateTime(2020, 10, 2, 17, 4, 50, 706, DateTimeKind.Local).AddTicks(6062), 4, 61, "Et autem quae amet aut vero.\nAssumenda quaerat repellat voluptatem et in.\nTotam harum in non aut." },
                    { 65, new DateTime(2021, 3, 22, 2, 30, 40, 469, DateTimeKind.Local).AddTicks(987), 148, new DateTime(2022, 4, 13, 18, 36, 15, 743, DateTimeKind.Local).AddTicks(5398), new DateTime(2020, 9, 25, 15, 58, 32, 422, DateTimeKind.Local).AddTicks(3027), 1, 48, "Iste praesentium ipsum.\nBeatae fugit tempore voluptatem.\nEst autem error officiis harum qui delectus cumque.\nVitae dolore possimus incidunt qui qui ab sit ipsum dolorem.\nNobis nihil delectus dignissimos occaecati qui." },
                    { 150, new DateTime(2021, 7, 23, 7, 32, 47, 128, DateTimeKind.Local).AddTicks(2532), 54, new DateTime(2022, 8, 2, 11, 49, 48, 923, DateTimeKind.Local).AddTicks(7145), new DateTime(2021, 8, 6, 19, 10, 33, 57, DateTimeKind.Local).AddTicks(9816), 3, 61, "Vel aliquid omnis et sit.\nNecessitatibus explicabo provident officia sunt nobis est officia libero et.\nFuga distinctio dolor blanditiis minus vel consequatur nihil suscipit vel.\nAlias dolor aspernatur consequuntur." },
                    { 62, new DateTime(2021, 1, 3, 0, 29, 3, 836, DateTimeKind.Local).AddTicks(3333), 21, new DateTime(2022, 7, 22, 14, 55, 55, 720, DateTimeKind.Local).AddTicks(6108), new DateTime(2021, 2, 17, 21, 26, 1, 255, DateTimeKind.Local).AddTicks(3050), 5, 61, "rem" },
                    { 79, new DateTime(2021, 2, 27, 11, 29, 42, 368, DateTimeKind.Local).AddTicks(3030), 42, new DateTime(2021, 12, 28, 6, 10, 52, 335, DateTimeKind.Local).AddTicks(3473), new DateTime(2021, 6, 20, 16, 16, 23, 723, DateTimeKind.Local).AddTicks(5741), 4, 48, "Amet quasi sapiente vero." },
                    { 119, new DateTime(2020, 12, 7, 8, 24, 52, 714, DateTimeKind.Local).AddTicks(3108), 122, new DateTime(2022, 3, 29, 6, 46, 0, 373, DateTimeKind.Local).AddTicks(7672), new DateTime(2020, 11, 21, 19, 38, 42, 283, DateTimeKind.Local).AddTicks(6941), 3, 48, "eligendi" },
                    { 159, new DateTime(2020, 9, 1, 21, 31, 51, 763, DateTimeKind.Local).AddTicks(7419), 90, new DateTime(2022, 8, 4, 14, 27, 25, 189, DateTimeKind.Local).AddTicks(5745), new DateTime(2020, 9, 6, 9, 10, 49, 597, DateTimeKind.Local).AddTicks(7271), 2, 48, "aut" },
                    { 175, new DateTime(2021, 5, 25, 13, 7, 37, 360, DateTimeKind.Local).AddTicks(4044), 46, new DateTime(2022, 6, 29, 21, 34, 35, 603, DateTimeKind.Local).AddTicks(1971), new DateTime(2021, 4, 8, 6, 22, 31, 378, DateTimeKind.Local).AddTicks(3317), 5, 48, "sed" },
                    { 186, new DateTime(2021, 7, 25, 17, 29, 54, 94, DateTimeKind.Local).AddTicks(1720), 88, new DateTime(2022, 4, 9, 8, 36, 40, 677, DateTimeKind.Local).AddTicks(6323), new DateTime(2021, 1, 15, 7, 25, 51, 687, DateTimeKind.Local).AddTicks(3183), 5, 48, "nihil" },
                    { 3, new DateTime(2021, 1, 24, 11, 4, 42, 87, DateTimeKind.Local).AddTicks(1918), 43, new DateTime(2022, 4, 15, 3, 18, 21, 649, DateTimeKind.Local).AddTicks(8535), new DateTime(2021, 5, 28, 4, 55, 10, 821, DateTimeKind.Local).AddTicks(814), 4, 4, "Qui aliquam possimus fugiat.\nCorrupti non numquam sunt iure earum dolorum.\nEst nihil placeat.\nBeatae expedita hic numquam.\nEt delectus id et velit sequi dolores." },
                    { 10, new DateTime(2021, 6, 22, 2, 17, 8, 743, DateTimeKind.Local).AddTicks(5561), 65, new DateTime(2022, 8, 10, 3, 35, 52, 847, DateTimeKind.Local).AddTicks(1681), new DateTime(2021, 1, 19, 20, 36, 39, 834, DateTimeKind.Local).AddTicks(2802), 4, 4, "Dolorem eos libero ab ad ipsa. Repellendus deserunt iste inventore magnam facere molestias nobis nihil id. Totam et adipisci." },
                    { 78, new DateTime(2021, 2, 20, 11, 24, 32, 643, DateTimeKind.Local).AddTicks(3139), 60, new DateTime(2022, 2, 15, 0, 48, 7, 597, DateTimeKind.Local).AddTicks(5509), new DateTime(2021, 6, 26, 2, 52, 15, 845, DateTimeKind.Local).AddTicks(3449), 4, 4, "Nesciunt reiciendis iure praesentium esse in est alias.\nEa ducimus perferendis commodi nulla sunt quasi.\nConsequatur dolores nulla vitae." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 99, new DateTime(2021, 7, 15, 12, 15, 6, 952, DateTimeKind.Local).AddTicks(509), 32, new DateTime(2022, 5, 18, 1, 50, 1, 12, DateTimeKind.Local).AddTicks(2807), new DateTime(2021, 6, 20, 9, 20, 5, 773, DateTimeKind.Local).AddTicks(6421), 2, 4, "ut" },
                    { 153, new DateTime(2021, 7, 4, 3, 0, 18, 564, DateTimeKind.Local).AddTicks(9641), 51, new DateTime(2022, 4, 27, 2, 59, 29, 651, DateTimeKind.Local).AddTicks(7753), new DateTime(2020, 11, 7, 23, 35, 17, 613, DateTimeKind.Local).AddTicks(137), 3, 4, "Dolores sunt voluptatum dolorem dolores quisquam cumque aut et suscipit.\nPariatur quia totam quis quos.\nFugiat nulla neque deserunt et nesciunt quibusdam consequuntur natus.\nEveniet ducimus et rem in dolore autem.\nFacere nisi a blanditiis maxime minima quia sed.\nTenetur est recusandae ratione est cumque fuga." },
                    { 196, new DateTime(2021, 5, 1, 19, 30, 48, 861, DateTimeKind.Local).AddTicks(3087), 97, new DateTime(2021, 12, 14, 15, 43, 50, 551, DateTimeKind.Local).AddTicks(9900), new DateTime(2021, 6, 24, 13, 55, 43, 286, DateTimeKind.Local).AddTicks(8712), 2, 4, "Et eius culpa beatae omnis laboriosam sunt." },
                    { 128, new DateTime(2021, 6, 29, 16, 25, 46, 390, DateTimeKind.Local).AddTicks(5207), 117, new DateTime(2021, 10, 26, 0, 4, 6, 502, DateTimeKind.Local).AddTicks(2483), new DateTime(2020, 10, 5, 0, 9, 7, 820, DateTimeKind.Local).AddTicks(7495), 5, 16, "Tempore et quis quia." },
                    { 129, new DateTime(2020, 8, 13, 23, 34, 34, 75, DateTimeKind.Local).AddTicks(9851), 63, new DateTime(2022, 4, 4, 1, 21, 58, 468, DateTimeKind.Local).AddTicks(4762), new DateTime(2020, 10, 17, 12, 55, 40, 874, DateTimeKind.Local).AddTicks(1142), 3, 16, "Quae enim impedit ut et ipsum dolorem." },
                    { 134, new DateTime(2020, 8, 14, 8, 53, 31, 777, DateTimeKind.Local).AddTicks(1148), 132, new DateTime(2021, 9, 11, 16, 51, 12, 153, DateTimeKind.Local).AddTicks(7223), new DateTime(2021, 7, 22, 18, 2, 53, 181, DateTimeKind.Local).AddTicks(3697), 2, 16, "libero" },
                    { 189, new DateTime(2020, 9, 28, 12, 4, 26, 374, DateTimeKind.Local).AddTicks(5721), 83, new DateTime(2022, 7, 29, 2, 28, 8, 327, DateTimeKind.Local).AddTicks(2306), new DateTime(2021, 7, 21, 8, 19, 1, 740, DateTimeKind.Local).AddTicks(9461), 5, 16, "Voluptatem dicta dolorem itaque quas minima accusantium. Rem ullam qui voluptatem tenetur assumenda et perferendis. Totam voluptatibus aperiam nulla dolore impedit omnis id vel." },
                    { 20, new DateTime(2020, 8, 22, 5, 30, 31, 858, DateTimeKind.Local).AddTicks(2121), 112, new DateTime(2022, 1, 2, 17, 15, 21, 157, DateTimeKind.Local).AddTicks(8844), new DateTime(2021, 5, 13, 23, 52, 47, 692, DateTimeKind.Local).AddTicks(5204), 4, 1, "laborum" },
                    { 27, new DateTime(2020, 9, 20, 17, 19, 30, 708, DateTimeKind.Local).AddTicks(7984), 108, new DateTime(2022, 7, 31, 11, 28, 36, 246, DateTimeKind.Local).AddTicks(9316), new DateTime(2020, 9, 19, 3, 1, 33, 3, DateTimeKind.Local).AddTicks(9671), 3, 1, "Eligendi qui ut sint eos commodi fugit voluptatum distinctio id." },
                    { 117, new DateTime(2020, 10, 10, 16, 36, 34, 757, DateTimeKind.Local).AddTicks(2929), 143, new DateTime(2022, 6, 27, 3, 20, 1, 79, DateTimeKind.Local).AddTicks(6762), new DateTime(2021, 2, 23, 0, 37, 51, 915, DateTimeKind.Local).AddTicks(3023), 2, 1, "Quos nam et accusamus tenetur qui voluptatum ut exercitationem. Molestiae sed molestiae expedita. Officiis placeat hic sequi fuga omnis quam ut amet ratione. Culpa quod cum deleniti cupiditate. Dolor aperiam ut." },
                    { 19, new DateTime(2021, 3, 7, 19, 23, 1, 757, DateTimeKind.Local).AddTicks(3200), 23, new DateTime(2021, 8, 21, 23, 3, 30, 156, DateTimeKind.Local).AddTicks(9524), new DateTime(2021, 3, 18, 2, 38, 9, 660, DateTimeKind.Local).AddTicks(9865), 1, 61, "Vitae ipsam similique deserunt." },
                    { 22, new DateTime(2020, 12, 8, 18, 56, 34, 193, DateTimeKind.Local).AddTicks(7973), 109, new DateTime(2022, 3, 1, 9, 57, 4, 415, DateTimeKind.Local).AddTicks(7909), new DateTime(2020, 12, 28, 22, 40, 35, 37, DateTimeKind.Local).AddTicks(4182), 1, 61, "Itaque nihil ut ipsam.\nDeleniti nobis laboriosam.\nPossimus sit cupiditate et excepturi et mollitia officia." },
                    { 52, new DateTime(2021, 6, 2, 19, 13, 24, 616, DateTimeKind.Local).AddTicks(6232), 108, new DateTime(2022, 5, 31, 5, 0, 43, 461, DateTimeKind.Local).AddTicks(3541), new DateTime(2021, 3, 14, 6, 31, 53, 183, DateTimeKind.Local).AddTicks(2865), 2, 61, "Accusantium minus velit voluptas et illo qui doloribus. Dolor ex ducimus consectetur officiis possimus dolore et. Sed eius et voluptas. Numquam aliquam aut illum expedita eos enim corporis architecto. Quas velit fugiat perspiciatis provident aut asperiores ut magni." },
                    { 132, new DateTime(2020, 9, 21, 8, 59, 35, 365, DateTimeKind.Local).AddTicks(8744), 61, new DateTime(2021, 9, 4, 9, 20, 5, 349, DateTimeKind.Local).AddTicks(7123), new DateTime(2020, 10, 27, 5, 44, 47, 950, DateTimeKind.Local).AddTicks(4073), 4, 61, "Nihil repudiandae numquam. Maiores quia eveniet molestiae ut quam enim. Vel beatae quod. Minus esse sapiente." },
                    { 135, new DateTime(2021, 1, 15, 22, 27, 34, 319, DateTimeKind.Local).AddTicks(8016), 88, new DateTime(2021, 11, 14, 2, 54, 7, 944, DateTimeKind.Local).AddTicks(262), new DateTime(2021, 6, 5, 19, 7, 11, 80, DateTimeKind.Local).AddTicks(9698), 2, 53, "Laborum aut itaque ipsa. Error sint totam dolor provident ut ipsum. Voluptas perspiciatis molestias eligendi est autem odit." },
                    { 115, new DateTime(2020, 11, 6, 0, 10, 52, 673, DateTimeKind.Local).AddTicks(2945), 135, new DateTime(2021, 12, 9, 20, 39, 7, 253, DateTimeKind.Local).AddTicks(502), new DateTime(2021, 8, 1, 0, 17, 34, 774, DateTimeKind.Local).AddTicks(4756), 3, 53, "Vitae omnis necessitatibus sit eum." },
                    { 39, new DateTime(2021, 5, 28, 22, 44, 5, 739, DateTimeKind.Local).AddTicks(4557), 33, new DateTime(2021, 12, 4, 4, 26, 55, 48, DateTimeKind.Local).AddTicks(8215), new DateTime(2020, 10, 22, 20, 17, 39, 520, DateTimeKind.Local).AddTicks(6054), 2, 53, "Aperiam mollitia perspiciatis ipsum labore vel dignissimos qui enim enim.\nRepudiandae illo voluptates ipsam nihil nesciunt rerum odio inventore dolore." },
                    { 111, new DateTime(2021, 4, 27, 0, 15, 52, 547, DateTimeKind.Local).AddTicks(7063), 31, new DateTime(2021, 10, 30, 15, 7, 9, 472, DateTimeKind.Local).AddTicks(4391), new DateTime(2021, 4, 27, 4, 14, 30, 470, DateTimeKind.Local).AddTicks(6579), 5, 41, "Et porro ipsa molestias quis asperiores quidem omnis non. Sunt earum autem eum maiores ea nemo qui. Temporibus aut qui in deserunt facere aliquam. Explicabo mollitia consequatur. Voluptatem ratione tempora fugit nihil voluptas culpa est deserunt fuga. Velit quas illum necessitatibus est maxime debitis eos." },
                    { 13, new DateTime(2021, 7, 4, 0, 12, 17, 97, DateTimeKind.Local).AddTicks(2912), 123, new DateTime(2022, 2, 13, 12, 5, 16, 988, DateTimeKind.Local).AddTicks(6705), new DateTime(2021, 3, 10, 15, 2, 21, 22, DateTimeKind.Local).AddTicks(5794), 4, 68, "possimus" },
                    { 30, new DateTime(2020, 11, 28, 15, 31, 36, 769, DateTimeKind.Local).AddTicks(8052), 93, new DateTime(2021, 10, 12, 3, 36, 39, 693, DateTimeKind.Local).AddTicks(2314), new DateTime(2021, 4, 15, 7, 50, 11, 694, DateTimeKind.Local).AddTicks(6131), 3, 68, "Dolor sit accusantium esse distinctio eligendi quod aspernatur molestiae. Dolorem impedit sed. Inventore tempora dolorem quia et et." },
                    { 43, new DateTime(2021, 4, 16, 21, 40, 58, 943, DateTimeKind.Local).AddTicks(1111), 88, new DateTime(2022, 8, 2, 8, 30, 12, 374, DateTimeKind.Local).AddTicks(8167), new DateTime(2021, 7, 16, 21, 15, 7, 880, DateTimeKind.Local).AddTicks(8357), 2, 68, "voluptatem" },
                    { 116, new DateTime(2020, 11, 10, 0, 58, 59, 948, DateTimeKind.Local).AddTicks(4201), 76, new DateTime(2021, 10, 5, 17, 36, 28, 232, DateTimeKind.Local).AddTicks(2404), new DateTime(2021, 6, 1, 22, 46, 47, 977, DateTimeKind.Local).AddTicks(388), 2, 68, "Et velit eos est quo non velit quia." },
                    { 145, new DateTime(2021, 5, 7, 12, 1, 17, 921, DateTimeKind.Local).AddTicks(3946), 54, new DateTime(2022, 4, 8, 20, 44, 11, 911, DateTimeKind.Local).AddTicks(6896), new DateTime(2021, 8, 10, 17, 27, 9, 510, DateTimeKind.Local).AddTicks(5898), 2, 68, "Accusantium dolorem nihil ut quidem culpa porro quis.\nSit doloribus et ad quis beatae id animi esse possimus.\nCulpa aliquid accusantium atque totam aperiam pariatur voluptas.\nAt quibusdam repellendus consequatur sit." },
                    { 103, new DateTime(2021, 3, 5, 5, 45, 51, 543, DateTimeKind.Local).AddTicks(5257), 109, new DateTime(2021, 11, 11, 19, 30, 51, 852, DateTimeKind.Local).AddTicks(3284), new DateTime(2020, 9, 6, 0, 5, 0, 969, DateTimeKind.Local).AddTicks(4708), 5, 52, "Rerum similique quia cum quas ut repellendus ipsa et tenetur. Dolor autem at sed et enim neque est. Odio aut ipsam ducimus pariatur. Quia laboriosam sit provident ut aperiam et ducimus. Enim quia laboriosam odit deserunt aut dolore asperiores ipsam. Modi dolore enim doloremque voluptatibus harum adipisci ab similique." },
                    { 173, new DateTime(2021, 2, 8, 1, 28, 1, 488, DateTimeKind.Local).AddTicks(9446), 133, new DateTime(2021, 10, 13, 17, 27, 24, 815, DateTimeKind.Local).AddTicks(6944), new DateTime(2020, 11, 19, 17, 8, 40, 493, DateTimeKind.Local).AddTicks(7282), 2, 52, "molestias" },
                    { 86, new DateTime(2021, 6, 20, 12, 34, 24, 651, DateTimeKind.Local).AddTicks(5352), 143, new DateTime(2022, 7, 24, 3, 9, 42, 972, DateTimeKind.Local).AddTicks(7765), new DateTime(2021, 6, 3, 13, 13, 15, 106, DateTimeKind.Local).AddTicks(9730), 3, 13, "Et inventore tenetur dignissimos perspiciatis molestiae delectus." },
                    { 130, new DateTime(2020, 10, 29, 9, 59, 22, 215, DateTimeKind.Local).AddTicks(3832), 23, new DateTime(2022, 1, 6, 18, 52, 59, 112, DateTimeKind.Local).AddTicks(8328), new DateTime(2020, 10, 16, 2, 17, 25, 229, DateTimeKind.Local).AddTicks(5612), 1, 13, "quia" },
                    { 200, new DateTime(2021, 2, 5, 1, 55, 11, 733, DateTimeKind.Local).AddTicks(6147), 143, new DateTime(2022, 8, 9, 3, 30, 53, 581, DateTimeKind.Local).AddTicks(9782), new DateTime(2021, 7, 30, 9, 55, 59, 614, DateTimeKind.Local).AddTicks(7763), 4, 13, "Magnam fugiat ut reprehenderit enim ut ipsa. Inventore autem cupiditate. Qui eum est." },
                    { 138, new DateTime(2020, 12, 7, 4, 3, 45, 158, DateTimeKind.Local).AddTicks(1737), 57, new DateTime(2022, 6, 18, 1, 13, 34, 489, DateTimeKind.Local).AddTicks(7177), new DateTime(2021, 5, 9, 23, 1, 40, 102, DateTimeKind.Local).AddTicks(633), 5, 49, "Hic voluptatum maiores dolor." },
                    { 61, new DateTime(2021, 3, 30, 8, 31, 53, 557, DateTimeKind.Local).AddTicks(6182), 62, new DateTime(2021, 11, 30, 12, 26, 30, 570, DateTimeKind.Local).AddTicks(5920), new DateTime(2020, 10, 24, 6, 21, 41, 528, DateTimeKind.Local).AddTicks(7365), 3, 76, "repellat" },
                    { 102, new DateTime(2021, 7, 29, 3, 51, 19, 509, DateTimeKind.Local).AddTicks(6543), 136, new DateTime(2022, 3, 7, 19, 19, 14, 992, DateTimeKind.Local).AddTicks(1672), new DateTime(2021, 6, 13, 22, 58, 10, 582, DateTimeKind.Local).AddTicks(5212), 2, 76, "Quaerat consequatur soluta voluptas est quo. Sit est natus saepe nostrum. Ut in in." },
                    { 141, new DateTime(2021, 2, 21, 16, 12, 44, 198, DateTimeKind.Local).AddTicks(9804), 91, new DateTime(2022, 1, 2, 1, 28, 45, 427, DateTimeKind.Local).AddTicks(7027), new DateTime(2021, 4, 20, 2, 40, 48, 604, DateTimeKind.Local).AddTicks(3750), 3, 76, "Eveniet voluptate quod distinctio beatae et ex.\nAut omnis similique corrupti sed consequuntur sequi assumenda quas.\nQuia facere totam fuga officiis ducimus quaerat ut illum.\nEst voluptatem a.\nId omnis iste." },
                    { 104, new DateTime(2021, 2, 5, 22, 19, 18, 937, DateTimeKind.Local).AddTicks(724), 100, new DateTime(2022, 6, 12, 5, 59, 27, 707, DateTimeKind.Local).AddTicks(7964), new DateTime(2021, 5, 1, 16, 39, 58, 604, DateTimeKind.Local).AddTicks(5317), 3, 33, "Sed illo animi ipsam nisi quasi ut maxime. Inventore magni eos consectetur sit alias cum et et saepe. Ut eveniet impedit voluptatibus exercitationem. Pariatur sit ducimus." },
                    { 11, new DateTime(2020, 12, 26, 11, 29, 21, 440, DateTimeKind.Local).AddTicks(2050), 112, new DateTime(2022, 1, 26, 15, 16, 44, 626, DateTimeKind.Local).AddTicks(408), new DateTime(2021, 5, 11, 10, 7, 37, 332, DateTimeKind.Local).AddTicks(5466), 3, 26, "Dolores omnis molestiae eos saepe at. Ut omnis quo perferendis qui atque. Quibusdam omnis velit." },
                    { 48, new DateTime(2021, 5, 29, 10, 41, 14, 373, DateTimeKind.Local).AddTicks(1410), 137, new DateTime(2021, 11, 8, 10, 32, 3, 754, DateTimeKind.Local).AddTicks(831), new DateTime(2021, 4, 25, 6, 47, 52, 100, DateTimeKind.Local).AddTicks(3834), 2, 26, "qui" },
                    { 80, new DateTime(2021, 2, 8, 14, 0, 57, 682, DateTimeKind.Local).AddTicks(9290), 39, new DateTime(2021, 9, 29, 19, 18, 22, 47, DateTimeKind.Local).AddTicks(9200), new DateTime(2021, 2, 24, 8, 34, 17, 701, DateTimeKind.Local).AddTicks(421), 4, 26, "Vel quisquam voluptas doloremque maxime sed necessitatibus aut." },
                    { 82, new DateTime(2020, 12, 3, 9, 49, 36, 668, DateTimeKind.Local).AddTicks(9913), 100, new DateTime(2021, 11, 8, 6, 34, 47, 760, DateTimeKind.Local).AddTicks(1519), new DateTime(2021, 6, 29, 5, 9, 11, 883, DateTimeKind.Local).AddTicks(7205), 5, 26, "Optio aut labore animi aliquid est." },
                    { 100, new DateTime(2021, 7, 3, 7, 9, 45, 565, DateTimeKind.Local).AddTicks(3937), 113, new DateTime(2022, 1, 7, 11, 49, 39, 466, DateTimeKind.Local).AddTicks(8309), new DateTime(2020, 10, 6, 3, 27, 40, 899, DateTimeKind.Local).AddTicks(5828), 5, 26, "Dolore eligendi eveniet eligendi numquam impedit iusto aspernatur. Perspiciatis soluta exercitationem mollitia nemo quas. Voluptatem commodi quidem. Animi amet minus nostrum cum. Est excepturi debitis." },
                    { 90, new DateTime(2021, 6, 30, 21, 32, 4, 126, DateTimeKind.Local).AddTicks(6204), 139, new DateTime(2021, 9, 19, 23, 46, 35, 919, DateTimeKind.Local).AddTicks(161), new DateTime(2021, 6, 12, 22, 34, 8, 107, DateTimeKind.Local).AddTicks(693), 1, 41, "Saepe debitis ea ipsam expedita laudantium maiores est earum." },
                    { 133, new DateTime(2021, 6, 12, 7, 39, 43, 736, DateTimeKind.Local).AddTicks(3840), 39, new DateTime(2022, 3, 26, 2, 32, 1, 644, DateTimeKind.Local).AddTicks(6459), new DateTime(2021, 5, 22, 6, 24, 54, 982, DateTimeKind.Local).AddTicks(6993), 1, 26, "Labore quos at accusantium.\nCorporis qui omnis accusamus.\nEt cumque quas quisquam aut id accusamus.\nDolorum alias rerum saepe animi est fugiat.\nVoluptas facilis molestias ut rerum veniam ut.\nConsectetur maxime similique veniam pariatur beatae dolores consectetur." },
                    { 171, new DateTime(2020, 12, 17, 1, 47, 33, 823, DateTimeKind.Local).AddTicks(1774), 150, new DateTime(2022, 2, 6, 18, 15, 52, 955, DateTimeKind.Local).AddTicks(3189), new DateTime(2021, 1, 10, 23, 13, 12, 315, DateTimeKind.Local).AddTicks(5750), 2, 81, "et" },
                    { 166, new DateTime(2021, 3, 9, 6, 24, 44, 707, DateTimeKind.Local).AddTicks(5606), 129, new DateTime(2022, 6, 22, 22, 14, 23, 750, DateTimeKind.Local).AddTicks(1733), new DateTime(2021, 4, 12, 13, 31, 52, 273, DateTimeKind.Local).AddTicks(7398), 1, 81, "Delectus ut sunt.\nNulla eos saepe.\nQui amet ut iure fugit veritatis omnis assumenda.\nIure excepturi minus iure repudiandae fuga itaque." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 110, new DateTime(2021, 7, 20, 0, 38, 56, 945, DateTimeKind.Local).AddTicks(9860), 75, new DateTime(2022, 6, 24, 9, 12, 4, 288, DateTimeKind.Local).AddTicks(4468), new DateTime(2021, 1, 13, 19, 22, 25, 349, DateTimeKind.Local).AddTicks(917), 1, 39, "Magni dolor reprehenderit fugiat." },
                    { 123, new DateTime(2021, 6, 23, 16, 23, 42, 228, DateTimeKind.Local).AddTicks(6204), 79, new DateTime(2022, 3, 26, 14, 30, 40, 649, DateTimeKind.Local).AddTicks(9551), new DateTime(2021, 5, 31, 7, 20, 38, 241, DateTimeKind.Local).AddTicks(4342), 4, 39, "Voluptatem dolorum architecto vel natus illum inventore earum natus dolor." },
                    { 124, new DateTime(2021, 6, 2, 22, 11, 42, 298, DateTimeKind.Local).AddTicks(5333), 82, new DateTime(2022, 3, 22, 9, 12, 29, 445, DateTimeKind.Local).AddTicks(2454), new DateTime(2021, 8, 8, 13, 15, 52, 436, DateTimeKind.Local).AddTicks(5323), 4, 39, "Vel quia dolorem ut asperiores laudantium." },
                    { 127, new DateTime(2020, 9, 8, 22, 35, 57, 27, DateTimeKind.Local).AddTicks(1560), 104, new DateTime(2021, 9, 14, 5, 46, 12, 656, DateTimeKind.Local).AddTicks(4083), new DateTime(2020, 12, 1, 10, 41, 23, 120, DateTimeKind.Local).AddTicks(9643), 1, 39, "Modi perferendis nisi in in atque corporis earum.\nQuae atque repudiandae aut placeat.\nSunt enim ipsam aut qui.\nAb amet ut culpa possimus veritatis perferendis voluptatum quaerat." },
                    { 168, new DateTime(2020, 10, 22, 7, 19, 5, 900, DateTimeKind.Local).AddTicks(9874), 107, new DateTime(2021, 9, 16, 2, 10, 59, 471, DateTimeKind.Local).AddTicks(2598), new DateTime(2021, 2, 17, 12, 56, 51, 92, DateTimeKind.Local).AddTicks(5885), 1, 39, "pariatur" },
                    { 29, new DateTime(2021, 5, 5, 20, 32, 19, 113, DateTimeKind.Local).AddTicks(2452), 59, new DateTime(2022, 3, 30, 15, 18, 13, 588, DateTimeKind.Local).AddTicks(9053), new DateTime(2021, 6, 3, 8, 51, 35, 917, DateTimeKind.Local).AddTicks(2935), 3, 2, "Occaecati omnis quas incidunt ut. Natus ad eos. Ipsa enim iste." },
                    { 46, new DateTime(2021, 8, 4, 7, 33, 11, 325, DateTimeKind.Local).AddTicks(2963), 96, new DateTime(2021, 11, 30, 17, 54, 13, 838, DateTimeKind.Local).AddTicks(1102), new DateTime(2020, 12, 11, 12, 9, 57, 736, DateTimeKind.Local).AddTicks(6206), 4, 2, "Dolor accusamus id voluptatibus natus voluptates deleniti quo.\nSoluta voluptatem consequatur minima aut facere consequatur.\nSuscipit laboriosam est est est non ut vero.\nExcepturi qui voluptatem." },
                    { 60, new DateTime(2020, 11, 10, 4, 47, 25, 398, DateTimeKind.Local).AddTicks(7079), 47, new DateTime(2021, 9, 22, 8, 40, 19, 708, DateTimeKind.Local).AddTicks(2759), new DateTime(2020, 10, 16, 12, 46, 14, 891, DateTimeKind.Local).AddTicks(8574), 3, 2, "Quasi cupiditate debitis itaque sint sapiente culpa illo labore.\nTenetur tempore possimus voluptatem pariatur commodi excepturi ut.\nItaque quis quo ab enim.\nReiciendis qui nihil magni deleniti dignissimos.\nCorporis quia et aut cumque.\nRerum asperiores et." },
                    { 146, new DateTime(2021, 5, 23, 4, 59, 5, 612, DateTimeKind.Local).AddTicks(9463), 39, new DateTime(2021, 9, 3, 23, 21, 59, 854, DateTimeKind.Local).AddTicks(8933), new DateTime(2021, 5, 29, 21, 18, 18, 339, DateTimeKind.Local).AddTicks(8827), 1, 2, "Iusto consequuntur amet dicta rerum eos suscipit vitae.\nEos debitis dicta.\nEos itaque voluptas id minus officiis tenetur vitae." },
                    { 194, new DateTime(2020, 9, 28, 0, 53, 45, 324, DateTimeKind.Local).AddTicks(5694), 47, new DateTime(2021, 8, 24, 23, 4, 19, 583, DateTimeKind.Local).AddTicks(5989), new DateTime(2020, 8, 26, 2, 23, 50, 463, DateTimeKind.Local).AddTicks(6735), 3, 8, "Fugit est occaecati deleniti facilis dolores voluptates." },
                    { 24, new DateTime(2021, 1, 2, 4, 12, 54, 658, DateTimeKind.Local).AddTicks(8236), 100, new DateTime(2022, 5, 2, 21, 16, 57, 784, DateTimeKind.Local).AddTicks(8512), new DateTime(2021, 1, 3, 3, 19, 55, 191, DateTimeKind.Local).AddTicks(3790), 4, 6, "Accusamus commodi qui non.\nMolestiae sint aut blanditiis voluptatem in quos laborum.\nMinima nobis reiciendis eum inventore.\nIn quasi officia sint ea amet recusandae impedit." },
                    { 47, new DateTime(2021, 5, 5, 12, 25, 49, 889, DateTimeKind.Local).AddTicks(4055), 40, new DateTime(2022, 3, 8, 9, 10, 15, 526, DateTimeKind.Local).AddTicks(6184), new DateTime(2020, 10, 30, 4, 8, 1, 234, DateTimeKind.Local).AddTicks(224), 1, 6, "Unde assumenda quas et error.\nVoluptatem et voluptas enim corrupti.\nImpedit ut enim quidem asperiores dolores laboriosam nihil consequuntur.\nQui vitae qui non aut quisquam.\nDolore iure accusantium cum." },
                    { 91, new DateTime(2021, 2, 1, 6, 52, 49, 383, DateTimeKind.Local).AddTicks(7314), 110, new DateTime(2022, 6, 22, 14, 5, 11, 989, DateTimeKind.Local).AddTicks(2815), new DateTime(2021, 3, 14, 9, 35, 50, 956, DateTimeKind.Local).AddTicks(4321), 4, 6, "Debitis doloribus ipsa consequatur est debitis eveniet. Qui rerum quae qui excepturi quia sit ut aut. Sed nostrum qui ullam rem. Reprehenderit vitae similique occaecati. Voluptas est nam possimus cupiditate illo suscipit consequatur dicta odit." },
                    { 139, new DateTime(2021, 1, 7, 23, 4, 30, 854, DateTimeKind.Local).AddTicks(6908), 34, new DateTime(2022, 5, 4, 22, 10, 25, 222, DateTimeKind.Local).AddTicks(5692), new DateTime(2021, 1, 3, 18, 5, 56, 87, DateTimeKind.Local).AddTicks(5627), 2, 6, "Illo sed quibusdam aut nulla nulla. Unde vero modi vitae distinctio dolores quas laudantium quasi enim. Quo ab quod." },
                    { 140, new DateTime(2021, 6, 28, 21, 9, 7, 175, DateTimeKind.Local).AddTicks(3589), 39, new DateTime(2021, 10, 20, 21, 23, 43, 289, DateTimeKind.Local).AddTicks(7821), new DateTime(2021, 5, 3, 22, 5, 9, 711, DateTimeKind.Local).AddTicks(169), 3, 6, "Aperiam dolorem iste unde repellendus est ut. Dolorum ut iure distinctio explicabo magnam. Quia perspiciatis facere eum nemo blanditiis debitis illo illo est. Recusandae quasi repellendus placeat occaecati consequuntur." },
                    { 184, new DateTime(2021, 2, 4, 6, 45, 59, 399, DateTimeKind.Local).AddTicks(9207), 150, new DateTime(2022, 1, 29, 16, 34, 7, 741, DateTimeKind.Local).AddTicks(1041), new DateTime(2021, 1, 18, 19, 9, 53, 764, DateTimeKind.Local).AddTicks(7248), 4, 6, "Excepturi velit consequuntur dolorum. Laborum aut aut aut. Et dolores adipisci iste est dolorem et voluptate pariatur. Laboriosam veniam dolores beatae quae et accusantium. Velit laboriosam dolorem. Voluptatem ea et cupiditate saepe." },
                    { 188, new DateTime(2021, 7, 20, 3, 34, 49, 876, DateTimeKind.Local).AddTicks(9308), 2, new DateTime(2021, 10, 4, 18, 1, 29, 92, DateTimeKind.Local).AddTicks(3172), new DateTime(2021, 3, 28, 8, 30, 37, 883, DateTimeKind.Local).AddTicks(7933), 2, 6, "ipsum" },
                    { 197, new DateTime(2020, 8, 14, 20, 52, 26, 923, DateTimeKind.Local).AddTicks(965), 8, new DateTime(2021, 8, 20, 23, 15, 21, 534, DateTimeKind.Local).AddTicks(3301), new DateTime(2021, 7, 9, 23, 15, 11, 949, DateTimeKind.Local).AddTicks(7499), 1, 6, "Laudantium facere dolorem voluptates rem debitis tempora corrupti illo est. Voluptatum placeat velit sed. Libero incidunt et quaerat veritatis inventore magni sed reprehenderit facere. Aut pariatur accusantium assumenda. Iusto vel debitis rem fugiat sed et maiores." },
                    { 154, new DateTime(2020, 10, 9, 7, 21, 52, 971, DateTimeKind.Local).AddTicks(9644), 55, new DateTime(2022, 3, 28, 21, 27, 33, 894, DateTimeKind.Local).AddTicks(1150), new DateTime(2021, 2, 3, 1, 5, 42, 401, DateTimeKind.Local).AddTicks(8034), 4, 14, "Quia aut et amet eos minus id.\nVoluptas provident voluptatem fugiat vel aut aut rem saepe qui." },
                    { 190, new DateTime(2021, 4, 11, 9, 52, 31, 196, DateTimeKind.Local).AddTicks(6303), 119, new DateTime(2022, 1, 20, 15, 4, 51, 464, DateTimeKind.Local).AddTicks(2159), new DateTime(2021, 3, 10, 5, 34, 53, 591, DateTimeKind.Local).AddTicks(6330), 4, 14, "ipsa" },
                    { 16, new DateTime(2020, 10, 25, 14, 2, 56, 853, DateTimeKind.Local).AddTicks(2303), 20, new DateTime(2021, 10, 5, 14, 7, 50, 625, DateTimeKind.Local).AddTicks(9315), new DateTime(2020, 9, 15, 0, 14, 56, 366, DateTimeKind.Local).AddTicks(908), 2, 81, "veniam" },
                    { 167, new DateTime(2021, 1, 10, 15, 40, 3, 391, DateTimeKind.Local).AddTicks(9504), 104, new DateTime(2022, 3, 26, 16, 24, 11, 597, DateTimeKind.Local).AddTicks(8690), new DateTime(2020, 12, 8, 22, 15, 54, 120, DateTimeKind.Local).AddTicks(1493), 1, 81, "Porro nemo perspiciatis ut hic quo saepe eaque. Dolorem sed sunt dolorum at voluptas. Eum inventore eaque dolorem. Qui ab quisquam sequi nam excepturi alias doloremque. Sit corporis occaecati distinctio qui possimus incidunt nihil." },
                    { 147, new DateTime(2021, 6, 27, 9, 24, 2, 30, DateTimeKind.Local).AddTicks(2825), 10, new DateTime(2022, 6, 24, 14, 26, 41, 361, DateTimeKind.Local).AddTicks(3289), new DateTime(2020, 10, 15, 1, 5, 30, 967, DateTimeKind.Local).AddTicks(2035), 5, 26, "Praesentium doloremque ullam id deserunt ea veniam. Sapiente nihil asperiores est porro et consequuntur non officia et. Mollitia exercitationem similique possimus voluptas nam numquam et." },
                    { 4, new DateTime(2021, 7, 14, 6, 48, 31, 230, DateTimeKind.Local).AddTicks(8648), 40, new DateTime(2021, 10, 16, 18, 47, 30, 779, DateTimeKind.Local).AddTicks(9191), new DateTime(2021, 8, 3, 21, 31, 50, 399, DateTimeKind.Local).AddTicks(8692), 1, 18, "Dignissimos eos non a expedita rerum eligendi sint.\nQuisquam facilis placeat vitae.\nReiciendis maxime doloremque tempora.\nTemporibus aspernatur eveniet nostrum autem." },
                    { 41, new DateTime(2021, 3, 16, 0, 25, 28, 911, DateTimeKind.Local).AddTicks(2249), 99, new DateTime(2022, 6, 20, 3, 52, 4, 588, DateTimeKind.Local).AddTicks(4375), new DateTime(2020, 9, 1, 19, 38, 37, 70, DateTimeKind.Local).AddTicks(3589), 4, 18, "Sit velit aliquid quasi." },
                    { 136, new DateTime(2021, 1, 27, 9, 15, 36, 128, DateTimeKind.Local).AddTicks(5840), 93, new DateTime(2022, 3, 18, 6, 14, 36, 926, DateTimeKind.Local).AddTicks(3691), new DateTime(2021, 3, 28, 5, 38, 5, 67, DateTimeKind.Local).AddTicks(2035), 1, 32, "Iusto nulla at odio sunt. Odit iste voluptatem facilis. Aut autem id sed temporibus dolores voluptate exercitationem." },
                    { 23, new DateTime(2020, 10, 12, 15, 46, 13, 462, DateTimeKind.Local).AddTicks(9112), 109, new DateTime(2022, 8, 2, 11, 7, 7, 781, DateTimeKind.Local).AddTicks(3365), new DateTime(2021, 1, 25, 3, 28, 0, 658, DateTimeKind.Local).AddTicks(4802), 1, 7, "tenetur" },
                    { 89, new DateTime(2020, 8, 23, 21, 10, 30, 187, DateTimeKind.Local).AddTicks(4131), 51, new DateTime(2022, 2, 3, 20, 22, 17, 841, DateTimeKind.Local).AddTicks(4865), new DateTime(2020, 12, 22, 8, 9, 52, 405, DateTimeKind.Local).AddTicks(3551), 5, 7, "Qui aut est cupiditate facilis optio cupiditate non sint et.\nMolestias facere accusamus.\nEarum id et omnis.\nNon sit sed minus fuga nulla." },
                    { 114, new DateTime(2020, 10, 4, 23, 38, 58, 748, DateTimeKind.Local).AddTicks(9988), 68, new DateTime(2022, 2, 6, 13, 1, 53, 299, DateTimeKind.Local).AddTicks(5121), new DateTime(2021, 1, 18, 11, 26, 30, 400, DateTimeKind.Local).AddTicks(4750), 5, 7, "Saepe praesentium non voluptas dolores corrupti quia quos." },
                    { 158, new DateTime(2021, 2, 27, 7, 43, 3, 561, DateTimeKind.Local).AddTicks(7805), 63, new DateTime(2021, 8, 30, 7, 46, 41, 653, DateTimeKind.Local).AddTicks(6210), new DateTime(2020, 11, 30, 0, 6, 36, 20, DateTimeKind.Local).AddTicks(2392), 1, 7, "In error ab numquam quia. Voluptate veritatis exercitationem ipsam voluptas iste id voluptate fuga non. Nulla aperiam aliquid perspiciatis mollitia laboriosam quia. Voluptate consequatur distinctio incidunt. Esse at exercitationem et quam maxime quisquam quia deserunt temporibus." },
                    { 148, new DateTime(2021, 6, 29, 19, 23, 18, 767, DateTimeKind.Local).AddTicks(5465), 91, new DateTime(2022, 4, 2, 17, 1, 54, 718, DateTimeKind.Local).AddTicks(8549), new DateTime(2021, 7, 8, 8, 43, 8, 162, DateTimeKind.Local).AddTicks(319), 1, 74, "Repellendus architecto unde in atque distinctio assumenda ipsum sapiente.\nQuas veniam recusandae sit et.\nIncidunt facilis modi necessitatibus.\nAut itaque autem odio sequi." },
                    { 6, new DateTime(2021, 1, 16, 1, 34, 53, 230, DateTimeKind.Local).AddTicks(5180), 85, new DateTime(2021, 8, 16, 13, 35, 44, 529, DateTimeKind.Local).AddTicks(4791), new DateTime(2020, 10, 29, 8, 35, 19, 174, DateTimeKind.Local).AddTicks(6951), 3, 44, "Illum in voluptatum excepturi eum. Et optio perspiciatis doloremque dignissimos ut. Natus unde sunt quo debitis harum voluptas nihil. Quia nihil et voluptatum et molestias sit. Est eum aliquid. Minima dolores vel eos optio iste fugit." },
                    { 53, new DateTime(2020, 11, 4, 17, 39, 10, 86, DateTimeKind.Local).AddTicks(2735), 60, new DateTime(2022, 5, 31, 19, 56, 26, 222, DateTimeKind.Local).AddTicks(2156), new DateTime(2021, 5, 22, 21, 48, 14, 719, DateTimeKind.Local).AddTicks(4451), 4, 44, "Beatae ad quam dolorem cumque officiis voluptatibus. Consequatur ut dolorem consequuntur esse deleniti veniam. Est praesentium et cumque aspernatur nesciunt ut accusamus. Magni dignissimos esse sed labore rem quisquam autem." },
                    { 120, new DateTime(2021, 5, 21, 20, 47, 35, 370, DateTimeKind.Local).AddTicks(6648), 102, new DateTime(2021, 11, 26, 18, 30, 13, 523, DateTimeKind.Local).AddTicks(4761), new DateTime(2021, 5, 4, 17, 27, 42, 117, DateTimeKind.Local).AddTicks(2265), 4, 44, "Quam qui enim ratione voluptate. Alias eos ut enim alias ipsum quam quia alias ipsa. Quae sit ut labore eos non enim. Temporibus voluptatem quia velit. Saepe id adipisci qui omnis non incidunt perferendis." },
                    { 143, new DateTime(2021, 1, 28, 22, 41, 21, 77, DateTimeKind.Local).AddTicks(975), 85, new DateTime(2021, 12, 16, 3, 8, 10, 385, DateTimeKind.Local).AddTicks(2844), new DateTime(2020, 9, 24, 13, 26, 10, 421, DateTimeKind.Local).AddTicks(9956), 3, 44, "Ut nobis nostrum ipsum beatae mollitia." },
                    { 144, new DateTime(2021, 4, 1, 17, 51, 15, 554, DateTimeKind.Local).AddTicks(4896), 142, new DateTime(2021, 10, 31, 7, 47, 53, 446, DateTimeKind.Local).AddTicks(4329), new DateTime(2021, 6, 9, 20, 54, 33, 970, DateTimeKind.Local).AddTicks(774), 3, 44, "aliquam" },
                    { 181, new DateTime(2020, 11, 28, 0, 53, 11, 176, DateTimeKind.Local).AddTicks(9464), 70, new DateTime(2021, 12, 18, 16, 10, 59, 182, DateTimeKind.Local).AddTicks(460), new DateTime(2021, 7, 13, 2, 54, 27, 436, DateTimeKind.Local).AddTicks(6607), 1, 44, "Distinctio perferendis quis voluptate id optio sit.\nVoluptas consequuntur molestiae ipsam omnis et est neque qui." },
                    { 57, new DateTime(2020, 8, 16, 8, 40, 2, 425, DateTimeKind.Local).AddTicks(5767), 109, new DateTime(2022, 6, 4, 22, 30, 55, 536, DateTimeKind.Local).AddTicks(6501), new DateTime(2021, 7, 9, 23, 58, 2, 160, DateTimeKind.Local).AddTicks(8867), 3, 40, "qui" },
                    { 1, new DateTime(2021, 7, 31, 7, 26, 23, 652, DateTimeKind.Local).AddTicks(8568), 58, new DateTime(2022, 4, 22, 1, 22, 9, 387, DateTimeKind.Local).AddTicks(7803), new DateTime(2021, 8, 10, 2, 32, 45, 867, DateTimeKind.Local).AddTicks(8331), 2, 47, "Mollitia in ducimus omnis voluptatem libero voluptatem. Eos est et maiores deleniti ab aliquam quidem iure et. Molestias ex odit dignissimos explicabo aperiam. Odio qui dolore animi ea sunt quidem reiciendis minus." },
                    { 34, new DateTime(2020, 10, 1, 16, 22, 0, 133, DateTimeKind.Local).AddTicks(9424), 140, new DateTime(2021, 9, 21, 16, 25, 40, 945, DateTimeKind.Local).AddTicks(598), new DateTime(2020, 8, 27, 19, 59, 31, 547, DateTimeKind.Local).AddTicks(3676), 4, 47, "corrupti" },
                    { 67, new DateTime(2020, 12, 10, 8, 57, 17, 981, DateTimeKind.Local).AddTicks(175), 71, new DateTime(2022, 5, 27, 20, 42, 45, 940, DateTimeKind.Local).AddTicks(1062), new DateTime(2021, 4, 23, 18, 41, 2, 140, DateTimeKind.Local).AddTicks(9729), 3, 47, "Eum dolorem et suscipit neque sint ipsa eius illum. Exercitationem iste labore temporibus amet accusantium ducimus voluptatibus suscipit. Quia at animi. Voluptatem exercitationem aut consectetur sit omnis voluptatem quod non necessitatibus. Nobis sit cum. Saepe beatae dolores." },
                    { 73, new DateTime(2020, 9, 19, 17, 20, 2, 897, DateTimeKind.Local).AddTicks(3353), 129, new DateTime(2022, 5, 3, 21, 50, 35, 725, DateTimeKind.Local).AddTicks(9355), new DateTime(2020, 11, 3, 7, 27, 22, 150, DateTimeKind.Local).AddTicks(5545), 1, 47, "Fugit porro sapiente est." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 84, new DateTime(2020, 9, 21, 19, 31, 24, 333, DateTimeKind.Local).AddTicks(7104), 44, new DateTime(2022, 1, 10, 21, 52, 57, 232, DateTimeKind.Local).AddTicks(4522), new DateTime(2021, 5, 12, 5, 21, 8, 903, DateTimeKind.Local).AddTicks(6604), 4, 47, "Ad dolorem non ipsa consequatur voluptatem debitis. Corrupti ad autem consequuntur. Saepe ipsum hic ratione sit dolores sit earum quis. In animi laudantium laboriosam repudiandae voluptatibus ullam voluptas voluptas." },
                    { 101, new DateTime(2021, 7, 17, 7, 29, 53, 270, DateTimeKind.Local).AddTicks(8955), 38, new DateTime(2022, 6, 17, 22, 1, 15, 250, DateTimeKind.Local).AddTicks(673), new DateTime(2021, 1, 11, 2, 44, 7, 605, DateTimeKind.Local).AddTicks(478), 2, 47, "Doloribus consequatur earum eum ut officia error id.\nVoluptas quaerat nesciunt quod earum quia.\nConsequuntur veritatis sapiente id sit.\nVoluptatem molestiae eius laboriosam.\nAd perspiciatis non odio eos sed in quis.\nSit est quis ratione qui." },
                    { 112, new DateTime(2020, 10, 27, 5, 4, 54, 617, DateTimeKind.Local).AddTicks(3754), 23, new DateTime(2022, 5, 30, 1, 59, 7, 414, DateTimeKind.Local).AddTicks(3084), new DateTime(2021, 3, 10, 12, 52, 50, 627, DateTimeKind.Local).AddTicks(7283), 3, 47, "Possimus doloremque necessitatibus ut tenetur error." },
                    { 36, new DateTime(2020, 9, 3, 20, 55, 32, 482, DateTimeKind.Local).AddTicks(5681), 46, new DateTime(2021, 9, 17, 18, 55, 11, 780, DateTimeKind.Local).AddTicks(9172), new DateTime(2021, 3, 22, 12, 30, 32, 636, DateTimeKind.Local).AddTicks(414), 1, 53, "Autem repellendus doloremque atque enim. Et vel est. Delectus et et rerum molestiae. Dolores quam consequatur provident." },
                    { 49, new DateTime(2021, 7, 31, 4, 24, 7, 389, DateTimeKind.Local).AddTicks(210), 72, new DateTime(2022, 3, 17, 23, 57, 16, 811, DateTimeKind.Local).AddTicks(4057), new DateTime(2021, 4, 7, 18, 43, 18, 439, DateTimeKind.Local).AddTicks(5465), 5, 32, "Alias aperiam culpa iure maiores dolore illo quis nihil quia." },
                    { 35, new DateTime(2020, 10, 18, 17, 44, 30, 518, DateTimeKind.Local).AddTicks(9579), 34, new DateTime(2022, 5, 24, 11, 15, 25, 398, DateTimeKind.Local).AddTicks(9053), new DateTime(2020, 9, 5, 14, 24, 8, 187, DateTimeKind.Local).AddTicks(1016), 1, 32, "Eum officiis numquam.\nAtque officia sed omnis voluptatem nihil iusto cumque eum.\nVoluptas at aut enim et odio.\nCulpa ut in.\nNisi qui dolor sit minus assumenda quae id non est." },
                    { 121, new DateTime(2021, 5, 9, 4, 51, 37, 96, DateTimeKind.Local).AddTicks(9338), 116, new DateTime(2022, 3, 28, 6, 41, 50, 857, DateTimeKind.Local).AddTicks(439), new DateTime(2021, 1, 24, 2, 6, 18, 950, DateTimeKind.Local).AddTicks(3659), 3, 9, "cupiditate" },
                    { 63, new DateTime(2021, 7, 20, 3, 23, 5, 327, DateTimeKind.Local).AddTicks(707), 99, new DateTime(2022, 4, 28, 2, 53, 16, 958, DateTimeKind.Local).AddTicks(8217), new DateTime(2020, 10, 4, 20, 37, 35, 477, DateTimeKind.Local).AddTicks(3746), 5, 9, "Quis iusto veniam debitis distinctio qui sit. Perferendis provident sit itaque a. Iure soluta nihil omnis soluta qui. Ut id quidem et explicabo culpa optio at ab fugiat." },
                    { 56, new DateTime(2020, 8, 15, 16, 52, 9, 272, DateTimeKind.Local).AddTicks(5457), 91, new DateTime(2022, 7, 18, 3, 28, 57, 749, DateTimeKind.Local).AddTicks(8127), new DateTime(2021, 5, 21, 4, 12, 38, 977, DateTimeKind.Local).AddTicks(2363), 2, 18, "Maxime neque voluptatem hic.\nQuis nihil id et dolores quaerat.\nTemporibus a voluptatum modi eum et.\nAut qui et recusandae ipsa eum fugit." },
                    { 69, new DateTime(2021, 7, 11, 2, 48, 13, 32, DateTimeKind.Local).AddTicks(7247), 36, new DateTime(2022, 1, 2, 1, 32, 50, 402, DateTimeKind.Local).AddTicks(6610), new DateTime(2021, 5, 21, 7, 13, 20, 204, DateTimeKind.Local).AddTicks(4297), 1, 18, "Et velit at.\nVoluptatem minus omnis.\nUt tempore quas voluptas est.\nDignissimos hic doloribus dolor exercitationem aut voluptas error unde dolorem." },
                    { 95, new DateTime(2020, 10, 8, 7, 28, 50, 303, DateTimeKind.Local).AddTicks(7849), 82, new DateTime(2021, 11, 5, 0, 26, 20, 459, DateTimeKind.Local).AddTicks(9441), new DateTime(2020, 11, 16, 9, 9, 59, 362, DateTimeKind.Local).AddTicks(4827), 3, 18, "Officia voluptatem vitae modi et autem." },
                    { 131, new DateTime(2021, 8, 11, 3, 3, 50, 573, DateTimeKind.Local).AddTicks(6255), 140, new DateTime(2022, 3, 29, 3, 22, 50, 409, DateTimeKind.Local).AddTicks(3300), new DateTime(2021, 7, 13, 3, 29, 37, 800, DateTimeKind.Local).AddTicks(9233), 1, 18, "rerum" },
                    { 149, new DateTime(2020, 10, 20, 2, 36, 22, 526, DateTimeKind.Local).AddTicks(5057), 21, new DateTime(2021, 10, 14, 7, 20, 24, 916, DateTimeKind.Local).AddTicks(9594), new DateTime(2021, 6, 24, 7, 58, 34, 649, DateTimeKind.Local).AddTicks(2186), 3, 18, "Sint voluptatem eos aut.\nQuibusdam officia consequatur aliquid impedit rerum consectetur dolores.\nVero sequi adipisci laboriosam excepturi in." },
                    { 107, new DateTime(2020, 11, 2, 22, 23, 28, 597, DateTimeKind.Local).AddTicks(301), 86, new DateTime(2021, 10, 6, 11, 54, 4, 22, DateTimeKind.Local).AddTicks(2919), new DateTime(2021, 1, 19, 21, 55, 1, 989, DateTimeKind.Local).AddTicks(2698), 3, 15, "Quisquam provident et perspiciatis aut labore sunt.\nAccusamus voluptas recusandae.\nIn ipsam necessitatibus delectus sed dolorem qui sint omnis.\nSimilique sit sint itaque sed ea fuga a qui aliquid.\nPerspiciatis voluptatum eos non officia aliquam qui." },
                    { 142, new DateTime(2020, 11, 21, 7, 36, 32, 826, DateTimeKind.Local).AddTicks(5987), 10, new DateTime(2021, 8, 21, 6, 27, 5, 84, DateTimeKind.Local).AddTicks(9338), new DateTime(2021, 3, 20, 21, 35, 37, 484, DateTimeKind.Local).AddTicks(6327), 3, 15, "Adipisci tenetur rerum alias voluptatem aperiam atque animi." },
                    { 161, new DateTime(2021, 1, 31, 22, 26, 44, 648, DateTimeKind.Local).AddTicks(8210), 118, new DateTime(2021, 9, 10, 18, 40, 19, 707, DateTimeKind.Local).AddTicks(543), new DateTime(2021, 3, 20, 8, 58, 34, 461, DateTimeKind.Local).AddTicks(7638), 3, 15, "Itaque at commodi voluptatem accusantium." },
                    { 106, new DateTime(2021, 4, 25, 19, 18, 11, 226, DateTimeKind.Local).AddTicks(4699), 45, new DateTime(2022, 5, 22, 12, 11, 24, 288, DateTimeKind.Local).AddTicks(3486), new DateTime(2021, 2, 26, 2, 50, 23, 827, DateTimeKind.Local).AddTicks(1741), 4, 30, "Velit reprehenderit et. Consequatur quidem nisi dolorum. Suscipit modi dolore." },
                    { 137, new DateTime(2020, 10, 10, 3, 12, 9, 581, DateTimeKind.Local).AddTicks(1418), 63, new DateTime(2021, 12, 14, 19, 10, 32, 993, DateTimeKind.Local).AddTicks(8735), new DateTime(2021, 5, 22, 11, 32, 23, 206, DateTimeKind.Local).AddTicks(111), 5, 30, "Ut sed ipsum cum voluptatem fugit nisi est.\nMinus dolores cupiditate iusto hic perspiciatis.\nQuo consequatur omnis.\nQuisquam et nisi rerum deserunt distinctio reiciendis." },
                    { 14, new DateTime(2021, 4, 24, 0, 1, 24, 164, DateTimeKind.Local).AddTicks(5941), 101, new DateTime(2021, 12, 25, 11, 53, 8, 623, DateTimeKind.Local).AddTicks(5937), new DateTime(2021, 6, 4, 12, 46, 32, 537, DateTimeKind.Local).AddTicks(9396), 3, 29, "Quaerat facere et et distinctio totam velit. Est aut nihil similique id placeat inventore et distinctio et. Dolorem et error nemo aut. Autem libero nostrum qui occaecati perferendis molestiae provident. Consequuntur quod minima ea. Fugit voluptatum quod error in." },
                    { 198, new DateTime(2020, 12, 3, 19, 3, 6, 821, DateTimeKind.Local).AddTicks(8403), 131, new DateTime(2021, 8, 12, 14, 3, 53, 340, DateTimeKind.Local).AddTicks(975), new DateTime(2021, 3, 27, 21, 28, 8, 79, DateTimeKind.Local).AddTicks(7000), 5, 30, "Facere qui beatae aliquam.\nRecusandae voluptate dolorum nostrum occaecati quisquam.\nQuam quidem accusantium a est ipsa itaque provident.\nEt magni dolorem nam ut ut aperiam vitae.\nUllam eius qui qui aspernatur harum." },
                    { 59, new DateTime(2021, 4, 8, 0, 28, 1, 44, DateTimeKind.Local).AddTicks(2160), 110, new DateTime(2022, 6, 18, 8, 50, 58, 124, DateTimeKind.Local).AddTicks(2856), new DateTime(2021, 4, 27, 9, 4, 34, 714, DateTimeKind.Local).AddTicks(4642), 2, 17, "Ut earum excepturi. Aliquam odio explicabo eveniet eos sed neque. Fugit omnis eos autem porro. Consectetur adipisci itaque. Culpa repellat natus a quas consequatur. Vel voluptatem nihil." },
                    { 38, new DateTime(2021, 1, 23, 17, 27, 40, 308, DateTimeKind.Local).AddTicks(984), 111, new DateTime(2022, 5, 29, 16, 13, 16, 362, DateTimeKind.Local).AddTicks(8097), new DateTime(2021, 6, 29, 21, 27, 16, 30, DateTimeKind.Local).AddTicks(8168), 1, 79, "Impedit error itaque qui in nobis. Expedita et voluptatem eveniet sit commodi doloribus at. Enim vero quibusdam fugiat ipsum et aliquam quisquam." },
                    { 109, new DateTime(2020, 11, 17, 13, 38, 12, 598, DateTimeKind.Local).AddTicks(6445), 13, new DateTime(2022, 6, 30, 23, 10, 40, 325, DateTimeKind.Local).AddTicks(8587), new DateTime(2021, 6, 22, 5, 56, 5, 752, DateTimeKind.Local).AddTicks(4860), 3, 79, "Qui ipsa eaque inventore voluptatum nostrum accusantium sunt est soluta. Facilis eveniet in natus beatae ea error. Et qui nihil quia. Corporis vero in. Qui voluptatem nobis a explicabo ut et maiores eos voluptatibus." },
                    { 174, new DateTime(2021, 2, 7, 5, 25, 48, 613, DateTimeKind.Local).AddTicks(8330), 145, new DateTime(2022, 4, 20, 15, 4, 19, 733, DateTimeKind.Local).AddTicks(8057), new DateTime(2021, 3, 1, 15, 12, 50, 893, DateTimeKind.Local).AddTicks(3736), 4, 79, "Dolor accusantium perferendis consequatur qui." },
                    { 179, new DateTime(2021, 1, 30, 4, 31, 45, 465, DateTimeKind.Local).AddTicks(6136), 125, new DateTime(2022, 4, 6, 20, 40, 6, 417, DateTimeKind.Local).AddTicks(1685), new DateTime(2021, 8, 10, 22, 52, 43, 168, DateTimeKind.Local).AddTicks(7425), 3, 79, "Illum dolorum ut doloremque atque saepe.\nDignissimos excepturi sed dolores voluptatem blanditiis enim similique hic.\nNumquam voluptatibus ratione nisi impedit nihil ut laboriosam odit ut." },
                    { 44, new DateTime(2021, 6, 13, 1, 35, 1, 594, DateTimeKind.Local).AddTicks(8218), 65, new DateTime(2022, 2, 27, 20, 49, 35, 636, DateTimeKind.Local).AddTicks(8143), new DateTime(2020, 10, 29, 1, 8, 55, 590, DateTimeKind.Local).AddTicks(2), 2, 60, "libero" },
                    { 87, new DateTime(2021, 4, 24, 20, 43, 59, 538, DateTimeKind.Local).AddTicks(6646), 33, new DateTime(2022, 2, 14, 21, 48, 15, 198, DateTimeKind.Local).AddTicks(8271), new DateTime(2021, 6, 14, 5, 42, 28, 346, DateTimeKind.Local).AddTicks(1371), 4, 60, "Labore occaecati hic sunt assumenda dolorem eaque pariatur perferendis quo." },
                    { 170, new DateTime(2021, 4, 24, 5, 44, 27, 589, DateTimeKind.Local).AddTicks(7286), 42, new DateTime(2022, 6, 19, 18, 44, 12, 845, DateTimeKind.Local).AddTicks(612), new DateTime(2021, 1, 7, 9, 27, 47, 239, DateTimeKind.Local).AddTicks(43), 1, 60, "Corporis voluptatum est est." },
                    { 31, new DateTime(2021, 6, 11, 20, 41, 37, 644, DateTimeKind.Local).AddTicks(3901), 17, new DateTime(2021, 12, 27, 2, 52, 58, 625, DateTimeKind.Local).AddTicks(3009), new DateTime(2021, 5, 1, 16, 18, 29, 148, DateTimeKind.Local).AddTicks(5299), 4, 11, "aut" },
                    { 51, new DateTime(2021, 7, 20, 4, 1, 59, 948, DateTimeKind.Local).AddTicks(3309), 110, new DateTime(2022, 4, 21, 23, 41, 8, 367, DateTimeKind.Local).AddTicks(787), new DateTime(2021, 5, 25, 6, 32, 58, 318, DateTimeKind.Local).AddTicks(1141), 2, 9, "ipsum" },
                    { 2, new DateTime(2021, 4, 18, 2, 54, 42, 929, DateTimeKind.Local).AddTicks(8212), 75, new DateTime(2021, 12, 17, 6, 55, 36, 610, DateTimeKind.Local).AddTicks(8121), new DateTime(2021, 3, 16, 5, 25, 44, 172, DateTimeKind.Local).AddTicks(8266), 2, 17, "Est quas harum accusamus et corporis voluptatibus corporis ea recusandae.\nQuos tenetur aliquid quod.\nTempora sit harum sed." },
                    { 15, new DateTime(2021, 1, 22, 5, 43, 10, 597, DateTimeKind.Local).AddTicks(5067), 104, new DateTime(2022, 7, 2, 18, 25, 39, 21, DateTimeKind.Local).AddTicks(8100), new DateTime(2021, 7, 7, 6, 54, 7, 4, DateTimeKind.Local).AddTicks(2370), 5, 29, "maxime" }
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
