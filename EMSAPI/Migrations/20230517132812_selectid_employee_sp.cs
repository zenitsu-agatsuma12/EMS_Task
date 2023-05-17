using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMSAPI.Migrations
{
    public partial class selectid_employee_sp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE SelectEmployeeId
                            @Id INT
                        AS
                        BEGIN
                            SELECT * FROM Employees WHERE Id = @Id;
                        END";
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sp = @"DROP PROCEDURE SelectEmployeeId";
            migrationBuilder.Sql(sp);
        }
    }
}
