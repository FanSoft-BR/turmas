using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FanSoft.CadTurmas.Data.Migrations
{
    public partial class AddCampoDescricaoInstrutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: new Guid("11927d0e-5065-44ce-9795-4b713d71d00f"));

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Instrutores",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { new Guid("77118e79-8ae3-42e5-a215-155da30e523b"), "Turma AZ 203", "AZ 203 Dez 2019" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: new Guid("77118e79-8ae3-42e5-a215-155da30e523b"));

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Instrutores");

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[] { new Guid("11927d0e-5065-44ce-9795-4b713d71d00f"), "Turma AZ 203", "AZ 203 Dez 2019" });
        }
    }
}
