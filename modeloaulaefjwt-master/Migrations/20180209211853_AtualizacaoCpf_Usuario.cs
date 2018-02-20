using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace modelobasicoefjwt.Migrations
{
    public partial class AtualizacaoCpf_Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "Usuarios",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "Usuarios");
        }
    }
}
