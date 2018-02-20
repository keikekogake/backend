using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;


namespace modelobasicoefjwt.Migrations {
    public partial class Estrutura_Inicial : Migration {
        protected override void Up (MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable (
                name: "Permissoes",
                columns : table => new {
                    IdPermissao = table.Column<int> (type: "int", nullable : false)
                        .Annotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        Nome = table.Column<string> (type: "nvarchar(100)", maxLength : 100, nullable : false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Permissoes", x => x.IdPermissao);
                });

            migrationBuilder.CreateTable (
                name: "Usuarios",
                columns : table => new {
                    IdUsuario = table.Column<int> (type: "int", nullable : false)
                        .Annotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        DataNascimento = table.Column<DateTime> (type: "datetime2", nullable : false),
                        Email = table.Column<string> (type: "nvarchar(50)", maxLength : 50, nullable : false),
                        Nome = table.Column<string> (type: "nvarchar(100)", maxLength : 100, nullable : false),
                        Senha = table.Column<string> (type: "nvarchar(12)", maxLength : 12, nullable : false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_Usuarios", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable (
                name: "UsuariosPermissoes",
                columns : table => new {
                    IdUsuarioPermissao = table.Column<int> (type: "int", nullable : false)
                        .Annotation ("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                        IdPermissao = table.Column<int> (type: "int", nullable : false),
                        IdUsuario = table.Column<int> (type: "int", nullable : false)
                },
                constraints : table => {
                    table.PrimaryKey ("PK_UsuariosPermissoes", x => x.IdUsuarioPermissao);
                    table.ForeignKey (
                        name: "FK_UsuariosPermissoes_Permissoes_IdPermissao",
                        column : x => x.IdPermissao,
                        principalTable: "Permissoes",
                        principalColumn: "IdPermissao",
                        onDelete : ReferentialAction.Cascade);
                    table.ForeignKey (
                        name: "FK_UsuariosPermissoes_Usuarios_IdUsuario",
                        column : x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUsuario",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex (
                name: "IX_UsuariosPermissoes_IdPermissao",
                table: "UsuariosPermissoes",
                column: "IdPermissao");

            migrationBuilder.CreateIndex (
                name: "IX_UsuariosPermissoes_IdUsuario",
                table: "UsuariosPermissoes",
                column: "IdUsuario");
        }

        protected override void Down (MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable (
                name: "UsuariosPermissoes");

            migrationBuilder.DropTable (
                name: "Permissoes");

            migrationBuilder.DropTable (
                name: "Usuarios");
        }
    }
}