﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ModularRestaurant.Ratings.Infrastructure.EF;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ModularRestaurant.Ratings.Infrastructure.EF.Migrations
{
    [DbContext(typeof(RatingsDbContext))]
    partial class RatingsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("ratings")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("ModularRestaurant.Ratings.Domain.Entities.UserRating", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<Guid?>("RestaurantId")
                        .HasColumnType("uuid");

                    b.Property<string>("RestaurantReply")
                        .HasColumnType("text");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("UserRatings");
                });

            modelBuilder.Entity("ModularRestaurant.Ratings.Domain.Entities.UserRating", b =>
                {
                    b.OwnsOne("ModularRestaurant.Ratings.Domain.Entities.Rating", "Rating", b1 =>
                        {
                            b1.Property<Guid>("UserRatingId")
                                .HasColumnType("uuid");

                            b1.Property<int>("Value")
                                .HasColumnType("integer")
                                .HasColumnName("Value");

                            b1.HasKey("UserRatingId");

                            b1.ToTable("UserRatings");

                            b1.WithOwner()
                                .HasForeignKey("UserRatingId");
                        });

                    b.Navigation("Rating");
                });
#pragma warning restore 612, 618
        }
    }
}
