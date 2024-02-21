using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class bruttoWeightInKgRenamedToGrossWeightInKg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BruttoWeightInKG",
                table: "CSInquiries",
                newName: "GrossWeightInKG");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Articles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Factory",
                table: "Articles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Nozzle",
                table: "Articles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Planned",
                table: "Articles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductionOrder",
                table: "Articles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ShortText",
                table: "Articles",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Factory",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Nozzle",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Planned",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ProductionOrder",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ShortText",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "GrossWeightInKG",
                table: "CSInquiries",
                newName: "BruttoWeightInKG");
        }
    }
}
