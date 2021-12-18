using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rocket_Elevators_Customer_Portal.Models;
using System;
using System.Net;
using System.IO;
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
        {
            Intervention clientIntervention = new Intervention() {author = author, start_date = null, end_date = null, result = result, report = report, status = status, customer_id = Convert.ToInt32(customer_id), building_id = Convert.ToInt32(building_id), battery_id = Convert.ToInt32(battery_id), column_id = Convert.ToInt32(column_id), elevator_id = Convert.ToInt32(elevator_id), employee_id = null};

            if (clientIntervention.elevator_id != 0)
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://hidden-woodland-68127.herokuapp.com/api/interventions");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = JsonSerializer.Serialize(clientIntervention);


                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var hello = streamReader.ReadToEnd();
                }

            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
