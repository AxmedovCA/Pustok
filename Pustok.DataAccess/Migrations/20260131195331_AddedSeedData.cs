using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pustok.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("4e2043c7-ea73-4d39-a5a8-3d14afaeb24d"), "Default Position" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumn: "Id",
                keyValue: new Guid("4e2043c7-ea73-4d39-a5a8-3d14afaeb24d"));
        }
    }
}
