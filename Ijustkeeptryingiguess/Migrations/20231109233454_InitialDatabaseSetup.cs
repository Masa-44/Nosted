using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ijustkeeptryingiguess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabaseSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesLead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn), // MariaDB identity
                    FirstName = table.Column<string>(type: "varchar(255)", nullable: false), // Changed to varchar(255)
                    LastName = table.Column<string>(type: "varchar(255)", nullable: false), // Changed to varchar(255)
                    Mobile = table.Column<string>(type: "varchar(255)", nullable: false), // Changed to varchar(255)
                    Email = table.Column<string>(type: "varchar(255)", nullable: false), // Changed to varchar(255)
                    Source = table.Column<string>(type: "varchar(255)", nullable: false) // Changed to varchar(255)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesLead", x => x.Id);
                });
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesLead");
        }
    }
}
