﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using norbit.crm.strashko.careertasks.backend.Models;

#nullable disable

namespace norbit.crm.strashko.careertasks.backend.Models.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20230626072925_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("norbit.crm.strashko.careertasks.backend.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5485236e-bcfb-4d35-b9fb-b5798d542a91"),
                            Age = 0,
                            CreatedOn = new DateTime(2023, 6, 26, 12, 29, 25, 212, DateTimeKind.Local).AddTicks(6199),
                            ModifiedOn = new DateTime(2023, 6, 26, 12, 29, 25, 212, DateTimeKind.Local).AddTicks(6209),
                            Name = "TestName1"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
