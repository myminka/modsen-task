using Microsoft.EntityFrameworkCore.Migrations;

namespace ModsenTask.Services.EntityFrameworkCore.Events.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "eventDatas",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 40, nullable: false),
                    discription = table.Column<string>(type: "ntext", nullable: true),
                    organiser = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_eventDatas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "addresses",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    country = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    street = table.Column<string>(nullable: true),
                    house_number = table.Column<int>(nullable: false),
                    event_data_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_addresses", x => x.id);
                    table.ForeignKey(
                        name: "FK_addresses_eventDatas_event_data_id",
                        column: x => x.event_data_id,
                        principalTable: "eventDatas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_addresses_event_data_id",
                table: "addresses",
                column: "event_data_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "addresses");

            migrationBuilder.DropTable(
                name: "eventDatas");
        }
    }
}
