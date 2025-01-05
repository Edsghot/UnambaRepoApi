﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnambaRepoApi.Configuration.Context;

#nullable disable

namespace UnambaRepoApi.Migrations
{
    [DbContext(typeof(MySqlContext))]
    partial class MySqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UnambaRepoApi.Modules.Teacher.Domain.Entity.TeacherEntity", b =>
                {
                    b.Property<int>("IdTeacher")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .HasMaxLength(900)
                        .HasColumnType("varchar(900)");

                    b.Property<string>("Facebook")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("Gender")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Instagram")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("LinkedIn")
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("RegistrationCode")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("IdTeacher");

                    b.ToTable("Teacher", (string)null);
                });

            modelBuilder.Entity("UnambaRepoApi.Modules.Teacher.Domain.Entity.TeachingExperienceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("InstitutionType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("TeacherType")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("TeachingExperience", (string)null);
                });

            modelBuilder.Entity("UnambaRepoApi.Modules.Teacher.Domain.Entity.ThesisAdvisingExperienceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Repository")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.Property<string>("Thesis")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("ThesisAcceptanceDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ThesisStudent")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("University")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("ThesisAdvisingExperience", (string)null);
                });

            modelBuilder.Entity("UnambaRepoApi.Modules.Teacher.Domain.Entity.WorkExperienceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsCurrent")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("JobDescription")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("JobIdi")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("varchar(400)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeacherId");

                    b.ToTable("WorkExperience", (string)null);
                });

            modelBuilder.Entity("UnambaRepoApi.Modules.User.Domain.Entity.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Years")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("UnambaRepoApi.Modules.Teacher.Domain.Entity.TeachingExperienceEntity", b =>
                {
                    b.HasOne("UnambaRepoApi.Modules.Teacher.Domain.Entity.TeacherEntity", "Teacher")
                        .WithMany("TeachingExperiences")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UnambaRepoApi.Modules.Teacher.Domain.Entity.ThesisAdvisingExperienceEntity", b =>
                {
                    b.HasOne("UnambaRepoApi.Modules.Teacher.Domain.Entity.TeacherEntity", "Teacher")
                        .WithMany("ThesisAdvisingExperiences")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UnambaRepoApi.Modules.Teacher.Domain.Entity.WorkExperienceEntity", b =>
                {
                    b.HasOne("UnambaRepoApi.Modules.Teacher.Domain.Entity.TeacherEntity", "Teacher")
                        .WithMany("WorkExperiences")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("UnambaRepoApi.Modules.Teacher.Domain.Entity.TeacherEntity", b =>
                {
                    b.Navigation("TeachingExperiences");

                    b.Navigation("ThesisAdvisingExperiences");

                    b.Navigation("WorkExperiences");
                });
#pragma warning restore 612, 618
        }
    }
}
