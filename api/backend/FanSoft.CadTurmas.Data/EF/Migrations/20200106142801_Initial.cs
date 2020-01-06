using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FanSoft.CadTurmas.Data.EF.Migrations
{
    public partial class Initial : Migration
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
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nome = table.Column<string>(type: "varchar(80)", nullable: false),
                    Email = table.Column<string>(type: "varchar(80)", nullable: false),
                    Senha = table.Column<string>(type: "char(88)", nullable: false),
                    RefreshToken = table.Column<string>(type: "char(32)", nullable: true),
                    RefreshTokenValidate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
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
                values: new object[] { 1, new DateTime(2020, 1, 6, 14, 28, 0, 349, DateTimeKind.Utc).AddTicks(9866), new DateTime(2020, 1, 6, 14, 28, 0, 349, DateTimeKind.Utc).AddTicks(9837), null, "Fabiano Nalin" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "AlteradoEm", "CriadoEm", "Email", "Nome", "RefreshToken", "RefreshTokenValidate", "Senha" },
                values: new object[] { 1, new DateTime(2020, 1, 6, 14, 28, 0, 362, DateTimeKind.Utc).AddTicks(6163), new DateTime(2020, 1, 6, 14, 28, 0, 362, DateTimeKind.Utc).AddTicks(6138), "nalin@fansoft.com.br", "Fabiano Nalin", null, null, "a1n5uKDhhuf8oIt9RxEKX4dGV3ASZODELtipSBegRkM92SE+EaUhgxS0now1iRwko0nTDhfR3q7rV+Lz3btZMQ==" });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "AlteradoEm", "CriadoEm", "DataInicio", "DataTermino", "Descricao", "InstrutorId", "Nome" },
                values: new object[] { new Guid("d4228a44-1a3d-46f1-b8eb-e2cfdb7ff551"), new DateTime(2020, 1, 6, 14, 28, 0, 352, DateTimeKind.Utc).AddTicks(5786), new DateTime(2020, 1, 6, 14, 28, 0, 352, DateTimeKind.Utc).AddTicks(5776), new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Turma AZ 203", 1, "AZ 203 Dez 2019" });

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
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Instrutor");
        }
    }
}
