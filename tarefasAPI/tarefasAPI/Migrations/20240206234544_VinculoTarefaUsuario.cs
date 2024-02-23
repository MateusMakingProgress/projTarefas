using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tarefasAPI.Migrations
{
    /// <inheritdoc />
    public partial class VinculoTarefaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UsuarioId",
                table: "TarefaModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TarefaModel_UsuarioId",
                table: "TarefaModel",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_TarefaModel_UsuarioModel_UsuarioId",
                table: "TarefaModel",
                column: "UsuarioId",
                principalTable: "UsuarioModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TarefaModel_UsuarioModel_UsuarioId",
                table: "TarefaModel");

            migrationBuilder.DropIndex(
                name: "IX_TarefaModel_UsuarioId",
                table: "TarefaModel");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "TarefaModel");
        }
    }
}
