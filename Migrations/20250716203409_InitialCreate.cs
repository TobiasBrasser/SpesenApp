using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpesenApp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpesenEintraege",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Datum = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Beschreibung = table.Column<string>(type: "TEXT", nullable: true),
                    Kst1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Kst2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Verpflegung = table.Column<decimal>(type: "TEXT", nullable: false),
                    Reisekosten = table.Column<decimal>(type: "TEXT", nullable: false),
                    KmAuto = table.Column<decimal>(type: "TEXT", nullable: false),
                    ReisespesenAuto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Kursmaterial = table.Column<decimal>(type: "TEXT", nullable: false),
                    AndereKosten = table.Column<decimal>(type: "TEXT", nullable: false),
                    PersonenId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpesenEintraege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpesenEintraege_Personen_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Personen",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SpesenEintraege_PersonId",
                table: "SpesenEintraege",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SpesenEintraege");

            migrationBuilder.DropTable(
                name: "Personen");
        }
    }
}
