using Microsoft.EntityFrameworkCore.Migrations;

namespace SJ.Api.Core.Migrations
{
    public partial class AddResultField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Results_Status_StatusId",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Results",
                table: "Results");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance");

            migrationBuilder.RenameTable(
                name: "Results",
                newName: "Result");

            migrationBuilder.RenameTable(
                name: "Insurance",
                newName: "Insurance");

            migrationBuilder.RenameIndex(
                name: "IX_Results_StatusId",
                table: "Result",
                newName: "IX_Result_StatusId");

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Insurance",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Result",
                table: "Result",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_ResultId",
                table: "Insurance",
                column: "ResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_Insurance_Result_ResultId",
                table: "Insurance",
                column: "ResultId",
                principalTable: "Result",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Status_StatusId",
                table: "Result",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Result_ResultId",
                table: "Insurance");

            migrationBuilder.DropForeignKey(
                name: "FK_Result_Status_StatusId",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Result",
                table: "Result");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance");

            migrationBuilder.DropIndex(
                name: "IX_Insurance_ResultId",
                table: "Insurance");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Insurance");

            migrationBuilder.RenameTable(
                name: "Result",
                newName: "Results");

            migrationBuilder.RenameTable(
                name: "Insurance",
                newName: "Insurance");

            migrationBuilder.RenameIndex(
                name: "IX_Result_StatusId",
                table: "Results",
                newName: "IX_Results_StatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Results",
                table: "Results",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Insurance",
                table: "Insurance",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Results_Status_StatusId",
                table: "Results",
                column: "StatusId",
                principalTable: "Status",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
