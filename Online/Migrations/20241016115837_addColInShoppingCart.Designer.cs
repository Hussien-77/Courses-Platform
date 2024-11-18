﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Online.Data;

#nullable disable

namespace Online.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241016115837_addColInShoppingCart")]
    partial class addColInShoppingCart
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Online.Models.CardItem", b =>
                {
                    b.Property<int>("CartItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CartItemId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("CartItemId");

                    b.HasIndex("CourseId");

                    b.HasIndex("ShoppingCartId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("CardItems");
                });

            modelBuilder.Entity("Online.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categoryes");
                });

            modelBuilder.Entity("Online.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Hours")
                        .HasColumnType("real");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("Lesson")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("CourseId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("InstructorId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("Online.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorID"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("InstructorID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("Online.Models.ShoppingCart", b =>
                {
                    b.Property<int>("ShoppingCartId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShoppingCartId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ShoppingCartId");

                    b.ToTable("ShoppingCarts");
                });

            modelBuilder.Entity("Online.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateRegistered")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Online.Models.CardItem", b =>
                {
                    b.HasOne("Online.Models.Course", "Course")
                        .WithMany("cardItem")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online.Models.ShoppingCart", "ShoppingCart")
                        .WithMany("CartItems")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online.Models.Student", "Student")
                        .WithOne("cardItem")
                        .HasForeignKey("Online.Models.CardItem", "StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("ShoppingCart");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("Online.Models.Course", b =>
                {
                    b.HasOne("Online.Models.Category", "Category")
                        .WithMany("Course")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Online.Models.Instructor", "Instructor")
                        .WithMany("Course")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("Online.Models.Category", b =>
                {
                    b.Navigation("Course");
                });

            modelBuilder.Entity("Online.Models.Course", b =>
                {
                    b.Navigation("cardItem");
                });

            modelBuilder.Entity("Online.Models.Instructor", b =>
                {
                    b.Navigation("Course");
                });

            modelBuilder.Entity("Online.Models.ShoppingCart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Online.Models.Student", b =>
                {
                    b.Navigation("cardItem");
                });
#pragma warning restore 612, 618
        }
    }
}
