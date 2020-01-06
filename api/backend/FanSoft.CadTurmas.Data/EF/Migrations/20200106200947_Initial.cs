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
                name: "Role",
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
                    table.PrimaryKey("PK_Role", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "UsuarioRole",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlteradoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioRole", x => new { x.UsuarioId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UsuarioRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioRole_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Instrutor",
                columns: new[] { "Id", "AlteradoEm", "CriadoEm", "Descricao", "Nome" },
                values: new object[] { 1, new DateTime(2020, 1, 6, 20, 9, 46, 953, DateTimeKind.Utc).AddTicks(302), new DateTime(2020, 1, 6, 20, 9, 46, 953, DateTimeKind.Utc).AddTicks(273), null, "Fabiano Nalin" });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "AlteradoEm", "CriadoEm", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(3351), new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(3339), "Administrador de tudo", "Admin" },
                    { 2, new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(5794), new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(5782), "Perfil de Usuário c/ privilégios administrativos", "PowerUser" },
                    { 3, new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(5936), new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(5933), "Perfil de Usuário comum", "User" }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "AlteradoEm", "CriadoEm", "Email", "Nome", "RefreshToken", "RefreshTokenValidate", "Senha" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 1, 6, 20, 9, 46, 965, DateTimeKind.Utc).AddTicks(7634), new DateTime(2020, 1, 6, 20, 9, 46, 965, DateTimeKind.Utc).AddTicks(7602), "nalin@fansoft.com.br", "Fabiano Nalin", null, null, "a1n5uKDhhuf8oIt9RxEKX4dGV3ASZODELtipSBegRkM92SE+EaUhgxS0now1iRwko0nTDhfR3q7rV+Lz3btZMQ==" },
                    { 2, new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(1460), new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(1448), "pmitui@gmail.com", "Priscila Mitui", null, null, "jVCZJAmUc24IvM/FtuyUf2gUm5/0m8fd4hEvrR0jq+ri86hUBVwi+8YefhqqWXbEXlJ94E62oUIdc50hBzCgTw==" }
                });

            migrationBuilder.InsertData(
                table: "Turma",
                columns: new[] { "Id", "AlteradoEm", "CriadoEm", "DataInicio", "DataTermino", "Descricao", "InstrutorId", "Nome" },
                values: new object[] { new Guid("afb2b278-9fee-47c3-9fce-3bedc2c28b0b"), new DateTime(2020, 1, 6, 20, 9, 46, 955, DateTimeKind.Utc).AddTicks(5025), new DateTime(2020, 1, 6, 20, 9, 46, 955, DateTimeKind.Utc).AddTicks(5013), new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2020, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "Turma AZ 203", 1, "AZ 203 Dez 2019" });

            migrationBuilder.InsertData(
                table: "UsuarioRole",
                columns: new[] { "UsuarioId", "RoleId", "AlteradoEm", "CriadoEm" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(8162), new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(8145) },
                    { 1, 2, new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(9931), new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(9919) },
                    { 2, 3, new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(9983), new DateTime(2020, 1, 6, 20, 9, 46, 966, DateTimeKind.Utc).AddTicks(9981) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turma_InstrutorId",
                table: "Turma",
                column: "InstrutorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioRole_RoleId",
                table: "UsuarioRole",
                column: "RoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "UsuarioRole");

            migrationBuilder.DropTable(
                name: "Instrutor");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
