﻿// <auto-generated />
using EmployeeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EmployeeManagementSystem.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EmployeeManagementSystem.Models.Department", b =>
                {
                    b.Property<int>("DepId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepId"), 1L, 1);

                    b.Property<string>("DepName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Models.Personnel", b =>
                {
                    b.Property<int>("PersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersId"), 1L, 1);

                    b.Property<int>("DepId")
                        .HasColumnType("int");

                    b.Property<string>("PersName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersId");

                    b.HasIndex("DepId");

                    b.ToTable("Personnels");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Models.Personnel", b =>
                {
                    b.HasOne("EmployeeManagementSystem.Models.Department", "Department")
                        .WithMany("Personnels")
                        .HasForeignKey("DepId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("EmployeeManagementSystem.Models.Department", b =>
                {
                    b.Navigation("Personnels");
                });
#pragma warning restore 612, 618
        }
    }
}
