﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ShoppingListDbContext))]
    [Migration("20250110125113_New")]
    partial class New
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Infrastructure.EntityModels.ShoppingList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ShopperId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShopperId");

                    b.ToTable("shoppingLists");
                });

            modelBuilder.Entity("Infrastructure.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Infrastructure.Models.Shopper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shoppers");
                });

            modelBuilder.Entity("ItemShoppingList", b =>
                {
                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.Property<int>("shoppingListsId")
                        .HasColumnType("int");

                    b.HasKey("ItemsId", "shoppingListsId");

                    b.HasIndex("shoppingListsId");

                    b.ToTable("ItemShoppingList");
                });

            modelBuilder.Entity("Infrastructure.EntityModels.ShoppingList", b =>
                {
                    b.HasOne("Infrastructure.Models.Shopper", null)
                        .WithMany("shoppingLists")
                        .HasForeignKey("ShopperId");
                });

            modelBuilder.Entity("ItemShoppingList", b =>
                {
                    b.HasOne("Infrastructure.Models.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Infrastructure.EntityModels.ShoppingList", null)
                        .WithMany()
                        .HasForeignKey("shoppingListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Infrastructure.Models.Shopper", b =>
                {
                    b.Navigation("shoppingLists");
                });
#pragma warning restore 612, 618
        }
    }
}
