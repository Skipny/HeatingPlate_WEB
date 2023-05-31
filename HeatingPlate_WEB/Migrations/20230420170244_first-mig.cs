using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HeatingPlate_WEB.Migrations
{
    /// <inheritdoc />
    public partial class firstmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "coefficients",
                columns: table => new
                {
                    coefficient_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    bi = table.Column<float>(type: "REAL", nullable: false),
                    thickness = table.Column<float>(type: "REAL", nullable: false),
                    number_p = table.Column<float>(type: "REAL", nullable: false),
                    number_m = table.Column<float>(type: "REAL", nullable: false),
                    number_n = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_coefficients", x => x.coefficient_id);
                });

            migrationBuilder.CreateTable(
                name: "metals",
                columns: table => new
                {
                    metal_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    metal_name = table.Column<string>(type: "TEXT", nullable: false),
                    temperature = table.Column<int>(type: "INTEGER", nullable: false),
                    density = table.Column<int>(type: "INTEGER", nullable: false),
                    lambda = table.Column<float>(type: "REAL", nullable: false),
                    heat_capacity = table.Column<float>(type: "REAL", nullable: false),
                    forward_movement = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_metals", x => x.metal_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "coefficients");

            migrationBuilder.DropTable(
                name: "metals");
        }
    }
}
