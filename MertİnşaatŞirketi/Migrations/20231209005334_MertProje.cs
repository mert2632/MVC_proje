using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MertProje.Migrations
{
    /// <inheritdoc />
    public partial class MertProje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ViewDataİletisimBilgileris",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirmaAdresAdresID = table.Column<int>(type: "INTEGER", nullable: true),
                    MusteriİletisimBilgileriIletisimID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewDataİletisimBilgileris", x => x.id);
                    table.ForeignKey(
                        name: "FK_ViewDataİletisimBilgileris_FirmailetisimBilgileris_FirmaAdresAdresID",
                        column: x => x.FirmaAdresAdresID,
                        principalTable: "FirmailetisimBilgileris",
                        principalColumn: "AdresID");
                    table.ForeignKey(
                        name: "FK_ViewDataİletisimBilgileris_iletisimBilgileris_MusteriİletisimBilgileriIletisimID",
                        column: x => x.MusteriİletisimBilgileriIletisimID,
                        principalTable: "iletisimBilgileris",
                        principalColumn: "IletisimID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ViewDataİletisimBilgileris_FirmaAdresAdresID",
                table: "ViewDataİletisimBilgileris",
                column: "FirmaAdresAdresID");

            migrationBuilder.CreateIndex(
                name: "IX_ViewDataİletisimBilgileris_MusteriİletisimBilgileriIletisimID",
                table: "ViewDataİletisimBilgileris",
                column: "MusteriİletisimBilgileriIletisimID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ViewDataİletisimBilgileris");
        }
    }
}
