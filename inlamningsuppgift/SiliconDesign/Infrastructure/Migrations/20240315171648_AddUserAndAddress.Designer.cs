﻿//// <auto-generated />
//using System;
//using Infrastructure.Contexts;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Infrastructure;
//using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.EntityFrameworkCore.Migrations;
//using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

//#nullable disable

//namespace Infrastructure.Migrations
//{
//    [DbContext(typeof(DataContext))]
//    [Migration("20240315171648_AddUserAndAddress")]
//    partial class AddUserAndAddress
//    {
//        /// <inheritdoc />
//        protected override void BuildTargetModel(ModelBuilder modelBuilder)
//        {
//#pragma warning disable 612, 618
//            modelBuilder
//                .HasAnnotation("ProductVersion", "8.0.3")
//                .HasAnnotation("Relational:MaxIdentifierLength", 128);

//            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

//            modelBuilder.Entity("Infrastructure.Entities.AddressEntity", b =>
//                {
//                    b.Property<int>("Id")
//                        .ValueGeneratedOnAdd()
//                        .HasColumnType("int");

//                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

//                    b.Property<string>("City")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("PostalCode")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("StreetName")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("UserId")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(450)");

//                    b.HasKey("Id");

//                    b.HasIndex("UserId")
//                        .IsUnique();

//                    b.ToTable("Addresses");
//                });

//            modelBuilder.Entity("Infrastructure.Entities.UserEntity", b =>
//                {
//                    b.Property<string>("Id")
//                        .HasColumnType("nvarchar(450)");

//                    b.Property<string>("Biography")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<DateTime>("Created")
//                        .HasColumnType("datetime2");

//                    b.Property<string>("Email")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("FirstName")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("LastName")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("Password")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("PhoneNumber")
//                        .HasColumnType("nvarchar(max)");

//                    b.Property<string>("SecurityKey")
//                        .IsRequired()
//                        .HasColumnType("nvarchar(max)");

//                    b.HasKey("Id");

//                    b.ToTable("Users");
//                });

//            modelBuilder.Entity("Infrastructure.Entities.AddressEntity", b =>
//                {
//                    b.HasOne("Infrastructure.Entities.UserEntity", "User")
//                        .WithOne("Address")
//                        .HasForeignKey("Infrastructure.Entities.AddressEntity", "UserId")
//                        .OnDelete(DeleteBehavior.Cascade)
//                        .IsRequired();

//                    b.Navigation("User");
//                });

//            modelBuilder.Entity("Infrastructure.Entities.UserEntity", b =>
//                {
//                    b.Navigation("Address")
//                        .IsRequired();
//                });
//#pragma warning restore 612, 618
//        }
//    }
//}
