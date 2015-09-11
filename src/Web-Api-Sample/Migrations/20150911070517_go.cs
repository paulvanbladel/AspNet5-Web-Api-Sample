using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace WebApiSample.Migrations
{
    public partial class go : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(isNullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(isNullable: true),
                    City = table.Column<string>(isNullable: true),
                    CompanyName = table.Column<string>(isNullable: true),
                    ContactTitle = table.Column<string>(isNullable: true),
                    Fax = table.Column<string>(isNullable: true),
                    Phone = table.Column<string>(isNullable: true),
                    PostalCode = table.Column<string>(isNullable: true),
                    Region = table.Column<string>(isNullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Customer");
        }
    }
}
