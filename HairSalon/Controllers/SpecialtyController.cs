using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet("/specialty")]
        public ActionResult Index()
        {
            List<Specialty> allspecialties = Specialty.GetAll();
            return View(allspecialties);
        }
        [HttpGet("/specialty/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpGet("/specialty/{specialtiesId}")]
        public ActionResult Details(int specialtiesId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty specialty = Specialty.Find(specialtiesId);
            List<Employee> allEmployees = Employee.GetAllEmployee();
            List<Employee> employee = specialty.GetEmployee();
            model.Add("specialty", specialty);
            model.Add("specialtyEmployee", employee);
            model.Add("allEmployees", allEmployees);
            return View(model);
        }
        [HttpPost("/specialty/{specialtyId}")]
        public ActionResult AddEmployeeToSpecialty(int specialtyId)
        {
            Specialty specialty = Specialty.Find(specialtyId);
            Employee employee = Employee.Find(int.Parse(Request.Form["employee-id"]));
            specialty.AddEmployee(employee);
            return RedirectToAction("Details", new { id = specialtyId });
        }
    }
}
