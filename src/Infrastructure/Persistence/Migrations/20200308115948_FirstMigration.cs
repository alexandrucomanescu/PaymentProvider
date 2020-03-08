using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentProvider.Infrastructure.Persistence.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    CreditCardNumber = table.Column<string>(),
                    CardHolder = table.Column<string>(),
                    ExpirationDate = table.Column<string>(),
                    SecurityCode = table.Column<string>(nullable: true),
                    Amount = table.Column<decimal>(),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentState",
                columns: table => new
                {
                    Id = table.Column<Guid>(),
                    PaymentId = table.Column<Guid>(),
                    Status = table.Column<int>(),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentState", x => x.Id);
                    
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
