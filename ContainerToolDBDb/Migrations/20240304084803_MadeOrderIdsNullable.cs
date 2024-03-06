using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class MadeOrderIdsNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CSInquiries_CSId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductionPlannings_TLId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TLInquiries_TLId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "TLId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PpId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CSId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CSInquiries_CSId",
                table: "Orders",
                column: "CSId",
                principalTable: "CSInquiries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductionPlannings_PpId",
                table: "Orders",
                column: "PpId",
                principalTable: "ProductionPlannings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TLInquiries_TLId",
                table: "Orders",
                column: "TLId",
                principalTable: "TLInquiries",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_CSInquiries_CSId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductionPlannings_PpId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TLInquiries_TLId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "TLId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PpId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CSId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_CSInquiries_CSId",
                table: "Orders",
                column: "CSId",
                principalTable: "CSInquiries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductionPlannings_TLId",
                table: "Orders",
                column: "TLId",
                principalTable: "ProductionPlannings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TLInquiries_TLId",
                table: "Orders",
                column: "TLId",
                principalTable: "TLInquiries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
