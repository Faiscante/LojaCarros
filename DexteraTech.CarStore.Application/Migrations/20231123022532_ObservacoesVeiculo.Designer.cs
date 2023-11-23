﻿// <auto-generated />
using System;
using DexteraTech.CarStore.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DexteraTech.CarStore.Application.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231123022532_ObservacoesVeiculo")]
    partial class ObservacoesVeiculo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Cambio", b =>
                {
                    b.Property<int>("IdCambio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCambio"));

                    b.Property<string>("NmCambio")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCambio")
                        .HasName("PK_IdCambio");

                    b.ToTable("Cambio", (string)null);
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Carroceria", b =>
                {
                    b.Property<int>("IdCarroceria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCarroceria"));

                    b.Property<string>("NmCarroceria")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCarroceria")
                        .HasName("PK_IdCarroceria");

                    b.ToTable("Carroceria");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Cor", b =>
                {
                    b.Property<int>("IdCor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCor"));

                    b.Property<string>("NmCor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdCor")
                        .HasName("PK_IdCor");

                    b.ToTable("Cor", (string)null);
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Foto", b =>
                {
                    b.Property<int>("IdFoto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFoto"));

                    b.Property<int>("IdVeiculo")
                        .HasColumnType("int");

                    b.Property<byte[]>("Imagen")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("NmArquivo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdFoto")
                        .HasName("PK_IdFoto");

                    b.HasIndex("IdVeiculo");

                    b.ToTable("Foto", (string)null);
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Marca", b =>
                {
                    b.Property<int>("IdMarca")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMarca"));

                    b.Property<string>("NmMarca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdMarca")
                        .HasName("PK_IdMarca");

                    b.ToTable("Marca", (string)null);
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Modelo", b =>
                {
                    b.Property<int>("IdModelo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdModelo"));

                    b.Property<int>("IdCarroceria")
                        .HasColumnType("int");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<string>("NmModelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdModelo")
                        .HasName("PK_IdModelo");

                    b.HasIndex(new[] { "IdCarroceria" }, "FK_IdCarroceria");

                    b.HasIndex(new[] { "IdMarca" }, "FK_IdModelo");

                    b.ToTable("Modelo", (string)null);
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Veiculo", b =>
                {
                    b.Property<int>("IdVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVeiculo"));

                    b.Property<int>("AnoFabricacao")
                        .HasColumnType("int");

                    b.Property<int>("AnoModelo")
                        .HasColumnType("int");

                    b.Property<bool>("ExibirVitrine")
                        .HasColumnType("bit");

                    b.Property<int>("IdCambio")
                        .HasColumnType("int");

                    b.Property<int>("IdCor")
                        .HasColumnType("int");

                    b.Property<int>("IdMarca")
                        .HasColumnType("int");

                    b.Property<int>("IdModelo")
                        .HasColumnType("int");

                    b.Property<int>("IdVersao")
                        .HasColumnType("int");

                    b.Property<bool>("Ipva")
                        .HasColumnType("bit")
                        .HasColumnName("IPVA");

                    b.Property<bool>("Licenciado")
                        .HasColumnType("bit");

                    b.Property<string>("Observacoes")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("Placa")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<float>("VlrVeiculo")
                        .HasColumnType("real");

                    b.HasKey("IdVeiculo")
                        .HasName("PK_IdVeiculo");

                    b.HasIndex(new[] { "IdCor" }, "FK_IdAno");

                    b.HasIndex(new[] { "IdVersao" }, "FK_IdCambio");

                    b.HasIndex(new[] { "IdCambio" }, "FK_IdCor");

                    b.ToTable("Veiculo", (string)null);
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Versao", b =>
                {
                    b.Property<int>("IdVersao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdVersao"));

                    b.Property<int>("IdModelo")
                        .HasColumnType("int");

                    b.Property<string>("NmVersao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("IdVersao")
                        .HasName("PK_IdVersao");

                    b.HasIndex(new[] { "IdModelo" }, "FK_IdModelo");

                    b.ToTable("Versao", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Foto", b =>
                {
                    b.HasOne("DexteraTech.CarStore.Application.Models.Veiculo", "IdVeiculoNavigation")
                        .WithMany("Fotos")
                        .HasForeignKey("IdVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Veiculo_Foto");

                    b.Navigation("IdVeiculoNavigation");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Modelo", b =>
                {
                    b.HasOne("DexteraTech.CarStore.Application.Models.Carroceria", "IdCarroceriaNavigation")
                        .WithMany("Modelos")
                        .HasForeignKey("IdCarroceria")
                        .IsRequired()
                        .HasConstraintName("FK_Carroceria_Modelo");

                    b.HasOne("DexteraTech.CarStore.Application.Models.Marca", "IdMarcaNavigation")
                        .WithMany("Modelos")
                        .HasForeignKey("IdMarca")
                        .IsRequired()
                        .HasConstraintName("FK_Marca_Modelo");

                    b.Navigation("IdCarroceriaNavigation");

                    b.Navigation("IdMarcaNavigation");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Veiculo", b =>
                {
                    b.HasOne("DexteraTech.CarStore.Application.Models.Cambio", "IdCambioNavigation")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdCambio")
                        .IsRequired()
                        .HasConstraintName("FK_Cambio_Veiculo");

                    b.HasOne("DexteraTech.CarStore.Application.Models.Cor", "IdCorNavigation")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdCor")
                        .IsRequired()
                        .HasConstraintName("FK_Cor_Veiculo");

                    b.HasOne("DexteraTech.CarStore.Application.Models.Versao", "IdVersaoNavigation")
                        .WithMany("Veiculos")
                        .HasForeignKey("IdVersao")
                        .IsRequired()
                        .HasConstraintName("FK_Versao_Veiculo");

                    b.Navigation("IdCambioNavigation");

                    b.Navigation("IdCorNavigation");

                    b.Navigation("IdVersaoNavigation");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Versao", b =>
                {
                    b.HasOne("DexteraTech.CarStore.Application.Models.Modelo", "IdModeloNavigation")
                        .WithMany("Versaos")
                        .HasForeignKey("IdModelo")
                        .IsRequired()
                        .HasConstraintName("FK_Modelo_Versao");

                    b.Navigation("IdModeloNavigation");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Cambio", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Carroceria", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Cor", b =>
                {
                    b.Navigation("Veiculos");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Modelo", b =>
                {
                    b.Navigation("Versaos");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Veiculo", b =>
                {
                    b.Navigation("Fotos");
                });

            modelBuilder.Entity("DexteraTech.CarStore.Application.Models.Versao", b =>
                {
                    b.Navigation("Veiculos");
                });
#pragma warning restore 612, 618
        }
    }
}
