using Microsoft.EntityFrameworkCore.Migrations;

namespace Tarea3_Bandas_Musicales.Data.Migrations
{
    public partial class AddBandasMusicales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bandas_Musicales",
                columns: table => new
                {
                    BandaM_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BandaM_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandaM_Musical_Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandaM_YearOfCreation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BandaM_Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bandas_Musicales", x => x.BandaM_Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bandas_Musicales");
        }
    }
}
