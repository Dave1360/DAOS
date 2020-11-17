using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class userInstruments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bdba4e31-7a7a-4970-8ee2-6f617c023372");

            migrationBuilder.CreateTable(
                name: "UserInstruments",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    InstrumentId = table.Column<int>(nullable: false),
                    Level = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInstruments", x => new { x.Id, x.InstrumentId });
                    table.ForeignKey(
                        name: "FK_UserInstruments_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserInstruments_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ff2b68b9-f640-4974-b788-994b4ea20626", 0, "0e800ca9-ba6d-4ca2-a88c-5a449c8498de", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kappa", false, null, null, null, null, null, false, "17b36cc8-5c08-428b-bf2d-b97a744ba971", false, "Kappa" });

            migrationBuilder.CreateIndex(
                name: "IX_UserInstruments_InstrumentId",
                table: "UserInstruments",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserInstruments");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ff2b68b9-f640-4974-b788-994b4ea20626");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateCreated", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "bdba4e31-7a7a-4970-8ee2-6f617c023372", 0, "e5e97346-81b2-4872-bfc8-70b22969a494", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Kappa", false, null, null, null, null, null, false, "0b5a9362-52f4-4f23-a26c-e5d25ed28139", false, "Kappa" });
        }
    }
}
