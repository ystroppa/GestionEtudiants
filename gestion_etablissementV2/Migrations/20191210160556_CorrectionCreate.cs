using Microsoft.EntityFrameworkCore.Migrations;

namespace gestion_etablissement.Migrations
{
    public partial class CorrectionCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Enseignant_affectationid",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enseignant",
                table: "Enseignant");

            migrationBuilder.RenameTable(
                name: "Enseignant",
                newName: "Enseignants");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enseignants",
                table: "Enseignants",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Enseignants_affectationid",
                table: "Service",
                column: "affectationid",
                principalTable: "Enseignants",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Service_Enseignants_affectationid",
                table: "Service");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enseignants",
                table: "Enseignants");

            migrationBuilder.RenameTable(
                name: "Enseignants",
                newName: "Enseignant");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enseignant",
                table: "Enseignant",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Service_Enseignant_affectationid",
                table: "Service",
                column: "affectationid",
                principalTable: "Enseignant",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
