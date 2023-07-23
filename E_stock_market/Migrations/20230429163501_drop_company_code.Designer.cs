﻿// <auto-generated />
using System;
using E_stock_market.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_stock_market.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230429163501_drop_company_code")]
    partial class drop_company_code
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_stock_market.Models.Company", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Company_ceo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Company_turnover")
                        .HasColumnType("bigint");

                    b.Property<string>("Company_website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("E_stock_market.Models.Stock", b =>
                {
                    b.Property<int>("ref_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ref_id"));

                    b.Property<int>("Company_code")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_time")
                        .HasColumnType("datetime2");

                    b.Property<float>("Stock_price")
                        .HasColumnType("real");

                    b.HasKey("ref_id");

                    b.ToTable("Stocks");
                });
#pragma warning restore 612, 618
        }
    }
}
