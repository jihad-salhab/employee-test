using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace employee_test.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Jobs (Description) VALUES ('Software Engineer')");
            migrationBuilder.Sql("INSERT INTO Jobs (Description) VALUES ('Project Manager')");
            migrationBuilder.Sql("INSERT INTO Jobs (Description) VALUES ('Technical Support')");

            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Mark Keeling',965522022,1)");
            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Destiny Hays',685255620,1)");
            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Lorcan Harrington',454751215,1)");
            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Alec Townsend',582256325,1)");
            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Jethro Cortes',215525555,2)");
            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Dru Black',126582825,2)");
            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Claudia Barker',784446225,2)");
            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Kunal Farrell',576652555,2)");
            migrationBuilder.Sql("INSERT INTO Employees (FullName,PhoneNumber,jobId) VALUES ('Shaun Burton',787522552,2)");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Jobs WHERE Description IN('Software Engineer','Project Manager','Technical Support')");

        }
    }
}
