using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YasminStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryAndStoreRealtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategoryStores_StoreCategories_StoreCategoryId",
                table: "StoreCategoryStores");

            migrationBuilder.DropTable(
                name: "StoreCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategoryStores",
                table: "StoreCategoryStores");

            migrationBuilder.DropIndex(
                name: "IX_StoreCategoryStores_StoreId",
                table: "StoreCategoryStores");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "StoreCategoryStores");

            migrationBuilder.RenameColumn(
                name: "StoreCategoryId",
                table: "StoreCategoryStores",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategoryStores_StoreCategoryId",
                table: "StoreCategoryStores",
                newName: "IX_StoreCategoryStores_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategoryStores",
                table: "StoreCategoryStores",
                columns: new[] { "StoreId", "CategoryId" });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryStores_Categories_CategoryId",
                table: "StoreCategoryStores",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StoreCategoryStores_Categories_CategoryId",
                table: "StoreCategoryStores");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StoreCategoryStores",
                table: "StoreCategoryStores");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "StoreCategoryStores",
                newName: "StoreCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_StoreCategoryStores_CategoryId",
                table: "StoreCategoryStores",
                newName: "IX_StoreCategoryStores_StoreCategoryId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "StoreCategoryStores",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StoreCategoryStores",
                table: "StoreCategoryStores",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "StoreCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategoryStores_StoreId",
                table: "StoreCategoryStores",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_StoreCategoryStores_StoreCategories_StoreCategoryId",
                table: "StoreCategoryStores",
                column: "StoreCategoryId",
                principalTable: "StoreCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
