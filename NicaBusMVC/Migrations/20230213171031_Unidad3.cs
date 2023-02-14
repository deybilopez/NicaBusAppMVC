using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicaBusMVC.Migrations
{
    public partial class Unidad3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetallesViaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameBus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lugar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HoraLlegada = table.Column<int>(type: "int", nullable: false),
                    Destino = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesViaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ruta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destino = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ruta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetallesViajeId = table.Column<int>(type: "int", nullable: false),
                    RutaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_DetallesViaje_DetallesViajeId",
                        column: x => x.DetallesViajeId,
                        principalTable: "DetallesViaje",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_Ruta_RutaId",
                        column: x => x.RutaId,
                        principalTable: "Ruta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_DetallesViajeId",
                table: "User",
                column: "DetallesViajeId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RutaId",
                table: "User",
                column: "RutaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "DetallesViaje");

            migrationBuilder.DropTable(
                name: "Ruta");
        }
    }
}
