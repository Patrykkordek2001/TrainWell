﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrainWell___BACKEND.Database;

#nullable disable

namespace TrainWell___BACKEND.Migrations
{
    [DbContext(typeof(TrainWellDbContext))]
    [Migration("20231121150514_DeleteUSerPhone")]
    partial class DeleteUSerPhone
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrainWell___BACKEND.Models.Diet.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MealName")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Diet.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Calories")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohydrates")
                        .HasColumnType("float");

                    b.Property<double?>("Fat")
                        .HasColumnType("float");

                    b.Property<double?>("Fiber")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Proteins")
                        .HasColumnType("float");

                    b.Property<double?>("Salt")
                        .HasColumnType("float");

                    b.Property<double?>("StaruratedFat")
                        .HasColumnType("float");

                    b.Property<double?>("Sugars")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Diet.ProductInMeal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Grams")
                        .HasColumnType("float");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.HasIndex("ProductId")
                        .IsUnique();

                    b.ToTable("ProductsInMeal");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Measurement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Arm")
                        .HasColumnType("float");

                    b.Property<double>("Chest")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("Hips")
                        .HasColumnType("float");

                    b.Property<double>("Shoulders")
                        .HasColumnType("float");

                    b.Property<double>("Thigh")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("Waist")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Measurements");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.ExerciseSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExerciseWorkoutId")
                        .HasColumnType("int");

                    b.Property<int>("Repetitions")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseWorkoutId");

                    b.ToTable("ExerciseSets");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.ExerciseWorkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ExerciseId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExerciseId");

                    b.HasIndex("WorkoutId");

                    b.ToTable("ExerciseWorkouts");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.User.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.User.UserInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Activity")
                        .HasColumnType("int");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CaloriesPerDay")
                        .HasColumnType("int");

                    b.Property<int>("CarbohydratesPerDay")
                        .HasColumnType("int");

                    b.Property<int>("FatPerDay")
                        .HasColumnType("int");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Growth")
                        .HasColumnType("int");

                    b.Property<int>("ProteinsPerDay")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Diet.ProductInMeal", b =>
                {
                    b.HasOne("TrainWell___BACKEND.Models.Diet.Meal", "Meal")
                        .WithMany("ProductsInMeal")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrainWell___BACKEND.Models.Diet.Product", "Product")
                        .WithOne("ProductInMeal")
                        .HasForeignKey("TrainWell___BACKEND.Models.Diet.ProductInMeal", "ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meal");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.ExerciseSet", b =>
                {
                    b.HasOne("TrainWell___BACKEND.Models.Training.ExerciseWorkout", "ExerciseWorkout")
                        .WithMany("ExerciseSets")
                        .HasForeignKey("ExerciseWorkoutId");

                    b.Navigation("ExerciseWorkout");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.ExerciseWorkout", b =>
                {
                    b.HasOne("TrainWell___BACKEND.Models.Training.Exercise", "Exercise")
                        .WithMany("ExerciseWorkouts")
                        .HasForeignKey("ExerciseId");

                    b.HasOne("TrainWell___BACKEND.Models.Training.Workout", "Workout")
                        .WithMany("ExerciseWorkouts")
                        .HasForeignKey("WorkoutId");

                    b.Navigation("Exercise");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.User.UserInfo", b =>
                {
                    b.HasOne("TrainWell___BACKEND.Models.User.User", "User")
                        .WithOne("UserInfo")
                        .HasForeignKey("TrainWell___BACKEND.Models.User.UserInfo", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Diet.Meal", b =>
                {
                    b.Navigation("ProductsInMeal");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Diet.Product", b =>
                {
                    b.Navigation("ProductInMeal");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.Exercise", b =>
                {
                    b.Navigation("ExerciseWorkouts");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.ExerciseWorkout", b =>
                {
                    b.Navigation("ExerciseSets");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.Training.Workout", b =>
                {
                    b.Navigation("ExerciseWorkouts");
                });

            modelBuilder.Entity("TrainWell___BACKEND.Models.User.User", b =>
                {
                    b.Navigation("UserInfo")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
