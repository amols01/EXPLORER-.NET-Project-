﻿// <auto-generated />
using System;
using Bhatkanti.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bhatkanti.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Bhatkanti.Models.Bill", b =>
                {
                    b.Property<int>("Bill_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Bill_ID"));

                    b.Property<int?>("Booking_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("GST")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("Guide_ID")
                        .HasColumnType("int");

                    b.Property<decimal>("Platform_Fee")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("Timestamp"));

                    b.Property<decimal>("Total_Bill_Amount")
                        .HasColumnType("decimal(65,30)");

                    b.Property<decimal>("Total_Guide_Fee")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Bill_ID");

                    b.HasIndex("Guide_ID");

                    b.ToTable("bill");
                });

            modelBuilder.Entity("Bhatkanti.Models.Booking_Payment_Details", b =>
                {
                    b.Property<string>("Payment_ID")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<string>("Bank_Transaction_Code")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("Booking_ID")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Status")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("Timestamp"));

                    b.Property<DateTime>("Transaction_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Transaction_Mode")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.HasKey("Payment_ID");

                    b.HasIndex("Booking_ID");

                    b.ToTable("booking_payment_details");
                });

            modelBuilder.Entity("Bhatkanti.Models.Booking_Place_Guide", b =>
                {
                    b.Property<int>("Booking_Place_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Booking_Place_ID"));

                    b.Property<int?>("Booking_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Guide_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Place_ID")
                        .HasColumnType("int");

                    b.HasKey("Booking_Place_ID");

                    b.HasIndex("Booking_ID");

                    b.HasIndex("Guide_ID");

                    b.HasIndex("Place_ID");

                    b.ToTable("booking_place_guide");
                });

            modelBuilder.Entity("Bhatkanti.Models.Cities", b =>
                {
                    b.Property<int>("City_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("City_ID"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("State_ID")
                        .HasColumnType("int");

                    b.HasKey("City_ID");

                    b.HasIndex("State_ID");

                    b.ToTable("city");
                });

            modelBuilder.Entity("Bhatkanti.Models.Feedback_Image", b =>
                {
                    b.Property<int>("Feedback_Image_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Feedback_Image_Id"));

                    b.Property<int>("Image_ID")
                        .HasColumnType("int");

                    b.Property<int>("Place_Feedback_ID")
                        .HasColumnType("int");

                    b.HasKey("Feedback_Image_Id");

                    b.HasIndex("Image_ID");

                    b.HasIndex("Place_Feedback_ID");

                    b.ToTable("place_feedback_images");
                });

            modelBuilder.Entity("Bhatkanti.Models.Guide", b =>
                {
                    b.Property<int>("Guide_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Guide_ID"));

                    b.Property<string>("Aadhar_Number")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<string>("Account_Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PAN_Number")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Guide_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("guide");
                });

            modelBuilder.Entity("Bhatkanti.Models.Guide_Feedbacks", b =>
                {
                    b.Property<int>("Guide_Feedback_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Guide_Feedback_ID"));

                    b.Property<string>("Guide_Feedback")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Guide_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Guide_Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Guide_Feedback_ID");

                    b.HasIndex("Guide_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("guide_feedback");
                });

            modelBuilder.Entity("Bhatkanti.Models.Guide_Places", b =>
                {
                    b.Property<int>("GP_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("GP_ID"));

                    b.Property<decimal>("Guide_Fee")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("Guide_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Place_ID")
                        .HasColumnType("int");

                    b.HasKey("GP_ID");

                    b.HasIndex("Guide_ID");

                    b.HasIndex("Place_ID");

                    b.ToTable("guide_places");
                });

            modelBuilder.Entity("Bhatkanti.Models.Help", b =>
                {
                    b.Property<int>("Help_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Help_ID"));

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Query")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("Timestamp"));

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Help_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("help");
                });

            modelBuilder.Entity("Bhatkanti.Models.Images", b =>
                {
                    b.Property<int>("Image_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Image_ID"));

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("longblob");

                    b.Property<string>("Image_Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("Image_Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("Image_Timestamp"));

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Image_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("images");
                });

            modelBuilder.Entity("Bhatkanti.Models.M_Roles", b =>
                {
                    b.Property<int>("Role_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Role_ID"));

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Role_ID");

                    b.ToTable("m_roles");
                });

            modelBuilder.Entity("Bhatkanti.Models.M_States", b =>
                {
                    b.Property<int>("State_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("State_ID"));

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("State_ID");

                    b.ToTable("m_states");
                });

            modelBuilder.Entity("Bhatkanti.Models.Place", b =>
                {
                    b.Property<int>("Place_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Place_ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("City_ID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nearest_PS")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Place_Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Place_ID");

                    b.HasIndex("City_ID");

                    b.ToTable("place");
                });

            modelBuilder.Entity("Bhatkanti.Models.Place_Feedbacks", b =>
                {
                    b.Property<int>("Place_Feedback_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Place_Feedback_ID"));

                    b.Property<string>("Place_Feedback")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Place_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Place_Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("Timestamp"));

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Place_Feedback_ID");

                    b.HasIndex("Place_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("place_feedback");
                });

            modelBuilder.Entity("Bhatkanti.Models.Place_Images", b =>
                {
                    b.Property<int>("Place_Image_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Place_Image_Id"));

                    b.Property<int>("Image_ID")
                        .HasColumnType("int");

                    b.Property<int>("Place_ID")
                        .HasColumnType("int");

                    b.HasKey("Place_Image_Id");

                    b.HasIndex("Image_ID");

                    b.HasIndex("Place_ID");

                    b.ToTable("place_images");
                });

            modelBuilder.Entity("Bhatkanti.Models.User_Guide_Bookings", b =>
                {
                    b.Property<int>("Booking_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Booking_ID"));

                    b.Property<int?>("Bill_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date_From")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date_To")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("Guide_ID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Time_From")
                        .HasColumnType("time(6)");

                    b.Property<TimeSpan>("Time_To")
                        .HasColumnType("time(6)");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("Timestamp"));

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Booking_ID");

                    b.HasIndex("Bill_ID");

                    b.HasIndex("Guide_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("user_guide_bookings");
                });

            modelBuilder.Entity("Bhatkanti.Models.Users", b =>
                {
                    b.Property<int>("User_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("User_ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("Guide_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Image_ID")
                        .HasColumnType("int");

                    b.Property<int?>("M_RolesRole_ID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)");

                    b.Property<byte[]>("Profile_Image")
                        .HasColumnType("longblob");

                    b.Property<int>("Role_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("Timestamp"));

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("User_ID");

                    b.HasIndex("Guide_ID");

                    b.HasIndex("M_RolesRole_ID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Bhatkanti.Models.Wishlist", b =>
                {
                    b.Property<int>("Wishlist_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Wishlist_ID"));

                    b.Property<int?>("City_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Place_ID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime(6)");

                    b.Property<int?>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("Wishlist_ID");

                    b.HasIndex("City_ID");

                    b.HasIndex("Place_ID");

                    b.HasIndex("User_ID");

                    b.ToTable("wishlist");
                });

            modelBuilder.Entity("Bhatkanti.Models.Bill", b =>
                {
                    b.HasOne("Bhatkanti.Models.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("Guide_ID");

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("Bhatkanti.Models.Booking_Payment_Details", b =>
                {
                    b.HasOne("Bhatkanti.Models.User_Guide_Bookings", "Booking")
                        .WithMany()
                        .HasForeignKey("Booking_ID");

                    b.Navigation("Booking");
                });

            modelBuilder.Entity("Bhatkanti.Models.Booking_Place_Guide", b =>
                {
                    b.HasOne("Bhatkanti.Models.User_Guide_Bookings", "Booking")
                        .WithMany()
                        .HasForeignKey("Booking_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Bhatkanti.Models.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("Guide_ID");

                    b.HasOne("Bhatkanti.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("Place_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Booking");

                    b.Navigation("Guide");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Bhatkanti.Models.Cities", b =>
                {
                    b.HasOne("Bhatkanti.Models.M_States", "State")
                        .WithMany()
                        .HasForeignKey("State_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("State");
                });

            modelBuilder.Entity("Bhatkanti.Models.Feedback_Image", b =>
                {
                    b.HasOne("Bhatkanti.Models.Images", "Image")
                        .WithMany()
                        .HasForeignKey("Image_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bhatkanti.Models.Place_Feedbacks", "Place_Feedback")
                        .WithMany()
                        .HasForeignKey("Place_Feedback_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Place_Feedback");
                });

            modelBuilder.Entity("Bhatkanti.Models.Guide", b =>
                {
                    b.HasOne("Bhatkanti.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bhatkanti.Models.Guide_Feedbacks", b =>
                {
                    b.HasOne("Bhatkanti.Models.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("Guide_ID");

                    b.HasOne("Bhatkanti.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Guide");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bhatkanti.Models.Guide_Places", b =>
                {
                    b.HasOne("Bhatkanti.Models.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("Guide_ID");

                    b.HasOne("Bhatkanti.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("Place_ID");

                    b.Navigation("Guide");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Bhatkanti.Models.Help", b =>
                {
                    b.HasOne("Bhatkanti.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bhatkanti.Models.Images", b =>
                {
                    b.HasOne("Bhatkanti.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bhatkanti.Models.Place", b =>
                {
                    b.HasOne("Bhatkanti.Models.Cities", "City")
                        .WithMany()
                        .HasForeignKey("City_ID");

                    b.Navigation("City");
                });

            modelBuilder.Entity("Bhatkanti.Models.Place_Feedbacks", b =>
                {
                    b.HasOne("Bhatkanti.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("Place_ID");

                    b.HasOne("Bhatkanti.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bhatkanti.Models.Place_Images", b =>
                {
                    b.HasOne("Bhatkanti.Models.Images", "Image")
                        .WithMany()
                        .HasForeignKey("Image_ID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Bhatkanti.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("Place_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("Bhatkanti.Models.User_Guide_Bookings", b =>
                {
                    b.HasOne("Bhatkanti.Models.Bill", "Bill")
                        .WithMany("Bookings")
                        .HasForeignKey("Bill_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Bhatkanti.Models.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("Guide_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Bhatkanti.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Bill");

                    b.Navigation("Guide");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bhatkanti.Models.Users", b =>
                {
                    b.HasOne("Bhatkanti.Models.Guide", "Guide")
                        .WithMany()
                        .HasForeignKey("Guide_ID");

                    b.HasOne("Bhatkanti.Models.M_Roles", null)
                        .WithMany("Users")
                        .HasForeignKey("M_RolesRole_ID");

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("Bhatkanti.Models.Wishlist", b =>
                {
                    b.HasOne("Bhatkanti.Models.Cities", "City")
                        .WithMany()
                        .HasForeignKey("City_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Bhatkanti.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("Place_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("Bhatkanti.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("City");

                    b.Navigation("Place");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Bhatkanti.Models.Bill", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Bhatkanti.Models.M_Roles", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
