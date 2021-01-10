using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class myDB1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5d1c11bf-cb24-4d24-82c9-71f931b5d292", "f301557f-f4c8-4ee1-9a2f-037dfae7a769" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "942f1f8a-5068-4154-b708-8282ed10d6b0", "89b55ca3-f424-42cf-9254-e50822a0d32c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "85cf5e9e-c848-493d-8cc3-930833eac53a", "7f77ed0e-c187-4b4c-bf04-d784fa2520bc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "493ace32-bac5-445a-9d85-629a3227c26f", "336e2222-ffb8-4b3b-9be9-0f315baffcc1" });
        }
    }
}
