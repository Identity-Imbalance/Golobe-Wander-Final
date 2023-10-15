﻿// <auto-generated />
using System;
using Globe_Wander_Final.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Globe_Wander_Final.Migrations
{
    [DbContext(typeof(GlobeWanderDbContext))]
    [Migration("20231013164109_seedingData")]
    partial class seedingData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Globe_Wander_Final.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "830558fd-4f00-4cfc-b645-b6c88bad570b",
                            Email = "User@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAIAAYagAAAAEN3t4UEjdbRu3S6wOeduYBnZMswR5mh86BXRErD8wb9NxbqLRxKnMHf/n47dImTEiw==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "f7083b7a-3a29-40ed-a726-71e47e6a51a6",
                            TwoFactorEnabled = false,
                            UserName = "User"
                        },
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5dce36b9-dd3b-46cc-8fd1-093d3d002d90",
                            Email = "adminUser@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "adminUser@EXAMPLE.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEN3LG2VVs67KZIVpQeqpYVetrq6Vs4JPvejI7ixyb50H8w1iDt8+8xy8N/IF+8fL5w==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "e35cf9b9-35ee-4a26-874b-b01b1e9281ab",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        },
                        new
                        {
                            Id = "3",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c6392281-2cd8-468c-992d-3908686029b0",
                            Email = "trip@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "trip@EXAMPLE.COM",
                            NormalizedUserName = "TRIP",
                            PasswordHash = "AQAAAAIAAYagAAAAENHDSBsX9wjeau0VhvT+/CmvAcRrm+lw/zZyT8Xf0N8XoLa15uKVdf5q+EUizS4Zmw==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b190afb2-8eaf-49ef-aa7c-eb12751d20fe",
                            TwoFactorEnabled = false,
                            UserName = "trip"
                        },
                        new
                        {
                            Id = "2",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5af802d6-6781-4cb1-b05e-da850fcc9b8b",
                            Email = "hotel@example.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "hotel@EXAMPLE.COM",
                            NormalizedUserName = "HOTEL",
                            PasswordHash = "AQAAAAIAAYagAAAAEP7Y8cGl4Ew0iwfJFq4m7VQgrsQVly/m+FBsfe9aF7O8TK4QqWZcVch+Sa5gjaMNoA==",
                            PhoneNumber = "1234567890",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2c699aef-7a1f-4f24-9bcc-2f26e385acbc",
                            TwoFactorEnabled = false,
                            UserName = "hotel"
                        });
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.BookingRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("HotelID", "RoomNumber")
                        .IsUnique();

                    b.ToTable("BookingRooms");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.BookingTrip", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<decimal>("CostPerPerson")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfPersons")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("TripID");

                    b.ToTable("bookingTrips");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TourSpotID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourSpotID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A unique hotel that you can't find in this place",
                            Name = "Paradise",
                            TourSpotID = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "A unique hotel that you can't find in this place",
                            Name = "Wander ",
                            TourSpotID = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "A unique hotel that y    ou can't find in this place",
                            Name = "Amazing",
                            TourSpotID = 3
                        });
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.Property<bool>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<decimal>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("HotelID", "RoomNumber");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Rate", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Comments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int>("TripID")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("TripID");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 2,
                            Name = "Small Room"
                        },
                        new
                        {
                            ID = 2,
                            Layout = 3,
                            Name = "Suite Room"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 1,
                            Name = "Studio room"
                        });
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.TourSpot", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("Category")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TourSpots");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Category = 3,
                            City = "Petra",
                            Country = "Jordan",
                            Description = "a place before thousands years",
                            Name = "Petra",
                            PhoneNumber = "078885423"
                        },
                        new
                        {
                            ID = 2,
                            Category = 3,
                            City = "Jerash",
                            Country = "Jordan",
                            Description = "A historical place that the Romanian civilization build before thousands years.",
                            Name = "Jerash",
                            PhoneNumber = "088782215"
                        },
                        new
                        {
                            ID = 3,
                            Category = 3,
                            City = "Irbid",
                            Country = "Jordan",
                            Description = "A historical place that the Romanian civilization build before thousands years. In the north of Jordan",
                            Name = "Um Qais",
                            PhoneNumber = "0788442521"
                        },
                        new
                        {
                            ID = 4,
                            Category = 4,
                            City = "Aqaba",
                            Country = "Jordan",
                            Description = "A spectacular desert in southern Jordan.",
                            Name = "Wadi Rum",
                            PhoneNumber = "0788555444"
                        },
                        new
                        {
                            ID = 5,
                            Category = 3,
                            City = "Ajloun",
                            Country = "Jordan",
                            Description = "A 12th-century Muslim castle in northern Jordan.",
                            Name = "Ajloun Castle",
                            PhoneNumber = "0799111122"
                        },
                        new
                        {
                            ID = 6,
                            Category = 4,
                            City = "Amman",
                            Country = "Jordan",
                            Description = "The lowest point on Earth and famous for its high salt content.",
                            Name = "Dead Sea",
                            PhoneNumber = "0777888999"
                        },
                        new
                        {
                            ID = 7,
                            Category = 4,
                            City = "Aqaba",
                            Country = "Jordan",
                            Description = "Beautiful beaches along the Red Sea.",
                            Name = "Aqaba Beach",
                            PhoneNumber = "0799777666"
                        },
                        new
                        {
                            ID = 8,
                            Category = 3,
                            City = "Madaba",
                            Country = "Jordan",
                            Description = "Ancient hilltop fortress where John the Baptist was imprisoned.",
                            Name = "Machaerus",
                            PhoneNumber = "0777666555"
                        },
                        new
                        {
                            ID = 9,
                            Category = 4,
                            City = "Tafilah",
                            Country = "Jordan",
                            Description = "A diverse ecological system in southern Jordan.",
                            Name = "Dana Biosphere Reserve",
                            PhoneNumber = "0799888777"
                        });
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Trip", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Activity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourSpotID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TourSpotID");

                    b.ToTable("Trips");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Activity = "walking",
                            Capacity = 30,
                            Cost = 20m,
                            Count = 0,
                            Description = "trip start at 8 am and going from Amman to Petra",
                            EndDate = new DateTime(2023, 10, 13, 16, 41, 8, 893, DateTimeKind.Utc).AddTicks(6910),
                            Name = "Petra ride",
                            StartDate = new DateTime(2023, 10, 13, 19, 41, 8, 893, DateTimeKind.Local).AddTicks(6898),
                            TourSpotID = 1
                        },
                        new
                        {
                            Id = 2,
                            Activity = "visiting",
                            Capacity = 22,
                            Cost = 30m,
                            Count = 0,
                            Description = "Amman to Jerash with a trip manager who can speak many languages",
                            EndDate = new DateTime(2023, 10, 13, 16, 41, 8, 893, DateTimeKind.Utc).AddTicks(6913),
                            Name = "Jerash ride",
                            StartDate = new DateTime(2023, 10, 13, 19, 41, 8, 893, DateTimeKind.Local).AddTicks(6912),
                            TourSpotID = 2
                        },
                        new
                        {
                            Id = 3,
                            Activity = "climbing",
                            Capacity = 40,
                            Cost = 40m,
                            Count = 0,
                            Description = "Amman to Irbid with a trip manager who can speak many languages",
                            EndDate = new DateTime(2023, 10, 13, 16, 41, 8, 893, DateTimeKind.Utc).AddTicks(6915),
                            Name = "Um-Qais ride",
                            StartDate = new DateTime(2023, 10, 13, 19, 41, 8, 893, DateTimeKind.Local).AddTicks(6914),
                            TourSpotID = 3
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "admin manager",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Admin Manager",
                            NormalizedName = "ADMIN MANAGER"
                        },
                        new
                        {
                            Id = "trip manager",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Trip Manager",
                            NormalizedName = "TRIP MANAGER"
                        },
                        new
                        {
                            Id = "hotel manager",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "Hotel Manager",
                            NormalizedName = "HOTEL MANAGER"
                        },
                        new
                        {
                            Id = "user",
                            ConcurrencyStamp = "00000000-0000-0000-0000-000000000000",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "admin manager"
                        },
                        new
                        {
                            UserId = "2",
                            RoleId = "hotel manager"
                        },
                        new
                        {
                            UserId = "3",
                            RoleId = "trip manager"
                        },
                        new
                        {
                            UserId = "4",
                            RoleId = "user"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.BookingRoom", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.HotelRoom", "HotelRooms")
                        .WithOne("BookingRoom")
                        .HasForeignKey("Globe_Wander_Final.Models.BookingRoom", "HotelID", "RoomNumber")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("HotelRooms");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.BookingTrip", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.Trip", "Trip")
                        .WithMany("BookingTrips")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Hotel", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.TourSpot", "TourSpot")
                        .WithMany("Hotels")
                        .HasForeignKey("TourSpotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourSpot");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.HotelRoom", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Globe_Wander_Final.Models.Room", "Rooms")
                        .WithMany("HotelRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Rate", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.Trip", "Trip")
                        .WithMany("Rates")
                        .HasForeignKey("TripID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trip");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Trip", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.TourSpot", "TourSpots")
                        .WithMany("Trips")
                        .HasForeignKey("TourSpotID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TourSpots");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Globe_Wander_Final.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Globe_Wander_Final.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Hotel", b =>
                {
                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.HotelRoom", b =>
                {
                    b.Navigation("BookingRoom");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Room", b =>
                {
                    b.Navigation("HotelRooms");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.TourSpot", b =>
                {
                    b.Navigation("Hotels");

                    b.Navigation("Trips");
                });

            modelBuilder.Entity("Globe_Wander_Final.Models.Trip", b =>
                {
                    b.Navigation("BookingTrips");

                    b.Navigation("Rates");
                });
#pragma warning restore 612, 618
        }
    }
}