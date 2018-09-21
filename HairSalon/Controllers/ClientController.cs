using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/allclients")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAllClient();
            return View(allClients);
        }
        [HttpGet("/employee/{employeeId}/client/new")]
        public ActionResult CreateForm(int employeeId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Employee employee = Employee.Find(employeeId);
            return View(employee);
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

    }
}
