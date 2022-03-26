using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BASE_MSQL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Models = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goods", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Goods",
                columns: new[] { "Id", "Count", "Models", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 6, "Intel Core I5", "Processor", 5120m },
                    { 2, 10, "Intel Core I7", "Processor", 9120m },
                    { 3, 12, "Intel Core I8", "Processor", 11120m },
                    { 4, 3, "Intel Core I9", "Processor", 13120m },
                    { 5, 5, "AMD Ryzen 7", "Processor", 14134m },
                    { 6, 61, "AMD Ryzen 5", "Processor", 10378m }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Goods");
        }
    }
}
