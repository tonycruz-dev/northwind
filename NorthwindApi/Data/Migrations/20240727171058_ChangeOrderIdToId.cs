using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NorthwindApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeOrderIdToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExtendedPrice",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.AddColumn<decimal>(
                name: "ExtendedPrice",
                table: "OrderDetails",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
