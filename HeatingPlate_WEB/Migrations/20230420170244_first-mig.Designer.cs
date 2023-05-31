﻿// <auto-generated />
using HeatingPlate_WEB.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HeatingPlate_WEB.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230420170244_first-mig")]
    partial class firstmig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.5");

            modelBuilder.Entity("HeatingPlate_WEB.Data.coefficients", b =>
                {
                    b.Property<int>("coefficient_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("bi")
                        .HasColumnType("REAL");

                    b.Property<float>("number_m")
                        .HasColumnType("REAL");

                    b.Property<float>("number_n")
                        .HasColumnType("REAL");

                    b.Property<float>("number_p")
                        .HasColumnType("REAL");

                    b.Property<float>("thickness")
                        .HasColumnType("REAL");

                    b.HasKey("coefficient_id");

                    b.ToTable("coefficients");
                });

            modelBuilder.Entity("HeatingPlate_WEB.Data.metals", b =>
                {
                    b.Property<int>("metal_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("density")
                        .HasColumnType("INTEGER");

                    b.Property<float>("forward_movement")
                        .HasColumnType("REAL");

                    b.Property<float>("heat_capacity")
                        .HasColumnType("REAL");

                    b.Property<float>("lambda")
                        .HasColumnType("REAL");

                    b.Property<string>("metal_name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("temperature")
                        .HasColumnType("INTEGER");

                    b.HasKey("metal_id");

                    b.ToTable("metals");
                });
#pragma warning restore 612, 618
        }
    }
}