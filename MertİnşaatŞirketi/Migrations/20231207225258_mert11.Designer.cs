﻿// <auto-generated />
using MertProje.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MertProje.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20231207225258_mert11")]
    partial class mert11
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("MertProje.Data.Admin", b =>
                {
                    b.Property<int>("AdminID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("confirmpassword")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AdminID");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("MertProje.Data.FirmaİletisimBilgileri", b =>
                {
                    b.Property<int>("AdresID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirmaAdres")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirmaHarita")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirmaMail")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirmaTelefon")
                        .HasColumnType("TEXT");

                    b.HasKey("AdresID");

                    b.ToTable("FirmailetisimBilgileris");
                });

            modelBuilder.Entity("MertProje.Data.Personel", b =>
                {
                    b.Property<int>("PersonelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("PersonelName")
                        .HasColumnType("TEXT");

                    b.Property<string>("PersonelÜnvan")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonelID");

                    b.ToTable("Personels");
                });

            modelBuilder.Entity("MertProje.Data.Projeler", b =>
                {
                    b.Property<int>("ProjelerimizID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProjelerimizName")
                        .HasColumnType("TEXT");

                    b.HasKey("ProjelerimizID");

                    b.ToTable("Projelers");
                });

            modelBuilder.Entity("MertProje.Data.İletisimBilgileri", b =>
                {
                    b.Property<int>("IletisimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AdSoyad")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Konu")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mesaj")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TelefonNumarasi")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("IletisimID");

                    b.ToTable("iletisimBilgileris");
                });

            modelBuilder.Entity("MertProje.Models.AnasayfaModel", b =>
                {
                    b.Property<int>("AnasayfaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AnasayfaAçıklama1")
                        .HasColumnType("TEXT");

                    b.Property<string>("AnasayfaAçıklama2")
                        .HasColumnType("TEXT");

                    b.Property<string>("AnasayfaBaşlık1")
                        .HasColumnType("TEXT");

                    b.Property<string>("AnasayfaBaşlık2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Anasayfaİmage1")
                        .HasColumnType("TEXT");

                    b.Property<string>("Anasayfaİmage2")
                        .HasColumnType("TEXT");

                    b.HasKey("AnasayfaID");

                    b.ToTable("anasayfas");
                });

            modelBuilder.Entity("MertProje.Models.BlogModel", b =>
                {
                    b.Property<int>("BlogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BlogAçıklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("BlogBaşlık")
                        .HasColumnType("TEXT");

                    b.Property<string>("BlogTarih")
                        .HasColumnType("TEXT");

                    b.Property<string>("Blogİmage")
                        .HasColumnType("TEXT");

                    b.HasKey("BlogID");

                    b.ToTable("blogs");
                });

            modelBuilder.Entity("MertProje.Models.HakkımızdaModel", b =>
                {
                    b.Property<int>("HakkımızdaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("HakkımızdaAçıklama")
                        .HasColumnType("TEXT");

                    b.Property<string>("HakkımızdaBaşlık")
                        .HasColumnType("TEXT");

                    b.Property<string>("HakkımızdaPersonelİmage1")
                        .HasColumnType("TEXT");

                    b.Property<string>("HakkımızdaPersonelİmage2")
                        .HasColumnType("TEXT");

                    b.Property<string>("Hakkımızdaİmage")
                        .HasColumnType("TEXT");

                    b.HasKey("HakkımızdaID");

                    b.ToTable("hakkımızdas");
                });
#pragma warning restore 612, 618
        }
    }
}
