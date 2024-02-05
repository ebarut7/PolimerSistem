using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TetraPolimerSistem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class tetraplm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_sevkiyatDetaylar_SevkiyatDetayId1",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_SevkiyatDetayId1",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "SevkiyatDetayId1",
                table: "orders");

            migrationBuilder.AlterColumn<int>(
                name: "SevkiyatDetayId",
                table: "orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_orders_SevkiyatDetayId",
                table: "orders",
                column: "SevkiyatDetayId");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_sevkiyatDetaylar_SevkiyatDetayId",
                table: "orders",
                column: "SevkiyatDetayId",
                principalTable: "sevkiyatDetaylar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_sevkiyatDetaylar_SevkiyatDetayId",
                table: "orders");

            migrationBuilder.DropIndex(
                name: "IX_orders_SevkiyatDetayId",
                table: "orders");

            migrationBuilder.AlterColumn<string>(
                name: "SevkiyatDetayId",
                table: "orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SevkiyatDetayId1",
                table: "orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orders_SevkiyatDetayId1",
                table: "orders",
                column: "SevkiyatDetayId1");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_sevkiyatDetaylar_SevkiyatDetayId1",
                table: "orders",
                column: "SevkiyatDetayId1",
                principalTable: "sevkiyatDetaylar",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
