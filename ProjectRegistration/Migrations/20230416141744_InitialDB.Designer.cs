﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjectRegistration.Models;

#nullable disable

namespace ProjectRegistration.Migrations
{
    [DbContext(typeof(ProjectRegistrationManagementContext))]
    [Migration("20230416141744_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProjectRegistration.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("Cyear")
                        .HasColumnType("int")
                        .HasColumnName("CYear");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Classes__3214EC07339A5E70");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("Cyear")
                        .HasColumnType("int")
                        .HasColumnName("CYear");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Courses__3214EC07BE249912");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Dname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Departme__3214EC074FB0CB9F");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Document__3214EC079026AE41");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ProjectRegistration.Models.LecturerStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("AvgGrade")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.Property<int?>("Syear")
                        .HasColumnType("int")
                        .HasColumnName("SYear");

                    b.Property<int?>("TotalProjectsGraded")
                        .HasColumnType("int");

                    b.Property<int?>("TotalProjectsGuided")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Lecturer__3214EC07C06C93CA");

                    b.HasIndex("LecturerId");

                    b.ToTable("LecturerStats");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Products__3214EC07069534B4");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProjectRegistration.Models.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__ProductD__3214EC071DE98856");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId2")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("GradingLecturerId")
                        .HasColumnType("int");

                    b.Property<int?>("GuidingLecturerId")
                        .HasColumnType("int");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaxMember")
                        .HasColumnType("int");

                    b.Property<string>("Pname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PName");

                    b.Property<int?>("Pyear")
                        .HasColumnType("int")
                        .HasColumnName("PYear");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Projects__3214EC07F1BD175F");

                    b.HasIndex("CourseId");

                    b.HasIndex("CourseId2");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("GradingLecturerId");

                    b.HasIndex("GuidingLecturerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectRegistration.Models.ProjectMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<double?>("Grade")
                        .HasColumnType("float");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__ProjectM__3214EC07D4367647");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("ProjectRegistration.Models.StudentStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("AvgGrade")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("FinishedProjects")
                        .HasColumnType("int");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.Property<int?>("StudentId")
                        .HasColumnType("int");

                    b.Property<int?>("Syear")
                        .HasColumnType("int")
                        .HasColumnName("SYear");

                    b.Property<int?>("TotalProjects")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__StudentS__3214EC07DBB6243E");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentStats");
                });

            modelBuilder.Entity("ProjectRegistration.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("UserPassword")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Users__3214EC07392CD93F");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Document", b =>
                {
                    b.HasOne("ProjectRegistration.Models.Project", "Project")
                        .WithMany("Documents")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_Documents_ProjectId");

                    b.HasOne("ProjectRegistration.Models.User", "User")
                        .WithMany("Documents")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Documents_UserId");

                    b.Navigation("Project");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectRegistration.Models.LecturerStat", b =>
                {
                    b.HasOne("ProjectRegistration.Models.User", "Lecturer")
                        .WithMany("LecturerStats")
                        .HasForeignKey("LecturerId")
                        .HasConstraintName("FK_LecturerStats_LecturerId");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Product", b =>
                {
                    b.HasOne("ProjectRegistration.Models.Project", "Project")
                        .WithMany("Products")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_Products_ProjectId");

                    b.HasOne("ProjectRegistration.Models.User", "Student")
                        .WithMany("Products")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_Products_StudentId");

                    b.Navigation("Project");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjectRegistration.Models.ProductDetail", b =>
                {
                    b.HasOne("ProjectRegistration.Models.Product", "Product")
                        .WithMany("ProductDetails")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_ProductDetails_ProductId");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Project", b =>
                {
                    b.HasOne("ProjectRegistration.Models.Course", "Course")
                        .WithMany("ProjectCourses")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_Projects_CourseId");

                    b.HasOne("ProjectRegistration.Models.Course", "CourseId2Navigation")
                        .WithMany("ProjectCourseId2Navigations")
                        .HasForeignKey("CourseId2")
                        .HasConstraintName("FK_Projects_CourseId2");

                    b.HasOne("ProjectRegistration.Models.Department", "Department")
                        .WithMany("Projects")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Projects_DepartmentId");

                    b.HasOne("ProjectRegistration.Models.User", "GradingLecturer")
                        .WithMany("ProjectGradingLecturers")
                        .HasForeignKey("GradingLecturerId")
                        .HasConstraintName("FK_Projects_GradingLecturerId");

                    b.HasOne("ProjectRegistration.Models.User", "GuidingLecturer")
                        .WithMany("ProjectGuidingLecturers")
                        .HasForeignKey("GuidingLecturerId")
                        .HasConstraintName("FK_Projects_GuidingLecturerId");

                    b.Navigation("Course");

                    b.Navigation("CourseId2Navigation");

                    b.Navigation("Department");

                    b.Navigation("GradingLecturer");

                    b.Navigation("GuidingLecturer");
                });

            modelBuilder.Entity("ProjectRegistration.Models.ProjectMember", b =>
                {
                    b.HasOne("ProjectRegistration.Models.Project", "Project")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("ProjectId")
                        .HasConstraintName("FK_ProjectMembers_ProjectId");

                    b.HasOne("ProjectRegistration.Models.User", "Student")
                        .WithMany("ProjectMembers")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_ProjectMembers_StudentId");

                    b.Navigation("Project");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjectRegistration.Models.StudentStat", b =>
                {
                    b.HasOne("ProjectRegistration.Models.User", "Student")
                        .WithMany("StudentStats")
                        .HasForeignKey("StudentId")
                        .HasConstraintName("FK_StudentStats_StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ProjectRegistration.Models.User", b =>
                {
                    b.HasOne("ProjectRegistration.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId")
                        .HasConstraintName("FK_Users_DepartmentId");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Course", b =>
                {
                    b.Navigation("ProjectCourseId2Navigations");

                    b.Navigation("ProjectCourses");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Department", b =>
                {
                    b.Navigation("Projects");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Product", b =>
                {
                    b.Navigation("ProductDetails");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Project", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Products");

                    b.Navigation("ProjectMembers");
                });

            modelBuilder.Entity("ProjectRegistration.Models.User", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("LecturerStats");

                    b.Navigation("Products");

                    b.Navigation("ProjectGradingLecturers");

                    b.Navigation("ProjectGuidingLecturers");

                    b.Navigation("ProjectMembers");

                    b.Navigation("StudentStats");
                });
#pragma warning restore 612, 618
        }
    }
}
