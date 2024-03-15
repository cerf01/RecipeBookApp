﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeBookApp.DAL;

#nullable disable

namespace RecipeBookApp.DAL.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240313170708_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Products.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("DetailsId")
                        .HasColumnType("int");

                    b.Property<int>("FoodType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetailsId")
                        .IsUnique()
                        .HasFilter("[DetailsId] IS NOT NULL");

                    b.ToTable("Food");
                });

            modelBuilder.Entity("RecipeBookApp.DAL.Moduls.FoodDetails", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<float>("Calories")
                        .HasColumnType("real");

                    b.Property<float>("FatTota")
                        .HasColumnType("real");

                    b.Property<float>("Fiber")
                        .HasColumnType("real");

                    b.Property<float>("Protein")
                        .HasColumnType("real");

                    b.Property<float>("Sugar")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("FoodDetails");
                });

            modelBuilder.Entity("RecipeBookApp.DAL.Moduls.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("AddetAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeBookApp.DAL.Moduls.RecipeFood", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeFoods");
                });

            modelBuilder.Entity("Products.Food", b =>
                {
                    b.HasOne("RecipeBookApp.DAL.Moduls.FoodDetails", "Details")
                        .WithOne()
                        .HasForeignKey("Products.Food", "DetailsId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Details");
                });

            modelBuilder.Entity("RecipeBookApp.DAL.Moduls.RecipeFood", b =>
                {
                    b.HasOne("Products.Food", "Food")
                        .WithMany("RecipeFood")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeBookApp.DAL.Moduls.Recipe", "Recipe")
                        .WithMany("RecipeFood")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("Products.Food", b =>
                {
                    b.Navigation("RecipeFood");
                });

            modelBuilder.Entity("RecipeBookApp.DAL.Moduls.Recipe", b =>
                {
                    b.Navigation("RecipeFood");
                });
#pragma warning restore 612, 618
        }
    }
}
