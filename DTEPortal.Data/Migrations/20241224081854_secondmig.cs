using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTEPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondmig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "MstState",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "MstState",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "IPAddress",
                table: "MstState",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LastUpdatedBy",
                table: "MstState",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdatedOn",
                table: "MstState",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MstState");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "MstState");

            migrationBuilder.DropColumn(
                name: "IPAddress",
                table: "MstState");

            migrationBuilder.DropColumn(
                name: "LastUpdatedBy",
                table: "MstState");

            migrationBuilder.DropColumn(
                name: "LastUpdatedOn",
                table: "MstState");
        }
    }
}
