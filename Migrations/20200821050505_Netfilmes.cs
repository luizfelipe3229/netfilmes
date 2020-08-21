//using System;
//using Microsoft.EntityFrameworkCore.Migrations;

//namespace Netfilmes.Migrations
//{
//    public partial class Netfilmes : Migration
//    {
//        protected override void Up(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.CreateTable(
//                name: "Genero",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Nome = table.Column<string>(nullable: true),
//                    DataDeCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "CONVERT(DATE, GETDATE())"),
//                    Ativo = table.Column<bool>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Genero", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Locacao",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Cpf = table.Column<string>(nullable: true),
//                    DataDaLocacao = table.Column<DateTime>(nullable: false, defaultValueSql: "CONVERT(DATE, GETDATE())")
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Locacao", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Usuario",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Nome = table.Column<string>(nullable: true),
//                    Senha = table.Column<string>(nullable: true),
//                    DataDeCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "CONVERT(DATE, GETDATE())")
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Usuario", x => x.Id);
//                });

//            migrationBuilder.CreateTable(
//                name: "Filme",
//                columns: table => new
//                {
//                    Id = table.Column<int>(nullable: false)
//                        .Annotation("SqlServer:Identity", "1, 1"),
//                    Nome = table.Column<string>(nullable: true),
//                    DataDeCriacao = table.Column<DateTime>(nullable: false, defaultValueSql: "CONVERT(DATE, GETDATE())"),
//                    Ativo = table.Column<bool>(nullable: false),
//                    GeneroId = table.Column<int>(nullable: true),
//                    LocacaoId = table.Column<int>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Filme", x => x.Id);
//                    table.ForeignKey(
//                        name: "FK_Filme_Genero_GeneroId",
//                        column: x => x.GeneroId,
//                        principalTable: "Genero",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.SetNull);
//                    table.ForeignKey(
//                        name: "FK_Filme_Locacao_LocacaoId",
//                        column: x => x.LocacaoId,
//                        principalTable: "Locacao",
//                        principalColumn: "Id",
//                        onDelete: ReferentialAction.Restrict);
//                });

//            migrationBuilder.CreateIndex(
//                name: "IX_Filme_GeneroId",
//                table: "Filme",
//                column: "GeneroId");

//            migrationBuilder.CreateIndex(
//                name: "IX_Filme_LocacaoId",
//                table: "Filme",
//                column: "LocacaoId");
//        }

//        protected override void Down(MigrationBuilder migrationBuilder)
//        {
//            migrationBuilder.DropTable(
//                name: "Filme");

//            migrationBuilder.DropTable(
//                name: "Usuario");

//            migrationBuilder.DropTable(
//                name: "Genero");

//            migrationBuilder.DropTable(
//                name: "Locacao");
//        }
//    }
//}
