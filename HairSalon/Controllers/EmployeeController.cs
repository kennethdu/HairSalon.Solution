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
        [HttpGet("/employee/{employeeId}/update")]
        public ActionResult UpdateForm (int employeeId)
        {
            Employee thisEmployee = Employee.Find(employeeId);
            return View();
        }
        [HttpGet("/employee/{employeeId}/delete")]
        public ActionResult DeleteOne(int employeeId)
        {
            Employee thisEmployee = Employee.Find(employeeId);
            thisEmployee.Delete();
            return RedirectToAction("Index");
        }
        [HttpPost("/employee/{employeeId}/update")]
        public ActionResult Update (int employeeId)
        {
            Employee thisEmployee = Employee.Find(employeeId);
            thisEmployee.Edit(Request.Form["new-employee-name"]);
            return RedirectToAction("Index");
        }
        [HttpPost("/employee")]
        public ActionResult Create()
        {
            Employee NewEmployee = new Employee(Request.Form["new-employee"]);
            NewEmployee.Save();
            List<Employee> allEmployee = Employee.GetAllEmployee();
            return RedirectToAction("Index");
        }
        [HttpPost("/client")]
        public ActionResult CreateClient(string clientName, int employeeId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Employee foundEmployee = Employee.Find(employeeId);
            Client newClient = new Client(Request.Form["new-client"]);
            newClient.Save();
            List<Client> employeeClient = foundEmployee.GetClient();
            model.Add("client", employeeClient);
            model.Add("employee", foundEmployee);
            return RedirectToAction("Details", new {id = employeeId});
        }
        [HttpPost("/specialty")]
        public ActionResult CreateSpecialty(string specialtyName, int employeeId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Employee foundEmployee = Employee.Find(employeeId);
            Specialty newSpecialty = new Specialty(Request.Form["new-specialty"]);
            newSpecialty.Save();
            List<Specialty> employeeSpecialty = foundEmployee.GetSpecialty();
            model.Add("specialty", employeeSpecialty);
            model.Add("employee", foundEmployee);
            return RedirectToAction("Details", new{id = employeeId});
        }
    }
}
