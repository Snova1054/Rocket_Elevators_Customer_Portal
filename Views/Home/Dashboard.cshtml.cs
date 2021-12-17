using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Rocket_Elevators_Customer_Portal.Views.Home
{
    [AllowAnonymous]
    public class DashboardModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<DashboardModel> _logger;

        public DashboardModel(SignInManager<IdentityUser> signInManager, 
            ILogger<DashboardModel> logger,
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        //[BindProperty]
        //public InputModel Input { get; set; }

        [BindProperty]
        public InputModel ClientIntervention { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        //public class InputModel
        //{
        //    [Required]
        //    [EmailAddress]
        //    public string Email { get; set; }

        //    [Required]
        //    [DataType(DataType.Password)]
        //    public string Password { get; set; }

        //    [Display(Name = "Remember me?")]
        //    public bool RememberMe { get; set; }
        //}
        public class InputModel
        {
            [Required]
            public int id { get; set; }
            [Required]
            public string Author { get; set; }
            [Required]
            public int CustomerID { get; set; }
            [Required]
            public int BuildingID { get; set; }
            [Required]
            public int BatteryID { get; set; }

            public int? ColumnID { get; set; }

            public int? ElevatorID { get; set; }

            public int? EmployeeID { get; set; }
            [Required]
            public string start_date { get; set; }
            [Required]
            public string end_date { get; set; }
            [Required]
            public string result { get; set; }
            [Required]
            public string report { get; set; }
            [Required]
            public string status { get; set; }
        }
    

        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl ??= Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            Console.WriteLine(returnUrl);
            returnUrl ??= Url.Content("~/");
            Console.WriteLine("HelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHello");
            Console.WriteLine("HelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHello");
            Console.WriteLine(returnUrl);
            Console.WriteLine("HelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHello");
            Console.WriteLine("HelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHello");
            Console.WriteLine("HelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHello");

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
