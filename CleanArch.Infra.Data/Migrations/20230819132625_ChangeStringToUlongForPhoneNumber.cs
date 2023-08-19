using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeStringToUlongForPhoneNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "PhoneNumber",
                table: "Customers",
                type: "bigint unsigned",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bigint unsigned")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
