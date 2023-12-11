using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MertProje.Migrations
{
    /// <inheritdoc />
    public partial class mert2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "admins",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    password = table.Column<string>(type: "TEXT", nullable: false),
                    confirmpassword = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "anasayfas",
                columns: table => new
                {
                    AnasayfaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Anasayfaİmage1 = table.Column<string>(type: "TEXT", nullable: true),
                    Anasayfaİmage2 = table.Column<string>(type: "TEXT", nullable: true),
                    AnasayfaBaşlık1 = table.Column<string>(type: "TEXT", nullable: true),
                    AnasayfaBaşlık2 = table.Column<string>(type: "TEXT", nullable: true),
                    AnasayfaAçıklama1 = table.Column<string>(type: "TEXT", nullable: true),
                    AnasayfaAçıklama2 = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anasayfas", x => x.AnasayfaID);
                });

            migrationBuilder.CreateTable(
                name: "blogs",
                columns: table => new
                {
                    BlogID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Blogİmage = table.Column<string>(type: "TEXT", nullable: true),
                    BlogBaşlık = table.Column<string>(type: "TEXT", nullable: true),
                    BlogAçıklama = table.Column<string>(type: "TEXT", nullable: true),
                    BlogTarih = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.BlogID);
                });

            migrationBuilder.CreateTable(
                name: "FirmailetisimBilgileris",
                columns: table => new
                {
                    AdresID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirmaTelefon = table.Column<string>(type: "TEXT", nullable: true),
                    FirmaMail = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FirmailetisimBilgileris", x => x.AdresID);
                });

            migrationBuilder.CreateTable(
                name: "hakkımızdas",
                columns: table => new
                {
                    HakkımızdaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HakkımızdaBaşlık = table.Column<string>(type: "TEXT", nullable: true),
                    Hakkımızdaİmage = table.Column<string>(type: "TEXT", nullable: true),
                    HakkımızdaPersonelİmage1 = table.Column<string>(type: "TEXT", nullable: true),
                    HakkımızdaPersonelİmage2 = table.Column<string>(type: "TEXT", nullable: true),
                    HakkımızdaAçıklama = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hakkımızdas", x => x.HakkımızdaID);
                });

            migrationBuilder.CreateTable(
                name: "iletisimBilgileris",
                columns: table => new
                {
                    IletisimID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AdSoyad = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    TelefonNumarasi = table.Column<string>(type: "TEXT", nullable: false),
                    Konu = table.Column<string>(type: "TEXT", nullable: false),
                    Mesaj = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_iletisimBilgileris", x => x.IletisimID);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    PersonelID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PersonelName = table.Column<string>(type: "TEXT", nullable: true),
                    PersonelÜnvan = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.PersonelID);
                });

            migrationBuilder.CreateTable(
                name: "Projelers",
                columns: table => new
                {
                    ProjelerimizID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProjelerimizName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projelers", x => x.ProjelerimizID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "admins");

            migrationBuilder.DropTable(
                name: "anasayfas");

            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "FirmailetisimBilgileris");

            migrationBuilder.DropTable(
                name: "hakkımızdas");

            migrationBuilder.DropTable(
                name: "iletisimBilgileris");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Projelers");
        }
    }
}
