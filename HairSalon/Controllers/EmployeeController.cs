using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class EmployeeController : Controller
    {
        [HttpGet("/employee")]
        public ActionResult Index()
        {
            List<Employee> allEmployee = Employee.GetAllEmployee();
            return View();
        }
        [HttpGet("/employee/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpPost("/employee")]
        public ActionResult Create(string newEmployee)
        {
            Employee NewEmployee = new Employee(newEmployee);
            NewEmployee.Save();
            return RedirectToAction("Index");
        }

    }
}
