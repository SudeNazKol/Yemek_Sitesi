using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace yemekSitesi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tarifler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YemekAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kategori = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Malzemeler = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Talimatlar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResimPath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yorumlar",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdSoyad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YorumMetni = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorumlar", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifler");

            migrationBuilder.DropTable(
                name: "Yorumlar");
        }
    }
}
