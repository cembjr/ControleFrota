using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Cembjr.ControleFrota.Data.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CFAten",
                columns: table => new
                {
                    IdAten = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    IsExcluido = table.Column<bool>(nullable: false),
                    AtenNome = table.Column<string>(nullable: false),
                    AtenTele = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFAten", x => x.IdAten);
                });

            migrationBuilder.CreateTable(
                name: "CFMoto",
                columns: table => new
                {
                    IdMoto = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    IsExcluido = table.Column<bool>(nullable: false),
                    MotoNome = table.Column<string>(nullable: false),
                    MotoTele = table.Column<string>(nullable: false),
                    MotoCnh = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFMoto", x => x.IdMoto);
                });

            migrationBuilder.CreateTable(
                name: "CFVeic",
                columns: table => new
                {
                    IdVeic = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    IsExcluido = table.Column<bool>(nullable: false),
                    VeicMarc = table.Column<string>(nullable: false),
                    VeicMode = table.Column<string>(nullable: false),
                    VeicPlac = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFVeic", x => x.IdVeic);
                });

            migrationBuilder.CreateTable(
                name: "CFServ",
                columns: table => new
                {
                    IdServ = table.Column<Guid>(nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    IsExcluido = table.Column<bool>(nullable: false),
                    DatSaid = table.Column<DateTime>(nullable: false),
                    DatCheg = table.Column<DateTime>(nullable: true),
                    IdAten = table.Column<Guid>(nullable: false),
                    IdMoto = table.Column<Guid>(nullable: false),
                    IdVeic = table.Column<Guid>(nullable: false),
                    ServDest = table.Column<string>(nullable: false),
                    ServObse = table.Column<string>(nullable: true),
                    ServKmInic = table.Column<int>(nullable: false),
                    ServKmFina = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CFServ", x => x.IdServ);
                    table.ForeignKey(
                        name: "FK_CFServ_CFAten_IdAten",
                        column: x => x.IdAten,
                        principalTable: "CFAten",
                        principalColumn: "IdAten",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CFServ_CFMoto_IdMoto",
                        column: x => x.IdMoto,
                        principalTable: "CFMoto",
                        principalColumn: "IdMoto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CFServ_CFVeic_IdVeic",
                        column: x => x.IdVeic,
                        principalTable: "CFVeic",
                        principalColumn: "IdVeic",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CFServ_IdAten",
                table: "CFServ",
                column: "IdAten");

            migrationBuilder.CreateIndex(
                name: "IX_CFServ_IdMoto",
                table: "CFServ",
                column: "IdMoto");

            migrationBuilder.CreateIndex(
                name: "IX_CFServ_IdVeic",
                table: "CFServ",
                column: "IdVeic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CFServ");

            migrationBuilder.DropTable(
                name: "CFAten");

            migrationBuilder.DropTable(
                name: "CFMoto");

            migrationBuilder.DropTable(
                name: "CFVeic");
        }
    }
}
