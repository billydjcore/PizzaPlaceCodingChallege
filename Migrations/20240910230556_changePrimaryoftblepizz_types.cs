using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaPlace.Api.Migrations
{
    /// <inheritdoc />
    public partial class changePrimaryoftblepizz_types : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pizza_types",
                table: "pizza_types");

            migrationBuilder.AlterColumn<string>(
                name: "pizza_type_id",
                table: "pizza_types",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pizza_types",
                table: "pizza_types",
                column: "pizza_type_id");

            migrationBuilder.DropColumn(
                name: "id",
                table: "order_details");

            migrationBuilder.DropPrimaryKey(
               name: "PK_order_details",
               table: "order_details");

            migrationBuilder.AddPrimaryKey(
              name: "PK_order_details",
              table: "order_details",
              column: "order_details_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_pizza_types",
                table: "pizza_types");

            migrationBuilder.AlterColumn<string>(
                name: "pizza_type_id",
                table: "pizza_types",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pizza_types",
                table: "pizza_types",
                column: "id");
        }
    }
}
