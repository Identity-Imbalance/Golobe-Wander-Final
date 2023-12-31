﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Globe_Wander_Final.Migrations
{
    /// <inheritdoc />
    public partial class done : Migration
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
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "UPDATEBOOKINGTEMPs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForUpdate = table.Column<int>(type: "int", nullable: false),
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UPDATEBOOKINGTEMPs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UPDATEBOOKINGTRIPs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdForUpdate = table.Column<int>(type: "int", nullable: false),
                    NumberOfPersons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UPDATEBOOKINGTRIPs", x => x.ID);
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
                    RoomNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CostPerPerson = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    CheckIn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOut = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    HotelId = table.Column<int>(type: "int", nullable: true),
                    TripId = table.Column<int>(type: "int", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Images_Trips_TripId",
                        column: x => x.TripId,
                        principalTable: "Trips",
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageUrl", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "5467bb29-8ada-41f4-819b-f4d9a6e8dd4f", "adminUser@example.com", true, null, false, null, "adminUser@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEBgHajPsriAusGzkDBX+Qr+dpoB3Doo+IwfdTxjuUHKHXNnH/xCT18mJDoglqt9ieg==", "1234567890", false, "21bd0bc6-2345-49ef-af46-88a6bac5d25b", false, "admin" },
                    { "2", 0, "def53d90-1a8e-4ef6-aa98-734103f8c079", "hotel@example.com", true, null, false, null, "hotel@EXAMPLE.COM", "HOTEL", "AQAAAAIAAYagAAAAEIC4EgrAz3yq5tRXkBTLH1rL2DdehTdrKjeRg7QGE8Ik8kBPqlzCrrBmU5EW9AJCpw==", "1234567890", false, "13541617-a186-4582-8e18-03a3d761d557", false, "hotel" },
                    { "3", 0, "83e1204e-1db8-4545-b7a8-0a5a6b7f7174", "trip@example.com", true, null, false, null, "trip@EXAMPLE.COM", "TRIP", "AQAAAAIAAYagAAAAEBiBUHEL2leyUp90hEGo0iz/AmT0jLk4JU8UywwDYIsDTpOOGEufpM4nNjHkj0Cu/A==", "1234567890", false, "871786a9-4764-4688-a58a-fa03d9662a36", false, "trip" },
                    { "4", 0, "1fc47d2f-4d1f-4c76-a6f6-395cfd029033", "User@example.com", true, null, false, null, null, "USER", "AQAAAAIAAYagAAAAEL1vAwB9CXJR+bggCR/cQ7OUbYNh0fzodAJYGloLYs70DVMWYcgtWYNbQhXCu+Z8cA==", "1234567890", false, "f0de04f4-9eef-488e-ade2-cf2209425004", false, "User" }
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
                columns: new[] { "ID", "Category", "City", "Country", "Description", "Img", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 3, "Petra", "Jordan", "Step back in time as you enter the ancient Nabatean city of Petra, a UNESCO World Heritage Site and one of the New Seven Wonders of the World. Marvel at the intricately carved facades, explore the hidden tombs, and soak in the sheer grandeur of this archaeological masterpiece.", "https://images.pexels.com/photos/1631665/pexels-photo-1631665.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Petra", "078885423" },
                    { 2, 3, "Jerash", "Jordan", "Uncover the secrets of Jerash, one of the best-preserved Roman cities in the world. Wander through its well-preserved streets, temples, and theaters, and let the whispers of ancient civilizations echo through time.", "https://c0.wallpaperflare.com/preview/705/707/822/jordan-jerash-oval-plaza-market.jpg", "Jerash", "088782215" },
                    { 3, 3, "Irbid", "Jordan", "Perched on a hill overlooking the Sea of Galilee, Um Qais offers panoramic views of the Jordan Valley, Golan Heights, and the Sea of Tiberias. This ancient Decapolis city invites you to wander among its Roman ruins and absorb the stunning natural beauty of the region.", "https://followinghadrianphotographycom.files.wordpress.com/2020/09/34509636386_2139ee3bc1_k.jpg?w=1075&h=712", "Um Qais", "0788442521" },
                    { 4, 4, "Aqaba", "Jordan", "Prepare to be enchanted by the surreal landscapes of Wadi Rum, often referred to as the \"Valley of the Moon.\" Traverse its vast desert expanse, characterized by towering sandstone mountains and shifting sands. Experience the magic of Bedouin culture through traditional meals and starlit desert camping.", "https://c4.wallpaperflare.com/wallpaper/774/140/860/nature-landscape-sand-desert-dunes-hd-wallpaper-preview.jpg", "Wadi Rum", "0788555444" },
                    { 5, 3, "Ajloun", "Jordan", "Ajloun Castle stands proudly amidst the lush green hills of northern Jordan. This 12th-century fortress offers a glimpse into the region's medieval history and provides breathtaking views of the surrounding countryside.", "https://as1.ftcdn.net/v2/jpg/02/49/78/08/1000_F_249780853_qBrIwoai4WNGR0OSx4I6A3EZZ47cUN5B.jpg", "Ajloun Castle", "0799111122" },
                    { 6, 4, "Amman", "Jordan", "Indulge in the therapeutic wonders of the Dead Sea, the lowest point on Earth. Float effortlessly on its mineral-rich waters and rejuvenate your skin with its famed mud. The surreal landscape and unique experiences make this natural wonder a must-visit.", "https://c4.wallpaperflare.com/wallpaper/884/827/830/dead-sea-coast-white-salt-blue-sea-wallpaper-preview.jpg", "Dead Sea", "0777888999" },
                    { 7, 4, "Aqaba", "Jordan", "Beautiful beaches along the Red Sea.", "https://wallpapers.com/images/high/aqaba-jordan-shoreline-y69cto406g6r0i5c.webp", "Aqaba Beach", "0799777666" },
                    { 8, 3, "Madaba", "Jordan", "Ancient hilltop fortress where John the Baptist was imprisoned.", "https://storage.kempinski.com/cdn-cgi/image/w=960,f=auto,g=auto,fit=scale-down/ki-cms-prod/images/4/5/5/3/313554-1-eng-GB/9e96e4717f7a-74342124_4K.jpg", "Wadi Al-Mujib", "0777666555" },
                    { 9, 4, "Tafilah", "Jordan", "A diverse ecological system in southern Jordan.", "https://www.jordanbesttours.com/images/dana/jordan_nature_reserves_dana_full.jpg", "Dana Biosphere Reserve", "0799888777" }
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
                    { 1, "walking", 30, 20m, 0, "trip starts at 8 am and goes from Amman to Petra", new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Petra ride", new DateTime(2023, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, "visiting", 22, 30m, 0, "Amman to Jerash with a trip manager who can speak many languages", new DateTime(2023, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jerash ride", new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, "climbing", 40, 40m, 0, "Amman to Irbid with a trip manager who can speak many languages", new DateTime(2023, 11, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Um-Qais ride", new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, "desert safari", 20, 50m, 0, "Explore the breathtaking Wadi Rum desert in Jordan.", new DateTime(2023, 11, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wadi Rum Adventure", new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 5, "swimming and mud baths", 15, 25m, 0, "Relax at the world-famous Dead Sea and experience its healing properties.", new DateTime(2023, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dead Sea Relaxation", new DateTime(2023, 11, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, "scuba diving", 10, 60m, 0, "Discover the vibrant marine life of the Red Sea in Aqaba.", new DateTime(2023, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aqaba Diving Expedition", new DateTime(2023, 11, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, "sightseeing", 25, 15m, 0, "Explore the historical and cultural landmarks of Amman.", new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amman City Tour", new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 8, "hiking", 12, 35m, 0, "Trek through the stunning Dana Biosphere Reserve.", new DateTime(2023, 12, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dana Biosphere Reserve Hike", new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 9, "canyoning", 18, 45m, 0, "Experience the adventure of canyoning in Wadi Mujib.", new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wadi Mujib Canyoning", new DateTime(2023, 12, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, "relaxation", 30, 20m, 0, "Relax in the soothing hot springs of Ma'in.", new DateTime(2023, 12, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ma'in Hot Springs Visit", new DateTime(2023, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 11, "historical tour", 20, 25m, 0, "Explore the historic Kerak Castle in Jordan.", new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kerak Castle Tour", new DateTime(2023, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 12, "nature walk", 15, 30m, 0, "Take a nature walk in the Ajloun Forest Reserve.", new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ajloun Forest Reserve Trek", new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 13, "food tasting", 12, 40m, 0, "Indulge in a culinary journey through Amman's cuisine.", new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amman Culinary Tour", new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 14, "mosaic art", 25, 20m, 0, "Discover the mosaic art of Madaba.", new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mosaic City Madaba", new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 15, "historical tour", 18, 30m, 0, "Explore the historic Ajloun Castle.", new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ajloun Castle Exploration", new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 16, "beach relaxation", 20, 55m, 0, "Relax on the beautiful beaches of Aqaba.", new DateTime(2024, 1, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aqaba Beach Getaway", new DateTime(2024, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 17, "snorkeling", 15, 40m, 0, "Explore the underwater world of the Red Sea through snorkeling in Aqaba.", new DateTime(2024, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aqaba Snorkeling Adventure", new DateTime(2024, 1, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 18, "boat tour", 25, 30m, 0, "View marine life through a glass-bottom boat tour in Aqaba.", new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aqaba Glass-Bottom Boat Tour", new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 19, "desert adventure", 12, 45m, 0, "Embark on an exciting jeep safari in the Aqaba desert.", new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aqaba Desert Jeep Safari", new DateTime(2024, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 20, "nightclub hopping", 20, 25m, 0, "Experience the vibrant nightlife of Aqaba.", new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Aqaba Nightlife Tour", new DateTime(2024, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 21, "historical tour", 15, 60m, 0, "Explore the iconic Pyramids of Giza in Egypt.", new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pyramids of Giza Tour", new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 22, "theater", 18, 60m, 0, "Attend a Broadway show in the heart of New York City.", new DateTime(2024, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Broadway Show Experience", new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 23, "museum visit", 20, 30m, 0, "Explore the museums along Museum Mile.", new DateTime(2024, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Museum Mile Tour", new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 24, "walking tour", 35, 20m, 0, "Take a scenic walk across the historic Brooklyn Bridge.", new DateTime(2024, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Brooklyn Bridge Walk", new DateTime(2024, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 25, "sightseeing", 30, 35m, 0, "Enjoy panoramic views from the Empire State Building.", new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Empire State Building Observation Deck", new DateTime(2024, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 26, "boat tour", 25, 45m, 0, "Cruise along the Hudson River and see Manhattan's skyline.", new DateTime(2024, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Hudson River Boat Tour", new DateTime(2024, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 27, "cultural tour", 20, 45m, 0, "Immerse in the rich culture of Ubud, Bali.", new DateTime(2024, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ubud Cultural Experience", new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 28, "snorkeling", 30, 60m, 0, "Explore the vibrant marine life of the Red Sea in Aqaba", new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Red Sea Adventure", new DateTime(2024, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 29, "off-roading", 20, 50m, 0, "Experience the thrill of a desert adventure in Aqaba", new DateTime(2024, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Desert Safari", new DateTime(2024, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 30, "scuba diving", 15, 70m, 0, "Discover submerged historical sites in the Red Sea", new DateTime(2024, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Historical Dive", new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 }
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
                    { 1, 102, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", true, 200.00m, 2, 700 },
                    { 1, 103, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 },
                    { 2, 201, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 2, 202, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", true, 200.00m, 2, 700 },
                    { 2, 203, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 },
                    { 3, 301, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 3, 302, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", true, 200.00m, 2, 700 },
                    { 3, 303, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 },
                    { 4, 401, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 4, 402, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", true, 200.00m, 2, 700 },
                    { 4, 403, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 },
                    { 5, 501, 1, 2, " A spacious room with a king-size bed, modern amenities, and a beautiful city view.", true, 150.00m, 1, 500 },
                    { 5, 502, 2, 2, " A luxurious suite with two queen-size beds, a mini bar, a private balcony with ocean views, and premium toiletries.", true, 200.00m, 2, 700 },
                    { 5, 503, 2, 1, "A large studio with a separate living area, king-size bed, two bathrooms, and a private terrace overlooking the city.", true, 300.00m, 3, 1000 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "HotelRoomHotelID", "HotelRoomRoomNumber", "Path", "RoomNumber", "TripId" },
                values: new object[,]
                {
                    { 1, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null, null },
                    { 2, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null, null },
                    { 3, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null, null },
                    { 4, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null, null },
                    { 5, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", null, null },
                    { 6, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null, null },
                    { 7, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null, null },
                    { 8, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image2.jpg", null, null },
                    { 9, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image1.jpg", null, null },
                    { 10, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image3.jpg", null, null },
                    { 11, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image4.jpg", null, null },
                    { 12, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image5.jpg", null, null },
                    { 13, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image3.jpg", null, null },
                    { 14, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel2image4.jpg", null, null },
                    { 15, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null, null },
                    { 16, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null, null },
                    { 17, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null, null },
                    { 18, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null, null },
                    { 19, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", null, null },
                    { 20, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null, null },
                    { 21, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null, null },
                    { 22, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null, null },
                    { 23, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null, null },
                    { 24, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null, null },
                    { 25, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null, null },
                    { 26, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", null, null },
                    { 27, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null, null },
                    { 28, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null, null },
                    { 29, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", null, null },
                    { 30, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null, null },
                    { 31, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null, null },
                    { 32, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", null, null },
                    { 33, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", null, null },
                    { 34, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", null, null },
                    { 35, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", null, null },
                    { 36, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 101, null },
                    { 37, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 101, null },
                    { 38, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 101, null },
                    { 39, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 101, null },
                    { 40, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 101, null },
                    { 41, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 101, null },
                    { 42, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 101, null },
                    { 43, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 102, null },
                    { 44, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 102, null },
                    { 45, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 102, null },
                    { 46, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 102, null },
                    { 47, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 102, null },
                    { 48, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 102, null },
                    { 49, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 102, null },
                    { 50, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 103, null },
                    { 51, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 103, null },
                    { 52, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 103, null },
                    { 53, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 103, null },
                    { 54, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 103, null },
                    { 55, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 103, null },
                    { 56, 1, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 103, null },
                    { 57, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 201, null },
                    { 58, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 201, null },
                    { 59, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 201, null },
                    { 60, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 201, null },
                    { 61, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 201, null },
                    { 62, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 201, null },
                    { 63, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 201, null },
                    { 64, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 202, null },
                    { 65, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 202, null },
                    { 66, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 202, null },
                    { 67, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 202, null },
                    { 68, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 202, null },
                    { 69, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 202, null },
                    { 70, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 202, null },
                    { 71, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 203, null },
                    { 72, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 203, null },
                    { 73, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 203, null },
                    { 74, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 203, null },
                    { 75, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 203, null },
                    { 76, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 203, null },
                    { 77, 2, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 203, null },
                    { 78, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 301, null },
                    { 79, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 301, null },
                    { 80, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 301, null },
                    { 81, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 301, null },
                    { 82, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 301, null },
                    { 83, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 301, null },
                    { 84, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 301, null },
                    { 85, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 302, null },
                    { 86, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 302, null },
                    { 87, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 302, null },
                    { 88, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 302, null },
                    { 89, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 302, null },
                    { 90, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 302, null },
                    { 91, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 302, null },
                    { 92, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 303, null },
                    { 93, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 303, null },
                    { 94, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 303, null },
                    { 95, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 303, null },
                    { 96, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 303, null },
                    { 97, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 303, null },
                    { 98, 3, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 303, null },
                    { 99, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 401, null },
                    { 100, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 401, null },
                    { 101, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 401, null },
                    { 102, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 401, null },
                    { 103, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 401, null },
                    { 104, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 401, null },
                    { 105, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 401, null },
                    { 106, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 402, null },
                    { 107, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 402, null },
                    { 108, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 402, null },
                    { 109, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 402, null },
                    { 110, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 402, null },
                    { 111, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 402, null },
                    { 112, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 402, null },
                    { 113, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 403, null },
                    { 114, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 403, null },
                    { 115, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 403, null },
                    { 116, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 403, null },
                    { 117, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 403, null },
                    { 118, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 403, null },
                    { 119, 4, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 403, null },
                    { 120, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 501, null },
                    { 121, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 501, null },
                    { 122, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 501, null },
                    { 123, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 501, null },
                    { 124, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 501, null },
                    { 125, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 501, null },
                    { 126, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 501, null },
                    { 127, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 502, null },
                    { 128, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 502, null },
                    { 129, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 502, null },
                    { 130, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 502, null },
                    { 131, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 502, null },
                    { 132, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 502, null },
                    { 133, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 502, null },
                    { 134, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 503, null },
                    { 135, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image3.jpg", 503, null },
                    { 136, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 503, null },
                    { 137, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image1.jpg", 503, null },
                    { 138, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image4.jpg", 503, null },
                    { 139, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image5.jpg", 503, null },
                    { 140, 5, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/hotel1image2.jpg", 503, null },
                    { 141, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 1 },
                    { 142, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip2.jpg", null, 2 },
                    { 143, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip3.jpg", null, 3 },
                    { 144, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip4.jpg", null, 4 },
                    { 145, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip5.jpeg", null, 5 },
                    { 146, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip6.jpg", null, 6 },
                    { 147, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", null, 7 },
                    { 148, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip8.jpg", null, 8 },
                    { 149, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 9 },
                    { 150, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 10 },
                    { 151, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip3.jpg", null, 11 },
                    { 152, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 12 },
                    { 153, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip2.jpg", null, 13 },
                    { 154, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 14 },
                    { 155, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 15 },
                    { 156, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 16 },
                    { 157, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 17 },
                    { 158, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip5.jpg", null, 18 },
                    { 159, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 19 },
                    { 160, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 20 },
                    { 161, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 21 },
                    { 162, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 22 },
                    { 163, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 23 },
                    { 164, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 24 },
                    { 165, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", null, 25 },
                    { 166, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 26 },
                    { 167, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 27 },
                    { 168, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", null, 28 },
                    { 169, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 29 },
                    { 170, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 30 }
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
                name: "IX_Images_TripId",
                table: "Images",
                column: "TripId");

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
                name: "UPDATEBOOKINGTEMPs");

            migrationBuilder.DropTable(
                name: "UPDATEBOOKINGTRIPs");

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
