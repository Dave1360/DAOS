using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Migrations
{
    public partial class DataForUserInstrumentGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2d06960a-c286-4a92-9f40-a67a0e1eb3b3", "4c6c67ca-8a86-4582-8f67-4c3967adc592" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "45e8b9e5-9969-4567-9925-0448ce80c4c0", "10eb7456-0a7a-4243-a15e-1bc7c512e5e0" });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "GenreId", "Id", "InstrumentId" },
                values: new object[] { 1, 3, null, 2 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "GenreId", "Id", "InstrumentId" },
                values: new object[] { 2, 1, null, 1 });

            migrationBuilder.InsertData(
                table: "UserInstrumentGenres",
                columns: new[] { "UserInstrumentGenreId", "GenreId", "Id", "InstrumentId" },
                values: new object[] { 3, 2, null, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserInstrumentGenres",
                keyColumn: "UserInstrumentGenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserInstrumentGenres",
                keyColumn: "UserInstrumentGenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserInstrumentGenres",
                keyColumn: "UserInstrumentGenreId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e363604b-647b-4cde-8ba9-1c63b264f1ad", "8848b53b-d0d5-4408-b115-3f07b38d3510" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "93d7b3e4-1616-4005-9abd-68e98ee827e1", "830ff07c-8584-49fb-a484-4cd3c83d0e7b" });
        }
    }
}
