using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Globe_Wander_Final.Migrations
{
    /// <inheritdoc />
    public partial class osama : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TourSpots",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TourSpots", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Layout = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rooms_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StarRate = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TourSpotID = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hotels_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Hotels_TourSpots_TourSpotID",
                        column: x => x.TourSpotID,
                        principalTable: "TourSpots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Activity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    TourSpotID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trips_TourSpots_TourSpotID",
                        column: x => x.TourSpotID,
                        principalTable: "TourSpots",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Amenities_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "Amenities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelFacilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelId = table.Column<int>(type: "int", nullable: false),
                    FacilityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelFacilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HotelFacilities_Facilities_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "Facilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelFacilities_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SquareFeet = table.Column<int>(type: "int", nullable: false),
                    Bathrooms = table.Column<int>(type: "int", nullable: false),
                    Beds = table.Column<int>(type: "int", nullable: false),
                    PricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => new { x.HotelID, x.RoomNumber });
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bookingTrips",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    NumberOfPersons = table.Column<int>(type: "int", nullable: false),
                    CostPerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookingTrips", x => x.ID);
                    table.ForeignKey(
                        name: "FK_bookingTrips_Trips_TripID",
                        column: x => x.TripID,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripID = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Rates_Trips_TripID",
                        column: x => x.TripID,
                        principalTable: "Trips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingRooms",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelID = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRooms", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BookingRooms_HotelRooms_HotelID_RoomNumber",
                        columns: x => new { x.HotelID, x.RoomNumber },
                        principalTable: "HotelRooms",
                        principalColumns: new[] { "HotelID", "RoomNumber" });
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: true),
                    HotelRoomHotelID = table.Column<int>(type: "int", nullable: true),
                    HotelRoomRoomNumber = table.Column<int>(type: "int", nullable: true),
                    HotelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_HotelRooms_HotelRoomHotelID_HotelRoomRoomNumber",
                        columns: x => new { x.HotelRoomHotelID, x.HotelRoomRoomNumber },
                        principalTable: "HotelRooms",
                        principalColumns: new[] { "HotelID", "RoomNumber" });
                    table.ForeignKey(
                        name: "FK_Images_Hotels_HotelId",
                        column: x => x.HotelId,
                        principalTable: "Hotels",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Free Wi-Fi" },
                    { 2, "TV" },
                    { 3, "Air conditioning" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "admin manager", "00000000-0000-0000-0000-000000000000", "Admin Manager", "ADMIN MANAGER" },
                    { "hotel manager", "00000000-0000-0000-0000-000000000000", "Hotel Manager", "HOTEL MANAGER" },
                    { "trip manager", "00000000-0000-0000-0000-000000000000", "Trip Manager", "TRIP MANAGER" },
                    { "user", "00000000-0000-0000-0000-000000000000", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "0bb483e1-e726-4bf8-9ee9-4abc98ccba26", "adminUser@example.com", true, false, null, "adminUser@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEMBXInpBnF+H2ucdh+Nh/mGsYMbuOS7Fxf+9HW7uAWBMOg/YgTC4l5SKsLIeqweG3w==", "1234567890", false, "b9cab3b3-82f4-4a45-9a3b-a986f229a75f", false, "admin" },
                    { "2", 0, "b8387b84-f307-44aa-8587-b201319512d7", "hotel@example.com", true, false, null, "hotel@EXAMPLE.COM", "HOTEL", "AQAAAAIAAYagAAAAEMhG6ApBJzb5mVmAPh3jYYqFk8Fclm26Mw9l29uAgnSPqLYGdAg0ECH7meVwPmAbyg==", "1234567890", false, "1624d794-c998-4365-b44f-d46f1da0c683", false, "hotel" },
                    { "3", 0, "353e88ab-80df-4aa2-8b2e-488f45b3869d", "trip@example.com", true, false, null, "trip@EXAMPLE.COM", "TRIP", "AQAAAAIAAYagAAAAEIP6iRcsy6EU77y9t+IqDm/q/Dy4aZla676HcQnKZkDvexLqF51v009s6uph5gl3EQ==", "1234567890", false, "a9d622f4-f8a7-425f-a687-6ca6b4e8cad7", false, "trip" },
                    { "4", 0, "ab2acc06-a01d-4bdf-bddb-209467966c63", "User@example.com", true, false, null, null, "USER", "AQAAAAIAAYagAAAAEIlsObD+II7+/Y81eBy4ofgmBYlMhMVuxODrlxae8ZigWx2I4H2+ZIQeojF3UpDz4Q==", "1234567890", false, "671c4dd8-d5e8-47da-b3db-39d975e309f9", false, "User" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Swming pool" },
                    { 2, "resturants" },
                    { 3, "GYM" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "AmenityId", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, null, 2, "Small Room" },
                    { 2, null, 3, "Suite Room" },
                    { 3, null, 1, "Studio room" }
                });

            migrationBuilder.InsertData(
                table: "TourSpots",
                columns: new[] { "ID", "Category", "City", "Country", "Description", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 3, "Petra", "Jordan", "a place before thousands years", "Petra", "078885423" },
                    { 2, 3, "Jerash", "Jordan", "A historical place that the Romanian civilization build before thousands years.", "Jerash", "088782215" },
                    { 3, 3, "Irbid", "Jordan", "A historical place that the Romanian civilization build before thousands years. In the north of Jordan", "Um Qais", "0788442521" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "admin manager", "1" },
                    { "hotel manager", "2" },
                    { "trip manager", "3" },
                    { "user", "4" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Description", "FacilityId", "Location", "Name", "StarRate", "TourSpotID" },
                values: new object[,]
                {
                    { 1, "A peaceful retreat in the heart of the city", null, "amman", "Harmony", 4, 1 },
                    { 2, "The perfect base for your desert adventure", null, "wadi rum", "Adventure", 3, 2 },
                    { 3, "A luxury resort on the shores of the Dead Sea", null, "dead sea", "Oasis", 5, 3 },
                    { 4, "Experience the rich history of Jerash", null, "jerash", "Heritage", 4, 1 },
                    { 5, "Stunning sea views in a modern setting", null, "aqaba", "Horizon", 5, 2 }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "Id", "AmenityId", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 1, 3 },
                    { 5, 2, 3 },
                    { 6, 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Activity", "Capacity", "Cost", "Count", "Description", "EndDate", "Name", "StartDate", "TourSpotID" },
                values: new object[,]
                {
                    { 1, "walking", 30, 20m, 0, "trip start at 8 am and going from Amman to Petra", new DateTime(2023, 10, 18, 15, 59, 19, 54, DateTimeKind.Utc).AddTicks(8042), "Petra ride", new DateTime(2023, 10, 18, 18, 59, 19, 54, DateTimeKind.Local).AddTicks(8000), 1 },
                    { 2, "visiting", 22, 30m, 0, "Amman to Jerash with a trip manager who can speak many languages", new DateTime(2023, 10, 18, 15, 59, 19, 54, DateTimeKind.Utc).AddTicks(8046), "Jerash ride", new DateTime(2023, 10, 18, 18, 59, 19, 54, DateTimeKind.Local).AddTicks(8045), 2 },
                    { 3, "climbing", 40, 40m, 0, "Amman to Irbid with a trip manager who can speak many languages", new DateTime(2023, 10, 18, 15, 59, 19, 54, DateTimeKind.Utc).AddTicks(8049), "Um-Qais ride", new DateTime(2023, 10, 18, 18, 59, 19, 54, DateTimeKind.Local).AddTicks(8048), 3 }
                });

            migrationBuilder.InsertData(
                table: "HotelFacilities",
                columns: new[] { "Id", "FacilityId", "HotelId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 1 },
                    { 5, 1, 2 },
                    { 6, 1, 3 },
                    { 7, 2, 4 },
                    { 8, 3, 5 },
                    { 10, 1, 4 },
                    { 11, 2, 5 }
                });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomNumber", "Bathrooms", "Beds", "Description", "IsAvailable", "PricePerDay", "RoomID", "SquareFeet" },
                values: new object[,]
                {
                    { 1, 101, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 1, 102, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", false, 200.00m, 2, 700 },
                    { 1, 103, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 },
                    { 2, 201, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 2, 202, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", false, 200.00m, 2, 700 },
                    { 2, 203, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 },
                    { 3, 301, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 3, 302, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", false, 200.00m, 2, 700 },
                    { 3, 303, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 },
                    { 4, 401, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 4, 402, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", false, 200.00m, 2, 700 },
                    { 4, 403, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 },
                    { 5, 501, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 5, 502, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", false, 200.00m, 2, 700 },
                    { 5, 503, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "HotelRoomHotelID", "HotelRoomRoomNumber", "Path", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null },
                    { 2, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null },
                    { 3, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null },
                    { 4, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null },
                    { 5, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", null },
                    { 6, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null },
                    { 7, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null },
                    { 8, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image2.jpg", null },
                    { 9, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image1.jpg", null },
                    { 10, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image3.jpg", null },
                    { 11, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image4.jpg", null },
                    { 12, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image5.jpg", null },
                    { 13, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image3.jpg", null },
                    { 14, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image4.jpg", null },
                    { 15, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null },
                    { 16, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null },
                    { 17, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null },
                    { 18, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null },
                    { 19, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", null },
                    { 20, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null },
                    { 21, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null },
                    { 22, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null },
                    { 23, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null },
                    { 24, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null },
                    { 25, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null },
                    { 26, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", null },
                    { 27, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null },
                    { 28, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null },
                    { 29, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null },
                    { 30, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null },
                    { 31, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null },
                    { 32, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null },
                    { 33, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", null },
                    { 34, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null },
                    { 35, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null },
                    { 36, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 101 },
                    { 37, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 101 },
                    { 38, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 101 },
                    { 39, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 101 },
                    { 40, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 101 },
                    { 41, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 101 },
                    { 42, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 101 },
                    { 43, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 102 },
                    { 44, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 102 },
                    { 45, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 102 },
                    { 46, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 102 },
                    { 47, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 102 },
                    { 48, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 102 },
                    { 49, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 102 },
                    { 50, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 103 },
                    { 51, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 103 },
                    { 52, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 103 },
                    { 53, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 103 },
                    { 54, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 103 },
                    { 55, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 103 },
                    { 56, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 103 },
                    { 57, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 201 },
                    { 58, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 201 },
                    { 59, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 201 },
                    { 60, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 201 },
                    { 61, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 201 },
                    { 62, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 201 },
                    { 63, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 201 },
                    { 64, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 202 },
                    { 65, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 202 },
                    { 66, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 202 },
                    { 67, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 202 },
                    { 68, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 202 },
                    { 69, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 202 },
                    { 70, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 202 },
                    { 71, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 203 },
                    { 72, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 203 },
                    { 73, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 203 },
                    { 74, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 203 },
                    { 75, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 203 },
                    { 76, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 203 },
                    { 77, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 203 },
                    { 78, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 301 },
                    { 79, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 301 },
                    { 80, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 301 },
                    { 81, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 301 },
                    { 82, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 301 },
                    { 83, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 301 },
                    { 84, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 301 },
                    { 85, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 302 },
                    { 86, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 302 },
                    { 87, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 302 },
                    { 88, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 302 },
                    { 89, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 302 },
                    { 90, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 302 },
                    { 91, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 302 },
                    { 92, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 303 },
                    { 93, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 303 },
                    { 94, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 303 },
                    { 95, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 303 },
                    { 96, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 303 },
                    { 97, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 303 },
                    { 98, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 303 },
                    { 99, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 401 },
                    { 100, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 401 },
                    { 101, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 401 },
                    { 102, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 401 },
                    { 103, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 401 },
                    { 104, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 401 },
                    { 105, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 401 },
                    { 106, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 402 },
                    { 107, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 402 },
                    { 108, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 402 },
                    { 109, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 402 },
                    { 110, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 402 },
                    { 111, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 402 },
                    { 112, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 402 },
                    { 113, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 403 },
                    { 114, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 403 },
                    { 115, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 403 },
                    { 116, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 403 },
                    { 117, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 403 },
                    { 118, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 403 },
                    { 119, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 403 },
                    { 120, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 501 },
                    { 121, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 501 },
                    { 122, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 501 },
                    { 123, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 501 },
                    { 124, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 501 },
                    { 125, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 501 },
                    { 126, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 501 },
                    { 127, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 502 },
                    { 128, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 502 },
                    { 129, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 502 },
                    { 130, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 502 },
                    { 131, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 502 },
                    { 132, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 502 },
                    { 133, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 502 },
                    { 134, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 503 },
                    { 135, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 503 },
                    { 136, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 503 },
                    { 137, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 503 },
                    { 138, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 503 },
                    { 139, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 503 },
                    { 140, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 503 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRooms_HotelID_RoomNumber",
                table: "BookingRooms",
                columns: new[] { "HotelID", "RoomNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bookingTrips_TripID",
                table: "bookingTrips",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_FacilityId",
                table: "HotelFacilities",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelFacilities_HotelId",
                table: "HotelFacilities",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRooms",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_FacilityId",
                table: "Hotels",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_TourSpotID",
                table: "Hotels",
                column: "TourSpotID");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HotelId",
                table: "Images",
                column: "HotelId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_HotelRoomHotelID_HotelRoomRoomNumber",
                table: "Images",
                columns: new[] { "HotelRoomHotelID", "HotelRoomRoomNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_Rates_TripID",
                table: "Rates",
                column: "TripID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomId",
                table: "RoomAmenities",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_AmenityId",
                table: "Rooms",
                column: "AmenityId");

            migrationBuilder.CreateIndex(
                name: "IX_Trips_TourSpotID",
                table: "Trips",
                column: "TourSpotID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BookingRooms");

            migrationBuilder.DropTable(
                name: "bookingTrips");

            migrationBuilder.DropTable(
                name: "HotelFacilities");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Rates");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "Trips");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "TourSpots");

            migrationBuilder.DropTable(
                name: "Amenities");
        }
    }
}
