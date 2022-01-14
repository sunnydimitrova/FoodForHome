using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodForHome.Data.Migrations
{
    public partial class UpdateAplicationUserDish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "ApplicationUserDishes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "ApplicationUserDishes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ApplicationUserDishes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "ApplicationUserDishes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserDishes_IsDeleted",
                table: "ApplicationUserDishes",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ApplicationUserDishes_IsDeleted",
                table: "ApplicationUserDishes");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "ApplicationUserDishes");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "ApplicationUserDishes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ApplicationUserDishes");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "ApplicationUserDishes");
        }
    }
}
