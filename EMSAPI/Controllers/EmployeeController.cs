using EMSAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EMSAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EMSDBContext _context;

        public EmployeeController(EMSDBContext EMS)
        {
            _context = EMS;
        }

        //Select All
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _context.Employees.FromSqlRaw("EXEC SelectAllEmployee").ToListAsync();
            return Ok(result);
        }

        // Add
        [HttpPost]
        public async Task<IActionResult> AddEmployee(string First_Name, string Last_Name, string Middle_Name, string Address, string DOB)
        {
            var parameters = new[] {
                new SqlParameter("@First_Name", First_Name),
                new SqlParameter("@Last_Name", Last_Name),
                new SqlParameter("@Middle_Name", Middle_Name),
                new SqlParameter("@Address", Address),
                new SqlParameter("@DOB", DOB)

                };
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC AddEmployee @First_Name, @Last_Name,@Middle_Name,@Address,@DOB ", parameters);
            return Ok(result);
        }

        // Update

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(int Id, string First_Name, string Last_Name, string Middle_Name, string Address, string DOB)
        {
            var parameters = new[]
            {
                new SqlParameter("@EmployeeId", Id),
                new SqlParameter("@First_Name", First_Name),
                new SqlParameter("@Last_Name", Last_Name),
                new SqlParameter("@Middle_Name", Middle_Name),
                new SqlParameter("@Address", Address),
                new SqlParameter("@DOB", DOB)
            };
            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateEmployee @EmployeeId, @First_Name, @Last_Name, @Middle_Name, @Address, @DOB", parameters);
            return Ok();
        }

        // Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int Id)
        {
            var parameter = new SqlParameter("@Id", Id);
            await _context.Database.ExecuteSqlRawAsync("EXEC DeleteEmployee @Id", parameter);
            return Ok();
        }

        // Get By Id
        [HttpGet("{Id}")]
        public IActionResult GetEmployeeById(int Id)
        {
            var parameter = new SqlParameter("@Id", Id);
            var result = _context.Employees.FromSqlInterpolated($"EXEC SelectEmployeeId {parameter}").AsEnumerable().FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
