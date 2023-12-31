﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SysRH.Infra.Context;

#nullable disable

namespace SysRH.Infra.Migrations
{
    [DbContext(typeof(SysRHContext))]
    [Migration("20231026132734_CPFupdate1")]
    partial class CPFupdate1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SysRH.Domain.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CPF")
                        .HasColumnType("INT(11)");

                    b.Property<string>("EmploymentHistory")
                        .IsRequired()
                        .HasColumnType("VARCHAR(120)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("VARCHAR(70)");

                    b.Property<decimal>("Salary")
                        .HasColumnType("DECIMAL(12,2)");

                    b.Property<string>("Trainings")
                        .IsRequired()
                        .HasColumnType("VARCHAR(120)");

                    b.HasKey("Id");

                    b.ToTable("Employee", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
