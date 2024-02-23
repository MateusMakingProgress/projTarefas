using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tarefasAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationVinculoTarefa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TarefaModel_UsuarioModel_UsuarioId",
                table: "TarefaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TarefaModel",
                table: "TarefaModel");

            migrationBuilder.RenameTable(
                name: "UsuarioModel",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "TarefaModel",
                newName: "Tarefas");

            migrationBuilder.RenameIndex(
                name: "IX_TarefaModel_UsuarioId",
                table: "Tarefas",
                newName: "IX_Tarefas_UsuarioId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Tarefas",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefas_Usuarios_UsuarioId",
                table: "Tarefas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tarefas",
                table: "Tarefas");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "UsuarioModel");

            migrationBuilder.RenameTable(
                name: "Tarefas",
                newName: "TarefaModel");

            migrationBuilder.RenameIndex(
                name: "IX_Tarefas_UsuarioId",
                table: "TarefaModel",
                newName: "IX_TarefaModel_UsuarioId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "TarefaModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsuarioModel",
                table: "UsuarioModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TarefaModel",
                table: "TarefaModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TarefaModel_UsuarioModel_UsuarioId",
                table: "TarefaModel",
                column: "UsuarioId",
                principalTable: "UsuarioModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
