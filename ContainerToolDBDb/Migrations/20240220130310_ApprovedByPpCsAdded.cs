using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class ApprovedByPpCsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovedByTl",
                table: "Orders",
                newName: "ApprovedByPpCs");

            migrationBuilder.RenameColumn(
                name: "ApprovedByCs",
                table: "Orders",
                newName: "ApprovedByCrTl");

            migrationBuilder.AddColumn<bool>(
                name: "ApprovedByCrCs",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByCrCs",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ApprovedByPpCs",
                table: "Orders",
                newName: "ApprovedByTl");

            migrationBuilder.RenameColumn(
                name: "ApprovedByCrTl",
                table: "Orders",
                newName: "ApprovedByCs");
        }
    }
}
