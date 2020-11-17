using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class SeedGenreEnsembles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9557b192-3427-4f7a-bf9f-7c37bc183dd7");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bdba4e31-7a7a-4970-8ee2-6f617c023372", 0, "e5e97346-81b2-4872-bfc8-70b22969a494", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kappa", false, null, null, null, null, null, false, "0b5a9362-52f4-4f23-a26c-e5d25ed28139", false, "Kappa" });

            migrationBuilder.InsertData(
                table: "GenreEnsembles",
                columns: new[] { "GenreId", "EnsembleId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "GenreEnsembles",
                columns: new[] { "GenreId", "EnsembleId" },
                values: new object[] { 2, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdba4e31-7a7a-4970-8ee2-6f617c023372");

            migrationBuilder.DeleteData(
                table: "GenreEnsembles",
                keyColumns: new[] { "GenreId", "EnsembleId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GenreEnsembles",
                keyColumns: new[] { "GenreId", "EnsembleId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9557b192-3427-4f7a-bf9f-7c37bc183dd7", 0, "f6e36f0b-761e-44b3-a89c-f2e69cd99973", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kappa", false, null, null, null, null, null, false, "f2138c7f-44ce-4226-8493-fa516e9fb871", false, "Kappa" });
        }
    }
}
