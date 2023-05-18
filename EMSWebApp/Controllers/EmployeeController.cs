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
            var employees = _repo.GetEmployees();
            return View(employees);
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
                var info = _repo.AddEmployees(newEmployee);
                return RedirectToAction("GetEmployees");
            }
            ViewData["Message"] = "Data is not valid to create the Employees";
            return View();
        }
    }
}
