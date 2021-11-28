﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModularRestaurant.Menus.Infrastructure.EF;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ModularRestaurant.Menus.Infrastructure.EF.Migrations
{
    [DbContext(typeof(MenusDbContext))]
    [Migration("20211128142020_AddImageToItem")]
    partial class AddImageToItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("menus")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ModularRestaurant.Menus.Domain.Entities.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("InternalName")
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("RestaurantId")
                        .HasColumnType("uuid");

                    b.Property<int>("Version")
                        .IsConcurrencyToken()
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("ModularRestaurant.Menus.Domain.Entities.Menu", b =>
                {
                    b.OwnsMany("ModularRestaurant.Menus.Domain.Entities.Group", "Groups", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Name")
                                .HasColumnType("text");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("Groups");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("ModularRestaurant.Menus.Domain.Entities.Item", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Description")
                                        .HasColumnType("text");

                                    b2.Property<Guid>("GroupId")
                                        .HasColumnType("uuid");

                                    b2.Property<string>("Image")
                                        .HasColumnType("text");

                                    b2.Property<string>("Name")
                                        .HasColumnType("text");

                                    b2.HasKey("Id");

                                    b2.HasIndex("GroupId");

                                    b2.ToTable("Items");

                                    b2.WithOwner()
                                        .HasForeignKey("GroupId");

                                    b2.OwnsOne("ModularRestaurant.Shared.Domain.ValueObjects.Money", "Price", b3 =>
                                        {
                                            b3.Property<Guid>("ItemId")
                                                .HasColumnType("uuid");

                                            b3.Property<string>("Currency")
                                                .HasColumnType("text")
                                                .HasColumnName("PriceCurrency");

                                            b3.Property<decimal>("Value")
                                                .HasColumnType("numeric")
                                                .HasColumnName("PriceValue");

                                            b3.HasKey("ItemId");

                                            b3.ToTable("Items");

                                            b3.WithOwner()
                                                .HasForeignKey("ItemId");
                                        });

                                    b2.Navigation("Price");
                                });

                            b1.Navigation("Items");
                        });

                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}