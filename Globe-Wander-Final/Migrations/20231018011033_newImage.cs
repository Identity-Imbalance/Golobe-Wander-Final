using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Globe_Wander_Final.Migrations
{
    /// <inheritdoc />
    public partial class newImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "627988e8-c6d0-45b4-83ca-b809ac3fcd52", "AQAAAAIAAYagAAAAEM4vwgLiWuuUy6cwkWBOimIfTUpB2yn7VaACQ4su7hkwnMkp8Kj3GlS6+lIIDbL36Q==", "740b143e-0953-44dc-97cc-6b7d75353008" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a3e8b234-eac6-48c9-9afb-016e6393888f", "AQAAAAIAAYagAAAAEMCWiiJyAfFrvB1IjnyrQxE5yZKDNGAiCQY4dYEctuGyNhh4KmdTCZg2K4aCx+qthQ==", "ed624474-78da-441b-afac-193d39ec3fb3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "194f7c19-1835-452f-ab38-54ea0910815a", "AQAAAAIAAYagAAAAEGhmeWuusdL3Hd7P4ITaEzaUaS+MqrEjYUotbmZ+vlqmZX9OsaQhDSFqlNDfxFLKFg==", "d6b642f8-d195-4081-ad4f-564de3cf431d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5c3f3c8e-c817-4d46-ba0a-ab7f840b32d8", "AQAAAAIAAYagAAAAEKi8tRu68huSRsnXmkVaNWEcEM6rLeR4dhVjr4jLvXLclM/WNmtd89Y/LVkHBSo4+g==", "bfe57859-343b-4b9f-9318-8ece31718518" });

            migrationBuilder.UpdateData(
                table: "TourSpots",
                keyColumn: "ID",
                keyValue: 7,
                column: "Img",
                value: "https://wallpapers.com/images/high/aqaba-jordan-shoreline-y69cto406g6r0i5c.webp");

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 1, 10, 32, 624, DateTimeKind.Utc).AddTicks(2328), new DateTime(2023, 10, 18, 4, 10, 32, 624, DateTimeKind.Local).AddTicks(2306) });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 1, 10, 32, 624, DateTimeKind.Utc).AddTicks(2331), new DateTime(2023, 10, 18, 4, 10, 32, 624, DateTimeKind.Local).AddTicks(2330) });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 1, 10, 32, 624, DateTimeKind.Utc).AddTicks(2333), new DateTime(2023, 10, 18, 4, 10, 32, 624, DateTimeKind.Local).AddTicks(2333) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4f68d5e8-fe68-43c5-906a-e76794448569", "AQAAAAIAAYagAAAAEPDjnk5+934oL0b/Uj98Th1ZmrbA4rL76cibueEQW7vrrM4Bq97CvbItKO6Alw7t+w==", "22feffd2-0df5-443d-893d-244843a78cdc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6417503f-e6de-46ed-b1b2-23a30aa53511", "AQAAAAIAAYagAAAAEM2MKcumev2NgDRXZ2cAOXujLXTPC3fEKtXUnAPPjZvS7YpukQPNq0B7hg3Ai/U3NA==", "11cd9828-6056-4cb4-b869-e9e163da4851" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f42f5196-aaf4-4b1e-811b-bd5176ba63b2", "AQAAAAIAAYagAAAAEF3SRfox8qZNAOfDXfe3vx6llaN9Oa+sCI8RzrpJDaF2xB6AxBos2f0uP7tzoCTVuA==", "1c5b0ab4-2d03-4d44-82c2-be7620a82e81" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7e756691-59ca-4e22-9147-b57f8a651ebf", "AQAAAAIAAYagAAAAEH3WH+KvJxji7GQJOXo+D2WO8BdgA8DhoFviGQRtCN1D+EqphKeJSbUzUcCv595QUg==", "4aced850-8bb6-464b-9860-360f78d07eeb" });

            migrationBuilder.UpdateData(
                table: "TourSpots",
                keyColumn: "ID",
                keyValue: 7,
                column: "Img",
                value: "https://wallpapers.com/wallpapers/aqaba-jordan-shoreline-y69cto406g6r0i5c.html");

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 1, 4, 41, 184, DateTimeKind.Utc).AddTicks(2614), new DateTime(2023, 10, 18, 4, 4, 41, 184, DateTimeKind.Local).AddTicks(2602) });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 1, 4, 41, 184, DateTimeKind.Utc).AddTicks(2618), new DateTime(2023, 10, 18, 4, 4, 41, 184, DateTimeKind.Local).AddTicks(2617) });

            migrationBuilder.UpdateData(
                table: "Trips",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 18, 1, 4, 41, 184, DateTimeKind.Utc).AddTicks(2620), new DateTime(2023, 10, 18, 4, 4, 41, 184, DateTimeKind.Local).AddTicks(2619) });
        }
    }
}
