using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSAPI.Migrations
{
    public partial class add_employee_sp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE AddEmployee
                            @First_Name VARCHAR(50),
                            @Last_Name VARCHAR(50),
                            @Middle_Name VARCHAR(50),
                            @Address VARCHAR(50),
                            @DOB VARCHAR(50)
                        AS
                        BEGIN
                            INSERT INTO Employees (First_Name,Last_Name,Middle_Name,Address,DOB)
                            VALUES (@First_Name,
                            @Last_Name,
                            @Middle_Name,
                            @Address,
                            @DOB);
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE AddEmployee";
            migrationBuilder.Sql(sp);
        }
    }
}
