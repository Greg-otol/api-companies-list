using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_companies_list.Migrations
{
    /// <inheritdoc />
    public partial class PostgreDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RazaoSocial = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    InscricaoMunicipal = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    StatusEmpresa = table.Column<int>(type: "integer", nullable: false),
                    ResponsavelLegal = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    TelefoneContato = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
