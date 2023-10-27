using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SysRH.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ATUALIZACPF : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CPF",
                table: "Employee",
                type: "INT(11)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "CPF",
                table: "Employee",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT(11)");
        }
    }
}
