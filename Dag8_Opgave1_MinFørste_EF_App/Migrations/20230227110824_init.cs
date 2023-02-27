using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dag8_Opgave1_MinFørste_EF_App.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Bil",
            //    columns: table => new
            //    {
            //        BILID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Weigth = table.Column<int>(type: "int", nullable: false),
            //        Diesel = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Bil", x => x.BILID);
            //    });

            //migrationBuilder.InsertData(
            //    table: "Bil",
            //    columns: new[] { "BILID", "Diesel", "Name", "Weigth" },
            //    values: new object[] { -1, true, "Ford", 1400 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bil");
        }
    }
}
