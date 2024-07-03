﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MusicVault.Migrations
{
    [DbContext(typeof(SqlDbContext))]
    [Migration("20240703132237_Migracija2")]
    partial class Migracija2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GlasanjeMuzickiSadrzaj", b =>
                {
                    b.Property<int>("GlasanjeId")
                        .HasColumnType("integer");

                    b.Property<int>("OpcijeZaGlasanjeId")
                        .HasColumnType("integer");

                    b.HasKey("GlasanjeId", "OpcijeZaGlasanjeId");

                    b.HasIndex("OpcijeZaGlasanjeId");

                    b.ToTable("GlasanjeMuzickiSadrzaj");
                });

            modelBuilder.Entity("IzvodjacMultimedijalniSadrzaj", b =>
                {
                    b.Property<int>("IzvodjacId")
                        .HasColumnType("integer");

                    b.Property<int>("MultimedijalniSadrzajiId")
                        .HasColumnType("integer");

                    b.HasKey("IzvodjacId", "MultimedijalniSadrzajiId");

                    b.HasIndex("MultimedijalniSadrzajiId");

                    b.ToTable("IzvodjacMultimedijalniSadrzaj");
                });

            modelBuilder.Entity("IzvodjacReklama", b =>
                {
                    b.Property<int>("IzvodjaciId")
                        .HasColumnType("integer");

                    b.Property<int>("ReklamaId")
                        .HasColumnType("integer");

                    b.HasKey("IzvodjaciId", "ReklamaId");

                    b.HasIndex("ReklamaId");

                    b.ToTable("IzvodjacReklama");
                });

            modelBuilder.Entity("IzvodjacZanr", b =>
                {
                    b.Property<int>("IzvodjacId")
                        .HasColumnType("integer");

                    b.Property<int>("ZanreviId")
                        .HasColumnType("integer");

                    b.HasKey("IzvodjacId", "ZanreviId");

                    b.HasIndex("ZanreviId");

                    b.ToTable("IzvodjacZanr");
                });

            modelBuilder.Entity("MultimedijalniSadrzajMuzickiSadrzaj", b =>
                {
                    b.Property<int>("MultimedijalniSadrzajiId")
                        .HasColumnType("integer");

                    b.Property<int>("MuzickiSadrzajId")
                        .HasColumnType("integer");

                    b.HasKey("MultimedijalniSadrzajiId", "MuzickiSadrzajId");

                    b.HasIndex("MuzickiSadrzajId");

                    b.ToTable("MultimedijalniSadrzajMuzickiSadrzaj");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Glas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Datum")
                        .HasColumnType("date");

                    b.Property<int?>("GlasanjeId")
                        .HasColumnType("integer");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("integer");

                    b.Property<int>("MuzickiSadrzajId")
                        .HasColumnType("integer");

                    b.Property<int>("Ocena")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GlasanjeId");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("MuzickiSadrzajId");

                    b.ToTable("Glas");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Glasanje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Aktivno")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("KrajGlasanja")
                        .HasColumnType("date");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<DateOnly>("PocetakGlasanja")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("Glasanje");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Izvodi", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("IzvodjacId")
                        .HasColumnType("integer");

                    b.Property<int>("MuzickiSadrzajId")
                        .HasColumnType("integer");

                    b.Property<string>("Uloga")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("IzvodjacId");

                    b.HasIndex("MuzickiSadrzajId");

                    b.ToTable("Izvodi");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Izvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Izvodjac");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Korisnik", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Banovan")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("GodRodjenja")
                        .HasColumnType("date");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<bool>("Javni")
                        .HasColumnType("boolean");

                    b.Property<string>("Lozinka")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("Mejl")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<int>("Pol")
                        .HasColumnType("integer");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<int>("Tip")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Korisnik");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.MultimedijalniSadrzaj.MultimedijalniSadrzaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MultimedijalniSadrzaj");

                    b.HasDiscriminator<string>("Vrsta").HasValue("MultimedijalniSadrzaj");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("Objavljeno")
                        .HasColumnType("boolean");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<string>("Vrsta")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("MuzickiSadrzaj");

                    b.HasDiscriminator<string>("Vrsta").HasValue("MuzickiSadrzaj");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Plejlista", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.ToTable("Plejlista");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Pregled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Datum")
                        .HasColumnType("date");

                    b.Property<int>("KorisnikId")
                        .HasColumnType("integer");

                    b.Property<int>("MuzickiSadrzajId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("KorisnikId");

                    b.HasIndex("MuzickiSadrzajId");

                    b.ToTable("Pregled");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Recenzija.Recenzija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("MuzickiSadrzajId")
                        .HasColumnType("integer");

                    b.Property<bool>("Objavljena")
                        .HasColumnType("boolean");

                    b.Property<int>("Ocena")
                        .HasColumnType("integer");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.Property<int>("Stanje")
                        .HasColumnType("integer");

                    b.Property<int?>("UrednikId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MuzickiSadrzajId");

                    b.HasIndex("UrednikId");

                    b.ToTable("Recenzija");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Reklama", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Cena")
                        .HasColumnType("integer");

                    b.Property<int>("MultimedijalniSadrzajId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("MultimedijalniSadrzajId");

                    b.ToTable("Reklama");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Zanr", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("NadZanrId")
                        .HasColumnType("integer");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar");

                    b.HasKey("Id");

                    b.HasIndex("NadZanrId")
                        .IsUnique();

                    b.ToTable("Zanr");
                });

            modelBuilder.Entity("MuzickiSadrzajMuzickiSadrzaj", b =>
                {
                    b.Property<int>("MuzickiSadrzajId")
                        .HasColumnType("integer");

                    b.Property<int>("MuzickiSadrzajiId")
                        .HasColumnType("integer");

                    b.HasKey("MuzickiSadrzajId", "MuzickiSadrzajiId");

                    b.HasIndex("MuzickiSadrzajiId");

                    b.ToTable("MuzickiSadrzajMuzickiSadrzaj");
                });

            modelBuilder.Entity("MuzickiSadrzajPlejlista", b =>
                {
                    b.Property<int>("MuzickiSadrzajiId")
                        .HasColumnType("integer");

                    b.Property<int>("PlejlistaId")
                        .HasColumnType("integer");

                    b.HasKey("MuzickiSadrzajiId", "PlejlistaId");

                    b.HasIndex("PlejlistaId");

                    b.ToTable("MuzickiSadrzajPlejlista");
                });

            modelBuilder.Entity("MuzickiSadrzajZanr", b =>
                {
                    b.Property<int>("MuzickiSadrzajId")
                        .HasColumnType("integer");

                    b.Property<int>("ZanreviId")
                        .HasColumnType("integer");

                    b.HasKey("MuzickiSadrzajId", "ZanreviId");

                    b.HasIndex("ZanreviId");

                    b.ToTable("MuzickiSadrzajZanr");
                });

            modelBuilder.Entity("PlejlistaZanr", b =>
                {
                    b.Property<int>("PlejlistaId")
                        .HasColumnType("integer");

                    b.Property<int>("ZanroviId")
                        .HasColumnType("integer");

                    b.HasKey("PlejlistaId", "ZanroviId");

                    b.HasIndex("ZanroviId");

                    b.ToTable("PlejlistaZanr");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.MultimedijalniSadrzaj.Gif", b =>
                {
                    b.HasBaseType("MusicVault.Backend.Model.MultimedijalniSadrzaj.MultimedijalniSadrzaj");

                    b.HasDiscriminator().HasValue("Album");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.MultimedijalniSadrzaj.Slika", b =>
                {
                    b.HasBaseType("MusicVault.Backend.Model.MultimedijalniSadrzaj.MultimedijalniSadrzaj");

                    b.HasDiscriminator().HasValue("Delo");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.MultimedijalniSadrzaj.Video", b =>
                {
                    b.HasBaseType("MusicVault.Backend.Model.MultimedijalniSadrzaj.MultimedijalniSadrzaj");

                    b.HasDiscriminator().HasValue("Nastup");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.MuzickiSadrzaj.Album", b =>
                {
                    b.HasBaseType("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj");

                    b.Property<int>("Tip")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Album");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.MuzickiSadrzaj.Delo", b =>
                {
                    b.HasBaseType("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj");

                    b.HasDiscriminator().HasValue("Delo");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.MuzickiSadrzaj.Nastup", b =>
                {
                    b.HasBaseType("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj");

                    b.HasDiscriminator().HasValue("Nastup");
                });

            modelBuilder.Entity("GlasanjeMuzickiSadrzaj", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Glasanje", null)
                        .WithMany()
                        .HasForeignKey("GlasanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", null)
                        .WithMany()
                        .HasForeignKey("OpcijeZaGlasanjeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IzvodjacMultimedijalniSadrzaj", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Izvodjac", null)
                        .WithMany()
                        .HasForeignKey("IzvodjacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.MultimedijalniSadrzaj.MultimedijalniSadrzaj", null)
                        .WithMany()
                        .HasForeignKey("MultimedijalniSadrzajiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IzvodjacReklama", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Izvodjac", null)
                        .WithMany()
                        .HasForeignKey("IzvodjaciId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.Reklama", null)
                        .WithMany()
                        .HasForeignKey("ReklamaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IzvodjacZanr", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Izvodjac", null)
                        .WithMany()
                        .HasForeignKey("IzvodjacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.Zanr", null)
                        .WithMany()
                        .HasForeignKey("ZanreviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MultimedijalniSadrzajMuzickiSadrzaj", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.MultimedijalniSadrzaj.MultimedijalniSadrzaj", null)
                        .WithMany()
                        .HasForeignKey("MultimedijalniSadrzajiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", null)
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Glas", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Glasanje", null)
                        .WithMany("Glasovi")
                        .HasForeignKey("GlasanjeId");

                    b.HasOne("MusicVault.Backend.Model.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", "MuzickiSadrzaj")
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("MuzickiSadrzaj");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Izvodi", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Izvodjac", "Izvodjac")
                        .WithMany()
                        .HasForeignKey("IzvodjacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", "MuzickiSadrzaj")
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Izvodjac");

                    b.Navigation("MuzickiSadrzaj");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Pregled", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Korisnik", "Korisnik")
                        .WithMany()
                        .HasForeignKey("KorisnikId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", "MuzickiSadrzaj")
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Korisnik");

                    b.Navigation("MuzickiSadrzaj");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Recenzija.Recenzija", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", "MuzickiSadrzaj")
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.Korisnik", "Urednik")
                        .WithMany()
                        .HasForeignKey("UrednikId");

                    b.Navigation("MuzickiSadrzaj");

                    b.Navigation("Urednik");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Reklama", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.MultimedijalniSadrzaj.MultimedijalniSadrzaj", "MultimedijalniSadrzaj")
                        .WithMany()
                        .HasForeignKey("MultimedijalniSadrzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MultimedijalniSadrzaj");
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Zanr", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Zanr", "NadZanr")
                        .WithOne()
                        .HasForeignKey("MusicVault.Backend.Model.Zanr", "NadZanrId");

                    b.Navigation("NadZanr");
                });

            modelBuilder.Entity("MuzickiSadrzajMuzickiSadrzaj", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", null)
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", null)
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MuzickiSadrzajPlejlista", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", null)
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajiId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.Plejlista", null)
                        .WithMany()
                        .HasForeignKey("PlejlistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MuzickiSadrzajZanr", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.MuzickiSadrzaj.MuzickiSadrzaj", null)
                        .WithMany()
                        .HasForeignKey("MuzickiSadrzajId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.Zanr", null)
                        .WithMany()
                        .HasForeignKey("ZanreviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlejlistaZanr", b =>
                {
                    b.HasOne("MusicVault.Backend.Model.Plejlista", null)
                        .WithMany()
                        .HasForeignKey("PlejlistaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicVault.Backend.Model.Zanr", null)
                        .WithMany()
                        .HasForeignKey("ZanroviId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicVault.Backend.Model.Glasanje", b =>
                {
                    b.Navigation("Glasovi");
                });
#pragma warning restore 612, 618
        }
    }
}
