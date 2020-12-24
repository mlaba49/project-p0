using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaWorld.Storing.Migrations
{
    public partial class addstorename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntityGuid",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EntityGuid",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "EntityGuid",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "APizzaModel");

            migrationBuilder.DropColumn(
                name: "EntityGuid",
                table: "APizzaModel");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "APizzaModel");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stores",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Order",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<long>(
                name: "StoreEntityId1",
                table: "Order",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 2L, "Dominoes" });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "EntityId", "Name" },
                values: new object[] { 3L, "Pizza Hut" });

            migrationBuilder.CreateIndex(
                name: "IX_Order_StoreEntityId1",
                table: "Order",
                column: "StoreEntityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Stores_StoreEntityId1",
                table: "Order",
                column: "StoreEntityId1",
                principalTable: "Stores",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Stores_StoreEntityId1",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_StoreEntityId1",
                table: "Order");

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Stores",
                keyColumn: "EntityId",
                keyValue: 3L);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "StoreEntityId1",
                table: "Order");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityGuid",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityGuid",
                table: "Stores",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EntityGuid",
                table: "Order",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "APizzaModel",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EntityGuid",
                table: "APizzaModel",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "APizzaModel",
                type: "float",
                nullable: true);
        }
    }
}
