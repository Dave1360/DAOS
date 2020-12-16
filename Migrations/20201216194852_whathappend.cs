using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class whathappend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3eda1972-2244-403b-b2bc-e71027733be4", "6b9105e4-eb26-40d8-bb00-7d015bd08043" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "29232cdb-17bf-4272-a19e-540438b50e1e", "ebdc1b39-37eb-4825-aa82-b838eb11caec" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
