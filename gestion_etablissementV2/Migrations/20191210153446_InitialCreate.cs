using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace gestion_etablissement.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enseignant",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(nullable: true),
                    prenom = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    sexe = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    num_emp = table.Column<string>(nullable: true),
                    cout_horaires = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Filieres",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filieres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    intitule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Etudiants",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(nullable: true),
                    prenom = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    sexe = table.Column<string>(nullable: true),
                    date = table.Column<DateTime>(nullable: false),
                    Filiereid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiants", x => x.id);
                    table.ForeignKey(
                        name: "FK_Etudiants_Filieres_Filiereid",
                        column: x => x.Filiereid,
                        principalTable: "Filieres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    filid = table.Column<int>(nullable: true),
                    matid = table.Column<int>(nullable: true),
                    coef = table.Column<int>(nullable: false),
                    nb_h = table.Column<int>(nullable: false),
                    descriptif = table.Column<string>(nullable: true),
                    affectationid = table.Column<int>(nullable: true),
                    Codeid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.id);
                    table.ForeignKey(
                        name: "FK_Service_Enseignant_affectationid",
                        column: x => x.affectationid,
                        principalTable: "Enseignant",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Filieres_filid",
                        column: x => x.filid,
                        principalTable: "Filieres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Service_Matiere_matid",
                        column: x => x.matid,
                        principalTable: "Matiere",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Etudiants_Filiereid",
                table: "Etudiants",
                column: "Filiereid");

            migrationBuilder.CreateIndex(
                name: "IX_Service_affectationid",
                table: "Service",
                column: "affectationid");

            migrationBuilder.CreateIndex(
                name: "IX_Service_filid",
                table: "Service",
                column: "filid");

            migrationBuilder.CreateIndex(
                name: "IX_Service_matid",
                table: "Service",
                column: "matid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Etudiants");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Enseignant");

            migrationBuilder.DropTable(
                name: "Filieres");

            migrationBuilder.DropTable(
                name: "Matiere");
        }
    }
}
