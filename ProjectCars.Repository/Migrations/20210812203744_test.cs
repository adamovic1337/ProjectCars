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
                    { 1, "Eritrea" },
                    { 111, "Guinea-Bissau" },
                    { 112, "Nepal" },
                    { 114, "Isle of Man" },
                    { 115, "Russian Federation" },
                    { 116, "Republic of Korea" },
                    { 118, "China" },
                    { 108, "Cape Verde" },
                    { 120, "Norway" },
                    { 123, "Solomon Islands" },
                    { 124, "Hong Kong" },
                    { 125, "Iran" },
                    { 129, "Luxembourg" },
                    { 130, "Andorra" },
                    { 131, "Panama" },
                    { 121, "Guinea" },
                    { 132, "Switzerland" },
                    { 107, "Jersey" },
                    { 105, "Ukraine" },
                    { 89, "Kazakhstan" },
                    { 90, "Anguilla" },
                    { 91, "Albania" },
                    { 93, "Virgin Islands, U.S." },
                    { 94, "Antigua and Barbuda" },
                    { 96, "Bhutan" },
                    { 106, "United Kingdom" },
                    { 97, "United States Minor Outlying Islands" },
                    { 99, "Uganda" },
                    { 100, "Saint Lucia" },
                    { 101, "Armenia" },
                    { 102, "French Southern Territories" },
                    { 103, "Montenegro" },
                    { 104, "Cyprus" },
                    { 98, "Vanuatu" },
                    { 88, "Sierra Leone" },
                    { 133, "United States of America" },
                    { 135, "Seychelles" },
                    { 167, "Palau" },
                    { 169, "Netherlands Antilles" },
                    { 170, "South Africa" },
                    { 176, "American Samoa" },
                    { 177, "Sweden" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 178, "Zimbabwe" },
                    { 166, "Libyan Arab Jamahiriya" },
                    { 179, "Romania" },
                    { 184, "Turkmenistan" },
                    { 185, "Greece" },
                    { 186, "Turks and Caicos Islands" },
                    { 187, "Guadeloupe" },
                    { 194, "Mongolia" },
                    { 197, "Pitcairn Islands" },
                    { 181, "Georgia" },
                    { 134, "Macao" },
                    { 164, "Denmark" },
                    { 162, "Mauritius" },
                    { 137, "United Arab Emirates" },
                    { 138, "Ghana" },
                    { 141, "Jamaica" },
                    { 145, "Norfolk Island" },
                    { 146, "Honduras" },
                    { 147, "Swaziland" },
                    { 163, "Nicaragua" },
                    { 149, "French Guiana" },
                    { 155, "Hungary" },
                    { 156, "New Zealand" },
                    { 157, "Latvia" },
                    { 158, "Cook Islands" },
                    { 159, "Slovakia (Slovak Republic)" },
                    { 160, "Saint Martin" },
                    { 150, "Morocco" },
                    { 87, "Lithuania" },
                    { 92, "Czech Republic" },
                    { 83, "Marshall Islands" },
                    { 22, "Barbados" },
                    { 24, "Tunisia" },
                    { 25, "Belize" },
                    { 26, "Serbia" },
                    { 28, "Comoros" },
                    { 29, "Myanmar" },
                    { 21, "Argentina" },
                    { 30, "Nauru" },
                    { 32, "Egypt" },
                    { 33, "Chad" },
                    { 85, "Svalbard & Jan Mayen Islands" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 35, "Croatia" },
                    { 36, "Liechtenstein" },
                    { 37, "Tanzania" },
                    { 31, "Dominica" },
                    { 20, "Cocos (Keeling) Islands" },
                    { 19, "Niue" },
                    { 18, "Tonga" },
                    { 2, "Suriname" },
                    { 3, "Martinique" },
                    { 4, "Guam" },
                    { 5, "Saint Barthelemy" },
                    { 6, "Maldives" },
                    { 7, "Cayman Islands" },
                    { 8, "Bangladesh" },
                    { 9, "Turkey" },
                    { 10, "Saudi Arabia" },
                    { 11, "British Indian Ocean Territory (Chagos Archipelago)" },
                    { 12, "Haiti" },
                    { 13, "Western Sahara" },
                    { 14, "Netherlands" },
                    { 15, "Tuvalu" },
                    { 16, "Falkland Islands (Malvinas)" },
                    { 38, "Dominican Republic" },
                    { 40, "Bahrain" },
                    { 34, "Portugal" },
                    { 43, "El Salvador" },
                    { 67, "Costa Rica" },
                    { 68, "Estonia" },
                    { 69, "Iraq" },
                    { 42, "Indonesia" },
                    { 71, "Iceland" },
                    { 72, "South Georgia and the South Sandwich Islands" },
                    { 66, "Taiwan" },
                    { 74, "Monaco" },
                    { 76, "New Caledonia" },
                    { 77, "Somalia" },
                    { 78, "Tajikistan" },
                    { 79, "Faroe Islands" },
                    { 80, "Sri Lanka" },
                    { 82, "Malawi" },
                    { 75, "Brazil" },
                    { 65, "Malta" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 70, "Ireland" },
                    { 63, "Kiribati" },
                    { 44, "Kyrgyz Republic" },
                    { 46, "Ecuador" },
                    { 64, "France" },
                    { 48, "Algeria" },
                    { 49, "Niger" },
                    { 50, "Gibraltar" },
                    { 51, "Saint Vincent and the Grenadines" },
                    { 47, "Micronesia" },
                    { 54, "Guyana" },
                    { 57, "Liberia" },
                    { 58, "Nigeria" },
                    { 60, "Uruguay" },
                    { 61, "Afghanistan" },
                    { 62, "Venezuela" },
                    { 52, "Guernsey" }
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
                    { 175, 1, "Rempelland" },
                    { 183, 108, "Port Doyle" },
                    { 174, 108, "West Hestermouth" },
                    { 149, 108, "Agnesview" },
                    { 296, 107, "West Jermainmouth" },
                    { 173, 106, "East Aiyanaport" },
                    { 160, 105, "South Mathewberg" },
                    { 124, 104, "Mooretown" },
                    { 240, 103, "Hagenestown" },
                    { 176, 103, "Laurafort" },
                    { 112, 103, "Port Oralland" },
                    { 198, 102, "Lake Brock" },
                    { 67, 102, "East Alan" },
                    { 63, 101, "West Enrique" },
                    { 232, 100, "Eliezertown" },
                    { 211, 100, "West Aronberg" },
                    { 234, 99, "East Dameonshire" },
                    { 182, 99, "Jacobsshire" },
                    { 190, 108, "South Maxinechester" },
                    { 141, 99, "Port Hattiehaven" },
                    { 252, 108, "East Keatonview" },
                    { 133, 112, "West Mikayla" },
                    { 285, 123, "Glennieborough" },
                    { 249, 123, "New Ricky" },
                    { 66, 123, "New Lucieborough" },
                    { 7, 123, "Marksberg" },
                    { 300, 121, "Mohrmouth" },
                    { 62, 121, "Lake Georgiana" },
                    { 23, 121, "Beahanmouth" },
                    { 157, 120, "D'Amoreport" },
                    { 257, 116, "Vernicemouth" },
                    { 166, 116, "East Zachary" },
                    { 262, 115, "Port Deron" },
                    { 260, 115, "South Emery" },
                    { 177, 115, "North Frankieton" },
                    { 51, 115, "Braunhaven" },
                    { 24, 115, "North Vidal" },
                    { 269, 114, "Gleichnerton" },
                    { 104, 114, "West Amosmouth" },
                    { 221, 111, "West Victoria" },
                    { 150, 98, "New Kitty" },
                    { 61, 98, "Zoilaville" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 197, 96, "Donnellyhaven" },
                    { 291, 82, "West Tedside" },
                    { 274, 82, "Hazelville" },
                    { 218, 82, "East Haylieberg" },
                    { 235, 80, "Tillmanhaven" },
                    { 251, 79, "Lake Alexaneport" },
                    { 246, 79, "North Clementstad" },
                    { 115, 79, "Nolanton" },
                    { 100, 79, "Norvalhaven" },
                    { 3, 79, "Lake Jennie" },
                    { 1, 79, "Zitaside" },
                    { 224, 78, "Konopelskiland" },
                    { 31, 78, "Reidburgh" },
                    { 14, 78, "Quigleyburgh" },
                    { 290, 77, "Spencerburgh" },
                    { 60, 77, "North Delia" },
                    { 266, 76, "Lake Evangelinehaven" },
                    { 154, 76, "Lake Kirstenbury" },
                    { 101, 83, "Parkerfurt" },
                    { 277, 83, "West Molliemouth" },
                    { 68, 85, "North Theresechester" },
                    { 73, 85, "Port Jeffereybury" },
                    { 33, 96, "Turnerland" },
                    { 58, 94, "New Vernonland" },
                    { 185, 93, "Ankundington" },
                    { 263, 92, "Aviston" },
                    { 129, 92, "Marjoryfurt" },
                    { 41, 92, "Kyrastad" },
                    { 117, 90, "Hahnstad" },
                    { 89, 90, "East Manuela" },
                    { 288, 123, "Port Austen" },
                    { 299, 89, "Port Rollinville" },
                    { 294, 89, "North Estrellabury" },
                    { 229, 89, "Wendyland" },
                    { 125, 88, "Port Jamaal" },
                    { 53, 88, "West Laverne" },
                    { 222, 87, "Steuberville" },
                    { 36, 87, "Issacfort" },
                    { 261, 85, "Westberg" },
                    { 142, 85, "Hayesfort" },
                    { 297, 89, "Littelport" },
                    { 244, 75, "East Patience" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 72, 125, "Rennerberg" },
                    { 205, 130, "West Fredrick" },
                    { 57, 170, "Daishaton" },
                    { 45, 170, "East Maciebury" },
                    { 96, 167, "Lake London" },
                    { 59, 167, "Greenholtview" },
                    { 56, 167, "North Dustyport" },
                    { 220, 166, "Kingmouth" },
                    { 199, 166, "Hollisburgh" },
                    { 93, 166, "North Hallietown" },
                    { 254, 164, "Kiratown" },
                    { 191, 164, "North Nevaberg" },
                    { 118, 164, "Cindyland" },
                    { 181, 163, "Reillytown" },
                    { 155, 163, "Howellberg" },
                    { 80, 163, "Janymouth" },
                    { 239, 162, "Jedidiahborough" },
                    { 195, 162, "South Creolastad" },
                    { 178, 162, "New Wilhelminetown" },
                    { 253, 176, "Lilymouth" },
                    { 271, 160, "Lake Sheldon" },
                    { 11, 177, "Nathenbury" },
                    { 119, 177, "Port Jackeline" },
                    { 236, 197, "New Felipa" },
                    { 165, 194, "New Olga" },
                    { 203, 187, "South Amyborough" },
                    { 188, 187, "Lednerfort" },
                    { 4, 187, "Kiehnfort" },
                    { 76, 186, "West Marian" },
                    { 52, 186, "Lake Eudorafort" },
                    { 163, 185, "West Pablotown" },
                    { 38, 185, "South Aminaview" },
                    { 265, 184, "New Lazarochester" },
                    { 103, 184, "Prohaskamouth" },
                    { 226, 181, "Lake Margretburgh" },
                    { 44, 181, "Hilpertview" },
                    { 270, 179, "Prosaccoton" },
                    { 92, 179, "New Tommie" },
                    { 169, 178, "East Ewald" },
                    { 282, 177, "East Rosina" },
                    { 37, 177, "Jessikamouth" },
                    { 264, 160, "South Clementshire" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 243, 160, "Keelingborough" },
                    { 34, 160, "North Hudsonberg" },
                    { 48, 145, "Port Ellsworth" },
                    { 286, 141, "Lake Flavioshire" },
                    { 267, 141, "Port Sherwood" },
                    { 74, 138, "South Crawford" },
                    { 292, 137, "Vanessaside" },
                    { 116, 137, "Jeannefurt" },
                    { 216, 135, "Port Trenton" },
                    { 50, 135, "Williamsonbury" },
                    { 35, 135, "West Dewitt" },
                    { 90, 134, "East Murphy" },
                    { 139, 133, "Lake Gunner" },
                    { 87, 133, "South Guiseppeside" },
                    { 280, 132, "Isaiasfort" },
                    { 213, 132, "East Tina" },
                    { 187, 132, "Ottisside" },
                    { 70, 131, "New Dagmar" },
                    { 29, 131, "Landenberg" },
                    { 162, 146, "Gerlachside" },
                    { 276, 146, "North Weston" },
                    { 287, 146, "New Janice" },
                    { 233, 147, "Madilynview" },
                    { 179, 159, "Lilianhaven" },
                    { 75, 159, "East Marion" },
                    { 71, 159, "New Kay" },
                    { 275, 157, "Lake Nicholas" },
                    { 156, 157, "Port Ona" },
                    { 77, 157, "Earlinehaven" },
                    { 245, 156, "New Gudrun" },
                    { 79, 156, "North Rahsaan" },
                    { 284, 129, "New Tabithaton" },
                    { 13, 156, "Wuckertbury" },
                    { 228, 155, "North Chelsey" },
                    { 214, 150, "North Patricia" },
                    { 153, 150, "Schulistmouth" },
                    { 140, 150, "Damianberg" },
                    { 134, 150, "Lake Everette" },
                    { 122, 150, "North Danialbury" },
                    { 94, 150, "Adityachester" },
                    { 230, 149, "East Nelda" },
                    { 293, 155, "West Shawn" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 91, 75, "South Elfrieda" },
                    { 208, 99, "Morarland" },
                    { 55, 28, "Kathrynton" },
                    { 130, 34, "Russelton" },
                    { 146, 32, "Murphyburgh" },
                    { 106, 31, "Casimirshire" },
                    { 28, 31, "New Natalia" },
                    { 186, 30, "Spinkafurt" },
                    { 167, 30, "West Christinechester" },
                    { 223, 29, "New Alejandrinview" },
                    { 259, 1, "East Bethany" },
                    { 64, 29, "Alessandromouth" },
                    { 120, 2, "Ondrickaland" },
                    { 180, 28, "West Albaport" },
                    { 86, 28, "West Kianna" },
                    { 170, 2, "Icieland" },
                    { 54, 75, "South Jeromy" },
                    { 273, 2, "Port Michaelshire" },
                    { 278, 3, "Trompstad" },
                    { 5, 25, "Stefantown" },
                    { 196, 34, "West Jermaineborough" },
                    { 97, 35, "Aliyahfurt" },
                    { 151, 35, "Julianashire" },
                    { 102, 36, "Howemouth" },
                    { 126, 48, "New Alejandrinton" },
                    { 43, 48, "Unastad" },
                    { 147, 47, "South Hector" },
                    { 88, 47, "Susieshire" },
                    { 219, 9, "Lake Carroll" },
                    { 99, 46, "Lake Savion" },
                    { 15, 46, "East Alethachester" },
                    { 248, 44, "Lamonthaven" },
                    { 189, 24, "West Amanihaven" },
                    { 113, 44, "East Crystelville" },
                    { 217, 42, "East Isabell" },
                    { 210, 42, "North Stephanland" },
                    { 42, 40, "Otisport" },
                    { 26, 40, "Albinaton" },
                    { 207, 37, "West Astrid" },
                    { 145, 37, "West Amani" },
                    { 192, 36, "East Jordon" },
                    { 161, 36, "Kenyonbury" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 111, 43, "East Jody" },
                    { 105, 49, "Katherinefurt" },
                    { 49, 24, "Lake Delberthaven" },
                    { 204, 22, "Lake Kayden" },
                    { 201, 6, "North Clyde" },
                    { 143, 12, "MacGyverview" },
                    { 137, 12, "East Tobinbury" },
                    { 128, 12, "North Josiane" },
                    { 256, 6, "Kuvalisstad" },
                    { 47, 12, "Feestview" },
                    { 19, 12, "Hermistonshire" },
                    { 258, 6, "Lake Herminia" },
                    { 18, 7, "Terryville" },
                    { 39, 7, "East Prudencemouth" },
                    { 164, 7, "East Melody" },
                    { 215, 11, "Port Madonna" },
                    { 85, 11, "West Scarlett" },
                    { 298, 7, "New Orrin" },
                    { 22, 8, "New Lessie" },
                    { 171, 10, "West Fausto" },
                    { 30, 10, "North Emmahaven" },
                    { 2, 6, "New Treshire" },
                    { 159, 13, "West Willowberg" },
                    { 20, 14, "South Robyn" },
                    { 46, 14, "North Brice" },
                    { 279, 3, "Boscoview" },
                    { 272, 21, "Wisokyland" },
                    { 158, 21, "Lake Janiyafurt" },
                    { 135, 21, "Lake Eldridgefurt" },
                    { 109, 21, "West Narcisoland" },
                    { 107, 21, "McLaughlinside" },
                    { 12, 5, "Lake Camden" },
                    { 98, 21, "Bergeberg" },
                    { 242, 22, "Elianmouth" },
                    { 289, 19, "North Herminiamouth" },
                    { 25, 5, "South Gaetanoburgh" },
                    { 21, 19, "Jakaylaborough" },
                    { 8, 19, "West Kali" },
                    { 83, 5, "South Kaitlinhaven" },
                    { 283, 15, "West Sageburgh" },
                    { 247, 15, "Ottohaven" },
                    { 121, 15, "Vonhaven" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 114, 15, "Mireilleburgh" },
                    { 69, 19, "West Ervin" },
                    { 138, 49, "Ashtonbury" },
                    { 27, 47, "Doyleborough" },
                    { 209, 49, "Dorisburgh" },
                    { 152, 63, "South Crystelmouth" },
                    { 16, 63, "Antoneberg" },
                    { 9, 63, "Emmyborough" },
                    { 295, 62, "New Kaileeview" },
                    { 168, 62, "Claudineberg" },
                    { 10, 62, "Lake Mossieshire" },
                    { 194, 63, "Bernhardhaven" },
                    { 237, 60, "Tremblayville" },
                    { 144, 60, "West Clarashire" },
                    { 268, 58, "Maggioborough" },
                    { 200, 49, "Lawsonport" },
                    { 238, 58, "Jakobhaven" },
                    { 136, 57, "South Holly" },
                    { 82, 57, "Port Mylesland" },
                    { 184, 60, "Gislasonmouth" },
                    { 78, 54, "New Aniyahfort" },
                    { 225, 63, "Lake Audieton" },
                    { 127, 64, "Maggioburgh" },
                    { 132, 74, "Leonorborough" },
                    { 84, 74, "Port Sigrid" },
                    { 40, 74, "Vernieshire" },
                    { 212, 72, "Lindborough" },
                    { 17, 71, "Koeppland" },
                    { 250, 70, "Derekstad" },
                    { 241, 63, "New Ofeliafurt" },
                    { 227, 69, "New Odie" },
                    { 6, 68, "Rennerview" },
                    { 148, 67, "North Icieburgh" },
                    { 193, 66, "Port Valentina" },
                    { 95, 66, "Deckowchester" },
                    { 281, 65, "Abbigailhaven" },
                    { 172, 64, "South Wilfredo" },
                    { 110, 69, "Hesselport" },
                    { 255, 52, "South Shakiratown" },
                    { 65, 8, "East Billmouth" },
                    { 231, 51, "Giovannafort" },
                    { 123, 51, "Mannhaven" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 81, 51, "Batzview" },
                    { 32, 51, "Purdybury" },
                    { 206, 50, "Bernieberg" },
                    { 202, 51, "Lake Elenoramouth" },
                    { 131, 50, "Paolostad" },
                    { 108, 52, "North Anne" }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 63, 2710, 3, "commodi", 379 },
                    { 77, 2117, 3, "ducimus", 127 },
                    { 24, 1943, 2, "ipsum", 667 },
                    { 71, 2110, 4, "omnis", 207 },
                    { 22, 1971, 2, "doloribus", 285 },
                    { 81, 1020, 3, "deleniti", 466 },
                    { 39, 2473, 2, "quisquam", 209 },
                    { 95, 1768, 1, "quasi", 429 },
                    { 1, 1408, 4, "ad", 682 },
                    { 25, 1622, 4, "rem", 604 },
                    { 38, 1949, 2, "consequatur", 314 },
                    { 31, 2566, 2, "nihil", 673 },
                    { 13, 1497, 2, "temporibus", 545 },
                    { 11, 2525, 2, "sit", 635 },
                    { 28, 1463, 4, "sint", 673 },
                    { 35, 2595, 4, "reiciendis", 662 },
                    { 29, 1410, 2, "amet", 163 },
                    { 70, 1983, 4, "quo", 581 },
                    { 37, 2640, 4, "facilis", 616 },
                    { 96, 2905, 1, "fuga", 400 },
                    { 3, 2073, 2, "enim", 467 },
                    { 52, 1190, 4, "voluptatibus", 240 },
                    { 61, 1405, 4, "asperiores", 514 },
                    { 62, 2985, 4, "non", 404 },
                    { 65, 2164, 4, "a", 405 },
                    { 5, 1452, 2, "veritatis", 279 },
                    { 6, 1214, 2, "pariatur", 625 },
                    { 67, 2787, 4, "vitae", 432 },
                    { 33, 2053, 4, "voluptatem", 468 },
                    { 68, 1785, 4, "neque", 343 },
                    { 66, 2386, 2, "animi", 314 },
                    { 46, 1911, 3, "beatae", 512 },
                    { 17, 1029, 1, "officia", 197 },
                    { 30, 1174, 1, "inventore", 453 },
                    { 89, 1803, 2, "sed", 602 },
                    { 19, 1190, 1, "cupiditate", 666 }
                });

            migrationBuilder.InsertData(
                table: "Engines",
                columns: new[] { "Id", "CubicCapacity", "FuelTypeId", "Name", "Power" },
                values: new object[,]
                {
                    { 88, 1858, 2, "in", 571 },
                    { 20, 1893, 1, "numquam", 364 },
                    { 83, 1198, 2, "cum", 591 },
                    { 55, 1725, 2, "velit", 233 },
                    { 21, 2579, 1, "consequuntur", 614 },
                    { 23, 2200, 1, "dolore", 522 },
                    { 78, 1131, 2, "id", 356 },
                    { 74, 2540, 2, "repellendus", 385 },
                    { 26, 2989, 1, "aliquam", 588 },
                    { 73, 2040, 2, "nostrum", 637 },
                    { 27, 1290, 1, "ut", 663 },
                    { 32, 2879, 1, "accusantium", 353 },
                    { 34, 2101, 1, "est", 600 },
                    { 14, 2726, 1, "quis", 290 },
                    { 10, 1933, 1, "libero", 521 },
                    { 42, 1097, 3, "dolorum", 265 },
                    { 40, 2090, 2, "eaque", 119 },
                    { 51, 1450, 2, "perspiciatis", 457 },
                    { 87, 1853, 1, "explicabo", 400 },
                    { 54, 2649, 2, "molestiae", 248 },
                    { 16, 2832, 3, "quaerat", 274 },
                    { 8, 2462, 3, "qui", 669 },
                    { 57, 1118, 3, "rerum", 398 },
                    { 7, 1640, 3, "molestias", 381 },
                    { 79, 2233, 1, "dolor", 322 },
                    { 64, 1004, 1, "nulla", 538 },
                    { 4, 2272, 3, "voluptas", 557 },
                    { 2, 2454, 3, "unde", 437 },
                    { 60, 1586, 1, "eos", 516 },
                    { 97, 2122, 2, "ipsam", 567 },
                    { 45, 2881, 1, "quia", 472 },
                    { 86, 2434, 1, "placeat", 664 },
                    { 9, 2128, 1, "et", 562 },
                    { 100, 1870, 4, "optio", 687 },
                    { 76, 2208, 4, "odio", 567 }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 99, 166, "Willms, Haley and Lubowitz" },
                    { 13, 96, "Barrows - Ziemann" },
                    { 79, 96, "Roob LLC" },
                    { 76, 97, "Bahringer, Ziemann and Berge" },
                    { 78, 52, "Schaden, Kovacek and Robel" },
                    { 32, 52, "Hilll and Sons" },
                    { 11, 52, "Brown, Predovic and Cormier" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 40, 51, "Pfannerstill - Mohr" },
                    { 46, 100, "Connelly Inc" },
                    { 33, 51, "O'Reilly, Cremin and Hartmann" },
                    { 26, 101, "O'Keefe, Sawayn and Zieme" },
                    { 85, 50, "Beahan - Conn" },
                    { 41, 50, "Paucek - Ratke" },
                    { 27, 105, "Becker - Wyman" },
                    { 28, 106, "Heidenreich Group" },
                    { 34, 107, "Schuster LLC" },
                    { 91, 48, "Kunze, Parker and Zulauf" },
                    { 18, 108, "Russel - Hartmann" },
                    { 17, 48, "Gleichner and Sons" },
                    { 5, 111, "Feest - Langosh" },
                    { 21, 111, "Brakus, Ritchie and Mitchell" },
                    { 86, 93, "Klocko - Zieme" },
                    { 53, 92, "Langworth - Farrell" },
                    { 2, 92, "Harber Group" },
                    { 69, 90, "Marvin and Sons" },
                    { 30, 75, "Schaefer - Parisian" },
                    { 37, 76, "Cole - Larson" },
                    { 25, 71, "Swift - Rippin" },
                    { 71, 77, "Gutkowski - Koelpin" },
                    { 60, 69, "O'Conner - DuBuque" },
                    { 9, 78, "O'Reilly, Reinger and Bartoletti" },
                    { 75, 78, "Reinger, Kshlerin and Christiansen" },
                    { 83, 78, "Franecki, Nader and Goyette" },
                    { 47, 68, "McDermott, Koelpin and Lemke" },
                    { 63, 66, "Bernier LLC" },
                    { 55, 111, "Gutkowski - Wyman" },
                    { 16, 79, "Howell, Yundt and Satterfield" },
                    { 54, 64, "Rath - Moore" },
                    { 19, 64, "Cassin, Heidenreich and Schmitt" },
                    { 31, 63, "Kassulke Group" },
                    { 4, 87, "Conn, O'Keefe and Labadie" },
                    { 64, 87, "Champlin Inc" },
                    { 6, 88, "Beahan, Bayer and Roob" },
                    { 77, 88, "Lakin LLC" },
                    { 98, 88, "Labadie, Douglas and Wintheiser" },
                    { 59, 61, "Mertz - Mosciski" },
                    { 38, 61, "White - Robel" },
                    { 48, 66, "Runolfsdottir and Sons" },
                    { 67, 169, "Wyman - Deckow" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 84, 111, "Bode - Kessler" },
                    { 35, 121, "Klein - Vandervort" },
                    { 42, 150, "Will - Bayer" },
                    { 29, 4, "Batz, Streich and Kuhic" },
                    { 7, 156, "Ondricka Inc" },
                    { 93, 158, "Hagenes - Spencer" },
                    { 62, 18, "O'Connell Group" },
                    { 1, 5, "Parisian, Schuster and Mohr" },
                    { 14, 162, "Keeling, Schultz and Reinger" },
                    { 74, 179, "Haley Group" },
                    { 61, 162, "Beahan Group" },
                    { 15, 163, "Herzog, White and Lind" },
                    { 23, 178, "Dare Inc" },
                    { 73, 11, "Bruen - Bosco" },
                    { 68, 177, "Gerlach Inc" },
                    { 56, 177, "Konopelski - Herman" },
                    { 20, 164, "Fisher LLC" },
                    { 22, 164, "Connelly LLC" },
                    { 65, 164, "Green and Sons" },
                    { 50, 10, "Kiehn, Bogisich and Pfannerstill" },
                    { 97, 176, "Gleichner - Fritsch" },
                    { 88, 7, "Larson LLC" },
                    { 8, 170, "Yundt - Turner" },
                    { 100, 26, "Pfeffer, McDermott and Conn" },
                    { 80, 186, "Senger, White and Hermiston" },
                    { 49, 149, "Dicki - Hickle" },
                    { 87, 147, "Cole Inc" },
                    { 58, 38, "Crist - Buckridge" },
                    { 44, 38, "Gottlieb, Lowe and Schmeler" },
                    { 96, 37, "Renner - Beahan" },
                    { 72, 37, "Renner - Crooks" },
                    { 70, 123, "Krajcik - Schumm" },
                    { 52, 124, "Hane, Zieme and Waters" },
                    { 57, 124, "Kemmer - Johns" },
                    { 39, 37, "Hessel - Casper" },
                    { 12, 131, "Kovacek Inc" },
                    { 51, 35, "Monahan, Witting and Monahan" },
                    { 10, 46, "Aufderhar, Hessel and Funk" },
                    { 66, 34, "Emmerich - Dibbert" },
                    { 94, 32, "Grady Group" },
                    { 43, 135, "Rodriguez - Hauck" },
                    { 81, 137, "Watsica LLC" }
                });

            migrationBuilder.InsertData(
                table: "Manufacturers",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 95, 29, "Lesch - Nienow" },
                    { 3, 141, "Douglas, Jenkins and Leffler" },
                    { 90, 141, "Sporer Inc" },
                    { 82, 197, "Little, Orn and Schmitt" },
                    { 45, 145, "Wisozk - Flatley" },
                    { 24, 1, "Hansen, Kertzmann and Zulauf" },
                    { 92, 28, "Kreiger Inc" },
                    { 89, 133, "Christiansen, Sipes and Langosh" },
                    { 36, 74, "Swift, Blick and Cassin" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 75, 76, 50, "sapiente" },
                    { 93, 38, 84, "odit" },
                    { 2, 38, 17, "reiciendis" },
                    { 82, 31, 3, "quia" },
                    { 38, 31, 40, "voluptatum" },
                    { 29, 31, 15, "voluptatibus" },
                    { 79, 24, 95, "sunt" },
                    { 50, 22, 60, "dolorum" },
                    { 89, 13, 74, "aut" },
                    { 96, 11, 3, "explicabo" },
                    { 26, 6, 74, "aspernatur" },
                    { 13, 6, 53, "hic" },
                    { 34, 3, 15, "rerum" },
                    { 46, 96, 100, "perspiciatis" },
                    { 17, 95, 95, "exercitationem" },
                    { 63, 87, 81, "qui" },
                    { 47, 87, 16, "numquam" },
                    { 36, 86, 24, "eum" },
                    { 24, 9, 54, "ad" },
                    { 44, 9, 85, "labore" },
                    { 8, 10, 66, "ut" },
                    { 14, 20, 58, "quo" },
                    { 90, 21, 4, "doloribus" },
                    { 7, 27, 69, "consectetur" },
                    { 19, 51, 50, "facilis" },
                    { 48, 30, 94, "dolores" },
                    { 35, 32, 2, "dolore" },
                    { 12, 34, 32, "similique" },
                    { 67, 34, 43, "libero" },
                    { 49, 64, 40, "veritatis" },
                    { 57, 64, 42, "velit" },
                    { 73, 79, 31, "unde" },
                    { 11, 32, 64, "et" },
                    { 84, 66, 28, "non" },
                    { 37, 70, 55, "sit" },
                    { 70, 73, 76, "debitis" },
                    { 6, 73, 65, "atque" },
                    { 91, 67, 20, "earum" },
                    { 39, 67, 67, "tenetur" },
                    { 80, 65, 58, "ea" },
                    { 5, 65, 41, "officia" },
                    { 98, 62, 98, "error" }
                });

            migrationBuilder.InsertData(
                table: "CarModels",
                columns: new[] { "Id", "EngineId", "ManufacturerId", "Name" },
                values: new object[,]
                {
                    { 33, 52, 62, "quaerat" },
                    { 27, 52, 13, "rem" },
                    { 9, 52, 63, "totam" },
                    { 60, 1, 21, "quisquam" },
                    { 31, 1, 9, "officiis" },
                    { 1, 1, 21, "omnis" },
                    { 56, 81, 97, "quidem" },
                    { 40, 81, 95, "ex" },
                    { 3, 81, 55, "maiores" },
                    { 22, 67, 1, "molestiae" },
                    { 94, 63, 43, "esse" },
                    { 30, 77, 93, "fugit" },
                    { 76, 83, 42, "nam" },
                    { 62, 89, 10, "neque" },
                    { 45, 97, 53, "excepturi" },
                    { 87, 97, 92, "vel" },
                    { 52, 4, 62, "nihil" },
                    { 10, 89, 57, "minima" },
                    { 25, 8, 36, "est" },
                    { 51, 63, 91, "ratione" },
                    { 81, 4, 58, "dolor" },
                    { 15, 63, 58, "sed" },
                    { 58, 74, 15, "possimus" },
                    { 53, 57, 98, "itaque" },
                    { 4, 57, 36, "architecto" },
                    { 61, 46, 50, "voluptas" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 283, 287, "Braden85@hotmail.com", "Vladimir", "Breitenberg", "password123", 2, "Allen_Koelpin5" },
                    { 287, 50, "Jensen0@hotmail.com", "Loyce", "Walter", "password123", 2, "Rosario.Nicolas" },
                    { 188, 116, "Delphine61@hotmail.com", "Shana", "West", "password123", 2, "Concepcion79" },
                    { 19, 267, "Gia35@hotmail.com", "Asha", "Pagac", "password123", 3, "Minerva55" },
                    { 172, 286, "Alfreda.Jones@hotmail.com", "Nikolas", "Swift", "password123", 1, "Hildegard.Heaney" },
                    { 185, 286, "Cordell_Spinka16@gmail.com", "Mireille", "Kuhn", "password123", 1, "Kailee_Rath" },
                    { 215, 286, "Jettie_Morar@yahoo.com", "Guillermo", "Wisoky", "password123", 2, "Logan63" },
                    { 298, 286, "Malinda.Daugherty60@yahoo.com", "Shanelle", "Sauer", "password123", 2, "Matteo_Kuvalis" },
                    { 113, 162, "Polly_Gutkowski@gmail.com", "Zoey", "Bahringer", "password123", 3, "Theodora66" },
                    { 156, 162, "Logan.Rohan51@hotmail.com", "Cesar", "Cole", "password123", 3, "Vella64" },
                    { 112, 50, "Maryam22@gmail.com", "Amie", "Waters", "password123", 1, "Ladarius.Vandervort" },
                    { 196, 74, "Hollie_Cummerata@hotmail.com", "Delphine", "Davis", "password123", 3, "Macy_Schneider2" },
                    { 195, 140, "Maddison_Durgan17@hotmail.com", "Belle", "Collins", "password123", 3, "Pearline33" },
                    { 55, 94, "Valerie18@hotmail.com", "Bridgette", "O'Reilly", "password123", 1, "Wellington20" },
                    { 66, 94, "Anya_Armstrong@yahoo.com", "Brown", "Denesik", "password123", 2, "Stephan77" },
                    { 213, 94, "Mariam_Rutherford@hotmail.com", "Caterina", "Huel", "password123", 3, "Clara.Kessler39" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 234, 134, "Elias36@gmail.com", "Kayden", "Daniel", "password123", 2, "Mafalda_Stracke21" },
                    { 18, 140, "Pablo91@gmail.com", "Hilma", "Gerhold", "password123", 2, "Orion.Mayert32" },
                    { 229, 140, "Jailyn.Huel25@yahoo.com", "Marcus", "Klein", "password123", 1, "Amira.Nolan" },
                    { 186, 153, "Alize_Bode80@gmail.com", "Wilbert", "Jast", "password123", 1, "Cletus.Tillman61" },
                    { 191, 153, "Linda_Hermann17@hotmail.com", "Halle", "Toy", "password123", 1, "Jade_Frami" },
                    { 84, 214, "Kendall.Hoppe@gmail.com", "Camron", "Kuhlman", "password123", 2, "Justina85" },
                    { 127, 293, "Ruby15@yahoo.com", "Serena", "Powlowski", "password123", 2, "Angelita.Abbott" },
                    { 165, 293, "Jake.Farrell65@yahoo.com", "Titus", "Heaney", "password123", 3, "Emely84" },
                    { 16, 35, "Mable_Dibbert92@gmail.com", "Vivienne", "Johns", "password123", 1, "Shemar_Turner12" },
                    { 245, 230, "Sydni.Barrows@hotmail.com", "Karley", "Schaefer", "password123", 2, "Gustave_Stehr" },
                    { 269, 90, "Ernest33@gmail.com", "Odessa", "Conn", "password123", 2, "Abdullah.Runolfsdottir" },
                    { 123, 285, "Abby89@hotmail.com", "Olin", "Jast", "password123", 3, "Arden.Altenwerth" },
                    { 295, 213, "Enos.Bruen@gmail.com", "Carolyn", "Lind", "password123", 2, "Rylan83" },
                    { 107, 183, "Elian_Stiedemann58@gmail.com", "Wade", "Bednar", "password123", 1, "Justen.Ward67" },
                    { 147, 252, "Afton.Toy28@yahoo.com", "Lucinda", "Hartmann", "password123", 1, "Rachel32" },
                    { 270, 221, "Myron_Thiel41@yahoo.com", "Darrion", "Terry", "password123", 1, "Delta77" },
                    { 212, 133, "Brando1@gmail.com", "Retta", "Zboncak", "password123", 2, "Alexzander_Gerlach" },
                    { 141, 269, "Oral99@hotmail.com", "Alfonso", "Gutkowski", "password123", 3, "Consuelo28" },
                    { 77, 166, "Corrine.Little@yahoo.com", "Zella", "Kuhlman", "password123", 3, "Mose.Kertzmann51" },
                    { 179, 257, "Velma37@hotmail.com", "Diego", "Koch", "password123", 3, "Tamara55" },
                    { 201, 157, "Destiny.Kozey@hotmail.com", "Nestor", "Treutel", "password123", 1, "Dora52" },
                    { 256, 157, "Damion_Green@hotmail.com", "Leanna", "Gislason", "password123", 3, "Kyleigh.Nikolaus" },
                    { 284, 7, "Prudence.Hickle33@gmail.com", "Ryleigh", "Haley", "password123", 3, "Chelsey.Walker" },
                    { 155, 249, "Kelly82@yahoo.com", "Jeremie", "Lueilwitz", "password123", 3, "Kathryne.Strosin91" },
                    { 161, 249, "Domenica.Schmidt16@hotmail.com", "Meghan", "Nolan", "password123", 3, "Salma61" },
                    { 291, 139, "Felicity.Jakubowski@hotmail.com", "Lucienne", "Weber", "password123", 2, "Paul.Herzog33" },
                    { 140, 13, "Webster_Hackett69@hotmail.com", "Brant", "Mohr", "password123", 1, "Jadyn_Johnston" },
                    { 42, 72, "Horace.Haag26@yahoo.com", "Lura", "Pacocha", "password123", 3, "Louisa.Bergnaum18" },
                    { 173, 72, "Neil.McClure@yahoo.com", "Ramiro", "Friesen", "password123", 1, "Clifton.Carter" },
                    { 80, 284, "Boris55@gmail.com", "Brandyn", "Feest", "password123", 1, "Garett.Anderson62" },
                    { 2, 205, "Tom_Fisher48@gmail.com", "Yoshiko", "Runolfsdottir", "password123", 1, "Brannon.Funk49" },
                    { 199, 205, "Rachael_Deckow@hotmail.com", "Ivy", "Hartmann", "password123", 1, "Isom52" },
                    { 14, 29, "Nathanial.Hermiston@hotmail.com", "Isai", "Dietrich", "password123", 3, "Erika98" },
                    { 47, 29, "Sebastian_Miller74@gmail.com", "John", "Stroman", "password123", 2, "Selena_Kunze83" },
                    { 72, 70, "Arden.Reilly@gmail.com", "Prince", "Willms", "password123", 1, "Ruthie35" },
                    { 292, 70, "Robin_Fay30@yahoo.com", "Lilliana", "Fritsch", "password123", 1, "Guy.Murphy27" },
                    { 108, 187, "Concepcion_Connelly5@gmail.com", "Libby", "Langworth", "password123", 1, "Stone_Ruecker" },
                    { 117, 187, "Austin34@gmail.com", "Elva", "Volkman", "password123", 3, "Zackary85" },
                    { 122, 187, "Salma_Gottlieb@hotmail.com", "Clarissa", "Hauck", "password123", 3, "Osborne_Zemlak66" },
                    { 207, 288, "Luigi86@hotmail.com", "Stacey", "Corwin", "password123", 2, "Maxime.Walter79" },
                    { 297, 13, "Ted_Dooley@gmail.com", "Alana", "Hegmann", "password123", 3, "Casimer6" },
                    { 27, 80, "Rollin78@hotmail.com", "Meta", "Deckow", "password123", 1, "Ulises.Ortiz99" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 118, 245, "Wilfrid.Mertz38@hotmail.com", "Abraham", "Reynolds", "password123", 1, "Lucinda_Kirlin8" },
                    { 130, 174, "Angela23@yahoo.com", "Rosetta", "Luettgen", "password123", 3, "Jerry.Fahey" },
                    { 132, 270, "Virginie.Runolfsson@yahoo.com", "Rory", "Cassin", "password123", 3, "Erwin.Pacocha" },
                    { 257, 44, "Sincere_Conroy75@hotmail.com", "Harmon", "Brekke", "password123", 2, "Monroe.Fay65" },
                    { 164, 226, "Beatrice48@hotmail.com", "Lindsay", "Jenkins", "password123", 2, "Cooper.Herman38" },
                    { 152, 103, "Enos75@yahoo.com", "Donavon", "Corwin", "password123", 1, "Brayan.Reinger" },
                    { 220, 103, "Landen_Douglas@hotmail.com", "Monroe", "Lebsack", "password123", 2, "Frida_Botsford96" },
                    { 105, 265, "Rossie97@hotmail.com", "Sienna", "Sanford", "password123", 1, "Wilfred_Mosciski36" },
                    { 210, 265, "Jaron18@yahoo.com", "Kendall", "Ritchie", "password123", 1, "Toby.Kirlin62" },
                    { 217, 265, "Henriette_Ward78@hotmail.com", "Angelita", "Weber", "password123", 3, "Jany_Howe" },
                    { 233, 265, "Kadin.Glover73@gmail.com", "Madyson", "Brown", "password123", 3, "Deon6" },
                    { 48, 38, "Cordie96@yahoo.com", "Virginie", "Trantow", "password123", 3, "Oleta66" },
                    { 78, 163, "Emerald_Mraz5@gmail.com", "Rhianna", "Hackett", "password123", 3, "Darion_Homenick" },
                    { 34, 52, "Hadley.Graham14@gmail.com", "Ron", "Greenfelder", "password123", 3, "Ezequiel23" },
                    { 236, 52, "Chet_Boyer@yahoo.com", "Ross", "Hermann", "password123", 1, "Alek91" },
                    { 67, 4, "Vince.Parker41@yahoo.com", "Lowell", "Larkin", "password123", 1, "Adelia_Leffler" },
                    { 114, 4, "Sofia.Jaskolski@gmail.com", "Clarissa", "Rice", "password123", 1, "Adell.Boehm23" },
                    { 187, 4, "Edyth_Morar@yahoo.com", "Abagail", "Oberbrunner", "password123", 3, "Kaelyn52" },
                    { 259, 4, "Alfonso_Bauch62@gmail.com", "Kaleigh", "Collier", "password123", 3, "Pearl.Brekke8" },
                    { 160, 188, "Newell31@gmail.com", "Melvina", "Murphy", "password123", 2, "Brice_Nikolaus" },
                    { 24, 203, "Maybell97@yahoo.com", "Makenzie", "Stracke", "password123", 1, "Tyra_Wuckert4" },
                    { 65, 203, "Wanda_Johns60@gmail.com", "Helena", "Barton", "password123", 1, "Deon5" },
                    { 99, 203, "Quentin.Hettinger@gmail.com", "Diego", "Torphy", "password123", 2, "Cullen_Thiel" },
                    { 139, 203, "Skye70@yahoo.com", "Lonzo", "Heller", "password123", 3, "Murphy_Hane" },
                    { 300, 203, "Osvaldo.Lind@hotmail.com", "Noble", "Jacobson", "password123", 1, "Wyatt88" },
                    { 63, 236, "Stanton83@yahoo.com", "Miles", "Quigley", "password123", 1, "Alvah.Macejkovic" },
                    { 49, 282, "Precious_Emmerich@gmail.com", "Cordie", "Schmitt", "password123", 2, "Cora30" },
                    { 194, 119, "Jaylen36@gmail.com", "Cathrine", "Koss", "password123", 3, "Ada.Ebert" },
                    { 70, 119, "Mafalda0@gmail.com", "Ethyl", "O'Reilly", "password123", 1, "Caitlyn94" },
                    { 142, 37, "Tyree.Kertzmann@yahoo.com", "Jamie", "Swaniawski", "password123", 2, "Dell.OKeefe23" },
                    { 32, 77, "Lucile.Bins43@yahoo.com", "Christine", "Erdman", "password123", 1, "Martine.Frami" },
                    { 36, 77, "Hazle_Hilpert59@yahoo.com", "Erling", "Hettinger", "password123", 3, "Graham91" },
                    { 248, 77, "Bryana.Schamberger@hotmail.com", "Helmer", "Gerlach", "password123", 2, "Manuela98" },
                    { 98, 71, "Gerda.Muller@yahoo.com", "Maximillian", "Huels", "password123", 3, "Marcellus42" },
                    { 115, 71, "Ciara_Bauch45@gmail.com", "Sigrid", "Jerde", "password123", 3, "Salvatore70" },
                    { 276, 75, "Aniyah7@yahoo.com", "Rhiannon", "DuBuque", "password123", 1, "Savannah_OReilly" },
                    { 135, 34, "Clarabelle_Murray0@gmail.com", "Jammie", "Bashirian", "password123", 3, "Helen_Hand" },
                    { 206, 243, "Eden.Mills41@yahoo.com", "Herminio", "Kertzmann", "password123", 1, "Greg_Powlowski0" },
                    { 214, 243, "Annalise_Wolff@yahoo.com", "Kariane", "Reynolds", "password123", 1, "Belle.Koch84" },
                    { 35, 264, "Naomie_Johns@gmail.com", "Colt", "Adams", "password123", 3, "Emerald_Smith" },
                    { 131, 271, "Julien40@hotmail.com", "Mercedes", "Pfannerstill", "password123", 2, "Alia_McClure" },
                    { 92, 178, "Alverta_OConner@yahoo.com", "Sabrina", "Cruickshank", "password123", 1, "Adella.Cole40" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 46, 245, "Brianne_Homenick68@hotmail.com", "Claud", "Weissnat", "password123", 2, "Bernita_Sanford19" },
                    { 211, 178, "Godfrey.Bednar2@gmail.com", "Ian", "Fahey", "password123", 1, "Adah_Swaniawski" },
                    { 56, 155, "Simone.Buckridge17@gmail.com", "Else", "Pfeffer", "password123", 1, "Janessa.Stiedemann12" },
                    { 192, 155, "Shanel_Predovic@yahoo.com", "Mable", "Steuber", "password123", 1, "Doris41" },
                    { 17, 118, "Jaleel.Auer56@yahoo.com", "Tyrel", "Bayer", "password123", 1, "Bennett11" },
                    { 82, 118, "Leonor.Volkman@hotmail.com", "Roosevelt", "Harvey", "password123", 3, "Callie_Jacobs" },
                    { 150, 118, "Frederic.Pagac43@yahoo.com", "Johathan", "Murray", "password123", 1, "Carolanne.Ullrich25" },
                    { 128, 191, "Augusta.Heathcote52@gmail.com", "Aylin", "Goodwin", "password123", 1, "Clarissa.Adams94" },
                    { 21, 254, "Ellie86@hotmail.com", "Caterina", "Konopelski", "password123", 1, "Javonte87" },
                    { 133, 199, "Desiree_Wintheiser62@yahoo.com", "Nicolas", "Jacobson", "password123", 2, "Sedrick81" },
                    { 247, 220, "Dameon57@yahoo.com", "Alberto", "Bahringer", "password123", 3, "Mark72" },
                    { 104, 59, "Kenny0@hotmail.com", "Davon", "Hudson", "password123", 1, "Isabella_Reichel" },
                    { 126, 59, "Frankie77@gmail.com", "Kayleigh", "Bruen", "password123", 1, "Justina.Lang" },
                    { 285, 45, "Arlie.Trantow@gmail.com", "Cleta", "Shanahan", "password123", 2, "Arnold96" },
                    { 209, 80, "Grover62@gmail.com", "Roma", "Pouros", "password123", 1, "Mallie.Willms" },
                    { 138, 92, "Beatrice.Beatty26@gmail.com", "Lemuel", "West", "password123", 1, "Germaine_Braun" },
                    { 121, 296, "Jayson59@yahoo.com", "Jamey", "Ledner", "password123", 2, "Lacey.Will" },
                    { 129, 173, "Fredrick_Kautzer@hotmail.com", "Jaylan", "Homenick", "password123", 1, "Melba91" },
                    { 294, 102, "Agustina_OKeefe87@hotmail.com", "Luciano", "Collins", "password123", 2, "Myrtis42" },
                    { 193, 102, "Alvera82@hotmail.com", "Monte", "Hodkiewicz", "password123", 3, "Tracey_Kovacek71" },
                    { 22, 102, "Nicole43@gmail.com", "Pedro", "Quitzon", "password123", 1, "Angelina87" },
                    { 289, 151, "Magdalena_Dietrich55@gmail.com", "Madie", "Becker", "password123", 1, "Carley.Carroll98" },
                    { 174, 97, "Monty_Powlowski13@hotmail.com", "Alfonzo", "Gusikowski", "password123", 2, "Deon22" },
                    { 296, 130, "Rosa_McClure@gmail.com", "Theron", "Deckow", "password123", 3, "Obie.Kulas62" },
                    { 157, 130, "Caterina14@gmail.com", "Green", "Rowe", "password123", 3, "Jalon_Labadie" },
                    { 69, 130, "Priscilla20@hotmail.com", "Abbigail", "Lebsack", "password123", 1, "Fae_Bosco" },
                    { 37, 130, "Isidro_King65@gmail.com", "Ruthie", "Kerluke", "password123", 1, "Rowan.Willms" },
                    { 148, 146, "Leland61@gmail.com", "Sid", "Russel", "password123", 2, "Gilda6" },
                    { 243, 106, "Erika.Ortiz@hotmail.com", "Lonnie", "Borer", "password123", 3, "Leta_Bosco" },
                    { 59, 106, "Terrance.Considine@gmail.com", "Manuel", "Schowalter", "password123", 1, "Furman_Sanford21" },
                    { 169, 223, "Ena47@gmail.com", "Retha", "Kulas", "password123", 2, "Eugenia15" },
                    { 167, 55, "Zechariah22@hotmail.com", "Chandler", "Wolff", "password123", 3, "Zackery.Zemlak29" },
                    { 3, 49, "Randall.Gutmann@hotmail.com", "Clement", "Muller", "password123", 3, "Marley_Ferry" },
                    { 282, 242, "Hollie_Lowe5@hotmail.com", "Brice", "Schiller", "password123", 3, "Jack24" },
                    { 159, 242, "Francesco.Gislason@hotmail.com", "William", "Miller", "password123", 2, "Camryn_Brown9" },
                    { 262, 204, "Josefa_Koss@hotmail.com", "Citlalli", "Mohr", "password123", 3, "Estel.McCullough9" },
                    { 189, 204, "Kacey.Roob@gmail.com", "Teresa", "Grimes", "password123", 2, "Watson9" },
                    { 89, 161, "Gaston_Durgan95@gmail.com", "Hulda", "Dibbert", "password123", 1, "Zena.Schimmel14" },
                    { 175, 158, "Dannie.Kertzmann59@hotmail.com", "Maribel", "Stark", "password123", 1, "Thaddeus.Blick64" },
                    { 264, 161, "Megane41@gmail.com", "Bonita", "McGlynn", "password123", 3, "Elza49" },
                    { 251, 192, "Murl.Jast1@yahoo.com", "Branson", "Turcotte", "password123", 1, "Clovis46" },
                    { 58, 200, "Adrienne78@gmail.com", "Jovanny", "Roob", "password123", 3, "Dulce80" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 293, 138, "Abner.Mueller32@yahoo.com", "Stanley", "Bogan", "password123", 2, "Emily.Metz" },
                    { 73, 138, "Erika_Runte@yahoo.com", "Clovis", "Pacocha", "password123", 1, "Yessenia59" },
                    { 151, 105, "Gunnar_Kub38@hotmail.com", "Marjolaine", "Hessel", "password123", 1, "Ezequiel.Grimes" },
                    { 244, 126, "Leslie_Hills16@yahoo.com", "Manuel", "Nikolaus", "password123", 3, "Leonel.Pollich" },
                    { 225, 147, "Orion.Powlowski33@gmail.com", "Wilhelmine", "Borer", "password123", 1, "Kaylah33" },
                    { 249, 88, "Rachael62@gmail.com", "Dayton", "Hodkiewicz", "password123", 3, "Rafael.Kautzer" },
                    { 44, 88, "Verdie.Leannon26@gmail.com", "Korbin", "Leffler", "password123", 3, "Trever19" },
                    { 266, 27, "Tamara_West@gmail.com", "Arielle", "Gutkowski", "password123", 2, "Lesly_Ebert68" },
                    { 255, 27, "Ken73@yahoo.com", "Oliver", "Pagac", "password123", 3, "Joyce5" },
                    { 281, 99, "Edmund.Harber16@hotmail.com", "Tatyana", "O'Conner", "password123", 2, "Claire40" },
                    { 162, 15, "Crawford51@yahoo.com", "Vito", "Gleichner", "password123", 3, "Frankie.Champlin" },
                    { 290, 248, "Ericka42@yahoo.com", "Maverick", "McDermott", "password123", 2, "Ona_Hodkiewicz" },
                    { 145, 248, "Karen_Brown3@hotmail.com", "Genevieve", "Murphy", "password123", 3, "Velda3" },
                    { 4, 248, "Assunta84@gmail.com", "Philip", "Schaefer", "password123", 2, "Gordon.Doyle65" },
                    { 261, 113, "Johan59@gmail.com", "Susanna", "Schroeder", "password123", 3, "Tamia93" },
                    { 5, 42, "Celia_Franecki40@yahoo.com", "Camden", "Spinka", "password123", 3, "Elfrieda60" },
                    { 272, 145, "Lafayette.Walter87@yahoo.com", "Dannie", "Romaguera", "password123", 2, "Guy15" },
                    { 38, 145, "Maverick12@yahoo.com", "Juliana", "Klocko", "password123", 2, "Orpha92" },
                    { 83, 192, "Deron_Hilll@hotmail.com", "Dock", "Spencer", "password123", 3, "Trevion.OConnell78" },
                    { 273, 200, "Keanu_Gorczany42@hotmail.com", "Joshuah", "Jones", "password123", 3, "Frankie_McGlynn" },
                    { 242, 109, "Vinnie10@yahoo.com", "Betty", "Johns", "password123", 1, "Ari.Nienow16" },
                    { 280, 107, "Courtney40@yahoo.com", "Amanda", "Armstrong", "password123", 3, "Bobby.Bayer" },
                    { 71, 65, "Jerrold.DAmore@yahoo.com", "Betty", "Lynch", "password123", 3, "Alek.Harvey72" },
                    { 43, 298, "Annabell.Toy@gmail.com", "Isaias", "Rutherford", "password123", 3, "Mortimer92" },
                    { 143, 164, "Arne.DuBuque66@hotmail.com", "Jamil", "D'Amore", "password123", 3, "Hosea.Kemmer" },
                    { 299, 39, "Devonte_Prohaska43@hotmail.com", "Nola", "Ortiz", "password123", 3, "Jonas_Olson" },
                    { 176, 18, "Pierre_Brakus@yahoo.com", "Loy", "Kuphal", "password123", 2, "Jammie_Moore1" },
                    { 149, 18, "Emmy_Reichert88@yahoo.com", "Jaleel", "Kirlin", "password123", 2, "Maximo19" },
                    { 137, 18, "Emilie.Carter@hotmail.com", "Eliane", "Pfannerstill", "password123", 1, "Roel.Feest79" },
                    { 204, 258, "Wyman20@hotmail.com", "Anika", "Aufderhar", "password123", 2, "Adolph53" },
                    { 226, 256, "Scotty.Frami30@yahoo.com", "Sallie", "Prosacco", "password123", 2, "Loyce30" },
                    { 100, 256, "Rylee_Skiles@hotmail.com", "Brooke", "Considine", "password123", 3, "Corbin.Huels" },
                    { 64, 83, "Valentina.Mohr43@hotmail.com", "Yasmeen", "Willms", "password123", 3, "Columbus.Boehm" },
                    { 198, 12, "Zechariah_Considine11@gmail.com", "Leda", "Hirthe", "password123", 1, "Reyes20" },
                    { 57, 12, "Grady_Boyle76@yahoo.com", "Leilani", "Hessel", "password123", 2, "Caleb30" },
                    { 240, 278, "Luz2@hotmail.com", "Rupert", "Runolfsdottir", "password123", 2, "Alena.Kassulke" },
                    { 158, 273, "Anderson8@gmail.com", "Birdie", "Hodkiewicz", "password123", 3, "Anya_Roob36" },
                    { 87, 273, "Ricardo_Jakubowski@gmail.com", "Jaylin", "Rippin", "password123", 3, "Jairo.Turcotte" },
                    { 45, 273, "Providenci98@hotmail.com", "Paolo", "Yost", "password123", 3, "Jayson6" },
                    { 246, 120, "Maybelle.Doyle43@gmail.com", "Brandi", "Kutch", "password123", 2, "Hulda81" },
                    { 181, 120, "Aliyah_Bins97@gmail.com", "Evert", "Heidenreich", "password123", 1, "Maryse90" },
                    { 125, 65, "Nannie_Mraz40@yahoo.com", "Adolph", "Towne", "password123", 3, "Retta61" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 26, 109, "Reyes.Schinner@yahoo.com", "Ebony", "Moen", "password123", 1, "Kevin_Pollich81" },
                    { 91, 219, "Rod.King@yahoo.com", "Abdiel", "Hermiston", "password123", 1, "Karlee.Gislason" },
                    { 11, 85, "Amos62@hotmail.com", "Niko", "Hermann", "password123", 2, "Jaylen29" },
                    { 136, 289, "Carlee.Breitenberg30@yahoo.com", "Viva", "Spinka", "password123", 2, "Gunnar_Prohaska" },
                    { 81, 289, "Selmer79@hotmail.com", "Ciara", "Rath", "password123", 1, "Westley_Rodriguez39" },
                    { 23, 289, "Shaniya30@yahoo.com", "Matilde", "Ward", "password123", 3, "Zita31" },
                    { 20, 289, "Tina77@yahoo.com", "Rossie", "Christiansen", "password123", 1, "Jackson_OConnell12" },
                    { 106, 69, "Ralph51@hotmail.com", "Camilla", "Huel", "password123", 1, "Nicola.Collier" },
                    { 278, 283, "Elta38@hotmail.com", "Reynold", "Williamson", "password123", 3, "Bernadette.Kozey" },
                    { 31, 247, "Lauriane_Wehner58@gmail.com", "Eulalia", "Toy", "password123", 1, "Austin39" },
                    { 254, 114, "Luz_Hauck@yahoo.com", "Mikayla", "Streich", "password123", 1, "Nikko99" },
                    { 267, 46, "Annabell37@hotmail.com", "Jordy", "Tromp", "password123", 1, "Jarrell.Maggio" },
                    { 10, 159, "Destany.Balistreri61@gmail.com", "Abigail", "Quigley", "password123", 1, "Elinore_Stark" },
                    { 274, 137, "Jacques.Orn49@yahoo.com", "Lucile", "Hansen", "password123", 1, "Elisabeth.Prosacco13" },
                    { 190, 128, "Vida_Sanford@hotmail.com", "Timmothy", "Kessler", "password123", 3, "Annabelle9" },
                    { 237, 47, "Maurice91@gmail.com", "Zoila", "Franecki", "password123", 1, "Keyshawn15" },
                    { 95, 47, "Kiel_Walsh@hotmail.com", "Madison", "Batz", "password123", 1, "Fredrick.Tremblay" },
                    { 286, 19, "Shanny.Kulas19@gmail.com", "Aurelie", "Harris", "password123", 2, "Brooklyn_Lowe" },
                    { 208, 215, "Ambrose_Cartwright@yahoo.com", "Van", "Price", "password123", 1, "Margarett_Bernhard" },
                    { 134, 215, "Tracy84@gmail.com", "Cecilia", "Balistreri", "password123", 2, "Everett.Braun64" },
                    { 101, 215, "Sandrine.Mraz39@yahoo.com", "Eliseo", "Graham", "password123", 2, "Nellie_Ferry" },
                    { 54, 215, "Erna.Durgan@gmail.com", "Magdalena", "Aufderhar", "password123", 3, "Harley73" },
                    { 200, 30, "Kacey53@yahoo.com", "Vaughn", "Klein", "password123", 2, "Claud_Gottlieb70" },
                    { 153, 173, "Ebba63@yahoo.com", "Edwin", "Larkin", "password123", 2, "Agustin78" },
                    { 235, 206, "Vernice_Veum33@gmail.com", "Casandra", "Bechtelar", "password123", 2, "Leta.Jacobs" },
                    { 116, 202, "Jeanne4@hotmail.com", "Frieda", "Nicolas", "password123", 1, "Jermaine94" },
                    { 9, 297, "Juliana83@hotmail.com", "Mabel", "Schowalter", "password123", 1, "Savion.Johnson" },
                    { 170, 222, "Marianne_Swift1@yahoo.com", "Jan", "Kohler", "password123", 3, "King74" },
                    { 110, 36, "Eriberto13@yahoo.com", "Jamar", "Zemlak", "password123", 1, "Lillie.Hackett40" },
                    { 60, 142, "Pascale62@hotmail.com", "Thaddeus", "Yost", "password123", 1, "Unique.Bradtke2" },
                    { 76, 68, "Mason.Morissette15@hotmail.com", "Maybell", "Corwin", "password123", 2, "Rusty42" },
                    { 74, 68, "Odie.Smitham58@gmail.com", "Vena", "Deckow", "password123", 3, "Colton11" },
                    { 228, 277, "Leonard.Cassin@gmail.com", "Fern", "Rohan", "password123", 2, "Zella.Bosco62" },
                    { 30, 277, "Porter63@yahoo.com", "Trenton", "Mitchell", "password123", 2, "Foster36" },
                    { 102, 291, "Sheridan_Tromp52@hotmail.com", "Edwin", "Kuhlman", "password123", 2, "Emil40" },
                    { 79, 291, "Micaela.Raynor86@hotmail.com", "Gregory", "Nikolaus", "password123", 3, "Braeden_Herzog15" },
                    { 1, 274, "Gregoria.Keebler61@gmail.com", "Reynold", "Gottlieb", "password123", 2, "Lawson_Waelchi" },
                    { 119, 218, "Dejah_Hills54@gmail.com", "Gordon", "Waelchi", "password123", 3, "Kacey.Aufderhar89" },
                    { 252, 235, "Estel.Stanton35@hotmail.com", "Cayla", "Zieme", "password123", 3, "Dane1" },
                    { 6, 251, "Hyman_Reilly34@yahoo.com", "Ariel", "Blick", "password123", 3, "Alivia21" },
                    { 232, 115, "Della21@yahoo.com", "Baylee", "Powlowski", "password123", 2, "Colten_West" },
                    { 88, 115, "Madeline.Romaguera@gmail.com", "Carol", "Howell", "password123", 1, "Akeem.Cassin" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 86, 115, "Maxwell42@yahoo.com", "Declan", "Dietrich", "password123", 1, "Vaughn86" },
                    { 253, 100, "Vito_Hoeger90@yahoo.com", "Jedediah", "Donnelly", "password123", 2, "Anika32" },
                    { 227, 3, "Taya11@hotmail.com", "Ashton", "Kuvalis", "password123", 1, "Ansel.Luettgen" },
                    { 171, 263, "Orlando.Waelchi@hotmail.com", "Earlene", "Erdman", "password123", 2, "Cayla_Kuvalis10" },
                    { 96, 224, "Judah.Douglas85@hotmail.com", "Judd", "Kutch", "password123", 1, "Josefina_Feil" },
                    { 197, 263, "Maria72@yahoo.com", "Mitchel", "Cummerata", "password123", 3, "Phoebe_Roob" },
                    { 218, 197, "Holly_Bailey71@yahoo.com", "Taurean", "Jones", "password123", 3, "Evans.Osinski" },
                    { 52, 160, "Eliseo.Goldner87@hotmail.com", "Dejuan", "Rutherford", "password123", 1, "Brendon86" },
                    { 263, 240, "Ardella88@gmail.com", "Courtney", "Quitzon", "password123", 1, "Sheridan_Gulgowski82" },
                    { 203, 240, "Junior8@gmail.com", "Joaquin", "Strosin", "password123", 1, "Tristian_Trantow" },
                    { 41, 240, "Ambrose.Leffler26@yahoo.com", "Narciso", "Block", "password123", 2, "Rossie_Waters12" },
                    { 50, 176, "Jacinto_Wiegand65@yahoo.com", "Clifford", "Botsford", "password123", 1, "Ramiro98" },
                    { 277, 112, "Domenico.Mitchell@hotmail.com", "Bonita", "Doyle", "password123", 1, "Eva.Schulist" },
                    { 238, 198, "Ramona_Okuneva@yahoo.com", "Tanya", "Emmerich", "password123", 1, "Yessenia.Schowalter" },
                    { 222, 67, "Arnoldo_Hermiston14@hotmail.com", "Kim", "Reinger", "password123", 3, "Kristina.Satterfield" },
                    { 221, 67, "Calista.Auer42@yahoo.com", "Dax", "Tromp", "password123", 1, "Adeline5" },
                    { 180, 67, "Juston_Aufderhar58@yahoo.com", "Gloria", "Heller", "password123", 3, "Reggie_Kris" },
                    { 53, 67, "Raphaelle43@gmail.com", "Granville", "Schroeder", "password123", 2, "Berry.Thompson" },
                    { 178, 211, "Braeden_Jaskolski20@gmail.com", "Shaun", "Schiller", "password123", 2, "Regan1" },
                    { 12, 211, "Rocky.Gusikowski13@hotmail.com", "Madisen", "Kuhlman", "password123", 1, "Friedrich_Bode4" },
                    { 224, 182, "Jakob_Corwin@hotmail.com", "Ellis", "Langosh", "password123", 2, "Peggie86" },
                    { 111, 182, "Waylon_Dicki@gmail.com", "Callie", "Lesch", "password123", 1, "Frida75" },
                    { 258, 141, "Laurianne_Lynch@hotmail.com", "Willa", "Rau", "password123", 3, "Frederik2" },
                    { 97, 141, "Michele12@yahoo.com", "Wilfredo", "Stokes", "password123", 3, "Katarina6" },
                    { 13, 150, "Kristofer.Luettgen51@gmail.com", "Felicia", "Williamson", "password123", 2, "Kayli_Miller" },
                    { 68, 61, "Roderick0@yahoo.com", "Genoveva", "Quigley", "password123", 3, "Elena.Auer" },
                    { 62, 197, "Edward_Schmidt86@gmail.com", "Christophe", "Rodriguez", "password123", 1, "Eladio.Deckow" },
                    { 271, 32, "Sophie_White31@yahoo.com", "Estel", "Mayer", "password123", 3, "Darryl42" },
                    { 182, 31, "Kenyatta.Lueilwitz85@gmail.com", "Ward", "Hodkiewicz", "password123", 3, "Emilio11" },
                    { 163, 14, "Geo.Kerluke@hotmail.com", "Julianne", "Stamm", "password123", 1, "Ethel53" },
                    { 8, 281, "Unique7@yahoo.com", "Gino", "Kuhn", "password123", 3, "Emilie_Champlin" },
                    { 28, 172, "Porter_Kilback@gmail.com", "Tony", "Harber", "password123", 3, "Garnet.Greenholt30" },
                    { 15, 172, "Jerel.Langworth@hotmail.com", "Gilbert", "Goldner", "password123", 2, "Brendon_Gusikowski72" },
                    { 202, 127, "Tyra_Kovacek@hotmail.com", "Chelsea", "Cremin", "password123", 3, "Lucas_Orn" },
                    { 275, 241, "Elliott_Greenfelder36@hotmail.com", "Alberta", "Ryan", "password123", 2, "Mariana_Corkery" },
                    { 260, 194, "Lowell60@gmail.com", "Alexie", "Flatley", "password123", 3, "Theodora_Monahan10" },
                    { 109, 194, "Gia92@hotmail.com", "Luella", "Macejkovic", "password123", 2, "Kennith_McClure6" },
                    { 40, 152, "Trever41@yahoo.com", "Marge", "Langworth", "password123", 1, "Annie.Weissnat" },
                    { 85, 16, "Kelsi.Brown52@gmail.com", "Camille", "Bashirian", "password123", 2, "Brice.Skiles" },
                    { 231, 9, "Justus60@hotmail.com", "Frederick", "Zieme", "password123", 1, "Isai_Mosciski91" },
                    { 288, 168, "Cecilia23@yahoo.com", "Chris", "Sanford", "password123", 2, "Chelsey.Zulauf14" },
                    { 166, 168, "Willy_Cummings10@gmail.com", "Jairo", "Koch", "password123", 3, "Josephine_Bailey" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CityId", "Email", "FirstName", "LastName", "Password", "RoleId", "Username" },
                values: new object[,]
                {
                    { 93, 168, "Furman67@gmail.com", "Enid", "Crist", "password123", 3, "Uriel.Nikolaus" },
                    { 25, 184, "Grover_Walsh53@yahoo.com", "Julius", "Beatty", "password123", 2, "Tom.Bauch" },
                    { 250, 108, "Margarette.Carroll79@yahoo.com", "Jonathan", "Volkman", "password123", 1, "Nick_Davis" },
                    { 219, 108, "Kristy_Rempel69@hotmail.com", "Barry", "Fritsch", "password123", 3, "Grayson.Rutherford85" },
                    { 94, 108, "Rebeca61@yahoo.com", "Emma", "Ryan", "password123", 3, "Camylle_Wilderman" },
                    { 223, 202, "Pearlie15@hotmail.com", "Santiago", "Pollich", "password123", 3, "Savion83" },
                    { 120, 202, "Haylie62@hotmail.com", "Jacky", "Bailey", "password123", 3, "Jon33" },
                    { 33, 281, "Nasir.Parker85@yahoo.com", "Zoila", "Sauer", "password123", 3, "Ruthie70" },
                    { 39, 31, "Beth63@hotmail.com", "Elna", "Schneider", "password123", 1, "Morris.Thompson26" },
                    { 205, 281, "Arnulfo83@gmail.com", "Dayana", "Howe", "password123", 1, "Kelly9" },
                    { 265, 95, "Mireya.Johnson@hotmail.com", "Halie", "Hane", "password123", 1, "Georgiana_Douglas" },
                    { 124, 290, "Hal_Moore@yahoo.com", "Breana", "Goldner", "password123", 3, "Bobby_Grant" },
                    { 241, 266, "Clara.Rippin@gmail.com", "Herbert", "Oberbrunner", "password123", 2, "Trudie43" },
                    { 216, 266, "Betsy.Rempel@gmail.com", "Bryana", "Howe", "password123", 3, "Janie_Gutmann91" },
                    { 183, 266, "Ewell2@yahoo.com", "Immanuel", "Wolff", "password123", 3, "Kendall48" },
                    { 144, 266, "Marquis.Jerde82@yahoo.com", "Theodore", "Reilly", "password123", 3, "Roger31" },
                    { 168, 244, "Cletus_Crooks89@hotmail.com", "Austyn", "Weissnat", "password123", 3, "Nina76" },
                    { 177, 132, "Destin.Bosco24@yahoo.com", "Kassandra", "Cummings", "password123", 2, "Cali8" },
                    { 51, 132, "Lauriane_Wehner53@gmail.com", "Kamryn", "Boyer", "password123", 1, "April74" },
                    { 279, 84, "Berneice.Haag77@gmail.com", "Dahlia", "Borer", "password123", 2, "Mateo_Cummerata75" },
                    { 268, 84, "Dan_Carter@hotmail.com", "Josefina", "Treutel", "password123", 3, "Adella92" },
                    { 146, 84, "Abagail.Shields@yahoo.com", "Hulda", "Dickens", "password123", 1, "Tomasa_DuBuque" },
                    { 239, 212, "Emilia73@gmail.com", "Bernadette", "Runolfsson", "password123", 2, "Moriah51" },
                    { 184, 17, "Cyril_Bruen@yahoo.com", "Haskell", "Okuneva", "password123", 2, "Leopold87" },
                    { 154, 227, "Antoinette_Dibbert24@gmail.com", "Marcelo", "Franecki", "password123", 1, "Sid.Roob" },
                    { 61, 227, "Laurianne32@yahoo.com", "Erich", "Emmerich", "password123", 3, "Vicente18" },
                    { 29, 227, "Bert_Mitchell@yahoo.com", "Floyd", "Marvin", "password123", 2, "Nedra.Brekke37" },
                    { 90, 148, "Theo11@hotmail.com", "Shyann", "Heaney", "password123", 1, "Alexandro34" },
                    { 7, 148, "Camylle6@yahoo.com", "Yasmin", "Nolan", "password123", 2, "Rosa_Schuppe" },
                    { 230, 193, "Keshaun_Ferry@gmail.com", "Pearline", "Corkery", "password123", 2, "Keenan19" },
                    { 75, 95, "Charlotte_Conn27@gmail.com", "Shany", "Gerlach", "password123", 1, "Ferne_Powlowski" },
                    { 103, 175, "Alvera.Wilkinson@yahoo.com", "Olin", "Strosin", "password123", 1, "Sonia88" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 47, "Reichert Inlet", 283, "Mervin.Koepp90@yahoo.com", "Feeney and Sons", 45, "(474) 888-8239", "www.Feeney and Sons.com" },
                    { 66, "Ubaldo Mission", 242, "Helene68@yahoo.com", "Hansen - King", 256, "(771) 035-9749", "www.Hansen - King.com" },
                    { 34, "Flatley Mount", 3, "Jarvis_Crona@gmail.com", "Kshlerin - Wolf", 155, "(168) 525-8929", "www.Kshlerin - Wolf.com" },
                    { 115, "Robel Crest", 99, "Sim.Cassin50@gmail.com", "Hauck LLC", 155, "(255) 036-0017", "www.Hauck LLC.com" },
                    { 1, "Imani Freeway", 88, "Dena_Lind84@hotmail.com", "Harber Group", 161, "(442) 294-0033", "www.Harber Group.com" },
                    { 139, "Rudolph Route", 220, "Stephon.Schoen98@hotmail.com", "Stiedemann - Wisoky", 42, "(354) 329-4326", "www.Stiedemann - Wisoky.com" },
                    { 31, "Gust Loaf", 237, "Kiarra_Yost0@hotmail.com", "Swaniawski, Lueilwitz and Conn", 117, "(007) 285-8570", "www.Swaniawski, Lueilwitz and Conn.com" },
                    { 49, "Jolie Meadow", 19, "Parker.Erdman@hotmail.com", "Block, Hauck and Harber", 117, "(692) 321-4136", "www.Block, Hauck and Harber.com" },
                    { 73, "Zaria Highway", 234, "Kenna_VonRueden73@hotmail.com", "Emard Group", 117, "(589) 903-0588", "www.Emard Group.com" },
                    { 126, "Baron Track", 167, "Zoie0@yahoo.com", "Rohan - Feil", 117, "(754) 716-9349", "www.Rohan - Feil.com" },
                    { 128, "Hegmann Drive", 137, "Jewel21@hotmail.com", "Goodwin - Rath", 117, "(184) 815-0350", "www.Goodwin - Rath.com" },
                    { 119, "Lizeth Estates", 199, "Andy86@hotmail.com", "Langosh, Kreiger and Becker", 122, "(189) 852-8084", "www.Langosh, Kreiger and Becker.com" },
                    { 145, "Hayley Canyon", 85, "Lura1@hotmail.com", "Hane, Jakubowski and Von", 122, "(599) 099-0445", "www.Hane, Jakubowski and Von.com" },
                    { 146, "Carter Ridges", 129, "Kailey.Wolf@yahoo.com", "Beier, Homenick and Kessler", 122, "(345) 972-8339", "www.Beier, Homenick and Kessler.com" },
                    { 39, "Raymond Causeway", 230, "Nikki0@yahoo.com", "Lubowitz, Hegmann and Hahn", 196, "(529) 861-9261", "www.Lubowitz, Hegmann and Hahn.com" },
                    { 78, "Rath River", 235, "Hillard.Pfannerstill@yahoo.com", "O'Reilly - Wilderman", 19, "(248) 940-9859", "www.O'Reilly - Wilderman.com" },
                    { 5, "Murl Cliffs", 221, "Earl.Nienow9@hotmail.com", "Harvey - Sipes", 256, "(304) 731-8619", "www.Harvey - Sipes.com" },
                    { 22, "Mante Fields", 236, "Ted_Murray74@hotmail.com", "Bosco - Predovic", 156, "(091) 524-8520", "www.Bosco - Predovic.com" },
                    { 125, "Guiseppe Meadows", 76, "Adelia_Kling@hotmail.com", "Collier - Kozey", 179, "(031) 875-4810", "www.Collier - Kozey.com" },
                    { 29, "Bruen Row", 290, "Christophe.Parker@yahoo.com", "Kreiger, Gaylord and Cruickshank", 141, "(416) 632-2500", "www.Kreiger, Gaylord and Cruickshank.com" },
                    { 32, "Lavina Square", 116, "Melody_Kerluke@gmail.com", "McCullough and Sons", 170, "(417) 236-3467", "www.McCullough and Sons.com" },
                    { 48, "Graham Way", 243, "Shyanne27@yahoo.com", "McKenzie, Brakus and Gaylord", 170, "(533) 456-0622", "www.McKenzie, Brakus and Gaylord.com" },
                    { 70, "Hoppe Orchard", 176, "Walter_Botsford40@gmail.com", "Pagac LLC", 197, "(470) 290-3660", "www.Pagac LLC.com" },
                    { 97, "Bartell Throughway", 63, "Lucienne91@hotmail.com", "Hessel - Nikolaus", 197, "(891) 399-8874", "www.Hessel - Nikolaus.com" },
                    { 6, "Emelie Hill", 250, "Fanny_Wehner@yahoo.com", "D'Amore - Jenkins", 68, "(322) 065-8221", "www.D'Amore - Jenkins.com" },
                    { 111, "Kihn Village", 27, "Ashtyn.Torp50@gmail.com", "Boehm - Ortiz", 68, "(847) 214-9900", "www.Boehm - Ortiz.com" },
                    { 67, "Bart Turnpike", 296, "Elouise.Nicolas@gmail.com", "Bashirian LLC", 97, "(242) 738-4359", "www.Bashirian LLC.com" },
                    { 83, "Rodrigo Hills", 14, "Aryanna80@gmail.com", "Yost - Zulauf", 97, "(014) 988-0508", "www.Yost - Zulauf.com" },
                    { 135, "Diana Ranch", 182, "Jo_Fay19@hotmail.com", "Nikolaus - Luettgen", 97, "(695) 944-4679", "www.Nikolaus - Luettgen.com" },
                    { 110, "Breitenberg Turnpike", 22, "Billie.Beahan@hotmail.com", "Ebert LLC", 180, "(301) 355-8718", "www.Ebert LLC.com" },
                    { 133, "Greta Throughway", 291, "Gregorio.Kessler@hotmail.com", "Brown - Nienow", 180, "(452) 914-4643", "www.Brown - Nienow.com" },
                    { 127, "Erika Gateway", 193, "Orland22@gmail.com", "Rippin - Monahan", 222, "(162) 192-2582", "www.Rippin - Monahan.com" },
                    { 132, "Gillian Underpass", 173, "Hayley_Harris@gmail.com", "Effertz LLC", 222, "(916) 336-4884", "www.Effertz LLC.com" },
                    { 13, "Gordon Club", 240, "Winnifred_Wilderman@gmail.com", "Reinger and Sons", 130, "(401) 943-0187", "www.Reinger and Sons.com" },
                    { 24, "Carmela Station", 212, "Krystel.Crist27@gmail.com", "Mosciski, Veum and Schultz", 141, "(428) 931-9624", "www.Mosciski, Veum and Schultz.com" },
                    { 53, "Arnold Land", 11, "Donnie_Schmeler@gmail.com", "Zboncak Group", 141, "(213) 381-3289", "www.Zboncak Group.com" },
                    { 40, "Remington Bypass", 35, "Elena.Zemlak@gmail.com", "Hilpert - Maggio", 74, "(624) 646-4498", "www.Hilpert - Maggio.com" },
                    { 96, "Olin Extensions", 21, "Ephraim.Hauck@hotmail.com", "Funk Inc", 156, "(518) 669-1579", "www.Funk Inc.com" },
                    { 100, "Hilpert Mountain", 147, "Dorothea_Crona2@hotmail.com", "Weissnat - Walsh", 213, "(367) 670-6637", "www.Weissnat - Walsh.com" },
                    { 45, "Stehr Lodge", 90, "Elvera.Kautzer@yahoo.com", "Conn, Gutkowski and Runolfsson", 132, "(501) 693-1154", "www.Conn, Gutkowski and Runolfsson.com" },
                    { 51, "Gilberto Crescent", 157, "Fanny77@hotmail.com", "Lubowitz - Hermiston", 132, "(459) 609-3414", "www.Lubowitz - Hermiston.com" },
                    { 62, "Lambert Loaf", 36, "Caroline73@yahoo.com", "Hermann, Streich and Runte", 132, "(455) 778-6632", "www.Hermann, Streich and Runte.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 101, "Fahey Trail", 24, "Tatyana.Kertzmann86@yahoo.com", "Sawayn - Ferry", 132, "(332) 068-0047", "www.Sawayn - Ferry.com" },
                    { 21, "Hattie Station", 269, "Geovany_Smitham11@gmail.com", "MacGyver - Oberbrunner", 217, "(866) 344-6347", "www.MacGyver - Oberbrunner.com" },
                    { 137, "Homenick Track", 52, "Jerrold_Veum@gmail.com", "Hoppe, Nienow and Kihn", 217, "(950) 130-2041", "www.Hoppe, Nienow and Kihn.com" },
                    { 9, "Kemmer Summit", 210, "Demarcus_Collier50@yahoo.com", "Tremblay and Sons", 233, "(060) 217-0012", "www.Tremblay and Sons.com" },
                    { 63, "Ken Unions", 102, "Isabella.Hyatt@gmail.com", "Prosacco, Cole and Weimann", 233, "(968) 821-5610", "www.Prosacco, Cole and Weimann.com" },
                    { 113, "Walter Passage", 252, "Alfred.Kohler51@yahoo.com", "Waters and Sons", 78, "(331) 994-0774", "www.Waters and Sons.com" },
                    { 72, "Abbott Flat", 98, "Ignacio.Macejkovic@hotmail.com", "Ward, Cremin and Lowe", 34, "(594) 080-8298", "www.Ward, Cremin and Lowe.com" },
                    { 95, "Casper Spring", 178, "Brenden7@hotmail.com", "Waters - West", 34, "(786) 982-6107", "www.Waters - West.com" },
                    { 104, "Miller Shore", 194, "Shyann65@hotmail.com", "Ledner LLC", 34, "(434) 498-3022", "www.Ledner LLC.com" },
                    { 2, "Giovanny Via", 101, "Diego.Hauck17@hotmail.com", "Witting, Kassulke and Greenholt", 187, "(755) 306-6161", "www.Witting, Kassulke and Greenholt.com" },
                    { 121, "Fay Tunnel", 112, "Glenna38@yahoo.com", "Strosin - Howell", 187, "(733) 428-8095", "www.Strosin - Howell.com" },
                    { 18, "Seth Rest", 1, "Loyal99@hotmail.com", "Glover, Sauer and Mayer", 139, "(162) 088-5914", "www.Glover, Sauer and Mayer.com" },
                    { 42, "Emard Haven", 130, "Tyree17@hotmail.com", "Streich, Quitzon and Reichel", 194, "(280) 254-1361", "www.Streich, Quitzon and Reichel.com" },
                    { 71, "Roob Dale", 280, "Anderson_Jast@yahoo.com", "Satterfield Inc", 213, "(798) 520-5804", "www.Satterfield Inc.com" },
                    { 99, "Colton Square", 214, "Colten_McCullough70@hotmail.com", "Mills Group", 247, "(437) 185-1645", "www.Mills Group.com" },
                    { 84, "Winnifred Circle", 184, "Mauricio68@hotmail.com", "Kuvalis, Gottlieb and Hand", 82, "(103) 774-8396", "www.Kuvalis, Gottlieb and Hand.com" },
                    { 138, "Laverna Shoals", 228, "Dennis_Beer51@gmail.com", "Macejkovic, Hand and Howe", 195, "(843) 416-4631", "www.Macejkovic, Hand and Howe.com" },
                    { 91, "Francesca Summit", 38, "Rosina_Spinka3@yahoo.com", "Gislason LLC", 165, "(875) 179-7882", "www.Gislason LLC.com" },
                    { 118, "Craig Way", 110, "Agnes42@gmail.com", "Bednar Group", 165, "(298) 463-2477", "www.Bednar Group.com" },
                    { 68, "Murray Camp", 201, "Keshaun69@hotmail.com", "Roob, Hilpert and Veum", 297, "(151) 157-4279", "www.Roob, Hilpert and Veum.com" },
                    { 117, "Ibrahim Corner", 274, "Santino_Zulauf84@yahoo.com", "Hickle, Collier and Stanton", 297, "(391) 550-1625", "www.Hickle, Collier and Stanton.com" },
                    { 150, "Martin Fords", 224, "Fredrick_Green97@hotmail.com", "Schuppe, Durgan and Wisozk", 297, "(755) 272-7952", "www.Schuppe, Durgan and Wisozk.com" },
                    { 10, "Melvina Street", 185, "Saige.Schuster43@yahoo.com", "Tillman Inc", 36, "(893) 889-5056", "www.Tillman Inc.com" },
                    { 130, "Thiel Pines", 231, "Kris.Blanda28@gmail.com", "Moen, Jast and Mitchell", 36, "(255) 998-3461", "www.Moen, Jast and Mitchell.com" },
                    { 120, "Gibson Shoal", 91, "Ezequiel_Towne@yahoo.com", "O'Kon Inc", 98, "(799) 859-5074", "www.O'Kon Inc.com" },
                    { 143, "Lockman Drive", 27, "Khalid98@gmail.com", "Hamill LLC", 98, "(346) 171-9070", "www.Hamill LLC.com" },
                    { 123, "Vincenza Forks", 127, "Naomie18@hotmail.com", "Stracke, Corwin and Koelpin", 115, "(315) 191-2229", "www.Stracke, Corwin and Koelpin.com" },
                    { 17, "Emile Lane", 140, "Kole.Runte@hotmail.com", "Hoeger, Abshire and Lueilwitz", 135, "(387) 361-6246", "www.Hoeger, Abshire and Lueilwitz.com" },
                    { 86, "McLaughlin Pine", 182, "Guillermo47@yahoo.com", "Dicki, Bradtke and Trantow", 35, "(318) 218-0210", "www.Dicki, Bradtke and Trantow.com" },
                    { 88, "Seth Squares", 287, "Ally_Stroman37@gmail.com", "Gleason, Borer and Nitzsche", 35, "(162) 509-3104", "www.Gleason, Borer and Nitzsche.com" },
                    { 36, "White Hollow", 226, "Kip25@gmail.com", "Breitenberg, Mann and Blick", 82, "(164) 386-9893", "www.Breitenberg, Mann and Blick.com" },
                    { 75, "Wolf Street", 110, "Coleman70@hotmail.com", "Brekke, Streich and Walsh", 247, "(235) 545-5781", "www.Brekke, Streich and Walsh.com" },
                    { 3, "Labadie Point", 169, "Michaela_McKenzie@yahoo.com", "Hintz, Turner and Hegmann", 79, "(833) 036-4891", "www.Hintz, Turner and Hegmann.com" },
                    { 60, "Marquise Parks", 123, "Clyde.Graham@yahoo.com", "Sauer Inc", 35, "(983) 629-2929", "www.Sauer Inc.com" },
                    { 141, "Scottie Island", 116, "Markus23@yahoo.com", "Stiedemann Inc", 252, "(704) 618-4320", "www.Stiedemann Inc.com" },
                    { 7, "Alvina Trail", 148, "Willow15@hotmail.com", "Luettgen, Zboncak and Nader", 282, "(298) 756-9790", "www.Luettgen, Zboncak and Nader.com" },
                    { 81, "Haskell Course", 169, "Grover31@gmail.com", "Adams - Heathcote", 282, "(682) 794-2403", "www.Adams - Heathcote.com" },
                    { 90, "McKenzie Springs", 230, "Tabitha48@hotmail.com", "Reynolds - Bernier", 282, "(658) 018-1588", "www.Reynolds - Bernier.com" },
                    { 116, "Liana Circle", 269, "Ursula.Marquardt@hotmail.com", "Halvorson - Bechtelar", 282, "(795) 611-7582", "www.Halvorson - Bechtelar.com" },
                    { 124, "O'Conner Village", 112, "Lori65@gmail.com", "Hamill Group", 282, "(161) 178-5643", "www.Hamill Group.com" },
                    { 37, "Maxime Manors", 66, "Treva_Emmerich14@hotmail.com", "Auer, Volkman and Ruecker", 167, "(247) 569-5808", "www.Auer, Volkman and Ruecker.com" },
                    { 105, "Connelly Ville", 138, "Deven_Shields14@gmail.com", "Runolfsson - Will", 243, "(576) 913-6891", "www.Runolfsson - Will.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 44, "Edythe Green", 255, "Trenton_Bogan2@hotmail.com", "Lynch - Hermiston", 157, "(182) 018-4033", "www.Lynch - Hermiston.com" },
                    { 136, "Welch Union", 133, "Allene89@yahoo.com", "Lehner - Homenick", 264, "(005) 117-4509", "www.Lehner - Homenick.com" },
                    { 11, "Brice Haven", 74, "Cornell_Friesen93@gmail.com", "Gibson and Sons", 83, "(305) 471-5777", "www.Gibson and Sons.com" },
                    { 4, "Cassandre Grove", 171, "Antwan_Hessel@gmail.com", "Trantow Group", 5, "(595) 370-6016", "www.Trantow Group.com" },
                    { 15, "Gleason Hill", 141, "Norval25@gmail.com", "Casper LLC", 5, "(110) 344-4317", "www.Casper LLC.com" },
                    { 93, "Reinhold Loaf", 286, "Ellen.Jacobson31@hotmail.com", "Marvin - Beer", 261, "(536) 011-1062", "www.Marvin - Beer.com" },
                    { 61, "Olson Centers", 25, "Lesley.Schinner@yahoo.com", "Murazik - Legros", 145, "(008) 504-9122", "www.Murazik - Legros.com" },
                    { 26, "Gonzalo Greens", 245, "Christa6@hotmail.com", "Ullrich, Berge and Kunze", 162, "(553) 732-3151", "www.Ullrich, Berge and Kunze.com" },
                    { 87, "Gutmann Point", 207, "Yessenia_Monahan62@yahoo.com", "Beahan, Volkman and Sawayn", 262, "(780) 201-2602", "www.Beahan, Volkman and Sawayn.com" },
                    { 28, "Wilderman Stravenue", 137, "Marc.Strosin@hotmail.com", "Auer, Schuster and Kirlin", 162, "(455) 570-5344", "www.Auer, Schuster and Kirlin.com" },
                    { 142, "Euna Manor", 72, "Jermaine_Kulas@gmail.com", "Monahan LLC", 280, "(850) 250-2971", "www.Monahan LLC.com" },
                    { 12, "Reagan Heights", 286, "Darren31@gmail.com", "Gusikowski - Huels", 23, "(060) 582-1570", "www.Gusikowski - Huels.com" },
                    { 129, "Gonzalo Parkway", 82, "Broderick_Welch48@yahoo.com", "Schimmel, Hansen and Rau", 119, "(637) 410-9188", "www.Schimmel, Hansen and Rau.com" },
                    { 112, "Rolfson Field", 279, "Dianna_Fadel3@hotmail.com", "Parker, Wintheiser and Shanahan", 158, "(353) 306-0242", "www.Parker, Wintheiser and Shanahan.com" },
                    { 52, "Claudine Parks", 3, "Jessy.Abshire40@hotmail.com", "Donnelly, Schaden and Will", 100, "(695) 323-7636", "www.Donnelly, Schaden and Will.com" },
                    { 92, "Grady Prairie", 278, "Gillian1@hotmail.com", "Kuvalis and Sons", 100, "(331) 448-7849", "www.Kuvalis and Sons.com" },
                    { 19, "Daisy Well", 53, "Louie.Hermann12@hotmail.com", "Schowalter - Howell", 299, "(042) 259-5610", "www.Schowalter - Howell.com" },
                    { 46, "Leif Roads", 211, "Granville.Keeling11@gmail.com", "Frami - Cummerata", 143, "(396) 747-8279", "www.Frami - Cummerata.com" },
                    { 77, "Purdy Parkways", 199, "Fay.Ullrich@yahoo.com", "Botsford, Torphy and Blanda", 143, "(353) 817-0525", "www.Botsford, Torphy and Blanda.com" },
                    { 82, "Casper Lodge", 45, "Earnestine7@hotmail.com", "Medhurst, Bartell and Turcotte", 71, "(961) 157-5012", "www.Medhurst, Bartell and Turcotte.com" },
                    { 148, "Cormier Estate", 254, "Kenna.Brakus@hotmail.com", "Adams LLC", 71, "(784) 374-6989", "www.Adams LLC.com" },
                    { 8, "Stiedemann Run", 164, "Betsy.Romaguera@hotmail.com", "Wisoky - Gusikowski", 125, "(391) 387-9572", "www.Wisoky - Gusikowski.com" },
                    { 103, "Beer View", 113, "Niko_Wiza@hotmail.com", "Gottlieb Inc", 125, "(655) 347-8531", "www.Gottlieb Inc.com" },
                    { 131, "Kovacek Lights", 81, "Unique_Armstrong88@gmail.com", "Pagac - Bins", 125, "(559) 303-7738", "www.Pagac - Bins.com" },
                    { 43, "Leonardo Port", 115, "Kamron1@hotmail.com", "Yundt - O'Reilly", 190, "(796) 505-7187", "www.Yundt - O'Reilly.com" },
                    { 69, "Kurtis Square", 116, "Elwin.Prosacco99@hotmail.com", "Kshlerin LLC", 278, "(170) 451-7040", "www.Kshlerin LLC.com" },
                    { 89, "Kerluke Ways", 172, "Alisha11@gmail.com", "Schmidt and Sons", 278, "(920) 428-0595", "www.Schmidt and Sons.com" },
                    { 30, "Caterina Pines", 72, "Schuyler25@yahoo.com", "O'Connell - Carter", 280, "(329) 465-2593", "www.O'Connell - Carter.com" },
                    { 122, "Friesen Lock", 109, "Hoyt86@gmail.com", "Johns and Sons", 255, "(359) 915-8348", "www.Johns and Sons.com" },
                    { 23, "Jaime Green", 223, "Cale_Bergnaum16@gmail.com", "Gerlach Group", 54, "(192) 046-9159", "www.Gerlach Group.com" },
                    { 107, "Kris Drives", 163, "Bradford_Gerlach49@yahoo.com", "Rosenbaum, Waters and Leuschke", 44, "(889) 043-1256", "www.Rosenbaum, Waters and Leuschke.com" },
                    { 144, "Schiller Tunnel", 74, "Kasey.Rowe37@hotmail.com", "Gottlieb, Abbott and Durgan", 268, "(677) 830-6358", "www.Gottlieb, Abbott and Durgan.com" },
                    { 54, "Amir Burgs", 118, "Paul87@yahoo.com", "Crist, Fisher and Botsford", 168, "(257) 677-6696", "www.Crist, Fisher and Botsford.com" },
                    { 109, "Deshaun Brooks", 218, "Pasquale_Stoltenberg57@yahoo.com", "Osinski LLC", 168, "(125) 702-3323", "www.Osinski LLC.com" },
                    { 106, "O'Hara Grove", 238, "Cameron.Rodriguez@hotmail.com", "Ferry Inc", 144, "(061) 276-4164", "www.Ferry Inc.com" },
                    { 25, "Kohler Camp", 19, "Cydney76@gmail.com", "O'Kon - Rau", 183, "(698) 057-3232", "www.O'Kon - Rau.com" },
                    { 108, "Taurean Ridge", 29, "Mattie62@yahoo.com", "Ledner - Rohan", 183, "(838) 347-1375", "www.Ledner - Rohan.com" },
                    { 149, "Antwon Tunnel", 169, "Mya_Graham@gmail.com", "D'Amore - Moore", 183, "(064) 527-9274", "www.D'Amore - Moore.com" },
                    { 33, "Rohan Roads", 280, "Lawrence63@hotmail.com", "Konopelski LLC", 216, "(462) 228-7784", "www.Konopelski LLC.com" },
                    { 57, "Maggie Drives", 56, "Janet6@yahoo.com", "Klocko - Steuber", 124, "(533) 242-7788", "www.Klocko - Steuber.com" },
                    { 140, "Dietrich Curve", 277, "Jeanne.Pouros9@yahoo.com", "Cruickshank, Deckow and Hammes", 124, "(100) 057-1630", "www.Cruickshank, Deckow and Hammes.com" },
                    { 14, "Kariane Mission", 268, "Evalyn69@yahoo.com", "Rogahn and Sons", 182, "(953) 619-5213", "www.Rogahn and Sons.com" }
                });

            migrationBuilder.InsertData(
                table: "CarServices",
                columns: new[] { "Id", "Address", "CityId", "Email", "Name", "OwnerId", "Phone", "Website" },
                values: new object[,]
                {
                    { 94, "Bogan Stravenue", 90, "Lesley91@hotmail.com", "Mante - Davis", 6, "(944) 053-1672", "www.Mante - Davis.com" },
                    { 102, "Niko Motorway", 222, "Irving_Murray@gmail.com", "Becker, Blick and Heaney", 6, "(592) 342-0842", "www.Becker, Blick and Heaney.com" },
                    { 80, "Juston Pass", 10, "Bennie.Crist@yahoo.com", "Shields, O'Connell and Huels", 44, "(162) 076-2545", "www.Shields, O'Connell and Huels.com" },
                    { 58, "McLaughlin Land", 96, "Hunter.Quigley@yahoo.com", "Bode and Sons", 252, "(537) 749-0984", "www.Bode and Sons.com" },
                    { 74, "Stefanie Dam", 49, "Sallie72@hotmail.com", "Beer, Deckow and Runte", 268, "(232) 560-2298", "www.Beer, Deckow and Runte.com" },
                    { 59, "Ollie Union", 95, "Kay_Harvey85@hotmail.com", "Hagenes - Hoeger", 61, "(408) 687-2054", "www.Hagenes - Hoeger.com" },
                    { 79, "Helena Hollow", 80, "Kelley73@hotmail.com", "Padberg, Wilkinson and Goyette", 216, "(894) 574-4565", "www.Padberg, Wilkinson and Goyette.com" },
                    { 76, "Efrain Forge", 109, "Mafalda.Steuber@yahoo.com", "Auer - Schowalter", 33, "(688) 028-2815", "www.Auer - Schowalter.com" },
                    { 20, "Karley Prairie", 35, "Anthony_Ankunding@yahoo.com", "Prohaska - Block", 249, "(877) 182-3032", "www.Prohaska - Block.com" },
                    { 16, "Flatley Mews", 2, "Lambert_Cassin4@gmail.com", "Treutel LLC", 249, "(431) 967-4127", "www.Treutel LLC.com" },
                    { 147, "Reichert Mission", 186, "Camille67@yahoo.com", "Heathcote - Schaefer", 33, "(478) 770-0155", "www.Heathcote - Schaefer.com" },
                    { 55, "Ethan Isle", 42, "Jess.Balistreri@hotmail.com", "Johnson, McDermott and Parisian", 244, "(063) 595-2192", "www.Johnson, McDermott and Parisian.com" },
                    { 27, "Herta Via", 241, "Layla90@yahoo.com", "Carter Inc", 271, "(585) 362-0978", "www.Carter Inc.com" },
                    { 85, "Orion Spur", 4, "Emilie.Stoltenberg@yahoo.com", "Bartoletti Group", 271, "(811) 944-6158", "www.Bartoletti Group.com" },
                    { 41, "Haag Point", 210, "Keyon.Kunde@gmail.com", "Abernathy Inc", 94, "(741) 958-7671", "www.Abernathy Inc.com" },
                    { 64, "Cartwright Village", 120, "Herminio_Denesik43@hotmail.com", "Bahringer, Herman and Borer", 94, "(052) 224-0636", "www.Bahringer, Herman and Borer.com" },
                    { 56, "Davis Light", 42, "Llewellyn_Jenkins@gmail.com", "Erdman, Runolfsdottir and Erdman", 223, "(981) 776-1890", "www.Erdman, Runolfsdottir and Erdman.com" },
                    { 35, "Beier Park", 145, "Edward94@yahoo.com", "Graham and Sons", 93, "(969) 539-1789", "www.Graham and Sons.com" },
                    { 65, "Pfannerstill View", 50, "Herman45@gmail.com", "McGlynn - Bahringer", 93, "(278) 633-9927", "www.McGlynn - Bahringer.com" },
                    { 50, "McLaughlin Light", 114, "Guillermo_Casper96@hotmail.com", "Dare, Runolfsson and Smitham", 33, "(090) 675-5590", "www.Dare, Runolfsson and Smitham.com" },
                    { 38, "Geraldine Summit", 150, "Clyde_Veum88@yahoo.com", "Cremin - Dach", 202, "(341) 533-2167", "www.Cremin - Dach.com" },
                    { 134, "Sarina Center", 300, "Emerson_Howe@yahoo.com", "Schamberger, Macejkovic and Brown", 28, "(755) 944-4175", "www.Schamberger, Macejkovic and Brown.com" },
                    { 114, "Minerva Lake", 287, "Dolores7@gmail.com", "Littel LLC", 219, "(283) 160-2250", "www.Littel LLC.com" },
                    { 98, "Albertha Roads", 44, "Kiley_Doyle@yahoo.com", "Hahn Group", 202, "(960) 729-1782", "www.Hahn Group.com" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 64, new DateTime(2020, 11, 8, 11, 44, 44, 152, DateTimeKind.Local).AddTicks(6954), 347483, 81, "5422898" },
                    { 28, new DateTime(2020, 9, 23, 4, 6, 43, 79, DateTimeKind.Local).AddTicks(2141), 3675, 25, "5429295" },
                    { 70, new DateTime(2020, 10, 26, 20, 32, 34, 422, DateTimeKind.Local).AddTicks(7490), 108717, 4, "8558768" },
                    { 58, new DateTime(2021, 4, 3, 9, 35, 47, 93, DateTimeKind.Local).AddTicks(3728), 358319, 94, "4330673" },
                    { 86, new DateTime(2021, 3, 30, 0, 10, 37, 71, DateTimeKind.Local).AddTicks(8975), 319984, 94, "7982669" },
                    { 25, new DateTime(2020, 10, 25, 15, 16, 0, 557, DateTimeKind.Local).AddTicks(6861), 851039, 56, "5091795" },
                    { 95, new DateTime(2021, 4, 10, 3, 2, 36, 739, DateTimeKind.Local).AddTicks(2810), 342554, 40, "2715753" },
                    { 15, new DateTime(2020, 8, 27, 10, 25, 28, 522, DateTimeKind.Local).AddTicks(7703), 684881, 87, "8299766" },
                    { 16, new DateTime(2020, 9, 13, 20, 8, 31, 585, DateTimeKind.Local).AddTicks(1417), 573426, 3, "8802906" },
                    { 94, new DateTime(2021, 2, 7, 23, 11, 20, 533, DateTimeKind.Local).AddTicks(7886), 559307, 4, "8484841" },
                    { 5, new DateTime(2021, 3, 26, 20, 34, 40, 817, DateTimeKind.Local).AddTicks(501), 767911, 87, "1683835" },
                    { 27, new DateTime(2021, 7, 1, 14, 31, 37, 938, DateTimeKind.Local).AddTicks(1358), 162801, 58, "1805227" },
                    { 99, new DateTime(2020, 8, 24, 22, 51, 34, 733, DateTimeKind.Local).AddTicks(9179), 65486, 45, "2244711" },
                    { 54, new DateTime(2020, 8, 27, 3, 24, 42, 246, DateTimeKind.Local).AddTicks(4237), 119696, 10, "7471376" },
                    { 85, new DateTime(2021, 5, 15, 8, 17, 23, 673, DateTimeKind.Local).AddTicks(2165), 745628, 76, "7694419" },
                    { 52, new DateTime(2021, 5, 10, 14, 28, 9, 802, DateTimeKind.Local).AddTicks(5157), 220969, 76, "5545916" },
                    { 29, new DateTime(2021, 1, 4, 13, 56, 47, 995, DateTimeKind.Local).AddTicks(3828), 825384, 58, "4123516" },
                    { 13, new DateTime(2021, 3, 12, 10, 42, 42, 769, DateTimeKind.Local).AddTicks(561), 225060, 58, "2474225" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 88, new DateTime(2021, 1, 31, 12, 15, 55, 273, DateTimeKind.Local).AddTicks(8687), 229038, 70, "4933804" },
                    { 61, new DateTime(2020, 11, 6, 9, 34, 42, 691, DateTimeKind.Local).AddTicks(6389), 771705, 70, "2146402" },
                    { 21, new DateTime(2021, 6, 3, 7, 53, 56, 136, DateTimeKind.Local).AddTicks(3740), 907652, 1, "1578042" },
                    { 56, new DateTime(2021, 1, 1, 17, 17, 10, 924, DateTimeKind.Local).AddTicks(8749), 557708, 70, "1361976" },
                    { 102, new DateTime(2021, 5, 4, 5, 53, 35, 97, DateTimeKind.Local).AddTicks(3437), 925033, 6, "2895509" },
                    { 100, new DateTime(2021, 2, 13, 15, 56, 41, 450, DateTimeKind.Local).AddTicks(2634), 828357, 45, "1722850" },
                    { 23, new DateTime(2020, 8, 13, 3, 21, 34, 875, DateTimeKind.Local).AddTicks(9033), 356415, 1, "6508344" },
                    { 79, new DateTime(2021, 7, 4, 6, 21, 50, 251, DateTimeKind.Local).AddTicks(9414), 672460, 5, "5942183" },
                    { 59, new DateTime(2021, 3, 26, 14, 41, 34, 543, DateTimeKind.Local).AddTicks(4947), 441393, 31, "6934650" },
                    { 81, new DateTime(2021, 2, 7, 13, 34, 1, 450, DateTimeKind.Local).AddTicks(6353), 303069, 91, "4880900" },
                    { 73, new DateTime(2021, 1, 8, 12, 52, 57, 118, DateTimeKind.Local).AddTicks(9763), 616125, 6, "1308201" },
                    { 43, new DateTime(2021, 8, 8, 21, 54, 10, 997, DateTimeKind.Local).AddTicks(7103), 733752, 91, "3370352" },
                    { 76, new DateTime(2021, 3, 21, 18, 53, 56, 347, DateTimeKind.Local).AddTicks(3604), 729316, 22, "5842742" },
                    { 91, new DateTime(2021, 5, 8, 3, 17, 11, 683, DateTimeKind.Local).AddTicks(7898), 292109, 80, "7667503" },
                    { 46, new DateTime(2021, 6, 19, 15, 44, 55, 112, DateTimeKind.Local).AddTicks(495), 362597, 80, "6866607" },
                    { 39, new DateTime(2020, 12, 9, 11, 16, 58, 714, DateTimeKind.Local).AddTicks(9721), 166027, 80, "8449580" },
                    { 26, new DateTime(2021, 5, 13, 17, 38, 38, 381, DateTimeKind.Local).AddTicks(3212), 253687, 80, "7667128" },
                    { 1, new DateTime(2021, 5, 12, 1, 48, 47, 348, DateTimeKind.Local).AddTicks(6174), 700188, 80, "2981384" },
                    { 68, new DateTime(2020, 11, 6, 21, 2, 20, 904, DateTimeKind.Local).AddTicks(8262), 406429, 5, "5677338" },
                    { 53, new DateTime(2021, 7, 26, 3, 55, 3, 901, DateTimeKind.Local).AddTicks(7591), 857926, 5, "3048474" },
                    { 17, new DateTime(2021, 2, 14, 16, 35, 25, 647, DateTimeKind.Local).AddTicks(5300), 329451, 5, "1600167" },
                    { 7, new DateTime(2021, 3, 27, 15, 4, 52, 82, DateTimeKind.Local).AddTicks(164), 211825, 5, "2362544" },
                    { 47, new DateTime(2021, 4, 7, 19, 6, 5, 824, DateTimeKind.Local).AddTicks(9403), 567862, 98, "4490934" },
                    { 2, new DateTime(2021, 7, 15, 4, 12, 34, 183, DateTimeKind.Local).AddTicks(2019), 984068, 98, "3416997" },
                    { 42, new DateTime(2021, 1, 2, 23, 49, 53, 249, DateTimeKind.Local).AddTicks(1723), 610882, 33, "6909374" },
                    { 82, new DateTime(2021, 4, 14, 7, 38, 40, 257, DateTimeKind.Local).AddTicks(4042), 4218, 27, "2335955" },
                    { 106, new DateTime(2021, 5, 18, 8, 21, 46, 954, DateTimeKind.Local).AddTicks(6616), 149023, 9, "7538794" },
                    { 60, new DateTime(2021, 5, 26, 17, 32, 27, 730, DateTimeKind.Local).AddTicks(6164), 332200, 9, "7604201" },
                    { 104, new DateTime(2020, 12, 25, 18, 29, 7, 386, DateTimeKind.Local).AddTicks(5895), 974873, 60, "5139561" },
                    { 37, new DateTime(2021, 7, 18, 1, 5, 39, 800, DateTimeKind.Local).AddTicks(5602), 666083, 60, "9962062" },
                    { 19, new DateTime(2020, 8, 17, 3, 1, 24, 40, DateTimeKind.Local).AddTicks(4550), 774334, 60, "5560304" },
                    { 8, new DateTime(2021, 4, 30, 16, 3, 53, 486, DateTimeKind.Local).AddTicks(5499), 560415, 60, "4792792" },
                    { 63, new DateTime(2021, 2, 5, 19, 23, 30, 101, DateTimeKind.Local).AddTicks(2505), 809020, 1, "1181580" },
                    { 49, new DateTime(2021, 6, 22, 21, 21, 4, 391, DateTimeKind.Local).AddTicks(2926), 655667, 6, "2891069" },
                    { 75, new DateTime(2020, 9, 16, 19, 18, 16, 992, DateTimeKind.Local).AddTicks(1010), 72558, 67, "4005632" },
                    { 38, new DateTime(2021, 5, 17, 18, 15, 39, 643, DateTimeKind.Local).AddTicks(3787), 190746, 84, "2434234" },
                    { 36, new DateTime(2021, 4, 6, 9, 17, 19, 579, DateTimeKind.Local).AddTicks(8505), 930583, 63, "7553010" },
                    { 22, new DateTime(2020, 9, 21, 18, 13, 34, 602, DateTimeKind.Local).AddTicks(4088), 21576, 36, "1545584" },
                    { 90, new DateTime(2020, 10, 24, 0, 40, 40, 79, DateTimeKind.Local).AddTicks(2010), 107171, 73, "1826891" },
                    { 40, new DateTime(2021, 2, 15, 15, 36, 35, 441, DateTimeKind.Local).AddTicks(3564), 862560, 73, "8173806" },
                    { 31, new DateTime(2020, 9, 15, 23, 43, 20, 476, DateTimeKind.Local).AddTicks(8990), 452794, 73, "5225715" },
                    { 10, new DateTime(2020, 8, 25, 0, 27, 18, 867, DateTimeKind.Local).AddTicks(326), 874355, 73, "9760939" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 103, new DateTime(2021, 5, 10, 5, 16, 5, 589, DateTimeKind.Local).AddTicks(8528), 836819, 67, "2602823" },
                    { 6, new DateTime(2021, 8, 4, 15, 2, 5, 944, DateTimeKind.Local).AddTicks(5117), 443345, 67, "7418464" },
                    { 30, new DateTime(2021, 1, 15, 23, 8, 43, 320, DateTimeKind.Local).AddTicks(265), 970369, 12, "1044639" },
                    { 9, new DateTime(2021, 6, 6, 17, 15, 2, 1, DateTimeKind.Local).AddTicks(1612), 196829, 12, "7202851" },
                    { 84, new DateTime(2021, 4, 3, 19, 59, 40, 779, DateTimeKind.Local).AddTicks(3806), 507740, 11, "7499804" },
                    { 51, new DateTime(2021, 4, 26, 15, 24, 50, 30, DateTimeKind.Local).AddTicks(179), 414930, 11, "5140619" },
                    { 77, new DateTime(2020, 11, 13, 23, 58, 25, 892, DateTimeKind.Local).AddTicks(508), 579379, 7, "1981079" },
                    { 101, new DateTime(2021, 4, 11, 23, 26, 33, 638, DateTimeKind.Local).AddTicks(4524), 350078, 90, "5048484" },
                    { 41, new DateTime(2020, 12, 22, 0, 49, 44, 828, DateTimeKind.Local).AddTicks(1211), 593211, 90, "3600639" },
                    { 11, new DateTime(2021, 8, 2, 16, 43, 45, 672, DateTimeKind.Local).AddTicks(8429), 829090, 90, "1974871" },
                    { 24, new DateTime(2020, 8, 18, 12, 16, 15, 709, DateTimeKind.Local).AddTicks(7586), 912382, 14, "3538302" },
                    { 14, new DateTime(2021, 5, 7, 16, 16, 30, 167, DateTimeKind.Local).AddTicks(974), 572137, 14, "6921171" },
                    { 44, new DateTime(2021, 8, 3, 13, 7, 35, 388, DateTimeKind.Local).AddTicks(7488), 447659, 8, "6950174" },
                    { 18, new DateTime(2021, 4, 14, 22, 5, 7, 47, DateTimeKind.Local).AddTicks(8710), 331068, 8, "7882077" },
                    { 96, new DateTime(2021, 7, 24, 12, 49, 26, 157, DateTimeKind.Local).AddTicks(4556), 877068, 24, "8232917" },
                    { 69, new DateTime(2021, 3, 21, 7, 45, 25, 642, DateTimeKind.Local).AddTicks(1317), 180871, 24, "4813371" },
                    { 83, new DateTime(2020, 11, 11, 0, 33, 23, 180, DateTimeKind.Local).AddTicks(8746), 940387, 91, "8227951" },
                    { 65, new DateTime(2020, 12, 15, 19, 52, 26, 903, DateTimeKind.Local).AddTicks(5044), 154529, 17, "7651051" },
                    { 20, new DateTime(2021, 2, 2, 2, 11, 16, 354, DateTimeKind.Local).AddTicks(7788), 613239, 6, "2743245" },
                    { 32, new DateTime(2021, 4, 18, 21, 34, 36, 486, DateTimeKind.Local).AddTicks(8081), 827033, 46, "9751723" },
                    { 33, new DateTime(2021, 1, 13, 17, 50, 42, 663, DateTimeKind.Local).AddTicks(8750), 230448, 34, "1685415" },
                    { 62, new DateTime(2020, 8, 31, 22, 27, 14, 390, DateTimeKind.Local).AddTicks(9232), 732260, 19, "6835280" },
                    { 105, new DateTime(2021, 8, 6, 0, 35, 37, 910, DateTimeKind.Local).AddTicks(6160), 301904, 93, "4493376" },
                    { 98, new DateTime(2021, 2, 18, 15, 21, 38, 321, DateTimeKind.Local).AddTicks(4507), 63367, 93, "1368131" },
                    { 93, new DateTime(2021, 2, 5, 3, 48, 56, 801, DateTimeKind.Local).AddTicks(3649), 319337, 93, "6408686" },
                    { 87, new DateTime(2020, 12, 10, 16, 58, 27, 449, DateTimeKind.Local).AddTicks(2249), 526820, 93, "6258307" },
                    { 78, new DateTime(2021, 7, 17, 5, 56, 58, 12, DateTimeKind.Local).AddTicks(3553), 8636, 93, "6213475" },
                    { 35, new DateTime(2021, 7, 17, 9, 57, 39, 613, DateTimeKind.Local).AddTicks(309), 911413, 93, "9457970" },
                    { 89, new DateTime(2020, 11, 16, 19, 0, 56, 578, DateTimeKind.Local).AddTicks(820), 318301, 2, "6297797" },
                    { 12, new DateTime(2021, 7, 18, 7, 17, 44, 477, DateTimeKind.Local).AddTicks(4357), 314716, 2, "2139865" },
                    { 3, new DateTime(2020, 12, 27, 1, 13, 45, 418, DateTimeKind.Local).AddTicks(398), 170584, 2, "3850036" },
                    { 71, new DateTime(2021, 2, 21, 5, 54, 43, 963, DateTimeKind.Local).AddTicks(8563), 501083, 82, "5951715" },
                    { 66, new DateTime(2020, 11, 30, 13, 9, 30, 827, DateTimeKind.Local).AddTicks(242), 431914, 82, "5826731" },
                    { 48, new DateTime(2021, 2, 9, 3, 31, 17, 178, DateTimeKind.Local).AddTicks(1893), 17253, 38, "8304947" },
                    { 80, new DateTime(2021, 1, 14, 5, 40, 50, 231, DateTimeKind.Local).AddTicks(7722), 315844, 29, "2787653" },
                    { 67, new DateTime(2020, 9, 18, 20, 41, 1, 557, DateTimeKind.Local).AddTicks(2257), 409882, 29, "7213523" },
                    { 34, new DateTime(2020, 8, 21, 2, 4, 42, 115, DateTimeKind.Local).AddTicks(5578), 340358, 79, "7071233" },
                    { 72, new DateTime(2021, 4, 5, 6, 47, 44, 679, DateTimeKind.Local).AddTicks(4186), 467640, 89, "5962345" },
                    { 45, new DateTime(2020, 11, 20, 7, 5, 16, 387, DateTimeKind.Local).AddTicks(4437), 769430, 89, "9785272" },
                    { 97, new DateTime(2021, 6, 6, 21, 22, 18, 983, DateTimeKind.Local).AddTicks(7600), 346730, 96, "5717492" },
                    { 55, new DateTime(2020, 11, 10, 0, 52, 5, 428, DateTimeKind.Local).AddTicks(549), 525634, 26, "3504228" },
                    { 4, new DateTime(2020, 8, 26, 23, 51, 1, 967, DateTimeKind.Local).AddTicks(9569), 496329, 26, "3241074" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "FirstRegistration", "Mileage", "ModelId", "Vin" },
                values: new object[,]
                {
                    { 92, new DateTime(2021, 7, 17, 4, 50, 49, 130, DateTimeKind.Local).AddTicks(6948), 222046, 13, "2194747" },
                    { 50, new DateTime(2021, 8, 6, 17, 7, 7, 756, DateTimeKind.Local).AddTicks(3722), 68395, 34, "7830968" },
                    { 57, new DateTime(2021, 5, 1, 20, 21, 31, 783, DateTimeKind.Local).AddTicks(134), 722162, 46, "9944095" },
                    { 74, new DateTime(2021, 7, 3, 22, 58, 19, 730, DateTimeKind.Local).AddTicks(1880), 593112, 37, "1537750" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 7, 69, 141, 201368, new DateTime(2021, 2, 24, 4, 10, 39, 188, DateTimeKind.Local).AddTicks(5977), "Modi est rem illum tempora iusto sed debitis quo. Vel quia sapiente incidunt consectetur omnis recusandae voluptate id. Id illo vel dolorum dolor ut. Itaque optio praesentium omnis omnis facere illum debitis." },
                    { 82, 70, 135, 157250, new DateTime(2021, 5, 17, 3, 20, 28, 629, DateTimeKind.Local).AddTicks(7102), "esse" },
                    { 145, 70, 117, 232677, new DateTime(2021, 8, 8, 0, 27, 41, 104, DateTimeKind.Local).AddTicks(7678), "Dolore harum molestiae eligendi." },
                    { 189, 70, 12, 360227, new DateTime(2020, 9, 15, 17, 22, 47, 681, DateTimeKind.Local).AddTicks(9638), "sed" },
                    { 271, 70, 141, 54809, new DateTime(2021, 2, 16, 4, 29, 27, 816, DateTimeKind.Local).AddTicks(7209), "Aut ratione voluptate et." },
                    { 471, 70, 30, 815936, new DateTime(2021, 5, 19, 13, 58, 35, 846, DateTimeKind.Local).AddTicks(6759), "Illo et sed quidem voluptas et saepe assumenda. Sit dolores dolorem incidunt et harum laboriosam. Minus officia quae similique ipsa repudiandae accusamus corporis qui." },
                    { 43, 94, 80, 655355, new DateTime(2020, 9, 4, 11, 29, 58, 486, DateTimeKind.Local).AddTicks(7042), "expedita" },
                    { 127, 94, 39, 542811, new DateTime(2020, 9, 6, 22, 4, 50, 409, DateTimeKind.Local).AddTicks(8659), "Aliquam error laborum omnis recusandae quis. Est ex natus. Neque accusamus sed sint eius qui at non natus. Amet quia excepturi repellat aut deleniti. Occaecati distinctio neque dolorum consectetur. Exercitationem corrupti quo eos aut." },
                    { 375, 94, 37, 412424, new DateTime(2020, 11, 6, 10, 5, 55, 799, DateTimeKind.Local).AddTicks(5643), "Quibusdam placeat accusamus iusto." },
                    { 414, 94, 147, 89190, new DateTime(2021, 7, 15, 18, 34, 37, 93, DateTimeKind.Local).AddTicks(4330), "Quisquam est odio veniam recusandae velit qui corrupti blanditiis eaque. Reiciendis repellendus itaque quisquam repellendus vero et placeat perspiciatis. Repellendus ut qui dolorem ipsa veniam." },
                    { 457, 94, 75, 587047, new DateTime(2021, 8, 12, 18, 41, 48, 196, DateTimeKind.Local).AddTicks(7600), "Qui aut voluptate minus.\nNemo qui eveniet iure praesentium.\nAut et accusamus necessitatibus voluptatem quaerat dolore numquam repellendus tempora.\nIusto quasi est consequatur possimus et et voluptate.\nRerum ut veritatis aut quo assumenda dolores." },
                    { 586, 94, 116, 208937, new DateTime(2020, 10, 28, 13, 51, 6, 143, DateTimeKind.Local).AddTicks(7577), "quod" },
                    { 36, 58, 29, 392152, new DateTime(2021, 3, 24, 14, 7, 36, 611, DateTimeKind.Local).AddTicks(6143), "Voluptas quaerat id debitis hic.\nEligendi deserunt sunt ea voluptate optio ut et ut.\nItaque quidem minus iusto quia quis.\nLabore corrupti voluptatibus animi labore et.\nSunt voluptas reprehenderit sunt possimus placeat.\nEst et sint ex id eveniet dolore." },
                    { 107, 58, 149, 318733, new DateTime(2021, 5, 3, 11, 31, 21, 875, DateTimeKind.Local).AddTicks(819), "Voluptate eius molestiae praesentium illum rerum voluptatem." },
                    { 278, 58, 119, 330475, new DateTime(2020, 8, 30, 14, 53, 31, 444, DateTimeKind.Local).AddTicks(5233), "Nobis quisquam natus doloribus culpa doloribus.\nEa quia ab ratione ut.\nLibero dolorem debitis quam.\nOmnis aliquid accusamus iure cupiditate praesentium.\nUt dicta dignissimos earum." },
                    { 479, 58, 5, 875308, new DateTime(2020, 10, 20, 0, 18, 24, 648, DateTimeKind.Local).AddTicks(8215), "Tenetur alias placeat ut.\nAdipisci modi nostrum voluptates.\nHarum animi quisquam eos omnis.\nIn delectus facere nihil blanditiis ullam ut nostrum occaecati.\nDolore nesciunt expedita.\nVoluptas culpa quo facere corporis fugit perspiciatis." },
                    { 542, 28, 125, 914080, new DateTime(2020, 10, 3, 14, 19, 18, 717, DateTimeKind.Local).AddTicks(8818), "vel" },
                    { 347, 28, 56, 701899, new DateTime(2021, 1, 27, 5, 14, 40, 933, DateTimeKind.Local).AddTicks(4969), "laborum" },
                    { 346, 28, 42, 702697, new DateTime(2020, 9, 22, 0, 8, 20, 112, DateTimeKind.Local).AddTicks(1987), "consequatur" },
                    { 236, 28, 63, 226636, new DateTime(2020, 12, 21, 1, 3, 45, 314, DateTimeKind.Local).AddTicks(4759), "Quia et vero sequi voluptatem corporis." },
                    { 525, 5, 100, 53019, new DateTime(2021, 3, 11, 15, 15, 31, 226, DateTimeKind.Local).AddTicks(7679), "At a consequatur ut eius odit temporibus rerum. Deleniti doloremque minima. Aut quasi tempore veniam repudiandae quo sed ea sunt dolorum. Et nihil aut sed id eius voluptatem occaecati. Quo alias sint nihil et dolor perspiciatis suscipit velit. Ipsum qui nesciunt quisquam placeat sed reiciendis." },
                    { 80, 15, 127, 245714, new DateTime(2020, 12, 29, 18, 35, 38, 633, DateTimeKind.Local).AddTicks(9194), "Nam soluta earum nesciunt voluptas et aut dolores.\nSit tempora voluptate." },
                    { 83, 15, 145, 532739, new DateTime(2021, 1, 11, 0, 55, 42, 807, DateTimeKind.Local).AddTicks(2874), "Voluptas totam perspiciatis velit assumenda delectus cupiditate nemo ea. Voluptates officia repudiandae consequatur inventore cumque similique incidunt. Vero officia esse nihil neque molestias. Et dicta aut autem porro. Ullam praesentium molestiae deleniti qui quam ipsa." },
                    { 130, 15, 93, 230153, new DateTime(2021, 4, 21, 17, 51, 31, 705, DateTimeKind.Local).AddTicks(4294), "Aut laborum et molestiae.\nDignissimos ut mollitia perferendis unde non saepe.\nSit officia aliquam doloremque alias voluptatem iusto dolorem saepe." },
                    { 147, 15, 103, 242375, new DateTime(2021, 3, 19, 18, 57, 9, 921, DateTimeKind.Local).AddTicks(5359), "iusto" },
                    { 265, 15, 129, 25632, new DateTime(2021, 4, 12, 1, 7, 54, 446, DateTimeKind.Local).AddTicks(6715), "commodi" },
                    { 588, 15, 112, 464242, new DateTime(2021, 5, 28, 22, 56, 58, 408, DateTimeKind.Local).AddTicks(48), "Optio dignissimos earum voluptas aut aperiam aspernatur quas vel officiis.\nSuscipit dolores incidunt.\nSapiente ad voluptatibus." },
                    { 508, 58, 69, 115277, new DateTime(2020, 11, 18, 22, 35, 41, 150, DateTimeKind.Local).AddTicks(4183), "Sequi quia consequatur.\nMolestiae laudantium non est sed adipisci dolor.\nSunt qui veritatis repellendus.\nMinus doloremque tempore non eius voluptatem blanditiis qui fugiat et.\nVoluptatem nostrum voluptatem nobis officiis." },
                    { 21, 64, 72, 790806, new DateTime(2021, 4, 17, 3, 30, 35, 184, DateTimeKind.Local).AddTicks(3155), "Eos iste veritatis.\nConsectetur qui dolores.\nEos eligendi libero.\nDolores autem voluptatem voluptatem quos omnis tempora ratione non porro.\nEt nostrum aut quis dolores in et esse quos." },
                    { 454, 64, 57, 66977, new DateTime(2021, 4, 29, 5, 2, 1, 843, DateTimeKind.Local).AddTicks(4236), "Consequuntur nihil cum occaecati id ipsam. Et perferendis porro voluptatem aperiam eaque quod ut quisquam quae. In vel repudiandae similique ipsam iste eveniet in consequatur est." },
                    { 469, 64, 138, 191603, new DateTime(2021, 5, 17, 18, 44, 18, 824, DateTimeKind.Local).AddTicks(6315), "Nemo iste architecto dolorum aperiam voluptas." },
                    { 50, 28, 93, 53462, new DateTime(2021, 5, 12, 16, 53, 29, 901, DateTimeKind.Local).AddTicks(3836), "qui" },
                    { 121, 28, 54, 599730, new DateTime(2021, 7, 14, 14, 5, 41, 391, DateTimeKind.Local).AddTicks(9111), "Enim excepturi excepturi quia sed. Distinctio dolorem qui est ea doloremque quidem qui in. Ut architecto dolorem molestias officiis quas et voluptate est magnam." },
                    { 123, 28, 147, 644966, new DateTime(2021, 2, 6, 20, 57, 53, 820, DateTimeKind.Local).AddTicks(7465), "Suscipit nam similique facilis sunt saepe exercitationem officia.\nVoluptatem rerum earum nihil consequatur eligendi atque.\nEst odit non et autem inventore similique tempora corrupti.\nOptio eveniet laborum nihil corporis ea et quos nulla nemo.\nNostrum sint aliquid nam molestias suscipit enim esse blanditiis." },
                    { 170, 28, 27, 140832, new DateTime(2020, 12, 30, 18, 26, 38, 388, DateTimeKind.Local).AddTicks(9250), "Sit labore fugiat aut officiis incidunt. Neque voluptate sed quia sint voluptatem nobis. Quia dolor quidem optio. Quo tenetur laboriosam inventore." },
                    { 204, 28, 7, 252836, new DateTime(2021, 5, 9, 4, 3, 31, 208, DateTimeKind.Local).AddTicks(4559), "Enim impedit consequatur occaecati. Similique rem ut dolorem sit recusandae. Eum exercitationem iusto labore nihil tempora. Quibusdam qui ipsum qui animi maxime. Incidunt natus in nisi laborum." },
                    { 275, 64, 43, 844381, new DateTime(2021, 4, 2, 20, 46, 7, 160, DateTimeKind.Local).AddTicks(8901), "Totam asperiores est sed repudiandae." },
                    { 587, 58, 135, 158823, new DateTime(2021, 1, 6, 18, 38, 1, 276, DateTimeKind.Local).AddTicks(1582), "Et adipisci est veritatis. Et placeat aliquam dolore dolorem alias non quia. Et quo expedita ipsa in consectetur culpa fugit eos quia. Consectetur minus beatae sapiente commodi rem natus ut ex aut. Laborum voluptatem distinctio nihil ipsum et et et sunt earum. Placeat accusamus dolores tempora qui commodi id error placeat illo." },
                    { 96, 86, 107, 200551, new DateTime(2021, 5, 26, 17, 29, 40, 10, DateTimeKind.Local).AddTicks(4224), "Placeat molestiae fuga ipsum iusto impedit nostrum dolorem deleniti est. Numquam harum totam nulla repellendus dignissimos deleniti numquam vel. Sed voluptatem unde necessitatibus explicabo dolores. Dolorum et quos voluptatum enim voluptatem delectus earum." },
                    { 114, 86, 6, 363798, new DateTime(2021, 6, 23, 4, 27, 57, 676, DateTimeKind.Local).AddTicks(8061), "officia" },
                    { 233, 25, 121, 887125, new DateTime(2020, 9, 28, 9, 19, 25, 151, DateTimeKind.Local).AddTicks(2379), "Quibusdam nostrum animi quas dolor et perferendis.\nVoluptatem quo laboriosam et.\nCum voluptas voluptas labore.\nAdipisci sint doloremque consequatur consequatur illum illum qui quasi dolorum.\nAb omnis aut qui sint." },
                    { 320, 25, 30, 585742, new DateTime(2020, 12, 5, 16, 14, 7, 620, DateTimeKind.Local).AddTicks(4044), "Voluptas quos omnis nostrum aspernatur ut id sit. Mollitia nihil maiores alias alias qui autem optio. Quis ipsam dolore sed. Quod at unde." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 439, 25, 139, 396378, new DateTime(2021, 3, 2, 21, 7, 15, 50, DateTimeKind.Local).AddTicks(108), "Unde non voluptas similique rerum dicta nobis inventore. Nemo quam iste ipsam ea. Ipsam rerum et. Quasi ut voluptates mollitia quidem vel dolorem ipsum eius voluptate. Optio libero et aliquam velit quae et odit ut architecto." },
                    { 486, 25, 127, 687666, new DateTime(2020, 12, 9, 6, 16, 59, 163, DateTimeKind.Local).AddTicks(2183), "Dolores iusto aut unde provident quaerat.\nVelit quo voluptas.\nNumquam est neque.\nQui suscipit suscipit.\nPariatur repellat eum et.\nConsectetur eos omnis ex." },
                    { 523, 25, 67, 471719, new DateTime(2020, 10, 4, 17, 38, 23, 693, DateTimeKind.Local).AddTicks(265), "Molestiae incidunt ad animi quam." },
                    { 131, 21, 114, 12805, new DateTime(2020, 9, 24, 7, 4, 11, 287, DateTimeKind.Local).AddTicks(1693), "Ipsa consequatur quo error repudiandae praesentium aut animi voluptatem." },
                    { 277, 21, 109, 971161, new DateTime(2021, 3, 18, 18, 41, 5, 818, DateTimeKind.Local).AddTicks(2247), "Incidunt non ratione. Dolore nihil labore iste. Nostrum pariatur unde aut iste amet assumenda cumque." },
                    { 213, 25, 71, 672980, new DateTime(2021, 8, 5, 8, 53, 21, 91, DateTimeKind.Local).AddTicks(5077), "Fugiat nobis aut saepe voluptas.\nDeserunt harum aperiam et et sit dolorum autem.\nUt iure dolorum qui in voluptatem voluptate.\nAspernatur sed fugit debitis.\nIn libero laboriosam consequatur ab suscipit modi deleniti dolores." },
                    { 295, 21, 146, 280262, new DateTime(2021, 7, 4, 10, 0, 11, 799, DateTimeKind.Local).AddTicks(916), "Omnis eos architecto neque iste delectus aut libero sit." },
                    { 421, 21, 23, 274889, new DateTime(2020, 12, 10, 22, 48, 57, 117, DateTimeKind.Local).AddTicks(193), "Ut ut labore id deleniti aut aliquam quia ipsam nesciunt. Consequuntur fuga quaerat. Vel nulla eum eum doloribus quidem et inventore assumenda repudiandae. Eos ratione tenetur autem omnis ut." },
                    { 435, 21, 74, 582451, new DateTime(2021, 6, 12, 1, 45, 24, 28, DateTimeKind.Local).AddTicks(8918), "Tenetur molestiae qui ut. Iste laborum occaecati est est deserunt excepturi. Praesentium commodi et earum quaerat perferendis. Ullam totam et aperiam ex enim veniam perferendis magni." },
                    { 577, 21, 149, 450999, new DateTime(2021, 4, 17, 1, 1, 15, 694, DateTimeKind.Local).AddTicks(4202), "Eius sed odio et qui ut enim assumenda quasi pariatur.\nNon ab praesentium illum dolor.\nIpsam consequatur et.\nEarum corporis hic in ut et recusandae doloribus.\nVoluptas quasi dolorem quo vel qui nulla." },
                    { 25, 23, 83, 965642, new DateTime(2020, 12, 21, 13, 36, 41, 872, DateTimeKind.Local).AddTicks(228), "blanditiis" },
                    { 106, 23, 69, 181457, new DateTime(2021, 7, 15, 8, 0, 19, 851, DateTimeKind.Local).AddTicks(7129), "Commodi et aut magni et iure error.\nQui consequuntur et pariatur neque dolores blanditiis fugiat esse.\nRerum molestiae vel recusandae eaque nostrum sit id odit.\nVoluptatem voluptatem qui dolore.\nNon suscipit ipsam quis omnis.\nUt nulla alias fugit accusamus dolorem sapiente omnis." },
                    { 291, 23, 89, 359646, new DateTime(2020, 10, 23, 1, 23, 4, 862, DateTimeKind.Local).AddTicks(42), "Itaque dolores rerum qui laborum recusandae error. Vel qui vel aut. Veritatis accusantium ut. Itaque eum nihil harum ipsum sapiente eum quaerat. Hic maxime aut in rerum incidunt cumque quisquam." },
                    { 509, 23, 137, 222125, new DateTime(2021, 1, 15, 6, 20, 39, 893, DateTimeKind.Local).AddTicks(5550), "Sint rem saepe." },
                    { 325, 21, 2, 434334, new DateTime(2021, 1, 31, 10, 20, 31, 639, DateTimeKind.Local).AddTicks(6676), "Esse quis neque hic officiis dolor aliquid.\nSint fugiat quaerat quae excepturi modi omnis et odit provident.\nDolore tenetur voluptatibus rerum.\nReprehenderit minima aliquam officiis quidem ut voluptatem modi pariatur nobis." },
                    { 517, 5, 44, 818585, new DateTime(2020, 10, 3, 13, 57, 40, 922, DateTimeKind.Local).AddTicks(1306), "Illum praesentium consequatur ea eum sed sunt.\nMinima soluta quod natus.\nRerum alias alias a ut eveniet culpa." },
                    { 76, 25, 18, 778431, new DateTime(2021, 3, 8, 4, 52, 52, 559, DateTimeKind.Local).AddTicks(2262), "Hic nemo delectus alias quia eos autem. Consequatur eligendi impedit placeat. Quasi odit architecto delectus sunt. Ut officiis sed optio autem magni. Omnis et quo quam doloribus quibusdam animi delectus. Similique cumque aut in explicabo est dolores." },
                    { 373, 95, 128, 874957, new DateTime(2020, 11, 3, 22, 18, 54, 140, DateTimeKind.Local).AddTicks(3910), "Accusamus harum excepturi ratione minima reprehenderit qui quasi illum." },
                    { 198, 86, 49, 793306, new DateTime(2021, 7, 20, 13, 19, 57, 585, DateTimeKind.Local).AddTicks(9159), "Assumenda quia aliquam magnam laborum quo." },
                    { 273, 86, 86, 782602, new DateTime(2021, 5, 25, 1, 35, 56, 636, DateTimeKind.Local).AddTicks(6693), "Et ut et dolores et voluptatem et vitae et. Id explicabo inventore rem quaerat. Omnis sed explicabo reiciendis quaerat et et sit. Nihil et natus incidunt architecto tenetur blanditiis tempore. Officiis deleniti adipisci nihil eum voluptates blanditiis nisi non impedit. Necessitatibus neque quis voluptatibus dignissimos esse." },
                    { 281, 86, 49, 598913, new DateTime(2021, 4, 3, 4, 6, 40, 712, DateTimeKind.Local).AddTicks(7409), "Vel veniam consequuntur et ad." },
                    { 322, 86, 67, 469650, new DateTime(2020, 12, 20, 16, 12, 30, 102, DateTimeKind.Local).AddTicks(3490), "Et reiciendis pariatur quia et deserunt asperiores quos." },
                    { 494, 86, 115, 497075, new DateTime(2020, 10, 31, 11, 54, 52, 726, DateTimeKind.Local).AddTicks(2809), "Suscipit amet commodi esse facilis et.\nEum minus possimus soluta aspernatur eligendi a voluptatem consequatur.\nDoloremque expedita dicta cupiditate." },
                    { 526, 86, 33, 341573, new DateTime(2021, 1, 11, 0, 34, 56, 175, DateTimeKind.Local).AddTicks(4948), "Suscipit dolores exercitationem excepturi corporis." },
                    { 35, 16, 137, 775485, new DateTime(2020, 11, 16, 10, 34, 53, 820, DateTimeKind.Local).AddTicks(4381), "Expedita enim ipsa aperiam culpa officiis. Reiciendis soluta et repellat quis nemo ut cupiditate. Ex atque consectetur. Ab sit maiores est autem sunt necessitatibus fugit." },
                    { 58, 25, 143, 211049, new DateTime(2021, 1, 23, 17, 50, 27, 338, DateTimeKind.Local).AddTicks(6039), "Quis accusamus mollitia in aspernatur odit delectus.\nSunt nihil magnam eaque ut est repellat.\nSoluta natus ut necessitatibus est dolorem rerum perspiciatis aut facere." },
                    { 185, 16, 30, 982505, new DateTime(2020, 11, 24, 23, 31, 42, 453, DateTimeKind.Local).AddTicks(211), "Voluptates cumque voluptate est distinctio placeat est." },
                    { 451, 16, 56, 407488, new DateTime(2021, 5, 27, 9, 5, 15, 617, DateTimeKind.Local).AddTicks(7207), "Nam fugiat ratione ut aut quia at ut qui ea. Dolore ut officiis id tenetur et ad. Labore laborum non praesentium est alias." },
                    { 477, 16, 86, 502936, new DateTime(2021, 1, 5, 1, 32, 54, 589, DateTimeKind.Local).AddTicks(3171), "Dolorum aut et.\nRem fuga accusamus qui ullam quos voluptatem qui.\nNesciunt quod et sunt harum.\nAspernatur consequatur numquam veniam facere magni aut." },
                    { 501, 16, 62, 87042, new DateTime(2021, 3, 16, 20, 43, 52, 290, DateTimeKind.Local).AddTicks(6385), "Earum magnam ut commodi error ut est." },
                    { 89, 95, 35, 307913, new DateTime(2021, 2, 18, 7, 54, 52, 221, DateTimeKind.Local).AddTicks(5741), "Error vel ut voluptatem numquam aut tempore sit blanditiis et.\nUt eius voluptatem labore nulla quod ab." },
                    { 109, 95, 43, 518680, new DateTime(2020, 12, 12, 20, 42, 21, 479, DateTimeKind.Local).AddTicks(9760), "Qui quam dolore aliquam iusto exercitationem dolor quia." },
                    { 191, 95, 81, 67083, new DateTime(2021, 4, 2, 21, 46, 53, 789, DateTimeKind.Local).AddTicks(692), "harum" },
                    { 306, 95, 59, 397598, new DateTime(2021, 7, 28, 5, 10, 4, 496, DateTimeKind.Local).AddTicks(9970), "Nobis ad rerum facilis ratione voluptatem.\nAb ex hic voluptatem quo et.\nEa dignissimos consequatur vitae quae nam.\nQui sed nulla aperiam et eius non suscipit nostrum." },
                    { 282, 16, 89, 222841, new DateTime(2021, 6, 30, 10, 23, 33, 129, DateTimeKind.Local).AddTicks(2087), "Est illo nisi quaerat pariatur. Error doloribus distinctio. Neque totam necessitatibus ut. Libero aut a et ullam nihil dolores ut." },
                    { 582, 23, 41, 977785, new DateTime(2021, 7, 16, 9, 1, 36, 503, DateTimeKind.Local).AddTicks(5854), "Delectus alias aspernatur accusamus molestiae voluptates aut." },
                    { 467, 5, 130, 565573, new DateTime(2021, 5, 26, 8, 56, 47, 775, DateTimeKind.Local).AddTicks(8912), "Eaque facilis voluptate consequatur quia beatae saepe minima odit rem." },
                    { 184, 5, 73, 522134, new DateTime(2021, 7, 5, 13, 26, 50, 715, DateTimeKind.Local).AddTicks(7829), "Officiis fugiat ad enim iste inventore sequi tempore est quis.\nEa perspiciatis sed eius.\nQuis et iste velit est ipsam aut.\nAut recusandae magni harum aliquid adipisci qui beatae." },
                    { 257, 61, 105, 728658, new DateTime(2020, 8, 20, 6, 27, 48, 445, DateTimeKind.Local).AddTicks(3239), "Eos est doloribus commodi in delectus est et pariatur nisi.\nVoluptatem illo esse." },
                    { 418, 61, 95, 92795, new DateTime(2021, 7, 17, 3, 11, 42, 324, DateTimeKind.Local).AddTicks(775), "Reprehenderit quasi eum voluptatem ut autem ut saepe quae." },
                    { 446, 61, 74, 981964, new DateTime(2021, 5, 22, 6, 28, 58, 233, DateTimeKind.Local).AddTicks(3103), "Qui quaerat ipsum asperiores. Aperiam doloremque debitis ut qui. Odio tempora facere totam debitis distinctio ea ut odit. Dolor quo saepe deleniti. Ut saepe sint aut rem aliquid voluptatum inventore sed ex." },
                    { 549, 61, 130, 765759, new DateTime(2020, 9, 2, 20, 12, 21, 174, DateTimeKind.Local).AddTicks(7980), "Et ut rem at." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 1, 88, 137, 466480, new DateTime(2021, 8, 5, 15, 50, 46, 791, DateTimeKind.Local).AddTicks(5543), "Enim mollitia est ratione molestias enim ea recusandae est. Quas corrupti aliquam provident corrupti aliquam veniam enim. Veniam quam perspiciatis veritatis." },
                    { 40, 88, 77, 942754, new DateTime(2021, 3, 21, 2, 0, 17, 805, DateTimeKind.Local).AddTicks(5672), "non" },
                    { 47, 88, 55, 812011, new DateTime(2020, 8, 26, 21, 17, 40, 916, DateTimeKind.Local).AddTicks(4656), "Molestiae et inventore inventore aut dolor modi et. Consequatur aliquid odio magni laboriosam aspernatur voluptatem. Omnis sit et debitis odit." },
                    { 117, 88, 101, 83310, new DateTime(2021, 2, 27, 16, 54, 6, 414, DateTimeKind.Local).AddTicks(2179), "Dicta aut illo saepe delectus." },
                    { 205, 88, 88, 597285, new DateTime(2020, 8, 26, 9, 34, 15, 460, DateTimeKind.Local).AddTicks(2058), "Necessitatibus suscipit accusamus est quod quis beatae amet iusto." },
                    { 426, 88, 93, 887520, new DateTime(2021, 6, 17, 13, 4, 58, 71, DateTimeKind.Local).AddTicks(2447), "Vitae deleniti magni." },
                    { 541, 88, 14, 415724, new DateTime(2020, 11, 14, 11, 42, 0, 103, DateTimeKind.Local).AddTicks(6252), "minima" },
                    { 53, 13, 93, 504321, new DateTime(2021, 5, 31, 19, 2, 29, 460, DateTimeKind.Local).AddTicks(4272), "Culpa fugiat dolorum qui nisi qui et tenetur quas. Id tempore ratione optio iusto vel sapiente delectus dolorem. Ipsa vel veritatis sed et adipisci." },
                    { 192, 13, 100, 91370, new DateTime(2020, 9, 24, 1, 43, 24, 431, DateTimeKind.Local).AddTicks(1662), "Eius incidunt soluta et explicabo sed cum." },
                    { 237, 13, 136, 355346, new DateTime(2020, 12, 16, 17, 30, 19, 963, DateTimeKind.Local).AddTicks(6683), "Sequi unde consequatur recusandae dignissimos animi ducimus aut sint dolorem." },
                    { 252, 13, 33, 159265, new DateTime(2020, 8, 31, 14, 19, 20, 685, DateTimeKind.Local).AddTicks(5688), "Eveniet ex est.\nEsse eius ipsam vitae eligendi voluptatem pariatur ad voluptatem.\nUt ab sed ut itaque." },
                    { 172, 61, 51, 221096, new DateTime(2020, 10, 8, 15, 3, 24, 530, DateTimeKind.Local).AddTicks(93), "Minus delectus voluptas deleniti eos molestiae. Laborum nobis molestias ducimus. Id quis eos odio nulla consequatur suscipit odio consequatur. Nostrum autem fuga laudantium autem repellat libero facilis rerum. Impedit est et deserunt eum reprehenderit consequatur vitae quos. Est laudantium itaque eius et hic inventore quibusdam." },
                    { 163, 61, 25, 122370, new DateTime(2020, 11, 27, 9, 27, 40, 911, DateTimeKind.Local).AddTicks(6176), "Delectus quis voluptatem est ipsa minima distinctio suscipit temporibus esse." },
                    { 591, 56, 59, 67279, new DateTime(2021, 5, 10, 12, 34, 46, 374, DateTimeKind.Local).AddTicks(4068), "excepturi" },
                    { 590, 56, 31, 977086, new DateTime(2021, 3, 16, 9, 20, 29, 174, DateTimeKind.Local).AddTicks(954), "Dolores hic minus non est repellat ratione et fugiat. Quisquam ut corrupti porro incidunt aliquam. Sint velit voluptatem repudiandae totam eum maxime hic magnam." },
                    { 497, 73, 34, 230917, new DateTime(2021, 8, 1, 10, 37, 15, 943, DateTimeKind.Local).AddTicks(9940), "Deserunt dolores vel repellat voluptas optio suscipit asperiores dolores. Voluptatem magni accusamus incidunt aut omnis. Iste et animi voluptates esse aut deleniti rerum. Porro quia accusantium accusamus ducimus laboriosam quam. Quos doloremque ut et delectus veritatis nihil provident voluptates." },
                    { 91, 102, 89, 7572, new DateTime(2020, 8, 22, 21, 9, 46, 271, DateTimeKind.Local).AddTicks(3251), "Distinctio magni excepturi est id. Blanditiis laboriosam nulla exercitationem voluptatem distinctio autem similique quaerat. Voluptates exercitationem doloremque eos quasi. Doloribus praesentium voluptatibus deserunt voluptates." },
                    { 216, 102, 13, 147431, new DateTime(2021, 4, 27, 11, 48, 46, 898, DateTimeKind.Local).AddTicks(9188), "Nobis et rerum omnis autem voluptas.\nId enim amet necessitatibus.\nVoluptatibus quia officia.\nMollitia eum earum ut dicta." },
                    { 249, 102, 80, 356613, new DateTime(2021, 2, 28, 9, 35, 13, 519, DateTimeKind.Local).AddTicks(5559), "Dolores error animi molestiae quis. Ducimus fuga quibusdam aliquam harum. Dolores et odio debitis totam labore dolorum commodi quas. Nulla est accusamus totam inventore quibusdam odio. Et sunt nulla at eum rerum reprehenderit." },
                    { 304, 102, 15, 795008, new DateTime(2021, 1, 23, 4, 1, 0, 222, DateTimeKind.Local).AddTicks(9880), "Illum non temporibus consequatur possimus.\nVelit quasi recusandae." },
                    { 412, 102, 80, 151441, new DateTime(2020, 9, 9, 10, 0, 24, 883, DateTimeKind.Local).AddTicks(4548), "Temporibus sunt odio sed nihil." },
                    { 551, 102, 127, 652897, new DateTime(2021, 1, 14, 8, 10, 43, 88, DateTimeKind.Local).AddTicks(8913), "sunt" },
                    { 312, 13, 87, 840898, new DateTime(2021, 7, 23, 7, 5, 17, 332, DateTimeKind.Local).AddTicks(879), "laudantium" },
                    { 564, 102, 42, 316663, new DateTime(2021, 4, 17, 22, 37, 9, 964, DateTimeKind.Local).AddTicks(6978), "aut" },
                    { 45, 56, 106, 937797, new DateTime(2021, 3, 20, 22, 3, 1, 252, DateTimeKind.Local).AddTicks(8316), "Adipisci voluptates et excepturi dolorum illum.\nSequi illo illum ab earum recusandae." },
                    { 61, 56, 62, 130286, new DateTime(2020, 10, 21, 11, 20, 45, 467, DateTimeKind.Local).AddTicks(9695), "odio" },
                    { 569, 74, 70, 116968, new DateTime(2020, 12, 20, 11, 32, 57, 236, DateTimeKind.Local).AddTicks(2738), "Sunt deserunt soluta et rerum consequatur et officiis.\nEveniet aut incidunt qui non dolores quas.\nExercitationem aut blanditiis non.\nTempore dignissimos asperiores consequuntur voluptates ex repellendus nisi facere corrupti." },
                    { 327, 56, 29, 414375, new DateTime(2021, 5, 18, 23, 12, 51, 453, DateTimeKind.Local).AddTicks(5706), "ut" },
                    { 419, 56, 4, 350159, new DateTime(2021, 6, 4, 18, 22, 56, 269, DateTimeKind.Local).AddTicks(2244), "Ut praesentium libero quasi. Aut et quas nemo impedit non corrupti. Cumque omnis qui sed rem. Autem delectus dicta qui quam itaque nihil." },
                    { 492, 56, 120, 753201, new DateTime(2021, 1, 24, 19, 33, 8, 840, DateTimeKind.Local).AddTicks(510), "Maxime perspiciatis consectetur est corporis quibusdam et tempora ea est. Veniam saepe quas voluptate sit magnam. Natus quasi voluptatum et nesciunt. Ut dolorum optio et ut suscipit. Aliquam magnam labore esse aut." },
                    { 513, 56, 140, 618553, new DateTime(2020, 8, 20, 20, 45, 10, 341, DateTimeKind.Local).AddTicks(3828), "Dolores modi repudiandae ipsam." },
                    { 44, 56, 75, 333562, new DateTime(2020, 9, 18, 14, 11, 34, 720, DateTimeKind.Local).AddTicks(876), "Officiis inventore consequatur corrupti molestiae sint reprehenderit culpa autem consequatur. Voluptas aut quisquam esse tenetur. Nesciunt error nemo ipsam consequatur quasi deserunt consequatur quas." },
                    { 450, 13, 52, 276541, new DateTime(2021, 8, 2, 6, 5, 30, 629, DateTimeKind.Local).AddTicks(5494), "Facilis ullam illum nisi.\nQui fugit omnis.\nSed omnis eligendi pariatur quas quia quo.\nNon dignissimos aut." },
                    { 580, 13, 143, 39358, new DateTime(2021, 3, 17, 21, 21, 52, 992, DateTimeKind.Local).AddTicks(5864), "voluptas" },
                    { 290, 27, 27, 255719, new DateTime(2021, 5, 1, 3, 10, 40, 843, DateTimeKind.Local).AddTicks(4414), "Minima modi maxime. Neque minus mollitia non eum omnis. Soluta est tempora eos optio." },
                    { 539, 54, 63, 378105, new DateTime(2020, 9, 11, 1, 42, 23, 719, DateTimeKind.Local).AddTicks(8914), "Rerum itaque repudiandae." },
                    { 563, 54, 125, 827500, new DateTime(2021, 4, 18, 14, 20, 20, 899, DateTimeKind.Local).AddTicks(5675), "Sunt voluptatum voluptatem non vitae dolorem quo.\nEnim eius quos.\nQuia enim nihil." },
                    { 41, 99, 112, 476560, new DateTime(2021, 6, 15, 3, 56, 42, 354, DateTimeKind.Local).AddTicks(6155), "amet" },
                    { 334, 99, 94, 425921, new DateTime(2021, 5, 9, 23, 51, 37, 816, DateTimeKind.Local).AddTicks(2792), "Aut ipsam numquam pariatur ab quidem sed itaque similique.\nNecessitatibus aut magnam nulla laboriosam.\nRem perferendis inventore dolor et odio consequatur alias.\nSed eligendi quia ut voluptatum est fugiat possimus.\nExercitationem dignissimos voluptatibus officia iure sint similique consectetur.\nAb amet ipsam quis accusamus." },
                    { 540, 99, 11, 59228, new DateTime(2021, 3, 9, 3, 4, 32, 367, DateTimeKind.Local).AddTicks(1612), "Fugit provident non mollitia beatae et ducimus ipsum." },
                    { 556, 99, 77, 128987, new DateTime(2021, 4, 13, 22, 54, 57, 355, DateTimeKind.Local).AddTicks(9648), "Excepturi vitae dolor eveniet laudantium numquam voluptatem qui consequatur vel. Quis aut reiciendis dolore dolores accusantium ut animi aut. Quos at voluptas neque est voluptatem quibusdam sit. Veniam veritatis voluptate." },
                    { 574, 99, 105, 382014, new DateTime(2021, 6, 15, 22, 59, 58, 826, DateTimeKind.Local).AddTicks(7233), "Ab nostrum reiciendis est nobis pariatur." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 60, 54, 85, 6176, new DateTime(2021, 3, 19, 11, 11, 10, 615, DateTimeKind.Local).AddTicks(1977), "sed" },
                    { 65, 100, 32, 495580, new DateTime(2021, 7, 31, 10, 8, 26, 653, DateTimeKind.Local).AddTicks(7008), "Optio voluptatem repellendus harum rerum." },
                    { 161, 100, 86, 130555, new DateTime(2020, 10, 15, 3, 10, 52, 961, DateTimeKind.Local).AddTicks(6343), "et" },
                    { 425, 100, 145, 511292, new DateTime(2020, 9, 9, 14, 25, 41, 719, DateTimeKind.Local).AddTicks(7599), "Ab repellat illum libero praesentium et voluptas aut mollitia distinctio." },
                    { 570, 100, 28, 669587, new DateTime(2021, 6, 6, 14, 31, 43, 665, DateTimeKind.Local).AddTicks(2964), "Et sint mollitia officia rerum voluptatem reprehenderit cumque voluptatem." },
                    { 3, 5, 126, 654519, new DateTime(2021, 2, 2, 0, 17, 36, 974, DateTimeKind.Local).AddTicks(1686), "Odit dolorem occaecati saepe." },
                    { 17, 5, 127, 321367, new DateTime(2021, 3, 1, 10, 38, 20, 257, DateTimeKind.Local).AddTicks(9661), "Quia fuga libero." },
                    { 85, 5, 58, 350527, new DateTime(2021, 5, 30, 16, 55, 44, 973, DateTimeKind.Local).AddTicks(7648), "Libero velit accusamus." },
                    { 97, 5, 30, 206412, new DateTime(2021, 1, 26, 14, 49, 30, 10, DateTimeKind.Local).AddTicks(2674), "Provident ea cupiditate veniam quidem et minima quod ad.\nFugit rem unde distinctio architecto minima nisi sunt." },
                    { 87, 100, 73, 485837, new DateTime(2021, 1, 4, 22, 32, 25, 390, DateTimeKind.Local).AddTicks(1737), "Molestiae quod officiis eum." },
                    { 239, 5, 37, 502258, new DateTime(2021, 5, 28, 3, 48, 12, 568, DateTimeKind.Local).AddTicks(7539), "Voluptates quisquam ad eos.\nQuae quis mollitia voluptatibus dolores aut.\nRepudiandae odit minus commodi minima dolorem voluptas totam aut." },
                    { 600, 85, 69, 821256, new DateTime(2020, 9, 12, 3, 8, 47, 62, DateTimeKind.Local).AddTicks(4649), "iste" },
                    { 250, 85, 35, 22078, new DateTime(2020, 12, 5, 15, 43, 41, 128, DateTimeKind.Local).AddTicks(7283), "Voluptatum consequuntur et ab laudantium laboriosam. Est consequatur nesciunt eum officia quisquam hic natus illum tempora. Sit veniam sit inventore sapiente veniam ab quos. Perferendis rerum libero fugiat quod est. Quia maxime in consequatur sit. Deserunt enim quia." },
                    { 422, 27, 58, 991673, new DateTime(2021, 8, 8, 9, 31, 10, 601, DateTimeKind.Local).AddTicks(614), "Ipsa est omnis eum consequatur quis consectetur illo." },
                    { 475, 27, 57, 24184, new DateTime(2021, 2, 24, 1, 26, 25, 580, DateTimeKind.Local).AddTicks(3076), "Fuga quasi fugit laudantium ut et repellat pariatur similique. Eum harum earum. Eius ad sequi aliquid et tempore necessitatibus. Rerum beatae nulla." },
                    { 495, 27, 122, 410875, new DateTime(2021, 3, 18, 6, 53, 1, 642, DateTimeKind.Local).AddTicks(4184), "cupiditate" },
                    { 553, 27, 125, 620925, new DateTime(2021, 7, 2, 10, 15, 57, 669, DateTimeKind.Local).AddTicks(8758), "Qui praesentium quis quis ea eius.\nAt esse mollitia qui reprehenderit quis quas possimus aut." },
                    { 8, 29, 28, 739538, new DateTime(2020, 9, 25, 3, 29, 22, 633, DateTimeKind.Local).AddTicks(4936), "Molestias omnis odit quisquam non ut qui dolor.\nEt ratione et quasi dolorem sapiente pariatur eaque." },
                    { 162, 29, 33, 383822, new DateTime(2021, 1, 13, 20, 31, 27, 496, DateTimeKind.Local).AddTicks(4874), "quaerat" },
                    { 311, 29, 15, 887369, new DateTime(2020, 10, 4, 15, 57, 16, 553, DateTimeKind.Local).AddTicks(6132), "Iusto dolore eum quis et soluta est aliquam esse.\nSunt at hic a voluptatem et non aut autem alias.\nId quasi unde." },
                    { 315, 85, 27, 606336, new DateTime(2021, 6, 5, 20, 13, 18, 275, DateTimeKind.Local).AddTicks(1496), "Hic quia est. Quidem reprehenderit ad nisi aut et corporis neque. Cum quo quod suscipit perferendis quis quia quaerat dolores nesciunt. Voluptatem nostrum ut iste aperiam saepe placeat delectus. Nesciunt amet et velit accusantium est officia. Explicabo non veritatis occaecati amet." },
                    { 393, 29, 124, 249640, new DateTime(2020, 10, 26, 13, 14, 54, 400, DateTimeKind.Local).AddTicks(492), "Amet fugiat voluptatem adipisci fuga vel laudantium nam provident beatae." },
                    { 168, 52, 55, 860602, new DateTime(2020, 10, 13, 17, 29, 58, 578, DateTimeKind.Local).AddTicks(1289), "facilis" },
                    { 303, 52, 87, 683832, new DateTime(2021, 2, 11, 12, 58, 30, 599, DateTimeKind.Local).AddTicks(4901), "Consectetur et id quo dolores repellat aut magni perferendis." },
                    { 324, 52, 62, 692827, new DateTime(2021, 7, 14, 21, 42, 38, 396, DateTimeKind.Local).AddTicks(4167), "Tenetur sit qui qui rerum veniam quia rerum consequatur ex.\nBeatae quia qui fuga modi molestiae nostrum ipsam placeat rerum." },
                    { 395, 52, 45, 63181, new DateTime(2021, 5, 17, 12, 17, 50, 60, DateTimeKind.Local).AddTicks(1976), "Occaecati quo et deleniti praesentium. Ea consequatur inventore perspiciatis adipisci et debitis id velit. Incidunt voluptatum voluptatibus atque praesentium sit porro consectetur. Esse ex mollitia placeat. Quia officia dolor voluptatem labore dolorem. Blanditiis sit eveniet." },
                    { 598, 52, 147, 869905, new DateTime(2020, 8, 22, 0, 28, 43, 255, DateTimeKind.Local).AddTicks(4364), "Impedit dolorum aperiam. Qui necessitatibus ipsum consequatur optio ut et deserunt ut provident. Deserunt doloremque illo fugit odio natus. Consequatur ipsum dolores distinctio id." },
                    { 103, 85, 92, 420568, new DateTime(2021, 4, 3, 19, 55, 7, 414, DateTimeKind.Local).AddTicks(6604), "esse" },
                    { 164, 85, 41, 229185, new DateTime(2020, 9, 19, 22, 33, 34, 897, DateTimeKind.Local).AddTicks(136), "Id mollitia molestiae dolorem est ratione. Error voluptatem molestiae sunt sit ut eos assumenda libero. Ut dolore debitis at distinctio." },
                    { 5, 52, 7, 395945, new DateTime(2021, 5, 23, 18, 38, 37, 232, DateTimeKind.Local).AddTicks(1556), "est" },
                    { 383, 73, 55, 617533, new DateTime(2020, 9, 3, 12, 46, 34, 579, DateTimeKind.Local).AddTicks(2584), "Rerum eius facilis omnis iusto impedit voluptas velit quisquam quasi.\nRerum consequatur rerum ad architecto dolorum.\nDolor modi et et omnis cupiditate.\nUt alias voluptates voluptas quisquam.\nSequi veniam neque officia voluptatum esse omnis est mollitia enim.\nRepellat ut et animi a fugiat similique." },
                    { 2, 63, 52, 766333, new DateTime(2021, 1, 16, 1, 28, 26, 36, DateTimeKind.Local).AddTicks(9275), "Dolore odit repudiandae corrupti. Qui reiciendis architecto dolorem ea omnis non sit voluptate voluptatibus. Occaecati officiis voluptatem et voluptatibus in rerum placeat. Qui provident facere soluta soluta. Qui sit molestiae qui in." },
                    { 156, 63, 56, 918187, new DateTime(2021, 3, 31, 9, 23, 0, 186, DateTimeKind.Local).AddTicks(8556), "Consequatur quia et rem eum. Sapiente quaerat occaecati eum sed minus modi. Id ipsum voluptatem eos reprehenderit et illo dolorem quae asperiores. Numquam vel deserunt quia blanditiis magni aliquam doloremque." },
                    { 404, 1, 39, 59487, new DateTime(2020, 12, 5, 2, 33, 37, 519, DateTimeKind.Local).AddTicks(9374), "Debitis est et." },
                    { 405, 1, 14, 26180, new DateTime(2021, 5, 27, 17, 52, 42, 641, DateTimeKind.Local).AddTicks(1029), "Et voluptatum et id qui quia excepturi temporibus qui. Magnam aut aut consequatur nulla dolorum dolorum ipsa assumenda qui. Nihil occaecati voluptate laboriosam beatae at pariatur aliquam. Et aperiam sequi suscipit et. Vel quod odio maiores nobis tempora quasi. Quo omnis qui quaerat voluptas odio eum." },
                    { 545, 1, 115, 882059, new DateTime(2020, 9, 1, 12, 40, 35, 439, DateTimeKind.Local).AddTicks(9006), "Earum error aut dolorum dolores voluptatibus.\nPorro corrupti autem.\nTotam totam dicta quaerat illum quia fugit quibusdam.\nMolestias similique nobis quo et ipsum atque quae odio accusantium.\nOdit quidem tempora iste suscipit delectus.\nSuscipit eos et architecto placeat velit dolores qui." },
                    { 256, 26, 98, 330834, new DateTime(2020, 9, 3, 1, 35, 47, 706, DateTimeKind.Local).AddTicks(5663), "mollitia" },
                    { 382, 26, 26, 13201, new DateTime(2020, 10, 9, 0, 46, 2, 802, DateTimeKind.Local).AddTicks(7344), "Voluptatem porro nemo sed et assumenda quisquam." },
                    { 572, 26, 6, 465987, new DateTime(2021, 1, 11, 6, 58, 40, 187, DateTimeKind.Local).AddTicks(83), "voluptatem" },
                    { 98, 39, 122, 144145, new DateTime(2020, 11, 18, 16, 4, 54, 899, DateTimeKind.Local).AddTicks(5595), "Est quas ut sunt et cum quas omnis exercitationem eum." },
                    { 195, 39, 6, 656509, new DateTime(2021, 4, 9, 20, 13, 22, 998, DateTimeKind.Local).AddTicks(569), "Doloribus laudantium unde modi totam.\nPorro vel debitis ipsa est mollitia et." },
                    { 367, 39, 80, 733669, new DateTime(2021, 4, 10, 4, 59, 13, 388, DateTimeKind.Local).AddTicks(2289), "Non et praesentium voluptatem provident." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 498, 39, 29, 462841, new DateTime(2021, 3, 27, 15, 32, 58, 766, DateTimeKind.Local).AddTicks(686), "quidem" },
                    { 532, 39, 141, 955310, new DateTime(2021, 7, 14, 19, 50, 35, 156, DateTimeKind.Local).AddTicks(2922), "Minima dolore rerum voluptas aut quia vel maxime eum.\nAut tempora illum.\nSed quam aut est eum." },
                    { 568, 39, 100, 439971, new DateTime(2021, 6, 13, 21, 35, 23, 65, DateTimeKind.Local).AddTicks(9458), "Tempora laudantium magnam neque adipisci non minus fugit." },
                    { 153, 46, 132, 159955, new DateTime(2021, 4, 1, 7, 31, 38, 735, DateTimeKind.Local).AddTicks(4848), "Non et eveniet autem est similique cumque numquam et quas." },
                    { 165, 46, 14, 620623, new DateTime(2021, 1, 29, 18, 23, 45, 101, DateTimeKind.Local).AddTicks(2866), "Illum repellat recusandae ducimus ut a." },
                    { 224, 46, 115, 20751, new DateTime(2021, 6, 4, 20, 6, 26, 557, DateTimeKind.Local).AddTicks(2405), "Adipisci numquam et veniam accusantium in fugit ut. Quia nulla rerum eligendi in quis omnis est. Vel ea voluptatem quis." },
                    { 308, 1, 65, 636442, new DateTime(2021, 6, 21, 23, 17, 34, 837, DateTimeKind.Local).AddTicks(3440), "Fugit officiis ab eveniet iure ex aperiam est suscipit ipsam." },
                    { 183, 1, 32, 879541, new DateTime(2021, 3, 14, 8, 7, 36, 947, DateTimeKind.Local).AddTicks(8118), "Illum recusandae aperiam qui sed corporis non sed. Aut sunt placeat incidunt laudantium. Laudantium illum ab. Sed ex rerum provident. Sint ipsam possimus et totam possimus. Commodi iusto sed eum sed non nobis." },
                    { 135, 1, 26, 529888, new DateTime(2021, 2, 1, 8, 54, 36, 124, DateTimeKind.Local).AddTicks(8579), "Quod natus sit.\nNemo omnis inventore repudiandae provident a ut pariatur vel." },
                    { 71, 1, 49, 950114, new DateTime(2021, 5, 15, 22, 17, 52, 284, DateTimeKind.Local).AddTicks(7579), "Rerum quisquam at id beatae qui.\nAtque tempora et autem id est expedita quos.\nMolestias eligendi soluta repellat aut iste vel quia." },
                    { 90, 53, 42, 321874, new DateTime(2020, 11, 30, 7, 13, 21, 457, DateTimeKind.Local).AddTicks(5836), "Suscipit dolorum aut." },
                    { 274, 53, 121, 946592, new DateTime(2020, 10, 12, 13, 37, 21, 146, DateTimeKind.Local).AddTicks(8758), "Et beatae beatae. Pariatur est voluptas voluptatem quam dolorem mollitia. Provident illo autem sit cupiditate repudiandae consequuntur nesciunt ut. Quaerat officiis in temporibus expedita minus tempore et. Debitis aut ratione voluptas facere." },
                    { 474, 53, 11, 680914, new DateTime(2021, 4, 10, 6, 5, 20, 965, DateTimeKind.Local).AddTicks(6698), "qui" },
                    { 593, 53, 121, 841998, new DateTime(2021, 6, 4, 3, 42, 24, 472, DateTimeKind.Local).AddTicks(8498), "nihil" },
                    { 595, 53, 41, 173127, new DateTime(2021, 3, 19, 13, 54, 36, 251, DateTimeKind.Local).AddTicks(8817), "Perspiciatis deserunt esse quam velit qui porro." },
                    { 124, 68, 139, 640295, new DateTime(2021, 7, 25, 10, 45, 8, 495, DateTimeKind.Local).AddTicks(4102), "Omnis perspiciatis id.\nEsse vitae consequatur animi eligendi sapiente quo rerum culpa ad.\nPariatur dolor hic ex deserunt quia sed.\nQuisquam aliquam vel aperiam quis." },
                    { 193, 68, 117, 902288, new DateTime(2020, 8, 21, 22, 4, 50, 153, DateTimeKind.Local).AddTicks(7217), "Aperiam non quo dolore nemo deserunt mollitia." },
                    { 297, 46, 81, 758964, new DateTime(2021, 4, 11, 22, 55, 18, 900, DateTimeKind.Local).AddTicks(5080), "Voluptatem fugit quia et est odio illum. Quo mollitia rerum sed voluptatem praesentium dolores qui veritatis eligendi. Quia quos asperiores exercitationem incidunt et temporibus repellendus omnis fugit. Adipisci illo nobis." },
                    { 340, 68, 5, 88000, new DateTime(2021, 4, 9, 6, 36, 19, 593, DateTimeKind.Local).AddTicks(4278), "reprehenderit" },
                    { 561, 68, 21, 636802, new DateTime(2020, 8, 20, 6, 57, 14, 589, DateTimeKind.Local).AddTicks(1669), "exercitationem" },
                    { 55, 79, 114, 347262, new DateTime(2020, 8, 14, 20, 17, 6, 856, DateTimeKind.Local).AddTicks(4000), "Aspernatur veniam odit consectetur similique consequatur dolore sunt ad magnam." },
                    { 286, 79, 6, 771305, new DateTime(2020, 10, 5, 11, 28, 31, 117, DateTimeKind.Local).AddTicks(4923), "Qui accusamus porro nisi ut. Non libero consequatur nisi culpa adipisci veritatis. Animi explicabo suscipit at tempora pariatur ipsam. Et architecto rerum rerum quo mollitia porro nemo sit. Ea ipsum sunt. Voluptatem id molestiae." },
                    { 406, 79, 49, 268473, new DateTime(2021, 2, 6, 8, 48, 58, 903, DateTimeKind.Local).AddTicks(9458), "tenetur" },
                    { 470, 79, 87, 373989, new DateTime(2021, 7, 25, 20, 16, 51, 757, DateTimeKind.Local).AddTicks(5865), "consequatur" },
                    { 485, 79, 66, 28407, new DateTime(2020, 9, 21, 1, 51, 43, 9, DateTimeKind.Local).AddTicks(2412), "Similique cumque magnam nihil nihil libero.\nVoluptatem odit quia molestias ea in quia.\nEt iste aut.\nSuscipit ad et voluptatem." },
                    { 505, 79, 57, 445749, new DateTime(2020, 11, 26, 8, 17, 34, 699, DateTimeKind.Local).AddTicks(5296), "voluptas" },
                    { 557, 68, 108, 479190, new DateTime(2020, 12, 17, 3, 38, 1, 567, DateTimeKind.Local).AddTicks(926), "Consectetur rerum maiores ut consequatur molestias exercitationem eum beatae.\nRerum itaque modi.\nNon voluptatem incidunt esse id eligendi.\nTempora consequuntur commodi explicabo.\nAut omnis pariatur voluptatem fuga dignissimos aut omnis eligendi.\nQuas hic omnis." },
                    { 366, 46, 113, 110584, new DateTime(2021, 6, 3, 9, 35, 57, 260, DateTimeKind.Local).AddTicks(2258), "voluptate" },
                    { 490, 46, 111, 160727, new DateTime(2021, 6, 20, 10, 19, 56, 8, DateTimeKind.Local).AddTicks(9697), "delectus" },
                    { 20, 91, 7, 388385, new DateTime(2021, 1, 23, 2, 11, 23, 38, DateTimeKind.Local).AddTicks(5693), "Delectus possimus blanditiis.\nBeatae et praesentium aperiam.\nQuo dolor ea qui nesciunt.\nAutem sint magnam est odit." },
                    { 111, 81, 89, 391297, new DateTime(2021, 8, 9, 6, 15, 14, 747, DateTimeKind.Local).AddTicks(8936), "Consequatur ipsam placeat sit dignissimos eveniet natus quasi veritatis officiis.\nNatus omnis dicta maiores dignissimos.\nVoluptatem eum cumque nulla maxime." },
                    { 119, 81, 32, 785653, new DateTime(2021, 7, 7, 12, 9, 38, 482, DateTimeKind.Local).AddTicks(918), "nam" },
                    { 144, 81, 34, 781680, new DateTime(2020, 12, 5, 8, 8, 34, 369, DateTimeKind.Local).AddTicks(6641), "Libero earum qui aperiam." },
                    { 199, 81, 6, 286662, new DateTime(2021, 1, 26, 19, 14, 2, 456, DateTimeKind.Local).AddTicks(192), "Qui et molestiae ut accusantium voluptas voluptates quia vero." },
                    { 390, 81, 51, 695978, new DateTime(2021, 1, 21, 10, 36, 0, 936, DateTimeKind.Local).AddTicks(9365), "Modi quasi at repudiandae molestias illo.\nOmnis odio vel aliquid error.\nLaudantium voluptatibus aliquid ex ipsam quo nihil odio.\nHic ad rerum." },
                    { 440, 81, 82, 840589, new DateTime(2021, 3, 6, 4, 58, 11, 513, DateTimeKind.Local).AddTicks(5342), "Sit praesentium eos quasi ut asperiores iste quos.\nSit est amet quisquam sint totam et quam.\nFacere et inventore hic perferendis qui voluptas.\nQuo fuga quo soluta cum magni temporibus." },
                    { 294, 83, 88, 591756, new DateTime(2021, 3, 29, 9, 14, 44, 859, DateTimeKind.Local).AddTicks(919), "Odit sed neque autem." },
                    { 56, 81, 134, 276951, new DateTime(2021, 1, 15, 0, 23, 56, 132, DateTimeKind.Local).AddTicks(5645), "Velit est esse facilis voluptatem dolorum quia fugiat necessitatibus.\nAt tempora deserunt ab quam quasi maiores accusamus.\nUllam at vel optio tenetur voluptate sint hic molestias est.\nEx voluptatem minus dolor ducimus et necessitatibus suscipit rerum.\nVoluptatibus ex cum et reprehenderit et soluta velit." },
                    { 343, 83, 25, 511917, new DateTime(2021, 6, 4, 0, 32, 21, 535, DateTimeKind.Local).AddTicks(2209), "Architecto quo ea voluptatum libero.\nSint nulla rerum.\nOptio impedit suscipit eos non qui assumenda excepturi.\nEt odit soluta dignissimos asperiores beatae a laborum id." },
                    { 388, 83, 113, 898409, new DateTime(2021, 6, 26, 5, 46, 37, 630, DateTimeKind.Local).AddTicks(6552), "tempora" },
                    { 518, 83, 99, 581826, new DateTime(2020, 10, 12, 4, 30, 7, 912, DateTimeKind.Local).AddTicks(7811), "accusantium" },
                    { 81, 74, 93, 824372, new DateTime(2021, 4, 15, 21, 43, 45, 582, DateTimeKind.Local).AddTicks(8388), "Qui molestias porro voluptate quia ut nostrum pariatur. Consequatur minima voluptatem est neque sed consequatur. Amet ipsa repellat voluptates doloremque quod dolore eos quia in. Voluptas quaerat ducimus et voluptate. Dolore adipisci rerum. Et vel omnis illo dignissimos." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 171, 74, 35, 237282, new DateTime(2021, 6, 2, 5, 21, 11, 372, DateTimeKind.Local).AddTicks(8483), "Adipisci et laboriosam quia est atque ipsa.\nNatus impedit accusamus hic consequatur.\nDolore nostrum aut eum inventore aut labore." },
                    { 352, 74, 149, 82141, new DateTime(2021, 7, 16, 6, 19, 17, 373, DateTimeKind.Local).AddTicks(33), "Eius ex recusandae non nam. Ut sequi sequi doloribus qui qui qui animi consequatur. Quidem qui aut nesciunt libero illo qui mollitia fugiat. Deleniti autem dolorum necessitatibus amet laudantium alias adipisci molestiae. Sequi accusamus similique distinctio officia. Consequatur quia autem porro incidunt." },
                    { 361, 74, 91, 424657, new DateTime(2021, 5, 12, 8, 35, 30, 5, DateTimeKind.Local).AddTicks(1717), "Ex cupiditate iure.\nEveniet velit non placeat dolorum iusto voluptas autem id voluptate.\nQuidem explicabo ea est ullam corrupti blanditiis.\nId quaerat quo eos qui quos.\nEaque quibusdam est." },
                    { 380, 74, 25, 51036, new DateTime(2020, 8, 27, 5, 5, 23, 762, DateTimeKind.Local).AddTicks(6184), "Rerum occaecati vitae qui iste aperiam quisquam facere at." },
                    { 386, 83, 107, 979581, new DateTime(2021, 1, 24, 12, 3, 32, 274, DateTimeKind.Local).AddTicks(8346), "Autem et quasi quas. Exercitationem enim est. At ipsa repellat quae omnis et nemo sed est veniam." },
                    { 37, 53, 58, 866912, new DateTime(2021, 2, 18, 15, 24, 6, 593, DateTimeKind.Local).AddTicks(4900), "Sed enim debitis deleniti consequatur." },
                    { 31, 81, 91, 565732, new DateTime(2021, 5, 2, 14, 46, 16, 315, DateTimeKind.Local).AddTicks(9148), "Culpa consectetur assumenda vel." },
                    { 333, 43, 96, 173516, new DateTime(2021, 1, 6, 14, 45, 48, 725, DateTimeKind.Local).AddTicks(8369), "Quia sed quo." },
                    { 30, 91, 150, 72317, new DateTime(2021, 2, 11, 0, 12, 43, 573, DateTimeKind.Local).AddTicks(6158), "Eum et aut voluptatem quia ipsam qui natus nihil." },
                    { 34, 91, 64, 355381, new DateTime(2021, 3, 3, 8, 27, 38, 790, DateTimeKind.Local).AddTicks(2347), "Doloribus eaque ullam assumenda blanditiis qui.\nLibero ad nihil ea omnis consequatur dolore." },
                    { 173, 91, 102, 534607, new DateTime(2020, 12, 9, 9, 51, 28, 331, DateTimeKind.Local).AddTicks(221), "rerum" },
                    { 208, 91, 98, 179741, new DateTime(2020, 8, 15, 12, 4, 36, 62, DateTimeKind.Local).AddTicks(2007), "aut" },
                    { 246, 91, 13, 438398, new DateTime(2021, 2, 2, 12, 3, 22, 977, DateTimeKind.Local).AddTicks(8686), "Vel id non laudantium deleniti repudiandae rem natus.\nSuscipit ab voluptates adipisci voluptatibus iste quod.\nEt ea labore velit eos et nisi aut.\nInventore consequuntur libero aliquid possimus exercitationem aut." },
                    { 292, 91, 6, 545859, new DateTime(2021, 6, 7, 7, 2, 39, 359, DateTimeKind.Local).AddTicks(5140), "Et voluptatum hic ut nisi possimus harum quaerat et. Et quae sequi et assumenda quia sed. Voluptatibus maiores qui quia ut voluptas voluptatem sit eum quaerat. Dolores eaque tenetur ut id consequatur eligendi aut. Sint officiis ipsam corrupti et a facilis." },
                    { 363, 91, 118, 204005, new DateTime(2020, 10, 18, 11, 57, 24, 22, DateTimeKind.Local).AddTicks(4762), "quos" },
                    { 348, 43, 142, 586602, new DateTime(2021, 3, 2, 2, 29, 36, 841, DateTimeKind.Local).AddTicks(9498), "Sed placeat aut accusamus ut fugit quia debitis expedita possimus.\nEt repellat culpa commodi." },
                    { 411, 91, 63, 530578, new DateTime(2020, 12, 20, 16, 29, 1, 894, DateTimeKind.Local).AddTicks(180), "Eligendi veniam vitae quo inventore sit sunt." },
                    { 579, 91, 6, 196434, new DateTime(2020, 11, 11, 14, 18, 18, 997, DateTimeKind.Local).AddTicks(3225), "Ad ut corrupti nulla at.\nSuscipit dolor corrupti occaecati sed voluptas laboriosam est.\nSuscipit est et et debitis dolor distinctio voluptatum repellat iusto.\nTempora porro vel corrupti nihil.\nLaboriosam et sed et ex.\nMollitia natus et impedit autem nemo." },
                    { 68, 76, 31, 274173, new DateTime(2021, 1, 11, 22, 12, 56, 912, DateTimeKind.Local).AddTicks(9707), "Quia reprehenderit dignissimos molestiae. Ut eveniet dolorem neque dignissimos. Expedita error ab ut est et ut dolores porro. Quia voluptas alias magnam molestiae quibusdam enim necessitatibus ipsam. Enim enim voluptatem maiores molestias possimus porro numquam." },
                    { 243, 76, 25, 839659, new DateTime(2021, 7, 29, 18, 35, 48, 252, DateTimeKind.Local).AddTicks(2778), "sit" },
                    { 524, 76, 146, 648311, new DateTime(2021, 5, 4, 19, 2, 6, 578, DateTimeKind.Local).AddTicks(1272), "Quia qui fuga est at iusto tempore est." },
                    { 575, 76, 74, 789911, new DateTime(2020, 9, 23, 7, 37, 54, 362, DateTimeKind.Local).AddTicks(1807), "Non et aut voluptatem quia et consequatur.\nQuasi fugit nobis.\nQuidem aut illum est vel dicta illum accusamus molestias sit.\nSed quia officia labore aut voluptas qui." },
                    { 10, 43, 128, 125674, new DateTime(2020, 10, 20, 9, 42, 53, 144, DateTimeKind.Local).AddTicks(4474), "Consequatur consequatur unde quaerat sint inventore dolores qui ut occaecati." },
                    { 77, 43, 94, 993938, new DateTime(2021, 6, 14, 8, 13, 51, 497, DateTimeKind.Local).AddTicks(2406), "Accusamus et occaecati enim.\nImpedit eum laborum deserunt officiis corrupti.\nOmnis occaecati rerum cumque voluptates.\nAliquid ut ut autem." },
                    { 537, 91, 127, 306576, new DateTime(2020, 8, 20, 16, 21, 47, 961, DateTimeKind.Local).AddTicks(5249), "Dolor aut exercitationem ut harum. Quaerat ab ut. Aspernatur sed culpa earum et ipsum quis aut. Soluta repudiandae aut autem labore est error accusantium." },
                    { 22, 63, 16, 260465, new DateTime(2020, 8, 17, 20, 24, 56, 241, DateTimeKind.Local).AddTicks(9260), "et" },
                    { 507, 17, 88, 560416, new DateTime(2021, 3, 11, 10, 56, 58, 377, DateTimeKind.Local).AddTicks(3201), "nulla" },
                    { 482, 17, 143, 127775, new DateTime(2020, 11, 17, 8, 42, 12, 747, DateTimeKind.Local).AddTicks(4593), "Vel in aut et. Quia modi ut fuga et maiores. Aut quod quo numquam. Repellendus a voluptatem consequatur reiciendis. Dolores similique eligendi et voluptatem." },
                    { 160, 19, 134, 701104, new DateTime(2021, 2, 25, 16, 53, 56, 542, DateTimeKind.Local).AddTicks(2624), "Accusamus quisquam nisi adipisci.\nOmnis et quos.\nCupiditate omnis optio.\nEt nam molestiae quis.\nOdio est illum tenetur facere aut non quas porro occaecati.\nOmnis minus dolores maiores accusantium incidunt quas et qui." },
                    { 285, 19, 39, 575059, new DateTime(2021, 2, 21, 14, 42, 21, 625, DateTimeKind.Local).AddTicks(3615), "Nihil molestias repellat sapiente corrupti.\nOdio praesentium animi repellat error magni veniam illum et.\nQuisquam et qui enim sit dolorem itaque.\nNostrum atque odio.\nVoluptatem ut reprehenderit delectus aperiam hic delectus nihil cumque.\nIpsa ipsum adipisci magni eius modi." },
                    { 221, 37, 75, 7025, new DateTime(2020, 10, 5, 2, 24, 44, 461, DateTimeKind.Local).AddTicks(4507), "Id est voluptatibus error velit." },
                    { 301, 37, 12, 686308, new DateTime(2021, 3, 11, 5, 59, 58, 272, DateTimeKind.Local).AddTicks(3064), "minima" },
                    { 336, 37, 118, 481632, new DateTime(2020, 10, 9, 7, 11, 49, 843, DateTimeKind.Local).AddTicks(6842), "Corrupti tempora reprehenderit magni veritatis libero voluptatem. Distinctio ab asperiores cupiditate voluptatem. Velit aliquid in vel. Quia dolores saepe unde harum. Quaerat ut temporibus possimus repellat rem possimus dolorem ipsa consectetur. Error nobis exercitationem culpa et dolores voluptatem dolores doloremque est." },
                    { 472, 37, 45, 862315, new DateTime(2020, 10, 18, 17, 52, 43, 22, DateTimeKind.Local).AddTicks(8204), "Consequatur veniam suscipit.\nEt ut doloribus eos iste nam vero totam sunt.\nDolor esse aperiam necessitatibus pariatur dolor perferendis magni aut sequi.\nSuscipit iure qui beatae fugit autem quidem optio." },
                    { 318, 104, 36, 685694, new DateTime(2021, 5, 11, 8, 50, 35, 188, DateTimeKind.Local).AddTicks(7958), "doloribus" },
                    { 341, 104, 147, 612335, new DateTime(2020, 8, 18, 17, 4, 37, 711, DateTimeKind.Local).AddTicks(1870), "Et ducimus ullam.\nVeniam doloremque accusamus est possimus aliquam dolores vel earum soluta." },
                    { 584, 104, 13, 498147, new DateTime(2021, 6, 3, 7, 47, 20, 5, DateTimeKind.Local).AddTicks(7912), "et" },
                    { 79, 60, 40, 287296, new DateTime(2021, 3, 21, 19, 56, 32, 234, DateTimeKind.Local).AddTicks(2439), "Et libero expedita consequuntur.\nVoluptas vel ipsa debitis.\nDebitis aliquid voluptatibus earum sunt." },
                    { 365, 60, 30, 665855, new DateTime(2021, 3, 31, 7, 11, 42, 83, DateTimeKind.Local).AddTicks(3708), "Cupiditate et qui et ex sit ipsam dignissimos. Eos ab labore quo aut ut enim. Sit minus est minus iste qui velit." },
                    { 462, 60, 116, 980505, new DateTime(2021, 7, 23, 21, 49, 30, 795, DateTimeKind.Local).AddTicks(1976), "Sint minima error pariatur vel temporibus deleniti neque. Est culpa hic. Consectetur deserunt perspiciatis harum ea. Minus qui et cum." },
                    { 210, 106, 135, 913592, new DateTime(2021, 4, 24, 17, 37, 55, 942, DateTimeKind.Local).AddTicks(5155), "dolorem" },
                    { 227, 106, 89, 539860, new DateTime(2021, 4, 4, 8, 2, 3, 308, DateTimeKind.Local).AddTicks(3425), "Qui amet et non molestiae possimus in dolores perferendis quaerat.\nNulla ut officiis aut voluptatum esse assumenda deleniti.\nNemo soluta est.\nFacere alias laudantium iure et doloremque temporibus aperiam quia.\nSequi nam commodi et ea et aperiam eveniet.\nId aut nemo deleniti exercitationem." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 280, 106, 12, 846051, new DateTime(2021, 4, 1, 6, 28, 9, 705, DateTimeKind.Local).AddTicks(8769), "Porro mollitia natus dolores. Ullam minus ipsum rem. Molestiae autem a rem quae ea ut ab accusamus. Dolor illo esse qui accusantium et sit ipsa quas." },
                    { 59, 19, 55, 997926, new DateTime(2020, 11, 14, 6, 33, 30, 979, DateTimeKind.Local).AddTicks(7375), "voluptatum" },
                    { 546, 8, 138, 353801, new DateTime(2020, 11, 28, 11, 52, 33, 989, DateTimeKind.Local).AddTicks(2314), "Reiciendis saepe autem debitis ut doloribus quia et aut. Praesentium ut rerum eum et. Molestiae pariatur quidem omnis recusandae iure iusto. Enim laboriosam eveniet tempora animi quae cum ab expedita. Distinctio suscipit sit blanditiis repellat. Perferendis commodi cupiditate quibusdam nostrum excepturi vero eveniet." },
                    { 456, 8, 119, 103346, new DateTime(2020, 10, 7, 12, 48, 55, 666, DateTimeKind.Local).AddTicks(7291), "Non maiores corrupti labore provident voluptas quos iste odit.\nDolorum quia hic.\nTenetur rerum fugit assumenda.\nVoluptatum qui omnis aut et consequatur facilis.\nIncidunt enim saepe suscipit.\nProvident excepturi neque corporis culpa ea." },
                    { 316, 8, 16, 176597, new DateTime(2021, 7, 9, 9, 34, 40, 816, DateTimeKind.Local).AddTicks(8068), "Deserunt temporibus vel sit voluptates ea.\nQuae quisquam enim eius et.\nOfficia omnis corrupti ea perspiciatis.\nQuia dolor et neque sed." },
                    { 169, 63, 132, 381920, new DateTime(2021, 1, 21, 12, 51, 52, 461, DateTimeKind.Local).AddTicks(8615), "Repellat eum blanditiis et minus et vero corrupti sunt nostrum.\nEa delectus voluptatem ab modi temporibus numquam doloremque.\nPerspiciatis earum voluptas ipsam expedita." },
                    { 350, 63, 18, 17132, new DateTime(2021, 6, 20, 7, 13, 16, 183, DateTimeKind.Local).AddTicks(2099), "Quia aliquam tempore.\nIn sunt non maxime dicta officiis odio et unde explicabo." },
                    { 397, 63, 80, 498880, new DateTime(2020, 11, 20, 4, 39, 15, 211, DateTimeKind.Local).AddTicks(5015), "Debitis ut quae praesentium consequatur quaerat facilis consequatur est consequuntur." },
                    { 416, 63, 63, 616304, new DateTime(2021, 3, 11, 7, 48, 7, 767, DateTimeKind.Local).AddTicks(4406), "Labore asperiores eos aliquid ut quisquam autem voluptatum ipsam ut." },
                    { 431, 63, 45, 908287, new DateTime(2021, 4, 1, 7, 32, 41, 143, DateTimeKind.Local).AddTicks(2640), "Excepturi molestiae at corporis rerum. Rem sit ea. Dolor necessitatibus et iusto quia minima rem aspernatur voluptatem. Eos quas ea." },
                    { 500, 63, 135, 592766, new DateTime(2021, 6, 4, 21, 41, 32, 94, DateTimeKind.Local).AddTicks(6350), "Neque delectus fuga non nobis impedit perferendis id at qui." },
                    { 516, 63, 29, 658723, new DateTime(2021, 4, 23, 16, 31, 34, 602, DateTimeKind.Local).AddTicks(5082), "veniam" },
                    { 283, 106, 142, 105675, new DateTime(2021, 6, 15, 6, 7, 10, 178, DateTimeKind.Local).AddTicks(8658), "Magnam sunt iusto omnis ut est maiores." },
                    { 559, 63, 63, 953466, new DateTime(2021, 4, 25, 6, 56, 42, 405, DateTimeKind.Local).AddTicks(4160), "Vitae numquam omnis molestias quia labore facere sapiente.\nEt quod fuga non deserunt id ratione qui non.\nQui natus accusantium id odit a ducimus soluta vel in." },
                    { 112, 59, 7, 394588, new DateTime(2020, 8, 29, 18, 35, 5, 44, DateTimeKind.Local).AddTicks(6995), "Voluptas sint voluptates consequatur minus. Aut et labore doloribus in dolorum aliquam id facilis qui. Ullam facere cumque quo temporibus ut accusamus qui. Et nemo ea. Vero recusandae repellat placeat exercitationem." },
                    { 154, 59, 124, 797152, new DateTime(2020, 10, 5, 15, 18, 21, 928, DateTimeKind.Local).AddTicks(6714), "Nesciunt dicta voluptas.\nPraesentium dolor enim iure." },
                    { 203, 59, 67, 823909, new DateTime(2021, 5, 9, 1, 50, 48, 230, DateTimeKind.Local).AddTicks(6853), "Iusto dolore veniam velit quaerat quia officiis nisi saepe." },
                    { 402, 59, 110, 972432, new DateTime(2021, 3, 15, 6, 25, 37, 695, DateTimeKind.Local).AddTicks(4406), "Sapiente quidem voluptate sed." },
                    { 484, 59, 95, 281183, new DateTime(2021, 5, 24, 7, 7, 40, 921, DateTimeKind.Local).AddTicks(6761), "Est voluptates facilis ut quidem deleniti rerum est rerum recusandae.\nNon consequuntur sed totam.\nAut sapiente enim.\nDolores molestias in consequatur fugiat atque officia vero voluptates excepturi." },
                    { 562, 59, 114, 445918, new DateTime(2021, 2, 19, 19, 6, 58, 904, DateTimeKind.Local).AddTicks(681), "illo" },
                    { 15, 8, 26, 626802, new DateTime(2021, 1, 24, 14, 33, 38, 335, DateTimeKind.Local).AddTicks(5553), "Omnis officiis recusandae." },
                    { 23, 59, 110, 276938, new DateTime(2020, 10, 8, 17, 5, 57, 249, DateTimeKind.Local).AddTicks(3914), "aut" },
                    { 359, 106, 90, 220043, new DateTime(2020, 10, 31, 12, 6, 47, 299, DateTimeKind.Local).AddTicks(5097), "Consequatur eius et tempore modi ut repellat.\nQuo et eligendi quibusdam.\nMinima earum consectetur quia reprehenderit non.\nAliquid voluptatum totam dolore ut praesentium cupiditate voluptatem." },
                    { 374, 106, 149, 349663, new DateTime(2021, 2, 5, 16, 7, 27, 335, DateTimeKind.Local).AddTicks(4182), "Odit id dignissimos similique qui doloribus.\nVoluptatem voluptatem perspiciatis laudantium dolorum et.\nBlanditiis possimus perspiciatis magni quibusdam totam.\nAperiam facere et assumenda iste illo." },
                    { 424, 106, 22, 375420, new DateTime(2020, 11, 11, 14, 43, 48, 989, DateTimeKind.Local).AddTicks(6090), "Ipsa accusamus odit quis earum id sit blanditiis. Et id dignissimos odit temporibus. Numquam aut sint est. Eos nihil ratione ut sunt nemo ullam." },
                    { 69, 47, 6, 911475, new DateTime(2021, 8, 5, 14, 4, 38, 926, DateTimeKind.Local).AddTicks(9747), "Quam qui enim tenetur repudiandae in.\nVel rem alias veritatis dignissimos tempore.\nRem fuga minima pariatur facere deserunt.\nEsse veritatis doloremque perferendis non." },
                    { 166, 47, 83, 152574, new DateTime(2021, 7, 11, 6, 45, 20, 507, DateTimeKind.Local).AddTicks(5681), "Totam ipsa saepe at." },
                    { 242, 47, 68, 943766, new DateTime(2020, 12, 29, 1, 17, 30, 591, DateTimeKind.Local).AddTicks(5152), "Ab numquam ullam possimus voluptatem cumque eius ut.\nIncidunt aut fugiat ut eveniet iste facere et cupiditate est.\nAdipisci illum velit quaerat sint iusto sed.\nEaque eos aut aliquid culpa animi aperiam est.\nQuia labore possimus.\nRecusandae similique id sapiente porro tempora omnis corporis magnam et." },
                    { 299, 47, 139, 677425, new DateTime(2020, 11, 23, 13, 34, 56, 949, DateTimeKind.Local).AddTicks(8389), "Enim corrupti repellat aut magni enim qui aut.\nItaque et voluptatem autem illum ea officia at molestiae cumque.\nAb temporibus deleniti." },
                    { 330, 47, 107, 591426, new DateTime(2021, 3, 2, 18, 10, 3, 359, DateTimeKind.Local).AddTicks(7935), "Omnis ullam cum nostrum pariatur quia ipsa quo ut." },
                    { 491, 47, 104, 665634, new DateTime(2020, 10, 20, 9, 25, 31, 239, DateTimeKind.Local).AddTicks(1601), "Mollitia facilis dolor debitis in rerum odio quam illum." },
                    { 102, 7, 128, 927444, new DateTime(2021, 8, 8, 0, 10, 51, 488, DateTimeKind.Local).AddTicks(2641), "Quidem adipisci et deserunt aut quis aliquam aliquid quia." },
                    { 438, 2, 126, 180105, new DateTime(2021, 2, 4, 17, 27, 23, 266, DateTimeKind.Local).AddTicks(2366), "Quia aperiam molestias et voluptatem. Sed nobis molestias. Error cupiditate non eos id qui sapiente provident sunt. Voluptatibus sapiente aut consectetur tempore. Neque magni qui mollitia. Molestiae ratione ipsa eligendi." },
                    { 110, 7, 139, 280642, new DateTime(2020, 12, 5, 15, 44, 24, 696, DateTimeKind.Local).AddTicks(1907), "quo" },
                    { 263, 7, 59, 517781, new DateTime(2021, 1, 22, 8, 14, 43, 669, DateTimeKind.Local).AddTicks(4120), "Molestiae et corrupti vero odit sed et illum tempora molestias. Cum fugiat voluptas et facilis quos delectus ut quis. Ea ut sed modi veniam corrupti." },
                    { 415, 7, 14, 573794, new DateTime(2021, 3, 21, 2, 23, 0, 111, DateTimeKind.Local).AddTicks(4102), "Cumque qui molestiae quas sequi doloremque placeat itaque totam aut.\nUnde blanditiis et repudiandae.\nDeserunt laborum dolor laudantium.\nRecusandae laboriosam vero sed saepe consequuntur autem." },
                    { 433, 7, 46, 235512, new DateTime(2021, 8, 3, 19, 54, 45, 258, DateTimeKind.Local).AddTicks(3811), "Mollitia asperiores repellendus pariatur sit." },
                    { 463, 7, 41, 764246, new DateTime(2021, 1, 16, 7, 37, 1, 879, DateTimeKind.Local).AddTicks(1763), "Illo atque voluptatibus nobis eos possimus autem dolore temporibus esse. Praesentium sunt earum voluptas et eligendi odit quia. Deserunt fugiat aut porro repellat ab. Molestias accusamus qui voluptatem eligendi id sit. Explicabo delectus libero ab fugiat facere eum." },
                    { 468, 7, 11, 203230, new DateTime(2021, 5, 3, 18, 40, 46, 651, DateTimeKind.Local).AddTicks(793), "earum" },
                    { 67, 17, 122, 725790, new DateTime(2020, 10, 5, 18, 32, 14, 635, DateTimeKind.Local).AddTicks(3615), "Quis neque ut sed rerum error at ipsum aut.\nSequi velit eos voluptatibus harum." },
                    { 136, 17, 103, 163789, new DateTime(2021, 3, 1, 19, 35, 29, 51, DateTimeKind.Local).AddTicks(848), "At explicabo fuga illo vitae.\nIn aperiam ab occaecati.\nEx alias quia eligendi et ducimus similique dolores consequatur.\nOccaecati dolorem suscipit architecto recusandae esse quasi maxime beatae." },
                    { 128, 7, 54, 948651, new DateTime(2021, 4, 26, 15, 54, 16, 778, DateTimeKind.Local).AddTicks(5432), "Voluptatibus numquam modi enim occaecati rerum qui qui." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 496, 17, 138, 932138, new DateTime(2021, 2, 5, 7, 50, 12, 278, DateTimeKind.Local).AddTicks(5091), "eum" },
                    { 427, 2, 34, 151795, new DateTime(2021, 8, 8, 22, 48, 59, 294, DateTimeKind.Local).AddTicks(8696), "Harum nemo molestiae vitae ea molestiae et ut inventore.\nQuia perspiciatis nisi pariatur et similique ut omnis modi.\nQuidem nisi quo quod nostrum excepturi." },
                    { 387, 2, 138, 214752, new DateTime(2021, 1, 22, 11, 51, 37, 605, DateTimeKind.Local).AddTicks(4117), "Qui sed vero perspiciatis beatae libero saepe asperiores blanditiis minus. Autem omnis commodi possimus aut optio explicabo. Consequatur quos ipsum laudantium. Et similique et." },
                    { 75, 82, 14, 944260, new DateTime(2021, 5, 15, 21, 35, 3, 817, DateTimeKind.Local).AddTicks(7981), "Enim fugit et omnis voluptatibus quod est quia quisquam. Et sint dolorem ipsam repellat culpa. Vero expedita amet beatae id. Unde deleniti officiis nam aut. Incidunt aut consequatur quibusdam totam earum accusamus saepe iste." },
                    { 167, 82, 7, 809612, new DateTime(2021, 3, 15, 19, 15, 19, 943, DateTimeKind.Local).AddTicks(1138), "Dolorum error aliquid in beatae. Optio accusantium esse id autem placeat voluptatem dolores. Fugiat reprehenderit voluptas. Labore tempora voluptatem voluptatem." },
                    { 261, 82, 98, 702883, new DateTime(2021, 2, 13, 23, 11, 49, 788, DateTimeKind.Local).AddTicks(1946), "quaerat" },
                    { 335, 82, 63, 137056, new DateTime(2020, 11, 8, 16, 45, 8, 117, DateTimeKind.Local).AddTicks(1192), "Sed nemo numquam quia sint rerum repellat nihil sunt expedita.\nMagnam dolorum unde.\nVoluptas rerum et eos laborum cum quia a vel ea.\nQui eos consequatur perspiciatis.\nIpsum asperiores porro." },
                    { 354, 82, 125, 630337, new DateTime(2021, 8, 10, 9, 6, 5, 440, DateTimeKind.Local).AddTicks(6643), "cum" },
                    { 430, 82, 50, 862328, new DateTime(2021, 2, 26, 10, 54, 41, 435, DateTimeKind.Local).AddTicks(8895), "Doloribus placeat praesentium modi nemo ut.\nDolorem ab facere autem qui sint.\nExpedita cupiditate mollitia facilis quas eos doloribus necessitatibus.\nBlanditiis dicta et debitis quasi quaerat laudantium praesentium." },
                    { 476, 82, 140, 287209, new DateTime(2020, 11, 24, 10, 21, 28, 259, DateTimeKind.Local).AddTicks(5252), "Suscipit qui qui voluptas consequatur repellat. Optio qui quaerat omnis ut enim et. Enim quia ea nisi." },
                    { 403, 2, 79, 199897, new DateTime(2021, 6, 14, 19, 16, 15, 116, DateTimeKind.Local).AddTicks(9317), "Deleniti nihil qui molestias explicabo ab aut. Illum vitae dicta accusantium nisi pariatur aliquid ut corporis. Voluptatem id hic consequatur et numquam est sint sed ipsam. Accusamus eum voluptatibus ratione sed. Minus ut quaerat." },
                    { 489, 82, 146, 933066, new DateTime(2020, 11, 17, 7, 15, 32, 476, DateTimeKind.Local).AddTicks(7320), "Quo et et iste.\nVoluptate ipsa sint." },
                    { 248, 42, 128, 216761, new DateTime(2020, 9, 16, 20, 50, 13, 684, DateTimeKind.Local).AddTicks(8920), "atque" },
                    { 287, 42, 18, 568760, new DateTime(2020, 11, 1, 10, 19, 37, 32, DateTimeKind.Local).AddTicks(7746), "Nesciunt dolorum accusamus deleniti voluptas ea provident aut illo a. Rerum blanditiis deserunt vero. Tenetur cumque neque deleniti autem. Aperiam molestias omnis minus molestiae autem beatae culpa dolorem eum. Hic temporibus explicabo est labore laudantium." },
                    { 345, 42, 95, 935374, new DateTime(2021, 4, 3, 3, 0, 17, 105, DateTimeKind.Local).AddTicks(6705), "Eos enim omnis nostrum qui.\nMolestias quia est consequatur occaecati autem sunt incidunt.\nUt commodi qui impedit odio dolor.\nIusto eveniet sed et accusantium excepturi perspiciatis veniam." },
                    { 506, 42, 12, 415340, new DateTime(2020, 11, 2, 23, 4, 33, 748, DateTimeKind.Local).AddTicks(5913), "Ut eos laudantium vitae cupiditate voluptatibus alias dolorum." },
                    { 520, 42, 52, 288447, new DateTime(2020, 8, 16, 10, 54, 14, 170, DateTimeKind.Local).AddTicks(4127), "Voluptatem eius cumque.\nRepellat id et rem qui corporis expedita.\nNulla dolor et soluta repellat quam beatae exercitationem.\nConsequatur molestias in fuga et voluptates cumque similique nam." },
                    { 196, 2, 31, 432236, new DateTime(2021, 6, 15, 7, 51, 44, 469, DateTimeKind.Local).AddTicks(5834), "Porro nihil quas non." },
                    { 370, 2, 80, 414820, new DateTime(2021, 3, 20, 4, 47, 5, 516, DateTimeKind.Local).AddTicks(6281), "Dolorum sed sit sed libero earum vel delectus.\nEnim aut et natus quo fugit reprehenderit qui.\nNam labore eos necessitatibus aut minima.\nAut voluptatibus nulla placeat corrupti iusto officia dolores assumenda." },
                    { 197, 42, 119, 251196, new DateTime(2021, 2, 15, 6, 53, 51, 223, DateTimeKind.Local).AddTicks(5187), "Temporibus asperiores rerum odio unde at quae. Rem maiores aut dolores animi amet voluptatem cupiditate. Aliquid ea rerum et facere laudantium laboriosam debitis." },
                    { 445, 49, 92, 370804, new DateTime(2021, 1, 9, 7, 58, 59, 834, DateTimeKind.Local).AddTicks(8806), "Ut cupiditate similique facilis adipisci commodi dolore expedita ea dolor." },
                    { 288, 56, 77, 807790, new DateTime(2021, 4, 16, 16, 32, 32, 628, DateTimeKind.Local).AddTicks(5406), "Voluptatem fugiat asperiores iusto dolor laboriosam nam dolores.\nUt qui commodi cumque.\nAut nesciunt recusandae.\nDolores reprehenderit amet quas aut voluptas.\nPorro ut eum repudiandae in est nihil.\nAut culpa deserunt vel rerum quibusdam atque neque." },
                    { 279, 65, 136, 745154, new DateTime(2021, 7, 6, 11, 51, 56, 958, DateTimeKind.Local).AddTicks(6718), "Qui magnam aut placeat et quos molestiae.\nVelit voluptas dolorum.\nIn explicabo assumenda.\nMagni reprehenderit et ullam adipisci." },
                    { 108, 90, 91, 825418, new DateTime(2021, 1, 5, 5, 49, 30, 531, DateTimeKind.Local).AddTicks(9882), "Incidunt quibusdam eos unde et sunt aut. Vel qui ipsum consequuntur eius nulla doloremque. Aut optio aut. Rerum quo voluptates at totam vel ea eligendi. Blanditiis quia aut ipsum voluptate non minima. Nam et dolore." },
                    { 187, 90, 41, 760589, new DateTime(2021, 2, 17, 15, 23, 22, 466, DateTimeKind.Local).AddTicks(5309), "Ullam voluptatem quos.\nEt soluta quod vero consequatur eaque et ea.\nQuaerat hic voluptatibus odio voluptatem rem culpa beatae explicabo veniam." },
                    { 360, 14, 30, 978591, new DateTime(2021, 7, 14, 9, 56, 14, 236, DateTimeKind.Local).AddTicks(1105), "Voluptatibus blanditiis minus optio temporibus ut non quos." },
                    { 408, 90, 91, 652290, new DateTime(2021, 5, 1, 7, 0, 46, 937, DateTimeKind.Local).AddTicks(2944), "Et eum sit ex.\nHarum quas est et accusamus mollitia at.\nEarum impedit iure qui et est numquam molestiae non autem.\nSed maxime excepturi voluptate ut.\nFugit et nihil.\nTenetur qui ipsum labore corrupti dolor molestiae quibusdam voluptas." },
                    { 452, 90, 68, 841810, new DateTime(2021, 3, 28, 21, 35, 17, 655, DateTimeKind.Local).AddTicks(6911), "rem" },
                    { 502, 90, 81, 215542, new DateTime(2021, 4, 18, 17, 6, 53, 649, DateTimeKind.Local).AddTicks(7132), "Quidem ducimus quo vitae perspiciatis similique quis. Unde ut non. Dolor autem ad assumenda mollitia fugit. Libero in vitae repellendus necessitatibus esse dolorum." },
                    { 597, 40, 31, 178851, new DateTime(2021, 7, 21, 12, 13, 55, 20, DateTimeKind.Local).AddTicks(464), "Cumque consequatur doloribus dolorem sequi soluta beatae natus repudiandae fugit." },
                    { 442, 22, 22, 371632, new DateTime(2020, 9, 28, 1, 43, 55, 245, DateTimeKind.Local).AddTicks(4150), "Officiis consequatur vel.\nAssumenda praesentium enim.\nFacilis ex sint neque.\nVel illo dolorum.\nUt dicta enim quidem voluptatem molestiae tempore." },
                    { 510, 22, 96, 515373, new DateTime(2020, 12, 23, 22, 55, 41, 797, DateTimeKind.Local).AddTicks(3388), "Omnis neque at distinctio rerum. Recusandae ullam omnis voluptatem mollitia modi. In voluptates ipsa dolores. Ex minima occaecati quia excepturi." },
                    { 332, 14, 133, 687383, new DateTime(2021, 1, 23, 4, 52, 1, 52, DateTimeKind.Local).AddTicks(4643), "Cumque velit enim possimus velit iusto odio." },
                    { 92, 36, 133, 482342, new DateTime(2020, 9, 2, 0, 29, 54, 780, DateTimeKind.Local).AddTicks(9652), "Expedita aut suscipit perferendis ipsam et at iste iure.\nIllum tempore dolore.\nOdio doloribus qui reiciendis debitis iste.\nVoluptas qui illo quod ratione." },
                    { 181, 36, 132, 219407, new DateTime(2021, 6, 6, 12, 15, 52, 367, DateTimeKind.Local).AddTicks(1556), "hic" },
                    { 245, 36, 79, 22106, new DateTime(2020, 11, 28, 13, 2, 39, 113, DateTimeKind.Local).AddTicks(1299), "et" },
                    { 296, 36, 28, 256259, new DateTime(2020, 11, 16, 7, 23, 23, 168, DateTimeKind.Local).AddTicks(6078), "Deleniti aperiam voluptas tenetur.\nEst omnis qui ut dignissimos possimus dolores earum.\nNostrum quis ea quis asperiores asperiores sapiente voluptatem ut maxime.\nItaque nam nisi a voluptates ratione cupiditate nulla voluptatem aut." },
                    { 493, 22, 24, 747647, new DateTime(2021, 2, 4, 20, 43, 28, 642, DateTimeKind.Local).AddTicks(2774), "hic" },
                    { 432, 36, 114, 453613, new DateTime(2021, 5, 28, 15, 48, 26, 478, DateTimeKind.Local).AddTicks(2851), "Quis nulla magni voluptatem. Culpa quis est magnam. Voluptatibus ut dignissimos illo necessitatibus quis fugiat voluptatem. Qui exercitationem tempora temporibus iure. Consequatur error corrupti qui. Quod iste ipsam." },
                    { 522, 40, 80, 681919, new DateTime(2021, 2, 1, 22, 11, 19, 57, DateTimeKind.Local).AddTicks(4319), "Perspiciatis et qui enim consequatur et quas velit enim." },
                    { 255, 40, 18, 295910, new DateTime(2020, 8, 24, 10, 58, 48, 40, DateTimeKind.Local).AddTicks(7501), "Quia maxime reiciendis repellat fugit id est voluptas quia nostrum.\nLibero accusamus eligendi tempora ut consectetur in.\nEsse maxime sequi sit repellat.\nUnde ipsa dolorem perspiciatis cumque." },
                    { 571, 10, 41, 274574, new DateTime(2020, 9, 18, 20, 58, 40, 351, DateTimeKind.Local).AddTicks(9940), "Rerum odio neque sint ut repudiandae excepturi." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 585, 10, 24, 72593, new DateTime(2020, 10, 1, 13, 42, 39, 782, DateTimeKind.Local).AddTicks(7481), "Iure sit et dolores." },
                    { 594, 10, 115, 799716, new DateTime(2021, 6, 23, 22, 9, 40, 574, DateTimeKind.Local).AddTicks(2917), "ut" },
                    { 401, 14, 45, 250668, new DateTime(2021, 5, 11, 19, 1, 8, 379, DateTimeKind.Local).AddTicks(8104), "Repellat fugiat quam. Eum inventore dolore. Sint porro blanditiis voluptas molestias dolores quasi amet. Eos et nemo tempore dolor. Voluptas architecto est quis molestiae. Fugiat est aut deleniti sequi dolorem assumenda." },
                    { 42, 31, 40, 860136, new DateTime(2021, 6, 4, 11, 32, 6, 61, DateTimeKind.Local).AddTicks(7044), "Recusandae et maiores est iste dolores architecto nam omnis facere. Modi aut voluptatibus quas ut ad eos ea unde at. Iste non aut quasi nihil iste enim dolor autem nesciunt. Omnis quia repellendus quia quia aut dolore voluptatibus unde quidem." },
                    { 400, 14, 61, 915817, new DateTime(2020, 12, 27, 16, 11, 27, 931, DateTimeKind.Local).AddTicks(4556), "Velit quidem culpa inventore. Est veritatis deleniti qui exercitationem fugit debitis. Eum mollitia possimus corporis libero eos est vel deserunt. Atque inventore cum consectetur itaque est qui ab voluptatum. Explicabo non ut magnam dolorem animi tempore autem tenetur aliquid. Vel aut aliquid eos et et odit." },
                    { 309, 40, 59, 184997, new DateTime(2021, 3, 31, 12, 13, 37, 935, DateTimeKind.Local).AddTicks(2935), "Quod ducimus beatae molestias quod quis quis ipsum.\nEarum inventore natus deleniti." },
                    { 258, 31, 123, 899402, new DateTime(2020, 9, 13, 23, 35, 7, 143, DateTimeKind.Local).AddTicks(7177), "Quia ipsam nostrum possimus totam harum accusantium. Neque distinctio soluta unde magnam adipisci tempora minima amet. Eos qui quibusdam sed hic laboriosam delectus quia. Sapiente animi libero a." },
                    { 423, 31, 8, 295790, new DateTime(2021, 6, 18, 15, 3, 35, 189, DateTimeKind.Local).AddTicks(8185), "magnam" },
                    { 443, 31, 85, 483099, new DateTime(2021, 4, 17, 4, 32, 20, 87, DateTimeKind.Local).AddTicks(3381), "enim" },
                    { 511, 31, 76, 837871, new DateTime(2020, 11, 13, 6, 55, 1, 284, DateTimeKind.Local).AddTicks(2072), "Ut et autem voluptatibus.\nMagni ullam accusantium molestiae quaerat.\nLabore et voluptas et.\nQuis voluptatem nam sit porro.\nLaborum dolorem quo qui et numquam ratione." },
                    { 552, 31, 148, 766710, new DateTime(2020, 12, 26, 1, 8, 22, 533, DateTimeKind.Local).AddTicks(8590), "Aspernatur doloremque porro dolorum atque laboriosam pariatur aut ut.\nEt corrupti et enim quisquam labore.\nCumque enim nisi ut nisi.\nId alias tempora.\nLaboriosam consequatur harum aliquid dolor rerum temporibus." },
                    { 29, 40, 74, 287816, new DateTime(2021, 1, 26, 14, 3, 24, 761, DateTimeKind.Local).AddTicks(2199), "Consequatur voluptatum iusto optio et distinctio ducimus." },
                    { 57, 40, 45, 991390, new DateTime(2020, 11, 26, 1, 56, 58, 539, DateTimeKind.Local).AddTicks(8653), "Iure beatae laudantium ut ut tempore et inventore sit ea. Quos consequatur id quia dolor et et eius voluptatem. Dolores ipsa natus perspiciatis ut placeat. Dolores fugit totam sit quia et inventore dolorem molestiae aspernatur." },
                    { 305, 31, 105, 144770, new DateTime(2021, 2, 21, 17, 10, 16, 973, DateTimeKind.Local).AddTicks(8773), "minima" },
                    { 364, 10, 31, 147219, new DateTime(2020, 9, 5, 20, 23, 36, 16, DateTimeKind.Local).AddTicks(1183), "Qui consequatur sint omnis." },
                    { 437, 36, 127, 642943, new DateTime(2021, 3, 12, 9, 40, 39, 976, DateTimeKind.Local).AddTicks(6444), "Omnis explicabo non. Et voluptatibus laboriosam. Omnis est harum. Voluptatibus eum velit inventore possimus saepe sunt aspernatur hic." },
                    { 466, 36, 134, 609976, new DateTime(2021, 2, 5, 21, 16, 40, 162, DateTimeKind.Local).AddTicks(9528), "Ad excepturi dicta a rerum laborum a.\nQuis et officiis aut aperiam et voluptate sit reiciendis.\nHic quae sunt nam quia velit distinctio tempore in.\nVoluptate deleniti nostrum autem sed.\nEt itaque et velit omnis dicta voluptatem voluptatem iure.\nDolores deserunt suscipit ipsum consequatur pariatur voluptate tempore omnis autem." },
                    { 118, 57, 16, 351856, new DateTime(2020, 9, 4, 6, 59, 32, 473, DateTimeKind.Local).AddTicks(384), "Fuga ipsa mollitia.\nVoluptatem mollitia et aspernatur.\nAt officia possimus similique id corrupti et doloribus possimus fugiat.\nFugiat ut minus.\nNihil aut deleniti.\nOdio aspernatur enim." },
                    { 307, 57, 133, 109140, new DateTime(2020, 10, 15, 18, 58, 20, 670, DateTimeKind.Local).AddTicks(7547), "Fugit delectus quia. Aut adipisci nulla consequatur eum officia ut. Cumque veniam et. Dolor facilis aut quasi ipsa est modi et. Quo et et facere." },
                    { 313, 57, 22, 34020, new DateTime(2020, 9, 30, 6, 24, 52, 690, DateTimeKind.Local).AddTicks(3319), "Consequuntur minima ab.\nPraesentium exercitationem doloremque." },
                    { 337, 57, 92, 764706, new DateTime(2020, 10, 22, 16, 47, 6, 233, DateTimeKind.Local).AddTicks(8027), "Id pariatur et deserunt soluta omnis dolore." },
                    { 417, 57, 9, 362412, new DateTime(2021, 4, 29, 12, 38, 34, 51, DateTimeKind.Local).AddTicks(8113), "voluptates" },
                    { 453, 57, 32, 707130, new DateTime(2020, 10, 25, 20, 9, 4, 706, DateTimeKind.Local).AddTicks(8315), "A corrupti repellat animi vel. Sunt delectus rem eos nihil. Non architecto natus molestiae enim. Quis sed ut deserunt." },
                    { 531, 44, 92, 284165, new DateTime(2020, 9, 2, 19, 56, 34, 837, DateTimeKind.Local).AddTicks(4846), "Doloribus neque qui repellendus." },
                    { 504, 57, 134, 846700, new DateTime(2021, 3, 6, 11, 10, 38, 939, DateTimeKind.Local).AddTicks(3206), "Nihil exercitationem sequi ratione possimus at dolores voluptatem omnis. Iusto facilis non iste distinctio. Nam molestiae dolore quasi quaerat perferendis tempore voluptatem asperiores." },
                    { 399, 44, 45, 680704, new DateTime(2021, 2, 26, 0, 24, 33, 323, DateTimeKind.Local).AddTicks(3513), "Et nulla non omnis neque dolore." },
                    { 232, 33, 77, 839539, new DateTime(2020, 8, 23, 14, 42, 31, 623, DateTimeKind.Local).AddTicks(8852), "Eos enim aut corporis atque est exercitationem.\nVoluptatibus placeat ducimus nemo ut rerum libero.\nAnimi dolores voluptatibus nisi qui similique tempore.\nQuia natus deserunt nesciunt ex enim velit.\nConsequuntur libero dolor dolorem nemo optio itaque et enim.\nError at temporibus ut quos." },
                    { 298, 33, 134, 884814, new DateTime(2021, 1, 23, 12, 23, 7, 530, DateTimeKind.Local).AddTicks(9454), "Tempora non ab quasi." },
                    { 321, 33, 86, 789974, new DateTime(2021, 7, 26, 23, 0, 20, 560, DateTimeKind.Local).AddTicks(44), "Corporis nam ut dolores nihil reprehenderit aut alias placeat." },
                    { 323, 33, 26, 206731, new DateTime(2021, 1, 14, 22, 12, 27, 646, DateTimeKind.Local).AddTicks(4796), "Aut quas aspernatur.\nNobis suscipit expedita ut tempore corporis ullam.\nError sed sit quisquam ipsum.\nVero et est eum quasi." },
                    { 326, 33, 89, 654018, new DateTime(2021, 2, 21, 17, 41, 31, 27, DateTimeKind.Local).AddTicks(3709), "qui" },
                    { 533, 57, 25, 385996, new DateTime(2021, 1, 19, 7, 8, 53, 689, DateTimeKind.Local).AddTicks(3389), "Qui natus aliquam ut. Maxime sunt consequuntur rem facilis nam dignissimos corporis exercitationem sint. Sunt aut perferendis recusandae quia. Dolorem eos ea molestiae cumque amet vel. Ipsam aut delectus porro qui qui quos eos ratione incidunt. Est repellendus rem possimus." },
                    { 458, 36, 74, 291902, new DateTime(2021, 6, 6, 12, 47, 36, 917, DateTimeKind.Local).AddTicks(2958), "illo" },
                    { 548, 44, 37, 602082, new DateTime(2020, 9, 7, 5, 2, 56, 30, DateTimeKind.Local).AddTicks(9773), "eveniet" },
                    { 530, 32, 1, 418348, new DateTime(2021, 6, 7, 9, 53, 27, 933, DateTimeKind.Local).AddTicks(3157), "Eveniet facere saepe est veniam." },
                    { 499, 36, 8, 521216, new DateTime(2021, 6, 9, 10, 9, 44, 481, DateTimeKind.Local).AddTicks(4812), "saepe" },
                    { 179, 65, 143, 539512, new DateTime(2020, 10, 25, 0, 12, 33, 249, DateTimeKind.Local).AddTicks(3650), "Velit sit et culpa doloribus voluptates." },
                    { 220, 65, 2, 707443, new DateTime(2021, 3, 7, 16, 24, 29, 861, DateTimeKind.Local).AddTicks(8382), "nihil" },
                    { 152, 14, 93, 536829, new DateTime(2021, 1, 26, 22, 37, 36, 488, DateTimeKind.Local).AddTicks(5358), "Incidunt soluta aliquid ut doloremque consequatur." },
                    { 534, 20, 29, 297145, new DateTime(2021, 7, 6, 23, 35, 24, 263, DateTimeKind.Local).AddTicks(3063), "Sint itaque quo accusamus minus reprehenderit error sapiente ipsa.\nIpsam omnis sit et deleniti qui similique aspernatur voluptas impedit.\nRepellendus quibusdam quidem quod aliquid aut quo ut dolorem accusantium.\nMagni atque sunt.\nAut vero dicta." },
                    { 293, 65, 150, 1055, new DateTime(2020, 11, 27, 13, 50, 12, 75, DateTimeKind.Local).AddTicks(3807), "aspernatur" },
                    { 544, 32, 141, 581438, new DateTime(2021, 5, 9, 4, 0, 48, 921, DateTimeKind.Local).AddTicks(2078), "Enim optio maxime aperiam. Ducimus vitae et sit id vel dolor esse ut sunt. Nesciunt officia et rerum rerum voluptate ullam. Rem vitae eum qui ducimus nemo voluptatem voluptas voluptate. Et fuga et eveniet est corporis fugiat voluptas. Temporibus ut temporibus et velit velit delectus." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 317, 65, 62, 761992, new DateTime(2021, 1, 5, 12, 28, 6, 81, DateTimeKind.Local).AddTicks(4744), "Sed voluptatem sunt reiciendis consequatur autem esse quis fuga.\nPerspiciatis error repellendus quo adipisci.\nMollitia voluptate sed iure.\nEum neque est tempore et est et minus.\nEt nemo sapiente qui perferendis." },
                    { 527, 65, 100, 288118, new DateTime(2021, 6, 8, 9, 2, 26, 93, DateTimeKind.Local).AddTicks(4219), "Ut iste dolore vel.\nIpsum repellendus neque aut qui at vitae voluptatibus.\nAlias et quibusdam.\nDeleniti neque consequatur est." },
                    { 19, 14, 82, 560882, new DateTime(2021, 7, 27, 15, 15, 4, 70, DateTimeKind.Local).AddTicks(3885), "Repellat exercitationem harum.\nEt sed consectetur animi necessitatibus dolorum.\nSit eveniet voluptatem eum.\nIpsa quo inventore.\nSed tenetur et debitis consequatur." },
                    { 581, 44, 76, 491685, new DateTime(2021, 3, 11, 0, 46, 32, 123, DateTimeKind.Local).AddTicks(5005), "et" },
                    { 260, 32, 68, 790945, new DateTime(2020, 8, 30, 6, 39, 37, 964, DateTimeKind.Local).AddTicks(3735), "Illo sapiente deleniti qui sed commodi." },
                    { 264, 32, 28, 280084, new DateTime(2021, 6, 1, 10, 34, 8, 308, DateTimeKind.Local).AddTicks(8737), "Iure quisquam qui est soluta doloribus sit voluptas qui. Architecto nemo eaque eaque veniam. Et odit perspiciatis consequatur natus accusantium eum consequatur quidem. Porro et ullam dolorem sed non nobis illo autem. Dolore porro veniam et odit. Cum non quae repudiandae dolore qui enim qui." },
                    { 394, 32, 60, 573727, new DateTime(2020, 12, 8, 11, 27, 27, 788, DateTimeKind.Local).AddTicks(697), "Cum voluptas est sed dolorum quidem exercitationem dolores rerum. Dolorem ut eligendi magni non qui natus facere sit. Illo ad voluptatem quo sunt. Qui esse omnis sed quia itaque. Quo facilis quasi perspiciatis voluptas error velit at optio." },
                    { 372, 65, 132, 858796, new DateTime(2021, 5, 23, 6, 53, 55, 525, DateTimeKind.Local).AddTicks(9904), "Similique eum qui laboriosam veritatis quidem.\nItaque libero aspernatur a sit aperiam harum aliquid fuga officiis.\nModi aut quo aut voluptas." },
                    { 284, 10, 110, 411093, new DateTime(2021, 3, 16, 19, 3, 14, 653, DateTimeKind.Local).AddTicks(2349), "Harum sed expedita sit nemo libero non cumque.\nNon tenetur harum deserunt qui.\nEaque nihil praesentium architecto." },
                    { 229, 10, 44, 14329, new DateTime(2020, 9, 2, 11, 32, 50, 772, DateTimeKind.Local).AddTicks(3994), "Aut magnam maiores totam libero. Voluptates quisquam ducimus fugit quibusdam commodi et. Velit voluptas accusamus. Dignissimos cupiditate ipsum doloremque nihil aperiam adipisci repellendus voluptate." },
                    { 217, 10, 103, 776856, new DateTime(2020, 8, 13, 13, 52, 59, 777, DateTimeKind.Local).AddTicks(5951), "atque" },
                    { 514, 77, 116, 599881, new DateTime(2020, 11, 15, 16, 25, 25, 547, DateTimeKind.Local).AddTicks(4644), "Qui et voluptatum vitae debitis dolor quam necessitatibus." },
                    { 519, 24, 2, 17541, new DateTime(2020, 10, 3, 14, 1, 46, 456, DateTimeKind.Local).AddTicks(9204), "fugiat" },
                    { 133, 51, 128, 191475, new DateTime(2021, 4, 14, 10, 2, 43, 22, DateTimeKind.Local).AddTicks(4039), "Velit non ullam facilis officia quia fugit sed ullam architecto.\nVoluptas deleniti aut placeat iste optio iste.\nNulla veniam minus laudantium.\nCulpa fuga provident deleniti aut voluptatem.\nVeniam deleniti doloremque.\nBeatae est exercitationem natus et quo qui perferendis ut laboriosam." },
                    { 269, 51, 96, 314962, new DateTime(2021, 3, 9, 7, 14, 34, 709, DateTimeKind.Local).AddTicks(3758), "In suscipit sed maxime ut dolorem quam." },
                    { 310, 51, 1, 57786, new DateTime(2021, 7, 16, 10, 10, 12, 535, DateTimeKind.Local).AddTicks(9603), "Qui maxime porro quo consequatur a rerum atque aut." },
                    { 480, 51, 38, 126516, new DateTime(2021, 5, 19, 5, 6, 30, 378, DateTimeKind.Local).AddTicks(3955), "Ullam quis officiis voluptas.\nRepellat sit natus voluptates rem omnis et aspernatur praesentium ducimus.\nRerum et harum nemo.\nAb voluptas delectus natus odio exercitationem.\nSunt numquam qui et sunt omnis doloribus." },
                    { 175, 77, 88, 60003, new DateTime(2020, 9, 10, 17, 8, 44, 422, DateTimeKind.Local).AddTicks(5448), "Quaerat consequatur fuga minus sint nulla sed dolores. Consequatur optio sunt ut voluptatem dicta reiciendis. Sint id iure accusantium ipsam. Nostrum facilis nulla soluta ducimus minima. Amet quasi ut quo. Omnis totam itaque et non." },
                    { 461, 24, 30, 943738, new DateTime(2020, 11, 7, 5, 51, 55, 789, DateTimeKind.Local).AddTicks(3757), "exercitationem" },
                    { 429, 24, 13, 412436, new DateTime(2020, 10, 11, 17, 58, 56, 829, DateTimeKind.Local).AddTicks(1141), "Et libero est ut eos veniam. Voluptatem error vero et. Neque nostrum totam est temporibus nulla repudiandae minima cupiditate." },
                    { 101, 84, 21, 121675, new DateTime(2021, 3, 21, 22, 56, 31, 183, DateTimeKind.Local).AddTicks(2538), "Consequatur soluta suscipit est." },
                    { 122, 84, 23, 741339, new DateTime(2021, 4, 12, 6, 48, 56, 930, DateTimeKind.Local).AddTicks(9824), "occaecati" },
                    { 276, 84, 128, 739660, new DateTime(2021, 3, 8, 11, 32, 53, 399, DateTimeKind.Local).AddTicks(9150), "Molestias quia illum sed non veritatis et.\nDeleniti iste pariatur quisquam aut eum numquam.\nAliquid in quam voluptatem omnis numquam enim.\nAspernatur autem officiis exercitationem necessitatibus.\nQui distinctio alias.\nRerum porro itaque et perferendis." },
                    { 378, 24, 102, 437025, new DateTime(2020, 8, 14, 18, 6, 13, 30, DateTimeKind.Local).AddTicks(7397), "Debitis ut voluptas iste aut blanditiis quia qui qui voluptatem. Porro sint modi aliquam quia sit voluptatem aut ea. Velit incidunt est ut laborum doloremque qui cum. Labore delectus sunt rerum consequatur modi et dolor sint molestias. Est qui et. Alias non voluptates est accusamus sapiente debitis." },
                    { 259, 24, 114, 801237, new DateTime(2021, 1, 4, 16, 22, 15, 276, DateTimeKind.Local).AddTicks(1160), "Est recusandae suscipit optio quae est nobis aliquid." },
                    { 515, 51, 121, 680389, new DateTime(2020, 10, 31, 18, 28, 37, 460, DateTimeKind.Local).AddTicks(3287), "Rerum odio dolore. Excepturi et iste aperiam. Vitae et fugiat occaecati enim aut." },
                    { 63, 9, 46, 895125, new DateTime(2020, 12, 29, 22, 43, 55, 707, DateTimeKind.Local).AddTicks(739), "Nesciunt eveniet eum dicta.\nMolestias minus debitis incidunt eos dolores nesciunt voluptatem blanditiis porro.\nVitae delectus odio aut qui.\nQui facere ipsum.\nNumquam aperiam quo." },
                    { 48, 77, 5, 870575, new DateTime(2020, 9, 5, 10, 51, 49, 861, DateTimeKind.Local).AddTicks(2382), "Animi non in beatae ullam rerum necessitatibus nulla aspernatur repellat." },
                    { 528, 101, 48, 793459, new DateTime(2020, 10, 4, 8, 4, 50, 598, DateTimeKind.Local).AddTicks(9535), "placeat" },
                    { 254, 11, 38, 692388, new DateTime(2021, 6, 4, 10, 0, 19, 538, DateTimeKind.Local).AddTicks(6098), "explicabo" },
                    { 473, 11, 40, 632743, new DateTime(2021, 6, 30, 2, 1, 18, 44, DateTimeKind.Local).AddTicks(9995), "Mollitia et aut vel illo ea.\nSimilique illo in et.\nPariatur quaerat asperiores labore ad.\nOdit officia nulla mollitia.\nDignissimos quis modi.\nEnim voluptatem quo quia laudantium a aliquid qui odit." },
                    { 512, 11, 43, 99092, new DateTime(2021, 3, 30, 22, 24, 18, 983, DateTimeKind.Local).AddTicks(4617), "Minus molestiae sed sed dolor quod rem." },
                    { 578, 11, 136, 175291, new DateTime(2021, 5, 25, 23, 4, 10, 509, DateTimeKind.Local).AddTicks(7200), "Eum tenetur sapiente amet soluta." },
                    { 104, 41, 124, 175957, new DateTime(2021, 5, 5, 15, 48, 34, 430, DateTimeKind.Local).AddTicks(1615), "et" },
                    { 139, 41, 124, 553621, new DateTime(2021, 6, 21, 14, 28, 38, 345, DateTimeKind.Local).AddTicks(3683), "Doloremque iste animi similique velit sint suscipit ut quis. Voluptatem facere sit nostrum aut quasi est velit voluptatem sit. Error voluptatem et. At eum expedita illum incidunt rerum sunt consequatur ut porro. Pariatur deserunt quod dolorem at vel est." },
                    { 560, 101, 128, 131904, new DateTime(2020, 10, 28, 22, 52, 49, 822, DateTimeKind.Local).AddTicks(8371), "Voluptatem beatae blanditiis enim iure illo labore facere enim." },
                    { 155, 41, 97, 197954, new DateTime(2020, 8, 14, 14, 24, 3, 8, DateTimeKind.Local).AddTicks(7165), "Eos eius culpa nihil unde nam ex animi. Consequuntur et est ipsam consectetur. Sequi nam praesentium laudantium ut provident. Placeat facere accusamus qui voluptate quo. Qui reprehenderit cumque est quo voluptatem quia exercitationem ad. Voluptate et corrupti quos aut sed inventore." },
                    { 465, 41, 74, 868133, new DateTime(2021, 3, 14, 14, 43, 49, 747, DateTimeKind.Local).AddTicks(6279), "Id consequatur beatae." },
                    { 529, 41, 75, 537788, new DateTime(2021, 2, 10, 15, 39, 52, 751, DateTimeKind.Local).AddTicks(9381), "Facilis qui quae voluptatem officiis debitis amet corporis aut.\nNon provident magnam qui quo.\nAut doloremque exercitationem.\nDolore vel a voluptas quasi molestiae eaque corporis sit." },
                    { 159, 101, 41, 686969, new DateTime(2020, 11, 9, 23, 2, 36, 888, DateTimeKind.Local).AddTicks(4025), "Reiciendis sed aut modi sapiente suscipit sunt laudantium reiciendis.\nModi officia vel dolorem dicta quis." },
                    { 215, 101, 119, 796426, new DateTime(2021, 4, 30, 17, 50, 34, 206, DateTimeKind.Local).AddTicks(7828), "Consequatur hic eius non praesentium sequi.\nDebitis velit tempore cumque quos voluptates velit vel est quibusdam." },
                    { 349, 101, 8, 234998, new DateTime(2021, 2, 15, 12, 38, 12, 645, DateTimeKind.Local).AddTicks(1323), "Distinctio eos et laboriosam similique aut. Quidem dolorem explicabo tenetur iste nihil sed aliquid. Nihil excepturi eaque." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 72, 11, 137, 984671, new DateTime(2020, 10, 6, 8, 46, 31, 356, DateTimeKind.Local).AddTicks(7574), "aut" },
                    { 253, 41, 100, 428670, new DateTime(2021, 5, 22, 20, 37, 19, 478, DateTimeKind.Local).AddTicks(2049), "Alias commodi magnam nobis officia molestias ex. Eveniet officiis nam beatae quia molestias error et aut consequuntur. Necessitatibus occaecati facere nihil et temporibus vel. Vel recusandae dolor dolores sit ut quibusdam eius tenetur. Aut et nisi sint sit aliquid reprehenderit eum ipsa." },
                    { 200, 9, 26, 213366, new DateTime(2021, 2, 11, 3, 16, 0, 452, DateTimeKind.Local).AddTicks(3038), "Inventore id expedita saepe sit qui sit.\nNisi recusandae nihil vel et.\nAnimi error sint rerum quia est hic.\nTempora perspiciatis aut consequuntur perspiciatis tempora et." },
                    { 218, 9, 140, 212954, new DateTime(2021, 2, 3, 7, 30, 6, 102, DateTimeKind.Local).AddTicks(4624), "Et distinctio ut quia et sunt excepturi aspernatur eius.\nCupiditate quis fuga voluptatum optio cupiditate ex sapiente.\nEt ea reprehenderit et molestiae soluta ratione ex.\nDolorem dolor quas amet." },
                    { 240, 9, 141, 247698, new DateTime(2021, 1, 29, 0, 30, 50, 142, DateTimeKind.Local).AddTicks(8668), "rerum" },
                    { 266, 75, 139, 300897, new DateTime(2020, 10, 15, 17, 20, 2, 107, DateTimeKind.Local).AddTicks(7278), "Laudantium error quia qui fuga voluptatibus distinctio itaque ut ratione." },
                    { 358, 75, 118, 549164, new DateTime(2020, 8, 30, 5, 58, 37, 307, DateTimeKind.Local).AddTicks(2017), "vitae" },
                    { 449, 75, 32, 175867, new DateTime(2020, 11, 18, 4, 15, 51, 430, DateTimeKind.Local).AddTicks(6106), "Tempora vel quasi aliquam consequatur qui aut voluptas fugit. Fuga accusantium unde eligendi modi eos. Optio maiores consequatur sed aut. Aspernatur dicta sed." },
                    { 538, 75, 137, 81747, new DateTime(2021, 5, 31, 16, 18, 44, 341, DateTimeKind.Local).AddTicks(36), "quis" },
                    { 434, 14, 2, 179384, new DateTime(2020, 11, 14, 14, 26, 24, 695, DateTimeKind.Local).AddTicks(7167), "Facere enim harum veniam at qui illo." },
                    { 558, 75, 25, 444070, new DateTime(2020, 8, 25, 9, 2, 43, 912, DateTimeKind.Local).AddTicks(9880), "Voluptas consequatur sed aut optio. Pariatur labore et. Sint fuga consequatur velit et quod provident possimus rem dignissimos." },
                    { 209, 75, 107, 463807, new DateTime(2020, 9, 13, 2, 25, 46, 175, DateTimeKind.Local).AddTicks(4108), "nemo" },
                    { 409, 14, 15, 775516, new DateTime(2021, 6, 17, 13, 20, 17, 901, DateTimeKind.Local).AddTicks(1689), "Enim non consequatur delectus quo minima voluptate eaque rerum." },
                    { 338, 103, 133, 816890, new DateTime(2021, 2, 15, 4, 9, 25, 123, DateTimeKind.Local).AddTicks(6521), "Ex odit quae sint.\nPorro sint nobis dolorum rerum maxime ab id ut.\nQuam dignissimos ut harum accusamus sequi.\nEst mollitia eius aut iusto." },
                    { 369, 103, 125, 998810, new DateTime(2021, 1, 13, 20, 7, 38, 616, DateTimeKind.Local).AddTicks(4248), "consequuntur" },
                    { 376, 103, 23, 923785, new DateTime(2020, 11, 18, 1, 44, 20, 77, DateTimeKind.Local).AddTicks(7036), "eum" },
                    { 464, 103, 102, 979855, new DateTime(2020, 11, 30, 18, 58, 58, 40, DateTimeKind.Local).AddTicks(2806), "Commodi et distinctio et nesciunt exercitationem modi soluta. Est dicta sequi veniam vel. Qui voluptatibus at voluptates aliquid ut est accusantium illo laboriosam. Quia voluptatem ipsa expedita qui ad et repellendus. A ea architecto ducimus necessitatibus quis esse." },
                    { 12, 10, 121, 679340, new DateTime(2021, 4, 22, 4, 12, 28, 755, DateTimeKind.Local).AddTicks(2497), "Labore et et aut accusamus sint blanditiis earum eos." },
                    { 143, 10, 44, 294415, new DateTime(2021, 2, 16, 16, 20, 47, 395, DateTimeKind.Local).AddTicks(5085), "Vitae quo ut laborum magnam magnam cumque et. Eius non animi omnis modi est. Esse possimus qui nemo non quia et. Voluptate consequatur dolorum omnis id vel maiores ad dolorem totam. Aut veritatis perspiciatis labore. Quos consequatur non." },
                    { 267, 103, 126, 573650, new DateTime(2020, 8, 22, 23, 37, 47, 279, DateTimeKind.Local).AddTicks(4518), "Quia quisquam in ut." },
                    { 177, 75, 143, 414028, new DateTime(2021, 6, 25, 11, 32, 56, 983, DateTimeKind.Local).AddTicks(6086), "molestiae" },
                    { 567, 14, 109, 52041, new DateTime(2020, 10, 31, 9, 24, 13, 97, DateTimeKind.Local).AddTicks(6717), "assumenda" },
                    { 148, 75, 22, 433381, new DateTime(2020, 8, 21, 6, 28, 29, 945, DateTimeKind.Local).AddTicks(3001), "Maxime laboriosam doloribus quos error tempore sint magnam rerum voluptatem." },
                    { 389, 9, 92, 878565, new DateTime(2020, 10, 28, 5, 5, 56, 713, DateTimeKind.Local).AddTicks(9932), "Quis aut illo aspernatur excepturi qui maxime aut et." },
                    { 149, 24, 55, 869644, new DateTime(2021, 4, 12, 12, 45, 51, 867, DateTimeKind.Local).AddTicks(441), "et" },
                    { 27, 30, 54, 363357, new DateTime(2021, 7, 15, 8, 35, 50, 730, DateTimeKind.Local).AddTicks(3197), "Quos tenetur fuga tenetur dolorem libero fuga quia hic. Deserunt cupiditate voluptatum voluptatum inventore quibusdam laborum quia tempore possimus. Consequuntur cum enim nobis consequuntur quia earum praesentium. Vero ut tenetur maiores voluptatum. Deleniti culpa voluptas odit iure dolore eligendi. Et accusantium cum culpa et dicta voluptas error magni consequuntur." },
                    { 49, 30, 22, 407656, new DateTime(2021, 7, 13, 19, 13, 58, 365, DateTimeKind.Local).AddTicks(586), "Quaerat repellat doloremque dicta. Voluptate a ut error et qui expedita dolore. Excepturi et quis corporis." },
                    { 99, 30, 21, 417838, new DateTime(2021, 1, 24, 16, 11, 26, 2, DateTimeKind.Local).AddTicks(4975), "Nisi eligendi numquam dolor nesciunt." },
                    { 158, 30, 78, 91544, new DateTime(2021, 1, 9, 1, 11, 56, 529, DateTimeKind.Local).AddTicks(4466), "Praesentium ut facere velit dolor nisi aliquid possimus." },
                    { 214, 30, 43, 842601, new DateTime(2021, 2, 25, 7, 49, 14, 116, DateTimeKind.Local).AddTicks(9120), "Eius quia dignissimos quia. Nam aliquam a sed magnam. Nihil non nihil. Non temporibus repellendus inventore consequatur." },
                    { 483, 30, 146, 590279, new DateTime(2020, 9, 28, 19, 11, 5, 863, DateTimeKind.Local).AddTicks(2962), "Quia itaque ullam ipsa dolores non quia quasi facilis.\nRecusandae non qui et temporibus adipisci accusantium perferendis sunt.\nEa aut quo laboriosam qui.\nArchitecto laborum dolores minima eaque ducimus fuga." },
                    { 126, 24, 88, 738625, new DateTime(2021, 5, 20, 10, 44, 3, 727, DateTimeKind.Local).AddTicks(324), "Similique est accusamus excepturi ratione dicta nihil." },
                    { 596, 14, 38, 8664, new DateTime(2021, 4, 9, 7, 58, 9, 61, DateTimeKind.Local).AddTicks(6621), "Quis a est. Facere sed nemo veniam fuga porro laborum quia. Natus quisquam explicabo itaque ex expedita. At repellat facere et et qui dolores est. Optio sunt quisquam eaque. Eos sit doloremque." },
                    { 32, 6, 86, 691735, new DateTime(2021, 1, 3, 19, 29, 3, 313, DateTimeKind.Local).AddTicks(7838), "Id magnam alias qui autem dolores quo dolor. Culpa necessitatibus eos adipisci porro qui consequatur nam. Commodi nulla expedita sed voluptatem sapiente explicabo id cum perferendis. Quasi nemo sit id quam. Saepe natus nemo consequuntur itaque perferendis numquam porro." },
                    { 140, 6, 74, 588563, new DateTime(2020, 9, 7, 10, 4, 50, 683, DateTimeKind.Local).AddTicks(811), "Esse maiores cupiditate officia temporibus laudantium ut minus sunt natus.\nSoluta qui inventore explicabo veritatis rerum explicabo sunt.\nModi explicabo praesentium sequi dolorem nam.\nDolor enim et doloremque aspernatur voluptas debitis vel ut error.\nDucimus magnam veniam sed.\nSit atque ipsum." },
                    { 180, 6, 85, 645875, new DateTime(2020, 10, 8, 13, 13, 25, 738, DateTimeKind.Local).AddTicks(9641), "Architecto aut voluptatem accusantium.\nRepellat esse nihil nobis sint non perspiciatis ut autem dolores.\nAtque harum omnis ut velit." },
                    { 52, 75, 109, 724901, new DateTime(2021, 3, 8, 17, 53, 33, 251, DateTimeKind.Local).AddTicks(6065), "Pariatur molestiae quia odio.\nId qui quasi.\nAt omnis nihil rerum." },
                    { 137, 75, 21, 125645, new DateTime(2020, 9, 5, 6, 17, 6, 65, DateTimeKind.Local).AddTicks(8366), "est" },
                    { 86, 11, 141, 525994, new DateTime(2021, 1, 4, 11, 34, 25, 453, DateTimeKind.Local).AddTicks(8140), "Iusto sed similique.\nEa nostrum blanditiis culpa culpa ut voluptatem amet vero quia.\nQui voluptatem vel voluptatum alias et.\nEst impedit quae qui et aliquam beatae et aliquid qui." },
                    { 521, 33, 132, 710173, new DateTime(2020, 8, 29, 19, 35, 48, 680, DateTimeKind.Local).AddTicks(2049), "Ipsam ipsa omnis illum.\nOdio minima quia voluptatem quia illo tempora.\nEius deserunt quidem ut velit." },
                    { 329, 33, 14, 118357, new DateTime(2020, 12, 2, 9, 33, 16, 806, DateTimeKind.Local).AddTicks(5645), "eum" },
                    { 396, 50, 122, 856642, new DateTime(2020, 9, 10, 1, 9, 12, 738, DateTimeKind.Local).AddTicks(3794), "Reiciendis a ut earum quasi." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 436, 78, 13, 18512, new DateTime(2021, 3, 21, 15, 28, 52, 995, DateTimeKind.Local).AddTicks(3428), "Est eum impedit sint molestiae incidunt unde.\nEligendi laboriosam omnis deserunt eum ad amet facere dolor iusto.\nAtque quas omnis debitis quis ad mollitia reprehenderit omnis odit." },
                    { 379, 78, 104, 133925, new DateTime(2020, 8, 23, 22, 7, 41, 321, DateTimeKind.Local).AddTicks(8284), "Qui molestiae ullam illo optio.\nVel ratione ut.\nDoloremque nihil voluptas ea ullam autem aut totam et.\nUt soluta quia.\nConsequatur non ea." },
                    { 129, 78, 26, 891215, new DateTime(2021, 6, 25, 23, 48, 51, 595, DateTimeKind.Local).AddTicks(5479), "omnis" },
                    { 18, 78, 142, 306492, new DateTime(2021, 4, 9, 5, 17, 25, 840, DateTimeKind.Local).AddTicks(6919), "Veniam voluptas iusto sed non eum occaecati.\nEt autem perspiciatis.\nQuas voluptatum pariatur et nihil.\nSoluta consequatur blanditiis qui quo reprehenderit consequatur sequi.\nIpsam et accusantium repudiandae quia modi rerum." },
                    { 392, 35, 60, 584384, new DateTime(2021, 2, 2, 22, 12, 20, 484, DateTimeKind.Local).AddTicks(3298), "Et repudiandae temporibus minima qui non quae occaecati earum.\nQuam magnam eveniet cumque.\nLabore tenetur consequatur non.\nAut asperiores maxime." },
                    { 157, 96, 133, 350832, new DateTime(2020, 12, 10, 12, 12, 52, 264, DateTimeKind.Local).AddTicks(4688), "Sunt voluptatem veniam expedita quis ad ipsam inventore.\nAccusantium fugit omnis et odio ad.\nArchitecto expedita minus laborum quod quis ab veritatis.\nHic nihil at beatae aut et non in." },
                    { 238, 35, 58, 8076, new DateTime(2020, 12, 4, 3, 24, 26, 942, DateTimeKind.Local).AddTicks(5789), "cumque" },
                    { 73, 35, 104, 902433, new DateTime(2021, 5, 17, 12, 11, 43, 889, DateTimeKind.Local).AddTicks(6264), "Veniam ut odio optio." },
                    { 589, 89, 3, 358584, new DateTime(2020, 10, 28, 22, 51, 39, 70, DateTimeKind.Local).AddTicks(5359), "provident" },
                    { 488, 89, 11, 663070, new DateTime(2021, 7, 29, 0, 8, 10, 897, DateTimeKind.Local).AddTicks(4918), "In ea aspernatur quas asperiores vel libero itaque vel.\nQui impedit nihil cupiditate voluptatem.\nDolorem et asperiores suscipit aut sit nemo.\nPraesentium deleniti facilis minus neque voluptas consequuntur molestiae.\nPerspiciatis aspernatur quis dolores nisi enim aliquid.\nDolores dolorum libero magnam." },
                    { 410, 89, 107, 745917, new DateTime(2021, 6, 4, 15, 42, 35, 373, DateTimeKind.Local).AddTicks(5333), "Autem molestiae amet doloribus reiciendis eius quos dolorem perspiciatis.\nMagni dignissimos molestias facilis ex eos sequi facilis deserunt." },
                    { 368, 89, 84, 394563, new DateTime(2020, 12, 10, 4, 3, 48, 870, DateTimeKind.Local).AddTicks(4380), "aut" },
                    { 225, 89, 56, 142349, new DateTime(2021, 5, 5, 22, 18, 57, 981, DateTimeKind.Local).AddTicks(2722), "Dignissimos eligendi accusamus autem quam iusto blanditiis. Aliquam facere ducimus voluptate rem dolores. At sapiente placeat iste. At atque optio quae id excepturi et. Harum vero quaerat. Voluptatem voluptas quis et reiciendis pariatur." },
                    { 178, 89, 31, 43220, new DateTime(2021, 1, 21, 8, 39, 3, 126, DateTimeKind.Local).AddTicks(7367), "Quasi dolorem dicta. In sit fuga suscipit veritatis a voluptas excepturi nisi. Non totam delectus officia vel aliquam reiciendis sint qui magni. Maiores possimus itaque qui dolores velit repellendus dolores pariatur." },
                    { 51, 89, 97, 318511, new DateTime(2020, 10, 7, 18, 41, 37, 739, DateTimeKind.Local).AddTicks(6277), "recusandae" },
                    { 194, 96, 5, 250426, new DateTime(2021, 7, 22, 2, 24, 55, 94, DateTimeKind.Local).AddTicks(1561), "Et ea eos adipisci ut labore rerum aut.\nItaque numquam porro sed ullam voluptatibus odio dicta omnis non.\nConsequatur quam cupiditate qui qui rerum id ut ipsam mollitia.\nItaque officia illum debitis deleniti tempora molestiae quia adipisci eligendi." },
                    { 201, 96, 9, 400883, new DateTime(2020, 10, 16, 0, 59, 1, 194, DateTimeKind.Local).AddTicks(76), "Nam praesentium temporibus iste.\nQuidem iste sunt eos explicabo.\nUllam earum est labore explicabo quia qui est.\nAutem aut aut necessitatibus ipsa odit.\nNulla quisquam dolorum facilis consequuntur." },
                    { 74, 50, 36, 755349, new DateTime(2021, 8, 12, 11, 16, 53, 265, DateTimeKind.Local).AddTicks(8341), "Temporibus et enim voluptate similique voluptatibus.\nOdio dicta nisi qui quos.\nCulpa autem ut ut.\nConsequatur molestias cumque suscipit quaerat aliquid et magnam maiores omnis.\nTempora nobis ut.\nNon numquam dolorem et rem veniam." },
                    { 206, 3, 13, 588742, new DateTime(2020, 9, 21, 9, 31, 41, 121, DateTimeKind.Local).AddTicks(8146), "Porro ex aut consequuntur voluptas est. Suscipit repudiandae delectus atque. Tempore amet sed magnam aut totam illum." },
                    { 314, 3, 75, 917846, new DateTime(2020, 12, 26, 1, 27, 20, 238, DateTimeKind.Local).AddTicks(8538), "Doloremque laboriosam ex est cumque dolor quo. Laborum velit et sit hic sint magnam. Autem quia eos id aut eligendi voluptas voluptatibus. Odio ipsa soluta qui aliquid quia veniam." },
                    { 550, 3, 128, 817916, new DateTime(2020, 11, 20, 12, 43, 34, 520, DateTimeKind.Local).AddTicks(5103), "Atque repellat occaecati dolore ut omnis impedit et occaecati.\nDebitis et pariatur.\nId repudiandae laudantium deserunt adipisci.\nEnim natus qui quibusdam consequatur id veritatis in ad magnam." },
                    { 355, 96, 119, 929735, new DateTime(2021, 4, 27, 3, 13, 22, 594, DateTimeKind.Local).AddTicks(2786), "Nisi et amet eius fugit culpa ea." },
                    { 138, 12, 28, 10397, new DateTime(2020, 10, 1, 17, 48, 1, 927, DateTimeKind.Local).AddTicks(6251), "voluptatem" },
                    { 38, 87, 134, 268855, new DateTime(2020, 12, 28, 15, 20, 36, 930, DateTimeKind.Local).AddTicks(5558), "Est et ipsam facilis nemo est. Animi accusamus sit qui. Beatae officia iure ratione pariatur aspernatur iusto voluptate pariatur." },
                    { 231, 12, 100, 849046, new DateTime(2021, 2, 8, 5, 55, 23, 908, DateTimeKind.Local).AddTicks(1053), "Est et unde id ut nulla voluptas repudiandae." },
                    { 247, 12, 140, 733913, new DateTime(2020, 12, 16, 21, 4, 6, 336, DateTimeKind.Local).AddTicks(4947), "Accusamus tempora laboriosam qui ex incidunt tenetur qui ratione.\nOptio accusantium consectetur dolor quia.\nTenetur accusamus aliquid aut vero nisi saepe sed in possimus.\nLibero ut cumque expedita ut assumenda natus quis amet.\nExcepturi doloribus aut rerum ut reiciendis iure." },
                    { 344, 12, 62, 387293, new DateTime(2021, 4, 7, 22, 59, 24, 634, DateTimeKind.Local).AddTicks(8417), "nemo" },
                    { 381, 12, 32, 61574, new DateTime(2020, 12, 1, 22, 57, 47, 388, DateTimeKind.Local).AddTicks(4251), "voluptatum" },
                    { 398, 12, 43, 225949, new DateTime(2020, 10, 14, 15, 43, 38, 812, DateTimeKind.Local).AddTicks(4253), "Dolore qui optio. Qui voluptas odio in voluptas consequatur. Magnam minus ipsam nisi et." },
                    { 535, 12, 13, 143919, new DateTime(2021, 5, 20, 7, 27, 47, 881, DateTimeKind.Local).AddTicks(3054), "autem" },
                    { 576, 12, 33, 353164, new DateTime(2021, 7, 30, 23, 58, 53, 678, DateTimeKind.Local).AddTicks(627), "Neque ut consequuntur et nostrum voluptatibus dolor. Omnis ab ut nisi eligendi. Laborum vero distinctio doloremque accusantium veniam error. Minus quaerat aliquam aliquid cum tempora saepe labore qui." },
                    { 241, 12, 22, 2507, new DateTime(2020, 10, 3, 3, 5, 24, 194, DateTimeKind.Local).AddTicks(8132), "Iure blanditiis numquam ipsum praesentium ut et unde sunt tempore." },
                    { 188, 87, 23, 40818, new DateTime(2021, 5, 9, 1, 14, 49, 771, DateTimeKind.Local).AddTicks(1585), "Necessitatibus quis vitae sint omnis esse a expedita blanditiis." },
                    { 62, 96, 78, 292093, new DateTime(2020, 11, 2, 19, 12, 34, 716, DateTimeKind.Local).AddTicks(276), "Quod possimus voluptate repudiandae quia molestiae ab reprehenderit.\nIste facere reprehenderit qui tempora." },
                    { 207, 87, 105, 462902, new DateTime(2021, 4, 6, 15, 7, 29, 575, DateTimeKind.Local).AddTicks(779), "Enim suscipit quidem id doloribus quos. Qui sed voluptates earum velit consequatur. Sit provident eos. Rerum molestias sint dolore nulla nisi quo sed aperiam. Pariatur eligendi ad ullam dolorum." },
                    { 234, 62, 65, 775364, new DateTime(2021, 4, 12, 17, 53, 27, 845, DateTimeKind.Local).AddTicks(8944), "Quia numquam at.\nIpsum ex vel quia repellat veritatis est." },
                    { 342, 62, 6, 46769, new DateTime(2021, 7, 24, 12, 54, 19, 999, DateTimeKind.Local).AddTicks(8596), "Illum placeat officia. Quam aspernatur rem aut et praesentium non nihil. Ut doloribus provident perferendis consequatur." },
                    { 212, 69, 87, 635302, new DateTime(2020, 10, 8, 22, 14, 34, 688, DateTimeKind.Local).AddTicks(7919), "ut" },
                    { 391, 62, 67, 357232, new DateTime(2020, 8, 30, 12, 48, 35, 310, DateTimeKind.Local).AddTicks(9596), "Omnis quisquam tempore nihil eveniet molestiae enim. Voluptas ad expedita cumque autem. Vel blanditiis consequatur non. Exercitationem autem voluptas aut voluptatem sed in doloremque." },
                    { 190, 69, 72, 216996, new DateTime(2021, 5, 28, 23, 42, 58, 575, DateTimeKind.Local).AddTicks(3879), "Ullam odit est.\nQuia quod aut.\nModi voluptate blanditiis beatae fugit nam sunt nulla et nulla.\nQuia voluptatibus omnis et voluptas non dicta beatae in in.\nAdipisci et fugiat consequatur.\nAut accusamus provident." },
                    { 116, 38, 20, 935080, new DateTime(2021, 4, 18, 20, 13, 34, 809, DateTimeKind.Local).AddTicks(3640), "Dolores laudantium fuga molestias enim eligendi consectetur dolorem aliquam qui. Necessitatibus possimus accusamus dignissimos quas cupiditate molestiae earum omnis. Similique est dolores voluptatem." },
                    { 228, 62, 12, 140522, new DateTime(2020, 12, 4, 20, 28, 43, 900, DateTimeKind.Local).AddTicks(6944), "repudiandae" }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 142, 38, 52, 256347, new DateTime(2020, 9, 20, 1, 46, 17, 381, DateTimeKind.Local).AddTicks(8394), "Sunt dolore adipisci et est est quia ipsum aut quasi.\nTempore asperiores minus voluptas magni.\nDolor corporis itaque voluptas nesciunt corrupti autem consectetur quibusdam.\nNihil modi optio et expedita." },
                    { 384, 38, 98, 248213, new DateTime(2021, 6, 5, 9, 10, 55, 567, DateTimeKind.Local).AddTicks(5736), "Dignissimos quia et.\nImpedit esse sunt repellat." },
                    { 88, 69, 53, 178568, new DateTime(2021, 2, 11, 5, 55, 28, 140, DateTimeKind.Local).AddTicks(6664), "Ut repellendus alias numquam iusto natus provident iste vero.\nNumquam eos sed et ratione dolorum nihil qui sit tempora.\nIllo quae hic minus consequuntur libero corporis.\nOmnis error deserunt rerum." },
                    { 95, 20, 114, 64283, new DateTime(2021, 5, 3, 14, 53, 34, 332, DateTimeKind.Local).AddTicks(2006), "Quaerat id repudiandae odit." },
                    { 146, 20, 80, 715536, new DateTime(2021, 4, 20, 12, 40, 22, 719, DateTimeKind.Local).AddTicks(2978), "Unde cupiditate accusamus occaecati optio illum error qui magni et." },
                    { 54, 69, 3, 553703, new DateTime(2021, 3, 3, 11, 47, 34, 544, DateTimeKind.Local).AddTicks(9514), "placeat" },
                    { 272, 20, 64, 172151, new DateTime(2021, 5, 17, 8, 38, 32, 78, DateTimeKind.Local).AddTicks(975), "Minima doloribus delectus.\nVoluptas et nobis voluptatibus vero aut et.\nDicta quibusdam ea aliquam autem suscipit praesentium quisquam.\nVoluptatem voluptatem sed sit incidunt cupiditate molestiae.\nDoloribus vitae voluptatibus modi voluptas." },
                    { 262, 38, 11, 433579, new DateTime(2021, 4, 7, 23, 11, 22, 188, DateTimeKind.Local).AddTicks(2580), "Culpa culpa nihil non quia facere molestiae ut maiores. Quis sapiente quia voluptatem quis. Hic quam praesentium laborum sunt maxime illum rerum rerum harum. Adipisci voluptatibus qui a fugiat voluptas maiores accusamus et." },
                    { 16, 3, 142, 572006, new DateTime(2021, 1, 25, 8, 22, 38, 466, DateTimeKind.Local).AddTicks(2675), "qui" },
                    { 9, 62, 44, 725996, new DateTime(2021, 4, 6, 16, 59, 40, 776, DateTimeKind.Local).AddTicks(1427), "Dolorem similique ratione." },
                    { 268, 69, 140, 150636, new DateTime(2021, 6, 28, 18, 21, 36, 35, DateTimeKind.Local).AddTicks(7665), "Perferendis aut modi culpa nihil delectus dolorem quia fugit.\nUt nostrum voluptatem.\nSuscipit amet illo blanditiis doloribus voluptatum ullam perferendis dolorem.\nQuam minima aut delectus necessitatibus mollitia consequatur quas." },
                    { 319, 87, 16, 224302, new DateTime(2021, 3, 29, 7, 54, 26, 577, DateTimeKind.Local).AddTicks(4639), "Corrupti eveniet asperiores deleniti eligendi dolorum." },
                    { 357, 87, 149, 605702, new DateTime(2020, 9, 11, 7, 28, 52, 434, DateTimeKind.Local).AddTicks(3627), "Ipsum non soluta." },
                    { 536, 87, 86, 705549, new DateTime(2020, 11, 19, 7, 0, 36, 339, DateTimeKind.Local).AddTicks(1619), "Non vitae officiis. Qui sed consequuntur vel. Qui nihil debitis debitis adipisci. Nulla error qui nihil impedit perferendis. Velit est mollitia natus quaerat excepturi quia repellat. Id velit sapiente amet quae est tenetur rerum cum." },
                    { 64, 93, 129, 718656, new DateTime(2020, 10, 3, 11, 17, 37, 354, DateTimeKind.Local).AddTicks(516), "Voluptatem dolorem enim quam ipsam excepturi fugit esse aliquam.\nAut est inventore tenetur.\nUnde adipisci nam alias aspernatur ducimus harum sint voluptas.\nCumque ipsa laborum dolore esse." },
                    { 105, 93, 14, 43973, new DateTime(2020, 12, 23, 20, 3, 59, 778, DateTimeKind.Local).AddTicks(330), "Sed consequatur quia reprehenderit impedit dignissimos tempora.\nCommodi aut voluptatibus est.\nEnim tempora nemo nostrum corporis fugiat et consectetur aperiam.\nAsperiores non voluptatem aut commodi sit ut assumenda.\nNon optio illum qui.\nProvident ex voluptate et aliquam repellat voluptate vel et non." },
                    { 182, 93, 31, 18061, new DateTime(2021, 3, 17, 5, 58, 20, 860, DateTimeKind.Local).AddTicks(6464), "Fuga veritatis id." },
                    { 6, 62, 9, 957293, new DateTime(2021, 1, 10, 6, 11, 16, 735, DateTimeKind.Local).AddTicks(1069), "velit" },
                    { 211, 93, 69, 21202, new DateTime(2021, 4, 28, 21, 33, 9, 898, DateTimeKind.Local).AddTicks(8433), "quos" },
                    { 554, 93, 120, 282325, new DateTime(2021, 4, 5, 3, 41, 17, 867, DateTimeKind.Local).AddTicks(3676), "Explicabo rem pariatur dolores rerum a hic eum.\nMagnam sint consequuntur.\nNobis incidunt rerum aut eligendi atque qui eaque non repellendus." },
                    { 125, 98, 123, 326026, new DateTime(2021, 7, 24, 20, 27, 23, 568, DateTimeKind.Local).AddTicks(9797), "Rerum labore nemo odio non molestias facere ut. Et tempore fugiat dolor repellat quibusdam beatae. Ratione necessitatibus et. Quaerat rerum maxime id quae quidem unde." },
                    { 441, 98, 8, 275502, new DateTime(2021, 4, 24, 9, 56, 41, 789, DateTimeKind.Local).AddTicks(2795), "Explicabo omnis est quo quia sint unde nesciunt. Maxime consequatur enim facere nobis libero vel ducimus velit incidunt. Nesciunt non expedita a expedita. In veniam architecto impedit odit perspiciatis aut. Consequatur ullam dolor." },
                    { 565, 98, 130, 639138, new DateTime(2020, 10, 12, 16, 52, 24, 221, DateTimeKind.Local).AddTicks(9005), "Unde harum et omnis eum nobis tempore sit." },
                    { 362, 105, 139, 482247, new DateTime(2020, 12, 18, 0, 4, 51, 948, DateTimeKind.Local).AddTicks(8872), "Qui nihil aut quaerat voluptatem necessitatibus adipisci.\nLaudantium nisi doloremque.\nItaque et occaecati ut ipsa dolor id sit laboriosam.\nQuaerat et qui ut." },
                    { 377, 105, 30, 74004, new DateTime(2020, 8, 20, 23, 56, 47, 929, DateTimeKind.Local).AddTicks(7654), "Sed nisi quisquam nulla dolores." },
                    { 235, 93, 93, 805717, new DateTime(2020, 12, 12, 9, 3, 27, 711, DateTimeKind.Local).AddTicks(2878), "Est mollitia pariatur qui illum aspernatur hic praesentium rem." },
                    { 13, 3, 134, 973749, new DateTime(2021, 4, 22, 8, 48, 25, 832, DateTimeKind.Local).AddTicks(246), "fuga" },
                    { 78, 11, 126, 961127, new DateTime(2021, 3, 12, 0, 14, 41, 284, DateTimeKind.Local).AddTicks(7996), "Qui aut odit exercitationem voluptatum nulla dolorum totam corrupti amet.\nCumque a odit non dicta.\nDelectus laborum corrupti architecto voluptas ut incidunt earum.\nQuos quidem cupiditate repudiandae autem ut qui.\nQui eos eum et veniam tempore voluptas ut." },
                    { 407, 71, 4, 699319, new DateTime(2021, 2, 21, 14, 52, 53, 603, DateTimeKind.Local).AddTicks(6928), "Sit eius rerum perspiciatis.\nVoluptatem consequatur aut animi repellendus eos quos aliquid maiores sunt.\nAliquid deserunt aut vel non voluptate consequatur.\nDolore cumque sunt ullam." },
                    { 503, 55, 53, 880054, new DateTime(2020, 11, 15, 9, 16, 16, 776, DateTimeKind.Local).AddTicks(2341), "Nihil nisi rerum." },
                    { 93, 44, 65, 251029, new DateTime(2021, 3, 27, 23, 30, 3, 671, DateTimeKind.Local).AddTicks(7829), "Non voluptates voluptatem repellat.\nVoluptatibus ea consequatur sint hic saepe rerum nemo ut et.\nSit autem laborum est recusandae unde sit.\nVeniam enim dolorem nobis quis modi et reprehenderit nesciunt et.\nDolores nostrum asperiores est repellat voluptatum unde repellendus." },
                    { 70, 97, 40, 904419, new DateTime(2020, 8, 15, 22, 52, 16, 401, DateTimeKind.Local).AddTicks(2665), "Assumenda molestias non sapiente itaque in. Accusamus dolores cum. Ducimus ipsam ipsa autem aut est iusto ea a a. Alias occaecati minima itaque. Iste quos quis et aperiam dignissimos." },
                    { 94, 97, 149, 420118, new DateTime(2021, 5, 17, 9, 53, 14, 946, DateTimeKind.Local).AddTicks(3951), "Ipsam excepturi explicabo itaque labore reiciendis culpa sit porro fuga. Quisquam quidem nostrum ducimus et atque consequatur et consequatur. Voluptatem nobis et dolore. Voluptas hic porro accusamus quo consequatur." },
                    { 120, 97, 117, 838197, new DateTime(2020, 10, 10, 10, 46, 37, 284, DateTimeKind.Local).AddTicks(8171), "Incidunt eius ullam voluptas tempora delectus." },
                    { 251, 97, 109, 848987, new DateTime(2020, 8, 23, 19, 28, 27, 177, DateTimeKind.Local).AddTicks(4257), "Sed qui aut culpa in ratione esse neque dolor alias." },
                    { 447, 55, 116, 731723, new DateTime(2021, 5, 9, 14, 26, 54, 227, DateTimeKind.Local).AddTicks(3352), "Quidem atque eius quia doloremque quia quos autem.\nAperiam mollitia consequatur eius quam.\nSint molestiae dolores eos a.\nAliquam esse delectus ipsum harum aut.\nCum autem velit sunt blanditiis cupiditate velit velit." },
                    { 302, 97, 29, 317495, new DateTime(2021, 7, 25, 14, 47, 18, 506, DateTimeKind.Local).AddTicks(6166), "Occaecati hic aliquid.\nCumque provident ut.\nNon laudantium corrupti deleniti sed ratione voluptate amet.\nMollitia ab rerum earum sit dolores qui enim.\nEst nesciunt occaecati eos provident recusandae nobis et." },
                    { 460, 97, 86, 590376, new DateTime(2021, 6, 15, 9, 28, 8, 894, DateTimeKind.Local).AddTicks(8292), "fuga" },
                    { 555, 97, 127, 232665, new DateTime(2021, 4, 16, 10, 10, 33, 419, DateTimeKind.Local).AddTicks(5607), "commodi" },
                    { 84, 44, 28, 329690, new DateTime(2021, 8, 1, 18, 1, 47, 452, DateTimeKind.Local).AddTicks(9141), "repellendus" },
                    { 141, 45, 144, 58958, new DateTime(2021, 1, 25, 3, 14, 42, 947, DateTimeKind.Local).AddTicks(5153), "Nesciunt iusto porro quia non quis nihil consequuntur." },
                    { 174, 45, 142, 396148, new DateTime(2021, 3, 17, 19, 56, 48, 748, DateTimeKind.Local).AddTicks(3848), "Eaque error dolorum magni sunt libero perspiciatis inventore blanditiis adipisci.\nRerum minus labore eum at." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 4, 18, 25, 464264, new DateTime(2020, 12, 10, 19, 56, 24, 668, DateTimeKind.Local).AddTicks(1773), "Fuga aut labore." },
                    { 420, 97, 13, 193974, new DateTime(2021, 6, 25, 2, 47, 27, 53, DateTimeKind.Local).AddTicks(3713), "Quae aspernatur architecto iure veniam ratione quis. Aut a adipisci neque ab est nisi occaecati. Doloremque sequi voluptatem non ad sit rerum magnam." },
                    { 132, 44, 16, 209045, new DateTime(2021, 1, 5, 3, 23, 31, 740, DateTimeKind.Local).AddTicks(1875), "Dolores praesentium quaerat omnis ut quidem. Dolorem tempore sapiente quae beatae corporis cum exercitationem. Vitae eius iste quia fugiat consequatur voluptatibus vel aut maiores. Ratione doloribus dolorem soluta enim laborum voluptates explicabo tempore ex." },
                    { 444, 55, 93, 291026, new DateTime(2021, 6, 8, 8, 56, 16, 658, DateTimeKind.Local).AddTicks(5035), "nostrum" },
                    { 428, 55, 46, 580273, new DateTime(2021, 2, 26, 3, 58, 19, 652, DateTimeKind.Local).AddTicks(5942), "Laudantium nam et." },
                    { 448, 50, 21, 952417, new DateTime(2020, 9, 5, 5, 14, 59, 176, DateTimeKind.Local).AddTicks(6928), "Eius ipsam debitis illo ut." },
                    { 481, 50, 122, 6477, new DateTime(2021, 5, 26, 14, 33, 13, 128, DateTimeKind.Local).AddTicks(6737), "Tempore consequatur asperiores et perferendis.\nCommodi quod deserunt.\nSint nihil nam magnam occaecati voluptates quia totam nihil et.\nEligendi beatae vero vitae quia rem." },
                    { 331, 44, 133, 719732, new DateTime(2021, 3, 17, 17, 40, 46, 998, DateTimeKind.Local).AddTicks(7848), "Rerum et qui.\nAccusamus repellat quia ea beatae repellat quasi." },
                    { 244, 44, 22, 478846, new DateTime(2020, 9, 20, 9, 32, 0, 372, DateTimeKind.Local).AddTicks(4874), "Magni facere aliquam maxime eos fugiat est est veniam.\nNon quaerat magnam praesentium ullam velit non possimus laboriosam repellendus." },
                    { 371, 92, 103, 21422, new DateTime(2020, 9, 10, 19, 39, 58, 72, DateTimeKind.Local).AddTicks(878), "Voluptas doloremque quia minus et.\nEsse laudantium id voluptatem quis tenetur aliquam eum.\nIpsam illo aliquid distinctio a delectus numquam nesciunt.\nExcepturi assumenda temporibus enim cumque eum nostrum assumenda architecto." },
                    { 573, 92, 94, 181747, new DateTime(2020, 12, 7, 10, 15, 57, 245, DateTimeKind.Local).AddTicks(9286), "consequatur" },
                    { 226, 44, 55, 16434, new DateTime(2021, 2, 22, 19, 53, 57, 599, DateTimeKind.Local).AddTicks(7442), "Consequatur repellat soluta sequi voluptatem ipsum." },
                    { 113, 4, 65, 31408, new DateTime(2020, 9, 1, 11, 12, 54, 534, DateTimeKind.Local).AddTicks(3625), "aut" },
                    { 202, 4, 21, 313895, new DateTime(2021, 3, 5, 10, 29, 51, 184, DateTimeKind.Local).AddTicks(4790), "voluptas" },
                    { 219, 4, 149, 370549, new DateTime(2021, 4, 15, 20, 53, 7, 372, DateTimeKind.Local).AddTicks(5558), "quam" },
                    { 289, 4, 35, 645973, new DateTime(2021, 2, 15, 0, 50, 0, 895, DateTimeKind.Local).AddTicks(325), "Ea aut velit praesentium rerum voluptatum corrupti." },
                    { 222, 44, 60, 850854, new DateTime(2021, 4, 11, 14, 41, 33, 774, DateTimeKind.Local).AddTicks(6544), "Ut enim ipsa eius." },
                    { 186, 55, 48, 924550, new DateTime(2020, 12, 28, 17, 23, 50, 218, DateTimeKind.Local).AddTicks(7702), "Natus alias perferendis labore natus quisquam quidem laboriosam." },
                    { 270, 55, 96, 286856, new DateTime(2021, 5, 30, 8, 9, 31, 131, DateTimeKind.Local).AddTicks(7045), "Eum est voluptatem sed alias voluptas occaecati neque ratione a." },
                    { 328, 55, 6, 946418, new DateTime(2021, 4, 14, 4, 54, 38, 929, DateTimeKind.Local).AddTicks(9780), "Excepturi amet similique et corrupti veniam natus mollitia non voluptatum." },
                    { 455, 45, 34, 258025, new DateTime(2020, 12, 5, 21, 25, 21, 838, DateTimeKind.Local).AddTicks(682), "Ut porro placeat et id possimus rerum." },
                    { 478, 45, 80, 837975, new DateTime(2021, 2, 26, 16, 20, 43, 128, DateTimeKind.Local).AddTicks(3007), "Aut autem qui quasi quo.\nNon libero debitis sit est quia tempore dolores sit.\nCorrupti cum ullam itaque sit modi voluptate mollitia debitis et.\nVoluptatem consequatur et qui ut quaerat.\nExercitationem repellendus aut.\nMagnam nulla quidem molestiae recusandae rerum deserunt et." },
                    { 230, 45, 1, 97813, new DateTime(2021, 7, 28, 5, 11, 7, 433, DateTimeKind.Local).AddTicks(4640), "Accusantium facilis consequatur enim corporis. Sunt sunt voluptates molestiae adipisci incidunt eum ut ad. Impedit numquam sit ut quia voluptatibus unde hic enim. Fugit delectus nihil commodi qui a eum perspiciatis maiores voluptas. Animi omnis expedita hic mollitia sed ad voluptas delectus ea. Libero sed vel architecto molestias beatae adipisci." },
                    { 566, 45, 23, 707825, new DateTime(2021, 5, 22, 8, 1, 31, 536, DateTimeKind.Local).AddTicks(7264), "occaecati" },
                    { 150, 48, 60, 532265, new DateTime(2020, 9, 21, 1, 39, 2, 676, DateTimeKind.Local).AddTicks(1170), "nam" },
                    { 413, 48, 18, 968355, new DateTime(2020, 12, 23, 21, 45, 48, 260, DateTimeKind.Local).AddTicks(6352), "et" },
                    { 223, 18, 127, 611852, new DateTime(2020, 9, 21, 7, 5, 44, 268, DateTimeKind.Local).AddTicks(2016), "Quidem aliquid saepe quis ipsam tempora dolores ut ut ut. In odio dolor quia a et tempora et distinctio. Ut sequi soluta porro doloremque sed explicabo vero consectetur et. Qui et dicta et libero ipsa ut. Nulla cupiditate illum et corrupti optio animi odio magni." },
                    { 11, 66, 69, 894871, new DateTime(2021, 3, 15, 16, 40, 16, 299, DateTimeKind.Local).AddTicks(6908), "Ex est inventore maiores maxime unde aliquam.\nMinima sequi et et tempore animi.\nSit ut ut et dolorum.\nSit voluptatibus placeat aut est distinctio dignissimos earum.\nQuisquam in rerum modi modi soluta." },
                    { 66, 66, 71, 124693, new DateTime(2021, 3, 9, 15, 49, 55, 372, DateTimeKind.Local).AddTicks(5355), "Aut quibusdam ut rerum harum perspiciatis atque velit iure voluptates." },
                    { 100, 66, 66, 86506, new DateTime(2021, 7, 21, 19, 18, 48, 724, DateTimeKind.Local).AddTicks(547), "Beatae a est laboriosam. Culpa tempore magni. Nihil dolores animi consectetur ex dolor neque. Recusandae voluptates provident architecto tempora et ex reiciendis animi repellendus." },
                    { 26, 48, 104, 885693, new DateTime(2020, 11, 26, 3, 33, 15, 184, DateTimeKind.Local).AddTicks(8741), "illo" },
                    { 151, 18, 8, 47349, new DateTime(2021, 2, 27, 0, 31, 46, 217, DateTimeKind.Local).AddTicks(5380), "Velit quidem et provident libero dolor non non quia.\nNecessitatibus voluptatum debitis perferendis asperiores.\nFacere eum et commodi suscipit et enim totam.\nAutem beatae ducimus." },
                    { 134, 66, 131, 81290, new DateTime(2021, 5, 4, 9, 6, 0, 136, DateTimeKind.Local).AddTicks(2585), "Quis quae tempore cum laudantium et veritatis.\nOfficia harum cupiditate ratione ut veniam quis qui repudiandae libero.\nEa repellat enim magni eos quisquam molestiae inventore magnam.\nInventore et ex dignissimos iste repudiandae.\nEa nostrum et dolor incidunt mollitia." },
                    { 300, 66, 73, 174921, new DateTime(2020, 8, 31, 11, 47, 23, 726, DateTimeKind.Local).AddTicks(8949), "Ut dolores enim dignissimos facere.\nIllo qui quia corrupti est natus nemo ad.\nUt aliquam aliquam voluptatem exercitationem blanditiis sapiente." },
                    { 24, 71, 116, 533157, new DateTime(2021, 7, 5, 3, 30, 49, 583, DateTimeKind.Local).AddTicks(8810), "Voluptatem odio laborum et qui.\nDignissimos assumenda sit assumenda rerum deleniti ut ad dolor.\nUt dolor perspiciatis est quo temporibus delectus omnis." },
                    { 39, 71, 58, 12388, new DateTime(2021, 7, 4, 11, 13, 32, 913, DateTimeKind.Local).AddTicks(3932), "Aut quia eius ad quisquam. Ab minima non maxime dicta assumenda accusantium autem velit officiis. Veritatis in quam sunt quisquam facilis quis non repellendus. Et ut et possimus qui non necessitatibus. Placeat aut quia explicabo quia ut aut numquam." },
                    { 14, 18, 115, 776817, new DateTime(2021, 1, 27, 4, 2, 17, 980, DateTimeKind.Local).AddTicks(996), "Et libero aut ducimus autem cum est quis sint. Voluptas molestiae sunt beatae soluta ut at. Doloribus repellat veniam velit quisquam omnis quam velit. Aut et mollitia. Atque tempora eum rem in dolores quam." },
                    { 46, 71, 77, 823871, new DateTime(2021, 6, 5, 18, 48, 47, 429, DateTimeKind.Local).AddTicks(7432), "quis" },
                    { 115, 66, 128, 423806, new DateTime(2021, 7, 30, 1, 8, 38, 750, DateTimeKind.Local).AddTicks(9692), "Eos atque reiciendis sit." },
                    { 543, 45, 26, 550375, new DateTime(2021, 2, 9, 19, 27, 27, 244, DateTimeKind.Local).AddTicks(3609), "Repellat sunt repellat qui consectetur aliquam quis et. Quia et recusandae distinctio facere repudiandae ad at non. Sunt distinctio ipsum." },
                    { 385, 18, 52, 310937, new DateTime(2020, 11, 27, 7, 17, 25, 836, DateTimeKind.Local).AddTicks(8779), "Expedita quasi impedit qui hic magnam aut ut est." },
                    { 592, 34, 32, 628078, new DateTime(2021, 4, 9, 20, 35, 12, 672, DateTimeKind.Local).AddTicks(4102), "Sapiente consequuntur fugit autem et esse. Nihil illum natus aut consequatur et. Vero saepe doloremque sed doloribus quaerat in officia ipsum." }
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CarId", "CarServiceId", "Mileage", "RepairDate", "Repairs" },
                values: new object[,]
                {
                    { 459, 18, 31, 97394, new DateTime(2021, 4, 5, 0, 42, 30, 917, DateTimeKind.Local).AddTicks(6919), "Ut reprehenderit nulla tenetur quisquam consequatur suscipit dicta rerum. Non in reiciendis at doloremque nam dolor. Ab eum voluptas dolore et ut qui non eum rerum. Accusantium ut sapiente unde animi. Omnis et aut. Rem et velit illo eaque." },
                    { 547, 67, 14, 606647, new DateTime(2021, 1, 22, 15, 39, 22, 207, DateTimeKind.Local).AddTicks(1280), "Dolorem officia blanditiis." },
                    { 353, 72, 22, 802927, new DateTime(2021, 5, 8, 4, 45, 4, 390, DateTimeKind.Local).AddTicks(5331), "Repellendus tempore dolorem sapiente laboriosam explicabo at reprehenderit ut provident." },
                    { 351, 67, 119, 476695, new DateTime(2021, 3, 1, 6, 16, 42, 507, DateTimeKind.Local).AddTicks(2899), "Eum aspernatur occaecati reiciendis.\nRerum sed qui porro sunt et.\nSed itaque deleniti delectus.\nOccaecati eos et cum." },
                    { 339, 67, 24, 847136, new DateTime(2020, 10, 27, 22, 7, 11, 558, DateTimeKind.Local).AddTicks(7796), "Temporibus exercitationem minus iusto eum repellat et vitae sint tempora." },
                    { 356, 72, 91, 987836, new DateTime(2021, 5, 6, 5, 57, 20, 894, DateTimeKind.Local).AddTicks(2721), "Omnis in vel omnis porro ut et.\nPerspiciatis ea optio in doloremque qui architecto veritatis tempora.\nId numquam sit et est quia reiciendis." },
                    { 33, 67, 85, 93743, new DateTime(2021, 1, 20, 9, 42, 51, 715, DateTimeKind.Local).AddTicks(4101), "eos" },
                    { 599, 67, 35, 420391, new DateTime(2020, 8, 18, 22, 41, 14, 891, DateTimeKind.Local).AddTicks(3423), "accusantium" },
                    { 583, 18, 37, 866677, new DateTime(2021, 2, 21, 0, 35, 25, 55, DateTimeKind.Local).AddTicks(1573), "modi" },
                    { 487, 34, 10, 337283, new DateTime(2021, 7, 10, 1, 19, 37, 270, DateTimeKind.Local).AddTicks(6279), "Dolorem quasi et accusantium facilis placeat consequatur ex." },
                    { 176, 34, 63, 537166, new DateTime(2020, 9, 8, 6, 8, 0, 155, DateTimeKind.Local).AddTicks(3286), "libero" },
                    { 28, 34, 5, 460146, new DateTime(2020, 8, 13, 2, 11, 32, 997, DateTimeKind.Local).AddTicks(1022), "Perspiciatis nobis placeat dolorum magni dolorum similique corrupti." }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 92, 18, 177 },
                    { 27, 46, 142 },
                    { 88, 24, 1 },
                    { 57, 43, 148 },
                    { 78, 81, 248 },
                    { 44, 83, 269 },
                    { 22, 26, 224 },
                    { 11, 69, 127 },
                    { 29, 96, 127 },
                    { 17, 20, 84 },
                    { 97, 101, 85 },
                    { 9, 28, 101 },
                    { 58, 72, 84 },
                    { 85, 15, 257 },
                    { 94, 34, 159 },
                    { 33, 5, 269 },
                    { 45, 80, 131 },
                    { 3, 48, 13 },
                    { 46, 100, 47 },
                    { 31, 99, 287 },
                    { 102, 71, 29 },
                    { 32, 54, 224 },
                    { 5, 55, 272 },
                    { 6, 3, 171 },
                    { 42, 12, 41 },
                    { 53, 29, 176 },
                    { 14, 13, 15 },
                    { 54, 88, 246 },
                    { 2, 87, 281 },
                    { 30, 93, 15 }
                });

            migrationBuilder.InsertData(
                table: "UserCars",
                columns: new[] { "Id", "CarId", "UserId" },
                values: new object[,]
                {
                    { 24, 105, 160 },
                    { 25, 102, 13 },
                    { 50, 62, 257 },
                    { 95, 38, 176 },
                    { 1, 49, 148 },
                    { 12, 52, 178 },
                    { 91, 94, 66 },
                    { 61, 4, 169 },
                    { 55, 92, 294 },
                    { 35, 53, 84 },
                    { 62, 77, 49 },
                    { 77, 17, 281 },
                    { 28, 51, 41 },
                    { 8, 7, 99 },
                    { 16, 84, 76 },
                    { 39, 9, 279 },
                    { 21, 30, 41 },
                    { 64, 2, 15 },
                    { 41, 42, 234 },
                    { 84, 82, 109 },
                    { 7, 75, 293 },
                    { 13, 106, 148 },
                    { 96, 10, 295 },
                    { 4, 104, 235 },
                    { 76, 59, 101 },
                    { 48, 22, 136 },
                    { 98, 23, 241 },
                    { 15, 21, 283 },
                    { 23, 65, 178 },
                    { 63, 32, 224 },
                    { 51, 25, 178 },
                    { 75, 95, 294 },
                    { 10, 86, 253 },
                    { 18, 50, 272 },
                    { 20, 68, 41 },
                    { 26, 74, 171 }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 16, new DateTime(2021, 1, 11, 20, 34, 59, 69, DateTimeKind.Local).AddTicks(1127), 25, new DateTime(2022, 8, 1, 9, 42, 59, 418, DateTimeKind.Local).AddTicks(3207), new DateTime(2021, 5, 24, 6, 55, 49, 528, DateTimeKind.Local).AddTicks(7623), 4, 29, "Possimus eligendi sunt ipsum ea deleniti rerum. Sit consequuntur rerum cumque qui occaecati. Iure inventore sapiente dolorem eligendi. Autem aliquid qui eius repudiandae ut mollitia odit eum sed." },
                    { 92, new DateTime(2021, 2, 28, 8, 47, 14, 223, DateTimeKind.Local).AddTicks(9662), 114, new DateTime(2022, 2, 12, 23, 29, 41, 176, DateTimeKind.Local).AddTicks(8802), new DateTime(2020, 12, 10, 3, 1, 40, 93, DateTimeKind.Local).AddTicks(8151), 3, 9, "Ut excepturi hic nemo vero aut. Ea dolores omnis similique. Qui ut laboriosam in deserunt cumque illum. Non quis ea sed est explicabo necessitatibus voluptate sint. Ipsam dolore necessitatibus. Est consequuntur quo debitis quod rerum et sunt." },
                    { 143, new DateTime(2020, 12, 22, 21, 54, 20, 37, DateTimeKind.Local).AddTicks(8264), 2, new DateTime(2021, 10, 15, 11, 43, 29, 687, DateTimeKind.Local).AddTicks(594), new DateTime(2021, 7, 31, 1, 39, 35, 258, DateTimeKind.Local).AddTicks(2316), 2, 9, "In enim culpa illo tempore. Laudantium eius vel aut exercitationem deserunt voluptatibus exercitationem molestias exercitationem. Quae ut odio minima quidem in quasi ea repellendus." },
                    { 155, new DateTime(2020, 9, 5, 7, 50, 45, 229, DateTimeKind.Local).AddTicks(4081), 147, new DateTime(2021, 10, 6, 14, 46, 14, 864, DateTimeKind.Local).AddTicks(7932), new DateTime(2020, 12, 6, 5, 33, 10, 556, DateTimeKind.Local).AddTicks(552), 2, 9, "voluptates" },
                    { 52, new DateTime(2020, 10, 9, 22, 58, 0, 160, DateTimeKind.Local).AddTicks(5141), 67, new DateTime(2021, 11, 12, 23, 41, 10, 852, DateTimeKind.Local).AddTicks(395), new DateTime(2020, 12, 19, 17, 28, 55, 732, DateTimeKind.Local).AddTicks(2171), 5, 91, "Id doloremque rerum est. Omnis est provident. Aspernatur beatae et. Provident aut eos beatae deserunt ut laborum consequatur. Ut neque tempora dolorem odio molestias." },
                    { 96, new DateTime(2020, 9, 5, 6, 26, 15, 903, DateTimeKind.Local).AddTicks(9039), 22, new DateTime(2022, 5, 2, 5, 13, 15, 560, DateTimeKind.Local).AddTicks(2145), new DateTime(2021, 8, 12, 18, 4, 18, 353, DateTimeKind.Local).AddTicks(8009), 3, 91, "Delectus ut tempora quas dicta qui quia vel minima harum.\nAut quaerat reiciendis.\nAut magni consequatur tempora amet illo esse voluptatem delectus.\nDolore harum qui tempora aspernatur modi vel.\nEst quibusdam omnis in." },
                    { 67, new DateTime(2021, 8, 5, 13, 57, 53, 280, DateTimeKind.Local).AddTicks(6741), 39, new DateTime(2022, 6, 18, 9, 41, 27, 389, DateTimeKind.Local).AddTicks(7132), new DateTime(2020, 10, 17, 10, 14, 38, 354, DateTimeKind.Local).AddTicks(896), 2, 10, "Ea dicta animi esse aut.\nModi facere at corporis fugit.\nHarum fugiat hic at.\nVelit et consequuntur voluptatem." },
                    { 147, new DateTime(2021, 3, 8, 9, 46, 42, 31, DateTimeKind.Local).AddTicks(8600), 42, new DateTime(2021, 11, 4, 4, 38, 34, 765, DateTimeKind.Local).AddTicks(3239), new DateTime(2020, 9, 30, 20, 30, 21, 403, DateTimeKind.Local).AddTicks(953), 1, 10, "Expedita maiores aliquid ut sed eius quo repellat occaecati. Quisquam earum et quod qui unde qui. Delectus voluptatem rerum at. Magni eligendi consequatur dolores sit ut quae quas ullam. Earum asperiores ea molestiae possimus accusantium vero nihil et error." },
                    { 156, new DateTime(2020, 12, 17, 2, 23, 1, 820, DateTimeKind.Local).AddTicks(366), 84, new DateTime(2021, 12, 3, 17, 7, 15, 714, DateTimeKind.Local).AddTicks(4746), new DateTime(2021, 7, 13, 2, 11, 54, 104, DateTimeKind.Local).AddTicks(2478), 5, 10, "Beatae nulla et dolores aut eligendi quos." },
                    { 177, new DateTime(2021, 4, 22, 11, 56, 40, 657, DateTimeKind.Local).AddTicks(45), 105, new DateTime(2021, 10, 7, 14, 15, 54, 870, DateTimeKind.Local).AddTicks(5599), new DateTime(2020, 8, 31, 8, 42, 11, 114, DateTimeKind.Local).AddTicks(7053), 4, 10, "Voluptatem sint itaque nihil." },
                    { 182, new DateTime(2021, 2, 13, 23, 35, 3, 490, DateTimeKind.Local).AddTicks(235), 41, new DateTime(2022, 2, 8, 16, 2, 42, 927, DateTimeKind.Local).AddTicks(5100), new DateTime(2021, 2, 24, 20, 7, 24, 6, DateTimeKind.Local).AddTicks(1222), 1, 10, "dolore" },
                    { 38, new DateTime(2021, 4, 12, 12, 27, 22, 976, DateTimeKind.Local).AddTicks(2148), 59, new DateTime(2021, 8, 25, 8, 15, 33, 78, DateTimeKind.Local).AddTicks(838), new DateTime(2020, 9, 4, 3, 44, 49, 301, DateTimeKind.Local).AddTicks(7685), 1, 75, "Qui ullam maiores sapiente et." },
                    { 56, new DateTime(2021, 2, 16, 23, 31, 5, 844, DateTimeKind.Local).AddTicks(6790), 122, new DateTime(2022, 2, 11, 3, 34, 29, 349, DateTimeKind.Local).AddTicks(3464), new DateTime(2020, 10, 5, 21, 21, 42, 594, DateTimeKind.Local).AddTicks(6119), 4, 75, "Provident vel ullam corrupti consequatur perferendis sit iure aut atque. Repellat quo fugit. Et occaecati porro beatae. Provident nesciunt repudiandae temporibus quo rerum ab odio quasi. Rerum dolorem tempora." },
                    { 84, new DateTime(2021, 5, 6, 20, 13, 13, 527, DateTimeKind.Local).AddTicks(5941), 60, new DateTime(2021, 8, 26, 21, 21, 22, 45, DateTimeKind.Local).AddTicks(7981), new DateTime(2021, 6, 16, 23, 41, 15, 454, DateTimeKind.Local).AddTicks(1870), 4, 75, "Voluptatem incidunt recusandae sequi est facere quia nesciunt sequi laudantium. Modi cupiditate maxime esse. Soluta dolor nesciunt distinctio doloribus. Nostrum doloribus adipisci quibusdam eum distinctio ut voluptatum." },
                    { 111, new DateTime(2021, 1, 12, 4, 12, 57, 293, DateTimeKind.Local).AddTicks(1164), 99, new DateTime(2022, 6, 17, 6, 23, 5, 501, DateTimeKind.Local).AddTicks(5461), new DateTime(2020, 8, 31, 5, 12, 26, 354, DateTimeKind.Local).AddTicks(1479), 3, 75, "Omnis praesentium dolor vel nihil." },
                    { 127, new DateTime(2021, 1, 17, 18, 27, 35, 275, DateTimeKind.Local).AddTicks(7627), 74, new DateTime(2021, 9, 2, 13, 54, 37, 595, DateTimeKind.Local).AddTicks(4913), new DateTime(2021, 2, 6, 15, 27, 45, 405, DateTimeKind.Local).AddTicks(2967), 5, 75, "Saepe ratione beatae aliquam." },
                    { 151, new DateTime(2021, 2, 3, 21, 36, 39, 801, DateTimeKind.Local).AddTicks(1378), 57, new DateTime(2021, 12, 24, 8, 8, 12, 180, DateTimeKind.Local).AddTicks(7937), new DateTime(2021, 6, 11, 7, 17, 33, 406, DateTimeKind.Local).AddTicks(7680), 1, 75, "Voluptatem laudantium provident doloribus fugiat minus." },
                    { 64, new DateTime(2020, 10, 8, 23, 41, 8, 83, DateTimeKind.Local).AddTicks(2253), 41, new DateTime(2021, 9, 17, 22, 56, 33, 996, DateTimeKind.Local).AddTicks(220), new DateTime(2020, 12, 1, 7, 4, 17, 552, DateTimeKind.Local).AddTicks(7368), 1, 51, "doloremque" },
                    { 75, new DateTime(2021, 7, 14, 5, 25, 39, 206, DateTimeKind.Local).AddTicks(7875), 117, new DateTime(2022, 7, 9, 13, 23, 44, 265, DateTimeKind.Local).AddTicks(4583), new DateTime(2021, 5, 17, 8, 39, 39, 534, DateTimeKind.Local).AddTicks(5652), 3, 15, "Perspiciatis eligendi voluptatem quia sint dignissimos minus est beatae. Sunt ut voluptatibus dicta vero odio expedita autem non. Cupiditate harum recusandae ut necessitatibus eos aspernatur dolorem. Neque voluptas recusandae." },
                    { 125, new DateTime(2021, 5, 27, 15, 51, 6, 370, DateTimeKind.Local).AddTicks(3130), 79, new DateTime(2022, 2, 5, 19, 18, 35, 488, DateTimeKind.Local).AddTicks(1533), new DateTime(2021, 3, 27, 23, 3, 0, 632, DateTimeKind.Local).AddTicks(1814), 4, 15, "Accusantium et laboriosam ut rem dolores beatae consectetur quis quis. Perspiciatis dolorum ipsum corrupti quasi earum rerum rem et. Eum est adipisci ut eius non error dolores. Quas non illum iste dolores nihil voluptas tempore rerum sequi." },
                    { 185, new DateTime(2020, 10, 24, 5, 41, 36, 108, DateTimeKind.Local).AddTicks(3334), 31, new DateTime(2021, 9, 10, 20, 44, 12, 195, DateTimeKind.Local).AddTicks(9485), new DateTime(2021, 6, 16, 16, 44, 42, 997, DateTimeKind.Local).AddTicks(5570), 2, 15, "sunt" },
                    { 39, new DateTime(2021, 1, 18, 5, 21, 0, 964, DateTimeKind.Local).AddTicks(160), 114, new DateTime(2022, 6, 14, 18, 7, 0, 571, DateTimeKind.Local).AddTicks(3619), new DateTime(2021, 4, 27, 17, 9, 21, 502, DateTimeKind.Local).AddTicks(8549), 5, 98, "et" },
                    { 48, new DateTime(2020, 11, 7, 15, 45, 53, 194, DateTimeKind.Local).AddTicks(6602), 109, new DateTime(2021, 8, 23, 16, 4, 32, 799, DateTimeKind.Local).AddTicks(8165), new DateTime(2021, 5, 12, 20, 22, 35, 318, DateTimeKind.Local).AddTicks(7814), 5, 9, "tempore" },
                    { 68, new DateTime(2020, 11, 8, 9, 36, 22, 611, DateTimeKind.Local).AddTicks(2181), 48, new DateTime(2022, 7, 11, 7, 25, 35, 600, DateTimeKind.Local).AddTicks(6728), new DateTime(2020, 11, 12, 15, 3, 59, 162, DateTimeKind.Local).AddTicks(7086), 3, 98, "eveniet" },
                    { 138, new DateTime(2021, 2, 18, 1, 37, 29, 907, DateTimeKind.Local).AddTicks(5438), 123, new DateTime(2022, 8, 3, 13, 3, 11, 482, DateTimeKind.Local).AddTicks(5622), new DateTime(2020, 11, 14, 7, 13, 44, 961, DateTimeKind.Local).AddTicks(9555), 3, 85, "Saepe dignissimos excepturi.\nMollitia quo architecto enim amet quo et minus commodi.\nQuibusdam eveniet aut." },
                    { 116, new DateTime(2021, 2, 28, 8, 44, 46, 889, DateTimeKind.Local).AddTicks(451), 105, new DateTime(2022, 4, 9, 5, 3, 15, 503, DateTimeKind.Local).AddTicks(4817), new DateTime(2020, 11, 30, 7, 24, 31, 421, DateTimeKind.Local).AddTicks(9039), 1, 85, "Perspiciatis animi magnam ratione quas tempore. Facere dolores iste voluptatem rerum. At nam eos consequatur qui nemo consequatur. Temporibus quibusdam vel voluptatum voluptatibus. Vel ut suscipit doloremque porro quaerat voluptas. Assumenda accusantium nostrum quisquam voluptatem labore dolorum sapiente accusantium." },
                    { 118, new DateTime(2021, 8, 12, 7, 48, 18, 424, DateTimeKind.Local).AddTicks(2708), 93, new DateTime(2021, 10, 7, 9, 37, 18, 972, DateTimeKind.Local).AddTicks(9096), new DateTime(2020, 8, 25, 14, 34, 0, 716, DateTimeKind.Local).AddTicks(6727), 5, 14, "Rerum occaecati quibusdam.\nId et assumenda aut saepe fugit architecto.\nVeniam similique quo eum est molestiae.\nVoluptas voluptates occaecati quae nemo explicabo sed aut facere." },
                    { 191, new DateTime(2021, 4, 14, 13, 53, 45, 885, DateTimeKind.Local).AddTicks(350), 78, new DateTime(2022, 5, 29, 18, 42, 50, 745, DateTimeKind.Local).AddTicks(9062), new DateTime(2020, 10, 17, 8, 29, 48, 291, DateTimeKind.Local).AddTicks(1228), 5, 14, "Quam doloremque aut molestiae dolor assumenda et atque quis.\nReprehenderit reiciendis assumenda non nesciunt commodi vero voluptas." },
                    { 109, new DateTime(2021, 7, 24, 0, 5, 3, 681, DateTimeKind.Local).AddTicks(2943), 112, new DateTime(2022, 1, 27, 17, 34, 43, 39, DateTimeKind.Local).AddTicks(2215), new DateTime(2021, 7, 17, 4, 2, 22, 714, DateTimeKind.Local).AddTicks(2695), 4, 53, "Voluptatem ad eveniet optio.\nOdit tenetur magni aspernatur repellendus.\nPerspiciatis quam possimus tempora saepe ex." },
                    { 72, new DateTime(2021, 3, 2, 10, 11, 43, 375, DateTimeKind.Local).AddTicks(6200), 79, new DateTime(2022, 4, 12, 0, 57, 29, 779, DateTimeKind.Local).AddTicks(9974), new DateTime(2021, 7, 20, 10, 2, 41, 631, DateTimeKind.Local).AddTicks(4278), 4, 12, "Eaque minus est. Eius magni saepe dolore occaecati hic tempore veniam provident. Voluptatem earum saepe necessitatibus. Ipsum modi dolor." },
                    { 98, new DateTime(2021, 1, 23, 6, 38, 32, 350, DateTimeKind.Local).AddTicks(3884), 120, new DateTime(2022, 7, 4, 3, 17, 59, 497, DateTimeKind.Local).AddTicks(7699), new DateTime(2021, 4, 16, 8, 35, 1, 929, DateTimeKind.Local).AddTicks(4207), 2, 12, "Maiores non adipisci consequatur.\nQuae neque maiores et assumenda similique repellendus.\nReiciendis atque officiis facere debitis autem vel dolore.\nEnim maiores nesciunt dolorum odit nemo magnam ut." },
                    { 130, new DateTime(2021, 6, 7, 11, 52, 51, 249, DateTimeKind.Local).AddTicks(7077), 105, new DateTime(2022, 6, 19, 9, 36, 4, 439, DateTimeKind.Local).AddTicks(3032), new DateTime(2021, 7, 13, 4, 49, 2, 330, DateTimeKind.Local).AddTicks(6153), 3, 12, "Quod quia recusandae eos modi et et commodi perferendis et." },
                    { 145, new DateTime(2020, 12, 8, 11, 17, 21, 254, DateTimeKind.Local).AddTicks(1361), 80, new DateTime(2022, 7, 16, 0, 32, 9, 465, DateTimeKind.Local).AddTicks(1028), new DateTime(2020, 12, 18, 2, 35, 16, 297, DateTimeKind.Local).AddTicks(962), 2, 12, "Est dolore et nulla voluptatem dolor enim dolor quae. Eligendi excepturi optio rerum minima molestiae ipsa et aut. Dolore accusamus mollitia eveniet et non quidem labore commodi et." },
                    { 174, new DateTime(2021, 6, 11, 2, 4, 12, 932, DateTimeKind.Local).AddTicks(7709), 58, new DateTime(2022, 4, 8, 4, 29, 16, 315, DateTimeKind.Local).AddTicks(7869), new DateTime(2020, 10, 29, 4, 57, 48, 882, DateTimeKind.Local).AddTicks(9205), 2, 12, "Illum provident qui et eligendi et dicta. Ratione aspernatur eum dolore quia. Doloremque quasi eos vitae nobis quis." },
                    { 93, new DateTime(2020, 8, 26, 23, 54, 44, 122, DateTimeKind.Local).AddTicks(6688), 12, new DateTime(2021, 9, 8, 9, 24, 42, 269, DateTimeKind.Local).AddTicks(7647), new DateTime(2021, 1, 9, 19, 44, 19, 885, DateTimeKind.Local).AddTicks(253), 1, 32, "esse" },
                    { 196, new DateTime(2020, 10, 18, 1, 58, 3, 830, DateTimeKind.Local).AddTicks(7974), 94, new DateTime(2022, 3, 7, 18, 24, 11, 871, DateTimeKind.Local).AddTicks(1935), new DateTime(2021, 6, 16, 3, 39, 21, 320, DateTimeKind.Local).AddTicks(1875), 1, 32, "Expedita aut velit." },
                    { 150, new DateTime(2021, 6, 30, 1, 18, 57, 85, DateTimeKind.Local).AddTicks(7577), 17, new DateTime(2021, 10, 17, 1, 23, 42, 289, DateTimeKind.Local).AddTicks(7039), new DateTime(2020, 10, 15, 9, 46, 59, 83, DateTimeKind.Local).AddTicks(213), 2, 31, "Quos maxime explicabo." },
                    { 1, new DateTime(2020, 8, 25, 14, 45, 45, 620, DateTimeKind.Local).AddTicks(9693), 92, new DateTime(2022, 3, 14, 3, 24, 50, 631, DateTimeKind.Local).AddTicks(9250), new DateTime(2021, 1, 18, 11, 11, 11, 540, DateTimeKind.Local).AddTicks(5652), 2, 46, "perferendis" },
                    { 6, new DateTime(2020, 12, 25, 5, 48, 30, 982, DateTimeKind.Local).AddTicks(8837), 38, new DateTime(2021, 11, 30, 7, 56, 54, 328, DateTimeKind.Local).AddTicks(5552), new DateTime(2020, 12, 27, 7, 32, 59, 892, DateTimeKind.Local).AddTicks(8011), 1, 46, "quasi" },
                    { 90, new DateTime(2021, 1, 6, 10, 3, 17, 82, DateTimeKind.Local).AddTicks(1189), 140, new DateTime(2021, 9, 24, 6, 5, 58, 539, DateTimeKind.Local).AddTicks(695), new DateTime(2020, 9, 19, 1, 5, 30, 92, DateTimeKind.Local).AddTicks(2885), 3, 46, "Consequatur reiciendis et dolor ullam porro accusamus.\nOfficiis quo amet ipsa tempore in molestiae repudiandae id.\nEos quisquam magni aperiam quidem nam amet." },
                    { 107, new DateTime(2021, 5, 3, 23, 47, 6, 267, DateTimeKind.Local).AddTicks(1375), 53, new DateTime(2021, 9, 7, 6, 16, 58, 785, DateTimeKind.Local).AddTicks(7339), new DateTime(2020, 11, 21, 8, 24, 33, 331, DateTimeKind.Local).AddTicks(2221), 1, 46, "Quibusdam non sunt modi nulla. Explicabo facilis ad praesentium sint porro illo ipsam in. Tempora modi voluptates distinctio." },
                    { 129, new DateTime(2021, 2, 1, 3, 58, 47, 499, DateTimeKind.Local).AddTicks(1903), 95, new DateTime(2022, 3, 17, 4, 15, 47, 643, DateTimeKind.Local).AddTicks(2085), new DateTime(2020, 12, 2, 9, 24, 10, 969, DateTimeKind.Local).AddTicks(5275), 4, 46, "itaque" }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 99, new DateTime(2020, 8, 15, 13, 31, 9, 516, DateTimeKind.Local).AddTicks(5496), 85, new DateTime(2022, 4, 29, 14, 20, 30, 939, DateTimeKind.Local).AddTicks(6788), new DateTime(2021, 3, 26, 16, 22, 39, 148, DateTimeKind.Local).AddTicks(2928), 3, 33, "aut" },
                    { 149, new DateTime(2021, 4, 21, 21, 28, 39, 910, DateTimeKind.Local).AddTicks(3515), 15, new DateTime(2022, 4, 23, 16, 6, 27, 443, DateTimeKind.Local).AddTicks(5306), new DateTime(2021, 7, 14, 8, 12, 12, 224, DateTimeKind.Local).AddTicks(7345), 1, 33, "expedita" },
                    { 172, new DateTime(2021, 3, 20, 2, 3, 32, 663, DateTimeKind.Local).AddTicks(4134), 22, new DateTime(2022, 5, 9, 23, 48, 8, 77, DateTimeKind.Local).AddTicks(7489), new DateTime(2020, 8, 14, 20, 30, 46, 346, DateTimeKind.Local).AddTicks(8003), 4, 33, "Harum similique voluptatem." },
                    { 2, new DateTime(2020, 9, 26, 12, 55, 58, 554, DateTimeKind.Local).AddTicks(3976), 92, new DateTime(2021, 12, 24, 22, 8, 47, 984, DateTimeKind.Local).AddTicks(7379), new DateTime(2021, 2, 24, 21, 31, 19, 107, DateTimeKind.Local).AddTicks(2126), 4, 85, "minus" },
                    { 24, new DateTime(2020, 10, 14, 16, 53, 58, 397, DateTimeKind.Local).AddTicks(7027), 120, new DateTime(2022, 7, 14, 16, 57, 9, 206, DateTimeKind.Local).AddTicks(7301), new DateTime(2021, 7, 5, 23, 3, 53, 198, DateTimeKind.Local).AddTicks(9552), 1, 85, "Et qui deleniti ad qui. Numquam enim laudantium enim magnam molestiae harum. Est itaque iusto fugit molestias aut perspiciatis qui cum laudantium." },
                    { 123, new DateTime(2021, 4, 4, 5, 5, 6, 849, DateTimeKind.Local).AddTicks(703), 86, new DateTime(2021, 11, 27, 3, 22, 12, 687, DateTimeKind.Local).AddTicks(667), new DateTime(2020, 12, 17, 19, 13, 40, 949, DateTimeKind.Local).AddTicks(9628), 5, 85, "Quo sequi similique qui. At pariatur veniam dolorem velit est illum. Sit non aliquam a. Quia provident numquam nobis sed tempora rem ipsa ex assumenda. Qui voluptates repellendus. Omnis nesciunt ipsa sit sit." },
                    { 79, new DateTime(2020, 8, 31, 9, 58, 10, 995, DateTimeKind.Local).AddTicks(2339), 49, new DateTime(2022, 4, 18, 16, 20, 18, 400, DateTimeKind.Local).AddTicks(5612), new DateTime(2021, 8, 1, 2, 7, 8, 741, DateTimeKind.Local).AddTicks(5590), 4, 14, "Expedita nisi voluptates doloremque id aut. Sapiente doloribus perferendis corporis enim aut. Ex qui ab. Sed excepturi optio aliquam in." },
                    { 132, new DateTime(2021, 7, 31, 13, 9, 24, 814, DateTimeKind.Local).AddTicks(5508), 105, new DateTime(2022, 5, 15, 17, 19, 55, 651, DateTimeKind.Local).AddTicks(3203), new DateTime(2021, 2, 5, 0, 3, 21, 622, DateTimeKind.Local).AddTicks(6308), 5, 98, "Provident cum consequuntur qui sit rerum aliquid. Expedita tempore debitis ducimus adipisci mollitia. Est deleniti nihil quia dicta fugiat non sed iure eligendi." },
                    { 160, new DateTime(2021, 1, 8, 2, 1, 42, 417, DateTimeKind.Local).AddTicks(9641), 135, new DateTime(2022, 3, 31, 23, 36, 32, 632, DateTimeKind.Local).AddTicks(5369), new DateTime(2021, 6, 14, 5, 23, 3, 242, DateTimeKind.Local).AddTicks(2463), 1, 98, "Nobis nesciunt non. Unde consequuntur sit iure quibusdam. Nihil esse sit porro rerum velit ducimus. Laudantium quisquam saepe. Sed quis quia id dolor." },
                    { 105, new DateTime(2021, 6, 30, 5, 3, 3, 124, DateTimeKind.Local).AddTicks(859), 145, new DateTime(2022, 5, 29, 4, 15, 2, 318, DateTimeKind.Local).AddTicks(5108), new DateTime(2020, 12, 16, 1, 46, 36, 72, DateTimeKind.Local).AddTicks(2247), 3, 27, "Non est ut quis." },
                    { 126, new DateTime(2020, 11, 24, 0, 51, 19, 348, DateTimeKind.Local).AddTicks(8244), 116, new DateTime(2022, 3, 31, 12, 45, 7, 327, DateTimeKind.Local).AddTicks(8121), new DateTime(2020, 9, 24, 16, 31, 47, 224, DateTimeKind.Local).AddTicks(9215), 2, 27, "quaerat" },
                    { 136, new DateTime(2021, 5, 6, 10, 28, 38, 34, DateTimeKind.Local).AddTicks(2370), 27, new DateTime(2021, 9, 29, 6, 31, 17, 769, DateTimeKind.Local).AddTicks(81), new DateTime(2020, 12, 7, 4, 7, 37, 853, DateTimeKind.Local).AddTicks(539), 2, 27, "Itaque voluptas quia qui qui sequi atque qui magni. Molestiae aut asperiores ut impedit autem minus fugit adipisci. Error facere ab numquam distinctio commodi. Nobis fugiat voluptatem." },
                    { 14, new DateTime(2020, 9, 4, 0, 40, 48, 929, DateTimeKind.Local).AddTicks(6865), 69, new DateTime(2022, 8, 3, 5, 29, 37, 31, DateTimeKind.Local).AddTicks(4049), new DateTime(2021, 1, 31, 20, 46, 54, 191, DateTimeKind.Local).AddTicks(6856), 2, 57, "Facilis unde et aut voluptatem nihil." },
                    { 37, new DateTime(2020, 11, 1, 20, 41, 28, 88, DateTimeKind.Local).AddTicks(3599), 88, new DateTime(2022, 6, 3, 15, 35, 18, 254, DateTimeKind.Local).AddTicks(2585), new DateTime(2021, 3, 11, 18, 29, 40, 115, DateTimeKind.Local).AddTicks(9633), 4, 57, "quam" },
                    { 59, new DateTime(2020, 11, 18, 19, 48, 53, 874, DateTimeKind.Local).AddTicks(5819), 5, new DateTime(2022, 5, 11, 1, 58, 48, 683, DateTimeKind.Local).AddTicks(7613), new DateTime(2020, 8, 16, 10, 56, 34, 602, DateTimeKind.Local).AddTicks(9493), 2, 57, "voluptatem" },
                    { 23, new DateTime(2021, 6, 14, 3, 15, 2, 404, DateTimeKind.Local).AddTicks(197), 70, new DateTime(2021, 9, 27, 13, 1, 6, 401, DateTimeKind.Local).AddTicks(1984), new DateTime(2021, 5, 1, 21, 11, 49, 50, DateTimeKind.Local).AddTicks(9270), 1, 78, "Accusantium a velit possimus dolores officia esse praesentium. Tempora expedita architecto dolorem nihil nesciunt sed. Nisi est non et unde nobis ut. Sint ipsam hic voluptatem. Ullam voluptatem ratione ab assumenda. Nihil veritatis laudantium veritatis temporibus reprehenderit vitae vero." },
                    { 55, new DateTime(2020, 8, 31, 22, 57, 7, 702, DateTimeKind.Local).AddTicks(5193), 149, new DateTime(2022, 2, 4, 13, 49, 25, 676, DateTimeKind.Local).AddTicks(6091), new DateTime(2021, 1, 12, 14, 17, 10, 633, DateTimeKind.Local).AddTicks(6207), 2, 78, "Aut ut eligendi ea nulla harum ut accusamus aliquid corporis." },
                    { 164, new DateTime(2021, 2, 2, 16, 14, 21, 424, DateTimeKind.Local).AddTicks(2114), 43, new DateTime(2022, 4, 16, 13, 9, 38, 548, DateTimeKind.Local).AddTicks(2553), new DateTime(2021, 2, 22, 5, 24, 42, 222, DateTimeKind.Local).AddTicks(8271), 2, 78, "Rerum officia modi neque rerum odio quia sequi fugit blanditiis. Doloribus praesentium dicta est. Exercitationem dignissimos quia quis sed fugiat labore accusantium." },
                    { 183, new DateTime(2020, 9, 10, 19, 43, 4, 769, DateTimeKind.Local).AddTicks(8202), 22, new DateTime(2022, 5, 16, 1, 27, 51, 798, DateTimeKind.Local).AddTicks(810), new DateTime(2021, 3, 15, 3, 18, 32, 473, DateTimeKind.Local).AddTicks(3489), 5, 78, "Ipsa minima dolores maiores earum recusandae et voluptatibus qui occaecati.\nSimilique accusamus pariatur.\nDolorem odit ex eos qui non.\nAmet sit eum eos qui odio harum necessitatibus nisi." },
                    { 195, new DateTime(2021, 6, 16, 5, 36, 10, 677, DateTimeKind.Local).AddTicks(2476), 150, new DateTime(2022, 5, 2, 17, 18, 11, 534, DateTimeKind.Local).AddTicks(7034), new DateTime(2020, 11, 25, 16, 31, 21, 848, DateTimeKind.Local).AddTicks(7135), 5, 78, "Mollitia est consequatur natus omnis." },
                    { 91, new DateTime(2021, 1, 13, 1, 1, 46, 150, DateTimeKind.Local).AddTicks(9649), 150, new DateTime(2022, 2, 18, 6, 17, 36, 306, DateTimeKind.Local).AddTicks(6096), new DateTime(2021, 2, 7, 10, 42, 57, 125, DateTimeKind.Local).AddTicks(9935), 2, 44, "ex" },
                    { 128, new DateTime(2020, 10, 7, 5, 36, 7, 77, DateTimeKind.Local).AddTicks(15), 111, new DateTime(2021, 11, 11, 23, 42, 19, 739, DateTimeKind.Local).AddTicks(6298), new DateTime(2021, 5, 12, 17, 4, 12, 332, DateTimeKind.Local).AddTicks(5111), 4, 44, "Veritatis tempora ut.\nIpsam doloremque ut ut velit reiciendis est perferendis libero." },
                    { 135, new DateTime(2021, 7, 2, 13, 0, 15, 201, DateTimeKind.Local).AddTicks(3627), 46, new DateTime(2021, 10, 7, 14, 14, 47, 508, DateTimeKind.Local).AddTicks(8748), new DateTime(2021, 6, 26, 1, 6, 35, 243, DateTimeKind.Local).AddTicks(7820), 4, 44, "Fugit aut perspiciatis aut esse." },
                    { 159, new DateTime(2021, 1, 10, 17, 50, 15, 137, DateTimeKind.Local).AddTicks(2530), 83, new DateTime(2021, 11, 9, 9, 6, 31, 254, DateTimeKind.Local).AddTicks(9411), new DateTime(2021, 7, 21, 2, 20, 2, 211, DateTimeKind.Local).AddTicks(4765), 3, 44, "Deserunt laudantium est qui quas.\nSimilique eum et totam magnam." },
                    { 178, new DateTime(2021, 4, 5, 2, 25, 30, 776, DateTimeKind.Local).AddTicks(2544), 68, new DateTime(2022, 8, 2, 2, 27, 15, 274, DateTimeKind.Local).AddTicks(617), new DateTime(2020, 12, 3, 1, 19, 24, 779, DateTimeKind.Local).AddTicks(5006), 4, 44, "dolorem" },
                    { 3, new DateTime(2021, 1, 18, 8, 20, 22, 390, DateTimeKind.Local).AddTicks(9418), 124, new DateTime(2021, 9, 22, 1, 40, 35, 115, DateTimeKind.Local).AddTicks(3298), new DateTime(2021, 4, 2, 4, 27, 39, 80, DateTimeKind.Local).AddTicks(1137), 5, 26, "Adipisci et quia natus rerum." },
                    { 4, new DateTime(2021, 6, 16, 9, 44, 3, 425, DateTimeKind.Local).AddTicks(5641), 4, new DateTime(2021, 9, 16, 9, 58, 59, 768, DateTimeKind.Local).AddTicks(7652), new DateTime(2021, 6, 11, 12, 8, 18, 617, DateTimeKind.Local).AddTicks(6105), 2, 26, "Et voluptas aut et." },
                    { 114, new DateTime(2021, 3, 13, 23, 24, 8, 495, DateTimeKind.Local).AddTicks(5341), 1, new DateTime(2021, 12, 24, 14, 55, 18, 44, DateTimeKind.Local).AddTicks(633), new DateTime(2020, 10, 22, 22, 28, 57, 248, DateTimeKind.Local).AddTicks(1159), 4, 26, "aperiam" },
                    { 158, new DateTime(2021, 5, 16, 7, 53, 58, 135, DateTimeKind.Local).AddTicks(8584), 29, new DateTime(2022, 4, 30, 20, 0, 37, 409, DateTimeKind.Local).AddTicks(4367), new DateTime(2020, 10, 11, 15, 32, 53, 341, DateTimeKind.Local).AddTicks(5409), 4, 26, "Tempore illum non est veniam. Et quisquam molestiae minus libero maxime et omnis nulla quia. Quidem quod quis. Aut maiores ut. Aperiam corporis alias voluptatum. Quia adipisci ut aut laudantium nesciunt neque voluptas quis adipisci." },
                    { 161, new DateTime(2021, 3, 8, 10, 15, 44, 624, DateTimeKind.Local).AddTicks(2168), 89, new DateTime(2022, 1, 28, 0, 53, 8, 817, DateTimeKind.Local).AddTicks(2757), new DateTime(2021, 5, 12, 14, 17, 22, 47, DateTimeKind.Local).AddTicks(9044), 1, 26, "animi" },
                    { 173, new DateTime(2021, 2, 24, 4, 40, 46, 664, DateTimeKind.Local).AddTicks(4804), 118, new DateTime(2021, 10, 16, 23, 32, 32, 393, DateTimeKind.Local).AddTicks(8377), new DateTime(2021, 7, 13, 20, 1, 48, 129, DateTimeKind.Local).AddTicks(6838), 4, 22, "et" },
                    { 137, new DateTime(2021, 1, 12, 0, 26, 26, 62, DateTimeKind.Local).AddTicks(7718), 58, new DateTime(2022, 7, 3, 14, 45, 48, 605, DateTimeKind.Local).AddTicks(9342), new DateTime(2021, 5, 14, 16, 39, 1, 432, DateTimeKind.Local).AddTicks(967), 4, 98, "ipsum" },
                    { 112, new DateTime(2020, 11, 8, 19, 56, 33, 334, DateTimeKind.Local).AddTicks(7198), 70, new DateTime(2022, 6, 22, 12, 1, 17, 317, DateTimeKind.Local).AddTicks(9086), new DateTime(2021, 3, 23, 17, 6, 31, 430, DateTimeKind.Local).AddTicks(858), 5, 22, "Est ad ut qui est.\nEt quibusdam non laudantium soluta minima aut reprehenderit.\nBlanditiis nisi non.\nVoluptate at et accusamus." },
                    { 77, new DateTime(2021, 5, 3, 12, 17, 59, 2, DateTimeKind.Local).AddTicks(5886), 138, new DateTime(2022, 5, 18, 5, 44, 29, 253, DateTimeKind.Local).AddTicks(3535), new DateTime(2020, 9, 13, 5, 5, 45, 421, DateTimeKind.Local).AddTicks(6185), 1, 20, "Deleniti ipsum dolores accusantium qui est." },
                    { 9, new DateTime(2021, 3, 27, 12, 2, 13, 721, DateTimeKind.Local).AddTicks(4116), 53, new DateTime(2022, 1, 20, 20, 2, 25, 32, DateTimeKind.Local).AddTicks(3447), new DateTime(2021, 3, 3, 9, 41, 16, 152, DateTimeKind.Local).AddTicks(4386), 3, 76, "Tempora aut ut ut vero blanditiis tempore. Dolores porro dolore sequi ad iste sed non voluptatem. Cupiditate laboriosam dolores maxime adipisci adipisci." },
                    { 32, new DateTime(2021, 5, 17, 4, 15, 36, 591, DateTimeKind.Local).AddTicks(3344), 117, new DateTime(2022, 1, 25, 18, 56, 47, 824, DateTimeKind.Local).AddTicks(1596), new DateTime(2020, 9, 21, 19, 29, 29, 458, DateTimeKind.Local).AddTicks(7415), 5, 76, "atque" },
                    { 53, new DateTime(2021, 6, 4, 1, 15, 28, 449, DateTimeKind.Local).AddTicks(9679), 137, new DateTime(2021, 9, 22, 10, 0, 21, 170, DateTimeKind.Local).AddTicks(5380), new DateTime(2021, 2, 12, 16, 58, 18, 593, DateTimeKind.Local).AddTicks(7304), 3, 76, "quibusdam" },
                    { 54, new DateTime(2021, 7, 22, 9, 3, 6, 593, DateTimeKind.Local).AddTicks(4970), 22, new DateTime(2021, 12, 15, 15, 54, 57, 513, DateTimeKind.Local).AddTicks(1101), new DateTime(2020, 9, 11, 7, 34, 37, 492, DateTimeKind.Local).AddTicks(8633), 3, 76, "Dolorem optio repellendus qui sit fugiat harum et." },
                    { 74, new DateTime(2021, 3, 11, 9, 17, 2, 56, DateTimeKind.Local).AddTicks(4105), 92, new DateTime(2021, 12, 14, 2, 26, 34, 259, DateTimeKind.Local).AddTicks(9513), new DateTime(2021, 2, 2, 0, 5, 9, 167, DateTimeKind.Local).AddTicks(5668), 3, 76, "Tenetur dolorem est dignissimos ipsa qui totam voluptatum.\nRerum officiis repellat qui quae amet ducimus consequatur." },
                    { 148, new DateTime(2021, 4, 13, 4, 31, 3, 733, DateTimeKind.Local).AddTicks(5791), 25, new DateTime(2022, 2, 22, 2, 52, 36, 787, DateTimeKind.Local).AddTicks(3454), new DateTime(2020, 9, 5, 16, 28, 32, 148, DateTimeKind.Local).AddTicks(4650), 1, 76, "non" },
                    { 176, new DateTime(2020, 10, 17, 9, 15, 48, 501, DateTimeKind.Local).AddTicks(880), 60, new DateTime(2021, 12, 12, 6, 55, 22, 530, DateTimeKind.Local).AddTicks(2150), new DateTime(2021, 1, 22, 3, 59, 14, 262, DateTimeKind.Local).AddTicks(7679), 5, 76, "Molestiae itaque assumenda quam architecto architecto odio. Quam tempora modi dolor molestiae tempora vero. Officia iusto dolorem adipisci illum tenetur. Modi fuga quibusdam voluptatem placeat et. Similique necessitatibus et." },
                    { 85, new DateTime(2020, 8, 19, 0, 47, 41, 209, DateTimeKind.Local).AddTicks(2470), 44, new DateTime(2021, 8, 17, 2, 24, 12, 785, DateTimeKind.Local).AddTicks(5242), new DateTime(2020, 12, 31, 13, 32, 19, 93, DateTimeKind.Local).AddTicks(761), 2, 13, "Qui earum nostrum maxime." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 31, new DateTime(2021, 3, 18, 20, 53, 28, 241, DateTimeKind.Local).AddTicks(8613), 119, new DateTime(2021, 12, 15, 23, 28, 43, 441, DateTimeKind.Local).AddTicks(314), new DateTime(2021, 2, 28, 9, 2, 38, 706, DateTimeKind.Local).AddTicks(1684), 1, 84, "Officia consequuntur et eum eum consequatur iste illum sint et." },
                    { 69, new DateTime(2021, 8, 6, 12, 34, 38, 162, DateTimeKind.Local).AddTicks(8804), 21, new DateTime(2022, 3, 10, 21, 36, 54, 477, DateTimeKind.Local).AddTicks(3882), new DateTime(2020, 8, 23, 17, 21, 26, 768, DateTimeKind.Local).AddTicks(8463), 5, 84, "Explicabo porro illum quo." },
                    { 165, new DateTime(2021, 4, 7, 0, 8, 38, 273, DateTimeKind.Local).AddTicks(6827), 26, new DateTime(2022, 4, 3, 0, 43, 51, 684, DateTimeKind.Local).AddTicks(3929), new DateTime(2021, 6, 1, 1, 35, 8, 26, DateTimeKind.Local).AddTicks(2664), 1, 64, "Est molestiae deleniti tenetur officiis. Est sint dolore incidunt ut reiciendis. Delectus modi sequi. Veritatis dolor sint vero quod fugit." },
                    { 110, new DateTime(2021, 8, 8, 3, 53, 16, 817, DateTimeKind.Local).AddTicks(8708), 93, new DateTime(2022, 7, 27, 20, 9, 59, 935, DateTimeKind.Local).AddTicks(1192), new DateTime(2020, 8, 26, 0, 36, 12, 157, DateTimeKind.Local).AddTicks(5636), 2, 8, "Eos vel dignissimos.\nSequi officia sit tenetur beatae rerum." },
                    { 113, new DateTime(2021, 4, 18, 9, 22, 0, 473, DateTimeKind.Local).AddTicks(9719), 142, new DateTime(2022, 4, 12, 10, 42, 16, 598, DateTimeKind.Local).AddTicks(2072), new DateTime(2020, 9, 30, 22, 13, 17, 57, DateTimeKind.Local).AddTicks(269), 5, 8, "Ea qui ex soluta est reiciendis non.\nOptio sapiente dolore porro optio qui cumque natus maxime.\nDignissimos et nisi eos.\nVoluptatibus ea non facere eum tempora." },
                    { 140, new DateTime(2021, 3, 14, 21, 44, 2, 750, DateTimeKind.Local).AddTicks(2133), 58, new DateTime(2021, 12, 27, 19, 34, 41, 42, DateTimeKind.Local).AddTicks(9269), new DateTime(2021, 2, 27, 5, 42, 28, 239, DateTimeKind.Local).AddTicks(5501), 5, 8, "Voluptas sunt explicabo." },
                    { 146, new DateTime(2020, 11, 26, 7, 53, 22, 536, DateTimeKind.Local).AddTicks(3563), 108, new DateTime(2022, 4, 1, 4, 50, 17, 410, DateTimeKind.Local).AddTicks(5838), new DateTime(2020, 9, 23, 11, 14, 8, 334, DateTimeKind.Local).AddTicks(9581), 3, 8, "Ut ipsa similique et itaque repudiandae porro eos. Voluptatem et dolorum nesciunt ipsa sed qui. Et nisi dolor odit qui architecto quam molestiae. Ipsa officia ipsum." },
                    { 184, new DateTime(2021, 7, 7, 3, 37, 3, 270, DateTimeKind.Local).AddTicks(2767), 98, new DateTime(2022, 5, 24, 3, 59, 52, 258, DateTimeKind.Local).AddTicks(9529), new DateTime(2021, 7, 31, 4, 33, 49, 445, DateTimeKind.Local).AddTicks(8106), 2, 8, "Perspiciatis et distinctio quam ad delectus soluta fuga laborum ab." },
                    { 117, new DateTime(2021, 1, 7, 2, 54, 32, 544, DateTimeKind.Local).AddTicks(5300), 113, new DateTime(2021, 9, 14, 20, 49, 31, 90, DateTimeKind.Local).AddTicks(3146), new DateTime(2021, 6, 16, 12, 48, 55, 537, DateTimeKind.Local).AddTicks(3913), 5, 77, "recusandae" },
                    { 7, new DateTime(2020, 12, 17, 23, 9, 46, 348, DateTimeKind.Local).AddTicks(5848), 105, new DateTime(2021, 11, 15, 21, 19, 58, 966, DateTimeKind.Local).AddTicks(4522), new DateTime(2021, 1, 28, 15, 21, 8, 441, DateTimeKind.Local).AddTicks(1797), 4, 35, "Voluptatum repellendus modi aliquid." },
                    { 20, new DateTime(2020, 8, 17, 9, 2, 44, 521, DateTimeKind.Local).AddTicks(3786), 110, new DateTime(2021, 11, 6, 18, 56, 6, 753, DateTimeKind.Local).AddTicks(8793), new DateTime(2021, 1, 16, 20, 53, 0, 109, DateTimeKind.Local).AddTicks(4432), 2, 35, "Est inventore quia rerum ducimus doloribus nisi sequi possimus debitis.\nAutem aut doloribus enim doloremque velit suscipit.\nAnimi est iste eos.\nQuia ea et voluptatum libero qui ab dolor molestias quia." },
                    { 179, new DateTime(2020, 10, 26, 5, 35, 50, 469, DateTimeKind.Local).AddTicks(7970), 150, new DateTime(2022, 5, 11, 20, 13, 41, 487, DateTimeKind.Local).AddTicks(5346), new DateTime(2020, 12, 30, 22, 13, 23, 879, DateTimeKind.Local).AddTicks(4379), 1, 35, "Est veniam quis expedita sit consequuntur est libero cupiditate sunt." },
                    { 187, new DateTime(2020, 10, 22, 22, 47, 26, 987, DateTimeKind.Local).AddTicks(9512), 47, new DateTime(2021, 10, 31, 7, 50, 0, 923, DateTimeKind.Local).AddTicks(8078), new DateTime(2021, 4, 9, 22, 58, 13, 761, DateTimeKind.Local).AddTicks(4321), 1, 35, "quia" },
                    { 108, new DateTime(2021, 1, 6, 15, 6, 53, 61, DateTimeKind.Local).AddTicks(187), 72, new DateTime(2022, 4, 6, 14, 53, 8, 86, DateTimeKind.Local).AddTicks(2167), new DateTime(2021, 6, 24, 4, 5, 12, 787, DateTimeKind.Local).AddTicks(3828), 5, 22, "consequatur" },
                    { 144, new DateTime(2021, 1, 20, 16, 49, 46, 517, DateTimeKind.Local).AddTicks(4352), 12, new DateTime(2021, 11, 30, 5, 50, 57, 267, DateTimeKind.Local).AddTicks(133), new DateTime(2021, 3, 17, 12, 7, 37, 142, DateTimeKind.Local).AddTicks(6694), 5, 54, "Cumque est tempora." },
                    { 120, new DateTime(2021, 5, 25, 14, 42, 46, 551, DateTimeKind.Local).AddTicks(4737), 92, new DateTime(2021, 11, 20, 18, 54, 46, 522, DateTimeKind.Local).AddTicks(580), new DateTime(2021, 4, 14, 18, 35, 19, 674, DateTimeKind.Local).AddTicks(4322), 2, 54, "Autem molestiae aperiam hic eveniet adipisci sequi.\nRem quos et atque cupiditate sit.\nNon sapiente blanditiis." },
                    { 78, new DateTime(2021, 4, 8, 14, 56, 14, 517, DateTimeKind.Local).AddTicks(1888), 83, new DateTime(2022, 1, 23, 10, 22, 42, 486, DateTimeKind.Local).AddTicks(3090), new DateTime(2021, 2, 12, 0, 33, 58, 434, DateTimeKind.Local).AddTicks(2778), 3, 54, "Cupiditate sint illo sequi rerum maxime sit vitae modi aut." },
                    { 13, new DateTime(2020, 11, 28, 20, 5, 8, 559, DateTimeKind.Local).AddTicks(6104), 118, new DateTime(2022, 4, 6, 10, 49, 59, 439, DateTimeKind.Local).AddTicks(4228), new DateTime(2021, 2, 24, 16, 4, 28, 838, DateTimeKind.Local).AddTicks(2678), 1, 21, "Voluptate debitis et magni qui voluptas. Excepturi commodi ut dolores dignissimos commodi. Deleniti ut optio libero laboriosam voluptatum quod fugiat." },
                    { 25, new DateTime(2021, 7, 16, 0, 55, 41, 402, DateTimeKind.Local).AddTicks(7741), 70, new DateTime(2021, 11, 3, 12, 56, 6, 750, DateTimeKind.Local).AddTicks(1155), new DateTime(2020, 11, 7, 10, 49, 31, 232, DateTimeKind.Local).AddTicks(1460), 3, 21, "dolores" },
                    { 200, new DateTime(2021, 2, 23, 23, 27, 56, 515, DateTimeKind.Local).AddTicks(3629), 116, new DateTime(2022, 3, 23, 9, 21, 20, 222, DateTimeKind.Local).AddTicks(5288), new DateTime(2021, 5, 29, 11, 22, 46, 726, DateTimeKind.Local).AddTicks(1990), 3, 21, "Est voluptatum minus fugit voluptatum vel excepturi consequatur ea vel. Mollitia voluptatem dolorum accusamus debitis sed. Sit eligendi architecto ex blanditiis voluptates. Asperiores autem voluptatem accusantium eum et. Occaecati omnis nobis quam minus. Sunt et veritatis voluptatem et ducimus." },
                    { 104, new DateTime(2020, 10, 7, 6, 37, 0, 639, DateTimeKind.Local).AddTicks(7449), 19, new DateTime(2021, 10, 6, 8, 25, 22, 771, DateTimeKind.Local).AddTicks(3314), new DateTime(2021, 6, 27, 1, 33, 13, 923, DateTimeKind.Local).AddTicks(4334), 2, 7, "Blanditiis et odit deleniti in qui tenetur." },
                    { 43, new DateTime(2020, 10, 8, 21, 46, 15, 134, DateTimeKind.Local).AddTicks(3511), 27, new DateTime(2022, 4, 19, 9, 46, 54, 961, DateTimeKind.Local).AddTicks(6384), new DateTime(2021, 1, 5, 1, 29, 38, 425, DateTimeKind.Local).AddTicks(3289), 2, 96, "repellat" },
                    { 46, new DateTime(2021, 6, 19, 6, 34, 28, 405, DateTimeKind.Local).AddTicks(3265), 127, new DateTime(2022, 6, 6, 7, 39, 15, 475, DateTimeKind.Local).AddTicks(4172), new DateTime(2020, 9, 30, 11, 9, 32, 474, DateTimeKind.Local).AddTicks(2969), 3, 96, "Occaecati recusandae ut nihil est dolorem et." },
                    { 49, new DateTime(2020, 8, 19, 10, 59, 34, 76, DateTimeKind.Local).AddTicks(2454), 8, new DateTime(2022, 8, 9, 2, 54, 37, 6, DateTimeKind.Local).AddTicks(9428), new DateTime(2021, 6, 16, 22, 49, 38, 675, DateTimeKind.Local).AddTicks(1121), 5, 96, "Aut quasi at magni sapiente nostrum rerum fuga est." },
                    { 28, new DateTime(2020, 9, 19, 14, 45, 34, 612, DateTimeKind.Local).AddTicks(3677), 67, new DateTime(2022, 3, 6, 10, 29, 2, 529, DateTimeKind.Local).AddTicks(441), new DateTime(2021, 1, 15, 6, 33, 20, 813, DateTimeKind.Local).AddTicks(3458), 4, 23, "Maiores fugiat repellat et possimus illum deserunt harum." },
                    { 199, new DateTime(2020, 9, 29, 1, 27, 19, 735, DateTimeKind.Local).AddTicks(2034), 51, new DateTime(2021, 10, 11, 2, 25, 23, 610, DateTimeKind.Local).AddTicks(9410), new DateTime(2021, 3, 22, 16, 38, 41, 411, DateTimeKind.Local).AddTicks(7593), 1, 23, "Laudantium iste ab laborum sunt eum totam quaerat rerum aut." },
                    { 100, new DateTime(2021, 4, 22, 4, 42, 40, 179, DateTimeKind.Local).AddTicks(1870), 130, new DateTime(2022, 5, 19, 11, 27, 6, 523, DateTimeKind.Local).AddTicks(5808), new DateTime(2020, 12, 16, 1, 32, 52, 943, DateTimeKind.Local).AddTicks(1820), 5, 63, "Dignissimos inventore aut." },
                    { 102, new DateTime(2020, 10, 27, 13, 48, 10, 359, DateTimeKind.Local).AddTicks(7740), 118, new DateTime(2022, 1, 17, 7, 3, 0, 757, DateTimeKind.Local).AddTicks(8072), new DateTime(2020, 10, 23, 8, 20, 40, 915, DateTimeKind.Local).AddTicks(8744), 5, 63, "Quo et aut velit aut. Eius qui est odit dolor ab quia earum. Repellendus praesentium eos et aut alias dolorem. Odit dignissimos at eum sunt ad dolores nesciunt deserunt quaerat. Totam alias aut qui est dolore vitae qui animi. Impedit rerum et." },
                    { 73, new DateTime(2021, 7, 4, 5, 44, 1, 931, DateTimeKind.Local).AddTicks(1723), 120, new DateTime(2021, 9, 25, 10, 5, 42, 913, DateTimeKind.Local).AddTicks(7739), new DateTime(2020, 12, 8, 21, 58, 1, 28, DateTimeKind.Local).AddTicks(4683), 2, 18, "Modi vel inventore et sed et saepe corporis aperiam maiores.\nVelit accusantium ut voluptas repudiandae iure quia aut quo." },
                    { 15, new DateTime(2021, 1, 23, 20, 9, 42, 537, DateTimeKind.Local).AddTicks(9756), 29, new DateTime(2021, 10, 20, 11, 2, 6, 400, DateTimeKind.Local).AddTicks(1635), new DateTime(2021, 7, 5, 6, 13, 50, 472, DateTimeKind.Local).AddTicks(1985), 5, 55, "atque" },
                    { 18, new DateTime(2021, 7, 4, 14, 59, 30, 675, DateTimeKind.Local).AddTicks(1067), 62, new DateTime(2022, 3, 29, 18, 3, 16, 751, DateTimeKind.Local).AddTicks(8619), new DateTime(2020, 12, 8, 9, 31, 7, 976, DateTimeKind.Local).AddTicks(9396), 5, 55, "Delectus laboriosam doloribus tenetur corrupti itaque aliquid ea.\nOfficia ea deleniti et ex fugiat rerum aut nihil sed.\nEveniet iusto dicta minima iusto rerum a distinctio.\nEst facilis repudiandae quos enim.\nBeatae omnis ullam ab." },
                    { 44, new DateTime(2021, 3, 30, 11, 47, 6, 133, DateTimeKind.Local).AddTicks(4119), 12, new DateTime(2022, 3, 24, 1, 11, 23, 40, DateTimeKind.Local).AddTicks(6304), new DateTime(2021, 2, 21, 0, 37, 28, 84, DateTimeKind.Local).AddTicks(1342), 2, 55, "Qui nam similique eius mollitia sit officiis repellendus cupiditate tempora.\nFacere labore officia fugit id ad.\nEst facere repellat numquam.\nQuis nemo aut." },
                    { 154, new DateTime(2021, 8, 6, 22, 38, 11, 740, DateTimeKind.Local).AddTicks(2475), 125, new DateTime(2021, 11, 27, 12, 42, 8, 541, DateTimeKind.Local).AddTicks(9012), new DateTime(2021, 1, 27, 13, 17, 2, 117, DateTimeKind.Local).AddTicks(8716), 3, 55, "Sunt eos ea tenetur recusandae illo expedita impedit iste. Repudiandae est laudantium suscipit et accusamus sed fugit illum. Maxime officia maxime nobis qui." },
                    { 170, new DateTime(2020, 12, 14, 15, 42, 24, 712, DateTimeKind.Local).AddTicks(198), 73, new DateTime(2022, 1, 5, 16, 51, 13, 888, DateTimeKind.Local).AddTicks(8245), new DateTime(2020, 12, 21, 22, 45, 29, 279, DateTimeKind.Local).AddTicks(6782), 1, 55, "Est sed et ea consectetur architecto suscipit porro architecto.\nQuo molestiae quo explicabo tempore adipisci voluptates.\nRerum quia in.\nPerspiciatis sit quaerat porro ipsam.\nVel est quas." },
                    { 192, new DateTime(2020, 12, 3, 19, 42, 59, 635, DateTimeKind.Local).AddTicks(3742), 34, new DateTime(2021, 9, 13, 15, 30, 37, 836, DateTimeKind.Local).AddTicks(4707), new DateTime(2021, 5, 19, 7, 3, 7, 491, DateTimeKind.Local).AddTicks(6214), 5, 55, "voluptates" },
                    { 29, new DateTime(2021, 4, 19, 10, 35, 42, 653, DateTimeKind.Local).AddTicks(7248), 70, new DateTime(2022, 3, 1, 9, 28, 11, 612, DateTimeKind.Local).AddTicks(509), new DateTime(2021, 3, 26, 0, 45, 54, 853, DateTimeKind.Local).AddTicks(8237), 5, 5, "Ab ducimus iste ad alias et officiis eum. Maiores repellendus beatae vitae expedita. Ipsa officiis in adipisci quia quo tenetur sapiente." },
                    { 194, new DateTime(2021, 5, 6, 14, 26, 26, 308, DateTimeKind.Local).AddTicks(4205), 60, new DateTime(2021, 10, 24, 5, 11, 56, 98, DateTimeKind.Local).AddTicks(9263), new DateTime(2021, 7, 15, 8, 49, 46, 566, DateTimeKind.Local).AddTicks(4388), 1, 5, "nihil" },
                    { 51, new DateTime(2021, 2, 17, 14, 3, 23, 917, DateTimeKind.Local).AddTicks(3506), 147, new DateTime(2021, 9, 25, 15, 22, 2, 575, DateTimeKind.Local).AddTicks(3274), new DateTime(2020, 12, 9, 9, 47, 11, 59, DateTimeKind.Local).AddTicks(4701), 3, 58, "Tempore ipsam molestiae aut amet placeat commodi quia facere. Asperiores ea ex est sed et illum ex voluptas ea. Aut dolor dolorem fugiat odit nesciunt. Natus earum sed omnis et consequuntur." },
                    { 197, new DateTime(2021, 5, 5, 23, 6, 34, 848, DateTimeKind.Local).AddTicks(4167), 137, new DateTime(2022, 3, 12, 4, 9, 58, 935, DateTimeKind.Local).AddTicks(7689), new DateTime(2020, 8, 13, 7, 35, 28, 327, DateTimeKind.Local).AddTicks(6386), 5, 39, "Aut velit ut ut in et corporis. Est expedita aut. Impedit molestias rerum. Molestias ab dicta doloribus aut reprehenderit laborum." },
                    { 33, new DateTime(2021, 2, 11, 14, 16, 20, 786, DateTimeKind.Local).AddTicks(9282), 30, new DateTime(2022, 3, 21, 16, 38, 14, 515, DateTimeKind.Local).AddTicks(75), new DateTime(2021, 3, 13, 6, 35, 17, 384, DateTimeKind.Local).AddTicks(5614), 3, 94, "Totam dolores delectus quo ea nostrum." },
                    { 157, new DateTime(2021, 6, 30, 23, 59, 26, 650, DateTimeKind.Local).AddTicks(351), 138, new DateTime(2021, 9, 30, 7, 39, 54, 194, DateTimeKind.Local).AddTicks(7466), new DateTime(2020, 12, 10, 1, 34, 5, 665, DateTimeKind.Local).AddTicks(9476), 2, 39, "quas" },
                    { 133, new DateTime(2020, 9, 22, 21, 9, 31, 380, DateTimeKind.Local).AddTicks(8821), 21, new DateTime(2022, 6, 19, 2, 41, 50, 504, DateTimeKind.Local).AddTicks(5689), new DateTime(2021, 4, 10, 11, 21, 1, 964, DateTimeKind.Local).AddTicks(600), 2, 39, "Sed quia est." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 97, new DateTime(2021, 7, 8, 17, 49, 7, 311, DateTimeKind.Local).AddTicks(6886), 28, new DateTime(2022, 3, 14, 11, 27, 40, 952, DateTimeKind.Local).AddTicks(8977), new DateTime(2021, 7, 31, 15, 6, 43, 496, DateTimeKind.Local).AddTicks(8651), 4, 29, "Praesentium reiciendis dolorem maxime tempora totam et molestiae officiis unde.\nVoluptatem hic voluptas." },
                    { 45, new DateTime(2021, 2, 11, 15, 10, 14, 64, DateTimeKind.Local).AddTicks(7114), 54, new DateTime(2021, 12, 25, 17, 44, 24, 490, DateTimeKind.Local).AddTicks(1434), new DateTime(2021, 7, 22, 10, 39, 26, 969, DateTimeKind.Local).AddTicks(4883), 1, 92, "Voluptatem odit quo.\nEum non sit reprehenderit aut temporibus dolore id perferendis.\nIn tempore veritatis temporibus placeat delectus quis.\nMinima voluptates fuga sapiente in quia ducimus omnis.\nEt nemo excepturi autem.\nNatus ea eveniet ut reiciendis qui recusandae." },
                    { 57, new DateTime(2021, 5, 13, 15, 11, 34, 149, DateTimeKind.Local).AddTicks(5956), 102, new DateTime(2021, 12, 1, 12, 45, 38, 310, DateTimeKind.Local).AddTicks(3845), new DateTime(2021, 6, 6, 2, 4, 9, 789, DateTimeKind.Local).AddTicks(9397), 4, 92, "Dolore error iure voluptatem nemo labore totam." },
                    { 62, new DateTime(2021, 2, 24, 10, 41, 12, 34, DateTimeKind.Local).AddTicks(1297), 54, new DateTime(2022, 4, 17, 7, 12, 51, 189, DateTimeKind.Local).AddTicks(8834), new DateTime(2021, 5, 7, 20, 52, 51, 501, DateTimeKind.Local).AddTicks(1932), 4, 92, "Aut quia occaecati adipisci natus est quia. Dolor dolor recusandae aperiam consequatur totam. Cumque et dicta ad animi exercitationem. Dolor optio nobis quod." },
                    { 180, new DateTime(2021, 7, 15, 5, 7, 35, 305, DateTimeKind.Local).AddTicks(2630), 140, new DateTime(2021, 10, 22, 15, 28, 19, 725, DateTimeKind.Local).AddTicks(7593), new DateTime(2021, 4, 4, 23, 0, 58, 310, DateTimeKind.Local).AddTicks(7885), 1, 92, "Pariatur repellat illo aspernatur ut.\nEt ullam consequuntur qui aut at repellat.\nDolores molestias aperiam perspiciatis veniam autem sit.\nAtque ipsum illo maiores voluptate." },
                    { 193, new DateTime(2021, 7, 6, 1, 38, 44, 625, DateTimeKind.Local).AddTicks(7403), 7, new DateTime(2021, 11, 4, 9, 23, 28, 789, DateTimeKind.Local).AddTicks(567), new DateTime(2021, 4, 20, 6, 35, 2, 764, DateTimeKind.Local).AddTicks(6467), 5, 92, "Sequi aut corporis soluta et aut quibusdam eligendi vel.\nAut magnam rerum aperiam ut veritatis." },
                    { 27, new DateTime(2021, 4, 12, 10, 48, 13, 941, DateTimeKind.Local).AddTicks(4483), 128, new DateTime(2022, 5, 15, 12, 25, 14, 881, DateTimeKind.Local).AddTicks(4769), new DateTime(2021, 4, 25, 18, 14, 48, 394, DateTimeKind.Local).AddTicks(9619), 4, 88, "Dolor voluptates perferendis ducimus eaque harum quam quam." },
                    { 58, new DateTime(2020, 9, 22, 3, 13, 11, 517, DateTimeKind.Local).AddTicks(5995), 82, new DateTime(2022, 6, 29, 7, 13, 26, 501, DateTimeKind.Local).AddTicks(5828), new DateTime(2021, 4, 19, 20, 8, 0, 254, DateTimeKind.Local).AddTicks(332), 4, 88, "Laudantium molestias omnis sed delectus." },
                    { 188, new DateTime(2021, 7, 11, 0, 27, 46, 620, DateTimeKind.Local).AddTicks(7326), 18, new DateTime(2022, 5, 11, 7, 15, 23, 372, DateTimeKind.Local).AddTicks(3021), new DateTime(2021, 1, 24, 7, 39, 20, 998, DateTimeKind.Local).AddTicks(9433), 2, 97, "Et molestiae repudiandae quia nemo sit voluptatem. Dolorem dolor et consequatur quo dicta. Qui architecto et sint vero impedit autem saepe aut. Nam aut placeat error voluptates vel mollitia fuga. Numquam sapiente dolorum facilis aliquam earum qui molestiae." },
                    { 66, new DateTime(2021, 2, 13, 4, 59, 13, 187, DateTimeKind.Local).AddTicks(179), 5, new DateTime(2021, 8, 16, 2, 51, 32, 608, DateTimeKind.Local).AddTicks(2520), new DateTime(2020, 10, 14, 3, 15, 29, 697, DateTimeKind.Local).AddTicks(970), 5, 62, "Molestias qui sit itaque assumenda dolorem debitis magnam aut." },
                    { 87, new DateTime(2021, 3, 12, 9, 10, 42, 493, DateTimeKind.Local).AddTicks(6158), 67, new DateTime(2022, 3, 7, 23, 26, 39, 928, DateTimeKind.Local).AddTicks(2146), new DateTime(2020, 12, 9, 13, 42, 12, 290, DateTimeKind.Local).AddTicks(2422), 5, 62, "Molestiae et distinctio et cum adipisci sit sit consequuntur delectus. Aut iusto mollitia numquam quis dolore nobis cum. Voluptates id dolores quidem et dolorum repellat quis modi velit. Dolor praesentium quis expedita. Et qui nemo. Asperiores aut et consequatur voluptas omnis." },
                    { 89, new DateTime(2021, 1, 31, 15, 54, 20, 15, DateTimeKind.Local).AddTicks(3131), 41, new DateTime(2021, 9, 30, 14, 23, 7, 298, DateTimeKind.Local).AddTicks(5090), new DateTime(2021, 3, 15, 23, 29, 39, 325, DateTimeKind.Local).AddTicks(3646), 2, 62, "Aliquam maiores aut ut consequuntur nemo.\nVelit quia aut est.\nNeque sint dolores labore suscipit officia id cumque.\nEius ut eos aliquid." },
                    { 171, new DateTime(2021, 7, 8, 19, 40, 10, 939, DateTimeKind.Local).AddTicks(5497), 33, new DateTime(2022, 3, 8, 8, 7, 43, 688, DateTimeKind.Local).AddTicks(6867), new DateTime(2020, 9, 12, 12, 12, 0, 365, DateTimeKind.Local).AddTicks(5404), 3, 62, "Esse deserunt beatae soluta cum." },
                    { 22, new DateTime(2020, 8, 31, 8, 4, 41, 455, DateTimeKind.Local).AddTicks(3115), 102, new DateTime(2022, 8, 5, 22, 54, 48, 733, DateTimeKind.Local).AddTicks(2287), new DateTime(2021, 6, 11, 23, 34, 41, 379, DateTimeKind.Local).AddTicks(4742), 3, 28, "Autem eum earum quaerat dolores sint non assumenda dicta.\nAccusamus corrupti recusandae dolorem est et rerum.\nCumque autem nobis.\nIllum mollitia est quia at distinctio vitae illum ex." },
                    { 103, new DateTime(2021, 7, 30, 6, 12, 58, 446, DateTimeKind.Local).AddTicks(5047), 53, new DateTime(2022, 6, 16, 21, 52, 12, 290, DateTimeKind.Local).AddTicks(6575), new DateTime(2021, 4, 30, 14, 58, 44, 78, DateTimeKind.Local).AddTicks(3540), 4, 28, "Omnis omnis ut. At consequuntur perspiciatis rem hic. Temporibus quis rem sunt et aut corrupti. Quibusdam est modi autem qui iste velit." },
                    { 115, new DateTime(2021, 5, 8, 3, 37, 24, 583, DateTimeKind.Local).AddTicks(3433), 50, new DateTime(2022, 2, 20, 1, 56, 41, 957, DateTimeKind.Local).AddTicks(2588), new DateTime(2021, 1, 24, 1, 35, 46, 406, DateTimeKind.Local).AddTicks(7948), 1, 28, "Veritatis dolore nesciunt ut. Minus odit dolorum tempora ut exercitationem quis. Odio tempora optio error autem. Qui est qui." },
                    { 63, new DateTime(2020, 12, 22, 14, 53, 31, 908, DateTimeKind.Local).AddTicks(6973), 104, new DateTime(2022, 4, 15, 5, 47, 51, 683, DateTimeKind.Local).AddTicks(4136), new DateTime(2021, 3, 29, 4, 5, 46, 858, DateTimeKind.Local).AddTicks(109), 4, 16, "officiis" },
                    { 65, new DateTime(2021, 2, 11, 0, 47, 14, 686, DateTimeKind.Local).AddTicks(7471), 128, new DateTime(2022, 3, 8, 18, 51, 48, 612, DateTimeKind.Local).AddTicks(8347), new DateTime(2021, 1, 5, 2, 15, 17, 284, DateTimeKind.Local).AddTicks(893), 5, 16, "molestiae" },
                    { 167, new DateTime(2020, 9, 14, 15, 3, 38, 644, DateTimeKind.Local).AddTicks(9203), 114, new DateTime(2021, 9, 29, 20, 31, 27, 278, DateTimeKind.Local).AddTicks(5432), new DateTime(2021, 4, 19, 18, 58, 49, 691, DateTimeKind.Local).AddTicks(3434), 2, 16, "Blanditiis magni aliquid dolor et eveniet praesentium." },
                    { 181, new DateTime(2020, 10, 15, 2, 0, 21, 775, DateTimeKind.Local).AddTicks(2171), 97, new DateTime(2021, 9, 12, 23, 2, 31, 129, DateTimeKind.Local).AddTicks(1713), new DateTime(2021, 2, 18, 14, 52, 35, 671, DateTimeKind.Local).AddTicks(2984), 4, 16, "Non quidem amet aut fugit ut." },
                    { 35, new DateTime(2020, 11, 18, 5, 46, 50, 803, DateTimeKind.Local).AddTicks(8959), 116, new DateTime(2022, 5, 4, 7, 42, 30, 399, DateTimeKind.Local).AddTicks(9780), new DateTime(2021, 7, 7, 23, 9, 55, 573, DateTimeKind.Local).AddTicks(2153), 3, 39, "cupiditate" },
                    { 153, new DateTime(2021, 6, 17, 7, 17, 3, 845, DateTimeKind.Local).AddTicks(266), 144, new DateTime(2021, 9, 13, 11, 21, 35, 458, DateTimeKind.Local).AddTicks(2364), new DateTime(2020, 10, 15, 22, 27, 52, 236, DateTimeKind.Local).AddTicks(6296), 4, 39, "Adipisci repellendus in sunt ab cumque." },
                    { 42, new DateTime(2021, 3, 30, 4, 39, 12, 579, DateTimeKind.Local).AddTicks(3101), 121, new DateTime(2021, 9, 12, 18, 1, 45, 200, DateTimeKind.Local).AddTicks(2085), new DateTime(2021, 6, 15, 22, 42, 13, 640, DateTimeKind.Local).AddTicks(7403), 2, 94, "Doloremque in unde eos ad.\nDolores dolore aspernatur minima sed unde aut quo et magni.\nNon corporis illum aut nesciunt.\nVoluptatem repudiandae dolorem amet saepe distinctio maiores tempore non." },
                    { 186, new DateTime(2021, 1, 19, 2, 12, 34, 961, DateTimeKind.Local).AddTicks(7816), 61, new DateTime(2021, 11, 28, 18, 57, 24, 877, DateTimeKind.Local).AddTicks(1641), new DateTime(2021, 5, 4, 20, 33, 30, 464, DateTimeKind.Local).AddTicks(7217), 4, 94, "Sequi fugit impedit dolorum. Dolorem rem ipsam delectus. In repudiandae consequatur voluptatem labore sed reprehenderit provident at." },
                    { 190, new DateTime(2021, 8, 5, 0, 56, 39, 858, DateTimeKind.Local).AddTicks(282), 95, new DateTime(2021, 10, 22, 10, 8, 39, 83, DateTimeKind.Local).AddTicks(7184), new DateTime(2021, 3, 15, 19, 29, 21, 840, DateTimeKind.Local).AddTicks(1783), 5, 94, "Quo eum odit accusamus eos. Molestiae ea aut porro. Cumque nisi ut officia cumque porro ex beatae dolores. Id a non aut molestiae. Eos laborum qui quod aut quia amet et. Vero iure provident veniam voluptatibus quia aut hic." },
                    { 152, new DateTime(2021, 7, 6, 23, 38, 42, 87, DateTimeKind.Local).AddTicks(5015), 2, new DateTime(2022, 5, 23, 2, 42, 42, 867, DateTimeKind.Local).AddTicks(8981), new DateTime(2020, 11, 24, 23, 1, 30, 340, DateTimeKind.Local).AddTicks(9275), 1, 24, "sed" },
                    { 162, new DateTime(2021, 7, 9, 12, 18, 39, 427, DateTimeKind.Local).AddTicks(8821), 61, new DateTime(2022, 6, 14, 5, 3, 48, 509, DateTimeKind.Local).AddTicks(2430), new DateTime(2021, 7, 27, 3, 43, 37, 273, DateTimeKind.Local).AddTicks(3765), 2, 24, "aperiam" },
                    { 166, new DateTime(2020, 11, 24, 3, 53, 3, 282, DateTimeKind.Local).AddTicks(739), 91, new DateTime(2022, 7, 27, 16, 30, 32, 179, DateTimeKind.Local).AddTicks(6173), new DateTime(2020, 11, 4, 12, 4, 32, 578, DateTimeKind.Local).AddTicks(9886), 1, 24, "Facilis maxime tempore consequatur distinctio dolorem omnis nihil maiores." },
                    { 169, new DateTime(2021, 5, 1, 18, 24, 49, 210, DateTimeKind.Local).AddTicks(8725), 115, new DateTime(2022, 1, 11, 10, 21, 33, 455, DateTimeKind.Local).AddTicks(6450), new DateTime(2021, 4, 21, 13, 53, 50, 585, DateTimeKind.Local).AddTicks(3154), 1, 24, "Repellat fuga sed sunt tenetur distinctio labore. Labore aliquam eius hic porro blanditiis. Molestiae autem facere voluptatem recusandae nisi." },
                    { 10, new DateTime(2020, 10, 11, 8, 39, 40, 696, DateTimeKind.Local).AddTicks(5693), 141, new DateTime(2022, 7, 26, 0, 52, 54, 455, DateTimeKind.Local).AddTicks(9504), new DateTime(2021, 6, 2, 19, 23, 23, 569, DateTimeKind.Local).AddTicks(4546), 3, 50, "mollitia" },
                    { 17, new DateTime(2020, 8, 25, 16, 58, 4, 402, DateTimeKind.Local).AddTicks(9636), 121, new DateTime(2022, 7, 20, 22, 50, 37, 991, DateTimeKind.Local).AddTicks(7996), new DateTime(2021, 1, 11, 2, 18, 49, 10, DateTimeKind.Local).AddTicks(4331), 5, 50, "Quae accusantium maiores ex voluptatem nemo repellendus." },
                    { 71, new DateTime(2021, 3, 2, 3, 41, 22, 368, DateTimeKind.Local).AddTicks(2235), 113, new DateTime(2022, 2, 1, 20, 58, 11, 767, DateTimeKind.Local).AddTicks(2205), new DateTime(2021, 1, 25, 16, 34, 2, 848, DateTimeKind.Local).AddTicks(1078), 5, 50, "Eligendi et velit.\nAb dolore quo nihil.\nEnim aut quisquam velit nemo.\nEt reiciendis odit architecto rem itaque facere quisquam.\nNeque debitis voluptatem non reiciendis non est." },
                    { 61, new DateTime(2021, 8, 11, 17, 7, 18, 573, DateTimeKind.Local).AddTicks(6602), 94, new DateTime(2022, 1, 14, 21, 15, 28, 507, DateTimeKind.Local).AddTicks(3104), new DateTime(2021, 1, 17, 21, 6, 42, 846, DateTimeKind.Local).AddTicks(6719), 4, 95, "corporis" },
                    { 88, new DateTime(2020, 10, 11, 3, 19, 48, 119, DateTimeKind.Local).AddTicks(1592), 23, new DateTime(2022, 1, 13, 8, 45, 8, 691, DateTimeKind.Local).AddTicks(1030), new DateTime(2020, 9, 12, 9, 11, 24, 408, DateTimeKind.Local).AddTicks(4055), 1, 95, "Ab voluptatem molestiae accusantium sed inventore velit facilis sapiente quo." },
                    { 19, new DateTime(2021, 1, 23, 7, 36, 11, 68, DateTimeKind.Local).AddTicks(1902), 80, new DateTime(2022, 5, 30, 22, 59, 56, 156, DateTimeKind.Local).AddTicks(843), new DateTime(2021, 7, 21, 5, 21, 53, 69, DateTimeKind.Local).AddTicks(7312), 4, 17, "Incidunt odit dolorem consequatur totam." },
                    { 30, new DateTime(2021, 4, 20, 1, 30, 31, 623, DateTimeKind.Local).AddTicks(601), 123, new DateTime(2021, 9, 24, 17, 39, 13, 669, DateTimeKind.Local).AddTicks(1696), new DateTime(2021, 1, 12, 13, 3, 38, 83, DateTimeKind.Local).AddTicks(7347), 4, 17, "deserunt" },
                    { 40, new DateTime(2021, 5, 15, 18, 1, 46, 475, DateTimeKind.Local).AddTicks(3490), 142, new DateTime(2022, 6, 9, 13, 39, 46, 331, DateTimeKind.Local).AddTicks(814), new DateTime(2020, 10, 26, 8, 57, 59, 441, DateTimeKind.Local).AddTicks(9674), 1, 17, "Cum officiis repudiandae numquam repellat deserunt vitae. Sit nemo aut voluptate. Rem eveniet molestias quibusdam quia maxime nostrum rerum nemo. Qui voluptas non magni ut dolorem quisquam quo dolores. Autem dolorum fugit ab et suscipit. Hic sit deserunt eum quae." },
                    { 101, new DateTime(2020, 10, 3, 16, 37, 58, 278, DateTimeKind.Local).AddTicks(8387), 33, new DateTime(2021, 12, 30, 1, 56, 10, 982, DateTimeKind.Local).AddTicks(1647), new DateTime(2020, 11, 17, 22, 8, 9, 31, DateTimeKind.Local).AddTicks(3837), 5, 17, "Quia quia rerum itaque." },
                    { 8, new DateTime(2021, 6, 6, 13, 39, 56, 103, DateTimeKind.Local).AddTicks(3051), 148, new DateTime(2022, 4, 19, 17, 59, 38, 139, DateTimeKind.Local).AddTicks(3385), new DateTime(2020, 10, 7, 20, 28, 32, 758, DateTimeKind.Local).AddTicks(8736), 3, 25, "Voluptatem eum numquam et minus odio.\nVoluptas inventore et repellat facere molestiae.\nDoloribus laudantium et quis doloremque est saepe.\nCulpa veritatis autem dolor et necessitatibus qui.\nAd distinctio et soluta consequatur quibusdam dicta." },
                    { 50, new DateTime(2020, 8, 26, 6, 1, 18, 631, DateTimeKind.Local).AddTicks(132), 61, new DateTime(2022, 4, 13, 16, 49, 56, 664, DateTimeKind.Local).AddTicks(9628), new DateTime(2020, 12, 1, 16, 46, 39, 544, DateTimeKind.Local).AddTicks(9684), 3, 25, "Impedit ut id accusantium quae." },
                    { 76, new DateTime(2021, 5, 7, 20, 43, 5, 507, DateTimeKind.Local).AddTicks(5663), 56, new DateTime(2022, 7, 31, 9, 16, 56, 557, DateTimeKind.Local).AddTicks(8498), new DateTime(2020, 8, 21, 19, 0, 54, 37, DateTimeKind.Local).AddTicks(8257), 3, 25, "et" },
                    { 95, new DateTime(2020, 11, 24, 13, 55, 12, 929, DateTimeKind.Local).AddTicks(7349), 128, new DateTime(2022, 7, 18, 8, 27, 50, 977, DateTimeKind.Local).AddTicks(2461), new DateTime(2020, 8, 28, 2, 5, 13, 189, DateTimeKind.Local).AddTicks(3866), 5, 25, "Nihil quo minima numquam eos." }
                });

            migrationBuilder.InsertData(
                table: "ServiceRequest",
                columns: new[] { "Id", "Appointment", "CarServiceId", "RepairEnd", "RepairStart", "StatusId", "UserCarId", "UserDescription" },
                values: new object[,]
                {
                    { 121, new DateTime(2021, 3, 5, 9, 32, 31, 360, DateTimeKind.Local).AddTicks(6329), 146, new DateTime(2022, 3, 2, 16, 53, 32, 616, DateTimeKind.Local).AddTicks(755), new DateTime(2021, 4, 19, 11, 26, 10, 327, DateTimeKind.Local).AddTicks(6751), 3, 25, "cumque" },
                    { 163, new DateTime(2021, 3, 11, 12, 6, 8, 710, DateTimeKind.Local).AddTicks(1772), 30, new DateTime(2022, 6, 3, 2, 34, 7, 902, DateTimeKind.Local).AddTicks(2367), new DateTime(2021, 4, 22, 3, 10, 49, 393, DateTimeKind.Local).AddTicks(5745), 4, 25, "aut" },
                    { 189, new DateTime(2021, 1, 29, 12, 35, 48, 566, DateTimeKind.Local).AddTicks(1337), 97, new DateTime(2022, 2, 13, 14, 29, 23, 42, DateTimeKind.Local).AddTicks(9584), new DateTime(2020, 9, 18, 9, 47, 8, 390, DateTimeKind.Local).AddTicks(1245), 3, 25, "Velit atque vero nam et aut." },
                    { 70, new DateTime(2021, 7, 10, 2, 38, 31, 950, DateTimeKind.Local).AddTicks(4995), 129, new DateTime(2021, 10, 26, 14, 17, 6, 46, DateTimeKind.Local).AddTicks(4137), new DateTime(2021, 1, 23, 2, 0, 16, 689, DateTimeKind.Local).AddTicks(4042), 2, 54, "Natus dignissimos tempora voluptate. Laboriosam voluptatem facere. Sapiente aspernatur consectetur at." },
                    { 131, new DateTime(2020, 12, 13, 8, 29, 20, 506, DateTimeKind.Local).AddTicks(1272), 7, new DateTime(2021, 11, 8, 11, 4, 43, 315, DateTimeKind.Local).AddTicks(3545), new DateTime(2020, 10, 23, 12, 54, 16, 605, DateTimeKind.Local).AddTicks(2706), 1, 24, "eveniet" },
                    { 82, new DateTime(2021, 5, 14, 14, 57, 36, 588, DateTimeKind.Local).AddTicks(2217), 122, new DateTime(2022, 7, 13, 0, 19, 38, 607, DateTimeKind.Local).AddTicks(3852), new DateTime(2020, 12, 28, 6, 48, 21, 910, DateTimeKind.Local).AddTicks(3385), 4, 24, "Repellat neque inventore sint. Sit accusantium sed. Voluptates odit harum harum tenetur. Qui voluptates quis fuga. Necessitatibus voluptatem aliquam eius unde ducimus aliquam perspiciatis. Eaque perferendis corporis voluptatem blanditiis." },
                    { 81, new DateTime(2020, 11, 14, 21, 27, 0, 899, DateTimeKind.Local).AddTicks(8750), 72, new DateTime(2021, 12, 28, 16, 49, 18, 222, DateTimeKind.Local).AddTicks(4774), new DateTime(2020, 10, 20, 7, 18, 35, 784, DateTimeKind.Local).AddTicks(2942), 2, 24, "Qui dolor consectetur. Et eum autem. Sunt aspernatur et dolore repellendus aut. In earum sapiente repellat illo temporibus ut incidunt." },
                    { 47, new DateTime(2021, 7, 27, 23, 24, 27, 490, DateTimeKind.Local).AddTicks(4445), 20, new DateTime(2022, 3, 27, 23, 36, 47, 319, DateTimeKind.Local).AddTicks(8295), new DateTime(2020, 9, 1, 21, 15, 54, 507, DateTimeKind.Local).AddTicks(6562), 5, 24, "Quas est architecto aut distinctio.\nQuia maiores unde cumque dolor at aliquam id quos eos." },
                    { 34, new DateTime(2020, 10, 14, 13, 21, 59, 578, DateTimeKind.Local).AddTicks(9169), 25, new DateTime(2022, 3, 1, 6, 17, 49, 971, DateTimeKind.Local).AddTicks(5855), new DateTime(2020, 11, 18, 2, 12, 39, 657, DateTimeKind.Local).AddTicks(5225), 4, 45, "molestias" },
                    { 80, new DateTime(2020, 9, 9, 15, 7, 17, 159, DateTimeKind.Local).AddTicks(6753), 104, new DateTime(2022, 4, 1, 22, 48, 42, 504, DateTimeKind.Local).AddTicks(2745), new DateTime(2020, 10, 26, 17, 19, 43, 373, DateTimeKind.Local).AddTicks(9131), 4, 45, "velit" },
                    { 124, new DateTime(2020, 10, 16, 6, 51, 51, 209, DateTimeKind.Local).AddTicks(4384), 144, new DateTime(2021, 10, 26, 9, 59, 59, 18, DateTimeKind.Local).AddTicks(6701), new DateTime(2021, 3, 9, 17, 15, 30, 311, DateTimeKind.Local).AddTicks(3430), 3, 45, "quia" },
                    { 134, new DateTime(2021, 8, 7, 20, 35, 17, 519, DateTimeKind.Local).AddTicks(921), 37, new DateTime(2021, 8, 22, 21, 14, 10, 2, DateTimeKind.Local).AddTicks(3220), new DateTime(2021, 4, 18, 2, 16, 41, 995, DateTimeKind.Local).AddTicks(1611), 2, 45, "Ducimus rem quia ex voluptatem.\nCumque minus perferendis cumque consequatur iste id aperiam ullam.\nMollitia voluptas cum eos mollitia voluptas.\nVoluptatum velit quo.\nSunt voluptatibus officia mollitia." },
                    { 86, new DateTime(2020, 10, 4, 6, 41, 29, 663, DateTimeKind.Local).AddTicks(1434), 123, new DateTime(2022, 5, 25, 18, 41, 59, 71, DateTimeKind.Local).AddTicks(5773), new DateTime(2021, 5, 6, 0, 0, 10, 925, DateTimeKind.Local).AddTicks(1812), 4, 102, "et" },
                    { 106, new DateTime(2020, 10, 9, 17, 50, 21, 820, DateTimeKind.Local).AddTicks(8106), 83, new DateTime(2021, 9, 26, 16, 22, 21, 382, DateTimeKind.Local).AddTicks(9875), new DateTime(2020, 11, 29, 18, 7, 35, 902, DateTimeKind.Local).AddTicks(6315), 3, 102, "illum" },
                    { 139, new DateTime(2020, 9, 3, 17, 35, 40, 323, DateTimeKind.Local).AddTicks(6407), 7, new DateTime(2021, 12, 2, 4, 59, 7, 379, DateTimeKind.Local).AddTicks(7347), new DateTime(2021, 4, 11, 13, 7, 31, 759, DateTimeKind.Local).AddTicks(5232), 5, 102, "Rerum quas quia est quaerat provident ut.\nIpsum labore voluptatem sed.\nUt illo et adipisci unde numquam iusto eius.\nSunt quos accusamus enim." },
                    { 36, new DateTime(2021, 2, 26, 10, 59, 30, 158, DateTimeKind.Local).AddTicks(6540), 51, new DateTime(2021, 12, 9, 18, 43, 21, 737, DateTimeKind.Local).AddTicks(8766), new DateTime(2020, 12, 6, 21, 48, 56, 28, DateTimeKind.Local).AddTicks(1521), 5, 6, "Rerum aut iusto laboriosam inventore.\nBeatae et fugit tenetur molestiae amet est odit cupiditate.\nMinus veritatis quisquam tempora quidem.\nFacilis ratione rerum omnis et.\nHarum omnis perferendis.\nAutem officiis ut totam optio dolorem assumenda aut rem nam." },
                    { 119, new DateTime(2021, 7, 17, 3, 2, 14, 616, DateTimeKind.Local).AddTicks(2278), 145, new DateTime(2022, 3, 17, 23, 41, 47, 417, DateTimeKind.Local).AddTicks(8129), new DateTime(2020, 9, 23, 1, 17, 52, 389, DateTimeKind.Local).AddTicks(8439), 5, 6, "Dolorem dolores pariatur." },
                    { 142, new DateTime(2021, 1, 9, 2, 37, 32, 831, DateTimeKind.Local).AddTicks(6025), 22, new DateTime(2022, 5, 13, 1, 20, 43, 792, DateTimeKind.Local).AddTicks(9147), new DateTime(2021, 1, 26, 14, 29, 8, 270, DateTimeKind.Local).AddTicks(5719), 5, 6, "Quam qui eum aut. Quia facere voluptatibus nesciunt velit excepturi. Repellendus autem sit repellendus ipsam aut tenetur. Sunt iusto aspernatur debitis. Et beatae numquam ut aut est itaque dignissimos nihil." },
                    { 168, new DateTime(2020, 12, 26, 18, 31, 52, 728, DateTimeKind.Local).AddTicks(6454), 16, new DateTime(2022, 1, 19, 14, 17, 7, 99, DateTimeKind.Local).AddTicks(3016), new DateTime(2021, 1, 29, 6, 45, 0, 919, DateTimeKind.Local).AddTicks(1230), 1, 26, "Ex aliquam ut qui sequi natus maiores quisquam rerum consectetur. Dicta repellendus molestias perferendis sequi ut distinctio nemo et. Optio sit nulla non eveniet nisi eaque consequatur amet cumque. Nostrum doloremque dolore beatae vel tenetur aliquid saepe qui." },
                    { 11, new DateTime(2020, 8, 30, 9, 29, 42, 951, DateTimeKind.Local).AddTicks(4762), 24, new DateTime(2022, 1, 31, 10, 8, 9, 414, DateTimeKind.Local).AddTicks(62), new DateTime(2020, 11, 17, 23, 53, 39, 653, DateTimeKind.Local).AddTicks(9229), 4, 42, "Voluptas sit et omnis non voluptates nostrum voluptatem blanditiis suscipit.\nPraesentium rerum praesentium deleniti omnis architecto vero velit perferendis voluptas.\nSapiente qui est.\nBeatae id animi et iusto.\nNihil aliquid quis natus perspiciatis rerum ducimus sed voluptatem.\nSit velit sed eos." },
                    { 21, new DateTime(2021, 4, 7, 12, 6, 2, 482, DateTimeKind.Local).AddTicks(6227), 14, new DateTime(2021, 12, 1, 5, 6, 53, 771, DateTimeKind.Local).AddTicks(2655), new DateTime(2021, 4, 30, 8, 34, 52, 310, DateTimeKind.Local).AddTicks(3047), 1, 42, "architecto" },
                    { 83, new DateTime(2020, 11, 23, 20, 45, 16, 730, DateTimeKind.Local).AddTicks(5981), 108, new DateTime(2022, 1, 21, 4, 14, 34, 440, DateTimeKind.Local).AddTicks(5960), new DateTime(2021, 7, 16, 3, 24, 24, 568, DateTimeKind.Local).AddTicks(4842), 3, 42, "Debitis consequuntur animi aut vero labore expedita nihil. Dolorem sit enim. Et quo consequatur dolorum architecto atque at enim. Aut quis quia nihil sint et aut tenetur perferendis porro. Sint vel explicabo. Suscipit qui nemo eligendi laborum et eos beatae amet excepturi." },
                    { 122, new DateTime(2020, 8, 14, 6, 44, 5, 588, DateTimeKind.Local).AddTicks(9319), 32, new DateTime(2022, 5, 6, 23, 2, 47, 552, DateTimeKind.Local).AddTicks(8904), new DateTime(2020, 11, 9, 2, 19, 59, 194, DateTimeKind.Local).AddTicks(7340), 3, 42, "Beatae recusandae sed quisquam aut. Accusamus et tempore et commodi unde accusamus dolores eaque. Et ullam voluptatibus. Voluptas voluptatem omnis officiis adipisci. Voluptas officiis quas eos at cum aut rerum voluptatem." },
                    { 141, new DateTime(2020, 10, 10, 7, 20, 39, 895, DateTimeKind.Local).AddTicks(8143), 37, new DateTime(2021, 9, 17, 14, 9, 11, 775, DateTimeKind.Local).AddTicks(7908), new DateTime(2021, 7, 25, 21, 43, 27, 126, DateTimeKind.Local).AddTicks(1773), 5, 42, "Consequatur est et voluptates expedita eveniet blanditiis consequuntur enim repellendus.\nNobis ut rerum deserunt aut itaque.\nEt voluptatum hic id.\nAtque consequatur dolor sunt." },
                    { 5, new DateTime(2021, 3, 3, 13, 12, 51, 122, DateTimeKind.Local).AddTicks(6673), 8, new DateTime(2022, 2, 18, 21, 27, 46, 364, DateTimeKind.Local).AddTicks(9957), new DateTime(2021, 6, 19, 8, 33, 15, 108, DateTimeKind.Local).AddTicks(2040), 2, 2, "eum" },
                    { 26, new DateTime(2021, 4, 4, 16, 9, 35, 495, DateTimeKind.Local).AddTicks(7146), 58, new DateTime(2022, 2, 20, 10, 16, 33, 380, DateTimeKind.Local).AddTicks(3089), new DateTime(2021, 4, 7, 2, 38, 15, 207, DateTimeKind.Local).AddTicks(9011), 2, 2, "Magnam temporibus quia vitae fugiat non non." },
                    { 41, new DateTime(2021, 3, 21, 5, 21, 54, 621, DateTimeKind.Local).AddTicks(2580), 107, new DateTime(2022, 5, 18, 8, 25, 17, 269, DateTimeKind.Local).AddTicks(8559), new DateTime(2021, 4, 10, 15, 34, 34, 924, DateTimeKind.Local).AddTicks(8046), 1, 2, "Expedita quis perferendis assumenda ducimus temporibus laudantium.\nEum laudantium totam.\nEarum reiciendis pariatur repellendus praesentium ratione temporibus." },
                    { 60, new DateTime(2020, 10, 27, 19, 20, 46, 138, DateTimeKind.Local).AddTicks(7897), 72, new DateTime(2021, 11, 19, 16, 38, 16, 611, DateTimeKind.Local).AddTicks(4656), new DateTime(2021, 5, 8, 7, 16, 40, 972, DateTimeKind.Local).AddTicks(4493), 3, 2, "Non rem voluptate est culpa consectetur rerum." },
                    { 94, new DateTime(2020, 12, 29, 13, 37, 17, 225, DateTimeKind.Local).AddTicks(4364), 121, new DateTime(2021, 9, 26, 22, 23, 36, 493, DateTimeKind.Local).AddTicks(8372), new DateTime(2020, 11, 7, 9, 21, 46, 570, DateTimeKind.Local).AddTicks(4648), 1, 30, "fugiat" },
                    { 198, new DateTime(2021, 4, 4, 10, 21, 41, 227, DateTimeKind.Local).AddTicks(5928), 30, new DateTime(2022, 6, 14, 7, 5, 29, 645, DateTimeKind.Local).AddTicks(4139), new DateTime(2020, 11, 27, 13, 13, 50, 468, DateTimeKind.Local).AddTicks(3350), 4, 30, "Tempore alias tempore maxime quia illum deserunt consectetur non quia. Repellat optio dolorem aut est. Voluptatem tenetur beatae omnis laboriosam cum corrupti. Ut et qui porro quibusdam non et amet amet." },
                    { 12, new DateTime(2021, 1, 24, 10, 22, 44, 996, DateTimeKind.Local).AddTicks(4401), 113, new DateTime(2021, 10, 6, 5, 49, 50, 932, DateTimeKind.Local).AddTicks(9669), new DateTime(2020, 9, 18, 18, 13, 24, 60, DateTimeKind.Local).AddTicks(7871), 1, 42, "Expedita nihil eius et ut laborum eum nobis unde." },
                    { 175, new DateTime(2021, 3, 27, 19, 31, 34, 650, DateTimeKind.Local).AddTicks(4127), 96, new DateTime(2022, 3, 4, 4, 16, 32, 344, DateTimeKind.Local).AddTicks(9254), new DateTime(2021, 3, 27, 21, 7, 17, 799, DateTimeKind.Local).AddTicks(9148), 3, 26, "Aliquam id placeat ea.\nQuaerat aut maiores omnis nihil magni expedita et voluptas.\nEum distinctio nostrum expedita voluptatem quo dolor non.\nDebitis quam doloremque debitis sed.\nDeleniti enim dolorem non saepe.\nQuidem voluptas suscipit dolorem non dicta." }
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
