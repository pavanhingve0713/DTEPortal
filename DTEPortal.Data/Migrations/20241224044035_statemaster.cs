using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DTEPortal.Data.Migrations
{
    /// <inheritdoc />
    public partial class statemaster : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MstState",
                columns: table => new
                {
                    StateId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateNameEng = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    StateNameHin = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    StateCode = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MstState", x => x.StateId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MstState");
        }
    }
}
