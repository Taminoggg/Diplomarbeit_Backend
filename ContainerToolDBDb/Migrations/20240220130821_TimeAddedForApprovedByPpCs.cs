using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class TimeAddedForApprovedByPpCs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ApprovedByTlTime",
                table: "Orders",
                newName: "ApprovedByPpCsTime");

            migrationBuilder.RenameColumn(
                name: "ApprovedByCsTime",
                table: "Orders",
                newName: "ApprovedByCrTlTime");

            migrationBuilder.AddColumn<DateTime>(
                name: "ApprovedByCrCsTime",
                table: "Orders",
                type: "datetime(6)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApprovedByCrCsTime",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "ApprovedByPpCsTime",
                table: "Orders",
                newName: "ApprovedByTlTime");

            migrationBuilder.RenameColumn(
                name: "ApprovedByCrTlTime",
                table: "Orders",
                newName: "ApprovedByCsTime");
        }
    }
}
