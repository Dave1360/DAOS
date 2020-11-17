using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2b68b9-f640-4974-b788-994b4ea20626");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, "b1a267d9-a91b-4a26-a15b-1040c37d8958", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kappa", false, null, null, null, null, null, false, "559dea72-e907-4211-973c-016b59c2b55e", false, "Kappa" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "2", 0, "c8f1a3e2-63c0-4f5e-b750-d9b66de2f7fc", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Dummy", false, null, null, null, null, null, false, "741feae1-656a-4cad-bdad-8e45edf39f82", false, "Dummy" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 1, "Drums" });

            migrationBuilder.InsertData(
                table: "Instruments",
                columns: new[] { "InstrumentId", "Name" },
                values: new object[] { 2, "Guitar" });

            migrationBuilder.InsertData(
                table: "UserInstruments",
                columns: new[] { "Id", "InstrumentId", "Level" },
                values: new object[] { "1", 1, 0 });

            migrationBuilder.InsertData(
                table: "UserInstruments",
                columns: new[] { "Id", "InstrumentId", "Level" },
                values: new object[] { "2", 2, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInstruments",
                keyColumns: new[] { "Id", "InstrumentId" },
                keyValues: new object[] { "1", 1 });

            migrationBuilder.DeleteData(
                table: "UserInstruments",
                keyColumns: new[] { "Id", "InstrumentId" },
                keyValues: new object[] { "2", 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Instruments",
                keyColumn: "InstrumentId",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ff2b68b9-f640-4974-b788-994b4ea20626", 0, "0e800ca9-ba6d-4ca2-a88c-5a449c8498de", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kappa", false, null, null, null, null, null, false, "17b36cc8-5c08-428b-bf2d-b97a744ba971", false, "Kappa" });
        }
    }
}
