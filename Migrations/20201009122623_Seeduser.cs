using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class Seeduser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9557b192-3427-4f7a-bf9f-7c37bc183dd7", 0, "f6e36f0b-761e-44b3-a89c-f2e69cd99973", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kappa", false, null, null, null, null, null, false, "f2138c7f-44ce-4226-8493-fa516e9fb871", false, "Kappa" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9557b192-3427-4f7a-bf9f-7c37bc183dd7");
        }
    }
}
