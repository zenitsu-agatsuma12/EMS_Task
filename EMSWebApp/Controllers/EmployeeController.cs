using EMSWebApp.Models;
using EMSWebApp.Repositories;
using EMSWebApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace EMSWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository _repo;

        public EmployeeController(IEmployeeRepository repo)
        {
            this._repo = repo;
        }
        // Get All
        public IActionResult GetEmployees()
        {
            string token = HttpContext.Session.GetString("JWToken");

            if (string.IsNullOrEmpty(token))
            {
                // Handle the case when the token is not available
                return RedirectToAction("Login", "Account");
            }

            var contacts =  _repo.GetEmployees(token);

            return View(contacts);
        }

        // Create

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeViewModel newEmployee)
        {
            if (ModelState.IsValid)
            {
                var token = HttpContext.Session.GetString("JWToken");
                var info = _repo.AddEmployees(newEmployee, token);
                return RedirectToAction("GetEmployees");
            }
            ViewData["Message"] = "Data is not valid to create the Employees";
            return View();
        }

        // Update

        [HttpPut]
        public IActionResult Update(int id, Employee newEmployee)
        {
            var updatedEmployee = _repo.UpdateEmployee(id, newEmployee);
            if (updatedEmployee != null)
            {
                return View("Success", updatedEmployee);
            }
            return View("Error");
        }

        // Get by ID

        public IActionResult Details(int id)
        {
            var employee = _repo.GetEmployeeById(id);
            if (employee != null)
            {
                return View(employee);
            }
            return View("Error");
        }

        public IActionResult Delete(int id)
        {
            var deletedEmployee = _repo.DeleteEmployee(id);
            if (deletedEmployee != null)
            {
                return View(deletedEmployee);
            }
            return View("Error");
        }

    }
}
