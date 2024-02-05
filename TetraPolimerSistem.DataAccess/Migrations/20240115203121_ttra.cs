using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TetraPolimerSistem.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ttra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "UrunBedelTL",
                table: "disTicaretMaliyetler",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrunBedelTL",
                table: "disTicaretMaliyetler");
        }
    }
}
