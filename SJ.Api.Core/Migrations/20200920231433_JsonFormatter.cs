using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SJ.Api.Core.Migrations
{
    public partial class JsonFormatter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Insurance_Result_ResultId",
                table: "Insurance");

            migrationBuilder.DropIndex(
                name: "IX_Insurance_ResultId",
                table: "Insurance");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "ResultId",
                table: "Insurance");

            migrationBuilder.AddColumn<int>(
                name: "InsuranceId",
                table: "Result",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Result",
                table: "Insurance",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Result_InsuranceId",
                table: "Result",
                column: "InsuranceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Result_Insurance_InsuranceId",
                table: "Result",
                column: "InsuranceId",
                principalTable: "Insurance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Result_Insurance_InsuranceId",
                table: "Result");

            migrationBuilder.DropIndex(
                name: "IX_Result_InsuranceId",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "InsuranceId",
                table: "Result");

            migrationBuilder.DropColumn(
                name: "Result",
                table: "Insurance");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Result",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ResultId",
                table: "Insurance",
                type: "int",
                nullable: true);

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
                onDelete: ReferentialAction.Restrict);
        }
    }
}
