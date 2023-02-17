﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PingPongManagmantSystem.DataAccess.Constans;

#nullable disable

namespace PingPongManagmantSystem.DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230217120845_UpdateDatabas")]
    partial class UpdateDatabas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.13");

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.BarProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("ArrivalPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SalePrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("BarProducts");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.Card", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("TimeLimit")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Cards");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.Cassa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("BarProductPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("Check")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SportProductPrice")
                        .HasColumnType("REAL");

                    b.Property<string>("SumPrice")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("TablePrice")
                        .HasColumnType("REAL");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cassas");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Percent")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.DesktopCassa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AccountBook")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Bar")
                        .HasColumnType("INTEGER");

                    b.Property<double>("BarSum")
                        .HasColumnType("REAL");

                    b.Property<bool>("Calc")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Label")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("Pause")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Play")
                        .HasColumnType("INTEGER");

                    b.Property<float>("PlayTime")
                        .HasColumnType("REAL");

                    b.Property<byte>("StolNumber")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Stop")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TimeAccount")
                        .HasColumnType("REAL");

                    b.Property<bool>("Transfer")
                        .HasColumnType("INTEGER");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("DesktopCassas");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.PingPongTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("PriceCheap")
                        .HasColumnType("REAL");

                    b.Property<double>("PriceExpensive")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("PingPongTables");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.SportProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("ArrivalPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("SalePrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("SportProducts");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.Time", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("TimeCheapFrom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeCheapUpTo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeExpensiveFrom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeExpensiveUpTo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Times");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PassportInfo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
