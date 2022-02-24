using Microsoft.EntityFrameworkCore.Migrations;

namespace ExploreCalifornia.Migrations
{
    public partial class SeedingMonthlySpecials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("insert into MonthlySpecials values ('Calm', 'California Calm Package', 'Day Spa Package', 250)");
            migrationBuilder.Sql("insert into MonthlySpecials values ('Desert', 'From Desert to Sea', '2 Day Salton Sea', 350)");
            migrationBuilder.Sql("insert into MonthlySpecials values ('Backpack', 'Backpack Cali', 'Big Sur Retreat', 620)");
            migrationBuilder.Sql("insert into MonthlySpecials values ('Taste', 'Taste of California', 'Tapas & Groves', 150)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
