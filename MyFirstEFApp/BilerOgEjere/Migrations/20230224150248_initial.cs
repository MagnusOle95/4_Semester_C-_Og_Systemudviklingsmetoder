using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BilerOgEjere.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Bil",
            //    columns: table => new
            //    {
            //        BilID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Weight = table.Column<int>(type: "int", nullable: false),
            //        Diesel = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bil", x => x.BilID);
            //    });

            //migrationBuilder.InsertData(
            //    table: "Bil",
            //    columns: new[] { "BilID", "Diesel", "Name", "Weight" },
            //    values: new object[] { -1, false, "Ford", 1400 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bil");
        }
    }
}
