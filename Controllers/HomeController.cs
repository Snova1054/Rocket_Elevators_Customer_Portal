using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rocket_Elevators_Customer_Portal.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.Net.Http;
using Rocket_Elevators_Customer_Portal;
using Microsoft.Extensions.Configuration.Json;
using System.Text.Json;




namespace Rocket_Elevators_Customer_Portal.Controllers
{
    public class HomeController : Controller
    {
        private static readonly HttpClient client = new HttpClient();
        //SignInManager<IdentityUser> SignInManager;
        //UserManager<IdentityUser> UserManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //public IActionResult Dashboard(string author, string start_date, string end_date, string result, string status, int customer_id, int building_id, int battery_id, int column_id, int elevator_id, int employee_id)
        public IActionResult Dashboard(string interventionString)
        {
            if(interventionString != "")
            {
                Intervention intervention = JsonSerializer.Deserialize<Intervention>(interventionString);
                Console.WriteLine("allo");
                Console.WriteLine(intervention.status);

            }
            
            //Intervention yesyes = Convert.
            //Console.WriteLine(yes.status);
            Intervention clientIntervention = new Intervention() {author = "daniel", start_date = DateTime.Now, end_date = DateTime.Now, result = "oui", report = "non", status = "ok", customer_id = 1, building_id = 1, battery_id = 1, column_id = 1, elevator_id = 1, employee_id = 1};
            //Console.WriteLine(clientIntervention.author);
            //my own cors policy
            return View();
        }

        public void postIntervention(string intervention)
        {
            Console.WriteLine("allo {0}", intervention);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
