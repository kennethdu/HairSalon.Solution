using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/client")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAllClient();
            return View(allClients);
        }
        [HttpGet("/client/new")]
        public ActionResult CreateForm()
        {
            return View();
        }
        [HttpGet("/employee/{employeeId}/client/{clientId}")]
        public ActionResult Details(int employeeId, int clientId)
        {
            Client client = Client.Find(clientId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Employee employee = Employee.Find(employeeId);
            model.Add("client", client);
            model.Add("employee", employee);
            return View(model);
        }
        [HttpGet("/employee/{employeeId}/client/{clientId}/update")]
        public ActionResult UpdateForm (int employeeId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client thisClient = Client.Find(clientId);
            Employee thisEmployee = Employee.Find(employeeId);
            model.Add("employee", thisEmployee);
            model.Add("client", thisClient);
            return View(model);
        }
        [HttpGet("/employee/{employeeId}/client/{clientId}/delete")]
        public ActionResult DeleteOne(int employeeId, int clientId)
        {
            Client thisClient = Client.Find(clientId);
            Employee thisEmployee = Employee.Find(employeeId);
            thisClient.Delete();
            return RedirectToAction("Index");
        }
        [HttpPost("/employee/{employeeId}/client/{clientId}/update")]
        public ActionResult UpdateClient(int employeeId, int clientId)
        {
            Employee thisEmployee = Employee.Find(employeeId);
            Client thisClient = Client.Find(clientId);
            thisClient.Edit(Request.Form["new-client-name"]);
            return RedirectToAction("Index", thisClient);
        }
        [HttpPost("/employee/{employeeId}/client/new")]
        public ActionResult AddEmployee (int employeeId)
        {
            Employee employee = Employee.Find(employeeId);
            Client client = Client.Find(int.Parse(Request.Form["client-id"]));
            employee.AddClient(client);
            return RedirectToAction("Details", new {id = employeeId});
        }
    }
}
