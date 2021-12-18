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

        public IActionResult Dashboard(string author, string start_date, string end_date, string result, string report, string status, string customer_id, string building_id, string battery_id, string column_id, string elevator_id, string employee_id)
        //public IActionResult Dashboard(string interventionString)
        {
            //Console.WriteLine("allo");
            //Console.WriteLine(customer_id);
            //Console.WriteLine(building_id);
            //Console.WriteLine(battery_id);
            //Console.WriteLine(column_id);
            //Console.WriteLine(elevator_id);

            Intervention clientIntervention = new Intervention() {author = author, start_date = null, end_date = null, result = result, report = report, status = status, customer_id = Convert.ToInt32(customer_id), building_id = Convert.ToInt32(building_id), battery_id = Convert.ToInt32(battery_id), column_id = Convert.ToInt32(column_id), elevator_id = Convert.ToInt32(elevator_id), employee_id = null};
            Console.WriteLine(clientIntervention.author);
            //my own cors policy
            //var values = new Dictionary<string, string>
            //{
            //    { "thing1", "hello" },
            //    { "thing2", "world" }
            //};

            //var content = new FormUrlEncodedContent(values);
            string Json = JsonSerializer.Serialize(clientIntervention);

            client.PostAsJsonAsync("https://hidden-woodland-68127.herokuapp.com/api/interventions", Json);
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
