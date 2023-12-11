using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MertProje.Migrations
{
    /// <inheritdoc />
    public partial class mert11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirmaAdres",
                table: "FirmailetisimBilgileris",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirmaHarita",
                table: "FirmailetisimBilgileris",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirmaAdres",
                table: "FirmailetisimBilgileris");

            migrationBuilder.DropColumn(
                name: "FirmaHarita",
                table: "FirmailetisimBilgileris");
        }
    }
}
