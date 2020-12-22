using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RentCarApp.DataAccess.Migrations
{
    public partial class Init_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Product");

            migrationBuilder.EnsureSchema(
                name: "Sales");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Thumbnail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brand",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Model",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Model", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Model_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Product",
                        principalTable: "Brand",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Car",
                schema: "Product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Doors = table.Column<int>(type: "int", nullable: false),
                    Transmission = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsEnable = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_Brand_BrandId",
                        column: x => x.BrandId,
                        principalSchema: "Product",
                        principalTable: "Brand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Product",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Car_Model_ModelId",
                        column: x => x.ModelId,
                        principalSchema: "Product",
                        principalTable: "Model",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                schema: "Sales",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Days = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Car_CarId",
                        column: x => x.CarId,
                        principalSchema: "Product",
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetail_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "Sales",
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "Product",
                table: "Brand",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsEnable", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("3be6ee74-a305-4cd2-ba90-2f5fd810c6cf"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 116, DateTimeKind.Local).AddTicks(3233), true, null, null, "Toyota" },
                    { new Guid("840417ab-de90-42a7-9f9e-6e6cb525cb5a"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 117, DateTimeKind.Local).AddTicks(6071), true, null, null, "Hyundai" },
                    { new Guid("8a854977-1d0b-4942-a652-bcc98e53aa59"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 117, DateTimeKind.Local).AddTicks(6126), true, null, null, "Kia" }
                });

            migrationBuilder.InsertData(
                schema: "Product",
                table: "Category",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsEnable", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("de5f34e4-4e69-415a-ab93-bd2db6d5d22c"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 122, DateTimeKind.Local).AddTicks(8125), true, null, null, "Sedan" },
                    { new Guid("76bc9159-00a0-4deb-8a5c-24ca78729ecf"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 122, DateTimeKind.Local).AddTicks(9395), true, null, null, "Truck" },
                    { new Guid("e1a5b3b7-8f78-48c5-baf0-4300271b3b64"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 122, DateTimeKind.Local).AddTicks(9421), true, null, null, "hatchback" }
                });

            migrationBuilder.InsertData(
                schema: "Product",
                table: "Model",
                columns: new[] { "Id", "BrandId", "CreatedBy", "CreatedDate", "Description", "IsEnable", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { new Guid("c12c00f0-c0f1-4de0-895f-6b1da44c4f51"), new Guid("3be6ee74-a305-4cd2-ba90-2f5fd810c6cf"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 126, DateTimeKind.Local).AddTicks(6803), "Toyota Corolla", true, null, null, "Corolla" },
                    { new Guid("7494dc9a-7c6a-457a-9338-e3d0975b7fee"), new Guid("3be6ee74-a305-4cd2-ba90-2f5fd810c6cf"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 126, DateTimeKind.Local).AddTicks(6810), "Toyota Camry", true, null, null, "Camry" },
                    { new Guid("ec78beee-a750-438f-8a51-c8b54155af13"), new Guid("840417ab-de90-42a7-9f9e-6e6cb525cb5a"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 126, DateTimeKind.Local).AddTicks(5057), "Hyundai Accent", true, null, null, "Accent" },
                    { new Guid("1889fd1c-27a3-447b-9044-655fad3531f1"), new Guid("840417ab-de90-42a7-9f9e-6e6cb525cb5a"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 126, DateTimeKind.Local).AddTicks(6740), "Hyundai Elantra", true, null, null, "Elantra" },
                    { new Guid("93da1e60-824f-4e7b-9bf2-46cb3c5d84b8"), new Guid("8a854977-1d0b-4942-a652-bcc98e53aa59"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 126, DateTimeKind.Local).AddTicks(6832), "Kia Picanto", true, null, null, "Picanto" },
                    { new Guid("7a0c1ef6-e47e-45c1-a485-78fdd3f9b95f"), new Guid("8a854977-1d0b-4942-a652-bcc98e53aa59"), "System", new DateTime(2020, 12, 21, 23, 18, 17, 126, DateTimeKind.Local).AddTicks(6837), "Kia Rio", true, null, null, "Rio" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Car_BrandId",
                schema: "Product",
                table: "Car",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_CategoryId",
                schema: "Product",
                table: "Car",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                schema: "Product",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Model_BrandId",
                schema: "Product",
                table: "Model",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_CarId",
                schema: "Sales",
                table: "OrderDetail",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetail_OrderId",
                schema: "Sales",
                table: "OrderDetail",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "OrderDetail",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Car",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "Sales");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Model",
                schema: "Product");

            migrationBuilder.DropTable(
                name: "Brand",
                schema: "Product");
        }
    }
}
