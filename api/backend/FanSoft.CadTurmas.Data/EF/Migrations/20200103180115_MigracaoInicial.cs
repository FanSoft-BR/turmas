using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FanSoft.CadTurmas.Data.EF.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrutor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    InstrutorId = table.Column<int>(type: "int", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    DataTermino = table.Column<DateTime>(type: "date", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(80)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turma_Instrutor_InstrutorId",
                        column: x => x.InstrutorId,
                        principalTable: "Instrutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.InsertData(
                table: "Instrutor",
                columns: new[] { "Id", "AlteradoEm", "CriadoEm", "Descricao", "Nome" },
                values: new object[] { 1, new DateTime(2020, 1, 3, 18, 1, 15, 21, DateTimeKind.Utc).AddTicks(9175), new DateTime(2020, 1, 3, 18, 1, 15, 21, DateTimeKind.Utc).AddTicks(9149), null, "Fabiano Nalin" });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "AlteradoEm", "CriadoEm", "DataInicio", "DataTermino", "Descricao", "InstrutorId", "Nome" },
                values: new object[] { new Guid("df9344ae-e6bb-42c5-99af-5f1543908b9c"), new DateTime(2020, 1, 3, 18, 1, 15, 24, DateTimeKind.Utc).AddTicks(1561), new DateTime(2020, 1, 3, 18, 1, 15, 24, DateTimeKind.Utc).AddTicks(1550), new DateTime(2020, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Turma AZ 203", 1, "AZ 203 Dez 2019" });

            migrationBuilder.CreateIndex(
                name: "IX_Turma_InstrutorId",
                table: "Turma",
                column: "InstrutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Instrutor");
        }
    }
}
