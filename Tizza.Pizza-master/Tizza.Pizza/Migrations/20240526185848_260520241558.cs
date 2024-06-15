using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tizza.Pizzas.Migrations
{
    /// <inheritdoc />
    public partial class _260520241558 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataVigenciaPromocao",
                table: "Pizza",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "ValorPromocao",
                table: "Pizza",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataVigenciaPromocao",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "ValorPromocao",
                table: "Pizza");
        }
    }
}
