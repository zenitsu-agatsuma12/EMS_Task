using EMSWebApp.Models;
using EMSWebApp.ViewModel;
using Microsoft.VisualBasic;

namespace EMSWebApp.Repositories
{
    public interface IEmployeeRepository
    {
        // get
        List<Employee> GetEmployees();

        // get by id
        Employee GetEmployeeById(int id);

        // add 
        EmployeeViewModel AddEmployees(EmployeeViewModel newEmployee);

        // update 
        Employee UpdateEmployee(int id, Employee newEmployee);

        // delete 
        Employee DeleteEmployee(int id);
    }
}
