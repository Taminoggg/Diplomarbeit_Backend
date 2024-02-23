using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class ApprovedByPPAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ApprovedByPpPp",
                table: "Orders",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedByPpPpTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByPpPp",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ApprovedByPpPpTime",
                table: "Orders");
        }
    }
}
