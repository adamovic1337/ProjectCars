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
                    { 1, "Austria" },
                    { 118, "Colombia" },
                    { 119, "Dominica" },
                    { 120, "Hungary" },
                    { 121, "Honduras" },
                    { 122, "Mozambique" },
                    { 123, "Swaziland" },
                    { 117, "Micronesia" },
                    { 124, "Mali" },
                    { 129, "Eritrea" },
                    { 130, "Sudan" },
                    { 131, "Panama" },
                    { 132, "Cocos (Keeling) Islands" },
                    { 133, "Malawi" },
                    { 134, "Haiti" },
                    { 126, "Guinea" },
                    { 136, "Cuba" },
                    { 116, "French Polynesia" },
                    { 111, "Fiji" },
                    { 92, "Northern Mariana Islands" },
                    { 93, "Paraguay" },
                    { 94, "Yemen" },
                    { 99, "Gibraltar" },
                    { 100, "Brazil" },
                    { 101, "Maldives" },
                    { 115, "Antarctica (the territory South of 60 deg S)" },
                    { 102, "Tunisia" },
                    { 105, "Qatar" },
                    { 106, "Nauru" },
                    { 107, "Kyrgyz Republic" },
                    { 108, "Mauritania" },
                    { 109, "Palau" },
                    { 110, "Iraq" },
                    { 103, "Belize" },
                    { 91, "Hong Kong" },
                    { 137, "Guernsey" },
                    { 141, "Lithuania" },
                    { 176, "Bouvet Island (Bouvetoya)" },
                    { 177, "Myanmar" },
                    { 178, "Uruguay" },
                    { 180, "Bolivia" },
                    { 182, "Niger" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 184, "Iran" },
                    { 172, "Vanuatu" },
                    { 185, "Serbia" },
                    { 188, "Montserrat" },
                    { 189, "Nicaragua" },
                    { 191, "Cayman Islands" },
                    { 194, "China" },
                    { 195, "Syrian Arab Republic" },
                    { 196, "Turks and Caicos Islands" },
                    { 186, "Martinique" },
                    { 138, "Namibia" },
                    { 171, "United Kingdom" },
                    { 164, "Sri Lanka" },
                    { 143, "Zambia" },
                    { 144, "Tonga" },
                    { 145, "Saint Kitts and Nevis" },
                    { 147, "Spain" },
                    { 148, "Palestinian Territory" },
                    { 149, "Uzbekistan" },
                    { 166, "Bhutan" },
                    { 151, "Australia" },
                    { 154, "Ukraine" },
                    { 155, "Romania" },
                    { 156, "United Arab Emirates" },
                    { 158, "Malta" },
                    { 162, "Mongolia" },
                    { 163, "France" },
                    { 152, "Bulgaria" },
                    { 90, "Argentina" },
                    { 96, "Netherlands Antilles" },
                    { 88, "Pakistan" },
                    { 23, "Mauritius" },
                    { 25, "Vietnam" },
                    { 26, "Costa Rica" },
                    { 27, "Botswana" },
                    { 30, "India" },
                    { 31, "Greenland" },
                    { 22, "Senegal" },
                    { 32, "Singapore" },
                    { 34, "Rwanda" },
                    { 35, "Gabon" },
                    { 36, "Niue" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 89, "Georgia" },
                    { 40, "Trinidad and Tobago" },
                    { 41, "Cook Islands" },
                    { 33, "Solomon Islands" },
                    { 42, "San Marino" },
                    { 21, "Saudi Arabia" },
                    { 19, "Ghana" },
                    { 2, "South Africa" },
                    { 3, "Cameroon" },
                    { 4, "Burkina Faso" },
                    { 5, "Guinea-Bissau" },
                    { 6, "Switzerland" },
                    { 7, "Kiribati" },
                    { 20, "Norway" },
                    { 9, "Indonesia" },
                    { 11, "Angola" },
                    { 12, "Benin" },
                    { 13, "Turkey" },
                    { 14, "Timor-Leste" },
                    { 16, "Albania" },
                    { 17, "Thailand" },
                    { 10, "Portugal" },
                    { 43, "Sierra Leone" },
                    { 37, "Wallis and Futuna" },
                    { 45, "Greece" },
                    { 66, "Croatia" },
                    { 67, "Faroe Islands" },
                    { 68, "Chad" },
                    { 44, "Pitcairn Islands" },
                    { 74, "Ireland" },
                    { 75, "Democratic People's Republic of Korea" },
                    { 65, "Heard Island and McDonald Islands" },
                    { 76, "Algeria" },
                    { 78, "Sweden" },
                    { 79, "Lesotho" },
                    { 81, "British Indian Ocean Territory (Chagos Archipelago)" },
                    { 82, "Jordan" },
                    { 85, "Saint Pierre and Miquelon" },
                    { 87, "South Georgia and the South Sandwich Islands" },
                    { 77, "Western Sahara" },
                    { 64, "Afghanistan" },
                    { 70, "Latvia" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 62, "Moldova" },
                    { 46, "Slovenia" },
                    { 47, "Belarus" },
                    { 63, "Kazakhstan" },
                    { 50, "Saint Helena" },
                    { 51, "New Zealand" },
                    { 52, "Guam" },
                    { 53, "Virgin Islands, U.S." },
                    { 49, "Tajikistan" },
                    { 55, "Isle of Man" },
                    { 56, "Estonia" },
                    { 57, "Equatorial Guinea" },
                    { 58, "Germany" },
                    { 59, "Central African Republic" },
                    { 60, "Cape Verde" },
                    { 54, "Cambodia" }
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
                    { 15, 111, "South Sarinaburgh" },
                    { 249, 120, "Malloryside" },
                    { 190, 120, "Schmelerville" },
                    { 292, 119, "East Petraville" },
                    { 132, 119, "East Felipa" },
                    { 118, 119, "Port Ezequielchester" },
                    { 205, 118, "New Derickstad" },
                    { 204, 118, "Reichelhaven" },
                    { 6, 118, "Macland" },
                    { 12, 196, "North Bert" },
                    { 69, 196, "Novellahaven" },
                    { 239, 117, "West Verda" },
                    { 127, 117, "Deckowborough" },
                    { 105, 117, "Millston" },
                    { 281, 196, "Mathiaston" },
                    { 291, 115, "Amayaborough" },
                    { 257, 111, "Kamrentown" },
                    { 158, 111, "Elyseport" },
                    { 255, 120, "Lebsackmouth" },
                    { 279, 120, "North Katelynfurt" },
                    { 28, 121, "South Jude" },
                    { 211, 121, "Fisherberg" },
                    { 174, 129, "Port Lailatown" },
                    { 21, 129, "Osbaldoburgh" },
                    { 9, 129, "West Patienceport" },
                    { 254, 126, "North Kristinaburgh" },
                    { 168, 126, "Nellatown" },
                    { 120, 126, "West Bart" },
                    { 91, 126, "New Laurine" },
                    { 19, 126, "Borisshire" },
                    { 73, 111, "Hartmannborough" },
                    { 34, 195, "Lubowitzbury" },
                    { 214, 124, "Barbaramouth" },
                    { 142, 124, "East Duncanland" },
                    { 282, 123, "North Rossie" },
                    { 114, 123, "Mrazmouth" },
                    { 42, 123, "Port Chad" },
                    { 8, 196, "Lake Bret" },
                    { 29, 122, "North Jessycamouth" },
                    { 294, 121, "Lake Meredith" },
                    { 299, 124, "Pamelatown" },
                    { 26, 130, "Lake Danykaside" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 31, 111, "Spencerfurt" },
                    { 2, 110, "South Jarodtown" },
                    { 242, 93, "South Rosendoton" },
                    { 81, 91, "South Claraland" },
                    { 217, 90, "South Harvey" },
                    { 163, 90, "South Aureliefurt" },
                    { 129, 89, "Morissettefort" },
                    { 178, 88, "North Ashlychester" },
                    { 74, 88, "New Isai" },
                    { 13, 88, "Lake Kiarramouth" },
                    { 252, 82, "West Keshawnchester" },
                    { 22, 82, "North Stacey" },
                    { 298, 176, "West Adrien" },
                    { 284, 81, "Ricemouth" },
                    { 51, 81, "New Malindaview" },
                    { 180, 79, "Lake Demetris" },
                    { 295, 78, "New Ricky" },
                    { 186, 77, "Willport" },
                    { 110, 77, "Mayerhaven" },
                    { 123, 94, "Carrolltown" },
                    { 171, 94, "Anselshire" },
                    { 198, 94, "Lake Dorthystad" },
                    { 52, 96, "East Justina" },
                    { 189, 108, "Bettyetown" },
                    { 183, 108, "Ardellaburgh" },
                    { 55, 108, "Spencermouth" },
                    { 177, 107, "Keanuville" },
                    { 278, 106, "North Abigale" },
                    { 274, 106, "South Kentonhaven" },
                    { 199, 106, "Beckerfort" },
                    { 185, 106, "New Lance" },
                    { 256, 110, "Langoshchester" },
                    { 94, 105, "Yasmineburgh" },
                    { 269, 102, "Marionbury" },
                    { 246, 101, "North Candidaside" },
                    { 159, 101, "Yadirachester" },
                    { 154, 101, "Goodwinport" },
                    { 64, 101, "South Ena" },
                    { 151, 100, "Lake Cassandra" },
                    { 263, 99, "Stevetown" },
                    { 128, 96, "East Darby" },
                    { 175, 103, "Terryshire" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 280, 76, "Cartwrightport" },
                    { 193, 130, "East Gunner" },
                    { 41, 194, "Port Linniemouth" },
                    { 80, 158, "Lake Shayleeport" },
                    { 187, 156, "New Yessenia" },
                    { 137, 156, "Vickiebury" },
                    { 25, 156, "Olliehaven" },
                    { 265, 155, "Alessandrochester" },
                    { 82, 155, "South Scottie" },
                    { 38, 155, "Sabinaview" },
                    { 89, 178, "Keonstad" },
                    { 140, 154, "Osinskistad" },
                    { 60, 154, "Kellieberg" },
                    { 247, 152, "Lake Jessie" },
                    { 297, 151, "Lake Zariaport" },
                    { 104, 151, "New Sadyebury" },
                    { 145, 149, "Deckowside" },
                    { 111, 178, "Macejkovicside" },
                    { 273, 178, "Trompbury" },
                    { 245, 148, "Port Rosa" },
                    { 83, 158, "Margaritaland" },
                    { 125, 158, "West Stanfordborough" },
                    { 277, 158, "South Consuelo" },
                    { 75, 162, "Steuberchester" },
                    { 153, 172, "Stromanview" },
                    { 144, 172, "New Tabithamouth" },
                    { 56, 172, "West Cecileland" },
                    { 222, 171, "Karinaburgh" },
                    { 130, 171, "North Janelle" },
                    { 59, 171, "South Pierrechester" },
                    { 1, 177, "West Edwardoland" },
                    { 65, 166, "South Margaret" },
                    { 160, 148, "New Gregville" },
                    { 4, 166, "Nikolausfurt" },
                    { 268, 177, "New Jaycee" },
                    { 143, 164, "North Aubrey" },
                    { 36, 164, "Port Damienmouth" },
                    { 240, 163, "Powlowskimouth" },
                    { 98, 163, "West Claremouth" },
                    { 68, 163, "Port Amietown" },
                    { 266, 162, "East Neomaville" },
                    { 161, 162, "Lake Stan" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 229, 177, "Lake Raquelbury" },
                    { 200, 131, "Lincolnburgh" },
                    { 5, 148, "East Jarrodburgh" },
                    { 86, 180, "Dooleyhaven" },
                    { 182, 138, "Port Magdalena" },
                    { 148, 138, "New Eugenia" },
                    { 244, 188, "Port Elisabethville" },
                    { 194, 137, "New Robb" },
                    { 76, 137, "Franciston" },
                    { 226, 136, "Mantestad" },
                    { 156, 136, "Saulview" },
                    { 44, 136, "Port Lexushaven" },
                    { 283, 188, "Adrianfurt" },
                    { 196, 133, "Schulistshire" },
                    { 97, 133, "Langoshview" },
                    { 90, 133, "Lake Edton" },
                    { 62, 133, "North Caleigh" },
                    { 103, 191, "Gorczanyfort" },
                    { 289, 191, "Uptonmouth" },
                    { 87, 132, "Wuckertview" },
                    { 17, 132, "North Ericka" },
                    { 191, 188, "Ricobury" },
                    { 85, 188, "Alyciatown" },
                    { 71, 141, "West Ivahton" },
                    { 78, 141, "Port Gerardoland" },
                    { 236, 147, "Betsychester" },
                    { 179, 147, "Robertsberg" },
                    { 272, 180, "Cathrynmouth" },
                    { 212, 184, "East Ethelside" },
                    { 238, 145, "New Jocelynfurt" },
                    { 135, 145, "Port Lauretta" },
                    { 233, 185, "New Mazie" },
                    { 243, 144, "West Siennaton" },
                    { 63, 180, "Mayerbury" },
                    { 192, 144, "Buckridgeshire" },
                    { 288, 143, "Wisokyside" },
                    { 172, 143, "South Garrickland" },
                    { 146, 143, "South Molly" },
                    { 116, 143, "North Juanitaberg" },
                    { 139, 186, "West Leland" },
                    { 220, 186, "North Daniela" },
                    { 195, 141, "Rempelhaven" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 92, 141, "North Rodrick" },
                    { 113, 144, "Hesselstad" },
                    { 23, 76, "Jeffereymouth" },
                    { 228, 176, "East Brandyn" },
                    { 230, 37, "Port Sarina" },
                    { 275, 36, "Beattyburgh" },
                    { 46, 37, "Batzfurt" },
                    { 108, 37, "North Angelina" },
                    { 155, 37, "East Calista" },
                    { 138, 75, "Rachelleberg" },
                    { 166, 40, "Treverburgh" },
                    { 231, 17, "East Lynn" },
                    { 11, 41, "North Bettyborough" },
                    { 30, 42, "North Hillardberg" },
                    { 66, 42, "Lake Roderick" },
                    { 134, 42, "South Brice" },
                    { 209, 42, "Dewittborough" },
                    { 287, 42, "Lemketown" },
                    { 210, 17, "Georgettemouth" },
                    { 218, 36, "South Johanfort" },
                    { 157, 17, "Port Ewaldtown" },
                    { 253, 43, "Kilbackshire" },
                    { 57, 17, "New Rylanfurt" },
                    { 223, 16, "Port Melany" },
                    { 14, 44, "Kerluketown" },
                    { 169, 44, "New Rudolph" },
                    { 270, 44, "Port Maureen" },
                    { 54, 16, "Shaniamouth" },
                    { 53, 16, "Leannfort" },
                    { 107, 45, "East Angelo" },
                    { 100, 46, "Geovanyhaven" },
                    { 47, 16, "East Estellaside" },
                    { 121, 49, "Port Harley" },
                    { 149, 49, "East Simoneview" },
                    { 260, 14, "West Tobin" },
                    { 49, 43, "New Clotildehaven" },
                    { 176, 14, "Boganshire" },
                    { 88, 36, "Lake Garthfurt" },
                    { 241, 35, "Lake Horacio" },
                    { 7, 23, "East Violet" },
                    { 124, 23, "New Alfonzofurt" },
                    { 119, 25, "Howeborough" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 122, 25, "Lake Orland" },
                    { 126, 22, "East Alverta" },
                    { 250, 20, "New Kendra" },
                    { 20, 27, "West Paulashire" },
                    { 150, 27, "New Elnora" },
                    { 219, 27, "Brendanton" },
                    { 235, 20, "South Willard" },
                    { 207, 30, "New Alta" },
                    { 221, 30, "South Trishaland" },
                    { 290, 30, "Lake Elouiseborough" },
                    { 224, 20, "West Norma" },
                    { 259, 35, "South Eino" },
                    { 227, 31, "Bodemouth" },
                    { 95, 19, "New Irving" },
                    { 43, 32, "Rosalynmouth" },
                    { 99, 32, "Lake Dandreborough" },
                    { 147, 33, "Christiansenside" },
                    { 170, 33, "Hermanfurt" },
                    { 206, 33, "Port Rachel" },
                    { 276, 33, "Isobelton" },
                    { 296, 33, "Alyshachester" },
                    { 3, 34, "North Nils" },
                    { 72, 34, "South Carlottaview" },
                    { 93, 34, "South Reagan" },
                    { 96, 34, "Sallymouth" },
                    { 271, 34, "East Collinmouth" },
                    { 131, 35, "Petraborough" },
                    { 213, 19, "Abbigailtown" },
                    { 173, 22, "North Judsonmouth" },
                    { 35, 14, "East Lucio" },
                    { 215, 22, "South Janessaberg" },
                    { 264, 74, "Lake Boydstad" },
                    { 251, 60, "Pfefferfurt" },
                    { 267, 60, "Eileenton" },
                    { 201, 74, "South Lizzieport" },
                    { 232, 7, "West Quentinburgh" },
                    { 84, 7, "North Adolphusborough" },
                    { 77, 74, "Hilmamouth" },
                    { 10, 62, "East Katherinetown" },
                    { 167, 5, "Lake Zechariah" },
                    { 112, 62, "Boganland" },
                    { 293, 62, "Goldenland" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 117, 5, "Satterfieldberg" },
                    { 164, 60, "West Ila" },
                    { 70, 63, "West Nannieport" },
                    { 37, 5, "Isabellefort" },
                    { 203, 70, "Amieside" },
                    { 162, 4, "Port Garfieldside" },
                    { 58, 4, "Williamsonhaven" },
                    { 152, 64, "Lake Maurice" },
                    { 262, 64, "South Kingborough" },
                    { 16, 65, "New Dustyhaven" },
                    { 101, 3, "Tremaynehaven" },
                    { 27, 65, "Tillmanberg" },
                    { 197, 65, "Donnellyhaven" },
                    { 61, 2, "East Susie" },
                    { 234, 66, "Port Ethel" },
                    { 133, 63, "East Willyville" },
                    { 24, 67, "Ortizside" },
                    { 237, 59, "Keeblerport" },
                    { 184, 9, "East Isabella" },
                    { 141, 50, "Loyalshire" },
                    { 181, 50, "Jazlynville" },
                    { 67, 51, "Richardberg" },
                    { 202, 52, "Blockburgh" },
                    { 40, 13, "South Cooper" },
                    { 285, 12, "West Mollybury" },
                    { 248, 52, "East Dorianburgh" },
                    { 258, 12, "Cassandreberg" },
                    { 188, 12, "Ullrichland" },
                    { 45, 53, "Mitchellport" },
                    { 136, 53, "Torphymouth" },
                    { 39, 12, "Frederikton" },
                    { 33, 9, "Stantonton" },
                    { 18, 12, "Hellerstad" },
                    { 106, 55, "Fritschton" },
                    { 165, 55, "New Douglas" },
                    { 261, 55, "Hanefort" },
                    { 300, 10, "Fritschberg" },
                    { 286, 56, "Lake Georgianna" },
                    { 216, 10, "Port Fatimaborough" },
                    { 79, 10, "Lake Janae" },
                    { 32, 57, "North Elliot" },
                    { 102, 57, "McClureburgh" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 115, 57, "Pricemouth" },
                    { 208, 9, "North Kira" },
                    { 109, 58, "West Richmond" },
                    { 50, 2, "New Ezequiel" },
                    { 225, 2, "Johnsonport" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 25, 1822, 4, "iure", 184 },
                    { 82, 1701, 4, "ipsa", 468 },
                    { 43, 1466, 4, "minus", 282 },
                    { 66, 2347, 4, "sequi", 126 },
                    { 61, 1022, 4, "tempora", 147 },
                    { 48, 1308, 4, "exercitationem", 420 },
                    { 34, 2906, 4, "error", 530 },
                    { 37, 1911, 4, "vel", 247 },
                    { 36, 1126, 4, "asperiores", 404 },
                    { 31, 1414, 4, "laboriosam", 638 },
                    { 68, 1406, 4, "aut", 467 },
                    { 33, 1242, 4, "et", 591 },
                    { 21, 2375, 2, "doloremque", 293 },
                    { 14, 1140, 4, "aspernatur", 129 },
                    { 22, 2794, 1, "inventore", 582 },
                    { 60, 2476, 2, "autem", 380 },
                    { 24, 2007, 1, "nostrum", 372 },
                    { 55, 1596, 2, "officia", 278 },
                    { 28, 2687, 1, "qui", 532 },
                    { 38, 1743, 1, "iusto", 587 },
                    { 40, 2863, 1, "ullam", 276 },
                    { 51, 2369, 1, "saepe", 166 },
                    { 64, 2374, 1, "id", 311 },
                    { 54, 1412, 2, "voluptas", 569 },
                    { 52, 2774, 2, "quasi", 410 },
                    { 67, 1122, 2, "nisi", 381 },
                    { 78, 2658, 1, "harum", 233 },
                    { 92, 2396, 1, "ad", 260 },
                    { 4, 2945, 2, "dolorum", 424 },
                    { 5, 1965, 2, "ut", 448 },
                    { 49, 2429, 2, "consectetur", 508 },
                    { 7, 2922, 2, "cumque", 166 },
                    { 9, 2774, 2, "nemo", 375 },
                    { 44, 1035, 2, "iste", 261 },
                    { 12, 1425, 2, "eos", 658 },
                    { 32, 2014, 2, "perspiciatis", 550 },
                    { 30, 1629, 2, "voluptate", 107 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 20, 2410, 2, "sed", 670 },
                    { 91, 1243, 1, "quam", 174 },
                    { 23, 2068, 4, "quo", 450 },
                    { 73, 1351, 2, "molestiae", 196 },
                    { 19, 1717, 1, "debitis", 305 },
                    { 13, 2635, 4, "sapiente", 163 },
                    { 8, 1323, 4, "consequuntur", 507 },
                    { 3, 2677, 4, "incidunt", 124 },
                    { 2, 2759, 4, "veritatis", 110 },
                    { 93, 1893, 3, "eaque", 477 },
                    { 77, 1062, 3, "distinctio", 159 },
                    { 76, 2183, 3, "nam", 684 },
                    { 70, 1716, 3, "quibusdam", 271 },
                    { 65, 2068, 3, "esse", 401 },
                    { 59, 1556, 3, "recusandae", 216 },
                    { 47, 2489, 3, "enim", 336 },
                    { 79, 2874, 2, "magnam", 240 },
                    { 46, 2813, 3, "voluptatem", 665 },
                    { 41, 2053, 3, "ipsam", 600 },
                    { 39, 2755, 3, "in", 496 },
                    { 27, 1125, 3, "omnis", 642 },
                    { 17, 1279, 3, "nesciunt", 366 },
                    { 6, 2370, 1, "eius", 103 },
                    { 10, 1450, 1, "modi", 462 },
                    { 15, 1926, 1, "fugiat", 661 },
                    { 1, 2675, 3, "est", 430 },
                    { 16, 2463, 1, "assumenda", 474 },
                    { 18, 1251, 1, "excepturi", 260 },
                    { 97, 2130, 2, "impedit", 182 },
                    { 42, 2856, 3, "accusantium", 437 },
                    { 11, 1022, 2, "tenetur", 389 },
                    { 99, 1183, 4, "quos", 382 },
                    { 95, 1926, 4, "laborum", 629 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 75, 166, "O'Reilly - Dach" },
                    { 22, 44, "Wilkinson - Little" },
                    { 28, 44, "Schinner - Johnston" },
                    { 100, 46, "Pagac and Sons" },
                    { 8, 47, "Stanton - Emard" },
                    { 64, 49, "Gutmann, Miller and Moore" },
                    { 79, 49, "Balistreri Group" },
                    { 86, 52, "Hane - Kertzmann" },
                    { 51, 53, "Bernier - Koss" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 6, 54, "Bayer Group" },
                    { 37, 54, "Murazik LLC" },
                    { 7, 56, "Stamm - Gutmann" },
                    { 57, 57, "Willms - Wiza" },
                    { 82, 60, "Bogan, Abbott and Bartoletti" },
                    { 87, 60, "Kuphal - Jenkins" },
                    { 99, 63, "Labadie - Hackett" },
                    { 14, 65, "Legros, Ernser and Brakus" },
                    { 76, 68, "Swaniawski and Sons" },
                    { 34, 74, "Bartell, Reilly and Harvey" },
                    { 29, 75, "Trantow - Abbott" },
                    { 40, 75, "Sawayn, Murray and Reinger" },
                    { 52, 43, "Heidenreich, Reynolds and Yundt" },
                    { 42, 43, "Stoltenberg, Gorczany and Botsford" },
                    { 83, 42, "Gusikowski, Jacobi and Blick" },
                    { 60, 42, "Hauck, Hilpert and Schmeler" },
                    { 38, 1, "Bartell - Gislason" },
                    { 58, 2, "Abbott, Kirlin and Roberts" },
                    { 66, 4, "Gutmann Group" },
                    { 16, 5, "Botsford Group" },
                    { 62, 6, "Langosh, Hills and Farrell" },
                    { 5, 7, "Wilderman - Bosco" },
                    { 19, 7, "Zieme, Stanton and Koss" },
                    { 72, 10, "Orn, Christiansen and Gottlieb" },
                    { 50, 13, "Bauch Inc" },
                    { 65, 13, "Pfeffer LLC" },
                    { 10, 79, "Harvey - Koelpin" },
                    { 33, 14, "Jacobson - Bins" },
                    { 4, 22, "Corwin Inc" },
                    { 56, 22, "Mante, Collier and Baumbach" },
                    { 43, 25, "Friesen, Walker and Batz" },
                    { 69, 25, "Johns - Schulist" },
                    { 93, 25, "Wuckert and Sons" },
                    { 15, 27, "Doyle, Bruen and Crona" },
                    { 41, 30, "Huel and Sons" },
                    { 9, 31, "Homenick, Cartwright and Huels" },
                    { 78, 31, "Lynch LLC" },
                    { 49, 40, "Huel, Runolfsson and Hessel" },
                    { 67, 21, "Prosacco, Bednar and Crist" },
                    { 31, 81, "Morissette Group" },
                    { 46, 87, "Blick Group" },
                    { 84, 88, "Crist - Feil" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 3, 189, "Hilpert LLC" },
                    { 70, 188, "Wintheiser - Marks" },
                    { 63, 133, "Grant LLC" },
                    { 53, 137, "Aufderhar, Leuschke and Block" },
                    { 13, 138, "Rolfson - Dickinson" },
                    { 97, 138, "Ondricka, Bradtke and Wisozk" },
                    { 21, 186, "Mraz, Klein and Streich" },
                    { 48, 141, "Hettinger - Schumm" },
                    { 96, 141, "Cremin, Bernhard and Funk" },
                    { 55, 144, "Schaefer, Baumbach and Koelpin" },
                    { 74, 145, "Jerde Group" },
                    { 80, 180, "Cummings - Bashirian" },
                    { 91, 145, "Rutherford - Bauch" },
                    { 77, 147, "Toy Inc" },
                    { 85, 147, "West, Kris and Waelchi" },
                    { 27, 178, "Crist - Bradtke" },
                    { 45, 148, "Davis, Buckridge and Hintz" },
                    { 89, 148, "Gulgowski, Marquardt and Howe" },
                    { 81, 154, "Bergnaum, Beier and Bechtelar" },
                    { 36, 164, "Durgan - Carter" },
                    { 47, 164, "Monahan, Halvorson and Koepp" },
                    { 59, 132, "O'Connell - Wisozk" },
                    { 1, 132, "Rau, Klocko and Lemke" },
                    { 2, 131, "Erdman LLC" },
                    { 88, 194, "Franecki - Adams" },
                    { 32, 89, "Ondricka, Leffler and Hintz" },
                    { 68, 89, "Crooks - Harris" },
                    { 94, 90, "Ondricka LLC" },
                    { 20, 93, "Ferry LLC" },
                    { 30, 93, "Bogisich - Heaney" },
                    { 25, 94, "Beahan, Carroll and Mitchell" },
                    { 26, 94, "Skiles, Fay and Braun" },
                    { 23, 96, "Walker, Blick and Abshire" },
                    { 73, 100, "Brown - Kunze" },
                    { 98, 100, "Conn, Dare and Wintheiser" },
                    { 44, 172, "Hayes, Stamm and Kertzmann" },
                    { 61, 102, "Nader - Raynor" },
                    { 12, 109, "Smith, Grady and Mertz" },
                    { 90, 110, "Runolfsson Group" },
                    { 11, 115, "Bode, Feest and Hammes" },
                    { 17, 115, "Will, Stroman and Morissette" },
                    { 54, 115, "Schinner and Sons" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 24, 116, "Schoen LLC" },
                    { 39, 117, "Emmerich - Frami" },
                    { 71, 117, "Koch LLC" },
                    { 92, 122, "Cassin Inc" },
                    { 18, 124, "Fay - Windler" },
                    { 95, 105, "Kemmer, Lesch and Welch" },
                    { 35, 1, "Bosco LLC" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 5, 95, 75, "aliquam" },
                    { 31, 55, 38, "numquam" },
                    { 22, 55, 92, "repellendus" },
                    { 42, 54, 24, "natus" },
                    { 49, 52, 71, "occaecati" },
                    { 98, 49, 36, "officia" },
                    { 11, 49, 14, "ab" },
                    { 90, 44, 57, "laboriosam" },
                    { 8, 44, 51, "consequatur" },
                    { 82, 30, 95, "accusantium" },
                    { 94, 20, 69, "animi" },
                    { 87, 12, 23, "eum" },
                    { 78, 12, 55, "nobis" },
                    { 36, 9, 9, "sed" },
                    { 3, 9, 40, "velit" },
                    { 46, 55, 24, "pariatur" },
                    { 29, 7, 10, "non" },
                    { 66, 64, 40, "unde" },
                    { 16, 64, 39, "amet" },
                    { 14, 64, 16, "et" },
                    { 76, 51, 63, "at" },
                    { 12, 40, 11, "fuga" },
                    { 74, 38, 73, "adipisci" },
                    { 6, 28, 77, "odit" },
                    { 10, 24, 53, "atque" },
                    { 19, 22, 3, "optio" },
                    { 1, 19, 82, "quo" },
                    { 20, 18, 49, "cum" },
                    { 79, 15, 5, "aliquid" },
                    { 2, 15, 24, "quia" },
                    { 85, 10, 91, "consectetur" },
                    { 9, 7, 99, "eligendi" },
                    { 70, 55, 15, "vitae" },
                    { 58, 82, 86, "officiis" },
                    { 40, 73, 58, "nihil" },
                    { 26, 67, 47, "vel" },
                    { 44, 82, 94, "sit" },
                    { 91, 68, 27, "voluptatem" },
                    { 86, 48, 1, "soluta" },
                    { 15, 48, 72, "nisi" },
                    { 39, 43, 78, "rerum" },
                    { 37, 43, 89, "iste" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 7, 43, 71, "molestiae" },
                    { 4, 43, 84, "ut" },
                    { 72, 36, 62, "repudiandae" },
                    { 54, 36, 65, "quidem" },
                    { 59, 33, 64, "qui" },
                    { 69, 23, 80, "architecto" },
                    { 18, 8, 5, "sapiente" },
                    { 97, 3, 67, "doloremque" },
                    { 84, 61, 10, "error" },
                    { 55, 93, 23, "culpa" },
                    { 65, 3, 22, "magnam" },
                    { 51, 97, 18, "distinctio" },
                    { 77, 17, 27, "accusamus" },
                    { 13, 39, 18, "illo" },
                    { 43, 41, 63, "saepe" },
                    { 57, 41, 80, "quod" },
                    { 45, 17, 4, "asperiores" },
                    { 25, 42, 93, "aut" },
                    { 21, 77, 93, "fugit" },
                    { 60, 41, 4, "est" },
                    { 89, 76, 75, "dignissimos" },
                    { 38, 97, 72, "sint" },
                    { 68, 70, 98, "reiciendis" },
                    { 41, 59, 41, "id" },
                    { 24, 46, 6, "ducimus" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 157, 146, "Oswaldo_Purdy@gmail.com", "Abdullah", "Friesen", "password123", 2, "Jasen_Kuvalis" },
                    { 180, 76, "Jonas_Kirlin71@gmail.com", "Silas", "Kuvalis", "password123", 1, "Maritza56" },
                    { 243, 194, "Bessie86@gmail.com", "Jace", "Parisian", "password123", 2, "Jarret.Bernhard5" },
                    { 158, 182, "Lloyd.Carroll9@yahoo.com", "Winnifred", "Glover", "password123", 3, "Turner_Crona22" },
                    { 268, 182, "Bethany15@yahoo.com", "Hershel", "Welch", "password123", 1, "Lucy90" },
                    { 109, 78, "Elizabeth47@hotmail.com", "Antonetta", "Ullrich", "password123", 2, "Nash_Bode91" },
                    { 156, 78, "Madelyn32@gmail.com", "Kyleigh", "Streich", "password123", 1, "Kyleigh40" },
                    { 171, 78, "Esteban.MacGyver@hotmail.com", "Gregorio", "Turcotte", "password123", 3, "Raleigh93" },
                    { 167, 195, "Craig37@hotmail.com", "Holden", "Champlin", "password123", 2, "Bert_Harris" },
                    { 30, 116, "Keanu.Champlin@hotmail.com", "Javonte", "Nader", "password123", 3, "Fredy_Predovic" },
                    { 99, 76, "Derrick_Ritchie@gmail.com", "Vada", "Medhurst", "password123", 1, "Deontae.Grimes58" },
                    { 12, 148, "Gia_Ward@hotmail.com", "Baylee", "Armstrong", "password123", 3, "Rowan_Larkin10" },
                    { 22, 236, "Leola23@yahoo.com", "Alaina", "Flatley", "password123", 1, "Kayleigh_Bednar" },
                    { 93, 192, "Shanna88@gmail.com", "Gussie", "Harris", "password123", 2, "Rodger65" },
                    { 274, 192, "Ayana0@hotmail.com", "Jalon", "Strosin", "password123", 2, "Jayde24" },
                    { 59, 135, "Addie_Muller15@hotmail.com", "Alejandra", "Pfannerstill", "password123", 3, "Brigitte.VonRueden" },
                    { 136, 135, "Bud_Upton@gmail.com", "Aliza", "Toy", "password123", 3, "Lafayette_Barrows" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 130, 179, "Janie_Jakubowski@hotmail.com", "Valerie", "Leffler", "password123", 1, "Cassidy_Abshire" },
                    { 240, 160, "Alisa.Blanda@gmail.com", "Fatima", "Walker", "password123", 1, "Jazmyn.Rowe88" },
                    { 281, 160, "Devonte15@gmail.com", "Christa", "Fahey", "password123", 1, "Madilyn_Stark79" },
                    { 60, 145, "Soledad_Mertz@gmail.com", "Mckenzie", "Wilkinson", "password123", 2, "Alice52" },
                    { 179, 145, "Helena_Ledner@yahoo.com", "Laurie", "Jenkins", "password123", 1, "Olen_OConner94" },
                    { 205, 104, "Abagail_Rosenbaum@hotmail.com", "Louvenia", "Waelchi", "password123", 2, "Kiera.Vandervort" },
                    { 9, 247, "Shaina87@hotmail.com", "Johathan", "Rath", "password123", 3, "Mariana.Brekke" },
                    { 239, 226, "Isobel.Funk96@hotmail.com", "Trever", "Kiehn", "password123", 1, "Ofelia.DAmore" },
                    { 230, 172, "Lilla.Douglas@yahoo.com", "Gerhard", "Greenfelder", "password123", 2, "Shea_Ziemann" },
                    { 215, 156, "Kelsie22@gmail.com", "Haylie", "Jacobi", "password123", 3, "Dorcas61" },
                    { 25, 19, "Gail_Corwin4@hotmail.com", "Jayce", "Deckow", "password123", 3, "Adrain_Johnston" },
                    { 91, 62, "Ebony.Hansen52@gmail.com", "Lonny", "Littel", "password123", 2, "Emmalee.Purdy" },
                    { 123, 28, "Johnny_Murray@gmail.com", "Wilma", "Corkery", "password123", 1, "Adolfo49" },
                    { 213, 211, "Berneice_Hyatt@gmail.com", "Mohammed", "Gutmann", "password123", 2, "Gail_Nitzsche62" },
                    { 81, 294, "Rosa.Mills61@yahoo.com", "Millie", "Gibson", "password123", 1, "Felicita.Bayer52" },
                    { 132, 294, "Suzanne_Homenick12@gmail.com", "Camilla", "Conroy", "password123", 2, "Kelley21" },
                    { 248, 294, "Willis_Streich@gmail.com", "Briana", "Douglas", "password123", 3, "Michel22" },
                    { 95, 29, "Arianna_Schowalter@yahoo.com", "Alfonzo", "Lemke", "password123", 1, "Taryn34" },
                    { 178, 29, "Hollis18@hotmail.com", "Maxie", "Funk", "password123", 1, "Oleta47" },
                    { 300, 29, "Akeem56@yahoo.com", "Noe", "Halvorson", "password123", 3, "Angus_Gerhold" },
                    { 41, 42, "Jaylon.Stamm69@gmail.com", "Adela", "Rosenbaum", "password123", 1, "Alvena.Prohaska70" },
                    { 271, 42, "Alvis72@hotmail.com", "Vinnie", "Emmerich", "password123", 2, "Koby26" },
                    { 144, 114, "Harry.Hyatt@gmail.com", "Russ", "Pollich", "password123", 2, "Joaquin_Russel" },
                    { 27, 214, "Amya30@gmail.com", "Madonna", "Ryan", "password123", 3, "Norwood.Raynor" },
                    { 31, 196, "Paula.Reinger35@gmail.com", "Charley", "Zulauf", "password123", 2, "Orlando31" },
                    { 197, 247, "Velda_Greenholt66@gmail.com", "Brittany", "Fahey", "password123", 2, "Odell_Hand" },
                    { 134, 19, "Bryana40@hotmail.com", "Meagan", "Kohler", "password123", 3, "Clement9" },
                    { 71, 91, "Jewell.Kuvalis@yahoo.com", "Shea", "Lang", "password123", 3, "Evan_Nicolas26" },
                    { 69, 120, "Sammy63@hotmail.com", "Hardy", "Koepp", "password123", 1, "Anna.Hintz" },
                    { 203, 120, "Tania45@yahoo.com", "Alda", "Beer", "password123", 3, "Mandy11" },
                    { 127, 168, "Hannah2@yahoo.com", "Terrill", "Bailey", "password123", 3, "April65" },
                    { 88, 21, "Nyah.Wolff52@gmail.com", "Marisa", "Hauck", "password123", 2, "Victoria96" },
                    { 120, 21, "Rebekah.Kassulke@gmail.com", "Zakary", "Weber", "password123", 1, "Richard.Ledner14" },
                    { 284, 174, "Stacy_Johnson@hotmail.com", "Dayne", "Schiller", "password123", 2, "Karlee_Jaskolski" },
                    { 47, 26, "Rosalinda91@hotmail.com", "Athena", "Wuckert", "password123", 2, "Davion68" },
                    { 231, 17, "Priscilla_Ebert89@yahoo.com", "Lee", "Reinger", "password123", 3, "Cloyd.Hamill56" },
                    { 94, 87, "Brandon.Langworth56@yahoo.com", "Brandy", "Rohan", "password123", 2, "Cydney_Feest" },
                    { 224, 87, "May55@gmail.com", "Scarlett", "Monahan", "password123", 2, "Nikolas76" },
                    { 44, 19, "Ericka.Abshire@yahoo.com", "Arlo", "Bosco", "password123", 2, "Karelle.Parker" },
                    { 52, 60, "Sheldon97@gmail.com", "Fred", "Monahan", "password123", 3, "Joany_Bradtke48" },
                    { 270, 161, "Daryl56@gmail.com", "Susan", "Barton", "password123", 3, "Viola10" },
                    { 116, 140, "Sonny.Schuster46@hotmail.com", "Dariana", "Lang", "password123", 2, "Domingo.Schinner51" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 149, 273, "Darius84@gmail.com", "Stephany", "Barrows", "password123", 1, "Bridie71" },
                    { 232, 273, "Rafael_Kulas@gmail.com", "Erich", "Berge", "password123", 3, "Alex_Muller39" },
                    { 77, 63, "Kristopher33@yahoo.com", "Carmella", "Nienow", "password123", 1, "Cara23" },
                    { 225, 272, "Jedidiah72@hotmail.com", "Sheldon", "Reichel", "password123", 1, "Coy_Mayert29" },
                    { 292, 272, "Collin66@hotmail.com", "Mariana", "Kuphal", "password123", 2, "Rosanna_Crist38" },
                    { 37, 212, "Bradford70@hotmail.com", "Hettie", "Cormier", "password123", 2, "Estrella11" },
                    { 169, 212, "Ona.Hudson@yahoo.com", "Elissa", "Shields", "password123", 1, "Blair_Berge35" },
                    { 168, 233, "Jaeden_Howe61@hotmail.com", "Domingo", "Heathcote", "password123", 3, "Alexandra_Farrell11" },
                    { 187, 220, "Jennyfer_Schumm@yahoo.com", "Ilene", "DuBuque", "password123", 3, "Kylie60" },
                    { 38, 85, "Faye24@hotmail.com", "Lucas", "Rogahn", "password123", 2, "Beatrice44" },
                    { 33, 191, "Rebeca_Will@gmail.com", "Garett", "Shanahan", "password123", 3, "Caesar_Corkery" },
                    { 48, 191, "Lorine59@yahoo.com", "Verlie", "Blick", "password123", 3, "Katlynn.Collier" },
                    { 142, 244, "Sylvia_Fahey@yahoo.com", "Fatima", "Mosciski", "password123", 3, "Eve_Harvey5" },
                    { 190, 244, "Douglas12@yahoo.com", "Robb", "Dietrich", "password123", 2, "Stewart43" },
                    { 261, 283, "Idell.Runolfsdottir@hotmail.com", "Kaitlyn", "Okuneva", "password123", 3, "Jaunita32" },
                    { 11, 103, "Garnet.Hilpert@hotmail.com", "Horacio", "Rogahn", "password123", 1, "Jasen39" },
                    { 285, 103, "Afton.Toy6@yahoo.com", "Hellen", "Pouros", "password123", 1, "Dillan0" },
                    { 97, 41, "Autumn82@gmail.com", "Eleonore", "Hartmann", "password123", 3, "Otha91" },
                    { 211, 41, "Georgette.Beier@hotmail.com", "Maxime", "Reichel", "password123", 2, "Vergie.Mayer0" },
                    { 286, 41, "Damaris_Littel@gmail.com", "Abe", "Simonis", "password123", 2, "Hunter.Prohaska95" },
                    { 122, 34, "Berenice.Sipes@yahoo.com", "Hellen", "Beer", "password123", 2, "Lesly.Weimann" },
                    { 61, 8, "Jordon96@yahoo.com", "Toni", "Thiel", "password123", 2, "Isobel.Effertz79" },
                    { 172, 12, "Lysanne.Schaefer@hotmail.com", "Victoria", "Fahey", "password123", 3, "Freddie12" },
                    { 254, 69, "Markus_Thompson@yahoo.com", "Cale", "Schmitt", "password123", 2, "Lera7" },
                    { 36, 281, "Paris.Johns23@yahoo.com", "Jaiden", "Goodwin", "password123", 1, "Jovani74" },
                    { 66, 28, "Guillermo.Abshire3@hotmail.com", "Rupert", "Turner", "password123", 2, "Jonathon_Rath30" },
                    { 10, 273, "Hans_Roob52@gmail.com", "Pierre", "Reinger", "password123", 1, "Carole_Kirlin73" },
                    { 294, 89, "Eleanora_Bosco79@hotmail.com", "Harry", "Lockman", "password123", 1, "Avery.Runolfsson" },
                    { 229, 298, "Eldridge.Runolfsson16@hotmail.com", "Meggie", "Wolf", "password123", 2, "Vivianne_Pfannerstill" },
                    { 2, 38, "Irwin_Batz@yahoo.com", "Walton", "Abernathy", "password123", 2, "Marlin97" },
                    { 76, 82, "Thalia82@gmail.com", "Alden", "Gottlieb", "password123", 2, "Dalton84" },
                    { 55, 265, "Concepcion.Connelly@gmail.com", "Lulu", "Stoltenberg", "password123", 3, "Martin20" },
                    { 198, 265, "Raoul51@yahoo.com", "Kelsie", "Becker", "password123", 3, "Dorian_Swaniawski" },
                    { 72, 25, "Freddy_Bayer74@gmail.com", "Robin", "Conroy", "password123", 3, "Audie_McLaughlin" },
                    { 234, 25, "Brittany25@hotmail.com", "Chyna", "Witting", "password123", 3, "Keely_Waters" },
                    { 50, 137, "Geo_Strosin96@yahoo.com", "Pablo", "Kunze", "password123", 1, "Nigel15" },
                    { 80, 137, "Bridget.Treutel60@yahoo.com", "Allison", "Wisoky", "password123", 2, "Dangelo.Howe" },
                    { 153, 137, "Kaci.Farrell16@gmail.com", "Delmer", "Abshire", "password123", 1, "Frida58" },
                    { 164, 187, "Maegan_Friesen88@yahoo.com", "Laney", "Rau", "password123", 3, "Milo_Cassin" },
                    { 6, 80, "Eddie.Kling28@yahoo.com", "Tavares", "Hauck", "password123", 2, "Melody.Klocko" },
                    { 152, 161, "Hoyt_Stanton3@hotmail.com", "Alexandrea", "O'Keefe", "password123", 1, "Terry12" },
                    { 56, 60, "Magali_Hammes@hotmail.com", "Edna", "Mitchell", "password123", 2, "Verner39" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 245, 161, "Brandyn.Skiles@yahoo.com", "Terrill", "Watsica", "password123", 3, "Merritt_Tremblay" },
                    { 247, 36, "Greta.Lehner@yahoo.com", "Lempi", "Mraz", "password123", 1, "Wellington20" },
                    { 133, 143, "Clovis.Renner@hotmail.com", "Caesar", "O'Keefe", "password123", 1, "Avery46" },
                    { 176, 130, "Adam75@gmail.com", "Gregg", "Toy", "password123", 2, "Haven.Weber19" },
                    { 181, 130, "Jaycee_Lubowitz9@hotmail.com", "Elbert", "Armstrong", "password123", 1, "Sam_McGlynn34" },
                    { 214, 130, "Shanny20@yahoo.com", "Mason", "Senger", "password123", 2, "Thea_Ziemann11" },
                    { 128, 222, "Bethel.Kiehn@yahoo.com", "Lela", "Kunde", "password123", 3, "Remington_Pfeffer" },
                    { 35, 56, "Frederique.Lakin97@yahoo.com", "Deangelo", "Schroeder", "password123", 2, "Velda.Schoen" },
                    { 101, 56, "Aimee58@gmail.com", "Ettie", "Ferry", "password123", 3, "Sasha.Dickens" },
                    { 184, 56, "Karen.Leffler@yahoo.com", "Pearlie", "Nienow", "password123", 3, "Margarete_Fahey42" },
                    { 173, 144, "Talon_Reilly@gmail.com", "Cletus", "Klein", "password123", 1, "River12" },
                    { 58, 153, "Emmanuelle20@hotmail.com", "Ericka", "McClure", "password123", 2, "Melyna_Okuneva47" },
                    { 84, 153, "Citlalli33@yahoo.com", "Gabrielle", "Dickens", "password123", 3, "Tatyana.Brakus" },
                    { 242, 36, "Aida55@hotmail.com", "Amelia", "O'Hara", "password123", 2, "Guillermo_Marquardt16" },
                    { 39, 273, "Osborne_Deckow27@gmail.com", "Ali", "Adams", "password123", 3, "Kathlyn.Schneider0" },
                    { 28, 255, "Howard.OHara82@hotmail.com", "Rahsaan", "Gibson", "password123", 3, "Hazle.Wunsch" },
                    { 161, 249, "Creola9@gmail.com", "Angela", "Bosco", "password123", 2, "Letitia.Mitchell20" },
                    { 64, 275, "Muhammad_Botsford@hotmail.com", "Francesca", "Kulas", "password123", 3, "Jackeline.Medhurst" },
                    { 141, 218, "Conor_Wunsch@yahoo.com", "Barbara", "Jacobi", "password123", 1, "Scarlett_Breitenberg58" },
                    { 112, 241, "Leo.Jast86@yahoo.com", "Valerie", "Dach", "password123", 2, "Hailee9" },
                    { 277, 271, "Benjamin52@hotmail.com", "Reta", "Kassulke", "password123", 3, "Melany44" },
                    { 223, 271, "Woodrow_Gutkowski@gmail.com", "Foster", "Johns", "password123", 1, "Trenton58" },
                    { 51, 271, "Lionel57@hotmail.com", "Vidal", "Boyer", "password123", 2, "Stefan82" },
                    { 249, 3, "Damon.Mante36@yahoo.com", "Jermain", "Tillman", "password123", 1, "Stevie49" },
                    { 192, 296, "Luis85@hotmail.com", "Oswaldo", "Wyman", "password123", 2, "Alvena_Ullrich" },
                    { 256, 276, "Eli.Hoppe@yahoo.com", "Selina", "Fritsch", "password123", 1, "Angela71" },
                    { 73, 276, "Justine74@hotmail.com", "Hassie", "Kuhic", "password123", 3, "Keanu89" },
                    { 221, 206, "Georgiana_Gerlach1@gmail.com", "Trevor", "Bernier", "password123", 2, "Trinity.Gorczany20" },
                    { 148, 99, "Kobe.Macejkovic58@gmail.com", "Shania", "Schiller", "password123", 1, "Ima_Ziemann99" },
                    { 228, 227, "Guiseppe99@yahoo.com", "Eleanora", "Rohan", "password123", 1, "Emmanuelle.Connelly" },
                    { 151, 221, "Timothy_Christiansen@yahoo.com", "Mark", "Runolfsson", "password123", 3, "Jamal91" },
                    { 96, 221, "Agustin33@gmail.com", "Francisca", "Hilpert", "password123", 1, "Verlie70" },
                    { 3, 221, "Webster_Nicolas@hotmail.com", "Leonard", "Bernhard", "password123", 1, "Gerardo.Kuhn54" },
                    { 159, 207, "Eleonore_Goyette@yahoo.com", "Sadye", "Tromp", "password123", 1, "Tracy_Orn7" },
                    { 155, 207, "Kaia.Schmitt@hotmail.com", "Rose", "Runolfsdottir", "password123", 3, "Merlin_Koelpin" },
                    { 145, 207, "Jazmyn_Lehner69@gmail.com", "Devan", "Rosenbaum", "password123", 1, "Wendy_Tromp83" },
                    { 113, 275, "Gertrude_Gislason61@yahoo.com", "Meggie", "Anderson", "password123", 1, "Aracely51" },
                    { 262, 219, "Michele.Treutel@yahoo.com", "Alivia", "Jones", "password123", 3, "Ephraim32" },
                    { 222, 46, "Christa.Kerluke@hotmail.com", "Garrett", "Dicki", "password123", 3, "Felton.Franecki55" },
                    { 63, 230, "Mckenna45@gmail.com", "Simeon", "Yundt", "password123", 2, "Marilou.Goldner96" },
                    { 89, 121, "Dessie96@hotmail.com", "Marcia", "Bashirian", "password123", 3, "Hilton_Champlin" },
                    { 219, 100, "Elizabeth70@hotmail.com", "Idell", "Crona", "password123", 1, "Efrain_Kassulke96" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 8, 107, "Newton_Hamill@yahoo.com", "Bradly", "Gerlach", "password123", 2, "Rosalee_Dicki" },
                    { 293, 270, "Laron74@gmail.com", "Ernie", "Ledner", "password123", 1, "Hazel_Pacocha" },
                    { 182, 169, "Caleigh26@yahoo.com", "Jacquelyn", "Cruickshank", "password123", 3, "Josefina10" },
                    { 46, 169, "Krystal_Runolfsson@gmail.com", "Santina", "Grimes", "password123", 2, "Ambrose.Treutel44" },
                    { 21, 169, "Margret68@hotmail.com", "Myrtis", "Schimmel", "password123", 2, "Wilson.Beier7" },
                    { 160, 49, "Celine5@yahoo.com", "Arturo", "Konopelski", "password123", 1, "Alayna47" },
                    { 257, 209, "Manuel42@gmail.com", "Krista", "Schmitt", "password123", 3, "Hailee_Harris" },
                    { 236, 30, "Sharon70@gmail.com", "Jerald", "Shields", "password123", 2, "Hellen_Beer32" },
                    { 107, 30, "Gust.Stanton@hotmail.com", "Lavern", "Mills", "password123", 3, "Brielle.Reilly41" },
                    { 217, 11, "Joanne18@gmail.com", "Tavares", "Schneider", "password123", 3, "Alessia87" },
                    { 45, 11, "Michael_Grady@yahoo.com", "Alexandra", "Thiel", "password123", 2, "Celestino.Johnson" },
                    { 17, 11, "Leopoldo_Hane@gmail.com", "Dante", "Bode", "password123", 1, "Lloyd5" },
                    { 7, 11, "Elliott_Reilly18@gmail.com", "Drake", "Wehner", "password123", 3, "Adele_Bernhard" },
                    { 165, 166, "Reymundo73@yahoo.com", "Fermin", "Douglas", "password123", 1, "Delilah27" },
                    { 125, 166, "Harry61@hotmail.com", "Rubie", "Okuneva", "password123", 3, "Brice_Dooley0" },
                    { 82, 166, "Alden_Gleason48@yahoo.com", "Simone", "Kozey", "password123", 2, "Shaylee88" },
                    { 121, 230, "Filomena34@gmail.com", "Lia", "Sporer", "password123", 3, "Asha.Labadie" },
                    { 226, 108, "Sarai.Metz@yahoo.com", "Keely", "Kessler", "password123", 2, "Chelsey.Roberts5" },
                    { 114, 121, "Rosario89@gmail.com", "Brent", "Fadel", "password123", 3, "Cleora_Lockman77" },
                    { 53, 122, "Stanton.Weimann76@yahoo.com", "Sierra", "Mertz", "password123", 1, "Ted_Ortiz" },
                    { 162, 124, "Clay_Stiedemann@hotmail.com", "Estrella", "Treutel", "password123", 1, "Ruthie39" },
                    { 263, 39, "Quentin.Johnston22@yahoo.com", "Herbert", "Gleichner", "password123", 2, "Beulah_Thompson73" },
                    { 54, 39, "Keanu.Wisozk@yahoo.com", "Sheldon", "Walter", "password123", 2, "Fern4" },
                    { 92, 216, "Danyka_Mayer8@yahoo.com", "Demetris", "Durgan", "password123", 3, "Jody.Rowe93" },
                    { 258, 208, "Furman.Considine58@yahoo.com", "Waylon", "Connelly", "password123", 3, "Santos.Hettinger" },
                    { 146, 208, "Ronny_Monahan@yahoo.com", "Terrence", "Harber", "password123", 2, "Mac.Crooks" },
                    { 90, 208, "Rusty.Hermiston67@yahoo.com", "Benton", "King", "password123", 1, "Oliver.Murray" },
                    { 49, 184, "Audreanne72@gmail.com", "Felicita", "Heaney", "password123", 2, "Aditya47" },
                    { 24, 232, "Selmer.Kessler21@gmail.com", "Royal", "Goodwin", "password123", 3, "Willie.Donnelly" },
                    { 5, 232, "Cindy_Luettgen@yahoo.com", "Heidi", "Hirthe", "password123", 2, "Alvis_Skiles" },
                    { 4, 232, "Ashtyn.Rath@gmail.com", "Augusta", "Feeney", "password123", 3, "Margarett.Sawayn" },
                    { 237, 84, "Jude_Buckridge@hotmail.com", "Devon", "Beatty", "password123", 2, "Nasir_OHara10" },
                    { 266, 37, "Carolyn.Kreiger@hotmail.com", "Kane", "O'Keefe", "password123", 3, "Joaquin2" },
                    { 117, 37, "Brenna.Toy32@yahoo.com", "Shania", "Kunde", "password123", 3, "Susana_Williamson76" },
                    { 170, 162, "Roma.Howe@yahoo.com", "Julius", "Beatty", "password123", 3, "Berniece.Von" },
                    { 19, 162, "Aylin_Will@yahoo.com", "Halie", "Okuneva", "password123", 1, "Denis_Swift72" },
                    { 209, 58, "Kay.Greenholt@hotmail.com", "Everett", "Wuckert", "password123", 1, "Augusta65" },
                    { 200, 58, "Danial91@gmail.com", "Grayce", "Jast", "password123", 3, "Dylan_Rogahn" },
                    { 102, 101, "Jena_Botsford14@yahoo.com", "Celestino", "Sipes", "password123", 2, "Kevin3" },
                    { 119, 225, "Allen.Roob46@yahoo.com", "Wilbert", "Schuppe", "password123", 1, "Sylvan.Mraz" },
                    { 287, 39, "Otha_Hauck59@gmail.com", "Katlyn", "Wyman", "password123", 1, "Amelia11" },
                    { 189, 119, "Giovanny94@yahoo.com", "Zelda", "Kassulke", "password123", 2, "Wanda_Rosenbaum94" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 174, 258, "Albina_Wolff66@yahoo.com", "Timmothy", "Funk", "password123", 1, "Lexi26" },
                    { 20, 285, "Shany.Romaguera@hotmail.com", "Dariana", "Stracke", "password123", 3, "Idell41" },
                    { 67, 124, "Kiarra_Gerlach@yahoo.com", "Godfrey", "Miller", "password123", 3, "Axel.Veum48" },
                    { 238, 173, "Roxane_MacGyver73@yahoo.com", "Wade", "Auer", "password123", 2, "Newton_Kunze24" },
                    { 279, 126, "Donnie.OKeefe@hotmail.com", "Sasha", "Stiedemann", "password123", 1, "Marie.Dibbert" },
                    { 105, 250, "Karlee30@hotmail.com", "Marquise", "Armstrong", "password123", 3, "Eva.Paucek76" },
                    { 68, 235, "Ila55@hotmail.com", "Josefina", "Rice", "password123", 1, "Sherman7" },
                    { 206, 213, "Clemmie61@yahoo.com", "Retha", "Beier", "password123", 2, "Ricardo22" },
                    { 70, 95, "Luigi_Lockman@hotmail.com", "Barry", "Schoen", "password123", 1, "Brennan.Zieme33" },
                    { 191, 210, "Tyrique.Treutel@gmail.com", "Norwood", "Morar", "password123", 2, "Kaleb6" },
                    { 42, 157, "Sandy97@gmail.com", "Tyree", "Wuckert", "password123", 2, "Shad_Monahan6" },
                    { 283, 57, "Tanya28@yahoo.com", "Giovanny", "VonRueden", "password123", 1, "Jace87" },
                    { 177, 57, "Vernice.Nolan50@gmail.com", "Anissa", "Mayert", "password123", 1, "Gianni.Altenwerth" },
                    { 135, 57, "Reuben65@hotmail.com", "Ruthie", "Welch", "password123", 3, "Catalina11" },
                    { 282, 54, "Haven_Sawayn49@gmail.com", "Easter", "Bernier", "password123", 1, "Rene_Grimes" },
                    { 299, 176, "Muriel10@hotmail.com", "Rose", "Huel", "password123", 3, "Sherman43" },
                    { 252, 176, "Kelvin_Christiansen@gmail.com", "Stone", "Stokes", "password123", 1, "Cordell.Kunde79" },
                    { 137, 176, "May.Lueilwitz79@gmail.com", "Caden", "Marks", "password123", 2, "Jimmie17" },
                    { 259, 35, "Margarett_Bode@gmail.com", "Cara", "Boehm", "password123", 2, "Jordy_Kassulke" },
                    { 140, 35, "Vivianne.Hane53@hotmail.com", "Kaleb", "Rempel", "password123", 1, "Ruben.Hudson60" },
                    { 295, 40, "Simeon_Kovacek@hotmail.com", "Alexis", "Thiel", "password123", 1, "Marco_Heaney" },
                    { 267, 258, "Madeline_Wisoky@gmail.com", "Domenic", "Hodkiewicz", "password123", 3, "Shyann.Kohler" },
                    { 199, 249, "Destiney_Hoppe@yahoo.com", "Eulalia", "Crona", "password123", 1, "Catherine.Mraz19" },
                    { 131, 121, "Darian_Nikolaus@yahoo.com", "Griffin", "Jerde", "password123", 3, "Ruben_Bode" },
                    { 34, 181, "Martin_Fisher@yahoo.com", "Liam", "Prohaska", "password123", 1, "Ken.West69" },
                    { 298, 175, "Conrad_Hilll@hotmail.com", "Florian", "Koch", "password123", 1, "Lexie.Ebert" },
                    { 124, 175, "Hollis_Larkin@hotmail.com", "Logan", "Smith", "password123", 2, "Johnson_Williamson83" },
                    { 110, 175, "Annetta_Kilback@hotmail.com", "Franz", "Beier", "password123", 2, "Freda_Tremblay" },
                    { 210, 269, "Melyssa41@yahoo.com", "Eldon", "Gleichner", "password123", 3, "Sally_Mosciski44" },
                    { 241, 246, "Eleazar71@yahoo.com", "Jennings", "Prohaska", "password123", 3, "Giovanni.Bayer" },
                    { 264, 159, "Cydney_Predovic0@gmail.com", "Andre", "Schmitt", "password123", 1, "Winston_Nader15" },
                    { 126, 159, "Caden_Armstrong@hotmail.com", "Retha", "Marvin", "password123", 2, "Genesis_Quigley" },
                    { 16, 159, "Rafaela55@hotmail.com", "Jensen", "Kris", "password123", 3, "Geraldine_Muller20" },
                    { 87, 154, "Jarrell_Green19@hotmail.com", "Carolyne", "Kuvalis", "password123", 1, "Fletcher_Kuphal" },
                    { 85, 64, "Ethan.Bernier@gmail.com", "Orval", "Reynolds", "password123", 2, "Toy82" },
                    { 14, 64, "Ford.Kub14@gmail.com", "Delpha", "Fisher", "password123", 3, "Myles.Jast34" },
                    { 255, 151, "Peggie.Marvin22@hotmail.com", "Bud", "Powlowski", "password123", 3, "Nels82" },
                    { 250, 151, "Isaiah.Nolan@gmail.com", "Dannie", "Williamson", "password123", 2, "Davin71" },
                    { 86, 151, "Jeanne43@hotmail.com", "Ellis", "Schmitt", "password123", 1, "Flavie.Brekke7" },
                    { 13, 151, "Ashton_Jacobs@gmail.com", "Fay", "Gislason", "password123", 3, "Declan_Hettinger45" },
                    { 83, 128, "Jason_Halvorson@hotmail.com", "Haylee", "Altenwerth", "password123", 2, "Assunta_Leannon4" },
                    { 251, 171, "Gardner_Hills@gmail.com", "Clara", "Romaguera", "password123", 1, "Ada.Kautzer" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 220, 217, "Shayna_Fadel88@hotmail.com", "Oleta", "Hansen", "password123", 3, "Adalberto.Collier95" },
                    { 207, 217, "Lemuel.Reichert29@gmail.com", "Arnold", "Luettgen", "password123", 3, "Kayleigh.Lehner51" },
                    { 150, 94, "Maverick.Nitzsche@hotmail.com", "Katrina", "Ledner", "password123", 3, "Rylan_Tremblay0" },
                    { 183, 217, "Verda.Collins@yahoo.com", "Monique", "Kautzer", "password123", 1, "Lorenzo39" },
                    { 143, 185, "Antonina82@hotmail.com", "Stacy", "Durgan", "password123", 3, "Hillary6" },
                    { 246, 274, "Ola.Predovic@hotmail.com", "King", "McDermott", "password123", 2, "Isai_Powlowski" },
                    { 193, 292, "Alfredo_Jacobs38@gmail.com", "Maurine", "Heathcote", "password123", 2, "Chloe_Hermiston" },
                    { 272, 132, "Coralie_Bauch13@yahoo.com", "Barbara", "MacGyver", "password123", 1, "Demond.Mohr" },
                    { 275, 205, "Valentina.Sipes78@yahoo.com", "Merritt", "Monahan", "password123", 1, "Jimmie39" },
                    { 276, 204, "Adrianna_Ondricka78@yahoo.com", "Herbert", "Heidenreich", "password123", 1, "Myrna_Marks9" },
                    { 269, 204, "Cletus_Goyette35@hotmail.com", "Noemy", "Gibson", "password123", 1, "Tyler25" },
                    { 201, 6, "Marjorie_Boyle@yahoo.com", "Simone", "Streich", "password123", 2, "Hulda6" },
                    { 23, 127, "Karl78@yahoo.com", "Loyce", "Witting", "password123", 3, "Uriah23" },
                    { 147, 291, "Elwin77@hotmail.com", "Janelle", "Cassin", "password123", 1, "Annamarie_Hilll14" },
                    { 194, 158, "Ashly.Keeling@gmail.com", "Amely", "Welch", "password123", 1, "Jannie74" },
                    { 1, 158, "Louisa_Jenkins@yahoo.com", "Devante", "Harber", "password123", 3, "Devon_Lebsack" },
                    { 196, 73, "Easton_Stoltenberg@yahoo.com", "Chauncey", "Miller", "password123", 2, "Price_Bradtke" },
                    { 139, 15, "Calista_Hoeger8@gmail.com", "Everardo", "Shields", "password123", 1, "Tiffany.Shields" },
                    { 265, 183, "Shaina11@hotmail.com", "Hayley", "Howe", "password123", 3, "Jamie.Ullrich" },
                    { 98, 183, "Garett.Glover79@gmail.com", "Asa", "Wiegand", "password123", 2, "Andrew21" },
                    { 18, 183, "Freida_Maggio@yahoo.com", "Billie", "Hilll", "password123", 2, "Terrill_Homenick" },
                    { 260, 55, "Lourdes.Mills@yahoo.com", "Anya", "Hegmann", "password123", 3, "Imogene.Heller" },
                    { 233, 55, "Cleta.Kshlerin@yahoo.com", "William", "Hickle", "password123", 3, "Jesse65" },
                    { 227, 55, "Genesis_Price17@gmail.com", "Alyce", "Monahan", "password123", 1, "Caleigh39" },
                    { 104, 55, "Uriah.Bosco73@gmail.com", "Alexys", "Watsica", "password123", 3, "Denis40" },
                    { 138, 199, "Dion.Rolfson2@gmail.com", "Raquel", "Bednar", "password123", 1, "Josiah19" },
                    { 216, 141, "Destini99@hotmail.com", "Earnest", "Bednar", "password123", 3, "Herman45" },
                    { 166, 129, "Fiona_Kuhlman81@yahoo.com", "Frankie", "Stokes", "password123", 2, "Ambrose5" },
                    { 291, 74, "Royce.King@hotmail.com", "Alexys", "Smith", "password123", 2, "Salvatore.Miller" },
                    { 244, 293, "Aglae_Gerhold@yahoo.com", "Vern", "Thiel", "password123", 3, "Rigoberto_Bode86" },
                    { 57, 293, "Catherine_Grady48@yahoo.com", "Mayra", "Nitzsche", "password123", 1, "Jarrett.Tromp42" },
                    { 278, 10, "Mckenna_Dooley13@yahoo.com", "Victor", "Gerlach", "password123", 3, "Lavinia_Buckridge" },
                    { 74, 164, "Nelson92@hotmail.com", "Noemi", "Dach", "password123", 1, "Eli_Stehr28" },
                    { 296, 237, "Christopher_Hyatt@hotmail.com", "Mustafa", "Gerlach", "password123", 2, "Delbert_Gusikowski" },
                    { 185, 237, "Iva93@gmail.com", "Alba", "Kuphal", "password123", 3, "Gabe1" },
                    { 129, 115, "Vanessa.DAmore@yahoo.com", "Vladimir", "Nolan", "password123", 1, "Pansy82" },
                    { 75, 115, "Vada.Schaefer@hotmail.com", "Brook", "Johnson", "password123", 1, "Tiana36" },
                    { 115, 102, "Omer_Moen22@yahoo.com", "Miracle", "Friesen", "password123", 1, "Jaleel.Cummerata75" },
                    { 195, 32, "Verdie.Moen84@hotmail.com", "Vernon", "Morar", "password123", 1, "Zoe_Kilback" },
                    { 273, 286, "Kay_Bogisich79@hotmail.com", "Mariano", "Schmeler", "password123", 2, "Bridie.Collier20" },
                    { 188, 286, "Clovis_Friesen@yahoo.com", "Joyce", "Hilpert", "password123", 2, "Rudy60" },
                    { 208, 106, "Oswaldo.Schulist@yahoo.com", "Courtney", "Wyman", "password123", 3, "Robert66" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 175, 106, "Mitchel83@hotmail.com", "Fabiola", "Kilback", "password123", 2, "Daphney_Zulauf" },
                    { 202, 136, "Derrick_Abshire@hotmail.com", "Devonte", "Kuphal", "password123", 3, "Zane_Bruen29" },
                    { 40, 136, "Marian_Ratke@yahoo.com", "Braeden", "Schiller", "password123", 3, "Jeanette.Ondricka" },
                    { 111, 45, "Nellie.Stroman@gmail.com", "Lee", "Christiansen", "password123", 2, "Destinee_Feeney22" },
                    { 79, 248, "Kendrick_Dickinson12@hotmail.com", "Carolanne", "Reichel", "password123", 1, "Davion_Quigley" },
                    { 32, 248, "Gunnar_Beatty93@gmail.com", "Lennie", "Jones", "password123", 3, "Cielo.Marvin" },
                    { 288, 293, "Shirley56@hotmail.com", "Weston", "Stokes", "password123", 3, "Michel.Effertz" },
                    { 26, 178, "Cristopher.Dibbert95@gmail.com", "Granville", "Maggio", "password123", 3, "Gerry71" },
                    { 154, 70, "Otto.Upton@yahoo.com", "Ashly", "Rodriguez", "password123", 2, "Connie_Fadel" },
                    { 163, 133, "Kailee46@yahoo.com", "Rosendo", "Smitham", "password123", 1, "Kacey.Spinka" },
                    { 253, 22, "Declan55@hotmail.com", "Hassan", "Gerhold", "password123", 2, "Alejandrin.Monahan74" },
                    { 204, 180, "Carleton89@hotmail.com", "Skye", "Trantow", "password123", 1, "Osbaldo.Johnston" },
                    { 106, 295, "Bria_Stoltenberg61@hotmail.com", "Jewel", "Schaden", "password123", 3, "Berniece64" },
                    { 78, 295, "Aisha_Stanton@hotmail.com", "Josie", "Miller", "password123", 1, "Tressa71" },
                    { 297, 186, "Niko81@gmail.com", "Victor", "Rath", "password123", 2, "Rosario_Rau" },
                    { 212, 280, "Ruthe.Mertz11@hotmail.com", "Madelyn", "Predovic", "password123", 1, "Elizabeth49" },
                    { 100, 280, "Brayan18@gmail.com", "Dan", "Langosh", "password123", 1, "Germaine.Roberts" },
                    { 290, 264, "Estevan.Batz@hotmail.com", "Halie", "Jerde", "password123", 3, "Laurianne_Koepp50" },
                    { 218, 264, "Fabiola51@yahoo.com", "Jermey", "Breitenberg", "password123", 1, "Constance.Walter46" },
                    { 62, 264, "Wallace.Moen@hotmail.com", "Chanelle", "Kihn", "password123", 1, "Abner_Purdy" },
                    { 103, 201, "Sincere.Fritsch34@hotmail.com", "Estefania", "Maggio", "password123", 2, "Agustin.Cremin55" },
                    { 289, 203, "Libby.Weimann@yahoo.com", "Wilton", "Zemlak", "password123", 2, "Johann.Goyette" },
                    { 43, 203, "Elza79@hotmail.com", "Lizzie", "Franecki", "password123", 1, "Nicolette.Hyatt" },
                    { 235, 24, "America_Flatley@hotmail.com", "Zane", "Predovic", "password123", 2, "Antwon.Emmerich28" },
                    { 118, 234, "Barbara_Halvorson@yahoo.com", "Viva", "Gislason", "password123", 2, "Sean53" },
                    { 65, 197, "Rex.Nolan@gmail.com", "Bart", "Walter", "password123", 2, "Antonietta.Koelpin97" },
                    { 15, 197, "Shanny.Koss96@gmail.com", "Viviane", "Bauch", "password123", 3, "Baylee.Ziemann86" },
                    { 29, 262, "Eugene14@yahoo.com", "Jovany", "Schmeler", "password123", 3, "Gerson.Fisher" },
                    { 186, 152, "Wilmer_Bogan@yahoo.com", "Van", "Jenkins", "password123", 2, "Jessyca18" },
                    { 108, 133, "Ericka.Bergnaum@yahoo.com", "Demario", "Emard", "password123", 1, "Jammie53" },
                    { 280, 61, "Reese85@hotmail.com", "Spencer", "Nitzsche", "password123", 1, "Reynold.Kris35" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 81, "Sipes Bypass", 263, "Jasper26@hotmail.com", "Labadie, Torp and Fay", 200, "(389) 970-7021", "www.Labadie, Torp and Fay.com" },
                    { 100, "Estefania Flats", 208, "Harmony.Reinger80@gmail.com", "Emmerich - Beahan", 25, "(631) 952-2127", "www.Emmerich - Beahan.com" },
                    { 62, "O'Reilly Fall", 107, "Isabelle20@gmail.com", "Batz and Sons", 134, "(815) 386-5237", "www.Batz and Sons.com" },
                    { 58, "Jamarcus Path", 144, "Vince_Terry@yahoo.com", "Walsh LLC", 203, "(430) 409-9793", "www.Walsh LLC.com" },
                    { 117, "Conroy Glen", 142, "Hugh16@gmail.com", "Kertzmann - Treutel", 203, "(249) 630-4973", "www.Kertzmann - Treutel.com" },
                    { 65, "Karianne Summit", 132, "Cyril.Dicki@gmail.com", "Spinka - West", 127, "(856) 964-1293", "www.Spinka - West.com" },
                    { 32, "Schmitt Springs", 170, "Gage.Schaefer@gmail.com", "McLaughlin - Adams", 231, "(440) 164-1071", "www.McLaughlin - Adams.com" },
                    { 121, "Sauer Plaza", 119, "Jasmin.McClure@yahoo.com", "Ankunding, Hoppe and Rohan", 231, "(808) 612-6058", "www.Ankunding, Hoppe and Rohan.com" },
                    { 2, "Shields Vista", 139, "Gus_OReilly@yahoo.com", "Dickens Group", 12, "(201) 594-6502", "www.Dickens Group.com" },
                    { 85, "Cristian Estate", 170, "Vena_Schultz@hotmail.com", "Mueller, Yost and Fahey", 12, "(051) 931-8032", "www.Mueller, Yost and Fahey.com" },
                    { 145, "Crona Camp", 294, "Albertha_Williamson41@gmail.com", "Lebsack, Haley and Swift", 12, "(059) 471-5291", "www.Lebsack, Haley and Swift.com" },
                    { 92, "Jewel Mount", 296, "Amelie.Gutkowski@gmail.com", "Kirlin, Hudson and Ledner", 171, "(251) 909-5024", "www.Kirlin, Hudson and Ledner.com" },
                    { 63, "Oberbrunner Pines", 166, "Ivy_Pagac@gmail.com", "Muller Inc", 30, "(727) 218-4499", "www.Muller Inc.com" },
                    { 119, "Tina Ports", 2, "Amber99@hotmail.com", "Schuster LLC", 30, "(286) 447-8773", "www.Schuster LLC.com" },
                    { 125, "Abbie Square", 142, "Ulises_Hermann47@yahoo.com", "Wunsch LLC", 30, "(291) 105-1114", "www.Wunsch LLC.com" },
                    { 82, "Shanie Inlet", 254, "Annette.Bayer@gmail.com", "Jacobson LLC", 59, "(457) 867-1153", "www.Jacobson LLC.com" },
                    { 17, "Evan Route", 150, "Isidro34@yahoo.com", "Goyette, Considine and Frami", 25, "(153) 921-1921", "www.Goyette, Considine and Frami.com" },
                    { 83, "Isabella Causeway", 52, "Candice97@gmail.com", "Little, Nicolas and Pfannerstill", 136, "(049) 346-2191", "www.Little, Nicolas and Pfannerstill.com" },
                    { 99, "Crona Mews", 294, "Kimberly1@yahoo.com", "Little LLC", 27, "(633) 051-7821", "www.Little LLC.com" },
                    { 143, "Annetta Ramp", 189, "Jett.Tremblay20@hotmail.com", "Wiza, Senger and Langworth", 300, "(764) 175-9667", "www.Wiza, Senger and Langworth.com" },
                    { 40, "Angelica Rapid", 285, "Ashton96@yahoo.com", "Gottlieb - Mayert", 210, "(803) 923-4841", "www.Gottlieb - Mayert.com" },
                    { 66, "Elmer Ramp", 43, "Marcel.Muller52@gmail.com", "Homenick LLC", 210, "(211) 257-6917", "www.Homenick LLC.com" },
                    { 69, "Judy Vista", 13, "Darrion41@hotmail.com", "Blanda, Lebsack and Jones", 210, "(082) 607-7535", "www.Blanda, Lebsack and Jones.com" },
                    { 123, "Annamae Lodge", 144, "Greg_Green@hotmail.com", "Prosacco - Rath", 150, "(142) 446-6500", "www.Prosacco - Rath.com" },
                    { 86, "Forest Ports", 272, "Reuben.Leannon73@gmail.com", "West - Kreiger", 143, "(322) 381-9862", "www.West - Kreiger.com" },
                    { 148, "Collins Plain", 100, "Giovani_Stanton95@gmail.com", "Tremblay Inc", 143, "(259) 866-6945", "www.Tremblay Inc.com" },
                    { 114, "Douglas Tunnel", 111, "Neva68@gmail.com", "Kautzer, Klocko and Berge", 104, "(301) 198-2735", "www.Kautzer, Klocko and Berge.com" },
                    { 34, "Shaniya Harbors", 11, "Noemi_Wolff@gmail.com", "Schoen, King and Zulauf", 233, "(008) 270-8777", "www.Schoen, King and Zulauf.com" },
                    { 51, "Emmett Plain", 5, "Hans_Shanahan12@hotmail.com", "Lowe, Kautzer and Hackett", 1, "(965) 265-4465", "www.Lowe, Kautzer and Hackett.com" },
                    { 36, "Tate Ranch", 18, "Christa_Hane@hotmail.com", "Dare LLC", 23, "(138) 017-6209", "www.Dare LLC.com" },
                    { 71, "Lilliana Keys", 286, "Norval.Wilderman36@yahoo.com", "Koelpin, Howell and Littel", 23, "(566) 508-2787", "www.Koelpin, Howell and Littel.com" },
                    { 75, "Kautzer Bypass", 155, "Dana_Hayes@gmail.com", "Treutel - Beatty", 248, "(476) 878-0704", "www.Treutel - Beatty.com" },
                    { 103, "Serena Harbor", 74, "Mose.Jakubowski70@gmail.com", "Purdy - Hoppe", 248, "(832) 702-4300", "www.Purdy - Hoppe.com" },
                    { 110, "Pouros Summit", 3, "Frederick.Bradtke6@yahoo.com", "Emmerich, Mosciski and Walker", 248, "(117) 135-6847", "www.Emmerich, Mosciski and Walker.com" },
                    { 44, "Gilbert Mews", 107, "Eden.Macejkovic@yahoo.com", "Mosciski, Toy and Witting", 300, "(419) 520-9801", "www.Mosciski, Toy and Witting.com" },
                    { 90, "Stamm Pass", 204, "Josue8@hotmail.com", "Raynor - Bruen", 27, "(928) 875-1754", "www.Raynor - Bruen.com" },
                    { 28, "Evangeline Prairie", 266, "Rebekah16@hotmail.com", "Maggio, Strosin and Herzog", 241, "(288) 388-0516", "www.Maggio, Strosin and Herzog.com" },
                    { 130, "Arne Course", 67, "Eda88@gmail.com", "Rippin - Anderson", 136, "(869) 329-5650", "www.Rippin - Anderson.com" },
                    { 19, "Darrel Roads", 85, "Salvador_Renner@yahoo.com", "Lakin - Borer", 9, "(596) 767-0586", "www.Lakin - Borer.com" },
                    { 122, "Lee Knoll", 179, "Nakia_Prosacco41@gmail.com", "Schaden Group", 84, "(456) 427-9102", "www.Schaden Group.com" },
                    { 139, "Giles Wall", 44, "Kenyon_Reilly31@hotmail.com", "McClure, O'Connell and Schoen", 84, "(925) 897-8214", "www.McClure, O'Connell and Schoen.com" },
                    { 84, "Durgan Squares", 275, "Obie99@hotmail.com", "Bailey, Christiansen and Murray", 39, "(224) 421-7880", "www.Bailey, Christiansen and Murray.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 120, "Brionna Creek", 250, "Jaylin_Hauck@gmail.com", "Rohan - Abshire", 232, "(068) 441-4891", "www.Rohan - Abshire.com" },
                    { 124, "Gaylord Stravenue", 167, "Kendall_Quitzon@yahoo.com", "Rolfson - Blick", 168, "(267) 628-1688", "www.Rolfson - Blick.com" },
                    { 136, "Nicholaus Village", 124, "Baylee.Kuhlman92@yahoo.com", "Corwin, Larson and Bradtke", 168, "(201) 381-9174", "www.Corwin, Larson and Bradtke.com" },
                    { 80, "Rossie Manor", 260, "Dudley_Konopelski91@gmail.com", "Luettgen, Medhurst and Ritchie", 187, "(802) 321-2085", "www.Luettgen, Medhurst and Ritchie.com" },
                    { 9, "Hahn Ville", 251, "Clint.Cartwright72@hotmail.com", "Weber, Rice and King", 48, "(679) 666-9528", "www.Weber, Rice and King.com" },
                    { 57, "Joanne Land", 88, "Chelsie_Ruecker63@yahoo.com", "Wilderman - Feil", 48, "(123) 047-0598", "www.Wilderman - Feil.com" },
                    { 107, "Zemlak Trafficway", 252, "Ryan.Kirlin@gmail.com", "Hansen Group", 48, "(700) 439-8916", "www.Hansen Group.com" },
                    { 33, "Brain Ferry", 255, "Anastacio12@yahoo.com", "Nader LLC", 142, "(923) 340-3580", "www.Nader LLC.com" },
                    { 54, "Skiles Trail", 246, "Pasquale33@hotmail.com", "Fay, Daugherty and Beier", 142, "(770) 529-4856", "www.Fay, Daugherty and Beier.com" },
                    { 131, "Reynolds Drives", 56, "Kareem52@hotmail.com", "Jast LLC", 142, "(948) 524-3706", "www.Jast LLC.com" },
                    { 135, "Pearl Ways", 293, "Clint67@hotmail.com", "Lockman - Kuhic", 142, "(113) 440-5001", "www.Lockman - Kuhic.com" },
                    { 39, "Graham Passage", 224, "Abigale.Beer84@yahoo.com", "Lesch Group", 97, "(769) 799-4910", "www.Lesch Group.com" },
                    { 21, "Christiansen Locks", 5, "Dereck.Wunsch18@gmail.com", "Ebert - Kilback", 84, "(444) 782-4170", "www.Ebert - Kilback.com" },
                    { 6, "Gilberto Hills", 176, "Issac.Schulist47@hotmail.com", "McCullough - Ondricka", 9, "(114) 012-6709", "www.McCullough - Ondricka.com" },
                    { 12, "Frida Greens", 248, "Guy.McDermott@hotmail.com", "Mraz Inc", 101, "(632) 017-3280", "www.Mraz Inc.com" },
                    { 35, "Evelyn Drives", 100, "Nikko25@gmail.com", "Zulauf, Crooks and Hoppe", 128, "(203) 641-9173", "www.Zulauf, Crooks and Hoppe.com" },
                    { 24, "Josianne Haven", 276, "Declan26@gmail.com", "Streich, Hayes and Bahringer", 9, "(520) 615-6017", "www.Streich, Hayes and Bahringer.com" },
                    { 3, "Cummerata Common", 153, "Jason.Jaskolski@hotmail.com", "Lehner, Becker and Morissette", 52, "(411) 455-1653", "www.Lehner, Becker and Morissette.com" },
                    { 150, "Vandervort Pine", 253, "Winona.Kerluke61@gmail.com", "Sipes, Buckridge and Breitenberg", 52, "(188) 725-6950", "www.Sipes, Buckridge and Breitenberg.com" },
                    { 1, "Langworth Lock", 194, "Emelia.Hackett@hotmail.com", "Shanahan Group", 198, "(719) 122-4890", "www.Shanahan Group.com" },
                    { 42, "Kennith Courts", 221, "Margarette_Kunde86@hotmail.com", "Welch - Hirthe", 72, "(491) 735-5165", "www.Welch - Hirthe.com" },
                    { 106, "Mraz Keys", 297, "Aida_OConner@hotmail.com", "Huels, Will and Corkery", 72, "(591) 689-1633", "www.Huels, Will and Corkery.com" },
                    { 26, "Alba Freeway", 174, "Lavon.Altenwerth@yahoo.com", "Tremblay - Christiansen", 234, "(417) 793-1021", "www.Tremblay - Christiansen.com" },
                    { 38, "Bernhard Spur", 109, "Jaqueline.Bernhard19@gmail.com", "Pagac - Ernser", 234, "(000) 966-1064", "www.Pagac - Ernser.com" },
                    { 56, "Jayden Creek", 142, "Alisha77@hotmail.com", "Reichel - Gleason", 234, "(854) 694-4663", "www.Reichel - Gleason.com" },
                    { 67, "Lubowitz Ford", 239, "Johann.Gulgowski@yahoo.com", "Steuber, Mertz and Pouros", 234, "(153) 923-6494", "www.Steuber, Mertz and Pouros.com" },
                    { 23, "Bauch Route", 220, "Travon_Emmerich@yahoo.com", "Dickens, Zulauf and Bartell", 245, "(225) 211-2013", "www.Dickens, Zulauf and Bartell.com" },
                    { 31, "Theron Prairie", 168, "Oliver_Cruickshank@gmail.com", "Tromp, Hettinger and Koch", 245, "(605) 641-5628", "www.Tromp, Hettinger and Koch.com" },
                    { 55, "McGlynn Prairie", 122, "Penelope_Hansen@yahoo.com", "Jerde - Heidenreich", 245, "(533) 978-7193", "www.Jerde - Heidenreich.com" },
                    { 74, "Cruickshank Mills", 231, "Adrien.Reinger@gmail.com", "O'Connell Inc", 245, "(550) 203-5850", "www.O'Connell Inc.com" },
                    { 47, "Heathcote Mall", 1, "Adeline.Towne@hotmail.com", "Kunze - Bahringer", 270, "(439) 698-0627", "www.Kunze - Bahringer.com" },
                    { 126, "Reichel Dale", 243, "Cary_Armstrong78@hotmail.com", "Lang - McGlynn", 128, "(800) 089-1729", "www.Lang - McGlynn.com" },
                    { 89, "Edwardo Curve", 67, "Ben12@gmail.com", "Bogan and Sons", 16, "(927) 503-5897", "www.Bogan and Sons.com" },
                    { 88, "Rhoda Branch", 71, "Kyle39@gmail.com", "Gutmann - Schimmel", 164, "(508) 860-9564", "www.Gutmann - Schimmel.com" },
                    { 127, "Albina Pine", 221, "Emely59@gmail.com", "Rutherford - Botsford", 255, "(528) 785-4745", "www.Rutherford - Botsford.com" },
                    { 144, "Howell Drive", 275, "Zita43@gmail.com", "Ortiz - Graham", 20, "(464) 866-9766", "www.Ortiz - Graham.com" },
                    { 11, "Beatrice Club", 282, "Roxane.Homenick61@gmail.com", "Considine, Ziemann and Konopelski", 135, "(162) 927-7372", "www.Considine, Ziemann and Konopelski.com" },
                    { 41, "Santino View", 243, "Jarrod_Renner92@yahoo.com", "Dickens - Kuhic", 135, "(131) 473-7523", "www.Dickens - Kuhic.com" },
                    { 112, "O'Reilly Ridge", 89, "Cameron18@yahoo.com", "Dietrich Group", 262, "(666) 941-6003", "www.Dietrich Group.com" },
                    { 73, "Mckenna Tunnel", 171, "Fern53@gmail.com", "Halvorson - Cruickshank", 155, "(199) 504-4723", "www.Halvorson - Cruickshank.com" },
                    { 77, "McLaughlin Camp", 239, "Luella_Reynolds@gmail.com", "Stanton, Wolff and O'Kon", 155, "(303) 080-3388", "www.Stanton, Wolff and O'Kon.com" },
                    { 37, "Claude Gateway", 24, "Andres11@yahoo.com", "Rath and Sons", 73, "(828) 255-6711", "www.Rath and Sons.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 95, "Schaefer Junction", 223, "Lera56@hotmail.com", "Kozey - Bechtelar", 73, "(542) 934-5178", "www.Kozey - Bechtelar.com" },
                    { 115, "Steuber Street", 273, "Oliver99@hotmail.com", "Hudson, Grady and Funk", 73, "(611) 762-1225", "www.Hudson, Grady and Funk.com" },
                    { 45, "Diamond Circle", 58, "Courtney99@gmail.com", "Gorczany, Metz and Heidenreich", 277, "(090) 378-6620", "www.Gorczany, Metz and Heidenreich.com" },
                    { 116, "Luettgen Square", 205, "Koby38@hotmail.com", "Goldner - Crooks", 277, "(044) 820-0097", "www.Goldner - Crooks.com" },
                    { 4, "Brown Stravenue", 72, "Cassie.Balistreri@gmail.com", "Wiegand - Heidenreich", 64, "(827) 178-1069", "www.Wiegand - Heidenreich.com" },
                    { 109, "Orn Road", 238, "Nasir.Torphy1@hotmail.com", "Lindgren, Waelchi and Considine", 222, "(344) 524-1205", "www.Lindgren, Waelchi and Considine.com" },
                    { 140, "Reynold Burg", 52, "Lexie70@yahoo.com", "Effertz - Klein", 121, "(287) 391-8909", "www.Effertz - Klein.com" },
                    { 64, "Bernier Club", 211, "Grayce.Kilback70@yahoo.com", "Koelpin, Harris and Hermiston", 125, "(859) 127-5221", "www.Koelpin, Harris and Hermiston.com" },
                    { 132, "Alan Vista", 96, "Herta19@yahoo.com", "Pollich - Weissnat", 20, "(951) 348-3263", "www.Pollich - Weissnat.com" },
                    { 79, "Florine Centers", 295, "Marlin_Vandervort71@yahoo.com", "West - Dickens", 125, "(935) 908-0416", "www.West - Dickens.com" },
                    { 10, "Lucie Pike", 152, "Jayne_Cormier94@yahoo.com", "Anderson, Oberbrunner and Strosin", 20, "(348) 420-5663", "www.Anderson, Oberbrunner and Strosin.com" },
                    { 133, "Stone Village", 278, "Alivia_Spinka40@gmail.com", "Kunze - Keebler", 92, "(187) 189-1922", "www.Kunze - Keebler.com" },
                    { 104, "Ethyl Lock", 193, "Sadye14@hotmail.com", "Wyman - Breitenberg", 14, "(353) 124-4818", "www.Wyman - Breitenberg.com" },
                    { 7, "Terry View", 86, "Pierre27@hotmail.com", "Vandervort, Funk and Zboncak", 170, "(638) 360-0179", "www.Vandervort, Funk and Zboncak.com" },
                    { 29, "Bins Locks", 191, "Lupe11@hotmail.com", "Roberts and Sons", 170, "(636) 949-6584", "www.Roberts and Sons.com" },
                    { 49, "Bayer Manors", 49, "Braden.Dibbert83@hotmail.com", "Quitzon - Bashirian", 170, "(025) 173-5206", "www.Quitzon - Bashirian.com" },
                    { 78, "Keara Cape", 76, "Nikki.Toy@hotmail.com", "Rogahn - Toy", 170, "(994) 344-1051", "www.Rogahn - Toy.com" },
                    { 61, "Oberbrunner Creek", 141, "Kaylin3@hotmail.com", "Tillman, Smitham and Bosco", 117, "(024) 767-5318", "www.Tillman, Smitham and Bosco.com" },
                    { 105, "Kaia Valleys", 230, "Aurore_Mohr@gmail.com", "Reichel, Emmerich and White", 117, "(560) 584-5331", "www.Reichel, Emmerich and White.com" },
                    { 25, "Waelchi Corner", 4, "Sincere.Murphy85@yahoo.com", "MacGyver, Armstrong and Towne", 266, "(512) 141-0395", "www.MacGyver, Armstrong and Towne.com" },
                    { 102, "Crona Light", 272, "June5@yahoo.com", "Heidenreich and Sons", 266, "(829) 675-9945", "www.Heidenreich and Sons.com" },
                    { 59, "Luettgen Coves", 176, "Liam_Legros38@hotmail.com", "Hilll LLC", 24, "(380) 728-6082", "www.Hilll LLC.com" },
                    { 111, "Earnest Junction", 73, "Nigel84@gmail.com", "Schroeder Group", 24, "(469) 513-5276", "www.Schroeder Group.com" },
                    { 118, "DuBuque Hills", 221, "Gussie50@gmail.com", "Weimann Inc", 24, "(994) 989-7385", "www.Weimann Inc.com" },
                    { 15, "Monte Meadows", 96, "Precious_Schmeler57@yahoo.com", "Leuschke - Bauch", 258, "(808) 437-7560", "www.Leuschke - Bauch.com" },
                    { 94, "Pearline Overpass", 167, "Trinity.Gerlach@gmail.com", "Wyman, Heidenreich and Ward", 258, "(671) 348-0223", "www.Wyman, Heidenreich and Ward.com" },
                    { 142, "Kaya Throughway", 126, "Laisha_Yundt@hotmail.com", "Lueilwitz LLC", 258, "(642) 506-4789", "www.Lueilwitz LLC.com" },
                    { 149, "Kristina Crest", 230, "Dale28@yahoo.com", "Bednar Group", 92, "(270) 490-8657", "www.Bednar Group.com" },
                    { 138, "Ubaldo Island", 209, "Leslie_Reichert7@hotmail.com", "O'Keefe - Macejkovic", 125, "(546) 721-5355", "www.O'Keefe - Macejkovic.com" },
                    { 16, "Howard Trace", 296, "Roselyn36@yahoo.com", "Daniel, Murphy and Flatley", 258, "(140) 917-4395", "www.Daniel, Murphy and Flatley.com" },
                    { 146, "Champlin Springs", 134, "Verna42@yahoo.com", "Reilly LLC", 7, "(286) 555-5935", "www.Reilly LLC.com" },
                    { 18, "Moore Lakes", 69, "Cathy.Schultz@yahoo.com", "Hettinger, Upton and Hansen", 208, "(747) 317-2837", "www.Hettinger, Upton and Hansen.com" },
                    { 76, "Kreiger Lock", 209, "Orville.Bahringer@yahoo.com", "Collier, Smitham and Stark", 208, "(318) 913-8764", "www.Collier, Smitham and Stark.com" },
                    { 128, "Kuvalis Pass", 83, "Jacklyn.Walker81@gmail.com", "Farrell Inc", 185, "(064) 747-7132", "www.Farrell Inc.com" },
                    { 87, "Conroy Spring", 296, "Verla.Homenick@hotmail.com", "Lueilwitz, Roob and Harber", 278, "(008) 209-8108", "www.Lueilwitz, Roob and Harber.com" },
                    { 20, "Gunner Mews", 293, "Lulu23@hotmail.com", "Sanford, Smith and Stroman", 290, "(616) 751-2824", "www.Sanford, Smith and Stroman.com" },
                    { 141, "Lane Course", 31, "Junius62@gmail.com", "Hartmann - Ritchie", 106, "(159) 582-5430", "www.Hartmann - Ritchie.com" },
                    { 46, "Koepp Fords", 157, "Johnnie48@gmail.com", "Hodkiewicz and Sons", 26, "(698) 772-8015", "www.Hodkiewicz and Sons.com" },
                    { 129, "Bayer Isle", 240, "Alba.Adams97@hotmail.com", "Conn - Johnson", 207, "(636) 587-9020", "www.Conn - Johnson.com" },
                    { 48, "Harvey Street", 90, "Sydney87@yahoo.com", "Kshlerin, Pollich and Wiza", 220, "(659) 945-2818", "www.Kshlerin, Pollich and Wiza.com" },
                    { 70, "Noemy Key", 257, "Nelle_Funk87@yahoo.com", "Gerlach Group", 220, "(424) 318-4771", "www.Gerlach Group.com" },
                    { 134, "Lebsack Shoal", 280, "Johnathan.Grant@hotmail.com", "Rice LLC", 220, "(392) 930-5541", "www.Rice LLC.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 13, "Effertz Trafficway", 76, "Magnus_Dooley93@yahoo.com", "Bayer Group", 13, "(501) 465-0900", "www.Bayer Group.com" },
                    { 96, "Torp Fall", 279, "Odell.Runolfsdottir39@hotmail.com", "Stehr, Dietrich and Cummings", 13, "(513) 224-4516", "www.Stehr, Dietrich and Cummings.com" },
                    { 113, "Gerlach Track", 166, "Jaqueline18@yahoo.com", "Green Inc", 7, "(775) 089-8653", "www.Green Inc.com" },
                    { 30, "Amya Dale", 165, "Lucius.Mann@hotmail.com", "Wyman, Anderson and Rutherford", 255, "(653) 476-0256", "www.Wyman, Anderson and Rutherford.com" },
                    { 68, "Delphine Haven", 222, "Winston_Herman@hotmail.com", "Littel, Buckridge and Reinger", 202, "(864) 728-3355", "www.Littel, Buckridge and Reinger.com" },
                    { 27, "Mellie Heights", 188, "Fern.Kerluke@yahoo.com", "Hammes - Kuvalis", 202, "(432) 337-0912", "www.Hammes - Kuvalis.com" },
                    { 53, "Estefania Brook", 89, "Ayla.Rolfson@yahoo.com", "Cormier, Stoltenberg and Walsh", 26, "(249) 344-3531", "www.Cormier, Stoltenberg and Walsh.com" },
                    { 5, "Hickle Fork", 15, "Hettie.Keebler26@hotmail.com", "Rippin - Fisher", 40, "(574) 062-0805", "www.Rippin - Fisher.com" },
                    { 137, "Sydney Expressway", 172, "Velma1@gmail.com", "Ledner, Ledner and Heaney", 217, "(870) 406-0621", "www.Ledner, Ledner and Heaney.com" },
                    { 97, "Brittany Coves", 183, "Taya_Hermiston@yahoo.com", "Luettgen - Keeling", 217, "(994) 261-1620", "www.Luettgen - Keeling.com" },
                    { 22, "Edgardo Courts", 99, "Gustave.Mitchell51@yahoo.com", "Koch Inc", 202, "(421) 778-8447", "www.Koch Inc.com" },
                    { 72, "Ozella Fort", 267, "Ewald51@hotmail.com", "Jacobson, Gleichner and Cronin", 107, "(392) 426-8085", "www.Jacobson, Gleichner and Cronin.com" },
                    { 108, "Heloise Port", 117, "Joe_Senger@hotmail.com", "Prosacco - Krajcik", 107, "(276) 101-4682", "www.Prosacco - Krajcik.com" },
                    { 8, "Jake Valley", 178, "Grace.Jacobson19@hotmail.com", "Bogisich Inc", 257, "(943) 009-6221", "www.Bogisich Inc.com" },
                    { 14, "Bailey Island", 98, "Ole99@hotmail.com", "Kub, Bode and Ward", 89, "(904) 122-9656", "www.Kub, Bode and Ward.com" },
                    { 43, "Schmeler Field", 113, "Clemens.Runolfsson20@gmail.com", "Corwin - Cassin", 89, "(521) 053-0747", "www.Corwin - Cassin.com" },
                    { 98, "Gutkowski Fort", 278, "Christopher45@gmail.com", "Rempel and Sons", 182, "(289) 554-2126", "www.Rempel and Sons.com" },
                    { 101, "Quitzon Hollow", 136, "Brown.Lindgren40@gmail.com", "Stroman - Pollich", 89, "(348) 651-4143", "www.Stroman - Pollich.com" },
                    { 60, "Mayert Camp", 122, "Marjorie29@gmail.com", "Rau Inc", 32, "(257) 647-2607", "www.Rau Inc.com" },
                    { 147, "Stephen Parkways", 251, "Mollie_Hilpert@hotmail.com", "Spencer, Gusikowski and Von", 131, "(493) 113-8872", "www.Spencer, Gusikowski and Von.com" },
                    { 50, "Rogahn Trace", 96, "Jane_Kozey@yahoo.com", "Mertz - Bednar", 216, "(747) 881-9494", "www.Mertz - Bednar.com" },
                    { 93, "Willms Pass", 180, "Alivia_Zboncak11@gmail.com", "Becker - Greenholt", 216, "(772) 440-9999", "www.Becker - Greenholt.com" },
                    { 52, "Deckow Port", 39, "Nathanael48@hotmail.com", "Hand - Huel", 89, "(035) 938-1204", "www.Hand - Huel.com" },
                    { 91, "Robb Flats", 1, "Jeanette70@gmail.com", "Quigley Group", 216, "(431) 214-9972", "www.Quigley Group.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 14, new DateTime(2020, 12, 29, 1, 19, 0, 59, DateTimeKind.Local).AddTicks(1881), 943490, 24, "3561859" },
                    { 37, new DateTime(2021, 4, 19, 23, 40, 33, 784, DateTimeKind.Local).AddTicks(7569), 24672, 60, "2281590" },
                    { 41, new DateTime(2021, 5, 14, 2, 44, 54, 110, DateTimeKind.Local).AddTicks(4994), 950692, 60, "5565818" },
                    { 84, new DateTime(2021, 2, 9, 10, 38, 13, 703, DateTimeKind.Local).AddTicks(6565), 927975, 60, "6943913" },
                    { 10, new DateTime(2021, 8, 3, 19, 20, 36, 831, DateTimeKind.Local).AddTicks(7653), 371, 25, "5588245" },
                    { 48, new DateTime(2020, 8, 27, 22, 7, 7, 950, DateTimeKind.Local).AddTicks(5788), 247831, 24, "1024724" },
                    { 23, new DateTime(2020, 11, 20, 22, 3, 46, 52, DateTimeKind.Local).AddTicks(5801), 324341, 57, "3396900" },
                    { 39, new DateTime(2021, 4, 7, 4, 42, 37, 172, DateTimeKind.Local).AddTicks(7294), 96780, 24, "2121220" },
                    { 58, new DateTime(2021, 6, 7, 23, 26, 41, 548, DateTimeKind.Local).AddTicks(139), 169002, 60, "1114871" },
                    { 42, new DateTime(2021, 5, 24, 4, 15, 56, 621, DateTimeKind.Local).AddTicks(8134), 263423, 43, "8364508" },
                    { 20, new DateTime(2021, 2, 6, 0, 37, 0, 129, DateTimeKind.Local).AddTicks(2803), 281348, 51, "7516266" },
                    { 25, new DateTime(2021, 4, 7, 20, 55, 6, 251, DateTimeKind.Local).AddTicks(1121), 795813, 13, "4874378" },
                    { 24, new DateTime(2021, 4, 4, 12, 26, 33, 701, DateTimeKind.Local).AddTicks(8913), 413689, 77, "6127178" },
                    { 53, new DateTime(2021, 3, 8, 9, 30, 48, 478, DateTimeKind.Local).AddTicks(3066), 831501, 45, "7132084" },
                    { 86, new DateTime(2021, 6, 16, 17, 31, 7, 901, DateTimeKind.Local).AddTicks(617), 211022, 51, "3869893" },
                    { 85, new DateTime(2021, 1, 14, 5, 51, 46, 179, DateTimeKind.Local).AddTicks(1748), 472625, 51, "1893192" },
                    { 31, new DateTime(2020, 8, 31, 2, 58, 7, 51, DateTimeKind.Local).AddTicks(5320), 729513, 38, "1765368" },
                    { 30, new DateTime(2021, 3, 20, 16, 16, 58, 214, DateTimeKind.Local).AddTicks(7443), 237030, 38, "7203217" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 80, new DateTime(2020, 9, 12, 8, 20, 56, 205, DateTimeKind.Local).AddTicks(1709), 25774, 24, "7711125" },
                    { 87, new DateTime(2021, 7, 13, 23, 57, 53, 497, DateTimeKind.Local).AddTicks(337), 945538, 46, "8542730" },
                    { 96, new DateTime(2020, 10, 26, 16, 49, 47, 59, DateTimeKind.Local).AddTicks(6284), 287359, 40, "1441594" },
                    { 76, new DateTime(2021, 5, 25, 7, 5, 35, 333, DateTimeKind.Local).AddTicks(779), 621568, 13, "5840104" },
                    { 70, new DateTime(2020, 9, 8, 0, 55, 44, 214, DateTimeKind.Local).AddTicks(7510), 497141, 41, "2860232" },
                    { 6, new DateTime(2021, 5, 30, 14, 39, 16, 266, DateTimeKind.Local).AddTicks(8993), 308960, 86, "3308623" },
                    { 40, new DateTime(2021, 2, 8, 15, 48, 12, 916, DateTimeKind.Local).AddTicks(5479), 34926, 68, "6913618" },
                    { 15, new DateTime(2020, 9, 29, 11, 26, 46, 299, DateTimeKind.Local).AddTicks(315), 468816, 58, "5718104" },
                    { 32, new DateTime(2020, 11, 18, 14, 34, 6, 680, DateTimeKind.Local).AddTicks(6908), 21345, 46, "4294191" },
                    { 8, new DateTime(2021, 8, 12, 16, 45, 42, 83, DateTimeKind.Local).AddTicks(8198), 265457, 58, "9690392" },
                    { 95, new DateTime(2020, 10, 26, 11, 41, 8, 450, DateTimeKind.Local).AddTicks(7487), 384639, 44, "4751265" },
                    { 2, new DateTime(2020, 10, 17, 11, 8, 45, 929, DateTimeKind.Local).AddTicks(2168), 939525, 44, "3731273" },
                    { 5, new DateTime(2020, 9, 19, 7, 23, 3, 666, DateTimeKind.Local).AddTicks(3793), 709883, 91, "6665816" },
                    { 77, new DateTime(2020, 9, 28, 16, 4, 24, 759, DateTimeKind.Local).AddTicks(5500), 638131, 84, "8540033" },
                    { 67, new DateTime(2021, 6, 19, 11, 2, 15, 657, DateTimeKind.Local).AddTicks(3592), 181805, 84, "3484921" },
                    { 4, new DateTime(2021, 5, 25, 9, 43, 36, 279, DateTimeKind.Local).AddTicks(4221), 538937, 86, "2850836" },
                    { 81, new DateTime(2020, 12, 31, 16, 50, 13, 250, DateTimeKind.Local).AddTicks(2679), 381161, 15, "2210016" },
                    { 13, new DateTime(2020, 10, 19, 7, 40, 31, 150, DateTimeKind.Local).AddTicks(7645), 119691, 68, "1821790" },
                    { 63, new DateTime(2020, 12, 4, 11, 59, 9, 937, DateTimeKind.Local).AddTicks(3209), 732829, 15, "9824508" },
                    { 18, new DateTime(2020, 12, 8, 21, 3, 12, 870, DateTimeKind.Local).AddTicks(571), 372462, 54, "2535634" },
                    { 62, new DateTime(2020, 11, 28, 4, 58, 33, 867, DateTimeKind.Local).AddTicks(6701), 83106, 59, "2268382" },
                    { 44, new DateTime(2020, 10, 3, 20, 33, 44, 498, DateTimeKind.Local).AddTicks(6000), 682118, 59, "7580312" },
                    { 22, new DateTime(2021, 1, 28, 4, 53, 32, 25, DateTimeKind.Local).AddTicks(6099), 344192, 69, "9050042" },
                    { 52, new DateTime(2021, 7, 14, 22, 45, 17, 724, DateTimeKind.Local).AddTicks(502), 287885, 18, "9848744" },
                    { 75, new DateTime(2021, 6, 5, 15, 48, 22, 441, DateTimeKind.Local).AddTicks(2871), 281540, 97, "7695308" },
                    { 46, new DateTime(2021, 4, 11, 16, 10, 53, 943, DateTimeKind.Local).AddTicks(6240), 507225, 65, "7491020" },
                    { 51, new DateTime(2021, 2, 8, 5, 12, 33, 788, DateTimeKind.Local).AddTicks(867), 59647, 55, "1584960" },
                    { 36, new DateTime(2021, 3, 12, 16, 20, 53, 730, DateTimeKind.Local).AddTicks(3229), 478566, 55, "7752109" },
                    { 27, new DateTime(2021, 2, 5, 21, 34, 41, 55, DateTimeKind.Local).AddTicks(6592), 802247, 89, "5107724" },
                    { 92, new DateTime(2020, 9, 2, 6, 31, 33, 574, DateTimeKind.Local).AddTicks(7370), 420280, 37, "6668717" },
                    { 71, new DateTime(2020, 11, 27, 18, 18, 53, 859, DateTimeKind.Local).AddTicks(6028), 780852, 22, "9084539" },
                    { 78, new DateTime(2020, 9, 23, 23, 9, 39, 526, DateTimeKind.Local).AddTicks(6231), 963916, 6, "4086573" },
                    { 49, new DateTime(2020, 8, 28, 21, 14, 38, 661, DateTimeKind.Local).AddTicks(37), 858477, 42, "6792496" },
                    { 12, new DateTime(2020, 8, 27, 2, 11, 33, 246, DateTimeKind.Local).AddTicks(9890), 382418, 9, "6499487" },
                    { 98, new DateTime(2021, 8, 11, 6, 48, 14, 562, DateTimeKind.Local).AddTicks(2451), 816078, 66, "7076823" },
                    { 97, new DateTime(2021, 3, 4, 21, 11, 56, 227, DateTimeKind.Local).AddTicks(4712), 831365, 66, "2506208" },
                    { 59, new DateTime(2021, 3, 31, 18, 58, 41, 78, DateTimeKind.Local).AddTicks(8437), 972606, 14, "4117872" },
                    { 11, new DateTime(2020, 8, 25, 15, 31, 36, 451, DateTimeKind.Local).AddTicks(4926), 493090, 76, "6054352" },
                    { 64, new DateTime(2020, 11, 1, 14, 43, 36, 775, DateTimeKind.Local).AddTicks(2204), 910748, 12, "6764229" },
                    { 7, new DateTime(2020, 12, 14, 21, 15, 31, 279, DateTimeKind.Local).AddTicks(9400), 911590, 12, "5895913" },
                    { 57, new DateTime(2020, 8, 24, 15, 40, 9, 942, DateTimeKind.Local).AddTicks(9962), 367098, 74, "2668242" },
                    { 21, new DateTime(2020, 11, 2, 22, 43, 39, 445, DateTimeKind.Local).AddTicks(9904), 79484, 10, "3623341" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 83, new DateTime(2021, 3, 11, 20, 52, 12, 199, DateTimeKind.Local).AddTicks(2902), 268483, 1, "2032654" },
                    { 16, new DateTime(2020, 11, 10, 6, 32, 53, 358, DateTimeKind.Local).AddTicks(961), 548178, 9, "9301323" },
                    { 79, new DateTime(2020, 9, 5, 16, 44, 27, 848, DateTimeKind.Local).AddTicks(1521), 103523, 1, "9319896" },
                    { 69, new DateTime(2020, 11, 5, 6, 50, 39, 587, DateTimeKind.Local).AddTicks(2408), 449502, 1, "6164752" },
                    { 65, new DateTime(2021, 3, 16, 23, 38, 16, 385, DateTimeKind.Local).AddTicks(1838), 414154, 1, "1204216" },
                    { 43, new DateTime(2021, 3, 12, 17, 52, 18, 290, DateTimeKind.Local).AddTicks(165), 296928, 1, "6494550" },
                    { 1, new DateTime(2020, 10, 17, 17, 51, 2, 563, DateTimeKind.Local).AddTicks(4982), 775642, 1, "5844822" },
                    { 19, new DateTime(2021, 4, 3, 9, 55, 42, 57, DateTimeKind.Local).AddTicks(237), 382855, 20, "9196565" },
                    { 38, new DateTime(2021, 5, 7, 14, 45, 32, 548, DateTimeKind.Local).AddTicks(2421), 103617, 2, "1294354" },
                    { 100, new DateTime(2021, 4, 29, 0, 34, 25, 510, DateTimeKind.Local).AddTicks(6119), 942063, 85, "4841947" },
                    { 82, new DateTime(2020, 8, 19, 19, 53, 52, 118, DateTimeKind.Local).AddTicks(4110), 353820, 85, "6527352" },
                    { 73, new DateTime(2020, 10, 29, 3, 7, 55, 356, DateTimeKind.Local).AddTicks(7379), 176225, 85, "5232361" },
                    { 56, new DateTime(2020, 9, 25, 9, 48, 6, 390, DateTimeKind.Local).AddTicks(5299), 499617, 58, "9972154" },
                    { 74, new DateTime(2020, 12, 7, 4, 19, 0, 850, DateTimeKind.Local).AddTicks(8868), 667656, 1, "5442014" },
                    { 66, new DateTime(2021, 2, 6, 16, 12, 16, 251, DateTimeKind.Local).AddTicks(1434), 240575, 42, "7532284" },
                    { 29, new DateTime(2020, 9, 23, 12, 42, 57, 828, DateTimeKind.Local).AddTicks(3733), 338091, 9, "6417027" },
                    { 35, new DateTime(2020, 12, 13, 4, 38, 47, 97, DateTimeKind.Local).AddTicks(3207), 680309, 29, "8529752" },
                    { 99, new DateTime(2020, 12, 31, 2, 39, 54, 618, DateTimeKind.Local).AddTicks(5571), 44287, 49, "1132767" },
                    { 72, new DateTime(2020, 9, 2, 13, 13, 55, 3, DateTimeKind.Local).AddTicks(3895), 28292, 49, "5152325" },
                    { 61, new DateTime(2020, 8, 23, 12, 25, 1, 221, DateTimeKind.Local).AddTicks(2369), 687694, 49, "5864010" },
                    { 55, new DateTime(2021, 5, 11, 1, 28, 24, 923, DateTimeKind.Local).AddTicks(4417), 175861, 98, "7795804" },
                    { 28, new DateTime(2020, 12, 17, 21, 36, 45, 395, DateTimeKind.Local).AddTicks(1608), 597163, 98, "3270036" },
                    { 17, new DateTime(2021, 3, 14, 4, 32, 50, 608, DateTimeKind.Local).AddTicks(6705), 694452, 98, "9863507" },
                    { 101, new DateTime(2021, 2, 1, 17, 45, 22, 170, DateTimeKind.Local).AddTicks(4629), 524754, 11, "7077059" },
                    { 93, new DateTime(2021, 3, 11, 9, 10, 44, 381, DateTimeKind.Local).AddTicks(1178), 905753, 11, "1183720" },
                    { 54, new DateTime(2020, 8, 18, 20, 4, 10, 329, DateTimeKind.Local).AddTicks(932), 989291, 11, "3091908" },
                    { 90, new DateTime(2021, 3, 25, 6, 43, 12, 121, DateTimeKind.Local).AddTicks(4150), 575974, 82, "8654687" },
                    { 33, new DateTime(2021, 1, 14, 12, 18, 22, 710, DateTimeKind.Local).AddTicks(172), 847362, 29, "9641210" },
                    { 68, new DateTime(2020, 11, 2, 8, 56, 17, 189, DateTimeKind.Local).AddTicks(5249), 864575, 82, "1222461" },
                    { 94, new DateTime(2021, 3, 6, 15, 53, 19, 793, DateTimeKind.Local).AddTicks(610), 216, 94, "5117892" },
                    { 91, new DateTime(2020, 11, 13, 17, 18, 27, 812, DateTimeKind.Local).AddTicks(8637), 743335, 87, "5784675" },
                    { 89, new DateTime(2020, 8, 31, 13, 35, 50, 19, DateTimeKind.Local).AddTicks(6037), 843746, 87, "2572988" },
                    { 50, new DateTime(2020, 10, 23, 21, 34, 5, 654, DateTimeKind.Local).AddTicks(5969), 782402, 87, "5344059" },
                    { 34, new DateTime(2021, 7, 12, 12, 46, 16, 831, DateTimeKind.Local).AddTicks(9804), 289027, 87, "7592483" },
                    { 88, new DateTime(2020, 12, 18, 23, 44, 11, 221, DateTimeKind.Local).AddTicks(4322), 268232, 78, "6323404" },
                    { 60, new DateTime(2020, 9, 20, 13, 4, 42, 724, DateTimeKind.Local).AddTicks(2701), 696818, 36, "3623908" },
                    { 26, new DateTime(2021, 3, 29, 18, 10, 4, 731, DateTimeKind.Local).AddTicks(8135), 952162, 36, "3522295" },
                    { 45, new DateTime(2021, 7, 1, 20, 3, 22, 446, DateTimeKind.Local).AddTicks(4452), 288664, 3, "5365843" },
                    { 47, new DateTime(2020, 10, 19, 12, 26, 57, 263, DateTimeKind.Local).AddTicks(6554), 237838, 29, "5377363" },
                    { 9, new DateTime(2021, 6, 2, 6, 40, 20, 26, DateTimeKind.Local).AddTicks(208), 60755, 82, "4292864" },
                    { 3, new DateTime(2021, 5, 18, 12, 4, 13, 114, DateTimeKind.Local).AddTicks(1272), 58076, 5, "2310581" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 4, 73, 143, 501810, new DateTime(2020, 11, 9, 23, 5, 19, 575, DateTimeKind.Local).AddTicks(6294), "A quasi laudantium mollitia dolores commodi numquam dolorem id.\nQuos numquam voluptatum.\nPerspiciatis reprehenderit non necessitatibus cumque eos dolorem reprehenderit quidem.\nUt inventore omnis.\nFugit odio odio officia illo eum consequatur.\nLaborum ut quam culpa voluptas voluptatum totam qui voluptas." },
                    { 176, 23, 120, 770793, new DateTime(2021, 7, 28, 17, 0, 40, 968, DateTimeKind.Local).AddTicks(7898), "Officiis nesciunt omnis. Voluptas et tenetur qui. Eius ullam maxime nesciunt. Voluptatibus qui quo sunt maxime soluta molestiae." },
                    { 261, 23, 137, 934448, new DateTime(2021, 3, 22, 9, 31, 43, 362, DateTimeKind.Local).AddTicks(7255), "enim" },
                    { 262, 23, 35, 997283, new DateTime(2020, 8, 21, 14, 47, 30, 719, DateTimeKind.Local).AddTicks(8880), "Repellat delectus vero ut reprehenderit et hic sed repudiandae.\nQui suscipit cum voluptatem officiis quas temporibus." },
                    { 291, 23, 72, 101485, new DateTime(2020, 9, 15, 17, 29, 4, 791, DateTimeKind.Local).AddTicks(4396), "Sed possimus debitis quaerat exercitationem voluptatem quia." },
                    { 391, 23, 96, 481845, new DateTime(2021, 8, 5, 18, 12, 51, 113, DateTimeKind.Local).AddTicks(5561), "Laborum dignissimos est. Eum ut exercitationem nobis quod est est. Adipisci corporis modi ullam enim. Officia error recusandae illum unde qui eos voluptatem." },
                    { 417, 23, 143, 599696, new DateTime(2020, 10, 26, 7, 11, 10, 152, DateTimeKind.Local).AddTicks(8899), "Provident inventore ipsa molestias quo. Enim eligendi consequuntur necessitatibus est. Laboriosam odit deleniti aut voluptatibus ipsum dolores ut error sed." },
                    { 466, 23, 17, 684691, new DateTime(2021, 8, 11, 18, 56, 55, 518, DateTimeKind.Local).AddTicks(4214), "Est aut consequuntur.\nFuga dolor quae sint nostrum laboriosam.\nNumquam vel qui sed sit id.\nAut sit et.\nMolestiae repellendus et.\nAmet deleniti officiis neque sit molestiae at fuga dicta natus." },
                    { 497, 23, 130, 213556, new DateTime(2021, 7, 30, 21, 32, 49, 162, DateTimeKind.Local).AddTicks(1444), "Enim sed voluptates amet non magni." },
                    { 502, 23, 10, 894727, new DateTime(2021, 2, 2, 20, 12, 8, 598, DateTimeKind.Local).AddTicks(5142), "rerum" },
                    { 589, 23, 74, 906715, new DateTime(2021, 4, 1, 10, 22, 42, 784, DateTimeKind.Local).AddTicks(2260), "Saepe esse in ut quo nisi est." },
                    { 24, 37, 145, 49631, new DateTime(2021, 8, 7, 8, 9, 30, 545, DateTimeKind.Local).AddTicks(7686), "Ipsam ratione dolores est." },
                    { 77, 37, 19, 606110, new DateTime(2020, 12, 6, 14, 27, 56, 731, DateTimeKind.Local).AddTicks(1097), "Quidem pariatur dolorum libero est quam est eveniet quidem qui.\nTotam et et aut.\nQuam debitis laborum.\nReiciendis quo exercitationem voluptas." },
                    { 110, 37, 140, 889395, new DateTime(2021, 5, 19, 21, 58, 33, 357, DateTimeKind.Local).AddTicks(397), "Animi tempore et deleniti cupiditate est autem. Voluptas est eum animi. Culpa magnam et beatae aliquam quis. Occaecati perspiciatis porro quos. Harum temporibus laudantium nisi eum et qui id. Inventore quia dolorum modi libero et." },
                    { 283, 37, 77, 967449, new DateTime(2021, 5, 27, 11, 23, 25, 441, DateTimeKind.Local).AddTicks(8573), "Libero optio voluptatem et." },
                    { 328, 37, 49, 929267, new DateTime(2020, 12, 31, 15, 12, 9, 877, DateTimeKind.Local).AddTicks(1337), "Dicta nam neque commodi.\nPossimus modi necessitatibus quam.\nOfficiis fugiat in voluptas molestias sint debitis.\nA maxime id delectus ratione ullam sit numquam dignissimos ratione.\nEos veritatis harum consequatur non fugiat consequatur.\nExpedita tempora non sit quas aut sed voluptatem sint nemo." },
                    { 167, 23, 132, 969128, new DateTime(2021, 5, 3, 10, 20, 36, 542, DateTimeKind.Local).AddTicks(193), "repudiandae" },
                    { 112, 23, 104, 457999, new DateTime(2020, 10, 16, 9, 37, 34, 760, DateTimeKind.Local).AddTicks(1232), "Impedit error consequatur illo tenetur aut eum necessitatibus eveniet repudiandae." },
                    { 78, 23, 142, 157916, new DateTime(2021, 7, 4, 6, 6, 55, 305, DateTimeKind.Local).AddTicks(7445), "animi" },
                    { 2, 23, 134, 658269, new DateTime(2021, 6, 11, 16, 35, 32, 328, DateTimeKind.Local).AddTicks(9720), "Autem non neque dolore provident eos vero magnam repellat ad. Esse doloremque odio excepturi optio voluptatem alias enim maxime. Est voluptas atque excepturi magni qui nihil ducimus. Accusamus quis qui dolorem qui." },
                    { 275, 25, 52, 851849, new DateTime(2021, 3, 13, 6, 10, 15, 130, DateTimeKind.Local).AddTicks(3624), "Eos dolores adipisci sequi illo dolores voluptas.\nQuisquam eos ullam.\nEt omnis laborum et.\nConsequatur beatae aperiam rerum omnis hic nemo et.\nMagni quibusdam consequatur quis perspiciatis dolor magni aut nulla.\nQui molestias quis enim et suscipit accusantium qui." },
                    { 324, 25, 89, 343, new DateTime(2020, 11, 13, 21, 28, 53, 869, DateTimeKind.Local).AddTicks(9684), "Ut laboriosam voluptates quia nihil et explicabo qui.\nEt labore ex unde corrupti magni ullam nesciunt consequatur exercitationem." },
                    { 408, 25, 113, 302258, new DateTime(2020, 11, 12, 20, 15, 56, 919, DateTimeKind.Local).AddTicks(4796), "Aut est dolore id sequi voluptatem. Fugiat nulla qui ex aperiam autem reprehenderit aut. Tempore odio ratione. Vitae minus commodi ut. Qui sit aliquid qui officia voluptas assumenda tempore. Id facere magni quisquam at sit fugit ullam culpa beatae." },
                    { 7, 76, 67, 284854, new DateTime(2021, 3, 4, 0, 30, 32, 971, DateTimeKind.Local).AddTicks(4498), "Et placeat velit nostrum delectus ratione rerum atque rerum." },
                    { 120, 76, 133, 281498, new DateTime(2021, 8, 15, 22, 6, 58, 641, DateTimeKind.Local).AddTicks(6752), "Fugit praesentium maxime corporis qui ut accusamus aut." },
                    { 312, 76, 47, 356406, new DateTime(2020, 10, 24, 20, 34, 19, 766, DateTimeKind.Local).AddTicks(6141), "Repellat quod dolores dicta voluptas et omnis tempore occaecati." },
                    { 481, 76, 140, 183503, new DateTime(2021, 7, 11, 7, 35, 37, 459, DateTimeKind.Local).AddTicks(8089), "Sapiente pariatur itaque dolores aut alias.\nVoluptatem ipsa tenetur debitis incidunt magnam deserunt." },
                    { 344, 37, 78, 408267, new DateTime(2021, 7, 11, 8, 26, 6, 520, DateTimeKind.Local).AddTicks(3416), "est" },
                    { 563, 76, 50, 944694, new DateTime(2021, 7, 13, 16, 46, 45, 493, DateTimeKind.Local).AddTicks(6969), "nesciunt" },
                    { 161, 42, 46, 15405, new DateTime(2021, 6, 12, 18, 16, 0, 918, DateTimeKind.Local).AddTicks(4078), "corporis" },
                    { 187, 42, 120, 877655, new DateTime(2020, 9, 21, 15, 27, 37, 75, DateTimeKind.Local).AddTicks(5565), "Harum et dolor reiciendis sunt eveniet.\nVoluptatibus nam unde pariatur.\nOdit temporibus quis provident qui.\nSapiente quisquam dolores beatae corrupti qui.\nMaiores sed et et dolorum saepe blanditiis nobis." },
                    { 220, 42, 139, 587819, new DateTime(2021, 5, 6, 10, 13, 51, 153, DateTimeKind.Local).AddTicks(4254), "Voluptatem sit et perspiciatis. Sapiente deserunt blanditiis non quos quia dolores amet. Quos eos labore aut qui." },
                    { 365, 42, 144, 202954, new DateTime(2021, 3, 4, 18, 14, 53, 461, DateTimeKind.Local).AddTicks(163), "sint" },
                    { 490, 42, 113, 170911, new DateTime(2021, 5, 5, 3, 4, 53, 562, DateTimeKind.Local).AddTicks(8143), "Nemo voluptate sint corporis veritatis qui consequuntur rerum culpa.\nMolestiae qui libero.\nEarum at nobis." },
                    { 501, 42, 2, 52210, new DateTime(2021, 5, 17, 19, 59, 24, 129, DateTimeKind.Local).AddTicks(5908), "exercitationem" },
                    { 546, 42, 145, 865740, new DateTime(2020, 12, 19, 15, 22, 55, 602, DateTimeKind.Local).AddTicks(8669), "Voluptatibus est quia pariatur et ad.\nPerferendis enim et ea repellendus incidunt quia.\nConsectetur aut ut et odit laudantium.\nAccusamus aperiam quas quibusdam veniam amet quibusdam sint voluptatem.\nHic sunt qui sint neque." },
                    { 93, 42, 24, 194121, new DateTime(2020, 8, 27, 7, 27, 13, 112, DateTimeKind.Local).AddTicks(2168), "In et distinctio rerum.\nQuasi cumque ut consequuntur et tempora.\nAliquid ex sint molestiae quaerat natus beatae consectetur." },
                    { 191, 25, 40, 625415, new DateTime(2021, 2, 25, 11, 57, 0, 22, DateTimeKind.Local).AddTicks(4850), "Eaque odio eum quos modi error at temporibus asperiores.\nEaque perferendis facere iusto voluptatem." },
                    { 367, 37, 125, 652882, new DateTime(2020, 12, 21, 21, 18, 55, 394, DateTimeKind.Local).AddTicks(9650), "Est molestiae excepturi provident a adipisci. Sapiente accusantium ipsam. Delectus impedit molestiae numquam tempore sapiente odit debitis perspiciatis qui." },
                    { 113, 41, 117, 607216, new DateTime(2021, 5, 17, 14, 53, 14, 740, DateTimeKind.Local).AddTicks(8675), "Ipsa et at officia libero aut harum. Temporibus deleniti et est. Vel odio et occaecati iusto quia autem alias." },
                    { 31, 14, 42, 379085, new DateTime(2021, 2, 1, 19, 59, 33, 154, DateTimeKind.Local).AddTicks(2523), "Voluptas culpa vel pariatur.\nVoluptatem ut consequatur sint deleniti qui atque quibusdam minima quia.\nDeserunt itaque exercitationem aut voluptates hic qui qui ut aut.\nAliquam occaecati non consequuntur sit." },
                    { 106, 14, 5, 482655, new DateTime(2021, 1, 27, 4, 6, 24, 951, DateTimeKind.Local).AddTicks(6155), "rerum" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 139, 14, 108, 220815, new DateTime(2021, 2, 12, 16, 7, 39, 524, DateTimeKind.Local).AddTicks(8755), "Hic quo vel consequatur voluptas velit sint ea quasi quibusdam." },
                    { 461, 14, 72, 666666, new DateTime(2020, 8, 21, 20, 12, 55, 527, DateTimeKind.Local).AddTicks(7420), "Aliquam recusandae veniam ut corrupti consectetur libero.\nQui rem reprehenderit commodi aliquid ut consequatur totam voluptatem est.\nAb voluptatem quam consequatur fugiat." },
                    { 512, 14, 25, 360939, new DateTime(2021, 2, 4, 3, 10, 5, 499, DateTimeKind.Local).AddTicks(6147), "illum" },
                    { 39, 39, 29, 593510, new DateTime(2021, 4, 18, 18, 17, 51, 87, DateTimeKind.Local).AddTicks(6401), "Voluptas perspiciatis nobis ad rerum. Quia delectus omnis suscipit tempora. Illo voluptates non dolore est amet omnis necessitatibus rem est. Temporibus quia amet sunt veritatis quos est neque quo et. Sint est quia possimus iure quidem est non natus." },
                    { 59, 39, 29, 297641, new DateTime(2021, 7, 16, 21, 2, 36, 978, DateTimeKind.Local).AddTicks(2239), "Fuga nesciunt corporis corporis voluptatem." },
                    { 205, 39, 2, 178812, new DateTime(2020, 9, 14, 1, 53, 1, 555, DateTimeKind.Local).AddTicks(7902), "Totam esse inventore omnis. Est enim repellat adipisci reiciendis est officiis excepturi. Aut reiciendis voluptate sint in aut voluptate qui. Culpa dolorem quo et aut. Similique rerum qui quasi praesentium at." },
                    { 335, 39, 77, 845095, new DateTime(2021, 6, 26, 14, 41, 42, 612, DateTimeKind.Local).AddTicks(8183), "est" },
                    { 413, 39, 114, 239269, new DateTime(2020, 11, 25, 15, 26, 37, 362, DateTimeKind.Local).AddTicks(1378), "ducimus" },
                    { 202, 48, 81, 936977, new DateTime(2020, 11, 15, 14, 25, 45, 326, DateTimeKind.Local).AddTicks(3045), "aspernatur" },
                    { 223, 48, 42, 528078, new DateTime(2021, 2, 18, 3, 22, 22, 613, DateTimeKind.Local).AddTicks(4087), "Placeat ratione accusantium ducimus doloremque assumenda debitis et id voluptate." },
                    { 277, 48, 99, 678414, new DateTime(2021, 1, 24, 2, 13, 26, 308, DateTimeKind.Local).AddTicks(5114), "Vero sint et sequi velit saepe et eos." },
                    { 284, 48, 22, 294245, new DateTime(2021, 7, 29, 22, 29, 49, 782, DateTimeKind.Local).AddTicks(98), "Quia voluptate similique.\nNulla similique voluptas ullam qui vitae quia sunt qui.\nPorro a a omnis rerum officiis maxime." },
                    { 329, 48, 37, 280793, new DateTime(2021, 4, 6, 7, 42, 29, 500, DateTimeKind.Local).AddTicks(3631), "Velit harum sed occaecati et ut doloribus ipsam beatae." },
                    { 487, 10, 79, 659596, new DateTime(2021, 5, 16, 21, 47, 22, 426, DateTimeKind.Local).AddTicks(9410), "Neque dolor facilis et. Eius quasi qui adipisci et sit. Odio iure est natus et aut. Voluptatem nihil dolores quasi ipsam velit quia temporibus sed. Ea voluptatem cum distinctio eveniet architecto vero." },
                    { 437, 10, 68, 135151, new DateTime(2021, 5, 7, 19, 10, 10, 741, DateTimeKind.Local).AddTicks(1324), "inventore" },
                    { 300, 10, 113, 918462, new DateTime(2020, 11, 3, 13, 7, 43, 883, DateTimeKind.Local).AddTicks(2686), "Inventore asperiores corporis aut expedita tempora saepe. Officia enim natus. Error sed autem a fugit ab dolore. Ab rem ea accusamus similique est." },
                    { 84, 10, 70, 356884, new DateTime(2021, 2, 9, 9, 48, 4, 330, DateTimeKind.Local).AddTicks(6775), "Est eveniet impedit necessitatibus." },
                    { 198, 41, 53, 310510, new DateTime(2020, 9, 9, 10, 18, 26, 58, DateTimeKind.Local).AddTicks(2509), "Nihil qui tenetur ea ex deleniti." },
                    { 289, 41, 8, 261663, new DateTime(2021, 2, 12, 9, 37, 14, 379, DateTimeKind.Local).AddTicks(4864), "Iste iusto maxime perferendis. Aut optio saepe aut. Saepe ea autem ut aspernatur quibusdam corporis." },
                    { 388, 41, 147, 438790, new DateTime(2020, 12, 1, 4, 49, 18, 608, DateTimeKind.Local).AddTicks(7011), "Enim temporibus ex." },
                    { 479, 41, 41, 683818, new DateTime(2020, 12, 15, 18, 6, 38, 349, DateTimeKind.Local).AddTicks(19), "exercitationem" },
                    { 492, 41, 7, 276468, new DateTime(2020, 9, 5, 19, 27, 15, 251, DateTimeKind.Local).AddTicks(6130), "Minima maiores provident possimus perspiciatis commodi deleniti omnis distinctio." },
                    { 519, 41, 93, 263543, new DateTime(2021, 6, 18, 5, 39, 24, 366, DateTimeKind.Local).AddTicks(986), "enim" },
                    { 586, 41, 77, 613577, new DateTime(2021, 1, 5, 6, 1, 15, 936, DateTimeKind.Local).AddTicks(3384), "Debitis inventore doloribus voluptas assumenda aut quasi. Quia quas consequatur vitae deserunt est labore quia facere. Esse dicta ipsam eum quas pariatur. Sed laborum nemo unde." },
                    { 524, 37, 113, 900762, new DateTime(2020, 8, 26, 15, 24, 29, 583, DateTimeKind.Local).AddTicks(63), "Sunt consequatur maiores ratione sapiente laborum." },
                    { 199, 58, 68, 59017, new DateTime(2020, 10, 1, 14, 10, 6, 315, DateTimeKind.Local).AddTicks(649), "Unde ex qui fugit illum suscipit velit. Unde suscipit reprehenderit. Aut qui sequi aliquid sed nihil perspiciatis animi at voluptatem. Esse laborum deleniti et porro et qui voluptatibus quia dolore. Necessitatibus error dolores earum omnis voluptatem sapiente nisi." },
                    { 38, 84, 148, 680274, new DateTime(2021, 2, 6, 12, 53, 16, 548, DateTimeKind.Local).AddTicks(3659), "Libero illum corporis et sequi." },
                    { 73, 84, 64, 303093, new DateTime(2020, 12, 14, 10, 31, 1, 504, DateTimeKind.Local).AddTicks(9235), "dolore" },
                    { 215, 84, 60, 109275, new DateTime(2020, 8, 30, 12, 9, 33, 640, DateTimeKind.Local).AddTicks(8280), "Itaque minus ea inventore sapiente architecto mollitia quia ut qui.\nAssumenda illo et aut eveniet ut.\nNon hic delectus quam quaerat perferendis minus quis natus dignissimos." },
                    { 416, 84, 59, 655251, new DateTime(2021, 2, 16, 11, 44, 45, 547, DateTimeKind.Local).AddTicks(2007), "Qui incidunt tempora qui omnis consequatur. Molestiae sapiente omnis dignissimos. Occaecati enim quas qui suscipit voluptatem accusamus. Unde reprehenderit consequuntur. Est sunt velit veritatis praesentium in rerum harum. Nostrum quia numquam." },
                    { 494, 84, 147, 516331, new DateTime(2020, 12, 23, 12, 15, 19, 354, DateTimeKind.Local).AddTicks(2777), "Doloremque consequatur quia labore quo delectus minus soluta earum. Non pariatur doloribus impedit sint dolor eum repellat excepturi. Molestiae molestiae alias est consectetur nemo. Temporibus adipisci nobis. Deserunt aliquam dolores tenetur est omnis nemo." },
                    { 521, 84, 132, 580488, new DateTime(2021, 3, 5, 18, 3, 28, 511, DateTimeKind.Local).AddTicks(4457), "Corporis repellendus rerum." },
                    { 19, 10, 91, 549717, new DateTime(2021, 3, 15, 18, 35, 0, 653, DateTimeKind.Local).AddTicks(3297), "Eos delectus ut est autem." },
                    { 297, 58, 10, 973080, new DateTime(2021, 7, 19, 9, 24, 3, 571, DateTimeKind.Local).AddTicks(9106), "Dolorum fugiat aliquam fugiat consectetur eos iure pariatur facere voluptas. Voluptatem velit doloremque culpa quo rerum animi molestiae qui. Alias deleniti consectetur ea quia esse quibusdam omnis. Ratione et velit ab ullam incidunt placeat ad aut occaecati. Ducimus reprehenderit quo iusto ducimus voluptas quaerat voluptate." },
                    { 114, 25, 41, 198806, new DateTime(2021, 2, 5, 4, 30, 11, 512, DateTimeKind.Local).AddTicks(2149), "Eveniet nihil quia.\nRerum rerum est distinctio.\nReprehenderit eaque officia autem accusamus dolorem." },
                    { 465, 24, 93, 921099, new DateTime(2020, 9, 7, 1, 58, 28, 671, DateTimeKind.Local).AddTicks(6023), "Dicta commodi ut nisi accusantium pariatur est nihil. Qui hic et aut minus vel similique qui aut. Necessitatibus corporis iusto enim enim iste in sapiente et." },
                    { 463, 24, 54, 410410, new DateTime(2021, 4, 8, 6, 47, 13, 12, DateTimeKind.Local).AddTicks(8574), "Deleniti sed quas vitae esse veniam." },
                    { 394, 32, 127, 609743, new DateTime(2020, 9, 16, 16, 0, 37, 163, DateTimeKind.Local).AddTicks(5640), "Quae dignissimos quia a.\nLaudantium dolore consequatur enim.\nMollitia aut totam.\nRepudiandae ipsam numquam facere recusandae.\nFuga delectus necessitatibus cupiditate." },
                    { 431, 32, 11, 35989, new DateTime(2021, 1, 28, 12, 40, 40, 871, DateTimeKind.Local).AddTicks(1035), "Maiores reprehenderit ea consequuntur itaque repudiandae doloremque sunt ratione.\nVel sed eum." },
                    { 472, 32, 137, 203640, new DateTime(2020, 12, 4, 15, 19, 2, 763, DateTimeKind.Local).AddTicks(5478), "Iusto dolor porro odio repellendus culpa. Itaque dolorum sit quidem enim adipisci qui ipsum. Dolores qui quo maxime tempora occaecati provident maxime. Tenetur blanditiis iusto amet. Placeat est rerum non ipsa animi itaque." },
                    { 555, 32, 99, 321996, new DateTime(2020, 8, 22, 23, 2, 8, 42, DateTimeKind.Local).AddTicks(7327), "Eos deleniti aspernatur.\nUt accusantium ab dolor explicabo hic beatae ipsam." },
                    { 571, 32, 107, 551326, new DateTime(2020, 12, 30, 15, 30, 58, 34, DateTimeKind.Local).AddTicks(3118), "voluptatem" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 573, 32, 137, 997178, new DateTime(2021, 5, 26, 9, 53, 56, 473, DateTimeKind.Local).AddTicks(7773), "Impedit ipsam laborum quo alias similique voluptate.\nBlanditiis sint impedit suscipit a recusandae labore minima deleniti." },
                    { 26, 87, 47, 443372, new DateTime(2020, 12, 30, 23, 3, 45, 563, DateTimeKind.Local).AddTicks(7847), "Quam voluptatibus ut omnis id. Ut sequi id ut. Ut blanditiis porro ipsum blanditiis sit." },
                    { 81, 87, 29, 163949, new DateTime(2020, 11, 2, 6, 59, 9, 636, DateTimeKind.Local).AddTicks(9802), "Est libero debitis quaerat. Nesciunt qui officia dolor unde. Necessitatibus nemo blanditiis quia et perferendis. Veniam qui cumque vero repudiandae voluptatem. Fuga est modi ducimus. Veritatis consequuntur ut voluptatem ut." },
                    { 156, 87, 9, 995743, new DateTime(2021, 8, 9, 22, 14, 3, 144, DateTimeKind.Local).AddTicks(9767), "Qui ipsum rerum ducimus aut dolorem. Consequatur autem voluptas. Placeat eum quis reiciendis commodi delectus." },
                    { 268, 87, 39, 39115, new DateTime(2020, 9, 5, 22, 52, 18, 196, DateTimeKind.Local).AddTicks(9094), "Perspiciatis architecto sit cum." },
                    { 313, 87, 8, 792093, new DateTime(2021, 8, 7, 11, 14, 3, 391, DateTimeKind.Local).AddTicks(7862), "Voluptatem vitae aperiam provident possimus error aut reiciendis.\nUt officiis voluptas porro suscipit cum.\nVeritatis architecto fuga ea corrupti hic quibusdam maxime itaque provident.\nIste in eveniet aut distinctio est corporis omnis." },
                    { 8, 96, 102, 406073, new DateTime(2021, 8, 17, 12, 14, 11, 874, DateTimeKind.Local).AddTicks(3913), "Deleniti reiciendis aspernatur.\nAut sint consequatur qui quia et impedit dolorum repellendus.\nAut pariatur molestias qui quisquam saepe quo.\nImpedit id sunt odio delectus et.\nIste minus tenetur sed ullam aut qui reprehenderit error." },
                    { 162, 96, 1, 469786, new DateTime(2021, 2, 13, 3, 15, 37, 952, DateTimeKind.Local).AddTicks(6308), "magnam" },
                    { 276, 96, 98, 97094, new DateTime(2020, 10, 8, 9, 59, 13, 861, DateTimeKind.Local).AddTicks(6503), "Facilis dignissimos rerum. Vitae amet necessitatibus et consectetur commodi ut beatae ut mollitia. Ab sunt recusandae hic rem ipsum beatae. Esse corporis facere dolores officiis est et repellendus hic. Nisi ut laboriosam. Sit voluptas voluptatum natus." },
                    { 340, 96, 45, 941113, new DateTime(2021, 4, 8, 4, 54, 25, 309, DateTimeKind.Local).AddTicks(6663), "facere" },
                    { 390, 32, 109, 81174, new DateTime(2021, 2, 20, 9, 7, 27, 181, DateTimeKind.Local).AddTicks(4495), "Modi quam saepe necessitatibus alias voluptas sed unde." },
                    { 170, 32, 123, 936056, new DateTime(2021, 5, 26, 18, 16, 22, 715, DateTimeKind.Local).AddTicks(7554), "Et praesentium autem eligendi nihil." },
                    { 137, 32, 21, 745522, new DateTime(2020, 12, 17, 22, 16, 11, 502, DateTimeKind.Local).AddTicks(277), "dolorum" },
                    { 43, 32, 115, 697161, new DateTime(2021, 8, 10, 9, 30, 36, 429, DateTimeKind.Local).AddTicks(7412), "Asperiores dicta mollitia hic laboriosam." },
                    { 111, 66, 136, 162475, new DateTime(2020, 8, 23, 16, 35, 13, 778, DateTimeKind.Local).AddTicks(4155), "accusantium" },
                    { 157, 66, 106, 620474, new DateTime(2021, 5, 17, 13, 22, 41, 550, DateTimeKind.Local).AddTicks(3644), "cum" },
                    { 317, 66, 18, 575961, new DateTime(2021, 3, 20, 15, 21, 28, 285, DateTimeKind.Local).AddTicks(7558), "sequi" },
                    { 353, 66, 9, 178456, new DateTime(2021, 1, 14, 9, 35, 46, 657, DateTimeKind.Local).AddTicks(8260), "Saepe cupiditate ut." },
                    { 491, 66, 49, 239013, new DateTime(2021, 8, 8, 22, 40, 42, 475, DateTimeKind.Local).AddTicks(7520), "Sunt nemo modi sed ducimus ut ex et necessitatibus. Eos perferendis quos eligendi enim qui sed. Placeat nihil autem nulla veniam voluptatibus. Consequuntur illum sed quis ut dicta eum totam consequuntur non. Et officia adipisci ut nam enim optio ab itaque. Commodi asperiores reiciendis officia officiis minima dolor incidunt velit et." },
                    { 545, 66, 39, 632113, new DateTime(2021, 3, 5, 9, 25, 32, 62, DateTimeKind.Local).AddTicks(343), "Consequuntur quis molestias atque nobis quas ipsam quae.\nConsequuntur omnis ut autem." },
                    { 580, 66, 44, 137205, new DateTime(2021, 7, 9, 8, 14, 12, 209, DateTimeKind.Local).AddTicks(7598), "maxime" },
                    { 370, 96, 83, 177284, new DateTime(2021, 2, 18, 11, 53, 43, 376, DateTimeKind.Local).AddTicks(4560), "autem" },
                    { 9, 71, 51, 266054, new DateTime(2021, 3, 10, 10, 41, 20, 681, DateTimeKind.Local).AddTicks(1618), "provident" },
                    { 13, 71, 139, 221690, new DateTime(2021, 8, 6, 23, 13, 6, 325, DateTimeKind.Local).AddTicks(6430), "Nisi est rerum occaecati quibusdam eveniet aliquid accusantium." },
                    { 54, 71, 65, 380436, new DateTime(2021, 3, 26, 3, 38, 11, 380, DateTimeKind.Local).AddTicks(7329), "Rem est quam quisquam voluptates officiis expedita expedita ut impedit. Id quia sed eum minus minima. Qui molestiae alias dignissimos reprehenderit non minima aut perferendis perspiciatis." },
                    { 63, 71, 111, 488833, new DateTime(2020, 11, 19, 17, 13, 36, 840, DateTimeKind.Local).AddTicks(7126), "Qui blanditiis est sed natus aut.\nSequi voluptatibus eos tempora blanditiis officia sed molestias voluptas aut.\nRerum eligendi nam.\nExpedita modi rerum consequuntur libero eos voluptas a.\nSed quia enim." },
                    { 192, 71, 84, 159954, new DateTime(2021, 7, 19, 21, 57, 35, 538, DateTimeKind.Local).AddTicks(8800), "Amet minima non aliquid voluptates quaerat quaerat officia. Aut id molestias unde et tempora inventore qui explicabo. Illum quia officia sint porro nostrum maiores." },
                    { 347, 71, 62, 918162, new DateTime(2020, 12, 6, 17, 44, 39, 528, DateTimeKind.Local).AddTicks(6935), "ex" },
                    { 426, 71, 134, 569659, new DateTime(2020, 11, 22, 1, 54, 35, 824, DateTimeKind.Local).AddTicks(9375), "Consequatur nulla quisquam consequuntur nesciunt. Eos iste tempora ut odio in a. Est qui voluptatem nihil." },
                    { 428, 3, 52, 418269, new DateTime(2021, 6, 28, 17, 54, 46, 751, DateTimeKind.Local).AddTicks(8541), "eaque" },
                    { 10, 71, 55, 363405, new DateTime(2021, 5, 10, 21, 49, 16, 313, DateTimeKind.Local).AddTicks(8723), "Ut porro accusantium eveniet ut inventore." },
                    { 553, 96, 146, 81151, new DateTime(2020, 9, 10, 5, 48, 48, 954, DateTimeKind.Local).AddTicks(9427), "Optio rem illo asperiores voluptatem tenetur dolorem. Autem sed architecto. Id non iure eum." },
                    { 315, 30, 90, 283871, new DateTime(2021, 6, 5, 17, 13, 49, 158, DateTimeKind.Local).AddTicks(6998), "voluptatem" },
                    { 375, 30, 65, 16267, new DateTime(2021, 1, 7, 16, 44, 58, 26, DateTimeKind.Local).AddTicks(9856), "Quia sed ea ut totam saepe nam. Eligendi rerum in sed deserunt ut mollitia. Quis aut eos soluta aut eveniet fugit. Dolor quo culpa sed et cum tempore enim facilis illum. Voluptatibus beatae asperiores ratione quas nesciunt ut id ut sequi." },
                    { 201, 86, 128, 443615, new DateTime(2021, 2, 12, 7, 47, 51, 124, DateTimeKind.Local).AddTicks(3394), "Sit nihil nisi optio deserunt.\nMollitia accusamus occaecati rerum." },
                    { 221, 86, 39, 686879, new DateTime(2021, 6, 1, 13, 32, 9, 591, DateTimeKind.Local).AddTicks(5352), "perferendis" },
                    { 233, 86, 54, 790513, new DateTime(2020, 12, 19, 1, 7, 31, 924, DateTimeKind.Local).AddTicks(1628), "Aspernatur labore maiores. Quis minima libero quo sunt at. Quis non qui reprehenderit magni nam suscipit occaecati totam. Itaque laboriosam nesciunt quia ullam vel assumenda aut aliquid facere. Culpa ut laborum eaque aut impedit est quia voluptate." },
                    { 522, 86, 105, 696084, new DateTime(2020, 9, 6, 14, 42, 20, 203, DateTimeKind.Local).AddTicks(9499), "Adipisci autem illum.\nIncidunt et veritatis velit." },
                    { 386, 53, 44, 89406, new DateTime(2020, 9, 29, 8, 37, 46, 997, DateTimeKind.Local).AddTicks(2570), "Vel saepe sit eius quisquam in nam. Et earum id aut et. Est maxime ipsum corrupti velit qui nesciunt voluptatibus sint iste. Facere ut quo eum odit dolorem dignissimos quia." },
                    { 509, 53, 58, 386078, new DateTime(2021, 8, 5, 10, 40, 13, 281, DateTimeKind.Local).AddTicks(3099), "eveniet" },
                    { 532, 53, 10, 378863, new DateTime(2021, 7, 29, 10, 20, 13, 669, DateTimeKind.Local).AddTicks(3137), "praesentium" },
                    { 96, 86, 116, 642849, new DateTime(2020, 8, 26, 7, 43, 9, 271, DateTimeKind.Local).AddTicks(1073), "Laboriosam repellendus beatae fugit iure nesciunt.\nLibero ratione modi eum.\nQuas quo et cum earum ex magni voluptatem.\nUt quod id tempore dolorum debitis et distinctio quis." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 544, 53, 142, 163811, new DateTime(2021, 3, 14, 2, 1, 47, 874, DateTimeKind.Local).AddTicks(7739), "rerum" },
                    { 295, 24, 71, 551743, new DateTime(2021, 6, 27, 2, 0, 44, 790, DateTimeKind.Local).AddTicks(9085), "ullam" },
                    { 306, 24, 34, 838951, new DateTime(2020, 12, 30, 8, 27, 47, 440, DateTimeKind.Local).AddTicks(4879), "Et molestiae ut numquam animi quaerat ut accusamus ratione atque.\nNeque illum enim ex consectetur tenetur recusandae.\nTempore voluptas qui expedita eos quisquam totam.\nSint animi minus sit omnis.\nOmnis et nam." },
                    { 307, 24, 53, 111295, new DateTime(2021, 6, 12, 0, 33, 31, 252, DateTimeKind.Local).AddTicks(9330), "Omnis id accusantium quia et vel consectetur aspernatur illo libero." },
                    { 314, 24, 11, 689186, new DateTime(2021, 3, 7, 23, 29, 6, 117, DateTimeKind.Local).AddTicks(8422), "Sint facilis ex aperiam et a sit eos." },
                    { 331, 24, 118, 133267, new DateTime(2020, 9, 7, 5, 27, 52, 837, DateTimeKind.Local).AddTicks(5895), "Aut dicta earum voluptatem aspernatur et. Eius neque illum et at laborum in quo nostrum. Enim labore non. Eos animi qui voluptates saepe." },
                    { 355, 24, 26, 619816, new DateTime(2021, 3, 21, 18, 23, 29, 108, DateTimeKind.Local).AddTicks(8626), "quae" },
                    { 368, 24, 27, 111335, new DateTime(2020, 10, 25, 23, 59, 40, 887, DateTimeKind.Local).AddTicks(1765), "ut" },
                    { 66, 24, 3, 627519, new DateTime(2021, 8, 11, 10, 14, 35, 784, DateTimeKind.Local).AddTicks(5834), "Iusto dignissimos ab iure accusantium dolores est veniam ipsam praesentium." },
                    { 464, 48, 128, 687022, new DateTime(2020, 12, 30, 4, 31, 3, 302, DateTimeKind.Local).AddTicks(3524), "Ea qui illo consectetur rem provident. Qui non ut illum est error. Ea est ratione asperiores animi. Quam excepturi magni harum qui beatae culpa. Officia velit sunt dolore totam blanditiis rem totam. Quo nobis quis aperiam sit unde." },
                    { 42, 86, 25, 946244, new DateTime(2021, 3, 29, 3, 28, 7, 169, DateTimeKind.Local).AddTicks(2154), "vitae" },
                    { 256, 85, 92, 534236, new DateTime(2021, 7, 27, 13, 17, 53, 861, DateTimeKind.Local).AddTicks(198), "qui" },
                    { 88, 31, 18, 191453, new DateTime(2021, 8, 1, 18, 48, 22, 168, DateTimeKind.Local).AddTicks(3797), "Expedita modi consequatur." },
                    { 158, 31, 146, 78040, new DateTime(2020, 12, 16, 23, 37, 46, 409, DateTimeKind.Local).AddTicks(1428), "Occaecati quia veniam sapiente odit nemo veniam distinctio ab necessitatibus.\nInventore nesciunt quos nostrum soluta omnis.\nSunt id occaecati id itaque incidunt vel eum quos.\nEum praesentium laudantium occaecati tempore laudantium.\nQuia totam et sit." },
                    { 183, 31, 98, 417397, new DateTime(2021, 1, 15, 8, 37, 27, 976, DateTimeKind.Local).AddTicks(9351), "Temporibus praesentium facere consequuntur voluptatibus et voluptas.\nOptio autem facilis qui vel molestias laborum rem necessitatibus.\nCorrupti veritatis earum quis neque aut et omnis sed nulla.\nQuae assumenda est recusandae libero totam amet aliquam voluptatibus.\nIllum quae facilis inventore et qui rerum nobis est.\nDignissimos necessitatibus qui eius et." },
                    { 260, 31, 146, 741505, new DateTime(2020, 10, 22, 11, 4, 40, 262, DateTimeKind.Local).AddTicks(3457), "Rerum dolorem quo dolores quia fugiat in saepe pariatur." },
                    { 369, 31, 4, 116459, new DateTime(2020, 12, 22, 21, 5, 31, 300, DateTimeKind.Local).AddTicks(3251), "Praesentium doloribus earum libero qui omnis.\nMolestiae et minima accusamus.\nDolore aliquid quis incidunt maxime sequi sed provident.\nAperiam enim voluptatem impedit assumenda nostrum ut pariatur autem dolores.\nNemo magnam delectus modi qui nostrum." },
                    { 505, 31, 142, 437348, new DateTime(2021, 2, 6, 2, 47, 15, 179, DateTimeKind.Local).AddTicks(2611), "nam" },
                    { 581, 31, 29, 12087, new DateTime(2020, 8, 24, 4, 23, 45, 830, DateTimeKind.Local).AddTicks(8800), "Eum cum neque ex atque numquam a. Voluptas sint accusantium cum itaque iste rerum ipsum qui. Magni beatae harum voluptatem. Aspernatur et quia culpa natus beatae dolores consequuntur aut similique. Doloribus vel magnam sit illo quaerat vel provident optio saepe." },
                    { 444, 85, 14, 892696, new DateTime(2020, 11, 22, 12, 51, 30, 427, DateTimeKind.Local).AddTicks(6926), "Minus voluptatem eos autem voluptate sint voluptatum." },
                    { 127, 20, 138, 807134, new DateTime(2021, 2, 20, 9, 41, 24, 614, DateTimeKind.Local).AddTicks(1218), "omnis" },
                    { 225, 20, 141, 729426, new DateTime(2020, 11, 12, 7, 49, 39, 990, DateTimeKind.Local).AddTicks(9946), "ratione" },
                    { 338, 20, 9, 536073, new DateTime(2020, 10, 11, 15, 3, 33, 786, DateTimeKind.Local).AddTicks(2370), "Eos ut id dolorum." },
                    { 376, 20, 105, 518155, new DateTime(2021, 5, 10, 19, 0, 23, 723, DateTimeKind.Local).AddTicks(7602), "Quo delectus facere tempora. Dignissimos est et enim praesentium delectus. Numquam voluptatem saepe. Ea laborum atque nostrum delectus harum cupiditate ut neque. Possimus sunt qui quis. Possimus et molestias mollitia soluta et nobis natus harum." },
                    { 588, 20, 115, 234487, new DateTime(2021, 1, 4, 22, 34, 18, 648, DateTimeKind.Local).AddTicks(4956), "Accusamus iusto voluptatem dolore dolores omnis eos." },
                    { 69, 85, 120, 328437, new DateTime(2020, 11, 30, 13, 10, 25, 37, DateTimeKind.Local).AddTicks(1090), "Incidunt odio aut est ad voluptas expedita et voluptatem." },
                    { 126, 85, 61, 148597, new DateTime(2021, 8, 4, 3, 24, 2, 228, DateTimeKind.Local).AddTicks(3684), "Omnis qui quisquam quia accusamus voluptatem est.\nQuaerat modi ratione non.\nOccaecati vitae autem officiis quam mollitia.\nMaxime illum dicta veritatis esse.\nEt ratione rerum fugit voluptatem similique.\nVelit qui reprehenderit eos occaecati." },
                    { 238, 85, 36, 998736, new DateTime(2020, 11, 7, 18, 55, 46, 976, DateTimeKind.Local).AddTicks(5740), "Et ut quo numquam laborum ex consequatur reiciendis. Est nihil et libero rerum consequuntur voluptas qui unde consequuntur. Et natus neque consectetur modi corrupti atque voluptatem consequuntur consequuntur. Perspiciatis nam repellat officia delectus. Impedit voluptatem ducimus autem fugit aut in. Perferendis inventore laborum perferendis sunt voluptatum facilis." },
                    { 181, 20, 39, 861261, new DateTime(2021, 3, 26, 23, 34, 16, 249, DateTimeKind.Local).AddTicks(7154), "Modi aspernatur ipsum porro sit necessitatibus perspiciatis fuga.\nNecessitatibus enim placeat molestias quis rerum.\nAdipisci qui omnis reprehenderit magnam ea ut repudiandae quasi quia.\nAut error odit praesentium sint corporis ipsa aliquam in.\nQuaerat deleniti repellat et unde et quis quia est.\nEt dolorem voluptatem omnis tempore qui molestias." },
                    { 468, 48, 102, 413024, new DateTime(2021, 6, 18, 23, 51, 55, 57, DateTimeKind.Local).AddTicks(7473), "Dicta laboriosam et id deserunt error ipsa consequuntur.\nQui ea amet.\nNatus ipsam illo saepe repellat quasi dolores aperiam.\nLaborum odio id molestias et veniam tempore eum nemo ut." },
                    { 498, 48, 129, 50940, new DateTime(2021, 2, 6, 18, 26, 52, 901, DateTimeKind.Local).AddTicks(1127), "voluptatem" },
                    { 578, 48, 66, 56650, new DateTime(2021, 1, 20, 2, 54, 11, 991, DateTimeKind.Local).AddTicks(9772), "quisquam" },
                    { 121, 81, 34, 855630, new DateTime(2020, 12, 6, 11, 28, 42, 925, DateTimeKind.Local).AddTicks(3872), "Eos amet sit ut rem excepturi fugiat." },
                    { 174, 81, 120, 808624, new DateTime(2020, 12, 18, 13, 40, 50, 746, DateTimeKind.Local).AddTicks(6692), "Sit error ducimus voluptas voluptates veniam. Ipsam cumque est dolores. Sapiente est quidem impedit repudiandae eos dicta repellat." },
                    { 574, 81, 73, 5220, new DateTime(2020, 10, 13, 1, 41, 26, 866, DateTimeKind.Local).AddTicks(2406), "Sint vel non nihil dolores et vel est.\nSunt est ipsam itaque mollitia impedit quisquam aspernatur vitae aut.\nSed tempore quis qui itaque ut eligendi rerum cumque quod.\nEt sit tenetur adipisci fuga ipsa voluptatibus est.\nUt inventore voluptate eum quia molestiae laboriosam aut occaecati.\nEius eum harum veritatis ut." },
                    { 52, 4, 15, 865312, new DateTime(2021, 1, 31, 12, 27, 30, 106, DateTimeKind.Local).AddTicks(1800), "Voluptate ut nobis dolores vel distinctio voluptatem praesentium. Voluptatibus aspernatur rerum debitis quisquam quia qui vero quibusdam eos. Impedit necessitatibus modi soluta quae iusto blanditiis eos maiores aliquam. Autem reiciendis consequatur veritatis occaecati eum ratione. Quia harum molestias quas quos ea. Nostrum non dolores." },
                    { 373, 4, 78, 379631, new DateTime(2021, 5, 3, 14, 16, 9, 774, DateTimeKind.Local).AddTicks(9196), "Alias tempora repudiandae doloremque eveniet expedita non.\nQuod eum ut corporis fugit repellat sit est sed.\nEarum sit ut facilis voluptas dignissimos eos.\nVeritatis quo rerum neque." },
                    { 415, 4, 59, 706540, new DateTime(2020, 11, 6, 0, 12, 16, 257, DateTimeKind.Local).AddTicks(6817), "maiores" },
                    { 542, 4, 85, 242103, new DateTime(2021, 3, 17, 12, 26, 25, 843, DateTimeKind.Local).AddTicks(2478), "Odio voluptatum quia corporis." },
                    { 206, 6, 102, 602738, new DateTime(2020, 8, 31, 2, 41, 40, 156, DateTimeKind.Local).AddTicks(2694), "Ullam ipsa et consequatur neque." },
                    { 227, 6, 32, 345494, new DateTime(2021, 6, 20, 12, 45, 58, 0, DateTimeKind.Local).AddTicks(6223), "Eaque ut fuga officia et. Quae rem voluptas dicta. Odit voluptate voluptatem excepturi nostrum molestiae." },
                    { 272, 6, 79, 417649, new DateTime(2020, 9, 28, 16, 11, 24, 653, DateTimeKind.Local).AddTicks(5137), "Qui perspiciatis veniam sit voluptatem tenetur.\nEt praesentium ab quisquam voluptate suscipit expedita.\nTempore incidunt est tempora placeat voluptatem.\nEt eligendi id incidunt rerum atque voluptate similique nisi impedit." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 429, 6, 88, 117535, new DateTime(2021, 1, 2, 20, 0, 20, 746, DateTimeKind.Local).AddTicks(7661), "similique" },
                    { 535, 6, 61, 602266, new DateTime(2021, 4, 28, 22, 28, 24, 136, DateTimeKind.Local).AddTicks(2787), "Nihil veritatis fugiat mollitia deleniti laudantium amet vitae. Repudiandae enim aut cumque. Eligendi ex id minus sequi dolorem quia tenetur vel hic. Illo nihil veritatis modi. Voluptatum veniam cupiditate doloremque necessitatibus corporis dolores dolor cumque." },
                    { 584, 6, 16, 554889, new DateTime(2020, 11, 26, 13, 27, 27, 915, DateTimeKind.Local).AddTicks(4176), "Saepe eos dolore.\nRerum vel hic iste eos et repellat libero maxime." },
                    { 203, 67, 18, 885193, new DateTime(2021, 5, 2, 20, 13, 37, 863, DateTimeKind.Local).AddTicks(2370), "earum" },
                    { 356, 67, 4, 891389, new DateTime(2021, 7, 6, 6, 27, 2, 78, DateTimeKind.Local).AddTicks(3395), "Accusantium harum voluptatum ratione. Tenetur cupiditate in excepturi et architecto illum voluptas repellat. Eius voluptatem dolor ea aliquam sit doloribus ut blanditiis." },
                    { 117, 81, 88, 947902, new DateTime(2021, 7, 17, 8, 42, 13, 954, DateTimeKind.Local).AddTicks(3187), "culpa" },
                    { 40, 81, 32, 219182, new DateTime(2021, 3, 12, 23, 56, 57, 772, DateTimeKind.Local).AddTicks(2656), "repellat" },
                    { 16, 81, 122, 822353, new DateTime(2021, 3, 20, 12, 10, 5, 549, DateTimeKind.Local).AddTicks(2061), "Odit quia blanditiis nostrum. Expedita animi facere provident. Unde laudantium explicabo dicta. Tempora autem enim velit placeat et possimus." },
                    { 533, 63, 62, 906544, new DateTime(2020, 12, 23, 11, 40, 27, 933, DateTimeKind.Local).AddTicks(1573), "Et tenetur aliquam id quisquam error expedita consequuntur impedit nihil.\nReprehenderit tempora consectetur beatae soluta deserunt consequatur.\nEst dolor assumenda temporibus dolores." },
                    { 46, 18, 11, 527091, new DateTime(2021, 4, 21, 20, 57, 29, 858, DateTimeKind.Local).AddTicks(7634), "Facere ea molestiae.\nNisi ex aut impedit aut pariatur ullam.\nHic ut minus architecto quae rerum et veritatis.\nRepellat delectus unde unde molestias sint doloribus.\nAperiam dignissimos neque id cupiditate officiis.\nRecusandae deleniti quia voluptatem laborum eligendi iste." },
                    { 74, 18, 61, 60894, new DateTime(2020, 11, 20, 17, 10, 47, 847, DateTimeKind.Local).AddTicks(998), "Ducimus esse sit aliquam." },
                    { 131, 18, 114, 719096, new DateTime(2020, 12, 1, 17, 29, 50, 711, DateTimeKind.Local).AddTicks(8757), "Quae iusto modi quam dicta ratione fugit." },
                    { 188, 18, 43, 85216, new DateTime(2021, 1, 2, 22, 6, 18, 512, DateTimeKind.Local).AddTicks(2685), "voluptatem" },
                    { 363, 18, 111, 21587, new DateTime(2021, 5, 28, 1, 45, 7, 813, DateTimeKind.Local).AddTicks(2366), "Aliquid quo doloremque accusamus dolor fugiat rerum." },
                    { 455, 18, 70, 227213, new DateTime(2020, 10, 21, 23, 2, 32, 836, DateTimeKind.Local).AddTicks(8091), "Sit voluptas alias eligendi sunt totam minima." },
                    { 572, 18, 27, 511438, new DateTime(2021, 6, 13, 23, 51, 18, 511, DateTimeKind.Local).AddTicks(6166), "Et totam voluptas eum consequatur sit distinctio." },
                    { 405, 67, 46, 72479, new DateTime(2021, 3, 27, 21, 43, 8, 725, DateTimeKind.Local).AddTicks(8392), "Magni nihil fugit." },
                    { 172, 92, 17, 674083, new DateTime(2020, 10, 4, 3, 4, 51, 926, DateTimeKind.Local).AddTicks(6326), "Similique quidem harum placeat sed. Quia ea quam nihil cupiditate voluptates reprehenderit natus ea vero. Dolorum quis molestiae nulla." },
                    { 337, 92, 62, 631619, new DateTime(2021, 7, 14, 12, 55, 50, 602, DateTimeKind.Local).AddTicks(6034), "iure" },
                    { 476, 92, 122, 993002, new DateTime(2021, 5, 1, 14, 56, 14, 149, DateTimeKind.Local).AddTicks(8150), "Similique rerum non nesciunt totam aut officia dolor." },
                    { 150, 63, 88, 306972, new DateTime(2020, 11, 19, 22, 8, 39, 282, DateTimeKind.Local).AddTicks(8829), "Beatae vel architecto dolor a modi dicta." },
                    { 212, 63, 4, 426206, new DateTime(2020, 12, 11, 11, 48, 24, 105, DateTimeKind.Local).AddTicks(812), "assumenda" },
                    { 359, 63, 65, 497341, new DateTime(2020, 10, 25, 13, 5, 23, 796, DateTimeKind.Local).AddTicks(9985), "Maiores odio temporibus magni eaque in voluptatem doloremque rerum exercitationem.\nIpsum nulla error et enim qui.\nReprehenderit nihil voluptatem aliquid est dolores.\nNon aliquid non." },
                    { 383, 63, 73, 209725, new DateTime(2021, 3, 8, 18, 18, 3, 834, DateTimeKind.Local).AddTicks(9069), "Voluptates enim possimus.\nUt ex assumenda fugiat provident ab expedita aut.\nConsequatur reiciendis iure illum qui ea.\nVoluptatem inventore accusamus voluptatum reiciendis earum.\nIure itaque sint fugiat recusandae et est soluta perspiciatis." },
                    { 403, 63, 24, 668366, new DateTime(2021, 5, 6, 21, 56, 29, 700, DateTimeKind.Local).AddTicks(1524), "tenetur" },
                    { 322, 92, 65, 9825, new DateTime(2021, 1, 8, 16, 40, 13, 710, DateTimeKind.Local).AddTicks(1145), "consequatur" },
                    { 564, 67, 12, 146291, new DateTime(2021, 7, 22, 21, 0, 10, 358, DateTimeKind.Local).AddTicks(6505), "Eum et magnam dicta sunt impedit officia. Officiis magni blanditiis et ut. Voluptatem dolores quis ab ut fuga sed eligendi laborum sapiente. Magnam dolores accusantium libero deserunt et quis. Voluptate laboriosam consequatur." },
                    { 577, 67, 19, 520385, new DateTime(2021, 8, 16, 20, 24, 17, 229, DateTimeKind.Local).AddTicks(9795), "voluptatem" },
                    { 281, 77, 120, 934444, new DateTime(2020, 9, 8, 16, 23, 34, 280, DateTimeKind.Local).AddTicks(766), "Et quam deserunt.\nCulpa eos nihil id magnam quae inventore.\nFugit non sapiente excepturi.\nEa sint doloremque quo id nobis commodi.\nPraesentium qui dolores quo voluptate deleniti.\nAt eum consequuntur quidem." },
                    { 234, 8, 70, 208480, new DateTime(2020, 10, 19, 6, 26, 22, 494, DateTimeKind.Local).AddTicks(8119), "Alias dolor aut repellendus et voluptatum tempora voluptatem nesciunt ut." },
                    { 245, 8, 69, 560778, new DateTime(2020, 12, 30, 20, 6, 7, 640, DateTimeKind.Local).AddTicks(5557), "non" },
                    { 265, 8, 96, 24672, new DateTime(2021, 2, 22, 13, 9, 42, 18, DateTimeKind.Local).AddTicks(7134), "qui" },
                    { 278, 8, 26, 804679, new DateTime(2021, 6, 14, 15, 51, 36, 161, DateTimeKind.Local).AddTicks(9378), "Perferendis alias in culpa sit quae consequatur optio." },
                    { 286, 8, 52, 680269, new DateTime(2021, 3, 22, 13, 30, 37, 586, DateTimeKind.Local).AddTicks(6721), "facilis" },
                    { 342, 15, 44, 530486, new DateTime(2021, 7, 5, 14, 14, 23, 439, DateTimeKind.Local).AddTicks(6262), "quia" },
                    { 477, 15, 5, 371110, new DateTime(2020, 11, 20, 3, 7, 7, 749, DateTimeKind.Local).AddTicks(2999), "Cupiditate laudantium reiciendis corporis ea. Aut ab omnis. Laudantium est libero quia. Et voluptas natus et ut et accusantium facere." },
                    { 178, 8, 74, 493717, new DateTime(2021, 5, 14, 7, 42, 1, 948, DateTimeKind.Local).AddTicks(4365), "Nihil dolor aut qui enim." },
                    { 516, 15, 79, 414280, new DateTime(2021, 2, 22, 20, 24, 48, 555, DateTimeKind.Local).AddTicks(42), "Voluptatibus dignissimos harum." },
                    { 224, 56, 24, 755649, new DateTime(2021, 8, 8, 12, 19, 44, 695, DateTimeKind.Local).AddTicks(1743), "Cupiditate atque ut aut accusantium molestiae tempora.\nOfficiis eos ut qui in velit eveniet.\nIncidunt itaque cumque incidunt non itaque et." },
                    { 246, 56, 103, 430822, new DateTime(2020, 11, 28, 10, 49, 8, 535, DateTimeKind.Local).AddTicks(1538), "Qui eveniet et aperiam.\nCum delectus mollitia aut sunt ut aut.\nAut nostrum iusto sed quod beatae voluptatem deleniti.\nAnimi non repellendus consequatur totam laborum a sint.\nOdio aut dolores labore qui nam hic qui assumenda.\nEt nesciunt eos alias voluptatem iure facilis laboriosam quia a." },
                    { 411, 56, 7, 152918, new DateTime(2020, 10, 7, 3, 40, 11, 821, DateTimeKind.Local).AddTicks(4350), "Neque ullam enim minus eum.\nAperiam iure et atque molestiae est rem." },
                    { 458, 56, 112, 349901, new DateTime(2021, 1, 26, 17, 54, 47, 878, DateTimeKind.Local).AddTicks(7253), "Est suscipit qui veniam et.\nInventore quisquam soluta error odio.\nUt quia non exercitationem praesentium nobis amet.\nProvident qui dolor voluptatum et.\nSint et aliquam voluptas odit provident optio et voluptatum.\nOmnis eligendi dolore laudantium odio maxime." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 557, 56, 94, 723158, new DateTime(2020, 11, 5, 8, 31, 53, 778, DateTimeKind.Local).AddTicks(7803), "Odio illo vitae dolorum sint numquam et corrupti facere dolore.\nSunt temporibus provident est perferendis animi deserunt alias similique." },
                    { 62, 3, 116, 131003, new DateTime(2021, 6, 21, 13, 29, 51, 242, DateTimeKind.Local).AddTicks(8870), "temporibus" },
                    { 230, 3, 108, 958252, new DateTime(2020, 9, 13, 18, 35, 51, 99, DateTimeKind.Local).AddTicks(4478), "Tempora autem nam.\nError odio dolorum dolor consequuntur natus ut culpa vel.\nQuo totam vitae mollitia perspiciatis incidunt.\nSit asperiores unde et doloremque eaque laboriosam." },
                    { 566, 15, 59, 63094, new DateTime(2021, 3, 4, 8, 2, 12, 20, DateTimeKind.Local).AddTicks(4221), "Consequatur blanditiis minima sint reiciendis corporis est qui quis. Quia non natus cum minima voluptatum. Dolorem eos expedita." },
                    { 36, 18, 127, 610020, new DateTime(2020, 12, 11, 13, 19, 2, 6, DateTimeKind.Local).AddTicks(8356), "Quis qui laudantium quas libero eum sit odio dolores nostrum. Autem voluptatem quo eos voluptas atque voluptates non incidunt. Omnis eos rerum occaecati optio optio delectus fugit deserunt. Deleniti molestiae est officia ipsum omnis ratione." },
                    { 153, 8, 119, 834947, new DateTime(2021, 5, 17, 7, 16, 54, 794, DateTimeKind.Local).AddTicks(2708), "ab" },
                    { 515, 95, 102, 675484, new DateTime(2021, 3, 30, 23, 8, 46, 888, DateTimeKind.Local).AddTicks(6004), "Occaecati dolor asperiores sed qui iste." },
                    { 360, 77, 136, 727219, new DateTime(2021, 4, 4, 3, 14, 11, 930, DateTimeKind.Local).AddTicks(7700), "possimus" },
                    { 449, 77, 40, 97604, new DateTime(2020, 8, 18, 13, 26, 51, 568, DateTimeKind.Local).AddTicks(5040), "Qui dolorem ratione sit incidunt vitae suscipit itaque culpa beatae.\nIncidunt est nostrum qui qui.\nVoluptas totam molestias cupiditate et eum totam.\nHic quisquam dicta laboriosam.\nEt distinctio quis voluptas quisquam dolorum." },
                    { 41, 5, 77, 624980, new DateTime(2020, 9, 19, 4, 43, 56, 841, DateTimeKind.Local).AddTicks(2540), "Et saepe aut possimus est veritatis voluptatum. Ipsum excepturi asperiores. Qui quo eaque pariatur. Consequuntur sed rerum numquam mollitia adipisci autem repellat sit. Inventore molestias quis. Consequuntur sint delectus architecto ipsam expedita harum." },
                    { 72, 5, 146, 211216, new DateTime(2021, 5, 4, 9, 12, 32, 1, DateTimeKind.Local).AddTicks(1090), "Qui sit aliquid qui ea quas fugit pariatur eaque. Rerum est similique a culpa temporibus explicabo cumque velit. Quia rerum in deserunt aut repudiandae eos quam." },
                    { 352, 5, 106, 239786, new DateTime(2020, 11, 7, 13, 38, 27, 856, DateTimeKind.Local).AddTicks(8945), "Qui non ut iusto.\nAnimi sunt aut aliquam commodi.\nAspernatur est minima aut cumque tenetur repellendus.\nExpedita officia tempore aliquam iure eum distinctio tenetur mollitia ea.\nIpsa voluptate earum facilis accusamus quos.\nRepellendus maiores ut excepturi natus eaque." },
                    { 136, 2, 134, 348027, new DateTime(2021, 5, 28, 2, 35, 50, 369, DateTimeKind.Local).AddTicks(1673), "Similique non aut consequatur beatae unde rem adipisci eius deleniti.\nEt beatae eum.\nUt eos nihil dolorem consequatur.\nOdio veniam cumque unde ea doloremque nulla eos consequatur qui." },
                    { 184, 2, 45, 669896, new DateTime(2021, 6, 20, 17, 57, 7, 821, DateTimeKind.Local).AddTicks(1000), "Atque doloremque et.\nA praesentium impedit.\nNihil eius et." },
                    { 575, 95, 53, 780560, new DateTime(2021, 3, 6, 22, 17, 52, 10, DateTimeKind.Local).AddTicks(9856), "Rerum amet recusandae perspiciatis maiores maiores. Dicta soluta fugit qui quia vel. Voluptatem doloribus ea. Eveniet vel molestiae. Cupiditate consequatur et ut velit ut. Et et repellendus voluptas aut fugit modi." },
                    { 287, 2, 62, 509687, new DateTime(2021, 6, 7, 5, 40, 19, 491, DateTimeKind.Local).AddTicks(1194), "error" },
                    { 320, 2, 136, 258697, new DateTime(2021, 1, 20, 5, 22, 6, 422, DateTimeKind.Local).AddTicks(6311), "Cupiditate minima itaque aspernatur voluptatem qui voluptas unde est.\nVoluptas deleniti non debitis odio sit.\nVoluptas in in et ducimus eaque et suscipit dignissimos dolorum." },
                    { 432, 2, 51, 439403, new DateTime(2021, 8, 3, 20, 14, 53, 127, DateTimeKind.Local).AddTicks(3102), "Nisi quam ab.\nPossimus quia est et corrupti numquam at.\nIncidunt laudantium sint sequi ut sit." },
                    { 470, 2, 35, 382263, new DateTime(2021, 1, 24, 0, 47, 46, 90, DateTimeKind.Local).AddTicks(5987), "Expedita qui doloribus necessitatibus laborum est." },
                    { 37, 95, 122, 332724, new DateTime(2021, 8, 5, 20, 37, 6, 250, DateTimeKind.Local).AddTicks(1655), "necessitatibus" },
                    { 213, 95, 67, 287124, new DateTime(2020, 12, 2, 11, 2, 12, 801, DateTimeKind.Local).AddTicks(1907), "amet" },
                    { 395, 95, 63, 846144, new DateTime(2021, 3, 23, 17, 20, 6, 542, DateTimeKind.Local).AddTicks(6415), "Qui possimus qui et et esse tenetur et. Distinctio suscipit placeat eum. Ut officia qui quis quia nam consequatur. Et et vitae omnis et ipsa cupiditate voluptatem." },
                    { 478, 95, 34, 234545, new DateTime(2020, 12, 1, 18, 0, 6, 62, DateTimeKind.Local).AddTicks(7699), "Omnis adipisci repellendus qui repellendus odit commodi rerum earum.\nEst eveniet vel reiciendis consequatur dolore sint id.\nFacere eos magnam sequi sunt porro et." },
                    { 299, 2, 82, 521494, new DateTime(2021, 4, 2, 12, 39, 5, 328, DateTimeKind.Local).AddTicks(2917), "Architecto accusamus eligendi saepe est commodi qui. Dicta tempore deserunt ea qui. Laborum assumenda facere voluptates dignissimos. Iure optio voluptates culpa. Ea eos soluta debitis nobis et accusantium quibusdam aperiam." },
                    { 60, 66, 9, 273895, new DateTime(2021, 4, 12, 21, 36, 50, 907, DateTimeKind.Local).AddTicks(5735), "Provident et omnis esse molestias.\nCulpa quia impedit similique.\nAb delectus sint vel voluptatem ex in qui cum dolore.\nRepellat sint sint illo omnis recusandae tempore ratione blanditiis.\nEveniet voluptatibus omnis.\nAut assumenda adipisci rerum." },
                    { 536, 62, 123, 819026, new DateTime(2021, 1, 27, 12, 16, 37, 47, DateTimeKind.Local).AddTicks(3990), "Quis architecto hic a tenetur sit. Reprehenderit cupiditate placeat magnam rerum ut nihil possimus quia. Esse iusto maiores qui libero ipsa iure vero molestiae. Pariatur error quasi." },
                    { 269, 62, 22, 354013, new DateTime(2021, 2, 20, 22, 47, 49, 396, DateTimeKind.Local).AddTicks(5105), "Ut laboriosam sed sapiente voluptatum quo molestiae. Unde minus voluptatum magnam. Debitis qui dolor quod ut quod alias pariatur. Aut ducimus dolores mollitia." },
                    { 30, 27, 81, 330243, new DateTime(2021, 7, 18, 9, 45, 57, 513, DateTimeKind.Local).AddTicks(594), "velit" },
                    { 387, 27, 28, 86363, new DateTime(2021, 4, 10, 12, 18, 16, 456, DateTimeKind.Local).AddTicks(1546), "Doloribus eligendi enim reiciendis beatae." },
                    { 399, 27, 121, 619223, new DateTime(2020, 11, 4, 1, 52, 17, 389, DateTimeKind.Local).AddTicks(9138), "Eos dolores aliquid." },
                    { 510, 27, 2, 90454, new DateTime(2021, 7, 15, 18, 31, 51, 276, DateTimeKind.Local).AddTicks(9840), "officiis" },
                    { 64, 36, 145, 100434, new DateTime(2021, 4, 25, 10, 35, 54, 2, DateTimeKind.Local).AddTicks(1673), "earum" },
                    { 102, 36, 64, 370982, new DateTime(2021, 1, 30, 14, 47, 8, 156, DateTimeKind.Local).AddTicks(6276), "Ducimus itaque rem harum inventore quia minus voluptatum." },
                    { 302, 36, 76, 671565, new DateTime(2020, 10, 3, 7, 11, 27, 379, DateTimeKind.Local).AddTicks(9371), "Dolores ut tempore nostrum.\nLabore atque incidunt fugiat alias.\nEt quos deserunt ut deleniti qui officia.\nVoluptate ab odio aut sint quo.\nQuos quas itaque." },
                    { 517, 36, 113, 993373, new DateTime(2021, 5, 30, 0, 40, 24, 922, DateTimeKind.Local).AddTicks(3654), "odio" },
                    { 570, 36, 149, 553769, new DateTime(2020, 10, 20, 20, 50, 33, 782, DateTimeKind.Local).AddTicks(3259), "Illum aut dolorem corrupti cupiditate impedit consectetur animi est." },
                    { 598, 36, 38, 507545, new DateTime(2021, 2, 8, 1, 27, 14, 966, DateTimeKind.Local).AddTicks(284), "Tempora ipsum tempore asperiores commodi eligendi." },
                    { 50, 51, 143, 470967, new DateTime(2021, 3, 22, 12, 1, 22, 765, DateTimeKind.Local).AddTicks(2066), "Placeat iusto ex quasi modi vel id in quis. Ipsa et corrupti maiores commodi totam porro aut. Et dolorem culpa amet quae. Et omnis facilis laborum tempore exercitationem eligendi sit asperiores. Cumque ducimus quaerat reiciendis iure suscipit itaque. Totam accusamus et facilis possimus repellendus et delectus." },
                    { 414, 51, 101, 290387, new DateTime(2021, 4, 27, 23, 32, 46, 310, DateTimeKind.Local).AddTicks(9239), "voluptatum" },
                    { 467, 51, 93, 492201, new DateTime(2021, 1, 14, 18, 12, 5, 969, DateTimeKind.Local).AddTicks(6730), "Sit ut quia amet voluptatem soluta eum." },
                    { 489, 51, 124, 980738, new DateTime(2020, 10, 17, 22, 9, 57, 177, DateTimeKind.Local).AddTicks(8952), "Quis est nam aut voluptas est ullam et hic inventore." },
                    { 554, 51, 73, 380904, new DateTime(2020, 10, 14, 9, 23, 22, 546, DateTimeKind.Local).AddTicks(774), "Temporibus mollitia similique dolore quas doloribus incidunt nihil incidunt consequatur. Ipsa libero quia aut. Praesentium officiis quia alias ut id vel rem ullam nihil. Dolore aut sint voluptatem possimus nesciunt ut ut. Qui nihil quia quasi natus aut." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 576, 40, 71, 14914, new DateTime(2021, 1, 17, 13, 2, 4, 604, DateTimeKind.Local).AddTicks(8950), "Mollitia aut et nihil soluta deleniti." },
                    { 372, 40, 23, 997548, new DateTime(2021, 4, 15, 6, 51, 10, 660, DateTimeKind.Local).AddTicks(284), "et" },
                    { 358, 40, 8, 304867, new DateTime(2021, 5, 20, 0, 56, 25, 725, DateTimeKind.Local).AddTicks(371), "aut" },
                    { 236, 40, 35, 743719, new DateTime(2021, 1, 18, 10, 21, 12, 981, DateTimeKind.Local).AddTicks(8556), "Doloremque ea quo expedita enim non. Alias laborum aliquid eos libero numquam id praesentium. Sit iste dignissimos." },
                    { 21, 80, 40, 983099, new DateTime(2021, 2, 10, 21, 36, 43, 524, DateTimeKind.Local).AddTicks(6786), "Voluptate eum atque laboriosam.\nQuisquam amet quis tempora enim quo perspiciatis dolorem repudiandae.\nDolorum qui nemo corrupti minus at voluptatem error.\nAperiam deserunt repudiandae quo.\nAb enim fuga debitis sunt.\nQuisquam et voluptatem." },
                    { 32, 80, 5, 361431, new DateTime(2021, 4, 19, 7, 5, 3, 982, DateTimeKind.Local).AddTicks(8728), "enim" },
                    { 168, 80, 147, 220731, new DateTime(2020, 9, 12, 13, 52, 45, 214, DateTimeKind.Local).AddTicks(3341), "Maiores sed veniam explicabo voluptatum." },
                    { 195, 80, 122, 743993, new DateTime(2020, 12, 22, 5, 43, 16, 69, DateTimeKind.Local).AddTicks(5521), "Dolores veritatis molestiae dolor aspernatur.\nSed et labore pariatur aliquam libero quia omnis hic odio.\nVeniam aut voluptatem nobis corporis quae aspernatur quod repudiandae magni.\nEos dicta nostrum facere." },
                    { 252, 80, 7, 132167, new DateTime(2021, 4, 10, 1, 57, 33, 745, DateTimeKind.Local).AddTicks(7868), "Beatae aut eveniet non sint quidem." },
                    { 569, 80, 141, 828475, new DateTime(2020, 10, 4, 3, 30, 22, 960, DateTimeKind.Local).AddTicks(3526), "Suscipit et quos eos est et perspiciatis quam. Excepturi autem placeat. Rerum voluptas voluptate repudiandae quae. A fugit maiores aut consequatur. Qui aut ut impedit possimus consequatur totam minima rem. Quia beatae magnam." },
                    { 49, 70, 44, 122443, new DateTime(2021, 6, 25, 9, 24, 8, 665, DateTimeKind.Local).AddTicks(4565), "Id ex qui provident sed assumenda ex dolores aut.\nSed voluptas earum sint quasi.\nVoluptates non dolores quod." },
                    { 86, 46, 149, 196626, new DateTime(2021, 2, 23, 0, 6, 15, 192, DateTimeKind.Local).AddTicks(276), "Quisquam repellat pariatur dolor placeat tenetur.\nOfficia sit ut nisi nostrum.\nAut laboriosam fuga cupiditate qui voluptates iste quibusdam.\nUllam voluptatum voluptatem libero expedita sit nisi ut omnis." },
                    { 67, 70, 111, 365647, new DateTime(2021, 1, 23, 19, 52, 59, 940, DateTimeKind.Local).AddTicks(5652), "autem" },
                    { 219, 70, 20, 890047, new DateTime(2020, 12, 27, 11, 53, 41, 516, DateTimeKind.Local).AddTicks(8099), "quasi" },
                    { 146, 13, 131, 620970, new DateTime(2021, 6, 22, 0, 19, 8, 450, DateTimeKind.Local).AddTicks(474), "Porro ut itaque." },
                    { 357, 13, 138, 670877, new DateTime(2020, 10, 19, 17, 29, 9, 747, DateTimeKind.Local).AddTicks(6167), "Ea dolorem perspiciatis aperiam dolorum nihil quibusdam alias." },
                    { 398, 13, 1, 116511, new DateTime(2021, 5, 27, 10, 13, 27, 960, DateTimeKind.Local).AddTicks(9427), "Aliquam omnis sunt dolore voluptas repudiandae quisquam vitae quaerat corrupti.\nVelit molestias perferendis sint quia quia nihil in vero.\nReiciendis voluptas eos quos est reprehenderit et expedita nulla non." },
                    { 442, 13, 38, 604683, new DateTime(2021, 2, 17, 6, 4, 3, 428, DateTimeKind.Local).AddTicks(9291), "Qui at cumque temporibus temporibus suscipit et est molestias sit. Consequatur alias deserunt officiis voluptas perspiciatis ipsum deleniti saepe possimus. Quia ea labore nostrum minus et occaecati perferendis voluptatum. Assumenda quasi accusamus id veniam quibusdam quasi illo blanditiis. Sed ut doloremque nam natus totam distinctio est id iste. Aperiam dolor doloremque facilis laboriosam omnis." },
                    { 558, 13, 21, 349550, new DateTime(2021, 6, 22, 2, 37, 8, 445, DateTimeKind.Local).AddTicks(1048), "ut" },
                    { 109, 40, 36, 767328, new DateTime(2020, 9, 23, 9, 50, 58, 715, DateTimeKind.Local).AddTicks(3142), "Et expedita aut sed nihil consectetur nemo.\nEt velit et voluptas fuga laudantium quod." },
                    { 200, 70, 104, 336883, new DateTime(2021, 2, 15, 19, 54, 18, 341, DateTimeKind.Local).AddTicks(7174), "Dolor sapiente eos molestiae ut tenetur maxime incidunt ducimus ipsum." },
                    { 169, 46, 88, 535616, new DateTime(2021, 3, 8, 1, 48, 35, 47, DateTimeKind.Local).AddTicks(1618), "Sed odio blanditiis et. Occaecati et unde perferendis ipsum. Sit autem ut. Eos non sed tempora dolores voluptas debitis ipsum ipsam. Laboriosam provident provident quia." },
                    { 232, 46, 148, 243353, new DateTime(2021, 1, 22, 13, 37, 13, 167, DateTimeKind.Local).AddTicks(354), "Libero incidunt possimus qui quia unde.\nCorporis ipsa ut repellendus neque perspiciatis.\nMagnam et id et ad.\nImpedit minima aspernatur.\nVeritatis id beatae.\nCommodi nihil odit est et minus." },
                    { 263, 46, 122, 887185, new DateTime(2020, 12, 29, 5, 26, 52, 406, DateTimeKind.Local).AddTicks(2710), "Debitis repudiandae tenetur eum aut." },
                    { 79, 22, 65, 126425, new DateTime(2021, 6, 5, 7, 2, 28, 681, DateTimeKind.Local).AddTicks(1007), "Eos vitae nihil quaerat. Quo vitae laboriosam optio eaque cumque unde qui sit. Voluptatem ea non et omnis vero aut dolorem inventore. Id eaque praesentium dicta dolore sapiente recusandae. Itaque iste autem et repudiandae." },
                    { 119, 22, 56, 437238, new DateTime(2020, 11, 27, 19, 15, 32, 915, DateTimeKind.Local).AddTicks(5936), "At odit porro eum cumque natus quaerat.\nQuas voluptate molestiae omnis beatae.\nDoloribus mollitia eos.\nPossimus animi omnis enim quidem quia.\nConsequatur nihil laudantium illo dolorem laboriosam aperiam." },
                    { 142, 22, 45, 553429, new DateTime(2021, 4, 21, 17, 53, 55, 437, DateTimeKind.Local).AddTicks(5985), "id" },
                    { 309, 22, 32, 266056, new DateTime(2021, 4, 8, 0, 59, 55, 901, DateTimeKind.Local).AddTicks(9964), "et" },
                    { 529, 22, 63, 429174, new DateTime(2020, 9, 1, 2, 55, 13, 192, DateTimeKind.Local).AddTicks(5484), "Qui ut doloremque deleniti rerum." },
                    { 587, 22, 75, 492841, new DateTime(2021, 8, 9, 4, 18, 44, 971, DateTimeKind.Local).AddTicks(8445), "Saepe similique autem rem adipisci mollitia saepe omnis ab et." },
                    { 76, 44, 108, 905533, new DateTime(2021, 3, 14, 3, 47, 25, 113, DateTimeKind.Local).AddTicks(2884), "Ut non voluptatem veniam ad sapiente tempore quam eaque.\nPossimus nemo quia at.\nMinus minus nesciunt et amet sapiente ut vero unde eos.\nEt aperiam quo autem facere at quas.\nAssumenda provident vero quia maiores tempore.\nNam qui neque earum quas." },
                    { 595, 52, 5, 51765, new DateTime(2020, 11, 6, 18, 13, 50, 839, DateTimeKind.Local).AddTicks(1122), "Consequatur voluptas corporis nemo nostrum in natus." },
                    { 250, 44, 19, 787602, new DateTime(2021, 4, 11, 12, 3, 42, 691, DateTimeKind.Local).AddTicks(2686), "dignissimos" },
                    { 345, 44, 77, 768305, new DateTime(2021, 1, 4, 13, 17, 49, 774, DateTimeKind.Local).AddTicks(3000), "Omnis ea maxime temporibus ipsum et esse aut cum. Nobis harum odio eligendi. Repellat perferendis aliquam repellat ullam culpa. Molestiae accusamus tempora exercitationem itaque nihil et." },
                    { 460, 44, 2, 883133, new DateTime(2021, 7, 15, 13, 12, 20, 722, DateTimeKind.Local).AddTicks(757), "Eveniet eum molestiae dolor ipsa minus et nisi optio.\nAut architecto ipsam labore laboriosam et sit.\nPerferendis fuga ad rerum saepe facilis.\nOmnis ut sunt autem ullam aspernatur impedit quo sapiente.\nSit sit dolor omnis porro.\nQuia eius rerum consequatur voluptas rerum ea." },
                    { 5, 62, 62, 422546, new DateTime(2020, 11, 7, 4, 55, 57, 434, DateTimeKind.Local).AddTicks(8820), "Voluptatibus architecto asperiores similique et nihil magnam odio vel. Ab ullam tempore ut nesciunt explicabo assumenda. Omnis doloremque rem quia sed ut et amet quo. Iste quo tempore qui recusandae et id. Reprehenderit odio aliquid consectetur et voluptatibus assumenda qui nihil ipsum." },
                    { 125, 62, 31, 600189, new DateTime(2021, 3, 7, 15, 45, 37, 611, DateTimeKind.Local).AddTicks(4315), "Voluptates esse id rerum beatae et totam reiciendis maxime consequatur.\nQuia minus ullam incidunt error sit.\nVel autem quia dicta optio et architecto illo deserunt.\nQuisquam cupiditate eius velit.\nNumquam numquam vero eligendi voluptates ipsum atque et.\nRepellat harum perferendis mollitia iusto." },
                    { 133, 62, 80, 393334, new DateTime(2021, 5, 23, 3, 31, 33, 375, DateTimeKind.Local).AddTicks(1202), "Voluptas odio distinctio tempore quis nulla aut.\nConsequatur eos voluptates facere voluptatibus quis." },
                    { 152, 62, 141, 479774, new DateTime(2021, 5, 8, 4, 15, 27, 640, DateTimeKind.Local).AddTicks(7999), "ab" },
                    { 207, 62, 54, 398264, new DateTime(2021, 3, 19, 18, 6, 52, 262, DateTimeKind.Local).AddTicks(2120), "Id id quia beatae. Iure aperiam modi nesciunt deserunt et. Velit aut illo. Quia quibusdam doloremque molestias sequi voluptas odit aut et. Consequatur placeat eveniet inventore qui autem sunt et laudantium. Provident pariatur cumque asperiores aut velit amet impedit." },
                    { 290, 44, 53, 485364, new DateTime(2021, 3, 3, 10, 33, 11, 539, DateTimeKind.Local).AddTicks(1971), "laborum" },
                    { 531, 62, 97, 892661, new DateTime(2021, 6, 15, 6, 41, 38, 558, DateTimeKind.Local).AddTicks(5028), "Culpa et voluptatem minus doloremque repellendus earum. Maxime nostrum quae architecto praesentium qui non nihil. Recusandae nam eum excepturi ut enim repellendus in aliquam est." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 222, 52, 34, 837516, new DateTime(2021, 6, 28, 20, 30, 38, 52, DateTimeKind.Local).AddTicks(6739), "Quidem ut eum nostrum error quidem cum incidunt consequatur itaque." },
                    { 129, 52, 99, 417330, new DateTime(2020, 10, 29, 12, 56, 35, 270, DateTimeKind.Local).AddTicks(3376), "Quas officia qui ut in officiis. Et eligendi labore ex. Ducimus corrupti nisi quisquam enim sunt. Minima optio repellendus velit eum sed sint." },
                    { 400, 46, 107, 277424, new DateTime(2020, 9, 25, 18, 13, 29, 854, DateTimeKind.Local).AddTicks(5731), "Dolores quidem molestias voluptatem eum non nemo dignissimos." },
                    { 488, 46, 63, 450601, new DateTime(2021, 6, 4, 23, 25, 8, 564, DateTimeKind.Local).AddTicks(3982), "Quis molestiae id dolor velit." },
                    { 503, 46, 114, 320313, new DateTime(2021, 7, 7, 8, 45, 19, 61, DateTimeKind.Local).AddTicks(95), "aperiam" },
                    { 591, 46, 34, 829169, new DateTime(2021, 6, 21, 17, 32, 0, 232, DateTimeKind.Local).AddTicks(2896), "Possimus labore alias quo deserunt asperiores." },
                    { 596, 46, 89, 672892, new DateTime(2021, 3, 5, 0, 6, 54, 465, DateTimeKind.Local).AddTicks(9028), "Placeat nisi voluptatem earum dignissimos eos." },
                    { 65, 75, 121, 831412, new DateTime(2020, 9, 8, 3, 34, 14, 604, DateTimeKind.Local).AddTicks(63), "Iusto qui est et ab distinctio libero." },
                    { 103, 75, 20, 565711, new DateTime(2020, 11, 4, 5, 12, 40, 715, DateTimeKind.Local).AddTicks(5101), "Ducimus et dolore autem ut corrupti quas eum doloribus dolores. Quaerat eius vitae. Quam recusandae nihil fugiat inventore saepe cupiditate ut." },
                    { 134, 52, 129, 196284, new DateTime(2020, 12, 28, 0, 10, 52, 754, DateTimeKind.Local).AddTicks(9343), "et" },
                    { 128, 75, 99, 942218, new DateTime(2020, 11, 6, 6, 24, 27, 124, DateTimeKind.Local).AddTicks(4926), "Minus dolor illo sed." },
                    { 419, 75, 104, 792776, new DateTime(2020, 11, 29, 8, 30, 47, 719, DateTimeKind.Local).AddTicks(3564), "Vel maiores aut sit soluta.\nModi dolorem beatae dolor velit dolore dignissimos veniam assumenda.\nVelit aut est velit libero esse nostrum excepturi autem voluptate.\nNobis ut qui vero id et ut pariatur sapiente quia.\nAlias deserunt quaerat minima quam ut sit odio quia dolor." },
                    { 420, 75, 115, 781895, new DateTime(2021, 6, 18, 13, 8, 16, 356, DateTimeKind.Local).AddTicks(8392), "Sapiente optio animi tempora ad non sed. Quaerat et aut sit explicabo et. Illum provident aut aspernatur sequi iure repellat voluptatem voluptas. Quis dolores ut iste dicta." },
                    { 434, 75, 77, 49816, new DateTime(2020, 9, 30, 3, 27, 21, 954, DateTimeKind.Local).AddTicks(2540), "Qui ea animi non consectetur repudiandae aut consequatur eaque." },
                    { 551, 75, 21, 797741, new DateTime(2020, 9, 10, 21, 43, 40, 207, DateTimeKind.Local).AddTicks(2532), "Omnis vel ipsum ex tempore reiciendis sit.\nAnimi animi est architecto voluptatem.\nEsse est sunt." },
                    { 582, 75, 77, 63457, new DateTime(2021, 5, 19, 10, 7, 17, 294, DateTimeKind.Local).AddTicks(5967), "delectus" },
                    { 29, 52, 10, 143420, new DateTime(2021, 5, 22, 15, 40, 40, 707, DateTimeKind.Local).AddTicks(5802), "quo" },
                    { 34, 52, 43, 995250, new DateTime(2021, 4, 12, 0, 45, 43, 832, DateTimeKind.Local).AddTicks(5365), "Aut omnis perferendis quis maiores ex numquam. Esse qui saepe minus quia id recusandae eius aut et. Minima expedita officia. Ut dolores quaerat cupiditate. Eaque magni quia molestiae tempora expedita eius animi. Maxime suscipit nemo et harum debitis doloribus sit et." },
                    { 364, 75, 127, 556106, new DateTime(2021, 3, 10, 8, 23, 40, 572, DateTimeKind.Local).AddTicks(2488), "Voluptatum reiciendis delectus facere unde optio iste in magni. Neque sint quo accusamus. Suscipit et modi odio qui soluta qui perferendis earum." },
                    { 47, 66, 60, 80462, new DateTime(2021, 3, 28, 19, 8, 23, 833, DateTimeKind.Local).AddTicks(8766), "Sed sit minima pariatur animi possimus odio. Ipsa quo odio vel labore architecto voluptate eos explicabo nihil. Ipsum eos similique quo dolorem ducimus. Odio facilis voluptatem quis iusto magni dicta tenetur et. Aut facere molestiae sed consequuntur inventore. Laboriosam dolorem quibusdam qui atque repudiandae." },
                    { 473, 3, 40, 920231, new DateTime(2020, 9, 19, 1, 34, 39, 238, DateTimeKind.Local).AddTicks(1258), "Autem sapiente doloremque perspiciatis. Dolorem minima adipisci aut repellendus aliquam sint. Ut eius fugiat quia. Placeat architecto iusto hic harum. Aut sunt minus autem earum. Fugiat reprehenderit in sit quis quaerat et." },
                    { 462, 16, 124, 902942, new DateTime(2021, 2, 7, 10, 34, 12, 945, DateTimeKind.Local).AddTicks(4149), "Sunt repellat et qui vitae qui ut fugiat nostrum." },
                    { 318, 98, 47, 669729, new DateTime(2021, 6, 9, 21, 41, 25, 762, DateTimeKind.Local).AddTicks(1173), "accusantium" },
                    { 339, 98, 27, 31495, new DateTime(2021, 7, 21, 14, 5, 22, 786, DateTimeKind.Local).AddTicks(4541), "Quos impedit qui tempora et.\nQuis ut sapiente suscipit magnam qui aliquid.\nDolore molestiae delectus non explicabo illum reprehenderit." },
                    { 493, 98, 115, 45513, new DateTime(2021, 5, 24, 17, 0, 11, 279, DateTimeKind.Local).AddTicks(784), "voluptatem" },
                    { 305, 1, 91, 289808, new DateTime(2021, 1, 31, 8, 54, 58, 779, DateTimeKind.Local).AddTicks(4576), "Aut aut beatae repellat officia enim ducimus sunt consequatur.\nQuae nisi natus quis debitis praesentium quia itaque commodi.\nNecessitatibus id et molestias fugiat est.\nExplicabo ut illo.\nAtque tempore autem et modi mollitia corrupti totam vitae." },
                    { 55, 12, 39, 857535, new DateTime(2020, 9, 9, 21, 22, 44, 882, DateTimeKind.Local).AddTicks(906), "Vero quasi soluta. Quam accusamus deleniti adipisci. Est ea soluta repellendus. Reprehenderit quisquam praesentium et. Aut doloremque aliquam necessitatibus dignissimos." },
                    { 71, 12, 119, 424204, new DateTime(2020, 10, 15, 4, 43, 57, 680, DateTimeKind.Local).AddTicks(7948), "Aut nobis fugiat maxime ea." },
                    { 244, 98, 56, 952452, new DateTime(2021, 6, 30, 6, 47, 14, 81, DateTimeKind.Local).AddTicks(6114), "Vero iste ut sequi et asperiores et sint mollitia quaerat.\nQui expedita eligendi nostrum provident maiores inventore ducimus necessitatibus qui." },
                    { 251, 1, 109, 555146, new DateTime(2021, 6, 19, 9, 55, 9, 242, DateTimeKind.Local).AddTicks(1413), "alias" },
                    { 257, 12, 87, 701128, new DateTime(2020, 12, 15, 1, 26, 10, 978, DateTimeKind.Local).AddTicks(2851), "voluptatem" },
                    { 311, 12, 124, 911282, new DateTime(2020, 9, 7, 12, 44, 56, 759, DateTimeKind.Local).AddTicks(1767), "Id vel minus sunt neque tempora eaque distinctio dolore repellendus.\nDucimus aut fuga qui maiores aperiam quia et.\nQuia ipsum consequatur facere est consectetur aliquid velit." },
                    { 396, 12, 135, 645568, new DateTime(2021, 7, 22, 14, 44, 34, 153, DateTimeKind.Local).AddTicks(8351), "aliquam" },
                    { 448, 12, 112, 197893, new DateTime(2021, 7, 8, 0, 9, 33, 984, DateTimeKind.Local).AddTicks(9062), "Laudantium amet fugit." },
                    { 217, 1, 17, 457345, new DateTime(2021, 7, 7, 6, 35, 57, 980, DateTimeKind.Local).AddTicks(9076), "Velit omnis deserunt perferendis repellendus hic fugiat. Alias qui eos. Ut qui suscipit. Beatae ratione illo porro vitae. Asperiores deserunt libero velit repellendus omnis iure." },
                    { 495, 12, 67, 193141, new DateTime(2021, 2, 25, 19, 1, 27, 758, DateTimeKind.Local).AddTicks(3104), "ea" },
                    { 108, 12, 117, 361842, new DateTime(2021, 2, 3, 23, 44, 9, 451, DateTimeKind.Local).AddTicks(1683), "Voluptas officia quod quis sit minima explicabo." },
                    { 541, 12, 103, 285676, new DateTime(2021, 1, 4, 11, 8, 46, 6, DateTimeKind.Local).AddTicks(6628), "rerum" },
                    { 160, 98, 30, 723004, new DateTime(2020, 8, 20, 18, 22, 37, 944, DateTimeKind.Local).AddTicks(892), "Tenetur sapiente qui dolor labore ab culpa est illum. Fugiat officia nihil at eum optio dolore ut numquam voluptates. Ut expedita numquam voluptas eum placeat vel rem. Molestiae necessitatibus qui est similique. Et laudantium vitae esse quis praesentium at sit. Eum nobis et laborum non itaque." },
                    { 527, 97, 138, 411209, new DateTime(2021, 7, 11, 20, 16, 8, 615, DateTimeKind.Local).AddTicks(9769), "iste" },
                    { 45, 59, 136, 586423, new DateTime(2020, 12, 28, 14, 26, 30, 418, DateTimeKind.Local).AddTicks(7871), "Ea ab atque.\nNam eos autem quam non ut fuga illo et ut.\nSint fuga et ut ea quasi sint dolorum quam.\nNam ipsum dolorem accusamus voluptatem illo." },
                    { 330, 59, 34, 699012, new DateTime(2021, 2, 18, 6, 37, 29, 572, DateTimeKind.Local).AddTicks(9891), "commodi" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 334, 59, 112, 886487, new DateTime(2020, 10, 24, 21, 50, 9, 209, DateTimeKind.Local).AddTicks(2578), "Dolores et occaecati atque sequi aliquid qui minima adipisci fugit.\nDolorum similique perspiciatis commodi.\nIpsa consequuntur illum officiis dolorem placeat." },
                    { 371, 59, 130, 975485, new DateTime(2021, 2, 26, 13, 46, 17, 114, DateTimeKind.Local).AddTicks(1896), "Corrupti voluptatem odio consequuntur cupiditate molestiae quisquam temporibus sapiente nobis." },
                    { 378, 59, 93, 238367, new DateTime(2021, 2, 10, 0, 48, 1, 840, DateTimeKind.Local).AddTicks(185), "enim" },
                    { 547, 59, 146, 999218, new DateTime(2021, 5, 5, 22, 50, 21, 449, DateTimeKind.Local).AddTicks(8759), "Suscipit assumenda reiciendis eaque totam perferendis odio nulla." },
                    { 68, 98, 137, 211652, new DateTime(2021, 7, 18, 14, 33, 24, 246, DateTimeKind.Local).AddTicks(6641), "est" },
                    { 48, 97, 110, 355879, new DateTime(2020, 12, 23, 10, 35, 49, 470, DateTimeKind.Local).AddTicks(8344), "Nemo fugit in temporibus ipsam quibusdam at tempore in enim.\nVeniam sunt voluptatibus aliquam laboriosam et enim quae.\nMagni quis laboriosam." },
                    { 83, 97, 91, 172224, new DateTime(2020, 11, 30, 15, 21, 28, 420, DateTimeKind.Local).AddTicks(8062), "modi" },
                    { 179, 97, 30, 387288, new DateTime(2021, 3, 19, 8, 41, 29, 223, DateTimeKind.Local).AddTicks(6888), "Voluptatem minus est illum iure omnis." },
                    { 189, 97, 110, 911811, new DateTime(2021, 6, 5, 13, 17, 12, 194, DateTimeKind.Local).AddTicks(1093), "Rerum aspernatur ut earum qui sit animi saepe voluptates. Autem repellendus ut officia ea est unde. Expedita qui est." },
                    { 377, 97, 56, 354873, new DateTime(2021, 1, 18, 23, 37, 58, 48, DateTimeKind.Local).AddTicks(2466), "Saepe porro et recusandae qui iure qui velit vitae.\nCorrupti et veniam est voluptatem aut.\nEst quia numquam.\nNam non impedit tempore illo at sit ducimus.\nDolorem eligendi odio eum et at." },
                    { 384, 97, 30, 20097, new DateTime(2021, 3, 21, 16, 27, 26, 437, DateTimeKind.Local).AddTicks(5728), "Enim cumque doloribus similique ex mollitia." },
                    { 404, 1, 95, 863060, new DateTime(2021, 6, 11, 13, 13, 34, 933, DateTimeKind.Local).AddTicks(2108), "Id quia ut eius molestias." },
                    { 80, 97, 58, 174214, new DateTime(2021, 3, 5, 6, 21, 4, 335, DateTimeKind.Local).AddTicks(8841), "Sunt laboriosam qui quis dolores eos perferendis et. Quis rerum sint. Expedita ipsa cum fuga magnam qui architecto assumenda. Rerum praesentium ipsa sed ducimus. Tempore laboriosam et aut mollitia ea aperiam qui." },
                    { 53, 1, 68, 125246, new DateTime(2021, 2, 9, 20, 17, 25, 992, DateTimeKind.Local).AddTicks(9743), "doloribus" },
                    { 35, 16, 110, 666110, new DateTime(2020, 12, 29, 18, 41, 8, 558, DateTimeKind.Local).AddTicks(1493), "Temporibus nihil a occaecati." },
                    { 122, 16, 19, 620844, new DateTime(2020, 10, 3, 0, 7, 26, 272, DateTimeKind.Local).AddTicks(5419), "Necessitatibus inventore rerum." },
                    { 28, 33, 58, 120376, new DateTime(2021, 1, 13, 19, 14, 38, 747, DateTimeKind.Local).AddTicks(5008), "Voluptates ullam ut tempore laboriosam at adipisci distinctio sint.\nSed ut eos." },
                    { 100, 33, 33, 196533, new DateTime(2021, 7, 15, 1, 29, 5, 473, DateTimeKind.Local).AddTicks(5395), "Eos et dolor quasi.\nHic vel qui est consequuntur dolor facilis quaerat est.\nEa hic vitae veritatis.\nVeniam repudiandae sint.\nQui est ducimus cupiditate sunt ratione quod." },
                    { 190, 33, 120, 634917, new DateTime(2021, 4, 15, 13, 8, 34, 895, DateTimeKind.Local).AddTicks(4530), "quam" },
                    { 214, 33, 119, 717848, new DateTime(2021, 4, 21, 23, 0, 3, 26, DateTimeKind.Local).AddTicks(4688), "Aliquid vel dolor rerum expedita omnis mollitia blanditiis." },
                    { 264, 33, 67, 978076, new DateTime(2020, 12, 2, 10, 33, 22, 927, DateTimeKind.Local).AddTicks(5111), "Accusamus minima ut dignissimos. Earum qui voluptates tempora pariatur harum quis aut. Molestiae molestiae sint excepturi illum sunt omnis." },
                    { 354, 33, 19, 805559, new DateTime(2021, 1, 21, 8, 48, 35, 167, DateTimeKind.Local).AddTicks(7133), "Est fuga facilis quos." },
                    { 310, 19, 31, 623530, new DateTime(2020, 12, 21, 22, 13, 15, 455, DateTimeKind.Local).AddTicks(5157), "Ut earum ut nulla pariatur eum.\nAt similique aspernatur ipsam molestias et assumenda id.\nIncidunt quia corrupti.\nEt suscipit assumenda animi.\nVelit adipisci ipsam." },
                    { 409, 33, 74, 209567, new DateTime(2021, 5, 5, 20, 56, 27, 635, DateTimeKind.Local).AddTicks(2376), "Accusantium quo dolorum ea voluptatem quia ad.\nNihil qui nemo.\nAliquam ea qui commodi.\nExpedita magni itaque hic officia vel quia dolor sequi." },
                    { 148, 35, 110, 188360, new DateTime(2020, 10, 24, 11, 16, 7, 644, DateTimeKind.Local).AddTicks(5458), "Delectus est ea. Ut provident doloribus sapiente vel molestias voluptatem molestiae. Fugit qui quia aut ipsum. Quis deserunt molestiae porro porro ut accusamus quisquam molestiae ipsa. Beatae esse aliquid odio ipsa ad dolore. Vitae sit reiciendis aut nisi aut odit dignissimos." },
                    { 218, 35, 89, 1165, new DateTime(2020, 11, 10, 14, 50, 53, 283, DateTimeKind.Local).AddTicks(2811), "Molestiae laudantium id vel. Quos ratione et aspernatur unde veritatis animi dignissimos saepe. Eius et ut non deserunt." },
                    { 273, 35, 122, 662814, new DateTime(2020, 12, 25, 3, 2, 4, 225, DateTimeKind.Local).AddTicks(3793), "Quia aliquam aliquam eveniet beatae iste nemo.\nSunt nihil quibusdam." },
                    { 362, 35, 62, 645689, new DateTime(2021, 4, 6, 6, 21, 46, 826, DateTimeKind.Local).AddTicks(7600), "Quasi ipsum dicta consectetur dolor sint eum quibusdam." },
                    { 204, 19, 56, 652865, new DateTime(2021, 6, 22, 12, 17, 0, 802, DateTimeKind.Local).AddTicks(2326), "Laboriosam enim est qui. Eum placeat eaque sed consectetur placeat ut inventore. Ipsam ut repellendus animi voluptatem laboriosam labore non. Ratione et ullam labore velit blanditiis aperiam voluptatum dolore." },
                    { 27, 69, 11, 257279, new DateTime(2020, 11, 30, 19, 45, 22, 167, DateTimeKind.Local).AddTicks(4981), "Vitae libero dolores aliquid veniam. Animi nihil deserunt fugit et reiciendis autem esse culpa. Tenetur qui nostrum voluptatem sapiente optio est distinctio aut qui. Sed suscipit sit aperiam sed." },
                    { 228, 19, 80, 543364, new DateTime(2021, 6, 17, 14, 6, 43, 825, DateTimeKind.Local).AddTicks(1268), "Ipsa omnis ut dolores culpa reprehenderit." },
                    { 450, 29, 49, 934765, new DateTime(2021, 4, 3, 17, 30, 17, 484, DateTimeKind.Local).AddTicks(2640), "Qui nobis incidunt culpa qui distinctio et non.\nAb nostrum qui repellendus laboriosam cum repellat minima ea dolore.\nDolor quia nihil eos voluptas similique eum.\nDolores aut sed nulla dolorem dolores iusto.\nHic quis eveniet molestiae est officiis molestiae laborum beatae." },
                    { 421, 29, 66, 879654, new DateTime(2021, 5, 21, 8, 53, 28, 653, DateTimeKind.Local).AddTicks(719), "Et qui distinctio quisquam et nesciunt ut. Quaerat accusantium aliquid voluptates aut sed. Est dolor adipisci delectus cum ad accusamus maiores. Error molestiae quia possimus voluptatem dignissimos voluptas perspiciatis ut." },
                    { 235, 29, 25, 7595, new DateTime(2020, 10, 20, 6, 49, 37, 243, DateTimeKind.Local).AddTicks(3977), "Aut rerum nihil a. Aliquid sit a. Adipisci veritatis minima ratione quos et pariatur commodi. Officia eveniet similique aut sit aliquid illum qui eos. Et et eos quas fugiat. Maxime velit dolorum reiciendis aut dolorem explicabo." },
                    { 14, 1, 141, 987047, new DateTime(2020, 8, 31, 18, 21, 9, 827, DateTimeKind.Local).AddTicks(2096), "doloremque" },
                    { 147, 16, 130, 938515, new DateTime(2020, 11, 1, 20, 20, 3, 670, DateTimeKind.Local).AddTicks(384), "corporis" },
                    { 254, 16, 11, 275798, new DateTime(2021, 1, 20, 6, 53, 12, 272, DateTimeKind.Local).AddTicks(609), "Vel ut unde est reiciendis.\nQuia quos ea et ea.\nNon et accusamus et enim voluptatem temporibus autem dignissimos atque.\nIure omnis consequatur quia error.\nQuia consequuntur natus et.\nPerspiciatis repellendus et voluptatem quos commodi." },
                    { 266, 16, 32, 883737, new DateTime(2021, 5, 19, 18, 26, 16, 140, DateTimeKind.Local).AddTicks(7569), "Alias tempora illum.\nVoluptas ad et sed doloremque doloremque veniam.\nQui ad quia praesentium non ullam asperiores.\nEt neque corporis et alias deserunt et." },
                    { 401, 16, 114, 843622, new DateTime(2021, 3, 5, 8, 7, 49, 746, DateTimeKind.Local).AddTicks(8373), "Modi molestiae esse minima qui exercitationem iure. Eius aspernatur enim. Ab quasi autem quo non." },
                    { 552, 19, 28, 56724, new DateTime(2020, 10, 24, 13, 30, 0, 298, DateTimeKind.Local).AddTicks(3893), "Sunt esse cumque dolor autem odio consequatur alias quia dolorem." },
                    { 418, 16, 106, 785401, new DateTime(2021, 2, 22, 8, 27, 16, 643, DateTimeKind.Local).AddTicks(2036), "Soluta iusto deleniti odit et quae mollitia est similique veritatis." },
                    { 441, 16, 110, 491565, new DateTime(2021, 2, 2, 22, 6, 52, 513, DateTimeKind.Local).AddTicks(8702), "Officia voluptatibus qui vero reprehenderit autem quod et.\nVoluptatibus aperiam natus inventore." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 25, 66, 25, 597769, new DateTime(2021, 5, 6, 3, 43, 56, 957, DateTimeKind.Local).AddTicks(3177), "autem" },
                    { 23, 29, 144, 459474, new DateTime(2020, 12, 30, 21, 47, 18, 87, DateTimeKind.Local).AddTicks(1205), "Ab minus officiis quidem aut rem voluptas sed." },
                    { 104, 29, 62, 687192, new DateTime(2020, 10, 1, 17, 50, 9, 64, DateTimeKind.Local).AddTicks(7994), "similique" },
                    { 118, 29, 135, 479967, new DateTime(2020, 11, 23, 1, 55, 4, 411, DateTimeKind.Local).AddTicks(3826), "quis" },
                    { 151, 29, 12, 455305, new DateTime(2020, 10, 13, 0, 56, 13, 593, DateTimeKind.Local).AddTicks(7382), "Illo provident qui enim corporis reprehenderit omnis.\nReiciendis alias eum natus rerum voluptatibus consequatur repudiandae inventore.\nSoluta et consequatur.\nFugit neque est.\nId quia modi." },
                    { 194, 29, 56, 169715, new DateTime(2021, 3, 17, 23, 44, 33, 17, DateTimeKind.Local).AddTicks(5943), "Incidunt velit dolore rerum laboriosam dolore similique." },
                    { 211, 29, 146, 670860, new DateTime(2020, 9, 24, 1, 57, 36, 425, DateTimeKind.Local).AddTicks(5119), "Et et dolorem fugiat autem quaerat rerum ullam ut mollitia." },
                    { 44, 59, 135, 213260, new DateTime(2021, 6, 17, 3, 36, 53, 875, DateTimeKind.Local).AddTicks(2928), "Quam perspiciatis et aut accusamus voluptas et omnis est adipisci." },
                    { 433, 35, 116, 564923, new DateTime(2021, 2, 22, 23, 24, 5, 707, DateTimeKind.Local).AddTicks(6361), "Dicta aspernatur eveniet est.\nVoluptates quidem et ratione." },
                    { 559, 1, 46, 870861, new DateTime(2020, 10, 4, 12, 1, 58, 698, DateTimeKind.Local).AddTicks(9376), "Autem ea officiis id in voluptatem laborum nulla." },
                    { 451, 11, 73, 417192, new DateTime(2020, 9, 22, 11, 6, 16, 678, DateTimeKind.Local).AddTicks(8786), "voluptatum" },
                    { 561, 79, 65, 50518, new DateTime(2020, 10, 3, 10, 24, 21, 737, DateTimeKind.Local).AddTicks(6453), "Ut commodi et." },
                    { 95, 83, 150, 416678, new DateTime(2020, 9, 7, 2, 3, 16, 710, DateTimeKind.Local).AddTicks(6300), "Ratione laborum placeat dolore nemo eum." },
                    { 116, 83, 4, 124161, new DateTime(2021, 6, 18, 11, 49, 16, 690, DateTimeKind.Local).AddTicks(9902), "Quidem blanditiis vel hic rerum culpa quis vitae nesciunt.\nOmnis maiores quia omnis id magni.\nQui alias dolores dicta beatae velit.\nDucimus incidunt et molestias consequatur quasi voluptatum." },
                    { 208, 83, 15, 707679, new DateTime(2020, 11, 6, 22, 57, 12, 86, DateTimeKind.Local).AddTicks(3473), "Debitis maxime ut illo quo harum modi ipsum nihil eum. Voluptas aspernatur eos quo earum. Laboriosam voluptas quaerat voluptas aspernatur eaque provident tenetur culpa qui. Molestias dolorem est quo dicta sit at ab. Consectetur fuga explicabo nemo cum asperiores est est. Dicta nulla in blanditiis est sit culpa unde unde." },
                    { 247, 83, 77, 462434, new DateTime(2021, 8, 13, 22, 17, 11, 507, DateTimeKind.Local).AddTicks(3857), "Dolore quibusdam non aliquid quidem praesentium nostrum non aspernatur ipsum.\nSaepe est ipsum nostrum nemo laboriosam soluta error.\nNon cupiditate quam qui ad fugiat natus beatae." },
                    { 341, 83, 57, 401875, new DateTime(2020, 12, 3, 8, 0, 21, 458, DateTimeKind.Local).AddTicks(575), "cumque" },
                    { 511, 79, 66, 444244, new DateTime(2020, 12, 15, 5, 7, 46, 223, DateTimeKind.Local).AddTicks(6147), "Numquam enim ut atque consectetur dolorum.\nMinus fugiat aspernatur.\nNihil molestiae quae sunt voluptas sunt recusandae dolore maxime temporibus.\nLaudantium qui excepturi vel sapiente quaerat doloremque sequi deserunt ducimus." },
                    { 346, 83, 148, 652541, new DateTime(2021, 4, 29, 12, 9, 40, 655, DateTimeKind.Local).AddTicks(756), "Dolore voluptatem a officia voluptatem." },
                    { 166, 43, 79, 192240, new DateTime(2021, 5, 29, 14, 57, 12, 785, DateTimeKind.Local).AddTicks(8573), "Consequatur saepe ut consequatur asperiores nostrum et tempora fuga.\nEa animi nemo repudiandae impedit non fugit reiciendis dolore nobis.\nCupiditate et possimus aut est.\nDicta blanditiis perferendis vel sed nesciunt pariatur.\nEt aut laudantium molestiae incidunt sint." },
                    { 556, 83, 106, 974472, new DateTime(2021, 3, 12, 20, 15, 50, 154, DateTimeKind.Local).AddTicks(335), "Consequuntur inventore atque ea possimus omnis illo odio autem eveniet." },
                    { 593, 83, 4, 677301, new DateTime(2020, 11, 7, 1, 36, 7, 905, DateTimeKind.Local).AddTicks(9569), "Autem tenetur veritatis laudantium.\nQui sit amet in.\nSit dolorum libero.\nEst eum quo ullam." },
                    { 237, 21, 30, 901834, new DateTime(2021, 6, 27, 9, 41, 25, 896, DateTimeKind.Local).AddTicks(6464), "Omnis aut quod explicabo ab amet rerum dignissimos est aliquam." },
                    { 267, 21, 92, 531471, new DateTime(2020, 9, 17, 1, 22, 54, 401, DateTimeKind.Local).AddTicks(6832), "quo" },
                    { 294, 21, 100, 105191, new DateTime(2021, 8, 15, 16, 55, 11, 890, DateTimeKind.Local).AddTicks(9819), "Aut voluptas et cum distinctio sunt voluptas ipsum unde omnis. Est recusandae qui hic. Nulla ab et officia totam ipsa qui doloremque. Eum eum nihil dolor optio et. Saepe repudiandae voluptatibus et veritatis." },
                    { 548, 83, 150, 343281, new DateTime(2021, 7, 15, 19, 43, 5, 227, DateTimeKind.Local).AddTicks(4995), "quod" },
                    { 327, 21, 61, 880262, new DateTime(2021, 3, 10, 15, 28, 47, 640, DateTimeKind.Local).AddTicks(6151), "Qui ea laboriosam laudantium consequatur possimus. Et voluptatum aut sit molestiae quis. Qui ullam id voluptatem facere rerum a." },
                    { 471, 79, 51, 836622, new DateTime(2020, 12, 10, 3, 38, 27, 355, DateTimeKind.Local).AddTicks(7206), "est" },
                    { 382, 79, 139, 406763, new DateTime(2021, 3, 30, 2, 39, 52, 820, DateTimeKind.Local).AddTicks(1326), "Corporis consequatur recusandae debitis ullam.\nQuo perspiciatis quia dolorem consequatur dolor illo ratione deserunt fugiat.\nAssumenda officia et est enim ut fuga.\nIste nobis ea.\nNisi nostrum possimus occaecati quae possimus officia at velit.\nVero quo labore dolore nulla facere facilis in maxime animi." },
                    { 177, 69, 118, 460016, new DateTime(2021, 1, 26, 7, 55, 48, 100, DateTimeKind.Local).AddTicks(874), "Possimus delectus recusandae voluptate consequuntur ut dolores perferendis." },
                    { 499, 69, 48, 735740, new DateTime(2021, 7, 28, 5, 42, 1, 927, DateTimeKind.Local).AddTicks(3932), "Qui aut aliquid porro praesentium ipsum molestias. Qui similique sapiente ratione. Est quis ut. Qui distinctio impedit doloribus non doloremque nihil. Voluptas mollitia error. Magni voluptas dolor." },
                    { 57, 74, 19, 603968, new DateTime(2021, 1, 4, 0, 54, 57, 482, DateTimeKind.Local).AddTicks(716), "Numquam natus facere eius.\nRatione dolorum ut odit." },
                    { 144, 74, 142, 982469, new DateTime(2020, 11, 29, 10, 21, 35, 992, DateTimeKind.Local).AddTicks(2648), "Ex totam qui. Magni quibusdam consequatur dicta molestiae quasi. Quae rerum magnam cupiditate voluptates natus nihil. Sed qui tempora mollitia placeat quia laboriosam vero eius tempora. Aliquam non vitae laboriosam nulla voluptas itaque accusantium." },
                    { 141, 65, 44, 693584, new DateTime(2021, 4, 10, 22, 10, 21, 234, DateTimeKind.Local).AddTicks(9342), "Iusto beatae quasi nihil inventore quia temporibus fugiat quasi. Illo ea fugit est dolorem sed neque perferendis aspernatur sapiente. Id voluptate inventore voluptatem suscipit perspiciatis. Aut labore et debitis consectetur." },
                    { 435, 74, 130, 110905, new DateTime(2021, 4, 19, 19, 42, 57, 253, DateTimeKind.Local).AddTicks(5100), "Cum rerum laboriosam. Beatae officiis ut ea nemo eius doloremque vitae. Hic vel quos a minima ullam laborum id vel repudiandae." },
                    { 304, 43, 81, 728422, new DateTime(2021, 4, 28, 3, 12, 5, 649, DateTimeKind.Local).AddTicks(8368), "In et voluptatum quis. Ea iste et. Cum atque inventore reprehenderit doloribus. Aut commodi temporibus consequuntur iste quia." },
                    { 506, 74, 2, 739928, new DateTime(2020, 9, 11, 16, 28, 41, 446, DateTimeKind.Local).AddTicks(9034), "temporibus" },
                    { 514, 74, 106, 844445, new DateTime(2021, 6, 26, 5, 22, 12, 272, DateTimeKind.Local).AddTicks(2413), "Beatae ut tempore est incidunt consequatur explicabo ut.\nExpedita quibusdam nihil soluta molestias sed facere maiores enim.\nSunt possimus in rerum.\nFuga repellendus dolor laborum iste libero dolores.\nUt praesentium excepturi sit alias quo perspiciatis harum." },
                    { 599, 74, 66, 271870, new DateTime(2021, 7, 20, 18, 7, 34, 235, DateTimeKind.Local).AddTicks(2415), "Corrupti sunt aut tenetur occaecati libero est voluptatem voluptatem.\nHic natus quia nostrum exercitationem et est nemo libero nihil.\nEt aliquam vel.\nReiciendis sunt quam itaque dolor sed beatae minus et.\nMolestiae possimus quisquam minus odio expedita veritatis." },
                    { 539, 43, 71, 537972, new DateTime(2021, 4, 30, 10, 36, 39, 196, DateTimeKind.Local).AddTicks(4434), "Voluptas voluptatibus id omnis.\nAliquid rem et corporis.\nEarum fuga sit." },
                    { 182, 79, 111, 916930, new DateTime(2020, 9, 10, 11, 20, 3, 605, DateTimeKind.Local).AddTicks(4913), "Id veritatis quis.\nFacere ducimus totam aperiam et fugit." },
                    { 210, 79, 2, 857709, new DateTime(2021, 4, 6, 13, 49, 50, 400, DateTimeKind.Local).AddTicks(39), "Porro ut hic et odit molestiae voluptas vitae quos. Aut ab sint et aliquam sed harum. Nisi non sunt." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 343, 79, 148, 196937, new DateTime(2021, 2, 18, 22, 21, 36, 766, DateTimeKind.Local).AddTicks(6946), "Iure consequatur id laborum tempora voluptas et. Non esse cum assumenda illo voluptas omnis. Voluptas sit eaque. Quia facilis numquam. Perspiciatis consequatur eaque aut quis dolore. Ut beatae est voluptas placeat possimus sit porro blanditiis." },
                    { 508, 74, 148, 299298, new DateTime(2021, 2, 26, 7, 29, 22, 851, DateTimeKind.Local).AddTicks(7537), "At aliquam nihil hic sint enim.\nVeniam quibusdam officiis.\nTempora recusandae nobis sit pariatur distinctio saepe occaecati.\nAliquid sed quam id sapiente sunt voluptas maiores quo." },
                    { 407, 21, 70, 505301, new DateTime(2021, 3, 21, 14, 54, 11, 887, DateTimeKind.Local).AddTicks(314), "Non aut voluptatem ducimus magni ducimus et.\nNumquam nesciunt quia.\nDelectus omnis voluptatum.\nSunt autem autem et non esse et odio autem.\nConsequatur atque est magni nihil consequatur.\nSuscipit doloremque qui." },
                    { 410, 21, 11, 311428, new DateTime(2021, 2, 4, 14, 13, 59, 579, DateTimeKind.Local).AddTicks(1626), "Illo ullam illo ab.\nOfficia et vero et molestiae excepturi consequatur.\nQuia cum quia.\nNihil explicabo in et culpa odio ut et in asperiores.\nEt dolor recusandae.\nDeleniti aspernatur velit aut." },
                    { 123, 43, 109, 273, new DateTime(2020, 11, 18, 15, 2, 4, 820, DateTimeKind.Local).AddTicks(55), "Vero magnam qui explicabo suscipit." },
                    { 424, 7, 120, 199046, new DateTime(2021, 6, 10, 8, 16, 14, 700, DateTimeKind.Local).AddTicks(4761), "Explicabo perspiciatis similique ad impedit pariatur vitae deserunt veniam iste.\nEligendi nulla natus dicta assumenda vel sapiente autem qui ut.\nAut vero est.\nOptio voluptatem iure non earum dolor esse.\nTempora at porro rem eveniet minima et id quos.\nDoloremque illum dolores minus." },
                    { 11, 64, 139, 876075, new DateTime(2021, 7, 24, 4, 35, 40, 865, DateTimeKind.Local).AddTicks(5081), "Similique cumque facere vitae atque et nihil blanditiis earum qui.\nTenetur nesciunt aliquam quia exercitationem.\nId et unde voluptas voluptatem sit non quidem doloremque.\nConsequuntur doloremque eos.\nAt eaque quo mollitia eum nobis sit eius.\nEt reiciendis nostrum maiores impedit rerum aut aut explicabo." },
                    { 321, 64, 89, 326142, new DateTime(2020, 12, 9, 20, 52, 51, 286, DateTimeKind.Local).AddTicks(1167), "Libero reprehenderit aperiam quia.\nNecessitatibus magnam accusantium vero.\nFuga qui iusto quo qui ut nam et molestiae soluta.\nArchitecto et nemo voluptas.\nSed consectetur quis deserunt officia quo cupiditate aut non.\nRatione nobis distinctio." },
                    { 392, 64, 15, 129448, new DateTime(2021, 7, 2, 18, 28, 35, 315, DateTimeKind.Local).AddTicks(1938), "Et ipsum deserunt sed unde fuga. Non id sequi sed ex ut consequatur dolore voluptatem. Alias architecto dolore vel nesciunt quibusdam eveniet nostrum voluptate. Accusamus vel blanditiis aut repellat sequi ut." },
                    { 447, 64, 37, 1152, new DateTime(2021, 4, 14, 7, 33, 50, 742, DateTimeKind.Local).AddTicks(5541), "Quia enim architecto et voluptatum distinctio. Consequatur repudiandae sed voluptatum aspernatur est ut ea nostrum. Labore est accusamus placeat consequatur excepturi sequi. Nemo sint est. Fugiat velit ut occaecati. Quia ipsum nobis nemo temporibus qui minima maiores." },
                    { 523, 64, 76, 294240, new DateTime(2020, 10, 24, 17, 16, 51, 720, DateTimeKind.Local).AddTicks(9216), "omnis" },
                    { 333, 7, 23, 360869, new DateTime(2020, 11, 29, 9, 0, 29, 811, DateTimeKind.Local).AddTicks(2528), "Dicta et vero sed.\nQui iure velit temporibus dolor voluptate.\nVoluptates non eius neque delectus corrupti numquam.\nSed a soluta maiores.\nQuo aut quas eum quae soluta." },
                    { 579, 1, 104, 812379, new DateTime(2021, 3, 2, 9, 19, 14, 575, DateTimeKind.Local).AddTicks(3512), "Enim rerum ipsa ut fuga.\nPerspiciatis suscipit asperiores.\nNihil vel consequatur qui non voluptas id pariatur accusantium.\nEligendi odit deserunt natus voluptas libero numquam omnis quam.\nSequi atque qui inventore velit sed ut rem assumenda qui." },
                    { 600, 64, 142, 856692, new DateTime(2021, 5, 26, 6, 39, 0, 809, DateTimeKind.Local).AddTicks(9491), "in" },
                    { 17, 11, 42, 255510, new DateTime(2020, 12, 18, 12, 22, 56, 522, DateTimeKind.Local).AddTicks(2593), "aut" },
                    { 175, 11, 85, 215600, new DateTime(2021, 7, 29, 15, 34, 51, 378, DateTimeKind.Local).AddTicks(4314), "Aut sit a. Necessitatibus quo ut rerum unde sapiente incidunt. Doloremque tempora dignissimos perferendis quam aspernatur." },
                    { 243, 11, 120, 967475, new DateTime(2021, 1, 16, 16, 21, 10, 668, DateTimeKind.Local).AddTicks(7094), "Non fugit sunt ut sint recusandae quia in." },
                    { 259, 11, 53, 569058, new DateTime(2021, 5, 31, 22, 33, 34, 457, DateTimeKind.Local).AddTicks(9079), "Reprehenderit consequatur neque. Sit accusamus est sit fuga et impedit rerum. Dolorem in fugit beatae voluptatem repellat quia rerum alias aspernatur." },
                    { 308, 11, 37, 345039, new DateTime(2021, 5, 27, 7, 18, 1, 447, DateTimeKind.Local).AddTicks(3086), "Magni reiciendis ut enim esse totam. Fugit eaque accusantium est natus fugit cumque suscipit voluptatem. Cum et quo qui illum totam qui et cum. Culpa itaque unde saepe necessitatibus." },
                    { 565, 64, 38, 130233, new DateTime(2021, 7, 30, 4, 3, 44, 164, DateTimeKind.Local).AddTicks(3359), "vel" },
                    { 298, 7, 71, 354266, new DateTime(2021, 1, 3, 18, 58, 48, 75, DateTimeKind.Local).AddTicks(2522), "amet" },
                    { 270, 7, 124, 455035, new DateTime(2020, 10, 21, 6, 49, 45, 235, DateTimeKind.Local).AddTicks(1099), "Ut voluptatem laborum accusamus similique debitis dignissimos eligendi minima odio." },
                    { 185, 7, 13, 468780, new DateTime(2020, 9, 6, 12, 56, 22, 19, DateTimeKind.Local).AddTicks(3265), "Minima reiciendis architecto mollitia occaecati enim sequi." },
                    { 440, 21, 112, 161936, new DateTime(2021, 8, 13, 22, 28, 29, 846, DateTimeKind.Local).AddTicks(6291), "Odio nisi enim at autem suscipit." },
                    { 92, 43, 116, 314669, new DateTime(2021, 8, 6, 2, 16, 3, 726, DateTimeKind.Local).AddTicks(5072), "Incidunt cum veritatis laborum voluptatem eos iusto." },
                    { 242, 78, 29, 450364, new DateTime(2021, 4, 27, 0, 39, 9, 371, DateTimeKind.Local).AddTicks(2529), "Exercitationem quia provident fugit aspernatur excepturi nihil ullam.\nCorporis vel aut numquam non sit quaerat doloremque sapiente ipsa." },
                    { 293, 78, 146, 631346, new DateTime(2021, 5, 22, 10, 1, 26, 437, DateTimeKind.Local).AddTicks(7744), "Perferendis saepe cupiditate repellendus qui consequatur quia. Nesciunt vel aliquid quidem sunt cupiditate. Sunt sunt expedita necessitatibus quo id laboriosam ut tenetur. Esse praesentium assumenda veniam totam aut a nobis non soluta. Est quas amet nulla optio impedit et ea similique." },
                    { 402, 78, 35, 964944, new DateTime(2020, 9, 18, 22, 28, 22, 205, DateTimeKind.Local).AddTicks(3633), "Repellat sint tempore tempora est nulla. Odit sit eum error consectetur. Cupiditate qui aliquid aut fuga quis modi quasi molestiae. Quis sint error et aliquam." },
                    { 454, 78, 96, 286522, new DateTime(2021, 1, 4, 0, 54, 11, 248, DateTimeKind.Local).AddTicks(1445), "Quae voluptates laudantium qui accusamus corporis dolore sunt dolor totam.\nPerspiciatis voluptatem qui sed ullam molestiae est est.\nEt culpa et facilis.\nOptio voluptas a voluptas quidem aut veniam.\nMolestiae ab error odio mollitia incidunt.\nAut necessitatibus officia enim." },
                    { 459, 78, 66, 534569, new DateTime(2021, 3, 13, 17, 28, 7, 90, DateTimeKind.Local).AddTicks(5354), "Voluptates et sed. Dolorum facere ut nesciunt odit ea. Ducimus vel totam sint blanditiis voluptates sint sed facilis." },
                    { 594, 78, 44, 628966, new DateTime(2020, 9, 12, 3, 5, 41, 124, DateTimeKind.Local).AddTicks(7730), "Dolor placeat totam aliquam assumenda et saepe ut quae non.\nNon non consequatur autem sed eaque aut ratione sint cupiditate.\nRepellat consequuntur asperiores eum quibusdam.\nVel autem voluptas exercitationem sint sint consequatur nihil eos." },
                    { 90, 43, 82, 489705, new DateTime(2020, 9, 23, 12, 27, 15, 456, DateTimeKind.Local).AddTicks(1245), "aperiam" },
                    { 248, 57, 86, 652611, new DateTime(2020, 12, 4, 16, 44, 33, 259, DateTimeKind.Local).AddTicks(3315), "qui" },
                    { 319, 57, 112, 152863, new DateTime(2021, 1, 18, 9, 17, 0, 833, DateTimeKind.Local).AddTicks(7521), "Sit sunt totam quam hic quia facilis deserunt." },
                    { 397, 57, 96, 494788, new DateTime(2021, 8, 9, 17, 7, 18, 484, DateTimeKind.Local).AddTicks(1420), "Cumque cupiditate quis eius veritatis consequatur est." },
                    { 436, 57, 52, 11514, new DateTime(2021, 8, 6, 1, 42, 53, 229, DateTimeKind.Local).AddTicks(1041), "Magni in quia voluptatum. Qui et optio nobis ut et labore fuga aut rerum. Iure dicta et iste dolor tempora iste voluptate ut et." },
                    { 500, 57, 59, 18736, new DateTime(2021, 8, 15, 7, 33, 9, 340, DateTimeKind.Local).AddTicks(359), "Sit cumque ut et facilis quaerat. Architecto perspiciatis sequi beatae rerum consequuntur dolore neque. Laborum architecto molestiae nihil magni sunt rerum. Voluptatem aut dolor. Aliquid non illo. Assumenda ad rerum." },
                    { 534, 57, 113, 310344, new DateTime(2020, 12, 26, 7, 40, 21, 392, DateTimeKind.Local).AddTicks(6714), "alias" },
                    { 568, 11, 98, 116580, new DateTime(2020, 10, 10, 18, 43, 14, 440, DateTimeKind.Local).AddTicks(6819), "Sit adipisci vero eos autem." },
                    { 475, 35, 28, 568639, new DateTime(2021, 4, 26, 13, 6, 41, 647, DateTimeKind.Local).AddTicks(9328), "voluptas" },
                    { 425, 35, 7, 148243, new DateTime(2020, 10, 7, 11, 29, 25, 467, DateTimeKind.Local).AddTicks(9436), "Dicta sed quo fuga quia sequi omnis sed aliquid et. Ad inventore sit incidunt ab nisi et excepturi nam. Sint quo dolorem fugiat. Delectus magni consectetur." },
                    { 12, 47, 138, 94203, new DateTime(2021, 7, 19, 13, 47, 56, 388, DateTimeKind.Local).AddTicks(8849), "Magnam nobis dolorem dignissimos qui ducimus in molestiae." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 149, 93, 36, 65985, new DateTime(2020, 10, 25, 10, 59, 46, 374, DateTimeKind.Local).AddTicks(2010), "Et non laudantium eaque saepe est quo aut." },
                    { 209, 93, 2, 243318, new DateTime(2021, 3, 8, 7, 20, 21, 310, DateTimeKind.Local).AddTicks(1917), "Sed nam ut id." },
                    { 296, 93, 26, 919107, new DateTime(2020, 8, 22, 13, 16, 39, 160, DateTimeKind.Local).AddTicks(7047), "quis" },
                    { 518, 93, 102, 944702, new DateTime(2021, 2, 15, 3, 54, 52, 721, DateTimeKind.Local).AddTicks(4113), "qui" },
                    { 540, 93, 45, 709398, new DateTime(2020, 8, 31, 13, 55, 19, 80, DateTimeKind.Local).AddTicks(8828), "Ut expedita ut consequuntur incidunt vero non.\nMollitia quod sunt et.\nAperiam est possimus occaecati.\nEt sit molestias dolorem sit aut." },
                    { 165, 101, 70, 756363, new DateTime(2020, 12, 13, 21, 14, 45, 754, DateTimeKind.Local).AddTicks(8208), "quia" },
                    { 22, 93, 137, 350459, new DateTime(2021, 1, 14, 3, 20, 47, 1, DateTimeKind.Local).AddTicks(4008), "Porro tenetur et voluptatibus.\nEsse iure voluptatem aut consequatur iure.\nSit corporis dolor consequatur rem.\nQuia eaque non.\nMollitia eveniet repudiandae consequatur magni temporibus molestias rerum." },
                    { 226, 101, 90, 162902, new DateTime(2021, 6, 14, 9, 0, 16, 905, DateTimeKind.Local).AddTicks(1429), "Id eius quia est modi et rerum nesciunt harum non." },
                    { 20, 82, 105, 1572, new DateTime(2021, 1, 4, 7, 4, 21, 48, DateTimeKind.Local).AddTicks(784), "Aut harum eveniet a beatae quaerat quia dolor." },
                    { 58, 17, 140, 706429, new DateTime(2021, 6, 11, 21, 16, 43, 639, DateTimeKind.Local).AddTicks(814), "Ea repellendus voluptatem ut.\nFacilis et nihil aliquam enim assumenda ea." },
                    { 140, 17, 1, 542940, new DateTime(2021, 7, 11, 0, 44, 4, 317, DateTimeKind.Local).AddTicks(9742), "Distinctio dolores nisi ab consequatur ut expedita nam libero modi." },
                    { 154, 17, 8, 110551, new DateTime(2020, 9, 14, 7, 51, 50, 828, DateTimeKind.Local).AddTicks(1751), "Odit quis qui iste deleniti." },
                    { 249, 17, 33, 475067, new DateTime(2021, 1, 20, 22, 11, 49, 895, DateTimeKind.Local).AddTicks(3831), "optio" },
                    { 255, 17, 50, 801520, new DateTime(2021, 3, 14, 4, 36, 18, 420, DateTimeKind.Local).AddTicks(4063), "Laboriosam tenetur dolor ipsum qui eos excepturi consequatur voluptas. Nesciunt ipsum laborum. Est et aperiam. Et sit qui voluptatem dicta voluptate doloribus eum." },
                    { 381, 101, 82, 217873, new DateTime(2021, 6, 7, 14, 33, 41, 970, DateTimeKind.Local).AddTicks(6928), "Non voluptate quia.\nFuga nam sit commodi autem voluptatum eligendi similique sit rerum.\nIn omnis asperiores suscipit.\nEnim aliquid aliquid inventore qui temporibus beatae magnam omnis.\nRepellendus quam libero natus qui harum necessitatibus." },
                    { 374, 17, 42, 433222, new DateTime(2021, 8, 7, 8, 38, 41, 353, DateTimeKind.Local).AddTicks(8085), "Laborum qui qui dolores et vero minus ratione est natus." },
                    { 361, 82, 33, 47241, new DateTime(2021, 7, 9, 11, 28, 45, 957, DateTimeKind.Local).AddTicks(8697), "Aut earum autem fuga maxime numquam voluptatem laboriosam aperiam.\nLibero quia reiciendis officia quidem facere et doloremque." },
                    { 457, 54, 33, 205409, new DateTime(2020, 9, 12, 2, 39, 31, 872, DateTimeKind.Local).AddTicks(6496), "Labore repudiandae doloribus ex accusantium nemo." },
                    { 145, 90, 98, 6844, new DateTime(2021, 2, 18, 7, 42, 51, 869, DateTimeKind.Local).AddTicks(6354), "dolorem" },
                    { 159, 19, 145, 909189, new DateTime(2020, 8, 18, 19, 13, 5, 36, DateTimeKind.Local).AddTicks(6232), "atque" },
                    { 326, 90, 49, 267117, new DateTime(2020, 8, 18, 5, 25, 57, 865, DateTimeKind.Local).AddTicks(2494), "ullam" },
                    { 389, 90, 14, 37510, new DateTime(2020, 11, 4, 7, 32, 29, 274, DateTimeKind.Local).AddTicks(3404), "Ut nemo tenetur dolores voluptas omnis nesciunt." },
                    { 423, 90, 114, 967195, new DateTime(2021, 5, 10, 8, 45, 55, 959, DateTimeKind.Local).AddTicks(4072), "Officia ullam repellendus quod et sequi debitis maiores deserunt ex.\nCumque aut consequatur minus quia in quis maxime est.\nAlias voluptas est qui.\nMolestias nisi nostrum." },
                    { 438, 90, 66, 490059, new DateTime(2020, 9, 1, 2, 4, 50, 351, DateTimeKind.Local).AddTicks(8740), "Quam veritatis voluptatem. Aperiam fugit dolores amet earum dignissimos eius. Est omnis cupiditate iure ut. Porro non voluptatem. Quam dolores suscipit magnam dignissimos." },
                    { 530, 54, 50, 409211, new DateTime(2021, 5, 23, 0, 57, 0, 12, DateTimeKind.Local).AddTicks(2515), "Et quidem alias eveniet voluptas rerum fugit in." },
                    { 107, 100, 118, 130555, new DateTime(2021, 5, 22, 18, 49, 22, 432, DateTimeKind.Local).AddTicks(1751), "Eos hic esse quisquam sequi voluptatem. Et hic laudantium consequatur non ea ex vel fugit consequatur. Pariatur voluptatibus doloremque placeat quia soluta qui harum. Laboriosam ipsa fugiat. Dolorum modi id quis et praesentium delectus consequuntur iure." },
                    { 87, 54, 54, 402961, new DateTime(2020, 10, 11, 21, 17, 27, 671, DateTimeKind.Local).AddTicks(1710), "Nisi molestias magni eveniet quaerat voluptas voluptatem. Qui magnam et maiores nulla perspiciatis dolorem. Facilis rerum cumque quis praesentium beatae ullam sed et hic. Eos explicabo veniam illum ducimus tenetur rerum illo. Molestiae ut sint provident non omnis." },
                    { 98, 54, 139, 203105, new DateTime(2020, 10, 23, 18, 0, 47, 667, DateTimeKind.Local).AddTicks(9849), "vitae" },
                    { 124, 54, 63, 170741, new DateTime(2020, 10, 18, 6, 40, 54, 549, DateTimeKind.Local).AddTicks(8677), "maxime" },
                    { 279, 54, 73, 56881, new DateTime(2021, 4, 4, 13, 0, 30, 248, DateTimeKind.Local).AddTicks(9002), "Enim voluptatibus illum voluptas quae beatae rerum a pariatur laudantium." },
                    { 332, 54, 5, 782130, new DateTime(2021, 4, 12, 11, 22, 24, 894, DateTimeKind.Local).AddTicks(619), "facilis" },
                    { 379, 54, 85, 765828, new DateTime(2021, 5, 15, 1, 3, 50, 114, DateTimeKind.Local).AddTicks(4066), "Sed quo dolorem consequatur consequatur molestias illo tempora quas sed." },
                    { 526, 90, 40, 983829, new DateTime(2021, 4, 10, 10, 47, 56, 602, DateTimeKind.Local).AddTicks(2791), "Quidem quis adipisci.\nDucimus perspiciatis repudiandae consectetur aut tempore.\nDolorum necessitatibus nesciunt quo.\nEius doloribus adipisci voluptas.\nLibero aliquam porro id corrupti fugit cumque est in ut." },
                    { 285, 100, 52, 503209, new DateTime(2021, 3, 28, 2, 35, 23, 238, DateTimeKind.Local).AddTicks(7557), "Doloribus rerum sit dolorum ut impedit quo harum." },
                    { 469, 17, 62, 637592, new DateTime(2021, 7, 17, 7, 19, 52, 296, DateTimeKind.Local).AddTicks(8066), "Eligendi voluptatum saepe sapiente quisquam dolorem sapiente. Enim ad odio id dolorum unde voluptas quidem dolores qui. Alias vitae repudiandae possimus qui. Qui quia accusantium quia." },
                    { 483, 17, 45, 135175, new DateTime(2020, 11, 28, 17, 48, 23, 755, DateTimeKind.Local).AddTicks(9437), "Maiores molestiae reprehenderit quis nostrum deleniti. Quis maiores officiis nam est fugit dolor quia voluptatem consectetur. Numquam dolores quos voluptas occaecati. Aut fuga qui. Sit aspernatur quis perspiciatis." },
                    { 196, 72, 80, 139494, new DateTime(2020, 8, 20, 2, 51, 53, 864, DateTimeKind.Local).AddTicks(5547), "Molestias commodi minus ipsum qui harum.\nQuia temporibus rem qui sit vitae minus in.\nConsectetur sit dolorem odio amet voluptas veritatis commodi.\nNatus et perferendis vel." },
                    { 274, 72, 2, 892367, new DateTime(2021, 3, 3, 20, 1, 40, 416, DateTimeKind.Local).AddTicks(5892), "Maxime officia qui aperiam enim consequuntur." },
                    { 366, 72, 40, 904026, new DateTime(2021, 1, 16, 17, 53, 29, 360, DateTimeKind.Local).AddTicks(1257), "Soluta deserunt eos laborum a omnis." },
                    { 446, 72, 53, 477365, new DateTime(2020, 10, 5, 15, 4, 39, 902, DateTimeKind.Local).AddTicks(8679), "Aut quae sed.\nProvident reiciendis aut et quae voluptatem eum.\nOdit excepturi laborum perspiciatis omnis laudantium molestias.\nEt deleniti possimus recusandae.\nAut odit aliquid quaerat sed.\nLaboriosam velit officia." },
                    { 513, 72, 125, 955546, new DateTime(2021, 2, 4, 17, 0, 24, 931, DateTimeKind.Local).AddTicks(8949), "quis" },
                    { 135, 99, 32, 365951, new DateTime(2020, 10, 31, 21, 42, 16, 655, DateTimeKind.Local).AddTicks(116), "Rerum incidunt temporibus distinctio ut. Et praesentium voluptatibus nihil voluptatum dolorem et est placeat facere. Voluptatem ipsam aut ut." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 61, 72, 6, 105266, new DateTime(2021, 4, 16, 22, 41, 50, 220, DateTimeKind.Local).AddTicks(6505), "aliquam" },
                    { 180, 99, 11, 198088, new DateTime(2021, 2, 28, 10, 6, 47, 66, DateTimeKind.Local).AddTicks(9309), "Ipsum sed nam deserunt nihil ut neque nemo et. Quisquam ad omnis beatae cupiditate fugit. Est voluptatum tempore recusandae. Consequatur rerum velit ipsum et voluptatem qui ea vitae earum." },
                    { 18, 73, 104, 294451, new DateTime(2021, 5, 25, 17, 31, 6, 731, DateTimeKind.Local).AddTicks(7673), "Consequatur incidunt dolor sed quos quaerat maiores ut sit non.\nSed aut quisquam.\nNostrum fugiat omnis impedit voluptas aliquid quo harum quos.\nSint et dicta ad aut ut.\nLaboriosam amet porro asperiores mollitia adipisci impedit corrupti et cupiditate." },
                    { 155, 49, 115, 97242, new DateTime(2021, 1, 29, 20, 38, 39, 386, DateTimeKind.Local).AddTicks(9851), "Sed quaerat temporibus et id dolores." },
                    { 253, 49, 116, 830576, new DateTime(2020, 10, 21, 17, 28, 0, 186, DateTimeKind.Local).AddTicks(8264), "Placeat assumenda sint accusamus dolorem qui ea sed." },
                    { 351, 49, 114, 593090, new DateTime(2021, 6, 29, 20, 30, 52, 537, DateTimeKind.Local).AddTicks(2467), "Est ratione qui impedit." },
                    { 422, 49, 9, 882184, new DateTime(2021, 1, 18, 5, 19, 20, 288, DateTimeKind.Local).AddTicks(8918), "Quo tempore rerum aspernatur quaerat repellendus inventore." },
                    { 567, 49, 50, 641879, new DateTime(2021, 3, 29, 2, 58, 3, 616, DateTimeKind.Local).AddTicks(8862), "sunt" },
                    { 241, 99, 118, 515344, new DateTime(2020, 11, 7, 0, 17, 39, 709, DateTimeKind.Local).AddTicks(262), "At temporibus praesentium et explicabo blanditiis quae." },
                    { 482, 17, 65, 839397, new DateTime(2020, 11, 22, 5, 22, 35, 72, DateTimeKind.Local).AddTicks(7130), "Provident tenetur adipisci alias qui. Non rerum facere rem necessitatibus vero voluptatem. Odio praesentium harum ratione quisquam accusantium architecto sit. Cumque molestias illo illo aut nulla magni voluptas." },
                    { 51, 73, 124, 273742, new DateTime(2021, 4, 26, 9, 52, 34, 830, DateTimeKind.Local).AddTicks(6631), "dolore" },
                    { 350, 61, 81, 501381, new DateTime(2021, 5, 10, 3, 26, 30, 307, DateTimeKind.Local).AddTicks(7183), "eius" },
                    { 504, 17, 83, 120049, new DateTime(2021, 5, 18, 14, 2, 38, 697, DateTimeKind.Local).AddTicks(8642), "Beatae harum est et aut et sed pariatur id. Dolores illo nobis omnis. Debitis occaecati ut veritatis voluptatem neque. Adipisci magni et vel reiciendis et a adipisci." },
                    { 550, 17, 19, 142609, new DateTime(2021, 6, 3, 10, 3, 35, 99, DateTimeKind.Local).AddTicks(4171), "odit" },
                    { 143, 28, 102, 964473, new DateTime(2020, 10, 7, 8, 25, 27, 27, DateTimeKind.Local).AddTicks(6535), "Iste ducimus minima laboriosam alias.\nQui ex qui fugiat tempore perferendis omnis quisquam harum deleniti.\nEum dolorem dolor ipsum omnis beatae consectetur repudiandae recusandae.\nOmnis velit sed nemo omnis qui.\nOmnis explicabo doloremque harum ut architecto illo fugiat ut." },
                    { 380, 28, 81, 496517, new DateTime(2021, 2, 21, 20, 11, 46, 508, DateTimeKind.Local).AddTicks(4680), "Quibusdam fuga eveniet dolorem exercitationem tempora libero. Fugiat asperiores qui ratione aut magni illo omnis. Ut minus ad qui quia recusandae voluptas rerum aliquid eaque. Amet voluptas expedita. Debitis fuga dolor asperiores vel sed qui." },
                    { 543, 28, 11, 161589, new DateTime(2021, 8, 15, 3, 44, 14, 724, DateTimeKind.Local).AddTicks(4311), "Blanditiis ullam laborum dolor ut." },
                    { 585, 28, 38, 483032, new DateTime(2020, 11, 22, 3, 9, 10, 920, DateTimeKind.Local).AddTicks(25), "voluptatibus" },
                    { 427, 61, 85, 293472, new DateTime(2021, 1, 11, 7, 47, 1, 537, DateTimeKind.Local).AddTicks(6704), "Harum perferendis quos totam. Incidunt ut consectetur voluptates quae et. Eum molestias cumque vel minima." },
                    { 99, 73, 83, 204045, new DateTime(2020, 10, 15, 7, 43, 48, 582, DateTimeKind.Local).AddTicks(3497), "Modi corporis voluptatem sunt nobis." },
                    { 97, 55, 54, 977836, new DateTime(2020, 11, 13, 10, 11, 57, 449, DateTimeKind.Local).AddTicks(5129), "Facilis corrupti quo voluptatem temporibus. Iure consequatur deserunt aut tempore vitae quod debitis rerum quam. Dolorum et ipsa voluptatum odio assumenda veniam. Aut omnis dolore quod vel minus illum. Commodi exercitationem et nostrum." },
                    { 186, 55, 117, 473635, new DateTime(2021, 1, 9, 12, 37, 38, 181, DateTimeKind.Local).AddTicks(7381), "necessitatibus" },
                    { 316, 55, 14, 581557, new DateTime(2021, 3, 4, 22, 52, 21, 217, DateTimeKind.Local).AddTicks(3605), "repudiandae" },
                    { 138, 61, 46, 674802, new DateTime(2021, 7, 13, 14, 18, 38, 64, DateTimeKind.Local).AddTicks(1828), "Qui qui qui iusto ut in quo et.\nSed consequatur consequuntur facilis aut voluptatem cum.\nFuga sit voluptate doloremque repellendus sint et.\nVelit ut rem sapiente at accusamus suscipit et ut natus." },
                    { 193, 61, 80, 652943, new DateTime(2020, 10, 3, 20, 7, 3, 208, DateTimeKind.Local).AddTicks(541), "Expedita nostrum magnam aut minima." },
                    { 349, 61, 3, 874058, new DateTime(2020, 11, 7, 12, 51, 59, 98, DateTimeKind.Local).AddTicks(6703), "Ducimus quaerat quia.\nReprehenderit nesciunt aut inventore nam minus repellat molestiae quibusdam rerum." },
                    { 89, 55, 66, 448767, new DateTime(2021, 3, 23, 17, 13, 32, 152, DateTimeKind.Local).AddTicks(2569), "Aut expedita enim ab." },
                    { 592, 68, 15, 824137, new DateTime(2020, 11, 7, 15, 43, 24, 589, DateTimeKind.Local).AddTicks(3835), "Optio qui sapiente numquam." },
                    { 130, 100, 57, 672018, new DateTime(2020, 10, 10, 21, 36, 59, 143, DateTimeKind.Local).AddTicks(5717), "Facilis quod suscipit vel tenetur officiis repudiandae recusandae asperiores." },
                    { 292, 68, 94, 537836, new DateTime(2020, 11, 4, 15, 34, 14, 250, DateTimeKind.Local).AddTicks(6942), "Maxime vero aut quam qui officiis. Et placeat omnis qui dolores quas dolorem quis non. Distinctio exercitationem nostrum est at sit ratione beatae. Et officiis sed quis." },
                    { 525, 60, 26, 233380, new DateTime(2021, 3, 29, 10, 32, 7, 975, DateTimeKind.Local).AddTicks(8837), "Et fugiat est ratione eaque sint assumenda quibusdam consequatur." },
                    { 171, 38, 141, 142645, new DateTime(2021, 5, 11, 18, 52, 48, 233, DateTimeKind.Local).AddTicks(9899), "Quisquam et odit ea in eos perspiciatis rem voluptas quia." },
                    { 56, 88, 1, 637138, new DateTime(2020, 12, 30, 20, 45, 0, 672, DateTimeKind.Local).AddTicks(5472), "Qui in dolorem non distinctio mollitia quo quisquam inventore cupiditate. Ut et sint nostrum. Velit alias expedita labore." },
                    { 163, 88, 52, 378059, new DateTime(2021, 2, 5, 5, 47, 1, 575, DateTimeKind.Local).AddTicks(3458), "Harum repellendus rerum et dolorum sed ab voluptatum. Eum ratione sed assumenda voluptatem quis iusto dolorem. Esse occaecati voluptate rerum ducimus tempore aut. Quia nisi quo." },
                    { 412, 88, 114, 392531, new DateTime(2021, 8, 6, 10, 33, 18, 897, DateTimeKind.Local).AddTicks(2072), "Fugiat quos enim voluptas hic quia in facilis et.\nAccusantium optio esse dolore.\nAnimi amet nulla neque et." },
                    { 439, 88, 41, 27357, new DateTime(2021, 6, 30, 19, 58, 48, 384, DateTimeKind.Local).AddTicks(2852), "Facilis dolores sint. Cupiditate exercitationem assumenda soluta sunt similique nisi repellat. Veniam possimus maxime consectetur. Et exercitationem ipsa inventore rerum consequuntur. Dolor libero sed optio inventore. Veniam laudantium placeat." },
                    { 520, 60, 27, 430164, new DateTime(2020, 12, 19, 5, 35, 11, 95, DateTimeKind.Local).AddTicks(7887), "In ea officia cupiditate fugiat et itaque at aspernatur alias." },
                    { 456, 88, 125, 973235, new DateTime(2021, 4, 14, 14, 14, 29, 184, DateTimeKind.Local).AddTicks(8803), "Ratione distinctio aliquid dolorem quo." },
                    { 85, 38, 141, 608355, new DateTime(2020, 8, 21, 1, 53, 44, 539, DateTimeKind.Local).AddTicks(5182), "Dignissimos aperiam id quo iste inventore." },
                    { 82, 34, 13, 220542, new DateTime(2021, 5, 6, 16, 7, 53, 286, DateTimeKind.Local).AddTicks(6451), "Aliquam nihil aut sint est itaque sit non itaque.\nNam rem ut temporibus possimus natus sit harum excepturi incidunt.\nAut corrupti consequatur maiores." },
                    { 91, 34, 49, 968005, new DateTime(2021, 4, 26, 4, 59, 49, 520, DateTimeKind.Local).AddTicks(765), "Neque nobis incidunt saepe.\nRerum error impedit sed officiis rem est.\nEt eum temporibus consectetur quam.\nSed atque consequatur voluptas." },
                    { 173, 34, 135, 599688, new DateTime(2021, 6, 4, 14, 9, 27, 356, DateTimeKind.Local).AddTicks(2879), "Ut ipsam quam possimus porro aut mollitia placeat dolor dolorem." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 216, 34, 55, 149210, new DateTime(2020, 11, 6, 16, 35, 54, 589, DateTimeKind.Local).AddTicks(1474), "Omnis provident eum nemo mollitia facere sed eum et. Dolor ut sed dignissimos. Ut quibusdam nihil vel rerum sint voluptatum iure voluptas. Sint voluptatem non labore sunt aperiam asperiores." },
                    { 443, 68, 47, 785510, new DateTime(2021, 3, 11, 9, 10, 1, 728, DateTimeKind.Local).AddTicks(9626), "Vitae animi recusandae quisquam eos deleniti placeat aut molestiae." },
                    { 484, 88, 71, 209122, new DateTime(2021, 7, 2, 19, 40, 51, 429, DateTimeKind.Local).AddTicks(4320), "Quaerat quo dolores quasi dolor ducimus quia sit unde natus.\nAut beatae soluta dolore consequatur eius et.\nUt libero laboriosam eum ex.\nQui quia consequatur reiciendis dolorum aut est atque praesentium a.\nEa optio laboriosam et voluptatibus id mollitia mollitia dolores." },
                    { 474, 60, 147, 775199, new DateTime(2021, 4, 3, 14, 44, 2, 194, DateTimeKind.Local).AddTicks(402), "Cum quia aliquid delectus atque quis amet est dicta.\nVoluptas nihil voluptas voluptas dignissimos rerum iusto corrupti aliquam.\nHic et laboriosam repudiandae animi a voluptates.\nNisi qui consequatur aut." },
                    { 231, 60, 83, 374244, new DateTime(2021, 7, 16, 18, 6, 7, 603, DateTimeKind.Local).AddTicks(9391), "Sed sint occaecati.\nOdit error aliquid voluptatem animi molestiae vitae.\nId exercitationem distinctio ipsum eos ipsum labore.\nQuia eum fugit et sed in.\nMagnam ipsum sed dolorem consequatur." },
                    { 132, 60, 111, 759286, new DateTime(2021, 8, 6, 4, 36, 2, 661, DateTimeKind.Local).AddTicks(2995), "Quasi repellendus iste." },
                    { 528, 38, 28, 38623, new DateTime(2021, 1, 29, 12, 48, 58, 700, DateTimeKind.Local).AddTicks(3866), "Consequatur optio ratione et quia." },
                    { 560, 47, 79, 506371, new DateTime(2020, 11, 29, 20, 4, 0, 212, DateTimeKind.Local).AddTicks(5004), "Alias consequatur impedit sapiente non aut laborum fuga dolor." },
                    { 3, 45, 106, 364289, new DateTime(2021, 2, 19, 14, 44, 10, 159, DateTimeKind.Local).AddTicks(1443), "Sit laboriosam veniam omnis ad voluptatem molestiae. Voluptate voluptas facilis laborum voluptatem voluptas sed. Minus ea totam et aut est ea totam. Sed vero voluptas eaque ipsa aut deleniti. Ratione ad doloribus sed sapiente vero beatae et repudiandae rerum. Rerum quia error illum voluptatibus reiciendis corrupti." },
                    { 323, 45, 55, 727513, new DateTime(2021, 6, 23, 19, 11, 10, 791, DateTimeKind.Local).AddTicks(6806), "Repellat est ad accusantium deserunt." },
                    { 385, 45, 42, 851260, new DateTime(2021, 8, 14, 8, 17, 58, 939, DateTimeKind.Local).AddTicks(1620), "dolorem" },
                    { 453, 45, 86, 846042, new DateTime(2020, 8, 29, 13, 8, 36, 144, DateTimeKind.Local).AddTicks(9376), "doloremque" },
                    { 485, 45, 34, 336138, new DateTime(2021, 3, 29, 19, 3, 21, 304, DateTimeKind.Local).AddTicks(4469), "earum" },
                    { 197, 38, 54, 57719, new DateTime(2020, 11, 27, 23, 20, 24, 223, DateTimeKind.Local).AddTicks(2882), "Tenetur magni est totam et autem laboriosam libero. Facere quia voluptatem beatae quasi mollitia. Ut aut dolore maxime corporis consequatur sit fugiat magni. Quod autem sit sit et incidunt odio et." },
                    { 33, 26, 122, 501722, new DateTime(2021, 3, 9, 14, 51, 58, 641, DateTimeKind.Local).AddTicks(7270), "Sed culpa exercitationem dolores voluptates eum tempore animi." },
                    { 105, 26, 19, 243972, new DateTime(2020, 9, 10, 12, 34, 20, 838, DateTimeKind.Local).AddTicks(5441), "illo" },
                    { 115, 26, 104, 699821, new DateTime(2021, 3, 27, 22, 21, 23, 543, DateTimeKind.Local).AddTicks(6405), "in" },
                    { 229, 26, 69, 129053, new DateTime(2021, 8, 14, 22, 32, 40, 3, DateTimeKind.Local).AddTicks(6474), "Delectus distinctio in quia." },
                    { 452, 26, 125, 739933, new DateTime(2021, 4, 4, 16, 20, 25, 347, DateTimeKind.Local).AddTicks(4073), "voluptatibus" },
                    { 583, 26, 94, 902937, new DateTime(2021, 7, 27, 6, 54, 0, 489, DateTimeKind.Local).AddTicks(7865), "Veritatis ducimus neque quidem in dolor harum temporibus et. Quae error similique. Numquam ipsum officiis voluptatem aut fuga maiores fugit saepe voluptatem. In fugit rerum et consequatur illo. Deleniti qui amet minus saepe dolorum esse facere veritatis odit." },
                    { 597, 26, 17, 673929, new DateTime(2020, 12, 27, 6, 4, 55, 398, DateTimeKind.Local).AddTicks(9334), "perferendis" },
                    { 101, 50, 95, 856045, new DateTime(2021, 2, 15, 15, 24, 0, 92, DateTimeKind.Local).AddTicks(2351), "Ut qui ut voluptates natus explicabo occaecati quas.\nRepellat animi nulla assumenda rem id eligendi itaque tempora.\nEnim corrupti magni." },
                    { 282, 50, 106, 740536, new DateTime(2021, 6, 11, 15, 42, 33, 408, DateTimeKind.Local).AddTicks(6185), "possimus" },
                    { 301, 34, 106, 628679, new DateTime(2021, 8, 3, 12, 16, 39, 227, DateTimeKind.Local).AddTicks(1547), "quasi" },
                    { 75, 38, 105, 447942, new DateTime(2021, 3, 30, 15, 39, 56, 397, DateTimeKind.Local).AddTicks(2974), "Voluptatem dicta fuga eum cumque vel facere possimus." },
                    { 486, 50, 63, 9390, new DateTime(2021, 6, 28, 0, 23, 36, 549, DateTimeKind.Local).AddTicks(3004), "Sit mollitia voluptas fugit ipsa molestiae cum fugiat corrupti. Est laudantium facilis cupiditate similique facilis quis. Quod ut vero. Autem quaerat provident nulla soluta dolores aliquid quae ut. Ut culpa sint. Quia et error tempore sint distinctio quidem officia." },
                    { 496, 94, 37, 688320, new DateTime(2021, 1, 2, 18, 25, 25, 501, DateTimeKind.Local).AddTicks(8505), "Voluptas enim eos vero odit aut et.\nVoluptate accusamus earum.\nQuaerat ipsam suscipit deserunt quos facere.\nFuga beatae ut repellat animi hic sint mollitia ullam.\nConsectetur et architecto voluptas odit temporibus veniam sed quidem pariatur.\nQuia quaerat et facilis aut corrupti placeat sunt eos animi." },
                    { 549, 94, 5, 593983, new DateTime(2020, 12, 20, 23, 59, 38, 996, DateTimeKind.Local).AddTicks(7250), "Quibusdam sed doloremque quo." },
                    { 537, 100, 69, 534512, new DateTime(2021, 1, 12, 6, 57, 23, 405, DateTimeKind.Local).AddTicks(3955), "Voluptatem aut blanditiis.\nMagni molestias eos illo laborum eum ad.\nDeleniti consectetur maiores iste ex reiciendis cumque.\nNatus aut non.\nUt dolorem blanditiis adipisci et minima non quod quia aut." },
                    { 430, 100, 28, 445749, new DateTime(2020, 11, 13, 3, 22, 17, 267, DateTimeKind.Local).AddTicks(7232), "Est sunt est nemo sed quia quae. Modi iure recusandae. Aperiam consectetur quam quis. Perspiciatis fuga blanditiis aut ex ab. Necessitatibus sequi fuga quis non ducimus." },
                    { 445, 9, 141, 459767, new DateTime(2020, 8, 24, 10, 56, 5, 990, DateTimeKind.Local).AddTicks(1131), "Ducimus suscipit porro fuga quae rerum et. Placeat cupiditate dolore vero blanditiis delectus mollitia reprehenderit. Suscipit aut voluptatibus voluptas nisi." },
                    { 288, 94, 39, 614071, new DateTime(2020, 8, 28, 8, 15, 57, 845, DateTimeKind.Local).AddTicks(9073), "Aliquid quasi fugit aspernatur et. Rerum at esse impedit praesentium quam et. Ut quia blanditiis ut non est tempora laboriosam. Eius consequuntur sit eligendi atque. Officiis laborum nam fugit aliquid corrupti. Ad ea ea facere quis autem asperiores." },
                    { 538, 9, 133, 305138, new DateTime(2020, 11, 14, 22, 19, 6, 951, DateTimeKind.Local).AddTicks(2879), "Et sit et mollitia." },
                    { 590, 9, 66, 244185, new DateTime(2020, 8, 31, 15, 36, 43, 233, DateTimeKind.Local).AddTicks(9048), "Blanditiis est consequuntur ipsa in consequatur et explicabo maxime." },
                    { 303, 100, 45, 747978, new DateTime(2021, 5, 10, 21, 37, 12, 608, DateTimeKind.Local).AddTicks(8812), "Autem sit aperiam et vitae autem tenetur. Cupiditate nulla quisquam deleniti eos voluptatem maxime fugit quia velit. Eligendi asperiores facere blanditiis." },
                    { 1, 68, 50, 227503, new DateTime(2021, 3, 10, 22, 22, 5, 470, DateTimeKind.Local).AddTicks(4090), "Sequi eos tempore voluptatem sed et.\nMaxime a quo qui.\nMolestiae eligendi est voluptas sit et.\nUt corporis omnis." },
                    { 15, 68, 23, 30239, new DateTime(2021, 5, 19, 23, 10, 46, 207, DateTimeKind.Local).AddTicks(502), "Ratione eos id voluptas eum.\nUnde numquam saepe." },
                    { 70, 68, 85, 643446, new DateTime(2020, 10, 24, 17, 22, 37, 74, DateTimeKind.Local).AddTicks(993), "Consequuntur harum quia." },
                    { 280, 68, 25, 210646, new DateTime(2020, 12, 30, 23, 36, 10, 389, DateTimeKind.Local).AddTicks(2698), "Omnis commodi iusto temporibus unde vero occaecati consequatur." },
                    { 562, 9, 26, 260529, new DateTime(2020, 9, 14, 4, 7, 3, 5, DateTimeKind.Local).AddTicks(27), "Laboriosam voluptatibus sequi cumque voluptates quisquam et.\nIncidunt incidunt temporibus rerum neque." },
                    { 164, 94, 99, 410775, new DateTime(2020, 10, 24, 0, 57, 33, 609, DateTimeKind.Local).AddTicks(3669), "Odit et nisi doloribus. Eum odio harum voluptatem sit et doloribus eos aperiam est. Ea assumenda ut maxime laboriosam non. Sed asperiores impedit omnis non consequatur minima omnis. Soluta modi voluptas et enim nihil occaecati culpa ducimus." },
                    { 406, 94, 96, 420948, new DateTime(2021, 1, 1, 9, 21, 33, 558, DateTimeKind.Local).AddTicks(223), "Odit adipisci illo veritatis suscipit aspernatur eveniet et sequi qui.\nSuscipit repudiandae atque et expedita eaque eos suscipit cumque sint." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 240, 65, 38, 329367, new DateTime(2021, 5, 8, 4, 58, 30, 413, DateTimeKind.Local).AddTicks(763), "Aut voluptas libero illo. Repellendus sit in soluta. Autem praesentium officia libero non molestiae accusamus. Iste est porro voluptas nam. Ut eos eveniet porro. In voluptas voluptatem." },
                    { 94, 89, 150, 758423, new DateTime(2021, 3, 27, 2, 3, 36, 20, DateTimeKind.Local).AddTicks(6314), "sint" },
                    { 507, 91, 57, 123094, new DateTime(2021, 5, 25, 4, 41, 4, 191, DateTimeKind.Local).AddTicks(960), "Odio molestiae eius fugiat consequatur cum iusto iusto.\nFacere quis sunt laudantium saepe velit et.\nNecessitatibus eos libero maxime aliquid vitae." },
                    { 239, 89, 8, 126946, new DateTime(2020, 8, 20, 4, 15, 50, 603, DateTimeKind.Local).AddTicks(2206), "est" },
                    { 336, 91, 79, 26899, new DateTime(2021, 8, 9, 19, 59, 37, 228, DateTimeKind.Local).AddTicks(6440), "Nemo est quisquam aut voluptas. Aspernatur occaecati saepe quis. Voluptatum dolores ex necessitatibus." },
                    { 6, 38, 74, 587493, new DateTime(2021, 3, 22, 20, 28, 32, 188, DateTimeKind.Local).AddTicks(7634), "Voluptatum nisi eos sed. Facilis dolore quo tempore aut reiciendis et voluptates. Quae ullam dolor cumque voluptas." },
                    { 258, 89, 40, 147472, new DateTime(2021, 7, 17, 14, 20, 49, 257, DateTimeKind.Local).AddTicks(9760), "minus" },
                    { 271, 89, 53, 468102, new DateTime(2021, 7, 17, 8, 27, 7, 270, DateTimeKind.Local).AddTicks(3052), "Consequuntur eos sed ex magni ad porro eum incidunt." },
                    { 325, 91, 64, 621213, new DateTime(2020, 8, 23, 5, 29, 18, 680, DateTimeKind.Local).AddTicks(8916), "magnam" },
                    { 480, 89, 39, 29252, new DateTime(2021, 5, 31, 13, 20, 15, 871, DateTimeKind.Local).AddTicks(3489), "Culpa debitis aut et aut distinctio. Est est id quia eius nihil reiciendis et qui. Eaque eligendi soluta quis qui magni tenetur. Et reprehenderit modi eligendi in id corporis est." },
                    { 348, 89, 20, 562223, new DateTime(2020, 10, 2, 9, 4, 42, 582, DateTimeKind.Local).AddTicks(8562), "Dolorem aut sit neque voluptatum." },
                    { 393, 89, 18, 637335, new DateTime(2021, 6, 6, 12, 46, 10, 587, DateTimeKind.Local).AddTicks(2552), "Quidem velit nam et ipsa animi aliquam repellendus eius. Quidem cumque et officia voluptates autem. Voluptates qui inventore repudiandae fugit minima illo sed." }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 55, 5, 206 },
                    { 36, 8, 5 },
                    { 101, 95, 286 },
                    { 42, 56, 38 },
                    { 12, 15, 242 },
                    { 1, 77, 44 },
                    { 72, 73, 273 },
                    { 27, 82, 157 },
                    { 79, 1, 37 },
                    { 5, 2, 21 },
                    { 77, 43, 116 },
                    { 37, 100, 284 },
                    { 38, 49, 246 },
                    { 6, 81, 214 },
                    { 61, 60, 205 },
                    { 15, 88, 146 },
                    { 4, 50, 18 },
                    { 70, 42, 5 },
                    { 43, 76, 263 },
                    { 66, 25, 94 },
                    { 71, 94, 242 },
                    { 64, 24, 230 },
                    { 24, 9, 46 },
                    { 87, 68, 224 },
                    { 39, 53, 56 },
                    { 16, 86, 154 },
                    { 51, 90, 226 },
                    { 23, 85, 91 },
                    { 21, 54, 230 },
                    { 40, 101, 37 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 80, 28, 56 },
                    { 76, 32, 161 },
                    { 14, 55, 44 },
                    { 35, 61, 205 },
                    { 29, 99, 161 },
                    { 13, 41, 122 },
                    { 34, 45, 94 },
                    { 59, 84, 35 },
                    { 31, 35, 109 },
                    { 10, 74, 2 },
                    { 11, 63, 60 },
                    { 32, 18, 154 },
                    { 63, 62, 154 },
                    { 68, 21, 189 },
                    { 99, 44, 2 },
                    { 33, 22, 83 },
                    { 25, 57, 229 },
                    { 8, 75, 54 },
                    { 48, 46, 47 },
                    { 56, 4, 236 },
                    { 81, 51, 58 },
                    { 3, 98, 259 },
                    { 82, 40, 213 },
                    { 9, 13, 214 },
                    { 73, 12, 83 },
                    { 22, 70, 289 },
                    { 47, 80, 61 },
                    { 7, 48, 83 },
                    { 17, 29, 46 },
                    { 30, 33, 157 },
                    { 19, 10, 42 },
                    { 2, 36, 214 },
                    { 18, 71, 21 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 8, new DateTime(2020, 9, 9, 3, 36, 40, 552, DateTimeKind.Local).AddTicks(288), 2, new DateTime(2022, 3, 6, 8, 56, 6, 381, DateTimeKind.Local).AddTicks(2578), new DateTime(2021, 4, 9, 14, 38, 53, 772, DateTimeKind.Local).AddTicks(3025), 2, 72, "Culpa accusamus ipsum vero harum unde enim quia ipsa.\nItaque non et neque quidem." },
                    { 48, new DateTime(2021, 2, 26, 17, 3, 46, 76, DateTimeKind.Local).AddTicks(4974), 96, new DateTime(2021, 10, 22, 5, 23, 59, 259, DateTimeKind.Local).AddTicks(7224), new DateTime(2021, 5, 16, 0, 41, 41, 556, DateTimeKind.Local).AddTicks(903), 3, 22, "corrupti" },
                    { 79, new DateTime(2020, 8, 18, 17, 49, 37, 836, DateTimeKind.Local).AddTicks(3517), 52, new DateTime(2022, 4, 29, 0, 7, 52, 477, DateTimeKind.Local).AddTicks(8639), new DateTime(2020, 8, 25, 4, 27, 20, 774, DateTimeKind.Local).AddTicks(1951), 5, 22, "Fugit autem vel maxime." },
                    { 84, new DateTime(2021, 7, 27, 5, 21, 32, 294, DateTimeKind.Local).AddTicks(9298), 47, new DateTime(2021, 9, 21, 19, 18, 0, 189, DateTimeKind.Local).AddTicks(4222), new DateTime(2020, 9, 15, 23, 56, 37, 877, DateTimeKind.Local).AddTicks(7491), 1, 22, "Aut nulla eos cum a. Doloribus vel ratione. Id suscipit perferendis blanditiis ut non. Doloribus deserunt sequi laboriosam soluta." },
                    { 85, new DateTime(2020, 10, 29, 12, 1, 8, 309, DateTimeKind.Local).AddTicks(8341), 82, new DateTime(2021, 11, 15, 7, 38, 30, 832, DateTimeKind.Local).AddTicks(734), new DateTime(2020, 10, 25, 13, 40, 29, 479, DateTimeKind.Local).AddTicks(5980), 4, 22, "voluptates" },
                    { 52, new DateTime(2020, 11, 11, 3, 14, 7, 410, DateTimeKind.Local).AddTicks(1141), 61, new DateTime(2022, 8, 8, 5, 48, 24, 143, DateTimeKind.Local).AddTicks(2568), new DateTime(2021, 7, 31, 1, 40, 23, 116, DateTimeKind.Local).AddTicks(3799), 1, 9, "In esse et.\nUt corrupti repellat officia pariatur consequatur velit placeat nam cupiditate.\nEnim illum excepturi quibusdam voluptatum et.\nNisi rerum est molestiae dolor." },
                    { 62, new DateTime(2021, 7, 2, 15, 47, 57, 442, DateTimeKind.Local).AddTicks(7088), 131, new DateTime(2021, 9, 1, 3, 22, 1, 999, DateTimeKind.Local).AddTicks(1875), new DateTime(2021, 7, 16, 3, 16, 3, 646, DateTimeKind.Local).AddTicks(6336), 5, 9, "Expedita sit optio.\nAspernatur sint voluptas dolores pariatur ut quis qui est.\nVoluptas adipisci eius eligendi omnis.\nQuae odit eum." },
                    { 139, new DateTime(2021, 1, 24, 18, 55, 45, 871, DateTimeKind.Local).AddTicks(6437), 47, new DateTime(2022, 2, 10, 5, 6, 9, 535, DateTimeKind.Local).AddTicks(7396), new DateTime(2020, 9, 18, 11, 40, 32, 846, DateTimeKind.Local).AddTicks(5452), 3, 9, "omnis" },
                    { 160, new DateTime(2020, 12, 27, 19, 47, 52, 792, DateTimeKind.Local).AddTicks(212), 95, new DateTime(2022, 2, 22, 9, 51, 8, 344, DateTimeKind.Local).AddTicks(7331), new DateTime(2021, 5, 21, 4, 5, 30, 950, DateTimeKind.Local).AddTicks(212), 5, 9, "Accusamus nisi consequatur voluptas dolores." },
                    { 185, new DateTime(2021, 6, 30, 22, 52, 19, 338, DateTimeKind.Local).AddTicks(8565), 53, new DateTime(2022, 3, 29, 6, 3, 54, 668, DateTimeKind.Local).AddTicks(585), new DateTime(2021, 3, 10, 11, 48, 47, 948, DateTimeKind.Local).AddTicks(2212), 3, 9, "eligendi" },
                    { 195, new DateTime(2020, 10, 17, 14, 29, 38, 304, DateTimeKind.Local).AddTicks(2396), 97, new DateTime(2021, 9, 25, 6, 13, 45, 267, DateTimeKind.Local).AddTicks(8245), new DateTime(2021, 1, 24, 7, 12, 25, 655, DateTimeKind.Local).AddTicks(4088), 1, 9, "Dolor veniam dolores suscipit eos.\nNam sed ex expedita." },
                    { 179, new DateTime(2020, 11, 8, 7, 48, 51, 28, DateTimeKind.Local).AddTicks(3580), 38, new DateTime(2022, 4, 22, 9, 5, 41, 167, DateTimeKind.Local).AddTicks(3095), new DateTime(2021, 8, 7, 8, 9, 49, 602, DateTimeKind.Local).AddTicks(9470), 5, 82, "Officiis laborum quibusdam ut beatae enim. Expedita et quis rerum nesciunt mollitia officia fugiat sit iusto. Sint aut ea. Quos quibusdam vitae enim commodi. Qui quas consequuntur at maxime aliquam ut ipsa laudantium neque. Impedit commodi quas id et aperiam et ut consequatur." },
                    { 187, new DateTime(2021, 7, 29, 7, 22, 37, 444, DateTimeKind.Local).AddTicks(1919), 1, new DateTime(2021, 11, 10, 3, 46, 25, 990, DateTimeKind.Local).AddTicks(5885), new DateTime(2021, 4, 14, 16, 47, 20, 467, DateTimeKind.Local).AddTicks(5079), 4, 82, "ducimus" },
                    { 189, new DateTime(2021, 1, 24, 5, 21, 37, 7, DateTimeKind.Local).AddTicks(9934), 146, new DateTime(2022, 3, 3, 1, 52, 38, 654, DateTimeKind.Local).AddTicks(7170), new DateTime(2020, 11, 25, 19, 40, 40, 110, DateTimeKind.Local).AddTicks(611), 4, 82, "Aut soluta in sint quibusdam molestiae officiis neque.\nVoluptatum minima et id.\nVoluptatem porro et omnis mollitia dolore molestiae iusto quo.\nIllum tenetur dignissimos in qui distinctio aut ex.\nQuibusdam cupiditate quis nihil natus aspernatur ipsa velit consequatur.\nEt soluta est tenetur beatae distinctio quam quasi suscipit non." },
                    { 114, new DateTime(2021, 4, 16, 3, 7, 40, 588, DateTimeKind.Local).AddTicks(5757), 55, new DateTime(2021, 12, 12, 6, 3, 24, 444, DateTimeKind.Local).AddTicks(2888), new DateTime(2020, 12, 21, 16, 2, 40, 434, DateTimeKind.Local).AddTicks(2298), 3, 2, "Eaque sit recusandae ut harum earum sed velit." },
                    { 161, new DateTime(2021, 1, 20, 20, 47, 21, 619, DateTimeKind.Local).AddTicks(6750), 87, new DateTime(2022, 7, 12, 23, 0, 36, 691, DateTimeKind.Local).AddTicks(5451), new DateTime(2020, 9, 16, 3, 1, 39, 443, DateTimeKind.Local).AddTicks(7214), 2, 2, "Soluta aut aut quo debitis consectetur ipsam quod dolorum." },
                    { 190, new DateTime(2020, 10, 6, 16, 47, 21, 610, DateTimeKind.Local).AddTicks(2754), 141, new DateTime(2022, 3, 10, 7, 19, 54, 66, DateTimeKind.Local).AddTicks(7157), new DateTime(2021, 5, 16, 14, 33, 44, 66, DateTimeKind.Local).AddTicks(7977), 3, 2, "Nisi molestias quis molestiae delectus aut. Aut aut corporis soluta omnis. Natus quas est a explicabo alias commodi id in. Voluptas molestiae ad quasi maiores ipsam assumenda." },
                    { 3, new DateTime(2021, 3, 9, 23, 5, 53, 975, DateTimeKind.Local).AddTicks(6099), 37, new DateTime(2021, 9, 24, 1, 36, 41, 145, DateTimeKind.Local).AddTicks(9786), new DateTime(2020, 11, 28, 4, 0, 45, 105, DateTimeKind.Local).AddTicks(7344), 2, 81, "Non consectetur nisi iure cum impedit in at. Vel harum eos delectus fuga quis optio. Id delectus pariatur reiciendis accusamus placeat molestiae vitae nemo numquam." },
                    { 24, new DateTime(2020, 8, 22, 20, 16, 23, 702, DateTimeKind.Local).AddTicks(2442), 124, new DateTime(2022, 6, 16, 6, 2, 59, 735, DateTimeKind.Local).AddTicks(973), new DateTime(2021, 6, 18, 4, 19, 2, 994, DateTimeKind.Local).AddTicks(8720), 3, 81, "Sint illum dolores culpa est accusantium voluptatem voluptas.\nRerum magni repellendus quasi voluptatibus impedit.\nAutem tenetur reprehenderit.\nMaiores qui repudiandae asperiores cumque omnis aliquid consequatur." },
                    { 74, new DateTime(2021, 7, 19, 17, 22, 21, 846, DateTimeKind.Local).AddTicks(6569), 145, new DateTime(2022, 1, 3, 14, 57, 2, 376, DateTimeKind.Local).AddTicks(5107), new DateTime(2020, 9, 17, 6, 53, 3, 334, DateTimeKind.Local).AddTicks(2867), 3, 81, "Dignissimos dicta atque sed possimus error explicabo assumenda blanditiis. Deleniti quis a et enim et et. Reiciendis voluptatibus voluptas sunt veniam. Rerum ratione sint nobis facilis adipisci reprehenderit. Inventore repellat eveniet sed ipsam consequatur." },
                    { 116, new DateTime(2020, 10, 26, 10, 11, 13, 271, DateTimeKind.Local).AddTicks(7296), 135, new DateTime(2022, 6, 21, 17, 17, 1, 368, DateTimeKind.Local).AddTicks(2950), new DateTime(2021, 7, 15, 11, 38, 12, 187, DateTimeKind.Local).AddTicks(3417), 5, 81, "Ut aut in odit qui sint." },
                    { 188, new DateTime(2021, 1, 26, 1, 31, 53, 127, DateTimeKind.Local).AddTicks(7917), 21, new DateTime(2022, 7, 21, 7, 44, 33, 856, DateTimeKind.Local).AddTicks(1686), new DateTime(2020, 9, 15, 8, 24, 2, 839, DateTimeKind.Local).AddTicks(4161), 1, 81, "Non magnam animi nisi excepturi commodi.\nA deserunt numquam aut est.\nEt ut veniam beatae saepe ut.\nNon explicabo ut sapiente non." },
                    { 1, new DateTime(2021, 7, 26, 12, 9, 18, 610, DateTimeKind.Local).AddTicks(390), 14, new DateTime(2022, 8, 12, 4, 19, 36, 75, DateTimeKind.Local).AddTicks(1457), new DateTime(2020, 11, 26, 21, 41, 51, 327, DateTimeKind.Local).AddTicks(9275), 4, 22, "Est fugiat et adipisci ut explicabo enim eum. Optio officiis dolorem autem assumenda. Saepe consequatur in incidunt ab." },
                    { 132, new DateTime(2020, 8, 27, 4, 13, 41, 307, DateTimeKind.Local).AddTicks(7931), 143, new DateTime(2021, 12, 17, 14, 45, 58, 748, DateTimeKind.Local).AddTicks(2280), new DateTime(2021, 5, 26, 23, 24, 11, 651, DateTimeKind.Local).AddTicks(6092), 1, 48, "Possimus nam possimus quia." },
                    { 182, new DateTime(2020, 9, 25, 2, 14, 55, 919, DateTimeKind.Local).AddTicks(3551), 18, new DateTime(2021, 12, 28, 5, 39, 21, 672, DateTimeKind.Local).AddTicks(8713), new DateTime(2021, 4, 22, 2, 12, 47, 222, DateTimeKind.Local).AddTicks(2890), 1, 47, "Nihil voluptas neque et omnis velit consequatur dolorem.\nRepudiandae dolor neque qui sint laudantium ut sit quibusdam iure.\nBlanditiis dolorem alias quas.\nAmet voluptatibus voluptatum.\nReiciendis minus ut et assumenda optio.\nExpedita rerum ex omnis." },
                    { 64, new DateTime(2021, 7, 12, 11, 15, 19, 475, DateTimeKind.Local).AddTicks(1605), 98, new DateTime(2022, 1, 10, 23, 53, 9, 812, DateTimeKind.Local).AddTicks(7808), new DateTime(2020, 9, 18, 18, 34, 18, 378, DateTimeKind.Local).AddTicks(5400), 3, 47, "Maxime fuga et voluptatem autem blanditiis illum voluptas quod. Voluptatem quam ut esse repellat omnis consectetur sunt nam inventore. Consectetur ipsam omnis maxime corrupti voluptas consequuntur adipisci. Odit aliquid optio sint. Quam qui similique facere quidem. Ut qui itaque et." },
                    { 135, new DateTime(2020, 9, 19, 1, 29, 53, 743, DateTimeKind.Local).AddTicks(9094), 6, new DateTime(2022, 4, 27, 1, 15, 23, 592, DateTimeKind.Local).AddTicks(7281), new DateTime(2020, 10, 16, 9, 18, 39, 595, DateTimeKind.Local).AddTicks(4322), 2, 43, "eum" },
                    { 150, new DateTime(2021, 8, 15, 5, 45, 50, 276, DateTimeKind.Local).AddTicks(9669), 38, new DateTime(2022, 5, 9, 13, 30, 35, 309, DateTimeKind.Local).AddTicks(6405), new DateTime(2020, 12, 27, 19, 48, 11, 911, DateTimeKind.Local).AddTicks(8043), 3, 43, "Ut sed quasi dignissimos." },
                    { 159, new DateTime(2020, 11, 21, 13, 10, 4, 891, DateTimeKind.Local).AddTicks(9635), 71, new DateTime(2021, 11, 15, 8, 10, 22, 216, DateTimeKind.Local).AddTicks(2938), new DateTime(2021, 5, 25, 16, 29, 2, 484, DateTimeKind.Local).AddTicks(4337), 3, 43, "Corporis quia dicta aperiam aut.\nMinima sunt tempora voluptate ex rerum eum.\nRem quibusdam eaque consectetur optio ea ea dolorum consequatur.\nVelit consequatur vel delectus.\nEst fugiat iusto maiores consequatur." },
                    { 55, new DateTime(2021, 4, 2, 19, 2, 33, 99, DateTimeKind.Local).AddTicks(144), 97, new DateTime(2022, 5, 26, 9, 18, 13, 590, DateTimeKind.Local).AddTicks(1928), new DateTime(2021, 7, 28, 22, 8, 29, 814, DateTimeKind.Local).AddTicks(4483), 5, 70, "Dicta sequi magnam alias delectus. Vero quos incidunt qui corporis et. Suscipit quis cum consequatur omnis aut quaerat est alias est. Hic quia perspiciatis. Eos modi ut veritatis consequatur et natus reiciendis aut reprehenderit. Aut quos molestias repellendus exercitationem debitis molestias quam." },
                    { 71, new DateTime(2021, 3, 15, 11, 24, 18, 96, DateTimeKind.Local).AddTicks(5477), 23, new DateTime(2021, 11, 2, 6, 44, 33, 31, DateTimeKind.Local).AddTicks(7231), new DateTime(2020, 10, 6, 4, 56, 51, 835, DateTimeKind.Local).AddTicks(5838), 1, 70, "Voluptas sit aut officiis voluptate.\nMolestiae id aut non maxime dicta temporibus.\nTemporibus quisquam ut animi mollitia dolore.\nSint qui ullam ut enim facere consequatur veniam amet.\nEa laudantium asperiores eos tenetur labore." },
                    { 100, new DateTime(2020, 8, 29, 16, 20, 49, 287, DateTimeKind.Local).AddTicks(9366), 96, new DateTime(2022, 1, 12, 0, 5, 32, 323, DateTimeKind.Local).AddTicks(7996), new DateTime(2021, 3, 15, 6, 33, 52, 250, DateTimeKind.Local).AddTicks(3761), 4, 70, "Recusandae mollitia consequatur illo aut dignissimos ut quia.\nVoluptatem aut itaque sed dicta.\nConsequatur reiciendis labore et.\nDicta vitae velit vitae sint veritatis accusantium.\nSoluta nemo magnam." },
                    { 101, new DateTime(2021, 7, 29, 0, 45, 32, 800, DateTimeKind.Local).AddTicks(2126), 77, new DateTime(2022, 7, 17, 10, 57, 40, 134, DateTimeKind.Local).AddTicks(4770), new DateTime(2020, 11, 8, 3, 45, 37, 332, DateTimeKind.Local).AddTicks(808), 3, 70, "Et aut excepturi minus eum.\nIncidunt at ut.\nSed atque deleniti velit iste pariatur in est.\nIpsa esse sint dignissimos." },
                    { 112, new DateTime(2021, 7, 19, 10, 52, 43, 59, DateTimeKind.Local).AddTicks(9100), 137, new DateTime(2021, 8, 26, 6, 45, 15, 857, DateTimeKind.Local).AddTicks(3569), new DateTime(2021, 6, 5, 20, 43, 40, 176, DateTimeKind.Local).AddTicks(3181), 1, 70, "ratione" },
                    { 128, new DateTime(2021, 2, 23, 1, 30, 13, 406, DateTimeKind.Local).AddTicks(3422), 122, new DateTime(2022, 8, 8, 14, 33, 19, 46, DateTimeKind.Local).AddTicks(8279), new DateTime(2021, 4, 4, 16, 48, 9, 505, DateTimeKind.Local).AddTicks(5422), 5, 70, "non" },
                    { 17, new DateTime(2021, 3, 19, 18, 24, 45, 657, DateTimeKind.Local).AddTicks(3978), 74, new DateTime(2022, 8, 9, 18, 43, 57, 831, DateTimeKind.Local).AddTicks(1571), new DateTime(2020, 8, 22, 16, 57, 56, 821, DateTimeKind.Local).AddTicks(9618), 5, 13, "Dolore maiores voluptatem. Vel harum accusantium corporis modi enim molestiae sed. Sit dolorum dicta qui. Voluptas voluptatibus quis qui et repellat doloribus aut ratione qui." },
                    { 58, new DateTime(2020, 10, 2, 1, 31, 19, 841, DateTimeKind.Local).AddTicks(6703), 10, new DateTime(2022, 4, 6, 15, 3, 46, 903, DateTimeKind.Local).AddTicks(1001), new DateTime(2021, 5, 7, 5, 51, 27, 122, DateTimeKind.Local).AddTicks(9881), 2, 13, "Nam ut libero facere libero est sit.\nQuasi illo est aut libero voluptatem perspiciatis nihil magnam.\nUt omnis ullam." },
                    { 78, new DateTime(2020, 11, 21, 5, 23, 38, 95, DateTimeKind.Local).AddTicks(9914), 41, new DateTime(2022, 5, 22, 21, 37, 19, 761, DateTimeKind.Local).AddTicks(6808), new DateTime(2021, 6, 26, 17, 43, 35, 827, DateTimeKind.Local).AddTicks(8821), 3, 13, "Repellat aspernatur quis vitae vero ut non voluptas.\nVeniam qui eius.\nMinus sequi ipsa iusto illo iure veniam distinctio aut.\nSed omnis quia exercitationem vel odio voluptas." },
                    { 130, new DateTime(2020, 10, 20, 12, 47, 33, 68, DateTimeKind.Local).AddTicks(3715), 35, new DateTime(2021, 10, 8, 22, 4, 20, 499, DateTimeKind.Local).AddTicks(2973), new DateTime(2020, 12, 7, 4, 59, 32, 78, DateTimeKind.Local).AddTicks(6095), 1, 13, "in" },
                    { 194, new DateTime(2021, 1, 27, 14, 22, 16, 153, DateTimeKind.Local).AddTicks(7700), 67, new DateTime(2021, 9, 1, 6, 35, 34, 857, DateTimeKind.Local).AddTicks(8850), new DateTime(2021, 4, 1, 2, 28, 19, 133, DateTimeKind.Local).AddTicks(9209), 3, 13, "Perferendis unde laboriosam expedita quia mollitia dolorum dolor odio." },
                    { 65, new DateTime(2020, 11, 11, 13, 5, 14, 600, DateTimeKind.Local).AddTicks(8075), 114, new DateTime(2021, 10, 11, 15, 28, 59, 25, DateTimeKind.Local).AddTicks(6517), new DateTime(2021, 1, 15, 14, 16, 20, 346, DateTimeKind.Local).AddTicks(5339), 4, 59, "Numquam omnis nemo saepe sint rerum est eligendi dolores sunt.\nTempore est illo fugit in aut fuga illum doloremque.\nOdit autem autem eligendi facilis in commodi deleniti sunt." },
                    { 156, new DateTime(2021, 3, 7, 2, 51, 50, 473, DateTimeKind.Local).AddTicks(3740), 3, new DateTime(2021, 10, 3, 11, 0, 4, 187, DateTimeKind.Local).AddTicks(5644), new DateTime(2020, 12, 8, 4, 36, 5, 513, DateTimeKind.Local).AddTicks(8027), 1, 19, "repellat" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 196, new DateTime(2021, 5, 15, 10, 18, 42, 225, DateTimeKind.Local).AddTicks(8383), 73, new DateTime(2022, 7, 16, 14, 25, 0, 215, DateTimeKind.Local).AddTicks(9411), new DateTime(2021, 3, 2, 18, 52, 48, 240, DateTimeKind.Local).AddTicks(7225), 1, 19, "Et aut consequatur delectus accusantium atque accusantium. Quia enim earum quidem quia reiciendis nulla dolor. Optio cum nobis non. Consequatur labore delectus hic officiis ducimus quod repudiandae quaerat incidunt. Ipsa corporis ipsam quis voluptatem odit at quo. Laboriosam nulla velit voluptatem et qui." },
                    { 39, new DateTime(2021, 3, 9, 18, 1, 35, 866, DateTimeKind.Local).AddTicks(6016), 67, new DateTime(2022, 6, 26, 23, 39, 50, 407, DateTimeKind.Local).AddTicks(3913), new DateTime(2021, 2, 20, 7, 8, 39, 534, DateTimeKind.Local).AddTicks(2805), 2, 7, "Odit et corrupti voluptatem minus nostrum minus voluptates omnis est." },
                    { 122, new DateTime(2021, 8, 10, 8, 44, 40, 16, DateTimeKind.Local).AddTicks(9525), 96, new DateTime(2022, 7, 6, 0, 33, 51, 621, DateTimeKind.Local).AddTicks(8546), new DateTime(2020, 12, 25, 0, 6, 9, 332, DateTimeKind.Local).AddTicks(7798), 3, 7, "Molestias repudiandae porro aut eligendi. Quae odio omnis accusamus similique. Dicta suscipit blanditiis suscipit impedit accusantium vero magni. Et non quia earum voluptates. Reiciendis incidunt et quibusdam in ratione quis qui." },
                    { 134, new DateTime(2021, 4, 5, 13, 16, 53, 657, DateTimeKind.Local).AddTicks(6252), 52, new DateTime(2022, 4, 2, 19, 0, 18, 585, DateTimeKind.Local).AddTicks(5464), new DateTime(2021, 1, 2, 7, 12, 8, 273, DateTimeKind.Local).AddTicks(8504), 4, 7, "voluptates" },
                    { 177, new DateTime(2021, 7, 24, 23, 1, 54, 7, DateTimeKind.Local).AddTicks(6972), 80, new DateTime(2021, 8, 29, 4, 35, 13, 455, DateTimeKind.Local).AddTicks(560), new DateTime(2021, 5, 3, 5, 32, 41, 313, DateTimeKind.Local).AddTicks(2811), 2, 7, "Ut possimus tempora aut atque ut sint." },
                    { 151, new DateTime(2021, 1, 11, 12, 49, 27, 703, DateTimeKind.Local).AddTicks(4820), 25, new DateTime(2021, 9, 22, 12, 43, 41, 419, DateTimeKind.Local).AddTicks(5864), new DateTime(2021, 8, 6, 19, 34, 46, 232, DateTimeKind.Local).AddTicks(8662), 1, 47, "Nihil nisi quibusdam vel temporibus beatae." },
                    { 76, new DateTime(2020, 9, 28, 18, 54, 33, 79, DateTimeKind.Local).AddTicks(7832), 147, new DateTime(2022, 6, 27, 0, 29, 53, 11, DateTimeKind.Local).AddTicks(192), new DateTime(2021, 7, 11, 21, 50, 8, 290, DateTimeKind.Local).AddTicks(5211), 2, 43, "Facere est quis veritatis id debitis rerum temporibus. Minus inventore neque enim ut quis deserunt et enim accusantium. Minus suscipit ex. Accusamus ut voluptas libero nostrum perspiciatis. Magni ducimus quidem fuga quaerat excepturi dolor qui explicabo ut. Repellat sint omnis." },
                    { 198, new DateTime(2021, 7, 27, 15, 58, 14, 410, DateTimeKind.Local).AddTicks(9060), 59, new DateTime(2021, 12, 12, 14, 20, 34, 293, DateTimeKind.Local).AddTicks(5883), new DateTime(2020, 11, 14, 0, 40, 28, 30, DateTimeKind.Local).AddTicks(8295), 3, 48, "Pariatur quod expedita nesciunt dolorem earum voluptatem nostrum consectetur. Alias est earum molestias libero. Enim quibusdam ipsam doloremque et quaerat. Non fugiat cumque sunt laudantium voluptates qui. Perferendis eveniet totam ut harum numquam nulla maxime." },
                    { 121, new DateTime(2021, 1, 16, 12, 25, 32, 187, DateTimeKind.Local).AddTicks(7197), 28, new DateTime(2022, 5, 10, 7, 19, 14, 939, DateTimeKind.Local).AddTicks(2550), new DateTime(2020, 9, 24, 9, 33, 29, 622, DateTimeKind.Local).AddTicks(218), 2, 8, "Laborum dolorum nemo facilis culpa magnam." },
                    { 54, new DateTime(2021, 3, 26, 14, 48, 16, 47, DateTimeKind.Local).AddTicks(8925), 68, new DateTime(2022, 1, 19, 23, 18, 50, 278, DateTimeKind.Local).AddTicks(3292), new DateTime(2020, 12, 1, 20, 8, 43, 972, DateTimeKind.Local).AddTicks(1764), 3, 1, "Reprehenderit nihil sit.\nRepellat perferendis eligendi dolor quia." },
                    { 163, new DateTime(2020, 9, 13, 12, 24, 7, 413, DateTimeKind.Local).AddTicks(6635), 61, new DateTime(2021, 9, 5, 2, 39, 43, 266, DateTimeKind.Local).AddTicks(5242), new DateTime(2020, 11, 5, 19, 10, 34, 74, DateTimeKind.Local).AddTicks(9653), 3, 1, "dolorem" },
                    { 192, new DateTime(2020, 12, 2, 3, 40, 1, 821, DateTimeKind.Local).AddTicks(3760), 94, new DateTime(2021, 8, 18, 18, 54, 35, 703, DateTimeKind.Local).AddTicks(8917), new DateTime(2021, 5, 8, 18, 37, 40, 94, DateTimeKind.Local).AddTicks(3915), 5, 1, "Quaerat esse odio quia vitae et dicta quaerat quasi. Molestiae accusantium dolorem voluptas incidunt eum. Et hic consequatur omnis ad doloribus sint soluta hic. Et ducimus ratione. Eum nam qui sit aut omnis est blanditiis officia. Rerum quaerat dignissimos quia accusantium eum et debitis nam." },
                    { 199, new DateTime(2021, 3, 16, 21, 7, 13, 165, DateTimeKind.Local).AddTicks(7726), 33, new DateTime(2021, 11, 13, 18, 30, 6, 986, DateTimeKind.Local).AddTicks(6042), new DateTime(2021, 2, 18, 8, 3, 14, 882, DateTimeKind.Local).AddTicks(8505), 3, 1, "assumenda" },
                    { 7, new DateTime(2020, 9, 17, 13, 25, 50, 852, DateTimeKind.Local).AddTicks(8882), 76, new DateTime(2022, 8, 6, 21, 13, 20, 827, DateTimeKind.Local).AddTicks(533), new DateTime(2020, 10, 28, 2, 1, 15, 153, DateTimeKind.Local).AddTicks(6407), 1, 55, "Maiores vel exercitationem modi.\nOdio quod voluptatem assumenda iure facere consectetur est iste voluptatem.\nQuo et aperiam quos qui.\nLaudantium ea aut occaecati ad odit numquam velit quo maxime.\nEum eveniet facilis rem nemo." },
                    { 158, new DateTime(2021, 2, 10, 5, 47, 42, 639, DateTimeKind.Local).AddTicks(2919), 47, new DateTime(2022, 5, 5, 23, 56, 57, 247, DateTimeKind.Local).AddTicks(1006), new DateTime(2021, 3, 23, 2, 35, 31, 528, DateTimeKind.Local).AddTicks(9517), 2, 55, "Facere est et." },
                    { 184, new DateTime(2020, 9, 22, 16, 59, 44, 320, DateTimeKind.Local).AddTicks(874), 138, new DateTime(2022, 1, 23, 1, 30, 54, 204, DateTimeKind.Local).AddTicks(826), new DateTime(2021, 6, 13, 7, 18, 56, 414, DateTimeKind.Local).AddTicks(2204), 2, 55, "Omnis expedita sint consequatur eius necessitatibus quam." },
                    { 36, new DateTime(2021, 5, 13, 22, 39, 6, 683, DateTimeKind.Local).AddTicks(719), 65, new DateTime(2022, 7, 31, 9, 9, 2, 744, DateTimeKind.Local).AddTicks(1886), new DateTime(2021, 3, 1, 9, 46, 23, 790, DateTimeKind.Local).AddTicks(1297), 5, 101, "quas" },
                    { 95, new DateTime(2021, 5, 25, 10, 59, 45, 538, DateTimeKind.Local).AddTicks(8156), 13, new DateTime(2022, 5, 3, 11, 57, 54, 181, DateTimeKind.Local).AddTicks(2945), new DateTime(2021, 8, 13, 2, 2, 21, 355, DateTimeKind.Local).AddTicks(4190), 1, 101, "dolor" },
                    { 104, new DateTime(2021, 3, 15, 1, 58, 49, 141, DateTimeKind.Local).AddTicks(4310), 100, new DateTime(2022, 8, 1, 6, 29, 39, 800, DateTimeKind.Local).AddTicks(3110), new DateTime(2021, 5, 6, 8, 43, 9, 449, DateTimeKind.Local).AddTicks(8478), 2, 101, "Voluptatum consequatur at aut commodi blanditiis a sint ut molestiae. Eos provident ipsum et quas quis. Ad recusandae totam enim non. Eaque dignissimos minima aut." },
                    { 136, new DateTime(2020, 10, 11, 19, 30, 37, 18, DateTimeKind.Local).AddTicks(9370), 91, new DateTime(2021, 12, 23, 23, 36, 14, 371, DateTimeKind.Local).AddTicks(6814), new DateTime(2020, 9, 3, 4, 21, 23, 331, DateTimeKind.Local).AddTicks(9559), 5, 101, "Autem omnis rerum. Cupiditate in delectus iste nihil. Ullam molestiae quae et quis laborum." },
                    { 153, new DateTime(2021, 3, 12, 14, 19, 30, 240, DateTimeKind.Local).AddTicks(1058), 75, new DateTime(2021, 9, 12, 5, 0, 44, 217, DateTimeKind.Local).AddTicks(2340), new DateTime(2021, 7, 21, 13, 27, 44, 222, DateTimeKind.Local).AddTicks(4744), 2, 101, "Ut nisi ut vero asperiores porro rerum rerum et et.\nLaudantium recusandae sunt minima unde dicta voluptatem." },
                    { 67, new DateTime(2021, 4, 3, 3, 25, 52, 628, DateTimeKind.Local).AddTicks(7923), 11, new DateTime(2021, 11, 30, 17, 18, 58, 65, DateTimeKind.Local).AddTicks(7223), new DateTime(2020, 10, 8, 13, 2, 6, 978, DateTimeKind.Local).AddTicks(1515), 4, 36, "qui" },
                    { 99, new DateTime(2021, 3, 13, 1, 46, 59, 773, DateTimeKind.Local).AddTicks(1448), 74, new DateTime(2022, 5, 16, 22, 56, 31, 771, DateTimeKind.Local).AddTicks(2888), new DateTime(2020, 9, 8, 19, 10, 47, 771, DateTimeKind.Local).AddTicks(5198), 4, 36, "Excepturi impedit dolorem non officiis possimus quo maiores." },
                    { 56, new DateTime(2021, 6, 17, 11, 3, 48, 615, DateTimeKind.Local).AddTicks(521), 88, new DateTime(2021, 9, 19, 2, 53, 47, 425, DateTimeKind.Local).AddTicks(1699), new DateTime(2020, 10, 20, 9, 22, 13, 388, DateTimeKind.Local).AddTicks(4066), 2, 12, "Laudantium numquam ab.\nQuo reiciendis harum consequatur molestiae labore consequatur quasi est.\nAccusamus aut eaque ipsum voluptas voluptatem.\nQui nesciunt dignissimos repellendus." },
                    { 87, new DateTime(2021, 1, 14, 11, 34, 36, 904, DateTimeKind.Local).AddTicks(3702), 17, new DateTime(2021, 12, 4, 0, 4, 8, 997, DateTimeKind.Local).AddTicks(3781), new DateTime(2021, 1, 23, 11, 10, 9, 957, DateTimeKind.Local).AddTicks(8729), 3, 12, "debitis" },
                    { 129, new DateTime(2020, 9, 5, 22, 2, 22, 838, DateTimeKind.Local).AddTicks(7252), 138, new DateTime(2022, 8, 2, 2, 45, 13, 307, DateTimeKind.Local).AddTicks(3404), new DateTime(2020, 8, 23, 14, 0, 12, 394, DateTimeKind.Local).AddTicks(1864), 1, 12, "Placeat eos et animi aut ut in.\nVoluptatem iure autem.\nDolor inventore tempora." },
                    { 28, new DateTime(2021, 8, 16, 3, 29, 46, 215, DateTimeKind.Local).AddTicks(4406), 94, new DateTime(2021, 9, 23, 1, 32, 37, 856, DateTimeKind.Local).AddTicks(4197), new DateTime(2021, 1, 20, 10, 43, 32, 695, DateTimeKind.Local).AddTicks(5292), 2, 42, "praesentium" },
                    { 53, new DateTime(2021, 4, 27, 17, 30, 39, 756, DateTimeKind.Local).AddTicks(817), 132, new DateTime(2022, 3, 3, 2, 57, 16, 397, DateTimeKind.Local).AddTicks(1698), new DateTime(2021, 5, 25, 3, 39, 34, 894, DateTimeKind.Local).AddTicks(7263), 2, 42, "Similique harum neque.\nLaudantium itaque dolor eius dolore reiciendis quas minus possimus.\nNesciunt est est sit vel numquam.\nAnimi aliquam nemo." },
                    { 63, new DateTime(2020, 9, 29, 13, 57, 8, 606, DateTimeKind.Local).AddTicks(8030), 27, new DateTime(2022, 4, 11, 6, 41, 53, 293, DateTimeKind.Local).AddTicks(2854), new DateTime(2020, 10, 23, 10, 14, 13, 317, DateTimeKind.Local).AddTicks(3276), 1, 42, "occaecati" },
                    { 91, new DateTime(2021, 3, 14, 16, 12, 5, 210, DateTimeKind.Local).AddTicks(5085), 48, new DateTime(2022, 8, 17, 18, 20, 2, 853, DateTimeKind.Local).AddTicks(7641), new DateTime(2021, 4, 7, 19, 6, 50, 629, DateTimeKind.Local).AddTicks(4821), 3, 42, "dolores" },
                    { 4, new DateTime(2021, 3, 30, 12, 14, 38, 427, DateTimeKind.Local).AddTicks(6636), 58, new DateTime(2022, 4, 16, 15, 26, 17, 527, DateTimeKind.Local).AddTicks(6828), new DateTime(2020, 9, 29, 2, 12, 45, 990, DateTimeKind.Local).AddTicks(2116), 3, 1, "deleniti" },
                    { 15, new DateTime(2021, 8, 5, 20, 14, 59, 825, DateTimeKind.Local).AddTicks(866), 60, new DateTime(2022, 7, 29, 4, 22, 4, 319, DateTimeKind.Local).AddTicks(131), new DateTime(2021, 4, 17, 22, 53, 40, 120, DateTimeKind.Local).AddTicks(6689), 3, 8, "Tempora delectus aut et in.\nCulpa et est sed quia quis.\nAut mollitia nam odio ut ipsa ratione aliquid.\nOccaecati dicta rerum saepe corrupti nobis ipsa." },
                    { 164, new DateTime(2021, 3, 16, 20, 15, 20, 482, DateTimeKind.Local).AddTicks(5432), 126, new DateTime(2022, 4, 17, 14, 54, 16, 327, DateTimeKind.Local).AddTicks(3622), new DateTime(2021, 2, 5, 23, 58, 32, 272, DateTimeKind.Local).AddTicks(4371), 2, 56, "Officiis nihil non fuga ut illum consectetur non.\nAutem dicta in quas magnam eum similique ipsam magni.\nAccusamus repudiandae voluptatem nihil deleniti consequuntur magni facilis.\nIncidunt qui et voluptate est.\nUt voluptatem est recusandae rerum sit omnis.\nEligendi repellat sed nihil." },
                    { 171, new DateTime(2020, 12, 31, 19, 9, 1, 43, DateTimeKind.Local).AddTicks(6969), 123, new DateTime(2021, 12, 20, 7, 19, 34, 465, DateTimeKind.Local).AddTicks(7534), new DateTime(2021, 7, 21, 22, 59, 19, 381, DateTimeKind.Local).AddTicks(1868), 4, 6, "Qui et voluptatum corrupti libero aut sunt.\nNon consequatur sit ratione laborum molestiae consequatur voluptatum saepe beatae." },
                    { 137, new DateTime(2021, 3, 3, 11, 40, 14, 613, DateTimeKind.Local).AddTicks(1719), 43, new DateTime(2022, 2, 18, 18, 2, 41, 804, DateTimeKind.Local).AddTicks(9943), new DateTime(2020, 11, 13, 14, 38, 23, 166, DateTimeKind.Local).AddTicks(7514), 2, 8, "Incidunt velit modi et voluptatem eum possimus. Voluptate nesciunt est odit similique voluptas ab expedita temporibus qui. Qui et et eius. Quam voluptas nihil iusto dolores. Cupiditate et eaque. Exercitationem neque quod molestiae odio dicta perspiciatis aperiam quidem." },
                    { 157, new DateTime(2021, 3, 22, 22, 21, 15, 360, DateTimeKind.Local).AddTicks(6216), 74, new DateTime(2022, 2, 18, 19, 14, 40, 251, DateTimeKind.Local).AddTicks(1160), new DateTime(2021, 4, 19, 13, 34, 50, 930, DateTimeKind.Local).AddTicks(5975), 3, 8, "Sapiente possimus quas error molestiae. Blanditiis aut debitis consequuntur perspiciatis cum vel. Et porro sed molestiae pariatur cupiditate repellendus soluta nam ad. Quasi nobis quasi eaque." },
                    { 168, new DateTime(2021, 4, 15, 1, 26, 29, 798, DateTimeKind.Local).AddTicks(9203), 37, new DateTime(2022, 7, 24, 11, 3, 47, 88, DateTimeKind.Local).AddTicks(8369), new DateTime(2021, 1, 30, 20, 50, 43, 5, DateTimeKind.Local).AddTicks(2621), 2, 8, "Ducimus quo earum sed necessitatibus qui." },
                    { 178, new DateTime(2020, 9, 6, 23, 21, 52, 326, DateTimeKind.Local).AddTicks(98), 7, new DateTime(2022, 3, 27, 23, 17, 19, 419, DateTimeKind.Local).AddTicks(6691), new DateTime(2021, 3, 26, 0, 41, 12, 40, DateTimeKind.Local).AddTicks(8943), 2, 8, "Nemo et quos ad et alias eveniet quis occaecati. Molestiae porro dolorem numquam possimus culpa odio. Voluptatum quo soluta impedit voluptas expedita quaerat. Et voluptatibus enim. Quaerat iusto sint vitae." },
                    { 44, new DateTime(2020, 11, 22, 18, 46, 11, 50, DateTimeKind.Local).AddTicks(3296), 49, new DateTime(2021, 8, 28, 7, 7, 21, 57, DateTimeKind.Local).AddTicks(7483), new DateTime(2020, 9, 15, 23, 26, 40, 670, DateTimeKind.Local).AddTicks(6222), 3, 33, "Praesentium et animi in hic commodi." },
                    { 105, new DateTime(2021, 6, 14, 14, 43, 55, 2, DateTimeKind.Local).AddTicks(8445), 39, new DateTime(2022, 2, 12, 15, 1, 20, 91, DateTimeKind.Local).AddTicks(2861), new DateTime(2020, 9, 4, 11, 42, 38, 605, DateTimeKind.Local).AddTicks(6302), 4, 33, "Et sint sed. Suscipit voluptas ea assumenda laboriosam rem id. Voluptatibus earum similique. Rem totam quia nesciunt laborum architecto et." },
                    { 117, new DateTime(2021, 5, 8, 13, 30, 33, 426, DateTimeKind.Local).AddTicks(8350), 55, new DateTime(2021, 12, 9, 9, 5, 57, 138, DateTimeKind.Local).AddTicks(7750), new DateTime(2021, 2, 8, 20, 0, 12, 520, DateTimeKind.Local).AddTicks(8396), 3, 33, "Et ut ab consequatur occaecati sit repellendus." },
                    { 143, new DateTime(2020, 11, 24, 5, 10, 36, 431, DateTimeKind.Local).AddTicks(6339), 136, new DateTime(2022, 8, 16, 17, 22, 4, 306, DateTimeKind.Local).AddTicks(2613), new DateTime(2020, 10, 23, 7, 58, 1, 798, DateTimeKind.Local).AddTicks(5585), 2, 33, "dolores" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 172, new DateTime(2020, 10, 28, 7, 22, 11, 634, DateTimeKind.Local).AddTicks(1424), 136, new DateTime(2022, 3, 14, 4, 9, 38, 426, DateTimeKind.Local).AddTicks(4783), new DateTime(2020, 9, 21, 1, 11, 6, 918, DateTimeKind.Local).AddTicks(2068), 4, 33, "Quam quam quod aut. Doloribus autem cum. Ullam nihil rerum sequi cumque sed unde est." },
                    { 14, new DateTime(2021, 5, 10, 21, 59, 48, 983, DateTimeKind.Local).AddTicks(6236), 113, new DateTime(2021, 12, 30, 4, 50, 33, 524, DateTimeKind.Local).AddTicks(355), new DateTime(2020, 12, 25, 15, 24, 13, 632, DateTimeKind.Local).AddTicks(8559), 1, 99, "Animi maxime aut et quis est quibusdam." },
                    { 51, new DateTime(2021, 6, 17, 11, 31, 1, 744, DateTimeKind.Local).AddTicks(2178), 113, new DateTime(2021, 11, 8, 14, 23, 37, 950, DateTimeKind.Local).AddTicks(534), new DateTime(2021, 5, 16, 13, 52, 18, 919, DateTimeKind.Local).AddTicks(2857), 1, 99, "In qui quis praesentium non doloremque modi distinctio qui." },
                    { 68, new DateTime(2021, 1, 23, 17, 52, 17, 38, DateTimeKind.Local).AddTicks(6804), 79, new DateTime(2021, 10, 25, 19, 34, 53, 848, DateTimeKind.Local).AddTicks(1811), new DateTime(2020, 10, 27, 11, 40, 41, 746, DateTimeKind.Local).AddTicks(8494), 2, 99, "Odit possimus recusandae.\nAccusamus enim quia numquam." },
                    { 75, new DateTime(2021, 3, 21, 0, 53, 13, 299, DateTimeKind.Local).AddTicks(7301), 31, new DateTime(2021, 11, 21, 14, 56, 41, 114, DateTimeKind.Local).AddTicks(9788), new DateTime(2021, 7, 3, 8, 31, 31, 14, DateTimeKind.Local).AddTicks(4871), 2, 99, "Ex autem vel.\nQuibusdam nulla maxime aut officiis et reiciendis est est quae." },
                    { 26, new DateTime(2021, 2, 15, 11, 46, 8, 557, DateTimeKind.Local).AddTicks(1543), 102, new DateTime(2022, 7, 30, 20, 43, 31, 329, DateTimeKind.Local).AddTicks(7822), new DateTime(2020, 10, 1, 7, 0, 49, 558, DateTimeKind.Local).AddTicks(6333), 5, 32, "Repellat voluptas saepe aut velit et quia.\nImpedit libero amet et." },
                    { 34, new DateTime(2021, 1, 31, 12, 2, 27, 592, DateTimeKind.Local).AddTicks(2535), 13, new DateTime(2022, 7, 7, 0, 44, 27, 207, DateTimeKind.Local).AddTicks(4191), new DateTime(2020, 12, 8, 13, 17, 2, 278, DateTimeKind.Local).AddTicks(8299), 3, 32, "veniam" },
                    { 49, new DateTime(2021, 4, 8, 12, 22, 12, 380, DateTimeKind.Local).AddTicks(8901), 32, new DateTime(2022, 5, 9, 8, 15, 7, 42, DateTimeKind.Local).AddTicks(7932), new DateTime(2020, 9, 10, 15, 11, 2, 638, DateTimeKind.Local).AddTicks(1611), 5, 32, "Nihil aut voluptatum." },
                    { 35, new DateTime(2020, 11, 15, 17, 6, 55, 567, DateTimeKind.Local).AddTicks(1802), 40, new DateTime(2021, 12, 9, 6, 30, 13, 143, DateTimeKind.Local).AddTicks(1973), new DateTime(2020, 12, 9, 15, 58, 19, 714, DateTimeKind.Local).AddTicks(3092), 5, 11, "Natus non est iste numquam dolorem aut." },
                    { 110, new DateTime(2021, 8, 1, 7, 29, 9, 41, DateTimeKind.Local).AddTicks(9984), 121, new DateTime(2022, 2, 14, 19, 45, 1, 691, DateTimeKind.Local).AddTicks(7341), new DateTime(2021, 3, 9, 20, 38, 54, 448, DateTimeKind.Local).AddTicks(6514), 5, 11, "Nulla necessitatibus dolor autem deleniti velit quam tenetur quis nisi." },
                    { 149, new DateTime(2021, 5, 8, 11, 54, 48, 780, DateTimeKind.Local).AddTicks(2180), 51, new DateTime(2021, 9, 20, 13, 21, 8, 792, DateTimeKind.Local).AddTicks(3609), new DateTime(2021, 4, 4, 21, 1, 41, 119, DateTimeKind.Local).AddTicks(7814), 5, 11, "rerum" },
                    { 193, new DateTime(2021, 6, 26, 16, 55, 39, 241, DateTimeKind.Local).AddTicks(1433), 22, new DateTime(2022, 6, 17, 17, 32, 55, 906, DateTimeKind.Local).AddTicks(8680), new DateTime(2021, 5, 29, 9, 11, 20, 832, DateTimeKind.Local).AddTicks(2304), 2, 11, "Cupiditate magni voluptate qui consequatur et culpa quae commodi quo." },
                    { 80, new DateTime(2020, 11, 5, 6, 42, 0, 813, DateTimeKind.Local).AddTicks(3016), 26, new DateTime(2021, 10, 10, 20, 25, 32, 658, DateTimeKind.Local).AddTicks(8544), new DateTime(2020, 9, 24, 16, 28, 59, 125, DateTimeKind.Local).AddTicks(3722), 1, 6, "iure" },
                    { 111, new DateTime(2021, 6, 20, 3, 20, 24, 790, DateTimeKind.Local).AddTicks(9926), 71, new DateTime(2022, 1, 7, 23, 3, 41, 24, DateTimeKind.Local).AddTicks(2483), new DateTime(2021, 7, 31, 9, 29, 6, 160, DateTimeKind.Local).AddTicks(3762), 5, 56, "Qui quisquam aperiam est eligendi voluptas eos." },
                    { 43, new DateTime(2021, 7, 22, 22, 30, 9, 577, DateTimeKind.Local).AddTicks(7505), 20, new DateTime(2022, 1, 28, 10, 31, 18, 871, DateTimeKind.Local).AddTicks(219), new DateTime(2021, 2, 7, 5, 53, 7, 669, DateTimeKind.Local).AddTicks(2514), 4, 43, "Nulla tempora velit quasi enim. Omnis ullam quia praesentium qui nemo nesciunt ab eum a. Officiis adipisci blanditiis doloremque occaecati et deserunt. Corrupti ullam consequuntur atque." },
                    { 33, new DateTime(2020, 11, 10, 10, 40, 9, 361, DateTimeKind.Local).AddTicks(6928), 14, new DateTime(2022, 6, 2, 0, 0, 14, 542, DateTimeKind.Local).AddTicks(4551), new DateTime(2020, 11, 5, 4, 17, 52, 407, DateTimeKind.Local).AddTicks(4398), 2, 43, "In molestiae repellendus sit sit enim consequatur vero omnis." },
                    { 21, new DateTime(2021, 5, 25, 16, 32, 1, 242, DateTimeKind.Local).AddTicks(5834), 63, new DateTime(2022, 1, 18, 7, 56, 29, 673, DateTimeKind.Local).AddTicks(2317), new DateTime(2020, 11, 27, 17, 38, 26, 227, DateTimeKind.Local).AddTicks(3296), 3, 43, "quia" },
                    { 37, new DateTime(2020, 11, 25, 12, 36, 36, 124, DateTimeKind.Local).AddTicks(928), 62, new DateTime(2022, 2, 14, 3, 8, 14, 498, DateTimeKind.Local).AddTicks(8707), new DateTime(2021, 7, 4, 21, 49, 47, 772, DateTimeKind.Local).AddTicks(6030), 3, 30, "Dicta aperiam quaerat voluptatem expedita in." },
                    { 119, new DateTime(2021, 6, 8, 4, 37, 33, 167, DateTimeKind.Local).AddTicks(1411), 106, new DateTime(2022, 3, 23, 20, 31, 21, 446, DateTimeKind.Local).AddTicks(3418), new DateTime(2021, 2, 18, 22, 33, 36, 250, DateTimeKind.Local).AddTicks(8966), 4, 30, "nihil" },
                    { 25, new DateTime(2020, 12, 10, 9, 42, 3, 160, DateTimeKind.Local).AddTicks(7422), 82, new DateTime(2022, 1, 6, 16, 1, 20, 641, DateTimeKind.Local).AddTicks(605), new DateTime(2020, 8, 29, 6, 39, 59, 780, DateTimeKind.Local).AddTicks(770), 3, 31, "eius" },
                    { 200, new DateTime(2021, 3, 12, 9, 48, 26, 954, DateTimeKind.Local).AddTicks(9008), 114, new DateTime(2022, 7, 6, 17, 27, 33, 422, DateTimeKind.Local).AddTicks(8043), new DateTime(2021, 4, 16, 13, 42, 37, 896, DateTimeKind.Local).AddTicks(3995), 3, 31, "Sed est quia quia at at vel.\nEt maiores debitis rem neque aperiam.\nLaudantium ab quaerat enim.\nOfficiis saepe occaecati mollitia non libero ut libero molestias quidem." },
                    { 10, new DateTime(2020, 11, 15, 16, 8, 24, 507, DateTimeKind.Local).AddTicks(2763), 40, new DateTime(2022, 7, 28, 10, 50, 20, 383, DateTimeKind.Local).AddTicks(639), new DateTime(2020, 9, 3, 11, 20, 56, 106, DateTimeKind.Local).AddTicks(1983), 2, 34, "Facere et et quia suscipit corporis nam officia amet." },
                    { 41, new DateTime(2020, 8, 31, 11, 9, 44, 286, DateTimeKind.Local).AddTicks(3444), 38, new DateTime(2021, 12, 19, 5, 21, 1, 235, DateTimeKind.Local).AddTicks(2719), new DateTime(2021, 2, 5, 7, 11, 0, 916, DateTimeKind.Local).AddTicks(7970), 1, 34, "Eos iste pariatur modi at sunt minima. Nobis esse maiores omnis reprehenderit omnis ipsa eligendi. Perspiciatis beatae quo. Autem minima alias repellat et quas ut vel. Fugit et ullam magnam rem rerum rerum harum officia provident." },
                    { 126, new DateTime(2020, 12, 17, 0, 13, 54, 640, DateTimeKind.Local).AddTicks(8102), 139, new DateTime(2022, 3, 14, 18, 49, 23, 350, DateTimeKind.Local).AddTicks(8843), new DateTime(2021, 8, 16, 5, 41, 2, 436, DateTimeKind.Local).AddTicks(2306), 1, 34, "Quaerat architecto eos quae ab ut ullam.\nSit et modi fuga mollitia dolor qui autem." },
                    { 2, new DateTime(2021, 7, 19, 21, 51, 57, 696, DateTimeKind.Local).AddTicks(3031), 23, new DateTime(2021, 11, 19, 6, 25, 39, 71, DateTimeKind.Local).AddTicks(7363), new DateTime(2021, 6, 23, 3, 11, 7, 936, DateTimeKind.Local).AddTicks(2007), 1, 61, "consectetur" },
                    { 12, new DateTime(2020, 11, 20, 19, 28, 24, 179, DateTimeKind.Local).AddTicks(5754), 44, new DateTime(2022, 4, 5, 18, 56, 0, 440, DateTimeKind.Local).AddTicks(914), new DateTime(2021, 1, 22, 18, 12, 22, 930, DateTimeKind.Local).AddTicks(6894), 4, 61, "Qui assumenda aut ut in non illum ad deleniti sint. Consequatur sint quibusdam ipsum et voluptate reiciendis. Natus molestiae voluptatem. Dolorem autem ipsum nisi aut. Ipsa ex eum possimus est autem et. Ducimus unde voluptate est et recusandae." },
                    { 69, new DateTime(2020, 8, 28, 20, 45, 6, 734, DateTimeKind.Local).AddTicks(2657), 41, new DateTime(2021, 12, 5, 1, 6, 51, 364, DateTimeKind.Local).AddTicks(4032), new DateTime(2021, 6, 1, 5, 57, 49, 464, DateTimeKind.Local).AddTicks(31), 1, 61, "Perspiciatis sunt tenetur dicta enim cumque." },
                    { 108, new DateTime(2020, 11, 18, 5, 1, 50, 308, DateTimeKind.Local).AddTicks(6223), 77, new DateTime(2021, 12, 7, 0, 31, 24, 72, DateTimeKind.Local).AddTicks(6312), new DateTime(2020, 12, 11, 21, 39, 14, 177, DateTimeKind.Local).AddTicks(7395), 5, 61, "occaecati" },
                    { 19, new DateTime(2021, 2, 8, 7, 16, 13, 10, DateTimeKind.Local).AddTicks(9162), 33, new DateTime(2022, 4, 25, 3, 39, 16, 952, DateTimeKind.Local).AddTicks(834), new DateTime(2020, 11, 3, 7, 56, 29, 290, DateTimeKind.Local).AddTicks(2703), 5, 15, "Totam modi laudantium.\nAmet dolores et quia sint cum molestiae.\nSequi facere quis atque exercitationem necessitatibus ut.\nEt perferendis qui ipsum quo.\nPariatur animi incidunt blanditiis omnis dolorem quisquam tenetur." },
                    { 20, new DateTime(2020, 12, 14, 19, 5, 18, 21, DateTimeKind.Local).AddTicks(6617), 53, new DateTime(2022, 3, 19, 7, 27, 46, 355, DateTimeKind.Local).AddTicks(8734), new DateTime(2021, 6, 27, 2, 25, 55, 579, DateTimeKind.Local).AddTicks(8266), 2, 15, "quis" },
                    { 103, new DateTime(2021, 8, 17, 16, 51, 26, 512, DateTimeKind.Local).AddTicks(1542), 74, new DateTime(2022, 5, 24, 14, 15, 6, 312, DateTimeKind.Local).AddTicks(5795), new DateTime(2020, 11, 8, 9, 9, 9, 14, DateTimeKind.Local).AddTicks(9972), 5, 15, "deleniti" },
                    { 147, new DateTime(2021, 1, 3, 5, 38, 25, 867, DateTimeKind.Local).AddTicks(8504), 123, new DateTime(2022, 2, 27, 12, 21, 4, 268, DateTimeKind.Local).AddTicks(7140), new DateTime(2020, 12, 13, 5, 17, 11, 842, DateTimeKind.Local).AddTicks(8577), 3, 15, "Et voluptate fuga quibusdam et nam quasi consectetur repellendus distinctio." },
                    { 175, new DateTime(2021, 2, 28, 17, 42, 7, 870, DateTimeKind.Local).AddTicks(1998), 115, new DateTime(2022, 4, 23, 15, 22, 48, 109, DateTimeKind.Local).AddTicks(7500), new DateTime(2021, 1, 15, 18, 37, 41, 401, DateTimeKind.Local).AddTicks(4287), 5, 15, "dicta" },
                    { 183, new DateTime(2021, 7, 16, 12, 40, 55, 452, DateTimeKind.Local).AddTicks(4131), 63, new DateTime(2021, 11, 18, 10, 56, 5, 589, DateTimeKind.Local).AddTicks(5277), new DateTime(2020, 9, 14, 21, 14, 11, 439, DateTimeKind.Local).AddTicks(4844), 4, 15, "officiis" },
                    { 88, new DateTime(2021, 1, 3, 23, 7, 55, 727, DateTimeKind.Local).AddTicks(3275), 95, new DateTime(2021, 12, 22, 3, 56, 48, 440, DateTimeKind.Local).AddTicks(4469), new DateTime(2020, 10, 11, 10, 22, 51, 468, DateTimeKind.Local).AddTicks(2689), 1, 4, "quasi" },
                    { 125, new DateTime(2021, 1, 21, 21, 48, 28, 885, DateTimeKind.Local).AddTicks(7786), 60, new DateTime(2022, 6, 13, 18, 34, 35, 217, DateTimeKind.Local).AddTicks(7987), new DateTime(2020, 11, 14, 20, 8, 43, 376, DateTimeKind.Local).AddTicks(3412), 4, 4, "Ipsam eligendi quidem illo est at dolores quos.\nIllum cumque nulla veritatis repellendus consequatur quo neque qui et.\nAut earum accusantium harum.\nEt autem totam consequatur qui qui." },
                    { 148, new DateTime(2020, 12, 29, 9, 50, 6, 612, DateTimeKind.Local).AddTicks(1765), 84, new DateTime(2021, 10, 28, 10, 1, 47, 431, DateTimeKind.Local).AddTicks(1116), new DateTime(2021, 3, 9, 12, 13, 3, 678, DateTimeKind.Local).AddTicks(3142), 2, 4, "Exercitationem est nobis laboriosam dolor temporibus. Earum qui in autem quaerat consectetur. Amet sit esse soluta et." },
                    { 154, new DateTime(2021, 6, 22, 11, 17, 36, 839, DateTimeKind.Local).AddTicks(780), 30, new DateTime(2022, 1, 1, 17, 26, 53, 807, DateTimeKind.Local).AddTicks(3845), new DateTime(2021, 2, 8, 21, 37, 20, 110, DateTimeKind.Local).AddTicks(4774), 4, 4, "quos" },
                    { 94, new DateTime(2020, 9, 3, 12, 56, 45, 925, DateTimeKind.Local).AddTicks(1104), 52, new DateTime(2022, 3, 10, 18, 14, 30, 83, DateTimeKind.Local).AddTicks(3960), new DateTime(2021, 7, 7, 19, 6, 56, 187, DateTimeKind.Local).AddTicks(3131), 5, 17, "Nesciunt odio earum quo." },
                    { 38, new DateTime(2020, 8, 22, 2, 28, 52, 255, DateTimeKind.Local).AddTicks(1198), 150, new DateTime(2021, 9, 15, 0, 42, 14, 132, DateTimeKind.Local).AddTicks(9952), new DateTime(2021, 6, 12, 18, 19, 30, 38, DateTimeKind.Local).AddTicks(5916), 5, 71, "Error rerum consequatur aperiam ea. Aut eaque dignissimos autem amet. Dolorum quas consequatur iure nobis dolorem ab. Cupiditate tenetur quas voluptatem dolor sapiente consectetur assumenda. Quam impedit porro libero dolorem iure atque sit officiis." },
                    { 90, new DateTime(2020, 9, 29, 13, 7, 40, 368, DateTimeKind.Local).AddTicks(1559), 23, new DateTime(2022, 8, 4, 0, 2, 31, 394, DateTimeKind.Local).AddTicks(6106), new DateTime(2020, 12, 6, 4, 0, 44, 304, DateTimeKind.Local).AddTicks(4973), 1, 73, "aut" },
                    { 42, new DateTime(2021, 2, 23, 18, 17, 31, 672, DateTimeKind.Local).AddTicks(1205), 95, new DateTime(2022, 6, 3, 20, 49, 16, 825, DateTimeKind.Local).AddTicks(5180), new DateTime(2021, 2, 10, 18, 13, 13, 903, DateTimeKind.Local).AddTicks(6961), 4, 68, "suscipit" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 45, new DateTime(2021, 7, 23, 21, 8, 59, 562, DateTimeKind.Local).AddTicks(2934), 26, new DateTime(2021, 10, 7, 21, 10, 52, 814, DateTimeKind.Local).AddTicks(8719), new DateTime(2020, 12, 15, 10, 35, 56, 713, DateTimeKind.Local).AddTicks(1797), 4, 72, "Est necessitatibus magnam quia nihil est ut qui harum harum.\nAb itaque eligendi dolor omnis magnam aut error dicta.\nDeserunt aut beatae nesciunt." },
                    { 131, new DateTime(2020, 9, 30, 15, 53, 47, 644, DateTimeKind.Local).AddTicks(3063), 35, new DateTime(2022, 3, 17, 4, 43, 21, 539, DateTimeKind.Local).AddTicks(1649), new DateTime(2021, 5, 31, 1, 34, 2, 852, DateTimeKind.Local).AddTicks(4280), 5, 72, "Ea quam minus saepe fuga iste.\nNeque excepturi ut commodi commodi dolore laudantium corporis ipsam maxime.\nIllum voluptatem nam aperiam dignissimos quas natus cum et.\nMaxime quis doloribus ducimus cumque quis nihil omnis quia suscipit.\nMolestiae ut possimus libero qui." },
                    { 166, new DateTime(2021, 6, 14, 13, 25, 31, 897, DateTimeKind.Local).AddTicks(1925), 46, new DateTime(2022, 7, 17, 13, 17, 46, 588, DateTimeKind.Local).AddTicks(8774), new DateTime(2021, 4, 28, 20, 44, 1, 294, DateTimeKind.Local).AddTicks(1941), 2, 72, "Qui ipsa qui ut est officiis sit corporis.\nIusto et aut eveniet et error aut odio maxime occaecati." },
                    { 176, new DateTime(2021, 5, 7, 9, 2, 30, 589, DateTimeKind.Local).AddTicks(6628), 38, new DateTime(2022, 7, 20, 6, 23, 34, 717, DateTimeKind.Local).AddTicks(3056), new DateTime(2021, 2, 10, 2, 5, 55, 741, DateTimeKind.Local).AddTicks(6020), 1, 72, "Soluta voluptas velit est magni adipisci aut nulla quaerat provident." },
                    { 22, new DateTime(2021, 4, 29, 15, 0, 34, 478, DateTimeKind.Local).AddTicks(2544), 145, new DateTime(2021, 9, 11, 18, 28, 40, 780, DateTimeKind.Local).AddTicks(814), new DateTime(2021, 4, 15, 0, 51, 4, 127, DateTimeKind.Local).AddTicks(7832), 3, 27, "Atque veniam voluptatem necessitatibus veritatis repudiandae quaerat fugiat sed. Culpa quibusdam architecto distinctio. Ut veritatis laboriosam aliquam officia ea. Harum in aut modi ipsa maxime." },
                    { 27, new DateTime(2021, 5, 16, 20, 14, 33, 761, DateTimeKind.Local).AddTicks(2765), 136, new DateTime(2021, 10, 16, 17, 31, 1, 332, DateTimeKind.Local).AddTicks(6647), new DateTime(2021, 3, 28, 8, 37, 4, 373, DateTimeKind.Local).AddTicks(4070), 4, 27, "Nemo eos similique voluptas corrupti et dolorem error pariatur." },
                    { 72, new DateTime(2020, 10, 16, 9, 44, 20, 207, DateTimeKind.Local).AddTicks(1580), 111, new DateTime(2022, 2, 7, 1, 12, 18, 359, DateTimeKind.Local).AddTicks(9845), new DateTime(2021, 2, 23, 2, 48, 46, 116, DateTimeKind.Local).AddTicks(802), 1, 27, "Et adipisci sed praesentium blanditiis culpa a autem molestias voluptas. Tempore sit explicabo facere. Quia temporibus vel nisi dolorum quibusdam ut." },
                    { 124, new DateTime(2021, 4, 8, 23, 26, 11, 942, DateTimeKind.Local).AddTicks(4913), 106, new DateTime(2021, 10, 7, 14, 36, 36, 69, DateTimeKind.Local).AddTicks(8135), new DateTime(2021, 3, 20, 19, 34, 25, 157, DateTimeKind.Local).AddTicks(8503), 2, 27, "Maiores ducimus inventore necessitatibus eum. Nesciunt repellendus id quasi quia recusandae architecto. Occaecati quo facere iusto. Dolorem iure facere similique sed et facere aut." },
                    { 127, new DateTime(2021, 7, 16, 1, 0, 49, 986, DateTimeKind.Local).AddTicks(7671), 36, new DateTime(2021, 9, 18, 23, 57, 34, 85, DateTimeKind.Local).AddTicks(6119), new DateTime(2021, 6, 30, 10, 23, 19, 952, DateTimeKind.Local).AddTicks(8686), 4, 27, "sequi" },
                    { 5, new DateTime(2020, 8, 24, 18, 49, 15, 137, DateTimeKind.Local).AddTicks(1611), 18, new DateTime(2021, 12, 15, 21, 37, 17, 936, DateTimeKind.Local).AddTicks(9959), new DateTime(2021, 2, 2, 16, 47, 6, 169, DateTimeKind.Local).AddTicks(9120), 5, 37, "porro" },
                    { 18, new DateTime(2021, 3, 30, 18, 5, 32, 638, DateTimeKind.Local).AddTicks(8388), 92, new DateTime(2022, 1, 9, 4, 35, 58, 683, DateTimeKind.Local).AddTicks(158), new DateTime(2020, 8, 28, 13, 26, 36, 976, DateTimeKind.Local).AddTicks(5608), 4, 37, "et" },
                    { 30, new DateTime(2021, 7, 25, 23, 10, 10, 127, DateTimeKind.Local).AddTicks(4615), 99, new DateTime(2022, 2, 15, 0, 46, 31, 875, DateTimeKind.Local).AddTicks(5081), new DateTime(2020, 9, 17, 3, 9, 27, 559, DateTimeKind.Local).AddTicks(5127), 3, 37, "Deserunt vero reiciendis numquam omnis omnis non ipsam." },
                    { 133, new DateTime(2020, 11, 12, 13, 50, 49, 879, DateTimeKind.Local).AddTicks(8437), 62, new DateTime(2022, 8, 13, 16, 43, 12, 408, DateTimeKind.Local).AddTicks(8275), new DateTime(2021, 2, 1, 1, 55, 7, 901, DateTimeKind.Local).AddTicks(2390), 2, 37, "Dolore repudiandae distinctio officiis." },
                    { 197, new DateTime(2020, 12, 1, 6, 34, 16, 240, DateTimeKind.Local).AddTicks(7671), 102, new DateTime(2021, 10, 16, 4, 5, 30, 518, DateTimeKind.Local).AddTicks(3900), new DateTime(2020, 9, 11, 22, 44, 17, 427, DateTimeKind.Local).AddTicks(5045), 5, 37, "Consequatur sunt alias beatae est in molestiae velit aut." },
                    { 9, new DateTime(2021, 3, 31, 6, 16, 58, 808, DateTimeKind.Local).AddTicks(636), 61, new DateTime(2022, 2, 4, 14, 21, 30, 643, DateTimeKind.Local).AddTicks(5546), new DateTime(2020, 11, 30, 8, 56, 15, 570, DateTimeKind.Local).AddTicks(4368), 5, 79, "Ea voluptatem tempora occaecati voluptatem enim molestiae aut eum.\nOptio ut ipsa omnis sed adipisci vitae inventore.\nExercitationem provident aspernatur corrupti rerum sit error ipsam atque.\nUt et et magnam corporis blanditiis atque.\nPlaceat alias est sint dolores." },
                    { 60, new DateTime(2020, 11, 3, 17, 56, 7, 52, DateTimeKind.Local).AddTicks(9859), 113, new DateTime(2022, 1, 21, 22, 33, 5, 492, DateTimeKind.Local).AddTicks(2087), new DateTime(2020, 12, 8, 17, 47, 52, 819, DateTimeKind.Local).AddTicks(7005), 1, 79, "Minus alias corporis commodi suscipit aliquid dolorum.\nNesciunt officia ullam temporibus dolorum doloremque eligendi.\nCupiditate rerum nihil perspiciatis provident et.\nAspernatur doloribus ex molestias eum laudantium ipsa." },
                    { 81, new DateTime(2020, 9, 7, 17, 2, 32, 412, DateTimeKind.Local).AddTicks(1669), 138, new DateTime(2022, 7, 14, 15, 48, 36, 518, DateTimeKind.Local).AddTicks(9091), new DateTime(2021, 1, 14, 2, 5, 44, 912, DateTimeKind.Local).AddTicks(862), 3, 77, "Provident id qui quia nostrum.\nCum praesentium cupiditate provident est optio nemo." },
                    { 31, new DateTime(2021, 1, 13, 23, 25, 9, 330, DateTimeKind.Local).AddTicks(387), 25, new DateTime(2022, 1, 31, 17, 2, 15, 731, DateTimeKind.Local).AddTicks(4068), new DateTime(2021, 2, 20, 0, 13, 36, 844, DateTimeKind.Local).AddTicks(7888), 4, 10, "consequatur" },
                    { 146, new DateTime(2021, 6, 10, 15, 30, 12, 166, DateTimeKind.Local).AddTicks(673), 17, new DateTime(2022, 6, 7, 2, 39, 29, 942, DateTimeKind.Local).AddTicks(3579), new DateTime(2021, 4, 23, 11, 25, 21, 159, DateTimeKind.Local).AddTicks(853), 5, 10, "Ex ut consequuntur eos vel atque velit consequuntur quisquam.\nQui qui corporis nam.\nOdit ut placeat pariatur molestiae et error consequatur." },
                    { 174, new DateTime(2021, 6, 6, 6, 48, 54, 756, DateTimeKind.Local).AddTicks(8100), 117, new DateTime(2021, 10, 5, 12, 41, 11, 148, DateTimeKind.Local).AddTicks(6361), new DateTime(2020, 9, 20, 2, 32, 28, 21, DateTimeKind.Local).AddTicks(321), 2, 10, "et" },
                    { 13, new DateTime(2020, 12, 10, 5, 42, 44, 221, DateTimeKind.Local).AddTicks(9719), 94, new DateTime(2022, 1, 22, 11, 49, 24, 590, DateTimeKind.Local).AddTicks(8465), new DateTime(2020, 9, 2, 14, 8, 38, 7, DateTimeKind.Local).AddTicks(5794), 2, 68, "Id iure aut. Laudantium rerum necessitatibus incidunt sit consequatur id iusto neque. Illo autem consequatur occaecati." },
                    { 144, new DateTime(2021, 4, 2, 8, 35, 43, 135, DateTimeKind.Local).AddTicks(4469), 124, new DateTime(2022, 2, 11, 4, 4, 44, 78, DateTimeKind.Local).AddTicks(7928), new DateTime(2020, 8, 30, 3, 51, 46, 646, DateTimeKind.Local).AddTicks(6771), 3, 25, "repellat" },
                    { 40, new DateTime(2021, 3, 5, 11, 42, 21, 846, DateTimeKind.Local).AddTicks(9235), 32, new DateTime(2022, 2, 24, 2, 15, 43, 336, DateTimeKind.Local).AddTicks(86), new DateTime(2021, 7, 7, 4, 28, 5, 888, DateTimeKind.Local).AddTicks(7459), 1, 71, "Nam totam tenetur." },
                    { 86, new DateTime(2021, 2, 11, 5, 41, 2, 544, DateTimeKind.Local).AddTicks(6222), 150, new DateTime(2022, 3, 8, 1, 16, 58, 76, DateTimeKind.Local).AddTicks(3459), new DateTime(2020, 8, 31, 9, 8, 40, 849, DateTimeKind.Local).AddTicks(1345), 5, 71, "Enim voluptate perspiciatis nisi dolor quis voluptatem. Maxime ratione itaque aut occaecati ullam veniam. Sit repellendus earum culpa est quisquam nulla dolore labore mollitia. Sunt rem consequuntur exercitationem deserunt atque laudantium minima placeat autem. Minima unde rerum voluptas culpa. Adipisci quibusdam veniam." },
                    { 115, new DateTime(2020, 10, 19, 13, 17, 50, 522, DateTimeKind.Local).AddTicks(3453), 68, new DateTime(2021, 10, 12, 23, 59, 17, 201, DateTimeKind.Local).AddTicks(3223), new DateTime(2020, 11, 2, 4, 31, 33, 358, DateTimeKind.Local).AddTicks(1438), 5, 71, "Exercitationem esse animi dolores recusandae fuga quam molestiae ut aspernatur.\nAd occaecati ea omnis.\nSoluta et tempore rerum saepe excepturi eos.\nDolorem similique voluptatem." },
                    { 23, new DateTime(2020, 10, 16, 9, 59, 59, 625, DateTimeKind.Local).AddTicks(9847), 80, new DateTime(2022, 2, 21, 14, 59, 40, 45, DateTimeKind.Local).AddTicks(8309), new DateTime(2020, 10, 3, 1, 18, 51, 769, DateTimeKind.Local).AddTicks(6608), 1, 76, "Atque laborum tempora quia occaecati accusantium doloribus dignissimos.\nSequi inventore eaque sit unde.\nSunt cumque iusto.\nEt maxime dolor." },
                    { 32, new DateTime(2021, 7, 20, 4, 12, 2, 635, DateTimeKind.Local).AddTicks(4617), 82, new DateTime(2021, 11, 15, 3, 9, 5, 317, DateTimeKind.Local).AddTicks(1471), new DateTime(2021, 4, 9, 23, 35, 4, 277, DateTimeKind.Local).AddTicks(740), 2, 76, "Amet et ratione exercitationem quae id.\nEt omnis est quia.\nEt rerum amet a.\nAmet illum harum voluptatem qui adipisci assumenda cumque atque." },
                    { 57, new DateTime(2020, 8, 29, 4, 36, 59, 772, DateTimeKind.Local).AddTicks(834), 117, new DateTime(2022, 7, 3, 22, 36, 17, 659, DateTimeKind.Local).AddTicks(8132), new DateTime(2021, 2, 10, 9, 25, 5, 423, DateTimeKind.Local).AddTicks(6587), 4, 76, "Voluptatum sint officia laboriosam reiciendis." },
                    { 82, new DateTime(2021, 5, 10, 8, 49, 54, 649, DateTimeKind.Local).AddTicks(7694), 103, new DateTime(2022, 4, 30, 14, 6, 53, 71, DateTimeKind.Local).AddTicks(8719), new DateTime(2021, 4, 26, 22, 7, 8, 374, DateTimeKind.Local).AddTicks(9726), 2, 76, "Voluptate quibusdam illo.\nVoluptas asperiores deserunt sit vitae necessitatibus quaerat qui culpa consectetur.\nQuam nihil iusto sit aut quibusdam ex voluptas est voluptatum.\nIste voluptatem ipsum ut doloremque culpa et provident velit animi." },
                    { 102, new DateTime(2021, 5, 7, 13, 49, 49, 552, DateTimeKind.Local).AddTicks(2939), 39, new DateTime(2022, 2, 2, 23, 31, 46, 8, DateTimeKind.Local).AddTicks(3891), new DateTime(2021, 1, 20, 16, 44, 51, 245, DateTimeKind.Local).AddTicks(480), 5, 76, "Commodi eum aut voluptates." },
                    { 107, new DateTime(2020, 8, 28, 4, 30, 5, 636, DateTimeKind.Local).AddTicks(7445), 67, new DateTime(2022, 7, 10, 18, 51, 20, 651, DateTimeKind.Local).AddTicks(3146), new DateTime(2020, 12, 13, 22, 26, 37, 187, DateTimeKind.Local).AddTicks(2942), 2, 23, "Earum aut rem optio." },
                    { 140, new DateTime(2020, 10, 27, 20, 53, 39, 253, DateTimeKind.Local).AddTicks(6744), 65, new DateTime(2021, 10, 7, 18, 52, 4, 298, DateTimeKind.Local).AddTicks(2726), new DateTime(2020, 10, 25, 12, 2, 56, 266, DateTimeKind.Local).AddTicks(6137), 2, 23, "Tenetur quasi non. Voluptas quisquam earum consequuntur modi rerum labore dolorem tenetur iusto. Similique esse accusantium laboriosam quas rerum." },
                    { 61, new DateTime(2021, 1, 13, 8, 47, 50, 757, DateTimeKind.Local).AddTicks(218), 12, new DateTime(2022, 2, 18, 8, 59, 3, 477, DateTimeKind.Local).AddTicks(949), new DateTime(2020, 12, 6, 0, 5, 47, 215, DateTimeKind.Local).AddTicks(2226), 1, 16, "Sunt et ut. Nulla ut autem similique rerum qui dicta. Doloremque amet ut alias et totam sed autem reiciendis nulla. Sequi sed et est ex officiis consequuntur harum similique. Saepe suscipit quidem et veniam eligendi fugiat laborum. Fuga aspernatur vel quasi possimus quas non maxime eaque." },
                    { 6, new DateTime(2021, 2, 18, 22, 43, 44, 122, DateTimeKind.Local).AddTicks(6022), 76, new DateTime(2021, 10, 5, 6, 47, 19, 405, DateTimeKind.Local).AddTicks(3520), new DateTime(2021, 6, 29, 19, 54, 16, 527, DateTimeKind.Local).AddTicks(6994), 4, 39, "Non et et quo expedita odio quam corporis quis." },
                    { 29, new DateTime(2020, 12, 22, 22, 27, 32, 965, DateTimeKind.Local).AddTicks(4931), 12, new DateTime(2022, 5, 2, 1, 25, 7, 701, DateTimeKind.Local).AddTicks(3133), new DateTime(2020, 10, 1, 16, 27, 52, 704, DateTimeKind.Local).AddTicks(9081), 5, 39, "Sit sunt odio accusamus maiores. Quis velit corporis dolores adipisci ab ipsam reiciendis. Facilis vel blanditiis minima. Alias quia quia. Non ducimus veniam dolor adipisci quo facilis quod rerum quia. Minus consequuntur reiciendis ut." },
                    { 73, new DateTime(2021, 7, 31, 6, 51, 57, 712, DateTimeKind.Local).AddTicks(254), 68, new DateTime(2022, 4, 11, 5, 5, 18, 849, DateTimeKind.Local).AddTicks(70), new DateTime(2021, 6, 21, 16, 48, 13, 254, DateTimeKind.Local).AddTicks(6687), 1, 39, "odio" },
                    { 98, new DateTime(2020, 8, 28, 13, 3, 21, 131, DateTimeKind.Local).AddTicks(1358), 8, new DateTime(2021, 10, 17, 1, 44, 32, 535, DateTimeKind.Local).AddTicks(964), new DateTime(2020, 12, 8, 9, 26, 42, 725, DateTimeKind.Local).AddTicks(7158), 3, 39, "qui" },
                    { 123, new DateTime(2020, 11, 7, 18, 46, 26, 451, DateTimeKind.Local).AddTicks(4736), 75, new DateTime(2022, 3, 18, 12, 57, 43, 508, DateTimeKind.Local).AddTicks(1452), new DateTime(2021, 8, 13, 4, 6, 26, 640, DateTimeKind.Local).AddTicks(1537), 2, 39, "facere" },
                    { 145, new DateTime(2020, 11, 9, 15, 3, 44, 636, DateTimeKind.Local).AddTicks(1564), 88, new DateTime(2022, 7, 23, 13, 28, 7, 400, DateTimeKind.Local).AddTicks(468), new DateTime(2021, 1, 7, 21, 11, 24, 370, DateTimeKind.Local).AddTicks(1471), 3, 39, "Accusantium iusto suscipit tempore molestiae sequi ullam.\nQuia similique enim quasi placeat in cum quidem ab." },
                    { 142, new DateTime(2020, 9, 3, 22, 59, 36, 429, DateTimeKind.Local).AddTicks(7200), 97, new DateTime(2022, 2, 14, 3, 29, 37, 391, DateTimeKind.Local).AddTicks(5048), new DateTime(2021, 6, 6, 6, 8, 38, 103, DateTimeKind.Local).AddTicks(4278), 3, 64, "Architecto qui aut repellat inventore incidunt maiores recusandae est voluptatum.\nMaxime porro cupiditate.\nError qui voluptatem quaerat autem perspiciatis.\nMolestiae molestiae deleniti aperiam quibusdam et voluptatem.\nQuia quisquam hic molestias." },
                    { 167, new DateTime(2020, 9, 18, 8, 4, 34, 455, DateTimeKind.Local).AddTicks(6440), 122, new DateTime(2021, 10, 7, 15, 26, 27, 674, DateTimeKind.Local).AddTicks(2332), new DateTime(2021, 4, 10, 14, 50, 7, 2, DateTimeKind.Local).AddTicks(2930), 4, 64, "Aut consequatur autem magni inventore. Corporis dicta ullam eos. Doloremque ipsum inventore alias rerum est cupiditate adipisci nisi eveniet. Et tenetur amet itaque nisi atque quod. Quia maxime sint et exercitationem unde rerum libero tenetur. Magni deleniti consequatur ullam possimus quos consequatur dolore." },
                    { 173, new DateTime(2020, 12, 16, 17, 27, 34, 947, DateTimeKind.Local).AddTicks(6379), 149, new DateTime(2022, 5, 16, 17, 32, 16, 225, DateTimeKind.Local).AddTicks(8591), new DateTime(2021, 7, 23, 15, 7, 27, 581, DateTimeKind.Local).AddTicks(3297), 4, 64, "Ipsa quia aut quam quo quidem sunt repudiandae sequi sed.\nEveniet quia nesciunt qui.\nNihil quia totam magni rem quis eos voluptatem et.\nRerum cupiditate veniam tenetur et inventore sed aperiam hic qui.\nLabore officia temporibus quis et unde nam ea.\nEt placeat placeat sequi possimus et numquam vero et." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 186, new DateTime(2021, 4, 27, 4, 51, 4, 686, DateTimeKind.Local).AddTicks(6560), 19, new DateTime(2021, 10, 29, 17, 33, 57, 118, DateTimeKind.Local).AddTicks(3531), new DateTime(2021, 5, 3, 19, 3, 55, 543, DateTimeKind.Local).AddTicks(4282), 4, 64, "Voluptatem aut iure atque est voluptatem consequuntur et deleniti. Rem alias ut. Natus consequatur et praesentium itaque sed quaerat corrupti et vero. Quia aut laborum voluptatem. Eos debitis repellendus sunt. Aut quas recusandae dolor eos." },
                    { 93, new DateTime(2020, 9, 22, 13, 34, 56, 638, DateTimeKind.Local).AddTicks(5616), 143, new DateTime(2022, 4, 24, 19, 50, 51, 445, DateTimeKind.Local).AddTicks(7086), new DateTime(2021, 5, 14, 17, 36, 3, 573, DateTimeKind.Local).AddTicks(8615), 5, 66, "Omnis aspernatur nulla placeat neque architecto. Tempora ut enim quibusdam vel ut aperiam eaque. Dolor quia ut deserunt ea numquam. In rerum sunt eveniet iusto numquam consectetur tempora aut. Impedit repudiandae odit nihil laboriosam facere fuga necessitatibus." },
                    { 113, new DateTime(2020, 9, 11, 6, 2, 18, 998, DateTimeKind.Local).AddTicks(3961), 49, new DateTime(2022, 1, 16, 21, 59, 10, 83, DateTimeKind.Local).AddTicks(7668), new DateTime(2021, 2, 15, 14, 4, 43, 759, DateTimeKind.Local).AddTicks(1770), 2, 66, "sit" },
                    { 141, new DateTime(2021, 6, 9, 23, 35, 36, 465, DateTimeKind.Local).AddTicks(1157), 85, new DateTime(2022, 3, 20, 14, 41, 39, 509, DateTimeKind.Local).AddTicks(2024), new DateTime(2020, 10, 13, 20, 43, 9, 54, DateTimeKind.Local).AddTicks(2495), 1, 66, "facilis" },
                    { 181, new DateTime(2021, 1, 3, 21, 15, 25, 814, DateTimeKind.Local).AddTicks(1099), 41, new DateTime(2022, 3, 7, 20, 40, 8, 899, DateTimeKind.Local).AddTicks(1818), new DateTime(2020, 11, 1, 17, 9, 37, 970, DateTimeKind.Local).AddTicks(1798), 2, 18, "Et doloremque esse laboriosam." },
                    { 138, new DateTime(2020, 9, 17, 13, 20, 31, 191, DateTimeKind.Local).AddTicks(2673), 19, new DateTime(2022, 7, 31, 13, 28, 15, 451, DateTimeKind.Local).AddTicks(3162), new DateTime(2020, 10, 7, 10, 34, 14, 757, DateTimeKind.Local).AddTicks(5486), 5, 18, "Voluptas vitae soluta commodi consectetur ut. Et a quia qui. Harum aut quasi illum perspiciatis rerum." },
                    { 191, new DateTime(2020, 8, 20, 13, 52, 35, 755, DateTimeKind.Local).AddTicks(8570), 8, new DateTime(2021, 9, 26, 13, 43, 53, 684, DateTimeKind.Local).AddTicks(3211), new DateTime(2020, 10, 20, 20, 26, 44, 157, DateTimeKind.Local).AddTicks(4123), 5, 38, "Ratione omnis nobis voluptate voluptas expedita autem qui dolorem.\nQuia reiciendis id.\nSed minus earum sint est et eligendi id sit.\nEt odio nihil asperiores saepe sed dicta tenetur.\nSit at id ab." },
                    { 162, new DateTime(2021, 1, 7, 5, 32, 31, 540, DateTimeKind.Local).AddTicks(8732), 10, new DateTime(2022, 8, 5, 3, 45, 5, 112, DateTimeKind.Local).AddTicks(9554), new DateTime(2021, 8, 17, 10, 43, 39, 413, DateTimeKind.Local).AddTicks(1154), 4, 38, "Voluptatem dicta aperiam facere accusantium fugiat et.\nQuod quisquam fugiat reiciendis cumque dolores est hic inventore.\nCommodi quidem qui ex repellat harum.\nEst ducimus eos iste." },
                    { 70, new DateTime(2020, 12, 21, 9, 32, 42, 378, DateTimeKind.Local).AddTicks(5589), 28, new DateTime(2022, 8, 15, 3, 23, 24, 313, DateTimeKind.Local).AddTicks(7058), new DateTime(2021, 1, 11, 20, 48, 29, 779, DateTimeKind.Local).AddTicks(3693), 1, 24, "Voluptatibus necessitatibus reiciendis." },
                    { 83, new DateTime(2021, 1, 26, 21, 6, 16, 202, DateTimeKind.Local).AddTicks(2787), 71, new DateTime(2021, 9, 5, 2, 25, 6, 755, DateTimeKind.Local).AddTicks(4566), new DateTime(2021, 6, 4, 12, 57, 56, 112, DateTimeKind.Local).AddTicks(8323), 3, 24, "Odio atque commodi in molestiae quos quia odit corrupti." },
                    { 106, new DateTime(2021, 5, 6, 22, 22, 27, 773, DateTimeKind.Local).AddTicks(8952), 74, new DateTime(2022, 1, 4, 14, 30, 11, 512, DateTimeKind.Local).AddTicks(9381), new DateTime(2021, 6, 8, 16, 53, 31, 524, DateTimeKind.Local).AddTicks(6322), 1, 24, "ipsam" },
                    { 120, new DateTime(2020, 11, 25, 4, 36, 16, 922, DateTimeKind.Local).AddTicks(3425), 140, new DateTime(2021, 9, 20, 9, 34, 26, 297, DateTimeKind.Local).AddTicks(1381), new DateTime(2020, 11, 24, 13, 28, 14, 267, DateTimeKind.Local).AddTicks(7255), 5, 24, "labore" },
                    { 165, new DateTime(2021, 7, 14, 18, 3, 16, 230, DateTimeKind.Local).AddTicks(4344), 107, new DateTime(2022, 2, 1, 18, 35, 38, 570, DateTimeKind.Local).AddTicks(5778), new DateTime(2020, 11, 7, 0, 31, 32, 227, DateTimeKind.Local).AddTicks(6055), 4, 24, "Quisquam quisquam minus dolores voluptas quia debitis cumque. Rerum soluta cum ut. Ea et eum quos sed." },
                    { 16, new DateTime(2021, 3, 11, 15, 25, 36, 722, DateTimeKind.Local).AddTicks(3285), 41, new DateTime(2021, 10, 4, 2, 48, 27, 647, DateTimeKind.Local).AddTicks(960), new DateTime(2020, 12, 25, 2, 2, 21, 342, DateTimeKind.Local).AddTicks(8864), 5, 87, "Doloribus dolorem neque vel saepe vitae dignissimos molestias dolorum provident. Vitae provident veniam optio velit delectus distinctio dignissimos autem. Nobis earum saepe blanditiis est accusamus quaerat necessitatibus sed. Est labore omnis repudiandae debitis voluptatibus ut tempore." },
                    { 97, new DateTime(2020, 9, 2, 23, 4, 24, 797, DateTimeKind.Local).AddTicks(5298), 75, new DateTime(2022, 7, 13, 22, 31, 8, 34, DateTimeKind.Local).AddTicks(3542), new DateTime(2020, 10, 31, 6, 36, 24, 895, DateTimeKind.Local).AddTicks(2240), 4, 87, "Cum ducimus expedita necessitatibus omnis id. Mollitia voluptate corporis nostrum sit asperiores sunt aut magnam expedita. Ad facilis facere tenetur impedit perferendis a." },
                    { 11, new DateTime(2020, 10, 28, 3, 1, 17, 642, DateTimeKind.Local).AddTicks(4065), 144, new DateTime(2022, 7, 9, 4, 10, 22, 427, DateTimeKind.Local).AddTicks(4949), new DateTime(2021, 2, 6, 14, 47, 23, 773, DateTimeKind.Local).AddTicks(2444), 1, 51, "Aspernatur quisquam officiis sit inventore vitae autem in. Est quia non libero excepturi eos minus deserunt. Quia molestiae ut voluptatem illum. Natus magnam illum aut officiis ut et eligendi. Sequi nihil fuga recusandae quam amet. Rerum recusandae officia saepe esse aliquam vitae odio." },
                    { 46, new DateTime(2021, 3, 26, 3, 2, 13, 265, DateTimeKind.Local).AddTicks(7743), 105, new DateTime(2021, 11, 28, 14, 10, 48, 908, DateTimeKind.Local).AddTicks(8398), new DateTime(2021, 1, 3, 17, 19, 54, 329, DateTimeKind.Local).AddTicks(6228), 5, 51, "Voluptas labore ex rem maiores dolor natus fugiat. Earum magni enim quibusdam tempora pariatur assumenda numquam iusto aut. Soluta perferendis aut ipsum. Ex recusandae omnis et. Sint perferendis modi enim at itaque adipisci dolor doloribus. Cupiditate iure fuga itaque hic nulla enim dignissimos quis." },
                    { 170, new DateTime(2021, 6, 11, 13, 23, 14, 85, DateTimeKind.Local).AddTicks(4154), 40, new DateTime(2022, 6, 18, 6, 49, 44, 816, DateTimeKind.Local).AddTicks(8056), new DateTime(2021, 4, 17, 8, 18, 13, 333, DateTimeKind.Local).AddTicks(7383), 1, 40, "Rerum dolore sit autem aliquam tenetur non provident dolore. Est aut ut quas exercitationem minus placeat et minima. Aliquam nobis ipsam dolor est odit laboriosam. Neque est voluptates laborum aliquam ad. Deleniti et maiores illo." },
                    { 96, new DateTime(2020, 11, 16, 2, 51, 3, 235, DateTimeKind.Local).AddTicks(3965), 103, new DateTime(2021, 9, 19, 18, 42, 25, 706, DateTimeKind.Local).AddTicks(5772), new DateTime(2021, 5, 5, 16, 50, 37, 353, DateTimeKind.Local).AddTicks(2589), 2, 42, "Aut dignissimos quis laborum nihil blanditiis tenetur quasi fuga aut.\nRem eius illo." },
                    { 118, new DateTime(2020, 12, 8, 13, 29, 6, 887, DateTimeKind.Local).AddTicks(6937), 112, new DateTime(2021, 11, 22, 3, 50, 17, 468, DateTimeKind.Local).AddTicks(6127), new DateTime(2021, 4, 8, 2, 1, 48, 106, DateTimeKind.Local).AddTicks(2489), 5, 80, "In quia fugit aut consequatur soluta odit quia.\nEt dicta quam exercitationem amet.\nPlaceat at quis doloribus consequatur qui illum molestiae iure optio." },
                    { 47, new DateTime(2020, 12, 29, 6, 31, 44, 472, DateTimeKind.Local).AddTicks(7734), 11, new DateTime(2022, 1, 7, 21, 24, 39, 154, DateTimeKind.Local).AddTicks(3288), new DateTime(2021, 5, 3, 7, 38, 25, 86, DateTimeKind.Local).AddTicks(9665), 2, 14, "Nemo harum pariatur et. Ipsum accusantium sed sunt. Quis repudiandae in et dignissimos voluptas." },
                    { 77, new DateTime(2021, 7, 7, 11, 39, 55, 51, DateTimeKind.Local).AddTicks(5240), 65, new DateTime(2021, 10, 18, 22, 25, 21, 868, DateTimeKind.Local).AddTicks(2048), new DateTime(2021, 1, 2, 17, 0, 22, 986, DateTimeKind.Local).AddTicks(3491), 5, 14, "Consequatur quam nostrum illum adipisci harum eaque aut dolores iusto. Non porro tempore rerum accusantium beatae officiis ipsum recusandae. Porro laboriosam iusto sint voluptatibus accusamus voluptatibus eligendi cum. Perferendis adipisci error harum. Ut eligendi officia excepturi. Voluptatem sint natus." },
                    { 92, new DateTime(2021, 5, 22, 6, 10, 39, 894, DateTimeKind.Local).AddTicks(7754), 84, new DateTime(2021, 11, 19, 9, 51, 34, 804, DateTimeKind.Local).AddTicks(3025), new DateTime(2021, 3, 3, 18, 55, 21, 273, DateTimeKind.Local).AddTicks(5768), 1, 14, "Et libero officiis eaque recusandae voluptatem corrupti autem. Voluptas rem sit ex eligendi est velit nostrum. Sit dolor est quia ut sunt repudiandae cumque iste. Neque asperiores placeat officia." },
                    { 152, new DateTime(2021, 6, 24, 18, 43, 42, 821, DateTimeKind.Local).AddTicks(8489), 37, new DateTime(2022, 5, 10, 15, 21, 59, 129, DateTimeKind.Local).AddTicks(9038), new DateTime(2021, 1, 21, 13, 5, 10, 69, DateTimeKind.Local).AddTicks(3355), 2, 14, "et" },
                    { 169, new DateTime(2021, 3, 1, 18, 32, 18, 654, DateTimeKind.Local).AddTicks(4440), 36, new DateTime(2021, 9, 29, 20, 18, 26, 444, DateTimeKind.Local).AddTicks(5348), new DateTime(2021, 7, 30, 21, 22, 30, 874, DateTimeKind.Local).AddTicks(5780), 2, 14, "Voluptatem sunt non numquam esse. Dolorum velit optio recusandae explicabo similique iure et in. Nemo natus aut aut et est quo dolor nemo eos. Consequatur excepturi vel possimus atque." },
                    { 59, new DateTime(2021, 6, 10, 2, 58, 27, 43, DateTimeKind.Local).AddTicks(3905), 84, new DateTime(2022, 1, 18, 22, 5, 49, 829, DateTimeKind.Local).AddTicks(9874), new DateTime(2020, 9, 17, 14, 21, 29, 70, DateTimeKind.Local).AddTicks(473), 5, 35, "Cupiditate cupiditate maxime iusto similique neque." },
                    { 89, new DateTime(2021, 4, 30, 6, 38, 45, 912, DateTimeKind.Local).AddTicks(4844), 28, new DateTime(2022, 4, 26, 3, 40, 57, 373, DateTimeKind.Local).AddTicks(54), new DateTime(2021, 1, 16, 19, 23, 59, 366, DateTimeKind.Local).AddTicks(2676), 2, 35, "Molestias reprehenderit quidem aut qui voluptas illo odio ipsam velit.\nSint magni voluptatum mollitia." },
                    { 109, new DateTime(2021, 5, 5, 14, 47, 24, 744, DateTimeKind.Local).AddTicks(8953), 68, new DateTime(2022, 7, 4, 18, 24, 36, 173, DateTimeKind.Local).AddTicks(3170), new DateTime(2020, 10, 3, 23, 15, 42, 910, DateTimeKind.Local).AddTicks(3274), 5, 35, "Quasi non accusantium adipisci sequi quia et animi qui. Ex ipsa suscipit voluptatem. Eos vel hic et illo. Repudiandae dicta mollitia. Similique animi necessitatibus officiis omnis consequatur eius aut." },
                    { 66, new DateTime(2021, 7, 30, 13, 14, 21, 891, DateTimeKind.Local).AddTicks(8760), 80, new DateTime(2022, 7, 29, 1, 51, 2, 530, DateTimeKind.Local).AddTicks(5378), new DateTime(2020, 10, 6, 9, 8, 29, 859, DateTimeKind.Local).AddTicks(9982), 5, 29, "iste" },
                    { 50, new DateTime(2020, 9, 5, 6, 47, 20, 393, DateTimeKind.Local).AddTicks(9497), 90, new DateTime(2022, 5, 4, 2, 57, 54, 458, DateTimeKind.Local).AddTicks(6770), new DateTime(2021, 2, 7, 1, 43, 21, 912, DateTimeKind.Local).AddTicks(5042), 1, 38, "Quasi autem qui amet quo consequatur doloremque et et. Delectus voluptatibus unde ea. Et doloribus iure et provident. Nisi quia error. Dicta reprehenderit voluptates vitae itaque sequi reprehenderit similique corporis esse. Iusto asperiores et." },
                    { 180, new DateTime(2021, 7, 3, 21, 3, 18, 296, DateTimeKind.Local).AddTicks(3358), 122, new DateTime(2022, 6, 11, 23, 0, 18, 689, DateTimeKind.Local).AddTicks(3239), new DateTime(2020, 8, 18, 14, 46, 1, 139, DateTimeKind.Local).AddTicks(8127), 5, 80, "occaecati" },
                    { 155, new DateTime(2021, 6, 24, 0, 11, 14, 398, DateTimeKind.Local).AddTicks(1661), 32, new DateTime(2022, 8, 7, 3, 19, 24, 974, DateTimeKind.Local).AddTicks(1101), new DateTime(2021, 5, 29, 7, 3, 58, 546, DateTimeKind.Local).AddTicks(3766), 3, 42, "Saepe totam omnis eius id ipsam." }
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
