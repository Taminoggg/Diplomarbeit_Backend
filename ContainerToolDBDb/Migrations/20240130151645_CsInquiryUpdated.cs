using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class CsInquiryUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Orders_OrderId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "ArticleNumber",
                table: "CSInquiries");

            migrationBuilder.DropColumn(
                name: "Customer",
                table: "CSInquiries");

            migrationBuilder.DropColumn(
                name: "DirectLine",
                table: "CSInquiries");

            migrationBuilder.DropColumn(
                name: "FastLine",
                table: "CSInquiries");

            migrationBuilder.DropColumn(
                name: "Palletamount",
                table: "CSInquiries");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Articles",
                newName: "CsinquiryId");

            migrationBuilder.AlterColumn<bool>(
                name: "IsFastLine",
                table: "Articles",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDirectLine",
                table: "Articles",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "ArticleNumber",
                table: "Articles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_CSInquiries_CsinquiryId",
                table: "Articles",
                column: "CsinquiryId",
                principalTable: "CSInquiries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_CSInquiries_CsinquiryId",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "CsinquiryId",
                table: "Articles",
                newName: "OrderId");

            migrationBuilder.AddColumn<string>(
                name: "ArticleNumber",
                table: "CSInquiries",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Customer",
                table: "CSInquiries",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DirectLine",
                table: "CSInquiries",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FastLine",
                table: "CSInquiries",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Palletamount",
                table: "CSInquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "IsFastLine",
                table: "Articles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "IsDirectLine",
                table: "Articles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleNumber",
                table: "Articles",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Orders_OrderId",
                table: "Articles",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
