using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BranchId",
                table: "MerchantRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MerchantRequests_BranchId",
                table: "MerchantRequests",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_MerchantRequests_Branches_BranchId",
                table: "MerchantRequests",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MerchantRequests_Branches_BranchId",
                table: "MerchantRequests");

            migrationBuilder.DropIndex(
                name: "IX_MerchantRequests_BranchId",
                table: "MerchantRequests");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "MerchantRequests");
        }
    }
}
