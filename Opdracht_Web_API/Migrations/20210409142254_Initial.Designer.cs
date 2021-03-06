// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Opdracht_Web_API.Data;

namespace Opdracht_Web_API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210409142254_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Opdracht_Web_API.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Opdracht_Web_API.Models.StoreItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("AmountInStock")
                        .HasColumnType("int");

                    b.Property<double>("BuyPrice")
                        .HasColumnType("float");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxLevelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaxLevelId");

                    b.ToTable("StoreItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            AmountInStock = 100,
                            BuyPrice = 2.0,
                            Code = "L0001",
                            Name = "Lamp",
                            TaxLevelId = 1
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            AmountInStock = 35,
                            BuyPrice = 20.0,
                            Code = "E0001",
                            Name = "Broodrooster",
                            TaxLevelId = 1
                        },
                        new
                        {
                            Id = 3,
                            Active = true,
                            AmountInStock = 10,
                            BuyPrice = 150.0,
                            Code = "E0002",
                            Name = "Koelkast",
                            TaxLevelId = 1
                        },
                        new
                        {
                            Id = 4,
                            Active = true,
                            AmountInStock = 10,
                            BuyPrice = 200.0,
                            Code = "E0003",
                            Name = "Wasmachine",
                            TaxLevelId = 1
                        },
                        new
                        {
                            Id = 5,
                            Active = true,
                            AmountInStock = 10,
                            BuyPrice = 200.0,
                            Code = "E0004",
                            Name = "Vaatwasmachine",
                            TaxLevelId = 1
                        },
                        new
                        {
                            Id = 6,
                            Active = true,
                            AmountInStock = 30,
                            BuyPrice = 15.0,
                            Code = "E0005",
                            Name = "Mixer",
                            TaxLevelId = 1
                        },
                        new
                        {
                            Id = 7,
                            Active = true,
                            AmountInStock = 40,
                            BuyPrice = 100.0,
                            Code = "E0006",
                            Name = "Strijkijzer",
                            TaxLevelId = 1
                        },
                        new
                        {
                            Id = 8,
                            Active = true,
                            AmountInStock = 20,
                            BuyPrice = 20.0,
                            Code = "H0001",
                            Name = "Strijkplank",
                            TaxLevelId = 1
                        },
                        new
                        {
                            Id = 9,
                            Active = true,
                            AmountInStock = 25,
                            BuyPrice = 250.0,
                            Code = "E0007",
                            Name = "Keukenrobot",
                            TaxLevelId = 1
                        });
                });

            modelBuilder.Entity("Opdracht_Web_API.Models.Tax", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaxPercentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Taxes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "standard",
                            TaxPercentage = 21
                        },
                        new
                        {
                            Id = 2,
                            Name = "exceptions and meals",
                            TaxPercentage = 12
                        },
                        new
                        {
                            Id = 3,
                            Name = "basic",
                            TaxPercentage = 6
                        });
                });

            modelBuilder.Entity("OrderStoreItem", b =>
                {
                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.HasKey("CartId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("OrderStoreItem");
                });

            modelBuilder.Entity("Opdracht_Web_API.Models.StoreItem", b =>
                {
                    b.HasOne("Opdracht_Web_API.Models.Tax", "TaxLevel")
                        .WithMany("StoreItems")
                        .HasForeignKey("TaxLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxLevel");
                });

            modelBuilder.Entity("OrderStoreItem", b =>
                {
                    b.HasOne("Opdracht_Web_API.Models.StoreItem", null)
                        .WithMany()
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Opdracht_Web_API.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Opdracht_Web_API.Models.Tax", b =>
                {
                    b.Navigation("StoreItems");
                });
#pragma warning restore 612, 618
        }
    }
}
