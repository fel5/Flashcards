﻿// <auto-generated />
using System;
using Flashcards2.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flashcards2.Migrations
{
    [DbContext(typeof(FlashcardsDbContext))]
    [Migration("20200629145209_AddPositionToSection")]
    partial class AddPositionToSection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("Flashcards2.DataLayer.Flashcard", b =>
                {
                    b.Property<int>("FlashcardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Answer")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Question")
                        .HasColumnType("TEXT");

                    b.Property<int>("SectionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Stage")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("FlashcardId");

                    b.HasIndex("SectionId");

                    b.ToTable("Flashcards");
                });

            modelBuilder.Entity("Flashcards2.DataLayer.Query", b =>
                {
                    b.Property<int>("QueryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("FlashcardId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Success")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("QueryId");

                    b.HasIndex("FlashcardId");

                    b.ToTable("Queries");
                });

            modelBuilder.Entity("Flashcards2.DataLayer.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int>("Position")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("TopicId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("SectionId");

                    b.HasIndex("TopicId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("Flashcards2.DataLayer.Topic", b =>
                {
                    b.Property<int>("TopicId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.HasKey("TopicId");

                    b.ToTable("Topics");
                });

            modelBuilder.Entity("Flashcards2.DataLayer.Flashcard", b =>
                {
                    b.HasOne("Flashcards2.DataLayer.Section", "Section")
                        .WithMany("Flashcards")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Flashcards2.DataLayer.Query", b =>
                {
                    b.HasOne("Flashcards2.DataLayer.Flashcard", "Flashcard")
                        .WithMany("Queries")
                        .HasForeignKey("FlashcardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Flashcards2.DataLayer.Section", b =>
                {
                    b.HasOne("Flashcards2.DataLayer.Topic", "Topic")
                        .WithMany("Sections")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
