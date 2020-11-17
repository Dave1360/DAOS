using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class Level : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "5ebc9c56-7dec-4089-96c5-b614676f19e8", "3da83c5f-2f1b-407e-9094-f1a85bf95172" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6c480962-395b-46f6-84ec-bcd2d1e65725", "84e260e5-c4c9-4b66-a9ce-f49567169310" });

            migrationBuilder.UpdateData(
                table: "UserInstruments",
                keyColumns: new[] { "Id", "InstrumentId" },
                keyValues: new object[] { "1", 1 },
                column: "Level",
                value: 5);

            migrationBuilder.UpdateData(
                table: "UserInstruments",
                keyColumns: new[] { "Id", "InstrumentId" },
                keyValues: new object[] { "2", 2 },
                column: "Level",
                value: 2);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b1a267d9-a91b-4a26-a15b-1040c37d8958", "559dea72-e907-4211-973c-016b59c2b55e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8f1a3e2-63c0-4f5e-b750-d9b66de2f7fc", "741feae1-656a-4cad-bdad-8e45edf39f82" });

            migrationBuilder.UpdateData(
                table: "UserInstruments",
                keyColumns: new[] { "Id", "InstrumentId" },
                keyValues: new object[] { "1", 1 },
                column: "Level",
                value: 0);

            migrationBuilder.UpdateData(
                table: "UserInstruments",
                keyColumns: new[] { "Id", "InstrumentId" },
                keyValues: new object[] { "2", 2 },
                column: "Level",
                value: 0);
        }
    }
}
