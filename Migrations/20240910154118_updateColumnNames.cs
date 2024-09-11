using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlace.Api.Migrations
{
    /// <inheritdoc />
    public partial class updateColumnNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pizza_type",
                table: "pizzas",
                newName: "pizza_type_id");

            migrationBuilder.RenameColumn(
                name: "pizza_type",
                table: "pizza_types",
                newName: "pizza_type_id");

            migrationBuilder.RenameColumn(
                name: "order_details",
                table: "order_details",
                newName: "order_details_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pizza_type_id",
                table: "pizzas",
                newName: "pizza_type");

            migrationBuilder.RenameColumn(
                name: "pizza_type_id",
                table: "pizza_types",
                newName: "pizza_type");

            migrationBuilder.RenameColumn(
                name: "order_details_id",
                table: "order_details",
                newName: "order_details");
        }
    }
}
