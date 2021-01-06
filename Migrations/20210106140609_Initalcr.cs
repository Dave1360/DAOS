using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class Initalcr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d4872b3e-1500-4b3d-8110-2c59a4091f29", "fc457925-053b-495c-8a2a-345acdf9fbc9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "946e0080-d0b6-4a1d-beb3-d2844511bc0e", "087c9ebe-66ec-49f8-b80b-a4049bcb939d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d9684bab-9f27-412c-b54c-1def725c0a49", "07fe8aa9-87bb-4d14-8d86-920340332e75" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b8e1bb77-bbb0-4f02-b1ff-3f6c4fcb64d6", "2b699b3f-c11d-40db-a4cd-97457eeed84a" });
        }
    }
}
