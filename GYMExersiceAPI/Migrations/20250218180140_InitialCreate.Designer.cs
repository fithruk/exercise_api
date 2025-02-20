﻿// <auto-generated />
using System;
using GYMExersiceAPI.ExersiceStore.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GYMExersiceAPI.Migrations
{
    [DbContext(typeof(ExerciseStroreDBContext))]
    [Migration("20250218180140_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExStepInstructionsEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ExerciseStepId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Instructions")
                        .IsRequired()
                        .HasColumnType("LONGTEXT");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseStepId");

                    b.ToTable("ExersicesInstructions");
                });

            modelBuilder.Entity("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExerciseStepEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("ExersiceId")
                        .HasColumnType("char(36)");

                    b.Property<int>("PhaseKey")
                        .HasColumnType("int");

                    b.Property<string>("PhaseName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("ExersiceId");

                    b.ToTable("ExersicesSteps");
                });

            modelBuilder.Entity("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExersiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Difficulty")
                        .HasColumnType("longtext");

                    b.Property<string>("Equipment")
                        .HasColumnType("longtext");

                    b.Property<string>("ExerciseMuscleGroup")
                        .HasColumnType("longtext");

                    b.Property<string>("ExerciseName")
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("TitleRu")
                        .HasColumnType("longtext");

                    b.Property<string>("TitleUa")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Exersices");
                });

            modelBuilder.Entity("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExStepInstructionsEntity", b =>
                {
                    b.HasOne("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExerciseStepEntity", "ExerciseStep")
                        .WithMany("Instructions")
                        .HasForeignKey("ExerciseStepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExerciseStep");
                });

            modelBuilder.Entity("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExerciseStepEntity", b =>
                {
                    b.HasOne("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExersiceEntity", "Exersice")
                        .WithMany("ExerciseSteps")
                        .HasForeignKey("ExersiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exersice");
                });

            modelBuilder.Entity("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExerciseStepEntity", b =>
                {
                    b.Navigation("Instructions");
                });

            modelBuilder.Entity("GYMExersiceAPI.ExersiceStore.DataAcess.Entities.ExersiceEntity", b =>
                {
                    b.Navigation("ExerciseSteps");
                });
#pragma warning restore 612, 618
        }
    }
}
