using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "TechDb");

            migrationBuilder.CreateTable(
                name: "Bancos",
                schema: "TechDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Code = table.Column<int>(type: "integer", nullable: false),
                    InterestPercent = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bancos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Boletos",
                schema: "TechDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PayorName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PayorCpfCnpj = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: true),
                    PayeeName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BancoId = table.Column<int>(type: "integer", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Boletos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bancos_Code",
                schema: "TechDb",
                table: "Bancos",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bancos",
                schema: "TechDb");

            migrationBuilder.DropTable(
                name: "Boletos",
                schema: "TechDb");
        }
    }
}
