using Microsoft.EntityFrameworkCore.Migrations;

namespace MusicDating.Data.Migrations
{
    public partial class AddedAgent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agent",
                columns: table => new
                {
                    AgentId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Level = table.Column<int>(maxLength: 1, nullable: false),
                    InstrumentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agent", x => x.AgentId);
                    table.ForeignKey(
                        name: "FK_Agent_Instruments_InstrumentId",
                        column: x => x.InstrumentId,
                        principalTable: "Instruments",
                        principalColumn: "InstrumentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agent_InstrumentId",
                table: "Agent",
                column: "InstrumentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agent");
        }
    }
}
