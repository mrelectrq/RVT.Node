using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlockChain",
                columns: table => new
                {
                    BlockID = table.Column<int>(unicode: false, maxLength: 500, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(unicode: false, maxLength: 500, nullable: false),
                    Hash = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    PreviouseHash = table.Column<string>(unicode: false, maxLength: 2000, nullable: true),
                    Party_Choosed = table.Column<int>(nullable: false),
                    Region_Choosed = table.Column<int>(nullable: false),
                    Gender = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    Year_To_Birth = table.Column<int>(nullable: false),
                    IDBD = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BlockCha__1442151110DD289E", x => x.BlockID);
                });

            migrationBuilder.CreateTable(
                name: "Consensus_Accounts",
                columns: table => new
                {
                    IDBD = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    RepDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    RepByNode_R = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Software = table.Column<string>(unicode: false, maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Consensu__B87DA8C3E8B93C43", x => x.IDBD);
                });

            migrationBuilder.CreateTable(
                name: "NPR___Data",
                columns: table => new
                {
                    IDVN = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    HashAds = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IntroducedBy = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Repdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NPR___Da__B87C0A44F71D4561", x => x.IDVN);
                });

            migrationBuilder.CreateTable(
                name: "NPV___Data",
                columns: table => new
                {
                    IDBD = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    HashAds = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    IntroducedBy = table.Column<string>(unicode: false, maxLength: 30, nullable: true),
                    Repdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NPV___Da__B87DA8C3747E560B", x => x.IDBD);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlockChain");

            migrationBuilder.DropTable(
                name: "Consensus_Accounts");

            migrationBuilder.DropTable(
                name: "NPR___Data");

            migrationBuilder.DropTable(
                name: "NPV___Data");
        }
    }
}
