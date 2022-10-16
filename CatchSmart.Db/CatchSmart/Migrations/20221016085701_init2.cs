using Microsoft.EntityFrameworkCore.Migrations;

namespace CatchSmart.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Candidates_CandidateId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_CandidateId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CandidateId",
                table: "Companies");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CandidateId",
                table: "Companies",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_CandidateId",
                table: "Companies",
                column: "CandidateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Candidates_CandidateId",
                table: "Companies",
                column: "CandidateId",
                principalTable: "Candidates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
