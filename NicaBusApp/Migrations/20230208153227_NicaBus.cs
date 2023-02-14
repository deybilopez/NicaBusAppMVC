using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NicaBusApp.Migrations
{
    public partial class NicaBus : Migration
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesViaje");

            migrationBuilder.DropTable(
                name: "Ruta");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
