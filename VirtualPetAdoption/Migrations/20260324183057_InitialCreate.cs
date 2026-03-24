using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VirtualPetAdoption.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Species = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false),
                    EnergyLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "Description", "EnergyLevel", "ImageUrl", "Name", "Species" },
                values: new object[,]
                {
                    { 1, "A calm and relaxed cat who enjoys naps.", 2, "/images/cat.png", "Fluffy", "Cat" },
                    { 2, "A high-energy dog who loves to play fetch.", 5, "/images/dog.png", "Rex", "Dog" },
                    { 3, "A friendly rabbit with moderate energy.", 3, "/images/rabbit.png", "Nibbles", "Rabbit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");
        }
    }
}
