using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations {
    /// <inheritdoc />
    public partial class InitCourses : Migration {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceOriginal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceDiscounted = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    LikePercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BestSeller = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table => {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
