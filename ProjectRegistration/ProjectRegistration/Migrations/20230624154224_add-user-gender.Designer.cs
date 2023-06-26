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
    [DbContext(typeof(IDENTITYUSERContext))]
    [Migration("20230624154224_add-user-gender")]
    partial class addusergender
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("ProjectRegistration.Models.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClassId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Cyear")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CYear");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("RegEnd")
                        .HasColumnType("datetime2");

                    b.Property<string>("RegOpen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegStart")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Classes__3214EC07C7FBE7D2");

                    b.HasIndex("CourseId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("ProjectRegistration.Models.ClassDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PK__ClassDet__3214EC07265C2FDC");

                    b.HasIndex("ClassId");

                    b.HasIndex("UserId");

                    b.ToTable("ClassDetails");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CourseId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.HasKey("Id")
                        .HasName("PK__Courses__3214EC077A99B303");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Dname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__Departme__3214EC07D7964779");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PK__Document__3214EC07AF051F9B");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ProjectRegistration.Models.LecturerStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("AvgGrade")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<string>("LecturerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("Syear")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SYear");

                    b.Property<int?>("TotalProjectsGraded")
                        .HasColumnType("int");

                    b.Property<int?>("TotalProjectsGuided")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Lecturer__3214EC07073DD833");

                    b.HasIndex("LecturerId");

                    b.ToTable("LecturerStats");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PK__Products__3214EC07F35EC2C6");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProjectRegistration.Models.ProductDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("ProductPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__ProductD__3214EC07802A3FFF");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductDetails");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ClassId")
                        .HasColumnType("int");

                    b.Property<int?>("ClassId2")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("GradingLecturerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("GuidingLecturerId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Info")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Pname")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PName");

                    b.Property<string>("Pyear")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PYear");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Projects__3214EC07CFEA4E65");

                    b.HasIndex("ClassId");

                    b.HasIndex("ClassId2");

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<double?>("Grade")
                        .HasColumnType("float");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id")
                        .HasName("PK__ProjectM__3214EC0757140A70");

                    b.HasIndex("ProjectId");

                    b.HasIndex("StudentId");

                    b.ToTable("ProjectMembers");
                });

            modelBuilder.Entity("ProjectRegistration.Models.StudentStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("AvgGrade")
                        .HasColumnType("float");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("FinishedProjects")
                        .HasColumnType("int");

                    b.Property<int?>("Semester")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Syear")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SYear");

                    b.Property<int?>("TotalProjects")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__StudentS__3214EC076466FA7E");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentStats");
                });

            modelBuilder.Entity("ProjectRegistration.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("Deleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DeletedDateTime")
                        .HasColumnType("smalldatetime");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("UserTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Users__3214EC0714467FCB");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProjectRegistration.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProjectRegistration.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProjectRegistration.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProjectRegistration.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectRegistration.Models.Class", b =>
                {
                    b.HasOne("ProjectRegistration.Models.Course", "Course")
                        .WithMany("Classes")
                        .HasForeignKey("CourseId")
                        .HasConstraintName("FK_Classes_CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ProjectRegistration.Models.ClassDetail", b =>
                {
                    b.HasOne("ProjectRegistration.Models.Class", "Class")
                        .WithMany("ClassDetails")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_ClassDetails_ClassId");

                    b.HasOne("ProjectRegistration.Models.User", "User")
                        .WithMany("ClassDetails")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_ClassDetails_UserId");

                    b.Navigation("Class");

                    b.Navigation("User");
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
                    b.HasOne("ProjectRegistration.Models.Class", "Class")
                        .WithMany("ProjectClasses")
                        .HasForeignKey("ClassId")
                        .HasConstraintName("FK_Projects_ClassId");

                    b.HasOne("ProjectRegistration.Models.Class", "ClassId2Navigation")
                        .WithMany("ProjectClassId2Navigations")
                        .HasForeignKey("ClassId2")
                        .HasConstraintName("FK_Projects_ClassId2");

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

                    b.Navigation("Class");

                    b.Navigation("ClassId2Navigation");

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

            modelBuilder.Entity("ProjectRegistration.Models.Class", b =>
                {
                    b.Navigation("ClassDetails");

                    b.Navigation("ProjectClassId2Navigations");

                    b.Navigation("ProjectClasses");
                });

            modelBuilder.Entity("ProjectRegistration.Models.Course", b =>
                {
                    b.Navigation("Classes");
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
                    b.Navigation("ClassDetails");

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
