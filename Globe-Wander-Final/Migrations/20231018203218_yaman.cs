﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Globe_Wander_Final.Migrations
{
    /// <inheritdoc />
    public partial class yaman : Migration
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
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "95d3f8b2-bbd0-4c2f-a067-b2aadc5ef92d", "adminUser@example.com", true, false, null, "adminUser@EXAMPLE.COM", "ADMIN", "AQAAAAIAAYagAAAAEN6uLgsCUsUj+RUFLU/r66kZtlxltHIR4BT73kE2yUTi108BM/GtNDiebkL/NbyU5A==", "1234567890", false, "139e0233-db61-433c-8c97-330a33d53c55", false, "admin" },
                    { "2", 0, "633f4c03-cc82-4ba9-b010-b6828277d15e", "hotel@example.com", true, false, null, "hotel@EXAMPLE.COM", "HOTEL", "AQAAAAIAAYagAAAAEGQzAeYBbeCo25qAWRcvta9OsQW+JoSMbNf24TNwdPYTzCJPGngT+LPWeNlamPXGcA==", "1234567890", false, "52950858-12e8-4e0a-bd4d-6c5021c93b2d", false, "hotel" },
                    { "3", 0, "9c885de9-1251-42c4-8a1e-38618e423508", "trip@example.com", true, false, null, "trip@EXAMPLE.COM", "TRIP", "AQAAAAIAAYagAAAAENas0l+UpindlZcSW7pQhD2988+C8h3kXSsznWA+MERYaqH95NMa01yKkB4GCAu9IQ==", "1234567890", false, "60bbbfaf-87b0-44b9-813e-b8b5a7324b3f", false, "trip" },
                    { "4", 0, "2c8298b9-9327-4be5-9006-4e84d3b9cee2", "User@example.com", true, false, null, null, "USER", "AQAAAAIAAYagAAAAEItjtZOIJ1f+FzPShegU1EDqlg2pll5ti9Djndv390Kd+/W9YyoXHJo+c2Xh4INS1A==", "1234567890", false, "fe94afd5-bcdb-4b88-813b-66b72cb0b68c", false, "User" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "swimingpool11111" },
                    { 2, "swimingpool22222" },
                    { 3, "swimingpool33333" }
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
                    { 1, 3, "Petra", "Jordan", "a place before thousands years", "https://images.pexels.com/photos/1631665/pexels-photo-1631665.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1", "Petra", "078885423" },
                    { 2, 3, "Jerash", "Jordan", "A historical place that the Romanian civilization build before thousands years.", "https://c0.wallpaperflare.com/preview/705/707/822/jordan-jerash-oval-plaza-market.jpg", "Jerash", "088782215" },
                    { 3, 3, "Irbid", "Jordan", "A historical place that the Romanian civilization build before thousands years. In the north of Jordan", "https://followinghadrianphotographycom.files.wordpress.com/2020/09/34509636386_2139ee3bc1_k.jpg?w=1075&h=712", "Um Qais", "0788442521" },
                    { 4, 4, "Aqaba", "Jordan", "A spectacular desert in southern Jordan.", "https://c4.wallpaperflare.com/wallpaper/774/140/860/nature-landscape-sand-desert-dunes-hd-wallpaper-preview.jpg", "Wadi Rum", "0788555444" },
                    { 5, 3, "Ajloun", "Jordan", "A 12th-century Muslim castle in northern Jordan.", "https://as1.ftcdn.net/v2/jpg/02/49/78/08/1000_F_249780853_qBrIwoai4WNGR0OSx4I6A3EZZ47cUN5B.jpg", "Ajloun Castle", "0799111122" },
                    { 6, 4, "Amman", "Jordan", "The lowest point on Earth and famous for its high salt content.", "https://c4.wallpaperflare.com/wallpaper/884/827/830/dead-sea-coast-white-salt-blue-sea-wallpaper-preview.jpg", "Dead Sea", "0777888999" },
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
                    { 1, "A unique hotel that you can't find in this place", null, "petra", "Paradise", 4, 1 },
                    { 2, "A unique hotel that you can't find in this place", null, "petra", "Wander ", 4, 2 },
                    { 3, "A unique hotel that y    ou can't find in this place", null, "petra", "Amazing", 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoomAmenities",
                columns: new[] { "Id", "AmenityId", "RoomId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Trips",
                columns: new[] { "Id", "Activity", "Capacity", "Cost", "Count", "Description", "EndDate", "Name", "StartDate", "TourSpotID" },
                values: new object[,]
                {
                    { 1, "walking", 30, 20m, 0, "trip start at 8 am and going from Amman to Petra", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7944), "Petra ride", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7915), 1 },
                    { 2, "visiting", 22, 30m, 0, "Amman to Jerash with a trip manager who can speak many languages", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7949), "Jerash ride", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7948), 1 },
                    { 3, "climbing", 40, 40m, 0, "Amman to Irbid with a trip manager who can speak many languages", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7953), "Um-Qais ride", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7952), 1 },
                    { 4, "desert safari", 20, 50m, 0, "Explore the breathtaking Wadi Rum desert in Jordan.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7957), "Wadi Rum Adventure", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7955), 2 },
                    { 5, "swimming and mud baths", 15, 25m, 0, "Relax at the world-famous Dead Sea and experience its healing properties.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7960), "Dead Sea Relaxation", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7959), 2 },
                    { 6, "scuba diving", 10, 60m, 0, "Discover the vibrant marine life of the Red Sea in Aqaba.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7964), "Aqaba Diving Expedition", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7963), 2 },
                    { 7, "sightseeing", 25, 15m, 0, "Explore the historical and cultural landmarks of Amman.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7967), "Amman City Tour", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7966), 3 },
                    { 8, "hiking", 12, 35m, 0, "Trek through the stunning Dana Biosphere Reserve.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7971), "Dana Biosphere Reserve Hike", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7970), 3 },
                    { 9, "canyoning", 18, 45m, 0, "Experience the adventure of canyoning in Wadi Mujib.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7975), "Wadi Mujib Canyoning", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7973), 3 },
                    { 10, "relaxation", 30, 20m, 0, "Relax in the soothing hot springs of Ma'in.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7980), "Ma'in Hot Springs Visit", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7977), 4 },
                    { 11, "historical tour", 20, 25m, 0, "Explore the historic Kerak Castle in Jordan.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7985), "Kerak Castle Tour", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7984), 4 },
                    { 12, "nature walk", 15, 30m, 0, "Take a nature walk in the Ajloun Forest Reserve.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7988), "Ajloun Forest Reserve Trek", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7987), 4 },
                    { 13, "food tasting", 12, 40m, 0, "Indulge in a culinary journey through Amman's cuisine.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(7991), "Amman Culinary Tour", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(7990), 4 },
                    { 14, "mosaic art", 25, 20m, 0, "Discover the mosaic art of Madaba.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8005), "Mosaic City Madaba", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8004), 4 },
                    { 15, "historical tour", 18, 30m, 0, "Explore the historic Ajloun Castle.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8008), "Ajloun Castle Exploration", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8007), 4 },
                    { 16, "beach relaxation", 20, 55m, 0, "Relax on the beautiful beaches of Aqaba.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8012), "Aqaba Beach Getaway", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8011), 5 },
                    { 17, "snorkeling", 15, 40m, 0, "Explore the underwater world of the Red Sea through snorkeling in Aqaba.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8016), "Aqaba Snorkeling Adventure", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8015), 5 },
                    { 18, "boat tour", 25, 30m, 0, "View marine life through a glass-bottom boat tour in Aqaba.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8070), "Aqaba Glass-Bottom Boat Tour", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8069), 5 },
                    { 19, "desert adventure", 12, 45m, 0, "Embark on an exciting jeep safari in the Aqaba desert.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8073), "Aqaba Desert Jeep Safari", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8072), 6 },
                    { 20, "nightclub hopping", 20, 25m, 0, "Experience the vibrant nightlife of Aqaba.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8077), "Aqaba Nightlife Tour", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8076), 6 },
                    { 21, "historical tour", 15, 60m, 0, "Explore the iconic Pyramids of Giza in Egypt.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8082), "Pyramids of Giza Tour", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8081), 6 },
                    { 22, "theater", 18, 60m, 0, "Attend a Broadway show in the heart of New York City.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8086), "Broadway Show Experience", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8085), 7 },
                    { 23, "museum visit", 20, 30m, 0, "Explore the museums along Museum Mile.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8090), "Museum Mile Tour", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8089), 7 },
                    { 24, "walking tour", 35, 20m, 0, "Take a scenic walk across the historic Brooklyn Bridge.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8093), "Brooklyn Bridge Walk", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8092), 7 },
                    { 25, "sightseeing", 30, 35m, 0, "Enjoy panoramic views from the Empire State Building.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8100), "Empire State Building Observation Deck", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8099), 8 },
                    { 26, "boat tour", 25, 45m, 0, "Cruise along the Hudson River and see Manhattan's skyline.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8104), "Hudson River Boat Tour", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8103), 8 },
                    { 27, "cultural tour", 20, 45m, 0, "Immerse in the rich culture of Ubud, Bali.", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8107), "Ubud Cultural Experience", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8106), 8 },
                    { 28, "snorkeling", 30, 60m, 0, "Explore the vibrant marine life of the Red Sea in Aqaba", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8110), "Red Sea Adventure", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8110), 9 },
                    { 29, "off-roading", 20, 50m, 0, "Experience the thrill of a desert adventure in Aqaba", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8114), "Desert Safari", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8113), 9 },
                    { 30, "scuba diving", 15, 70m, 0, "Discover submerged historical sites in the Red Sea", new DateTime(2023, 10, 18, 20, 32, 17, 731, DateTimeKind.Utc).AddTicks(8164), "Historical Dive", new DateTime(2023, 10, 18, 23, 32, 17, 731, DateTimeKind.Local).AddTicks(8131), 9 }
                });

            migrationBuilder.InsertData(
                table: "HotelFacilities",
                columns: new[] { "Id", "FacilityId", "HotelId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 1, 2 },
                    { 3, 2, 3 },
                    { 4, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomNumber", "Bathrooms", "Beds", "Description", "IsAvailable", "PricePerDay", "RoomID", "SquareFeet" },
                values: new object[,]
                {
                    { 1, 101, 2, 3, "CLEAN", true, 100m, 1, 250 },
                    { 1, 102, 2, 3, "CLEAN", true, 150m, 2, 250 },
                    { 2, 201, 2, 3, "CLEAN", false, 120m, 1, 250 }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "HotelId", "HotelRoomHotelID", "HotelRoomRoomNumber", "Path", "RoomNumber", "TripId" },
                values: new object[,]
                {
                    { 1, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 1 },
                    { 2, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip2.jpg", null, 2 },
                    { 3, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip3.jpg", null, 3 },
                    { 4, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip4.png", null, 4 },
                    { 5, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip5.jpg", null, 5 },
                    { 6, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip6.jpg", null, 6 },
                    { 7, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", null, 7 },
                    { 8, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip8.jpg", null, 8 },
                    { 9, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 9 },
                    { 10, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 10 },
                    { 11, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip30.jpg", null, 11 },
                    { 12, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip31.jpg", null, 12 },
                    { 13, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip32.jpg", null, 13 },
                    { 14, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 14 },
                    { 15, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 15 },
                    { 16, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 16 },
                    { 17, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 17 },
                    { 18, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip5.jpg", null, 18 },
                    { 19, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 19 },
                    { 20, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 20 },
                    { 21, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 21 },
                    { 22, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip9.jpg", null, 22 },
                    { 23, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 23 },
                    { 24, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 24 },
                    { 25, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", null, 25 },
                    { 26, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 26 },
                    { 27, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 27 },
                    { 28, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip7.png", null, 28 },
                    { 29, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip10.jpg", null, 29 },
                    { 30, null, null, null, "https://globewanderimages.blob.core.windows.net/globe-wander-images/trip1.jpg", null, 30 }
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
