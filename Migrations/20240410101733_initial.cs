using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "production");

            migrationBuilder.EnsureSchema(
                name: "sales");

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "production",
                columns: table => new
                {
                    brand_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    brand_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__brands__5E5A8E27FB4DBE87", x => x.brand_id);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                schema: "production",
                columns: table => new
                {
                    category_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__categori__D54EE9B40EED734E", x => x.category_id);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "sales",
                columns: table => new
                {
                    customer_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    street = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    state = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    zip_code = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__customer__CD65CB8510E47192", x => x.customer_id);
                });

            migrationBuilder.CreateTable(
                name: "index_logs",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    event_data = table.Column<string>(type: "xml", nullable: false),
                    changed_by = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__index_lo__9E2397E0651D5E70", x => x.log_id);
                });

            migrationBuilder.CreateTable(
                name: "product_audits",
                schema: "production",
                columns: table => new
                {
                    change_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    product_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    brand_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    model_year = table.Column<short>(type: "smallint", nullable: false),
                    list_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    updated_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    operation = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__product___F4EFE596F71E3CEB", x => x.change_id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                schema: "sales",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    store_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    street = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    city = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    state = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    zip_code = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stores__A2F2A30CB73D9223", x => x.store_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "production",
                columns: table => new
                {
                    product_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    brand_id = table.Column<int>(type: "int", nullable: false),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    model_year = table.Column<short>(type: "smallint", nullable: false),
                    list_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__products__47027DF5ADF00715", x => x.product_id);
                    table.ForeignKey(
                        name: "FK__products__brand___3C69FB99",
                        column: x => x.brand_id,
                        principalSchema: "production",
                        principalTable: "brands",
                        principalColumn: "brand_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__products__catego__3B75D760",
                        column: x => x.category_id,
                        principalSchema: "production",
                        principalTable: "categories",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "staffs",
                schema: "sales",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    phone = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    active = table.Column<byte>(type: "tinyint", nullable: false),
                    store_id = table.Column<int>(type: "int", nullable: false),
                    manager_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__staffs__1963DD9CB212402C", x => x.staff_id);
                    table.ForeignKey(
                        name: "FK__staffs__manager___44FF419A",
                        column: x => x.manager_id,
                        principalSchema: "sales",
                        principalTable: "staffs",
                        principalColumn: "staff_id");
                    table.ForeignKey(
                        name: "FK__staffs__store_id__440B1D61",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "stocks",
                schema: "production",
                columns: table => new
                {
                    store_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__stocks__E68284D3842DBB40", x => new { x.store_id, x.product_id });
                    table.ForeignKey(
                        name: "FK__stocks__product___52593CB8",
                        column: x => x.product_id,
                        principalSchema: "production",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__stocks__store_id__5165187F",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    customer_id = table.Column<int>(type: "int", nullable: true),
                    order_status = table.Column<byte>(type: "tinyint", nullable: false),
                    order_date = table.Column<DateTime>(type: "date", nullable: false),
                    required_date = table.Column<DateTime>(type: "date", nullable: false),
                    shipped_date = table.Column<DateTime>(type: "date", nullable: true),
                    store_id = table.Column<int>(type: "int", nullable: false),
                    staff_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__orders__46596229BAFDC65A", x => x.order_id);
                    table.ForeignKey(
                        name: "FK__orders__customer__47DBAE45",
                        column: x => x.customer_id,
                        principalSchema: "sales",
                        principalTable: "customers",
                        principalColumn: "customer_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__orders__staff_id__49C3F6B7",
                        column: x => x.staff_id,
                        principalSchema: "sales",
                        principalTable: "staffs",
                        principalColumn: "staff_id");
                    table.ForeignKey(
                        name: "FK__orders__store_id__48CFD27E",
                        column: x => x.store_id,
                        principalSchema: "sales",
                        principalTable: "stores",
                        principalColumn: "store_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_items",
                schema: "sales",
                columns: table => new
                {
                    order_id = table.Column<int>(type: "int", nullable: false),
                    item_id = table.Column<int>(type: "int", nullable: false),
                    product_id = table.Column<int>(type: "int", nullable: false),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    list_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(4,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__order_it__837942D4A0A1BE94", x => new { x.order_id, x.item_id });
                    table.ForeignKey(
                        name: "FK__order_ite__order__4D94879B",
                        column: x => x.order_id,
                        principalSchema: "sales",
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__order_ite__produ__4E88ABD4",
                        column: x => x.product_id,
                        principalSchema: "production",
                        principalTable: "products",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "nidx_fname",
                schema: "sales",
                table: "customers",
                column: "first_name");

            migrationBuilder.CreateIndex(
                name: "nidx_lname",
                schema: "sales",
                table: "customers",
                column: "last_name");

            migrationBuilder.CreateIndex(
                name: "IX_order_items_product_id",
                schema: "sales",
                table: "order_items",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_customer_id",
                schema: "sales",
                table: "orders",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_staff_id",
                schema: "sales",
                table: "orders",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_store_id",
                schema: "sales",
                table: "orders",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_brand_id",
                schema: "production",
                table: "products",
                column: "brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_category_id",
                schema: "production",
                table: "products",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_manager_id",
                schema: "sales",
                table: "staffs",
                column: "manager_id");

            migrationBuilder.CreateIndex(
                name: "IX_staffs_store_id",
                schema: "sales",
                table: "staffs",
                column: "store_id");

            migrationBuilder.CreateIndex(
                name: "UQ__staffs__AB6E616479BC26C2",
                schema: "sales",
                table: "staffs",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_stocks_product_id",
                schema: "production",
                table: "stocks",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "index_logs");

            migrationBuilder.DropTable(
                name: "order_items",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "product_audits",
                schema: "production");

            migrationBuilder.DropTable(
                name: "stocks",
                schema: "production");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "products",
                schema: "production");

            migrationBuilder.DropTable(
                name: "customers",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "staffs",
                schema: "sales");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "production");

            migrationBuilder.DropTable(
                name: "categories",
                schema: "production");

            migrationBuilder.DropTable(
                name: "stores",
                schema: "sales");
        }
    }
}
