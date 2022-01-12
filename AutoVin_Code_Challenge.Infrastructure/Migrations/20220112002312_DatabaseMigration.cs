using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoVin_Code_Challenge.Infrastructure.Migrations
{
    public partial class DatabaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TransactionTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AccountTypes_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OtherName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    BankId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerAccounts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerAccounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerAccounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerAccountId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TransactionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_CustomerAccounts_CustomerAccountId",
                        column: x => x.CustomerAccountId,
                        principalTable: "CustomerAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transactions_TransactionTypes_TransactionTypeId",
                        column: x => x.TransactionTypeId,
                        principalTable: "TransactionTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Banks",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name" },
                values: new object[] { new Guid("18e1d071-8b97-45d3-bff8-03f78f3160eb"), new DateTime(2022, 1, 12, 0, 23, 11, 579, DateTimeKind.Utc).AddTicks(5257), new DateTime(2022, 1, 12, 0, 23, 11, 579, DateTimeKind.Utc).AddTicks(5598), "Test Bank" });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "CreatedOn", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("4ddc3ee3-2845-434e-beac-5ea577c595d6"), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(3580), null, "Deposit" },
                    { new Guid("fc1eb2a3-15e2-473f-849f-ebe128716a05"), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(3762), null, "Withdraw" },
                    { new Guid("98690649-0319-4519-adf4-dd58845f8bf1"), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(3787), null, "Transfer" }
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "Id", "BankId", "CreatedOn", "LastModifiedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("3efdedd6-75b9-4acf-9704-1101fceea114"), new Guid("18e1d071-8b97-45d3-bff8-03f78f3160eb"), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(2432), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(2447), "Checking" },
                    { new Guid("e1c49eb7-7d32-4eac-b0f0-e7b264f3a873"), new Guid("18e1d071-8b97-45d3-bff8-03f78f3160eb"), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(2724), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(2726), "Individual Investment" },
                    { new Guid("d9b09f00-fed9-4d7c-a8bb-01ba171628cb"), new Guid("18e1d071-8b97-45d3-bff8-03f78f3160eb"), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(2752), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(2753), "Individual Investment" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "BankId", "CreatedOn", "FirstName", "LastModifiedOn", "OtherName", "Surname" },
                values: new object[] { new Guid("55212420-ef6b-40eb-8084-179e5eedd283"), new Guid("18e1d071-8b97-45d3-bff8-03f78f3160eb"), new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(5080), "Richard", null, null, "Aidoo" });

            migrationBuilder.InsertData(
                table: "CustomerAccounts",
                columns: new[] { "Id", "AccountNumber", "AccountTypeId", "CreatedOn", "CustomerId", "LastModifiedOn" },
                values: new object[] { new Guid("ae7e0c28-fe19-44fd-8fb5-6a9eb8c7046b"), "", new Guid("e1c49eb7-7d32-4eac-b0f0-e7b264f3a873"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("55212420-ef6b-40eb-8084-179e5eedd283"), null });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedOn", "CustomerAccountId", "LastModifiedOn", "TransactionTypeId" },
                values: new object[] { new Guid("69d61395-47db-4374-b631-66d0dcd4a9fb"), 10000.0, new DateTime(2022, 1, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(8144), new Guid("ae7e0c28-fe19-44fd-8fb5-6a9eb8c7046b"), null, new Guid("4ddc3ee3-2845-434e-beac-5ea577c595d6") });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedOn", "CustomerAccountId", "LastModifiedOn", "TransactionTypeId" },
                values: new object[] { new Guid("918eb616-307a-452b-90b6-d5b6c69f6532"), 500.0, new DateTime(2022, 4, 12, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(8337), new Guid("ae7e0c28-fe19-44fd-8fb5-6a9eb8c7046b"), null, new Guid("fc1eb2a3-15e2-473f-849f-ebe128716a05") });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "CreatedOn", "CustomerAccountId", "LastModifiedOn", "TransactionTypeId" },
                values: new object[] { new Guid("98046320-fb31-4795-b6f6-11ff141051d8"), 1500.0, new DateTime(2022, 2, 17, 0, 23, 11, 581, DateTimeKind.Utc).AddTicks(8537), new Guid("ae7e0c28-fe19-44fd-8fb5-6a9eb8c7046b"), null, new Guid("fc1eb2a3-15e2-473f-849f-ebe128716a05") });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTypes_BankId",
                table: "AccountTypes",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_AccountTypeId",
                table: "CustomerAccounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_CustomerId",
                table: "CustomerAccounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BankId",
                table: "Customers",
                column: "BankId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CustomerAccountId",
                table: "Transactions",
                column: "CustomerAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_TransactionTypeId",
                table: "Transactions",
                column: "TransactionTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "CustomerAccounts");

            migrationBuilder.DropTable(
                name: "TransactionTypes");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
