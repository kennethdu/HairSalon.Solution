using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAllClient();
            return View(allClients);
        }

    }
}
