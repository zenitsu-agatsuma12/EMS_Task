using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSAPI.Migrations
{
    public partial class update_employee_sp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE UpdateEmployee
                    @Id INT,
                    @First_Name VARCHAR(50),
                    @Last_Name VARCHAR(50),
                    @Middle_Name VARCHAR(50),
                    @Address VARCHAR(50),
                    @DOB VARCHAR(50)
                AS
                BEGIN
                    UPDATE Employees
                    SET First_Name = @First_Name,
                        Last_Name = @Last_Name,
                        Middle_Name = @Middle_Name,
                        Address = @Address,
                        DOB = @DOB
                    WHERE Id = @Id;
                END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE UpdateEmployee";
            migrationBuilder.Sql(sp);
        }
    }
}
