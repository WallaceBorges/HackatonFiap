using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthAndMed.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EspecialidadeMedica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EspecialidadeMedica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<long>(type: "bigint", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TipoUsuario = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CRM = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Especialidade_Id = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    Medico_Id = table.Column<int>(type: "int", nullable: false),
                    DataAtendimento = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Paciente_Id = table.Column<int>(type: "int", nullable: true),
                    DataAgendou = table.Column<DateTime>(type: "datetime2", nullable: true),
                    isAtendico = table.Column<bool>(type: "bit", nullable: true),
                    Prontuario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => new { x.Medico_Id, x.DataAtendimento });
                    table.ForeignKey(
                        name: "FK_Agenda_Usuario_Medico_Id",
                        column: x => x.Medico_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Agenda_Usuario_Paciente_Id",
                        column: x => x.Paciente_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MedicoEspecialidade",
                columns: table => new
                {
                    Medico_Id = table.Column<int>(type: "int", nullable: false),
                    EspecialidadeMedica_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicoEspecialidade", x => new { x.Medico_Id, x.EspecialidadeMedica_Id });
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_EspecialidadeMedica_EspecialidadeMedica_Id",
                        column: x => x.EspecialidadeMedica_Id,
                        principalTable: "EspecialidadeMedica",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicoEspecialidade_Usuario_Medico_Id",
                        column: x => x.Medico_Id,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "EspecialidadeMedica",
                columns: new[] { "Id", "Nome" },
                values: new object[,]
                {
                    { 1, "Clínico Geral" },
                    { 2, "Pediatra" },
                    { 3, "Cardiologista" },
                    { 4, "Ginecologista e Obstetra" },
                    { 5, "Dermatologista" },
                    { 6, "Ortopedista e Traumatologista" },
                    { 7, "Neurologista" },
                    { 8, "Psiquiatra" },
                    { 9, "Oftalmologista" },
                    { 10, "Endocrinologista" },
                    { 11, "Gastroenterologista" },
                    { 12, "Urologista" },
                    { 13, "Hematologista" },
                    { 14, "Oncologista" },
                    { 15, "Nefrologista" },
                    { 16, "Reumatologista" },
                    { 17, "Otorrinolaringologista" },
                    { 18, "Pneumologista" },
                    { 19, "Infectologista" },
                    { 20, "Cirurgião Geral" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_Paciente_Id",
                table: "Agenda",
                column: "Paciente_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicoEspecialidade_EspecialidadeMedica_Id",
                table: "MedicoEspecialidade",
                column: "EspecialidadeMedica_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "MedicoEspecialidade");

            migrationBuilder.DropTable(
                name: "EspecialidadeMedica");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
