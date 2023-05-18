using EMSWebApp.Models;
using EMSWebApp.ViewModel;
using Microsoft.VisualBasic;

namespace EMSWebApp.Repositories
{
    public interface IEmployeeRepository
    {
        // get
        List<Employee> GetEmployees(string token);

        // get by id
        Employee GetEmployeeById(int id, string token);

        // add 
        EmployeeViewModel AddEmployees(EmployeeViewModel newEmployee, string token);

        // update 
        Employee UpdateEmployee(int Id, Employee newEmployee);

        // delete 
        Employee DeleteEmployee(int id);
    }
}
