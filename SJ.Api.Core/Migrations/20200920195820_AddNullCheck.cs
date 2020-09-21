using Microsoft.EntityFrameworkCore.Migrations;

namespace SJ.Api.Core.Migrations
{
    public partial class AddNullCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Result_ResultId",
                table: "Insurance");

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "Insurance",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Result_ResultId",
                table: "Insurance",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Result_ResultId",
                table: "Insurance");

            migrationBuilder.AlterColumn<int>(
                name: "ResultId",
                table: "Insurance",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Result_ResultId",
                table: "Insurance",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
