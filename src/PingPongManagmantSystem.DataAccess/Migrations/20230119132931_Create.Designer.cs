﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PingPongManagmantSystem.Domain.Constans.DbConstans;

#nullable disable

namespace PingPongManagmantSystem.Domain.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230119132931_Create")]
    partial class Create
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

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("Price")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("TimeLimit")
                        .IsRequired()
                        .HasColumnType("TEXT");

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

                    b.Property<double>("Card")
                        .HasColumnType("REAL");

                    b.Property<string>("Check")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("NoCard")
                        .HasColumnType("REAL");

                    b.Property<double>("SportProductPrice")
                        .HasColumnType("REAL");

                    b.Property<double>("TablePrice")
                        .HasColumnType("REAL");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("VipCard")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Cassas");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("CheapPrice")
                        .HasColumnType("REAL");

                    b.Property<double>("ExpensivePrice")
                        .HasColumnType("REAL");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.PingPongTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
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

            modelBuilder.Entity("PingPongManagmantSystem.Domain.Entities.Cassa", b =>
                {
                    b.HasOne("PingPongManagmantSystem.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
