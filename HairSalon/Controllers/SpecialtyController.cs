using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        [HttpGet("/specialties")]
        public ActionResult Index()
        {
            List<Specialty> allspecialties = Specialty.GetAll();
            return View(allspecialties);
        }
        [HttpGet("/employee/{employeeId}/specialties/new")]
        public ActionResult CreateForm(int employeeId)
        {
            Employee employee = Employee.Find(employeeId);
            return View(employee);
        }
        [HttpGet("/employee/{employeeId}/specialties/{specialtiesId}")]
        public ActionResult Details(int employeeId, int specialtiesId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Specialty specialty = Specialty.Find(specialtiesId);
            Employee employee = Employee.Find(employeeId);
            model.Add("specialties", specialty);
            model.Add("employee", employee);
            return View(model);
        }
    }
}
