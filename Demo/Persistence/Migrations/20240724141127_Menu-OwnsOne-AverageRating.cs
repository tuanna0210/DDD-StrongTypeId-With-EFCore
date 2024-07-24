﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Demo.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MenuOwnsOneAverageRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AverageRating_NumRatings",
                table: "Menus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "AverageRating_Value",
                table: "Menus",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AverageRating_NumRatings",
                table: "Menus");

            migrationBuilder.DropColumn(
                name: "AverageRating_Value",
                table: "Menus");
        }
    }
}
