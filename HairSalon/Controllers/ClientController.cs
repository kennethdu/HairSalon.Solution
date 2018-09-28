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
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client client = Client.Find(clientId);
            Employee employee = Employee.Find(employeeId);
            List<Client> employeeClient = employee.GetClient();
            model.Add("client", client);
            model.Add("employee", employee);
            model.Add("employeeClient", employeeClient);
            return View(model);
        }
        [HttpGet("client/{clientId}/update")]
        public ActionResult UpdateForm (int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Client thisClient = Client.Find(clientId);
            model.Add("client", thisClient);
            return View(model);
        }
        [HttpGet("client/delete")]
        public ActionResult DeleteAll()
        {
            Client.DeleteAll();
            return RedirectToAction("Index");
        }
        [HttpGet("client/{clientId}/delete")]
        public ActionResult DeleteOne(int employeeId, int clientId)
        {
            Client thisClient = Client.Find(clientId);
            Employee thisEmployee = Employee.Find(employeeId);
            thisClient.Delete();
            return RedirectToAction("Index");
        }
        [HttpPost("/client/{clientId}/update")]
        public ActionResult UpdateClient(int employeeId, int clientId)
        {
            Client thisClient = Client.Find(clientId);
            thisClient.Edit(Request.Form["new-client-name"]);
            return RedirectToAction("Index", thisClient);
        }
    
    }
}
