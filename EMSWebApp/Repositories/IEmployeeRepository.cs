using EMSWebApp.Models;
using Microsoft.VisualBasic;

namespace EMSWebApp.Repositories
{
    public interface IEmployeeRepository
    {
        // get
        Task<List<Employee>> GetEmployees();

        // get by id
        Employee GetEmployeeById(int id);

        // add 
        Task<Employee?> AddEmployees(Employee newEmployee);

        // update 
        Employee UpdateEmployee(int id, Employee newEmployee);

        // delete 
        Employee DeleteEmployee(int id);
    }
}
