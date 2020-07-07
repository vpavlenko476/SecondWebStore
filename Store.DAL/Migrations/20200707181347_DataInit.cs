using Microsoft.EntityFrameworkCore.Migrations;
using Store.DAL.DataInit;

namespace Store.DAL.Migrations
{
    public partial class DataInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            DataInitilizer.InitData();
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
