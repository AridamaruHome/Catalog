using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertiesToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Products",
                newSchema: "Warehouse");

            migrationBuilder.AddColumn<string>(
                name: "Barcode",
                schema: "Warehouse",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                schema: "Warehouse",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                schema: "Warehouse",
                table: "Products",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Warehouse",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                schema: "Warehouse",
                table: "Products",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                schema: "Warehouse",
                table: "Products",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                schema: "Warehouse",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Barcode",
                schema: "Warehouse",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Category",
                schema: "Warehouse",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                schema: "Warehouse",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Warehouse",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                schema: "Warehouse",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                schema: "Warehouse",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                schema: "Warehouse",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                schema: "Warehouse",
                newName: "Products");
        }
    }
}
