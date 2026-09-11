using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_Waylan_Origin.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionCitaSemanal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Fecha",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CalloutTexto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CalloutTitulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HeroImageUrl",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "HistoriaTitulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptCard1ImageUrl",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptCard1Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptCard1Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptCard2ImageUrl",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptCard2Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptCard2Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa1Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa1Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa2Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa2Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa3Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa3Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa4Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa4Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa5Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProcesoEtapa5Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Razon1Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Razon1Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Razon2Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Razon2Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Razon3Texto",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Razon3Titulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RazonesTitulo",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Testimonio",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Ubicacion",
                table: "CitasSemanales",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalloutTexto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "CalloutTitulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "HeroImageUrl",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "HistoriaTitulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "OptCard1ImageUrl",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "OptCard1Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "OptCard1Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "OptCard2ImageUrl",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "OptCard2Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "OptCard2Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa1Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa1Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa2Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa2Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa3Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa3Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa4Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa4Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa5Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "ProcesoEtapa5Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "Razon1Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "Razon1Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "Razon2Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "Razon2Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "Razon3Texto",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "Razon3Titulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "RazonesTitulo",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "Testimonio",
                table: "CitasSemanales");

            migrationBuilder.DropColumn(
                name: "Ubicacion",
                table: "CitasSemanales");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha",
                table: "CitasSemanales",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
