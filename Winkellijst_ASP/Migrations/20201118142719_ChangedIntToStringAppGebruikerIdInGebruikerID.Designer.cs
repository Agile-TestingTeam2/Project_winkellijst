﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Winkellijst_ASP.Data;

namespace Winkellijst_ASP.Migrations
{
    [DbContext(typeof(GebruikerContext))]
    [Migration("20201118142719_ChangedIntToStringAppGebruikerIdInGebruikerID")]
    partial class ChangedIntToStringAppGebruikerIdInGebruikerID
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("Winkellijst")
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Winkellijst_ASP.Models.Afdeling", b =>
                {
                    b.Property<int>("AfdelingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Volgorde")
                        .HasColumnType("int");

                    b.Property<int>("WinkelId")
                        .HasColumnType("int");

                    b.HasKey("AfdelingId");

                    b.HasIndex("WinkelId");

                    b.ToTable("Afdeling");
                });

            modelBuilder.Entity("Winkellijst_ASP.Models.Gebruiker", b =>
                {
                    b.Property<int>("GebruikerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppGebruikerId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GebruikerId");

                    b.ToTable("Gebruiker");
                });

            modelBuilder.Entity("Winkellijst_ASP.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AfdelingId")
                        .HasColumnType("int");

                    b.Property<string>("Naam")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("ProductId");

                    b.HasIndex("AfdelingId");

                    b.HasIndex("Naam")
                        .IsUnique();

                    b.ToTable("Product");
                });

            modelBuilder.Entity("Winkellijst_ASP.Models.Winkel", b =>
                {
                    b.Property<int>("WinkelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Huisnummer")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)")
                        .HasMaxLength(12);

                    b.Property<string>("Stad")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Straat")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Winkelnaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("WinkelId");

                    b.ToTable("Winkel");
                });

            modelBuilder.Entity("Winkellijst_ASP.Models.WinkelLijst", b =>
                {
                    b.Property<int>("WinkelLijstId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AanmaakDatum")
                        .HasColumnType("dateTime");

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.Property<int>("WinkelId")
                        .HasColumnType("int");

                    b.HasKey("WinkelLijstId");

                    b.HasIndex("GebruikerId");

                    b.HasIndex("WinkelId");

                    b.ToTable("WinkelLijst");
                });

            modelBuilder.Entity("Winkellijst_ASP.Models.Afdeling", b =>
                {
                    b.HasOne("Winkellijst_ASP.Models.Winkel", "Winkel")
                        .WithMany("Afdelingen")
                        .HasForeignKey("WinkelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Winkellijst_ASP.Models.Product", b =>
                {
                    b.HasOne("Winkellijst_ASP.Models.Afdeling", "Afdeling")
                        .WithMany("Producten")
                        .HasForeignKey("AfdelingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Winkellijst_ASP.Models.WinkelLijst", b =>
                {
                    b.HasOne("Winkellijst_ASP.Models.Gebruiker", "Gebruiker")
                        .WithMany()
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Winkellijst_ASP.Models.Winkel", "Winkel")
                        .WithMany("WinkelLijsten")
                        .HasForeignKey("WinkelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
