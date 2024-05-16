using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project_api.Migrations
{
    /// <inheritdoc />
    public partial class lastest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clients",
                columns: table => new
                {
                    IdClient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clients", x => x.IdClient);
                });

            migrationBuilder.CreateTable(
                name: "productTypes",
                columns: table => new
                {
                    IdProductType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productTypes", x => x.IdProductType);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    IdStore = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StoreAddress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.IdStore);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "invoices",
                columns: table => new
                {
                    IdInvoice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(type: "int", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoices", x => x.IdInvoice);
                    table.ForeignKey(
                        name: "FK_invoices_clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "clients",
                        principalColumn: "IdClient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    IdProduct = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTypeID = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.IdProduct);
                    table.ForeignKey(
                        name: "FK_products_productTypes_ProductTypeID",
                        column: x => x.ProductTypeID,
                        principalTable: "productTypes",
                        principalColumn: "IdProductType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "games",
                columns: table => new
                {
                    IdGame = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Points = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_games", x => x.IdGame);
                    table.ForeignKey(
                        name: "FK_games_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "IdUser");
                });

            migrationBuilder.CreateTable(
                name: "productions",
                columns: table => new
                {
                    IdProduction = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productions", x => x.IdProduction);
                    table.ForeignKey(
                        name: "FK_productions_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "detailInvoices",
                columns: table => new
                {
                    IdDetailInvoice = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false),
                    IdInvoice = table.Column<int>(type: "int", nullable: false),
                    IdProduct = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detailInvoices", x => x.IdDetailInvoice);
                    table.ForeignKey(
                        name: "FK_detailInvoices_games_GameId",
                        column: x => x.GameId,
                        principalTable: "games",
                        principalColumn: "IdGame",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailInvoices_invoices_IdInvoice",
                        column: x => x.IdInvoice,
                        principalTable: "invoices",
                        principalColumn: "IdInvoice",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailInvoices_products_IdProduct",
                        column: x => x.IdProduct,
                        principalTable: "products",
                        principalColumn: "IdProduct",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detailInvoices_stores_GameId",
                        column: x => x.GameId,
                        principalTable: "stores",
                        principalColumn: "IdStore",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detailInvoices_GameId",
                table: "detailInvoices",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_detailInvoices_IdInvoice",
                table: "detailInvoices",
                column: "IdInvoice");

            migrationBuilder.CreateIndex(
                name: "IX_detailInvoices_IdProduct",
                table: "detailInvoices",
                column: "IdProduct");

            migrationBuilder.CreateIndex(
                name: "IX_games_UserId",
                table: "games",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_invoices_ClientID",
                table: "invoices",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_productions_ProductID",
                table: "productions",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_products_ProductTypeID",
                table: "products",
                column: "ProductTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detailInvoices");

            migrationBuilder.DropTable(
                name: "productions");

            migrationBuilder.DropTable(
                name: "games");

            migrationBuilder.DropTable(
                name: "invoices");

            migrationBuilder.DropTable(
                name: "stores");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "clients");

            migrationBuilder.DropTable(
                name: "productTypes");
        }
    }
}
