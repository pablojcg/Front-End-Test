﻿// <auto-generated />
using System;
using Company.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Company.Model.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Company.Model.Entities.Company", b =>
                {
                    b.Property<int>("idCompany")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("authorizedSendEmail")
                        .HasColumnType("bit");

                    b.Property<bool>("authorizedSendPhone")
                        .HasColumnType("bit");

                    b.Property<string>("companyName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firtsLastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("firtsName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("idIdentificationType")
                        .HasColumnType("int");

                    b.Property<int>("identificationNumber")
                        .HasColumnType("int");

                    b.Property<int>("nitCompany")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("secondLastName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("secondName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("unableRegistry")
                        .HasColumnType("bit");

                    b.HasKey("idCompany");

                    b.HasIndex("idIdentificationType");

                    b.ToTable("Company");

                    b.HasData(
                        new
                        {
                            idCompany = 1,
                            authorizedSendEmail = false,
                            authorizedSendPhone = false,
                            companyName = "Nombre Compañia 1",
                            email = "emailcompania1@email.com",
                            idIdentificationType = 1,
                            identificationNumber = 900674335,
                            nitCompany = 900674335,
                            phone = "333444555",
                            unableRegistry = true
                        },
                        new
                        {
                            idCompany = 2,
                            authorizedSendEmail = false,
                            authorizedSendPhone = false,
                            email = "pedroperez@email.com",
                            firtsLastName = "Perez",
                            firtsName = "Pedro",
                            idIdentificationType = 2,
                            identificationNumber = 1222333444,
                            nitCompany = 900674336,
                            phone = "344566788",
                            unableRegistry = false
                        },
                        new
                        {
                            idCompany = 3,
                            authorizedSendEmail = false,
                            authorizedSendPhone = false,
                            companyName = "Nombre Compañia 2",
                            email = "emailcompania2@email.com",
                            idIdentificationType = 3,
                            identificationNumber = 8907654,
                            nitCompany = 811033098,
                            phone = "322433544",
                            unableRegistry = false
                        });
                });

            modelBuilder.Entity("Company.Model.Entities.CompanyRegistry", b =>
                {
                    b.Property<int>("idCompanyRegistry")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateRegistry")
                        .HasColumnType("datetime2");

                    b.Property<int>("idCompany")
                        .HasColumnType("int");

                    b.HasKey("idCompanyRegistry");

                    b.HasIndex("idCompany");

                    b.ToTable("CompanyRegistry");
                });

            modelBuilder.Entity("Company.Model.Entities.IdentificationType", b =>
                {
                    b.Property<int>("idIdentificationType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("identificationDescription")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("identificationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("idIdentificationType");

                    b.ToTable("IdentificationType");

                    b.HasData(
                        new
                        {
                            idIdentificationType = 1,
                            identificationDescription = "Descripción de NIT",
                            identificationName = "NIT"
                        },
                        new
                        {
                            idIdentificationType = 2,
                            identificationDescription = "Descripción de Cedula de Ciudadania",
                            identificationName = "Cedula Ciudadania"
                        },
                        new
                        {
                            idIdentificationType = 3,
                            identificationDescription = "Descripción de Cedula de Extranjeria",
                            identificationName = "Cedula Extranjeria"
                        },
                        new
                        {
                            idIdentificationType = 4,
                            identificationDescription = "Descripción de Pasaporte",
                            identificationName = "Pasaporte"
                        });
                });

            modelBuilder.Entity("Company.Model.Entities.Company", b =>
                {
                    b.HasOne("Company.Model.Entities.IdentificationType", "identificationType")
                        .WithMany("identificationTypeHasCompany")
                        .HasForeignKey("idIdentificationType")
                        .HasConstraintName("FK_identificationTypeToCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("identificationType");
                });

            modelBuilder.Entity("Company.Model.Entities.CompanyRegistry", b =>
                {
                    b.HasOne("Company.Model.Entities.Company", "company")
                        .WithMany("companyHasCompanyRegistry")
                        .HasForeignKey("idCompany")
                        .HasConstraintName("FK_CompanyToCompanyRegistry")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");
                });

            modelBuilder.Entity("Company.Model.Entities.Company", b =>
                {
                    b.Navigation("companyHasCompanyRegistry");
                });

            modelBuilder.Entity("Company.Model.Entities.IdentificationType", b =>
                {
                    b.Navigation("identificationTypeHasCompany");
                });
#pragma warning restore 612, 618
        }
    }
}
