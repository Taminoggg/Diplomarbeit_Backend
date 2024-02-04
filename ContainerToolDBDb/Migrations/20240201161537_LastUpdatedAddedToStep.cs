using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class LastUpdatedAddedToStep : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LastUpdated",
                table: "Steps",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Steps");
        }
    }
}
