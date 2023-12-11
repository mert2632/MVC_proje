using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MertProje.Migrations
{
    /// <inheritdoc />
    public partial class MertProje2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ViewDataİletisimBilgileris_FirmailetisimBilgileris_FirmaAdresAdresID",
                table: "ViewDataİletisimBilgileris");

            migrationBuilder.DropForeignKey(
                name: "FK_ViewDataİletisimBilgileris_iletisimBilgileris_MusteriİletisimBilgileriIletisimID",
                table: "ViewDataİletisimBilgileris");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ViewDataİletisimBilgileris",
                table: "ViewDataİletisimBilgileris");

            migrationBuilder.RenameTable(
                name: "ViewDataİletisimBilgileris",
                newName: "GetViewDataİletisims");

            migrationBuilder.RenameIndex(
                name: "IX_ViewDataİletisimBilgileris_MusteriİletisimBilgileriIletisimID",
                table: "GetViewDataİletisims",
                newName: "IX_GetViewDataİletisims_MusteriİletisimBilgileriIletisimID");

            migrationBuilder.RenameIndex(
                name: "IX_ViewDataİletisimBilgileris_FirmaAdresAdresID",
                table: "GetViewDataİletisims",
                newName: "IX_GetViewDataİletisims_FirmaAdresAdresID");

            migrationBuilder.AddColumn<string>(
                name: "Personelİmage",
                table: "Personels",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MusteriİletisimBilgileriIletisimID",
                table: "GetViewDataİletisims",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GetViewDataİletisims",
                table: "GetViewDataİletisims",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_GetViewDataİletisims_FirmailetisimBilgileris_FirmaAdresAdresID",
                table: "GetViewDataİletisims",
                column: "FirmaAdresAdresID",
                principalTable: "FirmailetisimBilgileris",
                principalColumn: "AdresID");

            migrationBuilder.AddForeignKey(
                name: "FK_GetViewDataİletisims_iletisimBilgileris_MusteriİletisimBilgileriIletisimID",
                table: "GetViewDataİletisims",
                column: "MusteriİletisimBilgileriIletisimID",
                principalTable: "iletisimBilgileris",
                principalColumn: "IletisimID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GetViewDataİletisims_FirmailetisimBilgileris_FirmaAdresAdresID",
                table: "GetViewDataİletisims");

            migrationBuilder.DropForeignKey(
                name: "FK_GetViewDataİletisims_iletisimBilgileris_MusteriİletisimBilgileriIletisimID",
                table: "GetViewDataİletisims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GetViewDataİletisims",
                table: "GetViewDataİletisims");

            migrationBuilder.DropColumn(
                name: "Personelİmage",
                table: "Personels");

            migrationBuilder.RenameTable(
                name: "GetViewDataİletisims",
                newName: "ViewDataİletisimBilgileris");

            migrationBuilder.RenameIndex(
                name: "IX_GetViewDataİletisims_MusteriİletisimBilgileriIletisimID",
                table: "ViewDataİletisimBilgileris",
                newName: "IX_ViewDataİletisimBilgileris_MusteriİletisimBilgileriIletisimID");

            migrationBuilder.RenameIndex(
                name: "IX_GetViewDataİletisims_FirmaAdresAdresID",
                table: "ViewDataİletisimBilgileris",
                newName: "IX_ViewDataİletisimBilgileris_FirmaAdresAdresID");

            migrationBuilder.AlterColumn<int>(
                name: "MusteriİletisimBilgileriIletisimID",
                table: "ViewDataİletisimBilgileris",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ViewDataİletisimBilgileris",
                table: "ViewDataİletisimBilgileris",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ViewDataİletisimBilgileris_FirmailetisimBilgileris_FirmaAdresAdresID",
                table: "ViewDataİletisimBilgileris",
                column: "FirmaAdresAdresID",
                principalTable: "FirmailetisimBilgileris",
                principalColumn: "AdresID");

            migrationBuilder.AddForeignKey(
                name: "FK_ViewDataİletisimBilgileris_iletisimBilgileris_MusteriİletisimBilgileriIletisimID",
                table: "ViewDataİletisimBilgileris",
                column: "MusteriİletisimBilgileriIletisimID",
                principalTable: "iletisimBilgileris",
                principalColumn: "IletisimID");
        }
    }
}
