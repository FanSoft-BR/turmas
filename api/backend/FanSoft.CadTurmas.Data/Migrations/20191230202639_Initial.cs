using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FanSoft.CadTurmas.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Instrutores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrutores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Instrutores",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Fabiano Nalin" });

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { new Guid("11927d0e-5065-44ce-9795-4b713d71d00f"), "Turma AZ 203", "AZ 203 Dez 2019" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrutores");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
