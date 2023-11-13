using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysRH.Infra.Migrations
{
    /// <inheritdoc />
    public partial class cpfupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Employee",
                type: "VARCHAR(11)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CPF",
                table: "Employee",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
