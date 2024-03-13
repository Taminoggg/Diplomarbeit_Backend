using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContainerToolDB.Migrations
{
    /// <inheritdoc />
    public partial class TlinquiryDeptCapitalFieldsChangedAndColumsRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_TLInquiries_TLId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TLInquiries",
                table: "TLInquiries");

            migrationBuilder.DropColumn(
                name: "DebtCapitalGeneralForerunEUR",
                table: "TLInquiries");

            migrationBuilder.DropColumn(
                name: "DebtCapitalMainDOL",
                table: "TLInquiries");

            migrationBuilder.DropColumn(
                name: "IsContainer40",
                table: "TLInquiries");

            migrationBuilder.DropColumn(
                name: "IsContainerHC",
                table: "TLInquiries");

            migrationBuilder.RenameTable(
                name: "TLInquiries",
                newName: "Tlinquiries");

            migrationBuilder.RenameColumn(
                name: "ApprovedByCrTlTime",
                table: "Tlinquiries",
                newName: "ApprovedByCrTLTime");

            migrationBuilder.RenameColumn(
                name: "ApprovedByCrTl",
                table: "Tlinquiries",
                newName: "ApprovedByCrTL");

            migrationBuilder.RenameColumn(
                name: "WeightInKG",
                table: "Tlinquiries",
                newName: "SCTrail");

            migrationBuilder.RenameColumn(
                name: "InquiryNumber",
                table: "Tlinquiries",
                newName: "SCMainRun");

            migrationBuilder.RenameColumn(
                name: "DebtCapitalTrailingDOL",
                table: "Tlinquiries",
                newName: "SCGeneral");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Orders",
                newName: "CreatedBySD");

            migrationBuilder.AlterColumn<int>(
                name: "TLId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByCS",
                table: "Orders",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tlinquiries",
                table: "Tlinquiries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tlinquiries_TLId",
                table: "Orders",
                column: "TLId",
                principalTable: "Tlinquiries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tlinquiries_TLId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tlinquiries",
                table: "Tlinquiries");

            migrationBuilder.DropColumn(
                name: "CreatedByCS",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Tlinquiries",
                newName: "TLInquiries");

            migrationBuilder.RenameColumn(
                name: "ApprovedByCrTLTime",
                table: "TLInquiries",
                newName: "ApprovedByCrTlTime");

            migrationBuilder.RenameColumn(
                name: "ApprovedByCrTL",
                table: "TLInquiries",
                newName: "ApprovedByCrTl");

            migrationBuilder.RenameColumn(
                name: "SCTrail",
                table: "TLInquiries",
                newName: "WeightInKG");

            migrationBuilder.RenameColumn(
                name: "SCMainRun",
                table: "TLInquiries",
                newName: "InquiryNumber");

            migrationBuilder.RenameColumn(
                name: "SCGeneral",
                table: "TLInquiries",
                newName: "DebtCapitalTrailingDOL");

            migrationBuilder.RenameColumn(
                name: "CreatedBySD",
                table: "Orders",
                newName: "CreatedBy");

            migrationBuilder.AddColumn<int>(
                name: "DebtCapitalGeneralForerunEUR",
                table: "TLInquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DebtCapitalMainDOL",
                table: "TLInquiries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsContainer40",
                table: "TLInquiries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsContainerHC",
                table: "TLInquiries",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "TLId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TLInquiries",
                table: "TLInquiries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_TLInquiries_TLId",
                table: "Orders",
                column: "TLId",
                principalTable: "TLInquiries",
                principalColumn: "Id");
        }
    }
}
