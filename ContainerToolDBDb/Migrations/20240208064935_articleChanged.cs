using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class ArticleChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdditionalInformation",
                table: "Articles",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DesiredDeliveryDate",
                table: "Articles",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InquiryForFixedOrder",
                table: "Articles",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "InquiryForQuotation",
                table: "Articles",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinHeigthRequired",
                table: "Articles",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdditionalInformation",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "DesiredDeliveryDate",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "InquiryForFixedOrder",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "InquiryForQuotation",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "MinHeigthRequired",
                table: "Articles");
        }
    }
}
