﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeBox.Models;

#nullable disable

namespace RecipeBox.Migrations
{
    [DbContext(typeof(RecipeBoxContext))]
    partial class RecipeBoxContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("RecipeBox.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ingredients")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("RecipeId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeBox.Models.RecipeTag", b =>
                {
                    b.Property<int>("RecipeTagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("RecipeTagId");

                    b.HasIndex("RecipeId");

                    b.HasIndex("TagId");

                    b.ToTable("RecipeTags");
                });

            modelBuilder.Entity("RecipeBox.Models.Tag", b =>
                {
                    b.Property<int>("TagId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("longtext");

                    b.Property<int>("RecipeId")
                        .HasColumnType("int");

                    b.HasKey("TagId");

                    b.HasIndex("RecipeId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("RecipeBox.Models.RecipeTag", b =>
                {
                    b.HasOne("RecipeBox.Models.Recipe", "Recipe")
                        .WithMany("JoinEntities")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RecipeBox.Models.Tag", "Tag")
                        .WithMany("JoinEntities")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("RecipeBox.Models.Tag", b =>
                {
                    b.HasOne("RecipeBox.Models.Recipe", "Recipe")
                        .WithMany("Tags")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipe");
                });

            modelBuilder.Entity("RecipeBox.Models.Recipe", b =>
                {
                    b.Navigation("JoinEntities");

                    b.Navigation("Tags");
                });

            modelBuilder.Entity("RecipeBox.Models.Tag", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
