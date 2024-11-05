﻿// <auto-generated />
using System;
using FIAP.Grupo75.Contacts.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FIAP.Grupo75.Contacts.Infra.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FIAP.Grupo75.Contacts.Domain.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DddId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("DddId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("FIAP.Grupo75.Contacts.Domain.Entities.Ddd", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("nvarchar(2)");

                    b.Property<string>("RegionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Ddd");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Code = "61",
                            RegionName = "Distrito Federal"
                        },
                        new
                        {
                            Id = 2,
                            Code = "62",
                            RegionName = "Goiás"
                        },
                        new
                        {
                            Id = 3,
                            Code = "64",
                            RegionName = "Goiás"
                        },
                        new
                        {
                            Id = 4,
                            Code = "65",
                            RegionName = "Mato Grosso"
                        },
                        new
                        {
                            Id = 5,
                            Code = "66",
                            RegionName = "Mato Grosso"
                        },
                        new
                        {
                            Id = 6,
                            Code = "67",
                            RegionName = "Mato Grosso do Sul"
                        },
                        new
                        {
                            Id = 7,
                            Code = "82",
                            RegionName = "Alagoas"
                        },
                        new
                        {
                            Id = 8,
                            Code = "71",
                            RegionName = "Bahia"
                        },
                        new
                        {
                            Id = 9,
                            Code = "73",
                            RegionName = "Bahia"
                        },
                        new
                        {
                            Id = 10,
                            Code = "74",
                            RegionName = "Bahia"
                        },
                        new
                        {
                            Id = 11,
                            Code = "75",
                            RegionName = "Bahia"
                        },
                        new
                        {
                            Id = 12,
                            Code = "77",
                            RegionName = "Bahia"
                        },
                        new
                        {
                            Id = 13,
                            Code = "85",
                            RegionName = "Ceará"
                        },
                        new
                        {
                            Id = 14,
                            Code = "88",
                            RegionName = "Ceará"
                        },
                        new
                        {
                            Id = 15,
                            Code = "98",
                            RegionName = "Maranhão"
                        },
                        new
                        {
                            Id = 16,
                            Code = "99",
                            RegionName = "Maranhão"
                        },
                        new
                        {
                            Id = 17,
                            Code = "83",
                            RegionName = "Paraíba"
                        },
                        new
                        {
                            Id = 18,
                            Code = "81",
                            RegionName = "Pernambuco"
                        },
                        new
                        {
                            Id = 19,
                            Code = "87",
                            RegionName = "Pernambuco"
                        },
                        new
                        {
                            Id = 20,
                            Code = "86",
                            RegionName = "Piauí"
                        },
                        new
                        {
                            Id = 21,
                            Code = "89",
                            RegionName = "Piauí"
                        },
                        new
                        {
                            Id = 22,
                            Code = "84",
                            RegionName = "Rio Grande do Norte"
                        },
                        new
                        {
                            Id = 23,
                            Code = "79",
                            RegionName = "Sergipe"
                        },
                        new
                        {
                            Id = 24,
                            Code = "68",
                            RegionName = "Acre"
                        },
                        new
                        {
                            Id = 25,
                            Code = "96",
                            RegionName = "Amapá"
                        },
                        new
                        {
                            Id = 26,
                            Code = "92",
                            RegionName = "Amazonas"
                        },
                        new
                        {
                            Id = 27,
                            Code = "97",
                            RegionName = "Amazonas"
                        },
                        new
                        {
                            Id = 28,
                            Code = "91",
                            RegionName = "Pará"
                        },
                        new
                        {
                            Id = 29,
                            Code = "93",
                            RegionName = "Pará"
                        },
                        new
                        {
                            Id = 30,
                            Code = "94",
                            RegionName = "Pará"
                        },
                        new
                        {
                            Id = 31,
                            Code = "69",
                            RegionName = "Rondônia"
                        },
                        new
                        {
                            Id = 32,
                            Code = "95",
                            RegionName = "Roraima"
                        },
                        new
                        {
                            Id = 33,
                            Code = "63",
                            RegionName = "Tocantins"
                        },
                        new
                        {
                            Id = 34,
                            Code = "27",
                            RegionName = "Espírito Santo"
                        },
                        new
                        {
                            Id = 35,
                            Code = "28",
                            RegionName = "Espírito Santo"
                        },
                        new
                        {
                            Id = 36,
                            Code = "31",
                            RegionName = "Minas Gerais"
                        },
                        new
                        {
                            Id = 37,
                            Code = "32",
                            RegionName = "Minas Gerais"
                        },
                        new
                        {
                            Id = 38,
                            Code = "33",
                            RegionName = "Minas Gerais"
                        },
                        new
                        {
                            Id = 39,
                            Code = "34",
                            RegionName = "Minas Gerais"
                        },
                        new
                        {
                            Id = 40,
                            Code = "35",
                            RegionName = "Minas Gerais"
                        },
                        new
                        {
                            Id = 41,
                            Code = "37",
                            RegionName = "Minas Gerais"
                        },
                        new
                        {
                            Id = 42,
                            Code = "38",
                            RegionName = "Minas Gerais"
                        },
                        new
                        {
                            Id = 43,
                            Code = "21",
                            RegionName = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 44,
                            Code = "22",
                            RegionName = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 45,
                            Code = "24",
                            RegionName = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = 46,
                            Code = "11",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 47,
                            Code = "12",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 48,
                            Code = "13",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 49,
                            Code = "14",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 50,
                            Code = "15",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 51,
                            Code = "16",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 52,
                            Code = "17",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 53,
                            Code = "18",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 54,
                            Code = "19",
                            RegionName = "São Paulo"
                        },
                        new
                        {
                            Id = 55,
                            Code = "41",
                            RegionName = "Paraná"
                        },
                        new
                        {
                            Id = 56,
                            Code = "42",
                            RegionName = "Paraná"
                        },
                        new
                        {
                            Id = 57,
                            Code = "43",
                            RegionName = "Paraná"
                        },
                        new
                        {
                            Id = 58,
                            Code = "44",
                            RegionName = "Paraná"
                        },
                        new
                        {
                            Id = 59,
                            Code = "45",
                            RegionName = "Paraná"
                        },
                        new
                        {
                            Id = 60,
                            Code = "46",
                            RegionName = "Paraná"
                        },
                        new
                        {
                            Id = 61,
                            Code = "51",
                            RegionName = "Rio Grande do Sul"
                        },
                        new
                        {
                            Id = 62,
                            Code = "53",
                            RegionName = "Rio Grande do Sul"
                        },
                        new
                        {
                            Id = 63,
                            Code = "54",
                            RegionName = "Rio Grande do Sul"
                        },
                        new
                        {
                            Id = 64,
                            Code = "55",
                            RegionName = "Rio Grande do Sul"
                        },
                        new
                        {
                            Id = 65,
                            Code = "47",
                            RegionName = "Santa Catarina"
                        },
                        new
                        {
                            Id = 66,
                            Code = "48",
                            RegionName = "Santa Catarina"
                        },
                        new
                        {
                            Id = 67,
                            Code = "49",
                            RegionName = "Santa Catarina"
                        });
                });

            modelBuilder.Entity("FIAP.Grupo75.Contacts.Infra.Data.Identity.ApplicationUser", b =>
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("FIAP.Grupo75.Contacts.Domain.Entities.Contact", b =>
                {
                    b.HasOne("FIAP.Grupo75.Contacts.Domain.Entities.Ddd", "Ddd")
                        .WithMany("Contacts")
                        .HasForeignKey("DddId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ddd");
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
                    b.HasOne("FIAP.Grupo75.Contacts.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FIAP.Grupo75.Contacts.Infra.Data.Identity.ApplicationUser", null)
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

                    b.HasOne("FIAP.Grupo75.Contacts.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FIAP.Grupo75.Contacts.Infra.Data.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FIAP.Grupo75.Contacts.Domain.Entities.Ddd", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}
