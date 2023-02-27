using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dag8_Opgave1_MinFørste_EF_App.Migrations
{
    /// <inheritdoc />
    public partial class addAge : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "age",
                table: "Bil",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Bil",
                keyColumn: "BILID",
                keyValue: -1,
                column: "age",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Bil");
        }
    }
}
