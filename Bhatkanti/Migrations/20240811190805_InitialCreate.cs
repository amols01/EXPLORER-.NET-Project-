using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bhatkanti.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "m_roles",
                columns: table => new
                {
                    Role_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Role = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_roles", x => x.Role_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "m_states",
                columns: table => new
                {
                    State_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    State = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_m_states", x => x.State_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    City_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    State_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.City_ID);
                    table.ForeignKey(
                        name: "FK_city_m_states_State_ID",
                        column: x => x.State_ID,
                        principalTable: "m_states",
                        principalColumn: "State_ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "place",
                columns: table => new
                {
                    Place_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Place_Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City_ID = table.Column<int>(type: "int", nullable: true),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nearest_PS = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place", x => x.Place_ID);
                    table.ForeignKey(
                        name: "FK_place_city_City_ID",
                        column: x => x.City_ID,
                        principalTable: "city",
                        principalColumn: "City_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "bill",
                columns: table => new
                {
                    Bill_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Booking_ID = table.Column<int>(type: "int", nullable: true),
                    Total_Guide_Fee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    GST = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Platform_Fee = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Total_Bill_Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Guide_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill", x => x.Bill_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "booking_payment_details",
                columns: table => new
                {
                    Payment_ID = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Booking_ID = table.Column<int>(type: "int", nullable: true),
                    Transaction_Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Bank_Transaction_Code = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Transaction_Mode = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Status = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    Remarks = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_payment_details", x => x.Payment_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "booking_place_guide",
                columns: table => new
                {
                    Booking_Place_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Booking_ID = table.Column<int>(type: "int", nullable: true),
                    Guide_ID = table.Column<int>(type: "int", nullable: true),
                    Place_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking_place_guide", x => x.Booking_Place_ID);
                    table.ForeignKey(
                        name: "FK_booking_place_guide_place_Place_ID",
                        column: x => x.Place_ID,
                        principalTable: "place",
                        principalColumn: "Place_ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "guide",
                columns: table => new
                {
                    Guide_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Aadhar_Number = table.Column<string>(type: "varchar(12)", maxLength: 12, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PAN_Number = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Account_Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide", x => x.Guide_ID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "guide_places",
                columns: table => new
                {
                    GP_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Guide_ID = table.Column<int>(type: "int", nullable: true),
                    Place_ID = table.Column<int>(type: "int", nullable: true),
                    Guide_Fee = table.Column<decimal>(type: "decimal(65,30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_places", x => x.GP_ID);
                    table.ForeignKey(
                        name: "FK_guide_places_guide_Guide_ID",
                        column: x => x.Guide_ID,
                        principalTable: "guide",
                        principalColumn: "Guide_ID");
                    table.ForeignKey(
                        name: "FK_guide_places_place_Place_ID",
                        column: x => x.Place_ID,
                        principalTable: "place",
                        principalColumn: "Place_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Username = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Profile_Image = table.Column<byte[]>(type: "longblob", nullable: true),
                    Password = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image_ID = table.Column<int>(type: "int", nullable: true),
                    Role_ID = table.Column<int>(type: "int", nullable: false),
                    Guide_ID = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    M_RolesRole_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.User_ID);
                    table.ForeignKey(
                        name: "FK_users_guide_Guide_ID",
                        column: x => x.Guide_ID,
                        principalTable: "guide",
                        principalColumn: "Guide_ID");
                    table.ForeignKey(
                        name: "FK_users_m_roles_M_RolesRole_ID",
                        column: x => x.M_RolesRole_ID,
                        principalTable: "m_roles",
                        principalColumn: "Role_ID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "guide_feedback",
                columns: table => new
                {
                    Guide_Feedback_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Guide_ID = table.Column<int>(type: "int", nullable: true),
                    Guide_Feedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Guide_Rating = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_guide_feedback", x => x.Guide_Feedback_ID);
                    table.ForeignKey(
                        name: "FK_guide_feedback_guide_Guide_ID",
                        column: x => x.Guide_ID,
                        principalTable: "guide",
                        principalColumn: "Guide_ID");
                    table.ForeignKey(
                        name: "FK_guide_feedback_users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "help",
                columns: table => new
                {
                    Help_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone_Number = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Query = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Answer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_help", x => x.Help_ID);
                    table.ForeignKey(
                        name: "FK_help_users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "images",
                columns: table => new
                {
                    Image_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<byte[]>(type: "longblob", nullable: false),
                    Image_Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Image_Description = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images", x => x.Image_ID);
                    table.ForeignKey(
                        name: "FK_images_users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "place_feedback",
                columns: table => new
                {
                    Place_Feedback_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Place_ID = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Place_Feedback = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Place_Rating = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place_feedback", x => x.Place_Feedback_ID);
                    table.ForeignKey(
                        name: "FK_place_feedback_place_Place_ID",
                        column: x => x.Place_ID,
                        principalTable: "place",
                        principalColumn: "Place_ID");
                    table.ForeignKey(
                        name: "FK_place_feedback_users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user_guide_bookings",
                columns: table => new
                {
                    Booking_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    Date_To = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Date_From = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Time_From = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Time_To = table.Column<TimeSpan>(type: "time(6)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.ComputedColumn),
                    Bill_ID = table.Column<int>(type: "int", nullable: true),
                    Guide_ID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_guide_bookings", x => x.Booking_ID);
                    table.ForeignKey(
                        name: "FK_user_guide_bookings_bill_Bill_ID",
                        column: x => x.Bill_ID,
                        principalTable: "bill",
                        principalColumn: "Bill_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_guide_bookings_guide_Guide_ID",
                        column: x => x.Guide_ID,
                        principalTable: "guide",
                        principalColumn: "Guide_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_guide_bookings_users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "wishlist",
                columns: table => new
                {
                    Wishlist_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    User_ID = table.Column<int>(type: "int", nullable: true),
                    City_ID = table.Column<int>(type: "int", nullable: true),
                    Place_ID = table.Column<int>(type: "int", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wishlist", x => x.Wishlist_ID);
                    table.ForeignKey(
                        name: "FK_wishlist_city_City_ID",
                        column: x => x.City_ID,
                        principalTable: "city",
                        principalColumn: "City_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_wishlist_place_Place_ID",
                        column: x => x.Place_ID,
                        principalTable: "place",
                        principalColumn: "Place_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_wishlist_users_User_ID",
                        column: x => x.User_ID,
                        principalTable: "users",
                        principalColumn: "User_ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "place_images",
                columns: table => new
                {
                    Place_Image_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Place_ID = table.Column<int>(type: "int", nullable: false),
                    Image_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place_images", x => x.Place_Image_Id);
                    table.ForeignKey(
                        name: "FK_place_images_images_Image_ID",
                        column: x => x.Image_ID,
                        principalTable: "images",
                        principalColumn: "Image_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_place_images_place_Place_ID",
                        column: x => x.Place_ID,
                        principalTable: "place",
                        principalColumn: "Place_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "place_feedback_images",
                columns: table => new
                {
                    Feedback_Image_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Place_Feedback_ID = table.Column<int>(type: "int", nullable: false),
                    Image_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_place_feedback_images", x => x.Feedback_Image_Id);
                    table.ForeignKey(
                        name: "FK_place_feedback_images_images_Image_ID",
                        column: x => x.Image_ID,
                        principalTable: "images",
                        principalColumn: "Image_ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_place_feedback_images_place_feedback_Place_Feedback_ID",
                        column: x => x.Place_Feedback_ID,
                        principalTable: "place_feedback",
                        principalColumn: "Place_Feedback_ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_bill_Guide_ID",
                table: "bill",
                column: "Guide_ID");

            migrationBuilder.CreateIndex(
                name: "IX_booking_payment_details_Booking_ID",
                table: "booking_payment_details",
                column: "Booking_ID");

            migrationBuilder.CreateIndex(
                name: "IX_booking_place_guide_Booking_ID",
                table: "booking_place_guide",
                column: "Booking_ID");

            migrationBuilder.CreateIndex(
                name: "IX_booking_place_guide_Guide_ID",
                table: "booking_place_guide",
                column: "Guide_ID");

            migrationBuilder.CreateIndex(
                name: "IX_booking_place_guide_Place_ID",
                table: "booking_place_guide",
                column: "Place_ID");

            migrationBuilder.CreateIndex(
                name: "IX_city_State_ID",
                table: "city",
                column: "State_ID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_User_ID",
                table: "guide",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_feedback_Guide_ID",
                table: "guide_feedback",
                column: "Guide_ID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_feedback_User_ID",
                table: "guide_feedback",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_places_Guide_ID",
                table: "guide_places",
                column: "Guide_ID");

            migrationBuilder.CreateIndex(
                name: "IX_guide_places_Place_ID",
                table: "guide_places",
                column: "Place_ID");

            migrationBuilder.CreateIndex(
                name: "IX_help_User_ID",
                table: "help",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_images_User_ID",
                table: "images",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_place_City_ID",
                table: "place",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_place_feedback_Place_ID",
                table: "place_feedback",
                column: "Place_ID");

            migrationBuilder.CreateIndex(
                name: "IX_place_feedback_User_ID",
                table: "place_feedback",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_place_feedback_images_Image_ID",
                table: "place_feedback_images",
                column: "Image_ID");

            migrationBuilder.CreateIndex(
                name: "IX_place_feedback_images_Place_Feedback_ID",
                table: "place_feedback_images",
                column: "Place_Feedback_ID");

            migrationBuilder.CreateIndex(
                name: "IX_place_images_Image_ID",
                table: "place_images",
                column: "Image_ID");

            migrationBuilder.CreateIndex(
                name: "IX_place_images_Place_ID",
                table: "place_images",
                column: "Place_ID");

            migrationBuilder.CreateIndex(
                name: "IX_user_guide_bookings_Bill_ID",
                table: "user_guide_bookings",
                column: "Bill_ID");

            migrationBuilder.CreateIndex(
                name: "IX_user_guide_bookings_Guide_ID",
                table: "user_guide_bookings",
                column: "Guide_ID");

            migrationBuilder.CreateIndex(
                name: "IX_user_guide_bookings_User_ID",
                table: "user_guide_bookings",
                column: "User_ID");

            migrationBuilder.CreateIndex(
                name: "IX_users_Guide_ID",
                table: "users",
                column: "Guide_ID");

            migrationBuilder.CreateIndex(
                name: "IX_users_M_RolesRole_ID",
                table: "users",
                column: "M_RolesRole_ID");

            migrationBuilder.CreateIndex(
                name: "IX_wishlist_City_ID",
                table: "wishlist",
                column: "City_ID");

            migrationBuilder.CreateIndex(
                name: "IX_wishlist_Place_ID",
                table: "wishlist",
                column: "Place_ID");

            migrationBuilder.CreateIndex(
                name: "IX_wishlist_User_ID",
                table: "wishlist",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_bill_guide_Guide_ID",
                table: "bill",
                column: "Guide_ID",
                principalTable: "guide",
                principalColumn: "Guide_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_payment_details_user_guide_bookings_Booking_ID",
                table: "booking_payment_details",
                column: "Booking_ID",
                principalTable: "user_guide_bookings",
                principalColumn: "Booking_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_place_guide_guide_Guide_ID",
                table: "booking_place_guide",
                column: "Guide_ID",
                principalTable: "guide",
                principalColumn: "Guide_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_booking_place_guide_user_guide_bookings_Booking_ID",
                table: "booking_place_guide",
                column: "Booking_ID",
                principalTable: "user_guide_bookings",
                principalColumn: "Booking_ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_guide_users_User_ID",
                table: "guide",
                column: "User_ID",
                principalTable: "users",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_users_guide_Guide_ID",
                table: "users");

            migrationBuilder.DropTable(
                name: "booking_payment_details");

            migrationBuilder.DropTable(
                name: "booking_place_guide");

            migrationBuilder.DropTable(
                name: "guide_feedback");

            migrationBuilder.DropTable(
                name: "guide_places");

            migrationBuilder.DropTable(
                name: "help");

            migrationBuilder.DropTable(
                name: "place_feedback_images");

            migrationBuilder.DropTable(
                name: "place_images");

            migrationBuilder.DropTable(
                name: "wishlist");

            migrationBuilder.DropTable(
                name: "user_guide_bookings");

            migrationBuilder.DropTable(
                name: "place_feedback");

            migrationBuilder.DropTable(
                name: "images");

            migrationBuilder.DropTable(
                name: "bill");

            migrationBuilder.DropTable(
                name: "place");

            migrationBuilder.DropTable(
                name: "city");

            migrationBuilder.DropTable(
                name: "m_states");

            migrationBuilder.DropTable(
                name: "guide");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "m_roles");
        }
    }
}
