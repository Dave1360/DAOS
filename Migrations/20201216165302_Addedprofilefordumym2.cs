using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class Addedprofilefordumym2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "f224c54d-5f12-4039-9e9c-885ce77361a0", "f179b8f1-f3ff-406d-856e-e38b3cfbaf4d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4f628ac8-9387-4826-a267-3f3984d3b235", "cd185ff5-0c1a-483c-bbe2-c25a34d51c31" });

            migrationBuilder.InsertData(
                table: "profiles",
                columns: new[] { "ProfileId", "Address", "Birthday", "Description", "PhoneNumber" },
                values: new object[] { "730bf4e7-ee11-4e4f-af80-7c54a3541782", "DumDumStreet", new DateTime(2020, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 999999 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "profiles",
                keyColumn: "ProfileId",
                keyValue: "730bf4e7-ee11-4e4f-af80-7c54a3541782");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3de6a845-94eb-4a8c-982b-ec373c5f3f75", "5b8be408-6fa3-486e-afe6-8598c02b943e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "35afe91e-5a0d-4121-b33b-fd36a37c92bd", "bd697362-4345-403b-84b7-8f13d35aed4e" });
        }
    }
}
