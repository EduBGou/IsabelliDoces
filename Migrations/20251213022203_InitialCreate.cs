using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IsabelliDoces.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Street = table.Column<string>(type: "TEXT", nullable: false),
                    Number = table.Column<string>(type: "TEXT", nullable: false),
                    Complement = table.Column<string>(type: "TEXT", nullable: false),
                    Cep = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CakeFlavors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CakeFlavors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    HomeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Addresses_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    HomeId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Addresses_HomeId",
                        column: x => x.HomeId,
                        principalTable: "Addresses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    PermissionType = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionType });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPlaces",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    AddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPlaces", x => new { x.ClientId, x.AddressId });
                    table.ForeignKey(
                        name: "FK_DeliveryPlaces_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DeliveryPlaces_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccomplishDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DeliveryAddressId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Addresses_DeliveryAddressId",
                        column: x => x.DeliveryAddressId,
                        principalTable: "Addresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleContracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EmployeeId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleContracts_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleContracts_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    CakeFlavorId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLines_CakeFlavors_CakeFlavorId",
                        column: x => x.CakeFlavorId,
                        principalTable: "CakeFlavors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrderLines_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "Cep", "Complement", "Number", "Street" },
                values: new object[,]
                {
                    { 1, "12345-678", "Kitnet", "4226", "Rua Mato Fino" },
                    { 2, "78221-351", "", "9995", "Rua Floresta Grossa" },
                    { 3, "54321-876", "Casa Azul", "9855", "Rua Luis Hasper" },
                    { 4, "54321-876", "Casa Amarela", "871", "Rua Luis Hasper" }
                });

            migrationBuilder.InsertData(
                table: "CakeFlavors",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Chocolate", 40.00m },
                    { 2, "Morango", 50.00m },
                    { 3, "Pistache", 60.00m }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SuperAdmin" },
                    { 2, "Admin" },
                    { 3, "Atendente" },
                    { 4, "Entregador" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "HomeId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, 1, "Gustavo", "(44) 91234-5678" },
                    { 2, 2, "Lana", "(44) 95555-4444" },
                    { 3, 1, "Vincius", "(44) 96666-1050" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Cpf", "Email", "HomeId", "Name", "Password", "Phone" },
                values: new object[,]
                {
                    { 1, "025.156.745-89", "edu@gmail.com", 2, "Eduardo", "123", "(44) 91234-5678" },
                    { 2, "010.174.775-54", "isa@gmail.com", 3, "Isabelli", "321", "(44) 95445-1643" },
                    { 3, "410.214.875-12", "scopel@gmail.com", 4, "Scopel", "852", "(44) 97847-6941" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionType", "RoleId" },
                values: new object[,]
                {
                    { 0, 1 },
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 5, 1 },
                    { 6, 1 },
                    { 7, 1 },
                    { 0, 2 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 5, 3 },
                    { 7, 3 },
                    { 2, 4 },
                    { 6, 4 },
                    { 7, 4 }
                });

            migrationBuilder.InsertData(
                table: "DeliveryPlaces",
                columns: new[] { "AddressId", "ClientId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 3, 2 },
                    { 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "RoleContracts",
                columns: new[] { "Id", "EmployeeId", "EndDate", "RoleId", "StartDate" },
                values: new object[,]
                {
                    { 1, 1, null, 1, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, null, 2, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, null, 3, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 3, null, 4, new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_HomeId",
                table: "Clients",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPlaces_AddressId",
                table: "DeliveryPlaces",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HomeId",
                table: "Employees",
                column: "HomeId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_CakeFlavorId",
                table: "OrderLines",
                column: "CakeFlavorId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLines_OrderId",
                table: "OrderLines",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryAddressId",
                table: "Orders",
                column: "DeliveryAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleContracts_EmployeeId",
                table: "RoleContracts",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleContracts_RoleId",
                table: "RoleContracts",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DeliveryPlaces");

            migrationBuilder.DropTable(
                name: "OrderLines");

            migrationBuilder.DropTable(
                name: "RoleContracts");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "CakeFlavors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Addresses");
        }
    }
}
