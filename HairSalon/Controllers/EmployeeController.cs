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
            return View(allEmployee);
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
            List<Employee> allEmployee = Employee.GetAllEmployee();
            return View("Index", allEmployee);
        }
        [HttpGet("/employee/{id}")]
        public ActionResult Details(int id)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Employee selectedEmployee = Employee.Find(id);
            List<Client> employeeClient = selectedEmployee.GetClient();
            model.Add("employee", selectedEmployee);
            model.Add("client", employeeClient);
            return View(model);
        }
        // [HttpPost("/employee{employeeId}/client/new")]
        // public ActionResult CreateClient (int employeeId)
        // {
        //     Client thisClient = Client.Find(id);
        //     this
        // }
    }
}
